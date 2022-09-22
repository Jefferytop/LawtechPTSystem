namespace LawtechPTSystem.SubFrom
{
    partial class LegalEventSet
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
            this.components = new System.ComponentModel.Container();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox_Country = new System.Windows.Forms.ComboBox();
            this.countryTDropBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.qS_DataSet = new LawtechPTSystem.QS_DataSet();
            this.countryT_DropTableAdapter = new LawtechPTSystem.QS_DataSetTableAdapters.CountryT_DropTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.countryTDropBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qS_DataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.button2.Location = new System.Drawing.Point(771, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 31);
            this.button2.TabIndex = 23;
            this.button2.Text = "關閉";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 16);
            this.label1.TabIndex = 21;
            this.label1.Text = "國   別";
            // 
            // comboBox_Country
            // 
            this.comboBox_Country.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBox_Country.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox_Country.DataSource = this.countryTDropBindingSource;
            this.comboBox_Country.DisplayMember = "Country";
            this.comboBox_Country.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.comboBox_Country.FormattingEnabled = true;
            this.comboBox_Country.Location = new System.Drawing.Point(67, 9);
            this.comboBox_Country.Name = "comboBox_Country";
            this.comboBox_Country.Size = new System.Drawing.Size(230, 24);
            this.comboBox_Country.TabIndex = 20;
            this.comboBox_Country.ValueMember = "CountrySymbol";
            // 
            // countryTDropBindingSource
            // 
            this.countryTDropBindingSource.DataMember = "CountryT_Drop";
            this.countryTDropBindingSource.DataSource = this.qS_DataSet;
            // 
            // qS_DataSet
            // 
            this.qS_DataSet.DataSetName = "QS_DataSet";
            this.qS_DataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // countryT_DropTableAdapter
            // 
            this.countryT_DropTableAdapter.ClearBeforeFill = true;
            // 
            // LegalEventSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(872, 517);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox_Country);
            this.Name = "LegalEventSet";
            this.Text = "法務--事件內容設定";
            this.Load += new System.EventHandler(this.LegalEventSet_Load);
            ((System.ComponentModel.ISupportInitialize)(this.countryTDropBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qS_DataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        internal System.Windows.Forms.ComboBox comboBox_Country;
        private QS_DataSet qS_DataSet;
        private System.Windows.Forms.BindingSource countryTDropBindingSource;
        private LawtechPTSystem.QS_DataSetTableAdapters.CountryT_DropTableAdapter countryT_DropTableAdapter;
    }
}