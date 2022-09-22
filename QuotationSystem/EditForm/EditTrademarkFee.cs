using System;
using System.Data;
using System.Windows.Forms;

namespace LawtechPTSystem.EditForm
{
    public partial class EditTrademarkFee : Form
    {
        public EditTrademarkFee()
        {
            InitializeComponent();
        }

        private int iFeeKEY = -1;
        /// <summary>
        /// 請款費用資料表 ID
        /// </summary>
        public int property_FeeKEY
        {
            get { return iFeeKEY; }
            set { iFeeKEY = value; }
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

        private void EditTrademarkFee_Load(object sender, EventArgs e)
        {
            this.feePhaseTByTMTableAdapter.Fill(this.dataSet_Drop.FeePhaseTByTM);
            this.attorneyTTableAdapter.Fill(this.dataSet_Drop.AttorneyT);    
            this.moneyTTableAdapter.Fill(this.dataSet_Drop.MoneyT);           
            this.workerTAllTableAdapter.Fill(this.qS_DataSet.WorkerTAll);
            this.payKindTableAdapter.Fill(this.dataSet_Drop.PayKind);

            attorneyTBindingSource1.Filter = "CountrySymbol ='" + CountrySymbol + "'";

            Public.CTrademarkFee Edit = new Public.CTrademarkFee();
            Public.CTrademarkFee.ReadOne(iFeeKEY, ref Edit);
         

            txt_FeeSubject.Text = Edit.FeeSubject;
            if (Edit.FeePhase != null)
            {
                comboBox_FeePhase.SelectedValue = Edit.FeePhase;
            }

            cb_OthFeeName.Text = Edit.OthFeeName;
            cb_CustomizeName.Text = Edit.CustomizeName;
            cb_OtherTotalFeeCustomize1Name.Text = Edit.OtherTotalFeeCustomize1Name;
            cb_OtherTotalFeeCustomize2Name.Text = Edit.OtherTotalFeeCustomize2Name;
            cb_OtherTotalFeeCustomize3Name.Text = Edit.OtherTotalFeeCustomize3Name;

            //服務費、代收代付           
            numericUpDown_AttorneyFee2.Value = Edit.OAttorneyFee.Value;
            numericUpDown_AttorneyFee3.Value = Edit.OthFee.Value;
            numericUpDown_AttorneyFee4.Value = Edit.GovFee.Value;
            numericUpDown_AttorneyFee5.Value = Edit.CustomizeOthFee ?? 0;

            //幣別           
            cboMoney2.SelectedValue = Edit.OMoney??"";
            cboMoney3.SelectedValue = Edit.OthMoney??"";
            cboMoney4.SelectedValue = Edit.GMoney??"";
            cboMoney5.SelectedValue = Edit.CustomizeMoney ?? "";

            //匯率           
            numericUpDown_Money2.Value = Edit.OtoNT.Value;
            numericUpDown_Money3.Value = Edit.OthtoNT.Value;
            numericUpDown_Money4.Value = Edit.GtoNT.Value;
            numericUpDown_Money5.Value = Edit.CustomizeNT ?? 0;

            txtAttorneyFeeTotal2.Text = Edit.OTotall.Value.ToString("#,##0.##");
            txtAttorneyFeeTotal3.Text = Edit.OthTotal.Value.ToString("#,##0.##");
            txtAttorneyFeeTotal4.Text = Edit.GTotall.Value.ToString("#,##0.##");
            txtAttorneyFeeTotal5.Text = Edit.CustomizeTotal.HasValue ? Edit.CustomizeTotal.Value.ToString("#,##0.##") : "0";


            //所內收費-服務費
            numericUpDown_OtherFee.Text = Edit.OtherTotalFee.Value.ToString("#,##0.##");
            numericUpDown_OtherTotalFeeCustomize1.Text = Edit.OtherTotalFeeCustomize1.HasValue ? Edit.OtherTotalFeeCustomize1.Value.ToString("#,##0.##") : "0";
            numericUpDown_OtherTotalFeeCustomize2.Text = Edit.OtherTotalFeeCustomize2.HasValue ? Edit.OtherTotalFeeCustomize2.Value.ToString("#,##0.##") : "0";
            numericUpDown_OtherTotalFeeCustomize3.Text = Edit.OtherTotalFeeCustomize3.HasValue ? Edit.OtherTotalFeeCustomize3.Value.ToString("#,##0.##") : "0";

            //收費合計
            txt_OtherTotalFeeInSide.Text = Edit.OtherTotalFeeInSide.HasValue ? Edit.OtherTotalFeeInSide.Value.ToString("#,##0.##") : "0";

            //稅額%
            numericUpDown_TaxPercent.Value = Edit.TaxPercent.HasValue ? Edit.TaxPercent.Value : 0;

            //預扣稅額
            numericUpDown_Tax.Value = Edit.Tax.HasValue ? Edit.Tax.Value : 0;

            //外幣收款
            cb_NT.Checked = Edit.NT.HasValue ? Edit.NT.Value : false;

            //複代
            if (Edit.Attorney.HasValue)
            {
                comboBox_Attorney.SelectedValue = Edit.Attorney;
            }

            mskRDate.Text = Edit.RDate.HasValue ? Edit.RDate.Value.ToString("yyyy/MM/dd") : "    /  /";
            mskCollectionPeriod.Text = Edit.CollectionPeriod.HasValue ? Edit.CollectionPeriod.Value.ToString("yyyy/MM/dd") : "    /  /";

            cboFClientTransactor.SelectedValue = Edit.FClientTransactor;
            
           //代收代付合計
            txtOAttorneyGovFee.Text = Edit.OAttorneyGovFee.Value.ToString("#,##0");

            #region 請款合計
            numericUpDown_Totall.Value = Edit.Totall.Value;
            cboMoney1.SelectedValue = Edit.TMoney ?? "";
            numericUpDown_Money1.Value = Edit.TtoNT.Value;
            txtAttorneyFeeTotal1.Text = Edit.TotalNT.Value.ToString("#,##0.##"); 
            #endregion

            //主管簽核
            txt_SingcCode.Text = Edit.SingCode;

            txt_PayMemo.Text = Edit.PayMemo;

          
            if (Edit.Days > 0)
            {
                numericUpDown_Days.Value = Edit.Days.Value;
            }
            else
            {
                numericUpDown_Days.Value = 0;
            }


            //取得登入者身份
            iWorkerID = Properties.Settings.Default.WorkerKEY;
            Worker_Model worker = new Worker_Model();
            Worker_Model.ReadOne(iWorkerID, ref  worker);
           
            iOfficeRole = worker.OfficeRole.Value;
            strWorkerName = worker.EmployeeName;


            SetOfficeRole();
         

            //this.cboMoney1.SelectedIndexChanged += new System.EventHandler(this.cboMoney1_Changed);
            //this.cboMoney2.SelectedIndexChanged += new System.EventHandler(this.cboMoney1_Changed);
            //this.cboMoney3.SelectedIndexChanged += new System.EventHandler(this.cboMoney1_Changed);
        }

        private void but_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
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
                        //if (txt.Name == "numericUpDown_Money2")
                        //{
                        //    numericUpDown_Money3.Value = numericUpDown_Money2.Value;
                        //}
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
                    case "numericUpDown_AttorneyFee5":
                    case "numericUpDown_Money5":
                        rateMoney(cboMoney5, numericUpDown_Money5, numericUpDown_AttorneyFee5, txtAttorneyFeeTotal5);
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
            decimal dout = 0;//複代費用
            decimal doutOther = 0;//複代雜費
            decimal de = 0;//官方規費

            //複代費用
            if (txtAttorneyFeeTotal2.Text != "" && Public.Utility.isNumeric(txtAttorneyFeeTotal2.Text, "decimal"))
            {
                dout = decimal.Parse(txtAttorneyFeeTotal2.Text);
            }

            //複代雜費
            if (txtAttorneyFeeTotal3.Text != "" && Public.Utility.isNumeric(txtAttorneyFeeTotal3.Text, "decimal"))
            {
                doutOther = decimal.Parse(txtAttorneyFeeTotal3.Text);
            }

            //官方規費
            if (txtAttorneyFeeTotal4.Text != "" && Public.Utility.isNumeric(txtAttorneyFeeTotal4.Text, "decimal"))
            {
                de = decimal.Parse(txtAttorneyFeeTotal4.Text);
            }

            //自定義費用
            if (txtAttorneyFeeTotal5.Text != "" && Public.Utility.isNumeric(txtAttorneyFeeTotal5.Text, "decimal"))
            {
                din = decimal.Parse(txtAttorneyFeeTotal5.Text);
            }


            //代收代付合計=複代合計+複代雜費+官方規費
            dTol = dout + de + doutOther + din;
            txtOAttorneyGovFee.Text = dTol.ToString("#,##0");
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
                        if (cboMoney1.SelectedValue != null && cboMoney1.SelectedValue.ToString() != "NTD")
                        {
                            cb_NT.Checked = true;
                        }
                        else
                        {
                            cb_NT.Checked = false;
                        }
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
                    case "cboMoney5":
                        numericUpDown_Money5.Value = (decimal)(((System.Data.DataRowView)(cmb.SelectedItem)).Row["ToNT"]);
                        rateMoney(cmb, numericUpDown_Money5, numericUpDown_AttorneyFee5, txtAttorneyFeeTotal5);
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
        /// <summary>
        /// 所內收費-服務費
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numericUpDown_OtherFee_ValueChanged(object sender, EventArgs e)
        {
            decimal total = numericUpDown_OtherFee.Value + numericUpDown_OtherTotalFeeCustomize1.Value + numericUpDown_OtherTotalFeeCustomize2.Value + numericUpDown_OtherTotalFeeCustomize3.Value;

            txt_OtherTotalFeeInSide.Text = total.ToString("#,##0");

        }
        #endregion

        #region 收費合計  private void txt_OtherTotalFeeInSide_TextChanged(object sender, EventArgs e)
        /// <summary>
        /// 收費合計
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txt_OtherTotalFeeInSide_TextChanged(object sender, EventArgs e)
        {
            decimal decOtherTotalFeeInSide;
            bool bOtherTotalFeeInSide = decimal.TryParse(txt_OtherTotalFeeInSide.Text, out decOtherTotalFeeInSide);

            if (bOtherTotalFeeInSide)
            {
                txt_OtherTotalFeeInSideTax.Text = (decOtherTotalFeeInSide - numericUpDown_Tax.Value).ToString("#,##0");
            }
            else
            {
                txt_OtherTotalFeeInSideTax.Text = "0";
            }

            numericUpDown_TaxPercent_ValueChanged(null, null);
        }
        #endregion

        #region  代收代付合計 + 未稅額合計=請款合計 private void txtOAttorneyGovFee_TextChanged(object sender, EventArgs e)
        /// <summary>
        /// 代收代付合計 + 未稅額合計=請款合計
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtOAttorneyGovFee_TextChanged(object sender, EventArgs e)
        {
            decimal decOAttorneyGovFee;
            bool bOAttorneyGovFee = decimal.TryParse(txtOAttorneyGovFee.Text, out decOAttorneyGovFee);

            decimal decOtherTotalFeeInSideTax;
            bool bOtherTotalFeeInSideTax = decimal.TryParse(txt_OtherTotalFeeInSideTax.Text, out decOtherTotalFeeInSideTax);

            numericUpDown_Totall.Value = decOAttorneyGovFee + decOtherTotalFeeInSideTax;
        }
        #endregion

        #region 稅額% private void numericUpDown_TaxPercent_ValueChanged(object sender, EventArgs e)
        /// <summary>
        /// 稅額%
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numericUpDown_TaxPercent_ValueChanged(object sender, EventArgs e)
        {
            decimal decOtherTotalFeeInSide;
            bool bOtherTotalFeeInSide = decimal.TryParse(txt_OtherTotalFeeInSide.Text, out decOtherTotalFeeInSide);
            if (bOtherTotalFeeInSide)
            {
                numericUpDown_Tax.Value = (numericUpDown_TaxPercent.Value / 100) * decOtherTotalFeeInSide;
            }
            else
            {
                numericUpDown_Tax.Value = 0;
            }
        }
        #endregion

        #region 預扣稅額   private void numericUpDown_Tax_ValueChanged(object sender, EventArgs e)
        /// <summary>
        /// 預扣稅額
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numericUpDown_Tax_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown_Tax.Value > 0)
            {
                cb_Withholding.Checked = true;
            }
            else
            {
                cb_Withholding.Checked = false;
            }

            decimal decOtherTotalFeeInSide;
            bool bOtherTotalFeeInSide = decimal.TryParse(txt_OtherTotalFeeInSide.Text, out decOtherTotalFeeInSide);

            if (bOtherTotalFeeInSide)
            {
                txt_OtherTotalFeeInSideTax.Text = (decOtherTotalFeeInSide - numericUpDown_Tax.Value).ToString("#,##0");
            }
            else
            {
                txt_OtherTotalFeeInSideTax.Text = "0";
            }
        }
        #endregion
        
        #region but_OK_Click
        private void but_OK_Click(object sender, EventArgs e)
        {
            if (txt_FeeSubject.Text.Trim() != "")
            {
                Public.CTrademarkFee add = new Public.CTrademarkFee();
                Public.CTrademarkFee.ReadOne(iFeeKEY, ref add);
                add.SingCode = txt_SingcCode.Text;
                add.FeeSubject = txt_FeeSubject.Text;
                add.FeePhase = comboBox_FeePhase.SelectedValue != null ? (int)comboBox_FeePhase.SelectedValue : -1;
                add.NT = cb_NT.Checked;
                add.Withholding = cb_Withholding.Checked;

                if (comboBox_Attorney.SelectedValue != null)
                {
                    add.Attorney = (int)comboBox_Attorney.SelectedValue;
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

                #region 代收代付項目(無稅額)
                //複代費用
                add.OAttorneyFee = numericUpDown_AttorneyFee2.Value;

                //複代費用-幣別
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

                //複代雜費-幣別
                if (cboMoney3.SelectedValue != null)
                {
                    add.OthMoney = cboMoney3.SelectedValue.ToString();
                }
                else
                {
                    add.OthMoney = "";
                }

                //複代雜費幣別匯率
                add.OthtoNT = numericUpDown_Money3.Value;
                add.OthFeeName = cb_OthFeeName.Text;
                //複代雜費合計NT
                if (txtAttorneyFeeTotal3.Text != "")
                {
                    add.OthTotal = decimal.Parse(txtAttorneyFeeTotal3.Text);
                }

                //官方規費
                add.GovFee = numericUpDown_AttorneyFee4.Value;

                //官方規費-幣別
                if (cboMoney4.SelectedValue != null)
                {
                    add.GMoney = cboMoney4.SelectedValue.ToString();
                }
                else
                {
                    add.GMoney = "";
                }

                //官方規費-幣別兌換
                add.GtoNT = numericUpDown_Money4.Value;

                //官方規費-合計NT
                if (txtAttorneyFeeTotal4.Text != "")
                {
                    add.GTotall = decimal.Parse(txtAttorneyFeeTotal4.Text);
                }

                //自定義費用
                add.CustomizeName = cb_CustomizeName.Text;
                add.CustomizeOthFee = numericUpDown_AttorneyFee5.Value;

                //自定義費用-幣別
                if (cboMoney5.SelectedValue != null)
                {
                    add.CustomizeMoney = cboMoney5.SelectedValue.ToString();
                }
                else
                {
                    add.CustomizeMoney = "";
                }

                //自定義費用-幣別兌換
                add.CustomizeNT = numericUpDown_Money5.Value;

                //自定義費用-幣別兌換                
                if (txtAttorneyFeeTotal5.Text != "")
                {
                    add.CustomizeTotal = decimal.Parse(txtAttorneyFeeTotal5.Text);
                }

                #endregion

                //服務費
                add.OtherTotalFee = numericUpDown_OtherFee.Value;
                add.OtherTotalFeeCustomize1 = numericUpDown_OtherTotalFeeCustomize1.Value;
                add.OtherTotalFeeCustomize2 = numericUpDown_OtherTotalFeeCustomize2.Value;
                add.OtherTotalFeeCustomize3 = numericUpDown_OtherTotalFeeCustomize3.Value;
                add.OtherTotalFeeCustomize1Name = cb_OtherTotalFeeCustomize1Name.Text;
                add.OtherTotalFeeCustomize2Name = cb_OtherTotalFeeCustomize2Name.Text;
                add.OtherTotalFeeCustomize3Name = cb_OtherTotalFeeCustomize3Name.Text;


                //所內收費合計
                decimal decOtherTotalFeeInSide;
                bool bOtherTotalFeeInSide = decimal.TryParse(txt_OtherTotalFeeInSide.Text, out decOtherTotalFeeInSide);
                add.OtherTotalFeeInSide = decOtherTotalFeeInSide;

                //稅額%
                add.TaxPercent = numericUpDown_TaxPercent.Value;
                add.Tax = numericUpDown_Tax.Value;

                //未稅額合計(收費合計-預扣稅額)
                decimal decOtherTotalFeeInSideTax;
                bool bOtherTotalFeeInSideTax = decimal.TryParse(txt_OtherTotalFeeInSideTax.Text, out decOtherTotalFeeInSideTax);
                add.OtherTotalFeeInSideTax = decOtherTotalFeeInSideTax;

                add.FeePhase = comboBox_FeePhase.SelectedValue != null ? (int)comboBox_FeePhase.SelectedValue : -1;



                DateTime dt_RDate;
                bool IsRDate = DateTime.TryParse(mskRDate.Text, out dt_RDate);
                if (IsRDate) add.RDate = dt_RDate;
                else add.RDate = null;

                DateTime dt_CollectionPeriod;
                bool IsCollectionPeriod = DateTime.TryParse(mskCollectionPeriod.Text, out dt_CollectionPeriod);
                if (IsCollectionPeriod) add.CollectionPeriod = dt_CollectionPeriod;
                else add.CollectionPeriod = null;


                if (cboFClientTransactor.SelectedValue != null)
                {
                    add.FClientTransactor = (int)cboFClientTransactor.SelectedValue;
                }

                if (txtOAttorneyGovFee.Text != "")
                {
                    add.OAttorneyGovFee = decimal.Parse(txtOAttorneyGovFee.Text);
                }

                add.PayMemo = txt_PayMemo.Text;

                add.LastModifyWorker = Properties.Settings.Default.WorkerName;

                add.Update();

                Public.PublicForm Forms = new Public.PublicForm();


                #region Forms.TrademarkMF
                if (Forms.TrademarkMF != null && Forms.TrademarkMF.dt_TrademarkFeeT != null)
                {
                    DataRow dr = Forms.TrademarkMF.dt_TrademarkFeeT.Rows.Find(add.FeeKEY);
                    if (dr != null)
                    {
                        DataRow drV = Public.CTrademarkPublicFunction.GetTrademarkFee(property_FeeKEY.ToString());
                        dr.ItemArray = drV.ItemArray;
                        dr.AcceptChanges();
                    }
                }
                #endregion


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
            MaskedTextBox mtb = (MaskedTextBox)sender;
            DateTime dt = new DateTime();
            bool IsSuccess = DateTime.TryParse(mtb.Text, out dt);
            if (!IsSuccess)
            {
                mtb.Text = DateTime.Now.ToString("yyyy/MM/dd");
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

        #region ==============but_SingOff_Click==============
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
                    txt_SingCodeStatus.Text += "★" + WorkerName + DateTime.Now.ToString("yyyy-MM-dd HH:mm") + "簽核\r\n";
                }
                else
                {
                    but_SingOff.Text = "簽核";
                    but_SingOff.Tag = "Sing";
                    txt_SingCodeStatus.Text += "Ⅹ" + WorkerName + DateTime.Now.ToString("yyyy-MM-dd HH:mm") + "取消簽核\r\n";
                }
            }


        }
        #endregion

        private void EditTrademarkFee_FormClosed(object sender, FormClosedEventArgs e)
        {
            Public.Utility.NuLockRecordAuth("TrademarkFeeT", "FeeKEY=" + property_FeeKEY.ToString());
        }

        private void EditTrademarkFee_KeyDown(object sender, KeyEventArgs e)
        {
            Public.Utility.ControlTab(e);
        }

        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Name)
            {
                case "ToolStripMenuItem_All":
                    checkBox_All.Checked = true;
                    attorneyTBindingSource1.Filter = "";
                    break;
                case "ToolStripMenuItem_CurrentCountry":
                    if (CountrySymbol != "")
                    {
                        checkBox_All.Checked = false;
                        attorneyTBindingSource1.Filter = "Country ='" + CountrySymbol + "'";
                    }
                    break;
            }
        }

        private void mskRDate_Leave(object sender, EventArgs e)
        {
            MaskedTextBox mak = (MaskedTextBox)sender;
            Public.Utility.CheckMaskedtextbox(mak);
        }
    }
}
