using Microsoft.Reporting.WinForms;
namespace LawtechPTSystem.ReportView
{
    partial class PaymentReport
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
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.label15 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_PaymentNO = new System.Windows.Forms.TextBox();
            this.txt_Department = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_CostDept = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_Reciver = new System.Windows.Forms.TextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.maskedTextBox_PayDueDate = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBox_ReciveDate = new System.Windows.Forms.MaskedTextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.txt_Worker = new System.Windows.Forms.TextBox();
            this.txt_Description = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.but_Refresh = new System.Windows.Forms.Button();
            this.numericUpDown_Amount = new System.Windows.Forms.NumericUpDown();
            this.txt_InvoiceNo = new System.Windows.Forms.TextBox();
            this.maskedTextBox_ApplicantDate = new System.Windows.Forms.MaskedTextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Amount)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "LawtechPTSystem.Report.PaymentReport.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(537, 496);
            this.reportViewer1.TabIndex = 0;
            this.reportViewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Font = new System.Drawing.Font("微軟正黑體", 9.75F);
            this.label15.Location = new System.Drawing.Point(13, 151);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(73, 17);
            this.label15.TabIndex = 319;
            this.label15.Text = "申請部門：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 9.75F);
            this.label2.Location = new System.Drawing.Point(13, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 17);
            this.label2.TabIndex = 318;
            this.label2.Text = "申請日期：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 9.75F);
            this.label1.Location = new System.Drawing.Point(0, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 17);
            this.label1.TabIndex = 317;
            this.label1.Text = "付款流水號：";
            // 
            // txt_PaymentNO
            // 
            this.txt_PaymentNO.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_PaymentNO.Font = new System.Drawing.Font("微軟正黑體", 9.75F);
            this.txt_PaymentNO.Location = new System.Drawing.Point(89, 35);
            this.txt_PaymentNO.Name = "txt_PaymentNO";
            this.txt_PaymentNO.Size = new System.Drawing.Size(182, 25);
            this.txt_PaymentNO.TabIndex = 314;
            // 
            // txt_Department
            // 
            this.txt_Department.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_Department.Font = new System.Drawing.Font("微軟正黑體", 9.75F);
            this.txt_Department.Location = new System.Drawing.Point(89, 147);
            this.txt_Department.Name = "txt_Department";
            this.txt_Department.Size = new System.Drawing.Size(182, 25);
            this.txt_Department.TabIndex = 316;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("微軟正黑體", 9.75F);
            this.label3.Location = new System.Drawing.Point(30, 235);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 17);
            this.label3.TabIndex = 321;
            this.label3.Text = "國   別：";
            // 
            // txt_CostDept
            // 
            this.txt_CostDept.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_CostDept.Font = new System.Drawing.Font("微軟正黑體", 9.75F);
            this.txt_CostDept.Location = new System.Drawing.Point(89, 231);
            this.txt_CostDept.Name = "txt_CostDept";
            this.txt_CostDept.Size = new System.Drawing.Size(182, 25);
            this.txt_CostDept.TabIndex = 320;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("微軟正黑體", 9.75F);
            this.label4.Location = new System.Drawing.Point(26, 179);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 17);
            this.label4.TabIndex = 323;
            this.label4.Text = "受款人：";
            // 
            // txt_Reciver
            // 
            this.txt_Reciver.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_Reciver.Font = new System.Drawing.Font("微軟正黑體", 9.75F);
            this.txt_Reciver.Location = new System.Drawing.Point(89, 175);
            this.txt_Reciver.Name = "txt_Reciver";
            this.txt_Reciver.Size = new System.Drawing.Size(182, 25);
            this.txt_Reciver.TabIndex = 322;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.reportViewer1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.BackgroundImage = global::LawtechPTSystem.Properties.Resources.bg_01;
            this.splitContainer1.Panel2.Controls.Add(this.maskedTextBox_PayDueDate);
            this.splitContainer1.Panel2.Controls.Add(this.maskedTextBox_ReciveDate);
            this.splitContainer1.Panel2.Controls.Add(this.comboBox1);
            this.splitContainer1.Panel2.Controls.Add(this.txt_Worker);
            this.splitContainer1.Panel2.Controls.Add(this.txt_Description);
            this.splitContainer1.Panel2.Controls.Add(this.button2);
            this.splitContainer1.Panel2.Controls.Add(this.but_Refresh);
            this.splitContainer1.Panel2.Controls.Add(this.numericUpDown_Amount);
            this.splitContainer1.Panel2.Controls.Add(this.txt_InvoiceNo);
            this.splitContainer1.Panel2.Controls.Add(this.maskedTextBox_ApplicantDate);
            this.splitContainer1.Panel2.Controls.Add(this.txt_PaymentNO);
            this.splitContainer1.Panel2.Controls.Add(this.txt_Department);
            this.splitContainer1.Panel2.Controls.Add(this.txt_Reciver);
            this.splitContainer1.Panel2.Controls.Add(this.txt_CostDept);
            this.splitContainer1.Panel2.Controls.Add(this.label11);
            this.splitContainer1.Panel2.Controls.Add(this.label10);
            this.splitContainer1.Panel2.Controls.Add(this.label9);
            this.splitContainer1.Panel2.Controls.Add(this.label7);
            this.splitContainer1.Panel2.Controls.Add(this.label8);
            this.splitContainer1.Panel2.Controls.Add(this.label6);
            this.splitContainer1.Panel2.Controls.Add(this.label5);
            this.splitContainer1.Panel2.Controls.Add(this.label4);
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.label15);
            this.splitContainer1.Panel2.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.splitContainer1.Size = new System.Drawing.Size(832, 498);
            this.splitContainer1.SplitterDistance = 539;
            this.splitContainer1.TabIndex = 324;
            // 
            // maskedTextBox_PayDueDate
            // 
            this.maskedTextBox_PayDueDate.Font = new System.Drawing.Font("微軟正黑體", 9.75F);
            this.maskedTextBox_PayDueDate.ForeColor = System.Drawing.Color.Green;
            this.maskedTextBox_PayDueDate.Location = new System.Drawing.Point(89, 119);
            this.maskedTextBox_PayDueDate.Mask = "0000/00/00";
            this.maskedTextBox_PayDueDate.Name = "maskedTextBox_PayDueDate";
            this.maskedTextBox_PayDueDate.Size = new System.Drawing.Size(100, 25);
            this.maskedTextBox_PayDueDate.TabIndex = 342;
            this.maskedTextBox_PayDueDate.ValidatingType = typeof(System.DateTime);
            // 
            // maskedTextBox_ReciveDate
            // 
            this.maskedTextBox_ReciveDate.Font = new System.Drawing.Font("微軟正黑體", 9.75F);
            this.maskedTextBox_ReciveDate.ForeColor = System.Drawing.Color.Green;
            this.maskedTextBox_ReciveDate.Location = new System.Drawing.Point(89, 91);
            this.maskedTextBox_ReciveDate.Mask = "0000/00/00";
            this.maskedTextBox_ReciveDate.Name = "maskedTextBox_ReciveDate";
            this.maskedTextBox_ReciveDate.Size = new System.Drawing.Size(100, 25);
            this.maskedTextBox_ReciveDate.TabIndex = 340;
            this.maskedTextBox_ReciveDate.ValidatingType = typeof(System.DateTime);
            // 
            // comboBox1
            // 
            this.comboBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.comboBox1.Font = new System.Drawing.Font("微軟正黑體", 9.75F);
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(89, 9);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(182, 25);
            this.comboBox1.TabIndex = 338;
            // 
            // txt_Worker
            // 
            this.txt_Worker.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_Worker.Font = new System.Drawing.Font("微軟正黑體", 9.75F);
            this.txt_Worker.Location = new System.Drawing.Point(89, 203);
            this.txt_Worker.Name = "txt_Worker";
            this.txt_Worker.Size = new System.Drawing.Size(182, 25);
            this.txt_Worker.TabIndex = 335;
            // 
            // txt_Description
            // 
            this.txt_Description.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_Description.Font = new System.Drawing.Font("微軟正黑體", 9.75F);
            this.txt_Description.Location = new System.Drawing.Point(89, 315);
            this.txt_Description.Multiline = true;
            this.txt_Description.Name = "txt_Description";
            this.txt_Description.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_Description.Size = new System.Drawing.Size(179, 120);
            this.txt_Description.TabIndex = 334;
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button2.BackgroundImage = global::LawtechPTSystem.Properties.Resources.btnCancel;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.button2.Location = new System.Drawing.Point(149, 441);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(131, 39);
            this.button2.TabIndex = 332;
            this.button2.Text = "關    閉";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // but_Refresh
            // 
            this.but_Refresh.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.but_Refresh.BackgroundImage = global::LawtechPTSystem.Properties.Resources.btnComfirm;
            this.but_Refresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.but_Refresh.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.but_Refresh.Location = new System.Drawing.Point(12, 441);
            this.but_Refresh.Name = "but_Refresh";
            this.but_Refresh.Size = new System.Drawing.Size(131, 39);
            this.but_Refresh.TabIndex = 331;
            this.but_Refresh.Text = "重新整理付款單";
            this.but_Refresh.UseVisualStyleBackColor = true;
            this.but_Refresh.Click += new System.EventHandler(this.but_Refresh_Click);
            // 
            // numericUpDown_Amount
            // 
            this.numericUpDown_Amount.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDown_Amount.DecimalPlaces = 2;
            this.numericUpDown_Amount.Font = new System.Drawing.Font("微軟正黑體", 9.75F);
            this.numericUpDown_Amount.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDown_Amount.Location = new System.Drawing.Point(89, 287);
            this.numericUpDown_Amount.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
            this.numericUpDown_Amount.Name = "numericUpDown_Amount";
            this.numericUpDown_Amount.Size = new System.Drawing.Size(182, 25);
            this.numericUpDown_Amount.TabIndex = 328;
            // 
            // txt_InvoiceNo
            // 
            this.txt_InvoiceNo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_InvoiceNo.Font = new System.Drawing.Font("微軟正黑體", 9.75F);
            this.txt_InvoiceNo.Location = new System.Drawing.Point(89, 259);
            this.txt_InvoiceNo.Name = "txt_InvoiceNo";
            this.txt_InvoiceNo.Size = new System.Drawing.Size(182, 25);
            this.txt_InvoiceNo.TabIndex = 325;
            // 
            // maskedTextBox_ApplicantDate
            // 
            this.maskedTextBox_ApplicantDate.Font = new System.Drawing.Font("微軟正黑體", 9.75F);
            this.maskedTextBox_ApplicantDate.ForeColor = System.Drawing.Color.Green;
            this.maskedTextBox_ApplicantDate.Location = new System.Drawing.Point(89, 63);
            this.maskedTextBox_ApplicantDate.Mask = "0000/00/00";
            this.maskedTextBox_ApplicantDate.Name = "maskedTextBox_ApplicantDate";
            this.maskedTextBox_ApplicantDate.Size = new System.Drawing.Size(100, 25);
            this.maskedTextBox_ApplicantDate.TabIndex = 324;
            this.maskedTextBox_ApplicantDate.ValidatingType = typeof(System.DateTime);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("微軟正黑體", 9.75F);
            this.label11.Location = new System.Drawing.Point(13, 122);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(73, 17);
            this.label11.TabIndex = 341;
            this.label11.Text = "付款期限：";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("微軟正黑體", 9.75F);
            this.label10.Location = new System.Drawing.Point(13, 94);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(73, 17);
            this.label10.TabIndex = 339;
            this.label10.Text = "收件日期：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("微軟正黑體", 9.75F);
            this.label9.Location = new System.Drawing.Point(39, 12);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(47, 17);
            this.label9.TabIndex = 337;
            this.label9.Text = "所別：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("微軟正黑體", 9.75F);
            this.label7.Location = new System.Drawing.Point(26, 206);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 17);
            this.label7.TabIndex = 336;
            this.label7.Text = "申請人：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("微軟正黑體", 9.75F);
            this.label8.Location = new System.Drawing.Point(30, 318);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 17);
            this.label8.TabIndex = 333;
            this.label8.Text = "說   明：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("微軟正黑體", 9.75F);
            this.label6.Location = new System.Drawing.Point(30, 292);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 17);
            this.label6.TabIndex = 327;
            this.label6.Text = "金   額：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("微軟正黑體", 9.75F);
            this.label5.Location = new System.Drawing.Point(13, 263);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 17);
            this.label5.TabIndex = 326;
            this.label5.Text = "收據編號：";
            // 
            // PaymentReport
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(236)))), ((int)(((byte)(247)))));
            this.CancelButton = this.button2;
            this.ClientSize = new System.Drawing.Size(839, 505);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("微軟正黑體", 9F);
            this.Name = "PaymentReport";
            this.Text = "付款單";
            this.Load += new System.EventHandler(this.PaymentReport_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Amount)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_PaymentNO;
        private System.Windows.Forms.TextBox txt_Department;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_CostDept;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_Reciver;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_ApplicantDate;
        private System.Windows.Forms.NumericUpDown numericUpDown_Amount;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_InvoiceNo;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button but_Refresh;
        private System.Windows.Forms.TextBox txt_Description;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_Worker;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_ReciveDate;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_PayDueDate;
        private System.Windows.Forms.Label label11;
    }
}