using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LawtechPTSystemByFirm.AddFrom
{
    public partial class AddTrademarkControversyEstimateCost : Form
    {
        public AddTrademarkControversyEstimateCost()
        {
            InitializeComponent();
        }


        private int iTrademarkControversyID = -1;
        /// <summary>
        /// 商標申請案ID
        /// </summary>
        public int TrademarkControversyID
        {
            get { return iTrademarkControversyID; }
            set { iTrademarkControversyID = value; }
        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddTrademarkControversyEstimateCost_Load(object sender, EventArgs e)
        {
            this.moneyTTableAdapter.Fill(this.dataSet_Drop.MoneyT);

            maskedTextBox_CreateDate.Text = DateTime.Now.ToString("yyyy/MM/dd");

            cboMoney1_SelectedIndexChanged(cboMoney1, null);
            cboMoney1_SelectedIndexChanged(cboMoney2, null);
            cboMoney1_SelectedIndexChanged(cboMoney3, null);

            //numericUpDown_EstimateProfit.Value = 100;
        }

        #region cboMoney1_SelectedIndexChanged
        private void cboMoney1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cmb = (ComboBox)sender;
            if (cmb.SelectedItem != null)
            {
                switch (cmb.Name)
                {
                    case "cboMoney1":
                        numericUpDown_Money1.Value = (decimal)((System.Data.DataRowView)(cmb.SelectedItem)).Row["ToNT"];
                        rateMoney(cmb, numericUpDown_Money1, numericUpDown_IAttorneyFee, txt_ITotall);
                        break;
                    case "comboBox_OMoney":
                        numericUpDown_Money2.Value = (decimal)((System.Data.DataRowView)(cmb.SelectedItem)).Row["ToNT"];
                        rateMoney(cmb, numericUpDown_Money2, numericUpDown_OAttorneyFee, txt_OTotall);
                        break;

                    case "cboMoney2":
                        numericUpDown_Money3.Value = (decimal)((System.Data.DataRowView)(cmb.SelectedItem)).Row["ToNT"];
                        rateMoney(cmb, numericUpDown_Money3, numericUpDown_GovFee, txt_GTotall);
                        break;

                    case "cboMoney3":
                        numericUpDown_Money4.Value = (decimal)((System.Data.DataRowView)(cmb.SelectedItem)).Row["ToNT"];
                        rateMoney(cmb, numericUpDown_Money4, numericUpDown_OtherFee, txt_OtherTotal);
                        break;
                }

                txtAttorneyFeeTotal1_TextChanged(null, null);
            }
        }
        #endregion

        #region rateMoney
        private void rateMoney(ComboBox cboMoney, NumericUpDown nud_Money, NumericUpDown NumericUpDownAttorneyFee, TextBox txtFeeTotal1)
        {
            if (cboMoney.SelectedValue != null)
            {
                decimal dec = 0;

                dec = nud_Money.Value * NumericUpDownAttorneyFee.Value;
                txtFeeTotal1.Text = dec.ToString("#,##0.##");
            }
        }
        #endregion

        #region numericUpDown_Money1_ValueChanged
        private void numericUpDown_Money1_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown nud = (NumericUpDown)sender;

            switch (nud.Name)
            {
                case "numericUpDown_Money1":
                    //numericUpDown_Money1.Value = (decimal)((System.Data.DataRowView)(cmb.SelectedItem)).Row["ToNT"];
                    rateMoney(cboMoney1, nud, numericUpDown_IAttorneyFee, txt_ITotall);
                    break;
                case "numericUpDown_Money2":
                    //numericUpDown_Money2.Value = (decimal)((System.Data.DataRowView)(cmb.SelectedItem)).Row["ToNT"];
                    rateMoney(comboBox_OMoney, nud, numericUpDown_OAttorneyFee, txt_OTotall);
                    break;

                case "numericUpDown_Money3":
                    //numericUpDown_Money3.Value = (decimal)((System.Data.DataRowView)(cmb.SelectedItem)).Row["ToNT"];
                    rateMoney(cboMoney2, nud, numericUpDown_GovFee, txt_GTotall);
                    break;

                case "numericUpDown_Money4":
                    //numericUpDown_Money4.Value = (decimal)((System.Data.DataRowView)(cmb.SelectedItem)).Row["ToNT"];
                    rateMoney(cboMoney3, nud, numericUpDown_OtherFee, txt_OtherTotal);
                    break;
            }

            txtAttorneyFeeTotal1_TextChanged(null, null);

        }
        #endregion

        #region txtAttorneyFeeTotal1_TextChanged
        private void txtAttorneyFeeTotal1_TextChanged(object sender, EventArgs e)
        {
            decimal dTol = 0;
            decimal din = 0;
            decimal dAtt = 0;
            decimal dout = 0;
            decimal de = 0;
            if (txt_ITotall.Text != "" && Public.Utility.isNumeric(txt_ITotall.Text, "decimal"))
            {
                decimal.TryParse(txt_ITotall.Text, out din);
            }

            if (txt_OTotall.Text != "" && Public.Utility.isNumeric(txt_OTotall.Text, "decimal"))
            {
                decimal.TryParse(txt_OTotall.Text, out dAtt);
            }

            if (txt_GTotall.Text != "" && Public.Utility.isNumeric(txt_GTotall.Text, "decimal"))
            {
                decimal.TryParse(txt_GTotall.Text, out dout);
            }
            if (txt_OtherTotal.Text != "" && Public.Utility.isNumeric(txt_OtherTotal.Text, "decimal"))
            {
                decimal.TryParse(txt_OtherTotal.Text, out de);
            }

            dTol = din + dAtt + dout + de;
            txt_EstimateCost.Text = dTol.ToString("#,##0.##");


            //全部總計
            decimal decServicePrice = dTol + (dTol * (numericUpDown_EstimateProfit.Value / 100));
            txt_ServicePrice.Text = decServicePrice.ToString("#,##0.##");
        }
        #endregion

        #region numericUpDown_EstimateProfit_ValueChanged
        private void numericUpDown_EstimateProfit_ValueChanged(object sender, EventArgs e)
        {

            decimal decServicePrice = 0m;
            decimal.TryParse(txt_EstimateCost.Text, out decServicePrice);
            decServicePrice = decServicePrice + (decServicePrice * (numericUpDown_EstimateProfit.Value / 100));
            txt_ServicePrice.Text = decServicePrice.ToString("#,##0.##");
        }
        #endregion


        private void butOK_Click(object sender, EventArgs e)
        {
            if (txt_ES_FeeSubject.Text == "")
            {
                MessageBox.Show("費用內容不得為空白", "提示訊息");
                txt_ES_FeeSubject.Focus();
                return;
            }

            Public.CTrademarkControveryEstimateCost CCTrademarkEstimateCost = new Public.CTrademarkControveryEstimateCost("1=0");

            Public.PublicForm Forms = new LawtechPTSystemByFirm.Public.PublicForm();
            DataSet_TrademarkControversy.TrademarkControveryEstimateCostTRow dr = Forms.TrademarkControversyMF.dt_TrademarkControveryEstimateCostT.NewTrademarkControveryEstimateCostTRow();

            CCTrademarkEstimateCost.TrademarkControversyID = TrademarkControversyID;
            dr["TrademarkControversyID"] = CCTrademarkEstimateCost.TrademarkControversyID;

            CCTrademarkEstimateCost.FeeSubject = txt_ES_FeeSubject.Text;
            dr["FeeSubject"] = CCTrademarkEstimateCost.FeeSubject;

            CCTrademarkEstimateCost.IAttorneyFee = numericUpDown_IAttorneyFee.Value;
            dr["IAttorneyFee"] = CCTrademarkEstimateCost.IAttorneyFee;

            CCTrademarkEstimateCost.IMoney = cboMoney1.Text;
            dr["IMoney"] = CCTrademarkEstimateCost.IMoney;

           
            CCTrademarkEstimateCost.ItoNT = numericUpDown_Money1.Value;
            dr["ItoNT"] = CCTrademarkEstimateCost.ItoNT;


            decimal decITotall = 0m;
            decimal.TryParse(txt_ITotall.Text, out decITotall);
            CCTrademarkEstimateCost.ITotall = decITotall;
            dr["ITotall"] = CCTrademarkEstimateCost.ITotall;

            //國外事務所費用
            CCTrademarkEstimateCost.OAttorneyFee = numericUpDown_OAttorneyFee.Value;
            dr["OAttorneyFee"] = CCTrademarkEstimateCost.OAttorneyFee;

            //國外事務所費用-幣別
            if (comboBox_OMoney.SelectedValue != null)
            {
                CCTrademarkEstimateCost.OMoney = comboBox_OMoney.SelectedValue.ToString();
            }
            else
            {
                CCTrademarkEstimateCost.OMoney = "";
            }
            dr["OMoney"] = CCTrademarkEstimateCost.OAttorneyFee;

            //國外事務所費用-匯率
            CCTrademarkEstimateCost.OtoNT = numericUpDown_Money2.Value;
            dr["OtoNT"] = CCTrademarkEstimateCost.OtoNT;

            //國外事務所費用-合計NT
            decimal decOTotall = 0m;
            decimal.TryParse(txt_OTotall.Text, out decOTotall);
            CCTrademarkEstimateCost.OTotall = decOTotall;
            dr["OTotall"] = CCTrademarkEstimateCost.OTotall;

            CCTrademarkEstimateCost.GovFee = numericUpDown_GovFee.Value;
            dr["GovFee"] = CCTrademarkEstimateCost.GovFee;

            CCTrademarkEstimateCost.GMoney = cboMoney2.Text;
            dr["GMoney"] = CCTrademarkEstimateCost.GMoney;

            
            CCTrademarkEstimateCost.GtoNT = numericUpDown_Money3.Value;
            dr["GtoNT"] = CCTrademarkEstimateCost.GtoNT;


            decimal decGTotall = 0m;
            decimal.TryParse(txt_GTotall.Text, out decGTotall);
            CCTrademarkEstimateCost.GTotall = decGTotall;
            dr["GTotall"] = CCTrademarkEstimateCost.GTotall;

            CCTrademarkEstimateCost.OtherFee = numericUpDown_OtherFee.Value;
            dr["OtherFee"] = CCTrademarkEstimateCost.OtherFee;

            CCTrademarkEstimateCost.OtherMoney = cboMoney3.Text;
            dr["OtherMoney"] = CCTrademarkEstimateCost.OtherMoney;

            
            CCTrademarkEstimateCost.OtherNT = numericUpDown_Money4.Value;
            dr["OtherNT"] = CCTrademarkEstimateCost.OtherNT;


            decimal decOtherTotal = 0m;
            decimal.TryParse(txt_OtherTotal.Text, out decOtherTotal);
            CCTrademarkEstimateCost.OtherTotal = decOtherTotal;
            dr["OtherTotal"] = CCTrademarkEstimateCost.OtherTotal;

            decimal decEstimateCost = 0m;
            decimal.TryParse(txt_EstimateCost.Text, out decEstimateCost);
            CCTrademarkEstimateCost.EstimateCost = decEstimateCost;
            dr["EstimateCost"] = CCTrademarkEstimateCost.EstimateCost;

            CCTrademarkEstimateCost.EstimateProfit = numericUpDown_EstimateProfit.Value;
            dr["EstimateProfit"] = CCTrademarkEstimateCost.EstimateProfit;

            CCTrademarkEstimateCost.RealPrice = numericUpDown_RealPrice.Value;
            dr["RealPrice"] = CCTrademarkEstimateCost.RealPrice;

            CCTrademarkEstimateCost.PayMemo = txt_PayMemo.Text;
            dr["PayMemo"] = CCTrademarkEstimateCost.PayMemo;

            CCTrademarkEstimateCost.Remark = txt_Remark.Text;
            dr["Remark"] = CCTrademarkEstimateCost.Remark;

            DateTime dt_CreateDate = new DateTime();
            bool IsCheckCreateDate = DateTime.TryParse(maskedTextBox_CreateDate.Text, out dt_CreateDate);
            if (IsCheckCreateDate) CCTrademarkEstimateCost.CreateDate = dt_CreateDate;
            else CCTrademarkEstimateCost.CreateDate = new DateTime(1900, 1, 1);

            if (CCTrademarkEstimateCost.CreateDate.Year != 1900)
            {
                dr["CreateDate"] = CCTrademarkEstimateCost.CreateDate;
            }
            else { dr["CreateDate"] = DBNull.Value; }

            decimal decServicePrice = 0m;
            decimal.TryParse(txt_ServicePrice.Text, out decServicePrice);
            dr["ServicePrice"] = decServicePrice;

            CCTrademarkEstimateCost.LastModifyDate = DateTime.Now;
            CCTrademarkEstimateCost.LastModifyWorker = Properties.Settings.Default.WorkerKEY;

            dr["LastModifyDate"] = CCTrademarkEstimateCost.LastModifyDate;
            dr["LastModifyWorker"] = Properties.Settings.Default.WorkerName;


            CCTrademarkEstimateCost.Insert();
            dr["TMControveryEstimateCostID"] = CCTrademarkEstimateCost.TMControveryEstimateCostID;

           

            Forms.TrademarkControversyMF.dt_TrademarkControveryEstimateCostT.Rows.Add(dr);
            Forms.TrademarkControversyMF.dt_TrademarkControveryEstimateCostT.AcceptChanges();

            MessageBox.Show("新增成功");
            this.Close();
        }

        private void numericUpDown_IAttorneyFee_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown fee = (NumericUpDown)sender;
            switch (fee.Name)
            {
                case "numericUpDown_IAttorneyFee":
                    cboMoney1_SelectedIndexChanged(cboMoney1, null);
                    break;
                case "numericUpDown_OAttorneyFee":
                    cboMoney1_SelectedIndexChanged(comboBox_OMoney, null);
                    break;
                case "numericUpDown_GovFee":
                    cboMoney1_SelectedIndexChanged(cboMoney2, null);
                    break;
                case "numericUpDown_OtherFee":
                    cboMoney1_SelectedIndexChanged(cboMoney3, null);
                    break;
            }
        }

        private void AddTrademarkControversyEstimateCost_KeyDown(object sender, KeyEventArgs e)
        {
            Public.Utility.ControlTab(e);
        }

       
    }
}
