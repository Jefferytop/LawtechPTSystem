using System;
using System.Data;
using System.Windows.Forms;
using System.IO;
using System.Threading.Tasks;
namespace LawtechPTSystem.SubFrom
{
    /// <summary>
    /// 專利--申請案基本資料管理
    /// </summary>
    public partial class PatListMF : Form
    {
        public PatListMF()
        {

            InitializeComponent();
            GridView_File.AutoGenerateColumns = false;
            dataGridView_EstimateCost.AutoGenerateColumns = false;
            GridView_Fee.AutoGenerateColumns = false;
            dataGridView_Billing.AutoGenerateColumns = false;
            dataGridView_EstimateCost.AutoGenerateColumns = false;
            dataGridView_PatentRight.AutoGenerateColumns = false;
            dataGridView_applicants.AutoGenerateColumns = false;
            dataGridView_inventors.AutoGenerateColumns = false;
            dataGridView_PatentAnnuity.AutoGenerateColumns = false;
            dataGridView_PatentRightIpc.AutoGenerateColumns = false;
            dataGridView_PatentRightLoc.AutoGenerateColumns = false;

            Public.DynamicGridViewColumn.GetGridColum(ref GridView_File);
            Public.DynamicGridViewColumn.GetGridColum(ref GridView_PatComit);
            Public.DynamicGridViewColumn.GetGridColum(ref GridView_Fee);
            Public.DynamicGridViewColumn.GetGridColum(ref dataGridView_Billing);
            Public.DynamicGridViewColumn.GetGridColum(ref dataGridView_EstimateCost);
            Public.DynamicGridViewColumn.GetGridColum(ref dataGridView_PatentRight);
            Public.DynamicGridViewColumn.GetGridColum(ref dataGridView_applicants);
            Public.DynamicGridViewColumn.GetGridColum(ref dataGridView_inventors);
            Public.DynamicGridViewColumn.GetGridColum(ref dataGridView_PatentAnnuity);
            Public.DynamicGridViewColumn.GetGridColum(ref dataGridView_PatentRightIpc);
            Public.DynamicGridViewColumn.GetGridColum(ref dataGridView_PatentRightLoc);
        }

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

        private DataSet ds_PatentRightT = new DataSet();
        /// <summary>
        /// PatentRightT 智財局專利相關資料
        /// </summary>
        public DataSet DS_PatentRightT
        {
            get
            {
                return ds_PatentRightT;
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

        #region  ============property============

        UserPermissionForm myPermission;
        private const string ProgramSymbol = "PatListMF";
        private const string SourceTableName = "PatentManagementT";

        /// <summary>
        /// PatentID
        /// </summary>
        public int property_PatentID
        {
            get
            {
                if (GridView_File.CurrentRow != null)
                {
                    return (int)GridView_File.CurrentRow.Cells["PatentID"].Value;
                }
                else
                {
                    return -1;
                }
            }
        }

        /// <summary>
        /// 案件編號
        /// </summary>
        public string property_PatentNo
        {
            get
            {
                if (GridView_File.CurrentRow != null)
                {
                    return GridView_File.CurrentRow.Cells["PatentNo"].Value.ToString();
                }
                else
                {
                    return "";
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

        #endregion

        #region ==============PATMF_Load 、 PATMF_FormClosed==============
        private void PATMF_Load(object sender, EventArgs e)
        {

            Public.PublicForm Forms = new Public.PublicForm();
            Forms.PatListMF = this;

            //取得登入者Key
            iWorkerID = Properties.Settings.Default.WorkerKEY;


            //取得權限
            myPermission = new UserPermissionForm(Properties.Settings.Default.WorkerKEY, ProgramSymbol);

            System.Windows.Forms.BindingNavigator[] listbinding = { bindingNavigator_Patent, bindingNavigator_PatComit, bindingNavigator_EstimateCost, bindingNavigator_Fee, bindingNavigator_Payment };
            System.Windows.Forms.ContextMenuStrip[] listtMenu = { contextMenuStrip_Pat, contextMenuStrip_Event0, contextMenuStrip_Fee, contextMenuStrip_Billing, contextMenuStrip_EstimateCost };

            //確認可使用的功能選單
            Public.CommonFunctions.CheckMeunItemVisible(listbinding, myPermission.UserPermission);
            Public.CommonFunctions.CheckMeunItemVisible(listtMenu, myPermission.UserPermission);


            //int LastYear = DateTime.Now.Year - 1;
            //maskedTextBox_S.Text = new DateTime(LastYear, 1, 1).ToString("yyyy/MM/dd");
            SetBindingSource();

            TabFileBinding();
            ControlBindingPatComit();
            ControlBindingTMFee();
            ControlBindingTMPayment();
            ControlBindingTMEstimateCost();

            Public.Utility.SetLoadDataRange(userControlFilterDate1);

            if (Properties.Settings.Default.IsLoadData)
            {
                but_Search_Click(null, null);
            }

            this.GridView_File.SelectionChanged += new System.EventHandler(this.GridView_File_SelectionChanged);

            GridView_File_SelectionChanged(null, null);

        }

        private void PATMF_FormClosed(object sender, FormClosedEventArgs e)
        {
            Public.PublicForm Forms = new Public.PublicForm();
            Forms.PatListMF = null;
        }
        #endregion

        #region ================ControlBinding================

        #region TabFileBinding
        public void TabFileBinding()
        {
            //申請案卷號
            txt_PatentNo.DataBindings.Clear();
            txt_PatentNo.DataBindings.Add("Text", vPatentListBindingSource, "PatentNo", true, DataSourceUpdateMode.OnValidation, "", "");

            //提案名稱
            txt_FileNo_Old.DataBindings.Clear();
            txt_FileNo_Old.DataBindings.Add("Text", vPatentListBindingSource, "PatentNo_Old", true, DataSourceUpdateMode.OnValidation, "", "");

            //申請案名稱
            txt_title.DataBindings.Clear();
            txt_title.DataBindings.Add("Text", vPatentListBindingSource, "Title", true, DataSourceUpdateMode.OnValidation, "", "");

            //申請案名稱(英)
            txt_TitleEn.DataBindings.Clear();
            txt_TitleEn.DataBindings.Add("Text", vPatentListBindingSource, "TitleEn", true, DataSourceUpdateMode.OnValidation, "", "");

            //申請案號
            txt_ApplicationNo.DataBindings.Clear();
            txt_ApplicationNo.DataBindings.Add("Text", vPatentListBindingSource, "ApplicationNo", true, DataSourceUpdateMode.OnValidation, "", "");

            //舊版申請人
            //txt_ApplicantName.DataBindings.Clear();
            //txt_ApplicantName.DataBindings.Add("Text", bSource_File, "ApplicantName", true, DataSourceUpdateMode.OnValidation, "", "");

            //新版申請人
            txt_Applicant.DataBindings.Clear();
            txt_Applicant.DataBindings.Add("Text", vPatentListBindingSource, "ApplicantNames", true, DataSourceUpdateMode.OnValidation, "", "");

            //種類(發明、新型、新式樣)
            txt_Kind.DataBindings.Clear();
            txt_Kind.DataBindings.Add("Text", vPatentListBindingSource, "KindName", true, DataSourceUpdateMode.OnValidation, "", "");

            //性質(案件性質: 一般案、接續案)
            txt_Nature.DataBindings.Clear();
            txt_Nature.DataBindings.Add("Text", vPatentListBindingSource, "FeatureName", true, DataSourceUpdateMode.OnValidation, "", "");

            //國別
            txt_Country.DataBindings.Clear();
            txt_Country.DataBindings.Add("Text", vPatentListBindingSource, "Country", true, DataSourceUpdateMode.OnValidation, "", "");


            //公開號數
            txt_PubNo.DataBindings.Clear();
            txt_PubNo.DataBindings.Add("Text", vPatentListBindingSource, "PubNo", true, DataSourceUpdateMode.OnValidation, "", "");
            //專利號數
            txt_CertifyNo.DataBindings.Clear();
            txt_CertifyNo.DataBindings.Add("Text", vPatentListBindingSource, "CertifyNo", true, DataSourceUpdateMode.OnValidation, "", "");
            //公告號數
            txt_AllowPubNo.DataBindings.Clear();
            txt_AllowPubNo.DataBindings.Add("Text", vPatentListBindingSource, "AllowPubNo", true, DataSourceUpdateMode.OnValidation, "", "");

            //年費繳至第幾年
            //txt_PayYear1.DataBindings.Clear();
            //txt_PayYear1.DataBindings.Add("Value", bSource_File, "PayYear", false, DataSourceUpdateMode.OnValidation, 0m);

            txt_PayYear.DataBindings.Clear();
            txt_PayYear.DataBindings.Add("Text", vPatentListBindingSource, "PayYear");

            //發明人
            txt_Inventor.DataBindings.Clear();
            txt_Inventor.DataBindings.Add("Text", vPatentListBindingSource, "Inventor", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_AddDay.DataBindings.Clear();
            txt_AddDay.DataBindings.Add("Text", vPatentListBindingSource, "AddDay");


            //引案人
            txt_Introducer.DataBindings.Clear();
            txt_Introducer.DataBindings.Add("Text", vPatentListBindingSource, "Introducer", true, DataSourceUpdateMode.OnValidation);

            //備註
            txt_Remark2.DataBindings.Clear();
            txt_Remark2.DataBindings.Add("Text", vPatentListBindingSource, "Remark", true, DataSourceUpdateMode.OnValidation);

            //本所承辦人
            txt_ClientWorker.DataBindings.Clear();
            txt_ClientWorker.DataBindings.Add("Text", vPatentListBindingSource, "ClientWorkerName", true, DataSourceUpdateMode.OnValidation);

            //優先權
            txt_Priority.DataBindings.Clear();
            txt_Priority.DataBindings.Add("Text", vPatentListBindingSource, "PriorityBaseName", true, DataSourceUpdateMode.OnValidation);

            //審查請求
            txt_ISexam.DataBindings.Clear();
            txt_ISexam.DataBindings.Add("Text", vPatentListBindingSource, "ISExamName", true, DataSourceUpdateMode.OnValidation);

            //委託性質
            txt_DelegateFeatureName.DataBindings.Clear();
            txt_DelegateFeatureName.DataBindings.Add("Text", vPatentListBindingSource, "DelegateFeatureName", true, DataSourceUpdateMode.OnValidation);

            //委託類型
            txt_DelegateType.DataBindings.Clear();
            txt_DelegateType.DataBindings.Add("Text", vPatentListBindingSource, "DelegateTypeName", true, DataSourceUpdateMode.OnValidation);

            //主委託人
            txt_MainCustomer.DataBindings.Clear();
            txt_MainCustomer.DataBindings.Add("Text", vPatentListBindingSource, "MainCustomerName", true, DataSourceUpdateMode.OnValidation);

            //主委託人--聯絡窗口
            txt_MainCustomerTransactor.DataBindings.Clear();
            txt_MainCustomerTransactor.DataBindings.Add("Text", vPatentListBindingSource, "MainCustomerTransactorName", true, DataSourceUpdateMode.OnValidation);

            //主委託人--對方案號
            txt_MainCustomerRefNo.DataBindings.Clear();
            txt_MainCustomerRefNo.DataBindings.Add("Text", vPatentListBindingSource, "MainCustomerRefNo", true, DataSourceUpdateMode.OnValidation);

            //承辦事務所
            txt_PatentAttorney.DataBindings.Clear();
            txt_PatentAttorney.DataBindings.Add("Text", vPatentListBindingSource, "AttorneyFirm", true, DataSourceUpdateMode.OnValidation);

            //承辦事務所--對方案號
            txt_PatentAttorneyRefNo.DataBindings.Clear();
            txt_PatentAttorneyRefNo.DataBindings.Add("Text", vPatentListBindingSource, "AttorneyRefNo", true, DataSourceUpdateMode.OnValidation);

            //承辦事務所--聯絡窗口
            txt_PatentAttorneyTransactor.DataBindings.Clear();
            txt_PatentAttorneyTransactor.DataBindings.Add("Text", vPatentListBindingSource, "AttLiaisoner", true, DataSourceUpdateMode.OnValidation);

            //是否本所承辦案件
            chb_IsBySelf.DataBindings.Clear();
            chb_IsBySelf.DataBindings.Add("Checked", vPatentListBindingSource, "IsBySelf", true, DataSourceUpdateMode.OnPropertyChanged, false);

            //引案日期
            mask_IntroductionDate.DataBindings.Clear();
            mask_IntroductionDate.DataBindings.Add("Text", vPatentListBindingSource, "IntroductionDate", true, DataSourceUpdateMode.OnPropertyChanged, "    /  /", "yyyy/MM/dd");

            //最早母案申請日
            maskedTextBox_EarlyMotherDate.DataBindings.Clear();
            maskedTextBox_EarlyMotherDate.DataBindings.Add("Text", vPatentListBindingSource, "EarlyMotherDate", true, DataSourceUpdateMode.OnPropertyChanged, "    /  /", "yyyy/MM/dd");

            //實際申請日
            maskedTextBox_ApplicationDate.DataBindings.Clear();
            maskedTextBox_ApplicationDate.DataBindings.Add("Text", vPatentListBindingSource, "ApplicationDate", true, DataSourceUpdateMode.OnPropertyChanged, "    /  /", "yyyy/MM/dd");

            //公開日期
            maskedTextBox_Pubdate.DataBindings.Clear();
            maskedTextBox_Pubdate.DataBindings.Add("Text", vPatentListBindingSource, "Pubdate", true, DataSourceUpdateMode.OnValidation, "    /  /", "yyyy/MM/dd");

            //核准日期
            maskedTextBox_AllowDate.DataBindings.Clear();
            maskedTextBox_AllowDate.DataBindings.Add("Text", vPatentListBindingSource, "AllowDate", true, DataSourceUpdateMode.OnValidation, "    /  /", "yyyy/MM/dd");

            //公告日期
            maskedTextBox_AllowPubdate.DataBindings.Clear();
            maskedTextBox_AllowPubdate.DataBindings.Add("Text", vPatentListBindingSource, "AllowPubdate", true, DataSourceUpdateMode.OnPropertyChanged, "    /  /", "yyyy/MM/dd");

            //收到證書日
            maskedTextBox_GetDate.DataBindings.Clear();
            maskedTextBox_GetDate.DataBindings.Add("Text", vPatentListBindingSource, "GetDate", true, DataSourceUpdateMode.OnValidation, "    /  /", "yyyy/MM/dd");

            maskedTextBox_Registerdate.DataBindings.Clear();
            maskedTextBox_Registerdate.DataBindings.Add("Text", vPatentListBindingSource, "Registerdate", true, DataSourceUpdateMode.OnPropertyChanged, "    /  /", "yyyy/MM/dd");

            maskedTextBox_DueDate.DataBindings.Clear();
            maskedTextBox_DueDate.DataBindings.Add("Text", vPatentListBindingSource, "DueDate", true, DataSourceUpdateMode.OnPropertyChanged, "    /  /", "yyyy/MM/dd");

            maskedTextBox_RenewTo.DataBindings.Clear();
            maskedTextBox_RenewTo.DataBindings.Add("Text", vPatentListBindingSource, "RenewTo", true, DataSourceUpdateMode.OnPropertyChanged, "    /  /", "yyyy/MM/dd");

            maskedTextBox_CloseDate.DataBindings.Clear();
            maskedTextBox_CloseDate.DataBindings.Add("Text", vPatentListBindingSource, "CloseDate", true, DataSourceUpdateMode.OnPropertyChanged, "    /  /", "yyyy/MM/dd");

            //備註
            txt_CloseCaus.DataBindings.Clear();
            txt_CloseCaus.DataBindings.Add("Text", vPatentListBindingSource, "CloseCaus", true, DataSourceUpdateMode.OnValidation);

            //電子交互碼
            txt_ECode.DataBindings.Clear();
            txt_ECode.DataBindings.Add("Text", vPatentListBindingSource, "ECode", true, DataSourceUpdateMode.OnValidation);

            //最早優先申請日
            maskedTextBox_EarlyPriorityDate.DataBindings.Clear();
            maskedTextBox_EarlyPriorityDate.DataBindings.Add("Text", vPatentListBindingSource, "EarlyPriorityDate", true, DataSourceUpdateMode.OnPropertyChanged, "    /  /", "yyyy/MM/dd");

            //優先權申請號
            txt_EarlyPriorityNo.DataBindings.Clear();
            txt_EarlyPriorityNo.DataBindings.Add("Text", vPatentListBindingSource, "EarlyPriorityNo", true, DataSourceUpdateMode.OnValidation);

            //優惠期日期
            maskedTextBox_GracePeriod.DataBindings.Clear();
            maskedTextBox_GracePeriod.DataBindings.Add("Text", vPatentListBindingSource, "GracePeriod", true, DataSourceUpdateMode.OnValidation, "    /  /", "yyyy/MM/dd");

            //優惠期公開事由
            txt_GraceRemark.DataBindings.Clear();
            txt_GraceRemark.DataBindings.Add("Text", vPatentListBindingSource, "GraceRemark", true, DataSourceUpdateMode.OnValidation, "", "");

            //案件階段
            txt_StatusName.DataBindings.Clear();
            txt_StatusName.DataBindings.Add("Text", vPatentListBindingSource, "StatusName", true, DataSourceUpdateMode.OnValidation, "", "");

            //階段描述
            txt_StatusExplain.DataBindings.Clear();
            txt_StatusExplain.DataBindings.Add("Text", vPatentListBindingSource, "StatusExplain", true, DataSourceUpdateMode.OnValidation, "", "");
        }
        #endregion

        #region ControlBindingPatComit 事件記錄
        /// <summary>
        /// 事件記錄
        /// </summary>
        public void ControlBindingPatComit()
        {
            txt_ComitEventContent.DataBindings.Clear();
            txt_ComitEventContent.DataBindings.Add("Text", patComitEventTBindingSource, "EventContent", true, DataSourceUpdateMode.OnPropertyChanged, "", "");

            txt_WorkerKey.DataBindings.Clear();
            txt_WorkerKey.DataBindings.Add("Text", patComitEventTBindingSource, "EmployeeName", true, DataSourceUpdateMode.OnPropertyChanged, "", "");

            maskedTextBox_CreateDate.DataBindings.Clear();
            maskedTextBox_CreateDate.DataBindings.Add("Text", patComitEventTBindingSource, "CreateDate", true, DataSourceUpdateMode.OnPropertyChanged, "    /  /", "yyyy/MM/dd");

            maskedTextBox_OccurDate.DataBindings.Clear();
            maskedTextBox_OccurDate.DataBindings.Add("Text", patComitEventTBindingSource, "OccurDate", true, DataSourceUpdateMode.OnPropertyChanged, "    /  /", "yyyy/MM/dd");

            maskedTextBox_OfficerDate.DataBindings.Clear();
            maskedTextBox_OfficerDate.DataBindings.Add("Text", patComitEventTBindingSource, "OfficerDate", true, DataSourceUpdateMode.OnPropertyChanged, "    /  /", "yyyy/MM/dd");

            maskedTextBox_ComitDueDate.DataBindings.Clear();
            maskedTextBox_ComitDueDate.DataBindings.Add("Text", patComitEventTBindingSource, "DueDate", true, DataSourceUpdateMode.OnPropertyChanged, "    /  /", "yyyy/MM/dd");

            maskedTextBox_OfficeDueDate.DataBindings.Clear();
            maskedTextBox_OfficeDueDate.DataBindings.Add("Text", patComitEventTBindingSource, "OfficeDueDate", true, DataSourceUpdateMode.OnPropertyChanged, "    /  /", "yyyy/MM/dd");

            maskedTextBox_StartDate.DataBindings.Clear();
            maskedTextBox_StartDate.DataBindings.Add("Text", patComitEventTBindingSource, "StartDate", true, DataSourceUpdateMode.OnPropertyChanged, "    /  /", "yyyy/MM/dd");

            maskedTextBox_ComitDate.DataBindings.Clear();
            maskedTextBox_ComitDate.DataBindings.Add("Text", patComitEventTBindingSource, "ComitDate", true, DataSourceUpdateMode.OnPropertyChanged, "    /  /", "yyyy/MM/dd");

            maskedTextBox_FinishDate.DataBindings.Clear();
            maskedTextBox_FinishDate.DataBindings.Add("Text", patComitEventTBindingSource, "FinishDate", true, DataSourceUpdateMode.OnPropertyChanged, "    /  /", "yyyy/MM/dd");

            txt_eRemark.DataBindings.Clear();
            txt_eRemark.DataBindings.Add("Text", patComitEventTBindingSource, "Remark", true, DataSourceUpdateMode.OnPropertyChanged, "", "");

            txt_ComitResult.DataBindings.Clear();
            txt_ComitResult.DataBindings.Add("Text", patComitEventTBindingSource, "Result", true, DataSourceUpdateMode.OnPropertyChanged, "", "");

            txt_AttorneyKey.DataBindings.Clear();
            txt_AttorneyKey.DataBindings.Add("Text", patComitEventTBindingSource, "AttorneyFirm", true, DataSourceUpdateMode.OnPropertyChanged, "", "");

            txt_ALiaisonerKey.DataBindings.Clear();
            txt_ALiaisonerKey.DataBindings.Add("Text", patComitEventTBindingSource, "Liaisoner", true, DataSourceUpdateMode.OnPropertyChanged, "", "");

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
            maskedTextBox_RDate.DataBindings.Add("Text", patentFeeTBindingSource, "RDate", true, DataSourceUpdateMode.OnPropertyChanged, "    /  /", "yyyy/MM/dd");

            //收款期限
            maskedTextBox_CollectionPeriod.DataBindings.Clear();
            maskedTextBox_CollectionPeriod.DataBindings.Add("Text", patentFeeTBindingSource, "CollectionPeriod", true, DataSourceUpdateMode.OnPropertyChanged, "    /  /", "yyyy/MM/dd");

            //收款日期
            maskedTextBox_PayDate.DataBindings.Clear();
            maskedTextBox_PayDate.DataBindings.Add("Text", patentFeeTBindingSource, "PayDate", true, DataSourceUpdateMode.OnPropertyChanged, "    /  /", "yyyy/MM/dd");

            //收據日期
            maskedTextBox_ReceiptDate.DataBindings.Clear();
            maskedTextBox_ReceiptDate.DataBindings.Add("Text", patentFeeTBindingSource, "ReceiptDate", true, DataSourceUpdateMode.OnPropertyChanged, "    /  /", "yyyy/MM/dd");

            //發票日期
            maskedTextBox_aBillDate.DataBindings.Clear();
            maskedTextBox_aBillDate.DataBindings.Add("Text", patentFeeTBindingSource, "aBillDate", true, DataSourceUpdateMode.OnPropertyChanged, "    /  /", "yyyy/MM/dd");

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
            maskedTextBox_ReciveDate.DataBindings.Add("Text", patentPaymentTBindingSource, "ReciveDate", true, DataSourceUpdateMode.OnPropertyChanged, "    /  /", "yyyy/MM/dd");

            //付款期限
            maskedTextBox_PayDueDate.DataBindings.Clear();
            maskedTextBox_PayDueDate.DataBindings.Add("Text", patentPaymentTBindingSource, "PayDueDate", true, DataSourceUpdateMode.OnPropertyChanged, "    /  /", "yyyy/MM/dd");

            //付款日期
            maskedTextBox_PaymentDate.DataBindings.Clear();
            maskedTextBox_PaymentDate.DataBindings.Add("Text", patentPaymentTBindingSource, "PaymentDate", true, DataSourceUpdateMode.OnPropertyChanged, "    /  /", "yyyy/MM/dd");

            //完成日期
            maskedTextBox_IReceiptDate.DataBindings.Clear();
            maskedTextBox_IReceiptDate.DataBindings.Add("Text", patentPaymentTBindingSource, "IReceiptDate", true, DataSourceUpdateMode.OnPropertyChanged, "    /  /", "yyyy/MM/dd");

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

            //事件單號
            txt_PayEventID.DataBindings.Clear();
            txt_PayEventID.DataBindings.Add("Text", patentPaymentTBindingSource, "PatComitEventID", true, DataSourceUpdateMode.OnValidation, "", "PE#");


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

        #region 設定BindingSource的來源 private void SetBindingSource()
        /// <summary>
        /// 設定BindingSource的來源
        /// </summary>
        private void SetBindingSource()
        {
            if (dt_PatentList.Columns.Count == 0)
            {
                Public.CPatentPublicFunction.GetPatentList("1=0", ref dt_PatentList);
            }
            vPatentListBindingSource.DataSource = dt_PatentList;

            if (dt_PatComitEventT.Columns.Count == 0)
            {
                Public.CPatentPublicFunction.GetPatentEvent("0", ref dt_PatComitEventT);
            }
            patComitEventTBindingSource.DataSource = dt_PatComitEventT;

            if (dt_PatentEstimateCostT.Columns.Count == 0)
            {
                Public.CPatentPublicFunction.GetPatentEstimateCost("0", ref dt_PatentEstimateCostT);
            }
            patentEstimateCostTBindingSource.DataSource = dt_PatentEstimateCostT;

            if (dt_PatentFeeT.Columns.Count == 0)
            {
                Public.CPatentPublicFunction.GetPatentkFee("0", ref dt_PatentFeeT);
            }
            patentFeeTBindingSource.DataSource = dt_PatentFeeT;

            if (dt_PatentPaymentT.Columns.Count == 0)
            {
                Public.CPatentPublicFunction.GetPatentPayment("0", ref dt_PatentPaymentT);
            }
            patentPaymentTBindingSource.DataSource = dt_PatentPaymentT;


        }
        #endregion


        #region ===============but_Search===============
        private void but_Search_Click(object sender, EventArgs e)
        {
            but_Search.Enabled = false;

            string strSQL = Public.CommonFunctions.GetSQLScript(QueryFilter1, QueryFilter2, rb_and.Checked ? " and " : " or ", userControlFilterDate1);

            Public.CPatentPublicFunction.GetPatentList(strSQL, ref dt_PatentList);

            but_Search.Enabled = true;
        }

        #endregion      

        #region GetComitEvent 取得事件的資料
        /// <summary>
        /// 取得專利事件的資料
        /// </summary>
        /// <param name="strPatentID"></param>
        /// <returns></returns>
        public void GetPatentEvent(string strPatentID)
        {
            Public.CPatentPublicFunction.GetPatentEvent(strPatentID, ref dt_PatComitEventT);
        }
        #endregion 

        #region GetPatentkFee 取得專利請款的資料
        /// <summary>
        /// 取得專利請款的資料
        /// </summary>
        /// <param name="strPatentID"></param>
        /// <returns></returns>
        public void GetPatentkFee(string strPatentID)
        {
            Public.CPatentPublicFunction.GetPatentkFee(strPatentID, ref dt_PatentFeeT);

        }
        #endregion

        #region GetPatentPayment 取得專利付款的資料
        /// <summary>
        /// 取得專利付款的資料
        /// </summary>
        /// <param name="strPatentID"></param>
        /// <returns></returns>
        public void GetPatentPayment(string strPatentID)
        {
            Public.CPatentPublicFunction.GetPatentPayment(strPatentID, ref dt_PatentPaymentT);

        }
        #endregion 

        #region GetPatentEstimateCost 取得商標預估費用的資料
        /// <summary>
        /// 取得專利預估費用的資料
        /// </summary>
        /// <param name="strPatentID"></param>
        /// <returns></returns>
        public void GetPatentEstimateCost(string strPatentID)
        {
            Public.CPatentPublicFunction.GetPatentEstimateCost(strPatentID, ref dt_PatentEstimateCostT);
        }
        #endregion 

        #region GetPatentRight 取得智財專利相關的資料
        /// <summary>
        /// 取得智財專利相關的資料
        /// </summary>
        /// <param name="strPatentID"></param>
        /// <returns></returns>
        public void GetPatentRight(string strPatentID)
        {
            Public.CPatentPublicFunction.GetPatentRightInfoT(strPatentID, ref ds_PatentRightT);

            if (ds_PatentRightT != null && ds_PatentRightT.Tables.Count > 0)
            {
                if (ds_PatentRightT.Tables[0] != null)
                {
                    dataGridView_PatentRight.DataSource = ds_PatentRightT.Tables[0];
                }

                if (ds_PatentRightT.Tables[1] != null)
                {
                    dataGridView_applicants.DataSource = ds_PatentRightT.Tables[1];
                }

                if (ds_PatentRightT.Tables[2] != null)
                {
                    dataGridView_inventors.DataSource = ds_PatentRightT.Tables[2];
                }

                if (ds_PatentRightT.Tables[3] != null)
                {
                    dataGridView_PatentAnnuity.DataSource = ds_PatentRightT.Tables[3];
                }

                if (ds_PatentRightT.Tables[4] != null)
                {
                    dataGridView_PatentRightIpc.DataSource = ds_PatentRightT.Tables[4];
                }

                if (ds_PatentRightT.Tables[5] != null)
                {
                    dataGridView_PatentRightLoc.DataSource = ds_PatentRightT.Tables[5];
                }

            }

        }
        #endregion 

        #region CheckPatenDel 如果有子資料，將回傳False , 若無子資料回傳True
        /// <summary>
        /// 驗証案件是否可刪除
        /// 如果有子資料，將回傳False , 若無子資料回傳True
        /// </summary>
        /// <param name="PatentID"></param>
        /// <returns></returns>
        private bool CheckPatenDel(int PatentID)
        {
            string strSQL = string.Format(@"select Top 1 PatComitEventID from PatComitEventT where PatentID={0}; 
                                            select Top 1 PaymentID from PatentPaymentT where PatentID={0};
                                            select Top 1 FeeKEY from PatentFeeT where PatentID={0};
                                            select Top 1 PaymentID from PatentPaymentT where PatentID={0}", PatentID);

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

        #region ============申請案快顯============
        private void contextMenuStrip_File_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            contextMenuStrip_Pat.Visible = false;

            switch (e.ClickedItem.Name)
            {
                case "toolStripButton_Add":
                case "AddFiletoolStripMenuItem"://新增申請案

                    AddFrom.AddPatent add = new AddFrom.AddPatent();

                    add.ShowDialog();

                    break;

                case "toolStripButton_Del":
                case "DelFiletoolStripMenuItem": //刪除申請案
                    if (GridView_File.CurrentRow != null)
                    {

                        //1.判斷是否有人使用中
                        int iLocker = Public.Utility.GetRecordAuth("PatentManagementT", "PatentID=" + property_PatentID.ToString());
                        if (iLocker == -1 || iLocker == iWorkerID)
                        {
                            if (iLocker != iWorkerID)
                            {
                                Public.Utility.LockRecordAuth("PatentManagementT", iWorkerID, "PatentID=" + property_PatentID.ToString());
                            }

                            //2.判斷是否有子資料
                            if (!CheckPatenDel((int)GridView_File.CurrentRow.Cells["PatentID"].Value))
                            {
                                MessageBox.Show("該案件不得刪除，因案件下尚有子資料，請先將子資料刪除\r\n \r\n即可刪除此申請案【" + GridView_File.CurrentRow.Cells["PatentNo"].Value.ToString() + "】", "提示訊息");
                                return;
                            }

                            if (MessageBox.Show("是否確定刪除 \r\n" + GridView_File.CurrentRow.Cells["PatentNo"].Value.ToString(), "確認視窗", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                            {

                                if (MessageBox.Show(string.Format("請再次確定是否刪除該申請案({0})，\r\n它將會刪除所有相關的資料(附件、事件記錄、請款記錄、付款記錄)??", GridView_File.CurrentRow.Cells["PatentNo"].Value.ToString()), "確認視窗", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                                {
                                    Public.CPatentManagement Patent = new Public.CPatentManagement();
                                    Public.CPatentManagement.ReadOne(property_PatentID, ref Patent);


                                    Public.DLL dll = new Public.DLL();
                                    //刪除申請案相關文件包含事件記錄、來函、費用的實體檔案
                                    string delFileDir = string.Format(@"{0}\{1}", dll.PatentFolderRoot, GridView_File.CurrentRow.Cells["PatentID"].Value.ToString());
                                    if (Directory.Exists(delFileDir))
                                    {
                                        try
                                        {
                                            Directory.Delete(delFileDir, true);
                                        }
                                        catch
                                        {

                                        }
                                    }

                                    //刪除事件記錄、請款記錄                               
                                    string strSQLEvent = string.Format(@" 
delete [PatComitEventToFeeT] where PatComitEventID in(select PatComitEventID from PatComitEventT where PatentID={0});
delete PatComitEventToPaymentT where PatComitEventID in(select PatComitEventID from PatComitEventT where PatentID={0});
delete from PatentFeeT where PatentID={0};
delete from PatentPaymentT where PatentID={0};
delete PatComitEventT where  PatentID={0};", GridView_File.CurrentRow.Cells["PatentID"].Value.ToString());
                                    dll.SQLexecuteNonQuery(strSQLEvent);

                                    //刪除記錄檔    
                                    Public.CSystemLogT log = new Public.CSystemLogT();
                                    log.DelTime = DateTime.Now;
                                    log.DelWorkerKey = Properties.Settings.Default.WorkerKEY;
                                    log.DelWorker = Properties.Settings.Default.WorkerName;
                                    log.DelContent = string.Format("申請案卷號:{0}\r\n申請人:{1}\r\n申請案名稱:{2}\r\n客戶案號:{3}\r\n複代案號:{4}", Patent.PatentNo, Patent.ApplicantNames, Patent.Title, Patent.MainCustomerRefNo, Patent.AttorneyRefNo);
                                    log.DelTitle = string.Format("刪除「{0}」資料【{1}】", this.Text, Patent.PatentNo);
                                    log.Create();

                                    Patent.Delete((int)GridView_File.CurrentRow.Cells["PatentID"].Value);

                                    GridView_File.Rows.Remove(GridView_File.CurrentRow);

                                    //this.GridView_FileIndex = bSource_File.Position;

                                    MessageBox.Show("刪除成功");
                                }
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

                case "ToolStripMenuItem_Proposal":

                    if (GridView_File.SelectedRows.Count > 0)
                    {
                        US.OvertrueName overture = new US.OvertrueName();
                        overture.TypeMode = 1;
                        overture.GV = GridView_File;
                        overture.Dt = DT_PatentList;
                        overture.ShowDialog();
                    }
                    break;
                case "toolStripButton_Export":
                case "匯出成ExcelToolStripMenuItem":

                    contextMenuStrip_Pat.Visible = false;

                    try
                    {
                        Public.DLL dll = new Public.DLL();
                        Task task = dll.WriteToCSV(GridView_File);
                    }
                    catch
                    {
                        MessageBox.Show("匯出CSV失敗");
                    }
                    break;


                case "toolStripButton_Upload":
                case "上傳申請案相關文件ToolStripMenuItem":

                    if (GridView_File.CurrentRow != null)
                    {
                        bool bConnectionFile = Properties.Settings.Default.IsFileServerConnection;
                        if (bConnectionFile)
                        {
                            //US.UpdataFile upfile2 = new US.UpdataFile();
                            US.UpFileList upfile2 = new US.UpFileList();
                            upfile2.Text = "上傳申請案(" + GridView_File.CurrentRow.Cells["PatentNo"].Value.ToString() + ")相關文件";
                            upfile2.MainFileKey = (int)GridView_File.CurrentRow.Cells["PatentID"].Value;
                            upfile2.UploadMode = 3;
                            upfile2.MainFileType = 0;
                            upfile2.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("請確認檔案上傳路徑是否有正常連結!!");
                        }
                    }
                    break;
                case "toolStripButton_OpenFile":
                case "開啟申請案相關文件ToolStripMenuItem":
                    if (GridView_File.CurrentRow != null)
                    {
                        bool bConnectionFile = Properties.Settings.Default.IsFileServerConnection;
                        if (bConnectionFile)
                        {
                            ViewUpdateFileList subForm = new ViewUpdateFileList();
                            subForm.Text = GridView_File.CurrentRow.Cells["PatentNo"].Value.ToString() + "的相關文件";
                            subForm.FileKind = 3;
                            subForm.FileType = 0;
                            subForm.MainParentID = (int)GridView_File.CurrentRow.Cells["PatentID"].Value;
                            subForm.radoC.Checked = true;
                            subForm.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("請確認檔案上傳路徑是否有正常連結!!");
                        }
                    }
                    break;
                case "EditFiletoolStripMenuItem":
                case "toolStripButtonEditItem_Patent":
                    if (GridView_File.CurrentRow != null)
                    {
                        //判斷是否有人使用中
                        int iLocker = Public.Utility.GetRecordAuth("PatentManagementT", "PatentID=" + property_PatentID.ToString());
                        if (iLocker == -1 || iLocker == iWorkerID)
                        {
                            if (iLocker != iWorkerID)
                            {
                                Public.Utility.LockRecordAuth("PatentManagementT", iWorkerID, "PatentID=" + property_PatentID.ToString());
                            }
                            EditForm.EditPatent editPatent = new LawtechPTSystem.EditForm.EditPatent();
                            editPatent.Text += "--" + GridView_File.CurrentRow.Cells["PatentNo"].Value.ToString();
                            editPatent.Patent_ID = (int)GridView_File.CurrentRow.Cells["PatentID"].Value;
                            editPatent.ShowDialog();

                            Public.Utility.NuLockRecordAuth("PatentManagementT", "PatentID=" + property_PatentID.ToString());
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
                    if (GridView_File.SelectedRows.Count > 0)
                    {
                        ViewFrom.PatentCompleteHistory history = new ViewFrom.PatentCompleteHistory();
                        history.Gv = GridView_File;
                        history.Show();
                    }
                    break;

                case "toolStripMenuItem_SendMail"://寄送通知函
                    if (GridView_File.CurrentRow != null)
                    {
                        US.NotificationLetter letter = new US.NotificationLetter();
                        letter.ApplicantKeys = GridView_File.CurrentRow.Cells["ApplicantKeys"].Value.ToString();
                        letter.MainKey = (int)GridView_File.CurrentRow.Cells["PatentID"].Value;
                        letter.CaseKey = GridView_File.CurrentRow.Cells["PatentID"].Value != null ? (int)GridView_File.CurrentRow.Cells["PatentID"].Value : -1;
                        letter.DelegateType = GridView_File.CurrentRow.Cells["DelegateType"].Value.ToString() != "" ? (int)GridView_File.CurrentRow.Cells["DelegateType"].Value : -1;
                        letter.Attorney = GridView_File.CurrentRow.Cells["Attorney"].Value.ToString() != "" ? (int)GridView_File.CurrentRow.Cells["Attorney"].Value : -1;
                        letter.EmailSampleType = "Patent";
                        letter.CaseNo = GridView_File.CurrentRow.Cells["PatentNo"].Value.ToString();
                        letter.Text = letter.Text + "(" + GridView_File.CurrentRow.Cells["PatentNo"].Value.ToString() + ")";
                        letter.Show();
                    }
                    break;
                case "toolStripMenuItem_Copy":
                    if (GridView_File.CurrentRow != null)
                    {
                        CopyForm.Patent copy = new CopyForm.Patent();
                        copy.Patent_ID = (int)GridView_File.CurrentRow.Cells["PatentID"].Value;
                        copy.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("請指定要複製的申請案", "提示訊息");
                    }
                    break;

                case "toolStripMenuItem_PatentAnnualtoFee":
                    if (GridView_File.CurrentRow != null)
                    {
                        AddFrom.AddPatentFee fee = new AddFrom.AddPatentFee();
                        fee.PatentID = (int)GridView_File.CurrentRow.Cells["PatentID"].Value;
                        fee.SourceID = (int)GridView_PatComit.CurrentRow.Cells["PatComitEventID"].Value;

                        decimal RenewTo = GridView_File.CurrentRow.Cells["PayYear"].Value != DBNull.Value ? ((decimal)GridView_File.CurrentRow.Cells["PayYear"].Value) + 1 : 1;
                        fee.FeeSubject = GridView_File.CurrentRow.Cells["PatentNo"].Value.ToString() + " 第" + RenewTo.ToString("#,##0.##") + "年 年費請款";
                        fee.Text = fee.Text + "--" + GridView_File.CurrentRow.Cells["PatentNo"].Value.ToString();
                        fee.CountrySymbol = GridView_File.CurrentRow.Cells["CountrySymbol"].Value.ToString();
                        fee.ShowDialog();
                    }
                    break;
                case "toolStripMenuItem_PatentAnnualtoPayment":
                    if (GridView_File.CurrentRow != null)
                    {
                        AddFrom.AddPatentPayment Payment = new AddFrom.AddPatentPayment();
                        Payment.PatentID = (int)GridView_File.CurrentRow.Cells["PatentID"].Value;
                        Payment.CountrySymbol = GridView_File.CurrentRow.Cells["CountrySymbol"].Value.ToString();
                        Payment.SourceID = (int)GridView_PatComit.CurrentRow.Cells["PatComitEventID"].Value;
                        decimal RenewToPay = GridView_File.CurrentRow.Cells["PayYear"].Value != DBNull.Value ? ((decimal)GridView_File.CurrentRow.Cells["PayYear"].Value) + 1 : 1;
                        Payment.FeeSubject = GridView_File.CurrentRow.Cells["PatentNo"].Value.ToString() + " 第" + RenewToPay.ToString("#,##0.##") + "年年費付款";
                        Payment.Text = Payment.Text + "--" + GridView_File.CurrentRow.Cells["Title_File"].Value.ToString();
                        Payment.ShowDialog();
                    }
                    break;
                case "toolStripButton_Orientation":
                    Public.Utility.SsplitContainerHorizontal(ref splitContainer1);
                    break;

                case "toolStripMenuItem_SetGridColumn":
                    SetGridColumnT gc = new SetGridColumnT();
                    gc.CurrentGridSymboID = GridView_File.Tag.ToString();
                    gc.TitleName = "專利申請案列表";
                    gc.Show();
                    break;
                case "toolStripMenuItem_App"://查看申請人
                    if (GridView_File.CurrentRow != null)
                    {
                        ViewFrom.ApplicantList app = new ViewFrom.ApplicantList();
                        app.MainType = 1;
                        string No = GridView_File.CurrentRow.Cells["PatentNo"].Value.ToString();
                        app.Text += $"--{No}";
                        app.MainKey = (int)GridView_File.CurrentRow.Cells["PatentID"].Value;
                        app.Show();
                    }
                    break;
            }
        }
        #endregion

        #region but_Close_Click
        private void but_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region ============GridView_File 事件============
        private void GridView_File_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = false;
        }

        private void GridView_File_SelectionChanged(object sender, EventArgs e)
        {
            if (GridView_File.CurrentRow != null)
            {
                GetPatentEvent(property_PatentID.ToString());
                GetPatentkFee(property_PatentID.ToString());
                GetPatentPayment(property_PatentID.ToString());
                GetPatentEstimateCost(property_PatentID.ToString());
                GetPatentRight(property_PatentID.ToString());
            }
            else
            {
                dt_PatComitEventT.Rows.Clear();
                dt_PatentEstimateCostT.Rows.Clear();
                dt_PatentFeeT.Rows.Clear();
                dt_PatentPaymentT.Rows.Clear();
                ds_PatentRightT.Tables.Clear();
            }
        }

        private void GridView_File_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != -1 && e.RowIndex != -1)
            {
                if (GridView_File.CurrentRow != null)
                {
                    if (myPermission.UserPermission.HasFlag(PermissionTypes.Modify))//判斷權限
                    {
                        contextMenuStrip_File_ItemClicked(contextMenuStrip_Pat, new ToolStripItemClickedEventArgs(EditFiletoolStripMenuItem));
                    }
                }
            }
        }
        #endregion

        #region  ============事件記錄快顯============
        private void contextMenuStrip_Event0_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            contextMenuStrip_Event0.Visible = false;
            switch (e.ClickedItem.Name)
            {
                case "bindingNavigatorAddNewItem":
                case "AddToolStripMenuItem"://新增事件
                    AddFrom.AddPatentComitEvent comit = new AddFrom.AddPatentComitEvent();
                    comit.Text += "(" + property_PatentNo + "  " + GridView_File.CurrentRow.Cells["CountryName"].Value.ToString() + ")";
                    comit.CountrySymbol = GridView_File.CurrentRow.Cells["CountrySymbol"].Value.ToString();
                    comit.PatentID = property_PatentID;
                    comit.ShowDialog();
                    break;
                case "bindingNavigatorDeleteItem":
                case "DelToolStripMenuItem": //刪除事件
                    if (GridView_PatComit.CurrentRow != null)
                    {
                        if (GridView_PatComit.CurrentRow.Cells["EventSingCode"].Value.ToString() != "")
                        {
                            MessageBox.Show("已有主管簽核，不得刪除，若要刪除，請洽簽核主管", "提示訊息", MessageBoxButtons.OK);
                            return;
                        }

                        int iPatComitEventID = (int)GridView_PatComit.CurrentRow.Cells["PatComitEventID"].Value;
                        //判斷是否有人使用中
                        int iLocker = Public.Utility.GetRecordAuth("PatComitEventT", "PatComitEventID=" + iPatComitEventID.ToString());
                        if (iLocker == -1 || iLocker == iWorkerID)
                        {
                            if (iLocker != iWorkerID)
                            {
                                Public.Utility.LockRecordAuth("PatComitEventT", iWorkerID, "PatComitEventID=" + GridView_PatComit.CurrentRow.Cells["PatComitEventID"].Value.ToString());
                            }

                            string ssName = GridView_PatComit.CurrentRow.Cells["EventContent"].Value.ToString();

                            if (MessageBox.Show("是否確定刪除【" + ssName + "】", "確認視窗", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                            {
                                int iKey = (int)GridView_PatComit.CurrentRow.Cells["PatComitEventID"].Value;
                                Public.CPatComitEvent PatentComit = new Public.CPatComitEvent();
                                Public.CPatComitEvent.ReadOne(iKey, ref PatentComit);

                                //刪除標準流程項目
                                Public.CPatWorkReport patwork = new Public.CPatWorkReport();
                                patwork.Delete(" EventID=" + iPatComitEventID.ToString(), "");

                                //刪除事件轉請款
                                Public.CPatComitEventToFee ComitEventToFee = new Public.CPatComitEventToFee();
                                ComitEventToFee.Delete("PatComitEventID=" + GridView_PatComit.CurrentRow.Cells["PatComitEventID"].Value.ToString(), "");

                                //刪除事件轉付款
                                Public.CPatComitEventToPayment ComitEventToPayment = new Public.CPatComitEventToPayment();
                                ComitEventToPayment.Delete("PatComitEventID=" + GridView_PatComit.CurrentRow.Cells["PatComitEventID"].Value.ToString(), "");

                                //刪除官方公文
                                Public.COfficialDocumentEventT delDocumentEventT = new Public.COfficialDocumentEventT();
                                delDocumentEventT.Delete(" EventCaseType='PE' and CaseEventKey=" + iKey.ToString(), "");

                                Public.CPatentManagement pat = new Public.CPatentManagement();
                                Public.CPatentManagement.ReadOne(property_PatentID, ref pat);

                                //刪除記錄檔    
                                Public.CSystemLogT log = new Public.CSystemLogT();
                                log.DelTime = DateTime.Now;
                                log.DelWorkerKey = Properties.Settings.Default.WorkerKEY;
                                log.DelWorker = Properties.Settings.Default.WorkerName;
                                log.DelContent = string.Format("申請案編號:{2}\r\n申請案名稱:{3}\r\n事件內容:{0}\r\n事件發生日:{1}\r\n所內期限:{4}\r\n官方期限:{5}\r\n完成日期:{6}\r\n處理結果:{7}\r\n備註:{8}", PatentComit.EventContent, PatentComit.CreateDate.HasValue ? PatentComit.CreateDate.Value.ToString("yyyy/MM/dd") : "", pat.PatentNo, pat.Title, PatentComit.OfficeDueDate.HasValue ? PatentComit.OfficeDueDate.Value.ToString("yyyy/MM/dd") : "", PatentComit.DueDate.HasValue ? PatentComit.DueDate.Value.ToString("yyyy/MM/dd") : "", PatentComit.FinishDate.HasValue ? PatentComit.FinishDate.Value.ToString("yyyy/MM/dd") : "", PatentComit.Result, PatentComit.Remark);
                                log.DelTitle = string.Format("刪除「{0}」資料【事件記錄-{1}】", this.Text, PatentComit.EventContent);
                                log.Create();

                                PatentComit.Delete(iKey);
                                GridView_PatComit.Rows.Remove(GridView_PatComit.CurrentRow);


                                MessageBox.Show("刪除事件記錄成功", "確認視窗", MessageBoxButtons.OK);
                            }
                        }
                        else
                        {
                            if (iLocker != -1)
                            {
                                Worker_Model worker = new Worker_Model();
                                Worker_Model.ReadOne(iLocker, ref worker);
                                MessageBox.Show("很抱歉~~   目前該筆資料正被【" + worker.EmployeeName + "】使用中，請等候!!\r\n 謝謝", "提示訊息");
                            }
                        }
                    }

                    break;
                case "UpFileToolStripMenuItem": //事件記錄上傳相關文件
                    if (GridView_PatComit.CurrentRow != null)
                    {
                        bool bConnectionFile = Properties.Settings.Default.IsFileServerConnection;
                        if (bConnectionFile)
                        {
                            US.UpFileList upfile2 = new US.UpFileList();
                            upfile2.Text = GridView_File.CurrentRow.Cells["PatentNo"].Value.ToString() + "--上傳事件記錄相關文件";
                            upfile2.MainFileKey = (int)GridView_File.CurrentRow.Cells["PatentID"].Value;
                            upfile2.ChildFileKey = (int)GridView_PatComit.CurrentRow.Cells["PatComitEventID"].Value;
                            upfile2.UploadMode = 3;
                            upfile2.MainFileType = 1;

                            upfile2.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("請確認檔案上傳路徑是否有正常連結!!");
                        }
                    }
                    break;
                case "OpenFileToolStripMenuItem": //開啟申請案相關文件
                    if (GridView_PatComit.CurrentRow != null)
                    {
                        bool bConnectionFile = Properties.Settings.Default.IsFileServerConnection;
                        if (bConnectionFile)
                        {
                            ViewUpdateFileList subForm = new ViewUpdateFileList();
                            subForm.Text = GridView_File.CurrentRow.Cells["PatentNo"].Value.ToString() + "的相關文件";
                            subForm.FileKind = 3;
                            subForm.FileType = 1;
                            subForm.MainParentID = (int)GridView_File.CurrentRow.Cells["PatentID"].Value;
                            subForm.Child_ID = (int)GridView_PatComit.CurrentRow.Cells["PatComitEventID"].Value;
                            subForm.radoD.Checked = true;
                            subForm.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("請確認檔案上傳路徑是否有正常連結!!");
                        }
                    }
                    break;
                case "EdittoolStripMenuItem":
                case "toolStripButtonEditItem":
                    if (GridView_PatComit.CurrentRow != null)
                    {
                        //判斷是否有人使用中
                        int iLocker = Public.Utility.GetRecordAuth("PatComitEventT", "PatComitEventID=" + GridView_PatComit.CurrentRow.Cells["PatComitEventID"].Value.ToString());
                        if (iLocker == -1 || iLocker == iWorkerID)
                        {
                            if (iLocker != iWorkerID)
                            {
                                Public.Utility.LockRecordAuth("PatComitEventT", iWorkerID, "PatComitEventID=" + GridView_PatComit.CurrentRow.Cells["PatComitEventID"].Value.ToString());
                            }
                            EditForm.EditComitEvent comit_Edit = new EditForm.EditComitEvent();
                            comit_Edit.PatComitEventID = (int)GridView_PatComit.CurrentRow.Cells["PatComitEventID"].Value;
                            comit_Edit.PatentID = property_PatentID;
                            comit_Edit.Text += "(" + property_PatentNo + "  " + GridView_File.CurrentRow.Cells["CountryName"].Value.ToString() + ")";
                            comit_Edit.CountrySymbol = GridView_File.CurrentRow.Cells["CountrySymbol"].Value.ToString();
                            comit_Edit.ShowDialog();
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
                case "toolStripMenuItem_ComitToFee":
                    if (GridView_PatComit.CurrentRow != null)
                    {
                        AddFrom.AddPatentFee fee = new AddFrom.AddPatentFee();
                        fee.PatentID = (int)GridView_File.CurrentRow.Cells["PatentID"].Value;
                        fee.TypeFrom = 1;
                        fee.SourceID = (int)GridView_PatComit.CurrentRow.Cells["PatComitEventID"].Value;
                        fee.FeeSubject = GridView_PatComit.CurrentRow.Cells["EventContent"].Value.ToString();
                        fee.Text = fee.Text + "--" + GridView_File.CurrentRow.Cells["Title_File"].Value.ToString();
                        fee.CountrySymbol = GridView_File.CurrentRow.Cells["CountrySymbol"].Value.ToString();
                        fee.ShowDialog();
                    }
                    break;

                case "toolStripMenuItem_ComitToPayment":
                    if (GridView_PatComit.CurrentRow != null)
                    {
                        AddFrom.AddPatentPayment Payment = new AddFrom.AddPatentPayment();
                        Payment.PatentID = (int)GridView_File.CurrentRow.Cells["PatentID"].Value;
                        Payment.TypeFrom = 1;
                        Payment.SourceID = (int)GridView_PatComit.CurrentRow.Cells["PatComitEventID"].Value;
                        Payment.FeeSubject = GridView_PatComit.CurrentRow.Cells["EventContent"].Value.ToString();
                        Payment.Text = Payment.Text + "--" + property_PatentNo;
                        Payment.CountrySymbol = GridView_File.CurrentRow.Cells["CountrySymbol"].Value != null ? GridView_File.CurrentRow.Cells["CountrySymbol"].Value.ToString() : "";
                        Payment.ShowDialog();
                    }
                    break;
                case "toolStripMenuItem_ComitSendMail":
                    if (GridView_PatComit.CurrentRow != null)
                    {
                        US.NotificationLetter letter = new US.NotificationLetter();
                        letter.ApplicantKeys = GridView_File.CurrentRow.Cells["ApplicantKeys"].Value.ToString();
                        letter.MainKey = (int)GridView_File.CurrentRow.Cells["PatentID"].Value;
                        letter.CaseKey = (int)GridView_PatComit.CurrentRow.Cells["PatComitEventID"].Value;
                        letter.DelegateType = GridView_File.CurrentRow.Cells["DelegateType"].Value.ToString() != "" ? (int)GridView_File.CurrentRow.Cells["DelegateType"].Value : -1;
                        letter.Attorney = GridView_PatComit.CurrentRow.Cells["EventAttorneyKey"].Value.ToString() != "" ? (int)GridView_PatComit.CurrentRow.Cells["EventAttorneyKey"].Value : -1;
                        letter.EmailSampleType = "PatentEvent";
                        letter.CaseNo = GridView_File.CurrentRow.Cells["PatentNo"].Value.ToString();
                        letter.Text = letter.Text + "(" + GridView_File.CurrentRow.Cells["PatentNo"].Value.ToString() + ")";
                        letter.Show();
                    }
                    break;
                case "toolStripMenuItem_CopyComit":
                    if (GridView_PatComit.CurrentRow != null)
                    {
                        CopyForm.CopyPatentComitEvent copy = new CopyForm.CopyPatentComitEvent();
                        copy.PatComitEventID = (int)GridView_PatComit.CurrentRow.Cells["PatComitEventID"].Value;
                        copy.PatentID = property_PatentID;
                        copy.Text += "(" + property_PatentNo + "  " + GridView_File.CurrentRow.Cells["CountryName"].Value.ToString() + ")";
                        copy.CountrySymbol = GridView_File.CurrentRow.Cells["CountrySymbol"].Value.ToString();
                        copy.ShowDialog();

                    }
                    break;
                case "ToolStripMenuItem_EventSetGridColumn":
                    SetGridColumnT gc = new SetGridColumnT();
                    gc.CurrentGridSymboID = GridView_PatComit.Tag.ToString();
                    gc.TitleName = "事件記錄";
                    gc.Show();
                    break;
                case "toolStripMenuItem_WorkList":
                    if (GridView_PatComit.CurrentRow != null)
                    {
                        PATControlEventWorkList worklist = new PATControlEventWorkList();
                        worklist.TypeMode = 1;
                        worklist.EventID = (int)GridView_PatComit.CurrentRow.Cells["PatComitEventID"].Value;
                        worklist.EventType = 1;
                        worklist.EventContent = GridView_PatComit.CurrentRow.Cells["EventContent"].Value.ToString();
                        worklist.Show();
                    }
                    break;
            }


        }
        #endregion

        #region contextMenuStrip_EstimateCost_ItemClicked
        private void contextMenuStrip_EstimateCost_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            contextMenuStrip_EstimateCost.Visible = false;

            switch (e.ClickedItem.Name)
            {
                case "toolStripButton_ES_Add":
                case "toolStripMenuItem_Add_ES":  //新增預估成本

                    if (GridView_File.Rows.Count > 0)
                    {
                        AddFrom.AddPatentEstimateCost fee = new AddFrom.AddPatentEstimateCost();
                        fee.PatentID = (int)GridView_File.CurrentRow.Cells["PatentID"].Value;
                        fee.Text = fee.Text + "--" + GridView_File.CurrentRow.Cells["PatentNo"].Value.ToString();
                        fee.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("請先指定申請案       ", "提示訊息", MessageBoxButtons.OK);
                        return;
                    }

                    break;
                case "toolStripMenuItem_Del_ES":
                case "toolStripButton_ES_Del":  //刪除預估成本

                    if (dataGridView_EstimateCost.Rows.Count > 0)
                    {
                        int iLocker = Public.Utility.GetRecordAuth("PatentEstimateCostT", "PTEstimateCostID=" + dataGridView_EstimateCost.CurrentRow.Cells["PTEstimateCostID"].Value.ToString());
                        if (iLocker == -1 || iLocker == iWorkerID)
                        {

                            if (MessageBox.Show("是否確定刪除", "確認視窗", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                            {
                                int iPTEstimateCostID = (int)dataGridView_EstimateCost.CurrentRow.Cells["PTEstimateCostID"].Value;
                                Public.CPatentEstimateCost DelEstimateCost = new Public.CPatentEstimateCost();
                                Public.CPatentEstimateCost.ReadOne(iPTEstimateCostID, ref DelEstimateCost);

                                Public.CPatentManagement pat = new Public.CPatentManagement();
                                Public.CPatentManagement.ReadOne(property_PatentID, ref pat);

                                //刪除記錄檔    
                                Public.CSystemLogT log = new Public.CSystemLogT();
                                log.DelTime = DateTime.Now;
                                log.DelWorkerKey = Properties.Settings.Default.WorkerKEY;
                                log.DelWorker = Properties.Settings.Default.WorkerName;

                                log.DelContent = string.Format("申請案編號:{4}\r\n申請案名稱:{5}\r\n費用內容:{0}\r\n預估成本:{1}\r\n預估利潤:{2}\r\n實際報價:{3}", DelEstimateCost.FeeSubject, DelEstimateCost.EstimateCost.HasValue ? DelEstimateCost.EstimateCost.Value.ToString("#,##0.##") : "0", DelEstimateCost.EstimateProfit.HasValue ? DelEstimateCost.EstimateProfit.Value.ToString("#,##0.##") : "0", DelEstimateCost.RealPrice.HasValue ? DelEstimateCost.RealPrice.Value.ToString("#,##0.##") : "0", pat.PatentNo, pat.Title);
                                log.DelTitle = string.Format("刪除「{0}」資料【預估費用-{1}】", this.Text, DelEstimateCost.FeeSubject);
                                log.Create();

                                DelEstimateCost.Delete(iPTEstimateCostID);
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
                        int iLocker = Public.Utility.GetRecordAuth("PatentEstimateCostT", "PTEstimateCostID=" + dataGridView_EstimateCost.CurrentRow.Cells["PTEstimateCostID"].Value.ToString());
                        if (iLocker == -1 || iLocker == iWorkerID)
                        {
                            if (iLocker != iWorkerID)
                            {
                                Public.Utility.LockRecordAuth("PatentEstimateCostT", iWorkerID, "PTEstimateCostID=" + dataGridView_EstimateCost.CurrentRow.Cells["PTEstimateCostID"].Value.ToString());
                            }
                            EditForm.EditPatentEstimateCost edit = new LawtechPTSystem.EditForm.EditPatentEstimateCost();
                            edit.Text += "(" + property_PatentNo + ")";
                            edit.PTEstimateCostID = (int)dataGridView_EstimateCost.CurrentRow.Cells["PTEstimateCostID"].Value;
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

        #region GridView_PatComit_CellDoubleClick
        private void GridView_PatComit_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != -1 && e.RowIndex != -1)
            {
                if (GridView_PatComit.CurrentRow != null)
                {
                    if (myPermission.UserPermission.HasFlag(PermissionTypes.Modify))//判斷權限
                    {
                        contextMenuStrip_Event0_ItemClicked(contextMenuStrip_Event0, new ToolStripItemClickedEventArgs(EdittoolStripMenuItem));
                    }
                }
            }
        }
        #endregion

        #region ============請款費用記錄快顯============
        private void contextMenuStrip_Fee_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            contextMenuStrip_Fee.Visible = false;

            switch (e.ClickedItem.Name)
            {
                case "bindingNavigatorAddNewItem1":
                case "toolStripMenuItem_BillingAdd":  //請款新增費用

                    if (GridView_File.CurrentRow != null)
                    {
                        AddFrom.AddPatentFee fee = new AddFrom.AddPatentFee();
                        fee.PatentID = (int)GridView_File.CurrentRow.Cells["PatentID"].Value;
                        fee.CountrySymbol = GridView_File.CurrentRow.Cells["CountrySymbol"].Value.ToString();
                        fee.Text = fee.Text + " (" + property_PatentNo + ")";
                        fee.ShowDialog();
                    }

                    break;
                case "bindingNavigatorDeleteItem1":
                case "toolStripMenuItem_BillingDel":  //刪除請款費用

                    if (GridView_Fee.CurrentRow != null)
                    {
                        if (GridView_Fee.CurrentRow.Cells["FeePPP"].Value.ToString() != "")
                        {
                            MessageBox.Show("已登錄了請款單號，若要刪除，請洽帳務人員", "提示訊息", MessageBoxButtons.OK);
                            return;
                        }


                        if (GridView_Fee.CurrentRow.Cells["IsClosing"].Value != DBNull.Value && (bool)GridView_Fee.CurrentRow.Cells["IsClosing"].Value)
                        {
                            MessageBox.Show("該筆請款單號【" + GridView_Fee.CurrentRow.Cells["FeePPP"].Value.ToString() + "】已被關帳，請洽帳務主管", "提示訊息", MessageBoxButtons.OK);
                            return;
                        }

                        if (MessageBox.Show("是否確定刪除", "確認視窗", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            int iFeeKey = (int)GridView_Fee.CurrentRow.Cells["FeeKEY"].Value;
                            Public.CPatentFee DelFee = new Public.CPatentFee();
                            Public.CPatentFee.ReadOne(iFeeKey, ref DelFee);

                            Public.CPatentManagement pat = new Public.CPatentManagement();
                            Public.CPatentManagement.ReadOne(property_PatentID, ref pat);

                            //刪除記錄檔    
                            Public.CSystemLogT log = new Public.CSystemLogT();
                            log.DelTime = DateTime.Now;
                            log.DelWorkerKey = Properties.Settings.Default.WorkerKEY;
                            log.DelWorker = Properties.Settings.Default.WorkerName;
                            log.DelContent = string.Format("申請案編號:{5}\r\n申請案名稱:{6}\r\n費用內容:{0}\r\n請款日期:{1}\r\n請款單號:{2}\r\n請款合計:{3}\r\n幣別:{4}", DelFee.FeeSubject, DelFee.RDate.HasValue ? DelFee.RDate.Value.ToString("yyyy/MM/dd") : "", DelFee.PPP, DelFee.Totall.HasValue ? DelFee.Totall.Value.ToString("#,##0.##") : "", DelFee.TMoney, pat.PatentNo, pat.Title);
                            log.DelTitle = string.Format("刪除「{0}」資料【請款記錄-{1}】", this.Text, DelFee.FeeSubject);
                            log.Create();


                            DelFee.Delete(iFeeKey);
                            GridView_Fee.Rows.Remove(GridView_Fee.CurrentRow);

                            MessageBox.Show("刪除請款記錄成功", "提示訊息", MessageBoxButtons.OK);
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
                            upfile.Text = GridView_File.CurrentRow.Cells["PatentNo"].Value.ToString() + "  上傳請款費用相關文件";
                            upfile.UploadMode = 3;
                            upfile.MainFileType = 3;
                            upfile.MainFileKey = property_PatentID;
                            upfile.ChildFileKey = (int)GridView_Fee.CurrentRow.Cells["FeeKEY"].Value;

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
                        if (GridView_File.CurrentRow.Cells["ApplicantNames"].Value == null)
                        {
                            MessageBox.Show("申請人不得為空值，請確認", "提示訊息");
                            return;
                        }

                        ReportView.FeeReport fee = new ReportView.FeeReport();
                        fee.FeeKEY = (int)GridView_Fee.CurrentRow.Cells["FeeKEY"].Value;

                        fee.ApplicantKeys = GridView_File.CurrentRow.Cells["ApplicantKeys"].Value.ToString();
                        fee.ApplicantNames = GridView_File.CurrentRow.Cells["ApplicantNames"].Value.ToString();

                        fee.PatentID = (int)GridView_File.CurrentRow.Cells["PatentID"].Value;
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
                        feereport.ModeType = 1;
                        feereport.FeeKEY = (int)GridView_Fee.CurrentRow.Cells["FeeKEY"].Value;
                        feereport.PatentID = (int)GridView_File.CurrentRow.Cells["PatentID"].Value;
                        feereport.Show();
                    }
                    break;
                case "toolStripMenuItem_CopyFee":
                    if (GridView_Fee.CurrentRow != null)
                    {
                        CopyForm.CopyPatentFee copy = new CopyForm.CopyPatentFee();
                        copy.property_FeeKEY = (int)GridView_Fee.CurrentRow.Cells["FeeKEY"].Value;
                        copy.PatentID = (int)GridView_File.CurrentRow.Cells["PatentID"].Value;
                        copy.CountrySymbol = GridView_File.CurrentRow.Cells["CountrySymbol"].Value.ToString();
                        copy.ShowDialog();
                    }
                    break;

                case "開啟費用相關文件ToolStripMenuItem":
                    if (GridView_Fee.CurrentRow != null)
                    {
                        bool bConnectionFile = Properties.Settings.Default.IsFileServerConnection;
                        if (bConnectionFile)
                        {
                            ViewUpdateFileList subForm = new ViewUpdateFileList();
                            subForm.Text = GridView_File.CurrentRow.Cells["PatentNo"].Value.ToString() + "的請款費用相關文件";
                            subForm.FileKind = 3;
                            subForm.FileType = 3;
                            subForm.MainParentID = (int)GridView_File.CurrentRow.Cells["PatentID"].Value;
                            subForm.Child_ID = (int)GridView_Fee.CurrentRow.Cells["FeeKEY"].Value;
                            subForm.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("請確認檔案上傳路徑是否有正常連結!!");
                        }
                    }
                    break;
                case "toolStripMenuItem_BillEdit":
                case "toolStripButton_FeeEdit":
                    if (GridView_Fee.CurrentRow != null)
                    {

                        if (GridView_Fee.CurrentRow.Cells["IsClosing"].Value != DBNull.Value && (bool)GridView_Fee.CurrentRow.Cells["IsClosing"].Value)
                        {
                            MessageBox.Show("該筆請款單號【" + GridView_Fee.CurrentRow.Cells["FeePPP"].Value.ToString() + "】已被關帳，請洽帳務主管", "提示訊息", MessageBoxButtons.OK);
                            return;
                        }


                        if (GridView_Fee.CurrentRow.Cells["FeePPP"].Value.ToString() != "")
                        {
                            MessageBox.Show("已登錄了請款單號，若要修改，請洽帳務人員", "提示訊息", MessageBoxButtons.OK);
                            return;
                        }


                        //判斷是否有人使用中
                        int iLocker = Public.Utility.GetRecordAuth("PatentFeeT", "FeeKEY=" + GridView_Fee.CurrentRow.Cells["FeeKEY"].Value.ToString());
                        if (iLocker == -1 || iLocker == iWorkerID)
                        {
                            if (iLocker != iWorkerID)
                            {
                                Public.Utility.LockRecordAuth("PatentFeeT", iWorkerID, "FeeKEY=" + GridView_Fee.CurrentRow.Cells["FeeKEY"].Value.ToString());
                            }

                            EditForm.EditPatentFee edit = new EditForm.EditPatentFee();
                            edit.CountrySymbol = GridView_File.CurrentRow.Cells["CountrySymbol"].Value.ToString();
                            edit.property_FeeKEY = (int)GridView_Fee.CurrentRow.Cells["FeeKEY"].Value;
                            edit.Text += "(" + property_PatentNo + ")";
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
                case "toolStripMenuItem_SendMailFee":
                    if (GridView_Fee.CurrentRow != null)
                    {
                        US.NotificationLetter letter = new US.NotificationLetter();
                        letter.ApplicantKeys = GridView_File.CurrentRow.Cells["ApplicantKeys"].Value.ToString();
                        letter.MainKey = (int)GridView_File.CurrentRow.Cells["PatentID"].Value;
                        letter.CaseKey = (int)GridView_Fee.CurrentRow.Cells["FeeKEY"].Value;
                        letter.DelegateType = GridView_File.CurrentRow.Cells["DelegateType"].Value.ToString() != "" ? (int)GridView_File.CurrentRow.Cells["DelegateType"].Value : -1;
                        letter.Attorney = GridView_Fee.CurrentRow.Cells["FeeAttorney"].Value.ToString() != "" ? (int)GridView_Fee.CurrentRow.Cells["FeeAttorney"].Value : -1;
                        letter.EmailSampleType = "PatentFee";
                        letter.CaseNo = GridView_File.CurrentRow.Cells["PatentNo"].Value.ToString();
                        letter.Text = letter.Text + "(" + GridView_File.CurrentRow.Cells["PatentNo"].Value.ToString() + ")";
                        letter.Show();
                    }
                    break;
                case "ToolStripMenuItem_FeeSetGridColumn":
                    SetGridColumnT gc = new SetGridColumnT();
                    gc.CurrentGridSymboID = GridView_Fee.Tag.ToString();
                    gc.TitleName = "請款記錄";
                    gc.Show();
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
                        contextMenuStrip_Fee_ItemClicked(GridView_Fee, new ToolStripItemClickedEventArgs(toolStripMenuItem_BillEdit));
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

                    if (GridView_File.CurrentRow != null)
                    {
                        AddFrom.AddPatentPayment Payment = new AddFrom.AddPatentPayment();
                        Payment.CountrySymbol = GridView_File.CurrentRow.Cells["CountrySymbol"].Value.ToString();
                        Payment.PatentID = (int)GridView_File.CurrentRow.Cells["PatentID"].Value;
                        Payment.Text = Payment.Text + "(" + property_PatentNo + "  " + GridView_File.CurrentRow.Cells["CountryName"].Value.ToString() + ")";
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



                        //2.判斷是否有人使用中
                        int iLocker = Public.Utility.GetRecordAuth("PatentPaymentT", "PaymentID=" + dataGridView_Billing.CurrentRow.Cells["PaymentID"].Value.ToString());
                        if (iLocker == -1 || iLocker == iWorkerID)
                        {
                            if (iLocker != iWorkerID)
                            {
                                Public.Utility.LockRecordAuth("PatentPaymentT", iWorkerID, "PaymentID=" + dataGridView_Billing.CurrentRow.Cells["PaymentID"].Value.ToString());
                            }
                            string sName = dataGridView_Billing.CurrentRow.Cells["FeeSubject_Payment"].Value.ToString();

                            if (MessageBox.Show("是否確定刪除\r\n【" + sName + "】", "確認視窗", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                            {
                                int iPaymentIDK = (int)dataGridView_Billing.CurrentRow.Cells["PaymentID"].Value;
                                Public.CPatentPayment DelBilling = new Public.CPatentPayment();
                                Public.CPatentPayment.ReadOne(iPaymentIDK, ref DelBilling);

                                Public.CPatentManagement pat = new Public.CPatentManagement();
                                Public.CPatentManagement.ReadOne(property_PatentID, ref pat);

                                //刪除記錄檔    
                                Public.CSystemLogT log = new Public.CSystemLogT();
                                log.DelTime = DateTime.Now;
                                log.DelWorkerKey = Properties.Settings.Default.WorkerKEY;
                                log.DelWorker = Properties.Settings.Default.WorkerName;
                                log.DelContent = string.Format("申請案編號:{7}\r\n申請案名稱: {8}\r\n費用內容: {0}\r\n收件日期:{1}\r\n付款期限:{2}\r\n付款日期:{3}\r\n請款單編號:{4}\r\n金額合計:{5}\r\n幣別:{6}",
                                    DelBilling.FeeSubject,
                                    DelBilling.ReciveDate.HasValue ? DelBilling.ReciveDate.Value.ToString("yyyy/MM/dd") : "",
                                    DelBilling.PayDueDate.HasValue ? DelBilling.PayDueDate.Value.ToString("yyyy/MM/dd") : "",
                                    DelBilling.PaymentDate.HasValue ? DelBilling.PaymentDate.Value.ToString("yyyy/MM/dd") : "",
                                    DelBilling.BillingNo ?? "",
                                    DelBilling.Totall.HasValue ? DelBilling.Totall.Value.ToString("#,##0.##") : "",
                                    DelBilling.IMoney,
                                    pat.PatentNo,
                                    pat.Title);
                                log.DelTitle = string.Format("刪除「{0}」資料【付款記錄-{1}】", this.Text, DelBilling.FeeSubject);
                                log.Create();


                                DelBilling.Delete(iPaymentIDK);
                                dataGridView_Billing.Rows.Remove(dataGridView_Billing.CurrentRow);

                                MessageBox.Show("刪除付款費用記錄成功", "提示訊息", MessageBoxButtons.OK);
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
                            upfile.Text = GridView_File.CurrentRow.Cells["PatentNo"].Value.ToString() + "  上傳付款費用相關文件";
                            upfile.UploadMode = 3;
                            upfile.MainFileType = 4;
                            upfile.MainFileKey = property_PatentID;
                            upfile.ChildFileKey = (int)dataGridView_Billing.CurrentRow.Cells["PaymentID"].Value;

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
                        ReportView.PaymentReport payment = new ReportView.PaymentReport();
                        payment.Text += "(" + property_PatentNo + ")";
                        payment.Worker = Properties.Settings.Default.WorkerName;
                        string strDes = string.Format(@"
案件編號：{0} 
案件名稱：{1}
費用科目：{2} 
           服務費： {3}  {4}
             官費： {3}  {5}
             雜費： {3}  {6}
       __________________________
         金額小計： {3}  {7}", GridView_File.CurrentRow.Cells["PatentNo"].Value.ToString(),
                        GridView_File.CurrentRow.Cells["Title_File"].Value.ToString(),
                        txt_PayFeeSubject.Text, txt_PayIMoney.Text,
                        txt_IServiceFee.Text, txt_GovFee.Text,
                        txt_OtherFee.Text, txt_PayTotall.Text);

                        payment.Description = strDes;
                        payment.Department = "專利部";
                        payment.Amount = txt_PayTotall.Text;
                        payment.Reciver = txt_Attorney.Text;
                        payment.IMoney = txt_PayIMoney.Text;
                        payment.InvoiceNo = txt_IReceiptNo.Text;
                        payment.CountryName = GridView_File.CurrentRow.Cells["CountryName"].Value.ToString();
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
                            subForm.Text = GridView_File.CurrentRow.Cells["PatentNo"].Value.ToString() + "的付款費用相關文件";
                            subForm.FileKind = 3;
                            subForm.FileType = 4;
                            subForm.MainParentID = (int)GridView_File.CurrentRow.Cells["PatentID"].Value;
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
                        if (dataGridView_Billing.CurrentRow.Cells["BillingNo"].Value.ToString() != "")
                        {
                            MessageBox.Show("已登錄了請款單號【" + dataGridView_Billing.CurrentRow.Cells["BillingNo"].Value.ToString() + "】，若要修改，請洽帳務人員", "提示訊息", MessageBoxButtons.OK);
                            return;
                        }

                        //判斷該筆是否已經關帳
                        if (dataGridView_Billing.CurrentRow.Cells["IsClosingPayment"].Value != DBNull.Value && (bool)dataGridView_Billing.CurrentRow.Cells["IsClosingPayment"].Value)
                        {
                            MessageBox.Show("該筆付款記錄【" + dataGridView_Billing.CurrentRow.Cells["BillingNo"].Value.ToString() + "】已經被關帳，請洽帳務主管", "提示訊息", MessageBoxButtons.OK);
                            return;
                        }



                        //2.判斷是否有人使用中
                        int iLocker = Public.Utility.GetRecordAuth("PatentPaymentT", "PaymentID=" + dataGridView_Billing.CurrentRow.Cells["PaymentID"].Value.ToString());
                        if (iLocker == -1 || iLocker == iWorkerID)
                        {
                            if (iLocker != iWorkerID)
                            {
                                Public.Utility.LockRecordAuth("PatentPaymentT", iWorkerID, "PaymentID=" + dataGridView_Billing.CurrentRow.Cells["PaymentID"].Value.ToString());
                            }

                            EditForm.EditPatentPayment edit = new EditForm.EditPatentPayment();
                            edit.Text = edit.Text + "(" + property_PatentNo + "  " + GridView_File.CurrentRow.Cells["CountryName"].Value.ToString() + ")";
                            edit.CountrySymbol = GridView_File.CurrentRow.Cells["CountrySymbol"].Value.ToString();
                            edit.property_PaymentID = (int)dataGridView_Billing.CurrentRow.Cells["PaymentID"].Value;
                            edit.ShowDialog();

                            //Public.Utility.NuLockRecordAuth("PatentPaymentT", "PaymentID=" + dataGridView_Billing.CurrentRow.Cells["PaymentID"].Value.ToString());
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
                        US.NotificationLetter letter = new US.NotificationLetter();
                        letter.ApplicantKeys = GridView_File.CurrentRow.Cells["ApplicantKeys"].Value.ToString();
                        letter.MainKey = (int)GridView_File.CurrentRow.Cells["PatentID"].Value;
                        letter.CaseKey = (int)dataGridView_Billing.CurrentRow.Cells["PaymentID"].Value;
                        letter.DelegateType = GridView_File.CurrentRow.Cells["DelegateType"].Value.ToString() != "" ? (int)GridView_File.CurrentRow.Cells["DelegateType"].Value : -1;
                        letter.Attorney = dataGridView_Billing.CurrentRow.Cells["AttorneyPayment"].Value.ToString() != "" ? (int)dataGridView_Billing.CurrentRow.Cells["AttorneyPayment"].Value : -1;
                        letter.EmailSampleType = "PatentPayment";
                        letter.CaseNo = GridView_File.CurrentRow.Cells["PatentNo"].Value.ToString();
                        letter.Text = letter.Text + "(" + GridView_File.CurrentRow.Cells["PatentNo"].Value.ToString() + ")";
                        letter.Show();
                    }
                    break;
                case "ToolStripMenuItem_PaymentSetGridColumn":
                    SetGridColumnT gc = new SetGridColumnT();
                    gc.CurrentGridSymboID = dataGridView_Billing.Tag.ToString();
                    gc.TitleName = "付款記錄";
                    gc.Show();
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

        #region ============dataGridView_Billing_SelectionChanged===============
        private void dataGridView_Billing_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView_Billing.CurrentRow != null)
            {
                txt_PayFeeSubject.Text = dataGridView_Billing.CurrentRow.Cells["FeeSubject_Payment"].Value.ToString();
                txt_PayFeePhase.Text = dataGridView_Billing.CurrentRow.Cells["FeePhase_Payment"].FormattedValue.ToString();
                txt_FClientTransactor.Text = dataGridView_Billing.CurrentRow.Cells["FClientTransactor_Payment"].FormattedValue.ToString();
                txt_PayPayKind.Text = dataGridView_Billing.CurrentRow.Cells["PayKind_Payment"].Value.ToString();
                txt_PayIMoney.Text = dataGridView_Billing.CurrentRow.Cells["IMoney_Payment"].Value.ToString();
                txt_IServiceFee.Text = dataGridView_Billing.CurrentRow.Cells["IServiceFee_Payment"].Value.ToString();
                txt_GovFee.Text = dataGridView_Billing.CurrentRow.Cells["GovFee_Payment"].Value.ToString();
                txt_OtherFee.Text = dataGridView_Billing.CurrentRow.Cells["OtherFee_Payment"].Value.ToString();
                txt_IReceiptNo.Text = dataGridView_Billing.CurrentRow.Cells["IReceiptNo_Payment"].Value.ToString();
                maskedTextBox_IReceiptDate.Text = dataGridView_Billing.CurrentRow.Cells["IReceiptDate_Payment"].Value.ToString();
                txt_PayTotall.Text = dataGridView_Billing.CurrentRow.Cells["Totall_Payment"].Value.ToString();
                txt_PayRemark.Text = dataGridView_Billing.CurrentRow.Cells["Remark_Payment"].Value.ToString();
                txt_BillCheck.Text = dataGridView_Billing.CurrentRow.Cells["BillCheck_Payment"].Value.ToString();
                maskedTextBox_ReciveDate.Text = dataGridView_Billing.CurrentRow.Cells["ReciveDate_Payment"].Value.ToString();
                maskedTextBox_PayDueDate.Text = dataGridView_Billing.CurrentRow.Cells["PayDueDate_Payment"].Value.ToString();
                checkBox_IsBilling.Checked = (bool)dataGridView_Billing.CurrentRow.Cells["IsBilling_Payment"].Value;
                txt_BillingNo.Text = dataGridView_Billing.CurrentRow.Cells["BillingNo_Payment"].Value.ToString();
                checkBox_IsCopyFile.Checked = (bool)dataGridView_Billing.CurrentRow.Cells["IsCopyFile_Payment"].Value;
                checkBox_IsScan.Checked = (bool)dataGridView_Billing.CurrentRow.Cells["IsScan_Payment"].Value;

            }
        }
        #endregion

        #region bSource_File_DataError
        private void bSource_File_DataError(object sender, BindingManagerDataErrorEventArgs e)
        {
            string ss = e.Exception.Message.ToString();
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

        #region =============linkLabel===============
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LinkLabel link = (LinkLabel)sender;
            US.PopMemo pop;
            switch (link.Name)
            {
                case "linkLabel_PaymentMemo":
                    pop = new LawtechPTSystem.US.PopMemo(txt_Memo, true, link.Text);
                    break;
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
                case "linkLabel_Inventor":
                    pop = new LawtechPTSystem.US.PopMemo(txt_Inventor, true, link.Text);
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
                case "linkLabel_ApplicantNames":
                    pop = new LawtechPTSystem.US.PopMemo(txt_Applicant, true, link.Text);
                    break;
                case "linkLabel_MainCustomer":
                    pop = new LawtechPTSystem.US.PopMemo(txt_MainCustomer, true, link.Text);
                    break;
                case "linkLabel_PatentAttorney":
                    pop = new LawtechPTSystem.US.PopMemo(txt_PatentAttorney, true, link.Text);
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

        #region PATMF1_KeyDown
        private void PATMF1_KeyDown(object sender, KeyEventArgs e)
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

        #region dataGridView_EstimateCost_CellDoubleClick
        private void dataGridView_EstimateCost_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != -1 && e.RowIndex != -1)
            {
                if (dataGridView_EstimateCost.CurrentRow != null)
                {
                    if (myPermission.UserPermission.HasFlag(PermissionTypes.Modify))//判斷權限
                    {
                        contextMenuStrip_EstimateCost_ItemClicked(dataGridView_EstimateCost, new ToolStripItemClickedEventArgs(toolStripMenuItem_Edit_ES));
                    }
                }
            }
        }
        #endregion

        private void GridView_File_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            //this.GridView_File.SelectionChanged += new System.EventHandler(this.GridView_File_SelectionChanged);
            //GridView_File_SelectionChanged(null, null);
        }

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

        #region  private void dataGridView_PatentRight_CellDoubleClick(object sender, DataGridViewCellEventArgs e)

        private void dataGridView_PatentRight_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                string clumName = dataGridView_PatentRight.Columns[e.ColumnIndex].Name;
                switch (clumName)
                {
                    case "patentisuregspecxmla_url":
                    case "patentpubmtiff_url":
                    case "patentpubxml_url":
                    case "patentisuregspecmtiff_url":
                        if (dataGridView_PatentRight.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Trim() != "")
                        {
                            Public.Utility.ProcessStart(dataGridView_PatentRight.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                        }
                        break;
                }

            }
        }
        #endregion

        private void contextMenuStrip_PatentRight_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            contextMenuStrip_PatentRight.Visible = false;

            switch (e.ClickedItem.Name)
            {
                case "toolStripMenuItem_PatRight_SetCulnme":
                    SetGridColumnT gc = new SetGridColumnT();
                    gc.CurrentGridSymboID = dataGridView_PatentRight.Tag.ToString();
                    gc.TitleName = "智財局專利申請案資料";
                    gc.Show();
                    break;
            }
        }

      
    }
}
