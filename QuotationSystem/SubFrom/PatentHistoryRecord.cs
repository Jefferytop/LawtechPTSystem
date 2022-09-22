using System;
using System.Windows.Forms;

namespace LawtechPTSystem.SubFrom
{
    /// <summary>
    /// 舊版 不要使用
    /// </summary>
    public partial class PatentHistoryRecord : Form
    {
        public PatentHistoryRecord()
        {
            InitializeComponent();
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
            set {
                _PatentID = value;
            }
        }
        #endregion

        private void PatentHistoryRecord_Load(object sender, EventArgs e)
        {
            this.patentManagementTTableAdapter.FillByPatentID(this.qS_DataSet.PatentManagementT, property_PatentID);
            TabFileBinding();
            ControlBindingPatComit();
            ControlBindingPatNotify();
            ControlBindingTMFee();
            ControlBindingTMPayment();

            this.patComitEventTTableAdapter.Fill(this.qS_DataSet.PatComitEventT, property_PatentID);
            this.patNotifyEventTTableAdapter.Fill(this.qS_DataSet.PatNotifyEventT, property_PatentID);
            this.patentFeeTTableAdapter.Fill(this.qS_DataSet.PatentFeeT, property_PatentID);
            this.patentPaymentTTableAdapter.Fill(this.qS_DataSet.PatentPaymentT, property_PatentID);

          
        }

        #region ================ControlBinding================
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


            txt_Applicant.DataBindings.Clear();
            txt_Applicant.DataBindings.Add("Text", bSource_File, "ApplicantNames", true, DataSourceUpdateMode.OnValidation, "", "");


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

            txtPPP.DataBindings.Clear();
            txtPPP.DataBindings.Add("Text", patentFeeTBindingSource, "PPP", true, DataSourceUpdateMode.OnValidation, "", "");

            numericUpDown_Days.DataBindings.Clear();
            numericUpDown_Days.DataBindings.Add("Value", patentFeeTBindingSource, "Days", true, DataSourceUpdateMode.OnValidation, "", "");

            //請款日
            mskRDate.DataBindings.Clear();
            mskRDate.DataBindings.Add("Text", patentFeeTBindingSource, "RDate", true, DataSourceUpdateMode.OnPropertyChanged, "    /  /", "yyyy/MM/dd");

            //請款人
            txt_WorkerName.DataBindings.Clear();
            txt_WorkerName.DataBindings.Add("Text", patentFeeTBindingSource, "WorkerName", true, DataSourceUpdateMode.OnValidation, "", "");

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
            txt_IServiceFee.DataBindings.Add("Text", patentPaymentTBindingSource, "IServiceFee", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_GovFee.DataBindings.Clear();
            txt_GovFee.DataBindings.Add("Text", patentPaymentTBindingSource, "GovFee", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_OtherFee.DataBindings.Clear();
            txt_OtherFee.DataBindings.Add("Text", patentPaymentTBindingSource, "OtherFee", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_IReceiptNo.DataBindings.Clear();
            txt_IReceiptNo.DataBindings.Add("Text", patentPaymentTBindingSource, "IReceiptNo", true, DataSourceUpdateMode.OnValidation, "", "");

            maskedTextBox_IReceiptDate.DataBindings.Clear();
            maskedTextBox_IReceiptDate.DataBindings.Add("Text", patentPaymentTBindingSource, "IReceiptDate", true, DataSourceUpdateMode.OnPropertyChanged, "    /  /", "yyyy/MM/dd");

            txt_PayTotall.DataBindings.Clear();
            txt_PayTotall.DataBindings.Add("Text", patentPaymentTBindingSource, "Totall", true, DataSourceUpdateMode.OnValidation, "", "");

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

            checkBox_IsCopyFile.DataBindings.Clear();
            checkBox_IsCopyFile.DataBindings.Add("Checked", patentPaymentTBindingSource, "IsCopyFile", true, DataSourceUpdateMode.OnValidation, false);

            checkBox_IsScan.DataBindings.Clear();
            checkBox_IsScan.DataBindings.Add("Checked", patentPaymentTBindingSource, "IsScan", true, DataSourceUpdateMode.OnValidation, false);

        }

        #endregion

       

        #endregion   
    }
}
