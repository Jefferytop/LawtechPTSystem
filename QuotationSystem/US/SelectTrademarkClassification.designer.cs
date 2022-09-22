namespace LawtechPTSystem.US
{
    partial class SelectTrademarkClassification
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.button3 = new System.Windows.Forms.Button();
            this.but_RemoveClass = new System.Windows.Forms.Button();
            this.but_AddClass = new System.Windows.Forms.Button();
            this.lab_Country = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column_Select = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ClassName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClassDescript = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClassDescript_En = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TMClassID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sortDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.countrySymbolDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.trademarkClassificationTBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet_TM = new LawtechPTSystem.DataSet_TM();
            this.label2 = new System.Windows.Forms.Label();
            this.but_Cancel = new System.Windows.Forms.Button();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.Check = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SelectTMClassID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClassDescriptS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.but_OK = new System.Windows.Forms.Button();
            this.trademarkClassificationTTableAdapter = new LawtechPTSystem.DataSet_TMTableAdapters.TrademarkClassificationTTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trademarkClassificationTBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_TM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
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
            this.splitContainer1.Panel1.Controls.Add(this.button3);
            this.splitContainer1.Panel1.Controls.Add(this.but_RemoveClass);
            this.splitContainer1.Panel1.Controls.Add(this.but_AddClass);
            this.splitContainer1.Panel1.Controls.Add(this.lab_Country);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.dataGridView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.but_Cancel);
            this.splitContainer1.Panel2.Controls.Add(this.dataGridView2);
            this.splitContainer1.Panel2.Controls.Add(this.but_OK);
            this.splitContainer1.Size = new System.Drawing.Size(879, 473);
            this.splitContainer1.SplitterDistance = 536;
            this.splitContainer1.TabIndex = 0;
            // 
            // button3
            // 
            this.button3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.button3.Location = new System.Drawing.Point(477, 29);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(52, 86);
            this.button3.TabIndex = 6;
            this.button3.Text = "重選";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // but_RemoveClass
            // 
            this.but_RemoveClass.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.but_RemoveClass.Location = new System.Drawing.Point(477, 245);
            this.but_RemoveClass.Name = "but_RemoveClass";
            this.but_RemoveClass.Size = new System.Drawing.Size(52, 86);
            this.but_RemoveClass.TabIndex = 5;
            this.but_RemoveClass.Text = "<<";
            this.but_RemoveClass.UseVisualStyleBackColor = true;
            this.but_RemoveClass.Click += new System.EventHandler(this.but_RemoveClass_Click);
            // 
            // but_AddClass
            // 
            this.but_AddClass.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.but_AddClass.Location = new System.Drawing.Point(477, 153);
            this.but_AddClass.Name = "but_AddClass";
            this.but_AddClass.Size = new System.Drawing.Size(52, 86);
            this.but_AddClass.TabIndex = 4;
            this.but_AddClass.Text = ">>";
            this.but_AddClass.UseVisualStyleBackColor = true;
            this.but_AddClass.Click += new System.EventHandler(this.but_AddClass_Click);
            // 
            // lab_Country
            // 
            this.lab_Country.AutoSize = true;
            this.lab_Country.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.lab_Country.ForeColor = System.Drawing.Color.DarkViolet;
            this.lab_Country.Location = new System.Drawing.Point(61, 5);
            this.lab_Country.Name = "lab_Country";
            this.lab_Country.Size = new System.Drawing.Size(41, 20);
            this.lab_Country.TabIndex = 4;
            this.lab_Country.Text = "國別";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(6, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "國別：";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column_Select,
            this.ClassName,
            this.ClassDescript,
            this.ClassDescript_En,
            this.TMClassID,
            this.sortDataGridViewTextBoxColumn,
            this.countrySymbolDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.trademarkClassificationTBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(3, 29);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(468, 431);
            this.dataGridView1.TabIndex = 0;
            // 
            // Column_Select
            // 
            this.Column_Select.HeaderText = "";
            this.Column_Select.Name = "Column_Select";
            this.Column_Select.Width = 50;
            // 
            // ClassName
            // 
            this.ClassName.DataPropertyName = "ClassName";
            this.ClassName.HeaderText = "商標分類";
            this.ClassName.Name = "ClassName";
            this.ClassName.ReadOnly = true;
            this.ClassName.Width = 130;
            // 
            // ClassDescript
            // 
            this.ClassDescript.DataPropertyName = "ClassDescript";
            this.ClassDescript.HeaderText = "描述";
            this.ClassDescript.Name = "ClassDescript";
            this.ClassDescript.ReadOnly = true;
            // 
            // ClassDescript_En
            // 
            this.ClassDescript_En.DataPropertyName = "ClassDescript_En";
            this.ClassDescript_En.HeaderText = "描述(英)";
            this.ClassDescript_En.Name = "ClassDescript_En";
            this.ClassDescript_En.ReadOnly = true;
            // 
            // TMClassID
            // 
            this.TMClassID.DataPropertyName = "TMClassID";
            this.TMClassID.HeaderText = "TMClassID";
            this.TMClassID.Name = "TMClassID";
            this.TMClassID.ReadOnly = true;
            this.TMClassID.Visible = false;
            // 
            // sortDataGridViewTextBoxColumn
            // 
            this.sortDataGridViewTextBoxColumn.DataPropertyName = "Sort";
            this.sortDataGridViewTextBoxColumn.HeaderText = "Sort";
            this.sortDataGridViewTextBoxColumn.Name = "sortDataGridViewTextBoxColumn";
            this.sortDataGridViewTextBoxColumn.ReadOnly = true;
            this.sortDataGridViewTextBoxColumn.Visible = false;
            // 
            // countrySymbolDataGridViewTextBoxColumn
            // 
            this.countrySymbolDataGridViewTextBoxColumn.DataPropertyName = "CountrySymbol";
            this.countrySymbolDataGridViewTextBoxColumn.HeaderText = "CountrySymbol";
            this.countrySymbolDataGridViewTextBoxColumn.Name = "countrySymbolDataGridViewTextBoxColumn";
            this.countrySymbolDataGridViewTextBoxColumn.ReadOnly = true;
            this.countrySymbolDataGridViewTextBoxColumn.Visible = false;
            // 
            // trademarkClassificationTBindingSource
            // 
            this.trademarkClassificationTBindingSource.DataMember = "TrademarkClassificationT";
            this.trademarkClassificationTBindingSource.DataSource = this.dataSet_TM;
            // 
            // dataSet_TM
            // 
            this.dataSet_TM.DataSetName = "DataSet_TM";
            this.dataSet_TM.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(4, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(185, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "目前所選擇的商標分類：";
            // 
            // but_Cancel
            // 
            this.but_Cancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.but_Cancel.BackgroundImage = global::LawtechPTSystem.Properties.Resources.btnCancel;
            this.but_Cancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.but_Cancel.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.but_Cancel.Location = new System.Drawing.Point(181, 430);
            this.but_Cancel.Name = "but_Cancel";
            this.but_Cancel.Size = new System.Drawing.Size(100, 32);
            this.but_Cancel.TabIndex = 3;
            this.but_Cancel.Text = "取消";
            this.but_Cancel.UseVisualStyleBackColor = true;
            this.but_Cancel.Click += new System.EventHandler(this.but_Cancel_Click);
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AllowUserToOrderColumns = true;
            this.dataGridView2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Check,
            this.Column1,
            this.SelectTMClassID,
            this.ClassDescriptS});
            this.dataGridView2.Location = new System.Drawing.Point(3, 29);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowTemplate.Height = 24;
            this.dataGridView2.Size = new System.Drawing.Size(331, 392);
            this.dataGridView2.TabIndex = 0;
            // 
            // Check
            // 
            this.Check.HeaderText = "";
            this.Check.Name = "Check";
            this.Check.Width = 50;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "ClassName";
            this.Column1.HeaderText = "商標分類";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column1.Width = 160;
            // 
            // SelectTMClassID
            // 
            this.SelectTMClassID.DataPropertyName = "TMClassID";
            this.SelectTMClassID.HeaderText = "TMClassID";
            this.SelectTMClassID.Name = "SelectTMClassID";
            this.SelectTMClassID.Visible = false;
            // 
            // ClassDescriptS
            // 
            this.ClassDescriptS.DataPropertyName = "ClassDescript";
            this.ClassDescriptS.HeaderText = "ClassDescriptS";
            this.ClassDescriptS.Name = "ClassDescriptS";
            this.ClassDescriptS.Visible = false;
            // 
            // but_OK
            // 
            this.but_OK.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.but_OK.BackgroundImage = global::LawtechPTSystem.Properties.Resources.btnComfirm;
            this.but_OK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.but_OK.Font = new System.Drawing.Font("微軟正黑體", 10F);
            this.but_OK.Location = new System.Drawing.Point(75, 430);
            this.but_OK.Name = "but_OK";
            this.but_OK.Size = new System.Drawing.Size(100, 32);
            this.but_OK.TabIndex = 2;
            this.but_OK.Text = "確定";
            this.but_OK.UseVisualStyleBackColor = true;
            this.but_OK.Click += new System.EventHandler(this.but_OK_Click);
            // 
            // trademarkClassificationTTableAdapter
            // 
            this.trademarkClassificationTTableAdapter.ClearBeforeFill = true;
            // 
            // SelectTrademarkClassification
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(879, 473);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Name = "SelectTrademarkClassification";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "選擇商標分類";
            this.Load += new System.EventHandler(this.SelectTrademarkClassification_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trademarkClassificationTBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_TM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource trademarkClassificationTBindingSource;
        private DataSet_TM dataSet_TM;
        private LawtechPTSystem.DataSet_TMTableAdapters.TrademarkClassificationTTableAdapter trademarkClassificationTTableAdapter;
        private System.Windows.Forms.Button but_Cancel;
        private System.Windows.Forms.Button but_OK;
        private System.Windows.Forms.Label lab_Country;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Button but_RemoveClass;
        private System.Windows.Forms.Button but_AddClass;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column_Select;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClassName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClassDescript;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClassDescript_En;
        private System.Windows.Forms.DataGridViewTextBoxColumn TMClassID;
        private System.Windows.Forms.DataGridViewTextBoxColumn sortDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn countrySymbolDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Check;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn SelectTMClassID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClassDescriptS;
    }
}