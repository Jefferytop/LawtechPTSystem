namespace LawtechPTSystem.EditForm
{
    partial class EditTrademarkNotifyEvent
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditTrademarkNotifyEvent));
            this.comboBox_EventType = new System.Windows.Forms.ComboBox();
            this.trademarkNotifyEventTypeTBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.but_Cancel = new System.Windows.Forms.Button();
            this.but_OK = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.maskedTextBox_NoticeDate = new System.Windows.Forms.MaskedTextBox();
            this.contextMenuStrip_ForDate = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolStripMenuItem_Calculation = new System.Windows.Forms.ToolStripMenuItem();
            this.label36 = new System.Windows.Forms.Label();
            this.maskedTextBox_OutsourcingDate = new System.Windows.Forms.MaskedTextBox();
            this.label33 = new System.Windows.Forms.Label();
            this.maskedTextBox_FinishDate = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBox_DueDate = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBox_OccurDate = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBox_NotifyOfficerDate = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBox_NotifyComitDate = new System.Windows.Forms.MaskedTextBox();
            this.label48 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label49 = new System.Windows.Forms.Label();
            this.txt_Remark = new System.Windows.Forms.TextBox();
            this.txt_Result = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.maskedTextBox_AttorneyDueDate = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox_WorkerKey = new System.Windows.Forms.ComboBox();
            this.workerQuitNBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBox_Statue = new System.Windows.Forms.ComboBox();
            this.tMStatusTBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label11 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txt_StatusExplain = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txt_SingcCode = new System.Windows.Forms.TextBox();
            this.but_SingOff = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.txt_SingCodeStatus = new System.Windows.Forms.TextBox();
            this.Combo_EAttorneyTransactor = new System.Windows.Forms.ComboBox();
            this.Combo_EAttorney = new System.Windows.Forms.ComboBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolStripMenuItem_All = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_CurrentCountry = new System.Windows.Forms.ToolStripMenuItem();
            this.attorneyTBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.attLiaisonerTBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.comboBox_NotifyEventContent = new System.Windows.Forms.ComboBox();
            this.bindingSource_NotifyContent = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.trademarkNotifyEventTypeTBindingSource)).BeginInit();
            this.contextMenuStrip_ForDate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.workerQuitNBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tMStatusTBindingSource)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.attorneyTBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.attLiaisonerTBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_NotifyContent)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBox_EventType
            // 
            this.comboBox_EventType.DataSource = this.trademarkNotifyEventTypeTBindingSource;
            this.comboBox_EventType.DisplayMember = "NotifyEventTypeName";
            this.comboBox_EventType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_EventType.Font = new System.Drawing.Font("微軟正黑體", 14F);
            this.comboBox_EventType.FormattingEnabled = true;
            this.comboBox_EventType.Location = new System.Drawing.Point(63, 512);
            this.comboBox_EventType.Name = "comboBox_EventType";
            this.comboBox_EventType.Size = new System.Drawing.Size(34, 32);
            this.comboBox_EventType.TabIndex = 1078;
            this.comboBox_EventType.ValueMember = "NotifyEventTypeName";
            this.comboBox_EventType.Visible = false;
            // 
            // but_Cancel
            // 
            this.but_Cancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.but_Cancel.BackgroundImage = global::LawtechPTSystem.Properties.Resources.btnCancel;
            this.but_Cancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.but_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.but_Cancel.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.but_Cancel.Location = new System.Drawing.Point(286, 558);
            this.but_Cancel.Margin = new System.Windows.Forms.Padding(4);
            this.but_Cancel.Name = "but_Cancel";
            this.but_Cancel.Size = new System.Drawing.Size(100, 32);
            this.but_Cancel.TabIndex = 16;
            this.but_Cancel.Text = "取   消";
            this.but_Cancel.UseVisualStyleBackColor = true;
            this.but_Cancel.Click += new System.EventHandler(this.but_Cancel_Click);
            // 
            // but_OK
            // 
            this.but_OK.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.but_OK.BackgroundImage = global::LawtechPTSystem.Properties.Resources.btnComfirm;
            this.but_OK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.but_OK.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.but_OK.Location = new System.Drawing.Point(184, 558);
            this.but_OK.Margin = new System.Windows.Forms.Padding(4);
            this.but_OK.Name = "but_OK";
            this.but_OK.Size = new System.Drawing.Size(100, 32);
            this.but_OK.TabIndex = 15;
            this.but_OK.Text = "確   定";
            this.but_OK.UseVisualStyleBackColor = true;
            this.but_OK.Click += new System.EventHandler(this.but_OK_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(-9, 515);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 20);
            this.label2.TabIndex = 1075;
            this.label2.Text = "事件種類";
            this.label2.Visible = false;
            // 
            // maskedTextBox_NoticeDate
            // 
            this.maskedTextBox_NoticeDate.ContextMenuStrip = this.contextMenuStrip_ForDate;
            this.maskedTextBox_NoticeDate.ForeColor = System.Drawing.Color.Green;
            this.maskedTextBox_NoticeDate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.maskedTextBox_NoticeDate.Location = new System.Drawing.Point(396, 242);
            this.maskedTextBox_NoticeDate.Margin = new System.Windows.Forms.Padding(1);
            this.maskedTextBox_NoticeDate.Mask = "0000-00-00";
            this.maskedTextBox_NoticeDate.Name = "maskedTextBox_NoticeDate";
            this.maskedTextBox_NoticeDate.Size = new System.Drawing.Size(123, 29);
            this.maskedTextBox_NoticeDate.TabIndex = 9;
            this.maskedTextBox_NoticeDate.ValidatingType = typeof(System.DateTime);
            this.maskedTextBox_NoticeDate.DoubleClick += new System.EventHandler(this.maskedTextBox_NotifyComitDate_DoubleClick);
            this.maskedTextBox_NoticeDate.Leave += new System.EventHandler(this.maskedTextBox_NotifyComitDate_Leave);
            // 
            // contextMenuStrip_ForDate
            // 
            this.contextMenuStrip_ForDate.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_Calculation});
            this.contextMenuStrip_ForDate.Name = "contextMenuStrip_ForDate";
            this.contextMenuStrip_ForDate.Size = new System.Drawing.Size(123, 26);
            this.contextMenuStrip_ForDate.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuStrip_ForDate_ItemClicked);
            // 
            // ToolStripMenuItem_Calculation
            // 
            this.ToolStripMenuItem_Calculation.Name = "ToolStripMenuItem_Calculation";
            this.ToolStripMenuItem_Calculation.Size = new System.Drawing.Size(122, 22);
            this.ToolStripMenuItem_Calculation.Text = "計算日期";
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.BackColor = System.Drawing.Color.Transparent;
            this.label36.Location = new System.Drawing.Point(323, 245);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(73, 20);
            this.label36.TabIndex = 1073;
            this.label36.Text = "送件日期";
            // 
            // maskedTextBox_OutsourcingDate
            // 
            this.maskedTextBox_OutsourcingDate.ContextMenuStrip = this.contextMenuStrip_ForDate;
            this.maskedTextBox_OutsourcingDate.ForeColor = System.Drawing.Color.Green;
            this.maskedTextBox_OutsourcingDate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.maskedTextBox_OutsourcingDate.Location = new System.Drawing.Point(396, 211);
            this.maskedTextBox_OutsourcingDate.Margin = new System.Windows.Forms.Padding(1);
            this.maskedTextBox_OutsourcingDate.Mask = "0000-00-00";
            this.maskedTextBox_OutsourcingDate.Name = "maskedTextBox_OutsourcingDate";
            this.maskedTextBox_OutsourcingDate.Size = new System.Drawing.Size(123, 29);
            this.maskedTextBox_OutsourcingDate.TabIndex = 11;
            this.maskedTextBox_OutsourcingDate.ValidatingType = typeof(System.DateTime);
            this.maskedTextBox_OutsourcingDate.DoubleClick += new System.EventHandler(this.maskedTextBox_NotifyComitDate_DoubleClick);
            this.maskedTextBox_OutsourcingDate.Leave += new System.EventHandler(this.maskedTextBox_NotifyComitDate_Leave);
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.BackColor = System.Drawing.Color.Transparent;
            this.label33.Location = new System.Drawing.Point(323, 215);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(73, 20);
            this.label33.TabIndex = 1071;
            this.label33.Text = "委外日期";
            // 
            // maskedTextBox_FinishDate
            // 
            this.maskedTextBox_FinishDate.ContextMenuStrip = this.contextMenuStrip_ForDate;
            this.maskedTextBox_FinishDate.ForeColor = System.Drawing.Color.Green;
            this.maskedTextBox_FinishDate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.maskedTextBox_FinishDate.Location = new System.Drawing.Point(116, 278);
            this.maskedTextBox_FinishDate.Margin = new System.Windows.Forms.Padding(1);
            this.maskedTextBox_FinishDate.Mask = "0000-00-00";
            this.maskedTextBox_FinishDate.Name = "maskedTextBox_FinishDate";
            this.maskedTextBox_FinishDate.Size = new System.Drawing.Size(123, 29);
            this.maskedTextBox_FinishDate.TabIndex = 12;
            this.maskedTextBox_FinishDate.ValidatingType = typeof(System.DateTime);
            this.maskedTextBox_FinishDate.DoubleClick += new System.EventHandler(this.maskedTextBox_NotifyComitDate_DoubleClick);
            this.maskedTextBox_FinishDate.Leave += new System.EventHandler(this.maskedTextBox_NotifyComitDate_Leave);
            // 
            // maskedTextBox_DueDate
            // 
            this.maskedTextBox_DueDate.ContextMenuStrip = this.contextMenuStrip_ForDate;
            this.maskedTextBox_DueDate.ForeColor = System.Drawing.Color.Green;
            this.maskedTextBox_DueDate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.maskedTextBox_DueDate.Location = new System.Drawing.Point(116, 247);
            this.maskedTextBox_DueDate.Margin = new System.Windows.Forms.Padding(1);
            this.maskedTextBox_DueDate.Mask = "0000-00-00";
            this.maskedTextBox_DueDate.Name = "maskedTextBox_DueDate";
            this.maskedTextBox_DueDate.Size = new System.Drawing.Size(123, 29);
            this.maskedTextBox_DueDate.TabIndex = 6;
            this.maskedTextBox_DueDate.ValidatingType = typeof(System.DateTime);
            this.maskedTextBox_DueDate.DoubleClick += new System.EventHandler(this.maskedTextBox_NotifyComitDate_DoubleClick);
            this.maskedTextBox_DueDate.Leave += new System.EventHandler(this.maskedTextBox_NotifyComitDate_Leave);
            // 
            // maskedTextBox_OccurDate
            // 
            this.maskedTextBox_OccurDate.ContextMenuStrip = this.contextMenuStrip_ForDate;
            this.maskedTextBox_OccurDate.ForeColor = System.Drawing.Color.Green;
            this.maskedTextBox_OccurDate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.maskedTextBox_OccurDate.Location = new System.Drawing.Point(116, 184);
            this.maskedTextBox_OccurDate.Margin = new System.Windows.Forms.Padding(1);
            this.maskedTextBox_OccurDate.Mask = "0000-00-00";
            this.maskedTextBox_OccurDate.Name = "maskedTextBox_OccurDate";
            this.maskedTextBox_OccurDate.Size = new System.Drawing.Size(123, 29);
            this.maskedTextBox_OccurDate.TabIndex = 5;
            this.maskedTextBox_OccurDate.ValidatingType = typeof(System.DateTime);
            this.maskedTextBox_OccurDate.DoubleClick += new System.EventHandler(this.maskedTextBox_NotifyComitDate_DoubleClick);
            this.maskedTextBox_OccurDate.Leave += new System.EventHandler(this.maskedTextBox_NotifyComitDate_Leave);
            // 
            // maskedTextBox_NotifyOfficerDate
            // 
            this.maskedTextBox_NotifyOfficerDate.ContextMenuStrip = this.contextMenuStrip_ForDate;
            this.maskedTextBox_NotifyOfficerDate.ForeColor = System.Drawing.Color.Green;
            this.maskedTextBox_NotifyOfficerDate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.maskedTextBox_NotifyOfficerDate.Location = new System.Drawing.Point(116, 153);
            this.maskedTextBox_NotifyOfficerDate.Margin = new System.Windows.Forms.Padding(1);
            this.maskedTextBox_NotifyOfficerDate.Mask = "0000-00-00";
            this.maskedTextBox_NotifyOfficerDate.Name = "maskedTextBox_NotifyOfficerDate";
            this.maskedTextBox_NotifyOfficerDate.Size = new System.Drawing.Size(123, 29);
            this.maskedTextBox_NotifyOfficerDate.TabIndex = 4;
            this.maskedTextBox_NotifyOfficerDate.ValidatingType = typeof(System.DateTime);
            this.maskedTextBox_NotifyOfficerDate.DoubleClick += new System.EventHandler(this.maskedTextBox_NotifyComitDate_DoubleClick);
            this.maskedTextBox_NotifyOfficerDate.Leave += new System.EventHandler(this.maskedTextBox_NotifyComitDate_Leave);
            // 
            // maskedTextBox_NotifyComitDate
            // 
            this.maskedTextBox_NotifyComitDate.ContextMenuStrip = this.contextMenuStrip_ForDate;
            this.maskedTextBox_NotifyComitDate.ForeColor = System.Drawing.Color.Green;
            this.maskedTextBox_NotifyComitDate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.maskedTextBox_NotifyComitDate.Location = new System.Drawing.Point(116, 122);
            this.maskedTextBox_NotifyComitDate.Margin = new System.Windows.Forms.Padding(1);
            this.maskedTextBox_NotifyComitDate.Mask = "0000-00-00";
            this.maskedTextBox_NotifyComitDate.Name = "maskedTextBox_NotifyComitDate";
            this.maskedTextBox_NotifyComitDate.Size = new System.Drawing.Size(123, 29);
            this.maskedTextBox_NotifyComitDate.TabIndex = 3;
            this.maskedTextBox_NotifyComitDate.ValidatingType = typeof(System.DateTime);
            this.maskedTextBox_NotifyComitDate.DoubleClick += new System.EventHandler(this.maskedTextBox_NotifyComitDate_DoubleClick);
            this.maskedTextBox_NotifyComitDate.Leave += new System.EventHandler(this.maskedTextBox_NotifyComitDate_Leave);
            // 
            // label48
            // 
            this.label48.AutoSize = true;
            this.label48.BackColor = System.Drawing.Color.Transparent;
            this.label48.ForeColor = System.Drawing.Color.Brown;
            this.label48.Location = new System.Drawing.Point(43, 284);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(73, 20);
            this.label48.TabIndex = 1063;
            this.label48.Text = "完成日期";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.BackColor = System.Drawing.Color.Transparent;
            this.label23.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.label23.Location = new System.Drawing.Point(43, 252);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(73, 20);
            this.label23.TabIndex = 1061;
            this.label23.Text = "官方期限";
            // 
            // label49
            // 
            this.label49.AutoSize = true;
            this.label49.BackColor = System.Drawing.Color.Transparent;
            this.label49.Location = new System.Drawing.Point(59, 391);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(57, 20);
            this.label49.TabIndex = 1056;
            this.label49.Text = "備    註";
            // 
            // txt_Remark
            // 
            this.txt_Remark.BackColor = System.Drawing.Color.White;
            this.txt_Remark.ImeMode = System.Windows.Forms.ImeMode.Close;
            this.txt_Remark.Location = new System.Drawing.Point(116, 367);
            this.txt_Remark.Margin = new System.Windows.Forms.Padding(1);
            this.txt_Remark.Multiline = true;
            this.txt_Remark.Name = "txt_Remark";
            this.txt_Remark.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_Remark.Size = new System.Drawing.Size(432, 67);
            this.txt_Remark.TabIndex = 14;
            // 
            // txt_Result
            // 
            this.txt_Result.ImeMode = System.Windows.Forms.ImeMode.Close;
            this.txt_Result.Location = new System.Drawing.Point(116, 309);
            this.txt_Result.Margin = new System.Windows.Forms.Padding(1);
            this.txt_Result.Multiline = true;
            this.txt_Result.Name = "txt_Result";
            this.txt_Result.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_Result.Size = new System.Drawing.Size(432, 56);
            this.txt_Result.TabIndex = 13;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Location = new System.Drawing.Point(43, 189);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(73, 20);
            this.label10.TabIndex = 1060;
            this.label10.Text = "簽收日期";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(27, 157);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 20);
            this.label6.TabIndex = 1059;
            this.label6.Text = "官方發文日";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(49)))), ((int)(((byte)(149)))), ((int)(((byte)(115)))));
            this.label5.Location = new System.Drawing.Point(27, 126);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 20);
            this.label5.TabIndex = 1058;
            this.label5.Text = "事件發生日";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(43, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 20);
            this.label1.TabIndex = 1057;
            this.label1.Text = "來函內容";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Location = new System.Drawing.Point(43, 330);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 20);
            this.label8.TabIndex = 1054;
            this.label8.Text = "處理結果";
            // 
            // maskedTextBox_AttorneyDueDate
            // 
            this.maskedTextBox_AttorneyDueDate.ContextMenuStrip = this.contextMenuStrip_ForDate;
            this.maskedTextBox_AttorneyDueDate.ForeColor = System.Drawing.Color.Green;
            this.maskedTextBox_AttorneyDueDate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.maskedTextBox_AttorneyDueDate.Location = new System.Drawing.Point(116, 216);
            this.maskedTextBox_AttorneyDueDate.Margin = new System.Windows.Forms.Padding(1);
            this.maskedTextBox_AttorneyDueDate.Mask = "0000-00-00";
            this.maskedTextBox_AttorneyDueDate.Name = "maskedTextBox_AttorneyDueDate";
            this.maskedTextBox_AttorneyDueDate.Size = new System.Drawing.Size(123, 29);
            this.maskedTextBox_AttorneyDueDate.TabIndex = 7;
            this.maskedTextBox_AttorneyDueDate.ValidatingType = typeof(System.DateTime);
            this.maskedTextBox_AttorneyDueDate.DoubleClick += new System.EventHandler(this.maskedTextBox_NotifyComitDate_DoubleClick);
            this.maskedTextBox_AttorneyDueDate.Leave += new System.EventHandler(this.maskedTextBox_NotifyComitDate_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(68)))), ((int)(((byte)(98)))), ((int)(((byte)(214)))));
            this.label3.Location = new System.Drawing.Point(43, 218);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 20);
            this.label3.TabIndex = 1079;
            this.label3.Text = "所內期限";
            // 
            // comboBox_WorkerKey
            // 
            this.comboBox_WorkerKey.DataSource = this.workerQuitNBindingSource;
            this.comboBox_WorkerKey.DisplayMember = "FullEmployeeName";
            this.comboBox_WorkerKey.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_WorkerKey.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.comboBox_WorkerKey.FormattingEnabled = true;
            this.comboBox_WorkerKey.Location = new System.Drawing.Point(396, 120);
            this.comboBox_WorkerKey.Margin = new System.Windows.Forms.Padding(1);
            this.comboBox_WorkerKey.Name = "comboBox_WorkerKey";
            this.comboBox_WorkerKey.Size = new System.Drawing.Size(152, 28);
            this.comboBox_WorkerKey.TabIndex = 8;
            this.comboBox_WorkerKey.ValueMember = "WorkerKey";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(307, 124);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 20);
            this.label4.TabIndex = 1081;
            this.label4.Text = "事件承辦人";
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::LawtechPTSystem.Properties.Resources.button_technorati;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.button1.Location = new System.Drawing.Point(437, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(111, 28);
            this.button1.TabIndex = 1087;
            this.button1.TabStop = false;
            this.button1.Text = "回復案件階段";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBox_Statue
            // 
            this.comboBox_Statue.DataSource = this.tMStatusTBindingSource;
            this.comboBox_Statue.DisplayMember = "Status";
            this.comboBox_Statue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Statue.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.comboBox_Statue.FormattingEnabled = true;
            this.comboBox_Statue.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.comboBox_Statue.Location = new System.Drawing.Point(116, 12);
            this.comboBox_Statue.Margin = new System.Windows.Forms.Padding(1);
            this.comboBox_Statue.Name = "comboBox_Statue";
            this.comboBox_Statue.Size = new System.Drawing.Size(318, 28);
            this.comboBox_Statue.TabIndex = 0;
            this.comboBox_Statue.ValueMember = "TMStatusID";
            this.comboBox_Statue.SelectedIndexChanged += new System.EventHandler(this.comboBox_Statue_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Location = new System.Drawing.Point(11, 16);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(105, 20);
            this.label11.TabIndex = 1086;
            this.label11.Text = "目前案件階段";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Location = new System.Drawing.Point(43, 48);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(73, 20);
            this.label14.TabIndex = 1084;
            this.label14.Text = "階段描述";
            // 
            // txt_StatusExplain
            // 
            this.txt_StatusExplain.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txt_StatusExplain.Location = new System.Drawing.Point(116, 43);
            this.txt_StatusExplain.Margin = new System.Windows.Forms.Padding(1);
            this.txt_StatusExplain.Name = "txt_StatusExplain";
            this.txt_StatusExplain.Size = new System.Drawing.Size(432, 29);
            this.txt_StatusExplain.TabIndex = 2;
            this.txt_StatusExplain.TextChanged += new System.EventHandler(this.txt_StatusExplain_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(43, 93);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 20);
            this.label7.TabIndex = 1088;
            this.label7.Text = "事件內容";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.Transparent;
            this.label17.Font = new System.Drawing.Font("微軟正黑體", 9F);
            this.label17.ForeColor = System.Drawing.Color.DarkRed;
            this.label17.Location = new System.Drawing.Point(121, 504);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(109, 16);
            this.label17.TabIndex = 1104;
            this.label17.Text = "3.) 主管可取消簽核";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Font = new System.Drawing.Font("微軟正黑體", 9F);
            this.label16.ForeColor = System.Drawing.Color.DarkRed;
            this.label16.Location = new System.Drawing.Point(121, 486);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(301, 16);
            this.label16.TabIndex = 1103;
            this.label16.Text = "2.) 可多位主管會簽，需商標主管或最高權限身份可會簽";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Font = new System.Drawing.Font("微軟正黑體", 9F);
            this.label15.ForeColor = System.Drawing.Color.DarkRed;
            this.label15.Location = new System.Drawing.Point(121, 468);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(289, 16);
            this.label15.TabIndex = 1102;
            this.label15.Text = "1.) 經簽核後將不得再變更，需主管權限才能變更資料";
            // 
            // txt_SingcCode
            // 
            this.txt_SingcCode.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.txt_SingcCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_SingcCode.ForeColor = System.Drawing.Color.Blue;
            this.txt_SingcCode.Location = new System.Drawing.Point(116, 436);
            this.txt_SingcCode.Margin = new System.Windows.Forms.Padding(1);
            this.txt_SingcCode.Name = "txt_SingcCode";
            this.txt_SingcCode.ReadOnly = true;
            this.txt_SingcCode.Size = new System.Drawing.Size(432, 29);
            this.txt_SingcCode.TabIndex = 1100;
            this.txt_SingcCode.TabStop = false;
            // 
            // but_SingOff
            // 
            this.but_SingOff.BackgroundImage = global::LawtechPTSystem.Properties.Resources.btnGeen;
            this.but_SingOff.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.but_SingOff.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.but_SingOff.Location = new System.Drawing.Point(18, 436);
            this.but_SingOff.Name = "but_SingOff";
            this.but_SingOff.Size = new System.Drawing.Size(98, 28);
            this.but_SingOff.TabIndex = 1099;
            this.but_SingOff.Text = "簽  核";
            this.but_SingOff.UseVisualStyleBackColor = true;
            this.but_SingOff.Visible = false;
            this.but_SingOff.Click += new System.EventHandler(this.but_SingOff_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Location = new System.Drawing.Point(42, 440);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(73, 20);
            this.label9.TabIndex = 1101;
            this.label9.Text = "主管簽核";
            // 
            // txt_SingCodeStatus
            // 
            this.txt_SingCodeStatus.Location = new System.Drawing.Point(473, 468);
            this.txt_SingCodeStatus.Name = "txt_SingCodeStatus";
            this.txt_SingCodeStatus.Size = new System.Drawing.Size(55, 29);
            this.txt_SingCodeStatus.TabIndex = 1105;
            this.txt_SingCodeStatus.Visible = false;
            // 
            // Combo_EAttorneyTransactor
            // 
            this.Combo_EAttorneyTransactor.DisplayMember = "Liaisoner";
            this.Combo_EAttorneyTransactor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Combo_EAttorneyTransactor.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.Combo_EAttorneyTransactor.FormattingEnabled = true;
            this.Combo_EAttorneyTransactor.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Combo_EAttorneyTransactor.Location = new System.Drawing.Point(396, 181);
            this.Combo_EAttorneyTransactor.Margin = new System.Windows.Forms.Padding(1);
            this.Combo_EAttorneyTransactor.Name = "Combo_EAttorneyTransactor";
            this.Combo_EAttorneyTransactor.Size = new System.Drawing.Size(152, 28);
            this.Combo_EAttorneyTransactor.TabIndex = 1107;
            this.Combo_EAttorneyTransactor.ValueMember = "ALiaisonerKey";
            // 
            // Combo_EAttorney
            // 
            this.Combo_EAttorney.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.Combo_EAttorney.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.Combo_EAttorney.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(211)))), ((int)(((byte)(167)))));
            this.Combo_EAttorney.ContextMenuStrip = this.contextMenuStrip1;
            this.Combo_EAttorney.DataSource = this.attorneyTBindingSource;
            this.Combo_EAttorney.DisplayMember = "AttorneyKEY";
            this.Combo_EAttorney.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.Combo_EAttorney.ForeColor = System.Drawing.Color.Black;
            this.Combo_EAttorney.FormattingEnabled = true;
            this.Combo_EAttorney.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Combo_EAttorney.Location = new System.Drawing.Point(396, 151);
            this.Combo_EAttorney.Margin = new System.Windows.Forms.Padding(1);
            this.Combo_EAttorney.Name = "Combo_EAttorney";
            this.Combo_EAttorney.Size = new System.Drawing.Size(152, 28);
            this.Combo_EAttorney.TabIndex = 1106;
            this.Combo_EAttorney.ValueMember = "AttorneyKEY";
            this.Combo_EAttorney.SelectedIndexChanged += new System.EventHandler(this.Combo_EAttorney_SelectedIndexChanged_1);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_All,
            this.ToolStripMenuItem_CurrentCountry});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(159, 48);
            this.contextMenuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuStrip1_ItemClicked);
            // 
            // ToolStripMenuItem_All
            // 
            this.ToolStripMenuItem_All.Name = "ToolStripMenuItem_All";
            this.ToolStripMenuItem_All.Size = new System.Drawing.Size(158, 22);
            this.ToolStripMenuItem_All.Text = "所有事務所";
            // 
            // ToolStripMenuItem_CurrentCountry
            // 
            this.ToolStripMenuItem_CurrentCountry.Name = "ToolStripMenuItem_CurrentCountry";
            this.ToolStripMenuItem_CurrentCountry.Size = new System.Drawing.Size(158, 22);
            this.ToolStripMenuItem_CurrentCountry.Text = "目前國別事務所";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Location = new System.Drawing.Point(291, 186);
            this.label12.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(105, 20);
            this.label12.TabIndex = 1109;
            this.label12.Text = "事務所承辦人";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Location = new System.Drawing.Point(307, 157);
            this.label13.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(89, 20);
            this.label13.TabIndex = 1108;
            this.label13.Text = "承辦事務所";
            // 
            // comboBox_NotifyEventContent
            // 
            this.comboBox_NotifyEventContent.DataSource = this.bindingSource_NotifyContent;
            this.comboBox_NotifyEventContent.DisplayMember = "TMNotifyDueID";
            this.comboBox_NotifyEventContent.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.comboBox_NotifyEventContent.FormattingEnabled = true;
            this.comboBox_NotifyEventContent.Location = new System.Drawing.Point(116, 90);
            this.comboBox_NotifyEventContent.Name = "comboBox_NotifyEventContent";
            this.comboBox_NotifyEventContent.Size = new System.Drawing.Size(432, 28);
            this.comboBox_NotifyEventContent.TabIndex = 1110;
            this.comboBox_NotifyEventContent.ValueMember = "TMNotifyDueID";
            // 
            // EditTrademarkNotifyEvent
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = global::LawtechPTSystem.Properties.Resources.EditForm_bg;
            this.CancelButton = this.but_Cancel;
            this.ClientSize = new System.Drawing.Size(571, 600);
            this.Controls.Add(this.comboBox_NotifyEventContent);
            this.Controls.Add(this.Combo_EAttorneyTransactor);
            this.Controls.Add(this.Combo_EAttorney);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txt_SingCodeStatus);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.txt_SingcCode);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.comboBox_Statue);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.but_Cancel);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.comboBox_WorkerKey);
            this.Controls.Add(this.txt_StatusExplain);
            this.Controls.Add(this.maskedTextBox_AttorneyDueDate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBox_EventType);
            this.Controls.Add(this.but_OK);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.maskedTextBox_NotifyComitDate);
            this.Controls.Add(this.maskedTextBox_NoticeDate);
            this.Controls.Add(this.maskedTextBox_DueDate);
            this.Controls.Add(this.label36);
            this.Controls.Add(this.maskedTextBox_OutsourcingDate);
            this.Controls.Add(this.label33);
            this.Controls.Add(this.maskedTextBox_FinishDate);
            this.Controls.Add(this.maskedTextBox_OccurDate);
            this.Controls.Add(this.maskedTextBox_NotifyOfficerDate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label48);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.label49);
            this.Controls.Add(this.txt_Remark);
            this.Controls.Add(this.txt_Result);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.but_SingOff);
            this.Controls.Add(this.label9);
            this.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditTrademarkNotifyEvent";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "修改案件記錄";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.EditTrademarkNotifyEvent_FormClosed);
            this.Load += new System.EventHandler(this.EditTrademarkNotifyEvent_Load);
            this.DoubleClick += new System.EventHandler(this.maskedTextBox_NotifyComitDate_DoubleClick);
            ((System.ComponentModel.ISupportInitialize)(this.trademarkNotifyEventTypeTBindingSource)).EndInit();
            this.contextMenuStrip_ForDate.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.workerQuitNBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tMStatusTBindingSource)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.attorneyTBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.attLiaisonerTBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource_NotifyContent)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox_EventType;
        private System.Windows.Forms.Button but_Cancel;
        private System.Windows.Forms.Button but_OK;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_NoticeDate;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_OutsourcingDate;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_FinishDate;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_DueDate;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_OccurDate;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_NotifyOfficerDate;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_NotifyComitDate;
        private System.Windows.Forms.Label label48;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label49;
        internal System.Windows.Forms.TextBox txt_Remark;
        internal System.Windows.Forms.TextBox txt_Result;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.BindingSource trademarkNotifyEventTypeTBindingSource;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_AttorneyDueDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox_WorkerKey;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.BindingSource workerQuitNBindingSource;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_ForDate;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Calculation;
        private System.Windows.Forms.Button button1;
        internal System.Windows.Forms.ComboBox comboBox_Statue;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label14;
        internal System.Windows.Forms.TextBox txt_StatusExplain;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.BindingSource tMStatusTBindingSource;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txt_SingcCode;
        private System.Windows.Forms.Button but_SingOff;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txt_SingCodeStatus;
        private System.Windows.Forms.ComboBox Combo_EAttorneyTransactor;
        private System.Windows.Forms.ComboBox Combo_EAttorney;
        internal System.Windows.Forms.Label label12;
        internal System.Windows.Forms.Label label13;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_All;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_CurrentCountry;
        private System.Windows.Forms.BindingSource attorneyTBindingSource;
        private System.Windows.Forms.BindingSource attLiaisonerTBindingSource;
        private System.Windows.Forms.ComboBox comboBox_NotifyEventContent;
        private System.Windows.Forms.BindingSource bindingSource_NotifyContent;
    }
}