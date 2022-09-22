namespace LawtechPTSystemByFirm.AddFrom
{
    partial class AddNotifyDue
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該公開 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改這個方法的內容。
        ///
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.comboBox_FeePhase = new System.Windows.Forms.ComboBox();
            this.feePhaseTbyPatDropBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.qS_DataSet = new LawtechPTSystemByFirm.QS_DataSet();
            this.comboBox_StartDate = new System.Windows.Forms.ComboBox();
            this.patStartDateDropBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.comboBox_TimeUnit = new System.Windows.Forms.ComboBox();
            this.timeUnitDropBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.numericUpDown_ASday = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_AnswerTime = new System.Windows.Forms.NumericUpDown();
            this.txt_Answer = new System.Windows.Forms.TextBox();
            this.txt_Note = new System.Windows.Forms.TextBox();
            this.comboBox_Status = new System.Windows.Forms.ComboBox();
            this.patStatusTDropBindingSource = new System.Windows.Forms.BindingSource(this.components);
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
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.patStatusT_DropTableAdapter = new LawtechPTSystemByFirm.QS_DataSetTableAdapters.PatStatusT_DropTableAdapter();
            this.feePhaseTbyPat_DropTableAdapter = new LawtechPTSystemByFirm.QS_DataSetTableAdapters.FeePhaseTbyPat_DropTableAdapter();
            this.timeUnit_DropTableAdapter = new LawtechPTSystemByFirm.QS_DataSetTableAdapters.TimeUnit_DropTableAdapter();
            this.patStartDate_DropTableAdapter = new LawtechPTSystemByFirm.QS_DataSetTableAdapters.PatStartDate_DropTableAdapter();
            this.lab_CountryName = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.comboBox_ProcessKEY = new System.Windows.Forms.ComboBox();
            this.processKindTDropBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.processKindT_DropTableAdapter = new LawtechPTSystemByFirm.QS_DataSetTableAdapters.ProcessKindT_DropTableAdapter();
            this.label13 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.feePhaseTbyPatDropBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qS_DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.patStartDateDropBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeUnitDropBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_ASday)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_AnswerTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.patStatusTDropBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.processKindTDropBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBox_FeePhase
            // 
            this.comboBox_FeePhase.DataSource = this.feePhaseTbyPatDropBindingSource;
            this.comboBox_FeePhase.DisplayMember = "FeePhase";
            this.comboBox_FeePhase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_FeePhase.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.comboBox_FeePhase.FormattingEnabled = true;
            this.comboBox_FeePhase.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.comboBox_FeePhase.Location = new System.Drawing.Point(291, 328);
            this.comboBox_FeePhase.Name = "comboBox_FeePhase";
            this.comboBox_FeePhase.Size = new System.Drawing.Size(31, 28);
            this.comboBox_FeePhase.TabIndex = 30;
            this.comboBox_FeePhase.ValueMember = "FeePhaseID";
            this.comboBox_FeePhase.Visible = false;
            // 
            // feePhaseTbyPatDropBindingSource
            // 
            this.feePhaseTbyPatDropBindingSource.DataMember = "FeePhaseTbyPat_Drop";
            this.feePhaseTbyPatDropBindingSource.DataSource = this.qS_DataSet;
            // 
            // qS_DataSet
            // 
            this.qS_DataSet.DataSetName = "QS_DataSet";
            this.qS_DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // comboBox_StartDate
            // 
            this.comboBox_StartDate.DataSource = this.patStartDateDropBindingSource;
            this.comboBox_StartDate.DisplayMember = "SelectString";
            this.comboBox_StartDate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_StartDate.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.comboBox_StartDate.FormattingEnabled = true;
            this.comboBox_StartDate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.comboBox_StartDate.Location = new System.Drawing.Point(121, 200);
            this.comboBox_StartDate.Name = "comboBox_StartDate";
            this.comboBox_StartDate.Size = new System.Drawing.Size(205, 28);
            this.comboBox_StartDate.TabIndex = 35;
            this.comboBox_StartDate.ValueMember = "SelectValue";
            // 
            // patStartDateDropBindingSource
            // 
            this.patStartDateDropBindingSource.DataMember = "PatStartDate_Drop";
            this.patStartDateDropBindingSource.DataSource = this.qS_DataSet;
            // 
            // comboBox_TimeUnit
            // 
            this.comboBox_TimeUnit.DataSource = this.timeUnitDropBindingSource;
            this.comboBox_TimeUnit.DisplayMember = "SelectString";
            this.comboBox_TimeUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_TimeUnit.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.comboBox_TimeUnit.FormattingEnabled = true;
            this.comboBox_TimeUnit.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.comboBox_TimeUnit.Location = new System.Drawing.Point(263, 170);
            this.comboBox_TimeUnit.Name = "comboBox_TimeUnit";
            this.comboBox_TimeUnit.Size = new System.Drawing.Size(59, 28);
            this.comboBox_TimeUnit.TabIndex = 33;
            this.comboBox_TimeUnit.ValueMember = "SelectValue";
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
            this.numericUpDown_ASday.Location = new System.Drawing.Point(84, 282);
            this.numericUpDown_ASday.Maximum = new decimal(new int[] {
            365,
            0,
            0,
            0});
            this.numericUpDown_ASday.Name = "numericUpDown_ASday";
            this.numericUpDown_ASday.Size = new System.Drawing.Size(34, 29);
            this.numericUpDown_ASday.TabIndex = 37;
            this.numericUpDown_ASday.Visible = false;
            // 
            // numericUpDown_AnswerTime
            // 
            this.numericUpDown_AnswerTime.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.numericUpDown_AnswerTime.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.numericUpDown_AnswerTime.Location = new System.Drawing.Point(121, 167);
            this.numericUpDown_AnswerTime.Maximum = new decimal(new int[] {
            365,
            0,
            0,
            0});
            this.numericUpDown_AnswerTime.Name = "numericUpDown_AnswerTime";
            this.numericUpDown_AnswerTime.Size = new System.Drawing.Size(140, 29);
            this.numericUpDown_AnswerTime.TabIndex = 32;
            // 
            // txt_Answer
            // 
            this.txt_Answer.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.txt_Answer.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txt_Answer.Location = new System.Drawing.Point(121, 134);
            this.txt_Answer.Name = "txt_Answer";
            this.txt_Answer.Size = new System.Drawing.Size(205, 29);
            this.txt_Answer.TabIndex = 29;
            // 
            // txt_Note
            // 
            this.txt_Note.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.txt_Note.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txt_Note.Location = new System.Drawing.Point(121, 262);
            this.txt_Note.Multiline = true;
            this.txt_Note.Name = "txt_Note";
            this.txt_Note.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_Note.Size = new System.Drawing.Size(206, 105);
            this.txt_Note.TabIndex = 27;
            // 
            // comboBox_Status
            // 
            this.comboBox_Status.DataSource = this.patStatusTDropBindingSource;
            this.comboBox_Status.DisplayMember = "Status";
            this.comboBox_Status.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Status.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.comboBox_Status.FormattingEnabled = true;
            this.comboBox_Status.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.comboBox_Status.Location = new System.Drawing.Point(121, 104);
            this.comboBox_Status.Name = "comboBox_Status";
            this.comboBox_Status.Size = new System.Drawing.Size(204, 28);
            this.comboBox_Status.TabIndex = 26;
            this.comboBox_Status.ValueMember = "StatusID";
            // 
            // patStatusTDropBindingSource
            // 
            this.patStatusTDropBindingSource.DataMember = "PatStatusT-Drop";
            this.patStatusTDropBindingSource.DataSource = this.qS_DataSet;
            // 
            // txt_Content
            // 
            this.txt_Content.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.txt_Content.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txt_Content.Location = new System.Drawing.Point(121, 73);
            this.txt_Content.Name = "txt_Content";
            this.txt_Content.Size = new System.Drawing.Size(204, 29);
            this.txt_Content.TabIndex = 25;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.label3.Location = new System.Drawing.Point(48, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 20);
            this.label3.TabIndex = 31;
            this.label3.Text = "狀態變化";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.label2.Location = new System.Drawing.Point(48, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 20);
            this.label2.TabIndex = 34;
            this.label2.Text = "來函內容";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.label11.Location = new System.Drawing.Point(222, 331);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(73, 20);
            this.label11.TabIndex = 42;
            this.label11.Text = "費用種類";
            this.label11.Visible = false;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.label10.Location = new System.Drawing.Point(11, 288);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(73, 20);
            this.label10.TabIndex = 41;
            this.label10.Text = "加減天數";
            this.label10.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.label9.Location = new System.Drawing.Point(65, 203);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(57, 20);
            this.label9.TabIndex = 44;
            this.label9.Text = "起算日";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.label8.Location = new System.Drawing.Point(32, 312);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 20);
            this.label8.TabIndex = 43;
            this.label8.Text = "時間單位";
            this.label8.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.label7.Location = new System.Drawing.Point(49, 170);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 20);
            this.label7.TabIndex = 38;
            this.label7.Text = "答覆時間";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.label6.Location = new System.Drawing.Point(17, 138);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(105, 20);
            this.label6.TabIndex = 39;
            this.label6.Text = "應答覆之程序";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.label5.Location = new System.Drawing.Point(81, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 20);
            this.label5.TabIndex = 40;
            this.label5.Text = "國別";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.label1.Location = new System.Drawing.Point(80, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 20);
            this.label1.TabIndex = 36;
            this.label1.Text = "排序";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.numericUpDown1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.numericUpDown1.Location = new System.Drawing.Point(121, 41);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(204, 29);
            this.numericUpDown1.TabIndex = 24;
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button2.BackgroundImage = global::LawtechPTSystemByFirm.Properties.Resources.btnCancel;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button2.Location = new System.Drawing.Point(179, 391);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 32);
            this.button2.TabIndex = 47;
            this.button2.Text = "取消";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button1.BackgroundImage = global::LawtechPTSystemByFirm.Properties.Resources.btnComfirm;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button1.Location = new System.Drawing.Point(71, 391);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 32);
            this.button1.TabIndex = 46;
            this.button1.Text = "確定";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.label4.Location = new System.Drawing.Point(50, 266);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 20);
            this.label4.TabIndex = 48;
            this.label4.Text = "提醒訊息";
            // 
            // patStatusT_DropTableAdapter
            // 
            this.patStatusT_DropTableAdapter.ClearBeforeFill = true;
            // 
            // feePhaseTbyPat_DropTableAdapter
            // 
            this.feePhaseTbyPat_DropTableAdapter.ClearBeforeFill = true;
            // 
            // timeUnit_DropTableAdapter
            // 
            this.timeUnit_DropTableAdapter.ClearBeforeFill = true;
            // 
            // patStartDate_DropTableAdapter
            // 
            this.patStartDate_DropTableAdapter.ClearBeforeFill = true;
            // 
            // lab_CountryName
            // 
            this.lab_CountryName.AutoSize = true;
            this.lab_CountryName.BackColor = System.Drawing.Color.Transparent;
            this.lab_CountryName.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.lab_CountryName.ForeColor = System.Drawing.Color.Blue;
            this.lab_CountryName.Location = new System.Drawing.Point(119, 19);
            this.lab_CountryName.Name = "lab_CountryName";
            this.lab_CountryName.Size = new System.Drawing.Size(41, 20);
            this.lab_CountryName.TabIndex = 49;
            this.lab_CountryName.Text = "國別";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.label12.Location = new System.Drawing.Point(2, 233);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(121, 20);
            this.label12.TabIndex = 50;
            this.label12.Text = "預設的作業流程";
            // 
            // comboBox_ProcessKEY
            // 
            this.comboBox_ProcessKEY.DataSource = this.processKindTDropBindingSource;
            this.comboBox_ProcessKEY.DisplayMember = "ProcessKind";
            this.comboBox_ProcessKEY.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_ProcessKEY.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.comboBox_ProcessKEY.FormattingEnabled = true;
            this.comboBox_ProcessKEY.Location = new System.Drawing.Point(121, 230);
            this.comboBox_ProcessKEY.Name = "comboBox_ProcessKEY";
            this.comboBox_ProcessKEY.Size = new System.Drawing.Size(205, 28);
            this.comboBox_ProcessKEY.TabIndex = 51;
            this.comboBox_ProcessKEY.ValueMember = "ProcessKEY";
            // 
            // processKindTDropBindingSource
            // 
            this.processKindTDropBindingSource.DataMember = "ProcessKindT-Drop";
            this.processKindTDropBindingSource.DataSource = this.qS_DataSet;
            // 
            // processKindT_DropTableAdapter
            // 
            this.processKindT_DropTableAdapter.ClearBeforeFill = true;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label13.ForeColor = System.Drawing.Color.Green;
            this.label13.Location = new System.Drawing.Point(185, 370);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(142, 17);
            this.label13.TabIndex = 1088;
            this.label13.Text = "Shift+Enter：換下一行";
            // 
            // AddNotifyDue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::LawtechPTSystemByFirm.Properties.Resources.bg1;
            this.CancelButton = this.button2;
            this.ClientSize = new System.Drawing.Size(350, 436);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.comboBox_ProcessKEY);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.lab_CountryName);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBox_FeePhase);
            this.Controls.Add(this.comboBox_StartDate);
            this.Controls.Add(this.comboBox_TimeUnit);
            this.Controls.Add(this.numericUpDown_ASday);
            this.Controls.Add(this.numericUpDown_AnswerTime);
            this.Controls.Add(this.txt_Answer);
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
            this.Controls.Add(this.label4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddNotifyDue";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "新增專利期限來函設定";
            this.Load += new System.EventHandler(this.AddNotifyDue_Load);
            ((System.ComponentModel.ISupportInitialize)(this.feePhaseTbyPatDropBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qS_DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.patStartDateDropBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeUnitDropBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_ASday)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_AnswerTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.patStatusTDropBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.processKindTDropBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox_FeePhase;
        private System.Windows.Forms.ComboBox comboBox_StartDate;
        private System.Windows.Forms.ComboBox comboBox_TimeUnit;
        private System.Windows.Forms.NumericUpDown numericUpDown_ASday;
        private System.Windows.Forms.NumericUpDown numericUpDown_AnswerTime;
        private System.Windows.Forms.TextBox txt_Answer;
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
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private QS_DataSet qS_DataSet;
        private System.Windows.Forms.BindingSource patStatusTDropBindingSource;
        private LawtechPTSystemByFirm.QS_DataSetTableAdapters.PatStatusT_DropTableAdapter patStatusT_DropTableAdapter;
        private System.Windows.Forms.BindingSource feePhaseTbyPatDropBindingSource;
        private LawtechPTSystemByFirm.QS_DataSetTableAdapters.FeePhaseTbyPat_DropTableAdapter feePhaseTbyPat_DropTableAdapter;
        private System.Windows.Forms.BindingSource timeUnitDropBindingSource;
        private LawtechPTSystemByFirm.QS_DataSetTableAdapters.TimeUnit_DropTableAdapter timeUnit_DropTableAdapter;
        private System.Windows.Forms.BindingSource patStartDateDropBindingSource;
        private LawtechPTSystemByFirm.QS_DataSetTableAdapters.PatStartDate_DropTableAdapter patStartDate_DropTableAdapter;
        private System.Windows.Forms.Label lab_CountryName;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox comboBox_ProcessKEY;
        private System.Windows.Forms.BindingSource processKindTDropBindingSource;
        private LawtechPTSystemByFirm.QS_DataSetTableAdapters.ProcessKindT_DropTableAdapter processKindT_DropTableAdapter;
        private System.Windows.Forms.Label label13;
    }
}