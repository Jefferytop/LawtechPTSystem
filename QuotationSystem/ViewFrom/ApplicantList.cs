using System;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LawtechPTSystem.ViewFrom
{
    /// <summary>
    /// 申請人資料列表
    /// </summary>
    public partial class ApplicantList : Form
    {
        UserPermissionForm myPermission;
        private const string ProgramSymbol = "ApplicantList";
        private const string SourceTableName = "ApplicantT";

        DataTable dtLiaisonerTem;

        #region Public Property  

        private int iMainType = 1;
        /// <summary>
        /// 1: 專利  ;  2: 商標 ; 預設為 1
        /// </summary>
        public int MainType
        {
            get { return iMainType; }
            set { iMainType = value; }
        }

        private int iMainKey = -1;
        /// <summary>
        ///  專利或商標的案件key值
        /// </summary>
        public int MainKey
        {
            get { return iMainKey; }
            set { iMainKey = value; }
        }
        private DataTable dt_ApplicantSearchT = new DataTable();
        /// <summary>
        /// 申請人資料集
        /// </summary>
        public DataTable DT_ApplicantSearchT
        {
            get { return dt_ApplicantSearchT; }
            set { dt_ApplicantSearchT = value; }
        }

      

        private DataTable dt_InventorT = new DataTable();
        /// <summary>
        /// 發明人資料集
        /// </summary>
        public DataTable DT_Inventor
        {
            get { return dt_InventorT; }
            set { dt_InventorT = value; }
        }

        /// <summary>
        /// 取得目前該申請人的Key值
        /// </summary>
        public int ProApplicantKey
        {
            get
            {
                if (GridView_Applicant.CurrentRow != null)
                {
                    return (int)GridView_Applicant.CurrentRow.Cells["ApplicantKey"].Value;
                }
                else
                {
                    return -1;
                }
            }
        } 
        #endregion

        public ApplicantList()
        {
            InitializeComponent();
            GridView_Applicant.AutoGenerateColumns = false;         
            inventorTDataGridView.AutoGenerateColumns = false;           

            Public.DynamicGridViewColumn.GetGridColum(ref GridView_Applicant);          

            Public.DynamicGridViewColumn.GetGridColum(ref inventorTDataGridView);       
        }

        #region but_Close_Click
        private void but_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
      
        #region ===========Init============
        public void Init()
        {
            txt_ApplicantName.DataBindings.Clear();
            txt_ApplicantName.DataBindings.Add("Text", applicantTBindingSource, "ApplicantName", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_ApplicantNameEn.DataBindings.Clear();
            txt_ApplicantNameEn.DataBindings.Add("Text", applicantTBindingSource, "ApplicantNameEn", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_PrincipalName.DataBindings.Clear();
            txt_PrincipalName.DataBindings.Add("Text", applicantTBindingSource, "PrincipalName", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_PrincipalNameEn.DataBindings.Clear();
            txt_PrincipalNameEn.DataBindings.Add("Text", applicantTBindingSource, "PrincipalNameEn", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_Addr.DataBindings.Clear();
            txt_Addr.DataBindings.Add("Text", applicantTBindingSource, "Address", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_AddrEn.DataBindings.Clear();
            txt_AddrEn.DataBindings.Add("Text", applicantTBindingSource, "AddressEn", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_LiaisonAddr.DataBindings.Clear();
            txt_LiaisonAddr.DataBindings.Add("Text", applicantTBindingSource, "ContactAddr", true, DataSourceUpdateMode.OnValidation, "", "");

            //客戶代碼
            txt_ApplicantSymbol.DataBindings.Clear();
            txt_ApplicantSymbol.DataBindings.Add("Text", applicantTBindingSource, "ApplicantSymbol", true, DataSourceUpdateMode.OnValidation, "", "");

            //資本額
            txt_Capital.DataBindings.Clear();
            txt_Capital.DataBindings.Add("Text", applicantTBindingSource, "Capital", true, DataSourceUpdateMode.OnValidation, "", "");

            //收款記錄
            txt_CollectionRecord.DataBindings.Clear();
            txt_CollectionRecord.DataBindings.Add("Text", applicantTBindingSource, "CollectionRecord", true, DataSourceUpdateMode.OnValidation, "", "");

            //客戶評價
            txt_Evaluation.DataBindings.Clear();
            txt_Evaluation.DataBindings.Add("Text", applicantTBindingSource, "Evaluation", true, DataSourceUpdateMode.OnValidation, "", "");

            //開始來往時間
            maskedTextBox_StartedDate.DataBindings.Clear();
            maskedTextBox_StartedDate.DataBindings.Add("Text", applicantTBindingSource, "StartedDate", true, DataSourceUpdateMode.OnValidation, "    /  /", "yyyy/MM/dd");

            txt_ID.DataBindings.Clear();
            txt_ID.DataBindings.Add("Text", applicantTBindingSource, "ID", true, DataSourceUpdateMode.OnValidation, "", "");

            //所屬母公司
            txt_MainCorp.DataBindings.Clear();
            txt_MainCorp.DataBindings.Add("Text", applicantTBindingSource, "MainCorpName", true, DataSourceUpdateMode.OnValidation, "", "");

            //客戶種類
            txt_ClientKind.DataBindings.Clear();
            txt_ClientKind.DataBindings.Add("Text", applicantTBindingSource, "ClientKindString", true, DataSourceUpdateMode.OnValidation, "", "");

            //本所承辦人
            txt_Worker.DataBindings.Clear();
            txt_Worker.DataBindings.Add("Text", applicantTBindingSource, "EmployeeName", true, DataSourceUpdateMode.OnValidation, "", "");

            //請款方式
            txt_RecWay.DataBindings.Clear();
            txt_RecWay.DataBindings.Add("Text", applicantTBindingSource, "RecWayName", true, DataSourceUpdateMode.OnValidation, "", "");

            //電子信箱
            txt_email.DataBindings.Clear();
            txt_email.DataBindings.Add("Text", applicantTBindingSource, "Email", true, DataSourceUpdateMode.OnValidation, "", "");

            //網址
            txt_WebSite.DataBindings.Clear();
            txt_WebSite.DataBindings.Add("Text", applicantTBindingSource, "WebSite", true, DataSourceUpdateMode.OnValidation, "", "");

            //客戶來源
            txt_Source.DataBindings.Clear();
            txt_Source.DataBindings.Add("Text", applicantTBindingSource, "ApplicantSourceName", true, DataSourceUpdateMode.OnValidation, "", "");

            //產業別
            txt_businessKind.DataBindings.Clear();
            txt_businessKind.DataBindings.Add("Text", applicantTBindingSource, "BusinessKind", true, DataSourceUpdateMode.OnValidation, "", "");

            //國籍
            txt_CountryCitizenship.DataBindings.Clear();
            txt_CountryCitizenship.DataBindings.Add("Text", applicantTBindingSource, "CountryCitizenship", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_Chage.DataBindings.Clear();
            txt_Chage.DataBindings.Add("Text", applicantTBindingSource, "Chage", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_Business.DataBindings.Clear();
            txt_Business.DataBindings.Add("Text", applicantTBindingSource, "Business", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_SendTitle.DataBindings.Clear();
            txt_SendTitle.DataBindings.Add("Text", applicantTBindingSource, "SendTitle", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_Account.DataBindings.Clear();
            txt_Account.DataBindings.Add("Text", applicantTBindingSource, "Account", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_Password.DataBindings.Clear();
            txt_Password.DataBindings.Add("Text", applicantTBindingSource, "Password", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_TEL.DataBindings.Clear();
            txt_TEL.DataBindings.Add("Text", applicantTBindingSource, "TEL", true, DataSourceUpdateMode.OnValidation);

            txt_FAX.DataBindings.Clear();
            txt_FAX.DataBindings.Add("Text", applicantTBindingSource, "FAX", true, DataSourceUpdateMode.OnValidation);

            txt_Remark.DataBindings.Clear();
            txt_Remark.DataBindings.Add("Text", applicantTBindingSource, "Remart", true, DataSourceUpdateMode.OnValidation);

            txt_SourceDescription.DataBindings.Clear();
            txt_SourceDescription.DataBindings.Add("Text", applicantTBindingSource, "SourceDescription", true, DataSourceUpdateMode.OnValidation);

            txt_Receiptor.DataBindings.Clear();
            txt_Receiptor.DataBindings.Add("Text", applicantTBindingSource, "Receiptor", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_Remark.DataBindings.Clear();
            txt_Remark.DataBindings.Add("Text", applicantTBindingSource, "Remart", true, DataSourceUpdateMode.OnValidation, "", "");

            Check_P.DataBindings.Clear();
            Check_P.DataBindings.Add("Checked", applicantTBindingSource, "P", true, DataSourceUpdateMode.OnValidation, false);

            Check_T.DataBindings.Clear();
            Check_T.DataBindings.Add("Checked", applicantTBindingSource, "T", true, DataSourceUpdateMode.OnValidation, false);

            Check_C.DataBindings.Clear();
            Check_C.DataBindings.Add("Checked", applicantTBindingSource, "C", true, DataSourceUpdateMode.OnValidation, false);

            Check_L.DataBindings.Clear();
            Check_L.DataBindings.Add("Checked", applicantTBindingSource, "L", true, DataSourceUpdateMode.OnValidation, false);

            Check_E.DataBindings.Clear();
            Check_E.DataBindings.Add("Checked", applicantTBindingSource, "E", true, DataSourceUpdateMode.OnValidation, false);

            checkBox_LawVIP.DataBindings.Clear();
            checkBox_LawVIP.DataBindings.Add("Checked", applicantTBindingSource, "LawVIP", true, DataSourceUpdateMode.OnValidation, false);

            txt_LargeEnty.DataBindings.Clear();
            txt_LargeEnty.DataBindings.Add("Text", applicantTBindingSource, "LargeEntyName", true, DataSourceUpdateMode.OnValidation, "", "");

        }
        #endregion       

        #region ==========ApplicantMF1_Load============
        private void ApplicantMF1_Load(object sender, EventArgs e)
        {
            string strSQL = "";
            switch (MainType)
            {
                case 1:
                    strSQL = string.Format(" ApplicantKey in( select ApplicantKey from PatentApplicantT with(nolock) where PatentID={0} )", MainKey.ToString());                   
                    break;
                case 2:
                    strSQL = string.Format(" ApplicantKey in( select ApplicantKey from TrademarkApplicantT with(nolock) where TrademarkID={0} )", MainKey.ToString());
                    break;
            }

            Public.CApplicantPublicFunction.GetApplicantTList(strSQL, ref dt_ApplicantSearchT);
            applicantTBindingSource.DataSource = dt_ApplicantSearchT;
            SetBindingSource();

            Init();
        }
        #endregion

        #region ==========ApplicantMF1_FormClosed==========
        private void ApplicantMF1_FormClosed(object sender, FormClosedEventArgs e)
        {
           
        } 
        #endregion     
   
        #region ==============查詢按鈕==============
        private void button_Search_Click(object sender, EventArgs e)
        {
       
        }
        #endregion

        #region 設定BindingSource的來源 private void SetBindingSource()
        /// <summary>
        /// 設定BindingSource的來源
        /// </summary>
        private void SetBindingSource()
        {
            
            if (dt_InventorT.Columns.Count == 0)
            {
                Public.CApplicantPublicFunction.GetInventorT("0", ref dt_InventorT);
            }
            inventorTBindingSource.DataSource = dt_InventorT;

            
        }
        #endregion    

        #region ==========GridView_Applicant_DataError==========
        private void GridView_Applicant_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = false;
        } 
        #endregion        
       
        #region GridView_Applicant_SelectionChanged
        private void GridView_Applicant_SelectionChanged(object sender, EventArgs e)
        {
            if (GridView_Applicant.CurrentRow != null)
            {   
                Public.CApplicantPublicFunction.GetInventorT(ProApplicantKey.ToString(), ref dt_InventorT);
                                
                QueryFilterInventor.ParameterValue = ProApplicantKey.ToString();
            }
            else
            {
              
                dt_InventorT.Rows.Clear();            

                QueryFilterInventor.ParameterValue = "-1";               
            }
        }
        #endregion      

        #region ==========GridView_Applicant_CellClick==========
        private void GridView_Applicant_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex!=-1)
            {
                if (GridView_Applicant.Columns[e.ColumnIndex].Name == "Aemail")
                {
                    if (GridView_Applicant.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Trim() != "")
                    {
                        Public.Utility.ProcessMailTo(GridView_Applicant.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                    }
                }
                else if (GridView_Applicant.Columns[e.ColumnIndex].Name == "WebSite")
                {
                    if (GridView_Applicant.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Trim() != "")
                    {
                        Public.Utility.ProcessStart( GridView_Applicant.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                    }
                }
            }
        } 
        #endregion     

        #region  =============InventorT_ColumnChanged事件===============
        private void InventorT_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            if (e.Row.RowState == DataRowState.Unchanged)
            {

                Public.CInventor CA_CInventor = new Public.CInventor();
                CA_CInventor.InventorKey = (int)e.Row["InventorKey"];
                Public.CInventor.ReadOne(ref CA_CInventor);
                switch (e.Column.ColumnName)
                {

                    case "InventorKey":
                        CA_CInventor.InventorKey = e.ProposedValue != DBNull.Value ? (int)e.ProposedValue : -1;
                        break;
                    case "ApplicantKey":
                        CA_CInventor.ApplicantKey = e.ProposedValue != DBNull.Value ? (int)e.ProposedValue : -1;
                        break;
                    case "InventorName":
                        CA_CInventor.InventorName = e.ProposedValue != null ? e.ProposedValue.ToString() : "";
                        break;
                    case "FamilyName":
                        CA_CInventor.FamilyName = e.ProposedValue != null ? e.ProposedValue.ToString() : "";
                        break;
                    case "GivenName":
                        CA_CInventor.GivenName = e.ProposedValue != null ? e.ProposedValue.ToString() : "";
                        break;
                    case "InventorID":
                        CA_CInventor.InventorID = e.ProposedValue != null ? e.ProposedValue.ToString() : "";
                        break;
                    
                }
                CA_CInventor.Update();
                dt_InventorT.AcceptChanges();
            }
        }
        #endregion

        #region =================客戶快顯=====================
        private void contextMenuStrip_App_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            contextMenuStrip_App.Visible = false;

            switch (e.ClickedItem.Name)
            {
                case "toolStripButton_AddApp":
                case "AddApplicantMenuItem":
                    AddFrom.AddApplicant add = new LawtechPTSystem.AddFrom.AddApplicant();
                    add.ShowDialog();
                    break;

                case "toolStripButton_DelApp":
                case "DelApplicantMenuItem":
                    if (GridView_Applicant.CurrentRow != null)
                    {
                        Public.DLL dll = new Public.DLL();

                        if (MessageBox.Show("是否確定刪除 " + GridView_Applicant.CurrentRow.Cells["ApplicantName"].Value.ToString(), "確認視窗", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            int iKey = (int)GridView_Applicant.CurrentRow.Cells["ApplicantKey"].Value;

                            dll.SQLexecuteNonQuery("delete LiaisonerT where ApplicantKey=" + iKey.ToString());

                            Public.CApplicant app = new Public.CApplicant();
                            Public.CApplicant.ReadOne(iKey, ref app);
                            //刪除記錄檔    
                            Public.CSystemLogT log = new Public.CSystemLogT();
                            log.DelTime = DateTime.Now;
                            log.DelWorkerKey = Properties.Settings.Default.WorkerKEY;
                            log.DelWorker = Properties.Settings.Default.WorkerName;
                            log.DelContent = string.Format("客戶資料:{0}-{1}\r\n ID: {2}", app.ApplicantSymbol,app.ApplicantName ,app.ID);
                            log.DelTitle = string.Format("刪除「{0}」資料【{1}-{2}】", this.Text, app.ApplicantSymbol, app.ApplicantName);
                            log.Create();

                            app.Delete(iKey);
                            GridView_Applicant.Rows.Remove(GridView_Applicant.CurrentRow);

                            MessageBox.Show("刪除客戶成功");
                        }

                    }
                    break;

                case "toolStripButton_EditApp":
                case "EditToolStripMenuItem":
                    if (GridView_Applicant.CurrentRow != null)
                    {
                        int iUser = Public.CommonFunctions.GetRecordAuth(SourceTableName, "ApplicantKey=" + ProApplicantKey.ToString());
                        if (iUser == -1)//判斷是否有人使用中
                        {

                            EditForm.EditApplicant edit = new LawtechPTSystem.EditForm.EditApplicant();
                            edit.ApplicantKey = ProApplicantKey;
                            edit.ShowDialog();
                        }
                        else
                        {
                            Worker_Model manager = new Worker_Model();
                            Worker_Model.ReadOne(iUser, ref manager);
                            MessageBox.Show(string.Format("該筆資料目前被【{0}】使用中, 請稍候...", manager.EmployeeName), "提示訊息");
                        }

                    }
                    break;
                case "toolStripButton_Orientation":
                case "toolStripMenuItem_Orientation":
                    if (splitContainer1.Orientation == Orientation.Horizontal)
                    {
                        splitContainer1.Orientation = Orientation.Vertical;
                    }
                    else
                    {
                        splitContainer1.Orientation = Orientation.Horizontal;
                    }
                    break;

           
                case "toolStripButton_Export":
                case "toolStripMenuItem_CustomerExport":
                    try
                    {
                        Public.DLL dll = new Public.DLL();
                        Task task = dll.WriteToCSV(GridView_Applicant);
                    }
                    catch
                    {
                        MessageBox.Show("匯出CSV失敗:匯出過程發生異常被終止");
                    }

                    break;
                case "ToolStripMenuItem_SetGridColumn":
                    SubFrom.SetGridColumnT gc = new SubFrom.SetGridColumnT();
                    gc.CurrentGridSymboID = GridView_Applicant.Tag.ToString();
                    gc.TitleName = "客戶資料(申請人)列表";
                    gc.Show();
                    break;
            }
        }
        #endregion

     

      

      

        #region =================發明人快顯=================
        private void contextMenuStrip_Inventor_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            contextMenuStrip_Inventor.Visible = false;
            switch (e.ClickedItem.Name)
            {
                case "toolStripMenuItem_AddInventor":
                case "toolStripButton_AddInventor":
                    AddFrom.AddInventor add = new LawtechPTSystem.AddFrom.AddInventor();
                    add.ApplicantKey = (int)GridView_Applicant.CurrentRow.Cells["ApplicantKey"].Value;
                    add.ShowDialog();
                    break;

                case "toolStripMenuItem_DelInventor":
                case "toolStripButton_DelInventor":

                    if (inventorTDataGridView.CurrentRow != null)
                    {
                        if (MessageBox.Show("是否確定刪除此筆發明人【" + inventorTDataGridView.CurrentRow.Cells["InventorName"].Value.ToString() + "】 ", "確認視窗", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            int iKey = (int)inventorTDataGridView.CurrentRow.Cells["InventorKey"].Value;
                            Public.CInventor CA_Del = new Public.CInventor();
                            Public.CInventor.ReadOne(iKey,ref CA_Del);

                            //刪除記錄檔    
                            Public.CSystemLogT log = new Public.CSystemLogT();
                            log.DelTime = DateTime.Now;
                            log.DelWorkerKey = Properties.Settings.Default.WorkerKEY;
                            log.DelWorker = Properties.Settings.Default.WorkerName;
                            log.DelContent = string.Format("發明人:{0} \r\n身份証字號:{1} \r\n 地址:{2}", CA_Del.InventorName, CA_Del.InventorID, CA_Del.Address);
                            log.DelTitle = string.Format("刪除「{0}」資料【發明人-{1}】", this.Text, CA_Del.InventorName);
                            log.Create();

                            CA_Del.Delete();

                            inventorTDataGridView.Rows.Remove(inventorTDataGridView.CurrentRow);

                            dt_InventorT.AcceptChanges();

                            MessageBox.Show("刪除成功");
                        }
                    }
                    break;
                case "toolStripButton_EditInventor":
                case "toolStripMenuItem_EditInventor":
                    if (inventorTDataGridView.CurrentRow != null)
                    {
                        int iInventorKey = (int)inventorTDataGridView.CurrentRow.Cells["InventorKey"].Value;
                        int iUser = Public.CommonFunctions.GetRecordAuth("InventorT", "InventorKey=" + iInventorKey.ToString());
                        if (iUser == -1)//判斷是否有人使用中
                        {
                            EditForm.EditInventor edit = new EditForm.EditInventor();
                            edit.InventorKey = iInventorKey;
                            edit.ApplicantKey = (int)GridView_Applicant.CurrentRow.Cells["ApplicantKey"].Value;
                            edit.ShowDialog();
                        }
                        else
                        {
                            Worker_Model manager = new Worker_Model();
                            Worker_Model.ReadOne(iUser, ref manager);
                            MessageBox.Show(string.Format("該筆資料目前被【{0}】使用中, 請稍候...", manager.EmployeeName), "提示訊息");
                        }
                    }
                    break;
                case "toolStripButton_inventorExport":
                case "toolStripMenuItem_ExportInventor":
                    try
                    {
                        Public.DLL dll = new Public.DLL();
                        Task task = dll.WriteToCSV(inventorTDataGridView);
                    }
                    catch (System.Exception EX)
                    {
                        string ss = EX.Message;
                        MessageBox.Show("匯出CSV失敗:匯出過程發生異常被終止");
                    }
                    break;
                case "toolStripMenuItem_SetGridColumnInventor":
                    SubFrom.SetGridColumnT gc = new SubFrom.SetGridColumnT();
                    gc.CurrentGridSymboID = inventorTDataGridView.Tag.ToString();
                    gc.TitleName = "發明人資料";
                    gc.Show();
                    break;
            }
        }
        #endregion       

     

        #region btnInventorSearch_Click 發明人查詢按鈕
        private void btnInventorSearch_Click(object sender, EventArgs e)
        {
            if (QueryFilterInventor.ComboBoxSelectedValue.Text.Trim()!= "")
            {
                inventorTBindingSource.Filter = QueryFilterInventor.SQLSelectedValueColumn;
            }
            else
            {
                inventorTBindingSource.Filter = "";
            }
          
        }
        #endregion

       

       

       

    }
}
