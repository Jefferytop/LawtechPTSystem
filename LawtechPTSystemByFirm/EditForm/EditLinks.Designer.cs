namespace LawtechPTSystemByFirm.EditForm
{
    partial class EditLinks
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditLinks));
            this.txt_Description = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_WebAddress = new System.Windows.Forms.TextBox();
            this.butCancel = new System.Windows.Forms.Button();
            this.butOK = new System.Windows.Forms.Button();
            this.txt_WebSiteName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox_NewsTypeID = new System.Windows.Forms.ComboBox();
            this.newsTypeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet_News = new LawtechPTSystemByFirm.DataSet_News();
            this.label1 = new System.Windows.Forms.Label();
            this.newsTypeTableAdapter = new LawtechPTSystemByFirm.DataSet_NewsTableAdapters.NewsTypeTableAdapter();
            this.label5 = new System.Windows.Forms.Label();
            this.numericUpDown_Sort = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.newsTypeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_News)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Sort)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_Description
            // 
            this.txt_Description.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.txt_Description.Location = new System.Drawing.Point(99, 182);
            this.txt_Description.Multiline = true;
            this.txt_Description.Name = "txt_Description";
            this.txt_Description.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_Description.Size = new System.Drawing.Size(323, 127);
            this.txt_Description.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.Location = new System.Drawing.Point(55, 193);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 20);
            this.label4.TabIndex = 168;
            this.label4.Text = "說明";
            // 
            // txt_WebAddress
            // 
            this.txt_WebAddress.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.txt_WebAddress.Location = new System.Drawing.Point(99, 118);
            this.txt_WebAddress.Multiline = true;
            this.txt_WebAddress.Name = "txt_WebAddress";
            this.txt_WebAddress.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_WebAddress.Size = new System.Drawing.Size(323, 58);
            this.txt_WebAddress.TabIndex = 2;
            // 
            // butCancel
            // 
            this.butCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.butCancel.BackgroundImage = global::LawtechPTSystemByFirm.Properties.Resources.btnCancel;
            this.butCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.butCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.butCancel.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.butCancel.Location = new System.Drawing.Point(220, 333);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(100, 30);
            this.butCancel.TabIndex = 5;
            this.butCancel.Text = "取消";
            this.butCancel.UseVisualStyleBackColor = true;
            this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
            // 
            // butOK
            // 
            this.butOK.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.butOK.BackgroundImage = global::LawtechPTSystemByFirm.Properties.Resources.btnComfirm;
            this.butOK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.butOK.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.butOK.Location = new System.Drawing.Point(114, 333);
            this.butOK.Name = "butOK";
            this.butOK.Size = new System.Drawing.Size(100, 30);
            this.butOK.TabIndex = 4;
            this.butOK.Text = "確定";
            this.butOK.UseVisualStyleBackColor = true;
            this.butOK.Click += new System.EventHandler(this.butOK_Click);
            // 
            // txt_WebSiteName
            // 
            this.txt_WebSiteName.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.txt_WebSiteName.Location = new System.Drawing.Point(99, 85);
            this.txt_WebSiteName.Name = "txt_WebSiteName";
            this.txt_WebSiteName.Size = new System.Drawing.Size(323, 29);
            this.txt_WebSiteName.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(23, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 20);
            this.label3.TabIndex = 163;
            this.label3.Text = "網站名稱";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(55, 130);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 20);
            this.label2.TabIndex = 162;
            this.label2.Text = "網址";
            // 
            // comboBox_NewsTypeID
            // 
            this.comboBox_NewsTypeID.DataSource = this.newsTypeBindingSource;
            this.comboBox_NewsTypeID.DisplayMember = "TypeName";
            this.comboBox_NewsTypeID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_NewsTypeID.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.comboBox_NewsTypeID.FormattingEnabled = true;
            this.comboBox_NewsTypeID.Location = new System.Drawing.Point(99, 20);
            this.comboBox_NewsTypeID.Name = "comboBox_NewsTypeID";
            this.comboBox_NewsTypeID.Size = new System.Drawing.Size(323, 28);
            this.comboBox_NewsTypeID.TabIndex = 0;
            this.comboBox_NewsTypeID.ValueMember = "NewsTypeKey";
            // 
            // newsTypeBindingSource
            // 
            this.newsTypeBindingSource.DataMember = "NewsType";
            this.newsTypeBindingSource.DataSource = this.dataSet_News;
            // 
            // dataSet_News
            // 
            this.dataSet_News.DataSetName = "DataSet_News";
            this.dataSet_News.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(23, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 20);
            this.label1.TabIndex = 160;
            this.label1.Text = "連結類型";
            // 
            // newsTypeTableAdapter
            // 
            this.newsTypeTableAdapter.ClearBeforeFill = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label5.Location = new System.Drawing.Point(55, 57);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 20);
            this.label5.TabIndex = 169;
            this.label5.Text = "排序";
            // 
            // numericUpDown_Sort
            // 
            this.numericUpDown_Sort.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.numericUpDown_Sort.Location = new System.Drawing.Point(99, 52);
            this.numericUpDown_Sort.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.numericUpDown_Sort.Name = "numericUpDown_Sort";
            this.numericUpDown_Sort.Size = new System.Drawing.Size(125, 29);
            this.numericUpDown_Sort.TabIndex = 170;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label6.ForeColor = System.Drawing.Color.Green;
            this.label6.Location = new System.Drawing.Point(280, 313);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(142, 17);
            this.label6.TabIndex = 1089;
            this.label6.Text = "Shift+Enter：換下一行";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.Color.Transparent;
            this.label18.ForeColor = System.Drawing.Color.Red;
            this.label18.Location = new System.Drawing.Point(12, 95);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(11, 12);
            this.label18.TabIndex = 1090;
            this.label18.Text = "*";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(40, 134);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(11, 12);
            this.label7.TabIndex = 1091;
            this.label7.Text = "*";
            // 
            // EditLinks
            // 
            this.AcceptButton = this.butOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::LawtechPTSystemByFirm.Properties.Resources.EditForm_bg;
            this.CancelButton = this.butCancel;
            this.ClientSize = new System.Drawing.Size(435, 378);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.numericUpDown_Sort);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txt_Description);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_WebAddress);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.butOK);
            this.Controls.Add(this.txt_WebSiteName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox_NewsTypeID);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditLinks";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "編輯連結";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.EditLinks_FormClosed);
            this.Load += new System.EventHandler(this.EditLinks_Load);
            ((System.ComponentModel.ISupportInitialize)(this.newsTypeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_News)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Sort)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_Description;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_WebAddress;
        private System.Windows.Forms.Button butCancel;
        private System.Windows.Forms.Button butOK;
        private System.Windows.Forms.TextBox txt_WebSiteName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox_NewsTypeID;
        private System.Windows.Forms.Label label1;
        private DataSet_News dataSet_News;
        private System.Windows.Forms.BindingSource newsTypeBindingSource;
        private LawtechPTSystemByFirm.DataSet_NewsTableAdapters.NewsTypeTableAdapter newsTypeTableAdapter;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numericUpDown_Sort;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label7;
    }
}