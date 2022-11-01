
namespace LawtechPTSystem.AddFrom
{
    partial class AddAcountingFirmDetail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddAcountingFirmDetail));
            this.chb_IsEnable = new System.Windows.Forms.CheckBox();
            this.but_Cancel = new System.Windows.Forms.Button();
            this.but_OK = new System.Windows.Forms.Button();
            this.numericUpDown_Sort = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.txt_BankName = new System.Windows.Forms.TextBox();
            this.txt_AccountName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_BankAccount = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Sort)).BeginInit();
            this.SuspendLayout();
            // 
            // chb_IsEnable
            // 
            this.chb_IsEnable.AutoSize = true;
            this.chb_IsEnable.Checked = true;
            this.chb_IsEnable.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chb_IsEnable.Location = new System.Drawing.Point(133, 179);
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
            this.but_Cancel.Location = new System.Drawing.Point(231, 228);
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
            this.but_OK.Location = new System.Drawing.Point(119, 228);
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
            this.numericUpDown_Sort.Location = new System.Drawing.Point(133, 24);
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
            this.label10.Location = new System.Drawing.Point(90, 28);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 20);
            this.label10.TabIndex = 35;
            this.label10.Text = "排序";
            // 
            // txt_BankName
            // 
            this.txt_BankName.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.txt_BankName.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txt_BankName.Location = new System.Drawing.Point(133, 60);
            this.txt_BankName.Margin = new System.Windows.Forms.Padding(4);
            this.txt_BankName.Name = "txt_BankName";
            this.txt_BankName.Size = new System.Drawing.Size(286, 29);
            this.txt_BankName.TabIndex = 41;
            // 
            // txt_AccountName
            // 
            this.txt_AccountName.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.txt_AccountName.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txt_AccountName.Location = new System.Drawing.Point(133, 97);
            this.txt_AccountName.Margin = new System.Windows.Forms.Padding(4);
            this.txt_AccountName.Name = "txt_AccountName";
            this.txt_AccountName.Size = new System.Drawing.Size(286, 29);
            this.txt_AccountName.TabIndex = 40;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.label5.Location = new System.Drawing.Point(58, 176);
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
            this.label4.Location = new System.Drawing.Point(58, 63);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 20);
            this.label4.TabIndex = 37;
            this.label4.Text = "銀行名稱";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.label1.Location = new System.Drawing.Point(58, 100);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 20);
            this.label1.TabIndex = 38;
            this.label1.Text = "帳戶名稱";
            // 
            // txt_BankAccount
            // 
            this.txt_BankAccount.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.txt_BankAccount.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txt_BankAccount.Location = new System.Drawing.Point(133, 134);
            this.txt_BankAccount.Margin = new System.Windows.Forms.Padding(4);
            this.txt_BankAccount.Name = "txt_BankAccount";
            this.txt_BankAccount.Size = new System.Drawing.Size(286, 29);
            this.txt_BankAccount.TabIndex = 46;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.label2.Location = new System.Drawing.Point(58, 137);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 20);
            this.label2.TabIndex = 45;
            this.label2.Text = "帳戶號碼";
            // 
            // AddAcountingFirmDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::LawtechPTSystem.Properties.Resources.bg1;
            this.ClientSize = new System.Drawing.Size(445, 275);
            this.Controls.Add(this.txt_BankAccount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.chb_IsEnable);
            this.Controls.Add(this.but_Cancel);
            this.Controls.Add(this.but_OK);
            this.Controls.Add(this.numericUpDown_Sort);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txt_BankName);
            this.Controls.Add(this.txt_AccountName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddAcountingFirmDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "新增帳戶資料";
            this.Load += new System.EventHandler(this.AddAcountingFirmDetail_Load);
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
        private System.Windows.Forms.TextBox txt_BankName;
        private System.Windows.Forms.TextBox txt_AccountName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_BankAccount;
        private System.Windows.Forms.Label label2;
    }
}