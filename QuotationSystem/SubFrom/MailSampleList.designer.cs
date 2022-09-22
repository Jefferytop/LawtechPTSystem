namespace LawtechPTSystem.SubFrom
{
    partial class MailSampleList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MailSampleList));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox_EmailSampleType = new System.Windows.Forms.ComboBox();
            this.emailSampleTypeTBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet_Email = new LawtechPTSystem.DataSet_Email();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.emailSampleTBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.emailSampleTBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton_Add = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_Edit = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_Del = new System.Windows.Forms.ToolStripButton();
            this.emailSampleTDataGridView = new System.Windows.Forms.DataGridView();
            this.Sort = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SampleName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MailSubject = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MailPriority = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MailFormat = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.createDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WorkerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Format = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MailBody = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ESID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip_EmailSample = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem_AddSample = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_EditSample = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_DelSample = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txt_Format = new System.Windows.Forms.TextBox();
            this.txt_Priority = new System.Windows.Forms.TextBox();
            this.WebBrowser_Body = new System.Windows.Forms.WebBrowser();
            this.label9 = new System.Windows.Forms.Label();
            this.txt_Subject = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_Body = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_SampleDescription = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_SampleName = new System.Windows.Forms.TextBox();
            this.but_Close = new System.Windows.Forms.Button();
            this.but_Refresh = new System.Windows.Forms.Button();
            this.emailSampleListTableAdapter = new LawtechPTSystem.DataSet_EmailTableAdapters.EmailSampleListTableAdapter();
            this.emailSampleTypeTTableAdapter = new LawtechPTSystem.DataSet_EmailTableAdapters.EmailSampleTypeTTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.emailSampleTypeTBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_Email)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.emailSampleTBindingNavigator)).BeginInit();
            this.emailSampleTBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.emailSampleTBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emailSampleTDataGridView)).BeginInit();
            this.contextMenuStrip_EmailSample.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(24, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 20);
            this.label2.TabIndex = 50;
            this.label2.Text = "範本類型";
            // 
            // comboBox_EmailSampleType
            // 
            this.comboBox_EmailSampleType.DataSource = this.emailSampleTypeTBindingSource;
            this.comboBox_EmailSampleType.DisplayMember = "TypeName";
            this.comboBox_EmailSampleType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_EmailSampleType.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.comboBox_EmailSampleType.FormattingEnabled = true;
            this.comboBox_EmailSampleType.Location = new System.Drawing.Point(103, 12);
            this.comboBox_EmailSampleType.Name = "comboBox_EmailSampleType";
            this.comboBox_EmailSampleType.Size = new System.Drawing.Size(276, 28);
            this.comboBox_EmailSampleType.TabIndex = 49;
            this.comboBox_EmailSampleType.ValueMember = "EmailSampleType";
            this.comboBox_EmailSampleType.SelectedIndexChanged += new System.EventHandler(this.comboBox_EmailSampleType_SelectedIndexChanged);
            // 
            // emailSampleTypeTBindingSource
            // 
            this.emailSampleTypeTBindingSource.DataMember = "EmailSampleTypeT";
            this.emailSampleTypeTBindingSource.DataSource = this.dataSet_Email;
            // 
            // dataSet_Email
            // 
            this.dataSet_Email.DataSetName = "DataSet_Email";
            this.dataSet_Email.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Location = new System.Drawing.Point(3, 46);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.emailSampleTBindingNavigator);
            this.splitContainer1.Panel1.Controls.Add(this.emailSampleTDataGridView);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel2.Controls.Add(this.label8);
            this.splitContainer1.Panel2.Controls.Add(this.txt_SampleDescription);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.txt_SampleName);
            this.splitContainer1.Size = new System.Drawing.Size(891, 544);
            this.splitContainer1.SplitterDistance = 382;
            this.splitContainer1.TabIndex = 51;
            // 
            // emailSampleTBindingNavigator
            // 
            this.emailSampleTBindingNavigator.AddNewItem = null;
            this.emailSampleTBindingNavigator.BindingSource = this.emailSampleTBindingSource;
            this.emailSampleTBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.emailSampleTBindingNavigator.DeleteItem = null;
            this.emailSampleTBindingNavigator.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.emailSampleTBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.toolStripButton_Add,
            this.toolStripButton_Edit,
            this.toolStripButton_Del});
            this.emailSampleTBindingNavigator.Location = new System.Drawing.Point(0, 517);
            this.emailSampleTBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.emailSampleTBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.emailSampleTBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.emailSampleTBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.emailSampleTBindingNavigator.Name = "emailSampleTBindingNavigator";
            this.emailSampleTBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.emailSampleTBindingNavigator.Size = new System.Drawing.Size(380, 25);
            this.emailSampleTBindingNavigator.TabIndex = 52;
            this.emailSampleTBindingNavigator.Text = "bindingNavigator1";
            this.emailSampleTBindingNavigator.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuStrip_EmailSample_ItemClicked);
            // 
            // emailSampleTBindingSource
            // 
            this.emailSampleTBindingSource.DataMember = "EmailSampleList";
            this.emailSampleTBindingSource.DataSource = this.dataSet_Email;
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(27, 22);
            this.bindingNavigatorCountItem.Text = "/{0}";
            this.bindingNavigatorCountItem.ToolTipText = "項目總數";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "移到最前面";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "移到上一個";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "位置";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 22);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "目前的位置";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "移到下一個";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "移到最後面";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton_Add
            // 
            this.toolStripButton_Add.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_Add.Image = global::LawtechPTSystem.Properties.Resources.Add;
            this.toolStripButton_Add.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Add.Name = "toolStripButton_Add";
            this.toolStripButton_Add.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_Add.Text = "新增範本";
            // 
            // toolStripButton_Edit
            // 
            this.toolStripButton_Edit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_Edit.Image = global::LawtechPTSystem.Properties.Resources.Edit;
            this.toolStripButton_Edit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Edit.Name = "toolStripButton_Edit";
            this.toolStripButton_Edit.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_Edit.Text = "編輯範本";
            // 
            // toolStripButton_Del
            // 
            this.toolStripButton_Del.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_Del.Image = global::LawtechPTSystem.Properties.Resources.delete;
            this.toolStripButton_Del.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Del.Name = "toolStripButton_Del";
            this.toolStripButton_Del.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_Del.Text = "刪除範本";
            // 
            // emailSampleTDataGridView
            // 
            this.emailSampleTDataGridView.AllowUserToAddRows = false;
            this.emailSampleTDataGridView.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Blue;
            this.emailSampleTDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.emailSampleTDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.emailSampleTDataGridView.AutoGenerateColumns = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.emailSampleTDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.emailSampleTDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.emailSampleTDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Sort,
            this.TypeName,
            this.SampleName,
            this.MailSubject,
            this.MailPriority,
            this.MailFormat,
            this.createDateDataGridViewTextBoxColumn,
            this.WorkerName,
            this.Format,
            this.MailBody,
            this.ESID});
            this.emailSampleTDataGridView.ContextMenuStrip = this.contextMenuStrip_EmailSample;
            this.emailSampleTDataGridView.DataSource = this.emailSampleTBindingSource;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Silver;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.emailSampleTDataGridView.DefaultCellStyle = dataGridViewCellStyle4;
            this.emailSampleTDataGridView.Location = new System.Drawing.Point(3, 3);
            this.emailSampleTDataGridView.Margin = new System.Windows.Forms.Padding(1);
            this.emailSampleTDataGridView.MultiSelect = false;
            this.emailSampleTDataGridView.Name = "emailSampleTDataGridView";
            this.emailSampleTDataGridView.ReadOnly = true;
            this.emailSampleTDataGridView.RowTemplate.Height = 24;
            this.emailSampleTDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.emailSampleTDataGridView.Size = new System.Drawing.Size(374, 513);
            this.emailSampleTDataGridView.TabIndex = 0;
            this.emailSampleTDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.emailSampleTDataGridView_CellDoubleClick);
            this.emailSampleTDataGridView.SelectionChanged += new System.EventHandler(this.emailSampleTDataGridView_SelectionChanged);
            // 
            // Sort
            // 
            this.Sort.DataPropertyName = "Sort";
            this.Sort.HeaderText = "排序";
            this.Sort.Name = "Sort";
            this.Sort.ReadOnly = true;
            this.Sort.Width = 60;
            // 
            // TypeName
            // 
            this.TypeName.DataPropertyName = "TypeName";
            this.TypeName.HeaderText = "範本類型";
            this.TypeName.Name = "TypeName";
            this.TypeName.ReadOnly = true;
            // 
            // SampleName
            // 
            this.SampleName.DataPropertyName = "SampleName";
            this.SampleName.HeaderText = "範本名稱";
            this.SampleName.Name = "SampleName";
            this.SampleName.ReadOnly = true;
            this.SampleName.Width = 130;
            // 
            // MailSubject
            // 
            this.MailSubject.DataPropertyName = "MailSubject";
            this.MailSubject.HeaderText = "郵件主旨";
            this.MailSubject.Name = "MailSubject";
            this.MailSubject.ReadOnly = true;
            this.MailSubject.Width = 160;
            // 
            // MailPriority
            // 
            this.MailPriority.DataPropertyName = "MailPriority";
            this.MailPriority.HeaderText = "郵件重要性";
            this.MailPriority.Name = "MailPriority";
            this.MailPriority.ReadOnly = true;
            // 
            // MailFormat
            // 
            this.MailFormat.DataPropertyName = "MailFormat";
            this.MailFormat.HeaderText = "郵件格式";
            this.MailFormat.Name = "MailFormat";
            this.MailFormat.ReadOnly = true;
            // 
            // createDateDataGridViewTextBoxColumn
            // 
            this.createDateDataGridViewTextBoxColumn.DataPropertyName = "CreateDate";
            dataGridViewCellStyle3.Format = "g";
            dataGridViewCellStyle3.NullValue = null;
            this.createDateDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.createDateDataGridViewTextBoxColumn.HeaderText = "建立時間";
            this.createDateDataGridViewTextBoxColumn.Name = "createDateDataGridViewTextBoxColumn";
            this.createDateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // WorkerName
            // 
            this.WorkerName.DataPropertyName = "WorkerName";
            this.WorkerName.HeaderText = "建立者";
            this.WorkerName.Name = "WorkerName";
            this.WorkerName.ReadOnly = true;
            // 
            // Format
            // 
            this.Format.DataPropertyName = "Format";
            this.Format.HeaderText = "Format";
            this.Format.Name = "Format";
            this.Format.ReadOnly = true;
            this.Format.Visible = false;
            // 
            // MailBody
            // 
            this.MailBody.DataPropertyName = "MailBody";
            this.MailBody.HeaderText = "MailBody";
            this.MailBody.Name = "MailBody";
            this.MailBody.ReadOnly = true;
            this.MailBody.Visible = false;
            // 
            // ESID
            // 
            this.ESID.DataPropertyName = "ESID";
            this.ESID.HeaderText = "ESID";
            this.ESID.Name = "ESID";
            this.ESID.ReadOnly = true;
            this.ESID.Visible = false;
            // 
            // contextMenuStrip_EmailSample
            // 
            this.contextMenuStrip_EmailSample.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_AddSample,
            this.toolStripMenuItem_EditSample,
            this.toolStripMenuItem_DelSample});
            this.contextMenuStrip_EmailSample.Name = "contextMenuStrip_EmailSample";
            this.contextMenuStrip_EmailSample.Size = new System.Drawing.Size(123, 70);
            this.contextMenuStrip_EmailSample.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuStrip_EmailSample_ItemClicked);
            // 
            // toolStripMenuItem_AddSample
            // 
            this.toolStripMenuItem_AddSample.Image = global::LawtechPTSystem.Properties.Resources.Add;
            this.toolStripMenuItem_AddSample.Name = "toolStripMenuItem_AddSample";
            this.toolStripMenuItem_AddSample.Size = new System.Drawing.Size(122, 22);
            this.toolStripMenuItem_AddSample.Text = "新增範本";
            // 
            // toolStripMenuItem_EditSample
            // 
            this.toolStripMenuItem_EditSample.Image = global::LawtechPTSystem.Properties.Resources.Edit;
            this.toolStripMenuItem_EditSample.Name = "toolStripMenuItem_EditSample";
            this.toolStripMenuItem_EditSample.Size = new System.Drawing.Size(122, 22);
            this.toolStripMenuItem_EditSample.Text = "編輯範本";
            // 
            // toolStripMenuItem_DelSample
            // 
            this.toolStripMenuItem_DelSample.Image = global::LawtechPTSystem.Properties.Resources.delete;
            this.toolStripMenuItem_DelSample.Name = "toolStripMenuItem_DelSample";
            this.toolStripMenuItem_DelSample.Size = new System.Drawing.Size(122, 22);
            this.toolStripMenuItem_DelSample.Text = "刪除範本";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.txt_Format);
            this.groupBox1.Controls.Add(this.txt_Priority);
            this.groupBox1.Controls.Add(this.WebBrowser_Body);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txt_Subject);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.textBox_Body);
            this.groupBox1.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox1.Location = new System.Drawing.Point(5, 103);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(495, 432);
            this.groupBox1.TabIndex = 61;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "E Mail 範本";
            // 
            // txt_Format
            // 
            this.txt_Format.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.txt_Format.Location = new System.Drawing.Point(339, 55);
            this.txt_Format.Name = "txt_Format";
            this.txt_Format.Size = new System.Drawing.Size(147, 29);
            this.txt_Format.TabIndex = 64;
            // 
            // txt_Priority
            // 
            this.txt_Priority.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.txt_Priority.Location = new System.Drawing.Point(98, 55);
            this.txt_Priority.Name = "txt_Priority";
            this.txt_Priority.Size = new System.Drawing.Size(96, 29);
            this.txt_Priority.TabIndex = 63;
            // 
            // WebBrowser_Body
            // 
            this.WebBrowser_Body.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.WebBrowser_Body.IsWebBrowserContextMenuEnabled = false;
            this.WebBrowser_Body.Location = new System.Drawing.Point(98, 89);
            this.WebBrowser_Body.MinimumSize = new System.Drawing.Size(20, 20);
            this.WebBrowser_Body.Name = "WebBrowser_Body";
            this.WebBrowser_Body.Size = new System.Drawing.Size(388, 337);
            this.WebBrowser_Body.TabIndex = 51;
            this.WebBrowser_Body.Url = new System.Uri("http://www.google.com.tw", System.UriKind.Absolute);
            this.WebBrowser_Body.WebBrowserShortcutsEnabled = false;
            this.WebBrowser_Body.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.WebBrowser_Body_DocumentCompleted);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label9.Location = new System.Drawing.Point(260, 59);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(73, 20);
            this.label9.TabIndex = 48;
            this.label9.Text = "郵件格式";
            // 
            // txt_Subject
            // 
            this.txt_Subject.AllowDrop = true;
            this.txt_Subject.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_Subject.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.txt_Subject.Location = new System.Drawing.Point(98, 22);
            this.txt_Subject.Name = "txt_Subject";
            this.txt_Subject.Size = new System.Drawing.Size(388, 29);
            this.txt_Subject.TabIndex = 42;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.Location = new System.Drawing.Point(19, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 20);
            this.label4.TabIndex = 43;
            this.label4.Text = "郵件內文";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(19, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 20);
            this.label3.TabIndex = 41;
            this.label3.Text = "郵件主旨";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label5.Location = new System.Drawing.Point(3, 59);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 20);
            this.label5.TabIndex = 45;
            this.label5.Text = "郵件重要性";
            // 
            // textBox_Body
            // 
            this.textBox_Body.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_Body.Location = new System.Drawing.Point(100, 89);
            this.textBox_Body.Multiline = true;
            this.textBox_Body.Name = "textBox_Body";
            this.textBox_Body.Size = new System.Drawing.Size(386, 337);
            this.textBox_Body.TabIndex = 50;
            this.textBox_Body.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label8.Location = new System.Drawing.Point(13, 48);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 20);
            this.label8.TabIndex = 59;
            this.label8.Text = "說明描述";
            // 
            // txt_SampleDescription
            // 
            this.txt_SampleDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_SampleDescription.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.txt_SampleDescription.Location = new System.Drawing.Point(88, 44);
            this.txt_SampleDescription.Multiline = true;
            this.txt_SampleDescription.Name = "txt_SampleDescription";
            this.txt_SampleDescription.Size = new System.Drawing.Size(406, 53);
            this.txt_SampleDescription.TabIndex = 60;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(13, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 20);
            this.label1.TabIndex = 55;
            this.label1.Text = "範本名稱";
            // 
            // txt_SampleName
            // 
            this.txt_SampleName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_SampleName.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.txt_SampleName.Location = new System.Drawing.Point(88, 11);
            this.txt_SampleName.Name = "txt_SampleName";
            this.txt_SampleName.Size = new System.Drawing.Size(406, 29);
            this.txt_SampleName.TabIndex = 56;
            // 
            // but_Close
            // 
            this.but_Close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.but_Close.BackgroundImage = global::LawtechPTSystem.Properties.Resources.btnCancel;
            this.but_Close.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.but_Close.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.but_Close.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.but_Close.ForeColor = System.Drawing.Color.Black;
            this.but_Close.Location = new System.Drawing.Point(794, 12);
            this.but_Close.Name = "but_Close";
            this.but_Close.Size = new System.Drawing.Size(100, 30);
            this.but_Close.TabIndex = 501;
            this.but_Close.Text = "關   閉";
            this.but_Close.UseVisualStyleBackColor = true;
            this.but_Close.Click += new System.EventHandler(this.but_Close_Click);
            // 
            // but_Refresh
            // 
            this.but_Refresh.BackgroundImage = global::LawtechPTSystem.Properties.Resources.btnComfirm;
            this.but_Refresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.but_Refresh.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.but_Refresh.ForeColor = System.Drawing.Color.Black;
            this.but_Refresh.Image = global::LawtechPTSystem.Properties.Resources.UpdateData;
            this.but_Refresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.but_Refresh.Location = new System.Drawing.Point(385, 11);
            this.but_Refresh.Name = "but_Refresh";
            this.but_Refresh.Size = new System.Drawing.Size(127, 30);
            this.but_Refresh.TabIndex = 502;
            this.but_Refresh.Text = "更新";
            this.but_Refresh.UseVisualStyleBackColor = true;
            this.but_Refresh.Click += new System.EventHandler(this.but_Refresh_Click);
            // 
            // emailSampleListTableAdapter
            // 
            this.emailSampleListTableAdapter.ClearBeforeFill = true;
            // 
            // emailSampleTypeTTableAdapter
            // 
            this.emailSampleTypeTTableAdapter.ClearBeforeFill = true;
            // 
            // MailSampleList
            // 
            this.AcceptButton = this.but_Refresh;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(236)))), ((int)(((byte)(247)))));
            this.CancelButton = this.but_Close;
            this.ClientSize = new System.Drawing.Size(897, 594);
            this.Controls.Add(this.but_Refresh);
            this.Controls.Add(this.but_Close);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox_EmailSampleType);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MailSampleList";
            this.Text = "Email範本清單";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MailSampleList_FormClosed);
            this.Load += new System.EventHandler(this.MailSampleList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.emailSampleTypeTBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_Email)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.emailSampleTBindingNavigator)).EndInit();
            this.emailSampleTBindingNavigator.ResumeLayout(false);
            this.emailSampleTBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.emailSampleTBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emailSampleTDataGridView)).EndInit();
            this.contextMenuStrip_EmailSample.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox_EmailSampleType;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private DataSet_Email dataSet_Email;
        private System.Windows.Forms.BindingSource emailSampleTBindingSource;
        private System.Windows.Forms.BindingNavigator emailSampleTBindingNavigator;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.DataGridView emailSampleTDataGridView;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_EmailSample;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_AddSample;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_DelSample;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_SampleDescription;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_SampleName;
        private System.Windows.Forms.ToolStripButton toolStripButton_Add;
        private System.Windows.Forms.ToolStripButton toolStripButton_Edit;
        private System.Windows.Forms.ToolStripButton toolStripButton_Del;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_EditSample;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox_Body;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txt_Subject;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button but_Close;
        private System.Windows.Forms.Button but_Refresh;
        private System.Windows.Forms.WebBrowser WebBrowser_Body;
        private LawtechPTSystem.DataSet_EmailTableAdapters.EmailSampleListTableAdapter emailSampleListTableAdapter;
        private System.Windows.Forms.BindingSource emailSampleTypeTBindingSource;
        private LawtechPTSystem.DataSet_EmailTableAdapters.EmailSampleTypeTTableAdapter emailSampleTypeTTableAdapter;
        private System.Windows.Forms.TextBox txt_Format;
        private System.Windows.Forms.TextBox txt_Priority;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sort;
        private System.Windows.Forms.DataGridViewTextBoxColumn TypeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn SampleName;
        private System.Windows.Forms.DataGridViewTextBoxColumn MailSubject;
        private System.Windows.Forms.DataGridViewTextBoxColumn MailPriority;
        private System.Windows.Forms.DataGridViewTextBoxColumn MailFormat;
        private System.Windows.Forms.DataGridViewTextBoxColumn createDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn WorkerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Format;
        private System.Windows.Forms.DataGridViewTextBoxColumn MailBody;
        private System.Windows.Forms.DataGridViewTextBoxColumn ESID;
    }
}