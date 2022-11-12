namespace LawtechPTSystem.US
{
    partial class AbortControl
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
            this.butCancel = new System.Windows.Forms.Button();
            this.butOK = new System.Windows.Forms.Button();
            this.cboStatus = new System.Windows.Forms.ComboBox();
            this.patStatusTDropBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.qS_DataSet = new LawtechPTSystem.QS_DataSet();
            this.txtStatusExplain = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.chkFileAbort = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_Result = new System.Windows.Forms.TextBox();
            this.txtEventContent = new System.Windows.Forms.TextBox();
            this.txtFileNo = new System.Windows.Forms.TextBox();
            this.mskFinishDate = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox_Patent = new System.Windows.Forms.GroupBox();
            this.txt_CloseCaus = new System.Windows.Forms.TextBox();
            this.maskedTextBox_CloseDate = new System.Windows.Forms.MaskedTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.patStatusT_DropTableAdapter = new LawtechPTSystem.QS_DataSetTableAdapters.PatStatusT_DropTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.patStatusTDropBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qS_DataSet)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox_Patent.SuspendLayout();
            this.SuspendLayout();
            // 
            // butCancel
            // 
            this.butCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.butCancel.BackgroundImage = global::LawtechPTSystem.Properties.Resources.btnCancel;
            this.butCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.butCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.butCancel.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.butCancel.Location = new System.Drawing.Point(288, 404);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(100, 32);
            this.butCancel.TabIndex = 15;
            this.butCancel.Text = "取消";
            this.butCancel.UseVisualStyleBackColor = true;
            this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
            // 
            // butOK
            // 
            this.butOK.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.butOK.BackgroundImage = global::LawtechPTSystem.Properties.Resources.btnComfirm;
            this.butOK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.butOK.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.butOK.Location = new System.Drawing.Point(182, 404);
            this.butOK.Name = "butOK";
            this.butOK.Size = new System.Drawing.Size(100, 32);
            this.butOK.TabIndex = 14;
            this.butOK.Text = "確定";
            this.butOK.UseVisualStyleBackColor = true;
            this.butOK.Click += new System.EventHandler(this.butOK_Click);
            // 
            // cboStatus
            // 
            this.cboStatus.DataSource = this.patStatusTDropBindingSource;
            this.cboStatus.DisplayMember = "Status";
            this.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStatus.FormattingEnabled = true;
            this.cboStatus.Location = new System.Drawing.Point(125, 26);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Size = new System.Drawing.Size(300, 28);
            this.cboStatus.TabIndex = 7;
            this.cboStatus.ValueMember = "StatusID";
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
            // txtStatusExplain
            // 
            this.txtStatusExplain.Location = new System.Drawing.Point(125, 56);
            this.txtStatusExplain.Margin = new System.Windows.Forms.Padding(1);
            this.txtStatusExplain.Name = "txtStatusExplain";
            this.txtStatusExplain.Size = new System.Drawing.Size(400, 29);
            this.txtStatusExplain.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(50, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 20);
            this.label5.TabIndex = 1;
            this.label5.Text = "階段描述";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "目前案件階段";
            // 
            // chkFileAbort
            // 
            this.chkFileAbort.AutoSize = true;
            this.chkFileAbort.ForeColor = System.Drawing.SystemColors.Desktop;
            this.chkFileAbort.Location = new System.Drawing.Point(23, 216);
            this.chkFileAbort.Name = "chkFileAbort";
            this.chkFileAbort.Size = new System.Drawing.Size(204, 24);
            this.chkFileAbort.TabIndex = 13;
            this.chkFileAbort.Text = "專利申請案是否一併放棄";
            this.chkFileAbort.UseVisualStyleBackColor = true;
            this.chkFileAbort.CheckedChanged += new System.EventHandler(this.chkFileAbort_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txt_Result);
            this.groupBox1.Controls.Add(this.txtEventContent);
            this.groupBox1.Controls.Add(this.txtFileNo);
            this.groupBox1.Controls.Add(this.mskFinishDate);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(540, 196);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "放棄目前處理事件記錄";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微軟正黑體", 9F);
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.label7.Location = new System.Drawing.Point(216, 102);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(136, 16);
            this.label7.TabIndex = 7;
            this.label7.Text = "(同事件記錄的完成日期)";
            // 
            // txt_Result
            // 
            this.txt_Result.Location = new System.Drawing.Point(92, 126);
            this.txt_Result.Multiline = true;
            this.txt_Result.Name = "txt_Result";
            this.txt_Result.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_Result.Size = new System.Drawing.Size(432, 52);
            this.txt_Result.TabIndex = 5;
            // 
            // txtEventContent
            // 
            this.txtEventContent.BackColor = System.Drawing.Color.LightBlue;
            this.txtEventContent.ForeColor = System.Drawing.Color.Black;
            this.txtEventContent.Location = new System.Drawing.Point(92, 60);
            this.txtEventContent.Name = "txtEventContent";
            this.txtEventContent.ReadOnly = true;
            this.txtEventContent.Size = new System.Drawing.Size(432, 29);
            this.txtEventContent.TabIndex = 4;
            // 
            // txtFileNo
            // 
            this.txtFileNo.BackColor = System.Drawing.Color.LightCyan;
            this.txtFileNo.ForeColor = System.Drawing.Color.Black;
            this.txtFileNo.Location = new System.Drawing.Point(92, 27);
            this.txtFileNo.Name = "txtFileNo";
            this.txtFileNo.ReadOnly = true;
            this.txtFileNo.Size = new System.Drawing.Size(432, 29);
            this.txtFileNo.TabIndex = 2;
            // 
            // mskFinishDate
            // 
            this.mskFinishDate.ForeColor = System.Drawing.Color.Green;
            this.mskFinishDate.Location = new System.Drawing.Point(92, 93);
            this.mskFinishDate.Mask = "0000-00-00";
            this.mskFinishDate.Name = "mskFinishDate";
            this.mskFinishDate.Size = new System.Drawing.Size(120, 29);
            this.mskFinishDate.TabIndex = 1;
            this.mskFinishDate.DoubleClick += new System.EventHandler(this.mskFinishDate_DoubleClick);
            this.mskFinishDate.Leave += new System.EventHandler(this.mskFinishDate_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "放棄原因：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "申請案：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "放棄日期：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 66);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 20);
            this.label6.TabIndex = 6;
            this.label6.Text = "事件內容：";
            // 
            // groupBox_Patent
            // 
            this.groupBox_Patent.Controls.Add(this.txt_CloseCaus);
            this.groupBox_Patent.Controls.Add(this.maskedTextBox_CloseDate);
            this.groupBox_Patent.Controls.Add(this.label8);
            this.groupBox_Patent.Controls.Add(this.label9);
            this.groupBox_Patent.Controls.Add(this.cboStatus);
            this.groupBox_Patent.Controls.Add(this.label4);
            this.groupBox_Patent.Controls.Add(this.txtStatusExplain);
            this.groupBox_Patent.Controls.Add(this.label5);
            this.groupBox_Patent.Enabled = false;
            this.groupBox_Patent.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox_Patent.Location = new System.Drawing.Point(12, 216);
            this.groupBox_Patent.Name = "groupBox_Patent";
            this.groupBox_Patent.Size = new System.Drawing.Size(541, 182);
            this.groupBox_Patent.TabIndex = 16;
            this.groupBox_Patent.TabStop = false;
            // 
            // txt_CloseCaus
            // 
            this.txt_CloseCaus.Location = new System.Drawing.Point(125, 116);
            this.txt_CloseCaus.Multiline = true;
            this.txt_CloseCaus.Name = "txt_CloseCaus";
            this.txt_CloseCaus.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_CloseCaus.Size = new System.Drawing.Size(400, 52);
            this.txt_CloseCaus.TabIndex = 12;
            // 
            // maskedTextBox_CloseDate
            // 
            this.maskedTextBox_CloseDate.ForeColor = System.Drawing.Color.Green;
            this.maskedTextBox_CloseDate.Location = new System.Drawing.Point(125, 86);
            this.maskedTextBox_CloseDate.Margin = new System.Windows.Forms.Padding(1);
            this.maskedTextBox_CloseDate.Mask = "0000-00-00";
            this.maskedTextBox_CloseDate.Name = "maskedTextBox_CloseDate";
            this.maskedTextBox_CloseDate.Size = new System.Drawing.Size(120, 29);
            this.maskedTextBox_CloseDate.TabIndex = 10;
            this.maskedTextBox_CloseDate.DoubleClick += new System.EventHandler(this.mskFinishDate_DoubleClick);
            this.maskedTextBox_CloseDate.Leave += new System.EventHandler(this.mskFinishDate_Leave);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(50, 129);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 20);
            this.label8.TabIndex = 11;
            this.label8.Text = "結案原因";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(50, 90);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(73, 20);
            this.label9.TabIndex = 9;
            this.label9.Text = "結案日期";
            // 
            // patStatusT_DropTableAdapter
            // 
            this.patStatusT_DropTableAdapter.ClearBeforeFill = true;
            // 
            // AbortControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = global::LawtechPTSystem.Properties.Resources.bg_01;
            this.CancelButton = this.butCancel;
            this.ClientSize = new System.Drawing.Size(571, 447);
            this.Controls.Add(this.chkFileAbort);
            this.Controls.Add(this.groupBox_Patent);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.butOK);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AbortControl";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "放  棄";
            this.Load += new System.EventHandler(this.AbortControl_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AbortControl_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.patStatusTDropBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qS_DataSet)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox_Patent.ResumeLayout(false);
            this.groupBox_Patent.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button butCancel;
        private System.Windows.Forms.Button butOK;
        private System.Windows.Forms.ComboBox cboStatus;
        private System.Windows.Forms.TextBox txtStatusExplain;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkFileAbort;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtEventContent;
        private System.Windows.Forms.TextBox txtFileNo;
        private System.Windows.Forms.MaskedTextBox mskFinishDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox_Patent;
        private System.Windows.Forms.TextBox txt_Result;
        private QS_DataSet qS_DataSet;
        private System.Windows.Forms.BindingSource patStatusTDropBindingSource;
        private LawtechPTSystem.QS_DataSetTableAdapters.PatStatusT_DropTableAdapter patStatusT_DropTableAdapter;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_CloseCaus;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_CloseDate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
    }
}