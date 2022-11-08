using System;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;
using H3Operator.DBHelper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LawtechPTSystem.SubFrom
{
    /// <summary>
    /// 商標案基本資料管理
    /// </summary>
    public partial class TrademarkMF : Form
    {
        UserPermissionForm myPermission;
        private const string ProgramSymbol = "TrademarkMF";
        private const string SourceTableName = "TrademarkManagementT";

        public TrademarkMF()
        {
            InitializeComponent();

            trademarkManagementTDataGridView.AutoGenerateColumns = false;

            TMNotifyEventTDataGridView.AutoGenerateColumns = false;
            GridView_Fee.AutoGenerateColumns = false;
            dataGridView_Billing.AutoGenerateColumns = false;
            dataGridView_EstimateCost.AutoGenerateColumns = false;
            dataGridView_TrademarkAnnuity.AutoGenerateColumns = false;
            dataGridView_AnnuityClass.AutoGenerateColumns = false;
            dataGridView_AnnuityHolder.AutoGenerateColumns = false;
            dataGridView_AnnuityImage.AutoGenerateColumns = false;

            Public.DynamicGridViewColumn.GetGridColum(ref trademarkManagementTDataGridView);
            Public.DynamicGridViewColumn.GetGridColum(ref TMNotifyEventTDataGridView);
            Public.DynamicGridViewColumn.GetGridColum(ref GridView_Fee);
            Public.DynamicGridViewColumn.GetGridColum(ref dataGridView_Billing);
            Public.DynamicGridViewColumn.GetGridColum(ref dataGridView_EstimateCost);
            Public.DynamicGridViewColumn.GetGridColum(ref dataGridView_TrademarkAnnuity);
            Public.DynamicGridViewColumn.GetGridColum(ref dataGridView_AnnuityClass);
            Public.DynamicGridViewColumn.GetGridColum(ref dataGridView_AnnuityHolder);
            Public.DynamicGridViewColumn.GetGridColum(ref dataGridView_AnnuityImage);
        }

        #region ================資料集================
        private DataTable DT_TrademarkList = new DataTable();
        /// <summary>
        /// TrademarkManagement 資料集
        /// </summary>
        public DataTable dt_TrademarkManagementT
        {
            get
            {
                return DT_TrademarkList;
            }

        }

        private DataTable DT_TrademarkNotifyEventT = new DataTable();
        /// <summary>
        /// TrademarkNotifyEventT  事件記錄
        /// </summary>
        public DataTable dt_TrademarkNotifyEventT
        {
            get
            {
                return DT_TrademarkNotifyEventT;
            }

        }

        private DataTable DT_TrademarkFeeT = new DataTable();
        /// <summary>
        /// TrademarkFeeT 請款費用
        /// </summary>
        public DataTable dt_TrademarkFeeT
        {
            get
            {
                return DT_TrademarkFeeT;
            }

        }

        private DataTable DT_TrademarkPaymentT = new DataTable();
        /// <summary>
        /// TrademarkPaymentT 付款費用
        /// </summary>
        public DataTable dt_TrademarkPaymentT
        {
            get
            {
                return DT_TrademarkPaymentT;
            }

        }

        private DataTable DT_TrademarkEstimateCostT = new DataTable();
        /// <summary>
        /// TrademarkPaymentT 付款費用
        /// </summary>
        public DataTable dt_TrademarkEstimateCostT
        {
            get
            {
                return DT_TrademarkEstimateCostT;
            }

        }

        private DataSet ds_TrademarkAnnuityT = new DataSet();
        /// <summary>
        /// 商標權狀態異動資料 TmarkRights
        /// </summary>
        public DataSet DS_TrademarkAnnuityT
        {
            get
            {
                return ds_TrademarkAnnuityT;
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
                    this.dt_TrademarkManagementT.Rows.Clear();

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

        #region ==========Property==========
        /// <summary>
        /// TrademarkID
        /// </summary>
        public int property_TrademarkID
        {
            get
            {
                if (trademarkManagementTDataGridView.CurrentRow != null)
                {
                    return (int)trademarkManagementTDataGridView.CurrentRow.Cells["TrademarkID"].Value;
                }
                else
                {
                    return -1;
                }
            }
        }

        private int iWorkerID = -1;
        /// <summary>
        /// 登入者ID
        /// </summary>
        public int WorkerID
        {
            get { return iWorkerID; }
            set { iWorkerID = value; }
        }

        string strTMrootPath = "";
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

        private string pictureBoxPath = "";
        public string property_TMPicturePath
        {
            get
            {
                return pictureBoxPath;
            }
            set
            {
                pictureBoxPath = value;
            }
        }

        private string iMultipleKeyByCopy = "";
        /// <summary>
        /// 複製用的字串，用來記錄Key值
        /// </summary>
        public string MultipleKeyByCopy
        {
            get { return iMultipleKeyByCopy; }
            set { iMultipleKeyByCopy = value; }
        }

        #endregion

        #region =================TrademarkMF_Load  TrademarkMF_FormClosed======================
        private void TrademarkMF_Load(object sender, EventArgs e)
        {
            Public.PublicForm Forms = new Public.PublicForm();
            Forms.TrademarkMF = this;

            Public.DLL dll = new Public.DLL();
            property_TMrootPath = dll.TrademarkFolderRoot;

            //取得登入者Key
            iWorkerID = Properties.Settings.Default.WorkerKEY;

            //取得權限
            myPermission = new UserPermissionForm(Properties.Settings.Default.WorkerKEY, ProgramSymbol);

            System.Windows.Forms.BindingNavigator[] listbinding = { bindingNavigator_TM, bindingNavigator_Notify, bindingNavigator_EstimateCost, bindingNavigator_Fee, bindingNavigator_Payment };
            System.Windows.Forms.ContextMenuStrip[] listtMenu = { contextMenuStrip_Trademark, contextMenuStrip_Event1, contextMenuStrip_Fee, contextMenuStrip_Billing, contextMenuStrip_EstimateCost };

            //確認可使用的功能選單
            Public.CommonFunctions.CheckMeunItemVisible(listbinding, myPermission.UserPermission);
            Public.CommonFunctions.CheckMeunItemVisible(listtMenu, myPermission.UserPermission);

            SetBindingSource();

            TabTrademarkBinding();
            ControlBindingTMNotify();
            ControlBindingTMFee();
            ControlBindingTMPayment();
            ControlBindingTMEstimateCost();

            // but_ShowDetail_Click(null,null);
            Public.Utility.SetLoadDataRange(userControlFilterDate1);

            if (Properties.Settings.Default.IsLoadData)
            {
                but_Search_Click(null, null);
            }

            this.trademarkManagementTDataGridView.SelectionChanged += new System.EventHandler(this.trademarkManagementTDataGridView_SelectionChanged);
            trademarkManagementTDataGridView_SelectionChanged(null, null);
        }

        private void TrademarkMF_FormClosed(object sender, FormClosedEventArgs e)
        {
            Public.PublicForm Forms = new Public.PublicForm();

            Forms.TrademarkMF = null;
        }
        #endregion

        #region 設定BindingSource的來源 private void SetBindingSource()
        /// <summary>
        /// 設定BindingSource的來源
        /// </summary>
        private void SetBindingSource()
        {
            if (dt_TrademarkManagementT.Columns.Count == 0)
            {
                Public.CTrademarkPublicFunction.GetTrademarkList("1=0", ref DT_TrademarkList);
            }
            trademarkManagementTBindingSource.DataSource = dt_TrademarkManagementT;

            if (DT_TrademarkNotifyEventT.Columns.Count == 0)
            {
                Public.CTrademarkPublicFunction.GetTrademarkEvent("0", ref DT_TrademarkNotifyEventT);
            }
            trademarkNotifyEventTBindingSource.DataSource = DT_TrademarkNotifyEventT;

            if (DT_TrademarkEstimateCostT.Columns.Count == 0)
            {
                Public.CTrademarkPublicFunction.GetTrademarkEstimateCost("0", ref DT_TrademarkEstimateCostT);
            }
            trademarkEstimateCostTBindingSource.DataSource = DT_TrademarkEstimateCostT;

            if (DT_TrademarkFeeT.Columns.Count == 0)
            {
                Public.CTrademarkPublicFunction.GetTrademarkFee("0", ref DT_TrademarkFeeT);
            }
            trademarkFeeTBindingSource.DataSource = DT_TrademarkFeeT;

            if (DT_TrademarkPaymentT.Columns.Count == 0)
            {
                Public.CTrademarkPublicFunction.GetTrademarkPayment("0", ref DT_TrademarkPaymentT);
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

            txt_StyleName.Clear();
            txt_StyleName.DataBindings.Add("Text", trademarkManagementTBindingSource, "StyleName", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_TMStyleModelName.Clear();
            txt_TMStyleModelName.DataBindings.Add("Text", trademarkManagementTBindingSource, "TMStyleModelName", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_OutsourcingTrademarkNo.DataBindings.Clear();
            txt_OutsourcingTrademarkNo.DataBindings.Add("Text", trademarkManagementTBindingSource, "OutsourcingTrademarkNo", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_ApplicationNo.DataBindings.Clear();
            txt_ApplicationNo.DataBindings.Add("Text", trademarkManagementTBindingSource, "ApplicationNo", true, DataSourceUpdateMode.OnValidation, "", "");

            //優先權
            txt_Priority.DataBindings.Clear();
            txt_Priority.DataBindings.Add("Text", trademarkManagementTBindingSource, "PriorityBaseName", true, DataSourceUpdateMode.OnValidation);

            txt_EarlyPriorityNo.DataBindings.Clear();
            txt_EarlyPriorityNo.DataBindings.Add("Text", trademarkManagementTBindingSource, "EarlyPriorityNo", true, DataSourceUpdateMode.OnValidation, "", "");

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

            txt_CloseCaus.DataBindings.Clear();
            txt_CloseCaus.DataBindings.Add("Text", trademarkManagementTBindingSource, "CloseCaus", true, DataSourceUpdateMode.OnPropertyChanged, "");

            txt_OutsourcingTrademarkNo.DataBindings.Clear();
            txt_OutsourcingTrademarkNo.DataBindings.Add("Text", trademarkManagementTBindingSource, "OutsourcingTrademarkNo", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_RegistrationNo.DataBindings.Clear();
            txt_RegistrationNo.DataBindings.Add("Text", trademarkManagementTBindingSource, "RegistrationNo", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_Status.DataBindings.Clear();
            txt_Status.DataBindings.Add("Text", trademarkManagementTBindingSource, "StatusName", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_StatusExplain.DataBindings.Clear();
            txt_StatusExplain.DataBindings.Add("Text", trademarkManagementTBindingSource, "StatusExplain", true, DataSourceUpdateMode.OnPropertyChanged, "");

            txt_RegisterProduct.DataBindings.Clear();
            txt_RegisterProduct.DataBindings.Add("Text", trademarkManagementTBindingSource, "RegisterProduct", true, DataSourceUpdateMode.OnValidation, "", "");

            maskedTextBox_EntrustDate.DataBindings.Clear();
            maskedTextBox_EntrustDate.DataBindings.Add("Text", trademarkManagementTBindingSource, "EntrustDate", true, DataSourceUpdateMode.OnPropertyChanged, "    /  /", "yyyy/MM/dd");

            maskedTextBox_RegistrationDate.DataBindings.Clear();
            maskedTextBox_RegistrationDate.DataBindings.Add("Text", trademarkManagementTBindingSource, "RegistrationDate", true, DataSourceUpdateMode.OnValidation, "    /  /", "yyyy/MM/dd");

            maskedTextBox_LawDate.DataBindings.Clear();
            maskedTextBox_LawDate.DataBindings.Add("Text", trademarkManagementTBindingSource, "LawDate", true, DataSourceUpdateMode.OnPropertyChanged, "    /  /", "yyyy/MM/dd");

            maskedTextBox_NoticeDate.DataBindings.Clear();
            maskedTextBox_NoticeDate.DataBindings.Add("Text", trademarkManagementTBindingSource, "NoticeDate1", true, DataSourceUpdateMode.OnPropertyChanged, "    /  /", "yyyy/MM/dd");

            maskedTextBox_NoticeDate2.DataBindings.Clear();
            maskedTextBox_NoticeDate2.DataBindings.Add("Text", trademarkManagementTBindingSource, "NoticeDate", true, DataSourceUpdateMode.OnPropertyChanged, "    /  /", "yyyy/MM/dd");

            maskedTextBox_DueDate.DataBindings.Clear();
            maskedTextBox_DueDate.DataBindings.Add("Text", trademarkManagementTBindingSource, "DueDate", true, DataSourceUpdateMode.OnPropertyChanged, "    /  /", "yyyy/MM/dd");

            maskedTextBox_ExtendedDate.DataBindings.Clear();
            maskedTextBox_ExtendedDate.DataBindings.Add("Text", trademarkManagementTBindingSource, "ExtendedDate", true, DataSourceUpdateMode.OnPropertyChanged, "    /  /", "yyyy/MM/dd");

            maskedTextBox_CloseDate.DataBindings.Clear();
            maskedTextBox_CloseDate.DataBindings.Add("Text", trademarkManagementTBindingSource, "CloseDate", true, DataSourceUpdateMode.OnPropertyChanged, "    /  /", "yyyy/MM/dd");

            maskedTextBox_ApplicationDate.DataBindings.Clear();
            maskedTextBox_ApplicationDate.DataBindings.Add("Text", trademarkManagementTBindingSource, "ApplicationDate", true, DataSourceUpdateMode.OnPropertyChanged, "    /  /", "yyyy/MM/dd");

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
            maskedTextBox_OutsourcingDate.DataBindings.Add("Text", trademarkManagementTBindingSource, "OutsourcingDate", true, DataSourceUpdateMode.OnPropertyChanged, "    /  /", "yyyy/MM/dd");

            //提案家族
            txt_TrademarkOvertureName.DataBindings.Clear();
            txt_TrademarkOvertureName.DataBindings.Add("Text", trademarkManagementTBindingSource, "TrademarkOvertureName", true, DataSourceUpdateMode.OnValidation);
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
            maskedTextBox_NotifyComitDate.DataBindings.Add("Text", trademarkNotifyEventTBindingSource, "NotifyComitDate", true, DataSourceUpdateMode.OnPropertyChanged, "    /  /", "yyyy/MM/dd");

            maskedTextBox_NotifyOfficerDate.DataBindings.Clear();
            maskedTextBox_NotifyOfficerDate.DataBindings.Add("Text", trademarkNotifyEventTBindingSource, "NotifyOfficerDate", true, DataSourceUpdateMode.OnPropertyChanged, "    /  /", "yyyy/MM/dd");

            maskedTextBox_OccurDate.DataBindings.Clear();
            maskedTextBox_OccurDate.DataBindings.Add("Text", trademarkNotifyEventTBindingSource, "OccurDate", true, DataSourceUpdateMode.OnPropertyChanged, "    /  /", "yyyy/MM/dd");

            maskedTextBox_DueDate.DataBindings.Clear();
            maskedTextBox_DueDate.DataBindings.Add("Text", trademarkNotifyEventTBindingSource, "DueDate", true, DataSourceUpdateMode.OnPropertyChanged, "    /  /", "yyyy/MM/dd");

            maskedTextBox_Notice.DataBindings.Clear();
            maskedTextBox_Notice.DataBindings.Add("Text", trademarkNotifyEventTBindingSource, "NoticeDate", true, DataSourceUpdateMode.OnPropertyChanged, "    /  /", "yyyy/MM/dd");

            //maskedTextBox_CustomerAuthorizationDate.DataBindings.Clear();
            //maskedTextBox_CustomerAuthorizationDate.DataBindings.Add("Text", trademarkNotifyEventTBindingSource, "CustomerAuthorizationDate", true, DataSourceUpdateMode.OnPropertyChanged, "    /  /", "yyyy/MM/dd");

            mtb_OutsourcingDate.DataBindings.Clear();
            mtb_OutsourcingDate.DataBindings.Add("Text", trademarkNotifyEventTBindingSource, "OutsourcingDate", true, DataSourceUpdateMode.OnPropertyChanged, "    /  /", "yyyy/MM/dd");

            maskedTextBox_FinishDate.DataBindings.Clear();
            maskedTextBox_FinishDate.DataBindings.Add("Text", trademarkNotifyEventTBindingSource, "FinishDate", true, DataSourceUpdateMode.OnPropertyChanged, "    /  /", "yyyy/MM/dd");

            maskedTextBox_AttorneyDueDate.DataBindings.Clear();
            maskedTextBox_AttorneyDueDate.DataBindings.Add("Text", trademarkNotifyEventTBindingSource, "AttorneyDueDate", true, DataSourceUpdateMode.OnPropertyChanged, "    /  /", "yyyy/MM/dd");

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

            txt_FeeEventNumber.DataBindings.Clear();
            txt_FeeEventNumber.DataBindings.Add("Text", trademarkFeeTBindingSource, "TMNotifyEventID", true, DataSourceUpdateMode.OnPropertyChanged, "", "TE#");

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
            maskedTextBox_RDate.DataBindings.Add("Text", trademarkFeeTBindingSource, "RDate", true, DataSourceUpdateMode.OnValidation, "    /  /", "yyyy/MM/dd");

            //收款期限
            maskedTextBox_CollectionPeriod.DataBindings.Clear();
            maskedTextBox_CollectionPeriod.DataBindings.Add("Text", trademarkFeeTBindingSource, "CollectionPeriod", true, DataSourceUpdateMode.OnValidation, "    /  /", "yyyy/MM/dd");

            //收款日期
            maskedTextBox_PayDate.DataBindings.Clear();
            maskedTextBox_PayDate.DataBindings.Add("Text", trademarkFeeTBindingSource, "PayDate", true, DataSourceUpdateMode.OnValidation, "    /  /", "yyyy/MM/dd");

            //發票日期
            maskedTextBox_aBillDate.DataBindings.Clear();
            maskedTextBox_aBillDate.DataBindings.Add("Text", trademarkFeeTBindingSource, "aBillDate", true, DataSourceUpdateMode.OnPropertyChanged, "    /  /", "yyyy/MM/dd");

            //發票號碼
            txt_aBill.DataBindings.Clear();
            txt_aBill.DataBindings.Add("Text", trademarkFeeTBindingSource, "aBill", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_OthFeeName.DataBindings.Clear();
            txt_OthFeeName.DataBindings.Add("Text", trademarkFeeTBindingSource, "OthFeeName", true, DataSourceUpdateMode.OnPropertyChanged, "", "");

            txt_CustomizeName.DataBindings.Clear();
            txt_CustomizeName.DataBindings.Add("Text", trademarkFeeTBindingSource, "CustomizeName", true, DataSourceUpdateMode.OnPropertyChanged, "", "");

            txt_CustomizeOthFee.DataBindings.Clear();
            txt_CustomizeOthFee.DataBindings.Add("Text", trademarkFeeTBindingSource, "CustomizeOthFee", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");

            txt_CustomizeMoney.DataBindings.Clear();
            txt_CustomizeMoney.DataBindings.Add("Text", trademarkFeeTBindingSource, "CustomizeMoney", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_CustomizeNT.DataBindings.Clear();
            txt_CustomizeNT.DataBindings.Add("Text", trademarkFeeTBindingSource, "CustomizeNT", true, DataSourceUpdateMode.OnValidation, "", "#,##0.####");

            txt_CustomizeTotal.DataBindings.Clear();
            txt_CustomizeTotal.DataBindings.Add("Text", trademarkFeeTBindingSource, "CustomizeTotal", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");

            txt_OtherTotalFeeCustomize1Name.DataBindings.Clear();
            txt_OtherTotalFeeCustomize1Name.DataBindings.Add("Text", trademarkFeeTBindingSource, "OtherTotalFeeCustomize1Name", true, DataSourceUpdateMode.OnPropertyChanged, "", "");

            txt_OtherTotalFeeCustomize2Name.DataBindings.Clear();
            txt_OtherTotalFeeCustomize2Name.DataBindings.Add("Text", trademarkFeeTBindingSource, "OtherTotalFeeCustomize2Name", true, DataSourceUpdateMode.OnPropertyChanged, "", "");

            txt_OtherTotalFeeCustomize3Name.DataBindings.Clear();
            txt_OtherTotalFeeCustomize3Name.DataBindings.Add("Text", trademarkFeeTBindingSource, "OtherTotalFeeCustomize3Name", true, DataSourceUpdateMode.OnPropertyChanged, "", "");

            txt_OtherTotalFeeCustomize1.DataBindings.Clear();
            txt_OtherTotalFeeCustomize1.DataBindings.Add("Text", trademarkFeeTBindingSource, "OtherTotalFeeCustomize1", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");

            txt_OtherTotalFeeCustomize2.DataBindings.Clear();
            txt_OtherTotalFeeCustomize2.DataBindings.Add("Text", trademarkFeeTBindingSource, "OtherTotalFeeCustomize2", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");

            txt_OtherTotalFeeCustomize3.DataBindings.Clear();
            txt_OtherTotalFeeCustomize3.DataBindings.Add("Text", trademarkFeeTBindingSource, "OtherTotalFeeCustomize3", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");

            txt_OtherTotalFeeInSide.DataBindings.Clear();
            txt_OtherTotalFeeInSide.DataBindings.Add("Text", trademarkFeeTBindingSource, "OtherTotalFeeInSide", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");

            txt_TaxPercent.DataBindings.Clear();
            txt_TaxPercent.DataBindings.Add("Text", trademarkFeeTBindingSource, "TaxPercent", true, DataSourceUpdateMode.OnValidation, "", "#,##0");

            txt_OtherTotalFeeInSideTax.DataBindings.Clear();
            txt_OtherTotalFeeInSideTax.DataBindings.Add("Text", trademarkFeeTBindingSource, "OtherTotalFeeInSideTax", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");

            txt_Tax.DataBindings.Clear();
            txt_Tax.DataBindings.Add("Text", trademarkFeeTBindingSource, "Tax", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");
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

            //事件單號
            txt_PayEventID.DataBindings.Clear();
            txt_PayEventID.DataBindings.Add("Text", trademarkPaymentTBindingSource, "TMNotifyEventID", true, DataSourceUpdateMode.OnValidation, "", "");

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
            maskedTextBox_IReceiptDate.DataBindings.Add("Text", trademarkPaymentTBindingSource, "IReceiptDate", true, DataSourceUpdateMode.OnPropertyChanged, "    /  /", "yyyy/MM/dd");

            txt_PayTotall.DataBindings.Clear();
            txt_PayTotall.DataBindings.Add("Text", trademarkPaymentTBindingSource, "Totall", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");

            txt_PayRemark.DataBindings.Clear();
            txt_PayRemark.DataBindings.Add("Text", trademarkPaymentTBindingSource, "Remark", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_Memo.DataBindings.Clear();
            txt_Memo.DataBindings.Add("Text", trademarkPaymentTBindingSource, "Memo", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_BillCheck.DataBindings.Clear();
            txt_BillCheck.DataBindings.Add("Text", trademarkPaymentTBindingSource, "BillCheck", true, DataSourceUpdateMode.OnValidation, "", "");

            maskedTextBox_ReciveDate.DataBindings.Clear();
            maskedTextBox_ReciveDate.DataBindings.Add("Text", trademarkPaymentTBindingSource, "ReciveDate", true, DataSourceUpdateMode.OnPropertyChanged, "    /  /", "yyyy/MM/dd");

            maskedTextBox_PayDueDate.DataBindings.Clear();
            maskedTextBox_PayDueDate.DataBindings.Add("Text", trademarkPaymentTBindingSource, "PayDueDate", true, DataSourceUpdateMode.OnPropertyChanged, "    /  /", "yyyy/MM/dd");

            maskedTextBox_PaymentDate.DataBindings.Clear();
            maskedTextBox_PaymentDate.DataBindings.Add("Text", trademarkPaymentTBindingSource, "PaymentDate", true, DataSourceUpdateMode.OnPropertyChanged, "    /  /", "yyyy/MM/dd");

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

        #region 關閉按鈕 private void button4_Click(object sender, EventArgs e)
        /// <summary>
        /// 關閉按鈕
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region CheckPatenDel 如果有子資料，將回傳False , 若無子資料回傳True
        /// <summary>
        /// 驗証案件是否可刪除
        /// 如果有子資料，將回傳False , 若無子資料回傳True
        /// </summary>
        /// <param name="PatentID"></param>
        /// <returns></returns>
        private bool CheckPatenDel(int TrademarkID)
        {
            string strSQL = string.Format(@"select Top 1 TMNotifyEventID from TrademarkNotifyEventT where TrademarkID={0}; 
                                            select Top 1 PaymentID from TrademarkPaymentT where TrademarkID={0};
                                            select Top 1 FeeKEY from TrademarkFeeT where TrademarkID={0};
                                            ", TrademarkID);

            Public.DLL dll = new Public.DLL();
            DataSet dt = dll.SqlDataAdapterDataSet(strSQL);
            bool bResult = true;
            for (int i = 0; i < dt.Tables.Count; i++)
            {
                if (dt.Tables[i].Rows.Count > 0)
                {
                    bResult = false;
                    break;
                }
            }
            return bResult;
        }
        #endregion

        #region ================contextMenuStrip_Trademark_ItemClicked====================
        private void contextMenuStrip_Trademark_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            contextMenuStrip_Trademark.Visible = false;
            switch (e.ClickedItem.Name)
            {
                case "AddTMtoolStripMenuItem":
                case "toolStripButton_AddTM":
                    AddFrom.AddTrademark add = new AddFrom.AddTrademark();
                    add.ShowDialog();
                    break;

                case "DelTMtoolStripMenuItem":
                case "toolStripButton_DelTM":
                    if (trademarkManagementTDataGridView.CurrentRow != null)
                    {
                        //2.判斷是否有子資料
                        if (!CheckPatenDel((int)trademarkManagementTDataGridView.CurrentRow.Cells["TrademarkID"].Value))
                        {
                            MessageBox.Show("該案件不得刪除，因案件下尚有子資料，請先將子資料刪除\r\n \r\n即可刪除此申請案【" + trademarkManagementTDataGridView.CurrentRow.Cells["TrademarkNo"].Value.ToString() + "】", "提示訊息");
                            return;
                        }



                        //鎖定資料
                        int iLocker = Public.Utility.GetRecordAuth("TrademarkManagementT", "TrademarkID=" + property_TrademarkID.ToString());
                        if (iLocker == -1 || iLocker == iWorkerID)
                        {
                            if (iLocker != iWorkerID)
                            {
                                Public.Utility.LockRecordAuth("TrademarkManagementT", iWorkerID, "TrademarkID=" + property_TrademarkID.ToString());
                            }

                            string strName = trademarkManagementTDataGridView.CurrentRow.Cells["TrademarkNo"].Value.ToString();

                            if (MessageBox.Show("是否確定刪除【" + strName + "】", "確認視窗", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                            {
                                Public.DLL dll = new Public.DLL();
                                //刪除商標案相關文件包含委辦、來函、費用的實體檔案
                                string delFileDir = string.Format(@"{0}\{1}", dll.TrademarkFolderRoot, trademarkManagementTDataGridView.CurrentRow.Cells["TrademarkID"].Value.ToString());
                                if (Directory.Exists(delFileDir))
                                {
                                    Directory.Delete(delFileDir, true);
                                }
                                int iKey = (int)trademarkManagementTDataGridView.CurrentRow.Cells["TrademarkID"].Value;

                                Public.CTrademarkManagement TMdel = new Public.CTrademarkManagement();
                                Public.CTrademarkManagement.ReadOne(iKey, ref TMdel);

                                //刪除記錄檔    
                                Public.CSystemLogT log = new Public.CSystemLogT();
                                log.DelTime = DateTime.Now;
                                log.DelWorkerKey = Properties.Settings.Default.WorkerKEY;
                                log.DelWorker = Properties.Settings.Default.WorkerName;

                                log.DelContent = string.Format("商標案號:{0}\r\n商標名稱:{1}\r\n申請人:{2}\r\n商標樣式:{3}\r\n客戶案號:{4}\r\n複代案號:{5}", TMdel.TrademarkNo, TMdel.TrademarkName, TMdel.ApplicantNames, TMdel.StyleName, TMdel.MainCustomerRefNo, TMdel.OutsourcingTrademarkNo);
                                log.DelTitle = string.Format("刪除「{0}」資料【{1}】", this.Text, TMdel.TrademarkNo);
                                log.Create();

                                TMdel.Delete(iKey);
                                trademarkManagementTDataGridView.Rows.Remove(trademarkManagementTDataGridView.CurrentRow);
                                MessageBox.Show("刪除成功", "提示訊息");
                            }
                        }
                        else
                        {
                            if (iLocker != -1)//無人使用中
                            {
                                Worker_Model worker = new Worker_Model();
                                Worker_Model.ReadOne(iLocker, ref worker);
                                MessageBox.Show("很抱歉~~   目前該筆資料正被【" + worker.EmployeeName + "】使用中，請等候!!\r\n 謝謝", "提示訊息");
                            }
                        }
                    }
                    break;
                case "toolStripButton_Export":
                case "ImportExcelToolStripMenuItem":
                    try
                    {
                        Public.DLL dll = new Public.DLL();
                        Task task = dll.WriteToCSV(trademarkManagementTDataGridView);
                    }
                    catch
                    {
                        MessageBox.Show("匯出CSV失敗");
                    }

                    break;
                case "ToolStripMenuItem_Proposal":
                    if (trademarkManagementTDataGridView.SelectedRows.Count > 0)
                    {
                        US.OvertrueName overture = new LawtechPTSystem.US.OvertrueName();
                        overture.TypeMode = 2;
                        overture.GV = trademarkManagementTDataGridView;
                        overture.Dt = dt_TrademarkManagementT;
                        overture.ShowDialog();
                    }
                    break;
                case "toolStripMenuItem_CopyTrademark":
                    if (trademarkManagementTDataGridView.SelectedRows.Count > 0)
                    {
                        CopyForm.Trademark tm = new LawtechPTSystem.CopyForm.Trademark();
                        tm.TrademarkIDSource = (int)trademarkManagementTDataGridView.CurrentRow.Cells["TrademarkID"].Value;
                        tm.ShowDialog();
                    }
                    break;
                case "toolStripButton_UploadFile":
                case "UploadFileToolStripMenuItem":
                    if (trademarkManagementTDataGridView.CurrentRow != null)
                    {
                        bool bConnectionFile = Properties.Settings.Default.IsFileServerConnection;
                        if (bConnectionFile)
                        {
                            //US.UpdataFile upfile2 = new US.UpdataFile();
                            US.UpFileList upfile2 = new US.UpFileList();
                            upfile2.Text = "上傳商標(" + trademarkManagementTDataGridView.CurrentRow.Cells["TrademarkNo"].Value.ToString() + ")相關文件";
                            upfile2.MainFileKey = (int)trademarkManagementTDataGridView.CurrentRow.Cells["TrademarkID"].Value;
                            upfile2.UploadMode = 4;
                            upfile2.MainFileType = 6;
                            upfile2.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("請確認檔案上傳路徑是否有正常連結!!");
                        }
                    }
                    break;

                case "toolStripButton_OpenFileList":
                case "OpenFileListToolStripMenuItem":
                    if (trademarkManagementTDataGridView.CurrentRow != null)
                    {
                        bool bConnectionFile = Properties.Settings.Default.IsFileServerConnection;
                        if (bConnectionFile)
                        {
                            ViewUpdateFileList subForm = new ViewUpdateFileList();
                            subForm.Text = trademarkManagementTDataGridView.CurrentRow.Cells["TrademarkNo"].Value.ToString() + "的相關文件";
                            subForm.FileKind = 4;
                            subForm.FileType = 6;
                            subForm.MainParentID = (int)trademarkManagementTDataGridView.CurrentRow.Cells["TrademarkID"].Value;
                            subForm.vb_TM.Checked = true;
                            subForm.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("請確認檔案上傳路徑是否有正常連結!!");
                        }
                    }
                    break;
                case "EdittoolStripMenuItem":
                case "toolStripButton_EditTM":
                    if (trademarkManagementTDataGridView.CurrentRow != null)
                    {
                        //鎖定資料
                        int iLocker = Public.Utility.GetRecordAuth("TrademarkManagementT", "TrademarkID=" + property_TrademarkID.ToString());
                        if (iLocker == -1 || iLocker == iWorkerID)
                        {
                            if (iLocker != iWorkerID)
                            {
                                Public.Utility.LockRecordAuth("TrademarkManagementT", iWorkerID, "TrademarkID=" + property_TrademarkID.ToString());
                            }
                            EditForm.EditTrademark Edit = new LawtechPTSystem.EditForm.EditTrademark();
                            Edit.TrademarkID = (int)trademarkManagementTDataGridView.CurrentRow.Cells["TrademarkID"].Value;
                            Edit.ShowDialog();
                        }
                        else
                        {
                            if (iLocker != -1)//無人使用中
                            {
                                Worker_Model worker = new Worker_Model();
                                Worker_Model.ReadOne(iLocker, ref worker);
                                MessageBox.Show("很抱歉~~   目前該筆資料正被【" + worker.EmployeeName + "】使用中，請等候!!\r\n 謝謝", "提示訊息");
                            }
                        }
                    }
                    break;

                case "toolStripMenuItem_CompleteHistory":
                    if (trademarkManagementTDataGridView.SelectedRows.Count > 0)
                    {
                        ViewFrom.TrademarkCompleteHistory history = new LawtechPTSystem.ViewFrom.TrademarkCompleteHistory();
                        history.Gv = trademarkManagementTDataGridView;
                        history.Show();
                    }
                    break;

                case "toolStripMenuItem_SendMail":
                    if (trademarkManagementTDataGridView.CurrentRow != null)
                    {
                        US.NotificationLetter letter = new LawtechPTSystem.US.NotificationLetter();
                        letter.ApplicantKeys = trademarkManagementTDataGridView.CurrentRow.Cells["ApplicantKeys"].Value.ToString();
                        letter.MainKey = (int)trademarkManagementTDataGridView.CurrentRow.Cells["TrademarkID"].Value;
                        letter.CaseKey = trademarkManagementTDataGridView.CurrentRow.Cells["TrademarkID"].Value != null ? (int)trademarkManagementTDataGridView.CurrentRow.Cells["TrademarkID"].Value : -1;
                        letter.DelegateType = trademarkManagementTDataGridView.CurrentRow.Cells["DelegateType"].Value.ToString() != "" ? (int)trademarkManagementTDataGridView.CurrentRow.Cells["DelegateType"].Value : -1;
                        letter.Attorney = trademarkManagementTDataGridView.CurrentRow.Cells["OutsourcingAttorney"].Value.ToString() != "" ? (int)trademarkManagementTDataGridView.CurrentRow.Cells["OutsourcingAttorney"].Value : -1;
                        letter.EmailSampleType = "Trademark";
                        letter.CaseNo = trademarkManagementTDataGridView.CurrentRow.Cells["TrademarkNo"].Value.ToString();
                        letter.Text += "(" + trademarkManagementTDataGridView.CurrentRow.Cells["TrademarkNo"].Value.ToString() + ")";
                        letter.ShowDialog();
                    }
                    break;


                case "toolStripButton_Orientation":
                    Public.Utility.SsplitContainerHorizontal(ref splitContainer1);
                    break;
                case "toolStripMenuItem_SetGridColumn":
                    SetGridColumnT gc = new SetGridColumnT();
                    gc.CurrentGridSymboID = trademarkManagementTDataGridView.Tag.ToString();
                    gc.TitleName = "商標申請案列表";
                    gc.Show();
                    break;
                case "toolStripMenuItem_App"://查看申請人
                    if (trademarkManagementTDataGridView.CurrentRow != null)
                    {
                        ViewFrom.ApplicantList app = new ViewFrom.ApplicantList();
                        app.MainType = 2;
                        string No = trademarkManagementTDataGridView.CurrentRow.Cells["TrademarkNo"].Value.ToString();
                        app.Text += $"--{No}";
                        app.MainKey = (int)trademarkManagementTDataGridView.CurrentRow.Cells["TrademarkID"].Value;
                        app.Show();
                    }
                    break;
            }
        }
        #endregion

        #region trademarkManagementTDataGridView_CellDoubleClick
        private void trademarkManagementTDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != -1 && e.RowIndex != -1)
            {
                if (trademarkManagementTDataGridView.CurrentRow != null)
                {
                    if (myPermission.UserPermission.HasFlag(PermissionTypes.Modify))//判斷權限
                    {
                        contextMenuStrip_Trademark_ItemClicked(contextMenuStrip_Trademark, new ToolStripItemClickedEventArgs(EdittoolStripMenuItem));
                    }
                }
            }
        }
        #endregion

        #region ==============trademarkManagementTDataGridView_SelectionChanged================
        private void trademarkManagementTDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (trademarkManagementTDataGridView.CurrentRow != null)
            {
                string sPic = trademarkManagementTDataGridView.CurrentRow.Cells["PicPath"].Value.ToString();
                if (sPic != "")
                {
                    pictureBox1.ImageLocation = property_TMrootPath + "\\" + sPic;
                }
                else
                {
                    pictureBox1.ImageLocation = "";
                }

                //事件記錄
                Public.CTrademarkPublicFunction.GetTrademarkEvent(property_TrademarkID.ToString(), ref DT_TrademarkNotifyEventT);

                //請款記錄
                Public.CTrademarkPublicFunction.GetTrademarkFee(property_TrademarkID.ToString(), ref DT_TrademarkFeeT);

                //付款記錄
                Public.CTrademarkPublicFunction.GetTrademarkPayment(property_TrademarkID.ToString(), ref DT_TrademarkPaymentT);

                //預估成本
                Public.CTrademarkPublicFunction.GetTrademarkEstimateCost(property_TrademarkID.ToString(), ref DT_TrademarkEstimateCostT);


                //商標權狀態異動資料
                GetTrademarkAnnuity();


            }
            else
            {
                pictureBox1.ImageLocation = "";

                //來函
                this.DT_TrademarkNotifyEventT.Rows.Clear();

                //請款記錄
                this.DT_TrademarkFeeT.Rows.Clear();

                //付款記錄
                this.DT_TrademarkPaymentT.Rows.Clear();

                //預估成本
                this.DT_TrademarkEstimateCostT.Rows.Clear();

                ds_TrademarkAnnuityT.Tables.Clear();
            }
        }
        #endregion

        #region GetTrademarkList 取得商標的資料
        /// <summary>
        /// 取得商標的資料
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public void GetTrademarkList(string strWhere)
        {

            string strSQL = string.Format(@"SELECT *  from  V_TrademarkList  {0}", !string.IsNullOrEmpty(strWhere) ? " where " + strWhere : "");

            DBAccess dbhelper = new DBAccess();
            dt_TrademarkManagementT.Rows.Clear();
            dbhelper.QueryToDataTableByDataAdapter(strSQL, ref DT_TrademarkList);

            if (DT_TrademarkList.PrimaryKey.Length == 0)
            {
                DataColumn[] pk = { DT_TrademarkList.Columns["TrademarkID"] };
                DT_TrademarkList.PrimaryKey = pk;
            }
        }
        #endregion 

        #region GetComitEvent 取得事件的資料
        /// <summary>
        /// 取得商標事件的資料
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public void GetTrademarkEvent(string strTrademarkID)
        {
            string strSQL = string.Format(@"SELECT * from  V_TrademarkNotifyEventT where TrademarkID={0}", strTrademarkID);

            DBAccess dbhelper = new DBAccess();
            DT_TrademarkNotifyEventT.Rows.Clear();
            dbhelper.QueryToDataTableByDataAdapter(strSQL, ref DT_TrademarkNotifyEventT);

            if (DT_TrademarkNotifyEventT.PrimaryKey.Length == 0)
            {
                DataColumn[] pk = { DT_TrademarkNotifyEventT.Columns["TMNotifyEventID"] };
                DT_TrademarkNotifyEventT.PrimaryKey = pk;
            }
        }
        #endregion 

        #region GetTrademarkFee 取得商標請款的資料
        /// <summary>
        /// 取得商標請款的資料
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public void GetTrademarkFee(string strTrademarkID)
        {

            string strSQL = string.Format(@"SELECT * from  V_TrademarkFeeT where TrademarkID={0}", strTrademarkID);

            DBAccess dbhelper = new DBAccess();
            DT_TrademarkFeeT.Rows.Clear();
            dbhelper.QueryToDataTableByDataAdapter(strSQL, ref DT_TrademarkFeeT);
            if (DT_TrademarkFeeT.PrimaryKey.Length == 0)
            {
                DataColumn[] pk = { DT_TrademarkFeeT.Columns["FeeKEY"] };
                DT_TrademarkFeeT.PrimaryKey = pk;
            }
        }
        #endregion 

        #region GetTrademarkPayment 取得商標付款的資料
        /// <summary>
        /// 取得商標付款的資料
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public void GetTrademarkPayment(string strTrademarkID)
        {

            string strSQL = string.Format(@"SELECT * from  V_TrademarkPaymentT where TrademarkID={0}", strTrademarkID);

            DBAccess dbhelper = new DBAccess();
            DT_TrademarkPaymentT.Rows.Clear();
            dbhelper.QueryToDataTableByDataAdapter(strSQL, ref DT_TrademarkPaymentT);

            if (DT_TrademarkPaymentT.PrimaryKey.Length == 0)
            {
                DataColumn[] pk = { DT_TrademarkPaymentT.Columns["PaymentID"] };
                DT_TrademarkPaymentT.PrimaryKey = pk;
            }
        }
        #endregion 

        #region GetTrademarkEstimateCost 取得商標預估費用的資料
        /// <summary>
        /// 取得商標預估費用的資料
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public void GetTrademarkEstimateCost(string strTrademarkID)
        {

            string strSQL = string.Format(@"SELECT * from  TrademarkEstimateCostT where TrademarkID={0}", strTrademarkID);

            DBAccess dbhelper = new DBAccess();
            DT_TrademarkEstimateCostT.Rows.Clear();
            dbhelper.QueryToDataTableByDataAdapter(strSQL, ref DT_TrademarkEstimateCostT);
            if (DT_TrademarkEstimateCostT.PrimaryKey.Length == 0)
            {
                DataColumn[] pk = { DT_TrademarkEstimateCostT.Columns["TMEstimateCostID"] };
                DT_TrademarkEstimateCostT.PrimaryKey = pk;
            }
        }
        #endregion 

        public void GetTrademarkAnnuity()
        {
            Public.CTrademarkPublicFunction.GetTrademarkAnnuityList(property_TrademarkID.ToString(), ref ds_TrademarkAnnuityT);
            if (ds_TrademarkAnnuityT != null && ds_TrademarkAnnuityT.Tables.Count > 0)
            {
                if (ds_TrademarkAnnuityT.Tables[0] != null)
                {
                    dataGridView_TrademarkAnnuity.DataSource = ds_TrademarkAnnuityT.Tables[0];
                }

                if (ds_TrademarkAnnuityT.Tables[1] != null)
                {
                    dataGridView_AnnuityImage.DataSource = ds_TrademarkAnnuityT.Tables[1];
                }

                if (ds_TrademarkAnnuityT.Tables[2] != null)
                {
                    dataGridView_AnnuityClass.DataSource = ds_TrademarkAnnuityT.Tables[2];
                }

                if (ds_TrademarkAnnuityT.Tables[3] != null)
                {
                    dataGridView_AnnuityHolder.DataSource = ds_TrademarkAnnuityT.Tables[3];
                }
            }
        }

        #region ==============contextMenuStrip_Event1_ItemClicked================
        private void contextMenuStrip_Event1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            contextMenuStrip_Event1.Visible = false;
            switch (e.ClickedItem.Name)
            {
                case "bindingNavigatorAddNewItem_Notify":
                case "新增來函ToolStripMenuItem":
                    if (trademarkManagementTDataGridView.CurrentRow != null)
                    {
                        AddFrom.AddTrademarkNotifyEvent add = new AddFrom.AddTrademarkNotifyEvent();
                        add.TrademarkID = (int)trademarkManagementTDataGridView.CurrentRow.Cells["TrademarkID"].Value;
                        if (trademarkManagementTDataGridView.CurrentRow.Cells["CountrySymbol"].Value != null)
                        {
                            add.CountrySymbol = trademarkManagementTDataGridView.CurrentRow.Cells["CountrySymbol"].Value.ToString();
                        }
                        add.ShowDialog();
                    }
                    break;

                case "bindingNavigatorDeleteItem_Notify":
                case "刪除來函ToolStripMenuItem":
                    if (TMNotifyEventTDataGridView.CurrentRow != null)
                    {
                        int iLocker = Public.Utility.GetRecordAuth("TrademarkNotifyEventT", "TMNotifyEventID=" + TMNotifyEventTDataGridView.CurrentRow.Cells["TMNotifyEventID"].Value.ToString());
                        if (iLocker == -1 || iLocker == iWorkerID)
                        {
                            if (iLocker != iWorkerID)
                            {
                                Public.Utility.LockRecordAuth("TrademarkNotifyEventT", iWorkerID, "TMNotifyEventID=" + TMNotifyEventTDataGridView.CurrentRow.Cells["TMNotifyEventID"].Value.ToString());
                            }
                            string strName = TMNotifyEventTDataGridView.CurrentRow.Cells["NotifyEventContent"].Value.ToString();
                            if (MessageBox.Show("是否確定刪除【" + strName + "】", "確認視窗", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                            {
                                int iKey = (int)TMNotifyEventTDataGridView.CurrentRow.Cells["TMNotifyEventID"].Value;
                                Public.CTrademarkNotifyEvent TMdel = new Public.CTrademarkNotifyEvent();
                                Public.CTrademarkNotifyEvent.ReadOne(iKey, ref TMdel);

                                Public.CTrademarkNotifyEventToFee NotifyEventToFee = new Public.CTrademarkNotifyEventToFee();
                                NotifyEventToFee.Delete("TMNotifyEventID=" + iKey.ToString(), "");

                                Public.CTrademarkNotifyEventToPayment NotifyEventToPayment = new Public.CTrademarkNotifyEventToPayment();
                                NotifyEventToPayment.Delete("TMNotifyEventID=" + iKey.ToString(), "");

                                //刪除官方公文
                                Public.COfficialDocumentEventT delDocumentEventT = new Public.COfficialDocumentEventT();
                                delDocumentEventT.Delete(" EventCaseType='TE' and CaseEventKey=" + iKey.ToString(), "");

                                Public.CTrademarkManagement tm = new Public.CTrademarkManagement();
                                Public.CTrademarkManagement.ReadOne(property_TrademarkID, ref tm);

                                //刪除記錄檔    
                                Public.CSystemLogT log = new Public.CSystemLogT();
                                log.DelTime = DateTime.Now;
                                log.DelWorkerKey = Properties.Settings.Default.WorkerKEY;
                                log.DelWorker = Properties.Settings.Default.WorkerName;

                                log.DelContent = string.Format("商標案號:{5}\r\n商標名稱:{6}\r\n事件內容:{0}\r\n本所來函日:{1}\r\n官方期限:{2}\r\n本所期限:{3}\r\n完成日期:{4}\r\n處理結果:{7}\r\n備註:{8}", TMdel.NotifyEventContent, TMdel.NotifyComitDate.HasValue ? TMdel.NotifyComitDate.Value.ToString("yyyy/MM/dd") : "", TMdel.DueDate.HasValue ? TMdel.DueDate.Value.ToString("yyyy/MM/dd") : "", TMdel.AttorneyDueDate.HasValue ? TMdel.AttorneyDueDate.Value.ToString("yyyy/MM/dd") : "", TMdel.FinishDate.HasValue ? TMdel.FinishDate.Value.ToString("yyyy/MM/dd") : "", tm.TrademarkNo, tm.TrademarkName, TMdel.Result, TMdel.Remark);
                                log.DelTitle = string.Format("刪除「{0}」資料【事件記錄-{1}】", this.Text, TMdel.NotifyEventContent);
                                log.Create();

                                TMdel.Delete(iKey);
                                TMNotifyEventTDataGridView.Rows.Remove(TMNotifyEventTDataGridView.CurrentRow);



                                MessageBox.Show("刪除成功", "提示訊息");
                            }
                            //Public.Utility.NuLockRecordAuth("TrademarkNotifyEventT", "TMNotifyEventID=" + TMNotifyEventTDataGridView.CurrentRow.Cells["TMNotifyEventID"].Value.ToString());
                        }
                        else
                        {
                            if (iLocker != -1)//無人使用中
                            {
                                Worker_Model worker = new Worker_Model();
                                Worker_Model.ReadOne(iLocker, ref worker);
                                MessageBox.Show("很抱歉~~   目前該筆資料正被【" + worker.EmployeeName + "】使用中，請等候!!\r\n 謝謝", "提示訊息");
                            }
                        }
                    }
                    break;

                case "上傳來函相關文件ToolStripMenuItem":
                    if (TMNotifyEventTDataGridView.CurrentRow != null)
                    {
                        bool bConnectionFile = Properties.Settings.Default.IsFileServerConnection;
                        if (bConnectionFile)
                        {
                            //US.UpdataFile upfile2 = new US.UpdataFile();
                            US.UpFileList upfile2 = new US.UpFileList();
                            upfile2.Text = "上傳商標(" + trademarkManagementTDataGridView.CurrentRow.Cells["TrademarkNo"].Value.ToString() + ")相關文件";
                            upfile2.MainFileKey = (int)trademarkManagementTDataGridView.CurrentRow.Cells["TrademarkID"].Value;
                            upfile2.UploadMode = 4;
                            upfile2.MainFileType = 7;
                            upfile2.ChildFileKey = (int)TMNotifyEventTDataGridView.CurrentRow.Cells["TMNotifyEventID"].Value;
                            upfile2.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("請確認檔案上傳路徑是否有正常連結!!");
                        }
                    }
                    break;

                case "開啟來函相關文件ToolStripMenuItem":
                    if (TMNotifyEventTDataGridView.CurrentRow != null)
                    {
                        bool bConnectionFile = Properties.Settings.Default.IsFileServerConnection;
                        if (bConnectionFile)
                        {
                            ViewUpdateFileList subForm = new ViewUpdateFileList();
                            subForm.Text = trademarkManagementTDataGridView.CurrentRow.Cells["TrademarkNo"].Value.ToString() + "的相關文件";
                            subForm.FileKind = 4;
                            subForm.FileType = 7;
                            subForm.MainParentID = (int)trademarkManagementTDataGridView.CurrentRow.Cells["TrademarkID"].Value;
                            subForm.vb_TMNotify.Checked = true;
                            subForm.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("請確認檔案上傳路徑是否有正常連結!!");
                        }
                    }
                    break;

                case "EditNotifytoolStripMenuItem":
                case "toolStripButtonEidtItem_Notify":
                    if (TMNotifyEventTDataGridView.CurrentRow != null)
                    {
                        //鎖定資料
                        int iLocker = Public.Utility.GetRecordAuth("TrademarkNotifyEventT", "TMNotifyEventID=" + TMNotifyEventTDataGridView.CurrentRow.Cells["TMNotifyEventID"].Value.ToString());
                        if (iLocker == -1 || iLocker == iWorkerID)
                        {
                            if (iLocker != iWorkerID)
                            {
                                Public.Utility.LockRecordAuth("TrademarkNotifyEventT", iWorkerID, "TMNotifyEventID=" + TMNotifyEventTDataGridView.CurrentRow.Cells["TMNotifyEventID"].Value.ToString());
                            }
                            EditForm.EditTrademarkNotifyEvent Edit = new LawtechPTSystem.EditForm.EditTrademarkNotifyEvent();
                            Edit.property_TMNotifyEventID = (int)TMNotifyEventTDataGridView.CurrentRow.Cells["TMNotifyEventID"].Value;
                            Edit.CountrySymbol = trademarkManagementTDataGridView.CurrentRow.Cells["CountrySymbol"].Value.ToString();
                            Edit.ShowDialog();

                            //Public.Utility.NuLockRecordAuth("TrademarkNotifyEventT", "TMNotifyEventID=" + TMNotifyEventTDataGridView.CurrentRow.Cells["TMNotifyEventID"].Value.ToString());
                        }
                        else
                        {
                            if (iLocker != -1)//無人使用中
                            {
                                Worker_Model worker = new Worker_Model();
                                Worker_Model.ReadOne(iLocker, ref worker);
                                MessageBox.Show("很抱歉~~   目前該筆資料正被【" + worker.EmployeeName + "】使用中，請等候!!\r\n 謝謝", "提示訊息");
                            }
                        }
                    }

                    break;

                case "toolStripMenuItem_ToFee":
                    if (TMNotifyEventTDataGridView.CurrentRow != null)
                    {
                        AddFrom.AddTrademarkFee fee = new AddFrom.AddTrademarkFee();
                        fee.TrademarkID = (int)trademarkManagementTDataGridView.CurrentRow.Cells["TrademarkID"].Value;
                        fee.SourceID = (int)TMNotifyEventTDataGridView.CurrentRow.Cells["TMNotifyEventID"].Value;
                        fee.FeeSubject = "案件轉至請款--" + TMNotifyEventTDataGridView.CurrentRow.Cells["NotifyEventContent"].Value.ToString();
                        fee.CountrySymbol = trademarkManagementTDataGridView.CurrentRow.Cells["CountrySymbol"].Value.ToString();
                        fee.Text = fee.Text + "--" + trademarkManagementTDataGridView.CurrentRow.Cells["TrademarkNo"].Value.ToString();
                        fee.ShowDialog();
                    }
                    break;
                case "toolStripMenuItem_ToPayment":
                    if (TMNotifyEventTDataGridView.CurrentRow != null)
                    {
                        AddFrom.AddTrademarkPayment Payment = new AddFrom.AddTrademarkPayment();
                        Payment.TrademarkID = (int)trademarkManagementTDataGridView.CurrentRow.Cells["TrademarkID"].Value;
                        Payment.SourceID = (int)TMNotifyEventTDataGridView.CurrentRow.Cells["TMNotifyEventID"].Value;
                        Payment.FeeSubject = "案件轉至付款--" + TMNotifyEventTDataGridView.CurrentRow.Cells["NotifyEventContent"].Value.ToString();
                        Payment.CountrySymbol = trademarkManagementTDataGridView.CurrentRow.Cells["CountrySymbol"].Value.ToString();
                        Payment.Text = Payment.Text + "--" + trademarkManagementTDataGridView.CurrentRow.Cells["TrademarkNo"].Value.ToString();
                        Payment.ShowDialog();
                    }
                    break;
                case "toolStripMenuItem_CopyEvent"://複製案件記錄
                    if (TMNotifyEventTDataGridView.CurrentRow != null)
                    {
                        CopyForm.CopyTrademarkEvent CopyEvent = new LawtechPTSystem.CopyForm.CopyTrademarkEvent();
                        CopyEvent.TrademarkID = (int)trademarkManagementTDataGridView.CurrentRow.Cells["TrademarkID"].Value;
                        CopyEvent.property_TMNotifyEventID = (int)TMNotifyEventTDataGridView.CurrentRow.Cells["TMNotifyEventID"].Value;
                        CopyEvent.CountrySymbol = trademarkManagementTDataGridView.CurrentRow.Cells["CountrySymbol"].Value.ToString();
                        CopyEvent.ShowDialog();
                    }
                    break;

                case "toolStripMenuItem_MultipleCopy":
                    if (TMNotifyEventTDataGridView.SelectedRows.Count > 0)
                    {
                        StringBuilder sb = new StringBuilder();
                        for (int iRows = 0; iRows < TMNotifyEventTDataGridView.SelectedRows.Count; iRows++)
                        {
                            if (sb.Length > 0)
                            {
                                sb.Append(",");
                            }
                            sb.Append(TMNotifyEventTDataGridView.SelectedRows[iRows].Cells["TMNotifyEventID"].Value.ToString());
                        }

                        MultipleKeyByCopy = sb.ToString();
                        MessageBox.Show("成功複製了 " + TMNotifyEventTDataGridView.SelectedRows.Count.ToString() + "筆 事件記錄");
                    }
                    else
                    {
                        if (TMNotifyEventTDataGridView.CurrentRow != null)
                        {
                            MultipleKeyByCopy = TMNotifyEventTDataGridView.CurrentRow.Cells["TMNotifyEventID"].Value.ToString();
                            MessageBox.Show("成功複製了【" + TMNotifyEventTDataGridView.CurrentRow.Cells["NotifyEventContent"].Value.ToString() + "】事件記錄");
                        }
                    }
                    break;

                case "toolStripMenuItem_Paste":
                    if (trademarkManagementTDataGridView.CurrentRow != null)
                    {
                        if (MultipleKeyByCopy != "")
                        {

                            string[] Keys = MultipleKeyByCopy.Split(',');
                            if (MessageBox.Show("是否確定貼上 " + Keys.Length.ToString() + "筆事件記錄", "提示訊息", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                            {
                                List<Public.CTrademarkNotifyEvent> copyMulti = new List<Public.CTrademarkNotifyEvent>();
                                Public.CTrademarkNotifyEvent.ReadList(ref copyMulti, "TMNotifyEventID in(" + MultipleKeyByCopy + ")");
                                foreach (var item in copyMulti)
                                {

                                    item.TrademarkID = property_TrademarkID;

                                    item.LastModifyWorker = Properties.Settings.Default.WorkerName;

                                    item.Create();
                                }

                                RefrashDataTable(1);
                                trademarkNotifyEventTBindingSource.MoveLast();
                            }
                        }
                    }

                    break;

                case "toolStripMenuItem_SendMailEvent":
                    if (TMNotifyEventTDataGridView.CurrentRow != null)
                    {
                        US.NotificationLetter letter = new LawtechPTSystem.US.NotificationLetter();
                        letter.ApplicantKeys = trademarkManagementTDataGridView.CurrentRow.Cells["ApplicantKeys"].Value.ToString();
                        letter.MainKey = (int)trademarkManagementTDataGridView.CurrentRow.Cells["TrademarkID"].Value;
                        letter.CaseKey = TMNotifyEventTDataGridView.CurrentRow.Cells["TMNotifyEventID"].Value != null ? (int)TMNotifyEventTDataGridView.CurrentRow.Cells["TMNotifyEventID"].Value : -1;
                        letter.DelegateType = trademarkManagementTDataGridView.CurrentRow.Cells["DelegateType"].Value.ToString() != "" ? (int)trademarkManagementTDataGridView.CurrentRow.Cells["DelegateType"].Value : -1;
                        letter.Attorney = trademarkManagementTDataGridView.CurrentRow.Cells["OutsourcingAttorney"].Value.ToString() != "" ? (int)trademarkManagementTDataGridView.CurrentRow.Cells["OutsourcingAttorney"].Value : -1;
                        letter.EmailSampleType = "TrademarkEvent";
                        letter.CaseNo = trademarkManagementTDataGridView.CurrentRow.Cells["TrademarkNo"].Value.ToString();
                        letter.Text += "(" + trademarkManagementTDataGridView.CurrentRow.Cells["TrademarkNo"].Value.ToString() + ")";
                        letter.ShowDialog();
                    }
                    break;
                case "toolStripMenuItem_EventSetGridColumn":
                    SetGridColumnT gc = new SetGridColumnT();
                    gc.CurrentGridSymboID = TMNotifyEventTDataGridView.Tag.ToString();
                    gc.TitleName = "案件記錄";
                    gc.Show();
                    break;
                case "toolStripMenuItem_WorkList":
                    if (TMNotifyEventTDataGridView.CurrentRow != null)
                    {
                        PATControlEventWorkList worklist = new PATControlEventWorkList();
                        worklist.TypeMode = 2;
                        worklist.EventID = (int)TMNotifyEventTDataGridView.CurrentRow.Cells["TMNotifyEventID"].Value;
                        worklist.EventType = 1;
                        worklist.EventContent = TMNotifyEventTDataGridView.CurrentRow.Cells["NotifyEventContent"].Value.ToString();
                        worklist.Show();
                    }
                    break;
                case "toolStripButton_OrientationEvent":
                    Public.Utility.SsplitContainerHorizontal(ref splitContainer4);
                    break;
            }

        }

        #endregion

        #region TMNotifyEventTDataGridView_CellDoubleClick
        private void TMNotifyEventTDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != -1 && e.RowIndex != -1)
            {
                if (TMNotifyEventTDataGridView.CurrentRow != null)
                {
                    if (myPermission.UserPermission.HasFlag(PermissionTypes.Modify))//判斷權限
                    {
                        contextMenuStrip_Event1_ItemClicked(contextMenuStrip_Event1, new ToolStripItemClickedEventArgs(EditNotifytoolStripMenuItem));
                    }
                }
            }
        }
        #endregion

        #region  ===============but_Search_Click===================
        private void but_Search_Click(object sender, EventArgs e)
        {
            but_Search.Enabled = false;

            string strSQL = Public.CommonFunctions.GetSQLScript(QueryFilter1, QueryFilter2, rb_and.Checked ? " and " : " or ", userControlFilterDate1);

            Public.CTrademarkPublicFunction.GetTrademarkList(strSQL, ref DT_TrademarkList);

            but_Search.Enabled = true;
        }
        #endregion



        private void but_UpData_Click(object sender, EventArgs e)
        {
            RefrashDataTable(0);
        }


        #region ============請款費用記錄快顯============
        private void contextMenuStrip_Fee_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            contextMenuStrip_Fee.Visible = false;

            switch (e.ClickedItem.Name)
            {
                case "bindingNavigatorAddNewItem_Fee":
                case "toolStripMenuItem_BillingAdd":  //請款新增費用

                    if (trademarkManagementTDataGridView.Rows.Count > 0)
                    {
                        AddFrom.AddTrademarkFee fee = new AddFrom.AddTrademarkFee();
                        fee.TrademarkID = (int)trademarkManagementTDataGridView.CurrentRow.Cells["TrademarkID"].Value;
                        fee.Text = fee.Text + "--" + trademarkManagementTDataGridView.CurrentRow.Cells["TrademarkNo"].Value.ToString();
                        fee.CountrySymbol = trademarkManagementTDataGridView.CurrentRow.Cells["CountrySymbol"].Value.ToString();
                        fee.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("請先指定申請案       ", "提示訊息", MessageBoxButtons.OK);
                        return;
                    }

                    break;
                case "bindingNavigatorDeleteItem_Fee":
                case "toolStripMenuItem_BillingDel":  //刪除請款費用
                    if (GridView_Fee.CurrentRow != null)
                    {
                        //判斷該筆是否已經關帳
                        if (GridView_Fee.CurrentRow.Cells["IsClosing"].Value == DBNull.Value || (bool)GridView_Fee.CurrentRow.Cells["IsClosing"].Value != true)
                        {
                            //鎖定資料
                            int iLocker = Public.Utility.GetRecordAuth("TrademarkFeeT", "FeeKEY=" + GridView_Fee.CurrentRow.Cells["FeeKEY"].Value.ToString());
                            if (iLocker == -1 || iLocker == iWorkerID)
                            {
                                if (iLocker != iWorkerID)
                                {
                                    Public.Utility.LockRecordAuth("TrademarkFeeT", iWorkerID, "FeeKEY=" + GridView_Fee.CurrentRow.Cells["FeeKEY"].Value.ToString());
                                }
                                if (MessageBox.Show("是否確定刪除", "確認視窗", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                                {
                                    int iFeeKey = (int)GridView_Fee.CurrentRow.Cells["FeeKEY"].Value;
                                    Public.CTrademarkFee DelFee = new Public.CTrademarkFee();
                                    Public.CTrademarkFee.ReadOne(iFeeKey, ref DelFee);

                                    Public.CTrademarkManagement tm = new Public.CTrademarkManagement();
                                    Public.CTrademarkManagement.ReadOne(property_TrademarkID, ref tm);

                                    //刪除記錄檔    
                                    Public.CSystemLogT log = new Public.CSystemLogT();
                                    log.DelTime = DateTime.Now;
                                    log.DelWorkerKey = Properties.Settings.Default.WorkerKEY;
                                    log.DelWorker = Properties.Settings.Default.WorkerName;
                                    //string[] str = DelFee.GetInsertString(iFeeKey);
                                    //log.TableName = str[2];
                                    //log.DelContent_InsertColumn = str[0];
                                    //log.DelContent_InsertSQL = str[1];
                                    log.DelContent = string.Format("商標案號:{6}\r\n商標名稱:{7}\r\n費用內容:{0}\r\n請款日期:{1}\r\n收據日期:{2}\r\n請款合計:{3}\r\n幣別:{4}\r\n請款單號:{5}", DelFee.FeeSubject, DelFee.RDate, DelFee.ReceiptDate, DelFee.Totall, DelFee.TMoney, DelFee.PPP, tm.TrademarkNo, tm.TrademarkName);
                                    log.DelTitle = string.Format("刪除「{0}」資料【請款記錄-{1}】", this.Text, DelFee.FeeSubject);
                                    log.Create();


                                    DelFee.Delete(iFeeKey);
                                    GridView_Fee.Rows.Remove(GridView_Fee.CurrentRow);
                                    dt_TrademarkFeeT.AcceptChanges();
                                    MessageBox.Show("刪除請款費用記錄成功", "提示訊息", MessageBoxButtons.OK);
                                }

                                //當只有一筆資料而刪除時， GridView_Fee.CurrentRow = null
                                if (GridView_Fee.CurrentRow != null)
                                {
                                    Public.Utility.NuLockRecordAuth("TrademarkFeeT", "FeeKEY=" + GridView_Fee.CurrentRow.Cells["FeeKEY"].Value.ToString());
                                }
                            }
                            else
                            {
                                if (iLocker != -1)//無人使用中
                                {
                                    Worker_Model worker = new Worker_Model();
                                    Worker_Model.ReadOne(iLocker, ref worker);
                                    MessageBox.Show("很抱歉~~   目前該筆資料正被【" + worker.EmployeeName + "】使用中，請等候!!\r\n 謝謝", "提示訊息");
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("該筆付款記錄已經被關帳，請向會計部門確認", "提示訊息", MessageBoxButtons.OK);
                        }
                    }

                    break;
                case "上傳費用相關文件ToolStripMenuItem":  //上傳請款費用相關文件

                    if (GridView_Fee.CurrentRow != null)
                    {
                        bool bConnectionFile = Properties.Settings.Default.IsFileServerConnection;
                        if (bConnectionFile)
                        {
                            US.UpFileList upfile = new US.UpFileList();
                            upfile.Text = trademarkManagementTDataGridView.CurrentRow.Cells["TrademarkNo"].Value.ToString() + "  上傳請款費用相關文件";
                            upfile.UploadMode = 4;
                            upfile.MainFileKey = property_TrademarkID;
                            upfile.ChildFileKey = (int)GridView_Fee.CurrentRow.Cells["FeeKEY"].Value;
                            upfile.MainFileType = 8;
                            upfile.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("請確認檔案上傳路徑是否有正常連結!!");
                        }
                    }

                    break;

                case "印請款單ToolStripMenuItem":  //印請款單
                    if (GridView_Fee.CurrentRow != null)
                    {
                        if (trademarkManagementTDataGridView.CurrentRow.Cells["ApplicantNames"].Value == null)
                        {
                            MessageBox.Show("申請人不得為空值，請確認", "提示訊息");
                            return;
                        }

                        ReportView.FeeReport fee = new LawtechPTSystem.ReportView.FeeReport();
                        fee.ModeType = 2;
                        fee.FeeKEY = (int)GridView_Fee.CurrentRow.Cells["FeeKEY"].Value;

                        fee.ApplicantKeys = trademarkManagementTDataGridView.CurrentRow.Cells["ApplicantKeys"].Value.ToString();
                        fee.ApplicantNames = trademarkManagementTDataGridView.CurrentRow.Cells["ApplicantNames"].Value.ToString();

                        fee.PatentID = (int)trademarkManagementTDataGridView.CurrentRow.Cells["TrademarkID"].Value;
                        fee.Show();
                    }
                    else
                    {
                        MessageBox.Show("無資料        ", "提示訊息", MessageBoxButtons.OK);
                    }
                    break;
                case "ToolStripMenuItem_FeeReceiptReport"://印收據
                    if (GridView_Fee.CurrentRow != null)
                    {
                        ReportView.FeeReceiptReport feereport = new ReportView.FeeReceiptReport();
                        feereport.ModeType = 2;
                        feereport.FeeKEY = (int)GridView_Fee.CurrentRow.Cells["FeeKEY"].Value;
                        feereport.PatentID = (int)trademarkManagementTDataGridView.CurrentRow.Cells["TrademarkID"].Value;
                        feereport.Show();
                    }
                    break;

                case "開啟費用相關文件ToolStripMenuItem":
                    if (GridView_Fee.CurrentRow != null)
                    {
                        bool bConnectionFile = Properties.Settings.Default.IsFileServerConnection;
                        if (bConnectionFile)
                        {
                            ViewUpdateFileList subForm = new ViewUpdateFileList();
                            subForm.Text = trademarkManagementTDataGridView.CurrentRow.Cells["TrademarkNo"].Value.ToString() + "的請款費用相關文件";
                            subForm.FileKind = 4;
                            subForm.FileType = 8;
                            subForm.MainParentID = (int)trademarkManagementTDataGridView.CurrentRow.Cells["TrademarkID"].Value;
                            subForm.Child_ID = (int)GridView_Fee.CurrentRow.Cells["FeeKEY"].Value;
                            subForm.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("請確認檔案上傳路徑是否有正常連結!!");
                        }
                    }
                    break;
                case "toolStripMenuItem_BillingEdit":
                case "bindingNavigatorEditItem_Fee":
                    if (GridView_Fee.CurrentRow != null)
                    {
                        //判斷該筆是否已經關帳
                        if (GridView_Fee.CurrentRow.Cells["IsClosing"].Value == DBNull.Value || (bool)GridView_Fee.CurrentRow.Cells["IsClosing"].Value != true)
                        {
                            int iLocker = Public.Utility.GetRecordAuth("TrademarkFeeT", "FeeKEY=" + GridView_Fee.CurrentRow.Cells["FeeKEY"].Value.ToString());
                            if (iLocker == -1 || iLocker == iWorkerID)
                            {
                                if (iLocker != iWorkerID)
                                {
                                    Public.Utility.LockRecordAuth("TrademarkFeeT", iWorkerID, "FeeKEY=" + GridView_Fee.CurrentRow.Cells["FeeKEY"].Value.ToString());
                                }
                                EditForm.EditTrademarkFee edit = new LawtechPTSystem.EditForm.EditTrademarkFee();
                                edit.property_FeeKEY = (int)GridView_Fee.CurrentRow.Cells["FeeKEY"].Value;
                                edit.CountrySymbol = trademarkManagementTDataGridView.CurrentRow.Cells["CountrySymbol"].Value.ToString();
                                edit.ShowDialog();

                                //Public.Utility.NuLockRecordAuth("TrademarkFeeT", "FeeKEY=" + GridView_Fee.CurrentRow.Cells["FeeKEY"].Value.ToString());
                            }
                            else
                            {
                                if (iLocker != -1)//無人使用中
                                {
                                    Worker_Model worker = new Worker_Model();
                                    Worker_Model.ReadOne(iLocker, ref worker);
                                    MessageBox.Show("很抱歉~~   目前該筆資料正被【" + worker.EmployeeName + "】使用中，請等候!!\r\n 謝謝", "提示訊息");
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("該筆付款記錄已經被關帳，請向會計部門確認", "提示訊息", MessageBoxButtons.OK);
                        }
                    }
                    break;

                case "toolStripMenuItem_SendMailFee":
                    if (GridView_Fee.CurrentRow != null)
                    {
                        US.NotificationLetter letter = new LawtechPTSystem.US.NotificationLetter();
                        letter.ApplicantKeys = trademarkManagementTDataGridView.CurrentRow.Cells["ApplicantKeys"].Value.ToString();
                        letter.MainKey = (int)trademarkManagementTDataGridView.CurrentRow.Cells["TrademarkID"].Value;
                        letter.CaseKey = GridView_Fee.CurrentRow.Cells["FeeKEY"].Value != null ? (int)GridView_Fee.CurrentRow.Cells["FeeKEY"].Value : -1;
                        letter.DelegateType = trademarkManagementTDataGridView.CurrentRow.Cells["DelegateType"].Value.ToString() != "" ? (int)trademarkManagementTDataGridView.CurrentRow.Cells["DelegateType"].Value : -1;
                        letter.Attorney = trademarkManagementTDataGridView.CurrentRow.Cells["OutsourcingAttorney"].Value.ToString() != "" ? (int)trademarkManagementTDataGridView.CurrentRow.Cells["OutsourcingAttorney"].Value : -1;
                        letter.EmailSampleType = "TrademarkFee";
                        letter.CaseNo = trademarkManagementTDataGridView.CurrentRow.Cells["TrademarkNo"].Value.ToString();
                        letter.Text += "(" + trademarkManagementTDataGridView.CurrentRow.Cells["TrademarkNo"].Value.ToString() + ")";
                        letter.ShowDialog();
                    }
                    break;
                case "toolStripMenuItem_FeeSetGridColumn":
                    SetGridColumnT gc = new SetGridColumnT();
                    gc.CurrentGridSymboID = GridView_Fee.Tag.ToString();
                    gc.TitleName = "請款記錄";
                    gc.Show();
                    break;
                case "toolStripButton__OrientationFee":
                    Public.Utility.SsplitContainerHorizontal(ref splitContainer5);
                    break;
            }


        }
        #endregion

        #region GridView_Fee_CellDoubleClick
        private void GridView_Fee_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != -1 && e.RowIndex != -1)
            {
                if (GridView_Fee.CurrentRow != null)
                {
                    if (myPermission.UserPermission.HasFlag(PermissionTypes.Modify))//判斷權限
                    {
                        contextMenuStrip_Fee_ItemClicked(contextMenuStrip_Fee, new ToolStripItemClickedEventArgs(toolStripMenuItem_BillingEdit));
                    }
                }

            }
        }
        #endregion

        #region ============付款費用記錄快顯============
        private void contextMenuStrip_Billing_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            contextMenuStrip_Billing.Visible = false;

            switch (e.ClickedItem.Name)
            {
                case "toolStripButton_PayRecordAdd":
                case "toolStripMenuItem_PaymentAdd":  //付款新增費用

                    if (trademarkManagementTDataGridView.CurrentRow != null)
                    {
                        AddFrom.AddTrademarkPayment Payment = new AddFrom.AddTrademarkPayment();
                        Payment.TrademarkID = (int)trademarkManagementTDataGridView.CurrentRow.Cells["TrademarkID"].Value;
                        Payment.CountrySymbol = trademarkManagementTDataGridView.CurrentRow.Cells["CountrySymbol"].Value.ToString();
                        Payment.Text = Payment.Text + "--" + trademarkManagementTDataGridView.CurrentRow.Cells["TrademarkNo"].Value.ToString();
                        Payment.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("請先指定申請案       ", "提示訊息", MessageBoxButtons.OK);
                        return;
                    }

                    break;

                case "toolStripButton_PayRecordDel":
                case "toolStripMenuItem_PaymentDel":  //刪除付款費用

                    if (dataGridView_Billing.CurrentRow != null)
                    {
                        //判斷該筆是否已經關帳
                        if ((bool)dataGridView_Billing.CurrentRow.Cells["IsClosingPayment"].Value)
                        {
                            MessageBox.Show("該筆付款記錄【" + dataGridView_Billing.CurrentRow.Cells["BillingNo"].Value.ToString() + "】已經被關帳，請洽帳務主管", "提示訊息", MessageBoxButtons.OK);
                            return;
                        }

                        if (dataGridView_Billing.CurrentRow.Cells["BillingNo"].Value.ToString() != "")
                        {
                            MessageBox.Show("已登錄了請款單號【" + dataGridView_Billing.CurrentRow.Cells["BillingNo"].Value.ToString() + "】，若要刪除，請洽帳務人員", "提示訊息", MessageBoxButtons.OK);
                            return;
                        }

                        int iLocker = Public.Utility.GetRecordAuth("TrademarkPaymentT", "PaymentID=" + dataGridView_Billing.CurrentRow.Cells["PaymentID"].Value.ToString());
                        if (iLocker == -1 || iLocker == iWorkerID)
                        {
                            if (iLocker != iWorkerID)
                            {
                                Public.Utility.LockRecordAuth("TrademarkPaymentT", iWorkerID, "PaymentID=" + dataGridView_Billing.CurrentRow.Cells["PaymentID"].Value.ToString());
                            }

                            if (MessageBox.Show("是否確定刪除", "確認視窗", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                            {
                                int iPaymentIDK = (int)dataGridView_Billing.CurrentRow.Cells["PaymentID"].Value;
                                Public.CTrademarkPayment DelBilling = new Public.CTrademarkPayment();
                                Public.CTrademarkPayment.ReadOne(iPaymentIDK, ref DelBilling);

                                Public.CTrademarkManagement tm = new Public.CTrademarkManagement();
                                Public.CTrademarkManagement.ReadOne(property_TrademarkID, ref tm);

                                //刪除記錄檔    
                                Public.CSystemLogT log = new Public.CSystemLogT();
                                log.DelTime = DateTime.Now;
                                log.DelWorkerKey = Properties.Settings.Default.WorkerKEY;
                                log.DelWorker = Properties.Settings.Default.WorkerName;
                                log.DelContent = string.Format("商標案號:{6}\r\n商標名稱:{7}\r\n費用內容:{0}\r\n收件日期:{1}\r\n付款期限:{2}\r\n付款日期:{3}\r\n請款單編號:{4}\r\n實付金額:{5}", DelBilling.FeeSubject, DelBilling.ReciveDate, DelBilling.PayDueDate, DelBilling.PaymentDate, DelBilling.BillingNo, DelBilling.ActuallyPay.HasValue ? DelBilling.ActuallyPay.Value.ToString("#,##0.##") : "0", tm.TrademarkNo, tm.TrademarkName);
                                log.DelTitle = string.Format("刪除「{0}」資料【付款記錄-{1}】", this.Text, DelBilling.FeeSubject);
                                log.Create();

                                DelBilling.Delete(iPaymentIDK);
                                dataGridView_Billing.Rows.Remove(dataGridView_Billing.CurrentRow);

                                MessageBox.Show("刪除付款費用記錄成功", "提示訊息", MessageBoxButtons.OK);
                            }

                            if (dataGridView_Billing.CurrentRow != null)
                            {
                                Public.Utility.NuLockRecordAuth("TrademarkPaymentT", "PaymentID=" + GridView_Fee.CurrentRow.Cells["PaymentID"].Value.ToString());
                            }
                        }
                        else
                        {
                            if (iLocker != -1)//無人使用中
                            {
                                Worker_Model worker = new Worker_Model();
                                Worker_Model.ReadOne(iLocker, ref worker);
                                MessageBox.Show("很抱歉~~   目前該筆資料正被【" + worker.EmployeeName + "】使用中，請等候!!\r\n 謝謝", "提示訊息");
                            }
                        }


                    }

                    break;
                case "toolStripMenuItem_PaymentUpdateFile":  //上傳付款費用相關文件

                    if (dataGridView_Billing.CurrentRow != null)
                    {
                        bool bConnectionFile = Properties.Settings.Default.IsFileServerConnection;
                        if (bConnectionFile)
                        {
                            US.UpFileList upfile = new US.UpFileList();
                            upfile.Text = trademarkManagementTDataGridView.CurrentRow.Cells["TrademarkNo"].Value.ToString() + "  上傳付款費用相關文件";
                            upfile.UploadMode = 4;
                            upfile.MainFileKey = property_TrademarkID;
                            upfile.ChildFileKey = (int)dataGridView_Billing.CurrentRow.Cells["PaymentID"].Value;
                            upfile.MainFileType = 9;
                            upfile.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("請確認檔案上傳路徑是否有正常連結!!");
                        }
                    }

                    break;

                case "toolStripMenuItemPaymentReport": //付款申請單
                    if (dataGridView_Billing.CurrentRow != null)
                    {
                        ReportView.PaymentReport payment = new LawtechPTSystem.ReportView.PaymentReport();

                        payment.Worker = Properties.Settings.Default.WorkerName;
                        string strDes = string.Format(@"
案件編號：{0} 
案件名稱：{1}
費用科目：{2} 
           服務費： {3}  {4}
             官費： {3}  {5}
             雜費： {3}  {6}
       __________________________
         金額小計： {3}  {7}", trademarkManagementTDataGridView.CurrentRow.Cells["TrademarkNo"].Value.ToString(),
                        trademarkManagementTDataGridView.CurrentRow.Cells["TrademarkName"].Value.ToString(),
                        txt_PayFeeSubject.Text, txt_PayIMoney.Text,
                        txt_IServiceFee.Text, txt_GovFee.Text,
                        txt_OtherFee.Text, txt_PayTotall.Text);

                        payment.Description = strDes;
                        payment.Department = "商 標 部";
                        payment.Amount = txt_PayTotall.Text;
                        payment.Reciver = txt_Attorney.Text;
                        payment.IMoney = txt_PayIMoney.Text;
                        payment.InvoiceNo = txt_IReceiptNo.Text;
                        payment.CountryName = trademarkManagementTDataGridView.CurrentRow.Cells["CountryName"].Value.ToString();
                        payment.ApplicantDate = DateTime.Now.ToString("yyyy/MM/dd");
                        payment.ReciveDate = maskedTextBox_ReciveDate.Text;
                        payment.PayDueDate = maskedTextBox_PayDueDate.Text;
                        payment.Show();
                    }
                    else
                    {
                        MessageBox.Show("無資料", "提示訊息", MessageBoxButtons.OK);
                    }
                    break;


                case "toolStripMenuItem_PaymentUpdateFileList":
                    if (dataGridView_Billing.CurrentRow != null)
                    {
                        bool bConnectionFile = Properties.Settings.Default.IsFileServerConnection;
                        if (bConnectionFile)
                        {
                            ViewUpdateFileList subForm = new ViewUpdateFileList();
                            subForm.Text = trademarkManagementTDataGridView.CurrentRow.Cells["TrademarkNo"].Value.ToString() + "的付款費用相關文件";
                            subForm.FileKind = 4;
                            subForm.FileType = 9;
                            subForm.MainParentID = (int)trademarkManagementTDataGridView.CurrentRow.Cells["TrademarkID"].Value;
                            subForm.Child_ID = (int)dataGridView_Billing.CurrentRow.Cells["PaymentID"].Value;
                            subForm.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("請確認檔案上傳路徑是否有正常連結!!");
                        }
                    }
                    break;
                case "toolStripMenuItem_PaymentEdit":
                case "toolStripButton_PayRecordEdit":
                    if (dataGridView_Billing.CurrentRow != null)
                    {
                        //判斷該筆是否已經關帳
                        if (dataGridView_Billing.CurrentRow.Cells["IsClosingPayment"].Value != DBNull.Value && (bool)dataGridView_Billing.CurrentRow.Cells["IsClosingPayment"].Value)
                        {
                            MessageBox.Show("該筆付款記錄【" + dataGridView_Billing.CurrentRow.Cells["BillingNo"].Value.ToString() + "】已經被關帳，請洽帳務主管", "提示訊息", MessageBoxButtons.OK);
                            return;
                        }

                        if (dataGridView_Billing.CurrentRow.Cells["BillingNo"].Value.ToString() != "")
                        {
                            MessageBox.Show("已登錄了請款單號【" + dataGridView_Billing.CurrentRow.Cells["BillingNo"].Value.ToString() + "】，若要刪除，請洽帳務人員", "提示訊息", MessageBoxButtons.OK);
                            return;
                        }


                        int iLocker = Public.Utility.GetRecordAuth("TrademarkPaymentT", "PaymentID=" + dataGridView_Billing.CurrentRow.Cells["PaymentID"].Value.ToString());
                        if (iLocker == -1 || iLocker == iWorkerID)
                        {
                            if (iLocker != iWorkerID)
                            {
                                Public.Utility.LockRecordAuth("TrademarkPaymentT", iWorkerID, "PaymentID=" + dataGridView_Billing.CurrentRow.Cells["PaymentID"].Value.ToString());
                            }
                            EditForm.EditTrademarkPayment edit = new LawtechPTSystem.EditForm.EditTrademarkPayment();
                            edit.CountrySymbol = trademarkManagementTDataGridView.CurrentRow.Cells["CountrySymbol"].Value.ToString();
                            edit.property_PaymentID = (int)dataGridView_Billing.CurrentRow.Cells["PaymentID"].Value;
                            edit.ShowDialog();

                            //Public.Utility.NuLockRecordAuth("TrademarkPaymentT", "PaymentID=" + GridView_Fee.CurrentRow.Cells["PaymentID"].Value.ToString());
                        }
                        else
                        {
                            if (iLocker != -1)//無人使用中
                            {
                                Worker_Model worker = new Worker_Model();
                                Worker_Model.ReadOne(iLocker, ref worker);
                                MessageBox.Show("很抱歉~~   目前該筆資料正被【" + worker.EmployeeName + "】使用中，請等候!!\r\n 謝謝", "提示訊息");
                            }
                        }

                    }
                    break;

                case "toolStripMenuItem_SendMailPayment":
                    if (dataGridView_Billing.CurrentRow != null)
                    {
                        US.NotificationLetter letter = new LawtechPTSystem.US.NotificationLetter();
                        letter.ApplicantKeys = trademarkManagementTDataGridView.CurrentRow.Cells["ApplicantKeys"].Value.ToString();
                        letter.MainKey = (int)trademarkManagementTDataGridView.CurrentRow.Cells["TrademarkID"].Value;
                        letter.CaseKey = dataGridView_Billing.CurrentRow.Cells["PaymentID"].Value != null ? (int)dataGridView_Billing.CurrentRow.Cells["PaymentID"].Value : -1;
                        letter.DelegateType = trademarkManagementTDataGridView.CurrentRow.Cells["DelegateType"].Value.ToString() != "" ? (int)trademarkManagementTDataGridView.CurrentRow.Cells["DelegateType"].Value : -1;
                        letter.Attorney = dataGridView_Billing.CurrentRow.Cells["AttorneyPayment"].Value.ToString() != "" ? (int)dataGridView_Billing.CurrentRow.Cells["AttorneyPayment"].Value : -1;
                        letter.EmailSampleType = "TrademarkPayment";
                        letter.CaseNo = trademarkManagementTDataGridView.CurrentRow.Cells["TrademarkNo"].Value.ToString();
                        letter.Text += "(" + trademarkManagementTDataGridView.CurrentRow.Cells["TrademarkNo"].Value.ToString() + ")";
                        letter.ShowDialog();
                    }
                    break;
                case "toolStripMenuItem_PaymentSetGridColumn":
                    SetGridColumnT gc = new SetGridColumnT();
                    gc.CurrentGridSymboID = dataGridView_Billing.Tag.ToString();
                    gc.TitleName = "付款記錄";
                    gc.Show();
                    break;
                case "toolStripButton__OrientationPayment":
                    Public.Utility.SsplitContainerHorizontal(ref splitContainer6);
                    break;
            }
        }
        #endregion

        #region dataGridView_Billing_CellDoubleClick
        private void dataGridView_Billing_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != -1 && e.RowIndex != -1)
            {
                if (dataGridView_Billing.CurrentRow != null)
                {
                    if (myPermission.UserPermission.HasFlag(PermissionTypes.Modify))//判斷權限
                    {
                        contextMenuStrip_Billing_ItemClicked(contextMenuStrip_Billing, new ToolStripItemClickedEventArgs(toolStripMenuItem_PaymentEdit));
                    }
                }
            }
        }
        #endregion

        #region ============預估成本記錄快顯============
        private void contextMenuStrip_EstimateCost_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            contextMenuStrip_EstimateCost.Visible = false;

            switch (e.ClickedItem.Name)
            {
                case "toolStripButton_ES_Add":
                case "toolStripMenuItem_Add_ES":  //新增預估成本

                    if (trademarkManagementTDataGridView.Rows.Count > 0)
                    {
                        AddFrom.AddTrademarkEstimateCost fee = new AddFrom.AddTrademarkEstimateCost();
                        fee.TrademarkID = (int)trademarkManagementTDataGridView.CurrentRow.Cells["TrademarkID"].Value;
                        fee.Text = fee.Text + "--" + trademarkManagementTDataGridView.CurrentRow.Cells["TrademarkNo"].Value.ToString();
                        fee.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("請先指定商標申請案       ", "提示訊息", MessageBoxButtons.OK);
                        return;
                    }

                    break;
                case "toolStripMenuItem_Del_ES":
                case "toolStripButton_ES_Del":  //刪除預估成本

                    if (dataGridView_EstimateCost.Rows.Count > 0)
                    {
                        int iLocker = Public.Utility.GetRecordAuth("TrademarkEstimateCostT", "TMEstimateCostID=" + dataGridView_EstimateCost.CurrentRow.Cells["TMEstimateCostID"].Value.ToString());
                        if (iLocker == -1 || iLocker == iWorkerID)
                        {

                            if (MessageBox.Show("是否確定刪除", "確認視窗", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                            {
                                int iTMEstimateCostID = (int)dataGridView_EstimateCost.CurrentRow.Cells["TMEstimateCostID"].Value;
                                Public.CTrademarkEstimateCost DelEstimateCost = new Public.CTrademarkEstimateCost();
                                Public.CTrademarkEstimateCost.ReadOne(iTMEstimateCostID, ref DelEstimateCost);


                                //刪除記錄檔    
                                Public.CSystemLogT log = new Public.CSystemLogT();
                                log.DelTime = DateTime.Now;
                                log.DelWorkerKey = Properties.Settings.Default.WorkerKEY;
                                log.DelWorker = Properties.Settings.Default.WorkerName;
                                //string[] str = DelEstimateCost.GetInsertString(iTMEstimateCostID);
                                //log.TableName = str[2];
                                //log.DelContent_InsertColumn = str[0];
                                //log.DelContent_InsertSQL = str[1];
                                log.DelContent = string.Format("費用內容:{0}\r\n預估成本:{1}\r\n預估利潤:{2}\r\n實際報價:{3}", DelEstimateCost.FeeSubject, DelEstimateCost.EstimateCost.Value.ToString("#,##0.##"), DelEstimateCost.EstimateProfit.Value.ToString("#,##0.##"), DelEstimateCost.RealPrice.Value.ToString("#,##0.##"));
                                log.DelTitle = string.Format("刪除商標預估費用記錄資料【{0}】", DelEstimateCost.FeeSubject);
                                log.Create();


                                DelEstimateCost.Delete(iTMEstimateCostID);
                                dataGridView_EstimateCost.Rows.Remove(dataGridView_EstimateCost.CurrentRow);

                                MessageBox.Show("刪除預估成本記錄成功", "提示訊息", MessageBoxButtons.OK);
                            }
                        }
                        else
                        {
                            if (iLocker != -1)//無人使用中
                            {
                                Worker_Model worker = new Worker_Model();
                                Worker_Model.ReadOne(iLocker, ref worker);
                                MessageBox.Show("很抱歉~~   目前該筆資料正被【" + worker.EmployeeName + "】使用中，請等候!!\r\n 謝謝", "提示訊息");
                            }
                        }
                    }

                    break;
                case "toolStripMenuItem_Edit_ES":
                case "toolStripButton_ES_Edit":
                    if (dataGridView_EstimateCost.CurrentRow != null)
                    {
                        int iLocker = Public.Utility.GetRecordAuth("TrademarkEstimateCostT", "TMEstimateCostID=" + dataGridView_EstimateCost.CurrentRow.Cells["TMEstimateCostID"].Value.ToString());
                        if (iLocker == -1 || iLocker == iWorkerID)
                        {
                            if (iLocker != iWorkerID)
                            {
                                Public.Utility.LockRecordAuth("TrademarkEstimateCostT", iWorkerID, "TMEstimateCostID=" + dataGridView_EstimateCost.CurrentRow.Cells["TMEstimateCostID"].Value.ToString());
                            }
                            EditForm.EditTrademarkEstimateCost edit = new LawtechPTSystem.EditForm.EditTrademarkEstimateCost();
                            edit.TMEstimateCostID = (int)dataGridView_EstimateCost.CurrentRow.Cells["TMEstimateCostID"].Value;
                            edit.ShowDialog();
                        }
                        else
                        {
                            if (iLocker != -1)//無人使用中
                            {
                                Worker_Model worker = new Worker_Model();
                                Worker_Model.ReadOne(iLocker, ref worker);
                                MessageBox.Show("很抱歉~~   目前該筆資料正被【" + worker.EmployeeName + "】使用中，請等候!!\r\n 謝謝", "提示訊息");
                            }
                        }
                    }
                    break;

            }
        }
        #endregion

        #region dataGridView_EstimateCost_CellDoubleClick
        private void dataGridView_EstimateCost_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != -1 && e.RowIndex != -1)
            {
                if (dataGridView_EstimateCost.CurrentRow != null)
                {
                    if (myPermission.UserPermission.HasFlag(PermissionTypes.Modify))//判斷權限
                    {
                        contextMenuStrip_EstimateCost_ItemClicked(contextMenuStrip_EstimateCost, new ToolStripItemClickedEventArgs(toolStripMenuItem_Edit_ES));
                    }
                }
            }
        }
        #endregion

        #region maskedTextBox_S_DoubleClick
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

        #region ============LinkLabel Pup============
        private void linkLabel_mome_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LinkLabel link = (LinkLabel)sender;
            US.PopMemo pop;
            switch (link.Name)
            {
                case "linkLabel_EarlyPriorityNo":
                    pop = new LawtechPTSystem.US.PopMemo(txt_EarlyPriorityNo, true, link.Text);
                    break;
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
                case "linkLabel_RegisterProductItems":
                    pop = new LawtechPTSystem.US.PopMemo(txt_RegisterProductItems, true, link.Text);
                    break;
                case "linkLabel_MainCustomer":
                    pop = new LawtechPTSystem.US.PopMemo(txt_MainCustomer, true, link.Text);
                    break;
                case "linkLabel_AttorneyFirm":
                    pop = new LawtechPTSystem.US.PopMemo(txt_AttorneyFirm, true, link.Text);
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

        #endregion

        #region pictureBox1_DoubleClick
        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            if (trademarkManagementTDataGridView.CurrentRow != null && trademarkManagementTDataGridView.CurrentRow.Cells["PicPath"].Value != DBNull.Value && trademarkManagementTDataGridView.CurrentRow.Cells["PicPath"].Value.ToString().Trim() != "")
            {
                try
                {
                    string sPath = property_TMrootPath + "\\" + trademarkManagementTDataGridView.CurrentRow.Cells["PicPath"].Value.ToString(); ;
                    Public.Utility.ProcessStart(sPath);
                }
                catch (System.Exception EX)
                {
                    MessageBox.Show(EX.Message, "提示訊息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        #endregion

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pictureBox1_DoubleClick(null, null);
        }

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

        #region button1_Click
        private void button1_Click(object sender, EventArgs e)
        {
            Public.DLL dll = new Public.DLL();
            DataTable dt = dll.SqlDataAdapterDataTable("select  * from TM_TEST  where TM_NO in(select TrademarkNo from  TrademarkManagementT )  and CaseType='延展' ");

            for (int iRow = 0; iRow < dt.Rows.Count; iRow++)
            {
                string TMno = dt.Rows[iRow]["TM_NO"].ToString();
                Public.CTrademarkManagement tm = new Public.CTrademarkManagement();
                Public.CTrademarkManagement.ReadOne("TrademarkNo= '" + TMno + "'", ref tm);
                int iTrademarkID = tm.TrademarkID;


                //tm.Remarks = tm.Remarks;

                string[] ary ={
                             dt.Rows[iRow]["Application"].ToString(),
                             dt.Rows[iRow]["ReviewComments"].ToString() ,
                             dt.Rows[iRow]["ReviewComments2"].ToString(),
                             dt.Rows[iRow]["ReviewComments3"].ToString(),
                            dt.Rows[iRow]["GiveUp"].ToString(),
                            dt.Rows[iRow]["Approved"].ToString(),
                            dt.Rows[iRow]["Licensing"].ToString()};

                int[] status = { 1, 2, 3, 4, 5, 6, 7 };
                for (int iCol = 0; iCol < ary.Length; iCol++)//法定階段
                {
                    string[] notify = ary[iCol].Split('#');

                    for (int iNo = 0; iNo < notify.Length; iNo++)
                    {
                        if (notify[iNo] != "")//細部程序
                        {
                            string[] content = notify[iNo].Split('*');
                            if (content.Length == 2)
                            {
                                Public.CTrademarkNotifyEvent add = new Public.CTrademarkNotifyEvent();

                                add.TrademarkID = iTrademarkID;
                                add.TMStatusID = status[iCol];

                                DateTime dtNotifyComitDate = new DateTime();
                                bool istime = DateTime.TryParse(content[0], out dtNotifyComitDate);
                                if (istime)
                                {
                                    add.NotifyComitDate = dtNotifyComitDate;
                                }

                                add.Result = content[1];
                                add.Create();
                            }
                        }
                    }

                }
            }
        }
        #endregion

        #region button2_Click
        //異議案
        private void button2_Click(object sender, EventArgs e)
        {
            //Public.DLL dll = new Public.DLL();
            //DataTable dt = dll.SqlDataAdapterDataTable("select  * from TM_TEST  where TM_NO in(select TrademarkNo from  TrademarkControversyManagementT )  and CaseType='異議'");

            //for (int iRow = 0; iRow < dt.Rows.Count; iRow++)
            //{
            //    string TMno = dt.Rows[iRow]["TM_NO"].ToString();
            //    Public.CTrademarkControversyManagement tm = new Public.CTrademarkControversyManagement("TrademarkNo= '" + TMno + "'");
            //    int iTrademarkID = (int)tm.GetDataTable().Rows[0]["TrademarkControversyID"];
            //    tm.SetCurrent(iTrademarkID);

            //    //tm.Remarks = tm.Remarks;

            //    string[] ary ={
            //                 dt.Rows[iRow]["ReviewComments"].ToString() ,
            //                 dt.Rows[iRow]["ReviewComments2"].ToString(),                            
            //                dt.Rows[iRow]["GiveUp"].ToString(),
            //                dt.Rows[iRow]["Approved"].ToString(),
            //                dt.Rows[iRow]["Licensing"].ToString()};
            //    int[] status = { 2, 3,  5, 6, 7 };

            //    for (int iCol = 0; iCol < ary.Length; iCol++)//法定階段
            //    {
            //        string[] notify = ary[iCol].Split('#');

            //        for (int iNo = 0; iNo < notify.Length; iNo++)
            //        {
            //            if (notify[iNo] != "")//細部程序
            //            {
            //                string[] content = notify[iNo].Split('*');
            //                if (content.Length == 2)
            //                {
            //                    Public.CTrademarkControversyNotifyEvent add = new Public.CTrademarkControversyNotifyEvent("1=0");

            //                    add.TrademarkControversyID = iTrademarkID;
            //                    add.TMStatusID = status[iCol];

            //                    DateTime dtNotifyComitDate = new DateTime();
            //                    bool istime = DateTime.TryParse(content[0], out dtNotifyComitDate);
            //                    if (istime)
            //                    {
            //                        add.NotifyComitDate = dtNotifyComitDate;
            //                    }

            //                    add.Result = content[1];
            //                    add.Insert();
            //                }
            //            }
            //        }

            //    }
            //}
        }
        #endregion

        #region but_ShowDetail_Click
        private void but_ShowDetail_Click(object sender, EventArgs e)
        {
            if (!splitContainer1.Panel2Collapsed)
            {
                but_ShowDetail.Text = "開啟案件明細(Alt+E)";

                splitContainer1.Panel2Collapsed = true;
            }
            else
            {
                but_ShowDetail.Text = "關閉案件明細(Alt+E)";
                splitContainer1.Panel2Collapsed = false;
            }
        }
        #endregion

        #region  private void TrademarkMF_KeyDown(object sender, KeyEventArgs e)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TrademarkMF_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt)
            {
                if (e.KeyCode == Keys.E)
                {
                    but_ShowDetail_Click(null, null);
                }
            }
        }
        #endregion

        #region private void GridView_Fee_DataError(object sender, DataGridViewDataErrorEventArgs e)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GridView_Fee_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }
        #endregion

        private void contextMenuStrip_Fee_VisibleChanged(object sender, EventArgs e)
        {
            //是否啟用新增請款功能; 1: 停用 , 0:不停用
            if (toolStripMenuItem_BillingAdd.Visible == true)
            {
                toolStripMenuItem_BillingAdd.Enabled = !Properties.Settings.Default.EnableAddFee;
            }
        }

        private void contextMenuStrip_Billing_VisibleChanged(object sender, EventArgs e)
        {
            //是否啟用新增付款功能; 1: 停用 , 0:不停用
            if (toolStripMenuItem_PaymentAdd.Visible == true)
            {
                toolStripMenuItem_PaymentAdd.Enabled = !Properties.Settings.Default.EnableAddPayment;
            }
        }

        private void contextMenuStrip_TrademarkAnnuity_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            contextMenuStrip_TrademarkAnnuity.Visible = false;
            switch (e.ClickedItem.Name)
            {
                case "toolStripMenuItem_AnnuitySetColumn":
                    SetGridColumnT gc = new SetGridColumnT();
                    gc.CurrentGridSymboID = dataGridView_TrademarkAnnuity.Tag.ToString();
                    gc.TitleName = "智財局商標註冊案內容";
                    gc.Show();
                    break;
            }
        }

        #region private void dataGridView_AnnuityImage_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridView_AnnuityImage_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                string clumName = dataGridView_AnnuityImage.Columns[e.ColumnIndex].Name;
                switch (clumName)
                {
                    case "image_data_1":
                    case "image_data_2":
                    case "image_data_3":
                    case "image_data_4":
                    case "image_data_5":
                    case "image_data_6":
                    case "audio_filename":
                        if (dataGridView_AnnuityImage.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Trim() != "")
                        {
                            Public.Utility.ProcessStart(dataGridView_AnnuityImage.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                        }
                        break;
                }
            }
        } 
        #endregion


    }
}