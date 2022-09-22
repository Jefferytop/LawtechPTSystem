using System;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;

namespace LawtechPTSystemByFirm.SubFrom
{
    /// <summary>
    /// 舊版 不要使用
    /// </summary>
    public partial class TrademarkControlEvent : Form
    {
        public TrademarkControlEvent()
        {
            InitializeComponent();
            dgViewMF.AutoGenerateColumns = false;
        }

        private object m_objOpt = System.Reflection.Missing.Value;

        BindingSource bSource_Control;

       

        #region =========資料集=========
        /// <summary>
        /// 事件管制清單資料表
        /// </summary>
        public System.Data.DataTable dt_ControlEvent
        {
            get
            {
                return (System.Data.DataTable)bSource_Control.DataSource;
            }
        }

        /// <summary>
        /// 待處理事件明細資料表
        /// </summary>
        public DataSet_TM.TrademarkWorkReportTDataTable dt_WorkListEvent
        {
            get
            {
                return dataSet_TM.TrademarkWorkReportT;
            }
        }
        #endregion

        #region ==========Property ==========
        /// <summary>
        /// 查詢條件的起始時間
        /// </summary>
        public DateTime SearchStartTime
        {
            get
            {
                DateTime dt;
                bool IsStartTime = DateTime.TryParse(maskedTextBox_OccurDateS.Text, out dt);
                if (!IsStartTime)
                {
                    dt = new DateTime(1900, 1, 1);
                }
                else
                {
                    DateTime dtEnd;
                    bool IsEndTime = DateTime.TryParse(maskedTextBox_OccurDateE.Text, out dtEnd);
                    if (!IsEndTime)
                    {
                        dtEnd = new DateTime(1900, 1, 1);
                    }
                    if (IsStartTime && IsEndTime)
                    {
                        if (dtEnd < dt)
                        {
                            dt = dtEnd;
                        }
                    }
                }

                return dt;

            }
            set
            {
                DateTime dt = value;
                maskedTextBox_OccurDateS.Text = dt.ToString("yyyy/MM/dd");
            }
        }

        /// <summary>
        /// 查詢條件的結束時間
        /// </summary>
        public DateTime SearchEndTime
        {
            get
            {
                DateTime dtEnd;
                bool IsEndTime = DateTime.TryParse(maskedTextBox_OccurDateE.Text, out dtEnd);
                if (!IsEndTime)
                {
                    dtEnd = new DateTime(1900, 1, 1);
                }
                else
                {
                    DateTime dt;
                    bool IsStartTime = DateTime.TryParse(maskedTextBox_OccurDateS.Text, out dt);
                    if (!IsStartTime)
                    {
                        dt = new DateTime(1900, 1, 1);
                    }
                    if (IsStartTime && IsEndTime)
                    {
                        if (dtEnd < dt)
                        {
                            dtEnd = dt;
                        }
                    }
                }

                return dtEnd;

            }
            set
            {
                DateTime dt = value;
                maskedTextBox_OccurDateE.Text = dt.ToString("yyyy/MM/dd");
            }
        }

        private int iOfficeRole = -1;
        /// <summary>
        /// 登入者的權限身份 1.員工 2.專利主管 3.商標主管 4.帳務主管 0.admin
        /// </summary>
        public int OfficeRole
        {
            get { return iOfficeRole; }
            set { iOfficeRole = value; }
        }

        private int iWorkerID = -1;
        /// <summary>
        /// 登入者ID
        /// </summary>
        public int WorkerID
        {
            get { return iWorkerID; }
            set { iWorkerID = value; }
        }

        private string strWorkerName = "";
        /// <summary>
        /// 登入者的名字
        /// </summary>
        public string Property_WorkerName
        {
            get { return strWorkerName; }
            set { strWorkerName = value; }
        }

       

        private decimal decPatentControlPeriodTime = 0;
        /// <summary>
        /// 商標延展管制的時間
        /// </summary>
        public decimal TrademarkControlPeriodTime
        {
            get { return decPatentControlPeriodTime; }
            set { decPatentControlPeriodTime = value; }
        }

        #endregion 

        #region PATControlEvent_Load 、 PATControlEvent_FormClosed
        private void TrademarkControlEvent_Load(object sender, EventArgs e)
        {
            
            this.tMSelectDateModeControl_DropTableAdapter.Fill(this.dataSet_TM.TMSelectDateModeControl_Drop);
            
            Public.PublicForm Forms = new LawtechPTSystemByFirm.Public.PublicForm();
            Forms.TrademarkControlEvent = this;

            //取得登入者身份
            iWorkerID = Properties.Settings.Default.WorkerKEY;
            Worker_Model worker = new Worker_Model();
            Worker_Model.ReadOne(iWorkerID, ref  worker);
          
            iOfficeRole = worker.OfficeRole.Value;
            strWorkerName = worker.EmployeeName;

            bSource_Control = new BindingSource();
            dgViewMF.DataSource = bSource_Control;
            bindingNavigator1.BindingSource = bSource_Control;

            Public.DLL dll = new LawtechPTSystemByFirm.Public.DLL();
            TrademarkControlPeriodTime = dll.GetTrademarkControlPeriodTime;

            butQuery_Click(null, null);
        }

        private void TrademarkControlEvent_FormClosed(object sender, FormClosedEventArgs e)
        {
            Public.PublicForm Forms = new LawtechPTSystemByFirm.Public.PublicForm();
            Forms.TrademarkControlEvent = null;
        }
        #endregion

        #region ============butQuery_Click============
        private void butQuery_Click(object sender, EventArgs e)
        {
            butQuery.Enabled = false;
            string strFilter = "";
            string strWhere1 = "";
            string strWhere2 = "";

            if (chb_Finish.Checked && !chb_NoFinish.Checked) //已完成
            {
                strFilter += " and FinishDate is not null ";
            }
            else if (!chb_Finish.Checked && chb_NoFinish.Checked)//未完成
            {
                strFilter += " and FinishDate is null ";
            }

            //日期條件
            string strSeachDate = cb_SearchDate.SelectedValue.ToString();           

            string times = "";
            DateTime dtStartTime = SearchStartTime;
            DateTime dtEndTime = SearchEndTime;

            //事件發生日
            if (dtStartTime.Year != 1900 && dtEndTime.Year ==1900)
            {
                times += " and "+strSeachDate+">='" + maskedTextBox_OccurDateS.Text + "' ";
            }
            else if (dtStartTime.Year == 1900 && dtEndTime.Year != 1900)
            {
                times += " and " + strSeachDate + "<='" + maskedTextBox_OccurDateE.Text + " 23:59' ";
            }
            else if (dtStartTime.Year != 1900 && dtEndTime.Year != 1900)
            {
                times += string.Format(" and (" + strSeachDate + " >= '{0}' and " + strSeachDate + " <= '{1} 23:59'  ) ", dtStartTime.ToString("yyyy/MM/dd"), dtEndTime.ToString("yyyy/MM/dd"));
            }

            #region strWhere1
            string selectValue=((LawtechPTSystemByFirm.Public.CCombox)(searchMainByTM1.comboBox1.SelectedItem)).ValueString;
            ComboBox cbValue = searchMainByTM1.comboBox2;
            switch (selectValue)
            {
                case "ApplicantNames"://申請人
                case "AttorneyRefNo": //對方案號
                case "ApplicationNo":  //申請案號
                case "TrademarkName":  //申請案名稱
                case "TrademarkNo"://本所案號
                    if (cbValue.Text.Trim() != "")
                    {
                        strWhere1 = string.Format(" {0} like '%{1}%'", selectValue, cbValue.Text.Trim());
                    }
                    break;
                case "CountrySymbol"://國別
                    if (cbValue.SelectedValue != null)
                    {
                        strWhere1 = string.Format(" {0}='{1}'", selectValue, cbValue.SelectedValue.ToString());
                    }                  
                    break;
                case "DelegateType":
                case "WorkerKey": //案件承辦人
                case "Status": //申請案階段                        
                    if (cbValue.SelectedValue != null)
                    {
                        strWhere1 = string.Format(" {0}={1}", selectValue, cbValue.SelectedValue.ToString());
                    }
                    break;
            }
            #endregion 

            #region strWhere2
            string selectValue2 = ((LawtechPTSystemByFirm.Public.CCombox)(searchMainByTM2.comboBox1.SelectedItem)).ValueString;
            ComboBox cbValue2 = searchMainByTM2.comboBox2;
            switch (selectValue2)
            {
                case "ApplicantNames"://申請人
                case "AttorneyRefNo": //對方案號
                case "ApplicationNo":  //申請案號
                case "TrademarkName":  //申請案名稱
                case "TrademarkNo"://本所案號
                    if (cbValue2.Text.Trim() != "")
                        strWhere2 = string.Format(" {0} like '%{1}%'", selectValue2, cbValue2.Text.Trim());
                    break;
                case "Country"://國別
                    if (cbValue2.SelectedValue != null)
                    {
                        strWhere2 = string.Format(" {0}='{1}'", selectValue2, cbValue2.SelectedValue.ToString());
                    }
                    break;
                case "DelegateType":
                case "WorkerKey": //案件承辦人
                case "Status": //申請案階段                        
                    if (cbValue2.SelectedValue != null)
                    {
                        strWhere2 = string.Format(" {0}={1}", selectValue2, cbValue2.SelectedValue.ToString());
                    }
                    break;
            }
            #endregion 


            string FullFilter = "";
            if (strWhere1 != "" && strWhere2 != "")
            {
                string AndOr = "";
                if (rb_and.Checked)
                {
                    AndOr = " and ";
                    FullFilter = strWhere1 + AndOr + strWhere2;
                }
                else
                {
                    AndOr = " or ";
                    FullFilter = "(" + strWhere1 + AndOr + strWhere2 + ")";
                }

            }
            else if (strWhere1 == "" && strWhere2 == "")
            {
                FullFilter = "";
            }
            else
            {
                if (strWhere1 != "")
                {
                    FullFilter = strWhere1;
                }
                else
                {
                    FullFilter = strWhere2;
                }
            }


            string[] sWhere = { strFilter,times, FullFilter };

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

            DataBind_TrademarkEvent(FullWhere.ToString());

            butQuery.Enabled = true; ;
        }
        #endregion

        #region DataBind_TrademarkEvent
        public void DataBind_TrademarkEvent(string strWhere)
        {
            bSource_Control.DataSource = null;
            dgViewMF.Columns["SingCode"].Visible = false;
            dgViewMF.Columns["PPP"].Visible = false;
            dgViewMF.Columns["FeePhase"].Visible = false;
            dgViewMF.Columns["IMoney"].Visible = false;
            dgViewMF.Columns["Totall"].Visible = false;

            if (radB_all.Checked)//全部
            {                
                
                //System.Data.DataTable dt_NotifyEvent = GetNotifyEvent(strWhere);               
                //System.Data.DataTable dt_FeeEvent = GetFeeEvent(strWhere);
                //System.Data.DataTable dt_PaymentEvent = GetPaymentEvent(strWhere);
                //System.Data.DataTable dt_ExtendedEvent = GetExtendedDate(strWhere);

                //if (dt_ExtendedEvent.Rows.Count > 0)
                //    dt_NotifyEvent.Merge(dt_ExtendedEvent);

                //if (dt_FeeEvent.Rows.Count > 0)
                //    dt_NotifyEvent.Merge(dt_FeeEvent);

                //if (dt_PaymentEvent.Rows.Count > 0)
                //    dt_NotifyEvent.Merge(dt_PaymentEvent);

                //bSource_Control.DataSource = dt_NotifyEvent;
            } 
            else if(rado_Notify.Checked)//案件記錄
            {
                dgViewMF.Columns["DueDate"].HeaderText = "官方期限";

                System.Data.DataTable dt_NotifyEvent = GetNotifyEvent(strWhere);
                bSource_Control.DataSource = dt_NotifyEvent;

               
            }
            else if (rado_ExtendedDate.Checked)//可辦延展的商標
            {
                try
                {
                   

                    dgViewMF.Columns["DueDate"].HeaderText = "專用期限(官方)";

                    System.Data.DataTable dt_ExtendedEvent = GetExtendedDate(strWhere);
                    bSource_Control.DataSource = dt_ExtendedEvent;

                   
                }
                catch (System.Exception EX)
                {
                    string ss = EX.Message;
                }
            }
            else if (rado_Fee.Checked)//請款
            {
                try
                {
                    dgViewMF.Columns["SingCode"].Visible = true;
                    dgViewMF.Columns["PPP"].Visible = true;
                    dgViewMF.Columns["FeePhase"].Visible = true;

                    dgViewMF.Columns["DueDate"].HeaderText = "收據日期(官方)";

                    System.Data.DataTable dt_FeeEvent = GetFeeEvent(strWhere);
                    bSource_Control.DataSource = dt_FeeEvent;
                }
                catch (System.Exception EX)
                {
                    string ss=EX.Message;
                }
            }
            else if (radio_Payment.Checked)//付款
            {
                dgViewMF.Columns["SingCode"].Visible = true;
                dgViewMF.Columns["PPP"].Visible = true;
                dgViewMF.Columns["FeePhase"].Visible = true;
                dgViewMF.Columns["IMoney"].Visible = true;
                dgViewMF.Columns["Totall"].Visible = true;


                dgViewMF.Columns["DueDate"].HeaderText = "付款期限(官方)";

                System.Data.DataTable dt_PaymentEvent = GetPaymentEvent(strWhere);
                bSource_Control.DataSource = dt_PaymentEvent;
            }
            else
            {
                //System.Data.DataTable dt_NotifyEvent = GetNotifyEvent(strWhere);
                //bSource_Control.DataSource = dt_NotifyEvent;
            }


        }
        #endregion

        #region GetNotifyEvent 取得案件記錄的資料
        /// <summary>
        /// 取得案件記錄的資料
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public System.Data.DataTable GetNotifyEvent(string strWhere)
        {

            if (cb_SearchDate.SelectedValue.ToString() == "ComitDate")
            {
                strWhere = strWhere.Replace("ComitDate", " TrademarkNotifyEventT.NotifyComitDate");
            }
            else if (cb_SearchDate.SelectedValue.ToString() == "OfficeDueDate")
            {
                strWhere = strWhere.Replace("OfficeDueDate", "TrademarkNotifyEventT.AttorneyDueDate");
            }
            else
            {
                strWhere = strWhere.Replace("LastModifyDate", "TrademarkNotifyEventT.LastModifyDate");               
            }

            strWhere = strWhere.Replace("FinishDate", "TrademarkNotifyEventT.FinishDate");


             //異議案
            string strWhereControversy = strWhere.Replace("TrademarkNotifyEventT", "TrademarkControversyNotifyEventT");

            string strNotifyEventSQL = string.Format(
                                    @"SELECT         'TM' AS TableTypeName, TrademarkManagementT.TrademarkID, CountryT.CountrySymbol,
                  TrademarkManagementT.TrademarkNo, TrademarkNo,TrademarkManagementT.MainCustomerRefNo,
                  TrademarkManagementT.TrademarkName, TrademarkManagementT.CountrySymbol, 
                  TrademarkManagementT.StyleName, TrademarkManagementT.TMTypeName, 
                  TMStatusT.Status, TrademarkManagementT.StatusExplain, 
                  WorkerT.EmployeeName AS WorkerName, CountryT.Country AS CountryName, 
                  TrademarkNotifyEventT.TMNotifyEventID AS EventID, 
                  TrademarkNotifyEventT.NotifyEventContent AS EventContent, 
                  TrademarkNotifyEventT.NotifyComitDate AS ComitDate, 
                  TrademarkNotifyEventT.AttorneyDueDate AS OfficeDueDate, 
                  TrademarkNotifyEventT.DueDate,
				  TrademarkNotifyEventT.FinishDate, 
                  '案件記錄' AS EventTypeName, 1 AS EventType, 
                  CASE TrademarkManagementT.DelegateType WHEN 1 THEN '客戶直接委託' WHEN
                   2 THEN '複代委託' END AS DelegateTypeName, 
                  CASE WHEN TrademarkNotifyEventT.FinishDate IS NULL THEN DATEDIFF(day,GETDATE(), ISNULL(TrademarkNotifyEventT.DueDate, GETDATE())) 
                  WHEN TrademarkNotifyEventT.FinishDate IS NOT NULL THEN NULL 
                  END AS DiffDueDate, TrademarkNotifyEventT.Result, 
                  TrademarkNotifyEventT.LastModifyDateTime, 
                  TrademarkManagementT.ApplicantNames, 
                  TrademarkManagementT.ApplicantKeys,
				  WorkerT_1.EmployeeName AS LastModifyWorker, 
                  TrademarkManagementT.OutsourcingTrademarkNo, 
                  TrademarkManagementT.ApplicationDate, 
                  TrademarkManagementT.ApplicationNo,
				  isnull(convert(nvarchar(30), TrademarkManagementT.NoticeDate1 ,111),'') as NoticeDate1,
                  TrademarkManagementT.NoticeNo1,
				  isnull(convert(nvarchar(30),TrademarkManagementT.NoticeDate,111),'') as NoticeDate, 
                  TrademarkManagementT.NoticeNo, 
				TrademarkManagementT.RegistrationDate, 
                  TrademarkManagementT.RegistrationNo
FROM         WorkerT RIGHT OUTER JOIN
                      TrademarkNotifyEventT ON WorkerT.WorkerKey = TrademarkNotifyEventT.WorkerKey LEFT OUTER JOIN
                      TrademarkManagementT LEFT OUTER JOIN
                      AttorneyT ON TrademarkManagementT.OutsourcingAttorney = AttorneyT.AttorneyKey ON 
                      TrademarkNotifyEventT.TrademarkID = TrademarkManagementT.TrademarkID LEFT OUTER JOIN
                      WorkerT AS WorkerT_1 ON TrademarkNotifyEventT.LastModifyWorker = WorkerT_1.WorkerKey LEFT OUTER JOIN
                      CountryT ON TrademarkManagementT.CountrySymbol = CountryT.CountrySymbol LEFT OUTER JOIN
                      TMStatusT ON TrademarkManagementT.Status = TMStatusT.TMStatusID
WHERE     (TrademarkManagementT.CloseDate IS NULL)  {0}
UNION
SELECT  'CO' AS TableTypeName, 
          TrademarkControversyManagementT.TrademarkControversyID AS TrademarkID,  CountryT.CountrySymbol,
          TrademarkControversyManagementT.TrademarkNo, TrademarkNo,TrademarkControversyManagementT. MainCustomerRefNo,
          TrademarkControversyManagementT.TrademarkName, 
          TrademarkControversyManagementT.CountrySymbol, 
          TrademarkControversyManagementT.StyleName, TrademarkControversyManagementT.TMTypeName, 
          TMStatusT.Status, TrademarkControversyManagementT.StatusExplain, 
          WorkerT_1.EmployeeName AS WorkerName, CountryT.Country AS CountryName, 
          TrademarkControversyNotifyEventT.TMNotifyControversyEventID AS EventID, 
          TrademarkControversyNotifyEventT.NotifyEventContent AS EventContent, 
          TrademarkControversyNotifyEventT.NotifyComitDate AS ComitDate, 
          TrademarkControversyNotifyEventT.AttorneyDueDate AS OfficeDueDate, 
          TrademarkControversyNotifyEventT.DueDate, 
          TrademarkControversyNotifyEventT.FinishDate,
		 '案件記錄' AS EventTypeName, 
          1 AS EventType, 
          CASE TrademarkControversyManagementT.DelegateType WHEN 1 THEN '客戶直接委託'
           WHEN 2 THEN '複代委託' END AS DelegateTypeName, 
          CASE WHEN TrademarkControversyNotifyEventT.FinishDate IS NULL  THEN DATEDIFF(day, GETDATE(), ISNULL(TrademarkControversyNotifyEventT.DueDate, GETDATE())) 
          WHEN TrademarkControversyNotifyEventT.FinishDate IS NOT NULL THEN NULL
           END AS DiffDueDate, 
          TrademarkControversyNotifyEventT.Result, 
          TrademarkControversyNotifyEventT.LastModifyDate, 
          TrademarkControversyManagementT.ApplicantNames, 
          TrademarkControversyManagementT.ApplicantKeys, 
		  WorkerT.EmployeeName AS LastModifyWorker,
          TrademarkControversyManagementT.OutsourcingTrademarkNo, 
          TrademarkControversyManagementT.ApplicationDate, 
          TrademarkControversyManagementT.ApplicationNo,
		 '' AS NoticeDate1, 
         '' AS NoticeNo1,
		 '' AS NoticeDate,
		 '' AS NoticeNo, 
          TrademarkControversyManagementT.RegistrationDate, 
          TrademarkControversyManagementT.RegistrationNo          
FROM         WorkerT RIGHT OUTER JOIN
                      WorkerT AS WorkerT_1 RIGHT OUTER JOIN
                      TrademarkControversyNotifyEventT ON WorkerT_1.WorkerKey = TrademarkControversyNotifyEventT.WorkerKey ON 
                      WorkerT.WorkerKey = TrademarkControversyNotifyEventT.LastModifyWorker LEFT OUTER JOIN
                      AttorneyT RIGHT OUTER JOIN
                      TrademarkControversyManagementT ON AttorneyT.AttorneyKey = TrademarkControversyManagementT.OutsourcingAttorney LEFT OUTER JOIN
                      CountryT ON TrademarkControversyManagementT.CountrySymbol = CountryT.CountrySymbol LEFT OUTER JOIN
                      TMStatusT ON TrademarkControversyManagementT.Status = TMStatusT.TMStatusID ON 
                      TrademarkControversyNotifyEventT.TrademarkControversyID = TrademarkControversyManagementT.TrademarkControversyID
WHERE     (TrademarkControversyManagementT.CloseDate IS NULL) {1}
                                ", strWhere, strWhereControversy);

            Public.DLL dll = new LawtechPTSystemByFirm.Public.DLL();
            System.Data.DataTable dtNotifyEvent = new System.Data.DataTable();
            dll.FetchDataTable(strNotifyEventSQL, dtNotifyEvent);  

            return dtNotifyEvent;
        }
        #endregion

        #region GetExtendedDate 取得可辦延展的資料
        /// <summary>
        /// 取得商標可辦延展的資料
        /// 在專用期間6個月前管制 以【法定期限 LawDate】欄位
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public System.Data.DataTable GetExtendedDate(string strWhere)
        {

            if (cb_SearchDate.SelectedValue.ToString() == "ComitDate")
            {
                strWhere = strWhere.Replace("ComitDate", "DateAdd(month,-"+this.TrademarkControlPeriodTime.ToString("###0")+",TrademarkManagementT.LawDate)");
            }
            else if (cb_SearchDate.SelectedValue.ToString() == "OfficeDueDate")
            {
                strWhere = strWhere.Replace("OfficeDueDate", "TrademarkManagementT.ExtendedDate");
            }
            else
            {
                strWhere = strWhere.Replace("LastModifyDate", "TrademarkManagementT.LastModifyDate");               
            }
            strWhere = strWhere.Replace("FinishDate is not null", " (DateAdd(month,-" + this.TrademarkControlPeriodTime.ToString("###0") + ",TrademarkManagementT.LawDate)>getdate())").Replace("FinishDate is null", " (DateAdd(month,-" + this.TrademarkControlPeriodTime.ToString("###0") + ",TrademarkManagementT.LawDate)<getdate())");

            string strExtendedDateSQL = string.Format(
                                    @"SELECT   'TM' as TableTypeName,  TrademarkManagementT.TrademarkID,  CountryT.CountrySymbol,
		                                           TrademarkManagementT.TrademarkNo,TrademarkManagementT. MainCustomerRefNo,
                                                   TrademarkManagementT.TrademarkName, 
                                                   TrademarkManagementT.CountrySymbol,
                                                   TrademarkManagementT.StyleName, 
                                                   TrademarkManagementT.TMTypeName,
                                                   TMStatusT.Status, 
                                                   TrademarkManagementT.StatusExplain,		                                           
		                                           WorkerT.EmployeeName AS WorkerName,
		                                           CountryT.Country AS CountryName,
                                                   TrademarkManagementT.TrademarkID as EventID, 
                                                   TrademarkManagementT.TrademarkNo+' 可辦延展' as EventContent, 
                                                   TrademarkManagementT.RegistrationDate as ComitDate,
                                                   DateAdd(month,-{1},TrademarkManagementT.LawDate) as OfficeDueDate,
                                                   TrademarkManagementT.LawDate as DueDate,  
                                                   case when (DateAdd(month,-{1},TrademarkManagementT.LawDate)>getdate()) then TrademarkManagementT.LawDate else null end as FinishDate,
                                                   '可辦延展' AS EventTypeName,
                                                   4 AS EventType, 
                                                   CASE TrademarkManagementT.DelegateType WHEN 1 THEN '客戶直接委託' WHEN 2 THEN '複代委託' END AS DelegateTypeName, 
                                                   CASE WHEN (DateAdd(month,-{1},TrademarkManagementT.LawDate)<getdate()) THEN DATEDIFF(day, GETDATE(), TrademarkManagementT.LawDate )  
                                                   WHEN (DateAdd(month,-{1},TrademarkManagementT.LawDate)>getdate()) THEN NULL END AS DiffDueDate,
                                                   TrademarkManagementT.Remarks as Result,
                                                   TrademarkManagementT.LastModifyDate,                                                  
                                                  TrademarkManagementT.ApplicantNames, 
                                                  TrademarkManagementT.ApplicantKeys,
				                                  WorkerT.EmployeeName AS LastModifyWorker, 
                                                  TrademarkManagementT.OutsourcingTrademarkNo, 
                                                  TrademarkManagementT.ApplicationDate, 
                                                  TrademarkManagementT.ApplicationNo,
				                                  isnull(convert(nvarchar(30), TrademarkManagementT.NoticeDate1 ,111),'') as NoticeDate1,
                                                  TrademarkManagementT.NoticeNo1,
				                                  isnull(convert(nvarchar(30),TrademarkManagementT.NoticeDate,111),'') as NoticeDate, 
                                                  TrademarkManagementT.NoticeNo, 
				                                  TrademarkManagementT.RegistrationDate, 
                                                  TrademarkManagementT.RegistrationNo
                                       FROM         TrademarkManagementT LEFT OUTER JOIN
                                                  WorkerT ON TrademarkManagementT.LastModifyWorker = WorkerT.WorkerKey LEFT OUTER JOIN
                                                  AttorneyT ON TrademarkManagementT.OutsourcingAttorney = AttorneyT.AttorneyKey LEFT OUTER JOIN
                                                  CountryT ON TrademarkManagementT.CountrySymbol = CountryT.CountrySymbol LEFT OUTER JOIN
                                                  WorkerT AS WorkerT_1 ON TrademarkManagementT.WorkerKey = WorkerT_1.WorkerKey LEFT OUTER JOIN
                                                  TMStatusT ON TrademarkManagementT.Status = TMStatusT.TMStatusID
                                        WHERE         (TrademarkManagementT.CloseDate IS NULL) 
                                                   {0}", strWhere, this.TrademarkControlPeriodTime.ToString("###0"));

            Public.DLL dll = new LawtechPTSystemByFirm.Public.DLL();
            System.Data.DataTable dtExtendedEvent = new System.Data.DataTable();
            dll.FetchDataTable(strExtendedDateSQL, dtExtendedEvent);
            return dtExtendedEvent;
        }
        #endregion

        #region GetFeeEvent 取得請款的資料
        /// <summary>
        /// 取得請款的資料
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public System.Data.DataTable GetFeeEvent(string strWhere)
        {

            if (cb_SearchDate.SelectedValue.ToString() == "ComitDate")//事件日
            {
                strWhere = strWhere.Replace("ComitDate", "TrademarkFeeT.RDate");
            }
            else if (cb_SearchDate.SelectedValue.ToString() == "OfficeDueDate")
            {
                strWhere = strWhere.Replace("OfficeDueDate", "TrademarkFeeT.RDate");
            }
            else if (cb_SearchDate.SelectedValue.ToString() == "DueDate")//官方期限
            {
                strWhere = strWhere.Replace("DueDate", "ReceiptDate");
            }
            else
            {                
                strWhere = strWhere.Replace("LastModifyDate", "TrademarkFeeT.LastModifyDate");
            }

            strWhere = strWhere.Replace("FinishDate is not null", "TrademarkFeeT.Pay=1").Replace("FinishDate is null", " (TrademarkFeeT.Pay<>1) ");

            //異議案
            string strWhereControversy = strWhere.Replace("TrademarkFeeT", "TrademarkControversyFeeT");

            string strFeeEventSQL = string.Format(
                                    @"SELECT  'TM' AS TableTypeName, TrademarkManagementT.TrademarkID,  CountryT.CountrySymbol,
                                          TrademarkManagementT.TrademarkNo, TrademarkManagementT.MainCustomerRefNo,
                                          TrademarkManagementT.TrademarkName, TrademarkManagementT.CountrySymbol, 
                                          TrademarkManagementT.StyleName, TrademarkManagementT.TMTypeName, 
                                          TMStatusT.Status, TrademarkManagementT.StatusExplain, 
                                          WorkerT_1.EmployeeName AS WorkerName, CountryT.Country AS CountryName, 
                                          TrademarkFeeT.FeeKEY AS EventID, 
                                          TrademarkFeeT.FeeSubject AS EventContent, 
                                          TrademarkFeeT.RDate AS ComitDate, TrademarkFeeT.RDate AS OfficeDueDate, 
                                          ISNULL(DATEADD(dd, 30, TrademarkFeeT.RDate), NULL) AS DueDate, 
                                          CASE TrademarkFeeT.Pay WHEN 1 THEN TrademarkFeeT.PayDate ELSE NULL 
                                          END AS FinishDate, '請款' AS EventTypeName, 2 AS EventType, 
                                          CASE TrademarkManagementT.DelegateType WHEN 1 THEN '客戶直接委託' WHEN
                                           2 THEN '複代委託' END AS DelegateTypeName, 
                                          CASE TrademarkFeeT.Pay WHEN 0 THEN DATEDIFF(day, GETDATE(),ISNULL(TrademarkFeeT.ReceiptDate, GETDATE())) WHEN NULL THEN DATEDIFF(day,GETDATE(), ISNULL(TrademarkFeeT.ReceiptDate, GETDATE())) WHEN 1 THEN NULL 
                                          END AS DiffDueDate, TrademarkFeeT.Remark AS Result, 
                                          TrademarkFeeT.LastModifyDate, TrademarkManagementT.ApplicantNames, 
                                          TrademarkManagementT.ApplicantKeys, WorkerT.EmployeeName AS LastModifyWorker, 
                                          TrademarkManagementT.OutsourcingTrademarkNo, 
                                          TrademarkManagementT.ApplicationDate, 
                                          TrademarkManagementT.ApplicationNo,
		                                  isnull(convert(nvarchar(30), TrademarkManagementT.NoticeDate1 ,111),'') as NoticeDate1,  
                                          TrademarkManagementT.NoticeNo1,
		                                  isnull(convert(nvarchar(30), TrademarkManagementT.NoticeDate ,111),'') as NoticeDate, 
                                          TrademarkManagementT.NoticeNo,
                                          TrademarkManagementT.RegistrationDate, 
                                          TrademarkManagementT.RegistrationNo,TrademarkFeeT.PayDate,
	                                      TrademarkFeeT.SingCode,
		                                  TrademarkFeeT.ReceiptDate,
		                                  TrademarkFeeT.PPP, 
                                          FeePhaseT.FeePhase
                                        FROM         WorkerT RIGHT OUTER JOIN
                                              WorkerT AS WorkerT_1 RIGHT OUTER JOIN
                                              TrademarkFeeT ON WorkerT_1.WorkerKey = TrademarkFeeT.FClientTransactor LEFT OUTER JOIN
                                              FeePhaseT ON TrademarkFeeT.FeePhase = FeePhaseT.FeePhaseID ON WorkerT.WorkerKey = TrademarkFeeT.LastModifyWorker LEFT OUTER JOIN
                                              AttorneyT RIGHT OUTER JOIN
                                              TrademarkManagementT ON AttorneyT.AttorneyKey = TrademarkManagementT.OutsourcingAttorney LEFT OUTER JOIN
                                              CountryT ON TrademarkManagementT.CountrySymbol = CountryT.CountrySymbol LEFT OUTER JOIN
                                              TMStatusT ON TrademarkManagementT.Status = TMStatusT.TMStatusID ON TrademarkFeeT.TrademarkID = TrademarkManagementT.TrademarkID 
                                        WHERE     (TrademarkManagementT.CloseDate IS NULL) {0}
                                       UNION
                                    SELECT  'CO' AS TableTypeName, 
                                      TrademarkControversyManagementT.TrademarkControversyID AS TrademarkID,  CountryT.CountrySymbol,
                                      TrademarkControversyManagementT.TrademarkNo, TrademarkControversyManagementT.MainCustomerRefNo,
                                      TrademarkControversyManagementT.TrademarkName, 
                                      TrademarkControversyManagementT.CountrySymbol, 
                                      TrademarkControversyManagementT.StyleName, TrademarkControversyManagementT.TMTypeName, 
                                      TMStatusT.Status, TrademarkControversyManagementT.StatusExplain, 
                                      WorkerT_1.EmployeeName AS WorkerName, CountryT.Country AS CountryName, 
                                      TrademarkControversyFeeT.ControversyFeeKEY AS EventID, 
                                      TrademarkControversyFeeT.FeeSubject AS EventContent, 
                                      TrademarkControversyFeeT.RDate AS ComitDate, 
                                      TrademarkControversyFeeT.RDate AS OfficeDueDate, ISNULL(DATEADD(dd, 30, 
                                      TrademarkControversyFeeT.RDate), NULL) AS DueDate, 
                                      CASE TrademarkControversyFeeT.Pay WHEN 1 THEN TrademarkControversyFeeT.PayDate
                                       ELSE NULL END AS FinishDate, '請款' AS EventTypeName, 2 AS EventType, 
                                      CASE TrademarkControversyManagementT.DelegateType WHEN 1 THEN '客戶直接委託'
                                       WHEN 2 THEN '複代委託' END AS DelegateTypeName, 
                                      CASE TrademarkControversyFeeT.Pay WHEN 0 THEN DATEDIFF(day,GETDATE(), ISNULL(TrademarkControversyFeeT.ReceiptDate, GETDATE())) 
                                      WHEN NULL THEN DATEDIFF(day, GETDATE(),ISNULL(TrademarkControversyFeeT.ReceiptDate, GETDATE())) WHEN 1 THEN NULL  END AS DiffDueDate,
                                      TrademarkControversyFeeT.Remark AS Result, 
                                      TrademarkControversyFeeT.LastModifyDate, 
                                      TrademarkControversyManagementT.ApplicantNames, 
                                      TrademarkControversyManagementT.ApplicantKeys, 
                                      WorkerT.EmployeeName AS LastModifyWorker, 
                                      TrademarkControversyManagementT.OutsourcingTrademarkNo, 
                                      TrademarkControversyManagementT.ApplicationDate, 
                                      TrademarkControversyManagementT.ApplicationNo, 
	                                 '' AS NoticeDate1, 
	                                 '' AS NoticeNo1,
	                                 '' AS NoticeDate,
	                                 '' AS NoticeNo, 
                                      TrademarkControversyManagementT.RegistrationDate,                                      
	                                  TrademarkControversyManagementT.RegistrationNo,
	                                  TrademarkControversyFeeT.PayDate,
	                                  TrademarkControversyFeeT.SingCode, 
	                                  TrademarkControversyFeeT.ReceiptDate,
                                      TrademarkControversyFeeT.PPP, FeePhaseT.FeePhase
                                FROM         TrademarkControversyManagementT RIGHT OUTER JOIN
                      TrademarkControversyFeeT ON 
                      TrademarkControversyManagementT.TrademarkControversyID = TrademarkControversyFeeT.TrademarkControversyID LEFT OUTER JOIN
                      WorkerT AS WorkerT_1 ON TrademarkControversyFeeT.FClientTransactor = WorkerT_1.WorkerKey LEFT OUTER JOIN
                      FeePhaseT ON TrademarkControversyFeeT.FeePhase = FeePhaseT.FeePhaseID LEFT OUTER JOIN
                      WorkerT ON TrademarkControversyFeeT.LastModifyWorker = WorkerT.WorkerKey LEFT OUTER JOIN
                      AttorneyT ON TrademarkControversyManagementT.OutsourcingAttorney = AttorneyT.AttorneyKey LEFT OUTER JOIN
                      CountryT ON TrademarkControversyManagementT.CountrySymbol = CountryT.CountrySymbol LEFT OUTER JOIN
                      TMStatusT ON TrademarkControversyManagementT.Status = TMStatusT.TMStatusID
                    WHERE     (TrademarkControversyManagementT.CloseDate IS NULL) {1}

                                                ", strWhere, strWhereControversy);

            Public.DLL dll = new LawtechPTSystemByFirm.Public.DLL();
            System.Data.DataTable dtFeeEvent = new System.Data.DataTable();
            dll.FetchDataTable(strFeeEventSQL, dtFeeEvent);
            return dtFeeEvent;
        }
        #endregion

        #region GetPaymentEvent 取得付款的資料
        /// <summary>
        /// 取得付款的資料
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public System.Data.DataTable GetPaymentEvent(string strWhere)
        {
            if (cb_SearchDate.SelectedValue.ToString() == "ComitDate")
            {
                strWhere = strWhere.Replace("ComitDate", "TrademarkPaymentT.ReciveDate");
            }
            else if (cb_SearchDate.SelectedValue.ToString() == "OfficeDueDate")//本所期限
            {
                strWhere = strWhere.Replace("OfficeDueDate", " TrademarkPaymentT.PayDueDate");
            }
            else if (cb_SearchDate.SelectedValue.ToString() == "DueDate")//官方期限
            {
                strWhere = strWhere.Replace("DueDate", "TrademarkPaymentT.PayDueDate");
            }
            else
            {
                strWhere = strWhere.Replace("LastModifyDate", "TrademarkPaymentT.LastModifyDate");
            }

            strWhere = strWhere.Replace("FinishDate", "TrademarkPaymentT.IReceiptDate");

            //異議案
            string strWhereControversy = strWhere.Replace("TrademarkPaymentT", "TrademarkControversyPaymentT");


            string strFeeEventSQL = string.Format(
@"SELECT         'TM' AS TableTypeName, TrademarkManagementT.TrademarkID,  CountryT.CountrySymbol,
                          TrademarkManagementT.TrademarkNo, 
                          TrademarkManagementT.MainCustomerRefNo, 
                          TrademarkManagementT.TrademarkName, TrademarkManagementT.CountrySymbol, 
                          TrademarkManagementT.StyleName, TrademarkManagementT.TMTypeName, 
                          TMStatusT.Status, TrademarkManagementT.StatusExplain, 
                          WorkerT_1.EmployeeName AS WorkerName, CountryT.Country AS CountryName, 
                          TrademarkPaymentT.PaymentID AS EventID, 
                          TrademarkPaymentT.FeeSubject AS EventContent, 
                          TrademarkPaymentT.ReciveDate AS ComitDate, 
                          TrademarkPaymentT.PayDueDate AS OfficeDueDate, 
                          TrademarkPaymentT.PayDueDate AS DueDate, 
                          TrademarkPaymentT.IReceiptDate AS FinishDate, '付款' AS EventTypeName, 
                          3 AS EventType, 
                          CASE TrademarkManagementT.DelegateType WHEN 1 THEN '客戶直接委託' WHEN
                           2 THEN '複代委託' END AS DelegateTypeName, 
                          CASE WHEN TrademarkPaymentT.IReceiptDate IS NULL THEN DATEDIFF(day, 
                          GETDATE(), ISNULL(TrademarkPaymentT.PayDueDate, GETDATE())) ELSE NULL 
                          END AS DiffDueDate, TrademarkPaymentT.Remark AS Result, 
                          TrademarkPaymentT.LastModifyDate, 
                          TrademarkManagementT.ApplicantNames, 
                          TrademarkManagementT.ApplicantKeys,
                          TrademarkManagementT.OutsourcingTrademarkNo, 
                          TrademarkManagementT.ApplicationDate, 
                          TrademarkManagementT.ApplicationNo,
                          isnull(convert(nvarchar(30), TrademarkManagementT.NoticeDate1 ,111),'') as NoticeDate1,  
                          TrademarkManagementT.NoticeNo1,
                          isnull(convert(nvarchar(30), TrademarkManagementT.NoticeDate ,111),'') as NoticeDate, 
                          TrademarkManagementT.NoticeNo,
                          TrademarkPaymentT.BillingNo AS PPP,
                           TrademarkPaymentT.SingCode, TrademarkPaymentT.Totall, 
                          TrademarkPaymentT.IMoney, FeePhaseT.FeePhase, 
                          TrademarkManagementT.OutsourcingTrademarkNo, 
                          WorkerT.EmployeeName AS LastModifyWorker
FROM             TrademarkManagementT INNER JOIN
                          TrademarkPaymentT ON 
                          TrademarkManagementT.TrademarkID = TrademarkPaymentT.TrademarkID LEFT
                           OUTER JOIN
                          WorkerT ON 
                          TrademarkPaymentT.LastModifyWorker = WorkerT.WorkerKey LEFT OUTER JOIN
                          FeePhaseT ON 
                          TrademarkPaymentT.FeePhase = FeePhaseT.FeePhaseID LEFT OUTER JOIN
                          WorkerT AS WorkerT_1 ON 
                          TrademarkPaymentT.FClientTransactor = WorkerT_1.WorkerKey LEFT OUTER JOIN
                          AttorneyT ON 
                          TrademarkManagementT.OutsourcingAttorney = AttorneyT.AttorneyKey LEFT OUTER
                           JOIN
                          CountryT ON 
                          TrademarkManagementT.CountrySymbol = CountryT.CountrySymbol LEFT OUTER JOIN
                          TMStatusT ON TrademarkManagementT.Status = TMStatusT.TMStatusID
WHERE         (TrademarkManagementT.CloseDate IS NULL) {0}
                                    UNION
                                    SELECT         'CO' AS TableTypeName, 
                          TrademarkControversyManagementT.TrademarkControversyID AS TrademarkID,  CountryT.CountrySymbol,
                          TrademarkControversyManagementT.TrademarkNo, 
                          TrademarkControversyManagementT.MainCustomerRefNo, 
                          TrademarkControversyManagementT.TrademarkName, 
                          TrademarkControversyManagementT.CountrySymbol, 
                          TrademarkControversyManagementT.StyleName, 
                          TrademarkControversyManagementT.TMTypeName, TMStatusT.Status, 
                          TrademarkControversyManagementT.StatusExplain, 
                          WorkerT.EmployeeName AS WorkerName, CountryT.Country AS CountryName, 
                          TrademarkControversyPaymentT.ControversyPaymentID AS EventID, 
                          TrademarkControversyPaymentT.FeeSubject AS EventContent, 
                          TrademarkControversyPaymentT.ReciveDate AS ComitDate, 
                          TrademarkControversyPaymentT.PayDueDate AS OfficeDueDate, 
                          TrademarkControversyPaymentT.PayDueDate AS DueDate, 
                          TrademarkControversyPaymentT.IReceiptDate AS FinishDate, 
                          '付款' AS EventTypeName, 3 AS EventType, 
                          CASE TrademarkControversyManagementT.DelegateType WHEN 1 THEN '客戶直接委託'
                           WHEN 2 THEN '複代委託' END AS DelegateTypeName, 
                          CASE WHEN TrademarkControversyPaymentT.IReceiptDate IS NULL 
                          THEN DATEDIFF(day, GETDATE(), 
                          ISNULL(TrademarkControversyPaymentT.PayDueDate, GETDATE())) ELSE NULL 
                          END AS DiffDueDate, TrademarkControversyPaymentT.Remark AS Result, 
                          TrademarkControversyPaymentT.LastModifyDate, 
                          TrademarkControversyManagementT.ApplicantNames, 
                          TrademarkControversyManagementT.ApplicantKeys,
                          TrademarkControversyManagementT.OutsourcingTrademarkNo, 
                          TrademarkControversyManagementT.ApplicationDate, 
                          TrademarkControversyManagementT.ApplicationNo, 
                         '' AS NoticeDate1, 
                         '' AS NoticeNo1,
                         '' AS NoticeDate,
                         '' AS NoticeNo, 
                          TrademarkControversyPaymentT.BillingNo AS PPP, 
                          TrademarkControversyPaymentT.SingCode, 
                          TrademarkControversyPaymentT.Totall, 
                          TrademarkControversyPaymentT.IMoney, FeePhaseT.FeePhase, 
                          TrademarkControversyManagementT.OutsourcingTrademarkNo, 
                          WorkerT_1.EmployeeName AS LastModifyWorker
FROM             WorkerT AS WorkerT_1 RIGHT OUTER JOIN
                          TrademarkControversyPaymentT ON 
                          WorkerT_1.WorkerKey = TrademarkControversyPaymentT.LastModifyWorker LEFT
                           OUTER JOIN
                          WorkerT ON 
                          TrademarkControversyPaymentT.FClientTransactor = WorkerT.WorkerKey LEFT OUTER
                           JOIN
                          TrademarkControversyManagementT ON 
                          TrademarkControversyPaymentT.TrademarkControversyID = TrademarkControversyManagementT.TrademarkControversyID
                           LEFT OUTER JOIN
                          FeePhaseT ON 
                          TrademarkControversyPaymentT.FeePhase = FeePhaseT.FeePhaseID LEFT OUTER
                           JOIN
                          AttorneyT ON 
                          TrademarkControversyManagementT.OutsourcingAttorney = AttorneyT.AttorneyKey
                           LEFT OUTER JOIN
                          CountryT ON 
                          TrademarkControversyManagementT.CountrySymbol = CountryT.CountrySymbol LEFT OUTER
                           JOIN
                          TMStatusT ON 
                          TrademarkControversyManagementT.Status = TMStatusT.TMStatusID
WHERE         (TrademarkControversyManagementT.CloseDate IS NULL) {1}", strWhere, strWhereControversy);

            Public.DLL dll = new LawtechPTSystemByFirm.Public.DLL();
            System.Data.DataTable dtFeeEvent = new System.Data.DataTable();
            dll.FetchDataTable(strFeeEventSQL, dtFeeEvent);
            return dtFeeEvent;
        }
        #endregion

        private void butClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region =========匯出Excel 按鈕=========
        private void butExport_Click(object sender, EventArgs e)
        {

           
        }
        #endregion       

        #region =============相關文件=============
        private void toolStripLabel_UpdateFileList_Click(object sender, EventArgs e)
        {
            if (dgViewMF.CurrentRow != null)
            {
                 string sTable = dgViewMF.CurrentRow.Cells["TableTypeName"].Value.ToString();
                 if (sTable == "TM")
                 {
                     ViewUpdateFileList subForm = new ViewUpdateFileList();
                     subForm.Text = dgViewMF.CurrentRow.Cells["TrademarkNo"].Value.ToString() + "的申請案相關文件";
                     subForm.FileKind = 4;
                     subForm.FileType = 6;
                     subForm.MainParentID = (int)dgViewMF.CurrentRow.Cells["TrademarkID"].Value;
                     subForm.ShowDialog();
                 }
                 else
                 {
                     ViewUpdateFileList subForm = new ViewUpdateFileList();
                     subForm.Text = dgViewMF.CurrentRow.Cells["TrademarkNo"].Value.ToString() + "的申請案相關文件";
                     subForm.FileKind = 5;
                     subForm.FileType = 10;
                     subForm.MainParentID = (int)dgViewMF.CurrentRow.Cells["TrademarkID"].Value;
                     subForm.ShowDialog();
                 }
            }
        }
        #endregion

        #region =============商標詳細資料=============
        private void toolStripLabel_TrademarkView_Click(object sender, EventArgs e)
        {
            if (dgViewMF.CurrentRow != null)
            {
                string sTable = dgViewMF.CurrentRow.Cells["TableTypeName"].Value.ToString();
               if (sTable == "TM")
               {
                   TrademarkHistoryRecord HistoryRecord = new TrademarkHistoryRecord();
                   HistoryRecord.TrademarkID = (int)dgViewMF.CurrentRow.Cells["TrademarkID"].Value;
                   if (rado_Notify.Checked)
                   {
                       HistoryRecord.TabSelectedIndex = 1;
                   }
                   else if (rado_ExtendedDate.Checked)
                   {
                       HistoryRecord.TabSelectedIndex = 0;
                   }
                   else if (rado_Fee.Checked)
                   {
                       HistoryRecord.TabSelectedIndex = 3;
                   }
                   else
                   {
                       HistoryRecord.TabSelectedIndex = 4;
                   }
                   HistoryRecord.Show();
               }
               else//異議案
               {
                   TrademarkControversyHistoryRecord HistoryRecord = new TrademarkControversyHistoryRecord();

                   HistoryRecord.TrademarkControversyID = (int)dgViewMF.CurrentRow.Cells["TrademarkID"].Value;
                   if (rado_Notify.Checked)
                   {
                       HistoryRecord.TabSelectedIndex = 1;
                   }
                   else if (rado_ExtendedDate.Checked)
                   {
                       HistoryRecord.TabSelectedIndex = 0;
                   }
                   else if (rado_Fee.Checked)
                   {
                       HistoryRecord.TabSelectedIndex = 3;
                   }
                   else
                   {
                       HistoryRecord.TabSelectedIndex = 4;
                   }
                   HistoryRecord.Show();
               }
            }
        }
        #endregion      

        #region ============contextMenuMain_Opening============
        private void contextMenuMain_Opening(object sender, CancelEventArgs e)
        {
            if (dgViewMF.CurrentRow != null)
            {               
                this.toolStripMenuItem_NotFinish.Visible = false;
                this.來函直接歸檔ToolStripMenuItem.Visible = false;
                this.ToolStripMenuItem_NotifyFinish.Visible = false;
                this.ToolStripMenuItem_FinishFee.Visible = false;
                this.ToolStripMenuItem_PaymentFinish.Visible = false;
                this.ToolStripMenuItem_ExtendedFinish.Visible = false;
                this.toolStripMenuItem_SetControlTime.Visible = false;
                this.toolStripMenuItem_PaymentSingCode.Visible = false;
               
                if (dgViewMF.CurrentRow.Cells["FinishDate"].Value.GetType().ToString() != "System.DBNull")
                {
                    this.toolStripMenuItem_NotFinish.Visible = true;
                }
                else
                {
                    if (dgViewMF.CurrentRow.Cells["EventKind"].Value.ToString() == "1")  //來函
                    {
                        this.來函直接歸檔ToolStripMenuItem.Visible = true;
                        this.ToolStripMenuItem_NotifyFinish.Visible = true;

                    }
                    else if (dgViewMF.CurrentRow.Cells["EventKind"].Value.ToString() == "2")  //請款
                    {
                        if (OfficeRole == 3 || OfficeRole == 0)
                        {
                            //請款功能
                            this.ToolStripMenuItem_FinishFee.Visible = true;
                        }
                    }
                    else if (dgViewMF.CurrentRow.Cells["EventKind"].Value.ToString() == "3")//付款
                    {
                        if (OfficeRole == 3 || OfficeRole == 0)
                        {
                            toolStripMenuItem_PaymentSingCode.Visible = true;
                            this.ToolStripMenuItem_PaymentFinish.Visible = true;
                        }
                    }
                    else //可辦延展
                    {
                        this.ToolStripMenuItem_ExtendedFinish.Visible = true;
                        this.toolStripMenuItem_SetControlTime.Visible = true;
                    }

                }
            }
            else
            {
                e.Cancel = true;
            }

        }
        #endregion

        #region contextMenuStrip1_Opening
        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (dataGridView_WorkList.CurrentRow != null)
            {
                if ((bool)dataGridView_WorkList.CurrentRow.Cells["IsStart"].Value)
                {
                    if (dataGridView_WorkList.CurrentRow.Cells["EndTime"].FormattedValue.ToString() == "")
                    {
                        ToolStripMenuItem_Finish.Visible = true;
                    }
                    else
                    {
                        ToolStripMenuItem_Finish.Visible = false;
                    }
                    ToolStripMenuItem_Start.Visible = false;
                }
                else
                {
                    ToolStripMenuItem_Finish.Visible = false;
                    ToolStripMenuItem_Start.Visible = true;
                }
            }
            else
            {
                ToolStripMenuItem_Finish.Visible = false;
                ToolStripMenuItem_Start.Visible = false;
            }
        }
        #endregion

        #region  dgViewMF 快顯選單、相關事件
        private void contextMenuMain_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            contextMenuMain.Visible = false;

            switch (e.ClickedItem.Name)
            {

                case "來函直接歸檔ToolStripMenuItem":  //來函直接歸檔

                    if (dgViewMF.CurrentRow.Cells["EventKind"].Value.ToString() != "" && (int)dgViewMF.CurrentRow.Cells["EventKind"].Value == 1)
                    {

                        if (MessageBox.Show("是否確定直接歸檔?", "提示訊息", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            if (dgViewMF.CurrentRow.Cells["TableTypeName"].Value.ToString() == "TM")
                            {
                                Public.CTrademarkNotifyEvent NotifyEvent = new Public.CTrademarkNotifyEvent();
                                Public.CTrademarkNotifyEvent.ReadOne((int)dgViewMF.CurrentRow.Cells["EventID"].Value, ref NotifyEvent);
                               

                                NotifyEvent.FinishDate = DateTime.Now;

                                NotifyEvent.Result = DateTime.Now.ToString("yyyy/MM/dd") + " 直接歸檔";

                                NotifyEvent.LastModifyWorker = Properties.Settings.Default.WorkerName;

                                NotifyEvent.Update();

                                dgViewMF.CurrentRow.Cells["FinishDate"].Value = NotifyEvent.FinishDate;

                                System.Data.DataTable dt = (System.Data.DataTable)bSource_Control.DataSource;

                                dt.AcceptChanges();
                            }
                            else//異議案
                            {
                                Public.CTrademarkControversyNotifyEvent NotifyEvent = new Public.CTrademarkControversyNotifyEvent("TMNotifyControversyEventID=" + dgViewMF.CurrentRow.Cells["EventID"].Value.ToString());

                                NotifyEvent.SetCurrent((int)dgViewMF.CurrentRow.Cells["EventID"].Value);

                                NotifyEvent.FinishDate = DateTime.Now;

                                NotifyEvent.Result = DateTime.Now.ToString("yyyy/MM/dd") + " 直接歸檔";

                                NotifyEvent.LastModifyDate = DateTime.Now;

                                NotifyEvent.LastModifyWorker = Properties.Settings.Default.WorkerKEY;

                                NotifyEvent.Updata((int)dgViewMF.CurrentRow.Cells["EventID"].Value);

                                dgViewMF.CurrentRow.Cells["FinishDate"].Value = NotifyEvent.FinishDate;

                                System.Data.DataTable dt = (System.Data.DataTable)bSource_Control.DataSource;

                                dt.AcceptChanges();
                            }

                            MessageBox.Show("該案件記錄已完成歸檔", "提示訊息", MessageBoxButtons.OK);
                        }
                    }

                    break;

                case "ToolStripMenuItem_NotifyFinish"://來函已完成處理
                    if (dgViewMF.CurrentRow.Cells["EventKind"].Value.ToString() != "" && (int)dgViewMF.CurrentRow.Cells["EventKind"].Value == 1)
                    {
                        US.TrademarkNotifyFinish NotifyFinish = new LawtechPTSystemByFirm.US.TrademarkNotifyFinish();
                        NotifyFinish.TmNotifyEventID = (int)dgViewMF.CurrentRow.Cells["EventID"].Value;                        
                        NotifyFinish.DGvr = dgViewMF.CurrentRow;
                        NotifyFinish.TableTypeName = dgViewMF.CurrentRow.Cells["TableTypeName"].Value.ToString();
                        NotifyFinish.ShowDialog();
                    }
                    break;



                case "toolStripMenuItem_NotFinish":
                    if (MessageBox.Show("是否確定變更為【未完成處理的事件】?", "提示訊息", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        switch ((int)dgViewMF.CurrentRow.Cells["EventKind"].Value)
                        {
                            case 1:
                                int iComitEventID = (int)dgViewMF.CurrentRow.Cells["EventID"].Value;
                                Public.CPatComitEvent Comit = new Public.CPatComitEvent();
                                Public.CPatComitEvent.ReadOne(iComitEventID, ref Comit);
                                
                                Comit.FinishDate = null;
                                Comit.Result = DateTime.Now.ToString("yyyy/MM/dd") + " 變更為未完成事件";
                                Comit.Update();
                                dgViewMF.CurrentRow.Cells["FinishDate"].Value = System.DBNull.Value;
                                dt_ControlEvent.AcceptChanges();
                                break;

                            case 2:
                                int iEventID = (int)dgViewMF.CurrentRow.Cells["EventID"].Value;
                                Public.CPatNotifyEvent NotifyEvent = new Public.CPatNotifyEvent("PatNotifyEventID=" + iEventID.ToString());
                                NotifyEvent.SetCurrent(iEventID);
                                NotifyEvent.FinishDate = DateTime.Parse("1900/1/1");
                                NotifyEvent.NotifyResult = DateTime.Now.ToString("yyyy/MM/dd") + " 變更為未完成事件";
                                NotifyEvent.Updata(iEventID);

                                dgViewMF.CurrentRow.Cells["FinishDate"].Value = System.DBNull.Value;
                                dt_ControlEvent.AcceptChanges();
                                break;
                        }
                    }
                    break;

                case "ToolStripMenuItem_FinishFee"://請款簽核
                   
                    if (dgViewMF.CurrentRow.Cells["EventKind"].Value.ToString() != "" && (int)dgViewMF.CurrentRow.Cells["EventKind"].Value == 2)
                    {
                        if (dgViewMF.CurrentRow.Cells["TableTypeName"].Value.ToString() == "TM")
                        {
                            int iFeeKEY = (int)dgViewMF.CurrentRow.Cells["EventID"].Value;
                            Public.CTrademarkFee TmFee = new LawtechPTSystemByFirm.Public.CTrademarkFee();
                            Public.CTrademarkFee.ReadOne(iFeeKEY, ref TmFee);

                            if (TmFee.IsClosing.HasValue && TmFee.IsClosing.Value)//判斷是否關帳
                            {
                                MessageBox.Show("該筆請款單號【" + TmFee.PPP + "】已被關帳，請洽帳務主管", "提示訊息", MessageBoxButtons.OK);
                                return;
                            }

                            if (TmFee.PPP!=null && TmFee.PPP != "")//判斷是否已登入請款單號
                            {
                                MessageBox.Show("已登錄了請款單號【" + TmFee.PPP + "】，若要修改，請洽帳務人員", "提示訊息", MessageBoxButtons.OK);
                                return;
                            }

                            //判斷是否有人使用中
                            int iLocker = Public.Utility.GetRecordAuth("TrademarkFeeT", "FeeKEY=" + dgViewMF.CurrentRow.Cells["EventID"].Value.ToString());
                            if (iLocker == -1 || iLocker == iWorkerID)
                            {
                                if (iLocker != iWorkerID)
                                {
                                    Public.Utility.LockRecordAuth("TrademarkFeeT", iWorkerID, "FeeKEY=" + dgViewMF.CurrentRow.Cells["EventID"].Value.ToString());
                                }

                                EditForm.EditTrademarkFee edit = new LawtechPTSystemByFirm.EditForm.EditTrademarkFee();
                                edit.property_FeeKEY = (int)dgViewMF.CurrentRow.Cells["EventID"].Value;
                                edit.CountrySymbol = dgViewMF.CurrentRow.Cells["CountrySymbol"].Value.ToString();
                                if (edit.ShowDialog() == DialogResult.OK)
                                {
                                    Public.CTrademarkFee fee = new LawtechPTSystemByFirm.Public.CTrademarkFee();
                                    Public.CTrademarkFee.ReadOne(iFeeKEY,ref fee);
                                    dgViewMF.CurrentRow.Cells["SingCode"].Value = fee.SingCode;

                                }

                                Public.Utility.NuLockRecordAuth("TrademarkFeeT", "FeeKEY=" + dgViewMF.CurrentRow.Cells["EventID"].Value.ToString());
                            }
                            else
                            {

                                Worker_Model manager = new Worker_Model();
                                Worker_Model.ReadOne(iLocker, ref  manager);

                                MessageBox.Show("很抱歉~~   目前該筆資料正被【" + manager.EmployeeName + "】使用中，請等候!!\r\n 謝謝", "提示訊息");
                            }
                        }
                        else
                        {

                            int iFeeKEY = (int)dgViewMF.CurrentRow.Cells["EventID"].Value;
                            Public.CTrademarkControversyFee TmFee = new LawtechPTSystemByFirm.Public.CTrademarkControversyFee("ControversyFeeKEY=" + dgViewMF.CurrentRow.Cells["EventID"].Value.ToString());
                            TmFee.SetCurrent(iFeeKEY);

                            if (TmFee.IsClosing)//判斷是否關帳
                            {
                                MessageBox.Show("該筆請款單號【" + TmFee.PPP + "】已被關帳，請洽帳務主管", "提示訊息", MessageBoxButtons.OK);
                                return;
                            }

                            if (TmFee.PPP != "")//判斷是否已登入請款單號
                            {
                                MessageBox.Show("已登錄了請款單號【" + TmFee.PPP + "】，若要修改，請洽帳務人員", "提示訊息", MessageBoxButtons.OK);
                                return;
                            }

                            //判斷是否有人使用中
                            int iLocker = Public.Utility.GetRecordAuth("TrademarkControversyFeeT", "ControversyFeeKEY=" + dgViewMF.CurrentRow.Cells["EventID"].Value.ToString());
                            if (iLocker == -1 || iLocker == iWorkerID)
                            {
                                if (iLocker != iWorkerID)
                                {
                                    Public.Utility.LockRecordAuth("TrademarkControversyFeeT", iWorkerID, "ControversyFeeKEY=" + dgViewMF.CurrentRow.Cells["EventID"].Value.ToString());
                                }

                                EditForm.EditTrademarkControversyFee edit = new LawtechPTSystemByFirm.EditForm.EditTrademarkControversyFee();
                                edit.property_FeeKEY = (int)dgViewMF.CurrentRow.Cells["EventID"].Value;
                                edit.CountrySymbol = dgViewMF.CurrentRow.Cells["CountrySymbol"].Value.ToString();
                                if (edit.ShowDialog() == DialogResult.OK)
                                {
                                    Public.CTrademarkControversyFee fee = new LawtechPTSystemByFirm.Public.CTrademarkControversyFee("ControversyFeeKEY=" + iFeeKEY.ToString());
                                    fee.SetCurrent(iFeeKEY);
                                    dgViewMF.CurrentRow.Cells["SingCode"].Value = fee.SingCode;
                                }

                                Public.Utility.NuLockRecordAuth("TrademarkControversyFeeT", "ControversyFeeKEY=" + dgViewMF.CurrentRow.Cells["EventID"].Value.ToString());
                            }
                            else
                            {
                                Worker_Model worker = new Worker_Model();
                                Worker_Model.ReadOne(iLocker, ref  worker);

                                MessageBox.Show("很抱歉~~   目前該筆資料正被【" + worker.EmployeeName + "】使用中，請等候!!\r\n 謝謝", "提示訊息");
                            }
                        }
                    }
                    break;
                case "toolStripMenuItem_PaymentSingCode"://付款簽核
                    if (dgViewMF.CurrentRow.Cells["EventKind"].Value.ToString() != "" && (int)dgViewMF.CurrentRow.Cells["EventKind"].Value == 3)
                    {
                        if (dgViewMF.CurrentRow.Cells["TableTypeName"].Value.ToString() == "TM")
                        {
                            int iFeeKEY = (int)dgViewMF.CurrentRow.Cells["EventID"].Value;
                            Public.CTrademarkPayment TmPay = new LawtechPTSystemByFirm.Public.CTrademarkPayment();
                            Public.CTrademarkPayment.ReadOne(iFeeKEY, ref TmPay);



                            if (TmPay.IsClosing.HasValue && TmPay.IsClosing.Value)//判斷是否關帳
                            {
                                MessageBox.Show("該筆請款單號【" + TmPay.BillingNo + "】已被關帳，請洽帳務主管", "提示訊息", MessageBoxButtons.OK);
                                return;
                            }

                            if (TmPay.BillingNo!=null && TmPay.BillingNo != "")//判斷是否已登入請款單號
                            {
                                MessageBox.Show("已登錄了請款單號【" + TmPay.BillingNo + "】，若要修改，請洽帳務人員", "提示訊息", MessageBoxButtons.OK);
                                return;
                            }

                            //判斷是否有人使用中
                            int iLocker = Public.Utility.GetRecordAuth("TrademarkPaymentT", "PaymentID=" + dgViewMF.CurrentRow.Cells["EventID"].Value.ToString());
                            if (iLocker == -1 || iLocker == iWorkerID)
                            {
                                if (iLocker != iWorkerID)
                                {
                                    Public.Utility.LockRecordAuth("TrademarkPaymentT", iWorkerID, "PaymentID=" + dgViewMF.CurrentRow.Cells["EventID"].Value.ToString());
                                }

                                EditForm.EditTrademarkPayment edit = new LawtechPTSystemByFirm.EditForm.EditTrademarkPayment();
                                edit.property_PaymentID = (int)dgViewMF.CurrentRow.Cells["EventID"].Value;
                                edit.CountrySymbol = dgViewMF.CurrentRow.Cells["CountrySymbol"].Value.ToString();
                                if (edit.ShowDialog() == DialogResult.OK)
                                {
                                    Public.CTrademarkPayment TmPay1 = new LawtechPTSystemByFirm.Public.CTrademarkPayment();
                                    Public.CTrademarkPayment.ReadOne(iFeeKEY, ref TmPay1);                                   
                                    dgViewMF.CurrentRow.Cells["SingCode"].Value = TmPay1.SingCode;

                                }

                                Public.Utility.NuLockRecordAuth("TrademarkFeeT", "FeeKEY=" + dgViewMF.CurrentRow.Cells["EventID"].Value.ToString());
                            }
                            else
                            {
                                Worker_Model worker = new Worker_Model();
                                Worker_Model.ReadOne(iLocker, ref  worker);

                                MessageBox.Show("很抱歉~~   目前該筆資料正被【" + worker.EmployeeName + "】使用中，請等候!!\r\n 謝謝", "提示訊息");
                            }
                        }
                        else
                        {

                            int iFeeKEY = (int)dgViewMF.CurrentRow.Cells["EventID"].Value;
                            Public.CTrademarkControversyPayment TmFee = new LawtechPTSystemByFirm.Public.CTrademarkControversyPayment("ControversyPaymentID=" + dgViewMF.CurrentRow.Cells["EventID"].Value.ToString());
                            TmFee.SetCurrent(iFeeKEY);

                            if (TmFee.IsClosing)//判斷是否關帳
                            {
                                MessageBox.Show("該筆請款單號【" + TmFee.BillingNo + "】已被關帳，請洽帳務主管", "提示訊息", MessageBoxButtons.OK);
                                return;
                            }

                            if (TmFee.BillingNo != "")//判斷是否已登入請款單號
                            {
                                MessageBox.Show("已登錄了請款單號【" + TmFee.BillingNo + "】，若要修改，請洽帳務人員", "提示訊息", MessageBoxButtons.OK);
                                return;
                            }

                            //判斷是否有人使用中
                            int iLocker = Public.Utility.GetRecordAuth("TrademarkControversyPaymentT", "ControversyPaymentID=" + dgViewMF.CurrentRow.Cells["EventID"].Value.ToString());
                            if (iLocker == -1 || iLocker == iWorkerID)
                            {
                                if (iLocker != iWorkerID)
                                {
                                    Public.Utility.LockRecordAuth("TrademarkControversyPaymentT", iWorkerID, "ControversyPaymentID=" + dgViewMF.CurrentRow.Cells["EventID"].Value.ToString());
                                }

                                EditForm.EditTrademarkControversyPayment edit = new LawtechPTSystemByFirm.EditForm.EditTrademarkControversyPayment();
                                edit.property_PaymentID = (int)dgViewMF.CurrentRow.Cells["EventID"].Value;
                                edit.CountrySymbol = dgViewMF.CurrentRow.Cells["CountrySymbol"].Value.ToString();
                                if (edit.ShowDialog() == DialogResult.OK)
                                {
                                    Public.CTrademarkControversyFee fee = new LawtechPTSystemByFirm.Public.CTrademarkControversyFee("ControversyPaymentID=" + iFeeKEY.ToString());
                                    fee.SetCurrent(iFeeKEY);
                                    dgViewMF.CurrentRow.Cells["SingCode"].Value = fee.SingCode;

                                }

                                Public.Utility.NuLockRecordAuth("TrademarkControversyPaymentT", "ControversyPaymentID=" + dgViewMF.CurrentRow.Cells["EventID"].Value.ToString());
                            }
                            else
                            {
                                Worker_Model worker = new Worker_Model();
                                Worker_Model.ReadOne(iLocker, ref  worker);

                                MessageBox.Show("很抱歉~~   目前該筆資料正被【" + worker.EmployeeName + "】使用中，請等候!!\r\n 謝謝", "提示訊息");
                            }
                        }
                    }
                    break;
                case "ToolStripMenuItem_PaymentFinish"://已完成付款確認
                    if (dgViewMF.CurrentRow.Cells["EventKind"].Value.ToString() != "" && (int)dgViewMF.CurrentRow.Cells["EventKind"].Value == 3)
                    {
                        US.PaymentFinish payFinish = new LawtechPTSystemByFirm.US.PaymentFinish();
                        payFinish.PaymentID = (int)dgViewMF.CurrentRow.Cells["EventID"].Value;
                        if (dgViewMF.CurrentRow.Cells["TableTypeName"].Value.ToString() == "TM")
                        {
                            payFinish.TypeKind = 2;
                        }
                        else
                        {
                            payFinish.TypeKind = 3;
                        }
                        payFinish.DGvr = dgViewMF.CurrentRow;
                        payFinish.ShowDialog();
                    }
                    break;

                case "ToolStripMenuItem_ExtendedFinish":
                    if (dgViewMF.CurrentRow.Cells["EventKind"].Value.ToString() != "" && (int)dgViewMF.CurrentRow.Cells["EventKind"].Value == 4)
                    {
                        US.TrademarkExtendFinish ExtendFinish = new LawtechPTSystemByFirm.US.TrademarkExtendFinish();
                        ExtendFinish.TrademarkKey = (int)dgViewMF.CurrentRow.Cells["EventID"].Value;
                        ExtendFinish.DGvr = dgViewMF.CurrentRow;
                        ExtendFinish.ShowDialog();
                    }
                    break;

                    //延展管制時間
                case "toolStripMenuItem_SetControlTime":
                    US.TrademarkControlPeriod controlperiod = new LawtechPTSystemByFirm.US.TrademarkControlPeriod();
                    if (controlperiod.ShowDialog() == DialogResult.OK)
                    {
                       TrademarkControlPeriodTime = controlperiod.Trademarkcontrol;
                    }
                    break;
            }
        }

        private void dgViewMF_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            
            e.Cancel = false;
        }

        private void dgViewMF_SelectionChanged(object sender, EventArgs e)
        {
            if (dgViewMF.CurrentRow != null)
            {
                this.trademarkWorkReportTTableAdapter.Fill(dataSet_TM.TrademarkWorkReportT, (int)dgViewMF.CurrentRow.Cells["EventKind"].Value, (int)dgViewMF.CurrentRow.Cells["EventID"].Value);
            }
        }
        #endregion

        #region dataGridView_WorkList 快顯選單
        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            contextMenuStrip1.Visible = false;

            switch (e.ClickedItem.Name)
            {
                case "bindingNavigatorAddNewItem":
                case "ToolStripMenuItem_Add":
                    if (dgViewMF.CurrentRow != null)
                    {
                        AddFrom.AddTrademarkWorkEvent Add = new LawtechPTSystemByFirm.AddFrom.AddTrademarkWorkEvent();
                        Add.EventID = (int)dgViewMF.CurrentRow.Cells["EventID"].Value;
                        Add.EventType = (int)dgViewMF.CurrentRow.Cells["EventKind"].Value;
                        Add.ShowDialog();
                    }
                    break;

                case "bindingNavigatorDeleteItem":
                case "StripMenuItem_Del":
                    if (dataGridView_WorkList.CurrentRow != null)
                    {
                        if (MessageBox.Show("是否確定刪除", "確認視窗", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            int iWorkReportID = (int)dataGridView_WorkList.CurrentRow.Cells["WorkReportID"].Value;
                            Public.CTrademarkWorkReport DelWorkDetail = new Public.CTrademarkWorkReport();
                            DelWorkDetail.Delete(iWorkReportID);
                            dataGridView_WorkList.Rows.Remove(dataGridView_WorkList.CurrentRow);
                          
                            MessageBox.Show("刪除待處理明細成功", "提示訊息", MessageBoxButtons.OK);
                        }
                    }
                    break;
                case "ToolStripMenuItem_Set":

                    break;
                case "bindingNavigator_WorkList":
                case "toolStripButton_WorkListEdit":
                    if (dataGridView_WorkList.CurrentRow != null)
                    {
                        EditForm.EditTrademarkWorkEvent workevent = new LawtechPTSystemByFirm.EditForm.EditTrademarkWorkEvent();
                        workevent.EventID = (int)dgViewMF.CurrentRow.Cells["EventID"].Value;
                        workevent.EventType = (int)dgViewMF.CurrentRow.Cells["EventKind"].Value;
                        workevent.WorkReportID = (int)dataGridView_WorkList.CurrentRow.Cells["WorkReportID"].Value;
                        workevent.ShowDialog();
                    }
                    break;
                case "ToolStripMenuItem_Start":
                    if (dataGridView_WorkList.CurrentRow != null)
                    {
                        int iKey = (int)dataGridView_WorkList.CurrentRow.Cells["WorkReportID"].Value;
                        Public.CTrademarkWorkReport WorkDetail = new Public.CTrademarkWorkReport();
                        Public.CTrademarkWorkReport.ReadOne(iKey, ref WorkDetail);
                        

                        DataSet_TM.TrademarkWorkReportTRow dr = dt_WorkListEvent.FindByWorkReportID(iKey);

                        Public.CTrademarkProcessStepE processStep = new LawtechPTSystemByFirm.Public.CTrademarkProcessStepE();
                        Public.CTrademarkProcessStepE.ReadOne(WorkDetail.Progress.Value, ref processStep);
                       

                        WorkDetail.IsStart = true;
                        if (WorkDetail.Worker == -1)
                        {
                            WorkDetail.Worker = Properties.Settings.Default.WorkerKEY;
                            dr["Worker"] = WorkDetail.Worker;
                            dr["WorkerName"] = Properties.Settings.Default.WorkerName;
                        }
                        WorkDetail.StartTime = DateTime.Now;

                        if (processStep.ProcessHandleKEY != -1)
                        {
                            WorkDetail.EstimateDateTime = WorkDetail.StartTime.Value.AddDays(processStep.Days.Value).AddHours(processStep.Hours.Value).AddMinutes(processStep.Minutes.Value);
                        }

                        WorkDetail.Update();


                        dr["IsStart"] = WorkDetail.IsStart;
                        dr["StartTime"] = WorkDetail.StartTime;
                        if (WorkDetail.EstimateDateTime.HasValue)
                        {
                            dr["EstimateDateTime"] = WorkDetail.EstimateDateTime;
                        }
                        else
                        {
                            dr["EstimateDateTime"] = DBNull.Value;
                        }
                        dt_WorkListEvent.AcceptChanges();

                    }
                    break;
                case "ToolStripMenuItem_Finish":
                    if (dataGridView_WorkList.CurrentRow != null)
                    {
                        int iKey = (int)dataGridView_WorkList.CurrentRow.Cells["WorkReportID"].Value;
                        Public.CTrademarkWorkReport WorkDetail = new Public.CTrademarkWorkReport();
                        Public.CTrademarkWorkReport.ReadOne(iKey, ref WorkDetail);
                      

                        DataSet_TM.TrademarkWorkReportTRow dr = dt_WorkListEvent.FindByWorkReportID(iKey);

                        WorkDetail.IsStart = true;
                        if (WorkDetail.Worker == -1)
                        {
                            WorkDetail.Worker = Properties.Settings.Default.WorkerKEY;
                            dr["Worker"] = WorkDetail.Worker;
                            dr["WorkerName"] = Properties.Settings.Default.WorkerName;
                        }

                        if (WorkDetail.StartTime.HasValue)
                        {
                            WorkDetail.StartTime = DateTime.Now;
                        }
                        WorkDetail.EndTime = DateTime.Now;


                        string returnValue = "";
                        TimeSpan ts = WorkDetail.EndTime.Value - WorkDetail.StartTime.Value ;
                        if (ts.Days > 0)
                        {
                            returnValue = ts.Days.ToString() + "天";
                        }
                        if (ts.Hours > 0)
                        {
                            returnValue += ts.Hours.ToString() + "小時";
                        }
                        if (ts.Minutes > 0)
                        {
                            returnValue += ts.Minutes.ToString() + "分鐘";
                        }
                        WorkDetail.AllTime = returnValue;

                        WorkDetail.Update();


                        dr["IsStart"] = WorkDetail.IsStart;
                        dr["StartTime"] = WorkDetail.StartTime;
                        if (WorkDetail.EstimateDateTime.HasValue)
                        {
                            dr["EstimateDateTime"] = WorkDetail.EstimateDateTime;
                        }
                        else
                        {
                            dr["EstimateDateTime"] = DBNull.Value;
                        }
                        dr["EndTime"] = WorkDetail.EndTime;
                        dr["AllTime"] = WorkDetail.AllTime;
                        dt_WorkListEvent.AcceptChanges();
                    }
                    break;
            }
        }
        #endregion 

        private void ChkSelected(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            if (rb.Checked)
            {
                butQuery_Click(null, null);
            }
        }

        private void RadioSelected(object sender, EventArgs e)
        {
            RadioButton Radio = (RadioButton)sender;
            if (Radio.Checked)
            {              
                butQuery_Click(null, null);
            }
        }

        #region maskedTextBox_OccurDateS_DoubleClick
        private void maskedTextBox_OccurDateS_DoubleClick(object sender, EventArgs e)
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

        #region dataGridView_WorkList_CellDoubleClick
        private void dataGridView_WorkList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                contextMenuStrip1_ItemClicked(contextMenuStrip1, new ToolStripItemClickedEventArgs(toolStripButton_WorkListEdit));
            }
        }
        #endregion

        #region 完整歷程 private void toolStripButton_CompleteHistory_Click(object sender, EventArgs e)
        /// <summary>
        /// 完整歷程
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton_CompleteHistory_Click(object sender, EventArgs e)
        {
            if (dgViewMF.SelectedRows.Count > 0)
            {
                ViewFrom.TrademarkCompleteHistory history = new LawtechPTSystemByFirm.ViewFrom.TrademarkCompleteHistory();
                history.Gv = dgViewMF;
                history.Show();
            }
            else
            {
                if (dgViewMF.CurrentRow != null)
                {
                    ViewFrom.TrademarkCompleteHistory history = new LawtechPTSystemByFirm.ViewFrom.TrademarkCompleteHistory();
                    history.Gv = dgViewMF;
                    history.Show();
                }
            }
        } 
        #endregion

        private void but_ShowDetail_Click(object sender, EventArgs e)
        {
            if (!splitContainer1.Panel2Collapsed)
            {
                but_ShowDetail.Text = "開啟作業確認清單(Alt+E)";

                splitContainer1.Panel2Collapsed = true;
            }
            else
            {
                but_ShowDetail.Text = "關閉作業確認清單(Alt+E)";
                splitContainer1.Panel2Collapsed = false;
            }
        }

        private void TrademarkControlEvent_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt)
            {
                if (e.KeyCode == Keys.E)
                {
                    but_ShowDetail_Click(null, null);
                }
            }
        }

        private void dgViewMF_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != -1 && e.RowIndex != -1)
            {
                if (dgViewMF.CurrentRow != null)
                {
                    toolStripLabel_TrademarkView_Click(null,null);
                }
            }
        }
    }
}
