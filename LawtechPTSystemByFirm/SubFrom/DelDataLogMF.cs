using System;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LawtechPTSystemByFirm.SubFrom
{
    /// <summary>
    /// 刪除記錄檔
    /// </summary>
    public partial class DelDataLogMF : Form
    {
        public DelDataLogMF()
        {
            InitializeComponent();
        }

        #region but_Search_Click
        private void but_Search_Click(object sender, EventArgs e)
        {
            but_Search.Enabled = false;

            string times = "";
            string sfilter = "";
            string strFilter1 = "";
            string sFinishDate = "";
           

            if (comboBox_SelectValue.Text == "" && comboBox_SelectValue1.Text == "" && maskedTextBox_S.Text == "    /  /" && maskedTextBox_D.Text == "    /  /")
            {
                sfilter = "";
            }
            else
            {
                DateTime dtS = new DateTime(), dtE = new DateTime();
                if (maskedTextBox_S.Text != "    /  /")
                {
                    bool IsS = DateTime.TryParse(maskedTextBox_S.Text, out dtS);
                    if (!IsS)
                    {
                        MessageBox.Show("日期格式錯誤 <<" + maskedTextBox_S.Text + ">>");
                        return;
                    }
                }

                if (maskedTextBox_D.Text != "    /  /")
                {
                    bool IsE = DateTime.TryParse(maskedTextBox_D.Text, out dtE);
                    if (!IsE)
                    {
                        MessageBox.Show("日期格式錯誤 <<" + maskedTextBox_D.Text + ">>");
                        return;
                    }
                }

                if (maskedTextBox_S.Text != "    /  /" && maskedTextBox_D.Text != "    /  /")
                {

                    if (dtS > dtE)
                    {
                        maskedTextBox_S.Text = dtE.ToString("yyyy/MM/dd");
                        maskedTextBox_D.Text = dtS.ToString("yyyy/MM/dd");
                    }
                }


                string strDateMode = comboBox_DateMode.SelectedValue.ToString();

                if (maskedTextBox_S.Text != "    /  /" && maskedTextBox_D.Text == "    /  /")
                {
                    times += " " + strDateMode + ">='" + maskedTextBox_S.Text + "'";
                }
                else if (maskedTextBox_S.Text == "    /  /" && maskedTextBox_D.Text != "    /  /")
                {
                    times += " " + strDateMode + "<='" + maskedTextBox_D.Text + "'";
                }
                else if (maskedTextBox_S.Text != "    /  /" && maskedTextBox_D.Text != "    /  /")
                {
                    times += " (" + strDateMode + " >= '" + maskedTextBox_S.Text + "' and " + strDateMode + "<= '" + maskedTextBox_D.Text + "')";
                }

                #region Select 1
                if (comboBox_SelectValue.Text.Trim() != "" || comboBox_SelectValue.SelectedValue != null)
                {
                    switch (comboBox_Select.SelectedValue.ToString())
                    {
                     
                        case "DelContent":
                        case "DelTitle":
                            sfilter = comboBox_Select.SelectedValue.ToString() + " like '%" + comboBox_SelectValue.Text + "%' ";
                            break;
                        case "DelWorkerKey":
                            if (comboBox_SelectValue.SelectedValue != null)
                            {
                                sfilter = comboBox_Select.SelectedValue.ToString() + " = " + comboBox_SelectValue.SelectedValue.ToString();
                            }
                            else
                            {
                                comboBox_SelectValue.Text = "";
                            }
                            break;
                    }
                }
                #endregion

                #region Select 2

                if (comboBox_SelectValue1.Text.Trim() != "" || comboBox_SelectValue1.SelectedValue != null)
                {
                    switch (comboBox_Select1.SelectedValue.ToString())
                    {
                        case "DelContent":
                        case "DelTitle":
                            strFilter1 = comboBox_Select1.SelectedValue.ToString() + " like '%" + comboBox_SelectValue1.Text + "%' ";
                            break;

                        case "DelWorkerKey":
                            if (comboBox_SelectValue1.SelectedValue != null)
                            {
                                strFilter1 = comboBox_Select1.SelectedValue.ToString() + " = " + comboBox_SelectValue1.SelectedValue.ToString() ;
                            }
                            else
                            {
                                comboBox_SelectValue1.Text = "";
                            }
                            break;
                    }
                }
                #endregion

                but_Search.Enabled = true;
            }

            string FullFilter = "";
            if (strFilter1 != "" && sfilter != "")
            {
                string AndOr = "";
                if (rb_and.Checked)
                {
                    AndOr = " and ";
                    FullFilter = strFilter1 + AndOr + sfilter;
                }
                else
                {
                    AndOr = " or ";
                    FullFilter = "(" + strFilter1 + AndOr + sfilter + ")";
                }

            }
            else if (strFilter1 == "" && sfilter == "")
            {
                FullFilter = "";
            }
            else
            {
                if (strFilter1 != "")
                {
                    FullFilter = strFilter1;
                }
                else
                {
                    FullFilter = sfilter;
                }
            }

            string[] sWhere = { times, sFinishDate, FullFilter };

            StringBuilder FullWhere = new StringBuilder();
            for (int iArray = 0; iArray < sWhere.Length; iArray++)
            {
                if (sWhere[iArray] != "")
                {
                    if (FullWhere.Length > 0)
                    {
                        FullWhere.Append(" and ");
                    }
                    FullWhere.Append(sWhere[iArray]);
                }
            }

            GetDelLog(FullWhere.ToString());
        }
        #endregion

        #region GetFeeEvent 取得刪除歷史記錄的資料
        /// <summary>
        /// 取得刪除歷史記錄的資料
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public void GetDelLog(string strWhere)
        {            
            string strPatentFeeSQL = string.Format(
                                    @"
                                        SELECT         SystemLogT.SysLogID, SystemLogT.DelWorkerKey, SystemLogT.DelTime, 
                                                                  SystemLogT.DelTitle, SystemLogT.DelContent, 
                                                                  WorkerT.EmployeeName AS DelWorkerKey
                                        FROM             SystemLogT LEFT OUTER JOIN
                                                                  WorkerT ON SystemLogT.DelWorkerKey = WorkerT.WorkerKey {0}
                                        ORDER BY  SystemLogT.DelTime DESC
                                      ", strWhere);

            Public.DLL dll = new LawtechPTSystemByFirm.Public.DLL();
          
           dll.FetchDataTable(strPatentFeeSQL,this.dataSet_DelDataLog.SystemLogT);
            
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
            Public.PublicForm Forms = new LawtechPTSystemByFirm.Public.PublicForm();
            Forms.DelDataLogMF = this;

            this.logSearchDataTableAdapter.Fill(this.dataSet_DelDataLog.LogSearchData);           

            this.logSearchValueTableAdapter.Fill(this.dataSet_DelDataLog.LogSearchValue);
            this.systemLogTTableAdapter.Fill(this.dataSet_DelDataLog.SystemLogT);

            comboBox_Select.SelectedIndex = 2;
            comboBox_Select1.SelectedIndex = 1;

        }


        private void DelDataLogMF_FormClosed(object sender, FormClosedEventArgs e)
        {
            Public.PublicForm Forms = new LawtechPTSystemByFirm.Public.PublicForm();
            Forms.DelDataLogMF = null;
        }

        #endregion

        #region but_Excel_Click
        private void but_Excel_Click(object sender, EventArgs e)
        {
            try
            {
                Public.DLL dll = new LawtechPTSystemByFirm.Public.DLL();
                Task t = dll.WriteToCSV(systemLogTDataGridView);
            }
            catch
            {
                MessageBox.Show("匯出CSV失敗:匯出過程發生異常被終止");
            }
        }
        #endregion

        #region maskedTextBox_S_DoubleClick
        private void maskedTextBox_S_DoubleClick(object sender, EventArgs e)
        {
            MaskedTextBox mtb = (MaskedTextBox)sender;
            DateTime dt;
            bool IsSuccess = DateTime.TryParse(mtb.Text, out dt);
            if (!IsSuccess)
            {
                mtb.Text = DateTime.Now.ToString("yyyy/MM/dd");
            }
        }
        #endregion

        #region systemLogTDataGridView_DataError
        private void systemLogTDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = false;
        }
        #endregion

        #region comboBox_Select_SelectedIndexChanged
        private void comboBox_Select_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            Public.DLL dll = new LawtechPTSystemByFirm.Public.DLL();
            string strSQL = "";
            if (comboBox_Select.SelectedValue != null)
            {
                switch (comboBox_Select.SelectedValue.ToString())
                {
                    case "DelTitle"://主旨

                        strSQL = "select distinct DelTitle from SystemLogT order by DelTitle";
                        dt = dll.SqlDataAdapterDataTable(strSQL);
                        comboBox_SelectValue.DropDownStyle = ComboBoxStyle.DropDown;
                        comboBox_SelectValue.AutoCompleteSource = AutoCompleteSource.ListItems;
                        comboBox_SelectValue.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                        comboBox_SelectValue.DataSource = dt;
                        comboBox_SelectValue.DisplayMember = "DelTitle";
                        comboBox_SelectValue.ValueMember = "DelTitle";
                        comboBox_SelectValue.Text = "";
                        break;
                    case "DelWorkerKey"://刪除者

                        strSQL = "select WorkerKey,ISNULL(NameEn,'')+ Name as WorkerName from WorkerT order by ISNULL(NameEn,'')+ Name";
                        dt = dll.SqlDataAdapterDataTable(strSQL);
                        comboBox_SelectValue.DropDownStyle = ComboBoxStyle.DropDown;
                        comboBox_SelectValue.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                        comboBox_SelectValue.AutoCompleteSource = AutoCompleteSource.ListItems;                        
                        comboBox_SelectValue.DataSource = dt;
                        comboBox_SelectValue.DisplayMember = "WorkerName";
                        comboBox_SelectValue.ValueMember = "WorkerKey";
                       
                        break;
                    default:
                        comboBox_SelectValue.AutoCompleteMode = AutoCompleteMode.None;
                        comboBox_SelectValue.AutoCompleteSource = AutoCompleteSource.None;                        
                        comboBox_SelectValue.DropDownStyle = ComboBoxStyle.Simple;
                        comboBox_SelectValue.Text = "";
                        break;
                }
            }
        }
        #endregion

        #region comboBox_Select1_SelectedIndexChanged
        private void comboBox_Select1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            Public.DLL dll = new LawtechPTSystemByFirm.Public.DLL();
            string strSQL = "";
            if (comboBox_Select1.SelectedValue != null)
            {
                switch (comboBox_Select1.SelectedValue.ToString())
                {
                    case "DelTitle"://主旨

                        strSQL = "select distinct DelTitle from SystemLogT order by DelTitle";
                        dt = dll.SqlDataAdapterDataTable(strSQL);
                        comboBox_SelectValue1.DropDownStyle = ComboBoxStyle.DropDown;
                        comboBox_SelectValue1.AutoCompleteSource = AutoCompleteSource.ListItems;
                        comboBox_SelectValue1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                        comboBox_SelectValue1.DataSource = dt;
                        comboBox_SelectValue1.DisplayMember = "DelTitle";
                        comboBox_SelectValue1.ValueMember = "DelTitle";
                        comboBox_SelectValue1.Text = "";
                        break;
                    case "DelWorkerKey"://主旨

                        strSQL = "select WorkerKey,ISNULL(NameEn,'')+ Name as WorkerName from WorkerT order by ISNULL(NameEn,'')+ Name";
                        dt = dll.SqlDataAdapterDataTable(strSQL);
                        comboBox_SelectValue1.DropDownStyle = ComboBoxStyle.DropDown;
                        comboBox_SelectValue1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                        comboBox_SelectValue1.AutoCompleteSource = AutoCompleteSource.ListItems;
                        comboBox_SelectValue1.DataSource = dt;
                        comboBox_SelectValue1.DisplayMember = "WorkerName";
                        comboBox_SelectValue1.ValueMember = "WorkerKey";

                        break;
                    default:
                        comboBox_SelectValue1.AutoCompleteMode = AutoCompleteMode.None;
                        comboBox_SelectValue1.AutoCompleteSource = AutoCompleteSource.None;
                        comboBox_SelectValue1.DropDownStyle = ComboBoxStyle.Simple;
                        comboBox_SelectValue1.Text = "";
                        break;
                }
            }
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
                    Public.CSystemLog syslog = new LawtechPTSystemByFirm.Public.CSystemLog();
                    Public.CSystemLog.ReadOne(Key, ref syslog);
                   

                    Public.DLL dll = new LawtechPTSystemByFirm.Public.DLL();
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

    }
}
