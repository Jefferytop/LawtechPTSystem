namespace LawtechPTSystem.US
{
    partial class PaymentFinish
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
            this.but_Cancel = new System.Windows.Forms.Button();
            this.but_OK = new System.Windows.Forms.Button();
            this.maskedTextBox_IReceiptDate = new System.Windows.Forms.MaskedTextBox();
            this.label34 = new System.Windows.Forms.Label();
            this.txt_BillingNo = new System.Windows.Forms.TextBox();
            this.label31 = new System.Windows.Forms.Label();
            this.maskedTextBox_PayDueDate = new System.Windows.Forms.MaskedTextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.maskedTextBox_ReciveDate = new System.Windows.Forms.MaskedTextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.txt_BillCheck = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.txt_FeeSubject = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txt_Totall = new System.Windows.Forms.TextBox();
            this.label46 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.maskedTextBox_PaymentDate = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_ExchangeRate = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_IMoney = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // but_Cancel
            // 
            this.but_Cancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.but_Cancel.BackgroundImage = global::LawtechPTSystem.Properties.Resources.btnCancel;
            this.but_Cancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.but_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.but_Cancel.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.but_Cancel.Location = new System.Drawing.Point(227, 273);
            this.but_Cancel.Margin = new System.Windows.Forms.Padding(1);
            this.but_Cancel.Name = "but_Cancel";
            this.but_Cancel.Size = new System.Drawing.Size(100, 32);
            this.but_Cancel.TabIndex = 382;
            this.but_Cancel.Text = "取   消";
            this.but_Cancel.UseVisualStyleBackColor = true;
            this.but_Cancel.Click += new System.EventHandler(this.but_Cancel_Click);
            // 
            // but_OK
            // 
            this.but_OK.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.but_OK.BackgroundImage = global::LawtechPTSystem.Properties.Resources.btnComfirm;
            this.but_OK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.but_OK.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.but_OK.Location = new System.Drawing.Point(125, 273);
            this.but_OK.Margin = new System.Windows.Forms.Padding(1);
            this.but_OK.Name = "but_OK";
            this.but_OK.Size = new System.Drawing.Size(100, 32);
            this.but_OK.TabIndex = 381;
            this.but_OK.Text = "確   定";
            this.but_OK.UseVisualStyleBackColor = true;
            this.but_OK.Click += new System.EventHandler(this.but_OK_Click);
            // 
            // maskedTextBox_IReceiptDate
            // 
            this.maskedTextBox_IReceiptDate.ForeColor = System.Drawing.Color.Green;
            this.maskedTextBox_IReceiptDate.ImeMode = System.Windows.Forms.ImeMode.Close;
            this.maskedTextBox_IReceiptDate.Location = new System.Drawing.Point(323, 213);
            this.maskedTextBox_IReceiptDate.Mask = "0000/00/00";
            this.maskedTextBox_IReceiptDate.Name = "maskedTextBox_IReceiptDate";
            this.maskedTextBox_IReceiptDate.Size = new System.Drawing.Size(110, 29);
            this.maskedTextBox_IReceiptDate.TabIndex = 418;
            this.maskedTextBox_IReceiptDate.ValidatingType = typeof(System.DateTime);
            this.maskedTextBox_IReceiptDate.DoubleClick += new System.EventHandler(this.maskedTextBox_IReceiptDate_DoubleClick);
            this.maskedTextBox_IReceiptDate.Leave += new System.EventHandler(this.maskedTextBox_IReceiptDate_Leave);
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.ForeColor = System.Drawing.Color.Blue;
            this.label34.Location = new System.Drawing.Point(249, 218);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(73, 20);
            this.label34.TabIndex = 420;
            this.label34.Text = "完成日期";
            // 
            // txt_BillingNo
            // 
            this.txt_BillingNo.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.txt_BillingNo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txt_BillingNo.Location = new System.Drawing.Point(94, 178);
            this.txt_BillingNo.Name = "txt_BillingNo";
            this.txt_BillingNo.ReadOnly = true;
            this.txt_BillingNo.Size = new System.Drawing.Size(339, 29);
            this.txt_BillingNo.TabIndex = 449;
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(4, 182);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(89, 20);
            this.label31.TabIndex = 448;
            this.label31.Text = "請款單編號";
            // 
            // maskedTextBox_PayDueDate
            // 
            this.maskedTextBox_PayDueDate.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.maskedTextBox_PayDueDate.ForeColor = System.Drawing.Color.Green;
            this.maskedTextBox_PayDueDate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.maskedTextBox_PayDueDate.Location = new System.Drawing.Point(323, 46);
            this.maskedTextBox_PayDueDate.Mask = "0000/00/00";
            this.maskedTextBox_PayDueDate.Name = "maskedTextBox_PayDueDate";
            this.maskedTextBox_PayDueDate.ReadOnly = true;
            this.maskedTextBox_PayDueDate.Size = new System.Drawing.Size(110, 29);
            this.maskedTextBox_PayDueDate.TabIndex = 444;
            this.maskedTextBox_PayDueDate.ValidatingType = typeof(System.DateTime);
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(249, 50);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(73, 20);
            this.label28.TabIndex = 445;
            this.label28.Text = "付款期限";
            // 
            // maskedTextBox_ReciveDate
            // 
            this.maskedTextBox_ReciveDate.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.maskedTextBox_ReciveDate.ForeColor = System.Drawing.Color.Green;
            this.maskedTextBox_ReciveDate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.maskedTextBox_ReciveDate.Location = new System.Drawing.Point(94, 45);
            this.maskedTextBox_ReciveDate.Mask = "0000/00/00";
            this.maskedTextBox_ReciveDate.Name = "maskedTextBox_ReciveDate";
            this.maskedTextBox_ReciveDate.ReadOnly = true;
            this.maskedTextBox_ReciveDate.Size = new System.Drawing.Size(110, 29);
            this.maskedTextBox_ReciveDate.TabIndex = 442;
            this.maskedTextBox_ReciveDate.ValidatingType = typeof(System.DateTime);
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(20, 49);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(73, 20);
            this.label27.TabIndex = 443;
            this.label27.Text = "收件日期";
            // 
            // txt_BillCheck
            // 
            this.txt_BillCheck.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.txt_BillCheck.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txt_BillCheck.Location = new System.Drawing.Point(94, 145);
            this.txt_BillCheck.Name = "txt_BillCheck";
            this.txt_BillCheck.ReadOnly = true;
            this.txt_BillCheck.Size = new System.Drawing.Size(339, 29);
            this.txt_BillCheck.TabIndex = 441;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(20, 149);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(73, 20);
            this.label19.TabIndex = 440;
            this.label19.Text = "帳單確認";
            // 
            // txt_FeeSubject
            // 
            this.txt_FeeSubject.BackColor = System.Drawing.Color.LightBlue;
            this.txt_FeeSubject.ForeColor = System.Drawing.Color.Blue;
            this.txt_FeeSubject.ImeMode = System.Windows.Forms.ImeMode.Close;
            this.txt_FeeSubject.Location = new System.Drawing.Point(94, 12);
            this.txt_FeeSubject.Name = "txt_FeeSubject";
            this.txt_FeeSubject.ReadOnly = true;
            this.txt_FeeSubject.Size = new System.Drawing.Size(339, 29);
            this.txt_FeeSubject.TabIndex = 451;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(20, 17);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(73, 20);
            this.label15.TabIndex = 450;
            this.label15.Text = "費用內容";
            // 
            // txt_Totall
            // 
            this.txt_Totall.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.txt_Totall.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold);
            this.txt_Totall.ForeColor = System.Drawing.Color.MediumBlue;
            this.txt_Totall.Location = new System.Drawing.Point(94, 112);
            this.txt_Totall.Name = "txt_Totall";
            this.txt_Totall.ReadOnly = true;
            this.txt_Totall.Size = new System.Drawing.Size(110, 29);
            this.txt_Totall.TabIndex = 453;
            this.txt_Totall.Text = "0";
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.Location = new System.Drawing.Point(20, 117);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(73, 20);
            this.label46.TabIndex = 452;
            this.label46.Text = "金額總計";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 216);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 20);
            this.label1.TabIndex = 464;
            this.label1.Text = "付款日期";
            // 
            // maskedTextBox_PaymentDate
            // 
            this.maskedTextBox_PaymentDate.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.maskedTextBox_PaymentDate.ForeColor = System.Drawing.Color.Green;
            this.maskedTextBox_PaymentDate.ImeMode = System.Windows.Forms.ImeMode.Close;
            this.maskedTextBox_PaymentDate.Location = new System.Drawing.Point(94, 211);
            this.maskedTextBox_PaymentDate.Mask = "0000/00/00";
            this.maskedTextBox_PaymentDate.Name = "maskedTextBox_PaymentDate";
            this.maskedTextBox_PaymentDate.ReadOnly = true;
            this.maskedTextBox_PaymentDate.Size = new System.Drawing.Size(110, 29);
            this.maskedTextBox_PaymentDate.TabIndex = 463;
            this.maskedTextBox_PaymentDate.ValidatingType = typeof(System.DateTime);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(249, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 20);
            this.label3.TabIndex = 467;
            this.label3.Text = "當時匯率";
            // 
            // txt_ExchangeRate
            // 
            this.txt_ExchangeRate.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.txt_ExchangeRate.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold);
            this.txt_ExchangeRate.ForeColor = System.Drawing.Color.MediumBlue;
            this.txt_ExchangeRate.Location = new System.Drawing.Point(323, 79);
            this.txt_ExchangeRate.Name = "txt_ExchangeRate";
            this.txt_ExchangeRate.ReadOnly = true;
            this.txt_ExchangeRate.Size = new System.Drawing.Size(110, 29);
            this.txt_ExchangeRate.TabIndex = 468;
            this.txt_ExchangeRate.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(40, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 20);
            this.label4.TabIndex = 469;
            this.label4.Text = "幣   別";
            // 
            // txt_IMoney
            // 
            this.txt_IMoney.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.txt_IMoney.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold);
            this.txt_IMoney.ForeColor = System.Drawing.Color.MediumBlue;
            this.txt_IMoney.Location = new System.Drawing.Point(94, 78);
            this.txt_IMoney.Name = "txt_IMoney";
            this.txt_IMoney.ReadOnly = true;
            this.txt_IMoney.Size = new System.Drawing.Size(110, 29);
            this.txt_IMoney.TabIndex = 470;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 9F);
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(294, 243);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(148, 16);
            this.label2.TabIndex = 471;
            this.label2.Text = "* 請確認收款人已經到款項";
            // 
            // PaymentFinish
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = global::LawtechPTSystem.Properties.Resources.bg_01;
            this.CancelButton = this.but_Cancel;
            this.ClientSize = new System.Drawing.Size(452, 320);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_IMoney);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_ExchangeRate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.maskedTextBox_PaymentDate);
            this.Controls.Add(this.txt_Totall);
            this.Controls.Add(this.label46);
            this.Controls.Add(this.txt_FeeSubject);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.txt_BillingNo);
            this.Controls.Add(this.label31);
            this.Controls.Add(this.maskedTextBox_PayDueDate);
            this.Controls.Add(this.label28);
            this.Controls.Add(this.maskedTextBox_ReciveDate);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.txt_BillCheck);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.maskedTextBox_IReceiptDate);
            this.Controls.Add(this.label34);
            this.Controls.Add(this.but_Cancel);
            this.Controls.Add(this.but_OK);
            this.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PaymentFinish";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "完成付款";
            this.Load += new System.EventHandler(this.PaymentFinish_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button but_Cancel;
        private System.Windows.Forms.Button but_OK;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_IReceiptDate;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.TextBox txt_BillingNo;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_PayDueDate;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_ReciveDate;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.TextBox txt_BillCheck;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txt_FeeSubject;
        private System.Windows.Forms.Label label15;
        internal System.Windows.Forms.TextBox txt_Totall;
        private System.Windows.Forms.Label label46;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_PaymentDate;
        private System.Windows.Forms.Label label3;
        internal System.Windows.Forms.TextBox txt_ExchangeRate;
        private System.Windows.Forms.Label label4;
        internal System.Windows.Forms.TextBox txt_IMoney;
        private System.Windows.Forms.Label label2;
    }
}