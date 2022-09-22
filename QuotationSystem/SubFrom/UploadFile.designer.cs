namespace LawtechPTSystem.SubFrom
{
    partial class UploadFile
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UploadFile));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvUploadFile = new System.Windows.Forms.DataGridView();
            this.cmsUploadSelection = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.edittoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_KeyWorkSetting = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripMenuItem_UpLoad = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_OpenFile = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem_Horizontal = new System.Windows.Forms.ToolStripMenuItem();
            this.uploadTBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet_KM = new LawtechPTSystem.DataSet_KM();
            this.btnShowAll = new System.Windows.Forms.Button();
            this.but_Close = new System.Windows.Forms.Button();
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
            this.toolStripButton_Add = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_Edit = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_Del = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton_ContainerHorizontal = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txt_KindSN = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_BuildWorker = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_CountrySymbol = new System.Windows.Forms.TextBox();
            this.txt_BuildDate = new System.Windows.Forms.TextBox();
            this.txt_Author = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txt_ArticleTitle = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txt_Description = new System.Windows.Forms.TextBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.uploadTTableAdapter = new LawtechPTSystem.DataSet_KMTableAdapters.UploadTTableAdapter();
            this.userControlFilterDate1 = new LawtechPTSystem.US.UserControlFilterDate();
            this.QueryFilter1 = new LawtechPTSystem.US.ComboSearchColumnBox();
            this.QueryFilter2 = new LawtechPTSystem.US.ComboSearchColumnBox();
            this.Radio_and = new System.Windows.Forms.RadioButton();
            this.Radio_or = new System.Windows.Forms.RadioButton();
            this.but_ShowDetail = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.UploadKey = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Kind = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CountrySymbol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Country = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ArticleTitle = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Author = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RefURL = new System.Windows.Forms.DataGridViewLinkColumn();
            this.CreateDateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Creator = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastModifyDateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastModifyWorker = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FilePath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.referenceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fKEYDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subTableDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUploadFile)).BeginInit();
            this.cmsUploadSelection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uploadTBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_KM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvUploadFile
            // 
            this.dgvUploadFile.AllowUserToAddRows = false;
            this.dgvUploadFile.AllowUserToDeleteRows = false;
            this.dgvUploadFile.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Blue;
            this.dgvUploadFile.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvUploadFile.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvUploadFile.AutoGenerateColumns = false;
            this.dgvUploadFile.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUploadFile.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.UploadKey,
            this.Kind,
            this.CountrySymbol,
            this.Country,
            this.ArticleTitle,
            this.Description,
            this.Author,
            this.RefURL,
            this.CreateDateTime,
            this.Creator,
            this.LastModifyDateTime,
            this.LastModifyWorker,
            this.FilePath,
            this.referenceDataGridViewTextBoxColumn,
            this.fKEYDataGridViewTextBoxColumn,
            this.subTableDataGridViewTextBoxColumn});
            this.dgvUploadFile.ContextMenuStrip = this.cmsUploadSelection;
            this.dgvUploadFile.DataSource = this.uploadTBindingSource;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvUploadFile.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvUploadFile.Location = new System.Drawing.Point(3, 3);
            this.dgvUploadFile.Margin = new System.Windows.Forms.Padding(1);
            this.dgvUploadFile.Name = "dgvUploadFile";
            this.dgvUploadFile.ReadOnly = true;
            this.dgvUploadFile.RowHeadersWidth = 30;
            this.dgvUploadFile.RowTemplate.Height = 24;
            this.dgvUploadFile.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUploadFile.Size = new System.Drawing.Size(982, 314);
            this.dgvUploadFile.TabIndex = 3;
            this.dgvUploadFile.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUploadFile_CellClick);
            this.dgvUploadFile.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUploadFile_CellDoubleClick);
            // 
            // cmsUploadSelection
            // 
            this.cmsUploadSelection.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem,
            this.edittoolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.ToolStripMenuItem_KeyWorkSetting,
            this.toolStripSeparator1,
            this.ToolStripMenuItem_UpLoad,
            this.toolStripMenuItem_OpenFile,
            this.toolStripSeparator3,
            this.toolStripMenuItem_Horizontal});
            this.cmsUploadSelection.Name = "cmsUploadSelection";
            this.cmsUploadSelection.Size = new System.Drawing.Size(147, 170);
            this.cmsUploadSelection.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.cmsUploadSelection_ItemClicked);
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Image = global::LawtechPTSystem.Properties.Resources.Add;
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.addToolStripMenuItem.Text = "新增";
            // 
            // edittoolStripMenuItem
            // 
            this.edittoolStripMenuItem.Image = global::LawtechPTSystem.Properties.Resources.Edit;
            this.edittoolStripMenuItem.Name = "edittoolStripMenuItem";
            this.edittoolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.edittoolStripMenuItem.Text = "編輯";
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Image = global::LawtechPTSystem.Properties.Resources.delete;
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.deleteToolStripMenuItem.Text = "刪除";
            // 
            // ToolStripMenuItem_KeyWorkSetting
            // 
            this.ToolStripMenuItem_KeyWorkSetting.Name = "ToolStripMenuItem_KeyWorkSetting";
            this.ToolStripMenuItem_KeyWorkSetting.Size = new System.Drawing.Size(146, 22);
            this.ToolStripMenuItem_KeyWorkSetting.Text = "關鍵字設定";
            this.ToolStripMenuItem_KeyWorkSetting.Visible = false;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(143, 6);
            // 
            // ToolStripMenuItem_UpLoad
            // 
            this.ToolStripMenuItem_UpLoad.Image = global::LawtechPTSystem.Properties.Resources.UploadIcon;
            this.ToolStripMenuItem_UpLoad.Name = "ToolStripMenuItem_UpLoad";
            this.ToolStripMenuItem_UpLoad.Size = new System.Drawing.Size(146, 22);
            this.ToolStripMenuItem_UpLoad.Text = "上傳相關附件";
            // 
            // toolStripMenuItem_OpenFile
            // 
            this.toolStripMenuItem_OpenFile.Image = global::LawtechPTSystem.Properties.Resources.Download_Icon;
            this.toolStripMenuItem_OpenFile.Name = "toolStripMenuItem_OpenFile";
            this.toolStripMenuItem_OpenFile.Size = new System.Drawing.Size(146, 22);
            this.toolStripMenuItem_OpenFile.Text = "開啟相關附件";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(143, 6);
            // 
            // toolStripMenuItem_Horizontal
            // 
            this.toolStripMenuItem_Horizontal.Image = global::LawtechPTSystem.Properties.Resources.Vertical;
            this.toolStripMenuItem_Horizontal.Name = "toolStripMenuItem_Horizontal";
            this.toolStripMenuItem_Horizontal.Size = new System.Drawing.Size(146, 22);
            this.toolStripMenuItem_Horizontal.Text = "水平/垂直";
            // 
            // uploadTBindingSource
            // 
            this.uploadTBindingSource.DataMember = "UploadT";
            this.uploadTBindingSource.DataSource = this.dataSet_KM;
            // 
            // dataSet_KM
            // 
            this.dataSet_KM.DataSetName = "DataSet_KM";
            this.dataSet_KM.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btnShowAll
            // 
            this.btnShowAll.BackgroundImage = global::LawtechPTSystem.Properties.Resources.btnComfirm;
            this.btnShowAll.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnShowAll.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnShowAll.Location = new System.Drawing.Point(514, 20);
            this.btnShowAll.Margin = new System.Windows.Forms.Padding(1);
            this.btnShowAll.Name = "btnShowAll";
            this.btnShowAll.Size = new System.Drawing.Size(147, 32);
            this.btnShowAll.TabIndex = 9;
            this.btnShowAll.Text = "全部";
            this.btnShowAll.UseVisualStyleBackColor = true;
            this.btnShowAll.Click += new System.EventHandler(this.btnShowAll_Click);
            // 
            // but_Close
            // 
            this.but_Close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.but_Close.BackgroundImage = global::LawtechPTSystem.Properties.Resources.btnCancel;
            this.but_Close.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.but_Close.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.but_Close.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.but_Close.Location = new System.Drawing.Point(888, 54);
            this.but_Close.Name = "but_Close";
            this.but_Close.Size = new System.Drawing.Size(100, 32);
            this.but_Close.TabIndex = 11;
            this.but_Close.Text = "關閉";
            this.but_Close.UseVisualStyleBackColor = true;
            this.but_Close.Click += new System.EventHandler(this.but_Close_Click);
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = null;
            this.bindingNavigator1.BindingSource = this.uploadTBindingSource;
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
            this.toolStripButton_Add,
            this.toolStripButton_Edit,
            this.toolStripButton_Del,
            this.toolStripSeparator2,
            this.toolStripButton_ContainerHorizontal});
            this.bindingNavigator1.Location = new System.Drawing.Point(0, 318);
            this.bindingNavigator1.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigator1.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigator1.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigator1.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigator1.Size = new System.Drawing.Size(988, 25);
            this.bindingNavigator1.TabIndex = 12;
            this.bindingNavigator1.Text = "bindingNavigator1";
            this.bindingNavigator1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.cmsUploadSelection_ItemClicked);
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
            this.toolStripButton_Add.Text = "新增";
            // 
            // toolStripButton_Edit
            // 
            this.toolStripButton_Edit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_Edit.Image = global::LawtechPTSystem.Properties.Resources.Edit;
            this.toolStripButton_Edit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Edit.Name = "toolStripButton_Edit";
            this.toolStripButton_Edit.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_Edit.Text = "編輯";
            // 
            // toolStripButton_Del
            // 
            this.toolStripButton_Del.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_Del.Image = global::LawtechPTSystem.Properties.Resources.delete;
            this.toolStripButton_Del.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Del.Name = "toolStripButton_Del";
            this.toolStripButton_Del.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_Del.Text = "刪除";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton_ContainerHorizontal
            // 
            this.toolStripButton_ContainerHorizontal.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_ContainerHorizontal.Image = global::LawtechPTSystem.Properties.Resources.Vertical;
            this.toolStripButton_ContainerHorizontal.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_ContainerHorizontal.Name = "toolStripButton_ContainerHorizontal";
            this.toolStripButton_ContainerHorizontal.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_ContainerHorizontal.Text = "水平/垂直";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(4, 95);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgvUploadFile);
            this.splitContainer1.Panel1.Controls.Add(this.bindingNavigator1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.flowLayoutPanel1);
            this.splitContainer1.Size = new System.Drawing.Size(990, 527);
            this.splitContainer1.SplitterDistance = 345;
            this.splitContainer1.SplitterWidth = 6;
            this.splitContainer1.TabIndex = 13;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.panel1);
            this.flowLayoutPanel1.Controls.Add(this.panel2);
            this.flowLayoutPanel1.Controls.Add(this.panel3);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(1);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(988, 174);
            this.flowLayoutPanel1.TabIndex = 17;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txt_KindSN);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txt_BuildWorker);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.txt_CountrySymbol);
            this.panel1.Controls.Add(this.txt_BuildDate);
            this.panel1.Controls.Add(this.txt_Author);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(269, 160);
            this.panel1.TabIndex = 15;
            // 
            // txt_KindSN
            // 
            this.txt_KindSN.BackColor = System.Drawing.Color.White;
            this.txt_KindSN.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.txt_KindSN.Location = new System.Drawing.Point(88, 5);
            this.txt_KindSN.Margin = new System.Windows.Forms.Padding(1);
            this.txt_KindSN.Name = "txt_KindSN";
            this.txt_KindSN.ReadOnly = true;
            this.txt_KindSN.Size = new System.Drawing.Size(179, 29);
            this.txt_KindSN.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.label2.Location = new System.Drawing.Point(45, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "種類";
            // 
            // txt_BuildWorker
            // 
            this.txt_BuildWorker.BackColor = System.Drawing.Color.White;
            this.txt_BuildWorker.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.txt_BuildWorker.Location = new System.Drawing.Point(88, 97);
            this.txt_BuildWorker.Margin = new System.Windows.Forms.Padding(1);
            this.txt_BuildWorker.Name = "txt_BuildWorker";
            this.txt_BuildWorker.ReadOnly = true;
            this.txt_BuildWorker.Size = new System.Drawing.Size(179, 29);
            this.txt_BuildWorker.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.label3.Location = new System.Drawing.Point(45, 41);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "國別";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.label8.Location = new System.Drawing.Point(29, 101);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 20);
            this.label8.TabIndex = 12;
            this.label8.Text = "建立者";
            // 
            // txt_CountrySymbol
            // 
            this.txt_CountrySymbol.BackColor = System.Drawing.Color.White;
            this.txt_CountrySymbol.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.txt_CountrySymbol.Location = new System.Drawing.Point(88, 36);
            this.txt_CountrySymbol.Margin = new System.Windows.Forms.Padding(1);
            this.txt_CountrySymbol.Name = "txt_CountrySymbol";
            this.txt_CountrySymbol.ReadOnly = true;
            this.txt_CountrySymbol.Size = new System.Drawing.Size(179, 29);
            this.txt_CountrySymbol.TabIndex = 4;
            // 
            // txt_BuildDate
            // 
            this.txt_BuildDate.BackColor = System.Drawing.Color.White;
            this.txt_BuildDate.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.txt_BuildDate.Location = new System.Drawing.Point(88, 127);
            this.txt_BuildDate.Margin = new System.Windows.Forms.Padding(1);
            this.txt_BuildDate.Name = "txt_BuildDate";
            this.txt_BuildDate.ReadOnly = true;
            this.txt_BuildDate.Size = new System.Drawing.Size(179, 29);
            this.txt_BuildDate.TabIndex = 11;
            // 
            // txt_Author
            // 
            this.txt_Author.BackColor = System.Drawing.Color.White;
            this.txt_Author.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.txt_Author.Location = new System.Drawing.Point(88, 67);
            this.txt_Author.Margin = new System.Windows.Forms.Padding(1);
            this.txt_Author.Name = "txt_Author";
            this.txt_Author.ReadOnly = true;
            this.txt_Author.Size = new System.Drawing.Size(179, 29);
            this.txt_Author.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.label7.Location = new System.Drawing.Point(13, 132);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 20);
            this.label7.TabIndex = 10;
            this.label7.Text = "建立時間";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.label5.Location = new System.Drawing.Point(45, 71);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 20);
            this.label5.TabIndex = 6;
            this.label5.Text = "作者";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.txt_ArticleTitle);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Location = new System.Drawing.Point(278, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(269, 160);
            this.panel2.TabIndex = 16;
            // 
            // txt_ArticleTitle
            // 
            this.txt_ArticleTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_ArticleTitle.BackColor = System.Drawing.Color.White;
            this.txt_ArticleTitle.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.txt_ArticleTitle.Location = new System.Drawing.Point(50, 5);
            this.txt_ArticleTitle.Margin = new System.Windows.Forms.Padding(1);
            this.txt_ArticleTitle.Multiline = true;
            this.txt_ArticleTitle.Name = "txt_ArticleTitle";
            this.txt_ArticleTitle.ReadOnly = true;
            this.txt_ArticleTitle.Size = new System.Drawing.Size(209, 151);
            this.txt_ArticleTitle.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.label4.Location = new System.Drawing.Point(6, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "篇名";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.txt_Description);
            this.panel3.Controls.Add(this.linkLabel1);
            this.panel3.Location = new System.Drawing.Point(553, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(269, 160);
            this.panel3.TabIndex = 17;
            // 
            // txt_Description
            // 
            this.txt_Description.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_Description.BackColor = System.Drawing.Color.White;
            this.txt_Description.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.txt_Description.Location = new System.Drawing.Point(48, 5);
            this.txt_Description.Margin = new System.Windows.Forms.Padding(1);
            this.txt_Description.Multiline = true;
            this.txt_Description.Name = "txt_Description";
            this.txt_Description.ReadOnly = true;
            this.txt_Description.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_Description.Size = new System.Drawing.Size(218, 151);
            this.txt_Description.TabIndex = 9;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.linkLabel1.Location = new System.Drawing.Point(5, 14);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(41, 20);
            this.linkLabel1.TabIndex = 14;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "簡述";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // uploadTTableAdapter
            // 
            this.uploadTTableAdapter.ClearBeforeFill = true;
            // 
            // userControlFilterDate1
            // 
            this.userControlFilterDate1.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.userControlFilterDate1.Location = new System.Drawing.Point(8, 6);
            this.userControlFilterDate1.Margin = new System.Windows.Forms.Padding(0);
            this.userControlFilterDate1.Name = "userControlFilterDate1";
            this.userControlFilterDate1.SearchType = "UploadFile";
            this.userControlFilterDate1.Size = new System.Drawing.Size(381, 27);
            this.userControlFilterDate1.TabIndex = 1022;
            // 
            // QueryFilter1
            // 
            this.QueryFilter1.BackColor = System.Drawing.Color.Transparent;
            this.QueryFilter1.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.QueryFilter1.Location = new System.Drawing.Point(8, 35);
            this.QueryFilter1.Margin = new System.Windows.Forms.Padding(1);
            this.QueryFilter1.Name = "QueryFilter1";
            this.QueryFilter1.SearchColumnValueString = "ArticleTitle";
            this.QueryFilter1.SearchType = "UploadFile";
            this.QueryFilter1.Size = new System.Drawing.Size(401, 26);
            this.QueryFilter1.TabIndex = 1020;
            // 
            // QueryFilter2
            // 
            this.QueryFilter2.BackColor = System.Drawing.Color.Transparent;
            this.QueryFilter2.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.QueryFilter2.Location = new System.Drawing.Point(8, 63);
            this.QueryFilter2.Margin = new System.Windows.Forms.Padding(1);
            this.QueryFilter2.Name = "QueryFilter2";
            this.QueryFilter2.SearchColumnValueString = "ArticleTitle";
            this.QueryFilter2.SearchType = "UploadFile";
            this.QueryFilter2.Size = new System.Drawing.Size(401, 28);
            this.QueryFilter2.TabIndex = 1021;
            // 
            // Radio_and
            // 
            this.Radio_and.AutoSize = true;
            this.Radio_and.BackColor = System.Drawing.Color.Transparent;
            this.Radio_and.Checked = true;
            this.Radio_and.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Radio_and.Location = new System.Drawing.Point(413, 35);
            this.Radio_and.Name = "Radio_and";
            this.Radio_and.Size = new System.Drawing.Size(80, 20);
            this.Radio_and.TabIndex = 1023;
            this.Radio_and.TabStop = true;
            this.Radio_and.Text = "並且(and)";
            this.Radio_and.UseVisualStyleBackColor = false;
            // 
            // Radio_or
            // 
            this.Radio_or.AutoSize = true;
            this.Radio_or.BackColor = System.Drawing.Color.Transparent;
            this.Radio_or.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Radio_or.Location = new System.Drawing.Point(413, 63);
            this.Radio_or.Name = "Radio_or";
            this.Radio_or.Size = new System.Drawing.Size(58, 20);
            this.Radio_or.TabIndex = 1024;
            this.Radio_or.Text = "或(or)";
            this.Radio_or.UseVisualStyleBackColor = false;
            // 
            // but_ShowDetail
            // 
            this.but_ShowDetail.BackgroundImage = global::LawtechPTSystem.Properties.Resources.btnComfirm;
            this.but_ShowDetail.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.but_ShowDetail.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.but_ShowDetail.Location = new System.Drawing.Point(663, 54);
            this.but_ShowDetail.Margin = new System.Windows.Forms.Padding(1);
            this.but_ShowDetail.Name = "but_ShowDetail";
            this.but_ShowDetail.Size = new System.Drawing.Size(161, 32);
            this.but_ShowDetail.TabIndex = 1057;
            this.but_ShowDetail.Text = "開啟明細";
            this.but_ShowDetail.UseVisualStyleBackColor = true;
            this.but_ShowDetail.Click += new System.EventHandler(this.but_ShowDetail_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.BackgroundImage = global::LawtechPTSystem.Properties.Resources.btnSearch;
            this.btnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnSearch.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.btnSearch.Image = global::LawtechPTSystem.Properties.Resources.SearchIcon;
            this.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSearch.Location = new System.Drawing.Point(514, 54);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(1);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(147, 32);
            this.btnSearch.TabIndex = 1056;
            this.btnSearch.Text = "查詢";
            this.btnSearch.UseVisualStyleBackColor = true;
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
            this.Kind.DataPropertyName = "Kind";
            this.Kind.HeaderText = "文章種類";
            this.Kind.Name = "Kind";
            this.Kind.ReadOnly = true;
            this.Kind.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Kind.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // CountrySymbol
            // 
            this.CountrySymbol.DataPropertyName = "CountrySymbol";
            this.CountrySymbol.HeaderText = "CountrySymbol";
            this.CountrySymbol.Name = "CountrySymbol";
            this.CountrySymbol.ReadOnly = true;
            this.CountrySymbol.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.CountrySymbol.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.CountrySymbol.Visible = false;
            // 
            // Country
            // 
            this.Country.DataPropertyName = "Country";
            this.Country.HeaderText = "國別";
            this.Country.Name = "Country";
            this.Country.ReadOnly = true;
            // 
            // ArticleTitle
            // 
            this.ArticleTitle.DataPropertyName = "ArticleTitle";
            this.ArticleTitle.HeaderText = "篇名";
            this.ArticleTitle.Name = "ArticleTitle";
            this.ArticleTitle.ReadOnly = true;
            this.ArticleTitle.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ArticleTitle.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ArticleTitle.Width = 200;
            // 
            // Description
            // 
            this.Description.DataPropertyName = "Description";
            this.Description.HeaderText = "簡述";
            this.Description.Name = "Description";
            this.Description.ReadOnly = true;
            this.Description.Width = 150;
            // 
            // Author
            // 
            this.Author.DataPropertyName = "Author";
            this.Author.HeaderText = "作者";
            this.Author.Name = "Author";
            this.Author.ReadOnly = true;
            // 
            // RefURL
            // 
            this.RefURL.DataPropertyName = "RefURL";
            this.RefURL.HeaderText = "網路位置";
            this.RefURL.Name = "RefURL";
            this.RefURL.ReadOnly = true;
            this.RefURL.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.RefURL.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // CreateDateTime
            // 
            this.CreateDateTime.DataPropertyName = "CreateDateTime";
            dataGridViewCellStyle2.Format = "yyyy/MM/dd HH:mm";
            this.CreateDateTime.DefaultCellStyle = dataGridViewCellStyle2;
            this.CreateDateTime.HeaderText = "建立時間";
            this.CreateDateTime.Name = "CreateDateTime";
            this.CreateDateTime.ReadOnly = true;
            this.CreateDateTime.Width = 120;
            // 
            // Creator
            // 
            this.Creator.DataPropertyName = "Creator";
            this.Creator.HeaderText = "建立者";
            this.Creator.Name = "Creator";
            this.Creator.ReadOnly = true;
            this.Creator.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Creator.Width = 80;
            // 
            // LastModifyDateTime
            // 
            this.LastModifyDateTime.DataPropertyName = "LastModifyDateTime";
            dataGridViewCellStyle3.Format = "yyyy/MM/dd HH:mm";
            this.LastModifyDateTime.DefaultCellStyle = dataGridViewCellStyle3;
            this.LastModifyDateTime.HeaderText = "修改時間";
            this.LastModifyDateTime.Name = "LastModifyDateTime";
            this.LastModifyDateTime.ReadOnly = true;
            this.LastModifyDateTime.Width = 120;
            // 
            // LastModifyWorker
            // 
            this.LastModifyWorker.DataPropertyName = "LastModifyWorker";
            this.LastModifyWorker.HeaderText = "修改者";
            this.LastModifyWorker.Name = "LastModifyWorker";
            this.LastModifyWorker.ReadOnly = true;
            this.LastModifyWorker.Width = 80;
            // 
            // FilePath
            // 
            this.FilePath.DataPropertyName = "FilePath";
            this.FilePath.HeaderText = "FilePath";
            this.FilePath.Name = "FilePath";
            this.FilePath.ReadOnly = true;
            this.FilePath.Visible = false;
            // 
            // referenceDataGridViewTextBoxColumn
            // 
            this.referenceDataGridViewTextBoxColumn.DataPropertyName = "Reference";
            this.referenceDataGridViewTextBoxColumn.HeaderText = "Reference";
            this.referenceDataGridViewTextBoxColumn.Name = "referenceDataGridViewTextBoxColumn";
            this.referenceDataGridViewTextBoxColumn.ReadOnly = true;
            this.referenceDataGridViewTextBoxColumn.Visible = false;
            // 
            // fKEYDataGridViewTextBoxColumn
            // 
            this.fKEYDataGridViewTextBoxColumn.DataPropertyName = "FKEY";
            this.fKEYDataGridViewTextBoxColumn.HeaderText = "FKEY";
            this.fKEYDataGridViewTextBoxColumn.Name = "fKEYDataGridViewTextBoxColumn";
            this.fKEYDataGridViewTextBoxColumn.ReadOnly = true;
            this.fKEYDataGridViewTextBoxColumn.Visible = false;
            // 
            // subTableDataGridViewTextBoxColumn
            // 
            this.subTableDataGridViewTextBoxColumn.DataPropertyName = "SubTable";
            this.subTableDataGridViewTextBoxColumn.HeaderText = "SubTable";
            this.subTableDataGridViewTextBoxColumn.Name = "subTableDataGridViewTextBoxColumn";
            this.subTableDataGridViewTextBoxColumn.ReadOnly = true;
            this.subTableDataGridViewTextBoxColumn.Visible = false;
            // 
            // UploadFile
            // 
            this.AcceptButton = this.btnSearch;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(236)))), ((int)(((byte)(247)))));
            this.CancelButton = this.but_Close;
            this.ClientSize = new System.Drawing.Size(998, 624);
            this.Controls.Add(this.but_ShowDetail);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.Radio_and);
            this.Controls.Add(this.Radio_or);
            this.Controls.Add(this.userControlFilterDate1);
            this.Controls.Add(this.QueryFilter1);
            this.Controls.Add(this.QueryFilter2);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.but_Close);
            this.Controls.Add(this.btnShowAll);
            this.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "UploadFile";
            this.Text = "知識管理";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.UploadFile_FormClosed);
            this.Load += new System.EventHandler(this.UploadFile_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UploadFile_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUploadFile)).EndInit();
            this.cmsUploadSelection.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uploadTBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_KM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvUploadFile;
        private System.Windows.Forms.ContextMenuStrip cmsUploadSelection;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.Button btnShowAll;
        private System.Windows.Forms.Button but_Close;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_KeyWorkSetting;
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
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStripButton toolStripButton_Add;
        private System.Windows.Forms.ToolStripButton toolStripButton_Edit;
        private System.Windows.Forms.ToolStripButton toolStripButton_Del;
        private System.Windows.Forms.TextBox txt_Author;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_ArticleTitle;
        private System.Windows.Forms.TextBox txt_CountrySymbol;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_KindSN;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_BuildDate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_Description;
        private DataSet_KM dataSet_KM;
        private System.Windows.Forms.BindingSource uploadTBindingSource;
        private LawtechPTSystem.DataSet_KMTableAdapters.UploadTTableAdapter uploadTTableAdapter;
        private System.Windows.Forms.TextBox txt_BuildWorker;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ToolStripMenuItem edittoolStripMenuItem;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_UpLoad;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_OpenFile;
        private System.Windows.Forms.DataGridViewTextBoxColumn EditedDate;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButton_ContainerHorizontal;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_Horizontal;
        private System.Windows.Forms.Panel panel3;
        private US.UserControlFilterDate userControlFilterDate1;
        private US.ComboSearchColumnBox QueryFilter1;
        private US.ComboSearchColumnBox QueryFilter2;
        private System.Windows.Forms.RadioButton Radio_and;
        private System.Windows.Forms.RadioButton Radio_or;
        private System.Windows.Forms.Button but_ShowDetail;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridViewTextBoxColumn UploadKey;
        private System.Windows.Forms.DataGridViewTextBoxColumn Kind;
        private System.Windows.Forms.DataGridViewTextBoxColumn CountrySymbol;
        private System.Windows.Forms.DataGridViewTextBoxColumn Country;
        private System.Windows.Forms.DataGridViewLinkColumn ArticleTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn Author;
        private System.Windows.Forms.DataGridViewLinkColumn RefURL;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreateDateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn Creator;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastModifyDateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastModifyWorker;
        private System.Windows.Forms.DataGridViewTextBoxColumn FilePath;
        private System.Windows.Forms.DataGridViewTextBoxColumn referenceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fKEYDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn subTableDataGridViewTextBoxColumn;
    }
}