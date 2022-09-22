using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace LawtechPTSystem.SubFrom
{
    /// <summary>
    /// 商標--案件類別設定
    /// </summary>
    public partial class TMTypeMF : Form
    {
        UserPermissionForm myPermission;
        private const string ProgramSymbol = "TMTypeMF";
        private const string SourceTableName = "TrademarkTypeT";

        public TMTypeMF()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;

            Dictionary<string, BindingSource> lists = new Dictionary<string, BindingSource>() { { "trademarkTypeModeBindingSource", trademarkTypeModeBindingSource } };
            Public.DynamicGridViewColumn.GetGridColum(ref dataGridView1, lists);
        }

          public DataTable GetTMTypeT
        {
            get { return this.dataSet_TM.TrademarkTypeT; }
        }

        public void upDataSet()
        {
            this.dataSet_TM.TrademarkTypeT.Clear();
            this.trademarkTypeTTableAdapter.Fill(this.dataSet_TM.TrademarkTypeT);
        }
      

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TMTypeMF_Load(object sender, EventArgs e)
        {          
          
            Public.PublicForm Forms = new Public.PublicForm();
            Forms.TMTypeMF = this;

            //取得權限
            myPermission = new UserPermissionForm(Properties.Settings.Default.WorkerKEY, ProgramSymbol);

            System.Windows.Forms.BindingNavigator[] listbinding = { bindingNavigator1 };
            System.Windows.Forms.ContextMenuStrip[] listtMenu = { contextMenuStrip1 };

            //確認可使用的功能選單
            Public.CommonFunctions.CheckMeunItemVisible(listbinding, myPermission.UserPermission);
            Public.CommonFunctions.CheckMeunItemVisible(listtMenu, myPermission.UserPermission);

            this.trademarkTypeModeTableAdapter.Fill(this.dataSet_TM.TrademarkTypeMode);

            this.trademarkTypeTTableAdapter.Fill(this.dataSet_TM.TrademarkTypeT);

            this.dataSet_TM.TrademarkTypeT.ColumnChanged += new DataColumnChangeEventHandler(TrademarkTypeT_ColumnChanged);
        }

        #region  =============TrademarkTypeT_ColumnChanged事件===============
        private void TrademarkTypeT_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            if (e.Row.RowState == DataRowState.Unchanged)
            {
                Public.CTrademarkType CA_CTrademarkType = new Public.CTrademarkType();
                Public.CTrademarkType.ReadOne(int.Parse(e.Row["TMTypeID"].ToString()),ref CA_CTrademarkType);
                
                switch (e.Column.ColumnName)
                {
                    case "Sort":
                        CA_CTrademarkType.Sort = e.ProposedValue != DBNull.Value ? (int)e.ProposedValue : -1;
                        break;
                    case "TMTypeName":
                        CA_CTrademarkType.TMTypeName = e.ProposedValue != null ? e.ProposedValue.ToString() : "";
                        break;
                    case "TypeMode":
                        CA_CTrademarkType.TypeMode = e.ProposedValue != DBNull.Value ? (int)e.ProposedValue : -1;
                        break;
                }

                CA_CTrademarkType.Update();

                this.dataSet_TM.TrademarkTypeT.AcceptChanges();
            }
        }
        #endregion

        private void TMTypeMF_FormClosed(object sender, FormClosedEventArgs e)
        {
            Public.PublicForm Forms = new Public.PublicForm();
            Forms.TMTypeMF = null;
        }

        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            contextMenuStrip1.Visible = false;

            switch (e.ClickedItem.Name)
            {
                case "toolStripButton_Add":
                case "AddToolStripMenuItem":

                    AddFrom.AddTrademarkType add = new AddFrom.AddTrademarkType();

                    add.ShowDialog();

                    break;
                case "toolStripButton_del":
                case "DelToolStripMenuItem":
                    if (dataGridView1.CurrentRow != null)
                    {
                        string strName = dataGridView1.CurrentRow.Cells["TMTypeName"].Value.ToString();

                        if (MessageBox.Show("是否確定刪除【" + strName + "】", "確認視窗", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            int iKey = (int)dataGridView1.CurrentRow.Cells["TMTypeID"].Value;

                            Public.CTrademarkType TMType = new Public.CTrademarkType();
                            Public.CTrademarkType.ReadOne(iKey, ref TMType);                           

                            //刪除記錄檔    
                            Public.CSystemLogT log = new Public.CSystemLogT();
                            log.DelTime = DateTime.Now;
                            log.DelWorkerKey = Properties.Settings.Default.WorkerKEY;
                            log.DelWorker = Properties.Settings.Default.WorkerName;
                          
                            log.DelContent = string.Format("類型:{0}\r\n案件類別:{1}", dataGridView1.CurrentRow.Cells["TypeMode"].FormattedValue.ToString(), TMType.TMTypeName);
                            log.DelTitle = string.Format("刪除「{0}」資料【{1}】", this.Text,TMType.TMTypeName);
                            log.Create();

                            TMType.Delete();

                            dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
                            MessageBox.Show("刪除成功");
                        }
                    }
                    break;

            }
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = false;
        }
    }
}