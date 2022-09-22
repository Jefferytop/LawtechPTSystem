using System;
using System.Data;
using System.Windows.Forms;

namespace LawtechPTSystemByFirm.AddFrom
{
    public partial class AddPatentPayment : Form
    {
        public AddPatentPayment()
        {
            InitializeComponent();
        }

        private int iPatentID = -1;
        /// <summary>
        /// 申請案ID
        /// </summary>
        public int PatentID
        {
            get { return iPatentID; }
            set { iPatentID = value; }
        }

        private int iTypeFrom = -1;
        /// <summary>
        /// 委辦=1 , 來函=2
        /// </summary>
        public int TypeFrom
        {
            get { return iTypeFrom; }
            set { iTypeFrom = value; }
        }

        private int iSourceID = -1;
        /// <summary>
        /// 來源(委辦或來函)的 ID
        /// </summary>
        public int SourceID
        {
            get { return iSourceID; }
            set { iSourceID = value; }
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



        private void but_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        #region =============but_OK_Click================
        private void but_OK_Click(object sender, EventArgs e)
        {
            if (txt_FeeSubject.Text != "")
            {
                Public.CPatentPayment payment = new LawtechPTSystemByFirm.Public.CPatentPayment();
                payment.PatentID = iPatentID;
                payment.FeeSubject = txt_FeeSubject.Text;
                payment.FeePhase = (int)comboBox_FeePhase.SelectedValue;
                payment.FClientTransactor = comboBox_FClientTransactor.SelectedValue != null ? (int)comboBox_FClientTransactor.SelectedValue : -1;
                payment.PayKind = comboBox_PayKind.Text;
                if (comboBox_IMoney.SelectedValue != null)
                {
                    payment.IMoney = comboBox_IMoney.SelectedValue.ToString();
                }
                else
                {
                    payment.IMoney = "";
                }
                payment.Attorney =comboBox_Attorney.SelectedValue!=null ? (int)comboBox_Attorney.SelectedValue:-1;
                payment.ExchangeRate = numericUpDown_ExchangeRate.Value;

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
                payment.SingCode = txt_SingcCode.Text;//主管簽核
                payment.IReceiptNo = txt_IReceiptNo.Text;

                payment.RDate = DateTime.Now;

                DateTime dt_IReceiptDate ;
                bool IsIReceiptDate = DateTime.TryParse(maskedTextBox_IReceiptDate.Text, out dt_IReceiptDate);
                if (IsIReceiptDate) payment.IReceiptDate = dt_IReceiptDate;
                else payment.IReceiptDate = null;

                DateTime dt_ReciveDate ;
                bool IsReciveDate = DateTime.TryParse(maskedTextBox_ReciveDate.Text, out dt_ReciveDate);
                if (IsReciveDate) payment.ReciveDate = dt_ReciveDate;
                else payment.ReciveDate  = null;

                DateTime dt_PayDueDate ;
                bool IsPayDueDate= DateTime.TryParse(maskedTextBox_PayDueDate.Text, out dt_PayDueDate);
                if (IsPayDueDate) payment.PayDueDate = dt_PayDueDate;
                else payment.PayDueDate = null;

                payment.Remark = txt_Remark.Text;

               
                payment.IsClosing = false;                
                payment.LastModifyWorker = Properties.Settings.Default.WorkerName;
                payment.Create();


                if (iTypeFrom != -1)
                {
                    switch (iTypeFrom)
                    {
                        case 1: //事件記錄轉付款
                            Public.CPatComitEventToPayment comitFee = new LawtechPTSystemByFirm.Public.CPatComitEventToPayment();
                            comitFee.PaymentID = payment.PaymentID;
                            comitFee.PatComitEventID = iSourceID;
                            comitFee.Create();
                            break;

                        case 2://來函
                            Public.CPatNotifyEventToPayment NotifyFee = new LawtechPTSystemByFirm.Public.CPatNotifyEventToPayment("1=0");
                            NotifyFee.PaymentID = payment.PaymentID;
                            NotifyFee.PatNotifyEventID = iSourceID;
                            NotifyFee.Insert();
                            break;
                    }
                }


                Public.PublicForm Forms = new LawtechPTSystemByFirm.Public.PublicForm();
                if (Forms.PatListMF != null)
                {
                    DataRow dr = Forms.PatListMF.DT_PatentPaymentT.NewRow();
                    DataRow drV = Public.CPatentPublicFunction.GetPatentPaymentTDataRow(payment.PaymentID.ToString());
                    dr.ItemArray = drV.ItemArray;             
                    Forms.PatListMF.DT_PatentPaymentT.Rows.Add(dr);
                   
                }
                MessageBox.Show("新增成功", "提示訊息", MessageBoxButtons.OK);
                this.Close();
            }
            else
            {
                txt_FeeSubject.Focus();
                MessageBox.Show("請輸入費用內容", "提示訊息", MessageBoxButtons.OK);
            }
        }
        #endregion

        #region =============AddPatentPayment_Load==============
        private void AddPatentPayment_Load(object sender, EventArgs e)
        {
            
            this.feePhaseTByPatTableAdapter.Fill(this.dataSet_Drop.FeePhaseTByPat);
           
            this.attorneyTTableAdapter1.Fill(this.dataSet_Attorney.AttorneyT);
            if (sCountrySymbol != "")
            {
                attorneyTBindingSource.Filter = "CountrySymbol='" + sCountrySymbol + "'";
            }
            
            this.feePhaseTByPatTableAdapter.Fill(this.dataSet_Drop.FeePhaseTByPat);
            this.payKindTableAdapter.Fill(this.dataSet_Drop.PayKind);
            this.worker_QuitNTableAdapter.Fill(this.qS_DataSet.Worker_QuitN);            
            this.moneyTTableAdapter.Fill(this.dataSet_Drop.MoneyT);

            comboBox_FClientTransactor.SelectedValue = Properties.Settings.Default.WorkerKEY;

            comboBox_IMoney_SelectedIndexChanged(null,null);


            //取得登入者身份
            iWorkerID = Properties.Settings.Default.WorkerKEY;
            Worker_Model worker = new Worker_Model();
            Worker_Model.ReadOne(iWorkerID, ref  worker);

            iOfficeRole = worker.OfficeRole.Value;
            strWorkerName = worker.EmployeeName;

            comboBox_FeePhase_SelectedIndexChanged(null,null);

            SetOfficeRole();
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

        #region ==============txt_IServiceFee_TextChanged==================
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

        #region ==============maskedTextBox_ReciveDate_DoubleClick=================
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

        #region =========comboBox_IMoney_SelectedIndexChanged===========
        private void comboBox_IMoney_SelectedIndexChanged(object sender, EventArgs e)
        {

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

        #region contextMenuStrip1_ItemClicked
        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Name)
            {
                case "ToolStripMenuItem_All":
                    checkBox_All.Checked = true;
                    attorneyTBindingSource.Filter = "";
                    break;
                case "ToolStripMenuItem_CurrentCountry":
                    if (sCountrySymbol != "")
                    {
                        checkBox_All.Checked = false;
                        attorneyTBindingSource.Filter = "CountrySymbol ='" + sCountrySymbol + "'";
                    }
                    break;
            }
        }
        #endregion

        #region AddPatentPayment_KeyDown
        private void AddPatentPayment_KeyDown(object sender, KeyEventArgs e)
        {
            Public.Utility.ControlTab(e);
        }
        #endregion

        #region private void comboBox_FeePhase_SelectedIndexChanged(object sender, EventArgs e)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBox_FeePhase_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_FeePhase.SelectedValue != null)
            {
                feePhaseItemsTTableAdapter1.Fill(this.dataSet_Drop.FeePhaseItemsT, (int)comboBox_FeePhase.SelectedValue);
            }
            else
            {
                feePhaseItemsTTableAdapter1.Fill(this.dataSet_Drop.FeePhaseItemsT, -1);
            }
        } 
        #endregion

    }
}
