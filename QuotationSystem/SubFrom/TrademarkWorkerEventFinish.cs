using System;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LawtechPTSystem.SubFrom
{
    public partial class TrademarkWorkerEventFinish : Form
    {

        BindingSource bSource_Control;
        UserPermissionForm myPermission;
        private const string ProgramSymbol = "TrademarkWorkerEventFinish";
        private const string SourceTableName = "V_TrademarkEventList";

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
        #endregion

        public TrademarkWorkerEventFinish()
        {
            InitializeComponent();

            dgViewMF.AutoGenerateColumns = false;

            Public.DynamicGridViewColumn.GetGridColum(ref dgViewMF);
        }

        #region private void TrademarkWorkerEventFinish_Load(object sender, EventArgs e)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TrademarkWorkerEventFinish_Load(object sender, EventArgs e)
        {
            Public.PublicForm Forms = new Public.PublicForm();
            Forms.TrademarkWorkerEventFinish = this;

            //取得登入者身份
            iWorkerID = Properties.Settings.Default.WorkerKEY;
            Worker_Model worker = new Worker_Model();
            Worker_Model.ReadOne(iWorkerID, ref worker);

            iOfficeRole = worker.OfficeRole.Value;
            strWorkerName = worker.EmployeeName;

            this.Text += "--" + strWorkerName;

            //取得權限
            myPermission = new UserPermissionForm(Properties.Settings.Default.WorkerKEY, ProgramSymbol);

            System.Windows.Forms.BindingNavigator[] listbinding = { bindingNavigator1 };
            System.Windows.Forms.ContextMenuStrip[] listtMenu = { contextMenuStrip1 };

            //確認可使用的功能選單
            Public.CommonFunctions.CheckMeunItemVisible(listbinding, myPermission.UserPermission);
            Public.CommonFunctions.CheckMeunItemVisible(listtMenu, myPermission.UserPermission);

            bSource_Control = new BindingSource();
            dgViewMF.DataSource = bSource_Control;
            bindingNavigator1.BindingSource = bSource_Control;

            //帶入所設定的載入資料時間範圍
            Public.Utility.SetLoadDataRange(userControlFilterDate1);

            if (Properties.Settings.Default.IsLoadData)
            {
                butQuery_Click(null, null);
            }
        }
        #endregion

        #region private void TrademarkWorkerEventFinish_FormClosed(object sender, FormClosedEventArgs e)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TrademarkWorkerEventFinish_FormClosed(object sender, FormClosedEventArgs e)
        {
            Public.PublicForm Forms = new Public.PublicForm();
            Forms.TrademarkWorkerEventFinish = null;
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

        #region 查詢按鈕  private void butQuery_Click(object sender, EventArgs e)
        /// <summary>
        /// 查詢按鈕
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butQuery_Click(object sender, EventArgs e)
        {
            butQuery.Enabled = false;
            string strSqlworker = string.Format(" FinishDate is not null and WorkerKey={0}", iWorkerID.ToString());
            string FullWhere = Public.CommonFunctions.GetSQLScript(QueryFilter1, QueryFilter2, rb_and.Checked ? " and " : " or ", userControlFilterDate1);

            string strSqlwhere = "";

            if (!string.IsNullOrEmpty(strSqlworker.Trim()) && string.IsNullOrEmpty(FullWhere.Trim()))
            {
                strSqlwhere = strSqlworker;
            }
            else if (string.IsNullOrEmpty(strSqlworker.Trim()) && !string.IsNullOrEmpty(FullWhere.Trim()))
            {
                strSqlwhere = FullWhere;
            }
            else if (!string.IsNullOrEmpty(strSqlworker.Trim()) && !string.IsNullOrEmpty(FullWhere.Trim()))
            {
                strSqlwhere = strSqlworker + " and " + FullWhere;
            }
            DataTable dt_ComitEvent = Public.CTrademarkPublicFunction.GetComitEvent(strSqlwhere);

            bSource_Control.DataSource = dt_ComitEvent;
            butQuery.Enabled = true;
        }

        #endregion      

        #region private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            contextMenuStrip1.Visible = false;

            switch (e.ClickedItem.Name)
            {
                case "toolStripMenuItem_Add":
                case "toolStripButton_Add":
                    AddFrom.AddTrademarkNotifyEvent ComitEvent = new AddFrom.AddTrademarkNotifyEvent();
                    ComitEvent.Text += "--" + dgViewMF.CurrentRow.Cells["TrademarkNo"].Value.ToString();
                    ComitEvent.TrademarkID = (int)dgViewMF.CurrentRow.Cells["TrademarkID"].Value;
                    if (dgViewMF.CurrentRow.Cells["CountrySymbol"].Value != null && !string.IsNullOrEmpty(dgViewMF.CurrentRow.Cells["CountrySymbol"].Value.ToString()))
                    {
                        ComitEvent.CountrySymbol = dgViewMF.CurrentRow.Cells["CountrySymbol"].Value.ToString();
                    }
                    ComitEvent.ShowDialog();
                    break;
                case "EdittoolStripMenuItem":
                case "toolStripButton_Edit":
                    if (dgViewMF.CurrentRow != null)
                    {
                        if (dgViewMF.CurrentRow.Cells["SingCode"].Value.ToString() != "")
                        {
                            MessageBox.Show("已有主管簽核，不得刪除，若要刪除，請洽簽核主管", "提示訊息", MessageBoxButtons.OK);
                            return;
                        }

                        //鎖定資料
                        int iLocker = Public.Utility.GetRecordAuth("TrademarkNotifyEventT", "TMNotifyEventID=" + dgViewMF.CurrentRow.Cells["TMNotifyEventID"].Value.ToString());
                        if (iLocker == -1 || iLocker == iWorkerID)
                        {
                            if (iLocker != iWorkerID)
                            {
                                Public.Utility.LockRecordAuth("TrademarkNotifyEventT", iWorkerID, "TMNotifyEventID=" + dgViewMF.CurrentRow.Cells["TMNotifyEventID"].Value.ToString());
                            }
                            EditForm.EditTrademarkNotifyEvent Edit = new EditForm.EditTrademarkNotifyEvent();
                            Edit.property_TMNotifyEventID = (int)dgViewMF.CurrentRow.Cells["TMNotifyEventID"].Value;
                            Edit.CountrySymbol = dgViewMF.CurrentRow.Cells["CountrySymbol"].Value.ToString();
                            if (OfficeRole == 1)
                            {
                                Edit.HomePageEvent = Properties.Settings.Default.HomePageEvent;
                            }
                            Edit.ShowDialog();

                            //Public.Utility.NuLockRecordAuth("TrademarkNotifyEventT", "TMNotifyEventID=" + TMNotifyEventTDataGridView.CurrentRow.Cells["TMNotifyEventID"].Value.ToString());
                        }
                        else
                        {
                            if (iLocker != -1)//無人使用中
                            {
                                Worker_Model worker = new Worker_Model();
                                Worker_Model.ReadOne(iLocker, ref worker);
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
                        letter.CaseKey = dgViewMF.CurrentRow.Cells["TMNotifyEventID"].Value != null ? (int)dgViewMF.CurrentRow.Cells["TMNotifyEventID"].Value : -1;

                        letter.EmailSampleType = "TrademarkEvent";
                        letter.DelegateType = dgViewMF.CurrentRow.Cells["DelegateType"].Value != null ? (int)dgViewMF.CurrentRow.Cells["DelegateType"].Value : -1;
                        letter.Attorney = dgViewMF.CurrentRow.Cells["AttorneyKey"].Value != DBNull.Value ? (int)dgViewMF.CurrentRow.Cells["AttorneyKey"].Value : -1;
                        letter.CaseNo = dgViewMF.CurrentRow.Cells["TrademarkID"].Value.ToString();
                        letter.Show();
                    }
                    break;
                case "toolStripMenuItem_SetGridColumn":
                    if (OfficeRole == 0)//最高權限
                    {
                        SetGridColumnT gc = new SetGridColumnT();
                        gc.CurrentGridSymboID = dgViewMF.Tag.ToString();
                        gc.TitleName = "商標事件記錄列表";
                        gc.Show();
                    }
                    else
                    {
                        MessageBox.Show("需最高權限者才能進行設定");
                    }
                    break;
                case "toolStripButton_Export":
                case "toolStripMenuItem_Csv":
                    try
                    {
                        Public.DLL dll = new Public.DLL();
                        Task task = dll.WriteToCSV(dgViewMF);
                    }
                    catch
                    {

                        MessageBox.Show("匯出CSV失敗", "提示訊息", MessageBoxButtons.OK);
                    }
                    break;
            }
        } 
        #endregion


    }
}
