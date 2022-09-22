using Microsoft.Reporting.WinForms;
namespace LawtechPTSystemByFirm.ReportView
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.DataTable1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.BMtriffDataSet = new LawtechPTSystemByFirm.Report.BMtriffDataSet();
            this.DataTable1TableAdapter = new LawtechPTSystemByFirm.Report.BMtriffDataSetTableAdapters.DataTable1TableAdapter();
            this.dataTable_CHSTableAdapter1 = new LawtechPTSystemByFirm.Report.BMtriffDataSetTableAdapters.DataTable_CHSTableAdapter();
            this.dataTable_ENTableAdapter1 = new LawtechPTSystemByFirm.Report.BMtriffDataSetTableAdapters.DataTable_ENTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.DataTable1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BMtriffDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource2.Name = "BMtriffDataSet_DataTable1";
            reportDataSource2.Value = null;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "LawtechPTSystemByFirm.Report.Quotation3RF.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(762, 505);
            this.reportViewer1.TabIndex = 1;
            this.reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);
            this.reportViewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth;
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
            // Quotation4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(762, 505);
            this.Controls.Add(this.reportViewer1);
            this.Name = "Quotation4";
            this.Text = "客戶報價(清單格式)";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Quotation4_Load);
            ((System.ComponentModel.ISupportInitialize)(this.DataTable1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BMtriffDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource DataTable1BindingSource;
        private LawtechPTSystemByFirm.Report.BMtriffDataSet BMtriffDataSet;
        private LawtechPTSystemByFirm.Report.BMtriffDataSetTableAdapters.DataTable1TableAdapter DataTable1TableAdapter;
        private LawtechPTSystemByFirm.Report.BMtriffDataSetTableAdapters.DataTable_CHSTableAdapter dataTable_CHSTableAdapter1;
        private LawtechPTSystemByFirm.Report.BMtriffDataSetTableAdapters.DataTable_ENTableAdapter dataTable_ENTableAdapter1;
    }
}