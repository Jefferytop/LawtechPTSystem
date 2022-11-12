namespace LawtechPTSystem.EditForm
{
    partial class EditNotifyEvent
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
            this.but_Cancel = new System.Windows.Forms.Button();
            this.but_OK = new System.Windows.Forms.Button();
            this.maskedTextBox_NotifyFinishDate = new System.Windows.Forms.MaskedTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txt_EventContent = new System.Windows.Forms.TextBox();
            this.maskedTextBox_NotifyAttorneyDueDate = new System.Windows.Forms.MaskedTextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txt_NotifyRemark = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txt_NotifyRespond = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txt_NotifyResult = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.maskedTextBox_NotifyStartDate = new System.Windows.Forms.MaskedTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.maskedTextBox_NotifyDueDate = new System.Windows.Forms.MaskedTextBox();
            this.comboBox_EventContent = new System.Windows.Forms.ComboBox();
            this.Combo_EClientWorker = new System.Windows.Forms.ComboBox();
            this.workerTAllBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.qS_DataSet = new LawtechPTSystem.QS_DataSet();
            this.Combo_EAttorney = new System.Windows.Forms.ComboBox();
            this.attorneyTBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Combo_EAttorneyTransactor = new System.Windows.Forms.ComboBox();
            this.attorneyTAttLiaisonerTBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.maskedTextBox_OccurDate = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBox_OfficerDate = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBox_ComitDate = new System.Windows.Forms.MaskedTextBox();
            this.Label13 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label9 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.workerTAllTableAdapter = new LawtechPTSystem.QS_DataSetTableAdapters.WorkerTAllTableAdapter();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.workerTAllBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qS_DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.attorneyTBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.attorneyTAttLiaisonerTBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // but_Cancel
            // 
            this.but_Cancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.but_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.but_Cancel.Location = new System.Drawing.Point(325, 435);
            this.but_Cancel.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.but_Cancel.Name = "but_Cancel";
            this.but_Cancel.Size = new System.Drawing.Size(80, 37);
            this.but_Cancel.TabIndex = 507;
            this.but_Cancel.Text = "取消";
            this.but_Cancel.UseVisualStyleBackColor = true;
            this.but_Cancel.Click += new System.EventHandler(this.but_Cancel_Click);
            // 
            // but_OK
            // 
            this.but_OK.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.but_OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.but_OK.Location = new System.Drawing.Point(233, 435);
            this.but_OK.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.but_OK.Name = "but_OK";
            this.but_OK.Size = new System.Drawing.Size(80, 37);
            this.but_OK.TabIndex = 506;
            this.but_OK.Text = "確定";
            this.but_OK.UseVisualStyleBackColor = true;
            this.but_OK.Click += new System.EventHandler(this.but_OK_Click);
            // 
            // maskedTextBox_NotifyFinishDate
            // 
            this.maskedTextBox_NotifyFinishDate.ForeColor = System.Drawing.Color.Green;
            this.maskedTextBox_NotifyFinishDate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.maskedTextBox_NotifyFinishDate.Location = new System.Drawing.Point(432, 169);
            this.maskedTextBox_NotifyFinishDate.Mask = "0000-00-00";
            this.maskedTextBox_NotifyFinishDate.Name = "maskedTextBox_NotifyFinishDate";
            this.maskedTextBox_NotifyFinishDate.Size = new System.Drawing.Size(182, 29);
            this.maskedTextBox_NotifyFinishDate.TabIndex = 19;
            this.maskedTextBox_NotifyFinishDate.ValidatingType = typeof(System.DateTime);
            this.maskedTextBox_NotifyFinishDate.DoubleClick += new System.EventHandler(this.maskedTextBox_ComitDate_DoubleClick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(5, 173);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(105, 20);
            this.label6.TabIndex = 246;
            this.label6.Text = "法定答覆期限";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txt_EventContent);
            this.panel1.Controls.Add(this.maskedTextBox_NotifyAttorneyDueDate);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.txt_NotifyRemark);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.txt_NotifyRespond);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.txt_NotifyResult);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.maskedTextBox_NotifyFinishDate);
            this.panel1.Controls.Add(this.maskedTextBox_NotifyStartDate);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.maskedTextBox_NotifyDueDate);
            this.panel1.Controls.Add(this.comboBox_EventContent);
            this.panel1.Controls.Add(this.Combo_EClientWorker);
            this.panel1.Controls.Add(this.Combo_EAttorney);
            this.panel1.Controls.Add(this.Combo_EAttorneyTransactor);
            this.panel1.Controls.Add(this.maskedTextBox_OccurDate);
            this.panel1.Controls.Add(this.maskedTextBox_OfficerDate);
            this.panel1.Controls.Add(this.maskedTextBox_ComitDate);
            this.panel1.Controls.Add(this.Label13);
            this.panel1.Controls.Add(this.Label1);
            this.panel1.Controls.Add(this.Label2);
            this.panel1.Controls.Add(this.Label9);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(4, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(644, 395);
            this.panel1.TabIndex = 504;
            // 
            // txt_EventContent
            // 
            this.txt_EventContent.Location = new System.Drawing.Point(111, 9);
            this.txt_EventContent.Name = "txt_EventContent";
            this.txt_EventContent.Size = new System.Drawing.Size(502, 29);
            this.txt_EventContent.TabIndex = 259;
            // 
            // maskedTextBox_NotifyAttorneyDueDate
            // 
            this.maskedTextBox_NotifyAttorneyDueDate.ForeColor = System.Drawing.Color.Green;
            this.maskedTextBox_NotifyAttorneyDueDate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.maskedTextBox_NotifyAttorneyDueDate.Location = new System.Drawing.Point(112, 136);
            this.maskedTextBox_NotifyAttorneyDueDate.Mask = "0000-00-00";
            this.maskedTextBox_NotifyAttorneyDueDate.Name = "maskedTextBox_NotifyAttorneyDueDate";
            this.maskedTextBox_NotifyAttorneyDueDate.Size = new System.Drawing.Size(173, 29);
            this.maskedTextBox_NotifyAttorneyDueDate.TabIndex = 258;
            this.maskedTextBox_NotifyAttorneyDueDate.ValidatingType = typeof(System.DateTime);
            this.maskedTextBox_NotifyAttorneyDueDate.DoubleClick += new System.EventHandler(this.maskedTextBox_ComitDate_DoubleClick);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(37, 139);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(73, 20);
            this.label14.TabIndex = 257;
            this.label14.Text = "本所期限";
            // 
            // txt_NotifyRemark
            // 
            this.txt_NotifyRemark.Location = new System.Drawing.Point(112, 313);
            this.txt_NotifyRemark.Multiline = true;
            this.txt_NotifyRemark.Name = "txt_NotifyRemark";
            this.txt_NotifyRemark.Size = new System.Drawing.Size(502, 72);
            this.txt_NotifyRemark.TabIndex = 256;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(53, 316);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(57, 20);
            this.label12.TabIndex = 255;
            this.label12.Text = "備    註";
            // 
            // txt_NotifyRespond
            // 
            this.txt_NotifyRespond.Location = new System.Drawing.Point(112, 202);
            this.txt_NotifyRespond.Name = "txt_NotifyRespond";
            this.txt_NotifyRespond.Size = new System.Drawing.Size(502, 29);
            this.txt_NotifyRespond.TabIndex = 254;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(21, 207);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(89, 20);
            this.label11.TabIndex = 253;
            this.label11.Text = "應答覆程序";
            // 
            // txt_NotifyResult
            // 
            this.txt_NotifyResult.Location = new System.Drawing.Point(112, 235);
            this.txt_NotifyResult.Multiline = true;
            this.txt_NotifyResult.Name = "txt_NotifyResult";
            this.txt_NotifyResult.Size = new System.Drawing.Size(502, 72);
            this.txt_NotifyResult.TabIndex = 252;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(37, 239);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 20);
            this.label8.TabIndex = 251;
            this.label8.Text = "處理結果";
            // 
            // maskedTextBox_NotifyStartDate
            // 
            this.maskedTextBox_NotifyStartDate.ForeColor = System.Drawing.Color.Green;
            this.maskedTextBox_NotifyStartDate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.maskedTextBox_NotifyStartDate.Location = new System.Drawing.Point(432, 132);
            this.maskedTextBox_NotifyStartDate.Mask = "0000-00-00";
            this.maskedTextBox_NotifyStartDate.Name = "maskedTextBox_NotifyStartDate";
            this.maskedTextBox_NotifyStartDate.Size = new System.Drawing.Size(182, 29);
            this.maskedTextBox_NotifyStartDate.TabIndex = 248;
            this.maskedTextBox_NotifyStartDate.ValidatingType = typeof(System.DateTime);
            this.maskedTextBox_NotifyStartDate.DoubleClick += new System.EventHandler(this.maskedTextBox_ComitDate_DoubleClick);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(361, 137);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 20);
            this.label7.TabIndex = 249;
            this.label7.Text = "送件日期";
            // 
            // maskedTextBox_NotifyDueDate
            // 
            this.maskedTextBox_NotifyDueDate.ForeColor = System.Drawing.Color.Green;
            this.maskedTextBox_NotifyDueDate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.maskedTextBox_NotifyDueDate.Location = new System.Drawing.Point(112, 169);
            this.maskedTextBox_NotifyDueDate.Mask = "0000-00-00";
            this.maskedTextBox_NotifyDueDate.Name = "maskedTextBox_NotifyDueDate";
            this.maskedTextBox_NotifyDueDate.Size = new System.Drawing.Size(173, 29);
            this.maskedTextBox_NotifyDueDate.TabIndex = 246;
            this.maskedTextBox_NotifyDueDate.ValidatingType = typeof(System.DateTime);
            this.maskedTextBox_NotifyDueDate.DoubleClick += new System.EventHandler(this.maskedTextBox_ComitDate_DoubleClick);
            // 
            // comboBox_EventContent
            // 
            this.comboBox_EventContent.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBox_EventContent.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.comboBox_EventContent.DisplayMember = "NotifyContent";
            this.comboBox_EventContent.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold);
            this.comboBox_EventContent.FormattingEnabled = true;
            this.comboBox_EventContent.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.comboBox_EventContent.Location = new System.Drawing.Point(111, 9);
            this.comboBox_EventContent.Name = "comboBox_EventContent";
            this.comboBox_EventContent.Size = new System.Drawing.Size(38, 29);
            this.comboBox_EventContent.TabIndex = 1;
            this.comboBox_EventContent.ValueMember = "autoSN";
            this.comboBox_EventContent.SelectedIndexChanged += new System.EventHandler(this.comboBox_EventContent_SelectedIndexChanged);
            // 
            // Combo_EClientWorker
            // 
            this.Combo_EClientWorker.DataSource = this.workerTAllBindingSource;
            this.Combo_EClientWorker.DisplayMember = "Name";
            this.Combo_EClientWorker.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Combo_EClientWorker.FormattingEnabled = true;
            this.Combo_EClientWorker.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Combo_EClientWorker.Location = new System.Drawing.Point(432, 43);
            this.Combo_EClientWorker.Margin = new System.Windows.Forms.Padding(4);
            this.Combo_EClientWorker.Name = "Combo_EClientWorker";
            this.Combo_EClientWorker.Size = new System.Drawing.Size(182, 28);
            this.Combo_EClientWorker.TabIndex = 5;
            this.Combo_EClientWorker.ValueMember = "WorkerKEY";
            // 
            // workerTAllBindingSource
            // 
            this.workerTAllBindingSource.DataMember = "WorkerTAll";
            this.workerTAllBindingSource.DataSource = this.qS_DataSet;
            // 
            // qS_DataSet
            // 
            this.qS_DataSet.DataSetName = "QS_DataSet";
            this.qS_DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // Combo_EAttorney
            // 
            this.Combo_EAttorney.DataSource = this.attorneyTBindingSource;
            this.Combo_EAttorney.DisplayMember = "AttorneySymbol";
            this.Combo_EAttorney.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Combo_EAttorney.FormattingEnabled = true;
            this.Combo_EAttorney.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Combo_EAttorney.Location = new System.Drawing.Point(432, 72);
            this.Combo_EAttorney.Margin = new System.Windows.Forms.Padding(4);
            this.Combo_EAttorney.Name = "Combo_EAttorney";
            this.Combo_EAttorney.Size = new System.Drawing.Size(182, 28);
            this.Combo_EAttorney.TabIndex = 7;
            this.Combo_EAttorney.ValueMember = "AttorneyKEY";
            this.Combo_EAttorney.SelectedIndexChanged += new System.EventHandler(this.Combo_EAttorney_SelectedIndexChanged);
            // 
            // attorneyTBindingSource
            // 
            this.attorneyTBindingSource.DataMember = "AttorneyT";
            // 
            // Combo_EAttorneyTransactor
            // 
            this.Combo_EAttorneyTransactor.DataSource = this.attorneyTAttLiaisonerTBindingSource;
            this.Combo_EAttorneyTransactor.DisplayMember = "Liaisoner";
            this.Combo_EAttorneyTransactor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Combo_EAttorneyTransactor.FormattingEnabled = true;
            this.Combo_EAttorneyTransactor.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Combo_EAttorneyTransactor.Location = new System.Drawing.Point(432, 101);
            this.Combo_EAttorneyTransactor.Margin = new System.Windows.Forms.Padding(4);
            this.Combo_EAttorneyTransactor.Name = "Combo_EAttorneyTransactor";
            this.Combo_EAttorneyTransactor.Size = new System.Drawing.Size(182, 28);
            this.Combo_EAttorneyTransactor.TabIndex = 10;
            this.Combo_EAttorneyTransactor.ValueMember = "ALiaisonerKey";
            // 
            // attorneyTAttLiaisonerTBindingSource
            // 
            this.attorneyTAttLiaisonerTBindingSource.DataSource = this.attorneyTBindingSource;
            // 
            // maskedTextBox_OccurDate
            // 
            this.maskedTextBox_OccurDate.ForeColor = System.Drawing.Color.Green;
            this.maskedTextBox_OccurDate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.maskedTextBox_OccurDate.Location = new System.Drawing.Point(112, 103);
            this.maskedTextBox_OccurDate.Mask = "0000-00-00";
            this.maskedTextBox_OccurDate.Name = "maskedTextBox_OccurDate";
            this.maskedTextBox_OccurDate.Size = new System.Drawing.Size(173, 29);
            this.maskedTextBox_OccurDate.TabIndex = 6;
            this.maskedTextBox_OccurDate.ValidatingType = typeof(System.DateTime);
            this.maskedTextBox_OccurDate.DoubleClick += new System.EventHandler(this.maskedTextBox_ComitDate_DoubleClick);
            // 
            // maskedTextBox_OfficerDate
            // 
            this.maskedTextBox_OfficerDate.ForeColor = System.Drawing.Color.Green;
            this.maskedTextBox_OfficerDate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.maskedTextBox_OfficerDate.Location = new System.Drawing.Point(112, 72);
            this.maskedTextBox_OfficerDate.Mask = "0000-00-00";
            this.maskedTextBox_OfficerDate.Name = "maskedTextBox_OfficerDate";
            this.maskedTextBox_OfficerDate.Size = new System.Drawing.Size(173, 29);
            this.maskedTextBox_OfficerDate.TabIndex = 4;
            this.maskedTextBox_OfficerDate.ValidatingType = typeof(System.DateTime);
            this.maskedTextBox_OfficerDate.DoubleClick += new System.EventHandler(this.maskedTextBox_ComitDate_DoubleClick);
            // 
            // maskedTextBox_ComitDate
            // 
            this.maskedTextBox_ComitDate.ForeColor = System.Drawing.Color.Green;
            this.maskedTextBox_ComitDate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.maskedTextBox_ComitDate.Location = new System.Drawing.Point(112, 42);
            this.maskedTextBox_ComitDate.Mask = "0000-00-00";
            this.maskedTextBox_ComitDate.Name = "maskedTextBox_ComitDate";
            this.maskedTextBox_ComitDate.Size = new System.Drawing.Size(173, 29);
            this.maskedTextBox_ComitDate.TabIndex = 2;
            this.maskedTextBox_ComitDate.ValidatingType = typeof(System.DateTime);
            this.maskedTextBox_ComitDate.DoubleClick += new System.EventHandler(this.maskedTextBox_ComitDate_DoubleClick);
            // 
            // Label13
            // 
            this.Label13.AutoSize = true;
            this.Label13.Location = new System.Drawing.Point(346, 46);
            this.Label13.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.Label13.Name = "Label13";
            this.Label13.Size = new System.Drawing.Size(89, 20);
            this.Label13.TabIndex = 223;
            this.Label13.Text = "本所承辦人";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(345, 76);
            this.Label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(89, 20);
            this.Label1.TabIndex = 231;
            this.Label1.Text = "承辦事務所";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(329, 104);
            this.Label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(105, 20);
            this.Label2.TabIndex = 232;
            this.Label2.Text = "事務所承辦人";
            // 
            // Label9
            // 
            this.Label9.AutoSize = true;
            this.Label9.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold);
            this.Label9.Location = new System.Drawing.Point(36, 13);
            this.Label9.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(74, 21);
            this.Label9.TabIndex = 221;
            this.Label9.Text = "來函內容";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 20);
            this.label4.TabIndex = 244;
            this.label4.Text = "來函收文日";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 77);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 20);
            this.label5.TabIndex = 245;
            this.label5.Text = "官方發文日";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(21, 108);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(89, 20);
            this.label10.TabIndex = 245;
            this.label10.Text = "官方送達日";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(361, 172);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 20);
            this.label3.TabIndex = 250;
            this.label3.Text = "完成日期";
            // 
            // workerTAllTableAdapter
            // 
            this.workerTAllTableAdapter.ClearBeforeFill = true;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(208, 12);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(91, 24);
            this.radioButton3.TabIndex = 509;
            this.radioButton3.Text = "期限來函";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.Visible = false;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(112, 12);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(91, 24);
            this.radioButton1.TabIndex = 508;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "一般來函";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.Visible = false;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // EditNotifyEvent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CancelButton = this.but_Cancel;
            this.ClientSize = new System.Drawing.Size(649, 486);
            this.Controls.Add(this.radioButton3);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.but_Cancel);
            this.Controls.Add(this.but_OK);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditNotifyEvent";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "修改來函資料";
            this.Load += new System.EventHandler(this.EditNotifyEvent_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.workerTAllBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qS_DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.attorneyTBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.attorneyTAttLiaisonerTBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Button but_Cancel;
        internal System.Windows.Forms.Button but_OK;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_NotifyFinishDate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel1;
        internal System.Windows.Forms.ComboBox comboBox_EventContent;
        private System.Windows.Forms.ComboBox Combo_EClientWorker;
        private System.Windows.Forms.ComboBox Combo_EAttorney;
        private System.Windows.Forms.ComboBox Combo_EAttorneyTransactor;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_OccurDate;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_OfficerDate;
        internal System.Windows.Forms.MaskedTextBox maskedTextBox_ComitDate;
        internal System.Windows.Forms.Label Label13;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label9;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_NotifyStartDate;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_NotifyDueDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_NotifyResult;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.BindingSource attorneyTBindingSource;
        private System.Windows.Forms.BindingSource attorneyTAttLiaisonerTBindingSource;
        private QS_DataSet qS_DataSet;
        private System.Windows.Forms.BindingSource workerTAllBindingSource;
        private LawtechPTSystem.QS_DataSetTableAdapters.WorkerTAllTableAdapter workerTAllTableAdapter;
        internal System.Windows.Forms.RadioButton radioButton3;
        internal System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.TextBox txt_NotifyRespond;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txt_NotifyRemark;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_NotifyAttorneyDueDate;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txt_EventContent;

    }
}