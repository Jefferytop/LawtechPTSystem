namespace LawtechPTSystem.EditForm
{
    partial class EditTrademarkWorkEvent
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditTrademarkWorkEvent));
            this.checkBox_IsStart = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.maskedTextBox_StartTime = new System.Windows.Forms.MaskedTextBox();
            this.txt_AllTime = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.maskedTextBox_EndTime = new System.Windows.Forms.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.but_Cancel = new System.Windows.Forms.Button();
            this.but_OK = new System.Windows.Forms.Button();
            this.txt_Memo = new System.Windows.Forms.TextBox();
            this.maskedTextBox_WorkDate = new System.Windows.Forms.MaskedTextBox();
            this.comboBox_Worker = new System.Windows.Forms.ComboBox();
            this.workerTAllBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.qS_DataSet = new LawtechPTSystem.QS_DataSet();
            this.txt_WorkContent = new System.Windows.Forms.TextBox();
            this.maskedTextBox_EstimateDateTime = new System.Windows.Forms.MaskedTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.workerTAllTableAdapter = new LawtechPTSystem.QS_DataSetTableAdapters.WorkerTAllTableAdapter();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.workerTAllBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qS_DataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // checkBox_IsStart
            // 
            this.checkBox_IsStart.AutoSize = true;
            this.checkBox_IsStart.Location = new System.Drawing.Point(27, 111);
            this.checkBox_IsStart.Name = "checkBox_IsStart";
            this.checkBox_IsStart.Size = new System.Drawing.Size(15, 14);
            this.checkBox_IsStart.TabIndex = 479;
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
            this.groupBox1.Location = new System.Drawing.Point(15, 108);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(530, 83);
            this.groupBox1.TabIndex = 480;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "     是否開始";
            // 
            // maskedTextBox_StartTime
            // 
            this.maskedTextBox_StartTime.ForeColor = System.Drawing.Color.Green;
            this.maskedTextBox_StartTime.ImeMode = System.Windows.Forms.ImeMode.Close;
            this.maskedTextBox_StartTime.Location = new System.Drawing.Point(116, 20);
            this.maskedTextBox_StartTime.Margin = new System.Windows.Forms.Padding(1);
            this.maskedTextBox_StartTime.Mask = "0000/00/00 00:00";
            this.maskedTextBox_StartTime.Name = "maskedTextBox_StartTime";
            this.maskedTextBox_StartTime.Size = new System.Drawing.Size(137, 29);
            this.maskedTextBox_StartTime.TabIndex = 456;
            this.maskedTextBox_StartTime.DoubleClick += new System.EventHandler(this.maskedTextBox_WorkDate_DoubleClick);
            this.maskedTextBox_StartTime.Leave += new System.EventHandler(this.maskedTextBox_StartTime_Leave);
            // 
            // txt_AllTime
            // 
            this.txt_AllTime.BackColor = System.Drawing.Color.White;
            this.txt_AllTime.ForeColor = System.Drawing.Color.DarkCyan;
            this.txt_AllTime.Location = new System.Drawing.Point(384, 51);
            this.txt_AllTime.Margin = new System.Windows.Forms.Padding(1);
            this.txt_AllTime.Name = "txt_AllTime";
            this.txt_AllTime.ReadOnly = true;
            this.txt_AllTime.Size = new System.Drawing.Size(134, 29);
            this.txt_AllTime.TabIndex = 464;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(307, 55);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 20);
            this.label6.TabIndex = 463;
            this.label6.Text = "花費時間";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(43, 24);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "開工時間";
            // 
            // maskedTextBox_EndTime
            // 
            this.maskedTextBox_EndTime.ForeColor = System.Drawing.Color.Green;
            this.maskedTextBox_EndTime.ImeMode = System.Windows.Forms.ImeMode.Close;
            this.maskedTextBox_EndTime.Location = new System.Drawing.Point(384, 20);
            this.maskedTextBox_EndTime.Margin = new System.Windows.Forms.Padding(1);
            this.maskedTextBox_EndTime.Mask = "0000/00/00 00:00";
            this.maskedTextBox_EndTime.Name = "maskedTextBox_EndTime";
            this.maskedTextBox_EndTime.Size = new System.Drawing.Size(134, 29);
            this.maskedTextBox_EndTime.TabIndex = 457;
            this.maskedTextBox_EndTime.DoubleClick += new System.EventHandler(this.maskedTextBox_WorkDate_DoubleClick);
            this.maskedTextBox_EndTime.Leave += new System.EventHandler(this.maskedTextBox_StartTime_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(307, 25);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "結束時間";
            // 
            // but_Cancel
            // 
            this.but_Cancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.but_Cancel.BackgroundImage = global::LawtechPTSystem.Properties.Resources.btnCancel;
            this.but_Cancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.but_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.but_Cancel.Location = new System.Drawing.Point(282, 287);
            this.but_Cancel.Margin = new System.Windows.Forms.Padding(1);
            this.but_Cancel.Name = "but_Cancel";
            this.but_Cancel.Size = new System.Drawing.Size(100, 32);
            this.but_Cancel.TabIndex = 478;
            this.but_Cancel.Text = "取消";
            this.but_Cancel.UseVisualStyleBackColor = true;
            this.but_Cancel.Click += new System.EventHandler(this.but_Cancel_Click);
            // 
            // but_OK
            // 
            this.but_OK.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.but_OK.BackgroundImage = global::LawtechPTSystem.Properties.Resources.btnComfirm;
            this.but_OK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.but_OK.Location = new System.Drawing.Point(180, 287);
            this.but_OK.Margin = new System.Windows.Forms.Padding(1);
            this.but_OK.Name = "but_OK";
            this.but_OK.Size = new System.Drawing.Size(100, 32);
            this.but_OK.TabIndex = 477;
            this.but_OK.Text = "確定";
            this.but_OK.UseVisualStyleBackColor = true;
            this.but_OK.Click += new System.EventHandler(this.but_OK_Click);
            // 
            // txt_Memo
            // 
            this.txt_Memo.Location = new System.Drawing.Point(131, 197);
            this.txt_Memo.Multiline = true;
            this.txt_Memo.Name = "txt_Memo";
            this.txt_Memo.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_Memo.Size = new System.Drawing.Size(402, 86);
            this.txt_Memo.TabIndex = 476;
            // 
            // maskedTextBox_WorkDate
            // 
            this.maskedTextBox_WorkDate.ForeColor = System.Drawing.Color.Green;
            this.maskedTextBox_WorkDate.ImeMode = System.Windows.Forms.ImeMode.Close;
            this.maskedTextBox_WorkDate.Location = new System.Drawing.Point(131, 73);
            this.maskedTextBox_WorkDate.Margin = new System.Windows.Forms.Padding(1);
            this.maskedTextBox_WorkDate.Mask = "0000/00/00 00:00";
            this.maskedTextBox_WorkDate.Name = "maskedTextBox_WorkDate";
            this.maskedTextBox_WorkDate.Size = new System.Drawing.Size(137, 29);
            this.maskedTextBox_WorkDate.TabIndex = 474;
            this.maskedTextBox_WorkDate.DoubleClick += new System.EventHandler(this.maskedTextBox_WorkDate_DoubleClick);
            // 
            // comboBox_Worker
            // 
            this.comboBox_Worker.DataSource = this.workerTAllBindingSource;
            this.comboBox_Worker.DisplayMember = "Name";
            this.comboBox_Worker.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Worker.FormattingEnabled = true;
            this.comboBox_Worker.Location = new System.Drawing.Point(131, 43);
            this.comboBox_Worker.Margin = new System.Windows.Forms.Padding(1);
            this.comboBox_Worker.Name = "comboBox_Worker";
            this.comboBox_Worker.Size = new System.Drawing.Size(137, 28);
            this.comboBox_Worker.TabIndex = 473;
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
            // txt_WorkContent
            // 
            this.txt_WorkContent.Location = new System.Drawing.Point(131, 12);
            this.txt_WorkContent.Margin = new System.Windows.Forms.Padding(1);
            this.txt_WorkContent.Name = "txt_WorkContent";
            this.txt_WorkContent.Size = new System.Drawing.Size(402, 29);
            this.txt_WorkContent.TabIndex = 472;
            // 
            // maskedTextBox_EstimateDateTime
            // 
            this.maskedTextBox_EstimateDateTime.ForeColor = System.Drawing.Color.Green;
            this.maskedTextBox_EstimateDateTime.ImeMode = System.Windows.Forms.ImeMode.Close;
            this.maskedTextBox_EstimateDateTime.Location = new System.Drawing.Point(399, 71);
            this.maskedTextBox_EstimateDateTime.Margin = new System.Windows.Forms.Padding(1);
            this.maskedTextBox_EstimateDateTime.Mask = "0000/00/00 00:00";
            this.maskedTextBox_EstimateDateTime.Name = "maskedTextBox_EstimateDateTime";
            this.maskedTextBox_EstimateDateTime.Size = new System.Drawing.Size(137, 29);
            this.maskedTextBox_EstimateDateTime.TabIndex = 475;
            this.maskedTextBox_EstimateDateTime.DoubleClick += new System.EventHandler(this.maskedTextBox_WorkDate_DoubleClick);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(293, 75);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(105, 20);
            this.label7.TabIndex = 470;
            this.label7.Text = "預計完成時間";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Location = new System.Drawing.Point(79, 200);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 20);
            this.label8.TabIndex = 471;
            this.label8.Text = "備   註";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(25, 77);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 20);
            this.label3.TabIndex = 469;
            this.label3.Text = "作業發生時間";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(27, 15);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 20);
            this.label2.TabIndex = 468;
            this.label2.Text = "作業工作內容";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(75, 46);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 20);
            this.label1.TabIndex = 467;
            this.label1.Text = "承辦人";
            // 
            // workerTAllTableAdapter
            // 
            this.workerTAllTableAdapter.ClearBeforeFill = true;
            // 
            // EditTrademarkWorkEvent
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = global::LawtechPTSystem.Properties.Resources.EditForm_bg;
            this.CancelButton = this.but_Cancel;
            this.ClientSize = new System.Drawing.Size(563, 333);
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
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditTrademarkWorkEvent";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "編輯待處理明細";
            this.Load += new System.EventHandler(this.EditTrademarkWorkEvent_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.workerTAllBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qS_DataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBox_IsStart;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_StartTime;
        private System.Windows.Forms.TextBox txt_AllTime;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_EndTime;
        private System.Windows.Forms.Label label4;
        internal System.Windows.Forms.Button but_Cancel;
        internal System.Windows.Forms.Button but_OK;
        private System.Windows.Forms.TextBox txt_Memo;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_WorkDate;
        private System.Windows.Forms.ComboBox comboBox_Worker;
        private System.Windows.Forms.TextBox txt_WorkContent;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_EstimateDateTime;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private QS_DataSet qS_DataSet;
        private System.Windows.Forms.BindingSource workerTAllBindingSource;
        private LawtechPTSystem.QS_DataSetTableAdapters.WorkerTAllTableAdapter workerTAllTableAdapter;
    }
}