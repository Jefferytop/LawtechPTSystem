namespace LawtechPTSystem.AddFrom
{
    partial class AddTrademarkHandleProcess
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddTrademarkHandleProcess));
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.chkIsUsing = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.nudMinutes = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.nudHours = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.nudDays = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.cbStatus = new System.Windows.Forms.ComboBox();
            this.tMStatusTBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet_Drop = new LawtechPTSystem.DataSet_Drop();
            this.txtHandle = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDown_sort = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.tMStatusTTableAdapter = new LawtechPTSystem.DataSet_DropTableAdapters.TMStatusTTableAdapter();
            this.comboBox_DefultWorker = new System.Windows.Forms.ComboBox();
            this.workerTBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.workerTTableAdapter = new LawtechPTSystem.DataSet_DropTableAdapters.WorkerTTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.nudMinutes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHours)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDays)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tMStatusTBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_Drop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_sort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.workerTBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button2.BackgroundImage = global::LawtechPTSystem.Properties.Resources.btnCancel;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.button2.Location = new System.Drawing.Point(196, 328);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 32);
            this.button2.TabIndex = 52;
            this.button2.Text = "取消";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button1.BackgroundImage = global::LawtechPTSystem.Properties.Resources.btnComfirm;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.button1.Location = new System.Drawing.Point(90, 328);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 32);
            this.button1.TabIndex = 51;
            this.button1.Text = "確定";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // chkIsUsing
            // 
            this.chkIsUsing.AutoSize = true;
            this.chkIsUsing.Checked = true;
            this.chkIsUsing.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIsUsing.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.chkIsUsing.Location = new System.Drawing.Point(135, 288);
            this.chkIsUsing.Name = "chkIsUsing";
            this.chkIsUsing.Size = new System.Drawing.Size(68, 24);
            this.chkIsUsing.TabIndex = 50;
            this.chkIsUsing.Text = "啟  用";
            this.chkIsUsing.UseVisualStyleBackColor = true;
            this.chkIsUsing.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.label9.Location = new System.Drawing.Point(191, 256);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 20);
            this.label9.TabIndex = 48;
            this.label9.Text = "分鐘";
            // 
            // nudMinutes
            // 
            this.nudMinutes.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.nudMinutes.Location = new System.Drawing.Point(136, 253);
            this.nudMinutes.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.nudMinutes.Name = "nudMinutes";
            this.nudMinutes.Size = new System.Drawing.Size(52, 29);
            this.nudMinutes.TabIndex = 44;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.label8.Location = new System.Drawing.Point(191, 216);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 20);
            this.label8.TabIndex = 47;
            this.label8.Text = "小時";
            // 
            // nudHours
            // 
            this.nudHours.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.nudHours.Location = new System.Drawing.Point(136, 213);
            this.nudHours.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.nudHours.Name = "nudHours";
            this.nudHours.Size = new System.Drawing.Size(52, 29);
            this.nudHours.TabIndex = 43;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.label7.Location = new System.Drawing.Point(191, 177);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(25, 20);
            this.label7.TabIndex = 46;
            this.label7.Text = "天";
            // 
            // nudDays
            // 
            this.nudDays.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.nudDays.Location = new System.Drawing.Point(135, 174);
            this.nudDays.Maximum = new decimal(new int[] {
            365,
            0,
            0,
            0});
            this.nudDays.Name = "nudDays";
            this.nudDays.Size = new System.Drawing.Size(52, 29);
            this.nudDays.TabIndex = 42;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.label6.Location = new System.Drawing.Point(30, 180);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(105, 20);
            this.label6.TabIndex = 45;
            this.label6.Text = "預定工作天數";
            // 
            // cbStatus
            // 
            this.cbStatus.DataSource = this.tMStatusTBindingSource;
            this.cbStatus.DisplayMember = "Status";
            this.cbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStatus.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.cbStatus.FormattingEnabled = true;
            this.cbStatus.Location = new System.Drawing.Point(135, 92);
            this.cbStatus.Name = "cbStatus";
            this.cbStatus.Size = new System.Drawing.Size(229, 28);
            this.cbStatus.TabIndex = 40;
            this.cbStatus.ValueMember = "TMStatusID";
            // 
            // tMStatusTBindingSource
            // 
            this.tMStatusTBindingSource.DataMember = "TMStatusT";
            this.tMStatusTBindingSource.DataSource = this.dataSet_Drop;
            // 
            // dataSet_Drop
            // 
            this.dataSet_Drop.DataSetName = "DataSet_Drop";
            this.dataSet_Drop.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // txtHandle
            // 
            this.txtHandle.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.txtHandle.Location = new System.Drawing.Point(135, 56);
            this.txtHandle.Name = "txtHandle";
            this.txtHandle.Size = new System.Drawing.Size(229, 29);
            this.txtHandle.TabIndex = 39;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.label3.Location = new System.Drawing.Point(15, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 20);
            this.label3.TabIndex = 41;
            this.label3.Text = "對應的階段變化";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.label2.Location = new System.Drawing.Point(63, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 20);
            this.label2.TabIndex = 38;
            this.label2.Text = "處理程序";
            // 
            // numericUpDown_sort
            // 
            this.numericUpDown_sort.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.numericUpDown_sort.Location = new System.Drawing.Point(135, 20);
            this.numericUpDown_sort.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numericUpDown_sort.Name = "numericUpDown_sort";
            this.numericUpDown_sort.Size = new System.Drawing.Size(95, 29);
            this.numericUpDown_sort.TabIndex = 37;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.label1.Location = new System.Drawing.Point(95, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 20);
            this.label1.TabIndex = 36;
            this.label1.Text = "順序";
            // 
            // tMStatusTTableAdapter
            // 
            this.tMStatusTTableAdapter.ClearBeforeFill = true;
            // 
            // comboBox_DefultWorker
            // 
            this.comboBox_DefultWorker.DataSource = this.workerTBindingSource;
            this.comboBox_DefultWorker.DisplayMember = "FullEmployeeName";
            this.comboBox_DefultWorker.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_DefultWorker.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.comboBox_DefultWorker.FormattingEnabled = true;
            this.comboBox_DefultWorker.Location = new System.Drawing.Point(135, 126);
            this.comboBox_DefultWorker.Name = "comboBox_DefultWorker";
            this.comboBox_DefultWorker.Size = new System.Drawing.Size(229, 28);
            this.comboBox_DefultWorker.TabIndex = 53;
            this.comboBox_DefultWorker.ValueMember = "WorkerKey";
            // 
            // workerTBindingSource
            // 
            this.workerTBindingSource.DataMember = "WorkerT";
            this.workerTBindingSource.DataSource = this.dataSet_Drop;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.label4.Location = new System.Drawing.Point(31, 129);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 20);
            this.label4.TabIndex = 54;
            this.label4.Text = "預設處理人員";
            // 
            // workerTTableAdapter
            // 
            this.workerTTableAdapter.ClearBeforeFill = true;
            // 
            // AddTrademarkHandleProcess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = global::LawtechPTSystem.Properties.Resources.bg1;
            this.CancelButton = this.button2;
            this.ClientSize = new System.Drawing.Size(386, 375);
            this.Controls.Add(this.comboBox_DefultWorker);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.chkIsUsing);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.nudMinutes);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.nudHours);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.nudDays);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cbStatus);
            this.Controls.Add(this.txtHandle);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numericUpDown_sort);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddTrademarkHandleProcess";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "新增處理程序";
            this.Load += new System.EventHandler(this.AddTrademarkHandleProcess_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudMinutes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHours)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudDays)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tMStatusTBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_Drop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_sort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.workerTBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox chkIsUsing;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown nudMinutes;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown nudHours;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown nudDays;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbStatus;
        private System.Windows.Forms.TextBox txtHandle;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDown_sort;
        private System.Windows.Forms.Label label1;
        private DataSet_Drop dataSet_Drop;
        private System.Windows.Forms.BindingSource tMStatusTBindingSource;
        private LawtechPTSystem.DataSet_DropTableAdapters.TMStatusTTableAdapter tMStatusTTableAdapter;
        private System.Windows.Forms.ComboBox comboBox_DefultWorker;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.BindingSource workerTBindingSource;
        private DataSet_DropTableAdapters.WorkerTTableAdapter workerTTableAdapter;
    }
}