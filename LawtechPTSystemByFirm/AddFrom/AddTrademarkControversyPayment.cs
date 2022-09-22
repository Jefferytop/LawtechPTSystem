using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LawtechPTSystemByFirm.AddFrom
{
    public partial class AddTrademarkControversyPayment : Form
    {
        public AddTrademarkControversyPayment()
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

        private int iTrademarkControversyID = -1;
        /// <summary>
        /// 申請案ID
        /// </summary>
        public int TrademarkControversyID
        {
            get { return iTrademarkControversyID; }
            set { iTrademarkControversyID = value; }
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
            get { return txt_FeeSubject.Text; }
            set { txt_FeeSubject.Text = value; }
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

        private void AddTrademarkControversyPayment_Load(object sender, EventArgs e)
        {
            this.feePhaseTByTMTableAdapter.Fill(this.dataSet_Drop.FeePhaseTByTM);
            this.attorneyTTableAdapter.FillByCountry(this.dataSet_Drop.AttorneyT, sCountrySymbol);
            this.payKindTableAdapter.Fill(this.dataSet_Drop.PayKind);
            this.worker_QuitNTableAdapter.Fill(this.qS_DataSet.Worker_QuitN);
            this.moneyTTableAdapter.Fill(this.dataSet_Drop.MoneyT);

            comboBox_FClientTransactor.SelectedValue = Properties.Settings.Default.WorkerKEY;

            comboBox_IMoney_SelectedIndexChanged(null, null);

            //取得登入者身份
            iWorkerID = Properties.Settings.Default.WorkerKEY;
            Worker_Model worker = new Worker_Model();
            Worker_Model.ReadOne(iWorkerID, ref  worker);
          
            iOfficeRole = worker.OfficeRole.Value;
            strWorkerName = worker.EmployeeName;

            SetOfficeRole();
        }

        private void but_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void but_OK_Click(object sender, EventArgs e)
        {
            if (txt_FeeSubject.Text != "")
            {
                Public.CTrademarkControversyPayment payment = new LawtechPTSystemByFirm.Public.CTrademarkControversyPayment("1=0");
                payment.TrademarkControversyID = iTrademarkControversyID;
                payment.FeeSubject = txt_FeeSubject.Text;
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
                bool IsCheck = DateTime.TryParse(maskedTextBox_IReceiptDate.Text, out dt_IReceiptDate);
                if (IsCheck)
                {
                    payment.IReceiptDate = dt_IReceiptDate;
                }
                else
                {
                    payment.IReceiptDate = new DateTime(1900, 1, 1);
                }


                DateTime dt_ReciveDate = new DateTime();
                bool IsCheckReciveDate = DateTime.TryParse(maskedTextBox_ReciveDate.Text, out dt_ReciveDate);
                if (IsCheckReciveDate) payment.ReciveDate = dt_ReciveDate;
                else payment.ReciveDate = new DateTime(1900, 1, 1);

                DateTime dt_PayDueDate = new DateTime();
                bool IsCheckPayDueDate = DateTime.TryParse(maskedTextBox_PayDueDate.Text, out dt_PayDueDate);
                if (IsCheckPayDueDate) payment.PayDueDate = dt_PayDueDate;
                else payment.PayDueDate = new DateTime(1900, 1, 1);
                payment.ExchangeRate = numericUpDown_ExchangeRate.Value;
                payment.Remark = txt_Remark.Text;

                payment.IsClosing = false;
                payment.UpbuildDay = DateTime.Now;
                payment.LastModifyDate = DateTime.Now;
                payment.LastModifyWorker = Properties.Settings.Default.WorkerKEY;


                payment.Insert();

                if (SourceID != -1)
                {
                    Public.CTrademarkControversyNotifyEventToPayment NotifyPayment = new LawtechPTSystemByFirm.Public.CTrademarkControversyNotifyEventToPayment("1=0");
                    NotifyPayment.ControversyPaymentID = payment.ControversyPaymentID;
                    NotifyPayment.TMNotifyControversyEventID = iSourceID;
                    NotifyPayment.Insert();
                }


                Public.PublicForm Forms = new LawtechPTSystemByFirm.Public.PublicForm();
                DataRow dr = Forms.TrademarkControversyMF.dt_TrademarkControversyPaymentT.NewRow();
                dr["ControversyPaymentID"] = payment.ControversyPaymentID;
                dr["TrademarkControversyID"] = payment.TrademarkControversyID;
                dr["SingCode"] = payment.SingCode;
                dr["Attorney"] = payment.Attorney;
                dr["FeeSubject"] = payment.FeeSubject;
                dr["FeePhase"] = payment.FeePhase;
                dr["FeePhaseName"] = comboBox_FeePhase.Text;
                dr["FClientTransactor"] = payment.FClientTransactor;
                dr["PayKind"] = payment.PayKind;
                dr["IMoney"] = payment.IMoney;
                dr["ExchangeRate"] = payment.ExchangeRate;
                dr["IServiceFee"] = payment.IServiceFee;
                dr["GovFee"] = payment.GovFee;
                dr["OtherFee"] = payment.OtherFee;
                dr["Totall"] = payment.Totall;
                dr["IReceiptNo"] = payment.IReceiptNo;

                if (payment.RDate.Year != 1900)
                {
                    dr["RDate"] = payment.RDate;
                }

                if (payment.IReceiptDate.Year != 1900)
                {
                    dr["IReceiptDate"] = payment.IReceiptDate;
                }

                if (payment.ReciveDate.Year != 1900)
                {
                    dr["ReciveDate"] = payment.ReciveDate;
                }

                if (payment.PayDueDate.Year != 1900)
                {
                    dr["PayDueDate"] = payment.PayDueDate;
                }

                dr["Remark"] = payment.Remark;
                dr["BillingNo"] = payment.BillingNo;
                dr["BillCheck"] = payment.BillCheck;
                dr["IsBilling"] = payment.IsBilling;
                dr["IsCopyFile"] = payment.IsCopyFile;
                dr["IsScan"] = payment.IsScan;
                dr["IsClosing"] = payment.IsClosing;
                dr["WorkerName"] = comboBox_FClientTransactor.Text;
                dr["AttorneyFirm"] = comboBox_Attorney.Text;

                Forms.TrademarkControversyMF.dt_TrademarkControversyPaymentT.Rows.Add(dr);
                Forms.TrademarkControversyMF.dt_TrademarkControversyPaymentT.AcceptChanges();

                MessageBox.Show("新增成功", "提示訊息", MessageBoxButtons.OK);
                this.Close();
            }
            else
            {
                txt_FeeSubject.Focus();
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
                mtb.Text = DateTime.Now.ToString("yyyy/MM/dd");
            }
        }

        private void comboBox_IMoney_SelectedIndexChanged(object sender, EventArgs e)
        {

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
            US.SingCode sing = new LawtechPTSystemByFirm.US.SingCode();
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

                    US.CalculationDate Calculation = new LawtechPTSystemByFirm.US.CalculationDate();
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

        private void AddTrademarkControversyPayment_KeyDown(object sender, KeyEventArgs e)
        {
            Public.Utility.ControlTab(e);
        }
    }
}
