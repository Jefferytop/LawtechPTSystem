﻿namespace LawtechPTSystem.AddFrom
{
    partial class AddTMStyle
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddTMStyle));
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.numericUpDown_SN = new System.Windows.Forms.NumericUpDown();
            this.label15 = new System.Windows.Forms.Label();
            this.txt_StyleName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_SN)).BeginInit();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button2.BackgroundImage = global::LawtechPTSystem.Properties.Resources.btnCancel;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.button2.Location = new System.Drawing.Point(197, 96);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 32);
            this.button2.TabIndex = 82;
            this.button2.Text = "取消";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button1.BackgroundImage = global::LawtechPTSystem.Properties.Resources.btnComfirm;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.button1.Location = new System.Drawing.Point(91, 96);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 32);
            this.button1.TabIndex = 81;
            this.button1.Text = "確定";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // numericUpDown_SN
            // 
            this.numericUpDown_SN.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.numericUpDown_SN.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.numericUpDown_SN.Location = new System.Drawing.Point(102, 24);
            this.numericUpDown_SN.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.numericUpDown_SN.Name = "numericUpDown_SN";
            this.numericUpDown_SN.Size = new System.Drawing.Size(152, 29);
            this.numericUpDown_SN.TabIndex = 0;
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
            this.label15.Location = new System.Drawing.Point(60, 29);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(41, 20);
            this.label15.TabIndex = 80;
            this.label15.Text = "排序";
            // 
            // txt_StyleName
            // 
            this.txt_StyleName.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.txt_StyleName.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txt_StyleName.Location = new System.Drawing.Point(102, 55);
            this.txt_StyleName.MaxLength = 20;
            this.txt_StyleName.Name = "txt_StyleName";
            this.txt_StyleName.Size = new System.Drawing.Size(274, 29);
            this.txt_StyleName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.label1.Location = new System.Drawing.Point(28, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 20);
            this.label1.TabIndex = 79;
            this.label1.Text = "商標樣式";
            // 
            // AddTMStyle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = global::LawtechPTSystem.Properties.Resources.bg1;
            this.CancelButton = this.button2;
            this.ClientSize = new System.Drawing.Size(389, 140);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.numericUpDown_SN);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.txt_StyleName);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddTMStyle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "新增商標樣式";
            this.Load += new System.EventHandler(this.AddTMStyle_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AddTMStyle_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_SN)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.NumericUpDown numericUpDown_SN;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txt_StyleName;
        private System.Windows.Forms.Label label1;
    }
}