using System;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LawtechPTSystem.SubFrom
{
    public partial class TrademarkPerformanceList : Form
    {
        BindingSource bSource_Control;

        UserPermissionForm myPermission;
        private const string ProgramSymbol = "TrademarkPerformanceList";
        private const string SourceTableName = "V_TrademarkPerformanceBonus";

        /// <summary>
        /// 商標申請案績效表
        /// </summary>
        public TrademarkPerformanceList()
        {
            InitializeComponent();

            dgViewMF.AutoGenerateColumns = false;
            Public.DynamicGridViewColumn.GetGridColum(ref dgViewMF);
        }

        #region Property

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

        private DataTable dt_PatentPerformanceBonus = new DataTable();
        /// <summary>
        /// 取得專利案件績效表的資料
        /// </summary>
        public DataTable DT_PatentPerformanceBonus
        {
            get
            {
                return dt_PatentPerformanceBonus;
            }

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

        #region private void TrademarkPerformanceList_Load(object sender, EventArgs e)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TrademarkPerformanceList_Load(object sender, EventArgs e)
        {
            Public.PublicForm Forms = new Public.PublicForm();
            Forms.TrademarkPerformanceList = this;

            //取得登入者身份
            iWorkerID = Properties.Settings.Default.WorkerKEY;
            Worker_Model worker = new Worker_Model();
            Worker_Model.ReadOne(iWorkerID, ref  worker);

            iOfficeRole = worker.OfficeRole.Value;
            strWorkerName = worker.EmployeeName;

            //取得權限
            myPermission = new UserPermissionForm(Properties.Settings.Default.WorkerKEY, ProgramSymbol);

            System.Windows.Forms.BindingNavigator[] listbinding = { bindingNavigator1 };
            //System.Windows.Forms.ContextMenuStrip[] listtMenu = { contextMenuMain, contextMenuStrip1 };

            //確認可使用的功能選單
            Public.CommonFunctions.CheckMeunItemVisible(listbinding, myPermission.UserPermission);
            //Public.CommonFunctions.CheckMeunItemVisible(listtMenu, myPermission.UserPermission);
            if (dt_PatentPerformanceBonus.Columns.Count == 0)
            {
                Public.CTrademarkPublicFunction.GetTrademarkPerformanceBonus("1=0", ref dt_PatentPerformanceBonus);
            }
            bSource_Control = new BindingSource();
            bSource_Control.DataSource = dt_PatentPerformanceBonus;
            dgViewMF.DataSource = bSource_Control;
            bindingNavigator1.BindingSource = bSource_Control;

            butQuery_Click(null, null);
        }

        #endregion

        #region private void TrademarkPerformanceList_FormClosed(object sender, FormClosedEventArgs e)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TrademarkPerformanceList_FormClosed(object sender, FormClosedEventArgs e)
        {
            Public.PublicForm Forms = new Public.PublicForm();
            Forms.TrademarkPerformanceList = null;
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

            string strSQL = Public.CommonFunctions.GetSQLScript(QueryFilter1, QueryFilter2, rb_and.Checked ? " and " : " or ", userControlFilterDate1);

            Public.CTrademarkPublicFunction.GetTrademarkPerformanceBonus(strSQL, ref dt_PatentPerformanceBonus);

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
                case "ToolStripMenuItem_PatentView":
                    toolStripLabel_PatentView_Click(null, null);
                    break;
                case "toolStripButton_Export":
                case "ToolStripMenuItem_ExportCSV":
                    try
                    {
                        Public.DLL dll = new Public.DLL();
                        Task task = dll.WriteToCSV(dgViewMF);
                    }
                    catch
                    {
                        MessageBox.Show("匯出CSV失敗");
                    }
                    break;
                case "toolStripButton_OpenFile":
                case "toolStripLabel_UpdateFileList":
                    if (dgViewMF.CurrentRow != null)
                    {
                        ViewUpdateFileList subForm = new ViewUpdateFileList();
                        subForm.Text = dgViewMF.CurrentRow.Cells["PatentNo"].Value.ToString() + "的相關文件";
                        subForm.FileKind = 3;
                        subForm.FileType = 0;
                        subForm.MainParentID = (int)dgViewMF.CurrentRow.Cells["PatentID"].Value;
                        subForm.radoC.Checked = true;
                        subForm.ShowDialog();
                    }
                    break;
                case "toolStripButton_CompleteHistory":
                case "toolStripMenuItem_CompleteHistory":
                    if (dgViewMF.SelectedRows.Count > 0)
                    {
                        ViewFrom.PatentCompleteHistory history = new LawtechPTSystem.ViewFrom.PatentCompleteHistory();
                        history.Gv = dgViewMF;
                        history.Show();
                    }
                    break;
                case "toolStripMenuItem_SetGridColumn":
                    SetGridColumnT gc = new SetGridColumnT();
                    gc.CurrentGridSymboID = dgViewMF.Tag.ToString();
                    gc.TitleName = "商標案件績效列表";
                    gc.Show();
                    break;
                case "ToolStripMenuItem_OpenFile":
                    toolStripLabel_UpdateFileList_Click(null, null);
                    break;
            }
        }
        #endregion

        #region 申請案詳細資料 private void toolStripLabel_PatentView_Click(object sender, EventArgs e)
        /// <summary>
        /// 申請案詳細資料
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripLabel_PatentView_Click(object sender, EventArgs e)
        {
            if (dgViewMF.CurrentRow != null)
            {
                TrademarkHistoryRecord HistoryRecord = new TrademarkHistoryRecord();
                HistoryRecord.TrademarkID = (int)dgViewMF.CurrentRow.Cells["TrademarkID"].Value;
                HistoryRecord.TabSelectedIndex = 0;
                HistoryRecord.Show();
            }
        } 
        #endregion

        #region 案件完整歷程 private void toolStripButton_CompleteHistory_Click(object sender, EventArgs e)
        /// <summary>
        /// 案件完整歷程
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton_CompleteHistory_Click(object sender, EventArgs e)
        {
            if (dgViewMF.CurrentRow != null)
            {

                ViewFrom.TrademarkCompleteHistory history = new LawtechPTSystem.ViewFrom.TrademarkCompleteHistory();
                history.Gv = dgViewMF;
                history.Show();
            }
        } 
        #endregion

        #region 相關文件 private void toolStripLabel_UpdateFileList_Click(object sender, EventArgs e)
        /// <summary>
        /// 相關文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        #region private void dgViewMF_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgViewMF_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex != -1 && e.RowIndex != -1)
            {
                if (dgViewMF.Columns[e.ColumnIndex].Name == "EventCount")
                {
                    ViewFrom.TrademarkEventByUser patent = new ViewFrom.TrademarkEventByUser();
                    patent.property_TrademarkID = (int)dgViewMF.CurrentRow.Cells["TrademarkID"].Value;
                    patent.property_UserKey = dgViewMF.CurrentRow.Cells["WorkerKey"].Value.ToString() == "" ? -1 : (int)dgViewMF.CurrentRow.Cells["WorkerKey"].Value;
                    patent.Text = dgViewMF.CurrentRow.Cells["TrademarkNo"].Value.ToString() + "--" + dgViewMF.CurrentRow.Cells["EmployeeName"].Value.ToString() + " 事件記錄";
                    patent.Show();
                }
                else if (dgViewMF.Columns[e.ColumnIndex].Name == "FeeSUM")
                {
                    ViewFrom.TrademarkFeeByUser patent = new ViewFrom.TrademarkFeeByUser();
                    patent.property_TrademarkID = (int)dgViewMF.CurrentRow.Cells["TrademarkID"].Value;
                    patent.property_UserKey = dgViewMF.CurrentRow.Cells["WorkerKey"].Value.ToString() == "" ? -1 : (int)dgViewMF.CurrentRow.Cells["WorkerKey"].Value;
                    patent.Text = dgViewMF.CurrentRow.Cells["TrademarkNo"].Value.ToString() + "--" + dgViewMF.CurrentRow.Cells["EmployeeName"].Value.ToString() + " 請款記錄";
                    patent.Show();
                }
                else if (dgViewMF.Columns[e.ColumnIndex].Name == "PaySUM")
                {
                    ViewFrom.TrademarkPaymentByUser patent = new ViewFrom.TrademarkPaymentByUser();
                    patent.property_TrademarkID = (int)dgViewMF.CurrentRow.Cells["TrademarkID"].Value;
                    patent.property_UserKey = dgViewMF.CurrentRow.Cells["WorkerKey"].Value.ToString() == "" ? -1 : (int)dgViewMF.CurrentRow.Cells["WorkerKey"].Value;
                    patent.Text = dgViewMF.CurrentRow.Cells["TrademarkNo"].Value.ToString() + "--" + dgViewMF.CurrentRow.Cells["EmployeeName"].Value.ToString() + " 付款記錄";
                    patent.Show();
                }
            }
        }
        #endregion

    }
}
