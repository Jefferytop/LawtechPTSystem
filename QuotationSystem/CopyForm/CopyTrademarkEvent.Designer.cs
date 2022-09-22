namespace LawtechPTSystem.CopyForm
{
    partial class CopyTrademarkEvent
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
            this.button1 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBox_Statue = new System.Windows.Forms.ComboBox();
            this.tMStatusTBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet_Drop = new LawtechPTSystem.DataSet_Drop();
            this.label11 = new System.Windows.Forms.Label();
            this.but_Cancel = new System.Windows.Forms.Button();
            this.comboBox_WorkerKey = new System.Windows.Forms.ComboBox();
            this.workerQuitNBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.qS_DataSet = new LawtechPTSystem.QS_DataSet();
            this.label14 = new System.Windows.Forms.Label();
            this.txt_StatusExplain = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.maskedTextBox_AttorneyDueDate = new System.Windows.Forms.MaskedTextBox();
            this.contextMenuStrip_ForDate = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolStripMenuItem_Calculation = new System.Windows.Forms.ToolStripMenuItem();
            this.label3 = new System.Windows.Forms.Label();
            this.but_OK = new System.Windows.Forms.Button();
            this.maskedTextBox_Notice = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBox_NotifyComitDate = new System.Windows.Forms.MaskedTextBox();
            this.label36 = new System.Windows.Forms.Label();
            this.maskedTextBox_OutsourcingDate = new System.Windows.Forms.MaskedTextBox();
            this.label33 = new System.Windows.Forms.Label();
            this.maskedTextBox_FinishDate = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBox_CustomerAuthorizationDate = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBox_DueDate = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBox_OccurDate = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBox_NotifyOfficerDate = new System.Windows.Forms.MaskedTextBox();
            this.label48 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label49 = new System.Windows.Forms.Label();
            this.txt_Remark = new System.Windows.Forms.TextBox();
            this.txt_Result = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tMStatusTTableAdapter = new LawtechPTSystem.DataSet_DropTableAdapters.TMStatusTTableAdapter();
            this.worker_QuitNTableAdapter = new LawtechPTSystem.QS_DataSetTableAdapters.Worker_QuitNTableAdapter();
            this.comboBox_NotifyEventContent = new System.Windows.Forms.ComboBox();
            this.tMNotifyDueTBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet_TMDrop = new LawtechPTSystem.DataSet_TMDrop();
            this.tMNotifyDueTTableAdapter = new LawtechPTSystem.DataSet_TMDropTableAdapters.TMNotifyDueTTableAdapter();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tMStatusTBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_Drop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.workerQuitNBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qS_DataSet)).BeginInit();
            this.contextMenuStrip_ForDate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tMNotifyDueTBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_TMDrop)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Font = new System.Drawing.Font("微軟正黑體", 9F);
            this.button1.Location = new System.Drawing.Point(446, 22);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(91, 27);
            this.button1.TabIndex = 1121;
            this.button1.TabStop = false;
            this.button1.Text = "回復案件階段";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.label7.Location = new System.Drawing.Point(50, 93);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 20);
            this.label7.TabIndex = 1122;
            this.label7.Text = "事件內容";
            // 
            // comboBox_Statue
            // 
            this.comboBox_Statue.DataSource = this.tMStatusTBindingSource;
            this.comboBox_Statue.DisplayMember = "Status";
            this.comboBox_Statue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Statue.Enabled = false;
            this.comboBox_Statue.Font = new System.Drawing.Font("微軟正黑體", 14F);
            this.comboBox_Statue.FormattingEnabled = true;
            this.comboBox_Statue.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.comboBox_Statue.Location = new System.Drawing.Point(124, 22);
            this.comboBox_Statue.Margin = new System.Windows.Forms.Padding(1);
            this.comboBox_Statue.Name = "comboBox_Statue";
            this.comboBox_Statue.Size = new System.Drawing.Size(318, 32);
            this.comboBox_Statue.TabIndex = 1089;
            this.comboBox_Statue.ValueMember = "TMStatusID";
            this.comboBox_Statue.SelectedIndexChanged += new System.EventHandler(this.comboBox_Statue_SelectedIndexChanged);
            // 
            // tMStatusTBindingSource
            // 
            this.tMStatusTBindingSource.DataMember = "TMStatusT";
            this.tMStatusTBindingSource.DataSource = this.dataSet_Drop;
            // 
            // dataSet_Drop
            // 
            this.dataSet_Drop.DataSetName = "dataSet_Drop";
            this.dataSet_Drop.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.label11.Location = new System.Drawing.Point(19, 26);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(105, 20);
            this.label11.TabIndex = 1120;
            this.label11.Text = "目前案件階段";
            // 
            // but_Cancel
            // 
            this.but_Cancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.but_Cancel.BackgroundImage = global::LawtechPTSystem.Properties.Resources.btnCancel;
            this.but_Cancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.but_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.but_Cancel.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.but_Cancel.Location = new System.Drawing.Point(282, 499);
            this.but_Cancel.Margin = new System.Windows.Forms.Padding(4);
            this.but_Cancel.Name = "but_Cancel";
            this.but_Cancel.Size = new System.Drawing.Size(94, 32);
            this.but_Cancel.TabIndex = 1105;
            this.but_Cancel.Text = "取   消";
            this.but_Cancel.UseVisualStyleBackColor = true;
            this.but_Cancel.Click += new System.EventHandler(this.but_Cancel_Click);
            // 
            // comboBox_WorkerKey
            // 
            this.comboBox_WorkerKey.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBox_WorkerKey.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox_WorkerKey.DataSource = this.workerQuitNBindingSource;
            this.comboBox_WorkerKey.DisplayMember = "Name";
            this.comboBox_WorkerKey.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.comboBox_WorkerKey.FormattingEnabled = true;
            this.comboBox_WorkerKey.Location = new System.Drawing.Point(413, 120);
            this.comboBox_WorkerKey.Margin = new System.Windows.Forms.Padding(1);
            this.comboBox_WorkerKey.Name = "comboBox_WorkerKey";
            this.comboBox_WorkerKey.Size = new System.Drawing.Size(123, 28);
            this.comboBox_WorkerKey.TabIndex = 1097;
            this.comboBox_WorkerKey.ValueMember = "WorkerKey";
            // 
            // workerQuitNBindingSource
            // 
            this.workerQuitNBindingSource.DataMember = "Worker_QuitN";
            this.workerQuitNBindingSource.DataSource = this.qS_DataSet;
            // 
            // qS_DataSet
            // 
            this.qS_DataSet.DataSetName = "QS_DataSet";
            this.qS_DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.label14.Location = new System.Drawing.Point(49, 61);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(73, 20);
            this.label14.TabIndex = 1119;
            this.label14.Text = "階段描述";
            // 
            // txt_StatusExplain
            // 
            this.txt_StatusExplain.Enabled = false;
            this.txt_StatusExplain.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.txt_StatusExplain.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txt_StatusExplain.Location = new System.Drawing.Point(124, 56);
            this.txt_StatusExplain.Margin = new System.Windows.Forms.Padding(1);
            this.txt_StatusExplain.Name = "txt_StatusExplain";
            this.txt_StatusExplain.Size = new System.Drawing.Size(413, 29);
            this.txt_StatusExplain.TabIndex = 1091;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.label4.Location = new System.Drawing.Point(323, 124);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 20);
            this.label4.TabIndex = 1118;
            this.label4.Text = "本所承辦人";
            // 
            // maskedTextBox_AttorneyDueDate
            // 
            this.maskedTextBox_AttorneyDueDate.ContextMenuStrip = this.contextMenuStrip_ForDate;
            this.maskedTextBox_AttorneyDueDate.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.maskedTextBox_AttorneyDueDate.ForeColor = System.Drawing.Color.Green;
            this.maskedTextBox_AttorneyDueDate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.maskedTextBox_AttorneyDueDate.Location = new System.Drawing.Point(124, 213);
            this.maskedTextBox_AttorneyDueDate.Margin = new System.Windows.Forms.Padding(1);
            this.maskedTextBox_AttorneyDueDate.Mask = "0000/00/00";
            this.maskedTextBox_AttorneyDueDate.Name = "maskedTextBox_AttorneyDueDate";
            this.maskedTextBox_AttorneyDueDate.Size = new System.Drawing.Size(123, 29);
            this.maskedTextBox_AttorneyDueDate.TabIndex = 1096;
            this.maskedTextBox_AttorneyDueDate.ValidatingType = typeof(System.DateTime);
            this.maskedTextBox_AttorneyDueDate.DoubleClick += new System.EventHandler(this.maskedTextBox_NotifyComitDate_DoubleClick);
            this.maskedTextBox_AttorneyDueDate.Leave += new System.EventHandler(this.maskedTextBox_NotifyComitDate_Leave);
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(98)))), ((int)(((byte)(214)))));
            this.label3.Location = new System.Drawing.Point(49, 216);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 20);
            this.label3.TabIndex = 1117;
            this.label3.Text = "所內期限";
            // 
            // but_OK
            // 
            this.but_OK.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.but_OK.BackgroundImage = global::LawtechPTSystem.Properties.Resources.btnComfirm;
            this.but_OK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.but_OK.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.but_OK.Location = new System.Drawing.Point(180, 499);
            this.but_OK.Margin = new System.Windows.Forms.Padding(4);
            this.but_OK.Name = "but_OK";
            this.but_OK.Size = new System.Drawing.Size(94, 32);
            this.but_OK.TabIndex = 1104;
            this.but_OK.Text = "確   定";
            this.but_OK.UseVisualStyleBackColor = true;
            this.but_OK.Click += new System.EventHandler(this.but_OK_Click);
            // 
            // maskedTextBox_Notice
            // 
            this.maskedTextBox_Notice.ContextMenuStrip = this.contextMenuStrip_ForDate;
            this.maskedTextBox_Notice.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.maskedTextBox_Notice.ForeColor = System.Drawing.Color.Green;
            this.maskedTextBox_Notice.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.maskedTextBox_Notice.Location = new System.Drawing.Point(413, 181);
            this.maskedTextBox_Notice.Margin = new System.Windows.Forms.Padding(1);
            this.maskedTextBox_Notice.Mask = "0000/00/00";
            this.maskedTextBox_Notice.Name = "maskedTextBox_Notice";
            this.maskedTextBox_Notice.Size = new System.Drawing.Size(123, 29);
            this.maskedTextBox_Notice.TabIndex = 1098;
            this.maskedTextBox_Notice.ValidatingType = typeof(System.DateTime);
            this.maskedTextBox_Notice.DoubleClick += new System.EventHandler(this.maskedTextBox_NotifyComitDate_DoubleClick);
            this.maskedTextBox_Notice.Leave += new System.EventHandler(this.maskedTextBox_NotifyComitDate_Leave);
            // 
            // maskedTextBox_NotifyComitDate
            // 
            this.maskedTextBox_NotifyComitDate.ContextMenuStrip = this.contextMenuStrip_ForDate;
            this.maskedTextBox_NotifyComitDate.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.maskedTextBox_NotifyComitDate.ForeColor = System.Drawing.Color.Green;
            this.maskedTextBox_NotifyComitDate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.maskedTextBox_NotifyComitDate.Location = new System.Drawing.Point(124, 121);
            this.maskedTextBox_NotifyComitDate.Margin = new System.Windows.Forms.Padding(1);
            this.maskedTextBox_NotifyComitDate.Mask = "0000/00/00";
            this.maskedTextBox_NotifyComitDate.Name = "maskedTextBox_NotifyComitDate";
            this.maskedTextBox_NotifyComitDate.Size = new System.Drawing.Size(123, 29);
            this.maskedTextBox_NotifyComitDate.TabIndex = 1092;
            this.maskedTextBox_NotifyComitDate.ValidatingType = typeof(System.DateTime);
            this.maskedTextBox_NotifyComitDate.DoubleClick += new System.EventHandler(this.maskedTextBox_NotifyComitDate_DoubleClick);
            this.maskedTextBox_NotifyComitDate.Leave += new System.EventHandler(this.maskedTextBox_NotifyComitDate_Leave);
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.BackColor = System.Drawing.Color.Transparent;
            this.label36.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.label36.Location = new System.Drawing.Point(323, 186);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(73, 20);
            this.label36.TabIndex = 1116;
            this.label36.Text = "送件日期";
            // 
            // maskedTextBox_OutsourcingDate
            // 
            this.maskedTextBox_OutsourcingDate.ContextMenuStrip = this.contextMenuStrip_ForDate;
            this.maskedTextBox_OutsourcingDate.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.maskedTextBox_OutsourcingDate.ForeColor = System.Drawing.Color.Green;
            this.maskedTextBox_OutsourcingDate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.maskedTextBox_OutsourcingDate.Location = new System.Drawing.Point(413, 150);
            this.maskedTextBox_OutsourcingDate.Margin = new System.Windows.Forms.Padding(1);
            this.maskedTextBox_OutsourcingDate.Mask = "0000/00/00";
            this.maskedTextBox_OutsourcingDate.Name = "maskedTextBox_OutsourcingDate";
            this.maskedTextBox_OutsourcingDate.Size = new System.Drawing.Size(123, 29);
            this.maskedTextBox_OutsourcingDate.TabIndex = 1100;
            this.maskedTextBox_OutsourcingDate.ValidatingType = typeof(System.DateTime);
            this.maskedTextBox_OutsourcingDate.DoubleClick += new System.EventHandler(this.maskedTextBox_NotifyComitDate_DoubleClick);
            this.maskedTextBox_OutsourcingDate.Leave += new System.EventHandler(this.maskedTextBox_NotifyComitDate_Leave);
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.BackColor = System.Drawing.Color.Transparent;
            this.label33.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.label33.Location = new System.Drawing.Point(339, 155);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(73, 20);
            this.label33.TabIndex = 1115;
            this.label33.Text = "委外日期";
            // 
            // maskedTextBox_FinishDate
            // 
            this.maskedTextBox_FinishDate.ContextMenuStrip = this.contextMenuStrip_ForDate;
            this.maskedTextBox_FinishDate.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.maskedTextBox_FinishDate.ForeColor = System.Drawing.Color.Green;
            this.maskedTextBox_FinishDate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.maskedTextBox_FinishDate.Location = new System.Drawing.Point(124, 275);
            this.maskedTextBox_FinishDate.Margin = new System.Windows.Forms.Padding(1);
            this.maskedTextBox_FinishDate.Mask = "0000/00/00";
            this.maskedTextBox_FinishDate.Name = "maskedTextBox_FinishDate";
            this.maskedTextBox_FinishDate.Size = new System.Drawing.Size(123, 29);
            this.maskedTextBox_FinishDate.TabIndex = 1101;
            this.maskedTextBox_FinishDate.ValidatingType = typeof(System.DateTime);
            this.maskedTextBox_FinishDate.DoubleClick += new System.EventHandler(this.maskedTextBox_NotifyComitDate_DoubleClick);
            this.maskedTextBox_FinishDate.Leave += new System.EventHandler(this.maskedTextBox_NotifyComitDate_Leave);
            // 
            // maskedTextBox_CustomerAuthorizationDate
            // 
            this.maskedTextBox_CustomerAuthorizationDate.ContextMenuStrip = this.contextMenuStrip_ForDate;
            this.maskedTextBox_CustomerAuthorizationDate.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.maskedTextBox_CustomerAuthorizationDate.ForeColor = System.Drawing.Color.Green;
            this.maskedTextBox_CustomerAuthorizationDate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.maskedTextBox_CustomerAuthorizationDate.Location = new System.Drawing.Point(413, 216);
            this.maskedTextBox_CustomerAuthorizationDate.Margin = new System.Windows.Forms.Padding(1);
            this.maskedTextBox_CustomerAuthorizationDate.Mask = "0000/00/00";
            this.maskedTextBox_CustomerAuthorizationDate.Name = "maskedTextBox_CustomerAuthorizationDate";
            this.maskedTextBox_CustomerAuthorizationDate.Size = new System.Drawing.Size(123, 29);
            this.maskedTextBox_CustomerAuthorizationDate.TabIndex = 1099;
            this.maskedTextBox_CustomerAuthorizationDate.ValidatingType = typeof(System.DateTime);
            this.maskedTextBox_CustomerAuthorizationDate.Visible = false;
            this.maskedTextBox_CustomerAuthorizationDate.DoubleClick += new System.EventHandler(this.maskedTextBox_NotifyComitDate_DoubleClick);
            this.maskedTextBox_CustomerAuthorizationDate.Leave += new System.EventHandler(this.maskedTextBox_NotifyComitDate_Leave);
            // 
            // maskedTextBox_DueDate
            // 
            this.maskedTextBox_DueDate.ContextMenuStrip = this.contextMenuStrip_ForDate;
            this.maskedTextBox_DueDate.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.maskedTextBox_DueDate.ForeColor = System.Drawing.Color.Green;
            this.maskedTextBox_DueDate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.maskedTextBox_DueDate.Location = new System.Drawing.Point(124, 244);
            this.maskedTextBox_DueDate.Margin = new System.Windows.Forms.Padding(1);
            this.maskedTextBox_DueDate.Mask = "0000/00/00";
            this.maskedTextBox_DueDate.Name = "maskedTextBox_DueDate";
            this.maskedTextBox_DueDate.Size = new System.Drawing.Size(123, 29);
            this.maskedTextBox_DueDate.TabIndex = 1095;
            this.maskedTextBox_DueDate.ValidatingType = typeof(System.DateTime);
            this.maskedTextBox_DueDate.DoubleClick += new System.EventHandler(this.maskedTextBox_NotifyComitDate_DoubleClick);
            this.maskedTextBox_DueDate.Leave += new System.EventHandler(this.maskedTextBox_NotifyComitDate_Leave);
            // 
            // maskedTextBox_OccurDate
            // 
            this.maskedTextBox_OccurDate.ContextMenuStrip = this.contextMenuStrip_ForDate;
            this.maskedTextBox_OccurDate.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.maskedTextBox_OccurDate.ForeColor = System.Drawing.Color.Green;
            this.maskedTextBox_OccurDate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.maskedTextBox_OccurDate.Location = new System.Drawing.Point(124, 182);
            this.maskedTextBox_OccurDate.Margin = new System.Windows.Forms.Padding(1);
            this.maskedTextBox_OccurDate.Mask = "0000/00/00";
            this.maskedTextBox_OccurDate.Name = "maskedTextBox_OccurDate";
            this.maskedTextBox_OccurDate.Size = new System.Drawing.Size(123, 29);
            this.maskedTextBox_OccurDate.TabIndex = 1094;
            this.maskedTextBox_OccurDate.ValidatingType = typeof(System.DateTime);
            this.maskedTextBox_OccurDate.DoubleClick += new System.EventHandler(this.maskedTextBox_NotifyComitDate_DoubleClick);
            this.maskedTextBox_OccurDate.Leave += new System.EventHandler(this.maskedTextBox_NotifyComitDate_Leave);
            // 
            // maskedTextBox_NotifyOfficerDate
            // 
            this.maskedTextBox_NotifyOfficerDate.ContextMenuStrip = this.contextMenuStrip_ForDate;
            this.maskedTextBox_NotifyOfficerDate.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.maskedTextBox_NotifyOfficerDate.ForeColor = System.Drawing.Color.Green;
            this.maskedTextBox_NotifyOfficerDate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.maskedTextBox_NotifyOfficerDate.Location = new System.Drawing.Point(124, 152);
            this.maskedTextBox_NotifyOfficerDate.Margin = new System.Windows.Forms.Padding(1);
            this.maskedTextBox_NotifyOfficerDate.Mask = "0000/00/00";
            this.maskedTextBox_NotifyOfficerDate.Name = "maskedTextBox_NotifyOfficerDate";
            this.maskedTextBox_NotifyOfficerDate.Size = new System.Drawing.Size(123, 29);
            this.maskedTextBox_NotifyOfficerDate.TabIndex = 1093;
            this.maskedTextBox_NotifyOfficerDate.ValidatingType = typeof(System.DateTime);
            this.maskedTextBox_NotifyOfficerDate.DoubleClick += new System.EventHandler(this.maskedTextBox_NotifyComitDate_DoubleClick);
            this.maskedTextBox_NotifyOfficerDate.Leave += new System.EventHandler(this.maskedTextBox_NotifyComitDate_Leave);
            // 
            // label48
            // 
            this.label48.AutoSize = true;
            this.label48.BackColor = System.Drawing.Color.Transparent;
            this.label48.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.label48.ForeColor = System.Drawing.Color.Brown;
            this.label48.Location = new System.Drawing.Point(50, 279);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(73, 20);
            this.label48.TabIndex = 1114;
            this.label48.Text = "完成日期";
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.BackColor = System.Drawing.Color.Transparent;
            this.label32.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.label32.Location = new System.Drawing.Point(307, 220);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(105, 20);
            this.label32.TabIndex = 1113;
            this.label32.Text = "客戶委辦日期";
            this.label32.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.label1.Location = new System.Drawing.Point(49, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 20);
            this.label1.TabIndex = 1108;
            this.label1.Text = "來函內容";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.BackColor = System.Drawing.Color.Transparent;
            this.label23.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.label23.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.label23.Location = new System.Drawing.Point(49, 249);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(73, 20);
            this.label23.TabIndex = 1112;
            this.label23.Text = "官方期限";
            // 
            // label49
            // 
            this.label49.AutoSize = true;
            this.label49.BackColor = System.Drawing.Color.Transparent;
            this.label49.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.label49.Location = new System.Drawing.Point(63, 450);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(57, 20);
            this.label49.TabIndex = 1107;
            this.label49.Text = "備    註";
            // 
            // txt_Remark
            // 
            this.txt_Remark.BackColor = System.Drawing.Color.White;
            this.txt_Remark.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.txt_Remark.ImeMode = System.Windows.Forms.ImeMode.Close;
            this.txt_Remark.Location = new System.Drawing.Point(124, 425);
            this.txt_Remark.Margin = new System.Windows.Forms.Padding(1);
            this.txt_Remark.Multiline = true;
            this.txt_Remark.Name = "txt_Remark";
            this.txt_Remark.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_Remark.Size = new System.Drawing.Size(412, 67);
            this.txt_Remark.TabIndex = 1103;
            // 
            // txt_Result
            // 
            this.txt_Result.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.txt_Result.ImeMode = System.Windows.Forms.ImeMode.Close;
            this.txt_Result.Location = new System.Drawing.Point(124, 305);
            this.txt_Result.Margin = new System.Windows.Forms.Padding(1);
            this.txt_Result.Multiline = true;
            this.txt_Result.Name = "txt_Result";
            this.txt_Result.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_Result.Size = new System.Drawing.Size(412, 118);
            this.txt_Result.TabIndex = 1102;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.label10.Location = new System.Drawing.Point(47, 185);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(73, 20);
            this.label10.TabIndex = 1111;
            this.label10.Text = "簽收日期";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.label6.Location = new System.Drawing.Point(34, 157);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 20);
            this.label6.TabIndex = 1110;
            this.label6.Text = "官方發文日";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.label8.Location = new System.Drawing.Point(47, 363);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 20);
            this.label8.TabIndex = 1106;
            this.label8.Text = "處理結果";
            // 
            // tMStatusTTableAdapter
            // 
            this.tMStatusTTableAdapter.ClearBeforeFill = true;
            // 
            // worker_QuitNTableAdapter
            // 
            this.worker_QuitNTableAdapter.ClearBeforeFill = true;
            // 
            // comboBox_NotifyEventContent
            // 
            this.comboBox_NotifyEventContent.DataSource = this.tMNotifyDueTBindingSource;
            this.comboBox_NotifyEventContent.DisplayMember = "NotifyContent";
            this.comboBox_NotifyEventContent.Enabled = false;
            this.comboBox_NotifyEventContent.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.comboBox_NotifyEventContent.FormattingEnabled = true;
            this.comboBox_NotifyEventContent.Location = new System.Drawing.Point(124, 90);
            this.comboBox_NotifyEventContent.Margin = new System.Windows.Forms.Padding(1);
            this.comboBox_NotifyEventContent.Name = "comboBox_NotifyEventContent";
            this.comboBox_NotifyEventContent.Size = new System.Drawing.Size(413, 28);
            this.comboBox_NotifyEventContent.TabIndex = 1124;
            this.comboBox_NotifyEventContent.ValueMember = "TMNotifyDueID";
            // 
            // tMNotifyDueTBindingSource
            // 
            this.tMNotifyDueTBindingSource.DataMember = "TMNotifyDueT";
            this.tMNotifyDueTBindingSource.DataSource = this.dataSet_TMDrop;
            // 
            // dataSet_TMDrop
            // 
            this.dataSet_TMDrop.DataSetName = "DataSet_TMDrop";
            this.dataSet_TMDrop.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tMNotifyDueTTableAdapter
            // 
            this.tMNotifyDueTTableAdapter.ClearBeforeFill = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(149)))), ((int)(((byte)(115)))));
            this.label2.Location = new System.Drawing.Point(34, 124);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 20);
            this.label2.TabIndex = 1125;
            this.label2.Text = "事件發生日";
            // 
            // CopyTrademarkEvent
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = global::LawtechPTSystem.Properties.Resources.bg_01;
            this.CancelButton = this.but_Cancel;
            this.ClientSize = new System.Drawing.Size(555, 546);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox_NotifyEventContent);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.comboBox_Statue);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.but_Cancel);
            this.Controls.Add(this.comboBox_WorkerKey);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.txt_StatusExplain);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.maskedTextBox_AttorneyDueDate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.but_OK);
            this.Controls.Add(this.maskedTextBox_Notice);
            this.Controls.Add(this.maskedTextBox_NotifyComitDate);
            this.Controls.Add(this.label36);
            this.Controls.Add(this.maskedTextBox_OutsourcingDate);
            this.Controls.Add(this.label33);
            this.Controls.Add(this.maskedTextBox_FinishDate);
            this.Controls.Add(this.maskedTextBox_CustomerAuthorizationDate);
            this.Controls.Add(this.maskedTextBox_DueDate);
            this.Controls.Add(this.maskedTextBox_OccurDate);
            this.Controls.Add(this.maskedTextBox_NotifyOfficerDate);
            this.Controls.Add(this.label48);
            this.Controls.Add(this.label32);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.label49);
            this.Controls.Add(this.txt_Remark);
            this.Controls.Add(this.txt_Result);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label8);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CopyTrademarkEvent";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "複製案件記錄";
            this.Load += new System.EventHandler(this.CopyTrademarkEvent_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tMStatusTBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_Drop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.workerQuitNBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qS_DataSet)).EndInit();
            this.contextMenuStrip_ForDate.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tMNotifyDueTBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_TMDrop)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label7;
        internal System.Windows.Forms.ComboBox comboBox_Statue;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button but_Cancel;
        private System.Windows.Forms.ComboBox comboBox_WorkerKey;
        private System.Windows.Forms.Label label14;
        internal System.Windows.Forms.TextBox txt_StatusExplain;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_AttorneyDueDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button but_OK;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_Notice;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_NotifyComitDate;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_OutsourcingDate;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_FinishDate;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_CustomerAuthorizationDate;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_DueDate;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_OccurDate;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_NotifyOfficerDate;
        private System.Windows.Forms.Label label48;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label49;
        internal System.Windows.Forms.TextBox txt_Remark;
        internal System.Windows.Forms.TextBox txt_Result;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_ForDate;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Calculation;
        private DataSet_Drop dataSet_Drop;
        private System.Windows.Forms.BindingSource tMStatusTBindingSource;
        private LawtechPTSystem.DataSet_DropTableAdapters.TMStatusTTableAdapter tMStatusTTableAdapter;
        private QS_DataSet qS_DataSet;
        private System.Windows.Forms.BindingSource workerQuitNBindingSource;
        private LawtechPTSystem.QS_DataSetTableAdapters.Worker_QuitNTableAdapter worker_QuitNTableAdapter;
        private System.Windows.Forms.ComboBox comboBox_NotifyEventContent;
        private System.Windows.Forms.BindingSource tMNotifyDueTBindingSource;
        private DataSet_TMDrop dataSet_TMDrop;
        private LawtechPTSystem.DataSet_TMDropTableAdapters.TMNotifyDueTTableAdapter tMNotifyDueTTableAdapter;
        internal System.Windows.Forms.Label label2;
    }
}