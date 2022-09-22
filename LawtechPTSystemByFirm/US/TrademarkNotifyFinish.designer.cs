namespace LawtechPTSystemByFirm.US
{
    partial class TrademarkNotifyFinish
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
            this.but_Cancel = new System.Windows.Forms.Button();
            this.but_OK = new System.Windows.Forms.Button();
            this.label49 = new System.Windows.Forms.Label();
            this.txt_Remark = new System.Windows.Forms.TextBox();
            this.txt_Result = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.maskedTextBox_OutsourcingDate = new System.Windows.Forms.MaskedTextBox();
            this.label33 = new System.Windows.Forms.Label();
            this.maskedTextBox_FinishDate = new System.Windows.Forms.MaskedTextBox();
            this.label48 = new System.Windows.Forms.Label();
            this.txt_NotifyEventContent = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.maskedTextBox_DueDate = new System.Windows.Forms.MaskedTextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.maskedTextBox_NotifyComitDate = new System.Windows.Forms.MaskedTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // but_Cancel
            // 
            this.but_Cancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.but_Cancel.BackgroundImage = global::LawtechPTSystemByFirm.Properties.Resources.btnCancel;
            this.but_Cancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.but_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.but_Cancel.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.but_Cancel.Location = new System.Drawing.Point(270, 286);
            this.but_Cancel.Margin = new System.Windows.Forms.Padding(1);
            this.but_Cancel.Name = "but_Cancel";
            this.but_Cancel.Size = new System.Drawing.Size(94, 34);
            this.but_Cancel.TabIndex = 369;
            this.but_Cancel.Text = "取   消";
            this.but_Cancel.UseVisualStyleBackColor = true;
            this.but_Cancel.Click += new System.EventHandler(this.but_Cancel_Click);
            // 
            // but_OK
            // 
            this.but_OK.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.but_OK.BackgroundImage = global::LawtechPTSystemByFirm.Properties.Resources.btnComfirm;
            this.but_OK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.but_OK.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.but_OK.Location = new System.Drawing.Point(174, 286);
            this.but_OK.Margin = new System.Windows.Forms.Padding(1);
            this.but_OK.Name = "but_OK";
            this.but_OK.Size = new System.Drawing.Size(94, 34);
            this.but_OK.TabIndex = 368;
            this.but_OK.Text = "確   定";
            this.but_OK.UseVisualStyleBackColor = true;
            this.but_OK.Click += new System.EventHandler(this.but_OK_Click);
            // 
            // label49
            // 
            this.label49.AutoSize = true;
            this.label49.Location = new System.Drawing.Point(33, 198);
            this.label49.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(57, 20);
            this.label49.TabIndex = 1060;
            this.label49.Text = "備    註";
            // 
            // txt_Remark
            // 
            this.txt_Remark.BackColor = System.Drawing.Color.White;
            this.txt_Remark.ImeMode = System.Windows.Forms.ImeMode.Close;
            this.txt_Remark.Location = new System.Drawing.Point(91, 195);
            this.txt_Remark.Margin = new System.Windows.Forms.Padding(4);
            this.txt_Remark.Multiline = true;
            this.txt_Remark.Name = "txt_Remark";
            this.txt_Remark.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_Remark.Size = new System.Drawing.Size(427, 78);
            this.txt_Remark.TabIndex = 1059;
            // 
            // txt_Result
            // 
            this.txt_Result.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txt_Result.Location = new System.Drawing.Point(91, 114);
            this.txt_Result.Margin = new System.Windows.Forms.Padding(4);
            this.txt_Result.Multiline = true;
            this.txt_Result.Name = "txt_Result";
            this.txt_Result.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_Result.Size = new System.Drawing.Size(427, 73);
            this.txt_Result.TabIndex = 1057;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 117);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 20);
            this.label8.TabIndex = 1058;
            this.label8.Text = "處理結果";
            // 
            // maskedTextBox_OutsourcingDate
            // 
            this.maskedTextBox_OutsourcingDate.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.maskedTextBox_OutsourcingDate.ForeColor = System.Drawing.Color.Green;
            this.maskedTextBox_OutsourcingDate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.maskedTextBox_OutsourcingDate.Location = new System.Drawing.Point(361, 47);
            this.maskedTextBox_OutsourcingDate.Margin = new System.Windows.Forms.Padding(4);
            this.maskedTextBox_OutsourcingDate.Mask = "0000/00/00";
            this.maskedTextBox_OutsourcingDate.Name = "maskedTextBox_OutsourcingDate";
            this.maskedTextBox_OutsourcingDate.ReadOnly = true;
            this.maskedTextBox_OutsourcingDate.Size = new System.Drawing.Size(157, 29);
            this.maskedTextBox_OutsourcingDate.TabIndex = 1076;
            this.maskedTextBox_OutsourcingDate.ValidatingType = typeof(System.DateTime);
            this.maskedTextBox_OutsourcingDate.DoubleClick += new System.EventHandler(this.maskedTextBox_OutsourcingDate_DoubleClick);
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(286, 52);
            this.label33.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(73, 20);
            this.label33.TabIndex = 1075;
            this.label33.Text = "委外日期";
            // 
            // maskedTextBox_FinishDate
            // 
            this.maskedTextBox_FinishDate.ForeColor = System.Drawing.Color.Green;
            this.maskedTextBox_FinishDate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.maskedTextBox_FinishDate.Location = new System.Drawing.Point(361, 80);
            this.maskedTextBox_FinishDate.Margin = new System.Windows.Forms.Padding(4);
            this.maskedTextBox_FinishDate.Mask = "0000/00/00";
            this.maskedTextBox_FinishDate.Name = "maskedTextBox_FinishDate";
            this.maskedTextBox_FinishDate.Size = new System.Drawing.Size(157, 29);
            this.maskedTextBox_FinishDate.TabIndex = 1074;
            this.maskedTextBox_FinishDate.ValidatingType = typeof(System.DateTime);
            this.maskedTextBox_FinishDate.DoubleClick += new System.EventHandler(this.maskedTextBox_OutsourcingDate_DoubleClick);
            // 
            // label48
            // 
            this.label48.AutoSize = true;
            this.label48.Location = new System.Drawing.Point(286, 84);
            this.label48.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(73, 20);
            this.label48.TabIndex = 1073;
            this.label48.Text = "完成日期";
            // 
            // txt_NotifyEventContent
            // 
            this.txt_NotifyEventContent.BackColor = System.Drawing.Color.LightBlue;
            this.txt_NotifyEventContent.ForeColor = System.Drawing.Color.Black;
            this.txt_NotifyEventContent.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txt_NotifyEventContent.Location = new System.Drawing.Point(91, 13);
            this.txt_NotifyEventContent.Margin = new System.Windows.Forms.Padding(4);
            this.txt_NotifyEventContent.Name = "txt_NotifyEventContent";
            this.txt_NotifyEventContent.ReadOnly = true;
            this.txt_NotifyEventContent.Size = new System.Drawing.Size(427, 29);
            this.txt_NotifyEventContent.TabIndex = 1078;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 16);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 20);
            this.label1.TabIndex = 1077;
            this.label1.Text = "事件內容";
            // 
            // maskedTextBox_DueDate
            // 
            this.maskedTextBox_DueDate.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.maskedTextBox_DueDate.ForeColor = System.Drawing.Color.Green;
            this.maskedTextBox_DueDate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.maskedTextBox_DueDate.Location = new System.Drawing.Point(91, 80);
            this.maskedTextBox_DueDate.Mask = "0000/00/00";
            this.maskedTextBox_DueDate.Name = "maskedTextBox_DueDate";
            this.maskedTextBox_DueDate.ReadOnly = true;
            this.maskedTextBox_DueDate.Size = new System.Drawing.Size(157, 29);
            this.maskedTextBox_DueDate.TabIndex = 1080;
            this.maskedTextBox_DueDate.ValidatingType = typeof(System.DateTime);
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(19, 85);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(73, 20);
            this.label23.TabIndex = 1079;
            this.label23.Text = "官方期限";
            // 
            // maskedTextBox_NotifyComitDate
            // 
            this.maskedTextBox_NotifyComitDate.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.maskedTextBox_NotifyComitDate.ForeColor = System.Drawing.Color.Green;
            this.maskedTextBox_NotifyComitDate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.maskedTextBox_NotifyComitDate.Location = new System.Drawing.Point(91, 47);
            this.maskedTextBox_NotifyComitDate.Mask = "0000/00/00";
            this.maskedTextBox_NotifyComitDate.Name = "maskedTextBox_NotifyComitDate";
            this.maskedTextBox_NotifyComitDate.ReadOnly = true;
            this.maskedTextBox_NotifyComitDate.Size = new System.Drawing.Size(157, 29);
            this.maskedTextBox_NotifyComitDate.TabIndex = 1082;
            this.maskedTextBox_NotifyComitDate.ValidatingType = typeof(System.DateTime);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 20);
            this.label5.TabIndex = 1081;
            this.label5.Text = "事件發生日";
            // 
            // TrademarkNotifyFinish
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = global::LawtechPTSystemByFirm.Properties.Resources.bg_01;
            this.CancelButton = this.but_Cancel;
            this.ClientSize = new System.Drawing.Size(539, 330);
            this.Controls.Add(this.maskedTextBox_NotifyComitDate);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.maskedTextBox_DueDate);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.txt_NotifyEventContent);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.maskedTextBox_OutsourcingDate);
            this.Controls.Add(this.label33);
            this.Controls.Add(this.maskedTextBox_FinishDate);
            this.Controls.Add(this.label48);
            this.Controls.Add(this.label49);
            this.Controls.Add(this.txt_Remark);
            this.Controls.Add(this.txt_Result);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.but_Cancel);
            this.Controls.Add(this.but_OK);
            this.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TrademarkNotifyFinish";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "案件記錄已完成處理";
            this.Load += new System.EventHandler(this.TrademarkNotifyFinish_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TrademarkNotifyFinish_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button but_Cancel;
        private System.Windows.Forms.Button but_OK;
        private System.Windows.Forms.Label label49;
        internal System.Windows.Forms.TextBox txt_Remark;
        internal System.Windows.Forms.TextBox txt_Result;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_OutsourcingDate;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_FinishDate;
        private System.Windows.Forms.Label label48;
        internal System.Windows.Forms.TextBox txt_NotifyEventContent;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_DueDate;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_NotifyComitDate;
        private System.Windows.Forms.Label label5;
    }
}