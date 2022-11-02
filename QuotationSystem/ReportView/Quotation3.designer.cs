using Microsoft.Reporting.WinForms;
namespace LawtechPTSystem.ReportView
{
    partial class Quotation3
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Quotation3));
            this.DataTable1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.BMtriffDataSet = new LawtechPTSystem.Report.BMtriffDataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.comboBox_AcountingFirmT = new System.Windows.Forms.ComboBox();
            this.label25 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_Liaisoner = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_Save = new System.Windows.Forms.Button();
            this.btn_Close = new System.Windows.Forms.Button();
            this.btn_Refresh = new System.Windows.Forms.Button();
            this.txt_Content = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_Description = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_Subject = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.DataTable1TableAdapter = new LawtechPTSystem.Report.BMtriffDataSetTableAdapters.DataTable1TableAdapter();
            this.dataTable_CHSTableAdapter1 = new LawtechPTSystem.Report.BMtriffDataSetTableAdapters.DataTable_CHSTableAdapter();
            this.dataTable_ENTableAdapter1 = new LawtechPTSystem.Report.BMtriffDataSetTableAdapters.DataTable_ENTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.DataTable1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BMtriffDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // DataTable1BindingSource
            // 
            this.DataTable1BindingSource.DataMember = "DataTable1";
            this.DataTable1BindingSource.DataSource = this.BMtriffDataSet;
            // 
            // BMtriffDataSet
            // 
            this.BMtriffDataSet.DataSetName = "BMtriffDataSet";
            this.BMtriffDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "BMtriffDataSet_DataTable1";
            reportDataSource1.Value = this.DataTable1BindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "LawtechPTSystem.Report.Quotation3RF.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(533, 662);
            this.reportViewer1.TabIndex = 0;
            this.reportViewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth;
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
            this.splitContainer1.Panel2.Controls.Add(this.label5);
            this.splitContainer1.Panel2.Controls.Add(this.txt_Liaisoner);
            this.splitContainer1.Panel2.Controls.Add(this.label4);
            this.splitContainer1.Panel2.Controls.Add(this.btn_Save);
            this.splitContainer1.Panel2.Controls.Add(this.btn_Close);
            this.splitContainer1.Panel2.Controls.Add(this.btn_Refresh);
            this.splitContainer1.Panel2.Controls.Add(this.txt_Content);
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Panel2.Controls.Add(this.txt_Description);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.txt_Subject);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.splitContainer1.Size = new System.Drawing.Size(826, 664);
            this.splitContainer1.SplitterDistance = 535;
            this.splitContainer1.TabIndex = 1;
            // 
            // comboBox_AcountingFirmT
            // 
            this.comboBox_AcountingFirmT.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_AcountingFirmT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_AcountingFirmT.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.comboBox_AcountingFirmT.FormattingEnabled = true;
            this.comboBox_AcountingFirmT.Location = new System.Drawing.Point(11, 28);
            this.comboBox_AcountingFirmT.Name = "comboBox_AcountingFirmT";
            this.comboBox_AcountingFirmT.Size = new System.Drawing.Size(260, 28);
            this.comboBox_AcountingFirmT.TabIndex = 1137;
            
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.label25.Location = new System.Drawing.Point(10, 5);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(89, 20);
            this.label25.TabIndex = 1136;
            this.label25.Text = "開立公司：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("微軟正黑體", 9F);
            this.label5.ForeColor = System.Drawing.Color.Navy;
            this.label5.Location = new System.Drawing.Point(77, 66);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 16);
            this.label5.TabIndex = 20;
            this.label5.Text = "(動態資料)";
            // 
            // txt_Liaisoner
            // 
            this.txt_Liaisoner.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_Liaisoner.Location = new System.Drawing.Point(11, 84);
            this.txt_Liaisoner.Multiline = true;
            this.txt_Liaisoner.Name = "txt_Liaisoner";
            this.txt_Liaisoner.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_Liaisoner.Size = new System.Drawing.Size(267, 52);
            this.txt_Liaisoner.TabIndex = 19;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 20);
            this.label4.TabIndex = 18;
            this.label4.Text = "聯絡人：";
            // 
            // btn_Save
            // 
            this.btn_Save.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btn_Save.BackColor = System.Drawing.Color.Transparent;
            this.btn_Save.BackgroundImage = global::LawtechPTSystem.Properties.Resources.button_vtumblr;
            this.btn_Save.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Save.ForeColor = System.Drawing.Color.White;
            this.btn_Save.Location = new System.Drawing.Point(25, 621);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(120, 32);
            this.btn_Save.TabIndex = 17;
            this.btn_Save.Text = "儲存綠字";
            this.btn_Save.UseVisualStyleBackColor = false;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // btn_Close
            // 
            this.btn_Close.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btn_Close.BackgroundImage = global::LawtechPTSystem.Properties.Resources.button_flickr;
            this.btn_Close.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Close.Location = new System.Drawing.Point(151, 621);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(120, 32);
            this.btn_Close.TabIndex = 16;
            this.btn_Close.Text = "關閉";
            this.btn_Close.UseVisualStyleBackColor = true;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // btn_Refresh
            // 
            this.btn_Refresh.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btn_Refresh.BackColor = System.Drawing.Color.Transparent;
            this.btn_Refresh.BackgroundImage = global::LawtechPTSystem.Properties.Resources.button_linkedin;
            this.btn_Refresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Refresh.ForeColor = System.Drawing.Color.White;
            this.btn_Refresh.Location = new System.Drawing.Point(25, 583);
            this.btn_Refresh.Name = "btn_Refresh";
            this.btn_Refresh.Size = new System.Drawing.Size(120, 32);
            this.btn_Refresh.TabIndex = 15;
            this.btn_Refresh.Text = "重整報表";
            this.btn_Refresh.UseVisualStyleBackColor = false;
            this.btn_Refresh.Click += new System.EventHandler(this.btn_Refresh_Click);
            // 
            // txt_Content
            // 
            this.txt_Content.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_Content.ForeColor = System.Drawing.Color.ForestGreen;
            this.txt_Content.Location = new System.Drawing.Point(11, 252);
            this.txt_Content.Multiline = true;
            this.txt_Content.Name = "txt_Content";
            this.txt_Content.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_Content.Size = new System.Drawing.Size(267, 97);
            this.txt_Content.TabIndex = 14;
            this.txt_Content.Text = "隨後的收費表，自即日起開始生效，遇有調整，以本所最新的收費表為準。感謝您的垂詢。　順頌 商棋";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 229);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 20);
            this.label3.TabIndex = 13;
            this.label3.Text = "內文：";
            // 
            // txt_Description
            // 
            this.txt_Description.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_Description.ForeColor = System.Drawing.Color.ForestGreen;
            this.txt_Description.Location = new System.Drawing.Point(11, 375);
            this.txt_Description.Multiline = true;
            this.txt_Description.Name = "txt_Description";
            this.txt_Description.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_Description.Size = new System.Drawing.Size(267, 192);
            this.txt_Description.TabIndex = 12;
            this.txt_Description.Text = resources.GetString("txt_Description.Text");
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 352);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 20);
            this.label2.TabIndex = 11;
            this.label2.Text = "說明：";
            // 
            // txt_Subject
            // 
            this.txt_Subject.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_Subject.ForeColor = System.Drawing.Color.ForestGreen;
            this.txt_Subject.Location = new System.Drawing.Point(11, 168);
            this.txt_Subject.Multiline = true;
            this.txt_Subject.Name = "txt_Subject";
            this.txt_Subject.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_Subject.Size = new System.Drawing.Size(267, 52);
            this.txt_Subject.TabIndex = 10;
            this.txt_Subject.Text = "各項服務收費標準";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 145);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "主旨：";
            // 
            // DataTable1TableAdapter
            // 
            this.DataTable1TableAdapter.ClearBeforeFill = true;
            // 
            // dataTable_CHSTableAdapter1
            // 
            this.dataTable_CHSTableAdapter1.ClearBeforeFill = true;
            // 
            // dataTable_ENTableAdapter1
            // 
            this.dataTable_ENTableAdapter1.ClearBeforeFill = true;
            // 
            // Quotation3
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(236)))), ((int)(((byte)(247)))));
            this.ClientSize = new System.Drawing.Size(826, 664);
            this.Controls.Add(this.splitContainer1);
            this.Font = new System.Drawing.Font("微軟正黑體", 9F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Quotation3";
            this.Text = "客戶報價(專業格式)";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Quotation3_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataTable1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BMtriffDataSet)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource DataTable1BindingSource;
        private LawtechPTSystem.Report.BMtriffDataSet BMtriffDataSet;
        private LawtechPTSystem.Report.BMtriffDataSetTableAdapters.DataTable1TableAdapter DataTable1TableAdapter;
        private LawtechPTSystem.Report.BMtriffDataSetTableAdapters.DataTable_CHSTableAdapter dataTable_CHSTableAdapter1;
        private LawtechPTSystem.Report.BMtriffDataSetTableAdapters.DataTable_ENTableAdapter dataTable_ENTableAdapter1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.Button btn_Refresh;
        private System.Windows.Forms.TextBox txt_Content;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_Description;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_Subject;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_Liaisoner;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox_AcountingFirmT;
        private System.Windows.Forms.Label label25;
    }
}