using System;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LawtechPTSystemByFirm.SubFrom
{
    /// <summary>
    /// 舊版 不要再使用
    /// </summary>
    public partial class PATControlEvent : Form
    {
        private object m_objOpt = System.Reflection.Missing.Value;

        BindingSource bSource_Control;

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
        
        private int iOfficeRole = -1;
        /// <summary>
        /// 登入者的權限身份 1.員工 2.專利主管 3.商標主管 0.admin
        /// </summary>
        public int OfficeRole
        {
            get { return iOfficeRole; }
            set { iOfficeRole = value; }
        }

        private decimal decPatentControlPeriodTime = 0;
        /// <summary>
        /// 專利管制年費的時間
        /// </summary>
        public decimal PatentControlPeriodTime
        {
            get { return decPatentControlPeriodTime; }
            set { decPatentControlPeriodTime = value; }
        }

        /// <summary>
        /// 目前的 DataGridViewRow CurrentRow
        /// </summary>
        public DataGridViewRow GV_CurrentRow
        {
            get { return dgViewMF.CurrentRow; }
        }

        #endregion 

        public PATControlEvent()
        {
            InitializeComponent();
            dgViewMF.AutoGenerateColumns = false;
            dataGridView_WorkList.AutoGenerateColumns = false;
            Public.DynamicGridViewColumn.GetGridColum(ref dgViewMF);
            Public.DynamicGridViewColumn.GetGridColum(ref dataGridView_WorkList);
           
        }

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
        public QS_DataSet.PatWorkReportTDataTable dt_WorkListEvent
        {
            get
            {
                return qS_DataSet.PatWorkReportT;
            }
        }
        #endregion

        #region PATControlEvent_Load 、 PATControlEvent_FormClosed
        private void PATControlEvent_Load(object sender, EventArgs e)
        {           
            
            Public.PublicForm Forms = new LawtechPTSystemByFirm.Public.PublicForm();
            Forms.PATControlEvent = this;

            

            //取得登入者身份
            iWorkerID = Properties.Settings.Default.WorkerKEY;
            Worker_Model worker = new Worker_Model();
            Worker_Model.ReadOne(iWorkerID, ref  worker);

            iOfficeRole = worker.OfficeRole.Value;
            strWorkerName = worker.EmployeeName;

            bSource_Control = new BindingSource();
            dgViewMF.DataSource = bSource_Control;
            bindingNavigator1.BindingSource = bSource_Control;

            this.workerTAllTableAdapter.Fill(this.qS_DataSet.WorkerTAll);

            this.patSelectDateModeControl_DropTableAdapter.Fill(this.qS_DataSet.PatSelectDateModeControl_Drop);

            Public.DLL dll = new LawtechPTSystemByFirm.Public.DLL();

            PatentControlPeriodTime = dll.GetPatentControlPeriodTime;

            butQuery_Click(null,null);
        }

        private void PATControlEvent_FormClosed(object sender, FormClosedEventArgs e)
        {
            Public.PublicForm Forms = new LawtechPTSystemByFirm.Public.PublicForm();
            Forms.PATControlEvent = null;
        }
        #endregion

        private void ChkSelected(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            if (rb.Checked)
            {
                rb.BackgroundImage = global::LawtechPTSystemByFirm.Properties.Resources.btn_27;
                butQuery_Click(null, null);
            }
            else
            {
                rb.BackgroundImage = null;
            }
        }

        private void RadioSelected(object sender, EventArgs e)
        {
            RadioButton Radio = (RadioButton)sender;

            if (Radio.Checked)
            {

                Radio.BackgroundImage = global::LawtechPTSystemByFirm.Properties.Resources.btnGeen;
                
                butQuery_Click(null, null);
            }
            else
            {
                Radio.BackgroundImage = null;
            }
        }

        #region =========查詢 按鈕=========
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
                strFilter += " and FinishDate is null "; //and ( OfficeDueDate<GetDate() or OfficeDueDate is null ) 
            }

            string strSeachDate = cb_SearchDate.SelectedValue.ToString();           

            DateTime dtStartTime = SearchStartTime;
            DateTime dtEndTime = SearchEndTime;

            if (dtStartTime.Year > 1900 && dtEndTime.Year ==1900)
            {
                strFilter += " and  " + strSeachDate + ">='" + maskedTextBox_OccurDateS.Text + "' ";
            }
            else if (dtStartTime.Year == 1900 && dtEndTime.Year> 1900)
            {
                strFilter += " and " + strSeachDate + "<='" + maskedTextBox_OccurDateE.Text + " 23:59' ";
            }
            else if (dtStartTime.Year > 1900 && dtEndTime.Year > 1900 )
            {
                strFilter += string.Format(" and (" + strSeachDate + " >= '{0}' and " + strSeachDate + " <= '{1} 23:59'  ) ", maskedTextBox_OccurDateS.Text, maskedTextBox_OccurDateE.Text);
            }

            Public.CCombox Combox = (Public.CCombox)((System.Windows.Forms.ComboBox)(searchMain1.comboBox1)).SelectedItem;

            if (searchMain1.comboBox1.Text.Trim() != "" && searchMain1.comboBox2.Text.Trim() != "")
            {
                switch (Combox.SelectValue)
                {
                    case "WorkerKey":
                        strWhere1 = "  WorkerT.WorkerKey =" + searchMain1.comboBox2.SelectedValue.ToString() ;
                        break;
                    case "PatentNo":
                        strWhere1 = "  PatentManagementT.PatentNo like '%" + searchMain1.comboBox2.Text + "%'";
                        break;
                    case "PatentNo_Old":
                        strWhere1 = "  PatentManagementT.PatentNo_Old like '%" + searchMain1.comboBox2.Text + "%'";
                        break;
                    case "CountrySymbol":
                        strWhere1 = "  PatentManagementT.CountrySymbol = '" + searchMain1.comboBox2.SelectedValue.ToString() + "'";
                        break;
                    case "KindSN":
                        strWhere1 = "  PatentManagementT.Kind = '" + searchMain1.comboBox2.SelectedValue.ToString() + "'";
                        break;
                    case "FeatureID":
                        strWhere1 = "  PatentManagementT.Nature = " + searchMain1.comboBox2.SelectedValue.ToString();
                        break;
                    case "StatusID":
                        strWhere1 = "  PatentManagementT.Status = " + searchMain1.comboBox2.SelectedValue.ToString();
                        break;
                    case "Title":
                        strWhere1 = "  PatentManagementT.Title like '%" + searchMain1.comboBox2.Text + "%'";
                        break;
                    case "valueString":
                        strWhere1 = "  PatentManagementT.DelegateType =" + searchMain1.comboBox2.SelectedValue.ToString();
                        break;
                   
                }
            }

            Public.CCombox Combox2 = (Public.CCombox)((System.Windows.Forms.ComboBox)(searchMain2.comboBox1)).SelectedItem;
            if (searchMain2.comboBox1.Text.Trim() != "" && searchMain2.comboBox2.Text.Trim() != "")
            {
                switch (Combox2.SelectValue)    
                {
                    case "WorkerKey":
                        strWhere2 = "  WorkerT.WorkerKey =" + searchMain2.comboBox2.SelectedValue.ToString();
                        break;
                    case "PatentNo":
                        strWhere2 = "  PatentManagementT.PatentNo like '%" + searchMain2.comboBox2.Text + "%'";
                        break;
                    case "PatentNo_Old":
                        strWhere2 = "  PatentManagementT.PatentNo_Old like '%" + searchMain2.comboBox2.Text + "%'";
                        break;
                    case "CountrySymbol":
                        strWhere2 = "  PatentManagementT.CountrySymbol = '" + searchMain2.comboBox2.SelectedValue.ToString() + "'";
                        break;
                    case "KindSN":
                        strWhere2 = "  PatentManagementT.Kind = '" + searchMain2.comboBox2.SelectedValue.ToString() + "'";
                        break;
                    case "FeatureID":
                        strWhere2 = "  PatentManagementT.Nature = " + searchMain2.comboBox2.SelectedValue.ToString();
                        break;
                    case "StatusID":
                        strWhere2 = "  PatentManagementT.Status = " + searchMain2.comboBox2.SelectedValue.ToString();
                        break;
                    case "Title":
                        strWhere2 = "  PatentManagementT.Title like '%" + searchMain2.comboBox2.Text + "%'";
                        break;
                    case "valueString":
                        strWhere2 = "  PatentManagementT.DelegateType =" + searchMain2.comboBox2.SelectedValue.ToString();
                        break;

                }
            }


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


            string[] sWhere = { strFilter, FullFilter };

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

            DataBind_PatentEvent(FullWhere.ToString());

            butQuery.Enabled = true;
        }
        #endregion

        #region DataBind_PatentEvent
        public void DataBind_PatentEvent(string strWhere)
        {
            dgViewMF.Columns["SingCode"].Visible = false;
            dgViewMF.Columns["PaymentDate"].Visible = false; //付款 付款日期
            dgViewMF.Columns["AttorneyFirm"].Visible = false;
            dgViewMF.Columns["PPP"].Visible = false;//請款單號
            dgViewMF.Columns["PayAttorneyFirm"].Visible = false;//受款人
            dgViewMF.Columns["FeePhase"].Visible = false;//費用種類
            dgViewMF.Columns["IMoney"].Visible = false;//幣別
            dgViewMF.Columns["PayTotall"].Visible = false; //付款 合計
            dgViewMF.Columns["SingCodeStatus"].Visible = false;
            dgViewMF.Columns["OtherTotalFee"].Visible = false; //付款 合計
            dgViewMF.Columns["OAttorneyGovFee"].Visible = false; //付款 合計

            bSource_Control.DataSource = null;

            if (radB_all.Checked)//全部
            {
                //System.Data.DataTable dt_ComitEvent = GetComitEvent(strWhere);
                ////System.Data.DataTable dt_NotifyEvent = GetNotifyEvent(strWhere);
                //System.Data.DataTable dt_PatentFeeEvent = GetPatentFeeEvent(strWhere);
                //System.Data.DataTable dt_FeeEvent = GetFeeEvent(strWhere);
                //System.Data.DataTable dt_PaymentEvent = GetPaymentEvent(strWhere);
                

                //if (dt_PatentFeeEvent.Rows.Count > 0)
                //    dt_ComitEvent.Merge(dt_PatentFeeEvent);

                //if (dt_FeeEvent.Rows.Count > 0)
                //    dt_ComitEvent.Merge(dt_FeeEvent);

                //if (dt_PaymentEvent.Rows.Count > 0)
                //    dt_ComitEvent.Merge(dt_PaymentEvent);

                //dgViewMF.Columns["SingCode"].Visible = true;
                //dgViewMF.Columns["PaymentDate"].Visible = true;
                //dgViewMF.Columns["AttorneyFirm"].Visible = true;

                //bSource_Control.DataSource = dt_ComitEvent;
            }
            else if (radoB.Checked)//事件
            {
               
                dgViewMF.Columns["AttorneyFirm"].Visible = true;

                dgViewMF.Columns["DueDate"].HeaderText = "官方期限";
                System.Data.DataTable dt_ComitEvent = GetComitEvent(strWhere);
                
                bSource_Control.DataSource = dt_ComitEvent;
            }
            else if (radoPatentFee.Checked)//待繳年費
            {
                
                dgViewMF.Columns["DueDate"].HeaderText = "年費有效日";
                System.Data.DataTable dt_PatentFeeEvent = GetPatentFeeEvent(strWhere);
                bSource_Control.DataSource = dt_PatentFeeEvent;
            }
            else if (radoC.Checked)//來函
            {
                //System.Data.DataTable dt_NotifyEvent = GetNotifyEvent(strWhere);
                //bSource_Control.DataSource = dt_NotifyEvent;
            }
            else if (radioFee.Checked)//請款
            {
                dgViewMF.Columns["SingCode"].Visible = true;
                dgViewMF.Columns["FeePhase"].Visible = true;//費用種類
                dgViewMF.Columns["PayTotall"].Visible = true; //請款 合計
                dgViewMF.Columns["OtherTotalFee"].Visible = true; //請款 合計
                dgViewMF.Columns["OAttorneyGovFee"].Visible = true; //請款 合計
                dgViewMF.Columns["PPP"].Visible = true;
                dgViewMF.Columns["SingCodeStatus"].Visible = true;
                dgViewMF.Columns["IMoney"].Visible = true;//幣別

                dgViewMF.Columns["DueDate"].HeaderText = "收據日期(官方)";
                System.Data.DataTable dt_FeeEvent = GetFeeEvent(strWhere);
                bSource_Control.DataSource = dt_FeeEvent;

            }
            else //付款
            {
                dgViewMF.Columns["SingCode"].Visible = true;
                dgViewMF.Columns["PaymentDate"].Visible = true;
                dgViewMF.Columns["PPP"].Visible = true;
                dgViewMF.Columns["PayAttorneyFirm"].Visible = true;//受款人
                dgViewMF.Columns["FeePhase"].Visible = true;//費用種類
                dgViewMF.Columns["IMoney"].Visible = true;//幣別
                dgViewMF.Columns["PayTotall"].Visible = true; //付款 合計
                dgViewMF.Columns["SingCodeStatus"].Visible = true;

                dgViewMF.Columns["DueDate"].HeaderText = "付款期限(官方)";
                System.Data.DataTable dt_PaymentEvent = GetPaymentEvent(strWhere);
                bSource_Control.DataSource = dt_PaymentEvent;
            }
            

        }
        #endregion

        #region GetComitEvent 取得事件的資料
        /// <summary>
        /// 取得事件的資料
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public System.Data.DataTable GetComitEvent(string strWhere)
        {
            if (cb_SearchDate.SelectedValue.ToString() == "LastModifyDateTime")
            {
                strWhere = strWhere.Replace("LastModifyDateTime", "PatComitEventT.LastModifyDateTime");
            }
            else if (cb_SearchDate.SelectedValue.ToString() == "OfficeDueDate")
            {
                strWhere = strWhere.Replace("OfficeDueDate", "PatComitEventT.OfficeDueDate");
            }
            else if (cb_SearchDate.SelectedValue.ToString() == "DueDate")
            {
                strWhere = strWhere.Replace("DueDate", "PatComitEventT.DueDate");
            }
            else//事件日
            {
                strWhere = strWhere.Replace("OccurDate", "PatComitEventT.CreateDate");
            }

            strWhere = strWhere.Replace("FinishDate", "PatComitEventT.FinishDate");

            string strNotifyEventSQL = string.Format(
                                    @"SELECT          PatentManagementT.PatentID, 1 AS EventKind, PatentManagementT.PatentNo, PatentManagementT.Title, 
                            CountryT.CountrySymbol, CountryT.Country, KindT.Kind, '' AS PaymentDate, 
                            PatComitEventT.PatComitEventID AS EventID, PatComitEventT.CreateDate AS OccurDate, 
                            PatComitEventT.EventContent, PatComitEventT.OfficeDueDate, '' AS SingCode, 
                            CASE WHEN PatComitEventT.FinishDate IS NULL THEN DATEDIFF(day, GETDATE(), 
                            ISNULL(PatComitEventT.DueDate, GETDATE())) WHEN PatComitEventT.FinishDate IS NOT NULL THEN NULL 
                            END AS DiffDueDate, PatComitEventT.FinishDate, WorkerT.EmployeeName, PatComitEventT.Result, 
                            PATFeatureT.FeatureName, 1 AS EventType, '事件記錄' AS EventTypeName, PatComitEventT.DueDate, 
                            CASE PatentManagementT.DelegateType WHEN 1 THEN '申請人直接委託' WHEN 2 THEN '複代委託' END AS DelegateTypeName,
                             PatComitEventT.LastModifyDateTime, PatentManagementT.Status, PatStatusT.Status AS StatusName, 
                            PatentManagementT.MainCustomerRefNo, PatentManagementT.ApplicationDate, PatentManagementT.ApplicationNo, 
                            PatComitEventT.Remark AS EventRemark, AttorneyT.AttorneyKey, AttorneyT.AttorneyFirm, 
                            PatentManagementT.AttorneyRefNo, PatentManagementT.CertifyNo, PatentManagementT.ApplicantNames, 
                            PatentManagementT.ApplicantKeys,  PatComitEventT.LastModifyWorker, '' AS PPP, '' AS FeePhase, 
                            '' AS PayAttorneyFirm, '' AS PayAttorneyFirm
FROM              AttorneyT RIGHT OUTER JOIN
                            WorkerT AS WorkerT_1 RIGHT OUTER JOIN
                            PatComitEventT ON WorkerT_1.WorkerKey = PatComitEventT.LastModifyWorker LEFT OUTER JOIN
                            WorkerT ON PatComitEventT.WorkerKey = WorkerT.WorkerKey ON 
                            AttorneyT.AttorneyKey = PatComitEventT.AttorneyKey LEFT OUTER JOIN
                            CountryT RIGHT OUTER JOIN
                            PatStatusT RIGHT OUTER JOIN
                            PatentManagementT ON PatStatusT.StatusID = PatentManagementT.Status LEFT OUTER JOIN
                            KindT ON PatentManagementT.Kind = KindT.KindSN ON 
                            CountryT.CountrySymbol = PatentManagementT.CountrySymbol LEFT OUTER JOIN
                            PATFeatureT ON PatentManagementT.Nature = PATFeatureT.FeatureID ON 
                            PatComitEventT.PatentID = PatentManagementT.PatentID
WHERE          (PatentManagementT.CloseDate IS NULL)   {0}", strWhere);

            Public.DLL dll = new LawtechPTSystemByFirm.Public.DLL();
            System.Data.DataTable dtComitEvent = new System.Data.DataTable(); 
            dll.FetchDataTable(strNotifyEventSQL, dtComitEvent);
            return dtComitEvent;
        }
        #endregion 

        #region GetNotifyEvent 取得來函的資料
        /// <summary>
        /// 取得來函的資料
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public System.Data.DataTable GetNotifyEvent(string strWhere)
        {
            if (cb_SearchDate.SelectedValue.ToString() == "LastModifyDate")
            {
                strWhere = strWhere.Replace("LastModifyDate", "PatNotifyEventT.LastModifyDate");
            }
            else if (cb_SearchDate.SelectedValue.ToString() == "OfficeDueDate")
            {
                strWhere = strWhere.Replace("OfficeDueDate", "PatNotifyEventT.NotifyAttorneyDueDate");
            }
            else if (cb_SearchDate.SelectedValue.ToString() == "DueDate")//官方期限
            {
                strWhere = strWhere.Replace("DueDate", "PatNotifyEventT.DueDate");
            }
            else
            {
                strWhere = strWhere.Replace("OccurDate", "PatNotifyEventT.NotifyComitDate");//來函收文日
            }
              strWhere = strWhere.Replace("FinishDate", "PatNotifyEventT.FinishDate");
           
            string strNotifyEventSQL = string.Format(
                                    @"SELECT     PatentManagementT.PatentID,2 as EventKind, PatentManagementT.PatentNo, PatentManagementT.Title,CountryT.CountrySymbol, CountryT.Country, KindT.Kind, '' as PaymentDate,
                                                                      PatNotifyEventT.PatNotifyEventID AS EventID, PatNotifyEventT.NotifyComitDate as OccurDate, PatNotifyEventT.NotifyEventContent AS EventContent, 
                                                                      PatNotifyEventT.NotifyAttorneyDueDate AS OfficeDueDate, CASE WHEN PatNotifyEventT.FinishDate IS NULL THEN DATEDIFF(day, GETDATE(), 
                                                                      ISNULL(PatNotifyEventT.DueDate, GETDATE())) WHEN PatNotifyEventT.FinishDate IS NOT NULL THEN NULL END AS DiffDueDate, 
                                                                      PatNotifyEventT.FinishDate,  WorkerT.EmployeeName, PatNotifyEventT.NotifyResult AS Result, PATFeatureT.FeatureName, 
                                                                      2 AS EventType, '來函' AS EventTypeName, PatNotifyEventT.DueDate,case PatentManagementT.DelegateType when 1 then '客戶直接委託' when 2 then '複代委託' end as DelegateTypeName
                                                                      ,PatNotifyEventT.LastModifyDate , PatentManagementT.AttorneyRefNo

                                                FROM         WorkerT RIGHT OUTER JOIN
                                                                      PATFeatureT RIGHT OUTER JOIN
                                                                      CountryT RIGHT OUTER JOIN
                                                                      PatNotifyEventT LEFT OUTER JOIN
                                                                      PatentManagementT ON PatNotifyEventT.PatentID = PatentManagementT.PatentID LEFT OUTER JOIN
                                                                      KindT ON PatentManagementT.Kind = KindT.KindSN ON CountryT.CountrySymbol = PatentManagementT.Country ON 
                                                                      PATFeatureT.FeatureID = PatentManagementT.Nature LEFT OUTER JOIN
                                                                      AttorneyT ON PatNotifyEventT.AttorneyKey = AttorneyT.AttorneyKey ON WorkerT.WorkerKey = PatNotifyEventT.WorkerKey 
                                                                      where PatentManagementT.CloseDate is null 
                                                                        {0}", strWhere);

            Public.DLL dll = new LawtechPTSystemByFirm.Public.DLL();
            System.Data.DataTable dtNotifyEvent = new System.Data.DataTable();
            dll.FetchDataTable(strNotifyEventSQL, dtNotifyEvent);
           return dtNotifyEvent;
        }
        #endregion

        #region GetPatentFeeEvent 取得待繳年費的資料
        /// <summary>
        /// 取得待繳年費的資料
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public System.Data.DataTable GetPatentFeeEvent(string strWhere)
        {
            if (cb_SearchDate.SelectedValue.ToString() == "LastModifyDateTime")
            {
                strWhere = strWhere.Replace("LastModifyDateTime", "PatentManagementT.LastModifyDateTime");
            }
            else if (cb_SearchDate.SelectedValue.ToString() == "OfficeDueDate")
            {
                strWhere = strWhere.Replace("OfficeDueDate", "(CASE WHEN GetDate()>dateAdd(MM,-" + this.PatentControlPeriodTime.ToString("###0.#") + ",PatentManagementT.RenewTo) then dateAdd(MM,-" + this.PatentControlPeriodTime.ToString("###0.#") + ",PatentManagementT.RenewTo) else null end)");
            }
            else if (cb_SearchDate.SelectedValue.ToString() == "DueDate")//官方期限
            {
                strWhere = strWhere.Replace("DueDate", "PatentManagementT.RenewTo");
            }
            else
            {
                strWhere = strWhere.Replace("OccurDate", "DATEADD(MM, -" + this.PatentControlPeriodTime.ToString("###0.#") + ",PatentManagementT.RenewTo)");
            }
            strWhere = strWhere.Replace("FinishDate is not null", " PatentManagementT.RenewTo>dateAdd(MM," + this.PatentControlPeriodTime.ToString("###0.#") + ",getDate()) ").Replace("FinishDate is null ", " PatentManagementT.RenewTo<dateAdd(MM," + this.PatentControlPeriodTime.ToString("###0.#") + ",getDate())");

            string strPatentFeeEventSQL = string.Format(
                                    @"SELECT     PatentManagementT.PatentID, 3 AS EventKind, PatentManagementT.PatentNo, PatentManagementT.Title,CountryT.CountrySymbol, CountryT.Country, KindT.Kind,'' as  PaymentDate,
                                                              PatentManagementT.PatentID AS EventID, DATEADD(MM, - {1}, PatentManagementT.RenewTo) AS OccurDate,'' as  SingCode ,
                                                              '目前繳至 ' + CAST(PatentManagementT.PayYear AS Nvarchar(10)) + ' 年--待繳下年度專利費用' AS EventContent, CASE WHEN GetDate() > dateAdd(MM,
                                                               -{1}, PatentManagementT.RenewTo) THEN dateAdd(MM, -{1}, PatentManagementT.RenewTo) ELSE NULL END AS OfficeDueDate, 
                                                              CASE WHEN PatentManagementT.RenewTo > dateAdd(MM, {1}, getDate()) THEN PatentManagementT.RenewTo ELSE NULL END AS FinishDate, 
                                                              CASE WHEN PatentManagementT.CloseDate IS NULL THEN DATEDIFF(day, GETDATE(), ISNULL(PatentManagementT.RenewTo, GETDATE())) 
                                                              WHEN PatentManagementT.CloseDate IS NOT NULL THEN NULL END AS DiffDueDate, '' AS Result, WorkerT_1.EmployeeName , PATFeatureT.FeatureName, 
                                                              3 AS EventType, '年費' AS EventTypeName, PatentManagementT.RenewTo AS DueDate, 
                                                              CASE PatentManagementT.DelegateType WHEN 1 THEN '申請人直接委託' WHEN 2 THEN '複代委託' END AS DelegateTypeName, 
                                                              PatentManagementT.LastModifyDateTime, PatentManagementT.Status, PatStatusT.Status AS StatusName,PatentManagementT.MainCustomerRefNo,PatentManagementT.ApplicationDate,PatentManagementT.ApplicationNo,PatentManagementT.Remark as EventRemark, 
                                                              '' as AttorneyFirm , PatentManagementT.AttorneyRefNo, PatentManagementT.CertifyNo, PatentManagementT.ApplicantNames,PatentManagementT.ApplicantKeys,PatentManagementT.Attorney as AttorneyKey, PatentManagementT.LastModifyWorker
                                      FROM              PatentManagementT LEFT OUTER JOIN
                            PatStatusT ON PatentManagementT.Status = PatStatusT.StatusID LEFT OUTER JOIN
                            KindT ON PatentManagementT.Kind = KindT.KindSN LEFT OUTER JOIN
                            CountryT ON PatentManagementT.CountrySymbol = CountryT.CountrySymbol LEFT OUTER JOIN
                            WorkerT AS WorkerT_1 ON PatentManagementT.ClientWorker = WorkerT_1.WorkerKey LEFT OUTER JOIN
                            PATFeatureT ON PatentManagementT.Nature = PATFeatureT.FeatureID
WHERE          (PatentManagementT.CloseDate IS NULL) AND (PatentManagementT.RenewTo IS NOT NULL) 
                                            {0}", strWhere, this.PatentControlPeriodTime.ToString("###0.#"));

            Public.DLL dll = new LawtechPTSystemByFirm.Public.DLL();
            System.Data.DataTable dtstrPatentFeeEvent = new System.Data.DataTable();
            dll.FetchDataTable(strPatentFeeEventSQL, dtstrPatentFeeEvent);
            return dtstrPatentFeeEvent;
        }
        #endregion

        #region GetNotifyEvent 取得請款的資料
        /// <summary>
        /// 取得請款的資料
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public System.Data.DataTable GetFeeEvent(string strWhere)
        {
            if (cb_SearchDate.SelectedValue.ToString() == "LastModifyDateTime")
            {
                strWhere = strWhere.Replace("LastModifyDateTime", "PatentFeeT.LastModifyDateTime");
            }
            else if (cb_SearchDate.SelectedValue.ToString() == "OfficeDueDate")
            {
                strWhere = strWhere.Replace("OfficeDueDate", "PatentFeeT.RDate");
            }
            else if (cb_SearchDate.SelectedValue.ToString() == "DueDate")//官方期限
            {
                strWhere = strWhere.Replace("DueDate", "ReceiptDate");
            }
            else
            {
                strWhere = strWhere.Replace("OccurDate", "PatentFeeT.RDate");
            }

            strWhere = strWhere.Replace("FinishDate is not null", "PatentFeeT.Pay=1").Replace("FinishDate is null", " (PatentFeeT.Pay<>1) ");

            string strNotifyEventSQL = string.Format(
                                    @"SELECT     PatentManagementT.PatentID, 4 AS EventKind, PatentManagementT.PatentNo, PatentManagementT.Title, CountryT.CountrySymbol, CountryT.Country, 
                                                              KindT.Kind, PatentFeeT.FeeKEY AS EventID, PatentFeeT.RDate AS OccurDate, PatentFeeT.FeeSubject AS EventContent, 
                                                              PatentFeeT.RDate AS officeDueDate, PatentFeeT.SingCode, '' AS PaymentDate, CASE PatentFeeT.Pay WHEN 0 THEN DATEDIFF(day, GETDATE(), 
                                                              ISNULL(PatentFeeT.ReceiptDate, GETDATE())) WHEN NULL THEN DATEDIFF(day, GETDATE(), ISNULL(PatentFeeT.ReceiptDate, GETDATE())) 
                                                              WHEN 1 THEN NULL END AS DiffDueDate, CASE PatentFeeT.Pay WHEN 1 THEN PatentFeeT.PayDate ELSE NULL END AS FinishDate, 
                                                              WorkerT_1.EmployeeName, PatentFeeT.Remark AS Result, PATFeatureT.FeatureName, 4 AS EventType, '請款' AS EventTypeName, 
                                                              PatentFeeT.ReceiptDate AS DueDate, 
                                                              CASE PatentManagementT.DelegateType WHEN 1 THEN '申請人直接委託' WHEN 2 THEN '複代委託' END AS DelegateTypeName, 
                                                              PatentFeeT.LastModifyDateTime, PatentManagementT.Status, PatStatusT.Status AS StatusName, PatentManagementT.MainCustomerRefNo, 
                                                              PatentManagementT.ApplicationDate, PatentManagementT.ApplicationNo, PatentFeeT.Remark AS EventRemark, '' AS AttorneyFirm, 
                                                              PatentManagementT.AttorneyRefNo, PatentManagementT.CertifyNo, PatentManagementT.ApplicantNames,PatentManagementT.ApplicantKeys, FeePhaseT.FeePhase, 
                                                              WorkerT.EmployeeName AS LastModifyWorker, PatentFeeT.PPP, PatentFeeT.OtherTotalFee, PatentFeeT.OAttorneyGovFee, PatentFeeT.Totall,PatentFeeT.Attorney as AttorneyKey,PatentFeeT.SingCodeStatus,TMoney as IMoney
                                        FROM         FeePhaseT RIGHT OUTER JOIN
                                                              PatentFeeT LEFT OUTER JOIN
                                                              WorkerT ON PatentFeeT.LastModifyWorker = WorkerT.WorkerKey ON FeePhaseT.FeePhaseID = PatentFeeT.FeePhase LEFT OUTER JOIN
                                                              WorkerT AS WorkerT_1 ON PatentFeeT.FClientTransactor = WorkerT_1.WorkerKey LEFT OUTER JOIN
                                                              PatentManagementT LEFT OUTER JOIN
                                                              PatStatusT ON PatentManagementT.Status = PatStatusT.StatusID LEFT OUTER JOIN
                                                              KindT ON PatentManagementT.Kind = KindT.KindSN LEFT OUTER JOIN
                                                              CountryT ON PatentManagementT.CountrySymbol = CountryT.CountrySymbol LEFT OUTER JOIN
                                                              PATFeatureT ON PatentManagementT.Nature = PATFeatureT.FeatureID ON PatentFeeT.PatentID = PatentManagementT.PatentID
                                        WHERE     (PatentManagementT.CloseDate IS NULL)   {0}", strWhere);

            Public.DLL dll = new LawtechPTSystemByFirm.Public.DLL();
            System.Data.DataTable dtFeeEvent = new System.Data.DataTable();
            dll.FetchDataTable(strNotifyEventSQL, dtFeeEvent);
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
            if (cb_SearchDate.SelectedValue.ToString() == "LastModifyDateTime")
            {
                strWhere = strWhere.Replace("LastModifyDateTime", "PatentPaymentT.LastModifyDateTime");
            }
            else if (cb_SearchDate.SelectedValue.ToString() == "OfficeDueDate")
            {
                strWhere = strWhere.Replace("OfficeDueDate", "PatentPaymentT.PayDueDate");
            }
            else if (cb_SearchDate.SelectedValue.ToString() == "DueDate")//官方期限
            {
                strWhere = strWhere.Replace("DueDate", "PatentPaymentT.PayDueDate");
            }
            else
            {
                strWhere = strWhere.Replace("OccurDate", "PatentPaymentT.ReciveDate");
            }

            strWhere = strWhere.Replace("FinishDate", "PatentPaymentT.IReceiptDate");

            string strNotifyEventSQL = string.Format(
                                    @"SELECT     PatentManagementT.PatentID, 5 AS EventKind, PatentManagementT.PatentNo, PatentManagementT.Title, CountryT.CountrySymbol, CountryT.Country, 
                                          KindT.Kind, PatentPaymentT.PaymentID AS EventID, PatentPaymentT.ReciveDate AS OccurDate, PatentPaymentT.FeeSubject AS EventContent, 
                                          PatentPaymentT.SingCode, ISNULL(CONVERT(nvarchar(10), PatentPaymentT.PaymentDate, 111), '') AS PaymentDate, 
                                          PatentPaymentT.PayDueDate AS officeDueDate, CASE WHEN PatentPaymentT.IReceiptDate IS NULL THEN DATEDIFF(day, GETDATE(), 
                                          ISNULL(PatentPaymentT.PayDueDate, GETDATE())) ELSE NULL END AS DiffDueDate, PatentPaymentT.IReceiptDate AS FinishDate, WorkerT.EmployeeName, 
                                          PatentPaymentT.Remark AS Result, PATFeatureT.FeatureName, 5 AS EventType, '付款' AS EventTypeName, PatentPaymentT.PayDueDate AS DueDate, 
                                          CASE PatentManagementT.DelegateType WHEN 1 THEN '申請人直接委託' WHEN 2 THEN '複代委託' END AS DelegateTypeName, 
                                          PatentPaymentT.LastModifyDateTime, PatentManagementT.Status, PatStatusT.Status AS StatusName, PatentManagementT.MainCustomerRefNo, 
                                          PatentManagementT.ApplicationDate, PatentManagementT.ApplicationNo, PatentPaymentT.Remark AS EventRemark, '' AS AttorneyFirm, 
                                          PatentManagementT.AttorneyRefNo, PatentManagementT.CertifyNo, PatentManagementT.ApplicantNames,PatentManagementT.ApplicantKeys, PatentPaymentT.LastModifyWorker, 
                                          PatentPaymentT.BillingNo AS PPP, FeePhaseT.FeePhase,AttorneyT.AttorneyFirm AS PayAttorneyFirm,PatentPaymentT.IMoney, 
                                        PatentPaymentT.Totall,PatentPaymentT.Attorney as AttorneyKey,PatentPaymentT.SingCodeStatus
                                        FROM         PatentPaymentT LEFT OUTER JOIN
                                          FeePhaseT ON PatentPaymentT.FeePhase = FeePhaseT.FeePhaseID LEFT OUTER JOIN                                         
                                          AttorneyT ON PatentPaymentT.Attorney = AttorneyT.AttorneyKey LEFT OUTER JOIN
                                          WorkerT ON PatentPaymentT.FClientTransactor = WorkerT.WorkerKey LEFT OUTER JOIN
                                          PATFeatureT RIGHT OUTER JOIN
                                          KindT RIGHT OUTER JOIN
                                          PatStatusT RIGHT OUTER JOIN
                                          PatentManagementT ON PatStatusT.StatusID = PatentManagementT.Status ON KindT.KindSN = PatentManagementT.Kind LEFT OUTER JOIN
                                          CountryT ON PatentManagementT.CountrySymbol = CountryT.CountrySymbol ON PATFeatureT.FeatureID = PatentManagementT.Nature ON 
                                          PatentPaymentT.PatentID = PatentManagementT.PatentID
                                        WHERE     (PatentManagementT.CloseDate IS NULL)
                                          {0}", strWhere);

            Public.DLL dll = new LawtechPTSystemByFirm.Public.DLL();
            System.Data.DataTable dtPaymentEvent = new System.Data.DataTable();
            dll.FetchDataTable(strNotifyEventSQL, dtPaymentEvent);
            return dtPaymentEvent;
        }
        #endregion

        private void butClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region =========匯出Excel 按鈕=========
        private void butExport_Click(object sender, EventArgs e)
        {

            try
            {
                Public.DLL dll = new LawtechPTSystemByFirm.Public.DLL();
                Task task = dll.WriteToCSV(dgViewMF);
            }
            catch
            {
              
                MessageBox.Show("匯出CSV失敗", "提示訊息", MessageBoxButtons.OK);
            }                
        }
        #endregion       

        #region  dgViewMF 快顯選單、相關事件
        private void contextMenuMain_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            contextMenuMain.Visible = false;

            switch (e.ClickedItem.Name)
            {
                case "放棄ToolStripMenuItem":  //放棄
                    US.AbortControl AbortMF = new US.AbortControl();
                   
                    AbortMF.EventType = (int)dgViewMF.CurrentRow.Cells["EventKind"].Value;//EventKind 1:委辦  2.來函 
                    AbortMF.EventID = (int)dgViewMF.CurrentRow.Cells["EventID"].Value;
                    AbortMF.ShowDialog();
                    break;
                case "新增待處理事項ToolStripMenuItem":  //新增額外事件記錄

                    AddFrom.AddPatentComitEvent ComitEvent = new AddFrom.AddPatentComitEvent();

                    ComitEvent.ShowDialog();

                    break;

                case "委辦送件完成ToolStripMenuItem":  //委辦送件完成
                    if (dgViewMF.CurrentRow.Cells["EventKind"].Value.ToString() != "" && (int)dgViewMF.CurrentRow.Cells["EventKind"].Value == 1)
                    {
                        US.PatentComitEventFinish Comitfinish = new US.PatentComitEventFinish();
                        Comitfinish.EventType = 1;
                        Comitfinish.EventID = (int)dgViewMF.CurrentRow.Cells["EventID"].Value;
                        if (Comitfinish.ShowDialog() == DialogResult.OK)
                        {
                            dgViewMF.CurrentRow.Cells["FinishDate"].Value = Comitfinish.FinishDate;
                            dgViewMF.CurrentRow.Cells["Result"].Value = Comitfinish.Result;
                            dgViewMF.CurrentRow.Cells["DiffDueDate"].Value = 0;
                            dt_ControlEvent.AcceptChanges();
                        }
                    }
                    break;


                case "來函直接歸檔ToolStripMenuItem":  //來函直接歸檔

                    if (dgViewMF.CurrentRow.Cells["EventKind"].Value.ToString() != "" && (int)dgViewMF.CurrentRow.Cells["EventKind"].Value == 2)
                    {

                        if (MessageBox.Show("是否確定直接歸檔?", "提示訊息", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            Public.CPatNotifyEvent NotifyEvent = new Public.CPatNotifyEvent("PatNotifyEventID=" + dgViewMF.CurrentRow.Cells["EventID"].Value.ToString());

                            NotifyEvent.SetCurrent((int)dgViewMF.CurrentRow.Cells["EventID"].Value);

                            NotifyEvent.FinishDate = DateTime.Now;

                            NotifyEvent.NotifyResult = DateTime.Now.ToString("yyyy/MM/dd") + "直接歸檔";

                            NotifyEvent.Updata((int)dgViewMF.CurrentRow.Cells["EventID"].Value);

                            dgViewMF.CurrentRow.Cells["FinishDate"].Value = NotifyEvent.FinishDate;

                            System.Data.DataTable dt = (System.Data.DataTable)bSource_Control.DataSource;

                            dt.AcceptChanges();

                            MessageBox.Show("該來函已完成歸檔", "提示訊息", MessageBoxButtons.OK);
                        }
                    }

                    break;

                case "結束管制ToolStripMenuItem":  //委辦結束管制

                    if (dgViewMF.CurrentRow.Cells["EventKind"].Value.ToString() != "" && (int)dgViewMF.CurrentRow.Cells["EventKind"].Value == 1)
                    {

                        if (MessageBox.Show("事件是否確定結束管制?", "提示訊息", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            int iEventID = (int)dgViewMF.CurrentRow.Cells["EventID"].Value;
                            Public.CPatComitEvent comitEvent = new Public.CPatComitEvent();
                            Public.CPatComitEvent.ReadOne(iEventID, ref comitEvent);

                            comitEvent.FinishDate = DateTime.Now;

                            comitEvent.Result = DateTime.Now.ToString("yyyy/MM/dd") + "結束管制";

                            comitEvent.Update();


                            int iPatentID = (int)dgViewMF.CurrentRow.Cells["PatentID"].Value;
                            Public.CPatentManagement Patent = new Public.CPatentManagement();
                            Public.CPatentManagement.ReadOne(iPatentID, ref Patent);
                           

                            Patent.LastModifyDateTime = DateTime.Now;

                            Patent.LastModifyWorker = Properties.Settings.Default.WorkerName;

                            Patent.Update();

                            dgViewMF.CurrentRow.Cells["FinishDate"].Value = 1;

                            System.Data.DataTable dt = (System.Data.DataTable)bSource_Control.DataSource;
                            dt.AcceptChanges();
                        }
                    }
                    else
                    {
                        if (dgViewMF.CurrentRow.Cells["EventKind"].Value.ToString() != "" && (int)dgViewMF.CurrentRow.Cells["EventKind"].Value == 2)
                        {

                            if (MessageBox.Show("來函是否確定結束管制?", "提示訊息", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                            {
                                Public.CPatNotifyEvent notifyEvent = new Public.CPatNotifyEvent("PatNotifyEventID=" + dgViewMF.CurrentRow.Cells["EventID"].Value.ToString());

                                notifyEvent.SetCurrent((int)dgViewMF.CurrentRow.Cells["EventID"].Value);

                                notifyEvent.FinishDate = DateTime.Now;

                                notifyEvent.NotifyResult = DateTime.Now.ToString("yyyy/MM/dd") + "結束管制";

                                notifyEvent.Updata((int)dgViewMF.CurrentRow.Cells["EventID"].Value);


                                int iPatentID = (int)dgViewMF.CurrentRow.Cells["PatentID"].Value;
                                Public.CPatentManagement Patent = new Public.CPatentManagement();
                                Public.CPatentManagement.ReadOne(iPatentID, ref Patent);
                               

                                Patent.LastModifyWorker = Properties.Settings.Default.WorkerName;

                                Patent.LastModifyDateTime = DateTime.Now;

                                Patent.Update();

                                dgViewMF.CurrentRow.Cells["FinishDate"].Value = 1;

                                System.Data.DataTable dt = (System.Data.DataTable)bSource_Control.DataSource;
                                dt.AcceptChanges();
                            }
                        }
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
                                NotifyEvent.FinishDate = new DateTime(1900,1,1);
                                NotifyEvent.NotifyResult = DateTime.Now.ToString("yyyy/MM/dd") + " 變更為未完成事件";
                                NotifyEvent.Updata(iEventID);

                                dgViewMF.CurrentRow.Cells["FinishDate"].Value = System.DBNull.Value;
                                dt_ControlEvent.AcceptChanges();
                                break;
                        }
                    }
                    break;
                case "ToolStripMenuItem_PaymentComplete"://年費繳費完成
                    US.PatentPaymentComplete pat = new US.PatentPaymentComplete();
                    pat.PatentID = (int)dgViewMF.CurrentRow.Cells["PatentID"].Value;
                    pat.Text = dgViewMF.CurrentRow.Cells["PatentNo"].Value.ToString() + " " + pat.Text;
                    if (pat.ShowDialog() == DialogResult.OK)
                    {
                        dgViewMF.CurrentRow.Cells["FinishDate"].Value = pat.RenewTo;
                        dgViewMF.CurrentRow.Cells["DiffDueDate"].Value = 0;
                        dgViewMF.CurrentRow.Cells["Result"].Value = "";
                        dt_ControlEvent.AcceptChanges();
                    }
                    break;
                case "ToolStripMenuItem_ClosePatent"://結案,年費不續繳

                    US.PatentClose patClose = new US.PatentClose();
                    patClose.PatentID = (int)dgViewMF.CurrentRow.Cells["PatentID"].Value;
                    patClose.Text = dgViewMF.CurrentRow.Cells["PatentNo"].Value.ToString() + " " + patClose.Text;
                    if (patClose.ShowDialog() == DialogResult.OK)
                    {
                        dgViewMF.Rows.Remove(dgViewMF.CurrentRow);
                        dt_ControlEvent.AcceptChanges();
                    }

                    break;
                case "ToolStripMenuItem_FinishFee"://主管簽核 請款
                    if (dgViewMF.CurrentRow.Cells["EventKind"].Value.ToString() != "" && (int)dgViewMF.CurrentRow.Cells["EventKind"].Value == 4)
                    {
                        int iFeeKEY = (int)dgViewMF.CurrentRow.Cells["EventID"].Value;
                        Public.CPatentFee patentFee = new Public.CPatentFee();
                        Public.CPatentFee.ReadOne(iFeeKEY, ref patentFee);


                        if (patentFee.IsClosing.HasValue && patentFee.IsClosing.Value)//判斷是否關帳
                        {
                            MessageBox.Show("該筆請款單號【" + patentFee.PPP + "】已被關帳，請洽帳務主管", "提示訊息", MessageBoxButtons.OK);
                            return;
                        }

                        if (patentFee.PPP != "")//判斷是否已登入請款單號
                        {
                            MessageBox.Show("已登錄了請款單號【" + patentFee.PPP + "】，若要修改，請洽帳務人員", "提示訊息", MessageBoxButtons.OK);
                            return;
                        }

                        //判斷是否有人使用中
                        int iLocker = Public.Utility.GetRecordAuth("PatentFeeT", "FeeKEY=" + dgViewMF.CurrentRow.Cells["EventID"].Value.ToString());
                        if (iLocker == -1 || iLocker == iWorkerID)
                        {
                            if (iLocker != iWorkerID)
                            {
                                Public.Utility.LockRecordAuth("PatentFeeT", iWorkerID, "FeeKEY=" + dgViewMF.CurrentRow.Cells["EventID"].Value.ToString());
                            }

                            EditForm.EditPatentFee edit = new LawtechPTSystemByFirm.EditForm.EditPatentFee();
                            edit.property_FeeKEY = (int)dgViewMF.CurrentRow.Cells["EventID"].Value;
                            edit.CountrySymbol = dgViewMF.CurrentRow.Cells["CountrySymbol"].Value.ToString();
                            edit.ShowDialog();

                            Public.Utility.NuLockRecordAuth("PatentFeeT", "FeeKEY=" + dgViewMF.CurrentRow.Cells["EventID"].Value.ToString());
                        }
                        else
                        {
                            if (iLocker != -1)
                            {
                                Worker_Model manager = new Worker_Model();
                                Worker_Model.ReadOne(iLocker, ref  manager);

                                MessageBox.Show("很抱歉~~   目前該筆資料正被【" + manager.EmployeeName + "】使用中，請等候!!\r\n 謝謝", "提示訊息");
                            }
                        }
                    }
                    break;
                case "toolStripMenuItem_RejectionFee"://退請款
                    if (dgViewMF.CurrentRow.Cells["EventKind"].Value.ToString() != "" && (int)dgViewMF.CurrentRow.Cells["EventKind"].Value == 4)
                    {
                        int iFeeKEY = (int)dgViewMF.CurrentRow.Cells["EventID"].Value;
                        Public.CPatentFee patentFee = new LawtechPTSystemByFirm.Public.CPatentFee();
                        Public.CPatentFee.ReadOne(iFeeKEY, ref patentFee);


                        if (patentFee.IsClosing.HasValue && patentFee.IsClosing.Value)//判斷是否關帳
                        {
                            MessageBox.Show("該筆請款單號【" + patentFee.PPP + "】已被關帳，請洽帳務主管", "提示訊息", MessageBoxButtons.OK);
                            return;
                        }

                        if (patentFee.PPP != "")//判斷是否已登入請款單號
                        {
                            MessageBox.Show("已登錄了請款單號【" + patentFee.PPP + "】，若要修改，請洽帳務人員", "提示訊息", MessageBoxButtons.OK);
                            return;
                        }

                        //判斷是否有人使用中
                        int iLocker = Public.Utility.GetRecordAuth("PatentFeeT", "FeeKEY=" + dgViewMF.CurrentRow.Cells["EventID"].Value.ToString());
                        if (iLocker == -1 || iLocker == iWorkerID)
                        {
                            if (iLocker != iWorkerID)
                            {
                                Public.Utility.LockRecordAuth("PatentFeeT", iWorkerID, "FeeKEY=" + dgViewMF.CurrentRow.Cells["EventID"].Value.ToString());
                            }
                                                       
                            string str = "✖退請款(" + Properties.Settings.Default.WorkerName + " " + DateTime.Now.ToString("yyyy/MM/dd HH:mm") + ")";
                            patentFee.SingCodeStatus = str;
                            patentFee.LastModifyDateTime = DateTime.Now;
                            patentFee.LastModifyWorker = Properties.Settings.Default.WorkerName;
                            patentFee.Update();

                            dgViewMF.CurrentRow.Cells["SingCodeStatus"].Value = str;

                            Public.Utility.NuLockRecordAuth("PatentFeeT", "FeeKey=" + dgViewMF.CurrentRow.Cells["EventID"].Value.ToString());
                        }
                        else
                        {
                            if (iLocker != -1)
                            {
                                Worker_Model worker = new Worker_Model();
                                Worker_Model.ReadOne(iLocker, ref  worker);

                                MessageBox.Show("很抱歉~~   目前該筆資料正被【" + worker.EmployeeName + "】使用中，請等候!!\r\n 謝謝", "提示訊息");
                            }
                        }
                    }
                    break;
                case "toolStripMenuItem_ReBackFee"://重新送請款
                    if (dgViewMF.CurrentRow.Cells["EventKind"].Value.ToString() != "" && (int)dgViewMF.CurrentRow.Cells["EventKind"].Value == 4)
                    {
                        int iFeeKEY = (int)dgViewMF.CurrentRow.Cells["EventID"].Value;
                        Public.CPatentFee patentFee = new LawtechPTSystemByFirm.Public.CPatentFee();
                        Public.CPatentFee.ReadOne(iFeeKEY, ref patentFee);

                        if (patentFee.IsClosing.HasValue && patentFee.IsClosing.Value)//判斷是否關帳
                        {
                            MessageBox.Show("該筆請款單號【" + patentFee.PPP + "】已被關帳，請洽帳務主管", "提示訊息", MessageBoxButtons.OK);
                            return;
                        }

                        if (patentFee.PPP != "")//判斷是否已登入請款單號
                        {
                            MessageBox.Show("已登錄了請款單號【" + patentFee.PPP + "】，若要修改，請洽帳務人員", "提示訊息", MessageBoxButtons.OK);
                            return;
                        }

                        //判斷是否有人使用中
                        int iLocker = Public.Utility.GetRecordAuth("PatentFeeT", "FeeKEY=" + dgViewMF.CurrentRow.Cells["EventID"].Value.ToString());
                        if (iLocker == -1 || iLocker == iWorkerID)
                        {
                            if (iLocker != iWorkerID)
                            {
                                Public.Utility.LockRecordAuth("PatentFeeT", iWorkerID, "FeeKEY=" + dgViewMF.CurrentRow.Cells["EventID"].Value.ToString());
                            }

                           
                            string str = "☆重送請款簽核(" + Properties.Settings.Default.WorkerName + " " + DateTime.Now.ToString("yyyy/MM/dd HH:mm") + ")";
                            patentFee.SingCodeStatus = str;
                            patentFee.LastModifyDateTime = DateTime.Now;
                            patentFee.LastModifyWorker = Properties.Settings.Default.WorkerName;
                            patentFee.Update();

                            dgViewMF.CurrentRow.Cells["SingCodeStatus"].Value = str;

                            Public.Utility.NuLockRecordAuth("PatentFeeT", "FeeKEY=" + dgViewMF.CurrentRow.Cells["EventID"].Value.ToString());
                        }
                        else
                        {
                            if (iLocker != -1)
                            {
                                Worker_Model worker = new Worker_Model();
                                Worker_Model.ReadOne(iLocker, ref  worker);

                                MessageBox.Show("很抱歉~~   目前該筆資料正被【" + worker.EmployeeName + "】使用中，請等候!!\r\n 謝謝", "提示訊息");
                            }
                        }
                    }
                    break;

                case "ToolStripMenuItem_PaymentFinish"://主管簽核 付款
                    if (dgViewMF.CurrentRow.Cells["EventKind"].Value.ToString() != "" && (int)dgViewMF.CurrentRow.Cells["EventKind"].Value == 5)
                    {

                        int iFeeKEY = (int)dgViewMF.CurrentRow.Cells["EventID"].Value;
                        Public.CPatentPayment patentFee = new LawtechPTSystemByFirm.Public.CPatentPayment();
                        Public.CPatentPayment.ReadOne((int)dgViewMF.CurrentRow.Cells["EventID"].Value, ref patentFee);


                        if (patentFee.IsClosing.HasValue && patentFee.IsClosing.Value)//判斷是否關帳
                        {
                            MessageBox.Show("該筆請款單號【" + patentFee.BillingNo + "】已被關帳，請洽帳務主管", "提示訊息", MessageBoxButtons.OK);
                            return;
                        }

                        if (patentFee.BillingNo != "")//判斷是否已登入請款單號
                        {
                            MessageBox.Show("已登錄了請款單號【" + patentFee.BillingNo + "】，若要修改，請洽帳務人員", "提示訊息", MessageBoxButtons.OK);
                            return;
                        }


                        
                        //判斷是否有人使用中
                        int iLocker = Public.Utility.GetRecordAuth("PatentPaymentT", "PaymentID=" + dgViewMF.CurrentRow.Cells["EventID"].Value.ToString());
                        if (iLocker == -1 || iLocker == iWorkerID)
                        {
                            if (iLocker != iWorkerID)
                            {
                                Public.Utility.LockRecordAuth("PatentPaymentT", iWorkerID, "PaymentID=" + dgViewMF.CurrentRow.Cells["EventID"].Value.ToString());
                            }
                            EditForm.EditPatentPayment edit = new LawtechPTSystemByFirm.EditForm.EditPatentPayment();
                            edit.Text = edit.Text + "(" + dgViewMF.CurrentRow.Cells["Country"].Value.ToString() + ")" + "--" + dgViewMF.CurrentRow.Cells["PatentNo"].Value.ToString();
                            edit.CountrySymbol = dgViewMF.CurrentRow.Cells["CountrySymbol"].Value.ToString();
                            edit.property_PaymentID = (int)dgViewMF.CurrentRow.Cells["EventID"].Value;
                            edit.ShowDialog();

                            Public.Utility.NuLockRecordAuth("PatentPaymentT", "PaymentID=" + dgViewMF.CurrentRow.Cells["EventID"].Value.ToString());
                        }
                        else
                        {
                            if (iLocker != -1)
                            {
                                Worker_Model worker = new Worker_Model();
                                Worker_Model.ReadOne(iLocker, ref  worker);
                                MessageBox.Show("很抱歉~~   目前該筆資料正被【" + worker.EmployeeName + "】使用中，請等候!!\r\n 謝謝", "提示訊息");
                            }
                        }
                    }
                    break;
                case "toolStripMenuItem_RejectionPayment"://退付款
                    if (dgViewMF.CurrentRow.Cells["EventKind"].Value.ToString() != "" && (int)dgViewMF.CurrentRow.Cells["EventKind"].Value == 5)
                    {

                        int iFeeKEY = (int)dgViewMF.CurrentRow.Cells["EventID"].Value;
                        Public.CPatentPayment patentFee = new LawtechPTSystemByFirm.Public.CPatentPayment();
                        Public.CPatentPayment.ReadOne(iFeeKEY, ref patentFee);

                        if (patentFee.IsClosing.HasValue && patentFee.IsClosing.Value )//判斷是否關帳
                        {
                            MessageBox.Show("該筆請款單號【" + patentFee.BillingNo + "】已被關帳，請洽帳務主管", "提示訊息", MessageBoxButtons.OK);
                            return;
                        }

                        if (patentFee.BillingNo != "")//判斷是否已登入請款單號
                        {
                            MessageBox.Show("已登錄了請款單號【" + patentFee.BillingNo + "】，若要修改，請洽帳務人員", "提示訊息", MessageBoxButtons.OK);
                            return;
                        }

                        int PaymentID=(int)dgViewMF.CurrentRow.Cells["EventID"].Value;

                        //判斷是否有人使用中
                        int iLocker = Public.Utility.GetRecordAuth("PatentPaymentT", "PaymentID=" + PaymentID.ToString());
                        if (iLocker == -1 || iLocker == iWorkerID)
                        {
                            if (iLocker != iWorkerID)
                            {
                                Public.Utility.LockRecordAuth("PatentPaymentT", iWorkerID, "PaymentID=" + PaymentID.ToString());
                            }

                            Public.CPatentPayment payment = new LawtechPTSystemByFirm.Public.CPatentPayment();
                            Public.CPatentPayment.ReadOne(PaymentID, ref payment);
                            
                            string str = "✖退付款(" + Properties.Settings.Default.WorkerName + " " + DateTime.Now.ToString("yyyy/MM/dd HH:mm") + ")";
                            payment.SingCodeStatus = str;
                           
                            payment.LastModifyWorker = Properties.Settings.Default.WorkerName;
                            payment.Update();

                            dgViewMF.CurrentRow.Cells["SingCodeStatus"].Value = str;

                            Public.Utility.NuLockRecordAuth("PatentPaymentT", "PaymentID=" + dgViewMF.CurrentRow.Cells["EventID"].Value.ToString());
                        }
                        else
                        {
                            if (iLocker != -1)
                            {
                                Worker_Model worker = new Worker_Model();
                                Worker_Model.ReadOne(iLocker, ref  worker);
                                MessageBox.Show("很抱歉~~   目前該筆資料正被【" + worker.EmployeeName + "】使用中，請等候!!\r\n 謝謝", "提示訊息");
                            }
                        }
                    }
                    break;
                case "toolStripMenuItem_ReBackPayment"://重新送付款
                    if (dgViewMF.CurrentRow.Cells["EventKind"].Value.ToString() != "" && (int)dgViewMF.CurrentRow.Cells["EventKind"].Value == 5)
                    {

                        int iFeeKEY = (int)dgViewMF.CurrentRow.Cells["EventID"].Value;
                        Public.CPatentPayment patentFee = new LawtechPTSystemByFirm.Public.CPatentPayment();
                        Public.CPatentPayment.ReadOne(iFeeKEY, ref patentFee);

                        if (patentFee.IsClosing.HasValue && patentFee.IsClosing.Value)//判斷是否關帳
                        {
                            MessageBox.Show("該筆請款單號【" + patentFee.BillingNo + "】已被關帳，請洽帳務主管", "提示訊息", MessageBoxButtons.OK);
                            return;
                        }

                        if (patentFee.BillingNo != "")//判斷是否已登入請款單號
                        {
                            MessageBox.Show("已登錄了請款單號【" + patentFee.BillingNo + "】，若要修改，請洽帳務人員", "提示訊息", MessageBoxButtons.OK);
                            return;
                        }

                        int PaymentID = (int)dgViewMF.CurrentRow.Cells["EventID"].Value;

                        //判斷是否有人使用中
                        int iLocker = Public.Utility.GetRecordAuth("PatentPaymentT", "PaymentID=" + PaymentID.ToString());
                        if (iLocker == -1 || iLocker == iWorkerID)
                        {
                            if (iLocker != iWorkerID)
                            {
                                Public.Utility.LockRecordAuth("PatentPaymentT", iWorkerID, "PaymentID=" + PaymentID.ToString());
                            }

                            Public.CPatentPayment payment = new LawtechPTSystemByFirm.Public.CPatentPayment();
                            Public.CPatentPayment.ReadOne(PaymentID, ref payment);
                            
                            string str = "☆重送付款簽核(" + Properties.Settings.Default.WorkerName + " " + DateTime.Now.ToString("yyyy/MM/dd HH:mm") + ")";
                            payment.SingCodeStatus = str;
                          
                            payment.LastModifyWorker = Properties.Settings.Default.WorkerName;
                            payment.Update();

                            dgViewMF.CurrentRow.Cells["SingCodeStatus"].Value = str;

                            Public.Utility.NuLockRecordAuth("PatentPaymentT", "PaymentID=" + dgViewMF.CurrentRow.Cells["EventID"].Value.ToString());
                        }
                        else
                        {
                            if (iLocker != -1)
                            {
                                Worker_Model worker = new Worker_Model();
                                Worker_Model.ReadOne(iLocker, ref  worker);
                                MessageBox.Show("很抱歉~~   目前該筆資料正被【" + worker.EmployeeName + "】使用中，請等候!!\r\n 謝謝", "提示訊息");
                            }
                        }
                    }

                    break;
                case "toolStripMenuItem_SetPatentFee":
                    US.PatentControlPeriod controlperiod = new LawtechPTSystemByFirm.US.PatentControlPeriod();
                    if (controlperiod.ShowDialog() == DialogResult.OK)
                    {
                        PatentControlPeriodTime = controlperiod.patentcontrol;
                    }                    
                    break;

                case "ToolStripMenuItem_ConfirmPayment"://確認已完成付款
                    if(dgViewMF.CurrentRow!=null)
                    {

                        int iFeeKEY = (int)dgViewMF.CurrentRow.Cells["EventID"].Value;
                        Public.CPatentPayment patentFee = new LawtechPTSystemByFirm.Public.CPatentPayment();
                        Public.CPatentPayment.ReadOne(iFeeKEY, ref patentFee);


                        if (patentFee.IsClosing.HasValue && patentFee.IsClosing.Value)//判斷是否關帳
                        {
                            MessageBox.Show("該筆請款單號【" + patentFee.BillingNo + "】已被關帳，請洽帳務主管", "提示訊息", MessageBoxButtons.OK);
                            return;
                        }

                       
                        US.PaymentFinish payfinish = new LawtechPTSystemByFirm.US.PaymentFinish();
                        payfinish.TypeKind = 1;
                        payfinish.PaymentID = (int)dgViewMF.CurrentRow.Cells["EventID"].Value;
                        payfinish.DGvr = dgViewMF.CurrentRow;
                        payfinish.ShowDialog();
                    }
                    break;

                case "ToolStripMenuItem_SendMail":
                    if (dgViewMF.CurrentRow != null)
                    {
                        US.NotificationLetter letter = new LawtechPTSystemByFirm.US.NotificationLetter();
                        letter.ApplicantKeys = dgViewMF.CurrentRow.Cells["ApplicantKeys"].Value.ToString();
                        letter.CaseKey = dgViewMF.CurrentRow.Cells["EventID"].Value != null ? (int)dgViewMF.CurrentRow.Cells["EventID"].Value : -1;
                       
                        string sEventType = dgViewMF.CurrentRow.Cells["EventType"].Value.ToString();
                        switch (sEventType)
                        {
                            case "3":
                                letter.EmailSampleType = "Patent";
                                break;
                            case "1":
                                letter.EmailSampleType = "PatentEvent";
                                break;
                            case "4":
                                letter.EmailSampleType = "PatentFee";
                                break;
                            case "5":
                                letter.EmailSampleType = "PatentPayment";                                
                                
                                break;
                        }
                        letter.DelegateType = dgViewMF.CurrentRow.Cells["DelegateType"].Value != null ? (int)dgViewMF.CurrentRow.Cells["DelegateType"].Value : -1;
                        letter.Attorney = dgViewMF.CurrentRow.Cells["AttorneyKey"].Value != DBNull.Value ? (int)dgViewMF.CurrentRow.Cells["AttorneyKey"].Value : -1;                       
                        letter.CaseNo = dgViewMF.CurrentRow.Cells["PatentNo"].Value.ToString();
                        letter.Show();
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
            try
            {
                if (dgViewMF.CurrentRow != null && dgViewMF.CurrentRow.Cells["EventID"].Value != DBNull.Value && !string.IsNullOrEmpty(dgViewMF.CurrentRow.Cells["EventID"].Value.ToString()) )
                {
                    this.patWorkReportTTableAdapter.Fill(qS_DataSet.PatWorkReportT, (int)dgViewMF.CurrentRow.Cells["EventType"].Value, (int)dgViewMF.CurrentRow.Cells["EventID"].Value);
                }
                else
                {
                    this.qS_DataSet.PatWorkReportT.Rows.Clear();
                }
            }
            catch(System.Exception ex)
            {
                string ss = ex.Message;
                MessageBox.Show(ex.Message);
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
                        AddFrom.AddPatentWorkEvent Add = new LawtechPTSystemByFirm.AddFrom.AddPatentWorkEvent();
                        Add.EventID = (int)dgViewMF.CurrentRow.Cells["EventID"].Value;
                        Add.EventType = (int)dgViewMF.CurrentRow.Cells["EventType"].Value;
                        Add.ShowDialog();
                    }
                    break;

                case "bindingNavigatorDeleteItem":
                case "StripMenuItem_Del":
                    if (dataGridView_WorkList.CurrentRow!=null)
                    {
                        if (MessageBox.Show("是否確定刪除\r\n" + dataGridView_WorkList.CurrentRow.Cells["WorkContent"].Value.ToString(), "確認視窗", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            int iWorkReportID = (int)dataGridView_WorkList.CurrentRow.Cells["WorkReportID"].Value;
                            Public.CPatWorkReport DelWorkDetail = new Public.CPatWorkReport();
                            DelWorkDetail.Delete(iWorkReportID);
                            dataGridView_WorkList.Rows.Remove(dataGridView_WorkList.CurrentRow);
                            this.qS_DataSet.PatentFeeT.AcceptChanges();
                            MessageBox.Show("刪除待處理作業成功", "提示訊息", MessageBoxButtons.OK);
                        }
                    }
                    break;
                case "ToolStripMenuItem_Set":

                    break;                 
                case "toolStripButton_WorkListEdit":
                    if (dataGridView_WorkList.CurrentRow != null)
                    {
                        EditForm.EditPatentWorkEvent workevent = new LawtechPTSystemByFirm.EditForm.EditPatentWorkEvent();
                        workevent.EventID = (int)dgViewMF.CurrentRow.Cells["EventID"].Value;
                        workevent.EventType = (int)dgViewMF.CurrentRow.Cells["EventType"].Value;
                        workevent.WorkReportID = (int)dataGridView_WorkList.CurrentRow.Cells["WorkReportID"].Value;
                        workevent.ShowDialog();
                    }
                    break;
                case "ToolStripMenuItem_Start":
                    if (dataGridView_WorkList.CurrentRow != null)
                    {
                        int iKey=(int)dataGridView_WorkList.CurrentRow.Cells["WorkReportID"].Value;
                        Public.CPatWorkReport WorkDetail = new Public.CPatWorkReport();
                        Public.CPatWorkReport.ReadOne(iKey, ref WorkDetail);

                        WorkDetail.IsStart = true;
                        WorkDetail.StartTime = DateTime.Now;

                        QS_DataSet.PatWorkReportTRow dr = dt_WorkListEvent.FindByWorkReportID(iKey);

                        if (WorkDetail.Progress.HasValue)
                        {
                            Public.CProcessStep processStep = new LawtechPTSystemByFirm.Public.CProcessStep();
                            Public.CProcessStep.ReadOne(WorkDetail.Progress.Value, ref processStep);
                           
                            if (WorkDetail.Worker == -1)
                            {
                                WorkDetail.Worker = Properties.Settings.Default.WorkerKEY;
                                dr["Worker"] = WorkDetail.Worker;
                                dr["WorkerName"] = Properties.Settings.Default.WorkerName;
                            }                            

                            if (processStep.ProcessHandleKEY >0 && processStep.Days.HasValue)
                            {
                                WorkDetail.EstimateDateTime = WorkDetail.StartTime.Value.AddDays(processStep.Days.Value).AddHours(processStep.Hours.Value).AddMinutes(processStep.Minutes.Value);
                            }                           
                        }

                       
                        WorkDetail.Update();

                        dr["IsStart"] =WorkDetail.IsStart.HasValue? WorkDetail.IsStart.Value:false;
                        if (WorkDetail.StartTime.HasValue)
                        {
                            dr["StartTime"] = WorkDetail.StartTime.Value;
                        }
                        else
                        {
                            dr["StartTime"] = DBNull.Value;
                        }
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
                        Public.CPatWorkReport WorkDetail = new Public.CPatWorkReport();
                        Public.CPatWorkReport.ReadOne(iKey, ref WorkDetail);
                        

                        QS_DataSet.PatWorkReportTRow dr = dt_WorkListEvent.FindByWorkReportID(iKey);

                        WorkDetail.IsStart = true;
                        if (WorkDetail.Worker == -1)
                        {
                            WorkDetail.Worker = Properties.Settings.Default.WorkerKEY;
                            dr["Worker"] = WorkDetail.Worker;
                            dr["WorkerName"] = Properties.Settings.Default.WorkerName;
                        }
                        if (!WorkDetail.StartTime.HasValue )
                        {
                            WorkDetail.StartTime = DateTime.Now;
                        }
                        WorkDetail.EndTime = DateTime.Now;

                        TimeSpan ts = WorkDetail.EndTime.Value - WorkDetail.StartTime.Value;

                        string returnValue = "";
                       
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

        #region =============相關文件=============
        private void toolStripLabel_UpdateFileList_Click(object sender, EventArgs e)
        {
            if (dgViewMF.CurrentRow != null)
            {
                ViewUpdateFileList subForm = new ViewUpdateFileList();
                subForm.Text = dgViewMF.CurrentRow.Cells["PatentNo"].Value.ToString() + "的申請案相關文件";
                subForm.FileKind = 3;
                subForm.FileType = 0;
                subForm.MainParentID = (int)dgViewMF.CurrentRow.Cells["PatentID"].Value;                
                subForm.ShowDialog();
            }
        }
        #endregion

        #region ============contextMenuMain_Opening============
        private void contextMenuMain_Opening(object sender, CancelEventArgs e)
        {
            if (dgViewMF.CurrentRow != null)
            {
                this.ToolStripMenuItem_PaymentComplete.Visible = false;
                this.結束管制ToolStripMenuItem.Visible = false;
                this.toolStripMenuItem_NotFinish.Visible = false;
                this.來函直接歸檔ToolStripMenuItem.Visible = false;
                this.來函續辦ToolStripMenuItem.Visible = false;
                this.委辦送件完成ToolStripMenuItem.Visible = false;
                this.放棄ToolStripMenuItem.Visible = false;
                ToolStripMenuItem_ClosePatent.Visible=false;
                this.ToolStripMenuItem_PaymentFinish.Visible = false;
                this.ToolStripMenuItem_FinishFee.Visible = false;
                toolStripMenuItem_SetPatentFee.Visible = false;
                ToolStripMenuItem_ConfirmPayment.Visible = false;
                this.toolStripMenuItem_RejectionFee.Visible = false;
                this.toolStripMenuItem_ReBackFee.Visible = false;
                this.toolStripMenuItem_RejectionPayment.Visible = false;
                this.toolStripMenuItem_ReBackPayment.Visible = false;

                if ( dgViewMF.CurrentRow.Cells["FinishDate"].Value.GetType().ToString()!="System.DBNull")
                {
                    //this.toolStripMenuItem_NotFinish.Visible = true;
                }
                else
                {                    
                    if (dgViewMF.CurrentRow.Cells["EventType"].Value.ToString() == "1")  //委辦
                    {
                        this.放棄ToolStripMenuItem.Visible = true;
                        this.委辦送件完成ToolStripMenuItem.Visible = true;

                    }
                    else if (dgViewMF.CurrentRow.Cells["EventType"].Value.ToString() == "2")  //來函
                    {
                        this.放棄ToolStripMenuItem.Visible = true;
                        this.來函直接歸檔ToolStripMenuItem.Visible = true;
                        
                    }
                    else if (dgViewMF.CurrentRow.Cells["EventType"].Value.ToString() == "3")//年費
                    {
                        ToolStripMenuItem_PaymentComplete.Visible = true;
                        ToolStripMenuItem_ClosePatent.Visible = true;
                        toolStripMenuItem_SetPatentFee.Visible = true;
                    }
                    else if (dgViewMF.CurrentRow.Cells["EventType"].Value.ToString() == "4")//請款
                    {
                        if (OfficeRole == 2 || OfficeRole == 0)
                        {
                            //請款功能
                            this.ToolStripMenuItem_FinishFee.Visible = true;
                            this.toolStripMenuItem_RejectionFee.Visible = true;
                        }
                        else if (OfficeRole == 1)
                        {
                            this.toolStripMenuItem_ReBackFee.Visible = true;
                        }
                    }
                    else if (dgViewMF.CurrentRow.Cells["EventType"].Value.ToString() == "5")//付款
                    {
                        //付款
                        if (OfficeRole == 2 || OfficeRole == 0)
                        {
                            this.ToolStripMenuItem_PaymentFinish.Visible = true;
                            this.toolStripMenuItem_RejectionPayment.Visible = true;
                        }
                        else if (OfficeRole == 1)
                        {
                            toolStripMenuItem_ReBackPayment.Visible = true;
                        }
                        ToolStripMenuItem_ConfirmPayment.Visible = true;

                    }
                  
                }
            }
            else
            {
                e.Cancel = true;
            }

        }
        #endregion

        #region toolStripLabel_PatentView_Click
        private void toolStripLabel_PatentView_Click(object sender, EventArgs e)
        {
            PatentHistoryRecord1 patent = new LawtechPTSystemByFirm.SubFrom.PatentHistoryRecord1();
            patent.property_PatentID = (int)dgViewMF.CurrentRow.Cells["PatentID"].Value;
            if (radoB.Checked)
            {
                patent.TabSelectedIndex = 1;
            }
            else if (radoPatentFee.Checked)
            {
                patent.TabSelectedIndex = 0;
            }
            else if (radioFee.Checked)
            {
                patent.TabSelectedIndex = 2;
            }
            else
            {
                patent.TabSelectedIndex = 3;
            }
            patent.Show();
        }
        #endregion

        #region contextMenuStrip1_Opening
        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (dataGridView_WorkList.CurrentRow != null)
            {
                if (dataGridView_WorkList.CurrentRow.Cells["IsStart"].Value!=DBNull.Value && (bool)dataGridView_WorkList.CurrentRow.Cells["IsStart"].Value)
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

        #region =============案件完整歷程=============
        private void toolStripButton__CompleteHistory_Click(object sender, EventArgs e)
        {
            if (dgViewMF.SelectedRows.Count > 0)
            {
                ViewFrom.PatentCompleteHistory history = new LawtechPTSystemByFirm.ViewFrom.PatentCompleteHistory();
                history.Gv = dgViewMF;
                history.Show();
            }
        }
        #endregion

        #region dataGridView_WorkList_CellDoubleClick
        private void dataGridView_WorkList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView_WorkList.CurrentRow != null)
            {
                contextMenuStrip1_ItemClicked(contextMenuStrip1,new ToolStripItemClickedEventArgs( toolStripButton_WorkListEdit));
            }
        }
        #endregion

        #region dgViewMF_CellDoubleClick
        private void dgViewMF_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != -1 && e.RowIndex != -1)
            {
                toolStripLabel_PatentView_Click(null, null);
            }
        }
        #endregion

        #region but_ShowDetail_Click
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
        #endregion

        #region PATControlEvent_KeyDown
        private void PATControlEvent_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt)
            {
                if (e.KeyCode == Keys.E)
                {
                    but_ShowDetail_Click(null, null);
                }
            }
        }
        #endregion

    }
}
