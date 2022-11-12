﻿namespace LawtechPTSystem.EditForm
{
    partial class EditInventor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditInventor));
            this.butCancel = new System.Windows.Forms.Button();
            this.butOK = new System.Windows.Forms.Button();
            this.txt_ID = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_GivenName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_FamilyName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_InventorName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_Address = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_FullEnName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_Remark = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_InventorCountryCitizenship = new System.Windows.Forms.TextBox();
            this.label37 = new System.Windows.Forms.Label();
            this.txt_MiddleName = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // butCancel
            // 
            this.butCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.butCancel.BackgroundImage = global::LawtechPTSystem.Properties.Resources.btnCancel;
            this.butCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.butCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.butCancel.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.butCancel.Location = new System.Drawing.Point(179, 487);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(100, 32);
            this.butCancel.TabIndex = 27;
            this.butCancel.Text = "取消";
            this.butCancel.UseVisualStyleBackColor = true;
            this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
            // 
            // butOK
            // 
            this.butOK.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.butOK.BackgroundImage = global::LawtechPTSystem.Properties.Resources.btnComfirm;
            this.butOK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.butOK.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.butOK.Location = new System.Drawing.Point(73, 486);
            this.butOK.Name = "butOK";
            this.butOK.Size = new System.Drawing.Size(100, 32);
            this.butOK.TabIndex = 26;
            this.butOK.Text = "確定";
            this.butOK.UseVisualStyleBackColor = true;
            this.butOK.Click += new System.EventHandler(this.butOK_Click);
            // 
            // txt_ID
            // 
            this.txt_ID.Location = new System.Drawing.Point(121, 176);
            this.txt_ID.Margin = new System.Windows.Forms.Padding(1);
            this.txt_ID.Name = "txt_ID";
            this.txt_ID.Size = new System.Drawing.Size(219, 29);
            this.txt_ID.TabIndex = 25;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(37, 179);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 20);
            this.label4.TabIndex = 24;
            this.label4.Text = "身份證(ID)";
            // 
            // txt_GivenName
            // 
            this.txt_GivenName.Location = new System.Drawing.Point(121, 52);
            this.txt_GivenName.Margin = new System.Windows.Forms.Padding(1);
            this.txt_GivenName.Name = "txt_GivenName";
            this.txt_GivenName.Size = new System.Drawing.Size(219, 29);
            this.txt_GivenName.TabIndex = 23;
            this.txt_GivenName.TextChanged += new System.EventHandler(this.txt_FamilyName_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Location = new System.Drawing.Point(23, 56);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 20);
            this.label3.TabIndex = 22;
            this.label3.Text = "GivenName";
            // 
            // txt_FamilyName
            // 
            this.txt_FamilyName.Location = new System.Drawing.Point(121, 114);
            this.txt_FamilyName.Margin = new System.Windows.Forms.Padding(1);
            this.txt_FamilyName.Name = "txt_FamilyName";
            this.txt_FamilyName.Size = new System.Drawing.Size(219, 29);
            this.txt_FamilyName.TabIndex = 21;
            this.txt_FamilyName.TextChanged += new System.EventHandler(this.txt_FamilyName_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(18, 117);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 20);
            this.label2.TabIndex = 20;
            this.label2.Text = "FamilyName";
            // 
            // txt_InventorName
            // 
            this.txt_InventorName.Location = new System.Drawing.Point(121, 21);
            this.txt_InventorName.Margin = new System.Windows.Forms.Padding(1);
            this.txt_InventorName.Name = "txt_InventorName";
            this.txt_InventorName.Size = new System.Drawing.Size(219, 29);
            this.txt_InventorName.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(72, 25);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 20);
            this.label1.TabIndex = 18;
            this.label1.Text = "姓  名";
            // 
            // txt_Address
            // 
            this.txt_Address.Location = new System.Drawing.Point(121, 240);
            this.txt_Address.Margin = new System.Windows.Forms.Padding(1);
            this.txt_Address.Multiline = true;
            this.txt_Address.Name = "txt_Address";
            this.txt_Address.Size = new System.Drawing.Size(219, 105);
            this.txt_Address.TabIndex = 29;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(80, 243);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 20);
            this.label5.TabIndex = 28;
            this.label5.Text = "地址";
            // 
            // txt_FullEnName
            // 
            this.txt_FullEnName.Location = new System.Drawing.Point(121, 145);
            this.txt_FullEnName.Margin = new System.Windows.Forms.Padding(1);
            this.txt_FullEnName.Name = "txt_FullEnName";
            this.txt_FullEnName.Size = new System.Drawing.Size(219, 29);
            this.txt_FullEnName.TabIndex = 31;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Location = new System.Drawing.Point(46, 148);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 20);
            this.label7.TabIndex = 30;
            this.label7.Text = "英文全名";
            // 
            // txt_Remark
            // 
            this.txt_Remark.Location = new System.Drawing.Point(121, 347);
            this.txt_Remark.Margin = new System.Windows.Forms.Padding(1);
            this.txt_Remark.Multiline = true;
            this.txt_Remark.Name = "txt_Remark";
            this.txt_Remark.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_Remark.Size = new System.Drawing.Size(219, 133);
            this.txt_Remark.TabIndex = 33;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(78, 381);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 20);
            this.label6.TabIndex = 32;
            this.label6.Text = "備註";
            // 
            // txt_InventorCountryCitizenship
            // 
            this.txt_InventorCountryCitizenship.BackColor = System.Drawing.Color.White;
            this.txt_InventorCountryCitizenship.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.txt_InventorCountryCitizenship.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txt_InventorCountryCitizenship.Location = new System.Drawing.Point(121, 208);
            this.txt_InventorCountryCitizenship.Margin = new System.Windows.Forms.Padding(2);
            this.txt_InventorCountryCitizenship.Name = "txt_InventorCountryCitizenship";
            this.txt_InventorCountryCitizenship.Size = new System.Drawing.Size(219, 29);
            this.txt_InventorCountryCitizenship.TabIndex = 335;
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.BackColor = System.Drawing.Color.Transparent;
            this.label37.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.label37.ForeColor = System.Drawing.Color.Black;
            this.label37.Location = new System.Drawing.Point(78, 214);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(41, 20);
            this.label37.TabIndex = 336;
            this.label37.Text = "國籍";
            // 
            // txt_MiddleName
            // 
            this.txt_MiddleName.Location = new System.Drawing.Point(121, 83);
            this.txt_MiddleName.Margin = new System.Windows.Forms.Padding(1);
            this.txt_MiddleName.Name = "txt_MiddleName";
            this.txt_MiddleName.Size = new System.Drawing.Size(219, 29);
            this.txt_MiddleName.TabIndex = 338;
            this.txt_MiddleName.TextChanged += new System.EventHandler(this.txt_FamilyName_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Location = new System.Drawing.Point(16, 86);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(107, 20);
            this.label8.TabIndex = 337;
            this.label8.Text = "MiddleName";
            // 
            // EditInventor
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = global::LawtechPTSystem.Properties.Resources.EditForm_bg;
            this.CancelButton = this.butCancel;
            this.ClientSize = new System.Drawing.Size(353, 530);
            this.Controls.Add(this.txt_MiddleName);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txt_InventorCountryCitizenship);
            this.Controls.Add(this.label37);
            this.Controls.Add(this.txt_Remark);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txt_FullEnName);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txt_Address);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.butOK);
            this.Controls.Add(this.txt_ID);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_GivenName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_FamilyName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_InventorName);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditInventor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "編輯發明人";
            this.Load += new System.EventHandler(this.EditInventor_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button butCancel;
        private System.Windows.Forms.Button butOK;
        private System.Windows.Forms.TextBox txt_ID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_GivenName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_FamilyName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_InventorName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_Address;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_FullEnName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_Remark;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_InventorCountryCitizenship;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.TextBox txt_MiddleName;
        private System.Windows.Forms.Label label8;
    }
}