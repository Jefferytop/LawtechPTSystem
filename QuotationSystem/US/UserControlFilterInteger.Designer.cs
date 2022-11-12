namespace LawtechPTSystem.US
{
    partial class UserControlFilterInteger
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
            this.cb_Mode = new System.Windows.Forms.ComboBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.comboBox_Compare = new System.Windows.Forms.ComboBox();
            this.numericUpDown_Value = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.SearchDateSplitContainer1)).BeginInit();
            this.SearchDateSplitContainer1.Panel1.SuspendLayout();
            this.SearchDateSplitContainer1.Panel2.SuspendLayout();
            this.SearchDateSplitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Value)).BeginInit();
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
            this.SearchDateSplitContainer1.Panel1.Controls.Add(this.cb_Mode);
            // 
            // SearchDateSplitContainer1.Panel2
            // 
            this.SearchDateSplitContainer1.Panel2.Controls.Add(this.splitContainer1);
            this.SearchDateSplitContainer1.Size = new System.Drawing.Size(367, 29);
            this.SearchDateSplitContainer1.SplitterDistance = 149;
            this.SearchDateSplitContainer1.SplitterWidth = 2;
            this.SearchDateSplitContainer1.TabIndex = 55;
            // 
            // cb_Mode
            // 
            this.cb_Mode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_Mode.DisplayMember = "DisplayString";
            this.cb_Mode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Mode.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.cb_Mode.FormattingEnabled = true;
            this.cb_Mode.Location = new System.Drawing.Point(1, 1);
            this.cb_Mode.Margin = new System.Windows.Forms.Padding(0);
            this.cb_Mode.Name = "cb_Mode";
            this.cb_Mode.Size = new System.Drawing.Size(147, 25);
            this.cb_Mode.TabIndex = 53;
            this.cb_Mode.ValueMember = "ValueString";
            this.cb_Mode.SelectedIndexChanged += new System.EventHandler(this.cb_Mode_SelectedIndexChanged);
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
            this.splitContainer1.Panel1.Controls.Add(this.comboBox_Compare);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.numericUpDown_Value);
            this.splitContainer1.Size = new System.Drawing.Size(216, 29);
            this.splitContainer1.SplitterDistance = 106;
            this.splitContainer1.SplitterWidth = 2;
            this.splitContainer1.TabIndex = 0;
            // 
            // comboBox_Compare
            // 
            this.comboBox_Compare.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBox_Compare.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Compare.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.comboBox_Compare.FormattingEnabled = true;
            this.comboBox_Compare.Location = new System.Drawing.Point(0, 0);
            this.comboBox_Compare.Margin = new System.Windows.Forms.Padding(1);
            this.comboBox_Compare.Name = "comboBox_Compare";
            this.comboBox_Compare.Size = new System.Drawing.Size(106, 25);
            this.comboBox_Compare.TabIndex = 0;
            // 
            // numericUpDown_Value
            // 
            this.numericUpDown_Value.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numericUpDown_Value.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.numericUpDown_Value.ForeColor = System.Drawing.Color.SteelBlue;
            this.numericUpDown_Value.Location = new System.Drawing.Point(0, 0);
            this.numericUpDown_Value.Margin = new System.Windows.Forms.Padding(1);
            this.numericUpDown_Value.Name = "numericUpDown_Value";
            this.numericUpDown_Value.Size = new System.Drawing.Size(108, 25);
            this.numericUpDown_Value.TabIndex = 0;
            this.numericUpDown_Value.ThousandsSeparator = true;
            // 
            // UserControlFilterInteger
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.SearchDateSplitContainer1);
            this.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "UserControlFilterInteger";
            this.Size = new System.Drawing.Size(367, 29);
            this.Load += new System.EventHandler(this.UserControlFilterInteger_Load);
            this.SearchDateSplitContainer1.Panel1.ResumeLayout(false);
            this.SearchDateSplitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SearchDateSplitContainer1)).EndInit();
            this.SearchDateSplitContainer1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Value)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.SplitContainer SearchDateSplitContainer1;
        internal System.Windows.Forms.ComboBox cb_Mode;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ComboBox comboBox_Compare;
        private System.Windows.Forms.NumericUpDown numericUpDown_Value;
    }
}
