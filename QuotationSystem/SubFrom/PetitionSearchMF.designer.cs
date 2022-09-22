using Microsoft.Reporting.WinForms;
namespace LawtechPTSystem.SubFrom
{
    partial class PetitionSearchMF
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PetitionSearchMF));
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.petitionRFDataTableBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bMtriffDataSet = new LawtechPTSystem.Report.BMtriffDataSet();
            this.PetitionRF_CHSBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.petitionRFENBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.but_ShowEN = new System.Windows.Forms.Button();
            this.but_Show = new System.Windows.Forms.Button();
            this.comboBox_kind = new System.Windows.Forms.ComboBox();
            this.kindTBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.qS_DataSet = new LawtechPTSystem.QS_DataSet();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox_Country = new System.Windows.Forms.ComboBox();
            this.countryTBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView_Petition = new System.Windows.Forms.DataGridView();
            this.PetitionName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PetitionNameEN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PetitionNameCHS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Kind = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Country = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kindTTableAdapter = new LawtechPTSystem.QS_DataSetTableAdapters.KindTTableAdapter();
            this.countryTTableAdapter = new LawtechPTSystem.QS_DataSetTableAdapters.CountryTTableAdapter();
            this.petitionRFDataTableTableAdapter = new LawtechPTSystem.Report.BMtriffDataSetTableAdapters.PetitionRFDataTableTableAdapter();
            this.petitionRF_ENTableAdapter = new LawtechPTSystem.Report.BMtriffDataSetTableAdapters.PetitionRF_ENTableAdapter();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView_Subject = new System.Windows.Forms.DataGridView();
            this.pSIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sortDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subjectNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subjectNameENDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubjectNameCHS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.petitionSubjectTBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.petitionSubjectTTableAdapter = new LawtechPTSystem.QS_DataSetTableAdapters.PetitionSubjectTTableAdapter();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.tagTitle1 = new LawtechPTSystem.US.TagTitle();
            this.tagTitle2 = new LawtechPTSystem.US.TagTitle();
            this.but_ShowCHS = new System.Windows.Forms.Button();
            this.petitionRF_CHSTableAdapter1 = new LawtechPTSystem.Report.BMtriffDataSetTableAdapters.PetitionRF_CHSTableAdapter();
            this.trademarkWorkReportTTableAdapter1 = new LawtechPTSystem.DataSet_TMTableAdapters.TrademarkWorkReportTTableAdapter();
            this.reportViewer2 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.reportViewer3 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.petitionRFDataTableBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bMtriffDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PetitionRF_CHSBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.petitionRFENBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kindTBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qS_DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.countryTBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Petition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Subject)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.petitionSubjectTBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // petitionRFDataTableBindingSource
            // 
            this.petitionRFDataTableBindingSource.DataMember = "PetitionRFDataTable";
            this.petitionRFDataTableBindingSource.DataSource = this.bMtriffDataSet;
            // 
            // bMtriffDataSet
            // 
            this.bMtriffDataSet.DataSetName = "BMtriffDataSet";
            this.bMtriffDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // PetitionRF_CHSBindingSource
            // 
            this.PetitionRF_CHSBindingSource.DataMember = "PetitionRF_CHS";
            this.PetitionRF_CHSBindingSource.DataSource = this.bMtriffDataSet;
            // 
            // petitionRFENBindingSource
            // 
            this.petitionRFENBindingSource.DataMember = "PetitionRF_EN";
            this.petitionRFENBindingSource.DataSource = this.bMtriffDataSet;
            // 
            // but_ShowEN
            // 
            this.but_ShowEN.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.but_ShowEN.Location = new System.Drawing.Point(207, 4);
            this.but_ShowEN.Margin = new System.Windows.Forms.Padding(4);
            this.but_ShowEN.Name = "but_ShowEN";
            this.but_ShowEN.Size = new System.Drawing.Size(100, 40);
            this.but_ShowEN.TabIndex = 21;
            this.but_ShowEN.Text = "英文";
            this.but_ShowEN.UseVisualStyleBackColor = true;
            this.but_ShowEN.Click += new System.EventHandler(this.but_ShowEN_Click);
            // 
            // but_Show
            // 
            this.but_Show.BackColor = System.Drawing.Color.RoyalBlue;
            this.but_Show.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.but_Show.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.but_Show.Location = new System.Drawing.Point(4, 4);
            this.but_Show.Margin = new System.Windows.Forms.Padding(4);
            this.but_Show.Name = "but_Show";
            this.but_Show.Size = new System.Drawing.Size(100, 40);
            this.but_Show.TabIndex = 20;
            this.but_Show.Text = "中文";
            this.but_Show.UseVisualStyleBackColor = false;
            this.but_Show.Click += new System.EventHandler(this.but_Show_Click);
            // 
            // comboBox_kind
            // 
            this.comboBox_kind.DataSource = this.kindTBindingSource;
            this.comboBox_kind.DisplayMember = "Kind";
            this.comboBox_kind.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_kind.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.comboBox_kind.FormattingEnabled = true;
            this.comboBox_kind.Location = new System.Drawing.Point(284, 8);
            this.comboBox_kind.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox_kind.Name = "comboBox_kind";
            this.comboBox_kind.Size = new System.Drawing.Size(152, 28);
            this.comboBox_kind.TabIndex = 26;
            this.comboBox_kind.ValueMember = "KindSN";
            this.comboBox_kind.SelectedIndexChanged += new System.EventHandler(this.comboBox_Country_SelectedIndexChanged);
            // 
            // kindTBindingSource
            // 
            this.kindTBindingSource.DataMember = "KindT";
            this.kindTBindingSource.DataSource = this.qS_DataSet;
            this.kindTBindingSource.Sort = "SN";
            // 
            // qS_DataSet
            // 
            this.qS_DataSet.DataSetName = "QS_DataSet";
            this.qS_DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.label2.Location = new System.Drawing.Point(241, 12);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 20);
            this.label2.TabIndex = 25;
            this.label2.Text = "種類";
            // 
            // comboBox_Country
            // 
            this.comboBox_Country.DataSource = this.countryTBindingSource;
            this.comboBox_Country.DisplayMember = "Country";
            this.comboBox_Country.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.comboBox_Country.FormattingEnabled = true;
            this.comboBox_Country.Location = new System.Drawing.Point(43, 8);
            this.comboBox_Country.Margin = new System.Windows.Forms.Padding(4);
            this.comboBox_Country.Name = "comboBox_Country";
            this.comboBox_Country.Size = new System.Drawing.Size(174, 28);
            this.comboBox_Country.TabIndex = 24;
            this.comboBox_Country.ValueMember = "CountrySymbol";
            this.comboBox_Country.SelectedIndexChanged += new System.EventHandler(this.comboBox_Country_SelectedIndexChanged);
            // 
            // countryTBindingSource
            // 
            this.countryTBindingSource.DataMember = "CountryT";
            this.countryTBindingSource.DataSource = this.qS_DataSet;
            this.countryTBindingSource.Sort = "SN";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(5, 12);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 20);
            this.label1.TabIndex = 23;
            this.label1.Text = "國別";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // dataGridView_Petition
            // 
            this.dataGridView_Petition.AllowUserToAddRows = false;
            this.dataGridView_Petition.AllowUserToDeleteRows = false;
            this.dataGridView_Petition.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LemonChiffon;
            this.dataGridView_Petition.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView_Petition.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView_Petition.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Petition.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.PetitionName,
            this.PetitionNameEN,
            this.PetitionNameCHS,
            this.Kind,
            this.Country,
            this.PID});
            this.dataGridView_Petition.Location = new System.Drawing.Point(0, 30);
            this.dataGridView_Petition.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView_Petition.Name = "dataGridView_Petition";
            this.dataGridView_Petition.ReadOnly = true;
            this.dataGridView_Petition.RowTemplate.Height = 24;
            this.dataGridView_Petition.Size = new System.Drawing.Size(432, 382);
            this.dataGridView_Petition.TabIndex = 27;
            this.dataGridView_Petition.SelectionChanged += new System.EventHandler(this.dataGridView_Petition_SelectionChanged);
            // 
            // PetitionName
            // 
            this.PetitionName.DataPropertyName = "PetitionName";
            this.PetitionName.HeaderText = "申請需知";
            this.PetitionName.Name = "PetitionName";
            this.PetitionName.ReadOnly = true;
            this.PetitionName.Width = 200;
            // 
            // PetitionNameEN
            // 
            this.PetitionNameEN.DataPropertyName = "PetitionNameEN";
            this.PetitionNameEN.HeaderText = "申請需知(英)";
            this.PetitionNameEN.Name = "PetitionNameEN";
            this.PetitionNameEN.ReadOnly = true;
            this.PetitionNameEN.Width = 150;
            // 
            // PetitionNameCHS
            // 
            this.PetitionNameCHS.DataPropertyName = "PetitionNameCHS";
            this.PetitionNameCHS.HeaderText = "申請需知(簡)";
            this.PetitionNameCHS.Name = "PetitionNameCHS";
            this.PetitionNameCHS.ReadOnly = true;
            this.PetitionNameCHS.Width = 150;
            // 
            // Kind
            // 
            this.Kind.DataPropertyName = "Kind";
            this.Kind.HeaderText = "Kind";
            this.Kind.Name = "Kind";
            this.Kind.ReadOnly = true;
            this.Kind.Visible = false;
            // 
            // Country
            // 
            this.Country.DataPropertyName = "Country";
            this.Country.HeaderText = "Country";
            this.Country.Name = "Country";
            this.Country.ReadOnly = true;
            this.Country.Visible = false;
            // 
            // PID
            // 
            this.PID.DataPropertyName = "PID";
            this.PID.HeaderText = "PID";
            this.PID.Name = "PID";
            this.PID.ReadOnly = true;
            this.PID.Visible = false;
            // 
            // kindTTableAdapter
            // 
            this.kindTTableAdapter.ClearBeforeFill = true;
            // 
            // countryTTableAdapter
            // 
            this.countryTTableAdapter.ClearBeforeFill = true;
            // 
            // petitionRFDataTableTableAdapter
            // 
            this.petitionRFDataTableTableAdapter.ClearBeforeFill = true;
            // 
            // petitionRF_ENTableAdapter
            // 
            this.petitionRF_ENTableAdapter.ClearBeforeFill = true;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackgroundImage = global::LawtechPTSystem.Properties.Resources.btnCancel;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button1.Location = new System.Drawing.Point(656, 12);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 32);
            this.button1.TabIndex = 28;
            this.button1.Text = "關閉";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView_Subject
            // 
            this.dataGridView_Subject.AllowUserToAddRows = false;
            this.dataGridView_Subject.AllowUserToDeleteRows = false;
            this.dataGridView_Subject.AllowUserToOrderColumns = true;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.LemonChiffon;
            this.dataGridView_Subject.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView_Subject.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView_Subject.AutoGenerateColumns = false;
            this.dataGridView_Subject.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Subject.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.pSIDDataGridViewTextBoxColumn,
            this.sIDDataGridViewTextBoxColumn,
            this.sortDataGridViewTextBoxColumn,
            this.subjectNameDataGridViewTextBoxColumn,
            this.subjectNameENDataGridViewTextBoxColumn,
            this.SubjectNameCHS});
            this.dataGridView_Subject.DataSource = this.petitionSubjectTBindingSource;
            this.dataGridView_Subject.Location = new System.Drawing.Point(0, 29);
            this.dataGridView_Subject.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView_Subject.Name = "dataGridView_Subject";
            this.dataGridView_Subject.RowTemplate.Height = 24;
            this.dataGridView_Subject.Size = new System.Drawing.Size(432, 424);
            this.dataGridView_Subject.TabIndex = 29;
            // 
            // pSIDDataGridViewTextBoxColumn
            // 
            this.pSIDDataGridViewTextBoxColumn.DataPropertyName = "PSID";
            this.pSIDDataGridViewTextBoxColumn.HeaderText = "PSID";
            this.pSIDDataGridViewTextBoxColumn.Name = "pSIDDataGridViewTextBoxColumn";
            this.pSIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.pSIDDataGridViewTextBoxColumn.Visible = false;
            // 
            // sIDDataGridViewTextBoxColumn
            // 
            this.sIDDataGridViewTextBoxColumn.DataPropertyName = "SID";
            this.sIDDataGridViewTextBoxColumn.HeaderText = "SID";
            this.sIDDataGridViewTextBoxColumn.Name = "sIDDataGridViewTextBoxColumn";
            this.sIDDataGridViewTextBoxColumn.Visible = false;
            // 
            // sortDataGridViewTextBoxColumn
            // 
            this.sortDataGridViewTextBoxColumn.DataPropertyName = "sort";
            this.sortDataGridViewTextBoxColumn.HeaderText = "排序";
            this.sortDataGridViewTextBoxColumn.Name = "sortDataGridViewTextBoxColumn";
            this.sortDataGridViewTextBoxColumn.Width = 60;
            // 
            // subjectNameDataGridViewTextBoxColumn
            // 
            this.subjectNameDataGridViewTextBoxColumn.DataPropertyName = "SubjectName";
            this.subjectNameDataGridViewTextBoxColumn.HeaderText = "大綱名稱";
            this.subjectNameDataGridViewTextBoxColumn.Name = "subjectNameDataGridViewTextBoxColumn";
            this.subjectNameDataGridViewTextBoxColumn.Width = 150;
            // 
            // subjectNameENDataGridViewTextBoxColumn
            // 
            this.subjectNameENDataGridViewTextBoxColumn.DataPropertyName = "SubjectNameEN";
            this.subjectNameENDataGridViewTextBoxColumn.HeaderText = "大綱名稱(英)";
            this.subjectNameENDataGridViewTextBoxColumn.Name = "subjectNameENDataGridViewTextBoxColumn";
            this.subjectNameENDataGridViewTextBoxColumn.Width = 180;
            // 
            // SubjectNameCHS
            // 
            this.SubjectNameCHS.DataPropertyName = "SubjectNameCHS";
            this.SubjectNameCHS.HeaderText = "大綱名稱(簡)";
            this.SubjectNameCHS.Name = "SubjectNameCHS";
            this.SubjectNameCHS.Width = 120;
            // 
            // petitionSubjectTBindingSource
            // 
            this.petitionSubjectTBindingSource.DataMember = "PetitionSubjectT";
            this.petitionSubjectTBindingSource.DataSource = this.qS_DataSet;
            // 
            // petitionSubjectTTableAdapter
            // 
            this.petitionSubjectTTableAdapter.ClearBeforeFill = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.BackColor = System.Drawing.Color.Transparent;
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(5, 3);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            this.splitContainer1.Panel1.Controls.Add(this.comboBox_kind);
            this.splitContainer1.Panel1.Controls.Add(this.comboBox_Country);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.but_ShowCHS);
            this.splitContainer1.Panel2.Controls.Add(this.button1);
            this.splitContainer1.Panel2.Controls.Add(this.but_Show);
            this.splitContainer1.Panel2.Controls.Add(this.but_ShowEN);
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Size = new System.Drawing.Size(1231, 939);
            this.splitContainer1.SplitterDistance = 442;
            this.splitContainer1.SplitterWidth = 7;
            this.splitContainer1.TabIndex = 30;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer2.Location = new System.Drawing.Point(4, 42);
            this.splitContainer2.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.dataGridView_Petition);
            this.splitContainer2.Panel1.Controls.Add(this.tagTitle1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.dataGridView_Subject);
            this.splitContainer2.Panel2.Controls.Add(this.tagTitle2);
            this.splitContainer2.Size = new System.Drawing.Size(432, 891);
            this.splitContainer2.SplitterDistance = 412;
            this.splitContainer2.SplitterWidth = 6;
            this.splitContainer2.TabIndex = 0;
            // 
            // tagTitle1
            // 
            this.tagTitle1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tagTitle1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tagTitle1.BackgroundImage")));
            this.tagTitle1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tagTitle1.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tagTitle1.Location = new System.Drawing.Point(0, 3);
            this.tagTitle1.Margin = new System.Windows.Forms.Padding(0);
            this.tagTitle1.Name = "tagTitle1";
            this.tagTitle1.Size = new System.Drawing.Size(432, 35);
            this.tagTitle1.TabIndex = 1046;
            this.tagTitle1.TagTitleStyle = "Style1";
            this.tagTitle1.TitleLableText = "申．請．需．知．清．單";
            this.tagTitle1.Load += new System.EventHandler(this.tagTitle1_Load);
            // 
            // tagTitle2
            // 
            this.tagTitle2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tagTitle2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tagTitle2.BackgroundImage")));
            this.tagTitle2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tagTitle2.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tagTitle2.Location = new System.Drawing.Point(0, 0);
            this.tagTitle2.Margin = new System.Windows.Forms.Padding(0);
            this.tagTitle2.Name = "tagTitle2";
            this.tagTitle2.Size = new System.Drawing.Size(432, 36);
            this.tagTitle2.TabIndex = 1047;
            this.tagTitle2.TagTitleStyle = "Style1";
            this.tagTitle2.TitleLableText = "申．請．需．知．大．綱";
            // 
            // but_ShowCHS
            // 
            this.but_ShowCHS.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.but_ShowCHS.Location = new System.Drawing.Point(105, 4);
            this.but_ShowCHS.Margin = new System.Windows.Forms.Padding(4);
            this.but_ShowCHS.Name = "but_ShowCHS";
            this.but_ShowCHS.Size = new System.Drawing.Size(100, 40);
            this.but_ShowCHS.TabIndex = 29;
            this.but_ShowCHS.Text = "簡體";
            this.but_ShowCHS.UseVisualStyleBackColor = true;
            this.but_ShowCHS.Click += new System.EventHandler(this.but_ShowCHS_Click);
            // 
            // petitionRF_CHSTableAdapter1
            // 
            this.petitionRF_CHSTableAdapter1.ClearBeforeFill = true;
            // 
            // trademarkWorkReportTTableAdapter1
            // 
            this.trademarkWorkReportTTableAdapter1.ClearBeforeFill = true;
            // 
            // reportViewer2
            // 
            this.reportViewer2.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource3.Name = "BMtriffDataSet_PetitionRF_EN";
            reportDataSource3.Value = this.petitionRFENBindingSource;
            this.reportViewer2.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewer2.LocalReport.EnableExternalImages = true;
            this.reportViewer2.LocalReport.ReportEmbeddedResource = "LawtechPTSystem.Report.PetitionENRF.rdlc";
            this.reportViewer2.Location = new System.Drawing.Point(0, 0);
            this.reportViewer2.Margin = new System.Windows.Forms.Padding(4);
            this.reportViewer2.Name = "reportViewer2";
            this.reportViewer2.Size = new System.Drawing.Size(772, 868);
            this.reportViewer2.TabIndex = 19;
            this.reportViewer2.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth;
            // 
            // reportViewer3
            // 
            this.reportViewer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer3.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            reportDataSource2.Name = "BMtriffDataSet_PetitionRF_CHS";
            reportDataSource2.Value = this.PetitionRF_CHSBindingSource;
            this.reportViewer3.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer3.LocalReport.EnableExternalImages = true;
            this.reportViewer3.LocalReport.ReportEmbeddedResource = "LawtechPTSystem.Report.PetitionRF_CHS.rdlc";
            this.reportViewer3.Location = new System.Drawing.Point(0, 0);
            this.reportViewer3.Margin = new System.Windows.Forms.Padding(4);
            this.reportViewer3.Name = "reportViewer3";
            this.reportViewer3.Size = new System.Drawing.Size(772, 868);
            this.reportViewer3.TabIndex = 20;
            this.reportViewer3.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "BMtriffDataSet_PetitionRFDataTable";
            reportDataSource1.Value = this.petitionRFDataTableBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.EnableExternalImages = true;
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "LawtechPTSystem.Report.PetitionRF.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Margin = new System.Windows.Forms.Padding(4);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(772, 868);
            this.reportViewer1.TabIndex = 18;
            this.reportViewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.reportViewer1);
            this.panel1.Controls.Add(this.reportViewer3);
            this.panel1.Controls.Add(this.reportViewer2);
            this.panel1.Location = new System.Drawing.Point(4, 45);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(772, 868);
            this.panel1.TabIndex = 22;
            // 
            // PetitionSearchMF
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(236)))), ((int)(((byte)(247)))));
            this.CancelButton = this.button1;
            this.ClientSize = new System.Drawing.Size(1240, 946);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "PetitionSearchMF";
            this.Text = "申請需知";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PetitionSearchMF_FormClosed);
            this.Load += new System.EventHandler(this.PetitionSearchMF_Load);
            ((System.ComponentModel.ISupportInitialize)(this.petitionRFDataTableBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bMtriffDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PetitionRF_CHSBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.petitionRFENBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kindTBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qS_DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.countryTBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Petition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Subject)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.petitionSubjectTBindingSource)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button but_ShowEN;
        private System.Windows.Forms.Button but_Show;
        private System.Windows.Forms.ComboBox comboBox_kind;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox_Country;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView_Petition;
        private QS_DataSet qS_DataSet;
        private System.Windows.Forms.BindingSource kindTBindingSource;
        private LawtechPTSystem.QS_DataSetTableAdapters.KindTTableAdapter kindTTableAdapter;
        private System.Windows.Forms.BindingSource countryTBindingSource;
        private LawtechPTSystem.QS_DataSetTableAdapters.CountryTTableAdapter countryTTableAdapter;
        private System.Windows.Forms.BindingSource petitionRFENBindingSource;
        private LawtechPTSystem.Report.BMtriffDataSet bMtriffDataSet;
        private System.Windows.Forms.BindingSource petitionRFDataTableBindingSource;
        private LawtechPTSystem.Report.BMtriffDataSetTableAdapters.PetitionRFDataTableTableAdapter petitionRFDataTableTableAdapter;
        private LawtechPTSystem.Report.BMtriffDataSetTableAdapters.PetitionRF_ENTableAdapter petitionRF_ENTableAdapter;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView_Subject;
        private System.Windows.Forms.BindingSource petitionSubjectTBindingSource;
        private LawtechPTSystem.QS_DataSetTableAdapters.PetitionSubjectTTableAdapter petitionSubjectTTableAdapter;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Button but_ShowCHS;
        private System.Windows.Forms.BindingSource PetitionRF_CHSBindingSource;
        private LawtechPTSystem.Report.BMtriffDataSetTableAdapters.PetitionRF_CHSTableAdapter petitionRF_CHSTableAdapter1;
        private US.TagTitle tagTitle1;
        private US.TagTitle tagTitle2;
        private System.Windows.Forms.DataGridViewTextBoxColumn PetitionName;
        private System.Windows.Forms.DataGridViewTextBoxColumn PetitionNameEN;
        private System.Windows.Forms.DataGridViewTextBoxColumn PetitionNameCHS;
        private System.Windows.Forms.DataGridViewTextBoxColumn Kind;
        private System.Windows.Forms.DataGridViewTextBoxColumn Country;
        private System.Windows.Forms.DataGridViewTextBoxColumn PID;
        private System.Windows.Forms.DataGridViewTextBoxColumn pSIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sortDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn subjectNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn subjectNameENDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubjectNameCHS;
        private DataSet_TMTableAdapters.TrademarkWorkReportTTableAdapter trademarkWorkReportTTableAdapter1;
        private System.Windows.Forms.Panel panel1;
        private ReportViewer reportViewer1;
        private ReportViewer reportViewer3;
        private ReportViewer reportViewer2;
    }
}