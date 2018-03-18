using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO.Ports;
using System.Linq;
using System.Windows.Forms;

namespace Serial_Port
{
    public partial class Form1 : Form
    {
        private SerialPort serial;
        private bool testCOM_ON;
        private delegate void SerialReceiverEventHandler();
        private SerialReceiverEventHandler serReceiver;
        volatile private bool serialPortIsBusy;
        volatile private Queue<byte> serialPortBuffer;

        //Inicjalizacja obiektu oraz eventów do obsługi połączenia (odbierania i wysyłania danych)
        public void InitializeSerialPort()
        {
            serial = new SerialPort();
            serial.ReadTimeout = 1000;
            serial.WriteTimeout = 1000;
            serReceiver = new SerialReceiverEventHandler(WriteRecieved);
            serial.DataReceived += new SerialDataReceivedEventHandler(DataRecievedHandler);
            serialPortIsBusy = false;
            serialPortBuffer = new Queue<byte>();
            butRefresh_Click(null, null);
            testCOM_ON = false;
        }

        //Aktualizacja ustawień i listy dostępnych portów
        private void butRefresh_Click(object sender, EventArgs e)
        {
            cbName.Items.Clear();
            cbName1.Items.Clear();
            cbName2.Items.Clear();
            cbParity.Items.Clear();
            cbStop.Items.Clear();
            foreach (String s in SerialPort.GetPortNames())
            {
                cbName.Items.Add(s);
                cbName1.Items.Add(s);
                cbName2.Items.Add(s);
            }
            cbName.Items.Add("TestCOM");
            cbName1.Items.Add("TestCOM");
            cbName2.Items.Add("TestCOM");
            foreach (String s in Enum.GetNames(typeof(Parity))) cbParity.Items.Add(s);
            foreach (String s in Enum.GetNames(typeof(StopBits))) cbStop.Items.Add(s);

            butDefault_Click(sender, e);
        }

        //Ustawienia domyślne
        private void butDefault_Click(object sender, EventArgs e)
        {
            if (cbName.Items.Contains("COM3")) cbName.Text = "COM3";
            else if (cbName.Items.Contains("COM5")) cbName.Text = "COM5";
            else cbName.Text = "TestCOM";
            cbBaud.Text = "9600";
            cbData.Text = "8";
            cbParity.Text = "None";
            cbStop.Text = "One";
            cbHex.Checked = false;
        }

        //Przycisk anuluj
        private void butCancel_Click(object sender, EventArgs e)
        {
            cbName.Text = serial.PortName.ToString();
            cbBaud.Text = serial.BaudRate.ToString();
            cbData.Text = serial.DataBits.ToString();
            cbParity.Text = serial.Parity.ToString();
            cbStop.Text = serial.StopBits.ToString();
            cbHex.Checked = true;
        }

        //Zmiana portu
        private void cbName_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            cbName.SelectedItem = cb.SelectedItem;
            cbName1.SelectedItem = cb.SelectedItem;
            cbName2.SelectedItem = cb.SelectedItem;
        }

        //Wczytanie odebranych danych
        private void DataRecievedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            rtbConsole.Invoke(serReceiver);
        }
        private void WriteRecieved()
        {
            try
            {
                while (serial.BytesToRead > 0) ConsoleMessage(rtbConsole, serial.ReadLine(), System.Drawing.Color.Blue, false);
            }
            catch (TimeoutException) { ConsoleMessage(rtbConsole, "ReadTimeoutException", System.Drawing.Color.Red); serial.DiscardInBuffer(); }
        }

        //Sprawdzenie bufora danych
        void SerialPortCheck(object sender, EventArgs e)
        {
            if (serialPortBuffer.Count > 0 && serialPortBuffer.Last() == 0) SendCommand(String.Empty);
        }

        //Przygotowanie danych do wysłania
        private void SendCommand(string buffer)
        {
            if (serial.IsOpen || testCOM_ON)
            {
                int correct;
                byte[] code = new byte[] { };
                if (buffer.Length > 0) code = BlueBotCompiler.Compile(buffer, out correct);
                if (code == null) ConsoleMessage(rtbConsole, "Wystąpił błąd przy kompilacji!", System.Drawing.Color.Red);
                else foreach (byte b in code) serialPortBuffer.Enqueue(b);

                if (serialPortBuffer.Count == 0) return;

                if (serialPortIsBusy || serial.IsOpen && (serial.BytesToRead > 0 || serial.BytesToWrite > 0)) return;
                stateBox.BackColor = stateBox1.BackColor = System.Drawing.Color.Yellow;
                butSend.Enabled = false;
                rtbSend.Enabled = false;
                serialPortIsBusy = true;

                if (cbHex.Checked) foreach (byte s in serialPortBuffer)
                        ConsoleMessage(rtbConsole, s.ToString() + " ", System.Drawing.Color.DarkGray, s == serialPortBuffer.Last());
                else ConsoleMessage(rtbConsole, BlueBotCompiler.Decompile(serialPortBuffer.ToArray()), System.Drawing.Color.Black);
                backgroundSender.RunWorkerAsync(); //tworzy wątek wysyłający dane
            }
            else System.Windows.Forms.MessageBox.Show("Aby wysłać dane musisz najpierw ustanowić połączenie!");
        }

        //Wysłanie danych
        private void backgroundSender_DoWork(object sender, DoWorkEventArgs e)
        {
            int length = serialPortBuffer.Count;
            if (serial.IsOpen) serial.Write(serialPortBuffer.ToArray(), 0, length);
            while (length-- > 0) serialPortBuffer.Dequeue();
        }

        //Zakończenie wysyłania danych
        private void backgroundSender_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            stateBox.BackColor = stateBox1.BackColor = System.Drawing.Color.Green;
            butSend.Enabled = true;
            rtbSend.Enabled = true;
            serialPortIsBusy = false;
        }
    }
}