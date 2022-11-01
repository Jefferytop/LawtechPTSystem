
namespace LawtechPTSystem.SubFrom
{
    partial class PatentWorkerEventFinish
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PatentWorkerEventFinish));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.rb_or = new System.Windows.Forms.RadioButton();
            this.rb_and = new System.Windows.Forms.RadioButton();
            this.butClose = new System.Windows.Forms.Button();
            this.butQuery = new System.Windows.Forms.Button();
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
            this.toolStripButtonEditItem = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_Export = new System.Windows.Forms.ToolStripButton();
            this.dgViewMF = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem_Add = new System.Windows.Forms.ToolStripMenuItem();
            this.EdittoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ToolStripMenuItem_SendMail = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_SetGridColumn = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem_Csv = new System.Windows.Forms.ToolStripMenuItem();
            this.tagTitle2 = new LawtechPTSystem.US.TagTitle();
            this.QueryFilter2 = new LawtechPTSystem.US.ComboSearchColumnBox();
            this.QueryFilter1 = new LawtechPTSystem.US.ComboSearchColumnBox();
            this.userControlFilterDate1 = new LawtechPTSystem.US.UserControlFilterDate();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgViewMF)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rb_or
            // 
            this.rb_or.AutoSize = true;
            this.rb_or.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.rb_or.Location = new System.Drawing.Point(392, 69);
            this.rb_or.Name = "rb_or";
            this.rb_or.Size = new System.Drawing.Size(58, 20);
            this.rb_or.TabIndex = 1032;
            this.rb_or.Text = "或(or)";
            this.rb_or.UseVisualStyleBackColor = true;
            // 
            // rb_and
            // 
            this.rb_and.AutoSize = true;
            this.rb_and.Checked = true;
            this.rb_and.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.rb_and.Location = new System.Drawing.Point(392, 41);
            this.rb_and.Name = "rb_and";
            this.rb_and.Size = new System.Drawing.Size(80, 20);
            this.rb_and.TabIndex = 1031;
            this.rb_and.TabStop = true;
            this.rb_and.Text = "並且(and)";
            this.rb_and.UseVisualStyleBackColor = true;
            // 
            // butClose
            // 
            this.butClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.butClose.BackgroundImage = global::LawtechPTSystem.Properties.Resources.btnCancel;
            this.butClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.butClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.butClose.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.butClose.Location = new System.Drawing.Point(964, 57);
            this.butClose.Margin = new System.Windows.Forms.Padding(1);
            this.butClose.Name = "butClose";
            this.butClose.Size = new System.Drawing.Size(100, 32);
            this.butClose.TabIndex = 1030;
            this.butClose.Text = "關閉";
            this.butClose.UseVisualStyleBackColor = true;
            this.butClose.Click += new System.EventHandler(this.butClose_Click);
            // 
            // butQuery
            // 
            this.butQuery.BackgroundImage = global::LawtechPTSystem.Properties.Resources.btnSearch;
            this.butQuery.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.butQuery.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.butQuery.Image = global::LawtechPTSystem.Properties.Resources.SearchIcon;
            this.butQuery.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.butQuery.Location = new System.Drawing.Point(500, 57);
            this.butQuery.Margin = new System.Windows.Forms.Padding(1);
            this.butQuery.Name = "butQuery";
            this.butQuery.Size = new System.Drawing.Size(150, 32);
            this.butQuery.TabIndex = 1028;
            this.butQuery.Text = "查  詢";
            this.butQuery.UseVisualStyleBackColor = true;
            this.butQuery.Click += new System.EventHandler(this.butQuery_Click);
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
            this.toolStripButton_Add,
            this.toolStripButtonEditItem,
            this.toolStripButton_Export});
            this.bindingNavigator1.Location = new System.Drawing.Point(0, 602);
            this.bindingNavigator1.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigator1.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigator1.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigator1.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigator1.Size = new System.Drawing.Size(1074, 25);
            this.bindingNavigator1.TabIndex = 1058;
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
            this.bindingNavigatorPositionItem.Font = new System.Drawing.Font("Microsoft JhengHei UI", 9F);
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
            this.toolStripButton_Add.Image = global::LawtechPTSystem.Properties.Resources.Add;
            this.toolStripButton_Add.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Add.Name = "toolStripButton_Add";
            this.toolStripButton_Add.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_Add.Tag = "Create";
            this.toolStripButton_Add.Text = "新增事件記錄";
            // 
            // toolStripButtonEditItem
            // 
            this.toolStripButtonEditItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonEditItem.Image = global::LawtechPTSystem.Properties.Resources.Edit;
            this.toolStripButtonEditItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonEditItem.Name = "toolStripButtonEditItem";
            this.toolStripButtonEditItem.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonEditItem.Tag = "Modify";
            this.toolStripButtonEditItem.Text = "編輯事件記錄";
            // 
            // toolStripButton_Export
            // 
            this.toolStripButton_Export.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_Export.Image = global::LawtechPTSystem.Properties.Resources.csv_text;
            this.toolStripButton_Export.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Export.Name = "toolStripButton_Export";
            this.toolStripButton_Export.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_Export.Tag = "Export";
            this.toolStripButton_Export.Text = "匯出CSV";
            // 
            // dgViewMF
            // 
            this.dgViewMF.AllowUserToAddRows = false;
            this.dgViewMF.AllowUserToDeleteRows = false;
            this.dgViewMF.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.dgViewMF.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgViewMF.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微軟正黑體", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgViewMF.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgViewMF.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgViewMF.ContextMenuStrip = this.contextMenuStrip1;
            this.dgViewMF.ImeMode = System.Windows.Forms.ImeMode.Close;
            this.dgViewMF.Location = new System.Drawing.Point(9, 127);
            this.dgViewMF.Margin = new System.Windows.Forms.Padding(1);
            this.dgViewMF.Name = "dgViewMF";
            this.dgViewMF.ReadOnly = true;
            this.dgViewMF.RowHeadersWidth = 25;
            this.dgViewMF.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.LightSkyBlue;
            this.dgViewMF.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue;
            this.dgViewMF.RowTemplate.Height = 24;
            this.dgViewMF.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgViewMF.Size = new System.Drawing.Size(1055, 474);
            this.dgViewMF.TabIndex = 1057;
            this.dgViewMF.Tag = "PatentWorkerEventFinish";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_Add,
            this.EdittoolStripMenuItem,
            this.toolStripSeparator1,
            this.ToolStripMenuItem_SendMail,
            this.toolStripMenuItem_SetGridColumn,
            this.toolStripSeparator2,
            this.toolStripMenuItem_Csv});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(181, 148);
            this.contextMenuStrip1.Tag = "Modify";
            this.contextMenuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuStrip1_ItemClicked);
            // 
            // toolStripMenuItem_Add
            // 
            this.toolStripMenuItem_Add.Image = global::LawtechPTSystem.Properties.Resources.Add;
            this.toolStripMenuItem_Add.Name = "toolStripMenuItem_Add";
            this.toolStripMenuItem_Add.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem_Add.Tag = "Create";
            this.toolStripMenuItem_Add.Text = "新增事件記錄";
            // 
            // EdittoolStripMenuItem
            // 
            this.EdittoolStripMenuItem.Image = global::LawtechPTSystem.Properties.Resources.Edit;
            this.EdittoolStripMenuItem.Name = "EdittoolStripMenuItem";
            this.EdittoolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.EdittoolStripMenuItem.Tag = "Modify";
            this.EdittoolStripMenuItem.Text = "編輯事件記綠";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // ToolStripMenuItem_SendMail
            // 
            this.ToolStripMenuItem_SendMail.Image = global::LawtechPTSystem.Properties.Resources.email_open;
            this.ToolStripMenuItem_SendMail.Name = "ToolStripMenuItem_SendMail";
            this.ToolStripMenuItem_SendMail.Size = new System.Drawing.Size(180, 22);
            this.ToolStripMenuItem_SendMail.Text = "發通知郵件";
            // 
            // toolStripMenuItem_SetGridColumn
            // 
            this.toolStripMenuItem_SetGridColumn.Image = global::LawtechPTSystem.Properties.Resources.columns;
            this.toolStripMenuItem_SetGridColumn.Name = "toolStripMenuItem_SetGridColumn";
            this.toolStripMenuItem_SetGridColumn.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem_SetGridColumn.Text = "設定列表欄位";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(177, 6);
            // 
            // toolStripMenuItem_Csv
            // 
            this.toolStripMenuItem_Csv.Image = global::LawtechPTSystem.Properties.Resources.csv_text;
            this.toolStripMenuItem_Csv.Name = "toolStripMenuItem_Csv";
            this.toolStripMenuItem_Csv.Size = new System.Drawing.Size(180, 22);
            this.toolStripMenuItem_Csv.Tag = "Export";
            this.toolStripMenuItem_Csv.Text = "匯出成CSV";
            // 
            // tagTitle2
            // 
            this.tagTitle2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tagTitle2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tagTitle2.BackgroundImage")));
            this.tagTitle2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tagTitle2.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tagTitle2.Location = new System.Drawing.Point(9, 98);
            this.tagTitle2.Margin = new System.Windows.Forms.Padding(0);
            this.tagTitle2.Name = "tagTitle2";
            this.tagTitle2.Size = new System.Drawing.Size(1055, 32);
            this.tagTitle2.TabIndex = 1059;
            this.tagTitle2.TagTitleStyle = "Style1";
            this.tagTitle2.TitleLableText = "專利事件記錄列表";
            // 
            // QueryFilter2
            // 
            this.QueryFilter2.BackColor = System.Drawing.Color.Transparent;
            this.QueryFilter2.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.QueryFilter2.Location = new System.Drawing.Point(9, 66);
            this.QueryFilter2.Margin = new System.Windows.Forms.Padding(3, 21, 3, 21);
            this.QueryFilter2.Name = "QueryFilter2";
            this.QueryFilter2.SearchColumnValueString = "PatentNo";
            this.QueryFilter2.SearchType = "PatentWorkerEventFinish";
            this.QueryFilter2.Size = new System.Drawing.Size(378, 27);
            this.QueryFilter2.TabIndex = 1035;
            // 
            // QueryFilter1
            // 
            this.QueryFilter1.BackColor = System.Drawing.Color.Transparent;
            this.QueryFilter1.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.QueryFilter1.Location = new System.Drawing.Point(9, 38);
            this.QueryFilter1.Margin = new System.Windows.Forms.Padding(1);
            this.QueryFilter1.Name = "QueryFilter1";
            this.QueryFilter1.SearchColumnValueString = "PatentNo";
            this.QueryFilter1.SearchType = "PatentWorkerEventFinish";
            this.QueryFilter1.Size = new System.Drawing.Size(378, 27);
            this.QueryFilter1.TabIndex = 1034;
            // 
            // userControlFilterDate1
            // 
            this.userControlFilterDate1.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.userControlFilterDate1.Location = new System.Drawing.Point(9, 9);
            this.userControlFilterDate1.Margin = new System.Windows.Forms.Padding(0);
            this.userControlFilterDate1.Name = "userControlFilterDate1";
            this.userControlFilterDate1.SearchType = "PatentWorkerEventFinish";
            this.userControlFilterDate1.Size = new System.Drawing.Size(381, 27);
            this.userControlFilterDate1.TabIndex = 1033;
            // 
            // PatentWorkerEventFinish
            // 
            this.AcceptButton = this.butQuery;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(236)))), ((int)(((byte)(247)))));
            this.CancelButton = this.butClose;
            this.ClientSize = new System.Drawing.Size(1074, 627);
            this.Controls.Add(this.bindingNavigator1);
            this.Controls.Add(this.dgViewMF);
            this.Controls.Add(this.tagTitle2);
            this.Controls.Add(this.QueryFilter2);
            this.Controls.Add(this.QueryFilter1);
            this.Controls.Add(this.userControlFilterDate1);
            this.Controls.Add(this.rb_or);
            this.Controls.Add(this.rb_and);
            this.Controls.Add(this.butClose);
            this.Controls.Add(this.butQuery);
            this.Font = new System.Drawing.Font("微軟正黑體", 9F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PatentWorkerEventFinish";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "查看個人完成事件(專利)";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PatentWorkerEventFinish_FormClosed);
            this.Load += new System.EventHandler(this.PatentWorkerEventFinish_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgViewMF)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private US.ComboSearchColumnBox QueryFilter2;
        private US.ComboSearchColumnBox QueryFilter1;
        private US.UserControlFilterDate userControlFilterDate1;
        private System.Windows.Forms.RadioButton rb_or;
        private System.Windows.Forms.RadioButton rb_and;
        private System.Windows.Forms.Button butClose;
        private System.Windows.Forms.Button butQuery;
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
        private System.Windows.Forms.ToolStripButton toolStripButton_Export;
        internal System.Windows.Forms.DataGridView dgViewMF;
        private US.TagTitle tagTitle2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem EdittoolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_SetGridColumn;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_SendMail;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_Add;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_Csv;
        private System.Windows.Forms.ToolStripButton toolStripButton_Add;
        private System.Windows.Forms.ToolStripButton toolStripButtonEditItem;
    }
}