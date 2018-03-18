using System;
using System.Windows.Forms;
using System.Drawing;

namespace Serial_Port
{
    public class ButtonGUI : PanelGUI
    {
        public Keys Key { get; set; }
        public Button Button { get; set; }
        public string CommandUp { get; set; }
        public byte[] CodeUp { get; set; }
        public string CommandDown { get; set; }
        public byte[] CodeDown { get; set; }
        public bool isPressed { get; set; }

        public ButtonGUI(Keys _key,
                        string _button,
                        Form1 _form,
                        GroupBox _groupBox,
                        Point _location,
                        string _commandDown,
                        string _commandUp) : base()
        {
            Key = _key;
            Location = _location;
            CommandUp = _commandUp;
            CommandDown = _commandDown;
            Element = 'B';
            isPressed = false;

            Button = new Button();
            _groupBox.Controls.Add(Button);
            Button.Text = _button;
            Button.Anchor = System.Windows.Forms.AnchorStyles.None;
            Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            Button.Margin = new System.Windows.Forms.Padding(0);
            Button.Size = new Size(PanelGUI.CellSize.Width - 4, PanelGUI.CellSize.Height - 4);
            Button.TabIndex = 0;
            Button.UseVisualStyleBackColor = true;
            Button.Click += new System.EventHandler(_form.kbButton_Click);

            int correct;
            CodeUp = BlueBotCompiler.Compile(CommandUp, out correct);
            if (CodeUp == null) { CommandUp = String.Empty; CodeUp = new byte[] { 0 }; }
            CodeDown = BlueBotCompiler.Compile(CommandDown, out correct);
            if (CodeDown == null) { CommandDown = String.Empty; CodeDown = new byte[] { 0 }; }
        }

        public override void Paint(ref Point drawingPoint)
        {
            Point drawingLocation;
            if ((Location.X > drawingPoint.X && Location.Y == drawingPoint.Y) || Location.Y > drawingPoint.Y) drawingLocation = Location;
            else drawingLocation = drawingPoint;
            Button.Location = new Point(drawingLocation.X * PanelGUI.CellSize.Width + 2 + PanelGUI.WebBoundary.X,
                                        drawingLocation.Y * PanelGUI.CellSize.Height + 2 + PanelGUI.WebBoundary.Y);
            drawingPoint.X++;
            if (drawingPoint.X >= PanelGUI.WebSize.Width)
            {
                drawingPoint.X = 0;
                drawingPoint.Y++;
            }
        }


    }
}
