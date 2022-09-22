using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LawtechPTSystem.EditForm
{
    public partial class EditTrademarkEstimateCost : Form
    {
        public EditTrademarkEstimateCost()
        {
            InitializeComponent();
        }

        private int iTMEstimateCostID = -1;
        /// <summary>
        /// 預估成本資料表 ID
        /// </summary>
        public int TMEstimateCostID
        {
            get { return iTMEstimateCostID; }
            set { iTMEstimateCostID = value; }
        }

        private void butCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EditTrademarkEstimateCost_Load(object sender, EventArgs e)
        {
            this.moneyTTableAdapter.Fill(this.dataSet_Drop.MoneyT);

            Public.CTrademarkEstimateCost CCTrademarkEstimateCost = new Public.CTrademarkEstimateCost();
            Public.CTrademarkEstimateCost.ReadOne(TMEstimateCostID, ref CCTrademarkEstimateCost);
                     

            txt_ES_FeeSubject.Text = CCTrademarkEstimateCost.FeeSubject;

           
            numericUpDown_IAttorneyFee.Value = CCTrademarkEstimateCost.IAttorneyFee.HasValue?CCTrademarkEstimateCost.IAttorneyFee.Value:0;

            cboMoney1.SelectedValue = CCTrademarkEstimateCost.IMoney;

            numericUpDown_Money1.Value = CCTrademarkEstimateCost.ItoNT.HasValue ? CCTrademarkEstimateCost.ItoNT.Value : 0;

            txt_ITotall.Text = CCTrademarkEstimateCost.ITotall.HasValue ? CCTrademarkEstimateCost.ITotall.Value.ToString("#,##0.##") : "0";

            numericUpDown_GovFee.Value = CCTrademarkEstimateCost.GovFee.HasValue ? CCTrademarkEstimateCost.GovFee.Value : 0;

            
            //複代
            numericUpDown_OAttorneyFee.Value = CCTrademarkEstimateCost.OAttorneyFee.HasValue ? CCTrademarkEstimateCost.OAttorneyFee.Value : 0;

            comboBox_OMoney.SelectedValue = CCTrademarkEstimateCost.OMoney;

            numericUpDown_Money2.Value = CCTrademarkEstimateCost.OtoNT.HasValue ? CCTrademarkEstimateCost.OtoNT.Value : 0;

            txt_OTotall.Text = CCTrademarkEstimateCost.OTotall.HasValue ? CCTrademarkEstimateCost.OTotall.Value.ToString("#,##0.##") : "0";



            //官方
            cboMoney2.SelectedValue = CCTrademarkEstimateCost.GMoney;

            numericUpDown_Money3.Value = CCTrademarkEstimateCost.GtoNT.HasValue ? CCTrademarkEstimateCost.GtoNT.Value : 0;

            txt_GTotall.Text = CCTrademarkEstimateCost.GTotall.HasValue ? CCTrademarkEstimateCost.GTotall.Value.ToString("#,##0.##") : "0";

            numericUpDown_OtherFee.Value = CCTrademarkEstimateCost.OtherFee.HasValue ? CCTrademarkEstimateCost.OtherFee.Value : 0;

           
            cboMoney3.SelectedValue = CCTrademarkEstimateCost.OtherMoney;

            numericUpDown_Money4.Value = CCTrademarkEstimateCost.OtherNT.HasValue ? CCTrademarkEstimateCost.OtherNT.Value : 0;

            txt_OtherTotal.Text = CCTrademarkEstimateCost.OtherTotal.HasValue ? CCTrademarkEstimateCost.OtherTotal.Value.ToString("#,##0.##") : "0";



            txt_EstimateCost.Text = CCTrademarkEstimateCost.EstimateCost.HasValue ? CCTrademarkEstimateCost.EstimateCost.Value.ToString("#,##0.##") : "0";

            numericUpDown_EstimateProfit.Value = CCTrademarkEstimateCost.EstimateProfit.HasValue ? CCTrademarkEstimateCost.EstimateProfit.Value : 0;

            numericUpDown_RealPrice.Value = CCTrademarkEstimateCost.RealPrice.HasValue ? CCTrademarkEstimateCost.RealPrice.Value : 0;

            txt_PayMemo.Text = CCTrademarkEstimateCost.PayMemo;

            txt_Remark.Text = CCTrademarkEstimateCost.Remark;

            maskedTextBox_CreateDate.Text = CCTrademarkEstimateCost.CreateDate.HasValue ? CCTrademarkEstimateCost.CreateDate.Value.ToString("yyyy/MM/dd") : "";
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
        private void rateMoney(ComboBox cboMoney, NumericUpDown txtMoney, NumericUpDown NumericUpDownAttorneyFee, TextBox txtFeeTotal1)
        {
            if (cboMoney.Text != "")
            {
                decimal dec = 0;

                dec =txtMoney.Value * NumericUpDownAttorneyFee.Value;
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
            decimal decServicePrice = dTol+(dTol * numericUpDown_EstimateProfit.Value) / 100;
            txt_ServicePrice.Text = decServicePrice.ToString("#,##0.##");

        }
        #endregion

        #region numericUpDown_EstimateProfit_ValueChanged
        private void numericUpDown_EstimateProfit_ValueChanged(object sender, EventArgs e)
        {
            decimal decServicePrice = 0m;
            decimal.TryParse(txt_EstimateCost.Text, out decServicePrice);
            decServicePrice = decServicePrice+(decServicePrice * numericUpDown_EstimateProfit.Value) / 100;
            txt_ServicePrice.Text = decServicePrice.ToString("#,##0.##");
        }
        #endregion

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

        private void butOK_Click(object sender, EventArgs e)
        {
            if (txt_ES_FeeSubject.Text == "")
            {
                MessageBox.Show("費用內容不得為空白", "提示訊息");
                txt_ES_FeeSubject.Focus();
                return;
            }

            Public.CTrademarkEstimateCost CCTrademarkEstimateCost = new Public.CTrademarkEstimateCost();
            Public.CTrademarkEstimateCost.ReadOne(TMEstimateCostID, ref CCTrademarkEstimateCost);

            Public.PublicForm Forms = new Public.PublicForm();
            //DataSet_TM.TrademarkEstimateCostTRow dr = Forms.TrademarkMF.dt_TrademarkEstimateCostT.FindByTMEstimateCostID(TMEstimateCostID);

           

            CCTrademarkEstimateCost.FeeSubject = txt_ES_FeeSubject.Text;
            //dr["FeeSubject"] = CCTrademarkEstimateCost.FeeSubject;

            CCTrademarkEstimateCost.IAttorneyFee = numericUpDown_IAttorneyFee.Value;
            //dr["IAttorneyFee"] = CCTrademarkEstimateCost.IAttorneyFee;

            if (cboMoney1.SelectedValue != null)
            {
                CCTrademarkEstimateCost.IMoney = cboMoney1.SelectedValue.ToString();
            }
            else
            {
                CCTrademarkEstimateCost.IMoney = "";
            }
            //dr["IMoney"] = CCTrademarkEstimateCost.IMoney;


            CCTrademarkEstimateCost.ItoNT = numericUpDown_Money1.Value;
            //dr["ItoNT"] = CCTrademarkEstimateCost.ItoNT;

            decimal decITotall = 0m;
            decimal.TryParse(txt_ITotall.Text, out decITotall);
            CCTrademarkEstimateCost.ITotall = decITotall;
            //dr["ITotall"] = CCTrademarkEstimateCost.ITotall;


            //國外事務所費用
            CCTrademarkEstimateCost.OAttorneyFee = numericUpDown_OAttorneyFee.Value;
            //dr["OAttorneyFee"] = CCTrademarkEstimateCost.OAttorneyFee;

            //國外事務所費用-幣別
            if (comboBox_OMoney.SelectedValue != null)
            {
                CCTrademarkEstimateCost.OMoney = comboBox_OMoney.SelectedValue.ToString();
            }
            else
            {
                CCTrademarkEstimateCost.OMoney = "";
            }
            //dr["OMoney"] = CCTrademarkEstimateCost.OAttorneyFee;

            //國外事務所費用-匯率
            CCTrademarkEstimateCost.OtoNT = numericUpDown_Money2.Value;
            //dr["OtoNT"] = CCTrademarkEstimateCost.OtoNT;

            //國外事務所費用-合計NT
            decimal decOTotall = 0m;
            decimal.TryParse(txt_OTotall.Text, out decOTotall);
            CCTrademarkEstimateCost.OTotall = decOTotall;
            //dr["OTotall"] = CCTrademarkEstimateCost.OTotall;


            CCTrademarkEstimateCost.GovFee = numericUpDown_GovFee.Value;
            //dr["GovFee"] = CCTrademarkEstimateCost.GovFee;
            if (cboMoney2.SelectedValue != null)
            {
                CCTrademarkEstimateCost.GMoney = cboMoney2.SelectedValue.ToString();
            }
            else
            {
                CCTrademarkEstimateCost.GMoney = "";
            }
            //dr["GMoney"] = CCTrademarkEstimateCost.GMoney;


            CCTrademarkEstimateCost.GtoNT = numericUpDown_Money3.Value;
            //dr["GtoNT"] = CCTrademarkEstimateCost.GtoNT;

            decimal decGTotall = 0m;
            decimal.TryParse(txt_GTotall.Text, out decGTotall);
            CCTrademarkEstimateCost.GTotall = decGTotall;
            //dr["GTotall"] = CCTrademarkEstimateCost.GTotall;

            CCTrademarkEstimateCost.OtherFee = numericUpDown_OtherFee.Value;
            //dr["OtherFee"] = CCTrademarkEstimateCost.OtherFee;
            if (cboMoney3.SelectedValue != null)
            {
                CCTrademarkEstimateCost.OtherMoney = cboMoney3.SelectedValue.ToString();
            }
            else
            {
                CCTrademarkEstimateCost.OtherMoney = "";
            }
            //dr["OtherMoney"] = CCTrademarkEstimateCost.OtherMoney;


            CCTrademarkEstimateCost.OtherNT = numericUpDown_Money4.Value;
            //dr["OtherNT"] = CCTrademarkEstimateCost.OtherNT;

            decimal decOtherTotal = 0m;
            decimal.TryParse(txt_OtherTotal.Text, out decOtherTotal);
            CCTrademarkEstimateCost.OtherTotal = decOtherTotal;
            //dr["OtherTotal"] = CCTrademarkEstimateCost.OtherTotal;

            //預估報價-合計NT
            decimal decServicePrice = 0m;
            decimal.TryParse(txt_ServicePrice.Text, out decServicePrice);
            CCTrademarkEstimateCost.ServicePrice = decServicePrice;

            decimal decEstimateCost = 0m;
            decimal.TryParse(txt_EstimateCost.Text, out decEstimateCost);
            CCTrademarkEstimateCost.EstimateCost = decEstimateCost;
            //dr["EstimateCost"] = CCTrademarkEstimateCost.EstimateCost;

            CCTrademarkEstimateCost.EstimateProfit = numericUpDown_EstimateProfit.Value;
            //dr["EstimateProfit"] = CCTrademarkEstimateCost.EstimateProfit;

            CCTrademarkEstimateCost.RealPrice = numericUpDown_RealPrice.Value;
            //dr["RealPrice"] = CCTrademarkEstimateCost.RealPrice;

            CCTrademarkEstimateCost.PayMemo = txt_PayMemo.Text;
            //dr["PayMemo"] = CCTrademarkEstimateCost.PayMemo;

            CCTrademarkEstimateCost.Remark = txt_Remark.Text;
            //dr["Remark"] = CCTrademarkEstimateCost.Remark;

            DateTime dt_CreateDate = new DateTime();
            bool IsCheckCreateDate = DateTime.TryParse(maskedTextBox_CreateDate.Text, out dt_CreateDate);
            if (IsCheckCreateDate) CCTrademarkEstimateCost.CreateDate = dt_CreateDate;
            else CCTrademarkEstimateCost.CreateDate = null;
                       
            CCTrademarkEstimateCost.LastModifyWorker = Properties.Settings.Default.WorkerName;

           
            CCTrademarkEstimateCost.Update();

            if (Forms.TrademarkMF != null)
            {
                DataRow dr = Forms.TrademarkMF.dt_TrademarkEstimateCostT.Rows.Find(TMEstimateCostID);
                Forms.TrademarkMF.dt_TrademarkEstimateCostT.Rows.Remove(dr);

                DataRow drNew = Forms.TrademarkMF.dt_TrademarkEstimateCostT.NewRow();
                DataRow drV = Public.CTrademarkPublicFunction.GetTrademarkEstimateCost(CCTrademarkEstimateCost.TMEstimateCostID.ToString());
                drNew.ItemArray = drV.ItemArray;
                Forms.TrademarkMF.dt_TrademarkEstimateCostT.Rows.Add(drNew);
            }

            MessageBox.Show("修改成功  ","提示訊息");
            this.Close();

        }

        private void maskedTextBox_CreateDate_DoubleClick(object sender, EventArgs e)
        {
            MaskedTextBox mtb = (MaskedTextBox)sender;
            DateTime dt;
            bool IsSuccess = DateTime.TryParse(mtb.Text, out dt);
            if (!IsSuccess)
            {
                mtb.Text = DateTime.Now.ToString("yyyy/MM/dd");
            }
        }

        private void EditTrademarkEstimateCost_FormClosed(object sender, FormClosedEventArgs e)
        {
            //解除資料鎖定
            Public.Utility.NuLockRecordAuth("TrademarkEstimateCostT", "TMEstimateCostID=" + TMEstimateCostID.ToString());
        }

        private void EditTrademarkEstimateCost_KeyDown(object sender, KeyEventArgs e)
        {
            Public.Utility.ControlTab(e);
        }

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

        private void maskedTextBox_CreateDate_Leave(object sender, EventArgs e)
        {
            MaskedTextBox mak = (MaskedTextBox)sender;
            Public.Utility.CheckMaskedtextbox(mak);
        }
    }
}
