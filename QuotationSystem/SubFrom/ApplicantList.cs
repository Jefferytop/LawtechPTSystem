using System;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LawtechPTSystem.SubFrom
{
    /// <summary>
    /// 客戶資料列表(申請人)
    /// </summary>
    public partial class ApplicantList : Form
    {
        UserPermissionForm myPermission;
        private const string ProgramSymbol = "ApplicantList";
        private const string SourceTableName = "ApplicantT";

        DataTable dtLiaisonerTem;
        
        #region Public Property  

        private DataTable dt_ApplicantSearchT = new DataTable();
        /// <summary>
        /// 申請人資料集
        /// </summary>
        public DataTable DT_ApplicantSearchT
        {
            get { return dt_ApplicantSearchT; }
            set { dt_ApplicantSearchT = value; }
        }

        private DataTable dt_LiaisonerSreachT = new DataTable();
        /// <summary>
        /// 聯絡人資料集
        /// </summary>
        public DataTable DT_LiaisonerSreachT
        {
            get { return dt_LiaisonerSreachT; }
            set { dt_LiaisonerSreachT = value; }

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

        private DataTable dt_CustomerTrackingRecordT = new DataTable();
        /// <summary>
        /// 往來記錄資料集
        /// </summary>
        public DataTable DT_CustomerTrackingRecordT
        {
            get { return dt_CustomerTrackingRecordT; }
            set { dt_CustomerTrackingRecordT = value; }
        }

        private DataTable dt_PatentListT = new DataTable();
        /// <summary>
        /// 專利資料集
        /// </summary>
        public DataTable DT_PatentListT
        {
            get { return dt_PatentListT; }
            set { dt_PatentListT = value; }
        }

        private DataTable dt_TrademarkListT = new DataTable();
        /// <summary>
        /// 商標資料集
        /// </summary>
        public DataTable DT_TrademarkListT
        {
            get { return dt_TrademarkListT; }
            set { dt_TrademarkListT = value; }
        }

        private DataSet dt_NoFinishFeeApplication = new DataSet();
        /// <summary>
        /// 未完成請款記錄資料集
        /// </summary>
        public DataSet DT_NoFinishFeeApplication
        {
            get { return dt_NoFinishFeeApplication; }
            set { dt_NoFinishFeeApplication = value; }
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
            GridView_AttLiaisoner.AutoGenerateColumns = false;
            inventorTDataGridView.AutoGenerateColumns = false;
            customerTrackingRecordTDataGridView.AutoGenerateColumns = false;
            dataGridView_Patent.AutoGenerateColumns = false;
            dataGridView_Trademark.AutoGenerateColumns = false;
            dataGridView_Fee.AutoGenerateColumns = false;

            Public.DynamicGridViewColumn.GetGridColum(ref GridView_Applicant);
           
            Public.DynamicGridViewColumn.GetGridColum(ref GridView_AttLiaisoner);

            Public.DynamicGridViewColumn.GetGridColum(ref inventorTDataGridView);

            Public.DynamicGridViewColumn.GetGridColum(ref customerTrackingRecordTDataGridView);

            Public.DynamicGridViewColumn.GetGridColum(ref dataGridView_Patent);

            Public.DynamicGridViewColumn.GetGridColum(ref dataGridView_Trademark);

            Public.DynamicGridViewColumn.GetGridColum(ref dataGridView_Fee);
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

            //郵遞區號
            txt_LiaisonAddr.DataBindings.Clear();
            txt_LiaisonAddr.DataBindings.Add("Text", applicantTBindingSource, "ContactAddr", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_PostalCode.DataBindings.Clear();
            txt_PostalCode.DataBindings.Add("Text", applicantTBindingSource, "PostalCode", true, DataSourceUpdateMode.OnValidation, "", "");

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
            maskedTextBox_StartedDate.DataBindings.Add("Text", applicantTBindingSource, "StartedDate", true, DataSourceUpdateMode.OnValidation, "    -  -", "yyyy-MM-dd");

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

            Public.PublicForm Forms = new Public.PublicForm();
            Forms.ApplicantList = this;

            //取得權限
            myPermission = new UserPermissionForm(Properties.Settings.Default.WorkerKEY, ProgramSymbol);

            System.Windows.Forms.BindingNavigator[] listbinding = { bindingNavigator_App, bindingNavigator_AttLiaisoner, bindingNavigator_Inventor, bindingNavigator_customerTracking };
            System.Windows.Forms.ContextMenuStrip[] listtMenu = { contextMenuStrip_App, contextMenuStrip_Record, contextMenuStripContact, contextMenuStrip_Inventor };

            //確認可使用的功能選單
            Public.CommonFunctions.CheckMeunItemVisible(listbinding, myPermission.UserPermission);
            Public.CommonFunctions.CheckMeunItemVisible(listtMenu, myPermission.UserPermission);

            SetBindingSource();

            Init();

            Public.Utility.SetLoadDataRange(userControlFilterDate1);

            if (Properties.Settings.Default.IsLoadData)
            {
                button_Search_Click(null, null);
            }



        }
        #endregion

        #region ==========ApplicantMF1_FormClosed==========
        private void ApplicantMF1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Public.PublicForm Forms = new Public.PublicForm();
            Forms.ApplicantList = null;
        } 
        #endregion     
   
        #region ==============查詢按鈕==============
        private void button_Search_Click(object sender, EventArgs e)
        {
            string strSQL = Public.CommonFunctions.GetSQLScript(QueryFilter1, QueryFilter2, Radio_and.Checked ? " and " : " or ", userControlFilterDate1);
            Public.CApplicantPublicFunction.GetApplicantTList(strSQL, ref dt_ApplicantSearchT);            
        }
        #endregion

        #region 設定BindingSource的來源 private void SetBindingSource()
        /// <summary>
        /// 設定BindingSource的來源
        /// </summary>
        private void SetBindingSource()
        {
            if (dt_ApplicantSearchT.Columns.Count == 0)
            {
                Public.CApplicantPublicFunction.GetApplicantTList("1=0", ref dt_ApplicantSearchT);
            }
            applicantTBindingSource.DataSource = dt_ApplicantSearchT;

            if (dt_LiaisonerSreachT.Columns.Count == 0)
            {
                Public.CApplicantPublicFunction.GetLiaisoner("0", ref dt_LiaisonerSreachT);
            }
            liaisonerTBindingSource.DataSource = dt_LiaisonerSreachT;

            if (dt_InventorT.Columns.Count == 0)
            {
                Public.CApplicantPublicFunction.GetInventorT("0", ref dt_InventorT);
            }
            inventorTBindingSource.DataSource = dt_InventorT;

            if (dt_CustomerTrackingRecordT.Columns.Count == 0)
            {
                Public.CApplicantPublicFunction.GetCustomerTrackingRecordT("0", ref dt_CustomerTrackingRecordT);
            }
            customerTrackingRecordTBindingSource.DataSource = dt_CustomerTrackingRecordT;

            if (dt_PatentListT.Columns.Count == 0)
            {
                Public.CPatentPublicFunction.GetPatentList("1=0", ref dt_PatentListT);
            }
            bindingSource_patent.DataSource = dt_PatentListT;

            if (dt_TrademarkListT.Columns.Count == 0)
            {
                Public.CTrademarkPublicFunction.GetTrademarkList("1=0", ref dt_TrademarkListT);
            }
            bindingSource_Trademark.DataSource = dt_TrademarkListT;

            #region 未完成請款記錄
            if (dt_NoFinishFeeApplication.Tables.Count == 0)
            {
                Public.CApplicantPublicFunction.GetNoFinishFeeApplicationList("1=0", ref dt_NoFinishFeeApplication);
                bindingSource_Fee.DataSource = dt_NoFinishFeeApplication.Tables[0];
                toolStripLabel_NoPaySum.Text = "0";
            }
            #endregion

        }
        #endregion

        #region ==========更新按鈕=============
        private void button_Refresh_Click(object sender, EventArgs e)
        {
            dt_ApplicantSearchT.Rows.Clear();
            Public.CApplicantPublicFunction.GetApplicantTList("",ref dt_ApplicantSearchT);           
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
              
                Public.CApplicantPublicFunction.GetLiaisoner( ProApplicantKey.ToString() ,ref dt_LiaisonerSreachT);

                Public.CApplicantPublicFunction.GetInventorT(ProApplicantKey.ToString(), ref dt_InventorT);

                Public.CApplicantPublicFunction.GetCustomerTrackingRecordT(ProApplicantKey.ToString(),ref dt_CustomerTrackingRecordT);

                Public.CPatentPublicFunction.GetPatentList("PatentID in (select PatentID  from PatentApplicantT with(nolock) where ApplicantKey=" + ProApplicantKey.ToString()+")", ref dt_PatentListT);

                Public.CTrademarkPublicFunction.GetTrademarkList("TrademarkID in (select TrademarkID  from TrademarkApplicantT with(nolock) where ApplicantKey=" + ProApplicantKey.ToString() + " )", ref dt_TrademarkListT);

                Public.CApplicantPublicFunction.GetNoFinishFeeApplicationList("(IsClosing='False' or IsClosing is null ) and (Pay='False' or Pay is null) and ApplicantKey=" + ProApplicantKey.ToString(), ref dt_NoFinishFeeApplication);
                if (dt_NoFinishFeeApplication.Tables.Count == 2)
                {
                    bindingSource_Fee.DataSource = dt_NoFinishFeeApplication.Tables[0];
                    decimal decSum = 0;
                    bool bSum = decimal.TryParse(dt_NoFinishFeeApplication.Tables[1].Rows[0]["SumTotalNT"].ToString(), out decSum);
                    toolStripLabel_NoPaySum.Text = decSum.ToString("#,##0.##");
                }

                QueryFilterInventor.ParameterValue = ProApplicantKey.ToString();
            }
            else
            {
                dt_LiaisonerSreachT.Rows.Clear();
                dt_InventorT.Rows.Clear();
                dt_CustomerTrackingRecordT.Rows.Clear();
                if(dt_NoFinishFeeApplication.Tables.Count==2)
                {
                    dt_NoFinishFeeApplication.Tables[0].Rows.Clear();
                    dt_NoFinishFeeApplication.Tables[1].Rows.Clear();
                }
                
                QueryFilterInventor.ParameterValue = "-1";               
            }
        }
        #endregion

        #region ==========GridView_AttLiaisoner_CellClick==========
        private void GridView_AttLiaisoner_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                if (GridView_AttLiaisoner.Columns[e.ColumnIndex].Name == "email")
                {
                    if (GridView_AttLiaisoner.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Trim() != "")
                    {
                        Public.Utility.ProcessMailTo(GridView_AttLiaisoner.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                    }
                }
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

        #region  =============LiaisonerT_ColumnChanged事件===============
        private void LiaisonerT_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            if (e.Row.RowState == DataRowState.Unchanged)
            {

                Public.CLiaisoner CA_Liaisoner = new Public.CLiaisoner();
                CA_Liaisoner.LiaisonerKey = (int)e.Row["LiaisonerKey"];
                Public.CLiaisoner.ReadOne(ref CA_Liaisoner);
                switch (e.Column.ColumnName)
                {

                    case "Sort":
                        CA_Liaisoner.Sort = e.ProposedValue != DBNull.Value ? (int)e.ProposedValue : -1;
                        break;
                    case "LiaisonerName":
                        CA_Liaisoner.LiaisonerName = e.ProposedValue != null ? e.ProposedValue.ToString() : "";
                        break;
                    case "Ext":
                        CA_Liaisoner.Ext = e.ProposedValue != null ? e.ProposedValue.ToString() : "";
                        break;
                    case "Moblephone":
                        CA_Liaisoner.Moblephone = e.ProposedValue != null ? e.ProposedValue.ToString() : "";
                        break;
                    case "Email":
                        CA_Liaisoner.Email = e.ProposedValue != null ? e.ProposedValue.ToString() : "";
                        break;
                    case "Position":
                        CA_Liaisoner.Position = e.ProposedValue != null ? e.ProposedValue.ToString() : "";
                        break;

                    case "Gender":
                        CA_Liaisoner.Gender = e.ProposedValue != null ? e.ProposedValue.ToString() : "";
                        break;
                    case "LiaisonerAddr":
                        CA_Liaisoner.LiaisonerAddr = e.ProposedValue != null ? e.ProposedValue.ToString() : "";
                        break;
                    case "IsWindows":
                        CA_Liaisoner.IsWindows = e.ProposedValue != DBNull.Value ? (int)e.ProposedValue :-1;
                        break;
                    case "Quit":
                        CA_Liaisoner.Quit = e.ProposedValue != null ? (bool)e.ProposedValue : false;
                        break;
                    case "Remark":
                        CA_Liaisoner.Remark = e.ProposedValue != null ? e.ProposedValue.ToString() : "";
                        break;
                }
                CA_Liaisoner.LastModifyWorker = Properties.Settings.Default.WorkerName;
                CA_Liaisoner.Update();
                dt_LiaisonerSreachT.AcceptChanges();
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

                case "toolStripMenuItem_Download":
                case "toolStripButton_Download":
                    if (GridView_Applicant.CurrentRow != null)
                    {
                        //ApplicantViewDownFileList DownFileList = new ApplicantViewDownFileList();
                        //DownFileList.Pro_FileKind = 40;
                        //DownFileList.Pro_MainKey = ProApplicantKey;
                        //DownFileList.Text += "--"+GridView_Applicant.CurrentRow.Cells["ApplicantName"].Value.ToString() ;
                        //DownFileList.ShowDialog();
                        bool bConnectionFile = Properties.Settings.Default.IsFileServerConnection;
                        if (bConnectionFile)
                        {
                            ViewUpdateFileList subForm = new ViewUpdateFileList();
                            subForm.Text = GridView_Applicant.CurrentRow.Cells["ApplicantName"].Value.ToString() + "的相關文件";
                            subForm.FileKind = 40;
                            subForm.FileType = 99;
                            subForm.MainParentID = ProApplicantKey;
                            subForm.radoC.Checked = true;
                            subForm.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("請確認檔案上傳路徑是否有正常連結!!");
                        }
                    }
                    break;
                case "toolStripMenuItem_Upload":
                case "toolStripButton_Upload":
                    if (GridView_Applicant.CurrentRow != null)
                    {
                        bool bConnectionFile = Properties.Settings.Default.IsFileServerConnection;
                        if (bConnectionFile)
                        {
                            US.UpFileList upfile2 = new US.UpFileList();
                        upfile2.Text = "上傳附件(" + GridView_Applicant.CurrentRow.Cells["ApplicantName"].Value.ToString() + ")相關文件";
                        upfile2.MainFileKey = (int)GridView_Applicant.CurrentRow.Cells["ApplicantKey"].Value;
                        upfile2.UploadMode = 40;
                        upfile2.MainFileType = 99;
                        upfile2.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("請確認檔案上傳路徑是否有正常連結!!");
                        }
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
                    SetGridColumnT gc = new SetGridColumnT();
                    gc.CurrentGridSymboID = GridView_Applicant.Tag.ToString();
                    gc.TitleName = "客戶資料(申請人)列表";
                    gc.Show();
                    break;
            }
        }
        #endregion

        #region GridView_Applicant_CellDoubleClick
        private void GridView_Applicant_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != -1 && e.RowIndex != -1)
            {
                if (GridView_Applicant.CurrentRow != null)
                {
                    if (myPermission.UserPermission.HasFlag(PermissionTypes.Modify))//判斷權限
                    {
                        contextMenuStrip_App_ItemClicked(EditToolStripMenuItem, new ToolStripItemClickedEventArgs(EditToolStripMenuItem));
                    }
                }
            }
        } 
        #endregion

        #region =================連絡人快顯=====================
        private void contextMenuStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            contextMenuStripContact.Visible = false;
            switch (e.ClickedItem.Name)
            {
                case "toolStripButton1_AddLiaisoner":
                case "AddLiaisonerMenuItem":
                  
                    if (GridView_Applicant.CurrentRow != null)
                    {
                        AddFrom.AddLiaisoner add = new LawtechPTSystem.AddFrom.AddLiaisoner();
                        add.ApplicantKey = (int)GridView_Applicant.CurrentRow.Cells["ApplicantKey"].Value;
                        add.ShowDialog();
                        //if (add.ShowDialog() == DialogResult.OK)
                        //{
                        //    this.v_LiaisonerSreachTTableAdapter.Fill(this.dataSet_Applicant.V_LiaisonerSreachT, add.IApplicantKey);
                        //}
                    }
                    break;
                case "toolStripButton1_DelLiaisoner":
                case "DelLiaisonerMenuItem":
                    if (GridView_AttLiaisoner.CurrentRow != null)
                    {
                        contextMenuStripContact.Visible = false;

                        if (MessageBox.Show("是否確定刪除 " + GridView_AttLiaisoner.CurrentRow.Cells["LiaisonerName"].Value.ToString(), "確認視窗", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            int iKey = (int)GridView_AttLiaisoner.CurrentRow.Cells["LiaisonerKey"].Value;
                            Public.CLiaisoner ctt = new Public.CLiaisoner();
                            Public.CLiaisoner.ReadOne(iKey, ref ctt);

                            int iApplicantKey = (int)GridView_Applicant.CurrentRow.Cells["ApplicantKey"].Value;
                            Public.CApplicant app = new Public.CApplicant();
                            Public.CApplicant.ReadOne(iApplicantKey, ref app);

                            //刪除記錄檔    
                            Public.CSystemLogT log = new Public.CSystemLogT();
                            log.DelTime = DateTime.Now;
                            log.DelWorkerKey = Properties.Settings.Default.WorkerKEY;
                            log.DelWorker = Properties.Settings.Default.WorkerName;
                            log.DelContent = string.Format("客戶編號：{3}\r\n客戶名稱：{4}\r\n連絡人:{0} \r\n行動電話:{1} \r\n 職稱:{2}", ctt.LiaisonerName,ctt.Moblephone,ctt.Position,app.ApplicantSymbol, app.ApplicantName);
                            log.DelTitle = string.Format("刪除「{0}」資料【連絡人-{1}】", this.Text, ctt.LiaisonerName);
                            log.Create();

                            ctt.Delete();

                            GridView_AttLiaisoner.Rows.Remove(GridView_AttLiaisoner.CurrentRow);
                           
                            MessageBox.Show("刪除成功");
                        }
                    }
                    break;
                case "toolStripButton1_EditLiaisoner":
                case "EditLiaisonertoolStripMenuItem":
                    if (GridView_Applicant.CurrentRow != null)
                    {
                        int iLiaisonerKey = (int)GridView_AttLiaisoner.CurrentRow.Cells["LiaisonerKey"].Value;
                        int iUser = Public.CommonFunctions.GetRecordAuth("LiaisonerT", "LiaisonerKey=" + iLiaisonerKey.ToString());
                        if (iUser == -1)//判斷是否有人使用中
                        {
                            EditForm.EditLiaisoner edit = new LawtechPTSystem.EditForm.EditLiaisoner();
                            edit.LiaisonerKey = (int)GridView_AttLiaisoner.CurrentRow.Cells["LiaisonerKey"].Value;
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

                case "CopyToolStripMenuItem":
                            if (dtLiaisonerTem == null)
                            {
                                 dtLiaisonerTem=dt_LiaisonerSreachT.Clone();
                            }
                            if (dtLiaisonerTem.Rows.Count>0)
                            {
                                dtLiaisonerTem .Rows.Clear();
                            }
                            for (int iCopy = 0; iCopy < GridView_AttLiaisoner.Rows.Count; iCopy++)
                            {
                                if (GridView_AttLiaisoner.Rows[iCopy].Cells["CheckBox"].EditedFormattedValue.ToString() == "True")
                                {
                                    DataRow dr = dtLiaisonerTem.NewRow();
                                    dr.ItemArray = dt_LiaisonerSreachT.Rows[iCopy].ItemArray;
                                    dtLiaisonerTem.Rows.Add(dr);
                                }
                            }
                            break;

                case "PasteToolStripMenuItem":
                    if (GridView_Applicant.CurrentRow != null)
                    {
                        contextMenuStripContact.Visible = false;

                        if (MessageBox.Show("是否確定貼上新連絡人?", "提示訊息", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            Public.CLiaisoner add = new Public.CLiaisoner();
                            for (int iPaste = 0; iPaste < dtLiaisonerTem.Rows.Count; iPaste++)
                            {                                
                                add.ApplicantKey = (int)GridView_Applicant.CurrentRow.Cells["ApplicantKey"].Value;
                                add.Email = dtLiaisonerTem.Rows[iPaste]["Email"].ToString();
                                add.Ext = dtLiaisonerTem.Rows[iPaste]["Ext"].ToString();
                                add.IsWindows = int.Parse(dtLiaisonerTem.Rows[iPaste]["IsWindows"].ToString());
                                add.LiaisonerName = dtLiaisonerTem.Rows[iPaste]["LiaisonerName"].ToString();
                                add.LiaisonerAddr = dtLiaisonerTem.Rows[iPaste]["LiaisonerAddr"].ToString();
                                add.Moblephone = dtLiaisonerTem.Rows[iPaste]["Moblephone"].ToString();
                                add.Position = dtLiaisonerTem.Rows[iPaste]["Position"].ToString();
                                add.Quit = (bool)dtLiaisonerTem.Rows[iPaste]["Quit"];
                                add.Gender = dtLiaisonerTem.Rows[iPaste]["Gender"].ToString();
                                add.Sort = (int)dtLiaisonerTem.Rows[iPaste]["Sort"];
                                add.Creator = Properties.Settings.Default.WorkerName;
                                add.Create();
                            }
                            Public.CApplicantPublicFunction.GetLiaisoner(ProApplicantKey.ToString(), ref dt_LiaisonerSreachT);
                        }
                    }
                    break;
                case "toolStripButton1_ExportLiaisoner":
                case "toolStripButton__ExportLiaisoner":
                    try
                    {
                        Public.DLL dll = new Public.DLL();
                        Task task = dll.WriteToCSV(GridView_AttLiaisoner);
                    }
                    catch(System.Exception EX)
                    {
                        string ss = EX.Message;
                        MessageBox.Show("匯出CSV失敗:匯出過程發生異常被終止");
                    }
                    break;
                case "toolStripMenuItem_SetGridColumnLiaisoner":
                    SetGridColumnT gc = new SetGridColumnT();
                    gc.CurrentGridSymboID = GridView_AttLiaisoner.Tag.ToString();
                    gc.TitleName = "連絡人資料";
                    gc.Show();
                    break;
            }
        }
        #endregion

        #region  private void GridView_AttLiaisoner_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        /// <summary>
        /// 連絡人GridView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GridView_AttLiaisoner_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != -1 && e.RowIndex != -1)
            {
                if (GridView_Applicant.CurrentRow != null)
                {
                    if (myPermission.UserPermission.HasFlag(PermissionTypes.Modify))//判斷權限
                    {
                        contextMenuStrip2_ItemClicked(EditLiaisonertoolStripMenuItem, new ToolStripItemClickedEventArgs(EditLiaisonertoolStripMenuItem));
                    }
                }
            }
        } 
        #endregion       

        #region  =================來往記錄快顯=================
        private void contextMenuStrip_Record_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            contextMenuStrip_Record.Visible = false;
            switch (e.ClickedItem.Name)
            {
                case "toolStripButton_AddRcord":
                case "ToolStripMenuItem_AddRecord":
                    if (GridView_Applicant.CurrentRow != null)
                    {
                        AddFrom.AddCustomerRecord add = new LawtechPTSystem.AddFrom.AddCustomerRecord();
                        add.ApplicantKey = (int)GridView_Applicant.CurrentRow.Cells["ApplicantKey"].Value;

                        add.ShowDialog();                       
                    }
                    break;
                case "toolStripButton_DelRecord":
                case "ToolStripMenuItem_DelRecord":

                    if (customerTrackingRecordTDataGridView.CurrentRow != null)
                    {
                        if (MessageBox.Show("是否確定刪除此筆往來記錄 ", "確認視窗", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            int iTrackingRecordKey = (int)customerTrackingRecordTDataGridView.CurrentRow.Cells["TrackingRecordKey"].Value;
                            Public.CCustomerTrackingRecord CA_Del = new Public.CCustomerTrackingRecord();
                            Public.CCustomerTrackingRecord.ReadOne(iTrackingRecordKey, ref CA_Del);

                            int iApplicantKey = (int)GridView_Applicant.CurrentRow.Cells["ApplicantKey"].Value;
                            Public.CApplicant app = new Public.CApplicant();
                            Public.CApplicant.ReadOne(iApplicantKey, ref app);

                            //刪除記錄檔    
                            Public.CSystemLogT log = new Public.CSystemLogT();
                            log.DelTime = DateTime.Now;
                            log.DelWorkerKey = Properties.Settings.Default.WorkerKEY;
                            log.DelWorker = Properties.Settings.Default.WorkerName;
                            log.DelContent = string.Format("客戶編號：{0}\r\n客戶名稱：{1}\r\n往來重要記錄:{2} \r\n客戶抱怨與意見:{3} \r\n 交易資料追蹤:{4}", app.ApplicantSymbol, app.ApplicantName, CA_Del.VitalRecord, CA_Del.ComplaintsComments, CA_Del.TrackingTransactions);
                            log.DelTitle = string.Format("刪除「{0}」資料", this.Text);
                            log.Create();

                            CA_Del.Delete();
                            customerTrackingRecordTDataGridView.Rows.Remove(customerTrackingRecordTDataGridView.CurrentRow);

                            dt_CustomerTrackingRecordT.AcceptChanges();

                            MessageBox.Show("刪除成功");
                        }
                    }
                    break;
                case "toolStripButton_EditRecord":
                case "ToolStripMenuItem_EditRecord":
                    if (customerTrackingRecordTDataGridView.CurrentRow != null)
                    {
                        int iTrackingRecordKey = (int)customerTrackingRecordTDataGridView.CurrentRow.Cells["TrackingRecordKey"].Value;
                        int iUser = Public.CommonFunctions.GetRecordAuth("CustomerTrackingRecordT", "TrackingRecordKey=" + iTrackingRecordKey.ToString());
                        if (iUser == -1)//判斷是否有人使用中
                        {
                            EditForm.EditCustomerRecord edit = new LawtechPTSystem.EditForm.EditCustomerRecord();
                            edit.TrackingRecordKey = iTrackingRecordKey;
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
            }
        }
        #endregion

        #region  private void customerTrackingRecordTDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void customerTrackingRecordTDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != -1 && e.RowIndex != -1)
            {
                if (customerTrackingRecordTDataGridView.CurrentRow != null)
                {
                    if (myPermission.UserPermission.HasFlag(PermissionTypes.Modify))//判斷權限
                    {
                        contextMenuStrip_Record_ItemClicked(toolStripButton_EditRecord, new ToolStripItemClickedEventArgs(toolStripButton_EditRecord));
                    }
                }
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
                    AddFrom.AddInventor add = new AddFrom.AddInventor();
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

                            int iApplicantKey = (int)GridView_Applicant.CurrentRow.Cells["ApplicantKey"].Value;
                            Public.CApplicant app = new Public.CApplicant();
                            Public.CApplicant.ReadOne(iApplicantKey,ref app);
                            //刪除記錄檔    
                            Public.CSystemLogT log = new Public.CSystemLogT();
                            log.DelTime = DateTime.Now;
                            log.DelWorkerKey = Properties.Settings.Default.WorkerKEY;
                            log.DelWorker = Properties.Settings.Default.WorkerName;
                            log.DelContent = string.Format("客戶編號：{3}\r\n客戶名稱：{4}\r\n發明人:{0} \r\n身份証字號:{1} \r\n地址:{2}", CA_Del.InventorName, CA_Del.InventorID, CA_Del.Address,app.ApplicantSymbol,app.ApplicantName);
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
                    SetGridColumnT gc = new SetGridColumnT();
                    gc.CurrentGridSymboID = inventorTDataGridView.Tag.ToString();
                    gc.TitleName = "發明人資料";
                    gc.Show();
                    break;
            }
        }
        #endregion

        #region  private void inventorTDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void inventorTDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != -1 && e.RowIndex != -1)
            {
                if (inventorTDataGridView.CurrentRow != null)
                {
                    if (myPermission.UserPermission.HasFlag(PermissionTypes.Modify))//判斷權限
                    {
                        contextMenuStrip_Inventor_ItemClicked(toolStripMenuItem_EditInventor, new ToolStripItemClickedEventArgs(toolStripMenuItem_EditInventor));
                    }
                }
            }
        } 
        #endregion       

        #region =================開啟明細按鈕=================
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

        private void contextMenuStrip_Patent_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            contextMenuStrip_Patent.Visible = false;
            switch (e.ClickedItem.Name)
            {
                case "toolStripMenuItem_PatentCSV":
                    try
                    {
                        Public.DLL dll = new Public.DLL();
                        Task task = dll.WriteToCSV(dataGridView_Patent);
                    }
                    catch (System.Exception EX)
                    {
                        string ss = EX.Message;
                        MessageBox.Show("匯出CSV失敗:匯出過程發生異常被終止");
                    }
                    break;
                case "toolStripMenuItem_SetGridColumnPatent":
                    SetGridColumnT gc = new SetGridColumnT();
                    gc.CurrentGridSymboID = dataGridView_Patent.Tag.ToString();
                    gc.TitleName = "客戶管理(申請人)-專利資料";
                    gc.Show();
                    break;
            }
        }

        private void contextMenuStrip_Trademark_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            contextMenuStrip_Trademark.Visible = false;
            switch (e.ClickedItem.Name)
            {
                case "toolStripMenuItem_TrademarkCSV":
                    try
                    {
                        Public.DLL dll = new Public.DLL();
                        Task task = dll.WriteToCSV(dataGridView_Trademark);
                    }
                    catch (System.Exception EX)
                    {
                        string ss = EX.Message;
                        MessageBox.Show("匯出CSV失敗:匯出過程發生異常被終止");
                    }
                    break;
                case "toolStripMenuItem_SetGridColumnTrademark":
                    SetGridColumnT gc = new SetGridColumnT();
                    gc.CurrentGridSymboID = dataGridView_Trademark.Tag.ToString();
                    gc.TitleName = "客戶管理(申請人)-商標資料";
                    gc.Show();
                    break;
            }
        }
    }
}
