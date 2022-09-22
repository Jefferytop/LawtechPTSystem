using System;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LawtechPTSystemByFirm.ViewFrom
{
    public partial class TrademarkFeeByUser : Form
    {
        public TrademarkFeeByUser()
        {
            InitializeComponent();

            GridView_Fee.AutoGenerateColumns = false;
            Public.DynamicGridViewColumn.GetGridColum(ref GridView_Fee);
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
        private DataTable dt_TrademarkFeeT = new DataTable();
        /// <summary>
        /// PatentFeeT 請款費用
        /// </summary>
        public DataTable DT_TrademarkFeeT
        {
            get
            {
                return dt_TrademarkFeeT;
            }

        }
        #endregion

        #region private void toolStripButton_ExcelFee_Click(object sender, EventArgs e)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        #endregion

        private void but_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TrademarkFeeByUser_Load(object sender, EventArgs e)
        {
            SetBindingSource();
            ControlBindingTMFee();
        }

        #region ControlBindingTMFee
        public void ControlBindingTMFee()
        {

            txt_FeeSubject.DataBindings.Clear();
            txt_FeeSubject.DataBindings.Add("Text", TrademarkFeeTBindingSource, "FeeSubject", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_FeePhase.DataBindings.Clear();
            txt_FeePhase.DataBindings.Add("Text", TrademarkFeeTBindingSource, "FeePhase", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_AttorneyName.DataBindings.Clear();
            txt_AttorneyName.DataBindings.Add("Text", TrademarkFeeTBindingSource, "AttorneyFirm", true, DataSourceUpdateMode.OnValidation, "", "");

            txtTotall.DataBindings.Clear();
            txtTotall.DataBindings.Add("Text", TrademarkFeeTBindingSource, "Totall", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");

            txtAttorneyFee2.DataBindings.Clear();
            txtAttorneyFee2.DataBindings.Add("Text", TrademarkFeeTBindingSource, "OAttorneyFee", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");

            txtAttorneyFee3.DataBindings.Clear();
            txtAttorneyFee3.DataBindings.Add("Text", TrademarkFeeTBindingSource, "OthFee", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");

            txtAttorneyFee4.DataBindings.Clear();
            txtAttorneyFee4.DataBindings.Add("Text", TrademarkFeeTBindingSource, "GovFee", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");

            txt_IMoney.DataBindings.Clear();
            txt_IMoney.DataBindings.Add("Text", TrademarkFeeTBindingSource, "TMoney", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_OMoney.DataBindings.Clear();
            txt_OMoney.DataBindings.Add("Text", TrademarkFeeTBindingSource, "OMoney", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_OMoney1.DataBindings.Clear();
            txt_OMoney1.DataBindings.Add("Text", TrademarkFeeTBindingSource, "OMoney", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_GMoney.DataBindings.Clear();
            txt_GMoney.DataBindings.Add("Text", TrademarkFeeTBindingSource, "GMoney", true, DataSourceUpdateMode.OnValidation, "", "");

            txtMoney1.DataBindings.Clear();
            txtMoney1.DataBindings.Add("Text", TrademarkFeeTBindingSource, "TtoNT", true, DataSourceUpdateMode.OnValidation, "", "#,##0.####");

            txtMoney2.DataBindings.Clear();
            txtMoney2.DataBindings.Add("Text", TrademarkFeeTBindingSource, "OtoNT", true, DataSourceUpdateMode.OnValidation, "", "#,##0.####");

            txtMoney21.DataBindings.Clear();
            txtMoney21.DataBindings.Add("Text", TrademarkFeeTBindingSource, "OtoNT", true, DataSourceUpdateMode.OnValidation, "", "#,##0.####");

            txtMoney3.DataBindings.Clear();
            txtMoney3.DataBindings.Add("Text", TrademarkFeeTBindingSource, "GtoNT", true, DataSourceUpdateMode.OnValidation, "", "#,##0.####");

            txtAttorneyFeeTotal1.DataBindings.Clear();
            txtAttorneyFeeTotal1.DataBindings.Add("Text", TrademarkFeeTBindingSource, "TotalNT", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");

            txtAttorneyFeeTotal2.DataBindings.Clear();
            txtAttorneyFeeTotal2.DataBindings.Add("Text", TrademarkFeeTBindingSource, "OTotall", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");

            txtAttorneyFeeTotal3.DataBindings.Clear();
            txtAttorneyFeeTotal3.DataBindings.Add("Text", TrademarkFeeTBindingSource, "OthTotal", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");

            txtAttorneyFeeTotal4.DataBindings.Clear();
            txtAttorneyFeeTotal4.DataBindings.Add("Text", TrademarkFeeTBindingSource, "GTotall", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");

            checkBox_Pay.DataBindings.Clear();
            checkBox_Pay.DataBindings.Add("Checked", TrademarkFeeTBindingSource, "Pay", true, DataSourceUpdateMode.OnValidation, false);

            checkBox_NT.DataBindings.Clear();
            checkBox_NT.DataBindings.Add("Checked", TrademarkFeeTBindingSource, "NT", true, DataSourceUpdateMode.OnValidation, false);

            chkWithholding.DataBindings.Clear();
            chkWithholding.DataBindings.Add("Checked", TrademarkFeeTBindingSource, "Withholding", true, DataSourceUpdateMode.OnValidation, false);

            txtTax.DataBindings.Clear();
            txtTax.DataBindings.Add("Text", TrademarkFeeTBindingSource, "Tax", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");

            txtOAttorneyGovFee.DataBindings.Clear();
            txtOAttorneyGovFee.DataBindings.Add("Text", TrademarkFeeTBindingSource, "OAttorneyGovFee", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");

            txt_OtherTotalFee.DataBindings.Clear();
            txt_OtherTotalFee.DataBindings.Add("Text", TrademarkFeeTBindingSource, "OtherTotalFee", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");

            txtTotall.DataBindings.Clear();
            txtTotall.DataBindings.Add("Text", TrademarkFeeTBindingSource, "Totall", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");

            txtPracicalityPay.DataBindings.Clear();
            txtPracicalityPay.DataBindings.Add("Text", TrademarkFeeTBindingSource, "PracticalityPay", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");

            txt_PayKind.DataBindings.Clear();
            txt_PayKind.DataBindings.Add("Text", TrademarkFeeTBindingSource, "PayKind", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_PayMemo.DataBindings.Clear();
            txt_PayMemo.DataBindings.Add("Text", TrademarkFeeTBindingSource, "PayMemo", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_Remark.DataBindings.Clear();
            txt_Remark.DataBindings.Add("Text", TrademarkFeeTBindingSource, "Remark", true, DataSourceUpdateMode.OnValidation, "", "");

            //請款單號
            txt_PPP.DataBindings.Clear();
            txt_PPP.DataBindings.Add("Text", TrademarkFeeTBindingSource, "PPP", true, DataSourceUpdateMode.OnValidation, "", "");

            //請款人
            txt_FeeWorkerName.DataBindings.Clear();
            txt_FeeWorkerName.DataBindings.Add("Text", TrademarkFeeTBindingSource, "EmployeeName", true, DataSourceUpdateMode.OnValidation, "", "");

            //請款日期
            maskedTextBox_RDate.DataBindings.Clear();
            maskedTextBox_RDate.DataBindings.Add("Text", TrademarkFeeTBindingSource, "RDate", true, DataSourceUpdateMode.OnPropertyChanged, "    /  /", "yyyy/MM/dd");

            //收款日期
            maskedTextBox_PayDate.DataBindings.Clear();
            maskedTextBox_PayDate.DataBindings.Add("Text", TrademarkFeeTBindingSource, "PayDate", true, DataSourceUpdateMode.OnPropertyChanged, "    /  /", "yyyy/MM/dd");

            //收據日期
            maskedTextBox_ReceiptDate.DataBindings.Clear();
            maskedTextBox_ReceiptDate.DataBindings.Add("Text", TrademarkFeeTBindingSource, "ReceiptDate", true, DataSourceUpdateMode.OnPropertyChanged, "    /  /", "yyyy/MM/dd");

            //簽核
            txt_SingCode.DataBindings.Clear();
            txt_SingCode.DataBindings.Add("Text", TrademarkFeeTBindingSource, "SingCode", true, DataSourceUpdateMode.OnPropertyChanged, "", "");

        }

        #endregion

        #region 設定BindingSource的來源 private void SetBindingSource()
        /// <summary>
        /// 設定BindingSource的來源
        /// </summary>
        private void SetBindingSource()
        {
            if (dt_TrademarkFeeT.Columns.Count == 0)
            {
                Public.CTrademarkPublicFunction.GetTrademarkFeeByUser(property_TrademarkID.ToString(), property_UserKey, ref dt_TrademarkFeeT);
            }
            TrademarkFeeTBindingSource.DataSource = dt_TrademarkFeeT;
        }
        #endregion


    }
}
