using System;
using System.Data;
using System.Windows.Forms;

namespace LawtechPTSystem.US
{
    /// <summary>
    /// 已請款
    /// </summary>
    public partial class FeeFinish : Form
    {
        public FeeFinish()
        {
            InitializeComponent();
        }

        #region Property
        private int iFeeKey = -1;
        /// <summary>
        /// 請款單PK
        /// </summary>
        public int FeeKey
        {
            get { return iFeeKey; }
            set { iFeeKey = value; }
        }


        private int iTypeKind = -1;
        /// <summary>
        /// 1.專利  2.商標 3.商標異議案
        /// </summary>
        public int TypeKind
        {
            get { return iTypeKind; }
            set { iTypeKind = value; }
        }


        private DataGridViewRow dgvr;
        /// <summary>
        /// dataGridView的Row
        /// </summary>
        public DataGridViewRow DGvr
        {
            get { return dgvr; }
            set { dgvr = value; }
        }

        private DataTable dt_AcountingFirmT = new DataTable();
        /// <summary>
        /// 入帳公司資料
        /// </summary>
        public DataTable AcountingFirmT
        {
            get { return dt_AcountingFirmT; }
            set {
                dt_AcountingFirmT = value;
            }
        }

        private DataTable dt_AcountingFirmDetailT = new DataTable();
        /// <summary>
        /// 銀行帳號資料
        /// </summary>
        public DataTable AcountingFirmDetailT
        {
            get { return dt_AcountingFirmDetailT; }
            set
            {
                dt_AcountingFirmDetailT = value;
            }
        }

        #endregion

        private void FeeFinish_Load(object sender, EventArgs e)
        {          
            this.moneyTTableAdapter.Fill(this.dataSet_Drop.MoneyT);
           
            Public.CAccountingPublicFunction.GetAcountingFirmTDropDownList(ref dt_AcountingFirmT);
            bindingSource_AcountingFirmT.DataSource = dt_AcountingFirmT;           
            comboBox_AcountingFirmT.DisplayMember = "AcountingFirmName";
            comboBox_AcountingFirmT.ValueMember = "AcountingFirmKey";
            comboBox_AcountingFirmT.DataSource = bindingSource_AcountingFirmT;

            switch (iTypeKind)
            {             
                case 1:
                    Public.CPatentFee fee = new Public.CPatentFee();
                    Public.CPatentFee.ReadOne(iFeeKey, ref fee);
                    
                    txt_FeeSubject.Text = fee.FeeSubject;
                    txt_PPP.Text = fee.PPP;
                    txt_PayKind.Text = fee.PayKind;
                    txt_Remark.Text = fee.Remark;
                    txt_aBill.Text = fee.aBill;
                    if(fee.AcountingFirmKey.HasValue)
                    {
                        comboBox_AcountingFirmT.SelectedValue = fee.AcountingFirmKey.Value;
                    }

                    if (fee.AcountingBankKey.HasValue)
                    {
                        comboBox_AcountingFirmDetailT.SelectedValue = fee.AcountingBankKey.Value;
                    }


                    if (fee.ReceiptDate.HasValue)
                    {
                        maskedTextBox_ReceiptDate.Text = fee.ReceiptDate.Value.ToString("yyyy/MM/dd");
                    }

                    if (fee.PayDate.HasValue)
                    {
                        maskedTextBox_PayDate.Text = fee.PayDate.Value.ToString("yyyy/MM/dd");
                    }

                    if (fee.CollectionPeriod.HasValue)
                    {
                        maskedTextBox_CollectionPeriod.Text = fee.CollectionPeriod.Value.ToString("yyyy/MM/dd");
                    }

                    if (fee.aBillDate.HasValue)
                    {
                        maskedTextBox_aBillDate.Text = fee.aBillDate.Value.ToString("yyyy/MM/dd");
                    }


                    numericUpDown_PracicalityPay.Value = fee.PracticalityPay.HasValue ? fee.PracticalityPay.Value : fee.TotalNT.Value;
                    checkBox_NT.Checked = fee.NT.HasValue ? fee.NT.Value : false;                  

                    chkWithholding.Checked = fee.Withholding.HasValue ? fee.Withholding.Value :false;
                    checkBox_Pay.Checked = fee.Pay.HasValue ? fee.Pay.Value : false;

                    bindControlPatentFee(fee);

                    break;

                case 2:
                    Public.CTrademarkFee Tmfee = new Public.CTrademarkFee();
                    Public.CTrademarkFee.ReadOne(iFeeKey, ref Tmfee);
                    txt_FeeSubject.Text = Tmfee.FeeSubject;
                    txt_PPP.Text = Tmfee.PPP;
                    txt_PayKind.Text = Tmfee.PayKind;
                    txt_Remark.Text = Tmfee.Remark;
                    txt_aBill.Text = Tmfee.aBill;
                    if (Tmfee.AcountingFirmKey.HasValue)
                    {
                        comboBox_AcountingFirmT.SelectedValue = Tmfee.AcountingFirmKey.Value;
                    }

                    if (Tmfee.AcountingBankKey.HasValue)
                    {
                        comboBox_AcountingFirmDetailT.SelectedValue = Tmfee.AcountingBankKey.Value;
                    }

                    if (Tmfee.ReceiptDate.HasValue)
                    {
                        maskedTextBox_ReceiptDate.Text = Tmfee.ReceiptDate.Value.ToString("yyyy/MM/dd");
                    }

                    if (Tmfee.PayDate.HasValue)
                    {
                        maskedTextBox_PayDate.Text = Tmfee.PayDate.Value.ToString("yyyy/MM/dd");
                    }

                    if (Tmfee.CollectionPeriod.HasValue)
                    {
                        maskedTextBox_CollectionPeriod.Text = Tmfee.CollectionPeriod.Value.ToString("yyyy/MM/dd");
                    }

                    if (Tmfee.aBillDate.HasValue)
                    {
                        maskedTextBox_aBillDate.Text = Tmfee.aBillDate.Value.ToString("yyyy/MM/dd");
                    }


                    numericUpDown_PracicalityPay.Value =Tmfee.PracticalityPay.HasValue? Tmfee.PracticalityPay.Value: Tmfee.TotalNT.Value;
                    checkBox_NT.Checked = Tmfee.NT.HasValue? Tmfee.NT.Value:false;

                   

                    chkWithholding.Checked = Tmfee.Withholding.HasValue? Tmfee.Withholding.Value:false;
                    checkBox_Pay.Checked = Tmfee.Pay.HasValue ? Tmfee.Pay.Value : false;

                    bindControlTrademarkFee(Tmfee);

                    break;               
            }


        }

        #region  public void bindControlPatentFee(Public.CPatentFee fee)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fee"></param>
        public void bindControlPatentFee(Public.CPatentFee fee)
        {
            txt_OthFeeName.Text = fee.OthFeeName;
            txt_CustomizeName.Text = fee.CustomizeName;
            txt_OtherTotalFeeCustomize1Name.Text = fee.OtherTotalFeeCustomize1Name;
            txt_OtherTotalFeeCustomize2Name.Text = fee.OtherTotalFeeCustomize2Name;
            txt_OtherTotalFeeCustomize3Name.Text = fee.OtherTotalFeeCustomize3Name;
            txt_PayMemo.Text = fee.PayMemo;

            txtAttorneyFee2.Text = fee.OAttorneyFee.HasValue ? fee.OAttorneyFee.Value.ToString("#,##0.##") : "0";
            txtAttorneyFee4.Text = fee.GovFee.HasValue ? fee.GovFee.Value.ToString("#,##0.##") : "0";
            txtAttorneyFee3.Text = fee.OthFee.HasValue ? fee.OthFee.Value.ToString("#,##0.##") : "0";
            txt_CustomizeOthFee.Text = fee.CustomizeOthFee.HasValue ? fee.CustomizeOthFee.Value.ToString("#,##0.##") : "0";


            txt_OMoney.Text = fee.OMoney;
            txt_GMoney.Text = fee.GMoney;
            txt_OMoney1.Text = fee.OthMoney;
            txt_CustomizeMoney.Text = fee.CustomizeMoney;


            txtMoney2.Text = fee.OtoNT.HasValue ? fee.OtoNT.Value.ToString("#,##0.##") : "0";
            txtMoney21.Text = fee.OthtoNT.HasValue ? fee.OthtoNT.Value.ToString("#,##0.##") : "0";
            txtMoney3.Text = fee.GtoNT.HasValue ? fee.GtoNT.Value.ToString("#,##0.##") : "0";
            txt_CustomizeNT.Text = fee.CustomizeNT.HasValue ? fee.CustomizeNT.Value.ToString("#,##0.##") : "0";


            txtAttorneyFeeTotal2.Text = fee.OTotall.HasValue ? fee.OTotall.Value.ToString("#,##0.##") : "0";
            txtAttorneyFeeTotal3.Text = fee.OthTotal.HasValue ? fee.OthTotal.Value.ToString("#,##0.##") : "0";
            txtAttorneyFeeTotal4.Text = fee.GTotall.HasValue ? fee.GTotall.Value.ToString("#,##0.##") : "0";
            txt_CustomizeTotal.Text = fee.CustomizeTotal.HasValue ? fee.CustomizeTotal.Value.ToString("#,##0.##") : "0";
            txtOAttorneyGovFee.Text = fee.OAttorneyGovFee.HasValue ? fee.OAttorneyGovFee.Value.ToString("#,##0.##") : "0";

            //所內收費-服務費
            txt_OtherTotalFee.Text = fee.OtherTotalFee.HasValue ? fee.OtherTotalFee.Value.ToString("#,##0.##") : "0";
            txt_OtherTotalFeeCustomize1.Text = fee.OtherTotalFeeCustomize1.HasValue ? fee.OtherTotalFeeCustomize1.Value.ToString("#,##0.##") : "0";
            txt_OtherTotalFeeCustomize2.Text = fee.OtherTotalFeeCustomize2.HasValue ? fee.OtherTotalFeeCustomize2.Value.ToString("#,##0.##") : "0";
            txt_OtherTotalFeeCustomize3.Text = fee.OtherTotalFeeCustomize3.HasValue ? fee.OtherTotalFeeCustomize3.Value.ToString("#,##0.##") : "0";

            //收費合計
            txt_OtherTotalFeeInSide.Text = fee.OtherTotalFeeInSide.HasValue ? fee.OtherTotalFeeInSide.Value.ToString("#,##0.##") : "0";

            //稅額%
            txt_TaxPercent.Text = fee.TaxPercent.HasValue ? fee.TaxPercent.Value.ToString("#,##0.##") : "0";

            //預扣稅額
            txt_Tax.Text = fee.Tax.HasValue ? fee.Tax.Value.ToString("#,##0.##") : "0";

            //未含稅額
            txt_OtherTotalFeeInSideTax.Text = fee.OtherTotalFeeInSideTax.HasValue ? fee.OtherTotalFeeInSideTax.Value.ToString("#,##0.##") : "0";

            //請款合計
            txtTotall.Text = fee.Totall.HasValue ? fee.Totall.Value.ToString("#,##0.##") : "0";

            //請款合計-幣別
            txt_IMoney.Text = fee.TMoney;

            //請款合計-兌NT
            txtMoney1.Text = fee.TtoNT.HasValue ? fee.TtoNT.Value.ToString("#,##0.##") : "0";

            //請款合計-合計NT
            txtAttorneyFeeTotal1.Text = fee.TotalNT.HasValue ? fee.TotalNT.Value.ToString("#,##0.##") : "0";
        }
        #endregion

        #region  public void bindControlTrademarkFee(Public.CTrademarkFee fee)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fee"></param>
        public void bindControlTrademarkFee(Public.CTrademarkFee fee)
        {
            txt_OthFeeName.Text = fee.OthFeeName;
            txt_CustomizeName.Text = fee.CustomizeName;
            txt_OtherTotalFeeCustomize1Name.Text = fee.OtherTotalFeeCustomize1Name;
            txt_OtherTotalFeeCustomize2Name.Text = fee.OtherTotalFeeCustomize2Name;
            txt_OtherTotalFeeCustomize3Name.Text = fee.OtherTotalFeeCustomize3Name;
            txt_PayMemo.Text = fee.PayMemo;

            txtAttorneyFee2.Text = fee.OAttorneyFee.HasValue ? fee.OAttorneyFee.Value.ToString("#,##0.##") : "0";
            txtAttorneyFee4.Text = fee.GovFee.HasValue ? fee.GovFee.Value.ToString("#,##0.##") : "0";
            txtAttorneyFee3.Text = fee.OthFee.HasValue ? fee.OthFee.Value.ToString("#,##0.##") : "0";
            txt_CustomizeOthFee.Text = fee.CustomizeOthFee.HasValue ? fee.CustomizeOthFee.Value.ToString("#,##0.##") : "0";


            txt_OMoney.Text = fee.OMoney;
            txt_GMoney.Text = fee.GMoney;
            txt_OMoney1.Text = fee.OthMoney;
            txt_CustomizeMoney.Text = fee.CustomizeMoney;


            txtMoney2.Text = fee.OtoNT.HasValue ? fee.OtoNT.Value.ToString("#,##0.##") : "0";
            txtMoney21.Text = fee.OthtoNT.HasValue ? fee.OthtoNT.Value.ToString("#,##0.##") : "0";
            txtMoney3.Text = fee.GtoNT.HasValue ? fee.GtoNT.Value.ToString("#,##0.##") : "0";
            txt_CustomizeNT.Text = fee.CustomizeNT.HasValue ? fee.CustomizeNT.Value.ToString("#,##0.##") : "0";


            txtAttorneyFeeTotal2.Text = fee.OTotall.HasValue ? fee.OTotall.Value.ToString("#,##0.##") : "0";
            txtAttorneyFeeTotal3.Text = fee.OthTotal.HasValue ? fee.OthTotal.Value.ToString("#,##0.##") : "0";
            txtAttorneyFeeTotal4.Text = fee.GTotall.HasValue ? fee.GTotall.Value.ToString("#,##0.##") : "0";
            txt_CustomizeTotal.Text = fee.CustomizeTotal.HasValue ? fee.CustomizeTotal.Value.ToString("#,##0.##") : "0";
            txtOAttorneyGovFee.Text = fee.OAttorneyGovFee.HasValue ? fee.OAttorneyGovFee.Value.ToString("#,##0.##") : "0";

            //所內收費-服務費
            txt_OtherTotalFee.Text = fee.OtherTotalFee.HasValue ? fee.OtherTotalFee.Value.ToString("#,##0.##") : "0";
            txt_OtherTotalFeeCustomize1.Text = fee.OtherTotalFeeCustomize1.HasValue ? fee.OtherTotalFeeCustomize1.Value.ToString("#,##0.##") : "0";
            txt_OtherTotalFeeCustomize2.Text = fee.OtherTotalFeeCustomize2.HasValue ? fee.OtherTotalFeeCustomize2.Value.ToString("#,##0.##") : "0";
            txt_OtherTotalFeeCustomize3.Text = fee.OtherTotalFeeCustomize3.HasValue ? fee.OtherTotalFeeCustomize3.Value.ToString("#,##0.##") : "0";

            //收費合計
            txt_OtherTotalFeeInSide.Text = fee.OtherTotalFeeInSide.HasValue ? fee.OtherTotalFeeInSide.Value.ToString("#,##0.##") : "0";

            //稅額%
            txt_TaxPercent.Text = fee.TaxPercent.HasValue ? fee.TaxPercent.Value.ToString("#,##0.##") : "0";

            //預扣稅額
            txt_Tax.Text = fee.Tax.HasValue ? fee.Tax.Value.ToString("#,##0.##") : "0";

            //未含稅額
            txt_OtherTotalFeeInSideTax.Text = fee.OtherTotalFeeInSideTax.HasValue ? fee.OtherTotalFeeInSideTax.Value.ToString("#,##0.##") : "0";

            //請款合計
            txtTotall.Text = fee.Totall.HasValue ? fee.Totall.Value.ToString("#,##0.##") : "0";

            //請款合計-幣別
            txt_IMoney.Text = fee.TMoney;

            //請款合計-兌NT
            txtMoney1.Text = fee.TtoNT.HasValue ? fee.TtoNT.Value.ToString("#,##0.##") : "0";

            //請款合計-合計NT
            txtAttorneyFeeTotal1.Text = fee.TotalNT.HasValue ? fee.TotalNT.Value.ToString("#,##0.##") : "0";
        }
        #endregion

        private void but_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void but_OK_Click(object sender, EventArgs e)
        {
            Public.PublicForm Forms = new Public.PublicForm();
            switch (iTypeKind)
            {
                case 1:
                    Public.CPatentFee fee = new Public.CPatentFee();
                    Public.CPatentFee.ReadOne(iFeeKey, ref fee);

                    fee.Pay = checkBox_Pay.Checked != true ? false : true;//已請款
                    fee.PPP = txt_PPP.Text;
                    fee.aBill = txt_aBill.Text;
                    if(comboBox_AcountingFirmT.SelectedValue!=null)
                    {
                        fee.AcountingFirmKey = (int)comboBox_AcountingFirmT.SelectedValue;
                    }

                    if (comboBox_AcountingFirmDetailT.SelectedValue != null)
                    {
                        fee.AcountingBankKey = (int)comboBox_AcountingFirmDetailT.SelectedValue;
                    }


                    //收據日期
                    DateTime dtReceiptDate;
                    bool IsReceiptDate = DateTime.TryParse(maskedTextBox_ReceiptDate.Text, out dtReceiptDate);
                    if (IsReceiptDate)
                    {
                        fee.ReceiptDate = dtReceiptDate;
                    }
                    else
                    {
                        fee.ReceiptDate = null;
                    }

                    //收款日期
                    DateTime dtPayDate;
                    bool IsdtPayDate = DateTime.TryParse(maskedTextBox_PayDate.Text, out dtPayDate);
                    if (IsdtPayDate)
                    {
                        fee.PayDate = dtPayDate;
                    }
                    else
                    {
                        fee.PayDate = null;
                    }

                    //收款期限
                    DateTime dtCollectionPeriod;
                    bool IsdtCollectionPeriod = DateTime.TryParse(maskedTextBox_CollectionPeriod.Text, out dtCollectionPeriod);
                    if (IsdtCollectionPeriod)
                    {
                        fee.CollectionPeriod = dtCollectionPeriod;
                    }
                    else
                    {
                        fee.CollectionPeriod = null;
                    }

                    //發票日期
                    DateTime dtaBillDate;
                    bool IsaBillDate = DateTime.TryParse(maskedTextBox_aBillDate.Text, out dtaBillDate);
                    if (IsaBillDate)
                    {
                        fee.aBillDate = dtaBillDate;
                    }
                    else
                    {
                        fee.aBillDate = null;
                    }


                    fee.NT = checkBox_NT.Checked != true ? false : true;//外幣支付
                
                    fee.PracticalityPay = numericUpDown_PracicalityPay.Value;//實際請款
                  
                                   
                    fee.PayKind = txt_PayKind.Text;//付款方式
                    fee.Remark = txt_Remark.Text;
                    fee.LastModifyDateTime = DateTime.Now;
                    fee.LastModifyWorker = Properties.Settings.Default.WorkerName;
                    fee.Update();

                    if (Forms.AccountingFeeList != null && Forms.AccountingFeeList.GV_CurrentRow != null)
                    {
                        #region MyRegion
                        //DataGridViewRow gvr = Forms.AccountingFeeList.GV_CurrentRow;
                        //gvr.Cells["PPP"].Value = fee.PPP;
                        ////收據日期
                        //if (fee.ReceiptDate.HasValue)
                        //{
                        //    gvr.Cells["ReceiptDate"].Value = fee.ReceiptDate;
                        //}
                        //else
                        //{
                        //    gvr.Cells["ReceiptDate"].Value = DBNull.Value;
                        //}

                        ////收款日期
                        //if (fee.PayDate.HasValue)
                        //{
                        //    gvr.Cells["PayDate"].Value = fee.PayDate;
                        //}
                        //else
                        //{
                        //    gvr.Cells["PayDate"].Value = DBNull.Value;
                        //}

                        ////收款日期
                        //if (fee.CollectionPeriod.HasValue)
                        //{
                        //    gvr.Cells["CollectionPeriod"].Value = fee.CollectionPeriod;
                        //}
                        //else
                        //{
                        //    gvr.Cells["CollectionPeriod"].Value = DBNull.Value;
                        //}

                        //gvr.Cells["PracticalityPay"].Value = fee.PracticalityPay;
                        //gvr.Cells["Remark"].Value = fee.Remark;
                        //gvr.Cells["Tax"].Value = fee.Tax;
                        #endregion
                        DataTable dtSource = Forms.AccountingFeeList.GetAccountingData;
                        DataRow dr = dtSource.Rows.Find(fee.FeeKey);
                        DataRow drV = Public.CAccountingPublicFunction.GetAccountingFeeListPatentDataRow(fee.FeeKey.ToString());
                        dr.ItemArray = drV.ItemArray;
                        dr.AcceptChanges();
                    }
                    break;

                case 2:
                    Public.CTrademarkFee Tmfee = new Public.CTrademarkFee();
                    Public.CTrademarkFee.ReadOne(iFeeKey, ref Tmfee);

                    Tmfee.Pay = checkBox_Pay.Checked != true ? false : true;//已請款
                    Tmfee.PPP = txt_PPP.Text;
                    Tmfee.aBill = txt_aBill.Text;

                    if (comboBox_AcountingFirmT.SelectedValue != null)
                    {
                        Tmfee.AcountingFirmKey = (int)comboBox_AcountingFirmT.SelectedValue;
                    }

                    if (comboBox_AcountingFirmDetailT.SelectedValue != null)
                    {
                        Tmfee.AcountingBankKey = (int)comboBox_AcountingFirmDetailT.SelectedValue;
                    }
                    //收據日期
                    DateTime dtReceiptDateTM;
                    bool IsReceiptDateTM = DateTime.TryParse(maskedTextBox_ReceiptDate.Text, out dtReceiptDateTM);
                    if (IsReceiptDateTM)
                    {
                        Tmfee.ReceiptDate = dtReceiptDateTM;
                    }
                    else
                    {
                        Tmfee.ReceiptDate = null;
                    }

                    //收款日期
                    DateTime dtPayDatetm;
                    bool IsdtPayDatetm = DateTime.TryParse(maskedTextBox_PayDate.Text, out dtPayDatetm);
                    if (IsdtPayDatetm)
                    {
                        Tmfee.PayDate = dtPayDatetm;
                    }
                    else
                    {
                        Tmfee.PayDate = null;
                    }

                    //收款期限
                    DateTime dtTmCollectionPeriod;
                    bool IsTmCollectionPeriod = DateTime.TryParse(maskedTextBox_CollectionPeriod.Text, out dtTmCollectionPeriod);
                    if (IsTmCollectionPeriod)
                    {
                        Tmfee.CollectionPeriod = dtTmCollectionPeriod;
                    }
                    else
                    {
                        Tmfee.CollectionPeriod = null;
                    }

                    //發票日期
                    DateTime dtTaBillDate;
                    bool IsTaBillDate = DateTime.TryParse(maskedTextBox_aBillDate.Text, out dtTaBillDate);
                    if (IsTaBillDate)
                    {
                        Tmfee.aBillDate = dtTaBillDate;
                    }
                    else
                    {
                        Tmfee.aBillDate = null;
                    }

                    //Tmfee.NT = checkBox_NT.Checked != true ? false : true;//外幣支付                   

                    Tmfee.PracticalityPay = numericUpDown_PracicalityPay.Value;//實際請款
                    Tmfee.Withholding = chkWithholding.Checked != true ? false : true;//已預扣
                 
                    Tmfee.PayKind = txt_PayKind.Text;//付款方式
                    Tmfee.Remark = txt_Remark.Text;

                    Tmfee.LastModifyWorker = Properties.Settings.Default.WorkerName;
                    Tmfee.Update();


                    if (Forms.AccountingFeeList != null && Forms.AccountingFeeList.GV_CurrentRow != null)
                    {
                        #region MyRegion
                        //DataGridViewRow gvr = Forms.AccountingFeeList.GV_CurrentRow;
                        //gvr.Cells["PPP"].Value = Tmfee.PPP;
                        ////收據日期
                        //if (Tmfee.ReceiptDate.HasValue)
                        //{
                        //    gvr.Cells["ReceiptDate"].Value = Tmfee.ReceiptDate;
                        //}
                        //else
                        //{
                        //    gvr.Cells["ReceiptDate"].Value = DBNull.Value;
                        //}

                        ////收款日期
                        //if (Tmfee.PayDate.HasValue)
                        //{
                        //    gvr.Cells["PayDate"].Value = Tmfee.PayDate;
                        //}
                        //else
                        //{
                        //    gvr.Cells["PayDate"].Value = DBNull.Value;
                        //}

                        ////收款期限
                        //if (Tmfee.CollectionPeriod.HasValue)
                        //{
                        //    gvr.Cells["CollectionPeriod"].Value = Tmfee.CollectionPeriod;
                        //}
                        //else
                        //{
                        //    gvr.Cells["CollectionPeriod"].Value = DBNull.Value;
                        //}
                        //gvr.Cells["PracticalityPay"].Value = Tmfee.PracticalityPay;
                        //gvr.Cells["Remark"].Value = Tmfee.Remark;
                        //gvr.Cells["Tax"].Value = Tmfee.Tax; 
                        #endregion
                        DataTable dtSource = Forms.AccountingFeeList.GetAccountingData;
                        DataRow dr = dtSource.Rows.Find(Tmfee.FeeKEY);
                        DataRow drV = Public.CAccountingPublicFunction.GetAccountingFeeListTrademarkDataRow(Tmfee.FeeKEY.ToString());                        
                        dr.ItemArray = drV.ItemArray;
                        dr.AcceptChanges();
                        
                    }
                    break;

                case 3: //CO
                    Public.CTrademarkControversyFee TmControversyfee = new Public.CTrademarkControversyFee("ControversyFeeKEY=" + iFeeKey.ToString());
                    TmControversyfee.SetCurrent(iFeeKey);

                    TmControversyfee.Pay = checkBox_Pay.Checked != true ? false : true;//已請款
                    TmControversyfee.PPP = txt_PPP.Text;
                    //收據日期
                    DateTime dtCOReceiptDateTM;
                    bool IsCOReceiptDateTM = DateTime.TryParse(maskedTextBox_ReceiptDate.Text, out dtCOReceiptDateTM);
                    if (IsCOReceiptDateTM)
                    {
                        TmControversyfee.ReceiptDate = dtCOReceiptDateTM;
                    }
                    else
                    {
                        TmControversyfee.ReceiptDate = new DateTime(1900, 1, 1);
                    }

                    //收款日期
                    DateTime dtCOPayDatetm;
                    bool IsCOdtPayDatetm = DateTime.TryParse(maskedTextBox_PayDate.Text, out dtCOPayDatetm);
                    if (IsCOdtPayDatetm)
                    {
                        TmControversyfee.PayDate = dtCOPayDatetm;
                    }
                    else
                    {
                        TmControversyfee.PayDate = new DateTime(1900, 1, 1);
                    }

                    TmControversyfee.NT = checkBox_NT.Checked != true ? false : true;//外幣支付
                    TmControversyfee.PracticalityPay = numericUpDown_PracicalityPay.Value;//實際請款
                    TmControversyfee.Withholding = chkWithholding.Checked != true ? false : true;//已預扣
                 
                    TmControversyfee.PayKind = txt_PayKind.Text;//付款方式
                    TmControversyfee.Remark = txt_Remark.Text;
                    TmControversyfee.LastModifyDate = DateTime.Now;
                    TmControversyfee.LastModifyWorker = Properties.Settings.Default.WorkerKEY;
                    TmControversyfee.Updata(iFeeKey);

                    if (TmControversyfee.PayDate.Year > 1900)
                    {
                        dgvr.Cells["FinishDate"].Value = TmControversyfee.PayDate;
                    }
                    else
                    {
                        dgvr.Cells["FinishDate"].Value = DBNull.Value;
                    }
                    dgvr.Cells["Result"].Value = TmControversyfee.Remark;
                    break;
            }
            

            MessageBox.Show("更新成功", "提示訊息");
            this.Close();


        }

        private void mtb_PayDate_DoubleClick(object sender, EventArgs e)
        {
            MaskedTextBox mtb = (MaskedTextBox)sender;
            DateTime dt;
            bool IsSuccess = DateTime.TryParse(mtb.Text, out dt);
            if (!IsSuccess)
            {
                mtb.Text = DateTime.Now.ToString("yyyy/MM/dd");
            }
        }

        private void FeeFinish_KeyDown(object sender, KeyEventArgs e)
        {
            Public.Utility.ControlTab(e);
        }

        private void linkLabel_PPP_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            US.CheckPPP ppp = new CheckPPP();
            ppp.ModeType = TypeKind;

            if (TypeKind == 1)
            {
                Public.CPatentFee fee = new Public.CPatentFee();
                Public.CPatentFee.ReadOne(iFeeKey, ref fee);
                ppp.MainKey = fee.PatentID;
            }
            else if (TypeKind == 2)
            {
                Public.CTrademarkFee fee = new Public.CTrademarkFee();
                Public.CTrademarkFee.ReadOne(iFeeKey, ref fee);
                ppp.MainKey = fee.TrademarkID;
            }
            else if (TypeKind == 3)
            {
                Public.CTrademarkControversyFee fee = new Public.CTrademarkControversyFee("ControversyFeeKEY=" + iFeeKey.ToString());
                fee.SetCurrent(iFeeKey);
                ppp.MainKey = fee.TrademarkControversyID;
            }


            if (ppp.ShowDialog() == DialogResult.OK)
            {
                txt_PPP.Text = ppp.get_PPP;
            }
           
        }

        private void checkBox_Pay_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox_Pay.Checked)
            {
                maskedTextBox_PayDate.Enabled = true;
                maskedTextBox_PayDate.Text = DateTime.Now.ToString("yyyy/MM/dd");
            }
            else
            {
                maskedTextBox_PayDate.Enabled = false;
                maskedTextBox_PayDate.Text = "";
            }
        }

        private void maskedTextBox_ReceiptDate_DoubleClick_1(object sender, EventArgs e)
        {
            MaskedTextBox masked = (MaskedTextBox)sender;
            Public.CommonFunctions.MaskedTextBoxDoubleClick(masked);
        }

        private void maskedTextBox_ReceiptDate_Leave(object sender, EventArgs e)
        {
            MaskedTextBox mak = (MaskedTextBox)sender;
            Public.Utility.CheckMaskedtextbox(mak);
        }

      

       

        #region private void rateMoney(NumericUpDown AttorneyFee, NumericUpDown RateMoney, TextBox txtFeeTotal1)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="AttorneyFee"></param>
        /// <param name="RateMoney"></param>
        /// <param name="txtFeeTotal1"></param>
        private void rateMoney(NumericUpDown AttorneyFee, NumericUpDown RateMoney, TextBox txtFeeTotal1)
        {
            try
            {
                decimal dec =   AttorneyFee.Value / RateMoney.Value;

                txtFeeTotal1.Text = dec.ToString("#,##0");
            }
            catch
            {
                txtFeeTotal1.Text = "0";
            }
        }

        #endregion

        #region private void comboBox_AcountingFirmT_SelectedIndexChanged(object sender, EventArgs e)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox_AcountingFirmT_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_AcountingFirmT.SelectedValue != null)
            {
                int iKey = (int)comboBox_AcountingFirmT.SelectedValue;
                Public.CAccountingPublicFunction.GetAcountingFirmDetailDropDownTList(iKey.ToString(), ref dt_AcountingFirmDetailT);
                bindingSource_AcountingFirmDetailT.DataSource = dt_AcountingFirmDetailT;
                comboBox_AcountingFirmDetailT.DisplayMember = "BankInfo";
                comboBox_AcountingFirmDetailT.ValueMember = "AcountingBankKey";
            }
            else
            {
                dt_AcountingFirmDetailT.Rows.Clear();
            }

        } 
        #endregion
    }
}
