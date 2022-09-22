using System;
using System.Data;
using System.Windows.Forms;

namespace LawtechPTSystem.US
{
    public partial class AccountingPaymentFinish : Form
    {
        public AccountingPaymentFinish()
        {
            InitializeComponent();
        }

        #region Property
        private int iPaymentID = -1;
        /// <summary>
        /// 付款單PK
        /// </summary>
        public int PaymentID
        {
            get { return iPaymentID; }
            set { iPaymentID = value; }
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
        #endregion

        #region AccountingPaymentFinish_Load
        private void AccountingPaymentFinish_Load(object sender, EventArgs e)
        {
           
            this.acountingFirmTTableAdapter.Fill(this.dataSet_Attorney.AcountingFirmT);

            switch (iTypeKind)
            {
                case 1:
                    Public.CPatentPayment pay = new Public.CPatentPayment();
                    Public.CPatentPayment.ReadOne(iPaymentID, ref pay);
                   
                    txt_FeeSubject.Text = pay.FeeSubject;
                    txt_BillCheck.Text = pay.BillCheck;
                    txt_BillingNo.Text = pay.BillingNo;
                    txt_Memo.Text = pay.Memo;
                    txt_IMoney.Text = pay.IMoney;
                    txt_SingCode.Text= pay.SingCode;
                    if (string.IsNullOrEmpty(txt_SingCode.Text.Trim()))
                    {
                        lab_SingCode.Visible = true;
                    }

                        //金額總計
                        txt_Totall.Text = pay.Totall.HasValue ? pay.Totall.Value.ToString("#,##0.##") : "";
                    

                    //當時匯率
                    numericUpDown_ExchangeRate.Value =pay.ExchangeRate.HasValue? pay.ExchangeRate.Value:0;
                   
                    txt_IReceiptNo.Text = pay.IReceiptNo;

                    checkBox_IsCopyFile.Checked = pay.IsCopyFile.HasValue?   pay.IsCopyFile.Value:false;
                    checkBox_IsScan.Checked = pay.IsScan.HasValue ? pay.IsScan.Value : false;
                    checkBox_IsBilling.Checked = pay.IsBilling.HasValue ? pay.IsBilling.Value : false;
                    comboBox_AcountingFirmKey.SelectedValue =pay.AcountingFirmKey.HasValue ? pay.AcountingFirmKey.Value:0;
                    if (pay.ReciveDate.HasValue)
                    {
                        maskedTextBox_ReciveDate.Text = pay.ReciveDate.Value.ToString("yyyy/MM/dd");
                    }

                    if (pay.PaymentDate.HasValue)
                    {
                        maskedTextBox_PaymentDate.Text = pay.PaymentDate.Value.ToString("yyyy/MM/dd");
                    }

                    if (pay.EstimatedPaymentDate.HasValue)
                    {
                        maskedTextBox_EstimatedPaymentDate.Text = pay.EstimatedPaymentDate.Value.ToString("yyyy/MM/dd");
                    }

                    checkBox_IsBilling.Checked = pay.IsBilling.HasValue?pay.IsBilling.Value:false;
                    checkBox_IsCopyFile.Checked = pay.IsCopyFile.HasValue ? pay.IsCopyFile.Value : false;
                    checkBox_IsScan.Checked = pay.IsScan.HasValue ? pay.IsScan.Value : false;

                    if (pay.PayDueDate.HasValue)
                    {
                        maskedTextBox_PayDueDate.Text = pay.PayDueDate.Value.ToString("yyyy/MM/dd");
                    }

                 
                    if (pay.ActuallyPay.HasValue)
                    {
                        //實付金額
                        numericUpDown_ActuallyPay.Value = pay.ActuallyPay.Value;
                    }
                  

                    //完成日期
                    if (pay.IReceiptDate.HasValue)
                    {
                        maskedTextBox_IReceiptDate.Text = pay.IReceiptDate.Value.ToString("yyyy/MM/dd");
                    }
                   

                    //預估付款日
                    if (pay.EstimatedPaymentDate.HasValue)
                    {
                        maskedTextBox_EstimatedPaymentDate.Text = pay.EstimatedPaymentDate.Value.ToString("yyyy/MM/dd");
                    }


                    break;

                case 2:
                    Public.CTrademarkPayment TmPay = new Public.CTrademarkPayment();
                    Public.CTrademarkPayment.ReadOne(iPaymentID, ref TmPay);
                    txt_FeeSubject.Text = TmPay.FeeSubject;
                    txt_BillCheck.Text = TmPay.BillCheck;
                    txt_BillingNo.Text = TmPay.BillingNo;

                    if (string.IsNullOrEmpty(txt_SingCode.Text.Trim()))
                    {
                        lab_SingCode.Visible = true;
                    }

                    checkBox_IsBilling.Checked =TmPay.IsBilling.HasValue? TmPay.IsBilling.Value:false;
                    checkBox_IsCopyFile.Checked = TmPay.IsCopyFile.HasValue? TmPay.IsCopyFile.Value:false;
                    checkBox_IsScan.Checked = TmPay.IsScan.HasValue? TmPay.IsScan.Value:false;
                    if (TmPay.AcountingFirmKey.HasValue)
                    {
                        comboBox_AcountingFirmKey.SelectedValue = TmPay.AcountingFirmKey.Value;
                    }
                    txt_Memo.Text = TmPay.Memo;
                    txt_IMoney.Text = TmPay.IMoney;

                    //金額總計
                    txt_Totall.Text = TmPay.Totall.HasValue ? TmPay.Totall.Value.ToString("#,##0.##") : "0";

                    //當時匯率
                    numericUpDown_ExchangeRate.Value = TmPay.ExchangeRate.HasValue?TmPay.ExchangeRate.Value:1;

                  

                    if (TmPay.ReciveDate.HasValue)
                    {
                        maskedTextBox_ReciveDate.Text = TmPay.ReciveDate.Value.ToString("yyyy/MM/dd");
                    }

                    if (TmPay.PayDueDate.HasValue)
                    {
                        maskedTextBox_PayDueDate.Text = TmPay.PayDueDate.Value.ToString("yyyy/MM/dd");
                    }

                  
                    if(TmPay.ActuallyPay.HasValue)
                    {
                        //實付金額
                        numericUpDown_ActuallyPay.Value = TmPay.ActuallyPay.Value;
                    }
                   

                    if (TmPay.IReceiptDate.HasValue)
                    {
                        maskedTextBox_IReceiptDate.Text = TmPay.IReceiptDate.Value.ToString("yyyy/MM/dd");
                    }


                    if (TmPay.PaymentDate.HasValue)
                    {
                        maskedTextBox_PaymentDate.Text = TmPay.PaymentDate.Value.ToString("yyyy/MM/dd");
                    }

                    //預估付款日
                    if (TmPay.EstimatedPaymentDate.HasValue)
                    {
                        maskedTextBox_EstimatedPaymentDate.Text = TmPay.EstimatedPaymentDate.Value.ToString("yyyy/MM/dd");
                    }

                    break;
            }
        }
        #endregion

        #region but_Cancel_Click
        private void but_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region but_OK_Click
        private void but_OK_Click(object sender, EventArgs e)
        {
            Public.PublicForm Forms = new Public.PublicForm();


            switch (iTypeKind)
            {
                case 1: //專利付款 
                    Public.CPatentPayment pay = new Public.CPatentPayment();
                    Public.CPatentPayment.ReadOne(iPaymentID, ref pay); 
                  
                    pay.LastModifyWorker = Properties.Settings.Default.WorkerName;

                    pay.ExchangeRate = numericUpDown_ExchangeRate.Value;

                    //實付金額NT, 依所看到的值為主，台幣沒有小數點
                    decimal decActuallyPay;
                    bool isActuallyPay = decimal.TryParse(numericUpDown_ActuallyPay.Text, out decActuallyPay);
                    if (isActuallyPay)
                    {
                        pay.ActuallyPay = decActuallyPay;
                    }
                    else
                    {
                        pay.ActuallyPay = 0;
                    }
                    pay.BillCheck = txt_BillCheck.Text;
                    pay.BillingNo = txt_BillingNo.Text;
                   pay.IReceiptNo= txt_IReceiptNo.Text;
                    pay.AcountingFirmKey = comboBox_AcountingFirmKey.SelectedValue != null ? (int)comboBox_AcountingFirmKey.SelectedValue : -1;

                    DateTime dtPaymentDatePat;
                    bool IsPaymentDatePat = DateTime.TryParse(maskedTextBox_PaymentDate.Text, out dtPaymentDatePat);
                    if (IsPaymentDatePat)
                    {
                        pay.PaymentDate = dtPaymentDatePat;
                    }
                    else
                    {
                        pay.PaymentDate = null;
                    }


                    DateTime dtEstimatedPaymentDate;
                    bool IsEstimatedPaymentDate = DateTime.TryParse(maskedTextBox_EstimatedPaymentDate.Text, out dtEstimatedPaymentDate);
                    if (IsEstimatedPaymentDate)
                    {
                        pay.EstimatedPaymentDate = dtEstimatedPaymentDate;
                    }
                    else
                    {
                        pay.EstimatedPaymentDate =null;
                    }


                    DateTime dtIReceiptDate;
                    bool IsIReceiptDate = DateTime.TryParse(maskedTextBox_IReceiptDate.Text, out dtIReceiptDate);
                    if (IsIReceiptDate)
                    {
                        pay.IReceiptDate = dtIReceiptDate;
                    }
                    else
                    {
                        pay.IReceiptDate =null;
                    }




                    pay.IsCopyFile = checkBox_IsCopyFile.Checked;
                    pay.IsScan = checkBox_IsScan.Checked;
                    pay.IsBilling = checkBox_IsBilling.Checked;

                    pay.Memo = txt_Memo.Text;
                    pay.Update();


                    if (Forms.AccountingPaymentMF != null)
                    {
                        DataRow dr = Public.CAccountingPublicFunction.GetPATControlPaymentDataRow(pay.PaymentID.ToString());
                        for (int i = 0; i < Forms.AccountingPaymentMF.GetAccountingDataRow.ItemArray.Length; i++)
                        {
                            Forms.AccountingPaymentMF.GetAccountingDataRow.ItemArray[0] = dr.ItemArray;
                        }
                        Forms.AccountingPaymentMF.GetAccountingDataRow.AcceptChanges();
                    }


                    break;

                case 2://商標付款                  
                    Public.CTrademarkPayment TmPay = new Public.CTrademarkPayment();
                    Public.CTrademarkPayment.ReadOne(iPaymentID, ref TmPay);

                  
                    TmPay.LastModifyWorker = Properties.Settings.Default.WorkerName;
                    TmPay.AcountingFirmKey = comboBox_AcountingFirmKey.SelectedValue != null ? (int)comboBox_AcountingFirmKey.SelectedValue : -1;

                    TmPay.ExchangeRate = numericUpDown_ExchangeRate.Value;

                    //實付金額NT, 依所看到的值為主，台幣沒有小數點
                    decimal decActuallyPay_Tm;
                    bool isActuallyPay_Tm = decimal.TryParse(numericUpDown_ActuallyPay.Text, out decActuallyPay_Tm);
                    if (isActuallyPay_Tm)
                    {
                        TmPay.ActuallyPay = decActuallyPay_Tm;
                    }
                    else
                    {
                        TmPay.ActuallyPay = 0;
                    }

                    TmPay.BillCheck = txt_BillCheck.Text;
                    TmPay.BillingNo = txt_BillingNo.Text;
                    TmPay.IReceiptNo = txt_IReceiptNo.Text;

                    DateTime dtPaymentDate;
                    bool IsPaymentDate = DateTime.TryParse(maskedTextBox_PaymentDate.Text, out dtPaymentDate);
                    if (IsPaymentDate)
                    {
                        TmPay.PaymentDate = dtPaymentDate;
                    }
                    else
                    {
                        TmPay.PaymentDate =null;
                    }

                    DateTime dtEstimatedPaymentDate_TM;
                    bool IsEstimatedPaymentDateTM = DateTime.TryParse(maskedTextBox_EstimatedPaymentDate.Text, out dtEstimatedPaymentDate_TM);
                    if (IsEstimatedPaymentDateTM)
                    {
                        TmPay.EstimatedPaymentDate = dtEstimatedPaymentDate_TM;
                    }
                    else
                    {
                        TmPay.EstimatedPaymentDate =null;
                    }


                    DateTime dtIReceiptDate_TM;
                    bool IsIReceiptDate_TM = DateTime.TryParse(maskedTextBox_IReceiptDate.Text, out dtIReceiptDate_TM);
                    if (IsIReceiptDate_TM)
                    {
                        TmPay.IReceiptDate = dtIReceiptDate_TM;
                    }
                    else
                    {
                        TmPay.IReceiptDate = null;
                    }


                    TmPay.IsCopyFile = checkBox_IsCopyFile.Checked;
                    TmPay.IsScan = checkBox_IsScan.Checked;
                    TmPay.IsBilling = checkBox_IsBilling.Checked;
                    TmPay.Memo = txt_Memo.Text;
                    TmPay.Update();



                    if (Forms.AccountingPaymentMF != null)
                    {
                        dgvr.Cells["BillCheck"].Value = TmPay.BillCheck;
                        dgvr.Cells["BillingNo"].Value = TmPay.BillingNo;
                        dgvr.Cells["ExchangeRate"].Value = TmPay.ExchangeRate;
                        dgvr.Cells["ActuallyPay"].Value = TmPay.ActuallyPay;

                        if (TmPay.PaymentDate.HasValue)
                        {
                            dgvr.Cells["PaymentDate"].Value = TmPay.PaymentDate;
                        }
                        else
                        {
                            dgvr.Cells["PaymentDate"].Value = DBNull.Value;
                        }

                        if (TmPay.EstimatedPaymentDate.HasValue)
                        {
                            dgvr.Cells["EstimatedPaymentDate"].Value = TmPay.EstimatedPaymentDate;
                        }
                        else
                        {
                            dgvr.Cells["EstimatedPaymentDate"].Value = DBNull.Value;
                        }

                        if (TmPay.IReceiptDate.HasValue)
                        {
                            dgvr.Cells["IReceiptDate"].Value = TmPay.IReceiptDate;
                        }
                        else
                        {
                            dgvr.Cells["IReceiptDate"].Value = DBNull.Value;
                        }
                        dgvr.Cells["AcountingFirmName"].Value = comboBox_AcountingFirmKey.Text;
                        dgvr.Cells["Memo"].Value = TmPay.Memo;
                    }

                    break;
            }
            
            MessageBox.Show("更新成功", "提示訊息");
            this.Close();
        }
        #endregion

        #region maskedTextBox_PaymentDate_DoubleClick
        private void maskedTextBox_PaymentDate_DoubleClick(object sender, EventArgs e)
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

        #region numericUpDown_ExchangeRate_ValueChanged
        private void numericUpDown_ExchangeRate_ValueChanged(object sender, EventArgs e)
        {
            decimal decTotal = 0;
            bool bTotal = decimal.TryParse(txt_Totall.Text, out decTotal);
            if (bTotal)
            {
                numericUpDown_ActuallyPay.Value = numericUpDown_ExchangeRate.Value * decTotal;
            }
            else
            {
                numericUpDown_ActuallyPay.Value = 0;
            }
        }
        #endregion

        private void AccountingPaymentFinish_KeyDown(object sender, KeyEventArgs e)
        {
            Public.Utility.ControlTab(e);
        }

        private void maskedTextBox_EstimatedPaymentDate_Leave(object sender, EventArgs e)
        {
            MaskedTextBox mak = (MaskedTextBox)sender;
            Public.Utility.CheckMaskedtextbox(mak);
        }
    }
}
