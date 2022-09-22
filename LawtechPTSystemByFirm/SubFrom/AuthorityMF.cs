using System;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LawtechPTSystemByFirm.SubFrom
{
    /// <summary>
    /// 員工/權限管理
    /// </summary>
    public partial class AuthorityMF : Form
    {
        UserPermissionForm myPermission;
        private const string strProgramSymbol = "AuthorityMF";
        private const string SourceTableName = "ProgramT";
        public AuthorityMF()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;
            dataGridView2.AutoGenerateColumns = false;
            Public.DynamicGridViewColumn.GetGridColum(ref dataGridView1);
        }

        #region 自訂變數
        DataTable dtWorkers=new DataTable() ;
        /// <summary>
        /// 員工資料表
        /// </summary>
        public DataTable DtWorkers
        {
            get { return dtWorkers; }
            set { dtWorkers = value; }
        }

        BindingSource bs_Workers;

        internal DataTable dt_Auth;
        BindingSource bs_Auth;
        #endregion

        #region ==============AuthorityMF_Load    AuthorityMF_FormClosed================
        private void AuthorityMF_Load(object sender, EventArgs e)
        {
            // TODO: 這行程式碼會將資料載入 'dataSet_Drop.ProgramKindT' 資料表。您可以視需要進行移動或移除。
            this.programKindTTableAdapter.Fill(this.dataSet_Drop.ProgramKindT);
            Public.PublicForm Forms = new LawtechPTSystemByFirm.Public.PublicForm();
            Forms.AuthorityMF = this;

            //取得權限
            myPermission = new UserPermissionForm(Properties.Settings.Default.WorkerKEY, strProgramSymbol);

            System.Windows.Forms.BindingNavigator[] listbinding = { bindingNavigator1 };
            System.Windows.Forms.ContextMenuStrip[] listtMenu = { contextMenuStrip1 };

            //確認可使用的功能選單
            Public.CommonFunctions.CheckMeunItemVisible(listbinding, myPermission.UserPermission);
            Public.CommonFunctions.CheckMeunItemVisible(listtMenu, myPermission.UserPermission);


            //系統角色資料
            this.officeRoleTTableAdapter.Fill(this.qS_DataSet.OfficeRoleT);

            
            ViewModel_Worker.GetDataTable( ref dtWorkers);

            dt_Auth = new DataTable();
            bs_Auth = new BindingSource();


            bs_Workers = new BindingSource();
            bs_Workers.DataSource = dtWorkers;

            dataGridView1.DataSource = bs_Workers;
            bindingNavigator1.BindingSource = bs_Workers;

            

            dtWorkers.ColumnChanged += new DataColumnChangeEventHandler(WorkerT_ColumnChanged);
            //dtWorkers.RowDeleting += new DataRowChangeEventHandler(WorkerT_RowDeleting);

            ControlBind();
           
            bs_Auth.DataSource = dt_Auth;
            bindingNavigator_AuthProgram.BindingSource = bs_Auth;
            dataGridView2.DataSource = bs_Auth;

            dt_Auth.ColumnChanged += new DataColumnChangeEventHandler(WorkerProgramT_ColumnChanged);
            
            comboBox1.SelectedIndex = 0;
            ControlBindingAuth();
        }

        private void Authority()
        {
            string sSQL = "";
            string sKind="1";
            if (comboBox1.SelectedValue != null)
            {
                sKind = comboBox1.SelectedValue.ToString();
            }

            sSQL = string.Format(@"SELECT     ProgramT.ProgramKEY, ProgramT.ProgramName, ProgramT.ProgramSymbol,ProgramT.[Description] ,                          
                                         (SELECT     SearchAuthority
                                            FROM          WorkerProgramT AS WorkerProgramT_2
                                            WHERE      (ProgramT.ProgramKEY = ProgramKEY)AND (WorkerKEY = {1} ) )AS SearchAuthority ,
                                             (SELECT     AuthorizeCreate
                                            FROM          WorkerProgramT AS WorkerProgramT_2
                                            WHERE      (ProgramT.ProgramKEY = ProgramKEY)AND (WorkerKEY = {1} ) )AS AuthorizeCreate,
                                             (SELECT     AuthorizeModify
                                            FROM          WorkerProgramT AS WorkerProgramT_2
                                            WHERE      (ProgramT.ProgramKEY = ProgramKEY)AND (WorkerKEY ={1} ) )AS AuthorizeModify,
                                             (SELECT     AuthorizeDelete
                                            FROM          WorkerProgramT AS WorkerProgramT_2
                                            WHERE      (ProgramT.ProgramKEY = ProgramKEY)AND (WorkerKEY = {1} ) )AS AuthorizeDelete,
                                             (SELECT     AuthorizeDownload
                                            FROM          WorkerProgramT AS WorkerProgramT_2
                                            WHERE      (ProgramT.ProgramKEY = ProgramKEY)AND (WorkerKEY = {1} ) )AS AuthorizeDownload,
                                             (SELECT     AuthorizeExport
                                            FROM          WorkerProgramT AS WorkerProgramT_2
                                            WHERE      (ProgramT.ProgramKEY = ProgramKEY)AND (WorkerKEY = {1} ) )AS AuthorizeExport ,
                                            (SELECT     AuthorizeUpload
                                            FROM          WorkerProgramT AS WorkerProgramT_2
                                            WHERE      (ProgramT.ProgramKEY = ProgramKEY)AND (WorkerKEY = {1} ) )AS AuthorizeUpload                         
                                    FROM         ProgramT 
                                    where ProgramT.IsOpen=1 and (ProgramT.ProgramKind ={0}) order by Sort", sKind, dataGridView1.CurrentRow.Cells["WorkerKey"].Value.ToString());

            Public.DLL dll = new LawtechPTSystemByFirm.Public.DLL();
            if (dt_Auth != null)
            {
                dt_Auth.Rows.Clear();
            }
            dll.FetchDataTable(sSQL, dt_Auth);

            bs_Auth.DataSource = dt_Auth;

        }

        private void AuthorityMF_FormClosed(object sender, FormClosedEventArgs e)
        {
            Public.PublicForm Forms = new LawtechPTSystemByFirm.Public.PublicForm();
            Forms.AuthorityMF = null;
        }
        #endregion

        #region =========ControlBind===========
        private void ControlBind()
        {
            txt_WorkerId.DataBindings.Clear();
            txt_WorkerId.DataBindings.Add("Text", bs_Workers, "WorkerSymbol", true, DataSourceUpdateMode.OnPropertyChanged, "", "");

            txt_Name.DataBindings.Clear();
            txt_Name.DataBindings.Add("Text", bs_Workers, "EmployeeName", true, DataSourceUpdateMode.OnPropertyChanged, "", "");

            txt_NameEn.DataBindings.Clear();
            txt_NameEn.DataBindings.Add("Text", bs_Workers, "EmployeeNameEn", true, DataSourceUpdateMode.OnPropertyChanged, "", "");

            txt_TEL.DataBindings.Clear();
            txt_TEL.DataBindings.Add("Text", bs_Workers, "TEL", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_ext.DataBindings.Clear();
            txt_ext.DataBindings.Add("Text", bs_Workers, "ext", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_ID.DataBindings.Clear();
            txt_ID.DataBindings.Add("Text", bs_Workers, "EmployeeID", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_LoginName.DataBindings.Clear();
            txt_LoginName.DataBindings.Add("Text", bs_Workers, "Account", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_Password.DataBindings.Clear();
            txt_Password.DataBindings.Add("Text", bs_Workers, "Password", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_Mobilephone.DataBindings.Clear();
            txt_Mobilephone.DataBindings.Add("Text", bs_Workers, "Mobilephone", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_Email.DataBindings.Clear();
            txt_Email.DataBindings.Add("Text", bs_Workers, "Email", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_EverAddr.DataBindings.Clear();
            txt_EverAddr.DataBindings.Add("Text", bs_Workers, "EverAddr", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_Addr.DataBindings.Clear();
            txt_Addr.DataBindings.Add("Text", bs_Workers, "Addr", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_Background.DataBindings.Clear();
            txt_Background.DataBindings.Add("Text", bs_Workers, "Background", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_Experience.DataBindings.Clear();
            txt_Experience.DataBindings.Add("Text", bs_Workers, "Experience", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_Specialty.DataBindings.Clear();
            txt_Specialty.DataBindings.Add("Text", bs_Workers, "Specialty", true, DataSourceUpdateMode.OnValidation);

            txt_SingOffCode.DataBindings.Clear();
            txt_SingOffCode.DataBindings.Add("Text", bs_Workers, "SingCode", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_WorkScope.DataBindings.Clear();
            txt_WorkScope.DataBindings.Add("Text", bs_Workers, "WorkScope", true, DataSourceUpdateMode.OnValidation, "", "");

            maskedTextBox_Birthday.DataBindings.Clear();
            maskedTextBox_Birthday.DataBindings.Add("Text", bs_Workers, "Birthday", true, DataSourceUpdateMode.OnPropertyChanged, "", "yyyy/MM/dd");

            maskedTextBox_ReachDay.DataBindings.Clear();
            maskedTextBox_ReachDay.DataBindings.Add("Text", bs_Workers, "ReachDay", true, DataSourceUpdateMode.OnPropertyChanged, "", "yyyy/MM/dd");

            maskedTextBox_DepartDay.DataBindings.Clear();
            maskedTextBox_DepartDay.DataBindings.Add("Text", bs_Workers, "DepartDay", true, DataSourceUpdateMode.OnValidation, "", "yyyy/MM/dd");

            checkBox_Quit.DataBindings.Clear();
            checkBox_Quit.DataBindings.Add("Checked", bs_Workers, "IsQuit");

            comboBox_OfficeRole.DataBindings.Clear();
            comboBox_OfficeRole.DataBindings.Add("SelectedValue", bs_Workers, "OfficeRole", false, DataSourceUpdateMode.OnValidation);

           
        }

        private void ControlBindingAuth()
        {
            txt_Description.DataBindings.Clear();
            txt_Description.DataBindings.Add("Text", bs_Auth, "Description", false, DataSourceUpdateMode.Never, "", "");
        }
        #endregion

        #region WorkerProgramT_ColumnChanged
        private void WorkerProgramT_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            if (e.Row.RowState == DataRowState.Unchanged)
            {
                int iProgramKEY = (int)dataGridView2.CurrentRow.Cells["ProgramKEY"].Value;
                int iWorkerKEY = (int)dataGridView1.CurrentRow.Cells["WorkerKey"].Value;

                Public.CWorkerProgram wp = new Public.CWorkerProgram();
                Public.CWorkerProgram.ReadOne(string.Format("ProgramKEY={0} and WorkerKEY={1}", iProgramKEY.ToString(), iWorkerKEY.ToString()), ref wp);

                switch (e.Column.ColumnName)
                {
                    case "SearchAuthority":
                        wp.SearchAuthority = e.ProposedValue != DBNull.Value ? (bool)e.ProposedValue : false;
                        break;
                    case "AuthorizeCreate":
                        wp.AuthorizeCreate = e.ProposedValue != DBNull.Value ? (bool)e.ProposedValue : false;
                        if (wp.AuthorizeCreate.HasValue)
                        {
                            wp.SearchAuthority = true;
                        }
                        break;
                    case "AuthorizeModify":
                        wp.AuthorizeModify = e.ProposedValue != DBNull.Value ? (bool)e.ProposedValue : false;
                        if (wp.AuthorizeModify.HasValue)
                        {
                            wp.SearchAuthority = true;
                        }
                        break;
                    case "AuthorizeDelete":
                        wp.AuthorizeDelete = e.ProposedValue != DBNull.Value ? (bool)e.ProposedValue : false;
                        if (wp.AuthorizeDelete.HasValue)
                        {
                            wp.SearchAuthority = true;
                        }
                        break;
                    case "AuthorizeDownload":
                        wp.AuthorizeDownload = e.ProposedValue != DBNull.Value ? (bool)e.ProposedValue : false;
                        if (wp.AuthorizeDownload.HasValue)
                        {
                            wp.SearchAuthority = true;
                        }
                        break;
                    case "AuthorizeExport":
                        wp.AuthorizeExport = e.ProposedValue != DBNull.Value ? (bool)e.ProposedValue : false;
                        if (wp.AuthorizeExport.HasValue)
                        {
                            wp.SearchAuthority = true;
                        }
                        break;
                    case "AuthorizeUpload":
                        wp.AuthorizeUpload = e.ProposedValue != DBNull.Value ? (bool)e.ProposedValue : false;
                        if (wp.AuthorizeUpload.HasValue)
                        {
                            wp.SearchAuthority = true;
                        }
                        break;
                }
                if (wp.PWID > 0)
                {
                    wp.Update();
                }
                else
                {
                    wp.WorkerKEY = iWorkerKEY;
                    wp.ProgramKEY = iProgramKEY;
                    wp.Create();
                }




            }
        }
        #endregion

        #region  =============WorkerT_ColumnChanged事件===============
        private void WorkerT_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            if (e.Row.RowState == DataRowState.Unchanged)
            {
                int iPkey = (int)e.Row["WorkerKey"];

                Worker_Model CA_CWorker = new Worker_Model();
                Worker_Model.ReadOne(iPkey,ref CA_CWorker);
               
                switch (e.Column.ColumnName)
                {
                    case "EmployeeName":
                        CA_CWorker.EmployeeName = e.ProposedValue != null ? e.ProposedValue.ToString() : "";
                        break;
                    case "EmployeeNameEn":
                        CA_CWorker.EmployeeNameEn = e.ProposedValue != null ? e.ProposedValue.ToString() : "";
                        break;
                    case "ext":
                        CA_CWorker.ext = e.ProposedValue != null ? e.ProposedValue.ToString() : "";
                        break;
                    case "Account":
                        CA_CWorker.Account = e.ProposedValue != null ? e.ProposedValue.ToString() : "";
                        break;
                    case "Email":
                        CA_CWorker.Email = e.ProposedValue != null ? e.ProposedValue.ToString() : "";
                        break;
                    case "TEL":
                        CA_CWorker.TEL = e.ProposedValue != null ? e.ProposedValue.ToString() : "";
                        break;
                    case "EmployeeID":
                        CA_CWorker.EmployeeID = e.ProposedValue != null ? e.ProposedValue.ToString() : "";
                        break;
                    case "Birthday":
                        if (e.ProposedValue != DBNull.Value)
                        {
                            CA_CWorker.Birthday = (DateTime)e.ProposedValue;
                        }
                        else
                        {
                            CA_CWorker.Birthday = null;
                        }
                        break;
                    case "ReachDay":                       
                        if (e.ProposedValue != DBNull.Value)
                        {
                            CA_CWorker.ReachDay = (DateTime)e.ProposedValue;
                        }
                        else
                        {
                            CA_CWorker.ReachDay = null;
                        }
                        break;
                    case "DepartDay":                      
                        if (e.ProposedValue != DBNull.Value)
                        {
                            CA_CWorker.DepartDay = (DateTime)e.ProposedValue;
                        }
                        else
                        {
                            CA_CWorker.DepartDay = null;
                        }
                        break;
                    case "Urgent":
                        CA_CWorker.Urgent = e.ProposedValue != null ? e.ProposedValue.ToString() : "";
                        break;
                    case "EverAddr":
                        CA_CWorker.EverAddr = e.ProposedValue != null ? e.ProposedValue.ToString() : "";
                        break;
                    case "Addr":
                        CA_CWorker.Addr = e.ProposedValue != null ? e.ProposedValue.ToString() : "";
                        break;
                    case "Mobilephone":
                        CA_CWorker.Mobilephone = e.ProposedValue != null ? e.ProposedValue.ToString() : "";
                        break;
                    case "Remark":
                        CA_CWorker.Remark = e.ProposedValue != null ? e.ProposedValue.ToString() : "";
                        break;
                    case "WorkerSymbol":
                        CA_CWorker.WorkerSymbol = e.ProposedValue != null ? e.ProposedValue.ToString() : "";
                        break;
                    case "IsQuit":
                        CA_CWorker.IsQuit = e.ProposedValue != DBNull.Value ? (bool)e.ProposedValue : false;
                        break;
                    case "FullDeptName":
                        CA_CWorker.FullDeptName = e.ProposedValue != null ? e.ProposedValue.ToString() : "";
                        break;
                    case "FullDeptKEY":
                        CA_CWorker.FullDeptKEY = e.ProposedValue != null ? e.ProposedValue.ToString() : "";
                        break;
                    case "Password":
                        CA_CWorker.Password = e.ProposedValue != null ? e.ProposedValue.ToString() : "";
                        break;
                    case "Position":
                        CA_CWorker.Position = e.ProposedValue != null ? e.ProposedValue.ToString() : "";
                        break;
                    case "Background":
                        CA_CWorker.Background = e.ProposedValue != null ? e.ProposedValue.ToString() : "";
                        break;
                    case "Experience":
                        CA_CWorker.Experience = e.ProposedValue != null ? e.ProposedValue.ToString() : "";
                        break;
                    case "Specialty":
                        CA_CWorker.Specialty = e.ProposedValue != null ? e.ProposedValue.ToString() : "";
                        break;
                    case "OfficeRole":
                        CA_CWorker.OfficeRole = e.ProposedValue != null ? (int)e.ProposedValue : -1;
                        break;
                    case "SingCode":
                        CA_CWorker.SingCode = e.ProposedValue != null ? e.ProposedValue.ToString() : "";
                        break;
                    case "WorkScope":
                        CA_CWorker.WorkScope = e.ProposedValue != null ? e.ProposedValue.ToString() : "";
                        break;
                }
                CA_CWorker.LastModifyWorker = Properties.Settings.Default.WorkerName;
                CA_CWorker.Update();

                dtWorkers.AcceptChanges();
            }
        }
        #endregion       

        #region ==========新增員工快顯==========
        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            contextMenuStrip1.Visible = false;

            switch (e.ClickedItem.Name)
            {
                case "toolStripButtonAdd":
                case "AddToolStripMenuItem":
                    AddFrom.AddWorker add = new LawtechPTSystemByFirm.AddFrom.AddWorker();
                    add.ShowDialog();
                break;
                case "toolStripButtonDel":
            case "DelToolStripMenuItem":
                if (dataGridView1.CurrentRow != null)
                {                 

                    if (MessageBox.Show("是否確定刪除(" + dataGridView1.CurrentRow.Cells["WorkerName"].Value.ToString() + ")??", "提示訊息", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                    {
                        Worker_Model CA_CWorker = new Worker_Model();
                        
                        CA_CWorker.Delete((int)dataGridView1.CurrentRow.Cells["WorkerKey"].Value);

                        dataGridView1.Rows.Remove(dataGridView1.CurrentRow);
                        dtWorkers.AcceptChanges();

                        MessageBox.Show("刪除成功");
                    }
                }
                    break;

            case "toolStripMenuItem_Orientation":
                    toolStripButton1_Click(null,null);
                    break;

            case "toolStripMenuItem_Report":

                    break;
            case "toolStripMenuItem_Export":
            case "toolStripButton_Export":
                    try
                    {
                        Public.DLL dll = new LawtechPTSystemByFirm.Public.DLL();
                        Task task = dll.WriteToCSV(dataGridView1);
                       
                    }
                    catch
                    {
                        MessageBox.Show("匯出CSV失敗");
                    }
                    break;
            }
        }
        #endregion

        #region ==========關閉按鈕==========
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Authority();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex != -1 && dataGridView1.CurrentRow != null)
            {
                Authority();
            }
        }

        private void comboBox_OfficeRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_OfficeRole.SelectedValue != null && (int)comboBox_OfficeRole.SelectedValue != 1)
            {
                lab_SingOffCode.Visible = true;
                txt_SingOffCode.Visible = true;
            }
            else
            {
                lab_SingOffCode.Visible = false;
                txt_SingOffCode.Visible = false;
            }
        }

        private void label15_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView2.CurrentRow != null)
            {
                Public.DLL dll = new LawtechPTSystemByFirm.Public.DLL();
                string strSQL = string.Format("update ProgramT set Description='{0}' where ProgramKEY={1} ", txt_Description.Text, dataGridView2.CurrentRow.Cells["ProgramKEY"].Value.ToString());
                dll.SQLexecuteNonQuery(strSQL);
            }



        }

        #region contextMenuStrip2_ItemClicked
        private void contextMenuStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Name)
            {
                case "ToolStripMenuItem_Excel":

                    try
                    {
                        Public.DLL dll = new LawtechPTSystemByFirm.Public.DLL();
                        Task task = dll.WriteToCSV(dataGridView2);
                    }
                    catch
                    {
                        MessageBox.Show("匯出Excel失敗:匯出過程發生異常被終止");
                    }
                    break;
            }
        }
        #endregion

        #region btnOpenDetail_Click 開啟/關閉 明細
        private void btnOpenDetail_Click(object sender, EventArgs e)
        {
            string status = Public.CommonFunctions.splitContainerCollapsed(splitContainer1);

            if (status == "Open")
            {
                btnOpenDetail.Text = "關閉明細";
            }
            else
            {
                btnOpenDetail.Text = "開啟明細";
            }
        }
        #endregion

        #region btnSearch_Click 查詢按鈕
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string filter = Public.CommonFunctions.GetSQLScript(QueryFilter1, QueryFilter2, Radio_and.Checked ? "and " : "or", userControlFilterDate1);
            bs_Workers.Filter = filter;
        }
        #endregion

        #region maskedTextBox 按兩下填入當天日期
        private void maskedTextBox_Birthday_DoubleClick(object sender, EventArgs e)
        {
            MaskedTextBox masked = (MaskedTextBox)sender;
            Public.CommonFunctions.MaskedTextBoxDoubleClick(masked);
        }
        #endregion

        #region btnClearWhere_Click 清空查詢條件
        private void btnClearWhere_Click(object sender, EventArgs e)
        {
            userControlFilterDate1.ClearMaskedTextBox();

            QueryFilter1.ComboBoxSearchColumn.SelectedIndex = 0;
            QueryFilter1.ComboBoxSelectedValue.Text = "";

            QueryFilter2.ComboBoxSearchColumn.SelectedIndex = 0;
            QueryFilter2.ComboBoxSelectedValue.Text = "";
        }
        #endregion

        #region dataGridView1_DataError
        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = false;
        } 
        #endregion

        private void userControlFilterDate1_Load(object sender, EventArgs e)
        {

        }

        private void QueryFilter1_Load(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Public.Utility.SsplitContainerHorizontal(ref splitContainer1);
        }

        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            dtWorkers.Rows.Clear();
            ViewModel_Worker.GetDataTable(ref dtWorkers);
        }

        private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView2.CurrentCell != null && dataGridView2.Columns[dataGridView2.CurrentCell.ColumnIndex].Name == "ProgramName")
            {
                bool IsCheck = dataGridView2.CurrentRow.Cells["SearchAuthority"].Value != DBNull.Value ? (bool)dataGridView2.CurrentRow.Cells["SearchAuthority"].Value : false;

                dataGridView2.CurrentRow.Cells["SearchAuthority"].Value = !IsCheck;
                dataGridView2.CurrentRow.Cells["AuthorizeCreate"].Value = !IsCheck;
                dataGridView2.CurrentRow.Cells["AuthorizeModify"].Value = !IsCheck;
                dataGridView2.CurrentRow.Cells["AuthorizeDelete"].Value = !IsCheck;
                dataGridView2.CurrentRow.Cells["AuthorizeExport"].Value = !IsCheck;
                dataGridView2.CurrentRow.Cells["AuthorizeUpload"].Value = !IsCheck;
                dataGridView2.CurrentRow.Cells["AuthorizeDownload"].Value = !IsCheck;
            }
        }
        

    }
}