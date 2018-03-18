using System;
using System.Windows.Forms;

namespace Serial_Port
{
    public partial class Form1 : Form
    {
        //Przycisk wyślij
        private void butSend_Click(object sender, EventArgs e)
        {
            SendCommand(rtbSend.Text);
        }

        //Naciśnięcie klawisza enter
        private void rtbSend_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return) butSend_Click(sender, e);
        }

        //Przycisk wyczyść
        private void butClear_Click(object sender, EventArgs e)
        {
            rtbSend.Text = "";
            rtbConsole.Text = "";
        }

        //Przycisk wstaw funckję
        private void btInsertFunction_Click(object sender, EventArgs e)
        {
            if (rtbSend.TextLength != 0) rtbSend.Text += " ";
            rtbSend.Text += comboBox2.Text;
        }

        //Przycisk wstaw zmienną
        private void btInsertParam_Click(object sender, EventArgs e)
        {
            int place = rtbSend.Text.IndexOf(" p");
            if (place > 0) rtbSend.Text = rtbSend.Text.Remove(++place, 1);
            else
            {
                if (rtbSend.TextLength > 0) rtbSend.Text += " ";
                place = rtbSend.Text.Length;
            }
            rtbSend.Text = rtbSend.Text.Insert(place, comboBox1.Text);
        }

        //Wypisz na konsoli
        private void ConsoleMessage(System.Windows.Forms.RichTextBox richTextBox, string text, System.Drawing.Color color, bool newLine = true)
        {
            var startIndex = richTextBox.TextLength;
            richTextBox.AppendText(text);
            if (newLine) richTextBox.AppendText(Environment.NewLine);
            var endIndex = richTextBox.TextLength;
            richTextBox.Select(startIndex, endIndex - startIndex);
            richTextBox.SelectionColor = color;
        }

        //Przesunięcie widoku konsoli na koniec
        private void richTextBox_TextChanged(object sender, EventArgs e)
        {
            rtbConsole.SelectionStart = rtbConsole.Text.Length;
            rtbConsole.ScrollToCaret();
        }
    }
}
