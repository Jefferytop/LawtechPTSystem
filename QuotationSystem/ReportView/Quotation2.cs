using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace LawtechPTSystem.ReportView
{
    public partial class Quotation2 : Form
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


        /// <summary>
        /// 1:精簡格式 2:標準格式 3:專業格式 4:列表格式
        /// </summary>
        private int QuotationKind = 2;
        private Public.CQuotationTextT cq = new Public.CQuotationTextT();

        public Quotation2()
        {
            InitializeComponent();
        }

        private void Quotation2_Load(object sender, EventArgs e)
        {
            #region 取得入帳公司資料
            Public.CAccountingPublicFunction.GetAcountingFirmTDropDownList(ref dt_AcountingFirmT);
            DataRow drN = dt_AcountingFirmT.NewRow();
            drN["AcountingFirmKey"] = 0;
            drN["AcountingFirmName"] = "預設值";
            dt_AcountingFirmT.Rows.InsertAt(drN, 0);
            comboBox_AcountingFirmT.DisplayMember = "AcountingFirmName";
            comboBox_AcountingFirmT.ValueMember = "AcountingFirmKey";
            comboBox_AcountingFirmT.DataSource = dt_AcountingFirmT;
            #endregion
            this.comboBox_AcountingFirmT.SelectedIndexChanged += new System.EventHandler(this.comboBox_AcountingFirmT_SelectedIndexChanged);

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
                        reportViewer1.LocalReport.ReportEmbeddedResource = "LawtechPTSystem.Report.Quotation2RF.rdlc";
                        this.dataTable1TableAdapter.Fill(this.bMtriffDataSet.DataTable1, _ApplicantKey, ApplicantMode);
                        ReportDataSource ds = new ReportDataSource("BMtriffDataSet_DataTable1", this.bMtriffDataSet.DataTable1.GetEnumerator());
                        reportViewer1.LocalReport.DataSources.Add(ds);

                        break;

                    case 2:
                        reportViewer1.LocalReport.ReportEmbeddedResource = "LawtechPTSystem.Report.Quotation2RF_CHS.rdlc";
                        this.dataTable_CHSTableAdapter1.Fill(this.bMtriffDataSet.DataTable_CHS, _ApplicantKey, ApplicantMode);
                        reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("BMtriffDataSet_DataTable_CHS", this.bMtriffDataSet.DataTable_CHS.GetEnumerator()));
                        break;

                    case 3:
                        reportViewer1.LocalReport.ReportEmbeddedResource = "LawtechPTSystem.Report.Quotation2RF_EN.rdlc";
                        this.dataTable_ENTableAdapter1.Fill(this.bMtriffDataSet.DataTable_EN, _ApplicantKey, ApplicantMode);
                        reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("BMtriffDataSet_DataTable_EN", this.bMtriffDataSet.DataTable_EN.GetEnumerator()));
                        break;

                }


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
                ReportParameter rp = new ReportParameter("Liaisoner", txt_Liaisoner.Text);
                ReportParameter rpLogoPath = new ReportParameter("ReportLogoPath", reportPath);
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
            ReportParameter rp = new ReportParameter("Liaisoner", txt_Liaisoner.Text);

            ReportParameter rpLogoPath = new ReportParameter("ReportLogoPath", reportPath);

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

        /// <summary>
        /// 儲存綠字按鈕
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                object obj = new object();
                switch ((int)comboBox_AcountingFirmT.SelectedValue)
                {

                    case 0:
                        cq.Subject = txt_Subject.Text;
                        cq.ContentText = txt_Content.Text;
                        cq.Description = txt_Description.Text;
                        obj = cq.Update();
                        if (obj.ToString() == "0")
                        {
                            MessageBox.Show("儲存成功", "提示訊息");
                        }
                        else
                        {
                            MessageBox.Show("儲存失敗" + obj.ToString(), "提示訊息");
                        }
                        break;
                    default:
                        int iKey = (int)comboBox_AcountingFirmT.SelectedValue;
                        Public.CAcountingFirmT firm = new Public.CAcountingFirmT();
                        Public.CAcountingFirmT.ReadOne(iKey, ref firm);
                        firm.Quotation_Subject = txt_Subject.Text;
                        firm.Quotation_Content = txt_Content.Text;
                        firm.Quotation_Explain = txt_Description.Text;
                        obj = firm.Update();
                        if (obj.ToString() == "0")
                        {
                            MessageBox.Show("儲存成功", "提示訊息");
                        }
                        else
                        {
                            MessageBox.Show("儲存失敗" + obj.ToString(), "提示訊息");
                        }
                        break;
                }
            }
            catch { }
        }

        private void comboBox_AcountingFirmT_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_AcountingFirmT.SelectedValue != null)
            {
                switch ((int)comboBox_AcountingFirmT.SelectedValue)
                {
                    case 0:
                        string strsql = string.Format("QuotationKind={0} and LanguagesID={1}", QuotationKind, iLanguage);

                        Public.CQuotationTextT.ReadOne(strsql, ref cq);

                        txt_Subject.Text = cq.Subject;
                        txt_Content.Text = cq.ContentText;
                        txt_Description.Text = cq.Description;

                        txt_Liaisoner.Text = Liaisoner + " 先生 / 小姐";
                        break;
                    default:
                        int iKey = (int)comboBox_AcountingFirmT.SelectedValue;
                        Public.CAcountingFirmT firm = new Public.CAcountingFirmT();
                        Public.CAcountingFirmT.ReadOne(iKey, ref firm);
                        txt_Subject.Text = firm.Quotation_Subject;
                        txt_Content.Text = firm.Quotation_Content;
                        txt_Description.Text = firm.Quotation_Explain;
                        break;
                }

            }
        }


    }
}