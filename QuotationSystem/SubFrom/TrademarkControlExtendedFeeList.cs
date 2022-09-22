using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LawtechPTSystem.SubFrom
{
    /// <summary>
    /// 商標-延展管制表
    /// </summary>
    public partial class TrademarkControlExtendedFeeList : Form
    {
        private object m_objOpt = System.Reflection.Missing.Value;

        BindingSource bSource_Control;

        UserPermissionForm myPermission;
        private const string ProgramSymbol = "TrademarkControlExtendedFeeList";
        private const string SourceTableName = "V_TrademarkList";

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

        private decimal decTrademarkControlPeriodTime = 0;
        /// <summary>
        /// 商棟管制的時間
        /// </summary>
        public decimal TrademarkControlPeriodTime
        {
            get { return decTrademarkControlPeriodTime; }
            set { decTrademarkControlPeriodTime = value; }
        }

        /// <summary>
        /// 目前的 DataGridViewRow CurrentRow
        /// </summary>
        public DataGridViewRow GV_CurrentRow
        {
            get { return dgViewMF.CurrentRow; }
        }

        #endregion 

        public TrademarkControlExtendedFeeList()
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
            Forms.TrademarkControlExtendedFeeList = this;            

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

            TrademarkControlPeriodTime = dll.GetTrademarkControlPeriodTime;

            Public.Utility.SetLoadDataRange(userControlFilterDate1);

            if (Properties.Settings.Default.IsLoadData)
            {
                butQuery_Click(null, null);
            }
        }

        private void PATControlEvent_FormClosed(object sender, FormClosedEventArgs e)
        {
            Public.PublicForm Forms = new Public.PublicForm();
            Forms.TrademarkControlExtendedFeeList = null;
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
                strFilter = " and  LawDate>dateAdd(MM," + this.TrademarkControlPeriodTime.ToString("###0.#") + ",getDate()) ";
            }
            else if (chb_NoFinish.Checked)//未完成
            {
                strFilter = " and LawDate < dateAdd(MM," + this.TrademarkControlPeriodTime.ToString("###0.#") + ",getDate()) ";
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

        #region GetPatentFeeEvent 取得待繳商標延展費的資料
        /// <summary>
        /// 取得待繳商標延展費的資料
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public System.Data.DataTable GetPatentFeeEvent(string strWhere)
        {
            
            string strPatentFeeEventSQL = string.Format(
  @"declare @TrademarkControlPeriodTime int
set @TrademarkControlPeriodTime=-{1}
select DATEADD(MM, @TrademarkControlPeriodTime, LawDate) AS OccurDate,
'目前繳至 ' + CAST(convert(nvarchar(30), LawDate ,111) AS Nvarchar(10)) + ' --待繳下年度延展費用' AS EventContent ,
 DateAdd(month,@TrademarkControlPeriodTime,LawDate) as OfficeDueDate,
Case when (DateAdd(month,@TrademarkControlPeriodTime,LawDate)>getdate()) then LawDate else null end as FinishDate, 
CASE WHEN (DateAdd(month,@TrademarkControlPeriodTime,LawDate)<getdate()) THEN DATEDIFF(day, GETDATE(), LawDate )  
 WHEN (DateAdd(month,@TrademarkControlPeriodTime,LawDate)>getdate()) THEN NULL END AS DiffDueDate,
 LawDate as DueDate,
* from  V_TrademarkList where  (CloseDate IS NULL)  {0}", strWhere, this.TrademarkControlPeriodTime.ToString("###0.#"));

            Public.DLL dll = new Public.DLL();
            System.Data.DataTable dtstrPatentFeeEvent = new System.Data.DataTable();
            dll.FetchDataTable(strPatentFeeEventSQL, dtstrPatentFeeEvent);
            return dtstrPatentFeeEvent;
        }
        #endregion

        #region  private void butClose_Click(object sender, EventArgs e)
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
                case "ToolStripMenuItem_ExtendedFinish":
                    if (dgViewMF.CurrentRow!=null)
                    {
                        US.TrademarkExtendFinish ExtendFinish = new LawtechPTSystem.US.TrademarkExtendFinish();
                        ExtendFinish.TrademarkKey = (int)dgViewMF.CurrentRow.Cells["TrademarkID"].Value;
                        ExtendFinish.DGvr = dgViewMF.CurrentRow;
                        ExtendFinish.ShowDialog();
                    }
                    break;
             
                case "toolStripMenuItem_SetPatentFee":
                       US.TrademarkControlPeriod controlperiod = new LawtechPTSystem.US.TrademarkControlPeriod();
                    if (controlperiod.ShowDialog() == DialogResult.OK)
                    {
                       TrademarkControlPeriodTime = controlperiod.Trademarkcontrol;
                    }
                   
                    break;               
                case "ToolStripMenuItem_SendMail":
                    if (dgViewMF.CurrentRow != null)
                    {
                        US.NotificationLetter letter = new US.NotificationLetter();
                        letter.ApplicantKeys = dgViewMF.CurrentRow.Cells["ApplicantKeys"].Value.ToString();
                        letter.CaseKey = dgViewMF.CurrentRow.Cells["TrademarkID"].Value != null ? (int)dgViewMF.CurrentRow.Cells["TrademarkID"].Value : -1;
                        letter.EmailSampleType = "Trademark";
                        letter.DelegateType = dgViewMF.CurrentRow.Cells["DelegateType"].Value != null ? (int)dgViewMF.CurrentRow.Cells["DelegateType"].Value : -1;
                        letter.Attorney =  -1;
                        letter.CaseNo = dgViewMF.CurrentRow.Cells["TrademarkNo"].Value.ToString();
                        letter.Show();
                    }
                    break;
                case "toolStripMenuItem_SetGridColumn":
                    SetGridColumnT gc = new SetGridColumnT();
                    gc.CurrentGridSymboID = dgViewMF.Tag.ToString();
                    gc.TitleName = "商標-延展管制列表";
                    gc.Show();
                    break;
                case "ToolStripMenuItem_AddEvent":
                    if (dgViewMF.CurrentRow != null)
                    {
                        AddFrom.AddTrademarkNotifyEvent add = new AddFrom.AddTrademarkNotifyEvent();
                        add.TrademarkID = (int)dgViewMF.CurrentRow.Cells["TrademarkID"].Value;
                        if (dgViewMF.CurrentRow.Cells["CountrySymbol"].Value != null)
                        {
                            add.CountrySymbol = dgViewMF.CurrentRow.Cells["CountrySymbol"].Value.ToString();
                        }
                        add.ShowDialog();
                    }
                    break;
                case "toolStripMenuItem_AddFee":
                    if (dgViewMF.CurrentRow != null)
                    {
                        AddFrom.AddTrademarkFee fee = new AddFrom.AddTrademarkFee();
                        fee.TrademarkID = (int)dgViewMF.CurrentRow.Cells["TrademarkID"].Value;
                        fee.Text = fee.Text + "--" + dgViewMF.CurrentRow.Cells["TrademarkNo"].Value.ToString();
                        fee.CountrySymbol = dgViewMF.CurrentRow.Cells["CountrySymbol"].Value.ToString();
                        fee.ShowDialog();
                    }
                    break;
                case "toolStripMenuItem_AddPayment":
                    if (dgViewMF.CurrentRow != null)
                    {
                        AddFrom.AddTrademarkPayment Payment = new AddFrom.AddTrademarkPayment();
                        Payment.TrademarkID = (int)dgViewMF.CurrentRow.Cells["TrademarkID"].Value;
                        Payment.CountrySymbol = dgViewMF.CurrentRow.Cells["CountrySymbol"].Value.ToString();
                        Payment.Text = Payment.Text + "--" + dgViewMF.CurrentRow.Cells["TrademarkNo"].Value.ToString();
                        Payment.ShowDialog();
                    }
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
                subForm.Text = dgViewMF.CurrentRow.Cells["TrademarkNo"].Value.ToString() + "的申請案相關文件";
                subForm.FileKind = 4;
                subForm.FileType = 6;
                subForm.MainParentID = (int)dgViewMF.CurrentRow.Cells["TrademarkID"].Value;
                subForm.ShowDialog();
            }
        }
        #endregion
             
        #region toolStripLabel_PatentView_Click
        private void toolStripLabel_PatentView_Click(object sender, EventArgs e)
        {
            TrademarkHistoryRecord HistoryRecord = new TrademarkHistoryRecord();
            HistoryRecord.TrademarkID = (int)dgViewMF.CurrentRow.Cells["TrademarkID"].Value;
            HistoryRecord.TabSelectedIndex = 1;
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
                ViewFrom.TrademarkCompleteHistory history = new LawtechPTSystem.ViewFrom.TrademarkCompleteHistory();
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
