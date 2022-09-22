namespace LawtechPTSystemByFirm.US
{
    partial class ComboSearchDetailColumnBox
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.cb_SearchColumn = new System.Windows.Forms.ComboBox();
            this.cbSelectedValue = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.cb_SearchColumn);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.cbSelectedValue);
            this.splitContainer1.Size = new System.Drawing.Size(352, 27);
            this.splitContainer1.SplitterDistance = 117;
            this.splitContainer1.TabIndex = 9;
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
            this.cb_SearchColumn.Size = new System.Drawing.Size(117, 25);
            this.cb_SearchColumn.TabIndex = 6;
            this.cb_SearchColumn.ValueMember = "ValueString";
            this.cb_SearchColumn.SelectedIndexChanged += new System.EventHandler(this.cb_SearchColumn_SelectedIndexChanged);
            // 
            // cbSelectedValue
            // 
            this.cbSelectedValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbSelectedValue.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.cbSelectedValue.FormattingEnabled = true;
            this.cbSelectedValue.Location = new System.Drawing.Point(0, 0);
            this.cbSelectedValue.Margin = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.cbSelectedValue.MaxDropDownItems = 10;
            this.cbSelectedValue.Name = "cbSelectedValue";
            this.cbSelectedValue.Size = new System.Drawing.Size(231, 25);
            this.cbSelectedValue.TabIndex = 7;
            // 
            // ComboSearchDetailColumnBox
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(1);
            this.Name = "ComboSearchDetailColumnBox";
            this.Size = new System.Drawing.Size(352, 27);
            this.Load += new System.EventHandler(this.ComboSearchDetailColumnBox_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.SplitContainer splitContainer1;
        internal System.Windows.Forms.ComboBox cb_SearchColumn;
        internal System.Windows.Forms.ComboBox cbSelectedValue;
    }
}
