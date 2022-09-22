namespace LawtechPTSystem.SubFrom
{
    partial class LegalTypeSet
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LegalTypeSet));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.legalTypeTBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
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
            this.toolStripButton_Del = new System.Windows.Forms.ToolStripButton();
            this.legalTypeTDataGridView = new System.Windows.Forms.DataGridView();
            this.Sort = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LegalTypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.AddtoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeltoolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LegalTypeKey = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.legalTypeTBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet_Legal = new LawtechPTSystem.DataSet_Legal();
            this.legalTypeTTableAdapter = new LawtechPTSystem.DataSet_LegalTableAdapters.LegalTypeTTableAdapter();
            this.tableAdapterManager = new LawtechPTSystem.DataSet_LegalTableAdapters.TableAdapterManager();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.legalTypeTBindingNavigator)).BeginInit();
            this.legalTypeTBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.legalTypeTDataGridView)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.legalTypeTBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_Legal)).BeginInit();
            this.SuspendLayout();
            // 
            // legalTypeTBindingNavigator
            // 
            this.legalTypeTBindingNavigator.AddNewItem = null;
            this.legalTypeTBindingNavigator.BindingSource = this.legalTypeTBindingSource;
            this.legalTypeTBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.legalTypeTBindingNavigator.DeleteItem = null;
            this.legalTypeTBindingNavigator.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.legalTypeTBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
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
            this.toolStripButton_Del});
            this.legalTypeTBindingNavigator.Location = new System.Drawing.Point(0, 457);
            this.legalTypeTBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.legalTypeTBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.legalTypeTBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.legalTypeTBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.legalTypeTBindingNavigator.Name = "legalTypeTBindingNavigator";
            this.legalTypeTBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.legalTypeTBindingNavigator.Size = new System.Drawing.Size(798, 25);
            this.legalTypeTBindingNavigator.TabIndex = 0;
            this.legalTypeTBindingNavigator.Text = "bindingNavigator1";
            this.legalTypeTBindingNavigator.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuStrip1_ItemClicked);
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
            this.toolStripButton_Add.Image = global::LawtechPTSystem.Properties.Resources.Add;
            this.toolStripButton_Add.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Add.Name = "toolStripButton_Add";
            this.toolStripButton_Add.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_Add.Text = "新增";
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
            // legalTypeTDataGridView
            // 
            this.legalTypeTDataGridView.AllowUserToAddRows = false;
            this.legalTypeTDataGridView.AllowUserToDeleteRows = false;
            this.legalTypeTDataGridView.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.LightCyan;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Blue;
            this.legalTypeTDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.legalTypeTDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.legalTypeTDataGridView.AutoGenerateColumns = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.legalTypeTDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.legalTypeTDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.legalTypeTDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.LegalTypeKey,
            this.Sort,
            this.LegalTypeName});
            this.legalTypeTDataGridView.ContextMenuStrip = this.contextMenuStrip1;
            this.legalTypeTDataGridView.DataSource = this.legalTypeTBindingSource;
            this.legalTypeTDataGridView.Location = new System.Drawing.Point(7, 38);
            this.legalTypeTDataGridView.Margin = new System.Windows.Forms.Padding(1);
            this.legalTypeTDataGridView.Name = "legalTypeTDataGridView";
            this.legalTypeTDataGridView.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.legalTypeTDataGridView.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue;
            this.legalTypeTDataGridView.RowTemplate.Height = 24;
            this.legalTypeTDataGridView.Size = new System.Drawing.Size(781, 418);
            this.legalTypeTDataGridView.TabIndex = 1;
            // 
            // Sort
            // 
            this.Sort.DataPropertyName = "Sort";
            this.Sort.HeaderText = "排序";
            this.Sort.Name = "Sort";
            this.Sort.Width = 80;
            // 
            // LegalTypeName
            // 
            this.LegalTypeName.DataPropertyName = "LegalTypeName";
            this.LegalTypeName.HeaderText = "案件類別名稱";
            this.LegalTypeName.Name = "LegalTypeName";
            this.LegalTypeName.Width = 300;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddtoolStripMenuItem,
            this.DeltoolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(149, 48);
            this.contextMenuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuStrip1_ItemClicked);
            // 
            // AddtoolStripMenuItem
            // 
            this.AddtoolStripMenuItem.Name = "AddtoolStripMenuItem";
            this.AddtoolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.AddtoolStripMenuItem.Text = "新增案件類別";
            // 
            // DeltoolStripMenuItem
            // 
            this.DeltoolStripMenuItem.Name = "DeltoolStripMenuItem";
            this.DeltoolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.DeltoolStripMenuItem.Text = "刪除案件類別";
            // 
            // LegalTypeKey
            // 
            this.LegalTypeKey.DataPropertyName = "LegalTypeKey";
            this.LegalTypeKey.HeaderText = "LegalTypeKey";
            this.LegalTypeKey.Name = "LegalTypeKey";
            this.LegalTypeKey.Visible = false;
            // 
            // legalTypeTBindingSource
            // 
            this.legalTypeTBindingSource.DataMember = "LegalTypeT";
            this.legalTypeTBindingSource.DataSource = this.dataSet_Legal;
            // 
            // dataSet_Legal
            // 
            this.dataSet_Legal.DataSetName = "DataSet_Legal";
            this.dataSet_Legal.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // legalTypeTTableAdapter
            // 
            this.legalTypeTTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.LegalContentTTableAdapter = null;
            this.tableAdapterManager.LegalProcessKindTTableAdapter = null;
            this.tableAdapterManager.LegalProcessStepETTableAdapter = null;
            this.tableAdapterManager.LegalStatusTTableAdapter = null;
            this.tableAdapterManager.LegalTypeTTableAdapter = this.legalTypeTTableAdapter;
            this.tableAdapterManager.UpdateOrder = LawtechPTSystem.DataSet_LegalTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackgroundImage = global::LawtechPTSystem.Properties.Resources.btnCancel;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.button1.Location = new System.Drawing.Point(688, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 30);
            this.button1.TabIndex = 29;
            this.button1.Text = "關閉";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // LegalTypeSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(798, 482);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.legalTypeTDataGridView);
            this.Controls.Add(this.legalTypeTBindingNavigator);
            this.Name = "LegalTypeSet";
            this.Text = "案件類別設定";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.LegalTypeSet_FormClosed);
            this.Load += new System.EventHandler(this.LegalTypeSet_Load);
            ((System.ComponentModel.ISupportInitialize)(this.legalTypeTBindingNavigator)).EndInit();
            this.legalTypeTBindingNavigator.ResumeLayout(false);
            this.legalTypeTBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.legalTypeTDataGridView)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.legalTypeTBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_Legal)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataSet_Legal dataSet_Legal;
        private System.Windows.Forms.BindingSource legalTypeTBindingSource;
        private LawtechPTSystem.DataSet_LegalTableAdapters.LegalTypeTTableAdapter legalTypeTTableAdapter;
        private LawtechPTSystem.DataSet_LegalTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.BindingNavigator legalTypeTBindingNavigator;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.DataGridView legalTypeTDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn LegalTypeKey;
        private System.Windows.Forms.DataGridViewTextBoxColumn Sort;
        private System.Windows.Forms.DataGridViewTextBoxColumn LegalTypeName;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem AddtoolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem DeltoolStripMenuItem;
        private System.Windows.Forms.ToolStripButton toolStripButton_Add;
        private System.Windows.Forms.ToolStripButton toolStripButton_Del;
        private System.Windows.Forms.Button button1;
    }
}