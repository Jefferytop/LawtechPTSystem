using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LawtechPTSystemByFirm.SubFrom
{
    /// <summary>
    /// 商標-請款管制表
    /// </summary>
    public partial class TrademarkControlFeeList : Form
    {
        private object m_objOpt = System.Reflection.Missing.Value;

        BindingSource bSource_Control;

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

        #region =========資料集=========
        /// <summary>
        /// 請款管制清單資料表
        /// </summary>
        public System.Data.DataTable dt_ControlFee
        {
            get
            {
                return (System.Data.DataTable)bSource_Control.DataSource;
            }
        }

        #endregion

        UserPermissionForm myPermission;
        private const string ProgramSymbol = "TrademarkControlFeeList";
        private const string SourceTableName = "V_TrademarkControlFeeList";

        public TrademarkControlFeeList()
        {
            InitializeComponent();
            dgViewMF.AutoGenerateColumns = false;          
            Public.DynamicGridViewColumn.GetGridColum(ref dgViewMF);            
        }
        
        #region PATControlEvent_Load 、 PATControlEvent_FormClosed
        private void PATControlEvent_Load(object sender, EventArgs e)
        {           
            
            Public.PublicForm Forms = new LawtechPTSystemByFirm.Public.PublicForm();
            Forms.TrademarkControlFeeList = this;
          
            //取得登入者身份
            iWorkerID = Properties.Settings.Default.WorkerKEY;
            Worker_Model worker = new Worker_Model();
            Worker_Model.ReadOne(iWorkerID, ref  worker);

            iOfficeRole = worker.OfficeRole.Value;
            strWorkerName = worker.EmployeeName;


            //取得權限
            myPermission = new UserPermissionForm(Properties.Settings.Default.WorkerKEY, ProgramSymbol);

            System.Windows.Forms.BindingNavigator[] listbinding = { bindingNavigator1 };
            System.Windows.Forms.ContextMenuStrip[] listtMenu = { contextMenuMain };

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
            Forms.TrademarkControlFeeList = null;
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
                strFilter += " PayDate is not null ";
            }
            else if (chb_NoFinish.Checked)//未完成
            {
                strFilter += " PayDate is null ";
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

            string strSQL = Public.CommonFunctions.GetSQLScript(QueryFilter1, QueryFilter2, rb_and.Checked ? " and " : " or ", userControlFilterDate1);

            System.Data.DataTable dt_ComitEvent = GetFeeEvent(strSqlwhere);

            bSource_Control.DataSource = dt_ComitEvent;
                      
            butQuery.Enabled = true;
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
            string strNotifyEventSQL = string.Format(@"select * from V_TrademarkControlFeeList  {0}", !string.IsNullOrEmpty(strWhere) ? " where " + strWhere : "");

            Public.DLL dll = new LawtechPTSystemByFirm.Public.DLL();
            System.Data.DataTable dtFeeEvent = new System.Data.DataTable();
            dll.FetchDataTable(strNotifyEventSQL, dtFeeEvent);
            return dtFeeEvent;
        }
        #endregion


        private void butClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region =========匯出CSV 按鈕=========
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
                case "ToolStripMenuItem_FinishFee"://主管簽核 請款

                    int iFeeKEY = (int)dgViewMF.CurrentRow.Cells["FeeKEY"].Value;
                    Public.CTrademarkFee TrademarkFee = new Public.CTrademarkFee();
                    Public.CTrademarkFee.ReadOne(iFeeKEY, ref TrademarkFee);


                    if (TrademarkFee.IsClosing.HasValue && TrademarkFee.IsClosing.Value)//判斷是否關帳
                        {
                            MessageBox.Show("該筆請款單號【" + TrademarkFee.PPP + "】已被關帳，請洽帳務主管", "提示訊息", MessageBoxButtons.OK);
                            return;
                        }

                    if (TrademarkFee.PPP != null && TrademarkFee.PPP != "")//判斷是否已登入請款單號
                        {
                            MessageBox.Show("已登錄了請款單號【" + TrademarkFee.PPP + "】，若要修改，請洽帳務人員", "提示訊息", MessageBoxButtons.OK);
                            return;
                        }

                        //判斷是否有人使用中
                    int iLocker = Public.Utility.GetRecordAuth("TrademarkFeeT", "FeeKEY=" + dgViewMF.CurrentRow.Cells["FeeKEY"].Value.ToString());
                        if (iLocker == -1 || iLocker == iWorkerID)
                        {
                            if (iLocker != iWorkerID)
                            {
                                Public.Utility.LockRecordAuth("TrademarkFeeT", iWorkerID, "FeeKEY=" + dgViewMF.CurrentRow.Cells["FeeKEY"].Value.ToString());
                            }

                            EditForm.EditTrademarkFee edit = new LawtechPTSystemByFirm.EditForm.EditTrademarkFee();
                            edit.property_FeeKEY = (int)dgViewMF.CurrentRow.Cells["FeeKEY"].Value;
                            edit.CountrySymbol = dgViewMF.CurrentRow.Cells["CountrySymbol"].Value.ToString();
                            edit.ShowDialog();

                            Public.Utility.NuLockRecordAuth("TrademarkFeeT", "FeeKEY=" + dgViewMF.CurrentRow.Cells["FeeKEY"].Value.ToString());
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
                    
                    break;
                case "toolStripMenuItem_RejectionFee"://退請款
                    if (dgViewMF.CurrentRow!=null)
                    {
                        int iFeeKey = (int)dgViewMF.CurrentRow.Cells["FeeKEY"].Value;
                        Public.CTrademarkFee TrademarkFee1 = new LawtechPTSystemByFirm.Public.CTrademarkFee();
                        Public.CTrademarkFee.ReadOne(iFeeKey, ref TrademarkFee1);


                        if (TrademarkFee1.IsClosing.HasValue && TrademarkFee1.IsClosing.Value)//判斷是否關帳
                        {
                            MessageBox.Show("該筆請款單號【" + TrademarkFee1.PPP + "】已被關帳，請洽帳務主管", "提示訊息", MessageBoxButtons.OK);
                            return;
                        }

                        if (TrademarkFee1.PPP != null && TrademarkFee1.PPP != "")//判斷是否已登入請款單號
                        {
                            MessageBox.Show("已登錄了請款單號【" + TrademarkFee1.PPP + "】，若要修改，請洽帳務人員", "提示訊息", MessageBoxButtons.OK);
                            return;
                        }

                        //判斷是否有人使用中
                        int iLocker1 = Public.Utility.GetRecordAuth("TrademarkFeeT", "FeeKEY=" + dgViewMF.CurrentRow.Cells["FeeKEY"].Value.ToString());
                        if (iLocker1 == -1 || iLocker1 == iWorkerID)
                        {
                            if (iLocker1 != iWorkerID)
                            {
                                Public.Utility.LockRecordAuth("TrademarkFeeT", iWorkerID, "FeeKEY=" + dgViewMF.CurrentRow.Cells["FeeKEY"].Value.ToString());
                            }
                                                       
                            string str = "✖退請款(" + Properties.Settings.Default.WorkerName + " " + DateTime.Now.ToString("yyyy/MM/dd HH:mm") + ")";
                            TrademarkFee1.SingCodeStatus = str;

                            TrademarkFee1.LastModifyWorker = Properties.Settings.Default.WorkerName;
                            TrademarkFee1.Update();

                            dgViewMF.CurrentRow.Cells["SingCodeStatus"].Value = str;

                            Public.Utility.NuLockRecordAuth("TrademarkFeeT", "FeeKey=" + dgViewMF.CurrentRow.Cells["FeeKEY"].Value.ToString());
                        }
                        else
                        {
                            if (iLocker1 != -1)
                            {
                                Worker_Model worker = new Worker_Model();
                                Worker_Model.ReadOne(iLocker1, ref  worker);

                                MessageBox.Show("很抱歉~~   目前該筆資料正被【" + worker.EmployeeName + "】使用中，請等候!!\r\n 謝謝", "提示訊息");
                            }
                        }
                    }
                    break;
                case "toolStripMenuItem_ReBackFee"://重新送請款
                    if (dgViewMF.CurrentRow!=null)
                    {
                        int iFeeKEY2 = (int)dgViewMF.CurrentRow.Cells["FeeKEY"].Value;
                        Public.CTrademarkFee TrademarFee2 = new LawtechPTSystemByFirm.Public.CTrademarkFee();
                        Public.CTrademarkFee.ReadOne(iFeeKEY2, ref TrademarFee2);

                        if (TrademarFee2.IsClosing.HasValue && TrademarFee2.IsClosing.Value)//判斷是否關帳
                        {
                            MessageBox.Show("該筆請款單號【" + TrademarFee2.PPP + "】已被關帳，請洽帳務主管", "提示訊息", MessageBoxButtons.OK);
                            return;
                        }

                        if (TrademarFee2.PPP != "")//判斷是否已登入請款單號
                        {
                            MessageBox.Show("已登錄了請款單號【" + TrademarFee2.PPP + "】，若要修改，請洽帳務人員", "提示訊息", MessageBoxButtons.OK);
                            return;
                        }

                        //判斷是否有人使用中
                        int iLocker2 = Public.Utility.GetRecordAuth("TrademarkFeeT", "FeeKEY=" + dgViewMF.CurrentRow.Cells["FeeKEY"].Value.ToString());
                        if (iLocker2 == -1 || iLocker2 == iWorkerID)
                        {
                            if (iLocker2 != iWorkerID)
                            {
                                Public.Utility.LockRecordAuth("TrademarkFeeT", iWorkerID, "FeeKEY=" + dgViewMF.CurrentRow.Cells["FeeKEY"].Value.ToString());
                            }

                           
                            string str = "☆重送請款簽核(" + Properties.Settings.Default.WorkerName + " " + DateTime.Now.ToString("yyyy/MM/dd HH:mm") + ")";
                            TrademarFee2.SingCodeStatus = str;
                            TrademarFee2.LastModifyWorker = Properties.Settings.Default.WorkerName;
                            TrademarFee2.Update();

                            dgViewMF.CurrentRow.Cells["SingCodeStatus"].Value = str;

                            Public.Utility.NuLockRecordAuth("TrademarkFeeT", "FeeKEY=" + dgViewMF.CurrentRow.Cells["FeeKEY"].Value.ToString());
                        }
                        else
                        {
                            if (iLocker2 != -1)
                            {
                                Worker_Model worker = new Worker_Model();
                                Worker_Model.ReadOne(iLocker2, ref  worker);

                                MessageBox.Show("很抱歉~~   目前該筆資料正被【" + worker.EmployeeName + "】使用中，請等候!!\r\n 謝謝", "提示訊息");
                            }
                        }
                    }
                    break; 
                case "ToolStripMenuItem_SendMail":
                    if (dgViewMF.CurrentRow != null)
                    {
                        US.NotificationLetter letter = new LawtechPTSystemByFirm.US.NotificationLetter();
                        letter.ApplicantKeys = dgViewMF.CurrentRow.Cells["ApplicantKeys"].Value.ToString();
                        letter.CaseKey = dgViewMF.CurrentRow.Cells["FeeKEY"].Value != null ? (int)dgViewMF.CurrentRow.Cells["FeeKEY"].Value : -1;

                        letter.EmailSampleType = "TrademarkFee";
                        letter.DelegateType = dgViewMF.CurrentRow.Cells["DelegateType"].Value != null ? (int)dgViewMF.CurrentRow.Cells["DelegateType"].Value : -1;
                        letter.Attorney = dgViewMF.CurrentRow.Cells["AttorneyKey"].Value != DBNull.Value ? (int)dgViewMF.CurrentRow.Cells["AttorneyKey"].Value : -1;
                        letter.CaseNo = dgViewMF.CurrentRow.Cells["TrademarkNo"].Value.ToString();
                        letter.Show();
                    }
                    break;
                case "toolStripMenuItem_SetGridColumn":
                    SetGridColumnT gc = new SetGridColumnT();
                    gc.CurrentGridSymboID = dgViewMF.Tag.ToString();
                    gc.Show();
               break;
            }
        }

        private void dgViewMF_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = false;
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

        #region =============相關文件=============
        private void toolStripLabel_UpdateFileList_Click(object sender, EventArgs e)
        {
            if (dgViewMF.CurrentRow != null)
            {
                ViewUpdateFileList subForm = new ViewUpdateFileList();
                subForm.Text = dgViewMF.CurrentRow.Cells["TrademarkNo"].Value.ToString() + "的申請案相關文件";
                subForm.FileKind = 4;
                subForm.FileType = 8;
                subForm.MainParentID = (int)dgViewMF.CurrentRow.Cells["TrademarkID"].Value;
                subForm.Show();               
            }
        }
        #endregion

        #region ============contextMenuMain_Opening============
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void contextMenuMain_Opening(object sender, CancelEventArgs e)
        {
            if (dgViewMF.CurrentRow != null)
            {
              
               
                this.ToolStripMenuItem_FinishFee.Visible = false;
               
                this.toolStripMenuItem_RejectionFee.Visible = false;
                this.toolStripMenuItem_ReBackFee.Visible = false;


                if (dgViewMF.CurrentRow.Cells["PayDate"].Value.GetType().ToString() != "System.DBNull")
                {
                    //this.toolStripMenuItem_NotFinish.Visible = true;
                }
                else
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
            TrademarkHistoryRecord HistoryRecord = new TrademarkHistoryRecord();
            HistoryRecord.TrademarkID = (int)dgViewMF.CurrentRow.Cells["TrademarkID"].Value;

            HistoryRecord.TabSelectedIndex = 3;

            HistoryRecord.Show();
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
                ViewFrom.TrademarkCompleteHistory history = new LawtechPTSystemByFirm.ViewFrom.TrademarkCompleteHistory();
                history.Gv = dgViewMF;
                history.Show();
            }
        }
        #endregion

        private void dgViewMF_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != -1 && e.RowIndex != -1)
            {
                toolStripLabel_PatentView_Click(null, null);
            }
        }
                   
    }
}
