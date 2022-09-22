
namespace LawtechPTSystem.EditForm
{
    partial class EditMACsetting
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
            this.cmb_Account = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBox_IsEnable = new System.Windows.Forms.CheckBox();
            this.txt_Memo = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_MAC = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.butCancel = new System.Windows.Forms.Button();
            this.butOK = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmb_Account
            // 
            this.cmb_Account.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.cmb_Account.FormattingEnabled = true;
            this.cmb_Account.Location = new System.Drawing.Point(112, 102);
            this.cmb_Account.Name = "cmb_Account";
            this.cmb_Account.Size = new System.Drawing.Size(191, 28);
            this.cmb_Account.TabIndex = 41;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 9F);
            this.label1.Location = new System.Drawing.Point(115, 70);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(166, 16);
            this.label1.TabIndex = 40;
            this.label1.Text = "例：01:00:5e:xx:xx:xx 共17碼";
            // 
            // checkBox_IsEnable
            // 
            this.checkBox_IsEnable.AutoSize = true;
            this.checkBox_IsEnable.BackColor = System.Drawing.Color.Transparent;
            this.checkBox_IsEnable.Location = new System.Drawing.Point(112, 12);
            this.checkBox_IsEnable.Name = "checkBox_IsEnable";
            this.checkBox_IsEnable.Size = new System.Drawing.Size(68, 24);
            this.checkBox_IsEnable.TabIndex = 39;
            this.checkBox_IsEnable.Text = "啟  用";
            this.checkBox_IsEnable.UseVisualStyleBackColor = false;
            // 
            // txt_Memo
            // 
            this.txt_Memo.Location = new System.Drawing.Point(112, 166);
            this.txt_Memo.Margin = new System.Windows.Forms.Padding(1);
            this.txt_Memo.Multiline = true;
            this.txt_Memo.Name = "txt_Memo";
            this.txt_Memo.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_Memo.Size = new System.Drawing.Size(191, 105);
            this.txt_Memo.TabIndex = 38;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Location = new System.Drawing.Point(69, 200);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 20);
            this.label6.TabIndex = 37;
            this.label6.Text = "備註";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Location = new System.Drawing.Point(21, 105);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 20);
            this.label5.TabIndex = 36;
            this.label5.Text = "登入的帳號";
            // 
            // txt_MAC
            // 
            this.txt_MAC.Location = new System.Drawing.Point(112, 40);
            this.txt_MAC.Margin = new System.Windows.Forms.Padding(1);
            this.txt_MAC.Name = "txt_MAC";
            this.txt_MAC.Size = new System.Drawing.Size(191, 29);
            this.txt_MAC.TabIndex = 35;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Location = new System.Drawing.Point(32, 43);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 20);
            this.label4.TabIndex = 34;
            this.label4.Text = "MAC位址";
            // 
            // butCancel
            // 
            this.butCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.butCancel.BackgroundImage = global::LawtechPTSystem.Properties.Resources.btnCancel;
            this.butCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.butCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.butCancel.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.butCancel.Location = new System.Drawing.Point(177, 276);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(100, 32);
            this.butCancel.TabIndex = 33;
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
            this.butOK.Location = new System.Drawing.Point(71, 275);
            this.butOK.Name = "butOK";
            this.butOK.Size = new System.Drawing.Size(100, 32);
            this.butOK.TabIndex = 32;
            this.butOK.Text = "確定";
            this.butOK.UseVisualStyleBackColor = true;
            this.butOK.Click += new System.EventHandler(this.butOK_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 9F);
            this.label2.ForeColor = System.Drawing.Color.Maroon;
            this.label2.Location = new System.Drawing.Point(22, 45);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 16);
            this.label2.TabIndex = 42;
            this.label2.Text = "*";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("微軟正黑體", 9F);
            this.label3.Location = new System.Drawing.Point(115, 133);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 16);
            this.label3.TabIndex = 43;
            this.label3.Text = "輸入對應的登入帳號";
            // 
            // EditMACsetting
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = global::LawtechPTSystem.Properties.Resources.EditForm_bg;
            this.CancelButton = this.butCancel;
            this.ClientSize = new System.Drawing.Size(325, 320);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmb_Account);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkBox_IsEnable);
            this.Controls.Add(this.txt_Memo);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txt_MAC);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.butOK);
            this.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditMACsetting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "編輯MAC";
            this.Load += new System.EventHandler(this.EditMACsetting_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmb_Account;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBox_IsEnable;
        private System.Windows.Forms.TextBox txt_Memo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_MAC;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button butCancel;
        private System.Windows.Forms.Button butOK;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}