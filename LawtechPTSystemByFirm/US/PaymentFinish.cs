using System;
using System.Windows.Forms;

namespace LawtechPTSystemByFirm.US
{
    public partial class PaymentFinish : Form
    {
        public PaymentFinish()
        {
            InitializeComponent();
        }

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


        private void PaymentFinish_Load(object sender, EventArgs e)
        {

            switch (iTypeKind)
            {
                case 1:
                    Public.CPatentPayment pay = new LawtechPTSystemByFirm.Public.CPatentPayment();
                    Public.CPatentPayment.ReadOne(iPaymentID, ref pay);

                    txt_FeeSubject.Text = pay.FeeSubject;
                    txt_BillCheck.Text = pay.BillCheck;
                    txt_BillingNo.Text = pay.BillingNo;
                    //txt_Memo.Text = pay.Memo;
                    txt_IMoney.Text = pay.IMoney;
                    txt_ExchangeRate.Text = pay.ExchangeRate.HasValue ? pay.ExchangeRate.Value.ToString("#,##0.##") : "0";

                    maskedTextBox_ReciveDate.Text = pay.ReciveDate.HasValue ? pay.ReciveDate.Value.ToString("yyyy/MM/dd") : "";

                    maskedTextBox_PaymentDate.Text = pay.PaymentDate.HasValue ? pay.PaymentDate.Value.ToString("yyyy/MM/dd") : "";


                    //checkBox_IsBilling.Checked = pay.IsBilling;
                    //checkBox_IsCopyFile.Checked = pay.IsCopyFile;
                    //checkBox_IsScan.Checked = pay.IsScan;

                    maskedTextBox_PayDueDate.Text = pay.PayDueDate.HasValue ? pay.PayDueDate.Value.ToString("yyyy/MM/dd") : "";

                    txt_Totall.Text = pay.Totall.HasValue ? pay.Totall.Value.ToString("#,##0.##") : "0";

                    maskedTextBox_IReceiptDate.Text = pay.IReceiptDate.HasValue ? pay.IReceiptDate.Value.ToString("yyyy/MM/dd") : DateTime.Now.ToString("yyyy/MM/dd");


                    break;

                case 2:
                     Public.CTrademarkPayment TmPay = new LawtechPTSystemByFirm.Public.CTrademarkPayment();
                    Public.CTrademarkPayment.ReadOne(iPaymentID, ref TmPay);
                   
                    txt_FeeSubject.Text = TmPay.FeeSubject;
                    txt_BillCheck.Text = TmPay.BillCheck;
                    txt_BillingNo.Text = TmPay.BillingNo;
                    //checkBox_IsBilling.Checked = TmPay.IsBilling;
                    //checkBox_IsCopyFile.Checked = TmPay.IsCopyFile;
                    //checkBox_IsScan.Checked = TmPay.IsScan;
                    //txt_Memo.Text = TmPay.Memo;
                    txt_IMoney.Text = TmPay.IMoney;
                    if (TmPay.ExchangeRate.HasValue)
                    {
                        txt_ExchangeRate.Text = TmPay.ExchangeRate.Value.ToString("#,##0.##");
                    }
                    else {
                        txt_ExchangeRate.Text ="0";
                    }

                    if (TmPay.ReciveDate.HasValue)
                    {
                        maskedTextBox_ReciveDate.Text = TmPay.ReciveDate.Value.ToString("yyyy/MM/dd");
                    }

                    if (TmPay.PayDueDate.HasValue)
                    {
                        maskedTextBox_PayDueDate.Text = TmPay.PayDueDate.Value.ToString("yyyy/MM/dd");
                    }

                    txt_Totall.Text = TmPay.Totall.Value.ToString("#,##0.##");


                    if (TmPay.IReceiptDate.HasValue)
                    {
                        maskedTextBox_IReceiptDate.Text = TmPay.IReceiptDate.Value.ToString("yyyy/MM/dd");
                    }
                    else
                    {
                        maskedTextBox_IReceiptDate.Text = DateTime.Now.ToString("yyyy/MM/dd");
                    }

                    if (TmPay.PaymentDate.HasValue)
                    {
                        maskedTextBox_PaymentDate.Text = TmPay.PaymentDate.Value.ToString("yyyy/MM/dd");
                    }


                    break;
                case 3:
                    Public.CTrademarkControversyPayment TmCoPay = new LawtechPTSystemByFirm.Public.CTrademarkControversyPayment("ControversyPaymentID=" + iPaymentID.ToString());
                    TmCoPay.SetCurrent(iPaymentID);
                    txt_FeeSubject.Text = TmCoPay.FeeSubject;
                    txt_BillCheck.Text = TmCoPay.BillCheck;
                    txt_BillingNo.Text = TmCoPay.BillingNo;
                    //checkBox_IsBilling.Checked = TmPay.IsBilling;
                    //checkBox_IsCopyFile.Checked = TmPay.IsCopyFile;
                    //checkBox_IsScan.Checked = TmPay.IsScan;
                    //txt_Memo.Text = TmPay.Memo;
                    txt_IMoney.Text = TmCoPay.IMoney;
                    txt_ExchangeRate.Text = TmCoPay.ExchangeRate.ToString("#,##0.##");

                    if (TmCoPay.ReciveDate.Year > 1900)
                    {
                        maskedTextBox_ReciveDate.Text = TmCoPay.ReciveDate.ToString("yyyy/MM/dd");
                    }

                    if (TmCoPay.PayDueDate.Year > 1900)
                    {
                        maskedTextBox_PayDueDate.Text = TmCoPay.PayDueDate.ToString("yyyy/MM/dd");
                    }

                    txt_Totall.Text = TmCoPay.Totall.ToString("#,##0.##");


                    if (TmCoPay.IReceiptDate.Year > 1900)
                    {
                        maskedTextBox_IReceiptDate.Text = TmCoPay.IReceiptDate.ToString("yyyy/MM/dd");
                    }
                    else
                    {
                        maskedTextBox_IReceiptDate.Text = DateTime.Now.ToString("yyyy/MM/dd");
                    }

                    if (TmCoPay.PaymentDate.Year > 1900)
                    {
                        maskedTextBox_PaymentDate.Text = TmCoPay.PaymentDate.ToString("yyyy/MM/dd");
                    }


                    break;
            }
        }

        private void but_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void maskedTextBox_IReceiptDate_DoubleClick(object sender, EventArgs e)
        {
            MaskedTextBox mtb = (MaskedTextBox)sender;
            DateTime dt;
            bool IsSuccess = DateTime.TryParse(mtb.Text, out dt);
            if (!IsSuccess)
            {
                mtb.Text = DateTime.Now.ToString("yyyy/MM/dd");
            }
        }

        private void but_OK_Click(object sender, EventArgs e)
        {
            Public.PublicForm Forms = new LawtechPTSystemByFirm.Public.PublicForm();

            DateTime dtPaymentDate;
            bool IsPaymentDate = DateTime.TryParse(maskedTextBox_PaymentDate.Text, out dtPaymentDate);

            switch (iTypeKind)
            {
                case 1:
                   

                    if (IsPaymentDate)
                    {
                        Public.CPatentPayment pay = new LawtechPTSystemByFirm.Public.CPatentPayment();
                        Public.CPatentPayment.ReadOne(iPaymentID, ref pay);
                    
                        pay.LastModifyWorker = Properties.Settings.Default.WorkerName;
                        //pay.IReceiptDate = dtIReceiptDatePat;
                        //pay.Memo = txt_Memo.Text;

                        pay.BillCheck = txt_BillCheck.Text;
                        pay.BillingNo = txt_BillingNo.Text;
                        //pay.IsBilling = checkBox_IsBilling.Checked;
                        //pay.IsCopyFile = checkBox_IsCopyFile.Checked;
                        //pay.IsScan = checkBox_IsScan.Checked;

                        //DateTime dtPaymentDate;
                        //bool IsPaymentDate = DateTime.TryParse(maskedTextBox_PaymentDate.Text, out dtPaymentDate);
                        //if (IsPaymentDate)
                        //{
                        //    pay.PaymentDate = dtPaymentDate;
                        //}
                        //else
                        //{
                        //    pay.PaymentDate = new DateTime(1900,1,1);
                        //}


                        pay.Update();

                       
                        if (Forms.PATControlEvent != null)
                        {
                            dgvr.Cells["FinishDate"].Value = pay.IReceiptDate;
                            dgvr.Cells["Result"].Value = pay.Remark;
                        }

                        if (Forms.AccountingPaymentMF != null)
                        {
                            dgvr.Cells["BillCheck"].Value = pay.BillCheck;
                            dgvr.Cells["BillingNo"].Value = pay.BillingNo;
                            if (pay.PaymentDate.HasValue)
                            {
                                dgvr.Cells["PaymentDate"].Value = pay.PaymentDate;
                            }
                            else
                            {
                                dgvr.Cells["PaymentDate"].Value = DBNull.Value;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("付款日期是空，表示尚未付款，不允許填完成日期，請再確認", "提示訊息");
                        return;
                    }

                    break;

                case 2:
                   

                    if (IsPaymentDate)
                    {
                        Public.CTrademarkPayment TmPay = new LawtechPTSystemByFirm.Public.CTrademarkPayment();
                        Public.CTrademarkPayment.ReadOne(iPaymentID, ref TmPay); 
                     
                        TmPay.LastModifyWorker = Properties.Settings.Default.WorkerName;
                        //TmPay.Memo = txt_Memo.Text;

                        //TmPay.BillCheck = txt_BillCheck.Text;
                        //TmPay.BillingNo = txt_BillingNo.Text;
                        //TmPay.IsBilling = checkBox_IsBilling.Checked;
                        //TmPay.IsCopyFile = checkBox_IsCopyFile.Checked;
                        //TmPay.IsScan = checkBox_IsScan.Checked;

                        
                        bool IsIReceiptDate = DateTime.TryParse(maskedTextBox_IReceiptDate.Text, out dtPaymentDate);
                        if (IsPaymentDate)
                        {
                            TmPay.PaymentDate = dtPaymentDate;
                        }
                        else
                        {
                            TmPay.PaymentDate = null;
                        }

                        TmPay.Update();
                        if (Forms.TrademarkControlEvent != null)
                        {
                            dgvr.Cells["FinishDate"].Value = TmPay.IReceiptDate;
                            dgvr.Cells["Result"].Value = TmPay.Remark;
                        }

                        if (Forms.AccountingPaymentMF != null)
                        {
                            dgvr.Cells["BillCheck"].Value = TmPay.BillCheck;
                            dgvr.Cells["BillingNo"].Value = TmPay.BillingNo;
                            if (TmPay.PaymentDate.HasValue)
                            {
                                dgvr.Cells["PaymentDate"].Value = TmPay.PaymentDate;
                            }
                            else
                            {
                                dgvr.Cells["PaymentDate"].Value = DBNull.Value;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("付款日期是空，表示尚未付款，不允許填完成日期，請再確認", "提示訊息");
                        return;
                    }
                    break;

                case 3:


                    if (IsPaymentDate)
                    {
                        Public.CTrademarkControversyPayment TmCOPay = new LawtechPTSystemByFirm.Public.CTrademarkControversyPayment("ControversyPaymentID=" + iPaymentID.ToString());
                        TmCOPay.SetCurrent(iPaymentID);

                        TmCOPay.LastModifyDate = DateTime.Now;
                        TmCOPay.LastModifyWorker = Properties.Settings.Default.WorkerKEY;
                        //TmPay.Memo = txt_Memo.Text;

                        //TmPay.BillCheck = txt_BillCheck.Text;
                        //TmPay.BillingNo = txt_BillingNo.Text;
                        //TmPay.IsBilling = checkBox_IsBilling.Checked;
                        //TmPay.IsCopyFile = checkBox_IsCopyFile.Checked;
                        //TmPay.IsScan = checkBox_IsScan.Checked;


                        bool IsIReceiptDate = DateTime.TryParse(maskedTextBox_IReceiptDate.Text, out dtPaymentDate);
                        if (IsPaymentDate)
                        {
                            TmCOPay.PaymentDate = dtPaymentDate;
                        }
                        else
                        {
                            TmCOPay.PaymentDate = new DateTime(1900, 1, 1);
                        }

                        TmCOPay.Updata(iPaymentID);
                        if (Forms.TrademarkControlEvent != null)
                        {
                            dgvr.Cells["FinishDate"].Value = TmCOPay.IReceiptDate;
                            dgvr.Cells["Result"].Value = TmCOPay.Remark;
                        }

                        if (Forms.AccountingPaymentMF != null)
                        {
                            dgvr.Cells["BillCheck"].Value = TmCOPay.BillCheck;
                            dgvr.Cells["BillingNo"].Value = TmCOPay.BillingNo;
                            if (TmCOPay.PaymentDate.Year > 1900)
                            {
                                dgvr.Cells["PaymentDate"].Value = TmCOPay.PaymentDate;
                            }
                            else
                            {
                                dgvr.Cells["PaymentDate"].Value = DBNull.Value;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("付款日期是空，表示尚未付款，不允許填完成日期，請再確認", "提示訊息");
                        return;
                    }
                    break;
            }

           

            MessageBox.Show("更新成功","提示訊息");
            this.Close();
        }

       
    }
}
