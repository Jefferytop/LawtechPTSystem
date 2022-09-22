namespace LawtechPTSystemByFirm.US
{
    partial class SelectApplicant
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectApplicant));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.butCancel = new System.Windows.Forms.Button();
            this.butOK = new System.Windows.Forms.Button();
            this.applicantT_DropDataGridView = new System.Windows.Forms.DataGridView();
            this.ApplicantKey = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ApplicantSymbol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ApplicantName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.applicantTDropBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.qS_DataSet = new LawtechPTSystemByFirm.QS_DataSet();
            this.comboBox_SelectMode = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
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
            this.label2 = new System.Windows.Forms.Label();
            this.tagTitle1 = new LawtechPTSystemByFirm.US.TagTitle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ApplicantKey_Select = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ApplicantName_Select = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.tagTitle2 = new LawtechPTSystemByFirm.US.TagTitle();
            this.txt_SearchName = new System.Windows.Forms.TextBox();
            this.but_Search = new System.Windows.Forms.Button();
            this.applicantT_DropTableAdapter = new LawtechPTSystemByFirm.QS_DataSetTableAdapters.ApplicantT_DropTableAdapter();
            this.comboBox_app = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.applicantT_DropDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.applicantTDropBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qS_DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // butCancel
            // 
            this.butCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.butCancel.BackgroundImage = global::LawtechPTSystemByFirm.Properties.Resources.btnCancel;
            this.butCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.butCancel.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.butCancel.Location = new System.Drawing.Point(282, 652);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(100, 32);
            this.butCancel.TabIndex = 70;
            this.butCancel.Text = "取消";
            this.butCancel.UseVisualStyleBackColor = true;
            this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
            // 
            // butOK
            // 
            this.butOK.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.butOK.BackgroundImage = global::LawtechPTSystemByFirm.Properties.Resources.btnComfirm;
            this.butOK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.butOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.butOK.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.butOK.Location = new System.Drawing.Point(176, 652);
            this.butOK.Name = "butOK";
            this.butOK.Size = new System.Drawing.Size(100, 32);
            this.butOK.TabIndex = 60;
            this.butOK.Text = "確定";
            this.butOK.UseVisualStyleBackColor = true;
            this.butOK.Click += new System.EventHandler(this.butOK_Click);
            // 
            // applicantT_DropDataGridView
            // 
            this.applicantT_DropDataGridView.AllowUserToAddRows = false;
            this.applicantT_DropDataGridView.AllowUserToDeleteRows = false;
            this.applicantT_DropDataGridView.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.applicantT_DropDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.applicantT_DropDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.applicantT_DropDataGridView.AutoGenerateColumns = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.applicantT_DropDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.applicantT_DropDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.applicantT_DropDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ApplicantKey,
            this.ApplicantSymbol,
            this.ApplicantName});
            this.applicantT_DropDataGridView.DataSource = this.applicantTDropBindingSource;
            this.applicantT_DropDataGridView.Location = new System.Drawing.Point(3, 50);
            this.applicantT_DropDataGridView.Name = "applicantT_DropDataGridView";
            this.applicantT_DropDataGridView.ReadOnly = true;
            this.applicantT_DropDataGridView.RowHeadersWidth = 30;
            this.applicantT_DropDataGridView.RowTemplate.Height = 24;
            this.applicantT_DropDataGridView.Size = new System.Drawing.Size(547, 298);
            this.applicantT_DropDataGridView.TabIndex = 30;
            this.applicantT_DropDataGridView.Tag = "SelectApplicant";
            this.applicantT_DropDataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.applicantT_DropDataGridView_CellDoubleClick);
            // 
            // ApplicantKey
            // 
            this.ApplicantKey.DataPropertyName = "ApplicantKey";
            this.ApplicantKey.HeaderText = "ApplicantKey";
            this.ApplicantKey.Name = "ApplicantKey";
            this.ApplicantKey.ReadOnly = true;
            this.ApplicantKey.Visible = false;
            // 
            // ApplicantSymbol
            // 
            this.ApplicantSymbol.DataPropertyName = "ApplicantSymbol";
            this.ApplicantSymbol.HeaderText = "客戶編號";
            this.ApplicantSymbol.Name = "ApplicantSymbol";
            this.ApplicantSymbol.ReadOnly = true;
            this.ApplicantSymbol.Width = 83;
            // 
            // ApplicantName
            // 
            this.ApplicantName.DataPropertyName = "ApplicantName";
            this.ApplicantName.HeaderText = "公司名稱";
            this.ApplicantName.Name = "ApplicantName";
            this.ApplicantName.ReadOnly = true;
            this.ApplicantName.Width = 300;
            // 
            // applicantTDropBindingSource
            // 
            this.applicantTDropBindingSource.DataMember = "ApplicantT_Drop";
            this.applicantTDropBindingSource.DataSource = this.qS_DataSet;
            // 
            // qS_DataSet
            // 
            this.qS_DataSet.DataSetName = "QS_DataSet";
            this.qS_DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // comboBox_SelectMode
            // 
            this.comboBox_SelectMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_SelectMode.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.comboBox_SelectMode.FormattingEnabled = true;
            this.comboBox_SelectMode.Items.AddRange(new object[] {
            "全部",
            "專利客戶",
            "商標客戶",
            "法務客戶"});
            this.comboBox_SelectMode.Location = new System.Drawing.Point(87, 9);
            this.comboBox_SelectMode.Name = "comboBox_SelectMode";
            this.comboBox_SelectMode.Size = new System.Drawing.Size(117, 25);
            this.comboBox_SelectMode.TabIndex = 10;
            this.comboBox_SelectMode.SelectedIndexChanged += new System.EventHandler(this.comboBox_SelectMode_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.ForeColor = System.Drawing.Color.SlateBlue;
            this.label3.Location = new System.Drawing.Point(1, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 19);
            this.label3.TabIndex = 26;
            this.label3.Text = "申請人種類";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(2, 42);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.bindingNavigator1);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.applicantT_DropDataGridView);
            this.splitContainer1.Panel1.Controls.Add(this.tagTitle1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataGridView1);
            this.splitContainer1.Panel2.Controls.Add(this.label4);
            this.splitContainer1.Panel2.Controls.Add(this.tagTitle2);
            this.splitContainer1.Size = new System.Drawing.Size(555, 604);
            this.splitContainer1.SplitterDistance = 379;
            this.splitContainer1.TabIndex = 30;
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = null;
            this.bindingNavigator1.BindingSource = this.applicantTDropBindingSource;
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
            this.bindingNavigatorSeparator2});
            this.bindingNavigator1.Location = new System.Drawing.Point(0, 352);
            this.bindingNavigator1.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.bindingNavigator1.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.bindingNavigator1.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.bindingNavigator1.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = this.bindingNavigatorPositionItem;
            this.bindingNavigator1.Size = new System.Drawing.Size(553, 25);
            this.bindingNavigator1.TabIndex = 45;
            this.bindingNavigator1.TabStop = true;
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.ForeColor = System.Drawing.Color.DarkOrchid;
            this.label2.Location = new System.Drawing.Point(3, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(177, 17);
            this.label2.TabIndex = 44;
            this.label2.Text = "使用說明：點選兩下即可選取";
            // 
            // tagTitle1
            // 
            this.tagTitle1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tagTitle1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tagTitle1.BackgroundImage")));
            this.tagTitle1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tagTitle1.Location = new System.Drawing.Point(3, 23);
            this.tagTitle1.Margin = new System.Windows.Forms.Padding(1);
            this.tagTitle1.Name = "tagTitle1";
            this.tagTitle1.Size = new System.Drawing.Size(547, 32);
            this.tagTitle1.TabIndex = 46;
            this.tagTitle1.TagTitleStyle = "Style1";
            this.tagTitle1.TitleLableText = "公司列表";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.dataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ApplicantKey_Select,
            this.ApplicantName_Select});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView1.Location = new System.Drawing.Point(4, 30);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 30;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(546, 164);
            this.dataGridView1.TabIndex = 50;
            this.dataGridView1.Tag = "SelectApplicant_Check";
            this.dataGridView1.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // ApplicantKey_Select
            // 
            this.ApplicantKey_Select.DataPropertyName = "ApplicantKey";
            this.ApplicantKey_Select.HeaderText = "ApplicantKey";
            this.ApplicantKey_Select.Name = "ApplicantKey_Select";
            this.ApplicantKey_Select.ReadOnly = true;
            this.ApplicantKey_Select.Visible = false;
            // 
            // ApplicantName_Select
            // 
            this.ApplicantName_Select.DataPropertyName = "ApplicantName";
            this.ApplicantName_Select.HeaderText = "公司名稱";
            this.ApplicantName_Select.Name = "ApplicantName_Select";
            this.ApplicantName_Select.ReadOnly = true;
            this.ApplicantName_Select.Width = 400;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.ForeColor = System.Drawing.Color.DarkOrchid;
            this.label4.Location = new System.Drawing.Point(3, 197);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(177, 17);
            this.label4.TabIndex = 45;
            this.label4.Text = "使用說明：點選兩下即可移除";
            // 
            // tagTitle2
            // 
            this.tagTitle2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tagTitle2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("tagTitle2.BackgroundImage")));
            this.tagTitle2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.tagTitle2.Location = new System.Drawing.Point(4, 1);
            this.tagTitle2.Margin = new System.Windows.Forms.Padding(1);
            this.tagTitle2.Name = "tagTitle2";
            this.tagTitle2.Size = new System.Drawing.Size(546, 32);
            this.tagTitle2.TabIndex = 47;
            this.tagTitle2.TagTitleStyle = "Style3";
            this.tagTitle2.TitleLableText = "已選取的申請人列表";
            // 
            // txt_SearchName
            // 
            this.txt_SearchName.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.txt_SearchName.Location = new System.Drawing.Point(302, 9);
            this.txt_SearchName.Name = "txt_SearchName";
            this.txt_SearchName.Size = new System.Drawing.Size(138, 25);
            this.txt_SearchName.TabIndex = 20;
            this.txt_SearchName.TextChanged += new System.EventHandler(this.txt_SearchName_TextChanged);
            // 
            // but_Search
            // 
            this.but_Search.BackgroundImage = global::LawtechPTSystemByFirm.Properties.Resources.btnSearch;
            this.but_Search.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.but_Search.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.but_Search.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.but_Search.Location = new System.Drawing.Point(446, 6);
            this.but_Search.Name = "but_Search";
            this.but_Search.Size = new System.Drawing.Size(100, 32);
            this.but_Search.TabIndex = 31;
            this.but_Search.Text = "查  詢";
            this.but_Search.UseVisualStyleBackColor = true;
            this.but_Search.Visible = false;
            this.but_Search.Click += new System.EventHandler(this.but_Search_Click);
            // 
            // applicantT_DropTableAdapter
            // 
            this.applicantT_DropTableAdapter.ClearBeforeFill = true;
            // 
            // comboBox_app
            // 
            this.comboBox_app.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.comboBox_app.FormattingEnabled = true;
            this.comboBox_app.Items.AddRange(new object[] {
            "客戶編號",
            "公司名稱"});
            this.comboBox_app.Location = new System.Drawing.Point(213, 9);
            this.comboBox_app.Margin = new System.Windows.Forms.Padding(1);
            this.comboBox_app.Name = "comboBox_app";
            this.comboBox_app.Size = new System.Drawing.Size(88, 25);
            this.comboBox_app.TabIndex = 71;
            this.comboBox_app.Text = "客戶編號";
            // 
            // SelectApplicant
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = global::LawtechPTSystemByFirm.Properties.Resources.bg_01;
            this.CancelButton = this.butCancel;
            this.ClientSize = new System.Drawing.Size(558, 699);
            this.Controls.Add(this.comboBox_app);
            this.Controls.Add(this.but_Search);
            this.Controls.Add(this.txt_SearchName);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBox_SelectMode);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.butOK);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SelectApplicant";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "查詢";
            this.Load += new System.EventHandler(this.SelectApplicant_Load);
            ((System.ComponentModel.ISupportInitialize)(this.applicantT_DropDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.applicantTDropBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qS_DataSet)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button butCancel;
        private System.Windows.Forms.Button butOK;
        private System.Windows.Forms.DataGridView applicantT_DropDataGridView;
        private System.Windows.Forms.ComboBox comboBox_SelectMode;
        private System.Windows.Forms.Label label3;
        private QS_DataSet qS_DataSet;
        private System.Windows.Forms.BindingSource applicantTDropBindingSource;
        private LawtechPTSystemByFirm.QS_DataSetTableAdapters.ApplicantT_DropTableAdapter applicantT_DropTableAdapter;
        private System.Windows.Forms.SplitContainer splitContainer1;
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
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_SearchName;
        private System.Windows.Forms.Button but_Search;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ApplicantKey_Select;
        private System.Windows.Forms.DataGridViewTextBoxColumn ApplicantName_Select;
        private TagTitle tagTitle1;
        private TagTitle tagTitle2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ApplicantKey;
        private System.Windows.Forms.DataGridViewTextBoxColumn ApplicantSymbol;
        private System.Windows.Forms.DataGridViewTextBoxColumn ApplicantName;
        private System.Windows.Forms.ComboBox comboBox_app;
    }
}