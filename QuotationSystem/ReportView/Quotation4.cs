using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
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

        private DataTable dt_AcountingFirmT = new DataTable();
        /// <summary>
        /// 入帳公司資料
        /// </summary>
        public DataTable AcountingFirmT
        {
            get { return dt_AcountingFirmT; }
            set
            {
                dt_AcountingFirmT = value;
            }
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
            #region 取得入帳公司資料
            Public.CAccountingPublicFunction.GetAcountingFirmTDropDownList(ref dt_AcountingFirmT);
            DataRow drN = dt_AcountingFirmT.NewRow();
            drN["AcountingFirmKey"] = 0;
            drN["AcountingFirmName"] = "預設值";
            dt_AcountingFirmT.Rows.InsertAt(drN, 0);
            comboBox_AcountingFirmT.DataSource = dt_AcountingFirmT;
            comboBox_AcountingFirmT.DisplayMember = "AcountingFirmName";
            comboBox_AcountingFirmT.ValueMember = "AcountingFirmKey";

            //this.comboBox_AcountingFirmT.SelectedIndexChanged += new System.EventHandler(this.comboBox_AcountingFirmT_SelectedIndexChanged);
            #endregion

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


        private void comboBox_AcountingFirmT_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            //以列印模式顯示
            this.reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);

            string reportPath = "";
            switch (comboBox_AcountingFirmT.SelectedValue)
            {
                case 0:
                    if (!string.IsNullOrEmpty(Properties.Settings.Default.QuotationLogo))
                    {
                        reportPath = Properties.Settings.Default.QuotationLogo;
                    }
                    break;
                default:
                    int iKey = (int)comboBox_AcountingFirmT.SelectedValue;
                    Public.CAcountingFirmT firm = new Public.CAcountingFirmT();
                    Public.CAcountingFirmT.ReadOne(iKey, ref firm);
                    if (!string.IsNullOrEmpty(firm.LogoUrl))
                    {
                        reportPath = firm.LogoUrl;
                    }
                    else
                    {
                        reportPath = Properties.Settings.Default.QuotationLogo;
                    }
                    break;
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
