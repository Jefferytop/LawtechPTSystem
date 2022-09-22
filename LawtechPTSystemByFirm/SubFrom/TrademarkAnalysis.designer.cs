﻿namespace LawtechPTSystemByFirm.SubFrom
{
    partial class TrademarkAnalysis
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
            this.but_Cancel = new System.Windows.Forms.Button();
            this.but_OK = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.rb_Attorney = new System.Windows.Forms.RadioButton();
            this.rb_Kind = new System.Windows.Forms.RadioButton();
            this.rb_Country = new System.Windows.Forms.RadioButton();
            this.rb_MainCustomer = new System.Windows.Forms.RadioButton();
            this.rb_PatentCount = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // but_Cancel
            // 
            this.but_Cancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.but_Cancel.BackgroundImage = global::LawtechPTSystemByFirm.Properties.Resources.btnCancel;
            this.but_Cancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.but_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.but_Cancel.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.but_Cancel.Location = new System.Drawing.Point(377, 441);
            this.but_Cancel.Name = "but_Cancel";
            this.but_Cancel.Size = new System.Drawing.Size(100, 30);
            this.but_Cancel.TabIndex = 2;
            this.but_Cancel.Text = "取　消";
            this.but_Cancel.UseVisualStyleBackColor = true;
            this.but_Cancel.Click += new System.EventHandler(this.but_Cancel_Click);
            // 
            // but_OK
            // 
            this.but_OK.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.but_OK.BackgroundImage = global::LawtechPTSystemByFirm.Properties.Resources.btnComfirm;
            this.but_OK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.but_OK.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.but_OK.Location = new System.Drawing.Point(271, 441);
            this.but_OK.Name = "but_OK";
            this.but_OK.Size = new System.Drawing.Size(100, 30);
            this.but_OK.TabIndex = 1;
            this.but_OK.Text = "確　定";
            this.but_OK.UseVisualStyleBackColor = true;
            this.but_OK.Click += new System.EventHandler(this.but_OK_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.richTextBox1);
            this.groupBox1.Controls.Add(this.rb_Attorney);
            this.groupBox1.Controls.Add(this.rb_Kind);
            this.groupBox1.Controls.Add(this.rb_Country);
            this.groupBox1.Controls.Add(this.rb_MainCustomer);
            this.groupBox1.Controls.Add(this.rb_PatentCount);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Controls.Add(this.panel3);
            this.groupBox1.Controls.Add(this.panel4);
            this.groupBox1.Controls.Add(this.panel5);
            this.groupBox1.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.groupBox1.Location = new System.Drawing.Point(27, 41);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(699, 384);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "商．標．分．析";
            // 
            // richTextBox1
            // 
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBox1.Font = new System.Drawing.Font("微軟正黑體", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.richTextBox1.Location = new System.Drawing.Point(11, 264);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(261, 100);
            this.richTextBox1.TabIndex = 43;
            this.richTextBox1.Text = "依查詢表的資料為統計的資料來源\n案件的資訊越詳細，\n有助統計的結果更準確";
            // 
            // rb_Attorney
            // 
            this.rb_Attorney.AutoSize = true;
            this.rb_Attorney.Font = new System.Drawing.Font("標楷體", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.rb_Attorney.ForeColor = System.Drawing.Color.BlueViolet;
            this.rb_Attorney.Location = new System.Drawing.Point(288, 283);
            this.rb_Attorney.Name = "rb_Attorney";
            this.rb_Attorney.Size = new System.Drawing.Size(153, 23);
            this.rb_Attorney.TabIndex = 4;
            this.rb_Attorney.Text = "依承辦事務所";
            this.rb_Attorney.UseVisualStyleBackColor = true;
            // 
            // rb_Kind
            // 
            this.rb_Kind.AutoSize = true;
            this.rb_Kind.Font = new System.Drawing.Font("標楷體", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.rb_Kind.ForeColor = System.Drawing.Color.BlueViolet;
            this.rb_Kind.Location = new System.Drawing.Point(288, 214);
            this.rb_Kind.Name = "rb_Kind";
            this.rb_Kind.Size = new System.Drawing.Size(132, 23);
            this.rb_Kind.TabIndex = 3;
            this.rb_Kind.Text = "依案件類別";
            this.rb_Kind.UseVisualStyleBackColor = true;
            // 
            // rb_Country
            // 
            this.rb_Country.AutoSize = true;
            this.rb_Country.Font = new System.Drawing.Font("標楷體", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.rb_Country.ForeColor = System.Drawing.Color.BlueViolet;
            this.rb_Country.Location = new System.Drawing.Point(288, 147);
            this.rb_Country.Name = "rb_Country";
            this.rb_Country.Size = new System.Drawing.Size(90, 23);
            this.rb_Country.TabIndex = 2;
            this.rb_Country.Text = "依國別";
            this.rb_Country.UseVisualStyleBackColor = true;
            // 
            // rb_MainCustomer
            // 
            this.rb_MainCustomer.AutoSize = true;
            this.rb_MainCustomer.Font = new System.Drawing.Font("標楷體", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.rb_MainCustomer.ForeColor = System.Drawing.Color.BlueViolet;
            this.rb_MainCustomer.Location = new System.Drawing.Point(288, 85);
            this.rb_MainCustomer.Name = "rb_MainCustomer";
            this.rb_MainCustomer.Size = new System.Drawing.Size(132, 23);
            this.rb_MainCustomer.TabIndex = 1;
            this.rb_MainCustomer.Text = "依主委託人";
            this.rb_MainCustomer.UseVisualStyleBackColor = true;
            // 
            // rb_PatentCount
            // 
            this.rb_PatentCount.AutoSize = true;
            this.rb_PatentCount.Checked = true;
            this.rb_PatentCount.Font = new System.Drawing.Font("標楷體", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.rb_PatentCount.ForeColor = System.Drawing.Color.BlueViolet;
            this.rb_PatentCount.Location = new System.Drawing.Point(288, 22);
            this.rb_PatentCount.Name = "rb_PatentCount";
            this.rb_PatentCount.Size = new System.Drawing.Size(132, 23);
            this.rb_PatentCount.TabIndex = 0;
            this.rb_PatentCount.TabStop = true;
            this.rb_PatentCount.Text = "依案件統計";
            this.rb_PatentCount.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(294, 32);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(369, 43);
            this.panel1.TabIndex = 34;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label2.Location = new System.Drawing.Point(18, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(281, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "統計申請量、公告量、註冊量、結案量";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::LawtechPTSystemByFirm.Properties.Resources.Analysis;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(11, 26);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(261, 232);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.label6);
            this.panel2.Location = new System.Drawing.Point(294, 94);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(369, 43);
            this.panel2.TabIndex = 35;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label6.Location = new System.Drawing.Point(18, 17);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(185, 20);
            this.label6.TabIndex = 0;
            this.label6.Text = "統計各主委託人的案件量";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.Controls.Add(this.label7);
            this.panel3.Location = new System.Drawing.Point(294, 157);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(369, 43);
            this.panel3.TabIndex = 40;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label7.Location = new System.Drawing.Point(18, 17);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(153, 20);
            this.label7.TabIndex = 0;
            this.label7.Text = "統計各國別的案件量";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Transparent;
            this.panel4.Controls.Add(this.label8);
            this.panel4.Location = new System.Drawing.Point(294, 223);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(369, 43);
            this.panel4.TabIndex = 41;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label8.Location = new System.Drawing.Point(18, 17);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(201, 20);
            this.label8.TabIndex = 0;
            this.label8.Text = "統計商標案件類別的案件量";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Transparent;
            this.panel5.Controls.Add(this.label9);
            this.panel5.Location = new System.Drawing.Point(294, 293);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(369, 43);
            this.panel5.TabIndex = 42;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label9.Location = new System.Drawing.Point(18, 17);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(185, 20);
            this.label9.TabIndex = 0;
            this.label9.Text = "統計承辦事務所的案件量";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.label1.Location = new System.Drawing.Point(28, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(169, 20);
            this.label1.TabIndex = 36;
            this.label1.Text = "請點選要統計的項目：";
            // 
            // TrademarkAnalysis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(236)))), ((int)(((byte)(247)))));
            this.ClientSize = new System.Drawing.Size(748, 490);
            this.Controls.Add(this.but_Cancel);
            this.Controls.Add(this.but_OK);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TrademarkAnalysis";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "商標分析";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button but_Cancel;
        private System.Windows.Forms.Button but_OK;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.RadioButton rb_Attorney;
        private System.Windows.Forms.RadioButton rb_Kind;
        private System.Windows.Forms.RadioButton rb_Country;
        private System.Windows.Forms.RadioButton rb_MainCustomer;
        private System.Windows.Forms.RadioButton rb_PatentCount;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label1;
    }
}