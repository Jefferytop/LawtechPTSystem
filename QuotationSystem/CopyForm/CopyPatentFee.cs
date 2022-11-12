using System;
using System.Data;
using System.Windows.Forms;

namespace LawtechPTSystem.CopyForm
{
    public partial class CopyPatentFee : Form
    {
        public CopyPatentFee()
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


        private int iPatentID = -1;
        /// <summary>
        /// 申請案ID
        /// </summary>
        public int PatentID
        {
            get { return iPatentID; }
            set { iPatentID = value; }
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


        private void CopyPatentFee_Load(object sender, EventArgs e)
        {
            this.payKindTableAdapter.Fill(this.dataSet_Drop.PayKind);

            this.moneyTTableAdapter.Fill(this.dataSet_Drop.MoneyT);
            this.feePhaseTByPatTableAdapter.Fill(this.dataSet_Drop.FeePhaseTByPat);
            this.workerTAllTableAdapter.Fill(this.qS_DataSet.WorkerTAll);

            this.attorneyTTableAdapter.FillByCountry(this.dataSet_Drop.AttorneyT, sCountrySymbol);

            Public.CPatentFee Edit = new Public.CPatentFee();
            Public.CPatentFee.ReadOne(iFeeKEY, ref Edit);
           
            txt_FeeSubject.Text = Edit.FeeSubject;
            comboBox_FeePhase.SelectedValue = Edit.FeePhase;

            numericUpDown_AttorneyFee1.Value = Edit.Totall.HasValue ? Edit.Totall.Value : 0;
            numericUpDown_AttorneyFee2.Value = Edit.OAttorneyFee.HasValue?Edit.OAttorneyFee.Value:0;
            numericUpDown_AttorneyFee3.Value = Edit.OthFee.HasValue ?Edit.OthFee.Value:0;
            numericUpDown_AttorneyFee4.Value =Edit.GovFee.HasValue? Edit.GovFee.Value:0;
            cboMoney1.Text = Edit.TMoney;
            cboMoney2.Text = Edit.OMoney;
            cboMoney4.Text = Edit.GMoney;
            numericUpDown_Money1.Value = Edit.TtoNT.HasValue ? Edit.TtoNT.Value : 0;
            numericUpDown_Money2.Value =Edit.OtoNT.HasValue? Edit.OtoNT.Value:0;
            numericUpDown_Money3.Value = Edit.OtoNT.HasValue?Edit.OtoNT.Value:0;
            numericUpDown_Money4.Value = Edit.GtoNT.Value;
           
            txtAttorneyFeeTotal2.Text = Edit.OTotall.HasValue?Edit.OTotall.Value.ToString("#,##0.##"):"";
            txtAttorneyFeeTotal3.Text =Edit.OthTotal.HasValue? Edit.OthTotal.Value.ToString("#,##0.##"):"";
            txtAttorneyFeeTotal4.Text = Edit.GTotall.HasValue ? Edit.GTotall.Value.ToString("#,##0.##") : "";


            //雜費
            numericUpDown_OtherFee.Value = Edit.OtherTotalFee.HasValue ? Edit.OtherTotalFee.Value : 0;

            //複代
            comboBox_Attorney.SelectedValue = Edit.Attorney;

            mskRDate.Text = Edit.RDate.HasValue? Edit.RDate.Value.ToString("yyyy-MM-dd") : "";


            cboFClientTransactor.SelectedValue =Properties.Settings.Default.WorkerKEY;

            txtAttorneyFeeTotal1.Text = Edit.Totall.HasValue ? Edit.Totall.Value.ToString("#,##0.##") : "";
            txtOAttorneyGovFee.Text = Edit.OAttorneyGovFee.HasValue ? Edit.OAttorneyGovFee.Value.ToString("#,##0.##") : "";

            //主管簽核
            //txt_SingcCode.Text = Edit.SingCode;

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
                Public.CPatentFee add = new Public.CPatentFee();
                add.PatentID = iPatentID;
                add.SingCode = txt_SingcCode.Text;
                add.FeeSubject = txt_FeeSubject.Text;
                add.FeePhase = comboBox_FeePhase.SelectedValue != null ? (int)comboBox_FeePhase.SelectedValue : -1;

                if (comboBox_Attorney.SelectedValue != null)
                {
                    add.Attorney = (int)comboBox_Attorney.SelectedValue;
                }

                //本所費用
                add.IAttorneyFee = numericUpDown_AttorneyFee1.Value;

                //本所幣別
                add.IMoney = cboMoney1.Text;

                //本所幣別匯率               
                add.ItoNT = numericUpDown_Money1.Value;



                //複代費用
                add.OAttorneyFee = numericUpDown_AttorneyFee2.Value;

                add.OMoney = cboMoney2.Text;

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
                add.GMoney = cboMoney4.Text;
                add.GtoNT = numericUpDown_Money4.Value;
                if (txtAttorneyFeeTotal4.Text != "")
                {
                    add.GTotall = decimal.Parse(txtAttorneyFeeTotal4.Text);
                }

                //雜費
                add.OtherTotalFee = numericUpDown_OtherFee.Value;

                DateTime dt_RDate;
                bool IsRDate = DateTime.TryParse(mskRDate.Text, out dt_RDate);
                if (IsRDate) add.RDate = dt_RDate;
                else add.RDate = new DateTime(1900, 1, 1);

                //請款人
                if (cboFClientTransactor.SelectedValue != null)
                {
                    add.FClientTransactor = (int)cboFClientTransactor.SelectedValue;
                }

                //總計
                if (txtAttorneyFeeTotal1.Text != "")
                {
                    add.Totall = decimal.Parse(txtAttorneyFeeTotal1.Text);
                }

                //代收代付合計
                if (txtOAttorneyGovFee.Text != "")
                {
                    add.OAttorneyGovFee = decimal.Parse(txtOAttorneyGovFee.Text);
                }

                //請款合計 兌換成NT
                if (txtAttorneyFeeTotal1.Text != "")
                {
                    add.TotalNT = decimal.Parse(txtAttorneyFeeTotal1.Text);
                }

                add.PayMemo = txt_PayMemo.Text;

                add.FClientTransactor = cboFClientTransactor.SelectedValue != null ? (int)cboFClientTransactor.SelectedValue : -1;
                add.IsClosing = false;
                add.CreateDateTime = DateTime.Now;

                add.Creator = Properties.Settings.Default.WorkerName;
                add.Create();

                if (iTypeFrom != -1)
                {
                    switch (iTypeFrom)
                    {
                        case 1: //事件轉請款
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

        #region ===========mskRDate_DoubleClick===========
        private void mskRDate_DoubleClick(object sender, EventArgs e)
        {
            MaskedTextBox mtb = (MaskedTextBox)sender;
            DateTime dt = new DateTime();
            bool IsSuccess = DateTime.TryParse(mtb.Text, out dt);
            if (!IsSuccess)
            {
                mtb.Text = DateTime.Now.ToString("yyyy-MM-dd");
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
                    case "numericUpDown_AttorneyFee1":
                    case "numericUpDown_Money1":
                        rateMoney(cboMoney1, numericUpDown_Money1, numericUpDown_AttorneyFee1, txtAttorneyFeeTotal1);

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


            //dTol = din + dout + de + doutOther + numericUpDown_OtherFee.Value;
            //txtAttorneyFeeTotal1.Text = dTol.ToString("#,##0.##");


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
                        rateMoney(cmb, numericUpDown_Money1, numericUpDown_AttorneyFee1, txtAttorneyFeeTotal1);
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
            US.SingCode sing = new LawtechPTSystem.US.SingCode();
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

        #region numericUpDown_OtherFee_ValueChanged
        private void numericUpDown_OtherFee_ValueChanged(object sender, EventArgs e)
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

            dTol = din + dout + de + doutOther + numericUpDown_OtherFee.Value;
            txtAttorneyFeeTotal1.Text = dTol.ToString("#,##0.##");
        }
        #endregion

        private void but_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void mskRDate_Leave(object sender, EventArgs e)
        {
            MaskedTextBox mak = (MaskedTextBox)sender;
            Public.Utility.CheckMaskedtextbox(mak);
        }
    }
}
