using System;
using System.Windows.Forms;

namespace Serial_Port
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tabMenu = new System.Windows.Forms.TabControl();
            this.tabConsole = new System.Windows.Forms.TabPage();
            this.cbName1 = new System.Windows.Forms.ComboBox();
            this.butRefresh1 = new System.Windows.Forms.Button();
            this.rtbSend = new System.Windows.Forms.RichTextBox();
            this.btInsertParam = new System.Windows.Forms.Button();
            this.btInsertFunction = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.butClear = new System.Windows.Forms.Button();
            this.butSend = new System.Windows.Forms.Button();
            this.rtbConsole = new System.Windows.Forms.RichTextBox();
            this.labStatus = new System.Windows.Forms.Label();
            this.stateBox = new System.Windows.Forms.PictureBox();
            this.tabGUI = new System.Windows.Forms.TabPage();
            this.labelTest = new System.Windows.Forms.Label();
            this.cbAdd = new System.Windows.Forms.ComboBox();
            this.bAdd = new System.Windows.Forms.Button();
            this.bSave = new System.Windows.Forms.Button();
            this.bLoad = new System.Windows.Forms.Button();
            this.bRestart = new System.Windows.Forms.Button();
            this.cbName2 = new System.Windows.Forms.ComboBox();
            this.butRefresh2 = new System.Windows.Forms.Button();
            this.gbGraphics = new System.Windows.Forms.GroupBox();
            this.pbEchoSensor = new System.Windows.Forms.PictureBox();
            this.pbBlueBoard = new System.Windows.Forms.PictureBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.labStatus1 = new System.Windows.Forms.Label();
            this.bEdit = new System.Windows.Forms.Button();
            this.stateBox1 = new System.Windows.Forms.PictureBox();
            this.gbPanel = new System.Windows.Forms.GroupBox();
            this.tabOptions = new System.Windows.Forms.TabPage();
            this.cbHex = new System.Windows.Forms.CheckBox();
            this.butRefresh = new System.Windows.Forms.Button();
            this.butCancel = new System.Windows.Forms.Button();
            this.butDefault = new System.Windows.Forms.Button();
            this.cbStop = new System.Windows.Forms.ComboBox();
            this.cbParity = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbData = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbBaud = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbName = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.backgroundSender = new System.ComponentModel.BackgroundWorker();
            this.tabMenu.SuspendLayout();
            this.tabConsole.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stateBox)).BeginInit();
            this.tabGUI.SuspendLayout();
            this.gbGraphics.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbEchoSensor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBlueBoard)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stateBox1)).BeginInit();
            this.tabOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabMenu
            // 
            this.tabMenu.Controls.Add(this.tabConsole);
            this.tabMenu.Controls.Add(this.tabGUI);
            this.tabMenu.Controls.Add(this.tabOptions);
            this.tabMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMenu.Location = new System.Drawing.Point(0, 0);
            this.tabMenu.Name = "tabMenu";
            this.tabMenu.SelectedIndex = 0;
            this.tabMenu.Size = new System.Drawing.Size(384, 361);
            this.tabMenu.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabMenu.TabIndex = 0;
            this.tabMenu.KeyDown += new System.Windows.Forms.KeyEventHandler(this.kb_KeyDown);
            this.tabMenu.KeyUp += new System.Windows.Forms.KeyEventHandler(this.kb_KeyUp);
            // 
            // tabConsole
            // 
            this.tabConsole.AccessibleName = "";
            this.tabConsole.Controls.Add(this.cbName1);
            this.tabConsole.Controls.Add(this.butRefresh1);
            this.tabConsole.Controls.Add(this.rtbSend);
            this.tabConsole.Controls.Add(this.btInsertParam);
            this.tabConsole.Controls.Add(this.btInsertFunction);
            this.tabConsole.Controls.Add(this.comboBox1);
            this.tabConsole.Controls.Add(this.comboBox2);
            this.tabConsole.Controls.Add(this.butClear);
            this.tabConsole.Controls.Add(this.butSend);
            this.tabConsole.Controls.Add(this.rtbConsole);
            this.tabConsole.Controls.Add(this.labStatus);
            this.tabConsole.Controls.Add(this.stateBox);
            this.tabConsole.Location = new System.Drawing.Point(4, 22);
            this.tabConsole.Name = "tabConsole";
            this.tabConsole.Padding = new System.Windows.Forms.Padding(3);
            this.tabConsole.Size = new System.Drawing.Size(376, 335);
            this.tabConsole.TabIndex = 0;
            this.tabConsole.Text = "Konsola";
            this.tabConsole.UseVisualStyleBackColor = true;
            // 
            // cbName1
            // 
            this.cbName1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbName1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbName1.FormattingEnabled = true;
            this.cbName1.Location = new System.Drawing.Point(266, 10);
            this.cbName1.Margin = new System.Windows.Forms.Padding(10, 10, 30, 10);
            this.cbName1.Name = "cbName1";
            this.cbName1.Size = new System.Drawing.Size(97, 21);
            this.cbName1.TabIndex = 13;
            this.cbName1.SelectedIndexChanged += new System.EventHandler(this.cbName_SelectedIndexChanged);
            // 
            // butRefresh1
            // 
            this.butRefresh1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butRefresh1.Location = new System.Drawing.Point(188, 10);
            this.butRefresh1.Name = "butRefresh1";
            this.butRefresh1.Size = new System.Drawing.Size(65, 21);
            this.butRefresh1.TabIndex = 12;
            this.butRefresh1.Text = "Odśwież";
            this.butRefresh1.UseVisualStyleBackColor = true;
            this.butRefresh1.Click += new System.EventHandler(this.butRefresh_Click);
            // 
            // rtbSend
            // 
            this.rtbSend.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbSend.Location = new System.Drawing.Point(10, 237);
            this.rtbSend.MinimumSize = new System.Drawing.Size(4, 21);
            this.rtbSend.Name = "rtbSend";
            this.rtbSend.Size = new System.Drawing.Size(172, 21);
            this.rtbSend.TabIndex = 10;
            this.rtbSend.Text = "";
            // 
            // btInsertParam
            // 
            this.btInsertParam.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btInsertParam.Location = new System.Drawing.Point(191, 301);
            this.btInsertParam.Margin = new System.Windows.Forms.Padding(5, 5, 5, 10);
            this.btInsertParam.Name = "btInsertParam";
            this.btInsertParam.Size = new System.Drawing.Size(172, 21);
            this.btInsertParam.TabIndex = 9;
            this.btInsertParam.Text = "Wstaw zmienną";
            this.btInsertParam.UseVisualStyleBackColor = true;
            this.btInsertParam.Click += new System.EventHandler(this.btInsertParam_Click);
            // 
            // btInsertFunction
            // 
            this.btInsertFunction.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btInsertFunction.Location = new System.Drawing.Point(191, 270);
            this.btInsertFunction.Margin = new System.Windows.Forms.Padding(5);
            this.btInsertFunction.Name = "btInsertFunction";
            this.btInsertFunction.Size = new System.Drawing.Size(172, 21);
            this.btInsertFunction.TabIndex = 9;
            this.btInsertFunction.Text = "Wstaw funkcję";
            this.btInsertFunction.UseVisualStyleBackColor = true;
            this.btInsertFunction.Click += new System.EventHandler(this.btInsertFunction_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(10, 301);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 10);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(172, 21);
            this.comboBox1.Sorted = true;
            this.comboBox1.TabIndex = 8;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.btInsertParam_Click);
            // 
            // comboBox2
            // 
            this.comboBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBox2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(10, 270);
            this.comboBox2.Margin = new System.Windows.Forms.Padding(5);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(172, 21);
            this.comboBox2.Sorted = true;
            this.comboBox2.TabIndex = 7;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.btInsertFunction_Click);
            // 
            // butClear
            // 
            this.butClear.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.butClear.Location = new System.Drawing.Point(283, 237);
            this.butClear.Margin = new System.Windows.Forms.Padding(5, 5, 10, 5);
            this.butClear.MaximumSize = new System.Drawing.Size(80, 42);
            this.butClear.Name = "butClear";
            this.butClear.Size = new System.Drawing.Size(80, 21);
            this.butClear.TabIndex = 5;
            this.butClear.Text = "Wyczyść";
            this.butClear.UseVisualStyleBackColor = true;
            this.butClear.Click += new System.EventHandler(this.butClear_Click);
            // 
            // butSend
            // 
            this.butSend.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.butSend.Location = new System.Drawing.Point(191, 237);
            this.butSend.Margin = new System.Windows.Forms.Padding(5);
            this.butSend.MaximumSize = new System.Drawing.Size(80, 42);
            this.butSend.Name = "butSend";
            this.butSend.Size = new System.Drawing.Size(80, 21);
            this.butSend.TabIndex = 4;
            this.butSend.Text = "Wyślij";
            this.butSend.UseVisualStyleBackColor = true;
            this.butSend.Click += new System.EventHandler(this.butSend_Click);
            // 
            // rtbConsole
            // 
            this.rtbConsole.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbConsole.BackColor = System.Drawing.SystemColors.Window;
            this.rtbConsole.Location = new System.Drawing.Point(10, 43);
            this.rtbConsole.Margin = new System.Windows.Forms.Padding(10);
            this.rtbConsole.Name = "rtbConsole";
            this.rtbConsole.ReadOnly = true;
            this.rtbConsole.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.rtbConsole.Size = new System.Drawing.Size(353, 178);
            this.rtbConsole.TabIndex = 2;
            this.rtbConsole.Text = "";
            this.rtbConsole.TextChanged += new System.EventHandler(this.richTextBox_TextChanged);
            // 
            // labStatus
            // 
            this.labStatus.AutoSize = true;
            this.labStatus.Location = new System.Drawing.Point(38, 13);
            this.labStatus.Name = "labStatus";
            this.labStatus.Size = new System.Drawing.Size(85, 13);
            this.labStatus.TabIndex = 1;
            this.labStatus.Text = "Brak połączenia";
            // 
            // stateBox
            // 
            this.stateBox.BackColor = System.Drawing.Color.Red;
            this.stateBox.Location = new System.Drawing.Point(10, 13);
            this.stateBox.Margin = new System.Windows.Forms.Padding(10, 10, 10, 5);
            this.stateBox.Name = "stateBox";
            this.stateBox.Size = new System.Drawing.Size(15, 15);
            this.stateBox.TabIndex = 0;
            this.stateBox.TabStop = false;
            this.stateBox.Click += new System.EventHandler(this.stateBox_Click);
            // 
            // tabGUI
            // 
            this.tabGUI.Controls.Add(this.labelTest);
            this.tabGUI.Controls.Add(this.cbAdd);
            this.tabGUI.Controls.Add(this.bAdd);
            this.tabGUI.Controls.Add(this.bSave);
            this.tabGUI.Controls.Add(this.bLoad);
            this.tabGUI.Controls.Add(this.bRestart);
            this.tabGUI.Controls.Add(this.cbName2);
            this.tabGUI.Controls.Add(this.butRefresh2);
            this.tabGUI.Controls.Add(this.gbGraphics);
            this.tabGUI.Controls.Add(this.labStatus1);
            this.tabGUI.Controls.Add(this.bEdit);
            this.tabGUI.Controls.Add(this.stateBox1);
            this.tabGUI.Controls.Add(this.gbPanel);
            this.tabGUI.Location = new System.Drawing.Point(4, 22);
            this.tabGUI.Name = "tabGUI";
            this.tabGUI.Padding = new System.Windows.Forms.Padding(7, 5, 7, 5);
            this.tabGUI.Size = new System.Drawing.Size(376, 335);
            this.tabGUI.TabIndex = 1;
            this.tabGUI.Text = "Panel sterowania";
            this.tabGUI.UseVisualStyleBackColor = true;
            this.tabGUI.Enter += new System.EventHandler(this.FormGraph_tabGUI);
            this.tabGUI.Resize += new System.EventHandler(this.FormGraph_tabGUI);
            // 
            // labelTest
            // 
            this.labelTest.AutoSize = true;
            this.labelTest.Location = new System.Drawing.Point(127, 26);
            this.labelTest.Name = "labelTest";
            this.labelTest.Size = new System.Drawing.Size(50, 13);
            this.labelTest.TabIndex = 7;
            this.labelTest.Text = "labelTest";
            // 
            // cbAdd
            // 
            this.cbAdd.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cbAdd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAdd.FormattingEnabled = true;
            this.cbAdd.ItemHeight = 13;
            this.cbAdd.Items.AddRange(new object[] {
            "-",
            "Przycisk",
            "Suwak",
            "Wartość"});
            this.cbAdd.Location = new System.Drawing.Point(11, 279);
            this.cbAdd.Margin = new System.Windows.Forms.Padding(10, 10, 30, 10);
            this.cbAdd.Name = "cbAdd";
            this.cbAdd.Size = new System.Drawing.Size(52, 21);
            this.cbAdd.TabIndex = 16;
            this.cbAdd.SelectedIndexChanged += new System.EventHandler(this.cbAdd_SelectedIndexChanged);
            // 
            // bAdd
            // 
            this.bAdd.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.bAdd.Location = new System.Drawing.Point(10, 261);
            this.bAdd.Name = "bAdd";
            this.bAdd.Size = new System.Drawing.Size(54, 22);
            this.bAdd.TabIndex = 17;
            this.bAdd.Text = "Edytuj";
            this.bAdd.UseVisualStyleBackColor = true;
            this.bAdd.Click += new System.EventHandler(this.bAdd_Click);
            // 
            // bSave
            // 
            this.bSave.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.bSave.Location = new System.Drawing.Point(70, 261);
            this.bSave.Name = "bSave";
            this.bSave.Size = new System.Drawing.Size(54, 39);
            this.bSave.TabIndex = 18;
            this.bSave.Text = "Zapisz";
            this.bSave.UseVisualStyleBackColor = true;
            this.bSave.Click += new System.EventHandler(this.bSave_Click);
            // 
            // bLoad
            // 
            this.bLoad.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.bLoad.Location = new System.Drawing.Point(130, 261);
            this.bLoad.Name = "bLoad";
            this.bLoad.Size = new System.Drawing.Size(55, 39);
            this.bLoad.TabIndex = 19;
            this.bLoad.Text = "Wczytaj";
            this.bLoad.UseVisualStyleBackColor = true;
            this.bLoad.Click += new System.EventHandler(this.bLoad_Click);
            // 
            // bRestart
            // 
            this.bRestart.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.bRestart.Location = new System.Drawing.Point(10, 306);
            this.bRestart.Name = "bRestart";
            this.bRestart.Size = new System.Drawing.Size(83, 21);
            this.bRestart.TabIndex = 16;
            this.bRestart.Text = "Start";
            this.bRestart.UseVisualStyleBackColor = true;
            // 
            // cbName2
            // 
            this.cbName2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbName2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbName2.FormattingEnabled = true;
            this.cbName2.Location = new System.Drawing.Point(266, 10);
            this.cbName2.Margin = new System.Windows.Forms.Padding(10, 10, 30, 10);
            this.cbName2.Name = "cbName2";
            this.cbName2.Size = new System.Drawing.Size(97, 21);
            this.cbName2.TabIndex = 15;
            this.cbName2.SelectedIndexChanged += new System.EventHandler(this.cbName_SelectedIndexChanged);
            // 
            // butRefresh2
            // 
            this.butRefresh2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butRefresh2.Location = new System.Drawing.Point(188, 10);
            this.butRefresh2.Name = "butRefresh2";
            this.butRefresh2.Size = new System.Drawing.Size(65, 21);
            this.butRefresh2.TabIndex = 14;
            this.butRefresh2.Text = "Odśwież";
            this.butRefresh2.UseVisualStyleBackColor = true;
            this.butRefresh2.Click += new System.EventHandler(this.butRefresh_Click);
            // 
            // gbGraphics
            // 
            this.gbGraphics.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.gbGraphics.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.gbGraphics.Controls.Add(this.pbEchoSensor);
            this.gbGraphics.Controls.Add(this.pbBlueBoard);
            this.gbGraphics.Controls.Add(this.label9);
            this.gbGraphics.Controls.Add(this.label8);
            this.gbGraphics.Controls.Add(this.label6);
            this.gbGraphics.Location = new System.Drawing.Point(10, 42);
            this.gbGraphics.Name = "gbGraphics";
            this.gbGraphics.Size = new System.Drawing.Size(175, 213);
            this.gbGraphics.TabIndex = 5;
            this.gbGraphics.TabStop = false;
            this.gbGraphics.Text = "AlphaBot";
            // 
            // pbEchoSensor
            // 
            this.pbEchoSensor.BackColor = System.Drawing.Color.Black;
            this.pbEchoSensor.Location = new System.Drawing.Point(57, 59);
            this.pbEchoSensor.Name = "pbEchoSensor";
            this.pbEchoSensor.Size = new System.Drawing.Size(63, 58);
            this.pbEchoSensor.TabIndex = 6;
            this.pbEchoSensor.TabStop = false;
            // 
            // pbBlueBoard
            // 
            this.pbBlueBoard.Image = ((System.Drawing.Image)(resources.GetObject("pbBlueBoard.Image")));
            this.pbBlueBoard.Location = new System.Drawing.Point(23, 69);
            this.pbBlueBoard.Name = "pbBlueBoard";
            this.pbBlueBoard.Size = new System.Drawing.Size(118, 150);
            this.pbBlueBoard.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbBlueBoard.TabIndex = 5;
            this.pbBlueBoard.TabStop = false;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(147, 161);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(21, 13);
            this.label9.TabIndex = 4;
            this.label9.Text = "vR";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 161);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(19, 13);
            this.label8.TabIndex = 4;
            this.label8.Text = "vL";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(66, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 13);
            this.label6.TabIndex = 4;
            this.label6.Text = "Dystans";
            // 
            // labStatus1
            // 
            this.labStatus1.AutoSize = true;
            this.labStatus1.Location = new System.Drawing.Point(38, 13);
            this.labStatus1.Name = "labStatus1";
            this.labStatus1.Size = new System.Drawing.Size(85, 13);
            this.labStatus1.TabIndex = 3;
            this.labStatus1.Text = "Brak połączenia";
            // 
            // bEdit
            // 
            this.bEdit.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.bEdit.Location = new System.Drawing.Point(102, 306);
            this.bEdit.Name = "bEdit";
            this.bEdit.Size = new System.Drawing.Size(83, 21);
            this.bEdit.TabIndex = 0;
            this.bEdit.Text = "Edytuj";
            this.bEdit.UseVisualStyleBackColor = true;
            this.bEdit.Click += new System.EventHandler(this.bEdit_Click);
            // 
            // stateBox1
            // 
            this.stateBox1.BackColor = System.Drawing.Color.Red;
            this.stateBox1.Location = new System.Drawing.Point(10, 13);
            this.stateBox1.Margin = new System.Windows.Forms.Padding(10, 10, 10, 5);
            this.stateBox1.Name = "stateBox1";
            this.stateBox1.Size = new System.Drawing.Size(15, 15);
            this.stateBox1.TabIndex = 2;
            this.stateBox1.TabStop = false;
            this.stateBox1.Click += new System.EventHandler(this.stateBox_Click);
            // 
            // gbPanel
            // 
            this.gbPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.gbPanel.Location = new System.Drawing.Point(191, 42);
            this.gbPanel.Name = "gbPanel";
            this.gbPanel.Padding = new System.Windows.Forms.Padding(0);
            this.gbPanel.Size = new System.Drawing.Size(175, 285);
            this.gbPanel.TabIndex = 1;
            this.gbPanel.TabStop = false;
            this.gbPanel.Text = "Klawiatura";
            this.gbPanel.Click += new System.EventHandler(this.gbPanel_Click);
            // 
            // tabOptions
            // 
            this.tabOptions.Controls.Add(this.cbHex);
            this.tabOptions.Controls.Add(this.butRefresh);
            this.tabOptions.Controls.Add(this.butCancel);
            this.tabOptions.Controls.Add(this.butDefault);
            this.tabOptions.Controls.Add(this.cbStop);
            this.tabOptions.Controls.Add(this.cbParity);
            this.tabOptions.Controls.Add(this.label7);
            this.tabOptions.Controls.Add(this.cbData);
            this.tabOptions.Controls.Add(this.label5);
            this.tabOptions.Controls.Add(this.cbBaud);
            this.tabOptions.Controls.Add(this.label4);
            this.tabOptions.Controls.Add(this.cbName);
            this.tabOptions.Controls.Add(this.label3);
            this.tabOptions.Controls.Add(this.label2);
            this.tabOptions.Controls.Add(this.label1);
            this.tabOptions.Location = new System.Drawing.Point(4, 22);
            this.tabOptions.Name = "tabOptions";
            this.tabOptions.Size = new System.Drawing.Size(376, 335);
            this.tabOptions.TabIndex = 2;
            this.tabOptions.Text = "Opcje";
            this.tabOptions.UseVisualStyleBackColor = true;
            // 
            // cbHex
            // 
            this.cbHex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbHex.AutoSize = true;
            this.cbHex.BackColor = System.Drawing.Color.Transparent;
            this.cbHex.Checked = true;
            this.cbHex.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbHex.Location = new System.Drawing.Point(282, 229);
            this.cbHex.Margin = new System.Windows.Forms.Padding(30);
            this.cbHex.Name = "cbHex";
            this.cbHex.Size = new System.Drawing.Size(15, 14);
            this.cbHex.TabIndex = 3;
            this.cbHex.UseVisualStyleBackColor = false;
            // 
            // butRefresh
            // 
            this.butRefresh.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.butRefresh.Location = new System.Drawing.Point(135, 275);
            this.butRefresh.Margin = new System.Windows.Forms.Padding(10, 10, 10, 30);
            this.butRefresh.Name = "butRefresh";
            this.butRefresh.Size = new System.Drawing.Size(111, 30);
            this.butRefresh.TabIndex = 2;
            this.butRefresh.Text = "Odśwież";
            this.butRefresh.UseVisualStyleBackColor = true;
            this.butRefresh.Click += new System.EventHandler(this.butRefresh_Click);
            // 
            // butCancel
            // 
            this.butCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.butCancel.Location = new System.Drawing.Point(266, 282);
            this.butCancel.Margin = new System.Windows.Forms.Padding(10, 10, 30, 30);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(80, 23);
            this.butCancel.TabIndex = 2;
            this.butCancel.Text = "Anuluj";
            this.butCancel.UseVisualStyleBackColor = true;
            this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
            // 
            // butDefault
            // 
            this.butDefault.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.butDefault.Location = new System.Drawing.Point(35, 282);
            this.butDefault.Margin = new System.Windows.Forms.Padding(30, 10, 10, 30);
            this.butDefault.Name = "butDefault";
            this.butDefault.Size = new System.Drawing.Size(80, 23);
            this.butDefault.TabIndex = 2;
            this.butDefault.Text = "Domyślne";
            this.butDefault.UseVisualStyleBackColor = true;
            this.butDefault.Click += new System.EventHandler(this.butDefault_Click);
            // 
            // cbStop
            // 
            this.cbStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbStop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStop.FormattingEnabled = true;
            this.cbStop.Location = new System.Drawing.Point(225, 185);
            this.cbStop.Margin = new System.Windows.Forms.Padding(10, 10, 30, 10);
            this.cbStop.Name = "cbStop";
            this.cbStop.Size = new System.Drawing.Size(121, 21);
            this.cbStop.TabIndex = 1;
            // 
            // cbParity
            // 
            this.cbParity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbParity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbParity.FormattingEnabled = true;
            this.cbParity.Location = new System.Drawing.Point(225, 144);
            this.cbParity.Margin = new System.Windows.Forms.Padding(10, 10, 30, 10);
            this.cbParity.Name = "cbParity";
            this.cbParity.Size = new System.Drawing.Size(121, 21);
            this.cbParity.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(30, 229);
            this.label7.Margin = new System.Windows.Forms.Padding(30, 10, 30, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(83, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Kod maszynowy";
            // 
            // cbData
            // 
            this.cbData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbData.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbData.FormattingEnabled = true;
            this.cbData.Items.AddRange(new object[] {
            "5",
            "6",
            "7",
            "8",
            "9"});
            this.cbData.Location = new System.Drawing.Point(225, 103);
            this.cbData.Margin = new System.Windows.Forms.Padding(10, 10, 30, 10);
            this.cbData.Name = "cbData";
            this.cbData.Size = new System.Drawing.Size(121, 21);
            this.cbData.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(30, 188);
            this.label5.Margin = new System.Windows.Forms.Padding(30, 10, 30, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Bity stopu";
            // 
            // cbBaud
            // 
            this.cbBaud.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbBaud.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBaud.FormattingEnabled = true;
            this.cbBaud.Items.AddRange(new object[] {
            "2400",
            "4800",
            "9600",
            "14400",
            "19200",
            "28800",
            "38400",
            "57600",
            "76800",
            "115200"});
            this.cbBaud.Location = new System.Drawing.Point(225, 62);
            this.cbBaud.Margin = new System.Windows.Forms.Padding(10, 10, 30, 10);
            this.cbBaud.Name = "cbBaud";
            this.cbBaud.Size = new System.Drawing.Size(121, 21);
            this.cbBaud.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 147);
            this.label4.Margin = new System.Windows.Forms.Padding(30, 10, 30, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Bity parzystości";
            // 
            // cbName
            // 
            this.cbName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbName.FormattingEnabled = true;
            this.cbName.Location = new System.Drawing.Point(225, 21);
            this.cbName.Margin = new System.Windows.Forms.Padding(10, 10, 30, 10);
            this.cbName.Name = "cbName";
            this.cbName.Size = new System.Drawing.Size(121, 21);
            this.cbName.TabIndex = 1;
            this.cbName.SelectedIndexChanged += new System.EventHandler(this.cbName_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 106);
            this.label3.Margin = new System.Windows.Forms.Padding(30, 10, 30, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Bity danych";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 65);
            this.label2.Margin = new System.Windows.Forms.Padding(30, 10, 30, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Prędkość";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 24);
            this.label1.Margin = new System.Windows.Forms.Padding(30, 10, 30, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nazwa portu";
            // 
            // backgroundSender
            // 
            this.backgroundSender.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundSender_DoWork);
            this.backgroundSender.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundSender_RunWorkerCompleted);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 361);
            this.Controls.Add(this.tabMenu);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabMenu.ResumeLayout(false);
            this.tabConsole.ResumeLayout(false);
            this.tabConsole.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.stateBox)).EndInit();
            this.tabGUI.ResumeLayout(false);
            this.tabGUI.PerformLayout();
            this.gbGraphics.ResumeLayout(false);
            this.gbGraphics.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbEchoSensor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbBlueBoard)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stateBox1)).EndInit();
            this.tabOptions.ResumeLayout(false);
            this.tabOptions.PerformLayout();
            this.ResumeLayout(false);

        }


        #endregion

        private System.Windows.Forms.TabControl tabMenu;
        private System.Windows.Forms.TabPage tabConsole;
        private System.Windows.Forms.TabPage tabGUI;
        private System.Windows.Forms.TabPage tabOptions;
        private System.Windows.Forms.Button butDefault;
        private System.Windows.Forms.ComboBox cbName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbStop;
        private System.Windows.Forms.ComboBox cbParity;
        private System.Windows.Forms.ComboBox cbData;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbBaud;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button butRefresh;
        private System.Windows.Forms.Button butCancel;
        private System.Windows.Forms.Button butClear;
        private System.Windows.Forms.Button butSend;
        private System.Windows.Forms.RichTextBox rtbConsole;
        private System.Windows.Forms.Label labStatus;
        private System.Windows.Forms.PictureBox stateBox;
        private System.Windows.Forms.CheckBox cbHex;
        private System.Windows.Forms.Label label7;
        private System.ComponentModel.BackgroundWorker backgroundSender;
        private System.Windows.Forms.GroupBox gbPanel;
        private System.Windows.Forms.Button bEdit;
        private System.Windows.Forms.Label labStatus1;
        private System.Windows.Forms.PictureBox stateBox1;
        private GroupBox gbGraphics;
        private Label label6;
        private Label label9;
        private Label label8;
        private ComboBox comboBox2;
        private ComboBox comboBox1;
        private Button btInsertParam;
        private Button btInsertFunction;
        private RichTextBox rtbSend;
        private ComboBox cbName1;
        private Button butRefresh1;
        private ComboBox cbName2;
        private Button butRefresh2;
        private PictureBox pbBlueBoard;
        private PictureBox pbEchoSensor;
        private Button bRestart;
        private Button bSave;
        private Button bAdd;
        private Button bLoad;
        private ComboBox cbAdd;
        private Label labelTest;
    }
}

