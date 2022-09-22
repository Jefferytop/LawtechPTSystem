namespace LawtechPTSystemByFirm.US
{
    partial class UserControlFilterDate
    {
        /// <summary> 
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 元件設計工具產生的程式碼

        /// <summary> 
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
        /// 修改這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.SearchDateSplitContainer1 = new System.Windows.Forms.SplitContainer();
            this.cb_DateMode = new System.Windows.Forms.ComboBox();
            this.maskedEndDate = new System.Windows.Forms.MaskedTextBox();
            this.maskedStartDate = new System.Windows.Forms.MaskedTextBox();
            this.lab_Separated = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.SearchDateSplitContainer1)).BeginInit();
            this.SearchDateSplitContainer1.Panel1.SuspendLayout();
            this.SearchDateSplitContainer1.Panel2.SuspendLayout();
            this.SearchDateSplitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // SearchDateSplitContainer1
            // 
            this.SearchDateSplitContainer1.BackColor = System.Drawing.Color.Transparent;
            this.SearchDateSplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SearchDateSplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.SearchDateSplitContainer1.Location = new System.Drawing.Point(0, 0);
            this.SearchDateSplitContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.SearchDateSplitContainer1.Name = "SearchDateSplitContainer1";
            // 
            // SearchDateSplitContainer1.Panel1
            // 
            this.SearchDateSplitContainer1.Panel1.Controls.Add(this.cb_DateMode);
            // 
            // SearchDateSplitContainer1.Panel2
            // 
            this.SearchDateSplitContainer1.Panel2.Controls.Add(this.maskedEndDate);
            this.SearchDateSplitContainer1.Panel2.Controls.Add(this.maskedStartDate);
            this.SearchDateSplitContainer1.Panel2.Controls.Add(this.lab_Separated);
            this.SearchDateSplitContainer1.Size = new System.Drawing.Size(367, 29);
            this.SearchDateSplitContainer1.SplitterDistance = 135;
            this.SearchDateSplitContainer1.SplitterWidth = 2;
            this.SearchDateSplitContainer1.TabIndex = 55;
            // 
            // cb_DateMode
            // 
            this.cb_DateMode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_DateMode.DisplayMember = "DisplayString";
            this.cb_DateMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_DateMode.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.cb_DateMode.FormattingEnabled = true;
            this.cb_DateMode.Location = new System.Drawing.Point(1, 1);
            this.cb_DateMode.Margin = new System.Windows.Forms.Padding(0);
            this.cb_DateMode.Name = "cb_DateMode";
            this.cb_DateMode.Size = new System.Drawing.Size(133, 25);
            this.cb_DateMode.TabIndex = 53;
            this.cb_DateMode.ValueMember = "ValueString";
            // 
            // maskedEndDate
            // 
            this.maskedEndDate.Font = new System.Drawing.Font("微軟正黑體", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.maskedEndDate.ForeColor = System.Drawing.Color.RoyalBlue;
            this.maskedEndDate.Location = new System.Drawing.Point(125, 1);
            this.maskedEndDate.Margin = new System.Windows.Forms.Padding(0);
            this.maskedEndDate.Mask = "0000/00/00";
            this.maskedEndDate.Name = "maskedEndDate";
            this.maskedEndDate.Size = new System.Drawing.Size(100, 25);
            this.maskedEndDate.TabIndex = 53;
            this.maskedEndDate.ValidatingType = typeof(System.DateTime);
            this.maskedEndDate.DoubleClick += new System.EventHandler(this.maskedStartDate_DoubleClick);
            // 
            // maskedStartDate
            // 
            this.maskedStartDate.Font = new System.Drawing.Font("微軟正黑體", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.maskedStartDate.ForeColor = System.Drawing.Color.RoyalBlue;
            this.maskedStartDate.Location = new System.Drawing.Point(3, 1);
            this.maskedStartDate.Margin = new System.Windows.Forms.Padding(0);
            this.maskedStartDate.Mask = "0000/00/00";
            this.maskedStartDate.Name = "maskedStartDate";
            this.maskedStartDate.Size = new System.Drawing.Size(100, 25);
            this.maskedStartDate.TabIndex = 52;
            this.maskedStartDate.ValidatingType = typeof(System.DateTime);
            this.maskedStartDate.DoubleClick += new System.EventHandler(this.maskedStartDate_DoubleClick);
            // 
            // lab_Separated
            // 
            this.lab_Separated.Location = new System.Drawing.Point(106, 5);
            this.lab_Separated.Margin = new System.Windows.Forms.Padding(0);
            this.lab_Separated.Name = "lab_Separated";
            this.lab_Separated.Size = new System.Drawing.Size(17, 12);
            this.lab_Separated.TabIndex = 51;
            this.lab_Separated.Text = "～";
            // 
            // UserControlFilterDate
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.SearchDateSplitContainer1);
            this.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "UserControlFilterDate";
            this.Size = new System.Drawing.Size(367, 29);
            this.Load += new System.EventHandler(this.UserControlFilterDate_Load);
            this.SearchDateSplitContainer1.Panel1.ResumeLayout(false);
            this.SearchDateSplitContainer1.Panel2.ResumeLayout(false);
            this.SearchDateSplitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SearchDateSplitContainer1)).EndInit();
            this.SearchDateSplitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.SplitContainer SearchDateSplitContainer1;
        internal System.Windows.Forms.ComboBox cb_DateMode;
        internal System.Windows.Forms.Label lab_Separated;
        private System.Windows.Forms.MaskedTextBox maskedEndDate;
        private System.Windows.Forms.MaskedTextBox maskedStartDate;
    }
}
