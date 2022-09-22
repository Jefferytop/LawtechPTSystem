using Microsoft.Reporting.WinForms;
namespace LawtechPTSystemByFirm.ReportView
{
    partial class FeeReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FeeReport));
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.txt_ApplicantName = new System.Windows.Forms.TextBox();
            this.txt_PPP = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_AttorneyRefNo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_PatentNo = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_FeeSubject = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_Title = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txt_Country = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txt_Kind = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txt_ApplicationNo = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.numericUpDown_OAttorneyGovFee = new System.Windows.Forms.NumericUpDown();
            this.maskedTextBox_RDate = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBox_ApplicationDate = new System.Windows.Forms.MaskedTextBox();
            this.txt_Address = new System.Windows.Forms.TextBox();
            this.txt_Phone = new System.Windows.Forms.TextBox();
            this.txt_Fax = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.numericUpDown_IAttorneyFee = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_Totall = new System.Windows.Forms.NumericUpDown();
            this.label17 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.numericUpDown_Tax = new System.Windows.Forms.NumericUpDown();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.txt_PaymentInstructions = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_OAttorneyGovFee)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_IAttorneyFee)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Totall)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Tax)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.reportViewer1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "LawtechPTSystemByFirm.Report.FeeReport.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(594, 740);
            this.reportViewer1.TabIndex = 0;
            this.reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
            this.reportViewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth;
            this.reportViewer1.ReportRefresh += new System.ComponentModel.CancelEventHandler(this.reportViewer1_ReportRefresh);
            // 
            // txt_ApplicantName
            // 
            this.txt_ApplicantName.Location = new System.Drawing.Point(94, 21);
            this.txt_ApplicantName.Name = "txt_ApplicantName";
            this.txt_ApplicantName.Size = new System.Drawing.Size(182, 25);
            this.txt_ApplicantName.TabIndex = 2;
            // 
            // txt_PPP
            // 
            this.txt_PPP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_PPP.Font = new System.Drawing.Font("微軟正黑體", 9.75F);
            this.txt_PPP.Location = new System.Drawing.Point(694, 345);
            this.txt_PPP.Name = "txt_PPP";
            this.txt_PPP.Size = new System.Drawing.Size(182, 25);
            this.txt_PPP.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微軟正黑體", 9.75F);
            this.label3.Location = new System.Drawing.Point(620, 350);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 17);
            this.label3.TabIndex = 5;
            this.label3.Text = "帳單編號：";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微軟正黑體", 9.75F);
            this.label4.Location = new System.Drawing.Point(620, 379);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "帳單日期：";
            // 
            // txt_AttorneyRefNo
            // 
            this.txt_AttorneyRefNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_AttorneyRefNo.Font = new System.Drawing.Font("微軟正黑體", 9.75F);
            this.txt_AttorneyRefNo.Location = new System.Drawing.Point(694, 401);
            this.txt_AttorneyRefNo.Name = "txt_AttorneyRefNo";
            this.txt_AttorneyRefNo.Size = new System.Drawing.Size(182, 25);
            this.txt_AttorneyRefNo.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微軟正黑體", 9.75F);
            this.label5.Location = new System.Drawing.Point(620, 407);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 17);
            this.label5.TabIndex = 9;
            this.label5.Text = "貴方案號：";
            // 
            // txt_PatentNo
            // 
            this.txt_PatentNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_PatentNo.Font = new System.Drawing.Font("微軟正黑體", 9.75F);
            this.txt_PatentNo.Location = new System.Drawing.Point(694, 429);
            this.txt_PatentNo.Name = "txt_PatentNo";
            this.txt_PatentNo.Size = new System.Drawing.Size(182, 25);
            this.txt_PatentNo.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微軟正黑體", 9.75F);
            this.label6.Location = new System.Drawing.Point(620, 433);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 17);
            this.label6.TabIndex = 11;
            this.label6.Text = "本所案號：";
            // 
            // txt_FeeSubject
            // 
            this.txt_FeeSubject.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_FeeSubject.Font = new System.Drawing.Font("微軟正黑體", 9.75F);
            this.txt_FeeSubject.Location = new System.Drawing.Point(94, 15);
            this.txt_FeeSubject.Name = "txt_FeeSubject";
            this.txt_FeeSubject.Size = new System.Drawing.Size(182, 25);
            this.txt_FeeSubject.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微軟正黑體", 9.75F);
            this.label7.Location = new System.Drawing.Point(37, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 17);
            this.label7.TabIndex = 13;
            this.label7.Text = "案   由：";
            // 
            // txt_Title
            // 
            this.txt_Title.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_Title.Font = new System.Drawing.Font("微軟正黑體", 9.75F);
            this.txt_Title.Location = new System.Drawing.Point(94, 42);
            this.txt_Title.Name = "txt_Title";
            this.txt_Title.Size = new System.Drawing.Size(182, 25);
            this.txt_Title.TabIndex = 16;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("微軟正黑體", 9.75F);
            this.label8.Location = new System.Drawing.Point(20, 47);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 17);
            this.label8.TabIndex = 15;
            this.label8.Text = "專利名稱：";
            // 
            // txt_Country
            // 
            this.txt_Country.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_Country.Font = new System.Drawing.Font("微軟正黑體", 9.75F);
            this.txt_Country.Location = new System.Drawing.Point(94, 69);
            this.txt_Country.Name = "txt_Country";
            this.txt_Country.Size = new System.Drawing.Size(182, 25);
            this.txt_Country.TabIndex = 18;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("微軟正黑體", 9.75F);
            this.label9.Location = new System.Drawing.Point(37, 74);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 17);
            this.label9.TabIndex = 17;
            this.label9.Text = "國   別：";
            // 
            // txt_Kind
            // 
            this.txt_Kind.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_Kind.Font = new System.Drawing.Font("微軟正黑體", 9.75F);
            this.txt_Kind.Location = new System.Drawing.Point(94, 97);
            this.txt_Kind.Name = "txt_Kind";
            this.txt_Kind.Size = new System.Drawing.Size(182, 25);
            this.txt_Kind.TabIndex = 20;
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("微軟正黑體", 9.75F);
            this.label10.Location = new System.Drawing.Point(37, 102);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 17);
            this.label10.TabIndex = 19;
            this.label10.Text = "種   類：";
            // 
            // txt_ApplicationNo
            // 
            this.txt_ApplicationNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_ApplicationNo.Font = new System.Drawing.Font("微軟正黑體", 9.75F);
            this.txt_ApplicationNo.Location = new System.Drawing.Point(94, 125);
            this.txt_ApplicationNo.Name = "txt_ApplicationNo";
            this.txt_ApplicationNo.Size = new System.Drawing.Size(182, 25);
            this.txt_ApplicationNo.TabIndex = 22;
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("微軟正黑體", 9.75F);
            this.label11.Location = new System.Drawing.Point(33, 130);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(60, 17);
            this.label11.TabIndex = 21;
            this.label11.Text = "申請號：";
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("微軟正黑體", 9.75F);
            this.label12.Location = new System.Drawing.Point(33, 159);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(60, 17);
            this.label12.TabIndex = 23;
            this.label12.Text = "申請日：";
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("微軟正黑體", 9.75F);
            this.label13.Location = new System.Drawing.Point(607, 462);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(86, 17);
            this.label13.TabIndex = 25;
            this.label13.Text = "本所服務費：";
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("微軟正黑體", 9.75F);
            this.label14.Location = new System.Drawing.Point(594, 489);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(99, 17);
            this.label14.TabIndex = 27;
            this.label14.Text = "代收代付費用：";
            // 
            // numericUpDown_OAttorneyGovFee
            // 
            this.numericUpDown_OAttorneyGovFee.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDown_OAttorneyGovFee.DecimalPlaces = 2;
            this.numericUpDown_OAttorneyGovFee.Font = new System.Drawing.Font("微軟正黑體", 9.75F);
            this.numericUpDown_OAttorneyGovFee.Location = new System.Drawing.Point(694, 485);
            this.numericUpDown_OAttorneyGovFee.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericUpDown_OAttorneyGovFee.Name = "numericUpDown_OAttorneyGovFee";
            this.numericUpDown_OAttorneyGovFee.Size = new System.Drawing.Size(182, 25);
            this.numericUpDown_OAttorneyGovFee.TabIndex = 28;
            // 
            // maskedTextBox_RDate
            // 
            this.maskedTextBox_RDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.maskedTextBox_RDate.BackColor = System.Drawing.Color.White;
            this.maskedTextBox_RDate.Font = new System.Drawing.Font("微軟正黑體", 9.75F);
            this.maskedTextBox_RDate.ForeColor = System.Drawing.Color.Green;
            this.maskedTextBox_RDate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.maskedTextBox_RDate.Location = new System.Drawing.Point(694, 373);
            this.maskedTextBox_RDate.Mask = "0000/00/00";
            this.maskedTextBox_RDate.Name = "maskedTextBox_RDate";
            this.maskedTextBox_RDate.Size = new System.Drawing.Size(182, 25);
            this.maskedTextBox_RDate.TabIndex = 306;
            this.maskedTextBox_RDate.ValidatingType = typeof(System.DateTime);
            // 
            // maskedTextBox_ApplicationDate
            // 
            this.maskedTextBox_ApplicationDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.maskedTextBox_ApplicationDate.BackColor = System.Drawing.Color.White;
            this.maskedTextBox_ApplicationDate.Font = new System.Drawing.Font("微軟正黑體", 9.75F);
            this.maskedTextBox_ApplicationDate.ForeColor = System.Drawing.Color.Green;
            this.maskedTextBox_ApplicationDate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.maskedTextBox_ApplicationDate.Location = new System.Drawing.Point(94, 153);
            this.maskedTextBox_ApplicationDate.Mask = "0000/00/00";
            this.maskedTextBox_ApplicationDate.Name = "maskedTextBox_ApplicationDate";
            this.maskedTextBox_ApplicationDate.Size = new System.Drawing.Size(182, 25);
            this.maskedTextBox_ApplicationDate.TabIndex = 307;
            this.maskedTextBox_ApplicationDate.ValidatingType = typeof(System.DateTime);
            // 
            // txt_Address
            // 
            this.txt_Address.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_Address.Location = new System.Drawing.Point(94, 49);
            this.txt_Address.Name = "txt_Address";
            this.txt_Address.Size = new System.Drawing.Size(182, 25);
            this.txt_Address.TabIndex = 308;
            // 
            // txt_Phone
            // 
            this.txt_Phone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_Phone.Location = new System.Drawing.Point(94, 77);
            this.txt_Phone.Name = "txt_Phone";
            this.txt_Phone.Size = new System.Drawing.Size(182, 25);
            this.txt_Phone.TabIndex = 309;
            // 
            // txt_Fax
            // 
            this.txt_Fax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_Fax.Location = new System.Drawing.Point(94, 105);
            this.txt_Fax.Name = "txt_Fax";
            this.txt_Fax.Size = new System.Drawing.Size(182, 25);
            this.txt_Fax.TabIndex = 310;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.txt_ApplicantName);
            this.groupBox1.Controls.Add(this.txt_Fax);
            this.groupBox1.Controls.Add(this.txt_Address);
            this.groupBox1.Controls.Add(this.txt_Phone);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox1.Location = new System.Drawing.Point(600, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(282, 136);
            this.groupBox1.TabIndex = 311;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "致 ：";
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label16.Location = new System.Drawing.Point(40, 110);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(53, 17);
            this.label16.TabIndex = 314;
            this.label16.Text = "傳  真：";
            // 
            // label15
            // 
            this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label15.Location = new System.Drawing.Point(40, 80);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(53, 17);
            this.label15.TabIndex = 313;
            this.label15.Text = "電  話：";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(40, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 17);
            this.label2.TabIndex = 312;
            this.label2.Text = "地  址：";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(20, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 17);
            this.label1.TabIndex = 311;
            this.label1.Text = "請款對象：";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.txt_FeeSubject);
            this.groupBox2.Controls.Add(this.txt_Title);
            this.groupBox2.Controls.Add(this.maskedTextBox_ApplicationDate);
            this.groupBox2.Controls.Add(this.txt_Country);
            this.groupBox2.Controls.Add(this.txt_Kind);
            this.groupBox2.Controls.Add(this.txt_ApplicationNo);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Font = new System.Drawing.Font("微軟正黑體", 9.75F);
            this.groupBox2.Location = new System.Drawing.Point(600, 154);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(282, 186);
            this.groupBox2.TabIndex = 312;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "案  由：";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.BackgroundImage = global::LawtechPTSystemByFirm.Properties.Resources.btnComfirm;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.button1.Location = new System.Drawing.Point(620, 691);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(131, 39);
            this.button1.TabIndex = 313;
            this.button1.Text = "重新整理請款單";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // numericUpDown_IAttorneyFee
            // 
            this.numericUpDown_IAttorneyFee.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDown_IAttorneyFee.DecimalPlaces = 2;
            this.numericUpDown_IAttorneyFee.Font = new System.Drawing.Font("微軟正黑體", 9.75F);
            this.numericUpDown_IAttorneyFee.Location = new System.Drawing.Point(694, 457);
            this.numericUpDown_IAttorneyFee.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericUpDown_IAttorneyFee.Name = "numericUpDown_IAttorneyFee";
            this.numericUpDown_IAttorneyFee.Size = new System.Drawing.Size(182, 25);
            this.numericUpDown_IAttorneyFee.TabIndex = 314;
            // 
            // numericUpDown_Totall
            // 
            this.numericUpDown_Totall.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDown_Totall.DecimalPlaces = 2;
            this.numericUpDown_Totall.Font = new System.Drawing.Font("微軟正黑體", 9.75F);
            this.numericUpDown_Totall.Location = new System.Drawing.Point(694, 539);
            this.numericUpDown_Totall.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericUpDown_Totall.Name = "numericUpDown_Totall";
            this.numericUpDown_Totall.Size = new System.Drawing.Size(182, 25);
            this.numericUpDown_Totall.TabIndex = 316;
            // 
            // label17
            // 
            this.label17.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("微軟正黑體", 9.75F);
            this.label17.Location = new System.Drawing.Point(646, 542);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(47, 17);
            this.label17.TabIndex = 315;
            this.label17.Text = "合計：";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Font = new System.Drawing.Font("微軟正黑體", 9.75F);
            this.textBox1.Location = new System.Drawing.Point(694, 565);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(182, 25);
            this.textBox1.TabIndex = 317;
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.BackgroundImage = global::LawtechPTSystemByFirm.Properties.Resources.btnCancel;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.button2.Location = new System.Drawing.Point(757, 691);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(131, 39);
            this.button2.TabIndex = 333;
            this.button2.Text = "關    閉";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // numericUpDown_Tax
            // 
            this.numericUpDown_Tax.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDown_Tax.DecimalPlaces = 2;
            this.numericUpDown_Tax.Font = new System.Drawing.Font("微軟正黑體", 9.75F);
            this.numericUpDown_Tax.Location = new System.Drawing.Point(694, 512);
            this.numericUpDown_Tax.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericUpDown_Tax.Name = "numericUpDown_Tax";
            this.numericUpDown_Tax.Size = new System.Drawing.Size(182, 25);
            this.numericUpDown_Tax.TabIndex = 335;
            // 
            // label18
            // 
            this.label18.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("微軟正黑體", 9.75F);
            this.label18.Location = new System.Drawing.Point(646, 515);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(47, 17);
            this.label18.TabIndex = 334;
            this.label18.Text = "稅額：";
            // 
            // label19
            // 
            this.label19.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("微軟正黑體", 9.75F);
            this.label19.Location = new System.Drawing.Point(620, 597);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(73, 17);
            this.label19.TabIndex = 336;
            this.label19.Text = "付款說明：";
            // 
            // txt_PaymentInstructions
            // 
            this.txt_PaymentInstructions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_PaymentInstructions.Font = new System.Drawing.Font("微軟正黑體", 9.75F);
            this.txt_PaymentInstructions.Location = new System.Drawing.Point(694, 592);
            this.txt_PaymentInstructions.Multiline = true;
            this.txt_PaymentInstructions.Name = "txt_PaymentInstructions";
            this.txt_PaymentInstructions.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_PaymentInstructions.Size = new System.Drawing.Size(182, 93);
            this.txt_PaymentInstructions.TabIndex = 308;
            this.txt_PaymentInstructions.Text = resources.GetString("txt_PaymentInstructions.Text");
            // 
            // FeeReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(236)))), ((int)(((byte)(247)))));
            this.CancelButton = this.button2;
            this.ClientSize = new System.Drawing.Size(900, 742);
            this.Controls.Add(this.txt_PaymentInstructions);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.numericUpDown_Tax);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.numericUpDown_Totall);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.numericUpDown_IAttorneyFee);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.maskedTextBox_RDate);
            this.Controls.Add(this.numericUpDown_OAttorneyGovFee);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.txt_PatentNo);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txt_AttorneyRefNo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_PPP);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.reportViewer1);
            this.Name = "FeeReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = " ";
            this.Load += new System.EventHandler(this.FeeReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_OAttorneyGovFee)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_IAttorneyFee)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Totall)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Tax)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.TextBox txt_ApplicantName;
        private System.Windows.Forms.TextBox txt_PPP;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_AttorneyRefNo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_PatentNo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_FeeSubject;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_Title;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txt_Country;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txt_Kind;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txt_ApplicationNo;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.NumericUpDown numericUpDown_OAttorneyGovFee;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_RDate;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_ApplicationDate;
        private System.Windows.Forms.TextBox txt_Address;
        private System.Windows.Forms.TextBox txt_Phone;
        private System.Windows.Forms.TextBox txt_Fax;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.NumericUpDown numericUpDown_IAttorneyFee;
        private System.Windows.Forms.NumericUpDown numericUpDown_Totall;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.NumericUpDown numericUpDown_Tax;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txt_PaymentInstructions;
    }
}