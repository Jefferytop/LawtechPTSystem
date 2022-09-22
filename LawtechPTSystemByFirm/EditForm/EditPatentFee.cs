using System;
using System.Data;
using System.Windows.Forms;

namespace LawtechPTSystemByFirm.EditForm
{
    public partial class EditPatentFee : Form
    {
        public EditPatentFee()
        {
            InitializeComponent();
        }

        private int iFeeKey = -1;
        /// <summary>
        /// 請款費用資料表 ID
        /// </summary>
        public int property_FeeKEY
        {
            get { return iFeeKey; }
            set { iFeeKey = value; }
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


        private string sCountrySymbol = "";
        /// <summary>
        /// 國別
        /// </summary>
        public string CountrySymbol
        {
            get { return sCountrySymbol; }
            set { sCountrySymbol = value; }
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


        #region ===========EditPatentFee_Load================
        /// <summary>
        /// 表單載入事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditPatentFee_Load(object sender, EventArgs e)
        {
            this.payKindTableAdapter.Fill(this.dataSet_Drop.PayKind);
            
            this.moneyTTableAdapter.Fill(this.dataSet_Drop.MoneyT);
            this.feePhaseTByPatTableAdapter.Fill(this.dataSet_Drop.FeePhaseTByPat);
            this.workerTAllTableAdapter.Fill(this.qS_DataSet.WorkerTAll);

            this.attorneyTTableAdapter.Fill(this.dataSet_Drop.AttorneyT);

            Public.CPatentFee Edit = new LawtechPTSystemByFirm.Public.CPatentFee();
            Public.CPatentFee.ReadOne(iFeeKey, ref Edit);
           

            txt_FeeSubject.Text = Edit.FeeSubject;
            comboBox_FeePhase.SelectedValue = Edit.FeePhase;

            numericUpDown_Totall.Value =Edit.Totall.HasValue? Edit.Totall.Value:0;
            numericUpDown_AttorneyFee2.Value = Edit.OAttorneyFee.HasValue ? Edit.OAttorneyFee.Value : 0;
            numericUpDown_AttorneyFee3.Value = Edit.OthFee.HasValue ? Edit.OthFee.Value : 0;
            numericUpDown_AttorneyFee4.Value = Edit.GovFee.HasValue ? Edit.GovFee.Value : 0;

            if (!string.IsNullOrEmpty(Edit.TMoney))
            {
                cboMoney1.SelectedValue = Edit.TMoney;
            }

            if (!string.IsNullOrEmpty(Edit.OMoney))
            {
                cboMoney2.SelectedValue = Edit.OMoney;
            }

            if (!string.IsNullOrEmpty(Edit.GMoney))
            {
                cboMoney4.SelectedValue = Edit.GMoney;
            }

          
            numericUpDown_Money1.Value = Edit.TtoNT.HasValue? Edit.TtoNT.Value:0;
            numericUpDown_Money2.Value =Edit.OtoNT.HasValue?  Edit.OtoNT.Value:0;
            numericUpDown_Money3.Value = Edit.OtoNT.HasValue? Edit.OtoNT.Value:0;
            numericUpDown_Money4.Value = Edit.GtoNT.HasValue ? Edit.GtoNT.Value : 0;

            txtAttorneyFeeTotal1.Text =Edit.TotalNT.HasValue ? Edit.TotalNT.Value.ToString("#,##0.##") : "0";
            txtAttorneyFeeTotal2.Text =Edit.OTotall.HasValue ? Edit.OTotall.Value.ToString("#,##0.##"): "0";
            txtAttorneyFeeTotal3.Text =Edit.OthTotal.HasValue ? Edit.OthTotal.Value.ToString("#,##0.##"): "0";
            txtAttorneyFeeTotal4.Text = Edit.GTotall.HasValue ? Edit.GTotall.Value.ToString("#,##0.##") : "0";

            //雜費
            numericUpDown_OtherFee.Text =Edit.OtherTotalFee.HasValue? Edit.OtherTotalFee.Value.ToString("#,##0.##"):"0";

            if (Edit.Attorney.HasValue)
            {
                comboBox_Attorney.SelectedValue = Edit.Attorney;
            }

            mskRDate.Text = Edit.RDate.HasValue ? Edit.RDate.Value.ToString("yyyy/MM/dd") : "";


            cboFClientTransactor.SelectedValue =Edit.FClientTransactor.HasValue? Edit.FClientTransactor:0;
           
            txtOAttorneyGovFee.Text = Edit.OAttorneyGovFee.HasValue? Edit.OAttorneyGovFee.Value.ToString("#,##0.##"):"0";

            //主管簽核
            txt_SingcCode.Text = Edit.SingCode;

            txt_SingCodeStatus.Text = Edit.SingCodeStatus;

            txt_PayMemo.Text = Edit.PayMemo;

            //numericUpDown_Days.Value = Edit.Days;

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
        #endregion 

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

        #region ==========but_OK_Click==========
        private void but_OK_Click(object sender, EventArgs e)
        {
            if (txt_FeeSubject.Text.Trim() != "")
            {
                Public.CPatentFee Edit = new LawtechPTSystemByFirm.Public.CPatentFee();
                Public.CPatentFee.ReadOne(iFeeKey, ref Edit);


                Edit.SingCode = txt_SingcCode.Text;
                Edit.FeeSubject = txt_FeeSubject.Text;
                Edit.FeePhase = comboBox_FeePhase.SelectedValue != null ? (int)comboBox_FeePhase.SelectedValue : -1;
                Edit.SingCodeStatus += txt_SingCodeStatus.Text + txt_SingCodeStatus_N.Text;

                if (comboBox_Attorney.SelectedValue != null)
                {
                    Edit.Attorney = (int)comboBox_Attorney.SelectedValue;
                }
                else
                {
                    Edit.Attorney = null;
                }

                //請款合計
                Edit.Totall = numericUpDown_Totall.Value;

                //請款合計 幣別
                if (cboMoney1.SelectedValue != null)
                {
                    Edit.TMoney = cboMoney1.SelectedValue.ToString();
                }
                else
                {
                    Edit.TMoney = "";
                }

                //請款合計 匯率               
                Edit.TtoNT = numericUpDown_Money1.Value;

                //請款合計 兌換成NT
                if (txtAttorneyFeeTotal1.Text != "")
                {
                    Edit.TotalNT = decimal.Parse(txtAttorneyFeeTotal1.Text);
                }

                //複代費用
                Edit.OAttorneyFee = numericUpDown_AttorneyFee2.Value;

                if (cboMoney2.SelectedValue != null)
                {
                    Edit.OMoney = cboMoney2.SelectedValue.ToString();
                }
                else
                {
                    Edit.OMoney = "";
                }

                //複代幣別匯率
                Edit.OtoNT = numericUpDown_Money2.Value;

                //複代服務費合計
                if (txtAttorneyFeeTotal2.Text != "")
                {
                    Edit.OTotall = decimal.Parse(txtAttorneyFeeTotal2.Text);
                }

                //複代雜費
                Edit.OthFee = numericUpDown_AttorneyFee3.Value;

                //複代雜費合計NT
                if (txtAttorneyFeeTotal3.Text != "")
                {
                    Edit.OthTotal = decimal.Parse(txtAttorneyFeeTotal3.Text);
                }

                //官方
                Edit.GovFee = numericUpDown_AttorneyFee4.Value;

                if (cboMoney4.SelectedValue != null)
                {
                    Edit.GMoney = cboMoney4.SelectedValue.ToString();
                }
                else
                {
                    Edit.GMoney = "";                
                }
                Edit.GtoNT = numericUpDown_Money4.Value;
                if (txtAttorneyFeeTotal4.Text != "")
                {
                    Edit.GTotall = decimal.Parse(txtAttorneyFeeTotal4.Text);
                }

                //雜費
                Edit.OtherTotalFee = numericUpDown_OtherFee.Value;

                Edit.FeePhase = comboBox_FeePhase.SelectedValue != null ? (int)comboBox_FeePhase.SelectedValue : -1;



                DateTime dt_RDate;
                bool IsRDate = DateTime.TryParse(mskRDate.Text, out dt_RDate);
                if (IsRDate) Edit.RDate = dt_RDate;
                else Edit.RDate = null;


                if (cboFClientTransactor.SelectedValue != null)
                { Edit.FClientTransactor = (int)cboFClientTransactor.SelectedValue; }


                if (txtOAttorneyGovFee.Text != "")
                {
                    Edit.OAttorneyGovFee = decimal.Parse(txtOAttorneyGovFee.Text); 
                }

                Edit.PayMemo = txt_PayMemo.Text;

                Edit.LastModifyDateTime = DateTime.Now;
                Edit.LastModifyWorker = Properties.Settings.Default.WorkerName;

                Edit.Update();

                Public.PublicForm Forms = new LawtechPTSystemByFirm.Public.PublicForm();

                #region Forms.PatListMF
                if (Forms.PatListMF != null && Forms.PatListMF.DT_PatentFeeT != null)
                {
                    DataRow dr = Forms.PatListMF.DT_PatentFeeT.Rows.Find(Edit.FeeKey);
                    if(dr!=null)
                    {
                      
                        DataRow drV = Public.CPatentPublicFunction.GetPatentFeeTDataRow(property_FeeKEY.ToString());
                        dr.ItemArray = drV.ItemArray;
                        dr.AcceptChanges();                     
                    }
                }
                #endregion

                #region Forms.PATControlFeeList
                if (Forms.PATControlFeeList != null && Forms.PATControlFeeList.DT_ControlFee != null)
                {
                    DataRow dr = Forms.PATControlFeeList.dt_CurrentControlFeeDataRow;
                    if (dr != null)
                    {
                        string ss = "";
                        DataRow drV = Public.CPatentPublicFunction.GetPATControlFee(property_FeeKEY.ToString());

                        for (int iItem = 0; iItem < drV.ItemArray.Length; iItem++)
                        {
                            try
                            {
                                dr.ItemArray[iItem] = drV.ItemArray[iItem];
                            }
                            catch (System.Data.ReadOnlyException)
                            {
                                ss = dr.ItemArray[iItem].ToString();
                            }
                            catch
                            {
                                ss = dr.ItemArray[iItem].ToString();
                            }
                        }
                        dr.AcceptChanges();
                    }                   
                }
                #endregion

                #region Forms.AccountingFeeMF
                //if (Forms.AccountingFeeMF != null && Forms.AccountingFeeMF.GetAccountingData != null)
                //{
                   
                //    DataRow dr = Forms.AccountingFeeMF.GetAccountingDataRow;
                //    if (dr != null)
                //    {
                //        dr["FeeSubject"] = Edit.FeeSubject;
                //        dr["SingCode"] = Edit.SingCode;//主管簽核
                //        dr["OtherTotalFee"] = Edit.OtherTotalFee;//雜費
                //        dr["OAttorneyGovFee"] = Edit.OAttorneyGovFee;
                //        dr["Totall"] = Edit.Totall;
                //    }
                //}
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
       
        #region ===========mskRDate_DoubleClick===========
        private void mskRDate_DoubleClick(object sender, EventArgs e)
        {
            MaskedTextBox mtb = (MaskedTextBox)sender;
            DateTime dt=new DateTime();
            bool IsSuccess = DateTime.TryParse(mtb.Text, out dt);
            if (!IsSuccess)
            {
                mtb.Text = DateTime.Now.ToString("yyyy/MM/dd");
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

        #endregion

        #region ============but_SingOff_Click===============
        private void but_SingOff_Click(object sender, EventArgs e)
        {
            US.SingCode sing = new LawtechPTSystemByFirm.US.SingCode();
            sing.ShowDialog();
            if (sing.IsSuccess)
            {
                txt_SingcCode.Text = SingOffName(strWorkerName);
                //txt_SingCodeStatus.Text = "";
                if (but_SingOff.Tag.ToString() == "Sing")
                {
                    but_SingOff.Tag = "Cancel";
                    but_SingOff.Text = "取消簽核";
                    txt_SingCodeStatus_N.Text = "★" + WorkerName + DateTime.Now.ToString("yyyy-MM-dd HH:mm") + "簽核\r\n";
                }
                else
                {
                    but_SingOff.Text = "簽核";
                    but_SingOff.Tag = "Sing";
                    txt_SingCodeStatus_N.Text = "Ⅹ" + WorkerName + DateTime.Now.ToString("yyyy-MM-dd HH:mm") + "取消簽核\r\n";
                }
            }

        }
        #endregion
        
        #region numericUpDown_OtherFee_ValueChanged
        private void numericUpDown_OtherFee_ValueChanged(object sender, EventArgs e)
        {
          
        }
        #endregion

        private void EditPatentFee_KeyDown(object sender, KeyEventArgs e)
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

        private void EditPatentFee_FormClosed(object sender, FormClosedEventArgs e)
        {
            Public.Utility.NuLockRecordAuth("PatentFeeT", "FeeKEY=" + property_FeeKEY.ToString());
        }

        


    }
}
