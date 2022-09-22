using H3Operator.DBHelper;
using System;
using System.Data;
using System.Windows.Forms;

namespace LawtechPTSystem.SubFrom
{
    public partial class SMSLogsMF : Form
    {

        UserPermissionForm myPermission;
        private const string ProgramSymbol = "SMSLogsMF";
        private const string SourceTableName = "SMLogT";

        private DataTable dt_SMLogT = new DataTable();
        public DataTable DT_SMLogT
        {
            get; set;
        }


        public SMSLogsMF()
        {
            InitializeComponent();

            Public.DynamicGridViewColumn.GetGridColum(ref systemLogTDataGridView);
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region private void but_Search_Click(object sender, EventArgs e)
        /// <summary>
        /// 查詢按鈕
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void but_Search_Click(object sender, EventArgs e)
        {
            but_Search.Enabled = false;

            string strSQLWhere = Public.CommonFunctions.GetSQLScript(QueryFilter1, QueryFilter2, Radio_and.Checked ? " and " : " or ");
            GetSmsLog(strSQLWhere);

            systemLogTBindingSource.DataSource = dt_SMLogT;
            systemLogTDataGridView.DataSource = systemLogTBindingSource;

            but_Search.Enabled = true;
        } 
        #endregion

        #region GetSmsLog 取得簡訊歷史記錄的資料
        /// <summary>
        /// 取得刪除歷史記錄的資料
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public void GetSmsLog(string strWhere)
        {
            if (dt_SMLogT.Rows.Count > 0)
            {
                dt_SMLogT.Rows.Clear();
            }


            string strPatentFeeSQL = string.Format(
                                    @"
                                      SELECT   SMLogKey, SMCreator, ReceivePhone, SmContent, SmResult, SmClientTime, FeePoint, CreateDateTime, 
                            LastModifyDateTime FROM SMLogT with(nolock) {0} order by CreateDateTime desc
                                      ", strWhere.Trim() != string.Empty ? " where " + strWhere : "");

            DBAccess dll = new DBAccess();
            dll.QueryToDataTableByDataAdapter(strPatentFeeSQL, ref dt_SMLogT);

        }
        #endregion

        #region private void SMSLogsMF_Load(object sender, EventArgs e)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SMSLogsMF_Load(object sender, EventArgs e)
        {
            Public.PublicForm Forms = new Public.PublicForm();
            Forms.SMSLogsMF = this;

            //取得權限
            myPermission = new UserPermissionForm(Properties.Settings.Default.WorkerKEY, ProgramSymbol);

            System.Windows.Forms.BindingNavigator[] listbinding = { systemLogTBindingNavigator };
            System.Windows.Forms.ContextMenuStrip[] listtMenu = { contextMenuStrip1 };

            //確認可使用的功能選單
            Public.CommonFunctions.CheckMeunItemVisible(listbinding, myPermission.UserPermission);
            Public.CommonFunctions.CheckMeunItemVisible(listtMenu, myPermission.UserPermission);

            but_Search_Click(null, null);
        }
        #endregion

        #region private void SMSLogsMF_FormClosed(object sender, FormClosedEventArgs e)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SMSLogsMF_FormClosed(object sender, FormClosedEventArgs e)
        {
            Public.PublicForm Forms = new Public.PublicForm();
            Forms.SMSLogsMF = null;
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
                case "toolStripMenuItem_del":
                case "toolStripButton_Del":
                    if (systemLogTDataGridView.CurrentRow != null)
                    {
                        string strDelTitle = systemLogTDataGridView.CurrentRow.Cells["SmContent"].Value.ToString();
                        if (MessageBox.Show("是否確定刪除【" + strDelTitle + "】", "確認視窗", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            int iKey = (int)systemLogTDataGridView.CurrentRow.Cells["SMLogKey"].Value;
                            Public.CSMLog del_Due = new Public.CSMLog();
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
                        Public.CSMLog del_Due = new Public.CSMLog();
                        del_Due.Delete(" SmClientTime<DATEADD(month,-3,getdate()) ", "");

                        but_Search_Click(null, null);

                        MessageBox.Show("刪除成功", "提示訊息", MessageBoxButtons.OK);


                    }
                    break;
                case "toolStripButton_ClearAll":
                case "toolStripMenuItem_ClearAll":
                    if (MessageBox.Show("是否確定清空刪除Logs資料", "確認視窗", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        string str = "truncate table SMLogT";
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
        #endregion


    }
}
