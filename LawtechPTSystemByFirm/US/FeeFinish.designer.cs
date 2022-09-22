namespace LawtechPTSystemByFirm.US
{
    partial class FeeFinish
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
            this.txt_FeeSubject = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.but_Cancel = new System.Windows.Forms.Button();
            this.but_OK = new System.Windows.Forms.Button();
            this.maskedTextBox_ReceiptDate = new System.Windows.Forms.MaskedTextBox();
            this.label62 = new System.Windows.Forms.Label();
            this.txt_PPP = new System.Windows.Forms.TextBox();
            this.maskedTextBox_PayDate = new System.Windows.Forms.MaskedTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label84 = new System.Windows.Forms.Label();
            this.txt_PayKind = new System.Windows.Forms.TextBox();
            this.label83 = new System.Windows.Forms.Label();
            this.label82 = new System.Windows.Forms.Label();
            this.checkBox_Pay = new System.Windows.Forms.CheckBox();
            this.txt_Remark = new System.Windows.Forms.TextBox();
            this.chkWithholding = new System.Windows.Forms.CheckBox();
            this.label47 = new System.Windows.Forms.Label();
            this.checkBox_NT = new System.Windows.Forms.CheckBox();
            this.label117 = new System.Windows.Forms.Label();
            this.label116 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDown_PracicalityPay = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_Tax = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.linkLabel_PPP = new System.Windows.Forms.LinkLabel();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_PracicalityPay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Tax)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_FeeSubject
            // 
            this.txt_FeeSubject.BackColor = System.Drawing.Color.LightBlue;
            this.txt_FeeSubject.ForeColor = System.Drawing.Color.Blue;
            this.txt_FeeSubject.Location = new System.Drawing.Point(104, 12);
            this.txt_FeeSubject.Name = "txt_FeeSubject";
            this.txt_FeeSubject.ReadOnly = true;
            this.txt_FeeSubject.Size = new System.Drawing.Size(519, 29);
            this.txt_FeeSubject.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 20);
            this.label1.TabIndex = 364;
            this.label1.Text = "費用內容";
            // 
            // but_Cancel
            // 
            this.but_Cancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.but_Cancel.BackgroundImage = global::LawtechPTSystemByFirm.Properties.Resources.btnCancel;
            this.but_Cancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.but_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.but_Cancel.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.but_Cancel.Location = new System.Drawing.Point(321, 417);
            this.but_Cancel.Margin = new System.Windows.Forms.Padding(1);
            this.but_Cancel.Name = "but_Cancel";
            this.but_Cancel.Size = new System.Drawing.Size(100, 32);
            this.but_Cancel.TabIndex = 12;
            this.but_Cancel.Text = "取   消";
            this.but_Cancel.UseVisualStyleBackColor = true;
            this.but_Cancel.Click += new System.EventHandler(this.but_Cancel_Click);
            // 
            // but_OK
            // 
            this.but_OK.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.but_OK.BackgroundImage = global::LawtechPTSystemByFirm.Properties.Resources.btnComfirm;
            this.but_OK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.but_OK.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.but_OK.Location = new System.Drawing.Point(217, 417);
            this.but_OK.Margin = new System.Windows.Forms.Padding(1);
            this.but_OK.Name = "but_OK";
            this.but_OK.Size = new System.Drawing.Size(100, 32);
            this.but_OK.TabIndex = 11;
            this.but_OK.Text = "確   定";
            this.but_OK.UseVisualStyleBackColor = true;
            this.but_OK.Click += new System.EventHandler(this.but_OK_Click);
            // 
            // maskedTextBox_ReceiptDate
            // 
            this.maskedTextBox_ReceiptDate.BackColor = System.Drawing.Color.White;
            this.maskedTextBox_ReceiptDate.ForeColor = System.Drawing.Color.Green;
            this.maskedTextBox_ReceiptDate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.maskedTextBox_ReceiptDate.Location = new System.Drawing.Point(104, 78);
            this.maskedTextBox_ReceiptDate.Mask = "0000/00/00";
            this.maskedTextBox_ReceiptDate.Name = "maskedTextBox_ReceiptDate";
            this.maskedTextBox_ReceiptDate.Size = new System.Drawing.Size(110, 29);
            this.maskedTextBox_ReceiptDate.TabIndex = 2;
            this.maskedTextBox_ReceiptDate.ValidatingType = typeof(System.DateTime);
            this.maskedTextBox_ReceiptDate.DoubleClick += new System.EventHandler(this.maskedTextBox_ReceiptDate_DoubleClick);
            // 
            // label62
            // 
            this.label62.AutoSize = true;
            this.label62.Location = new System.Drawing.Point(30, 82);
            this.label62.Name = "label62";
            this.label62.Size = new System.Drawing.Size(73, 20);
            this.label62.TabIndex = 1082;
            this.label62.Text = "收據日期";
            // 
            // txt_PPP
            // 
            this.txt_PPP.BackColor = System.Drawing.Color.White;
            this.txt_PPP.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.txt_PPP.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.txt_PPP.Location = new System.Drawing.Point(104, 45);
            this.txt_PPP.Name = "txt_PPP";
            this.txt_PPP.Size = new System.Drawing.Size(419, 29);
            this.txt_PPP.TabIndex = 1;
            // 
            // maskedTextBox_PayDate
            // 
            this.maskedTextBox_PayDate.BackColor = System.Drawing.Color.White;
            this.maskedTextBox_PayDate.ForeColor = System.Drawing.Color.Green;
            this.maskedTextBox_PayDate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.maskedTextBox_PayDate.Location = new System.Drawing.Point(104, 280);
            this.maskedTextBox_PayDate.Mask = "0000/00/00";
            this.maskedTextBox_PayDate.Name = "maskedTextBox_PayDate";
            this.maskedTextBox_PayDate.Size = new System.Drawing.Size(110, 29);
            this.maskedTextBox_PayDate.TabIndex = 3;
            this.maskedTextBox_PayDate.ValidatingType = typeof(System.DateTime);
            this.maskedTextBox_PayDate.DoubleClick += new System.EventHandler(this.maskedTextBox_ReceiptDate_DoubleClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(30, 284);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 20);
            this.label2.TabIndex = 1077;
            this.label2.Text = "收款日期";
            // 
            // label84
            // 
            this.label84.AutoSize = true;
            this.label84.Location = new System.Drawing.Point(46, 167);
            this.label84.Name = "label84";
            this.label84.Size = new System.Drawing.Size(57, 20);
            this.label84.TabIndex = 1075;
            this.label84.Text = "已預扣";
            // 
            // txt_PayKind
            // 
            this.txt_PayKind.BackColor = System.Drawing.Color.White;
            this.txt_PayKind.ImeMode = System.Windows.Forms.ImeMode.Close;
            this.txt_PayKind.Location = new System.Drawing.Point(104, 111);
            this.txt_PayKind.Name = "txt_PayKind";
            this.txt_PayKind.Size = new System.Drawing.Size(519, 29);
            this.txt_PayKind.TabIndex = 9;
            // 
            // label83
            // 
            this.label83.AutoSize = true;
            this.label83.Location = new System.Drawing.Point(30, 144);
            this.label83.Name = "label83";
            this.label83.Size = new System.Drawing.Size(73, 20);
            this.label83.TabIndex = 1074;
            this.label83.Text = "外幣收款";
            // 
            // label82
            // 
            this.label82.AutoSize = true;
            this.label82.ForeColor = System.Drawing.Color.Blue;
            this.label82.Location = new System.Drawing.Point(46, 257);
            this.label82.Name = "label82";
            this.label82.Size = new System.Drawing.Size(57, 20);
            this.label82.TabIndex = 1073;
            this.label82.Text = "已收款";
            // 
            // checkBox_Pay
            // 
            this.checkBox_Pay.AutoSize = true;
            this.checkBox_Pay.Checked = true;
            this.checkBox_Pay.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_Pay.ForeColor = System.Drawing.Color.Blue;
            this.checkBox_Pay.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.checkBox_Pay.Location = new System.Drawing.Point(104, 260);
            this.checkBox_Pay.Name = "checkBox_Pay";
            this.checkBox_Pay.Size = new System.Drawing.Size(15, 14);
            this.checkBox_Pay.TabIndex = 8;
            this.checkBox_Pay.UseVisualStyleBackColor = true;
            this.checkBox_Pay.CheckedChanged += new System.EventHandler(this.checkBox_Pay_CheckedChanged);
            // 
            // txt_Remark
            // 
            this.txt_Remark.ImeMode = System.Windows.Forms.ImeMode.Close;
            this.txt_Remark.Location = new System.Drawing.Point(104, 312);
            this.txt_Remark.Multiline = true;
            this.txt_Remark.Name = "txt_Remark";
            this.txt_Remark.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_Remark.Size = new System.Drawing.Size(520, 101);
            this.txt_Remark.TabIndex = 10;
            // 
            // chkWithholding
            // 
            this.chkWithholding.AutoSize = true;
            this.chkWithholding.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.chkWithholding.Location = new System.Drawing.Point(104, 171);
            this.chkWithholding.Name = "chkWithholding";
            this.chkWithholding.Size = new System.Drawing.Size(15, 14);
            this.chkWithholding.TabIndex = 5;
            this.chkWithholding.UseVisualStyleBackColor = true;
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.Location = new System.Drawing.Point(30, 115);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(73, 20);
            this.label47.TabIndex = 1071;
            this.label47.Text = "收款方式";
            // 
            // checkBox_NT
            // 
            this.checkBox_NT.AutoSize = true;
            this.checkBox_NT.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.checkBox_NT.Location = new System.Drawing.Point(104, 149);
            this.checkBox_NT.Name = "checkBox_NT";
            this.checkBox_NT.Size = new System.Drawing.Size(15, 14);
            this.checkBox_NT.TabIndex = 4;
            this.checkBox_NT.UseVisualStyleBackColor = true;
            // 
            // label117
            // 
            this.label117.AutoSize = true;
            this.label117.Location = new System.Drawing.Point(30, 228);
            this.label117.Name = "label117";
            this.label117.Size = new System.Drawing.Size(73, 20);
            this.label117.TabIndex = 1065;
            this.label117.Text = "實際收款";
            // 
            // label116
            // 
            this.label116.AutoSize = true;
            this.label116.Location = new System.Drawing.Point(30, 196);
            this.label116.Name = "label116";
            this.label116.Size = new System.Drawing.Size(73, 20);
            this.label116.TabIndex = 1064;
            this.label116.Text = "預扣稅額";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(54, 316);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 20);
            this.label3.TabIndex = 1083;
            this.label3.Text = "備  註";
            // 
            // numericUpDown_PracicalityPay
            // 
            this.numericUpDown_PracicalityPay.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.numericUpDown_PracicalityPay.ForeColor = System.Drawing.Color.DarkOrchid;
            this.numericUpDown_PracicalityPay.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDown_PracicalityPay.Location = new System.Drawing.Point(104, 225);
            this.numericUpDown_PracicalityPay.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.numericUpDown_PracicalityPay.Name = "numericUpDown_PracicalityPay";
            this.numericUpDown_PracicalityPay.Size = new System.Drawing.Size(130, 29);
            this.numericUpDown_PracicalityPay.TabIndex = 7;
            this.numericUpDown_PracicalityPay.ThousandsSeparator = true;
            // 
            // numericUpDown_Tax
            // 
            this.numericUpDown_Tax.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.numericUpDown_Tax.ForeColor = System.Drawing.Color.DarkGoldenrod;
            this.numericUpDown_Tax.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDown_Tax.Location = new System.Drawing.Point(104, 192);
            this.numericUpDown_Tax.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericUpDown_Tax.Name = "numericUpDown_Tax";
            this.numericUpDown_Tax.Size = new System.Drawing.Size(130, 29);
            this.numericUpDown_Tax.TabIndex = 6;
            this.numericUpDown_Tax.ThousandsSeparator = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微軟正黑體", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(122, 260);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(144, 15);
            this.label4.TabIndex = 1086;
            this.label4.Text = "*勾選則表示已完成該項請款";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label5.ForeColor = System.Drawing.Color.Green;
            this.label5.Location = new System.Drawing.Point(485, 417);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(142, 17);
            this.label5.TabIndex = 1087;
            this.label5.Text = "Shift+Enter：換下一行";
            // 
            // linkLabel_PPP
            // 
            this.linkLabel_PPP.AutoSize = true;
            this.linkLabel_PPP.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.linkLabel_PPP.Location = new System.Drawing.Point(529, 52);
            this.linkLabel_PPP.Name = "linkLabel_PPP";
            this.linkLabel_PPP.Size = new System.Drawing.Size(92, 18);
            this.linkLabel_PPP.TabIndex = 1088;
            this.linkLabel_PPP.TabStop = true;
            this.linkLabel_PPP.Text = "產生請款單號";
            this.linkLabel_PPP.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_PPP_LinkClicked);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(30, 50);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 20);
            this.label6.TabIndex = 1089;
            this.label6.Text = "請款單號";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(236, 196);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 20);
            this.label7.TabIndex = 1090;
            this.label7.Text = "NT";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(237, 230);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(31, 20);
            this.label8.TabIndex = 1091;
            this.label8.Text = "NT";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("微軟正黑體", 9F);
            this.label9.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label9.Location = new System.Drawing.Point(271, 232);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(136, 16);
            this.label9.TabIndex = 1092;
            this.label9.Text = "(實際收款時的台幣金額)";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("微軟正黑體", 9F);
            this.label10.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label10.Location = new System.Drawing.Point(270, 200);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(136, 16);
            this.label10.TabIndex = 1093;
            this.label10.Text = "(實際收款時的台幣稅額)";
            // 
            // FeeFinish
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = global::LawtechPTSystemByFirm.Properties.Resources.bg_01;
            this.CancelButton = this.but_Cancel;
            this.ClientSize = new System.Drawing.Size(633, 464);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.linkLabel_PPP);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.numericUpDown_Tax);
            this.Controls.Add(this.numericUpDown_PracicalityPay);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.maskedTextBox_ReceiptDate);
            this.Controls.Add(this.label62);
            this.Controls.Add(this.txt_PPP);
            this.Controls.Add(this.maskedTextBox_PayDate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label84);
            this.Controls.Add(this.txt_PayKind);
            this.Controls.Add(this.label83);
            this.Controls.Add(this.label82);
            this.Controls.Add(this.checkBox_Pay);
            this.Controls.Add(this.txt_Remark);
            this.Controls.Add(this.chkWithholding);
            this.Controls.Add(this.label47);
            this.Controls.Add(this.checkBox_NT);
            this.Controls.Add(this.label117);
            this.Controls.Add(this.label116);
            this.Controls.Add(this.but_Cancel);
            this.Controls.Add(this.but_OK);
            this.Controls.Add(this.txt_FeeSubject);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FeeFinish";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "已 請 款";
            this.Load += new System.EventHandler(this.FeeFinish_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FeeFinish_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_PracicalityPay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Tax)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_FeeSubject;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button but_Cancel;
        private System.Windows.Forms.Button but_OK;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_ReceiptDate;
        private System.Windows.Forms.Label label62;
        internal System.Windows.Forms.TextBox txt_PPP;
        internal System.Windows.Forms.MaskedTextBox maskedTextBox_PayDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label84;
        private System.Windows.Forms.TextBox txt_PayKind;
        private System.Windows.Forms.Label label83;
        private System.Windows.Forms.Label label82;
        private System.Windows.Forms.CheckBox checkBox_Pay;
        private System.Windows.Forms.TextBox txt_Remark;
        private System.Windows.Forms.CheckBox chkWithholding;
        private System.Windows.Forms.Label label47;
        private System.Windows.Forms.CheckBox checkBox_NT;
        private System.Windows.Forms.Label label117;
        private System.Windows.Forms.Label label116;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDown_PracicalityPay;
        private System.Windows.Forms.NumericUpDown numericUpDown_Tax;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.LinkLabel linkLabel_PPP;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
    }
}