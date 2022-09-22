using System;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LawtechPTSystem.ViewFrom
{
    public partial class PatentPaymentByUser : Form
    {
        public PatentPaymentByUser()
        {
            InitializeComponent();
            dataGridView_Billing.AutoGenerateColumns = false;
            Public.DynamicGridViewColumn.GetGridColum(ref dataGridView_Billing);
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
        #endregion

        private void PatentPaymentByUser_Load(object sender, EventArgs e)
        {
            SetBindingSource();
            ControlBindingTMPayment();
        }

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

            checkBox_IsCopyFile.DataBindings.Clear();
            checkBox_IsCopyFile.DataBindings.Add("Checked", patentPaymentTBindingSource, "IsCopyFile", true, DataSourceUpdateMode.OnValidation, false);

            checkBox_IsScan.DataBindings.Clear();
            checkBox_IsScan.DataBindings.Add("Checked", patentPaymentTBindingSource, "IsScan", true, DataSourceUpdateMode.OnValidation, false);

            //主管簽核
            txt_PaySingCode.DataBindings.Clear();
            txt_PaySingCode.DataBindings.Add("Text", patentPaymentTBindingSource, "SingCode", true, DataSourceUpdateMode.OnValidation, "", "");
        }

        #endregion           

        #region 設定BindingSource的來源 private void SetBindingSource()
        /// <summary>
        /// 設定BindingSource的來源
        /// </summary>
        private void SetBindingSource()
        {
            if (dt_PatentPaymentT.Columns.Count == 0)
            {
                Public.CPatentPublicFunction.GetPatentPaymentByUser(property_PatentID.ToString(), property_UserKey, ref dt_PatentPaymentT);
            }
            patentPaymentTBindingSource.DataSource = dt_PatentPaymentT;
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
                Public.DLL dll = new Public.DLL();
                Task task = dll.WriteToCSV(dataGridView_Billing);
            }
            catch
            {
                MessageBox.Show("匯出CSV失敗");
            }
        }
    }
}
