using System;
using System.Data;
using System.Windows.Forms;

namespace LawtechPTSystem.AddFrom
{
    public partial class AddPatentFee : Form
    {
        public AddPatentFee()
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

        #region but_Cancel_Click
        private void but_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region ==========確定鈕===========
        private void but_OK_Click(object sender, EventArgs e)
        {
            if (comboBox_FeeSubject.Text.Trim() != "")
            {
                Public.CPatentFee add = new Public.CPatentFee();
                add.PatentID = iPatentID;
                add.SingCode = txt_SingcCode.Text;
                add.FeeSubject = comboBox_FeeSubject.Text;
                add.FeePhase = comboBox_FeePhase.SelectedValue != null ? (int)comboBox_FeePhase.SelectedValue : -1;
                add.NT = cb_NT.Checked;
                add.Withholding = cb_Withholding.Checked;
                //請款人
                if (comboBox_Attorney.SelectedValue != null)
                {
                    add.Attorney = (int)comboBox_Attorney.SelectedValue;
                }

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

                //請款合計-兌NT            
                add.TtoNT = numericUpDown_Money1.Value;

                //請款合計-合計NT
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


                DateTime dt_RDate;
                bool IsRDate = DateTime.TryParse(mskRDate.Text, out dt_RDate);
                if (IsRDate) add.RDate = dt_RDate;
                else add.RDate = null;

                DateTime dt_CollectionPeriod;
                bool IsCollectionPeriod = DateTime.TryParse(mskCollectionPeriod.Text, out dt_CollectionPeriod);
                if (IsCollectionPeriod) add.CollectionPeriod = dt_CollectionPeriod;
                else add.CollectionPeriod = null;

                //請款人
                if (cboFClientTransactor.SelectedValue != null)
                {
                    add.FClientTransactor = (int)cboFClientTransactor.SelectedValue;
                }

               

                //代收代付合計
                if (txtOAttorneyGovFee.Text != "")
                {
                    add.OAttorneyGovFee = decimal.Parse(txtOAttorneyGovFee.Text);
                }

                add.PayMemo = txt_PayMemo.Text;

                add.FClientTransactor = cboFClientTransactor.SelectedValue != null ? (int)cboFClientTransactor.SelectedValue : -1;
                add.IsClosing = false;               
               
                add.Creator = Properties.Settings.Default.WorkerName;
                object obj=add.Create();

                if (iTypeFrom != -1)
                {
                    switch (iTypeFrom)
                    {
                        case 1: //委辦
                            Public.CPatComitEventToFee comitFee = new Public.CPatComitEventToFee();
                            comitFee.FeeKey = add.FeeKey;
                            comitFee.PatComitEventID = iSourceID;
                            comitFee.Create();
                            break;

                        case 2://來函
                            Public.CPatNotifyEventToFee NotifyFee = new Public.CPatNotifyEventToFee("1=0");
                            NotifyFee.FeeKEY = add.FeeKey;
                            NotifyFee.PatNotifyEventID = iSourceID;
                            NotifyFee.Insert();
                            break;
                    }
                }

                Public.PublicForm Forms = new Public.PublicForm();
                if (Forms.PatListMF != null)
                {
                    DataRow dr = Forms.PatListMF.DT_PatentFeeT.NewRow();
                    DataRow drV = Public.CPatentPublicFunction.GetPatentFeeTDataRow(add.FeeKey.ToString());
                    dr.ItemArray = drV.ItemArray;
                    Forms.PatListMF.DT_PatentFeeT.Rows.Add(dr);                    
                   
                }
                MessageBox.Show("新增成功  "+add.FeeSubject, "提示訊息", MessageBoxButtons.OK);
                this.Close();
            }
            else
            {
                comboBox_FeeSubject.Focus();
                MessageBox.Show("請輸入費用內容", "提示訊息", MessageBoxButtons.OK);
            }
        }
        #endregion

        #region ==============AddPatentFee_Load==================
        private void AddPatentFee_Load(object sender, EventArgs e)
        {


            this.payKindTableAdapter.Fill(this.dataSet_Drop.PayKind);
            this.worker_QuitNTableAdapter.Fill(this.qS_DataSet.Worker_QuitN);
            this.moneyTTableAdapter.Fill(this.dataSet_Drop.MoneyT);
            this.feePhaseTByPatTableAdapter.Fill(this.dataSet_Drop.FeePhaseTByPat);
            this.attorneyTTableAdapter.Fill(this.dataSet_Drop.AttorneyT);
           
            if (CountrySymbol!="")
            {
                attorneyTBindingSource.Filter = " CountrySymbol ='" + CountrySymbol + "'";
            }  
   
            cboMoney1_Changed(cboMoney1, null);
            cboMoney1_Changed(cboMoney2, null);
            cboMoney1_Changed(cboMoney4, null);
            cboMoney1_Changed(cboMoney5, null);

            cboFClientTransactor.SelectedValue = Properties.Settings.Default.WorkerKEY;
            mskRDate.Text = DateTime.Now.ToString("yyyy/MM/dd");
            mskCollectionPeriod.Text = DateTime.Now.AddDays(14).ToString("yyyy/MM/dd");
            
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

        #region ===========費用金額計算===========
        private void rateMoney(ComboBox cboMoney, NumericUpDown RateMoney, NumericUpDown AttorneyFee, TextBox txtFeeTotal1)
        {
            try
            {
                decimal dec = RateMoney.Value * AttorneyFee.Value;
                if (txtAttorneyFeeTotal1.Name == "txtAttorneyFeeTotal1")
                {
                    txtFeeTotal1.Text = dec.ToString("#,##0");
                }
                else
                {
                    txtFeeTotal1.Text = dec.ToString("#,##0.##");
                }
             
            }
            catch
            {
                txtFeeTotal1.Text = "0";
            }


        }

        #region txtAttorneyFeeTotal1_TextChanged
        /// <summary>
        /// 計算代收代付合計NT
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtAttorneyFeeTotal1_TextChanged(object sender, EventArgs e)
        {
            decimal dTol = 0;
            decimal din = 0;
            decimal dout = 0; //複代費用
            decimal doutOther = 0;//複代雜費
            decimal de = 0;//官方規費

            //if (txtAttorneyFeeTotal1.Text != "" && Public.Utility.isNumeric(txtAttorneyFeeTotal1.Text, "decimal"))
            //{
            //    din = decimal.Parse(txtAttorneyFeeTotal1.Text);
            //}

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
            dTol = dout + de + doutOther+ din;
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

        #endregion

        #region =========mskRDate_DoubleClick=========
        private void mskRDate_DoubleClick(object sender, EventArgs e)
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
            US.SingCode sing = new US.SingCode();
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
                        // if (txt.Name == "numericUpDown_Money2")
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

        #region numericUpDown_OtherFee_ValueChanged
        /// <summary>
        /// 所內收費-服務費
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void numericUpDown_OtherFee_ValueChanged(object sender, EventArgs e)
        {
           decimal total= numericUpDown_OtherFee.Value + numericUpDown_OtherTotalFeeCustomize1.Value + numericUpDown_OtherTotalFeeCustomize2.Value + numericUpDown_OtherTotalFeeCustomize3.Value;

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

            numericUpDown_TaxPercent_ValueChanged(null,null);
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
            else {
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

        #region AddPatentFee_KeyDown
        private void AddPatentFee_KeyDown(object sender, KeyEventArgs e)
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
                feePhaseItemsTTableAdapter.FillByFeePhase(this.qS_DataSet.FeePhaseItemsT,-1);
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
                        attorneyTBindingSource.Filter = "CountrySymbol ='" + CountrySymbol + "'";
                    }
                    break;
            }
        }


        #endregion

        private void mskRDate_Leave(object sender, EventArgs e)
        {
            MaskedTextBox mak = (MaskedTextBox)sender;
            Public.Utility.CheckMaskedtextbox(mak);
        }

        
    }
}
