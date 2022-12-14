using System;
using System.Data;
using System.Windows.Forms;

namespace LawtechPTSystemByFirm.SubFrom
{
    /// <summary>
    /// 費用內容設定
    /// </summary>
    public partial class PatFeePhase : Form
    {
        UserPermissionForm myPermission;
        private const string strProgramSymbol = "PatFeePhase";
        private const string SourceTableName = "FeePhaseT";

        int iType = 1;//1.Pat 2.TM
        
        public PatFeePhase()
        {
            InitializeComponent();
            feePhaseTDataGridView.AutoGenerateColumns = false;
            feePhaseItemsTDataGridView.AutoGenerateColumns = false;
            Public.DynamicGridViewColumn.GetGridColum(ref feePhaseTDataGridView);
            Public.DynamicGridViewColumn.GetGridColum(ref feePhaseItemsTDataGridView);
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

        private void but_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region PatFeePhase_Load PatFeePhase_FormClosed
        private void PatFeePhase_Load(object sender, EventArgs e)
        {

            Public.PublicForm Forms = new LawtechPTSystemByFirm.Public.PublicForm();
            Forms.PatFeePhase = this;

            //取得權限
            myPermission = new UserPermissionForm(Properties.Settings.Default.WorkerKEY, strProgramSymbol);

            System.Windows.Forms.BindingNavigator[] listbinding = { feePhaseTBindingNavigator ,bindingNavigator1 };
            System.Windows.Forms.ContextMenuStrip[] listtMenu = { contextMenuStrip1, contextMenuStrip2 };

            //確認可使用的功能選單
            Public.CommonFunctions.CheckMeunItemVisible(listbinding, myPermission.UserPermission);
            Public.CommonFunctions.CheckMeunItemVisible(listtMenu, myPermission.UserPermission);



            feePhaseTTableAdapter.Fill(this.qS_DataSet.FeePhaseT, iType);

            this.qS_DataSet.FeePhaseT.ColumnChanged += new DataColumnChangeEventHandler(FeePhaseT_ColumnChanged);
            this.qS_DataSet.FeePhaseItemsT.ColumnChanged += new DataColumnChangeEventHandler(FeePhaseItemsT_ColumnChanged);
        }

        private void PatFeePhase_FormClosed(object sender, FormClosedEventArgs e)
        {
            Public.PublicForm Forms = new LawtechPTSystemByFirm.Public.PublicForm();
            Forms.PatFeePhase = null;
        }
        #endregion

        #region  =============FeePhaseT_ColumnChanged事件===============
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                Public.CFeePhaseItems.ReadOne(int.Parse(e.Row["FeePhaseDetailKey"].ToString()), ref CA_CFeePhaseItems);
               
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
                    add.Text = "新增專利費用種類";
                    add.ShowDialog();

                    break;
                case "toolStripButton_Del":
                case "DelToolStripMenuItem":
                    if (feePhaseTDataGridView.CurrentRow != null)
                    {
                        string sName = feePhaseTDataGridView.CurrentRow.Cells["FeePhase"].Value.ToString();
                        if (MessageBox.Show("是否確定刪除【" + sName + "】", "確認視窗", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            int iKey = (int)feePhaseTDataGridView.CurrentRow.Cells["FeePhaseID"].Value;
                            Public.CFeePhase PatStatus = new Public.CFeePhase();
                            PatStatus.FeePhaseID = iKey; 
                            PatStatus.Delete(iKey);

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
                        AddFrom.AddFeePhaseItem add = new LawtechPTSystemByFirm.AddFrom.AddFeePhaseItem();
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
                            PatFeePhaseItems.FeePhaseDetailKey=iKey;
                            
                            PatFeePhaseItems.Delete(iKey);
                            feePhaseItemsTDataGridView.Rows.Remove(feePhaseItemsTDataGridView.CurrentRow);
                            MessageBox.Show("刪除成功");
                        }
                    }
                    break;
            }
        }
        #endregion

        private void PatFeePhase_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt)
            {
                if (e.KeyCode == Keys.E)
                {
                    but_MoneyList_Click(null, null);
                }
            }
        }

        private void but_Update_Click(object sender, EventArgs e)
        {
            but_Update.Enabled = false;
            feePhaseTTableAdapter.Fill(this.qS_DataSet.FeePhaseT, iType);
            but_Update.Enabled = true;
        }

    }
}