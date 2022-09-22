namespace LawtechPTSystem.EditForm
{
    partial class EditPatentWorkEvent
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditPatentWorkEvent));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_WorkContent = new System.Windows.Forms.TextBox();
            this.comboBox_Worker = new System.Windows.Forms.ComboBox();
            this.workerTAllBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.qS_DataSet = new LawtechPTSystem.QS_DataSet();
            this.maskedTextBox_WorkDate = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBox_StartTime = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBox_EndTime = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBox_EstimateDateTime = new System.Windows.Forms.MaskedTextBox();
            this.txt_Memo = new System.Windows.Forms.TextBox();
            this.but_Cancel = new System.Windows.Forms.Button();
            this.but_OK = new System.Windows.Forms.Button();
            this.workerTAllTableAdapter = new LawtechPTSystem.QS_DataSetTableAdapters.WorkerTAllTableAdapter();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_AllTime = new System.Windows.Forms.TextBox();
            this.checkBox_IsStart = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.workerTAllBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qS_DataSet)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(72, 53);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "承辦人";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(54, 22);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "工作內容";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(53, 84);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "發生時間";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(307, 27);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "結束時間";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(43, 26);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "開工時間";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(290, 84);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(105, 20);
            this.label7.TabIndex = 6;
            this.label7.Text = "預計完成時間";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Location = new System.Drawing.Point(76, 220);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 20);
            this.label8.TabIndex = 7;
            this.label8.Text = "備   註";
            // 
            // txt_WorkContent
            // 
            this.txt_WorkContent.Location = new System.Drawing.Point(128, 17);
            this.txt_WorkContent.Name = "txt_WorkContent";
            this.txt_WorkContent.Size = new System.Drawing.Size(402, 29);
            this.txt_WorkContent.TabIndex = 0;
            // 
            // comboBox_Worker
            // 
            this.comboBox_Worker.DataSource = this.workerTAllBindingSource;
            this.comboBox_Worker.DisplayMember = "Name";
            this.comboBox_Worker.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Worker.FormattingEnabled = true;
            this.comboBox_Worker.Location = new System.Drawing.Point(128, 50);
            this.comboBox_Worker.Name = "comboBox_Worker";
            this.comboBox_Worker.Size = new System.Drawing.Size(137, 28);
            this.comboBox_Worker.TabIndex = 1;
            this.comboBox_Worker.ValueMember = "WorkerKey";
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
            // maskedTextBox_WorkDate
            // 
            this.maskedTextBox_WorkDate.ForeColor = System.Drawing.Color.Green;
            this.maskedTextBox_WorkDate.ImeMode = System.Windows.Forms.ImeMode.Close;
            this.maskedTextBox_WorkDate.Location = new System.Drawing.Point(128, 80);
            this.maskedTextBox_WorkDate.Mask = "0000/00/00 00:00";
            this.maskedTextBox_WorkDate.Name = "maskedTextBox_WorkDate";
            this.maskedTextBox_WorkDate.Size = new System.Drawing.Size(137, 29);
            this.maskedTextBox_WorkDate.TabIndex = 2;
            this.maskedTextBox_WorkDate.DoubleClick += new System.EventHandler(this.maskedTextBox_WorkDate_DoubleClick);
            // 
            // maskedTextBox_StartTime
            // 
            this.maskedTextBox_StartTime.ForeColor = System.Drawing.Color.Green;
            this.maskedTextBox_StartTime.ImeMode = System.Windows.Forms.ImeMode.Close;
            this.maskedTextBox_StartTime.Location = new System.Drawing.Point(116, 22);
            this.maskedTextBox_StartTime.Mask = "0000/00/00 00:00";
            this.maskedTextBox_StartTime.Name = "maskedTextBox_StartTime";
            this.maskedTextBox_StartTime.Size = new System.Drawing.Size(137, 29);
            this.maskedTextBox_StartTime.TabIndex = 0;
            this.maskedTextBox_StartTime.DoubleClick += new System.EventHandler(this.maskedTextBox_WorkDate_DoubleClick);
            this.maskedTextBox_StartTime.Leave += new System.EventHandler(this.maskedTextBox_StartTime_Leave);
            // 
            // maskedTextBox_EndTime
            // 
            this.maskedTextBox_EndTime.ForeColor = System.Drawing.Color.Green;
            this.maskedTextBox_EndTime.ImeMode = System.Windows.Forms.ImeMode.Close;
            this.maskedTextBox_EndTime.Location = new System.Drawing.Point(384, 22);
            this.maskedTextBox_EndTime.Mask = "0000/00/00 00:00";
            this.maskedTextBox_EndTime.Name = "maskedTextBox_EndTime";
            this.maskedTextBox_EndTime.Size = new System.Drawing.Size(134, 29);
            this.maskedTextBox_EndTime.TabIndex = 1;
            this.maskedTextBox_EndTime.DoubleClick += new System.EventHandler(this.maskedTextBox_WorkDate_DoubleClick);
            this.maskedTextBox_EndTime.Leave += new System.EventHandler(this.maskedTextBox_StartTime_Leave);
            // 
            // maskedTextBox_EstimateDateTime
            // 
            this.maskedTextBox_EstimateDateTime.ForeColor = System.Drawing.Color.Green;
            this.maskedTextBox_EstimateDateTime.ImeMode = System.Windows.Forms.ImeMode.Close;
            this.maskedTextBox_EstimateDateTime.Location = new System.Drawing.Point(396, 80);
            this.maskedTextBox_EstimateDateTime.Mask = "0000/00/00 00:00";
            this.maskedTextBox_EstimateDateTime.Name = "maskedTextBox_EstimateDateTime";
            this.maskedTextBox_EstimateDateTime.Size = new System.Drawing.Size(137, 29);
            this.maskedTextBox_EstimateDateTime.TabIndex = 3;
            this.maskedTextBox_EstimateDateTime.DoubleClick += new System.EventHandler(this.maskedTextBox_WorkDate_DoubleClick);
            // 
            // txt_Memo
            // 
            this.txt_Memo.Location = new System.Drawing.Point(128, 217);
            this.txt_Memo.Multiline = true;
            this.txt_Memo.Name = "txt_Memo";
            this.txt_Memo.Size = new System.Drawing.Size(402, 75);
            this.txt_Memo.TabIndex = 5;
            // 
            // but_Cancel
            // 
            this.but_Cancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.but_Cancel.BackgroundImage = global::LawtechPTSystem.Properties.Resources.btnCancel;
            this.but_Cancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.but_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.but_Cancel.Location = new System.Drawing.Point(283, 302);
            this.but_Cancel.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.but_Cancel.Name = "but_Cancel";
            this.but_Cancel.Size = new System.Drawing.Size(100, 32);
            this.but_Cancel.TabIndex = 7;
            this.but_Cancel.Text = "取消";
            this.but_Cancel.UseVisualStyleBackColor = true;
            this.but_Cancel.Click += new System.EventHandler(this.but_Cancel_Click);
            // 
            // but_OK
            // 
            this.but_OK.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.but_OK.BackgroundImage = global::LawtechPTSystem.Properties.Resources.btnComfirm;
            this.but_OK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.but_OK.Location = new System.Drawing.Point(171, 302);
            this.but_OK.Margin = new System.Windows.Forms.Padding(6, 5, 6, 5);
            this.but_OK.Name = "but_OK";
            this.but_OK.Size = new System.Drawing.Size(100, 32);
            this.but_OK.TabIndex = 6;
            this.but_OK.Text = "確定";
            this.but_OK.UseVisualStyleBackColor = true;
            this.but_OK.Click += new System.EventHandler(this.but_OK_Click);
            // 
            // workerTAllTableAdapter
            // 
            this.workerTAllTableAdapter.ClearBeforeFill = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(307, 59);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 20);
            this.label6.TabIndex = 463;
            this.label6.Text = "花費時間";
            // 
            // txt_AllTime
            // 
            this.txt_AllTime.BackColor = System.Drawing.Color.White;
            this.txt_AllTime.ForeColor = System.Drawing.Color.DarkCyan;
            this.txt_AllTime.Location = new System.Drawing.Point(384, 55);
            this.txt_AllTime.Name = "txt_AllTime";
            this.txt_AllTime.ReadOnly = true;
            this.txt_AllTime.Size = new System.Drawing.Size(134, 29);
            this.txt_AllTime.TabIndex = 2;
            // 
            // checkBox_IsStart
            // 
            this.checkBox_IsStart.AutoSize = true;
            this.checkBox_IsStart.Location = new System.Drawing.Point(24, 124);
            this.checkBox_IsStart.Name = "checkBox_IsStart";
            this.checkBox_IsStart.Size = new System.Drawing.Size(15, 14);
            this.checkBox_IsStart.TabIndex = 465;
            this.checkBox_IsStart.UseVisualStyleBackColor = true;
            this.checkBox_IsStart.CheckedChanged += new System.EventHandler(this.checkBox_IsStart_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.maskedTextBox_StartTime);
            this.groupBox1.Controls.Add(this.txt_AllTime);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.maskedTextBox_EndTime);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Enabled = false;
            this.groupBox1.Location = new System.Drawing.Point(12, 120);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(530, 91);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "     是否開始";
            // 
            // EditPatentWorkEvent
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = global::LawtechPTSystem.Properties.Resources.EditForm_bg;
            this.CancelButton = this.but_Cancel;
            this.ClientSize = new System.Drawing.Size(554, 344);
            this.Controls.Add(this.checkBox_IsStart);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.but_Cancel);
            this.Controls.Add(this.but_OK);
            this.Controls.Add(this.txt_Memo);
            this.Controls.Add(this.maskedTextBox_WorkDate);
            this.Controls.Add(this.comboBox_Worker);
            this.Controls.Add(this.txt_WorkContent);
            this.Controls.Add(this.maskedTextBox_EstimateDateTime);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditPatentWorkEvent";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "編輯待處理作業";
            this.Load += new System.EventHandler(this.EditPatentWorkEvent_Load);
            ((System.ComponentModel.ISupportInitialize)(this.workerTAllBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qS_DataSet)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_WorkContent;
        private System.Windows.Forms.ComboBox comboBox_Worker;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_WorkDate;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_StartTime;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_EndTime;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_EstimateDateTime;
        private System.Windows.Forms.TextBox txt_Memo;
        internal System.Windows.Forms.Button but_Cancel;
        internal System.Windows.Forms.Button but_OK;
        private QS_DataSet qS_DataSet;
        private System.Windows.Forms.BindingSource workerTAllBindingSource;
        private LawtechPTSystem.QS_DataSetTableAdapters.WorkerTAllTableAdapter workerTAllTableAdapter;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_AllTime;
        private System.Windows.Forms.CheckBox checkBox_IsStart;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}