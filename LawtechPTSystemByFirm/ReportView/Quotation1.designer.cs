using Microsoft.Reporting.WinForms;
namespace LawtechPTSystemByFirm.ReportView
{
    partial class Quotation1
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.bMtriffDataSet = new LawtechPTSystemByFirm.Report.BMtriffDataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dataTable1TableAdapter = new LawtechPTSystemByFirm.Report.BMtriffDataSetTableAdapters.DataTable1TableAdapter();
            this.dataTable_CHSTableAdapter1 = new LawtechPTSystemByFirm.Report.BMtriffDataSetTableAdapters.DataTable_CHSTableAdapter();
            this.dataTable_ENTableAdapter1 = new LawtechPTSystemByFirm.Report.BMtriffDataSetTableAdapters.DataTable_ENTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.bMtriffDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // bMtriffDataSet
            // 
            this.bMtriffDataSet.DataSetName = "BMtriffDataSet";
            this.bMtriffDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "BMtriffDataSet_DataTable1";
            reportDataSource1.Value = null;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "LawtechPTSystemByFirm.Report.Quotation1RF.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(826, 664);
            this.reportViewer1.TabIndex = 0;
            this.reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
            this.reportViewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth;
            // 
            // dataTable1TableAdapter
            // 
            this.dataTable1TableAdapter.ClearBeforeFill = true;
            // 
            // dataTable_CHSTableAdapter1
            // 
            this.dataTable_CHSTableAdapter1.ClearBeforeFill = true;
            // 
            // dataTable_ENTableAdapter1
            // 
            this.dataTable_ENTableAdapter1.ClearBeforeFill = true;
            // 
            // Quotation1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(826, 664);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Quotation1";
            this.Text = "客戶報價(精簡格式)";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Quotation1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bMtriffDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private LawtechPTSystemByFirm.Report.BMtriffDataSet bMtriffDataSet;
        private LawtechPTSystemByFirm.Report.BMtriffDataSetTableAdapters.DataTable1TableAdapter dataTable1TableAdapter;
        private LawtechPTSystemByFirm.Report.BMtriffDataSetTableAdapters.DataTable_CHSTableAdapter dataTable_CHSTableAdapter1;
        private LawtechPTSystemByFirm.Report.BMtriffDataSetTableAdapters.DataTable_ENTableAdapter dataTable_ENTableAdapter1;
    }
}