using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace LawtechPTSystem.SubFrom
{
    public partial class LinksMF : Form
    {
        public LinksMF()
        {
            InitializeComponent();
            Public.DynamicGridViewColumn.GetGridColum(ref dataGridView1);
        }

        UserPermissionForm myPermission;
        private const string ProgramSymbol = "LinksMF";
        private const string SourceTableName = "LinksT";


        #region Public Property
        /// <summary>
        /// 常用連結資料集
        /// </summary>
        public DataTable DT_Links
        {
            get { return this.dataSet_News.Links; }

        }

       /// <summary>
       /// 當前的資料的Key值
       /// </summary>
        public int ProLinkKey
        {
            get
            {
                if (dataGridView1.CurrentRow != null)
                {
                    return (int)dataGridView1.CurrentRow.Cells["LinksKey"].Value;
                }
                else
                {
                    return -1;
                }
            }
        } 

        #endregion

        #region LinksMF_Load
        private void LinksMF_Load(object sender, EventArgs e)
        {

            Public.PublicForm Forms = new Public.PublicForm();
            Forms.LinksMF = this;

            //取得權限
            myPermission = new UserPermissionForm(Properties.Settings.Default.WorkerKEY, ProgramSymbol);
      
            //確認可使用的功能選單
            Public.CommonFunctions.CheckMeunItemVisible(contextMenuStrip1, myPermission.UserPermission);
            Public.CommonFunctions.CheckMeunItemVisible(bindingNavigator1, myPermission.UserPermission);

            but_Search_Click(null, null);
        } 
        #endregion

        #region LinksMF_FormClosed
        private void LinksMF_FormClosed(object sender, FormClosedEventArgs e)
        {
            Public.PublicForm Forms = new Public.PublicForm();
            Forms.LinksMF = null;
        } 
        #endregion

        #region but_Close_Click
        private void but_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        } 
        #endregion

        #region contextMenuStrip1_ItemClicked
        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            contextMenuStrip1.Visible = false;

            switch (e.ClickedItem.Name)
            {
                case "toolStripButton_Add":
                case "toolStripMenuItem_Add":
                    AddFrom.AddLinks add = new LawtechPTSystem.AddFrom.AddLinks();
                    add.ShowDialog();
                    break;
                case "toolStripButton_Edit":
                case "toolStripMenuItem_Edit":
                    if (dataGridView1.CurrentRow != null)
                    {
                        int iUser = Public.CommonFunctions.GetRecordAuth(SourceTableName, "LinksKey=" + ProLinkKey.ToString());
                        if (iUser == -1)//判斷是否有人使用中
                        {
                            EditForm.EditLinks edit = new LawtechPTSystem.EditForm.EditLinks();
                            edit.ProLinkKey = (int)dataGridView1.CurrentRow.Cells["LinksKey"].Value;
                            edit.ShowDialog();
                        }
                        else
                        {
                            List<ViewModel_LockedWorker> manager=new  List<ViewModel_LockedWorker>() ;
                            ViewModel_LockedWorker.ReadViewTableList("WorkerKey=" + iUser.ToString(), ref  manager);
                            if (manager.Count > 0)
                            {
                                MessageBox.Show(string.Format("該筆資料目前被【{0}】使用中...", manager[0].EmployeeName), "提示訊息");
                            }
                        }

                    }
                    break;
                case "toolStripButton_Del":
                case "toolStripMenuItem_Del":
                    if (dataGridView1.CurrentRow != null)
                    {
                        string sName = dataGridView1.CurrentRow.Cells["WebSiteName"].Value.ToString();
                        if (MessageBox.Show("是否確定刪除 【" + sName + "】", "確認視窗", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                            {
                                Links_Model delLinks = new Links_Model();
                                Links_Model.ReadOne(ProLinkKey, ref delLinks);
                                delLinks.Delete();

                                #region 刪除記錄檔 已不用
                                //刪除記錄檔    
                                //Public.CSystemLog log = new Public.CSystemLog("1=0");
                                //log.DelTime = DateTime.Now;
                                //log.DelWorkerKey = Properties.Settings.Default.WorkerKEY;
                                //string[] str = del.GetInsertString(iKey);
                                //log.TableName = str[2];
                                //log.DelContent_InsertColumn = str[0];
                                //log.DelContent_InsertSQL = str[1];
                                //log.DelContent = string.Format("網站名稱:{0}", del.WebSiteName);
                                //log.DelTitle = string.Format("刪除常用連結網站資料【{0}】", del.WebSiteName);
                                //log.Insert();

                                //del.Delete(iKey); 
                                #endregion

                                dataGridView1.Rows.Remove(dataGridView1.CurrentRow);

                                this.dataSet_News.News.AcceptChanges();

                                MessageBox.Show("刪除成功");
                            }
                      
                    }
                    break;


            }
        }
        #endregion

        #region but_Search_Click
        private void but_Search_Click(object sender, EventArgs e)
        {
            string FullWhere = Public.CommonFunctions.GetSQLScript(QueryFilter1, QueryFilter2, Radio_and.Checked ? " and " : " or ", userControlFilterDate1);

            string strSQL = string.Format(@"SELECT    LinksT.LinksKey, LinksT.NewsTypeKey, LinksT.Sort, LinksT.WebSiteName, LinksT.WebAddress, LinksT.Description, LinksT.CreateDateTime, 
                                              LinksT.LastModifyDateTime,  LinksT.LockedWorker, NewsType.TypeName, WorkerT_1.EmployeeName AS Creator, 
                                              WorkerT.EmployeeName AS LastModifyWorker
                                                FROM         LinksT INNER JOIN
                                              NewsType ON LinksT.NewsTypeKey = NewsType.NewsTypeKey LEFT OUTER JOIN
                                              WorkerT ON LinksT.LastModifyWorker = WorkerT.WorkerKey LEFT OUTER JOIN
                                              WorkerT AS WorkerT_1 ON LinksT.Creator = WorkerT_1.WorkerKey   {0}
                                            ORDER BY  LinksT.Sort", FullWhere.ToString().Trim() != "" ? " where " + FullWhere.ToString() : "");

            //Public.DLL dll = new Public.DLL();

            this.linksTableAdapter.Fill(this.dataSet_News.Links);
            bindingSource1.Filter = FullWhere.ToString().Trim();
            //dll.FetchDataTable(strSQL, (DataTable)this.dataSet_News.Links);

        }
        #endregion

          
        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = false;
        }

        #region dataGridView1_CellContentClick
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex!=-1)
            {

                if (dataGridView1.Columns[e.ColumnIndex].Name == "webAddressDataGridViewTextBoxColumn" || dataGridView1.Columns[e.ColumnIndex].Name == "WebSiteName")
                {
                    if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() != "")
                    {
                        Public.Utility.ProcessStart(dataGridView1.Rows[e.RowIndex].Cells["webAddressDataGridViewTextBoxColumn"].Value.ToString());
                    }
                }
            }
        }
        #endregion

        #region dataGridView1_CellDoubleClick
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != -1 && e.RowIndex != -1)
            {
                contextMenuStrip1_ItemClicked(contextMenuStrip1, new ToolStripItemClickedEventArgs(toolStripMenuItem_Edit));
            }
        }
        #endregion

        

    }
}
