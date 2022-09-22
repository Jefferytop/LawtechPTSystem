namespace LawtechPTSystemByFirm.SubFrom
{
    partial class ViewUpdateFileList
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewUpdateFileList));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.UpLoadID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mainParentIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.childIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fileKindDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uploaderDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreateDateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FileDoc = new System.Windows.Forms.DataGridViewLinkColumn();
            this.FilePath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolStripMenuItem_DelFile = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_SaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.upLoadFileTBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.qS_DataSet = new LawtechPTSystemByFirm.QS_DataSet();
            this.groupBox_Pat = new System.Windows.Forms.GroupBox();
            this.but_Close = new System.Windows.Forms.Button();
            this.radioButton_Fee = new System.Windows.Forms.RadioButton();
            this.radoF = new System.Windows.Forms.RadioButton();
            this.radoD = new System.Windows.Forms.RadioButton();
            this.radoC = new System.Windows.Forms.RadioButton();
            this.radB_all = new System.Windows.Forms.RadioButton();
            this.vb_TMPayment = new System.Windows.Forms.RadioButton();
            this.vb_TMFee = new System.Windows.Forms.RadioButton();
            this.vb_TMNotify = new System.Windows.Forms.RadioButton();
            this.vb_TM = new System.Windows.Forms.RadioButton();
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorDeleteItem = new System.Windows.Forms.ToolStripButton();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.groupBox_TM = new System.Windows.Forms.GroupBox();
            this.vb_TMall = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox_Controvery = new System.Windows.Forms.GroupBox();
            this.rb_ControveryAll = new System.Windows.Forms.RadioButton();
            this.button2 = new System.Windows.Forms.Button();
            this.vb_Controvery = new System.Windows.Forms.RadioButton();
            this.rb_ControveryPayment = new System.Windows.Forms.RadioButton();
            this.rb_ControveryEvent = new System.Windows.Forms.RadioButton();
            this.rb_ControveryFee = new System.Windows.Forms.RadioButton();
            this.groupBox_Default = new System.Windows.Forms.GroupBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.button3 = new System.Windows.Forms.Button();
            this.upLoadFileTTableAdapter = new LawtechPTSystemByFirm.QS_DataSetTableAdapters.UpLoadFileTTableAdapter();
            this.tagTitle1 = new LawtechPTSystemByFirm.US.TagTitle();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.upLoadFileTBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qS_DataSet)).BeginInit();
            this.groupBox_Pat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            this.groupBox_TM.SuspendLayout();
            this.groupBox_Controvery.SuspendLayout();
            this.groupBox_Default.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowDrop = true;
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Blue;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(202)))), ((int)(((byte)(207)))), ((int)(((byte)(222)))));
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.UpLoadID,
            this.mainParentIDDataGridViewTextBoxColumn,
            this.childIDDataGridViewTextBoxColumn,
            this.fileKindDataGridViewTextBoxColumn,
            this.uploaderDataGridViewTextBoxColumn,
            this.CreateDateTime,
            this.FileDoc,
            this.FilePath});
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.DataSource = this.upLoadFileTBindingSource;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.Location = new System.Drawing.Point(13, 103);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 25;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(736, 541);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView1_CellMouseDown);
            // 
            // UpLoadID
            // 
            this.UpLoadID.DataPropertyName = "UpLoadID";
            this.UpLoadID.HeaderText = "UpLoadID";
            this.UpLoadID.Name = "UpLoadID";
            this.UpLoadID.ReadOnly = true;
            this.UpLoadID.Visible = false;
            // 
            // mainParentIDDataGridViewTextBoxColumn
            // 
            this.mainParentIDDataGridViewTextBoxColumn.DataPropertyName = "MainParentID";
            this.mainParentIDDataGridViewTextBoxColumn.HeaderText = "MainParentID";
            this.mainParentIDDataGridViewTextBoxColumn.Name = "mainParentIDDataGridViewTextBoxColumn";
            this.mainParentIDDataGridViewTextBoxColumn.Visible = false;
            // 
            // childIDDataGridViewTextBoxColumn
            // 
            this.childIDDataGridViewTextBoxColumn.DataPropertyName = "ChildID";
            this.childIDDataGridViewTextBoxColumn.HeaderText = "ChildID";
            this.childIDDataGridViewTextBoxColumn.Name = "childIDDataGridViewTextBoxColumn";
            this.childIDDataGridViewTextBoxColumn.Visible = false;
            // 
            // fileKindDataGridViewTextBoxColumn
            // 
            this.fileKindDataGridViewTextBoxColumn.DataPropertyName = "FileKind";
            this.fileKindDataGridViewTextBoxColumn.HeaderText = "FileKind";
            this.fileKindDataGridViewTextBoxColumn.Name = "fileKindDataGridViewTextBoxColumn";
            this.fileKindDataGridViewTextBoxColumn.Visible = false;
            // 
            // uploaderDataGridViewTextBoxColumn
            // 
            this.uploaderDataGridViewTextBoxColumn.DataPropertyName = "Uploader";
            this.uploaderDataGridViewTextBoxColumn.HeaderText = "上傳者";
            this.uploaderDataGridViewTextBoxColumn.Name = "uploaderDataGridViewTextBoxColumn";
            this.uploaderDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // CreateDateTime
            // 
            this.CreateDateTime.DataPropertyName = "CreateDateTime";
            dataGridViewCellStyle3.Format = "yyyy-MM-dd HH:mm:ss";
            this.CreateDateTime.DefaultCellStyle = dataGridViewCellStyle3;
            this.CreateDateTime.HeaderText = "上傳時間";
            this.CreateDateTime.Name = "CreateDateTime";
            this.CreateDateTime.Width = 130;
            // 
            // FileDoc
            // 
            this.FileDoc.DataPropertyName = "FileDoc";
            this.FileDoc.HeaderText = "檔案名稱";
            this.FileDoc.Name = "FileDoc";
            this.FileDoc.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.FileDoc.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.FileDoc.Width = 473;
            // 
            // FilePath
            // 
            this.FilePath.DataPropertyName = "FilePath";
            this.FilePath.HeaderText = "FilePath";
            this.FilePath.Name = "FilePath";
            this.FilePath.Visible = false;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_DelFile,
            this.ToolStripMenuItem_SaveAs});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(123, 48);
            this.contextMenuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuStrip1_ItemClicked);
            // 
            // ToolStripMenuItem_DelFile
            // 
            this.ToolStripMenuItem_DelFile.Name = "ToolStripMenuItem_DelFile";
            this.ToolStripMenuItem_DelFile.Size = new System.Drawing.Size(122, 22);
            this.ToolStripMenuItem_DelFile.Text = "刪除檔案";
            // 
            // ToolStripMenuItem_SaveAs
            // 
            this.ToolStripMenuItem_SaveAs.Name = "ToolStripMenuItem_SaveAs";
            this.ToolStripMenuItem_SaveAs.Size = new System.Drawing.Size(122, 22);
            this.ToolStripMenuItem_SaveAs.Text = "另存新檔";
            // 
            // upLoadFileTBindingSource
            // 
            this.upLoadFileTBindingSource.DataMember = "UpLoadFileT";
            this.upLoadFileTBindingSource.DataSource = this.qS_DataSet;
            // 
            // qS_DataSet
            // 
            this.qS_DataSet.DataSetName = "QS_DataSet";
            this.qS_DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // groupBox_Pat
            // 
            this.groupBox_Pat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox_Pat.Controls.Add(this.but_Close);
            this.groupBox_Pat.Controls.Add(this.radioButton_Fee);
            this.groupBox_Pat.Controls.Add(this.radoF);
            this.groupBox_Pat.Controls.Add(this.radoD);
            this.groupBox_Pat.Controls.Add(this.radoC);
            this.groupBox_Pat.Controls.Add(this.radB_all);
            this.groupBox_Pat.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox_Pat.Location = new System.Drawing.Point(13, 10);
            this.groupBox_Pat.Margin = new System.Windows.Forms.Padding(1);
            this.groupBox_Pat.Name = "groupBox_Pat";
            this.groupBox_Pat.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox_Pat.Size = new System.Drawing.Size(736, 59);
            this.groupBox_Pat.TabIndex = 2;
            this.groupBox_Pat.TabStop = false;
            this.groupBox_Pat.Text = "文件關聯";
            // 
            // but_Close
            // 
            this.but_Close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.but_Close.BackgroundImage = global::LawtechPTSystemByFirm.Properties.Resources.btnCancel;
            this.but_Close.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.but_Close.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.but_Close.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.but_Close.Location = new System.Drawing.Point(631, 20);
            this.but_Close.Margin = new System.Windows.Forms.Padding(1);
            this.but_Close.Name = "but_Close";
            this.but_Close.Size = new System.Drawing.Size(100, 32);
            this.but_Close.TabIndex = 24;
            this.but_Close.Text = "關閉";
            this.but_Close.UseVisualStyleBackColor = true;
            this.but_Close.Click += new System.EventHandler(this.but_Close_Click);
            // 
            // radioButton_Fee
            // 
            this.radioButton_Fee.AutoSize = true;
            this.radioButton_Fee.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.radioButton_Fee.ForeColor = System.Drawing.Color.BlueViolet;
            this.radioButton_Fee.Location = new System.Drawing.Point(318, 26);
            this.radioButton_Fee.Margin = new System.Windows.Forms.Padding(4);
            this.radioButton_Fee.Name = "radioButton_Fee";
            this.radioButton_Fee.Size = new System.Drawing.Size(91, 24);
            this.radioButton_Fee.TabIndex = 6;
            this.radioButton_Fee.Text = "請款費用";
            this.radioButton_Fee.UseVisualStyleBackColor = true;
            this.radioButton_Fee.CheckedChanged += new System.EventHandler(this.radB_all_CheckedChanged);
            // 
            // radoF
            // 
            this.radoF.AutoSize = true;
            this.radoF.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.radoF.ForeColor = System.Drawing.Color.Chocolate;
            this.radoF.Location = new System.Drawing.Point(463, 26);
            this.radoF.Margin = new System.Windows.Forms.Padding(4);
            this.radoF.Name = "radoF";
            this.radoF.Size = new System.Drawing.Size(91, 24);
            this.radoF.TabIndex = 5;
            this.radoF.Text = "付款費用";
            this.radoF.UseVisualStyleBackColor = true;
            this.radoF.CheckedChanged += new System.EventHandler(this.radB_all_CheckedChanged);
            // 
            // radoD
            // 
            this.radoD.AutoSize = true;
            this.radoD.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.radoD.ForeColor = System.Drawing.Color.SaddleBrown;
            this.radoD.Location = new System.Drawing.Point(200, 26);
            this.radoD.Margin = new System.Windows.Forms.Padding(4);
            this.radoD.Name = "radoD";
            this.radoD.Size = new System.Drawing.Size(91, 24);
            this.radoD.TabIndex = 3;
            this.radoD.Text = "事件記錄";
            this.radoD.UseVisualStyleBackColor = true;
            this.radoD.CheckedChanged += new System.EventHandler(this.radB_all_CheckedChanged);
            // 
            // radoC
            // 
            this.radoC.AutoSize = true;
            this.radoC.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.radoC.ForeColor = System.Drawing.Color.Navy;
            this.radoC.Location = new System.Drawing.Point(88, 26);
            this.radoC.Margin = new System.Windows.Forms.Padding(4);
            this.radoC.Name = "radoC";
            this.radoC.Size = new System.Drawing.Size(75, 24);
            this.radoC.TabIndex = 2;
            this.radoC.Text = "申請案";
            this.radoC.UseVisualStyleBackColor = true;
            this.radoC.CheckedChanged += new System.EventHandler(this.radB_all_CheckedChanged);
            // 
            // radB_all
            // 
            this.radB_all.AutoSize = true;
            this.radB_all.Checked = true;
            this.radB_all.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.radB_all.ForeColor = System.Drawing.Color.Green;
            this.radB_all.Location = new System.Drawing.Point(15, 26);
            this.radB_all.Margin = new System.Windows.Forms.Padding(4);
            this.radB_all.Name = "radB_all";
            this.radB_all.Size = new System.Drawing.Size(59, 24);
            this.radB_all.TabIndex = 0;
            this.radB_all.TabStop = true;
            this.radB_all.Text = "全部";
            this.radB_all.UseVisualStyleBackColor = true;
            this.radB_all.CheckedChanged += new System.EventHandler(this.radB_all_CheckedChanged);
            // 
            // vb_TMPayment
            // 
            this.vb_TMPayment.AutoSize = true;
            this.vb_TMPayment.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.vb_TMPayment.ForeColor = System.Drawing.Color.Chocolate;
            this.vb_TMPayment.Location = new System.Drawing.Point(438, 25);
            this.vb_TMPayment.Margin = new System.Windows.Forms.Padding(4);
            this.vb_TMPayment.Name = "vb_TMPayment";
            this.vb_TMPayment.Size = new System.Drawing.Size(91, 24);
            this.vb_TMPayment.TabIndex = 10;
            this.vb_TMPayment.Text = "付款費用";
            this.vb_TMPayment.UseVisualStyleBackColor = true;
            this.vb_TMPayment.CheckedChanged += new System.EventHandler(this.radB_all_CheckedChanged);
            // 
            // vb_TMFee
            // 
            this.vb_TMFee.AutoSize = true;
            this.vb_TMFee.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.vb_TMFee.ForeColor = System.Drawing.Color.BlueViolet;
            this.vb_TMFee.Location = new System.Drawing.Point(322, 25);
            this.vb_TMFee.Margin = new System.Windows.Forms.Padding(4);
            this.vb_TMFee.Name = "vb_TMFee";
            this.vb_TMFee.Size = new System.Drawing.Size(91, 24);
            this.vb_TMFee.TabIndex = 9;
            this.vb_TMFee.Text = "請款費用";
            this.vb_TMFee.UseVisualStyleBackColor = true;
            this.vb_TMFee.CheckedChanged += new System.EventHandler(this.radB_all_CheckedChanged);
            // 
            // vb_TMNotify
            // 
            this.vb_TMNotify.AutoSize = true;
            this.vb_TMNotify.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.vb_TMNotify.ForeColor = System.Drawing.Color.Sienna;
            this.vb_TMNotify.Location = new System.Drawing.Point(201, 25);
            this.vb_TMNotify.Margin = new System.Windows.Forms.Padding(4);
            this.vb_TMNotify.Name = "vb_TMNotify";
            this.vb_TMNotify.Size = new System.Drawing.Size(91, 24);
            this.vb_TMNotify.TabIndex = 8;
            this.vb_TMNotify.Text = "案件記錄";
            this.vb_TMNotify.UseVisualStyleBackColor = true;
            this.vb_TMNotify.CheckedChanged += new System.EventHandler(this.radB_all_CheckedChanged);
            // 
            // vb_TM
            // 
            this.vb_TM.AutoSize = true;
            this.vb_TM.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.vb_TM.ForeColor = System.Drawing.Color.Navy;
            this.vb_TM.Location = new System.Drawing.Point(95, 25);
            this.vb_TM.Margin = new System.Windows.Forms.Padding(4);
            this.vb_TM.Name = "vb_TM";
            this.vb_TM.Size = new System.Drawing.Size(75, 24);
            this.vb_TM.TabIndex = 7;
            this.vb_TM.Text = "商標案";
            this.vb_TM.UseVisualStyleBackColor = true;
            this.vb_TM.CheckedChanged += new System.EventHandler(this.radB_all_CheckedChanged);
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = null;
            this.bindingNavigator1.BindingSource = this.upLoadFileTBindingSource;
            this.bindingNavigator1.CountItem = this.bindingNavigatorCountItem;
            this.bindingNavigator1.DeleteItem = null;
            this.bindingNavigator1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bindingNavigator1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.bindingNavigatorDeleteItem});
            this.bindingNavigator1.Location = new System.Drawing.Point(0, 647);
            this.bindingNavigator1.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigator1.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigator1.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigator1.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigator1.Size = new System.Drawing.Size(761, 25);
            this.bindingNavigator1.TabIndex = 3;
            this.bindingNavigator1.Text = "bindingNavigator1";
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
            // bindingNavigatorDeleteItem
            // 
            this.bindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem.Image = global::LawtechPTSystemByFirm.Properties.Resources.delete;
            this.bindingNavigatorDeleteItem.Name = "bindingNavigatorDeleteItem";
            this.bindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorDeleteItem.Text = "刪除檔案";
            this.bindingNavigatorDeleteItem.Click += new System.EventHandler(this.bindingNavigatorDeleteItem_Click);
            // 
            // groupBox_TM
            // 
            this.groupBox_TM.Controls.Add(this.vb_TMall);
            this.groupBox_TM.Controls.Add(this.button1);
            this.groupBox_TM.Controls.Add(this.vb_TM);
            this.groupBox_TM.Controls.Add(this.vb_TMPayment);
            this.groupBox_TM.Controls.Add(this.vb_TMNotify);
            this.groupBox_TM.Controls.Add(this.vb_TMFee);
            this.groupBox_TM.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.groupBox_TM.Location = new System.Drawing.Point(13, 10);
            this.groupBox_TM.Name = "groupBox_TM";
            this.groupBox_TM.Size = new System.Drawing.Size(736, 59);
            this.groupBox_TM.TabIndex = 4;
            this.groupBox_TM.TabStop = false;
            this.groupBox_TM.Text = "文件關聯";
            // 
            // vb_TMall
            // 
            this.vb_TMall.AutoSize = true;
            this.vb_TMall.Checked = true;
            this.vb_TMall.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.vb_TMall.ForeColor = System.Drawing.Color.Green;
            this.vb_TMall.Location = new System.Drawing.Point(15, 25);
            this.vb_TMall.Margin = new System.Windows.Forms.Padding(4);
            this.vb_TMall.Name = "vb_TMall";
            this.vb_TMall.Size = new System.Drawing.Size(59, 24);
            this.vb_TMall.TabIndex = 26;
            this.vb_TMall.TabStop = true;
            this.vb_TMall.Text = "全部";
            this.vb_TMall.UseVisualStyleBackColor = true;
            this.vb_TMall.CheckedChanged += new System.EventHandler(this.radB_all_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackgroundImage = global::LawtechPTSystemByFirm.Properties.Resources.btnCancel;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button1.Location = new System.Drawing.Point(631, 20);
            this.button1.Margin = new System.Windows.Forms.Padding(1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 32);
            this.button1.TabIndex = 25;
            this.button1.Text = "關閉";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.but_Close_Click);
            // 
            // groupBox_Controvery
            // 
            this.groupBox_Controvery.Controls.Add(this.rb_ControveryAll);
            this.groupBox_Controvery.Controls.Add(this.button2);
            this.groupBox_Controvery.Controls.Add(this.vb_Controvery);
            this.groupBox_Controvery.Controls.Add(this.rb_ControveryPayment);
            this.groupBox_Controvery.Controls.Add(this.rb_ControveryEvent);
            this.groupBox_Controvery.Controls.Add(this.rb_ControveryFee);
            this.groupBox_Controvery.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.groupBox_Controvery.Location = new System.Drawing.Point(13, 10);
            this.groupBox_Controvery.Name = "groupBox_Controvery";
            this.groupBox_Controvery.Size = new System.Drawing.Size(736, 59);
            this.groupBox_Controvery.TabIndex = 5;
            this.groupBox_Controvery.TabStop = false;
            this.groupBox_Controvery.Text = "文件關聯";
            // 
            // rb_ControveryAll
            // 
            this.rb_ControveryAll.AutoSize = true;
            this.rb_ControveryAll.Checked = true;
            this.rb_ControveryAll.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.rb_ControveryAll.ForeColor = System.Drawing.Color.Green;
            this.rb_ControveryAll.Location = new System.Drawing.Point(15, 25);
            this.rb_ControveryAll.Margin = new System.Windows.Forms.Padding(4);
            this.rb_ControveryAll.Name = "rb_ControveryAll";
            this.rb_ControveryAll.Size = new System.Drawing.Size(59, 24);
            this.rb_ControveryAll.TabIndex = 26;
            this.rb_ControveryAll.TabStop = true;
            this.rb_ControveryAll.Text = "全部";
            this.rb_ControveryAll.UseVisualStyleBackColor = true;
            this.rb_ControveryAll.CheckedChanged += new System.EventHandler(this.radB_all_CheckedChanged);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.BackgroundImage = global::LawtechPTSystemByFirm.Properties.Resources.btnCancel;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button2.Location = new System.Drawing.Point(629, 20);
            this.button2.Margin = new System.Windows.Forms.Padding(1);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 32);
            this.button2.TabIndex = 25;
            this.button2.Text = "關閉";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.but_Close_Click);
            // 
            // vb_Controvery
            // 
            this.vb_Controvery.AutoSize = true;
            this.vb_Controvery.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.vb_Controvery.ForeColor = System.Drawing.Color.Navy;
            this.vb_Controvery.Location = new System.Drawing.Point(95, 25);
            this.vb_Controvery.Margin = new System.Windows.Forms.Padding(4);
            this.vb_Controvery.Name = "vb_Controvery";
            this.vb_Controvery.Size = new System.Drawing.Size(107, 24);
            this.vb_Controvery.TabIndex = 7;
            this.vb_Controvery.Text = "商標異議案";
            this.vb_Controvery.UseVisualStyleBackColor = true;
            this.vb_Controvery.CheckedChanged += new System.EventHandler(this.radB_all_CheckedChanged);
            // 
            // rb_ControveryPayment
            // 
            this.rb_ControveryPayment.AutoSize = true;
            this.rb_ControveryPayment.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.rb_ControveryPayment.ForeColor = System.Drawing.Color.Chocolate;
            this.rb_ControveryPayment.Location = new System.Drawing.Point(454, 25);
            this.rb_ControveryPayment.Margin = new System.Windows.Forms.Padding(4);
            this.rb_ControveryPayment.Name = "rb_ControveryPayment";
            this.rb_ControveryPayment.Size = new System.Drawing.Size(91, 24);
            this.rb_ControveryPayment.TabIndex = 10;
            this.rb_ControveryPayment.Text = "付款費用";
            this.rb_ControveryPayment.UseVisualStyleBackColor = true;
            this.rb_ControveryPayment.CheckedChanged += new System.EventHandler(this.radB_all_CheckedChanged);
            // 
            // rb_ControveryEvent
            // 
            this.rb_ControveryEvent.AutoSize = true;
            this.rb_ControveryEvent.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.rb_ControveryEvent.ForeColor = System.Drawing.Color.Sienna;
            this.rb_ControveryEvent.Location = new System.Drawing.Point(217, 25);
            this.rb_ControveryEvent.Margin = new System.Windows.Forms.Padding(4);
            this.rb_ControveryEvent.Name = "rb_ControveryEvent";
            this.rb_ControveryEvent.Size = new System.Drawing.Size(91, 24);
            this.rb_ControveryEvent.TabIndex = 8;
            this.rb_ControveryEvent.Text = "案件記錄";
            this.rb_ControveryEvent.UseVisualStyleBackColor = true;
            this.rb_ControveryEvent.CheckedChanged += new System.EventHandler(this.radB_all_CheckedChanged);
            // 
            // rb_ControveryFee
            // 
            this.rb_ControveryFee.AutoSize = true;
            this.rb_ControveryFee.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.rb_ControveryFee.ForeColor = System.Drawing.Color.BlueViolet;
            this.rb_ControveryFee.Location = new System.Drawing.Point(338, 25);
            this.rb_ControveryFee.Margin = new System.Windows.Forms.Padding(4);
            this.rb_ControveryFee.Name = "rb_ControveryFee";
            this.rb_ControveryFee.Size = new System.Drawing.Size(91, 24);
            this.rb_ControveryFee.TabIndex = 9;
            this.rb_ControveryFee.Text = "請款費用";
            this.rb_ControveryFee.UseVisualStyleBackColor = true;
            this.rb_ControveryFee.CheckedChanged += new System.EventHandler(this.radB_all_CheckedChanged);
            // 
            // groupBox_Default
            // 
            this.groupBox_Default.Controls.Add(this.radioButton1);
            this.groupBox_Default.Controls.Add(this.button3);
            this.groupBox_Default.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.groupBox_Default.Location = new System.Drawing.Point(13, 10);
            this.groupBox_Default.Name = "groupBox_Default";
            this.groupBox_Default.Size = new System.Drawing.Size(736, 59);
            this.groupBox_Default.TabIndex = 6;
            this.groupBox_Default.TabStop = false;
            this.groupBox_Default.Text = "文件關聯";
            this.groupBox_Default.Visible = false;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.radioButton1.ForeColor = System.Drawing.Color.Green;
            this.radioButton1.Location = new System.Drawing.Point(15, 25);
            this.radioButton1.Margin = new System.Windows.Forms.Padding(4);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(59, 24);
            this.radioButton1.TabIndex = 26;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "全部";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.BackgroundImage = global::LawtechPTSystemByFirm.Properties.Resources.btnCancel;
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button3.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button3.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button3.Location = new System.Drawing.Point(626, 20);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(100, 32);
            this.button3.TabIndex = 25;
            this.button3.Text = "關閉";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.but_Close_Click);
            // 
            // upLoadFileTTableAdapter
            // 
            this.upLoadFileTTableAdapter.ClearBeforeFill = true;
            // 
            // tagTitle1
            // 
            this.tagTitle1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tagTitle1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tagTitle1.BackgroundImage")));
            this.tagTitle1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tagTitle1.Location = new System.Drawing.Point(13, 75);
            this.tagTitle1.Margin = new System.Windows.Forms.Padding(0);
            this.tagTitle1.Name = "tagTitle1";
            this.tagTitle1.Size = new System.Drawing.Size(736, 32);
            this.tagTitle1.TabIndex = 30;
            this.tagTitle1.TagTitleStyle = "Style4";
            this.tagTitle1.TitleLableText = "相關附件列表";
            // 
            // ViewUpdateFileList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::LawtechPTSystemByFirm.Properties.Resources.bg_01;
            this.CancelButton = this.but_Close;
            this.ClientSize = new System.Drawing.Size(761, 672);
            this.Controls.Add(this.bindingNavigator1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.groupBox_Default);
            this.Controls.Add(this.groupBox_Controvery);
            this.Controls.Add(this.groupBox_TM);
            this.Controls.Add(this.tagTitle1);
            this.Controls.Add(this.groupBox_Pat);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ViewUpdateFileList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ViewUpdateFileList";
            this.Load += new System.EventHandler(this.ViewUpdateFileList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.upLoadFileTBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qS_DataSet)).EndInit();
            this.groupBox_Pat.ResumeLayout(false);
            this.groupBox_Pat.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            this.groupBox_TM.ResumeLayout(false);
            this.groupBox_TM.PerformLayout();
            this.groupBox_Controvery.ResumeLayout(false);
            this.groupBox_Controvery.PerformLayout();
            this.groupBox_Default.ResumeLayout(false);
            this.groupBox_Default.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox_Pat;
        internal System.Windows.Forms.RadioButton radoF;
        internal System.Windows.Forms.RadioButton radoD;
        internal System.Windows.Forms.RadioButton radoC;
        internal System.Windows.Forms.RadioButton radB_all;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private QS_DataSet qS_DataSet;
        private System.Windows.Forms.BindingSource upLoadFileTBindingSource;
        private LawtechPTSystemByFirm.QS_DataSetTableAdapters.UpLoadFileTTableAdapter upLoadFileTTableAdapter;
        internal System.Windows.Forms.RadioButton radioButton_Fee;
        internal System.Windows.Forms.RadioButton vb_TMNotify;
        internal System.Windows.Forms.RadioButton vb_TM;
        internal System.Windows.Forms.RadioButton vb_TMPayment;
        internal System.Windows.Forms.RadioButton vb_TMFee;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_DelFile;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_SaveAs;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.DataGridViewTextBoxColumn upbuildDayDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button but_Close;
        private System.Windows.Forms.GroupBox groupBox_TM;
        internal System.Windows.Forms.RadioButton vb_TMall;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox_Controvery;
        internal System.Windows.Forms.RadioButton rb_ControveryAll;
        private System.Windows.Forms.Button button2;
        internal System.Windows.Forms.RadioButton vb_Controvery;
        internal System.Windows.Forms.RadioButton rb_ControveryPayment;
        internal System.Windows.Forms.RadioButton rb_ControveryEvent;
        internal System.Windows.Forms.RadioButton rb_ControveryFee;
        private System.Windows.Forms.GroupBox groupBox_Default;
        internal System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataGridViewTextBoxColumn UpLoadID;
        private System.Windows.Forms.DataGridViewTextBoxColumn mainParentIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn childIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fileKindDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn uploaderDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreateDateTime;
        private System.Windows.Forms.DataGridViewLinkColumn FileDoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn FilePath;
        private US.TagTitle tagTitle1;
    }
}