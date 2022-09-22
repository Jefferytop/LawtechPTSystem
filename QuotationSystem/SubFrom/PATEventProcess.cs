using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace LawtechPTSystem.SubFrom
{
    /// <summary>
    /// 標準作業流程設定
    /// </summary>
    public partial class PATEventProcess : Form
    {
        UserPermissionForm myPermission;
        private const string strProgramSymbol = "PATEventProcess";
        private const string SourceTableName = "ProcessKindT";

        /// <summary>
        /// 取得事件程序的資料集
        /// </summary>
        public DataTable GetPKind
        {
            get { return this.qS_DataSet.ProcessKindT; }
        }

        /// <summary>
        /// 取得程序清單的資料集
        /// </summary>
        public DataTable GetPHandle
        {
            get { return this.qS_DataSet.ProcessStepET; }
        }

        public PATEventProcess()
        {
            InitializeComponent();
            dataGridView_ProcessKind.AutoGenerateColumns = false;
            processStepETDataGridView.AutoGenerateColumns = false;
            Public.DynamicGridViewColumn.GetGridColum(ref dataGridView_ProcessKind);

            Dictionary<string, BindingSource> lists2 = new Dictionary<string, BindingSource>() { { "patStatusTDropBindingSource", patStatusTDropBindingSource } };
            Public.DynamicGridViewColumn.GetGridColum(ref processStepETDataGridView, lists2);
        }

        #region PATEventProcess_Load PATEventProcess_FormClosed
        private void PATEventProcess_Load(object sender, EventArgs e)
        {
            Public.PublicForm Froms = new Public.PublicForm();
            Froms.PATEventProcess = this;

            //取得權限
            myPermission = new UserPermissionForm(Properties.Settings.Default.WorkerKEY, strProgramSymbol);

            System.Windows.Forms.BindingNavigator[] listbinding = { bindingNavigator1, bindingNavigator2 };
            System.Windows.Forms.ContextMenuStrip[] listtMenu = { contextMenuStrip1, contextMenuStrip2 };

            //確認可使用的功能選單
            Public.CommonFunctions.CheckMeunItemVisible(listbinding, myPermission.UserPermission);
            Public.CommonFunctions.CheckMeunItemVisible(listtMenu, myPermission.UserPermission);
           
            this.patStatusT_DropTableAdapter.Fill(this.qS_DataSet._PatStatusT_Drop);
           
            this.processKindTTableAdapter.Fill(this.qS_DataSet.ProcessKindT);

            if (this.qS_DataSet.ProcessKindT.Rows.Count > 0)
            {
                this.processStepETTableAdapter.Fill(this.qS_DataSet.ProcessStepET, (int)this.qS_DataSet.ProcessKindT.Rows[0]["ProcessKEY"]);
            }

            ((System.Windows.Forms.DataGridViewCheckBoxColumn)dataGridView_ProcessKind.Columns["ProcessbStop"]).TrueValue = 1;
            ((System.Windows.Forms.DataGridViewCheckBoxColumn)dataGridView_ProcessKind.Columns["ProcessbStop"]).FalseValue =0;

            this.qS_DataSet.ProcessKindT.ColumnChanged += new DataColumnChangeEventHandler(ProcessKindT_ColumnChanged);
            this.qS_DataSet.ProcessStepET.ColumnChanged += new DataColumnChangeEventHandler(ProcessStepET_ColumnChanged);

        }

        private void PATEventProcess_FormClosed(object sender, FormClosedEventArgs e)
        {
            Public.PublicForm Froms = new Public.PublicForm();
            Froms.PATEventProcess = null;
        }
        #endregion

        #region  =============ProcessKindT_ColumnChanged事件===============
        private void ProcessKindT_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            if (e.Row.RowState == DataRowState.Unchanged)
            {
                Public.CProcessKind CA_CProcessKind = new Public.CProcessKind();
                Public.CProcessKind.ReadOne((int)e.Row["ProcessKEY"], ref CA_CProcessKind);
                switch (e.Column.ColumnName)
                {
                    case "sort":
                        CA_CProcessKind.sort = e.ProposedValue != DBNull.Value ? (int)e.ProposedValue : -1;
                        break;
                    case "ProcessKind":
                        CA_CProcessKind.ProcessKind = e.ProposedValue != null ? e.ProposedValue.ToString() : "";
                        break;
                    case "bStop":
                        CA_CProcessKind.bStop = e.ProposedValue != DBNull.Value ? (int)e.ProposedValue : -1;
                        break;
                }
                CA_CProcessKind.Update();
                this.qS_DataSet.ProcessKindT.AcceptChanges();
            }
        }
        #endregion

        #region  =============ProcessStepET_ColumnChanged事件===============
        private void ProcessStepET_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            if (e.Row.RowState == DataRowState.Unchanged)
            {
                Public.CProcessStep CA_CProcessStep = new Public.CProcessStep();
                Public.CProcessStep.ReadOne(int.Parse(e.Row["ProcessHandleKEY"].ToString()), ref CA_CProcessStep);
              
                switch (e.Column.ColumnName)
                {
                    case "sort":
                        CA_CProcessStep.sort = e.ProposedValue != DBNull.Value ? (int)e.ProposedValue : -1;
                        break;
                    case "Handle":
                        CA_CProcessStep.Handle = e.ProposedValue != null ? e.ProposedValue.ToString() : "";
                        break;
                    case "Status":
                        CA_CProcessStep.Status = e.ProposedValue != DBNull.Value ? (int)e.ProposedValue : -1;
                        break;
                    case "DefualtWorker":
                        CA_CProcessStep.DefualtWorker = e.ProposedValue != DBNull.Value ? (int)e.ProposedValue : -1;
                        break;
                    case "Days":
                        CA_CProcessStep.Days = e.ProposedValue != DBNull.Value ? (int)e.ProposedValue : -1;
                        break;
                    case "Hours":
                        CA_CProcessStep.Hours = e.ProposedValue != DBNull.Value ? (int)e.ProposedValue : -1;
                        break;
                    case "Minutes":
                        CA_CProcessStep.Minutes = e.ProposedValue != DBNull.Value ? (int)e.ProposedValue : -1;
                        break;
                    case "IsUsing":
                        CA_CProcessStep.IsUsing = e.ProposedValue != DBNull.Value ? (bool)e.ProposedValue : false;
                        break;
                    case "ProcessKEY":
                        CA_CProcessStep.ProcessKEY = e.ProposedValue != DBNull.Value ? (int)e.ProposedValue : -1;
                        break;
                }
                CA_CProcessStep.Update();
                this.qS_DataSet.ProcessStepET.AcceptChanges();
            }
        }
        #endregion

        #region contextMenuStrip1_ItemClicked
        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            contextMenuStrip1.Visible = false;
            switch (e.ClickedItem.Name)
            {
                case "toolStripButton_Add":
                case "AddToolStripMenuItem":

                    AddFrom.AddProcessKind Add = new AddFrom.AddProcessKind();
                                       
                    Add.ShowDialog();

                    break;
                case "toolStripButton_Del":
                case "DelToolStripMenuItem":

                    if (dataGridView_ProcessKind.CurrentRow != null)
                    {
                        string sName = dataGridView_ProcessKind.CurrentRow.Cells["ProcessKindName"].Value.ToString();
                        if (MessageBox.Show("是否確定刪除【" + sName + "】", "確認視窗", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            int iKey=(int)dataGridView_ProcessKind.CurrentRow.Cells["ProcessKEY"].Value;
                            Public.CProcessKind ProcessKind = new Public.CProcessKind();
                            Public.CProcessKind.ReadOne(iKey, ref ProcessKind);

                            //刪除記錄檔    
                            Public.CSystemLogT log = new Public.CSystemLogT();
                            log.DelTime = DateTime.Now;
                            log.DelWorkerKey = Properties.Settings.Default.WorkerKEY;
                            log.DelWorker = Properties.Settings.Default.WorkerName;                          
                            log.DelContent = string.Format("標準流程名稱:{0}", ProcessKind.ProcessKind);
                            log.DelTitle = string.Format("刪除「{0}」 資料【{1}】", this.Text,ProcessKind.ProcessKind);
                            log.Create();


                            ProcessKind.Delete(iKey);

                            DataRow dr = this.qS_DataSet.ProcessKindT.Rows.Find((int)dataGridView_ProcessKind.CurrentRow.Cells["ProcessKEY"].Value);
                            this.qS_DataSet.ProcessKindT.Rows.Remove(dr);
                            this.qS_DataSet.ProcessKindT.AcceptChanges();
                            MessageBox.Show("刪除成功");
                        }
                    }


                    break;

            }
        }
        #endregion

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {       
                e.Cancel = false;
        }

        #region contextMenuStrip2_ItemClicked
        private void contextMenuStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            contextMenuStrip2.Visible = false;

            switch (e.ClickedItem.Name)
            {
                case "toolStripButton_AddDetail":
                case "ToolStripMenuItem_AddProcess":
                    AddFrom.AddHandleProcess addProc = new AddFrom.AddHandleProcess();
                    addProc.ProcessKey = (int)dataGridView_ProcessKind.CurrentRow.Cells["ProcessKEY"].Value;
                    addProc.ShowDialog();
                    break;
                case "toolStripButton_DelDetail":
                case "ToolStripMenuItem_DelProcess":

                    if (processStepETDataGridView.CurrentRow != null)
                    {
                        //string strSQL = "select count(*) from WorkReportT where Progress =" + processStepETDataGridView.CurrentRow.Cells["ProcessHandleKEY"].Value.ToString();
                        //Public.DLL dll = new Public.DLL();
                        //int iCount = (int)dll.SQLexecuteScalar(strSQL);                        
                        //if (iCount > 0)
                        //{
                        //    MessageBox.Show("該筆處理歷程已被使用，不允許刪除");
                        //}
                        //else
                        //{
                        string sName = processStepETDataGridView.CurrentRow.Cells["ProcessHandle"].Value.ToString();

                        if (MessageBox.Show("是否確定刪除【" + sName + "】", "確認視窗", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                           
                            int iKey = (int)processStepETDataGridView.CurrentRow.Cells["ProcessHandleKEY"].Value;

                            Public.CProcessStep ProcessStep = new Public.CProcessStep();
                            Public.CProcessStep.ReadOne(iKey, ref ProcessStep);

                            //刪除記錄檔    
                            Public.CSystemLogT log = new Public.CSystemLogT();
                            log.DelTime = DateTime.Now;
                            log.DelWorkerKey = Properties.Settings.Default.WorkerKEY;
                            log.DelWorker = Properties.Settings.Default.WorkerName;                           
                            log.DelContent = string.Format("標準作業流程名稱:{0}\r\n流程步驟:{1}", dataGridView_ProcessKind.CurrentRow.Cells["ProcessKindName"].Value.ToString(), ProcessStep.Handle);
                            log.DelTitle = string.Format("刪除「{0}」資料【{1}】", this.Text,ProcessStep.Handle);
                            log.Create();

                            ProcessStep.Delete(iKey);

                            processStepETDataGridView.Rows.Remove(processStepETDataGridView.CurrentRow);

                            //DataRow dr = this.qS_DataSet.ProcessStepET.Rows.Find((int)processStepETDataGridView.CurrentRow.Cells["ProcessHandleKEY"].Value);
                            //this.qS_DataSet.ProcessStepET.Rows.Remove(dr);
                            //this.qS_DataSet.ProcessStepET.AcceptChanges();
                            MessageBox.Show("刪除成功");
                        }
                        //}

                    }
                    break;

                case "ToolStripMenuItem_SetPatStatus":

                    SubFrom.PATStatusMF SetMF = new PATStatusMF();

                    SetMF.ShowDialog();

                    break;

            }
        }
        #endregion

        private void dataGridView_ProcessKind_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView_ProcessKind.CurrentRow != null)
            {
                this.qS_DataSet.ProcessStepET.Clear();
                this.processStepETTableAdapter.Fill(this.qS_DataSet.ProcessStepET, (int)dataGridView_ProcessKind.CurrentRow.Cells["ProcessKEY"].Value);
            }
        }

        private void but_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Public.Utility.SsplitContainerHorizontal(ref splitContainer1);
        }

              

        
    }
}