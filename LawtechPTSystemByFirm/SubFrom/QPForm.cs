using System;
using System.Text;
using System.Data;
using System.Windows.Forms;
using LawtechPTSystemByFirm.Public;
using System.Collections.Generic;
using H3Operator.DBHelper;

namespace LawtechPTSystemByFirm.SubFrom
{
    /// <summary>
    /// 標準牌價維護
    /// </summary>
    public partial class QPForm : Form
    {
        #region=====自訂變數=====      
       
        List<Public.CMoney> exchange = new List<Public.CMoney>();
        int LastSelectAttorney = -1;

        StringBuilder CopyFeeSNList = new StringBuilder();

        UserPermissionForm myPermission;
        private const string ProgramSymbol = "QPForm";
        private const string SourceTableName = "nTriffT";

        #endregion

       private int iWorkerKEY=-1;

        /// <summary>
        /// 登入者的 Key值
        /// </summary>
        public int ProWorkerKEY
        {
            get
            {
                if (iWorkerKEY == -1)
                {
                   iWorkerKEY= Properties.Settings.Default.WorkerKEY;
                }
                return iWorkerKEY;
            }
            
        }

        /// <summary>
        /// 目前標準牌價的Key值
        /// </summary>
        public int ProPKey
        {
            get
            {
                if (dataGridView1.CurrentRow != null)
                {
                    return (int)dataGridView1.CurrentRow.Cells["FeeSN"].Value;
                }
                else
                {
                    return -1;
                }
            }
        }

        public QPForm()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;

            Dictionary<string, BindingSource> lists = new Dictionary<string, BindingSource>() { { "phaseTBindingSource", phaseTBindingSource } };
            Public.DynamicGridViewColumn.GetGridColum(ref dataGridView1, lists);
        }

        #region ===============QPForm_Load、FormClosed====================
        private void QPForm_Load(object sender, EventArgs e)
        {
           
            Public.PublicForm Forms = new PublicForm();
            Forms.QPForm = this;

            //取得權限
            myPermission = new UserPermissionForm(Properties.Settings.Default.WorkerKEY, ProgramSymbol);
          
            //確認可使用的功能選單
            Public.CommonFunctions.CheckMeunItemVisible(contextMenuStrip1, myPermission.UserPermission);
            Public.CommonFunctions.CheckMeunItemVisible(bindingNavigator1, myPermission.UserPermission);


           // this.phaseTTableAdapter.Fill(this.qS_DataSet.PhaseT);
            
            this.phaseTTableAdapter.Fill(this.qS_DataSet1.PhaseT);
          

            this.countryTTableAdapter.Fill(this.qS_DataSet1.CountryT);

            if (cbbCountry.SelectedValue != null)
            {
                this.attorneyTTableAdapter.FillByCountry(this.dataSet_Drop.AttorneyT, cbbCountry.SelectedValue.ToString());
            }
            
            this.moneyTTableAdapter.Fill(this.qS_DataSet1.MoneyT);
            
            this.kindTTableAdapter.Fill(this.qS_DataSet1.KindT);
           
            //資料繫結
            LoadData();

            LoadMoney();

            //初始化資料對應
            initDataBind();

            this.moneyTTableAdapter1.Fill(this.dataSet_Drop.MoneyT);

            this.dataSet_Triff.nTriffT.nTriffTRowChanged += new DataSet_Triff.nTriffTRowChangeEventHandler(nTriffT_RowChanged);
            
        }

        private void QPForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Public.PublicForm Forms = new PublicForm();
            Forms.QPForm = null;
        }

        #endregion 

        #region ============LoadData===============
        /// <summary>
        /// 繫結資料，依國別、種類、大實體
        /// </summary>
        public void LoadData()
        {
            //資料讀取
            nTriffListTableAdapter.Fill(this.dataSet_Triff.nTriffT, this.cbbCountry.SelectedValue.ToString(), this.cbbReleaseKind.SelectedValue.ToString(), this.cbLargeEntity.Checked ? true : false);
           
        }
        #endregion

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

        #region ===========initDataBind================
        private void initDataBind()
        {
            //初始化資料繫結
            this.cbbCountry.DataBindings.Clear();
            this.cbbReleaseKind.DataBindings.Clear();

            this.txtProcedureName.DataBindings.Clear();
            this.txtProcedureName.DataBindings.Add("Text", vnTriffListBindingSource, "ProcedureName", true, DataSourceUpdateMode.OnValidation, "");

            this.txtProcedureName_CHS.DataBindings.Clear();
            this.txtProcedureName_CHS.DataBindings.Add("Text", vnTriffListBindingSource, "ProcedureName_CHS", true, DataSourceUpdateMode.OnValidation, "");

            this.txtProcedureName_EN.DataBindings.Clear();
            this.txtProcedureName_EN.DataBindings.Add("Text", vnTriffListBindingSource, "ProcedureName_EN", true, DataSourceUpdateMode.OnValidation, "");

            this.cbbAttorney.DataBindings.Clear();
            this.cbbAttorney.DataBindings.Add("SelectedValue", vnTriffListBindingSource, "AttorneyKey", true, DataSourceUpdateMode.OnPropertyChanged);

            this.txtGovFee.DataBindings.Clear();
            this.txtGovFee.DataBindings.Add("Text", vnTriffListBindingSource, "GovFee", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");

            //官方規費折合NT
            this.txtGovFeeNT.DataBindings.Clear();
            this.txtGovFeeNT.DataBindings.Add("Text", vnTriffListBindingSource, "GovFeeNT", true, DataSourceUpdateMode.OnPropertyChanged, "", "#,##0.##");

            //官方規費--幣別
            this.cbbGovMoneyKind.DataBindings.Clear();
            this.cbbGovMoneyKind.DataBindings.Add("SelectedValue", vnTriffListBindingSource, "MoneyKindG", true, DataSourceUpdateMode.OnPropertyChanged);

            this.txtAttorneyFee.DataBindings.Clear();
            this.txtAttorneyFee.DataBindings.Add("Text", vnTriffListBindingSource, "AttorneyFee", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");

            //國外代理人服務費--幣別
            this.cbbAttorneyMoneyKind.DataBindings.Clear();
            this.cbbAttorneyMoneyKind.DataBindings.Add("SelectedValue", vnTriffListBindingSource, "MoneyKind", true, DataSourceUpdateMode.OnPropertyChanged);

            this.cbShowLargeEntity.DataBindings.Clear();
            this.cbShowLargeEntity.DataBindings.Add("Checked", vnTriffListBindingSource, "LargeEntity", true, DataSourceUpdateMode.OnPropertyChanged);

            this.txtAttorneyElseFee.DataBindings.Clear();
            this.txtAttorneyElseFee.DataBindings.Add("Text", vnTriffListBindingSource, "AttorneyElseFee", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");

            this.txtNotifyFee.DataBindings.Clear();
            this.txtNotifyFee.DataBindings.Add("Text", vnTriffListBindingSource, "NotifyFee", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");

            this.txtRemark.DataBindings.Clear();
            this.txtRemark.DataBindings.Add("Text", vnTriffListBindingSource, "Remark", true, DataSourceUpdateMode.OnValidation, "");

            this.txtRemark_CHS.DataBindings.Clear();
            this.txtRemark_CHS.DataBindings.Add("Text", vnTriffListBindingSource, "Remark_CHS", true, DataSourceUpdateMode.OnValidation, "");

            this.txtRemark_EN.DataBindings.Clear();
            this.txtRemark_EN.DataBindings.Add("Text", vnTriffListBindingSource, "Remark_EN", true, DataSourceUpdateMode.OnValidation, "");

            this.txtExamtime.DataBindings.Clear();
            this.txtExamtime.DataBindings.Add("Text", vnTriffListBindingSource, "Examtime", true, DataSourceUpdateMode.OnValidation, "");

            this.cbbPhase.DataBindings.Clear();
            this.cbbPhase.DataBindings.Add("SelectedValue", vnTriffListBindingSource, "PhaseKEY", true, DataSourceUpdateMode.OnPropertyChanged);

            this.cbShowLargeEntity.DataBindings.Clear();
            this.cbShowLargeEntity.DataBindings.Add("Checked", vnTriffListBindingSource, "LargeEntity", true, DataSourceUpdateMode.OnPropertyChanged);
            
            this.txtSignDocument.DataBindings.Clear();
            this.txtSignDocument.DataBindings.Add("Text", vnTriffListBindingSource, "SignDocument", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");

            this.txtTranFee.DataBindings.Clear();
            this.txtTranFee.DataBindings.Add("Text", vnTriffListBindingSource, "TranFee", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");

            this.txtWriteFee.DataBindings.Clear();
            this.txtWriteFee.DataBindings.Add("Text", vnTriffListBindingSource, "WriteFee", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");

            this.txtSafeFee.DataBindings.Clear();
            this.txtSafeFee.DataBindings.Add("Text", vnTriffListBindingSource, "SafeFee", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");

            this.txtMeFee.DataBindings.Clear();
            this.txtMeFee.DataBindings.Add("Text", vnTriffListBindingSource, "MeFee", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");

            //實際總計NT
            this.txtTotall.DataBindings.Clear();
            this.txtTotall.DataBindings.Add("Text", vnTriffListBindingSource, "Totall", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");

            //報價總計NT
            this.txtQTotal.DataBindings.Clear();
            this.txtQTotal.DataBindings.Add("Text", vnTriffListBindingSource, "QuotaTotal", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");

            //差額NT
            this.txtGain.DataBindings.Clear();
            this.txtGain.DataBindings.Add("Text", vnTriffListBindingSource, "Gain", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");

            //之前報價NT
            this.txtBeforeTotal.DataBindings.Clear();
            this.txtBeforeTotal.DataBindings.Add("Text", vnTriffListBindingSource, "BeforeTotal", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");

            this.txtMeRemark.DataBindings.Clear();
            this.txtMeRemark.DataBindings.Add("Text", vnTriffListBindingSource, "MeRemark", true, DataSourceUpdateMode.OnValidation);

            this.txtMeRemark_CHS.DataBindings.Clear();
            this.txtMeRemark_CHS.DataBindings.Add("Text", vnTriffListBindingSource, "MeRemark_CHS", true, DataSourceUpdateMode.OnValidation);

            this.txtMeRemark_EN.DataBindings.Clear();
            this.txtMeRemark_EN.DataBindings.Add("Text", vnTriffListBindingSource, "MeRemark_EN", true, DataSourceUpdateMode.OnValidation);

            //國外代理人服務費折合NT
            this.txtAttorneyELFeeNT.DataBindings.Clear();
            this.txtAttorneyELFeeNT.DataBindings.Add("Text", vnTriffListBindingSource, "AttorneyELFeeNT", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");

            //預估國外代理人雜費折合NT
            this.txtAttorneyElseFeeNT.DataBindings.Clear();
            this.txtAttorneyElseFeeNT.DataBindings.Add("Text", vnTriffListBindingSource, "AttorneyElseFeeNT", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");

            //預估轉遞審定書費用折合NT
            this.txtNotifyFeeNT.DataBindings.Clear();
            this.txtNotifyFeeNT.DataBindings.Add("Text", vnTriffListBindingSource, "NotifyFeeNT", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");

            //複代費用NT
            this.txtAttorneyFeeNT.DataBindings.Clear();
            this.txtAttorneyFeeNT.DataBindings.Add("Text", vnTriffListBindingSource, "AttorneyFeeNT", true, DataSourceUpdateMode.OnValidation, "", "#,##0.##");        
        }

        #endregion

        #region private void nTriffT_RowChanged(object sender, DataRowChangeEventArgs e)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void nTriffT_RowChanged(object sender, DataSet_Triff.nTriffTRowChangeEvent e)
        {
            if (e.Row.RowState == DataRowState.Modified)
            {              
                DBAccess dbhelper = new DBAccess();

                DataTable dtChange = this.dataSet_Triff.nTriffT.GetChanges();
                dbhelper.SqlBulkCopyDataAdapterUpdate(dtChange, Properties.Settings.Default.DataBaseConnectionString, "nTriffT");

                this.dataSet_Triff.nTriffT.AcceptChanges();
              
            }
        } 
        #endregion

        #region  =============nTriffT_ColumnChanged事件===============
        private void nTriffT_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {

            if (e.ProposedValue != System.DBNull.Value && e.Row.RowState == DataRowState.Unchanged)
            {

                Public.CnTriff CA_CnTriff = new Public.CnTriff();
                Public.CnTriff.ReadOne(int.Parse(e.Row["FeeSN"].ToString()), ref CA_CnTriff);

                switch (e.Column.ColumnName)
                {

                    case "Sort":
                        CA_CnTriff.Sort = e.ProposedValue != DBNull.Value ? (int)e.ProposedValue : -1;
                        break;
                    case "CountrySymbol":
                        CA_CnTriff.CountrySymbol = e.ProposedValue != null ? e.ProposedValue.ToString() : "";
                        break;
                    case "KindSN":
                        CA_CnTriff.KindSN = e.ProposedValue != null ? e.ProposedValue.ToString() : "";
                        break;
                    case "ProcedureName":
                        CA_CnTriff.ProcedureName = e.ProposedValue != null ? e.ProposedValue.ToString() : "";
                        break;
                    case "PhaseKEY":
                        CA_CnTriff.PhaseKEY = e.ProposedValue != null ? (int)e.ProposedValue : -1;
                        break;
                    case "Examtime":
                        CA_CnTriff.Examtime = e.ProposedValue != null ? e.ProposedValue.ToString() : "";
                        break;
                    case "GovFee"://官方規費
                        CA_CnTriff.GovFee = e.ProposedValue != DBNull.Value ? decimal.Parse(e.ProposedValue.ToString()) : 0;
                        break;
                    case "GovFeeNT"://官方收費折合NT
                        CA_CnTriff.GovFeeNT = e.ProposedValue != DBNull.Value ? decimal.Parse(e.ProposedValue.ToString()) : 0;
                        //IsChange = false;
                        break;
                    case "MoneyKindG":
                        CA_CnTriff.MoneyKindG = e.ProposedValue != null ? e.ProposedValue.ToString() : "";
                        break;
                    case "AttorneyKey":
                        CA_CnTriff.AttorneyKey = e.ProposedValue != DBNull.Value ? (int)e.ProposedValue : -1;
                        break;
                    case "AttorneyFee":
                        CA_CnTriff.AttorneyFee = e.ProposedValue != DBNull.Value ? decimal.Parse(e.ProposedValue.ToString()) : 0;
                        break;
                    case "AttorneyELFeeNT"://國外代理人服務費折合 NT
                        CA_CnTriff.AttorneyELFeeNT = e.ProposedValue != DBNull.Value ? decimal.Parse(e.ProposedValue.ToString()) : 0;
                        //IsChange = false;
                        break;
                    case "AttorneyElseFee":
                        CA_CnTriff.AttorneyElseFee = e.ProposedValue != DBNull.Value ? decimal.Parse(e.ProposedValue.ToString()) : 0;
                        break;
                    case "AttorneyElseFeeNT"://預估國外代理人雜費折合NT
                        CA_CnTriff.AttorneyElseFeeNT = e.ProposedValue != DBNull.Value ? decimal.Parse(e.ProposedValue.ToString()) : 0;
                        //IsChange = false;
                        break;
                    case "NotifyFee":
                        CA_CnTriff.NotifyFee = e.ProposedValue != DBNull.Value ? decimal.Parse(e.ProposedValue.ToString()) : 0;
                        break;
                    case "NotifyFeeNT"://預估轉遞審定書費用折合NT
                        CA_CnTriff.NotifyFeeNT = e.ProposedValue != DBNull.Value ? decimal.Parse(e.ProposedValue.ToString()) : 0;
                        //IsChange = false;
                        break;
                    case "MoneyKind":
                        CA_CnTriff.MoneyKind = e.ProposedValue != null ? e.ProposedValue.ToString() : "";
                        break;
                    case "TranFee":
                        CA_CnTriff.TranFee = e.ProposedValue != DBNull.Value ? decimal.Parse(e.ProposedValue.ToString()) : 0;
                        break;
                    case "WriteFee":
                        CA_CnTriff.WriteFee = e.ProposedValue != DBNull.Value ? decimal.Parse(e.ProposedValue.ToString()) : 0;
                        break;
                    case "SafeFee":
                        CA_CnTriff.SafeFee = e.ProposedValue != DBNull.Value ? decimal.Parse(e.ProposedValue.ToString()) : 0;
                        break;
                    case "AttorneyFeeNT"://國外代理費NT
                        CA_CnTriff.AttorneyFeeNT = e.ProposedValue != DBNull.Value ? decimal.Parse(e.ProposedValue.ToString()) : 0;
                        //IsChange = false;
                        break;
                    case "AttorneyGovFee":
                        CA_CnTriff.AttorneyGovFee = e.ProposedValue != DBNull.Value ? decimal.Parse(e.ProposedValue.ToString()) : 0;
                        break;
                    case "MeFee":
                        CA_CnTriff.MeFee = e.ProposedValue != DBNull.Value ? decimal.Parse(e.ProposedValue.ToString()) : 0;
                        break;
                    case "Totall"://實際總價
                        CA_CnTriff.Totall = e.ProposedValue != DBNull.Value ? decimal.Parse(e.ProposedValue.ToString()) : 0;
                        //IsChange = false;
                        break;
                    case "QuotaTotal"://報價總價
                        CA_CnTriff.QuotaTotal = e.ProposedValue != DBNull.Value ? decimal.Parse(e.ProposedValue.ToString()) : 0;
                        //IsChange = false;
                        break;
                    case "BeforeTotal"://之前報價
                        CA_CnTriff.BeforeTotal = e.ProposedValue != DBNull.Value ? decimal.Parse(e.ProposedValue.ToString()) : 0;
                        //IsChange = false;
                        break;
                    case "Gain"://差額
                        CA_CnTriff.Gain = e.ProposedValue != DBNull.Value ? decimal.Parse(e.ProposedValue.ToString()) : 0;
                        //IsChange = false;
                        break;
                    case "SignDocument":
                        CA_CnTriff.SignDocument = e.ProposedValue != null ? e.ProposedValue.ToString() : "";
                        break;
                    case "ToNT":
                        CA_CnTriff.ToNT = e.ProposedValue != DBNull.Value ? decimal.Parse(e.ProposedValue.ToString()) : 0;
                        break;
                    case "ToNTG":
                        CA_CnTriff.ToNTG = e.ProposedValue != DBNull.Value ? decimal.Parse(e.ProposedValue.ToString()) : 0;
                        break;
                    case "Remark":
                        CA_CnTriff.Remark = e.ProposedValue != null ? e.ProposedValue.ToString() : "";
                        break;
                    case "MeRemark":
                        CA_CnTriff.MeRemark = e.ProposedValue != null ? e.ProposedValue.ToString() : "";
                        break;
                    case "LargeEntity":
                        CA_CnTriff.LargeEntity = e.ProposedValue != DBNull.Value ? (bool)e.ProposedValue : false;
                        break;
                    case "ForStander":
                        CA_CnTriff.ForStander = e.ProposedValue != DBNull.Value ? (bool)e.ProposedValue : false;
                        break;
                    case "NofityContent":
                        CA_CnTriff.NofityContent = e.ProposedValue != null ? e.ProposedValue.ToString() : "";
                        break;
                    case "AfterProcess":
                        CA_CnTriff.AfterProcess = e.ProposedValue != null ? e.ProposedValue.ToString() : "";
                        break;
                }

                CA_CnTriff.Update();
            }

            dataSet_Triff.Tables["nTriffT"].AcceptChanges();
            
        }
        #endregion           

        #region 關閉按鈕 private void btnExit_Click(object sender, EventArgs e)
        /// <summary>
        /// 關閉按鈕
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        } 
        #endregion
               
        private void cbbReleaseKind_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbReleaseKind.SelectedValue != null)
            {
               
                LoadData();
            }
        }

        private void cbbCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbCountry.SelectedValue != null)
            {
                this.attorneyTTableAdapter.FillByCountry(this.dataSet_Drop.AttorneyT, cbbCountry.SelectedValue.ToString());
                LoadData();               
            }
        }

        private void cbLargeEntity_CheckedChanged(object sender, EventArgs e)
        {
            LoadData();
        }

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
        private void Exchange(NumericUpDown sourceTB, TextBox destTB, List<Public.CMoney> exchangeDT, string Money)
        {
           
                Public.CMoney dr = exchangeDT.Find(x => x.MoneyKey.ToString() == Money);
                if (dr !=null && dr.MoneyKey > 0 )
                {
                    decimal exchange = dr.ToNT.Value;
                    decimal cash = sourceTB.Value;
                    if (exchange >= Decimal.Zero)
                    {
                       string sRevalue= ( exchange * cash).ToString("#,##0.##");
                       if (sRevalue.Trim() != destTB.Text)
                       {
                           DataRow drFee = dataSet_Triff.nTriffT.Rows[vnTriffListBindingSource.Position];
                           NumericUpDown txt = (NumericUpDown)sourceTB;
                           switch (txt.Name)
                           {
                               case "txtGovFee":
                                   drFee["GovFeeNT"] = exchange * cash;
                                   break;
                               case "txtAttorneyFee":
                                   drFee["AttorneyELFeeNT"] = exchange * cash;
                                   break;
                               case "txtAttorneyElseFee":
                                   drFee["AttorneyElseFeeNT"] = exchange * cash;
                                   break;
                               case "txtNotifyFee":
                                   drFee["NotifyFeeNT"] = exchange * cash;

                                   break;
                           }
                           destTB.Text = sRevalue.Trim();
                       }
                    }
                }
            
        }
        #endregion


        private void cbbGovMoneyKind_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtGovFee.Text != string.Empty && isNumeric(txtGovFee.Text) && cbbGovMoneyKind.SelectedIndex >= 0)
            {
                Exchange(txtGovFee, txtGovFeeNT, exchange, cbbGovMoneyKind.SelectedValue.ToString());
                if (this.dataSet_Triff.nTriffT != null && vnTriffListBindingSource.Position >= 0)
                {
                    //this.dataSet_Triff.nTriffT.AcceptChanges();
                    Total();
                }
            }
        }

      

        private void cbbAttorneyMoneyKind_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbbAttorneyMoneyKind.Text!=null)
            {
                label26.Text = cbbAttorneyMoneyKind.Text;
                label27.Text = cbbAttorneyMoneyKind.Text;
            }
        }

        #region ==============CountAttorneyFeeNT=================
        /// <summary>
        /// 計算代理人費用
        /// </summary>
        private void CountAttorneyFeeNT()
        {
            try
            {
                if (cbbAttorneyMoneyKind.SelectedValue != null)
                {
                    decimal ex = 0;
                    Public.CMoney drm = exchange.Find(x => x.MoneyKey.ToString() == cbbAttorneyMoneyKind.SelectedValue.ToString());
                    if (drm != null && drm.MoneyKey > 0)
                    {
                        ex = drm.ToNT.Value;
                    }

                    DataRow dr = dataSet_Triff.nTriffT.Rows[vnTriffListBindingSource.Position];
                    decimal attorneyfee = txtAttorneyFee.Value;
                    decimal attorneyelsefee = txtAttorneyElseFee.Value;
                    decimal notifyfee = txtNotifyFee.Value;
                    decimal gain = isNumeric(dr["Gain"].ToString()) ? (decimal)dr["Gain"] : 0;
                    decimal tranfee = txtTranFee.Value;
                    decimal writefee = txtWriteFee.Value;
                    decimal safefee = txtSafeFee.Value;
                    decimal attorneyfeent = ((attorneyfee + attorneyelsefee + notifyfee) * ex) + tranfee + writefee + safefee;
                    //dataGridView1.Rows[vnTriffListBindingSource.Position].Cells["AttorneyFeeNT"].Value = (object)attorneyfeent;
                    dataSet_Triff.nTriffT.Rows[vnTriffListBindingSource.Position]["AttorneyFeeNT"] = attorneyfeent;
                }
            }
            catch (System.Exception EX)
            {
                Utility.WriteLog(string.Format("發生錯誤於:{0} 錯誤訊息:{1}", this.Name, EX.Message));
            }
        }
        #endregion

        
        #region =========Total==========
        /// <summary>
        /// 分別計算實際總計,差額及報價總計
        /// </summary>
        private void Total()
        {
            if (vnTriffListBindingSource.Position >= 0)
            {
                int p = vnTriffListBindingSource.Position;
                DataRow dr = dataSet_Triff.nTriffT.Rows[p];
                if (dr != null)
                {
                    
                    decimal exchange1 = isNumeric(txtGovFeeNT.Text) ? decimal.Parse(txtGovFeeNT.Text) : 0;
                    decimal exchange2 = isNumeric(txtAttorneyELFeeNT.Text) ? decimal.Parse(txtAttorneyELFeeNT.Text) : 0;
                    decimal exchange3 = isNumeric(txtAttorneyElseFeeNT.Text) ? decimal.Parse(txtAttorneyElseFeeNT.Text) : 0;
                    decimal exchange4 = isNumeric(txtNotifyFeeNT.Text) ? decimal.Parse(txtNotifyFeeNT.Text) : 0;
                    decimal tranfee = txtTranFee.Value;
                    decimal writefee =txtWriteFee.Value;
                    decimal safefee = txtSafeFee.Value;
                    decimal mefee = txtMeFee.Value;
                    decimal total = exchange1 + exchange2 + exchange3 + exchange4 + tranfee + writefee + safefee + mefee;
                    decimal quotationtotal = QuotaTotal(total);
                    decimal beforetotal = isNumeric(txtQTotal.Text) ? decimal.Parse(txtQTotal.Text) : 0;
                    
                    decimal gain = quotationtotal - total;

                    txtTotall.Text  = string.Format("{0:N}",total);
                    txtGain.Text = string.Format("{0:N}", gain);
                    txtQTotal.Text = string.Format("{0:N}",quotationtotal);
                    txtBeforeTotal.Text = string.Format("{0:N}", beforetotal);
                   
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
        #endregion
      
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

        private void cbbGovMoneyKind_Leave(object sender, EventArgs e)
        {
            if (txtGovFee.Text != string.Empty && isNumeric(txtGovFee.Text) && cbbGovMoneyKind.SelectedIndex >= 0 && dataGridView1.CurrentRow != null)
            {
                Exchange(txtGovFee, txtGovFeeNT, exchange, cbbGovMoneyKind.SelectedValue.ToString());

                Total();

            }
        }

        private void cbbAttorneyMoneyKind_Leave(object sender, EventArgs e)
        {
            if (txtGovFee.Text != string.Empty && isNumeric(txtGovFee.Text) && cbbGovMoneyKind.SelectedIndex >= 0 && dataGridView1.CurrentRow != null)
            {
                Exchange(txtAttorneyFee, txtAttorneyELFeeNT, exchange, cbbAttorneyMoneyKind.SelectedValue.ToString());
                Exchange(txtAttorneyElseFee, txtAttorneyElseFeeNT, exchange, cbbAttorneyMoneyKind.SelectedValue.ToString());
                Exchange(txtNotifyFee, txtNotifyFeeNT, exchange, cbbAttorneyMoneyKind.SelectedValue.ToString());

                CountAttorneyFeeNT();
                Total();

            }
        }

      

        #region ============貼上按鈕===================
        private void btnPaste_Click(object sender, EventArgs e)
        {
            //if (ds.Tables.Contains("provisional") && ds.Tables["provisional"].Rows.Count > 0)
            //{
            //    for (int iN = 0; iN < ds.Tables["provisional"].Rows.Count; iN++)
            //    {
            //        DataRow dr = ds.Tables["provisional"].Rows[iN];
            //        Public.CnTriff triff = new CnTriff("1=0");
            //        triff.Country = cbbCountry.SelectedValue.ToString();//國別
            //        triff.Kind = cbbReleaseKind.SelectedValue.ToString();//種類
            //        triff.Sort = (int)dr["Sort"];//排序
            //        triff.ProcedureName = dr["ProcedureName"].ToString();//程序
            //        triff.ProcedureName_CHS = dr["ProcedureName_CHS"].ToString();//程序
            //        triff.ProcedureName_EN = dr["ProcedureName_EN"].ToString();//程序
            //        triff.ForStander =(bool) dr["ForStander"];//標準
            //        triff.Phase = (int)dr["Phase"];//所屬階段
            //        triff.GovFeeNT = (decimal)dr["GovFeeNT"];//政府規費
            //        triff.AttorneyFeeNT = (decimal)dr["AttorneyFeeNT"];//國外代理費
            //        triff.MeFee = (decimal)dr["MeFee"];//長曜服務費
            //        triff.QuotaTotal = (decimal)dr["QuotaTotal"];//總計
            //        triff.Attorney =dr["Attorney"].ToString()!=""? (int)dr["Attorney"]:-1;//國外代理人
            //        triff.Examtime = dr["Examtime"].ToString();//審查時間
            //        triff.MoneyKindG =dr["MoneyKindG"].ToString();//官方收費幣別
            //        triff.GovFee = (decimal)dr["GovFee"];//官方收費
            //        triff.GovFeeNT = (decimal)dr["GovFeeNT"];//官方收費折合NT
            //        triff.AttorneyFee = (decimal)dr["AttorneyFee"];//國外代理人服務費
            //        triff.AttorneyELFeeNT = (decimal)dr["AttorneyELFeeNT"];//國外代理人服務費折合NT
            //        triff.MoneyKind = dr["MoneyKind"].ToString();//國外代理人服務費幣別
            //        triff.AttorneyElseFee = (decimal)dr["AttorneyElseFee"];//預估國外代理人雜費
            //        triff.AttorneyElseFeeNT = (decimal)dr["AttorneyElseFeeNT"];//預估國外代理人雜費折合NT
            //        triff.NotifyFeeNT = (decimal)dr["NotifyFeeNT"];//預估轉遞審定書費用折合NT
            //        triff.NotifyFee = (decimal)dr["NotifyFee"];//預估轉遞審定書費用
            //        triff.TranFee = (decimal)dr["TranFee"];//預估非英語審定書翻譯費NT
            //        triff.WriteFee = (decimal)dr["WriteFee"];//預估撰稿費或非英語翻譯費
            //        triff.SafeFee = (decimal)dr["SafeFee"];//安全基金
            //        triff.MeFee = (decimal)dr["MeFee"];//本所服務費
            //        triff.Totall = (decimal)dr["Totall"];//實際總計NT
            //        triff.QuotaTotal = (decimal)dr["QuotaTotal"];//報價總計
            //        triff.Gain = (decimal)dr["Gain"];//差額
            //        triff.BeforeTotal = (decimal)dr["BeforeTotal"];//差額
            //        triff.SignDocument = dr["SignDocument"].ToString();//應備簽署文件
            //        triff.Remark = dr["Remark"].ToString();//客戶備註
            //        triff.Remark_CHS = dr["Remark_CHS"].ToString();//客戶備註
            //        triff.Remark_EN = dr["Remark_EN"].ToString();//客戶備註
            //        triff.MeRemark = dr["MeRemark"].ToString();//本所備註
            //        triff.MeRemark_CHS = dr["MeRemark_CHS"].ToString();//本所備註
            //        triff.MeRemark_EN = dr["MeRemark_EN"].ToString();//本所備註
            //        triff.LargeEntity = cbLargeEntity.Checked;//是否大實體
            //        //triff.LargeEntity = (bool)dr["LargeEntity"];
            //        triff.Insert();
            //    }
            //    //ds.Tables["provisional"].Clear();
            //    //btnCopy.Text = "複製勾選";
            //    LoadData();
            //}
        }
        #endregion

        private void btnExchangeUudate_Click(object sender, EventArgs e)
        {
            MoneyMF mf = new MoneyMF();
            if (mf.ShowDialog() == DialogResult.OK)
            {
                List<Public.CMoney> money = new List<Public.CMoney>();
                Public.CMoney.ReadList(ref  money);  
                exchange = null;
                exchange = money;
            }
        }

        #region 功能選單
        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            contextMenuStrip1.Visible = false;
            if (toolStripLabel_Msg.Text != "")
            {
                toolStripLabel_Msg.Text = "";
            }
            switch (e.ClickedItem.Name)
            {
                case "toolStripButton_Add":
                case "ToolStripMenuItem_Add":
                    if (this.cbbCountry.SelectedValue != null)
                    {
                        AddFrom.QPForm_New qrfrom = new LawtechPTSystemByFirm.AddFrom.QPForm_New();
                        qrfrom.Text = qrfrom.Text + "--" + this.cbbCountry.Text + "   " + this.cbbReleaseKind.Text;
                        qrfrom.Country = this.cbbCountry.SelectedValue.ToString();
                        qrfrom.ReleaseKind = this.cbbReleaseKind.SelectedValue.ToString();
                        qrfrom.LargeEntity = this.cbLargeEntity.Checked;
                        qrfrom.LastAttorneyKey = LastSelectAttorney;
                        if (qrfrom.ShowDialog() == DialogResult.OK)
                        {
                            LoadData();
                        }
                    }
                    else
                    {
                        MessageBox.Show("國別有誤 !! \r\n 請確認選擇有效國別");
                    }
                    break;
                case "toolStripButton_Edit":
                case "toolStripMenuItem_Edit":
                    int iUser = Public.CommonFunctions.GetRecordAuth(SourceTableName, "ListPriceKey=" + ProPKey.ToString());
                    if (iUser == -1)//判斷是否有人使用中
                    {
                        //DraftResolutionStatus.EditorProposalStatus Editor = new DraftResolutionStatus.EditorProposalStatus();
                        //Editor.ResolutionStatusKey = CurrentResolutionStatusKey;
                        //Editor.ShowDialog();
                    }
                    else
                    {
                        Worker_Model manager = new Worker_Model();
                        Worker_Model.ReadOne(iUser, ref  manager);                       
                        
                        MessageBox.Show(string.Format("該筆資料目前被【{0}】使用中...", manager.EmployeeName), "提示訊息");
                    }

                    break;

                case "toolStripButton_Del":
                case "ToolStripMenuItem_Del":
                    if (dataGridView1.CurrentRow != null)
                    {
                        if (MessageBox.Show("是否要刪除？\r\n" + dataGridView1.CurrentRow.Cells["ProcedureName"].Value.ToString(), "提示訊息", MessageBoxButtons.OKCancel) == DialogResult.OK)
                        {
                            Public.CnTriff del = new CnTriff();
                            del.Delete((int)dataGridView1.CurrentRow.Cells["FeeSN"].Value);
                            dataGridView1.Rows.Remove(dataGridView1.CurrentRow);

                            this.dataSet_Triff.nTriffT.AcceptChanges();
                        }
                    }
                    break;
                case "toolStripMenuItem_Phase":
                    SubFrom.PhaseMF phaseMF = new SubFrom.PhaseMF();
                    phaseMF.ShowDialog();

                    break;
                case "ToolStripMenuItem_Copy":  //複製功能       
                    CopyFeeSNList.Clear();
                    int iCopyCount = 0;

                    for (int iCount = 0; iCount < dataGridView1.Rows.Count; iCount++)
                    {
                        if (dataGridView1.Rows[iCount].Cells["chkSelect"].Value != null && dataGridView1.Rows[iCount].Cells["chkSelect"].Value.ToString() == "True")
                        {
                            string key = dataGridView1.Rows[iCount].Cells["FeeSN"].Value.ToString();
                            if (CopyFeeSNList.Length > 0)
                            {
                                CopyFeeSNList.Append(",");
                            }
                            CopyFeeSNList.Append(key);
                            iCopyCount++;
                            dataGridView1.Rows[iCount].Cells["chkSelect"].Value = false;
                        }
                    }                   
                        toolStripLabel_Msg.Text = "複製勾選( " + iCopyCount.ToString() + " 筆)";
                 
                    break;
                case "ToolStripMenuItem_paste":
                   string[] keyList= CopyFeeSNList.ToString().Split(',');
                    if (CopyFeeSNList.Length>0 && keyList.Length > 0)
                    {
                        Public.CnTriff triff_Add = new CnTriff();
                        for (int iN = 0; iN < keyList.Length; iN++)
                        {      
                            int key;
                            bool isKey=int.TryParse(keyList[iN],out key);
                            if (isKey)
                            {
                               object obj= Public.CnTriff.ReadOne(key, ref triff_Add);

                               if (obj.ToString() == "0" && triff_Add.FeeSN == key)
                               {
                                   triff_Add.CountrySymbol = cbbCountry.SelectedValue.ToString();//國別
                                   triff_Add.KindSN = cbbReleaseKind.SelectedValue.ToString();//種類
                                   triff_Add.Create();
                               }

                            }                           
                          
                        }

                        toolStripLabel_Msg.Text = "貼上 " + keyList.Length.ToString() + " 筆";
                        LoadData();
                    }
                    break;
                case "ToolStripMenuItem_ExchangeRate":
                    btnExchangeUudate_Click(null, null);
                    break;
                case "toolStripMenuItem_DelMulti":
                    if (MessageBox.Show("是否要批次刪除？", "刪除", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {                      
                        foreach (DataGridViewRow dgv_r in dataGridView1.Rows)
                        {
                            if (dgv_r.Cells["chkSelect"].FormattedValue.ToString() == "True")
                            {
                                Public.CnTriff del = new CnTriff();
                                del.Delete((int)dataGridView1.CurrentRow.Cells["FeeSN"].Value);
                            }
                        }

                        foreach (DataGridViewRow dgv_r in dataGridView1.Rows)
                        {
                            if (dgv_r.Cells["chkSelect"].FormattedValue.ToString() == "True")
                            {
                                dataGridView1.Rows.Remove(dgv_r);
                            }
                        }
                        dataSet_Triff.nTriffT.AcceptChanges();
                       
                    }
                    break;
                case "toolStripMenuItem_Horizontal":
                case "toolStripButton1":
                    Public.Utility.SsplitContainerHorizontal(ref splitContainer1);
                    break;
            }
        }
        #endregion

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = false;
        }

        #region 開啟明細按鈕
        private void btnOpenDetail_Click(object sender, EventArgs e)
        {
            string status = Public.CommonFunctions.splitContainerCollapsed(splitContainer1);

            if (status == "Open")
            {
                btnOpenDetail.Text = "關閉明細";
            }
            else
            {
                btnOpenDetail.Text = "開啟明細";
            }
        }
        #endregion

        private void btn_statistics_Click(object sender, EventArgs e)
        {
            btn_statistics.Enabled = false;
            try
            {
                Exchange(txtGovFee, txtGovFeeNT, exchange, cbbGovMoneyKind.SelectedValue.ToString());
                Exchange(txtAttorneyFee, txtAttorneyELFeeNT, exchange, cbbAttorneyMoneyKind.SelectedValue.ToString());
                Exchange(txtAttorneyElseFee, txtAttorneyElseFeeNT, exchange, cbbAttorneyMoneyKind.SelectedValue.ToString());
                Exchange(txtNotifyFee, txtNotifyFeeNT, exchange, cbbAttorneyMoneyKind.SelectedValue.ToString());
                CountAttorneyFeeNT();
                Total();
                DBAccess dbhelper = new DBAccess();
               
                DataTable dtChange = this.dataSet_Triff.nTriffT.GetChanges();
                dbhelper.SqlBulkCopyDataAdapterUpdate(dtChange, Properties.Settings.Default.DataBaseConnectionString, "nTriffT");

                //int iUpdate = nTriffListTableAdapter.Update(this.dataSet_Triff.nTriffT);
                this.dataSet_Triff.nTriffT.AcceptChanges();
            }
            catch (System.Exception EX)
            {
                string ss = EX.Message;
            }
            finally{
             btn_statistics.Enabled = true;
            }
           
        }

       

    }
}