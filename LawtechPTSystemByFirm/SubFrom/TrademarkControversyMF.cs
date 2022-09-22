using System;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading.Tasks;

namespace LawtechPTSystemByFirm.SubFrom
{
    public partial class TrademarkControversyMF : Form
    {

        #region ================資料集================
        /// <summary>
        /// TrademarkControversyManagementT 資料集
        /// </summary>
        public DataSet_TrademarkControversy.TrademarkControversyManagementTDataTable dt_TrademarkControversyManagementT
        {
            get
            {
                return this.dataSet_TrademarkControversy.TrademarkControversyManagementT;
            }

        }

        /// <summary>
        /// TrademarkControversyNotifyEventT 來函
        /// </summary>
        public DataSet_TrademarkControversy.TrademarkControversyNotifyEventTDataTable dt_TrademarkControversyNotifyEventT
        {
            get
            {
                return this.dataSet_TrademarkControversy.TrademarkControversyNotifyEventT;
            }

        }

        /// <summary>
        /// TrademarkControversyFeeT 請款費用
        /// </summary>
        public DataSet_TrademarkControversy.TrademarkControversyFeeTDataTable dt_TrademarkControversyFeeT
        {
            get
            {
                return this.dataSet_TrademarkControversy.TrademarkControversyFeeT;
            }

        }

        /// <summary>
        /// TrademarkControversyPaymentT 付款費用
        /// </summary>
        public DataSet_TrademarkControversy.TrademarkControversyPaymentTDataTable dt_TrademarkControversyPaymentT
        {
            get
            {
                return this.dataSet_TrademarkControversy.TrademarkControversyPaymentT;
            }

        }

        /// <summary>
        /// TrademarkEstimateCostT 預估成本
        /// </summary>
        public DataSet_TrademarkControversy.TrademarkControveryEstimateCostTDataTable dt_TrademarkControveryEstimateCostT
        {
            get
            {
                return this.dataSet_TrademarkControversy.TrademarkControveryEstimateCostT;
            }

        }

        /// <summary>
        /// 重新整理資料集 0.商標 1.案件記錄 2.預估成本  3.請款費用  4.付款費用 
        /// </summary>
        /// <param name="iTable"></param>
        public void RefrashDataTable(int iTable)
        {
            switch (iTable)
            {
                case 0:
                    this.dataSet_TrademarkControversy.TrademarkControversyManagementT.Rows.Clear();
                    //this.trademarkcontManagementTTableAdapter.Fill(this.dataSet_TrademarkControversy.TrademarkControversyManagementT);
                    break;
                case 1:
                    this.dataSet_TrademarkControversy.TrademarkControversyNotifyEventT.Rows.Clear();
                    this.trademarkControversyNotifyEventTTableAdapter.Fill(this.dataSet_TrademarkControversy.TrademarkControversyNotifyEventT, property_TrademarkID);
                    break;

                case 2:
                    this.dataSet_TrademarkControversy.TrademarkControveryEstimateCostT.Rows.Clear();
                    this.trademarkControveryEstimateCostTTableAdapter.Fill(this.dataSet_TrademarkControversy.TrademarkControveryEstimateCostT, property_TrademarkID);
                    break;

                case 3:
                    this.dataSet_TrademarkControversy.TrademarkControversyFeeT.Rows.Clear();
                    //this.trademarkFeeTTableAdapter.Fill(this.dataSet_TrademarkControversy.TrademarkControversyFeeT, property_TrademarkID);
                    break;

                case 4:
                    this.dataSet_TrademarkControversy.TrademarkControversyPaymentT.Rows.Clear();
                    //this.trademarkPaymentTTableAdapter.Fill(this.dataSet_TrademarkControversy.TrademarkControversyPaymentT, property_TrademarkID);
                    break;

             
            }
        }
        #endregion

        #region ==========Property==========
        /// <summary>
        /// TrademarkControversyID
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


        /// <summary>
        /// TrademarkControversyNo
        /// </summary>
        public string property_TrademarkNo
        {
            get
            {
                if (trademarkManagementTDataGridView.CurrentRow != null)
                {
                    return trademarkManagementTDataGridView.CurrentRow.Cells["TrademarkNo"].Value.ToString();
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

        /// <summary>
        /// 商標異議案的Root Path
        /// </summary>
        public string property_TMrootPath
        {
            get
            {
                Public.DLL dll = new LawtechPTSystemByFirm.Public.DLL();
                return dll.TrademarkControversyFolderRoot;
            }
        }


        //public string property_TMPicturePath
        //{
        //    get
        //    {
        //        return pictureBox1.ImageLocation;
        //    }
        //    set
        //    {
        //        pictureBox1.ImageLocation = value;
        //    }
        //}

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


        public TrademarkControversyMF()
        {
            InitializeComponent();
        }

        #region TrademarkControversyMF_Load    TrademarkControversyMF_FormClosed
        private void TrademarkControversyMF_Load(object sender, EventArgs e)
        {
                     
            Public.PublicForm Forms = new LawtechPTSystemByFirm.Public.PublicForm();
            Forms.TrademarkControversyMF = this;

            DateTime dtStart = new DateTime(DateTime.Now.Year - 2, 1, 1);
            userControlFilterDate1.MaskedStartDate.Text = dtStart.ToString("yyyy/MM/dd");

            this.tMSelectDateModelTableAdapter.Fill(this.dataSet_Drop.TMSelectDateModel);


            TabTrademarkBinding();
            ControlBindingTMNotify();
            ControlBindingTMEstimateCost();
            ControlBindingTMFee();
            ControlBindingTMPayment();

            but_ShowDetail_Click(null, null);
            but_Search_Click(null, null);
        }

        private void TrademarkControversyMF_FormClosed(object sender, FormClosedEventArgs e)
        {
            Public.PublicForm Forms = new LawtechPTSystemByFirm.Public.PublicForm();

            Forms.TrademarkControversyMF = null;
        }
        #endregion

        #region but_Close_Click
        private void but_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region but_Search_Click
        private void but_Search_Click(object sender, EventArgs e)
        {
            but_Search.Enabled = false;
            
            Public.DLL dll = new LawtechPTSystemByFirm.Public.DLL();

            if (this.dataSet_TrademarkControversy.TrademarkControversyManagementT.Rows.Count > 0)
            {
                this.dataSet_TrademarkControversy.TrademarkControversyManagementT.Clear();
            }

            string FullWhere = Public.CommonFunctions.GetSQLScript(QueryFilter1, QueryFilter2, rb_and.Checked ? " and " : " or ", userControlFilterDate1);

            string SQL = @"SELECT *  from  V_TrademarkControversyList  " + FullWhere.ToString();
            
            dll.FetchDataTable(SQL, this.dataSet_TrademarkControversy.TrademarkControversyManagementT);

            but_Search.Enabled = true;
        }
        #endregion 

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
            txt_Name.DataBindings.Add("Text", trademarkControversyManagementTBindingSource, "EmployeeName", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_DisagreementNo.Clear();
            txt_DisagreementNo.DataBindings.Add("Text", trademarkControversyManagementTBindingSource, "DisagreementNo", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_TMTypeName.DataBindings.Clear();
            txt_TMTypeName.DataBindings.Add("Text", trademarkControversyManagementTBindingSource, "TMTypeName", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_TrademarOriginalNo.DataBindings.Clear();
            txt_TrademarOriginalNo.DataBindings.Add("Text", trademarkControversyManagementTBindingSource, "TrademarOriginalNo", true, DataSourceUpdateMode.OnValidation, "", "");

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

            txt_ES_OAttorneyFee.DataBindings.Clear();
            txt_ES_OAttorneyFee.DataBindings.Add("Text", trademarkControveryEstimateCostTBindingSource, "OAttorneyFee", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");

            txt_ES_OMoney.DataBindings.Clear();
            txt_ES_OMoney.DataBindings.Add("Text", trademarkControveryEstimateCostTBindingSource, "OMoney", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_ES_OtoNT.DataBindings.Clear();
            txt_ES_OtoNT.DataBindings.Add("Text", trademarkControveryEstimateCostTBindingSource, "OtoNT", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");

            txt_ES_OTotall.DataBindings.Clear();
            txt_ES_OTotall.DataBindings.Add("Text", trademarkControveryEstimateCostTBindingSource, "OTotall", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");

            txt_ES_GovFee.DataBindings.Clear();
            txt_ES_GovFee.DataBindings.Add("Text", trademarkControveryEstimateCostTBindingSource, "GovFee", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");

            txt_ES_OtherFee.DataBindings.Clear();
            txt_ES_OtherFee.DataBindings.Add("Text", trademarkControveryEstimateCostTBindingSource, "OtherFee", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");

            txt_ES_IMoney.DataBindings.Clear();
            txt_ES_IMoney.DataBindings.Add("Text", trademarkControveryEstimateCostTBindingSource, "IMoney", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_ES_OtherMoney.DataBindings.Clear();
            txt_ES_OtherMoney.DataBindings.Add("Text", trademarkControveryEstimateCostTBindingSource, "OtherMoney", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_ES_GMoney.DataBindings.Clear();
            txt_ES_GMoney.DataBindings.Add("Text", trademarkControveryEstimateCostTBindingSource, "GMoney", true, DataSourceUpdateMode.OnValidation, "", "");

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

            txt_RealPrice.DataBindings.Clear();
            txt_RealPrice.DataBindings.Add("Text", trademarkControveryEstimateCostTBindingSource, "RealPrice", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");

            txt_ES_PayMemo.DataBindings.Clear();
            txt_ES_PayMemo.DataBindings.Add("Text", trademarkControveryEstimateCostTBindingSource, "PayMemo", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_ES_Remark.DataBindings.Clear();
            txt_ES_Remark.DataBindings.Add("Text", trademarkControveryEstimateCostTBindingSource, "Remark", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_ServicePrice.DataBindings.Clear();
            txt_ServicePrice.DataBindings.Add("Text", trademarkControveryEstimateCostTBindingSource, "ServicePrice", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");         


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
            txt_IServiceFee.DataBindings.Add("Text", trademarkControversyPaymentTBindingSource, "IServiceFee", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");

            txt_GovFee.DataBindings.Clear();
            txt_GovFee.DataBindings.Add("Text", trademarkControversyPaymentTBindingSource, "GovFee", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");

            txt_OtherFee.DataBindings.Clear();
            txt_OtherFee.DataBindings.Add("Text", trademarkControversyPaymentTBindingSource, "OtherFee", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");

            txt_IReceiptNo.DataBindings.Clear();
            txt_IReceiptNo.DataBindings.Add("Text", trademarkControversyPaymentTBindingSource, "IReceiptNo", true, DataSourceUpdateMode.OnValidation, "", "");

            maskedTextBox_IReceiptDate.DataBindings.Clear();
            maskedTextBox_IReceiptDate.DataBindings.Add("Text", trademarkControversyPaymentTBindingSource, "IReceiptDate", true, DataSourceUpdateMode.OnPropertyChanged, "    /  /", "yyyy/MM/dd");

            txt_PayTotall.DataBindings.Clear();
            txt_PayTotall.DataBindings.Add("Text", trademarkControversyPaymentTBindingSource, "Totall", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");

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

        #region CheckPatenDel 如果有子資料，將回傳False , 若無子資料回傳True
        /// <summary>
        /// 驗証案件是否可刪除
        /// 如果有子資料，將回傳False , 若無子資料回傳True
        /// </summary>
        /// <param name="iTrademarkControversyID"></param>
        /// <returns></returns>
        private bool CheckPatenDel(int iTrademarkControversyID)
        {
            string strSQL = string.Format(@"select Top 1 TMNotifyControversyEventID from TrademarkControversyNotifyEventT where TrademarkControversyID={0}; 
                                            select Top 1 ControversyPaymentID from TrademarkControversyPaymentT where TrademarkControversyID={0};
                                            select Top 1 ControversyFeeKEY from TrademarkControversyFeeT where TrademarkControversyID={0};
                                           ", iTrademarkControversyID.ToString());

            Public.DLL dll = new LawtechPTSystemByFirm.Public.DLL();
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
                    AddFrom.AddTrademarkControversyManagement add = new AddFrom.AddTrademarkControversyManagement();
                    add.ShowDialog();
                    break;

                case "DelTMtoolStripMenuItem":
                case "toolStripButton_DelTM":
                    if (trademarkManagementTDataGridView.CurrentRow != null)
                    {
                        //1.判斷是否有子資料
                        if (!CheckPatenDel((int)trademarkManagementTDataGridView.CurrentRow.Cells["TrademarkID"].Value))
                        {
                            MessageBox.Show("該案件不得刪除，因案件下尚有子資料，請先將子資料刪除\r\n \r\n即可刪除此申請案【" + trademarkManagementTDataGridView.CurrentRow.Cells["TrademarkNo"].Value.ToString() + "】", "提示訊息");
                            return;
                        }

                        //2.鎖定資料
                        int iLocker = Public.Utility.GetRecordAuth("TrademarkControversyManagementT", "TrademarkControversyID=" + property_TrademarkID.ToString());
                        if (iLocker == -1 || iLocker == iWorkerID)
                        {
                            if (iLocker != iWorkerID)
                            {
                                Public.Utility.LockRecordAuth("TrademarkControversyManagementT", iWorkerID, "TrademarkControversyID=" + property_TrademarkID.ToString());
                            }

                            if (MessageBox.Show("是否確定刪除 【" + trademarkManagementTDataGridView.CurrentRow.Cells["TrademarkNo"].Value.ToString() + "】", "確認視窗", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                            {
                                Public.DLL dll = new LawtechPTSystemByFirm.Public.DLL();
                                //刪除商標案相關文件包含委辦、來函、費用的實體檔案
                                string delFileDir = string.Format(@"{0}\{1}", dll.TrademarkControversyFolderRoot, trademarkManagementTDataGridView.CurrentRow.Cells["TrademarkID"].Value.ToString());
                                if (Directory.Exists(delFileDir))
                                {
                                    Directory.Delete(delFileDir, true);
                                }

                                int iKey = (int)trademarkManagementTDataGridView.CurrentRow.Cells["TrademarkID"].Value;
                                Public.CTrademarkControversyManagement TMdel = new Public.CTrademarkControversyManagement();
                                Public.CTrademarkControversyManagement.ReadOne(iKey, ref TMdel);
                               

                                //刪除記錄檔    
                                Public.CSystemLog log = new LawtechPTSystemByFirm.Public.CSystemLog();
                                log.DelTime = DateTime.Now;
                                log.DelWorkerKey = Properties.Settings.Default.WorkerKEY;
                                //string[] str = TMdel.GetInsertString(iKey);
                                //log.TableName = str[2];
                                //log.DelContent_InsertColumn = str[0];
                                //log.DelContent_InsertSQL = str[1];
                                log.DelContent = string.Format("本所案號:{0}\r\n商標名稱:{1}\r\n申請人:{2}\r\n商標樣式:{3}\r\n案件類別:{4}\r\n申請案號:{5}\r\n異議申請號:{6}", TMdel.TrademarkNo, TMdel.TrademarkName, TMdel.ApplicantNames, TMdel.StyleName, TMdel.TMTypeName, TMdel.ApplicationNo, TMdel.DisagreementNo);
                                log.DelTitle = string.Format("刪除商標異議案基本資料【{0}】", TMdel.TrademarkNo);
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
                                Worker_Model.ReadOne(iLocker, ref  worker);
                                
                                MessageBox.Show("很抱歉~~   目前該筆資料正被【" + worker.EmployeeName + "】使用中，請等候!!\r\n 謝謝", "提示訊息");
                            }
                        }
                    }
                    break;
                case "ImportExcelToolStripMenuItem":
                    try
                    {
                        Public.DLL dll = new LawtechPTSystemByFirm.Public.DLL();
                        Task task = dll.WriteToCSV(trademarkManagementTDataGridView);
                    }
                    catch
                    {
                        MessageBox.Show("匯出Excel失敗");
                    }

                    break;
                case "ToolStripMenuItem_Proposal":
                    if (trademarkManagementTDataGridView.SelectedRows.Count > 0)
                    {
                        US.OvertrueName overture = new LawtechPTSystemByFirm.US.OvertrueName();
                        overture.TypeMode = 3;
                        overture.GV = trademarkManagementTDataGridView;
                        //overture.Dt = this.dataSet_TM.TrademarkManagementT;
                        overture.ShowDialog();
                    }
                    break;

                case "UploadFileToolStripMenuItem":
                    if (trademarkManagementTDataGridView.CurrentRow != null)
                    {
                        //US.UpdataFile upfile2 = new US.UpdataFile();
                        US.UpFileList upfile2 = new US.UpFileList();
                        upfile2.Text = "上傳商標異議案(" + trademarkManagementTDataGridView.CurrentRow.Cells["TrademarkNo"].Value.ToString() + ")相關文件";
                        upfile2.MainFileKey = (int)trademarkManagementTDataGridView.CurrentRow.Cells["TrademarkID"].Value;
                        upfile2.UploadMode = 5;
                        upfile2.MainFileType = 10;
                        upfile2.ShowDialog();
                    }
                    break;


                case "OpenFileListToolStripMenuItem":
                    if (trademarkManagementTDataGridView.CurrentRow != null)
                    {
                        ViewUpdateFileList subForm = new ViewUpdateFileList();
                        subForm.Text = trademarkManagementTDataGridView.CurrentRow.Cells["TrademarkNo"].Value.ToString() + "的相關文件";
                        subForm.FileKind = 5;
                        subForm.FileType = 10;
                        subForm.MainParentID = (int)trademarkManagementTDataGridView.CurrentRow.Cells["TrademarkID"].Value;
                        subForm.vb_TM.Checked = true;
                        subForm.ShowDialog();
                    }
                    break;
                case "EdittoolStripMenuItem":
                case "toolStripButton_EditTM":
                    if (trademarkManagementTDataGridView.CurrentRow != null)
                    {
                        int iLocker = Public.Utility.GetRecordAuth("TrademarkControversyManagementT", "TrademarkControversyID=" + property_TrademarkID.ToString());

                        if (iLocker == -1 || iLocker == iWorkerID)
                        {
                            if (iLocker != iWorkerID)
                            {
                                Public.Utility.LockRecordAuth("TrademarkControversyManagementT", iWorkerID, "TrademarkControversyID=" + property_TrademarkID.ToString());
                            }

                            EditForm.CopyTrademarkControversy Edit = new LawtechPTSystemByFirm.EditForm.CopyTrademarkControversy();
                            Edit.TrademarkControversyID = (int)trademarkManagementTDataGridView.CurrentRow.Cells["TrademarkID"].Value;
                            Edit.ShowDialog();
                        }
                        else
                        {
                            if (iLocker != -1)//無人使用中
                            {
                                Worker_Model worker = new Worker_Model();
                                Worker_Model.ReadOne(iLocker, ref  worker);
                                MessageBox.Show("很抱歉~~   目前該筆資料正被【" + worker.EmployeeName + "】使用中，請等候!!\r\n 謝謝", "提示訊息");
                            }
                        }
                    }
                    break;

                case "toolStripMenuItem_CompleteHistory":
                    if (trademarkManagementTDataGridView.SelectedRows.Count > 0)
                    {
                        ViewFrom.TrademarkCompleteHistory history = new LawtechPTSystemByFirm.ViewFrom.TrademarkCompleteHistory();
                        history.Gv = trademarkManagementTDataGridView;
                        history.Show();
                    }
                    else
                    { 
                   
                    }
                    break;

                case "toolStripMenuItem_SendMail":
                    if (trademarkManagementTDataGridView.CurrentRow != null)
                    {
                        US.NotificationLetter letter = new LawtechPTSystemByFirm.US.NotificationLetter();
                        letter.ApplicantKeys = trademarkManagementTDataGridView.CurrentRow.Cells["ApplicantKeys"].Value.ToString() ;
                        letter.CaseKey = trademarkManagementTDataGridView.CurrentRow.Cells["TrademarkID"].Value != null ? (int)trademarkManagementTDataGridView.CurrentRow.Cells["TrademarkID"].Value : -1;
                        letter.DelegateType = trademarkManagementTDataGridView.CurrentRow.Cells["DelegateType"].Value.ToString() != "" ? (int)trademarkManagementTDataGridView.CurrentRow.Cells["DelegateType"].Value : -1;
                        letter.Attorney = trademarkManagementTDataGridView.CurrentRow.Cells["OutsourcingAttorney"].Value.ToString() != "" ? (int)trademarkManagementTDataGridView.CurrentRow.Cells["OutsourcingAttorney"].Value : -1;
                        letter.EmailSampleType = "Trademark";
                        letter.CaseNo = trademarkManagementTDataGridView.CurrentRow.Cells["TrademarkNo"].Value.ToString();
                        letter.ShowDialog();
                    }
                    break;

                case "toolStripMenuItem_Copy":
                    if (trademarkManagementTDataGridView.CurrentRow != null)
                    {
                        CopyForm.CopyTrademarkControversyBy copy = new LawtechPTSystemByFirm.CopyForm.CopyTrademarkControversyBy();
                        copy.TrademarkControversyID = (int)trademarkManagementTDataGridView.CurrentRow.Cells["TrademarkID"].Value;
                        copy.ShowDialog();
                    }
                    break;
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

                    US.CalculationDate Calculation = new LawtechPTSystemByFirm.US.CalculationDate();
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

        #region maskedTextBox_ApplicationDate_DoubleClick
        private void maskedTextBox_ApplicationDate_DoubleClick(object sender, EventArgs e)
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

        #region trademarkManagementTDataGridView_CellDoubleClick
        private void trademarkManagementTDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            contextMenuStrip_Trademark_ItemClicked(contextMenuStrip_Trademark, new ToolStripItemClickedEventArgs(EdittoolStripMenuItem));
        }
        #endregion

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
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

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (trademarkManagementTDataGridView.CurrentRow != null && trademarkManagementTDataGridView.CurrentRow.Cells["ObjectionPicPath"].Value != DBNull.Value && trademarkManagementTDataGridView.CurrentRow.Cells["PicPath"].Value.ToString().Trim() != "")
            {
                try
                {
                    string sPath = property_TMrootPath + "\\" + trademarkManagementTDataGridView.CurrentRow.Cells["ObjectionPicPath"].Value.ToString(); ;
                    Public.Utility.ProcessStart(sPath);
                }
                catch (System.Exception EX)
                {
                    MessageBox.Show(EX.Message, "提示訊息", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #region contextMenuStrip_Event1_ItemClicked 案件記錄快顯
        private void contextMenuStrip_Event1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            contextMenuStrip_Event1.Visible = false;

            switch (e.ClickedItem.Name)
            {
                case "bindingNavigatorAddNewItem_Notify":
                case "新增來函ToolStripMenuItem":
                    if (trademarkManagementTDataGridView.CurrentRow != null)
                    {
                        AddFrom.AddTrademarkControversyNotifyEvent add = new AddFrom.AddTrademarkControversyNotifyEvent();
                        add.Text += "(" + property_TrademarkNo + ")";
                        add.TrademarkControversyID = (int)trademarkManagementTDataGridView.CurrentRow.Cells["TrademarkID"].Value;
                        add.CountrySymbol = trademarkManagementTDataGridView.CurrentRow.Cells["CountrySymbol"].Value.ToString();
                        add.ShowDialog();
                    }
                    break;

                case "bindingNavigatorDeleteItem_Notify":
                case "刪除來函ToolStripMenuItem":
                    if (TMNotifyEventTDataGridView.CurrentRow != null)
                    {
                        string sName = TMNotifyEventTDataGridView.CurrentRow.Cells["NotifyEventContent"].Value.ToString();

                        if (MessageBox.Show("是否確定刪除【" + sName + "】", "確認視窗", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            int iKey = (int)TMNotifyEventTDataGridView.CurrentRow.Cells["TMNotifyControversyEventID"].Value;
                            Public.CTrademarkControversyNotifyEvent TMdel = new Public.CTrademarkControversyNotifyEvent("TMNotifyControversyEventID=" + iKey.ToString());
                            TMdel.SetCurrent(iKey);

                            Public.CTrademarkControversyNotifyEventToFee NotifyEventToFee = new LawtechPTSystemByFirm.Public.CTrademarkControversyNotifyEventToFee("1=0");
                            NotifyEventToFee.Delete("TMNotifyControversyEventID=" + iKey.ToString());

                            Public.CTrademarkControversyNotifyEventToPayment NotifyEventToPayment = new LawtechPTSystemByFirm.Public.CTrademarkControversyNotifyEventToPayment("1=0");
                            NotifyEventToPayment.Delete("TMNotifyControversyEventID=" + iKey.ToString());

                            //刪除記錄檔    
                            Public.CSystemLog log = new LawtechPTSystemByFirm.Public.CSystemLog();
                            log.DelTime = DateTime.Now;
                            log.DelWorkerKey = Properties.Settings.Default.WorkerKEY;
                            string[] str = TMdel.GetInsertString(iKey);
                            log.TableName = str[2];
                            log.DelContent_InsertColumn = str[0];
                            log.DelContent_InsertSQL = str[1];
                            log.DelContent = string.Format("事件內容:{0}\r\n本所來函日:{1}\r\n官方期限:{2}\r\n本所期限:{3}\r\n完成日期:{4}", TMdel.NotifyEventContent, TMdel.NotifyComitDate, TMdel.DueDate, TMdel.AttorneyDueDate, TMdel.FinishDate);
                            log.DelTitle = string.Format("刪除商標異議案件記錄資料【{0}】", TMdel.NotifyEventContent);
                            log.Create();

                            TMdel.Delete(iKey);
                            TMNotifyEventTDataGridView.Rows.Remove(TMNotifyEventTDataGridView.CurrentRow);

                            MessageBox.Show("刪除成功", "提示訊息");
                        }
                    }
                    break;

                case "上傳來函相關文件ToolStripMenuItem":
                    if (TMNotifyEventTDataGridView.CurrentRow != null)
                    {
                        //US.UpdataFile upfile2 = new US.UpdataFile();
                        US.UpFileList upfile2 = new US.UpFileList();
                        upfile2.Text = "上傳商標(" + trademarkManagementTDataGridView.CurrentRow.Cells["TrademarkNo"].Value.ToString() + ")相關文件";
                        upfile2.MainFileKey = (int)trademarkManagementTDataGridView.CurrentRow.Cells["TrademarkID"].Value;
                        upfile2.UploadMode = 5;
                        upfile2.MainFileType = 11;
                        upfile2.ChildFileKey = (int)TMNotifyEventTDataGridView.CurrentRow.Cells["TMNotifyControversyEventID"].Value;
                        upfile2.ShowDialog();
                    }
                    break;

                case "開啟來函相關文件ToolStripMenuItem":
                    if (TMNotifyEventTDataGridView.CurrentRow != null)
                    {
                        ViewUpdateFileList subForm = new ViewUpdateFileList();
                        subForm.Text = trademarkManagementTDataGridView.CurrentRow.Cells["TrademarkNo"].Value.ToString() + "的相關文件";
                        subForm.FileKind = 5;
                        subForm.FileType = 11;
                        subForm.MainParentID = (int)trademarkManagementTDataGridView.CurrentRow.Cells["TrademarkID"].Value;
                        subForm.vb_TMNotify.Checked = true;
                        subForm.ShowDialog();
                    }
                    break;

                case "EditNotifytoolStripMenuItem":
                case "toolStripButtonEidtItem_Notify":
                    if (TMNotifyEventTDataGridView.CurrentRow != null)
                    {
                        int iLocker = Public.Utility.GetRecordAuth("TrademarkControversyNotifyEventT", "TMNotifyControversyEventID=" + TMNotifyEventTDataGridView.CurrentRow.Cells["TMNotifyControversyEventID"].Value.ToString());
                        if (iLocker == -1 || iLocker == iWorkerID)
                        {
                            if (iLocker != iWorkerID)
                            {
                                Public.Utility.LockRecordAuth("TrademarkControversyNotifyEventT", iWorkerID, "TMNotifyControversyEventID=" + TMNotifyEventTDataGridView.CurrentRow.Cells["TMNotifyControversyEventID"].Value.ToString());
                            }
                            EditForm.EditTrademarkControversyNotifyEvent Edit = new LawtechPTSystemByFirm.EditForm.EditTrademarkControversyNotifyEvent();
                            Edit.Text += "(" + property_TrademarkNo + ")";
                            Edit.property_TMNotifyEventID = (int)TMNotifyEventTDataGridView.CurrentRow.Cells["TMNotifyControversyEventID"].Value;
                            //Edit.CountrySymbol = trademarkManagementTDataGridView.CurrentRow.Cells["Country"].Value.ToString();
                            Edit.ShowDialog();
                        }
                        else
                        {
                            if (iLocker != -1)//無人使用中
                            {
                                Worker_Model worker = new Worker_Model();
                                Worker_Model.ReadOne(iLocker, ref  worker);
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
                        fee.SourceID = (int)TMNotifyEventTDataGridView.CurrentRow.Cells["TMNotifyControversyEventID"].Value;
                        fee.FeeSubject =" 案件記錄轉至請款--" + TMNotifyEventTDataGridView.CurrentRow.Cells["NotifyEventContent"].Value.ToString();
                        fee.Text = fee.Text + "--" + trademarkManagementTDataGridView.CurrentRow.Cells["TrademarkNo"].Value.ToString();
                        fee.ShowDialog();
                    }
                    break;
                case "toolStripMenuItem_ToPayment":
                    if (TMNotifyEventTDataGridView.CurrentRow != null)
                    {
                        AddFrom.AddTrademarkPayment Payment = new AddFrom.AddTrademarkPayment();
                        Payment.TrademarkID = (int)trademarkManagementTDataGridView.CurrentRow.Cells["TrademarkID"].Value;
                        Payment.SourceID = (int)TMNotifyEventTDataGridView.CurrentRow.Cells["TMNotifyControversyEventID"].Value;
                        Payment.FeeSubject = " 案件記錄轉至付款--" + TMNotifyEventTDataGridView.CurrentRow.Cells["NotifyEventContent"].Value.ToString();
                        Payment.Text = Payment.Text + "--" + trademarkManagementTDataGridView.CurrentRow.Cells["TrademarkNo"].Value.ToString();
                        Payment.ShowDialog();
                    }
                    break;
                case "toolStripMenuItem_CopyEvent":
                    if (TMNotifyEventTDataGridView.CurrentRow != null)
                    {
                        CopyForm.CopyTrademarkControversyEvent copy = new LawtechPTSystemByFirm.CopyForm.CopyTrademarkControversyEvent();
                        copy.TrademarkControversyID = (int)trademarkManagementTDataGridView.CurrentRow.Cells["TrademarkID"].Value;
                        copy.property_TMNotifyEventID = (int)TMNotifyEventTDataGridView.CurrentRow.Cells["TMNotifyControversyEventID"].Value;
                        copy.ShowDialog();
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
                            sb.Append(TMNotifyEventTDataGridView.SelectedRows[iRows].Cells["TMNotifyControversyEventID"].Value.ToString());
                        }

                        MultipleKeyByCopy = sb.ToString();
                        MessageBox.Show("成功複製了 " + TMNotifyEventTDataGridView.SelectedRows.Count.ToString() + "筆 事件記錄");
                    }
                    else
                    {
                        if (TMNotifyEventTDataGridView.CurrentRow != null)
                        {
                            MultipleKeyByCopy = TMNotifyEventTDataGridView.CurrentRow.Cells["TMNotifyControversyEventID"].Value.ToString();
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
                                Public.CTrademarkControversyNotifyEvent copyMulti = new LawtechPTSystemByFirm.Public.CTrademarkControversyNotifyEvent("TMNotifyControversyEventID in(" + MultipleKeyByCopy + ")");
                                for (int iRow = 0; iRow < Keys.Length; iRow++)
                                {
                                    copyMulti.SetCurrent(int.Parse(Keys[iRow]));
                                    copyMulti.TrademarkControversyID = property_TrademarkID;
                                    copyMulti.LastModifyDate = DateTime.Now;
                                    copyMulti.LastModifyWorker = Properties.Settings.Default.WorkerKEY;
                                    copyMulti.UpbuildDay = DateTime.Now;

                                    copyMulti.Insert();
                                }

                                RefrashDataTable(1);
                                trademarkControversyNotifyEventTBindingSource.MoveLast();
                            }
                        }
                    }

                    break;
            }

        }
        #endregion       

        #region trademarkManagementTDataGridView_SelectionChanged
        private void trademarkManagementTDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (trademarkManagementTDataGridView.CurrentRow != null)
            {


                //來函
                this.trademarkControversyNotifyEventTTableAdapter.Fill(this.dataSet_TrademarkControversy.TrademarkControversyNotifyEventT, property_TrademarkID);

                //請款記錄
                this.trademarkControversyFeeTTableAdapter.Fill(this.dataSet_TrademarkControversy.TrademarkControversyFeeT, property_TrademarkID);

                //付款記錄
                this.trademarkControversyPaymentTTableAdapter.Fill(this.dataSet_TrademarkControversy.TrademarkControversyPaymentT, property_TrademarkID);

                //預估成本
                this.trademarkControveryEstimateCostTTableAdapter.Fill(this.dataSet_TrademarkControversy.TrademarkControveryEstimateCostT, property_TrademarkID);

            }
            else
            {
                this.dataSet_TrademarkControversy.TrademarkControversyNotifyEventT.Rows.Clear();
                this.dataSet_TrademarkControversy.TrademarkControversyFeeT.Rows.Clear();
                this.dataSet_TrademarkControversy.TrademarkControversyPaymentT.Rows.Clear();
                this.dataSet_TrademarkControversy.TrademarkControveryEstimateCostT.Rows.Clear();
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
                        AddFrom.AddTrademarkControversyEstimateCost fee = new AddFrom.AddTrademarkControversyEstimateCost();
                        fee.TrademarkControversyID = (int)trademarkManagementTDataGridView.CurrentRow.Cells["TrademarkID"].Value;
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

                        if (MessageBox.Show("是否確定刪除", "確認視窗", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            int iTMEstimateCostID = (int)dataGridView_EstimateCost.CurrentRow.Cells["TMControveryEstimateCostID"].Value;
                            Public.CTrademarkControveryEstimateCost DelEstimateCost = new Public.CTrademarkControveryEstimateCost("TMControveryEstimateCostID=" + iTMEstimateCostID.ToString());
                            DelEstimateCost.SetCurrent(iTMEstimateCostID);

                            //刪除記錄檔    
                            Public.CSystemLog log = new LawtechPTSystemByFirm.Public.CSystemLog();
                            log.DelTime = DateTime.Now;
                            log.DelWorkerKey = Properties.Settings.Default.WorkerKEY;
                            string[] str = DelEstimateCost.GetInsertString(iTMEstimateCostID);
                            log.TableName = str[2];
                            log.DelContent_InsertColumn = str[0];
                            log.DelContent_InsertSQL = str[1];
                            log.DelContent = string.Format("費用內容:{0}\r\n預估成本:{1}\r\n預估利潤:{2}\r\n實際報價:{3}", DelEstimateCost.FeeSubject, DelEstimateCost.EstimateCost.ToString("#,##0.##"), DelEstimateCost.EstimateProfit.ToString("#,##0.##"), DelEstimateCost.RealPrice.ToString("#,##0.##"));
                            log.DelTitle = string.Format("刪除商標異議案預估費用記錄資料【{0}】", DelEstimateCost.FeeSubject);
                            log.Create();

                            DelEstimateCost.Delete(iTMEstimateCostID);

                            dataGridView_EstimateCost.Rows.Remove(dataGridView_EstimateCost.CurrentRow);
                            this.dataSet_TrademarkControversy.TrademarkControveryEstimateCostT.AcceptChanges();
                            MessageBox.Show("刪除預估成本記錄成功", "提示訊息", MessageBoxButtons.OK);
                        }
                    }

                    break;
                case "toolStripMenuItem_Edit_ES":
                case "toolStripButton_ES_Edit":
                    if (dataGridView_EstimateCost.CurrentRow != null)
                    {
                        int iLocker = Public.Utility.GetRecordAuth("TrademarkControveryEstimateCostT", "TMControveryEstimateCostID=" + dataGridView_EstimateCost.CurrentRow.Cells["TMControveryEstimateCostID"].Value.ToString());
                        if (iLocker == -1 || iLocker == iWorkerID)
                        {
                            if (iLocker != iWorkerID)
                            {
                                Public.Utility.LockRecordAuth("TrademarkControveryEstimateCostT", iWorkerID, "TMControveryEstimateCostID=" + dataGridView_EstimateCost.CurrentRow.Cells["TMControveryEstimateCostID"].Value.ToString());
                            }
                            EditForm.EditTrademarkControversyEstimateCost edit = new LawtechPTSystemByFirm.EditForm.EditTrademarkControversyEstimateCost();
                            edit.TMControveryEstimateCostID = (int)dataGridView_EstimateCost.CurrentRow.Cells["TMControveryEstimateCostID"].Value;
                            edit.ShowDialog();
                        }
                        else
                        {
                            if (iLocker != -1)//無人使用中
                            {
                                Worker_Model worker = new Worker_Model();
                                Worker_Model.ReadOne(iLocker, ref  worker);
                                MessageBox.Show("很抱歉~~   目前該筆資料正被【" + worker.EmployeeName + "】使用中，請等候!!\r\n 謝謝", "提示訊息");
                            }
                        }
                    }
                    break;
            }
        }
        #endregion        

        #region ============請款費用記錄快顯============
        private void contextMenuStrip_Fee_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            contextMenuStrip_Fee.Visible = false;

            switch (e.ClickedItem.Name)
            {
                case "bindingNavigatorAddNewItem_Fee":
                case "toolStripMenuItem_BillingAdd":  //請款新增費用

                    if (trademarkManagementTDataGridView.CurrentRow!=null)
                    {
                        AddFrom.AddTrademarkControversyFee fee = new AddFrom.AddTrademarkControversyFee();
                        fee.TrademarkControversyID = (int)trademarkManagementTDataGridView.CurrentRow.Cells["TrademarkID"].Value;
                        fee.Text = fee.Text + "--" + trademarkManagementTDataGridView.CurrentRow.Cells["TrademarkNo"].Value.ToString();
                        fee.CountrySymbol = trademarkManagementTDataGridView.CurrentRow.Cells["CountrySymbol"].Value.ToString();
                        fee.ShowDialog();
                    }
                  

                    break;
                case "bindingNavigatorDeleteItem_Fee":
                case "toolStripMenuItem_BillingDel":  //刪除請款費用

                    if (GridView_Fee.CurrentRow != null)
                    {
                        if (GridView_Fee.CurrentRow.Cells["PPP"].Value.ToString() != "")
                        {
                            MessageBox.Show("已登錄了請款單號，若要刪除，請洽帳務人員", "提示訊息", MessageBoxButtons.OK);
                            return;
                        }


                        if ((bool)GridView_Fee.CurrentRow.Cells["IsClosing"].Value)
                        {
                            MessageBox.Show("該筆請款單號【" + GridView_Fee.CurrentRow.Cells["PPP"].Value.ToString() + "】已被關帳，請洽帳務主管", "提示訊息", MessageBoxButtons.OK);
                            return;
                        }

                        string sName = GridView_Fee.CurrentRow.Cells["FeeSubjectControversy"].Value.ToString();

                        if (MessageBox.Show("是否確定刪除【" + sName + "】", "確認視窗", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            int iFeeKey = (int)GridView_Fee.CurrentRow.Cells["ControversyFeeKEY"].Value;
                            Public.CTrademarkControversyFee DelFee = new Public.CTrademarkControversyFee("ControversyFeeKEY=" + iFeeKey.ToString());
                            DelFee.SetCurrent(iFeeKey);


                            //刪除記錄檔    
                            Public.CSystemLog log = new LawtechPTSystemByFirm.Public.CSystemLog();
                            log.DelTime = DateTime.Now;
                            log.DelWorkerKey = Properties.Settings.Default.WorkerKEY;
                            string[] str = DelFee.GetInsertString(iFeeKey);
                            log.TableName = str[2];
                            log.DelContent_InsertColumn = str[0];
                            log.DelContent_InsertSQL = str[1];
                            log.DelContent = string.Format("費用內容:{0}\r\n請款日期:{1}\r\n請款合計:{2}\r\n幣別:{3}\r\n請款單號:{4}", DelFee.FeeSubject, DelFee.RDate, DelFee.Totall, DelFee.TMoney, DelFee.PPP);
                            log.DelTitle = string.Format("刪除商標異議案請款記錄資料【{0}】", DelFee.FeeSubject);
                            log.Create();


                            DelFee.Delete(iFeeKey);
                            GridView_Fee.Rows.Remove(GridView_Fee.CurrentRow);
                            this.dataSet_TrademarkControversy.TrademarkControversyFeeT.AcceptChanges();
                            MessageBox.Show("刪除請款費用記錄成功", "提示訊息", MessageBoxButtons.OK);
                        }
                    }

                    break;
                case "上傳費用相關文件ToolStripMenuItem":  //上傳請款費用相關文件

                    if (GridView_Fee.CurrentRow != null)
                    {
                        US.UpFileList upfile = new US.UpFileList();
                        upfile.Text = trademarkManagementTDataGridView.CurrentRow.Cells["TrademarkNo"].Value.ToString() + "  上傳請款費用相關文件";
                        upfile.UploadMode = 5;
                        upfile.MainFileKey = property_TrademarkID;
                        upfile.ChildFileKey = (int)GridView_Fee.CurrentRow.Cells["ControversyFeeKEY"].Value;
                        upfile.MainFileType = 12;
                        upfile.ShowDialog();

                    }

                    break;

                case "印請款單ToolStripMenuItem":  //印請款單
                    if (GridView_Fee.CurrentRow != null)
                    {

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
                        subForm.Text = trademarkManagementTDataGridView.CurrentRow.Cells["TrademarkNo"].Value.ToString() + "的請款費用相關文件";
                        subForm.FileKind = 5;
                        subForm.FileType = 12;
                        subForm.MainParentID = (int)trademarkManagementTDataGridView.CurrentRow.Cells["TrademarkID"].Value;
                        subForm.Child_ID = (int)GridView_Fee.CurrentRow.Cells["ControversyFeeKEY"].Value;
                        subForm.ShowDialog();
                    }
                    break;
                case "toolStripMenuItem_BillingEdit":
                case "bindingNavigatorEditItem_Fee"://修改請款費用
                    if (GridView_Fee.CurrentRow != null)
                    {
                        if (GridView_Fee.CurrentRow.Cells["PPP"].Value.ToString() != "")
                        {
                            MessageBox.Show("已登錄了請款單號，若要刪除，請洽帳務人員", "提示訊息", MessageBoxButtons.OK);
                            return;
                        }


                        if ((bool)GridView_Fee.CurrentRow.Cells["IsClosing"].Value)
                        {
                            MessageBox.Show("該筆請款單號【" + GridView_Fee.CurrentRow.Cells["PPP"].Value.ToString() + "】已被關帳，請洽帳務主管", "提示訊息", MessageBoxButtons.OK);
                            return;
                        }


                        int iLocker = Public.Utility.GetRecordAuth("TrademarkControversyFeeT", "ControversyFeeKEY=" + GridView_Fee.CurrentRow.Cells["ControversyFeeKEY"].Value.ToString());
                        if (iLocker == -1 || iLocker == iWorkerID)
                        {
                            if (iLocker != iWorkerID)
                            {
                                Public.Utility.LockRecordAuth("TrademarkControversyFeeT", iWorkerID, "ControversyFeeKEY=" + GridView_Fee.CurrentRow.Cells["ControversyFeeKEY"].Value.ToString());
                            }
                            EditForm.EditTrademarkControversyFee edit = new LawtechPTSystemByFirm.EditForm.EditTrademarkControversyFee();
                            edit.property_FeeKEY = (int)GridView_Fee.CurrentRow.Cells["ControversyFeeKEY"].Value;
                            edit.CountrySymbol = trademarkManagementTDataGridView.CurrentRow.Cells["CountrySymbol"].Value.ToString();
                            edit.ShowDialog();
                            
                        }
                        else
                        {
                            if (iLocker != -1)//無人使用中
                            {
                                Worker_Model worker = new Worker_Model();
                                Worker_Model.ReadOne(iLocker, ref  worker);
                                MessageBox.Show("很抱歉~~   目前該筆資料正被【" + worker.EmployeeName + "】使用中，請等候!!\r\n 謝謝", "提示訊息");
                            }
                        }
                    }
                    break;
            }


        }
        #endregion

        #region ============付款費用記錄快顯============
        private void contextMenuStrip_Billing_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            contextMenuStrip_Billing.Visible = false;

            switch (e.ClickedItem.Name)
            {
                case "bindingNavigatorAddNewItem_Payment":
                case "toolStripMenuItem_PaymentAdd":  //付款新增費用

                    if (trademarkManagementTDataGridView.CurrentRow != null)
                    {
                        AddFrom.AddTrademarkControversyPayment Payment = new AddFrom.AddTrademarkControversyPayment();
                        Payment.TrademarkControversyID = (int)trademarkManagementTDataGridView.CurrentRow.Cells["TrademarkID"].Value;
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

                case "bindingNavigatorDeleteItem_Payment":
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

                        if (MessageBox.Show("是否確定刪除", "確認視窗", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            int iPaymentIDK = (int)dataGridView_Billing.CurrentRow.Cells["ControversyPaymentID"].Value;
                            Public.CTrademarkControversyPayment DelBilling = new Public.CTrademarkControversyPayment("ControversyPaymentID=" + iPaymentIDK.ToString());
                            DelBilling.SetCurrent(iPaymentIDK);


                            //刪除記錄檔    
                            Public.CSystemLog log = new LawtechPTSystemByFirm.Public.CSystemLog();
                            log.DelTime = DateTime.Now;
                            log.DelWorkerKey = Properties.Settings.Default.WorkerKEY;
                            string[] str = DelBilling.GetInsertString(iPaymentIDK);
                            log.TableName = str[2];
                            log.DelContent_InsertColumn = str[0];
                            log.DelContent_InsertSQL = str[1];
                            log.DelContent = string.Format("費用內容:{0}\r\n收件日期:{1}\r\n付款期限:{2}\r\n付款日期:{3}\r\n實付金額:{4}\r\n幣別:{5}", DelBilling.FeeSubject, DelBilling.ReciveDate, DelBilling.PayDueDate, DelBilling.PaymentDate, DelBilling.ActuallyPay, DelBilling.IMoney);
                            log.DelTitle = string.Format("刪除商標異議案付款記錄資料【{0}】", DelBilling.FeeSubject);
                            log.Create();


                            DelBilling.Delete(iPaymentIDK);
                            dataGridView_Billing.Rows.Remove(dataGridView_Billing.CurrentRow);
                            this.dataSet_TrademarkControversy.TrademarkControversyPaymentT.AcceptChanges();
                            MessageBox.Show("刪除付款費用記錄成功", "提示訊息", MessageBoxButtons.OK);
                        }
                    }

                    break;
                case "toolStripMenuItem_PaymentUpdateFile":  //上傳付款費用相關文件

                    if (dataGridView_Billing.CurrentRow != null)
                    {
                        US.UpFileList upfile = new US.UpFileList();
                        upfile.Text = trademarkManagementTDataGridView.CurrentRow.Cells["TrademarkNo"].Value.ToString() + "  上傳付款費用相關文件";
                        upfile.UploadMode = 5;
                        upfile.MainFileKey = property_TrademarkID;
                        upfile.ChildFileKey = (int)dataGridView_Billing.CurrentRow.Cells["ControversyPaymentID"].Value;
                        upfile.MainFileType = 13;
                        upfile.ShowDialog();

                    }

                    break;


                case "付款証明單ToolStripMenuItem":
                    if (dataGridView_Billing.CurrentRow != null)
                    {
                        ReportView.PaymentReport payment = new LawtechPTSystemByFirm.ReportView.PaymentReport();

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
                        payment.CostDept = trademarkManagementTDataGridView.CurrentRow.Cells["CountryName"].Value.ToString();
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
                        ViewUpdateFileList subForm = new ViewUpdateFileList();
                        subForm.Text = trademarkManagementTDataGridView.CurrentRow.Cells["TrademarkNo"].Value.ToString() + "的付款費用相關文件";
                        subForm.FileKind = 5;
                        subForm.FileType = 13;
                        subForm.MainParentID = (int)trademarkManagementTDataGridView.CurrentRow.Cells["TrademarkID"].Value;
                        subForm.Child_ID = (int)dataGridView_Billing.CurrentRow.Cells["ControversyPaymentID"].Value;
                        subForm.ShowDialog();
                    }
                    break;
                case "toolStripMenuItem_PaymentEdit":
                case "bindingNavigatorEditItem_Payment":
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

                        int iLocker = Public.Utility.GetRecordAuth("TrademarkControversyPaymentT", "ControversyPaymentID=" + dataGridView_Billing.CurrentRow.Cells["ControversyPaymentID"].Value.ToString());
                        if (iLocker == -1 || iLocker == iWorkerID)
                        {
                            if (iLocker != iWorkerID)
                            {
                                Public.Utility.LockRecordAuth("TrademarkControversyPaymentT", iWorkerID, "ControversyPaymentID=" + dataGridView_Billing.CurrentRow.Cells["PaymentID"].Value.ToString());
                            }
                            EditForm.EditTrademarkControversyPayment edit = new LawtechPTSystemByFirm.EditForm.EditTrademarkControversyPayment();
                            edit.CountrySymbol = trademarkManagementTDataGridView.CurrentRow.Cells["CountrySymbol"].Value.ToString();
                            edit.property_PaymentID = (int)dataGridView_Billing.CurrentRow.Cells["ControversyPaymentID"].Value;
                            edit.ShowDialog();
                        }
                        else
                        {
                            if (iLocker != -1)//無人使用中
                            {
                                Worker_Model worker = new Worker_Model();
                                Worker_Model.ReadOne(iLocker, ref  worker);
                                MessageBox.Show("很抱歉~~   目前該筆資料正被【" + worker.EmployeeName + "】使用中，請等候!!\r\n 謝謝", "提示訊息");
                            }
                        }
                    }
                    break;

            }
        }
        #endregion

        #region dataGridView_Billing_CellDoubleClick
        private void dataGridView_Billing_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != -1 && e.RowIndex != -1)
            {
                contextMenuStrip_Billing_ItemClicked(contextMenuStrip_Billing, new ToolStripItemClickedEventArgs(toolStripMenuItem_PaymentEdit));
            }
        }
#endregion

        #region dataGridView_EstimateCost_CellDoubleClick
        private void dataGridView_EstimateCost_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != -1 && e.RowIndex != -1)
            {
                contextMenuStrip_EstimateCost_ItemClicked(contextMenuStrip_EstimateCost, new ToolStripItemClickedEventArgs(toolStripMenuItem_Edit_ES));
            }
        }
        #endregion

        #region GridView_Fee_CellDoubleClick
        private void GridView_Fee_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != -1 && e.RowIndex != -1)
            {
                contextMenuStrip_Fee_ItemClicked(contextMenuStrip_Fee, new ToolStripItemClickedEventArgs(toolStripMenuItem_BillingEdit));
            }
        }
        #endregion

        #region TMNotifyEventTDataGridView_CellDoubleClick
        private void TMNotifyEventTDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != -1 && e.RowIndex != -1)
            {
                contextMenuStrip_Event1_ItemClicked(contextMenuStrip_Event1, new ToolStripItemClickedEventArgs(EditNotifytoolStripMenuItem));
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

        #region TrademarkControversyMF_KeyDown
        private void TrademarkControversyMF_KeyDown(object sender, KeyEventArgs e)
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

        #region linkLabel_ObjectionContent_LinkClicked
        private void linkLabel_ObjectionContent_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LinkLabel link = (LinkLabel)sender;
            US.PopMemo pop;
            switch (link.Name)
            {
                case "linkLabel_ObjectionContent":
                    pop = new LawtechPTSystemByFirm.US.PopMemo(txt_ObjectionContent, true, link.Text);
                    break;
                case "linkLabel_mome":
                    pop = new LawtechPTSystemByFirm.US.PopMemo(txt_Remarks, true, link.Text);
                    break;
                case "linkLabel_NotifyResult":
                    pop = new LawtechPTSystemByFirm.US.PopMemo(txt_NotifyResult, true, link.Text);
                    break;
                case "linkLabel_ComintRemark":
                    pop = new LawtechPTSystemByFirm.US.PopMemo(txt_NotifyRemark, true, link.Text);
                    break;
                case "linkLabel_ES_PayMemo":
                    pop = new LawtechPTSystemByFirm.US.PopMemo(txt_ES_PayMemo, true, link.Text);
                    break;
                case "linkLabel_ES_Remark":
                    pop = new LawtechPTSystemByFirm.US.PopMemo(txt_ES_Remark, true, link.Text);
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
                case "linkLabel_Memo":
                    pop = new LawtechPTSystemByFirm.US.PopMemo(txt_Memo, true, link.Text);
                    break;
                default:
                    pop = new LawtechPTSystemByFirm.US.PopMemo(txt_Remarks, true, link.Text);
                    break;
            }

            pop.Show();
        }
        #endregion

      


    }
}
