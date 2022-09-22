namespace LawtechPTSystemByFirm.US
{
    partial class AccountingPaymentFinish
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
            this.components = new System.ComponentModel.Container();
            this.txt_IMoney = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.maskedTextBox_PaymentDate = new System.Windows.Forms.MaskedTextBox();
            this.txt_Totall = new System.Windows.Forms.TextBox();
            this.label46 = new System.Windows.Forms.Label();
            this.txt_FeeSubject = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txt_BillingNo = new System.Windows.Forms.TextBox();
            this.maskedTextBox_PayDueDate = new System.Windows.Forms.MaskedTextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.maskedTextBox_ReciveDate = new System.Windows.Forms.MaskedTextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.txt_BillCheck = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.maskedTextBox_IReceiptDate = new System.Windows.Forms.MaskedTextBox();
            this.label34 = new System.Windows.Forms.Label();
            this.but_Cancel = new System.Windows.Forms.Button();
            this.but_OK = new System.Windows.Forms.Button();
            this.label29 = new System.Windows.Forms.Label();
            this.txt_Memo = new System.Windows.Forms.TextBox();
            this.checkBox_IsBilling = new System.Windows.Forms.CheckBox();
            this.label42 = new System.Windows.Forms.Label();
            this.checkBox_IsScan = new System.Windows.Forms.CheckBox();
            this.checkBox_IsCopyFile = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.maskedTextBox_EstimatedPaymentDate = new System.Windows.Forms.MaskedTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBox_AcountingFirmKey = new System.Windows.Forms.ComboBox();
            this.acountingFirmTBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet_Attorney = new LawtechPTSystemByFirm.DataSet_Attorney();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_IReceiptNo = new System.Windows.Forms.TextBox();
            this.acountingFirmTTableAdapter = new LawtechPTSystemByFirm.DataSet_AttorneyTableAdapters.AcountingFirmTTableAdapter();
            this.label9 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.numericUpDown_ExchangeRate = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDown_ActuallyPay = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.acountingFirmTBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_Attorney)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_ExchangeRate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_ActuallyPay)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_IMoney
            // 
            this.txt_IMoney.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.txt_IMoney.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold);
            this.txt_IMoney.ForeColor = System.Drawing.Color.MediumBlue;
            this.txt_IMoney.Location = new System.Drawing.Point(103, 45);
            this.txt_IMoney.Name = "txt_IMoney";
            this.txt_IMoney.ReadOnly = true;
            this.txt_IMoney.Size = new System.Drawing.Size(130, 29);
            this.txt_IMoney.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(49, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 20);
            this.label4.TabIndex = 492;
            this.label4.Text = "幣   別";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 20);
            this.label3.TabIndex = 490;
            this.label3.Text = "當時匯率";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 249);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 20);
            this.label1.TabIndex = 489;
            this.label1.Text = "付款日期";
            // 
            // maskedTextBox_PaymentDate
            // 
            this.maskedTextBox_PaymentDate.BackColor = System.Drawing.Color.White;
            this.maskedTextBox_PaymentDate.ForeColor = System.Drawing.Color.Green;
            this.maskedTextBox_PaymentDate.ImeMode = System.Windows.Forms.ImeMode.Close;
            this.maskedTextBox_PaymentDate.Location = new System.Drawing.Point(103, 244);
            this.maskedTextBox_PaymentDate.Mask = "0000/00/00";
            this.maskedTextBox_PaymentDate.Name = "maskedTextBox_PaymentDate";
            this.maskedTextBox_PaymentDate.Size = new System.Drawing.Size(130, 29);
            this.maskedTextBox_PaymentDate.TabIndex = 4;
            this.maskedTextBox_PaymentDate.ValidatingType = typeof(System.DateTime);
            this.maskedTextBox_PaymentDate.DoubleClick += new System.EventHandler(this.maskedTextBox_PaymentDate_DoubleClick);
            // 
            // txt_Totall
            // 
            this.txt_Totall.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.txt_Totall.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold);
            this.txt_Totall.ForeColor = System.Drawing.Color.MediumBlue;
            this.txt_Totall.Location = new System.Drawing.Point(103, 78);
            this.txt_Totall.Name = "txt_Totall";
            this.txt_Totall.ReadOnly = true;
            this.txt_Totall.Size = new System.Drawing.Size(130, 29);
            this.txt_Totall.TabIndex = 3;
            this.txt_Totall.Text = "0";
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.Location = new System.Drawing.Point(29, 83);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(73, 20);
            this.label46.TabIndex = 486;
            this.label46.Text = "金額總計";
            // 
            // txt_FeeSubject
            // 
            this.txt_FeeSubject.BackColor = System.Drawing.Color.LightBlue;
            this.txt_FeeSubject.ForeColor = System.Drawing.Color.Blue;
            this.txt_FeeSubject.ImeMode = System.Windows.Forms.ImeMode.Close;
            this.txt_FeeSubject.Location = new System.Drawing.Point(103, 12);
            this.txt_FeeSubject.Name = "txt_FeeSubject";
            this.txt_FeeSubject.ReadOnly = true;
            this.txt_FeeSubject.Size = new System.Drawing.Size(351, 29);
            this.txt_FeeSubject.TabIndex = 0;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(29, 17);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(73, 20);
            this.label15.TabIndex = 484;
            this.label15.Text = "費用內容";
            // 
            // txt_BillingNo
            // 
            this.txt_BillingNo.BackColor = System.Drawing.Color.White;
            this.txt_BillingNo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txt_BillingNo.Location = new System.Drawing.Point(103, 178);
            this.txt_BillingNo.Name = "txt_BillingNo";
            this.txt_BillingNo.Size = new System.Drawing.Size(130, 29);
            this.txt_BillingNo.TabIndex = 2;
            // 
            // maskedTextBox_PayDueDate
            // 
            this.maskedTextBox_PayDueDate.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.maskedTextBox_PayDueDate.ForeColor = System.Drawing.Color.Green;
            this.maskedTextBox_PayDueDate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.maskedTextBox_PayDueDate.Location = new System.Drawing.Point(332, 80);
            this.maskedTextBox_PayDueDate.Mask = "0000/00/00";
            this.maskedTextBox_PayDueDate.Name = "maskedTextBox_PayDueDate";
            this.maskedTextBox_PayDueDate.ReadOnly = true;
            this.maskedTextBox_PayDueDate.Size = new System.Drawing.Size(122, 29);
            this.maskedTextBox_PayDueDate.TabIndex = 4;
            this.maskedTextBox_PayDueDate.ValidatingType = typeof(System.DateTime);
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(258, 84);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(73, 20);
            this.label28.TabIndex = 481;
            this.label28.Text = "付款期限";
            // 
            // maskedTextBox_ReciveDate
            // 
            this.maskedTextBox_ReciveDate.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.maskedTextBox_ReciveDate.ForeColor = System.Drawing.Color.Green;
            this.maskedTextBox_ReciveDate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.maskedTextBox_ReciveDate.Location = new System.Drawing.Point(332, 47);
            this.maskedTextBox_ReciveDate.Mask = "0000/00/00";
            this.maskedTextBox_ReciveDate.Name = "maskedTextBox_ReciveDate";
            this.maskedTextBox_ReciveDate.ReadOnly = true;
            this.maskedTextBox_ReciveDate.Size = new System.Drawing.Size(122, 29);
            this.maskedTextBox_ReciveDate.TabIndex = 1;
            this.maskedTextBox_ReciveDate.ValidatingType = typeof(System.DateTime);
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(258, 51);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(73, 20);
            this.label27.TabIndex = 479;
            this.label27.Text = "收件日期";
            // 
            // txt_BillCheck
            // 
            this.txt_BillCheck.BackColor = System.Drawing.Color.White;
            this.txt_BillCheck.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txt_BillCheck.Location = new System.Drawing.Point(103, 211);
            this.txt_BillCheck.Name = "txt_BillCheck";
            this.txt_BillCheck.Size = new System.Drawing.Size(130, 29);
            this.txt_BillCheck.TabIndex = 3;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(29, 215);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(73, 20);
            this.label19.TabIndex = 476;
            this.label19.Text = "帳單確認";
            // 
            // maskedTextBox_IReceiptDate
            // 
            this.maskedTextBox_IReceiptDate.BackColor = System.Drawing.Color.White;
            this.maskedTextBox_IReceiptDate.ForeColor = System.Drawing.Color.Green;
            this.maskedTextBox_IReceiptDate.ImeMode = System.Windows.Forms.ImeMode.Close;
            this.maskedTextBox_IReceiptDate.Location = new System.Drawing.Point(103, 277);
            this.maskedTextBox_IReceiptDate.Mask = "0000/00/00";
            this.maskedTextBox_IReceiptDate.Name = "maskedTextBox_IReceiptDate";
            this.maskedTextBox_IReceiptDate.Size = new System.Drawing.Size(130, 29);
            this.maskedTextBox_IReceiptDate.TabIndex = 5;
            this.maskedTextBox_IReceiptDate.ValidatingType = typeof(System.DateTime);
            this.maskedTextBox_IReceiptDate.DoubleClick += new System.EventHandler(this.maskedTextBox_PaymentDate_DoubleClick);
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.ForeColor = System.Drawing.Color.Blue;
            this.label34.Location = new System.Drawing.Point(29, 282);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(73, 20);
            this.label34.TabIndex = 475;
            this.label34.Text = "完成日期";
            // 
            // but_Cancel
            // 
            this.but_Cancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.but_Cancel.BackgroundImage = global::LawtechPTSystemByFirm.Properties.Resources.btnCancel;
            this.but_Cancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.but_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.but_Cancel.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.but_Cancel.Location = new System.Drawing.Point(243, 492);
            this.but_Cancel.Margin = new System.Windows.Forms.Padding(2);
            this.but_Cancel.Name = "but_Cancel";
            this.but_Cancel.Size = new System.Drawing.Size(100, 32);
            this.but_Cancel.TabIndex = 13;
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
            this.but_OK.Location = new System.Drawing.Point(139, 492);
            this.but_OK.Margin = new System.Windows.Forms.Padding(2);
            this.but_OK.Name = "but_OK";
            this.but_OK.Size = new System.Drawing.Size(100, 32);
            this.but_OK.TabIndex = 12;
            this.but_OK.Text = "確   定";
            this.but_OK.UseVisualStyleBackColor = true;
            this.but_OK.Click += new System.EventHandler(this.but_OK_Click);
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(45, 387);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(53, 20);
            this.label29.TabIndex = 500;
            this.label29.Text = "說   明";
            // 
            // txt_Memo
            // 
            this.txt_Memo.BackColor = System.Drawing.Color.White;
            this.txt_Memo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txt_Memo.Location = new System.Drawing.Point(103, 337);
            this.txt_Memo.Multiline = true;
            this.txt_Memo.Name = "txt_Memo";
            this.txt_Memo.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_Memo.Size = new System.Drawing.Size(351, 149);
            this.txt_Memo.TabIndex = 11;
            // 
            // checkBox_IsBilling
            // 
            this.checkBox_IsBilling.AutoSize = true;
            this.checkBox_IsBilling.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.checkBox_IsBilling.Location = new System.Drawing.Point(332, 263);
            this.checkBox_IsBilling.Name = "checkBox_IsBilling";
            this.checkBox_IsBilling.Size = new System.Drawing.Size(140, 24);
            this.checkBox_IsBilling.TabIndex = 10;
            this.checkBox_IsBilling.Text = "是否向客戶請款";
            this.checkBox_IsBilling.UseVisualStyleBackColor = true;
            // 
            // label42
            // 
            this.label42.AutoSize = true;
            this.label42.Location = new System.Drawing.Point(290, 211);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(41, 20);
            this.label42.TabIndex = 497;
            this.label42.Text = "歸檔";
            // 
            // checkBox_IsScan
            // 
            this.checkBox_IsScan.AutoSize = true;
            this.checkBox_IsScan.Location = new System.Drawing.Point(332, 237);
            this.checkBox_IsScan.Name = "checkBox_IsScan";
            this.checkBox_IsScan.Size = new System.Drawing.Size(76, 24);
            this.checkBox_IsScan.TabIndex = 9;
            this.checkBox_IsScan.Text = "掃　瞄";
            this.checkBox_IsScan.UseVisualStyleBackColor = true;
            // 
            // checkBox_IsCopyFile
            // 
            this.checkBox_IsCopyFile.AutoSize = true;
            this.checkBox_IsCopyFile.Location = new System.Drawing.Point(332, 211);
            this.checkBox_IsCopyFile.Name = "checkBox_IsCopyFile";
            this.checkBox_IsCopyFile.Size = new System.Drawing.Size(76, 24);
            this.checkBox_IsCopyFile.TabIndex = 8;
            this.checkBox_IsCopyFile.Text = "影　本";
            this.checkBox_IsCopyFile.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(242, 180);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 20);
            this.label6.TabIndex = 503;
            this.label6.Text = "預估付款日";
            // 
            // maskedTextBox_EstimatedPaymentDate
            // 
            this.maskedTextBox_EstimatedPaymentDate.BackColor = System.Drawing.Color.White;
            this.maskedTextBox_EstimatedPaymentDate.ForeColor = System.Drawing.Color.Green;
            this.maskedTextBox_EstimatedPaymentDate.ImeMode = System.Windows.Forms.ImeMode.Close;
            this.maskedTextBox_EstimatedPaymentDate.Location = new System.Drawing.Point(332, 175);
            this.maskedTextBox_EstimatedPaymentDate.Mask = "0000/00/00";
            this.maskedTextBox_EstimatedPaymentDate.Name = "maskedTextBox_EstimatedPaymentDate";
            this.maskedTextBox_EstimatedPaymentDate.Size = new System.Drawing.Size(122, 29);
            this.maskedTextBox_EstimatedPaymentDate.TabIndex = 7;
            this.maskedTextBox_EstimatedPaymentDate.ValidatingType = typeof(System.DateTime);
            this.maskedTextBox_EstimatedPaymentDate.DoubleClick += new System.EventHandler(this.maskedTextBox_PaymentDate_DoubleClick);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(242, 148);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 20);
            this.label7.TabIndex = 504;
            this.label7.Text = "付款事務所";
            // 
            // comboBox_AcountingFirmKey
            // 
            this.comboBox_AcountingFirmKey.DataSource = this.acountingFirmTBindingSource;
            this.comboBox_AcountingFirmKey.DisplayMember = "AcountingFirmName";
            this.comboBox_AcountingFirmKey.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_AcountingFirmKey.FormattingEnabled = true;
            this.comboBox_AcountingFirmKey.Location = new System.Drawing.Point(332, 145);
            this.comboBox_AcountingFirmKey.Name = "comboBox_AcountingFirmKey";
            this.comboBox_AcountingFirmKey.Size = new System.Drawing.Size(122, 28);
            this.comboBox_AcountingFirmKey.TabIndex = 6;
            this.comboBox_AcountingFirmKey.ValueMember = "AcountingFirmKey";
            // 
            // acountingFirmTBindingSource
            // 
            this.acountingFirmTBindingSource.DataMember = "AcountingFirmT";
            this.acountingFirmTBindingSource.DataSource = this.dataSet_Attorney;
            // 
            // dataSet_Attorney
            // 
            this.dataSet_Attorney.DataSetName = "DataSet_Attorney";
            this.dataSet_Attorney.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(258, 117);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 20);
            this.label8.TabIndex = 506;
            this.label8.Text = "收據號碼";
            // 
            // txt_IReceiptNo
            // 
            this.txt_IReceiptNo.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.txt_IReceiptNo.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold);
            this.txt_IReceiptNo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txt_IReceiptNo.Location = new System.Drawing.Point(332, 112);
            this.txt_IReceiptNo.Name = "txt_IReceiptNo";
            this.txt_IReceiptNo.ReadOnly = true;
            this.txt_IReceiptNo.Size = new System.Drawing.Size(122, 29);
            this.txt_IReceiptNo.TabIndex = 6;
            // 
            // acountingFirmTTableAdapter
            // 
            this.acountingFirmTTableAdapter.ClearBeforeFill = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(29, 183);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(73, 20);
            this.label9.TabIndex = 508;
            this.label9.Text = "請款單號";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微軟正黑體", 8F);
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(99, 308);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(180, 15);
            this.label5.TabIndex = 509;
            this.label5.Text = "* 帳務人員付款完成後，並留存單據";
            // 
            // numericUpDown_ExchangeRate
            // 
            this.numericUpDown_ExchangeRate.DecimalPlaces = 4;
            this.numericUpDown_ExchangeRate.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown_ExchangeRate.Location = new System.Drawing.Point(103, 111);
            this.numericUpDown_ExchangeRate.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericUpDown_ExchangeRate.Name = "numericUpDown_ExchangeRate";
            this.numericUpDown_ExchangeRate.Size = new System.Drawing.Size(130, 29);
            this.numericUpDown_ExchangeRate.TabIndex = 0;
            this.numericUpDown_ExchangeRate.ValueChanged += new System.EventHandler(this.numericUpDown_ExchangeRate_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 148);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(95, 20);
            this.label2.TabIndex = 510;
            this.label2.Text = "實付金額NT";
            // 
            // numericUpDown_ActuallyPay
            // 
            this.numericUpDown_ActuallyPay.Location = new System.Drawing.Point(103, 144);
            this.numericUpDown_ActuallyPay.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.numericUpDown_ActuallyPay.Name = "numericUpDown_ActuallyPay";
            this.numericUpDown_ActuallyPay.Size = new System.Drawing.Size(130, 29);
            this.numericUpDown_ActuallyPay.TabIndex = 1;
            // 
            // AccountingPaymentFinish
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::LawtechPTSystemByFirm.Properties.Resources.bg_01;
            this.CancelButton = this.but_Cancel;
            this.ClientSize = new System.Drawing.Size(473, 539);
            this.Controls.Add(this.numericUpDown_ActuallyPay);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numericUpDown_ExchangeRate);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txt_IReceiptNo);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.comboBox_AcountingFirmKey);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.maskedTextBox_EstimatedPaymentDate);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.txt_Memo);
            this.Controls.Add(this.checkBox_IsBilling);
            this.Controls.Add(this.label42);
            this.Controls.Add(this.checkBox_IsScan);
            this.Controls.Add(this.checkBox_IsCopyFile);
            this.Controls.Add(this.txt_IMoney);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.maskedTextBox_PaymentDate);
            this.Controls.Add(this.txt_Totall);
            this.Controls.Add(this.label46);
            this.Controls.Add(this.txt_FeeSubject);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.txt_BillingNo);
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
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AccountingPaymentFinish";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "已付款";
            this.Load += new System.EventHandler(this.AccountingPaymentFinish_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AccountingPaymentFinish_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.acountingFirmTBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_Attorney)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_ExchangeRate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_ActuallyPay)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.TextBox txt_IMoney;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_PaymentDate;
        internal System.Windows.Forms.TextBox txt_Totall;
        private System.Windows.Forms.Label label46;
        private System.Windows.Forms.TextBox txt_FeeSubject;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txt_BillingNo;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_PayDueDate;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_ReciveDate;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.TextBox txt_BillCheck;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_IReceiptDate;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Button but_Cancel;
        private System.Windows.Forms.Button but_OK;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.TextBox txt_Memo;
        private System.Windows.Forms.CheckBox checkBox_IsBilling;
        private System.Windows.Forms.Label label42;
        private System.Windows.Forms.CheckBox checkBox_IsScan;
        private System.Windows.Forms.CheckBox checkBox_IsCopyFile;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_EstimatedPaymentDate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBox_AcountingFirmKey;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_IReceiptNo;
        private DataSet_Attorney dataSet_Attorney;
        private System.Windows.Forms.BindingSource acountingFirmTBindingSource;
        private LawtechPTSystemByFirm.DataSet_AttorneyTableAdapters.AcountingFirmTTableAdapter acountingFirmTTableAdapter;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numericUpDown_ExchangeRate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDown_ActuallyPay;
    }
}