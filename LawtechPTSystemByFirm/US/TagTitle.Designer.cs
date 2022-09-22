namespace LawtechPTSystemByFirm.US
{
    partial class TagTitle
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
            this.labTagTitleName = new System.Windows.Forms.Label();
            this.pic_R = new System.Windows.Forms.PictureBox();
            this.pic_L = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pic_R)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_L)).BeginInit();
            this.SuspendLayout();
            // 
            // labTagTitleName
            // 
            this.labTagTitleName.AutoSize = true;
            this.labTagTitleName.BackColor = System.Drawing.Color.Transparent;
            this.labTagTitleName.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.labTagTitleName.Location = new System.Drawing.Point(13, 5);
            this.labTagTitleName.Name = "labTagTitleName";
            this.labTagTitleName.Size = new System.Drawing.Size(49, 18);
            this.labTagTitleName.TabIndex = 5;
            this.labTagTitleName.Text = "label1";
            // 
            // pic_R
            // 
            this.pic_R.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pic_R.Dock = System.Windows.Forms.DockStyle.Right;
            this.pic_R.Image = global::LawtechPTSystemByFirm.Properties.Resources.Tag5_R;
            this.pic_R.Location = new System.Drawing.Point(175, 0);
            this.pic_R.Margin = new System.Windows.Forms.Padding(0);
            this.pic_R.Name = "pic_R";
            this.pic_R.Size = new System.Drawing.Size(17, 32);
            this.pic_R.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_R.TabIndex = 4;
            this.pic_R.TabStop = false;
            // 
            // pic_L
            // 
            this.pic_L.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pic_L.Dock = System.Windows.Forms.DockStyle.Left;
            this.pic_L.Image = global::LawtechPTSystemByFirm.Properties.Resources.Tag5_L;
            this.pic_L.Location = new System.Drawing.Point(0, 0);
            this.pic_L.Margin = new System.Windows.Forms.Padding(0);
            this.pic_L.Name = "pic_L";
            this.pic_L.Size = new System.Drawing.Size(10, 32);
            this.pic_L.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_L.TabIndex = 3;
            this.pic_L.TabStop = false;
            // 
            // TagTitle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::LawtechPTSystemByFirm.Properties.Resources.Tag5_bg;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.labTagTitleName);
            this.Controls.Add(this.pic_R);
            this.Controls.Add(this.pic_L);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(1);
            this.Name = "TagTitle";
            this.Size = new System.Drawing.Size(192, 32);
            ((System.ComponentModel.ISupportInitialize)(this.pic_R)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_L)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labTagTitleName;
        private System.Windows.Forms.PictureBox pic_R;
        private System.Windows.Forms.PictureBox pic_L;
    }
}
