using System;
using System.Windows.Forms;
using System.IO;
using System.Threading.Tasks;

namespace LawtechPTSystemByFirm.SubFrom
{
    public partial class PATMF : Form
    {
      
        public PATMF()
        {
            InitializeComponent();
        }

        #region ===========資料集===========
        /// <summary>
        /// PatentManagement 資料集
        /// </summary>
        public QS_DataSet.PatentManagementTDataTable dt_PatentManagement
        {
            get
            {
                return this.qS_DataSet.PatentManagementT;
            }
            
        }

        /// <summary>
        /// PatComitEventT 委辦
        /// </summary>
        public QS_DataSet.PatComitEventTDataTable dt_PatComitEventT
        {
            get
            {
                return this.qS_DataSet.PatComitEventT;
            }

        }

        /// <summary>
        /// PatNotifyEventT 來函
        /// </summary>
        public QS_DataSet.PatNotifyEventTDataTable dt_PatNotifyEventT
        {
            get
            {
                return this.qS_DataSet.PatNotifyEventT;
            }

        }

        /// <summary>
        /// PatentFeeT 請款費用
        /// </summary>
        public QS_DataSet.PatentFeeTDataTable dt_PatentFeeT
        {
            get
            {
                return this.qS_DataSet.PatentFeeT;
            }

        }

        /// <summary>
        /// PatentFeeT 付款費用
        /// </summary>
        public QS_DataSet.PatentPaymentTDataTable dt_PatentPaymentT
        {
            get
            {
                return this.qS_DataSet.PatentPaymentT;
            }

        }

        /// <summary>
        /// 重新整理資料集 1.委辦  2.來函  3.請款費用  4.付款費用
        /// </summary>
        /// <param name="iTable"></param>
        public void RefrashDataTable(int iTable)
        {
            switch (iTable)
            {
                case 0:
                    this.qS_DataSet.PatentManagementT.Rows.Clear();
                    this.patentManagementTTableAdapter.Fill(this.qS_DataSet.PatentManagementT);
                    break;
                case 1:
                    this.qS_DataSet.PatComitEventT.Rows.Clear();
                    this.patComitEventTTableAdapter.Fill(this.qS_DataSet.PatComitEventT, property_PatentID);                   
                    break;

                case 2:
                    this.qS_DataSet.PatNotifyEventT.Rows.Clear();
                    this.patNotifyEventTTableAdapter.Fill(this.qS_DataSet.PatNotifyEventT, property_PatentID);
                    break;

                case 3:
                    this.qS_DataSet.PatentFeeT.Rows.Clear();
                    this.patentFeeTTableAdapter.Fill(this.qS_DataSet.PatentFeeT, property_PatentID);
                    break;

                case 4:
                    this.qS_DataSet.PatentPaymentT.Rows.Clear();
                    this.patentPaymentTTableAdapter.Fill(this.qS_DataSet.PatentPaymentT, property_PatentID);
                    break;
            }
        }
        #endregion

        #region  ============property============
        /// <summary>
        /// PatentID
        /// </summary>
        public int property_PatentID
        {
            get {
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
        #endregion

        #region ==============PATMF_Load 、 PATMF_FormClosed==============
        private void PATMF_Load(object sender, EventArgs e)
        {
            
           
            Public.PublicForm Forms = new LawtechPTSystemByFirm.Public.PublicForm();
            Forms.PATMF = this;
                      
            this.patSelectDateMode_DropTableAdapter.Fill(this.qS_DataSet.PatSelectDateMode_Drop);            
           
            //this.patentManagementTTableAdapter.Fill(this.qS_DataSet.PatentManagementT);  
            
            int LastYear=DateTime.Now.Year-1;
            maskedTextBox_S.Text = new DateTime(LastYear, 1, 1).ToString("yyyy/MM/dd");

            TabFileBinding();
            ControlBindingPatComit();
            ControlBindingPatNotify();
            ControlBindingTMFee();
            ControlBindingTMPayment();

            but_Search_Click(null,null);
        }

        private void PATMF_FormClosed(object sender, FormClosedEventArgs e)
        {
            Public.PublicForm Forms = new LawtechPTSystemByFirm.Public.PublicForm();
            Forms.PATMF = null;
        }
        #endregion

        #region ================ControlBinding================
        public void TabFileBinding()
        {
            //申請案卷號
            txt_FileNo.DataBindings.Clear();
            txt_FileNo.DataBindings.Add("Text", bSource_File, "PatentNo", true, DataSourceUpdateMode.OnValidation, "", "");
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
            //實際申請日
            txt_Applicant.DataBindings.Clear();
            txt_Applicant.DataBindings.Add("Text", bSource_File, "ApplicantName", true, DataSourceUpdateMode.OnValidation, "", "");
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
            txt_PayYear.DataBindings.Clear();
            txt_PayYear.DataBindings.Add("Value", bSource_File, "PayYear", false, DataSourceUpdateMode.OnValidation, 0m);

            txt_AddDay.DataBindings.Clear();
            txt_AddDay.DataBindings.Add("Value", bSource_File, "AddDay", true, DataSourceUpdateMode.OnValidation);

            //引案人
            txt_Introducer.DataBindings.Clear();
            txt_Introducer.DataBindings.Add("Text", bSource_File, "Introducer", true, DataSourceUpdateMode.OnValidation);

            //備註
            txt_Remark2.DataBindings.Clear();
            txt_Remark2.DataBindings.Add("Text", bSource_File, "Remark", true, DataSourceUpdateMode.OnValidation);

           //本所承辦人
            txt_ClientWorker.DataBindings.Clear();
            txt_ClientWorker.DataBindings.Add("Text", bSource_File, "WorkerName", true, DataSourceUpdateMode.OnValidation);
            
            //優先權
            txt_Priority.DataBindings.Clear();
            txt_Priority.DataBindings.Add("Text", bSource_File, "PriorityBaseName", true, DataSourceUpdateMode.OnValidation);

            //審查請求
            txt_ISexam.DataBindings.Clear();
            txt_ISexam.DataBindings.Add("Text", bSource_File, "ISExamName", true, DataSourceUpdateMode.OnValidation);

            
            //委託類型
            txt_DelegateType.DataBindings.Clear();
            txt_DelegateType.DataBindings.Add("Text", bSource_File, "DelegateTypeName", true, DataSourceUpdateMode.OnValidation);
            
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
            mask_IntroductionDate.DataBindings.Add("Text", bSource_File, "IntroductionDate", true, DataSourceUpdateMode.OnPropertyChanged, "    /  /", "yyyy/MM/dd");

            //最早母案申請日
            maskedTextBox_EarlyMotherDate.DataBindings.Clear();
            maskedTextBox_EarlyMotherDate.DataBindings.Add("Text", bSource_File, "EarlyMotherDate", true, DataSourceUpdateMode.OnPropertyChanged, "    /  /", "yyyy/MM/dd");
           
            //實際申請日
            maskedTextBox_ApplicationDate.DataBindings.Clear();
            maskedTextBox_ApplicationDate.DataBindings.Add("Text", bSource_File, "ApplicationDate", true, DataSourceUpdateMode.OnPropertyChanged, "    /  /", "yyyy/MM/dd");
            
            //公開日期
            maskedTextBox_Pubdate.DataBindings.Clear();
            maskedTextBox_Pubdate.DataBindings.Add("Text", bSource_File, "Pubdate", true, DataSourceUpdateMode.OnValidation, "    /  /", "yyyy/MM/dd");
           
            //核准日期
            maskedTextBox_AllowDate.DataBindings.Clear();
            maskedTextBox_AllowDate.DataBindings.Add("Text", bSource_File, "AllowDate", true, DataSourceUpdateMode.OnValidation, "    /  /", "yyyy/MM/dd");
           
            //公告日期
            maskedTextBox_AllowPubdate.DataBindings.Clear();
            maskedTextBox_AllowPubdate.DataBindings.Add("Text", bSource_File, "AllowPubdate", true, DataSourceUpdateMode.OnPropertyChanged, "    /  /", "yyyy/MM/dd");
            
            //收到證書日
            maskedTextBox_GetDate.DataBindings.Clear();
            maskedTextBox_GetDate.DataBindings.Add("Text", bSource_File, "GetDate", true, DataSourceUpdateMode.OnValidation, "    /  /", "yyyy/MM/dd");

            maskedTextBox_Registerdate.DataBindings.Clear();
            maskedTextBox_Registerdate.DataBindings.Add("Text", bSource_File, "Registerdate", true, DataSourceUpdateMode.OnPropertyChanged, "    /  /", "yyyy/MM/dd");

            maskedTextBox_DueDate.DataBindings.Clear();
            maskedTextBox_DueDate.DataBindings.Add("Text", bSource_File, "DueDate", true, DataSourceUpdateMode.OnPropertyChanged, "    /  /", "yyyy/MM/dd");

            maskedTextBox_RenewTo.DataBindings.Clear();
            maskedTextBox_RenewTo.DataBindings.Add("Text", bSource_File, "RenewTo", true, DataSourceUpdateMode.OnPropertyChanged, "    /  /", "yyyy/MM/dd");

            maskedTextBox_CloseDate.DataBindings.Clear();
            maskedTextBox_CloseDate.DataBindings.Add("Text", bSource_File, "CloseDate", true, DataSourceUpdateMode.OnPropertyChanged, "    /  /", "yyyy/MM/dd");

            //備註
            txt_CloseCaus.DataBindings.Clear();
            txt_CloseCaus.DataBindings.Add("Text", bSource_File, "CloseCaus", true, DataSourceUpdateMode.OnValidation);

            //最早優先申請日
            maskedTextBox_EarlyPriorityDate.DataBindings.Clear();
            maskedTextBox_EarlyPriorityDate.DataBindings.Add("Text", bSource_File, "EarlyPriorityDate", true, DataSourceUpdateMode.OnPropertyChanged, "    /  /", "yyyy/MM/dd");
           
        }

        public void ControlBindingPatComit()
        {
            txt_ComitEventContent.DataBindings.Clear();
            txt_ComitEventContent.DataBindings.Add("Text", patComitEventTBindingSource, "EventContent", true, DataSourceUpdateMode.OnPropertyChanged, "", "");

            txt_WorkerKey.DataBindings.Clear();
            txt_WorkerKey.DataBindings.Add("Text", patComitEventTBindingSource, "WorkerName", true, DataSourceUpdateMode.OnPropertyChanged, "", "");

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
            
        }

        public void ControlBindingPatNotify()
        {
            txt_NotifyEventContent.DataBindings.Clear();
            txt_NotifyEventContent.DataBindings.Add("Text", patNotifyEventTBindingSource, "NotifyEventContent", true, DataSourceUpdateMode.OnPropertyChanged, "", "");

            txt_NotifyWorkerKey.DataBindings.Clear();
            txt_NotifyWorkerKey.DataBindings.Add("Text", patNotifyEventTBindingSource, "WorkerName", true, DataSourceUpdateMode.OnPropertyChanged, "", "");

            txt_NotifyAttorneyKey.DataBindings.Clear();
            txt_NotifyAttorneyKey.DataBindings.Add("Text", patNotifyEventTBindingSource, "AttorneyFirm", true, DataSourceUpdateMode.OnPropertyChanged, "", "");

            txt_NotifyALiaisonerKey.DataBindings.Clear();
            txt_NotifyALiaisonerKey.DataBindings.Add("Text", patNotifyEventTBindingSource, "Liaisoner", true, DataSourceUpdateMode.OnPropertyChanged, "", "");
            
            txt_NotifyResult.DataBindings.Clear();
            txt_NotifyResult.DataBindings.Add("Text", patNotifyEventTBindingSource, "NotifyResult", true, DataSourceUpdateMode.OnPropertyChanged, "", "");

            txt_NotifyRemark.DataBindings.Clear();
            txt_NotifyRemark.DataBindings.Add("Text", patNotifyEventTBindingSource, "NotifyRemark", true, DataSourceUpdateMode.OnPropertyChanged, "", "");

            maskedTextBox_NotifyComitDate.DataBindings.Clear();
            maskedTextBox_NotifyComitDate.DataBindings.Add("Text", patNotifyEventTBindingSource, "NotifyComitDate", true, DataSourceUpdateMode.OnPropertyChanged, "    /  /", "yyyy/MM/dd");

            maskedTextBox_NotifyOfficerDate.DataBindings.Clear();
            maskedTextBox_NotifyOfficerDate.DataBindings.Add("Text", patNotifyEventTBindingSource, "NotifyOfficerDate", true, DataSourceUpdateMode.OnPropertyChanged, "    /  /", "yyyy/MM/dd");

            maskedTextBox_NotifyOccurDate.DataBindings.Clear();
            maskedTextBox_NotifyOccurDate.DataBindings.Add("Text", patNotifyEventTBindingSource, "OccurDate", true, DataSourceUpdateMode.OnPropertyChanged, "    /  /", "yyyy/MM/dd");

            maskedTextBox_NotifyAttorneyDueDate.DataBindings.Clear();
            maskedTextBox_NotifyAttorneyDueDate.DataBindings.Add("Text", patNotifyEventTBindingSource, "NotifyAttorneyDueDate", true, DataSourceUpdateMode.OnPropertyChanged, "    /  /", "yyyy/MM/dd");

            maskedTextBox_NotifyDueDate.DataBindings.Clear();
            maskedTextBox_NotifyDueDate.DataBindings.Add("Text", patNotifyEventTBindingSource, "DueDate", true, DataSourceUpdateMode.OnPropertyChanged, "    /  /", "yyyy/MM/dd");

            maskedTextBox_NotifyStartDate.DataBindings.Clear();
            maskedTextBox_NotifyStartDate.DataBindings.Add("Text", patNotifyEventTBindingSource, "NotifyStartDate", true, DataSourceUpdateMode.OnPropertyChanged, "    /  /", "yyyy/MM/dd");

            maskedTextBox_NotifyFinishDate.DataBindings.Clear();
            maskedTextBox_NotifyFinishDate.DataBindings.Add("Text", patNotifyEventTBindingSource, "FinishDate", true, DataSourceUpdateMode.OnPropertyChanged, "    /  /", "yyyy/MM/dd");


        }

        #region ControlBindingTMFee
        public void ControlBindingTMFee()
        {

            txt_FeeSubject.DataBindings.Clear();
            txt_FeeSubject.DataBindings.Add("Text", patentFeeTBindingSource, "FeeSubject", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_FeePhase.DataBindings.Clear();
            txt_FeePhase.DataBindings.Add("Text", patentFeeTBindingSource, "FeePhaseName", true, DataSourceUpdateMode.OnValidation, "", "");

            txtAttorneyFee1.DataBindings.Clear();
            txtAttorneyFee1.DataBindings.Add("Text", patentFeeTBindingSource, "IAttorneyFee", true, DataSourceUpdateMode.OnValidation, "", "");

            txtAttorneyFee2.DataBindings.Clear();
            txtAttorneyFee2.DataBindings.Add("Text", patentFeeTBindingSource, "OAttorneyFee", true, DataSourceUpdateMode.OnValidation, "", "");

            txtAttorneyFee3.DataBindings.Clear();
            txtAttorneyFee3.DataBindings.Add("Text", patentFeeTBindingSource, "GovFee", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_IMoney.DataBindings.Clear();
            txt_IMoney.DataBindings.Add("Text", patentFeeTBindingSource, "IMoney", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_OMoney.DataBindings.Clear();
            txt_OMoney.DataBindings.Add("Text", patentFeeTBindingSource, "OMoney", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_GMoney.DataBindings.Clear();
            txt_GMoney.DataBindings.Add("Text", patentFeeTBindingSource, "GMoney", true, DataSourceUpdateMode.OnValidation, "", "");

            txtMoney1.DataBindings.Clear();
            txtMoney1.DataBindings.Add("Text", patentFeeTBindingSource, "ItoNT", true, DataSourceUpdateMode.OnValidation, "", "");

            txtMoney2.DataBindings.Clear();
            txtMoney2.DataBindings.Add("Text", patentFeeTBindingSource, "OtoNT", true, DataSourceUpdateMode.OnValidation, "", "");

            txtMoney3.DataBindings.Clear();
            txtMoney3.DataBindings.Add("Text", patentFeeTBindingSource, "GtoNT", true, DataSourceUpdateMode.OnValidation, "", "");

            txtAttorneyFeeTotal1.DataBindings.Clear();
            txtAttorneyFeeTotal1.DataBindings.Add("Text", patentFeeTBindingSource, "ITotall", true, DataSourceUpdateMode.OnValidation, "", "");

            txtAttorneyFeeTotal2.DataBindings.Clear();
            txtAttorneyFeeTotal2.DataBindings.Add("Text", patentFeeTBindingSource, "OTotall", true, DataSourceUpdateMode.OnValidation, "", "");

            txtAttorneyFeeTotal3.DataBindings.Clear();
            txtAttorneyFeeTotal3.DataBindings.Add("Text", patentFeeTBindingSource, "GTotall", true, DataSourceUpdateMode.OnValidation, "", "");

            checkBox_Pay.DataBindings.Clear();
            checkBox_Pay.DataBindings.Add("Checked", patentFeeTBindingSource, "Pay", true, DataSourceUpdateMode.OnValidation, false);

            checkBox_NT.DataBindings.Clear();
            checkBox_NT.DataBindings.Add("Checked", patentFeeTBindingSource, "NT", true, DataSourceUpdateMode.OnValidation, false);

            chkWithholding.DataBindings.Clear();
            chkWithholding.DataBindings.Add("Checked", patentFeeTBindingSource, "Withholding", true, DataSourceUpdateMode.OnValidation, false);

            txtTax.DataBindings.Clear();
            txtTax.DataBindings.Add("Text", patentFeeTBindingSource, "Tax", true, DataSourceUpdateMode.OnValidation, "", "");

            txtOAttorneyGovFee.DataBindings.Clear();
            txtOAttorneyGovFee.DataBindings.Add("Text", patentFeeTBindingSource, "OAttorneyGovFee", true, DataSourceUpdateMode.OnValidation, "", "");

            txtTotall.DataBindings.Clear();
            txtTotall.DataBindings.Add("Text", patentFeeTBindingSource, "Totall", true, DataSourceUpdateMode.OnValidation, "", "");

            txtPracicalityPay.DataBindings.Clear();
            txtPracicalityPay.DataBindings.Add("Text", patentFeeTBindingSource, "PracticalityPay", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_PayKind.DataBindings.Clear();
            txt_PayKind.DataBindings.Add("Text", patentFeeTBindingSource, "PayKind", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_PayMemo.DataBindings.Clear();
            txt_PayMemo.DataBindings.Add("Text", patentFeeTBindingSource, "PayMemo", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_Remark.DataBindings.Clear();
            txt_Remark.DataBindings.Add("Text", patentFeeTBindingSource, "Remark", true, DataSourceUpdateMode.OnValidation, "", "");

            numericUpDown_Days.DataBindings.Clear();
            numericUpDown_Days.DataBindings.Add("Value", patentFeeTBindingSource, "Days", true, DataSourceUpdateMode.OnValidation, "", "");

            //請款單號
            txt_PPP.DataBindings.Clear();
            txt_PPP.DataBindings.Add("Text", patentFeeTBindingSource, "PPP", true, DataSourceUpdateMode.OnValidation, "", "");

            //請款人
            txt_FeeWorkerName.DataBindings.Clear();
            txt_FeeWorkerName.DataBindings.Add("Text", patentFeeTBindingSource, "WorkerName", true, DataSourceUpdateMode.OnValidation, "", "");

            //請款日期
            maskedTextBox_RDate.DataBindings.Clear();
            maskedTextBox_RDate.DataBindings.Add("Text", patentFeeTBindingSource, "RDate", true, DataSourceUpdateMode.OnPropertyChanged, "    /  /", "yyyy/MM/dd");

            //收款日期
            maskedTextBox_PayDate.DataBindings.Clear();
            maskedTextBox_PayDate.DataBindings.Add("Text", patentFeeTBindingSource, "PayDate", true, DataSourceUpdateMode.OnPropertyChanged, "    /  /", "yyyy/MM/dd");


        }

        #endregion


        #region ControlBindingTMPayment
        public void ControlBindingTMPayment()
        {
            txt_PayFeeSubject.DataBindings.Clear();
            txt_PayFeeSubject.DataBindings.Add("Text", patentPaymentTBindingSource, "FeeSubject", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_PayFeePhase.DataBindings.Clear();
            txt_PayFeePhase.DataBindings.Add("Text", patentPaymentTBindingSource, "FeePhaseName", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_FClientTransactor.DataBindings.Clear();
            txt_FClientTransactor.DataBindings.Add("Text", patentPaymentTBindingSource, "WorkerName", true, DataSourceUpdateMode.OnValidation, "", "");

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

            //收據日期
            maskedTextBox_IReceiptDate.DataBindings.Clear();
            maskedTextBox_IReceiptDate.DataBindings.Add("Text", patentPaymentTBindingSource, "IReceiptDate", true, DataSourceUpdateMode.OnPropertyChanged, "    /  /", "yyyy/MM/dd");

            txt_PayTotall.DataBindings.Clear();
            txt_PayTotall.DataBindings.Add("Text", patentPaymentTBindingSource, "Totall", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");

            txt_PayRemark.DataBindings.Clear();
            txt_PayRemark.DataBindings.Add("Text", patentPaymentTBindingSource, "Remark", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_BillCheck.DataBindings.Clear();
            txt_BillCheck.DataBindings.Add("Text", patentPaymentTBindingSource, "BillCheck", true, DataSourceUpdateMode.OnValidation, "", "");

            maskedTextBox_ReciveDate.DataBindings.Clear();
            maskedTextBox_ReciveDate.DataBindings.Add("Text", patentPaymentTBindingSource, "ReciveDate", true, DataSourceUpdateMode.OnPropertyChanged, "    /  /", "yyyy/MM/dd");

            maskedTextBox_PayDueDate.DataBindings.Clear();
            maskedTextBox_PayDueDate.DataBindings.Add("Text", patentPaymentTBindingSource, "PayDueDate", true, DataSourceUpdateMode.OnPropertyChanged, "    /  /", "yyyy/MM/dd");

            checkBox_IsBilling.DataBindings.Clear();
            checkBox_IsBilling.DataBindings.Add("Checked", patentPaymentTBindingSource, "IsBilling", true, DataSourceUpdateMode.OnValidation, false);

            txt_BillingNo.DataBindings.Clear();
            txt_BillingNo.DataBindings.Add("Text", patentPaymentTBindingSource, "BillingNo", true, DataSourceUpdateMode.OnValidation, "", "");

            //匯率
            txt_ExchangeRate.DataBindings.Clear();
            txt_ExchangeRate.DataBindings.Add("Text", patentPaymentTBindingSource, "ExchangeRate", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");

            checkBox_IsCopyFile.DataBindings.Clear();
            checkBox_IsCopyFile.DataBindings.Add("Checked", patentPaymentTBindingSource, "IsCopyFile", true, DataSourceUpdateMode.OnValidation, false);

            checkBox_IsScan.DataBindings.Clear();
            checkBox_IsScan.DataBindings.Add("Checked", patentPaymentTBindingSource, "IsScan", true, DataSourceUpdateMode.OnValidation, false);

        }

        #endregion

        #endregion
        
        #region ===============but_Search===============
        private void but_Search_Click(object sender, EventArgs e)
        {
            Public.DLL dll = new LawtechPTSystemByFirm.Public.DLL();
            string times = "";
            string strFilter = "";
            if (searchMain1.comboBox2.Text == "" && maskedTextBox_S.Text == "    /  /" && maskedTextBox_D.Text == "    /  /")
            {
                strFilter = "1=1";
            }
            else
            {
                if (maskedTextBox_S.Text != "    /  /" && maskedTextBox_D.Text != "    /  /")
                {
                    DateTime dtS = DateTime.Parse(maskedTextBox_S.Text);
                    DateTime dtE = DateTime.Parse(maskedTextBox_D.Text);
                    if (dtS > dtE)
                    {
                        maskedTextBox_S.Text = dtE.ToString("yyyy/MM/dd");
                        maskedTextBox_D.Text = dtS.ToString("yyyy/MM/dd");
                    }
                }


              
                string strDateMode = comboBox_DateMode.SelectedValue.ToString();

                if (maskedTextBox_S.Text != "    /  /" && maskedTextBox_D.Text == "    /  /")
                {
                    times += " " + strDateMode + ">='" + maskedTextBox_S.Text + "'";
                }
                else if (maskedTextBox_S.Text == "    /  /" && maskedTextBox_D.Text != "    /  /")
                {
                    times += " " + strDateMode + "<='" + maskedTextBox_D.Text + "'";
                }
                else if (maskedTextBox_S.Text != "    /  /" && maskedTextBox_D.Text != "    /  /")
                {
                    times += " (" + strDateMode + " >= '" + maskedTextBox_S.Text + "' and " + strDateMode + "<= '" + maskedTextBox_D.Text + "')";
                }

               
                switch (((LawtechPTSystemByFirm.Public.CCombox)(searchMain1.comboBox1.SelectedItem)).ValueString)
                {
                    case "PatentNo"://申請案卷號
                        if ((searchMain1.comboBox2.Text == "全部" || searchMain1.comboBox2.Text.Trim() == "") && times == "")
                        {

                            strFilter = "1=1";
                        }
                        else
                        {
                            if (times != "")
                                strFilter = times + " and PatentNo like '%" + searchMain1.comboBox2.Text + "%'";
                            else
                                strFilter = " PatentNo like '%" + searchMain1.comboBox2.Text + "%'";


                        }
                        break;
                    case "Country"://國別
                        if ((searchMain1.comboBox2.Text == "全部" || searchMain1.comboBox2.Text.Trim() == "") && times == "")
                        {
                            strFilter = "1=1";
                        }
                        else
                        {
                            if (searchMain1.comboBox2.SelectedValue != null)
                            {
                                if (times == "")
                                    strFilter = "PatentManagementT.Country='" + searchMain1.comboBox2.SelectedValue.ToString() + "'";
                                else
                                    strFilter = times + " and PatentManagementT.Country='" + searchMain1.comboBox2.SelectedValue.ToString() + "'";
                            }
                            else
                            {
                                MessageBox.Show("選取的【國別】有誤，\r\n必需從下拉選單中選取，請重新輸入", "提示訊息");
                                searchMain1.comboBox2.Focus();
                            }
                        }
                        break;



                    case "發明人": //發明人
                        if ((searchMain1.comboBox2.Text == "全部" || searchMain1.comboBox2.Text.Trim() == "") && times == "")
                        {
                            strFilter = "1=1";
                        }
                        else
                        {
                            if (times == "")
                                strFilter = "InventorName like '%" + searchMain1.comboBox2.Text + "%'";
                            else
                                strFilter = times + " and InventorName like '%" + searchMain1.comboBox2.Text + "%'";
                        }
                        break;

                    case "Kind": //種類
                        if ((searchMain1.comboBox2.Text == "全部" || searchMain1.comboBox2.Text.Trim() == "") && times == "")
                        {
                            strFilter = "1=1";
                        }
                        else
                        {
                            if (searchMain1.comboBox2.SelectedValue != null)
                            {
                                if (times == "")
                                    strFilter = "PatentManagementT.Kind='" + searchMain1.comboBox2.SelectedValue.ToString() + "'";
                                else
                                    strFilter = times + " and PatentManagementT.Kind='" + searchMain1.comboBox2.SelectedValue.ToString() + "'";
                            }
                            else
                            {
                                MessageBox.Show("選取的【種類】有誤，\r\n必需從下拉選單中選取，請重新輸入", "提示訊息");
                                searchMain1.comboBox2.Focus();
                            }
                        }
                        break;

                    case "Nature": //性質
                        if ((searchMain1.comboBox2.Text == "全部" || searchMain1.comboBox2.Text.Trim() == "") && times == "")
                        {
                            strFilter = "1=1";
                        }
                        else
                        {
                            if (searchMain1.comboBox2.SelectedValue != null)
                            {
                                if (times == "")
                                    strFilter = "PatentManagementT.Nature=" + searchMain1.comboBox2.SelectedValue.ToString();
                                else
                                    strFilter = times + " and PatentManagementT.Nature=" + searchMain1.comboBox2.SelectedValue.ToString();
                            }
                            else
                            {
                                MessageBox.Show("選取的【性質】有誤，\r\n必需從下拉選單中選取，請重新輸入", "提示訊息");
                                searchMain1.comboBox2.Focus();
                            }
                        }

                        break;
                    case "AttorneyFirm":
                    case "AttorneySymbol": //承辦事務所
                        if ((searchMain1.comboBox2.Text == "全部" || searchMain1.comboBox2.Text.Trim() == "") && times == "")
                        {
                            strFilter = "1=1";
                        }
                        else
                        {
                            if (searchMain1.comboBox2.SelectedValue != null)
                            {
                                if (times == "")
                                    strFilter = " DelegateType=1 and PatentManagementT.Attorney=" + searchMain1.comboBox2.SelectedValue.ToString();
                                else
                                    strFilter = times + " and DelegateType=1 and PatentManagementT.Attorney=" + searchMain1.comboBox2.SelectedValue.ToString();
                            }
                            else
                            {
                                MessageBox.Show("這不是有效的事務所資料，請確認!!");
                            }
                        }

                        break;

                    case "AttorneyRefNo": //事務所卷號
                        if ((searchMain1.comboBox2.Text == "全部" || searchMain1.comboBox2.Text.Trim() == "") && times == "")
                        {
                            strFilter = "1=1";
                        }
                        else
                        {
                            if (times == "")
                                strFilter = " DelegateType=1 and PatentManagementT.AttorneyRefNo like '%" + searchMain1.comboBox2.Text + "%'";
                            else
                                strFilter = times + " and DelegateType=1 and PatentManagementT.AttorneyRefNo like '%" + searchMain1.comboBox2.Text + "%'";
                        }

                        break;

                    case "Title":  //申請案名稱
                        if ((searchMain1.comboBox2.Text == "全部" || searchMain1.comboBox2.Text.Trim() == "") && times == "")
                        {
                            strFilter = "1=1";
                        }
                        else
                        {
                            if (times == "")
                                strFilter = "Title like '%" + searchMain1.comboBox2.Text + "%'";
                            else
                                strFilter = times + " and Title like '%" + searchMain1.comboBox2.Text + "%'";
                        }
                        break;



                    case "ApplicationNo":  //申請案號
                        if ((searchMain1.comboBox2.Text == "全部" || searchMain1.comboBox2.Text.Trim() == "") && times == "")
                        {
                            strFilter = "1=1";
                        }
                        else
                        {
                            if (times == "")
                                strFilter = "PatentManagementT.ApplicationNo like '%" + searchMain1.comboBox2.Text + "%'";
                            else
                                strFilter = times + " and PatentManagementT.ApplicationNo like '%" + searchMain1.comboBox2.Text + "%'";

                        }
                        break;

                    case "ApplicantKey": //申請人
                        if ((searchMain1.comboBox2.Text == "全部" || searchMain1.comboBox2.Text.Trim() == "") && times == "")
                        {
                            strFilter = "1=1";
                        }
                        else
                        {
                            if (searchMain1.comboBox2.SelectedValue != null)
                            {
                                if (times == "")
                                    strFilter = "PatentManagementT.Applicant=" + searchMain1.comboBox2.SelectedValue.ToString();
                                else
                                    strFilter = times + " and PatentManagementT.Applicant=" + searchMain1.comboBox2.SelectedValue.ToString();
                            }
                            else
                            {
                                MessageBox.Show("必需從下拉選單中選取，請重新輸入");
                                searchMain1.comboBox2.Focus();
                            }

                        }
                        break;

                    case "DelegateType": //委託類型
                        if ((searchMain1.comboBox2.Text == "全部" || searchMain1.comboBox2.Text.Trim() == "") && times == "")
                        {
                            strFilter = "1=1";
                        }
                        else
                        {
                            if (searchMain1.comboBox2.SelectedValue != null)
                            {
                                if (times == "")
                                    strFilter = "DelegateType=" + searchMain1.comboBox2.SelectedValue.ToString();
                                else
                                    strFilter = times + " and DelegateType=" + searchMain1.comboBox2.SelectedValue.ToString();
                            }
                            else
                            {
                                MessageBox.Show("必需從下拉選單中選取，請重新輸入");
                                searchMain1.comboBox2.Focus();
                            }

                        }
                        break;



                    case "Status": //申請案狀態
                        if ((searchMain1.comboBox2.Text == "全部" || searchMain1.comboBox2.Text.Trim() == "") && times == "")
                        {
                            strFilter = "1=1";
                        }
                        else
                        {
                            if (searchMain1.comboBox2.SelectedValue != null)
                            {
                                if (times == "")
                                    strFilter = "PatentManagementT.Status=" + searchMain1.comboBox2.SelectedValue.ToString();
                                else
                                    strFilter = times + " and PatentManagementT.Status=" + searchMain1.comboBox2.SelectedValue.ToString();
                            }
                            else
                            {
                                MessageBox.Show("必需從下拉選單中選取，請重新輸入");
                                searchMain1.comboBox2.Focus();
                            }
                        }
                        break;

                    case "ClientWorker": //案件承辦人
                        if ((searchMain1.comboBox2.Text == "全部" || searchMain1.comboBox2.Text.Trim() == "") && times == "")
                        {
                            strFilter = "1=1";
                        }
                        else
                        {
                            if (searchMain1.comboBox2.SelectedValue != null)
                            {
                                if (times == "")
                                    strFilter = "PatentManagementT.ClientWorker=" + searchMain1.comboBox2.SelectedValue.ToString();
                                else
                                    strFilter = times + " and PatentManagementT.ClientWorker=" + searchMain1.comboBox2.SelectedValue.ToString();
                            }
                            else
                            {
                                MessageBox.Show("必需從下拉選單中選取，請重新輸入");
                                searchMain1.comboBox2.Focus();
                            }
                        }

                        break;
                    case "PatentNo_Old"://提案家族
                        if ((searchMain1.comboBox2.Text == "全部" || searchMain1.comboBox2.Text.Trim() == "") && times == "")
                        {
                            strFilter = "1=1";
                        }
                        else
                        {
                            if (times == "")
                                strFilter = "PatentManagementT.PatentNo_Old like '%" + searchMain1.comboBox2.Text + "%'";
                            else
                                strFilter = times + " and PatentManagementT.PatentNo_Old like '%" + searchMain1.comboBox2.Text + "%'";
                        }
                        break;
                }
            }



            string SQL = @"SELECT         PatentManagementT.PatentID, PatentManagementT.PatentNo, 
                          PatentManagementT.PatentNo_Old, PatentManagementT.UpbuildDate, 
                          PatentManagementT.Applicant, PatentManagementT.Title, 
                          PatentManagementT.TitleEn, PatentManagementT.Kind, 
                          PatentManagementT.Nature, PatentManagementT.Country, 
                          PatentManagementT.ClientWorker, PatentManagementT.Status, 
                          PatentManagementT.StatusExplain, PatentManagementT.ISexam, 
                          PatentManagementT.Priority, PatentManagementT.EarlyPriorityDate, 
                          PatentManagementT.EarlyMotherDate, PatentManagementT.ApplicationDate, 
                          PatentManagementT.ApplicationNo, PatentManagementT.Pubdate, 
                          PatentManagementT.PubNo, PatentManagementT.AllowDate, 
                          PatentManagementT.AllowPubDate, PatentManagementT.AllowPubNo, 
                          PatentManagementT.GetDate, PatentManagementT.CertifyNo, 
                          PatentManagementT.RegisterDate, PatentManagementT.DueDate, 
                          PatentManagementT.PayYear, PatentManagementT.RenewTo, 
                          PatentManagementT.CloseDate, PatentManagementT.CloseCaus, 
                          PatentManagementT.Remark, PatentManagementT.FileSource, 
                          PatentManagementT.NextYear, PatentManagementT.YearFee, 
                          PatentManagementT.IneventerMan, PatentManagementT.AddDay, 
                          PatentManagementT.Inventor, WorkerT_1.Name AS WorkerName, 
                          PatStatusT.Status AS StatusName, CountryT.Country AS CountryName, 
                          KindT.Kind AS KindName, PATFeatureT.FeatureName, 
                          PattPriorityBaseT.PriorityBaseName, PatISexamT.ISExam AS ISExamName, 
                          CASE WHEN PatentManagementT.DelegateType = 1 THEN '申請人直接委託' WHEN
                           PatentManagementT.DelegateType = 2 THEN '複代委託' END AS DelegateTypeName,
                           CASE WHEN PatentManagementT.DelegateType = 1 THEN ApplicantNames WHEN
                           PatentManagementT.DelegateType = 2 THEN
                              (SELECT         AttorneyT.AttorneyFirm
                                FROM              AttorneyT
                                WHERE          AttorneyKey = PatentManagementT.MainCustomer) 
                          END AS MainCustomerName, PatentManagementT.MainCustomerRefNo, 
                          CASE WHEN PatentManagementT.DelegateType = 1 THEN
                              (SELECT         LiaisonerT.Liaisoner
                                FROM              LiaisonerT
                                WHERE          LiaisonerKey = PatentManagementT.MainCustomerTransactor) 
                          WHEN PatentManagementT.DelegateType = 2 THEN
                              (SELECT         AttLiaisonerT.Liaisoner
                                FROM              AttLiaisonerT
                                WHERE          AttLiaisonerT.ALiaisonerKey = PatentManagementT.MainCustomerTransactor)
                           END AS MainCustomerTransactorName, PatentManagementT.Attorney, 
                          PatentManagementT.AttorneyRefNo, PatentManagementT.AttorneyTransactor, 
                          PatentManagementT.IsBySelf, PatentManagementT.Introducer, 
                          PatentManagementT.IntroductionDate, AttorneyT.AttorneyFirm, 
                          AttLiaisonerT.Liaisoner AS AttLiaisoner, PatentManagementT.DelegateType, 
                          PatentManagementT.MainCustomer, 
                          PatentManagementT.MainCustomerTransactor, 
                          PatentManagementT.ApplicantNames, PatentManagementT.ApplicantKeys, 
                          PatentManagementT.EarlyPriorityNo, PatentManagementT.LastModifyWorker, 
                          PatentManagementT.LastModifyDate, 
                          WorkerT.EmployeeName AS LastModifyWorkerName
                            FROM             WorkerT AS WorkerT_1 RIGHT OUTER JOIN
                          AttLiaisonerT RIGHT OUTER JOIN
                          PatentManagementT LEFT OUTER JOIN
                          WorkerT ON PatentManagementT.LastModifyWorker = WorkerT.WorkerKey ON 
                          AttLiaisonerT.ALiaisonerKey = PatentManagementT.AttorneyTransactor LEFT OUTER
                           JOIN
                          AttorneyT ON 
                          PatentManagementT.Attorney = AttorneyT.AttorneyKey LEFT OUTER JOIN
                          PatISexamT ON 
                          PatentManagementT.ISexam = PatISexamT.ISExamID LEFT OUTER JOIN
                          PattPriorityBaseT ON 
                          PatentManagementT.Priority = PattPriorityBaseT.PriorityBaseID LEFT OUTER JOIN
                          PATFeatureT ON 
                          PatentManagementT.Nature = PATFeatureT.FeatureID LEFT OUTER JOIN
                          CountryT ON 
                          PatentManagementT.CountrySymbol = CountryT.CountrySymbol LEFT OUTER JOIN
                          PatStatusT ON PatentManagementT.Status = PatStatusT.StatusID ON 
                          WorkerT_1.WorkerKey = PatentManagementT.ClientWorker LEFT OUTER JOIN
                          KindT ON PatentManagementT.Kind = KindT.KindSN where " + strFilter;
            if (this.qS_DataSet.PatentManagementT.Rows.Count > 0)
            {
                this.qS_DataSet.PatentManagementT.Clear();
            }
            dll.FetchDataTable(SQL, this.qS_DataSet.PatentManagementT);
           
        }
          
        #endregion
        
        #region ============申請案快顯============
        private void contextMenuStrip_File_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            contextMenuStrip_File.Visible = false;
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
                        contextMenuStrip_File.Visible = false;

                        if (MessageBox.Show("是否確定刪除 \r\n" + GridView_File.CurrentRow.Cells["PatentNo"].Value.ToString(), "確認視窗", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {

                            if (MessageBox.Show(string.Format("請再次確定是否刪除該申請案({0})，\r\n它將會刪除所有相關的資料(附件、委辦、來函)??", GridView_File.CurrentRow.Cells["PatentNo"].Value.ToString()), "確認視窗", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                            {
                                Public.CPatentManagement Patent = new Public.CPatentManagement();

                                Public.DLL dll = new LawtechPTSystemByFirm.Public.DLL();
                                //刪除申請案相關文件包含委辦、來函、費用的實體檔案
                                string delFileDir = string.Format(@"{0}\{1}", dll.PatentFolderRoot, GridView_File.CurrentRow.Cells["PatentID"].Value.ToString());
                                if (Directory.Exists(delFileDir))
                                {
                                    Directory.Delete(delFileDir, true);
                                }

                                //刪除委辦、來函、請款   記錄                               
                                string strSQLEvent =string.Format( "delete PatComitEventT where  PatentID={0};  delete PatNotifyEventT where PatentID={0}" , GridView_File.CurrentRow.Cells["PatentID"].Value.ToString());
                                dll.SQLexecuteNonQuery(strSQLEvent);

                                Patent.Delete((int)GridView_File.CurrentRow.Cells["PatentID"].Value);
                                GridView_File.Rows.Remove(GridView_File.CurrentRow);
                                this.qS_DataSet.PatentManagementT.AcceptChanges();

                                //this.GridView_FileIndex = bSource_File.Position;

                                MessageBox.Show("刪除申請成功");
                            }
                        }
                    }
                    break;

                case "ToolStripMenuItem_Proposal":

                    if (GridView_File.SelectedRows.Count>0 )
                    {
                        US.OvertrueName overture = new LawtechPTSystemByFirm.US.OvertrueName();
                        overture.TypeMode = 1;
                        overture.GV = GridView_File;
                        overture.Dt = qS_DataSet.PatentManagementT;
                        overture.ShowDialog();
                    }
                    break;

                case "匯出成ExcelToolStripMenuItem":

                    contextMenuStrip_File.Visible = false;
                    try
                    {
                        Public.DLL dll = new LawtechPTSystemByFirm.Public.DLL();
                        Task task = dll.WriteToCSV(GridView_File);
                    }
                    catch
                    {
                        MessageBox.Show("匯出Excel失敗");
                    }
                    break;

              

                case "上傳申請案相關文件ToolStripMenuItem":
                   
                        if (GridView_File.CurrentRow != null)
                        {
                            //US.UpdataFile upfile2 = new US.UpdataFile();
                            US.UpFileList upfile2 = new US.UpFileList();
                            upfile2.Text = "上傳申請案(" + GridView_File.CurrentRow.Cells["PatentNo"].Value.ToString() + ")相關文件";
                            upfile2.MainFileKey = (int)GridView_File.CurrentRow.Cells["PatentID"].Value;
                            upfile2.UploadMode =3 ;
                            upfile2.MainFileType = 0;                     
                            upfile2.ShowDialog();
                        }
                    
                    break;

                case "開啟申請案相關文件ToolStripMenuItem":
                    if (GridView_File.CurrentRow != null)
                    {
                        ViewUpdateFileList subForm = new ViewUpdateFileList();
                        subForm.Text = GridView_File.CurrentRow.Cells["PatentNo"].Value.ToString() + "的相關文件";
                        subForm.FileKind = 3;
                        subForm.FileType = 0;
                        subForm.MainParentID = (int)GridView_File.CurrentRow.Cells["PatentID"].Value;
                        subForm.radoC.Checked = true;
                        subForm.ShowDialog();
                    }
                    break;
               
               

                case "EditFiletoolStripMenuItem":
                case "toolStripButtonEditItem_Patent":
                    if (GridView_File.CurrentRow != null)
                    {
                        EditForm.EditPatent editPatent = new LawtechPTSystemByFirm.EditForm.EditPatent();
                        editPatent.Text += "--" + GridView_File.CurrentRow.Cells["PatentNo"].Value.ToString();
                        editPatent.Patent_ID = (int)GridView_File.CurrentRow.Cells["PatentID"].Value;
                        editPatent.ShowDialog();
                    }
                    break;


                case "toolStripMenuItem_CompleteHistory":
                    if (GridView_File.SelectedRows.Count > 0)
                    {
                        ViewFrom.PatentCompleteHistory history = new LawtechPTSystemByFirm.ViewFrom.PatentCompleteHistory();
                        history.Gv = GridView_File;
                        history.Show();
                    }
                    break;

                case "toolStripMenuItem_SendMail"://寄送通知函
                    if (GridView_File.CurrentRow != null)
                    {
                        US.NotificationLetter letter = new LawtechPTSystemByFirm.US.NotificationLetter();
                        letter.ApplicantKeys = GridView_File.CurrentRow.Cells["ApplicantKeys"].Value.ToString();
                        letter.CaseKey = GridView_File.CurrentRow.Cells["PatentID"].Value != null ? (int)GridView_File.CurrentRow.Cells["PatentID"].Value : -1;
                        letter.DelegateType = GridView_File.CurrentRow.Cells["DelegateType"].Value.ToString() != "" ? (int)GridView_File.CurrentRow.Cells["DelegateType"].Value : -1;
                        letter.Attorney = GridView_File.CurrentRow.Cells["Attorney"].Value.ToString() != "" ? (int)GridView_File.CurrentRow.Cells["Attorney"].Value : -1;
                        letter.EmailSampleType = "Patent";
                        letter.CaseNo = GridView_File.CurrentRow.Cells["PatentNo"].Value.ToString();
                        letter.ShowDialog();
                    }
                    break;
            }
        }
        #endregion

        private void but_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region ============GridView_File 事件============
        private void GridView_File_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = false;
        }

        private void GridView_File_SelectionChanged(object sender, EventArgs e)
        {
            if (GridView_File.CurrentRow != null)
            {
                this.patComitEventTTableAdapter.Fill(this.qS_DataSet.PatComitEventT, property_PatentID);
                this.patNotifyEventTTableAdapter.Fill(this.qS_DataSet.PatNotifyEventT, property_PatentID);                
                this.patentFeeTTableAdapter.Fill(this.qS_DataSet.PatentFeeT, property_PatentID);
                this.patentPaymentTTableAdapter.Fill(this.qS_DataSet.PatentPaymentT, property_PatentID);
            }
        }

        private void GridView_File_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            contextMenuStrip_File_ItemClicked(contextMenuStrip_File, new ToolStripItemClickedEventArgs(EditFiletoolStripMenuItem));
        }
        #endregion 

      
        
        #region  ============委辦快顯============
        private void contextMenuStrip_Event0_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            contextMenuStrip_Event0.Visible = false;
            switch (e.ClickedItem.Name)
            {
                case "bindingNavigatorAddNewItem":
                case "AddToolStripMenuItem"://新增委辦
                    AddFrom.AddPatentComitEvent comit = new LawtechPTSystemByFirm.AddFrom.AddPatentComitEvent();
                    comit.Text += "(" + GridView_File.CurrentRow.Cells["CountryName"].Value.ToString() + ")";
                    comit.CountrySymbol = GridView_File.CurrentRow.Cells["Country"].Value.ToString();
                    comit.PatentID = property_PatentID;
                    comit.ShowDialog();
                    break;
                case "bindingNavigatorDeleteItem":
                case "DelToolStripMenuItem": //刪除委辦
                    if (GridView_PatComit.CurrentRow != null)
                    {
                        if (MessageBox.Show("是否確定刪除", "確認視窗", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            Public.CPatComitEvent PatentComit = new Public.CPatComitEvent();

                            //刪除事件轉請款
                            Public.CPatComitEventToFee ComitEventToFee = new LawtechPTSystemByFirm.Public.CPatComitEventToFee();
                            ComitEventToFee.Delete("PatComitEventID=" + GridView_PatComit.CurrentRow.Cells["PatComitEventID"].Value.ToString(),"");
                            //刪除事件轉付款
                            Public.CPatComitEventToPayment ComitEventToPayment = new LawtechPTSystemByFirm.Public.CPatComitEventToPayment();
                            ComitEventToPayment.Delete("PatComitEventID=" + GridView_PatComit.CurrentRow.Cells["PatComitEventID"].Value.ToString(),"");


                            PatentComit.Delete((int)GridView_PatComit.CurrentRow.Cells["PatComitEventID"].Value);
                            GridView_PatComit.Rows.Remove(GridView_PatComit.CurrentRow);
                            this.qS_DataSet.PatComitEventT.AcceptChanges();
                            
                            MessageBox.Show("刪除委辦成功", "確認視窗", MessageBoxButtons.OK);

                        }
                    }
                    break;
                case "UpFileToolStripMenuItem": //委辦上傳相關文件
                    if (GridView_PatComit.CurrentRow != null)
                    {
                        US.UpFileList upfile2 = new US.UpFileList();
                        upfile2.Text = GridView_File.CurrentRow.Cells["PatentNo"].Value.ToString() + "--上傳委辦相關文件";
                        upfile2.MainFileKey = (int)GridView_File.CurrentRow.Cells["PatentID"].Value;
                        upfile2.ChildFileKey = (int)GridView_PatComit.CurrentRow.Cells["PatComitEventID"].Value;
                        upfile2.MainFileType = 1;
                        upfile2.UploadMode = 3;
                        upfile2.ShowDialog();
                    }
                    break;
                case "OpenFileToolStripMenuItem": //開啟申請案相關文件
                    if (GridView_PatComit.CurrentRow != null)
                    {
                        ViewUpdateFileList subForm = new ViewUpdateFileList();
                        subForm.Text = GridView_File.CurrentRow.Cells["PatentNo"].Value.ToString() + "的相關文件";
                        subForm.FileKind =3;
                        subForm.FileType = 1;
                        subForm.MainParentID = (int)GridView_File.CurrentRow.Cells["PatentID"].Value;
                        subForm.Child_ID = (int)GridView_PatComit.CurrentRow.Cells["PatComitEventID"].Value;
                        subForm.radoD.Checked = true;
                        subForm.ShowDialog();
                    }
                    break;
                case "EdittoolStripMenuItem":
                case "toolStripButtonEditItem":
                    if (GridView_PatComit.CurrentRow != null)
                    {
                        EditForm.EditComitEvent comit_Edit = new LawtechPTSystemByFirm.EditForm.EditComitEvent();
                        comit_Edit.PatComitEventID = (int)GridView_PatComit.CurrentRow.Cells["PatComitEventID"].Value;
                        comit_Edit.Text += "(" + GridView_File.CurrentRow.Cells["CountryName"].Value.ToString() + ")";
                        comit_Edit.CountrySymbol = GridView_File.CurrentRow.Cells["Country"].Value.ToString();
                        comit_Edit.ShowDialog();
                    }
                    break;
                case "toolStripMenuItem_ComitToFee":
                    if (GridView_PatComit.CurrentRow != null)
                    {
                        AddFrom.AddPatentFee fee = new AddFrom.AddPatentFee();
                        fee.PatentID = (int)GridView_File.CurrentRow.Cells["PatentID"].Value;
                        fee.TypeFrom = 1;
                        fee.SourceID = (int)GridView_PatComit.CurrentRow.Cells["PatComitEventID"].Value;
                        fee.FeeSubject =  GridView_PatComit.CurrentRow.Cells["eventContentDataGridViewTextBoxColumn"].Value.ToString();
                        fee.Text = fee.Text + "--" + GridView_File.CurrentRow.Cells["Title_File"].Value.ToString();
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
                        Payment.FeeSubject =  GridView_PatComit.CurrentRow.Cells["eventContentDataGridViewTextBoxColumn"].Value.ToString();
                        Payment.Text = Payment.Text + "--" + GridView_File.CurrentRow.Cells["Title_File"].Value.ToString();
                        Payment.ShowDialog();
                    }
                    break;
            }


        }
        #endregion

        private void GridView_PatComit_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            contextMenuStrip_Event0_ItemClicked(contextMenuStrip_Event0, new ToolStripItemClickedEventArgs(EdittoolStripMenuItem));
        }

        #region  ============來函快顯============
        private void contextMenuStrip_Event1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            contextMenuStrip_Event1.Visible = false;
            switch (e.ClickedItem.Name)
            {
                case "bindingNavigatorAddNewItem_Notify":
                case "新增來函ToolStripMenuItem"://新增來函
                    AddFrom.AddPatentNotifyEvent NotifyEvent = new LawtechPTSystemByFirm.AddFrom.AddPatentNotifyEvent();
                    NotifyEvent.Text += "(" + GridView_File.CurrentRow.Cells["CountryName"].Value.ToString() + ")";
                    NotifyEvent.PatentID = property_PatentID;
                    NotifyEvent.Country = GridView_File.CurrentRow.Cells["Country"].Value.ToString();
                    NotifyEvent.ShowDialog();
                    break;
                case "bindingNavigatorDeleteItem_Notify":
                case "刪除來函ToolStripMenuItem": //刪除來函
                    if (patNotifyEventTDataGridView.CurrentRow != null)
                    {
                        if (MessageBox.Show("是否確定刪除", "確認視窗", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            Public.CPatNotifyEvent PatentNotify = new Public.CPatNotifyEvent("1=0");

                            //刪除來函轉請款
                            Public.CPatNotifyEventToFee NotifyEventToFee = new LawtechPTSystemByFirm.Public.CPatNotifyEventToFee("1=0");
                            NotifyEventToFee.Delete("PatNotifyEventID=" + patNotifyEventTDataGridView.CurrentRow.Cells["PatNotifyEventID"].Value.ToString());

                            //刪除來函轉付款
                            Public.CPatNotifyEventToPayment NotifyEventToPayment = new LawtechPTSystemByFirm.Public.CPatNotifyEventToPayment("1=0");
                            NotifyEventToPayment.Delete("PatNotifyEventID=" + patNotifyEventTDataGridView.CurrentRow.Cells["PatNotifyEventID"].Value.ToString());


                            PatentNotify.Delete((int)patNotifyEventTDataGridView.CurrentRow.Cells["PatNotifyEventID"].Value);
                            patNotifyEventTDataGridView.Rows.Remove(patNotifyEventTDataGridView.CurrentRow);
                            this.qS_DataSet.PatNotifyEventT.AcceptChanges();

                            

                            MessageBox.Show("刪除來函成功", "確認視窗", MessageBoxButtons.OK);

                        }
                    }
                    break;
                case "上傳來函相關文件ToolStripMenuItem": //來函上傳相關文件
                    if (patNotifyEventTDataGridView.CurrentRow != null)
                    {
                        US.UpFileList upfile2 = new US.UpFileList();
                        upfile2.Text = GridView_File.CurrentRow.Cells["PatentNo"].Value.ToString() + "--上傳來函相關文件";
                        upfile2.MainFileKey = (int)GridView_File.CurrentRow.Cells["PatentID"].Value;
                        upfile2.ChildFileKey = (int)patNotifyEventTDataGridView.CurrentRow.Cells["PatNotifyEventID"].Value;
                        upfile2.MainFileType = 2;
                        upfile2.UploadMode = 3;
                        upfile2.ShowDialog();
                    }
                    break;
                case "開啟來函相關文件ToolStripMenuItem": //開啟來函相關文件
                    if (patNotifyEventTDataGridView.CurrentRow != null)
                    {
                        ViewUpdateFileList subForm = new ViewUpdateFileList();
                        subForm.Text = GridView_File.CurrentRow.Cells["PatentNo"].Value.ToString() + "的相關文件";
                        subForm.FileKind = 3;
                        subForm.FileType = 2;
                        subForm.MainParentID = (int)GridView_File.CurrentRow.Cells["PatentID"].Value;
                        subForm.Child_ID = (int)patNotifyEventTDataGridView.CurrentRow.Cells["PatNotifyEventID"].Value;                        
                        subForm.ShowDialog();
                    }
                    break;
                case "toolStripMenuItem_Notify":
                case "toolStripButtonEidtItem_Notify":
                    if (patNotifyEventTDataGridView.CurrentRow != null)
                    {
                        EditForm.EditNotifyEvent Notify_Edit = new LawtechPTSystemByFirm.EditForm.EditNotifyEvent();
                        Notify_Edit.NotifyEventID = (int)patNotifyEventTDataGridView.CurrentRow.Cells["PatNotifyEventID"].Value;
                        Notify_Edit.Text += "(" + GridView_File.CurrentRow.Cells["CountryName"].Value.ToString() + ")";
                        Notify_Edit.Country = GridView_File.CurrentRow.Cells["Country"].Value.ToString();
                        Notify_Edit.PatentID = property_PatentID;
                        Notify_Edit.ShowDialog();
                    }
                    break;

                case "toolStripMenuItem_ToFee":
                    if (patNotifyEventTDataGridView.CurrentRow != null)
                    {
                        AddFrom.AddPatentFee fee = new AddFrom.AddPatentFee();
                        fee.PatentID = (int)GridView_File.CurrentRow.Cells["PatentID"].Value;
                        fee.TypeFrom = 2;
                        fee.SourceID = (int)patNotifyEventTDataGridView.CurrentRow.Cells["PatNotifyEventID"].Value;
                        fee.FeeSubject =  patNotifyEventTDataGridView.CurrentRow.Cells["dataGridViewTextBoxColumn4"].Value.ToString();
                        fee.Text = fee.Text + "--" + GridView_File.CurrentRow.Cells["Title_File"].Value.ToString();
                        fee.ShowDialog();
                    }
                    break;
                case "toolStripMenuItem_ToPayment":
                    if (patNotifyEventTDataGridView.CurrentRow != null)
                    {
                        AddFrom.AddPatentPayment Payment = new AddFrom.AddPatentPayment();
                        Payment.PatentID = (int)GridView_File.CurrentRow.Cells["PatentID"].Value;
                        Payment.TypeFrom = 1;
                        Payment.SourceID = (int)patNotifyEventTDataGridView.CurrentRow.Cells["PatNotifyEventID"].Value;
                        Payment.FeeSubject =  patNotifyEventTDataGridView.CurrentRow.Cells["dataGridViewTextBoxColumn4"].Value.ToString();
                        Payment.Text = Payment.Text + "--" + GridView_File.CurrentRow.Cells["Title_File"].Value.ToString();
                        Payment.ShowDialog();
                    }
                    break;
            }
        }
        #endregion

        private void patNotifyEventTDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            contextMenuStrip_Event1_ItemClicked(contextMenuStrip_Event1, new ToolStripItemClickedEventArgs(toolStripMenuItem_Notify));
        }

        #region ============請款費用記錄快顯============
        private void contextMenuStrip_Fee_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            contextMenuStrip_Fee.Visible = false;

            switch (e.ClickedItem.Name)
            {
                case "bindingNavigatorAddNewItem1":
                case "toolStripMenuItem_BillingAdd":  //請款新增費用

                    if (GridView_File.Rows.Count > 0)
                    {
                        AddFrom.AddPatentFee fee = new AddFrom.AddPatentFee();
                        fee.PatentID = (int)GridView_File.CurrentRow.Cells["PatentID"].Value;                        
                        fee.Text = fee.Text + "--" + GridView_File.CurrentRow.Cells["Title_File"].Value.ToString();
                        fee.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("請先指定申請案       ", "提示訊息", MessageBoxButtons.OK);
                        return;
                    }

                    break;
                case "bindingNavigatorDeleteItem1":
                case "toolStripMenuItem_BillingDel":  //刪除請款費用

                    if (GridView_Fee.Rows.Count > 0)
                    {

                        if (MessageBox.Show("是否確定刪除", "確認視窗", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            int iFeeKey=(int)GridView_Fee.CurrentRow.Cells["FeeKEY"].Value;
                            Public.CPatentFee DelFee = new Public.CPatentFee();
                            DelFee.Delete(iFeeKey);
                            DelFee.Delete(iFeeKey);
                            GridView_Fee.Rows.Remove(GridView_Fee.CurrentRow);
                            this.qS_DataSet.PatentFeeT.AcceptChanges();
                            MessageBox.Show("刪除請款費用記錄成功", "提示訊息", MessageBoxButtons.OK);
                        }
                    }

                    break;
                case "上傳費用相關文件ToolStripMenuItem":  //上傳請款費用相關文件

                    if (GridView_Fee.CurrentRow != null)
                    {
                        US.UpFileList upfile = new US.UpFileList();
                        upfile.Text = GridView_File.CurrentRow.Cells["PatentNo"].Value.ToString() + "  上傳請款費用相關文件";
                        upfile.UploadMode = 3;
                        upfile.MainFileKey = property_PatentID;
                        upfile.ChildFileKey = (int)GridView_Fee.CurrentRow.Cells["FeeKEY"].Value;  
                        upfile.MainFileType = 3;
                        upfile.ShowDialog();

                    }

                    break;

                case "印請款單ToolStripMenuItem":  //印請款單
                    if (GridView_Fee.CurrentRow != null)
                    {
                        if (GridView_File.CurrentRow.Cells["Applicant"].Value == null)
                        {
                            MessageBox.Show("申請人不得為空值，請確認","提示訊息");
                            return;
                        }

                        ReportView.FeeReport fee = new LawtechPTSystemByFirm.ReportView.FeeReport();
                        fee.FeeKEY =(int) GridView_Fee.CurrentRow.Cells["FeeKEY"].Value;
                        
                            fee.ApplicantKeys =GridView_File.CurrentRow.Cells["Applicant"].Value.ToString() ;
                        
                        fee.PatentID = (int)GridView_File.CurrentRow.Cells["PatentID"].Value;
                        fee.Show();
                    }
                    else
                    {
                        MessageBox.Show("無資料        ", "提示訊息", MessageBoxButtons.OK);
                    }
                    break;
              

                case "開啟費用相關文件ToolStripMenuItem":
                    if (GridView_Fee.CurrentRow != null)
                    {
                        ViewUpdateFileList subForm = new ViewUpdateFileList();
                        subForm.Text = GridView_File.CurrentRow.Cells["PatentNo"].Value.ToString() + "的請款費用相關文件";
                        subForm.FileKind =3;
                        subForm.FileType = 3;
                        subForm.MainParentID = (int)GridView_File.CurrentRow.Cells["PatentID"].Value;
                        subForm.Child_ID = (int)GridView_Fee.CurrentRow.Cells["FeeKEY"].Value;  
                        subForm.ShowDialog();
                    }
                    break;
                case "toolStripMenuItem_BillEdit":
                case "toolStripButton_FeeEdit":
                    if (GridView_Fee.CurrentRow != null)
                    {
                        EditForm.EditPatentFee edit = new LawtechPTSystemByFirm.EditForm.EditPatentFee();
                        edit.property_FeeKEY = (int)GridView_Fee.CurrentRow.Cells["FeeKEY"].Value;
                        edit.ShowDialog();
                    }
                    break;
                case "toolStripMenuItem_Copy":
                    if (GridView_Fee.CurrentRow != null)
                    {

                    }
                    break;
            }


        }
        #endregion

        private void GridView_Fee_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            contextMenuStrip_Fee_ItemClicked(GridView_Fee, new ToolStripItemClickedEventArgs(toolStripMenuItem_BillEdit));
        }


        #region ============付款費用記錄快顯============
        private void contextMenuStrip_Billing_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            contextMenuStrip_Billing.Visible = false;

            switch (e.ClickedItem.Name)
            {
                case "toolStripButton_PayRecordAdd":
                case "toolStripMenuItem_PaymentAdd":  //付款新增費用

                    if (GridView_File.CurrentRow!=null)
                    {
                        AddFrom.AddPatentPayment Payment = new AddFrom.AddPatentPayment();                      
                        Payment.CountrySymbol = GridView_File.CurrentRow.Cells["Country"].Value.ToString();
                        Payment.PatentID = (int)GridView_File.CurrentRow.Cells["PatentID"].Value;
                        Payment.Text = Payment.Text + "(" + GridView_File.CurrentRow.Cells["CountryName"].Value.ToString() + ")" + "--" + GridView_File.CurrentRow.Cells["Title_File"].Value.ToString();
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

                    if (dataGridView_Billing.Rows.Count > 0)
                    {

                        if (MessageBox.Show("是否確定刪除", "確認視窗", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            int iPaymentIDK = (int)dataGridView_Billing.CurrentRow.Cells["PaymentID"].Value;
                            Public.CPatentPayment DelBilling = new Public.CPatentPayment();                            
                            DelBilling.Delete(iPaymentIDK);
                            dataGridView_Billing.Rows.Remove(dataGridView_Billing.CurrentRow);
                            this.qS_DataSet.PatentPaymentT.AcceptChanges();
                            MessageBox.Show("刪除付款費用記錄成功", "提示訊息", MessageBoxButtons.OK);
                        }
                    }

                    break;
                case "toolStripMenuItem_PaymentUpdateFile":  //上傳付款費用相關文件

                    if (dataGridView_Billing.CurrentRow != null)
                    {
                        US.UpFileList upfile = new US.UpFileList();
                        upfile.Text = GridView_File.CurrentRow.Cells["PatentNo"].Value.ToString() + "  上傳付款費用相關文件";
                        upfile.UploadMode = 3;
                        upfile.MainFileKey = property_PatentID;
                        upfile.ChildFileKey = (int)dataGridView_Billing.CurrentRow.Cells["PaymentID"].Value;
                        upfile.MainFileType = 4;
                        upfile.ShowDialog();

                    }

                    break;

             
                case "付款証明單ToolStripMenuItem":
                    if (GridView_Fee.CurrentRow != null)
                    {

                    }
                    else
                    {
                        MessageBox.Show("無資料", "提示訊息", MessageBoxButtons.OK);
                    }
                    break;

                case "toolStripMenuItem_PaymentUpdateFileList":
                    if (dataGridView_Billing.CurrentRow != null)
                    {
                        ViewUpdateFileList subForm = new ViewUpdateFileList();
                        subForm.Text = GridView_File.CurrentRow.Cells["PatentNo"].Value.ToString() + "的付款費用相關文件";
                        subForm.FileKind = 3;
                        subForm.FileType = 4;
                        subForm.MainParentID = (int)GridView_File.CurrentRow.Cells["PatentID"].Value;
                        subForm.Child_ID = (int)dataGridView_Billing.CurrentRow.Cells["PaymentID"].Value;
                        subForm.ShowDialog();
                    }
                    break;
                case "toolStripMenuItem_PaymentEdit":
                case "toolStripButton_PayRecordEdit":
                    if (dataGridView_Billing.CurrentRow != null)
                    {
                        EditForm.EditPatentPayment edit = new LawtechPTSystemByFirm.EditForm.EditPatentPayment();
                        edit.Text = edit.Text + "(" + GridView_File.CurrentRow.Cells["CountryName"].Value.ToString() + ")" + "--" + GridView_File.CurrentRow.Cells["Title_File"].Value.ToString();
                        edit.CountrySymbol = GridView_File.CurrentRow.Cells["Country"].Value.ToString();
                        edit.property_PaymentID = (int)dataGridView_Billing.CurrentRow.Cells["PaymentID"].Value;
                        edit.ShowDialog();
                    }
                    break;

            }
        }
        #endregion

        private void dataGridView_Billing_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            contextMenuStrip_Billing_ItemClicked(contextMenuStrip_Billing, new ToolStripItemClickedEventArgs(toolStripMenuItem_PaymentEdit));
        }

        #region ===========GridView_Fee_SelectionChanged==============
        private void GridView_Fee_SelectionChanged(object sender, EventArgs e)
        {
            if (GridView_Fee.CurrentRow != null)
            {
                txt_FeeSubject.Text = GridView_Fee.CurrentRow.Cells["FeeSubject"].Value.ToString();
                txt_FeePhase.Text = GridView_Fee.CurrentRow.Cells["FeePhase"].FormattedValue.ToString();
                txtAttorneyFee1.Text = GridView_Fee.CurrentRow.Cells["IAttorneyFee"].Value.ToString();
                txtAttorneyFee2.Text = GridView_Fee.CurrentRow.Cells["OAttorneyFee"].Value.ToString();
                txtAttorneyFee3.Text = GridView_Fee.CurrentRow.Cells["GovFee"].Value.ToString();
                txt_IMoney.Text = GridView_Fee.CurrentRow.Cells["IMoney"].Value.ToString();
                txt_OMoney.Text = GridView_Fee.CurrentRow.Cells["OMoney"].Value.ToString();
                txt_GMoney.Text = GridView_Fee.CurrentRow.Cells["GMoney"].Value.ToString();
                txtMoney1.Text = GridView_Fee.CurrentRow.Cells["ItoNT"].Value.ToString();
                txtMoney2.Text = GridView_Fee.CurrentRow.Cells["OtoNT"].Value.ToString();
                txtMoney3.Text = GridView_Fee.CurrentRow.Cells["GtoNT"].Value.ToString();
                txtAttorneyFeeTotal1.Text = GridView_Fee.CurrentRow.Cells["ITotall"].Value.ToString();
                txtAttorneyFeeTotal2.Text = GridView_Fee.CurrentRow.Cells["OTotall"].Value.ToString();
                txtAttorneyFeeTotal3.Text = GridView_Fee.CurrentRow.Cells["GTotall"].Value.ToString();
               
                checkBox_Pay.Checked = (bool)GridView_Fee.CurrentRow.Cells["FeePay"].Value;
                checkBox_NT.Checked = (bool)GridView_Fee.CurrentRow.Cells["NT"].Value;
                chkWithholding.Checked = (bool)GridView_Fee.CurrentRow.Cells["Withholding"].Value;
                txtTax.Text = GridView_Fee.CurrentRow.Cells["Tax"].Value.ToString();
                txtOAttorneyGovFee.Text = GridView_Fee.CurrentRow.Cells["OAttorneyGovFee"].Value.ToString();
                txtTotall.Text = GridView_Fee.CurrentRow.Cells["Totall"].Value.ToString();
                txtPracicalityPay.Text = GridView_Fee.CurrentRow.Cells["PracticalityPay"].Value.ToString();
                txt_PayMemo.Text = GridView_Fee.CurrentRow.Cells["PayMemo"].Value.ToString();
                txt_Remark.Text = GridView_Fee.CurrentRow.Cells["Remark"].Value.ToString();
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

        private void bSource_File_DataError(object sender, BindingManagerDataErrorEventArgs e)
        {            
               string ss= e.Exception.Message.ToString();            
        }

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

        #region =============linkLabel===============
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LinkLabel link=(LinkLabel)sender;
            US.PopMemo pop;
            switch(link.Name)
            {
                case "linkLabel_CloseCaus":
                     pop = new LawtechPTSystemByFirm.US.PopMemo(txt_CloseCaus, true, link.Text);
                    break;
                case "linkLabel_mome":
                   pop = new LawtechPTSystemByFirm.US.PopMemo(txt_Remark2, true, link.Text);
                    break;
                case "linkLabel_ComitResult":
                    pop = new LawtechPTSystemByFirm.US.PopMemo(txt_ComitResult, true, link.Text);
                    break;
                case "linkLabel_eRemark":
                    pop = new LawtechPTSystemByFirm.US.PopMemo(txt_eRemark, true, link.Text);
                    break;
                case "linkLabel_NotifyResult":
                    pop = new LawtechPTSystemByFirm.US.PopMemo(txt_NotifyResult, true, link.Text);
                    break;
                case "linkLabel_NotifyRemark":
                    pop = new LawtechPTSystemByFirm.US.PopMemo(txt_NotifyRemark, true, link.Text);
                    break;
                case "linkLabel_PayMemo":
                    pop = new LawtechPTSystemByFirm.US.PopMemo(txt_PayMemo, true, link.Text);
                    break;
                case "linkLabel_Remark":
                    pop = new LawtechPTSystemByFirm.US.PopMemo(txt_Remark, true, link.Text);
                    break;
                case "linkLabel_PayRemark":
                    pop = new LawtechPTSystemByFirm.US.PopMemo(txt_PayRemark, true, link.Text);
                    break;
                default:
                    pop = new LawtechPTSystemByFirm.US.PopMemo(txt_FileNo, true, link.Text);
                    break;
        }

            pop.Show();
        }

        #endregion
    }
}