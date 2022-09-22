namespace LawtechPTSystem.US
{
    partial class ComboSearchColumnBoxPro
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
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.rab_or = new System.Windows.Forms.RadioButton();
            this.rab_And = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
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
            this.cbSelectedValue.Size = new System.Drawing.Size(228, 25);
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
            this.cb_SearchColumn.SelectedIndexChanged += new System.EventHandler(this.cb_SearchColumn_SelectedIndexChanged);
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
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Panel2MinSize = 50;
            this.splitContainer1.Size = new System.Drawing.Size(550, 28);
            this.splitContainer1.SplitterDistance = 150;
            this.splitContainer1.SplitterWidth = 6;
            this.splitContainer1.TabIndex = 8;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Margin = new System.Windows.Forms.Padding(1);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.cbSelectedValue);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.rab_or);
            this.splitContainer2.Panel2.Controls.Add(this.rab_And);
            this.splitContainer2.Panel2.Controls.Add(this.radioButton1);
            this.splitContainer2.Size = new System.Drawing.Size(394, 28);
            this.splitContainer2.SplitterDistance = 228;
            this.splitContainer2.SplitterWidth = 3;
            this.splitContainer2.TabIndex = 8;
            // 
            // rab_or
            // 
            this.rab_or.AutoSize = true;
            this.rab_or.Checked = true;
            this.rab_or.Location = new System.Drawing.Point(61, 4);
            this.rab_or.Margin = new System.Windows.Forms.Padding(1);
            this.rab_or.Name = "rab_or";
            this.rab_or.Size = new System.Drawing.Size(46, 22);
            this.rab_or.TabIndex = 1;
            this.rab_or.TabStop = true;
            this.rab_or.Text = "OR";
            this.rab_or.UseVisualStyleBackColor = true;
            // 
            // rab_And
            // 
            this.rab_And.AutoSize = true;
            this.rab_And.Location = new System.Drawing.Point(5, 4);
            this.rab_And.Margin = new System.Windows.Forms.Padding(1);
            this.rab_And.Name = "rab_And";
            this.rab_And.Size = new System.Drawing.Size(54, 22);
            this.rab_And.TabIndex = 0;
            this.rab_And.TabStop = true;
            this.rab_And.Text = "And";
            this.rab_And.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(113, 4);
            this.radioButton1.Margin = new System.Windows.Forms.Padding(1);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(51, 22);
            this.radioButton1.TabIndex = 2;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Not";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // ComboSearchColumnBoxPro
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.Margin = new System.Windows.Forms.Padding(1);
            this.Name = "ComboSearchColumnBoxPro";
            this.Size = new System.Drawing.Size(550, 28);
            this.Load += new System.EventHandler(this.ComboSearchColumnBox_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.ComboBox cbSelectedValue;
        internal System.Windows.Forms.ComboBox cb_SearchColumn;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.RadioButton rab_or;
        private System.Windows.Forms.RadioButton rab_And;
        private System.Windows.Forms.RadioButton radioButton1;
    }
}
