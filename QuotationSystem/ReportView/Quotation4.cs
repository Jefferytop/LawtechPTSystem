using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace LawtechPTSystem.ReportView
{
    public partial class Quotation4 : Form
    {
        public Quotation4()
        {
            InitializeComponent();
        }

        private int iApplicantMode;
        /// <summary>
        /// 申請模式 0.客戶 複代
        /// </summary>
        public int ApplicantMode
        {
            get { return iApplicantMode; }
            set { iApplicantMode = value; }
        }


        private string _Liaisoner;
        public string Liaisoner
        {
            get { return _Liaisoner; }
            set { _Liaisoner = value; }
        }

        private int _ApplicantKey;

        public int ApplicantKey
        {
            get { return _ApplicantKey; }
            set { _ApplicantKey = value; }
        }

        private int iLanguage;
        /// <summary>
        /// 語系 1.繁體 2.簡體 3.英文
        /// </summary>
        public int Language
        {
            get { return iLanguage; }
            set { iLanguage = value; }
        }

        private void Quotation4_Load(object sender, EventArgs e)
        {
            switch (iLanguage)
            {
                case 1:
                    reportViewer1.LocalReport.ReportEmbeddedResource = "LawtechPTSystem.Report.Quotation4RF.rdlc";
                    this.DataTable1TableAdapter.Fill(this.BMtriffDataSet.DataTable1, _ApplicantKey, ApplicantMode);
                    reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("BMtriffDataSet_DataTable1", this.BMtriffDataSet.DataTable1.GetEnumerator()));
                    break;

                case 2:
                    reportViewer1.LocalReport.ReportEmbeddedResource = "LawtechPTSystem.Report.Quotation4RF_CHS.rdlc";
                    this.dataTable_CHSTableAdapter1.Fill(this.BMtriffDataSet.DataTable_CHS, _ApplicantKey, ApplicantMode);
                    reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("BMtriffDataSet_DataTable_CHS", this.BMtriffDataSet.DataTable_CHS.GetEnumerator()));
                    break;

                case 3:
                    reportViewer1.LocalReport.ReportEmbeddedResource = "LawtechPTSystem.Report.Quotation4RF_EN.rdlc";
                    this.dataTable_ENTableAdapter1.Fill(this.BMtriffDataSet.DataTable_EN, _ApplicantKey, ApplicantMode);
                    reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("BMtriffDataSet_DataTable_EN", this.BMtriffDataSet.DataTable_EN.GetEnumerator()));
                    break;
            }

            //以列印模式顯示
            this.reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);

            string reportPath = "";
            if (!string.IsNullOrEmpty(Properties.Settings.Default.QuotationLogo))
            {
                reportPath = Properties.Settings.Default.QuotationLogo;
            }

            reportViewer1.LocalReport.EnableExternalImages = true;

            ReportParameter rpLogoPath = new ReportParameter("ReportLogoPath", reportPath);
            ReportParameter rp = new ReportParameter("Liaisoner", _Liaisoner);

            List<ReportParameter> Params = new List<ReportParameter>();
            Params.Add(rp);
            Params.Add(rpLogoPath);
            this.reportViewer1.LocalReport.SetParameters(Params);

            this.reportViewer1.RefreshReport();
        }



    }
}
