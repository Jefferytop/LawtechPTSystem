using System;
using System.Data;
using System.Windows.Forms;

namespace LawtechPTSystem.SubFrom
{
    public partial class TrademarkHistoryRecord : Form
    {
        public TrademarkHistoryRecord()
        {
            InitializeComponent();           

            TMNotifyEventTDataGridView.AutoGenerateColumns = false;
            GridView_Fee.AutoGenerateColumns = false;
            dataGridView_Billing.AutoGenerateColumns = false;
            dataGridView_EstimateCost.AutoGenerateColumns = false;

         
            Public.DynamicGridViewColumn.GetGridColum(ref TMNotifyEventTDataGridView);
            Public.DynamicGridViewColumn.GetGridColum(ref GridView_Fee);
            Public.DynamicGridViewColumn.GetGridColum(ref dataGridView_Billing);
            Public.DynamicGridViewColumn.GetGridColum(ref dataGridView_EstimateCost);

        }

        private int iTrademarkID = -1;
        /// <summary>
        /// 商標的PK
        /// </summary>
        public int TrademarkID
        {
            get { return iTrademarkID; }
            set { iTrademarkID = value; }
        }

        string strTMrootPath = "";
        /// <summary>
        /// 商標的上傳資料夾路徑
        /// </summary>
        public string property_TMrootPath
        {
            get
            {
                return strTMrootPath;
            }
            set
            {
                strTMrootPath = value;
            }
        }


        private int iTabSelectedIndex = 0;
        /// <summary>
        /// 第幾個Tab 0.申請案基本資料  1.事件記錄 2.請款  3.付款 2.預估成本
        /// </summary>
        public int TabSelectedIndex
        {
            get { return iTabSelectedIndex; }
            set { iTabSelectedIndex = value; }
        }

        #region ================資料集================
        private DataTable dt_TrademarkList = new DataTable();
        /// <summary>
        /// TrademarkManagement 資料集
        /// </summary>
        public DataTable DT_TrademarkManagementT
        {
            get
            {
                return dt_TrademarkList;
            }

        }

        private DataTable dt_TrademarkNotifyEventT = new DataTable();
        /// <summary>
        /// TrademarkNotifyEventT  事件記錄
        /// </summary>
        public DataTable DT_TrademarkNotifyEventT
        {
            get
            {
                return dt_TrademarkNotifyEventT;
            }

        }

        private DataTable dt_TrademarkFeeT = new DataTable();
        /// <summary>
        /// TrademarkFeeT 請款費用
        /// </summary>
        public DataTable DT_TrademarkFeeT
        {
            get
            {
                return dt_TrademarkFeeT;
            }

        }

        private DataTable dt_TrademarkPaymentT = new DataTable();
        /// <summary>
        /// TrademarkPaymentT 付款費用
        /// </summary>
        public DataTable DT_TrademarkPaymentT
        {
            get
            {
                return dt_TrademarkPaymentT;
            }

        }

        private DataTable dt_TrademarkEstimateCostT = new DataTable();
        /// <summary>
        /// TrademarkPaymentT 付款費用
        /// </summary>
        public DataTable DT_TrademarkEstimateCostT
        {
            get
            {
                return dt_TrademarkEstimateCostT;
            }

        }

        /// <summary>
        /// 重新整理資料集 0.商標 1.事件記錄 2.預估成本  3.請款費用  4.付款費用 
        /// </summary>
        /// <param name="iTable"></param>
        public void RefrashDataTable(int iTable)
        {
            switch (iTable)
            {
                case 0:
                    this.DT_TrademarkManagementT.Rows.Clear();

                    break;
                case 1:
                    this.dt_TrademarkNotifyEventT.Rows.Clear();

                    break;

                case 2:
                    this.dt_TrademarkEstimateCostT.Rows.Clear();

                    break;

                case 3:
                    this.dt_TrademarkFeeT.Rows.Clear();

                    break;

                case 4:
                    this.dt_TrademarkPaymentT.Rows.Clear();

                    break;


            }
        }
        #endregion


        private void TrademarkHistoryRecord_Load(object sender, EventArgs e)
        {
            Public.DLL dll = new Public.DLL();
            property_TMrootPath = dll.TrademarkFolderRoot;

            SetBindingSource();

            TabTrademarkBinding();
            ControlBindingTMNotify();
            ControlBindingTMFee();
            ControlBindingTMEstimateCost();
            ControlBindingTMPayment();

            Tabcontrol1.SelectedIndex = TabSelectedIndex;

            this.Text = this.Text + "(" + txt_TrademarkNo.Text + ")";

            if (!string.IsNullOrEmpty(txt_PicPath.Text) )
            {
                pictureBox1.ImageLocation = property_TMrootPath + "\\" + txt_PicPath.Text;
            }
        }

        #region 設定BindingSource的來源 private void SetBindingSource()
        /// <summary>
        /// 設定BindingSource的來源
        /// </summary>
        private void SetBindingSource()
        {
            if (DT_TrademarkManagementT.Columns.Count == 0)
            {
                Public.CTrademarkPublicFunction.GetTrademarkList("TrademarkID=" + TrademarkID.ToString(),ref dt_TrademarkList);
            }
            trademarkManagementTBindingSource.DataSource = DT_TrademarkManagementT;

            if (DT_TrademarkNotifyEventT.Columns.Count == 0)
            {
                Public.CTrademarkPublicFunction.GetTrademarkEvent(TrademarkID.ToString(),ref dt_TrademarkNotifyEventT);
            }
            trademarkNotifyEventTBindingSource.DataSource = DT_TrademarkNotifyEventT;

            if (DT_TrademarkEstimateCostT.Columns.Count == 0)
            {
                Public.CTrademarkPublicFunction.GetTrademarkEstimateCost(TrademarkID.ToString(),ref dt_TrademarkEstimateCostT);
            }
            trademarkEstimateCostTBindingSource.DataSource = DT_TrademarkEstimateCostT;

            if (DT_TrademarkFeeT.Columns.Count == 0)
            {
                Public.CTrademarkPublicFunction.GetTrademarkFee(TrademarkID.ToString(),ref dt_TrademarkFeeT);
            }
            trademarkFeeTBindingSource.DataSource = DT_TrademarkFeeT;

            if (DT_TrademarkPaymentT.Columns.Count == 0)
            {
                Public.CTrademarkPublicFunction.GetTrademarkPayment(TrademarkID.ToString(),ref dt_TrademarkPaymentT);
            }
            trademarkPaymentTBindingSource.DataSource = DT_TrademarkPaymentT;
        }
        #endregion

        #region ================ControlBinding================

        #region TabTrademarkBinding
        public void TabTrademarkBinding()
        {

            txt_TrademarkName.DataBindings.Clear();
            txt_TrademarkName.DataBindings.Add("Text", trademarkManagementTBindingSource, "TrademarkName", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_ApplicantKey.DataBindings.Clear();
            txt_ApplicantKey.DataBindings.Add("Text", trademarkManagementTBindingSource, "ApplicantNames", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_TrademarkNo.DataBindings.Clear();
            txt_TrademarkNo.DataBindings.Add("Text", trademarkManagementTBindingSource, "TrademarkNo", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_Name.DataBindings.Clear();
            txt_Name.DataBindings.Add("Text", trademarkManagementTBindingSource, "EmployeeName", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_RegisterProductItems.Clear();
            txt_RegisterProductItems.DataBindings.Add("Text", trademarkManagementTBindingSource, "RegisterProductName", true, DataSourceUpdateMode.OnValidation, "", "");


            txt_OutsourcingTrademarkNo.DataBindings.Clear();
            txt_OutsourcingTrademarkNo.DataBindings.Add("Text", trademarkManagementTBindingSource, "OutsourcingTrademarkNo", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_ApplicationNo.DataBindings.Clear();
            txt_ApplicationNo.DataBindings.Add("Text", trademarkManagementTBindingSource, "ApplicationNo", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_NoticeNo.DataBindings.Clear();
            txt_NoticeNo.DataBindings.Add("Text", trademarkManagementTBindingSource, "NoticeNo1", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_NoticeNo2.DataBindings.Clear();
            txt_NoticeNo2.DataBindings.Add("Text", trademarkManagementTBindingSource, "NoticeNo", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_RegistrationNo.DataBindings.Clear();
            txt_RegistrationNo.DataBindings.Add("Text", trademarkManagementTBindingSource, "RegistrationNo", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_RegisterProduct.DataBindings.Clear();
            txt_RegisterProduct.DataBindings.Add("Text", trademarkManagementTBindingSource, "RegisterProduct", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_Remarks.DataBindings.Clear();
            txt_Remarks.DataBindings.Add("Text", trademarkManagementTBindingSource, "Remarks", true, DataSourceUpdateMode.OnPropertyChanged, "");

            txt_PicPath.DataBindings.Clear();
            txt_PicPath.DataBindings.Add("Text", trademarkManagementTBindingSource, "PicPath", true, DataSourceUpdateMode.OnPropertyChanged, "");


            txt_OutsourcingTrademarkNo.DataBindings.Clear();
            txt_OutsourcingTrademarkNo.DataBindings.Add("Text", trademarkManagementTBindingSource, "OutsourcingTrademarkNo", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_RegistrationNo.DataBindings.Clear();
            txt_RegistrationNo.DataBindings.Add("Text", trademarkManagementTBindingSource, "RegistrationNo", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_Status.DataBindings.Clear();
            txt_Status.DataBindings.Add("Text", trademarkManagementTBindingSource, "StatusName", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_StatusExplain.DataBindings.Clear();
            txt_StatusExplain.DataBindings.Add("Text", trademarkManagementTBindingSource, "StatusExplain", true, DataSourceUpdateMode.OnPropertyChanged, "");

            //優先權
            txt_Priority.DataBindings.Clear();
            txt_Priority.DataBindings.Add("Text", trademarkManagementTBindingSource, "PriorityBaseName", true, DataSourceUpdateMode.OnValidation);

            txt_EarlyPriorityNo.DataBindings.Clear();
            txt_EarlyPriorityNo.DataBindings.Add("Text", trademarkManagementTBindingSource, "EarlyPriorityNo", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_RegisterProduct.DataBindings.Clear();
            txt_RegisterProduct.DataBindings.Add("Text", trademarkManagementTBindingSource, "RegisterProduct", true, DataSourceUpdateMode.OnValidation, "", "");

            maskedTextBox_EntrustDate.DataBindings.Clear();
            maskedTextBox_EntrustDate.DataBindings.Add("Text", trademarkManagementTBindingSource, "EntrustDate", true, DataSourceUpdateMode.OnPropertyChanged, "    -  -", "yyyy-MM-dd");

            maskedTextBox_RegistrationDate.DataBindings.Clear();
            maskedTextBox_RegistrationDate.DataBindings.Add("Text", trademarkManagementTBindingSource, "RegistrationDate", true, DataSourceUpdateMode.OnValidation, "    -  -", "yyyy-MM-dd");

            maskedTextBox_LawDate.DataBindings.Clear();
            maskedTextBox_LawDate.DataBindings.Add("Text", trademarkManagementTBindingSource, "LawDate", true, DataSourceUpdateMode.OnPropertyChanged, "    -  -", "yyyy-MM-dd");

            maskedTextBox_NoticeDate.DataBindings.Clear();
            maskedTextBox_NoticeDate.DataBindings.Add("Text", trademarkManagementTBindingSource, "NoticeDate1", true, DataSourceUpdateMode.OnPropertyChanged, "    -  -", "yyyy-MM-dd");

            maskedTextBox_NoticeDate2.DataBindings.Clear();
            maskedTextBox_NoticeDate2.DataBindings.Add("Text", trademarkManagementTBindingSource, "NoticeDate", true, DataSourceUpdateMode.OnPropertyChanged, "    -  -", "yyyy-MM-dd");

            maskedTextBox_DueDate.DataBindings.Clear();
            maskedTextBox_DueDate.DataBindings.Add("Text", trademarkManagementTBindingSource, "DueDate", true, DataSourceUpdateMode.OnPropertyChanged, "    -  -", "yyyy-MM-dd");

            maskedTextBox_ExtendedDate.DataBindings.Clear();
            maskedTextBox_ExtendedDate.DataBindings.Add("Text", trademarkManagementTBindingSource, "ExtendedDate", true, DataSourceUpdateMode.OnPropertyChanged, "    -  -", "yyyy-MM-dd");

            maskedTextBox_CloseDate.DataBindings.Clear();
            maskedTextBox_CloseDate.DataBindings.Add("Text", trademarkManagementTBindingSource, "CloseDate", true, DataSourceUpdateMode.OnPropertyChanged, "    -  -", "yyyy-MM-dd");

            maskedTextBox_ApplicationDate.DataBindings.Clear();
            maskedTextBox_ApplicationDate.DataBindings.Add("Text", trademarkManagementTBindingSource, "ApplicationDate", true, DataSourceUpdateMode.OnPropertyChanged, "    -  -", "yyyy-MM-dd");

            //委託性質
            txt_DelegateFeatureName.DataBindings.Clear();
            txt_DelegateFeatureName.DataBindings.Add("Text", trademarkManagementTBindingSource, "DelegateFeatureName", true, DataSourceUpdateMode.OnValidation);

            //委託類型
            txt_DelegateType.DataBindings.Clear();
            txt_DelegateType.DataBindings.Add("Text", trademarkManagementTBindingSource, "DelegateTypeName", true, DataSourceUpdateMode.OnValidation);

            //主委託人
            txt_MainCustomer.DataBindings.Clear();
            txt_MainCustomer.DataBindings.Add("Text", trademarkManagementTBindingSource, "MainCustomerName", true, DataSourceUpdateMode.OnValidation);

            //主委託人--聯絡窗口
            txt_MainCustomerTransactor.DataBindings.Clear();
            txt_MainCustomerTransactor.DataBindings.Add("Text", trademarkManagementTBindingSource, "MainCustomerTransactorName", true, DataSourceUpdateMode.OnValidation);

            //主委託人--對方案號
            txt_MainCustomerRefNo.DataBindings.Clear();
            txt_MainCustomerRefNo.DataBindings.Add("Text", trademarkManagementTBindingSource, "MainCustomerRefNo", true, DataSourceUpdateMode.OnValidation);

            //是否本所承辦案件
            chb_IsBySelf.DataBindings.Clear();
            chb_IsBySelf.DataBindings.Add("Checked", trademarkManagementTBindingSource, "IsBySelf", true, DataSourceUpdateMode.OnPropertyChanged, false);

            //承辦事務所
            txt_AttorneyFirm.DataBindings.Clear();
            txt_AttorneyFirm.DataBindings.Add("Text", trademarkManagementTBindingSource, "AttorneyFirm", true, DataSourceUpdateMode.OnValidation, "", "");

            //事務所聯絡人
            txt_Liaisoner.DataBindings.Clear();
            txt_Liaisoner.DataBindings.Add("Text", trademarkManagementTBindingSource, "AttLiaisoner", true, DataSourceUpdateMode.OnValidation, "", "");

            //承辦事務所-委辦日期
            maskedTextBox_OutsourcingDate.DataBindings.Clear();
            maskedTextBox_OutsourcingDate.DataBindings.Add("Text", trademarkManagementTBindingSource, "OutsourcingDate", true, DataSourceUpdateMode.OnPropertyChanged, "    -  -", "yyyy-MM-dd");

            //提案家族
            txt_TrademarkOvertureName.DataBindings.Clear();
            txt_TrademarkOvertureName.DataBindings.Add("Text", trademarkManagementTBindingSource, "TrademarkOvertureName", true, DataSourceUpdateMode.OnValidation);

            txt_StyleName.Clear();
            txt_StyleName.DataBindings.Add("Text", trademarkManagementTBindingSource, "StyleName", true, DataSourceUpdateMode.OnValidation, "", "");
        }
        #endregion

        #region ControlBindingTMNotify
        public void ControlBindingTMNotify()
        {

            txt_NotifyEventContent.DataBindings.Clear();
            txt_NotifyEventContent.DataBindings.Add("Text", trademarkNotifyEventTBindingSource, "NotifyEventContent", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_WorkerKey.DataBindings.Clear(); 
            txt_WorkerKey.DataBindings.Add("Text", trademarkNotifyEventTBindingSource, "EmployeeName", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_NotifyResult.DataBindings.Clear();
            txt_NotifyResult.DataBindings.Add("Text", trademarkNotifyEventTBindingSource, "Result", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_NotifyRemark.DataBindings.Clear();
            txt_NotifyRemark.DataBindings.Add("Text", trademarkNotifyEventTBindingSource, "Remark", true, DataSourceUpdateMode.OnValidation, "", "");

            maskedTextBox_NotifyComitDate.DataBindings.Clear();
            maskedTextBox_NotifyComitDate.DataBindings.Add("Text", trademarkNotifyEventTBindingSource, "NotifyComitDate", true, DataSourceUpdateMode.OnPropertyChanged, "    -  -", "yyyy-MM-dd");

            maskedTextBox_NotifyOfficerDate.DataBindings.Clear();
            maskedTextBox_NotifyOfficerDate.DataBindings.Add("Text", trademarkNotifyEventTBindingSource, "NotifyOfficerDate", true, DataSourceUpdateMode.OnPropertyChanged, "    -  -", "yyyy-MM-dd");

            maskedTextBox_OccurDate.DataBindings.Clear();
            maskedTextBox_OccurDate.DataBindings.Add("Text", trademarkNotifyEventTBindingSource, "OccurDate", true, DataSourceUpdateMode.OnPropertyChanged, "    -  -", "yyyy-MM-dd");

            maskedTextBox_DueDate.DataBindings.Clear();
            maskedTextBox_DueDate.DataBindings.Add("Text", trademarkNotifyEventTBindingSource, "DueDate", true, DataSourceUpdateMode.OnPropertyChanged, "    -  -", "yyyy-MM-dd");

            maskedTextBox_Notice.DataBindings.Clear();
            maskedTextBox_Notice.DataBindings.Add("Text", trademarkNotifyEventTBindingSource, "NoticeDate", true, DataSourceUpdateMode.OnPropertyChanged, "    -  -", "yyyy-MM-dd");

            maskedTextBox_CustomerAuthorizationDate.DataBindings.Clear();
            maskedTextBox_CustomerAuthorizationDate.DataBindings.Add("Text", trademarkNotifyEventTBindingSource, "CustomerAuthorizationDate", true, DataSourceUpdateMode.OnPropertyChanged, "    -  -", "yyyy-MM-dd");

            mtb_OutsourcingDate.DataBindings.Clear();
            mtb_OutsourcingDate.DataBindings.Add("Text", trademarkNotifyEventTBindingSource, "OutsourcingDate", true, DataSourceUpdateMode.OnPropertyChanged, "    -  -", "yyyy-MM-dd");

            maskedTextBox_FinishDate.DataBindings.Clear();
            maskedTextBox_FinishDate.DataBindings.Add("Text", trademarkNotifyEventTBindingSource, "FinishDate", true, DataSourceUpdateMode.OnPropertyChanged, "    -  -", "yyyy-MM-dd");

            maskedTextBox_AttorneyDueDate.DataBindings.Clear();
            maskedTextBox_AttorneyDueDate.DataBindings.Add("Text", trademarkNotifyEventTBindingSource, "AttorneyDueDate", true, DataSourceUpdateMode.OnPropertyChanged, "    -  -", "yyyy-MM-dd");

        }
        #endregion

        #region ControlBindingTMFee
        public void ControlBindingTMFee()
        {

            txt_FeeSubject.DataBindings.Clear();
            txt_FeeSubject.DataBindings.Add("Text", trademarkFeeTBindingSource, "FeeSubject", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_FeePhase.DataBindings.Clear();
            txt_FeePhase.DataBindings.Add("Text", trademarkFeeTBindingSource, "FeePhase", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_AttorneyName.DataBindings.Clear();
            txt_AttorneyName.DataBindings.Add("Text", trademarkFeeTBindingSource, "AttorneyFirm", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_PayMemo.DataBindings.Clear();
            txt_PayMemo.DataBindings.Add("Text", trademarkFeeTBindingSource, "PayMemo", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_Remark.DataBindings.Clear();
            txt_Remark.DataBindings.Add("Text", trademarkFeeTBindingSource, "Remark", true, DataSourceUpdateMode.OnValidation, "", "");

            txtAttorneyFee2.DataBindings.Clear();
            txtAttorneyFee2.DataBindings.Add("Text", trademarkFeeTBindingSource, "OAttorneyFee", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");

            txtAttorneyFee3.DataBindings.Clear();
            txtAttorneyFee3.DataBindings.Add("Text", trademarkFeeTBindingSource, "OthFee", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");

            txtAttorneyFee4.DataBindings.Clear();
            txtAttorneyFee4.DataBindings.Add("Text", trademarkFeeTBindingSource, "GovFee", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");

            txt_TMoney.DataBindings.Clear();
            txt_TMoney.DataBindings.Add("Text", trademarkFeeTBindingSource, "TMoney", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_OMoney.DataBindings.Clear();
            txt_OMoney.DataBindings.Add("Text", trademarkFeeTBindingSource, "OMoney", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_OMoney1.DataBindings.Clear();
            txt_OMoney1.DataBindings.Add("Text", trademarkFeeTBindingSource, "OthMoney", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_GMoney.DataBindings.Clear();
            txt_GMoney.DataBindings.Add("Text", trademarkFeeTBindingSource, "GMoney", true, DataSourceUpdateMode.OnValidation, "", "");

            txtMoney1.DataBindings.Clear();
            txtMoney1.DataBindings.Add("Text", trademarkFeeTBindingSource, "TtoNT", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");

            txtMoney2.DataBindings.Clear();
            txtMoney2.DataBindings.Add("Text", trademarkFeeTBindingSource, "OtoNT", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");

            txtMoney21.DataBindings.Clear();
            txtMoney21.DataBindings.Add("Text", trademarkFeeTBindingSource, "OthtoNT", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");

            txtMoney3.DataBindings.Clear();
            txtMoney3.DataBindings.Add("Text", trademarkFeeTBindingSource, "GtoNT", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");

            txtAttorneyFeeTotal1.DataBindings.Clear();
            txtAttorneyFeeTotal1.DataBindings.Add("Text", trademarkFeeTBindingSource, "TotalNT", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");

            txtAttorneyFeeTotal2.DataBindings.Clear();
            txtAttorneyFeeTotal2.DataBindings.Add("Text", trademarkFeeTBindingSource, "OTotall", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");

            txtAttorneyFeeTotal3.DataBindings.Clear();
            txtAttorneyFeeTotal3.DataBindings.Add("Text", trademarkFeeTBindingSource, "OthTotal", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");

            txtAttorneyFeeTotal4.DataBindings.Clear();
            txtAttorneyFeeTotal4.DataBindings.Add("Text", trademarkFeeTBindingSource, "GTotall", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");

            txt_PayKind.DataBindings.Clear();
            txt_PayKind.DataBindings.Add("Text", trademarkFeeTBindingSource, "PayKind", true, DataSourceUpdateMode.OnValidation, "", "");

            checkBox_Pay.DataBindings.Clear();
            checkBox_Pay.DataBindings.Add("Checked", trademarkFeeTBindingSource, "Pay", true, DataSourceUpdateMode.OnValidation, false);

            checkBox_NT.DataBindings.Clear();
            checkBox_NT.DataBindings.Add("Checked", trademarkFeeTBindingSource, "NT", true, DataSourceUpdateMode.OnValidation, false);

            chkWithholding.DataBindings.Clear();
            chkWithholding.DataBindings.Add("Checked", trademarkFeeTBindingSource, "Withholding", true, DataSourceUpdateMode.OnValidation, false);

            txt_Tax.DataBindings.Clear();
            txt_Tax.DataBindings.Add("Text", trademarkFeeTBindingSource, "Tax", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");

            txtOAttorneyGovFee.DataBindings.Clear();
            txtOAttorneyGovFee.DataBindings.Add("Text", trademarkFeeTBindingSource, "OAttorneyGovFee", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");

            txtTotall.DataBindings.Clear();
            txtTotall.DataBindings.Add("Text", trademarkFeeTBindingSource, "Totall", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");

            txt_OtherTotalFee.DataBindings.Clear();
            txt_OtherTotalFee.DataBindings.Add("Text", trademarkFeeTBindingSource, "OtherTotalFee", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");

            txtPracicalityPay.DataBindings.Clear();
            txtPracicalityPay.DataBindings.Add("Text", trademarkFeeTBindingSource, "PracticalityPay", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");

            txt_PayMemo.DataBindings.Clear();
            txt_PayMemo.DataBindings.Add("Text", trademarkFeeTBindingSource, "PayMemo", true, DataSourceUpdateMode.OnValidation, "", "");

            //簽核
            txt_SingCode.DataBindings.Clear();
            txt_SingCode.DataBindings.Add("Text", trademarkFeeTBindingSource, "SingCode", true, DataSourceUpdateMode.OnPropertyChanged, "", "");

            //請款單號
            txt_PPP.DataBindings.Clear();
            txt_PPP.DataBindings.Add("Text", trademarkFeeTBindingSource, "PPP", true, DataSourceUpdateMode.OnValidation, "", "");

            //請款人
            txt_FeeWorkerName.DataBindings.Clear();
            txt_FeeWorkerName.DataBindings.Add("Text", trademarkFeeTBindingSource, "EmployeeName", true, DataSourceUpdateMode.OnValidation, "", "");


            //請款日期
            maskedTextBox_RDate.DataBindings.Clear();
            maskedTextBox_RDate.DataBindings.Add("Text", trademarkFeeTBindingSource, "RDate", true, DataSourceUpdateMode.OnValidation, "    -  -", "yyyy-MM-dd");

            //收據日期
            maskedTextBox_ReceiptDate.DataBindings.Clear();
            maskedTextBox_ReceiptDate.DataBindings.Add("Text", trademarkFeeTBindingSource, "ReceiptDate", true, DataSourceUpdateMode.OnValidation, "    -  -", "yyyy-MM-dd");

            //收款日期
            maskedTextBox_PayDate.DataBindings.Clear();
            maskedTextBox_PayDate.DataBindings.Add("Text", trademarkFeeTBindingSource, "PayDate", true, DataSourceUpdateMode.OnValidation, "    -  -", "yyyy-MM-dd");

            // 發票日期
            maskedTextBox_aBillDate.DataBindings.Clear();
            maskedTextBox_aBillDate.DataBindings.Add("Text", trademarkFeeTBindingSource, "aBillDate", true, DataSourceUpdateMode.OnPropertyChanged, "    -  -", "yyyy-MM-dd");

            //發票號碼
            txt_aBill.DataBindings.Clear();
            txt_aBill.DataBindings.Add("Text", trademarkFeeTBindingSource, "aBill", true, DataSourceUpdateMode.OnValidation, "", "");
        }

        #endregion

        #region ControlBindingTMEstimateCost
        public void ControlBindingTMEstimateCost()
        {
            txt_ES_FeeSubject.DataBindings.Clear();
            txt_ES_FeeSubject.DataBindings.Add("Text", trademarkEstimateCostTBindingSource, "FeeSubject", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_ES_IAttorneyFee.DataBindings.Clear();
            txt_ES_IAttorneyFee.DataBindings.Add("Text", trademarkEstimateCostTBindingSource, "IAttorneyFee", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");

            txt_ES_OAttorneyFee.DataBindings.Clear();
            txt_ES_OAttorneyFee.DataBindings.Add("Text", trademarkEstimateCostTBindingSource, "OAttorneyFee", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");

            txt_ES_OMoney.DataBindings.Clear();
            txt_ES_OMoney.DataBindings.Add("Text", trademarkEstimateCostTBindingSource, "OMoney", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_ES_OtoNT.DataBindings.Clear();
            txt_ES_OtoNT.DataBindings.Add("Text", trademarkEstimateCostTBindingSource, "OtoNT", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");

            txt_ES_OTotall.DataBindings.Clear();
            txt_ES_OTotall.DataBindings.Add("Text", trademarkEstimateCostTBindingSource, "OTotall", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");

            txt_ES_GovFee.DataBindings.Clear();
            txt_ES_GovFee.DataBindings.Add("Text", trademarkEstimateCostTBindingSource, "GovFee", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");

            txt_ES_OtherFee.DataBindings.Clear();
            txt_ES_OtherFee.DataBindings.Add("Text", trademarkEstimateCostTBindingSource, "OtherFee", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");

            txt_ES_IMoney.DataBindings.Clear();
            txt_ES_IMoney.DataBindings.Add("Text", trademarkEstimateCostTBindingSource, "IMoney", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_ES_OtherMoney.DataBindings.Clear();
            txt_ES_OtherMoney.DataBindings.Add("Text", trademarkEstimateCostTBindingSource, "OtherMoney", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_ES_GMoney.DataBindings.Clear();
            txt_ES_GMoney.DataBindings.Add("Text", trademarkEstimateCostTBindingSource, "GMoney", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_ES_ItoNT.DataBindings.Clear();
            txt_ES_ItoNT.DataBindings.Add("Text", trademarkEstimateCostTBindingSource, "ItoNT", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");

            txt_ES_ITotall.DataBindings.Clear();
            txt_ES_ITotall.DataBindings.Add("Text", trademarkEstimateCostTBindingSource, "ITotall", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");

            txt_ES_GtoNT.DataBindings.Clear();
            txt_ES_GtoNT.DataBindings.Add("Text", trademarkEstimateCostTBindingSource, "GtoNT", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");

            txt_ES_GTotall.DataBindings.Clear();
            txt_ES_GTotall.DataBindings.Add("Text", trademarkEstimateCostTBindingSource, "GTotall", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");

            txt_ES_OtherNT.DataBindings.Clear();
            txt_ES_OtherNT.DataBindings.Add("Text", trademarkEstimateCostTBindingSource, "OtherNT", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");

            txt_ES_OtherTotal.DataBindings.Clear();
            txt_ES_OtherTotal.DataBindings.Add("Text", trademarkEstimateCostTBindingSource, "OtherTotal", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");

            txt_EstimateProfit.DataBindings.Clear();
            txt_EstimateProfit.DataBindings.Add("Text", trademarkEstimateCostTBindingSource, "EstimateProfit", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");

            txt_EstimateCost.DataBindings.Clear();
            txt_EstimateCost.DataBindings.Add("Text", trademarkEstimateCostTBindingSource, "EstimateCost", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");

            txt_RealPrice.DataBindings.Clear();
            txt_RealPrice.DataBindings.Add("Text", trademarkEstimateCostTBindingSource, "RealPrice", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");

            txt_ES_PayMemo.DataBindings.Clear();
            txt_ES_PayMemo.DataBindings.Add("Text", trademarkEstimateCostTBindingSource, "PayMemo", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_ES_Remark.DataBindings.Clear();
            txt_ES_Remark.DataBindings.Add("Text", trademarkEstimateCostTBindingSource, "Remark", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_ServicePrice.DataBindings.Clear();
            txt_ServicePrice.DataBindings.Add("Text", trademarkEstimateCostTBindingSource, "ServicePrice", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");


        }

        #endregion

        #region ControlBindingTMPayment
        public void ControlBindingTMPayment()
        {
            txt_PayFeeSubject.DataBindings.Clear();
            txt_PayFeeSubject.DataBindings.Add("Text", trademarkPaymentTBindingSource, "FeeSubject", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_PayFeePhase.DataBindings.Clear();
            txt_PayFeePhase.DataBindings.Add("Text", trademarkPaymentTBindingSource, "FeePhase", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_PaySingCode.DataBindings.Clear();
            txt_PaySingCode.DataBindings.Add("Text", trademarkPaymentTBindingSource, "SingCode", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_FClientTransactor.DataBindings.Clear();
            txt_FClientTransactor.DataBindings.Add("Text", trademarkPaymentTBindingSource, "EmployeeName", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_Attorney.DataBindings.Clear();
            txt_Attorney.DataBindings.Add("Text", trademarkPaymentTBindingSource, "AttorneyFirm", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_PayPayKind.DataBindings.Clear();
            txt_PayPayKind.DataBindings.Add("Text", trademarkPaymentTBindingSource, "PayKind", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_PayIMoney.DataBindings.Clear();
            txt_PayIMoney.DataBindings.Add("Text", trademarkPaymentTBindingSource, "IMoney", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_IServiceFee.DataBindings.Clear();
            txt_IServiceFee.DataBindings.Add("Text", trademarkPaymentTBindingSource, "IServiceFee", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");

            txt_GovFee.DataBindings.Clear();
            txt_GovFee.DataBindings.Add("Text", trademarkPaymentTBindingSource, "GovFee", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");

            txt_OtherFee.DataBindings.Clear();
            txt_OtherFee.DataBindings.Add("Text", trademarkPaymentTBindingSource, "OtherFee", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");

            txt_IReceiptNo.DataBindings.Clear();
            txt_IReceiptNo.DataBindings.Add("Text", trademarkPaymentTBindingSource, "IReceiptNo", true, DataSourceUpdateMode.OnValidation, "", "");

            maskedTextBox_IReceiptDate.DataBindings.Clear();
            maskedTextBox_IReceiptDate.DataBindings.Add("Text", trademarkPaymentTBindingSource, "IReceiptDate", true, DataSourceUpdateMode.OnPropertyChanged, "    -  -", "yyyy-MM-dd");

            txt_PayTotall.DataBindings.Clear();
            txt_PayTotall.DataBindings.Add("Text", trademarkPaymentTBindingSource, "Totall", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");

            txt_PayRemark.DataBindings.Clear();
            txt_PayRemark.DataBindings.Add("Text", trademarkPaymentTBindingSource, "Remark", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_Memo.DataBindings.Clear();
            txt_Memo.DataBindings.Add("Text", trademarkPaymentTBindingSource, "Memo", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_BillCheck.DataBindings.Clear();
            txt_BillCheck.DataBindings.Add("Text", trademarkPaymentTBindingSource, "BillCheck", true, DataSourceUpdateMode.OnValidation, "", "");

            maskedTextBox_ReciveDate.DataBindings.Clear();
            maskedTextBox_ReciveDate.DataBindings.Add("Text", trademarkPaymentTBindingSource, "ReciveDate", true, DataSourceUpdateMode.OnPropertyChanged, "    -  -", "yyyy-MM-dd");

            maskedTextBox_PayDueDate.DataBindings.Clear();
            maskedTextBox_PayDueDate.DataBindings.Add("Text", trademarkPaymentTBindingSource, "PayDueDate", true, DataSourceUpdateMode.OnPropertyChanged, "    -  -", "yyyy-MM-dd");

            maskedTextBox_PaymentDate.DataBindings.Clear();
            maskedTextBox_PaymentDate.DataBindings.Add("Text", trademarkPaymentTBindingSource, "PaymentDate", true, DataSourceUpdateMode.OnPropertyChanged, "    -  -", "yyyy-MM-dd");

            checkBox_IsBilling.DataBindings.Clear();
            checkBox_IsBilling.DataBindings.Add("Checked", trademarkPaymentTBindingSource, "IsBilling", true, DataSourceUpdateMode.OnValidation, false);

            txt_BillingNo.DataBindings.Clear();
            txt_BillingNo.DataBindings.Add("Text", trademarkPaymentTBindingSource, "BillingNo", true, DataSourceUpdateMode.OnValidation, "", "");

            checkBox_IsCopyFile.DataBindings.Clear();
            checkBox_IsCopyFile.DataBindings.Add("Checked", trademarkPaymentTBindingSource, "IsCopyFile", true, DataSourceUpdateMode.OnValidation, false);

            checkBox_IsScan.DataBindings.Clear();
            checkBox_IsScan.DataBindings.Add("Checked", trademarkPaymentTBindingSource, "IsScan", true, DataSourceUpdateMode.OnValidation, false);

            //匯率
            txt_ExchangeRate.DataBindings.Clear();
            txt_ExchangeRate.DataBindings.Add("Text", trademarkPaymentTBindingSource, "ExchangeRate", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");

            //實付金額
            txt_ActuallyPay.DataBindings.Clear();
            txt_ActuallyPay.DataBindings.Add("Text", trademarkPaymentTBindingSource, "ActuallyPay", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");
        }

        #endregion

        #endregion            
   
        
        private void linkLabel_mome_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LinkLabel link = (LinkLabel)sender;
            US.PopMemo pop;
            switch (link.Name)
            {
                case "linkLabel_CloseCaus":
                    pop = new LawtechPTSystem.US.PopMemo(txt_CloseCaus, true, link.Text);
                    break;
                case "linkLabel_mome":
                    pop = new LawtechPTSystem.US.PopMemo(txt_Remarks, true, link.Text);
                    break;
                case "linkLabel_ComintRemark":
                    pop = new LawtechPTSystem.US.PopMemo(txt_NotifyRemark, true, link.Text);
                    break;
                case "linkLabel_NotifyResult":
                    pop = new LawtechPTSystem.US.PopMemo(txt_NotifyResult, true, link.Text);
                    break;
                case "linkLabel_ES_PayMemo":
                    pop = new LawtechPTSystem.US.PopMemo(txt_ES_PayMemo, true, link.Text);
                    break;
                case "linkLabel_ES_Remark":
                    pop = new LawtechPTSystem.US.PopMemo(txt_ES_Remark, true, link.Text);
                    break;
                case "linkLabel_PayMemo":
                    pop = new LawtechPTSystem.US.PopMemo(txt_PayMemo, true, link.Text);
                    break;
                case "linkLabel_PayRemark":
                    pop = new LawtechPTSystem.US.PopMemo(txt_PayRemark, true, link.Text);
                    break;
                case "linkLabel_EarlyPriorityNo":
                    pop = new LawtechPTSystem.US.PopMemo(txt_EarlyPriorityNo, true, link.Text);
                    break;
                case "linkLabel_PayKind":
                    pop = new LawtechPTSystem.US.PopMemo(txt_PayKind, true, link.Text);
                    break;
                case "linkLabel_Remark":
                    pop = new LawtechPTSystem.US.PopMemo(txt_Remark, true, link.Text);
                    break;
                default:
                    pop = new LawtechPTSystem.US.PopMemo(txt_Remarks, true, link.Text);
                    break;
            }

            pop.Show();
        }

       
        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            if (this.DT_TrademarkManagementT.Rows[0]["PicPath"].ToString() != "")
            {
                try
                {
                    string sPath = property_TMrootPath + "\\" + this.DT_TrademarkManagementT.Rows[0]["PicPath"].ToString();
                    Public.Utility.ProcessStart(sPath);
                }
                catch (System.Exception EX)
                {
                    MessageBox.Show(EX.Message, "提示訊息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pictureBox1_DoubleClick(null, null);
        }

     

        private void but_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkLabel_mome_LinkClicked(object sender, EventArgs e)
        {

        }

        private void GridView_Fee_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = false;
        }
    }
}
