namespace LawtechPTSystem.US
{
    partial class PatentComitEventFinish
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
            this.txt_statusExplain = new System.Windows.Forms.TextBox();
            this.comboBox_status = new System.Windows.Forms.ComboBox();
            this.patStatusTDropBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.qS_DataSet = new LawtechPTSystem.QS_DataSet();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.but_OK = new System.Windows.Forms.Button();
            this.txt_Result = new System.Windows.Forms.TextBox();
            this.maskedTextBox_FinishDate = new System.Windows.Forms.MaskedTextBox();
            this.contextMenuStrip_ForDate = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ToolStripMenuItem_Calculation = new System.Windows.Forms.ToolStripMenuItem();
            this.maskedTextBox_ComitDate = new System.Windows.Forms.MaskedTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_EventContent = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.patStatusT_DropTableAdapter = new LawtechPTSystem.QS_DataSetTableAdapters.PatStatusT_DropTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.patStatusTDropBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qS_DataSet)).BeginInit();
            this.contextMenuStrip_ForDate.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt_statusExplain
            // 
            this.txt_statusExplain.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.txt_statusExplain.Location = new System.Drawing.Point(106, 219);
            this.txt_statusExplain.Multiline = true;
            this.txt_statusExplain.Name = "txt_statusExplain";
            this.txt_statusExplain.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_statusExplain.Size = new System.Drawing.Size(374, 67);
            this.txt_statusExplain.TabIndex = 31;
            // 
            // comboBox_status
            // 
            this.comboBox_status.DataSource = this.patStatusTDropBindingSource;
            this.comboBox_status.DisplayMember = "Status";
            this.comboBox_status.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_status.FormattingEnabled = true;
            this.comboBox_status.Location = new System.Drawing.Point(106, 189);
            this.comboBox_status.Name = "comboBox_status";
            this.comboBox_status.Size = new System.Drawing.Size(374, 28);
            this.comboBox_status.TabIndex = 34;
            this.comboBox_status.ValueMember = "StatusID";
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
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.label7.Location = new System.Drawing.Point(30, 224);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 20);
            this.label7.TabIndex = 33;
            this.label7.Text = "階段描述";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.label6.Location = new System.Drawing.Point(30, 191);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 20);
            this.label6.TabIndex = 32;
            this.label6.Text = "案件階段";
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button2.BackgroundImage = global::LawtechPTSystem.Properties.Resources.btnCancel;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(248, 308);
            this.button2.Margin = new System.Windows.Forms.Padding(1);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 32);
            this.button2.TabIndex = 30;
            this.button2.Text = "取消";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // but_OK
            // 
            this.but_OK.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.but_OK.BackgroundImage = global::LawtechPTSystem.Properties.Resources.btnComfirm;
            this.but_OK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.but_OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.but_OK.Location = new System.Drawing.Point(146, 308);
            this.but_OK.Margin = new System.Windows.Forms.Padding(1);
            this.but_OK.Name = "but_OK";
            this.but_OK.Size = new System.Drawing.Size(100, 32);
            this.but_OK.TabIndex = 29;
            this.but_OK.Text = "確定";
            this.but_OK.UseVisualStyleBackColor = true;
            this.but_OK.Click += new System.EventHandler(this.but_OK_Click);
            // 
            // txt_Result
            // 
            this.txt_Result.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.txt_Result.Location = new System.Drawing.Point(106, 108);
            this.txt_Result.Multiline = true;
            this.txt_Result.Name = "txt_Result";
            this.txt_Result.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_Result.Size = new System.Drawing.Size(374, 57);
            this.txt_Result.TabIndex = 28;
            // 
            // maskedTextBox_FinishDate
            // 
            this.maskedTextBox_FinishDate.ContextMenuStrip = this.contextMenuStrip_ForDate;
            this.maskedTextBox_FinishDate.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.maskedTextBox_FinishDate.ForeColor = System.Drawing.Color.Green;
            this.maskedTextBox_FinishDate.Location = new System.Drawing.Point(106, 77);
            this.maskedTextBox_FinishDate.Mask = "0000/00/00";
            this.maskedTextBox_FinishDate.Name = "maskedTextBox_FinishDate";
            this.maskedTextBox_FinishDate.Size = new System.Drawing.Size(116, 29);
            this.maskedTextBox_FinishDate.TabIndex = 20;
            this.maskedTextBox_FinishDate.ValidatingType = typeof(System.DateTime);
            this.maskedTextBox_FinishDate.DoubleClick += new System.EventHandler(this.maskedTextBox_ComitDate_DoubleClick);
            this.maskedTextBox_FinishDate.Leave += new System.EventHandler(this.maskedTextBox_ComitDate_Leave);
            // 
            // contextMenuStrip_ForDate
            // 
            this.contextMenuStrip_ForDate.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_Calculation});
            this.contextMenuStrip_ForDate.Name = "contextMenuStrip_ForDate";
            this.contextMenuStrip_ForDate.Size = new System.Drawing.Size(123, 26);
            this.contextMenuStrip_ForDate.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuStrip_ForDate_ItemClicked);
            // 
            // ToolStripMenuItem_Calculation
            // 
            this.ToolStripMenuItem_Calculation.Name = "ToolStripMenuItem_Calculation";
            this.ToolStripMenuItem_Calculation.Size = new System.Drawing.Size(122, 22);
            this.ToolStripMenuItem_Calculation.Text = "計算日期";
            // 
            // maskedTextBox_ComitDate
            // 
            this.maskedTextBox_ComitDate.ContextMenuStrip = this.contextMenuStrip_ForDate;
            this.maskedTextBox_ComitDate.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.maskedTextBox_ComitDate.ForeColor = System.Drawing.Color.Green;
            this.maskedTextBox_ComitDate.Location = new System.Drawing.Point(106, 45);
            this.maskedTextBox_ComitDate.Mask = "0000/00/00";
            this.maskedTextBox_ComitDate.Name = "maskedTextBox_ComitDate";
            this.maskedTextBox_ComitDate.Size = new System.Drawing.Size(116, 29);
            this.maskedTextBox_ComitDate.TabIndex = 26;
            this.maskedTextBox_ComitDate.ValidatingType = typeof(System.DateTime);
            this.maskedTextBox_ComitDate.DoubleClick += new System.EventHandler(this.maskedTextBox_ComitDate_DoubleClick);
            this.maskedTextBox_ComitDate.Leave += new System.EventHandler(this.maskedTextBox_ComitDate_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.label4.Location = new System.Drawing.Point(30, 126);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 20);
            this.label4.TabIndex = 25;
            this.label4.Text = "處理結果";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(119)))), ((int)(((byte)(72)))), ((int)(((byte)(54)))));
            this.label3.Location = new System.Drawing.Point(30, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 20);
            this.label3.TabIndex = 24;
            this.label3.Text = "完成日期";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.label2.Location = new System.Drawing.Point(30, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 20);
            this.label2.TabIndex = 23;
            this.label2.Text = "送件日期";
            // 
            // txt_EventContent
            // 
            this.txt_EventContent.BackColor = System.Drawing.Color.LightCyan;
            this.txt_EventContent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_EventContent.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.txt_EventContent.Location = new System.Drawing.Point(106, 12);
            this.txt_EventContent.Name = "txt_EventContent";
            this.txt_EventContent.ReadOnly = true;
            this.txt_EventContent.Size = new System.Drawing.Size(300, 29);
            this.txt_EventContent.TabIndex = 22;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.label1.Location = new System.Drawing.Point(30, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 20);
            this.label1.TabIndex = 20;
            this.label1.Text = "事件名稱";
            // 
            // patStatusT_DropTableAdapter
            // 
            this.patStatusT_DropTableAdapter.ClearBeforeFill = true;
            // 
            // PatentComitEventFinish
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = global::LawtechPTSystem.Properties.Resources.bg_01;
            this.CancelButton = this.button2;
            this.ClientSize = new System.Drawing.Size(494, 359);
            this.Controls.Add(this.txt_statusExplain);
            this.Controls.Add(this.comboBox_status);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.but_OK);
            this.Controls.Add(this.txt_Result);
            this.Controls.Add(this.maskedTextBox_FinishDate);
            this.Controls.Add(this.maskedTextBox_ComitDate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_EventContent);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PatentComitEventFinish";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "事件處理完成";
            this.Load += new System.EventHandler(this.PatentComitEventFinish_Load);
            ((System.ComponentModel.ISupportInitialize)(this.patStatusTDropBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qS_DataSet)).EndInit();
            this.contextMenuStrip_ForDate.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_statusExplain;
        private System.Windows.Forms.ComboBox comboBox_status;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button but_OK;
        private System.Windows.Forms.TextBox txt_Result;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_FinishDate;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_ComitDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_EventContent;
        private System.Windows.Forms.Label label1;
        private QS_DataSet qS_DataSet;
        private System.Windows.Forms.BindingSource patStatusTDropBindingSource;
        private LawtechPTSystem.QS_DataSetTableAdapters.PatStatusT_DropTableAdapter patStatusT_DropTableAdapter;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_ForDate;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Calculation;
    }
}