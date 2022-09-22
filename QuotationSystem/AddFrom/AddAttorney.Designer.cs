namespace LawtechPTSystem.AddFrom
{
    partial class AddAttorney
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該公開 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改這個方法的內容。
        ///
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddAttorney));
            this.numericUpDown_SN = new System.Windows.Forms.NumericUpDown();
            this.label15 = new System.Windows.Forms.Label();
            this.txt_ID = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.but_Cancel = new System.Windows.Forms.Button();
            this.but_OK = new System.Windows.Forms.Button();
            this.txt_Remark = new System.Windows.Forms.TextBox();
            this.Combo_MotherAttorney = new System.Windows.Forms.ComboBox();
            this.attorneyTBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.qS_DataSet = new QS_DataSet();
            this.txt_BankAccountNo = new System.Windows.Forms.TextBox();
            this.txt_BankAccount = new System.Windows.Forms.TextBox();
            this.txt_payment = new System.Windows.Forms.TextBox();
            this.txt_Bank = new System.Windows.Forms.TextBox();
            this.txt_FAX = new System.Windows.Forms.TextBox();
            this.txt_TEL = new System.Windows.Forms.TextBox();
            this.Combo_Country = new System.Windows.Forms.ComboBox();
            this.countryTBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.txt_Addr = new System.Windows.Forms.TextBox();
            this.txt_Principal = new System.Windows.Forms.TextBox();
            this.txt_AttorneyFirm = new System.Windows.Forms.TextBox();
            this.txt_AttorneySymbol = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.countryTTableAdapter = new QS_DataSetTableAdapters.CountryTTableAdapter();
            this.attorneyTTableAdapter = new QS_DataSetTableAdapters.AttorneyTTableAdapter();
            this.txt_email = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txt_WebSite = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_SN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.attorneyTBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qS_DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.countryTBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // numericUpDown_SN
            // 
            this.numericUpDown_SN.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.numericUpDown_SN.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.numericUpDown_SN.Location = new System.Drawing.Point(116, 12);
            this.numericUpDown_SN.Maximum = new decimal(new int[] {
            9999,
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
            this.label15.Location = new System.Drawing.Point(74, 17);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(41, 20);
            this.label15.TabIndex = 64;
            this.label15.Text = "排序";
            // 
            // txt_ID
            // 
            this.txt_ID.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.txt_ID.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txt_ID.Location = new System.Drawing.Point(340, 43);
            this.txt_ID.MaxLength = 20;
            this.txt_ID.Name = "txt_ID";
            this.txt_ID.Size = new System.Drawing.Size(141, 29);
            this.txt_ID.TabIndex = 2;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.label14.Location = new System.Drawing.Point(269, 47);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(73, 20);
            this.label14.TabIndex = 62;
            this.label14.Text = "統編 / ID";
            // 
            // but_Cancel
            // 
            this.but_Cancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.but_Cancel.BackgroundImage = global::LawtechPTSystem.Properties.Resources.btnCancel;
            this.but_Cancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.but_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.but_Cancel.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.but_Cancel.Location = new System.Drawing.Point(260, 489);
            this.but_Cancel.Name = "but_Cancel";
            this.but_Cancel.Size = new System.Drawing.Size(100, 32);
            this.but_Cancel.TabIndex = 32;
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
            this.but_OK.Location = new System.Drawing.Point(154, 489);
            this.but_OK.Name = "but_OK";
            this.but_OK.Size = new System.Drawing.Size(100, 32);
            this.but_OK.TabIndex = 31;
            this.but_OK.Text = "確   定";
            this.but_OK.UseVisualStyleBackColor = true;
            this.but_OK.Click += new System.EventHandler(this.but_OK_Click);
            // 
            // txt_Remark
            // 
            this.txt_Remark.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.txt_Remark.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txt_Remark.Location = new System.Drawing.Point(116, 367);
            this.txt_Remark.MaxLength = 500;
            this.txt_Remark.Multiline = true;
            this.txt_Remark.Name = "txt_Remark";
            this.txt_Remark.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_Remark.Size = new System.Drawing.Size(365, 100);
            this.txt_Remark.TabIndex = 15;
            // 
            // Combo_MotherAttorney
            // 
            this.Combo_MotherAttorney.DataSource = this.attorneyTBindingSource;
            this.Combo_MotherAttorney.DisplayMember = "AttorneySymbol";
            this.Combo_MotherAttorney.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Combo_MotherAttorney.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.Combo_MotherAttorney.FormattingEnabled = true;
            this.Combo_MotherAttorney.ImeMode = System.Windows.Forms.ImeMode.Close;
            this.Combo_MotherAttorney.Location = new System.Drawing.Point(81, 533);
            this.Combo_MotherAttorney.Name = "Combo_MotherAttorney";
            this.Combo_MotherAttorney.Size = new System.Drawing.Size(31, 28);
            this.Combo_MotherAttorney.TabIndex = 8;
            this.Combo_MotherAttorney.ValueMember = "AttorneyKEY";
            this.Combo_MotherAttorney.Visible = false;
            // 
            // attorneyTBindingSource
            // 
            this.attorneyTBindingSource.DataMember = "AttorneyT";
            this.attorneyTBindingSource.DataSource = this.qS_DataSet;
            // 
            // qS_DataSet
            // 
            this.qS_DataSet.DataSetName = "QS_DataSet";
            this.qS_DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // txt_BankAccountNo
            // 
            this.txt_BankAccountNo.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.txt_BankAccountNo.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txt_BankAccountNo.Location = new System.Drawing.Point(340, 301);
            this.txt_BankAccountNo.MaxLength = 50;
            this.txt_BankAccountNo.Name = "txt_BankAccountNo";
            this.txt_BankAccountNo.Size = new System.Drawing.Size(141, 29);
            this.txt_BankAccountNo.TabIndex = 13;
            // 
            // txt_BankAccount
            // 
            this.txt_BankAccount.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.txt_BankAccount.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txt_BankAccount.Location = new System.Drawing.Point(116, 301);
            this.txt_BankAccount.MaxLength = 100;
            this.txt_BankAccount.Name = "txt_BankAccount";
            this.txt_BankAccount.Size = new System.Drawing.Size(152, 29);
            this.txt_BankAccount.TabIndex = 12;
            // 
            // txt_payment
            // 
            this.txt_payment.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.txt_payment.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txt_payment.Location = new System.Drawing.Point(116, 334);
            this.txt_payment.MaxLength = 100;
            this.txt_payment.Name = "txt_payment";
            this.txt_payment.Size = new System.Drawing.Size(365, 29);
            this.txt_payment.TabIndex = 14;
            this.txt_payment.Text = "請款日起30天內匯款";
            // 
            // txt_Bank
            // 
            this.txt_Bank.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.txt_Bank.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txt_Bank.Location = new System.Drawing.Point(116, 268);
            this.txt_Bank.MaxLength = 100;
            this.txt_Bank.Name = "txt_Bank";
            this.txt_Bank.Size = new System.Drawing.Size(365, 29);
            this.txt_Bank.TabIndex = 11;
            // 
            // txt_FAX
            // 
            this.txt_FAX.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.txt_FAX.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txt_FAX.Location = new System.Drawing.Point(340, 169);
            this.txt_FAX.MaxLength = 50;
            this.txt_FAX.Name = "txt_FAX";
            this.txt_FAX.Size = new System.Drawing.Size(141, 29);
            this.txt_FAX.TabIndex = 8;
            // 
            // txt_TEL
            // 
            this.txt_TEL.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.txt_TEL.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txt_TEL.Location = new System.Drawing.Point(116, 169);
            this.txt_TEL.MaxLength = 50;
            this.txt_TEL.Name = "txt_TEL";
            this.txt_TEL.Size = new System.Drawing.Size(152, 29);
            this.txt_TEL.TabIndex = 7;
            // 
            // Combo_Country
            // 
            this.Combo_Country.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.Combo_Country.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.Combo_Country.DataSource = this.countryTBindingSource;
            this.Combo_Country.DisplayMember = "Country";
            this.Combo_Country.Font = new System.Drawing.Font("微軟正黑體", 14F);
            this.Combo_Country.FormattingEnabled = true;
            this.Combo_Country.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Combo_Country.Location = new System.Drawing.Point(340, 104);
            this.Combo_Country.Name = "Combo_Country";
            this.Combo_Country.Size = new System.Drawing.Size(141, 32);
            this.Combo_Country.TabIndex = 5;
            this.Combo_Country.ValueMember = "CountrySymbol";
            // 
            // countryTBindingSource
            // 
            this.countryTBindingSource.DataMember = "CountryT";
            this.countryTBindingSource.DataSource = this.qS_DataSet;
            this.countryTBindingSource.Sort = "SN";
            // 
            // txt_Addr
            // 
            this.txt_Addr.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.txt_Addr.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txt_Addr.Location = new System.Drawing.Point(116, 137);
            this.txt_Addr.MaxLength = 150;
            this.txt_Addr.Name = "txt_Addr";
            this.txt_Addr.Size = new System.Drawing.Size(365, 29);
            this.txt_Addr.TabIndex = 6;
            // 
            // txt_Principal
            // 
            this.txt_Principal.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.txt_Principal.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txt_Principal.Location = new System.Drawing.Point(116, 105);
            this.txt_Principal.MaxLength = 50;
            this.txt_Principal.Name = "txt_Principal";
            this.txt_Principal.Size = new System.Drawing.Size(152, 29);
            this.txt_Principal.TabIndex = 4;
            // 
            // txt_AttorneyFirm
            // 
            this.txt_AttorneyFirm.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.txt_AttorneyFirm.ForeColor = System.Drawing.Color.Blue;
            this.txt_AttorneyFirm.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txt_AttorneyFirm.Location = new System.Drawing.Point(116, 74);
            this.txt_AttorneyFirm.MaxLength = 100;
            this.txt_AttorneyFirm.Name = "txt_AttorneyFirm";
            this.txt_AttorneyFirm.Size = new System.Drawing.Size(365, 29);
            this.txt_AttorneyFirm.TabIndex = 3;
            // 
            // txt_AttorneySymbol
            // 
            this.txt_AttorneySymbol.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.txt_AttorneySymbol.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txt_AttorneySymbol.Location = new System.Drawing.Point(116, 43);
            this.txt_AttorneySymbol.MaxLength = 20;
            this.txt_AttorneySymbol.Name = "txt_AttorneySymbol";
            this.txt_AttorneySymbol.Size = new System.Drawing.Size(152, 29);
            this.txt_AttorneySymbol.TabIndex = 1;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.label13.Location = new System.Drawing.Point(42, 338);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(73, 20);
            this.label13.TabIndex = 46;
            this.label13.Text = "付款方式";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.label12.Location = new System.Drawing.Point(298, 305);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(41, 20);
            this.label12.TabIndex = 45;
            this.label12.Text = "帳號";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.label11.Location = new System.Drawing.Point(74, 396);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(41, 20);
            this.label11.TabIndex = 44;
            this.label11.Text = "備註";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.label3.Location = new System.Drawing.Point(74, 271);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 20);
            this.label3.TabIndex = 42;
            this.label3.Text = "銀行";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.label10.Location = new System.Drawing.Point(74, 306);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 20);
            this.label10.TabIndex = 43;
            this.label10.Text = "帳戶";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.label9.Location = new System.Drawing.Point(23, 537);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(57, 20);
            this.label9.TabIndex = 41;
            this.label9.Text = "母公司";
            this.label9.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.label8.Location = new System.Drawing.Point(299, 173);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 20);
            this.label8.TabIndex = 40;
            this.label8.Text = "傳真";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.label7.Location = new System.Drawing.Point(74, 174);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 20);
            this.label7.TabIndex = 39;
            this.label7.Text = "電話";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.label6.Location = new System.Drawing.Point(298, 109);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 20);
            this.label6.TabIndex = 38;
            this.label6.Text = "國別";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.label5.Location = new System.Drawing.Point(42, 141);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 20);
            this.label5.TabIndex = 37;
            this.label5.Text = "通訊地址";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.label4.Location = new System.Drawing.Point(10, 109);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 20);
            this.label4.TabIndex = 36;
            this.label4.Text = "事務所負責人";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(26, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 20);
            this.label2.TabIndex = 35;
            this.label2.Text = "事務所名稱";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.label1.Location = new System.Drawing.Point(26, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 20);
            this.label1.TabIndex = 34;
            this.label1.Text = "事務所代碼";
            // 
            // countryTTableAdapter
            // 
            this.countryTTableAdapter.ClearBeforeFill = true;
            // 
            // attorneyTTableAdapter
            // 
            this.attorneyTTableAdapter.ClearBeforeFill = true;
            // 
            // txt_email
            // 
            this.txt_email.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.txt_email.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txt_email.Location = new System.Drawing.Point(116, 202);
            this.txt_email.MaxLength = 50;
            this.txt_email.Name = "txt_email";
            this.txt_email.Size = new System.Drawing.Size(365, 29);
            this.txt_email.TabIndex = 9;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.label16.Location = new System.Drawing.Point(42, 205);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(73, 20);
            this.label16.TabIndex = 66;
            this.label16.Text = "電子信箱";
            // 
            // txt_WebSite
            // 
            this.txt_WebSite.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.txt_WebSite.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.txt_WebSite.Location = new System.Drawing.Point(116, 235);
            this.txt_WebSite.MaxLength = 50;
            this.txt_WebSite.Name = "txt_WebSite";
            this.txt_WebSite.Size = new System.Drawing.Size(365, 29);
            this.txt_WebSite.TabIndex = 10;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.BackColor = System.Drawing.Color.Transparent;
            this.label17.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.label17.Location = new System.Drawing.Point(74, 238);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(41, 20);
            this.label17.TabIndex = 68;
            this.label17.Text = "網址";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.Color.Transparent;
            this.label18.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label18.ForeColor = System.Drawing.Color.Green;
            this.label18.Location = new System.Drawing.Point(336, 470);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(142, 17);
            this.label18.TabIndex = 1088;
            this.label18.Text = "Shift+Enter：換下一行";
            // 
            // AddAttorney
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = global::LawtechPTSystem.Properties.Resources.bg1;
            this.CancelButton = this.but_Cancel;
            this.ClientSize = new System.Drawing.Size(506, 534);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.txt_WebSite);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.txt_email);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.numericUpDown_SN);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.txt_ID);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.but_Cancel);
            this.Controls.Add(this.but_OK);
            this.Controls.Add(this.txt_Remark);
            this.Controls.Add(this.Combo_MotherAttorney);
            this.Controls.Add(this.txt_BankAccountNo);
            this.Controls.Add(this.txt_BankAccount);
            this.Controls.Add(this.txt_payment);
            this.Controls.Add(this.txt_Bank);
            this.Controls.Add(this.txt_FAX);
            this.Controls.Add(this.txt_TEL);
            this.Controls.Add(this.Combo_Country);
            this.Controls.Add(this.txt_Addr);
            this.Controls.Add(this.txt_Principal);
            this.Controls.Add(this.txt_AttorneyFirm);
            this.Controls.Add(this.txt_AttorneySymbol);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddAttorney";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "新增事務所";
            this.Load += new System.EventHandler(this.AddAttorney_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AddAttorney_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_SN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.attorneyTBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qS_DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.countryTBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown numericUpDown_SN;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txt_ID;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button but_Cancel;
        private System.Windows.Forms.Button but_OK;
        private System.Windows.Forms.TextBox txt_Remark;
        private System.Windows.Forms.ComboBox Combo_MotherAttorney;
        private System.Windows.Forms.TextBox txt_BankAccountNo;
        private System.Windows.Forms.TextBox txt_BankAccount;
        private System.Windows.Forms.TextBox txt_payment;
        private System.Windows.Forms.TextBox txt_Bank;
        private System.Windows.Forms.TextBox txt_FAX;
        private System.Windows.Forms.TextBox txt_TEL;
        private System.Windows.Forms.ComboBox Combo_Country;
        private System.Windows.Forms.TextBox txt_Addr;
        private System.Windows.Forms.TextBox txt_Principal;
        private System.Windows.Forms.TextBox txt_AttorneyFirm;
        private System.Windows.Forms.TextBox txt_AttorneySymbol;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private QS_DataSet qS_DataSet;
        private System.Windows.Forms.BindingSource countryTBindingSource;
        private LawtechPTSystem.QS_DataSetTableAdapters.CountryTTableAdapter countryTTableAdapter;
        private System.Windows.Forms.BindingSource attorneyTBindingSource;
        private LawtechPTSystem.QS_DataSetTableAdapters.AttorneyTTableAdapter attorneyTTableAdapter;
        private System.Windows.Forms.TextBox txt_email;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txt_WebSite;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
    }
}