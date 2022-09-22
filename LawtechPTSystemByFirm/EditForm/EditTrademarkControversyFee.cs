using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LawtechPTSystemByFirm.EditForm
{
    public partial class EditTrademarkControversyFee : Form
    {
        public EditTrademarkControversyFee()
        {
            InitializeComponent();
        }

        private int iFeeKEY = -1;
        /// <summary>
        /// 商標異議案ID
        /// </summary>
        public int property_FeeKEY
        {
            get { return iFeeKEY; }
            set { iFeeKEY = value; }
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


        private void EditTrademarkControversyFee_Load(object sender, EventArgs e)
        {
            this.feePhaseTByTMTableAdapter.Fill(this.dataSet_Drop.FeePhaseTByTM);
            this.attorneyTTableAdapter.FillByCountry(this.dataSet_Drop.AttorneyT, sCountrySymbol);
            this.moneyTTableAdapter.Fill(this.dataSet_Drop.MoneyT);
            this.workerTAllTableAdapter.Fill(this.qS_DataSet.WorkerTAll);
            this.payKindTableAdapter.Fill(this.dataSet_Drop.PayKind);



            Public.CTrademarkControversyFee Edit = new LawtechPTSystemByFirm.Public.CTrademarkControversyFee("ControversyFeeKEY=" + iFeeKEY.ToString());
            Edit.SetCurrent(iFeeKEY);

            txt_FeeSubject.Text = Edit.FeeSubject;
            comboBox_FeePhase.SelectedValue = Edit.FeePhase;

            numericUpDown_Totall.Value = Edit.Totall;
            numericUpDown_AttorneyFee2.Value = Edit.OAttorneyFee;
            numericUpDown_AttorneyFee3.Value = Edit.OthFee;
            numericUpDown_AttorneyFee4.Value = Edit.GovFee;

            cboMoney1.SelectedValue = Edit.TMoney;
            cboMoney2.SelectedValue = Edit.OMoney;
            cboMoney4.SelectedValue = Edit.GMoney;

            numericUpDown_Money1.Value = Edit.TtoNT;
            numericUpDown_Money2.Value = Edit.OtoNT;
            numericUpDown_Money3.Value = Edit.OtoNT;
            numericUpDown_Money4.Value = Edit.GtoNT;

            txtAttorneyFeeTotal1.Text = Edit.TotalNT.ToString("#,##0.##");
            txtAttorneyFeeTotal2.Text = Edit.OTotall.ToString("#,##0.##");
            txtAttorneyFeeTotal3.Text = Edit.OthTotal.ToString("#,##0.##");
            txtAttorneyFeeTotal4.Text = Edit.GTotall.ToString("#,##0.##");



            //雜費
            numericUpDown_OtherFee.Text = Edit.OtherTotalFee.ToString("#,##0.##");

            //複代
            comboBox_Attorney.SelectedValue = Edit.Attorney;

            mskRDate.Text = Edit.RDate.ToShortDateString() != "1900/1/1" ? Edit.RDate.ToString("yyyy/MM/dd") : "    /  /";

            cboFClientTransactor.SelectedValue = Edit.FClientTransactor;

            
            txtOAttorneyGovFee.Text = Edit.OAttorneyGovFee.ToString("#,##0.##");

            //主管簽核
            txt_SingcCode.Text = Edit.SingCode;

            txt_PayMemo.Text = Edit.PayMemo;


            //if (Edit.Days > 0)
            //{
            //    numericUpDown_Days.Value = Edit.Days;
            //}
            //else
            //{
            //    numericUpDown_Days.Value = 0;
            //}


            //取得登入者身份
            iWorkerID = Properties.Settings.Default.WorkerKEY;
            Worker_Model worker = new Worker_Model();
            Worker_Model.ReadOne(iWorkerID, ref  worker);
          
            iOfficeRole = worker.OfficeRole.Value;
            strWorkerName = worker.EmployeeName;


            SetOfficeRole();


            this.cboMoney1.SelectedIndexChanged += new System.EventHandler(this.cboMoney1_Changed);
            this.cboMoney2.SelectedIndexChanged += new System.EventHandler(this.cboMoney1_Changed);
            this.cboMoney3.SelectedIndexChanged += new System.EventHandler(this.cboMoney1_Changed);
        }

        private void but_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region OfficeRole()
        public void SetOfficeRole()
        {
            switch (OfficeRole)
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
                        rateMoney(cboMoney1, numericUpDown_Money1, numericUpDown_Totall, txtAttorneyFeeTotal1);

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



        #region ===========費用金額計算===========
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

            if (txtAttorneyFeeTotal1.Text != "" && Public.Utility.isNumeric(txtAttorneyFeeTotal1.Text, "decimal"))
            {
                din = decimal.Parse(txtAttorneyFeeTotal1.Text);
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
                        rateMoney(cmb, numericUpDown_Money1, numericUpDown_Totall, txtAttorneyFeeTotal1);
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

        private void chkWithholding_Leave(object sender, EventArgs e)
        {
            txtAttorneyFeeTotal1_TextChanged(null, null);
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

            //if (txtAttorneyFeeTotal1.Text != "" && Public.Utility.isNumeric(txtAttorneyFeeTotal1.Text, "decimal"))
            //{
            //    din = decimal.Parse(txtAttorneyFeeTotal1.Text);
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

        #region but_OK_Click
        private void but_OK_Click(object sender, EventArgs e)
        {
            if (txt_FeeSubject.Text.Trim() != "")
            {
                Public.CTrademarkControversyFee add = new LawtechPTSystemByFirm.Public.CTrademarkControversyFee("ControversyFeeKEY=" + iFeeKEY.ToString());
                add.SetCurrent(iFeeKEY);
                add.SingCode = txt_SingcCode.Text;
                add.FeeSubject = txt_FeeSubject.Text;
                add.FeePhase = comboBox_FeePhase.SelectedValue != null ? (int)comboBox_FeePhase.SelectedValue : -1;

                if (comboBox_Attorney.SelectedValue != null)
                {
                    add.Attorney = (int)comboBox_Attorney.SelectedValue;
                }
                else
                {
                    add.Attorney = -1;
                }

                //請款合計
                add.Totall = numericUpDown_Totall.Value;

                //請款合計幣別
                if (cboMoney1.SelectedValue != null)
                {
                    add.TMoney = cboMoney1.SelectedValue.ToString();
                }
                else
                {
                    add.TMoney = "";
                }

                //請款合計幣別匯率               
                add.TtoNT = numericUpDown_Money1.Value;

                //請款合計NT
                if (txtAttorneyFeeTotal1.Text != "")
                {
                    add.TotalNT = decimal.Parse(txtAttorneyFeeTotal1.Text);
                }

                //複代費用
                add.OAttorneyFee = numericUpDown_AttorneyFee2.Value;

                //複代費用 幣別
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

                add.FeePhase = comboBox_FeePhase.SelectedValue != null ? (int)comboBox_FeePhase.SelectedValue : -1;



                DateTime dt_RDate;
                bool IsRDate = DateTime.TryParse(mskRDate.Text, out dt_RDate);
                if (IsRDate) add.RDate = dt_RDate;
                else add.RDate = new DateTime(1900, 1, 1);


                if (cboFClientTransactor.SelectedValue != null)
                { add.FClientTransactor = (int)cboFClientTransactor.SelectedValue; }


               

                if (txtOAttorneyGovFee.Text != "")
                { 
                    add.OAttorneyGovFee = decimal.Parse(txtOAttorneyGovFee.Text); 
                }

                add.PayMemo = txt_PayMemo.Text;

                add.LastModifyDate = DateTime.Now;
                add.LastModifyWorker = Properties.Settings.Default.WorkerKEY;

                add.Updata(iFeeKEY);

                Public.PublicForm Forms = new LawtechPTSystemByFirm.Public.PublicForm();
                if (Forms.TrademarkControversyMF != null && Forms.TrademarkControversyMF.dt_TrademarkControversyFeeT != null)
                {
                    DataSet_TrademarkControversy.TrademarkControversyFeeTRow dr = Forms.TrademarkControversyMF.dt_TrademarkControversyFeeT.FindByControversyFeeKEY(add.ControversyFeeKEY);

                    if (dr != null)
                    {
                        if (add.RDate.Year != 1900)
                        {
                            dr["RDate"] = add.RDate;
                        }
                        if (add.PayDate.Year != 1900)
                        {
                            dr["PayDate"] = add.PayDate;
                        }
                        dr["FeeSubject"] = add.FeeSubject;
                        dr["FeePhase"] = add.FeePhase;
                        dr["FClientTransactor"] = add.FClientTransactor;
                        dr["Attorney"] = add.Attorney;
                        if (add.Attorney != -1)
                        {
                            dr["AttorneyFirm"] = comboBox_Attorney.Text;
                        }
                        else
                        {
                            dr["AttorneyFirm"] = "";
                        }

                        dr["Totall"] = add.Totall;
                        dr["TMoney"] = add.TMoney;
                        dr["TtoNT"] = add.TtoNT;
                        dr["TotalNT"] = add.TotalNT;

                        dr["OAttorneyFee"] = add.OAttorneyFee;
                        dr["OMoney"] = add.OMoney;
                        dr["OtoNT"] = add.OtoNT;
                        dr["OTotall"] = add.OTotall;

                        dr["OthFee"] = add.OthFee;
                        dr["OthTotal"] = add.OthTotal;

                        dr["SingCode"] = add.SingCode;
                        dr["GovFee"] = add.GovFee;
                        dr["GMoney"] = add.GMoney;
                        dr["GtoNT"] = add.GtoNT;
                        dr["GTotall"] = add.GTotall;
                        dr["OAttorneyGovFee"] = add.OAttorneyGovFee;
                        dr["Totall"] = add.Totall;
                        dr["OtherTotalFee"] = add.OtherTotalFee;
                        dr["PayKind"] = add.PayKind;
                        dr["Remark"] = add.Remark;
                        dr["PayMemo"] = add.PayMemo;
                        dr["Days"] = add.Days;
                        dr["WorkerName"] = cboFClientTransactor.Text;
                        dr["FeePhaseName"] = comboBox_FeePhase.Text;

                        Forms.TrademarkControversyMF.dt_TrademarkControversyFeeT.AcceptChanges();
                    }
                }

                MessageBox.Show("修改成功", "提示訊息", MessageBoxButtons.OK);
                this.Close();
            }
            else
            {
                txt_FeeSubject.Focus();
                MessageBox.Show("請輸入費用內容", "提示訊息", MessageBoxButtons.OK);
            }
        }
        #endregion

        #region mskRDate_DoubleClick
        private void mskRDate_DoubleClick(object sender, EventArgs e)
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

        #region ==============but_SingOff_Click==============
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

        private void EditTrademarkControversyFee_KeyDown(object sender, KeyEventArgs e)
        {
            Public.Utility.ControlTab(e);
        }
    }
}
