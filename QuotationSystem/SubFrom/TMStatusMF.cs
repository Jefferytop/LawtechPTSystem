using System;
using System.Data;
using System.Windows.Forms;

namespace LawtechPTSystem.SubFrom
{
    /// <summary>
    /// 商標--案件階段設定
    /// </summary>
    public partial class TMStatusMF : Form
    {
        UserPermissionForm myPermission;
        private const string ProgramSymbol = "TMStatusMF";
        private const string SourceTableName = "TMStatusT";

        public TMStatusMF()
        {
            InitializeComponent();

            TMStatusTDataGridView.AutoGenerateColumns = false;
            Public.DynamicGridViewColumn.GetGridColum(ref TMStatusTDataGridView);
        }

        public DataTable GetTMStatusT
        {
            get { return this.dataSet_TM.TMStatusT; }
        }

        public void upDataSet()
        {
            this.dataSet_TM.TMStatusT.Clear();
            this.tMStatusTTableAdapter.Fill(this.dataSet_TM.TMStatusT);
        }

        private void TMStatusMF_Load(object sender, EventArgs e)
        {           
          
            Public.PublicForm Forms = new Public.PublicForm();
            Forms.TMStatusMF = this;

            //取得權限
            myPermission = new UserPermissionForm(Properties.Settings.Default.WorkerKEY, ProgramSymbol);

            System.Windows.Forms.BindingNavigator[] listbinding = { bindingNavigator1 };
            System.Windows.Forms.ContextMenuStrip[] listtMenu = { contextMenuStrip1 };

            //確認可使用的功能選單
            Public.CommonFunctions.CheckMeunItemVisible(listbinding, myPermission.UserPermission);
            Public.CommonFunctions.CheckMeunItemVisible(listtMenu, myPermission.UserPermission);

            this.tMStatusTTableAdapter.FillByALL(this.dataSet_TM.TMStatusT);

            this.dataSet_TM.TMStatusT.ColumnChanged += new DataColumnChangeEventHandler(TMStatusT_ColumnChanged);
        }

        private void TMStatusMF_FormClosed(object sender, FormClosedEventArgs e)
        {
            Public.PublicForm Forms = new Public.PublicForm();
            Forms.TMStatusMF = null;
        }

        #region  =============TMStatusT_ColumnChanged事件===============
        private void TMStatusT_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            if (e.Row.RowState == DataRowState.Unchanged)
            {

                Public.CTMStatus CA_CTMStatus = new Public.CTMStatus();
                Public.CTMStatus.ReadOne(int.Parse(e.Row["TMStatusID"].ToString()), ref CA_CTMStatus);
               
                switch (e.Column.ColumnName)
                {
                    case "Status":
                        CA_CTMStatus.Status = e.ProposedValue != null ? e.ProposedValue.ToString() : "";
                        break;
                    case "Sort":
                        CA_CTMStatus.Sort = e.ProposedValue != DBNull.Value ? (int)e.ProposedValue : -1;
                        break;
                    case "bStop":
                        CA_CTMStatus.bStop = e.ProposedValue != DBNull.Value ? (bool)e.ProposedValue : false;
                        break;
                }
                CA_CTMStatus.Update();
                this.dataSet_TM.TMStatusT.AcceptChanges();
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
                    AddFrom.AddTMStatus add = new AddFrom.AddTMStatus();

                    add.ShowDialog();

                    break;

                case "toolStripButton_del":
                case "DelToolStripMenuItem":
                    if (TMStatusTDataGridView.CurrentRow != null)
                    {
                        string strName = TMStatusTDataGridView.CurrentRow.Cells["Status"].Value.ToString();

                        if (MessageBox.Show("是否確定刪除【" + strName + "】", "確認視窗", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            int iKey = (int)TMStatusTDataGridView.CurrentRow.Cells["TMStatusID"].Value;
                            Public.CTMStatus TMStatus = new Public.CTMStatus();
                            Public.CTMStatus.ReadOne(iKey, ref TMStatus);

                            //刪除記錄檔    
                            Public.CSystemLogT log = new Public.CSystemLogT();
                            log.DelTime = DateTime.Now;
                            log.DelWorkerKey = Properties.Settings.Default.WorkerKEY;
                            log.DelWorker = Properties.Settings.Default.WorkerName;                        
                            log.DelContent = string.Format("案件階段:{0}", TMStatus.Status);
                            log.DelTitle = string.Format("刪除「{0}」資料【{1}】", this.Text,TMStatus.Status);
                            log.Create();


                            TMStatus.Delete(iKey);
                            TMStatusTDataGridView.Rows.Remove(TMStatusTDataGridView.CurrentRow);
                            MessageBox.Show("刪除成功");
                        }
                    }
                    break;

            }
        }
        #endregion

    }
}