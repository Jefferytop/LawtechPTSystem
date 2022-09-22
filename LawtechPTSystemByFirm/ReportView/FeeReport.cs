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
    public partial class FeeReport : Form
    {
        public FeeReport()
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

        private string iApplicantKey ="";
        public string ApplicantKeys
        {
            get { return iApplicantKey; }
            set { iApplicantKey = value; }
        }

        private string iApplicantName ="";
        public string ApplicantNames
        {
            get { return iApplicantName; }
            set { iApplicantName = value; }
        }


        private int iFeeKEY = -1;
        public int FeeKEY
        {
            get { return iFeeKEY; }
            set { iFeeKEY = value; }
        }


        private void FeeReport_Load(object sender, EventArgs e)
        {
            //以列印模式顯示
            this.reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);

            string[] AppNames = ApplicantNames.Split(';');
            AutoCompleteStringCollection ss = new AutoCompleteStringCollection();
            ss.AddRange(AppNames); 

            switch (ModeType)
            {
                case 1:

                    Public.CPatentManagement patent = new LawtechPTSystemByFirm.Public.CPatentManagement();
                    Public.CPatentManagement.ReadOne(iPatentID, ref patent);                    

                    if (patent.DelegateType == 1)//申請人直接委託
                    {
                        //Public.CApplicant app = new LawtechPTSystemByFirm.Public.CApplicant("ApplicantKey in(" + iApplicantKey.ToString() + ")");
                        //Public.CApplicant.ReadOne(iApplicantKey, ref app);
                        //int iAppKey = (int)app.GetDataTable().Rows[0]["ApplicantKey"];
                        //app.SetCurrent(iAppKey);


                        //txt_ApplicantName.AutoCompleteCustomSource = ss;

                        //txt_ApplicantName.Text = AppNames[0];
                        //txt_Address.Text = app.Address;
                        //txt_Fax.Text = app.FAX;


                    }
                    else//複代委託
                    {
                        if (patent.Attorney.HasValue && patent.Attorney != -1)
                        {
                            Public.CAttorney attorney = new LawtechPTSystemByFirm.Public.CAttorney();

                            attorney.AttorneyKey = patent.Attorney.Value;

                            Public.CAttorney.ReadOne(ref attorney);

                            txt_ApplicantName.Text = attorney.AttorneyFirm;
                            txt_Address.Text = attorney.Addr;
                            txt_Fax.Text = attorney.FAX;

                        }
                    }

                    Public.CPatentFee fee = new LawtechPTSystemByFirm.Public.CPatentFee();
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

                   
                    numericUpDown_OAttorneyGovFee.Value =fee.PracticalityPay.HasValue? fee.PracticalityPay.Value:0;

                    numericUpDown_IAttorneyFee.Value =fee.IAttorneyFee.HasValue? fee.IAttorneyFee.Value:0;

                    numericUpDown_OAttorneyGovFee.Value =fee.OAttorneyGovFee.HasValue? fee.OAttorneyGovFee.Value:0;

                    numericUpDown_Totall.Value = fee.Totall.HasValue?fee.Totall.Value:0;
                    break;
                case 2:
                    Public.CTrademarkManagement Tm = new LawtechPTSystemByFirm.Public.CTrademarkManagement();
                    Public.CTrademarkManagement.ReadOne(iPatentID, ref Tm);
                  

                    if (Tm.DelegateType == 1)//申請人直接委託
                    {
                        
                            //Public.CApplicant app = new LawtechPTSystemByFirm.Public.CApplicant("ApplicantKey in(" + iApplicantKey.ToString()+")");
                            //int iAppKey = (int)app.GetDataTable().Rows[0]["ApplicantKey"];
                            //app.SetCurrent(iAppKey);

                            //txt_ApplicantName.AutoCompleteCustomSource = ss;

                            //txt_ApplicantName.Text = AppNames[0];
                            //txt_Address.Text = app.Address;
                            //txt_Fax.Text = app.FAX;
                        

                    }
                    else//複代委託
                    {
                        if (Tm.OutsourcingAttorney != -1)
                        {
                            Public.CAttorney attorney = new LawtechPTSystemByFirm.Public.CAttorney();
                            if(Tm.OutsourcingAttorney.HasValue){
                            Public.CAttorney.ReadOne(Tm.OutsourcingAttorney.Value, ref attorney);
                          
                            txt_ApplicantName.Text = attorney.AttorneyFirm;
                            txt_Address.Text = attorney.Addr;
                            txt_Fax.Text = attorney.FAX;
                            }
                        }
                    }

                    Public.CTrademarkFee TMfee = new LawtechPTSystemByFirm.Public.CTrademarkFee();
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

                    txt_FeeSubject.Text = "專利 " + TMfee.FeeSubject;
                    numericUpDown_OAttorneyGovFee.Value = TMfee.PracticalityPay.Value;

                    numericUpDown_IAttorneyFee.Value = TMfee.IAttorneyFee.Value;

                    numericUpDown_OAttorneyGovFee.Value = TMfee.OAttorneyGovFee.Value;

                    numericUpDown_Totall.Value = TMfee.Totall.Value;
                    break;
            }

            RefashionData();
            
        }

        public string GetCountryName(string Country)
        {
            string strSQL = string.Format("select Country from CountryT where CountrySymbol='{0}'", Country);
            Public.DLL dll = new LawtechPTSystemByFirm.Public.DLL();
            object obj=dll.SQLexecuteScalar(strSQL);
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
            string strSQL = string.Format("select Kind from KindT where KindSN='{0}'", kind);
            Public.DLL dll = new LawtechPTSystemByFirm.Public.DLL();
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

            ReportParameter ApplicantName = new ReportParameter("Report_ApplicantName", txt_ApplicantName.Text);
            Params.Add(ApplicantName);

            ReportParameter Addr = new ReportParameter("Report_Addr", txt_Address.Text);
            Params.Add(Addr);

            ReportParameter Phone = new ReportParameter("Report_TEL", txt_Phone.Text);
            Params.Add(Phone);

            ReportParameter Fax = new ReportParameter("Report_FAX", txt_Fax.Text);
            Params.Add(Fax);

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
                      

            //本所服務費
            ReportParameter ITotall = new ReportParameter("Report_ITotall", numericUpDown_IAttorneyFee.Value.ToString("#,##0.##"));
            Params.Add(ITotall);

            //代收代付費
            ReportParameter GovFee = new ReportParameter("Report_GovFee", numericUpDown_OAttorneyGovFee.Value.ToString("#,##0.##"));
            Params.Add(GovFee);

            //稅額
            ReportParameter tax = new ReportParameter("Report_Tax", numericUpDown_Tax.Value.ToString("#,##0.##"));
            Params.Add(tax);

            //合計
            ReportParameter Totall = new ReportParameter("Report_Totall", numericUpDown_Totall.Value.ToString("#,##0.##"));
            Params.Add(Totall);

            //付款說明
            ReportParameter PaymentInstructions = new ReportParameter("Report_PaymentInstructions", txt_PaymentInstructions.Text);
            Params.Add(PaymentInstructions);

            Public.DLL dll = new LawtechPTSystemByFirm.Public.DLL();
            string strPracticalityPay1 = dll.convertMoneyString(numericUpDown_Totall.Value.ToString("0.##"));
            textBox1.Text = strPracticalityPay1.Replace("零"," ");
            ReportParameter PracticalityPay1 = new ReportParameter("Report_PracticalityPay1", textBox1.Text);
            Params.Add(PracticalityPay1);

            this.reportViewer1.LocalReport.SetParameters(Params);

            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_ReportRefresh(object sender, CancelEventArgs e)
        {
            RefashionData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RefashionData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
