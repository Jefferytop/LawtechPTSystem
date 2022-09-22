namespace LawtechPTSystemByFirm.US
{
    partial class UpFileList
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpFileList));
            this.listView1 = new System.Windows.Forms.ListView();
            this.but_Cancel = new System.Windows.Forms.Button();
            this.but_OK = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.but_SelectFile = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnOutlookFolder = new System.Windows.Forms.Button();
            this.cbOutlookFolder = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.lab_Reader = new System.Windows.Forms.Label();
            this.lab_MailCount = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.but_SearchMail = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.maskedTextBox_EndDate = new System.Windows.Forms.MaskedTextBox();
            this.dataGridView_outlook = new System.Windows.Forms.DataGridView();
            this.Selected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SenderName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Subject = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ReceivedTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maskedTextBox_Start = new System.Windows.Forms.MaskedTextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_outlook)).BeginInit();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.AllowDrop = true;
            this.listView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(6, 24);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(551, 418);
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.DragDrop += new System.Windows.Forms.DragEventHandler(this.listView1_DragDrop);
            this.listView1.DragEnter += new System.Windows.Forms.DragEventHandler(this.listView1_DragEnter);
            this.listView1.DoubleClick += new System.EventHandler(this.listView1_DoubleClick);
            // 
            // but_Cancel
            // 
            this.but_Cancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.but_Cancel.BackgroundImage = global::LawtechPTSystemByFirm.Properties.Resources.btnCancel;
            this.but_Cancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.but_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.but_Cancel.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.but_Cancel.Location = new System.Drawing.Point(294, 567);
            this.but_Cancel.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.but_Cancel.Name = "but_Cancel";
            this.but_Cancel.Size = new System.Drawing.Size(100, 30);
            this.but_Cancel.TabIndex = 388;
            this.but_Cancel.Text = "取消";
            this.but_Cancel.UseVisualStyleBackColor = true;
            this.but_Cancel.Click += new System.EventHandler(this.but_Cancel_Click);
            // 
            // but_OK
            // 
            this.but_OK.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.but_OK.BackgroundImage = global::LawtechPTSystemByFirm.Properties.Resources.btnComfirm;
            this.but_OK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.but_OK.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.but_OK.Location = new System.Drawing.Point(191, 567);
            this.but_OK.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.but_OK.Name = "but_OK";
            this.but_OK.Size = new System.Drawing.Size(100, 30);
            this.but_OK.TabIndex = 387;
            this.but_OK.Text = "確定";
            this.but_OK.UseVisualStyleBackColor = true;
            this.but_OK.Click += new System.EventHandler(this.but_OK_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(9, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(204, 18);
            this.label1.TabIndex = 389;
            this.label1.Text = "操作說明：請拖曳檔案到列表中";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 8F);
            this.label2.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label2.Location = new System.Drawing.Point(6, 451);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(231, 15);
            this.label2.TabIndex = 390;
            this.label2.Text = "1.因安全性考量，請避免直接上傳執行檔(.exe)";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微軟正黑體", 8F);
            this.label3.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label3.Location = new System.Drawing.Point(6, 472);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(289, 15);
            this.label3.TabIndex = 391;
            this.label3.Text = "2.避免上傳超大檔案，單個檔案大小請控制在100 MB 以內";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微軟正黑體", 8F);
            this.label4.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label4.Location = new System.Drawing.Point(6, 490);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(137, 15);
            this.label4.TabIndex = 392;
            this.label4.Text = "3.快點兩下，可移除該項目";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Font = new System.Drawing.Font("微軟正黑體", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.tabControl1.ItemSize = new System.Drawing.Size(84, 30);
            this.tabControl1.Location = new System.Drawing.Point(5, 7);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(573, 550);
            this.tabControl1.TabIndex = 393;
            // 
            // tabPage1
            // 
            this.tabPage1.BackgroundImage = global::LawtechPTSystemByFirm.Properties.Resources.candyhole;
            this.tabPage1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPage1.Controls.Add(this.but_SelectFile);
            this.tabPage1.Controls.Add(this.listView1);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Location = new System.Drawing.Point(4, 34);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(565, 512);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "  指定檔案上傳  ";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // but_SelectFile
            // 
            this.but_SelectFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.but_SelectFile.BackgroundImage = global::LawtechPTSystemByFirm.Properties.Resources.btnT1;
            this.but_SelectFile.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.but_SelectFile.ForeColor = System.Drawing.Color.Blue;
            this.but_SelectFile.Location = new System.Drawing.Point(457, 448);
            this.but_SelectFile.Name = "but_SelectFile";
            this.but_SelectFile.Size = new System.Drawing.Size(100, 39);
            this.but_SelectFile.TabIndex = 393;
            this.but_SelectFile.Text = "選取檔案";
            this.but_SelectFile.UseVisualStyleBackColor = true;
            this.but_SelectFile.Click += new System.EventHandler(this.but_SelectFile_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.BackgroundImage = global::LawtechPTSystemByFirm.Properties.Resources.candyhole;
            this.tabPage2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPage2.Controls.Add(this.btnOutlookFolder);
            this.tabPage2.Controls.Add(this.cbOutlookFolder);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.checkBox1);
            this.tabPage2.Controls.Add(this.lab_Reader);
            this.tabPage2.Controls.Add(this.lab_MailCount);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.but_SearchMail);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.maskedTextBox_EndDate);
            this.tabPage2.Controls.Add(this.dataGridView_outlook);
            this.tabPage2.Controls.Add(this.maskedTextBox_Start);
            this.tabPage2.Location = new System.Drawing.Point(4, 34);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(565, 512);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "  Outlook郵件上傳  ";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnOutlookFolder
            // 
            this.btnOutlookFolder.BackgroundImage = global::LawtechPTSystemByFirm.Properties.Resources.btnT1;
            this.btnOutlookFolder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnOutlookFolder.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.btnOutlookFolder.ForeColor = System.Drawing.Color.Black;
            this.btnOutlookFolder.Image = global::LawtechPTSystemByFirm.Properties.Resources.MinIcons_013;
            this.btnOutlookFolder.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOutlookFolder.Location = new System.Drawing.Point(378, 13);
            this.btnOutlookFolder.Name = "btnOutlookFolder";
            this.btnOutlookFolder.Size = new System.Drawing.Size(161, 30);
            this.btnOutlookFolder.TabIndex = 402;
            this.btnOutlookFolder.Text = "讀取資料夾";
            this.btnOutlookFolder.UseVisualStyleBackColor = true;
            this.btnOutlookFolder.Click += new System.EventHandler(this.btnOutlookFolder_Click);
            // 
            // cbOutlookFolder
            // 
            this.cbOutlookFolder.DisplayMember = "ProFolderName";
            this.cbOutlookFolder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbOutlookFolder.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.cbOutlookFolder.FormattingEnabled = true;
            this.cbOutlookFolder.Location = new System.Drawing.Point(114, 15);
            this.cbOutlookFolder.Name = "cbOutlookFolder";
            this.cbOutlookFolder.Size = new System.Drawing.Size(258, 28);
            this.cbOutlookFolder.TabIndex = 401;
            this.cbOutlookFolder.ValueMember = "EntryID";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.label10.ForeColor = System.Drawing.Color.Blue;
            this.label10.Location = new System.Drawing.Point(47, 20);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(64, 18);
            this.label10.TabIndex = 400;
            this.label10.Text = "郵件帳戶";
            // 
            // checkBox1
            // 
            this.checkBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox1.AutoSize = true;
            this.checkBox1.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.checkBox1.Location = new System.Drawing.Point(366, 485);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(193, 22);
            this.checkBox1.TabIndex = 397;
            this.checkBox1.Text = "上傳結束後，關閉Outlook";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // lab_Reader
            // 
            this.lab_Reader.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lab_Reader.AutoSize = true;
            this.lab_Reader.Font = new System.Drawing.Font("微軟正黑體", 8F);
            this.lab_Reader.Location = new System.Drawing.Point(11, 454);
            this.lab_Reader.Name = "lab_Reader";
            this.lab_Reader.Size = new System.Drawing.Size(17, 15);
            this.lab_Reader.TabIndex = 396;
            this.lab_Reader.Text = "--";
            // 
            // lab_MailCount
            // 
            this.lab_MailCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lab_MailCount.AutoSize = true;
            this.lab_MailCount.Font = new System.Drawing.Font("微軟正黑體", 8F);
            this.lab_MailCount.Location = new System.Drawing.Point(439, 454);
            this.lab_MailCount.Name = "lab_MailCount";
            this.lab_MailCount.Size = new System.Drawing.Size(17, 15);
            this.lab_MailCount.TabIndex = 395;
            this.lab_MailCount.Text = "--";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微軟正黑體", 8F);
            this.label7.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label7.Location = new System.Drawing.Point(4, 491);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(193, 15);
            this.label7.TabIndex = 394;
            this.label7.Text = "2.可支援的outlook版本為2003、2007";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("微軟正黑體", 8F);
            this.label8.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label8.Location = new System.Drawing.Point(4, 475);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(346, 15);
            this.label8.TabIndex = 393;
            this.label8.Text = "1.避免讀取太多的郵件，而影響電腦的效能，請依電腦硬體的等級考量";
            // 
            // but_SearchMail
            // 
            this.but_SearchMail.BackgroundImage = global::LawtechPTSystemByFirm.Properties.Resources.btnT1;
            this.but_SearchMail.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.but_SearchMail.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.but_SearchMail.Image = global::LawtechPTSystemByFirm.Properties.Resources.Email;
            this.but_SearchMail.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.but_SearchMail.Location = new System.Drawing.Point(378, 46);
            this.but_SearchMail.Name = "but_SearchMail";
            this.but_SearchMail.Size = new System.Drawing.Size(161, 30);
            this.but_SearchMail.TabIndex = 316;
            this.but_SearchMail.Text = "讀取郵件";
            this.but_SearchMail.UseVisualStyleBackColor = true;
            this.but_SearchMail.Click += new System.EventHandler(this.button1_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.label6.Location = new System.Drawing.Point(232, 51);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(21, 20);
            this.label6.TabIndex = 315;
            this.label6.Text = "~";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.label5.ForeColor = System.Drawing.Color.Blue;
            this.label5.Location = new System.Drawing.Point(47, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 18);
            this.label5.TabIndex = 314;
            this.label5.Text = "時間區間";
            // 
            // maskedTextBox_EndDate
            // 
            this.maskedTextBox_EndDate.BackColor = System.Drawing.Color.White;
            this.maskedTextBox_EndDate.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.maskedTextBox_EndDate.ForeColor = System.Drawing.Color.RoyalBlue;
            this.maskedTextBox_EndDate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.maskedTextBox_EndDate.Location = new System.Drawing.Point(257, 48);
            this.maskedTextBox_EndDate.Mask = "0000/00/00";
            this.maskedTextBox_EndDate.Name = "maskedTextBox_EndDate";
            this.maskedTextBox_EndDate.Size = new System.Drawing.Size(115, 29);
            this.maskedTextBox_EndDate.TabIndex = 313;
            this.maskedTextBox_EndDate.ValidatingType = typeof(System.DateTime);
            this.maskedTextBox_EndDate.DoubleClick += new System.EventHandler(this.maskedTextBox_Start_DoubleClick);
            // 
            // dataGridView_outlook
            // 
            this.dataGridView_outlook.AllowUserToAddRows = false;
            this.dataGridView_outlook.AllowUserToDeleteRows = false;
            this.dataGridView_outlook.AllowUserToOrderColumns = true;
            this.dataGridView_outlook.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微軟正黑體", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_outlook.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView_outlook.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_outlook.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Selected,
            this.Number,
            this.SenderName,
            this.Subject,
            this.Status,
            this.ReceivedTime});
            this.dataGridView_outlook.GridColor = System.Drawing.SystemColors.ActiveCaption;
            this.dataGridView_outlook.Location = new System.Drawing.Point(6, 83);
            this.dataGridView_outlook.Name = "dataGridView_outlook";
            this.dataGridView_outlook.RowHeadersWidth = 25;
            this.dataGridView_outlook.RowTemplate.Height = 24;
            this.dataGridView_outlook.Size = new System.Drawing.Size(551, 368);
            this.dataGridView_outlook.TabIndex = 312;
            // 
            // Selected
            // 
            this.Selected.DataPropertyName = "Selected";
            this.Selected.HeaderText = "選取";
            this.Selected.Name = "Selected";
            this.Selected.Width = 50;
            // 
            // Number
            // 
            this.Number.DataPropertyName = "Number";
            this.Number.HeaderText = "編號";
            this.Number.Name = "Number";
            this.Number.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Number.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Number.Width = 60;
            // 
            // SenderName
            // 
            this.SenderName.DataPropertyName = "SenderName";
            this.SenderName.HeaderText = "寄件人";
            this.SenderName.Name = "SenderName";
            this.SenderName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.SenderName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Subject
            // 
            this.Subject.DataPropertyName = "Subject";
            this.Subject.HeaderText = "主旨";
            this.Subject.Name = "Subject";
            this.Subject.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Subject.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Subject.Width = 150;
            // 
            // Status
            // 
            this.Status.DataPropertyName = "Status";
            this.Status.HeaderText = "狀態";
            this.Status.Name = "Status";
            this.Status.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Status.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Status.Width = 60;
            // 
            // ReceivedTime
            // 
            this.ReceivedTime.DataPropertyName = "ReceivedTime";
            this.ReceivedTime.HeaderText = "接收時間";
            this.ReceivedTime.Name = "ReceivedTime";
            this.ReceivedTime.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ReceivedTime.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ReceivedTime.Width = 120;
            // 
            // maskedTextBox_Start
            // 
            this.maskedTextBox_Start.BackColor = System.Drawing.Color.White;
            this.maskedTextBox_Start.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.maskedTextBox_Start.ForeColor = System.Drawing.Color.RoyalBlue;
            this.maskedTextBox_Start.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.maskedTextBox_Start.Location = new System.Drawing.Point(114, 48);
            this.maskedTextBox_Start.Mask = "0000/00/00";
            this.maskedTextBox_Start.Name = "maskedTextBox_Start";
            this.maskedTextBox_Start.Size = new System.Drawing.Size(115, 29);
            this.maskedTextBox_Start.TabIndex = 311;
            this.maskedTextBox_Start.ValidatingType = typeof(System.DateTime);
            this.maskedTextBox_Start.DoubleClick += new System.EventHandler(this.maskedTextBox_Start_DoubleClick);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Multiselect = true;
            // 
            // UpFileList
            // 
            this.AcceptButton = this.but_SearchMail;
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::LawtechPTSystemByFirm.Properties.Resources.AddForm_bg;
            this.CancelButton = this.but_Cancel;
            this.ClientSize = new System.Drawing.Size(584, 608);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.but_Cancel);
            this.Controls.Add(this.but_OK);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UpFileList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "上傳檔案";
            this.Load += new System.EventHandler(this.UpFileList_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_outlook)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        internal System.Windows.Forms.Button but_Cancel;
        internal System.Windows.Forms.Button but_OK;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView dataGridView_outlook;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_Start;
        private System.Windows.Forms.Button but_SearchMail;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_EndDate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lab_MailCount;
        private System.Windows.Forms.Label lab_Reader;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Selected;
        private System.Windows.Forms.DataGridViewTextBoxColumn Number;
        private System.Windows.Forms.DataGridViewTextBoxColumn SenderName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Subject;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn ReceivedTime;
        private System.Windows.Forms.Button but_SelectFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.ComboBox cbOutlookFolder;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnOutlookFolder;
    }
}