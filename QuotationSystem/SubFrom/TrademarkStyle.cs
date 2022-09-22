using System;
using System.Data;
using System.Windows.Forms;

namespace LawtechPTSystem.SubFrom
{
    /// <summary>
    /// 商標式樣設定
    /// </summary>
    public partial class TrademarkStyle : Form
    {
        UserPermissionForm myPermission;
        private const string ProgramSymbol = "TrademarkStyle";
        private const string SourceTableName = "TrademarkStyleT";

        public TrademarkStyle()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;
            Public.DynamicGridViewColumn.GetGridColum(ref dataGridView1);
        }

        public DataTable GetTMStyleT
        {
            get { return this.dataSet_TM.TrademarkStyleT; }
        }

        public void upDataSet()
        {
            this.dataSet_TM.TrademarkStyleT.Clear();
            this.trademarkStyleTTableAdapter.Fill(this.dataSet_TM.TrademarkStyleT);
        }

        #region TrademarkStyle_Load
        private void TrademarkStyle_Load(object sender, EventArgs e)
        {
            Public.PublicForm Froms = new Public.PublicForm();
            Froms.TrademarkStyle = this;

            //取得權限
            myPermission = new UserPermissionForm(Properties.Settings.Default.WorkerKEY, ProgramSymbol);

            System.Windows.Forms.BindingNavigator[] listbinding = { bindingNavigator1 };
            System.Windows.Forms.ContextMenuStrip[] listtMenu = { contextMenuStrip1};

            //確認可使用的功能選單
            Public.CommonFunctions.CheckMeunItemVisible(listbinding, myPermission.UserPermission);
            Public.CommonFunctions.CheckMeunItemVisible(listtMenu, myPermission.UserPermission);

            this.trademarkStyleTTableAdapter.Fill(this.dataSet_TM.TrademarkStyleT);

            this.dataSet_TM.TrademarkStyleT.ColumnChanged += new DataColumnChangeEventHandler(TrademarkStyleT_ColumnChanged);
        }

        private void TrademarkStyle_FormClosed(object sender, FormClosedEventArgs e)
        {
            Public.PublicForm Froms = new Public.PublicForm();
            Froms.TrademarkStyle = null;
        }
        #endregion

        #region  =============TrademarkStyleT_ColumnChanged事件===============
        private void TrademarkStyleT_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            if (e.Row.RowState == DataRowState.Unchanged)
            {

                Public.CTrademarkStyle CA_CTrademarkStyle = new Public.CTrademarkStyle();
                Public.CTrademarkStyle.ReadOne(int.Parse(e.Row["TMStyleID"].ToString()), ref CA_CTrademarkStyle);
                
                switch (e.Column.ColumnName)
                {                 
                    case "Sort":
                        CA_CTrademarkStyle.Sort = e.ProposedValue != DBNull.Value ? (int)e.ProposedValue : -1;
                        break;
                    case "StyleName":
                        CA_CTrademarkStyle.StyleName = e.ProposedValue != null ? e.ProposedValue.ToString() : "";
                        break;
                }
                CA_CTrademarkStyle.Update();
                this.dataSet_TM.TrademarkStyleT.AcceptChanges();
            }
        }
        #endregion

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
                    AddFrom.AddTMStyle add = new AddFrom.AddTMStyle();

                    add.ShowDialog();

                    break;

                case "toolStripButton_del":
                case "DelToolStripMenuItem":
                    if (dataGridView1.CurrentRow != null)
                    {
                        string strName = dataGridView1.CurrentRow.Cells["StyleName"].Value.ToString();

                        if (MessageBox.Show("是否確定刪除【" + strName + "】", "確認視窗", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {

                            int iKey = (int)dataGridView1.CurrentRow.Cells["TMStyleID"].Value;
                            Public.CTrademarkStyle TMType = new Public.CTrademarkStyle();
                            Public.CTrademarkStyle.ReadOne(iKey,ref TMType);                           

                            //刪除記錄檔    
                            Public.CSystemLogT log = new Public.CSystemLogT();
                            log.DelTime = DateTime.Now;
                            log.DelWorkerKey = Properties.Settings.Default.WorkerKEY;
                            log.DelWorker = Properties.Settings.Default.WorkerName;                         
                            log.DelContent = string.Format("商標樣式:{0}", TMType.StyleName);
                            log.DelTitle = string.Format("刪除「{0}」資料【{1}】", this.Text,TMType.StyleName);
                            log.Create();


                            TMType.Delete();
                            dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
                            MessageBox.Show("刪除成功");
                        }
                    }
                    break;

            }
        }
        #endregion

        private void but_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
