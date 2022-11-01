
namespace LawtechPTSystem.SubFrom
{
    partial class PTSUpdate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PTSUpdate));
            this.label1 = new System.Windows.Forms.Label();
            this.btn_CHeckVersion = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lab_CurrentVersion = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lab_TopVersion = new System.Windows.Forms.Label();
            this.but_Close = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.richTextBox_UpdateLog = new System.Windows.Forms.RichTextBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.lab_VersionMsg = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 20F);
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label1.Location = new System.Drawing.Point(16, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(207, 34);
            this.label1.TabIndex = 1;
            this.label1.Text = "System Update";
            // 
            // btn_CHeckVersion
            // 
            this.btn_CHeckVersion.BackgroundImage = global::LawtechPTSystem.Properties.Resources.btn_28;
            this.btn_CHeckVersion.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_CHeckVersion.Location = new System.Drawing.Point(131, 465);
            this.btn_CHeckVersion.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_CHeckVersion.Name = "btn_CHeckVersion";
            this.btn_CHeckVersion.Size = new System.Drawing.Size(133, 33);
            this.btn_CHeckVersion.TabIndex = 2;
            this.btn_CHeckVersion.Text = "開始檢查更新";
            this.btn_CHeckVersion.UseVisualStyleBackColor = true;
            this.btn_CHeckVersion.Click += new System.EventHandler(this.btn_CHeckVersion_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(128, 415);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "目前P.T.S系統版本：";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::LawtechPTSystem.Properties.Resources.UpdateIcon;
            this.pictureBox2.Location = new System.Drawing.Point(22, 408);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(90, 90);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 4;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox1.Image = global::LawtechPTSystem.Properties.Resources.technology01;
            this.pictureBox1.Location = new System.Drawing.Point(11, 42);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(658, 349);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // lab_CurrentVersion
            // 
            this.lab_CurrentVersion.AutoSize = true;
            this.lab_CurrentVersion.ForeColor = System.Drawing.Color.Blue;
            this.lab_CurrentVersion.Location = new System.Drawing.Point(270, 415);
            this.lab_CurrentVersion.Name = "lab_CurrentVersion";
            this.lab_CurrentVersion.Size = new System.Drawing.Size(20, 18);
            this.lab_CurrentVersion.TabIndex = 5;
            this.lab_CurrentVersion.Text = "--";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(128, 440);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(136, 18);
            this.label4.TabIndex = 6;
            this.label4.Text = "最新P.T.S系統版本：";
            // 
            // lab_TopVersion
            // 
            this.lab_TopVersion.AutoSize = true;
            this.lab_TopVersion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lab_TopVersion.Location = new System.Drawing.Point(270, 440);
            this.lab_TopVersion.Name = "lab_TopVersion";
            this.lab_TopVersion.Size = new System.Drawing.Size(20, 18);
            this.lab_TopVersion.TabIndex = 7;
            this.lab_TopVersion.Text = "--";
            // 
            // but_Close
            // 
            this.but_Close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.but_Close.BackgroundImage = global::LawtechPTSystem.Properties.Resources.btnCancel;
            this.but_Close.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.but_Close.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.but_Close.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.but_Close.Location = new System.Drawing.Point(281, 713);
            this.but_Close.Name = "but_Close";
            this.but_Close.Size = new System.Drawing.Size(120, 32);
            this.but_Close.TabIndex = 1011;
            this.but_Close.Text = "關  閉";
            this.but_Close.UseVisualStyleBackColor = true;
            this.but_Close.Click += new System.EventHandler(this.but_Close_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(128, 511);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 18);
            this.label6.TabIndex = 1013;
            this.label6.Text = "更新 Log：";
            // 
            // richTextBox_UpdateLog
            // 
            this.richTextBox_UpdateLog.Location = new System.Drawing.Point(131, 532);
            this.richTextBox_UpdateLog.Name = "richTextBox_UpdateLog";
            this.richTextBox_UpdateLog.ReadOnly = true;
            this.richTextBox_UpdateLog.Size = new System.Drawing.Size(341, 175);
            this.richTextBox_UpdateLog.TabIndex = 1014;
            this.richTextBox_UpdateLog.Text = "";
            // 
            // richTextBox1
            // 
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Location = new System.Drawing.Point(478, 408);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(192, 299);
            this.richTextBox1.TabIndex = 1015;
            this.richTextBox1.Text = "Note: \n更新時，請勿使用其他功能\n待更新完成後，再開始使用\nPTS專利商標事務所管理系統。\n\n此功能用於新增欄位、\n新增查詢條件、擴充功能...等。";
            // 
            // lab_VersionMsg
            // 
            this.lab_VersionMsg.AutoSize = true;
            this.lab_VersionMsg.ForeColor = System.Drawing.Color.Green;
            this.lab_VersionMsg.Location = new System.Drawing.Point(267, 473);
            this.lab_VersionMsg.Name = "lab_VersionMsg";
            this.lab_VersionMsg.Size = new System.Drawing.Size(114, 18);
            this.lab_VersionMsg.TabIndex = 1016;
            this.lab_VersionMsg.Text = "(您已是最新版本)";
            this.lab_VersionMsg.Visible = false;
            // 
            // PTSUpdate
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.CancelButton = this.but_Close;
            this.ClientSize = new System.Drawing.Size(682, 757);
            this.Controls.Add(this.lab_VersionMsg);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.richTextBox_UpdateLog);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.but_Close);
            this.Controls.Add(this.lab_TopVersion);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lab_CurrentVersion);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btn_CHeckVersion);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PTSUpdate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "PTS更新檢查";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PTSUpdate_FormClosed);
            this.Load += new System.EventHandler(this.PTSUpdate_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_CHeckVersion;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label lab_CurrentVersion;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lab_TopVersion;
        private System.Windows.Forms.Button but_Close;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RichTextBox richTextBox_UpdateLog;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label lab_VersionMsg;
    }
}