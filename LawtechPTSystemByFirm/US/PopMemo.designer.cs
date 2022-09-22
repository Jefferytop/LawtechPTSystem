namespace LawtechPTSystemByFirm.US
{
    partial class PopMemo
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
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.txt_Content = new System.Windows.Forms.TextBox();
            this.but_Close = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button2.BackgroundImage = global::LawtechPTSystemByFirm.Properties.Resources.btnCancel;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point(251, 507);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 32);
            this.button2.TabIndex = 5;
            this.button2.Text = "取消";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button1.BackgroundImage = global::LawtechPTSystemByFirm.Properties.Resources.btnComfirm;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Location = new System.Drawing.Point(145, 507);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 32);
            this.button1.TabIndex = 4;
            this.button1.Text = "確定";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txt_Content
            // 
            this.txt_Content.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_Content.BackColor = System.Drawing.Color.White;
            this.txt_Content.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.txt_Content.Location = new System.Drawing.Point(2, 3);
            this.txt_Content.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txt_Content.MaxLength = 4000;
            this.txt_Content.Multiline = true;
            this.txt_Content.Name = "txt_Content";
            this.txt_Content.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_Content.Size = new System.Drawing.Size(492, 496);
            this.txt_Content.TabIndex = 3;
            // 
            // but_Close
            // 
            this.but_Close.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.but_Close.BackgroundImage = global::LawtechPTSystemByFirm.Properties.Resources.btnCancel;
            this.but_Close.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.but_Close.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.but_Close.Location = new System.Drawing.Point(198, 507);
            this.but_Close.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.but_Close.Name = "but_Close";
            this.but_Close.Size = new System.Drawing.Size(100, 32);
            this.but_Close.TabIndex = 6;
            this.but_Close.Text = "關  閉";
            this.but_Close.UseVisualStyleBackColor = true;
            this.but_Close.Visible = false;
            this.but_Close.Click += new System.EventHandler(this.button2_Click);
            // 
            // PopMemo
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::LawtechPTSystemByFirm.Properties.Resources.bg_01;
            this.CancelButton = this.button2;
            this.ClientSize = new System.Drawing.Size(497, 550);
            this.Controls.Add(this.txt_Content);
            this.Controls.Add(this.but_Close);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "PopMemo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PopMemo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txt_Content;
        private System.Windows.Forms.Button but_Close;
    }
}