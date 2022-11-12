using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LawtechPTSystem.AddFrom
{
    public partial class AddTrademarkPayment : Form
    {
        public AddTrademarkPayment()
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

        private int iTrademarkID = -1;
        /// <summary>
        /// 申請案ID
        /// </summary>
        public int TrademarkID
        {
            get { return iTrademarkID; }
            set { iTrademarkID = value; }
        }

        private int iSourceID = -1;
        /// <summary>
        /// 來源來函的 ID
        /// </summary>
        public int SourceID
        {
            get { return iSourceID; }
            set { iSourceID = value; }
        }

      

        /// <summary>
        /// 費用內容
        /// </summary>
        public string FeeSubject
        {
            get { return comboBox_FeeSubject.Text; }
            set { comboBox_FeeSubject.Text = value; }
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

        private void AddTrademarkPayment_Load(object sender, EventArgs e)
        {
            
            this.feePhaseTByTMTableAdapter.Fill(this.dataSet_Drop1.FeePhaseTByTM);
            this.attorneyTTableAdapter.Fill(this.dataSet_Drop1.AttorneyT);
            if (CountrySymbol != "")
            {
                attorneyTBindingSource.Filter = " CountrySymbol ='" + CountrySymbol + "'";
            }  
            this.payKindTableAdapter.Fill(this.dataSet_Drop1.PayKind);
            this.worker_QuitNTableAdapter.Fill(this.qS_DataSet.Worker_QuitN);
            this.moneyTTableAdapter.Fill(this.dataSet_Drop1.MoneyT);

            comboBox_FClientTransactor.SelectedValue = Properties.Settings.Default.WorkerKEY;

            comboBox_IMoney_SelectedIndexChanged(null, null);

            //取得登入者身份
            iWorkerID = Properties.Settings.Default.WorkerKEY;
            Worker_Model worker = new Worker_Model();
            Worker_Model.ReadOne(iWorkerID, ref  worker);
           
            iOfficeRole = worker.OfficeRole.Value;
            strWorkerName = worker.EmployeeName;

            SetOfficeRole();

            comboBox_FeePhase_SelectedIndexChanged(null,null);
        }

        private void but_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void but_OK_Click(object sender, EventArgs e)
        {
            if (comboBox_FeeSubject.Text != "")
            {
                Public.CTrademarkPayment payment = new Public.CTrademarkPayment();
                payment.TrademarkID = iTrademarkID;
                payment.FeeSubject = comboBox_FeeSubject.Text;
                payment.SingCode = txt_SingcCode.Text;

                if (comboBox_FeePhase.SelectedValue != null)//費用種類
                {
                    payment.FeePhase = (int)comboBox_FeePhase.SelectedValue;
                }


                if (comboBox_FClientTransactor.SelectedValue != null)//請款人
                {
                    payment.FClientTransactor = (int)comboBox_FClientTransactor.SelectedValue;
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

                if (comboBox_Attorney.SelectedValue != null)//受款人
                {
                    payment.Attorney = (int)comboBox_Attorney.SelectedValue;
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

                payment.RDate = DateTime.Now;
                DateTime dt_IReceiptDate = new DateTime();
               bool IsCheck= DateTime.TryParse(maskedTextBox_IReceiptDate.Text, out dt_IReceiptDate);
               if (IsCheck)
               {
                   payment.IReceiptDate = dt_IReceiptDate;
               }
               else
               {
                   payment.IReceiptDate = null;
               }


                DateTime dt_ReciveDate = new DateTime();
                bool IsCheckReciveDate = DateTime.TryParse(maskedTextBox_ReciveDate.Text, out dt_ReciveDate);
                if (IsCheckReciveDate) payment.ReciveDate = dt_ReciveDate;
                else payment.ReciveDate = null;

                DateTime dt_PayDueDate = new DateTime();
                bool IsCheckPayDueDate = DateTime.TryParse(maskedTextBox_PayDueDate.Text, out dt_PayDueDate);
                if (IsCheckPayDueDate) payment.PayDueDate = dt_PayDueDate;
                else payment.PayDueDate = null;
                payment.ExchangeRate = numericUpDown_ExchangeRate.Value;
                payment.Remark = txt_Remark.Text;

                //payment.BillingNo = txt_BillingNo.Text;
                //payment.BillCheck = txt_BillCheck.Text;
                //payment.IsBilling = checkBox_IsBilling.Checked;
                //payment.IsCopyFile = checkBox_IsCopyFile.Checked;
                //payment.IsScan = checkBox_IsScan.Checked;

                payment.IsClosing = false;                
                payment.Creator = Properties.Settings.Default.WorkerName;
                payment.Create();

                if (SourceID != -1)
                {
                    Public.CTrademarkNotifyEventToPayment NotifyPayment = new Public.CTrademarkNotifyEventToPayment();
                    NotifyPayment.PaymentID = payment.PaymentID;
                    NotifyPayment.TMNotifyEventID = iSourceID;
                    NotifyPayment.Create();
                }


                Public.PublicForm Forms = new Public.PublicForm();                
                if (Forms.TrademarkMF != null)
                {
                    DataRow dr = Forms.TrademarkMF.dt_TrademarkPaymentT.NewRow();
                    DataRow drV = Public.CTrademarkPublicFunction.GetTrademarkPayment(payment.PaymentID.ToString());
                    dr.ItemArray = drV.ItemArray;
                    Forms.TrademarkMF.dt_TrademarkPaymentT.Rows.Add(dr);
                }


                MessageBox.Show("新增成功 " + payment.FeeSubject, "提示訊息", MessageBoxButtons.OK);
                this.Close();
            }
            else
            {
                comboBox_FeeSubject.Focus();
                MessageBox.Show("請輸入費用內容", "提示訊息", MessageBoxButtons.OK);
            }
        }

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

        private void maskedTextBox_ReciveDate_DoubleClick(object sender, EventArgs e)
        {
            MaskedTextBox mtb = (MaskedTextBox)sender;
            DateTime dt;
            bool IsSuccess = DateTime.TryParse(mtb.Text, out dt);
            if (!IsSuccess)
            {
                mtb.Text = DateTime.Now.ToString("yyyy-MM-dd");
            }
        }

        private void comboBox_IMoney_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_IMoney.SelectedItem != null)
            {
                numericUpDown_ExchangeRate.Text = ((System.Data.DataRowView)(comboBox_IMoney.SelectedItem)).Row["ToNT"].ToString();
            }
        }

        #region OfficeRole()
        public void SetOfficeRole()
        {
            switch (iOfficeRole)
            {
                case 1:
                case 2:
                    label12.Visible = true;
                    but_SingOff.Visible = false;
                    break;
                case 3:
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

        #region ========but_SingOff_Click==========
        private void but_SingOff_Click(object sender, EventArgs e)
        {
            US.SingCode sing = new LawtechPTSystem.US.SingCode();
            sing.ShowDialog();
            if (sing.IsSuccess)
            {
                txt_SingcCode.Text = SingOffName(strWorkerName);
                if (but_SingOff.Tag.ToString() == "Sing")
                {
                    but_SingOff.Tag = "Cancel";
                    but_SingOff.Text = "取消簽核";
                }
                else
                {
                    but_SingOff.Text = "簽核";
                    but_SingOff.Tag = "Sing";
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

        private void AddTrademarkPayment_KeyDown(object sender, KeyEventArgs e)
        {
            Public.Utility.ControlTab(e);
        }

        #region comboBox_FeePhase_SelectedIndexChanged
        private void comboBox_FeePhase_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_FeePhase.SelectedValue != null)
            {
                feePhaseItemsTTableAdapter.FillByFeePhase(this.qS_DataSet.FeePhaseItemsT, (int)comboBox_FeePhase.SelectedValue);
            }
            else
            {
                feePhaseItemsTTableAdapter.FillByFeePhase(this.qS_DataSet.FeePhaseItemsT, -1);
            }
        }
        #endregion

        #region contextMenuStrip2_ItemClicked
        private void contextMenuStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            contextMenuStrip2.Visible = false;

            switch (e.ClickedItem.Name)
            {
                case "ToolStripMenuItem_All2":
                    checkBox_All.Checked = true;
                    attorneyTBindingSource.Filter = "";
                    break;
                case "ToolStripMenuItem_CurrentCountry2":
                    if (CountrySymbol != "")
                    {
                        checkBox_All.Checked = false;
                        attorneyTBindingSource.Filter = "Country ='" + CountrySymbol + "'";
                    }
                    break;
            }
        }
        #endregion

        private void maskedTextBox_ReciveDate_Leave(object sender, EventArgs e)
        {
            MaskedTextBox mak = (MaskedTextBox)sender;
            Public.Utility.CheckMaskedtextbox(mak);
        }
    }
}
