using System;
using System.ComponentModel;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LawtechPTSystemByFirm.SubFrom
{
    /// <summary>
    /// 專利付款管制表
    /// </summary>
    public partial class PATControlPayment : Form
    {
        private object m_objOpt = System.Reflection.Missing.Value;

        BindingSource bSource_Control;

        UserPermissionForm myPermission;
        private const string ProgramSymbol = "PATControlPayment";
        private const string SourceTableName = "V_PATControlPayment";

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

        public PATControlPayment()
        {
            InitializeComponent();
            dgViewMF.AutoGenerateColumns = false;          
            Public.DynamicGridViewColumn.GetGridColum(ref dgViewMF);            
        }

        #region =========資料集=========
        private DataTable dt_ControlPayment = new DataTable();
        /// <summary>
        /// 事件管制清單資料表
        /// </summary>
        public System.Data.DataTable DT_ControlPayment
        {
            get
            {
                return dt_ControlPayment;
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
            Forms.PATControlPayment = this;

            

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

            this.workerTAllTableAdapter.Fill(this.qS_DataSet.WorkerTAll);

            this.patSelectDateModeControl_DropTableAdapter.Fill(this.qS_DataSet.PatSelectDateModeControl_Drop);

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
            Forms.PATControlPayment= null;
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
                strFilter += " IReceiptDate is not null ";
            }
            else if (chb_NoFinish.Checked)//未完成
            {
                strFilter += " IReceiptDate is null ";
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
            
            System.Data.DataTable dt_ComitEvent = GetPaymentEvent(strSqlwhere);

            bSource_Control.DataSource = dt_ComitEvent;

            butQuery.Enabled = true;
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
            string strNotifyEventSQL = string.Format(@"SELECT * from V_PATControlPayment with(nolock) {0}", !string.IsNullOrEmpty(strWhere) ? " where " + strWhere : "");

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
            int iFeeKEY = 0;
            Public.CPatentPayment patentFee = new LawtechPTSystemByFirm.Public.CPatentPayment();
            int iLocker = 0;
            int PaymentID = 0;
            switch (e.ClickedItem.Name)
            {
             
                case "ToolStripMenuItem_PaymentFinish"://主管簽核 付款
                    
                        iFeeKEY = (int)dgViewMF.CurrentRow.Cells["EventID"].Value;                      
                        Public.CPatentPayment.ReadOne((int)dgViewMF.CurrentRow.Cells["EventID"].Value, ref patentFee);


                        if (patentFee.IsClosing.HasValue && patentFee.IsClosing.Value)//判斷是否關帳
                        {
                            MessageBox.Show("該筆請款單號【" + patentFee.BillingNo + "】已被關帳，請洽帳務主管", "提示訊息", MessageBoxButtons.OK);
                            return;
                        }

                        if (patentFee.BillingNo!=null && patentFee.BillingNo != "")//判斷是否已登入請款單號
                        {
                            MessageBox.Show("已登錄了請款單號【" + patentFee.BillingNo + "】，若要修改，請洽帳務人員", "提示訊息", MessageBoxButtons.OK);
                            return;
                        }


                        
                        //判斷是否有人使用中
                         iLocker = Public.Utility.GetRecordAuth("PatentPaymentT", "PaymentID=" + dgViewMF.CurrentRow.Cells["EventID"].Value.ToString());
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
                    
                    break;
                case "toolStripMenuItem_RejectionPayment"://退付款
                   
                        iFeeKEY = (int)dgViewMF.CurrentRow.Cells["EventID"].Value;
                      
                        Public.CPatentPayment.ReadOne(iFeeKEY, ref patentFee);

                        if (patentFee.IsClosing.HasValue && patentFee.IsClosing.Value )//判斷是否關帳
                        {
                            MessageBox.Show("該筆請款單號【" + patentFee.BillingNo + "】已被關帳，請洽帳務主管", "提示訊息", MessageBoxButtons.OK);
                            return;
                        }

                        if (patentFee.BillingNo != null && patentFee.BillingNo != "")//判斷是否已登入請款單號
                        {
                            MessageBox.Show("已登錄了請款單號【" + patentFee.BillingNo + "】，若要修改，請洽帳務人員", "提示訊息", MessageBoxButtons.OK);
                            return;
                        }

                         PaymentID=(int)dgViewMF.CurrentRow.Cells["EventID"].Value;

                        //判斷是否有人使用中
                         iLocker = Public.Utility.GetRecordAuth("PatentPaymentT", "PaymentID=" + PaymentID.ToString());
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
                    
                    break;
                case "toolStripMenuItem_ReBackPayment"://重新送付款
                  
                         iFeeKEY = (int)dgViewMF.CurrentRow.Cells["EventID"].Value;
                       
                        Public.CPatentPayment.ReadOne(iFeeKEY, ref patentFee);

                        if (patentFee.IsClosing.HasValue && patentFee.IsClosing.Value)//判斷是否關帳
                        {
                            MessageBox.Show("該筆請款單號【" + patentFee.BillingNo + "】已被關帳，請洽帳務主管", "提示訊息", MessageBoxButtons.OK);
                            return;
                        }

                        if (patentFee.BillingNo != null && patentFee.BillingNo != "")//判斷是否已登入請款單號
                        {
                            MessageBox.Show("已登錄了請款單號【" + patentFee.BillingNo + "】，若要修改，請洽帳務人員", "提示訊息", MessageBoxButtons.OK);
                            return;
                        }

                         PaymentID = (int)dgViewMF.CurrentRow.Cells["EventID"].Value;

                        //判斷是否有人使用中
                         iLocker = Public.Utility.GetRecordAuth("PatentPaymentT", "PaymentID=" + PaymentID.ToString());
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

                    break;
               
                case "ToolStripMenuItem_ConfirmPayment"://由帳務人員處理 確認已完成付款
                    if(dgViewMF.CurrentRow!=null)
                    {

                         iFeeKEY = (int)dgViewMF.CurrentRow.Cells["EventID"].Value;
                       
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
                        letter.EmailSampleType = "PatentPayment";
                        letter.DelegateType = dgViewMF.CurrentRow.Cells["DelegateType"].Value != null ? (int)dgViewMF.CurrentRow.Cells["DelegateType"].Value : -1;
                        letter.Attorney = dgViewMF.CurrentRow.Cells["AttorneyKey"].Value != DBNull.Value ? (int)dgViewMF.CurrentRow.Cells["AttorneyKey"].Value : -1;
                        letter.CaseNo = dgViewMF.CurrentRow.Cells["PatentNo"].Value.ToString();
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

                this.toolStripMenuItem_NotFinish.Visible = false;
                this.ToolStripMenuItem_PaymentFinish.Visible = false;                        
                //ToolStripMenuItem_ConfirmPayment.Visible = false;             

                this.toolStripMenuItem_RejectionPayment.Visible = false;
                this.toolStripMenuItem_ReBackPayment.Visible = false;

                if (dgViewMF.CurrentRow.Cells["IReceiptDate"].Value.GetType().ToString() != "System.DBNull")
                {
                    this.toolStripMenuItem_NotFinish.Visible = true;
                }
                else
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
                    //ToolStripMenuItem_ConfirmPayment.Visible = true;

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
            patent.TabSelectedIndex = 3;          
            patent.Show();
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

        private void dgViewMF_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != -1 && e.RowIndex != -1)
            {
                toolStripLabel_PatentView_Click(null, null);
            }
        }
                   
    }
}
