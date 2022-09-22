
namespace LawtechPTSystem.SubFrom
{
    partial class SMSsend
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SMSsend));
            this.label1 = new System.Windows.Forms.Label();
            this.txt_Phones = new System.Windows.Forms.TextBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.txt_SMContent = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.but_Cancel = new System.Windows.Forms.Button();
            this.but_OK = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.lab_Balance = new System.Windows.Forms.Label();
            this.richTextBox_SMLog = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_SMSsignature = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.lab_Count = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(46, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "1.) 輸入電話號碼";
            // 
            // txt_Phones
            // 
            this.txt_Phones.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.txt_Phones.Location = new System.Drawing.Point(50, 64);
            this.txt_Phones.Multiline = true;
            this.txt_Phones.Name = "txt_Phones";
            this.txt_Phones.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_Phones.Size = new System.Drawing.Size(432, 67);
            this.txt_Phones.TabIndex = 1;
            this.txt_Phones.Leave += new System.EventHandler(this.txt_Phones_Leave);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.linkLabel1.Location = new System.Drawing.Point(397, 41);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(64, 18);
            this.linkLabel1.TabIndex = 2;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "輸入說明";
            this.linkLabel1.Click += new System.EventHandler(this.linkLabel1_Click);
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.linkLabel2.Location = new System.Drawing.Point(397, 139);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(64, 18);
            this.linkLabel2.TabIndex = 5;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "注意事項";
            this.linkLabel2.Click += new System.EventHandler(this.linkLabel2_Click);
            // 
            // txt_SMContent
            // 
            this.txt_SMContent.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.txt_SMContent.Location = new System.Drawing.Point(50, 162);
            this.txt_SMContent.Multiline = true;
            this.txt_SMContent.Name = "txt_SMContent";
            this.txt_SMContent.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_SMContent.Size = new System.Drawing.Size(432, 92);
            this.txt_SMContent.TabIndex = 4;
            this.txt_SMContent.TextChanged += new System.EventHandler(this.txt_SMContent_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(46, 139);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "2.) 輸入簡訊內容";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.Location = new System.Drawing.Point(55, 385);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "簡訊發送Log";
            // 
            // but_Cancel
            // 
            this.but_Cancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.but_Cancel.BackgroundImage = global::LawtechPTSystem.Properties.Resources.btnCancel;
            this.but_Cancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.but_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.but_Cancel.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.but_Cancel.Location = new System.Drawing.Point(215, 561);
            this.but_Cancel.Margin = new System.Windows.Forms.Padding(1);
            this.but_Cancel.Name = "but_Cancel";
            this.but_Cancel.Size = new System.Drawing.Size(100, 32);
            this.but_Cancel.TabIndex = 482;
            this.but_Cancel.Text = "關  閉";
            this.but_Cancel.UseVisualStyleBackColor = true;
            this.but_Cancel.Click += new System.EventHandler(this.but_Cancel_Click);
            // 
            // but_OK
            // 
            this.but_OK.BackgroundImage = global::LawtechPTSystem.Properties.Resources.button_linkedin;
            this.but_OK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.but_OK.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.but_OK.ForeColor = System.Drawing.Color.White;
            this.but_OK.Location = new System.Drawing.Point(341, 324);
            this.but_OK.Margin = new System.Windows.Forms.Padding(1);
            this.but_OK.Name = "but_OK";
            this.but_OK.Size = new System.Drawing.Size(141, 35);
            this.but_OK.TabIndex = 481;
            this.but_OK.Text = "開始發送簡訊";
            this.but_OK.UseVisualStyleBackColor = true;
            this.but_OK.Click += new System.EventHandler(this.but_OK_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label5.ForeColor = System.Drawing.Color.MediumBlue;
            this.label5.Location = new System.Drawing.Point(46, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 20);
            this.label5.TabIndex = 483;
            this.label5.Text = "簡訊尚餘(則):";
            // 
            // lab_Balance
            // 
            this.lab_Balance.AutoSize = true;
            this.lab_Balance.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.lab_Balance.ForeColor = System.Drawing.Color.Brown;
            this.lab_Balance.Location = new System.Drawing.Point(155, 11);
            this.lab_Balance.Name = "lab_Balance";
            this.lab_Balance.Size = new System.Drawing.Size(18, 20);
            this.lab_Balance.TabIndex = 484;
            this.lab_Balance.Text = "0";
            // 
            // richTextBox_SMLog
            // 
            this.richTextBox_SMLog.BackColor = System.Drawing.Color.White;
            this.richTextBox_SMLog.Location = new System.Drawing.Point(50, 408);
            this.richTextBox_SMLog.Name = "richTextBox_SMLog";
            this.richTextBox_SMLog.ReadOnly = true;
            this.richTextBox_SMLog.Size = new System.Drawing.Size(432, 149);
            this.richTextBox_SMLog.TabIndex = 1015;
            this.richTextBox_SMLog.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.DarkGreen;
            this.label3.Location = new System.Drawing.Point(173, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(188, 17);
            this.label3.TabIndex = 1016;
            this.label3.Text = "輸入電話號碼(使用半形純數字) ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.DarkGreen;
            this.label6.Location = new System.Drawing.Point(221, 257);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(261, 17);
            this.label6.TabIndex = 1017;
            this.label6.Text = "簡訊內容中若有電話號碼，請務必要用-分隔";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label7.Location = new System.Drawing.Point(46, 294);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(95, 20);
            this.label7.TabIndex = 1018;
            this.label7.Text = "3.) 簡訊簽名";
            // 
            // txt_SMSsignature
            // 
            this.txt_SMSsignature.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.txt_SMSsignature.Location = new System.Drawing.Point(145, 292);
            this.txt_SMSsignature.Margin = new System.Windows.Forms.Padding(1);
            this.txt_SMSsignature.Name = "txt_SMSsignature";
            this.txt_SMSsignature.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_SMSsignature.Size = new System.Drawing.Size(337, 25);
            this.txt_SMSsignature.TabIndex = 1019;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(54, 257);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 17);
            this.label8.TabIndex = 1020;
            this.label8.Text = "字母數：";
            // 
            // lab_Count
            // 
            this.lab_Count.AutoSize = true;
            this.lab_Count.Font = new System.Drawing.Font("微軟正黑體", 10F, System.Drawing.FontStyle.Bold);
            this.lab_Count.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lab_Count.Location = new System.Drawing.Point(109, 257);
            this.lab_Count.Name = "lab_Count";
            this.lab_Count.Size = new System.Drawing.Size(16, 18);
            this.lab_Count.TabIndex = 1021;
            this.lab_Count.Text = "0";
            // 
            // SMSsend
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(236)))), ((int)(((byte)(247)))));
            this.CancelButton = this.but_Cancel;
            this.ClientSize = new System.Drawing.Size(530, 603);
            this.Controls.Add(this.lab_Count);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txt_SMSsignature);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.richTextBox_SMLog);
            this.Controls.Add(this.lab_Balance);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.but_Cancel);
            this.Controls.Add(this.but_OK);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.linkLabel2);
            this.Controls.Add(this.txt_SMContent);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.txt_Phones);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SMSsend";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "簡訊發送";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SMSsend_FormClosed);
            this.Load += new System.EventHandler(this.SMSsend_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_Phones;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.TextBox txt_SMContent;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        internal System.Windows.Forms.Button but_Cancel;
        internal System.Windows.Forms.Button but_OK;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lab_Balance;
        private System.Windows.Forms.RichTextBox richTextBox_SMLog;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_SMSsignature;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lab_Count;
    }
}