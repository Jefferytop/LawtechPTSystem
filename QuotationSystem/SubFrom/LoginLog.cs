using H3Operator.DBHelper;
using System;
using System.Data;
using System.Windows.Forms;

namespace LawtechPTSystem.SubFrom
{
    /// <summary>
    /// 登入記錄檔
    /// </summary>
    public partial class LoginLog : Form
    {
        public LoginLog()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;
            Public.DynamicGridViewColumn.GetGridColum(ref dataGridView1);
        }

        /// <summary>
        /// 取得目前該登入記錄的Key值
        /// </summary>
        public int WorkerLoginKey
        {
            get
            {
                if (dataGridView1.CurrentRow != null)
                {
                    return (int)dataGridView1.CurrentRow.Cells["WorkerLoginKey"].Value;
                }
                else
                {
                    return -1;
                }
            }
        }

        private DataTable dt_WorkerLoginT;
        /// <summary>
        /// 登入記錄資料集
        /// </summary>
        public DataTable DT_WorkerLoginT
        {
            get { return dt_WorkerLoginT; }
            set { dt_WorkerLoginT = value; }
        }

        UserPermissionForm myPermission;
        private const string ProgramSymbol = "LoginLogMF";
        private const string SourceTableName = "WorkerLoginT";

        private void LoginLog_Load(object sender, EventArgs e)
        {
            Public.PublicForm Forms = new Public.PublicForm();
            Forms.LoginLog = this;

            //取得權限
            myPermission = new UserPermissionForm(Properties.Settings.Default.WorkerKEY, ProgramSymbol);

            //確認可使用的功能選單
            Public.CommonFunctions.CheckMeunItemVisible(contextMenuStrip1, myPermission.UserPermission);
            Public.CommonFunctions.CheckMeunItemVisible(bindingNavigator_WorkerLogin, myPermission.UserPermission);

            DB_Models.DB_WorkerLoginTModel del = new DB_Models.DB_WorkerLoginTModel();
            del.Delete("CreateDateTime< dateadd(month,-6,CreateDateTime)","");

            but_Search_Click(null, null);
        }

        private void but_Search_Click(object sender, EventArgs e)
        {
            if (dt_WorkerLoginT != null && dt_WorkerLoginT.Rows.Count > 0)
            {
                dt_WorkerLoginT.Rows.Clear();
            }

            string strSQLWhere = Public.CommonFunctions.GetSQLScript(QueryFilter1, QueryFilter2, Radio_and.Checked ? " and " : " or ");
            dt_WorkerLoginT = GetWorkerLoginT(strSQLWhere);
            bindingSource1.DataSource = dt_WorkerLoginT;
            bindingNavigator_WorkerLogin.BindingSource = bindingSource1;
            dataGridView1.DataSource = bindingSource1;
        }

        #region 取得user 登入記錄 private DataTable GetWorkerLoginT(string strSQL)
        /// <summary>
        /// 取得user 登入記錄
        /// </summary>
        /// <returns></returns>
        private DataTable GetWorkerLoginT(string strSQL)
        {
            Public.DLL dll = new Public.DLL();
            string sql = string.Format(@"SELECT   WorkerLoginT.WorkerLoginKey, WorkerLoginT.WorkerKey, WorkerLoginT.Online, 
                            WorkerLoginT.OnlineTime, WorkerLoginT.OutTime,WorkerLoginT.LoginIP  ,WorkerLoginT.LoginRemark, WorkerLoginT.CreateDateTime, WorkerT.EmployeeName
FROM              WorkerLoginT INNER JOIN
                            WorkerT ON WorkerLoginT.WorkerKey = WorkerT.WorkerKey
{0}
order by WorkerLoginT.WorkerLoginKey desc ", string.IsNullOrEmpty(strSQL.Trim()) ? "" : "where " + strSQL);


            DataTable dt = dll.SqlDataAdapterDataTable(sql);
            dt.PrimaryKey = new DataColumn[1] { dt.Columns["WorkerLoginKey"] };


            return dt;
        } 
        #endregion

        #region  private void but_Close_Click(object sender, EventArgs e)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void but_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        } 
        #endregion

        #region 表單關閉事件 private void LoginLog_FormClosed(object sender, FormClosedEventArgs e)
        /// <summary>
        /// 表單關閉事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LoginLog_FormClosed(object sender, FormClosedEventArgs e)
        {
            Public.PublicForm Forms = new Public.PublicForm();
            Forms.LoginLog = null;
        } 
        #endregion

        private void bindingNavigator_WorkerLogin_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
             contextMenuStrip1.Visible = false;

             switch (e.ClickedItem.Name)
             {
                 case "toolStripMenuItem_Del":
                 case "DelToolStripMenuItem":
                     if (dataGridView1.CurrentRow != null)
                     {

                         if (MessageBox.Show("是否確定刪除(" + dataGridView1.CurrentRow.Cells["EmployeeName"].Value.ToString() + ")??", "提示訊息", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                         {
                             DB_Models.DB_WorkerLoginTModel CA_login = new DB_Models.DB_WorkerLoginTModel();

                             CA_login.Delete((int)dataGridView1.CurrentRow.Cells["WorkerLoginKey"].Value);

                             dataGridView1.Rows.Remove(dataGridView1.CurrentRow);                             

                             MessageBox.Show("刪除成功");
                         }
                     }
                     break;
                 case "Del3ToolStripMenuItem":
                 case "toolStripMenuItem_Del3":
                     if (dataGridView1.CurrentRow != null)
                     {

                         if (MessageBox.Show("是否確定刪除三個月前的登入記錄??", "提示訊息", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                         {
                             DB_Models.DB_WorkerLoginTModel CA_login = new DB_Models.DB_WorkerLoginTModel();

                             CA_login.Delete("CreateDateTime<= DATEADD(month,-3,getDate())","");

                            but_Search_Click(null, null);
                             MessageBox.Show("刪除成功");
                         }
                     }
                     break;
                case "toolStripButton_ClearAll":
                case "toolStripMenuItem_ClearAll":
                    if (MessageBox.Show("是否確定清空登入記錄", "確認視窗", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        string str = "truncate table WorkerLoginT";
                        DBAccess db = new DBAccess();
                        object obj = db.ExecuteNonQuery(str);
                        if (obj.ToString() == "0")
                        {
                            but_Search_Click(null, null);
                            MessageBox.Show("清空成功", "提示訊息", MessageBoxButtons.OK);
                        }
                    }
                    break;
            }
        }
    }
}
