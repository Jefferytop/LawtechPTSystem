namespace LawtechPTSystemByFirm.SubFrom
{
    partial class SubjectUploadMF
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SubjectUploadMF));
            this.dgvUploadFile = new System.Windows.Forms.DataGridView();
            this.UploadKey = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Kind = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.kindTBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.qS_DataSet = new LawtechPTSystemByFirm.QS_DataSet();
            this.Country = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.countryTBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ArticleTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Author = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BuildDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BuildWorker = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.workerTBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.FilePath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SUID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.AddToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.countryTTableAdapter = new LawtechPTSystemByFirm.QS_DataSetTableAdapters.CountryTTableAdapter();
            this.workerTTableAdapter = new LawtechPTSystemByFirm.QS_DataSetTableAdapters.WorkerTTableAdapter();
            this.kindTTableAdapter = new LawtechPTSystemByFirm.QS_DataSetTableAdapters.KindTTableAdapter();
            this.rb_or = new System.Windows.Forms.RadioButton();
            this.rb_and = new System.Windows.Forms.RadioButton();
            this.comboBox_DateMode = new System.Windows.Forms.ComboBox();
            this.but_Search = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.maskedTextBox_D = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBox_S = new System.Windows.Forms.MaskedTextBox();
            this.but_Close = new System.Windows.Forms.Button();
            this.comboBox_SelectValue1 = new System.Windows.Forms.ComboBox();
            this.comboBox_Select1 = new System.Windows.Forms.ComboBox();
            this.comboBox_SelectValue = new System.Windows.Forms.ComboBox();
            this.comboBox_Select = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUploadFile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kindTBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qS_DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.countryTBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.workerTBindingSource)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvUploadFile
            // 
            this.dgvUploadFile.AllowUserToAddRows = false;
            this.dgvUploadFile.AllowUserToDeleteRows = false;
            this.dgvUploadFile.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvUploadFile.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUploadFile.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.UploadKey,
            this.Kind,
            this.Country,
            this.ArticleTitle,
            this.Description,
            this.Author,
            this.BuildDate,
            this.BuildWorker,
            this.FilePath,
            this.SUID});
            this.dgvUploadFile.ContextMenuStrip = this.contextMenuStrip1;
            this.dgvUploadFile.Location = new System.Drawing.Point(3, 3);
            this.dgvUploadFile.Name = "dgvUploadFile";
            this.dgvUploadFile.RowTemplate.Height = 24;
            this.dgvUploadFile.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUploadFile.Size = new System.Drawing.Size(676, 467);
            this.dgvUploadFile.TabIndex = 4;
            // 
            // UploadKey
            // 
            this.UploadKey.DataPropertyName = "UploadKey";
            this.UploadKey.HeaderText = "UploadKey";
            this.UploadKey.Name = "UploadKey";
            this.UploadKey.ReadOnly = true;
            this.UploadKey.Visible = false;
            // 
            // Kind
            // 
            this.Kind.DataPropertyName = "KindSN";
            this.Kind.DataSource = this.kindTBindingSource;
            this.Kind.DisplayMember = "Kind";
            this.Kind.HeaderText = "文章種類";
            this.Kind.Name = "Kind";
            this.Kind.ReadOnly = true;
            this.Kind.ValueMember = "KindSN";
            // 
            // kindTBindingSource
            // 
            this.kindTBindingSource.DataMember = "KindT";
            this.kindTBindingSource.DataSource = this.qS_DataSet;
            // 
            // qS_DataSet
            // 
            this.qS_DataSet.DataSetName = "QS_DataSet";
            this.qS_DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // Country
            // 
            this.Country.DataPropertyName = "CountrySymbol";
            this.Country.DataSource = this.countryTBindingSource;
            this.Country.DisplayMember = "Country";
            this.Country.HeaderText = "國別";
            this.Country.Name = "Country";
            this.Country.ReadOnly = true;
            this.Country.ValueMember = "CountrySymbol";
            // 
            // countryTBindingSource
            // 
            this.countryTBindingSource.DataMember = "CountryT";
            this.countryTBindingSource.DataSource = this.qS_DataSet;
            // 
            // ArticleTitle
            // 
            this.ArticleTitle.DataPropertyName = "ArticleTitle";
            this.ArticleTitle.HeaderText = "篇名";
            this.ArticleTitle.Name = "ArticleTitle";
            this.ArticleTitle.ReadOnly = true;
            // 
            // Description
            // 
            this.Description.DataPropertyName = "Description";
            this.Description.HeaderText = "簡述";
            this.Description.Name = "Description";
            this.Description.Width = 200;
            // 
            // Author
            // 
            this.Author.DataPropertyName = "Author";
            this.Author.HeaderText = "作者";
            this.Author.Name = "Author";
            this.Author.ReadOnly = true;
            // 
            // BuildDate
            // 
            this.BuildDate.DataPropertyName = "BuildDate";
            dataGridViewCellStyle2.Format = "yyyy/MM/dd HH:mm";
            this.BuildDate.DefaultCellStyle = dataGridViewCellStyle2;
            this.BuildDate.HeaderText = "上傳時間";
            this.BuildDate.Name = "BuildDate";
            this.BuildDate.ReadOnly = true;
            // 
            // BuildWorker
            // 
            this.BuildWorker.DataPropertyName = "BuildWorker";
            this.BuildWorker.DataSource = this.workerTBindingSource;
            this.BuildWorker.DisplayMember = "Name";
            this.BuildWorker.HeaderText = "上傳人";
            this.BuildWorker.Name = "BuildWorker";
            this.BuildWorker.ReadOnly = true;
            this.BuildWorker.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.BuildWorker.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.BuildWorker.ValueMember = "WorkerKey";
            // 
            // workerTBindingSource
            // 
            this.workerTBindingSource.DataMember = "WorkerT";
            this.workerTBindingSource.DataSource = this.qS_DataSet;
            // 
            // FilePath
            // 
            this.FilePath.DataPropertyName = "FilePath";
            this.FilePath.HeaderText = "FilePath";
            this.FilePath.Name = "FilePath";
            this.FilePath.ReadOnly = true;
            this.FilePath.Visible = false;
            // 
            // SUID
            // 
            this.SUID.DataPropertyName = "SUID";
            this.SUID.HeaderText = "SUID";
            this.SUID.Name = "SUID";
            this.SUID.Visible = false;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddToolStripMenuItem,
            this.DelToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(147, 48);
            this.contextMenuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuStrip1_ItemClicked);
            // 
            // AddToolStripMenuItem
            // 
            this.AddToolStripMenuItem.Name = "AddToolStripMenuItem";
            this.AddToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.AddToolStripMenuItem.Text = "新增相關文章";
            // 
            // DelToolStripMenuItem
            // 
            this.DelToolStripMenuItem.Name = "DelToolStripMenuItem";
            this.DelToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.DelToolStripMenuItem.Text = "刪除相關文章";
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = null;
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
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripButton3});
            this.bindingNavigator1.Location = new System.Drawing.Point(0, 473);
            this.bindingNavigator1.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigator1.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigator1.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigator1.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigator1.Size = new System.Drawing.Size(682, 25);
            this.bindingNavigator1.TabIndex = 5;
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
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::LawtechPTSystemByFirm.Properties.Resources.Add;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "新增";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = global::LawtechPTSystemByFirm.Properties.Resources.Edit;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton2.Text = "編輯";
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = global::LawtechPTSystemByFirm.Properties.Resources.delete;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton3.Text = "刪除";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Location = new System.Drawing.Point(-2, 96);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgvUploadFile);
            this.splitContainer1.Panel1.Controls.Add(this.bindingNavigator1);
            this.splitContainer1.Size = new System.Drawing.Size(995, 500);
            this.splitContainer1.SplitterDistance = 684;
            this.splitContainer1.SplitterWidth = 6;
            this.splitContainer1.TabIndex = 6;
            // 
            // countryTTableAdapter
            // 
            this.countryTTableAdapter.ClearBeforeFill = true;
            // 
            // workerTTableAdapter
            // 
            this.workerTTableAdapter.ClearBeforeFill = true;
            // 
            // kindTTableAdapter
            // 
            this.kindTTableAdapter.ClearBeforeFill = true;
            // 
            // rb_or
            // 
            this.rb_or.AutoSize = true;
            this.rb_or.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.rb_or.Location = new System.Drawing.Point(422, 67);
            this.rb_or.Name = "rb_or";
            this.rb_or.Size = new System.Drawing.Size(58, 20);
            this.rb_or.TabIndex = 1026;
            this.rb_or.Text = "或(or)";
            this.rb_or.UseVisualStyleBackColor = true;
            // 
            // rb_and
            // 
            this.rb_and.AutoSize = true;
            this.rb_and.Checked = true;
            this.rb_and.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.rb_and.Location = new System.Drawing.Point(422, 41);
            this.rb_and.Name = "rb_and";
            this.rb_and.Size = new System.Drawing.Size(80, 20);
            this.rb_and.TabIndex = 1025;
            this.rb_and.TabStop = true;
            this.rb_and.Text = "並且(and)";
            this.rb_and.UseVisualStyleBackColor = true;
            // 
            // comboBox_DateMode
            // 
            this.comboBox_DateMode.DisplayMember = "SelectString";
            this.comboBox_DateMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_DateMode.Font = new System.Drawing.Font("微軟正黑體", 14F);
            this.comboBox_DateMode.FormattingEnabled = true;
            this.comboBox_DateMode.ItemHeight = 24;
            this.comboBox_DateMode.Location = new System.Drawing.Point(13, 3);
            this.comboBox_DateMode.Margin = new System.Windows.Forms.Padding(1);
            this.comboBox_DateMode.MaxDropDownItems = 10;
            this.comboBox_DateMode.Name = "comboBox_DateMode";
            this.comboBox_DateMode.Size = new System.Drawing.Size(138, 32);
            this.comboBox_DateMode.TabIndex = 1022;
            this.comboBox_DateMode.ValueMember = "SelectValue";
            // 
            // but_Search
            // 
            this.but_Search.BackgroundImage = global::LawtechPTSystemByFirm.Properties.Resources.btnComfirm;
            this.but_Search.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.but_Search.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.but_Search.Location = new System.Drawing.Point(558, 60);
            this.but_Search.Name = "but_Search";
            this.but_Search.Size = new System.Drawing.Size(120, 30);
            this.but_Search.TabIndex = 1021;
            this.but_Search.Text = "查詢";
            this.but_Search.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.label2.Location = new System.Drawing.Point(273, 8);
            this.label2.Margin = new System.Windows.Forms.Padding(1);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 20);
            this.label2.TabIndex = 1020;
            this.label2.Text = "~";
            // 
            // maskedTextBox_D
            // 
            this.maskedTextBox_D.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.maskedTextBox_D.ForeColor = System.Drawing.Color.Green;
            this.maskedTextBox_D.Location = new System.Drawing.Point(295, 4);
            this.maskedTextBox_D.Margin = new System.Windows.Forms.Padding(1);
            this.maskedTextBox_D.Mask = "0000/00/00";
            this.maskedTextBox_D.Name = "maskedTextBox_D";
            this.maskedTextBox_D.Size = new System.Drawing.Size(114, 29);
            this.maskedTextBox_D.TabIndex = 1019;
            this.maskedTextBox_D.ValidatingType = typeof(System.DateTime);
            // 
            // maskedTextBox_S
            // 
            this.maskedTextBox_S.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.maskedTextBox_S.ForeColor = System.Drawing.Color.Green;
            this.maskedTextBox_S.Location = new System.Drawing.Point(153, 4);
            this.maskedTextBox_S.Margin = new System.Windows.Forms.Padding(1);
            this.maskedTextBox_S.Mask = "0000/00/00";
            this.maskedTextBox_S.Name = "maskedTextBox_S";
            this.maskedTextBox_S.Size = new System.Drawing.Size(112, 29);
            this.maskedTextBox_S.TabIndex = 1018;
            this.maskedTextBox_S.ValidatingType = typeof(System.DateTime);
            // 
            // but_Close
            // 
            this.but_Close.BackgroundImage = global::LawtechPTSystemByFirm.Properties.Resources.btnCancel;
            this.but_Close.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.but_Close.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.but_Close.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.but_Close.Location = new System.Drawing.Point(881, 60);
            this.but_Close.Name = "but_Close";
            this.but_Close.Size = new System.Drawing.Size(100, 30);
            this.but_Close.TabIndex = 1027;
            this.but_Close.Text = "關閉";
            this.but_Close.UseVisualStyleBackColor = true;
            this.but_Close.Click += new System.EventHandler(this.but_Close_Click);
            // 
            // comboBox_SelectValue1
            // 
            this.comboBox_SelectValue1.Font = new System.Drawing.Font("標楷體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.comboBox_SelectValue1.FormattingEnabled = true;
            this.comboBox_SelectValue1.Location = new System.Drawing.Point(153, 65);
            this.comboBox_SelectValue1.Margin = new System.Windows.Forms.Padding(1);
            this.comboBox_SelectValue1.Name = "comboBox_SelectValue1";
            this.comboBox_SelectValue1.Size = new System.Drawing.Size(256, 27);
            this.comboBox_SelectValue1.TabIndex = 1036;
            // 
            // comboBox_Select1
            // 
            this.comboBox_Select1.DisplayMember = "String";
            this.comboBox_Select1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Select1.Font = new System.Drawing.Font("標楷體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.comboBox_Select1.FormattingEnabled = true;
            this.comboBox_Select1.Location = new System.Drawing.Point(13, 65);
            this.comboBox_Select1.Margin = new System.Windows.Forms.Padding(1);
            this.comboBox_Select1.Name = "comboBox_Select1";
            this.comboBox_Select1.Size = new System.Drawing.Size(138, 27);
            this.comboBox_Select1.TabIndex = 1035;
            this.comboBox_Select1.ValueMember = "Value";
            // 
            // comboBox_SelectValue
            // 
            this.comboBox_SelectValue.Font = new System.Drawing.Font("標楷體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.comboBox_SelectValue.FormattingEnabled = true;
            this.comboBox_SelectValue.Location = new System.Drawing.Point(153, 36);
            this.comboBox_SelectValue.Margin = new System.Windows.Forms.Padding(1);
            this.comboBox_SelectValue.Name = "comboBox_SelectValue";
            this.comboBox_SelectValue.Size = new System.Drawing.Size(256, 27);
            this.comboBox_SelectValue.TabIndex = 1034;
            // 
            // comboBox_Select
            // 
            this.comboBox_Select.DisplayMember = "String";
            this.comboBox_Select.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Select.Font = new System.Drawing.Font("標楷體", 14F);
            this.comboBox_Select.FormattingEnabled = true;
            this.comboBox_Select.Location = new System.Drawing.Point(13, 36);
            this.comboBox_Select.Margin = new System.Windows.Forms.Padding(1);
            this.comboBox_Select.Name = "comboBox_Select";
            this.comboBox_Select.Size = new System.Drawing.Size(138, 27);
            this.comboBox_Select.TabIndex = 1033;
            this.comboBox_Select.ValueMember = "Value";
            // 
            // SubjectUploadMF
            // 
            this.AcceptButton = this.but_Search;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(236)))), ((int)(((byte)(247)))));
            this.CancelButton = this.but_Close;
            this.ClientSize = new System.Drawing.Size(993, 597);
            this.Controls.Add(this.comboBox_SelectValue1);
            this.Controls.Add(this.comboBox_Select1);
            this.Controls.Add(this.comboBox_SelectValue);
            this.Controls.Add(this.comboBox_Select);
            this.Controls.Add(this.but_Close);
            this.Controls.Add(this.rb_or);
            this.Controls.Add(this.rb_and);
            this.Controls.Add(this.comboBox_DateMode);
            this.Controls.Add(this.but_Search);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.maskedTextBox_D);
            this.Controls.Add(this.maskedTextBox_S);
            this.Controls.Add(this.splitContainer1);
            this.Name = "SubjectUploadMF";
            this.Text = "知識管理";
            this.Load += new System.EventHandler(this.SubjectUploadMF_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUploadFile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kindTBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qS_DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.countryTBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.workerTBindingSource)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvUploadFile;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private QS_DataSet qS_DataSet;
        private System.Windows.Forms.BindingSource countryTBindingSource;
        private LawtechPTSystemByFirm.QS_DataSetTableAdapters.CountryTTableAdapter countryTTableAdapter;
        private System.Windows.Forms.BindingSource workerTBindingSource;
        private LawtechPTSystemByFirm.QS_DataSetTableAdapters.WorkerTTableAdapter workerTTableAdapter;
        private System.Windows.Forms.BindingSource kindTBindingSource;
        private LawtechPTSystemByFirm.QS_DataSetTableAdapters.KindTTableAdapter kindTTableAdapter;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem AddToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DelToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn UploadKey;
        private System.Windows.Forms.DataGridViewComboBoxColumn Kind;
        private System.Windows.Forms.DataGridViewComboBoxColumn Country;
        private System.Windows.Forms.DataGridViewTextBoxColumn ArticleTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn Author;
        private System.Windows.Forms.DataGridViewTextBoxColumn BuildDate;
        private System.Windows.Forms.DataGridViewComboBoxColumn BuildWorker;
        private System.Windows.Forms.DataGridViewTextBoxColumn FilePath;
        private System.Windows.Forms.DataGridViewTextBoxColumn SUID;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.RadioButton rb_or;
        private System.Windows.Forms.RadioButton rb_and;
        private System.Windows.Forms.ComboBox comboBox_DateMode;
        private System.Windows.Forms.Button but_Search;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_D;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_S;
        private System.Windows.Forms.Button but_Close;
        private System.Windows.Forms.ComboBox comboBox_SelectValue1;
        private System.Windows.Forms.ComboBox comboBox_Select1;
        private System.Windows.Forms.ComboBox comboBox_SelectValue;
        private System.Windows.Forms.ComboBox comboBox_Select;
    }
}