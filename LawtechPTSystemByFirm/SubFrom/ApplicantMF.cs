using System;
using System.Data;
using System.Windows.Forms;

namespace LawtechPTSystemByFirm.SubFrom
{
    /// <summary>
    /// 已不用(X)
    /// </summary>
    public partial class ApplicantMF : Form
    {
        public ApplicantMF()
        {
            InitializeComponent();
        }

        #region 自訂變數
        //internal DataTable dt_Applicant;
        //BindingSource bs_Applicant;
        //internal DataTable dt_Liaisoner;
        BindingSource bs_Liaisoner = new BindingSource();
        //DataTable dtLiaisonerTem;
        #endregion

        /// <summary>
        /// 發明人資料集
        /// </summary>
        public DataTable DT_Inventor
        {
            get { return dataSet_Applicant.InventorT; }

        }


        private void but_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region ================ApplicantMF_Load、FormClosed======================
        private void ApplicantMF_Load(object sender, EventArgs e)
        {
            Public.PublicForm Forms = new LawtechPTSystemByFirm.Public.PublicForm();
            Forms.ApplicantMF = this;
            
            this.largeEntyTTableAdapter.Fill(this.dataSet_Applicant.LargeEntyT);
           
            this.collectionRecordTTableAdapter.Fill(this.dataSet_Drop.CollectionRecordT);
            
            this.customerEvaluationTTableAdapter.Fill(this.dataSet_Drop.CustomerEvaluationT);
            this.businessKindTTableAdapter.Fill(this.qS_DataSet.BusinessKindT);
            DataRow dr = this.qS_DataSet.BusinessKindT.NewRow();
            dr["BusinessKind"] = " ";
            dr["BusinessKEY"] = -1;
            this.qS_DataSet.BusinessKindT.Rows.InsertAt(dr, 0);

            this.applicantTTableAdapter.Fill(this.qS_DataSet.ApplicantT);
            DataRow drApp = this.qS_DataSet.ApplicantT.NewApplicantTRow();
            drApp["ApplicantName"] = " ";
            drApp["ApplicantKey"] = -1;
            this.qS_DataSet.ApplicantT.Rows.InsertAt(drApp,0);

            this.clientKindTableAdapter.Fill(this.qS_DataSet.ClientKindT);
            this.workerTAllTableAdapter.Fill(this.qS_DataSet.WorkerTAll);
            DataRow drWork = this.qS_DataSet.WorkerTAll.NewWorkerTAllRow();
            drWork["WorkerKey"] = -1;
            drWork["Name"] = " ";
            this.qS_DataSet.WorkerTAll.Rows.InsertAt(drWork,0);

            GridView_Applicant.AutoGenerateColumns = false;
            GridView_AttLiaisoner.AutoGenerateColumns = false;

            this.isWindowsTableAdapter.Fill(this.qS_DataSet.IsWindows);
            DataRow drIsWindow = this.qS_DataSet.IsWindows.NewIsWindowsRow();
            drIsWindow["string"] = " ";
            drIsWindow["value"] = -1;
            this.qS_DataSet.IsWindows.Rows.InsertAt(drIsWindow,0);
            
          
           
            this.applicantSourceTableAdapter.Fill(this.qS_DataSet.ApplicantSourceT);

            

           // Public.CApplicant capp = new LawtechPTSystemByFirm.Public.CApplicant();
           // dt_Applicant = capp.GetDataTable();
           // bs_Applicant = new BindingSource();
           // bs_Applicant.DataSource = dt_Applicant;
           // bindingNavigator1.BindingSource = bs_Applicant;
           // GridView_Applicant.DataSource = bs_Applicant;

           // dt_Applicant.ColumnChanged += new DataColumnChangeEventHandler(ApplicantT_ColumnChanged);
           // dt_Applicant.RowDeleting += new DataRowChangeEventHandler(ApplicantT_RowDeleting);

           // this.qS_DataSet.CustomerTrackingRecordT.ColumnChanged += new DataColumnChangeEventHandler(CustomerTrackingRecordT_ColumnChanged);

           // Init();
           // CustomerTrackingRecordTInit();


           // comboBox1.SelectedIndex = 0;

           // dtLiaisonerTem = new DataTable();

           // dt_Liaisoner = new DataTable();
           
           // bindingNavigator3.BindingSource = bs_Liaisoner;

           //setDtLiaisonerTem();

           //dataSet_Applicant.InventorT.ColumnChanged += new DataColumnChangeEventHandler(InventorT_ColumnChanged);


           //comboBox3.SelectedIndex = 0;

           //but_MoneyList_Click(null,null);

        }

       

        private void ApplicantMF_FormClosed(object sender, FormClosedEventArgs e)
        {
            Public.PublicForm Forms = new LawtechPTSystemByFirm.Public.PublicForm();
            Forms.ApplicantMF = null;
        }
        #endregion

        #region setDtLiaisonerTem
        private void setDtLiaisonerTem()
        {
            //dtLiaisonerTem.Columns.AddRange(new DataColumn[]{
            //               new DataColumn("SN",typeof(int) ),
            //               new DataColumn("Ext",typeof(string)) ,
            //               new DataColumn("Liaisoner",typeof(string) ),
            //               new DataColumn("Moblephone",typeof(string) ),
            //               new DataColumn("email",typeof(string) ),
            //               new DataColumn("Position",typeof(string) ),
            //               new DataColumn("Sex",typeof(string) ) ,
            //                new DataColumn("LiaisonerAddr",typeof(string) ) ,
            //                new DataColumn("IsWindows",typeof(int) ),
            //                new DataColumn("Quit",typeof(bool) )
            //             }
            //       );
        }
        #endregion

        #region  =============ApplicantT_ColumnChanged事件===============
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ApplicantT_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            if (e.Row.RowState == DataRowState.Unchanged)
            {
                Public.CApplicant CA_CApplicant = new Public.CApplicant();
                Public.CApplicant.ReadOne((int)e.Row["ApplicantKey"], ref CA_CApplicant);                

                switch (e.Column.ColumnName)
                {
                    case "ApplicantName":
                        CA_CApplicant.ApplicantName = e.ProposedValue != null ? e.ProposedValue.ToString() : "";
                        break;
                    case "ApplicantNameEn":
                        CA_CApplicant.ApplicantNameEn = e.ProposedValue != null ? e.ProposedValue.ToString() : "";
                        break;
                    case "ID":
                        CA_CApplicant.ID = e.ProposedValue != null ? e.ProposedValue.ToString() : "";
                        break;
                    case "Address":
                        CA_CApplicant.Address = e.ProposedValue != null ? e.ProposedValue.ToString() : "";
                        break;
                    case "Email":
                        CA_CApplicant.Email = e.ProposedValue != null ? e.ProposedValue.ToString() : "";
                        break;
                    case "WebSite":
                        CA_CApplicant.WebSite = e.ProposedValue != null ? e.ProposedValue.ToString() : "";
                        break;
                    case "AddressEn":
                        CA_CApplicant.AddressEn = e.ProposedValue != null ? e.ProposedValue.ToString() : "";
                        break;
                    case "PrincipalName":
                        CA_CApplicant.PrincipalName = e.ProposedValue != null ? e.ProposedValue.ToString() : "";
                        break;
                    case "PrincipalNameEn":
                        CA_CApplicant.PrincipalNameEn = e.ProposedValue != null ? e.ProposedValue.ToString() : "";
                        break;
                    case "Chage":
                        CA_CApplicant.Chage = e.ProposedValue != null ? e.ProposedValue.ToString() : "";
                        break;
                    case "Business":
                        CA_CApplicant.Business = e.ProposedValue != null ? e.ProposedValue.ToString() : "";
                        break;
                    case "TEL":
                        CA_CApplicant.TEL = e.ProposedValue != null ? e.ProposedValue.ToString() : "";
                        break;
                    case "FAX":
                        CA_CApplicant.FAX = e.ProposedValue != null ? e.ProposedValue.ToString() : "";
                        break;
                    case "Remart":
                        CA_CApplicant.Remart = e.ProposedValue != null ? e.ProposedValue.ToString() : "";
                        break;
                    case "P":
                        CA_CApplicant.P = e.ProposedValue != DBNull.Value ? (bool)e.ProposedValue : false;
                        break;
                    case "T":
                        CA_CApplicant.T = e.ProposedValue != DBNull.Value ? (bool)e.ProposedValue : false;
                        break;
                    case "C":
                        CA_CApplicant.C = e.ProposedValue != DBNull.Value ? (bool)e.ProposedValue : false;
                        break;
                    case "L":
                        CA_CApplicant.L = e.ProposedValue != DBNull.Value ? (bool)e.ProposedValue : false;
                        break;
                    case "E":
                        CA_CApplicant.E = e.ProposedValue != DBNull.Value ? (bool)e.ProposedValue : false;
                        break;
                    case "SendTitle":
                        CA_CApplicant.SendTitle = e.ProposedValue != null ? e.ProposedValue.ToString() : "";
                        break;
                    case "Account":
                        CA_CApplicant.Account = e.ProposedValue != null ? e.ProposedValue.ToString() : "";
                        break;
                    case "Password":
                        CA_CApplicant.Password = e.ProposedValue != null ? e.ProposedValue.ToString() : "";
                        break;
                    case "MainCorp":
                        CA_CApplicant.MainCorp = e.ProposedValue != DBNull.Value ? (int)e.ProposedValue : -1;
                        break;
                    case "Worker":
                        CA_CApplicant.Worker = e.ProposedValue != DBNull.Value ? (int)e.ProposedValue : -1;
                        break;
                    case "LawVIP":
                        CA_CApplicant.LawVIP = e.ProposedValue != DBNull.Value ? (bool)e.ProposedValue : false;
                        break;
                    case "Source":
                        CA_CApplicant.Source = e.ProposedValue != DBNull.Value ? (int)e.ProposedValue : -1;
                        break;
                    case "RecWay":
                        CA_CApplicant.RecWay = e.ProposedValue != DBNull.Value ? (int)e.ProposedValue : -1;
                        break;
                    case "LargeEnty":
                        CA_CApplicant.LargeEnty = e.ProposedValue != DBNull.Value ? (int)e.ProposedValue : -1;
                        break;
                    case "Receiptor":
                        CA_CApplicant.Receiptor = e.ProposedValue != null ? e.ProposedValue.ToString() : "";
                        break;
                    case "ApplicantSymbol":
                        CA_CApplicant.ApplicantSymbol = e.ProposedValue != null ? e.ProposedValue.ToString() : "";
                        break;
                    case "SourceDescription":
                        CA_CApplicant.SourceDescription = e.ProposedValue != null ? e.ProposedValue.ToString() : "";
                        break;
                    case "ClientKind":
                        CA_CApplicant.ClientKind = e.ProposedValue != DBNull.Value ? (int)e.ProposedValue : -1;
                        break;
                    case "BusinessKind":
                        CA_CApplicant.BusinessKind = e.ProposedValue != DBNull.Value ? (int)e.ProposedValue : -1;
                        break;
                    case "ContactAddr":
                        CA_CApplicant.ContactAddr = e.ProposedValue != null ? e.ProposedValue.ToString() : "";
                        break;
                    case "Capital":
                        CA_CApplicant.Capital = e.ProposedValue != null ? e.ProposedValue.ToString() : "";
                        break;
                    case "CollectionRecord":
                        CA_CApplicant.CollectionRecord = e.ProposedValue != null ? e.ProposedValue.ToString() : "";
                        break;
                    case "StartedDate":
                        CA_CApplicant.StartedDate = e.ProposedValue != DBNull.Value ? (DateTime)e.ProposedValue : DateTime.Parse("1900/1/1");
                        break;
                    case "Evaluation":
                        CA_CApplicant.Evaluation = e.ProposedValue != null ? e.ProposedValue.ToString() : "";
                        break;
                }
                CA_CApplicant.LastModifyDateTime = DateTime.Now;
                CA_CApplicant.LastModifyWorker = Properties.Settings.Default.WorkerName;
                CA_CApplicant.Update();
                dataSet_Applicant.ApplicantT.AcceptChanges();
            }
        }
        #endregion

        #region  =============ApplicantT+_RowDeleting事件===============
        private void ApplicantT_RowDeleting(object sender, DataRowChangeEventArgs e)
        {
           int iKey= (int)e.Row["ApplicantKey"];
            Public.CApplicant CA_CApplicant = new Public.CApplicant();
            Public.CApplicant.ReadOne(iKey, ref CA_CApplicant);
            

            Public.CSystemLog log = new LawtechPTSystemByFirm.Public.CSystemLog();
            log.DelTime = DateTime.Now;
            log.DelWorkerKey = Properties.Settings.Default.WorkerKEY;
            //string[] str=CA_CApplicant.GetInsertString(iKey);
            //log.TableName = str[2];
            //log.DelContent_InsertColumn = str[0];
            //log.DelContent_InsertSQL = str[1];
            log.DelContent = string.Format("客戶代碼:{0}\r\n客戶名稱:{1}\r\n統一編號:{2}\r\n地址:{3}\r\n電子信箱:{4}", CA_CApplicant.ApplicantSymbol, CA_CApplicant.ApplicantName, CA_CApplicant.ID, CA_CApplicant.Address, CA_CApplicant.Email);
            log.DelTitle = string.Format("刪除客戶資料【{0}】", CA_CApplicant.ApplicantName);
            log.Create();

            CA_CApplicant.Delete((int)e.Row["ApplicantKey"]);
        }
        #endregion

        #region  =============LiaisonerT_ColumnChanged事件===============
        private void LiaisonerT_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            if (e.Row.RowState == DataRowState.Unchanged)
            {

                //Public.CLiaisoner CA_CLiaisoner = new Public.CLiaisoner("LiaisonerKey=" + e.Row["LiaisonerKey"].ToString());
                //CA_CLiaisoner.SetCurrent((int)e.Row["LiaisonerKey"]);
                //switch (e.Column.ColumnName)
                //{

                //    case "Sort":
                //        CA_CLiaisoner.Sort = e.ProposedValue != DBNull.Value ? (int)e.ProposedValue : -1;
                //        break;
                //    case "ApplicantKey":
                //        CA_CLiaisoner.ApplicantKey = e.ProposedValue != DBNull.Value ? (int)e.ProposedValue : -1;
                //        break;
                //    case "LiaisonerName":
                //        CA_CLiaisoner.LiaisonerName = e.ProposedValue != null ? e.ProposedValue.ToString() : "";
                //        break;
                //    case "Ext":
                //        CA_CLiaisoner.Ext = e.ProposedValue != null ? e.ProposedValue.ToString() : "";
                //        break;
                //    case "Moblephone":
                //        CA_CLiaisoner.Moblephone = e.ProposedValue != null ? e.ProposedValue.ToString() : "";
                //        break;
                //    case "email":
                //        CA_CLiaisoner.email = e.ProposedValue != null ? e.ProposedValue.ToString() : "";
                //        break;
                //    case "Position":
                //        CA_CLiaisoner.Position = e.ProposedValue != null ? e.ProposedValue.ToString() : "";
                //        break;
                //    case "Sex":
                //        CA_CLiaisoner.Sex = e.ProposedValue != null ? e.ProposedValue.ToString() : "";
                //        break;
                //    case "LiaisonerAddr":
                //        CA_CLiaisoner.LiaisonerAddr = e.ProposedValue != null ? e.ProposedValue.ToString() : "";
                //        break;
                //    case "IsWindows":
                //        CA_CLiaisoner.IsWindows = e.ProposedValue != DBNull.Value ? (int)e.ProposedValue : -1;
                //        break;
                //    case "Quit":
                //        CA_CLiaisoner.Quit = e.ProposedValue != DBNull.Value ? (bool)e.ProposedValue : false;
                //        break;

                //}
                //CA_CLiaisoner.Updata((int)e.Row["LiaisonerKey"]);
                //dt_Liaisoner.AcceptChanges();
            }
        }
        #endregion

        #region  =============LiaisonerT+_RowDeleting事件===============
        private void LiaisonerT_RowDeleting(object sender, DataRowChangeEventArgs e)
        {
            //int iKey = (int)e.Row["LiaisonerKey"];
            //Public.CLiaisoner CA_CLiaisoner = new Public.CLiaisoner("LiaisonerKey=" + iKey.ToString());
            //CA_CLiaisoner.SetCurrent(iKey);

            //Public.CSystemLog log = new LawtechPTSystemByFirm.Public.CSystemLog();
            //log.DelTime = DateTime.Now;
            //log.DelWorkerKey = Properties.Settings.Default.WorkerKEY;
            //string[] str = CA_CLiaisoner.GetInsertString(iKey);
            //log.TableName = str[2];
            //log.DelContent_InsertColumn = str[0];
            //log.DelContent_InsertSQL = str[1];
            //log.DelContent = string.Format("聯絡人姓名:{0}\r\n分機:{1}\r\n行動電話:{2}\r\n電子信箱:{3}\r\n性別:{4}", CA_CLiaisoner.LiaisonerName, CA_CLiaisoner.Ext, CA_CLiaisoner.Moblephone, CA_CLiaisoner.email, CA_CLiaisoner.Sex);
            //log.DelTitle = string.Format("刪除客戶聯絡人資料【{0}】", CA_CLiaisoner.LiaisonerName);
            //log.Create();

            //CA_CLiaisoner.Delete(e.Row["LiaisonerKey"].ToString());
        }
        #endregion

       
        #region  =============InventorT_ColumnChanged事件===============
        private void InventorT_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            if (e.Row.RowState == DataRowState.Unchanged)
            {
                Public.CInventor CA_CInventor = new Public.CInventor();
                CA_CInventor.InventorKey=(int)e.Row["InventorKey"];
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
                    case "Address":
                        CA_CInventor.Address = e.ProposedValue != null ? e.ProposedValue.ToString() : "";
                        break;
                   
                }
                CA_CInventor.Update();
                this.dataSet_Applicant.InventorT.AcceptChanges();
            }
        }
        #endregion

        #region ==========BindAttLiaisoner繫結客戶連絡人============
        /// <summary>
        /// 繫結事務所連絡人
        /// </summary>
        public void BindAttLiaisoner()
        {
            if (GridView_Applicant.CurrentRow != null)
            {
                //if (dt_Liaisoner != null) dt_Liaisoner.Rows.Clear();

                //Public.CLiaisoner attLiaisoner = new LawtechPTSystemByFirm.Public.CLiaisoner("ApplicantKey=" + GridView_Applicant.CurrentRow.Cells["ApplicantKey"].Value.ToString()+" order by SN");
                //dt_Liaisoner = attLiaisoner.GetDataTable();

                //bs_Liaisoner.DataSource = dt_Liaisoner;
                //GridView_AttLiaisoner.DataSource = bs_Liaisoner;

                //dt_Liaisoner.ColumnChanged += new DataColumnChangeEventHandler(LiaisonerT_ColumnChanged);
                //dt_Liaisoner.RowDeleting += new DataRowChangeEventHandler(LiaisonerT_RowDeleting);
            }
            else
            {
                //dt_Liaisoner.Rows.Clear();
            }
        }
        #endregion

        #region ===========Init============
        public void Init()
        {
           // txt_ApplicantSymbol.DataBindings.Clear();
           // txt_ApplicantSymbol.DataBindings.Add("Text", bs_Applicant, "ApplicantSymbol", true, DataSourceUpdateMode.OnValidation, "", "");


           // txt_ApplicantName.DataBindings.Clear();
           // txt_ApplicantName.DataBindings.Add("Text", bs_Applicant, "ApplicantName", true, DataSourceUpdateMode.OnValidation, "", "");

           //txt_ApplicantNameEn.DataBindings.Clear();
           //txt_ApplicantNameEn.DataBindings.Add("Text", bs_Applicant, "ApplicantNameEn", true, DataSourceUpdateMode.OnValidation, "", "");

           //txt_PrincipalName.DataBindings.Clear();
           //txt_PrincipalName.DataBindings.Add("Text", bs_Applicant, "PrincipalName", true, DataSourceUpdateMode.OnValidation, "", "");

           //txt_PrincipalNameEn.DataBindings.Clear();
           //txt_PrincipalNameEn.DataBindings.Add("Text", bs_Applicant, "PrincipalNameEn", true, DataSourceUpdateMode.OnValidation, "", "");

           //txt_email.DataBindings.Clear();
           //txt_email.DataBindings.Add("Text", bs_Applicant, "Email", true, DataSourceUpdateMode.OnValidation, "", "");

           //txt_WebSite.DataBindings.Clear();
           //txt_WebSite.DataBindings.Add("Text", bs_Applicant, "WebSite", true, DataSourceUpdateMode.OnValidation, "", "");

           // txt_Addr.DataBindings.Clear();
           // txt_Addr.DataBindings.Add("Text", bs_Applicant, "Addr", true, DataSourceUpdateMode.OnValidation, "", "");

           // txt_AddrEn.DataBindings.Clear();
           // txt_AddrEn.DataBindings.Add("Text", bs_Applicant, "AddrEn", true, DataSourceUpdateMode.OnValidation, "", "");

           // txt_LiaisonAddr.DataBindings.Clear();
           // txt_LiaisonAddr.DataBindings.Add("Text", bs_Applicant, "LiaisonAddr", true, DataSourceUpdateMode.OnValidation, "", "");

           // //資本額
           // txt_Capital.DataBindings.Clear();
           // txt_Capital.DataBindings.Add("Text", bs_Applicant, "Capital", true, DataSourceUpdateMode.OnValidation, "", "");

           // //收款記錄
           // comboBox_CollectionRecord.DataBindings.Clear();
           // comboBox_CollectionRecord.DataBindings.Add("Text", bs_Applicant, "CollectionRecord", true, DataSourceUpdateMode.OnValidation, "", "");

           // //客戶評價
           // comboBox_Evaluation.DataBindings.Clear();
           // comboBox_Evaluation.DataBindings.Add("Text", bs_Applicant, "Evaluation", true, DataSourceUpdateMode.OnValidation, "", "");

           // //開始來往時間
           // maskedTextBox_StartedDate.DataBindings.Clear();
           // maskedTextBox_StartedDate.DataBindings.Add("Text", bs_Applicant, "StartedDate", true, DataSourceUpdateMode.OnPropertyChanged, "    /  /", "yyyy/MM/dd");

           // txt_ID.DataBindings.Clear();
           // txt_ID.DataBindings.Add("Text", bs_Applicant, "ID", true, DataSourceUpdateMode.OnValidation, "", "");

           // txt_Chage.DataBindings.Clear();
           // txt_Chage.DataBindings.Add("Text", bs_Applicant, "Chage", true, DataSourceUpdateMode.OnValidation, "", "");

           // txt_Business.DataBindings.Clear();
           // txt_Business.DataBindings.Add("Text", bs_Applicant, "Business", true, DataSourceUpdateMode.OnValidation, "", "");

           // txt_SendTitle.DataBindings.Clear();
           // txt_SendTitle.DataBindings.Add("Text", bs_Applicant, "SendTitle", true, DataSourceUpdateMode.OnValidation, "", "");

           // txt_Account.DataBindings.Clear();
           // txt_Account.DataBindings.Add("Text", bs_Applicant, "Account", true, DataSourceUpdateMode.OnValidation, "", "");

           // txt_Password.DataBindings.Clear();
           // txt_Password.DataBindings.Add("Text", bs_Applicant, "Password", true, DataSourceUpdateMode.OnValidation, "", "");

           // txt_TEL.DataBindings.Clear();
           // txt_TEL.DataBindings.Add("Text", bs_Applicant, "TEL", true, DataSourceUpdateMode.OnValidation, "", "");

           // txt_FAX.DataBindings.Clear();
           // txt_FAX.DataBindings.Add("Text", bs_Applicant, "FAX", true, DataSourceUpdateMode.OnValidation, "", "");

           // txt_Remark.DataBindings.Clear();
           // txt_Remark.DataBindings.Add("Text", bs_Applicant, "Remart", true, DataSourceUpdateMode.OnValidation, "", "");

           // txt_SourceDescription.DataBindings.Clear();
           // txt_SourceDescription.DataBindings.Add("Text", bs_Applicant, "SourceDescription", true, DataSourceUpdateMode.OnValidation, "", "");

           // txt_Receiptor.DataBindings.Clear();
           // txt_Receiptor.DataBindings.Add("Text", bs_Applicant, "Receiptor", true, DataSourceUpdateMode.OnValidation, "", "");

           // txt_Remark.DataBindings.Clear();
           // txt_Remark.DataBindings.Add("Text", bs_Applicant, "Remart", true, DataSourceUpdateMode.OnValidation, "", "");

           // Check_P.DataBindings.Clear();
           // Check_P.DataBindings.Add("Checked", bs_Applicant, "P", true, DataSourceUpdateMode.OnPropertyChanged, false);

           // Check_T.DataBindings.Clear();
           // Check_T.DataBindings.Add("Checked", bs_Applicant, "T", true, DataSourceUpdateMode.OnPropertyChanged, false);

           // Check_C.DataBindings.Clear();
           // Check_C.DataBindings.Add("Checked", bs_Applicant, "C", true, DataSourceUpdateMode.OnPropertyChanged, false);

           // Check_L.DataBindings.Clear();
           // Check_L.DataBindings.Add("Checked", bs_Applicant, "L", true, DataSourceUpdateMode.OnPropertyChanged, false);

           // Check_E.DataBindings.Clear();
           // Check_E.DataBindings.Add("Checked", bs_Applicant, "E", true, DataSourceUpdateMode.OnPropertyChanged, false);

           // checkBox_LawVIP.DataBindings.Clear();
           // checkBox_LawVIP.DataBindings.Add("Checked", bs_Applicant, "LawVIP",true,DataSourceUpdateMode.OnPropertyChanged,false);

           // comboBox_LargeEnty.DataBindings.Clear();
           // comboBox_LargeEnty.DataBindings.Add("SelectedValue", bs_Applicant, "LargeEnty");
                     

           // //所屬母公司
           // //txt_MainCorp.DataBindings.Clear();
           // //txt_MainCorp.DataBindings.Add("Text", bs_Applicant, "MainCorpName", true, DataSourceUpdateMode.OnValidation, "", "");
           // //所屬母公司
           // comboBox_MainCorp.DataBindings.Clear();
           // comboBox_MainCorp.DataBindings.Add("SelectedValue", bs_Applicant, "MainCorp");

           // comboBox_Worker.DataBindings.Clear();
           // comboBox_Worker.DataBindings.Add("SelectedValue", bs_Applicant, "Worker");

           // comboBox_Source.DataBindings.Clear();
           // comboBox_Source.DataBindings.Add("SelectedValue", bs_Applicant, "Source");

           // comboBox_RecWay.DataBindings.Clear();
           // comboBox_RecWay.DataBindings.Add("SelectedValue", bs_Applicant, "RecWay");

           // comboBox_ClientKind.DataBindings.Clear();
           // comboBox_ClientKind.DataBindings.Add("SelectedValue", bs_Applicant, "ClientKind");

           // comboBox2.DataBindings.Clear();
           // comboBox2.DataBindings.Add("SelectedValue", bs_Applicant, "BusinessKind");

        }

        public void CustomerTrackingRecordTInit()
        {
            txt_VitalRecord.DataBindings.Clear();
            txt_VitalRecord.DataBindings.Add("Text", customerTrackingRecordTBindingSource, "VitalRecord", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_ComplaintsComments.DataBindings.Clear();
            txt_ComplaintsComments.DataBindings.Add("Text", customerTrackingRecordTBindingSource, "ComplaintsComments", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_TrackingTransactions.DataBindings.Clear();
            txt_TrackingTransactions.DataBindings.Add("Text", customerTrackingRecordTBindingSource, "TrackingTransactions", true, DataSourceUpdateMode.OnValidation, "", "");
        
        }

        #endregion

        #region =================客戶快顯=================
        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            contextMenuStrip1.Visible = false;

            switch (e.ClickedItem.Name)
            {
                case "toolStripButton_AddApp":
                case "AddApplicantMenuItem":
                    AddFrom.AddApplicant add = new LawtechPTSystemByFirm.AddFrom.AddApplicant();
                    add.ShowDialog();
                    break;

                case "toolStripButton_DelApp":
                case "DelApplicantMenuItem":
                    if (GridView_Applicant.CurrentRow != null)
                    {
                        Public.DLL dll = new LawtechPTSystemByFirm.Public.DLL();

                        //判斷事務所有沒有被使用
                        //object obj= dll.SQLexecuteScalar("select count(Attorney) from FileT where Attorney=" + GridView_Attorney.CurrentRow.Cells["AttorneyKEY"].Value.ToString());

                        //if (obj!=null && obj.ToString() == "0")
                        //{
                        contextMenuStrip1.Visible = false;

                        if (MessageBox.Show("是否確定刪除 " + GridView_Applicant.CurrentRow.Cells["ApplicantName"].Value.ToString(), "確認視窗", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            dll.SQLexecuteNonQuery("delete LiaisonerT where ApplicantKey=" + GridView_Applicant.CurrentRow.Cells["ApplicantKey"].Value.ToString());

                            GridView_Applicant.Rows.Remove(GridView_Applicant.CurrentRow);

                            //dt_Applicant.AcceptChanges();

                            MessageBox.Show("刪除客戶成功");
                        }
                        //}
                        //else
                        //{
                        //    MessageBox.Show("該資料已被使用，為確保資料完整性，不得刪除");
                        //}
                    }
                    break;

                case "toolStripButton_EditApp":
                case "EditToolStripMenuItem":
                    EditForm.EditApplicant edit = new LawtechPTSystemByFirm.EditForm.EditApplicant();
                    edit.ApplicantKey = (int)GridView_Applicant.CurrentRow.Cells["ApplicantKey"].Value;
                    edit.ShowDialog();
                    break;

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
                case "toolStripMenuItem_VisibleColumn":

                    break;
            }
        }
        #endregion

        #region =================連絡人快顯=====================
        private void contextMenuStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            contextMenuStrip2.Visible = false;

            switch (e.ClickedItem.Name)
            {
                case "toolStripButton_add":
                case "AddLiaisonerMenuItem":
                   
                    if (GridView_Applicant.CurrentRow != null)
                    {
                        AddFrom.AddLiaisoner add = new LawtechPTSystemByFirm.AddFrom.AddLiaisoner();
                        add.ApplicantKey = (int)GridView_Applicant.CurrentRow.Cells["ApplicantKey"].Value;
                        add.ShowDialog();
                    }
                    break;

                case "toolStripButton_Del":
                case "DelLiaisonerMenuItem":
                    if (GridView_AttLiaisoner.CurrentRow != null)
                    {                       
                       

                        if (MessageBox.Show("是否確定刪除 " + GridView_AttLiaisoner.CurrentRow.Cells["Liaisoner"].Value.ToString(), "確認視窗", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            GridView_AttLiaisoner.Rows.Remove(GridView_AttLiaisoner.CurrentRow);

                            //dt_Liaisoner.AcceptChanges();

                            MessageBox.Show("刪除成功");
                        }                      
                    }
                    break;

                case "CopyToolStripMenuItem":
                    for (int iCopy = 0; iCopy < GridView_AttLiaisoner.Rows.Count; iCopy++)
                    {
                        if (GridView_AttLiaisoner.Rows[iCopy].Cells["CheckBox"].EditedFormattedValue.ToString() == "True")
                        {
                           //DataRow dr= dtLiaisonerTem.NewRow();
                           //dr["SN"] = (int)GridView_AttLiaisoner.Rows[iCopy].Cells["SN1"].Value;
                           //dr["Ext"] = GridView_AttLiaisoner.Rows[iCopy].Cells["Ext"].Value.ToString();
                           //dr["Liaisoner"] = GridView_AttLiaisoner.Rows[iCopy].Cells["Liaisoner"].Value.ToString();
                           //dr["Moblephone"] = GridView_AttLiaisoner.Rows[iCopy].Cells["Moblephone"].Value.ToString();
                           //dr["email"] = GridView_AttLiaisoner.Rows[iCopy].Cells["email"].Value.ToString();
                           //dr["Position"] = GridView_AttLiaisoner.Rows[iCopy].Cells["Rank"].Value.ToString();
                           //dr["Sex"] = GridView_AttLiaisoner.Rows[iCopy].Cells["Liaisoner"].Value.ToString();
                           //dr["LiaisonerAddr"] = GridView_AttLiaisoner.Rows[iCopy].Cells["Sex"].Value.ToString();
                           // dr["IsWindows"] =GridView_AttLiaisoner.Rows[iCopy].Cells["IsWindows"].Value.ToString()!=""? (int)GridView_AttLiaisoner.Rows[iCopy].Cells["IsWindows"].Value:-1;
                           // dr["Quit"] = GridView_AttLiaisoner.Rows[iCopy].Cells["Quit"].Value.ToString()!=""?(bool)GridView_AttLiaisoner.Rows[iCopy].Cells["Quit"].Value:false;
                           //dtLiaisonerTem.Rows.Add(dr);
                        }
                    }
                        break;

                case "PasteToolStripMenuItem":
                    if (GridView_Applicant.CurrentRow != null)
                    {
                        contextMenuStrip2.Visible = false;

                        if (MessageBox.Show("是否確定貼上新連絡人?", "提示訊息", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            //for (int iPaste = 0; iPaste < dtLiaisonerTem.Rows.Count; iPaste++)
                            //{
                                //Public.CLiaisoner add = new LawtechPTSystemByFirm.Public.CLiaisoner("1=0");
                                //add.ApplicantKey = (int)GridView_Applicant.CurrentRow.Cells["ApplicantKey"].Value;
                                //add.email = dtLiaisonerTem.Rows[iPaste]["email"].ToString();
                                //add.Ext = dtLiaisonerTem.Rows[iPaste]["Ext"].ToString();
                                //add.IsWindows = (int)dtLiaisonerTem.Rows[iPaste]["IsWindows"];
                                //add.LiaisonerName = dtLiaisonerTem.Rows[iPaste]["LiaisonerName"].ToString();
                                //add.LiaisonerAddr = dtLiaisonerTem.Rows[iPaste]["LiaisonerAddr"].ToString();
                                //add.Moblephone = dtLiaisonerTem.Rows[iPaste]["Moblephone"].ToString();
                                //add.Position = dtLiaisonerTem.Rows[iPaste]["Position"].ToString();
                                //add.Quit = (bool)dtLiaisonerTem.Rows[iPaste]["Quit"];
                                //add.Sex = dtLiaisonerTem.Rows[iPaste]["Sex"].ToString();
                                //add.Sort = (int)dtLiaisonerTem.Rows[iPaste]["Sort"];
                                //add.Insert();
                            //}
                            //BindAttLiaisoner();
                        }
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
                case "toolStripButton_AddCustomerRecord":
                case "ToolStripMenuItem_AddRecord":
                    if (GridView_Applicant.CurrentRow != null)
                    {
                        AddFrom.AddCustomerRecord add = new LawtechPTSystemByFirm.AddFrom.AddCustomerRecord();
                        add.ApplicantKey = (int)GridView_Applicant.CurrentRow.Cells["ApplicantKey"].Value;

                        add.ShowDialog();
                    }

                    break;
                case "toolStripButton_DelCustomerRecord":
                case "ToolStripMenuItem_DelRecord":

                    if (customerTrackingRecordTDataGridView.CurrentRow != null)
                    {                       
                        if (MessageBox.Show("是否確定刪除此筆往來記錄 ", "確認視窗", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            int iKey = (int)customerTrackingRecordTDataGridView.CurrentRow.Cells["TrackingRecordKey"].Value;
                            Public.CCustomerTrackingRecord CA_Del = new Public.CCustomerTrackingRecord();
                            Public.CCustomerTrackingRecord.ReadOne(iKey, ref CA_Del);

                            //刪除記錄檔
                            Public.CSystemLog log = new LawtechPTSystemByFirm.Public.CSystemLog();
                            log.DelTime = DateTime.Now;
                            log.DelWorkerKey = Properties.Settings.Default.WorkerKEY;
                            //string[] str = CA_Del.GetInsertString(iKey);
                            //log.TableName = str[2];
                            //log.DelContent_InsertColumn = str[0];
                            //log.DelContent_InsertSQL = str[1];
                            log.DelContent = string.Format("重要記錄:{0}\r\n抱怨與意見:{1}\r\n交易資料追縱:{2}", CA_Del.VitalRecord, CA_Del.ComplaintsComments, CA_Del.TrackingTransactions);
                            log.DelTitle = "刪除客戶往來記錄資料";
                            log.Create();

                            CA_Del.Delete(iKey);

                            customerTrackingRecordTDataGridView.Rows.Remove(customerTrackingRecordTDataGridView.CurrentRow);

                            this.dataSet_Applicant.CustomerTrackingRecordT.AcceptChanges();

                            MessageBox.Show("刪除成功");
                        }
                    }
                    break;

              
            }
        }
        #endregion

        #region GridView_Applicant_SelectionChanged
        private void GridView_Applicant_SelectionChanged(object sender, EventArgs e)
        {
            if (GridView_Applicant.CurrentRow != null)
            {
                BindAttLiaisoner();

                this.customerTrackingRecordTTableAdapter.Fill(this.qS_DataSet.CustomerTrackingRecordT, (int)GridView_Applicant.CurrentRow.Cells["ApplicantKey"].Value);

               this.inventorTTableAdapter.Fill(dataSet_Applicant.InventorT, (int)GridView_Applicant.CurrentRow.Cells["ApplicantKey"].Value);
            }
            else
            {
                this.customerTrackingRecordTTableAdapter.Fill(this.qS_DataSet.CustomerTrackingRecordT, -1);
                this.inventorTTableAdapter.Fill(dataSet_Applicant.InventorT, -1);
            }
        }
        #endregion

        #region  ===============查詢按鈕===============
        //查詢按鈕
        private void button1_Click(object sender, EventArgs e)
        {
            //switch (comboBox1.Text)
            //{ 
            //    case "客戶名稱":
            //        bs_Applicant.Filter = " ApplicantName like '%" + Combo_where .Text+ "%'";
            //        break;
            //    case "客戶代碼":
            //        bs_Applicant.Filter = " ApplicantSymbol like '%" + Combo_where.Text + "%'";
            //        break;
            //    case "統一編號":
            //        bs_Applicant.Filter = " ID like '%" + Combo_where.Text + "%'";
            //        break;
            //    case "TEL":
            //        bs_Applicant.Filter = " TEL like '%" + Combo_where.Text + "%'";
            //        break;
            //    case "本所客戶人員":
            //        if (Combo_where.SelectedValue != null)
            //        {
            //            bs_Applicant.Filter = " Worker=" + Combo_where.SelectedValue.ToString();
            //        }
            //        else
            //        {
            //            MessageBox.Show("本所客戶人員資料錯誤，請確認該人員【" + Combo_where .Text+ "】是否正確!!");
            //        }
            //        break;
            //    case "所屬母公司":
            //        if (Combo_where.SelectedValue != null)
            //        {
            //            bs_Applicant.Filter = " MainCorp=" + Combo_where.SelectedValue.ToString();
            //        }
            //        else
            //        {
            //            MessageBox.Show("所屬母公司資料錯誤，請確認該公司【" + Combo_where.Text + "】是否正確!!");
            //        }
            //        break;
            //    case "客戶種類":
            //        bs_Applicant.Filter = " ClientKind=" + Combo_where.SelectedValue.ToString();
            //        break;
            //    case "法顧客戶":
            //        bs_Applicant.Filter = " LawVIP=" + Combo_where.SelectedValue.ToString();
            //        break;
            //    case "聯絡地址":
            //        bs_Applicant.Filter = " Addr like '%" + Combo_where.Text + "%'";
            //        break;
            //    case "案件委託種類":                   
            //        bs_Applicant.Filter = Combo_where.SelectedValue.ToString()+ "=1 ";
            //        break;
            //}
        }
        #endregion

        #region  ====================全部按鈕====================
        //全部按鈕
        private void button2_Click(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;            
            Combo_where.Text = "";
            //bs_Applicant.Filter = " 1=1";
        }
        #endregion


        private void GridView_Applicant_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = false;
        }

        #region ============comboBox1_SelectedIndexChanged============
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dtSM = new DataTable();
            Public.DLL dll = new LawtechPTSystemByFirm.Public.DLL();
            string sSQL = "";
           
            switch (comboBox1.Text)
            {
                case "客戶名稱":
                    sSQL = "SELECT DISTINCT ApplicantName FROM ApplicantT";
                    dll.FetchDataTable(sSQL, dtSM);
                    Combo_where.DropDownStyle = ComboBoxStyle.DropDown;
                    Combo_where.AutoCompleteSource = AutoCompleteSource.ListItems;
                    Combo_where.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    Combo_where.DataSource = dtSM;
                    Combo_where.DisplayMember = "ApplicantName";
                    Combo_where.ValueMember = "ApplicantName";
                    Combo_where.Text="";
                    break;
                case "客戶代碼":
                    sSQL = "SELECT DISTINCT ApplicantSymbol FROM ApplicantT";
                    dll.FetchDataTable(sSQL, dtSM);
                    Combo_where.DropDownStyle = ComboBoxStyle.DropDown;
                    Combo_where.AutoCompleteSource = AutoCompleteSource.ListItems;
                    Combo_where.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    Combo_where.DataSource = dtSM;
                    Combo_where.DisplayMember = "ApplicantSymbol";
                    Combo_where.ValueMember = "ApplicantSymbol";
                    Combo_where.Text = "";
                    break;
                case "統一編號":
                    sSQL = "SELECT DISTINCT ID FROM ApplicantT";
                    dll.FetchDataTable(sSQL, dtSM);
                    Combo_where.DropDownStyle = ComboBoxStyle.DropDown;
                    Combo_where.AutoCompleteSource = AutoCompleteSource.ListItems;
                    Combo_where.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    Combo_where.DataSource = dtSM;
                    Combo_where.DisplayMember = "ID";
                    Combo_where.ValueMember = "ID";
                    Combo_where.Text = "";
                    break;
                case "TEL":
                    sSQL = "SELECT DISTINCT TEL FROM ApplicantT";
                    dll.FetchDataTable(sSQL, dtSM);
                    Combo_where.DropDownStyle = ComboBoxStyle.DropDown;
                    Combo_where.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    Combo_where.AutoCompleteSource = AutoCompleteSource.ListItems;
                   
                    Combo_where.DataSource = dtSM;
                    Combo_where.DisplayMember = "TEL";
                    Combo_where.ValueMember = "TEL";
                    Combo_where.Text = "";
                    break;
                case "本所客戶人員":
                    sSQL = "SELECT  Name,WorkerKey FROM  WorkerT WHERE (WorkerKey IN (SELECT DISTINCT Worker  FROM  ApplicantT))";
                    dll.FetchDataTable(sSQL, dtSM);
                   
                    Combo_where.DataSource = dtSM;
                    Combo_where.DropDownStyle = ComboBoxStyle.DropDown;
                    Combo_where.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    Combo_where.AutoCompleteSource = AutoCompleteSource.ListItems;
                    
                    Combo_where.DisplayMember = "Name";
                    Combo_where.ValueMember = "WorkerKey";
                    
                    break;
                case "所屬母公司":
                    sSQL = " SELECT  ApplicantName,ApplicantKey FROM  ApplicantT WHERE  (ApplicantKey IN (SELECT DISTINCT MainCorp  FROM  ApplicantT AS ApplicantT_1))";
                    dll.FetchDataTable(sSQL, dtSM);
                  
                    Combo_where.DataSource = dtSM;
                    Combo_where.DropDownStyle = ComboBoxStyle.DropDownList;
                    Combo_where.AutoCompleteMode = AutoCompleteMode.None;
                    Combo_where.AutoCompleteSource = AutoCompleteSource.None;
                   
                    Combo_where.DisplayMember = "ApplicantName";
                    Combo_where.ValueMember = "ApplicantKey";
                   
                    break;
                case "客戶種類":
                    Combo_where.DropDownStyle = ComboBoxStyle.DropDownList;
                    Combo_where.AutoCompleteMode = AutoCompleteMode.None;
                    Combo_where.AutoCompleteSource = AutoCompleteSource.None;
                   
                    sSQL = @"SELECT         1 AS Value, '本所客戶' AS String
                                                            UNION
                                                            SELECT         2 AS Value, '本所人頭' AS String
                                                            UNION
                                                            SELECT         3 AS Value, '開發中客戶' AS String
                                                            UNION
                                                            SELECT         4 AS Value, '爭議案相對人' AS String";
                    dll.FetchDataTable(sSQL, dtSM);
                    Combo_where.DataSource = dtSM;
                    Combo_where.DisplayMember = "String";
                    Combo_where.ValueMember = "Value";
                    
                    break;
                case "法顧客戶":
                    Combo_where.DropDownStyle = ComboBoxStyle.DropDownList;
                    Combo_where.AutoCompleteMode = AutoCompleteMode.None;
                    Combo_where.AutoCompleteSource = AutoCompleteSource.None;
                    sSQL = @"SELECT         1 AS Value, '是' AS String
                                                            UNION
                                                            SELECT         0 AS Value, '否' AS String
                                                           ";
                    dll.FetchDataTable(sSQL, dtSM);
                    Combo_where.DataSource = dtSM;
                    Combo_where.DisplayMember = "String";
                    Combo_where.ValueMember = "Value";
                    
                    break;
                case "聯絡地址":
                    sSQL = "SELECT DISTINCT Addr FROM ApplicantT";
                    dll.FetchDataTable(sSQL, dtSM);

                    Combo_where.DataSource = dtSM;
                    Combo_where.DropDownStyle = ComboBoxStyle.DropDown;
                    Combo_where.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    Combo_where.AutoCompleteSource = AutoCompleteSource.ListItems;

                    Combo_where.DisplayMember = "Addr";
                    Combo_where.ValueMember = "Addr";
                    break;
                case "案件委託種類":
                    Combo_where.DropDownStyle = ComboBoxStyle.DropDownList;
                    Combo_where.AutoCompleteMode = AutoCompleteMode.None;
                    Combo_where.AutoCompleteSource = AutoCompleteSource.None;
                   
                    sSQL = @"SELECT         'P' AS Value, '專利' AS String,1 as sort
                            UNION
                            SELECT         'T' AS Value, '商標' AS String,2 as sort
                            UNION
                            SELECT         'C' AS Value, '著作權' AS String,3 as sort
                            UNION
                            SELECT         'L' AS Value, '法務' AS String,4 as sort
                            UNION
                            SELECT         'LawVIP' AS Value, '法顧客戶' AS String,5 as sort
                            UNION
                            SELECT         'E' AS Value, '其他' AS String,6 as sort
                            order by sort ";
                    dll.FetchDataTable(sSQL, dtSM);
                    Combo_where.DataSource = dtSM;
                    

                    Combo_where.DisplayMember = "String";
                    Combo_where.ValueMember = "Value";
                    break;
            }

        }
        #endregion

        #region =================發明人=================
        private void contextMenuStrip_Inventor_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            contextMenuStrip_Inventor.Visible = false;
            switch (e.ClickedItem.Name)
            {
                case "toolStripMenuItem_AddInventor":
                case "toolStripButton_AddInventor":
                    AddFrom.AddInventor add = new LawtechPTSystemByFirm.AddFrom.AddInventor();
                    add.ApplicantKey = (int)GridView_Applicant.CurrentRow.Cells["ApplicantKey"].Value;
                    add.ShowDialog();
                    break;

                case "toolStripMenuItem_DelInventor":
                case "toolStripButton_EditInventor":

                    if (inventorTDataGridView.CurrentRow != null)
                    {
                        if (MessageBox.Show("是否確定刪除此筆發明人【" + inventorTDataGridView.CurrentRow.Cells["InventorName"].Value.ToString() + "】 ", "確認視窗", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            Public.CInventor CA_Del = new Public.CInventor();
                            CA_Del.Delete((int)inventorTDataGridView.CurrentRow.Cells["InventorKey"].Value);

                            inventorTDataGridView.Rows.Remove(inventorTDataGridView.CurrentRow);

                            this.dataSet_Applicant.InventorT.AcceptChanges();

                            MessageBox.Show("刪除成功");
                        }
                    }
                    break;


            }
        }
        #endregion

        #region GridView_AttLiaisoner_CellClick
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

        #region GridView_Applicant_CellContentClick
        private void GridView_Applicant_CellContentClick(object sender, DataGridViewCellEventArgs e)
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
                    if (GridView_Applicant.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Replace("http://", "").Trim() != "")
                    {
                        Public.Utility.ProcessStart("http://" + GridView_Applicant.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Replace("http://", ""));
                    }
                }
            }
        }
        #endregion

        #region contextMenuStrip_Inventor_ItemClicked_1
        private void contextMenuStrip_Inventor_ItemClicked_1(object sender, ToolStripItemClickedEventArgs e)
        {
            contextMenuStrip_Inventor.Visible = false;
            switch (e.ClickedItem.Name)
            {
                case "toolStripMenuItem_AddInventor":
                case "toolStripButton_AddInventor":
                    AddFrom.AddInventor add = new LawtechPTSystemByFirm.AddFrom.AddInventor();
                    add.ApplicantKey = (int)GridView_Applicant.CurrentRow.Cells["ApplicantKey"].Value;
                    add.ShowDialog();
                    break;

                case "toolStripMenuItem_DelInventor":
                case "toolStripButton_DelInventor":

                    if (inventorTDataGridView.CurrentRow != null)
                    {
                        if (MessageBox.Show("是否確定刪除此筆發明人【" + inventorTDataGridView.CurrentRow.Cells["InventorName"].Value.ToString() + "】 ", "確認視窗", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            Public.CInventor CA_Del = new Public.CInventor();
                            CA_Del.Delete((int)inventorTDataGridView.CurrentRow.Cells["InventorKey"].Value);

                            inventorTDataGridView.Rows.Remove(inventorTDataGridView.CurrentRow);

                            this.dataSet_Applicant.InventorT.AcceptChanges();

                            MessageBox.Show("刪除成功");
                        }
                    }
                    break;
            }
        }
        #endregion

        #region button3_Click
        private void button3_Click(object sender, EventArgs e)
        {
            switch (comboBox3.Text)
            { 
                case "發明人姓名":
                    bindingSource_Inventor.Filter = string.Format("InventorName like '%{0}%'",textBox1.Text);
                    break;
                case "FamilyName":
                    bindingSource_Inventor.Filter = string.Format("FamilyName like '%{0}%'", textBox1.Text);
                    break;
                case "GivenName":
                    bindingSource_Inventor.Filter = string.Format("GivenName like '%{0}%'", textBox1.Text);
                    break;
                case "ID":
                    bindingSource_Inventor.Filter = string.Format("ID like '%{0}%'", textBox1.Text);
                    break;
                case "地址":
                    bindingSource_Inventor.Filter = string.Format("Address like '%{0}%'", textBox1.Text);
                    break;
                default:
                    bindingSource_Inventor.Filter = "";
                    break;

            }
        }
        #endregion

        #region but_MoneyList_Click
        private void but_MoneyList_Click(object sender, EventArgs e)
        {
            if (!splitContainer1.Panel2Collapsed)
            {
                but_MoneyList.Text = "開啟客戶明細(Alt+E)";

                splitContainer1.Panel2Collapsed = true;
            }
            else
            {
                but_MoneyList.Text = "關閉客戶明細(Alt+E)";
                splitContainer1.Panel2Collapsed = false;
            }

        }
        #endregion

        #region ApplicantMF_KeyDown
        private void ApplicantMF_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt)
            {
                if (e.KeyCode == Keys.E)
                {
                    but_MoneyList_Click(null, null);
                }
            }
        }
        #endregion

        #region GridView_Applicant_ColumnHeaderMouseDoubleClick
        private void GridView_Applicant_ColumnHeaderMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //if (e.RowIndex == -1 && e.ColumnIndex != -1)
            //{
            //    GridView_Applicant.Columns[e.ColumnIndex].Visible = false;
            //}
        }
        #endregion

        #region linkLabel1_LinkClicked
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
             LinkLabel link = (LinkLabel)sender;
            US.PopMemo pop;
            switch (link.Name)
            {
                case "linkLabel_TrackingTransactions":
                    pop = new LawtechPTSystemByFirm.US.PopMemo(txt_TrackingTransactions, true, link.Text);
                    break;
                case "linkLabel_VitalRecord":
                    pop = new LawtechPTSystemByFirm.US.PopMemo(txt_VitalRecord, true, link.Text);
                    break;

                case "linkLabel_ComplaintsComments":
                    pop = new LawtechPTSystemByFirm.US.PopMemo(txt_ComplaintsComments, true, link.Text);
                    break;
                case "linkLabel_Remark":
                    pop = new LawtechPTSystemByFirm.US.PopMemo(txt_Remark, true, link.Text);
                    break;
                default:
                    pop = new LawtechPTSystemByFirm.US.PopMemo(txt_Remark, true, link.Text);
                    break;
            }

            pop.Show();
        }
        #endregion

    }
}