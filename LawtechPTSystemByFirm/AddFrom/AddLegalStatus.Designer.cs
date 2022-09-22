namespace LawtechPTSystemByFirm.AddFrom
{
    partial class AddLegalStatus
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddLegalStatus));
            this.but_Close = new System.Windows.Forms.Button();
            this.but_OK = new System.Windows.Forms.Button();
            this.numericUpDown_SN = new System.Windows.Forms.NumericUpDown();
            this.label15 = new System.Windows.Forms.Label();
            this.txt_Status = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_SN)).BeginInit();
            this.SuspendLayout();
            // 
            // but_Close
            // 
            this.but_Close.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.but_Close.BackgroundImage = global::LawtechPTSystemByFirm.Properties.Resources.btnCancel;
            this.but_Close.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.but_Close.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.but_Close.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.but_Close.Location = new System.Drawing.Point(204, 79);
            this.but_Close.Name = "but_Close";
            this.but_Close.Size = new System.Drawing.Size(100, 32);
            this.but_Close.TabIndex = 82;
            this.but_Close.Text = "取消";
            this.but_Close.UseVisualStyleBackColor = true;
            this.but_Close.Click += new System.EventHandler(this.button2_Click);
            // 
            // but_OK
            // 
            this.but_OK.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.but_OK.BackgroundImage = global::LawtechPTSystemByFirm.Properties.Resources.btnComfirm;
            this.but_OK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.but_OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.but_OK.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.but_OK.Location = new System.Drawing.Point(98, 79);
            this.but_OK.Name = "but_OK";
            this.but_OK.Size = new System.Drawing.Size(100, 32);
            this.but_OK.TabIndex = 81;
            this.but_OK.Text = "確定";
            this.but_OK.UseVisualStyleBackColor = true;
            this.but_OK.Click += new System.EventHandler(this.but_OK_Click);
            // 
            // numericUpDown_SN
            // 
            this.numericUpDown_SN.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.numericUpDown_SN.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.numericUpDown_SN.Location = new System.Drawing.Point(98, 10);
            this.numericUpDown_SN.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.numericUpDown_SN.Name = "numericUpDown_SN";
            this.numericUpDown_SN.Size = new System.Drawing.Size(152, 29);
            this.numericUpDown_SN.TabIndex = 77;
            this.numericUpDown_SN.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.label15.Location = new System.Drawing.Point(56, 15);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(41, 20);
            this.label15.TabIndex = 80;
            this.label15.Text = "排序";
            // 
            // txt_Status
            // 
            this.txt_Status.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.txt_Status.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txt_Status.Location = new System.Drawing.Point(98, 43);
            this.txt_Status.MaxLength = 20;
            this.txt_Status.Name = "txt_Status";
            this.txt_Status.Size = new System.Drawing.Size(274, 29);
            this.txt_Status.TabIndex = 78;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.label1.Location = new System.Drawing.Point(24, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 20);
            this.label1.TabIndex = 79;
            this.label1.Text = "案件階段";
            // 
            // AddLegalStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::LawtechPTSystemByFirm.Properties.Resources.bg1;
            this.CancelButton = this.but_Close;
            this.ClientSize = new System.Drawing.Size(392, 123);
            this.Controls.Add(this.but_Close);
            this.Controls.Add(this.but_OK);
            this.Controls.Add(this.numericUpDown_SN);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.txt_Status);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddLegalStatus";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "新增案件階段";
            this.Load += new System.EventHandler(this.AddLegalStatus_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_SN)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button but_Close;
        private System.Windows.Forms.Button but_OK;
        private System.Windows.Forms.NumericUpDown numericUpDown_SN;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txt_Status;
        private System.Windows.Forms.Label label1;
    }
}