using System;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LawtechPTSystemByFirm.ViewFrom
{
    public partial class TrademarkPaymentByUser : Form
    {
        public TrademarkPaymentByUser()
        {
            InitializeComponent();

            dataGridView_Billing.AutoGenerateColumns = false;
            Public.DynamicGridViewColumn.GetGridColum(ref dataGridView_Billing);
        }

        private void TrademarkPaymentByUser_Load(object sender, EventArgs e)
        {
            SetBindingSource();
            ControlBindingTMPayment();
        }

        #region  ============property============
        private int _TrademarkID = -1;
        /// <summary>
        /// PatentID
        /// </summary>
        public int property_TrademarkID
        {
            get
            {
                return _TrademarkID;

            }
            set
            {
                _TrademarkID = value;
            }
        }

        private int _Userkey = -1;
        /// <summary>
        /// 事件承辦人
        /// </summary>
        public int property_UserKey
        {
            get
            {
                return _Userkey;

            }
            set
            {
                _Userkey = value;
            }
        }
        #endregion

        #region ===========資料集===========
        private DataTable dt_TrademarkPaymentT = new DataTable();
        /// <summary>
        /// PatentFeeT 付款費用
        /// </summary>
        public DataTable DT_TrademarkPaymentT
        {
            get
            {
                return dt_TrademarkPaymentT;
            }

        }
        #endregion

        #region ControlBindingTMPayment
        public void ControlBindingTMPayment()
        {
            txt_PayFeeSubject.DataBindings.Clear();
            txt_PayFeeSubject.DataBindings.Add("Text", TrademarkPaymentTBindingSource, "FeeSubject", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_PayFeePhase.DataBindings.Clear();
            txt_PayFeePhase.DataBindings.Add("Text", TrademarkPaymentTBindingSource, "FeePhase", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_FClientTransactor.DataBindings.Clear();
            txt_FClientTransactor.DataBindings.Add("Text", TrademarkPaymentTBindingSource, "EmployeeName", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_Attorney.DataBindings.Clear();
            txt_Attorney.DataBindings.Add("Text", TrademarkPaymentTBindingSource, "AttorneyFirm", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_PayPayKind.DataBindings.Clear();
            txt_PayPayKind.DataBindings.Add("Text", TrademarkPaymentTBindingSource, "PayKind", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_PayIMoney.DataBindings.Clear();
            txt_PayIMoney.DataBindings.Add("Text", TrademarkPaymentTBindingSource, "IMoney", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_IServiceFee.DataBindings.Clear();
            txt_IServiceFee.DataBindings.Add("Text", TrademarkPaymentTBindingSource, "IServiceFee", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");

            txt_GovFee.DataBindings.Clear();
            txt_GovFee.DataBindings.Add("Text", TrademarkPaymentTBindingSource, "GovFee", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");

            txt_OtherFee.DataBindings.Clear();
            txt_OtherFee.DataBindings.Add("Text", TrademarkPaymentTBindingSource, "OtherFee", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");

            //單據號碼
            txt_IReceiptNo.DataBindings.Clear();
            txt_IReceiptNo.DataBindings.Add("Text", TrademarkPaymentTBindingSource, "IReceiptNo", true, DataSourceUpdateMode.OnValidation, "", "");



            txt_PayTotall.DataBindings.Clear();
            txt_PayTotall.DataBindings.Add("Text", TrademarkPaymentTBindingSource, "Totall", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");

            txt_PayRemark.DataBindings.Clear();
            txt_PayRemark.DataBindings.Add("Text", TrademarkPaymentTBindingSource, "Remark", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_Memo.DataBindings.Clear();
            txt_Memo.DataBindings.Add("Text", TrademarkPaymentTBindingSource, "Memo", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_BillCheck.DataBindings.Clear();
            txt_BillCheck.DataBindings.Add("Text", TrademarkPaymentTBindingSource, "BillCheck", true, DataSourceUpdateMode.OnValidation, "", "");

            //收件日期
            maskedTextBox_ReciveDate.DataBindings.Clear();
            maskedTextBox_ReciveDate.DataBindings.Add("Text", TrademarkPaymentTBindingSource, "ReciveDate", true, DataSourceUpdateMode.OnPropertyChanged, "    /  /", "yyyy/MM/dd");

            //付款期限
            maskedTextBox_PayDueDate.DataBindings.Clear();
            maskedTextBox_PayDueDate.DataBindings.Add("Text", TrademarkPaymentTBindingSource, "PayDueDate", true, DataSourceUpdateMode.OnPropertyChanged, "    /  /", "yyyy/MM/dd");

            //付款日期
            maskedTextBox_PaymentDate.DataBindings.Clear();
            maskedTextBox_PaymentDate.DataBindings.Add("Text", TrademarkPaymentTBindingSource, "PaymentDate", true, DataSourceUpdateMode.OnPropertyChanged, "    /  /", "yyyy/MM/dd");

            //完成日期
            maskedTextBox_IReceiptDate.DataBindings.Clear();
            maskedTextBox_IReceiptDate.DataBindings.Add("Text", TrademarkPaymentTBindingSource, "IReceiptDate", true, DataSourceUpdateMode.OnPropertyChanged, "    /  /", "yyyy/MM/dd");

            checkBox_IsBilling.DataBindings.Clear();
            checkBox_IsBilling.DataBindings.Add("Checked", TrademarkPaymentTBindingSource, "IsBilling", true, DataSourceUpdateMode.OnValidation, false);

            txt_BillingNo.DataBindings.Clear();
            txt_BillingNo.DataBindings.Add("Text", TrademarkPaymentTBindingSource, "BillingNo", true, DataSourceUpdateMode.OnValidation, "", "");

            //匯率
            txt_ExchangeRate.DataBindings.Clear();
            txt_ExchangeRate.DataBindings.Add("Text", TrademarkPaymentTBindingSource, "ExchangeRate", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");

            checkBox_IsCopyFile.DataBindings.Clear();
            checkBox_IsCopyFile.DataBindings.Add("Checked", TrademarkPaymentTBindingSource, "IsCopyFile", true, DataSourceUpdateMode.OnValidation, false);

            checkBox_IsScan.DataBindings.Clear();
            checkBox_IsScan.DataBindings.Add("Checked", TrademarkPaymentTBindingSource, "IsScan", true, DataSourceUpdateMode.OnValidation, false);

            //主管簽核
            txt_PaySingCode.DataBindings.Clear();
            txt_PaySingCode.DataBindings.Add("Text", TrademarkPaymentTBindingSource, "SingCode", true, DataSourceUpdateMode.OnValidation, "", "");
        }

        #endregion

        #region 設定BindingSource的來源 private void SetBindingSource()
        /// <summary>
        /// 設定BindingSource的來源
        /// </summary>
        private void SetBindingSource()
        {
            if (dt_TrademarkPaymentT.Columns.Count == 0)
            {
                Public.CTrademarkPublicFunction.GetTrademarkPaymentByUser(property_TrademarkID.ToString(), property_UserKey, ref dt_TrademarkPaymentT);
            }
            TrademarkPaymentTBindingSource.DataSource = dt_TrademarkPaymentT;
        }
        #endregion

        private void but_Close_Click(object sender, EventArgs e)
        {
            this.Close();
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
                MessageBox.Show("匯出CSV失敗");
            }
        }


    }
}
