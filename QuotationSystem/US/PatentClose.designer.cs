namespace LawtechPTSystem.US
{
    partial class PatentClose
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
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.txtPatentNo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Label9 = new System.Windows.Forms.Label();
            this.butCancel = new System.Windows.Forms.Button();
            this.butOK = new System.Windows.Forms.Button();
            this.maskedTextBox_CloseDate = new System.Windows.Forms.MaskedTextBox();
            this.label95 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_CloseCaus = new System.Windows.Forms.TextBox();
            this.cboStatus = new System.Windows.Forms.ComboBox();
            this.patStatusTDropBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.qS_DataSet = new LawtechPTSystem.QS_DataSet();
            this.label4 = new System.Windows.Forms.Label();
            this.txtStatusExplain = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.patStatusT_DropTableAdapter = new LawtechPTSystem.QS_DataSetTableAdapters.PatStatusT_DropTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.patStatusTDropBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qS_DataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // txtTitle
            // 
            this.txtTitle.BackColor = System.Drawing.Color.LightBlue;
            this.txtTitle.ForeColor = System.Drawing.Color.Black;
            this.txtTitle.Location = new System.Drawing.Point(114, 45);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.ReadOnly = true;
            this.txtTitle.Size = new System.Drawing.Size(366, 29);
            this.txtTitle.TabIndex = 332;
            // 
            // txtPatentNo
            // 
            this.txtPatentNo.BackColor = System.Drawing.Color.LightCyan;
            this.txtPatentNo.ForeColor = System.Drawing.Color.Black;
            this.txtPatentNo.Location = new System.Drawing.Point(114, 12);
            this.txtPatentNo.Name = "txtPatentNo";
            this.txtPatentNo.ReadOnly = true;
            this.txtPatentNo.Size = new System.Drawing.Size(366, 29);
            this.txtPatentNo.TabIndex = 331;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.label1.Location = new System.Drawing.Point(24, 17);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 20);
            this.label1.TabIndex = 330;
            this.label1.Text = "申請案卷號";
            // 
            // Label9
            // 
            this.Label9.AutoSize = true;
            this.Label9.BackColor = System.Drawing.Color.Transparent;
            this.Label9.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.Label9.Location = new System.Drawing.Point(24, 50);
            this.Label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(89, 20);
            this.Label9.TabIndex = 329;
            this.Label9.Text = "申請案名稱";
            // 
            // butCancel
            // 
            this.butCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.butCancel.BackgroundImage = global::LawtechPTSystem.Properties.Resources.btnCancel;
            this.butCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.butCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.butCancel.Location = new System.Drawing.Point(248, 302);
            this.butCancel.Margin = new System.Windows.Forms.Padding(1);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(100, 32);
            this.butCancel.TabIndex = 323;
            this.butCancel.Text = "取消";
            this.butCancel.UseVisualStyleBackColor = true;
            this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
            // 
            // butOK
            // 
            this.butOK.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.butOK.BackgroundImage = global::LawtechPTSystem.Properties.Resources.btnComfirm;
            this.butOK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.butOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.butOK.Location = new System.Drawing.Point(146, 302);
            this.butOK.Margin = new System.Windows.Forms.Padding(1);
            this.butOK.Name = "butOK";
            this.butOK.Size = new System.Drawing.Size(100, 32);
            this.butOK.TabIndex = 322;
            this.butOK.Text = "確定";
            this.butOK.UseVisualStyleBackColor = true;
            this.butOK.Click += new System.EventHandler(this.butOK_Click);
            // 
            // maskedTextBox_CloseDate
            // 
            this.maskedTextBox_CloseDate.BackColor = System.Drawing.Color.White;
            this.maskedTextBox_CloseDate.ForeColor = System.Drawing.Color.Green;
            this.maskedTextBox_CloseDate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.maskedTextBox_CloseDate.Location = new System.Drawing.Point(114, 78);
            this.maskedTextBox_CloseDate.Mask = "0000/00/00";
            this.maskedTextBox_CloseDate.Name = "maskedTextBox_CloseDate";
            this.maskedTextBox_CloseDate.Size = new System.Drawing.Size(115, 29);
            this.maskedTextBox_CloseDate.TabIndex = 334;
            this.maskedTextBox_CloseDate.ValidatingType = typeof(System.DateTime);
            this.maskedTextBox_CloseDate.DoubleClick += new System.EventHandler(this.maskedTextBox_CloseDate_DoubleClick);
            this.maskedTextBox_CloseDate.Leave += new System.EventHandler(this.maskedTextBox_CloseDate_Leave);
            // 
            // label95
            // 
            this.label95.AutoSize = true;
            this.label95.BackColor = System.Drawing.Color.Transparent;
            this.label95.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.label95.Location = new System.Drawing.Point(56, 81);
            this.label95.Name = "label95";
            this.label95.Size = new System.Drawing.Size(57, 20);
            this.label95.TabIndex = 333;
            this.label95.Text = "結案日";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.label7.Location = new System.Drawing.Point(40, 122);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 20);
            this.label7.TabIndex = 336;
            this.label7.Text = "結案原因";
            // 
            // txt_CloseCaus
            // 
            this.txt_CloseCaus.BackColor = System.Drawing.Color.White;
            this.txt_CloseCaus.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txt_CloseCaus.Location = new System.Drawing.Point(114, 111);
            this.txt_CloseCaus.Multiline = true;
            this.txt_CloseCaus.Name = "txt_CloseCaus";
            this.txt_CloseCaus.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_CloseCaus.Size = new System.Drawing.Size(366, 88);
            this.txt_CloseCaus.TabIndex = 335;
            // 
            // cboStatus
            // 
            this.cboStatus.DataSource = this.patStatusTDropBindingSource;
            this.cboStatus.DisplayMember = "Status";
            this.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStatus.FormattingEnabled = true;
            this.cboStatus.Location = new System.Drawing.Point(114, 205);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Size = new System.Drawing.Size(366, 28);
            this.cboStatus.TabIndex = 339;
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
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.label4.Location = new System.Drawing.Point(40, 209);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 20);
            this.label4.TabIndex = 337;
            this.label4.Text = "案件階段";
            // 
            // txtStatusExplain
            // 
            this.txtStatusExplain.Location = new System.Drawing.Point(114, 255);
            this.txtStatusExplain.Name = "txtStatusExplain";
            this.txtStatusExplain.Size = new System.Drawing.Size(366, 29);
            this.txtStatusExplain.TabIndex = 340;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.label5.Location = new System.Drawing.Point(40, 261);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 20);
            this.label5.TabIndex = 338;
            this.label5.Text = "階段描述";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("細明體", 9F);
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(119, 238);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 12);
            this.label2.TabIndex = 341;
            this.label2.Text = "※ 請選擇適合的結案階段";
            // 
            // patStatusT_DropTableAdapter
            // 
            this.patStatusT_DropTableAdapter.ClearBeforeFill = true;
            // 
            // PatentClose
            // 
            this.AcceptButton = this.butOK;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = global::LawtechPTSystem.Properties.Resources.bg_01;
            this.CancelButton = this.butCancel;
            this.ClientSize = new System.Drawing.Size(494, 349);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboStatus);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtStatusExplain);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txt_CloseCaus);
            this.Controls.Add(this.maskedTextBox_CloseDate);
            this.Controls.Add(this.label95);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.txtPatentNo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Label9);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.butOK);
            this.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PatentClose";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "結  案";
            this.Load += new System.EventHandler(this.PatentClose_Load);
            ((System.ComponentModel.ISupportInitialize)(this.patStatusTDropBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qS_DataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.TextBox txtPatentNo;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Label Label9;
        private System.Windows.Forms.Button butCancel;
        private System.Windows.Forms.Button butOK;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_CloseDate;
        internal System.Windows.Forms.Label label95;
        internal System.Windows.Forms.Label label7;
        internal System.Windows.Forms.TextBox txt_CloseCaus;
        private System.Windows.Forms.ComboBox cboStatus;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtStatusExplain;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private QS_DataSet qS_DataSet;
        private System.Windows.Forms.BindingSource patStatusTDropBindingSource;
        private LawtechPTSystem.QS_DataSetTableAdapters.PatStatusT_DropTableAdapter patStatusT_DropTableAdapter;
    }
}