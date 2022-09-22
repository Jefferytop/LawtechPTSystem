using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LawtechPTSystemByFirm.SubFrom
{
    /// <summary>
    /// 商標--事件內容設定
    /// </summary>
    public partial class TMNotifyDueMF : Form
    {
        UserPermissionForm myPermission;
        private const string ProgramSymbol = "TMNotifyDueMF";
        private const string SourceTableName = "TMNotifyDueT";

        public TMNotifyDueMF()
        {
            InitializeComponent();
            patNotifyDueTDataGridView.AutoGenerateColumns = false;
            processStepETDataGridView.AutoGenerateColumns = false;

            Dictionary<string, BindingSource> lists = new Dictionary<string, BindingSource>() { { "tMStatusTBindingSource", tMStatusTBindingSource }, { "trademarkProcessKindTBindingSource", trademarkProcessKindTBindingSource } };
            Public.DynamicGridViewColumn.GetGridColum(ref patNotifyDueTDataGridView, lists);

            Dictionary<string, BindingSource> lists2 = new Dictionary<string, BindingSource>() { { "tMStatusTBindingSource", tMStatusTBindingSource }, { "workerTBindingSource", workerTBindingSource } };
            Public.DynamicGridViewColumn.GetGridColum(ref processStepETDataGridView, lists2);
        }

        DataTable dt_Copy;

        public string proCountry
        {
            get
            {
                if (comboBox_Country.SelectedValue != null)
                {
                    return comboBox_Country.SelectedValue.ToString();
                }
                else
                {
                    return "TW";
                }
            }
        }

        public DataTable GetTMNotifyDue
        {
            get { return this.dataSet_TM.TMNotifyDueT; }
        }

        public void upDataSet()
        {
            this.dataSet_TM.TMNotifyDueT.Clear();
            this.tMNotifyDueTTableAdapter.Fill(this.dataSet_TM.TMNotifyDueT, proCountry);
        }

        private void TMNotifyDueMF_Load(object sender, EventArgs e)
        {
          
            Public.PublicForm Forms = new LawtechPTSystemByFirm.Public.PublicForm();
            Forms.TMNotifyDueMF = this;

            //取得權限
            myPermission = new UserPermissionForm(Properties.Settings.Default.WorkerKEY, ProgramSymbol);

            System.Windows.Forms.BindingNavigator[] listbinding = { bindingNavigator1, bindingNavigator2 };
            System.Windows.Forms.ContextMenuStrip[] listtMenu = { contextMenuStrip1 };

            //確認可使用的功能選單
            Public.CommonFunctions.CheckMeunItemVisible(listbinding, myPermission.UserPermission);
            Public.CommonFunctions.CheckMeunItemVisible(listtMenu, myPermission.UserPermission);

            this.tMStartDateTableAdapter.Fill(this.dataSet_Drop.TMStartDate);
            this.trademarkProcessKindTTableAdapter.Fill(this.dataSet_Drop.TrademarkProcessKindT);
          
            this.timeUnit_DropTableAdapter.Fill(this.qS_DataSet.TimeUnit_Drop);
            this.feePhaseTByTMTableAdapter.Fill(this.dataSet_Drop.FeePhaseTByTM);
           
            this.tMStatusTTableAdapter.Fill(this.dataSet_Drop.TMStatusT);
            this.countryT_DropTableAdapter.Fill(this.qS_DataSet.CountryT_Drop);
            this.tMNotifyDueTTableAdapter.Fill(this.dataSet_TM.TMNotifyDueT, proCountry);

            this.workerTTableAdapter.Fill(this.dataSet_Drop.WorkerT, false);

            dt_Copy = this.dataSet_TM.TMNotifyDueT.Clone();

            this.dataSet_TM.TMNotifyDueT.ColumnChanged += new DataColumnChangeEventHandler(TMNotifyDueT_ColumnChanged);
        }

        #region  =============TMNotifyDueT_ColumnChanged事件===============
        private void TMNotifyDueT_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            if (e.Row.RowState == DataRowState.Unchanged)
            {

                Public.CTMNotifyDue CA_CTMNotifyDue = new Public.CTMNotifyDue();
                Public.CTMNotifyDue.ReadOne((int)e.Row["TMNotifyDueID"], ref CA_CTMNotifyDue);
             
                switch (e.Column.ColumnName)
                {                    
                    case "Sort":
                        CA_CTMNotifyDue.Sort = e.ProposedValue != DBNull.Value ? (int)e.ProposedValue : -1;
                        break;
                    case "NotifyContent":
                        CA_CTMNotifyDue.NotifyContent = e.ProposedValue != null ? e.ProposedValue.ToString() : "";
                        break;
                    case "Status":
                        CA_CTMNotifyDue.Status = e.ProposedValue != DBNull.Value ? (int)e.ProposedValue : -1;
                        break;
                    case "CountrySymbol":
                        CA_CTMNotifyDue.CountrySymbol = e.ProposedValue != null ? e.ProposedValue.ToString() : "";
                        break;
                    case "Note":
                        CA_CTMNotifyDue.Note = e.ProposedValue != null ? e.ProposedValue.ToString() : "";
                        break;
                    case "Answer":
                        CA_CTMNotifyDue.Answer = e.ProposedValue != null ? e.ProposedValue.ToString() : "";
                        break;
                    case "AnswerTime":
                        CA_CTMNotifyDue.AnswerTime = e.ProposedValue != DBNull.Value ? (int)e.ProposedValue : -1;
                        break;
                    case "TimeUnit":
                        CA_CTMNotifyDue.TimeUnit = e.ProposedValue != DBNull.Value ? (int)e.ProposedValue : -1;
                        break;
                    case "StartDate":
                        CA_CTMNotifyDue.StartDate = e.ProposedValue != DBNull.Value ? (int)e.ProposedValue : -1;
                        break;
                    case "ASday":
                        CA_CTMNotifyDue.ASday = e.ProposedValue != DBNull.Value ? (int)e.ProposedValue : -1;
                        break;
                    case "FeePhase":
                        CA_CTMNotifyDue.FeePhase = e.ProposedValue != DBNull.Value ? (int)e.ProposedValue : -1;
                        break;
                    case "ProcessKEY":
                        CA_CTMNotifyDue.ProcessKEY = e.ProposedValue != DBNull.Value ? (int)e.ProposedValue : -1;
                        break;
                }
                CA_CTMNotifyDue.Update();
                //this.dataSet_TM.TMNotifyDueT.AcceptChanges();
            }
        }
        #endregion


        private void TMNotifyDueMF_FormClosed(object sender, FormClosedEventArgs e)
        {
            Public.PublicForm Forms = new LawtechPTSystemByFirm.Public.PublicForm();
            Forms.TMNotifyDueMF = null;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            contextMenuStrip1.Visible = false;

            switch (e.ClickedItem.Name)
            {
                case "toolStripButton_Add":
                case "AddToolStripMenuItem":
                    AddFrom.AddTMNotifyDue Due = new AddFrom.AddTMNotifyDue();
                    int iSort = 1;
                    if (patNotifyDueTDataGridView.Rows.Count > 1)
                    {
                        iSort = (int)patNotifyDueTDataGridView.Rows[patNotifyDueTDataGridView.Rows.Count - 1].Cells["Sort"].Value + 1;
                    }
                    Due.Sort = iSort;
                    Due.Country = comboBox_Country.SelectedValue.ToString();
                    Due.ShowDialog();
                    break;

                case "toolStripButton_del":
                case "DelToolStripMenuItem":
                    if (patNotifyDueTDataGridView.CurrentRow != null)
                    {
                        string strName = patNotifyDueTDataGridView.CurrentRow.Cells["NotifyContent"].Value.ToString();

                        if (MessageBox.Show("是否確定刪除【" + strName + "】", "確認視窗", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            int iKey = (int)patNotifyDueTDataGridView.CurrentRow.Cells["TMNotifyDueID"].Value;
                            Public.CTMNotifyDue del_Due = new Public.CTMNotifyDue();
                            //del_Due.Delete(iKey);

                            //刪除記錄檔    
                            Public.CSystemLog log = new LawtechPTSystemByFirm.Public.CSystemLog();
                            log.DelTime = DateTime.Now;
                            log.DelWorkerKey = Properties.Settings.Default.WorkerKEY;
                            //string[] str = del_Due.GetInsertString(iKey);
                            //log.TableName = str[2];
                            //log.DelContent_InsertColumn = str[0];
                            //log.DelContent_InsertSQL = str[1];
                            log.DelContent = string.Format("國別:{2}\r\n事件內容:{0}\r\n提醒訊息:{1}", del_Due.NotifyContent, del_Due.Note, comboBox_Country.Text);
                            log.DelTitle = string.Format("刪除商標事件內容設定檔資料【{0}】", del_Due.NotifyContent);
                            log.Create();


                            del_Due.Delete(iKey);

                            DataRow dr = this.dataSet_TM.TMNotifyDueT.Rows.Find((int)patNotifyDueTDataGridView.CurrentRow.Cells["TMNotifyDueID"].Value);

                            this.dataSet_TM.TMNotifyDueT.Rows.Remove(dr);

                            MessageBox.Show("刪除成功", "提示訊息", MessageBoxButtons.OK);
                        }

                    }
                    break;
                case "CopySelectToolStripMenuItem":
                    dt_Copy.Clear();
                    int nCount = 0;
                    for (int i = 0; i < patNotifyDueTDataGridView.Rows.Count; i++)
                    {
                        if (patNotifyDueTDataGridView.Rows[i].Cells["Column1"].EditedFormattedValue != null && patNotifyDueTDataGridView.Rows[i].Cells["Column1"].EditedFormattedValue.ToString() == bool.TrueString)
                        {

                            DataRow dr = dt_Copy.NewRow();
                            dr["Sort"] = patNotifyDueTDataGridView.Rows[i].Cells["Sort"].Value.ToString() != "" ? (int)patNotifyDueTDataGridView.Rows[i].Cells["Sort"].Value : 0;
                            dr["NotifyContent"] = patNotifyDueTDataGridView.Rows[i].Cells["NotifyContent"].Value.ToString();
                            dr["Status"] = patNotifyDueTDataGridView.Rows[i].Cells["Status"].Value.ToString() != "" ? (int)patNotifyDueTDataGridView.Rows[i].Cells["Status"].Value : -1;
                            dr["Note"] = patNotifyDueTDataGridView.Rows[i].Cells["Note"].Value.ToString();
                            //dr["Answer"] = patNotifyDueTDataGridView.Rows[i].Cells["Answer"].Value.ToString();
                            //dr["AnswerTime"] = patNotifyDueTDataGridView.Rows[i].Cells["AnswerTime"].Value.ToString() != "" ? int.Parse(patNotifyDueTDataGridView.Rows[i].Cells["AnswerTime"].Value.ToString()) : 0;
                            //dr["TimeUnit"] =patNotifyDueTDataGridView.Rows[i].Cells["TimeUnit"].Value!=DBNull.Value? (int)patNotifyDueTDataGridView.Rows[i].Cells["TimeUnit"].Value:-1;
                            //dr["StartDate"] =patNotifyDueTDataGridView.Rows[i].Cells["StartDate"].Value!=DBNull.Value? (int)patNotifyDueTDataGridView.Rows[i].Cells["StartDate"].Value:-1;
                            //dr["ASday"] = patNotifyDueTDataGridView.Rows[i].Cells["StartDate"].Value.ToString() == "" ? 0 : (int)patNotifyDueTDataGridView.Rows[i].Cells["StartDate"].Value;
                            //dr["FeePhase"] = patNotifyDueTDataGridView.Rows[i].Cells["FeePhase"].Value != DBNull.Value ? (int)patNotifyDueTDataGridView.Rows[i].Cells["FeePhase"].Value : -1;
                            dr["ProcessKEY"] = patNotifyDueTDataGridView.Rows[i].Cells["ProcessKEY"].Value.ToString() != "" ? (int)patNotifyDueTDataGridView.Rows[i].Cells["ProcessKEY"].Value : -1;
                            dt_Copy.Rows.Add(dr);
                            nCount++;
                        }
                    }
                    //patNotifyDueTDataGridView.Sort(patNotifyDueTDataGridView.Columns["Sort"], ListSortDirection.Ascending);
                    MessageBox.Show("共複製了 " + nCount.ToString() + " 筆");
                    break;
                case "PasteSelectToolStripMenuItem":
                    if (dt_Copy.Rows.Count > 0)
                    {
                        bool isUpdate = false;
                        for (int n = 0; n < dt_Copy.Rows.Count; n++)
                        {
                            DataRow dr = dt_Copy.Rows[n];
                            Public.CTMNotifyDue due = new Public.CTMNotifyDue();
                            due.Sort = (int)dr["Sort"];
                            due.NotifyContent = dr["NotifyContent"].ToString();
                            due.Status = (int)dr["Status"];
                            due.CountrySymbol = comboBox_Country.SelectedValue.ToString();
                            due.Note = dr["Note"].ToString();
                            //due.Answer = dr["Answer"].ToString();
                            //due.AnswerTime = (int)dr["AnswerTime"];
                            //due.TimeUnit = (int)dr["TimeUnit"];
                            //due.StartDate = (int)dr["StartDate"];
                            //due.ASday = (int)dr["ASday"];
                            //due.FeePhase = dr["FeePhase"].ToString() == "" ? -1 : (int)dr["FeePhase"];
                            due.ProcessKEY = (int)dr["ProcessKEY"];
                            object obj=due.Create();

                            if (!isUpdate && obj.ToString() == "0")
                            {
                                isUpdate = true;
                            }
                        }

                        if (isUpdate)
                        {
                            but_Update_Click(null, null);
                        }
                    }

                    break;
                case "SelectAllToolStripMenuItem":
                    if (patNotifyDueTDataGridView.Rows.Count > 0)
                    {
                        //patNotifyDueTDataGridView.CurrentCell = patNotifyDueTDataGridView.CurrentRow.Cells[1];

                        for (int i = 0; i < patNotifyDueTDataGridView.Rows.Count; i++)
                        {
                            patNotifyDueTDataGridView.Rows[i].Cells["Column1"].Value = true;
                        }
                    }
                    break;
                case "CancelAllToolStripMenuItem":
                    if (patNotifyDueTDataGridView.Rows.Count > 0)
                    {
                        for (int i = 0; i < patNotifyDueTDataGridView.Rows.Count; i++)
                        {
                            patNotifyDueTDataGridView.Rows[i].Cells["Column1"].Value = false;
                        }
                    }
                    break;

                case "toolStripMenuItem_Excel":
                    try
                    {
                        Public.DLL dll = new LawtechPTSystemByFirm.Public.DLL();
                        Task task = dll.WriteToCSV(patNotifyDueTDataGridView);
                    }
                    catch
                    {
                        MessageBox.Show("匯出CSV失敗");
                    }
                    break;
                case "toolStripMenuItem_MultipleDelete"://多筆刪除
                    if (MessageBox.Show("是否確定將勾選事件內容刪除", "確認視窗", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        int delCount = 0;
                        bool isUpdate = false;
                        object obj;
                        Public.CTMNotifyDue del_Due = new Public.CTMNotifyDue();
                        int iKey = 0;
                        for (int i = 0; i < patNotifyDueTDataGridView.Rows.Count; i++)
                        {
                            if (patNotifyDueTDataGridView.Rows[i].Cells["Column1"].EditedFormattedValue != null && patNotifyDueTDataGridView.Rows[i].Cells["Column1"].EditedFormattedValue.ToString() == bool.TrueString)
                            {
                                iKey = (int)patNotifyDueTDataGridView.Rows[i].Cells["TMNotifyDueID"].Value;
                                
                                obj= del_Due.Delete(iKey);

                                if (!isUpdate && obj.ToString() == "0")
                                {
                                    isUpdate = true;
                                }

                                delCount++;
                            }
                        }

                        if (isUpdate)
                        {
                            but_Update_Click(null, null);
                        }

                        MessageBox.Show("共刪除了 " + delCount.ToString() + " 筆");
                    }
                    break;
            }
        }

        private void comboBox_Country_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_Country != null)
            {
                this.tMNotifyDueTTableAdapter.Fill(this.dataSet_TM.TMNotifyDueT, proCountry);
            }
        }

        private void patNotifyDueTDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
         
            e.Cancel = false;
        }

        private void patNotifyDueTDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (patNotifyDueTDataGridView.CurrentRow != null)
            {
                tagTitle2.TitleLableText = "指定的作業流程--" + patNotifyDueTDataGridView.CurrentRow.Cells["ProcessKEY"].FormattedValue;

                this.dataSet_TM.TrademarkProcessStepET.Clear();
                this.trademarkProcessStepETTableAdapter.Fill(this.dataSet_TM.TrademarkProcessStepET, (int)patNotifyDueTDataGridView.CurrentRow.Cells["ProcessKEY"].Value);
            }
            else {
                tagTitle2.TitleLableText = "指定的作業流程" ;

                this.dataSet_TM.TrademarkProcessStepET.Clear();
            }
        }

        private void but_Update_Click(object sender, EventArgs e)
        {
            if (comboBox_Country != null)
            {
                this.tMNotifyDueTTableAdapter.Fill(this.dataSet_TM.TMNotifyDueT, proCountry);
            }
        }
    }
}