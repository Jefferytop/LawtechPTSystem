namespace LawtechPTSystemByFirm.SubFrom
{
    partial class LegalFeePhase
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LegalFeePhase));
            this.feePhaseTTableAdapter = new LawtechPTSystemByFirm.QS_DataSetTableAdapters.FeePhaseTTableAdapter();
            this.qS_DataSet = new LawtechPTSystemByFirm.QS_DataSet();
            this.feePhaseTBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.AddToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.feePhaseTDataGridView = new System.Windows.Forms.DataGridView();
            this.sortDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FeePhase = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FeePhaseID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.typeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.feePhaseTBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
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
            this.toolStripButton_del = new System.Windows.Forms.ToolStripButton();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.qS_DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.feePhaseTBindingSource)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.feePhaseTDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.feePhaseTBindingNavigator)).BeginInit();
            this.feePhaseTBindingNavigator.SuspendLayout();
            this.SuspendLayout();
            // 
            // feePhaseTTableAdapter
            // 
            this.feePhaseTTableAdapter.ClearBeforeFill = true;
            // 
            // qS_DataSet
            // 
            this.qS_DataSet.DataSetName = "QS_DataSet";
            this.qS_DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // feePhaseTBindingSource
            // 
            this.feePhaseTBindingSource.DataMember = "FeePhaseT";
            this.feePhaseTBindingSource.DataSource = this.qS_DataSet;
            this.feePhaseTBindingSource.Sort = "sort";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddToolStripMenuItem,
            this.DelToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(149, 48);
            this.contextMenuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuStrip1_ItemClicked);
            // 
            // AddToolStripMenuItem
            // 
            this.AddToolStripMenuItem.Name = "AddToolStripMenuItem";
            this.AddToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.AddToolStripMenuItem.Text = "新增費用種類";
            // 
            // DelToolStripMenuItem
            // 
            this.DelToolStripMenuItem.Name = "DelToolStripMenuItem";
            this.DelToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.DelToolStripMenuItem.Text = "刪除費用種類";
            // 
            // feePhaseTDataGridView
            // 
            this.feePhaseTDataGridView.AllowUserToAddRows = false;
            this.feePhaseTDataGridView.AllowUserToDeleteRows = false;
            this.feePhaseTDataGridView.AllowUserToOrderColumns = true;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.LightCyan;
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.feePhaseTDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.feePhaseTDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.feePhaseTDataGridView.AutoGenerateColumns = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.feePhaseTDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.feePhaseTDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.sortDataGridViewTextBoxColumn,
            this.FeePhase,
            this.FeePhaseID,
            this.typeDataGridViewTextBoxColumn});
            this.feePhaseTDataGridView.ContextMenuStrip = this.contextMenuStrip1;
            this.feePhaseTDataGridView.DataSource = this.feePhaseTBindingSource;
            this.feePhaseTDataGridView.Location = new System.Drawing.Point(2, 43);
            this.feePhaseTDataGridView.Margin = new System.Windows.Forms.Padding(1);
            this.feePhaseTDataGridView.Name = "feePhaseTDataGridView";
            this.feePhaseTDataGridView.RowTemplate.Height = 24;
            this.feePhaseTDataGridView.Size = new System.Drawing.Size(768, 607);
            this.feePhaseTDataGridView.TabIndex = 505;
            // 
            // sortDataGridViewTextBoxColumn
            // 
            this.sortDataGridViewTextBoxColumn.DataPropertyName = "Sort";
            this.sortDataGridViewTextBoxColumn.HeaderText = "排序";
            this.sortDataGridViewTextBoxColumn.Name = "sortDataGridViewTextBoxColumn";
            this.sortDataGridViewTextBoxColumn.Width = 60;
            // 
            // FeePhase
            // 
            this.FeePhase.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.FeePhase.DataPropertyName = "FeePhase";
            this.FeePhase.HeaderText = "費用種類";
            this.FeePhase.Name = "FeePhase";
            // 
            // FeePhaseID
            // 
            this.FeePhaseID.DataPropertyName = "FeePhaseID";
            this.FeePhaseID.HeaderText = "FeePhaseID";
            this.FeePhaseID.Name = "FeePhaseID";
            this.FeePhaseID.ReadOnly = true;
            this.FeePhaseID.Visible = false;
            // 
            // typeDataGridViewTextBoxColumn
            // 
            this.typeDataGridViewTextBoxColumn.DataPropertyName = "Type";
            this.typeDataGridViewTextBoxColumn.HeaderText = "Type";
            this.typeDataGridViewTextBoxColumn.Name = "typeDataGridViewTextBoxColumn";
            this.typeDataGridViewTextBoxColumn.Visible = false;
            // 
            // feePhaseTBindingNavigator
            // 
            this.feePhaseTBindingNavigator.AddNewItem = null;
            this.feePhaseTBindingNavigator.BindingSource = this.feePhaseTBindingSource;
            this.feePhaseTBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.feePhaseTBindingNavigator.DeleteItem = null;
            this.feePhaseTBindingNavigator.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.feePhaseTBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.toolStripButton_del});
            this.feePhaseTBindingNavigator.Location = new System.Drawing.Point(0, 653);
            this.feePhaseTBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.feePhaseTBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.feePhaseTBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.feePhaseTBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.feePhaseTBindingNavigator.Name = "feePhaseTBindingNavigator";
            this.feePhaseTBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.feePhaseTBindingNavigator.Size = new System.Drawing.Size(772, 25);
            this.feePhaseTBindingNavigator.TabIndex = 507;
            this.feePhaseTBindingNavigator.Text = "bindingNavigator1";
            this.feePhaseTBindingNavigator.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuStrip1_ItemClicked);
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(28, 22);
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
            // toolStripButton_Add
            // 
            this.toolStripButton_Add.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_Add.Image = global::LawtechPTSystemByFirm.Properties.Resources.Add;
            this.toolStripButton_Add.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Add.Name = "toolStripButton_Add";
            this.toolStripButton_Add.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_Add.Text = "新增";
            // 
            // toolStripButton_del
            // 
            this.toolStripButton_del.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_del.Image = global::LawtechPTSystemByFirm.Properties.Resources.delete;
            this.toolStripButton_del.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_del.Name = "toolStripButton_del";
            this.toolStripButton_del.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_del.Text = "刪除";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackgroundImage = global::LawtechPTSystemByFirm.Properties.Resources.btnCancel;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.button1.Location = new System.Drawing.Point(672, 9);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 30);
            this.button1.TabIndex = 508;
            this.button1.Text = "關閉";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // LegalFeePhase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
           //this.BackgroundImage = global::LawtechPTSystemByFirm.Properties.Resources.Bg_白paper_34;
            this.ClientSize = new System.Drawing.Size(772, 678);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.feePhaseTBindingNavigator);
            this.Controls.Add(this.feePhaseTDataGridView);
            this.Name = "LegalFeePhase";
            this.Text = "法務--費用種類";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.LegalFeePhase_FormClosed);
            this.Load += new System.EventHandler(this.LegalFeePhase_Load);
            ((System.ComponentModel.ISupportInitialize)(this.qS_DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.feePhaseTBindingSource)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.feePhaseTDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.feePhaseTBindingNavigator)).EndInit();
            this.feePhaseTBindingNavigator.ResumeLayout(false);
            this.feePhaseTBindingNavigator.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private LawtechPTSystemByFirm.QS_DataSetTableAdapters.FeePhaseTTableAdapter feePhaseTTableAdapter;
        private QS_DataSet qS_DataSet;
        private System.Windows.Forms.BindingSource feePhaseTBindingSource;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem AddToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DelToolStripMenuItem;
        private System.Windows.Forms.DataGridView feePhaseTDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn sortDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn FeePhase;
        private System.Windows.Forms.DataGridViewTextBoxColumn FeePhaseID;
        private System.Windows.Forms.DataGridViewTextBoxColumn typeDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingNavigator feePhaseTBindingNavigator;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButton_Add;
        private System.Windows.Forms.ToolStripButton toolStripButton_del;
        private System.Windows.Forms.Button button1;
    }
}