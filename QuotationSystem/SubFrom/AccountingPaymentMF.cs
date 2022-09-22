using System;
using System.ComponentModel;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LawtechPTSystem.SubFrom
{
    /// <summary>
    /// 帳務管理--應付款項列表
    /// </summary>
    public partial class AccountingPaymentMF : Form
    {
        BindingSource bSource_Control;
        BindingSource bSource_ControlList;

        UserPermissionForm myPermission;
        private const string ProgramSymbol = "AccountingPaymentMF";
        private const string SourceTableName = "";

        #region =====property=====
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

        /// <summary>
        /// 取得資料集來源
        /// </summary>
        public DataTable GetAccountingData
        {
            get
            {
                return (DataTable)bSource_Control.DataSource;
            }
        }

        /// <summary>
        /// 目前的DataGridViewRow CurrentRow
        /// </summary>
        public DataGridViewRow GV_CurrentRow
        {
            get
            {
                return dgViewMF.CurrentRow;
            }
        }

        public DataRow GetAccountingDataRow
        {
            get
            {
                return ((System.Data.DataRowView)(dgViewMF.CurrentRow.DataBoundItem)).Row;
            }
        }
        #endregion

        public AccountingPaymentMF()
        {
            InitializeComponent();
            dgViewMF.AutoGenerateColumns = false;
            Public.DynamicGridViewColumn.GetGridColum(ref dgViewMF);
        }

        private void but_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region but_Excel_Click
        private void but_Excel_Click(object sender, EventArgs e)
        {
            try
            {
                Public.DLL dll = new Public.DLL();
                Task t = dll.WriteToCSV(dgViewMF);
            }
            catch
            {
                MessageBox.Show("匯出CSV失敗:匯出過程發生異常被終止");
            }
        }
        #endregion

        #region AccountingPaymentMF_Load FormClose
        private void AccountingPaymentMF_Load(object sender, EventArgs e)
        {
            Public.PublicForm Forms = new Public.PublicForm();
            Forms.AccountingPaymentMF = this;

            but_MoneyList_Click(null,null);

            //登入者
            iWorkerID = Properties.Settings.Default.WorkerKEY;
            Worker_Model worker = new Worker_Model();
            Worker_Model.ReadOne(iWorkerID, ref  worker);
           
            //角色的權限
            OfficeRole = worker.OfficeRole.Value;

            //取得權限
            myPermission = new UserPermissionForm(Properties.Settings.Default.WorkerKEY, ProgramSymbol);

            System.Windows.Forms.BindingNavigator[] listbinding = { bindingNavigator1, bindingNavigator2 };
            System.Windows.Forms.ContextMenuStrip[] listtMenu = { contextMenuStrip_Accounting };

            //確認可使用的功能選單
            Public.CommonFunctions.CheckMeunItemVisible(listbinding, myPermission.UserPermission);
            Public.CommonFunctions.CheckMeunItemVisible(listtMenu, myPermission.UserPermission); 


            bSource_Control = new BindingSource();
            dgViewMF.DataSource = bSource_Control;
            bindingNavigator1.BindingSource = bSource_Control;

            dataGridView1.AutoGenerateColumns = false;
            bSource_ControlList = new BindingSource();
            dataGridView1.DataSource = bSource_ControlList;
            bindingNavigator2.BindingSource = bSource_ControlList;

            Public.Utility.SetLoadDataRange(userControlFilterDate1);

            if (Properties.Settings.Default.IsLoadData)
            {
                but_Search_Click(null, null);
            }
        }

        private void AccountingPaymentMF_FormClosed(object sender, FormClosedEventArgs e)
        {
            Public.PublicForm Forms = new Public.PublicForm();
            Forms.AccountingPaymentMF = null;
        }
        #endregion

        #region DataBind_Payment
        public void DataBind_Payment(string strWhere)
        {
            if (radioButton_All.Checked)//全部
            {
                //System.Data.DataSet dsPatentFee = GetFeeEvent(strWhere);
                //System.Data.DataTable dt_PatentFee= dsPatentFee.Tables[0];
                //System.Data.DataTable dt_PatentFeeMoney = dsPatentFee.Tables[1];

                //if (dt_PatentFee.Rows.Count > 0)
                //{
                //    System.Data.DataSet ds_TrademarkFeeEvent = GetFeeEventbyTrademark(strWhere);
                //    System.Data.DataTable dt_TrademarkFeeEvent = ds_TrademarkFeeEvent.Tables[0];
                //    dt_PatentFee.Merge(dt_TrademarkFeeEvent);

                //    System.Data.DataTable dt_TrademarkFeeEventMoney = ds_TrademarkFeeEvent.Tables[1];
                //    dt_PatentFeeMoney.Merge(dt_TrademarkFeeEventMoney);
                //}
                //else
                //{
                //    System.Data.DataSet ds_TrademarkFeeEvent = GetFeeEventbyTrademark(strWhere);
                   
                //    dt_PatentFee = ds_TrademarkFeeEvent.Tables[0];

                //    dt_PatentFeeMoney = ds_TrademarkFeeEvent.Tables[1];
                //}
                //bSource_Control.DataSource = dt_PatentFee;
                //bSource_ControlList.DataSource = dt_PatentFeeMoney;
            }
            else if (radioButton_Patent.Checked)//專利
            {
                System.Data.DataSet dt_PatentFee = Public.CAccountingPublicFunction.GetPATControlPayment(strWhere);
                bSource_Control.DataSource = dt_PatentFee.Tables[0];

                bSource_ControlList.DataSource = dt_PatentFee.Tables[1];

                decimal ActuallyPay = dt_PatentFee.Tables[2].Rows[0]["ActuallyPay"] != DBNull.Value ? (decimal)dt_PatentFee.Tables[2].Rows[0]["ActuallyPay"] : 0;
                toolStripLabel_ActuallyPay.Text = ActuallyPay.ToString("#,##0.##");
            }
            else if (radioButton_Trademark.Checked)//商標
            {
                System.Data.DataSet dt_PatentFeeEvent = Public.CAccountingPublicFunction.GetTrademarkControlPaymentList(strWhere);
                bSource_Control.DataSource = dt_PatentFeeEvent.Tables[0];

                bSource_ControlList.DataSource = dt_PatentFeeEvent.Tables[1];

                decimal ActuallyPay = dt_PatentFeeEvent.Tables[2].Rows[0]["ActuallyPay"] != DBNull.Value ? (decimal)dt_PatentFeeEvent.Tables[2].Rows[0]["ActuallyPay"] : 0;
                toolStripLabel_ActuallyPay.Text = ActuallyPay.ToString("#,##0.##");
            }

        }
        #endregion
               

        #region dgViewMF_DataError
        private void dgViewMF_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = false;
        }
        #endregion

        #region but_Search_Click
        private void but_Search_Click(object sender, EventArgs e)
        {
            but_Search.Enabled = false;

            string strFilter = "";
            if (radioButton_NotFinish.Checked)//待處理
            {
                strFilter = " PaymentDate is null and IReceiptDate is null ";
            }
            else if (radioButton_Processed.Checked)//已處理
            {
                strFilter = " PaymentDate is not null and IReceiptDate is null ";
            }
            else
            {
                //已完成
                strFilter = " IReceiptDate is not null ";
            }

            string FullWhere = Public.CommonFunctions.GetSQLScript(QueryFilter1, QueryFilter2, rb_and.Checked ? " and " : " or ", userControlFilterDate1);

            string strSqlwhere = "";
            if (!string.IsNullOrEmpty(strFilter.Trim()) && string.IsNullOrEmpty(FullWhere.Trim()))
            {
                strSqlwhere = strFilter;
            }
            else if (string.IsNullOrEmpty(strFilter.Trim()) && !string.IsNullOrEmpty(FullWhere.Trim()))
            {
                strSqlwhere = FullWhere;
            }
            else if (!string.IsNullOrEmpty(strFilter.Trim()) && !string.IsNullOrEmpty(FullWhere.Trim()))
            {
                strSqlwhere = strFilter + " and " + FullWhere;
            }

            DataBind_Payment(strSqlwhere.ToString());

            but_Search.Enabled = true;
        }
        #endregion

        #region radioButton_NotFinish_CheckedChanged
        private void radioButton_NotFinish_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;           
           
            if (rb.Checked)
            {
                if (rb.Tag != null)
                {
                    if (rb.Tag.ToString() == "TM")
                    {
                        dgViewMF.Tag = "AccountingPaymentMF_TM";

                        QueryFilter1.SearchType = "'TrademarkControlPaymentList','AccountingPaymentMF'";
                        QueryFilter2.SearchType = "'TrademarkControlPaymentList','AccountingPaymentMF'";
                    }
                    else
                    {
                        dgViewMF.Tag = "AccountingPaymentMF";

                        QueryFilter1.SearchType = "'PATControlPayment','AccountingPaymentMF'";
                        QueryFilter2.SearchType = "'PATControlPayment','AccountingPaymentMF'";
                    }

                    Public.DynamicGridViewColumn.GetGridColum(ref dgViewMF);
                }

                but_Search_Click(null, null);
            }
        }
        #endregion

        #region contextMenuStrip_Accounting
        private void contextMenuStrip_Accounting_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            contextMenuStrip_Accounting.Visible = false;
            string sCaseType = radioButton_Patent.Checked ? "Pat" : "Tm"; 

            if (dgViewMF.CurrentRow != null)
            {
                bool bIsClosing = dgViewMF.CurrentRow.Cells["IsClosing"].Value != DBNull.Value ? (bool)dgViewMF.CurrentRow.Cells["IsClosing"].Value : false;

                switch (e.ClickedItem.Name)
                {
                    case "ToolStripMenuItem_FinishFee":

                        if (bIsClosing)//判斷是否關帳
                        {
                            MessageBox.Show("該筆請款記錄已經被關帳，請洽帳務主管", "提示訊息", MessageBoxButtons.OK);
                            return;
                        }

                        US.AccountingPaymentFinish fee = new LawtechPTSystem.US.AccountingPaymentFinish();

                        fee.PaymentID = (int)dgViewMF.CurrentRow.Cells["PaymentID"].Value;

                        if (sCaseType == "Pat")
                        {
                            fee.Text = fee.Text + "(專利-" + dgViewMF.CurrentRow.Cells["PatentNo"].Value.ToString() + ")";
                            fee.TypeKind = 1;
                        }
                        else if (sCaseType == "Tm")
                        {
                            fee.Text = fee.Text + "(商標-" + dgViewMF.CurrentRow.Cells["TrademarkNo"].Value.ToString() + ")";
                            fee.TypeKind = 2;
                        }

                        fee.DGvr = dgViewMF.CurrentRow;
                        fee.Show();

                        break;

                    case "ToolStripMenuItem_SingOff":

                        if (bIsClosing)//判斷是否關帳
                        {
                            MessageBox.Show("該筆請款記錄已經被關帳，請洽帳務主管", "提示訊息", MessageBoxButtons.OK);
                            return;
                        }
                        if (sCaseType == "Pat")
                        {
                            EditForm.EditPatentPayment patentfee = new LawtechPTSystem.EditForm.EditPatentPayment();
                            patentfee.property_PaymentID = (int)dgViewMF.CurrentRow.Cells["PaymentID"].Value;
                            patentfee.CountrySymbol = dgViewMF.CurrentRow.Cells["CountrySymbol"].Value.ToString();
                            patentfee.Text = patentfee.Text + "(" + dgViewMF.CurrentRow.Cells["PatentNo"].Value.ToString() + "  " + dgViewMF.CurrentRow.Cells["Country"].Value.ToString() + ")";
                            patentfee.ShowDialog() ;
                            
                        }
                        else if (sCaseType == "Tm")
                        {
                            EditForm.EditTrademarkPayment trademarkfee = new LawtechPTSystem.EditForm.EditTrademarkPayment();
                            trademarkfee.property_PaymentID = (int)dgViewMF.CurrentRow.Cells["PaymentID"].Value;
                            trademarkfee.CountrySymbol = dgViewMF.CurrentRow.Cells["CountrySymbol"].Value.ToString();
                            trademarkfee.Text = trademarkfee.Text + "(" + dgViewMF.CurrentRow.Cells["TrademarkNo"].Value.ToString() + "  " + dgViewMF.CurrentRow.Cells["CountrySymbol"].Value.ToString() + ")";
                            trademarkfee.ShowDialog();
                        }
                        break;

                    case "toolStripMenuItem_SendMail":
                        if (dgViewMF.CurrentRow != null)
                        {
                            US.NotificationLetter letter = new LawtechPTSystem.US.NotificationLetter();
                            letter.ApplicantKeys = dgViewMF.CurrentRow.Cells["ApplicantKeys"].Value.ToString();
                            
                            letter.DelegateType = (dgViewMF.CurrentRow.Cells["DelegateType"].Value != null && dgViewMF.CurrentRow.Cells["DelegateType"].Value.ToString() != "") ? (int)dgViewMF.CurrentRow.Cells["DelegateType"].Value : -1;
                            letter.Attorney = dgViewMF.CurrentRow.Cells["AttorneyKey"].Value != DBNull.Value ? (int)dgViewMF.CurrentRow.Cells["AttorneyKey"].Value : -1;
                            if (sCaseType == "Pat")
                            {
                                letter.EmailSampleType = "PatentFee";
                                letter.CaseKey = dgViewMF.CurrentRow.Cells["PatentID"].Value != null ? (int)dgViewMF.CurrentRow.Cells["PatentID"].Value : -1;
                                letter.CaseNo = dgViewMF.CurrentRow.Cells["PatentNo"].Value.ToString();
                            }
                            else if (sCaseType == "CO")
                            {
                                letter.EmailSampleType = "TrademarkControversyFee";
                            }
                            else
                            {
                                letter.EmailSampleType = "TrademarkFee";
                                letter.CaseKey = dgViewMF.CurrentRow.Cells["TrademarkID"].Value != null ? (int)dgViewMF.CurrentRow.Cells["TrademarkID"].Value : -1;
                                letter.CaseNo = dgViewMF.CurrentRow.Cells["TrademarkNo"].Value.ToString();
                            }
                           
                            letter.Show();
                        }
                        break;

                    case "ToolStripMenuItem_CaseDetail":

                        if (sCaseType == "Pat")
                        {
                            PatentHistoryRecord1 patent = new LawtechPTSystem.SubFrom.PatentHistoryRecord1();
                            patent.property_PatentID = (int)dgViewMF.CurrentRow.Cells["PatentID"].Value;
                            patent.TabSelectedIndex = 3;
                            patent.Show();
                        }                        
                        else if (sCaseType == "Tm")
                        {
                            TrademarkHistoryRecord HistoryRecord = new TrademarkHistoryRecord();
                            HistoryRecord.TrademarkID = (int)dgViewMF.CurrentRow.Cells["TrademarkID"].Value;
                            HistoryRecord.TabSelectedIndex = 5;
                            HistoryRecord.Show();
                        }
                       
                        break;

                    case "ToolStripMenuItem_PatentCompleteHistory":
                        if (sCaseType == "Pat")
                        {
                            ViewFrom.PatentCompleteHistory history = new LawtechPTSystem.ViewFrom.PatentCompleteHistory();
                            history.Gv = dgViewMF;
                            history.Show();
                        }
                        else if (sCaseType == "Tm")
                        {
                            ViewFrom.TrademarkCompleteHistory history = new LawtechPTSystem.ViewFrom.TrademarkCompleteHistory();
                            history.Gv = dgViewMF;
                            history.Show();
                        }
                        else if (sCaseType == "CO")
                        {
                            ViewFrom.TrademarkControversyCompleteHistory history = new LawtechPTSystem.ViewFrom.TrademarkControversyCompleteHistory();
                            history.Gv = dgViewMF;
                            history.Show();
                        }
                        break;


                    case "toolStripMenuItem_CloseAccount"://關帳
                        if (dgViewMF.SelectedRows.Count > 0)
                        {
                            //複選多筆時
                            for (int iRow = 0; iRow < dgViewMF.SelectedRows.Count; iRow++)
                            {
                                int Feekey = (int)dgViewMF.SelectedRows[iRow].Cells["PaymentID"].Value;

                                switch (sCaseType)
                                {
                                    case "Pat":
                                        Public.CPatentPayment pat = new Public.CPatentPayment();
                                        Public.CPatentPayment.ReadOne(Feekey, ref pat);                                       
                                        pat.IsClosing = true;
                                        pat.CloseDate = DateTime.Now;
                                        pat.Update();

                                        break;
                                    case "Tm":
                                         Public.CTrademarkPayment TmPay = new Public.CTrademarkPayment();
                                         Public.CTrademarkPayment.ReadOne(Feekey, ref TmPay);

                                         TmPay.IsClosing = true;
                                         TmPay.CloseDate = DateTime.Now;
                                         TmPay.Update();
                                        break;
                                    case "CO":
                                        Public.CTrademarkControversyPayment CO = new Public.CTrademarkControversyPayment("ControversyPaymentID=" + Feekey.ToString());
                                        CO.SetCurrent(Feekey);
                                        CO.IsClosing = true;
                                        CO.CloseDate = DateTime.Now;
                                        CO.Updata(Feekey);
                                        break;
                                }

                                dgViewMF.SelectedRows[iRow].Cells["IsClosing"].Value = true;
                                dgViewMF.SelectedRows[iRow].Cells["CloseDate"].Value = DateTime.Now;
                            }
                            MessageBox.Show(string.Format("已完成關帳，共 {0} 筆", dgViewMF.SelectedRows.Count.ToString()), "提示訊息");
                        }
                        else
                        {
                            //判斷單筆時
                            if (dgViewMF.CurrentRow != null)
                            {
                                int Feekey = (int)dgViewMF.CurrentRow.Cells["PaymentID"].Value;

                                switch (dgViewMF.CurrentRow.Cells["CaseType"].Value.ToString())
                                {
                                    case "Pat":
                                        Public.CPatentPayment pat = new Public.CPatentPayment();
                                        Public.CPatentPayment.ReadOne(Feekey, ref pat);
                                       
                                        pat.IsClosing = true;
                                        pat.CloseDate = DateTime.Now;
                                        pat.Update();

                                        break;
                                    case "Tm":
                                        Public.CTrademarkPayment TM = new Public.CTrademarkPayment();
                                        Public.CTrademarkPayment.ReadOne(Feekey, ref TM);
                                        TM.IsClosing = true;
                                        TM.CloseDate = DateTime.Now;
                                        TM.Update();
                                        break;
                                    case "CO":
                                        Public.CTrademarkControversyPayment CO = new Public.CTrademarkControversyPayment("ControversyPaymentID=" + Feekey.ToString());
                                        CO.SetCurrent(Feekey);
                                        CO.IsClosing = true;
                                        CO.CloseDate = DateTime.Now;
                                        CO.Updata(Feekey);
                                        break;
                                }

                                dgViewMF.CurrentRow.Cells["IsClosing"].Value = true;
                                dgViewMF.CurrentRow.Cells["CloseDate"].Value = DateTime.Now;

                                MessageBox.Show(string.Format("已完成關帳 \r\n 請款單號【{0}】", dgViewMF.CurrentRow.Cells["BillingNo"].Value.ToString()), "提示訊息");
                            }
                        }
                        break;
                 
                    case "toolStripMenuItem_OpenAccount": //取消關帳
                        if (dgViewMF.SelectedRows.Count > 0)
                        {
                            for (int iRow = 0; iRow < dgViewMF.SelectedRows.Count; iRow++)
                            {
                                int PaymentID = (int)dgViewMF.SelectedRows[iRow].Cells["PaymentID"].Value;
                                switch (sCaseType)
                                {
                                    case "Pat":
                                        Public.CPatentPayment pat = new Public.CPatentPayment();
                                        Public.CPatentPayment.ReadOne(PaymentID, ref pat);
                                        pat.IsClosing = false;
                                        pat.CloseDate = null;
                                        pat.Update();

                                        break;
                                    case "Tm":

                                        Public.CTrademarkPayment TmPay = new Public.CTrademarkPayment();
                                        Public.CTrademarkPayment.ReadOne(PaymentID, ref TmPay);

                                        TmPay.IsClosing = false;
                                        TmPay.CloseDate = null;
                                        TmPay.Update();
                                        break;
                                    case "CO":
                                        Public.CTrademarkControversyPayment CO = new Public.CTrademarkControversyPayment("ControversyPaymentID=" + PaymentID.ToString());
                                        CO.SetCurrent(PaymentID);
                                        CO.IsClosing = false;
                                        CO.CloseDate = new DateTime(1900, 1, 1);
                                        CO.Updata(PaymentID);
                                        break;
                                }

                                dgViewMF.SelectedRows[iRow].Cells["IsClosing"].Value = false;
                                dgViewMF.SelectedRows[iRow].Cells["CloseDate"].Value = DBNull.Value;
                            }

                            MessageBox.Show(string.Format("已完成開帳，共 {0} 筆", dgViewMF.SelectedRows.Count.ToString()), "提示訊息");
                        }
                        else
                        {
                            //判斷單筆時
                            if (dgViewMF.CurrentRow != null)
                            {
                                int Feekey = (int)dgViewMF.CurrentRow.Cells["PaymentID"].Value;

                                switch (sCaseType)
                                {
                                    case "Pat":
                                        Public.CPatentPayment pat = new Public.CPatentPayment();
                                        Public.CPatentPayment.ReadOne(Feekey, ref pat);
                                        pat.IsClosing = false;
                                        pat.CloseDate =null;
                                        pat.Update();

                                        break;
                                    case "Tm":
                                        Public.CTrademarkPayment TmPay = new Public.CTrademarkPayment();
                                        Public.CTrademarkPayment.ReadOne(Feekey, ref TmPay);

                                        TmPay.IsClosing = false;
                                        TmPay.CloseDate = null;
                                        TmPay.Update();
                                        break;
                                    case "CO":
                                        Public.CTrademarkControversyFee CO = new Public.CTrademarkControversyFee("ControversyPaymentID=" + Feekey.ToString());
                                        CO.SetCurrent(Feekey);
                                        CO.IsClosing = false;
                                        CO.CloseDate = new DateTime(1900, 1, 1);
                                        CO.Updata(Feekey);
                                        break;
                                }

                                dgViewMF.CurrentRow.Cells["IsClosing"].Value = false;
                                dgViewMF.CurrentRow.Cells["CloseDate"].Value = DBNull.Value;

                                MessageBox.Show(string.Format("已完成開帳 \r\n 請款單號【{0}】", dgViewMF.CurrentRow.Cells["BillingNo"].Value.ToString()), "提示訊息");
                            }
                        }
                        break;
                    case "toolStripMenuItem_SetGridColumn":
                        SetGridColumnT gc = new SetGridColumnT();
                        gc.CurrentGridSymboID = dgViewMF.Tag.ToString();
                        gc.TitleName = "應付款項清單表";
                        gc.Show();
                        break;
                    case "toolStripMenuItem_App":
                        if (dgViewMF.CurrentRow != null)
                        {
                            ViewFrom.ApplicantList app = new ViewFrom.ApplicantList();
                            string No = "";
                            if (sCaseType == "Tm")
                            {
                                app.MainType = 2;
                                No = dgViewMF.CurrentRow.Cells["TrademarkNo"].Value.ToString();
                                app.MainKey = (int)dgViewMF.CurrentRow.Cells["TrademarkID"].Value;
                            }
                            else
                            {
                                app.MainType = 1;
                                No = dgViewMF.CurrentRow.Cells["PatentNo"].Value.ToString();
                                app.MainKey = (int)dgViewMF.CurrentRow.Cells["PatentID"].Value;
                            }

                            app.Text += $"--{No}";

                            app.Show();
                        }
                        break;
                }
            }

        }

        private void contextMenuStrip_Accounting_Opening(object sender, CancelEventArgs e)
        {
            if (dgViewMF.CurrentRow != null)
            {
                this.ToolStripMenuItem_FinishFee.Visible = true;
                ToolStripMenuItem_SingOff.Visible = false;
                toolStripMenuItem_CloseAccount.Visible = false;
                toolStripMenuItem_OpenAccount.Visible = false;

                if (OfficeRole == 2 || OfficeRole == 3 )
                {
                    ToolStripMenuItem_SingOff.Visible = true;

                }
                else if (OfficeRole == 4)
                {
                    ToolStripMenuItem_SingOff.Visible = true;
                    toolStripMenuItem_CloseAccount.Visible = true;
                    toolStripMenuItem_OpenAccount.Visible = true;
                }
                else if (OfficeRole == 0)
                {
                    ToolStripMenuItem_SingOff.Visible = true;
                    toolStripMenuItem_CloseAccount.Visible = true;
                    toolStripMenuItem_OpenAccount.Visible = true;
                }
            }
            else
            {
                e.Cancel = true;
            }
        }
        #endregion

        #region contextMenuStrip_ForDate_ItemClicked
        private void contextMenuStrip_ForDate_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ContextMenuStrip content = (ContextMenuStrip)sender;
            MaskedTextBox mtb = content.SourceControl as MaskedTextBox;

            contextMenuStrip_ForDate.Visible = false;

            switch (e.ClickedItem.Name)
            {
                case "ToolStripMenuItem_Calculation":

                    US.CalculationDate Calculation = new LawtechPTSystem.US.CalculationDate();
                    DateTime dt = new DateTime(1900, 1, 1);
                    bool IsSuccess = DateTime.TryParse(mtb.Text, out dt);
                    if (IsSuccess)
                    {
                        Calculation.CurrentDate = dt;
                    }
                    else
                    {
                        Calculation.CurrentDate = new DateTime(1900, 1, 1);
                    }

                    //取得結果
                    if (Calculation.ShowDialog() == DialogResult.OK)
                    {
                        mtb.Text = Calculation.GetResult;
                    }
                    break;
            }
        }
        #endregion

        #region =============maskedTextBox_S_DoubleClick===========
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
               
        #region but_MoneyList_Click
        private void but_MoneyList_Click(object sender, EventArgs e)
        {
            if (!splitContainer1.Panel2Collapsed)
            {
                but_MoneyList.Text = "開啟幣別統計表(Alt+E)";
                
                splitContainer1.Panel2Collapsed = true;
            }
            else
            {
                but_MoneyList.Text = "關閉幣別統計表(Alt+E)";
                splitContainer1.Panel2Collapsed = false;
            }
        }
        #endregion

        private void AccountingPaymentMF_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt)
            {
                if (e.KeyCode == Keys.E)
                {
                    but_MoneyList_Click(null, null);
                }
            }
        }

        #region dgViewMF_CellDoubleClick
        private void dgViewMF_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                contextMenuStrip_Accounting_ItemClicked(contextMenuStrip_Accounting, new ToolStripItemClickedEventArgs(ToolStripMenuItem_CaseDetail));
            }
        }
        #endregion

    }
}
