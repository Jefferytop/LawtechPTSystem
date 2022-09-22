namespace LawtechPTSystemByFirm.ViewFrom
{
    partial class TrademarkControversyCompleteHistory
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("商標異議案完整歷程");
            this.But_Collapse = new System.Windows.Forms.Button();
            this.But_Expand = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // But_Collapse
            // 
            this.But_Collapse.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.But_Collapse.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.But_Collapse.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.But_Collapse.Image = global::LawtechPTSystemByFirm.Properties.Resources.btn_27;
            this.But_Collapse.Location = new System.Drawing.Point(146, 3);
            this.But_Collapse.Margin = new System.Windows.Forms.Padding(1);
            this.But_Collapse.Name = "But_Collapse";
            this.But_Collapse.Size = new System.Drawing.Size(139, 32);
            this.But_Collapse.TabIndex = 395;
            this.But_Collapse.Text = "全部收合";
            this.But_Collapse.UseVisualStyleBackColor = true;
            this.But_Collapse.Click += new System.EventHandler(this.But_Collapse_Click);
            // 
            // But_Expand
            // 
            this.But_Expand.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.But_Expand.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.But_Expand.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.But_Expand.Image = global::LawtechPTSystemByFirm.Properties.Resources.btn_27;
            this.But_Expand.Location = new System.Drawing.Point(1, 3);
            this.But_Expand.Margin = new System.Windows.Forms.Padding(1);
            this.But_Expand.Name = "But_Expand";
            this.But_Expand.Size = new System.Drawing.Size(139, 32);
            this.But_Expand.TabIndex = 394;
            this.But_Expand.Text = "全部展開";
            this.But_Expand.UseVisualStyleBackColor = true;
            this.But_Expand.Click += new System.EventHandler(this.But_Expand_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.button1.Image = global::LawtechPTSystemByFirm.Properties.Resources.btnCancel;
            this.button1.Location = new System.Drawing.Point(554, 3);
            this.button1.Margin = new System.Windows.Forms.Padding(1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(139, 32);
            this.button1.TabIndex = 393;
            this.button1.Text = "關  閉";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeView1.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.treeView1.Location = new System.Drawing.Point(1, 39);
            this.treeView1.Name = "treeView1";
            treeNode1.ForeColor = System.Drawing.Color.SteelBlue;
            treeNode1.Name = "Node0";
            treeNode1.NodeFont = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            treeNode1.Text = "商標異議案完整歷程";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1});
            this.treeView1.Size = new System.Drawing.Size(692, 479);
            this.treeView1.TabIndex = 396;
            // 
            // TrademarkControversyCompleteHistory
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CancelButton = this.button1;
            this.ClientSize = new System.Drawing.Size(696, 519);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.But_Collapse);
            this.Controls.Add(this.But_Expand);
            this.Controls.Add(this.button1);
            this.Name = "TrademarkControversyCompleteHistory";
            this.Text = "商標異議案完整歷程";
            this.Load += new System.EventHandler(this.TrademarkControversyCompleteHistory_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button But_Collapse;
        private System.Windows.Forms.Button But_Expand;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TreeView treeView1;
    }
}