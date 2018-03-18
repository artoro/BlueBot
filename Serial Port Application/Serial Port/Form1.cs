using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Timers;

namespace Serial_Port
{
    public partial class Form1 : Form
    {
        //KONSTRUKTOR OKIENKA
        public Form1()
        {
            //Zainicjowanie okienka
            InitializeComponent();
            FormGraph_HideEditMenu();

            //Załadowanie biblioteki BlueBoard
            BlueBotCompiler.LoadLibrary(@"C:\Users\Admin\Documents\Arduino\AlphaBot\BlueBot\Names.h");
            this.comboBox1.Items.AddRange(BlueBotCompiler.GetVariables());
            this.comboBox2.Items.AddRange(BlueBotCompiler.GetFunctions());

            //Inicjalizacja obiektu oraz eventów do obsługi połączenia (odbierania i wysyłania danych)
            InitializeSerialPort();

            //Inicjalizacja obsługi klawiatury i GUI
            InitializeGUI();
        }

        //Przycisk stanu
        private void stateBox_Click(object sender, EventArgs e)
        {
            //jeżeli połączenie jest aktywne to je kończymy, zmieniamy kolor na red i zmieniamy napis 
            if (serial.IsOpen || testCOM_ON)
            {
                stateBox.BackColor = stateBox1.BackColor = System.Drawing.Color.Red;
                if (serial.IsOpen) serial.Close();
                else testCOM_ON = false;
                labStatus.Text = labStatus1.Text = "Brak połączenia";
                ConsoleMessage(rtbConsole, "\nZakończono połączenie z " + serial.PortName + "\n", System.Drawing.Color.Orange);
                FormGraph_ShowCbName();
            }
            //w przeciwnym wypadku włączamy połączenie, zmieniamy kolor na zielony i zmieniamy napis 
            else
            {
                //połączenie może nie być możliwe dlatego należy się zabezpieczyć na wypadek błędu 
                try
                {
                    //najpierw przepisujemy do portu parametry z opcji 
                    serial.PortName = this.cbName.Text;
                    serial.BaudRate = Int32.Parse(this.cbBaud.Text);
                    serial.DataBits = Int32.Parse(this.cbData.Text);
                    serial.Parity = (Parity)Enum.Parse(typeof(Parity), this.cbParity.Text);
                    serial.StopBits = (StopBits)Enum.Parse(typeof(StopBits), this.cbStop.Text);
                    //a następnie uruchamiamy port 
                    if (serial.PortName == "TestCOM") testCOM_ON = true;
                    else serial.Open();
                    //po uruchomieniu zmieniamy elementy graficzne interfejsu 
                    stateBox.BackColor = stateBox1.BackColor = System.Drawing.Color.Green;
                    labStatus.Text = labStatus1.Text = "Aktywne połączenie (port:" + serial.PortName.ToString() +
                                                       ", prędkość: " + serial.BaudRate.ToString() +
                                                       ", bity danych: " + serial.DataBits.ToString() +
                                                       "\n bity stopu: " + serial.StopBits.ToString() +
                                                       ", parzystość: " + serial.Parity.ToString() + ")";
                    ConsoleMessage(rtbConsole, "Rozpoczęto połączenie z " + serial.PortName, System.Drawing.Color.Orange);
                    FormGraph_HideCbName();
                }
                //jeżeli nastąpi błąd to go przechwycimy i wyświetlimy stosowny komunikat 
                catch (Exception exc)
                {
                    MessageBox.Show("Błąd połączenia:" + exc.Message);
                    ConsoleMessage(rtbConsole, "Błąd połączenia z " + serial.PortName, System.Drawing.Color.Red);
                    stateBox.BackColor = stateBox1.BackColor = System.Drawing.Color.Red;
                    FormGraph_ShowCbName();
                }
            }
        }
    }
}
