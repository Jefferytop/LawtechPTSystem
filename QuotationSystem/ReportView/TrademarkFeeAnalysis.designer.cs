using Microsoft.Reporting.WinForms;
namespace LawtechPTSystem.ReportView
{
    partial class TrademarkFeeAnalysis
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TrademarkFeeAnalysis));
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.but_Close = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.reportViewer1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.reportViewer1.IsDocumentMapWidthFixed = true;
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "LawtechPTSystem.Report.PatentCount.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(2, 1);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.PromptAreaCollapsed = true;
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.ShowContextMenu = false;
            this.reportViewer1.Size = new System.Drawing.Size(914, 744);
            this.reportViewer1.TabIndex = 2;
            this.reportViewer1.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth;
            // 
            // but_Close
            // 
            this.but_Close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.but_Close.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.but_Close.Location = new System.Drawing.Point(830, 29);
            this.but_Close.Name = "but_Close";
            this.but_Close.Size = new System.Drawing.Size(75, 23);
            this.but_Close.TabIndex = 3;
            this.but_Close.Text = "Close";
            this.but_Close.UseVisualStyleBackColor = true;
            this.but_Close.Visible = false;
            this.but_Close.Click += new System.EventHandler(this.but_Close_Click);
            // 
            // TrademarkFeeAnalysis
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.CancelButton = this.but_Close;
            this.ClientSize = new System.Drawing.Size(917, 746);
            this.Controls.Add(this.but_Close);
            this.Controls.Add(this.reportViewer1);
            this.Font = new System.Drawing.Font("微軟正黑體", 9F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TrademarkFeeAnalysis";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "商標費用統計";
            this.Load += new System.EventHandler(this.TrademarkFeeAnalysis_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.Button but_Close;
    }
}