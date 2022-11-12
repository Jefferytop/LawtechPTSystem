
using System;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LawtechPTSystem.SubFrom
{
    public partial class PatentHistoryRecord1 : Form
    {
        public PatentHistoryRecord1()
        {
            InitializeComponent();
         
            dataGridView_EstimateCost.AutoGenerateColumns = false;
            GridView_PatComit.AutoGenerateColumns = false;
            dataGridView_Billing.AutoGenerateColumns = false;
            GridView_Fee.AutoGenerateColumns = false;
           
            Public.DynamicGridViewColumn.GetGridColum(ref GridView_PatComit);
            Public.DynamicGridViewColumn.GetGridColum(ref GridView_Fee);
            Public.DynamicGridViewColumn.GetGridColum(ref dataGridView_Billing);
            Public.DynamicGridViewColumn.GetGridColum(ref dataGridView_EstimateCost);
        }

        private void but_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region  ============property============
        private int _PatentID = -1;
        /// <summary>
        /// PatentID
        /// </summary>
        public int property_PatentID
        {
            get
            {
                return _PatentID;

            }
            set
            {
                _PatentID = value;
            }
        }

        private int iTabSelectedIndex = 0;
        /// <summary>
        /// 第幾個Tab 0.申請案基本資料  1.事件記錄  2.請款  3.付款
        /// </summary>
        public int TabSelectedIndex
        {
            get { return iTabSelectedIndex; }
            set { iTabSelectedIndex = value; }
        }

        #endregion

        #region ===========資料集===========
        private DataTable dt_PatentList = new DataTable();
        /// <summary>
        /// PatentManagement 資料集
        /// </summary>
        public DataTable DT_PatentList
        {
            get
            {
                return dt_PatentList;
            }

        }

        private DataTable dt_PatComitEventT = new DataTable();
        /// <summary>
        /// PatComitEventT 事件記錄
        /// </summary>
        public DataTable DT_PatComitEventT
        {
            get
            {
                return dt_PatComitEventT;
            }

        }

        private DataTable dt_PatNotifyEventT = new DataTable();
        /// <summary>
        /// PatNotifyEventT 來函
        /// </summary>
        public DataTable DT_PatNotifyEventT
        {
            get
            {
                return dt_PatNotifyEventT;
            }

        }

        private DataTable dt_PatentEstimateCostT = new DataTable();
        /// <summary>
        /// PatentEstimateCostT 預估費用
        /// </summary>
        public DataTable DT_PatentEstimateCostT
        {
            get
            {
                return dt_PatentEstimateCostT;
            }

        }

        private DataTable dt_PatentFeeT = new DataTable();
        /// <summary>
        /// PatentFeeT 請款費用
        /// </summary>
        public DataTable DT_PatentFeeT
        {
            get
            {
                return dt_PatentFeeT;
            }

        }

        private DataTable dt_PatentPaymentT = new DataTable();
        /// <summary>
        /// PatentFeeT 付款費用
        /// </summary>
        public DataTable DT_PatentPaymentT
        {
            get
            {
                return dt_PatentPaymentT;
            }

        }

        /// <summary>
        /// 重新整理資料集 1.事件記錄  2.預估費用  3.請款費用  4.付款費用
        /// </summary>
        /// <param name="iTable"></param>
        public void RefrashDataTable(int iTable)
        {
            switch (iTable)
            {
                case 0:
                    this.DT_PatentList.Rows.Clear();
                    break;
                case 1:
                    this.DT_PatComitEventT.Rows.Clear();
                    break;
                case 2:
                    this.DT_PatentEstimateCostT.Rows.Clear();
                    break;
                case 3:
                    this.DT_PatentFeeT.Rows.Clear();
                    break;

                case 4:
                    this.DT_PatentPaymentT.Rows.Clear();
                    break;
            }
        }
        #endregion

        #region PatentHistoryRecord_Load
        private void PatentHistoryRecord_Load(object sender, EventArgs e)
        {
            
            SetBindingSource();

            TabFileBinding();
            ControlBindingPatComit();            
            ControlBindingTMFee();
            ControlBindingTMPayment();
            ControlBindingTMEstimateCost();
           
            Tabcontrol1.SelectedIndex = TabSelectedIndex;
        }
        #endregion

        #region 設定BindingSource的來源 private void SetBindingSource()
        /// <summary>
        /// 設定BindingSource的來源
        /// </summary>
        private void SetBindingSource()
        {
            if (dt_PatentList.Columns.Count == 0)
            {
                Public.CPatentPublicFunction.GetPatentList(" PatentID=" + property_PatentID.ToString(), ref dt_PatentList);
            }
            bSource_File.DataSource = dt_PatentList;

            if (dt_PatComitEventT.Columns.Count == 0)
            {
                Public.CPatentPublicFunction.GetPatentEvent(property_PatentID.ToString(), ref dt_PatComitEventT);
            }
            patComitEventTBindingSource.DataSource = dt_PatComitEventT;

            if (dt_PatentEstimateCostT.Columns.Count == 0)
            {
                Public.CPatentPublicFunction.GetPatentEstimateCost(property_PatentID.ToString(), ref dt_PatentEstimateCostT);
            }
            patentEstimateCostTBindingSource.DataSource = dt_PatentEstimateCostT;

            if (dt_PatentFeeT.Columns.Count == 0)
            {
                Public.CPatentPublicFunction.GetPatentkFee(property_PatentID.ToString(), ref dt_PatentFeeT);
            }
            patentFeeTBindingSource.DataSource = dt_PatentFeeT;

            if (dt_PatentPaymentT.Columns.Count == 0)
            {
                Public.CPatentPublicFunction.GetPatentPayment(property_PatentID.ToString(), ref dt_PatentPaymentT);
            }
            patentPaymentTBindingSource.DataSource = dt_PatentPaymentT;
        }
        #endregion

        #region ================ControlBinding================

        #region TabFileBinding
        public void TabFileBinding()
        {
            //申請案卷號
            txt_PatentNo.DataBindings.Clear();
            txt_PatentNo.DataBindings.Add("Text", bSource_File, "PatentNo", true, DataSourceUpdateMode.OnValidation, "", "");
            //提案名稱
            txt_FileNo_Old.DataBindings.Clear();
            txt_FileNo_Old.DataBindings.Add("Text", bSource_File, "PatentNo_Old", true, DataSourceUpdateMode.OnValidation, "", "");
            //申請案名稱
            txt_title.DataBindings.Clear();
            txt_title.DataBindings.Add("Text", bSource_File, "Title", true, DataSourceUpdateMode.OnValidation, "", "");
            //申請案名稱(英)
            txt_TitleEn.DataBindings.Clear();
            txt_TitleEn.DataBindings.Add("Text", bSource_File, "TitleEn", true, DataSourceUpdateMode.OnValidation, "", "");

            //申請案號
            txt_ApplicationNo.DataBindings.Clear();
            txt_ApplicationNo.DataBindings.Add("Text", bSource_File, "ApplicationNo", true, DataSourceUpdateMode.OnValidation, "", "");

            //申請人
            txt_Applicant.DataBindings.Clear();
            txt_Applicant.DataBindings.Add("Text", bSource_File, "ApplicantNames", true, DataSourceUpdateMode.OnValidation, "", "");

            //發明人
            txt_Inventor.DataBindings.Clear();
            txt_Inventor.DataBindings.Add("Text", bSource_File, "Inventor", true, DataSourceUpdateMode.OnValidation, "", "");

            //種類(發明、新型、新式樣)
            txt_Kind.DataBindings.Clear();
            txt_Kind.DataBindings.Add("Text", bSource_File, "KindName", true, DataSourceUpdateMode.OnValidation, "", "");

            //性質(案件性質: 一般案、接續案)
            txt_Nature.DataBindings.Clear();
            txt_Nature.DataBindings.Add("Text", bSource_File, "FeatureName", true, DataSourceUpdateMode.OnValidation, "", "");

            //國別
            txt_Country.DataBindings.Clear();
            txt_Country.DataBindings.Add("Text", bSource_File, "Country", true, DataSourceUpdateMode.OnValidation, "", "");

            //公開號數
            txt_PubNo.DataBindings.Clear();
            txt_PubNo.DataBindings.Add("Text", bSource_File, "PubNo", true, DataSourceUpdateMode.OnValidation, "", "");

            //專利號數
            txt_CertifyNo.DataBindings.Clear();
            txt_CertifyNo.DataBindings.Add("Text", bSource_File, "CertifyNo", true, DataSourceUpdateMode.OnValidation, "", "");
            //公告號數
            txt_AllowPubNo.DataBindings.Clear();
            txt_AllowPubNo.DataBindings.Add("Text", bSource_File, "AllowPubNo", true, DataSourceUpdateMode.OnValidation, "", "");

            //年費繳至第幾年
            //txt_PayYear.DataBindings.Clear();
            //txt_PayYear.DataBindings.Add("Value", bSource_File, "PayYear", false, DataSourceUpdateMode.OnValidation, 0m);

            textBox_PayYear.DataBindings.Clear();
            textBox_PayYear.DataBindings.Add("Text", bSource_File, "PayYear", false, DataSourceUpdateMode.OnValidation);

            //txt_AddDay.DataBindings.Clear();
            //txt_AddDay.DataBindings.Add("Value", bSource_File, "AddDay", true, DataSourceUpdateMode.OnValidation);

            textBox_AddDay.DataBindings.Clear();
            textBox_AddDay.DataBindings.Add("Text", bSource_File, "AddDay", true, DataSourceUpdateMode.OnValidation);

            //引案人
            txt_Introducer.DataBindings.Clear();
            txt_Introducer.DataBindings.Add("Text", bSource_File, "Introducer", true, DataSourceUpdateMode.OnValidation);

            //備註
            txt_Remark2.DataBindings.Clear();
            txt_Remark2.DataBindings.Add("Text", bSource_File, "Remark", true, DataSourceUpdateMode.OnValidation);

            //本所承辦人
            txt_ClientWorker.DataBindings.Clear();
            txt_ClientWorker.DataBindings.Add("Text", bSource_File, "ClientWorkerName", true, DataSourceUpdateMode.OnValidation);

            //優先權
            txt_Priority.DataBindings.Clear();
            txt_Priority.DataBindings.Add("Text", bSource_File, "PriorityBaseName", true, DataSourceUpdateMode.OnValidation);

            //審查請求
            txt_ISexam.DataBindings.Clear();
            txt_ISexam.DataBindings.Add("Text", bSource_File, "ISExamName", true, DataSourceUpdateMode.OnValidation);


            //委託類型
            txt_DelegateType.DataBindings.Clear();
            txt_DelegateType.DataBindings.Add("Text", bSource_File, "DelegateTypeName", true, DataSourceUpdateMode.OnValidation);

            //委託性質
            txt_DelegateFeatureName.DataBindings.Clear();
            txt_DelegateFeatureName.DataBindings.Add("Text", bSource_File, "DelegateFeatureName", true, DataSourceUpdateMode.OnValidation);

            //主委託人
            txt_MainCustomer.DataBindings.Clear();
            txt_MainCustomer.DataBindings.Add("Text", bSource_File, "MainCustomerName", true, DataSourceUpdateMode.OnValidation);

            //主委託人--聯絡窗口
            txt_MainCustomerTransactor.DataBindings.Clear();
            txt_MainCustomerTransactor.DataBindings.Add("Text", bSource_File, "MainCustomerTransactorName", true, DataSourceUpdateMode.OnValidation);

            //主委託人--對方案號
            txt_MainCustomerRefNo.DataBindings.Clear();
            txt_MainCustomerRefNo.DataBindings.Add("Text", bSource_File, "MainCustomerRefNo", true, DataSourceUpdateMode.OnValidation);

            //承辦事務所
            txt_PatentAttorney.DataBindings.Clear();
            txt_PatentAttorney.DataBindings.Add("Text", bSource_File, "AttorneyFirm", true, DataSourceUpdateMode.OnValidation);

            //承辦事務所--對方案號
            txt_PatentAttorneyRefNo.DataBindings.Clear();
            txt_PatentAttorneyRefNo.DataBindings.Add("Text", bSource_File, "AttorneyRefNo", true, DataSourceUpdateMode.OnValidation);

            //承辦事務所--聯絡窗口
            txt_PatentAttorneyTransactor.DataBindings.Clear();
            txt_PatentAttorneyTransactor.DataBindings.Add("Text", bSource_File, "AttLiaisoner", true, DataSourceUpdateMode.OnValidation);

            //是否本所承辦案件
            chb_IsBySelf.DataBindings.Clear();
            chb_IsBySelf.DataBindings.Add("Checked", bSource_File, "IsBySelf", true, DataSourceUpdateMode.OnPropertyChanged, false);



            //引案日期
            mask_IntroductionDate.DataBindings.Clear();
            mask_IntroductionDate.DataBindings.Add("Text", bSource_File, "IntroductionDate", true, DataSourceUpdateMode.OnPropertyChanged, "    -  -", "yyyy-MM-dd");

            //最早母案申請日
            maskedTextBox_EarlyMotherDate.DataBindings.Clear();
            maskedTextBox_EarlyMotherDate.DataBindings.Add("Text", bSource_File, "EarlyMotherDate", true, DataSourceUpdateMode.OnPropertyChanged, "    -  -", "yyyy-MM-dd");

            //實際申請日
            maskedTextBox_ApplicationDate.DataBindings.Clear();
            maskedTextBox_ApplicationDate.DataBindings.Add("Text", bSource_File, "ApplicationDate", true, DataSourceUpdateMode.OnPropertyChanged, "    -  -", "yyyy-MM-dd");

            //公開日期
            maskedTextBox_Pubdate.DataBindings.Clear();
            maskedTextBox_Pubdate.DataBindings.Add("Text", bSource_File, "Pubdate", true, DataSourceUpdateMode.OnValidation, "    -  -", "yyyy-MM-dd");

            //核准日期
            maskedTextBox_AllowDate.DataBindings.Clear();
            maskedTextBox_AllowDate.DataBindings.Add("Text", bSource_File, "AllowDate", true, DataSourceUpdateMode.OnValidation, "    -  -", "yyyy-MM-dd");

            //公告日期
            maskedTextBox_AllowPubdate.DataBindings.Clear();
            maskedTextBox_AllowPubdate.DataBindings.Add("Text", bSource_File, "AllowPubdate", true, DataSourceUpdateMode.OnPropertyChanged, "    -  -", "yyyy-MM-dd");

            //收到證書日
            maskedTextBox_GetDate.DataBindings.Clear();
            maskedTextBox_GetDate.DataBindings.Add("Text", bSource_File, "GetDate", true, DataSourceUpdateMode.OnValidation, "    -  -", "yyyy-MM-dd");

            maskedTextBox_Registerdate.DataBindings.Clear();
            maskedTextBox_Registerdate.DataBindings.Add("Text", bSource_File, "Registerdate", true, DataSourceUpdateMode.OnPropertyChanged, "    -  -", "yyyy-MM-dd");

            maskedTextBox_DueDate.DataBindings.Clear();
            maskedTextBox_DueDate.DataBindings.Add("Text", bSource_File, "DueDate", true, DataSourceUpdateMode.OnPropertyChanged, "    -  -", "yyyy-MM-dd");

            maskedTextBox_RenewTo.DataBindings.Clear();
            maskedTextBox_RenewTo.DataBindings.Add("Text", bSource_File, "RenewTo", true, DataSourceUpdateMode.OnPropertyChanged, "    -  -", "yyyy-MM-dd");

            maskedTextBox_CloseDate.DataBindings.Clear();
            maskedTextBox_CloseDate.DataBindings.Add("Text", bSource_File, "CloseDate", true, DataSourceUpdateMode.OnPropertyChanged, "    -  -", "yyyy-MM-dd");
            
            //最早優先申請日
            maskedTextBox_EarlyPriorityDate.DataBindings.Clear();
            maskedTextBox_EarlyPriorityDate.DataBindings.Add("Text", bSource_File, "EarlyPriorityDate", true, DataSourceUpdateMode.OnPropertyChanged, "    -  -", "yyyy-MM-dd");

            //優先權申請號
            txt_EarlyPriorityNo.DataBindings.Clear();
            txt_EarlyPriorityNo.DataBindings.Add("Text", bSource_File, "EarlyPriorityNo", true, DataSourceUpdateMode.OnValidation);

            //案件階段
            txt_StatusName.DataBindings.Clear();
            txt_StatusName.DataBindings.Add("Text", bSource_File, "StatusName", true, DataSourceUpdateMode.OnValidation);

            //階段描述
            txt_StatusExplain.DataBindings.Clear();
            txt_StatusExplain.DataBindings.Add("Text", bSource_File, "StatusExplain", true, DataSourceUpdateMode.OnValidation);

            //結案原因
            txt_CloseCaus.DataBindings.Clear();
            txt_CloseCaus.DataBindings.Add("Text", bSource_File, "CloseCaus", true, DataSourceUpdateMode.OnValidation);

            //結案原因
            txt_ECode.DataBindings.Clear();
            txt_ECode.DataBindings.Add("Text", bSource_File, "ECode", true, DataSourceUpdateMode.OnValidation);
        }
        #endregion

        #region ControlBindingPatComit
        public void ControlBindingPatComit()
        {
            txt_ComitEventContent.DataBindings.Clear();
            txt_ComitEventContent.DataBindings.Add("Text", patComitEventTBindingSource, "EventContent", true, DataSourceUpdateMode.OnPropertyChanged, "", "");

            txt_WorkerKey.DataBindings.Clear();
            txt_WorkerKey.DataBindings.Add("Text", patComitEventTBindingSource, "EmployeeName", true, DataSourceUpdateMode.OnPropertyChanged, "", "");

            maskedTextBox_OccurDate.DataBindings.Clear();
            maskedTextBox_OccurDate.DataBindings.Add("Text", patComitEventTBindingSource, "OccurDate", true, DataSourceUpdateMode.OnPropertyChanged, "    -  -", "yyyy-MM-dd");

            maskedTextBox_OfficerDate.DataBindings.Clear();
            maskedTextBox_OfficerDate.DataBindings.Add("Text", patComitEventTBindingSource, "OfficerDate", true, DataSourceUpdateMode.OnPropertyChanged, "    -  -", "yyyy-MM-dd");

            maskedTextBox_ComitDueDate.DataBindings.Clear();
            maskedTextBox_ComitDueDate.DataBindings.Add("Text", patComitEventTBindingSource, "DueDate", true, DataSourceUpdateMode.OnPropertyChanged, "    -  -", "yyyy-MM-dd");

            maskedTextBox_OfficeDueDate.DataBindings.Clear();
            maskedTextBox_OfficeDueDate.DataBindings.Add("Text", patComitEventTBindingSource, "OfficeDueDate", true, DataSourceUpdateMode.OnPropertyChanged, "    -  -", "yyyy-MM-dd");

            maskedTextBox_StartDate.DataBindings.Clear();
            maskedTextBox_StartDate.DataBindings.Add("Text", patComitEventTBindingSource, "StartDate", true, DataSourceUpdateMode.OnPropertyChanged, "    -  -", "yyyy-MM-dd");

            maskedTextBox_ComitDate.DataBindings.Clear();
            maskedTextBox_ComitDate.DataBindings.Add("Text", patComitEventTBindingSource, "ComitDate", true, DataSourceUpdateMode.OnPropertyChanged, "    -  -", "yyyy-MM-dd");

            maskedTextBox_FinishDate.DataBindings.Clear();
            maskedTextBox_FinishDate.DataBindings.Add("Text", patComitEventTBindingSource, "FinishDate", true, DataSourceUpdateMode.OnPropertyChanged, "    -  -", "yyyy-MM-dd");

            maskedTextBox_CreateDate.DataBindings.Clear();
            maskedTextBox_CreateDate.DataBindings.Add("Text", patComitEventTBindingSource, "CreateDate", true, DataSourceUpdateMode.OnPropertyChanged, "    -  -", "yyyy-MM-dd");

            txt_eRemark.DataBindings.Clear();
            txt_eRemark.DataBindings.Add("Text", patComitEventTBindingSource, "Remark", true, DataSourceUpdateMode.OnPropertyChanged, "", "");

            txt_ComitResult.DataBindings.Clear();
            txt_ComitResult.DataBindings.Add("Text", patComitEventTBindingSource, "Result", true, DataSourceUpdateMode.OnPropertyChanged, "", "");

        }
        #endregion

        #region ControlBindingTMFee
        public void ControlBindingTMFee()
        {

            txt_FeeSubject.DataBindings.Clear();
            txt_FeeSubject.DataBindings.Add("Text", patentFeeTBindingSource, "FeeSubject", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_FeePhase.DataBindings.Clear();
            txt_FeePhase.DataBindings.Add("Text", patentFeeTBindingSource, "FeePhase", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_AttorneyName.DataBindings.Clear();
            txt_AttorneyName.DataBindings.Add("Text", patentFeeTBindingSource, "AttorneyFirm", true, DataSourceUpdateMode.OnValidation, "", "");

            txtTotall.DataBindings.Clear();
            txtTotall.DataBindings.Add("Text", patentFeeTBindingSource, "Totall", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");

            txtAttorneyFee2.DataBindings.Clear();
            txtAttorneyFee2.DataBindings.Add("Text", patentFeeTBindingSource, "OAttorneyFee", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");

            txtAttorneyFee3.DataBindings.Clear();
            txtAttorneyFee3.DataBindings.Add("Text", patentFeeTBindingSource, "OthFee", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");

            txtAttorneyFee4.DataBindings.Clear();
            txtAttorneyFee4.DataBindings.Add("Text", patentFeeTBindingSource, "GovFee", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");

            txt_IMoney.DataBindings.Clear();
            txt_IMoney.DataBindings.Add("Text", patentFeeTBindingSource, "TMoney", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_OMoney.DataBindings.Clear();
            txt_OMoney.DataBindings.Add("Text", patentFeeTBindingSource, "OMoney", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_OMoney1.DataBindings.Clear();
            txt_OMoney1.DataBindings.Add("Text", patentFeeTBindingSource, "OthMoney", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_GMoney.DataBindings.Clear();
            txt_GMoney.DataBindings.Add("Text", patentFeeTBindingSource, "GMoney", true, DataSourceUpdateMode.OnValidation, "", "");

            txtMoney1.DataBindings.Clear();
            txtMoney1.DataBindings.Add("Text", patentFeeTBindingSource, "TtoNT", true, DataSourceUpdateMode.OnValidation, "", "#,##0.####");

            txtMoney2.DataBindings.Clear();
            txtMoney2.DataBindings.Add("Text", patentFeeTBindingSource, "OtoNT", true, DataSourceUpdateMode.OnValidation, "", "#,##0.####");

            txtMoney21.DataBindings.Clear();
            txtMoney21.DataBindings.Add("Text", patentFeeTBindingSource, "OthtoNT", true, DataSourceUpdateMode.OnValidation, "", "#,##0.####");

            txtMoney3.DataBindings.Clear();
            txtMoney3.DataBindings.Add("Text", patentFeeTBindingSource, "GtoNT", true, DataSourceUpdateMode.OnValidation, "", "#,##0.####");

            txtAttorneyFeeTotal1.DataBindings.Clear();
            txtAttorneyFeeTotal1.DataBindings.Add("Text", patentFeeTBindingSource, "TotalNT", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");

            txtAttorneyFeeTotal2.DataBindings.Clear();
            txtAttorneyFeeTotal2.DataBindings.Add("Text", patentFeeTBindingSource, "OTotall", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");

            txtAttorneyFeeTotal3.DataBindings.Clear();
            txtAttorneyFeeTotal3.DataBindings.Add("Text", patentFeeTBindingSource, "OthTotal", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");

            txtAttorneyFeeTotal4.DataBindings.Clear();
            txtAttorneyFeeTotal4.DataBindings.Add("Text", patentFeeTBindingSource, "GTotall", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");

            checkBox_Pay.DataBindings.Clear();
            checkBox_Pay.DataBindings.Add("Checked", patentFeeTBindingSource, "Pay", true, DataSourceUpdateMode.OnValidation, false);

            checkBox_NT.DataBindings.Clear();
            checkBox_NT.DataBindings.Add("Checked", patentFeeTBindingSource, "NT", true, DataSourceUpdateMode.OnValidation, false);

            chkWithholding.DataBindings.Clear();
            chkWithholding.DataBindings.Add("Checked", patentFeeTBindingSource, "Withholding", true, DataSourceUpdateMode.OnValidation, false);

            txt_Tax.DataBindings.Clear();
            txt_Tax.DataBindings.Add("Text", patentFeeTBindingSource, "Tax", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");

            txtOAttorneyGovFee.DataBindings.Clear();
            txtOAttorneyGovFee.DataBindings.Add("Text", patentFeeTBindingSource, "OAttorneyGovFee", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");

            txt_OtherTotalFee.DataBindings.Clear();
            txt_OtherTotalFee.DataBindings.Add("Text", patentFeeTBindingSource, "OtherTotalFee", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");

            txtTotall.DataBindings.Clear();
            txtTotall.DataBindings.Add("Text", patentFeeTBindingSource, "Totall", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");

            txtPracicalityPay.DataBindings.Clear();
            txtPracicalityPay.DataBindings.Add("Text", patentFeeTBindingSource, "PracticalityPay", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");

            txt_PayKind.DataBindings.Clear();
            txt_PayKind.DataBindings.Add("Text", patentFeeTBindingSource, "PayKind", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_PayMemo.DataBindings.Clear();
            txt_PayMemo.DataBindings.Add("Text", patentFeeTBindingSource, "PayMemo", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_Remark.DataBindings.Clear();
            txt_Remark.DataBindings.Add("Text", patentFeeTBindingSource, "Remark", true, DataSourceUpdateMode.OnValidation, "", "");

            //請款單號
            txt_PPP.DataBindings.Clear();
            txt_PPP.DataBindings.Add("Text", patentFeeTBindingSource, "PPP", true, DataSourceUpdateMode.OnValidation, "", "");

            //請款人
            txt_FeeWorkerName.DataBindings.Clear();
            txt_FeeWorkerName.DataBindings.Add("Text", patentFeeTBindingSource, "EmployeeName", true, DataSourceUpdateMode.OnValidation, "", "");

            //請款日期
            maskedTextBox_RDate.DataBindings.Clear();
            maskedTextBox_RDate.DataBindings.Add("Text", patentFeeTBindingSource, "RDate", true, DataSourceUpdateMode.OnPropertyChanged, "    -  -", "yyyy-MM-dd");

            //收款期限
            maskedTextBox_CollectionPeriod.DataBindings.Clear();
            maskedTextBox_CollectionPeriod.DataBindings.Add("Text", patentFeeTBindingSource, "CollectionPeriod", true, DataSourceUpdateMode.OnPropertyChanged, "    -  -", "yyyy-MM-dd");

            //收款日期
            maskedTextBox_PayDate.DataBindings.Clear();
            maskedTextBox_PayDate.DataBindings.Add("Text", patentFeeTBindingSource, "PayDate", true, DataSourceUpdateMode.OnPropertyChanged, "    -  -", "yyyy-MM-dd");

            //收據日期
            maskedTextBox_ReceiptDate.DataBindings.Clear();
            maskedTextBox_ReceiptDate.DataBindings.Add("Text", patentFeeTBindingSource, "ReceiptDate", true, DataSourceUpdateMode.OnPropertyChanged, "    -  -", "yyyy-MM-dd");

            // 發票日期
            maskedTextBox_aBillDate.DataBindings.Clear();
            maskedTextBox_aBillDate.DataBindings.Add("Text", patentFeeTBindingSource, "aBillDate", true, DataSourceUpdateMode.OnPropertyChanged, "    -  -", "yyyy-MM-dd");

            //發票號碼
            txt_aBill.DataBindings.Clear();
            txt_aBill.DataBindings.Add("Text", patentFeeTBindingSource, "aBill", true, DataSourceUpdateMode.OnValidation, "", "");

            //簽核
            txt_SingCode.DataBindings.Clear();
            txt_SingCode.DataBindings.Add("Text", patentFeeTBindingSource, "SingCode", true, DataSourceUpdateMode.OnPropertyChanged, "", "");

            txt_FeeEventNumber.DataBindings.Clear();
            txt_FeeEventNumber.DataBindings.Add("Text", patentFeeTBindingSource, "PatComitEventID", true, DataSourceUpdateMode.OnPropertyChanged, "", "PE#");

            txt_OthFeeName.DataBindings.Clear();
            txt_OthFeeName.DataBindings.Add("Text", patentFeeTBindingSource, "OthFeeName", true, DataSourceUpdateMode.OnPropertyChanged, "", "");

            txt_CustomizeName.DataBindings.Clear();
            txt_CustomizeName.DataBindings.Add("Text", patentFeeTBindingSource, "CustomizeName", true, DataSourceUpdateMode.OnPropertyChanged, "", "");

            txt_CustomizeOthFee.DataBindings.Clear();
            txt_CustomizeOthFee.DataBindings.Add("Text", patentFeeTBindingSource, "CustomizeOthFee", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");

            txt_CustomizeMoney.DataBindings.Clear();
            txt_CustomizeMoney.DataBindings.Add("Text", patentFeeTBindingSource, "CustomizeMoney", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_CustomizeNT.DataBindings.Clear();
            txt_CustomizeNT.DataBindings.Add("Text", patentFeeTBindingSource, "CustomizeNT", true, DataSourceUpdateMode.OnValidation, "", "#,##0.####");

            txt_CustomizeTotal.DataBindings.Clear();
            txt_CustomizeTotal.DataBindings.Add("Text", patentFeeTBindingSource, "CustomizeTotal", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");

            txt_OtherTotalFeeCustomize1Name.DataBindings.Clear();
            txt_OtherTotalFeeCustomize1Name.DataBindings.Add("Text", patentFeeTBindingSource, "OtherTotalFeeCustomize1Name", true, DataSourceUpdateMode.OnPropertyChanged, "", "");

            txt_OtherTotalFeeCustomize2Name.DataBindings.Clear();
            txt_OtherTotalFeeCustomize2Name.DataBindings.Add("Text", patentFeeTBindingSource, "OtherTotalFeeCustomize2Name", true, DataSourceUpdateMode.OnPropertyChanged, "", "");

            txt_OtherTotalFeeCustomize3Name.DataBindings.Clear();
            txt_OtherTotalFeeCustomize3Name.DataBindings.Add("Text", patentFeeTBindingSource, "OtherTotalFeeCustomize3Name", true, DataSourceUpdateMode.OnPropertyChanged, "", "");

            txt_OtherTotalFeeCustomize1.DataBindings.Clear();
            txt_OtherTotalFeeCustomize1.DataBindings.Add("Text", patentFeeTBindingSource, "OtherTotalFeeCustomize1", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");

            txt_OtherTotalFeeCustomize2.DataBindings.Clear();
            txt_OtherTotalFeeCustomize2.DataBindings.Add("Text", patentFeeTBindingSource, "OtherTotalFeeCustomize2", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");

            txt_OtherTotalFeeCustomize3.DataBindings.Clear();
            txt_OtherTotalFeeCustomize3.DataBindings.Add("Text", patentFeeTBindingSource, "OtherTotalFeeCustomize3", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");

            txt_OtherTotalFeeInSide.DataBindings.Clear();
            txt_OtherTotalFeeInSide.DataBindings.Add("Text", patentFeeTBindingSource, "OtherTotalFeeInSide", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");

            txt_TaxPercent.DataBindings.Clear();
            txt_TaxPercent.DataBindings.Add("Text", patentFeeTBindingSource, "TaxPercent", true, DataSourceUpdateMode.OnValidation, "", "#,##0");

            txt_OtherTotalFeeInSideTax.DataBindings.Clear();
            txt_OtherTotalFeeInSideTax.DataBindings.Add("Text", patentFeeTBindingSource, "OtherTotalFeeInSideTax", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");
        }

        #endregion

        #region ControlBindingTMPayment
        public void ControlBindingTMPayment()
        {
            txt_PayFeeSubject.DataBindings.Clear();
            txt_PayFeeSubject.DataBindings.Add("Text", patentPaymentTBindingSource, "FeeSubject", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_PayFeePhase.DataBindings.Clear();
            txt_PayFeePhase.DataBindings.Add("Text", patentPaymentTBindingSource, "FeePhase", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_FClientTransactor.DataBindings.Clear();
            txt_FClientTransactor.DataBindings.Add("Text", patentPaymentTBindingSource, "EmployeeName", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_Attorney.DataBindings.Clear();
            txt_Attorney.DataBindings.Add("Text", patentPaymentTBindingSource, "AttorneyFirm", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_PayPayKind.DataBindings.Clear();
            txt_PayPayKind.DataBindings.Add("Text", patentPaymentTBindingSource, "PayKind", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_PayIMoney.DataBindings.Clear();
            txt_PayIMoney.DataBindings.Add("Text", patentPaymentTBindingSource, "IMoney", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_IServiceFee.DataBindings.Clear();
            txt_IServiceFee.DataBindings.Add("Text", patentPaymentTBindingSource, "IServiceFee", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");

            txt_GovFee.DataBindings.Clear();
            txt_GovFee.DataBindings.Add("Text", patentPaymentTBindingSource, "GovFee", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");

            txt_OtherFee.DataBindings.Clear();
            txt_OtherFee.DataBindings.Add("Text", patentPaymentTBindingSource, "OtherFee", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");

            //單據號碼
            txt_IReceiptNo.DataBindings.Clear();
            txt_IReceiptNo.DataBindings.Add("Text", patentPaymentTBindingSource, "IReceiptNo", true, DataSourceUpdateMode.OnValidation, "", "");

           

            txt_PayTotall.DataBindings.Clear();
            txt_PayTotall.DataBindings.Add("Text", patentPaymentTBindingSource, "Totall", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");

            txt_PayRemark.DataBindings.Clear();
            txt_PayRemark.DataBindings.Add("Text", patentPaymentTBindingSource, "Remark", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_Memo.DataBindings.Clear();
            txt_Memo.DataBindings.Add("Text", patentPaymentTBindingSource, "Memo", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_BillCheck.DataBindings.Clear();
            txt_BillCheck.DataBindings.Add("Text", patentPaymentTBindingSource, "BillCheck", true, DataSourceUpdateMode.OnValidation, "", "");

            //收件日期
            maskedTextBox_ReciveDate.DataBindings.Clear();
            maskedTextBox_ReciveDate.DataBindings.Add("Text", patentPaymentTBindingSource, "ReciveDate", true, DataSourceUpdateMode.OnPropertyChanged, "    -  -", "yyyy-MM-dd");

            //付款期限
            maskedTextBox_PayDueDate.DataBindings.Clear();
            maskedTextBox_PayDueDate.DataBindings.Add("Text", patentPaymentTBindingSource, "PayDueDate", true, DataSourceUpdateMode.OnPropertyChanged, "    -  -", "yyyy-MM-dd");

            //付款日期
            maskedTextBox_PaymentDate.DataBindings.Clear();
            maskedTextBox_PaymentDate.DataBindings.Add("Text", patentPaymentTBindingSource, "PaymentDate", true, DataSourceUpdateMode.OnPropertyChanged, "    -  -", "yyyy-MM-dd");

            //完成日期
            maskedTextBox_IReceiptDate.DataBindings.Clear();
            maskedTextBox_IReceiptDate.DataBindings.Add("Text", patentPaymentTBindingSource, "IReceiptDate", true, DataSourceUpdateMode.OnPropertyChanged, "    -  -", "yyyy-MM-dd");
            
            checkBox_IsBilling.DataBindings.Clear();
            checkBox_IsBilling.DataBindings.Add("Checked", patentPaymentTBindingSource, "IsBilling", true, DataSourceUpdateMode.OnValidation, false);

            txt_BillingNo.DataBindings.Clear();
            txt_BillingNo.DataBindings.Add("Text", patentPaymentTBindingSource, "BillingNo", true, DataSourceUpdateMode.OnValidation, "", "");

            //匯率
            txt_ExchangeRate.DataBindings.Clear();
            txt_ExchangeRate.DataBindings.Add("Text", patentPaymentTBindingSource, "ExchangeRate", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");

            //實付金額
            txt_ActuallyPay.DataBindings.Clear();
            txt_ActuallyPay.DataBindings.Add("Text", patentPaymentTBindingSource, "ActuallyPay", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");

            checkBox_IsCopyFile.DataBindings.Clear();
            checkBox_IsCopyFile.DataBindings.Add("Checked", patentPaymentTBindingSource, "IsCopyFile", true, DataSourceUpdateMode.OnValidation, false);

            checkBox_IsScan.DataBindings.Clear();
            checkBox_IsScan.DataBindings.Add("Checked", patentPaymentTBindingSource, "IsScan", true, DataSourceUpdateMode.OnValidation, false);

            //主管簽核
            txt_PaySingCode.DataBindings.Clear();
            txt_PaySingCode.DataBindings.Add("Text", patentPaymentTBindingSource, "SingCode", true, DataSourceUpdateMode.OnValidation, "", "");
        }

        #endregion           

        #region ControlBindingTMEstimateCost
        public void ControlBindingTMEstimateCost()
        {
            txt_ES_FeeSubject.DataBindings.Clear();
            txt_ES_FeeSubject.DataBindings.Add("Text", patentEstimateCostTBindingSource, "FeeSubject", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_ES_IAttorneyFee.DataBindings.Clear();
            txt_ES_IAttorneyFee.DataBindings.Add("Text", patentEstimateCostTBindingSource, "IAttorneyFee", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");

            txt_ES_OAttorneyFee.DataBindings.Clear();
            txt_ES_OAttorneyFee.DataBindings.Add("Text", patentEstimateCostTBindingSource, "OAttorneyFee", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");

            txt_ES_OMoney.DataBindings.Clear();
            txt_ES_OMoney.DataBindings.Add("Text", patentEstimateCostTBindingSource, "OMoney", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_ES_OtoNT.DataBindings.Clear();
            txt_ES_OtoNT.DataBindings.Add("Text", patentEstimateCostTBindingSource, "OtoNT", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");

            txt_ES_OTotall.DataBindings.Clear();
            txt_ES_OTotall.DataBindings.Add("Text", patentEstimateCostTBindingSource, "OTotall", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");

            txt_ES_GovFee.DataBindings.Clear();
            txt_ES_GovFee.DataBindings.Add("Text", patentEstimateCostTBindingSource, "GovFee", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");

            txt_ES_OtherFee.DataBindings.Clear();
            txt_ES_OtherFee.DataBindings.Add("Text", patentEstimateCostTBindingSource, "OtherFee", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");

            txt_ES_IMoney.DataBindings.Clear();
            txt_ES_IMoney.DataBindings.Add("Text", patentEstimateCostTBindingSource, "IMoney", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_ES_OtherMoney.DataBindings.Clear();
            txt_ES_OtherMoney.DataBindings.Add("Text", patentEstimateCostTBindingSource, "OtherMoney", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_ES_GMoney.DataBindings.Clear();
            txt_ES_GMoney.DataBindings.Add("Text", patentEstimateCostTBindingSource, "GMoney", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_ES_ItoNT.DataBindings.Clear();
            txt_ES_ItoNT.DataBindings.Add("Text", patentEstimateCostTBindingSource, "ItoNT", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");

            txt_ES_ITotall.DataBindings.Clear();
            txt_ES_ITotall.DataBindings.Add("Text", patentEstimateCostTBindingSource, "ITotall", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");

            txt_ES_GtoNT.DataBindings.Clear();
            txt_ES_GtoNT.DataBindings.Add("Text", patentEstimateCostTBindingSource, "GtoNT", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");

            txt_ES_GTotall.DataBindings.Clear();
            txt_ES_GTotall.DataBindings.Add("Text", patentEstimateCostTBindingSource, "GTotall", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");

            txt_ES_OtherNT.DataBindings.Clear();
            txt_ES_OtherNT.DataBindings.Add("Text", patentEstimateCostTBindingSource, "OtherNT", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");

            txt_ES_OtherTotal.DataBindings.Clear();
            txt_ES_OtherTotal.DataBindings.Add("Text", patentEstimateCostTBindingSource, "OtherTotal", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");

            txt_EstimateProfit.DataBindings.Clear();
            txt_EstimateProfit.DataBindings.Add("Text", patentEstimateCostTBindingSource, "EstimateProfit", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");

            txt_EstimateCost.DataBindings.Clear();
            txt_EstimateCost.DataBindings.Add("Text", patentEstimateCostTBindingSource, "EstimateCost", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");

            txt_RealPrice.DataBindings.Clear();
            txt_RealPrice.DataBindings.Add("Text", patentEstimateCostTBindingSource, "RealPrice", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");

            txt_ES_PayMemo.DataBindings.Clear();
            txt_ES_PayMemo.DataBindings.Add("Text", patentEstimateCostTBindingSource, "PayMemo", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_ES_Remark.DataBindings.Clear();
            txt_ES_Remark.DataBindings.Add("Text", patentEstimateCostTBindingSource, "Remark", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_ServicePrice.DataBindings.Clear();
            txt_ServicePrice.DataBindings.Add("Text", patentEstimateCostTBindingSource, "ServicePrice", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");


        }

        #endregion

        #endregion

        #region =============linkLabel===============
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LinkLabel link = (LinkLabel)sender;
            US.PopMemo pop;
            switch (link.Name)
            {
                case "linkLabel_CloseCaus":
                    pop = new LawtechPTSystem.US.PopMemo(txt_CloseCaus, true, link.Text);
                    break;
                case "linkLabel_mome":
                    pop = new LawtechPTSystem.US.PopMemo(txt_Remark2, true, link.Text);
                    break;
                case "linkLabel_ComitResult":
                    pop = new LawtechPTSystem.US.PopMemo(txt_ComitResult, true, link.Text);
                    break;
                case "linkLabel_eRemark":
                    pop = new LawtechPTSystem.US.PopMemo(txt_eRemark, true, link.Text);
                    break;
                case "linkLabel_FeeSubject":
                    pop = new LawtechPTSystem.US.PopMemo(txt_FeeSubject, true, link.Text);
                    break;
                case "linkLabel_MainCustomer":
                    pop = new LawtechPTSystem.US.PopMemo(txt_MainCustomer, true, link.Text);
                    break;
                case "linkLabel_PatentAttorney":
                    pop = new LawtechPTSystem.US.PopMemo(txt_PatentAttorney, true, link.Text);
                    break;
                case "linkLabel_PayMemo":
                    pop = new LawtechPTSystem.US.PopMemo(txt_PayMemo, true, link.Text);
                    break;
                case "linkLabel_Remark":
                    pop = new LawtechPTSystem.US.PopMemo(txt_Remark, true, link.Text);
                    break;
                case "linkLabel_PayRemark":
                    pop = new LawtechPTSystem.US.PopMemo(txt_PayRemark, true, link.Text);
                    break;
              
                case "linkLabel_Memo":
                    pop = new LawtechPTSystem.US.PopMemo(txt_Memo, true, link.Text);
                    break;
                case "linkLabel_ES_PayMemo":
                    pop = new LawtechPTSystem.US.PopMemo(txt_ES_PayMemo, true, link.Text);
                    break;
                case "linkLabel_ES_Remark":
                    pop = new LawtechPTSystem.US.PopMemo(txt_ES_Remark, true, link.Text);                    
                    break;
                case "linkLabel_Inventor":
                    pop = new LawtechPTSystem.US.PopMemo(txt_Inventor, true, link.Text);
                    break;
                case "linkLabel_EarlyPriorityNo":
                    pop = new LawtechPTSystem.US.PopMemo(txt_EarlyPriorityNo, true, link.Text);
                    break;
                case "linkLabel_PayKind":
                    pop = new LawtechPTSystem.US.PopMemo(txt_PayKind, true, link.Text);
                    break;
                default:
                    pop = new LawtechPTSystem.US.PopMemo(txt_FileNo, true, link.Text);
                    break;
            }

            pop.Show();
        }

        #endregion

        private void toolStripButton_ExcelEvent_Click(object sender, EventArgs e)
        {
            try
            {
                Public.DLL dll = new Public.DLL();
                Task task = dll.WriteToCSV(GridView_PatComit);
            }
            catch
            {
                MessageBox.Show("匯出CSV失敗");
            }
        }

        private void toolStripButton_ExcelFee_Click(object sender, EventArgs e)
        {
            try
            {
                Public.DLL dll = new Public.DLL();
                Task task = dll.WriteToCSV(GridView_Fee);
            }
            catch
            {
                MessageBox.Show("匯出CSV失敗");
            }
        }

        private void toolStripButton_ExcelPayment_Click(object sender, EventArgs e)
        {
            try
            {
                Public.DLL dll = new Public.DLL();
                Task task = dll.WriteToCSV(dataGridView_Billing);
            }
            catch
            {
                MessageBox.Show("匯出CSV失敗");
            }
        }

        private void txt_PatentNo_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_PatentNo.Text))
            {
                this.Text += string.Format("({0})", txt_PatentNo.Text);
            }
        }
        
    }
}
