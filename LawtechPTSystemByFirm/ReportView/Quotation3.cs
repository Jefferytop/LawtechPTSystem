using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace LawtechPTSystemByFirm.ReportView
{
    public partial class Quotation3 : Form
    {
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


        public Quotation3()
        {
            InitializeComponent();
        }

        private void Quotation3_Load(object sender, EventArgs e)
        {
            switch (iLanguage)
            {
                case 1:
                    reportViewer1.LocalReport.ReportEmbeddedResource = "LawtechPTSystemByFirm.Report.Quotation3RF.rdlc";
                    this.DataTable1TableAdapter.Fill(this.BMtriffDataSet.DataTable1, _ApplicantKey, ApplicantMode);
                    reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("BMtriffDataSet_DataTable1", this.BMtriffDataSet.DataTable1.GetEnumerator()));
                    break;

                case 2:
                    reportViewer1.LocalReport.ReportEmbeddedResource = "LawtechPTSystemByFirm.Report.Quotation3RF_CHS.rdlc";
                    this.dataTable_CHSTableAdapter1.Fill(this.BMtriffDataSet.DataTable_CHS, _ApplicantKey, ApplicantMode);
                    reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("BMtriffDataSet_DataTable_CHS", this.BMtriffDataSet.DataTable_CHS.GetEnumerator()));
                    break;

                case 3:
                    reportViewer1.LocalReport.ReportEmbeddedResource = "LawtechPTSystemByFirm.Report.Quotation3RF_EN.rdlc";
                    this.dataTable_ENTableAdapter1.Fill(this.BMtriffDataSet.DataTable_EN, _ApplicantKey, ApplicantMode);
                    reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("BMtriffDataSet_DataTable_EN", this.BMtriffDataSet.DataTable_EN.GetEnumerator()));
                    break;
            }

            //以列印模式顯示
            this.reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);

            ReportParameter rp = new ReportParameter("Liaisoner", _Liaisoner);
            List<ReportParameter> Params = new List<ReportParameter>();
            Params.Add(rp);
            this.reportViewer1.LocalReport.SetParameters(Params);

            this.reportViewer1.RefreshReport();
        }
    }
}