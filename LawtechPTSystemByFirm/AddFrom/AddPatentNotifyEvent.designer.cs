namespace LawtechPTSystemByFirm.AddFrom
{
    partial class AddPatentNotifyEvent
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.maskedTextBox_NotifyAttorneyDueDate = new System.Windows.Forms.MaskedTextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.maskedTextBox_DueDate = new System.Windows.Forms.MaskedTextBox();
            this.txt_Respond = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBox_Statue = new System.Windows.Forms.ComboBox();
            this.patStatusTDropBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.qS_DataSet = new LawtechPTSystemByFirm.QS_DataSet();
            this.button4 = new System.Windows.Forms.Button();
            this.txt_UpdateFile = new System.Windows.Forms.TextBox();
            this.txt_upDoc = new System.Windows.Forms.TextBox();
            this.comboBox_EventContent = new System.Windows.Forms.ComboBox();
            this.txt_StatusExplain = new System.Windows.Forms.TextBox();
            this.Combo_EClientWorker = new System.Windows.Forms.ComboBox();
            this.workerQuitNBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Combo_EAttorney = new System.Windows.Forms.ComboBox();
            this.attorneyTBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet_Drop = new LawtechPTSystemByFirm.DataSet_Drop();
            this.Combo_EAttorneyTransactor = new System.Windows.Forms.ComboBox();
            this.maskedTextBox_OccurDate = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBox_OfficerDate = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBox_ComitDate = new System.Windows.Forms.MaskedTextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.Label13 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label9 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.but_Cancel = new System.Windows.Forms.Button();
            this.but_OK = new System.Windows.Forms.Button();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.worker_QuitNTableAdapter = new LawtechPTSystemByFirm.QS_DataSetTableAdapters.Worker_QuitNTableAdapter();
            this.attorneyTTableAdapter = new LawtechPTSystemByFirm.DataSet_DropTableAdapters.AttorneyTTableAdapter();
            this.attLiaisonerTTableAdapter = new LawtechPTSystemByFirm.DataSet_DropTableAdapters.AttLiaisonerTTableAdapter();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.patStatusT_DropTableAdapter = new LawtechPTSystemByFirm.QS_DataSetTableAdapters.PatStatusT_DropTableAdapter();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.patStatusTDropBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qS_DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.workerQuitNBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.attorneyTBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_Drop)).BeginInit();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.maskedTextBox_NotifyAttorneyDueDate);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Controls.Add(this.maskedTextBox_DueDate);
            this.panel2.Controls.Add(this.txt_Respond);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Location = new System.Drawing.Point(12, 302);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(614, 83);
            this.panel2.TabIndex = 322;
            // 
            // maskedTextBox_NotifyAttorneyDueDate
            // 
            this.maskedTextBox_NotifyAttorneyDueDate.ForeColor = System.Drawing.Color.Green;
            this.maskedTextBox_NotifyAttorneyDueDate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.maskedTextBox_NotifyAttorneyDueDate.Location = new System.Drawing.Point(431, 37);
            this.maskedTextBox_NotifyAttorneyDueDate.Mask = "0000/00/00";
            this.maskedTextBox_NotifyAttorneyDueDate.Name = "maskedTextBox_NotifyAttorneyDueDate";
            this.maskedTextBox_NotifyAttorneyDueDate.Size = new System.Drawing.Size(173, 29);
            this.maskedTextBox_NotifyAttorneyDueDate.TabIndex = 380;
            this.maskedTextBox_NotifyAttorneyDueDate.ValidatingType = typeof(System.DateTime);
            this.maskedTextBox_NotifyAttorneyDueDate.DoubleClick += new System.EventHandler(this.maskedTextBox_ComitDate_DoubleClick);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(361, 42);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(73, 20);
            this.label14.TabIndex = 379;
            this.label14.Text = "所內期限";
            // 
            // maskedTextBox_DueDate
            // 
            this.maskedTextBox_DueDate.ForeColor = System.Drawing.Color.Green;
            this.maskedTextBox_DueDate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.maskedTextBox_DueDate.Location = new System.Drawing.Point(102, 37);
            this.maskedTextBox_DueDate.Mask = "0000/00/00";
            this.maskedTextBox_DueDate.Name = "maskedTextBox_DueDate";
            this.maskedTextBox_DueDate.Size = new System.Drawing.Size(173, 29);
            this.maskedTextBox_DueDate.TabIndex = 19;
            this.maskedTextBox_DueDate.ValidatingType = typeof(System.DateTime);
            this.maskedTextBox_DueDate.DoubleClick += new System.EventHandler(this.maskedTextBox_ComitDate_DoubleClick);
            // 
            // txt_Respond
            // 
            this.txt_Respond.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txt_Respond.Location = new System.Drawing.Point(102, 4);
            this.txt_Respond.Name = "txt_Respond";
            this.txt_Respond.Size = new System.Drawing.Size(502, 29);
            this.txt_Respond.TabIndex = 18;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(17, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(89, 20);
            this.label8.TabIndex = 306;
            this.label8.Text = "應答覆程序";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(2, 41);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(105, 20);
            this.label6.TabIndex = 246;
            this.label6.Text = "法定答覆期限";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.comboBox_Statue);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.txt_UpdateFile);
            this.panel1.Controls.Add(this.txt_upDoc);
            this.panel1.Controls.Add(this.comboBox_EventContent);
            this.panel1.Controls.Add(this.txt_StatusExplain);
            this.panel1.Controls.Add(this.Combo_EClientWorker);
            this.panel1.Controls.Add(this.Combo_EAttorney);
            this.panel1.Controls.Add(this.Combo_EAttorneyTransactor);
            this.panel1.Controls.Add(this.maskedTextBox_OccurDate);
            this.panel1.Controls.Add(this.maskedTextBox_OfficerDate);
            this.panel1.Controls.Add(this.maskedTextBox_ComitDate);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.Label13);
            this.panel1.Controls.Add(this.Label1);
            this.panel1.Controls.Add(this.Label2);
            this.panel1.Controls.Add(this.Label9);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Location = new System.Drawing.Point(12, 29);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(614, 266);
            this.panel1.TabIndex = 321;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(30, 167);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 20);
            this.label7.TabIndex = 378;
            this.label7.Text = "狀態描述";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("微軟正黑體", 9F);
            this.button1.Location = new System.Drawing.Point(276, 133);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(98, 23);
            this.button1.TabIndex = 377;
            this.button1.Text = "原申請案狀態";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBox_Statue
            // 
            this.comboBox_Statue.DataSource = this.patStatusTDropBindingSource;
            this.comboBox_Statue.DisplayMember = "Status";
            this.comboBox_Statue.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Statue.FormattingEnabled = true;
            this.comboBox_Statue.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.comboBox_Statue.Location = new System.Drawing.Point(102, 133);
            this.comboBox_Statue.Name = "comboBox_Statue";
            this.comboBox_Statue.Size = new System.Drawing.Size(173, 28);
            this.comboBox_Statue.TabIndex = 8;
            this.comboBox_Statue.ValueMember = "StatusID";
            // 
            // patStatusTDropBindingSource
            // 
            this.patStatusTDropBindingSource.DataMember = "PatStatusT-Drop";
            this.patStatusTDropBindingSource.DataSource = this.qS_DataSet;
            // 
            // qS_DataSet
            // 
            this.qS_DataSet.DataSetName = "QS_DataSet";
            this.qS_DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(453, 230);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(53, 26);
            this.button4.TabIndex = 16;
            this.button4.Text = "瀏覽";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // txt_UpdateFile
            // 
            this.txt_UpdateFile.BackColor = System.Drawing.Color.White;
            this.txt_UpdateFile.ForeColor = System.Drawing.Color.Black;
            this.txt_UpdateFile.Location = new System.Drawing.Point(102, 229);
            this.txt_UpdateFile.Name = "txt_UpdateFile";
            this.txt_UpdateFile.ReadOnly = true;
            this.txt_UpdateFile.Size = new System.Drawing.Size(349, 29);
            this.txt_UpdateFile.TabIndex = 318;
            // 
            // txt_upDoc
            // 
            this.txt_upDoc.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txt_upDoc.Location = new System.Drawing.Point(102, 195);
            this.txt_upDoc.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.txt_upDoc.MaxLength = 500;
            this.txt_upDoc.Name = "txt_upDoc";
            this.txt_upDoc.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_upDoc.Size = new System.Drawing.Size(502, 29);
            this.txt_upDoc.TabIndex = 15;
            // 
            // comboBox_EventContent
            // 
            this.comboBox_EventContent.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBox_EventContent.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.comboBox_EventContent.DisplayMember = "NotifyContent";
            this.comboBox_EventContent.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold);
            this.comboBox_EventContent.FormattingEnabled = true;
            this.comboBox_EventContent.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.comboBox_EventContent.Location = new System.Drawing.Point(102, 9);
            this.comboBox_EventContent.Name = "comboBox_EventContent";
            this.comboBox_EventContent.Size = new System.Drawing.Size(502, 29);
            this.comboBox_EventContent.TabIndex = 1;
            this.comboBox_EventContent.ValueMember = "autoSN";
            this.comboBox_EventContent.SelectedIndexChanged += new System.EventHandler(this.comboBox_EventContent_SelectedIndexChanged);
            // 
            // txt_StatusExplain
            // 
            this.txt_StatusExplain.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txt_StatusExplain.Location = new System.Drawing.Point(102, 163);
            this.txt_StatusExplain.Name = "txt_StatusExplain";
            this.txt_StatusExplain.Size = new System.Drawing.Size(502, 29);
            this.txt_StatusExplain.TabIndex = 12;
            // 
            // Combo_EClientWorker
            // 
            this.Combo_EClientWorker.DataSource = this.workerQuitNBindingSource;
            this.Combo_EClientWorker.DisplayMember = "Name";
            this.Combo_EClientWorker.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Combo_EClientWorker.FormattingEnabled = true;
            this.Combo_EClientWorker.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Combo_EClientWorker.Location = new System.Drawing.Point(422, 40);
            this.Combo_EClientWorker.Margin = new System.Windows.Forms.Padding(4);
            this.Combo_EClientWorker.Name = "Combo_EClientWorker";
            this.Combo_EClientWorker.Size = new System.Drawing.Size(182, 28);
            this.Combo_EClientWorker.TabIndex = 5;
            this.Combo_EClientWorker.ValueMember = "WorkerKEY";
            // 
            // workerQuitNBindingSource
            // 
            this.workerQuitNBindingSource.DataMember = "Worker_QuitN";
            this.workerQuitNBindingSource.DataSource = this.qS_DataSet;
            // 
            // Combo_EAttorney
            // 
            this.Combo_EAttorney.DataSource = this.attorneyTBindingSource;
            this.Combo_EAttorney.DisplayMember = "AttorneySymbol";
            this.Combo_EAttorney.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Combo_EAttorney.FormattingEnabled = true;
            this.Combo_EAttorney.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Combo_EAttorney.Location = new System.Drawing.Point(422, 69);
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
            this.attorneyTBindingSource.DataSource = this.dataSet_Drop;
            // 
            // dataSet_Drop
            // 
            this.dataSet_Drop.DataSetName = "DataSet_Drop";
            this.dataSet_Drop.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // Combo_EAttorneyTransactor
            // 
            this.Combo_EAttorneyTransactor.DisplayMember = "ALiaisonerKey";
            this.Combo_EAttorneyTransactor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Combo_EAttorneyTransactor.FormattingEnabled = true;
            this.Combo_EAttorneyTransactor.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Combo_EAttorneyTransactor.Location = new System.Drawing.Point(422, 98);
            this.Combo_EAttorneyTransactor.Margin = new System.Windows.Forms.Padding(4);
            this.Combo_EAttorneyTransactor.Name = "Combo_EAttorneyTransactor";
            this.Combo_EAttorneyTransactor.Size = new System.Drawing.Size(182, 28);
            this.Combo_EAttorneyTransactor.TabIndex = 10;
            this.Combo_EAttorneyTransactor.ValueMember = "ALiaisonerKey";
            // 
            // maskedTextBox_OccurDate
            // 
            this.maskedTextBox_OccurDate.ForeColor = System.Drawing.Color.Green;
            this.maskedTextBox_OccurDate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.maskedTextBox_OccurDate.Location = new System.Drawing.Point(102, 100);
            this.maskedTextBox_OccurDate.Mask = "0000/00/00";
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
            this.maskedTextBox_OfficerDate.Location = new System.Drawing.Point(102, 69);
            this.maskedTextBox_OfficerDate.Mask = "0000/00/00";
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
            this.maskedTextBox_ComitDate.Location = new System.Drawing.Point(102, 39);
            this.maskedTextBox_ComitDate.Mask = "0000/00/00";
            this.maskedTextBox_ComitDate.Name = "maskedTextBox_ComitDate";
            this.maskedTextBox_ComitDate.Size = new System.Drawing.Size(173, 29);
            this.maskedTextBox_ComitDate.TabIndex = 2;
            this.maskedTextBox_ComitDate.ValidatingType = typeof(System.DateTime);
            this.maskedTextBox_ComitDate.DoubleClick += new System.EventHandler(this.maskedTextBox_ComitDate_DoubleClick);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(1, 200);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(105, 20);
            this.label12.TabIndex = 306;
            this.label12.Text = "上傳文件描述";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 232);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 20);
            this.label3.TabIndex = 306;
            this.label3.Text = "來函上傳";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(1, 136);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(105, 20);
            this.label11.TabIndex = 306;
            this.label11.Text = "目前案件狀態";
            // 
            // Label13
            // 
            this.Label13.AutoSize = true;
            this.Label13.Location = new System.Drawing.Point(336, 43);
            this.Label13.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.Label13.Name = "Label13";
            this.Label13.Size = new System.Drawing.Size(89, 20);
            this.Label13.TabIndex = 223;
            this.Label13.Text = "本所承辦人";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(335, 73);
            this.Label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(89, 20);
            this.Label1.TabIndex = 231;
            this.Label1.Text = "承辦事務所";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(319, 101);
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
            this.Label9.Location = new System.Drawing.Point(27, 13);
            this.Label9.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(74, 21);
            this.Label9.TabIndex = 221;
            this.Label9.Text = "來函內容";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 20);
            this.label4.TabIndex = 244;
            this.label4.Text = "來函收文日";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 74);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 20);
            this.label5.TabIndex = 245;
            this.label5.Text = "官方發文日";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(18, 105);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(89, 20);
            this.label10.TabIndex = 245;
            this.label10.Text = "官方送達日";
            // 
            // but_Cancel
            // 
            this.but_Cancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.but_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.but_Cancel.Location = new System.Drawing.Point(317, 416);
            this.but_Cancel.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.but_Cancel.Name = "but_Cancel";
            this.but_Cancel.Size = new System.Drawing.Size(80, 37);
            this.but_Cancel.TabIndex = 503;
            this.but_Cancel.Text = "取消";
            this.but_Cancel.UseVisualStyleBackColor = true;
            this.but_Cancel.Click += new System.EventHandler(this.but_Cancel_Click);
            // 
            // but_OK
            // 
            this.but_OK.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.but_OK.Location = new System.Drawing.Point(225, 416);
            this.but_OK.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.but_OK.Name = "but_OK";
            this.but_OK.Size = new System.Drawing.Size(80, 37);
            this.but_OK.TabIndex = 502;
            this.but_OK.Text = "確定";
            this.but_OK.UseVisualStyleBackColor = true;
            this.but_OK.Click += new System.EventHandler(this.but_OK_Click);
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.BackColor = System.Drawing.Color.Transparent;
            this.radioButton3.Location = new System.Drawing.Point(373, 6);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(91, 24);
            this.radioButton3.TabIndex = 505;
            this.radioButton3.Text = "期限來函";
            this.radioButton3.UseVisualStyleBackColor = false;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.BackColor = System.Drawing.Color.Transparent;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(98, 6);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(91, 24);
            this.radioButton1.TabIndex = 504;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "一般來函";
            this.radioButton1.UseVisualStyleBackColor = false;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // worker_QuitNTableAdapter
            // 
            this.worker_QuitNTableAdapter.ClearBeforeFill = true;
            // 
            // attorneyTTableAdapter
            // 
            this.attorneyTTableAdapter.ClearBeforeFill = true;
            // 
            // attLiaisonerTTableAdapter
            // 
            this.attLiaisonerTTableAdapter.ClearBeforeFill = true;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // patStatusT_DropTableAdapter
            // 
            this.patStatusT_DropTableAdapter.ClearBeforeFill = true;
            // 
            // AddPatentNotifyEvent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::LawtechPTSystemByFirm.Properties.Resources.bg1;
            this.CancelButton = this.but_Cancel;
            this.ClientSize = new System.Drawing.Size(637, 464);
            this.Controls.Add(this.radioButton3);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.but_Cancel);
            this.Controls.Add(this.but_OK);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddPatentNotifyEvent";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "新增來函";
            this.Load += new System.EventHandler(this.AddPatentNotifyEvent_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.patStatusTDropBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qS_DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.workerQuitNBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.attorneyTBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_Drop)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_DueDate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_Respond;
        private System.Windows.Forms.Panel panel1;
        internal System.Windows.Forms.ComboBox comboBox_Statue;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox txt_UpdateFile;
        internal System.Windows.Forms.TextBox txt_upDoc;
        internal System.Windows.Forms.ComboBox comboBox_EventContent;
        internal System.Windows.Forms.TextBox txt_StatusExplain;
        private System.Windows.Forms.ComboBox Combo_EClientWorker;
        private System.Windows.Forms.ComboBox Combo_EAttorney;
        private System.Windows.Forms.ComboBox Combo_EAttorneyTransactor;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_OccurDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_OfficerDate;
        private System.Windows.Forms.Label label10;
        internal System.Windows.Forms.MaskedTextBox maskedTextBox_ComitDate;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label11;
        internal System.Windows.Forms.Label Label13;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label9;
        internal System.Windows.Forms.Button but_Cancel;
        internal System.Windows.Forms.Button but_OK;
        internal System.Windows.Forms.RadioButton radioButton3;
        internal System.Windows.Forms.RadioButton radioButton1;
        private QS_DataSet qS_DataSet;
        private System.Windows.Forms.BindingSource workerQuitNBindingSource;
        private LawtechPTSystemByFirm.QS_DataSetTableAdapters.Worker_QuitNTableAdapter worker_QuitNTableAdapter;
        private DataSet_Drop dataSet_Drop;
        private System.Windows.Forms.BindingSource attorneyTBindingSource;
        private LawtechPTSystemByFirm.DataSet_DropTableAdapters.AttorneyTTableAdapter attorneyTTableAdapter;
        private LawtechPTSystemByFirm.DataSet_DropTableAdapters.AttLiaisonerTTableAdapter attLiaisonerTTableAdapter;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.BindingSource patStatusTDropBindingSource;
        private LawtechPTSystemByFirm.QS_DataSetTableAdapters.PatStatusT_DropTableAdapter patStatusT_DropTableAdapter;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_NotifyAttorneyDueDate;
        private System.Windows.Forms.Label label14;
    }
}