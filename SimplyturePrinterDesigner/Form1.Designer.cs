namespace SimplyturePrinterDesigner
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
            this.tbStatus = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.tb_log = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.testprint2 = new System.Windows.Forms.Button();
            this.AddLogo1 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.SetCenterAlignment = new System.Windows.Forms.Button();
            this.SetLeftAlignment = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.StartBWInversion = new System.Windows.Forms.Button();
            this.CancelBWInversion = new System.Windows.Forms.Button();
            this.LoadLogo2 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.BoldOff = new System.Windows.Forms.Button();
            this.BoldON = new System.Windows.Forms.Button();
            this.AddTab = new System.Windows.Forms.Button();
            this.Linesplitter = new System.Windows.Forms.Button();
            this.AddLinefeed = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.AddStringtoReceipt = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.TB_addstring = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbStatus
            // 
            this.tbStatus.Location = new System.Drawing.Point(457, 20);
            this.tbStatus.Name = "tbStatus";
            this.tbStatus.Size = new System.Drawing.Size(51, 20);
            this.tbStatus.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Black;
            this.button1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.button1.Location = new System.Drawing.Point(354, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(97, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "Get printer status";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 484);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(133, 29);
            this.button2.TabIndex = 4;
            this.button2.Text = "Print test receipt";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // tb_log
            // 
            this.tb_log.Location = new System.Drawing.Point(0, 519);
            this.tb_log.Multiline = true;
            this.tb_log.Name = "tb_log";
            this.tb_log.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tb_log.Size = new System.Drawing.Size(538, 158);
            this.tb_log.TabIndex = 5;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(408, 484);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(118, 29);
            this.button3.TabIndex = 6;
            this.button3.Text = "Clear log";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // testprint2
            // 
            this.testprint2.Enabled = false;
            this.testprint2.Location = new System.Drawing.Point(151, 484);
            this.testprint2.Name = "testprint2";
            this.testprint2.Size = new System.Drawing.Size(251, 29);
            this.testprint2.TabIndex = 7;
            this.testprint2.Text = "Print receipt from builder";
            this.testprint2.UseVisualStyleBackColor = true;
            this.testprint2.Click += new System.EventHandler(this.testprint2_Click);
            // 
            // AddLogo1
            // 
            this.AddLogo1.Location = new System.Drawing.Point(6, 19);
            this.AddLogo1.Name = "AddLogo1";
            this.AddLogo1.Size = new System.Drawing.Size(75, 23);
            this.AddLogo1.TabIndex = 8;
            this.AddLogo1.Text = "Add logo 1";
            this.AddLogo1.UseVisualStyleBackColor = true;
            this.AddLogo1.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(377, 224);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(131, 23);
            this.button5.TabIndex = 9;
            this.button5.Text = "See current receipt data";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(354, 48);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 10;
            this.button6.Text = "Add full cut";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.SetCenterAlignment);
            this.groupBox1.Controls.Add(this.SetLeftAlignment);
            this.groupBox1.Controls.Add(this.button9);
            this.groupBox1.Controls.Add(this.StartBWInversion);
            this.groupBox1.Controls.Add(this.CancelBWInversion);
            this.groupBox1.Controls.Add(this.LoadLogo2);
            this.groupBox1.Controls.Add(this.button8);
            this.groupBox1.Controls.Add(this.BoldOff);
            this.groupBox1.Controls.Add(this.BoldON);
            this.groupBox1.Controls.Add(this.AddTab);
            this.groupBox1.Controls.Add(this.Linesplitter);
            this.groupBox1.Controls.Add(this.AddLinefeed);
            this.groupBox1.Controls.Add(this.button7);
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.AddStringtoReceipt);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.TB_addstring);
            this.groupBox1.Controls.Add(this.AddLogo1);
            this.groupBox1.Controls.Add(this.button5);
            this.groupBox1.Controls.Add(this.button6);
            this.groupBox1.Controls.Add(this.tbStatus);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(514, 253);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Add Printer Commands";
            // 
            // SetCenterAlignment
            // 
            this.SetCenterAlignment.Location = new System.Drawing.Point(6, 107);
            this.SetCenterAlignment.Name = "SetCenterAlignment";
            this.SetCenterAlignment.Size = new System.Drawing.Size(106, 23);
            this.SetCenterAlignment.TabIndex = 29;
            this.SetCenterAlignment.Text = "SetCenterAlignment";
            this.SetCenterAlignment.UseVisualStyleBackColor = true;
            this.SetCenterAlignment.Click += new System.EventHandler(this.SetCenterAlignment_Click);
            // 
            // SetLeftAlignment
            // 
            this.SetLeftAlignment.Location = new System.Drawing.Point(362, 77);
            this.SetLeftAlignment.Name = "SetLeftAlignment";
            this.SetLeftAlignment.Size = new System.Drawing.Size(106, 23);
            this.SetLeftAlignment.TabIndex = 28;
            this.SetLeftAlignment.Text = "SetLeftAlignment";
            this.SetLeftAlignment.UseVisualStyleBackColor = true;
            this.SetLeftAlignment.Click += new System.EventHandler(this.SetLeftAlignment_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(250, 78);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(106, 23);
            this.button9.TabIndex = 27;
            this.button9.Text = "SetRightAlignment";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // StartBWInversion
            // 
            this.StartBWInversion.Location = new System.Drawing.Point(6, 78);
            this.StartBWInversion.Name = "StartBWInversion";
            this.StartBWInversion.Size = new System.Drawing.Size(115, 23);
            this.StartBWInversion.TabIndex = 26;
            this.StartBWInversion.Text = "StartBWInversion";
            this.StartBWInversion.UseVisualStyleBackColor = true;
            this.StartBWInversion.Click += new System.EventHandler(this.StartBWInversion_Click);
            // 
            // CancelBWInversion
            // 
            this.CancelBWInversion.Location = new System.Drawing.Point(127, 78);
            this.CancelBWInversion.Name = "CancelBWInversion";
            this.CancelBWInversion.Size = new System.Drawing.Size(115, 23);
            this.CancelBWInversion.TabIndex = 25;
            this.CancelBWInversion.Text = "CancelBWInversion";
            this.CancelBWInversion.UseVisualStyleBackColor = true;
            this.CancelBWInversion.Click += new System.EventHandler(this.CancelBWInversion_Click);
            // 
            // LoadLogo2
            // 
            this.LoadLogo2.Location = new System.Drawing.Point(87, 20);
            this.LoadLogo2.Name = "LoadLogo2";
            this.LoadLogo2.Size = new System.Drawing.Size(76, 23);
            this.LoadLogo2.TabIndex = 24;
            this.LoadLogo2.Text = "Load logo 2";
            this.LoadLogo2.UseVisualStyleBackColor = true;
            this.LoadLogo2.Click += new System.EventHandler(this.LoadLogo2_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(250, 49);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(98, 23);
            this.button8.TabIndex = 23;
            this.button8.Text = "Set horizontal tab";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // BoldOff
            // 
            this.BoldOff.Location = new System.Drawing.Point(169, 49);
            this.BoldOff.Name = "BoldOff";
            this.BoldOff.Size = new System.Drawing.Size(75, 23);
            this.BoldOff.TabIndex = 22;
            this.BoldOff.Text = "Bold Off";
            this.BoldOff.UseVisualStyleBackColor = true;
            this.BoldOff.Click += new System.EventHandler(this.BoldOff_Click);
            // 
            // BoldON
            // 
            this.BoldON.Location = new System.Drawing.Point(87, 49);
            this.BoldON.Name = "BoldON";
            this.BoldON.Size = new System.Drawing.Size(75, 23);
            this.BoldON.TabIndex = 21;
            this.BoldON.Text = "Bold On";
            this.BoldON.UseVisualStyleBackColor = true;
            this.BoldON.Click += new System.EventHandler(this.BoldON_Click);
            // 
            // AddTab
            // 
            this.AddTab.Location = new System.Drawing.Point(6, 49);
            this.AddTab.Name = "AddTab";
            this.AddTab.Size = new System.Drawing.Size(75, 23);
            this.AddTab.TabIndex = 20;
            this.AddTab.Text = "AddTab";
            this.AddTab.UseVisualStyleBackColor = true;
            this.AddTab.Click += new System.EventHandler(this.AddTab_Click);
            // 
            // Linesplitter
            // 
            this.Linesplitter.Location = new System.Drawing.Point(259, 19);
            this.Linesplitter.Name = "Linesplitter";
            this.Linesplitter.Size = new System.Drawing.Size(89, 23);
            this.Linesplitter.TabIndex = 19;
            this.Linesplitter.Text = "Add line splitter";
            this.Linesplitter.UseVisualStyleBackColor = true;
            this.Linesplitter.Click += new System.EventHandler(this.Linesplitter_Click);
            // 
            // AddLinefeed
            // 
            this.AddLinefeed.Location = new System.Drawing.Point(435, 48);
            this.AddLinefeed.Name = "AddLinefeed";
            this.AddLinefeed.Size = new System.Drawing.Size(79, 23);
            this.AddLinefeed.TabIndex = 18;
            this.AddLinefeed.Text = "Add linefeed";
            this.AddLinefeed.UseVisualStyleBackColor = true;
            this.AddLinefeed.Click += new System.EventHandler(this.AddLinefeed_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(377, 195);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(131, 23);
            this.button7.TabIndex = 15;
            this.button7.Text = "Clear receipt builder";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(169, 19);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(83, 23);
            this.button4.TabIndex = 14;
            this.button4.Text = "Add new Line";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click_1);
            // 
            // AddStringtoReceipt
            // 
            this.AddStringtoReceipt.Location = new System.Drawing.Point(318, 224);
            this.AddStringtoReceipt.Name = "AddStringtoReceipt";
            this.AddStringtoReceipt.Size = new System.Drawing.Size(53, 23);
            this.AddStringtoReceipt.TabIndex = 13;
            this.AddStringtoReceipt.Text = "Add";
            this.AddStringtoReceipt.UseVisualStyleBackColor = true;
            this.AddStringtoReceipt.Click += new System.EventHandler(this.AddStringtoReceipt_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 227);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 16);
            this.label1.TabIndex = 12;
            this.label1.Text = "Add string";
            // 
            // TB_addstring
            // 
            this.TB_addstring.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TB_addstring.Location = new System.Drawing.Point(80, 225);
            this.TB_addstring.Name = "TB_addstring";
            this.TB_addstring.Size = new System.Drawing.Size(231, 21);
            this.TB_addstring.TabIndex = 11;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(538, 677);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.testprint2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.tb_log);
            this.Controls.Add(this.button2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbStatus;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox tb_log;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button testprint2;
        private System.Windows.Forms.Button AddLogo1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button AddStringtoReceipt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TB_addstring;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button AddLinefeed;
        private System.Windows.Forms.Button Linesplitter;
        private System.Windows.Forms.Button AddTab;
        private System.Windows.Forms.Button BoldOff;
        private System.Windows.Forms.Button BoldON;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button LoadLogo2;
        private System.Windows.Forms.Button CancelBWInversion;
        private System.Windows.Forms.Button StartBWInversion;
        private System.Windows.Forms.Button SetLeftAlignment;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button SetCenterAlignment;
    }
}

