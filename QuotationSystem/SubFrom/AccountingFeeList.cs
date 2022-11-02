using System;
using System.ComponentModel;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LawtechPTSystem.SubFrom
{
    /// <summary>
    /// 帳務管理--應請款項清單表
    /// </summary>
    public partial class AccountingFeeList : Form
    {
        BindingSource bSource_Control;

        UserPermissionForm myPermission;
        private const string ProgramSymbol = "AccountingFeeList";
        private const string SourceTableName = "V_TrademarkEventList";

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
            set {
                bSource_Control.DataSource = value;
            }
        }

        /// <summary>
        /// 目前的DataGridViewRow CurrentRow
        /// </summary>
        public DataGridViewRow GV_CurrentRow
        {
            get {
                return dgViewMF.CurrentRow;
            }
        }

        public DataRow GetAccountingDataRow
        {
            get {
                return ((System.Data.DataRowView)(dgViewMF.CurrentRow.DataBoundItem)).Row;
            }
        }
        #endregion

        public AccountingFeeList()
        {
            InitializeComponent();
            dgViewMF.AutoGenerateColumns = false;
            Public.DynamicGridViewColumn.GetGridColum(ref dgViewMF);
        }

        #region AccountingFeeMF_Load  AccountingFeeMF_FormClosed
        private void AccountingFeeMF_Load(object sender, EventArgs e)
        {          
            
            Public.PublicForm Forms = new Public.PublicForm();
            Forms.AccountingFeeList = this;

            //登入者
            iWorkerID = Properties.Settings.Default.WorkerKEY;
            Worker_Model worker = new Worker_Model();
            Worker_Model.ReadOne(iWorkerID, ref  worker);
           
            //角色的權限
            OfficeRole = worker.OfficeRole.Value;

            //取得權限
            myPermission = new UserPermissionForm(Properties.Settings.Default.WorkerKEY, ProgramSymbol);

            System.Windows.Forms.BindingNavigator[] listbinding = { bindingNavigator1 };
            System.Windows.Forms.ContextMenuStrip[] listtMenu = { contextMenuStrip_Accounting };

            //確認可使用的功能選單
            Public.CommonFunctions.CheckMeunItemVisible(listbinding, myPermission.UserPermission);
            Public.CommonFunctions.CheckMeunItemVisible(listtMenu, myPermission.UserPermission); 

            this.accountingSelectValueTableAdapter.Fill(this.dataSet_Accounting.AccountingSelectValue);
            this.dataSet_Accounting.AccountingSelectDate.Rows.Clear();
            this.accountingSelectDateTableAdapter.Fill(this.dataSet_Accounting.AccountingSelectDate);


            bSource_Control = new BindingSource();
            dgViewMF.DataSource = bSource_Control;
            bindingNavigator1.BindingSource = bSource_Control;

            Public.Utility.SetLoadDataRange(userControlFilterDate1);

            if (Properties.Settings.Default.IsLoadData)
            {
                but_Search_Click(null, null);
            }
        }
       
        private void AccountingFeeMF_FormClosed(object sender, FormClosedEventArgs e)
        {
            Public.PublicForm Forms = new Public.PublicForm();
            Forms.AccountingFeeList = null;
        }
        #endregion

        #region but_Close_Click
        private void but_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region 查詢按鈕 but_Search_Click
        /// <summary>
        /// 查詢按鈕
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void but_Search_Click(object sender, EventArgs e)
        {
            but_Search.Enabled = false;
            string strFilter = "";

            //待處理:表示尚未填上請款單號且未關帳
            if (radioButton_NotFinish.Checked)
            {
                strFilter = " PayDate is null and ( PPP is null or PPP='') and IsClosing<>1";
            }
            else if (radioButton_ppp.Checked)//已處理:表示已填上請款單號
            {
                strFilter = " PayDate is null and PPP is not null and PPP<>'' and IsClosing<>1";
            }
            else if( radioButton_Finish.Checked)//已完成:
            {
                strFilter = "(Pay='True') and IsClosing<>1";
            }
            else { //已關帳
                strFilter = " (IsClosing=1) ";
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

            DataBind_Fee(strSqlwhere.ToString());           
         

            but_Search.Enabled = true;
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

        #region DataBind_Fee
        public void DataBind_Fee(string strWhere)
        {
            if (radioButton_All.Checked)//全部
            {
                DataTable dt_PatentFee = GetFeeEvent(strWhere);

                if (dt_PatentFee.Rows.Count > 0)
                {
                    System.Data.DataTable dt_TrademarkFeeEvent = GetFeeEventbyTrademark(strWhere);
                    dt_PatentFee.Merge(dt_TrademarkFeeEvent);
                }
                else
                {
                    dt_PatentFee = GetFeeEventbyTrademark(strWhere);
                }

                bSource_Control.DataSource = dt_PatentFee;
            }
            else if (radioButton_Patent.Checked)//專利
            {
                System.Data.DataTable dt_PatentFee = GetFeeEvent(strWhere);
                bSource_Control.DataSource = dt_PatentFee;
            }
            else if (radioButton_Trademark.Checked)//商標
            {
                System.Data.DataTable dt_PatentFeeEvent = GetFeeEventbyTrademark(strWhere);
                bSource_Control.DataSource = dt_PatentFeeEvent;
            }           
         
        }
        #endregion        

        #region GetFeeEvent 取得專利請款的資料
        /// <summary>
        /// 取得請款的資料
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public System.Data.DataTable GetFeeEvent(string strWhere)
        {
            string strPatentFeeSQL = string.Format(
                                    @"SELECT   PatentID AS MainKey,PatentNo as 'EventNo', * from V_PATControlFeeList  where {0};
                                      SELECT Sum(TotalNT)as SumTotall,  sum(Tax) as SumTax ,sum(PracticalityPay)as SumPracticalityPay  FROM   V_PATControlFeeList  where {0}
                                ", strWhere);

            Public.DLL dll = new Public.DLL();
            System.Data.DataSet dsFeeEvent = new System.Data.DataSet();
           dsFeeEvent= dll.SqlDataAdapterDataSet(strPatentFeeSQL);


            #region 設定 PrimaryKey --FeeKey
            if (dsFeeEvent.Tables[0].PrimaryKey.Length == 0)
            {
                DataColumn[] pk = { dsFeeEvent.Tables[0].Columns["FeeKey"] };
                dsFeeEvent.Tables[0].PrimaryKey = pk;
            } 
            #endregion

            if (dsFeeEvent.Tables[1].Rows.Count > 0)
           {
               lab_PatSumTotal.Text = dsFeeEvent.Tables[1].Rows[0]["SumTotall"] != DBNull.Value ? ((decimal)dsFeeEvent.Tables[1].Rows[0]["SumTotall"]).ToString("#,##0.##") : "0";
               lab_PatSumTax.Text = dsFeeEvent.Tables[1].Rows[0]["SumTax"] != DBNull.Value ? ((decimal)dsFeeEvent.Tables[1].Rows[0]["SumTax"]).ToString("#,##0.##") : "0";
               lab_PatSumPracticalityPay.Text = dsFeeEvent.Tables[1].Rows[0]["SumPracticalityPay"] != DBNull.Value ? ((decimal)dsFeeEvent.Tables[1].Rows[0]["SumPracticalityPay"]).ToString("#,##0.##") : "0";
           }
           return dsFeeEvent.Tables[0];
        }
        #endregion

        #region GetFeeEvent 取得商標請款的資料
        /// <summary>
        /// 取得商標請款的資料
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public System.Data.DataTable GetFeeEventbyTrademark(string strWhere)
        {
             
            string strPatentFeeSQL = string.Format(
                                    @"SELECT      TrademarkID AS MainKey,TrademarkNo as 'EventNo',TrademarkName as Title, *
                                        FROM         V_TrademarkControlFeeList  where {0};
                                                    
                                                    select Sum(TotalNT)as SumTotall,  sum(Tax) as SumTax ,sum(PracticalityPay)as SumPracticalityPay
                                                         FROM        V_TrademarkControlFeeList  where {0}                                             
                                        ", strWhere);

            Public.DLL dll = new Public.DLL();
            System.Data.DataSet dsFeeEvent = new System.Data.DataSet();
          dsFeeEvent=  dll.SqlDataAdapterDataSet(strPatentFeeSQL);

            #region 設定 PrimaryKey --FeeKey
            if (dsFeeEvent.Tables[0].PrimaryKey.Length == 0)
            {
                DataColumn[] pk = { dsFeeEvent.Tables[0].Columns["FeeKey"] };
                dsFeeEvent.Tables[0].PrimaryKey = pk;
            }
            #endregion

            if (dsFeeEvent.Tables[1].Rows.Count > 0)
          {
              lab_TMSumTotal.Text = dsFeeEvent.Tables[1].Rows[0]["SumTotall"] != DBNull.Value ? ((decimal)dsFeeEvent.Tables[1].Rows[0]["SumTotall"]).ToString("#,##0.##") : "0";
              lab_TMSumTax.Text = dsFeeEvent.Tables[1].Rows[0]["SumTax"] != DBNull.Value ? ((decimal)dsFeeEvent.Tables[1].Rows[0]["SumTax"]).ToString("#,##0.##") : "0";
              lab_TMSumPracticalityPay.Text = dsFeeEvent.Tables[1].Rows[0]["SumPracticalityPay"] != DBNull.Value ? ((decimal)dsFeeEvent.Tables[1].Rows[0]["SumPracticalityPay"]).ToString("#,##0.##") : "0";
          }
          return dsFeeEvent.Tables[0];
        }
        #endregion

        #region dgViewMF_DataError
        private void dgViewMF_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = false;
        }
        #endregion

        #region contextMenuStrip_Accounting
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void contextMenuStrip_Accounting_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            contextMenuStrip_Accounting.Visible = false;
            string sCaseType = radioButton_Patent.Checked?"Pat":"Tm";           

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

                        US.FeeFinish fee = new LawtechPTSystem.US.FeeFinish();

                        fee.FeeKey = (int)dgViewMF.CurrentRow.Cells["FeeKey"].Value;
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
                        else if (sCaseType == "CO")//商標異議案
                        {
                            fee.Text = fee.Text + "(商標-" + dgViewMF.CurrentRow.Cells["PatentNo"].Value.ToString() + ")";
                            fee.TypeKind = 2;
                        }

                        fee.DGvr = dgViewMF.CurrentRow;
                        fee.ShowDialog();
                       
                        break;
                    case "ToolStripMenuItem_PatentCompleteHistory"://完整歷程
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
                    case "ToolStripMenuItem_SingOff":

                        if (bIsClosing)//判斷是否關帳
                        {
                            MessageBox.Show("該筆請款記錄已經被關帳，請洽帳務主管", "提示訊息", MessageBoxButtons.OK);
                            return;
                        }

                        if (sCaseType == "Pat")
                        {
                            EditForm.EditPatentFee patentfee = new LawtechPTSystem.EditForm.EditPatentFee();
                            patentfee.property_FeeKEY = (int)dgViewMF.CurrentRow.Cells["FeeKEY"].Value;
                            patentfee.ShowDialog();
                        }
                        else if (sCaseType == "Tm")
                        {
                            EditForm.EditTrademarkFee trademarkfee = new LawtechPTSystem.EditForm.EditTrademarkFee();
                            trademarkfee.property_FeeKEY = (int)dgViewMF.CurrentRow.Cells["FeeKEY"].Value;
                            trademarkfee.ShowDialog();
                        }
                       
                        break;

                    case "toolStripMenuItem_PayDateFinish"://填收款日
                        if (dgViewMF.SelectedRows.Count > 0)
                        {
                            US.FeeFinishDate FeeDate=new LawtechPTSystem.US.FeeFinishDate();

                            if (FeeDate.ShowDialog() == DialogResult.OK)
                            {
                                //複選多筆時
                                for (int iRow = 0; iRow < dgViewMF.SelectedRows.Count; iRow++)
                                {
                                    
                                    bool close=    dgViewMF.SelectedRows[iRow].Cells["IsClosing"].Value != DBNull.Value ? (bool)dgViewMF.SelectedRows[iRow].Cells["IsClosing"].Value : false;
                                    if (close)//判斷是否關帳
                                    {
                                        break;
                                    }


                                    int Feekey = (int)dgViewMF.SelectedRows[iRow].Cells["FeeKEY"].Value;

                                    switch (dgViewMF.SelectedRows[iRow].Cells["CaseType"].Value.ToString())
                                    {
                                        case "Pat":
                                            Public.CPatentFee pat = new Public.CPatentFee();
                                            Public.CPatentFee.ReadOne(Feekey, ref pat);
                                            
                                            pat.Pay = FeeDate.Pro_Pay;
                                            pat.PayDate = FeeDate.CurrentDate;
                                            pat.PayKind = FeeDate.Pro_PayKind;
                                            pat.Update();

                                            break;
                                        case "Tm":
                                            Public.CTrademarkFee TM = new Public.CTrademarkFee();
                                            Public.CTrademarkFee.ReadOne(Feekey, ref TM);
                                            TM.Pay = FeeDate.Pro_Pay;
                                            TM.PayDate = FeeDate.CurrentDate;
                                            TM.PayKind = FeeDate.Pro_PayKind;
                                            TM.Update();
                                            break;
                                        case "CO":
                                            Public.CTrademarkControversyFee CO = new Public.CTrademarkControversyFee("ControversyFeeKEY=" + Feekey.ToString());
                                            CO.SetCurrent(Feekey);
                                            CO.Pay = FeeDate.Pro_Pay;
                                            CO.PayDate = FeeDate.CurrentDate;
                                            CO.PayKind = FeeDate.Pro_PayKind;
                                            CO.Updata(Feekey);
                                            break;
                                    }
                                    if (FeeDate.CurrentDate.Year > 1900)
                                    {
                                        dgViewMF.SelectedRows[iRow].Cells["PayDate"].Value = FeeDate.CurrentDate;
                                    }
                                    else
                                    {
                                        dgViewMF.SelectedRows[iRow].Cells["PayDate"].Value = DBNull.Value;
                                    }

                                    dgViewMF.SelectedRows[iRow].Cells["PayKind"].Value = FeeDate.Pro_PayKind;
                                }

                                MessageBox.Show(string.Format("已完成修改，共 {0} 筆", dgViewMF.SelectedRows.Count.ToString()), "提示訊息");
                            }
                        }
                        else //判斷單筆時
                        {
                            if (bIsClosing)//判斷是否關帳
                            {
                                MessageBox.Show("該筆請款記錄已經被關帳，請洽帳務主管", "提示訊息", MessageBoxButtons.OK);
                                return;
                            }

                           
                            if (dgViewMF.CurrentRow != null)
                            {
                                US.FeeFinishDate FeeDate=new LawtechPTSystem.US.FeeFinishDate();

                                if (FeeDate.ShowDialog() == DialogResult.OK)
                                {
                                    int Feekey = (int)dgViewMF.CurrentRow.Cells["FeeKEY"].Value;

                                    switch (sCaseType)
                                    {
                                        case "Pat":
                                            Public.CPatentFee pat = new Public.CPatentFee();
                                            Public.CPatentFee.ReadOne(Feekey, ref pat);
                                            
                                            pat.Pay = FeeDate.Pro_Pay;
                                            pat.PayDate = FeeDate.CurrentDate;
                                            pat.Update();

                                            break;
                                        case "Tm":
                                            Public.CTrademarkFee TM = new Public.CTrademarkFee();
                                            Public.CTrademarkFee.ReadOne(Feekey,ref TM);
                                            TM.Pay = FeeDate.Pro_Pay;
                                            TM.PayDate = FeeDate.CurrentDate;
                                            TM.Update();
                                            break;
                                        case "CO":
                                            Public.CTrademarkControversyFee CO = new Public.CTrademarkControversyFee("ControversyFeeKEY=" + Feekey.ToString());
                                            CO.SetCurrent(Feekey);
                                            CO.Pay = FeeDate.Pro_Pay;
                                            CO.PayDate = FeeDate.CurrentDate;
                                            CO.Updata(Feekey);
                                            break;
                                    }


                                    if (FeeDate.CurrentDate.Year > 1900)
                                    {
                                        dgViewMF.CurrentRow.Cells["PayDate"].Value = FeeDate.CurrentDate;
                                    }
                                    else
                                    {
                                        dgViewMF.CurrentRow.Cells["PayDate"].Value = DBNull.Value;
                                    }

                                    

                                    MessageBox.Show(string.Format("已完成修改 \r\n 請款單號【{0}】", dgViewMF.CurrentRow.Cells["PPP"].Value.ToString()), "提示訊息");
                                }
                            }
                        }
                        break;

                    case "toolStripMenuItem_SendMail":
                        if (dgViewMF.CurrentRow != null)
                        {
                            US.NotificationLetter letter = new LawtechPTSystem.US.NotificationLetter();
                            letter.ApplicantKeys = dgViewMF.CurrentRow.Cells["ApplicantKeys"].Value!=DBNull.Value? dgViewMF.CurrentRow.Cells["ApplicantKeys"].Value.ToString():"" ;
                           
                            letter.DelegateType =(dgViewMF.CurrentRow.Cells["DelegateType"].Value!=null && dgViewMF.CurrentRow.Cells["DelegateType"].Value.ToString() != "" ) ? (int)dgViewMF.CurrentRow.Cells["DelegateType"].Value : -1;
                            letter.Attorney = dgViewMF.CurrentRow.Cells["AttorneyKey"].Value !=DBNull.Value ? (int)dgViewMF.CurrentRow.Cells["AttorneyKey"].Value : -1;
                            if (sCaseType == "Pat")
                            {
                                letter.MainKey = dgViewMF.CurrentRow.Cells["PatentID"].Value != null ? (int)dgViewMF.CurrentRow.Cells["PatentID"].Value : -1;
                                letter.CaseKey = dgViewMF.CurrentRow.Cells["FeeKey"].Value != null ? (int)dgViewMF.CurrentRow.Cells["FeeKey"].Value : -1;
                                letter.EmailSampleType = "PatentFee";
                            }                           
                            else
                            {
                                letter.MainKey = dgViewMF.CurrentRow.Cells["TrademarkID"].Value != null ? (int)dgViewMF.CurrentRow.Cells["TrademarkID"].Value : -1;
                                letter.CaseKey = dgViewMF.CurrentRow.Cells["FeeKey"].Value != null ? (int)dgViewMF.CurrentRow.Cells["FeeKey"].Value : -1;
                                letter.EmailSampleType = "TrademarkFee";
                            }
                            if (sCaseType == "Pat")
                            {
                                letter.CaseNo = dgViewMF.CurrentRow.Cells["PatentNo"].Value.ToString();
                            }
                            else
                            {
                                letter.CaseNo = dgViewMF.CurrentRow.Cells["TrademarkNo"].Value.ToString();
                            }
                            letter.Show();
                        }
                        break;

                    case "ToolStripMenuItem_CaseDetail":

                        if (sCaseType == "Pat")
                        {
                            PatentHistoryRecord1 patent = new PatentHistoryRecord1();
                            patent.property_PatentID = (int)dgViewMF.CurrentRow.Cells["PatentID"].Value;

                            patent.TabSelectedIndex = 2;
                            patent.Show();
                        }
                        else if (sCaseType == "Tm")
                        {
                            TrademarkHistoryRecord HistoryRecord = new TrademarkHistoryRecord();
                            HistoryRecord.TrademarkID = (int)dgViewMF.CurrentRow.Cells["TrademarkID"].Value;
                            HistoryRecord.TabSelectedIndex = 2;
                            HistoryRecord.Show();
                        }
                            
                        break;

                    case "toolStripMenuItem_CloseAccount":
                        if (dgViewMF.SelectedRows.Count > 0)
                        {
                            //複選多筆時
                            for (int iRow = 0; iRow < dgViewMF.SelectedRows.Count; iRow++)
                            {
                                int Feekey = (int)dgViewMF.SelectedRows[iRow].Cells["FeeKEY"].Value;

                                switch (sCaseType)
                                {
                                    case "Pat":
                                        Public.CPatentFee pat = new Public.CPatentFee();
                                        Public.CPatentFee.ReadOne(Feekey, ref pat);
                                        
                                        pat.IsClosing = true;
                                        pat.CloseDate = DateTime.Now;
                                        pat.Update();

                                        break;
                                    case "Tm":
                                        Public.CTrademarkFee TM = new Public.CTrademarkFee();
                                        Public.CTrademarkFee.ReadOne(Feekey, ref TM);
                                        TM.IsClosing = true;
                                        TM.CloseDate = DateTime.Now;
                                        TM.Update();
                                        break;
                                    case "CO":
                                        Public.CTrademarkControversyFee CO = new Public.CTrademarkControversyFee("ControversyFeeKEY=" + Feekey.ToString());
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
                                int Feekey = (int)dgViewMF.CurrentRow.Cells["FeeKEY"].Value;

                                switch (sCaseType)
                                {
                                    case "Pat":
                                        Public.CPatentFee pat = new Public.CPatentFee();
                                        Public.CPatentFee.ReadOne(Feekey, ref pat);
                                       
                                        pat.IsClosing = true;
                                        pat.CloseDate = DateTime.Now;
                                        pat.Update();

                                        break;
                                    case "Tm":
                                        Public.CTrademarkFee TM = new Public.CTrademarkFee();
                                        Public.CTrademarkFee.ReadOne(Feekey,ref TM);
                                        TM.IsClosing = true;
                                        TM.CloseDate = DateTime.Now;
                                        TM.Update();
                                        break;
                                    case "CO":
                                        Public.CTrademarkControversyFee CO = new Public.CTrademarkControversyFee("ControversyFeeKEY=" + Feekey.ToString());
                                        CO.SetCurrent(Feekey);
                                        CO.IsClosing = true;
                                        CO.CloseDate = DateTime.Now;
                                        CO.Updata(Feekey);
                                        break;
                                }

                                dgViewMF.CurrentRow.Cells["IsClosing"].Value = true;
                                dgViewMF.CurrentRow.Cells["CloseDate"].Value = DateTime.Now;

                                MessageBox.Show(string.Format("已完成關帳 \r\n 請款單號【{0}】", dgViewMF.CurrentRow.Cells["PPP"].Value.ToString()), "提示訊息");
                            }
                        }
                        break;

                    case "toolStripMenuItem_OpenAccount":
                        if (dgViewMF.SelectedRows.Count > 0)
                        {
                            for (int iRow = 0; iRow < dgViewMF.SelectedRows.Count; iRow++)
                            {
                                int Feekey = (int)dgViewMF.SelectedRows[iRow].Cells["FeeKEY"].Value;
                                switch (sCaseType)
                                {
                                    case "Pat":
                                        Public.CPatentFee pat = new Public.CPatentFee();
                                        Public.CPatentFee.ReadOne(Feekey, ref pat);
                                        pat.IsClosing = false;
                                        pat.CloseDate =null;
                                        pat.Update();

                                        break;
                                    case "Tm":
                                        Public.CTrademarkFee TM = new Public.CTrademarkFee();
                                        Public.CTrademarkFee.ReadOne(Feekey,ref TM);
                                        TM.IsClosing = false;
                                        TM.CloseDate = null;
                                        TM.Update();
                                        break;
                                    case "CO":
                                        Public.CTrademarkControversyFee CO = new Public.CTrademarkControversyFee("ControversyFeeKEY=" + Feekey.ToString());
                                        CO.SetCurrent(Feekey);
                                        CO.IsClosing = false;
                                        CO.CloseDate = new DateTime(1900, 1, 1);
                                        CO.Updata(Feekey);
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
                            if (dgViewMF.CurrentRow!=null)
                            {
                                int Feekey = (int)dgViewMF.CurrentRow.Cells["FeeKEY"].Value;

                                switch (sCaseType)
                                {
                                    case "Pat":
                                        Public.CPatentFee pat = new Public.CPatentFee();
                                        Public.CPatentFee.ReadOne(Feekey, ref pat);
                                        pat.IsClosing = false;
                                        pat.CloseDate = null;
                                        pat.Update();

                                        break;
                                    case "Tm":
                                        Public.CTrademarkFee TM = new Public.CTrademarkFee();
                                        Public.CTrademarkFee.ReadOne(Feekey,ref TM);
                                        TM.IsClosing = false;
                                        TM.CloseDate = null;
                                        TM.Update();
                                        break;
                                    case "CO":
                                        Public.CTrademarkControversyFee CO = new Public.CTrademarkControversyFee("ControversyFeeKEY=" + Feekey.ToString());
                                        CO.SetCurrent(Feekey);
                                        CO.IsClosing = false;
                                        CO.CloseDate = new DateTime(1900, 1, 1);
                                        CO.Updata(Feekey);
                                        break;
                                }

                                dgViewMF.CurrentRow.Cells["IsClosing"].Value = false;
                                dgViewMF.CurrentRow.Cells["CloseDate"].Value = DBNull.Value;

                                MessageBox.Show(string.Format("已完成開帳 \r\n 請款單號【{0}】", dgViewMF.CurrentRow.Cells["PPP"].Value.ToString()), "提示訊息");
                            }
                        }
                        break;
                    case "toolStripMenuItem_SetGridColumn":
                        SetGridColumnT gc = new SetGridColumnT();
                        gc.CurrentGridSymboID = dgViewMF.Tag.ToString();
                        gc.TitleName = "應收款項清單表";
                        gc.Show();
                        break;
                    case "toolStripMenuItem_PrintedReceipt"://印收據
                        if (dgViewMF.CurrentRow != null)
                        {
                            if (sCaseType == "Pat")
                            {
                                if (dgViewMF.CurrentRow.Cells["ApplicantName"].Value == null)
                                {
                                    MessageBox.Show("申請人不得為空值，請確認", "提示訊息");
                                    return;
                                }
                                ReportView.FeeReceiptReport feereport = new ReportView.FeeReceiptReport();
                                feereport.ModeType = 1;
                                feereport.FeeKEY = (int)dgViewMF.CurrentRow.Cells["FeeKEY"].Value;                              
                                feereport.PatentID = (int)dgViewMF.CurrentRow.Cells["PatentID"].Value;                               
                                feereport.Show();
                            }
                            else if (sCaseType == "Tm")
                            {
                             
                                ReportView.FeeReceiptReport feeTm = new ReportView.FeeReceiptReport();
                                feeTm.ModeType = 2;
                                feeTm.FeeKEY = (int)dgViewMF.CurrentRow.Cells["FeeKEY"].Value;
                                feeTm.PatentID = (int)dgViewMF.CurrentRow.Cells["TrademarkID"].Value;                              
                                feeTm.Show();
                            }
                        }
                      
                            break;
                    case "toolStripMenuItem_PrintFeeReport"://印請款單
                        if (dgViewMF.CurrentRow != null)
                        {
                          
                            if (sCaseType == "Pat")
                            {
                                if (dgViewMF.CurrentRow.Cells["ApplicantName"].Value == null)
                                {
                                    MessageBox.Show("申請人不得為空值，請確認", "提示訊息");
                                    return;
                                }

                                ReportView.FeeReport feereport = new ReportView.FeeReport();
                                feereport.ModeType = 1;
                                feereport.FeeKEY = (int)dgViewMF.CurrentRow.Cells["FeeKEY"].Value;
                                feereport.ApplicantKeys = dgViewMF.CurrentRow.Cells["ApplicantKeys"].Value.ToString();
                                feereport.ApplicantNames = dgViewMF.CurrentRow.Cells["ApplicantName"].Value.ToString();                                
                                feereport.PatentID = (int)dgViewMF.CurrentRow.Cells["PatentID"].Value;
                                feereport.Show();
                            }
                            else if (sCaseType == "Tm")
                            {
                                if (dgViewMF.CurrentRow.Cells["ApplicantNames"].Value == null)
                                {
                                    MessageBox.Show("申請人不得為空值，請確認", "提示訊息");
                                    return;
                                }

                                ReportView.FeeReport feeTm = new LawtechPTSystem.ReportView.FeeReport();
                                feeTm.ModeType = 2;
                                feeTm.FeeKEY = (int)dgViewMF.CurrentRow.Cells["FeeKEY"].Value;

                                feeTm.ApplicantKeys = dgViewMF.CurrentRow.Cells["ApplicantKeys"].Value.ToString();
                                feeTm.ApplicantNames = dgViewMF.CurrentRow.Cells["ApplicantNames"].Value.ToString();

                                feeTm.PatentID = (int)dgViewMF.CurrentRow.Cells["TrademarkID"].Value;
                                feeTm.Show();
                            }
                        }
                        else
                        {
                            MessageBox.Show("無資料        ", "提示訊息", MessageBoxButtons.OK);
                        }
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

        #region contextMenuStrip_Accounting_Opening
        private void contextMenuStrip_Accounting_Opening(object sender, CancelEventArgs e)
        {
            if (dgViewMF.CurrentRow != null)
            {              
                this.ToolStripMenuItem_FinishFee.Visible = true;
                ToolStripMenuItem_SingOff.Visible = false;
                toolStripMenuItem_CloseAccount.Visible = false;
                toolStripMenuItem_OpenAccount.Visible = false;
                toolStripMenuItem_PayDateFinish.Visible = true;

                if (OfficeRole == 2 || OfficeRole == 3 )
                {
                    ToolStripMenuItem_SingOff.Visible = true;
                    
                }
                else if ( OfficeRole == 4)
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

        #endregion

        #region 匯出按鈕 but_Excel_Click
        /// <summary>
        /// 匯出按鈕
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void but_Excel_Click(object sender, EventArgs e)
        {
            try
            {
                Public.DLL dll = new Public.DLL();
                Task task = dll.WriteToCSV(dgViewMF);

            }
            catch
            {
                MessageBox.Show("匯出CSV失敗:匯出過程發生異常被終止");
            }
        }
        #endregion

        #region radioButton_NotFinish_CheckedChanged
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButton_NotFinish_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;

            if (rb.Checked)
            {
                if (rb.Tag != null)
                {
                    if (rb.Tag.ToString() == "TM")
                    {
                        dgViewMF.Tag = "AccountingFeeList_Trademark";

                        QueryFilter1.SearchType = "'TrademarkControlFeeList','AccountingFeeList'";
                        QueryFilter2.SearchType = "'TrademarkControlFeeList','AccountingFeeList'";
                    }
                    else
                    {
                        dgViewMF.Tag = "AccountingFeeList";

                        QueryFilter1.SearchType = "'PATControlFeeList','AccountingFeeList'";
                        QueryFilter2.SearchType = "'PATControlFeeList','AccountingFeeList'";
                    }

                    Public.DynamicGridViewColumn.GetGridColum(ref dgViewMF);
                }

                but_Search_Click(null, null);
            }
        }
        #endregion

        #region dgViewMF_CellDoubleClick
        private void dgViewMF_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != -1 && e.RowIndex != -1)
            {
                contextMenuStrip_Accounting_ItemClicked(contextMenuStrip_Accounting,new ToolStripItemClickedEventArgs(ToolStripMenuItem_CaseDetail));
            }
        }
        #endregion

        private void dgViewMF_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        
    }

}
