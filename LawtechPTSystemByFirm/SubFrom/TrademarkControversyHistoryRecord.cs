using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LawtechPTSystemByFirm.SubFrom
{
    public partial class TrademarkControversyHistoryRecord : Form
    {
        public TrademarkControversyHistoryRecord()
        {
            InitializeComponent();
        }

        private int iTrademarkControversyID = -1;
        /// <summary>
        /// 商標的PK
        /// </summary>
        public int TrademarkControversyID
        {
            get { return iTrademarkControversyID; }
            set { iTrademarkControversyID = value; }
        }

         private int iTabSelectedIndex = 0;
        /// <summary>
        /// 第幾個Tab 0.申請案基本資料  1.事件記錄 2.預估成本 3.異議/爭議  4.請款  5.付款
        /// </summary>
        public int TabSelectedIndex
        {
            get { return iTabSelectedIndex; }
            set { iTabSelectedIndex = value; }
        }


        #region ================ControlBinding================

        #region TabTrademarkBinding
        public void TabTrademarkBinding()
        {

            txt_TrademarkName.DataBindings.Clear();
            txt_TrademarkName.DataBindings.Add("Text", trademarkControversyManagementTBindingSource, "TrademarkName", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_ApplicantKey.DataBindings.Clear();
            txt_ApplicantKey.DataBindings.Add("Text", trademarkControversyManagementTBindingSource, "ApplicantNames", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_TrademarkNo.DataBindings.Clear();
            txt_TrademarkNo.DataBindings.Add("Text", trademarkControversyManagementTBindingSource, "TrademarkNo", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_Name.DataBindings.Clear();
            txt_Name.DataBindings.Add("Text", trademarkControversyManagementTBindingSource, "Name", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_TMTypeName.Clear();
            txt_TMTypeName.DataBindings.Add("Text", trademarkControversyManagementTBindingSource, "TMTypeName", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_TrademarOriginalNo.DataBindings.Clear();
            txt_TrademarOriginalNo.DataBindings.Add("Text", trademarkControversyManagementTBindingSource, "TrademarOriginalNo", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_DisagreementNo.Clear();
            txt_DisagreementNo.DataBindings.Add("Text", trademarkControversyManagementTBindingSource, "DisagreementNo", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_OutsourcingTrademarkNo.DataBindings.Clear();
            txt_OutsourcingTrademarkNo.DataBindings.Add("Text", trademarkControversyManagementTBindingSource, "OutsourcingTrademarkNo", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_ApplicationNo.DataBindings.Clear();
            txt_ApplicationNo.DataBindings.Add("Text", trademarkControversyManagementTBindingSource, "ApplicationNo", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_RegistrationNo.DataBindings.Clear();
            txt_RegistrationNo.DataBindings.Add("Text", trademarkControversyManagementTBindingSource, "RegistrationNo", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_RegisterProduct.DataBindings.Clear();
            txt_RegisterProduct.DataBindings.Add("Text", trademarkControversyManagementTBindingSource, "RegisterProduct", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_Remarks.DataBindings.Clear();
            txt_Remarks.DataBindings.Add("Text", trademarkControversyManagementTBindingSource, "Remarks", true, DataSourceUpdateMode.OnPropertyChanged, "");

            txt_OutsourcingTrademarkNo.DataBindings.Clear();
            txt_OutsourcingTrademarkNo.DataBindings.Add("Text", trademarkControversyManagementTBindingSource, "OutsourcingTrademarkNo", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_RegistrationNo.DataBindings.Clear();
            txt_RegistrationNo.DataBindings.Add("Text", trademarkControversyManagementTBindingSource, "RegistrationNo", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_RegisterProduct.DataBindings.Clear();
            txt_RegisterProduct.DataBindings.Add("Text", trademarkControversyManagementTBindingSource, "RegisterProduct", true, DataSourceUpdateMode.OnValidation, "", "");

            maskedTextBox_EntrustDate.DataBindings.Clear();
            maskedTextBox_EntrustDate.DataBindings.Add("Text", trademarkControversyManagementTBindingSource, "EntrustDate", true, DataSourceUpdateMode.OnPropertyChanged, "    /  /", "yyyy/MM/dd");

            maskedTextBox_RegistrationDate.DataBindings.Clear();
            maskedTextBox_RegistrationDate.DataBindings.Add("Text", trademarkControversyManagementTBindingSource, "RegistrationDate", true, DataSourceUpdateMode.OnValidation, "    /  /", "yyyy/MM/dd");

            //maskedTextBox_LawDate.DataBindings.Clear();
            //maskedTextBox_LawDate.DataBindings.Add("Text", trademarkControversyManagementTBindingSource, "LawDate", true, DataSourceUpdateMode.OnPropertyChanged, "    /  /", "yyyy/MM/dd");

            //異議日期
            maskedTextBox_ObjectionDate.DataBindings.Clear();
            maskedTextBox_ObjectionDate.DataBindings.Add("Text", trademarkControversyManagementTBindingSource, "ObjectionDate", true, DataSourceUpdateMode.OnPropertyChanged, "    /  /", "yyyy/MM/dd");

            maskedTextBox_DueDate.DataBindings.Clear();
            maskedTextBox_DueDate.DataBindings.Add("Text", trademarkControversyManagementTBindingSource, "DueDate", true, DataSourceUpdateMode.OnPropertyChanged, "    /  /", "yyyy/MM/dd");

            maskedTextBox_CloseDate.DataBindings.Clear();
            maskedTextBox_CloseDate.DataBindings.Add("Text", trademarkControversyManagementTBindingSource, "CloseDate", true, DataSourceUpdateMode.OnPropertyChanged, "    /  /", "yyyy/MM/dd");

            maskedTextBox_ApplicationDate.DataBindings.Clear();
            maskedTextBox_ApplicationDate.DataBindings.Add("Text", trademarkControversyManagementTBindingSource, "ApplicationDate", true, DataSourceUpdateMode.OnPropertyChanged, "    /  /", "yyyy/MM/dd");

            //委託類型
            txt_DelegateType.DataBindings.Clear();
            txt_DelegateType.DataBindings.Add("Text", trademarkControversyManagementTBindingSource, "DelegateTypeName", true, DataSourceUpdateMode.OnValidation);

            //主委託人
            txt_MainCustomer.DataBindings.Clear();
            txt_MainCustomer.DataBindings.Add("Text", trademarkControversyManagementTBindingSource, "MainCustomerName", true, DataSourceUpdateMode.OnValidation);

            //主委託人--聯絡窗口
            txt_MainCustomerTransactor.DataBindings.Clear();
            txt_MainCustomerTransactor.DataBindings.Add("Text", trademarkControversyManagementTBindingSource, "MainCustomerTransactorName", true, DataSourceUpdateMode.OnValidation);

            //主委託人--對方案號
            txt_MainCustomerRefNo.DataBindings.Clear();
            txt_MainCustomerRefNo.DataBindings.Add("Text", trademarkControversyManagementTBindingSource, "MainCustomerRefNo", true, DataSourceUpdateMode.OnValidation);

            //是否本所承辦案件
            chb_IsBySelf.DataBindings.Clear();
            chb_IsBySelf.DataBindings.Add("Checked", trademarkControversyManagementTBindingSource, "IsBySelf", true, DataSourceUpdateMode.OnPropertyChanged, false);

            //承辦事務所
            txt_AttorneyFirm.DataBindings.Clear();
            txt_AttorneyFirm.DataBindings.Add("Text", trademarkControversyManagementTBindingSource, "AttorneyFirm", true, DataSourceUpdateMode.OnValidation, "", "");

            //事務所聯絡人
            txt_Liaisoner.DataBindings.Clear();
            txt_Liaisoner.DataBindings.Add("Text", trademarkControversyManagementTBindingSource, "AttLiaisoner", true, DataSourceUpdateMode.OnValidation, "", "");

            //承辦事務所-委辦日期
            maskedTextBox_OutsourcingDate.DataBindings.Clear();
            maskedTextBox_OutsourcingDate.DataBindings.Add("Text", trademarkControversyManagementTBindingSource, "OutsourcingDate", true, DataSourceUpdateMode.OnPropertyChanged, "    /  /", "yyyy/MM/dd");

            //異議案號
            txt_ObjectionNo.DataBindings.Clear();
            txt_ObjectionNo.DataBindings.Add("Text", trademarkControversyManagementTBindingSource, "ObjectionNo", true, DataSourceUpdateMode.OnValidation, "", "");

            //異議類別
            txt_ObjectionClass.DataBindings.Clear();
            txt_ObjectionClass.DataBindings.Add("Text", trademarkControversyManagementTBindingSource, "ObjectionClass", true, DataSourceUpdateMode.OnValidation, "", "");

            //提出異議
            txt_ObjectionContent.DataBindings.Clear();
            txt_ObjectionContent.DataBindings.Add("Text", trademarkControversyManagementTBindingSource, "ObjectionContent", true, DataSourceUpdateMode.OnValidation, "", "");

            //被異議人
            txt_ObjectionPeople.DataBindings.Clear();
            txt_ObjectionPeople.DataBindings.Add("Text", trademarkControversyManagementTBindingSource, "ObjectionPeople", true, DataSourceUpdateMode.OnValidation, "", "");

            //被異議/爭議商標名稱
            txt_ObjectionTrademarkName.DataBindings.Clear();
            txt_ObjectionTrademarkName.DataBindings.Add("Text", trademarkControversyManagementTBindingSource, "ObjectionTrademarkName", true, DataSourceUpdateMode.OnValidation, "", "");

            //該案申請號
            txt_ObjectionApplicationNo.DataBindings.Clear();
            txt_ObjectionApplicationNo.DataBindings.Add("Text", trademarkControversyManagementTBindingSource, "ObjectionApplicationNo", true, DataSourceUpdateMode.OnValidation, "", "");

            //該案申請日
            mask_ObjectionApplicationDate.DataBindings.Clear();
            mask_ObjectionApplicationDate.DataBindings.Add("Text", trademarkControversyManagementTBindingSource, "ObjectionApplicationDate", true, DataSourceUpdateMode.OnPropertyChanged, "    /  /", "yyyy/MM/dd");

            //該案公告日
            mask_ObjectionNoticeDate.DataBindings.Clear();
            mask_ObjectionNoticeDate.DataBindings.Add("Text", trademarkControversyManagementTBindingSource, "ObjectionNoticeDate", true, DataSourceUpdateMode.OnPropertyChanged, "    /  /", "yyyy/MM/dd");

            //該案公告號
            txt_ObjectionNoticeNo.DataBindings.Clear();
            txt_ObjectionNoticeNo.DataBindings.Add("Text", trademarkControversyManagementTBindingSource, "ObjectionNoticeNo", true, DataSourceUpdateMode.OnValidation, "", "");

            //該案註冊日
            masked_ObjectionRegistrationDate.DataBindings.Clear();
            masked_ObjectionRegistrationDate.DataBindings.Add("Text", trademarkControversyManagementTBindingSource, "ObjectionRegistrationDate", true, DataSourceUpdateMode.OnPropertyChanged, "    /  /", "yyyy/MM/dd");

            //該案註冊號
            txt_ObjectionRegistrationNo.DataBindings.Clear();
            txt_ObjectionRegistrationNo.DataBindings.Add("Text", trademarkControversyManagementTBindingSource, "ObjectionRegistrationNo", true, DataSourceUpdateMode.OnValidation, "", "");

            //官方期限
            maskedTextBox_ObjectionDueDate.DataBindings.Clear();
            maskedTextBox_ObjectionDueDate.DataBindings.Add("Text", trademarkControversyManagementTBindingSource, "ObjectionDueDate", true, DataSourceUpdateMode.OnPropertyChanged, "    /  /", "yyyy/MM/dd");

          

        }
        #endregion

        #region ControlBindingTMNotify
        public void ControlBindingTMNotify()
        {

            txt_NotifyEventContent.DataBindings.Clear();
            txt_NotifyEventContent.DataBindings.Add("Text", trademarkControversyNotifyEventTBindingSource, "NotifyEventContent", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_WorkerKey.DataBindings.Clear();
            txt_WorkerKey.DataBindings.Add("Text", trademarkControversyNotifyEventTBindingSource, "WorkerName", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_NotifyResult.DataBindings.Clear();
            txt_NotifyResult.DataBindings.Add("Text", trademarkControversyNotifyEventTBindingSource, "Result", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_NotifyRemark.DataBindings.Clear();
            txt_NotifyRemark.DataBindings.Add("Text", trademarkControversyNotifyEventTBindingSource, "Remark", true, DataSourceUpdateMode.OnValidation, "", "");

            maskedTextBox_NotifyComitDate.DataBindings.Clear();
            maskedTextBox_NotifyComitDate.DataBindings.Add("Text", trademarkControversyNotifyEventTBindingSource, "NotifyComitDate", true, DataSourceUpdateMode.OnPropertyChanged, "    /  /", "yyyy/MM/dd");

            maskedTextBox_NotifyOfficerDate.DataBindings.Clear();
            maskedTextBox_NotifyOfficerDate.DataBindings.Add("Text", trademarkControversyNotifyEventTBindingSource, "NotifyOfficerDate", true, DataSourceUpdateMode.OnPropertyChanged, "    /  /", "yyyy/MM/dd");

            maskedTextBox_OccurDate.DataBindings.Clear();
            maskedTextBox_OccurDate.DataBindings.Add("Text", trademarkControversyNotifyEventTBindingSource, "OccurDate", true, DataSourceUpdateMode.OnPropertyChanged, "    /  /", "yyyy/MM/dd");

            maskedTextBox_DueDate.DataBindings.Clear();
            maskedTextBox_DueDate.DataBindings.Add("Text", trademarkControversyNotifyEventTBindingSource, "DueDate", true, DataSourceUpdateMode.OnPropertyChanged, "    /  /", "yyyy/MM/dd");

            maskedTextBox_Notice.DataBindings.Clear();
            maskedTextBox_Notice.DataBindings.Add("Text", trademarkControversyNotifyEventTBindingSource, "NoticeDate", true, DataSourceUpdateMode.OnPropertyChanged, "    /  /", "yyyy/MM/dd");

            maskedTextBox_CustomerAuthorizationDate.DataBindings.Clear();
            maskedTextBox_CustomerAuthorizationDate.DataBindings.Add("Text", trademarkControversyNotifyEventTBindingSource, "CustomerAuthorizationDate", true, DataSourceUpdateMode.OnPropertyChanged, "    /  /", "yyyy/MM/dd");

            mtb_OutsourcingDate.DataBindings.Clear();
            mtb_OutsourcingDate.DataBindings.Add("Text", trademarkControversyNotifyEventTBindingSource, "OutsourcingDate", true, DataSourceUpdateMode.OnPropertyChanged, "    /  /", "yyyy/MM/dd");

            maskedTextBox_FinishDate.DataBindings.Clear();
            maskedTextBox_FinishDate.DataBindings.Add("Text", trademarkControversyNotifyEventTBindingSource, "FinishDate", true, DataSourceUpdateMode.OnPropertyChanged, "    /  /", "yyyy/MM/dd");

            maskedTextBox_AttorneyDueDate.DataBindings.Clear();
            maskedTextBox_AttorneyDueDate.DataBindings.Add("Text", trademarkControversyNotifyEventTBindingSource, "AttorneyDueDate", true, DataSourceUpdateMode.OnPropertyChanged, "    /  /", "yyyy/MM/dd");

        }
        #endregion

        #region ControlBindingTMFee
        public void ControlBindingTMFee()
        {

            txt_FeeSubject.DataBindings.Clear();
            txt_FeeSubject.DataBindings.Add("Text", trademarkControversyFeeTBindingSource, "FeeSubject", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_FeePhase.DataBindings.Clear();
            txt_FeePhase.DataBindings.Add("Text", trademarkControversyFeeTBindingSource, "FeePhaseName", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_AttorneyName.DataBindings.Clear();
            txt_AttorneyName.DataBindings.Add("Text", trademarkControversyFeeTBindingSource, "AttorneyFirm", true, DataSourceUpdateMode.OnValidation, "", "");

            txtAttorneyFee1.DataBindings.Clear();
            txtAttorneyFee1.DataBindings.Add("Text", trademarkControversyFeeTBindingSource, "Totall", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");

            txtAttorneyFee2.DataBindings.Clear();
            txtAttorneyFee2.DataBindings.Add("Text", trademarkControversyFeeTBindingSource, "OAttorneyFee", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");

            txtAttorneyFee3.DataBindings.Clear();
            txtAttorneyFee3.DataBindings.Add("Text", trademarkControversyFeeTBindingSource, "OthFee", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");

            txtAttorneyFee4.DataBindings.Clear();
            txtAttorneyFee4.DataBindings.Add("Text", trademarkControversyFeeTBindingSource, "GovFee", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");

            txt_IMoney.DataBindings.Clear();
            txt_IMoney.DataBindings.Add("Text", trademarkControversyFeeTBindingSource, "TMoney", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_OMoney.DataBindings.Clear();
            txt_OMoney.DataBindings.Add("Text", trademarkControversyFeeTBindingSource, "OMoney", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_OMoney1.DataBindings.Clear();
            txt_OMoney1.DataBindings.Add("Text", trademarkControversyFeeTBindingSource, "OMoney", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_GMoney.DataBindings.Clear();
            txt_GMoney.DataBindings.Add("Text", trademarkControversyFeeTBindingSource, "GMoney", true, DataSourceUpdateMode.OnValidation, "", "");

            txtMoney1.DataBindings.Clear();
            txtMoney1.DataBindings.Add("Text", trademarkControversyFeeTBindingSource, "TtoNT", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");

            txtMoney2.DataBindings.Clear();
            txtMoney2.DataBindings.Add("Text", trademarkControversyFeeTBindingSource, "OtoNT", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");

            txtMoney21.DataBindings.Clear();
            txtMoney21.DataBindings.Add("Text", trademarkControversyFeeTBindingSource, "OtoNT", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");

            txtMoney3.DataBindings.Clear();
            txtMoney3.DataBindings.Add("Text", trademarkControversyFeeTBindingSource, "GtoNT", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");

            txtAttorneyFeeTotal1.DataBindings.Clear();
            txtAttorneyFeeTotal1.DataBindings.Add("Text", trademarkControversyFeeTBindingSource, "TotalNT", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");

            txtAttorneyFeeTotal2.DataBindings.Clear();
            txtAttorneyFeeTotal2.DataBindings.Add("Text", trademarkControversyFeeTBindingSource, "OTotall", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");

            txtAttorneyFeeTotal3.DataBindings.Clear();
            txtAttorneyFeeTotal3.DataBindings.Add("Text", trademarkControversyFeeTBindingSource, "OthTotal", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");

            txtAttorneyFeeTotal4.DataBindings.Clear();
            txtAttorneyFeeTotal4.DataBindings.Add("Text", trademarkControversyFeeTBindingSource, "GTotall", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");

            txt_PayKind.DataBindings.Clear();
            txt_PayKind.DataBindings.Add("Text", trademarkControversyFeeTBindingSource, "PayKind", true, DataSourceUpdateMode.OnValidation, "", "");

            checkBox_Pay.DataBindings.Clear();
            checkBox_Pay.DataBindings.Add("Checked", trademarkControversyFeeTBindingSource, "Pay", true, DataSourceUpdateMode.OnValidation, false);

            checkBox_NT.DataBindings.Clear();
            checkBox_NT.DataBindings.Add("Checked", trademarkControversyFeeTBindingSource, "NT", true, DataSourceUpdateMode.OnValidation, false);

            chkWithholding.DataBindings.Clear();
            chkWithholding.DataBindings.Add("Checked", trademarkControversyFeeTBindingSource, "Withholding", true, DataSourceUpdateMode.OnValidation, false);

            txtTax.DataBindings.Clear();
            txtTax.DataBindings.Add("Text", trademarkControversyFeeTBindingSource, "Tax", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");

            txtOAttorneyGovFee.DataBindings.Clear();
            txtOAttorneyGovFee.DataBindings.Add("Text", trademarkControversyFeeTBindingSource, "OAttorneyGovFee", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");


            txt_OtherTotalFee.DataBindings.Clear();
            txt_OtherTotalFee.DataBindings.Add("Text", trademarkControversyFeeTBindingSource, "OtherTotalFee", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");

            txtPracicalityPay.DataBindings.Clear();
            txtPracicalityPay.DataBindings.Add("Text", trademarkControversyFeeTBindingSource, "PracticalityPay", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");

            txt_PayMemo.DataBindings.Clear();
            txt_PayMemo.DataBindings.Add("Text", trademarkControversyFeeTBindingSource, "PayMemo", true, DataSourceUpdateMode.OnValidation, "", "");

            //簽核
            txt_SingCode.DataBindings.Clear();
            txt_SingCode.DataBindings.Add("Text", trademarkControversyFeeTBindingSource, "SingCode", true, DataSourceUpdateMode.OnPropertyChanged, "", "");

            //請款單號
            txt_PPP.DataBindings.Clear();
            txt_PPP.DataBindings.Add("Text", trademarkControversyFeeTBindingSource, "PPP", true, DataSourceUpdateMode.OnValidation, "", "");

            //請款人
            txt_FeeWorkerName.DataBindings.Clear();
            txt_FeeWorkerName.DataBindings.Add("Text", trademarkControversyFeeTBindingSource, "WorkerName", true, DataSourceUpdateMode.OnValidation, "", "");


            //請款日期
            maskedTextBox_RDate.DataBindings.Clear();
            maskedTextBox_RDate.DataBindings.Add("Text", trademarkControversyFeeTBindingSource, "RDate", true, DataSourceUpdateMode.OnValidation, "    /  /", "yyyy/MM/dd");

            //收款日期
            maskedTextBox_PayDate.DataBindings.Clear();
            maskedTextBox_PayDate.DataBindings.Add("Text", trademarkControversyFeeTBindingSource, "PayDate", true, DataSourceUpdateMode.OnValidation, "    /  /", "yyyy/MM/dd");
        }

        #endregion

        #region ControlBindingTMEstimateCost
        public void ControlBindingTMEstimateCost()
        {
            txt_ES_FeeSubject.DataBindings.Clear();
            txt_ES_FeeSubject.DataBindings.Add("Text", trademarkControveryEstimateCostTBindingSource, "FeeSubject", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_ES_IAttorneyFee.DataBindings.Clear();
            txt_ES_IAttorneyFee.DataBindings.Add("Text", trademarkControveryEstimateCostTBindingSource, "IAttorneyFee", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");

            txt_ES_GovFee.DataBindings.Clear();
            txt_ES_GovFee.DataBindings.Add("Text", trademarkControveryEstimateCostTBindingSource, "GovFee", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");

            txt_ES_OtherFee.DataBindings.Clear();
            txt_ES_OtherFee.DataBindings.Add("Text", trademarkControveryEstimateCostTBindingSource, "OtherFee", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");

            txt_ES_IMoney.DataBindings.Clear();
            txt_ES_IMoney.DataBindings.Add("Text", trademarkControveryEstimateCostTBindingSource, "IMoney", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");

            txt_ES_OtherMoney.DataBindings.Clear();
            txt_ES_OtherMoney.DataBindings.Add("Text", trademarkControveryEstimateCostTBindingSource, "OtherMoney", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");

            txt_ES_GMoney.DataBindings.Clear();
            txt_ES_GMoney.DataBindings.Add("Text", trademarkControveryEstimateCostTBindingSource, "GMoney", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");

            txt_ES_ItoNT.DataBindings.Clear();
            txt_ES_ItoNT.DataBindings.Add("Text", trademarkControveryEstimateCostTBindingSource, "ItoNT", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");

            txt_ES_ITotall.DataBindings.Clear();
            txt_ES_ITotall.DataBindings.Add("Text", trademarkControveryEstimateCostTBindingSource, "ITotall", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");

            txt_ES_GtoNT.DataBindings.Clear();
            txt_ES_GtoNT.DataBindings.Add("Text", trademarkControveryEstimateCostTBindingSource, "GtoNT", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");

            txt_ES_GTotall.DataBindings.Clear();
            txt_ES_GTotall.DataBindings.Add("Text", trademarkControveryEstimateCostTBindingSource, "GTotall", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");

            txt_ES_OtherNT.DataBindings.Clear();
            txt_ES_OtherNT.DataBindings.Add("Text", trademarkControveryEstimateCostTBindingSource, "OtherNT", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");

            txt_ES_OtherTotal.DataBindings.Clear();
            txt_ES_OtherTotal.DataBindings.Add("Text", trademarkControveryEstimateCostTBindingSource, "OtherTotal", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");

            txt_EstimateProfit.DataBindings.Clear();
            txt_EstimateProfit.DataBindings.Add("Text", trademarkControveryEstimateCostTBindingSource, "EstimateProfit", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");

            txt_EstimateCost.DataBindings.Clear();
            txt_EstimateCost.DataBindings.Add("Text", trademarkControveryEstimateCostTBindingSource, "EstimateCost", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");

            txt_ES_PayMemo.DataBindings.Clear();
            txt_ES_PayMemo.DataBindings.Add("Text", trademarkControveryEstimateCostTBindingSource, "PayMemo", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_ES_Remark.DataBindings.Clear();
            txt_ES_Remark.DataBindings.Add("Text", trademarkControveryEstimateCostTBindingSource, "Remark", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_ServicePrice.DataBindings.Clear();
            txt_ServicePrice.DataBindings.Add("Text", trademarkControveryEstimateCostTBindingSource, "ServicePrice", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");

            txt_RealPrice.DataBindings.Clear();
            txt_RealPrice.DataBindings.Add("Text", trademarkControveryEstimateCostTBindingSource, "RealPrice", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");


        }

        #endregion

        #region ControlBindingTMPayment
        public void ControlBindingTMPayment()
        {
            txt_PayFeeSubject.DataBindings.Clear();
            txt_PayFeeSubject.DataBindings.Add("Text", trademarkControversyPaymentTBindingSource, "FeeSubject", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_PayFeePhase.DataBindings.Clear();
            txt_PayFeePhase.DataBindings.Add("Text", trademarkControversyPaymentTBindingSource, "FeePhaseName", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_PaySingCode.DataBindings.Clear();
            txt_PaySingCode.DataBindings.Add("Text", trademarkControversyPaymentTBindingSource, "SingCode", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_FClientTransactor.DataBindings.Clear();
            txt_FClientTransactor.DataBindings.Add("Text", trademarkControversyPaymentTBindingSource, "WorkerName", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_Attorney.DataBindings.Clear();
            txt_Attorney.DataBindings.Add("Text", trademarkControversyPaymentTBindingSource, "AttorneyFirm", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_PayPayKind.DataBindings.Clear();
            txt_PayPayKind.DataBindings.Add("Text", trademarkControversyPaymentTBindingSource, "PayKind", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_PayIMoney.DataBindings.Clear();
            txt_PayIMoney.DataBindings.Add("Text", trademarkControversyPaymentTBindingSource, "IMoney", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_IServiceFee.DataBindings.Clear();
            txt_IServiceFee.DataBindings.Add("Text", trademarkControversyPaymentTBindingSource, "IServiceFee", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_GovFee.DataBindings.Clear();
            txt_GovFee.DataBindings.Add("Text", trademarkControversyPaymentTBindingSource, "GovFee", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_OtherFee.DataBindings.Clear();
            txt_OtherFee.DataBindings.Add("Text", trademarkControversyPaymentTBindingSource, "OtherFee", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_IReceiptNo.DataBindings.Clear();
            txt_IReceiptNo.DataBindings.Add("Text", trademarkControversyPaymentTBindingSource, "IReceiptNo", true, DataSourceUpdateMode.OnValidation, "", "");

            maskedTextBox_IReceiptDate.DataBindings.Clear();
            maskedTextBox_IReceiptDate.DataBindings.Add("Text", trademarkControversyPaymentTBindingSource, "IReceiptDate", true, DataSourceUpdateMode.OnPropertyChanged, "    /  /", "yyyy/MM/dd");

            txt_PayTotall.DataBindings.Clear();
            txt_PayTotall.DataBindings.Add("Text", trademarkControversyPaymentTBindingSource, "Totall", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_PayRemark.DataBindings.Clear();
            txt_PayRemark.DataBindings.Add("Text", trademarkControversyPaymentTBindingSource, "Remark", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_Memo.DataBindings.Clear();
            txt_Memo.DataBindings.Add("Text", trademarkControversyPaymentTBindingSource, "Memo", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_BillCheck.DataBindings.Clear();
            txt_BillCheck.DataBindings.Add("Text", trademarkControversyPaymentTBindingSource, "BillCheck", true, DataSourceUpdateMode.OnValidation, "", "");

            maskedTextBox_ReciveDate.DataBindings.Clear();
            maskedTextBox_ReciveDate.DataBindings.Add("Text", trademarkControversyPaymentTBindingSource, "ReciveDate", true, DataSourceUpdateMode.OnPropertyChanged, "    /  /", "yyyy/MM/dd");

            maskedTextBox_PayDueDate.DataBindings.Clear();
            maskedTextBox_PayDueDate.DataBindings.Add("Text", trademarkControversyPaymentTBindingSource, "PayDueDate", true, DataSourceUpdateMode.OnPropertyChanged, "    /  /", "yyyy/MM/dd");

            maskedTextBox_PaymentDate.DataBindings.Clear();
            maskedTextBox_PaymentDate.DataBindings.Add("Text", trademarkControversyPaymentTBindingSource, "PaymentDate", true, DataSourceUpdateMode.OnPropertyChanged, "    /  /", "yyyy/MM/dd");

            checkBox_IsBilling.DataBindings.Clear();
            checkBox_IsBilling.DataBindings.Add("Checked", trademarkControversyPaymentTBindingSource, "IsBilling", true, DataSourceUpdateMode.OnValidation, false);

            txt_BillingNo.DataBindings.Clear();
            txt_BillingNo.DataBindings.Add("Text", trademarkControversyPaymentTBindingSource, "BillingNo", true, DataSourceUpdateMode.OnValidation, "", "");

            checkBox_IsCopyFile.DataBindings.Clear();
            checkBox_IsCopyFile.DataBindings.Add("Checked", trademarkControversyPaymentTBindingSource, "IsCopyFile", true, DataSourceUpdateMode.OnValidation, false);

            checkBox_IsScan.DataBindings.Clear();
            checkBox_IsScan.DataBindings.Add("Checked", trademarkControversyPaymentTBindingSource, "IsScan", true, DataSourceUpdateMode.OnValidation, false);

            //匯率
            txt_ExchangeRate.DataBindings.Clear();
            txt_ExchangeRate.DataBindings.Add("Text", trademarkControversyPaymentTBindingSource, "ExchangeRate", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");
        }

        #endregion

        #endregion

        #region TrademarkControversyHistoryRecord_Load
        private void TrademarkControversyHistoryRecord_Load(object sender, EventArgs e)
        {
            this.trademarkControversyManagementTTableAdapter1.FillByID(this.dataSet_TrademarkControversy.TrademarkControversyManagementT, iTrademarkControversyID);
            
            //事件記錄
            this.trademarkControversyNotifyEventTTableAdapter.Fill(this.dataSet_TrademarkControversy.TrademarkControversyNotifyEventT, iTrademarkControversyID);

            //請款記錄
            this.trademarkControversyFeeTTableAdapter.Fill(this.dataSet_TrademarkControversy.TrademarkControversyFeeT, iTrademarkControversyID);

            //付款記錄
            this.trademarkControversyPaymentTTableAdapter.Fill(this.dataSet_TrademarkControversy.TrademarkControversyPaymentT, iTrademarkControversyID);

            //預估成本
            this.trademarkControveryEstimateCostTTableAdapter.Fill(this.dataSet_TrademarkControversy.TrademarkControveryEstimateCostT, iTrademarkControversyID);
            
            TabTrademarkBinding();
            ControlBindingTMNotify();
            ControlBindingTMFee();
            ControlBindingTMEstimateCost();
            ControlBindingTMPayment();

            Tabcontrol1.SelectedIndex = TabSelectedIndex;
            
            this.Text=this.Text+"("+txt_TrademarkNo.Text+")";
        }
        #endregion

        private void but_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButton_ExcelFee_Click(object sender, EventArgs e)
        {
            try
            {
                Public.DLL dll = new LawtechPTSystemByFirm.Public.DLL();
                Task task = dll.WriteToCSV(GridView_Fee);
            }
            catch
            {
                MessageBox.Show("匯出Excel失敗");
            }
        }

      

        private void toolStripButton_ExcelPayment_Click(object sender, EventArgs e)
        {
            try
            {
                Public.DLL dll = new LawtechPTSystemByFirm.Public.DLL();
                Task task = dll.WriteToCSV(dataGridView_Billing);
            }
            catch
            {
                MessageBox.Show("匯出Excel失敗");
            }
        }

        private void bindingNavigatorAddNewItem_ExcelEvent_Click(object sender, EventArgs e)
        {
            try
            {
                Public.DLL dll = new LawtechPTSystemByFirm.Public.DLL();
                Task task = dll.WriteToCSV(TMNotifyEventTDataGridView);
            }
            catch
            {
                MessageBox.Show("匯出Excel失敗");
            }
        }

      

     
    }
}
