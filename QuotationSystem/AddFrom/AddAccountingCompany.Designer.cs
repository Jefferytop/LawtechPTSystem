
namespace LawtechPTSystem.AddFrom
{
    partial class AddAccountingCompany
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddAccountingCompany));
            this.numericUpDown_Sort = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.txt_AcountingFirmName = new System.Windows.Forms.TextBox();
            this.txt_AcountingFirm = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.but_Cancel = new System.Windows.Forms.Button();
            this.but_OK = new System.Windows.Forms.Button();
            this.chb_IsEnable = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Sort)).BeginInit();
            this.SuspendLayout();
            // 
            // numericUpDown_Sort
            // 
            this.numericUpDown_Sort.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.numericUpDown_Sort.Location = new System.Drawing.Point(130, 22);
            this.numericUpDown_Sort.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDown_Sort.Name = "numericUpDown_Sort";
            this.numericUpDown_Sort.Size = new System.Drawing.Size(87, 29);
            this.numericUpDown_Sort.TabIndex = 9;
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
            this.label10.Location = new System.Drawing.Point(87, 26);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 20);
            this.label10.TabIndex = 5;
            this.label10.Text = "排序";
            // 
            // txt_AcountingFirmName
            // 
            this.txt_AcountingFirmName.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.txt_AcountingFirmName.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txt_AcountingFirmName.Location = new System.Drawing.Point(130, 58);
            this.txt_AcountingFirmName.Margin = new System.Windows.Forms.Padding(4);
            this.txt_AcountingFirmName.Name = "txt_AcountingFirmName";
            this.txt_AcountingFirmName.Size = new System.Drawing.Size(286, 29);
            this.txt_AcountingFirmName.TabIndex = 11;
            // 
            // txt_AcountingFirm
            // 
            this.txt_AcountingFirm.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.txt_AcountingFirm.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txt_AcountingFirm.Location = new System.Drawing.Point(355, 13);
            this.txt_AcountingFirm.Margin = new System.Windows.Forms.Padding(4);
            this.txt_AcountingFirm.Name = "txt_AcountingFirm";
            this.txt_AcountingFirm.Size = new System.Drawing.Size(48, 29);
            this.txt_AcountingFirm.TabIndex = 10;
            this.txt_AcountingFirm.Visible = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.label5.Location = new System.Drawing.Point(55, 91);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 20);
            this.label5.TabIndex = 6;
            this.label5.Text = "是否啟用";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.label4.Location = new System.Drawing.Point(23, 63);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "入帳公司名稱";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.label1.Location = new System.Drawing.Point(248, 18);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "入帳公司代碼";
            this.label1.Visible = false;
            // 
            // but_Cancel
            // 
            this.but_Cancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.but_Cancel.BackgroundImage = global::LawtechPTSystem.Properties.Resources.btnCancel;
            this.but_Cancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.but_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.but_Cancel.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.but_Cancel.Location = new System.Drawing.Point(228, 134);
            this.but_Cancel.Margin = new System.Windows.Forms.Padding(4);
            this.but_Cancel.Name = "but_Cancel";
            this.but_Cancel.Size = new System.Drawing.Size(100, 32);
            this.but_Cancel.TabIndex = 33;
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
            this.but_OK.Location = new System.Drawing.Point(116, 134);
            this.but_OK.Margin = new System.Windows.Forms.Padding(4);
            this.but_OK.Name = "but_OK";
            this.but_OK.Size = new System.Drawing.Size(100, 32);
            this.but_OK.TabIndex = 32;
            this.but_OK.Text = "確   定";
            this.but_OK.UseVisualStyleBackColor = true;
            this.but_OK.Click += new System.EventHandler(this.but_OK_Click);
            // 
            // chb_IsEnable
            // 
            this.chb_IsEnable.AutoSize = true;
            this.chb_IsEnable.Checked = true;
            this.chb_IsEnable.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chb_IsEnable.Location = new System.Drawing.Point(130, 94);
            this.chb_IsEnable.Name = "chb_IsEnable";
            this.chb_IsEnable.Size = new System.Drawing.Size(15, 14);
            this.chb_IsEnable.TabIndex = 34;
            this.chb_IsEnable.UseVisualStyleBackColor = true;
            // 
            // AddAccountingCompany
            // 
            this.AcceptButton = this.but_OK;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(174)))), ((int)(((byte)(212)))));
            this.BackgroundImage = global::LawtechPTSystem.Properties.Resources.bg1;
            this.CancelButton = this.but_Cancel;
            this.ClientSize = new System.Drawing.Size(445, 183);
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
            this.Name = "AddAccountingCompany";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "新增入帳公司";
            this.Load += new System.EventHandler(this.AddAccountingCompany_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Sort)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numericUpDown_Sort;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txt_AcountingFirmName;
        private System.Windows.Forms.TextBox txt_AcountingFirm;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button but_Cancel;
        private System.Windows.Forms.Button but_OK;
        private System.Windows.Forms.CheckBox chb_IsEnable;
    }
}