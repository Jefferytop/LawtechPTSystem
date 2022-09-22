namespace LawtechPTSystem.AddFrom
{
    partial class AddTMNotifyDue
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddTMNotifyDue));
            this.label4 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBox_FeePhase = new System.Windows.Forms.ComboBox();
            this.feePhaseTByTMBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet_Drop = new DataSet_Drop();
            this.comboBox_StartDate = new System.Windows.Forms.ComboBox();
            this.patStartDateDropBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.qS_DataSet = new QS_DataSet();
            this.comboBox_TimeUnit = new System.Windows.Forms.ComboBox();
            this.timeUnitDropBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.numericUpDown_ASday = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_AnswerTime = new System.Windows.Forms.NumericUpDown();
            this.txt_Answer = new System.Windows.Forms.TextBox();
            this.comboBox_country = new System.Windows.Forms.ComboBox();
            this.countryTDropBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.txt_Note = new System.Windows.Forms.TextBox();
            this.comboBox_Status = new System.Windows.Forms.ComboBox();
            this.tMStatusTBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.txt_Content = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.countryT_DropTableAdapter = new QS_DataSetTableAdapters.CountryT_DropTableAdapter();
            this.tMStatusTTableAdapter = new DataSet_DropTableAdapters.TMStatusTTableAdapter();
            this.feePhaseTByTMTableAdapter = new DataSet_DropTableAdapters.FeePhaseTByTMTableAdapter();
            this.timeUnit_DropTableAdapter = new QS_DataSetTableAdapters.TimeUnit_DropTableAdapter();
            this.patStartDate_DropTableAdapter = new QS_DataSetTableAdapters.PatStartDate_DropTableAdapter();
            this.label12 = new System.Windows.Forms.Label();
            this.cb_Process = new System.Windows.Forms.ComboBox();
            this.trademarkProcessKindTBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.trademarkProcessKindTTableAdapter = new DataSet_DropTableAdapters.TrademarkProcessKindTTableAdapter();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.feePhaseTByTMBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_Drop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.patStartDateDropBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qS_DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeUnitDropBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_ASday)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_AnswerTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.countryTDropBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tMStatusTBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trademarkProcessKindTBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.label4.Location = new System.Drawing.Point(56, 240);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 20);
            this.label4.TabIndex = 72;
            this.label4.Text = "提醒訊息";
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button2.BackgroundImage = global::LawtechPTSystem.Properties.Resources.btnCancel;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.button2.Location = new System.Drawing.Point(200, 342);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(112, 32);
            this.button2.TabIndex = 71;
            this.button2.Text = "取消";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button1.BackgroundImage = global::LawtechPTSystem.Properties.Resources.btnComfirm;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.button1.Location = new System.Drawing.Point(79, 342);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 32);
            this.button1.TabIndex = 70;
            this.button1.Text = "確定";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBox_FeePhase
            // 
            this.comboBox_FeePhase.DataSource = this.feePhaseTByTMBindingSource;
            this.comboBox_FeePhase.DisplayMember = "FeePhase";
            this.comboBox_FeePhase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_FeePhase.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.comboBox_FeePhase.FormattingEnabled = true;
            this.comboBox_FeePhase.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.comboBox_FeePhase.Location = new System.Drawing.Point(472, 165);
            this.comboBox_FeePhase.Name = "comboBox_FeePhase";
            this.comboBox_FeePhase.Size = new System.Drawing.Size(38, 28);
            this.comboBox_FeePhase.TabIndex = 55;
            this.comboBox_FeePhase.ValueMember = "FeePhaseID";
            this.comboBox_FeePhase.Visible = false;
            // 
            // feePhaseTByTMBindingSource
            // 
            this.feePhaseTByTMBindingSource.DataMember = "FeePhaseTByTM";
            this.feePhaseTByTMBindingSource.DataSource = this.dataSet_Drop;
            // 
            // dataSet_Drop
            // 
            this.dataSet_Drop.DataSetName = "DataSet_Drop";
            this.dataSet_Drop.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // comboBox_StartDate
            // 
            this.comboBox_StartDate.DataSource = this.patStartDateDropBindingSource;
            this.comboBox_StartDate.DisplayMember = "SelectString";
            this.comboBox_StartDate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_StartDate.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.comboBox_StartDate.FormattingEnabled = true;
            this.comboBox_StartDate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.comboBox_StartDate.Location = new System.Drawing.Point(479, 71);
            this.comboBox_StartDate.Name = "comboBox_StartDate";
            this.comboBox_StartDate.Size = new System.Drawing.Size(31, 28);
            this.comboBox_StartDate.TabIndex = 60;
            this.comboBox_StartDate.ValueMember = "SelectValue";
            this.comboBox_StartDate.Visible = false;
            // 
            // patStartDateDropBindingSource
            // 
            this.patStartDateDropBindingSource.DataMember = "PatStartDate_Drop";
            this.patStartDateDropBindingSource.DataSource = this.qS_DataSet;
            // 
            // qS_DataSet
            // 
            this.qS_DataSet.DataSetName = "QS_DataSet";
            this.qS_DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // comboBox_TimeUnit
            // 
            this.comboBox_TimeUnit.DataSource = this.timeUnitDropBindingSource;
            this.comboBox_TimeUnit.DisplayMember = "SelectString";
            this.comboBox_TimeUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_TimeUnit.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.comboBox_TimeUnit.FormattingEnabled = true;
            this.comboBox_TimeUnit.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.comboBox_TimeUnit.Location = new System.Drawing.Point(479, 43);
            this.comboBox_TimeUnit.Name = "comboBox_TimeUnit";
            this.comboBox_TimeUnit.Size = new System.Drawing.Size(31, 28);
            this.comboBox_TimeUnit.TabIndex = 58;
            this.comboBox_TimeUnit.ValueMember = "SelectValue";
            this.comboBox_TimeUnit.Visible = false;
            // 
            // timeUnitDropBindingSource
            // 
            this.timeUnitDropBindingSource.DataMember = "TimeUnit_Drop";
            this.timeUnitDropBindingSource.DataSource = this.qS_DataSet;
            // 
            // numericUpDown_ASday
            // 
            this.numericUpDown_ASday.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.numericUpDown_ASday.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.numericUpDown_ASday.Location = new System.Drawing.Point(479, 99);
            this.numericUpDown_ASday.Maximum = new decimal(new int[] {
            365,
            0,
            0,
            0});
            this.numericUpDown_ASday.Name = "numericUpDown_ASday";
            this.numericUpDown_ASday.Size = new System.Drawing.Size(31, 29);
            this.numericUpDown_ASday.TabIndex = 62;
            this.numericUpDown_ASday.Visible = false;
            // 
            // numericUpDown_AnswerTime
            // 
            this.numericUpDown_AnswerTime.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.numericUpDown_AnswerTime.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.numericUpDown_AnswerTime.Location = new System.Drawing.Point(479, 11);
            this.numericUpDown_AnswerTime.Maximum = new decimal(new int[] {
            365,
            0,
            0,
            0});
            this.numericUpDown_AnswerTime.Name = "numericUpDown_AnswerTime";
            this.numericUpDown_AnswerTime.Size = new System.Drawing.Size(31, 29);
            this.numericUpDown_AnswerTime.TabIndex = 57;
            this.numericUpDown_AnswerTime.Visible = false;
            // 
            // txt_Answer
            // 
            this.txt_Answer.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.txt_Answer.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txt_Answer.Location = new System.Drawing.Point(479, 132);
            this.txt_Answer.Name = "txt_Answer";
            this.txt_Answer.Size = new System.Drawing.Size(31, 29);
            this.txt_Answer.TabIndex = 54;
            this.txt_Answer.Visible = false;
            // 
            // comboBox_country
            // 
            this.comboBox_country.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBox_country.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox_country.BackColor = System.Drawing.Color.White;
            this.comboBox_country.DataSource = this.countryTDropBindingSource;
            this.comboBox_country.DisplayMember = "Country";
            this.comboBox_country.Enabled = false;
            this.comboBox_country.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.comboBox_country.FormattingEnabled = true;
            this.comboBox_country.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.comboBox_country.Location = new System.Drawing.Point(129, 15);
            this.comboBox_country.Name = "comboBox_country";
            this.comboBox_country.Size = new System.Drawing.Size(244, 28);
            this.comboBox_country.TabIndex = 0;
            this.comboBox_country.ValueMember = "CountrySymbol";
            // 
            // countryTDropBindingSource
            // 
            this.countryTDropBindingSource.DataMember = "CountryT_Drop";
            this.countryTDropBindingSource.DataSource = this.qS_DataSet;
            // 
            // txt_Note
            // 
            this.txt_Note.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.txt_Note.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txt_Note.Location = new System.Drawing.Point(129, 207);
            this.txt_Note.Multiline = true;
            this.txt_Note.Name = "txt_Note";
            this.txt_Note.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_Note.Size = new System.Drawing.Size(244, 96);
            this.txt_Note.TabIndex = 5;
            // 
            // comboBox_Status
            // 
            this.comboBox_Status.DataSource = this.tMStatusTBindingSource;
            this.comboBox_Status.DisplayMember = "Status";
            this.comboBox_Status.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Status.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.comboBox_Status.FormattingEnabled = true;
            this.comboBox_Status.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.comboBox_Status.Location = new System.Drawing.Point(129, 77);
            this.comboBox_Status.Name = "comboBox_Status";
            this.comboBox_Status.Size = new System.Drawing.Size(244, 28);
            this.comboBox_Status.TabIndex = 2;
            this.comboBox_Status.ValueMember = "TMStatusID";
            // 
            // tMStatusTBindingSource
            // 
            this.tMStatusTBindingSource.DataMember = "TMStatusT";
            this.tMStatusTBindingSource.DataSource = this.dataSet_Drop;
            // 
            // txt_Content
            // 
            this.txt_Content.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.txt_Content.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txt_Content.Location = new System.Drawing.Point(129, 107);
            this.txt_Content.Multiline = true;
            this.txt_Content.Name = "txt_Content";
            this.txt_Content.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_Content.Size = new System.Drawing.Size(244, 44);
            this.txt_Content.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.label3.Location = new System.Drawing.Point(8, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 20);
            this.label3.TabIndex = 56;
            this.label3.Text = "對應的案件階段";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.label2.Location = new System.Drawing.Point(55, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 20);
            this.label2.TabIndex = 59;
            this.label2.Text = "事件內容";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.label11.Location = new System.Drawing.Point(399, 168);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(73, 20);
            this.label11.TabIndex = 67;
            this.label11.Text = "費用種類";
            this.label11.Visible = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.label10.Location = new System.Drawing.Point(406, 105);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(73, 20);
            this.label10.TabIndex = 66;
            this.label10.Text = "加減天數";
            this.label10.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.label9.Location = new System.Drawing.Point(422, 74);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(57, 20);
            this.label9.TabIndex = 69;
            this.label9.Text = "起算日";
            this.label9.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.label8.Location = new System.Drawing.Point(406, 47);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 20);
            this.label8.TabIndex = 68;
            this.label8.Text = "時間單位";
            this.label8.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.label7.Location = new System.Drawing.Point(422, 195);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 20);
            this.label7.TabIndex = 63;
            this.label7.Text = "答覆時間";
            this.label7.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.label6.Location = new System.Drawing.Point(389, 134);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(105, 20);
            this.label6.TabIndex = 64;
            this.label6.Text = "應答覆之程序";
            this.label6.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.label5.Location = new System.Drawing.Point(87, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 20);
            this.label5.TabIndex = 65;
            this.label5.Text = "國別";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.label1.Location = new System.Drawing.Point(87, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 20);
            this.label1.TabIndex = 61;
            this.label1.Text = "排序";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.numericUpDown1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.numericUpDown1.Location = new System.Drawing.Point(129, 45);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(244, 29);
            this.numericUpDown1.TabIndex = 1;
            // 
            // countryT_DropTableAdapter
            // 
            this.countryT_DropTableAdapter.ClearBeforeFill = true;
            // 
            // tMStatusTTableAdapter
            // 
            this.tMStatusTTableAdapter.ClearBeforeFill = true;
            // 
            // feePhaseTByTMTableAdapter
            // 
            this.feePhaseTByTMTableAdapter.ClearBeforeFill = true;
            // 
            // timeUnit_DropTableAdapter
            // 
            this.timeUnit_DropTableAdapter.ClearBeforeFill = true;
            // 
            // patStartDate_DropTableAdapter
            // 
            this.patStartDate_DropTableAdapter.ClearBeforeFill = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.label12.Location = new System.Drawing.Point(24, 157);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(105, 20);
            this.label12.TabIndex = 73;
            this.label12.Text = "指定作業流程";
            // 
            // cb_Process
            // 
            this.cb_Process.DataSource = this.trademarkProcessKindTBindingSource;
            this.cb_Process.DisplayMember = "ProcessKind";
            this.cb_Process.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Process.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.cb_Process.FormattingEnabled = true;
            this.cb_Process.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.cb_Process.Location = new System.Drawing.Point(129, 154);
            this.cb_Process.Name = "cb_Process";
            this.cb_Process.Size = new System.Drawing.Size(244, 28);
            this.cb_Process.TabIndex = 4;
            this.cb_Process.ValueMember = "ProcessKEY";
            // 
            // trademarkProcessKindTBindingSource
            // 
            this.trademarkProcessKindTBindingSource.DataMember = "TrademarkProcessKindT";
            this.trademarkProcessKindTBindingSource.DataSource = this.dataSet_Drop;
            // 
            // trademarkProcessKindTTableAdapter
            // 
            this.trademarkProcessKindTTableAdapter.ClearBeforeFill = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("微軟正黑體", 8F);
            this.label13.ForeColor = System.Drawing.Color.Firebrick;
            this.label13.Location = new System.Drawing.Point(130, 184);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(177, 15);
            this.label13.TabIndex = 75;
            this.label13.Text = "*沒有觸發的標準作業流程，可不選";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label14.ForeColor = System.Drawing.Color.Green;
            this.label14.Location = new System.Drawing.Point(228, 306);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(142, 17);
            this.label14.TabIndex = 1088;
            this.label14.Text = "Shift+Enter：換下一行";
            // 
            // AddTMNotifyDue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = global::LawtechPTSystem.Properties.Resources.bg1;
            this.CancelButton = this.button2;
            this.ClientSize = new System.Drawing.Size(391, 384);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.cb_Process);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBox_FeePhase);
            this.Controls.Add(this.comboBox_StartDate);
            this.Controls.Add(this.comboBox_TimeUnit);
            this.Controls.Add(this.numericUpDown_ASday);
            this.Controls.Add(this.numericUpDown_AnswerTime);
            this.Controls.Add(this.txt_Answer);
            this.Controls.Add(this.comboBox_country);
            this.Controls.Add(this.txt_Note);
            this.Controls.Add(this.comboBox_Status);
            this.Controls.Add(this.txt_Content);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericUpDown1);
            this.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddTMNotifyDue";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "新增商標事件內容";
            this.Load += new System.EventHandler(this.AddTMNotifyDue_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AddTMNotifyDue_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.feePhaseTByTMBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_Drop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.patStartDateDropBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qS_DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeUnitDropBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_ASday)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_AnswerTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.countryTDropBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tMStatusTBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trademarkProcessKindTBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBox_FeePhase;
        private System.Windows.Forms.ComboBox comboBox_StartDate;
        private System.Windows.Forms.ComboBox comboBox_TimeUnit;
        private System.Windows.Forms.NumericUpDown numericUpDown_ASday;
        private System.Windows.Forms.NumericUpDown numericUpDown_AnswerTime;
        private System.Windows.Forms.TextBox txt_Answer;
        private System.Windows.Forms.ComboBox comboBox_country;
        private System.Windows.Forms.TextBox txt_Note;
        private System.Windows.Forms.ComboBox comboBox_Status;
        private System.Windows.Forms.TextBox txt_Content;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private QS_DataSet qS_DataSet;
        private System.Windows.Forms.BindingSource countryTDropBindingSource;
        private LawtechPTSystem.QS_DataSetTableAdapters.CountryT_DropTableAdapter countryT_DropTableAdapter;
        private DataSet_Drop dataSet_Drop;
        private System.Windows.Forms.BindingSource tMStatusTBindingSource;
        private LawtechPTSystem.DataSet_DropTableAdapters.TMStatusTTableAdapter tMStatusTTableAdapter;
        private System.Windows.Forms.BindingSource feePhaseTByTMBindingSource;
        private LawtechPTSystem.DataSet_DropTableAdapters.FeePhaseTByTMTableAdapter feePhaseTByTMTableAdapter;
        private System.Windows.Forms.BindingSource timeUnitDropBindingSource;
        private LawtechPTSystem.QS_DataSetTableAdapters.TimeUnit_DropTableAdapter timeUnit_DropTableAdapter;
        private System.Windows.Forms.BindingSource patStartDateDropBindingSource;
        private LawtechPTSystem.QS_DataSetTableAdapters.PatStartDate_DropTableAdapter patStartDate_DropTableAdapter;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cb_Process;
        private System.Windows.Forms.BindingSource trademarkProcessKindTBindingSource;
        private LawtechPTSystem.DataSet_DropTableAdapters.TrademarkProcessKindTTableAdapter trademarkProcessKindTTableAdapter;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
    }
}