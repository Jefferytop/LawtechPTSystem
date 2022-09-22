namespace LawtechPTSystemByFirm.EditForm
{
    partial class EditOfficeProperty
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditOfficeProperty));
            this.qS_DataSet = new LawtechPTSystemByFirm.QS_DataSet();
            this.dataSet_Drop = new LawtechPTSystemByFirm.DataSet_Drop();
            this.workerTAllBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.workerTAllTableAdapter = new LawtechPTSystemByFirm.QS_DataSetTableAdapters.WorkerTAllTableAdapter();
            this.moneyTBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.moneyTTableAdapter = new LawtechPTSystemByFirm.DataSet_DropTableAdapters.MoneyTTableAdapter();
            this.numericUpDown_TotalNT = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_Amount = new System.Windows.Forms.NumericUpDown();
            this.cb_Status = new System.Windows.Forms.ComboBox();
            this.cb_Owner = new System.Windows.Forms.ComboBox();
            this.cb_Location = new System.Windows.Forms.ComboBox();
            this.numericUpDown_ExchangeRate = new System.Windows.Forms.NumericUpDown();
            this.cb_Currency = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.but_Cancel = new System.Windows.Forms.Button();
            this.but_OK = new System.Windows.Forms.Button();
            this.txt_Parts = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_FunctionDescription = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txt_Specifications = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txt_WarrantyTime = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txt_Memo = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_InvoiceNumber = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.mask_BuyDate = new System.Windows.Forms.MaskedTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.mask_CreateDate = new System.Windows.Forms.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_OfficePropertyName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_OfficePropertyNo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox_OfficePropertyType = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.comboBox_Unit = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.qS_DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_Drop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.workerTAllBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.moneyTBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_TotalNT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Amount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_ExchangeRate)).BeginInit();
            this.SuspendLayout();
            // 
            // qS_DataSet
            // 
            this.qS_DataSet.DataSetName = "QS_DataSet";
            this.qS_DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // dataSet_Drop
            // 
            this.dataSet_Drop.DataSetName = "DataSet_Drop";
            this.dataSet_Drop.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // workerTAllBindingSource
            // 
            this.workerTAllBindingSource.DataMember = "WorkerTAll";
            this.workerTAllBindingSource.DataSource = this.qS_DataSet;
            // 
            // workerTAllTableAdapter
            // 
            this.workerTAllTableAdapter.ClearBeforeFill = true;
            // 
            // moneyTBindingSource
            // 
            this.moneyTBindingSource.DataMember = "MoneyT";
            this.moneyTBindingSource.DataSource = this.dataSet_Drop;
            // 
            // moneyTTableAdapter
            // 
            this.moneyTTableAdapter.ClearBeforeFill = true;
            // 
            // numericUpDown_TotalNT
            // 
            this.numericUpDown_TotalNT.BackColor = System.Drawing.Color.White;
            this.numericUpDown_TotalNT.DecimalPlaces = 2;
            this.numericUpDown_TotalNT.Enabled = false;
            this.numericUpDown_TotalNT.Location = new System.Drawing.Point(276, 243);
            this.numericUpDown_TotalNT.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericUpDown_TotalNT.Name = "numericUpDown_TotalNT";
            this.numericUpDown_TotalNT.ReadOnly = true;
            this.numericUpDown_TotalNT.Size = new System.Drawing.Size(100, 29);
            this.numericUpDown_TotalNT.TabIndex = 11;
            // 
            // numericUpDown_Amount
            // 
            this.numericUpDown_Amount.DecimalPlaces = 2;
            this.numericUpDown_Amount.Location = new System.Drawing.Point(86, 245);
            this.numericUpDown_Amount.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericUpDown_Amount.Name = "numericUpDown_Amount";
            this.numericUpDown_Amount.Size = new System.Drawing.Size(100, 29);
            this.numericUpDown_Amount.TabIndex = 10;
            this.numericUpDown_Amount.ValueChanged += new System.EventHandler(this.numericUpDown_ExchangeRate_ValueChanged);
            // 
            // cb_Status
            // 
            this.cb_Status.Font = new System.Drawing.Font("微軟正黑體", 14F);
            this.cb_Status.FormattingEnabled = true;
            this.cb_Status.Items.AddRange(new object[] {
            "使用中★ ",
            "列管中☆ ",
            "報修中◎",
            "報廢×"});
            this.cb_Status.Location = new System.Drawing.Point(86, 340);
            this.cb_Status.Name = "cb_Status";
            this.cb_Status.Size = new System.Drawing.Size(290, 32);
            this.cb_Status.TabIndex = 14;
            // 
            // cb_Owner
            // 
            this.cb_Owner.DataSource = this.workerTAllBindingSource;
            this.cb_Owner.DisplayMember = "Name";
            this.cb_Owner.Font = new System.Drawing.Font("微軟正黑體", 14F);
            this.cb_Owner.FormattingEnabled = true;
            this.cb_Owner.Location = new System.Drawing.Point(86, 308);
            this.cb_Owner.Name = "cb_Owner";
            this.cb_Owner.Size = new System.Drawing.Size(290, 32);
            this.cb_Owner.TabIndex = 13;
            this.cb_Owner.ValueMember = "Name";
            // 
            // cb_Location
            // 
            this.cb_Location.Font = new System.Drawing.Font("微軟正黑體", 14F);
            this.cb_Location.FormattingEnabled = true;
            this.cb_Location.Items.AddRange(new object[] {
            "中和",
            "新店",
            "新竹"});
            this.cb_Location.Location = new System.Drawing.Point(86, 276);
            this.cb_Location.Name = "cb_Location";
            this.cb_Location.Size = new System.Drawing.Size(290, 32);
            this.cb_Location.TabIndex = 12;
            // 
            // numericUpDown_ExchangeRate
            // 
            this.numericUpDown_ExchangeRate.DecimalPlaces = 2;
            this.numericUpDown_ExchangeRate.Location = new System.Drawing.Point(276, 210);
            this.numericUpDown_ExchangeRate.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDown_ExchangeRate.Name = "numericUpDown_ExchangeRate";
            this.numericUpDown_ExchangeRate.Size = new System.Drawing.Size(100, 29);
            this.numericUpDown_ExchangeRate.TabIndex = 9;
            this.numericUpDown_ExchangeRate.ValueChanged += new System.EventHandler(this.numericUpDown_ExchangeRate_ValueChanged);
            // 
            // cb_Currency
            // 
            this.cb_Currency.DataSource = this.moneyTBindingSource;
            this.cb_Currency.DisplayMember = "MoneyName";
            this.cb_Currency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Currency.Font = new System.Drawing.Font("微軟正黑體", 14F);
            this.cb_Currency.FormattingEnabled = true;
            this.cb_Currency.Location = new System.Drawing.Point(86, 210);
            this.cb_Currency.Name = "cb_Currency";
            this.cb_Currency.Size = new System.Drawing.Size(100, 32);
            this.cb_Currency.TabIndex = 8;
            this.cb_Currency.ValueMember = "MoneyKey";
            this.cb_Currency.SelectedIndexChanged += new System.EventHandler(this.cb_Currency_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(203, 214);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 20);
            this.label2.TabIndex = 105;
            this.label2.Text = "當時匯率";
            // 
            // but_Cancel
            // 
            this.but_Cancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.but_Cancel.BackgroundImage = global::LawtechPTSystemByFirm.Properties.Resources.btnCancel;
            this.but_Cancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.but_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.but_Cancel.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.but_Cancel.Location = new System.Drawing.Point(432, 377);
            this.but_Cancel.Name = "but_Cancel";
            this.but_Cancel.Size = new System.Drawing.Size(100, 32);
            this.but_Cancel.TabIndex = 20;
            this.but_Cancel.Text = "取消";
            this.but_Cancel.UseVisualStyleBackColor = true;
            this.but_Cancel.Click += new System.EventHandler(this.but_Cancel_Click);
            // 
            // but_OK
            // 
            this.but_OK.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.but_OK.BackgroundImage = global::LawtechPTSystemByFirm.Properties.Resources.btnComfirm;
            this.but_OK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.but_OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.but_OK.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.but_OK.Location = new System.Drawing.Point(326, 377);
            this.but_OK.Name = "but_OK";
            this.but_OK.Size = new System.Drawing.Size(100, 32);
            this.but_OK.TabIndex = 19;
            this.but_OK.Text = "確定";
            this.but_OK.UseVisualStyleBackColor = true;
            this.but_OK.Click += new System.EventHandler(this.but_OK_Click);
            // 
            // txt_Parts
            // 
            this.txt_Parts.BackColor = System.Drawing.Color.White;
            this.txt_Parts.Location = new System.Drawing.Point(459, 12);
            this.txt_Parts.Multiline = true;
            this.txt_Parts.Name = "txt_Parts";
            this.txt_Parts.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_Parts.Size = new System.Drawing.Size(381, 34);
            this.txt_Parts.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Location = new System.Drawing.Point(404, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 20);
            this.label8.TabIndex = 101;
            this.label8.Text = "配   件";
            // 
            // txt_FunctionDescription
            // 
            this.txt_FunctionDescription.BackColor = System.Drawing.Color.White;
            this.txt_FunctionDescription.Location = new System.Drawing.Point(459, 177);
            this.txt_FunctionDescription.Multiline = true;
            this.txt_FunctionDescription.Name = "txt_FunctionDescription";
            this.txt_FunctionDescription.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_FunctionDescription.Size = new System.Drawing.Size(381, 120);
            this.txt_FunctionDescription.TabIndex = 17;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.Transparent;
            this.label17.Location = new System.Drawing.Point(385, 181);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(73, 20);
            this.label17.TabIndex = 99;
            this.label17.Text = "功能說明";
            // 
            // txt_Specifications
            // 
            this.txt_Specifications.BackColor = System.Drawing.Color.White;
            this.txt_Specifications.Location = new System.Drawing.Point(459, 52);
            this.txt_Specifications.Multiline = true;
            this.txt_Specifications.Name = "txt_Specifications";
            this.txt_Specifications.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_Specifications.Size = new System.Drawing.Size(381, 119);
            this.txt_Specifications.TabIndex = 16;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Location = new System.Drawing.Point(384, 56);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(73, 20);
            this.label16.TabIndex = 97;
            this.label16.Text = "詳細規格";
            // 
            // txt_WarrantyTime
            // 
            this.txt_WarrantyTime.BackColor = System.Drawing.Color.White;
            this.txt_WarrantyTime.Location = new System.Drawing.Point(276, 177);
            this.txt_WarrantyTime.Name = "txt_WarrantyTime";
            this.txt_WarrantyTime.Size = new System.Drawing.Size(100, 29);
            this.txt_WarrantyTime.TabIndex = 7;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Location = new System.Drawing.Point(12, 345);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(73, 20);
            this.label15.TabIndex = 95;
            this.label15.Text = "目前狀態";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Location = new System.Drawing.Point(214, 248);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(63, 20);
            this.label14.TabIndex = 94;
            this.label14.Text = "合計NT";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Location = new System.Drawing.Point(36, 216);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(49, 20);
            this.label13.TabIndex = 93;
            this.label13.Text = "幣  別";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Location = new System.Drawing.Point(12, 250);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(73, 20);
            this.label12.TabIndex = 92;
            this.label12.Text = "購買金額";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Location = new System.Drawing.Point(28, 314);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(57, 20);
            this.label11.TabIndex = 91;
            this.label11.Text = "保管人";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Location = new System.Drawing.Point(28, 281);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(57, 20);
            this.label10.TabIndex = 90;
            this.label10.Text = "所在地";
            // 
            // txt_Memo
            // 
            this.txt_Memo.BackColor = System.Drawing.Color.White;
            this.txt_Memo.Location = new System.Drawing.Point(459, 303);
            this.txt_Memo.Multiline = true;
            this.txt_Memo.Name = "txt_Memo";
            this.txt_Memo.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_Memo.Size = new System.Drawing.Size(381, 64);
            this.txt_Memo.TabIndex = 18;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Location = new System.Drawing.Point(404, 305);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 20);
            this.label9.TabIndex = 88;
            this.label9.Text = "備   註";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(203, 181);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 20);
            this.label7.TabIndex = 87;
            this.label7.Text = "保固時間";
            // 
            // txt_InvoiceNumber
            // 
            this.txt_InvoiceNumber.BackColor = System.Drawing.Color.White;
            this.txt_InvoiceNumber.Location = new System.Drawing.Point(86, 177);
            this.txt_InvoiceNumber.Name = "txt_InvoiceNumber";
            this.txt_InvoiceNumber.Size = new System.Drawing.Size(100, 29);
            this.txt_InvoiceNumber.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(12, 183);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 20);
            this.label6.TabIndex = 85;
            this.label6.Text = "發票號碼";
            // 
            // mask_BuyDate
            // 
            this.mask_BuyDate.BackColor = System.Drawing.Color.White;
            this.mask_BuyDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.mask_BuyDate.Location = new System.Drawing.Point(276, 144);
            this.mask_BuyDate.Mask = "0000/00/00";
            this.mask_BuyDate.Name = "mask_BuyDate";
            this.mask_BuyDate.Size = new System.Drawing.Size(100, 29);
            this.mask_BuyDate.TabIndex = 5;
            this.mask_BuyDate.ValidatingType = typeof(System.DateTime);
            this.mask_BuyDate.DoubleClick += new System.EventHandler(this.mask_CreateDate_DoubleClick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(202, 150);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 20);
            this.label5.TabIndex = 83;
            this.label5.Text = "購買日期";
            // 
            // mask_CreateDate
            // 
            this.mask_CreateDate.BackColor = System.Drawing.Color.White;
            this.mask_CreateDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.mask_CreateDate.Location = new System.Drawing.Point(86, 144);
            this.mask_CreateDate.Mask = "0000/00/00";
            this.mask_CreateDate.Name = "mask_CreateDate";
            this.mask_CreateDate.Size = new System.Drawing.Size(100, 29);
            this.mask_CreateDate.TabIndex = 4;
            this.mask_CreateDate.ValidatingType = typeof(System.DateTime);
            this.mask_CreateDate.DoubleClick += new System.EventHandler(this.mask_CreateDate_DoubleClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(12, 150);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 20);
            this.label4.TabIndex = 81;
            this.label4.Text = "建檔日期";
            // 
            // txt_OfficePropertyName
            // 
            this.txt_OfficePropertyName.BackColor = System.Drawing.Color.White;
            this.txt_OfficePropertyName.Location = new System.Drawing.Point(86, 45);
            this.txt_OfficePropertyName.Name = "txt_OfficePropertyName";
            this.txt_OfficePropertyName.Size = new System.Drawing.Size(290, 29);
            this.txt_OfficePropertyName.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(12, 50);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 20);
            this.label3.TabIndex = 79;
            this.label3.Text = "品項名稱";
            // 
            // txt_OfficePropertyNo
            // 
            this.txt_OfficePropertyNo.BackColor = System.Drawing.Color.White;
            this.txt_OfficePropertyNo.Location = new System.Drawing.Point(86, 12);
            this.txt_OfficePropertyNo.Name = "txt_OfficePropertyNo";
            this.txt_OfficePropertyNo.Size = new System.Drawing.Size(290, 29);
            this.txt_OfficePropertyNo.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 20);
            this.label1.TabIndex = 77;
            this.label1.Text = "財產編號";
            // 
            // comboBox_OfficePropertyType
            // 
            this.comboBox_OfficePropertyType.Font = new System.Drawing.Font("微軟正黑體", 14F);
            this.comboBox_OfficePropertyType.FormattingEnabled = true;
            this.comboBox_OfficePropertyType.Items.AddRange(new object[] {
            "電腦設備",
            "辦公設備",
            "雜項設備",
            "運輸設備"});
            this.comboBox_OfficePropertyType.Location = new System.Drawing.Point(86, 78);
            this.comboBox_OfficePropertyType.Name = "comboBox_OfficePropertyType";
            this.comboBox_OfficePropertyType.Size = new System.Drawing.Size(290, 32);
            this.comboBox_OfficePropertyType.TabIndex = 2;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.BackColor = System.Drawing.Color.Transparent;
            this.label19.Location = new System.Drawing.Point(12, 83);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(73, 20);
            this.label19.TabIndex = 115;
            this.label19.Text = "品項類型";
            // 
            // comboBox_Unit
            // 
            this.comboBox_Unit.Font = new System.Drawing.Font("微軟正黑體", 14F);
            this.comboBox_Unit.FormattingEnabled = true;
            this.comboBox_Unit.Items.AddRange(new object[] {
            "眾律國際法律事務所",
            "眾律國際專利商標事務所"});
            this.comboBox_Unit.Location = new System.Drawing.Point(86, 111);
            this.comboBox_Unit.Name = "comboBox_Unit";
            this.comboBox_Unit.Size = new System.Drawing.Size(290, 32);
            this.comboBox_Unit.TabIndex = 3;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.Color.Transparent;
            this.label18.Location = new System.Drawing.Point(12, 116);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(73, 20);
            this.label18.TabIndex = 113;
            this.label18.Text = "所屬單位";
            // 
            // EditOfficeProperty
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::LawtechPTSystemByFirm.Properties.Resources.EditForm_bg;
            this.CancelButton = this.but_Cancel;
            this.ClientSize = new System.Drawing.Size(858, 421);
            this.Controls.Add(this.comboBox_OfficePropertyType);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.comboBox_Unit);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.numericUpDown_TotalNT);
            this.Controls.Add(this.numericUpDown_Amount);
            this.Controls.Add(this.cb_Status);
            this.Controls.Add(this.cb_Owner);
            this.Controls.Add(this.cb_Location);
            this.Controls.Add(this.numericUpDown_ExchangeRate);
            this.Controls.Add(this.cb_Currency);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.but_Cancel);
            this.Controls.Add(this.but_OK);
            this.Controls.Add(this.txt_Parts);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txt_FunctionDescription);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.txt_Specifications);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.txt_WarrantyTime);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txt_Memo);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txt_InvoiceNumber);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.mask_BuyDate);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.mask_CreateDate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_OfficePropertyName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_OfficePropertyNo);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditOfficeProperty";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "編輯財產清單";
            this.Load += new System.EventHandler(this.EditOfficeProperty_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EditOfficeProperty_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.qS_DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_Drop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.workerTAllBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.moneyTBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_TotalNT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Amount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_ExchangeRate)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private QS_DataSet qS_DataSet;
        private DataSet_Drop dataSet_Drop;
        private System.Windows.Forms.BindingSource workerTAllBindingSource;
        private LawtechPTSystemByFirm.QS_DataSetTableAdapters.WorkerTAllTableAdapter workerTAllTableAdapter;
        private System.Windows.Forms.BindingSource moneyTBindingSource;
        private LawtechPTSystemByFirm.DataSet_DropTableAdapters.MoneyTTableAdapter moneyTTableAdapter;
        private System.Windows.Forms.NumericUpDown numericUpDown_TotalNT;
        private System.Windows.Forms.NumericUpDown numericUpDown_Amount;
        private System.Windows.Forms.ComboBox cb_Status;
        private System.Windows.Forms.ComboBox cb_Owner;
        private System.Windows.Forms.ComboBox cb_Location;
        private System.Windows.Forms.NumericUpDown numericUpDown_ExchangeRate;
        private System.Windows.Forms.ComboBox cb_Currency;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button but_Cancel;
        private System.Windows.Forms.Button but_OK;
        private System.Windows.Forms.TextBox txt_Parts;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_FunctionDescription;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txt_Specifications;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txt_WarrantyTime;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txt_Memo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_InvoiceNumber;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.MaskedTextBox mask_BuyDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.MaskedTextBox mask_CreateDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_OfficePropertyName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_OfficePropertyNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox_OfficePropertyType;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.ComboBox comboBox_Unit;
        private System.Windows.Forms.Label label18;
    }
}