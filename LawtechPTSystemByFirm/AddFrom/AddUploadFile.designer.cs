namespace LawtechPTSystemByFirm.AddFrom
{
    partial class AddUploadFile
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddUploadFile));
            this.cboKind2 = new System.Windows.Forms.ComboBox();
            this.kindTBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.qS_DataSet = new LawtechPTSystemByFirm.QS_DataSet();
            this.cboCountry = new System.Windows.Forms.ComboBox();
            this.countryTBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnOK = new System.Windows.Forms.Button();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtArticleTitle = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtAuthor = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtKeyWords = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.kindTTableAdapter = new LawtechPTSystemByFirm.QS_DataSetTableAdapters.KindTTableAdapter();
            this.countryTTableAdapter = new LawtechPTSystemByFirm.QS_DataSetTableAdapters.CountryTTableAdapter();
            this.button1 = new System.Windows.Forms.Button();
            this.txtReference = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtRefURL = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.cboKind1 = new System.Windows.Forms.ComboBox();
            this.kindItemBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.kindItemTableAdapter = new LawtechPTSystemByFirm.QS_DataSetTableAdapters.KindItemTableAdapter();
            this.lblStart1 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.kindTBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qS_DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.countryTBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kindItemBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // cboKind2
            // 
            this.cboKind2.DataSource = this.kindTBindingSource;
            this.cboKind2.DisplayMember = "Kind";
            this.cboKind2.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cboKind2.FormattingEnabled = true;
            this.cboKind2.Location = new System.Drawing.Point(467, 438);
            this.cboKind2.Name = "cboKind2";
            this.cboKind2.Size = new System.Drawing.Size(36, 27);
            this.cboKind2.TabIndex = 1;
            this.cboKind2.ValueMember = "KindSN";
            this.cboKind2.Visible = false;
            // 
            // kindTBindingSource
            // 
            this.kindTBindingSource.DataMember = "KindT";
            this.kindTBindingSource.DataSource = this.qS_DataSet;
            this.kindTBindingSource.Sort = "SN";
            // 
            // qS_DataSet
            // 
            this.qS_DataSet.DataSetName = "QS_DataSet";
            this.qS_DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // cboCountry
            // 
            this.cboCountry.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboCountry.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboCountry.DataSource = this.countryTBindingSource;
            this.cboCountry.DisplayMember = "Country";
            this.cboCountry.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cboCountry.FormattingEnabled = true;
            this.cboCountry.Location = new System.Drawing.Point(105, 62);
            this.cboCountry.Name = "cboCountry";
            this.cboCountry.Size = new System.Drawing.Size(398, 27);
            this.cboCountry.TabIndex = 2;
            this.cboCountry.ValueMember = "CountrySymbol";
            // 
            // countryTBindingSource
            // 
            this.countryTBindingSource.DataMember = "CountryT";
            this.countryTBindingSource.DataSource = this.qS_DataSet;
            this.countryTBindingSource.Sort = "SN";
            // 
            // btnOK
            // 
            this.btnOK.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnOK.BackgroundImage = global::LawtechPTSystemByFirm.Properties.Resources.btnComfirm;
            this.btnOK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnOK.Location = new System.Drawing.Point(160, 438);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(100, 32);
            this.btnOK.TabIndex = 9;
            this.btnOK.Text = "確定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // txtFilePath
            // 
            this.txtFilePath.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtFilePath.Location = new System.Drawing.Point(99, 416);
            this.txtFilePath.MaxLength = 1000;
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.Size = new System.Drawing.Size(36, 27);
            this.txtFilePath.TabIndex = 21;
            this.txtFilePath.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(394, 440);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 19);
            this.label1.TabIndex = 4;
            this.label1.Text = "文章種類2";
            this.label1.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(64, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 19);
            this.label2.TabIndex = 5;
            this.label2.Text = "國別";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(64, 263);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 19);
            this.label3.TabIndex = 6;
            this.label3.Text = "簡述";
            // 
            // txtDescription
            // 
            this.txtDescription.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtDescription.Location = new System.Drawing.Point(105, 237);
            this.txtDescription.MaxLength = 3000;
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtDescription.Size = new System.Drawing.Size(398, 173);
            this.txtDescription.TabIndex = 8;
            // 
            // txtArticleTitle
            // 
            this.txtArticleTitle.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtArticleTitle.Location = new System.Drawing.Point(105, 91);
            this.txtArticleTitle.MaxLength = 500;
            this.txtArticleTitle.Name = "txtArticleTitle";
            this.txtArticleTitle.Size = new System.Drawing.Size(398, 27);
            this.txtArticleTitle.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.Location = new System.Drawing.Point(64, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 19);
            this.label4.TabIndex = 8;
            this.label4.Text = "篇名";
            // 
            // txtAuthor
            // 
            this.txtAuthor.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtAuthor.Location = new System.Drawing.Point(105, 120);
            this.txtAuthor.MaxLength = 200;
            this.txtAuthor.Name = "txtAuthor";
            this.txtAuthor.Size = new System.Drawing.Size(398, 27);
            this.txtAuthor.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label5.Location = new System.Drawing.Point(64, 122);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 19);
            this.label5.TabIndex = 10;
            this.label5.Text = "作者";
            // 
            // txtKeyWords
            // 
            this.txtKeyWords.BackColor = System.Drawing.Color.White;
            this.txtKeyWords.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtKeyWords.Location = new System.Drawing.Point(105, 149);
            this.txtKeyWords.MaxLength = 300;
            this.txtKeyWords.Name = "txtKeyWords";
            this.txtKeyWords.Size = new System.Drawing.Size(398, 27);
            this.txtKeyWords.TabIndex = 5;
            this.txtKeyWords.DoubleClick += new System.EventHandler(this.txtKeyWords_DoubleClick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label6.Location = new System.Drawing.Point(19, 151);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 19);
            this.label6.TabIndex = 12;
            this.label6.Text = "關鍵字設定";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label7.Location = new System.Drawing.Point(-1, 421);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(99, 19);
            this.label7.TabIndex = 14;
            this.label7.Text = "上傳檔案路徑";
            this.label7.Visible = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnCancel.BackgroundImage = global::LawtechPTSystemByFirm.Properties.Resources.btnCancel;
            this.btnCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnCancel.Location = new System.Drawing.Point(266, 438);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 32);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // kindTTableAdapter
            // 
            this.kindTTableAdapter.ClearBeforeFill = true;
            // 
            // countryTTableAdapter
            // 
            this.countryTTableAdapter.ClearBeforeFill = true;
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::LawtechPTSystemByFirm.Properties.Resources.btnComfirm;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button1.Location = new System.Drawing.Point(134, 416);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(51, 26);
            this.button1.TabIndex = 23;
            this.button1.Text = "瀏覽";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtReference
            // 
            this.txtReference.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtReference.Location = new System.Drawing.Point(105, 178);
            this.txtReference.MaxLength = 300;
            this.txtReference.Name = "txtReference";
            this.txtReference.Size = new System.Drawing.Size(398, 27);
            this.txtReference.TabIndex = 6;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label8.Location = new System.Drawing.Point(64, 180);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(39, 19);
            this.label8.TabIndex = 17;
            this.label8.Text = "出處";
            // 
            // txtRefURL
            // 
            this.txtRefURL.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtRefURL.Location = new System.Drawing.Point(105, 207);
            this.txtRefURL.MaxLength = 3000;
            this.txtRefURL.Name = "txtRefURL";
            this.txtRefURL.Size = new System.Drawing.Size(398, 27);
            this.txtRefURL.TabIndex = 7;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label9.Location = new System.Drawing.Point(34, 209);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(69, 19);
            this.label9.TabIndex = 19;
            this.label9.Text = "網路位置";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label10.Location = new System.Drawing.Point(34, 35);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(69, 19);
            this.label10.TabIndex = 22;
            this.label10.Text = "文章種類";
            // 
            // cboKind1
            // 
            this.cboKind1.DataSource = this.kindItemBindingSource;
            this.cboKind1.DisplayMember = "string";
            this.cboKind1.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cboKind1.FormattingEnabled = true;
            this.cboKind1.Location = new System.Drawing.Point(105, 33);
            this.cboKind1.Name = "cboKind1";
            this.cboKind1.Size = new System.Drawing.Size(398, 27);
            this.cboKind1.TabIndex = 0;
            this.cboKind1.ValueMember = "value";
            this.cboKind1.SelectedIndexChanged += new System.EventHandler(this.cboKind1_SelectedIndexChanged);
            // 
            // kindItemBindingSource
            // 
            this.kindItemBindingSource.DataMember = "KindItem";
            this.kindItemBindingSource.DataSource = this.qS_DataSet;
            // 
            // kindItemTableAdapter
            // 
            this.kindItemTableAdapter.ClearBeforeFill = true;
            // 
            // lblStart1
            // 
            this.lblStart1.AutoSize = true;
            this.lblStart1.BackColor = System.Drawing.Color.Transparent;
            this.lblStart1.ForeColor = System.Drawing.Color.Red;
            this.lblStart1.Location = new System.Drawing.Point(49, 98);
            this.lblStart1.Name = "lblStart1";
            this.lblStart1.Size = new System.Drawing.Size(11, 12);
            this.lblStart1.TabIndex = 28;
            this.lblStart1.Text = "*";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.Color.Transparent;
            this.label11.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label11.ForeColor = System.Drawing.Color.Green;
            this.label11.Location = new System.Drawing.Point(362, 412);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(142, 17);
            this.label11.TabIndex = 1088;
            this.label11.Text = "Shift+Enter：換下一行";
            // 
            // AddUploadFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::LawtechPTSystemByFirm.Properties.Resources.bg1;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(526, 482);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.cboKind1);
            this.Controls.Add(this.txtRefURL);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtReference);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtKeyWords);
            this.Controls.Add(this.txtAuthor);
            this.Controls.Add(this.txtArticleTitle);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtFilePath);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.cboCountry);
            this.Controls.Add(this.cboKind2);
            this.Controls.Add(this.lblStart1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label7);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddUploadFile";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "知識管理";
            this.Load += new System.EventHandler(this.AddUploadFile_Load);
            ((System.ComponentModel.ISupportInitialize)(this.kindTBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qS_DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.countryTBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kindItemBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboKind2;
        private System.Windows.Forms.ComboBox cboCountry;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox txtArticleTitle;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtAuthor;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtKeyWords;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnCancel;
        private QS_DataSet qS_DataSet;
        private System.Windows.Forms.BindingSource kindTBindingSource;
        private LawtechPTSystemByFirm.QS_DataSetTableAdapters.KindTTableAdapter kindTTableAdapter;
        private System.Windows.Forms.BindingSource countryTBindingSource;
        private LawtechPTSystemByFirm.QS_DataSetTableAdapters.CountryTTableAdapter countryTTableAdapter;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtReference;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtRefURL;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cboKind1;
        private System.Windows.Forms.BindingSource kindItemBindingSource;
        private LawtechPTSystemByFirm.QS_DataSetTableAdapters.KindItemTableAdapter kindItemTableAdapter;
        private System.Windows.Forms.Label lblStart1;
        private System.Windows.Forms.Label label11;
    }
}