namespace LawtechPTSystem.US
{
    partial class SendMailSample
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
            this.butCancel = new System.Windows.Forms.Button();
            this.butOK = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.editorHTML1 = new LawtechPTSystem.US.EditorHTML();
            this.textBox_Body = new System.Windows.Forms.TextBox();
            this.comboBox_MailFormat = new System.Windows.Forms.ComboBox();
            this.mailFormatBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet_Email = new LawtechPTSystem.DataSet_Email();
            this.label9 = new System.Windows.Forms.Label();
            this.txt_Subject = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox_Priority = new System.Windows.Forms.ComboBox();
            this.mailPriorityBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label5 = new System.Windows.Forms.Label();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_SampleDescription = new System.Windows.Forms.TextBox();
            this.numericUpDown_sort = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox_MailType = new System.Windows.Forms.ComboBox();
            this.emailSampleTypeTBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.txt_SampleName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dataGridView_SelectColumn = new System.Windows.Forms.DataGridView();
            this.LabelName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cCIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.labelNameCombainTBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet_TableColumn = new LawtechPTSystem.DataSet_TableColumn();
            this.labelNameCombainTTableAdapter = new LawtechPTSystem.DataSet_TableColumnTableAdapters.LabelNameCombainTTableAdapter();
            this.mailPriorityTableAdapter = new LawtechPTSystem.DataSet_EmailTableAdapters.MailPriorityTableAdapter();
            this.emailSampleTypeTTableAdapter = new LawtechPTSystem.DataSet_EmailTableAdapters.EmailSampleTypeTTableAdapter();
            this.mailFormatTableAdapter = new LawtechPTSystem.DataSet_EmailTableAdapters.MailFormatTableAdapter();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mailFormatBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_Email)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mailPriorityBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_sort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emailSampleTypeTBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_SelectColumn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.labelNameCombainTBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_TableColumn)).BeginInit();
            this.SuspendLayout();
            // 
            // butCancel
            // 
            this.butCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.butCancel.BackgroundImage = global::LawtechPTSystem.Properties.Resources.btnCancel;
            this.butCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.butCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.butCancel.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.butCancel.Location = new System.Drawing.Point(435, 459);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(93, 34);
            this.butCancel.TabIndex = 39;
            this.butCancel.Text = "取  消";
            this.butCancel.UseVisualStyleBackColor = true;
            this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
            // 
            // butOK
            // 
            this.butOK.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.butOK.BackgroundImage = global::LawtechPTSystem.Properties.Resources.btnComfirm;
            this.butOK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.butOK.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.butOK.Location = new System.Drawing.Point(340, 459);
            this.butOK.Name = "butOK";
            this.butOK.Size = new System.Drawing.Size(93, 34);
            this.butOK.TabIndex = 38;
            this.butOK.Text = "確定儲存";
            this.butOK.UseVisualStyleBackColor = true;
            this.butOK.Click += new System.EventHandler(this.butOK_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.editorHTML1);
            this.groupBox1.Controls.Add(this.textBox_Body);
            this.groupBox1.Controls.Add(this.comboBox_MailFormat);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txt_Subject);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.comboBox_Priority);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox1.Location = new System.Drawing.Point(7, 168);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(560, 269);
            this.groupBox1.TabIndex = 40;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "E Mail 範本";
            // 
            // editorHTML1
            // 
            this.editorHTML1.AllowDrop = true;
            this.editorHTML1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.editorHTML1.BodyHtml = null;
            this.editorHTML1.BodyText = null;
            this.editorHTML1.EditorBackColor = System.Drawing.Color.White;
            this.editorHTML1.EditorForeColor = System.Drawing.Color.Black;
            this.editorHTML1.FontName = null;
            this.editorHTML1.FontSize = LawtechPTSystem.US.FontSize.NA;
            this.editorHTML1.Location = new System.Drawing.Point(98, 89);
            this.editorHTML1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.editorHTML1.Name = "editorHTML1";
            this.editorHTML1.Size = new System.Drawing.Size(453, 173);
            this.editorHTML1.TabIndex = 51;
            // 
            // textBox_Body
            // 
            this.textBox_Body.AllowDrop = true;
            this.textBox_Body.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_Body.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.textBox_Body.Location = new System.Drawing.Point(98, 89);
            this.textBox_Body.Multiline = true;
            this.textBox_Body.Name = "textBox_Body";
            this.textBox_Body.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox_Body.Size = new System.Drawing.Size(453, 174);
            this.textBox_Body.TabIndex = 50;
            this.textBox_Body.DragDrop += new System.Windows.Forms.DragEventHandler(this.txt_Subject_DragDrop);
            this.textBox_Body.DragOver += new System.Windows.Forms.DragEventHandler(this.txt_Subject_DragOver);
            this.textBox_Body.MouseUp += new System.Windows.Forms.MouseEventHandler(this.txt_Subject_MouseUp);
            // 
            // comboBox_MailFormat
            // 
            this.comboBox_MailFormat.DataSource = this.mailFormatBindingSource;
            this.comboBox_MailFormat.DisplayMember = "String";
            this.comboBox_MailFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_MailFormat.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.comboBox_MailFormat.FormattingEnabled = true;
            this.comboBox_MailFormat.Location = new System.Drawing.Point(339, 55);
            this.comboBox_MailFormat.Name = "comboBox_MailFormat";
            this.comboBox_MailFormat.Size = new System.Drawing.Size(147, 28);
            this.comboBox_MailFormat.TabIndex = 49;
            this.comboBox_MailFormat.ValueMember = "Value";
            this.comboBox_MailFormat.SelectedIndexChanged += new System.EventHandler(this.comboBox_MailFormat_SelectedIndexChanged);
            // 
            // mailFormatBindingSource
            // 
            this.mailFormatBindingSource.DataMember = "MailFormat";
            this.mailFormatBindingSource.DataSource = this.dataSet_Email;
            // 
            // dataSet_Email
            // 
            this.dataSet_Email.DataSetName = "DataSet_Email";
            this.dataSet_Email.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label9.Location = new System.Drawing.Point(260, 59);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(73, 20);
            this.label9.TabIndex = 48;
            this.label9.Text = "郵件格式";
            // 
            // txt_Subject
            // 
            this.txt_Subject.AllowDrop = true;
            this.txt_Subject.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_Subject.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.txt_Subject.Location = new System.Drawing.Point(98, 22);
            this.txt_Subject.Name = "txt_Subject";
            this.txt_Subject.Size = new System.Drawing.Size(453, 29);
            this.txt_Subject.TabIndex = 42;
            this.txt_Subject.DragDrop += new System.Windows.Forms.DragEventHandler(this.txt_Subject_DragDrop);
            this.txt_Subject.DragOver += new System.Windows.Forms.DragEventHandler(this.txt_Subject_DragOver);
            this.txt_Subject.MouseUp += new System.Windows.Forms.MouseEventHandler(this.txt_Subject_MouseUp);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.Location = new System.Drawing.Point(22, 135);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 20);
            this.label4.TabIndex = 43;
            this.label4.Text = "郵件內文";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(22, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 20);
            this.label3.TabIndex = 41;
            this.label3.Text = "郵件主旨";
            // 
            // comboBox_Priority
            // 
            this.comboBox_Priority.DataSource = this.mailPriorityBindingSource;
            this.comboBox_Priority.DisplayMember = "String";
            this.comboBox_Priority.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Priority.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.comboBox_Priority.FormattingEnabled = true;
            this.comboBox_Priority.Location = new System.Drawing.Point(98, 55);
            this.comboBox_Priority.Name = "comboBox_Priority";
            this.comboBox_Priority.Size = new System.Drawing.Size(115, 28);
            this.comboBox_Priority.TabIndex = 46;
            this.comboBox_Priority.ValueMember = "value";
            // 
            // mailPriorityBindingSource
            // 
            this.mailPriorityBindingSource.DataMember = "MailPriority";
            this.mailPriorityBindingSource.DataSource = this.dataSet_Email;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label5.Location = new System.Drawing.Point(6, 59);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 20);
            this.label5.TabIndex = 45;
            this.label5.Text = "郵件重要性";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.BackColor = System.Drawing.Color.Transparent;
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(9, 7);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.label8);
            this.splitContainer1.Panel1.Controls.Add(this.txt_SampleDescription);
            this.splitContainer1.Panel1.Controls.Add(this.numericUpDown_sort);
            this.splitContainer1.Panel1.Controls.Add(this.label6);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.comboBox_MailType);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.txt_SampleName);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.label7);
            this.splitContainer1.Panel2.Controls.Add(this.dataGridView_SelectColumn);
            this.splitContainer1.Size = new System.Drawing.Size(848, 446);
            this.splitContainer1.SplitterDistance = 578;
            this.splitContainer1.TabIndex = 41;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label8.Location = new System.Drawing.Point(30, 113);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 20);
            this.label8.TabIndex = 53;
            this.label8.Text = "說明描述";
            // 
            // txt_SampleDescription
            // 
            this.txt_SampleDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_SampleDescription.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.txt_SampleDescription.Location = new System.Drawing.Point(105, 109);
            this.txt_SampleDescription.Multiline = true;
            this.txt_SampleDescription.Name = "txt_SampleDescription";
            this.txt_SampleDescription.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_SampleDescription.Size = new System.Drawing.Size(453, 53);
            this.txt_SampleDescription.TabIndex = 54;
            // 
            // numericUpDown_sort
            // 
            this.numericUpDown_sort.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.numericUpDown_sort.Location = new System.Drawing.Point(105, 43);
            this.numericUpDown_sort.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDown_sort.Name = "numericUpDown_sort";
            this.numericUpDown_sort.Size = new System.Drawing.Size(120, 29);
            this.numericUpDown_sort.TabIndex = 52;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label6.Location = new System.Drawing.Point(54, 46);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 20);
            this.label6.TabIndex = 51;
            this.label6.Text = "排  序";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(30, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 20);
            this.label2.TabIndex = 48;
            this.label2.Text = "範本類型";
            // 
            // comboBox_MailType
            // 
            this.comboBox_MailType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_MailType.DataSource = this.emailSampleTypeTBindingSource;
            this.comboBox_MailType.DisplayMember = "TypeName";
            this.comboBox_MailType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_MailType.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.comboBox_MailType.FormattingEnabled = true;
            this.comboBox_MailType.Location = new System.Drawing.Point(105, 9);
            this.comboBox_MailType.Name = "comboBox_MailType";
            this.comboBox_MailType.Size = new System.Drawing.Size(453, 28);
            this.comboBox_MailType.TabIndex = 47;
            this.comboBox_MailType.ValueMember = "EmailSampleType";
            this.comboBox_MailType.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // emailSampleTypeTBindingSource
            // 
            this.emailSampleTypeTBindingSource.DataMember = "EmailSampleTypeT";
            this.emailSampleTypeTBindingSource.DataSource = this.dataSet_Email;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(30, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 20);
            this.label1.TabIndex = 49;
            this.label1.Text = "範本名稱";
            // 
            // txt_SampleName
            // 
            this.txt_SampleName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_SampleName.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.txt_SampleName.Location = new System.Drawing.Point(105, 76);
            this.txt_SampleName.Name = "txt_SampleName";
            this.txt_SampleName.Size = new System.Drawing.Size(453, 29);
            this.txt_SampleName.TabIndex = 50;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label7.ForeColor = System.Drawing.Color.DarkBlue;
            this.label7.Location = new System.Drawing.Point(3, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(138, 17);
            this.label7.TabIndex = 2;
            this.label7.Text = "請選擇下方的資料欄位";
            // 
            // dataGridView_SelectColumn
            // 
            this.dataGridView_SelectColumn.AllowDrop = true;
            this.dataGridView_SelectColumn.AllowUserToAddRows = false;
            this.dataGridView_SelectColumn.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.MediumSlateBlue;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            this.dataGridView_SelectColumn.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView_SelectColumn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView_SelectColumn.AutoGenerateColumns = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_SelectColumn.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView_SelectColumn.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_SelectColumn.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.LabelName,
            this.cCIDDataGridViewTextBoxColumn});
            this.dataGridView_SelectColumn.DataSource = this.labelNameCombainTBindingSource;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.MediumSlateBlue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView_SelectColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView_SelectColumn.Location = new System.Drawing.Point(3, 43);
            this.dataGridView_SelectColumn.Margin = new System.Windows.Forms.Padding(1);
            this.dataGridView_SelectColumn.MultiSelect = false;
            this.dataGridView_SelectColumn.Name = "dataGridView_SelectColumn";
            this.dataGridView_SelectColumn.ReadOnly = true;
            this.dataGridView_SelectColumn.RowHeadersWidth = 30;
            this.dataGridView_SelectColumn.RowTemplate.Height = 24;
            this.dataGridView_SelectColumn.Size = new System.Drawing.Size(258, 388);
            this.dataGridView_SelectColumn.TabIndex = 1;
            this.dataGridView_SelectColumn.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridView_SelectColumn_CellMouseDown);
            this.dataGridView_SelectColumn.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dataGridView_SelectColumn_DataError);
            // 
            // LabelName
            // 
            this.LabelName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.LabelName.DataPropertyName = "LabelName";
            this.LabelName.HeaderText = "資料名稱";
            this.LabelName.Name = "LabelName";
            this.LabelName.ReadOnly = true;
            // 
            // cCIDDataGridViewTextBoxColumn
            // 
            this.cCIDDataGridViewTextBoxColumn.DataPropertyName = "CCID";
            this.cCIDDataGridViewTextBoxColumn.HeaderText = "CCID";
            this.cCIDDataGridViewTextBoxColumn.Name = "cCIDDataGridViewTextBoxColumn";
            this.cCIDDataGridViewTextBoxColumn.ReadOnly = true;
            this.cCIDDataGridViewTextBoxColumn.Visible = false;
            // 
            // labelNameCombainTBindingSource
            // 
            this.labelNameCombainTBindingSource.DataMember = "LabelNameCombainT";
            this.labelNameCombainTBindingSource.DataSource = this.dataSet_TableColumn;
            // 
            // dataSet_TableColumn
            // 
            this.dataSet_TableColumn.DataSetName = "DataSet_TableColumn";
            this.dataSet_TableColumn.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // labelNameCombainTTableAdapter
            // 
            this.labelNameCombainTTableAdapter.ClearBeforeFill = true;
            // 
            // mailPriorityTableAdapter
            // 
            this.mailPriorityTableAdapter.ClearBeforeFill = true;
            // 
            // emailSampleTypeTTableAdapter
            // 
            this.emailSampleTypeTTableAdapter.ClearBeforeFill = true;
            // 
            // mailFormatTableAdapter
            // 
            this.mailFormatTableAdapter.ClearBeforeFill = true;
            // 
            // SendMailSample
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = global::LawtechPTSystem.Properties.Resources.candyhole;
            this.CancelButton = this.butCancel;
            this.ClientSize = new System.Drawing.Size(866, 505);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.butOK);
            this.Name = "SendMailSample";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "郵件範本";
            this.Load += new System.EventHandler(this.SendMailSample_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mailFormatBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_Email)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mailPriorityBindingSource)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_sort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emailSampleTypeTBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_SelectColumn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.labelNameCombainTBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_TableColumn)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button butCancel;
        private System.Windows.Forms.Button butOK;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox txt_Subject;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox_Priority;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox_MailType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_SampleName;
        private System.Windows.Forms.BindingSource labelNameCombainTBindingSource;
        private DataSet_TableColumn dataSet_TableColumn;
        private LawtechPTSystem.DataSet_TableColumnTableAdapters.LabelNameCombainTTableAdapter labelNameCombainTTableAdapter;
        private DataSet_Email dataSet_Email;
        private System.Windows.Forms.BindingSource mailPriorityBindingSource;
        private LawtechPTSystem.DataSet_EmailTableAdapters.MailPriorityTableAdapter mailPriorityTableAdapter;
        private System.Windows.Forms.NumericUpDown numericUpDown_sort;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dataGridView_SelectColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn LabelName;
        private System.Windows.Forms.DataGridViewTextBoxColumn cCIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_SampleDescription;
        private System.Windows.Forms.ComboBox comboBox_MailFormat;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox_Body;
        private EditorHTML editorHTML1;
        private System.Windows.Forms.BindingSource emailSampleTypeTBindingSource;
        private LawtechPTSystem.DataSet_EmailTableAdapters.EmailSampleTypeTTableAdapter emailSampleTypeTTableAdapter;
        private System.Windows.Forms.BindingSource mailFormatBindingSource;
        private LawtechPTSystem.DataSet_EmailTableAdapters.MailFormatTableAdapter mailFormatTableAdapter;
    }
}