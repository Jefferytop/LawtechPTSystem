using System;
using System.Data;
using System.Windows.Forms;

namespace LawtechPTSystemByFirm.AddFrom
{
    public partial class AddTrademarkFee : Form
    {
        public AddTrademarkFee()
        {
            InitializeComponent();
        }

        private int iTrademarkID = -1;
        /// <summary>
        /// 商標申請案ID
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

        private string sCountrySymbol = "";
        /// <summary>
        /// 國別
        /// </summary>
        public string CountrySymbol
        {
            get { return sCountrySymbol; }
            set { sCountrySymbol = value; }
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

        #region but_OK_Click
        private void but_OK_Click(object sender, EventArgs e)
        {
            if (comboBox_FeeSubject.Text.Trim() != "")
            {
                Public.CTrademarkFee add = new LawtechPTSystemByFirm.Public.CTrademarkFee();
                add.TrademarkID = TrademarkID;
                add.SingCode = txt_SingcCode.Text;
                add.FeeSubject = comboBox_FeeSubject.Text;
                add.FeePhase = comboBox_FeePhase.SelectedValue != null ? (int)comboBox_FeePhase.SelectedValue : -1;
                add.PayMemo = txt_PayMemo.Text;
                add.FClientTransactor = cboFClientTransactor.SelectedValue != null ? (int)cboFClientTransactor.SelectedValue : -1;

                if (comboBox_Attorney.SelectedValue != null)
                {
                    add.Attorney = (int)comboBox_Attorney.SelectedValue;
                }
                else
                {
                    add.Attorney = -1;
                }

                //請款人
                if (cboFClientTransactor.SelectedValue != null)
                {
                    add.FClientTransactor = (int)cboFClientTransactor.SelectedValue;
                }

                //本所費用
                //add.IAttorneyFee = numericUpDown_AttorneyFee1.Value;

                //請款合計
                add.Totall = numericUpDown_Totall.Value;

                //請款合計 幣別
                if (cboMoney1.SelectedValue != null)
                {
                    add.TMoney = cboMoney1.SelectedValue.ToString();
                }
                else
                {
                    add.TMoney = "";
                }



                //請款合計匯率               
                add.TtoNT = numericUpDown_Money1.Value;

                //請款合計NT
                if (txtTotal1.Text != "")
                {
                    add.TotalNT = decimal.Parse(txtTotal1.Text);
                }

                //複代費用
                add.OAttorneyFee = numericUpDown_AttorneyFee2.Value;

                //複代幣別
                if (cboMoney2.SelectedValue != null)
                {
                    add.OMoney = cboMoney2.SelectedValue.ToString();
                }
                else
                {
                    add.OMoney = "";
                }

                //複代幣別匯率
                add.OtoNT = numericUpDown_Money2.Value;

                //複代服務費合計
                if (txtAttorneyFeeTotal2.Text != "")
                {
                    add.OTotall = decimal.Parse(txtAttorneyFeeTotal2.Text);
                }

                //複代雜費
                add.OthFee = numericUpDown_AttorneyFee3.Value;

                //複代雜費合計NT
                if (txtAttorneyFeeTotal3.Text != "")
                {
                    add.OthTotal = decimal.Parse(txtAttorneyFeeTotal3.Text);
                }

                //官方
                add.GovFee = numericUpDown_AttorneyFee4.Value;
                
                //官方規費幣別
                if (cboMoney4.SelectedValue != null)
                {
                    add.GMoney = cboMoney4.SelectedValue.ToString();
                }
                else
                {
                    add.GMoney = "";
                }

                add.GtoNT = numericUpDown_Money4.Value;
                if (txtAttorneyFeeTotal4.Text != "")
                {
                    add.GTotall = decimal.Parse(txtAttorneyFeeTotal4.Text);
                }

                //雜費
                add.OtherTotalFee = numericUpDown_OtherFee.Value;

                DateTime dtRDate;
                bool IsRDate = DateTime.TryParse(mskRDate.Text, out dtRDate);
                if (IsRDate)
                {
                    add.RDate = dtRDate;
                }
                
                if (txtOAttorneyGovFee.Text != "")
                { 
                    add.OAttorneyGovFee = decimal.Parse(txtOAttorneyGovFee.Text);
                }


                add.IsClosing = false;
               
                add.Creator = Properties.Settings.Default.WorkerName;
                object obj=add.Create();

                if (SourceID != -1)
                {
                    Public.CTrademarkNotifyEventToFee NotifyFee = new LawtechPTSystemByFirm.Public.CTrademarkNotifyEventToFee();
                    NotifyFee.FeeKEY = add.FeeKEY;
                    NotifyFee.TMNotifyEventID = iSourceID;
                    NotifyFee.Create();
                }
                
                Public.PublicForm Forms = new LawtechPTSystemByFirm.Public.PublicForm();
                if (Forms.TrademarkMF != null)
                {
                    DataRow dr = Forms.TrademarkMF.dt_TrademarkFeeT.NewRow();
                    DataRow drV = Public.CTrademarkPublicFunction.GetTrademarkFee(add.FeeKEY.ToString());
                    dr.ItemArray = drV.ItemArray;
                    Forms.TrademarkMF.dt_TrademarkFeeT.Rows.Add(dr);
                }


                MessageBox.Show("新增成功 " + add.FeeSubject, "提示訊息", MessageBoxButtons.OK);
                this.Close();
            }
            else
            {
                comboBox_FeeSubject.Focus();
                MessageBox.Show("請輸入費用內容", "提示訊息", MessageBoxButtons.OK);
            }
        }
        #endregion

        #region AddTrademarkFee_Load
        private void AddTrademarkFee_Load(object sender, EventArgs e)
        {
           
            this.feePhaseTByTMTableAdapter.Fill(this.dataSet_Drop.FeePhaseTByTM);
            this.payKindTableAdapter.Fill(this.dataSet_Drop.PayKind);
            this.worker_QuitNTableAdapter.Fill(this.qS_DataSet.Worker_QuitN);
            this.moneyTTableAdapter.Fill(this.dataSet_Drop.MoneyT);
            this.attorneyTTableAdapter.Fill(this.dataSet_Drop.AttorneyT);
            if (CountrySymbol != "")
            {
                attorneyTBindingSource.Filter = " CountrySymbol ='" + CountrySymbol + "'";
            }  

            cboMoney1_Changed(cboMoney1, null);
            cboMoney1_Changed(cboMoney2, null);
            cboMoney1_Changed(cboMoney4, null);


            cboFClientTransactor.SelectedValue = Properties.Settings.Default.WorkerKEY;
            mskRDate.Text = DateTime.Now.ToString("yyyy/MM/dd");

            //取得登入者身份
            iWorkerID = Properties.Settings.Default.WorkerKEY;
            Worker_Model worker = new Worker_Model();
            Worker_Model.ReadOne(iWorkerID, ref  worker);
            iOfficeRole = worker.OfficeRole.Value;
            strWorkerName = worker.EmployeeName;

            SetOfficeRole();
        }
        #endregion

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
    
        #region cboMoney1_Changed
        private void cboMoney1_Changed(object sender, EventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;
            if (cmb.SelectedItem != null)
            {
                switch (cmb.Name)
                {
                    case "cboMoney1":
                        numericUpDown_Money1.Value = (decimal)(((System.Data.DataRowView)(cmb.SelectedItem)).Row["ToNT"]);
                        rateMoney(cmb, numericUpDown_Money1, numericUpDown_Totall, txtTotal1);
                        break;

                    case "cboMoney2":
                        numericUpDown_Money2.Value = (decimal)(((System.Data.DataRowView)(cmb.SelectedItem)).Row["ToNT"]);
                        rateMoney(cmb, numericUpDown_Money2, numericUpDown_AttorneyFee2, txtAttorneyFeeTotal2);
                        break;

                    case "cboMoney3":
                        numericUpDown_Money3.Value = (decimal)(((System.Data.DataRowView)(cmb.SelectedItem)).Row["ToNT"]);
                        rateMoney(cmb, numericUpDown_Money3, numericUpDown_AttorneyFee3, txtAttorneyFeeTotal3);
                        break;
                    case "cboMoney4":
                        numericUpDown_Money4.Value = (decimal)(((System.Data.DataRowView)(cmb.SelectedItem)).Row["ToNT"]);
                        rateMoney(cmb, numericUpDown_Money4, numericUpDown_AttorneyFee4, txtAttorneyFeeTotal4);
                        break;
                }

                txtAttorneyFeeTotal1_TextChanged(null, null);
            }
        }
        #endregion

        #region ===========費用金額計算===========
        /// <summary>
        /// 費用金額計算
        /// </summary>
        /// <param name="cboMoney"></param>
        /// <param name="RateMoney"></param>
        /// <param name="AttorneyFee"></param>
        /// <param name="txtFeeTotal1"></param>
        private void rateMoney(ComboBox cboMoney, NumericUpDown RateMoney, NumericUpDown AttorneyFee, TextBox txtFeeTotal1)
        {
            try
            {
                decimal dec = RateMoney.Value * AttorneyFee.Value;
                txtFeeTotal1.Text = dec.ToString("#,##0.##");
            }
            catch
            {
                txtFeeTotal1.Text = "0";
            }
        }

        #region txtAttorneyFeeTotal1_TextChanged
        private void txtAttorneyFeeTotal1_TextChanged(object sender, EventArgs e)
        {
            decimal dTol = 0;
            decimal din = 0;
            decimal dout = 0;
            decimal doutOther = 0;
            decimal de = 0;

            if (txtTotal1.Text != "" && Public.Utility.isNumeric(txtTotal1.Text, "decimal"))
            {
                din = decimal.Parse(txtTotal1.Text);
            }
            if (txtAttorneyFeeTotal2.Text != "" && Public.Utility.isNumeric(txtAttorneyFeeTotal2.Text, "decimal"))
            {
                dout = decimal.Parse(txtAttorneyFeeTotal2.Text);
            }
            if (txtAttorneyFeeTotal3.Text != "" && Public.Utility.isNumeric(txtAttorneyFeeTotal3.Text, "decimal"))
            {
                doutOther = decimal.Parse(txtAttorneyFeeTotal3.Text);
            }
            if (txtAttorneyFeeTotal4.Text != "" && Public.Utility.isNumeric(txtAttorneyFeeTotal4.Text, "decimal"))
            {
                de = decimal.Parse(txtAttorneyFeeTotal4.Text);
            }

            //代收代付合計=複代合計+複代雜費+官方規費
            dTol = dout + de + doutOther;
            txtOAttorneyGovFee.Text = dTol.ToString("#,##0.##");            
           
        }
        #endregion

       

        private void chkWithholding_Leave(object sender, EventArgs e)
        {
            txtAttorneyFeeTotal1_TextChanged(null, null);
        }

        #endregion

        #region mskRDate_DoubleClick
        private void mskRDate_DoubleClick(object sender, EventArgs e)
        {

        }
        #endregion

        #region but_SingOff_Click
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

        #region numericUpDown_OtherFee_ValueChanged
        private void numericUpDown_OtherFee_ValueChanged(object sender, EventArgs e)
        {
            //decimal dTol = 0;
            //decimal din = 0;
            //decimal dout = 0;
            //decimal doutOther = 0;
            //decimal de = 0;

            //if (txtTotal1.Text != "" && Public.Utility.isNumeric(txtTotal1.Text, "decimal"))
            //{
            //    din = decimal.Parse(txtTotal1.Text);
            //}
            //if (txtAttorneyFeeTotal2.Text != "" && Public.Utility.isNumeric(txtAttorneyFeeTotal2.Text, "decimal"))
            //{
            //    dout = decimal.Parse(txtAttorneyFeeTotal2.Text);
            //}
            //if (txtAttorneyFeeTotal3.Text != "" && Public.Utility.isNumeric(txtAttorneyFeeTotal3.Text, "decimal"))
            //{
            //    doutOther = decimal.Parse(txtAttorneyFeeTotal3.Text);
            //}
            //if (txtAttorneyFeeTotal4.Text != "" && Public.Utility.isNumeric(txtAttorneyFeeTotal4.Text, "decimal"))
            //{
            //    de = decimal.Parse(txtAttorneyFeeTotal4.Text);
            //}

            //dTol = din + dout + de + doutOther + numericUpDown_OtherFee.Value;
            //txtTotall.Text = dTol.ToString("#,##0.##");
        }
        #endregion

        #region numericUpDown_AttorneyFee1_ValueChanged
        private void numericUpDown_AttorneyFee1_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown txt = (NumericUpDown)sender;
            try
            {
                switch (txt.Name)
                {
                    case "numericUpDown_Totall":
                    case "numericUpDown_Money1":
                        rateMoney(cboMoney1, numericUpDown_Money1, numericUpDown_Totall, txtTotal1);
                        break;

                    case "numericUpDown_AttorneyFee2":
                    case "numericUpDown_Money2":
                        if (txt.Name == "numericUpDown_Money2")
                        {
                            numericUpDown_Money3.Value = numericUpDown_Money2.Value;
                        }
                        rateMoney(cboMoney2, numericUpDown_Money2, numericUpDown_AttorneyFee2, txtAttorneyFeeTotal2);
                        break;

                    case "numericUpDown_AttorneyFee3":
                    case "numericUpDown_Money3":
                        rateMoney(cboMoney3, numericUpDown_Money3, numericUpDown_AttorneyFee3, txtAttorneyFeeTotal3);
                        break;

                    case "numericUpDown_AttorneyFee4":
                    case "numericUpDown_Money4":
                        rateMoney(cboMoney4, numericUpDown_Money4, numericUpDown_AttorneyFee4, txtAttorneyFeeTotal4);
                        break;
                }

                if (txt.Text != "" && Public.Utility.isNumeric(txt.Text, "decimal"))
                {
                    txtAttorneyFeeTotal1_TextChanged(null, null);
                }
            }
            catch (System.Exception EX)
            {
                txt.Focus();
                MessageBox.Show(EX.Message.Replace("'", ""));
            }

        }
        #endregion

        #region AddTrademarkFee_KeyDown
        private void AddTrademarkFee_KeyDown(object sender, KeyEventArgs e)
        {
            Public.Utility.ControlTab(e);
        }
        #endregion

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

    }
}
