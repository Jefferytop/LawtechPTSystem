using System;
using System.Data;
using System.Windows.Forms;

namespace LawtechPTSystem.SubFrom
{
    /// <summary>
    /// 商標費用種類設定
    /// </summary>
    public partial class TrademarkFeePhase : Form
    {
        UserPermissionForm myPermission;
        private const string strProgramSymbol = "TrademarkFeePhase";
        private const string SourceTableName = "FeePhaseT";

        public TrademarkFeePhase()
        {
            InitializeComponent();

            feePhaseTDataGridView.AutoGenerateColumns = false;
            feePhaseItemsTDataGridView.AutoGenerateColumns = false;
            Public.DynamicGridViewColumn.GetGridColum(ref feePhaseTDataGridView);
            Public.DynamicGridViewColumn.GetGridColum(ref feePhaseItemsTDataGridView);
        }

        int iType = 2;//1.Pat 2.TM

        private void but_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public DataTable GetFeePhaseT
        {
            get { return this.qS_DataSet.FeePhaseT; }
        }


        public DataTable GetFeePhaseItemsT
        {
            get { return this.qS_DataSet.FeePhaseItemsT; }
        }


        public void upDataSet()
        {
            this.qS_DataSet.FeePhaseT.Clear();
            this.feePhaseTTableAdapter.Fill(this.qS_DataSet.FeePhaseT, iType);
        }

        #region  =============FeePhaseT_ColumnChanged事件===============
        private void FeePhaseT_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            if (e.Row.RowState == DataRowState.Unchanged)
            {

                Public.CFeePhase CA_CFeePhase = new Public.CFeePhase();
                Public.CFeePhase.ReadOne(int.Parse(e.Row["FeePhaseID"].ToString()), ref CA_CFeePhase);
                
                switch (e.Column.ColumnName)
                {
                    case "Sort":
                        CA_CFeePhase.Sort = e.ProposedValue != DBNull.Value ? (int)e.ProposedValue : -1;
                        break;

                    case "FeePhase":
                        CA_CFeePhase.FeePhase = e.ProposedValue != null ? e.ProposedValue.ToString() : "";
                        break;
                }
                CA_CFeePhase.Update();
                this.qS_DataSet.FeePhaseT.AcceptChanges();
            }
        }
        #endregion

        #region  =============FeePhaseItemsT_ColumnChanged事件===============
        private void FeePhaseItemsT_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            if (e.Row.RowState == DataRowState.Unchanged)
            {

                Public.CFeePhaseItems CA_CFeePhaseItems = new Public.CFeePhaseItems();
                Public.CFeePhaseItems.ReadOne(int.Parse( e.Row["FeePhaseDetailKey"].ToString()),ref CA_CFeePhaseItems);
               
                switch (e.Column.ColumnName)
                {
                    case "Sort":
                        CA_CFeePhaseItems.Sort = e.ProposedValue != DBNull.Value ? (int)e.ProposedValue : -1;
                        break;
                    case "FeePhaseItem":
                        CA_CFeePhaseItems.FeePhaseItem = e.ProposedValue != null ? e.ProposedValue.ToString() : "";
                        break;
                }
                CA_CFeePhaseItems.Update();
                this.qS_DataSet.FeePhaseItemsT.AcceptChanges();
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
                    AddFrom.AddFeePhase add = new AddFrom.AddFeePhase();
                    add.IType = iType;
                    add.Text = "新增商標費用種類";
                    add.ShowDialog();

                    break;
                case "toolStripButton_del":
                case "DelToolStripMenuItem":
                    if (feePhaseTDataGridView.CurrentRow != null)
                    {
                        string strName = feePhaseTDataGridView.CurrentRow.Cells["FeePhase"].Value.ToString();
                        if (MessageBox.Show("是否確定刪除【" + strName+"】", "確認視窗", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            int iKey = (int)feePhaseTDataGridView.CurrentRow.Cells["FeePhaseID"].Value;

                            Public.CFeePhase TmStatus = new Public.CFeePhase();
                            Public.CFeePhase.ReadOne(iKey, ref TmStatus);

                            //刪除記錄檔    
                            Public.CSystemLogT log = new Public.CSystemLogT();
                            log.DelTime = DateTime.Now;
                            log.DelWorkerKey = Properties.Settings.Default.WorkerKEY;
                            log.DelWorker = Properties.Settings.Default.WorkerName;
                            log.DelContent = string.Format("費用種類:{0}", TmStatus.FeePhase);
                            log.DelTitle = string.Format("刪除「{0}」資料【{1}】", this.Text, TmStatus.FeePhase);
                            log.Create();


                            TmStatus.Delete();
                            feePhaseTDataGridView.Rows.Remove(feePhaseTDataGridView.CurrentRow);
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

        #region TrademarkFeePhase_Load  TrademarkFeePhase_FormClosed
        private void TrademarkFeePhase_FormClosed(object sender, FormClosedEventArgs e)
        {
            Public.PublicForm Forms = new Public.PublicForm();
            Forms.TrademarkFeePhase = null;
        }

        private void TrademarkFeePhase_Load(object sender, EventArgs e)
        {
            Public.PublicForm Forms = new Public.PublicForm();
            Forms.TrademarkFeePhase = this;

            //取得權限
            myPermission = new UserPermissionForm(Properties.Settings.Default.WorkerKEY, strProgramSymbol);

            System.Windows.Forms.BindingNavigator[] listbinding = { feePhaseTBindingNavigator, bindingNavigator1 };
            System.Windows.Forms.ContextMenuStrip[] listtMenu = { contextMenuStrip1, contextMenuStrip2 };

            //確認可使用的功能選單
            Public.CommonFunctions.CheckMeunItemVisible(listbinding, myPermission.UserPermission);
            Public.CommonFunctions.CheckMeunItemVisible(listtMenu, myPermission.UserPermission);

            feePhaseTTableAdapter.Fill(this.qS_DataSet.FeePhaseT, iType);

            this.qS_DataSet.FeePhaseT.ColumnChanged += new DataColumnChangeEventHandler(FeePhaseT_ColumnChanged);
            this.qS_DataSet.FeePhaseItemsT.ColumnChanged += new DataColumnChangeEventHandler(FeePhaseItemsT_ColumnChanged);
        }
        #endregion               

        #region but_MoneyList_Click
        private void but_MoneyList_Click(object sender, EventArgs e)
        {
            if (!splitContainer1.Panel2Collapsed)
            {
                but_MoneyList.Text = "開啟對應的費用內容(Alt+E)";

                splitContainer1.Panel2Collapsed = true;
            }
            else
            {
                but_MoneyList.Text = "關閉對應的費用內容(Alt+E)";
                splitContainer1.Panel2Collapsed = false;
            }
        }
        #endregion

        #region feePhaseTDataGridView_DataError
        private void feePhaseTDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = false;
        }
        #endregion

        #region contextMenuStrip2_ItemClicked
        private void contextMenuStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            contextMenuStrip2.Visible = false;

            switch (e.ClickedItem.Name)
            {
                case "toolStripButton_AddItem":
                case "ToolStripMenuItem_AddItems":
                    if (feePhaseTDataGridView.CurrentRow != null)
                    {
                        AddFrom.AddFeePhaseItem add = new LawtechPTSystem.AddFrom.AddFeePhaseItem();
                        add.TypeMode = 2;
                        add.FeePhaseID = (int)feePhaseTDataGridView.CurrentRow.Cells["FeePhaseID"].Value;
                        add.ShowDialog();
                    }
                    break;
                case "toolStripButton_DelItem":
                case "ToolStripMenuItem_DelItem":
                    if (feePhaseItemsTDataGridView.CurrentRow != null)
                    {
                        string sName = feePhaseItemsTDataGridView.CurrentRow.Cells["FeePhaseItem"].Value.ToString();
                        if (MessageBox.Show("是否確定刪除【" + sName + "】", "確認視窗", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            int iKey = (int)feePhaseItemsTDataGridView.CurrentRow.Cells["FeePhaseDetailKey"].Value;

                            Public.CFeePhaseItems PatFeePhaseItems = new Public.CFeePhaseItems();
                            Public.CFeePhaseItems.ReadOne(iKey, ref PatFeePhaseItems);

                            //刪除記錄檔    
                            Public.CSystemLogT log = new Public.CSystemLogT();
                            log.DelTime = DateTime.Now;
                            log.DelWorkerKey = Properties.Settings.Default.WorkerKEY;
                            log.DelWorker = Properties.Settings.Default.WorkerName;
                            log.DelContent = string.Format("費用明細:{0}", PatFeePhaseItems.FeePhaseItem);
                            log.DelTitle = string.Format("刪除「{0}」資料【{1}】", this.Text, PatFeePhaseItems.FeePhaseItem);
                            log.Create();


                            PatFeePhaseItems.Delete();
                            feePhaseItemsTDataGridView.Rows.Remove(feePhaseItemsTDataGridView.CurrentRow);
                            MessageBox.Show("刪除成功");
                        }
                    }
                    break;
            }
        }
        #endregion

        #region feePhaseTDataGridView_SelectionChanged
        private void feePhaseTDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (feePhaseTDataGridView.CurrentRow != null)
            {
                this.feePhaseItemsTTableAdapter.FillByFeePhase(this.qS_DataSet.FeePhaseItemsT, (int)feePhaseTDataGridView.CurrentRow.Cells["FeePhaseID"].Value);

                tagTitle2.TitleLableText = feePhaseTDataGridView.CurrentRow.Cells["FeePhase"].Value.ToString() + " 對應的費用內容";
            }
            else
            {
                this.feePhaseItemsTTableAdapter.FillByFeePhase(this.qS_DataSet.FeePhaseItemsT, -1);
                tagTitle2.TitleLableText = "對應的費用內容";
            }
        }
        #endregion

        private void TrademarkFeePhase_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt)
            {
                if (e.KeyCode == Keys.E)
                {
                    but_MoneyList_Click(null, null);
                }
            }
        }

    }
}
