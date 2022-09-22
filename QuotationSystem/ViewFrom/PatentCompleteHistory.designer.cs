namespace LawtechPTSystem.ViewFrom
{
    partial class PatentCompleteHistory
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("申請案完整歷程");
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.button1 = new System.Windows.Forms.Button();
            this.But_Expand = new System.Windows.Forms.Button();
            this.But_Collapse = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDown_size = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_size)).BeginInit();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeView1.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.treeView1.Location = new System.Drawing.Point(12, 40);
            this.treeView1.Name = "treeView1";
            treeNode1.ForeColor = System.Drawing.Color.SteelBlue;
            treeNode1.Name = "Node0";
            treeNode1.NodeFont = new System.Drawing.Font("微軟正黑體", 10F, System.Drawing.FontStyle.Bold);
            treeNode1.Text = "申請案完整歷程";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.treeView1.Size = new System.Drawing.Size(776, 605);
            this.treeView1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackgroundImage = global::LawtechPTSystem.Properties.Resources.btnCancel;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.button1.Location = new System.Drawing.Point(649, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(139, 32);
            this.button1.TabIndex = 386;
            this.button1.Text = "關  閉";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // But_Expand
            // 
            this.But_Expand.BackgroundImage = global::LawtechPTSystem.Properties.Resources.btn_28;
            this.But_Expand.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.But_Expand.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.But_Expand.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.But_Expand.Location = new System.Drawing.Point(12, 5);
            this.But_Expand.Name = "But_Expand";
            this.But_Expand.Size = new System.Drawing.Size(139, 32);
            this.But_Expand.TabIndex = 387;
            this.But_Expand.Text = "全部展開";
            this.But_Expand.UseVisualStyleBackColor = true;
            this.But_Expand.Click += new System.EventHandler(this.But_Expand_Click);
            // 
            // But_Collapse
            // 
            this.But_Collapse.BackgroundImage = global::LawtechPTSystem.Properties.Resources.btn_28;
            this.But_Collapse.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.But_Collapse.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.But_Collapse.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.But_Collapse.Location = new System.Drawing.Point(157, 5);
            this.But_Collapse.Name = "But_Collapse";
            this.But_Collapse.Size = new System.Drawing.Size(139, 32);
            this.But_Collapse.TabIndex = 388;
            this.But_Collapse.Text = "全部收合";
            this.But_Collapse.UseVisualStyleBackColor = true;
            this.But_Collapse.Click += new System.EventHandler(this.But_Collapse_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.label1.Location = new System.Drawing.Point(323, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 20);
            this.label1.TabIndex = 402;
            this.label1.Text = "字體大小";
            // 
            // numericUpDown_size
            // 
            this.numericUpDown_size.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.numericUpDown_size.Location = new System.Drawing.Point(398, 7);
            this.numericUpDown_size.Maximum = new decimal(new int[] {
            18,
            0,
            0,
            0});
            this.numericUpDown_size.Minimum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.numericUpDown_size.Name = "numericUpDown_size";
            this.numericUpDown_size.Size = new System.Drawing.Size(77, 29);
            this.numericUpDown_size.TabIndex = 401;
            this.numericUpDown_size.Value = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.numericUpDown_size.ValueChanged += new System.EventHandler(this.numericUpDown_size_ValueChanged);
            // 
            // PatentCompleteHistory
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = global::LawtechPTSystem.Properties.Resources.bg_01;
            this.CancelButton = this.button1;
            this.ClientSize = new System.Drawing.Size(800, 657);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericUpDown_size);
            this.Controls.Add(this.But_Collapse);
            this.Controls.Add(this.But_Expand);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.treeView1);
            this.Name = "PatentCompleteHistory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "案件完整歷程";
            this.Load += new System.EventHandler(this.PatentCompleteHistory_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_size)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button But_Expand;
        private System.Windows.Forms.Button But_Collapse;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDown_size;
    }
}