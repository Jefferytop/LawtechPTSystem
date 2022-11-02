using Microsoft.Reporting.WinForms;
namespace LawtechPTSystem.ReportView
{
    partial class Quotation4
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Quotation4));
            this.DataTable1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.BMtriffDataSet = new LawtechPTSystem.Report.BMtriffDataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.DataTable1TableAdapter = new LawtechPTSystem.Report.BMtriffDataSetTableAdapters.DataTable1TableAdapter();
            this.dataTable_CHSTableAdapter1 = new LawtechPTSystem.Report.BMtriffDataSetTableAdapters.DataTable_CHSTableAdapter();
            this.dataTable_ENTableAdapter1 = new LawtechPTSystem.Report.BMtriffDataSetTableAdapters.DataTable_ENTableAdapter();
            this.comboBox_AcountingFirmT = new System.Windows.Forms.ComboBox();
            this.label25 = new System.Windows.Forms.Label();
            this.btn_Refresh = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DataTable1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BMtriffDataSet)).BeginInit();
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
            this.reportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            reportDataSource1.Name = "BMtriffDataSet_DataTable1";
            reportDataSource1.Value = this.DataTable1BindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "LawtechPTSystem.Report.Quotation4RF.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 39);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(762, 466);
            this.reportViewer1.TabIndex = 1;
            this.reportViewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth;
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
            // comboBox_AcountingFirmT
            // 
            this.comboBox_AcountingFirmT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_AcountingFirmT.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.comboBox_AcountingFirmT.FormattingEnabled = true;
            this.comboBox_AcountingFirmT.Location = new System.Drawing.Point(107, 5);
            this.comboBox_AcountingFirmT.Name = "comboBox_AcountingFirmT";
            this.comboBox_AcountingFirmT.Size = new System.Drawing.Size(319, 28);
            this.comboBox_AcountingFirmT.TabIndex = 1139;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("微軟正黑體", 12F);
            this.label25.Location = new System.Drawing.Point(12, 9);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(89, 20);
            this.label25.TabIndex = 1138;
            this.label25.Text = "開立公司：";
            // 
            // btn_Refresh
            // 
            this.btn_Refresh.BackColor = System.Drawing.Color.Transparent;
            this.btn_Refresh.BackgroundImage = global::LawtechPTSystem.Properties.Resources.button_linkedin;
            this.btn_Refresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Refresh.ForeColor = System.Drawing.Color.White;
            this.btn_Refresh.Location = new System.Drawing.Point(432, 3);
            this.btn_Refresh.Name = "btn_Refresh";
            this.btn_Refresh.Size = new System.Drawing.Size(120, 32);
            this.btn_Refresh.TabIndex = 1140;
            this.btn_Refresh.Text = "重整報表";
            this.btn_Refresh.UseVisualStyleBackColor = false;
            this.btn_Refresh.Click += new System.EventHandler(this.btn_Refresh_Click);
            // 
            // Quotation4
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(236)))), ((int)(((byte)(247)))));
            this.ClientSize = new System.Drawing.Size(762, 505);
            this.Controls.Add(this.btn_Refresh);
            this.Controls.Add(this.comboBox_AcountingFirmT);
            this.Controls.Add(this.label25);
            this.Controls.Add(this.reportViewer1);
            this.Font = new System.Drawing.Font("微軟正黑體", 9F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Quotation4";
            this.Text = "客戶報價(清單格式)";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Quotation4_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataTable1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BMtriffDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource DataTable1BindingSource;
        private LawtechPTSystem.Report.BMtriffDataSet BMtriffDataSet;
        private LawtechPTSystem.Report.BMtriffDataSetTableAdapters.DataTable1TableAdapter DataTable1TableAdapter;
        private LawtechPTSystem.Report.BMtriffDataSetTableAdapters.DataTable_CHSTableAdapter dataTable_CHSTableAdapter1;
        private LawtechPTSystem.Report.BMtriffDataSetTableAdapters.DataTable_ENTableAdapter dataTable_ENTableAdapter1;
        private System.Windows.Forms.ComboBox comboBox_AcountingFirmT;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Button btn_Refresh;
    }
}