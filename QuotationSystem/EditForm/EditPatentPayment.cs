using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LawtechPTSystem.EditForm
{
    public partial class EditPatentPayment : Form
    {
        public EditPatentPayment()
        {
            InitializeComponent();
        }

        private string sCountrySymbol = "";
        /// <summary>
        /// 國別
        /// </summary>
        public string CountrySymbol
        {
            get { return sCountrySymbol; }
            set { sCountrySymbol = value; }
        }

        private int iPaymentID = -1;
        /// <summary>
        /// 付款費用資料表 ID
        /// </summary>
        public int property_PaymentID
        {
            get { return iPaymentID; }
            set { iPaymentID = value; }
        }


        private int iWorkerID = -1;
        /// <summary>
        /// 登入者的Key
        /// </summary>
        public int WorkerID
        {
            get { return iWorkerID; }
            set { iWorkerID = value; }
        }

        private string strWorkerName = "";
        /// <summary>
        /// 登入者的名字
        /// </summary>
        public string WorkerName
        {
            get { return strWorkerName; }
            set { strWorkerName = value; }
        }


        private int iOfficeRole = -1;
        /// <summary>
        /// 登入者的權限身份 1.員工 2.專利主管 3.商標主管 0.admin
        /// </summary>
        public int OfficeRole
        {
            get { return iOfficeRole; }
            set { iOfficeRole = value; }
        }


        private void but_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region =========but_OK_Click============
        private void but_OK_Click(object sender, EventArgs e)
        {
            Public.CPatentPayment payment = new Public.CPatentPayment();
            Public.CPatentPayment.ReadOne(iPaymentID, ref payment);
          
            payment.FeeSubject = txt_FeeSubject.Text;
            payment.FeePhase = (int)comboBox_FeePhase.SelectedValue;
            if (comboBox_FClientTransactor.SelectedValue != null)//請款人
            {
                payment.FClientTransactor = (int)comboBox_FClientTransactor.SelectedValue;
            }
            else
            {
                payment.FClientTransactor = -1;
            }
            payment.PayKind = comboBox_PayKind.Text;

            if (comboBox_IMoney.SelectedValue != null)
            {
                payment.IMoney = comboBox_IMoney.SelectedValue.ToString();
            }
            else
            {
                payment.IMoney = "";
            }

            if (comboBox_Attormey.SelectedValue != null)//受款人
            {
                payment.Attorney = (int)comboBox_Attormey.SelectedValue;
            }
            else
            {
                payment.Attorney = null;
            }

            decimal decIServiceFee = 0;
            decimal.TryParse(txt_IServiceFee.Text, out decIServiceFee);
            payment.IServiceFee = decIServiceFee;

            decimal decGovFee = 0;
            decimal.TryParse(txt_GovFee.Text, out decGovFee);
            payment.GovFee = decGovFee;

            decimal decOtherFee = 0;
            decimal.TryParse(txt_OtherFee.Text, out decOtherFee);
            payment.OtherFee = decOtherFee;

            decimal decTotall = 0;
            decimal.TryParse(txt_Totall.Text, out decTotall);
            payment.Totall = decTotall;

            payment.IReceiptNo = txt_IReceiptNo.Text;
            payment.SingCode = txt_SingcCode.Text;//主管簽核
            payment.ExchangeRate = numericUpDown_ExchangeRate.Value;

            DateTime dt_IReceiptDate ;
            bool IsIReceiptDate= DateTime.TryParse(maskedTextBox_IReceiptDate.Text, out dt_IReceiptDate);
            if (IsIReceiptDate) payment.IReceiptDate = dt_IReceiptDate;
            else payment.IReceiptDate = null;

            DateTime dt_ReciveDate ;
            bool IsReciveDate=DateTime.TryParse(maskedTextBox_ReciveDate.Text, out dt_ReciveDate);
            if (IsReciveDate) payment.ReciveDate = dt_ReciveDate;
            else payment.ReciveDate = null;

            DateTime dt_PayDueDate ;
            bool IsPayDueDate=  DateTime.TryParse(maskedTextBox_PayDueDate.Text, out dt_PayDueDate);
            if (IsPayDueDate) payment.PayDueDate = dt_PayDueDate;
            else payment.PayDueDate = null;

            payment.Remark = txt_Remark.Text;
            payment.SingCodeStatus = txt_SingCodeStatus.Text + txt_SingCodeStatus_N.Text;

            //payment.BillingNo = txt_BillingNo.Text;
            //payment.BillCheck = txt_BillCheck.Text;
            //payment.IsBilling = checkBox_IsBilling.Checked;
            //payment.IsCopyFile = checkBox_IsCopyFile.Checked;
            //payment.IsScan = checkBox_IsScan.Checked;
          
            payment.LastModifyWorker = Properties.Settings.Default.WorkerName;

            payment.Update();

            Public.PublicForm Forms = new Public.PublicForm();

            #region  Forms.PatListMF
            if (Forms.PatListMF != null && Forms.PatListMF.DT_PatentPaymentT != null)
            {
                DataRow dr = Forms.PatListMF.DT_PatentPaymentT.Rows.Find(payment.PaymentID);
                
                DataRow drV = Public.CPatentPublicFunction.GetPatentPaymentTDataRow(property_PaymentID.ToString());
                dr.ItemArray = drV.ItemArray;
                dr.AcceptChanges();
            }
             #endregion
           
            #region Forms.AccountingPaymentMF
            if (Forms.AccountingPaymentMF != null && Forms.AccountingPaymentMF.GetAccountingData != null)
            {
                DataRow dr = Forms.AccountingPaymentMF.GetAccountingDataRow;
                if (dr != null)
                {
                 DataRow drV=   Public.CAccountingPublicFunction.GetPATControlPaymentDataRow(payment.PaymentID.ToString());
                 dr.ItemArray = drV.ItemArray;
                 dr.AcceptChanges();
                }
            }
            #endregion

            MessageBox.Show("修改成功", "提示訊息", MessageBoxButtons.OK);
            this.Close();
        }
        #endregion

        #region =============EditPatentPayment_Load==================
        private void EditPatentPayment_Load(object sender, EventArgs e)
        {

            this.attorneyTTableAdapter.Fill(this.dataSet_Drop.AttorneyT);

            this.payKindTableAdapter.Fill(this.dataSet_Drop.PayKind);
            this.workerTAllTableAdapter.Fill(this.qS_DataSet.WorkerTAll);
            this.moneyTTableAdapter.Fill(this.dataSet_Drop.MoneyT);
            this.feePhaseTByPatTableAdapter.Fill(this.dataSet_Drop.FeePhaseTByPat);

            Public.CPatentPayment edit = new Public.CPatentPayment();
            Public.CPatentPayment.ReadOne(iPaymentID, ref edit);


            txt_FeeSubject.Text = edit.FeeSubject;
            if (edit.FeePhase.HasValue)
            {
                comboBox_FeePhase.SelectedValue = edit.FeePhase;
            }
            if (edit.FClientTransactor.HasValue)
            {
                comboBox_FClientTransactor.SelectedValue = edit.FClientTransactor;
            }
            comboBox_PayKind.Text = edit.PayKind;
           
            comboBox_IMoney.SelectedValue = edit.IMoney;

          
            txt_IServiceFee.Text =edit.IServiceFee.HasValue? edit.IServiceFee.ToString():"";

            txt_GovFee.Text =edit.GovFee.HasValue? edit.GovFee.ToString():"";

            txt_OtherFee.Text =edit.OtherFee.HasValue? edit.OtherFee.ToString():"";

            txt_Totall.Text = edit.Totall.HasValue ? edit.Totall.ToString() : "";

            txt_IReceiptNo.Text = edit.IReceiptNo;

            txt_SingcCode.Text = edit.SingCode;//主管簽核

            txt_SingCodeStatus.Text = edit.SingCodeStatus;

            numericUpDown_ExchangeRate.Value=edit.ExchangeRate.HasValue?edit.ExchangeRate.Value:0;

            maskedTextBox_IReceiptDate.Text = edit.IReceiptDate.HasValue ? edit.IReceiptDate.Value.ToString("yyyy/MM/dd") : "";

            maskedTextBox_ReciveDate.Text = edit.ReciveDate.HasValue ? edit.ReciveDate.Value.ToString("yyyy/MM/dd") : "";

            maskedTextBox_PayDueDate.Text = edit.PayDueDate.HasValue ? edit.PayDueDate.Value.ToString("yyyy/MM/dd") : "";

            comboBox_Attormey.SelectedValue = edit.Attorney;

            txt_Remark.Text = edit.Remark;

            //取得登入者身份
            iWorkerID = Properties.Settings.Default.WorkerKEY;
            Worker_Model worker = new Worker_Model();
            Worker_Model.ReadOne(iWorkerID, ref  worker);
            iOfficeRole = worker.OfficeRole.Value;
            strWorkerName = worker.EmployeeName;

            SetOfficeRole();

        }
        #endregion

        #region =============txt_IServiceFee_TextChanged===============
        private void txt_IServiceFee_TextChanged(object sender, EventArgs e)
        {
            double doubleIServiceFee = 0;
            bool bIServiceFee = double.TryParse(txt_IServiceFee.Text, out doubleIServiceFee);

            double doubleGovFee = 0;
            bool bGovFee = double.TryParse(txt_GovFee.Text, out doubleGovFee);

            double doubleOtherFee = 0;
            bool bOtherFee = double.TryParse(txt_OtherFee.Text, out doubleOtherFee);

            if (bIServiceFee && bGovFee && bOtherFee)
            {
                txt_Totall.Text = (doubleIServiceFee + doubleGovFee + doubleOtherFee).ToString("#,##0.####");
            }
            else
            {
                if (!bIServiceFee)
                {
                    txt_IServiceFee.Text = "0";
                }
                if (!bGovFee)
                {
                    txt_GovFee.Text = "0";
                }
                if (!bOtherFee)
                {
                    txt_OtherFee.Text = "0";
                }
            }
        }
        #endregion

        #region =============maskedTextBox_ReciveDate_DoubleClick================
        private void maskedTextBox_ReciveDate_DoubleClick(object sender, EventArgs e)
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

        #region ==========comboBox_IMoney_SelectedIndexChanged=============
        private void comboBox_IMoney_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_IMoney.SelectedItem != null)
            {
                numericUpDown_ExchangeRate.Text = ((System.Data.DataRowView)(comboBox_IMoney.SelectedItem)).Row["ToNT"].ToString();
            }
        }
        #endregion

        #region OfficeRole()
        public void SetOfficeRole()
        {
            switch (iOfficeRole)
            {
                case 1:
                case 3:
                    label12.Visible = true;
                    but_SingOff.Visible = false;
                    break;
                case 2:
                case 0:
                    label12.Visible = false;
                    but_SingOff.Visible = true;
                    if (txt_SingcCode.Text.Contains(strWorkerName))
                    {
                        but_SingOff.Text = "取消簽核";
                        but_SingOff.Tag = "Cancel";
                    }
                    else
                    {
                        but_SingOff.Text = "簽核";
                        but_SingOff.Tag = "Sing";
                    }
                    break;


            }
        }
        #endregion

        #region ===========SingOffName==============
        private string SingOffName(string Name)
        {
            string ReValue = "";
            if (but_SingOff.Tag.ToString() == "Sing")//簽核
            {
                txt_SingcCode.Text += ";" + Name;
            }
            else//取消簽核
            {
                txt_SingcCode.Text = txt_SingcCode.Text.Replace(Name, "");
            }

            string[] sSingName = txt_SingcCode.Text.Split(';');

            for (int iLenght = 0; iLenght < sSingName.Length; iLenght++)
            {
                if (sSingName[iLenght] != "")
                {
                    ReValue += sSingName[iLenght];
                    if (iLenght < sSingName.Length - 1)
                    {
                        ReValue += ";";
                    }
                }
            }

            return ReValue;
        }
        #endregion

        #region ============but_SingOff_Click================
        private void but_SingOff_Click(object sender, EventArgs e)
        {
            US.SingCode sing = new LawtechPTSystem.US.SingCode();
            sing.ShowDialog();
            if (sing.IsSuccess)
            {
                txt_SingcCode.Text = SingOffName(strWorkerName);
                //txt_SingCodeStatus.Text = "";
                if (but_SingOff.Tag.ToString() == "Sing")
                {
                    but_SingOff.Tag = "Cancel";
                    but_SingOff.Text = "取消簽核";
                    txt_SingCodeStatus_N.Text = "★" + WorkerName + DateTime.Now.ToString("yyyy-MM-dd HH:mm") + "簽核\r\n";
                }
                else
                {
                    but_SingOff.Text = "簽核";
                    but_SingOff.Tag = "Sing";
                    txt_SingCodeStatus_N.Text = "Ⅹ" + WorkerName + DateTime.Now.ToString("yyyy-MM-dd HH:mm") + "取消簽核\r\n";
                }
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

                    US.CalculationDate Calculation = new LawtechPTSystem.US.CalculationDate();
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

        private void EditPatentPayment_FormClosed(object sender, FormClosedEventArgs e)
        {
            Public.Utility.NuLockRecordAuth("PatentPaymentT", "PaymentID=" + property_PaymentID.ToString());
        }

        private void EditPatentPayment_KeyDown(object sender, KeyEventArgs e)
        {
            Public.Utility.ControlTab(e);
        }

        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Name)
            {
                case "ToolStripMenuItem_All":
                    checkBox_All.Checked = true;
                    attorneyTBindingSource.Filter = "";
                    break;
                case "ToolStripMenuItem_CurrentCountry":
                    if (CountrySymbol != "")
                    {
                        checkBox_All.Checked = false;
                        attorneyTBindingSource.Filter = "CountrySymbol ='" + CountrySymbol + "'";
                    }
                    break;
            }
        }

        #region private void comboBox_FeePhase_SelectedIndexChanged(object sender, EventArgs e)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox_FeePhase_SelectedIndexChanged(object sender, EventArgs e)
        {
            string strFeeItem = txt_FeeSubject.Text;
            if (comboBox_FeePhase.SelectedValue != null)
            {
                feePhaseItemsTTableAdapter.Fill(this.dataSet_Drop.FeePhaseItemsT, (int)comboBox_FeePhase.SelectedValue);
            }
            else
            {
                feePhaseItemsTTableAdapter.Fill(this.dataSet_Drop.FeePhaseItemsT, -1);
            }

            txt_FeeSubject.Text = strFeeItem;
        }

        #endregion

        private void maskedTextBox_ReciveDate_Leave(object sender, EventArgs e)
        {
            MaskedTextBox mak = (MaskedTextBox)sender;
            Public.Utility.CheckMaskedtextbox(mak);
        }
    }
}
