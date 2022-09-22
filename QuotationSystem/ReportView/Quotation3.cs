using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace LawtechPTSystem.ReportView
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

        /// <summary>
        /// 1:精簡格式 2:標準格式 3:專業格式 4:列表格式
        /// </summary>
        private int QuotationKind = 3;
        private Public.CQuotationTextT cq = new Public.CQuotationTextT();

        public Quotation3()
        {
            InitializeComponent();
        }

        private void Quotation3_Load(object sender, EventArgs e)
        {
            try
            {
                string strsql = string.Format("QuotationKind={0} and LanguagesID={1}", QuotationKind, iLanguage);

                Public.CQuotationTextT.ReadOne(strsql, ref cq);

                txt_Subject.Text = cq.Subject;
                txt_Content.Text = cq.ContentText;
                txt_Description.Text = cq.Description;
                txt_Liaisoner.Text = Liaisoner + " 先生 / 小姐";

                switch (iLanguage)
                {
                    case 1:
                        reportViewer1.LocalReport.ReportEmbeddedResource = "LawtechPTSystem.Report.Quotation3RF.rdlc";
                        this.DataTable1TableAdapter.Fill(this.BMtriffDataSet.DataTable1, _ApplicantKey, ApplicantMode);
                        reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("BMtriffDataSet_DataTable1", this.BMtriffDataSet.DataTable1.GetEnumerator()));
                        break;

                    case 2:
                        reportViewer1.LocalReport.ReportEmbeddedResource = "LawtechPTSystem.Report.Quotation3RF_CHS.rdlc";
                        this.dataTable_CHSTableAdapter1.Fill(this.BMtriffDataSet.DataTable_CHS, _ApplicantKey, ApplicantMode);
                        reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("BMtriffDataSet_DataTable_CHS", this.BMtriffDataSet.DataTable_CHS.GetEnumerator()));
                        break;

                    case 3:
                        reportViewer1.LocalReport.ReportEmbeddedResource = "LawtechPTSystem.Report.Quotation3RF_EN.rdlc";
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
                ReportParameter rp = new ReportParameter("Liaisoner", txt_Liaisoner.Text);
                ReportParameter psubject = new ReportParameter("Subject", txt_Subject.Text);

                ReportParameter pContent = new ReportParameter("Content", txt_Content.Text);

                ReportParameter pDescription = new ReportParameter("Description", txt_Description.Text);

                List<ReportParameter> Params = new List<ReportParameter>();
                Params.Add(rp);
                Params.Add(psubject);
                Params.Add(pContent);
                Params.Add(pDescription);
                Params.Add(rpLogoPath);
                this.reportViewer1.LocalReport.SetParameters(Params);

                this.reportViewer1.RefreshReport();
            }
            catch (SystemException EX)
            {
                MessageBox.Show(EX.Message);
            }
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            //以列印模式顯示
            this.reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);

            string reportPath = "";
            if (!string.IsNullOrEmpty(Properties.Settings.Default.QuotationLogo))
            {
                reportPath = Properties.Settings.Default.QuotationLogo;
            }

            reportViewer1.LocalReport.EnableExternalImages = true;

            ReportParameter rpLogoPath = new ReportParameter("ReportLogoPath", reportPath);
            ReportParameter rp = new ReportParameter("Liaisoner", txt_Liaisoner.Text);
            ReportParameter psubject = new ReportParameter("Subject", txt_Subject.Text);

            ReportParameter pContent = new ReportParameter("Content", txt_Content.Text);

            ReportParameter pDescription = new ReportParameter("Description", txt_Description.Text);

            List<ReportParameter> Params = new List<ReportParameter>();
            Params.Add(rp);
            Params.Add(psubject);
            Params.Add(pContent);
            Params.Add(pDescription);
            Params.Add(rpLogoPath);
            this.reportViewer1.LocalReport.SetParameters(Params);

            this.reportViewer1.RefreshReport();
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            cq.Subject = txt_Subject.Text;
            cq.ContentText = txt_Content.Text;
            cq.Description = txt_Description.Text;
            object obj = cq.Update();
            if (obj.ToString() == "0")
            {
                MessageBox.Show("儲存成功", "提示訊息");
            }
            else
            {
                MessageBox.Show("儲存失敗" + obj.ToString(), "提示訊息");
            }
        }
    }
}