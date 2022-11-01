using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LawtechPTSystem.SubFrom
{
    /// <summary>
    /// 專利--個人完成事件記錄
    /// </summary>
    public partial class PatentWorkerEventFinish : Form
    {
        public PatentWorkerEventFinish()
        {
            InitializeComponent();

            dgViewMF.AutoGenerateColumns = false;

            Public.DynamicGridViewColumn.GetGridColum(ref dgViewMF);
        }
        UserPermissionForm myPermission;
        BindingSource bSource_Control;

        private const string ProgramSymbol = "PatentWorkerEventFinish";
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
            get { return Properties.Settings.Default.OfficeRole; }
        }
        #endregion

        #region  private void PatentWorkerEventFinish_Load(object sender, EventArgs e)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PatentWorkerEventFinish_Load(object sender, EventArgs e)
        {
            Public.PublicForm Forms = new Public.PublicForm();
            Forms.PatentWorkerEventFinish = this;

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
            System.Windows.Forms.ContextMenuStrip[] listtMenu = {  contextMenuStrip1 };

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

        #region private void PatentWorkerEventFinish_FormClosed(object sender, FormClosedEventArgs e)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PatentWorkerEventFinish_FormClosed(object sender, FormClosedEventArgs e)
        {
            Public.PublicForm Forms = new Public.PublicForm();
            Forms.PatentWorkerEventFinish = null;
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

        #region 查詢按鈕 private void butQuery_Click(object sender, EventArgs e)
        /// <summary>
        /// 查詢按鈕
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void butQuery_Click(object sender, EventArgs e)
        {
            butQuery.Enabled = false;
            string strSqlworker = string.Format(" FinishDate is not  null and WorkerKey={0}", iWorkerID.ToString());
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
            System.Data.DataTable dt_ComitEvent = Public.CPatentPublicFunction.GetComitEvent(strSqlwhere);

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
                    AddFrom.AddPatentComitEvent ComitEvent = new AddFrom.AddPatentComitEvent();
                    ComitEvent.Text += "--" + dgViewMF.CurrentRow.Cells["PatentNo"].Value.ToString();
                    ComitEvent.PatentID = (int)dgViewMF.CurrentRow.Cells["PatentID"].Value;
                    if (dgViewMF.CurrentRow.Cells["CountrySymbol"].Value != null && !string.IsNullOrEmpty(dgViewMF.CurrentRow.Cells["CountrySymbol"].Value.ToString()))
                    {
                        ComitEvent.CountrySymbol = dgViewMF.CurrentRow.Cells["CountrySymbol"].Value.ToString();
                    }
                    ComitEvent.ShowDialog();
                    break;
                case "EdittoolStripMenuItem":
                case "toolStripButtonEditItem":
                    if (dgViewMF.CurrentRow != null)
                    {
                        if (dgViewMF.CurrentRow.Cells["SingCode"].Value.ToString() != "")
                        {
                            MessageBox.Show("已有主管簽核，不得刪除，若要刪除，請洽簽核主管", "提示訊息", MessageBoxButtons.OK);
                            return;
                        }

                        //判斷是否有人使用中
                        int iLocker = Public.Utility.GetRecordAuth("PatComitEventT", "PatComitEventID=" + dgViewMF.CurrentRow.Cells["PatComitEventID"].Value.ToString());
                        if (iLocker == -1 || iLocker == iWorkerID)
                        {
                            if (iLocker != iWorkerID)
                            {
                                Public.Utility.LockRecordAuth("PatComitEventT", iWorkerID, "PatComitEventID=" + dgViewMF.CurrentRow.Cells["PatComitEventID"].Value.ToString());
                            }
                            EditForm.EditComitEvent comit_Edit = new EditForm.EditComitEvent();
                            comit_Edit.PatComitEventID = (int)dgViewMF.CurrentRow.Cells["PatComitEventID"].Value;
                            comit_Edit.PatentID = (int)dgViewMF.CurrentRow.Cells["PatentID"].Value;
                            comit_Edit.Text += "(" + dgViewMF.CurrentRow.Cells["PatentNo"].Value.ToString() + "  " + dgViewMF.CurrentRow.Cells["Country"].Value.ToString() + ")";
                            comit_Edit.CountrySymbol = dgViewMF.CurrentRow.Cells["CountrySymbol"].Value.ToString();
                            if (OfficeRole == 1)
                            {
                                comit_Edit.HomePageEvent = Properties.Settings.Default.HomePageEvent;
                            }
                            comit_Edit.ShowDialog();
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
                        letter.CaseKey = dgViewMF.CurrentRow.Cells["EventID"].Value != null ? (int)dgViewMF.CurrentRow.Cells["EventID"].Value : -1;

                        letter.EmailSampleType = "PatentEvent";
                        letter.DelegateType = dgViewMF.CurrentRow.Cells["DelegateType"].Value != null ? (int)dgViewMF.CurrentRow.Cells["DelegateType"].Value : -1;
                        letter.Attorney = dgViewMF.CurrentRow.Cells["AttorneyKey"].Value != DBNull.Value ? (int)dgViewMF.CurrentRow.Cells["AttorneyKey"].Value : -1;
                        letter.CaseNo = dgViewMF.CurrentRow.Cells["PatentNo"].Value.ToString();
                        letter.Show();
                    }
                    break;
                case "toolStripMenuItem_SetGridColumn":
                    if (OfficeRole == 0)//最高權限
                    {
                        SetGridColumnT gc = new SetGridColumnT();
                        gc.CurrentGridSymboID = dgViewMF.Tag.ToString();
                        gc.TitleName = "專利事件記錄列表";
                        gc.Show();
                    }
                    else
                    {
                        MessageBox.Show("需最高權限者才能進行設定");
                    }
                    break;
                case "toolStripMenuItem_Csv":
                case "toolStripButton_Export":
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
