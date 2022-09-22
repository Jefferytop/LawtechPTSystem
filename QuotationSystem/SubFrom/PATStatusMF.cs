using System;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LawtechPTSystem.SubFrom
{
    /// <summary>
    /// 專利--案件階段設定
    /// </summary>
    public partial class PATStatusMF : Form
    {
        UserPermissionForm myPermission;
        private const string strProgramSymbol = "PATStatusMF";
        private const string SourceTableName = "PatStatusT";

        public PATStatusMF()
        {
            InitializeComponent();
            Public.DynamicGridViewColumn.GetGridColum(ref patStatusTDataGridView);
        }

        public DataTable GetPatStatusT
        {
            get { return this.qS_DataSet.PatStatusT; }
        }

        private void PATStatusMF_Load(object sender, EventArgs e)
        {
            Public.PublicForm Forms = new Public.PublicForm();
            Forms.PATStatusMF = this;

            //取得權限
            myPermission = new UserPermissionForm(Properties.Settings.Default.WorkerKEY, strProgramSymbol);

            System.Windows.Forms.BindingNavigator[] listbinding = { bindingNavigator1 };
            System.Windows.Forms.ContextMenuStrip[] listtMenu = { contextMenuStrip1 };

            //確認可使用的功能選單
            Public.CommonFunctions.CheckMeunItemVisible(listbinding, myPermission.UserPermission);
            Public.CommonFunctions.CheckMeunItemVisible(listtMenu, myPermission.UserPermission);

            this.patStatusTTableAdapter.FillByALL(this.qS_DataSet.PatStatusT);

            this.qS_DataSet.PatStatusT.ColumnChanged += new DataColumnChangeEventHandler(PatStatusT_ColumnChanged);
        }

        private void PATStatusMF_FormClosed(object sender, FormClosedEventArgs e)
        {
            Public.PublicForm Forms = new Public.PublicForm();
            Forms.PATStatusMF = null;
        }

        public void upDataSet()
        {
            this.qS_DataSet.PatStatusT.Clear();
            this.patStatusTTableAdapter.Fill(this.qS_DataSet.PatStatusT);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region contextMenuStrip1_ItemClicked
        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            contextMenuStrip1.Visible = false;
            switch (e.ClickedItem.Name)
            {
                case "toolStripButton_Add":
                case "AddToolStripMenuItem":
                    AddFrom.AddPATStatus add = new AddFrom.AddPATStatus();

                    add.ShowDialog();

                    break;
                case "toolStripButton_Del":
                case "DelToolStripMenuItem":
                    if (patStatusTDataGridView.CurrentRow != null)
                    {
                        string sName = patStatusTDataGridView.CurrentRow.Cells["Status"].Value.ToString();

                        if (MessageBox.Show("是否確定刪除 【" + sName + "】", "確認視窗", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            int iKey = (int)patStatusTDataGridView.CurrentRow.Cells["StatusID"].Value;
                            Public.CPatStatus PatStatus = new Public.CPatStatus();
                            Public.CPatStatus.ReadOne(iKey, ref PatStatus);
                            
                            //刪除記錄檔    
                            Public.CSystemLogT log = new Public.CSystemLogT();
                            log.DelTime = DateTime.Now;
                            log.DelWorkerKey = Properties.Settings.Default.WorkerKEY;
                            log.DelWorker = Properties.Settings.Default.WorkerName;
                            
                            log.DelContent = string.Format("案件階段:{0}", PatStatus.Status);
                            log.DelTitle = string.Format("刪除「{0}」資料【{0}】", this.Text,PatStatus.Status);
                            log.Create();

                            PatStatus.Delete();

                            patStatusTDataGridView.Rows.Remove(patStatusTDataGridView.CurrentRow);
                            MessageBox.Show("刪除成功");
                        }
                    }
                    break;
                case "toolStripButton_Export":
                case "toolStripMenuItem_Excel":
                    try
                    {
                        Public.DLL dll = new Public.DLL();
                        Task task = dll.WriteToCSV(patStatusTDataGridView);
                    }
                    catch
                    {
                        MessageBox.Show("匯出CSV失敗:匯出過程發生異常被終止");
                    }
                    break;
                
            }
        }
        #endregion

        #region patStatusTDataGridView_DataError
        private void patStatusTDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = false;
        }
        #endregion

        #region  =============PatStatusT_ColumnChanged事件===============
        private void PatStatusT_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            if (e.Row.RowState == DataRowState.Unchanged)
            {
                Public.CPatStatus CA_CPatStatus = new Public.CPatStatus();
                Public.CPatStatus.ReadOne(int.Parse(e.Row["StatusID"].ToString()), ref CA_CPatStatus);
               
                switch (e.Column.ColumnName)
                {                    
                    case "Status":
                        CA_CPatStatus.Status = e.ProposedValue != null ? e.ProposedValue.ToString() : "";
                        break;
                    case "bStop":
                        CA_CPatStatus.bStop = e.ProposedValue != DBNull.Value ? (bool)e.ProposedValue : false;
                        break;
                    case "Sort":
                        CA_CPatStatus.Sort = e.ProposedValue != DBNull.Value ? (int)e.ProposedValue : -1;
                        break;
                }
                CA_CPatStatus.Update();
                this.qS_DataSet.PatStatusT.AcceptChanges();
            }
        }
        #endregion

        private void but_Update_Click(object sender, EventArgs e)
        {
            if (this.qS_DataSet.PatStatusT.Rows.Count > 0)
            {
                this.qS_DataSet.PatStatusT.Rows.Clear();
            }

            this.patStatusTTableAdapter.Fill(this.qS_DataSet.PatStatusT);
        }

      
    }
}