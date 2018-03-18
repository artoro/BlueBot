using System;
using System.Collections;
using System.Drawing;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Serial_Port
{
    public partial class Form1 : Form
    {
        private bool editKeys;
        private bool addingItemsGUI;
        private Form2 editingKeyForm;
        private System.Windows.Forms.Timer kbTimer;

        //Inicjalizacja GUI
        public void InitializeGUI()
        {
            //Timer klawiatury
            kbTimer = new System.Windows.Forms.Timer();
            kbTimer.Interval = 100;
            kbTimer.Tick += new EventHandler(SerialPortCheck);
            kbTimer.Start();

            //Utworzenie klawiatury
            PanelGUI.Panel = gbPanel;
            PanelGUI.Elements = new ArrayList();
            new ButtonGUI(Keys.Divide, "↶", this, gbPanel, new System.Drawing.Point(0, 0), "SetParam 21=40; SetParam SERVO_UPDATE=6; CalcParams SERVO_ANGLE=SERVO_ANGLE - 21; UpdateServo;", "");
            new ButtonGUI(Keys.Add, "⇈", this, gbPanel, new System.Drawing.Point(1, 0), "SetParam MOT_SPEED=240; SetSpeed;", "SetParam MOT_SPEED=200; SetSpeed;");
            new ButtonGUI(Keys.Multiply, "↷", this, gbPanel, new System.Drawing.Point(2, 0), "SetParam 21=40; SetParam SERVO_UPDATE=6; CalcParams SERVO_ANGLE=SERVO_ANGLE + 21; UpdateServo;", "");
            new ButtonGUI(Keys.NumPad7, "↰", this, gbPanel, new System.Drawing.Point(0, 1), "SetParam MOT_DIRECTION=20; SetDirection;", "SetParam MOT_DIRECTION=0; SetDirection;");
            new ButtonGUI(Keys.NumPad8, "↑", this, gbPanel, new System.Drawing.Point(1, 1), "SetParam MOT_DIRECTION=0; SetDirection;", "MotorBrake");
            new ButtonGUI(Keys.NumPad9, "↱", this, gbPanel, new System.Drawing.Point(2, 1), "SetParam MOT_DIRECTION=340; SetDirection;", "SetParam MOT_DIRECTION=0; SetDirection;");
            new ButtonGUI(Keys.NumPad4, "←", this, gbPanel, new System.Drawing.Point(0, 2), "SetParam MOT_DIRECTION=45; SetDirection;", "SetParam MOT_DIRECTION=0; SetDirection;");
            new ButtonGUI(Keys.NumPad5, "X", this, gbPanel, new System.Drawing.Point(1, 2), "MotorBrake", "");
            new ButtonGUI(Keys.NumPad6, "→", this, gbPanel, new System.Drawing.Point(2, 2), "SetParam MOT_DIRECTION=315; SetDirection;", "SetParam MOT_DIRECTION=0; SetDirection;");
            new ButtonGUI(Keys.NumPad1, "↲", this, gbPanel, new System.Drawing.Point(0, 3), "SetParam MOT_DIRECTION=135; SetDirection;", "SetParam MOT_DIRECTION=180; SetDirection;");
            new ButtonGUI(Keys.NumPad2, "↓", this, gbPanel, new System.Drawing.Point(1, 3), "SetParam MOT_DIRECTION=180; SetDirection;", "MotorBrake; SetParam MOT_DIRECTION=0; SetDirection;");
            new ButtonGUI(Keys.NumPad3, "↳", this, gbPanel, new System.Drawing.Point(2, 3), "SetParam MOT_DIRECTION=225; SetDirection;", "SetParam MOT_DIRECTION=180; SetDirection;");
            PanelGUI.Update();
            editKeys = false;
            addingItemsGUI = false;
        }

        //Kliknięcie przycisku myszką
        public void kbButton_Click(object sender, EventArgs e)
        {
            foreach (ButtonGUI bGUI in PanelGUI.Elements) if (bGUI.Button == (Button)sender)
            {
                if (editKeys) //edycja przycisku
                {
                    if (editingKeyForm != null) editingKeyForm.Close();
                    editingKeyForm = new Form2(this, bGUI);
                    editingKeyForm.ShowDialog();
                }
                else if (!bGUI.isPressed && (serial.IsOpen || testCOM_ON)) //wysłanie komendy wciśnięcia
                    foreach (byte b in bGUI.CodeDown) serialPortBuffer.Enqueue(b);
                return;
            }
        }

        //Wciśnięcie przycisku z klawiatury
        public void kb_KeyDown(object sender, KeyEventArgs e)
        {
            if (!editKeys && (serial.IsOpen || testCOM_ON))
                foreach (ButtonGUI bGUI in PanelGUI.Elements) if (bGUI.Key == e.KeyCode)
                {
                    if (!bGUI.isPressed) //wysłanie komendy wciśnięcia
                    {
                        foreach (byte b in bGUI.CodeDown) serialPortBuffer.Enqueue(b);
                        bGUI.isPressed = true;
                    }
                    return;
                }
        }

        //Puszczenie przycisku klawiatury
        private void kb_KeyUp(object sender, KeyEventArgs e)
        {
            if (!editKeys && (serial.IsOpen || testCOM_ON))
                foreach (ButtonGUI bGUI in PanelGUI.Elements) if (bGUI.Key == e.KeyCode) //wysłanie komendy puszczenia
                {
                    foreach (byte b in bGUI.CodeUp) serialPortBuffer.Enqueue(b);
                    bGUI.isPressed = false;
                    return;
                }
        }

        //Wciśnięcie przycisku edycji
        private void bEdit_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            if (editKeys)
            {
                if (editingKeyForm != null) editingKeyForm.Close();
                b.Text = "Edytuj";
                FormGraph_HidePanelBackground();
                FormGraph_HideEditMenu();
            }
            else
            {
                b.Text = "Zapisz";
                FormGraph_ShowPanelBackground();
                FormGraph_ShowEditMenu();
            }
            editKeys = !editKeys;
        }

        //Zapis panelu sterowania wraz z zaprogramowanymi komendami
        private void bSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.DefaultExt = "txt";
            saveFileDialog1.AddExtension = true;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamWriter writer = new StreamWriter(saveFileDialog1.OpenFile());
                if (writer != null)
                {
                    StringBuilder sb = new StringBuilder();
                    foreach (PanelGUI kb in PanelGUI.Elements) switch (kb.Element)
                        {
                            case 'B':
                                ButtonGUI bGUI = (ButtonGUI)kb;
                                sb.AppendLine("B~" + bGUI.Button.Text + "~" + bGUI.Key + "~"
                                             + bGUI.CommandDown + "~" + bGUI.CommandUp + "~"
                                             + bGUI.Location.X + "," + bGUI.Location.Y);
                                break;
                        }
                    writer.Write(sb.ToString());
                    writer.Close();
                }
            }
        }

        //Wczytanie panelu sterowania i zaprogramowanych komend
        private void bLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.RestoreDirectory = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamReader reader = new StreamReader(openFileDialog1.OpenFile());
                if (reader != null)
                {
                    while(!reader.EndOfStream)
                    {
                        string s = reader.ReadLine();
                        Regex regex = new Regex(@"~");
                        string[] sTab = regex.Split(s);
                        if (sTab.Length == 6)
                        {
                            switch (sTab[0])
                            {
                            case "B":
                                GroupBox _groupBox = gbPanel;
                                string _button = sTab[1];
                                Keys _keys;
                                Enum.TryParse(sTab[2], out _keys);
                                string _commandDown = sTab[3];
                                string _commandUp = sTab[4];
                                regex = new Regex(@",");
                                string[] size = regex.Split(sTab[5]);
                                Point _panelLocation = new Point(int.Parse(size[0]), int.Parse(size[1]));
                                new ButtonGUI(_keys, _button, this, _groupBox, _panelLocation, _commandDown, _commandUp);
                                break;
                            case "S":
                                break;
                            }
                        }
                    }
                    reader.Close();
                }
            }
        }

        private void bAdd_Click(object sender, EventArgs e)
        {
            if (addingItemsGUI = !addingItemsGUI)
            {
                Cursor = Cursors.Cross;
                bAdd.Text = "Edytuj";
            }
            else
            {
                Cursor = Cursors.Default;
                bAdd.Text = ((cbAdd.SelectedText.ToString().Contains("-")) ? "Usuń" : "Dodaj");
            }
        }

        private void cbAdd_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (addingItemsGUI)
            {
                bAdd.Text = "Edytuj";
            }
            else
            {
                bAdd.Text = ((cbAdd.SelectedItem.ToString().Contains("-")) ? "Usuń" : "Dodaj");
            }
        }

        private void gbPanel_Click(object sender, EventArgs e)
        {
            if (addingItemsGUI)
            {
                Point cell = PanelGUI.GetCell(Cursor.Position);
                labelTest.Text = "zle";
                //switch (cbAdd.SelectedItem.ToString())
                //{
                //    case "-":
                //        break;
                //    case "Przycisk":
                //        new ButtonGUI(Keys.F1, String.Empty, this, gbPanel, cell, string.Empty, string.Empty);
                //        break;
                //    case "Suwak":
                //        break;
                //    case "Wartość":
                //        break;
                //    default:
                //        bAdd.Text = "err";
                //        break;
                //}
                //PanelGUI.Update();
            }
        }
    }
}
