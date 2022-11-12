using System;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LawtechPTSystem.SubFrom
{
    /// <summary>
    /// 舊版不使用
    /// </summary>
    public partial class AccountingFeeMF : Form
    {
        BindingSource bSource_Control;

        #region =====property=====
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

        /// <summary>
        /// 取得資料集來源
        /// </summary>
        public DataTable GetAccountingData
        {
            get 
            {
                return (DataTable)bSource_Control.DataSource;
            }
        }

        /// <summary>
        /// 目前的DataGridViewRow CurrentRow
        /// </summary>
        public DataGridViewRow GV_CurrentRow
        {
            get {
                return dgViewMF.CurrentRow;
            }
        }

        public DataRow GetAccountingDataRow
        {
            get {
                return ((System.Data.DataRowView)(dgViewMF.CurrentRow.DataBoundItem)).Row;
            }
        }
        #endregion

        public AccountingFeeMF()
        {
            InitializeComponent();
            dgViewMF.AutoGenerateColumns = false;
        }

        #region AccountingFeeMF_Load  AccountingFeeMF_FormClosed
        private void AccountingFeeMF_Load(object sender, EventArgs e)
        {          
            
            Public.PublicForm Forms = new Public.PublicForm();
            Forms.AccountingFeeMF = this;

            //登入者
            iWorkerID = Properties.Settings.Default.WorkerKEY;
            Worker_Model worker = new Worker_Model();
            Worker_Model.ReadOne(iWorkerID, ref  worker);
           
            //角色的權限
            OfficeRole = worker.OfficeRole.Value;

            this.accountingSelectValueTableAdapter.Fill(this.dataSet_Accounting.AccountingSelectValue);
            this.dataSet_Accounting.AccountingSelectDate.Rows.Clear();
            this.accountingSelectDateTableAdapter.Fill(this.dataSet_Accounting.AccountingSelectDate);


            bSource_Control = new BindingSource();
            dgViewMF.DataSource = bSource_Control;
            bindingNavigator1.BindingSource = bSource_Control;

            but_Search_Click(null,null);
        }
       
        private void AccountingFeeMF_FormClosed(object sender, FormClosedEventArgs e)
        {
            Public.PublicForm Forms = new Public.PublicForm();
            Forms.AccountingFeeMF = null;
        }
        #endregion

        #region but_Close_Click
        private void but_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region but_Search_Click
        private void but_Search_Click(object sender, EventArgs e)
        {
            but_Search.Enabled = false;
            string times = "";
            string sfilter = "";
            string strFilter1 = "";
            string sFinishDate = "";
            if (radioButton_NotFinish.Checked)//待處理
            {
                sFinishDate = " FinishDate is null and ( PPP is null or PPP='')";
            }
            else if (radioButton_ppp.Checked)
            {
                sFinishDate = " FinishDate is null and PPP is not null";
            }
            else
            {
                sFinishDate = " FinishDate is not null ";
            }

            if (comboBox_SelectValue.Text == "" && comboBox_SelectValue1.Text == "" && maskedTextBox_S.Text == "    -  -" && maskedTextBox_D.Text == "    -  -")
            {
                sfilter = "";
            }
            else
            {
                DateTime dtS = new DateTime(), dtE = new DateTime();
                if (maskedTextBox_S.Text != "    -  -")
                {
                    bool IsS = DateTime.TryParse(maskedTextBox_S.Text, out dtS);
                    if (!IsS)
                    {
                        MessageBox.Show("日期格式錯誤 <<" + maskedTextBox_S.Text + ">>");
                        return;
                    }
                }

                if (maskedTextBox_D.Text != "    -  -")
                {
                    bool IsE = DateTime.TryParse(maskedTextBox_D.Text, out dtE);
                    if (!IsE)
                    {
                        MessageBox.Show("日期格式錯誤 <<" + maskedTextBox_D.Text + ">>");
                        return;
                    }
                }

                if (maskedTextBox_S.Text != "    -  -" && maskedTextBox_D.Text != "    -  -")
                {

                    if (dtS > dtE)
                    {
                        maskedTextBox_S.Text = dtE.ToString("yyyy-MM-dd");
                        maskedTextBox_D.Text = dtS.ToString("yyyy-MM-dd");
                    }
                }
                

                string strDateMode = comboBox_DateMode.SelectedValue.ToString();

                if (maskedTextBox_S.Text != "    -  -" && maskedTextBox_D.Text == "    -  -")
                {
                    times += " " + strDateMode + ">='" + maskedTextBox_S.Text + "'";
                }
                else if (maskedTextBox_S.Text == "    -  -" && maskedTextBox_D.Text != "    -  -")
                {
                    times += " " + strDateMode + "<='" + maskedTextBox_D.Text + "'";
                }
                else if (maskedTextBox_S.Text != "    -  -" && maskedTextBox_D.Text != "    -  -")
                {
                    times += " (" + strDateMode + " >= '" + maskedTextBox_S.Text + "' and " + strDateMode + "<= '" + maskedTextBox_D.Text + "')";
                }

                #region Select 1
                if (comboBox_SelectValue.Text.Trim() != "" || comboBox_SelectValue.SelectedValue != null)
                {
                    switch (comboBox_Select.SelectedValue.ToString())
                    {
                        case "PPP":
                        case "EventNo":
                        case "MainCustomerRefNo":
                        case "ApplicationNo":
                            sfilter = comboBox_Select.SelectedValue.ToString() + " like '%" + comboBox_SelectValue.Text+ "%' ";                            
                            break;
                        case "CustomerName":
                            if (comboBox_SelectValue.SelectedValue != null)
                            {
                                sfilter = "(CASE PatentManagementT.DelegateType WHEN 1 THEN ApplicantNames WHEN 2 THEN (select AttorneyT.AttorneyFirm from AttorneyT where AttorneyT.AttorneyKey=PatentManagementT.MainCustomer ) END) ='" + comboBox_SelectValue.Text+"'";
                            }
                            else
                            {
                                comboBox_SelectValue.Text = "";
                            }

                            break;
                        case "CountryT.CountrySymbol":
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
                #endregion

                #region Select 2
               
                if (comboBox_SelectValue1.Text.Trim() != "" || comboBox_SelectValue1.SelectedValue != null)
                {
                    switch (comboBox_Select1.SelectedValue.ToString())
                    {
                        case "PPP":
                        case "EventNo":
                        case "MainCustomerRefNo":
                        case "ApplicationNo":
                            strFilter1 = comboBox_Select1.SelectedValue.ToString() + " like '%" + comboBox_SelectValue1.Text + "%' ";
                            break;
                        case "CustomerName":
                            if (comboBox_SelectValue1.SelectedValue != null)
                            {
                                strFilter1 = "(CASE PatentManagementT.DelegateType WHEN 1 THEN ApplicantNames WHEN 2 THEN (select AttorneyT.AttorneyFirm from AttorneyT where AttorneyT.AttorneyKey=PatentManagementT.MainCustomer ) END) ='" + comboBox_SelectValue1.Text+"'";
                            }
                            else
                            {
                                comboBox_SelectValue1.Text = "";
                            }

                            break;
                        case "CountryT.CountrySymbol":
                            if (comboBox_SelectValue1.SelectedValue != null)
                            {
                                strFilter1 = comboBox_Select1.SelectedValue.ToString() + " ='" + comboBox_SelectValue1.SelectedValue.ToString() + "'";
                            }
                            else
                            {
                                comboBox_SelectValue1.Text = "";
                            }
                            break;
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

            string[] sWhere = { times, sFinishDate, FullFilter };

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
        
            DataBind_Fee(FullWhere.ToString());

            but_Search.Enabled = true;
        }
        #endregion

        #region contextMenuStrip_ForDate_ItemClicked
        private void contextMenuStrip_ForDate_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ContextMenuStrip content = (ContextMenuStrip)sender;
            MaskedTextBox mtb = content.SourceControl as MaskedTextBox;

            contextMenuStrip_ForDate.Visible = false;

            switch (e.ClickedItem.Name)
            {
                case "ToolStripMenuItem_Calculation":

                    US.CalculationDate Calculation = new LawtechPTSystem.US.CalculationDate();
                    DateTime dt = new DateTime(1900, 1, 1);
                    bool IsSuccess = DateTime.TryParse(mtb.Text, out dt);
                    if (IsSuccess)
                    {
                        Calculation.CurrentDate = dt;
                    }
                    else
                    {
                        Calculation.CurrentDate = new DateTime(1900, 1, 1);
                    }

                    //取得結果
                    if (Calculation.ShowDialog() == DialogResult.OK)
                    {
                        mtb.Text = Calculation.GetResult;
                    }
                    break;
            }
        }
        #endregion

        #region =============maskedTextBox_S_DoubleClick===========
        private void maskedTextBox_S_DoubleClick(object sender, EventArgs e)
        {
            MaskedTextBox mtb = (MaskedTextBox)sender;
            DateTime dt;
            bool IsSuccess = DateTime.TryParse(mtb.Text, out dt);
            if (!IsSuccess)
            {
                mtb.Text = DateTime.Now.ToString("yyyy-MM-dd");
            }
        }
        #endregion

        #region DataBind_Fee
        public void DataBind_Fee(string strWhere)
        {
            if (radioButton_All.Checked)//全部
            {
                System.Data.DataTable dt_PatentFee = GetFeeEvent(strWhere);

                if (dt_PatentFee.Rows.Count > 0)
                {
                    System.Data.DataTable dt_TrademarkFeeEvent = GetFeeEventbyTrademark(strWhere);
                    dt_PatentFee.Merge(dt_TrademarkFeeEvent);
                }
                else
                {
                    dt_PatentFee = GetFeeEventbyTrademark(strWhere);
                }

                bSource_Control.DataSource = dt_PatentFee;
            }
            else if (radioButton_Patent.Checked)//專利
            {
                System.Data.DataTable dt_PatentFee = GetFeeEvent(strWhere);
                bSource_Control.DataSource = dt_PatentFee;
            }
            else if (radioButton_Trademark.Checked)//商標
            {
                System.Data.DataTable dt_PatentFeeEvent = GetFeeEventbyTrademark(strWhere);
                bSource_Control.DataSource = dt_PatentFeeEvent;
            }           
         
        }
        #endregion        

        #region GetFeeEvent 取得專利請款的資料
        /// <summary>
        /// 取得請款的資料
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public System.Data.DataTable GetFeeEvent(string strWhere)
        {

            strWhere = strWhere.Replace("FinishDate is not null", "PatentFeeT.Pay=1").Replace("FinishDate is null", " (PatentFeeT.Pay<>1) ").Replace("EventNo", "PatentManagementT.PatentNo");

            string strPatentFeeSQL = string.Format(
                                    @"SELECT     'Pat' AS CaseType, '專利' AS CaseTypeName, PatentManagementT.PatentID AS MainKey, PatentFeeT.FeeKEY, PatentManagementT.PatentNo, 
                                                  PatentManagementT.DelegateType, PatentManagementT.MainCustomerRefNo, CountryT.Country, KindT.Kind, PatentManagementT.ApplicationDate, 
                                                  PatentManagementT.ApplicationNo, PatentFeeT.FeeSubject, PatentFeeT.Totall, PatentManagementT.Title, PatentFeeT.SingCode, 
                                                  PatentFeeT.ReceiptDate, PatentFeeT.PayDate, WorkerT.EmployeeName AS WorkerName, PatentFeeT.OtherTotalFee, PatentFeeT.OAttorneyGovFee, 
                                                  PatentFeeT.PPP, PatentFeeT.PracticalityPay, 
                                                  CASE PatentManagementT.DelegateType WHEN 1 THEN PatentManagementT.ApplicantNames WHEN 2 THEN
                                                      (SELECT     AttorneyT.AttorneyFirm
                                                        FROM          AttorneyT
                                                        WHERE      AttorneyKey = PatentManagementT.MainCustomer) END AS CustomerName, PatentFeeT.RDate, 
                                                  AttorneyT.AttorneyFirm AS AttorneyFirmFee, PatentFeeT.OMoney, PatentFeeT.GovFee, PatentFeeT.OAttorneyFee, PatentFeeT.OthFee, 
                                                  AttorneyT.AttorneyKey, PatComitEventT.OccurDate, PatentFeeT.IsClosing, PatentFeeT.CloseDate, PatentFeeT.GMoney, 
                                                  PatentManagementT.ApplicantNames, PatentFeeT.Tax, FeePhaseT.FeePhase, PatentFeeT.Remark,PatentManagementT.ApplicantKeys,PatentFeeT.PayKind,PatentFeeT.TMoney
                                            FROM         FeePhaseT RIGHT OUTER JOIN
                                                  PatentFeeT ON FeePhaseT.FeePhaseID = PatentFeeT.FeePhase LEFT OUTER JOIN
                                                  PatComitEventToFeeT LEFT OUTER JOIN
                                                  PatComitEventT ON PatComitEventToFeeT.PatComitEventID = PatComitEventT.PatComitEventID ON 
                                                  PatentFeeT.FeeKEY = PatComitEventToFeeT.FeeKEY LEFT OUTER JOIN
                                                  AttorneyT ON PatentFeeT.Attorney = AttorneyT.AttorneyKey LEFT OUTER JOIN
                                                  WorkerT ON PatentFeeT.FClientTransactor = WorkerT.WorkerKey LEFT OUTER JOIN
                                                  PatentManagementT LEFT OUTER JOIN
                                                  KindT ON PatentManagementT.Kind = KindT.KindSN LEFT OUTER JOIN
                                                  CountryT ON PatentManagementT.CountrySymbol = CountryT.CountrySymbol ON PatentFeeT.PatentID = PatentManagementT.PatentID
                                where {0};

                                select Sum(Totall)as SumTotall,  sum(Tax) as SumTax ,sum(PracticalityPay)as SumPracticalityPay
                                 FROM         FeePhaseT RIGHT OUTER JOIN
                                                                                  PatentFeeT ON FeePhaseT.FeePhaseID = PatentFeeT.FeePhase LEFT OUTER JOIN
                                                                                  PatComitEventToFeeT LEFT OUTER JOIN
                                                                                  PatComitEventT ON PatComitEventToFeeT.PatComitEventID = PatComitEventT.PatComitEventID ON 
                                                                                  PatentFeeT.FeeKEY = PatComitEventToFeeT.FeeKEY LEFT OUTER JOIN
                                                                                  AttorneyT ON PatentFeeT.Attorney = AttorneyT.AttorneyKey LEFT OUTER JOIN
                                                                                  WorkerT ON PatentFeeT.FClientTransactor = WorkerT.WorkerKey LEFT OUTER JOIN
                                                                                  PatentManagementT LEFT OUTER JOIN
                                                                                  KindT ON PatentManagementT.Kind = KindT.KindSN LEFT OUTER JOIN
                                                                                  CountryT ON PatentManagementT.CountrySymbol = CountryT.CountrySymbol ON PatentFeeT.PatentID = PatentManagementT.PatentID
                                                                where {0}
                                ", strWhere);

            Public.DLL dll = new Public.DLL();
            System.Data.DataSet dsFeeEvent = new System.Data.DataSet();
           dsFeeEvent= dll.SqlDataAdapterDataSet(strPatentFeeSQL);

           if (dsFeeEvent.Tables[1].Rows.Count > 0)
           {
               lab_PatSumTotal.Text = dsFeeEvent.Tables[1].Rows[0]["SumTotall"] != DBNull.Value ? ((decimal)dsFeeEvent.Tables[1].Rows[0]["SumTotall"]).ToString("#,##0.##") : "0";
               lab_PatSumTax.Text = dsFeeEvent.Tables[1].Rows[0]["SumTax"] != DBNull.Value ? ((decimal)dsFeeEvent.Tables[1].Rows[0]["SumTax"]).ToString("#,##0.##") : "0";
               lab_PatSumPracticalityPay.Text = dsFeeEvent.Tables[1].Rows[0]["SumPracticalityPay"] != DBNull.Value ? ((decimal)dsFeeEvent.Tables[1].Rows[0]["SumPracticalityPay"]).ToString("#,##0.##") : "0";
           }
           return dsFeeEvent.Tables[0];
        }
        #endregion

        #region GetFeeEvent 取得商標請款的資料
        /// <summary>
        /// 取得商標請款的資料
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public System.Data.DataTable GetFeeEventbyTrademark(string strWhere)
        {

            string strControversyWhere = strWhere.Replace("FinishDate is not null", "TrademarkControversyFeeT.Pay=1").Replace("FinishDate is null", " (TrademarkControversyFeeT.Pay<>1) ").Replace("EventNo", "TrademarkControversyManagementT.TrademarkNo").Replace("PatentManagementT", "TrademarkControversyManagementT").Replace("PatentFeeT", "TrademarkControversyFeeT");

            strWhere = strWhere.Replace("FinishDate is not null", "TrademarkFeeT.Pay=1").Replace("FinishDate is null", " (TrademarkFeeT.Pay<>1) ").Replace("EventNo", "TrademarkManagementT.TrademarkNo").Replace("PatentManagementT", "TrademarkManagementT").Replace("PatentFeeT", "TrademarkFeeT"); 
           

            string strPatentFeeSQL = string.Format(
                                    @"SELECT     'Tm' AS CaseType, '商標' AS CaseTypeName, TrademarkManagementT.TrademarkID AS MainKey, TrademarkFeeT.FeeKEY, 
                                                              TrademarkManagementT.TrademarkNo AS PatentNo, TrademarkManagementT.DelegateType, TrademarkManagementT.MainCustomerRefNo, 
                                                              CountryT.Country, TrademarkManagementT.StyleName AS kind, TrademarkManagementT.ApplicationDate, TrademarkManagementT.ApplicationNo, 
                                                              TrademarkFeeT.FeeSubject, TrademarkFeeT.Totall, TrademarkManagementT.TrademarkName AS Title, TrademarkFeeT.SingCode, 
                                                              TrademarkFeeT.ReceiptDate, TrademarkFeeT.PayDate, WorkerT.EmployeeName AS WorkerName, TrademarkFeeT.OtherTotalFee, 
                                                              TrademarkFeeT.OAttorneyGovFee, TrademarkFeeT.PPP, TrademarkFeeT.PracticalityPay, 
                                                              CASE TrademarkManagementT.DelegateType WHEN 1 THEN TrademarkManagementT.ApplicantNames WHEN 2 THEN
                                                                  (SELECT     AttorneyT.AttorneyFirm
                                                                    FROM          AttorneyT
                                                                    WHERE      AttorneyKey = TrademarkManagementT.MainCustomer) END AS CustomerName, TrademarkFeeT.RDate, 
                                                              AttorneyT.AttorneyFirm AS AttorneyFirmFee, TrademarkFeeT.OMoney, TrademarkFeeT.GovFee, TrademarkFeeT.OAttorneyFee, TrademarkFeeT.OthFee, 
                                                              AttorneyT.AttorneyKey, TrademarkNotifyEventT.OccurDate, TrademarkFeeT.IsClosing, TrademarkFeeT.CloseDate, TrademarkFeeT.GMoney, 
                                                              TrademarkManagementT.ApplicantNames, TrademarkFeeT.Tax, FeePhaseT.FeePhase, TrademarkFeeT.Remark,TrademarkManagementT.ApplicantKeys,TrademarkFeeT.PayKind,TrademarkFeeT. TMoney
                                        FROM         FeePhaseT RIGHT OUTER JOIN
                                                              TrademarkFeeT ON FeePhaseT.FeePhaseID = TrademarkFeeT.FeePhase LEFT OUTER JOIN
                                                              TrademarkNotifyEventToFeeT LEFT OUTER JOIN
                                                              TrademarkNotifyEventT ON TrademarkNotifyEventToFeeT.TMNotifyEventID = TrademarkNotifyEventT.TMNotifyEventID ON 
                                                              TrademarkFeeT.FeeKEY = TrademarkNotifyEventToFeeT.FeeKEY LEFT OUTER JOIN
                                                              AttorneyT ON TrademarkFeeT.Attorney = AttorneyT.AttorneyKey LEFT OUTER JOIN
                                                              WorkerT ON TrademarkFeeT.FClientTransactor = WorkerT.WorkerKey LEFT OUTER JOIN
                                                              TrademarkManagementT LEFT OUTER JOIN
                                                              CountryT ON TrademarkManagementT.CountrySymbol = CountryT.CountrySymbol ON TrademarkFeeT.TrademarkID = TrademarkManagementT.TrademarkID  where {0}
                                       UNION
                                      SELECT     'CO' AS CaseType, '商標' AS CaseTypeName, TrademarkControversyManagementT.TrademarkControversyID AS MainKey, 
                                              TrademarkControversyFeeT.ControversyFeeKEY AS FeeKEY, TrademarkControversyManagementT.TrademarkNo AS PatentNo, 
                                              TrademarkControversyManagementT.DelegateType, TrademarkControversyManagementT.MainCustomerRefNo, CountryT.Country, 
                                              TrademarkControversyManagementT.StyleName AS kind, TrademarkControversyManagementT.ApplicationDate, 
                                              TrademarkControversyManagementT.ApplicationNo, TrademarkControversyFeeT.FeeSubject, TrademarkControversyFeeT.Totall, 
                                              TrademarkControversyManagementT.TrademarkName AS Title, TrademarkControversyFeeT.SingCode, TrademarkControversyFeeT.ReceiptDate, 
                                              TrademarkControversyFeeT.PayDate, WorkerT.EmployeeName AS WorkerName, TrademarkControversyFeeT.OtherTotalFee, 
                                              TrademarkControversyFeeT.OAttorneyGovFee, TrademarkControversyFeeT.PPP, TrademarkControversyFeeT.PracticalityPay, 
                                              CASE TrademarkControversyManagementT.DelegateType WHEN 1 THEN TrademarkControversyManagementT.ApplicantNames WHEN 2 THEN
                                                  (SELECT     AttorneyT.AttorneyFirm
                                                    FROM          AttorneyT
                                                    WHERE      AttorneyKey = TrademarkControversyManagementT.MainCustomer) END AS CustomerName, TrademarkControversyFeeT.RDate, 
                                              AttorneyT.AttorneyFirm AS AttorneyFirmFee, TrademarkControversyFeeT.OMoney, TrademarkControversyFeeT.GovFee, 
                                              TrademarkControversyFeeT.OAttorneyFee, TrademarkControversyFeeT.OthFee, AttorneyT.AttorneyKey, TrademarkControversyNotifyEventT.OccurDate, 
                                              TrademarkControversyFeeT.IsClosing, TrademarkControversyFeeT.CloseDate, TrademarkControversyFeeT.GMoney, 
                                              TrademarkControversyManagementT.ApplicantNames, TrademarkControversyFeeT.Tax, FeePhaseT.FeePhase, 
                                              TrademarkControversyFeeT.Remark,TrademarkControversyManagementT.ApplicantKeys,TrademarkControversyFeeT.PayKind,TrademarkControversyFeeT.TMoney
                                            FROM         FeePhaseT RIGHT OUTER JOIN
                                              TrademarkControversyFeeT ON FeePhaseT.FeePhaseID = TrademarkControversyFeeT.FeePhase LEFT OUTER JOIN
                                              TrademarkControversyNotifyEventToFeeT LEFT OUTER JOIN
                                              TrademarkControversyNotifyEventT ON 
                                              TrademarkControversyNotifyEventToFeeT.TMNotifyControversyEventID = TrademarkControversyNotifyEventT.TMNotifyControversyEventID ON 
                                              TrademarkControversyFeeT.ControversyFeeKEY = TrademarkControversyNotifyEventToFeeT.ControversyFeeKEY LEFT OUTER JOIN
                                              AttorneyT ON TrademarkControversyFeeT.Attorney = AttorneyT.AttorneyKey LEFT OUTER JOIN
                                              WorkerT ON TrademarkControversyFeeT.FClientTransactor = WorkerT.WorkerKey LEFT OUTER JOIN
                                              TrademarkControversyManagementT LEFT OUTER JOIN
                                              CountryT ON TrademarkControversyManagementT.CountrySymbol = CountryT.CountrySymbol ON 
                                              TrademarkControversyFeeT.TrademarkControversyID = TrademarkControversyManagementT.TrademarkControversyID  where {1};
                                                    
                                                    select Sum(Totall)as SumTotall,  sum(Tax) as SumTax ,sum(PracticalityPay)as SumPracticalityPay
                                                         FROM         FeePhaseT RIGHT OUTER JOIN
                                                              TrademarkFeeT ON FeePhaseT.FeePhaseID = TrademarkFeeT.FeePhase LEFT OUTER JOIN
                                                              TrademarkNotifyEventToFeeT LEFT OUTER JOIN
                                                              TrademarkNotifyEventT ON TrademarkNotifyEventToFeeT.TMNotifyEventID = TrademarkNotifyEventT.TMNotifyEventID ON 
                                                              TrademarkFeeT.FeeKEY = TrademarkNotifyEventToFeeT.FeeKEY LEFT OUTER JOIN
                                                              AttorneyT ON TrademarkFeeT.Attorney = AttorneyT.AttorneyKey LEFT OUTER JOIN
                                                              WorkerT ON TrademarkFeeT.FClientTransactor = WorkerT.WorkerKey LEFT OUTER JOIN
                                                              TrademarkManagementT LEFT OUTER JOIN
                                                              CountryT ON TrademarkManagementT.CountrySymbol = CountryT.CountrySymbol ON TrademarkFeeT.TrademarkID = TrademarkManagementT.TrademarkID  where {0}
                                                union
                                                select Sum(Totall)as SumTotall,  sum(Tax) as SumTax ,sum(PracticalityPay)as SumPracticalityPay
                                                 FROM         FeePhaseT RIGHT OUTER JOIN
                                              TrademarkControversyFeeT ON FeePhaseT.FeePhaseID = TrademarkControversyFeeT.FeePhase LEFT OUTER JOIN
                                              TrademarkControversyNotifyEventToFeeT LEFT OUTER JOIN
                                              TrademarkControversyNotifyEventT ON 
                                              TrademarkControversyNotifyEventToFeeT.TMNotifyControversyEventID = TrademarkControversyNotifyEventT.TMNotifyControversyEventID ON 
                                              TrademarkControversyFeeT.ControversyFeeKEY = TrademarkControversyNotifyEventToFeeT.ControversyFeeKEY LEFT OUTER JOIN
                                              AttorneyT ON TrademarkControversyFeeT.Attorney = AttorneyT.AttorneyKey LEFT OUTER JOIN
                                              WorkerT ON TrademarkControversyFeeT.FClientTransactor = WorkerT.WorkerKey LEFT OUTER JOIN
                                              TrademarkControversyManagementT LEFT OUTER JOIN
                                              CountryT ON TrademarkControversyManagementT.CountrySymbol = CountryT.CountrySymbol ON 
                                              TrademarkControversyFeeT.TrademarkControversyID = TrademarkControversyManagementT.TrademarkControversyID  where {1}

                                        ", strWhere, strControversyWhere);

            Public.DLL dll = new Public.DLL();
            System.Data.DataSet dsFeeEvent = new System.Data.DataSet();
          dsFeeEvent=  dll.SqlDataAdapterDataSet(strPatentFeeSQL);

          if (dsFeeEvent.Tables[1].Rows.Count > 0)
          {
              lab_TMSumTotal.Text = dsFeeEvent.Tables[1].Rows[0]["SumTotall"] != DBNull.Value ? ((decimal)dsFeeEvent.Tables[1].Rows[0]["SumTotall"]).ToString("#,##0.##") : "0";
              lab_TMSumTax.Text = dsFeeEvent.Tables[1].Rows[0]["SumTax"] != DBNull.Value ? ((decimal)dsFeeEvent.Tables[1].Rows[0]["SumTax"]).ToString("#,##0.##") : "0";
              lab_TMSumPracticalityPay.Text = dsFeeEvent.Tables[1].Rows[0]["SumPracticalityPay"] != DBNull.Value ? ((decimal)dsFeeEvent.Tables[1].Rows[0]["SumPracticalityPay"]).ToString("#,##0.##") : "0";
          }
          return dsFeeEvent.Tables[0];
        }
        #endregion

        #region dgViewMF_DataError
        private void dgViewMF_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = false;
        }
        #endregion

        #region contextMenuStrip_Accounting
        private void contextMenuStrip_Accounting_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            contextMenuStrip_Accounting.Visible = false;
            string sCaseType = dgViewMF.CurrentRow.Cells["CaseType"].Value.ToString();           

            if (dgViewMF.CurrentRow != null)
            {
                bool bIsClosing = dgViewMF.CurrentRow.Cells["IsClosing"].Value != DBNull.Value ? (bool)dgViewMF.CurrentRow.Cells["IsClosing"].Value : false;

                switch (e.ClickedItem.Name)
                {
                    case "ToolStripMenuItem_FinishFee":
                        if (bIsClosing)//判斷是否關帳
                        {
                            MessageBox.Show("該筆請款記錄已經被關帳，請洽帳務主管", "提示訊息", MessageBoxButtons.OK);
                            return;
                        }

                        US.FeeFinish fee = new LawtechPTSystem.US.FeeFinish();

                        fee.FeeKey = (int)dgViewMF.CurrentRow.Cells["FeeKey"].Value;
                        if (sCaseType == "Pat")
                        {
                            fee.Text = fee.Text + "(專利-" + dgViewMF.CurrentRow.Cells["PatentNo"].Value.ToString() + ")";
                            fee.TypeKind = 1;
                        }
                        else if (sCaseType == "Tm")
                        {
                            fee.Text = fee.Text + "(商標-" + dgViewMF.CurrentRow.Cells["PatentNo"].Value.ToString() + ")";
                            fee.TypeKind = 2;
                        }
                        else if (sCaseType == "CO")//商標異議案
                        {
                            fee.Text = fee.Text + "(商標-" + dgViewMF.CurrentRow.Cells["PatentNo"].Value.ToString() + ")";
                            fee.TypeKind = 2;
                        }

                        fee.DGvr = dgViewMF.CurrentRow;
                        fee.ShowDialog();
                       
                        break;
                    case "ToolStripMenuItem_PatentCompleteHistory"://完整歷程
                        if (sCaseType == "Pat")
                        {
                            ViewFrom.PatentCompleteHistory history = new LawtechPTSystem.ViewFrom.PatentCompleteHistory();
                            history.Gv = dgViewMF;
                            history.Show();
                        }
                        else if (sCaseType == "Tm")
                        {
                            ViewFrom.TrademarkCompleteHistory history = new LawtechPTSystem.ViewFrom.TrademarkCompleteHistory();
                            history.Gv = dgViewMF;
                            history.Show();
                        }
                        else if (sCaseType == "CO")
                        {
                            ViewFrom.TrademarkControversyCompleteHistory history = new LawtechPTSystem.ViewFrom.TrademarkControversyCompleteHistory();
                            history.Gv = dgViewMF;
                            history.Show();
                        }
                        break;
                    case "ToolStripMenuItem_SingOff":

                        if (bIsClosing)//判斷是否關帳
                        {
                            MessageBox.Show("該筆請款記錄已經被關帳，請洽帳務主管", "提示訊息", MessageBoxButtons.OK);
                            return;
                        }

                        if (sCaseType == "Pat")
                        {
                            EditForm.EditPatentFee patentfee = new LawtechPTSystem.EditForm.EditPatentFee();
                            patentfee.property_FeeKEY = (int)dgViewMF.CurrentRow.Cells["FeeKEY"].Value;
                            patentfee.ShowDialog();
                        }
                        else if (sCaseType == "Tm")
                        {
                            EditForm.EditTrademarkFee trademarkfee = new LawtechPTSystem.EditForm.EditTrademarkFee();
                            trademarkfee.property_FeeKEY = (int)dgViewMF.CurrentRow.Cells["FeeKEY"].Value;
                            trademarkfee.ShowDialog();
                        }
                       
                        break;

                    case "toolStripMenuItem_PayDateFinish"://填付款日
                        if (dgViewMF.SelectedRows.Count > 0)
                        {
                            US.FeeFinishDate FeeDate=new LawtechPTSystem.US.FeeFinishDate();

                            if (FeeDate.ShowDialog() == DialogResult.OK)
                            {
                                //複選多筆時
                                for (int iRow = 0; iRow < dgViewMF.SelectedRows.Count; iRow++)
                                {
                                    
                                    bool close=    dgViewMF.SelectedRows[iRow].Cells["IsClosing"].Value != DBNull.Value ? (bool)dgViewMF.SelectedRows[iRow].Cells["IsClosing"].Value : false;
                                    if (close)//判斷是否關帳
                                    {
                                        break;
                                    }


                                    int Feekey = (int)dgViewMF.SelectedRows[iRow].Cells["FeeKEY"].Value;

                                    switch (dgViewMF.SelectedRows[iRow].Cells["CaseType"].Value.ToString())
                                    {
                                        case "Pat":
                                            Public.CPatentFee pat = new Public.CPatentFee();
                                            Public.CPatentFee.ReadOne(Feekey, ref pat);
                                            
                                            pat.Pay = FeeDate.Pro_Pay;
                                            pat.PayDate = FeeDate.CurrentDate;
                                            pat.PayKind = FeeDate.Pro_PayKind;
                                            pat.Update();

                                            break;
                                        case "Tm":
                                            Public.CTrademarkFee TM = new Public.CTrademarkFee();
                                            Public.CTrademarkFee.ReadOne(Feekey,ref TM);
                                            TM.Pay = FeeDate.Pro_Pay;
                                            TM.PayDate = FeeDate.CurrentDate;
                                            TM.PayKind = FeeDate.Pro_PayKind;
                                            TM.Update();
                                            break;
                                        case "CO":
                                            Public.CTrademarkControversyFee CO = new Public.CTrademarkControversyFee("ControversyFeeKEY=" + Feekey.ToString());
                                            CO.SetCurrent(Feekey);
                                            CO.Pay = FeeDate.Pro_Pay;
                                            CO.PayDate = FeeDate.CurrentDate;
                                            CO.PayKind = FeeDate.Pro_PayKind;
                                            CO.Updata(Feekey);
                                            break;
                                    }
                                    if (FeeDate.CurrentDate.Year > 1900)
                                    {
                                        dgViewMF.SelectedRows[iRow].Cells["PayDate"].Value = FeeDate.CurrentDate;
                                    }
                                    else
                                    {
                                        dgViewMF.SelectedRows[iRow].Cells["PayDate"].Value = DBNull.Value;
                                    }

                                    dgViewMF.SelectedRows[iRow].Cells["PayKind"].Value = FeeDate.Pro_PayKind;
                                }

                                MessageBox.Show(string.Format("已完成修改，共 {0} 筆", dgViewMF.SelectedRows.Count.ToString()), "提示訊息");
                            }
                        }
                        else //判斷單筆時
                        {
                            if (bIsClosing)//判斷是否關帳
                            {
                                MessageBox.Show("該筆請款記錄已經被關帳，請洽帳務主管", "提示訊息", MessageBoxButtons.OK);
                                return;
                            }

                           
                            if (dgViewMF.CurrentRow != null)
                            {
                                US.FeeFinishDate FeeDate=new LawtechPTSystem.US.FeeFinishDate();

                                if (FeeDate.ShowDialog() == DialogResult.OK)
                                {
                                    int Feekey = (int)dgViewMF.CurrentRow.Cells["FeeKEY"].Value;

                                    switch (dgViewMF.CurrentRow.Cells["CaseType"].Value.ToString())
                                    {
                                        case "Pat":
                                            Public.CPatentFee pat = new Public.CPatentFee();
                                            Public.CPatentFee.ReadOne(Feekey, ref pat);
                                            
                                            pat.Pay = FeeDate.Pro_Pay;
                                            pat.PayDate = FeeDate.CurrentDate;
                                            pat.Update();

                                            break;
                                        case "Tm":
                                            Public.CTrademarkFee TM = new Public.CTrademarkFee();
                                            Public.CTrademarkFee.ReadOne(Feekey, ref TM);
                                            TM.Pay = FeeDate.Pro_Pay;
                                            TM.PayDate = FeeDate.CurrentDate;
                                            TM.Update();
                                            break;
                                        case "CO":
                                            Public.CTrademarkControversyFee CO = new Public.CTrademarkControversyFee("ControversyFeeKEY=" + Feekey.ToString());
                                            CO.SetCurrent(Feekey);
                                            CO.Pay = FeeDate.Pro_Pay;
                                            CO.PayDate = FeeDate.CurrentDate;
                                            CO.Updata(Feekey);
                                            break;
                                    }


                                    if (FeeDate.CurrentDate.Year > 1900)
                                    {
                                        dgViewMF.CurrentRow.Cells["PayDate"].Value = FeeDate.CurrentDate;
                                    }
                                    else
                                    {
                                        dgViewMF.CurrentRow.Cells["PayDate"].Value = DBNull.Value;
                                    }

                                    dgViewMF.CurrentRow.Cells["PayKind"].Value = FeeDate.Pro_PayKind;

                                    MessageBox.Show(string.Format("已完成修改 \r\n 請款單號【{0}】", dgViewMF.CurrentRow.Cells["PPP"].Value.ToString()), "提示訊息");
                                }
                            }
                        }
                        break;

                    case "toolStripMenuItem_SendMail":
                        if (dgViewMF.CurrentRow != null)
                        {
                            US.NotificationLetter letter = new LawtechPTSystem.US.NotificationLetter();
                            letter.ApplicantKeys = dgViewMF.CurrentRow.Cells["ApplicantKeys"].Value!=DBNull.Value? dgViewMF.CurrentRow.Cells["ApplicantKeys"].Value.ToString():"" ;
                            letter.CaseKey = dgViewMF.CurrentRow.Cells["MainKey"].Value != null ? (int)dgViewMF.CurrentRow.Cells["MainKey"].Value : -1;
                            letter.DelegateType = dgViewMF.CurrentRow.Cells["DelegateType"].Value.ToString() != "" ? (int)dgViewMF.CurrentRow.Cells["DelegateType"].Value : -1;
                            letter.Attorney = dgViewMF.CurrentRow.Cells["AttorneyKey"].Value !=DBNull.Value ? (int)dgViewMF.CurrentRow.Cells["AttorneyKey"].Value : -1;
                            if (sCaseType == "Pat")
                            {
                                letter.EmailSampleType = "PatentFee";
                            }
                            else if (sCaseType == "CO")
                            {
                                letter.EmailSampleType = "TrademarkControversyFee";
                            }
                            else
                            {
                                letter.EmailSampleType = "TrademarkFee";
                            }
                            letter.CaseNo = dgViewMF.CurrentRow.Cells["PatentNo"].Value.ToString();
                            letter.Show();
                        }
                        break;

                    case "ToolStripMenuItem_CaseDetail":
                       
                            if (sCaseType == "Pat")
                            {
                                PatentHistoryRecord1 patent = new LawtechPTSystem.SubFrom.PatentHistoryRecord1();
                                patent.property_PatentID = (int)dgViewMF.CurrentRow.Cells["MainKey"].Value;
                                patent.TabSelectedIndex = 2;
                                patent.Show();
                            }
                            else if (sCaseType == "Tm")
                            {
                                TrademarkHistoryRecord HistoryRecord = new TrademarkHistoryRecord();
                                HistoryRecord.TrademarkID = (int)dgViewMF.CurrentRow.Cells["MainKey"].Value;
                                HistoryRecord.TabSelectedIndex = 4;
                                HistoryRecord.Show();
                            }
                          
                        break;

                    case "toolStripMenuItem_CloseAccount":
                        if (dgViewMF.SelectedRows.Count > 0)
                        {
                            //複選多筆時
                            for (int iRow = 0; iRow < dgViewMF.SelectedRows.Count; iRow++)
                            {
                                int Feekey = (int)dgViewMF.SelectedRows[iRow].Cells["FeeKEY"].Value;

                                switch (dgViewMF.SelectedRows[iRow].Cells["CaseType"].Value.ToString())
                                {
                                    case "Pat":
                                        Public.CPatentFee pat = new Public.CPatentFee();
                                        Public.CPatentFee.ReadOne(Feekey, ref pat);
                                        
                                        pat.IsClosing = true;
                                        pat.CloseDate = DateTime.Now;
                                        pat.Update();

                                        break;
                                    case "Tm":
                                        Public.CTrademarkFee TM = new Public.CTrademarkFee();
                                        Public.CTrademarkFee.ReadOne(Feekey,ref TM);
                                        TM.IsClosing = true;
                                        TM.CloseDate = DateTime.Now;
                                        TM.Update();
                                        break;
                                    case "CO":
                                        Public.CTrademarkControversyFee CO = new Public.CTrademarkControversyFee("ControversyFeeKEY=" + Feekey.ToString());
                                        CO.SetCurrent(Feekey);
                                        CO.IsClosing = true;
                                        CO.CloseDate = DateTime.Now;
                                        CO.Updata(Feekey);
                                        break;
                                }

                                dgViewMF.SelectedRows[iRow].Cells["IsClosing"].Value = true;
                                dgViewMF.SelectedRows[iRow].Cells["CloseDate"].Value = DateTime.Now;
                                
                            }
                            MessageBox.Show(string.Format("已完成關帳，共 {0} 筆", dgViewMF.SelectedRows.Count.ToString()), "提示訊息");
                        }
                        else
                        {
                            //判斷單筆時
                            if (dgViewMF.CurrentRow != null)
                            {
                                int Feekey = (int)dgViewMF.CurrentRow.Cells["FeeKEY"].Value;

                                switch (dgViewMF.CurrentRow.Cells["CaseType"].Value.ToString())
                                {
                                    case "Pat":
                                        Public.CPatentFee pat = new Public.CPatentFee();
                                        Public.CPatentFee.ReadOne(Feekey, ref pat);
                                       
                                        pat.IsClosing = true;
                                        pat.CloseDate = DateTime.Now;
                                        pat.Update();

                                        break;
                                    case "Tm":
                                        Public.CTrademarkFee TM = new Public.CTrademarkFee();
                                        Public.CTrademarkFee.ReadOne(Feekey, ref TM);
                                        TM.IsClosing = true;
                                        TM.CloseDate = DateTime.Now;
                                        TM.Update();
                                        break;
                                    case "CO":
                                        Public.CTrademarkControversyFee CO = new Public.CTrademarkControversyFee("ControversyFeeKEY=" + Feekey.ToString());
                                        CO.SetCurrent(Feekey);
                                        CO.IsClosing = true;
                                        CO.CloseDate = DateTime.Now;
                                        CO.Updata(Feekey);
                                        break;
                                }

                                dgViewMF.CurrentRow.Cells["IsClosing"].Value = true;
                                dgViewMF.CurrentRow.Cells["CloseDate"].Value = DateTime.Now;

                                MessageBox.Show(string.Format("已完成關帳 \r\n 請款單號【{0}】", dgViewMF.CurrentRow.Cells["PPP"].Value.ToString()), "提示訊息");
                            }
                        }
                        break;

                    case "toolStripMenuItem_OpenAccount":
                        if (dgViewMF.SelectedRows.Count > 0)
                        {
                            for (int iRow = 0; iRow < dgViewMF.SelectedRows.Count; iRow++)
                            {
                                int Feekey = (int)dgViewMF.SelectedRows[iRow].Cells["FeeKEY"].Value;
                                switch (dgViewMF.SelectedRows[iRow].Cells["CaseType"].Value.ToString())
                                {
                                    case "Pat":
                                        Public.CPatentFee pat = new Public.CPatentFee();
                                        Public.CPatentFee.ReadOne(Feekey, ref pat);
                                        pat.IsClosing = false;
                                        pat.CloseDate = null;
                                        pat.Update();

                                        break;
                                    case "Tm":
                                        Public.CTrademarkFee TM = new Public.CTrademarkFee();
                                        Public.CTrademarkFee.ReadOne(Feekey,ref TM);
                                        TM.IsClosing = false;
                                        TM.CloseDate =null;
                                        TM.Update();
                                        break;
                                    case "CO":
                                        Public.CTrademarkControversyFee CO = new Public.CTrademarkControversyFee("ControversyFeeKEY=" + Feekey.ToString());
                                        CO.SetCurrent(Feekey);
                                        CO.IsClosing = false;
                                        CO.CloseDate = new DateTime(1900, 1, 1);
                                        CO.Updata(Feekey);
                                        break;
                                }

                                dgViewMF.SelectedRows[iRow].Cells["IsClosing"].Value = false;
                                dgViewMF.SelectedRows[iRow].Cells["CloseDate"].Value = DBNull.Value;
                            }

                            MessageBox.Show(string.Format("已完成開帳，共 {0} 筆", dgViewMF.SelectedRows.Count.ToString()), "提示訊息");
                        }
                        else
                        {
                            //判斷單筆時
                            if (dgViewMF.CurrentRow!=null)
                            {
                                int Feekey = (int)dgViewMF.CurrentRow.Cells["FeeKEY"].Value;

                                switch (dgViewMF.CurrentRow.Cells["CaseType"].Value.ToString())
                                {
                                    case "Pat":
                                        Public.CPatentFee pat = new Public.CPatentFee();
                                        Public.CPatentFee.ReadOne(Feekey, ref pat);
                                        pat.IsClosing = false;
                                        pat.CloseDate = null;
                                        pat.Update();

                                        break;
                                    case "Tm":
                                        Public.CTrademarkFee TM = new Public.CTrademarkFee();
                                        Public.CTrademarkFee.ReadOne(Feekey,ref TM);
                                        TM.IsClosing = false;
                                        TM.CloseDate =null;
                                        TM.Update();
                                        break;
                                    case "CO":
                                        Public.CTrademarkControversyFee CO = new Public.CTrademarkControversyFee("ControversyFeeKEY=" + Feekey.ToString());
                                        CO.SetCurrent(Feekey);
                                        CO.IsClosing = false;
                                        CO.CloseDate = new DateTime(1900, 1, 1);
                                        CO.Updata(Feekey);
                                        break;
                                }

                                dgViewMF.CurrentRow.Cells["IsClosing"].Value = false;
                                dgViewMF.CurrentRow.Cells["CloseDate"].Value = DBNull.Value;

                                MessageBox.Show(string.Format("已完成開帳 \r\n 請款單號【{0}】", dgViewMF.CurrentRow.Cells["PPP"].Value.ToString()), "提示訊息");
                            }
                        }
                        break;
                    case "toolStripMenuItem_App":
                        if (dgViewMF.CurrentRow != null)
                        {
                            ViewFrom.ApplicantList app = new ViewFrom.ApplicantList();
                            string No = "";
                            if (sCaseType == "Tm")
                            {
                                app.MainType = 2;
                                No = dgViewMF.CurrentRow.Cells["TrademarkNo"].Value.ToString();
                                app.MainKey = (int)dgViewMF.CurrentRow.Cells["TrademarkID"].Value;
                            }
                            else
                            {
                                app.MainType = 1;
                                No = dgViewMF.CurrentRow.Cells["PatentNo"].Value.ToString();
                                app.MainKey = (int)dgViewMF.CurrentRow.Cells["PatentID"].Value;
                            }

                            app.Text += $"--{No}";

                            app.Show();
                        }
                        break;

                }
            }

        }

        #region contextMenuStrip_Accounting_Opening
        private void contextMenuStrip_Accounting_Opening(object sender, CancelEventArgs e)
        {
            if (dgViewMF.CurrentRow != null)
            {              
                this.ToolStripMenuItem_FinishFee.Visible = true;
                ToolStripMenuItem_SingOff.Visible = false;
                toolStripMenuItem_CloseAccount.Visible = false;
                toolStripMenuItem_OpenAccount.Visible = false;
                toolStripMenuItem_PayDateFinish.Visible = true;

                if (OfficeRole == 2 || OfficeRole == 3 )
                {
                    ToolStripMenuItem_SingOff.Visible = true;
                    
                }
                else if ( OfficeRole == 4)
                {
                    ToolStripMenuItem_SingOff.Visible = true;
                    toolStripMenuItem_CloseAccount.Visible = true;
                    toolStripMenuItem_OpenAccount.Visible = true;
                }
                else if (OfficeRole == 0)
                {
                    ToolStripMenuItem_SingOff.Visible = true;
                    toolStripMenuItem_CloseAccount.Visible = true;
                    toolStripMenuItem_OpenAccount.Visible = true;
                }
                

            }
            else
            {
                e.Cancel = true;
            }
        }
        #endregion

        #endregion

        #region comboBox_Select_SelectedIndexChanged
        private void comboBox_Select_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            Public.DLL dll = new Public.DLL();
            string strSQL = "";
            if (comboBox_Select.SelectedValue != null)
            {
                switch (comboBox_Select.SelectedValue.ToString())
                {
                    case "CustomerName"://主委託人

                        strSQL = "select ApplicantKey,ApplicantName from ApplicantT order by ApplicantName";
                        dt = dll.SqlDataAdapterDataTable(strSQL);
                        comboBox_SelectValue.DropDownStyle = ComboBoxStyle.DropDown;
                        comboBox_SelectValue.AutoCompleteSource = AutoCompleteSource.ListItems;
                        comboBox_SelectValue.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                        comboBox_SelectValue.DataSource = dt;
                        comboBox_SelectValue.DisplayMember = "ApplicantName";
                        comboBox_SelectValue.ValueMember = "ApplicantKey";
                        comboBox_SelectValue.Text = "";
                        break;
                    case "CountryT.CountrySymbol"://國別
                        strSQL = "select CountrySymbol+'-'+Country as Country,CountrySymbol from CountryT order by SN";
                        dt = dll.SqlDataAdapterDataTable(strSQL);
                        comboBox_SelectValue.DropDownStyle = ComboBoxStyle.DropDown;
                        comboBox_SelectValue.AutoCompleteSource = AutoCompleteSource.ListItems;
                        comboBox_SelectValue.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                        comboBox_SelectValue.DataSource = dt;
                        comboBox_SelectValue.DisplayMember = "Country";
                        comboBox_SelectValue.ValueMember = "CountrySymbol";
                        comboBox_SelectValue.Text = "";
                        break;
                    default:
                        comboBox_SelectValue.AutoCompleteSource = AutoCompleteSource.None;
                        comboBox_SelectValue.AutoCompleteMode = AutoCompleteMode.None;
                        comboBox_SelectValue.DropDownStyle = ComboBoxStyle.Simple;
                        comboBox_SelectValue.Text = "";
                        break;
                }
            }
        }
        #endregion

        #region comboBox_Select1_SelectedIndexChanged
        private void comboBox_Select1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            Public.DLL dll = new Public.DLL();
            string strSQL = "";
            if (comboBox_Select1.SelectedValue != null)
            {
                switch (comboBox_Select1.SelectedValue.ToString())
                {
                    case "CustomerName"://主委託人

                        strSQL = "select ApplicantKey,ApplicantName from ApplicantT order by ApplicantName";
                        dt = dll.SqlDataAdapterDataTable(strSQL);
                        comboBox_SelectValue1.DropDownStyle = ComboBoxStyle.DropDown;
                        comboBox_SelectValue1.AutoCompleteSource = AutoCompleteSource.ListItems;
                        comboBox_SelectValue1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                        comboBox_SelectValue1.DataSource = dt;
                        comboBox_SelectValue1.DisplayMember = "ApplicantName";
                        comboBox_SelectValue1.ValueMember = "ApplicantKey";
                        comboBox_SelectValue1.Text = "";
                        break;
                    case "CountryT.CountrySymbol"://國別
                        strSQL = "select CountrySymbol+'-'+Country as Country,CountrySymbol from CountryT order by SN";
                        dt = dll.SqlDataAdapterDataTable(strSQL);
                        comboBox_SelectValue1.DropDownStyle = ComboBoxStyle.DropDown;
                        comboBox_SelectValue1.AutoCompleteSource = AutoCompleteSource.ListItems;
                        comboBox_SelectValue1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                        comboBox_SelectValue1.DataSource = dt;
                        comboBox_SelectValue1.DisplayMember = "Country";
                        comboBox_SelectValue1.ValueMember = "CountrySymbol";
                        comboBox_SelectValue1.Text = "";
                        break;
                    default:
                        comboBox_SelectValue1.AutoCompleteSource = AutoCompleteSource.None;
                        comboBox_SelectValue1.AutoCompleteMode = AutoCompleteMode.None;
                        comboBox_SelectValue1.DropDownStyle = ComboBoxStyle.Simple;
                        comboBox_SelectValue1.Text = "";
                        break;
                }
            }
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

        #region radioButton_NotFinish_CheckedChanged
        private void radioButton_NotFinish_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            if (rb.Checked)
            {
                but_Search_Click(null, null);
            }
        }
        #endregion

        #region dgViewMF_CellDoubleClick
        private void dgViewMF_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != -1 && e.RowIndex != -1)
            {
                contextMenuStrip_Accounting_ItemClicked(contextMenuStrip_Accounting,new ToolStripItemClickedEventArgs(ToolStripMenuItem_CaseDetail));
            }
        }
        #endregion

        private void dgViewMF_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        
    }

}
