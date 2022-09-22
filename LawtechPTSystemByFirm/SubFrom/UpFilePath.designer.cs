namespace LawtechPTSystemByFirm.SubFrom
{
    partial class UpFilePath
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpFilePath));
            this.button2 = new System.Windows.Forms.Button();
            this.txt_FileServerFolder = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lab_FullPath = new System.Windows.Forms.Label();
            this.but_OK = new System.Windows.Forms.Button();
            this.but_Cancel = new System.Windows.Forms.Button();
            this.but_SelectFolder = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txt_IntranetPath = new System.Windows.Forms.TextBox();
            this.but_SelectFolderLan = new System.Windows.Forms.Button();
            this.txt_FileServer_IP = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txt_FileServer_Password = new System.Windows.Forms.TextBox();
            this.txt_FileServer_Account = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_LocalhostPath = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.cb_IsFileServer = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.BackgroundImage = global::LawtechPTSystemByFirm.Properties.Resources.btn_28;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.button2.Location = new System.Drawing.Point(359, 258);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 30);
            this.button2.TabIndex = 4;
            this.button2.Text = "測試連結";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txt_FileServerFolder
            // 
            this.txt_FileServerFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_FileServerFolder.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.txt_FileServerFolder.Location = new System.Drawing.Point(408, 55);
            this.txt_FileServerFolder.Name = "txt_FileServerFolder";
            this.txt_FileServerFolder.Size = new System.Drawing.Size(17, 29);
            this.txt_FileServerFolder.TabIndex = 3;
            this.txt_FileServerFolder.Visible = false;
            this.txt_FileServerFolder.TextChanged += new System.EventHandler(this.txt_FileServer_IP_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.label5.Location = new System.Drawing.Point(324, 61);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 18);
            this.label5.TabIndex = 26;
            this.label5.Text = "資料夾名稱";
            this.label5.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微軟正黑體", 9F);
            this.label4.Location = new System.Drawing.Point(16, 336);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(333, 16);
            this.label4.TabIndex = 25;
            this.label4.Text = "預設資料夾名稱OfficeSystemData(系統自動建立，請勿更改)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.label3.Location = new System.Drawing.Point(15, 288);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(134, 18);
            this.label3.TabIndex = 24;
            this.label3.Text = "預設上傳檔案位置：";
            // 
            // lab_FullPath
            // 
            this.lab_FullPath.AutoSize = true;
            this.lab_FullPath.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.lab_FullPath.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.lab_FullPath.Location = new System.Drawing.Point(22, 311);
            this.lab_FullPath.Name = "lab_FullPath";
            this.lab_FullPath.Size = new System.Drawing.Size(23, 20);
            this.lab_FullPath.TabIndex = 23;
            this.lab_FullPath.Text = "--";
            // 
            // but_OK
            // 
            this.but_OK.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.but_OK.BackgroundImage = global::LawtechPTSystemByFirm.Properties.Resources.btnComfirm;
            this.but_OK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.but_OK.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.but_OK.Location = new System.Drawing.Point(154, 404);
            this.but_OK.Name = "but_OK";
            this.but_OK.Size = new System.Drawing.Size(100, 30);
            this.but_OK.TabIndex = 1;
            this.but_OK.Text = "確定更改";
            this.but_OK.UseVisualStyleBackColor = true;
            this.but_OK.Click += new System.EventHandler(this.but_OK_Click);
            // 
            // but_Cancel
            // 
            this.but_Cancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.but_Cancel.BackColor = System.Drawing.Color.Transparent;
            this.but_Cancel.BackgroundImage = global::LawtechPTSystemByFirm.Properties.Resources.btnCancel;
            this.but_Cancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.but_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.but_Cancel.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.but_Cancel.Location = new System.Drawing.Point(260, 404);
            this.but_Cancel.Name = "but_Cancel";
            this.but_Cancel.Size = new System.Drawing.Size(100, 30);
            this.but_Cancel.TabIndex = 2;
            this.but_Cancel.Text = "取    消";
            this.but_Cancel.UseVisualStyleBackColor = false;
            this.but_Cancel.Click += new System.EventHandler(this.but_Cancel_Click);
            // 
            // but_SelectFolder
            // 
            this.but_SelectFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.but_SelectFolder.BackgroundImage = global::LawtechPTSystemByFirm.Properties.Resources.btn_28;
            this.but_SelectFolder.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.but_SelectFolder.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.but_SelectFolder.Location = new System.Drawing.Point(358, 19);
            this.but_SelectFolder.Name = "but_SelectFolder";
            this.but_SelectFolder.Size = new System.Drawing.Size(75, 27);
            this.but_SelectFolder.TabIndex = 1;
            this.but_SelectFolder.Text = "檔案路徑";
            this.but_SelectFolder.UseVisualStyleBackColor = true;
            this.but_SelectFolder.Click += new System.EventHandler(this.but_SelectFolder_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.lab_FullPath);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox1.Location = new System.Drawing.Point(10, 38);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(495, 362);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "設定檔案上傳指定路徑";
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(18, 162);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(14, 13);
            this.radioButton2.TabIndex = 38;
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(18, 22);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(14, 13);
            this.radioButton1.TabIndex = 37;
            this.radioButton1.TabStop = true;
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txt_IntranetPath);
            this.groupBox3.Controls.Add(this.but_SelectFolderLan);
            this.groupBox3.Controls.Add(this.txt_FileServer_IP);
            this.groupBox3.Controls.Add(this.txt_FileServerFolder);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.txt_FileServer_Password);
            this.groupBox3.Controls.Add(this.txt_FileServer_Account);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Location = new System.Drawing.Point(26, 161);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(439, 97);
            this.groupBox3.TabIndex = 36;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "區域網路路徑";
            // 
            // txt_IntranetPath
            // 
            this.txt_IntranetPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_IntranetPath.BackColor = System.Drawing.Color.White;
            this.txt_IntranetPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_IntranetPath.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.txt_IntranetPath.Location = new System.Drawing.Point(25, 26);
            this.txt_IntranetPath.Name = "txt_IntranetPath";
            this.txt_IntranetPath.ReadOnly = true;
            this.txt_IntranetPath.Size = new System.Drawing.Size(333, 29);
            this.txt_IntranetPath.TabIndex = 37;
            this.txt_IntranetPath.TextChanged += new System.EventHandler(this.txt_IntranetPath_TextChanged);
            // 
            // but_SelectFolderLan
            // 
            this.but_SelectFolderLan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.but_SelectFolderLan.BackgroundImage = global::LawtechPTSystemByFirm.Properties.Resources.btn_28;
            this.but_SelectFolderLan.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.but_SelectFolderLan.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.but_SelectFolderLan.Location = new System.Drawing.Point(358, 27);
            this.but_SelectFolderLan.Name = "but_SelectFolderLan";
            this.but_SelectFolderLan.Size = new System.Drawing.Size(75, 27);
            this.but_SelectFolderLan.TabIndex = 36;
            this.but_SelectFolderLan.Text = "檔案路徑";
            this.but_SelectFolderLan.UseVisualStyleBackColor = true;
            this.but_SelectFolderLan.Click += new System.EventHandler(this.but_SelectFolderLan_Click);
            // 
            // txt_FileServer_IP
            // 
            this.txt_FileServer_IP.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_FileServer_IP.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.txt_FileServer_IP.Location = new System.Drawing.Point(271, 55);
            this.txt_FileServer_IP.Name = "txt_FileServer_IP";
            this.txt_FileServer_IP.Size = new System.Drawing.Size(37, 29);
            this.txt_FileServer_IP.TabIndex = 0;
            this.txt_FileServer_IP.Visible = false;
            this.txt_FileServer_IP.TextChanged += new System.EventHandler(this.txt_FileServer_IP_TextChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.label13.Location = new System.Drawing.Point(213, 61);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(52, 18);
            this.label13.TabIndex = 34;
            this.label13.Text = "IP 位址";
            this.label13.Visible = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.label11.Location = new System.Drawing.Point(54, 66);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(36, 18);
            this.label11.TabIndex = 30;
            this.label11.Text = "帳號";
            this.label11.Visible = false;
            // 
            // txt_FileServer_Password
            // 
            this.txt_FileServer_Password.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_FileServer_Password.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.txt_FileServer_Password.Location = new System.Drawing.Point(179, 61);
            this.txt_FileServer_Password.Name = "txt_FileServer_Password";
            this.txt_FileServer_Password.Size = new System.Drawing.Size(29, 29);
            this.txt_FileServer_Password.TabIndex = 2;
            this.txt_FileServer_Password.Visible = false;
            // 
            // txt_FileServer_Account
            // 
            this.txt_FileServer_Account.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_FileServer_Account.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.txt_FileServer_Account.Location = new System.Drawing.Point(96, 61);
            this.txt_FileServer_Account.Name = "txt_FileServer_Account";
            this.txt_FileServer_Account.Size = new System.Drawing.Size(29, 29);
            this.txt_FileServer_Account.TabIndex = 1;
            this.txt_FileServer_Account.Visible = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.label12.Location = new System.Drawing.Point(137, 66);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(36, 18);
            this.label12.TabIndex = 32;
            this.label12.Text = "密碼";
            this.label12.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txt_LocalhostPath);
            this.groupBox2.Controls.Add(this.but_SelectFolder);
            this.groupBox2.Location = new System.Drawing.Point(26, 22);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(439, 133);
            this.groupBox2.TabIndex = 35;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "本機路徑(預設路徑)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微軟正黑體", 9F);
            this.label7.Location = new System.Drawing.Point(25, 109);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(310, 16);
            this.label7.TabIndex = 42;
            this.label7.Text = "4. 個人路徑設定: 「個人資料設定」-->「修改個人資料」";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微軟正黑體", 9F);
            this.label6.Location = new System.Drawing.Point(25, 90);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(285, 16);
            this.label6.TabIndex = 41;
            this.label6.Text = "3. 啟用檔案上傳功能時，如未設定路徑則帶預設路徑";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 9F);
            this.label2.Location = new System.Drawing.Point(25, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(202, 16);
            this.label2.TabIndex = 40;
            this.label2.Text = "2. 每位User需各行設定本機檔案路徑";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 9F);
            this.label1.Location = new System.Drawing.Point(25, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(215, 16);
            this.label1.TabIndex = 39;
            this.label1.Text = "1. 建議使用，並搭配DropBox雲端硬碟";
            // 
            // txt_LocalhostPath
            // 
            this.txt_LocalhostPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_LocalhostPath.BackColor = System.Drawing.Color.White;
            this.txt_LocalhostPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txt_LocalhostPath.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.txt_LocalhostPath.Location = new System.Drawing.Point(25, 18);
            this.txt_LocalhostPath.Name = "txt_LocalhostPath";
            this.txt_LocalhostPath.ReadOnly = true;
            this.txt_LocalhostPath.Size = new System.Drawing.Size(333, 29);
            this.txt_LocalhostPath.TabIndex = 35;
            this.txt_LocalhostPath.TextChanged += new System.EventHandler(this.txt_LocalhostPath_TextChanged);
            // 
            // cb_IsFileServer
            // 
            this.cb_IsFileServer.AutoSize = true;
            this.cb_IsFileServer.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cb_IsFileServer.Location = new System.Drawing.Point(12, 27);
            this.cb_IsFileServer.Name = "cb_IsFileServer";
            this.cb_IsFileServer.Size = new System.Drawing.Size(156, 24);
            this.cb_IsFileServer.TabIndex = 3;
            this.cb_IsFileServer.Text = "啟用檔案上傳功能";
            this.cb_IsFileServer.UseVisualStyleBackColor = true;
            this.cb_IsFileServer.CheckedChanged += new System.EventHandler(this.cb_FTPServerEnable_CheckedChanged);
            // 
            // UpFilePath
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::LawtechPTSystemByFirm.Properties.Resources.EditForm_bg;
            this.CancelButton = this.but_Cancel;
            this.ClientSize = new System.Drawing.Size(515, 442);
            this.Controls.Add(this.cb_IsFileServer);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.but_OK);
            this.Controls.Add(this.but_Cancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UpFilePath";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "設定檔案上傳路徑";
            this.Load += new System.EventHandler(this.UpFilePath_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txt_FileServerFolder;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lab_FullPath;
        private System.Windows.Forms.Button but_OK;
        private System.Windows.Forms.Button but_Cancel;
        private System.Windows.Forms.Button but_SelectFolder;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.TextBox txt_FileServer_Password;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txt_FileServer_Account;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txt_FileServer_IP;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txt_LocalhostPath;
        private System.Windows.Forms.CheckBox cb_IsFileServer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_IntranetPath;
        private System.Windows.Forms.Button but_SelectFolderLan;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
    }
}