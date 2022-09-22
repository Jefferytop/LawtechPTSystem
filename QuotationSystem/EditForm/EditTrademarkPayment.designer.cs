﻿namespace LawtechPTSystem.EditForm
{
    partial class EditTrademarkPayment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditTrademarkPayment));
            this.attorneyTBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet_Drop = new LawtechPTSystem.DataSet_Drop();
            this.payKindBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.workerTAllBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.qS_DataSet = new LawtechPTSystem.QS_DataSet();
            this.but_Cancel = new System.Windows.Forms.Button();
            this.but_OK = new System.Windows.Forms.Button();
            this.feePhaseTByTMBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.moneyTBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.feePhaseTByTMTableAdapter = new LawtechPTSystem.DataSet_DropTableAdapters.FeePhaseTByTMTableAdapter();
            this.attorneyTTableAdapter = new LawtechPTSystem.DataSet_DropTableAdapters.AttorneyTTableAdapter();
            this.workerTAllTableAdapter = new LawtechPTSystem.QS_DataSetTableAdapters.WorkerTAllTableAdapter();
            this.payKindTableAdapter = new LawtechPTSystem.DataSet_DropTableAdapters.PayKindTableAdapter();
            this.label12 = new System.Windows.Forms.Label();
            this.txt_SingcCode = new System.Windows.Forms.TextBox();
            this.but_SingOff = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDown_ExchangeRate = new System.Windows.Forms.NumericUpDown();
            this.comboBox_Attormey = new System.Windows.Forms.ComboBox();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolStripMenuItem_All2 = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_CurrentCountry2 = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox_PayKind = new System.Windows.Forms.ComboBox();
            this.comboBox_FClientTransactor = new System.Windows.Forms.ComboBox();
            this.txt_FeeSubject = new System.Windows.Forms.ComboBox();
            this.feePhaseItemsTBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label15 = new System.Windows.Forms.Label();
            this.txt_Remark = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label43 = new System.Windows.Forms.Label();
            this.comboBox_FeePhase = new System.Windows.Forms.ComboBox();
            this.txt_Totall = new System.Windows.Forms.TextBox();
            this.label46 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.maskedTextBox_PayDueDate = new System.Windows.Forms.MaskedTextBox();
            this.contextMenuStrip_ForDate = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolStripMenuItem_Calculation = new System.Windows.Forms.ToolStripMenuItem();
            this.label28 = new System.Windows.Forms.Label();
            this.maskedTextBox_ReciveDate = new System.Windows.Forms.MaskedTextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.txt_OtherFee = new System.Windows.Forms.TextBox();
            this.txt_GovFee = new System.Windows.Forms.TextBox();
            this.txt_IServiceFee = new System.Windows.Forms.TextBox();
            this.maskedTextBox_IReceiptDate = new System.Windows.Forms.MaskedTextBox();
            this.txt_IReceiptNo = new System.Windows.Forms.TextBox();
            this.label34 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.comboBox_IMoney = new System.Windows.Forms.ComboBox();
            this.label52 = new System.Windows.Forms.Label();
            this.label54 = new System.Windows.Forms.Label();
            this.label55 = new System.Windows.Forms.Label();
            this.label57 = new System.Windows.Forms.Label();
            this.moneyTTableAdapter1 = new LawtechPTSystem.DataSet_DropTableAdapters.MoneyTTableAdapter();
            this.checkBox_All = new System.Windows.Forms.CheckBox();
            this.feePhaseItemsTTableAdapter = new LawtechPTSystem.DataSet_DropTableAdapters.FeePhaseItemsTTableAdapter();
            this.txt_SingCodeStatus = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.attorneyTBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_Drop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.payKindBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.workerTAllBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qS_DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.feePhaseTByTMBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.moneyTBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_ExchangeRate)).BeginInit();
            this.contextMenuStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.feePhaseItemsTBindingSource)).BeginInit();
            this.contextMenuStrip_ForDate.SuspendLayout();
            this.SuspendLayout();
            // 
            // attorneyTBindingSource
            // 
            this.attorneyTBindingSource.DataMember = "AttorneyT";
            this.attorneyTBindingSource.DataSource = this.dataSet_Drop;
            // 
            // dataSet_Drop
            // 
            this.dataSet_Drop.DataSetName = "DataSet_Drop";
            this.dataSet_Drop.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // payKindBindingSource
            // 
            this.payKindBindingSource.DataMember = "PayKind";
            this.payKindBindingSource.DataSource = this.dataSet_Drop;
            // 
            // workerTAllBindingSource
            // 
            this.workerTAllBindingSource.DataMember = "WorkerTAll";
            this.workerTAllBindingSource.DataSource = this.qS_DataSet;
            // 
            // qS_DataSet
            // 
            this.qS_DataSet.DataSetName = "QS_DataSet";
            this.qS_DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // but_Cancel
            // 
            this.but_Cancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.but_Cancel.BackgroundImage = global::LawtechPTSystem.Properties.Resources.btnCancel;
            this.but_Cancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.but_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.but_Cancel.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.but_Cancel.Location = new System.Drawing.Point(347, 394);
            this.but_Cancel.Name = "but_Cancel";
            this.but_Cancel.Size = new System.Drawing.Size(100, 32);
            this.but_Cancel.TabIndex = 18;
            this.but_Cancel.Text = "取消";
            this.but_Cancel.UseVisualStyleBackColor = true;
            this.but_Cancel.Click += new System.EventHandler(this.but_Cancel_Click);
            // 
            // but_OK
            // 
            this.but_OK.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.but_OK.BackgroundImage = global::LawtechPTSystem.Properties.Resources.btnComfirm;
            this.but_OK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.but_OK.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.but_OK.Location = new System.Drawing.Point(241, 394);
            this.but_OK.Name = "but_OK";
            this.but_OK.Size = new System.Drawing.Size(100, 32);
            this.but_OK.TabIndex = 17;
            this.but_OK.Text = "確定";
            this.but_OK.UseVisualStyleBackColor = true;
            this.but_OK.Click += new System.EventHandler(this.but_OK_Click);
            // 
            // feePhaseTByTMBindingSource
            // 
            this.feePhaseTByTMBindingSource.DataMember = "FeePhaseTByTM";
            this.feePhaseTByTMBindingSource.DataSource = this.dataSet_Drop;
            // 
            // moneyTBindingSource
            // 
            this.moneyTBindingSource.DataMember = "MoneyT";
            this.moneyTBindingSource.DataSource = this.dataSet_Drop;
            // 
            // feePhaseTByTMTableAdapter
            // 
            this.feePhaseTByTMTableAdapter.ClearBeforeFill = true;
            // 
            // attorneyTTableAdapter
            // 
            this.attorneyTTableAdapter.ClearBeforeFill = true;
            // 
            // workerTAllTableAdapter
            // 
            this.workerTAllTableAdapter.ClearBeforeFill = true;
            // 
            // payKindTableAdapter
            // 
            this.payKindTableAdapter.ClearBeforeFill = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Location = new System.Drawing.Point(31, 168);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(73, 20);
            this.label12.TabIndex = 561;
            this.label12.Text = "主管簽核";
            // 
            // txt_SingcCode
            // 
            this.txt_SingcCode.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.txt_SingcCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_SingcCode.ForeColor = System.Drawing.Color.Blue;
            this.txt_SingcCode.Location = new System.Drawing.Point(105, 164);
            this.txt_SingcCode.Margin = new System.Windows.Forms.Padding(1);
            this.txt_SingcCode.Name = "txt_SingcCode";
            this.txt_SingcCode.ReadOnly = true;
            this.txt_SingcCode.Size = new System.Drawing.Size(337, 29);
            this.txt_SingcCode.TabIndex = 9;
            // 
            // but_SingOff
            // 
            this.but_SingOff.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.but_SingOff.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.but_SingOff.Image = global::LawtechPTSystem.Properties.Resources.btnGeen;
            this.but_SingOff.Location = new System.Drawing.Point(6, 164);
            this.but_SingOff.Name = "but_SingOff";
            this.but_SingOff.Size = new System.Drawing.Size(98, 28);
            this.but_SingOff.TabIndex = 8;
            this.but_SingOff.Text = "簽  核";
            this.but_SingOff.UseVisualStyleBackColor = true;
            this.but_SingOff.Visible = false;
            this.but_SingOff.Click += new System.EventHandler(this.but_SingOff_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(245, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 20);
            this.label4.TabIndex = 560;
            this.label4.Text = "當時匯率";
            this.label4.Visible = false;
            // 
            // numericUpDown_ExchangeRate
            // 
            this.numericUpDown_ExchangeRate.DecimalPlaces = 2;
            this.numericUpDown_ExchangeRate.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDown_ExchangeRate.Location = new System.Drawing.Point(319, 103);
            this.numericUpDown_ExchangeRate.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericUpDown_ExchangeRate.Name = "numericUpDown_ExchangeRate";
            this.numericUpDown_ExchangeRate.Size = new System.Drawing.Size(123, 29);
            this.numericUpDown_ExchangeRate.TabIndex = 6;
            this.numericUpDown_ExchangeRate.Visible = false;
            // 
            // comboBox_Attormey
            // 
            this.comboBox_Attormey.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBox_Attormey.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox_Attormey.ContextMenuStrip = this.contextMenuStrip2;
            this.comboBox_Attormey.DataSource = this.attorneyTBindingSource;
            this.comboBox_Attormey.DisplayMember = "AttorneyFirm";
            this.comboBox_Attormey.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.comboBox_Attormey.FormattingEnabled = true;
            this.comboBox_Attormey.Location = new System.Drawing.Point(319, 73);
            this.comboBox_Attormey.Margin = new System.Windows.Forms.Padding(1);
            this.comboBox_Attormey.Name = "comboBox_Attormey";
            this.comboBox_Attormey.Size = new System.Drawing.Size(359, 28);
            this.comboBox_Attormey.TabIndex = 3;
            this.comboBox_Attormey.ValueMember = "AttorneyKey";
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_All2,
            this.ToolStripMenuItem_CurrentCountry2});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(159, 48);
            this.contextMenuStrip2.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuStrip2_ItemClicked);
            // 
            // ToolStripMenuItem_All2
            // 
            this.ToolStripMenuItem_All2.Name = "ToolStripMenuItem_All2";
            this.ToolStripMenuItem_All2.Size = new System.Drawing.Size(158, 22);
            this.ToolStripMenuItem_All2.Text = "所有事務所";
            // 
            // ToolStripMenuItem_CurrentCountry2
            // 
            this.ToolStripMenuItem_CurrentCountry2.Name = "ToolStripMenuItem_CurrentCountry2";
            this.ToolStripMenuItem_CurrentCountry2.Size = new System.Drawing.Size(158, 22);
            this.ToolStripMenuItem_CurrentCountry2.Text = "目前國別事務所";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(260, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 20);
            this.label1.TabIndex = 559;
            this.label1.Text = "受款人";
            // 
            // comboBox_PayKind
            // 
            this.comboBox_PayKind.DataSource = this.payKindBindingSource;
            this.comboBox_PayKind.DisplayMember = "String";
            this.comboBox_PayKind.Font = new System.Drawing.Font("微軟正黑體", 14F);
            this.comboBox_PayKind.FormattingEnabled = true;
            this.comboBox_PayKind.Location = new System.Drawing.Point(319, 225);
            this.comboBox_PayKind.Margin = new System.Windows.Forms.Padding(1);
            this.comboBox_PayKind.Name = "comboBox_PayKind";
            this.comboBox_PayKind.Size = new System.Drawing.Size(359, 32);
            this.comboBox_PayKind.TabIndex = 15;
            this.comboBox_PayKind.ValueMember = "String";
            // 
            // comboBox_FClientTransactor
            // 
            this.comboBox_FClientTransactor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBox_FClientTransactor.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox_FClientTransactor.DataSource = this.workerTAllBindingSource;
            this.comboBox_FClientTransactor.DisplayMember = "Name";
            this.comboBox_FClientTransactor.FormattingEnabled = true;
            this.comboBox_FClientTransactor.Location = new System.Drawing.Point(105, 73);
            this.comboBox_FClientTransactor.Margin = new System.Windows.Forms.Padding(1);
            this.comboBox_FClientTransactor.Name = "comboBox_FClientTransactor";
            this.comboBox_FClientTransactor.Size = new System.Drawing.Size(130, 28);
            this.comboBox_FClientTransactor.TabIndex = 2;
            this.comboBox_FClientTransactor.ValueMember = "WorkerKey";
            // 
            // txt_FeeSubject
            // 
            this.txt_FeeSubject.DataSource = this.feePhaseItemsTBindingSource;
            this.txt_FeeSubject.DisplayMember = "FeePhaseItem";
            this.txt_FeeSubject.ForeColor = System.Drawing.Color.Blue;
            this.txt_FeeSubject.ImeMode = System.Windows.Forms.ImeMode.Close;
            this.txt_FeeSubject.Location = new System.Drawing.Point(105, 42);
            this.txt_FeeSubject.Margin = new System.Windows.Forms.Padding(1);
            this.txt_FeeSubject.Name = "txt_FeeSubject";
            this.txt_FeeSubject.Size = new System.Drawing.Size(573, 28);
            this.txt_FeeSubject.TabIndex = 1;
            this.txt_FeeSubject.ValueMember = "FeePhaseItem";
            // 
            // feePhaseItemsTBindingSource
            // 
            this.feePhaseItemsTBindingSource.DataMember = "FeePhaseItemsT";
            this.feePhaseItemsTBindingSource.DataSource = this.dataSet_Drop;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Location = new System.Drawing.Point(31, 47);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(73, 20);
            this.label15.TabIndex = 553;
            this.label15.Text = "費用內容";
            // 
            // txt_Remark
            // 
            this.txt_Remark.BackColor = System.Drawing.Color.White;
            this.txt_Remark.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txt_Remark.Location = new System.Drawing.Point(105, 259);
            this.txt_Remark.Margin = new System.Windows.Forms.Padding(1);
            this.txt_Remark.Multiline = true;
            this.txt_Remark.Name = "txt_Remark";
            this.txt_Remark.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_Remark.Size = new System.Drawing.Size(573, 124);
            this.txt_Remark.TabIndex = 16;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.Color.Transparent;
            this.label18.Location = new System.Drawing.Point(31, 19);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(73, 20);
            this.label18.TabIndex = 552;
            this.label18.Text = "費用種類";
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.BackColor = System.Drawing.Color.Transparent;
            this.label43.Location = new System.Drawing.Point(55, 283);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(49, 20);
            this.label43.TabIndex = 558;
            this.label43.Text = "備  註";
            // 
            // comboBox_FeePhase
            // 
            this.comboBox_FeePhase.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBox_FeePhase.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox_FeePhase.DataSource = this.feePhaseTByTMBindingSource;
            this.comboBox_FeePhase.DisplayMember = "FeePhase";
            this.comboBox_FeePhase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_FeePhase.FormattingEnabled = true;
            this.comboBox_FeePhase.Location = new System.Drawing.Point(105, 12);
            this.comboBox_FeePhase.Margin = new System.Windows.Forms.Padding(1);
            this.comboBox_FeePhase.Name = "comboBox_FeePhase";
            this.comboBox_FeePhase.Size = new System.Drawing.Size(573, 28);
            this.comboBox_FeePhase.TabIndex = 0;
            this.comboBox_FeePhase.ValueMember = "FeePhaseID";
            this.comboBox_FeePhase.SelectedIndexChanged += new System.EventHandler(this.comboBox_FeePhase_SelectedIndexChanged);
            // 
            // txt_Totall
            // 
            this.txt_Totall.BackColor = System.Drawing.Color.White;
            this.txt_Totall.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold);
            this.txt_Totall.ForeColor = System.Drawing.Color.MediumBlue;
            this.txt_Totall.Location = new System.Drawing.Point(525, 164);
            this.txt_Totall.Margin = new System.Windows.Forms.Padding(1);
            this.txt_Totall.Name = "txt_Totall";
            this.txt_Totall.ReadOnly = true;
            this.txt_Totall.Size = new System.Drawing.Size(153, 29);
            this.txt_Totall.TabIndex = 10;
            this.txt_Totall.Text = "0";
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.BackColor = System.Drawing.Color.Transparent;
            this.label46.Location = new System.Drawing.Point(451, 168);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(73, 20);
            this.label46.TabIndex = 549;
            this.label46.Text = "金額合計";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.BackColor = System.Drawing.Color.Transparent;
            this.label29.Location = new System.Drawing.Point(244, 229);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(73, 20);
            this.label29.TabIndex = 557;
            this.label29.Text = "付款形式";
            // 
            // maskedTextBox_PayDueDate
            // 
            this.maskedTextBox_PayDueDate.ContextMenuStrip = this.contextMenuStrip_ForDate;
            this.maskedTextBox_PayDueDate.ForeColor = System.Drawing.Color.Green;
            this.maskedTextBox_PayDueDate.ImeMode = System.Windows.Forms.ImeMode.Close;
            this.maskedTextBox_PayDueDate.Location = new System.Drawing.Point(319, 195);
            this.maskedTextBox_PayDueDate.Margin = new System.Windows.Forms.Padding(1);
            this.maskedTextBox_PayDueDate.Mask = "0000/00/00";
            this.maskedTextBox_PayDueDate.Name = "maskedTextBox_PayDueDate";
            this.maskedTextBox_PayDueDate.Size = new System.Drawing.Size(123, 29);
            this.maskedTextBox_PayDueDate.TabIndex = 12;
            this.maskedTextBox_PayDueDate.ValidatingType = typeof(System.DateTime);
            this.maskedTextBox_PayDueDate.DoubleClick += new System.EventHandler(this.maskedTextBox_ReciveDate_DoubleClick);
            this.maskedTextBox_PayDueDate.Leave += new System.EventHandler(this.maskedTextBox_ReciveDate_Leave);
            // 
            // contextMenuStrip_ForDate
            // 
            this.contextMenuStrip_ForDate.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_Calculation});
            this.contextMenuStrip_ForDate.Name = "contextMenuStrip_ForDate";
            this.contextMenuStrip_ForDate.Size = new System.Drawing.Size(123, 26);
            this.contextMenuStrip_ForDate.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuStrip_ForDate_ItemClicked);
            // 
            // ToolStripMenuItem_Calculation
            // 
            this.ToolStripMenuItem_Calculation.Name = "ToolStripMenuItem_Calculation";
            this.ToolStripMenuItem_Calculation.Size = new System.Drawing.Size(122, 22);
            this.ToolStripMenuItem_Calculation.Text = "計算日期";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.BackColor = System.Drawing.Color.Transparent;
            this.label28.Location = new System.Drawing.Point(244, 198);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(73, 20);
            this.label28.TabIndex = 556;
            this.label28.Text = "付款期限";
            // 
            // maskedTextBox_ReciveDate
            // 
            this.maskedTextBox_ReciveDate.ContextMenuStrip = this.contextMenuStrip_ForDate;
            this.maskedTextBox_ReciveDate.ForeColor = System.Drawing.Color.Green;
            this.maskedTextBox_ReciveDate.ImeMode = System.Windows.Forms.ImeMode.Close;
            this.maskedTextBox_ReciveDate.Location = new System.Drawing.Point(105, 195);
            this.maskedTextBox_ReciveDate.Margin = new System.Windows.Forms.Padding(1);
            this.maskedTextBox_ReciveDate.Mask = "0000/00/00";
            this.maskedTextBox_ReciveDate.Name = "maskedTextBox_ReciveDate";
            this.maskedTextBox_ReciveDate.Size = new System.Drawing.Size(130, 29);
            this.maskedTextBox_ReciveDate.TabIndex = 11;
            this.maskedTextBox_ReciveDate.ValidatingType = typeof(System.DateTime);
            this.maskedTextBox_ReciveDate.DoubleClick += new System.EventHandler(this.maskedTextBox_ReciveDate_DoubleClick);
            this.maskedTextBox_ReciveDate.Leave += new System.EventHandler(this.maskedTextBox_ReciveDate_Leave);
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.BackColor = System.Drawing.Color.Transparent;
            this.label27.Location = new System.Drawing.Point(31, 201);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(73, 20);
            this.label27.TabIndex = 555;
            this.label27.Text = "收件日期";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.BackColor = System.Drawing.Color.Transparent;
            this.label26.Location = new System.Drawing.Point(15, 77);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(89, 20);
            this.label26.TabIndex = 554;
            this.label26.Text = "本所承辦人";
            // 
            // txt_OtherFee
            // 
            this.txt_OtherFee.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold);
            this.txt_OtherFee.ForeColor = System.Drawing.Color.Chocolate;
            this.txt_OtherFee.ImeMode = System.Windows.Forms.ImeMode.Close;
            this.txt_OtherFee.Location = new System.Drawing.Point(525, 133);
            this.txt_OtherFee.Margin = new System.Windows.Forms.Padding(1);
            this.txt_OtherFee.Name = "txt_OtherFee";
            this.txt_OtherFee.Size = new System.Drawing.Size(153, 29);
            this.txt_OtherFee.TabIndex = 7;
            this.txt_OtherFee.Text = "0";
            this.txt_OtherFee.TextChanged += new System.EventHandler(this.txt_IServiceFee_TextChanged);
            // 
            // txt_GovFee
            // 
            this.txt_GovFee.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold);
            this.txt_GovFee.ForeColor = System.Drawing.Color.Chocolate;
            this.txt_GovFee.ImeMode = System.Windows.Forms.ImeMode.Close;
            this.txt_GovFee.Location = new System.Drawing.Point(319, 133);
            this.txt_GovFee.Margin = new System.Windows.Forms.Padding(1);
            this.txt_GovFee.Name = "txt_GovFee";
            this.txt_GovFee.Size = new System.Drawing.Size(123, 29);
            this.txt_GovFee.TabIndex = 6;
            this.txt_GovFee.Text = "0";
            this.txt_GovFee.TextChanged += new System.EventHandler(this.txt_IServiceFee_TextChanged);
            // 
            // txt_IServiceFee
            // 
            this.txt_IServiceFee.BackColor = System.Drawing.Color.White;
            this.txt_IServiceFee.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold);
            this.txt_IServiceFee.ForeColor = System.Drawing.Color.Chocolate;
            this.txt_IServiceFee.ImeMode = System.Windows.Forms.ImeMode.Close;
            this.txt_IServiceFee.Location = new System.Drawing.Point(105, 133);
            this.txt_IServiceFee.Margin = new System.Windows.Forms.Padding(1);
            this.txt_IServiceFee.Name = "txt_IServiceFee";
            this.txt_IServiceFee.Size = new System.Drawing.Size(130, 29);
            this.txt_IServiceFee.TabIndex = 5;
            this.txt_IServiceFee.Text = "0";
            this.txt_IServiceFee.TextChanged += new System.EventHandler(this.txt_IServiceFee_TextChanged);
            // 
            // maskedTextBox_IReceiptDate
            // 
            this.maskedTextBox_IReceiptDate.ContextMenuStrip = this.contextMenuStrip_ForDate;
            this.maskedTextBox_IReceiptDate.ForeColor = System.Drawing.Color.Green;
            this.maskedTextBox_IReceiptDate.ImeMode = System.Windows.Forms.ImeMode.Close;
            this.maskedTextBox_IReceiptDate.Location = new System.Drawing.Point(525, 195);
            this.maskedTextBox_IReceiptDate.Margin = new System.Windows.Forms.Padding(1);
            this.maskedTextBox_IReceiptDate.Mask = "0000/00/00";
            this.maskedTextBox_IReceiptDate.Name = "maskedTextBox_IReceiptDate";
            this.maskedTextBox_IReceiptDate.Size = new System.Drawing.Size(153, 29);
            this.maskedTextBox_IReceiptDate.TabIndex = 13;
            this.maskedTextBox_IReceiptDate.ValidatingType = typeof(System.DateTime);
            this.maskedTextBox_IReceiptDate.Visible = false;
            this.maskedTextBox_IReceiptDate.DoubleClick += new System.EventHandler(this.maskedTextBox_ReciveDate_DoubleClick);
            this.maskedTextBox_IReceiptDate.Leave += new System.EventHandler(this.maskedTextBox_ReciveDate_Leave);
            // 
            // txt_IReceiptNo
            // 
            this.txt_IReceiptNo.BackColor = System.Drawing.Color.White;
            this.txt_IReceiptNo.ImeMode = System.Windows.Forms.ImeMode.Close;
            this.txt_IReceiptNo.Location = new System.Drawing.Point(105, 226);
            this.txt_IReceiptNo.Margin = new System.Windows.Forms.Padding(1);
            this.txt_IReceiptNo.Name = "txt_IReceiptNo";
            this.txt_IReceiptNo.Size = new System.Drawing.Size(130, 29);
            this.txt_IReceiptNo.TabIndex = 14;
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.BackColor = System.Drawing.Color.Transparent;
            this.label34.Location = new System.Drawing.Point(451, 198);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(73, 20);
            this.label34.TabIndex = 551;
            this.label34.Text = "完成日期";
            this.label34.Visible = false;
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.BackColor = System.Drawing.Color.Transparent;
            this.label35.Location = new System.Drawing.Point(31, 233);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(73, 20);
            this.label35.TabIndex = 550;
            this.label35.Text = "收據號碼";
            // 
            // comboBox_IMoney
            // 
            this.comboBox_IMoney.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBox_IMoney.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox_IMoney.DataSource = this.moneyTBindingSource;
            this.comboBox_IMoney.DisplayMember = "Money";
            this.comboBox_IMoney.FormattingEnabled = true;
            this.comboBox_IMoney.ImeMode = System.Windows.Forms.ImeMode.Close;
            this.comboBox_IMoney.Location = new System.Drawing.Point(105, 103);
            this.comboBox_IMoney.Margin = new System.Windows.Forms.Padding(1);
            this.comboBox_IMoney.Name = "comboBox_IMoney";
            this.comboBox_IMoney.Size = new System.Drawing.Size(130, 28);
            this.comboBox_IMoney.TabIndex = 4;
            this.comboBox_IMoney.ValueMember = "MoneyCode";
            this.comboBox_IMoney.SelectedIndexChanged += new System.EventHandler(this.comboBox_IMoney_SelectedIndexChanged);
            // 
            // label52
            // 
            this.label52.AutoSize = true;
            this.label52.BackColor = System.Drawing.Color.Transparent;
            this.label52.Location = new System.Drawing.Point(63, 107);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(41, 20);
            this.label52.TabIndex = 548;
            this.label52.Text = "幣別";
            // 
            // label54
            // 
            this.label54.AutoSize = true;
            this.label54.BackColor = System.Drawing.Color.Transparent;
            this.label54.Location = new System.Drawing.Point(483, 137);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(41, 20);
            this.label54.TabIndex = 547;
            this.label54.Text = "雜支";
            // 
            // label55
            // 
            this.label55.AutoSize = true;
            this.label55.BackColor = System.Drawing.Color.Transparent;
            this.label55.Location = new System.Drawing.Point(276, 137);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(41, 20);
            this.label55.TabIndex = 546;
            this.label55.Text = "官費";
            // 
            // label57
            // 
            this.label57.AutoSize = true;
            this.label57.BackColor = System.Drawing.Color.Transparent;
            this.label57.Location = new System.Drawing.Point(47, 137);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(57, 20);
            this.label57.TabIndex = 545;
            this.label57.Text = "服務費";
            // 
            // moneyTTableAdapter1
            // 
            this.moneyTTableAdapter1.ClearBeforeFill = true;
            // 
            // checkBox_All
            // 
            this.checkBox_All.AutoSize = true;
            this.checkBox_All.Location = new System.Drawing.Point(594, 102);
            this.checkBox_All.Name = "checkBox_All";
            this.checkBox_All.Size = new System.Drawing.Size(47, 24);
            this.checkBox_All.TabIndex = 1090;
            this.checkBox_All.Text = "All";
            this.checkBox_All.UseVisualStyleBackColor = true;
            this.checkBox_All.Visible = false;
            // 
            // feePhaseItemsTTableAdapter
            // 
            this.feePhaseItemsTTableAdapter.ClearBeforeFill = true;
            // 
            // txt_SingCodeStatus
            // 
            this.txt_SingCodeStatus.Enabled = false;
            this.txt_SingCodeStatus.Location = new System.Drawing.Point(528, 387);
            this.txt_SingCodeStatus.Name = "txt_SingCodeStatus";
            this.txt_SingCodeStatus.Size = new System.Drawing.Size(55, 29);
            this.txt_SingCodeStatus.TabIndex = 1091;
            this.txt_SingCodeStatus.Visible = false;
            // 
            // EditTrademarkPayment
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = global::LawtechPTSystem.Properties.Resources.EditForm_bg;
            this.CancelButton = this.but_Cancel;
            this.ClientSize = new System.Drawing.Size(688, 438);
            this.Controls.Add(this.txt_SingCodeStatus);
            this.Controls.Add(this.checkBox_All);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_SingcCode);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.but_SingOff);
            this.Controls.Add(this.comboBox_PayKind);
            this.Controls.Add(this.comboBox_Attormey);
            this.Controls.Add(this.numericUpDown_ExchangeRate);
            this.Controls.Add(this.but_Cancel);
            this.Controls.Add(this.txt_Remark);
            this.Controls.Add(this.comboBox_FClientTransactor);
            this.Controls.Add(this.txt_FeeSubject);
            this.Controls.Add(this.comboBox_FeePhase);
            this.Controls.Add(this.txt_Totall);
            this.Controls.Add(this.maskedTextBox_PayDueDate);
            this.Controls.Add(this.maskedTextBox_IReceiptDate);
            this.Controls.Add(this.maskedTextBox_ReciveDate);
            this.Controls.Add(this.txt_OtherFee);
            this.Controls.Add(this.txt_GovFee);
            this.Controls.Add(this.txt_IServiceFee);
            this.Controls.Add(this.but_OK);
            this.Controls.Add(this.txt_IReceiptNo);
            this.Controls.Add(this.comboBox_IMoney);
            this.Controls.Add(this.label54);
            this.Controls.Add(this.label43);
            this.Controls.Add(this.label27);
            this.Controls.Add(this.label35);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label26);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label57);
            this.Controls.Add(this.label52);
            this.Controls.Add(this.label55);
            this.Controls.Add(this.label29);
            this.Controls.Add(this.label28);
            this.Controls.Add(this.label34);
            this.Controls.Add(this.label46);
            this.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditTrademarkPayment";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "修改付款記錄";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.EditTrademarkPayment_FormClosed);
            this.Load += new System.EventHandler(this.EditTrademarkPayment_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.EditTrademarkPayment_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.attorneyTBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_Drop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.payKindBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.workerTAllBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qS_DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.feePhaseTByTMBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.moneyTBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_ExchangeRate)).EndInit();
            this.contextMenuStrip2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.feePhaseItemsTBindingSource)).EndInit();
            this.contextMenuStrip_ForDate.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button but_Cancel;
        private System.Windows.Forms.Button but_OK;
        private DataSet_Drop dataSet_Drop;
        private System.Windows.Forms.BindingSource feePhaseTByTMBindingSource;
        private LawtechPTSystem.DataSet_DropTableAdapters.FeePhaseTByTMTableAdapter feePhaseTByTMTableAdapter;
        private System.Windows.Forms.BindingSource attorneyTBindingSource;
        private LawtechPTSystem.DataSet_DropTableAdapters.AttorneyTTableAdapter attorneyTTableAdapter;
        private QS_DataSet qS_DataSet;
        private System.Windows.Forms.BindingSource workerTAllBindingSource;
        private LawtechPTSystem.QS_DataSetTableAdapters.WorkerTAllTableAdapter workerTAllTableAdapter;
        private System.Windows.Forms.BindingSource payKindBindingSource;
        private LawtechPTSystem.DataSet_DropTableAdapters.PayKindTableAdapter payKindTableAdapter;
        private System.Windows.Forms.BindingSource moneyTBindingSource;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txt_SingcCode;
        private System.Windows.Forms.Button but_SingOff;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericUpDown_ExchangeRate;
        private System.Windows.Forms.ComboBox comboBox_Attormey;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox_PayKind;
        private System.Windows.Forms.ComboBox comboBox_FClientTransactor;
        private System.Windows.Forms.ComboBox txt_FeeSubject;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txt_Remark;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label43;
        private System.Windows.Forms.ComboBox comboBox_FeePhase;
        internal System.Windows.Forms.TextBox txt_Totall;
        private System.Windows.Forms.Label label46;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_PayDueDate;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_ReciveDate;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.TextBox txt_OtherFee;
        private System.Windows.Forms.TextBox txt_GovFee;
        private System.Windows.Forms.TextBox txt_IServiceFee;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_IReceiptDate;
        private System.Windows.Forms.TextBox txt_IReceiptNo;
        private System.Windows.Forms.Label label34;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.ComboBox comboBox_IMoney;
        private System.Windows.Forms.Label label52;
        private System.Windows.Forms.Label label54;
        private System.Windows.Forms.Label label55;
        private System.Windows.Forms.Label label57;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_ForDate;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Calculation;
        private LawtechPTSystem.DataSet_DropTableAdapters.MoneyTTableAdapter moneyTTableAdapter1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_All2;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_CurrentCountry2;
        private System.Windows.Forms.CheckBox checkBox_All;
        private System.Windows.Forms.BindingSource feePhaseItemsTBindingSource;
        private DataSet_DropTableAdapters.FeePhaseItemsTTableAdapter feePhaseItemsTTableAdapter;
        private System.Windows.Forms.TextBox txt_SingCodeStatus;
    }
}