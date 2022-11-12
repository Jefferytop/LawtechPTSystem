using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LawtechPTSystem.SubFrom
{
    /// <summary>
    /// 專利-待繳年費管制表
    /// </summary>
    public partial class PATControlYearFeeList : Form
    {
        private object m_objOpt = System.Reflection.Missing.Value;

        BindingSource bSource_Control;

        UserPermissionForm myPermission;
        private const string ProgramSymbol = "PATControlYearFeeList";
        private const string SourceTableName = "V_PATControlEventList";

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

        public PATControlYearFeeList()
        {
            InitializeComponent();
            dgViewMF.AutoGenerateColumns = false;          
            Public.DynamicGridViewColumn.GetGridColum(ref dgViewMF);            
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
            
            Public.PublicForm Forms = new Public.PublicForm();
            Forms.PATControlYearFeeList = this;            

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
            Forms.PATControlYearFeeList = null;
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
        private void butQuery_Click(object sender, EventArgs e)
        {
            butQuery.Enabled = false;

            string strFilter = "";
            if (chb_Finish.Checked) //已完成
            {
                strFilter = " and  RenewTo>dateAdd(MM," + this.PatentControlPeriodTime.ToString("###0.#") + ",getDate()) ";
            }
            else if (chb_NoFinish.Checked)//未完成
            {
                strFilter = " and RenewTo < dateAdd(MM," + this.PatentControlPeriodTime.ToString("###0.#") + ",getDate()) ";
            }

            string FullWhere = Public.CommonFunctions.GetSQLScript(QueryFilter1, QueryFilter2, rb_and.Checked ? " and " : " or ", userControlFilterDate1);

            string strSqlwhere = "";
            if (!string.IsNullOrEmpty(strFilter.Trim()) && string.IsNullOrEmpty(FullWhere.Trim()))
            {
                strSqlwhere = strFilter;
            }
            else if (string.IsNullOrEmpty(strFilter.Trim()) && !string.IsNullOrEmpty(FullWhere.Trim()))
            {
                strSqlwhere = " and "+FullWhere;
            }
            else if (!string.IsNullOrEmpty(strFilter.Trim()) && !string.IsNullOrEmpty(FullWhere.Trim()))
            {
                strSqlwhere = strFilter + " and " + FullWhere;
            }
            
            System.Data.DataTable dt_ComitEvent = GetPatentFeeEvent(strSqlwhere);

            bSource_Control.DataSource = dt_ComitEvent;

            butQuery.Enabled = true;
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
            
            string strPatentFeeEventSQL = string.Format(
                                    @"declare @PatentControlPeriodTime int
set @PatentControlPeriodTime={1}
select DATEADD(MM, - @PatentControlPeriodTime, RenewTo) AS OccurDate,
'目前繳至 ' + CAST(PayYear AS Nvarchar(10)) + ' 年--待繳下年度專利費用' AS EventContent ,
CASE WHEN GetDate() > dateAdd(MM, -@PatentControlPeriodTime, RenewTo) THEN dateAdd(MM, -@PatentControlPeriodTime, RenewTo) ELSE NULL END AS OfficeDueDate,
CASE WHEN RenewTo > dateAdd(MM, @PatentControlPeriodTime, getDate()) THEN RenewTo ELSE NULL END AS FinishDate, 
CASE WHEN CloseDate IS NULL THEN DATEDIFF(day, GETDATE(), ISNULL(RenewTo, GETDATE()))  WHEN CloseDate IS NOT NULL THEN NULL END AS DiffDueDate, 
* from  V_PatentList
where  (CloseDate IS NULL) AND (RenewTo IS NOT NULL)
                                            {0}", strWhere, this.PatentControlPeriodTime.ToString("###0.#"));

            Public.DLL dll = new Public.DLL();
            System.Data.DataTable dtstrPatentFeeEvent = new System.Data.DataTable();
            dll.FetchDataTable(strPatentFeeEventSQL, dtstrPatentFeeEvent);
            return dtstrPatentFeeEvent;
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
                case "toolStripMenuItem_AddEvent":
                    AddFrom.AddPatentComitEvent comit = new AddFrom.AddPatentComitEvent();
                    comit.Text += "(" + dgViewMF.CurrentRow.Cells["PatentNo"].Value.ToString() + "  " + dgViewMF.CurrentRow.Cells["CountryName"].Value.ToString() + ")";
                    comit.CountrySymbol = dgViewMF.CurrentRow.Cells["CountrySymbol"].Value.ToString();
                    comit.PatentID = (int)dgViewMF.CurrentRow.Cells["PatentID"].Value;
                    comit.ShowDialog();
                    break;
                case "toolStripMenuItem_PatentAnnualtoFee":
                    if (dgViewMF.CurrentRow != null)
                    {
                        AddFrom.AddPatentFee fee = new AddFrom.AddPatentFee();
                        fee.PatentID = (int)dgViewMF.CurrentRow.Cells["PatentID"].Value;
                        fee.CountrySymbol = dgViewMF.CurrentRow.Cells["CountrySymbol"].Value.ToString();
                        fee.Text = fee.Text + " (" + dgViewMF.CurrentRow.Cells["PatentNo"].Value.ToString() + ")";
                        fee.ShowDialog();
                    }
                    break;

                case "toolStripMenuItem_PatentAnnualtoPayment":
                    if (dgViewMF.CurrentRow != null)
                    {
                        AddFrom.AddPatentPayment Payment = new AddFrom.AddPatentPayment();
                        Payment.CountrySymbol = dgViewMF.CurrentRow.Cells["CountrySymbol"].Value.ToString();
                        Payment.PatentID = (int)dgViewMF.CurrentRow.Cells["PatentID"].Value;
                        Payment.Text = Payment.Text + "(" + dgViewMF.CurrentRow.Cells["PatentNo"].Value.ToString() + "  " + dgViewMF.CurrentRow.Cells["CountryName"].Value.ToString() + ")";
                        Payment.ShowDialog();
                    }
                    break;
                case "ToolStripMenuItem_PaymentComplete"://年費繳費完成
                    if (dgViewMF.CurrentRow != null)
                    {
                        US.PatentPaymentComplete pat = new US.PatentPaymentComplete();
                        pat.PatentID = (int)dgViewMF.CurrentRow.Cells["PatentID"].Value;
                        pat.Text = dgViewMF.CurrentRow.Cells["PatentNo"].Value.ToString() + " " + pat.Text;
                        if (pat.ShowDialog() == DialogResult.OK)
                        {
                            dgViewMF.CurrentRow.Cells["FinishDate"].Value = pat.RenewTo;
                            dgViewMF.CurrentRow.Cells["DiffDueDate"].Value = 0;
                            //dgViewMF.CurrentRow.Cells["Result"].Value = "";
                            dt_ControlEvent.AcceptChanges();
                        }
                    }
                    break;
                case "ToolStripMenuItem_ClosePatent"://結案,年費不續繳
                    if (dgViewMF.CurrentRow != null)
                    {
                        US.PatentClose patClose = new US.PatentClose();
                        patClose.PatentID = (int)dgViewMF.CurrentRow.Cells["PatentID"].Value;
                        patClose.Text = dgViewMF.CurrentRow.Cells["PatentNo"].Value.ToString() + " " + patClose.Text;
                        if (patClose.ShowDialog() == DialogResult.OK)
                        {
                            dgViewMF.Rows.Remove(dgViewMF.CurrentRow);
                            dt_ControlEvent.AcceptChanges();
                        }
                    }
                    break;
                case "toolStripMenuItem_SetPatentFee":
                    US.PatentControlPeriod controlperiod = new LawtechPTSystem.US.PatentControlPeriod();
                    if (controlperiod.ShowDialog() == DialogResult.OK)
                    {
                        PatentControlPeriodTime = controlperiod.patentcontrol;
                    }
                    break;               
                case "ToolStripMenuItem_SendMail":
                    if (dgViewMF.CurrentRow != null)
                    {
                        US.NotificationLetter letter = new LawtechPTSystem.US.NotificationLetter();
                        letter.ApplicantKeys = dgViewMF.CurrentRow.Cells["ApplicantKeys"].Value.ToString();
                        letter.CaseKey = dgViewMF.CurrentRow.Cells["PatentID"].Value != null ? (int)dgViewMF.CurrentRow.Cells["PatentID"].Value : -1;
                        letter.EmailSampleType = "Patent";
                        letter.DelegateType = dgViewMF.CurrentRow.Cells["DelegateType"].Value != null ? (int)dgViewMF.CurrentRow.Cells["DelegateType"].Value : -1;
                        letter.Attorney =  -1;
                        letter.CaseNo = dgViewMF.CurrentRow.Cells["PatentNo"].Value.ToString();
                        letter.Show();
                    }
                    break;
                case "toolStripMenuItem_SetGridColumn":
                    SetGridColumnT gc = new SetGridColumnT();
                    gc.CurrentGridSymboID = dgViewMF.Tag.ToString();
                    gc.TitleName = "專利-年費管制列表";
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
             
        #region toolStripLabel_PatentView_Click
        private void toolStripLabel_PatentView_Click(object sender, EventArgs e)
        {
            PatentHistoryRecord1 patent = new LawtechPTSystem.SubFrom.PatentHistoryRecord1();
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
                mtb.Text = DateTime.Now.ToString("yyyy-MM-dd");
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

        private void dgViewMF_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != -1 && e.RowIndex != -1)
            {
                toolStripLabel_PatentView_Click(null, null);
            }
        }
                   
    }
}
