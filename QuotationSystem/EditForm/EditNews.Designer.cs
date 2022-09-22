namespace LawtechPTSystem.EditForm
{
    partial class EditNews
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditNews));
            this.txt_NewsSubject = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_NewsContent = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox_NewsTypeID = new System.Windows.Forms.ComboBox();
            this.newsTypeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet_News = new LawtechPTSystem.DataSet_News();
            this.label1 = new System.Windows.Forms.Label();
            this.butCancel = new System.Windows.Forms.Button();
            this.butOK = new System.Windows.Forms.Button();
            this.newsTypeTableAdapter = new LawtechPTSystem.DataSet_NewsTableAdapters.NewsTypeTableAdapter();
            this.label37 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.newsTypeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_News)).BeginInit();
            this.SuspendLayout();
            // 
            // txt_NewsSubject
            // 
            this.txt_NewsSubject.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.txt_NewsSubject.Location = new System.Drawing.Point(89, 46);
            this.txt_NewsSubject.Name = "txt_NewsSubject";
            this.txt_NewsSubject.Size = new System.Drawing.Size(345, 29);
            this.txt_NewsSubject.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(33, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 20);
            this.label3.TabIndex = 155;
            this.label3.Text = "主   旨";
            // 
            // txt_NewsContent
            // 
            this.txt_NewsContent.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.txt_NewsContent.Location = new System.Drawing.Point(89, 79);
            this.txt_NewsContent.Multiline = true;
            this.txt_NewsContent.Name = "txt_NewsContent";
            this.txt_NewsContent.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_NewsContent.Size = new System.Drawing.Size(345, 248);
            this.txt_NewsContent.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(33, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 20);
            this.label2.TabIndex = 153;
            this.label2.Text = "內   文";
            // 
            // comboBox_NewsTypeID
            // 
            this.comboBox_NewsTypeID.DataSource = this.newsTypeBindingSource;
            this.comboBox_NewsTypeID.DisplayMember = "TypeName";
            this.comboBox_NewsTypeID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_NewsTypeID.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.comboBox_NewsTypeID.FormattingEnabled = true;
            this.comboBox_NewsTypeID.Location = new System.Drawing.Point(89, 15);
            this.comboBox_NewsTypeID.Name = "comboBox_NewsTypeID";
            this.comboBox_NewsTypeID.Size = new System.Drawing.Size(345, 28);
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
            this.label1.Location = new System.Drawing.Point(13, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 20);
            this.label1.TabIndex = 151;
            this.label1.Text = "公佈類型";
            // 
            // butCancel
            // 
            this.butCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.butCancel.BackgroundImage = global::LawtechPTSystem.Properties.Resources.btnCancel;
            this.butCancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.butCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.butCancel.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.butCancel.Location = new System.Drawing.Point(230, 350);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(100, 32);
            this.butCancel.TabIndex = 4;
            this.butCancel.Text = "取消";
            this.butCancel.UseVisualStyleBackColor = true;
            this.butCancel.Click += new System.EventHandler(this.butCancel_Click);
            // 
            // butOK
            // 
            this.butOK.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.butOK.BackgroundImage = global::LawtechPTSystem.Properties.Resources.btnComfirm;
            this.butOK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.butOK.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.butOK.Location = new System.Drawing.Point(124, 350);
            this.butOK.Name = "butOK";
            this.butOK.Size = new System.Drawing.Size(100, 32);
            this.butOK.TabIndex = 3;
            this.butOK.Text = "確定";
            this.butOK.UseVisualStyleBackColor = true;
            this.butOK.Click += new System.EventHandler(this.butOK_Click);
            // 
            // newsTypeTableAdapter
            // 
            this.newsTypeTableAdapter.ClearBeforeFill = true;
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.BackColor = System.Drawing.Color.Transparent;
            this.label37.ForeColor = System.Drawing.Color.Red;
            this.label37.Location = new System.Drawing.Point(19, 56);
            this.label37.Margin = new System.Windows.Forms.Padding(0);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(11, 12);
            this.label37.TabIndex = 1090;
            this.label37.Text = "*";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label5.ForeColor = System.Drawing.Color.Green;
            this.label5.Location = new System.Drawing.Point(292, 330);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(142, 17);
            this.label5.TabIndex = 1091;
            this.label5.Text = "Shift+Enter：換下一行";
            // 
            // EditNews
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = global::LawtechPTSystem.Properties.Resources.EditForm_bg;
            this.CancelButton = this.butCancel;
            this.ClientSize = new System.Drawing.Size(455, 395);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label37);
            this.Controls.Add(this.txt_NewsSubject);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_NewsContent);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox_NewsTypeID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.butOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditNews";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "編輯公佈消息";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.EditNews_FormClosed);
            this.Load += new System.EventHandler(this.EditNews_Load);
            ((System.ComponentModel.ISupportInitialize)(this.newsTypeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet_News)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_NewsSubject;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_NewsContent;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox_NewsTypeID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button butCancel;
        private System.Windows.Forms.Button butOK;
        private DataSet_News dataSet_News;
        private System.Windows.Forms.BindingSource newsTypeBindingSource;
        private LawtechPTSystem.DataSet_NewsTableAdapters.NewsTypeTableAdapter newsTypeTableAdapter;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.Label label5;
    }
}