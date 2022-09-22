namespace LawtechPTSystemByFirm.US
{
    partial class EmailSet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmailSet));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.numericUpDown_EmailTimeOut = new System.Windows.Forms.NumericUpDown();
            this.label14 = new System.Windows.Forms.Label();
            this.txt_Name = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txt_EmailAddress = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txt_STMPserver = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.but_SetMail = new System.Windows.Forms.Button();
            this.chb_SSL = new System.Windows.Forms.CheckBox();
            this.txt_SmtpPort = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox_SelectSMTP = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_Password = new System.Windows.Forms.TextBox();
            this.txt_EmailAccount = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txt_AttachFile = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.but_SendMail = new System.Windows.Forms.Button();
            this.txt_Body = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_Subject = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_Reciver = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.But_Close = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label17 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_EmailTimeOut)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.numericUpDown_EmailTimeOut);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.txt_Name);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.txt_EmailAddress);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.txt_STMPserver);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.but_SetMail);
            this.groupBox1.Controls.Add(this.chb_SSL);
            this.groupBox1.Controls.Add(this.txt_SmtpPort);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.comboBox_SelectSMTP);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txt_Password);
            this.groupBox1.Controls.Add(this.txt_EmailAccount);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("微軟正黑體", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(419, 342);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "寄 件 者 資 訊";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("微軟正黑體", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label16.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label16.Location = new System.Drawing.Point(120, 290);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(213, 15);
            this.label16.TabIndex = 20;
            this.label16.Text = "* 若是需傳送大檔案郵件，建議將時間延長";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label15.Location = new System.Drawing.Point(207, 262);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(25, 20);
            this.label15.TabIndex = 19;
            this.label15.Text = "秒";
            // 
            // numericUpDown_EmailTimeOut
            // 
            this.numericUpDown_EmailTimeOut.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.numericUpDown_EmailTimeOut.Location = new System.Drawing.Point(123, 258);
            this.numericUpDown_EmailTimeOut.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericUpDown_EmailTimeOut.Name = "numericUpDown_EmailTimeOut";
            this.numericUpDown_EmailTimeOut.Size = new System.Drawing.Size(81, 29);
            this.numericUpDown_EmailTimeOut.TabIndex = 8;
            this.numericUpDown_EmailTimeOut.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(25, 266);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(92, 18);
            this.label14.TabIndex = 17;
            this.label14.Text = "等候回應時間";
            // 
            // txt_Name
            // 
            this.txt_Name.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.txt_Name.Location = new System.Drawing.Point(123, 60);
            this.txt_Name.Name = "txt_Name";
            this.txt_Name.Size = new System.Drawing.Size(272, 29);
            this.txt_Name.TabIndex = 1;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(53, 66);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(64, 18);
            this.label13.TabIndex = 15;
            this.label13.Text = "您的名稱";
            // 
            // txt_EmailAddress
            // 
            this.txt_EmailAddress.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.txt_EmailAddress.Location = new System.Drawing.Point(123, 93);
            this.txt_EmailAddress.Name = "txt_EmailAddress";
            this.txt_EmailAddress.Size = new System.Drawing.Size(272, 29);
            this.txt_EmailAddress.TabIndex = 2;
            this.txt_EmailAddress.Leave += new System.EventHandler(this.txt_EmailAddress_Leave);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(53, 98);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(64, 18);
            this.label11.TabIndex = 13;
            this.label11.Text = "電子郵件";
            // 
            // txt_STMPserver
            // 
            this.txt_STMPserver.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.txt_STMPserver.Location = new System.Drawing.Point(123, 191);
            this.txt_STMPserver.Name = "txt_STMPserver";
            this.txt_STMPserver.Size = new System.Drawing.Size(272, 29);
            this.txt_STMPserver.TabIndex = 5;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(29, 198);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(88, 18);
            this.label10.TabIndex = 11;
            this.label10.Text = "SMTP伺服器";
            // 
            // but_SetMail
            // 
            this.but_SetMail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.but_SetMail.BackgroundImage = global::LawtechPTSystemByFirm.Properties.Resources.btnT1;
            this.but_SetMail.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.but_SetMail.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.but_SetMail.ForeColor = System.Drawing.Color.Blue;
            this.but_SetMail.Location = new System.Drawing.Point(275, 304);
            this.but_SetMail.Name = "but_SetMail";
            this.but_SetMail.Size = new System.Drawing.Size(120, 30);
            this.but_SetMail.TabIndex = 9;
            this.but_SetMail.Text = "儲存設定";
            this.but_SetMail.UseVisualStyleBackColor = true;
            this.but_SetMail.Click += new System.EventHandler(this.but_SetMail_Click);
            // 
            // chb_SSL
            // 
            this.chb_SSL.AutoSize = true;
            this.chb_SSL.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.chb_SSL.Location = new System.Drawing.Point(308, 228);
            this.chb_SSL.Name = "chb_SSL";
            this.chb_SSL.Size = new System.Drawing.Size(86, 24);
            this.chb_SSL.TabIndex = 9;
            this.chb_SSL.Text = "SSL加密";
            this.chb_SSL.UseVisualStyleBackColor = true;
            // 
            // txt_SmtpPort
            // 
            this.txt_SmtpPort.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.txt_SmtpPort.Location = new System.Drawing.Point(123, 225);
            this.txt_SmtpPort.Name = "txt_SmtpPort";
            this.txt_SmtpPort.Size = new System.Drawing.Size(81, 29);
            this.txt_SmtpPort.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(40, 232);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 18);
            this.label4.TabIndex = 6;
            this.label4.Text = "SMTP Port";
            // 
            // comboBox_SelectSMTP
            // 
            this.comboBox_SelectSMTP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_SelectSMTP.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.comboBox_SelectSMTP.FormattingEnabled = true;
            this.comboBox_SelectSMTP.Items.AddRange(new object[] {
            "",
            "Gmail(smtp.gmail.com)",
            "GSuite(smtp.gmail.com)",
            "自訂...."});
            this.comboBox_SelectSMTP.Location = new System.Drawing.Point(123, 27);
            this.comboBox_SelectSMTP.Name = "comboBox_SelectSMTP";
            this.comboBox_SelectSMTP.Size = new System.Drawing.Size(272, 28);
            this.comboBox_SelectSMTP.TabIndex = 0;
            this.comboBox_SelectSMTP.SelectedIndexChanged += new System.EventHandler(this.comboBox_SelectSMTP_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(25, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 18);
            this.label3.TabIndex = 4;
            this.label3.Text = "寄信服務單位";
            // 
            // txt_Password
            // 
            this.txt_Password.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.txt_Password.Location = new System.Drawing.Point(123, 158);
            this.txt_Password.Name = "txt_Password";
            this.txt_Password.PasswordChar = '*';
            this.txt_Password.Size = new System.Drawing.Size(272, 29);
            this.txt_Password.TabIndex = 4;
            // 
            // txt_EmailAccount
            // 
            this.txt_EmailAccount.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.txt_EmailAccount.Location = new System.Drawing.Point(123, 125);
            this.txt_EmailAccount.Name = "txt_EmailAccount";
            this.txt_EmailAccount.Size = new System.Drawing.Size(272, 29);
            this.txt_EmailAccount.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(53, 165);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "登入密碼";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(53, 131);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "登入帳號";
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.txt_AttachFile);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.but_SendMail);
            this.groupBox2.Controls.Add(this.txt_Body);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.txt_Subject);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.txt_Reciver);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Font = new System.Drawing.Font("微軟正黑體", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox2.Location = new System.Drawing.Point(446, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(488, 342);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "電子郵件 測 試";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微軟正黑體", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label5.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label5.Location = new System.Drawing.Point(76, 299);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 15);
            this.label5.TabIndex = 21;
            this.label5.Text = "快速點兩下選擇檔案";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("微軟正黑體", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.DarkGreen;
            this.label12.Location = new System.Drawing.Point(76, 52);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(252, 15);
            this.label12.TabIndex = 14;
            this.label12.Text = "範例： a1234@gmail.com ; b6789@gmail.com...";
            // 
            // txt_AttachFile
            // 
            this.txt_AttachFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_AttachFile.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.txt_AttachFile.Location = new System.Drawing.Point(75, 267);
            this.txt_AttachFile.Name = "txt_AttachFile";
            this.txt_AttachFile.Size = new System.Drawing.Size(398, 29);
            this.txt_AttachFile.TabIndex = 3;
            this.txt_AttachFile.DoubleClick += new System.EventHandler(this.txt_AttachFile_DoubleClick);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.label9.Location = new System.Drawing.Point(28, 272);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(44, 18);
            this.label9.TabIndex = 12;
            this.label9.Text = "附  件";
            // 
            // but_SendMail
            // 
            this.but_SendMail.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.but_SendMail.BackgroundImage = global::LawtechPTSystemByFirm.Properties.Resources.btnT1;
            this.but_SendMail.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.but_SendMail.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.but_SendMail.ForeColor = System.Drawing.Color.Blue;
            this.but_SendMail.Location = new System.Drawing.Point(331, 302);
            this.but_SendMail.Name = "but_SendMail";
            this.but_SendMail.Size = new System.Drawing.Size(142, 30);
            this.but_SendMail.TabIndex = 4;
            this.but_SendMail.Text = "寄送測試信";
            this.but_SendMail.UseVisualStyleBackColor = true;
            this.but_SendMail.Click += new System.EventHandler(this.but_SendMail_Click);
            // 
            // txt_Body
            // 
            this.txt_Body.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_Body.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.txt_Body.Location = new System.Drawing.Point(75, 105);
            this.txt_Body.Multiline = true;
            this.txt_Body.Name = "txt_Body";
            this.txt_Body.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_Body.Size = new System.Drawing.Size(398, 156);
            this.txt_Body.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.label8.Location = new System.Drawing.Point(28, 160);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 18);
            this.label8.TabIndex = 4;
            this.label8.Text = "內  文";
            // 
            // txt_Subject
            // 
            this.txt_Subject.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_Subject.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.txt_Subject.Location = new System.Drawing.Point(75, 70);
            this.txt_Subject.Name = "txt_Subject";
            this.txt_Subject.Size = new System.Drawing.Size(398, 29);
            this.txt_Subject.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.label7.Location = new System.Drawing.Point(28, 76);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 18);
            this.label7.TabIndex = 2;
            this.label7.Text = "主  旨";
            // 
            // txt_Reciver
            // 
            this.txt_Reciver.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_Reciver.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.txt_Reciver.Location = new System.Drawing.Point(75, 22);
            this.txt_Reciver.Multiline = true;
            this.txt_Reciver.Name = "txt_Reciver";
            this.txt_Reciver.Size = new System.Drawing.Size(398, 27);
            this.txt_Reciver.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.label6.Location = new System.Drawing.Point(22, 26);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 18);
            this.label6.TabIndex = 0;
            this.label6.Text = "收件人";
            // 
            // But_Close
            // 
            this.But_Close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.But_Close.BackgroundImage = global::LawtechPTSystemByFirm.Properties.Resources.btnCancel;
            this.But_Close.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.But_Close.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.But_Close.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.But_Close.Location = new System.Drawing.Point(834, 364);
            this.But_Close.Name = "But_Close";
            this.But_Close.Size = new System.Drawing.Size(100, 30);
            this.But_Close.TabIndex = 21;
            this.But_Close.Text = "關  閉";
            this.But_Close.UseVisualStyleBackColor = true;
            this.But_Close.Click += new System.EventHandler(this.But_Close_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.Transparent;
            this.label17.Font = new System.Drawing.Font("微軟正黑體", 8F);
            this.label17.ForeColor = System.Drawing.Color.Purple;
            this.label17.Location = new System.Drawing.Point(19, 357);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(234, 15);
            this.label17.TabIndex = 21;
            this.label17.Text = "* 「寄件者設定」可參考Outlook的寄件人設定";
            // 
            // EmailSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::LawtechPTSystemByFirm.Properties.Resources.EditForm_bg;
            this.CancelButton = this.But_Close;
            this.ClientSize = new System.Drawing.Size(946, 405);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.But_Close);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EmailSet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "寄件者設定";
            this.Load += new System.EventHandler(this.EmailSet_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EmailSet_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_EmailTimeOut)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_Password;
        private System.Windows.Forms.TextBox txt_EmailAccount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox_SelectSMTP;
        private System.Windows.Forms.CheckBox chb_SSL;
        private System.Windows.Forms.TextBox txt_SmtpPort;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button but_SetMail;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txt_Subject;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_Reciver;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button but_SendMail;
        private System.Windows.Forms.TextBox txt_Body;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_AttachFile;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox txt_STMPserver;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txt_EmailAddress;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txt_Name;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.NumericUpDown numericUpDown_EmailTimeOut;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button But_Close;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label5;
    }
}