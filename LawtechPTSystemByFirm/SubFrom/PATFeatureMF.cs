using System;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LawtechPTSystemByFirm.SubFrom
{
    /// <summary>
    /// 專利--案件性質設定
    /// </summary>
    public partial class PATFeatureMF : Form
    {
        UserPermissionForm myPermission;
        private const string strProgramSymbol = "PATFeatureMF";
        private const string SourceTableName = "PATFeatureT";

        public PATFeatureMF()
        {
            InitializeComponent();
            Public.DynamicGridViewColumn.GetGridColum(ref pATFeatureTDataGridView);
        }

        public DataTable GetPATFeatureT
        {
            get { return this.qS_DataSet.PATFeatureT; }
        }

        #region private void PATFeatureMF_Load(object sender, EventArgs e)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PATFeatureMF_Load(object sender, EventArgs e)
        {
            Public.PublicForm Forms = new LawtechPTSystemByFirm.Public.PublicForm();
            Forms.PATFeatureMF = this;

            //取得權限
            myPermission = new UserPermissionForm(Properties.Settings.Default.WorkerKEY, strProgramSymbol);

            System.Windows.Forms.BindingNavigator[] listbinding = { bindingNavigator1 };
            System.Windows.Forms.ContextMenuStrip[] listtMenu = { contextMenuStrip1 };

            //確認可使用的功能選單
            Public.CommonFunctions.CheckMeunItemVisible(listbinding, myPermission.UserPermission);
            Public.CommonFunctions.CheckMeunItemVisible(listtMenu, myPermission.UserPermission);

            this.pATFeatureTTableAdapter.FillPatFeature(this.qS_DataSet.PATFeatureT);

            this.qS_DataSet.PATFeatureT.ColumnChanged += new DataColumnChangeEventHandler(PATFeatureT_ColumnChanged);
        } 
        #endregion

        public void upDataSet()
        {
            this.qS_DataSet.PATFeatureT.Clear();
            this.pATFeatureTTableAdapter.FillPatFeature(this.qS_DataSet.PATFeatureT);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region 表單關閉事件 private void PATFeatureMF_FormClosed(object sender, FormClosedEventArgs e)
        /// <summary>
        /// 表單關閉事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PATFeatureMF_FormClosed(object sender, FormClosedEventArgs e)
        {
            Public.PublicForm Forms = new LawtechPTSystemByFirm.Public.PublicForm();
            Forms.PATFeatureMF = null;
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
                case "toolStripButton_Add":
                case "AddToolStripMenuItem":
                    AddFrom.AddPatFeature add = new AddFrom.AddPatFeature();

                    add.ShowDialog();

                    break;
                case "toolStripButton_Delete":
                case "DelToolStripMenuItem":
                    if (pATFeatureTDataGridView.CurrentRow != null)
                    {
                        string sName = pATFeatureTDataGridView.CurrentRow.Cells["FeatureName"].Value.ToString();
                        if (MessageBox.Show("是否確定刪除--" + sName, "確認視窗", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            int iKey = (int)pATFeatureTDataGridView.CurrentRow.Cells["FeatureID"].Value;
                            Public.CPATFeature PatStatus = new Public.CPATFeature();
                            PatStatus.FeatureID = iKey;

                            //刪除記錄檔    
                            Public.CSystemLog log = new LawtechPTSystemByFirm.Public.CSystemLog();
                            log.DelTime = DateTime.Now;
                            log.DelWorkerKey = Properties.Settings.Default.WorkerKEY;
                            
                            log.DelContent = string.Format("案件性質:{0}", PatStatus.FeatureName);
                            log.DelTitle = string.Format("刪除專利案件性質設定檔資料【{0}】", PatStatus.FeatureName);
                            log.Create();


                            PatStatus.Delete(iKey);
                            pATFeatureTDataGridView.Rows.Remove(pATFeatureTDataGridView.CurrentRow);
                            MessageBox.Show("刪除成功");
                        }
                    }
                    break;
                case "toolStripButton_Export":
                    try
                    {
                        Public.DLL dll = new LawtechPTSystemByFirm.Public.DLL();
                        Task T= dll.WriteToCSV(pATFeatureTDataGridView);

                    }
                    catch
                    {
                        MessageBox.Show("匯出CSV失敗");
                    }
                    break;
            }
        } 
        #endregion

        #region  =============PATFeatureT_ColumnChanged事件===============
        private void PATFeatureT_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            if (e.Row.RowState == DataRowState.Unchanged)
            {

                Public.CPATFeature CA_CPATFeature = new Public.CPATFeature();
                Public.CPATFeature.ReadOne(int.Parse(e.Row["FeatureID"].ToString()),ref CA_CPATFeature);
               
                switch (e.Column.ColumnName)
                {
                    case "FeatureName":
                        CA_CPATFeature.FeatureName = e.ProposedValue != null ? e.ProposedValue.ToString() : "";
                        break;
                    case "Sort":
                        CA_CPATFeature.Sort = e.ProposedValue != DBNull.Value ? (int)e.ProposedValue : -1;
                        break;
                    case "bStop":
                        CA_CPATFeature.bStop = e.ProposedValue != DBNull.Value ? (bool)e.ProposedValue : false;
                        break;
                }
                CA_CPATFeature.Update();
                this.qS_DataSet.PATFeatureT.AcceptChanges();
            }
        }
        #endregion

        #region 刷新按鈕 private void but_Update_Click(object sender, EventArgs e)
        /// <summary>
        /// 刷新按鈕
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void but_Update_Click(object sender, EventArgs e)
        {
            but_Update.Enabled = false;
            if (this.qS_DataSet.PATFeatureT.Rows.Count > 0)
            {
                this.qS_DataSet.PATFeatureT.Rows.Clear();
            }
            this.pATFeatureTTableAdapter.FillPatFeature(this.qS_DataSet.PATFeatureT);
            but_Update.Enabled = true;
        } 
        #endregion
    }
}