using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Serial_Port
{
    public partial class Form2 : Form
    {
        private ButtonGUI editedKey;
        private bool changeKey;
        private bool changeSign;
        private bool isActiveUp;

        public Form2(Form1 main, ButtonGUI _editedButton)
        {
            InitializeComponent();
            this.comboBox1.Items.AddRange(BlueBotCompiler.GetFunctions());
            this.comboBox2.Items.AddRange(BlueBotCompiler.GetVariables());

            editedKey = _editedButton;
            this.kbEdited.Text = editedKey.Button.Text;
            this.rtbCommandDown.Text = editedKey.CommandDown;
            this.rtbCommandUp.Text = editedKey.CommandUp;

            changeKey = false;
            changeSign = false;
            isActiveUp = false;
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void setButton_Click(object sender, EventArgs e)
        {
            this.Enabled = false;
            int correct = 0;
            byte[] codeDown = BlueBotCompiler.Compile(rtbCommandDown.Text, out correct);
            if (codeDown == null)
            {
                rtbCommandDown.SelectAll();
                rtbCommandDown.SelectionBackColor = Color.Transparent;
                rtbCommandDown.Select(correct, 1);
                rtbCommandDown.SelectionBackColor = Color.Red;
                this.Enabled = true;
                return;
            }
            byte[] codeUp = BlueBotCompiler.Compile(rtbCommandUp.Text, out correct);
            if (codeUp == null)
            {
                rtbCommandUp.SelectAll();
                rtbCommandUp.SelectionBackColor = Color.Transparent;
                rtbCommandUp.Select(correct, 1);
                rtbCommandUp.SelectionBackColor = Color.Red;
                this.Enabled = true;
                return;
            }
            editedKey.Button.Text = kbEdited.Text;
            editedKey.CommandDown = rtbCommandDown.Text;
            editedKey.CodeDown = codeDown;
            editedKey.CommandUp = rtbCommandUp.Text;
            editedKey.CodeUp = codeUp;
            this.Close();
        }

        private void btChangeSign_Click(object sender, EventArgs e)
        {
            changeKey = false;
            changeSign = true;
            rtbCommandDown.Enabled = false;
            rtbCommandUp.Enabled = false;
        }

        private void btChangeKey_Click(object sender, EventArgs e)
        {
            changeKey = true;
            changeSign = false;
            rtbCommandDown.Enabled = false;
            rtbCommandUp.Enabled = false;
        }

        private void kb_KeyDown(object sender, KeyEventArgs e)
        {
            if (changeKey)
            {
                editedKey.Key = e.KeyCode;
                changeKey = false;
                rtbCommandDown.Enabled = true;
                rtbCommandUp.Enabled = true;
            }
            else if (changeSign)
            {
                kbEdited.Text = Convert.ToChar(e.KeyValue).ToString();
                changeSign = false;
                rtbCommandDown.Enabled = true;
                rtbCommandUp.Enabled = true;
            }
            else if (e.KeyCode == editedKey.Key)
                kbEdited.Font = new Font(kbEdited.Font, kbEdited.Font.Style & FontStyle.Bold);
        }

        private void kb_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == editedKey.Key)
                kbEdited.Font = new Font(kbEdited.Font, kbEdited.Font.Style & ~FontStyle.Bold);
        }
        
        private void btInsertFunction_Click(object sender, EventArgs e)
        {
            if (isActiveUp) Replace(rtbCommandUp.Text, comboBox1.Text, -1);
            else rtbCommandDown.Text = Replace(rtbCommandDown.Text, comboBox1.Text, -1);
        }

        private void btInsertParam_Click(object sender, EventArgs e)
        {
            if (isActiveUp) rtbCommandUp.Text = Replace(rtbCommandUp.Text, comboBox2.Text);
            else rtbCommandDown.Text = Replace(rtbCommandDown.Text, comboBox2.Text);
        }

        private string Replace(string source, string text, int place = 0)
        {
            if (place == 0) place = source.IndexOf(" p");
            if (place > 0) source = source.Remove(++place, 1);
            else
            {
                if (source.Length > 0) source += " ";
                place = source.Length;
            }
            return source.Insert(place, text);
        }

        private void rtbCommandDown_Click(object sender, EventArgs e)
        {
            isActiveUp = false;
        }

        private void rtbCommandUp_Click(object sender, EventArgs e)
        {
            isActiveUp = true;
        }
    }
}
