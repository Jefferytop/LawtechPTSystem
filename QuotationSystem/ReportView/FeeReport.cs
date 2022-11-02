using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

using System.Data;

namespace LawtechPTSystem.ReportView
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


        private int iFeeKEY = -1;
        public int FeeKEY
        {
            get { return iFeeKEY; }
            set { iFeeKEY = value; }
        }

        DataTable FeeTable = new DataTable();

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
        /// 初始化
        /// </summary>
        private void FeeTableInit()
        {
            FeeTable.Columns.Add(new DataColumn("FeeItemName", typeof(string)));
            FeeTable.Columns.Add(new DataColumn("Amount", typeof(decimal)));
            FeeTable.Columns.Add(new DataColumn("TaxAmount", typeof(decimal)));
            FeeTable.Columns.Add(new DataColumn("TotalAmount", typeof(decimal)));
        }

        private void FeeTableAdd() {

            FeeTable.Rows.Clear();
            if (!cb_NT.Checked)
            {
                #region 台幣收款
                if (txt_GTotall.Text.Trim() != "")
                {
                    DataRow dr = FeeTable.NewRow();
                    dr["FeeItemName"] = txt_GTotall.Text.Trim();
                    dr["Amount"] = numericUpDown_GTotall.Value;
                    dr["TaxAmount"] = 0;
                    dr["TotalAmount"] = numericUpDown_GTotall.Value;
                    FeeTable.Rows.Add(dr);
                }

                if (txt_OAttorneyGovFee.Text.Trim() != "")
                {
                    DataRow dr = FeeTable.NewRow();
                    dr["FeeItemName"] = txt_OAttorneyGovFee.Text.Trim();
                    dr["Amount"] = numericUpDown_OAttorneyGovFee.Value;
                    dr["TaxAmount"] = 0;
                    dr["TotalAmount"] = numericUpDown_OAttorneyGovFee.Text.Trim();
                    FeeTable.Rows.Add(dr);
                }

                if (txt_OthFeeName.Text.Trim() != "")
                {
                    DataRow dr = FeeTable.NewRow();
                    dr["FeeItemName"] = txt_OthFeeName.Text.Trim();
                    dr["Amount"] = numericUpDown_OthFee.Value;
                    dr["TaxAmount"] = 0;
                    dr["TotalAmount"] = numericUpDown_OthFee.Text.Trim();
                    FeeTable.Rows.Add(dr);
                }

                if (txt_CustomizeName.Text.Trim() != "")
                {
                    DataRow dr = FeeTable.NewRow();
                    dr["FeeItemName"] = txt_CustomizeName.Text.Trim();
                    dr["Amount"] = numericUpDown_CustomizeOthFee.Value;
                    dr["TaxAmount"] = 0;
                    dr["TotalAmount"] = numericUpDown_CustomizeOthFee.Text.Trim();
                    FeeTable.Rows.Add(dr);
                }

                //服務費
                if (txt_IAttorneyFee.Text.Trim() != "")
                {
                    DataRow dr = FeeTable.NewRow();
                    dr["FeeItemName"] = txt_IAttorneyFee.Text.Trim();
                    dr["Amount"] = numericUpDown_IAttorneyFee.Value;
                    dr["TaxAmount"] = numericUpDown_IAttorneyFee.Value * numericUpDown_TaxPercent.Value * 0.01m;
                    dr["TotalAmount"] = (decimal)dr["Amount"] - (decimal)dr["TaxAmount"];
                    FeeTable.Rows.Add(dr);
                }

                if (txt_OtherTotalFeeCustomize1Name.Text.Trim() != "")
                {
                    DataRow dr = FeeTable.NewRow();
                    dr["FeeItemName"] = txt_OtherTotalFeeCustomize1Name.Text.Trim();
                    dr["Amount"] = numericUpDown_OtherTotalFeeCustomize1.Value;
                    dr["TaxAmount"] = numericUpDown_OtherTotalFeeCustomize1.Value * numericUpDown_TaxPercent.Value * 0.01m;
                    dr["TotalAmount"] = (decimal)dr["Amount"] - (decimal)dr["TaxAmount"];
                    FeeTable.Rows.Add(dr);
                }

                if (txt_OtherTotalFeeCustomize2Name.Text.Trim() != "")
                {
                    DataRow dr = FeeTable.NewRow();
                    dr["FeeItemName"] = txt_OtherTotalFeeCustomize2Name.Text.Trim();
                    dr["Amount"] = numericUpDown_OtherTotalFeeCustomize2.Value;
                    dr["TaxAmount"] = numericUpDown_OtherTotalFeeCustomize2.Value * numericUpDown_TaxPercent.Value * 0.01m;
                    dr["TotalAmount"] = (decimal)dr["Amount"] - (decimal)dr["TaxAmount"];
                    FeeTable.Rows.Add(dr);
                }

                if (txt_OtherTotalFeeCustomize3Name.Text.Trim() != "")
                {
                    DataRow dr = FeeTable.NewRow();
                    dr["FeeItemName"] = txt_OtherTotalFeeCustomize3Name.Text.Trim();
                    dr["Amount"] = numericUpDown_OtherTotalFeeCustomize3.Value;
                    dr["TaxAmount"] = numericUpDown_OtherTotalFeeCustomize3.Value * numericUpDown_TaxPercent.Value * 0.01m;
                    dr["TotalAmount"] = (decimal)dr["Amount"] - (decimal)dr["TaxAmount"];
                    FeeTable.Rows.Add(dr);
                }
                #endregion
            }
            else
            {
                #region 外幣收款
                //服務費               
                DataRow dr = FeeTable.NewRow();
                dr["FeeItemName"] = "服務費";
                decimal decTotall;
                bool b = decimal.TryParse(txt_Totall.Text, out decTotall);
                if (b)
                {
                    dr["Amount"] = decTotall;
                    dr["TotalAmount"] = decTotall;
                }
                else
                {
                    dr["Amount"] = 0;
                    dr["TotalAmount"] = 0;
                }

                dr["TaxAmount"] = 0;

                FeeTable.Rows.Add(dr);
                #endregion

            }
        }

        private void FeeReport_Load(object sender, EventArgs e)
        {
            #region 取得靜態文字預設值
            Public.CStatueRecordT cs = new Public.CStatueRecordT();
            Public.CStatueRecordT.ReadOne("StatusName='FeeReport' ", ref cs);
            if (cs.Value != null && cs.Value.Length > 0)
            {
                string[] str = cs.Value.Split('§');
                if (str.Length == 3)
                {
                    txt_PaymentInstructions.Text = str[0];
                    txt_Footer.Text = str[1];
                    txt_Footer1.Text = str[2];
                }
            }
            #endregion

            #region 取得入帳公司資料
            Public.CAccountingPublicFunction.GetAcountingFirmTDropDownList(ref dt_AcountingFirmT);
            DataRow drN = dt_AcountingFirmT.NewRow();
            drN["AcountingFirmKey"] = 0;
            drN["AcountingFirmName"] = "預設值";
            dt_AcountingFirmT.Rows.InsertAt(drN, 0);
            comboBox_AcountingFirmT.DataSource = dt_AcountingFirmT;
            comboBox_AcountingFirmT.DisplayMember = "AcountingFirmName";
            comboBox_AcountingFirmT.ValueMember = "AcountingFirmKey";

            this.comboBox_AcountingFirmT.SelectedIndexChanged += new System.EventHandler(this.comboBox_AcountingFirmT_SelectedIndexChanged);
            #endregion

            FeeTableInit();

            //以列印模式顯示
            this.reportViewer1.SetDisplayMode(DisplayMode.PrintLayout);

            string[] AppNames = ApplicantNames.Split(';');
            AutoCompleteStringCollection ss = new AutoCompleteStringCollection();
            ss.AddRange(AppNames);

            switch (ModeType)
            {
                case 1:
                    #region 專利
                    Public.CPatentManagement patent = new Public.CPatentManagement();
                    Public.CPatentManagement.ReadOne(iPatentID, ref patent);

                    if (patent.DelegateType == 1)//申請人直接委託
                    {
                        List<Public.CApplicant> app = new List<Public.CApplicant>();
                        if (!string.IsNullOrEmpty(iApplicantKey.ToString()))
                        {
                            Public.CApplicant.ReadList(ref app, "ApplicantKey in(" + iApplicantKey.ToString() + ")");
                        }
                        else
                        {
                            if (AppNames.Length > 0)
                            {
                                Public.CApplicant.ReadList(ref app, "ApplicantName ='" + AppNames[0].ToString() + "'");
                            }
                            else
                            {
                                Public.CApplicant.ReadList(ref app, "ApplicantName ='' ");
                            }
                        }

                        txt_ApplicantName.AutoCompleteCustomSource = ss;

                        txt_ApplicantName.Text = AppNames[0];
                        if (app.Count > 0)
                        {
                            DataTable dtLiaisoner = new DataTable();
                            Public.CApplicantPublicFunction.GetLiaisonerContractTypeT(app[0].ApplicantKey.ToString(), ref dtLiaisoner);
                            string strLiaisoner = "";
                            if (dtLiaisoner.Rows.Count > 0)
                            {
                                strLiaisoner = dtLiaisoner.Rows[0]["LiaisonerName"].ToString() + " " + dtLiaisoner.Rows[0]["Gender"].ToString(); ;
                            }

                            txt_Address.Text = app[0].ContactAddr;
                            txt_LiaisonerName.Text = strLiaisoner;
                            txt_PostalCode.Text = app[0].PostalCode;
                        }

                    }
                    else//複代委託
                    {
                        if (patent.Attorney.HasValue && patent.Attorney != -1)
                        {
                            Public.CAttorney attorney = new Public.CAttorney();

                            attorney.AttorneyKey = patent.Attorney.Value;

                            Public.CAttorney.ReadOne(ref attorney);

                            txt_ApplicantName.Text = attorney.AttorneyFirm;
                            txt_Address.Text = attorney.Addr;
                            //txt_LiaisonerName.Text = attorney.TEL;
                        }
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

                    //外幣收款
                    cb_NT.Checked = fee.NT.HasValue ? fee.NT.Value : false;

                    //規費
                    numericUpDown_GTotall.Value = fee.GTotall.HasValue ? fee.GTotall.Value : 0;

                    decimal OthTotal = fee.OTotall.HasValue ? fee.OTotall.Value : 0;

                    //複代理費用
                    numericUpDown_OAttorneyGovFee.Value = OthTotal;

                    //複代雜費
                    txt_OthFeeName.Text = fee.OthFeeName;
                    numericUpDown_OthFee.Value = fee.OthFee.HasValue ? fee.OthFee.Value : 0;

                    //代收代付自定義
                    txt_CustomizeName.Text = fee.CustomizeName;
                    numericUpDown_CustomizeOthFee.Value = fee.CustomizeOthFee.HasValue ? fee.CustomizeOthFee.Value : 0;

                    //稅額%
                    numericUpDown_TaxPercent.Value = fee.TaxPercent.HasValue ? fee.TaxPercent.Value : 0;

                    //服務費
                    numericUpDown_IAttorneyFee.Value = fee.OtherTotalFee.HasValue ? fee.OtherTotalFee.Value : 0;
                    txt_OtherTotalFeeCustomize1Name.Text = fee.OtherTotalFeeCustomize1Name;
                    txt_OtherTotalFeeCustomize2Name.Text = fee.OtherTotalFeeCustomize2Name;
                    txt_OtherTotalFeeCustomize3Name.Text = fee.OtherTotalFeeCustomize3Name;
                    numericUpDown_OtherTotalFeeCustomize1.Value = fee.OtherTotalFeeCustomize1.HasValue ? fee.OtherTotalFeeCustomize1.Value : 0;
                    numericUpDown_OtherTotalFeeCustomize2.Value = fee.OtherTotalFeeCustomize2.HasValue ? fee.OtherTotalFeeCustomize2.Value : 0;
                    numericUpDown_OtherTotalFeeCustomize3.Value = fee.OtherTotalFeeCustomize3.HasValue ? fee.OtherTotalFeeCustomize3.Value : 0;

                    //預扣稅額
                    numericUpDown_tax.Value = fee.Tax.HasValue ? fee.Tax.Value : 0;

                    //收費合計
                    txt_OtherTotalFeeInSide.Text = fee.OtherTotalFeeInSide.HasValue ? fee.OtherTotalFeeInSide.Value.ToString("#,##0.##") : "0";

                    //未含稅額
                    txt_OtherTotalFeeInSideTax.Text = fee.OtherTotalFeeInSideTax.HasValue ? fee.OtherTotalFeeInSideTax.Value.ToString("#,##0.##") : "0";

                    //請款合計
                    txt_Totall.Text = fee.Totall.HasValue ? fee.Totall.Value.ToString("#,##0.##") : "0";

                    //請款合計-幣別
                    txt_TMoney.Text = fee.TMoney.ToString();

                    //總合計
                    numericUpDown_Totall.Value = fee.TotalNT.HasValue ? fee.TotalNT.Value : 0;

                    //入帳公司
                    if (fee.AcountingFirmKey.HasValue)
                    {
                        comboBox_AcountingFirmT.SelectedValue = fee.AcountingFirmKey;
                    }

                    #endregion
                    break;
                case 2:
                    #region 商標
                    Public.CTrademarkManagement Tm = new Public.CTrademarkManagement();
                    Public.CTrademarkManagement.ReadOne(iPatentID, ref Tm);


                    if (Tm.DelegateType == 1)//申請人直接委託
                    {

                        List<Public.CApplicant> app = new List<Public.CApplicant>();
                        Public.CApplicant.ReadList(ref app, "ApplicantKey in(" + iApplicantKey.ToString() + ")");

                        txt_ApplicantName.AutoCompleteCustomSource = ss;

                        txt_ApplicantName.Text = AppNames[0];
                        if (app.Count > 0)
                        {
                            DataTable dtLiaisoner = new DataTable();
                            Public.CApplicantPublicFunction.GetLiaisonerContractTypeT(app[0].ApplicantKey.ToString(), ref dtLiaisoner);
                            string strLiaisoner = "";
                            if (dtLiaisoner.Rows.Count > 0)
                            {
                                strLiaisoner = dtLiaisoner.Rows[0]["LiaisonerName"].ToString() + " " + dtLiaisoner.Rows[0]["Gender"].ToString();
                            }

                            txt_Address.Text = app[0].ContactAddr;
                            txt_LiaisonerName.Text = strLiaisoner;
                        }

                    }
                    else//複代委託
                    {
                        if (Tm.OutsourcingAttorney != -1)
                        {
                            Public.CAttorney attorney = new Public.CAttorney();
                            if (Tm.OutsourcingAttorney.HasValue) {
                                Public.CAttorney.ReadOne(Tm.OutsourcingAttorney.Value, ref attorney);

                                txt_ApplicantName.Text = attorney.AttorneyFirm;
                                txt_Address.Text = attorney.Addr;

                            }
                        }
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

                    //規費
                    numericUpDown_GTotall.Value = TMfee.GTotall.HasValue ? TMfee.GTotall.Value : 0;

                    decimal TmOthTotal = TMfee.OTotall.HasValue ? TMfee.OTotall.Value : 0;

                    //複代理費
                    numericUpDown_OAttorneyGovFee.Value = TmOthTotal;

                    //複代雜費
                    txt_OthFeeName.Text = TMfee.OthFeeName;
                    numericUpDown_OthFee.Value = TMfee.OthFee.HasValue ? TMfee.OthFee.Value : 0;

                    txt_CustomizeName.Text = TMfee.CustomizeName;
                    numericUpDown_CustomizeOthFee.Value = TMfee.CustomizeOthFee.HasValue ? TMfee.CustomizeOthFee.Value : 0;

                    //稅額%
                    numericUpDown_TaxPercent.Value = TMfee.TaxPercent.HasValue ? TMfee.TaxPercent.Value : 0;

                    //服務費
                    numericUpDown_IAttorneyFee.Value = TMfee.OtherTotalFee.HasValue ? TMfee.OtherTotalFee.Value : 0;

                    txt_OtherTotalFeeCustomize1Name.Text = TMfee.OtherTotalFeeCustomize1Name;
                    txt_OtherTotalFeeCustomize2Name.Text = TMfee.OtherTotalFeeCustomize2Name;
                    txt_OtherTotalFeeCustomize3Name.Text = TMfee.OtherTotalFeeCustomize3Name;
                    numericUpDown_OtherTotalFeeCustomize1.Value = TMfee.OtherTotalFeeCustomize1.HasValue ? TMfee.OtherTotalFeeCustomize1.Value : 0;
                    numericUpDown_OtherTotalFeeCustomize2.Value = TMfee.OtherTotalFeeCustomize2.HasValue ? TMfee.OtherTotalFeeCustomize2.Value : 0;
                    numericUpDown_OtherTotalFeeCustomize3.Value = TMfee.OtherTotalFeeCustomize3.HasValue ? TMfee.OtherTotalFeeCustomize3.Value : 0;

                    //預扣稅額
                    numericUpDown_tax.Value = TMfee.Tax.HasValue ? TMfee.Tax.Value : 0;

                    //收費合計
                    txt_OtherTotalFeeInSide.Text = TMfee.OtherTotalFeeInSide.HasValue ? TMfee.OtherTotalFeeInSide.Value.ToString("#,##0.##") : "0";

                    //未含稅額
                    txt_OtherTotalFeeInSideTax.Text = TMfee.OtherTotalFeeInSideTax.HasValue ? TMfee.OtherTotalFeeInSideTax.Value.ToString("#,##0.##") : "0";

                    //請款合計
                    txt_Totall.Text = TMfee.Totall.HasValue ? TMfee.Totall.Value.ToString("#,##0.##") : "0";

                    //請款合計-幣別
                    txt_TMoney.Text = TMfee.TMoney.ToString();

                    //總合計
                    numericUpDown_Totall.Value = TMfee.TotalNT.HasValue ? TMfee.TotalNT.Value : 0;

                    //入帳公司
                    if (TMfee.AcountingFirmKey.HasValue)
                    {
                        comboBox_AcountingFirmT.SelectedValue = TMfee.AcountingFirmKey;
                    }
                    #endregion

                    break;
            }

            FeeTableAdd();
            RefashionData();

        }

        public string GetCountryName(string Country)
        {
            string strSQL = string.Format("select Country from CountryT where CountrySymbol='{0}'", Country);
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
            string strSQL = string.Format("select Kind from KindT where KindSN='{0}'", kind);
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

            ReportParameter ApplicantName = new ReportParameter("Report_ApplicantName", txt_ApplicantName.Text);
            Params.Add(ApplicantName);

            ReportParameter ApplicantPostalCode = new ReportParameter("Report_PostalCode", txt_PostalCode.Text);
            Params.Add(ApplicantPostalCode);

            ReportParameter Addr = new ReportParameter("Report_Addr", txt_Address.Text);
            Params.Add(Addr);

            ReportParameter Phone = new ReportParameter("Report_LiaisonerName", txt_LiaisonerName.Text);
            Params.Add(Phone);

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

            //規費
            ReportParameter Report_txtGovFee = new ReportParameter("Report_txtGovFee", txt_GTotall.Text);
            Params.Add(Report_txtGovFee);

            //複代理費
            ReportParameter Report_txtOAttorneyGovFee = new ReportParameter("Report_txtOAttorneyGovFee", txt_OAttorneyGovFee.Text);
            Params.Add(Report_txtOAttorneyGovFee);

            //複代理費
            ReportParameter Report_txtIAttorneyFee = new ReportParameter("Report_txtIAttorneyFee", txt_IAttorneyFee.Text);
            Params.Add(Report_txtIAttorneyFee);

            //超頁費
            ReportParameter Report_txtOthFee = new ReportParameter("Report_txtOthFee", txt_OtherTotalFeeCustomize1Name.Text);
            Params.Add(Report_txtOthFee);


            //規費
            ReportParameter GovFee = new ReportParameter("Report_GovFee", numericUpDown_GTotall.Value.ToString("#,##0.##"));
            Params.Add(GovFee);

            //複代理費
            ReportParameter OTotall = new ReportParameter("Report_OTotall", numericUpDown_OAttorneyGovFee.Value.ToString("#,##0.##"));
            Params.Add(OTotall);

            //本所服務費
            ReportParameter ITotall = new ReportParameter("Report_ITotall", numericUpDown_IAttorneyFee.Value.ToString("#,##0.##"));
            Params.Add(ITotall);

            //超頁費
            ReportParameter othFee = new ReportParameter("Report_othFee", numericUpDown_OtherTotalFeeCustomize1.Value.ToString("#,##0.##"));
            Params.Add(othFee);


            //稅額
            ReportParameter tax = new ReportParameter("Report_Tax", numericUpDown_TaxPercent.Value.ToString("#,##0.##"));
            Params.Add(tax);


            //付款說明
            ReportParameter PaymentInstructions = new ReportParameter("Report_PaymentInstructions", txt_PaymentInstructions.Text);
            Params.Add(PaymentInstructions);

            //頁尾
            ReportParameter footer = new ReportParameter("ReportParameterFooter", txt_Footer.Text);
            Params.Add(footer);

            //頁尾
            ReportParameter footer1 = new ReportParameter("ReportParameterFooter1", txt_Footer1.Text);
            Params.Add(footer1);

            ReportParameter PracticalityPay1 = new ReportParameter("Report_PracticalityPay1", textBox1.Text);
            Params.Add(PracticalityPay1);

            try
            {
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

                ReportParameter rpLogoPath = new ReportParameter("ReportLogoPath", reportPath);
                Params.Add(rpLogoPath);

                reportViewer1.LocalReport.EnableExternalImages = true;

                this.reportViewer1.LocalReport.SetParameters(Params);

                reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", FeeTable));

                this.reportViewer1.RefreshReport();
            }
            catch (SystemException EX)
            {
                MessageBox.Show(EX.Message);
            }
        }

        private void reportViewer1_ReportRefresh(object sender, CancelEventArgs e)
        {
            FeeTableAdd();
            RefashionData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FeeTableAdd();
            RefashionData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void numericUpDown_GTotall_ValueChanged(object sender, EventArgs e)
        {

            //decimal total= numericUpDown_IAttorneyFee.Value + numericUpDown_OtherTotalFeeCustomize1.Value + numericUpDown_OtherTotalFeeCustomize2.Value + numericUpDown_OtherTotalFeeCustomize3.Value;
            // txt_OtherTotalFeeInSide.Text = total.ToString("#,##0.##");

            // decimal IAttorneyFee = 0;
            // decimal OthFee = 0;
            // decimal OtherTotalFeeCustomize2 = 0;
            // decimal OtherTotalFeeCustomize3 = 0;

            // if (numericUpDown_TaxPercent.Value != 0)
            // {
            //     IAttorneyFee = numericUpDown_IAttorneyFee.Value - numericUpDown_IAttorneyFee.Value * numericUpDown_TaxPercent.Value / 100;
            //     OthFee = numericUpDown_OtherTotalFeeCustomize1.Value - numericUpDown_OtherTotalFeeCustomize1.Value * numericUpDown_TaxPercent.Value / 100;
            //     OtherTotalFeeCustomize2 = numericUpDown_OtherTotalFeeCustomize2.Value - numericUpDown_OtherTotalFeeCustomize2.Value * numericUpDown_TaxPercent.Value / 100;
            //     OtherTotalFeeCustomize3 = numericUpDown_OtherTotalFeeCustomize3.Value - numericUpDown_OtherTotalFeeCustomize3.Value * numericUpDown_TaxPercent.Value / 100;
            // }
            // else {
            //     IAttorneyFee = numericUpDown_IAttorneyFee.Value;
            //     OthFee = numericUpDown_OtherTotalFeeCustomize1.Value;
            //     OtherTotalFeeCustomize2 = numericUpDown_OtherTotalFeeCustomize2.Value;
            //     OtherTotalFeeCustomize3 = numericUpDown_OtherTotalFeeCustomize3.Value;
            // }
            // numericUpDown_Totall.Value = IAttorneyFee + OthFee + OtherTotalFeeCustomize2 + OtherTotalFeeCustomize3+ numericUpDown_GTotall.Value + numericUpDown_OAttorneyGovFee.Value+ numericUpDown_OthFee.Value+ numericUpDown_CustomizeOthFee.Value;

            // Public.DLL dll = new Public.DLL();
            // string strPracticalityPay1 = dll.convertMoneyString(numericUpDown_Totall.Text);
            // textBox1.Text = strPracticalityPay1.Replace("零", " ");
        }

        /// <summary>
        /// 儲存綠字按鈕
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_SaveText_Click(object sender, EventArgs e)
        {
            try
            {
                object obj = new object();

                switch ((int)comboBox_AcountingFirmT.SelectedValue)
                {

                    case 0:
                        string strTextFee = string.Format("{0}§{1}§{2}",

                            txt_PaymentInstructions.Text,
                            txt_Footer.Text,
                            txt_Footer1.Text);

                        Public.CStatueRecordT cs = new Public.CStatueRecordT();
                        Public.CStatueRecordT.ReadOne("StatusName='FeeReport' ", ref cs);

                        cs.Value = strTextFee;
                        cs.Update();

                        MessageBox.Show(string.Format("儲存靜態文字成功 : {0} , {1} ",
                         "付款說明", "頁尾"));
                        break;
                    default:
                        int iKey = (int)comboBox_AcountingFirmT.SelectedValue;
                        Public.CAcountingFirmT firm = new Public.CAcountingFirmT();
                        Public.CAcountingFirmT.ReadOne(iKey, ref firm);
                        firm.Fee_PaymentInstructions = txt_PaymentInstructions.Text;
                        firm.Fee_Footer = txt_Footer.Text;
                        firm.Fee_Footer1 = txt_Footer1.Text;
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
            catch (SystemException EX)
            {
                MessageBox.Show("儲存失敗:" + EX.Message);
            }
        }
    

        private void numericUpDown_Totall_ValueChanged(object sender, EventArgs e)
        {
            Public.DLL dll = new Public.DLL();
            string strPracticalityPay1 = dll.convertMoneyString(numericUpDown_Totall.Value.ToString("0.##"));
            textBox1.Text = strPracticalityPay1.Replace("零", " ");
        }

        /// <summary>
        /// 收費合計
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txt_OtherTotalFeeInSide_TextChanged(object sender, EventArgs e)
        {
            //decimal decOtherTotalFeeInSide;
            //bool bOtherTotalFeeInSide = decimal.TryParse(txt_OtherTotalFeeInSide.Text, out decOtherTotalFeeInSide);

            //if (bOtherTotalFeeInSide)
            //{
            //    txt_OtherTotalFeeInSideTax.Text = (decOtherTotalFeeInSide - numericUpDown_tax.Value).ToString("#,##0");
            //}
            //else
            //{
            //    txt_OtherTotalFeeInSideTax.Text = "0";
            //}
        }

        private void numericUpDown_TaxPercent_ValueChanged(object sender, EventArgs e)
        {
            //decimal decOtherTotalFeeInSide;
            //bool bOtherTotalFeeInSide = decimal.TryParse(txt_OtherTotalFeeInSide.Text, out decOtherTotalFeeInSide);
            //if (bOtherTotalFeeInSide)
            //{
            //    numericUpDown_tax.Value = (numericUpDown_TaxPercent.Value / 100) * decOtherTotalFeeInSide;
            //}
            //else
            //{
            //    numericUpDown_tax.Value = 0;
            //}
        }

        private void comboBox_AcountingFirmT_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_AcountingFirmT.SelectedValue != null)
            {
                switch ((int)comboBox_AcountingFirmT.SelectedValue)
                {
                    case 0:
                        #region 取得靜態文字預設值
                        Public.CStatueRecordT cs = new Public.CStatueRecordT();
                        Public.CStatueRecordT.ReadOne("StatusName='FeeReport' ", ref cs);
                        if (cs.Value != null && cs.Value.Length > 0)
                        {
                            string[] str = cs.Value.Split('§');
                            if (str.Length == 3)
                            {
                                txt_PaymentInstructions.Text = str[0];
                                txt_Footer.Text = str[1];
                                txt_Footer1.Text = str[2];
                            }
                        }
                        #endregion
                        break;
                    default:
                        int iKey = (int)comboBox_AcountingFirmT.SelectedValue;
                        Public.CAcountingFirmT firm = new Public.CAcountingFirmT();
                        Public.CAcountingFirmT.ReadOne(iKey, ref firm);
                        txt_PaymentInstructions.Text = firm.Fee_PaymentInstructions;
                        txt_Footer.Text = firm.Fee_Footer;
                        txt_Footer1.Text = firm.Fee_Footer1;
                        break;
                }
            }
        }



    }
}
