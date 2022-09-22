using Microsoft.Reporting.WinForms;
namespace LawtechPTSystem.SubFrom
{
    partial class PetitionMF
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該公開 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改這個方法的內容。
        ///
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PetitionMF));
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.petitionRFDataTableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bMTriffDataSet1 = new LawtechPTSystem.Report.BMtriffDataSet();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.petitionRFENBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.subjectBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.paragraphTBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.SubjectBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.paragraphTBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.QS_DataSet1 = new LawtechPTSystem.QS_DataSet();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox_Country = new System.Windows.Forms.ComboBox();
            this.countryTBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.countryTTableAdapter = new LawtechPTSystem.QS_DataSetTableAdapters.CountryTTableAdapter();
            this.dataGridView_Petition = new System.Windows.Forms.DataGridView();
            this.PetitionName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PetitionNameEN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PetitionNameCHS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Kind = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Country = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.petitionNameENDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.petitionNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.countryDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kindDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.AddPetition = new System.Windows.Forms.ToolStripMenuItem();
            this.DelPetition = new System.Windows.Forms.ToolStripMenuItem();
            this.petitionTBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridView_Subject = new System.Windows.Forms.DataGridView();
            this.pSIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.sortDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SID = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.subjectTBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.SubjectName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subjectNameENDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubjectNameCHS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.AddSubject = new System.Windows.Forms.ToolStripMenuItem();
            this.Delsubject = new System.Windows.Forms.ToolStripMenuItem();
            this.SubjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.CopySubjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PasteSubjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.UploadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.petitionSubjectTBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridView_Paragraph = new System.Windows.Forms.DataGridView();
            this.paraIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.sort = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsOpen = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.paragraphDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ParagraphEN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ParagraphCHS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip3 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.AddParag = new System.Windows.Forms.ToolStripMenuItem();
            this.DelParagraph = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.CopyParagraph = new System.Windows.Forms.ToolStripMenuItem();
            this.PasteParagraph = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.ParagraphDetail = new System.Windows.Forms.ToolStripMenuItem();
            this.petitionTTableAdapter = new LawtechPTSystem.QS_DataSetTableAdapters.PetitionTTableAdapter();
            this._PetitionSubjectTTableAdapter = new LawtechPTSystem.QS_DataSetTableAdapters.PetitionSubjectTTableAdapter();
            this.paragraphTTableAdapter = new LawtechPTSystem.QS_DataSetTableAdapters.ParagraphTTableAdapter();
            this.but_Show = new System.Windows.Forms.Button();
            this.but_ShowEN = new System.Windows.Forms.Button();
            this.subjectTTableAdapter = new LawtechPTSystem.QS_DataSetTableAdapters.SubjectTTableAdapter();
            this.SubjectTableAdapter = new LawtechPTSystem.Report.BMtriffDataSetTableAdapters.SubjectTableAdapter();
            this.paragraphTTableAdapter1 = new LawtechPTSystem.Report.BMtriffDataSetTableAdapters.ParagraphTTableAdapter();
            this.petitionRFDataTableTableAdapter = new LawtechPTSystem.Report.BMtriffDataSetTableAdapters.PetitionRFDataTableTableAdapter();
            this.petitionRFENBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.petitionRF_ENTableAdapter = new LawtechPTSystem.Report.BMtriffDataSetTableAdapters.PetitionRF_ENTableAdapter();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox_kind = new System.Windows.Forms.ComboBox();
            this.kindTBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.kindTTableAdapter = new LawtechPTSystem.QS_DataSetTableAdapters.KindTTableAdapter();
            this.button1 = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer_list = new System.Windows.Forms.SplitContainer();
            this.tagTitle1 = new LawtechPTSystem.US.TagTitle();
            this.splitContainer_Content = new System.Windows.Forms.SplitContainer();
            this.tagTitle2 = new LawtechPTSystem.US.TagTitle();
            this.tagTitle3 = new LawtechPTSystem.US.TagTitle();
            this.but_ShowCHS = new System.Windows.Forms.Button();
            this.petitionRF_CHSTableAdapter1 = new LawtechPTSystem.Report.BMtriffDataSetTableAdapters.PetitionRF_CHSTableAdapter();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.reportViewer2 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.reportViewer3 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.petitionRFDataTableBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bMTriffDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.petitionRFENBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.subjectBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.paragraphTBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SubjectBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.paragraphTBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QS_DataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.countryTBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Petition)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.petitionTBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Subject)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.subjectTBindingSource)).BeginInit();
            this.contextMenuStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.petitionSubjectTBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Paragraph)).BeginInit();
            this.contextMenuStrip3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.petitionRFENBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kindTBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_list)).BeginInit();
            this.splitContainer_list.Panel1.SuspendLayout();
            this.splitContainer_list.Panel2.SuspendLayout();
            this.splitContainer_list.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_Content)).BeginInit();
            this.splitContainer_Content.Panel1.SuspendLayout();
            this.splitContainer_Content.Panel2.SuspendLayout();
            this.splitContainer_Content.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // petitionRFDataTableBindingSource
            // 
            this.petitionRFDataTableBindingSource.DataMember = "PetitionRFDataTable";
            this.petitionRFDataTableBindingSource.DataSource = this.bMTriffDataSet1;
            // 
            // bMTriffDataSet1
            // 
            this.bMTriffDataSet1.DataSetName = "BMtriffDataSet";
            this.bMTriffDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataMember = "PetitionRF_CHS";
            this.bindingSource1.DataSource = this.bMTriffDataSet1;
            // 
            // petitionRFENBindingSource1
            // 
            this.petitionRFENBindingSource1.DataMember = "PetitionRF_EN";
            this.petitionRFENBindingSource1.DataSource = this.bMTriffDataSet1;
            // 
            // subjectBindingSource1
            // 
            this.subjectBindingSource1.DataMember = "Subject";
            this.subjectBindingSource1.DataSource = this.bMTriffDataSet1;
            // 
            // paragraphTBindingSource1
            // 
            this.paragraphTBindingSource1.DataMember = "ParagraphT";
            this.paragraphTBindingSource1.DataSource = this.bMTriffDataSet1;
            // 
            // SubjectBindingSource
            // 
            this.SubjectBindingSource.DataMember = "Subject";
            this.SubjectBindingSource.DataSource = this.bMTriffDataSet1;
            this.SubjectBindingSource.Sort = "";
            // 
            // paragraphTBindingSource
            // 
            this.paragraphTBindingSource.DataMember = "ParagraphT";
            this.paragraphTBindingSource.DataSource = this.QS_DataSet1;
            // 
            // QS_DataSet1
            // 
            this.QS_DataSet1.DataSetName = "QS_DataSet1";
            this.QS_DataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.label1.Location = new System.Drawing.Point(7, 8);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "國別";
            // 
            // comboBox_Country
            // 
            this.comboBox_Country.DataSource = this.countryTBindingSource;
            this.comboBox_Country.DisplayMember = "Country";
            this.comboBox_Country.FormattingEnabled = true;
            this.comboBox_Country.Location = new System.Drawing.Point(47, 5);
            this.comboBox_Country.Name = "comboBox_Country";
            this.comboBox_Country.Size = new System.Drawing.Size(164, 25);
            this.comboBox_Country.TabIndex = 2;
            this.comboBox_Country.ValueMember = "CountrySymbol";
            this.comboBox_Country.SelectedIndexChanged += new System.EventHandler(this.comboBox_Country_SelectedIndexChanged);
            // 
            // countryTBindingSource
            // 
            this.countryTBindingSource.DataMember = "CountryT";
            this.countryTBindingSource.DataSource = this.QS_DataSet1;
            this.countryTBindingSource.Sort = "SN";
            // 
            // countryTTableAdapter
            // 
            this.countryTTableAdapter.ClearBeforeFill = true;
            // 
            // dataGridView_Petition
            // 
            this.dataGridView_Petition.AllowUserToAddRows = false;
            this.dataGridView_Petition.AllowUserToDeleteRows = false;
            this.dataGridView_Petition.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(221)))), ((int)(((byte)(235)))), ((int)(((byte)(231)))));
            this.dataGridView_Petition.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView_Petition.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView_Petition.AutoGenerateColumns = false;
            this.dataGridView_Petition.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Petition.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PetitionName,
            this.PetitionNameEN,
            this.PetitionNameCHS,
            this.Kind,
            this.Country,
            this.PID,
            this.petitionNameENDataGridViewTextBoxColumn,
            this.petitionNameDataGridViewTextBoxColumn,
            this.countryDataGridViewTextBoxColumn,
            this.kindDataGridViewTextBoxColumn});
            this.dataGridView_Petition.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView_Petition.DataSource = this.petitionTBindingSource;
            this.dataGridView_Petition.Location = new System.Drawing.Point(3, 29);
            this.dataGridView_Petition.Margin = new System.Windows.Forms.Padding(1);
            this.dataGridView_Petition.Name = "dataGridView_Petition";
            this.dataGridView_Petition.RowHeadersWidth = 30;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微軟正黑體", 9F);
            this.dataGridView_Petition.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView_Petition.RowTemplate.Height = 24;
            this.dataGridView_Petition.Size = new System.Drawing.Size(476, 158);
            this.dataGridView_Petition.TabIndex = 4;
            this.dataGridView_Petition.Tag = "Petition";
            this.dataGridView_Petition.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_Petition_CellContentClick);
            this.dataGridView_Petition.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridView_Petition_DataError);
            this.dataGridView_Petition.SelectionChanged += new System.EventHandler(this.dataGridView_Petition_SelectionChanged);
            // 
            // PetitionName
            // 
            this.PetitionName.DataPropertyName = "PetitionName";
            this.PetitionName.HeaderText = "申請需知名稱";
            this.PetitionName.Name = "PetitionName";
            this.PetitionName.Width = 200;
            // 
            // PetitionNameEN
            // 
            this.PetitionNameEN.DataPropertyName = "PetitionNameEN";
            this.PetitionNameEN.HeaderText = "申請需知名稱(英)";
            this.PetitionNameEN.Name = "PetitionNameEN";
            this.PetitionNameEN.Width = 400;
            // 
            // PetitionNameCHS
            // 
            this.PetitionNameCHS.DataPropertyName = "PetitionNameCHS";
            this.PetitionNameCHS.HeaderText = "申請需知名稱(簡)";
            this.PetitionNameCHS.Name = "PetitionNameCHS";
            this.PetitionNameCHS.Width = 200;
            // 
            // Kind
            // 
            this.Kind.DataPropertyName = "Kind";
            this.Kind.HeaderText = "Kind";
            this.Kind.Name = "Kind";
            this.Kind.Visible = false;
            // 
            // Country
            // 
            this.Country.DataPropertyName = "Country";
            this.Country.HeaderText = "Country";
            this.Country.Name = "Country";
            this.Country.Visible = false;
            // 
            // PID
            // 
            this.PID.DataPropertyName = "PID";
            this.PID.HeaderText = "PID";
            this.PID.Name = "PID";
            this.PID.Visible = false;
            // 
            // petitionNameENDataGridViewTextBoxColumn
            // 
            this.petitionNameENDataGridViewTextBoxColumn.DataPropertyName = "PetitionNameEN";
            this.petitionNameENDataGridViewTextBoxColumn.HeaderText = "PetitionNameEN";
            this.petitionNameENDataGridViewTextBoxColumn.Name = "petitionNameENDataGridViewTextBoxColumn";
            this.petitionNameENDataGridViewTextBoxColumn.Visible = false;
            // 
            // petitionNameDataGridViewTextBoxColumn
            // 
            this.petitionNameDataGridViewTextBoxColumn.DataPropertyName = "PetitionName";
            this.petitionNameDataGridViewTextBoxColumn.HeaderText = "PetitionName";
            this.petitionNameDataGridViewTextBoxColumn.Name = "petitionNameDataGridViewTextBoxColumn";
            this.petitionNameDataGridViewTextBoxColumn.Visible = false;
            // 
            // countryDataGridViewTextBoxColumn
            // 
            this.countryDataGridViewTextBoxColumn.DataPropertyName = "Country";
            this.countryDataGridViewTextBoxColumn.HeaderText = "Country";
            this.countryDataGridViewTextBoxColumn.Name = "countryDataGridViewTextBoxColumn";
            this.countryDataGridViewTextBoxColumn.Visible = false;
            // 
            // kindDataGridViewTextBoxColumn
            // 
            this.kindDataGridViewTextBoxColumn.DataPropertyName = "Kind";
            this.kindDataGridViewTextBoxColumn.HeaderText = "Kind";
            this.kindDataGridViewTextBoxColumn.Name = "kindDataGridViewTextBoxColumn";
            this.kindDataGridViewTextBoxColumn.Visible = false;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddPetition,
            this.DelPetition});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(99, 48);
            this.contextMenuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuStrip1_ItemClicked);
            // 
            // AddPetition
            // 
            this.AddPetition.Image = global::LawtechPTSystem.Properties.Resources.Add;
            this.AddPetition.Name = "AddPetition";
            this.AddPetition.Size = new System.Drawing.Size(98, 22);
            this.AddPetition.Text = "新增";
            // 
            // DelPetition
            // 
            this.DelPetition.Image = global::LawtechPTSystem.Properties.Resources.delete;
            this.DelPetition.Name = "DelPetition";
            this.DelPetition.Size = new System.Drawing.Size(98, 22);
            this.DelPetition.Text = "刪除";
            // 
            // petitionTBindingSource
            // 
            this.petitionTBindingSource.DataMember = "PetitionT";
            this.petitionTBindingSource.DataSource = this.QS_DataSet1;
            // 
            // dataGridView_Subject
            // 
            this.dataGridView_Subject.AllowUserToAddRows = false;
            this.dataGridView_Subject.AllowUserToDeleteRows = false;
            this.dataGridView_Subject.AllowUserToOrderColumns = true;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.AliceBlue;
            this.dataGridView_Subject.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView_Subject.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView_Subject.AutoGenerateColumns = false;
            this.dataGridView_Subject.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Subject.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.pSIDDataGridViewTextBoxColumn,
            this.Column1,
            this.sortDataGridViewTextBoxColumn,
            this.SID,
            this.SubjectName,
            this.subjectNameENDataGridViewTextBoxColumn,
            this.SubjectNameCHS});
            this.dataGridView_Subject.ContextMenuStrip = this.contextMenuStrip2;
            this.dataGridView_Subject.DataSource = this.petitionSubjectTBindingSource;
            this.dataGridView_Subject.Location = new System.Drawing.Point(3, 30);
            this.dataGridView_Subject.Margin = new System.Windows.Forms.Padding(1);
            this.dataGridView_Subject.Name = "dataGridView_Subject";
            this.dataGridView_Subject.RowHeadersWidth = 30;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("微軟正黑體", 9F);
            this.dataGridView_Subject.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView_Subject.RowTemplate.Height = 24;
            this.dataGridView_Subject.Size = new System.Drawing.Size(476, 184);
            this.dataGridView_Subject.TabIndex = 7;
            this.dataGridView_Subject.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_Subject_CellContentClick);
            this.dataGridView_Subject.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_Subject_CellDoubleClick);
            this.dataGridView_Subject.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridView_Petition_DataError);
            this.dataGridView_Subject.SelectionChanged += new System.EventHandler(this.dataGridView_Subject_SelectionChanged);
            // 
            // pSIDDataGridViewTextBoxColumn
            // 
            this.pSIDDataGridViewTextBoxColumn.DataPropertyName = "PSID";
            this.pSIDDataGridViewTextBoxColumn.HeaderText = "PSID";
            this.pSIDDataGridViewTextBoxColumn.Name = "pSIDDataGridViewTextBoxColumn";
            this.pSIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.pSIDDataGridViewTextBoxColumn.Visible = false;
            // 
            // Column1
            // 
            this.Column1.FalseValue = "False";
            this.Column1.HeaderText = "勾選";
            this.Column1.IndeterminateValue = "False";
            this.Column1.Name = "Column1";
            this.Column1.TrueValue = "True";
            this.Column1.Width = 60;
            // 
            // sortDataGridViewTextBoxColumn
            // 
            this.sortDataGridViewTextBoxColumn.DataPropertyName = "sort";
            this.sortDataGridViewTextBoxColumn.HeaderText = "排序";
            this.sortDataGridViewTextBoxColumn.Name = "sortDataGridViewTextBoxColumn";
            this.sortDataGridViewTextBoxColumn.Width = 70;
            // 
            // SID
            // 
            this.SID.DataPropertyName = "SID";
            this.SID.DataSource = this.subjectTBindingSource;
            this.SID.DisplayMember = "SubjectName";
            this.SID.HeaderText = "大綱名稱";
            this.SID.Name = "SID";
            this.SID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.SID.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.SID.ValueMember = "SID";
            this.SID.Visible = false;
            this.SID.Width = 200;
            // 
            // subjectTBindingSource
            // 
            this.subjectTBindingSource.DataMember = "SubjectT";
            this.subjectTBindingSource.DataSource = this.QS_DataSet1;
            // 
            // SubjectName
            // 
            this.SubjectName.DataPropertyName = "SubjectName";
            this.SubjectName.HeaderText = "大綱名稱";
            this.SubjectName.Name = "SubjectName";
            this.SubjectName.ReadOnly = true;
            this.SubjectName.Width = 150;
            // 
            // subjectNameENDataGridViewTextBoxColumn
            // 
            this.subjectNameENDataGridViewTextBoxColumn.DataPropertyName = "SubjectNameEN";
            this.subjectNameENDataGridViewTextBoxColumn.HeaderText = "大綱名稱(英)";
            this.subjectNameENDataGridViewTextBoxColumn.Name = "subjectNameENDataGridViewTextBoxColumn";
            this.subjectNameENDataGridViewTextBoxColumn.ReadOnly = true;
            this.subjectNameENDataGridViewTextBoxColumn.Width = 200;
            // 
            // SubjectNameCHS
            // 
            this.SubjectNameCHS.DataPropertyName = "SubjectNameCHS";
            this.SubjectNameCHS.HeaderText = "大綱名稱(簡)";
            this.SubjectNameCHS.Name = "SubjectNameCHS";
            this.SubjectNameCHS.ReadOnly = true;
            this.SubjectNameCHS.Width = 150;
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddSubject,
            this.Delsubject,
            this.SubjectToolStripMenuItem,
            this.toolStripSeparator3,
            this.CopySubjectToolStripMenuItem,
            this.PasteSubjectToolStripMenuItem,
            this.toolStripSeparator4,
            this.UploadToolStripMenuItem});
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(147, 148);
            this.contextMenuStrip2.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuStrip2_ItemClicked);
            // 
            // AddSubject
            // 
            this.AddSubject.Image = global::LawtechPTSystem.Properties.Resources.Add;
            this.AddSubject.Name = "AddSubject";
            this.AddSubject.Size = new System.Drawing.Size(146, 22);
            this.AddSubject.Text = "新增大綱";
            // 
            // Delsubject
            // 
            this.Delsubject.Image = global::LawtechPTSystem.Properties.Resources.delete;
            this.Delsubject.Name = "Delsubject";
            this.Delsubject.Size = new System.Drawing.Size(146, 22);
            this.Delsubject.Text = "刪除大綱";
            // 
            // SubjectToolStripMenuItem
            // 
            this.SubjectToolStripMenuItem.Name = "SubjectToolStripMenuItem";
            this.SubjectToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.SubjectToolStripMenuItem.Text = "大綱名稱設定";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(143, 6);
            // 
            // CopySubjectToolStripMenuItem
            // 
            this.CopySubjectToolStripMenuItem.Name = "CopySubjectToolStripMenuItem";
            this.CopySubjectToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.CopySubjectToolStripMenuItem.Text = "複製勾選";
            // 
            // PasteSubjectToolStripMenuItem
            // 
            this.PasteSubjectToolStripMenuItem.Name = "PasteSubjectToolStripMenuItem";
            this.PasteSubjectToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.PasteSubjectToolStripMenuItem.Text = "貼上勾選";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(143, 6);
            // 
            // UploadToolStripMenuItem
            // 
            this.UploadToolStripMenuItem.Name = "UploadToolStripMenuItem";
            this.UploadToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.UploadToolStripMenuItem.Text = "相關文章";
            this.UploadToolStripMenuItem.Visible = false;
            // 
            // petitionSubjectTBindingSource
            // 
            this.petitionSubjectTBindingSource.DataMember = "PetitionSubjectT";
            this.petitionSubjectTBindingSource.DataSource = this.QS_DataSet1;
            // 
            // dataGridView_Paragraph
            // 
            this.dataGridView_Paragraph.AllowUserToAddRows = false;
            this.dataGridView_Paragraph.AllowUserToDeleteRows = false;
            this.dataGridView_Paragraph.AllowUserToOrderColumns = true;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(229)))), ((int)(((byte)(185)))));
            this.dataGridView_Paragraph.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView_Paragraph.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView_Paragraph.AutoGenerateColumns = false;
            this.dataGridView_Paragraph.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Paragraph.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.paraIDDataGridViewTextBoxColumn,
            this.Column2,
            this.sort,
            this.IsOpen,
            this.paragraphDataGridViewTextBoxColumn,
            this.ParagraphEN,
            this.ParagraphCHS});
            this.dataGridView_Paragraph.ContextMenuStrip = this.contextMenuStrip3;
            this.dataGridView_Paragraph.DataSource = this.paragraphTBindingSource;
            this.dataGridView_Paragraph.Location = new System.Drawing.Point(3, 29);
            this.dataGridView_Paragraph.Margin = new System.Windows.Forms.Padding(1);
            this.dataGridView_Paragraph.Name = "dataGridView_Paragraph";
            this.dataGridView_Paragraph.RowHeadersWidth = 30;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("微軟正黑體", 9F);
            this.dataGridView_Paragraph.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridView_Paragraph.RowTemplate.Height = 24;
            this.dataGridView_Paragraph.Size = new System.Drawing.Size(476, 259);
            this.dataGridView_Paragraph.TabIndex = 8;
            this.dataGridView_Paragraph.Tag = "Paragraph";
            this.dataGridView_Paragraph.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_Paragraph_CellClick);
            this.dataGridView_Paragraph.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridView_Petition_DataError);
            // 
            // paraIDDataGridViewTextBoxColumn
            // 
            this.paraIDDataGridViewTextBoxColumn.DataPropertyName = "ParaID";
            this.paraIDDataGridViewTextBoxColumn.HeaderText = "ParaID";
            this.paraIDDataGridViewTextBoxColumn.Name = "paraIDDataGridViewTextBoxColumn";
            this.paraIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.paraIDDataGridViewTextBoxColumn.Visible = false;
            // 
            // Column2
            // 
            this.Column2.FalseValue = "False";
            this.Column2.HeaderText = "勾選";
            this.Column2.IndeterminateValue = "False";
            this.Column2.Name = "Column2";
            this.Column2.TrueValue = "True";
            this.Column2.Width = 60;
            // 
            // sort
            // 
            this.sort.DataPropertyName = "sort";
            this.sort.HeaderText = "排序";
            this.sort.Name = "sort";
            this.sort.Width = 70;
            // 
            // IsOpen
            // 
            this.IsOpen.DataPropertyName = "IsOpen";
            this.IsOpen.FalseValue = "False";
            this.IsOpen.HeaderText = "公開";
            this.IsOpen.Name = "IsOpen";
            this.IsOpen.TrueValue = "True";
            this.IsOpen.Width = 60;
            // 
            // paragraphDataGridViewTextBoxColumn
            // 
            this.paragraphDataGridViewTextBoxColumn.DataPropertyName = "Paragraph";
            this.paragraphDataGridViewTextBoxColumn.HeaderText = "段落內容";
            this.paragraphDataGridViewTextBoxColumn.Name = "paragraphDataGridViewTextBoxColumn";
            this.paragraphDataGridViewTextBoxColumn.Width = 200;
            // 
            // ParagraphEN
            // 
            this.ParagraphEN.DataPropertyName = "ParagraphEN";
            this.ParagraphEN.HeaderText = "段落內容(英)";
            this.ParagraphEN.Name = "ParagraphEN";
            this.ParagraphEN.Width = 200;
            // 
            // ParagraphCHS
            // 
            this.ParagraphCHS.DataPropertyName = "ParagraphCHS";
            this.ParagraphCHS.HeaderText = "段落內容(簡)";
            this.ParagraphCHS.Name = "ParagraphCHS";
            this.ParagraphCHS.Width = 150;
            // 
            // contextMenuStrip3
            // 
            this.contextMenuStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddParag,
            this.DelParagraph,
            this.toolStripSeparator1,
            this.CopyParagraph,
            this.PasteParagraph,
            this.toolStripSeparator2,
            this.ParagraphDetail});
            this.contextMenuStrip3.Name = "contextMenuStrip3";
            this.contextMenuStrip3.Size = new System.Drawing.Size(147, 126);
            this.contextMenuStrip3.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuStrip3_ItemClicked);
            // 
            // AddParag
            // 
            this.AddParag.Image = global::LawtechPTSystem.Properties.Resources.Add;
            this.AddParag.Name = "AddParag";
            this.AddParag.Size = new System.Drawing.Size(146, 22);
            this.AddParag.Text = "新增段落";
            // 
            // DelParagraph
            // 
            this.DelParagraph.Image = global::LawtechPTSystem.Properties.Resources.delete;
            this.DelParagraph.Name = "DelParagraph";
            this.DelParagraph.Size = new System.Drawing.Size(146, 22);
            this.DelParagraph.Text = "刪除段落";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(143, 6);
            // 
            // CopyParagraph
            // 
            this.CopyParagraph.Name = "CopyParagraph";
            this.CopyParagraph.Size = new System.Drawing.Size(146, 22);
            this.CopyParagraph.Text = "複製勾選段落";
            // 
            // PasteParagraph
            // 
            this.PasteParagraph.Name = "PasteParagraph";
            this.PasteParagraph.Size = new System.Drawing.Size(146, 22);
            this.PasteParagraph.Text = "貼上段落";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(143, 6);
            // 
            // ParagraphDetail
            // 
            this.ParagraphDetail.Name = "ParagraphDetail";
            this.ParagraphDetail.Size = new System.Drawing.Size(146, 22);
            this.ParagraphDetail.Text = "依據法條";
            // 
            // petitionTTableAdapter
            // 
            this.petitionTTableAdapter.ClearBeforeFill = true;
            // 
            // _PetitionSubjectTTableAdapter
            // 
            this._PetitionSubjectTTableAdapter.ClearBeforeFill = true;
            // 
            // paragraphTTableAdapter
            // 
            this.paragraphTTableAdapter.ClearBeforeFill = true;
            // 
            // but_Show
            // 
            this.but_Show.BackColor = System.Drawing.Color.RoyalBlue;
            this.but_Show.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.but_Show.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.but_Show.Location = new System.Drawing.Point(3, 3);
            this.but_Show.Name = "but_Show";
            this.but_Show.Size = new System.Drawing.Size(75, 37);
            this.but_Show.TabIndex = 16;
            this.but_Show.Text = "中文";
            this.but_Show.UseVisualStyleBackColor = false;
            this.but_Show.Click += new System.EventHandler(this.but_Show_Click);
            // 
            // but_ShowEN
            // 
            this.but_ShowEN.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.but_ShowEN.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.but_ShowEN.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.but_ShowEN.Location = new System.Drawing.Point(155, 3);
            this.but_ShowEN.Name = "but_ShowEN";
            this.but_ShowEN.Size = new System.Drawing.Size(75, 37);
            this.but_ShowEN.TabIndex = 17;
            this.but_ShowEN.Text = "英文";
            this.but_ShowEN.UseVisualStyleBackColor = true;
            this.but_ShowEN.Click += new System.EventHandler(this.but_ShowEN_Click);
            // 
            // subjectTTableAdapter
            // 
            this.subjectTTableAdapter.ClearBeforeFill = true;
            // 
            // SubjectTableAdapter
            // 
            this.SubjectTableAdapter.ClearBeforeFill = true;
            // 
            // paragraphTTableAdapter1
            // 
            this.paragraphTTableAdapter1.ClearBeforeFill = true;
            // 
            // petitionRFDataTableTableAdapter
            // 
            this.petitionRFDataTableTableAdapter.ClearBeforeFill = true;
            // 
            // petitionRFENBindingSource
            // 
            this.petitionRFENBindingSource.DataMember = "PetitionRF_EN";
            this.petitionRFENBindingSource.DataSource = this.bMTriffDataSet1;
            // 
            // petitionRF_ENTableAdapter
            // 
            this.petitionRF_ENTableAdapter.ClearBeforeFill = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.label2.Location = new System.Drawing.Point(219, 9);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 20);
            this.label2.TabIndex = 20;
            this.label2.Text = "種類";
            // 
            // comboBox_kind
            // 
            this.comboBox_kind.DataSource = this.kindTBindingSource;
            this.comboBox_kind.DisplayMember = "Kind";
            this.comboBox_kind.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_kind.FormattingEnabled = true;
            this.comboBox_kind.Location = new System.Drawing.Point(258, 5);
            this.comboBox_kind.Name = "comboBox_kind";
            this.comboBox_kind.Size = new System.Drawing.Size(131, 25);
            this.comboBox_kind.TabIndex = 21;
            this.comboBox_kind.ValueMember = "KindSN";
            this.comboBox_kind.SelectedIndexChanged += new System.EventHandler(this.comboBox_Country_SelectedIndexChanged);
            // 
            // kindTBindingSource
            // 
            this.kindTBindingSource.DataMember = "KindT";
            this.kindTBindingSource.DataSource = this.QS_DataSet1;
            // 
            // kindTTableAdapter
            // 
            this.kindTTableAdapter.ClearBeforeFill = true;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.BackgroundImage = global::LawtechPTSystem.Properties.Resources.btnCancel;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.button1.Location = new System.Drawing.Point(453, 8);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 30);
            this.button1.TabIndex = 22;
            this.button1.Text = "關  閉";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.Transparent;
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer_list);
            this.splitContainer1.Panel1.Controls.Add(this.comboBox_Country);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.comboBox_kind);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.but_ShowCHS);
            this.splitContainer1.Panel2.Controls.Add(this.but_Show);
            this.splitContainer1.Panel2.Controls.Add(this.but_ShowEN);
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Panel2.Controls.Add(this.button1);
            this.splitContainer1.Size = new System.Drawing.Size(1055, 741);
            this.splitContainer1.SplitterDistance = 490;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 23;
            // 
            // splitContainer_list
            // 
            this.splitContainer_list.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer_list.Location = new System.Drawing.Point(3, 33);
            this.splitContainer_list.Name = "splitContainer_list";
            this.splitContainer_list.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer_list.Panel1
            // 
            this.splitContainer_list.Panel1.Controls.Add(this.dataGridView_Petition);
            this.splitContainer_list.Panel1.Controls.Add(this.tagTitle1);
            // 
            // splitContainer_list.Panel2
            // 
            this.splitContainer_list.Panel2.Controls.Add(this.splitContainer_Content);
            this.splitContainer_list.Size = new System.Drawing.Size(482, 707);
            this.splitContainer_list.SplitterDistance = 190;
            this.splitContainer_list.TabIndex = 22;
            // 
            // tagTitle1
            // 
            this.tagTitle1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tagTitle1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tagTitle1.BackgroundImage")));
            this.tagTitle1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tagTitle1.Location = new System.Drawing.Point(3, 3);
            this.tagTitle1.Margin = new System.Windows.Forms.Padding(0);
            this.tagTitle1.Name = "tagTitle1";
            this.tagTitle1.Size = new System.Drawing.Size(476, 29);
            this.tagTitle1.TabIndex = 29;
            this.tagTitle1.TagTitleStyle = "Style1";
            this.tagTitle1.TitleLableText = "1.) 申．請．需．知．清．單";
            // 
            // splitContainer_Content
            // 
            this.splitContainer_Content.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer_Content.Location = new System.Drawing.Point(0, 0);
            this.splitContainer_Content.Name = "splitContainer_Content";
            this.splitContainer_Content.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer_Content.Panel1
            // 
            this.splitContainer_Content.Panel1.Controls.Add(this.dataGridView_Subject);
            this.splitContainer_Content.Panel1.Controls.Add(this.tagTitle2);
            // 
            // splitContainer_Content.Panel2
            // 
            this.splitContainer_Content.Panel2.Controls.Add(this.dataGridView_Paragraph);
            this.splitContainer_Content.Panel2.Controls.Add(this.tagTitle3);
            this.splitContainer_Content.Size = new System.Drawing.Size(482, 513);
            this.splitContainer_Content.SplitterDistance = 217;
            this.splitContainer_Content.TabIndex = 0;
            // 
            // tagTitle2
            // 
            this.tagTitle2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tagTitle2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tagTitle2.BackgroundImage")));
            this.tagTitle2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tagTitle2.Location = new System.Drawing.Point(3, 2);
            this.tagTitle2.Margin = new System.Windows.Forms.Padding(0);
            this.tagTitle2.Name = "tagTitle2";
            this.tagTitle2.Size = new System.Drawing.Size(476, 35);
            this.tagTitle2.TabIndex = 30;
            this.tagTitle2.TagTitleStyle = "Style1";
            this.tagTitle2.TitleLableText = "2.) 申．請．需．知．大．綱";
            // 
            // tagTitle3
            // 
            this.tagTitle3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tagTitle3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tagTitle3.BackgroundImage")));
            this.tagTitle3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tagTitle3.Location = new System.Drawing.Point(3, 0);
            this.tagTitle3.Margin = new System.Windows.Forms.Padding(0);
            this.tagTitle3.Name = "tagTitle3";
            this.tagTitle3.Size = new System.Drawing.Size(476, 34);
            this.tagTitle3.TabIndex = 31;
            this.tagTitle3.TagTitleStyle = "Style1";
            this.tagTitle3.TitleLableText = "3.) 申．請．需．知．段．落．內．文";
            // 
            // but_ShowCHS
            // 
            this.but_ShowCHS.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.but_ShowCHS.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.but_ShowCHS.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.but_ShowCHS.Location = new System.Drawing.Point(79, 3);
            this.but_ShowCHS.Name = "but_ShowCHS";
            this.but_ShowCHS.Size = new System.Drawing.Size(75, 37);
            this.but_ShowCHS.TabIndex = 23;
            this.but_ShowCHS.Text = "簡體";
            this.but_ShowCHS.UseVisualStyleBackColor = true;
            this.but_ShowCHS.Click += new System.EventHandler(this.but_ShowCHS_Click);
            // 
            // petitionRF_CHSTableAdapter1
            // 
            this.petitionRF_CHSTableAdapter1.ClearBeforeFill = true;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource3.Name = "BMtriffDataSet_PetitionRFDataTable";
            reportDataSource3.Value = this.petitionRFDataTableBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewer1.LocalReport.EnableExternalImages = true;
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "LawtechPTSystem.Report.PetitionRF.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(550, 695);
            this.reportViewer1.TabIndex = 18;
            this.reportViewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth;
            // 
            // reportViewer2
            // 
            this.reportViewer2.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource2.Name = "BMtriffDataSet_PetitionRF_EN";
            reportDataSource2.Value = this.petitionRFENBindingSource1;
            this.reportViewer2.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer2.LocalReport.EnableExternalImages = true;
            this.reportViewer2.LocalReport.ReportEmbeddedResource = "LawtechPTSystem.Report.PetitionENRF.rdlc";
            this.reportViewer2.Location = new System.Drawing.Point(0, 0);
            this.reportViewer2.Name = "reportViewer2";
            this.reportViewer2.Size = new System.Drawing.Size(550, 695);
            this.reportViewer2.TabIndex = 19;
            this.reportViewer2.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth;
            // 
            // reportViewer3
            // 
            this.reportViewer3.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "BMtriffDataSet_PetitionRF_CHS";
            reportDataSource1.Value = this.bindingSource1;
            this.reportViewer3.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer3.LocalReport.EnableExternalImages = true;
            this.reportViewer3.LocalReport.ReportEmbeddedResource = "LawtechPTSystem.Report.PetitionRF_CHS.rdlc";
            this.reportViewer3.Location = new System.Drawing.Point(0, 0);
            this.reportViewer3.Name = "reportViewer3";
            this.reportViewer3.Size = new System.Drawing.Size(550, 695);
            this.reportViewer3.TabIndex = 20;
            this.reportViewer3.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.reportViewer3);
            this.panel1.Controls.Add(this.reportViewer2);
            this.panel1.Controls.Add(this.reportViewer1);
            this.panel1.Location = new System.Drawing.Point(4, 41);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(550, 695);
            this.panel1.TabIndex = 19;
            // 
            // PetitionMF
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(236)))), ((int)(((byte)(247)))));
            this.CancelButton = this.button1;
            this.ClientSize = new System.Drawing.Size(1055, 741);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "PetitionMF";
            this.Text = "申請需知";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.petitionRFDataTableBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bMTriffDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.petitionRFENBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.subjectBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.paragraphTBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SubjectBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.paragraphTBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QS_DataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.countryTBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Petition)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.petitionTBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Subject)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.subjectTBindingSource)).EndInit();
            this.contextMenuStrip2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.petitionSubjectTBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Paragraph)).EndInit();
            this.contextMenuStrip3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.petitionRFENBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kindTBindingSource)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer_list.Panel1.ResumeLayout(false);
            this.splitContainer_list.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_list)).EndInit();
            this.splitContainer_list.ResumeLayout(false);
            this.splitContainer_Content.Panel1.ResumeLayout(false);
            this.splitContainer_Content.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_Content)).EndInit();
            this.splitContainer_Content.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox_Country;
        private QS_DataSet QS_DataSet1;
        private System.Windows.Forms.BindingSource countryTBindingSource;
        private LawtechPTSystem.QS_DataSetTableAdapters.CountryTTableAdapter countryTTableAdapter;
        private System.Windows.Forms.DataGridView dataGridView_Petition;
        
        
        private System.Windows.Forms.DataGridView dataGridView_Subject;
        private System.Windows.Forms.DataGridView dataGridView_Paragraph;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem AddPetition;
        private System.Windows.Forms.ToolStripMenuItem DelPetition;
        private System.Windows.Forms.BindingSource petitionTBindingSource;
        private LawtechPTSystem.QS_DataSetTableAdapters.PetitionTTableAdapter petitionTTableAdapter;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip2;
        private System.Windows.Forms.ToolStripMenuItem AddSubject;
        private System.Windows.Forms.ToolStripMenuItem Delsubject;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip3;
        private System.Windows.Forms.ToolStripMenuItem AddParag;
        private System.Windows.Forms.ToolStripMenuItem DelParagraph;
        private System.Windows.Forms.ToolStripMenuItem CopyParagraph;
        private System.Windows.Forms.ToolStripMenuItem PasteParagraph;
        private System.Windows.Forms.ToolStripMenuItem ParagraphDetail;
        private System.Windows.Forms.BindingSource petitionSubjectTBindingSource;
        private LawtechPTSystem.QS_DataSetTableAdapters.PetitionSubjectTTableAdapter _PetitionSubjectTTableAdapter;
        private System.Windows.Forms.BindingSource paragraphTBindingSource;
        private LawtechPTSystem.QS_DataSetTableAdapters.ParagraphTTableAdapter paragraphTTableAdapter;
        private System.Windows.Forms.Button but_Show;
        private System.Windows.Forms.Button but_ShowEN;
      
        private System.Windows.Forms.BindingSource subjectTBindingSource;
        private LawtechPTSystem.QS_DataSetTableAdapters.SubjectTTableAdapter subjectTTableAdapter;
        private System.Windows.Forms.BindingSource SubjectBindingSource;
        private LawtechPTSystem.Report.BMtriffDataSet bMTriffDataSet1;
        private LawtechPTSystem.Report.BMtriffDataSetTableAdapters.SubjectTableAdapter SubjectTableAdapter;
        private System.Windows.Forms.BindingSource subjectBindingSource1;
        private System.Windows.Forms.BindingSource paragraphTBindingSource1;
        private LawtechPTSystem.Report.BMtriffDataSetTableAdapters.ParagraphTTableAdapter paragraphTTableAdapter1;
        private System.Windows.Forms.BindingSource petitionRFDataTableBindingSource;
        private LawtechPTSystem.Report.BMtriffDataSetTableAdapters.PetitionRFDataTableTableAdapter petitionRFDataTableTableAdapter;
        private System.Windows.Forms.BindingSource petitionRFENBindingSource;
        private System.Windows.Forms.BindingSource petitionRFENBindingSource1;
        private LawtechPTSystem.Report.BMtriffDataSetTableAdapters.PetitionRF_ENTableAdapter petitionRF_ENTableAdapter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox_kind;
        private System.Windows.Forms.BindingSource kindTBindingSource;
        private LawtechPTSystem.QS_DataSetTableAdapters.KindTTableAdapter kindTTableAdapter;
        private System.Windows.Forms.ToolStripMenuItem SubjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CopySubjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem PasteSubjectToolStripMenuItem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripMenuItem UploadToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridViewTextBoxColumn PetitionName;
        private System.Windows.Forms.DataGridViewTextBoxColumn PetitionNameEN;
        private System.Windows.Forms.DataGridViewTextBoxColumn PetitionNameCHS;
        private System.Windows.Forms.DataGridViewTextBoxColumn Kind;
        private System.Windows.Forms.DataGridViewTextBoxColumn Country;
        private System.Windows.Forms.DataGridViewTextBoxColumn PID;
        private System.Windows.Forms.DataGridViewTextBoxColumn petitionNameENDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn petitionNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn countryDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn kindDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button but_ShowCHS;
        private LawtechPTSystem.Report.BMtriffDataSetTableAdapters.PetitionRF_CHSTableAdapter petitionRF_CHSTableAdapter1;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.SplitContainer splitContainer_list;
        private System.Windows.Forms.SplitContainer splitContainer_Content;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.DataGridViewTextBoxColumn pSIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn sortDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn SID;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubjectName;
        private System.Windows.Forms.DataGridViewTextBoxColumn subjectNameENDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubjectNameCHS;
        private System.Windows.Forms.DataGridViewTextBoxColumn paraIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn sort;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsOpen;
        private System.Windows.Forms.DataGridViewTextBoxColumn paragraphDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ParagraphEN;
        private System.Windows.Forms.DataGridViewTextBoxColumn ParagraphCHS;
        private US.TagTitle tagTitle1;
        private US.TagTitle tagTitle2;
        private US.TagTitle tagTitle3;
        private System.Windows.Forms.Panel panel1;
        private ReportViewer reportViewer3;
        private ReportViewer reportViewer2;
        private ReportViewer reportViewer1;
    }
}

