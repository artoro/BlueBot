namespace Serial_Port
{
    partial class Form2
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
            this.kbEdited = new System.Windows.Forms.Button();
            this.rtbCommandDown = new System.Windows.Forms.RichTextBox();
            this.btChangeKey = new System.Windows.Forms.Button();
            this.btChangeSign = new System.Windows.Forms.Button();
            this.setButton = new System.Windows.Forms.Button();
            this.rtbCommandUp = new System.Windows.Forms.RichTextBox();
            this.labON = new System.Windows.Forms.Label();
            this.labOFF = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btInsertFunction = new System.Windows.Forms.Button();
            this.btInsertParam = new System.Windows.Forms.Button();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // kbEdited
            // 
            this.kbEdited.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.kbEdited.Location = new System.Drawing.Point(12, 40);
            this.kbEdited.Name = "kbEdited";
            this.kbEdited.Size = new System.Drawing.Size(50, 50);
            this.kbEdited.TabIndex = 0;
            this.kbEdited.Text = "B";
            this.kbEdited.UseVisualStyleBackColor = true;
            // 
            // rtbCommandDown
            // 
            this.rtbCommandDown.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbCommandDown.Location = new System.Drawing.Point(68, 12);
            this.rtbCommandDown.Name = "rtbCommandDown";
            this.rtbCommandDown.Size = new System.Drawing.Size(204, 50);
            this.rtbCommandDown.TabIndex = 1;
            this.rtbCommandDown.Text = "";
            this.rtbCommandDown.Click += new System.EventHandler(this.rtbCommandDown_Click);
            // 
            // btChangeKey
            // 
            this.btChangeKey.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btChangeKey.Location = new System.Drawing.Point(278, 12);
            this.btChangeKey.Name = "btChangeKey";
            this.btChangeKey.Size = new System.Drawing.Size(94, 22);
            this.btChangeKey.TabIndex = 2;
            this.btChangeKey.Text = "Zmień klawisz";
            this.btChangeKey.UseVisualStyleBackColor = true;
            this.btChangeKey.Click += new System.EventHandler(this.btChangeKey_Click);
            this.btChangeKey.KeyDown += new System.Windows.Forms.KeyEventHandler(this.kb_KeyDown);
            this.btChangeKey.KeyUp += new System.Windows.Forms.KeyEventHandler(this.kb_KeyUp);
            // 
            // btChangeSign
            // 
            this.btChangeSign.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btChangeSign.Location = new System.Drawing.Point(278, 40);
            this.btChangeSign.Name = "btChangeSign";
            this.btChangeSign.Size = new System.Drawing.Size(94, 22);
            this.btChangeSign.TabIndex = 2;
            this.btChangeSign.Text = "Symbol";
            this.btChangeSign.UseVisualStyleBackColor = true;
            this.btChangeSign.Click += new System.EventHandler(this.btChangeSign_Click);
            this.btChangeSign.KeyDown += new System.Windows.Forms.KeyEventHandler(this.kb_KeyDown);
            this.btChangeSign.KeyUp += new System.Windows.Forms.KeyEventHandler(this.kb_KeyUp);
            // 
            // setButton
            // 
            this.setButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.setButton.Location = new System.Drawing.Point(278, 68);
            this.setButton.Name = "setButton";
            this.setButton.Size = new System.Drawing.Size(94, 50);
            this.setButton.TabIndex = 3;
            this.setButton.Text = "Ustaw";
            this.setButton.UseVisualStyleBackColor = true;
            this.setButton.Click += new System.EventHandler(this.setButton_Click);
            // 
            // rtbCommandUp
            // 
            this.rtbCommandUp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbCommandUp.Location = new System.Drawing.Point(68, 68);
            this.rtbCommandUp.Name = "rtbCommandUp";
            this.rtbCommandUp.Size = new System.Drawing.Size(204, 50);
            this.rtbCommandUp.TabIndex = 1;
            this.rtbCommandUp.Text = "";
            this.rtbCommandUp.Click += new System.EventHandler(this.rtbCommandUp_Click);
            // 
            // labON
            // 
            this.labON.AutoSize = true;
            this.labON.Location = new System.Drawing.Point(13, 14);
            this.labON.Name = "labON";
            this.labON.Padding = new System.Windows.Forms.Padding(5);
            this.labON.Size = new System.Drawing.Size(49, 23);
            this.labON.TabIndex = 4;
            this.labON.Text = "Włącz";
            // 
            // labOFF
            // 
            this.labOFF.AutoSize = true;
            this.labOFF.Location = new System.Drawing.Point(9, 95);
            this.labOFF.Name = "labOFF";
            this.labOFF.Padding = new System.Windows.Forms.Padding(5);
            this.labOFF.Size = new System.Drawing.Size(54, 23);
            this.labOFF.TabIndex = 4;
            this.labOFF.Text = "Wyłącz";
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(68, 124);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(204, 21);
            this.comboBox1.Sorted = true;
            this.comboBox1.TabIndex = 5;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.btInsertFunction_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 128);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Funkcje";
            // 
            // btInsertFunction
            // 
            this.btInsertFunction.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btInsertFunction.Location = new System.Drawing.Point(278, 124);
            this.btInsertFunction.Name = "btInsertFunction";
            this.btInsertFunction.Size = new System.Drawing.Size(94, 21);
            this.btInsertFunction.TabIndex = 2;
            this.btInsertFunction.Text = "Wstaw";
            this.btInsertFunction.UseVisualStyleBackColor = true;
            this.btInsertFunction.Click += new System.EventHandler(this.btInsertFunction_Click);
            // 
            // btInsertParam
            // 
            this.btInsertParam.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btInsertParam.Location = new System.Drawing.Point(278, 151);
            this.btInsertParam.Name = "btInsertParam";
            this.btInsertParam.Size = new System.Drawing.Size(94, 21);
            this.btInsertParam.TabIndex = 2;
            this.btInsertParam.Text = "Wstaw";
            this.btInsertParam.UseVisualStyleBackColor = true;
            this.btInsertParam.Click += new System.EventHandler(this.btInsertParam_Click);
            // 
            // comboBox2
            // 
            this.comboBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBox2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(68, 151);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(204, 21);
            this.comboBox2.Sorted = true;
            this.comboBox2.TabIndex = 5;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.btInsertParam_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 154);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Zmienne";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 184);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.labOFF);
            this.Controls.Add(this.labON);
            this.Controls.Add(this.btInsertParam);
            this.Controls.Add(this.setButton);
            this.Controls.Add(this.btInsertFunction);
            this.Controls.Add(this.btChangeSign);
            this.Controls.Add(this.btChangeKey);
            this.Controls.Add(this.rtbCommandUp);
            this.Controls.Add(this.rtbCommandDown);
            this.Controls.Add(this.kbEdited);
            this.Name = "Form2";
            this.Text = "Przycisk";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button kbEdited;
        private System.Windows.Forms.RichTextBox rtbCommandDown;
        private System.Windows.Forms.Button btChangeKey;
        private System.Windows.Forms.Button btChangeSign;
        private System.Windows.Forms.Button setButton;
        private System.Windows.Forms.RichTextBox rtbCommandUp;
        private System.Windows.Forms.Label labON;
        private System.Windows.Forms.Label labOFF;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btInsertFunction;
        private System.Windows.Forms.Button btInsertParam;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label2;
    }
}