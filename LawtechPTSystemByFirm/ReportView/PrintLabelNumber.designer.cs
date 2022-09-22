namespace LawtechPTSystemByFirm.ReportView
{
    partial class PrintLabelNumber
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.PrintLabelTBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.BMtriffDataSet = new LawtechPTSystemByFirm.Report.BMtriffDataSet();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.PrintLabelTBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BMtriffDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // PrintLabelTBindingSource
            // 
            this.PrintLabelTBindingSource.DataMember = "PrintLabelT";
            this.PrintLabelTBindingSource.DataSource = this.BMtriffDataSet;
            // 
            // BMtriffDataSet
            // 
            this.BMtriffDataSet.DataSetName = "BMtriffDataSet";
            this.BMtriffDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource2.Name = "BMtriffDataSet_PrintLabelT";
            reportDataSource2.Value = this.PrintLabelTBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "LawtechPTSystemByFirm.Report.PrintLabelNumber1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(838, 676);
            this.reportViewer1.TabIndex = 0;
            this.reportViewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth;
            // 
            // PrintLabelNumber
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(838, 676);
            this.Controls.Add(this.reportViewer1);
            this.Name = "PrintLabelNumber";
            this.Text = "列印郵件標籤";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.PrintLabelNumber_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PrintLabelTBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BMtriffDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource PrintLabelTBindingSource;
        private LawtechPTSystemByFirm.Report.BMtriffDataSet BMtriffDataSet;
    }
}