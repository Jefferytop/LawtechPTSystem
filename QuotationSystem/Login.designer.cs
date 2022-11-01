namespace LawtechPTSystem
{
    partial class Login
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該公開 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改這個方法的內容。
        ///
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.but_Cancel = new System.Windows.Forms.Button();
            this.but_OK = new System.Windows.Forms.Button();
            this.txt_Password = new System.Windows.Forms.TextBox();
            this.txt_Account = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label_DBName = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lab_MACSettingType = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // but_Cancel
            // 
            this.but_Cancel.BackColor = System.Drawing.Color.Transparent;
            this.but_Cancel.BackgroundImage = global::LawtechPTSystem.Properties.Resources.btnCancel;
            this.but_Cancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.but_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.but_Cancel.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.but_Cancel.FlatAppearance.BorderSize = 0;
            this.but_Cancel.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.but_Cancel.ForeColor = System.Drawing.Color.Black;
            this.but_Cancel.Location = new System.Drawing.Point(129, 244);
            this.but_Cancel.Margin = new System.Windows.Forms.Padding(0);
            this.but_Cancel.Name = "but_Cancel";
            this.but_Cancel.Size = new System.Drawing.Size(100, 30);
            this.but_Cancel.TabIndex = 11;
            this.but_Cancel.Text = "離 開";
            this.but_Cancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.but_Cancel.UseVisualStyleBackColor = true;
            this.but_Cancel.Click += new System.EventHandler(this.but_Cancel_Click);
            // 
            // but_OK
            // 
            this.but_OK.BackColor = System.Drawing.Color.Transparent;
            this.but_OK.BackgroundImage = global::LawtechPTSystem.Properties.Resources.btnEnter;
            this.but_OK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.but_OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.but_OK.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.but_OK.FlatAppearance.BorderSize = 0;
            this.but_OK.Font = new System.Drawing.Font("微軟正黑體", 14F);
            this.but_OK.ForeColor = System.Drawing.Color.White;
            this.but_OK.Location = new System.Drawing.Point(20, 244);
            this.but_OK.Margin = new System.Windows.Forms.Padding(0);
            this.but_OK.Name = "but_OK";
            this.but_OK.Size = new System.Drawing.Size(100, 30);
            this.but_OK.TabIndex = 10;
            this.but_OK.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.but_OK.UseVisualStyleBackColor = true;
            this.but_OK.Click += new System.EventHandler(this.but_OK_Click);
            // 
            // txt_Password
            // 
            this.txt_Password.BackColor = System.Drawing.Color.Gainsboro;
            this.txt_Password.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Password.Font = new System.Drawing.Font("微軟正黑體", 14F);
            this.txt_Password.Location = new System.Drawing.Point(15, 144);
            this.txt_Password.Margin = new System.Windows.Forms.Padding(0);
            this.txt_Password.Name = "txt_Password";
            this.txt_Password.PasswordChar = '*';
            this.txt_Password.Size = new System.Drawing.Size(214, 32);
            this.txt_Password.TabIndex = 9;
            // 
            // txt_Account
            // 
            this.txt_Account.BackColor = System.Drawing.Color.Gainsboro;
            this.txt_Account.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_Account.Font = new System.Drawing.Font("微軟正黑體", 14F);
            this.txt_Account.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.txt_Account.Location = new System.Drawing.Point(15, 74);
            this.txt_Account.Margin = new System.Windows.Forms.Padding(0);
            this.txt_Account.Name = "txt_Account";
            this.txt_Account.Size = new System.Drawing.Size(214, 32);
            this.txt_Account.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 8F);
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(696, 470);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 15);
            this.label2.TabIndex = 16;
            this.label2.Text = "V.2022.09.28";
            // 
            // label_DBName
            // 
            this.label_DBName.AutoSize = true;
            this.label_DBName.BackColor = System.Drawing.Color.Transparent;
            this.label_DBName.Font = new System.Drawing.Font("微軟正黑體", 8F);
            this.label_DBName.ForeColor = System.Drawing.Color.Blue;
            this.label_DBName.Location = new System.Drawing.Point(18, 470);
            this.label_DBName.Name = "label_DBName";
            this.label_DBName.Size = new System.Drawing.Size(50, 15);
            this.label_DBName.TabIndex = 17;
            this.label_DBName.Text = "dbname";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImage = global::LawtechPTSystem.Properties.Resources.login_bg1;
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBox3);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txt_Account);
            this.panel1.Controls.Add(this.txt_Password);
            this.panel1.Controls.Add(this.but_OK);
            this.panel1.Controls.Add(this.but_Cancel);
            this.panel1.Location = new System.Drawing.Point(279, 119);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(254, 290);
            this.panel1.TabIndex = 18;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label5.ForeColor = System.Drawing.Color.SteelBlue;
            this.label5.Location = new System.Drawing.Point(9, 212);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(241, 16);
            this.label5.TabIndex = 25;
            this.label5.Text = "2.) 因安全考量，建議避免多人使用同一帳號";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.ForeColor = System.Drawing.Color.SteelBlue;
            this.label1.Location = new System.Drawing.Point(9, 191);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 16);
            this.label1.TabIndex = 24;
            this.label1.Text = "1.) 請確定網路連線正常";
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackgroundImage = global::LawtechPTSystem.Properties.Resources.LoginIcon;
            this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pictureBox3.Location = new System.Drawing.Point(88, 6);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(69, 31);
            this.pictureBox3.TabIndex = 22;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.pictureBox2.Location = new System.Drawing.Point(3, 40);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(238, 1);
            this.pictureBox2.TabIndex = 21;
            this.pictureBox2.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.label4.Location = new System.Drawing.Point(19, 121);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 21);
            this.label4.TabIndex = 20;
            this.label4.Text = "密 碼：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.label3.Location = new System.Drawing.Point(19, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 21);
            this.label3.TabIndex = 19;
            this.label3.Text = "帳 號：";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.ImageLocation = "E:\\VisualStudioProject_ggamingproxy\\PatetnTrademarkByMiirProject\\PatetnTrademarkB" +
    "yMiirProject\\LawtechPTSystem\\QuotationSystem\\bin\\Release\\logo2018.png";
            this.pictureBox1.Location = new System.Drawing.Point(12, 44);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(125, 125);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 19;
            this.pictureBox1.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.label6.ForeColor = System.Drawing.Color.DimGray;
            this.label6.Location = new System.Drawing.Point(555, 468);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(131, 18);
            this.label6.TabIndex = 20;
            this.label6.Text = "版權所有 ‧ 翻版必究";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // lab_MACSettingType
            // 
            this.lab_MACSettingType.AutoSize = true;
            this.lab_MACSettingType.BackColor = System.Drawing.Color.Transparent;
            this.lab_MACSettingType.Font = new System.Drawing.Font("微軟正黑體", 8F);
            this.lab_MACSettingType.ForeColor = System.Drawing.Color.Green;
            this.lab_MACSettingType.Location = new System.Drawing.Point(18, 452);
            this.lab_MACSettingType.Name = "lab_MACSettingType";
            this.lab_MACSettingType.Size = new System.Drawing.Size(10, 15);
            this.lab_MACSettingType.TabIndex = 21;
            this.lab_MACSettingType.Text = ".";
            // 
            // Login
            // 
            this.AcceptButton = this.but_OK;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.RosyBrown;
            this.BackgroundImage = global::LawtechPTSystem.Properties.Resources.login2;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.CancelButton = this.but_Cancel;
            this.ClientSize = new System.Drawing.Size(800, 500);
            this.Controls.Add(this.lab_MACSettingType);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label_DBName);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.TransparencyKey = System.Drawing.Color.RosyBrown;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Login_FormClosed);
            this.Load += new System.EventHandler(this.Login_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Login_MouseDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button but_Cancel;
        private System.Windows.Forms.Button but_OK;
        private System.Windows.Forms.TextBox txt_Password;
        private System.Windows.Forms.TextBox txt_Account;
        //private Sunisoft.IrisSkin.SkinEngine skinEngine1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label_DBName;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lab_MACSettingType;
    }
}