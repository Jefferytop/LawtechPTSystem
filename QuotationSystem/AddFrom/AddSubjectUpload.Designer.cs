namespace LawtechPTSystem.AddFrom
{
    partial class AddSubjectUpload
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
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.label11 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.cboWorker = new System.Windows.Forms.ComboBox();
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.maskedEndDate = new System.Windows.Forms.MaskedTextBox();
            this.maskedStartDate = new System.Windows.Forms.MaskedTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.cboSelectedItem = new System.Windows.Forms.ComboBox();
            this.dgvUploadFile = new System.Windows.Forms.DataGridView();
            this.UploadKey = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ArticleTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Kind = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.kindTBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.qS_DataSet = new QS_DataSet();
            this.Country = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.countryTBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Author = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BuildDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BuildWorker = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.workerTBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.FilePath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kindTTableAdapter = new QS_DataSetTableAdapters.KindTTableAdapter();
            this.countryTTableAdapter = new QS_DataSetTableAdapters.CountryTTableAdapter();
            this.workerTTableAdapter = new QS_DataSetTableAdapters.WorkerTTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUploadFile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kindTBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qS_DataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.countryTBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.workerTBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(407, 50);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowTemplate.Height = 24;
            this.dataGridView2.Size = new System.Drawing.Size(359, 533);
            this.dataGridView2.TabIndex = 6;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold);
            this.label11.Location = new System.Drawing.Point(377, 285);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(34, 21);
            this.label11.TabIndex = 2;
            this.label11.Text = ">>";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.button1.Location = new System.Drawing.Point(310, 589);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 32);
            this.button1.TabIndex = 7;
            this.button1.Text = "確定";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.button2.Location = new System.Drawing.Point(391, 589);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 32);
            this.button2.TabIndex = 8;
            this.button2.Text = "取消";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // cboWorker
            // 
            this.cboWorker.DisplayMember = "Name";
            this.cboWorker.Font = new System.Drawing.Font("微軟正黑體", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cboWorker.FormattingEnabled = true;
            this.cboWorker.Location = new System.Drawing.Point(138, 19);
            this.cboWorker.Name = "cboWorker";
            this.cboWorker.Size = new System.Drawing.Size(185, 27);
            this.cboWorker.TabIndex = 17;
            this.cboWorker.ValueMember = "WorkerKey";
            // 
            // txtFilter
            // 
            this.txtFilter.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtFilter.Location = new System.Drawing.Point(138, 19);
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(185, 27);
            this.txtFilter.TabIndex = 13;
            // 
            // maskedEndDate
            // 
            this.maskedEndDate.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.maskedEndDate.ForeColor = System.Drawing.Color.Green;
            this.maskedEndDate.Location = new System.Drawing.Point(244, 18);
            this.maskedEndDate.Mask = "0000-00-00";
            this.maskedEndDate.Name = "maskedEndDate";
            this.maskedEndDate.Size = new System.Drawing.Size(76, 27);
            this.maskedEndDate.TabIndex = 3;
            this.maskedEndDate.ValidatingType = typeof(System.DateTime);
            this.maskedEndDate.Visible = false;
            // 
            // maskedStartDate
            // 
            this.maskedStartDate.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.maskedStartDate.ForeColor = System.Drawing.Color.Green;
            this.maskedStartDate.Location = new System.Drawing.Point(139, 18);
            this.maskedStartDate.Mask = "0000-00-00";
            this.maskedStartDate.Name = "maskedStartDate";
            this.maskedStartDate.Size = new System.Drawing.Size(75, 27);
            this.maskedStartDate.TabIndex = 1;
            this.maskedStartDate.ValidatingType = typeof(System.DateTime);
            this.maskedStartDate.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(219, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "～";
            this.label1.Visible = false;
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.btnSearch.Location = new System.Drawing.Point(324, 18);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(57, 26);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "查詢";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // cboSelectedItem
            // 
            this.cboSelectedItem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSelectedItem.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cboSelectedItem.FormattingEnabled = true;
            this.cboSelectedItem.Items.AddRange(new object[] {
            "文章篇名",
            "簡述",
            "作者",
            "上傳時間",
            "上傳人",
            "關鍵字"});
            this.cboSelectedItem.Location = new System.Drawing.Point(15, 19);
            this.cboSelectedItem.Name = "cboSelectedItem";
            this.cboSelectedItem.Size = new System.Drawing.Size(121, 27);
            this.cboSelectedItem.TabIndex = 0;
            this.cboSelectedItem.SelectedIndexChanged += new System.EventHandler(this.cboSelectedItem_SelectedIndexChanged);
            // 
            // dgvUploadFile
            // 
            this.dgvUploadFile.AllowUserToAddRows = false;
            this.dgvUploadFile.AllowUserToDeleteRows = false;
            this.dgvUploadFile.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUploadFile.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.UploadKey,
            this.ArticleTitle,
            this.Kind,
            this.Country,
            this.Description,
            this.Author,
            this.BuildDate,
            this.BuildWorker,
            this.FilePath});
            this.dgvUploadFile.Location = new System.Drawing.Point(12, 50);
            this.dgvUploadFile.Name = "dgvUploadFile";
            this.dgvUploadFile.RowTemplate.Height = 24;
            this.dgvUploadFile.Size = new System.Drawing.Size(359, 533);
            this.dgvUploadFile.TabIndex = 5;
            // 
            // UploadKey
            // 
            this.UploadKey.DataPropertyName = "UploadKey";
            this.UploadKey.HeaderText = "UploadKey";
            this.UploadKey.Name = "UploadKey";
            this.UploadKey.ReadOnly = true;
            this.UploadKey.Visible = false;
            // 
            // ArticleTitle
            // 
            this.ArticleTitle.DataPropertyName = "ArticleTitle";
            this.ArticleTitle.HeaderText = "篇名";
            this.ArticleTitle.Name = "ArticleTitle";
            this.ArticleTitle.ReadOnly = true;
            // 
            // Kind
            // 
            this.Kind.DataPropertyName = "KindSN";
            this.Kind.DataSource = this.kindTBindingSource;
            this.Kind.DisplayMember = "Kind";
            this.Kind.HeaderText = "專利種類";
            this.Kind.Name = "Kind";
            this.Kind.ReadOnly = true;
            this.Kind.ValueMember = "KindSN";
            // 
            // kindTBindingSource
            // 
            this.kindTBindingSource.DataMember = "KindT";
            this.kindTBindingSource.DataSource = this.qS_DataSet;
            // 
            // qS_DataSet
            // 
            this.qS_DataSet.DataSetName = "QS_DataSet";
            this.qS_DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // Country
            // 
            this.Country.DataPropertyName = "CountrySymbol";
            this.Country.DataSource = this.countryTBindingSource;
            this.Country.DisplayMember = "Country";
            this.Country.HeaderText = "國別";
            this.Country.Name = "Country";
            this.Country.ReadOnly = true;
            this.Country.ValueMember = "CountrySymbol";
            // 
            // countryTBindingSource
            // 
            this.countryTBindingSource.DataMember = "CountryT";
            this.countryTBindingSource.DataSource = this.qS_DataSet;
            // 
            // Description
            // 
            this.Description.DataPropertyName = "Description";
            this.Description.HeaderText = "簡述";
            this.Description.Name = "Description";
            // 
            // Author
            // 
            this.Author.DataPropertyName = "Author";
            this.Author.HeaderText = "作者";
            this.Author.Name = "Author";
            this.Author.ReadOnly = true;
            // 
            // BuildDate
            // 
            this.BuildDate.DataPropertyName = "BuildDate";
            this.BuildDate.HeaderText = "上傳時間";
            this.BuildDate.Name = "BuildDate";
            this.BuildDate.ReadOnly = true;
            // 
            // BuildWorker
            // 
            this.BuildWorker.DataPropertyName = "BuildWorker";
            this.BuildWorker.DataSource = this.workerTBindingSource;
            this.BuildWorker.DisplayMember = "Name";
            this.BuildWorker.HeaderText = "上傳人";
            this.BuildWorker.Name = "BuildWorker";
            this.BuildWorker.ReadOnly = true;
            this.BuildWorker.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.BuildWorker.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.BuildWorker.ValueMember = "WorkerKey";
            // 
            // workerTBindingSource
            // 
            this.workerTBindingSource.DataMember = "WorkerT";
            this.workerTBindingSource.DataSource = this.qS_DataSet;
            // 
            // FilePath
            // 
            this.FilePath.DataPropertyName = "FilePath";
            this.FilePath.HeaderText = "FilePath";
            this.FilePath.Name = "FilePath";
            this.FilePath.ReadOnly = true;
            this.FilePath.Visible = false;
            // 
            // kindTTableAdapter
            // 
            this.kindTTableAdapter.ClearBeforeFill = true;
            // 
            // countryTTableAdapter
            // 
            this.countryTTableAdapter.ClearBeforeFill = true;
            // 
            // workerTTableAdapter
            // 
            this.workerTTableAdapter.ClearBeforeFill = true;
            // 
            // AddSubjectUpload
            // 
            this.AcceptButton = this.btnSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CancelButton = this.button2;
            this.ClientSize = new System.Drawing.Size(780, 629);
            this.Controls.Add(this.dgvUploadFile);
            this.Controls.Add(this.maskedEndDate);
            this.Controls.Add(this.maskedStartDate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.cboSelectedItem);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.cboWorker);
            this.Controls.Add(this.txtFilter);
            this.Controls.Add(this.label11);
            this.Font = new System.Drawing.Font("微軟正黑體", 9F);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddSubjectUpload";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "新增相關文章";
            this.Load += new System.EventHandler(this.AddSubjectUpload_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AddSubjectUpload_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUploadFile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kindTBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qS_DataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.countryTBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.workerTBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox cboWorker;
        private System.Windows.Forms.TextBox txtFilter;
        private System.Windows.Forms.MaskedTextBox maskedEndDate;
        private System.Windows.Forms.MaskedTextBox maskedStartDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ComboBox cboSelectedItem;
        private System.Windows.Forms.DataGridView dgvUploadFile;
        private QS_DataSet qS_DataSet;
        private System.Windows.Forms.BindingSource kindTBindingSource;
        private LawtechPTSystem.QS_DataSetTableAdapters.KindTTableAdapter kindTTableAdapter;
        private System.Windows.Forms.BindingSource countryTBindingSource;
        private LawtechPTSystem.QS_DataSetTableAdapters.CountryTTableAdapter countryTTableAdapter;
        private System.Windows.Forms.BindingSource workerTBindingSource;
        private LawtechPTSystem.QS_DataSetTableAdapters.WorkerTTableAdapter workerTTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn UploadKey;
        private System.Windows.Forms.DataGridViewTextBoxColumn ArticleTitle;
        private System.Windows.Forms.DataGridViewComboBoxColumn Kind;
        private System.Windows.Forms.DataGridViewComboBoxColumn Country;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn Author;
        private System.Windows.Forms.DataGridViewTextBoxColumn BuildDate;
        private System.Windows.Forms.DataGridViewComboBoxColumn BuildWorker;
        private System.Windows.Forms.DataGridViewTextBoxColumn FilePath;
    }
}