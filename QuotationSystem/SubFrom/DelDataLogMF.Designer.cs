namespace LawtechPTSystem.SubFrom
{
    partial class DelDataLogMF
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DelDataLogMF));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.but_Excel = new System.Windows.Forms.Button();
            this.but_Search = new System.Windows.Forms.Button();
            this.systemLogTBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.systemLogTBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton_Del = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_Del3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_ClearAll = new System.Windows.Forms.ToolStripButton();
            this.systemLogTDataGridView = new System.Windows.Forms.DataGridView();
            this.But_Record = new System.Windows.Forms.DataGridViewLinkColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem_del = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_del3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_ClearAll = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_RollBack = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.Radio_or = new System.Windows.Forms.RadioButton();
            this.Radio_and = new System.Windows.Forms.RadioButton();
            this.userControlFilterDate1 = new LawtechPTSystem.US.UserControlFilterDate();
            this.QueryFilter2 = new LawtechPTSystem.US.ComboSearchColumnBox();
            this.QueryFilter1 = new LawtechPTSystem.US.ComboSearchColumnBox();
            this.tagTitle1 = new LawtechPTSystem.US.TagTitle();
            ((System.ComponentModel.ISupportInitialize)(this.systemLogTBindingNavigator)).BeginInit();
            this.systemLogTBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.systemLogTBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.systemLogTDataGridView)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // but_Excel
            // 
            this.but_Excel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("but_Excel.BackgroundImage")));
            this.but_Excel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.but_Excel.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.but_Excel.Location = new System.Drawing.Point(645, 66);
            this.but_Excel.Margin = new System.Windows.Forms.Padding(1);
            this.but_Excel.Name = "but_Excel";
            this.but_Excel.Size = new System.Drawing.Size(120, 30);
            this.but_Excel.TabIndex = 1042;
            this.but_Excel.Text = "匯出CSV";
            this.but_Excel.UseVisualStyleBackColor = true;
            this.but_Excel.Click += new System.EventHandler(this.but_Excel_Click);
            // 
            // but_Search
            // 
            this.but_Search.BackgroundImage = global::LawtechPTSystem.Properties.Resources.btnSearch;
            this.but_Search.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.but_Search.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.but_Search.Image = global::LawtechPTSystem.Properties.Resources.SearchIcon;
            this.but_Search.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.but_Search.Location = new System.Drawing.Point(493, 66);
            this.but_Search.Margin = new System.Windows.Forms.Padding(1);
            this.but_Search.Name = "but_Search";
            this.but_Search.Size = new System.Drawing.Size(150, 30);
            this.but_Search.TabIndex = 1039;
            this.but_Search.Text = "查詢";
            this.but_Search.UseVisualStyleBackColor = true;
            this.but_Search.Click += new System.EventHandler(this.but_Search_Click);
            // 
            // systemLogTBindingNavigator
            // 
            this.systemLogTBindingNavigator.AddNewItem = null;
            this.systemLogTBindingNavigator.BindingSource = this.systemLogTBindingSource;
            this.systemLogTBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.systemLogTBindingNavigator.DeleteItem = null;
            this.systemLogTBindingNavigator.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.systemLogTBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.toolStripButton_Del,
            this.toolStripButton_Del3,
            this.toolStripButton_ClearAll});
            this.systemLogTBindingNavigator.Location = new System.Drawing.Point(0, 589);
            this.systemLogTBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.systemLogTBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.systemLogTBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.systemLogTBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.systemLogTBindingNavigator.Name = "systemLogTBindingNavigator";
            this.systemLogTBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.systemLogTBindingNavigator.Size = new System.Drawing.Size(914, 25);
            this.systemLogTBindingNavigator.TabIndex = 1049;
            this.systemLogTBindingNavigator.Text = "bindingNavigator1";
            this.systemLogTBindingNavigator.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuStrip1_ItemClicked);
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
            // toolStripButton_Del
            // 
            this.toolStripButton_Del.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_Del.Image = global::LawtechPTSystem.Properties.Resources.delete;
            this.toolStripButton_Del.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Del.Name = "toolStripButton_Del";
            this.toolStripButton_Del.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_Del.Tag = "Delete";
            this.toolStripButton_Del.Text = "刪除";
            this.toolStripButton_Del.ToolTipText = "刪除";
            // 
            // toolStripButton_Del3
            // 
            this.toolStripButton_Del3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_Del3.Image = global::LawtechPTSystem.Properties.Resources.deletelist;
            this.toolStripButton_Del3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Del3.Name = "toolStripButton_Del3";
            this.toolStripButton_Del3.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_Del3.Tag = "Delete";
            this.toolStripButton_Del3.Text = "刪除三個月前資料";
            // 
            // toolStripButton_ClearAll
            // 
            this.toolStripButton_ClearAll.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_ClearAll.Image = global::LawtechPTSystem.Properties.Resources.folder_deleteAll;
            this.toolStripButton_ClearAll.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_ClearAll.Name = "toolStripButton_ClearAll";
            this.toolStripButton_ClearAll.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_ClearAll.Tag = "Delete";
            this.toolStripButton_ClearAll.Text = "全部清空";
            // 
            // systemLogTDataGridView
            // 
            this.systemLogTDataGridView.AllowUserToAddRows = false;
            this.systemLogTDataGridView.AllowUserToDeleteRows = false;
            this.systemLogTDataGridView.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.systemLogTDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.systemLogTDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.systemLogTDataGridView.AutoGenerateColumns = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.systemLogTDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.systemLogTDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.systemLogTDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.But_Record});
            this.systemLogTDataGridView.ContextMenuStrip = this.contextMenuStrip1;
            this.systemLogTDataGridView.DataSource = this.systemLogTBindingSource;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.systemLogTDataGridView.DefaultCellStyle = dataGridViewCellStyle3;
            this.systemLogTDataGridView.Location = new System.Drawing.Point(7, 131);
            this.systemLogTDataGridView.Name = "systemLogTDataGridView";
            this.systemLogTDataGridView.ReadOnly = true;
            this.systemLogTDataGridView.RowHeadersWidth = 25;
            this.systemLogTDataGridView.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.systemLogTDataGridView.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.systemLogTDataGridView.RowTemplate.Height = 24;
            this.systemLogTDataGridView.Size = new System.Drawing.Size(901, 455);
            this.systemLogTDataGridView.TabIndex = 1049;
            this.systemLogTDataGridView.Tag = "DelDataLogMF";
            this.systemLogTDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.systemLogTDataGridView_CellClick);
            this.systemLogTDataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.systemLogTDataGridView_DataError);
            // 
            // But_Record
            // 
            this.But_Record.HeaderText = "還原";
            this.But_Record.Name = "But_Record";
            this.But_Record.ReadOnly = true;
            this.But_Record.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.But_Record.Text = "我要還原";
            this.But_Record.UseColumnTextForLinkValue = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_del,
            this.toolStripMenuItem_del3,
            this.toolStripMenuItem_ClearAll,
            this.ToolStripMenuItem_RollBack});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(181, 114);
            this.contextMenuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuStrip1_ItemClicked);
            // 
            // toolStripMenuItem_del
            // 
            this.toolStripMenuItem_del.Image = global::LawtechPTSystem.Properties.Resources.delete;
            this.toolStripMenuItem_del.Name = "toolStripMenuItem_del";
            this.toolStripMenuItem_del.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem_del.Tag = "Delete";
            this.toolStripMenuItem_del.Text = "刪除";
            // 
            // toolStripMenuItem_del3
            // 
            this.toolStripMenuItem_del3.Image = global::LawtechPTSystem.Properties.Resources.deletelist;
            this.toolStripMenuItem_del3.Name = "toolStripMenuItem_del3";
            this.toolStripMenuItem_del3.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem_del3.Tag = "Delete";
            this.toolStripMenuItem_del3.Text = "刪除三個月前資料";
            this.toolStripMenuItem_del3.ToolTipText = "刪除三個月前資料";
            // 
            // toolStripMenuItem_ClearAll
            // 
            this.toolStripMenuItem_ClearAll.Image = global::LawtechPTSystem.Properties.Resources.folder_deleteAll;
            this.toolStripMenuItem_ClearAll.Name = "toolStripMenuItem_ClearAll";
            this.toolStripMenuItem_ClearAll.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem_ClearAll.Tag = "Delete";
            this.toolStripMenuItem_ClearAll.Text = "全部清空";
            // 
            // ToolStripMenuItem_RollBack
            // 
            this.ToolStripMenuItem_RollBack.Name = "ToolStripMenuItem_RollBack";
            this.ToolStripMenuItem_RollBack.Size = new System.Drawing.Size(180, 22);
            this.ToolStripMenuItem_RollBack.Tag = "";
            this.ToolStripMenuItem_RollBack.Text = "還原該筆記錄";
            this.ToolStripMenuItem_RollBack.Visible = false;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackgroundImage = global::LawtechPTSystem.Properties.Resources.btnCancel;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.button1.Location = new System.Drawing.Point(808, 66);
            this.button1.Margin = new System.Windows.Forms.Padding(1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 30);
            this.button1.TabIndex = 1051;
            this.button1.Text = "關閉";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Radio_or
            // 
            this.Radio_or.AutoSize = true;
            this.Radio_or.BackColor = System.Drawing.Color.Transparent;
            this.Radio_or.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.Radio_or.Location = new System.Drawing.Point(396, 66);
            this.Radio_or.Name = "Radio_or";
            this.Radio_or.Size = new System.Drawing.Size(62, 22);
            this.Radio_or.TabIndex = 1056;
            this.Radio_or.Text = "或(or)";
            this.Radio_or.UseVisualStyleBackColor = false;
            // 
            // Radio_and
            // 
            this.Radio_and.AutoSize = true;
            this.Radio_and.BackColor = System.Drawing.Color.Transparent;
            this.Radio_and.Checked = true;
            this.Radio_and.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.Radio_and.Location = new System.Drawing.Point(396, 39);
            this.Radio_and.Name = "Radio_and";
            this.Radio_and.Size = new System.Drawing.Size(88, 22);
            this.Radio_and.TabIndex = 1055;
            this.Radio_and.TabStop = true;
            this.Radio_and.Text = "並且(and)";
            this.Radio_and.UseVisualStyleBackColor = false;
            // 
            // userControlFilterDate1
            // 
            this.userControlFilterDate1.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.userControlFilterDate1.Location = new System.Drawing.Point(9, 8);
            this.userControlFilterDate1.Margin = new System.Windows.Forms.Padding(0);
            this.userControlFilterDate1.Name = "userControlFilterDate1";
            this.userControlFilterDate1.SearchType = "DelDataLogMF";
            this.userControlFilterDate1.Size = new System.Drawing.Size(381, 27);
            this.userControlFilterDate1.TabIndex = 1057;
            // 
            // QueryFilter2
            // 
            this.QueryFilter2.BackColor = System.Drawing.Color.Transparent;
            this.QueryFilter2.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.QueryFilter2.Location = new System.Drawing.Point(9, 65);
            this.QueryFilter2.Margin = new System.Windows.Forms.Padding(3, 21, 3, 21);
            this.QueryFilter2.Name = "QueryFilter2";
            this.QueryFilter2.SearchColumnValueString = "DelWorker";
            this.QueryFilter2.SearchType = "DelDataLogMF";
            this.QueryFilter2.Size = new System.Drawing.Size(378, 27);
            this.QueryFilter2.TabIndex = 1059;
            // 
            // QueryFilter1
            // 
            this.QueryFilter1.BackColor = System.Drawing.Color.Transparent;
            this.QueryFilter1.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.QueryFilter1.Location = new System.Drawing.Point(9, 37);
            this.QueryFilter1.Margin = new System.Windows.Forms.Padding(1);
            this.QueryFilter1.Name = "QueryFilter1";
            this.QueryFilter1.SearchColumnValueString = "DelWorker";
            this.QueryFilter1.SearchType = "DelDataLogMF";
            this.QueryFilter1.Size = new System.Drawing.Size(378, 27);
            this.QueryFilter1.TabIndex = 1058;
            // 
            // tagTitle1
            // 
            this.tagTitle1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tagTitle1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tagTitle1.BackgroundImage")));
            this.tagTitle1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tagTitle1.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tagTitle1.Location = new System.Drawing.Point(7, 103);
            this.tagTitle1.Margin = new System.Windows.Forms.Padding(0);
            this.tagTitle1.Name = "tagTitle1";
            this.tagTitle1.Size = new System.Drawing.Size(901, 30);
            this.tagTitle1.TabIndex = 1050;
            this.tagTitle1.TagTitleStyle = "Style4";
            this.tagTitle1.TitleLableText = "§ 刪 除 記 錄 歷 史 資 料";
            // 
            // DelDataLogMF
            // 
            this.AcceptButton = this.but_Search;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(236)))), ((int)(((byte)(247)))));
            this.ClientSize = new System.Drawing.Size(914, 614);
            this.Controls.Add(this.userControlFilterDate1);
            this.Controls.Add(this.QueryFilter2);
            this.Controls.Add(this.QueryFilter1);
            this.Controls.Add(this.Radio_or);
            this.Controls.Add(this.Radio_and);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.systemLogTDataGridView);
            this.Controls.Add(this.systemLogTBindingNavigator);
            this.Controls.Add(this.but_Excel);
            this.Controls.Add(this.but_Search);
            this.Controls.Add(this.tagTitle1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DelDataLogMF";
            this.Text = "刪除記錄檔";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DelDataLogMF_FormClosed);
            this.Load += new System.EventHandler(this.DelDataLogMF_Load);
            ((System.ComponentModel.ISupportInitialize)(this.systemLogTBindingNavigator)).EndInit();
            this.systemLogTBindingNavigator.ResumeLayout(false);
            this.systemLogTBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.systemLogTBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.systemLogTDataGridView)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button but_Excel;
        private System.Windows.Forms.Button but_Search;
        private System.Windows.Forms.BindingNavigator systemLogTBindingNavigator;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.DataGridView systemLogTDataGridView;
        private System.Windows.Forms.BindingSource systemLogTBindingSource;
       
        private US.TagTitle tagTitle1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewLinkColumn But_Record;
        private System.Windows.Forms.RadioButton Radio_or;
        private System.Windows.Forms.RadioButton Radio_and;
        private US.UserControlFilterDate userControlFilterDate1;
        private US.ComboSearchColumnBox QueryFilter2;
        private US.ComboSearchColumnBox QueryFilter1;
        private System.Windows.Forms.ToolStripButton toolStripButton_Del;
        private System.Windows.Forms.ToolStripButton toolStripButton_Del3;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_del;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_del3;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_RollBack;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_ClearAll;
        private System.Windows.Forms.ToolStripButton toolStripButton_ClearAll;
    }
}