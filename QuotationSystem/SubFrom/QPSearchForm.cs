using System;
using System.Data;
using System.Windows.Forms;

namespace LawtechPTSystem.SubFrom
{
    public partial class QPSearchForm : Form
    {
        public QPSearchForm()
        {
            InitializeComponent();
        }

        #region=====自訂變數=====

        BindingSource bSource_TriffT;
        DataSet ds; //包含TriffT.
        Public.CnTriff ct;
        DataTable exchange = new DataTable();
        //int LastSelectAttorney = -1;

        #endregion

        private void QPSearchForm_Load(object sender, EventArgs e)
        {                       
            Public.PublicForm Forms = new Public.PublicForm();
            Forms.QPSearchForm = this;

            //this.moneyTTableAdapter.Fill(this.qS_DataSet.MoneyT);
            
            //this.attorneyTTableAdapter.Fill(this.qS_DataSet.AttorneyT);
           
            this.kindTTableAdapter.Fill(this.qS_DataSet.KindT);
           
           //this.countryTTableAdapter.Fill(this.qS_DataSet.CountryT);

            this.countryT_DropTableAdapter.Fill(this.qS_DataSet.CountryT_Drop);


            initDataBind();

        }

        #region ===========initDataBind================
        private void initDataBind()
        {
            //初始化資料繫結
            this.cbbCountry.DataBindings.Clear();
            this.cbbReleaseKind.DataBindings.Clear();

            this.txtProcedureName.DataBindings.Clear();
            this.txtProcedureName.DataBindings.Add("Text", vnTriffListBindingSource, "ProcedureName", true, DataSourceUpdateMode.OnValidation, "");

            this.txt_Attorney.DataBindings.Clear();
            this.txt_Attorney.DataBindings.Add("Text", vnTriffListBindingSource, "AttorneyFirm", true, DataSourceUpdateMode.OnPropertyChanged);

            this.txtGovFee.DataBindings.Clear();
            this.txtGovFee.DataBindings.Add("Text", vnTriffListBindingSource, "GovFee", true, DataSourceUpdateMode.OnValidation, "", "#,##0.####");

            //官方規費折合NT
            this.txtExchange1.DataBindings.Clear();
            this.txtExchange1.DataBindings.Add("Text", vnTriffListBindingSource, "GovFeeNT", true, DataSourceUpdateMode.OnPropertyChanged, "", "#,##0.####");

            //官方規費--幣別
            this.txt_GovMoneyKind.DataBindings.Clear();
            this.txt_GovMoneyKind.DataBindings.Add("Text", vnTriffListBindingSource, "MoneyKindG", true, DataSourceUpdateMode.OnPropertyChanged);

            this.txtAttorneyFee.DataBindings.Clear();
            this.txtAttorneyFee.DataBindings.Add("Text", vnTriffListBindingSource, "AttorneyFee", true, DataSourceUpdateMode.OnValidation, "", "#,##0.####");

            //國外代理人服務費--幣別
            this.txt_AttorneyMoneyKind.DataBindings.Clear();
            this.txt_AttorneyMoneyKind.DataBindings.Add("Text", vnTriffListBindingSource, "MoneyKind", true, DataSourceUpdateMode.OnPropertyChanged);

            this.cbShowLargeEntity.DataBindings.Clear();
            this.cbShowLargeEntity.DataBindings.Add("Checked", vnTriffListBindingSource, "LargeEntity", true, DataSourceUpdateMode.OnPropertyChanged);

            this.txtAttorneyElseFee.DataBindings.Clear();
            this.txtAttorneyElseFee.DataBindings.Add("Text", vnTriffListBindingSource, "AttorneyElseFee", true, DataSourceUpdateMode.OnValidation, "", "#,##0.####");

            this.txtNotifyFee.DataBindings.Clear();
            this.txtNotifyFee.DataBindings.Add("Text", vnTriffListBindingSource, "NotifyFee", true, DataSourceUpdateMode.OnValidation, "", "#,##0.####");

            this.txtRemark.DataBindings.Clear();
            this.txtRemark.DataBindings.Add("Text", vnTriffListBindingSource, "Remark", true, DataSourceUpdateMode.OnValidation, "");

            this.txtExamtime.DataBindings.Clear();
            this.txtExamtime.DataBindings.Add("Text", vnTriffListBindingSource, "Examtime", true, DataSourceUpdateMode.OnValidation, "");

            this.txt_Phase.DataBindings.Clear();
            this.txt_Phase.DataBindings.Add("Text", vnTriffListBindingSource, "PhaseName", true, DataSourceUpdateMode.OnPropertyChanged);

            this.cbShowLargeEntity.DataBindings.Clear();
            this.cbShowLargeEntity.DataBindings.Add("Checked", vnTriffListBindingSource, "LargeEntity", true, DataSourceUpdateMode.OnPropertyChanged);

            this.txtSignDocument.DataBindings.Clear();
            this.txtSignDocument.DataBindings.Add("Text", vnTriffListBindingSource, "SignDocument", true, DataSourceUpdateMode.OnValidation, "");

            this.txtTranFee.DataBindings.Clear();
            this.txtTranFee.DataBindings.Add("Text", vnTriffListBindingSource, "TranFee", true, DataSourceUpdateMode.OnValidation, "", "#,##0.####");

            this.txtWriteFee.DataBindings.Clear();
            this.txtWriteFee.DataBindings.Add("Text", vnTriffListBindingSource, "WriteFee", true, DataSourceUpdateMode.OnValidation, "", "#,##0.####");

            this.txtSafeFee.DataBindings.Clear();
            this.txtSafeFee.DataBindings.Add("Text", vnTriffListBindingSource, "SafeFee", true, DataSourceUpdateMode.OnValidation, "", "#,##0.####");

            this.txtMeFee.DataBindings.Clear();
            this.txtMeFee.DataBindings.Add("Text", vnTriffListBindingSource, "MeFee", true, DataSourceUpdateMode.OnValidation, "", "#,##0.####");

            //實際總計NT
            this.txtTotall.DataBindings.Clear();
            this.txtTotall.DataBindings.Add("Text", vnTriffListBindingSource, "Totall", true, DataSourceUpdateMode.OnPropertyChanged, "", "#,##0.####");

            //報價總計NT
            this.txtQTotal.DataBindings.Clear();
            this.txtQTotal.DataBindings.Add("Text", vnTriffListBindingSource, "QuotaTotal", true, DataSourceUpdateMode.OnPropertyChanged, "", "#,##0.####");

            //差額NT
            this.txtGain.DataBindings.Clear();
            this.txtGain.DataBindings.Add("Text", vnTriffListBindingSource, "Gain", true, DataSourceUpdateMode.OnPropertyChanged, "", "#,##0.####");

            //之前報價NT
            this.txtBeforeTotal.DataBindings.Clear();
            this.txtBeforeTotal.DataBindings.Add("Text", vnTriffListBindingSource, "BeforeTotal", true, DataSourceUpdateMode.OnPropertyChanged, "", "#,##0.####");

            this.txtMeRemark.DataBindings.Clear();
            this.txtMeRemark.DataBindings.Add("Text", vnTriffListBindingSource, "MeRemark", true, DataSourceUpdateMode.OnValidation);

            //國外代理人服務費折合NT
            this.txtExchange2.DataBindings.Clear();
            this.txtExchange2.DataBindings.Add("Text", vnTriffListBindingSource, "AttorneyELFeeNT", true, DataSourceUpdateMode.OnPropertyChanged, "", "#,##0.####");

            //預估國外代理人雜費折合NT
            this.txtExchange3.DataBindings.Clear();
            this.txtExchange3.DataBindings.Add("Text", vnTriffListBindingSource, "AttorneyElseFeeNT", true, DataSourceUpdateMode.OnPropertyChanged, "", "#,##0.####");

            //預估轉遞審定書費用折合NT
            this.txtExchange4.DataBindings.Clear();
            this.txtExchange4.DataBindings.Add("Text", vnTriffListBindingSource, "NotifyFeeNT", true, DataSourceUpdateMode.OnPropertyChanged, "", "#,##0.####");

            //ds.Tables["nTriffT"].RowChanged -= new DataRowChangeEventHandler(QPForm_RowChanged);
            //ds.Tables["nTriffT"].RowChanged += new DataRowChangeEventHandler(QPForm_RowChanged);
            //ds.Tables["nTriffT"].ColumnChanged -= new DataColumnChangeEventHandler(QPForm_ColumnChanged);
            //ds.Tables["nTriffT"].ColumnChanged += new DataColumnChangeEventHandler(nTriffT_ColumnChanged);
            //ds.Tables["nTriffT"].RowDeleting += new DataRowChangeEventHandler(nTriffT_RowDeleting);
        }

        #endregion

        #region private void QPSearchForm_FormClosed(object sender, FormClosedEventArgs e)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void QPSearchForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Public.PublicForm Forms = new Public.PublicForm();
            Forms.QPSearchForm = null;
        } 
        #endregion

        private void cbbCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbCountry.SelectedValue != null)
            {
                LoadData();
            }
        }

        private void but_Search_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        #region ============LoadData===============
        /// <summary>
        /// 繫結資料，依國別、種類
        /// </summary>
        public void LoadData()
        {
            ////資料讀取
            ////string filter = string.Format("Country = '{0}' and Kind = '{1}' and LargeEntity = {2}", this.cbbCountry.SelectedValue.ToString(), this.cbbReleaseKind.SelectedValue.ToString(), this.cbLargeEntity.Checked ? "1" : "0");
            ////SqlConnection conn = new SqlConnection(Properties.Settings.Default.Setting);
            ////SqlDataAdapter da = new SqlDataAdapter("Select * From nTriffT Where " + filter, conn);
            ////ds = new DataSet();
            ////da.Fill(ds, "nTriffT");
            ////            string SQLCommand = @"Select t1.*, (
            ////                                  From nTriffT as t1,
            ////                                  (SELECT t1.ToNT AS g_ToNT FROM MoneyT AS t1 RIGHT OUTER JOIN nTriffT AS t2 ON t1.Money = t2.MoneyKindG) as ex1,
            ////                                  (SELECT t1.ToNT AS a_ToNT FROM MoneyT AS t1 RIGHT OUTER JOIN nTriffT AS t2 ON t1.Money = t2.MoneyKind) as ex2";
            ////string SQLCommand = @"Select *, From nTriffT Where Country = '{0}' and Kind = '{1}' and LargeEntity = {2}"; 
            //ct = new Public.CnTriff(string.Format("Country = '{0}' and Kind = '{1}' and LargeEntity = {2} Order by Sort", this.cbbCountry.SelectedValue.ToString(), this.cbbReleaseKind.SelectedValue.ToString(), this.cbLargeEntity.Checked ? "1" : "0"));
            //if (ds == null)
            //{
            //    ds = new DataSet();
            //}

            //if (ds.Tables.Contains("nTriffT"))
            //{
            //    ds.Tables["nTriffT"].Clear();
            //    ds.Tables["nTriffT"].Merge(ct.GetDataTable());
            //}
            //else
            //{
            //    ds.Tables.Add(ct.GetDataTable());
            //}

            //if (bSource_TriffT == null) bSource_TriffT = new BindingSource();
            //bSource_TriffT.DataSource = ds.Tables["nTriffT"];
            //dataGridView1.DataSource = bSource_TriffT;
            //bindingNavigator1.BindingSource = bSource_TriffT;

            //資料讀取
            v_nTriffListTableAdapter.Fill(this.dataSet_Triff.V_nTriffList, this.cbbCountry.SelectedValue.ToString(), this.cbbReleaseKind.SelectedValue.ToString(), this.cbLargeEntity.Checked ? true : false);

        }
        #endregion

        #region ==============CountAttorneyFeeNT=================
        /// <summary>
        /// 計算代理人費用
        /// </summary>
        private void CountAttorneyFeeNT()
        {
            try
            {
                //if (bSource_TriffT.Position >= 0)
                //{
                decimal ex = 0;
                DataRow[] drm = exchange.Select(string.Format("Money='{0}'", txt_AttorneyMoneyKind.Text));
                if (drm != null && drm.Length > 0)
                {
                    ex = (decimal)drm[0]["ToNT"];
                }

                DataRow dr = ds.Tables["nTriffT"].Rows[bSource_TriffT.Position];
                decimal attorneyfee = isNumeric(txtAttorneyFee.Text) ? decimal.Parse(txtAttorneyFee.Text) : 0;
                decimal attorneyelsefee = isNumeric(txtAttorneyElseFee.Text) ? decimal.Parse(txtAttorneyElseFee.Text) : 0;
                decimal notifyfee = isNumeric(txtNotifyFee.Text) ? decimal.Parse(txtNotifyFee.Text) : 0;
                //decimal gain = isNumeric(dr["Gain"].ToString()) ? (decimal)dr["Gain"] : 0;
                decimal tranfee = isNumeric(txtTranFee.Text) ? decimal.Parse(txtTranFee.Text) : 0;
                decimal writefee = isNumeric(txtWriteFee.Text) ? decimal.Parse(txtWriteFee.Text) : 0;
                decimal safefee = isNumeric(txtSafeFee.Text) ? decimal.Parse(txtSafeFee.Text) : 0;
                decimal attorneyfeent = ((attorneyfee + attorneyelsefee + notifyfee) * ex) + tranfee + writefee + safefee;
                dataGridView1.Rows[bSource_TriffT.Position].Cells["AttorneyFeeNT"].Value = (object)attorneyfeent;
                //ds.Tables["nTriffT"].Rows[bSource_TriffT.Position]["AttorneyFeeNT"] = attorneyfeent;
                //}
            }
            catch (System.Exception EX)
            {
               Public.Utility.WriteLog(string.Format("發生錯誤於:{0} 錯誤訊息:{1}", this.Name, EX.Message));
            }
        }
        #endregion

        #region =========Total==========
        /// <summary>
        /// 分別計算實際總計,差額及報價總計
        /// </summary>
        private void Total()
        {
            if (bSource_TriffT.Position >= 0)
            {
                int p = bSource_TriffT.Position;
                DataRow dr = ds.Tables["nTriffT"].Rows[p];
                if (dr != null)
                {

                    decimal exchange1 = isNumeric(txtExchange1.Text) ? decimal.Parse(txtExchange1.Text) : 0;
                    decimal exchange2 = isNumeric(txtExchange2.Text) ? decimal.Parse(txtExchange2.Text) : 0;
                    decimal exchange3 = isNumeric(txtExchange3.Text) ? decimal.Parse(txtExchange3.Text) : 0;
                    decimal exchange4 = isNumeric(txtExchange4.Text) ? decimal.Parse(txtExchange4.Text) : 0;
                    decimal tranfee = isNumeric(txtTranFee.Text) ? decimal.Parse(txtTranFee.Text) : 0;
                    decimal writefee = isNumeric(txtWriteFee.Text) ? decimal.Parse(txtWriteFee.Text) : 0;
                    decimal safefee = isNumeric(txtSafeFee.Text) ? decimal.Parse(txtSafeFee.Text) : 0;
                    decimal mefee = isNumeric(txtMeFee.Text) ? decimal.Parse(txtMeFee.Text) : 0;
                    decimal total = exchange1 + exchange2 + exchange3 + exchange4 + tranfee + writefee + safefee + mefee;
                    decimal quotationtotal = QuotaTotal(total);
                    decimal beforetotal = isNumeric(txtQTotal.Text) ? decimal.Parse(txtQTotal.Text) : 0;//isNumeric(txtBeforeTotal.Text) ? decimal.Parse(txtBeforeTotal.Text) : 0;
                    //if (quotationtotal != beforetotal) beforetotal = quotationtotal;
                    //quotationtotal = QuotaTotal(total);
                    decimal gain = quotationtotal - total;

                    txtTotall.Text = string.Format("{0:N}", total);
                    txtGain.Text = string.Format("{0:N}", gain);
                    txtQTotal.Text = string.Format("{0:N}", quotationtotal);
                    txtBeforeTotal.Text = string.Format("{0:N}", beforetotal);
                    //ds.AcceptChanges();
                }
            }
        }
        #endregion

        #region ===========QuotaTotal============
        /// <summary>
        /// 計算報價總計差額
        /// </summary>
        /// <param name="Money"></param>
        /// <returns></returns>
        private decimal QuotaTotal(decimal Money)
        {
            decimal qt = 0;
            if (Money <= 100) //不用整數
            {
                qt = Money;
            }
            else if (Money > 100 && Money <= 1000) //整數一位ex: 111=> 120
            {
                int m = 0;//換算成銅鈑,用個數計算
                int i = (int)Money % 10; //求餘數
                if (i > 0)
                    m = ((int)Money / 10) + 1;
                else
                    m = (int)Money / 10;

                qt = (decimal)m * 10;
            }
            else if (Money > 1000) //整數2位ex: 1111 => 1200
            {
                int m = 0;//換算成百鈔,用張數計算
                int i = (int)Money % 100; //求餘數
                if (i > 0)
                    m = ((int)Money / 100) + 1;
                else
                    m = (int)Money / 100;

                qt = (decimal)m * 100;
            }
            return qt;
        }
        #endregion

        #region ===========isNumeric===========
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
                decimal dec=0;
                IsSuccess = decimal.TryParse(Number, out dec);
            }
            catch 
            {
              
            }
            return IsSuccess;
        }
        #endregion

        #region ===============Exchange===================
        /// <summary>
        /// 匯率計算
        /// </summary>
        /// <param name="sourceTB">金額來源</param>
        /// <param name="destTB">金額目錄</param>
        /// <param name="exchangeDT">滙率表</param>
        /// <param name="Money">滙換種類</param>
        private void Exchange(TextBox sourceTB, TextBox destTB, DataTable exchangeDT, string Money)
        {
            if (isNumeric(sourceTB.Text))
            {
                DataRow[] dr = exchangeDT.Select(string.Format("Money='{0}'", Money));
                if (dr != null && dr.Length > 0)
                {
                    decimal exchange = (decimal)dr[0]["ToNT"];
                    decimal cash = decimal.Parse(sourceTB.Text);
                    if (exchange >= Decimal.Zero)
                    {
                        destTB.Text = string.Format("{0:N}", exchange * cash);
                    }
                }
            }
        }
        #endregion

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                //txt_GovMoneyKind.Text = dataGridView1.CurrentRow.Cells["MoneyKindG"].FormattedValue.ToString();

                //txt_AttorneyMoneyKind.Text = dataGridView1.CurrentRow.Cells["MoneyKind"].FormattedValue.ToString();

                //txt_Phase.Text = dataGridView1.CurrentRow.Cells["Phase"].FormattedValue.ToString();

                //txt_Attorney.Text = dataGridView1.CurrentRow.Cells["Attorney"].FormattedValue.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = false;
        }

        private void linkLabel_SignDocument_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            LinkLabel link = (LinkLabel)sender;
            US.PopMemo pop;
            switch (link.Name)
            {
                case "linkLabel_SignDocument":
                    pop = new LawtechPTSystem.US.PopMemo(txtSignDocument, true, link.Text);
                    break;
                case "linkLabel_Remark":
                    pop = new LawtechPTSystem.US.PopMemo(txtRemark, true, link.Text);
                    break;
                case "linkLabel_MeRemark":
                    pop = new LawtechPTSystem.US.PopMemo(txtMeRemark, true, link.Text);
                    break;
                default:
                    pop = new LawtechPTSystem.US.PopMemo(txtSignDocument, true, link.Text);
                    break;
            }

            pop.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

       
    }
}