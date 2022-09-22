using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LawtechPTSystem.ReportView
{
    /// <summary>
    /// 收據
    /// </summary>
    public partial class FeeReceiptReport : Form
    {
        public FeeReceiptReport()
        {
            InitializeComponent();
        }

        private int iModeType = 1;
        /// <summary>
        /// 模式 1.專利  2.商標
        /// </summary>
        public int ModeType
        {
            get { return iModeType; }
            set { iModeType = value; }
        }

        private int iPatentID = -1;
        public int PatentID
        {
            get { return iPatentID; }
            set { iPatentID = value; }
        }

         private int iFeeKEY = -1;
        public int FeeKEY
        {
            get { return iFeeKEY; }
            set { iFeeKEY = value; }
        }

        private string iApplicantKey = "";
        public string ApplicantKeys
        {
            get { return iApplicantKey; }
            set { iApplicantKey = value; }
        }

        private string iApplicantName = "";
        public string ApplicantNames
        {
            get { return iApplicantName; }
            set { iApplicantName = value; }
        }

        private void FeeReceiptReport_Load(object sender, EventArgs e)
        {
            #region 取得靜態文字預設值
            Public.CStatueRecordT cs = new Public.CStatueRecordT();
            Public.CStatueRecordT.ReadOne("StatusName='FeeReceiptReport' ", ref cs);
            if (cs.Value != null && cs.Value.Length > 0)
            {
                string[] str = cs.Value.Split('§');
                if (str.Length ==3)
                {                   
                    txt_PaymentInstructions.Text = str[0];
                    txt_Footer.Text = str[1];
                    txt_Footer1.Text = str[2];
                }
            }
            #endregion

            //以列印模式顯示
            this.reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);           

            switch (ModeType)
            {
                case 1: //專利

                    Public.CPatentManagement patent = new Public.CPatentManagement();
                    Public.CPatentManagement.ReadOne(iPatentID, ref patent);

                    string[] AppNames = patent.ApplicantNames!=null? patent. ApplicantNames.Split(';'):null;
                    if (AppNames.Length > 0)
                    {
                        txt_ApplicantName.Text = AppNames[0];
                    }
                  

                    Public.CPatentFee fee = new Public.CPatentFee();
                    Public.CPatentFee.ReadOne(iFeeKEY, ref fee);


                    txt_PPP.Text = fee.PPP;
                    if (fee.RDate.HasValue)
                    {
                        maskedTextBox_RDate.Text = fee.RDate.Value.ToString("yyyy/MM/dd");
                    }

                    txt_AttorneyRefNo.Text = patent.MainCustomerRefNo;
                    txt_PatentNo.Text = patent.PatentNo;
                    txt_Title.Text = patent.Title;
                    txt_Country.Text = GetCountryName(patent.CountrySymbol);
                    txt_Kind.Text = GetKIndName(patent.Kind);
                    txt_ApplicationNo.Text = patent.ApplicationNo;
                    if (patent.ApplicationDate.HasValue)
                    {
                        maskedTextBox_ApplicationDate.Text = patent.ApplicationDate.Value.ToString("yyyy/MM/dd");
                    }

                    txt_FeeSubject.Text = "專利 " + fee.FeeSubject;
                  
                    decimal OthTotal = fee.OthTotal.HasValue ? fee.OthTotal.Value : 0;                 

                    //服務費
                    numericUpDown_OthTotal.Value = fee.OtherTotalFee.HasValue ? fee.OtherTotalFee.Value : 0;

                    //代收代付合計NT
                    numericUpDown_OAttorneyGovFee.Value = fee.OAttorneyGovFee.HasValue?fee.OAttorneyGovFee.Value:0;
                    break;
                case 2:  //商標
                    Public.CTrademarkManagement Tm = new Public.CTrademarkManagement();
                    Public.CTrademarkManagement.ReadOne(iPatentID, ref Tm);

                    string[] TmAppNames = Tm.ApplicantNames!=null? Tm.ApplicantNames.Split(';'):null;
                  if(TmAppNames.Length>0)
                    {
                        txt_ApplicantName.Text = TmAppNames[0];
                    }
                   

                    Public.CTrademarkFee TMfee = new Public.CTrademarkFee();
                    Public.CTrademarkFee.ReadOne(iFeeKEY, ref TMfee);

                    txt_PPP.Text = TMfee.PPP;
                    if (TMfee.RDate.HasValue)
                    {
                        maskedTextBox_RDate.Text = TMfee.RDate.Value.ToString("yyyy/MM/dd");
                    }

                    txt_AttorneyRefNo.Text = Tm.MainCustomerRefNo;
                    txt_PatentNo.Text = Tm.TrademarkNo;
                    txt_Title.Text = Tm.TrademarkName;
                    txt_Country.Text = GetCountryName(Tm.CountrySymbol);
                    txt_Kind.Text = GetKIndName(Tm.StyleName);
                    txt_ApplicationNo.Text = Tm.ApplicationNo;
                    if (Tm.ApplicationDate.HasValue)
                    {
                        maskedTextBox_ApplicationDate.Text = Tm.ApplicationDate.Value.ToString("yyyy/MM/dd");
                    }

                    txt_FeeSubject.Text = "商標 " + TMfee.FeeSubject;

                    //服務費
                    numericUpDown_OthTotal.Value = TMfee.OtherTotalFee.HasValue ? TMfee.OtherTotalFee.Value : 0;

                    //代收代付合計NT
                    numericUpDown_OAttorneyGovFee.Value = TMfee.OAttorneyGovFee.HasValue ? TMfee.OAttorneyGovFee.Value : 0;

                    break;
            }

            RefashionData();
        }

        public string GetCountryName(string Country)
        {
            string strSQL = string.Format("select Country from CountryT with(nolock) where CountrySymbol='{0}'", Country);
            Public.DLL dll = new Public.DLL();
            object obj = dll.SQLexecuteScalar(strSQL);
            if (obj != null)
            {
                return obj.ToString();
            }
            else
            {
                return "";
            }
        }

        public string GetKIndName(string kind)
        {
            string strSQL = string.Format("select Kind from KindT with(nolock) where KindSN='{0}'", kind);
            Public.DLL dll = new Public.DLL();
            object obj = dll.SQLexecuteScalar(strSQL);
            if (obj != null)
            {
                return obj.ToString();
            }
            else
            {
                return "";
            }
        }

        public void RefashionData()
        {
            List<ReportParameter> Params = new List<ReportParameter>();          

            ReportParameter PPP = new ReportParameter("Report_PPP", txt_PPP.Text);
            Params.Add(PPP);

            ReportParameter RDate = new ReportParameter("Report_RDate", maskedTextBox_RDate.Text != "    /  /" ? maskedTextBox_RDate.Text : "");
            Params.Add(RDate);

            ReportParameter AttorneyRefNo = new ReportParameter("Report_AttorneyRefNo", txt_AttorneyRefNo.Text);
            Params.Add(AttorneyRefNo);

            ReportParameter PatentNo = new ReportParameter("Report_PatentNo", txt_PatentNo.Text);
            Params.Add(PatentNo);

            ReportParameter FeeSubject = new ReportParameter("Report_FeeSubject", txt_FeeSubject.Text);
            Params.Add(FeeSubject);

            ReportParameter Title = new ReportParameter("Report_Title", txt_Title.Text);
            Params.Add(Title);

            ReportParameter Country = new ReportParameter("Report_Country", txt_Country.Text);
            Params.Add(Country);

            ReportParameter Kind = new ReportParameter("Report_Kind", txt_Kind.Text);
            Params.Add(Kind);

            ReportParameter ApplicationNo = new ReportParameter("Report_ApplicationNo", txt_ApplicationNo.Text);
            Params.Add(ApplicationNo);

            ReportParameter ApplicationDate = new ReportParameter("Report_ApplicationDate", maskedTextBox_ApplicationDate.Text != "    /  /" ? maskedTextBox_ApplicationDate.Text : "");
            Params.Add(ApplicationDate);

            //收據總計
            ReportParameter IAttorneyFee = new ReportParameter("Report_OthTotal", numericUpDown_OthTotal.Value.ToString("#,##0.##"));
            Params.Add(IAttorneyFee);

            //代收代付總計
            ReportParameter OAttorneyGovFee = new ReportParameter("Report_OAttorneyGovFee", numericUpDown_OAttorneyGovFee.Value.ToString("#,##0.##"));
            Params.Add(OAttorneyGovFee);

            //申請人名
            ReportParameter AttorneyName = new ReportParameter("Report_ApplicantName", txt_ApplicantName.Text);
            Params.Add(AttorneyName);

            //備註
            ReportParameter PaymentInstructions = new ReportParameter("Report_PaymentInstructions", txt_PaymentInstructions.Text);
            Params.Add(PaymentInstructions);

            //頁尾
            ReportParameter footer = new ReportParameter("ReportParameterFooter", txt_Footer.Text);
            Params.Add(footer);

            //頁尾
            ReportParameter footer1 = new ReportParameter("ReportParameterFooter1", txt_Footer1.Text);
            Params.Add(footer1);



            try
            {
                string reportPath = "";
                if (!string.IsNullOrEmpty(Properties.Settings.Default.QuotationLogo))
                {
                    reportPath = Properties.Settings.Default.QuotationLogo;
                }
                ReportParameter rpLogoPath = new ReportParameter("ReportLogoPath", reportPath);
                Params.Add(rpLogoPath);

                reportViewer1.LocalReport.EnableExternalImages = true;

                this.reportViewer1.LocalReport.SetParameters(Params);

                this.reportViewer1.RefreshReport();
            }
            catch (SystemException EX)
            {
                MessageBox.Show(EX.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_SaveText_Click(object sender, EventArgs e)
        {
            try
            {
                string strTextFee = string.Format("{0}§{1}§{2}",                     
                    txt_PaymentInstructions.Text,
                    txt_Footer.Text ,
                      txt_Footer1.Text);

                Public.CStatueRecordT cs = new Public.CStatueRecordT();
                Public.CStatueRecordT.ReadOne("StatusName='FeeReceiptReport' ", ref cs);

                cs.Value = strTextFee;
                cs.Update();

                MessageBox.Show(string.Format("儲存靜態文字成功 : {0} , {1} ",
                   "備註", "頁尾"));
            }
            catch (SystemException EX)
            {
                MessageBox.Show("儲存失敗:" + EX.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RefashionData();
        }
    }
}
