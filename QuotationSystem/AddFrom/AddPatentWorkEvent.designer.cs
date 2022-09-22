namespace LawtechPTSystem.AddFrom
{
    partial class AddPatentWorkEvent
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddPatentWorkEvent));
            this.but_Cancel = new System.Windows.Forms.Button();
            this.but_OK = new System.Windows.Forms.Button();
            this.txt_Memo = new System.Windows.Forms.TextBox();
            this.maskedTextBox_EstimateDateTime = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBox_StartTime = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBox_WorkDate = new System.Windows.Forms.MaskedTextBox();
            this.comboBox_Worker = new System.Windows.Forms.ComboBox();
            this.workerQuitNBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.qS_DataSet = new LawtechPTSystem.QS_DataSet();
            this.txt_WorkContent = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.worker_QuitNTableAdapter = new LawtechPTSystem.QS_DataSetTableAdapters.Worker_QuitNTableAdapter();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.workerQuitNBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qS_DataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // but_Cancel
            // 
            this.but_Cancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.but_Cancel.BackgroundImage = global::LawtechPTSystem.Properties.Resources.btnCancel;
            this.but_Cancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.but_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.but_Cancel.Location = new System.Drawing.Point(304, 216);
            this.but_Cancel.Margin = new System.Windows.Forms.Padding(1);
            this.but_Cancel.Name = "but_Cancel";
            this.but_Cancel.Size = new System.Drawing.Size(100, 32);
            this.but_Cancel.TabIndex = 480;
            this.but_Cancel.Text = "取消";
            this.but_Cancel.UseVisualStyleBackColor = true;
            this.but_Cancel.Click += new System.EventHandler(this.but_Cancel_Click);
            // 
            // but_OK
            // 
            this.but_OK.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.but_OK.BackgroundImage = global::LawtechPTSystem.Properties.Resources.btnComfirm;
            this.but_OK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.but_OK.Location = new System.Drawing.Point(202, 216);
            this.but_OK.Margin = new System.Windows.Forms.Padding(1);
            this.but_OK.Name = "but_OK";
            this.but_OK.Size = new System.Drawing.Size(100, 32);
            this.but_OK.TabIndex = 479;
            this.but_OK.Text = "確定";
            this.but_OK.UseVisualStyleBackColor = true;
            this.but_OK.Click += new System.EventHandler(this.but_OK_Click);
            // 
            // txt_Memo
            // 
            this.txt_Memo.Location = new System.Drawing.Point(119, 108);
            this.txt_Memo.Multiline = true;
            this.txt_Memo.Name = "txt_Memo";
            this.txt_Memo.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_Memo.Size = new System.Drawing.Size(475, 89);
            this.txt_Memo.TabIndex = 5;
            // 
            // maskedTextBox_EstimateDateTime
            // 
            this.maskedTextBox_EstimateDateTime.ForeColor = System.Drawing.Color.Green;
            this.maskedTextBox_EstimateDateTime.ImeMode = System.Windows.Forms.ImeMode.Close;
            this.maskedTextBox_EstimateDateTime.Location = new System.Drawing.Point(425, 75);
            this.maskedTextBox_EstimateDateTime.Mask = "0000/00/00 00:00";
            this.maskedTextBox_EstimateDateTime.Name = "maskedTextBox_EstimateDateTime";
            this.maskedTextBox_EstimateDateTime.Size = new System.Drawing.Size(169, 29);
            this.maskedTextBox_EstimateDateTime.TabIndex = 4;
            this.maskedTextBox_EstimateDateTime.ValidatingType = typeof(System.DateTime);
            this.maskedTextBox_EstimateDateTime.DoubleClick += new System.EventHandler(this.maskedTextBox_WorkDate_DoubleClick);
            this.maskedTextBox_EstimateDateTime.Leave += new System.EventHandler(this.maskedTextBox_StartTime_Leave);
            // 
            // maskedTextBox_StartTime
            // 
            this.maskedTextBox_StartTime.ForeColor = System.Drawing.Color.Green;
            this.maskedTextBox_StartTime.ImeMode = System.Windows.Forms.ImeMode.Close;
            this.maskedTextBox_StartTime.Location = new System.Drawing.Point(425, 43);
            this.maskedTextBox_StartTime.Mask = "0000/00/00 00:00";
            this.maskedTextBox_StartTime.Name = "maskedTextBox_StartTime";
            this.maskedTextBox_StartTime.Size = new System.Drawing.Size(169, 29);
            this.maskedTextBox_StartTime.TabIndex = 3;
            this.maskedTextBox_StartTime.ValidatingType = typeof(System.DateTime);
            this.maskedTextBox_StartTime.Visible = false;
            this.maskedTextBox_StartTime.DoubleClick += new System.EventHandler(this.maskedTextBox_WorkDate_DoubleClick);
            this.maskedTextBox_StartTime.Leave += new System.EventHandler(this.maskedTextBox_StartTime_Leave);
            // 
            // maskedTextBox_WorkDate
            // 
            this.maskedTextBox_WorkDate.ForeColor = System.Drawing.Color.Green;
            this.maskedTextBox_WorkDate.ImeMode = System.Windows.Forms.ImeMode.Close;
            this.maskedTextBox_WorkDate.Location = new System.Drawing.Point(119, 75);
            this.maskedTextBox_WorkDate.Mask = "0000/00/00 00:00";
            this.maskedTextBox_WorkDate.Name = "maskedTextBox_WorkDate";
            this.maskedTextBox_WorkDate.Size = new System.Drawing.Size(169, 29);
            this.maskedTextBox_WorkDate.TabIndex = 2;
            this.maskedTextBox_WorkDate.DoubleClick += new System.EventHandler(this.maskedTextBox_WorkDate_DoubleClick);
            this.maskedTextBox_WorkDate.Leave += new System.EventHandler(this.maskedTextBox_StartTime_Leave);
            // 
            // comboBox_Worker
            // 
            this.comboBox_Worker.DataSource = this.workerQuitNBindingSource;
            this.comboBox_Worker.DisplayMember = "Name";
            this.comboBox_Worker.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Worker.FormattingEnabled = true;
            this.comboBox_Worker.Location = new System.Drawing.Point(119, 45);
            this.comboBox_Worker.Name = "comboBox_Worker";
            this.comboBox_Worker.Size = new System.Drawing.Size(169, 28);
            this.comboBox_Worker.TabIndex = 1;
            this.comboBox_Worker.ValueMember = "WorkerKey";
            // 
            // workerQuitNBindingSource
            // 
            this.workerQuitNBindingSource.DataMember = "Worker_QuitN";
            this.workerQuitNBindingSource.DataSource = this.qS_DataSet;
            // 
            // qS_DataSet
            // 
            this.qS_DataSet.DataSetName = "QS_DataSet";
            this.qS_DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // txt_WorkContent
            // 
            this.txt_WorkContent.Location = new System.Drawing.Point(119, 12);
            this.txt_WorkContent.Name = "txt_WorkContent";
            this.txt_WorkContent.Size = new System.Drawing.Size(475, 29);
            this.txt_WorkContent.TabIndex = 0;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Location = new System.Drawing.Point(79, 143);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 20);
            this.label8.TabIndex = 470;
            this.label8.Text = "備註";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(319, 79);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(105, 20);
            this.label7.TabIndex = 469;
            this.label7.Text = "預計完成時間";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(353, 47);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 20);
            this.label5.TabIndex = 467;
            this.label5.Text = "開工時間";
            this.label5.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(47, 79);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 20);
            this.label3.TabIndex = 465;
            this.label3.Text = "發生時間";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(47, 15);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 20);
            this.label2.TabIndex = 464;
            this.label2.Text = "工作內容";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(63, 50);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 20);
            this.label1.TabIndex = 463;
            this.label1.Text = "承辦人";
            // 
            // worker_QuitNTableAdapter
            // 
            this.worker_QuitNTableAdapter.ClearBeforeFill = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.ForeColor = System.Drawing.Color.Green;
            this.label4.Location = new System.Drawing.Point(450, 200);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(142, 17);
            this.label4.TabIndex = 1088;
            this.label4.Text = "Shift+Enter：換下一行";
            // 
            // AddPatentWorkEvent
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = global::LawtechPTSystem.Properties.Resources.bg1;
            this.CancelButton = this.but_Cancel;
            this.ClientSize = new System.Drawing.Size(607, 262);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.but_Cancel);
            this.Controls.Add(this.but_OK);
            this.Controls.Add(this.txt_Memo);
            this.Controls.Add(this.maskedTextBox_EstimateDateTime);
            this.Controls.Add(this.maskedTextBox_StartTime);
            this.Controls.Add(this.maskedTextBox_WorkDate);
            this.Controls.Add(this.comboBox_Worker);
            this.Controls.Add(this.txt_WorkContent);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddPatentWorkEvent";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "新增待處理作業";
            this.Load += new System.EventHandler(this.AddPatentWorkEvent_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AddPatentWorkEvent_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.workerQuitNBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qS_DataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Button but_Cancel;
        internal System.Windows.Forms.Button but_OK;
        private System.Windows.Forms.TextBox txt_Memo;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_EstimateDateTime;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_StartTime;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_WorkDate;
        private System.Windows.Forms.ComboBox comboBox_Worker;
        private System.Windows.Forms.TextBox txt_WorkContent;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private QS_DataSet qS_DataSet;
        private System.Windows.Forms.BindingSource workerQuitNBindingSource;
        private LawtechPTSystem.QS_DataSetTableAdapters.Worker_QuitNTableAdapter worker_QuitNTableAdapter;
        private System.Windows.Forms.Label label4;
    }
}