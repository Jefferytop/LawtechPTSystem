
using System;
using System.ComponentModel;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LawtechPTSystem.SubFrom
{
    /// <summary>
    /// 專利請款管制表
    /// </summary>
    public partial class PATControlFeeList : Form
    {
        private object m_objOpt = System.Reflection.Missing.Value;
       
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
        private DataTable dt_ControlFee = new DataTable();
        /// <summary>
        /// 請款管制清單資料表
        /// </summary>
        public System.Data.DataTable DT_ControlFee
        {
            get
            {
                return dt_ControlFee;
            }
        }


        /// <summary>
        /// 當前事件管制清單資料 DataRow
        /// </summary>
        public System.Data.DataRow dt_CurrentControlFeeDataRow
        {
            get
            {
                DataRow dr = dt_ControlFee.Rows.Find((int)dgViewMF.CurrentRow.Cells["FeeKey"].Value);
                return dr;
            }
        }
        #endregion

        UserPermissionForm myPermission;
        private const string ProgramSymbol = "PATControlFeeList";
        private const string SourceTableName = "V_PATControlFeeList";

        public PATControlFeeList()
        {
            InitializeComponent();
            dgViewMF.AutoGenerateColumns = false;          
            Public.DynamicGridViewColumn.GetGridColum(ref dgViewMF);            
        }
        
        #region PATControlEvent_Load 、 PATControlEvent_FormClosed
        private void PATControlEvent_Load(object sender, EventArgs e)
        {           
            
            Public.PublicForm Forms = new Public.PublicForm();
            Forms.PATControlFeeList = this;
          
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

            SetBindingSource();    

            Public.DLL dll = new Public.DLL();

            PatentControlPeriodTime = dll.GetPatentControlPeriodTime;

            Public.Utility.SetLoadDataRange(userControlFilterDate1);

            if (Properties.Settings.Default.IsLoadData)
            {
                butQuery_Click(null, null);
            }
        }

        private void PATControlEvent_FormClosed(object sender, FormClosedEventArgs e)
        {
            Public.PublicForm Forms = new Public.PublicForm();
            Forms.PATControlFeeList = null;
        }
        #endregion

        private void ChkSelected(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;
            if (rb.Checked)
            {
                rb.BackgroundImage = global::LawtechPTSystem.Properties.Resources.btn_27;
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

                Radio.BackgroundImage = global::LawtechPTSystem.Properties.Resources.btnGeen;
                
                butQuery_Click(null, null);
            }
            else
            {
                Radio.BackgroundImage = null;
            }
        }

        #region =========查詢 按鈕=========
        /// <summary>
        /// 查詢 按鈕
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butQuery_Click(object sender, EventArgs e)
        {
            butQuery.Enabled = false;

            string strFilter = "";
            if (chb_Finish.Checked) //已完成
            {
                strFilter += " PayDate is not null or (IsClosing=1) ";
            }
            else if (chb_NoFinish.Checked)//未完成
            {
                strFilter += " PayDate is null and (IsClosing<>1) ";
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

           
            Public.CPatentPublicFunction.GetPATControlFeeList(strSqlwhere, ref dt_ControlFee);           
                      
            butQuery.Enabled = true;
        }
        #endregion

        #region 設定BindingSource的來源 private void SetBindingSource()
        /// <summary>
        /// 設定BindingSource的來源
        /// </summary>
        private void SetBindingSource()
        {
            Public.CPatentPublicFunction.GetPATControlFeeList("1=0", ref dt_ControlFee);
            bindingSource_Fee.DataSource = dt_ControlFee;
        }
        #endregion

        #region 關閉按鈕 private void butClose_Click(object sender, EventArgs e)
        /// <summary>
        /// 關閉按鈕
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butClose_Click(object sender, EventArgs e)
        {
            this.Close();
        } 
        #endregion

        #region =========匯出Excel 按鈕=========
        private void butExport_Click(object sender, EventArgs e)
        {

            try
            {
                Public.DLL dll = new Public.DLL();
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
                  
                        int iFeeKEY = (int)dgViewMF.CurrentRow.Cells["EventID"].Value;
                        Public.CPatentFee patentFee = new Public.CPatentFee();
                        Public.CPatentFee.ReadOne(iFeeKEY, ref patentFee);


                        if (patentFee.IsClosing.HasValue && patentFee.IsClosing.Value)//判斷是否關帳
                        {
                            MessageBox.Show("該筆請款單號【" + patentFee.PPP + "】已被關帳，請洽帳務主管", "提示訊息", MessageBoxButtons.OK);
                            return;
                        }

                        if (patentFee.PPP != null && patentFee.PPP != "")//判斷是否已登入請款單號
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

                            EditForm.EditPatentFee edit = new LawtechPTSystem.EditForm.EditPatentFee();
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
                    
                    break;
                case "toolStripMenuItem_RejectionFee"://退請款
                    if (dgViewMF.CurrentRow!=null)
                    {
                        int iFeeKey = (int)dgViewMF.CurrentRow.Cells["EventID"].Value;
                        Public.CPatentFee patentFee1 = new Public.CPatentFee();
                        Public.CPatentFee.ReadOne(iFeeKey, ref patentFee1);


                        if (patentFee1.IsClosing.HasValue && patentFee1.IsClosing.Value)//判斷是否關帳
                        {
                            MessageBox.Show("該筆請款單號【" + patentFee1.PPP + "】已被關帳，請洽帳務主管", "提示訊息", MessageBoxButtons.OK);
                            return;
                        }

                        if (patentFee1.PPP!=null && patentFee1.PPP != "")//判斷是否已登入請款單號
                        {
                            MessageBox.Show("已登錄了請款單號【" + patentFee1.PPP + "】，若要修改，請洽帳務人員", "提示訊息", MessageBoxButtons.OK);
                            return;
                        }

                        //判斷是否有人使用中
                        int iLocker1 = Public.Utility.GetRecordAuth("PatentFeeT", "FeeKEY=" + dgViewMF.CurrentRow.Cells["EventID"].Value.ToString());
                        if (iLocker1 == -1 || iLocker1 == iWorkerID)
                        {
                            if (iLocker1 != iWorkerID)
                            {
                                Public.Utility.LockRecordAuth("PatentFeeT", iWorkerID, "FeeKEY=" + dgViewMF.CurrentRow.Cells["EventID"].Value.ToString());
                            }
                                                       
                            string str = "✖退請款(" + Properties.Settings.Default.WorkerName + " " + DateTime.Now.ToString("yyyy/MM/dd HH:mm") + ")";
                            patentFee1.SingCodeStatus = str;

                            patentFee1.LastModifyWorker = Properties.Settings.Default.WorkerName;
                            patentFee1.Update();

                            dgViewMF.CurrentRow.Cells["SingCodeStatus"].Value = str;

                            Public.Utility.NuLockRecordAuth("PatentFeeT", "FeeKey=" + dgViewMF.CurrentRow.Cells["EventID"].Value.ToString());
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
                        int iFeeKEY2 = (int)dgViewMF.CurrentRow.Cells["EventID"].Value;
                        Public.CPatentFee patentFee2 = new Public.CPatentFee();
                        Public.CPatentFee.ReadOne(iFeeKEY2, ref patentFee2);

                        if (patentFee2.IsClosing.HasValue && patentFee2.IsClosing.Value)//判斷是否關帳
                        {
                            MessageBox.Show("該筆請款單號【" + patentFee2.PPP + "】已被關帳，請洽帳務主管", "提示訊息", MessageBoxButtons.OK);
                            return;
                        }

                        if (patentFee2.PPP != "")//判斷是否已登入請款單號
                        {
                            MessageBox.Show("已登錄了請款單號【" + patentFee2.PPP + "】，若要修改，請洽帳務人員", "提示訊息", MessageBoxButtons.OK);
                            return;
                        }

                        //判斷是否有人使用中
                        int iLocker2 = Public.Utility.GetRecordAuth("PatentFeeT", "FeeKEY=" + dgViewMF.CurrentRow.Cells["EventID"].Value.ToString());
                        if (iLocker2 == -1 || iLocker2 == iWorkerID)
                        {
                            if (iLocker2 != iWorkerID)
                            {
                                Public.Utility.LockRecordAuth("PatentFeeT", iWorkerID, "FeeKEY=" + dgViewMF.CurrentRow.Cells["EventID"].Value.ToString());
                            }

                           
                            string str = "☆重送請款簽核(" + Properties.Settings.Default.WorkerName + " " + DateTime.Now.ToString("yyyy/MM/dd HH:mm") + ")";
                            patentFee2.SingCodeStatus = str;                            
                            patentFee2.LastModifyWorker = Properties.Settings.Default.WorkerName;
                            patentFee2.Update();

                            dgViewMF.CurrentRow.Cells["SingCodeStatus"].Value = str;

                            Public.Utility.NuLockRecordAuth("PatentFeeT", "FeeKEY=" + dgViewMF.CurrentRow.Cells["EventID"].Value.ToString());
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
                        US.NotificationLetter letter = new LawtechPTSystem.US.NotificationLetter();
                        letter.ApplicantKeys = dgViewMF.CurrentRow.Cells["ApplicantKeys"].Value.ToString();
                        letter.CaseKey = dgViewMF.CurrentRow.Cells["EventID"].Value != null ? (int)dgViewMF.CurrentRow.Cells["EventID"].Value : -1;

                        letter.EmailSampleType = "PatentFee";
                        letter.DelegateType = dgViewMF.CurrentRow.Cells["DelegateType"].Value != null ? (int)dgViewMF.CurrentRow.Cells["DelegateType"].Value : -1;
                        letter.Attorney = dgViewMF.CurrentRow.Cells["AttorneyKey"].Value != DBNull.Value ? (int)dgViewMF.CurrentRow.Cells["AttorneyKey"].Value : -1;
                        letter.CaseNo = dgViewMF.CurrentRow.Cells["PatentNo"].Value.ToString();
                        letter.Show();
                    }
                    break;

                case "toolStripMenuItem_SetGridColumn":
                    SetGridColumnT gc = new SetGridColumnT();
                    gc.CurrentGridSymboID = dgViewMF.Tag.ToString();
                    gc.TitleName = "專利案件-請款記錄列表";
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
                Public.DLL dll = new Public.DLL();
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
         
                PatentHistoryRecord1 patent = new PatentHistoryRecord1();
                patent.property_PatentID = (int)dgViewMF.CurrentRow.Cells["PatentID"].Value;

                patent.TabSelectedIndex = 2;

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
                ViewFrom.PatentCompleteHistory history = new LawtechPTSystem.ViewFrom.PatentCompleteHistory();
                history.Gv = dgViewMF;
                history.Show();
            }
        }
        #endregion

        #region private void dgViewMF_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgViewMF_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != -1 && e.RowIndex != -1)
            {
                toolStripLabel_PatentView_Click(null, null);
            }
        } 
        #endregion
                   
    }
}
