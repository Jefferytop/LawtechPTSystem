﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LawtechPTSystem.AddFrom
{
    public partial class AddTrademarkEstimateCost : Form
    {
        public AddTrademarkEstimateCost()
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

        private void butCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void butOK_Click(object sender, EventArgs e)
        {
            if (txt_ES_FeeSubject.Text == "")
            {
                MessageBox.Show("費用內容不得為空白","提示訊息");
                txt_ES_FeeSubject.Focus();
                return;
            }

            Public.CTrademarkEstimateCost CCTrademarkEstimateCost = new Public.CTrademarkEstimateCost();
            
            Public.PublicForm Forms = new Public.PublicForm();
            DataRow dr=  Forms.TrademarkMF.dt_TrademarkEstimateCostT.NewRow();

            CCTrademarkEstimateCost.TrademarkID = TrademarkID;
              

            CCTrademarkEstimateCost.FeeSubject = txt_ES_FeeSubject.Text;
          

            CCTrademarkEstimateCost.IAttorneyFee = numericUpDown_IAttorneyFee.Value;
           

            //服務費-幣別
            if (cboMoney1.SelectedValue != null)
            {
                CCTrademarkEstimateCost.IMoney = cboMoney1.SelectedValue.ToString();
            }
            else
            {
                CCTrademarkEstimateCost.IMoney = "";
            }
           

           //本所費用 匯率
            CCTrademarkEstimateCost.ItoNT = numericUpDown_Money1.Value;
          

            decimal decITotall = 0m;
            decimal.TryParse(txt_ITotall.Text, out decITotall);
            CCTrademarkEstimateCost.ITotall =decITotall;
            

            //國外事務所費用
            CCTrademarkEstimateCost.OAttorneyFee = numericUpDown_OAttorneyFee.Value;
           

            //國外事務所費用-幣別
            if (comboBox_OMoney.SelectedValue != null)
            {
                CCTrademarkEstimateCost.OMoney = comboBox_OMoney.SelectedValue.ToString();
            }
            else
            {
                CCTrademarkEstimateCost.OMoney = "";
            }
           

            //國外事務所費用-匯率
            CCTrademarkEstimateCost.OtoNT = numericUpDown_Money2.Value;
           

            //國外事務所費用-合計NT
            decimal decOTotall = 0m;
            decimal.TryParse(txt_OTotall.Text, out decOTotall);
            CCTrademarkEstimateCost.OTotall = decOTotall;
           

            CCTrademarkEstimateCost.GovFee = numericUpDown_GovFee.Value;
           

            if (cboMoney2.SelectedValue != null)
            {
                CCTrademarkEstimateCost.GMoney = cboMoney2.SelectedValue.ToString();
            }
            else
            {
                CCTrademarkEstimateCost.GMoney = "";
            }
          

            //官方費用匯率
            CCTrademarkEstimateCost.GtoNT = numericUpDown_Money3.Value;
           

            decimal decGTotall = 0m;
            decimal.TryParse(txt_GTotall.Text, out decGTotall);
            CCTrademarkEstimateCost.GTotall = decGTotall;
           

            CCTrademarkEstimateCost.OtherFee = numericUpDown_OtherFee.Value;
            

            if (cboMoney3.SelectedValue != null)
            {
                CCTrademarkEstimateCost.OtherMoney = cboMoney3.SelectedValue.ToString();
            }
            else
            {
                CCTrademarkEstimateCost.OtherMoney = "";
            }
           

            //複代費用匯率           
            CCTrademarkEstimateCost.OtherNT = numericUpDown_Money4.Value;
         

            decimal decOtherTotal = 0m;
            decimal.TryParse(txt_OtherTotal.Text, out decOtherTotal);
            CCTrademarkEstimateCost.OtherTotal = decOtherTotal;
          

            decimal decEstimateCost = 0m;
            decimal.TryParse(txt_EstimateCost.Text, out decEstimateCost);
            CCTrademarkEstimateCost.EstimateCost = decEstimateCost;
           

            CCTrademarkEstimateCost.EstimateProfit = numericUpDown_EstimateProfit.Value;
          

            CCTrademarkEstimateCost.RealPrice = numericUpDown_RealPrice.Value;
            

            CCTrademarkEstimateCost.PayMemo = txt_PayMemo.Text;
         

            CCTrademarkEstimateCost.Remark = txt_Remark.Text;
          

            DateTime dt_CreateDate = new DateTime();
            bool IsCheckCreateDate = DateTime.TryParse(maskedTextBox_CreateDate.Text, out dt_CreateDate);
            if (IsCheckCreateDate) CCTrademarkEstimateCost.CreateDate = dt_CreateDate;
            else CCTrademarkEstimateCost.CreateDate = null;

           
         
            decimal decServicePrice = 0m;
            decimal.TryParse(txt_ServicePrice.Text, out decServicePrice);
            CCTrademarkEstimateCost.ServicePrice = decServicePrice;

            CCTrademarkEstimateCost.Creator = Properties.Settings.Default.WorkerName;

            CCTrademarkEstimateCost.Create();  
           
            CCTrademarkEstimateCost.LastModifyWorker = Properties.Settings.Default.WorkerName;
            if (Forms.TrademarkMF != null)
            {
                DataRow drV = Public.CTrademarkPublicFunction.GetTrademarkEstimateCost(CCTrademarkEstimateCost.TMEstimateCostID.ToString());
                dr.ItemArray = drV.ItemArray;
                Forms.TrademarkMF.dt_TrademarkEstimateCostT.Rows.Add(dr);
            } 
           

            MessageBox.Show("新增成功");
            this.Close();

        }

        private void AddTrademarkEstimateCost_Load(object sender, EventArgs e)
        {
           
            this.moneyTTableAdapter.Fill(this.dataSet_Drop.MoneyT);

            maskedTextBox_CreateDate.Text = DateTime.Now.ToString("yyyy-MM-dd");

            //numericUpDown_EstimateProfit.Value = 20;
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

        private void numericUpDown_EstimateProfit_ValueChanged(object sender, EventArgs e)
        {            
            decimal decServicePrice =0m;
            decimal.TryParse(txt_EstimateCost.Text, out decServicePrice);
            decServicePrice = decServicePrice+ (decServicePrice * (numericUpDown_EstimateProfit.Value / 100));
            txt_ServicePrice.Text = decServicePrice.ToString("#,##0.##");
        }

        #region numericUpDown_IAttorneyFee_ValueChanged
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
        #endregion

        #region AddTrademarkEstimateCost_KeyDown
        private void AddTrademarkEstimateCost_KeyDown(object sender, KeyEventArgs e)
        {
            Public.Utility.ControlTab(e);
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

    }
}
