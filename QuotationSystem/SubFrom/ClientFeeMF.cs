using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using H3Operator.DBHelper;
using System.Threading.Tasks;

namespace LawtechPTSystem.SubFrom
{
    /// <summary>
    /// 客戶報價處理
    /// </summary>
    public partial class ClientFeeMF : Form
    {

        #region =====自定變數=====
        //Public.CApplicant ca;
        //Public.CLiaisoner cl;

        DataTable masterDT = new DataTable(); //主表單Table
        /// <summary>
        /// 主表單Table
        /// </summary>
        public DataTable MasterDT
        {
            get { return masterDT; }
            set { masterDT = value; }
        }

        DataTable detailDT=new DataTable(); 
        /// <summary>
        /// 明細表單Table
        /// </summary>
        public DataTable DetailDT
        {
            get { return detailDT; }
            set { detailDT = value; }
        }

        /// <summary>
        /// 主表單BindingSource
        /// </summary>
        BindingSource bSource_ClientFeeMaster; 

        /// <summary>
        /// 明細表單BindingSource
        /// </summary>
        BindingSource bSource_ClientFeeDetail; 
        #endregion

        #region =====Property=====
        private int Mode = -1;
        /// <summary>
        /// 報價模式 0.對客戶報價 1.對複代報價
        /// </summary>
        public int FeeMode
        {
            get { return Mode; }
            set { Mode = value; }
        }

        private int iLanguage = 1;
        /// <summary>
        /// 語系 : 1.繁體 2.簡體  3.英文
        /// </summary>
        public int Language
        {
            get { return iLanguage; }
            set { iLanguage = value; }
        }
        #endregion 

        public ClientFeeMF()
        {
            InitializeComponent();

            dataGridView1.AutoGenerateColumns = false;
            dataGridView2.AutoGenerateColumns = false;
            Public.DynamicGridViewColumn.GetGridColum(ref dataGridView1);
            Public.DynamicGridViewColumn.GetGridColum(ref dataGridView2);
        }

        #region  private void ClientFeeMF_Load(object sender, EventArgs e)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClientFeeMF_Load(object sender, EventArgs e)
        {
           
            this.applicantTTableAdapter.Fill(this.dataSet_Drop.ApplicantT);
            Public.PublicForm Forms = new Public.PublicForm();
            Forms.ClientFeeMF = this;

            this.attorneyTTableAdapter.Fill(this.dataSet_Drop.AttorneyT);           

            this.languagesTTableAdapter.Fill(this.dataSet_Drop.LanguagesT);
           
            
            
            cbbPrintMode.SelectedIndex = 1;

            comboBox_Mode.SelectedIndex = 0;             

            if (cbbCompany.SelectedValue.ToString() != "")
            {
                LoadMaster();
                LoadDetail();
            }

            
            dataGridView2.DataSource = bSource_ClientFeeDetail;
            bindingNavigator2.BindingSource = bSource_ClientFeeDetail;

            if (detailDT == null)
            {
                detailDT = new DataTable();
            }

            this.cbbCompany.SelectedIndexChanged += new System.EventHandler(this.cbbCompany_SelectedIndexChanged);

            masterDT.ColumnChanged += new DataColumnChangeEventHandler(masterDT_ColumnChanged);

            detailDT.ColumnChanged += new DataColumnChangeEventHandler(detailDT_ColumnChanged);
            cbbCompany.Tag = "ok";

           
        }

        #endregion

        private void masterDT_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            try
            {
                if (e.Row.RowState == DataRowState.Unchanged)
                {
                    switch (e.Column.ColumnName)
                    {
                        case "IsPrint":
                            bool bPrint;
                            bool isSuccess = bool.TryParse(e.Row["IsPrint"].ToString(), out bPrint);
                            string strAppkey = e.Row["ApplicantKey"].ToString();
                            string strCountry = e.Row["Country"].ToString();
                            string strKind = e.Row["Kind"].ToString();
                            string strLargeEntity = e.Row["LargeEntity"].ToString();
                            string strApplicantMode = e.Row["ApplicantMode"].ToString();
                            Public.CnTriffPublicFunction.UpdateClientFeeDetailList(strAppkey, strCountry, strKind, strLargeEntity, strApplicantMode, bPrint.ToString());

                            break;
                    }
                }
            }
            catch (SystemException ex)
            {
                MessageBox.Show("ClientFeeMF (masterDT_ColumnChanged) :" + ex.Message, "提示訊息");

            }
        }

        #region detailDT_ColumnChanged
        void detailDT_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            try
            {
                if (e.Row.RowState == DataRowState.Unchanged)
                {
                    Public.CClientFee cf = new Public.CClientFee();
                    Public.CClientFee.ReadOne((int)e.Row["ClientFeeSN"], ref cf);

                    cf.LastModifyWorker = Properties.Settings.Default.WorkerName;

                    switch (e.Column.ColumnName)
                    {
                        case "MeFee":
                            decimal QuotaTotal = isNumeric(e.Row["QuotaTotal"].ToString(), "decimal") ? decimal.Parse(e.Row["QuotaTotal"].ToString()) : 0;
                            decimal GovFeeNT = isNumeric(e.Row["GovFeeNT"].ToString(), "decimal") ? decimal.Parse(e.Row["GovFeeNT"].ToString()) : 0;
                            decimal AttorneyFeeNT = isNumeric(e.Row["AttorneyFeeNT"].ToString(), "decimal") ? decimal.Parse(e.Row["AttorneyFeeNT"].ToString()) : 0;
                            decimal MeFee = isNumeric(e.Row["MeFee"].ToString(), "decimal") ? decimal.Parse(e.Row["MeFee"].ToString()) : 0;
                            QuotaTotal = GovFeeNT + AttorneyFeeNT + MeFee;

                            cf.QuotaTotal = QuotaTotal;
                            cf.MeFee = MeFee;

                            break;
                        case "Remark":
                            cf.Remark = e.Row["Remark"].ToString();
                            break;
                        case "Sort":
                            int intSN;
                            bool isSN = int.TryParse(e.Row["Sort"].ToString(), out intSN);
                            cf.SN = isSN ? intSN : 0;
                            break;
                        case "QuotaTotal":
                            //return;
                            break;
                       
                    }

                    cf.Update();
                    this.DetailDT.AcceptChanges();
                }
            }
            catch (SystemException ex)
            {
                MessageBox.Show("ClientFeeMF (detailDT_ColumnChanged):" + ex.Message, "提示訊息");

            }
        }
        #endregion

        #region =====讀取主表單和明細表單資料=====
      
        /// <summary>
        /// 讀取主表單資料
        /// </summary>
        private void LoadMaster()
        {

            //查詢所選公司人員           
            if (FeeMode == 0)
            {
                //客戶聯絡人
                if (cbbCompany.SelectedValue != null && cbbCompany.SelectedValue.GetType().FullName=="System.Int32")
                {
                    this.liaisonerTOnlineTableAdapter.Fill(this.qS_DataSet.LiaisonerTOnline, (int)cbbCompany.SelectedValue);
                }
            }
            else
            {
                //複代聯絡人
                if (cbbCompany.SelectedValue != null && cbbCompany.SelectedValue.GetType().FullName == "System.Int32")
                {
                    this.attLiaisonerT_AllTableAdapter.Fill(this.dataSet_Drop.AttLiaisonerT_All, (int)cbbCompany.SelectedValue);

                }
            }

            if (cbbCompany.SelectedValue != null && cbbCompany.SelectedValue.GetType().FullName == "System.Int32")
            {

                if (masterDT.Rows.Count > 0)
                {
                    masterDT.Rows.Clear();
                }
                Public.CnTriffPublicFunction.GetClientFeeList(cbbCompany.SelectedValue.ToString(), comboBox_Mode.SelectedIndex.ToString(), ref masterDT);
                if (bSource_ClientFeeMaster == null)
                {
                    bSource_ClientFeeMaster = new BindingSource();
                    bSource_ClientFeeMaster.DataSource = masterDT;
                    

                    dataGridView1.DataSource = bSource_ClientFeeMaster;
                    bindingNavigator1.BindingSource = bSource_ClientFeeMaster;
                }
            }
        }

       
        /// <summary>
        /// 讀取明細資料
        /// </summary>
        private void LoadDetail()
        {
            if (cbbCompany.SelectedValue != null && cbbCompany.SelectedValue.GetType().FullName == "System.Int32" && dataGridView1.CurrentRow != null)
            {              
                string strCountrySymbol = dataGridView1.CurrentRow.Cells["Country"].Value.ToString();
                string strKindSN = dataGridView1.CurrentRow.Cells["Kind"].Value.ToString();
                string bLargeEntity = ((bool)dataGridView1.CurrentRow.Cells["LargeEntity"].Value) ? "1" : "0";


                if (detailDT.Rows.Count > 0)
                {
                    detailDT.Rows.Clear();
                }
                Public.CnTriffPublicFunction.GetClientFeeDetailList(cbbCompany.SelectedValue.ToString(), strCountrySymbol, strKindSN, bLargeEntity, comboBox_Mode.SelectedIndex.ToString(), ref detailDT);

                if (bSource_ClientFeeDetail == null)
                {
                    bSource_ClientFeeDetail = new BindingSource();
                    bSource_ClientFeeDetail.DataSource = detailDT;
                    bindingNavigator2.BindingSource = bSource_ClientFeeDetail;
                }

                if (dataGridView2.DataSource == null)
                {
                    dataGridView2.DataSource = bSource_ClientFeeDetail;
                }
            }
            else
            {
                if (detailDT != null && detailDT.Rows.Count > 0)
                    detailDT.Rows.Clear();
            }
        }
        #endregion

        #region 檢查是否為數值,Type: int or decimal
        //檢查是否為數值,Type: int or decimal
        private bool isNumeric(string Value, string type)
        {
            bool IsSuccess = false;
            switch (type)
            {
                case "int":
                    try
                    {
                        int i=0;
                      IsSuccess=  int.TryParse(Value,out i);
                    }
                    catch 
                    {
                       
                    }
                    break;
                case "decimal":
                    try
                    {
                        decimal dec = 0;
                     IsSuccess=   decimal.TryParse(Value, out dec);
                    }
                    catch 
                    {
                        
                    }
                    break;
            }
            return IsSuccess;
        }
        #endregion

        #region =====btnExit_Click=====
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region =====btnJoinQuotation_Click=====
        private void btnJoinQuotation_Click(object sender, EventArgs e)
        {
            AddFrom.AddCustQuotation acq = new AddFrom.AddCustQuotation();

            if (acq != null)
            {
                acq.ApplicantKey = int.Parse(cbbCompany.SelectedValue.ToString());
                acq.ApplicantMode = comboBox_Mode.SelectedIndex;
                if (acq.ShowDialog() == DialogResult.OK)
                {
                    LoadMaster();
                    LoadDetail();
                }
            }
        }
        #endregion

        #region =====cbbCompany_SelectedIndexChanged=====
        private void cbbCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbCompany.SelectedValue != null && cbbCompany.SelectedValue.GetType().FullName == "System.Int32")
            {
                LoadMaster();
                LoadDetail();
            }
        }
        #endregion

        #region =====內容快顯(cmsMaster & cmsDetail)=====
        private void cmsMaster_Opening(object sender, CancelEventArgs e)
        {
            //if (masterDT.Rows.Count > 0)
            //    cmsMaster.Visible = true;
            //else
            //    cmsMaster.Visible = false;
        }

        private void cmsMaster_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            cmsMaster.Visible = false;
            switch (e.ClickedItem.Name)
            {
                case "cmiMaterDelete":
                    int iCount = dataGridView1.SelectedRows.Count;
                    if (iCount > 0)
                    {
                        if (MessageBox.Show("是否要刪除所選項目？\r\n" + dataGridView1.CurrentRow.Cells["CountryName"].Value.ToString() + "  " + dataGridView1.CurrentRow.Cells["KindName"].Value.ToString(), "刪除", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            foreach (DataGridViewRow dgvr in dataGridView1.SelectedRows)
                            {
                                string SQLCommand = "Delete From ClientFeeT Where ApplicantKey = {0} And Country = '{1}' And Kind = '{2}' And LargeEntity = {3}";
                                string key = cbbCompany.SelectedValue.ToString();
                                string c = dataGridView1.CurrentRow.Cells["Country"].Value.ToString();
                                string k = dataGridView1.CurrentRow.Cells["Kind"].Value.ToString();
                                string en = ((bool)dataGridView1.CurrentRow.Cells["LargeEntity"].Value) == true ? "1" : "0";

                                Public.DLL dll = new Public.DLL();
                                dll.SQLexecuteNonQuery(string.Format(SQLCommand, key, c, k, en));
                                masterDT.Rows[dataGridView1.CurrentRow.Index].Delete();
                              
                                masterDT.AcceptChanges();
                            }
                        }
                    }
                    break;
                case "toolStripMenuItem_Add":
                    btnJoinQuotation_Click(null,null);
                    break;
                case "toolStripMenuItem2":
                    if (splitContainer1.Orientation == Orientation.Horizontal)
                    {
                        splitContainer1.Orientation = Orientation.Vertical;
                    }
                    else
                    {
                        splitContainer1.Orientation = Orientation.Horizontal;
                    }
                    break;
                case "toolStripMenuItem_AllCheck":
                    if (dataGridView1.Rows.Count > 0)
                    {
                        //dataGridView1.CurrentCell.Selected = false;
                        //dataGridView1.CurrentRow.Cells["StaYear"].Selected = true;

                        for (int i = 0; i < dataGridView1.Rows.Count; i++)
                        {
                            dataGridView1.Rows[i].Cells["Print"].Value = true;
                        }
                    }
                    break;
                case "toolStripMenuItem_Clear":
                    if (dataGridView1.Rows.Count > 0)
                    {
                        //dataGridView1.CurrentCell.Selected = false;
                        //dataGridView1.CurrentRow.Cells["StaYear"].Selected = true;

                        for (int i = 0; i < dataGridView1.Rows.Count; i++)
                        {
                            dataGridView1.Rows[i].Cells["Print"].Value = false;
                        }
                    }
                    break;
                default:
                    break;
            }
        }

        private void cmsDetail_Opening(object sender, CancelEventArgs e)
        {
            cmsDetail.Items["cmiDetailAddNew"].Enabled = (dataGridView1.Rows.Count > 0) ? true : false;
            cmsDetail.Items["cmiDetailDelete"].Enabled = (dataGridView2.Rows.Count > 0) ? true : false;
            cmsDetail.Items["cmiResort"].Enabled = (dataGridView2.Rows.Count > 0) ? true : false;
        }

        private void cmsDetail_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Name)
            {
                case "cmiDetailAddNew":
                    AddFrom.AddCustQuotationNew addNew = new AddFrom.AddCustQuotationNew();
                    
                    addNew.Country = dataGridView1.CurrentRow.Cells["Country"].Value.ToString();
                    addNew.Kind = dataGridView1.CurrentRow.Cells["Kind"].Value.ToString();
                    addNew.Largeentity = bool.Parse(dataGridView1.CurrentRow.Cells["LargeEntity"].Value.ToString());
                    addNew.BuildedDate = DateTime.Now;
                    addNew.ApplicantKey = cbbCompany.SelectedValue!=null?(int)cbbCompany.SelectedValue:0;
                    addNew.Text += "--" + dataGridView1.CurrentRow.Cells["CountryName"].Value.ToString() + "," + dataGridView1.CurrentRow.Cells["KindName"].Value.ToString();
                    addNew.NewRow = detailDT.NewRow();
                    if (addNew.ShowDialog() == DialogResult.OK)
                    {
                       
                    }
                    break;
                case "cmiDetailDelete":
                    int iCount = dataGridView2.SelectedRows.Count;
                    if (iCount > 0)
                    {
                        if (MessageBox.Show(string.Format("是否要刪除所選項目，共 {0} 筆？", iCount.ToString()), "刪除", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            string SQLCommand = "Delete From ClientFeeT Where ";
                            int i = 1;
                            foreach (DataGridViewRow dgvr in dataGridView2.SelectedRows)
                            {
                                SQLCommand += string.Format("ClientFeeSN = {0} ", dgvr.Cells["ClientFeeSN"].Value.ToString());
                                SQLCommand += (i > 0 && i < iCount) ? " OR " : "";
                                
                                //刪除detailDT相對項目
                                detailDT.Rows[dgvr.Index].Delete();
                                i++;
                            }
                            detailDT.AcceptChanges();

                            //刪除所選項目
                            Public.DLL dll = new Public.DLL();
                            dll.SQLexecuteNonQuery(SQLCommand);
                        }
                        dataGridView1.CurrentRow.Cells["ItemCount"].Value = (int)dataGridView1.CurrentRow.Cells["ItemCount"].Value - iCount;
                    }
                    break;

                //重新排序索引
                case "cmiResort":
                    if (MessageBox.Show("是否對目前排列做重新排序動作？", this.Name, MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        for (int i = 0; i < dataGridView2.Rows.Count; i++)
                        {
                            dataGridView2.Rows[i].Cells["Sort"].Value = i + 1;
                        }
                    }
                    break;

                default:
                    break;
            }
        }
        #endregion

        #region =====dataGridView事件=====
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            LoadDetail();
        }

        //重新定位主表單BindingSource位置
        private void dataGridView1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            //bSource_ClientFeeMaster.Position = e.RowIndex;
        }

        //重新定位明細表單BindingSource位置
        private void dataGridView2_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            bSource_ClientFeeDetail.Position = e.RowIndex;
        }
        #endregion

        #region =====報表列印=====
        private void btnPrint_Click(object sender, EventArgs e)
        {
            int c = 0;
            string appKey = cbbCompany.SelectedValue.ToString();
            DBAccess dbhelper = new DBAccess();
            
            //將選取列印項目Copy到ClientFeeT_Temp裡做暫存
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                if (dataGridView1.Rows[i].Cells["Print"].Value == null || dataGridView1.Rows[i].Cells["Print"].Value.ToString() == "False")
                {
                    
                    continue;
                }
                if (dataGridView1.Rows[i].Cells["Print"].Value.ToString() == "True")
                {  
                    string ApplicantMode = comboBox_Mode.SelectedIndex.ToString();
                    string countryKey = dataGridView1.Rows[i].Cells["Country"].Value.ToString();
                    string kindKey = dataGridView1.Rows[i].Cells["Kind"].Value.ToString();
                    string largeEntity = ((bool)dataGridView1.Rows[i].Cells["LargeEntity"].Value == true) ? "1" : "0";

                    //先清空ClientFeeT_Temp裏的暫存資料
                    dbhelper.ExecuteNonQuery(string.Format("Delete From ClientFeeT_Temp where ApplicantKey ={0} And Country = '{1}' And Kind = '{2}'", appKey, countryKey, kindKey));

                    string SQLCommand = string.Format("select * from ClientFeeT with(nolock) where ApplicantKey ={0} And Country = '{1}' And Kind = '{2}' And LargeEntity = {3} and ApplicantMode={4}", appKey, countryKey, kindKey, largeEntity, ApplicantMode);   
                    DataTable dtTemp = new DataTable();
                    dbhelper.QueryToDataTableByDataAdapter(SQLCommand, ref dtTemp);
                    dbhelper.SqlBulkCopyWriteToServer(dtTemp, Public.PublicCommonFunction.GetConnectionString(), "ClientFeeT_Temp");
                    c++;
                }
                
            }

            if (c > 0)
            {
                switch (cbbPrintMode.SelectedIndex)
                {
                    //精簡模式
                    case 0:
                        ReportView.Quotation1 Report1 = new ReportView.Quotation1();
                        Report1.ApplicantKey = int.Parse(cbbCompany.SelectedValue.ToString());
                        Report1.Liaisoner = cbbLiaisoner.Text;
                        Report1.Language = (int)comboBox_Language.SelectedValue;
                        Report1.ApplicantMode = (int)comboBox_Mode.SelectedIndex;
                        Report1.Show();
                        break;

                    //基本模式
                    case 1:
                        ReportView.Quotation2 Report2 = new ReportView.Quotation2();
                        Report2.ApplicantKey = int.Parse(cbbCompany.SelectedValue.ToString());
                        Report2.Liaisoner = cbbLiaisoner.Text;
                        Report2.Language = (int)comboBox_Language.SelectedValue;
                        Report2.ApplicantMode = (int)comboBox_Mode.SelectedIndex;
                        Report2.Show();
                        break;

                    //專業模式
                    case 2:
                        ReportView.Quotation3 Report3 = new ReportView.Quotation3();
                        Report3.ApplicantKey = int.Parse(cbbCompany.SelectedValue.ToString());
                        Report3.Liaisoner = cbbLiaisoner.Text;
                        Report3.Language = (int)comboBox_Language.SelectedValue;
                        Report3.ApplicantMode = (int)comboBox_Mode.SelectedIndex;
                        Report3.Show();
                        break;

                    //清單模式
                    case 3:
                        ReportView.Quotation4 Report4 = new ReportView.Quotation4();
                        Report4.ApplicantKey = int.Parse(cbbCompany.SelectedValue.ToString());
                        Report4.Liaisoner = cbbLiaisoner.Text;
                        Report4.Language = (int)comboBox_Language.SelectedValue;
                        Report4.ApplicantMode = (int)comboBox_Mode.SelectedIndex;
                        Report4.Show();
                        break;
                }
            }
            else
            {
                MessageBox.Show("請勾選報價總表中要列印的項目", "提示訊息");
            }

        }
        #endregion

        #region ClientFeeMF_FormClosed
        //結束表單
        private void ClientFeeMF_FormClosed(object sender, FormClosedEventArgs e)
        {
            Public.PublicForm Forms = new Public.PublicForm();
            Forms.ClientFeeMF = null;
        }
        #endregion

        #region comboBox_Mode_SelectedIndexChanged
        private void comboBox_Mode_SelectedIndexChanged(object sender, EventArgs e)
        {
            Mode = comboBox_Mode.SelectedIndex;
            this.cbbCompany.SelectedIndexChanged -= new System.EventHandler(this.cbbCompany_SelectedIndexChanged);

            
            if (comboBox_Mode.SelectedIndex == 0)
            {
                //客戶
                this.applicantTTableAdapter.Fill(this.dataSet_Drop.ApplicantT);
                cbbCompany.DataSource = applicantTDropBindingSource;
                cbbCompany.DisplayMember = "ApplicantSymbolName";
                cbbCompany.ValueMember = "ApplicantKey";
               
                //聯絡人
                if (cbbCompany.SelectedValue != null)
                {
                    this.liaisonerTOnlineTableAdapter.Fill(this.qS_DataSet.LiaisonerTOnline, (int)cbbCompany.SelectedValue);
                    cbbLiaisoner.DataSource = liaisonerTOnlineBindingSource;
                    cbbLiaisoner.DisplayMember = "LiaisonerName";
                    cbbLiaisoner.ValueMember = "LiaisonerKey";
                }
            }
            else
            {
                //複代
                this.attorneyTTableAdapter.Fill(this.dataSet_Drop.AttorneyT);
                cbbCompany.DataSource = attorneyTBindingSource;
                cbbCompany.DisplayMember = "AttorneyFirm";
                cbbCompany.ValueMember = "AttorneyKey";

                //複代聯絡人
                if (cbbCompany.SelectedValue != null)
                {                   
                    this.attLiaisonerT_AllTableAdapter.Fill(this.dataSet_Drop.AttLiaisonerT_All, (int)cbbCompany.SelectedValue);
                    cbbLiaisoner.DataSource = attorneyTAttLiaisonerTBindingSource;
                    cbbLiaisoner.DisplayMember = "Liaisoner";
                    cbbLiaisoner.ValueMember = "ALiaisonerKey";
                }
            }

            this.cbbCompany.SelectedIndexChanged += new System.EventHandler(this.cbbCompany_SelectedIndexChanged);
            cbbCompany_SelectedIndexChanged(null, null);
        }
        #endregion

        private void dataGridView2_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = false;
        }

        #region toolStripButton_Excel_Click
        private void toolStripButton_Excel_Click(object sender, EventArgs e)
        {
            try
            {
                Public.DLL dll = new Public.DLL();
                Task task = dll.WriteToCSV(dataGridView2);
            }
            catch
            {
                MessageBox.Show("匯出 CSV失敗");
            }
        }
        #endregion

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (splitContainer1.Orientation == Orientation.Horizontal)
            {
                splitContainer1.Orientation = Orientation.Vertical;
            }
            else
            {
                splitContainer1.Orientation = Orientation.Horizontal;
            }
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = false;
            //int i = e.ColumnIndex;
            //int r = e.RowIndex;
            //string s = e.Context.ToString();
        }

    }
}