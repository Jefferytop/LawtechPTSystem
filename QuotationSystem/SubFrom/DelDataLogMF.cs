using H3Operator.DBHelper;
using System;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LawtechPTSystem.SubFrom
{
    /// <summary>
    /// 刪除記錄檔
    /// </summary>
    public partial class DelDataLogMF : Form
    {
        UserPermissionForm myPermission;
        private const string ProgramSymbol = "DelDataLogMF";
        private const string SourceTableName = "SystemLogT";

        private DataTable dt_SystemLogT = new DataTable();
        public DataTable DT_SystemLogT
        {
            get; set;
        }

        public DelDataLogMF()
        {
            InitializeComponent();
            Public.DynamicGridViewColumn.GetGridColum(ref systemLogTDataGridView);
        }

        #region but_Search_Click
        private void but_Search_Click(object sender, EventArgs e)
        {
            but_Search.Enabled = false;

            string strSQLWhere = Public.CommonFunctions.GetSQLScript(QueryFilter1, QueryFilter2, Radio_and.Checked ? " and " : " or ");
            GetDelLog(strSQLWhere);

            systemLogTBindingSource.DataSource = dt_SystemLogT;
            systemLogTDataGridView.DataSource = systemLogTBindingSource;

            but_Search.Enabled = true;
        }
        #endregion

        #region GetDelLog 取得刪除歷史記錄的資料
        /// <summary>
        /// 取得刪除歷史記錄的資料
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public void GetDelLog(string strWhere)
        {
            if (dt_SystemLogT.Rows.Count > 0)
            {
                dt_SystemLogT.Rows.Clear();
            }


            string strPatentFeeSQL = string.Format(
                                    @"
                                      SELECT Top 1000 SysLogID, DelWorkerKey, DelTime, DelTitle, DelContent, TableName, DelWorker, 
                            DelContent_InsertColumn, DelContent_InsertSQL, CreateDateTime, LastModifyDateTime FROM SystemLogT with(nolock) {0} order by DelTime desc
                                      ", strWhere.Trim() != string.Empty ? " where " + strWhere : "");

            DBAccess dll = new DBAccess();
            dll.QueryToDataTableByDataAdapter(strPatentFeeSQL, ref dt_SystemLogT);

        }
        #endregion

        #region but_Close_Click
        private void but_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion 

        #region  DelDataLogMF_Load  DelDataLogMF_FormClosed
        private void DelDataLogMF_Load(object sender, EventArgs e)
        {
            Public.PublicForm Forms = new Public.PublicForm();
            Forms.DelDataLogMF = this;

            //取得權限
            myPermission = new UserPermissionForm(Properties.Settings.Default.WorkerKEY, ProgramSymbol);

            System.Windows.Forms.BindingNavigator[] listbinding = { systemLogTBindingNavigator };
            System.Windows.Forms.ContextMenuStrip[] listtMenu = { contextMenuStrip1 };

            //確認可使用的功能選單
            Public.CommonFunctions.CheckMeunItemVisible(listbinding, myPermission.UserPermission);
            Public.CommonFunctions.CheckMeunItemVisible(listtMenu, myPermission.UserPermission);

            but_Search_Click(null, null);

        }


        private void DelDataLogMF_FormClosed(object sender, FormClosedEventArgs e)
        {
            Public.PublicForm Forms = new Public.PublicForm();
            Forms.DelDataLogMF = null;           

        }

        #endregion

        #region but_Excel_Click
        private void but_Excel_Click(object sender, EventArgs e)
        {
            try
            {
                Public.DLL dll = new Public.DLL();
                Task t = dll.WriteToCSV(systemLogTDataGridView);
            }
            catch
            {
                MessageBox.Show("匯出CSV失敗:匯出過程發生異常被終止");
            }
        }
        #endregion      

        #region systemLogTDataGridView_DataError
        private void systemLogTDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = false;
        }
        #endregion

      

        #region systemLogTDataGridView_CellClick
        private void systemLogTDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != -1 && e.RowIndex != -1)
            {
                if (systemLogTDataGridView.CurrentRow!=null &&  systemLogTDataGridView.Columns[e.ColumnIndex].Name == "But_Record")
                {
                    int Key = (int)systemLogTDataGridView.Rows[e.RowIndex].Cells["SysLogID"].Value;
                    Public.CSystemLogT syslog = new Public.CSystemLogT();
                    Public.CSystemLogT.ReadOne(Key, ref syslog);
                   

                    Public.DLL dll = new Public.DLL();
                    string strInsert = string.Format("insert into {0} ({1}) values({2})",syslog.TableName ,syslog.DelContent_InsertColumn,syslog.DelContent_InsertSQL);
                    try
                    {
                        dll.SQLexecuteNonQuery(strInsert);

                        syslog.Delete(Key);

                        systemLogTDataGridView.Rows.Remove(systemLogTDataGridView.CurrentRow);
                    }
                    catch(SystemException ex)
                    {
                        MessageBox.Show(ex.Message);
                    }

                }
            }
        }
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            contextMenuStrip1.Visible = false;

            switch (e.ClickedItem.Name)
            {
                case "toolStripMenuItem_del":
                case "toolStripButton_Del":
                    if (systemLogTDataGridView.CurrentRow != null)
                    {
                        string strDelTitle = systemLogTDataGridView.CurrentRow.Cells["DelTitle"].Value.ToString();
                        if (MessageBox.Show("是否確定刪除【" + strDelTitle + "】", "確認視窗", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            int iKey = (int)systemLogTDataGridView.CurrentRow.Cells["SysLogID"].Value;
                            Public.CSystemLogT del_Due = new Public.CSystemLogT();
                            del_Due.Delete(iKey);

                            var item = systemLogTDataGridView.CurrentRow;

                            systemLogTDataGridView.Rows.Remove(item);

                            MessageBox.Show("刪除成功", "提示訊息", MessageBoxButtons.OK);
                        }
                    }
                    break;

                case "toolStripMenuItem_del3":
                case "toolStripButton_Del3":
                    if (MessageBox.Show("是否確定刪除3個月以前的資料", "確認視窗", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        Public.CSystemLogT del_Due = new Public.CSystemLogT();
                        del_Due.Delete(" DelTime<DATEADD(month,-3,getdate()) ", "");

                        but_Search_Click(null, null);

                        MessageBox.Show("刪除成功", "提示訊息", MessageBoxButtons.OK);


                    }
                    break;
                case "toolStripButton_ClearAll":
                case "toolStripMenuItem_ClearAll":
                    if (MessageBox.Show("是否確定清空刪除Logs資料", "確認視窗", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        string str = "truncate table SystemLogT";
                        DBAccess db = new DBAccess();
                        object obj=db.ExecuteNonQuery(str);
                        if (obj.ToString() == "0") {
                            but_Search_Click(null, null);
                            MessageBox.Show("清空成功", "提示訊息", MessageBoxButtons.OK);
                        }
                    }
                        break;
            }
        }


    }
}
