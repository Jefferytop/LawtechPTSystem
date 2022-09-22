using System;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LawtechPTSystem.SubFrom
{
    /// <summary>
    /// (X)舊版不要使用 應收應付總表
    /// </summary>
    public partial class AccountingCombin : Form
    {
        public AccountingCombin()
        {
            InitializeComponent();
            dgViewMF.AutoGenerateColumns = false;
            GridView_Fee.AutoGenerateColumns = false;
            GridView_Payment.AutoGenerateColumns = false;
        }

        BindingSource bSource_Control;
        BindingSource bSource_Fee;
        BindingSource bSource_Payment;


        private int iWorkerID = -1;
        /// <summary>
        /// 登入者ID
        /// </summary>
        public int WorkerID
        {
            get { return iWorkerID; }
            set { iWorkerID = value; }
        }


        private int iOfficeRole = -1;
        /// <summary>
        /// 權限 0.最高權限 1.指定權限 2.專利  3.商標 4.會計經理
        /// </summary>
        public int OfficeRole
        {
            get { return iOfficeRole; }
            set { iOfficeRole = value; }
        }


        #region AccountingCombin_Load  AccountingCombin_FormClosed
        private void AccountingCombin_Load(object sender, EventArgs e)
        {
            Public.PublicForm Forms = new Public.PublicForm();
            Forms.AccountingCombin = this;

            this.accountingCombinSearchTradenarkTableAdapter.Fill(this.dataSet_Accounting.AccountingCombinSearchTradenark);
           

            this.accountingCombinSearchPatentTableAdapter.Fill(this.dataSet_Accounting.AccountingCombinSearchPatent);
            
            this.accountingCombinSearchDateTableAdapter.Fill(this.dataSet_Accounting.AccountingCombinSearchDate);
           

            //登入者
            iWorkerID = Properties.Settings.Default.WorkerKEY;
           
            //角色的權限
            OfficeRole = Properties.Settings.Default.OfficeRole;

            bSource_Control = new BindingSource();
            dgViewMF.DataSource = bSource_Control;
            bindingNavigator1.BindingSource = bSource_Control;

            bSource_Fee = new BindingSource();
            GridView_Fee.DataSource = bSource_Fee;
            bindingNavigator_Fee.BindingSource = bSource_Fee;

            bSource_Payment = new BindingSource();
            GridView_Payment.DataSource = bSource_Payment;
            bindingNavigator_Payment.BindingSource = bSource_Payment;

            //but_ShowDetail_Click(null,null);
            but_Search_Click(null,null);
        }

        private void AccountingCombin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Public.PublicForm Forms = new Public.PublicForm();
            Forms.AccountingCombin = null;
        }
        #endregion

        #region but_Search_Click
        private void but_Search_Click(object sender, EventArgs e)
        {
            but_Search.Enabled = false;
            string times = "";
            string sfilter = "";           
            string strFilter1 = "";
           

            if (comboBox_SelectValue.Text == "" && comboBox_SelectValue1.Text == "" && maskedTextBox_S.Text == "    /  /" && maskedTextBox_D.Text == "    /  /")
            {
                sfilter = "";
            }
            else
            {
                DateTime dtS = new DateTime(), dtE = new DateTime();
                if (maskedTextBox_S.Text != "    /  /")
                {
                    bool IsS = DateTime.TryParse(maskedTextBox_S.Text, out dtS);
                    if (!IsS)
                    {
                        MessageBox.Show("日期格式錯誤 <<" + maskedTextBox_S.Text + ">>");
                        return;
                    }
                }

                if (maskedTextBox_D.Text != "    /  /")
                {
                    bool IsE = DateTime.TryParse(maskedTextBox_D.Text, out dtE);
                    if (!IsE)
                    {
                        MessageBox.Show("日期格式錯誤 <<" + maskedTextBox_D.Text + ">>");
                        return;
                    }
                }

                if (maskedTextBox_S.Text != "    /  /" && maskedTextBox_D.Text != "    /  /")
                {

                    if (dtS > dtE)
                    {
                        maskedTextBox_S.Text = dtE.ToString("yyyy/MM/dd");
                        maskedTextBox_D.Text = dtS.ToString("yyyy/MM/dd");
                    }
                }


                string strDateMode = comboBox_DateMode.SelectedValue.ToString();

                if (maskedTextBox_S.Text != "    /  /" && maskedTextBox_D.Text == "    /  /")
                {
                    times += " " + strDateMode + ">='" + maskedTextBox_S.Text + "'";
                }
                else if (maskedTextBox_S.Text == "    /  /" && maskedTextBox_D.Text != "    /  /")
                {
                    times += " " + strDateMode + "<='" + maskedTextBox_D.Text + "'";
                }
                else if (maskedTextBox_S.Text != "    /  /" && maskedTextBox_D.Text != "    /  /")
                {
                    times += " (" + strDateMode + " >= '" + maskedTextBox_S.Text + "' and " + strDateMode + "<= '" + maskedTextBox_D.Text + "')";
                }

                #region Select 1
                if (comboBox_SelectValue.Text.Trim() != "" || comboBox_SelectValue.SelectedValue != null)
                {
                    if (radioButton_Patent.Checked)//專利
                    {
                        switch (comboBox_Select.SelectedValue.ToString())
                        {
                            case "PatentFeeT.PPP":
                            case "PatentManagementT.PatentNo":
                                sfilter = comboBox_Select.SelectedValue.ToString() + " like '%" + comboBox_SelectValue.Text + "%' ";
                                break;
                            case "CustomerName":
                                if (comboBox_SelectValue.SelectedValue != null)
                                {
                                    sfilter = "(CASE PatentManagementT.DelegateType WHEN 1 THEN ApplicantNames WHEN 2 THEN (select AttorneyT.AttorneyFirm from AttorneyT where AttorneyT.AttorneyKey=PatentManagementT.MainCustomer ) END) ='" + comboBox_SelectValue.Text + "'";
                                }
                                else
                                {
                                    comboBox_SelectValue.Text = "";
                                }

                                break;
                            case "PatentManagementT.Kind":
                            case "PatentManagementT.CountrySymbol":
                                if (comboBox_SelectValue.SelectedValue != null)
                                {
                                    sfilter = comboBox_Select.SelectedValue.ToString() + " ='" + comboBox_SelectValue.SelectedValue.ToString() + "'";
                                }
                                else
                                {
                                    comboBox_SelectValue.Text = "";
                                }
                                break;
                            case "PatentManagementT.Nature":                          
                                if (comboBox_SelectValue.SelectedValue != null)
                                {
                                    sfilter = comboBox_Select.SelectedValue.ToString() + " =" + comboBox_SelectValue.SelectedValue.ToString();
                                }
                                else
                                {
                                    comboBox_SelectValue.Text = "";
                                }
                                break;
                        }
                    }
                    else//商標
                    {
                        switch (comboBox_Select.SelectedValue.ToString())
                        {
                            case "PPP":
                            case "TrademarkNo":
                                sfilter = comboBox_Select.SelectedValue.ToString() + " like '%" + comboBox_SelectValue.Text + "%' ";
                                break;
                            case "CustomerName":
                                if (comboBox_SelectValue.SelectedValue != null)
                                {
                                    sfilter = "(CASE PatentManagementT.DelegateType WHEN 1 THEN ApplicantNames WHEN 2 THEN (select AttorneyT.AttorneyFirm from AttorneyT where AttorneyT.AttorneyKey=PatentManagementT.MainCustomer ) END) ='" + comboBox_SelectValue.Text + "'";
                                }
                                else
                                {
                                    comboBox_SelectValue.Text = "";
                                }

                                break;
                            case "StyleName":
                            case "TMTypeName":
                            case "CountrySymbol":
                                if (comboBox_SelectValue.SelectedValue != null)
                                {
                                    sfilter = comboBox_Select.SelectedValue.ToString() + " ='" + comboBox_SelectValue.SelectedValue.ToString() + "'";
                                }
                                else
                                {
                                    comboBox_SelectValue.Text = "";
                                }
                                break;
                         
                        }
                    }
                }
                #endregion

                #region Select 2

                if (comboBox_SelectValue1.Text.Trim() != "" || comboBox_SelectValue1.SelectedValue != null)
                {
                    if (radioButton_Patent.Checked)//專利
                    {
                        switch (comboBox_Select.SelectedValue.ToString())
                        {
                            case "PatentFeeT.PPP":
                            case "PatentManagementT.PatentNo":
                                strFilter1 = comboBox_Select1.SelectedValue.ToString() + " like '%" + comboBox_SelectValue1.Text + "%' ";
                                break;
                            case "CustomerName":
                                if (comboBox_SelectValue1.SelectedValue != null)
                                {
                                    strFilter1 = "(CASE PatentManagementT.DelegateType WHEN 1 THEN ApplicantNames WHEN 2 THEN (select AttorneyT.AttorneyFirm from AttorneyT where AttorneyT.AttorneyKey=PatentManagementT.MainCustomer ) END) ='" + comboBox_SelectValue.Text + "'";
                                }
                                else
                                {
                                    comboBox_SelectValue1.Text = "";
                                }

                                break;
                            case "PatentManagementT.Kind":
                            case "PatentManagementT.CountrySymbol":
                                if (comboBox_SelectValue1.SelectedValue != null)
                                {
                                    strFilter1 = comboBox_Select1.SelectedValue.ToString() + " ='" + comboBox_SelectValue1.SelectedValue.ToString() + "'";
                                }
                                else
                                {
                                    comboBox_SelectValue1.Text = "";
                                }
                                break;
                            case "PatentManagementT.Nature":
                            
                                if (comboBox_SelectValue1.SelectedValue != null)
                                {
                                    strFilter1 = comboBox_Select1.SelectedValue.ToString() + " =" + comboBox_SelectValue1.SelectedValue.ToString();
                                }
                                else
                                {
                                    comboBox_SelectValue1.Text = "";
                                }
                                break;
                        }
                    }
                    else//商標
                    {
                        switch (comboBox_Select.SelectedValue.ToString())
                        {
                            case "PPP":
                            case "TrademarkNo":
                                strFilter1 = comboBox_Select.SelectedValue.ToString() + " like '%" + comboBox_SelectValue.Text + "%' ";
                                break;
                            case "CustomerName":
                                if (comboBox_SelectValue.SelectedValue != null)
                                {
                                    strFilter1 = "(CASE TrademarkManagementT.DelegateType WHEN 1 THEN ApplicantNames WHEN 2 THEN (select AttorneyT.AttorneyFirm from AttorneyT where AttorneyT.AttorneyKey=TrademarkManagementT.MainCustomer ) END) ='" + comboBox_SelectValue.Text + "'";
                                }
                                else
                                {
                                    comboBox_SelectValue.Text = "";
                                }

                                break;
                            case "StyleName":
                            case "TMTypeName":
                            case "CountrySymbol":
                                if (comboBox_SelectValue.SelectedValue != null)
                                {
                                    strFilter1 = comboBox_Select.SelectedValue.ToString() + " ='" + comboBox_SelectValue.SelectedValue.ToString() + "'";
                                }
                                else
                                {
                                    comboBox_SelectValue.Text = "";
                                }
                                break;

                        }
                    }
                }
                #endregion
            }

            string FullFilter = "";
            if (strFilter1 != "" && sfilter != "")
            {
                string AndOr = "";
                if (rb_and.Checked)
                {
                    AndOr = " and ";
                    FullFilter = strFilter1 + AndOr + sfilter;
                }
                else
                {
                    AndOr = " or ";
                    FullFilter = "(" + strFilter1 + AndOr + sfilter + ")";
                }

            }
            else if (strFilter1 == "" && sfilter == "")
            {
                FullFilter = "";
            }
            else
            {
                if (strFilter1 != "")
                {
                    FullFilter = strFilter1;
                }
                else
                {
                    FullFilter = sfilter;
                }
            }

            string[] sWhere = { times,  FullFilter };

            StringBuilder FullWhere = new StringBuilder();
            for (int iArray = 0; iArray < sWhere.Length; iArray++)
            {
                if (sWhere[iArray] != "")
                {
                    if (FullWhere.Length > 0)
                    {
                        FullWhere.Append(" and ");
                    }
                    FullWhere.Append(sWhere[iArray]);
                }
            }


            if (radioButton_Patent.Checked)
            {
                DataTable dt_Patent = GetPatent(FullWhere.ToString());
                bSource_Control.DataSource = dt_Patent;
            }
            else
            {
                DataTable dt_Patent = GetTrademark(FullWhere.ToString());
                bSource_Control.DataSource = dt_Patent;
            }

            but_Search.Enabled = true;
        }
        #endregion

        #region GetFeeEvent 取得專利應收應付的資料
        /// <summary>
        /// 取得專利應收應付的資料
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public System.Data.DataTable GetPatent(string strWhere)
        {

           // strWhere = strWhere.Replace("FinishDate is not null", "PatentFeeT.Pay=1").Replace("FinishDate is null", " (PatentFeeT.Pay<>1) ").Replace("EventNo", "PatentManagementT.PatentNo");
            
            if (strWhere.Trim() != "")
            {
                strWhere = " Where " + strWhere;
            }

            string strPatentFeeSQL = string.Format(
                                    @"SELECT DISTINCT T1.PPP, PatentManagementT.PatentID, PatentManagementT.PatentNo, PatentManagementT.ApplicantNames, PatentManagementT.Title, 'Pat' as CaseTypeMode,
                                                          SUM(PatentFeeT_1.PracticalityPay) AS SUM_PracticalityPay, SUM(PatentPaymentT.ActuallyPay) AS PaymentTotall, 
                                                          CASE PatentManagementT.DelegateType WHEN 1 THEN PatentManagementT.ApplicantNames WHEN 2 THEN
                                                              (SELECT     AttorneyT.AttorneyFirm
                                                                FROM          AttorneyT
                                                                WHERE      AttorneyKey = PatentManagementT.MainCustomer) END AS CustomerName, PatentManagementT.DelegateType, KindT.Kind, 
                                                          CountryT.Country AS CountryName, PATFeatureT.FeatureName, PatentManagementT.ApplicantKeys, PatentManagementT.PayYear, 
                                                          PatentManagementT.DueDate, PatentManagementT.RegisterDate, PatentManagementT.CertifyNo, PatentManagementT.GetDate, 
                                                          PatentManagementT.RenewTo, PatentManagementT.MainCustomerRefNo, PatentManagementT.CountrySymbol, 
                                                          ISNULL( SUM(PatentFeeT_1.PracticalityPay),0) - ISNULL(SUM(PatentPaymentT.ActuallyPay), 0)  AS Profit
                                    FROM         KindT RIGHT OUTER JOIN
                                                          PatentPaymentT RIGHT OUTER JOIN
                                                          PatentManagementT RIGHT OUTER JOIN
                                                              (SELECT DISTINCT PPP, PatentID
                                                                FROM          PatentFeeT
                                                                WHERE      (PPP <> '') AND (PPP IS NOT NULL)
                                                                UNION
                                                                SELECT DISTINCT BillingNo AS PPP, PatentID
                                                                FROM         PatentPaymentT AS PatentPaymentT_1
                                                                WHERE     (BillingNo <> '') AND (BillingNo IS NOT NULL)) AS T1 ON PatentManagementT.PatentID = T1.PatentID ON 
                                                          PatentPaymentT.BillingNo = T1.PPP LEFT OUTER JOIN
                                                          PatentFeeT AS PatentFeeT_1 ON T1.PPP = PatentFeeT_1.PPP LEFT OUTER JOIN
                                                          PATFeatureT ON PatentManagementT.Nature = PATFeatureT.FeatureID LEFT OUTER JOIN
                                                          CountryT ON PatentManagementT.CountrySymbol = CountryT.CountrySymbol ON KindT.KindSN = PatentManagementT.Kind
                                                          {0}
                                    GROUP BY T1.PPP, PatentManagementT.PatentID, PatentManagementT.PatentNo, PatentManagementT.ApplicantNames, PatentManagementT.Title, 
                                                          PatentManagementT.MainCustomer, PatentManagementT.DelegateType, KindT.Kind, CountryT.Country, PATFeatureT.FeatureName, 
                                                          PatentManagementT.ApplicantKeys, PatentManagementT.PayYear, PatentManagementT.DueDate, PatentManagementT.RegisterDate, 
                                                          PatentManagementT.CertifyNo, PatentManagementT.GetDate, PatentManagementT.RenewTo, PatentManagementT.MainCustomerRefNo, 
                                                          PatentManagementT.CountrySymbol   order by  PatentManagementT.PatentNo,T1.PPP ;

                                                SELECT SUM(PatentFeeT_1.PracticalityPay) AS SUM_PracticalityPay, SUM(PatentPaymentT.ActuallyPay) AS PaymentTotall,
                                                       ISNULL( SUM(PatentFeeT_1.PracticalityPay),0) - ISNULL(SUM(PatentPaymentT.ActuallyPay), 0)  AS Profit
                                                FROM         KindT RIGHT OUTER JOIN
                                                          PatentPaymentT RIGHT OUTER JOIN
                                                          PatentManagementT RIGHT OUTER JOIN
                                                              (SELECT DISTINCT PPP, PatentID
                                                                FROM          PatentFeeT
                                                                WHERE      (PPP <> '') AND (PPP IS NOT NULL)
                                                                UNION
                                                                SELECT DISTINCT BillingNo AS PPP, PatentID
                                                                FROM         PatentPaymentT AS PatentPaymentT_1
                                                                WHERE     (BillingNo <> '') AND (BillingNo IS NOT NULL)) AS T1 ON PatentManagementT.PatentID = T1.PatentID ON 
                                                          PatentPaymentT.BillingNo = T1.PPP LEFT OUTER JOIN
                                                          PatentFeeT AS PatentFeeT_1 ON T1.PPP = PatentFeeT_1.PPP LEFT OUTER JOIN
                                                          PATFeatureT ON PatentManagementT.Nature = PATFeatureT.FeatureID LEFT OUTER JOIN
                                                          CountryT ON PatentManagementT.CountrySymbol = CountryT.CountrySymbol ON KindT.KindSN = PatentManagementT.Kind  {0}
                                  
                                ", strWhere);

            Public.DLL dll = new Public.DLL();
            System.Data.DataSet dsFeeEvent = new System.Data.DataSet();
            dsFeeEvent = dll.SqlDataAdapterDataSet(strPatentFeeSQL);

            if (dsFeeEvent.Tables[1].Rows.Count > 0)
            {
                toolStripLabel_FeeTotal.Text = dsFeeEvent.Tables[1].Rows[0]["SUM_PracticalityPay"] != DBNull.Value ? ((decimal)dsFeeEvent.Tables[1].Rows[0]["SUM_PracticalityPay"]).ToString("#,##0.##") : "0";
                toolStripLabel_PaymentTotal.Text = dsFeeEvent.Tables[1].Rows[0]["PaymentTotall"] != DBNull.Value ? ((decimal)dsFeeEvent.Tables[1].Rows[0]["PaymentTotall"]).ToString("#,##0.##") : "0";
                toolStripLabel_ProfitTotal.Text = dsFeeEvent.Tables[1].Rows[0]["Profit"] != DBNull.Value ? ((decimal)dsFeeEvent.Tables[1].Rows[0]["Profit"]).ToString("#,##0.##") : "0";
            }
            return dsFeeEvent.Tables[0];
        }
        #endregion

        #region GetFeeEvent 取得商標應收應付的資料
        /// <summary>
        /// 取得商標應收應付的資料
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public System.Data.DataTable GetTrademark(string strWhere)
        {

            //strWhere = strWhere.Replace("FinishDate is not null", "PatentFeeT.Pay=1").Replace("FinishDate is null", " (PatentFeeT.Pay<>1) ").Replace("EventNo", "PatentManagementT.PatentNo");
            if (strWhere.Trim() != "")
            {
                strWhere = " Where " + strWhere;
            }
            string strTmFeeSQL = string.Format(
                                    @"SELECT DISTINCT 
                                               T1.PPP, TrademarkManagementT.TrademarkID AS PatentID, TrademarkManagementT.TrademarkNo AS PatentNo, 
                                                                  TrademarkManagementT.TrademarkName AS Title, TrademarkManagementT.ApplicantNames, 'Tm' AS CaseTypeMode, 
                                                                  SUM(TrademarkFeeT_1.PracticalityPay) AS SUM_PracticalityPay, SUM(TrademarkPaymentT.ActuallyPay) 
                                                                  AS PaymentTotall, CASE TrademarkManagementT.DelegateType WHEN 1 THEN TrademarkManagementT.ApplicantNames WHEN 2 THEN
                                                                      (SELECT     AttorneyT.AttorneyFirm
                                                                        FROM          AttorneyT
                                                                        WHERE      AttorneyKey = TrademarkManagementT.MainCustomer) END AS CustomerName, TrademarkManagementT.DelegateType, 
                                                                  CountryT.Country AS CountryName, TrademarkManagementT.ApplicantKeys, ISNULL(SUM(TrademarkFeeT_1.PracticalityPay), 0) 
                                                                  - ISNULL(SUM(TrademarkPaymentT.ActuallyPay), 0) AS Profit, TrademarkManagementT.StyleName, 
                                                                  TrademarkManagementT.TMTypeName
                                            FROM         TrademarkPaymentT RIGHT OUTER JOIN
                                                                  TrademarkManagementT RIGHT OUTER JOIN
                                                                      (SELECT DISTINCT PPP, TrademarkID
                                                                        FROM          TrademarkFeeT
                                                                        WHERE      (PPP <> '') AND (PPP IS NOT NULL)
                                                                        UNION
                                                                        SELECT DISTINCT BillingNo AS PPP, TrademarkID
                                                                        FROM         TrademarkPaymentT AS TrademarkPaymentT_1
                                                                        WHERE     (BillingNo <> '') AND (BillingNo IS NOT NULL)) AS T1 ON TrademarkManagementT.TrademarkID = T1.TrademarkID ON 
                                                                  TrademarkPaymentT.BillingNo = T1.PPP LEFT OUTER JOIN
                                                                  TrademarkFeeT AS TrademarkFeeT_1 ON T1.PPP = TrademarkFeeT_1.PPP LEFT OUTER JOIN
                                                                  CountryT ON TrademarkManagementT.CountrySymbol = CountryT.CountrySymbol
                                            GROUP BY T1.PPP, TrademarkManagementT.TrademarkID, TrademarkManagementT.TrademarkNo, TrademarkManagementT.ApplicantNames, 
                                                                  TrademarkManagementT.MainCustomer, TrademarkManagementT.DelegateType, CountryT.Country, TrademarkManagementT.ApplicantKeys, 
                                                                  TrademarkManagementT.MainCustomerRefNo, TrademarkManagementT.CountrySymbol, TrademarkManagementT.TrademarkName, 
                                                                  TrademarkManagementT.StyleName, TrademarkManagementT.TMTypeName ;
                                                                                            

                                                SELECT SUM(TrademarkFeeT_1.PracticalityPay) AS SUM_PracticalityPay, SUM(TrademarkPaymentT.ActuallyPay) 
                                                                  AS PaymentTotall,
                                                       ISNULL( SUM(TrademarkFeeT_1.PracticalityPay),0) - ISNULL(SUM(TrademarkPaymentT.ActuallyPay), 0)  AS Profit
                                                FROM         TrademarkPaymentT RIGHT OUTER JOIN
                                                                  TrademarkManagementT RIGHT OUTER JOIN
                                                                      (SELECT DISTINCT PPP, TrademarkID
                                                                        FROM          TrademarkFeeT
                                                                        WHERE      (PPP <> '') AND (PPP IS NOT NULL)
                                                                        UNION
                                                                        SELECT DISTINCT BillingNo AS PPP, TrademarkID
                                                                        FROM         TrademarkPaymentT AS TrademarkPaymentT_1
                                                                        WHERE     (BillingNo <> '') AND (BillingNo IS NOT NULL)) AS T1 ON TrademarkManagementT.TrademarkID = T1.TrademarkID ON 
                                                                  TrademarkPaymentT.BillingNo = T1.PPP LEFT OUTER JOIN
                                                                  TrademarkFeeT AS TrademarkFeeT_1 ON T1.PPP = TrademarkFeeT_1.PPP LEFT OUTER JOIN
                                                                  CountryT ON TrademarkManagementT.CountrySymbol = CountryT.CountrySymbol                                 
                                ", strWhere);

            string strTmControversy = @"SELECT DISTINCT 
                                      T1.PPP, TrademarkControversyManagementT.TrademarkControversyID AS PatentID, TrademarkControversyManagementT.TrademarkNo AS PatentNo, 
                                      TrademarkControversyManagementT.TrademarkName AS Title, TrademarkControversyManagementT.ApplicantNames, 'CO' AS CaseTypeMode, 
                                      SUM(TrademarkControversyFeeT_1.PracticalityPay) AS SUM_PracticalityPay, SUM(TrademarkControversyPaymentT.ExchangeRate * TrademarkControversyPaymentT.Totall) 
                                      AS PaymentTotall, CASE TrademarkControversyManagementT.DelegateType WHEN 1 THEN TrademarkControversyManagementT.ApplicantNames WHEN 2 THEN
                                          (SELECT     AttorneyT.AttorneyFirm
                                            FROM          AttorneyT
                                            WHERE      AttorneyKey = TrademarkControversyManagementT.MainCustomer) END AS CustomerName, TrademarkControversyManagementT.DelegateType, 
                                      CountryT.Country AS CountryName, TrademarkControversyManagementT.ApplicantKeys, ISNULL(SUM(TrademarkControversyFeeT_1.PracticalityPay), 0) 
                                      - ISNULL(SUM(TrademarkControversyPaymentT.ExchangeRate * TrademarkControversyPaymentT.Totall), 0) AS Profit, TrademarkControversyManagementT.StyleName, 
                                      TrademarkControversyManagementT.TMTypeName
                                FROM         TrademarkControversyPaymentT RIGHT OUTER JOIN
                                      TrademarkControversyManagementT RIGHT OUTER JOIN
                                          (SELECT DISTINCT PPP, TrademarkControversyID
                                            FROM          TrademarkControversyFeeT
                                            WHERE      (PPP <> '') AND (PPP IS NOT NULL)
                                            UNION
                                            SELECT DISTINCT BillingNo AS PPP, TrademarkControversyID
                                            FROM         TrademarkControversyPaymentT AS TrademarkControversyPaymentT_1
                                            WHERE     (BillingNo <> '') AND (BillingNo IS NOT NULL)) AS T1 ON TrademarkControversyManagementT.TrademarkControversyID = T1.TrademarkControversyID ON 
                                      TrademarkControversyPaymentT.BillingNo = T1.PPP LEFT OUTER JOIN
                                      TrademarkControversyFeeT AS TrademarkControversyFeeT_1 ON T1.PPP = TrademarkControversyFeeT_1.PPP LEFT OUTER JOIN
                                      CountryT ON TrademarkControversyManagementT.CountrySymbol = CountryT.CountrySymbol
                                 GROUP BY T1.PPP, TrademarkControversyManagementT.TrademarkControversyID, TrademarkControversyManagementT.TrademarkNo, TrademarkControversyManagementT.ApplicantNames, 
                                      TrademarkControversyManagementT.MainCustomer, TrademarkControversyManagementT.DelegateType, CountryT.Country, TrademarkControversyManagementT.ApplicantKeys, 
                                      TrademarkControversyManagementT.MainCustomerRefNo, TrademarkControversyManagementT.CountrySymbol, TrademarkControversyManagementT.TrademarkName, 
                                      TrademarkControversyManagementT.StyleName, TrademarkControversyManagementT.TMTypeName; 

                                 SELECT SUM(TrademarkControversyFeeT_1.PracticalityPay) AS SUM_PracticalityPay, SUM(TrademarkControversyPaymentT.ExchangeRate * TrademarkControversyPaymentT.Totall)  AS PaymentTotall,
                                        ISNULL( SUM(TrademarkControversyFeeT_1.PracticalityPay),0) - ISNULL( SUM(TrademarkControversyPaymentT.ExchangeRate * TrademarkControversyPaymentT.Totall), 0)  AS Profit
                                FROM   TrademarkControversyPaymentT RIGHT OUTER JOIN
                                      TrademarkControversyManagementT RIGHT OUTER JOIN
                                          (SELECT DISTINCT PPP, TrademarkControversyID
                                            FROM          TrademarkControversyFeeT
                                            WHERE      (PPP <> '') AND (PPP IS NOT NULL)
                                            UNION
                                            SELECT DISTINCT BillingNo AS PPP, TrademarkControversyID
                                            FROM         TrademarkControversyPaymentT AS TrademarkControversyPaymentT_1
                                            WHERE     (BillingNo <> '') AND (BillingNo IS NOT NULL)) AS T1 ON TrademarkControversyManagementT.TrademarkControversyID = T1.TrademarkControversyID ON 
                                      TrademarkControversyPaymentT.BillingNo = T1.PPP LEFT OUTER JOIN
                                      TrademarkControversyFeeT AS TrademarkControversyFeeT_1 ON T1.PPP = TrademarkControversyFeeT_1.PPP LEFT OUTER JOIN
                                      CountryT ON TrademarkControversyManagementT.CountrySymbol = CountryT.CountrySymbol
                                 GROUP BY T1.PPP, TrademarkControversyManagementT.TrademarkControversyID, TrademarkControversyManagementT.TrademarkNo, TrademarkControversyManagementT.ApplicantNames, 
                                      TrademarkControversyManagementT.MainCustomer, TrademarkControversyManagementT.DelegateType, CountryT.Country, TrademarkControversyManagementT.ApplicantKeys, 
                                      TrademarkControversyManagementT.MainCustomerRefNo, TrademarkControversyManagementT.CountrySymbol, TrademarkControversyManagementT.TrademarkName, 
                                      TrademarkControversyManagementT.StyleName, TrademarkControversyManagementT.TMTypeName";

            Public.DLL dll = new Public.DLL();

            System.Data.DataSet dsFeeEvent = new System.Data.DataSet();
            dsFeeEvent = dll.SqlDataAdapterDataSet(strTmFeeSQL);

            System.Data.DataSet dsControversyEvent = new System.Data.DataSet();
            dsControversyEvent = dll.SqlDataAdapterDataSet(strTmControversy);

            decimal FeeTotal = 0, PaymentTotal = 0, ProfitTotal = 0, ControversyFeeTotal = 0, ControversyPaymentTotal = 0, ControversyProfitTotal = 0;
            if (dsFeeEvent.Tables[1].Rows.Count > 0)
            {
                FeeTotal = dsFeeEvent.Tables[1].Rows[0]["SUM_PracticalityPay"] != DBNull.Value ? (decimal)dsFeeEvent.Tables[1].Rows[0]["SUM_PracticalityPay"] : 0;
                PaymentTotal = dsFeeEvent.Tables[1].Rows[0]["PaymentTotall"] != DBNull.Value ? (decimal)dsFeeEvent.Tables[1].Rows[0]["PaymentTotall"] : 0;
                ProfitTotal = dsFeeEvent.Tables[1].Rows[0]["Profit"] != DBNull.Value ? (decimal)dsFeeEvent.Tables[1].Rows[0]["Profit"] : 0;
            }

            if (dsControversyEvent.Tables[1].Rows.Count > 0)
            {
                ControversyFeeTotal = dsControversyEvent.Tables[1].Rows[0]["SUM_PracticalityPay"] != DBNull.Value ? (decimal)dsControversyEvent.Tables[1].Rows[0]["SUM_PracticalityPay"] : 0;
                ControversyPaymentTotal = dsControversyEvent.Tables[1].Rows[0]["PaymentTotall"] != DBNull.Value ? (decimal)dsControversyEvent.Tables[1].Rows[0]["PaymentTotall"] : 0;
                ControversyProfitTotal = dsControversyEvent.Tables[1].Rows[0]["Profit"] != DBNull.Value ? (decimal)dsControversyEvent.Tables[1].Rows[0]["Profit"] : 0;
            }

            toolStripLabel_FeeTotal.Text = (FeeTotal + ControversyFeeTotal).ToString("#,##0.##");
            toolStripLabel_PaymentTotal.Text = (PaymentTotal + ControversyPaymentTotal).ToString("#,##0.##");
            toolStripLabel_ProfitTotal.Text = (ProfitTotal + ControversyProfitTotal).ToString("#,##0.##");

            dsFeeEvent.Tables[0].Merge(dsControversyEvent.Tables[0]);

            return dsFeeEvent.Tables[0];
        }
        #endregion

        #region but_Excel_Click
        private void but_Excel_Click(object sender, EventArgs e)
        {
            try
            {
                Public.DLL dll = new Public.DLL();

                Task task = dll.WriteToCSV(dgViewMF);
            }
            catch
            {
                MessageBox.Show("匯出Excel失敗:匯出過程發生異常被終止");
            }
        }
        #endregion

        #region but_Close_Click
        private void but_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region but_ShowDetail_Click
        private void but_ShowDetail_Click(object sender, EventArgs e)
        {
            if (!splitContainer1.Panel2Collapsed)
            {
                but_ShowDetail.Text = "開啟應收應付明細(Alt+E)";

                splitContainer1.Panel2Collapsed = true;
            }
            else
            {
                but_ShowDetail.Text = "關閉應收應付明細(Alt+E)";

                splitContainer1.Panel2Collapsed = false;
            }
        }
        #endregion

        #region maskedTextBox_S_DoubleClick
        private void maskedTextBox_S_DoubleClick(object sender, EventArgs e)
        {
            MaskedTextBox mtb = (MaskedTextBox)sender;
            DateTime dt;
            bool IsSuccess = DateTime.TryParse(mtb.Text, out dt);
            if (!IsSuccess)
            {
                mtb.Text = DateTime.Now.ToString("yyyy/MM/dd");
            }
        }
        #endregion

        #region dgViewMF_SelectionChanged
        private void dgViewMF_SelectionChanged(object sender, EventArgs e)
        {
            if (dgViewMF.CurrentRow != null)
            {
                string sPPP = dgViewMF.CurrentRow.Cells["PPP"].Value.ToString();

                if (radioButton_Patent.Checked)//專利
                {
                    QS_DataSetTableAdapters.PatentFeeTTableAdapter patFee = new LawtechPTSystem.QS_DataSetTableAdapters.PatentFeeTTableAdapter();
                    QS_DataSet.PatentFeeTDataTable DatatableFee = new QS_DataSet.PatentFeeTDataTable();
                    patFee.FillByPPP(DatatableFee, sPPP);
                    bSource_Fee.DataSource = DatatableFee;

                    QS_DataSetTableAdapters.PatentPaymentTTableAdapter patPayment = new LawtechPTSystem.QS_DataSetTableAdapters.PatentPaymentTTableAdapter();
                    QS_DataSet.PatentPaymentTDataTable DatatablePayment = new QS_DataSet.PatentPaymentTDataTable();
                    patPayment.FillByBillingNo(DatatablePayment, sPPP);
                    bSource_Payment.DataSource = DatatablePayment;
                }
                else//商標
                {
                    if (dgViewMF.CurrentRow.Cells["CaseTypeMode"].Value.ToString() == "Tm")//一般案
                    {
                        DataSet_TMTableAdapters.TrademarkFeeTTableAdapter TmFee = new DataSet_TMTableAdapters.TrademarkFeeTTableAdapter();
                        DataSet_TM.TrademarkFeeTDataTable DatatableFee = new DataSet_TM.TrademarkFeeTDataTable();
                        TmFee.FillByPPP(DatatableFee, sPPP);
                        bSource_Fee.DataSource = DatatableFee;

                        DataSet_TMTableAdapters.TrademarkPaymentTTableAdapter TmPayment = new LawtechPTSystem.DataSet_TMTableAdapters.TrademarkPaymentTTableAdapter();
                        DataSet_TM.TrademarkPaymentTDataTable DatatablePayment = new DataSet_TM.TrademarkPaymentTDataTable();
                        TmPayment.FillBy(DatatablePayment, sPPP);
                        bSource_Payment.DataSource = DatatablePayment;
                    }
                    else
                    {
                        //異議案
                        DataSet_TrademarkControversyTableAdapters.TrademarkControversyFeeTTableAdapter TmFee = new DataSet_TrademarkControversyTableAdapters.TrademarkControversyFeeTTableAdapter();
                        DataSet_TrademarkControversy.TrademarkControversyFeeTDataTable DatatableFee = new DataSet_TrademarkControversy.TrademarkControversyFeeTDataTable();
                        TmFee.FillByPPP(DatatableFee, sPPP);
                        bSource_Fee.DataSource = DatatableFee;

                        DataSet_TrademarkControversyTableAdapters.TrademarkControversyPaymentTTableAdapter TmPayment = new DataSet_TrademarkControversyTableAdapters.TrademarkControversyPaymentTTableAdapter();
                        DataSet_TrademarkControversy.TrademarkControversyPaymentTDataTable DatatablePayment = new DataSet_TrademarkControversy.TrademarkControversyPaymentTDataTable();
                        TmPayment.FillByBillingNo(DatatablePayment, sPPP);
                        bSource_Payment.DataSource = DatatablePayment;
                    }
                }
            }
            else
            {

                if (radioButton_Patent.Checked)
                {
                    QS_DataSetTableAdapters.PatentFeeTTableAdapter patFee = new LawtechPTSystem.QS_DataSetTableAdapters.PatentFeeTTableAdapter();
                    QS_DataSet.PatentFeeTDataTable DatatableFee = new QS_DataSet.PatentFeeTDataTable();
                    patFee.FillByPPP(DatatableFee, "-1");
                    bSource_Fee.DataSource = DatatableFee;

                    QS_DataSetTableAdapters.PatentPaymentTTableAdapter patPayment = new LawtechPTSystem.QS_DataSetTableAdapters.PatentPaymentTTableAdapter();
                    QS_DataSet.PatentPaymentTDataTable DatatablePayment = new QS_DataSet.PatentPaymentTDataTable();
                    patPayment.FillByBillingNo(DatatablePayment, "-1");
                    bSource_Payment.DataSource = DatatablePayment;
                }
                else//商標
                {

                    if (dgViewMF.CurrentRow != null && dgViewMF.CurrentRow.Cells["CaseTypeMode"].Value.ToString() == "Tm")//一般案
                    {
                        DataSet_TMTableAdapters.TrademarkFeeTTableAdapter TmFee = new DataSet_TMTableAdapters.TrademarkFeeTTableAdapter();
                        DataSet_TM.TrademarkFeeTDataTable DatatableFee = new DataSet_TM.TrademarkFeeTDataTable();
                        TmFee.FillByPPP(DatatableFee, "-1");
                        bSource_Fee.DataSource = DatatableFee;

                        DataSet_TMTableAdapters.TrademarkPaymentTTableAdapter TmPayment = new LawtechPTSystem.DataSet_TMTableAdapters.TrademarkPaymentTTableAdapter();
                        DataSet_TM.TrademarkPaymentTDataTable DatatablePayment = new DataSet_TM.TrademarkPaymentTDataTable();
                        TmPayment.FillBy(DatatablePayment, "-1");
                        bSource_Payment.DataSource = DatatablePayment;
                    }
                    else
                    {
                        //異議案
                        DataSet_TrademarkControversyTableAdapters.TrademarkControversyFeeTTableAdapter TmFee = new DataSet_TrademarkControversyTableAdapters.TrademarkControversyFeeTTableAdapter();
                        DataSet_TrademarkControversy.TrademarkControversyFeeTDataTable DatatableFee = new DataSet_TrademarkControversy.TrademarkControversyFeeTDataTable();
                        TmFee.FillByPPP(DatatableFee, "-1");
                        bSource_Fee.DataSource = DatatableFee;

                        DataSet_TrademarkControversyTableAdapters.TrademarkControversyPaymentTTableAdapter TmPayment = new DataSet_TrademarkControversyTableAdapters.TrademarkControversyPaymentTTableAdapter();
                        DataSet_TrademarkControversy.TrademarkControversyPaymentTDataTable DatatablePayment = new DataSet_TrademarkControversy.TrademarkControversyPaymentTDataTable();
                        TmPayment.FillByBillingNo(DatatablePayment, "-1");
                        bSource_Payment.DataSource = DatatablePayment;
                    }
                }

            }
        }
        #endregion

        #region toolStripButton_CaseDetail_Click
        private void toolStripButton_CaseDetail_Click(object sender, EventArgs e)
        {
            if (radioButton_Patent.Checked)
            {
                PatentHistoryRecord1 patent = new LawtechPTSystem.SubFrom.PatentHistoryRecord1();
                patent.property_PatentID = (int)dgViewMF.CurrentRow.Cells["PatentID"].Value;
                patent.TabSelectedIndex = 2;
                patent.Show();
            }
            else
            {
                if (dgViewMF.CurrentRow.Cells["CaseTypeMode"].Value.ToString() == "Tm")
                {
                    TrademarkHistoryRecord trademark = new LawtechPTSystem.SubFrom.TrademarkHistoryRecord();
                    trademark.TrademarkID = (int)dgViewMF.CurrentRow.Cells["PatentID"].Value;
                    trademark.TabSelectedIndex = 3;
                    trademark.Show();
                }
               
            }
        }
        #endregion

        #region comboBox_Select_SelectedIndexChanged
        private void comboBox_Select_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb_Select = (ComboBox)sender;
            ComboBox cb_SelectValue;

            if (cb_Select.Name == "comboBox_Select")
            {
                cb_SelectValue = comboBox_SelectValue;
            }
            else
            {
                cb_SelectValue = comboBox_SelectValue1;
            }

            cb_SelectValue.AutoCompleteSource = AutoCompleteSource.None;
            cb_SelectValue.AutoCompleteMode = AutoCompleteMode.None;
            cb_SelectValue.DropDownStyle = ComboBoxStyle.Simple;

            if (radioButton_Patent.Checked)//專利
            {
                #region 
                DataTable dt = new DataTable();
                Public.DLL dll = new Public.DLL();
                string strSQL = "";
                if (cb_Select.SelectedValue != null)
                {
                    switch (cb_Select.SelectedValue.ToString())
                    {
                        case "CustomerName"://主委託人

                            strSQL = "select ApplicantKey,ApplicantName from ApplicantT order by ApplicantName";
                            dt = dll.SqlDataAdapterDataTable(strSQL);
                            cb_SelectValue.DropDownStyle = ComboBoxStyle.DropDown;
                            cb_SelectValue.AutoCompleteSource = AutoCompleteSource.ListItems;
                            cb_SelectValue.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                            cb_SelectValue.DataSource = dt;
                            cb_SelectValue.DisplayMember = "ApplicantName";
                            cb_SelectValue.ValueMember = "ApplicantKey";
                            cb_SelectValue.Text = "";
                            break;
                        case "PatentFeeT.PPP"://請款單號
                            strSQL = @"Select distinct PPP from (SELECT DISTINCT PPP, PatentID
                                                                FROM          PatentFeeT
                                                                WHERE      (PPP <> '') AND (PPP IS NOT NULL)
                                                                UNION
                                                                SELECT DISTINCT BillingNo AS PPP, PatentID
                                                                FROM         PatentPaymentT AS PatentPaymentT_1
                                                                WHERE     (BillingNo <> '') AND (BillingNo IS NOT NULL)) AS T1";
                            dt = dll.SqlDataAdapterDataTable(strSQL);
                            cb_SelectValue.DropDownStyle = ComboBoxStyle.DropDown;
                            cb_SelectValue.AutoCompleteSource = AutoCompleteSource.ListItems;
                            cb_SelectValue.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                            cb_SelectValue.DataSource = dt;
                            cb_SelectValue.DisplayMember = "PPP";
                            cb_SelectValue.ValueMember = "PPP";
                            cb_SelectValue.Text = "";
                            break;
                        case "PatentManagementT.PatentNo"://本所案號
                            strSQL = @"Select distinct PatentNo from PatentManagementT";
                            dt = dll.SqlDataAdapterDataTable(strSQL);
                            cb_SelectValue.DropDownStyle = ComboBoxStyle.DropDown;
                            cb_SelectValue.AutoCompleteSource = AutoCompleteSource.ListItems;
                            cb_SelectValue.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                            cb_SelectValue.DataSource = dt;
                            cb_SelectValue.DisplayMember = "PatentNo";
                            cb_SelectValue.ValueMember = "PatentNo";
                            cb_SelectValue.Text = "";
                            break;
                        case "PatentManagementT.Country"://國別
                            strSQL = "select CountrySymbol+'-'+Country as Country,CountrySymbol from CountryT order by SN";
                            dt = dll.SqlDataAdapterDataTable(strSQL);
                            cb_SelectValue.DropDownStyle = ComboBoxStyle.DropDown;
                            cb_SelectValue.AutoCompleteSource = AutoCompleteSource.ListItems;
                            cb_SelectValue.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                            cb_SelectValue.DataSource = dt;
                            cb_SelectValue.DisplayMember = "Country";
                            cb_SelectValue.ValueMember = "CountrySymbol";
                            cb_SelectValue.Text = "";
                            break;
                        case "PatentManagementT.Kind"://種類
                            strSQL = "select Kind,KindSN from KindT where OvertureKind='P' order by SN";
                            dt = dll.SqlDataAdapterDataTable(strSQL);
                            cb_SelectValue.DropDownStyle = ComboBoxStyle.DropDownList;
                            cb_SelectValue.AutoCompleteSource = AutoCompleteSource.None;
                            cb_SelectValue.AutoCompleteMode = AutoCompleteMode.None;
                            cb_SelectValue.DataSource = dt;
                            cb_SelectValue.DisplayMember = "Kind";
                            cb_SelectValue.ValueMember = "KindSN";
                            //comboBox_SelectValue.SelectedIndex = "";
                            break;
                        case "PatentManagementT.Nature"://性質
                            strSQL = "SELECT     FeatureID, FeatureName from PATFeatureT  order by sort";
                            dt = dll.SqlDataAdapterDataTable(strSQL);
                            cb_SelectValue.DropDownStyle = ComboBoxStyle.DropDownList;
                            cb_SelectValue.AutoCompleteSource = AutoCompleteSource.None;
                            cb_SelectValue.AutoCompleteMode = AutoCompleteMode.None;
                            cb_SelectValue.DataSource = dt;
                            cb_SelectValue.DisplayMember = "FeatureName";
                            cb_SelectValue.ValueMember = "FeatureID";
                            //comboBox_SelectValue.SelectedIndex = "";
                            break;
                        default:
                            //cb_SelectValue.AutoCompleteSource = AutoCompleteSource.None;
                            //cb_SelectValue.AutoCompleteMode = AutoCompleteMode.None;
                            //cb_SelectValue.DropDownStyle = ComboBoxStyle.Simple;
                            cb_SelectValue.Text = "";
                            break;
                    }
                }
                #endregion
            }
            else //商標
            {
                #region 
                DataTable dt = new DataTable();
                Public.DLL dll = new Public.DLL();
                string strSQL = "";

                if (cb_Select.SelectedValue != null)
                {
                    switch (cb_Select.SelectedValue.ToString())
                    {
                        case "CustomerName"://主委託人

                            strSQL = "select ApplicantKey,ApplicantName from ApplicantT order by ApplicantName";
                            dt = dll.SqlDataAdapterDataTable(strSQL);
                            cb_SelectValue.DropDownStyle = ComboBoxStyle.DropDown;
                            cb_SelectValue.AutoCompleteSource = AutoCompleteSource.ListItems;
                            cb_SelectValue.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                            cb_SelectValue.DataSource = dt;
                            cb_SelectValue.DisplayMember = "ApplicantName";
                            cb_SelectValue.ValueMember = "ApplicantKey";
                            cb_SelectValue.Text = "";
                            break;

                        case "PPP"://請款單號
                            strSQL = @"Select distinct PPP from 
                                                            (SELECT DISTINCT PPP
                                                                FROM          TrademarkFeeT
                                                                WHERE      (PPP <> '') AND (PPP IS NOT NULL)
                                                              UNION
                                                                SELECT DISTINCT BillingNo AS PPP
                                                                FROM         TrademarkPaymentT AS TrademarkPaymentT_1
                                                                WHERE     (BillingNo <> '') AND (BillingNo IS NOT NULL)
                                                              UNION
                                                               SELECT DISTINCT PPP
                                                                FROM          TrademarkControversyFeeT
                                                                WHERE      (PPP <> '') AND (PPP IS NOT NULL)
                                                              UNION
                                                                SELECT DISTINCT BillingNo AS PPP
                                                                FROM         TrademarkControversyPaymentT AS TrademarkControversyPaymentT_1
                                                                WHERE     (BillingNo <> '') AND (BillingNo IS NOT NULL)
                                        ) AS T1";
                            dt = dll.SqlDataAdapterDataTable(strSQL);
                            cb_SelectValue.DropDownStyle = ComboBoxStyle.DropDown;
                            cb_SelectValue.AutoCompleteSource = AutoCompleteSource.ListItems;
                            cb_SelectValue.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                            cb_SelectValue.DataSource = dt;
                            cb_SelectValue.DisplayMember = "PPP";
                            cb_SelectValue.ValueMember = "PPP";
                            cb_SelectValue.Text = "";
                            break;

                        case "Country"://國別
                            strSQL = "select CountrySymbol+'-'+Country as Country,CountrySymbol from CountryT order by SN";
                            dt = dll.SqlDataAdapterDataTable(strSQL);
                            cb_SelectValue.DropDownStyle = ComboBoxStyle.DropDown;
                            cb_SelectValue.AutoCompleteSource = AutoCompleteSource.ListItems;
                            cb_SelectValue.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                            cb_SelectValue.DataSource = dt;
                            cb_SelectValue.DisplayMember = "Country";
                            cb_SelectValue.ValueMember = "CountrySymbol";
                            cb_SelectValue.Text = "";
                            break;

                        case "TrademarkNo"://本所案號
                            strSQL = @"Select distinct TrademarkNo from TrademarkManagementT
                                        UNION 
                                       Select distinct TrademarkNo from TrademarkControversyManagementT
                                        ";
                            dt = dll.SqlDataAdapterDataTable(strSQL);
                            cb_SelectValue.DropDownStyle = ComboBoxStyle.DropDown;
                            cb_SelectValue.AutoCompleteSource = AutoCompleteSource.ListItems;
                            cb_SelectValue.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                            cb_SelectValue.DataSource = dt;
                            cb_SelectValue.DisplayMember = "TrademarkNo";
                            cb_SelectValue.ValueMember = "TrademarkNo";
                            cb_SelectValue.Text = "";
                            break;

                        case "StyleName"://商標樣式
                            strSQL = @"Select distinct StyleName from TrademarkControversyManagementT where StyleName is not Null and StyleName<>''
                                        UNION 
                                       Select distinct StyleName from TrademarkControversyManagementT where StyleName is not Null and StyleName<>''";
                            dt = dll.SqlDataAdapterDataTable(strSQL);
                            cb_SelectValue.DropDownStyle = ComboBoxStyle.DropDownList;
                            cb_SelectValue.AutoCompleteSource = AutoCompleteSource.None;
                            cb_SelectValue.AutoCompleteMode = AutoCompleteMode.None;
                            cb_SelectValue.DataSource = dt;
                            cb_SelectValue.DisplayMember = "StyleName";
                            cb_SelectValue.ValueMember = "StyleName";
                            cb_SelectValue.Text = "";
                            break;

                        case "TMTypeName"://案件類別
                            strSQL = @"Select distinct TMTypeName from TrademarkManagementT where TMTypeName is not Null and TMTypeName<>''
                                        UNION 
                                       Select distinct TMTypeName from TrademarkControversyManagementT  where TMTypeName is not Null and TMTypeName<>''";
                            dt = dll.SqlDataAdapterDataTable(strSQL);
                            cb_SelectValue.DropDownStyle = ComboBoxStyle.DropDownList;
                            cb_SelectValue.AutoCompleteSource = AutoCompleteSource.None;
                            cb_SelectValue.AutoCompleteMode = AutoCompleteMode.None;
                            cb_SelectValue.DataSource = dt;
                            cb_SelectValue.DisplayMember = "TMTypeName";
                            cb_SelectValue.ValueMember = "TMTypeName";
                            cb_SelectValue.Text = "";
                            break;
                        default:                          
                            cb_SelectValue.Text = "";
                            break;
                    }
                }
                #endregion
            }
        }
        #endregion 

        #region radioButton_Patent_CheckedChanged
        private void radioButton_Patent_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb=( RadioButton)sender;
            if (rb.Checked)
            {
                if (rb.Name == "radioButton_Patent")
                {
                    comboBox_Select.DataSource = accountingCombinSearchPatentBindingSource;
                    comboBox_Select1.DataSource = accountingCombinSearchPatentBindingSource1;
                }
                else
                {
                    comboBox_Select.DataSource = accountingCombinSearchTradenarkBindingSource;
                    comboBox_Select1.DataSource = accountingCombinSearchTradenarkBindingSource1;
                }

                but_Search_Click(null,null);

            }
        }
        #endregion

        #region dgViewMF_DataError
        private void dgViewMF_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = false;
        }
        #endregion

        #region dgViewMF_CellDoubleClick
        private void dgViewMF_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            toolStripButton_CaseDetail_Click(null,null);
        }
        #endregion

        #region toolStripButton1_Click
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            //ToolStripButton toolbut = (ToolStripButton)sender;

            if (splitContainer2.Orientation == Orientation.Horizontal)
            {
                splitContainer2.Orientation = Orientation.Vertical;

                if (splitContainer2.Size.Width > 50)
                {
                    int iWidth = splitContainer2.Size.Width / 2;
                    splitContainer2.SplitterDistance = iWidth;
                }

                toolStripButton1.Text = "水平畫面";
                toolStripButton1.Image = global::LawtechPTSystem.Properties.Resources.horizontal;

                toolStripButton2.Text = "水平畫面";
                toolStripButton2.Image = global::LawtechPTSystem.Properties.Resources.horizontal;
            }
            else
            {
                if (splitContainer2.Size.Height > 50)
                {
                    int iHeight = splitContainer2.Size.Height / 2;
                    splitContainer2.SplitterDistance = iHeight;
                }

                splitContainer2.Orientation = Orientation.Horizontal;
                toolStripButton1.Text = "垂直畫面";
                toolStripButton1.Image = global::LawtechPTSystem.Properties.Resources.Vertical;

                toolStripButton2.Text = "垂直畫面";
                toolStripButton2.Image = global::LawtechPTSystem.Properties.Resources.Vertical;
            }
        }
        #endregion

        private void dgViewMF_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

    }
}
