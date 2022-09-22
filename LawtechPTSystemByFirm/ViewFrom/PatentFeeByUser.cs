using System;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LawtechPTSystemByFirm.ViewFrom
{
    public partial class PatentFeeByUser : Form
    {
        public PatentFeeByUser()
        {
            InitializeComponent();

            GridView_Fee.AutoGenerateColumns = false;
            Public.DynamicGridViewColumn.GetGridColum(ref GridView_Fee);
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
        #endregion

        private void toolStripButton_ExcelFee_Click(object sender, EventArgs e)
        {
            try
            {
                Public.DLL dll = new LawtechPTSystemByFirm.Public.DLL();
                Task task = dll.WriteToCSV(GridView_Fee);
            }
            catch
            {
                MessageBox.Show("匯出CSV失敗");
            }
        }

        private void but_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PatentFeeByUser_Load(object sender, EventArgs e)
        {
            SetBindingSource();
            ControlBindingTMFee();
        }

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
            txt_OMoney1.DataBindings.Add("Text", patentFeeTBindingSource, "OMoney", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_GMoney.DataBindings.Clear();
            txt_GMoney.DataBindings.Add("Text", patentFeeTBindingSource, "GMoney", true, DataSourceUpdateMode.OnValidation, "", "");

            txtMoney1.DataBindings.Clear();
            txtMoney1.DataBindings.Add("Text", patentFeeTBindingSource, "TtoNT", true, DataSourceUpdateMode.OnValidation, "", "#,##0.####");

            txtMoney2.DataBindings.Clear();
            txtMoney2.DataBindings.Add("Text", patentFeeTBindingSource, "OtoNT", true, DataSourceUpdateMode.OnValidation, "", "#,##0.####");

            txtMoney21.DataBindings.Clear();
            txtMoney21.DataBindings.Add("Text", patentFeeTBindingSource, "OtoNT", true, DataSourceUpdateMode.OnValidation, "", "#,##0.####");

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

            txtTax.DataBindings.Clear();
            txtTax.DataBindings.Add("Text", patentFeeTBindingSource, "Tax", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");

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

            //收款日期
            maskedTextBox_PayDate.DataBindings.Clear();
            maskedTextBox_PayDate.DataBindings.Add("Text", patentFeeTBindingSource, "PayDate", true, DataSourceUpdateMode.OnPropertyChanged, "    /  /", "yyyy/MM/dd");

            //收據日期
            maskedTextBox_ReceiptDate.DataBindings.Clear();
            maskedTextBox_ReceiptDate.DataBindings.Add("Text", patentFeeTBindingSource, "ReceiptDate", true, DataSourceUpdateMode.OnPropertyChanged, "    /  /", "yyyy/MM/dd");

            //簽核
            txt_SingCode.DataBindings.Clear();
            txt_SingCode.DataBindings.Add("Text", patentFeeTBindingSource, "SingCode", true, DataSourceUpdateMode.OnPropertyChanged, "", "");

        }

        #endregion

         #region 設定BindingSource的來源 private void SetBindingSource()
        /// <summary>
        /// 設定BindingSource的來源
        /// </summary>
        private void SetBindingSource()
        {
            if (dt_PatentFeeT.Columns.Count == 0)
            {
                Public.CPatentPublicFunction.GetPatentkFeeByUser(property_PatentID.ToString(),property_UserKey, ref dt_PatentFeeT);
            }
            patentFeeTBindingSource.DataSource = dt_PatentFeeT;
        }
         #endregion
    }
}
