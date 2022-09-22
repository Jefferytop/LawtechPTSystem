using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LawtechPTSystem.SubFrom
{
    public partial class AttorneyMF : Form
    {  
        
        #region 自訂變數    
        UserPermissionForm myPermission;
        private const string ProgramSymbol = "AttorneyMF";
        private const string SourceTableName = "AttorneyT";
        
        #endregion

        public AttorneyMF()
        {
            InitializeComponent();

            GridView_Attorney.AutoGenerateColumns = false;
            GridView_AttLiaisoner.AutoGenerateColumns = false;

            Dictionary<string, BindingSource> lists = new Dictionary<string, BindingSource>() { { "countryTBindingSource", countryTBindingSource } };
            Public.DynamicGridViewColumn.GetGridColum(ref GridView_Attorney, lists);

            Dictionary<string, BindingSource> lists1 = new Dictionary<string, BindingSource>() { { "contractTypeTBindingSource", contractTypeTBindingSource } };
            Public.DynamicGridViewColumn.GetGridColum(ref GridView_AttLiaisoner, lists1);

            Public.DynamicGridViewColumn.GetGridColum(ref attorneyTrackingRecordTDataGridView);
        }   

        #region ===============AttorneyMF_Load、FormClosed======================
        private void AttorneyMF_Load(object sender, EventArgs e)
        {                       
            Public.PublicForm Forms = new Public.PublicForm();
            Forms.AttorneyMF = this;

            //取得權限
            myPermission = new UserPermissionForm(Properties.Settings.Default.WorkerKEY, ProgramSymbol);

            System.Windows.Forms.BindingNavigator[] listbinding = { bindingNavigator1, bindingNavigator_AttLiaisoner, bindingNavigator2};
            System.Windows.Forms.ContextMenuStrip[] listtMenu = { contextMenuStrip1, contextMenuStrip_Record, contextMenuStrip2 };

            //確認可使用的功能選單
            Public.CommonFunctions.CheckMeunItemVisible(listbinding, myPermission.UserPermission);
            Public.CommonFunctions.CheckMeunItemVisible(listtMenu, myPermission.UserPermission);
                   
                             
            this.countryTTableAdapter.Fill(this.dataSet_Drop.CountryT);
            //this.contractTypeTTableAdapter.Fill(this.dataSet_Drop.ContractTypeT);           
            this.attorneyTTableAdapter1.Fill(this.dataSet_Attorney.AttorneyT);
            attorneyTBindingSource1.Filter = "1=0";
            
            this.dataSet_Attorney.AttorneyT.ColumnChanged += new DataColumnChangeEventHandler(AttorneyT_ColumnChanged);
            this.dataSet_Attorney.AttorneyT.RowDeleting += new DataRowChangeEventHandler(AttorneyT_RowDeleting);

            Init();
            AttorneyTrackingRecordTInit();

            if (Properties.Settings.Default.IsLoadData)
            {
                button1_Click(null, null);
            }

            this.dataSet_Attorney.AttLiaisonerT.ColumnChanged += new DataColumnChangeEventHandler(AttLiaisonerT_ColumnChanged);
            this.dataSet_Attorney.AttLiaisonerT.RowDeleting += new DataRowChangeEventHandler(AttLiaisonerT_RowDeleting);

            this.dataSet_Attorney.AttorneyTrackingRecordT.ColumnChanged += new DataColumnChangeEventHandler(AttorneyTrackingRecordT_ColumnChanged);

            this.contractTypeTTableAdapter.Fill(this.dataSet_Drop.ContractTypeT);
            //but_MoneyList_Click(null,null);
        }

        private void AttorneyMF_FormClosed(object sender, FormClosedEventArgs e)
        {
            Public.PublicForm Forms = new Public.PublicForm();
            Forms.AttorneyMF = null;
        }
        #endregion
    
        #region  =============AttorneyT_ColumnChanged事件===============
        private void AttorneyT_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            if (e.Row.RowState == DataRowState.Unchanged)
            {

                Public.CAttorney CA_CAttorney = new Public.CAttorney();
                Public.CAttorney.ReadOne((int)e.Row["AttorneyKey"], ref CA_CAttorney);
               
                switch (e.Column.ColumnName)
                {

                    case "AttorneySymbol":
                        CA_CAttorney.AttorneySymbol = e.ProposedValue != null ? e.ProposedValue.ToString() : "";
                        break;
                    case "Sort":
                        CA_CAttorney.Sort = e.ProposedValue != DBNull.Value ? (int)e.ProposedValue : -1;
                        break;
                    case "AttorneyFirm":
                        CA_CAttorney.AttorneyFirm = e.ProposedValue != null ? e.ProposedValue.ToString() : "";
                        break;
                    case "ID":
                        CA_CAttorney.ID = e.ProposedValue != null ? e.ProposedValue.ToString() : "";
                        break;
                    case "Principal":
                        CA_CAttorney.Principal = e.ProposedValue != null ? e.ProposedValue.ToString() : "";
                        break;
                    case "CountrySymbol":
                        CA_CAttorney.CountrySymbol = e.ProposedValue != null ? e.ProposedValue.ToString() : "";
                        break;
                    case "Addr":
                        CA_CAttorney.Addr = e.ProposedValue != null ? e.ProposedValue.ToString() : "";
                        break;
                    case "TEL":
                        CA_CAttorney.TEL = e.ProposedValue != null ? e.ProposedValue.ToString() : "";
                        break;
                    case "FAX":
                        CA_CAttorney.FAX = e.ProposedValue != null ? e.ProposedValue.ToString() : "";
                        break;
                    case "Email":
                        CA_CAttorney.Email = e.ProposedValue != null ? e.ProposedValue.ToString() : "";
                        break;
                    case "WebSite":
                        CA_CAttorney.WebSite = e.ProposedValue != null ? e.ProposedValue.ToString() : "";
                        break;
                    case "BankAccount":
                        CA_CAttorney.BankAccount = e.ProposedValue != null ? e.ProposedValue.ToString() : "";
                        break;
                    case "BankAccountNo":
                        CA_CAttorney.BankAccountNo = e.ProposedValue != null ? e.ProposedValue.ToString() : "";
                        break;
                    case "Bank":
                        CA_CAttorney.Bank = e.ProposedValue != null ? e.ProposedValue.ToString() : "";
                        break;
                    case "Remark":
                        CA_CAttorney.Remark = e.ProposedValue != null ? e.ProposedValue.ToString() : "";
                        break;
                    case "MotherAttorney":
                        CA_CAttorney.MotherAttorney = e.ProposedValue != DBNull.Value ? (int)e.ProposedValue : -1;
                        break;
                    case "Payment":
                        CA_CAttorney.Payment = e.ProposedValue != null ? e.ProposedValue.ToString() : "";
                        break;
                }

            
                CA_CAttorney.LastModifyWorker = Properties.Settings.Default.WorkerName;
                CA_CAttorney.Update();
                this.dataSet_Attorney.AttorneyT.AcceptChanges();
            }
        }
        #endregion

        #region  =============AttorneyT+_RowDeleting事件===============
        private void AttorneyT_RowDeleting(object sender, DataRowChangeEventArgs e)
        {
            int iKey = (int)e.Row["AttorneyKey"];
            Public.CAttorney CA_CAttorney = new Public.CAttorney();
            Public.CAttorney.ReadOne(iKey, ref CA_CAttorney);           

            //刪除記錄檔    
            Public.CSystemLogT log = new Public.CSystemLogT();
            log.DelTime = DateTime.Now;
            log.DelWorkerKey = Properties.Settings.Default.WorkerKEY;
            log.DelWorker = Properties.Settings.Default.WorkerName;            
            log.DelContent = string.Format("事務所代碼:{0}\r\n事務所名稱:{1}\r\n電子信箱:{2}\r\n網址:{3}\r\n電話:{4}", CA_CAttorney.AttorneySymbol, CA_CAttorney.AttorneyFirm, CA_CAttorney.Email, CA_CAttorney.WebSite, CA_CAttorney.TEL);
            log.DelTitle = string.Format("刪除「{0}」 資料【{1}】", this.Text,CA_CAttorney.AttorneyFirm);
            log.Create();

            CA_CAttorney.Delete((int)e.Row["AttorneyKey"]);
        }
        #endregion

        #region  =============AttLiaisonerT_ColumnChanged事件===============
        private void AttLiaisonerT_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            if (e.Row.RowState == DataRowState.Unchanged)
            {
                Public.CAttLiaisoner CA_CAttLiaisoner = new Public.CAttLiaisoner();
                Public.CAttLiaisoner.ReadOne((int)e.Row["ALiaisonerKey"], ref CA_CAttLiaisoner);
             
                switch (e.Column.ColumnName)
                {
                    case "Sort":
                        CA_CAttLiaisoner.Sort = e.ProposedValue != DBNull.Value ? (int)e.ProposedValue : -1;
                        break;
                    case "Liaisoner":
                        CA_CAttLiaisoner.Liaisoner = e.ProposedValue != null ? e.ProposedValue.ToString() : "";
                        break;
                    case "Ext":
                        CA_CAttLiaisoner.Ext = e.ProposedValue != null ? e.ProposedValue.ToString() : "";
                        break;
                    case "Moblephone":
                        CA_CAttLiaisoner.Moblephone = e.ProposedValue != null ? e.ProposedValue.ToString() : "";
                        break;
                    case "email":
                        CA_CAttLiaisoner.email = e.ProposedValue != null ? e.ProposedValue.ToString() : "";
                        break;
                    case "AttorneyKey":
                        CA_CAttLiaisoner.AttorneyKey = e.ProposedValue != DBNull.Value ? (int)e.ProposedValue : -1;
                        break;
                    case "Position":
                        CA_CAttLiaisoner.Position = e.ProposedValue != null ? e.ProposedValue.ToString() : "";
                        break;
                    case "Gender":
                        CA_CAttLiaisoner.Gender = e.ProposedValue != null ? e.ProposedValue.ToString() : "";
                        break;
                    case "IsWindows":
                        CA_CAttLiaisoner.IsWindows = e.ProposedValue != DBNull.Value ? (int)e.ProposedValue : -1;
                        break;
                    case "Quit":
                        CA_CAttLiaisoner.Quit = e.ProposedValue != DBNull.Value ? (bool)e.ProposedValue : false;
                        break;
                }
                CA_CAttLiaisoner.Update();
                this.dataSet_Attorney.AttLiaisonerT.AcceptChanges();
            }
        }
        #endregion

        #region  =============AttLiaisonerT+_RowDeleting事件===============
        private void AttLiaisonerT_RowDeleting(object sender, DataRowChangeEventArgs e)
        {
            int iKey = (int)e.Row["ALiaisonerKey"];
            Public.CAttLiaisoner CA_CAttLiaisoner = new Public.CAttLiaisoner();
            Public.CAttLiaisoner.ReadOne(iKey, ref CA_CAttLiaisoner);

            int iAttorneyKey = CA_CAttLiaisoner.AttorneyKey;
            Public.CAttorney att = new Public.CAttorney();
            Public.CAttorney.ReadOne(iAttorneyKey, ref att);

            //刪除記錄檔    
            Public.CSystemLogT log = new Public.CSystemLogT();
            log.DelTime = DateTime.Now;
            log.DelWorkerKey = Properties.Settings.Default.WorkerKEY;
            log.DelWorker = Properties.Settings.Default.WorkerName;           
            log.DelContent = string.Format("事務所代碼:{5}\r\n事務所名稱:{6}\r\n聯絡人姓名:{0}\r\n分機:{1}\r\n行動電話:{2}\r\n電子信箱:{3}\r\n性別:{4}", CA_CAttLiaisoner.Liaisoner, CA_CAttLiaisoner.Ext, CA_CAttLiaisoner.Moblephone, CA_CAttLiaisoner.email, CA_CAttLiaisoner.Gender,att.AttorneySymbol,att.AttorneyFirm);
            log.DelTitle = string.Format("刪除「{0}」資料【聯絡人-{1}】", this.Text,CA_CAttLiaisoner.Liaisoner);
            log.Create();

            CA_CAttLiaisoner.Delete((int)e.Row["ALiaisonerKey"]);
        }
        #endregion

        #region  =============AttorneyTrackingRecordT_ColumnChanged事件===============
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AttorneyTrackingRecordT_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            if (e.Row.RowState == DataRowState.Unchanged)
            {
                Public.CAttorneyTrackingRecord CA_CAttorneyTrackingRecord = new Public.CAttorneyTrackingRecord();
                CA_CAttorneyTrackingRecord.AttorneyTrackingRecordKey = (int)e.Row["AttorneyTrackingRecordKey"];
                Public.CAttorneyTrackingRecord.ReadOne(ref CA_CAttorneyTrackingRecord);
                switch (e.Column.ColumnName)
                {                  
                   
                    case "VitalRecord":
                        CA_CAttorneyTrackingRecord.VitalRecord = e.ProposedValue != null ? e.ProposedValue.ToString() : "";
                        break;
                    case "ComplaintsComments":
                        CA_CAttorneyTrackingRecord.ComplaintsComments = e.ProposedValue != null ? e.ProposedValue.ToString() : "";
                        break;
                    case "TrackingTransactions":
                        CA_CAttorneyTrackingRecord.TrackingTransactions = e.ProposedValue != null ? e.ProposedValue.ToString() : "";
                        break;
                }
                CA_CAttorneyTrackingRecord.LastModifyWorker = Properties.Settings.Default.WorkerName;
                CA_CAttorneyTrackingRecord.Update();
                this.dataSet_Attorney.AttorneyTrackingRecordT.AcceptChanges();
            }
        }
        #endregion

        #region 關閉按鈕 private void but_Close_Click(object sender, EventArgs e)
        /// <summary>
        /// 關閉按鈕
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void but_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        } 
        #endregion

        #region ===========Init============
        public void Init()
        {
            txt_AttorneySymbol.DataBindings.Clear();
            txt_AttorneySymbol.DataBindings.Add("Text", attorneyTBindingSource1, "AttorneySymbol", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_AttorneyFirm.DataBindings.Clear();
            txt_AttorneyFirm.DataBindings.Add("Text", attorneyTBindingSource1, "AttorneyFirm", true, DataSourceUpdateMode.OnValidation, "", "");


            txt_Addr.DataBindings.Clear();
            txt_Addr.DataBindings.Add("Text", attorneyTBindingSource1, "Addr", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_ID.DataBindings.Clear();
            txt_ID.DataBindings.Add("Text", attorneyTBindingSource1, "ID", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_Principal.DataBindings.Clear();
            txt_Principal.DataBindings.Add("Text", attorneyTBindingSource1, "Principal", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_TEL.DataBindings.Clear();
            txt_TEL.DataBindings.Add("Text", attorneyTBindingSource1, "TEL", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_FAX.DataBindings.Clear();
            txt_FAX.DataBindings.Add("Text", attorneyTBindingSource1, "FAX", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_email.DataBindings.Clear();
            txt_email.DataBindings.Add("Text", attorneyTBindingSource1, "Email", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_Website.DataBindings.Clear();
            txt_Website.DataBindings.Add("Text", attorneyTBindingSource1, "WebSite", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_BankAccount.DataBindings.Clear();
            txt_BankAccount.DataBindings.Add("Text", attorneyTBindingSource1, "BankAccount", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_BankAccountNo.DataBindings.Clear();
            txt_BankAccountNo.DataBindings.Add("Text", attorneyTBindingSource1, "BankAccountNo", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_Bank.DataBindings.Clear();
            txt_Bank.DataBindings.Add("Text", attorneyTBindingSource1, "Bank", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_Remark.DataBindings.Clear();
            txt_Remark.DataBindings.Add("Text", attorneyTBindingSource1, "Remark", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_payment.DataBindings.Clear();
            txt_payment.DataBindings.Add("Text", attorneyTBindingSource1, "payment", true, DataSourceUpdateMode.OnValidation, "", "");

        }


        public void AttorneyTrackingRecordTInit()
        {
            txt_VitalRecord.DataBindings.Clear();
            txt_VitalRecord.DataBindings.Add("Text", attorneyTrackingRecordTBindingSource, "VitalRecord", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_ComplaintsComments.DataBindings.Clear();
            txt_ComplaintsComments.DataBindings.Add("Text", attorneyTrackingRecordTBindingSource, "ComplaintsComments", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_TrackingTransactions.DataBindings.Clear();
            txt_TrackingTransactions.DataBindings.Add("Text", attorneyTrackingRecordTBindingSource, "TrackingTransactions", true, DataSourceUpdateMode.OnValidation, "", "");

        }

        #endregion

        private void GridView_Attorney_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = false;
        }

        #region private void GridView_Attorney_SelectionChanged(object sender, EventArgs e)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GridView_Attorney_SelectionChanged(object sender, EventArgs e)
        {
            
            if (GridView_Attorney.CurrentRow != null)
            {
                attLiaisonerTTableAdapter.Fill(dataSet_Attorney.AttLiaisonerT, (int)GridView_Attorney.CurrentRow.Cells["AttorneyKey"].Value);
                this.attorneyTrackingRecordTTableAdapter1.Fill(this.dataSet_Attorney.AttorneyTrackingRecordT, (int)GridView_Attorney.CurrentRow.Cells["AttorneyKey"].Value);
            }
            else
            {
                dataSet_Attorney.AttLiaisonerT.Rows.Clear();
                this.dataSet_Attorney.AttorneyTrackingRecordT.Rows.Clear();

            }
        }
        #endregion


        #region  ==================事務所快顯=======================
        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            contextMenuStrip1.Visible = false;

            switch (e.ClickedItem.Name)
            {
                case "toolStripButton_Add":
                case "AddAttroneyMenuItem":

                    AddFrom.AddAttorney add = new LawtechPTSystem.AddFrom.AddAttorney();

                    if (add.ShowDialog() == DialogResult.OK)
                    {
                        this.attorneyTTableAdapter1.Fill(this.dataSet_Attorney.AttorneyT);
                    }

                    break;
                case "toolStripButton_Del":
                case "DelAttorneyMenuItem":

                    if (GridView_Attorney.CurrentRow != null)
                    {
                        Public.DLL dll = new Public.DLL();

                        //判斷事務所有沒有被使用
                        //object obj= dll.SQLexecuteScalar("select count(Attorney) from FileT where Attorney=" + GridView_Attorney.CurrentRow.Cells["AttorneyKEY"].Value.ToString());

                        //if (obj!=null && obj.ToString() == "0")
                        //{


                        if (MessageBox.Show("是否確定刪除 " + GridView_Attorney.CurrentRow.Cells["AttorneyFirm"].Value.ToString(), "確認視窗", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            dll.SQLexecuteNonQuery("delete AttLiaisonerT where AttorneyKEY=" + GridView_Attorney.CurrentRow.Cells["AttorneyKEY"].Value.ToString());

                            GridView_Attorney.Rows.Remove(GridView_Attorney.CurrentRow);

                            this.dataSet_Attorney.AttorneyT.AcceptChanges();

                            MessageBox.Show("刪除事務所成功");
                        }
                        //}
                        //else
                        //{
                        //    MessageBox.Show("該資料已被使用，為確保資料完整性，不得刪除");
                        //}
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
                case "toolStripMenuItem_OpenFile":
                case "toolStripButton_OpenFile":
                    if (GridView_Attorney.CurrentRow != null)
                    {
                        bool bConnectionFile = Properties.Settings.Default.IsFileServerConnection;
                        if (bConnectionFile)
                        {
                            ViewUpdateFileList subForm = new ViewUpdateFileList();
                            subForm.Text = GridView_Attorney.CurrentRow.Cells["AttorneySymbol"].Value.ToString() + "-" + GridView_Attorney.CurrentRow.Cells["AttorneyFirm"].Value.ToString() + "的相關文件";
                            subForm.FileKind = 50;
                            subForm.FileType = 99;
                            subForm.MainParentID = (int)GridView_Attorney.CurrentRow.Cells["AttorneyKey"].Value;
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
                    if (GridView_Attorney.CurrentRow != null)
                    {
                        bool bConnectionFile = Properties.Settings.Default.IsFileServerConnection;
                        if (bConnectionFile)
                        {
                            US.UpFileList upfile2 = new US.UpFileList();
                            upfile2.Text = "上傳附件(" + GridView_Attorney.CurrentRow.Cells["AttorneySymbol"].Value.ToString() + "-" + GridView_Attorney.CurrentRow.Cells["AttorneyFirm"].Value.ToString() + ")相關文件";
                            upfile2.MainFileKey = (int)GridView_Attorney.CurrentRow.Cells["AttorneyKey"].Value;
                            upfile2.UploadMode = 50;
                            upfile2.MainFileType = 99;
                            upfile2.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("請確認檔案上傳路徑是否有正常連結!!");
                        }
                    }

                    break;
                case "ToolStripMenuItem_SetGridColumn":
                    SetGridColumnT gc = new SetGridColumnT();
                    gc.CurrentGridSymboID = GridView_Attorney.Tag.ToString();
                    gc.TitleName = "事務所列表 (複代、承案人員)";
                    gc.Show();
                    break;
                case "toolStripButton_ExportCSV":
                case "toolStripMenuItem_CSV":
                    try
                    {
                        Public.DLL dll = new Public.DLL();
                        Task task = dll.WriteToCSV(GridView_Attorney);
                    }
                    catch
                    {
                        MessageBox.Show("匯出CSV失敗:匯出過程發生異常被終止");
                    }
                    break;
            }
        }
        #endregion

        #region ===============查詢按鈕 ==================
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string strSQLWhere = Public.CommonFunctions.GetSQLScript(QueryFilter1, QueryFilter2, Radio_and.Checked ? " and " : " or ");
                attorneyTBindingSource1.Filter = strSQLWhere.Replace("Like N'", "Like '");
            }
            catch (SystemException EX)
            {
                string ss = EX.Message;
            }
        }
        #endregion

        #region ================全部按鈕======================
        private void button2_Click(object sender, EventArgs e)
        {
            this.dataSet_Attorney.AttorneyT.Rows.Clear();

            this.attorneyTTableAdapter1.Fill(this.dataSet_Attorney.AttorneyT);

            attorneyTBindingSource1.Filter = "";

        }
        #endregion

        #region ====================連絡人快顯 =========================
        /// <summary>
        /// 連絡人快顯
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void contextMenuStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Name)
            {
                case "toolStripButton_AddAtt":
                case "AddLiaisonerMenuItem":
                    contextMenuStrip2.Visible = false;
                    if (GridView_Attorney.CurrentRow != null)
                    {
                        AddFrom.AddAttLiaisoner add = new LawtechPTSystem.AddFrom.AddAttLiaisoner();
                        add.Text = add.Text + " (" + GridView_Attorney.CurrentRow.Cells["AttorneyFirm"].Value.ToString() + ")";
                        add.iAttorneyKEY = (int)GridView_Attorney.CurrentRow.Cells["AttorneyKey"].Value;
                       if( add.ShowDialog()==DialogResult.OK)
                        {
                            dataSet_Attorney.AttLiaisonerT.Rows.Clear();
                            attLiaisonerTTableAdapter.Fill(dataSet_Attorney.AttLiaisonerT, (int)GridView_Attorney.CurrentRow.Cells["AttorneyKey"].Value);
                        }
                    }
                    break;
                case "toolStripButton_DelAtt":
                case "DelLiaisonerMenuItem":
                    contextMenuStrip2.Visible = false;
                    if (GridView_AttLiaisoner.CurrentRow != null)
                    {
                        Public.DLL dll = new Public.DLL();

                        //判斷事務所有沒有被使用
                        //object obj= dll.SQLexecuteScalar("select count(Attorney) from FileT where Attorney=" + GridView_Attorney.CurrentRow.Cells["AttorneyKEY"].Value.ToString());

                        //if (obj!=null && obj.ToString() == "0")
                        //{
                        

                        if (MessageBox.Show("是否確定刪除 " + GridView_AttLiaisoner.CurrentRow.Cells["Liaisoner"].Value.ToString(), "確認視窗", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            //dll.SQLexecuteNonQuery("delete AttLiaisonerT where ALiaisonerKey=" + GridView_AttLiaisoner.CurrentRow.Cells["ALiaisonerKey"].Value.ToString());
                            Public.CAttLiaisoner del = new Public.CAttLiaisoner();
                            Public.CAttLiaisoner.ReadOne((int)GridView_AttLiaisoner.CurrentRow.Cells["ALiaisonerKey"].Value,ref del);
                            GridView_AttLiaisoner.Rows.Remove(GridView_AttLiaisoner.CurrentRow);

                            this.dataSet_Attorney.AttLiaisonerT.AcceptChanges();

                            //刪除記錄檔    
                            //Public.CSystemLogT log = new Public.CSystemLogT();
                            //log.DelTime = DateTime.Now;
                            //log.DelWorkerKey = Properties.Settings.Default.WorkerKEY;
                            //log.DelWorker = Properties.Settings.Default.WorkerName;
                            
                            //log.DelContent = string.Format("事務所連絡人:{0}\r\n 行動電話:{1}\r\n 職稱:{2}\r\n email 格式:{3}", del.Liaisoner, del.Moblephone, del.Position, del.email);
                            //log.DelTitle = string.Format("刪除事務所連絡人資料【{0}】", del.Liaisoner);
                            //log.Create();

                            MessageBox.Show("刪除事務所聯絡人成功");
                        }
                        //}
                        //else
                        //{
                        //    MessageBox.Show("該資料已被使用，為確保資料完整性，不得刪除");
                        //}
                    }
                    break;
            }
        }
        #endregion

        #region  =================來往記錄快顯=================
        private void contextMenuStrip_Record_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            contextMenuStrip_Record.Visible = false;
            switch (e.ClickedItem.Name)
            {
                case "toolStripButton_AddRecrod":
                case "ToolStripMenuItem_AddRecord":
                    if (GridView_Attorney.CurrentRow != null)
                    {
                        AddFrom.AddAttorneyRecord add = new LawtechPTSystem.AddFrom.AddAttorneyRecord();
                        add.AttorneyKey = (int)GridView_Attorney.CurrentRow.Cells["AttorneyKEY"].Value;
                       
                        if (add.ShowDialog() == DialogResult.OK)
                        {
                            this.attorneyTrackingRecordTTableAdapter1.Fill(this.dataSet_Attorney.AttorneyTrackingRecordT, (int)GridView_Attorney.CurrentRow.Cells["AttorneyKey"].Value);
                        }
                    }

                    break;
                case "toolStripButton_DelRecrod":
                case "ToolStripMenuItem_DelRecord":

                    if (attorneyTrackingRecordTDataGridView.CurrentRow != null)
                    {
                        if (MessageBox.Show("是否確定刪除此筆往來記錄 ", "確認視窗", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            int iKey = (int)attorneyTrackingRecordTDataGridView.CurrentRow.Cells["AttorneyTrackingRecordKey"].Value;
                            Public.CAttorneyTrackingRecord CA_Del = new Public.CAttorneyTrackingRecord();
                            Public.CAttorneyTrackingRecord.ReadOne(iKey,ref CA_Del);

                            int iAttorneyKey = CA_Del.AttorneyKey.Value;
                            Public.CAttorney att = new Public.CAttorney();
                            Public.CAttorney.ReadOne(iAttorneyKey, ref att);

                            //刪除記錄檔    
                            Public.CSystemLogT log = new Public.CSystemLogT();
                            log.DelTime = DateTime.Now;
                            log.DelWorkerKey = Properties.Settings.Default.WorkerKEY;
                            log.DelWorker = Properties.Settings.Default.WorkerName;                          
                            log.DelContent = string.Format("事務所代碼:{3}\r\n事務所名稱:{4}\r\n重要記錄:{0}\r\n抱怨與意見:{1}\r\n交易資料追縱:{2}", CA_Del.VitalRecord, CA_Del.ComplaintsComments, CA_Del.TrackingTransactions, att.AttorneySymbol, att.AttorneyFirm);
                            log.DelTitle = string.Format(" 刪除「{0}」資料",this.Text);
                            log.Create();

                            CA_Del.Delete(iKey);

                            attorneyTrackingRecordTDataGridView.Rows.Remove(attorneyTrackingRecordTDataGridView.CurrentRow);

                            this.dataSet_Attorney.AttorneyTrackingRecordT.AcceptChanges();

                            MessageBox.Show("刪除成功");
                        }
                    }
                    break;

            }
        }
        #endregion

        private void GridView_AttLiaisoner_CellContentClick(object sender, DataGridViewCellEventArgs e)
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

        private void GridView_Attorney_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                if (GridView_Attorney.Columns[e.ColumnIndex].Name == "AEmail")
                {
                    if (GridView_Attorney.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Trim() != "")
                    {
                        Public.Utility.ProcessMailTo(GridView_Attorney.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                    }
                }
                else if (GridView_Attorney.Columns[e.ColumnIndex].Name == "WebSite")
                {
                    Public.Utility.ProcessStart( GridView_Attorney.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Trim());
                }
            }
        }

      
        #region =============linkLabel===============
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LinkLabel link = (LinkLabel)sender;
            US.PopMemo pop;
            switch (link.Name)
            {
                case "linkLabel_TEL":
                    pop = new LawtechPTSystem.US.PopMemo(txt_TEL, true, link.Text);
                    break;
                case "linkLabel_Remark":
                    pop = new LawtechPTSystem.US.PopMemo(txt_Remark, true, link.Text);
                    break;
                case "linkLabel_AttorneyFirm":
                    pop = new LawtechPTSystem.US.PopMemo(txt_AttorneyFirm, true, link.Text);
                    break;
                case "linkLabel_TrackingTransactions":
                    pop = new LawtechPTSystem.US.PopMemo(txt_TrackingTransactions, true, link.Text);
                    break;
                case "linkLabel_VitalRecord":
                    pop = new LawtechPTSystem.US.PopMemo(txt_VitalRecord, true, link.Text);
                    break;
              
                case "linkLabel_ComplaintsComments":
                    pop = new LawtechPTSystem.US.PopMemo(txt_ComplaintsComments, true, link.Text);
                    break;
             
                default:
                    pop = new LawtechPTSystem.US.PopMemo(txt_Remark, true, link.Text);
                    break;
            }

            pop.Show();
        }
         #endregion

        #region but_MoneyList_Click
        private void but_MoneyList_Click(object sender, EventArgs e)
        {
            if (!splitContainer1.Panel2Collapsed)
            {
                but_MoneyList.Text = "開啟事務所明細(Alt+E)";

                splitContainer1.Panel2Collapsed = true;
            }
            else
            {
                but_MoneyList.Text = "關閉事務所明細(Alt+E)";
                splitContainer1.Panel2Collapsed = false;
            }
        }
        #endregion

        private void AttorneyMF_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt)
            {
                if (e.KeyCode == Keys.E)
                {
                    but_MoneyList_Click(null, null);
                }
            }
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

       

    }
}