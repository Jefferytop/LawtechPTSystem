using System;
using System.Data;
using System.Windows.Forms;

namespace LawtechPTSystem.SubFrom
{
    public partial class PhaseMF : Form
    {

        UserPermissionForm myPermission;
        private const string ProgramSymbol = "QPForm";
        private const string SourceTableName = "nTriffT";


        public PhaseMF()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;
            Public.DynamicGridViewColumn.GetGridColum(ref dataGridView1);
        }

        #region  private void PhaseMF_Load(object sender, EventArgs e)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PhaseMF_Load(object sender, EventArgs e)
        {
            //取得權限
            myPermission = new UserPermissionForm(Properties.Settings.Default.WorkerKEY, ProgramSymbol);

            //確認可使用的功能選單
            Public.CommonFunctions.CheckMeunItemVisible(contextMenuStrip1, myPermission.UserPermission);
            Public.CommonFunctions.CheckMeunItemVisible(bindingNavigator1, myPermission.UserPermission);

            LoadData();

            this.dataSet_Triff.PhaseT.ColumnChanged += new DataColumnChangeEventHandler(PhaseT_ColumnChanged);
        } 
        #endregion

        #region  =============PhaseT_ColumnChanged事件===============
        private void PhaseT_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            if (e.Row.RowState == DataRowState.Unchanged)
            {
                Public.CPhase CA_CPhase = new Public.CPhase();
                Public.CPhase.ReadOne(int.Parse(e.Row["PhaseKey"].ToString()), ref CA_CPhase);

                switch (e.Column.ColumnName)
                {
                    case "PhaseName":
                        CA_CPhase.PhaseName = e.ProposedValue != null ? e.ProposedValue.ToString() : "";
                        break;                   
                    case "Sort":
                        CA_CPhase.Sort = e.ProposedValue != DBNull.Value ? (int)e.ProposedValue : -1;
                        break;
                }
                CA_CPhase.Update();
                this.dataSet_Triff.PhaseT.AcceptChanges();
            }
        }
        #endregion

        #region ============LoadData===============
        /// <summary>
        /// 繫結所屬階段資料
        /// </summary>
        public void LoadData()
        {
            this.dataSet_Triff.PhaseT.Clear();
            //資料讀取
            this.phaseTTableAdapter.Fill(this.dataSet_Triff.PhaseT);

        }
        #endregion

        #region 關閉按鈕 private void btn_Close_Click(object sender, EventArgs e)
        /// <summary>
        /// 關閉按鈕
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        } 
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bindingNavigator1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (contextMenuStrip1.Visible)
            {
                contextMenuStrip1.Visible = false;
            }
            switch (e.ClickedItem.Name)
            {
                case "toolStripButton_Add":
                case "ToolStripMenuItem_Add":
                    AddFrom.AddPhase add = new AddFrom.AddPhase();
                    DialogResult DResult = add.ShowDialog();
                    if (DResult == DialogResult.OK)
                    {
                        LoadData();
                    }
                    break;
                case "toolStripButton_Del":
                case "ToolStripMenuItem_Del":
                    if (dataGridView1.CurrentRow != null)
                    {
                        string sName = dataGridView1.CurrentRow.Cells["PhaseName"].Value.ToString();

                        if (MessageBox.Show("是否確定刪除 【" + sName + "】", "確認視窗", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            int iKey = (int)dataGridView1.CurrentRow.Cells["PhaseKey"].Value;
                            Public.CPhase cphase = new Public.CPhase();
                            Public.CPhase.ReadOne(iKey, ref cphase);

                            //刪除記錄檔    
                            Public.CSystemLogT log = new Public.CSystemLogT();
                            log.DelTime = DateTime.Now;
                            log.DelWorkerKey = Properties.Settings.Default.WorkerKEY;
                            log.DelWorker = Properties.Settings.Default.WorkerName;
                            //string[] str = PatStatus.GetInsertString(iKey);
                            //log.TableName = str[2];
                            //log.DelContent_InsertColumn = str[0];
                            //log.DelContent_InsertSQL = str[1];
                            log.DelContent = string.Format("所屬階段:{0}", cphase.PhaseName);
                            log.DelTitle = string.Format("刪除所屬階段資料【{0}】", cphase.PhaseName);
                            log.Create();

                            cphase.Delete();

                            dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
                            MessageBox.Show("刪除成功");
                        }
                    }
                    break;
            }
        }

        private void but_Update_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
