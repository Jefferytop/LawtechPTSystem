
namespace LawtechPTSystem.EditForm
{
    partial class EditAccountingCompany
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditAccountingCompany));
            this.chb_IsEnable = new System.Windows.Forms.CheckBox();
            this.but_Cancel = new System.Windows.Forms.Button();
            this.but_OK = new System.Windows.Forms.Button();
            this.numericUpDown_Sort = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.txt_AcountingFirmName = new System.Windows.Forms.TextBox();
            this.txt_AcountingFirm = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_LogoUrl = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.linkLabel_OpenLogo = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Sort)).BeginInit();
            this.SuspendLayout();
            // 
            // chb_IsEnable
            // 
            this.chb_IsEnable.AutoSize = true;
            this.chb_IsEnable.Checked = true;
            this.chb_IsEnable.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chb_IsEnable.Location = new System.Drawing.Point(138, 20);
            this.chb_IsEnable.Name = "chb_IsEnable";
            this.chb_IsEnable.Size = new System.Drawing.Size(15, 14);
            this.chb_IsEnable.TabIndex = 44;
            this.chb_IsEnable.UseVisualStyleBackColor = true;
            // 
            // but_Cancel
            // 
            this.but_Cancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.but_Cancel.BackgroundImage = global::LawtechPTSystem.Properties.Resources.btnCancel;
            this.but_Cancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.but_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.but_Cancel.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.but_Cancel.Location = new System.Drawing.Point(275, 303);
            this.but_Cancel.Margin = new System.Windows.Forms.Padding(4);
            this.but_Cancel.Name = "but_Cancel";
            this.but_Cancel.Size = new System.Drawing.Size(100, 32);
            this.but_Cancel.TabIndex = 43;
            this.but_Cancel.Text = "取   消";
            this.but_Cancel.UseVisualStyleBackColor = true;
            this.but_Cancel.Click += new System.EventHandler(this.but_Cancel_Click);
            // 
            // but_OK
            // 
            this.but_OK.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.but_OK.BackgroundImage = global::LawtechPTSystem.Properties.Resources.btnComfirm;
            this.but_OK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.but_OK.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.but_OK.Location = new System.Drawing.Point(163, 303);
            this.but_OK.Margin = new System.Windows.Forms.Padding(4);
            this.but_OK.Name = "but_OK";
            this.but_OK.Size = new System.Drawing.Size(100, 32);
            this.but_OK.TabIndex = 42;
            this.but_OK.Text = "確   定";
            this.but_OK.UseVisualStyleBackColor = true;
            this.but_OK.Click += new System.EventHandler(this.but_OK_Click);
            // 
            // numericUpDown_Sort
            // 
            this.numericUpDown_Sort.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.numericUpDown_Sort.Location = new System.Drawing.Point(130, 41);
            this.numericUpDown_Sort.Margin = new System.Windows.Forms.Padding(2);
            this.numericUpDown_Sort.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDown_Sort.Name = "numericUpDown_Sort";
            this.numericUpDown_Sort.Size = new System.Drawing.Size(87, 29);
            this.numericUpDown_Sort.TabIndex = 39;
            this.numericUpDown_Sort.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.label10.Location = new System.Drawing.Point(87, 45);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 20);
            this.label10.TabIndex = 35;
            this.label10.Text = "排序";
            // 
            // txt_AcountingFirmName
            // 
            this.txt_AcountingFirmName.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.txt_AcountingFirmName.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txt_AcountingFirmName.Location = new System.Drawing.Point(130, 77);
            this.txt_AcountingFirmName.Margin = new System.Windows.Forms.Padding(4);
            this.txt_AcountingFirmName.Name = "txt_AcountingFirmName";
            this.txt_AcountingFirmName.Size = new System.Drawing.Size(386, 29);
            this.txt_AcountingFirmName.TabIndex = 41;
            // 
            // txt_AcountingFirm
            // 
            this.txt_AcountingFirm.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.txt_AcountingFirm.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txt_AcountingFirm.Location = new System.Drawing.Point(363, 31);
            this.txt_AcountingFirm.Margin = new System.Windows.Forms.Padding(4);
            this.txt_AcountingFirm.Name = "txt_AcountingFirm";
            this.txt_AcountingFirm.Size = new System.Drawing.Size(48, 29);
            this.txt_AcountingFirm.TabIndex = 40;
            this.txt_AcountingFirm.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.label5.Location = new System.Drawing.Point(63, 17);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 20);
            this.label5.TabIndex = 36;
            this.label5.Text = "是否啟用";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.label4.Location = new System.Drawing.Point(55, 81);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 20);
            this.label4.TabIndex = 37;
            this.label4.Text = "公司名稱";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.label1.Location = new System.Drawing.Point(256, 36);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 20);
            this.label1.TabIndex = 38;
            this.label1.Text = "入帳公司代碼";
            this.label1.Visible = false;
            // 
            // txt_LogoUrl
            // 
            this.txt_LogoUrl.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.txt_LogoUrl.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txt_LogoUrl.Location = new System.Drawing.Point(130, 114);
            this.txt_LogoUrl.Margin = new System.Windows.Forms.Padding(4);
            this.txt_LogoUrl.Multiline = true;
            this.txt_LogoUrl.Name = "txt_LogoUrl";
            this.txt_LogoUrl.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_LogoUrl.Size = new System.Drawing.Size(386, 62);
            this.txt_LogoUrl.TabIndex = 46;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.label2.Location = new System.Drawing.Point(15, 126);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 20);
            this.label2.TabIndex = 45;
            this.label2.Text = "公司Logo URL";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(135, 179);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(191, 17);
            this.label3.TabIndex = 50;
            this.label3.Text = "§ 可用於請款單、報價單的Logo";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.BackColor = System.Drawing.Color.Transparent;
            this.label20.ForeColor = System.Drawing.Color.Blue;
            this.label20.Location = new System.Drawing.Point(135, 256);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(124, 17);
            this.label20.TabIndex = 49;
            this.label20.Text = "3.)請使用 jpg 、png";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.ForeColor = System.Drawing.Color.Blue;
            this.label15.Location = new System.Drawing.Point(135, 232);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(143, 17);
            this.label15.TabIndex = 48;
            this.label15.Text = "2.)圖檔Size 1728 x 230";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.ForeColor = System.Drawing.Color.Blue;
            this.label16.Location = new System.Drawing.Point(135, 207);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(114, 17);
            this.label16.TabIndex = 47;
            this.label16.Text = "1.)請輸入網路位置";
            // 
            // linkLabel_OpenLogo
            // 
            this.linkLabel_OpenLogo.AutoSize = true;
            this.linkLabel_OpenLogo.BackColor = System.Drawing.Color.Transparent;
            this.linkLabel_OpenLogo.Location = new System.Drawing.Point(66, 153);
            this.linkLabel_OpenLogo.Name = "linkLabel_OpenLogo";
            this.linkLabel_OpenLogo.Size = new System.Drawing.Size(65, 17);
            this.linkLabel_OpenLogo.TabIndex = 51;
            this.linkLabel_OpenLogo.TabStop = true;
            this.linkLabel_OpenLogo.Text = "開啟Logo";
            this.linkLabel_OpenLogo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel_OpenLogo_LinkClicked);
            // 
            // EditAccountingCompany
            // 
            this.AcceptButton = this.but_OK;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = global::LawtechPTSystem.Properties.Resources.EditForm_bg;
            this.CancelButton = this.but_Cancel;
            this.ClientSize = new System.Drawing.Size(532, 350);
            this.Controls.Add(this.linkLabel_OpenLogo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.txt_LogoUrl);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.chb_IsEnable);
            this.Controls.Add(this.but_Cancel);
            this.Controls.Add(this.but_OK);
            this.Controls.Add(this.numericUpDown_Sort);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txt_AcountingFirmName);
            this.Controls.Add(this.txt_AcountingFirm);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditAccountingCompany";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "編輯入帳公司";
            this.Load += new System.EventHandler(this.EditAccountingCompany_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Sort)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chb_IsEnable;
        private System.Windows.Forms.Button but_Cancel;
        private System.Windows.Forms.Button but_OK;
        private System.Windows.Forms.NumericUpDown numericUpDown_Sort;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txt_AcountingFirmName;
        private System.Windows.Forms.TextBox txt_AcountingFirm;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_LogoUrl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.LinkLabel linkLabel_OpenLogo;
    }
}