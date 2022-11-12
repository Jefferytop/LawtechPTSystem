namespace LawtechPTSystem.US
{
    partial class CalculationDate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CalculationDate));
            this.but_Cancel = new System.Windows.Forms.Button();
            this.but_OK = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDown_Year = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_Month = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.numericUpDown_Day = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.mtb_CurrentDate = new System.Windows.Forms.MaskedTextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.maskedTextBox_Result = new System.Windows.Forms.MaskedTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Year)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Month)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Day)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // but_Cancel
            // 
            this.but_Cancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.but_Cancel.BackgroundImage = global::LawtechPTSystem.Properties.Resources.btnCancel;
            this.but_Cancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.but_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.but_Cancel.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.but_Cancel.Location = new System.Drawing.Point(206, 234);
            this.but_Cancel.Margin = new System.Windows.Forms.Padding(4);
            this.but_Cancel.Name = "but_Cancel";
            this.but_Cancel.Size = new System.Drawing.Size(100, 32);
            this.but_Cancel.TabIndex = 6;
            this.but_Cancel.Text = "取   消";
            this.but_Cancel.UseVisualStyleBackColor = true;
            this.but_Cancel.Click += new System.EventHandler(this.but_Cancel_Click);
            // 
            // but_OK
            // 
            this.but_OK.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.but_OK.BackgroundImage = global::LawtechPTSystem.Properties.Resources.btnComfirm;
            this.but_OK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.but_OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.but_OK.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.but_OK.Location = new System.Drawing.Point(104, 234);
            this.but_OK.Margin = new System.Windows.Forms.Padding(4);
            this.but_OK.Name = "but_OK";
            this.but_OK.Size = new System.Drawing.Size(100, 32);
            this.but_OK.TabIndex = 5;
            this.but_OK.Text = "確   定";
            this.but_OK.UseVisualStyleBackColor = true;
            this.but_OK.Click += new System.EventHandler(this.but_OK_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.label1.Location = new System.Drawing.Point(105, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(25, 20);
            this.label1.TabIndex = 370;
            this.label1.Text = "年";
            // 
            // numericUpDown_Year
            // 
            this.numericUpDown_Year.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.numericUpDown_Year.Location = new System.Drawing.Point(132, 61);
            this.numericUpDown_Year.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.numericUpDown_Year.Minimum = new decimal(new int[] {
            30,
            0,
            0,
            -2147483648});
            this.numericUpDown_Year.Name = "numericUpDown_Year";
            this.numericUpDown_Year.Size = new System.Drawing.Size(120, 29);
            this.numericUpDown_Year.TabIndex = 1;
            this.numericUpDown_Year.ValueChanged += new System.EventHandler(this.numericUpDown_Year_ValueChanged);
            // 
            // numericUpDown_Month
            // 
            this.numericUpDown_Month.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.numericUpDown_Month.Location = new System.Drawing.Point(132, 94);
            this.numericUpDown_Month.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.numericUpDown_Month.Minimum = new decimal(new int[] {
            12,
            0,
            0,
            -2147483648});
            this.numericUpDown_Month.Name = "numericUpDown_Month";
            this.numericUpDown_Month.Size = new System.Drawing.Size(120, 29);
            this.numericUpDown_Month.TabIndex = 2;
            this.numericUpDown_Month.ValueChanged += new System.EventHandler(this.numericUpDown_Year_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.label2.Location = new System.Drawing.Point(105, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 20);
            this.label2.TabIndex = 372;
            this.label2.Text = "月";
            // 
            // numericUpDown_Day
            // 
            this.numericUpDown_Day.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.numericUpDown_Day.Location = new System.Drawing.Point(132, 127);
            this.numericUpDown_Day.Maximum = new decimal(new int[] {
            365,
            0,
            0,
            0});
            this.numericUpDown_Day.Minimum = new decimal(new int[] {
            365,
            0,
            0,
            -2147483648});
            this.numericUpDown_Day.Name = "numericUpDown_Day";
            this.numericUpDown_Day.Size = new System.Drawing.Size(120, 29);
            this.numericUpDown_Day.TabIndex = 3;
            this.numericUpDown_Day.ValueChanged += new System.EventHandler(this.numericUpDown_Year_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.label3.Location = new System.Drawing.Point(105, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 20);
            this.label3.TabIndex = 374;
            this.label3.Text = "日";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.ForeColor = System.Drawing.Color.Navy;
            this.label4.Location = new System.Drawing.Point(255, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 16);
            this.label4.TabIndex = 376;
            this.label4.Text = "[30] ~ [-30]";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label5.ForeColor = System.Drawing.Color.Navy;
            this.label5.Location = new System.Drawing.Point(255, 103);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 16);
            this.label5.TabIndex = 377;
            this.label5.Text = "[12] ~ [-12]";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label6.ForeColor = System.Drawing.Color.Navy;
            this.label6.Location = new System.Drawing.Point(255, 135);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 16);
            this.label6.TabIndex = 378;
            this.label6.Text = "[365] ~ [-365]";
            // 
            // mtb_CurrentDate
            // 
            this.mtb_CurrentDate.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.mtb_CurrentDate.ForeColor = System.Drawing.Color.Green;
            this.mtb_CurrentDate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.mtb_CurrentDate.Location = new System.Drawing.Point(132, 27);
            this.mtb_CurrentDate.Margin = new System.Windows.Forms.Padding(4);
            this.mtb_CurrentDate.Mask = "0000-00-00";
            this.mtb_CurrentDate.Name = "mtb_CurrentDate";
            this.mtb_CurrentDate.Size = new System.Drawing.Size(120, 29);
            this.mtb_CurrentDate.TabIndex = 0;
            this.mtb_CurrentDate.ValidatingType = typeof(System.DateTime);
            this.mtb_CurrentDate.DoubleClick += new System.EventHandler(this.mtb_CurrentDate_DoubleClick);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.label8.Location = new System.Drawing.Point(57, 31);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 20);
            this.label8.TabIndex = 379;
            this.label8.Text = "目前日期";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackgroundImage = global::LawtechPTSystem.Properties.Resources.pinggs58;
            this.pictureBox1.Location = new System.Drawing.Point(-7, 165);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(420, 10);
            this.pictureBox1.TabIndex = 381;
            this.pictureBox1.TabStop = false;
            // 
            // maskedTextBox_Result
            // 
            this.maskedTextBox_Result.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.maskedTextBox_Result.ForeColor = System.Drawing.Color.Green;
            this.maskedTextBox_Result.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.maskedTextBox_Result.Location = new System.Drawing.Point(154, 182);
            this.maskedTextBox_Result.Margin = new System.Windows.Forms.Padding(4);
            this.maskedTextBox_Result.Mask = "0000-00-00";
            this.maskedTextBox_Result.Name = "maskedTextBox_Result";
            this.maskedTextBox_Result.Size = new System.Drawing.Size(120, 29);
            this.maskedTextBox_Result.TabIndex = 4;
            this.maskedTextBox_Result.ValidatingType = typeof(System.DateTime);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.label7.Location = new System.Drawing.Point(64, 187);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 20);
            this.label7.TabIndex = 383;
            this.label7.Text = "計算後日期";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label9.ForeColor = System.Drawing.Color.Navy;
            this.label9.Location = new System.Drawing.Point(254, 36);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(134, 16);
            this.label9.TabIndex = 384;
            this.label9.Text = "計算日期時, 不得為空值";
            // 
            // CalculationDate
            // 
            this.AcceptButton = this.but_OK;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = global::LawtechPTSystem.Properties.Resources.bg_01;
            this.CancelButton = this.but_Cancel;
            this.ClientSize = new System.Drawing.Size(409, 281);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.maskedTextBox_Result);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.mtb_CurrentDate);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.numericUpDown_Day);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numericUpDown_Month);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numericUpDown_Year);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.but_Cancel);
            this.Controls.Add(this.but_OK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CalculationDate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "計算日期";
            this.Load += new System.EventHandler(this.CalculationDate_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CalculationDate_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Year)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Month)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Day)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button but_Cancel;
        private System.Windows.Forms.Button but_OK;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDown_Year;
        private System.Windows.Forms.NumericUpDown numericUpDown_Month;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numericUpDown_Day;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.MaskedTextBox mtb_CurrentDate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_Result;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
    }
}