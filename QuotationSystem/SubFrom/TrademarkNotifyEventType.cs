using System;
using System.Data;
using System.Windows.Forms;

namespace LawtechPTSystem.SubFrom
{
    /// <summary>
    /// 商標--事件種類
    /// </summary>
    public partial class TrademarkNotifyEventType : Form
    {
        UserPermissionForm myPermission;
        private const string ProgramSymbol = "TrademarkNotifyEventType";
        private const string SourceTableName = "TrademarkNotifyEventTypeT";

        public TrademarkNotifyEventType()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;
            Public.DynamicGridViewColumn.GetGridColum(ref dataGridView1);
        }

        public DataTable GetTMNotifyEvnetTypeT
        {
            get { return this.dataSet_TM.TrademarkNotifyEventTypeT; }
        }

        public void upDataSet()
        {
            this.dataSet_TM.TrademarkNotifyEventTypeT.Clear();
            this.trademarkNotifyEventTypeTTableAdapter.Fill(this.dataSet_TM.TrademarkNotifyEventTypeT);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TrademarkNotifyEventType_Load(object sender, EventArgs e)
        {
            Public.PublicForm Forms = new Public.PublicForm();
            Forms.TrademarkNotifyEventType = this;

            //取得權限
            myPermission = new UserPermissionForm(Properties.Settings.Default.WorkerKEY, ProgramSymbol);

            System.Windows.Forms.BindingNavigator[] listbinding = { bindingNavigator1 };
            System.Windows.Forms.ContextMenuStrip[] listtMenu = { contextMenuStrip1 };

            //確認可使用的功能選單
            Public.CommonFunctions.CheckMeunItemVisible(listbinding, myPermission.UserPermission);
            Public.CommonFunctions.CheckMeunItemVisible(listtMenu, myPermission.UserPermission);

            this.trademarkNotifyEventTypeTTableAdapter.Fill(this.dataSet_TM.TrademarkNotifyEventTypeT);

            this.dataSet_TM.TrademarkNotifyEventTypeT.ColumnChanged += new DataColumnChangeEventHandler(TrademarkNotifyEventTypeT_ColumnChanged);

        }

        #region  =============TrademarkNotifyEventTypeT_ColumnChanged事件===============
        private void TrademarkNotifyEventTypeT_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            if (e.Row.RowState == DataRowState.Unchanged)
            {

                Public.CTrademarkNotifyEventType CA_CTrademarkNotifyEventType = new Public.CTrademarkNotifyEventType();
                Public.CTrademarkNotifyEventType.ReadOne(int.Parse(e.Row["TMNotifyEventTypeID"].ToString()), ref CA_CTrademarkNotifyEventType);
                
                switch (e.Column.ColumnName)
                {
                    case "Sort":
                        CA_CTrademarkNotifyEventType.Sort = e.ProposedValue != DBNull.Value ? (int)e.ProposedValue : -1;
                        break;
                    case "NotifyEventTypeName":
                        CA_CTrademarkNotifyEventType.NotifyEventTypeName = e.ProposedValue != null ? e.ProposedValue.ToString() : "";
                        break;
                }
                CA_CTrademarkNotifyEventType.Update();
                this.dataSet_TM.TrademarkNotifyEventTypeT.AcceptChanges();
            }
        }
        #endregion

        private void TrademarkNotifyEventType_FormClosed(object sender, FormClosedEventArgs e)
        {
            Public.PublicForm Forms = new Public.PublicForm();
            Forms.TrademarkNotifyEventType = null;
        }

        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            contextMenuStrip1.Visible = false;
            switch (e.ClickedItem.Name)
            {
                case "toolStripButton_Add":
                case "AddToolStripMenuItem":
                    AddFrom.AddTrademarkNotifyEventType add = new AddFrom.AddTrademarkNotifyEventType();

                    add.ShowDialog();

                    break;

                case "toolStripButton_del":
                case "DelToolStripMenuItem":
                    if (dataGridView1.CurrentRow != null)
                    {
                        string strName = dataGridView1.CurrentRow.Cells["NotifyEventTypeName"].Value.ToString();
                        if (MessageBox.Show("是否確定刪除【" + strName + "】", "確認視窗", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            int ikey = (int)dataGridView1.CurrentRow.Cells["TMNotifyEventTypeID"].Value;
                            Public.CTrademarkNotifyEventType TMType = new Public.CTrademarkNotifyEventType();
                            Public.CTrademarkNotifyEventType.ReadOne(ikey, ref TMType);
                            //刪除記錄檔    
                            Public.CSystemLogT log = new Public.CSystemLogT();
                            log.DelTime = DateTime.Now;
                            log.DelWorkerKey = Properties.Settings.Default.WorkerKEY;
                            log.DelWorker = Properties.Settings.Default.WorkerName;
                            log.DelContent = string.Format("事件種類:{0}", TMType.NotifyEventTypeName);
                            log.DelTitle = string.Format("刪除「{0}」資料【{1}】", this.Text, TMType.NotifyEventTypeName);
                            log.Create();

                            TMType.Delete();
                            dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
                            MessageBox.Show("刪除成功");
                        }
                    }
                    break;

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
