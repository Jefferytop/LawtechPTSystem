
namespace LawtechPTSystem.ReportView
{
    partial class FeeReceiptReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FeeReceiptReport));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.comboBox_AcountingFirmT = new System.Windows.Forms.ComboBox();
            this.label25 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txt_Footer = new System.Windows.Forms.TextBox();
            this.txt_Footer1 = new System.Windows.Forms.TextBox();
            this.txt_ApplicantName = new System.Windows.Forms.TextBox();
            this.lab_AttorneyName = new System.Windows.Forms.Label();
            this.numericUpDown_OAttorneyGovFee = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_SaveText = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txt_FeeSubject = new System.Windows.Forms.TextBox();
            this.txt_Title = new System.Windows.Forms.TextBox();
            this.maskedTextBox_ApplicationDate = new System.Windows.Forms.MaskedTextBox();
            this.txt_Country = new System.Windows.Forms.TextBox();
            this.txt_Kind = new System.Windows.Forms.TextBox();
            this.txt_ApplicationNo = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txt_PPP = new System.Windows.Forms.TextBox();
            this.txt_PaymentInstructions = new System.Windows.Forms.TextBox();
            this.txt_AttorneyRefNo = new System.Windows.Forms.TextBox();
            this.numericUpDown_OthTotal = new System.Windows.Forms.NumericUpDown();
            this.txt_PatentNo = new System.Windows.Forms.TextBox();
            this.maskedTextBox_RDate = new System.Windows.Forms.MaskedTextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_OAttorneyGovFee)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_OthTotal)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.reportViewer1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.comboBox_AcountingFirmT);
            this.splitContainer1.Panel2.Controls.Add(this.label25);
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Panel2.Controls.Add(this.txt_ApplicantName);
            this.splitContainer1.Panel2.Controls.Add(this.lab_AttorneyName);
            this.splitContainer1.Panel2.Controls.Add(this.numericUpDown_OAttorneyGovFee);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.btn_SaveText);
            this.splitContainer1.Panel2.Controls.Add(this.button2);
            this.splitContainer1.Panel2.Controls.Add(this.button1);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer1.Panel2.Controls.Add(this.txt_PPP);
            this.splitContainer1.Panel2.Controls.Add(this.txt_PaymentInstructions);
            this.splitContainer1.Panel2.Controls.Add(this.txt_AttorneyRefNo);
            this.splitContainer1.Panel2.Controls.Add(this.numericUpDown_OthTotal);
            this.splitContainer1.Panel2.Controls.Add(this.txt_PatentNo);
            this.splitContainer1.Panel2.Controls.Add(this.maskedTextBox_RDate);
            this.splitContainer1.Panel2.Controls.Add(this.label23);
            this.splitContainer1.Panel2.Controls.Add(this.label19);
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Panel2.Controls.Add(this.label4);
            this.splitContainer1.Panel2.Controls.Add(this.label5);
            this.splitContainer1.Panel2.Controls.Add(this.label6);
            this.splitContainer1.Panel2.Controls.Add(this.label17);
            this.splitContainer1.Size = new System.Drawing.Size(882, 729);
            this.splitContainer1.SplitterDistance = 494;
            this.splitContainer1.TabIndex = 338;
            // 
            // reportViewer1
            // 
            this.reportViewer1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "LawtechPTSystem.Report.FeeReceiptReport.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(492, 727);
            this.reportViewer1.TabIndex = 0;
            this.reportViewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth;
            // 
            // comboBox_AcountingFirmT
            // 
            this.comboBox_AcountingFirmT.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_AcountingFirmT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_AcountingFirmT.Font = new System.Drawing.Font("微軟正黑體", 9.75F);
            this.comboBox_AcountingFirmT.FormattingEnabled = true;
            this.comboBox_AcountingFirmT.Location = new System.Drawing.Point(103, 11);
            this.comboBox_AcountingFirmT.Name = "comboBox_AcountingFirmT";
            this.comboBox_AcountingFirmT.Size = new System.Drawing.Size(268, 25);
            this.comboBox_AcountingFirmT.TabIndex = 1133;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("微軟正黑體", 9.75F);
            this.label25.Location = new System.Drawing.Point(34, 15);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(73, 17);
            this.label25.TabIndex = 1132;
            this.label25.Text = "開立公司：";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.txt_Footer);
            this.panel1.Controls.Add(this.txt_Footer1);
            this.panel1.Location = new System.Drawing.Point(103, 591);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(276, 85);
            this.panel1.TabIndex = 351;
            // 
            // txt_Footer
            // 
            this.txt_Footer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_Footer.Font = new System.Drawing.Font("微軟正黑體", 9F);
            this.txt_Footer.ForeColor = System.Drawing.Color.ForestGreen;
            this.txt_Footer.Location = new System.Drawing.Point(1, 1);
            this.txt_Footer.Margin = new System.Windows.Forms.Padding(1);
            this.txt_Footer.Multiline = true;
            this.txt_Footer.Name = "txt_Footer";
            this.txt_Footer.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_Footer.Size = new System.Drawing.Size(266, 39);
            this.txt_Footer.TabIndex = 342;
            this.txt_Footer.Text = "柏豐國際專利商標事務所   地址：105臺北市松山區光復南路 統一編號：4xxx14123\r\n                                  " +
    "             TEL：(02)2578-3311         FAX：(02)2578-1234";
            // 
            // txt_Footer1
            // 
            this.txt_Footer1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_Footer1.Font = new System.Drawing.Font("微軟正黑體", 9F);
            this.txt_Footer1.ForeColor = System.Drawing.Color.ForestGreen;
            this.txt_Footer1.Location = new System.Drawing.Point(1, 42);
            this.txt_Footer1.Margin = new System.Windows.Forms.Padding(1);
            this.txt_Footer1.Multiline = true;
            this.txt_Footer1.Name = "txt_Footer1";
            this.txt_Footer1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_Footer1.Size = new System.Drawing.Size(266, 39);
            this.txt_Footer1.TabIndex = 350;
            this.txt_Footer1.Text = " TEL：(02)2578-2711         FAX：(02)2578-5432";
            // 
            // txt_ApplicantName
            // 
            this.txt_ApplicantName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_ApplicantName.Font = new System.Drawing.Font("微軟正黑體", 9.75F);
            this.txt_ApplicantName.ForeColor = System.Drawing.Color.Black;
            this.txt_ApplicantName.Location = new System.Drawing.Point(103, 394);
            this.txt_ApplicantName.Margin = new System.Windows.Forms.Padding(1);
            this.txt_ApplicantName.Name = "txt_ApplicantName";
            this.txt_ApplicantName.Size = new System.Drawing.Size(268, 25);
            this.txt_ApplicantName.TabIndex = 349;
            // 
            // lab_AttorneyName
            // 
            this.lab_AttorneyName.AutoSize = true;
            this.lab_AttorneyName.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.lab_AttorneyName.Location = new System.Drawing.Point(38, 398);
            this.lab_AttorneyName.Name = "lab_AttorneyName";
            this.lab_AttorneyName.Size = new System.Drawing.Size(64, 18);
            this.lab_AttorneyName.TabIndex = 348;
            this.lab_AttorneyName.Text = "申請人：";
            // 
            // numericUpDown_OAttorneyGovFee
            // 
            this.numericUpDown_OAttorneyGovFee.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDown_OAttorneyGovFee.Font = new System.Drawing.Font("微軟正黑體", 9.75F);
            this.numericUpDown_OAttorneyGovFee.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDown_OAttorneyGovFee.Location = new System.Drawing.Point(103, 367);
            this.numericUpDown_OAttorneyGovFee.Margin = new System.Windows.Forms.Padding(1);
            this.numericUpDown_OAttorneyGovFee.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.numericUpDown_OAttorneyGovFee.Name = "numericUpDown_OAttorneyGovFee";
            this.numericUpDown_OAttorneyGovFee.Size = new System.Drawing.Size(268, 25);
            this.numericUpDown_OAttorneyGovFee.TabIndex = 347;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.label1.Location = new System.Drawing.Point(-4, 369);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 18);
            this.label1.TabIndex = 346;
            this.label1.Text = "代收代付總計：";
            // 
            // btn_SaveText
            // 
            this.btn_SaveText.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btn_SaveText.BackgroundImage = global::LawtechPTSystem.Properties.Resources.button_myspace;
            this.btn_SaveText.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_SaveText.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.btn_SaveText.ForeColor = System.Drawing.Color.White;
            this.btn_SaveText.Location = new System.Drawing.Point(146, 684);
            this.btn_SaveText.Name = "btn_SaveText";
            this.btn_SaveText.Size = new System.Drawing.Size(104, 32);
            this.btn_SaveText.TabIndex = 345;
            this.btn_SaveText.Text = "儲存綠字";
            this.btn_SaveText.UseVisualStyleBackColor = true;
            this.btn_SaveText.Click += new System.EventHandler(this.btn_SaveText_Click);
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button2.BackgroundImage = global::LawtechPTSystem.Properties.Resources.btnCancel;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.button2.Location = new System.Drawing.Point(252, 684);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 32);
            this.button2.TabIndex = 333;
            this.button2.Text = "關    閉";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button1.BackgroundImage = global::LawtechPTSystem.Properties.Resources.button_linkedin;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(41, 684);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(104, 32);
            this.button1.TabIndex = 313;
            this.button1.Text = "重整收據單";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            this.groupBox2.Location = new System.Drawing.Point(9, 42);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(370, 186);
            this.groupBox2.TabIndex = 312;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "案  由：";
            // 
            // txt_FeeSubject
            // 
            this.txt_FeeSubject.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_FeeSubject.Font = new System.Drawing.Font("微軟正黑體", 9.75F);
            this.txt_FeeSubject.Location = new System.Drawing.Point(94, 15);
            this.txt_FeeSubject.Name = "txt_FeeSubject";
            this.txt_FeeSubject.Size = new System.Drawing.Size(268, 25);
            this.txt_FeeSubject.TabIndex = 14;
            // 
            // txt_Title
            // 
            this.txt_Title.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_Title.Font = new System.Drawing.Font("微軟正黑體", 9.75F);
            this.txt_Title.Location = new System.Drawing.Point(94, 42);
            this.txt_Title.Name = "txt_Title";
            this.txt_Title.Size = new System.Drawing.Size(268, 25);
            this.txt_Title.TabIndex = 16;
            // 
            // maskedTextBox_ApplicationDate
            // 
            this.maskedTextBox_ApplicationDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.maskedTextBox_ApplicationDate.BackColor = System.Drawing.Color.White;
            this.maskedTextBox_ApplicationDate.Font = new System.Drawing.Font("微軟正黑體", 9.75F);
            this.maskedTextBox_ApplicationDate.ForeColor = System.Drawing.Color.Green;
            this.maskedTextBox_ApplicationDate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.maskedTextBox_ApplicationDate.Location = new System.Drawing.Point(94, 153);
            this.maskedTextBox_ApplicationDate.Mask = "0000-00-00";
            this.maskedTextBox_ApplicationDate.Name = "maskedTextBox_ApplicationDate";
            this.maskedTextBox_ApplicationDate.Size = new System.Drawing.Size(268, 25);
            this.maskedTextBox_ApplicationDate.TabIndex = 307;
            this.maskedTextBox_ApplicationDate.ValidatingType = typeof(System.DateTime);
            // 
            // txt_Country
            // 
            this.txt_Country.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_Country.Font = new System.Drawing.Font("微軟正黑體", 9.75F);
            this.txt_Country.Location = new System.Drawing.Point(94, 69);
            this.txt_Country.Name = "txt_Country";
            this.txt_Country.Size = new System.Drawing.Size(268, 25);
            this.txt_Country.TabIndex = 18;
            // 
            // txt_Kind
            // 
            this.txt_Kind.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_Kind.Font = new System.Drawing.Font("微軟正黑體", 9.75F);
            this.txt_Kind.Location = new System.Drawing.Point(94, 97);
            this.txt_Kind.Name = "txt_Kind";
            this.txt_Kind.Size = new System.Drawing.Size(268, 25);
            this.txt_Kind.TabIndex = 20;
            // 
            // txt_ApplicationNo
            // 
            this.txt_ApplicationNo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_ApplicationNo.Font = new System.Drawing.Font("微軟正黑體", 9.75F);
            this.txt_ApplicationNo.Location = new System.Drawing.Point(94, 125);
            this.txt_ApplicationNo.Name = "txt_ApplicationNo";
            this.txt_ApplicationNo.Size = new System.Drawing.Size(268, 25);
            this.txt_ApplicationNo.TabIndex = 22;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.label7.Location = new System.Drawing.Point(31, 19);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 18);
            this.label7.TabIndex = 13;
            this.label7.Text = "案   由：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.label8.Location = new System.Drawing.Point(15, 47);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(78, 18);
            this.label8.TabIndex = 15;
            this.label8.Text = "專利名稱：";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.label9.Location = new System.Drawing.Point(31, 73);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(62, 18);
            this.label9.TabIndex = 17;
            this.label9.Text = "國   別：";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.label10.Location = new System.Drawing.Point(31, 101);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(62, 18);
            this.label10.TabIndex = 19;
            this.label10.Text = "種   類：";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.label11.Location = new System.Drawing.Point(29, 129);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(64, 18);
            this.label11.TabIndex = 21;
            this.label11.Text = "申請號：";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.label12.Location = new System.Drawing.Point(29, 157);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(64, 18);
            this.label12.TabIndex = 23;
            this.label12.Text = "申請日：";
            // 
            // txt_PPP
            // 
            this.txt_PPP.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_PPP.Font = new System.Drawing.Font("微軟正黑體", 9.75F);
            this.txt_PPP.Location = new System.Drawing.Point(103, 232);
            this.txt_PPP.Margin = new System.Windows.Forms.Padding(1);
            this.txt_PPP.Name = "txt_PPP";
            this.txt_PPP.Size = new System.Drawing.Size(268, 25);
            this.txt_PPP.TabIndex = 6;
            // 
            // txt_PaymentInstructions
            // 
            this.txt_PaymentInstructions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_PaymentInstructions.Font = new System.Drawing.Font("微軟正黑體", 9.75F);
            this.txt_PaymentInstructions.ForeColor = System.Drawing.Color.ForestGreen;
            this.txt_PaymentInstructions.Location = new System.Drawing.Point(103, 422);
            this.txt_PaymentInstructions.Margin = new System.Windows.Forms.Padding(1);
            this.txt_PaymentInstructions.Multiline = true;
            this.txt_PaymentInstructions.Name = "txt_PaymentInstructions";
            this.txt_PaymentInstructions.Size = new System.Drawing.Size(268, 165);
            this.txt_PaymentInstructions.TabIndex = 317;
            // 
            // txt_AttorneyRefNo
            // 
            this.txt_AttorneyRefNo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_AttorneyRefNo.Font = new System.Drawing.Font("微軟正黑體", 9.75F);
            this.txt_AttorneyRefNo.Location = new System.Drawing.Point(103, 286);
            this.txt_AttorneyRefNo.Margin = new System.Windows.Forms.Padding(1);
            this.txt_AttorneyRefNo.Name = "txt_AttorneyRefNo";
            this.txt_AttorneyRefNo.Size = new System.Drawing.Size(268, 25);
            this.txt_AttorneyRefNo.TabIndex = 10;
            // 
            // numericUpDown_OthTotal
            // 
            this.numericUpDown_OthTotal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDown_OthTotal.Font = new System.Drawing.Font("微軟正黑體", 9.75F);
            this.numericUpDown_OthTotal.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDown_OthTotal.Location = new System.Drawing.Point(103, 340);
            this.numericUpDown_OthTotal.Margin = new System.Windows.Forms.Padding(1);
            this.numericUpDown_OthTotal.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.numericUpDown_OthTotal.Name = "numericUpDown_OthTotal";
            this.numericUpDown_OthTotal.Size = new System.Drawing.Size(268, 25);
            this.numericUpDown_OthTotal.TabIndex = 316;
            // 
            // txt_PatentNo
            // 
            this.txt_PatentNo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_PatentNo.Font = new System.Drawing.Font("微軟正黑體", 9.75F);
            this.txt_PatentNo.Location = new System.Drawing.Point(103, 313);
            this.txt_PatentNo.Margin = new System.Windows.Forms.Padding(1);
            this.txt_PatentNo.Name = "txt_PatentNo";
            this.txt_PatentNo.Size = new System.Drawing.Size(268, 25);
            this.txt_PatentNo.TabIndex = 12;
            // 
            // maskedTextBox_RDate
            // 
            this.maskedTextBox_RDate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.maskedTextBox_RDate.BackColor = System.Drawing.Color.White;
            this.maskedTextBox_RDate.Font = new System.Drawing.Font("微軟正黑體", 9.75F);
            this.maskedTextBox_RDate.ForeColor = System.Drawing.Color.Green;
            this.maskedTextBox_RDate.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.maskedTextBox_RDate.Location = new System.Drawing.Point(103, 259);
            this.maskedTextBox_RDate.Margin = new System.Windows.Forms.Padding(1);
            this.maskedTextBox_RDate.Mask = "0000-00-00";
            this.maskedTextBox_RDate.Name = "maskedTextBox_RDate";
            this.maskedTextBox_RDate.Size = new System.Drawing.Size(268, 25);
            this.maskedTextBox_RDate.TabIndex = 306;
            this.maskedTextBox_RDate.ValidatingType = typeof(System.DateTime);
            // 
            // label23
            // 
            this.label23.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.label23.Location = new System.Drawing.Point(52, 622);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(50, 18);
            this.label23.TabIndex = 343;
            this.label23.Text = "頁尾：";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.label19.Location = new System.Drawing.Point(49, 481);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(50, 18);
            this.label19.TabIndex = 336;
            this.label19.Text = "備註：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.label3.Location = new System.Drawing.Point(24, 236);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 18);
            this.label3.TabIndex = 5;
            this.label3.Text = "請款單號：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.label4.Location = new System.Drawing.Point(24, 264);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 18);
            this.label4.TabIndex = 7;
            this.label4.Text = "請款日期：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.label5.Location = new System.Drawing.Point(24, 291);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 18);
            this.label5.TabIndex = 9;
            this.label5.Text = "貴方案號：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.label6.Location = new System.Drawing.Point(24, 315);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 18);
            this.label6.TabIndex = 11;
            this.label6.Text = "本所案號：";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.label17.Location = new System.Drawing.Point(38, 343);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(64, 18);
            this.label17.TabIndex = 315;
            this.label17.Text = "服務費：";
            // 
            // FeeReceiptReport
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(236)))), ((int)(((byte)(247)))));
            this.ClientSize = new System.Drawing.Size(882, 729);
            this.Controls.Add(this.splitContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FeeReceiptReport";
            this.Text = "印收據";
            this.Load += new System.EventHandler(this.FeeReceiptReport_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_OAttorneyGovFee)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_OthTotal)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.Button btn_SaveText;
        private System.Windows.Forms.TextBox txt_Footer;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txt_FeeSubject;
        private System.Windows.Forms.TextBox txt_Title;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_ApplicationDate;
        private System.Windows.Forms.TextBox txt_Country;
        private System.Windows.Forms.TextBox txt_Kind;
        private System.Windows.Forms.TextBox txt_ApplicationNo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txt_PPP;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_PaymentInstructions;
        private System.Windows.Forms.TextBox txt_AttorneyRefNo;
        private System.Windows.Forms.NumericUpDown numericUpDown_OthTotal;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txt_PatentNo;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_RDate;
        private System.Windows.Forms.NumericUpDown numericUpDown_OAttorneyGovFee;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_ApplicantName;
        private System.Windows.Forms.Label lab_AttorneyName;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txt_Footer1;
        private System.Windows.Forms.ComboBox comboBox_AcountingFirmT;
        private System.Windows.Forms.Label label25;
    }
}