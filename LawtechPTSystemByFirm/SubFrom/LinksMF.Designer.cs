namespace LawtechPTSystemByFirm.SubFrom
{
    partial class LinksMF
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LinksMF));
            this.but_Close = new System.Windows.Forms.Button();
            this.but_Search = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem_Add = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_Edit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_Del = new System.Windows.Forms.ToolStripMenuItem();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet_News = new LawtechPTSystemByFirm.DataSet_News();
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
            this.Radio_or = new System.Windows.Forms.RadioButton();
            this.Radio_and = new System.Windows.Forms.RadioButton();
            this.typeNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sortDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.webSiteNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.typeNameDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sortDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.webSiteNameDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WebAddressColumn = new System.Windows.Forms.DataGridViewLinkColumn();
            this.descriptionDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.linksKeyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.newsTypeKeyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.linksTableAdapter = new LawtechPTSystemByFirm.DataSet_NewsTableAdapters.LinksTableAdapter();
            this.QueryFilter2 = new LawtechPTSystemByFirm.US.ComboSearchColumnBox();
            this.QueryFilter1 = new LawtechPTSystemByFirm.US.ComboSearchColumnBox();
            this.userControlFilterDate1 = new LawtechPTSystemByFirm.US.UserControlFilterDate();
            this.tagTitle1 = new LawtechPTSystemByFirm.US.TagTitle();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_News)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            this.SuspendLayout();
            // 
            // but_Close
            // 
            this.but_Close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.but_Close.BackgroundImage = global::LawtechPTSystemByFirm.Properties.Resources.btnCancel;
            this.but_Close.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.but_Close.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.but_Close.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.but_Close.Location = new System.Drawing.Point(759, 66);
            this.but_Close.Name = "but_Close";
            this.but_Close.Size = new System.Drawing.Size(100, 30);
            this.but_Close.TabIndex = 1049;
            this.but_Close.Text = "關  閉";
            this.but_Close.UseVisualStyleBackColor = true;
            this.but_Close.Click += new System.EventHandler(this.but_Close_Click);
            // 
            // but_Search
            // 
            this.but_Search.BackgroundImage = global::LawtechPTSystemByFirm.Properties.Resources.btnSearch;
            this.but_Search.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.but_Search.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.but_Search.Image = global::LawtechPTSystemByFirm.Properties.Resources.SearchIcon;
            this.but_Search.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.but_Search.Location = new System.Drawing.Point(506, 66);
            this.but_Search.Name = "but_Search";
            this.but_Search.Size = new System.Drawing.Size(150, 30);
            this.but_Search.TabIndex = 1048;
            this.but_Search.Text = "查詢";
            this.but_Search.UseVisualStyleBackColor = true;
            this.but_Search.Click += new System.EventHandler(this.but_Search_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Blue;
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoGenerateColumns = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.ContextMenuStrip = this.contextMenuStrip1;
            this.dataGridView1.DataSource = this.bindingSource1;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微軟正黑體", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.Location = new System.Drawing.Point(4, 129);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 25;
            this.dataGridView1.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.dataGridView1.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(855, 476);
            this.dataGridView1.TabIndex = 1051;
            this.dataGridView1.Tag = "Links";
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            this.dataGridView1.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridView1_DataError);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_Add,
            this.toolStripMenuItem_Edit,
            this.toolStripMenuItem_Del});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(99, 70);
            this.contextMenuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuStrip1_ItemClicked);
            // 
            // toolStripMenuItem_Add
            // 
            this.toolStripMenuItem_Add.Image = global::LawtechPTSystemByFirm.Properties.Resources.Add;
            this.toolStripMenuItem_Add.Name = "toolStripMenuItem_Add";
            this.toolStripMenuItem_Add.Size = new System.Drawing.Size(98, 22);
            this.toolStripMenuItem_Add.Tag = "Create";
            this.toolStripMenuItem_Add.Text = "新增";
            // 
            // toolStripMenuItem_Edit
            // 
            this.toolStripMenuItem_Edit.Image = global::LawtechPTSystemByFirm.Properties.Resources.Edit;
            this.toolStripMenuItem_Edit.Name = "toolStripMenuItem_Edit";
            this.toolStripMenuItem_Edit.Size = new System.Drawing.Size(98, 22);
            this.toolStripMenuItem_Edit.Tag = "Modify";
            this.toolStripMenuItem_Edit.Text = "編輯";
            // 
            // toolStripMenuItem_Del
            // 
            this.toolStripMenuItem_Del.Image = global::LawtechPTSystemByFirm.Properties.Resources.delete;
            this.toolStripMenuItem_Del.Name = "toolStripMenuItem_Del";
            this.toolStripMenuItem_Del.Size = new System.Drawing.Size(98, 22);
            this.toolStripMenuItem_Del.Tag = "Delete";
            this.toolStripMenuItem_Del.Text = "刪除";
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataMember = "Links";
            this.bindingSource1.DataSource = this.dataSet_News;
            // 
            // dataSet_News
            // 
            this.dataSet_News.DataSetName = "DataSet_News";
            this.dataSet_News.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = null;
            this.bindingNavigator1.BindingSource = this.bindingSource1;
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
            this.toolStripButton_Del});
            this.bindingNavigator1.Location = new System.Drawing.Point(0, 605);
            this.bindingNavigator1.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigator1.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigator1.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigator1.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigator1.Size = new System.Drawing.Size(863, 25);
            this.bindingNavigator1.TabIndex = 1052;
            this.bindingNavigator1.Text = "bindingNavigator1";
            this.bindingNavigator1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuStrip1_ItemClicked);
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
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 23);
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
            this.toolStripButton_Add.Image = global::LawtechPTSystemByFirm.Properties.Resources.Add;
            this.toolStripButton_Add.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Add.Name = "toolStripButton_Add";
            this.toolStripButton_Add.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_Add.Tag = "Create";
            this.toolStripButton_Add.Text = "新增";
            // 
            // toolStripButton_Edit
            // 
            this.toolStripButton_Edit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_Edit.Image = global::LawtechPTSystemByFirm.Properties.Resources.Edit;
            this.toolStripButton_Edit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Edit.Name = "toolStripButton_Edit";
            this.toolStripButton_Edit.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_Edit.Tag = "Modify";
            this.toolStripButton_Edit.Text = "編輯";
            // 
            // toolStripButton_Del
            // 
            this.toolStripButton_Del.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_Del.Image = global::LawtechPTSystemByFirm.Properties.Resources.delete;
            this.toolStripButton_Del.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Del.Name = "toolStripButton_Del";
            this.toolStripButton_Del.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_Del.Tag = "Delete";
            this.toolStripButton_Del.Text = "刪除";
            // 
            // Radio_or
            // 
            this.Radio_or.AutoSize = true;
            this.Radio_or.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Radio_or.Location = new System.Drawing.Point(413, 74);
            this.Radio_or.Name = "Radio_or";
            this.Radio_or.Size = new System.Drawing.Size(58, 20);
            this.Radio_or.TabIndex = 1054;
            this.Radio_or.Text = "或(or)";
            this.Radio_or.UseVisualStyleBackColor = true;
            // 
            // Radio_and
            // 
            this.Radio_and.AutoSize = true;
            this.Radio_and.Checked = true;
            this.Radio_and.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Radio_and.Location = new System.Drawing.Point(413, 44);
            this.Radio_and.Name = "Radio_and";
            this.Radio_and.Size = new System.Drawing.Size(80, 20);
            this.Radio_and.TabIndex = 1053;
            this.Radio_and.TabStop = true;
            this.Radio_and.Text = "並且(and)";
            this.Radio_and.UseVisualStyleBackColor = true;
            // 
            // typeNameDataGridViewTextBoxColumn
            // 
            this.typeNameDataGridViewTextBoxColumn.DataPropertyName = "TypeName";
            this.typeNameDataGridViewTextBoxColumn.HeaderText = "TypeName";
            this.typeNameDataGridViewTextBoxColumn.Name = "typeNameDataGridViewTextBoxColumn";
            this.typeNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.typeNameDataGridViewTextBoxColumn.ToolTipText = "TypeName";
            // 
            // sortDataGridViewTextBoxColumn
            // 
            this.sortDataGridViewTextBoxColumn.DataPropertyName = "Sort";
            this.sortDataGridViewTextBoxColumn.HeaderText = "Sort";
            this.sortDataGridViewTextBoxColumn.Name = "sortDataGridViewTextBoxColumn";
            this.sortDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // webSiteNameDataGridViewTextBoxColumn
            // 
            this.webSiteNameDataGridViewTextBoxColumn.DataPropertyName = "WebSiteName";
            this.webSiteNameDataGridViewTextBoxColumn.HeaderText = "WebSiteName";
            this.webSiteNameDataGridViewTextBoxColumn.Name = "webSiteNameDataGridViewTextBoxColumn";
            this.webSiteNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.webSiteNameDataGridViewTextBoxColumn.ToolTipText = "WebSiteName";
            // 
            // descriptionDataGridViewTextBoxColumn
            // 
            this.descriptionDataGridViewTextBoxColumn.DataPropertyName = "Description";
            this.descriptionDataGridViewTextBoxColumn.HeaderText = "Description";
            this.descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
            this.descriptionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // typeNameDataGridViewTextBoxColumn1
            // 
            this.typeNameDataGridViewTextBoxColumn1.DataPropertyName = "TypeName";
            this.typeNameDataGridViewTextBoxColumn1.HeaderText = "類型";
            this.typeNameDataGridViewTextBoxColumn1.Name = "typeNameDataGridViewTextBoxColumn1";
            this.typeNameDataGridViewTextBoxColumn1.ReadOnly = true;
            this.typeNameDataGridViewTextBoxColumn1.ToolTipText = "TypeName";
            this.typeNameDataGridViewTextBoxColumn1.Width = 80;
            // 
            // sortDataGridViewTextBoxColumn1
            // 
            this.sortDataGridViewTextBoxColumn1.DataPropertyName = "Sort";
            this.sortDataGridViewTextBoxColumn1.HeaderText = "排序";
            this.sortDataGridViewTextBoxColumn1.Name = "sortDataGridViewTextBoxColumn1";
            this.sortDataGridViewTextBoxColumn1.ReadOnly = true;
            this.sortDataGridViewTextBoxColumn1.ToolTipText = "Sort";
            // 
            // webSiteNameDataGridViewTextBoxColumn1
            // 
            this.webSiteNameDataGridViewTextBoxColumn1.DataPropertyName = "WebSiteName";
            this.webSiteNameDataGridViewTextBoxColumn1.HeaderText = "網站名稱";
            this.webSiteNameDataGridViewTextBoxColumn1.Name = "webSiteNameDataGridViewTextBoxColumn1";
            this.webSiteNameDataGridViewTextBoxColumn1.ReadOnly = true;
            this.webSiteNameDataGridViewTextBoxColumn1.ToolTipText = "WebSiteName";
            // 
            // WebAddressColumn
            // 
            this.WebAddressColumn.DataPropertyName = "WebAddress";
            this.WebAddressColumn.HeaderText = "網址";
            this.WebAddressColumn.Name = "WebAddressColumn";
            this.WebAddressColumn.ReadOnly = true;
            this.WebAddressColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.WebAddressColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.WebAddressColumn.Text = "WebAddress";
            // 
            // descriptionDataGridViewTextBoxColumn1
            // 
            this.descriptionDataGridViewTextBoxColumn1.DataPropertyName = "Description";
            this.descriptionDataGridViewTextBoxColumn1.HeaderText = "Description";
            this.descriptionDataGridViewTextBoxColumn1.Name = "descriptionDataGridViewTextBoxColumn1";
            this.descriptionDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // linksKeyDataGridViewTextBoxColumn
            // 
            this.linksKeyDataGridViewTextBoxColumn.DataPropertyName = "LinksKey";
            this.linksKeyDataGridViewTextBoxColumn.HeaderText = "LinksKey";
            this.linksKeyDataGridViewTextBoxColumn.Name = "linksKeyDataGridViewTextBoxColumn";
            this.linksKeyDataGridViewTextBoxColumn.ReadOnly = true;
            this.linksKeyDataGridViewTextBoxColumn.Visible = false;
            // 
            // newsTypeKeyDataGridViewTextBoxColumn
            // 
            this.newsTypeKeyDataGridViewTextBoxColumn.DataPropertyName = "NewsTypeKey";
            this.newsTypeKeyDataGridViewTextBoxColumn.HeaderText = "NewsTypeKey";
            this.newsTypeKeyDataGridViewTextBoxColumn.Name = "newsTypeKeyDataGridViewTextBoxColumn";
            this.newsTypeKeyDataGridViewTextBoxColumn.ReadOnly = true;
            this.newsTypeKeyDataGridViewTextBoxColumn.Visible = false;
            // 
            // linksTableAdapter
            // 
            this.linksTableAdapter.ClearBeforeFill = true;
            // 
            // QueryFilter2
            // 
            this.QueryFilter2.BackColor = System.Drawing.Color.Transparent;
            this.QueryFilter2.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.QueryFilter2.Location = new System.Drawing.Point(9, 69);
            this.QueryFilter2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.QueryFilter2.Name = "QueryFilter2";
            this.QueryFilter2.SearchColumnValueString = "WebSiteName";
            this.QueryFilter2.SearchType = "LinksMF";
            this.QueryFilter2.Size = new System.Drawing.Size(398, 26);
            this.QueryFilter2.TabIndex = 1057;
            // 
            // QueryFilter1
            // 
            this.QueryFilter1.BackColor = System.Drawing.Color.Transparent;
            this.QueryFilter1.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.QueryFilter1.Location = new System.Drawing.Point(9, 41);
            this.QueryFilter1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.QueryFilter1.Name = "QueryFilter1";
            this.QueryFilter1.SearchColumnValueString = "WebSiteName";
            this.QueryFilter1.SearchType = "LinksMF";
            this.QueryFilter1.Size = new System.Drawing.Size(398, 26);
            this.QueryFilter1.TabIndex = 1056;
            // 
            // userControlFilterDate1
            // 
            this.userControlFilterDate1.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.userControlFilterDate1.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.userControlFilterDate1.Location = new System.Drawing.Point(9, 9);
            this.userControlFilterDate1.Margin = new System.Windows.Forms.Padding(0);
            this.userControlFilterDate1.Name = "userControlFilterDate1";
            this.userControlFilterDate1.SearchType = "NewsList";
            this.userControlFilterDate1.Size = new System.Drawing.Size(367, 32);
            this.userControlFilterDate1.TabIndex = 1055;
            // 
            // tagTitle1
            // 
            this.tagTitle1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tagTitle1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tagTitle1.BackgroundImage")));
            this.tagTitle1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tagTitle1.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tagTitle1.Location = new System.Drawing.Point(4, 101);
            this.tagTitle1.Margin = new System.Windows.Forms.Padding(0);
            this.tagTitle1.Name = "tagTitle1";
            this.tagTitle1.Size = new System.Drawing.Size(855, 32);
            this.tagTitle1.TabIndex = 1058;
            this.tagTitle1.TagTitleStyle = "Style1";
            this.tagTitle1.TitleLableText = "常用網站連結列表";
            // 
            // LinksMF
            // 
            this.AcceptButton = this.but_Search;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(236)))), ((int)(((byte)(247)))));
            this.CancelButton = this.but_Close;
            this.ClientSize = new System.Drawing.Size(863, 630);
            this.Controls.Add(this.QueryFilter2);
            this.Controls.Add(this.QueryFilter1);
            this.Controls.Add(this.userControlFilterDate1);
            this.Controls.Add(this.Radio_or);
            this.Controls.Add(this.Radio_and);
            this.Controls.Add(this.bindingNavigator1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.but_Close);
            this.Controls.Add(this.but_Search);
            this.Controls.Add(this.tagTitle1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LinksMF";
            this.Text = "常用網站連結";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.LinksMF_FormClosed);
            this.Load += new System.EventHandler(this.LinksMF_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_News)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button but_Close;
        private System.Windows.Forms.Button but_Search;
        private System.Windows.Forms.DataGridView dataGridView1;
        private DataSet_News dataSet_News;
        private LawtechPTSystemByFirm.DataSet_NewsTableAdapters.LinksTableAdapter linksTableAdapter;
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
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_Add;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_Edit;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_Del;
        private System.Windows.Forms.ToolStripButton toolStripButton_Add;
        private System.Windows.Forms.ToolStripButton toolStripButton_Edit;
        private System.Windows.Forms.ToolStripButton toolStripButton_Del;
       
        private US.ComboSearchColumnBox QueryFilter2;
        private US.ComboSearchColumnBox QueryFilter1;
        private US.UserControlFilterDate userControlFilterDate1;
        private System.Windows.Forms.RadioButton Radio_or;
        private System.Windows.Forms.RadioButton Radio_and;
        private US.TagTitle tagTitle1;
        private System.Windows.Forms.BindingSource bindingSource1;
       
        private System.Windows.Forms.DataGridViewTextBoxColumn typeNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sortDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn webSiteNameDataGridViewTextBoxColumn;
       
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
       
       
        private System.Windows.Forms.DataGridViewTextBoxColumn typeNameDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn sortDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn webSiteNameDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewLinkColumn WebAddressColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn linksKeyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn newsTypeKeyDataGridViewTextBoxColumn;
    }
}