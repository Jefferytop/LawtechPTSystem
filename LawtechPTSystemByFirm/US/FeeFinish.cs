using System;
using System.Windows.Forms;

namespace LawtechPTSystemByFirm.US
{
    public partial class FeeFinish : Form
    {
        public FeeFinish()
        {
            InitializeComponent();
        }

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


        private void FeeFinish_Load(object sender, EventArgs e)
        {
            switch (iTypeKind)
            {             
                case 1:
                    Public.CPatentFee fee = new LawtechPTSystemByFirm.Public.CPatentFee();
                    Public.CPatentFee.ReadOne(iFeeKey, ref fee);
                    
                    txt_FeeSubject.Text = fee.FeeSubject;
                    txt_PPP.Text = fee.PPP;
                    txt_PayKind.Text = fee.PayKind;
                    txt_Remark.Text = fee.Remark;

                    if (fee.ReceiptDate.HasValue)
                    {
                        maskedTextBox_ReceiptDate.Text = fee.ReceiptDate.Value.ToString("yyyy/MM/dd");
                    }

                    if (fee.PayDate.HasValue)
                    {
                        maskedTextBox_PayDate.Text = fee.PayDate.Value.ToString("yyyy/MM/dd");
                    }
                    if (fee.Tax.HasValue)
                        numericUpDown_Tax.Value = fee.Tax.HasValue?fee.Tax.Value:0;
                    numericUpDown_PracicalityPay.Value = fee.PracticalityPay.HasValue ? fee.PracticalityPay.Value : 0;
                    checkBox_NT.Checked = fee.NT.HasValue ? fee.NT.Value : false;
                    chkWithholding.Checked = fee.Withholding.HasValue ? fee.Withholding.Value :false;
                    checkBox_Pay.Checked = fee.Pay.HasValue ? fee.Pay.Value : false;
                    break;

                case 2:
                    Public.CTrademarkFee Tmfee = new LawtechPTSystemByFirm.Public.CTrademarkFee();
                    Public.CTrademarkFee.ReadOne(iFeeKey, ref Tmfee);
                    txt_FeeSubject.Text = Tmfee.FeeSubject;
                    txt_PPP.Text = Tmfee.PPP;
                    txt_PayKind.Text = Tmfee.PayKind;
                    txt_Remark.Text = Tmfee.Remark;

                    if (Tmfee.ReceiptDate.HasValue)
                    {
                        maskedTextBox_ReceiptDate.Text = Tmfee.ReceiptDate.Value.ToString("yyyy/MM/dd");
                    }

                    if (Tmfee.PayDate.HasValue)
                    {
                        maskedTextBox_PayDate.Text = Tmfee.PayDate.Value.ToString("yyyy/MM/dd");
                    }
                    numericUpDown_Tax.Value = Tmfee.Tax.HasValue? Tmfee.Tax.Value:0;
                    numericUpDown_PracicalityPay.Value =Tmfee.PracticalityPay.HasValue? Tmfee.PracticalityPay.Value:0;
                    checkBox_NT.Checked = Tmfee.NT.HasValue? Tmfee.NT.Value:false;
                    chkWithholding.Checked = Tmfee.Withholding.HasValue? Tmfee.Withholding.Value:false;
                    checkBox_Pay.Checked = Tmfee.Pay.HasValue ? Tmfee.Pay.Value : false;
                    
                    break;

                case 3:
                    Public.CTrademarkControversyFee TmControversyfee = new LawtechPTSystemByFirm.Public.CTrademarkControversyFee("ControversyFeeKEY=" + iFeeKey.ToString());
                    TmControversyfee.SetCurrent(iFeeKey);
                    txt_FeeSubject.Text = TmControversyfee.FeeSubject;
                    txt_PPP.Text = TmControversyfee.PPP;
                    txt_PayKind.Text = TmControversyfee.PayKind;
                    txt_Remark.Text = TmControversyfee.Remark;

                    if (TmControversyfee.ReceiptDate.Year > 1900)
                    {
                        maskedTextBox_ReceiptDate.Text = TmControversyfee.ReceiptDate.ToString("yyyy/MM/dd");
                    }

                    if (TmControversyfee.PayDate.Year > 1900)
                    {
                        maskedTextBox_PayDate.Text = TmControversyfee.PayDate.ToString("yyyy/MM/dd");
                    }
                    numericUpDown_Tax.Value = TmControversyfee.Tax;
                    numericUpDown_PracicalityPay.Value = TmControversyfee.PracticalityPay;
                    checkBox_NT.Checked = TmControversyfee.NT;
                    chkWithholding.Checked = TmControversyfee.Withholding;
                    checkBox_Pay.Checked = TmControversyfee.Pay;

                    break;
            }
        }

        private void but_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void but_OK_Click(object sender, EventArgs e)
        {
            Public.PublicForm Forms = new LawtechPTSystemByFirm.Public.PublicForm();
            switch (iTypeKind)
            {
                case 1:
                    Public.CPatentFee fee = new LawtechPTSystemByFirm.Public.CPatentFee();
                    Public.CPatentFee.ReadOne(iFeeKey, ref fee);

                    fee.Pay = checkBox_Pay.Checked != true ? false : true;//已請款
                    fee.PPP = txt_PPP.Text;
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


                    fee.NT = checkBox_NT.Checked != true ? false : true;//外幣支付
                    fee.PracticalityPay = numericUpDown_PracicalityPay.Value;//實際請款
                    fee.Withholding = chkWithholding.Checked != true ? false : true;//已預扣
                    fee.Tax = numericUpDown_Tax.Value;//預扣稅額
                    fee.PayKind = txt_PayKind.Text;//付款方式
                    fee.Remark = txt_Remark.Text;
                    fee.LastModifyDateTime = DateTime.Now;
                    fee.LastModifyWorker = Properties.Settings.Default.WorkerName;
                    fee.Update();

                    if (Forms.AccountingFeeList != null && Forms.AccountingFeeList.GV_CurrentRow != null)
                    {
                        DataGridViewRow gvr = Forms.AccountingFeeList.GV_CurrentRow;
                        gvr.Cells["PPP"].Value = fee.PPP;
                        //收據日期
                        if (fee.ReceiptDate.HasValue)
                        {
                            gvr.Cells["ReceiptDate"].Value = fee.ReceiptDate;
                        }
                        else
                        {
                            gvr.Cells["ReceiptDate"].Value = DBNull.Value;
                        }

                        //收款日期
                        if (fee.PayDate.HasValue)
                        {
                            gvr.Cells["PayDate"].Value = fee.PayDate;
                        }
                        else
                        {
                            gvr.Cells["PayDate"].Value = DBNull.Value;
                        }
                        gvr.Cells["PracticalityPay"].Value = fee.PracticalityPay;
                        gvr.Cells["Remark"].Value = fee.Remark;
                        gvr.Cells["Tax"].Value = fee.Tax;
                    }
                    break;

                case 2:
                    Public.CTrademarkFee Tmfee = new LawtechPTSystemByFirm.Public.CTrademarkFee();
                    Public.CTrademarkFee.ReadOne(iFeeKey, ref Tmfee);

                    Tmfee.Pay = checkBox_Pay.Checked != true ? false : true;//已請款
                    Tmfee.PPP = txt_PPP.Text;
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

                    Tmfee.NT = checkBox_NT.Checked != true ? false : true;//外幣支付
                    Tmfee.PracticalityPay = numericUpDown_PracicalityPay.Value;//實際請款
                    Tmfee.Withholding = chkWithholding.Checked != true ? false : true;//已預扣
                    Tmfee.Tax = numericUpDown_Tax.Value;//預扣稅額
                    Tmfee.PayKind = txt_PayKind.Text;//付款方式
                    Tmfee.Remark = txt_Remark.Text;

                    Tmfee.LastModifyWorker = Properties.Settings.Default.WorkerName;
                    Tmfee.Update();


                    if (Forms.AccountingFeeList != null && Forms.AccountingFeeList.GV_CurrentRow != null)
                    {
                        DataGridViewRow gvr = Forms.AccountingFeeList.GV_CurrentRow;
                        gvr.Cells["PPP"].Value = Tmfee.PPP;
                        //收據日期
                        if (Tmfee.ReceiptDate.HasValue)
                        {
                            gvr.Cells["ReceiptDate"].Value = Tmfee.ReceiptDate;
                        }
                        else
                        {
                            gvr.Cells["ReceiptDate"].Value = DBNull.Value;
                        }

                        //收款日期
                        if (Tmfee.PayDate.HasValue)
                        {
                            gvr.Cells["PayDate"].Value = Tmfee.PayDate;
                        }
                        else
                        {
                            gvr.Cells["PayDate"].Value = DBNull.Value;
                        }
                        gvr.Cells["PracticalityPay"].Value = Tmfee.PracticalityPay;
                        gvr.Cells["Remark"].Value = Tmfee.Remark;
                        gvr.Cells["Tax"].Value = Tmfee.Tax;
                    }
                    break;

                case 3: //CO
                    Public.CTrademarkControversyFee TmControversyfee = new LawtechPTSystemByFirm.Public.CTrademarkControversyFee("ControversyFeeKEY=" + iFeeKey.ToString());
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
                    TmControversyfee.Tax = numericUpDown_Tax.Value;//預扣稅額
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

        private void maskedTextBox_ReceiptDate_DoubleClick(object sender, EventArgs e)
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
                Public.CPatentFee fee = new LawtechPTSystemByFirm.Public.CPatentFee();
                Public.CPatentFee.ReadOne(iFeeKey, ref fee);
                ppp.MainKey = fee.PatentID;
            }
            else if (TypeKind == 2)
            {
                Public.CTrademarkFee fee = new LawtechPTSystemByFirm.Public.CTrademarkFee();
                Public.CTrademarkFee.ReadOne(iFeeKey, ref fee);
                ppp.MainKey = fee.TrademarkID;
            }
            else if (TypeKind == 3)
            {
                Public.CTrademarkControversyFee fee = new LawtechPTSystemByFirm.Public.CTrademarkControversyFee("ControversyFeeKEY=" + iFeeKey.ToString());
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

      
    }
}
