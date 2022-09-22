
using System;
using System.ComponentModel;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LawtechPTSystemByFirm.SubFrom
{
    /// <summary>
    /// 專利--待辦事項管制表
    /// </summary>
    public partial class PATControlEventList : Form
    {
        private object m_objOpt = System.Reflection.Missing.Value;

        BindingSource bSource_Control;

        UserPermissionForm myPermission;
        private const string ProgramSymbol = "PATControlEventList";
        private const string SourceTableName = "V_PATControlEventList";

        private int  p_EventType=1;//1.事件記錄
        #region ==========Property ==========
        
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
            get { return Properties.Settings.Default.OfficeRole; }           
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

        public PATControlEventList()
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
        /// 當前事件管制清單資料 DataRow
        /// </summary>
        public System.Data.DataRow dt_CurrentControlEventDataRow
        {
            get
            {
                DataRow dr=dt_ControlEvent.Rows.Find((int)dgViewMF.CurrentRow.Cells["PatComitEventID"].Value);
                return dr;
            }
        }

        private DataTable dt_PatWorkReportT = new DataTable();
        /// <summary>
        /// 待處理事件明細資料表
        /// </summary>
        public System.Data.DataTable DT_PatWorkReportT
        {
            get
            {
                return dt_PatWorkReportT;
            }
        }
        #endregion

        #region PATControlEvent_Load 、 PATControlEvent_FormClosed
        private void PATControlEvent_Load(object sender, EventArgs e)
        {           
            
            Public.PublicForm Forms = new LawtechPTSystemByFirm.Public.PublicForm();
            Forms.PATControlEventList = this;            

            //取得登入者身份
            iWorkerID = Properties.Settings.Default.WorkerKEY;
            Worker_Model worker = new Worker_Model();
            Worker_Model.ReadOne(iWorkerID, ref  worker);

            iOfficeRole = worker.OfficeRole.Value;
            strWorkerName = worker.EmployeeName;

            //取得權限
            myPermission = new UserPermissionForm(Properties.Settings.Default.WorkerKEY, ProgramSymbol);

            System.Windows.Forms.BindingNavigator[] listbinding = { bindingNavigator1, bindingNavigator2 };
            System.Windows.Forms.ContextMenuStrip[] listtMenu = { contextMenuMain, contextMenuStrip1 };

            //確認可使用的功能選單
            Public.CommonFunctions.CheckMeunItemVisible(listbinding, myPermission.UserPermission);
            Public.CommonFunctions.CheckMeunItemVisible(listtMenu, myPermission.UserPermission); 

            bSource_Control = new BindingSource();
            dgViewMF.DataSource = bSource_Control;
            bindingNavigator1.BindingSource = bSource_Control;            

            Public.DLL dll = new LawtechPTSystemByFirm.Public.DLL();

            PatentControlPeriodTime = dll.GetPatentControlPeriodTime;

            Public.Utility.SetLoadDataRange(userControlFilterDate1);

            if (Properties.Settings.Default.IsLoadData)
            {
                butQuery_Click(null, null);
            }
        }

        private void PATControlEvent_FormClosed(object sender, FormClosedEventArgs e)
        {
            Public.PublicForm Forms = new LawtechPTSystemByFirm.Public.PublicForm();
            Forms.PATControlEventList = null;
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
            if (chb_Finish.Checked) //已完成
            {
                strFilter += " FinishDate is not null ";
            }
            else if (chb_NoFinish.Checked)//未完成
            {
                strFilter += " FinishDate is null ";
            }

            string FullWhere = Public.CommonFunctions.GetSQLScript(QueryFilter1, QueryFilter2, rb_and.Checked ? " and " : " or ", userControlFilterDate1);

            string strSqlwhere = "";
            if (!string.IsNullOrEmpty(strFilter.Trim()) && string.IsNullOrEmpty(FullWhere.Trim()))
            {
                strSqlwhere = strFilter;
            }
            else if (string.IsNullOrEmpty(strFilter.Trim()) && !string.IsNullOrEmpty(FullWhere.Trim()))
            {
                strSqlwhere = FullWhere;
            }
            else if (!string.IsNullOrEmpty(strFilter.Trim()) && !string.IsNullOrEmpty(FullWhere.Trim()))
            {
                strSqlwhere = strFilter + " and " + FullWhere;
            }


            System.Data.DataTable dt_ComitEvent = GetComitEvent(strSqlwhere);

            bSource_Control.DataSource = dt_ComitEvent;

            butQuery.Enabled = true;
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
           
            string strNotifyEventSQL = string.Format(@"SELECT *  from  V_PATControlEventList with(nolock)  {0}", !string.IsNullOrEmpty(strWhere) ? " where "+strWhere :"");

            Public.DLL dll = new LawtechPTSystemByFirm.Public.DLL();
            System.Data.DataTable dtComitEvent = new System.Data.DataTable(); 
            dll.FetchDataTable(strNotifyEventSQL, dtComitEvent);
            if (dtComitEvent.PrimaryKey.Length == 0)
            {
                DataColumn[] pk = { dtComitEvent.Columns["PatComitEventID"] };
                dtComitEvent.PrimaryKey = pk;
            }
            return dtComitEvent;
        }
        #endregion 

        #region 關閉按鈕 private void butClose_Click(object sender, EventArgs e)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butClose_Click(object sender, EventArgs e)
        {
            this.Close();
        } 
        #endregion

        #region  dgViewMF 快顯選單、相關事件
        private void contextMenuMain_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            contextMenuMain.Visible = false;

            switch (e.ClickedItem.Name)
            {
                case "EdittoolStripMenuItem":
                case "toolStripButtonEditItem":
                    if (dgViewMF.CurrentRow != null)
                    {
                        //判斷是否有人使用中
                        int iLocker = Public.Utility.GetRecordAuth("PatComitEventT", "PatComitEventID=" + dgViewMF.CurrentRow.Cells["PatComitEventID"].Value.ToString());
                        if (iLocker == -1 || iLocker == iWorkerID)
                        {
                            if (iLocker != iWorkerID)
                            {
                                Public.Utility.LockRecordAuth("PatComitEventT", iWorkerID, "PatComitEventID=" + dgViewMF.CurrentRow.Cells["PatComitEventID"].Value.ToString());
                            }
                            EditForm.EditComitEvent comit_Edit = new LawtechPTSystemByFirm.EditForm.EditComitEvent();
                            comit_Edit.PatComitEventID = (int)dgViewMF.CurrentRow.Cells["PatComitEventID"].Value;
                            comit_Edit.PatentID = (int)dgViewMF.CurrentRow.Cells["PatentID"].Value;
                            comit_Edit.Text += "(" + dgViewMF.CurrentRow.Cells["PatentNo"].Value.ToString() + "  " + dgViewMF.CurrentRow.Cells["Country"].Value.ToString() + ")";
                            comit_Edit.CountrySymbol = dgViewMF.CurrentRow.Cells["CountrySymbol"].Value.ToString();
                            comit_Edit.ShowDialog();
                        }
                        else
                        {
                            if (iLocker != -1)//無人使用中
                            {
                                Worker_Model worker = new Worker_Model();
                                Worker_Model.ReadOne(iLocker, ref  worker);
                                MessageBox.Show("很抱歉~~   目前該筆資料正被【" + worker.EmployeeName + "】使用中，請等候!!\r\n 謝謝", "提示訊息");
                            }
                        }
                    }
                    break;
                case "放棄ToolStripMenuItem":  //放棄
                    US.AbortControl AbortMF = new US.AbortControl();                   
                    AbortMF.PatentID = (int)dgViewMF.CurrentRow.Cells["PatentID"].Value;
                    AbortMF.EventType =p_EventType; 
                    AbortMF.EventID = (int)dgViewMF.CurrentRow.Cells["EventID"].Value;
                    AbortMF.ShowDialog();
                    break;
                case "ToolStripMenuItem_AddEventItem":  //新增事件記錄

                    AddFrom.AddPatentComitEvent ComitEvent = new AddFrom.AddPatentComitEvent();
                    ComitEvent.Text += "--" + dgViewMF.CurrentRow.Cells["PatentNo"].Value.ToString();
                    ComitEvent.PatentID = (int)dgViewMF.CurrentRow.Cells["PatentID"].Value;
                    if (dgViewMF.CurrentRow.Cells["CountrySymbol"].Value != null && !string.IsNullOrEmpty(dgViewMF.CurrentRow.Cells["CountrySymbol"].Value.ToString()))
                    {
                        ComitEvent.CountrySymbol = dgViewMF.CurrentRow.Cells["CountrySymbol"].Value.ToString();
                    }
                    ComitEvent.ShowDialog();

                    break;

                case "ToolStripMenuItem_EventFinish":  //事件處理完成
                   
                        US.PatentComitEventFinish Comitfinish = new US.PatentComitEventFinish();
                        Comitfinish.Text += "--" + dgViewMF.CurrentRow.Cells["PatentNo"].Value.ToString();
                        Comitfinish.EventType = p_EventType;
                        Comitfinish.EventID = (int)dgViewMF.CurrentRow.Cells["EventID"].Value;
                        if (Comitfinish.ShowDialog() == DialogResult.OK)
                        {
                            dgViewMF.CurrentRow.Cells["FinishDate"].Value = Comitfinish.FinishDate;
                            dgViewMF.CurrentRow.Cells["Result"].Value = Comitfinish.Result;
                            dgViewMF.CurrentRow.Cells["DiffDueDate"].Value = 0;
                            dt_ControlEvent.AcceptChanges();
                        }
                    
                    break;

                case "toolStripMenuItem_NotFinish":
                    if (MessageBox.Show("是否確定變更為【未完成處理的事件】?", "提示訊息", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        int iComitEventID = (int)dgViewMF.CurrentRow.Cells["EventID"].Value;
                        Public.CPatComitEvent Comit = new Public.CPatComitEvent();
                        Public.CPatComitEvent.ReadOne(iComitEventID, ref Comit);

                        Comit.FinishDate = null;                       
                        Comit.LastModifyWorker = Properties.Settings.Default.WorkerName;
                        Comit.Result =Comit.LastModifyWorker+" "+ DateTime.Now.ToString("yyyy/MM/dd") + " 變更為未完成事件";
                        Comit.Update();
                        dgViewMF.CurrentRow.Cells["FinishDate"].Value = System.DBNull.Value;
                        dt_ControlEvent.AcceptChanges();
                    }
                    break;            

                case "ToolStripMenuItem_SendMail":
                    if (dgViewMF.CurrentRow != null)
                    {
                        US.NotificationLetter letter = new LawtechPTSystemByFirm.US.NotificationLetter();
                        letter.ApplicantKeys = dgViewMF.CurrentRow.Cells["ApplicantKeys"].Value.ToString();
                        letter.CaseKey = dgViewMF.CurrentRow.Cells["EventID"].Value != null ? (int)dgViewMF.CurrentRow.Cells["EventID"].Value : -1;

                        letter.EmailSampleType = "PatentEvent";
                        letter.DelegateType = dgViewMF.CurrentRow.Cells["DelegateType"].Value != null ? (int)dgViewMF.CurrentRow.Cells["DelegateType"].Value : -1;
                        letter.Attorney = dgViewMF.CurrentRow.Cells["AttorneyKey"].Value != DBNull.Value ? (int)dgViewMF.CurrentRow.Cells["AttorneyKey"].Value : -1;
                        letter.CaseNo = dgViewMF.CurrentRow.Cells["PatentNo"].Value.ToString();
                        letter.Show();
                    }
                    break;
                case "ToolStripMenuItem_SingCodeEvent"://主管簽核
                    if (dgViewMF.CurrentRow!= null)
                    {
                        int iComitEventID = (int)dgViewMF.CurrentRow.Cells["EventID"].Value;
                        Public.CPatComitEvent Comit = new Public.CPatComitEvent();
                        Public.CPatComitEvent.ReadOne(iComitEventID, ref Comit);

                       
                        //判斷是否有人使用中
                        int iLocker = Public.Utility.GetRecordAuth("PatComitEventT", "PatComitEventID=" + dgViewMF.CurrentRow.Cells["EventID"].Value.ToString());
                        if (iLocker == -1 || iLocker == iWorkerID)
                        {
                            if (iLocker != iWorkerID)
                            {
                                Public.Utility.LockRecordAuth("PatComitEventT", iWorkerID, "PatComitEventID=" + dgViewMF.CurrentRow.Cells["EventID"].Value.ToString());
                            }

                            EditForm.EditComitEvent edit = new LawtechPTSystemByFirm.EditForm.EditComitEvent();
                            edit.PatentID = (int)dgViewMF.CurrentRow.Cells["PatentID"].Value;
                            edit.PatComitEventID = (int)dgViewMF.CurrentRow.Cells["EventID"].Value;
                            edit.CountrySymbol = dgViewMF.CurrentRow.Cells["CountrySymbol"].Value.ToString();
                            edit.ShowDialog();

                            Public.Utility.NuLockRecordAuth("PatComitEventT", "PatComitEventID=" + dgViewMF.CurrentRow.Cells["EventID"].Value.ToString());
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
                case "toolStripMenuItem_SetGridColumn":
                    SetGridColumnT gc = new SetGridColumnT();
                    gc.CurrentGridSymboID = dgViewMF.Tag.ToString();
                    gc.Show();
                    break;
            }
        }

        #region private void dgViewMF_DataError(object sender, DataGridViewDataErrorEventArgs e)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgViewMF_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = false;
        } 
        #endregion

        #region private void dgViewMF_SelectionChanged(object sender, EventArgs e)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgViewMF_SelectionChanged(object sender, EventArgs e)
        {
            try
            {

                if (dgViewMF.CurrentRow != null && dgViewMF.CurrentRow.Cells["EventID"].Value != DBNull.Value && !string.IsNullOrEmpty(dgViewMF.CurrentRow.Cells["EventID"].Value.ToString()))
                {
                    Public.CPatentPublicFunction.GetPatWorkReportT("1", dgViewMF.CurrentRow.Cells["EventID"].Value.ToString(), ref dt_PatWorkReportT);
                    tagTitle1.TitleLableText = "作業確認項目--" + dgViewMF.CurrentRow.Cells["EventContent"].Value.ToString();
                }
                else
                {
                    this.DT_PatWorkReportT.Rows.Clear();
                }

                if (patWorkReportTBindingSource.DataSource == null || patWorkReportTBindingSource.DataSource != DT_PatWorkReportT)
                {
                    patWorkReportTBindingSource.DataSource = dt_PatWorkReportT;
                }
            }
            catch (System.Exception ex)
            {
                string ss = ex.Message;
                MessageBox.Show(ex.Message);
            }
        } 
        #endregion


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
                        Add.EventType = p_EventType;
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
                        workevent.EventType = p_EventType;
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

                        if (WorkDetail.Progress.HasValue)
                        {
                            Public.CProcessStep processStep = new LawtechPTSystemByFirm.Public.CProcessStep();
                            Public.CProcessStep.ReadOne(WorkDetail.Progress.Value, ref processStep);

                            if (WorkDetail.Worker.HasValue==false || WorkDetail.Worker == -1  )
                            {
                                WorkDetail.Worker = Properties.Settings.Default.WorkerKEY;                               
                            }                            

                            if (processStep.ProcessHandleKEY >0 && processStep.Days.HasValue)
                            {
                                WorkDetail.EstimateDateTime = WorkDetail.StartTime.Value.AddDays(processStep.Days.Value).AddHours(processStep.Hours.Value).AddMinutes(processStep.Minutes.Value);
                            }                           
                        }
                       
                        WorkDetail.Update();

                        DataRow dr = Public.CPatentPublicFunction.GetPatWorkReport(iKey.ToString());
                        DataRow drCurrent = dt_PatWorkReportT.Rows.Find(iKey);
                        drCurrent.ItemArray = dr.ItemArray;
                        drCurrent.AcceptChanges();

                    }
                    break;
                case "ToolStripMenuItem_Finish":
                    if (dataGridView_WorkList.CurrentRow != null)
                    {
                        int iKey = (int)dataGridView_WorkList.CurrentRow.Cells["WorkReportID"].Value;
                        Public.CPatWorkReport WorkDetail = new Public.CPatWorkReport();
                        Public.CPatWorkReport.ReadOne(iKey, ref WorkDetail);
                        
                        WorkDetail.IsStart = true;
                        if (WorkDetail.Worker == -1)
                        {
                            WorkDetail.Worker = Properties.Settings.Default.WorkerKEY;                         
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

                        DataRow dr = Public.CPatentPublicFunction.GetPatWorkReport(iKey.ToString());
                        DataRow drCurrent = dt_PatWorkReportT.Rows.Find(iKey);
                        drCurrent.ItemArray = dr.ItemArray;
                        drCurrent.AcceptChanges();
                    }
                    break;
                case "toolStripMenuItem_SetGridColumnDetail":
                    SetGridColumnT gc = new SetGridColumnT();
                    gc.CurrentGridSymboID = dataGridView_WorkList.Tag.ToString();
                    gc.Show();
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
                subForm.FileType = 1;
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
                this.ToolStripMenuItem_AddEventItem.Visible = true;               
                this.toolStripMenuItem_NotFinish.Visible = false;                
                this.ToolStripMenuItem_EventFinish.Visible = false;
                this.放棄ToolStripMenuItem.Visible = true;
                this.ToolStripMenuItem_SingCodeEvent.Visible = false;

                if (dgViewMF.CurrentRow.Cells["FinishDate"].Value.GetType().ToString() != "System.DBNull")
                {
                      this.toolStripMenuItem_NotFinish.Visible =  true;
                }
                else
                {                  
                    this.ToolStripMenuItem_EventFinish.Visible = true;
                }

                if (OfficeRole == 2 || OfficeRole == 0)
                {
                    this.ToolStripMenuItem_SingCodeEvent.Visible = true;
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

            patent.TabSelectedIndex = 1;
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

        #region 匯出CSV private void toolStripButton_Export_Click(object sender, EventArgs e)
        /// <summary>
        /// 匯出CSV
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton_Export_Click(object sender, EventArgs e)
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

        #region 水平/垂直 畫面 private void toolStripButton_Orientation_Click(object sender, EventArgs e)
        /// <summary>
        /// 水平/垂直 畫面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton_Orientation_Click(object sender, EventArgs e)
        {
            Public.Utility.SsplitContainerHorizontal(ref splitContainer1);
        } 
        #endregion

      

    }
}
