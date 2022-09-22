using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace LawtechPTSystem.SubFrom
{
    /// <summary>
    /// 專利--事件內容
    /// </summary>
    public partial class ComitContentTMF : Form
    {

        UserPermissionForm myPermission;
        private const string strProgramSymbol = "ComitContentTMF";
        private const string SourceTableName = "PatComitContentT";

        public ComitContentTMF()
        {
            InitializeComponent();

            patComitContentTDataGridView.AutoGenerateColumns = false;
            processStepETDataGridView.AutoGenerateColumns = false;

            Dictionary<string, BindingSource> lists = new Dictionary<string, BindingSource>() { { "patStatusTDropBindingSource", patStatusTDropBindingSource }, { "processKindTDropBindingSource", processKindTDropBindingSource } };
            Public.DynamicGridViewColumn.GetGridColum(ref patComitContentTDataGridView, lists);

            Dictionary<string, BindingSource> lists2 = new Dictionary<string, BindingSource>() { { "patStatusTDropBindingSource", patStatusTDropBindingSource } };
            Public.DynamicGridViewColumn.GetGridColum(ref processStepETDataGridView, lists2);
        }

        DataTable DT_Copy = new DataTable();

        public DataTable GetPatComitContent
        {
            get { return this.qS_DataSet.PatComitContentT; }
        }

        public void upDataSet()
        {
            this.qS_DataSet.PatComitContentT.Clear();
            this.patComitContentTTableAdapter.Fill(this.qS_DataSet.PatComitContentT, comboBox_Country.SelectedValue.ToString());
        }

        public void CopyeInit()
        {
            DT_Copy.Columns.Add("Sort",typeof(int));
            DT_Copy.Columns.Add("ComitContent");
            DT_Copy.Columns.Add("ProcessKEY", typeof(int));
            DT_Copy.Columns.Add("Status", typeof(int));
        }

        #region 表單載入事件 private void ComitContentTMF_Load(object sender, EventArgs e)
        /// <summary>
        /// 表單載入事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComitContentTMF_Load(object sender, EventArgs e)
        {
            Public.PublicForm Forms = new Public.PublicForm();
            Forms.ComitContentTMF = this;

            //取得權限
            myPermission = new UserPermissionForm(Properties.Settings.Default.WorkerKEY, strProgramSymbol);

            System.Windows.Forms.BindingNavigator[] listbinding = { bindingNavigator1 };
            System.Windows.Forms.ContextMenuStrip[] listtMenu = { contextMenuStrip1 };

            //確認可使用的功能選單
            Public.CommonFunctions.CheckMeunItemVisible(listbinding, myPermission.UserPermission);
            Public.CommonFunctions.CheckMeunItemVisible(listtMenu, myPermission.UserPermission);

            CopyeInit();

            this.countryT_DropTableAdapter.Fill(this.qS_DataSet.CountryT_Drop);
            this.patStatusT_DropTableAdapter.Fill(this.qS_DataSet._PatStatusT_Drop);
            this.processKindT_DropTableAdapter.Fill(this.qS_DataSet._ProcessKindT_Drop);
            this.patComitContentTTableAdapter.Fill(this.qS_DataSet.PatComitContentT, comboBox_Country.SelectedValue.ToString());

            this.qS_DataSet.PatComitContentT.ColumnChanged += new DataColumnChangeEventHandler(PatComitContentT_ColumnChanged);
        } 
        #endregion

        #region  =============PatComitContentT_ColumnChanged事件===============
        private void PatComitContentT_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            if (e.Row.RowState == DataRowState.Unchanged)
            {
                Public.CPatComitContent CA_CPatComitContent = new Public.CPatComitContent();
                CA_CPatComitContent.ComitContentID = int.Parse(e.Row["ComitContentID"].ToString());
                Public.CPatComitContent.ReadOne(ref  CA_CPatComitContent);
                switch (e.Column.ColumnName)
                {                  
                    case "Sort":
                        CA_CPatComitContent.Sort = e.ProposedValue != DBNull.Value ? (int)e.ProposedValue : -1;
                        break;
                    case "ComitContent":
                        CA_CPatComitContent.ComitContent = e.ProposedValue != null ? e.ProposedValue.ToString() : "";
                        break;
                    case "ProcessKEY":
                        CA_CPatComitContent.ProcessKEY = e.ProposedValue != DBNull.Value ? (int)e.ProposedValue : -1;
                        break;
                    case "Status":
                        CA_CPatComitContent.Status = e.ProposedValue != DBNull.Value ? (int)e.ProposedValue : -1;
                        break;
                }
                CA_CPatComitContent.Update();
                //this.qS_DataSet.PatComitContentT.AcceptChanges();
            }
        }
        #endregion

        private void ComitContentTMF_FormClosed(object sender, FormClosedEventArgs e)
        {
            Public.PublicForm Forms = new Public.PublicForm();
            Forms.ComitContentTMF = null;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

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
                    AddFrom.AddComitContent add = new AddFrom.AddComitContent();
                    add.Text += "(" + comboBox_Country.SelectedValue.ToString() + ")";
                    add.property_Country = comboBox_Country.SelectedValue.ToString();
                    add.ShowDialog();

                    break;
                case "toolStripButton_Del":
                case "DelToolStripMenuItem":
                    if (patComitContentTDataGridView.CurrentRow != null)
                    {
                        string sName = patComitContentTDataGridView.CurrentRow.Cells["ComitContent"].Value.ToString();
                        if (MessageBox.Show("是否確定刪除 【" + sName + "】", "確認視窗", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            int iKey = (int)patComitContentTDataGridView.CurrentRow.Cells["ComitContentID"].Value;
                            Public.CPatComitContent PatContent = new Public.CPatComitContent();
                            Public.CPatComitContent.ReadOne(iKey ,ref PatContent);

                            //刪除記錄檔    
                            Public.CSystemLogT log = new Public.CSystemLogT();
                            log.DelTime = DateTime.Now;
                            log.DelWorkerKey = Properties.Settings.Default.WorkerKEY;
                            log.DelWorker = Properties.Settings.Default.WorkerName;                           
                            log.DelContent = string.Format("國別:{0}\r\n事件內容:{1}", comboBox_Country.Text, PatContent.ComitContent);
                            log.DelTitle = string.Format("刪除「{0}」資料【{1}】",this.Text, PatContent.ComitContent);
                            log.Create();

                            PatContent.Delete(iKey);


                            patComitContentTDataGridView.Rows.Remove(patComitContentTDataGridView.CurrentRow);
                            MessageBox.Show("刪除成功");
                        }
                    }
                    break;

                case "toolStripMenuItem_Copy":
                  
                        DT_Copy.Rows.Clear();
                        int nCount = 0;
                        for (int iRow = 0; iRow < patComitContentTDataGridView.Rows.Count; iRow++)
                        {
                            if (patComitContentTDataGridView.Rows[iRow].Cells["Column1"].EditedFormattedValue != null && patComitContentTDataGridView.Rows[iRow].Cells["Column1"].EditedFormattedValue.ToString() == bool.TrueString)
                            {
                                DataRow dr = DT_Copy.NewRow();
                                dr["Sort"] = patComitContentTDataGridView.Rows[iRow].Cells["Sort"].Value;
                                dr["ComitContent"] = patComitContentTDataGridView.Rows[iRow].Cells["ComitContent"].Value;
                                dr["ProcessKEY"] = patComitContentTDataGridView.Rows[iRow].Cells["ProcessKEY"].Value;
                                dr["Status"] = patComitContentTDataGridView.Rows[iRow].Cells["Status"].Value;
                                DT_Copy.Rows.Add(dr);
                                nCount++;
                            }
                        }

                        MessageBox.Show(string.Format("共複製 {0} 筆", nCount.ToString()), "提示訊息");

                        break;
                case "SelectAllToolStripMenuItem"://選取全部勾選
                    if (patComitContentTDataGridView.Rows.Count > 0)
                    {
                       
                        for (int i = 0; i < patComitContentTDataGridView.Rows.Count; i++)
                        {
                            patComitContentTDataGridView.Rows[i].Cells["Column1"].Value = true;
                        }
                    }
                    break;
                case "CancelAllToolStripMenuItem"://清除全部勾選
                    if (patComitContentTDataGridView.Rows.Count > 0)
                    {
                        for (int i = 0; i < patComitContentTDataGridView.Rows.Count; i++)
                        {
                            patComitContentTDataGridView.Rows[i].Cells["Column1"].Value = false;
                        }
                    }
                    break;

                case "toolStripMenuItem_Paste":
                    if (MessageBox.Show(string.Format("是否確定貼上({1})\r\n共 {0} 筆", DT_Copy.Rows.Count, comboBox_Country.Text), "提示訊息") == DialogResult.OK)
                    {
                        for (int iRow = 0; iRow < DT_Copy.Rows.Count; iRow++)
                        {
                            Public.CPatComitContent ComitContent = new Public.CPatComitContent();
                            ComitContent.CountrySymbol = comboBox_Country.SelectedValue.ToString();
                            ComitContent.Sort = DT_Copy.Rows[iRow]["Sort"] != DBNull.Value ? (int)DT_Copy.Rows[iRow]["Sort"] : -1;
                            ComitContent.Status = DT_Copy.Rows[iRow]["Status"] != DBNull.Value ? (int)DT_Copy.Rows[iRow]["Status"] : -1;
                            ComitContent.ProcessKEY = DT_Copy.Rows[iRow]["ProcessKEY"] != DBNull.Value ? (int)DT_Copy.Rows[iRow]["ProcessKEY"] : -1;
                            ComitContent.ComitContent = DT_Copy.Rows[iRow]["ComitContent"].ToString();
                            ComitContent.Create();
                        }

                        but_Update_Click(null, null);
                        MessageBox.Show(string.Format("共貼上 {0} 筆", DT_Copy.Rows.Count), "提示訊息");
                    }

                    break;

                case "toolStripMenuItem_Excel":
                    try
                    {
                        Public.DLL dll = new Public.DLL();
                        Task task = dll.WriteToCSV(patComitContentTDataGridView);
                    }
                    catch
                    {
                        MessageBox.Show("匯出CSV失敗");
                    }
                    break;

            }
        } 
        #endregion

        private void comboBox_Country_SelectedIndexChanged(object sender, EventArgs e)
        {
            tagTitle2.TitleLableText = "指定的作業流程";
            this.qS_DataSet.ProcessStepET.Clear();

            if (comboBox_Country.SelectedValue != null)
            {
                upDataSet();
            }
        }


        #region 刷新按鈕 private void but_Update_Click(object sender, EventArgs e)
        /// <summary>
        /// 刷新按鈕
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void but_Update_Click(object sender, EventArgs e)
        {
            but_Update.Enabled = false;
            if (comboBox_Country.SelectedValue != null)
            {
                upDataSet();
            }
            but_Update.Enabled = true;
        } 
        #endregion

        private void patComitContentTDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = false;
        }

        private void patComitContentTDataGridView_CellLeave(object sender, DataGridViewCellEventArgs e)
        {
            //if (patComitContentTDataGridView.CurrentCell.ColumnIndex ==4 )
            //{
            //    if (patComitContentTDataGridView.CurrentRow.Cells["ProcessKEY"].Value != DBNull.Value && patComitContentTDataGridView.CurrentRow.Cells["ProcessKEY"].Value!=null)
            //    {
            //        int intProcessKEY = (int)patComitContentTDataGridView.CurrentRow.Cells["ProcessKEY"].Value;
            //        tagTitle2.TitleLableText = "指定的作業流程--" + patComitContentTDataGridView.CurrentRow.Cells["ProcessKEY"].FormattedValue;
            //        this.qS_DataSet.ProcessStepET.Clear();
            //        this.processStepETTableAdapter.Fill(this.qS_DataSet.ProcessStepET, intProcessKEY);
            //    }
            
            //}
        }

        private void patComitContentTDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (patComitContentTDataGridView.CurrentRow != null)
            {
                if (patComitContentTDataGridView.CurrentRow.Cells["ProcessKEY"].Value != DBNull.Value && (int)patComitContentTDataGridView.CurrentRow.Cells["ProcessKEY"].Value!=-1 && patComitContentTDataGridView.CurrentRow.Cells["ProcessKEY"].FormattedValue.ToString()!="")
                {
                    int intProcessKEY = (int)patComitContentTDataGridView.CurrentRow.Cells["ProcessKEY"].Value;
                    tagTitle2.TitleLableText = "指定的作業流程--" + patComitContentTDataGridView.CurrentRow.Cells["ProcessKEY"].FormattedValue;

                    this.qS_DataSet.ProcessStepET.Clear();
                    this.processStepETTableAdapter.Fill(this.qS_DataSet.ProcessStepET, intProcessKEY);
                    if (processStepETBindingSource.DataSource == null)
                    {
                        processStepETBindingSource.DataSource = this.qS_DataSet;
                        processStepETBindingSource.DataMember = "ProcessStepET";
                    }
                }
                else
                {
                    tagTitle2.TitleLableText = "指定的作業流程";
                    this.qS_DataSet.ProcessStepET.Clear();
                }
            }
            else
            {
                tagTitle2.TitleLableText = "指定的作業流程";
                this.qS_DataSet.ProcessStepET.Clear();
            }
        }

       
    }
}