using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace LawtechPTSystem.SubFrom
{
    /// <summary>
    /// 商標--標準作業流程設定
    /// </summary>
    public partial class TrademarkEventProcess : Form
    {
        UserPermissionForm myPermission;
        private const string strProgramSymbol = "TrademarkEventProcess";
        private const string SourceTableName = "TrademarkProcessKindT";

        public TrademarkEventProcess()
        {
            InitializeComponent();

            dataGridView_ProcessKind.AutoGenerateColumns = false;
            processStepETDataGridView.AutoGenerateColumns = false;

            Public.DynamicGridViewColumn.GetGridColum(ref dataGridView_ProcessKind);

            Dictionary<string, BindingSource> lists = new Dictionary<string, BindingSource>() { { "tMStatusTBindingSource", tMStatusTBindingSource }, { "workerTAllBindingSource", workerTAllBindingSource } };
            Public.DynamicGridViewColumn.GetGridColum(ref processStepETDataGridView, lists);
        }

        /// <summary>
        /// 取得事件程序的資料集
        /// </summary>
        public DataTable GetPKind
        {
            get { return this.dataSet_TM.TrademarkProcessKindT; }
        }

        /// <summary>
        /// 取得程序清單的資料集
        /// </summary>
        public DataTable GetPHandle
        {
            get { return this.dataSet_TM.TrademarkProcessStepET; }
        }

        private void but_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TrademarkEventProcess_Load(object sender, EventArgs e)
        {
            Public.PublicForm Froms = new Public.PublicForm();
            Froms.TrademarkEventProcess = this;

            //取得權限
            myPermission = new UserPermissionForm(Properties.Settings.Default.WorkerKEY, strProgramSymbol);

            System.Windows.Forms.BindingNavigator[] listbinding = { bindingNavigator1, bindingNavigator2 };
            System.Windows.Forms.ContextMenuStrip[] listtMenu = { contextMenuStrip1, contextMenuStrip2 };

            //確認可使用的功能選單
            Public.CommonFunctions.CheckMeunItemVisible(listbinding, myPermission.UserPermission);
            Public.CommonFunctions.CheckMeunItemVisible(listtMenu, myPermission.UserPermission);

            this.workerTAllTableAdapter.Fill(this.qS_DataSet.WorkerTAll);
            this.tMStatusTTableAdapter.Fill(this.dataSet_Drop.TMStatusT);           
            this.trademarkProcessKindTTableAdapter.Fill(this.dataSet_TM.TrademarkProcessKindT);


            ((System.Windows.Forms.DataGridViewCheckBoxColumn)dataGridView_ProcessKind.Columns["ProcessbStop"]).TrueValue = 1;
            ((System.Windows.Forms.DataGridViewCheckBoxColumn)dataGridView_ProcessKind.Columns["ProcessbStop"]).FalseValue = 0;

            this.dataSet_TM.TrademarkProcessKindT.ColumnChanged += new DataColumnChangeEventHandler(ProcessKindT_ColumnChanged);
            this.dataSet_TM.TrademarkProcessStepET.ColumnChanged += new DataColumnChangeEventHandler(ProcessStepET_ColumnChanged);
        }

        private void TrademarkEventProcess_FormClosed(object sender, FormClosedEventArgs e)
        {
            Public.PublicForm Froms = new Public.PublicForm();
            Froms.TrademarkEventProcess = null;
        }

        #region  =============ProcessKindT_ColumnChanged事件===============
        private void ProcessKindT_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            if (e.Row.RowState == DataRowState.Unchanged)
            {
                Public.CTrademarkProcessKind CA_CProcessKind = new Public.CTrademarkProcessKind();
                Public.CTrademarkProcessKind.ReadOne(int.Parse(e.Row["ProcessKEY"].ToString()), ref CA_CProcessKind);
              
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
                this.dataSet_TM.TrademarkProcessKindT.AcceptChanges();
            }
        }
        #endregion


        #region  =============ProcessStepET_ColumnChanged事件===============
        private void ProcessStepET_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            if (e.Row.RowState == DataRowState.Unchanged)
            {
                Public.CTrademarkProcessStepE CA_CProcessStep = new Public.CTrademarkProcessStepE();
                Public.CTrademarkProcessStepE.ReadOne(int.Parse(e.Row["ProcessHandleKEY"].ToString()), ref CA_CProcessStep);
                
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
                this.dataSet_TM.TrademarkProcessStepET.AcceptChanges();
            }
        }
        #endregion

        private void dataGridView_ProcessKind_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = false;
        }

        #region contextMenuStrip1_ItemClicked
        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            contextMenuStrip1.Visible = false;
            switch (e.ClickedItem.Name)
            {
                case "toolStripButton_AddProcessKind":
                case "AddToolStripMenuItem":

                    AddFrom.AddTrademarkProcessKind Add = new AddFrom.AddTrademarkProcessKind();
                  
                    Add.ShowDialog();

                    break;
                case "toolStripButton_DelProcessKind":
                case "DelToolStripMenuItem":

                    if (dataGridView_ProcessKind.CurrentRow != null)
                    {
                        string strName = dataGridView_ProcessKind.CurrentRow.Cells["ProcessKindName"].Value.ToString();

                        if (MessageBox.Show("是否確定刪除【" + strName + "】", "確認視窗", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            int iKey = (int)dataGridView_ProcessKind.CurrentRow.Cells["ProcessKEY"].Value;

                            Public.CTrademarkProcessKind ProcessKind = new Public.CTrademarkProcessKind();
                            Public.CTrademarkProcessKind.ReadOne(iKey, ref ProcessKind);

                            //刪除記錄檔    
                            Public.CSystemLogT log = new Public.CSystemLogT();
                            log.DelTime = DateTime.Now;
                            log.DelWorkerKey = Properties.Settings.Default.WorkerKEY;
                            log.DelWorker = Properties.Settings.Default.WorkerName;                         
                            log.DelContent = string.Format("標準流程名稱:{0}", ProcessKind.ProcessKind);
                            log.DelTitle = string.Format("刪除「{0}」資料【{1}】", this.Text,ProcessKind.ProcessKind);
                            log.Create();

                            ProcessKind.Delete();

                            DataRow dr = this.dataSet_TM.TrademarkProcessKindT.Rows.Find((int)dataGridView_ProcessKind.CurrentRow.Cells["ProcessKEY"].Value);
                            this.dataSet_TM.TrademarkProcessKindT.Rows.Remove(dr);
                            this.dataSet_TM.TrademarkProcessKindT.AcceptChanges();
                            MessageBox.Show("刪除成功");
                        }
                    }


                    break;

                case "toolStripButton1":
                    Public.Utility.SsplitContainerHorizontal(ref splitContainer1);
                    break;

            }
        }
        #endregion


        private void contextMenuStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            contextMenuStrip2.Visible = false;

            switch (e.ClickedItem.Name)
            {
                case "toolStripButton_Add":
                case "ToolStripMenuItem_AddProcess":
                    AddFrom.AddTrademarkHandleProcess addProc = new AddFrom.AddTrademarkHandleProcess();
                    addProc.ProcessKEY = (int)dataGridView_ProcessKind.CurrentRow.Cells["ProcessKEY"].Value;
                    addProc.ShowDialog();
                    break;
                case "toolStripButton_Del":
                case "ToolStripMenuItem_DelProcess":

                    if (processStepETDataGridView.CurrentRow != null)
                    {
                        
                        string strName = processStepETDataGridView.CurrentRow.Cells["TrademarkHandle"].Value.ToString();

                        if (MessageBox.Show("是否確定刪除【" + strName + "】", "確認視窗", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            int iKey = (int)processStepETDataGridView.CurrentRow.Cells["ProcessHandleKEY"].Value;
                            Public.CTrademarkProcessStepE ProcessStep = new Public.CTrademarkProcessStepE();
                            Public.CTrademarkProcessStepE.ReadOne(iKey, ref ProcessStep);

                            //刪除記錄檔    
                            Public.CSystemLogT log = new Public.CSystemLogT();
                            log.DelTime = DateTime.Now;
                            log.DelWorkerKey = Properties.Settings.Default.WorkerKEY;
                            log.DelWorker = Properties.Settings.Default.WorkerName;                          
                            log.DelContent = string.Format("處理階段:{0}", ProcessStep.Handle);
                            log.DelTitle = string.Format("刪除「{0}」資料【{1}--{2}】", this.Text,dataGridView_ProcessKind.CurrentRow.Cells["ProcessKindName"].Value.ToString(), ProcessStep.Handle);
                            log.Create();


                            ProcessStep.Delete();

                            DataRow dr = this.dataSet_TM.TrademarkProcessStepET.Rows.Find((int)processStepETDataGridView.CurrentRow.Cells["ProcessHandleKEY"].Value);

                            processStepETDataGridView.Rows.Remove(processStepETDataGridView.CurrentRow);

                            this.dataSet_TM.TrademarkProcessStepET.Rows.Remove(dr);
                            this.dataSet_TM.TrademarkProcessStepET.AcceptChanges();
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

        private void dataGridView_ProcessKind_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView_ProcessKind.CurrentRow != null)
            {
                this.dataSet_TM.TrademarkProcessStepET.Clear();
                this.trademarkProcessStepETTableAdapter.Fill(this.dataSet_TM.TrademarkProcessStepET, (int)dataGridView_ProcessKind.CurrentRow.Cells["ProcessKEY"].Value);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();

        }

       

      

    }
}
