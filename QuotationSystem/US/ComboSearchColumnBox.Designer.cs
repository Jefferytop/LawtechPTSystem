namespace LawtechPTSystem.US
{
    partial class ComboSearchColumnBox
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
            this.cbSelectedValue = new System.Windows.Forms.ComboBox();
            this.cb_SearchColumn = new System.Windows.Forms.ComboBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbSelectedValue
            // 
            this.cbSelectedValue.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbSelectedValue.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbSelectedValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbSelectedValue.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.cbSelectedValue.FormattingEnabled = true;
            this.cbSelectedValue.Location = new System.Drawing.Point(0, 0);
            this.cbSelectedValue.Margin = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.cbSelectedValue.MaxDropDownItems = 10;
            this.cbSelectedValue.Name = "cbSelectedValue";
            this.cbSelectedValue.Size = new System.Drawing.Size(294, 25);
            this.cbSelectedValue.TabIndex = 7;
            // 
            // cb_SearchColumn
            // 
            this.cb_SearchColumn.DisplayMember = "DisplayString";
            this.cb_SearchColumn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cb_SearchColumn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_SearchColumn.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.cb_SearchColumn.FormattingEnabled = true;
            this.cb_SearchColumn.Location = new System.Drawing.Point(0, 0);
            this.cb_SearchColumn.Margin = new System.Windows.Forms.Padding(0);
            this.cb_SearchColumn.MaxDropDownItems = 10;
            this.cb_SearchColumn.Name = "cb_SearchColumn";
            this.cb_SearchColumn.Size = new System.Drawing.Size(150, 25);
            this.cb_SearchColumn.TabIndex = 6;
            this.cb_SearchColumn.ValueMember = "ValueString";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(1);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.cb_SearchColumn);
            this.splitContainer1.Panel1MinSize = 50;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.cbSelectedValue);
            this.splitContainer1.Panel2MinSize = 50;
            this.splitContainer1.Size = new System.Drawing.Size(450, 28);
            this.splitContainer1.SplitterDistance = 150;
            this.splitContainer1.SplitterWidth = 6;
            this.splitContainer1.TabIndex = 8;
            // 
            // ComboSearchColumnBox
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ComboSearchColumnBox";
            this.Size = new System.Drawing.Size(450, 28);
            this.Load += new System.EventHandler(this.ComboSearchColumnBox_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.ComboBox cbSelectedValue;
        internal System.Windows.Forms.ComboBox cb_SearchColumn;
        private System.Windows.Forms.SplitContainer splitContainer1;
    }
}
