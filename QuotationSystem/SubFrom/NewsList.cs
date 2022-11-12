using System;
using System.Data;
using System.Windows.Forms;

namespace LawtechPTSystem.SubFrom
{
    public partial class NewsList : Form
    {
        public NewsList()
        {
            InitializeComponent();

            newsDataGridView.AutoGenerateColumns = false;
            dataGridView_WorkerName.AutoGenerateColumns = false;
            Public.DynamicGridViewColumn.GetGridColum(ref newsDataGridView);
            Public.DynamicGridViewColumn.GetGridColum(ref dataGridView_WorkerName);
        }

        #region Public Property
        private DataTable Dt_News = new DataTable();
        /// <summary>
        /// 公怖欄資料集
        /// </summary>
        public DataTable DT_News
        {
            get { return Dt_News; }

        }

        private DataTable dt_NewsWorkerName = new DataTable();
        /// <summary>
        /// 公怖欄已閱人員資料集
        /// </summary>
        public DataTable DT_NewsWorkerName
        {
            get { return dt_NewsWorkerName; }

        }

        private int iWorkerID = -1;
        /// <summary>
        /// 登入者ID
        /// </summary>
        public int WorkerID
        {
            get { return iWorkerID; }
            set { iWorkerID = value; }
        }


        private int iOfficeRole = -1;
        /// <summary>
        /// 權限 0.最高權限 1.指定權限 2.專利  3.商標 4.會計經理
        /// </summary>
        public int OfficeRole
        {
            get { return iOfficeRole; }
            set { iOfficeRole = value; }
        } 
        #endregion

        #region News_Load  News_FormClosed
        private void News_Load(object sender, EventArgs e)
        {
            Public.PublicForm Forms = new Public.PublicForm();
            Forms.News = this;         
         

            //起始時間          
            Public.Utility.SetLoadDataRange(userControlFilterDate1);

            NewsControlBinding();

            //登入者
            iWorkerID = Properties.Settings.Default.WorkerKEY;
          
            //角色的權限
            OfficeRole = Properties.Settings.Default.OfficeRole;

            if (Properties.Settings.Default.IsLoadData)
            {
                but_Search_Click(null, null);
            }
        }

        private void News_FormClosed(object sender, FormClosedEventArgs e)
        {
            Public.PublicForm Forms = new Public.PublicForm();
            Forms.News = null;

        }
        #endregion
       
        #region ================NewsControlBinding================
        public void NewsControlBinding()
        {           

            //主旨
            txt_NewsSubject.DataBindings.Clear();
            txt_NewsSubject.DataBindings.Add("Text", newsBindingSource, "NewsSubject", true, DataSourceUpdateMode.OnPropertyChanged, "", "");

            //內文
            txt_NewsContent.DataBindings.Clear();
            txt_NewsContent.DataBindings.Add("Text", newsBindingSource, "NewsContent", true, DataSourceUpdateMode.OnPropertyChanged, "", "");

            //建立者
            txt_WorkerName.DataBindings.Clear();
            txt_WorkerName.DataBindings.Add("Text", newsBindingSource, "Creator", true, DataSourceUpdateMode.OnPropertyChanged, "", "");


            //發怖類型
            txt_TypeName.DataBindings.Clear();
            txt_TypeName.DataBindings.Add("Text", newsBindingSource, "TypeName", true, DataSourceUpdateMode.OnPropertyChanged, "", "");

           
            //建立時間
           txt_CreateDate.DataBindings.Clear();
           txt_CreateDate.DataBindings.Add("Text", newsBindingSource, "CreateDateTime", true, DataSourceUpdateMode.OnPropertyChanged, "    -  -", "yyyy-MM-dd HH:mm");
                      

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
                    AddFrom.AddNews add = new LawtechPTSystem.AddFrom.AddNews();
                    add.ShowDialog();
                    break;
                case "toolStripButton_Edit":
                case "toolStripMenuItem_Edit":
                    if (newsDataGridView.CurrentRow != null)
                    {
                        int NewsKey= (int)newsDataGridView.CurrentRow.Cells["NewsKey"].Value;
                        DB_NewsTModel news = new DB_NewsTModel();
                        DB_NewsTModel.ReadOne(NewsKey, ref news);
                        if (news.Creator == Properties.Settings.Default.WorkerName || OfficeRole == 0)
                      {
                          EditForm.EditNews edit = new LawtechPTSystem.EditForm.EditNews();
                          edit.Pro_NewsKey = (int)newsDataGridView.CurrentRow.Cells["NewsKey"].Value;
                          edit.ShowDialog();
                      }
                      else
                      {
                          MessageBox.Show(Properties.Settings.Default.WorkerName+"\r\n  您不是『建立者』或是『最高權限者』，不得修改!!");
                      }
                    }
                    break;
                case "toolStripButton_Del":
                case "toolStripMenuItem_Del":
                    if (newsDataGridView.CurrentRow != null)
                    {
                        int NewsKey = (int)newsDataGridView.CurrentRow.Cells["NewsKey"].Value;
                        DB_NewsTModel news = new DB_NewsTModel();
                        DB_NewsTModel.ReadOne(NewsKey, ref news);

                        if (news.Creator == Properties.Settings.Default.WorkerName || OfficeRole == 0)
                        {
                            string sName=newsDataGridView.CurrentRow.Cells["NewsSubject"].Value.ToString();

                            if (MessageBox.Show("是否確定刪除 \r\n " + sName, "確認視窗", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                            {
                                #region 刪除已閱讀者
                                //刪除已閱讀者
                                Public.CNewsWorkerT delWorker = new Public.CNewsWorkerT();
                                delWorker.Delete("NewsKey=" + news.NewsKey.ToString(), ""); 
                                #endregion                                

                                #region 刪除記錄檔                                 
                                Public.CSystemLogT log = new Public.CSystemLogT();
                                log.DelTime = DateTime.Now;
                                log.DelWorkerKey = Properties.Settings.Default.WorkerKEY;                                
                                log.DelContent = string.Format("主旨:{0}\r\n建立者：{1}", news.NewsSubject,news.Creator);
                                log.DelTitle = string.Format("刪除{0}資料【{1}】\r\n內文：{2}", this.Text ,news.NewsSubject,news.NewsContent);
                                log.Create();
                                #endregion

                                news.Delete();

                                newsDataGridView.Rows.Remove(newsDataGridView.CurrentRow);

                                this.dataSet_News.News.AcceptChanges();

                                MessageBox.Show("刪除成功");
                            }
                        }
                        else
                        {
                            MessageBox.Show( Properties.Settings.Default.WorkerName+"\r\n 您不是『建立者』或是『最高權限者』，不得刪除!!");
                        }
                    }
                    break;
                case "toolStripMenuItem_SetGridColumn":
                    SetGridColumnT gc = new SetGridColumnT();
                    gc.CurrentGridSymboID = newsDataGridView.Tag.ToString();
                    gc.TitleName = "公佈欄訊息列表";
                    gc.Show();
                    break;
            
            }
        }
        #endregion     

        #region but_Search_Click
        private void but_Search_Click(object sender, EventArgs e)
        {
            but_Search.Enabled = false;

            string strSQL = Public.CommonFunctions.GetSQLScript(QueryFilter1, QueryFilter2, Radio_and.Checked ? " and " : " or ", userControlFilterDate1);

            Public.CNewsPublicFunction.GetNewsList(strSQL, ref Dt_News);

            newsBindingSource.DataSource = Dt_News;

            but_Search.Enabled = true;


        }
        #endregion

        #region newsDataGridView_CellDoubleClick
        private void newsDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != -1 && e.RowIndex != -1)
            {
                contextMenuStrip1_ItemClicked(contextMenuStrip1, new ToolStripItemClickedEventArgs(toolStripMenuItem_Edit));
            }
        } 
        #endregion

        private void but_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void newsDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = false;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Public.Utility.SsplitContainerHorizontal(ref splitContainer1);
        }

        private void newsDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (newsDataGridView.CurrentRow != null)
            {
                int iKey = (int)newsDataGridView.CurrentRow.Cells["NewsKey"].Value;
                Public.CNewsPublicFunction.GetNewsWorkerNameList(iKey.ToString(), iWorkerID .ToString(), ref dt_NewsWorkerName);
                bindingSource_WorkerName.DataSource = dt_NewsWorkerName;
                DataRow dr = dt_NewsWorkerName.Rows.Find(iWorkerID);
                if (dr == null)
                {
                    Public.CNewsWorkerT nw = new Public.CNewsWorkerT();
                    nw.WorkerKey = iWorkerID;
                    nw.NewsKey = iKey;
                    nw.Create();
                }
            }
            else
            {
                dt_NewsWorkerName.Rows.Clear();
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LinkLabel link = (LinkLabel)sender;
            US.PopMemo pop;
            switch (link.Name)
            {
                case "linkLabel_NewsSubject":
                    pop = new LawtechPTSystem.US.PopMemo(txt_NewsSubject, true, link.Text);
                    break;
                case "linkLabel_NewsContent":
                    pop = new LawtechPTSystem.US.PopMemo(txt_NewsContent, true, link.Text);
                    break;
                default:
                    pop = new LawtechPTSystem.US.PopMemo(txt_NewsSubject, true, link.Text);
                    break;
            }

            pop.Show();

        }

       private void btnOpenDetail_Click(object sender, EventArgs e)
        {
            Public.Utility.SsplitContainerHorizontal(ref splitContainer1);
        }
    }
}
