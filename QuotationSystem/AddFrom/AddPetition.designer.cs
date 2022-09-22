namespace LawtechPTSystem.AddFrom
{
    partial class AddPetition
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddPetition));
            this.QS_DataSet1 = new LawtechPTSystem.QS_DataSet();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox_Country = new System.Windows.Forms.ComboBox();
            this.countryTBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.comboBox_Kind = new System.Windows.Forms.ComboBox();
            this.kindTBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.countryTTableAdapter = new LawtechPTSystem.QS_DataSetTableAdapters.CountryTTableAdapter();
            this.kindTTableAdapter = new LawtechPTSystem.QS_DataSetTableAdapters.KindTTableAdapter();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_PetitionName = new System.Windows.Forms.TextBox();
            this.txt_PetitionNameEN = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.txt_PetitionNameCHS = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.QS_DataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.countryTBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.kindTBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // QS_DataSet1
            // 
            this.QS_DataSet1.DataSetName = "QS_DataSet1";
            this.QS_DataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.label2.Location = new System.Drawing.Point(70, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "國別";
            // 
            // comboBox_Country
            // 
            this.comboBox_Country.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBox_Country.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox_Country.DataSource = this.countryTBindingSource;
            this.comboBox_Country.DisplayMember = "Country";
            this.comboBox_Country.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.comboBox_Country.FormattingEnabled = true;
            this.comboBox_Country.Location = new System.Drawing.Point(112, 26);
            this.comboBox_Country.Name = "comboBox_Country";
            this.comboBox_Country.Size = new System.Drawing.Size(220, 28);
            this.comboBox_Country.TabIndex = 0;
            this.comboBox_Country.ValueMember = "CountrySymbol";
            // 
            // countryTBindingSource
            // 
            this.countryTBindingSource.DataMember = "CountryT";
            this.countryTBindingSource.DataSource = this.QS_DataSet1;
            // 
            // comboBox_Kind
            // 
            this.comboBox_Kind.DataSource = this.kindTBindingSource;
            this.comboBox_Kind.DisplayMember = "Kind";
            this.comboBox_Kind.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_Kind.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.comboBox_Kind.FormattingEnabled = true;
            this.comboBox_Kind.Location = new System.Drawing.Point(112, 56);
            this.comboBox_Kind.Name = "comboBox_Kind";
            this.comboBox_Kind.Size = new System.Drawing.Size(220, 28);
            this.comboBox_Kind.TabIndex = 1;
            this.comboBox_Kind.ValueMember = "KindSN";
            // 
            // kindTBindingSource
            // 
            this.kindTBindingSource.DataMember = "KindT";
            this.kindTBindingSource.DataSource = this.QS_DataSet1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.label3.Location = new System.Drawing.Point(70, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "種類";
            // 
            // countryTTableAdapter
            // 
            this.countryTTableAdapter.ClearBeforeFill = true;
            // 
            // kindTTableAdapter
            // 
            this.kindTTableAdapter.ClearBeforeFill = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.label4.Location = new System.Drawing.Point(38, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "申請需知";
            // 
            // txt_PetitionName
            // 
            this.txt_PetitionName.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.txt_PetitionName.Location = new System.Drawing.Point(112, 86);
            this.txt_PetitionName.Name = "txt_PetitionName";
            this.txt_PetitionName.Size = new System.Drawing.Size(413, 29);
            this.txt_PetitionName.TabIndex = 2;
            // 
            // txt_PetitionNameEN
            // 
            this.txt_PetitionNameEN.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.txt_PetitionNameEN.Location = new System.Drawing.Point(112, 152);
            this.txt_PetitionNameEN.Name = "txt_PetitionNameEN";
            this.txt_PetitionNameEN.Size = new System.Drawing.Size(413, 29);
            this.txt_PetitionNameEN.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.label5.Location = new System.Drawing.Point(12, 156);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(99, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "申請需知(英)";
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button1.BackgroundImage = global::LawtechPTSystem.Properties.Resources.btnComfirm;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.button1.Location = new System.Drawing.Point(175, 203);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 32);
            this.button1.TabIndex = 30;
            this.button1.Text = "確定";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button2.BackgroundImage = global::LawtechPTSystem.Properties.Resources.btnCancel;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.button2.Location = new System.Drawing.Point(281, 203);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 32);
            this.button2.TabIndex = 31;
            this.button2.Text = "取消";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txt_PetitionNameCHS
            // 
            this.txt_PetitionNameCHS.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.txt_PetitionNameCHS.Location = new System.Drawing.Point(112, 119);
            this.txt_PetitionNameCHS.Name = "txt_PetitionNameCHS";
            this.txt_PetitionNameCHS.Size = new System.Drawing.Size(413, 29);
            this.txt_PetitionNameCHS.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.label1.Location = new System.Drawing.Point(12, 123);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 20);
            this.label1.TabIndex = 33;
            this.label1.Text = "申請需知(簡)";
            // 
            // AddPetition
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = global::LawtechPTSystem.Properties.Resources.bg1;
            this.CancelButton = this.button2;
            this.ClientSize = new System.Drawing.Size(556, 250);
            this.Controls.Add(this.txt_PetitionNameCHS);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txt_PetitionNameEN);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txt_PetitionName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBox_Kind);
            this.Controls.Add(this.comboBox_Country);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddPetition";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "新增申請需知";
            this.Load += new System.EventHandler(this.AddPetition_Load);
            ((System.ComponentModel.ISupportInitialize)(this.QS_DataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.countryTBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.kindTBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox_Country;
        private System.Windows.Forms.ComboBox comboBox_Kind;
        private System.Windows.Forms.Label label3;
        private QS_DataSet QS_DataSet1;
        private System.Windows.Forms.BindingSource countryTBindingSource;
        private LawtechPTSystem.QS_DataSetTableAdapters.CountryTTableAdapter countryTTableAdapter;
        private System.Windows.Forms.BindingSource kindTBindingSource;
        private LawtechPTSystem.QS_DataSetTableAdapters.KindTTableAdapter kindTTableAdapter;
        
       
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_PetitionName;
        private System.Windows.Forms.TextBox txt_PetitionNameEN;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txt_PetitionNameCHS;
        private System.Windows.Forms.Label label1;
    }
}