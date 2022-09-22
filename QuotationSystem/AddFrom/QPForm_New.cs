using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace LawtechPTSystem.AddFrom
{
    public partial class QPForm_New : Form
    {
        #region ========自定變數========
        Public.CnTriff ct;
        //Public.DataClass dc;
        List<Public.CMoney> exchange = new List<Public.CMoney>();

        private DataTable resultdatatable;
        public DataTable ResultDataTable
        {
            get { return resultdatatable; }
        }
        private string country = string.Empty;
        /// <summary>
        /// 取得或設定國別。
        /// </summary>
        public string Country
        {
            get { return country; }
            set { country = value; }
        }

        private string releasekind = string.Empty;
        /// <summary>
        /// 取得或設定報價類別。
        /// </summary>
        public string ReleaseKind
        {
            get { return releasekind; }
            set { releasekind = value; }
        }

        private bool largeentity = false;
        /// <summary>
        /// 取得或設定是否為大實體。
        /// </summary>
        public bool LargeEntity
        {
            get { return largeentity; }
            set { largeentity = value; }
        }

        /// <summary>
        /// 設定或取得上次選擇代理人
        /// </summary>
        private int lastattorneykey = -1;
        public int LastAttorneyKey
        {
            get { return lastattorneykey; }
            set { lastattorneykey = value; }
        }


        #endregion

        
        public QPForm_New()
        {
            InitializeComponent();
        }

        private void QuotationRecord_Load(object sender, EventArgs e)
        {
            
            this.phaseTTableAdapter.Fill(this.qS_DataSet.PhaseT);

            this.attorneyTTableAdapter.FillByCountry(this.qS_DataSet.AttorneyT, Country);
            
            this.moneyTTableAdapter.Fill(this.qS_DataSet.MoneyT);

            List<Public.CMoney> cm_g = new List<Public.CMoney>();
            Public.CMoney.ReadList(ref  cm_g);

            List<Public.CMoney> cm_a = new List<Public.CMoney>();
            Public.CMoney.ReadList(ref  cm_a);  
            
           
            
            cbbGovMoneyKind.DataSource = cm_g;
            cbbGovMoneyKind.DisplayMember = "MoneyName";
            cbbGovMoneyKind.ValueMember = "MoneyKey";
            cbbAttorneyMoneyKind.DataSource = cm_a;
            cbbAttorneyMoneyKind.DisplayMember = "MoneyName";
            cbbAttorneyMoneyKind.ValueMember = "MoneyKey";

            ct = new Public.CnTriff();
            phaseTTableAdapter.Fill(qS_DataSet.PhaseT);
            //resultdatatable = ct.GetDataTable();
            //dc = new Public.DataClass(); //取得所屬階段列表
            //cbbPhase.DataSource = dc.CreatePhase();
            //cbbPhase.DisplayMember = "PhaseName";
            //cbbPhase.ValueMember = "PhaseValue";

            LoadMoney();

            cbbAttorney.SelectedValue = lastattorneykey;
            this.cbShowLargeEntity.Checked = this.largeentity;
            if (cbbPhase.Items.Count > 0) cbbPhase.SelectedIndex = 0;

        }

        #region ============LoadMoney 繫結幣別資料===============
        /// <summary>
        /// 繫結幣別資料
        /// </summary>
        public void LoadMoney()
        {
            //資料讀取
            exchange.Clear();
            Public.CMoney.ReadList(ref  exchange);
        }
        #endregion

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtProcedureName.Text == string.Empty)
            {
                MessageBox.Show("【作業程序】未定義！");
                return;

            }
            else if (cbbPhase.SelectedValue == null)
            {
                MessageBox.Show("【所屬階段】非有效值，請重新選擇！");
                return;
            }
            else
            {
                ct.CountrySymbol = this.country;
                ct.KindSN = this.releasekind;
                ct.LargeEntity = this.largeentity;
                ct.ProcedureName = this.txtProcedureName.Text;
                ct.ProcedureName_CHS = this.txtProcedureName_CHS.Text;
                ct.ProcedureName_EN = this.txtProcedureName_EN.Text;
                ct.AttorneyKey = cbbAttorney.SelectedValue != null ? (int)this.cbbAttorney.SelectedValue : -1;
                ct.Examtime = this.txtExamtime.Text;
                ct.GovFee = this.txtGovFee.Value;
                ct.MoneyKindG = cbbGovMoneyKind.SelectedValue.ToString();
                ct.GovFeeNT = decimal.Parse(this.txtGovFeeNT.Text);
                ct.AttorneyFee =this.txtAttorneyFee.Value;
                ct.MoneyKind = cbbAttorneyMoneyKind.SelectedValue.ToString();
                ct.AttorneyFeeNT = this.txtAttorneyFee.Value;
                ct.AttorneyElseFee = this.txtAttorneyElseFee.Value;               
                ct.NotifyFee = this.txtNotifyFee.Value;
                ct.AttorneyELFeeNT = decimal.Parse(this.txtAttorneyELFeeNT.Text);
                ct.AttorneyElseFeeNT = decimal.Parse(this.txtAttorneyElseFeeNT.Text);
                ct.NotifyFeeNT = decimal.Parse(this.txtNotifyFeeNT.Text);
                if (cbbPhase.SelectedValue != null)
                {
                    ct.PhaseKEY = (int)this.cbbPhase.SelectedValue;
                }
                else
                {
                    ct.PhaseKEY = null;
                }
                ct.SignDocument = this.txtSignDocument.Text;
                ct.TranFee = this.txtTranFee.Value;
                ct.WriteFee = this.txtWriteFee.Value;
                ct.SafeFee = this.txtSafeFee.Value;
                ct.MeFee = this.txtMeFee.Value;
                ct.Totall = decimal.Parse(this.txtTotall.Text);
                ct.QuotaTotal = decimal.Parse(this.txtQTotal.Text);
                ct.Gain = decimal.Parse(this.txtGain.Text);
                ct.BeforeTotal = decimal.Parse(this.txtBeforeTotal.Text);
                ct.Remark = txtRemark.Text;
                ct.Remark_CHS = txtRemark_CHS.Text;
                ct.Remark_EN = txtRemark_EN.Text;
                ct.MeRemark = txtMeRemark.Text;
                ct.MeRemark_CHS = txtMeRemark_CHS.Text;
                ct.MeRemark_EN = txtMeRemark_EN.Text;
                ct.LargeEntity = cbShowLargeEntity.Checked;
                ct.Create();
                
                lastattorneykey = cbbAttorney.SelectedValue != null ? int.Parse(cbbAttorney.SelectedValue.ToString()) : -1;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void txtGovFee_KeyUp(object sender, KeyEventArgs e)
        {
            Exchange(txtGovFee, txtGovFeeNT, exchange, cbbGovMoneyKind.SelectedValue.ToString());
            CountAttorneyFeeNT();
            Total();
        }

        /// <summary>
        /// 檢查是否為數值
        /// </summary>
        /// <param name="Number">數值字串</param>
        /// <returns></returns>
        private bool isNumeric(string Number)
        {
            bool IsSuccess = false;
            try
            {
                decimal dec = 0;
               IsSuccess= decimal.TryParse(Number, out dec);
            }
            catch 
            {
                
            }
            return IsSuccess;
        }

        /// <summary>
        /// 匯率計算
        /// </summary>
        /// <param name="sourceTB">金額來源</param>
        /// <param name="destTB">金額目錄</param>
        /// <param name="exchangeDT">滙率表</param>
        /// <param name="Money">滙換種類</param>
        private void Exchange(NumericUpDown sourceTB, TextBox destTB, List<Public.CMoney> exchangeDT, string Money)
        {
           
                Public.CMoney dr = exchangeDT.Find(x => x.MoneyKey.ToString() == Money);
                if (dr != null && dr.MoneyKey > 0)
                {
                    decimal exchange = dr.ToNT.Value;
                    decimal cash = sourceTB.Value;
                    if (exchange >= Decimal.Zero)
                    {
                        string sRevalue = (exchange * cash).ToString("#,##0.##");
                        if (sRevalue.Trim() != destTB.Text)
                        {  
                            destTB.Text = sRevalue.Trim();
                        }
                    }
                }
            
        }

        //計算代理人費用
        private void CountAttorneyFeeNT()
        {
            decimal ex = 0;
            Public.CMoney drm = exchange.Find(x => x.MoneyKey.ToString() == cbbAttorneyMoneyKind.SelectedValue.ToString());
           
            if (drm != null && drm.MoneyKey > 0)
            {
                ex = drm .ToNT.Value;
            }

            decimal attorneyfee =txtAttorneyFee.Value;
            decimal attorneyelsefee =txtAttorneyElseFee.Value;
            decimal notifyfee = txtNotifyFee.Value;
            //decimal gain = isNumeric(dr["Gain"].ToString()) ? (decimal)dr["Gain"] : 0;
            decimal tranfee =txtTranFee.Value;
            decimal writefee =txtWriteFee.Value;
            decimal safefee = txtSafeFee.Value;
            decimal attorneyfeent = ((attorneyfee + attorneyelsefee + notifyfee) * ex) + tranfee + writefee + safefee;
            //ds.Tables["nTriffT"].Rows[bSource_TriffT.Position]["AttorneyFeeNT"] = attorneyfeent;
        }

        //分別計算實際總計,差額及報價總計
        private void Total()
        {
            decimal exchange1 = isNumeric(txtGovFeeNT.Text) ? decimal.Parse(txtGovFeeNT.Text) : 0;
            decimal exchange2 = isNumeric(txtAttorneyELFeeNT.Text) ? decimal.Parse(txtAttorneyELFeeNT.Text) : 0;
            decimal exchange3 = isNumeric(txtAttorneyElseFeeNT.Text) ? decimal.Parse(txtAttorneyElseFeeNT.Text) : 0;
            decimal exchange4 = isNumeric(txtNotifyFeeNT.Text) ? decimal.Parse(txtNotifyFeeNT.Text) : 0;
            decimal tranfee =txtTranFee.Value;
            decimal writefee = txtWriteFee.Value;
            decimal safefee =txtSafeFee.Value;
            decimal mefee = txtMeFee.Value;
            decimal total = exchange1 + exchange2 + exchange3 + exchange4 + tranfee + writefee + safefee + mefee;
            decimal quotationtotal = QuotaTotal(total);
            decimal gain = quotationtotal - total;
            txtTotall.Text = string.Format("{0:N}", total);
            txtGain.Text = string.Format("{0:N}", gain);
            txtQTotal.Text = string.Format("{0:N}", quotationtotal);
        }

        //計算報價總計差額
        private decimal QuotaTotal(decimal Money)
        {
            
            decimal qt = 0;
            if (Money <= 100) //不用整數
            {
                qt = Money;
            }
            else if (Money > 100 && Money <= 1000) //依50為一單位ex: 123 => 150, 156 => 200
            {
                int m = 0;//換算成銅鈑,用個數計算
                int i = (int)Money % 50; //求餘數
                if (i > 0)
                    m = ((int)Money / 50) + 1;
                else
                    m = (int)Money / 50;

                qt = (decimal)m * 50;
            }
            else if (Money > 1000 && Money <= 10000) //依500為一單位ex: 1234 => 1500, 1666 => 2000
            {
                int m = 0;//換算成500元,用張數計算
                int i = (int)Money % 500; //求餘數
                if (i > 0)
                    m = ((int)Money / 500) + 1;
                else
                    m = (int)Money / 500;

                qt = (decimal)m * 500;
            }
            else if (Money > 10000) //
            {
                int m = 0;//換算成100元,用張數計算 ex: 12345 => 12400
                int i = (int)Money % 100; //求餘數
                if (i > 0)
                    m = ((int)Money / 100) + 1;
                else
                    m = (int)Money / 100;

                qt = (decimal)m * 100;
            }
            return qt;
        }

        private void txtAttorneyFee_KeyUp(object sender, KeyEventArgs e)
        {
            Exchange(txtAttorneyFee, txtAttorneyELFeeNT, exchange, cbbAttorneyMoneyKind.SelectedValue.ToString());
            CountAttorneyFeeNT();
            Total();
        }

        private void txtAttorneyElseFee_KeyUp(object sender, KeyEventArgs e)
        {
            Exchange(txtAttorneyElseFee, txtAttorneyElseFeeNT, exchange, cbbAttorneyMoneyKind.SelectedValue.ToString());
            CountAttorneyFeeNT();
            Total();
        }

       

        private void cbShowLargeEntity_CheckedChanged(object sender, EventArgs e)
        {
            largeentity = cbShowLargeEntity.Checked;
        }

        private void cbbGovMoneyKind_SelectedIndexChanged(object sender, EventArgs e)
        {
            Exchange(txtGovFee, txtGovFeeNT, exchange, cbbGovMoneyKind.SelectedValue.ToString());
            CountAttorneyFeeNT();
            Total();
        }

        private void cbbAttorneyMoneyKind_SelectedIndexChanged(object sender, EventArgs e)
        {
            Exchange(txtAttorneyFee, txtAttorneyELFeeNT, exchange, cbbAttorneyMoneyKind.SelectedValue.ToString());
            Exchange(txtAttorneyElseFee, txtAttorneyElseFeeNT, exchange, cbbAttorneyMoneyKind.SelectedValue.ToString());
            Exchange(txtNotifyFee, txtNotifyFeeNT, exchange, cbbAttorneyMoneyKind.SelectedValue.ToString());
            CountAttorneyFeeNT();
            Total();
        }

        private void txtGovFee_ValueChanged(object sender, EventArgs e)
        {
            NumericUpDown txt = (NumericUpDown)sender;
            switch (txt.Name)
            {
                case "txtGovFee":
                    if (cbbGovMoneyKind.SelectedValue != null)
                    {
                        Exchange(txt, txtGovFeeNT, exchange, cbbGovMoneyKind.SelectedValue.ToString());
                    }
                    break;
                case "txtAttorneyFee":
                    if (cbbAttorneyMoneyKind.SelectedValue != null)
                    {
                        Exchange(txt, txtAttorneyELFeeNT, exchange, cbbAttorneyMoneyKind.SelectedValue.ToString());
                    }

                    break;
                case "txtAttorneyElseFee":
                    if (cbbAttorneyMoneyKind.SelectedValue != null)
                    {
                        Exchange(txt, txtAttorneyElseFeeNT, exchange, cbbAttorneyMoneyKind.SelectedValue.ToString());
                    }

                    break;
                case "txtNotifyFee":
                    if (cbbAttorneyMoneyKind.SelectedValue != null)
                    {
                        Exchange(txt, txtNotifyFeeNT, exchange, cbbAttorneyMoneyKind.SelectedValue.ToString());
                    }

                    break;
            }
            CountAttorneyFeeNT();
            Total();
        }

        private void txtTranFee_ValueChanged(object sender, EventArgs e)
        {
            CountAttorneyFeeNT();
            Total();
        }

        private void txtMeFee_ValueChanged(object sender, EventArgs e)
        {
            Total();
        }
    }
}