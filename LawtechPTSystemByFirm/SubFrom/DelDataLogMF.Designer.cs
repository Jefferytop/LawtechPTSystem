namespace LawtechPTSystemByFirm.SubFrom
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            this.rb_or = new System.Windows.Forms.RadioButton();
            this.rb_and = new System.Windows.Forms.RadioButton();
            this.comboBox_SelectValue1 = new System.Windows.Forms.ComboBox();
            this.comboBox_Select1 = new System.Windows.Forms.ComboBox();
            this.logSearchValueBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet_DelDataLog = new LawtechPTSystemByFirm.DataSet_DelDataLog();
            this.but_Excel = new System.Windows.Forms.Button();
            this.comboBox_SelectValue = new System.Windows.Forms.ComboBox();
            this.comboBox_Select = new System.Windows.Forms.ComboBox();
            this.logSearchValueBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.but_Search = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.maskedTextBox_D = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBox_S = new System.Windows.Forms.MaskedTextBox();
            this.comboBox_DateMode = new System.Windows.Forms.ComboBox();
            this.logSearchDataBindingSource = new System.Windows.Forms.BindingSource(this.components);
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
            this.systemLogTDataGridView = new System.Windows.Forms.DataGridView();
            this.SysLogID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DelWorkerKey = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DelTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DelTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DelContent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.But_Record = new System.Windows.Forms.DataGridViewLinkColumn();
            this.systemLogTTableAdapter = new LawtechPTSystemByFirm.DataSet_DelDataLogTableAdapters.SystemLogTTableAdapter();
            this.tableAdapterManager = new LawtechPTSystemByFirm.DataSet_DelDataLogTableAdapters.TableAdapterManager();
            this.logSearchValueTableAdapter = new LawtechPTSystemByFirm.DataSet_DelDataLogTableAdapters.LogSearchValueTableAdapter();
            this.logSearchDataTableAdapter = new LawtechPTSystemByFirm.DataSet_DelDataLogTableAdapters.LogSearchDataTableAdapter();
            this.tagTitle1 = new LawtechPTSystemByFirm.US.TagTitle();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.logSearchValueBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_DelDataLog)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.logSearchValueBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.logSearchDataBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.systemLogTBindingNavigator)).BeginInit();
            this.systemLogTBindingNavigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.systemLogTBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.systemLogTDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // rb_or
            // 
            this.rb_or.AutoSize = true;
            this.rb_or.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.rb_or.Location = new System.Drawing.Point(405, 74);
            this.rb_or.Name = "rb_or";
            this.rb_or.Size = new System.Drawing.Size(58, 20);
            this.rb_or.TabIndex = 1046;
            this.rb_or.Text = "或(or)";
            this.rb_or.UseVisualStyleBackColor = true;
            // 
            // rb_and
            // 
            this.rb_and.AutoSize = true;
            this.rb_and.Checked = true;
            this.rb_and.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.rb_and.Location = new System.Drawing.Point(405, 44);
            this.rb_and.Name = "rb_and";
            this.rb_and.Size = new System.Drawing.Size(80, 20);
            this.rb_and.TabIndex = 1045;
            this.rb_and.TabStop = true;
            this.rb_and.Text = "並且(and)";
            this.rb_and.UseVisualStyleBackColor = true;
            // 
            // comboBox_SelectValue1
            // 
            this.comboBox_SelectValue1.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.comboBox_SelectValue1.FormattingEnabled = true;
            this.comboBox_SelectValue1.Location = new System.Drawing.Point(150, 69);
            this.comboBox_SelectValue1.Margin = new System.Windows.Forms.Padding(1);
            this.comboBox_SelectValue1.Name = "comboBox_SelectValue1";
            this.comboBox_SelectValue1.Size = new System.Drawing.Size(251, 32);
            this.comboBox_SelectValue1.TabIndex = 1044;
            // 
            // comboBox_Select1
            // 
            this.comboBox_Select1.DataSource = this.logSearchValueBindingSource1;
            this.comboBox_Select1.DisplayMember = "ShowString";
            this.comboBox_Select1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Select1.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.comboBox_Select1.FormattingEnabled = true;
            this.comboBox_Select1.Location = new System.Drawing.Point(10, 69);
            this.comboBox_Select1.Margin = new System.Windows.Forms.Padding(1);
            this.comboBox_Select1.Name = "comboBox_Select1";
            this.comboBox_Select1.Size = new System.Drawing.Size(137, 32);
            this.comboBox_Select1.TabIndex = 1043;
            this.comboBox_Select1.ValueMember = "ValueString";
            this.comboBox_Select1.SelectedIndexChanged += new System.EventHandler(this.comboBox_Select1_SelectedIndexChanged);
            // 
            // logSearchValueBindingSource1
            // 
            this.logSearchValueBindingSource1.DataMember = "LogSearchValue";
            this.logSearchValueBindingSource1.DataSource = this.dataSet_DelDataLog;
            // 
            // dataSet_DelDataLog
            // 
            this.dataSet_DelDataLog.DataSetName = "DataSet_DelDataLog";
            this.dataSet_DelDataLog.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
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
            // comboBox_SelectValue
            // 
            this.comboBox_SelectValue.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.comboBox_SelectValue.FormattingEnabled = true;
            this.comboBox_SelectValue.Location = new System.Drawing.Point(150, 35);
            this.comboBox_SelectValue.Margin = new System.Windows.Forms.Padding(1);
            this.comboBox_SelectValue.Name = "comboBox_SelectValue";
            this.comboBox_SelectValue.Size = new System.Drawing.Size(251, 32);
            this.comboBox_SelectValue.TabIndex = 1041;
            // 
            // comboBox_Select
            // 
            this.comboBox_Select.DataSource = this.logSearchValueBindingSource;
            this.comboBox_Select.DisplayMember = "ShowString";
            this.comboBox_Select.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Select.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.comboBox_Select.FormattingEnabled = true;
            this.comboBox_Select.Location = new System.Drawing.Point(10, 36);
            this.comboBox_Select.Margin = new System.Windows.Forms.Padding(1);
            this.comboBox_Select.Name = "comboBox_Select";
            this.comboBox_Select.Size = new System.Drawing.Size(137, 32);
            this.comboBox_Select.TabIndex = 1040;
            this.comboBox_Select.ValueMember = "ValueString";
            this.comboBox_Select.SelectedIndexChanged += new System.EventHandler(this.comboBox_Select_SelectedIndexChanged);
            // 
            // logSearchValueBindingSource
            // 
            this.logSearchValueBindingSource.DataMember = "LogSearchValue";
            this.logSearchValueBindingSource.DataSource = this.dataSet_DelDataLog;
            // 
            // but_Search
            // 
            this.but_Search.BackgroundImage = global::LawtechPTSystemByFirm.Properties.Resources.btnSearch;
            this.but_Search.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.but_Search.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.but_Search.Image = global::LawtechPTSystemByFirm.Properties.Resources.SearchIcon;
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.label2.Location = new System.Drawing.Point(264, 10);
            this.label2.Margin = new System.Windows.Forms.Padding(1);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 20);
            this.label2.TabIndex = 1038;
            this.label2.Text = "~";
            // 
            // maskedTextBox_D
            // 
            this.maskedTextBox_D.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.maskedTextBox_D.ForeColor = System.Drawing.Color.Green;
            this.maskedTextBox_D.Location = new System.Drawing.Point(287, 3);
            this.maskedTextBox_D.Margin = new System.Windows.Forms.Padding(1);
            this.maskedTextBox_D.Mask = "0000/00/00";
            this.maskedTextBox_D.Name = "maskedTextBox_D";
            this.maskedTextBox_D.Size = new System.Drawing.Size(114, 29);
            this.maskedTextBox_D.TabIndex = 1037;
            this.maskedTextBox_D.ValidatingType = typeof(System.DateTime);
            this.maskedTextBox_D.DoubleClick += new System.EventHandler(this.maskedTextBox_S_DoubleClick);
            // 
            // maskedTextBox_S
            // 
            this.maskedTextBox_S.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.maskedTextBox_S.ForeColor = System.Drawing.Color.Green;
            this.maskedTextBox_S.Location = new System.Drawing.Point(150, 3);
            this.maskedTextBox_S.Margin = new System.Windows.Forms.Padding(1);
            this.maskedTextBox_S.Mask = "0000/00/00";
            this.maskedTextBox_S.Name = "maskedTextBox_S";
            this.maskedTextBox_S.Size = new System.Drawing.Size(112, 29);
            this.maskedTextBox_S.TabIndex = 1036;
            this.maskedTextBox_S.ValidatingType = typeof(System.DateTime);
            this.maskedTextBox_S.DoubleClick += new System.EventHandler(this.maskedTextBox_S_DoubleClick);
            // 
            // comboBox_DateMode
            // 
            this.comboBox_DateMode.DataSource = this.logSearchDataBindingSource;
            this.comboBox_DateMode.DisplayMember = "ShowString";
            this.comboBox_DateMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_DateMode.Font = new System.Drawing.Font("微軟正黑體", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.comboBox_DateMode.FormattingEnabled = true;
            this.comboBox_DateMode.Location = new System.Drawing.Point(10, 3);
            this.comboBox_DateMode.Margin = new System.Windows.Forms.Padding(1);
            this.comboBox_DateMode.Name = "comboBox_DateMode";
            this.comboBox_DateMode.Size = new System.Drawing.Size(137, 32);
            this.comboBox_DateMode.TabIndex = 1035;
            this.comboBox_DateMode.ValueMember = "ValueString";
            // 
            // logSearchDataBindingSource
            // 
            this.logSearchDataBindingSource.DataMember = "LogSearchData";
            this.logSearchDataBindingSource.DataSource = this.dataSet_DelDataLog;
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
            this.bindingNavigatorSeparator2});
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
            // 
            // systemLogTBindingSource
            // 
            this.systemLogTBindingSource.DataMember = "SystemLogT";
            this.systemLogTBindingSource.DataSource = this.dataSet_DelDataLog;
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
            // systemLogTDataGridView
            // 
            this.systemLogTDataGridView.AllowUserToAddRows = false;
            this.systemLogTDataGridView.AllowUserToDeleteRows = false;
            this.systemLogTDataGridView.AllowUserToOrderColumns = true;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.systemLogTDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle9;
            this.systemLogTDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.systemLogTDataGridView.AutoGenerateColumns = false;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.systemLogTDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.systemLogTDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.systemLogTDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SysLogID,
            this.DelWorkerKey,
            this.DelTime,
            this.DelTitle,
            this.DelContent,
            this.But_Record});
            this.systemLogTDataGridView.DataSource = this.systemLogTBindingSource;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.systemLogTDataGridView.DefaultCellStyle = dataGridViewCellStyle12;
            this.systemLogTDataGridView.Location = new System.Drawing.Point(7, 131);
            this.systemLogTDataGridView.Name = "systemLogTDataGridView";
            this.systemLogTDataGridView.ReadOnly = true;
            this.systemLogTDataGridView.RowHeadersWidth = 25;
            this.systemLogTDataGridView.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.systemLogTDataGridView.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.systemLogTDataGridView.RowTemplate.Height = 24;
            this.systemLogTDataGridView.Size = new System.Drawing.Size(901, 455);
            this.systemLogTDataGridView.TabIndex = 1049;
            this.systemLogTDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.systemLogTDataGridView_CellClick);
            this.systemLogTDataGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.systemLogTDataGridView_DataError);
            // 
            // SysLogID
            // 
            this.SysLogID.DataPropertyName = "SysLogID";
            this.SysLogID.HeaderText = "SysLogID";
            this.SysLogID.Name = "SysLogID";
            this.SysLogID.ReadOnly = true;
            this.SysLogID.Visible = false;
            // 
            // DelWorkerKey
            // 
            this.DelWorkerKey.DataPropertyName = "DelWorkerKey";
            this.DelWorkerKey.HeaderText = "DelWorkerKey";
            this.DelWorkerKey.Name = "DelWorkerKey";
            this.DelWorkerKey.ReadOnly = true;
            this.DelWorkerKey.Visible = false;
            // 
            // DelTime
            // 
            this.DelTime.DataPropertyName = "DelTime";
            dataGridViewCellStyle11.Format = "yyyy/MM/dd HH:mm";
            this.DelTime.DefaultCellStyle = dataGridViewCellStyle11;
            this.DelTime.HeaderText = "刪除記錄時間";
            this.DelTime.Name = "DelTime";
            this.DelTime.ReadOnly = true;
            this.DelTime.Width = 110;
            // 
            // DelTitle
            // 
            this.DelTitle.DataPropertyName = "DelTitle";
            this.DelTitle.HeaderText = "記錄";
            this.DelTitle.Name = "DelTitle";
            this.DelTitle.ReadOnly = true;
            this.DelTitle.Width = 200;
            // 
            // DelContent
            // 
            this.DelContent.DataPropertyName = "DelContent";
            this.DelContent.HeaderText = "內容";
            this.DelContent.Name = "DelContent";
            this.DelContent.ReadOnly = true;
            this.DelContent.Width = 350;
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
            // systemLogTTableAdapter
            // 
            this.systemLogTTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.Connection = null;
            this.tableAdapterManager.UpdateOrder = LawtechPTSystemByFirm.DataSet_DelDataLogTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // logSearchValueTableAdapter
            // 
            this.logSearchValueTableAdapter.ClearBeforeFill = true;
            // 
            // logSearchDataTableAdapter
            // 
            this.logSearchDataTableAdapter.ClearBeforeFill = true;
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
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackgroundImage = global::LawtechPTSystemByFirm.Properties.Resources.btnCancel;
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
            // DelDataLogMF
            // 
            this.AcceptButton = this.but_Search;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(236)))), ((int)(((byte)(247)))));
            this.ClientSize = new System.Drawing.Size(914, 614);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.systemLogTDataGridView);
            this.Controls.Add(this.systemLogTBindingNavigator);
            this.Controls.Add(this.rb_or);
            this.Controls.Add(this.rb_and);
            this.Controls.Add(this.comboBox_SelectValue1);
            this.Controls.Add(this.comboBox_Select1);
            this.Controls.Add(this.but_Excel);
            this.Controls.Add(this.comboBox_SelectValue);
            this.Controls.Add(this.comboBox_Select);
            this.Controls.Add(this.but_Search);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.maskedTextBox_D);
            this.Controls.Add(this.maskedTextBox_S);
            this.Controls.Add(this.comboBox_DateMode);
            this.Controls.Add(this.tagTitle1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DelDataLogMF";
            this.Text = "刪除記錄檔";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DelDataLogMF_FormClosed);
            this.Load += new System.EventHandler(this.DelDataLogMF_Load);
            ((System.ComponentModel.ISupportInitialize)(this.logSearchValueBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_DelDataLog)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.logSearchValueBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.logSearchDataBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.systemLogTBindingNavigator)).EndInit();
            this.systemLogTBindingNavigator.ResumeLayout(false);
            this.systemLogTBindingNavigator.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.systemLogTBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.systemLogTDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rb_or;
        private System.Windows.Forms.RadioButton rb_and;
        private System.Windows.Forms.ComboBox comboBox_SelectValue1;
        private System.Windows.Forms.ComboBox comboBox_Select1;
        private System.Windows.Forms.Button but_Excel;
        private System.Windows.Forms.ComboBox comboBox_SelectValue;
        private System.Windows.Forms.ComboBox comboBox_Select;
        private System.Windows.Forms.Button but_Search;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_D;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_S;
        private System.Windows.Forms.ComboBox comboBox_DateMode;
        private DataSet_DelDataLog dataSet_DelDataLog;
        private LawtechPTSystemByFirm.DataSet_DelDataLogTableAdapters.SystemLogTTableAdapter systemLogTTableAdapter;
        private LawtechPTSystemByFirm.DataSet_DelDataLogTableAdapters.TableAdapterManager tableAdapterManager;
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
        private System.Windows.Forms.BindingSource logSearchValueBindingSource;
        private LawtechPTSystemByFirm.DataSet_DelDataLogTableAdapters.LogSearchValueTableAdapter logSearchValueTableAdapter;
        private System.Windows.Forms.BindingSource logSearchValueBindingSource1;
        private System.Windows.Forms.BindingSource systemLogTBindingSource;
        private System.Windows.Forms.BindingSource logSearchDataBindingSource;
        private LawtechPTSystemByFirm.DataSet_DelDataLogTableAdapters.LogSearchDataTableAdapter logSearchDataTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn DelWorkerKeyName;
        private US.TagTitle tagTitle1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn SysLogID;
        private System.Windows.Forms.DataGridViewTextBoxColumn DelWorkerKey;
        private System.Windows.Forms.DataGridViewTextBoxColumn DelTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn DelTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn DelContent;
        private System.Windows.Forms.DataGridViewLinkColumn But_Record;
    }
}