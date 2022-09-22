using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LawtechPTSystemByFirm.SubFrom
{
    /// <summary>
    /// (X)舊版 僅剩參考用
    /// </summary>
    public partial class TrademarkFeeSearch : Form
    {

        #region =====property=====
        private int iWorkerID = -1;
        /// <summary>
        /// 登入者ID
        /// </summary>
        public int WorkerID
        {
            get { return iWorkerID; }
            set { iWorkerID = value; }
        }


        private int iOfficeRole = -1;
        /// <summary>
        /// 權限 0.最高權限 1.指定權限 2.專利  3.商標 4.會計經理
        /// </summary>
        public int OfficeRole
        {
            get { return iOfficeRole; }
            set { iOfficeRole = value; }
        }

        /// <summary>
        /// 取得資料集來源
        /// </summary>
        public DataTable GetAccountingData
        {
            get
            {
                return (DataTable)bSource_Control.DataSource;
            }
        }

        /// <summary>
        /// 目前的DataGridViewRow CurrentRow
        /// </summary>
        public DataGridViewRow GV_CurrentRow
        {
            get
            {
                return dgViewMF.CurrentRow;
            }
        }

        public DataRow GetAccountingDataRow
        {
            get
            {
                return ((System.Data.DataRowView)(dgViewMF.CurrentRow.DataBoundItem)).Row;
            }
        }
        #endregion

        BindingSource bSource_Control;

        public TrademarkFeeSearch()
        {
            InitializeComponent();
            dgViewMF.AutoGenerateColumns = false;
        }

        #region TrademarkFeeSearch_Load
        private void TrademarkFeeSearch_Load(object sender, EventArgs e)
        {
            Public.PublicForm Forms = new LawtechPTSystemByFirm.Public.PublicForm();
            Forms.TrademarkFeeSearch = this;

            //登入者
            iWorkerID = Properties.Settings.Default.WorkerKEY;
            Worker_Model worker = new Worker_Model();
            Worker_Model.ReadOne(iWorkerID, ref  worker);
          
            //角色的權限
            OfficeRole = worker.OfficeRole.Value;

            this.accountingSelectValueTableAdapter.Fill(this.dataSet_Accounting.AccountingSelectValue);
            this.dataSet_Accounting.AccountingSelectDate.Rows.Clear();


            this.accountingSelectDateTableAdapter.Fill(this.dataSet_Accounting.AccountingSelectDate);

            bSource_Control = new BindingSource();
            dgViewMF.DataSource = bSource_Control;
            bindingNavigator1.BindingSource = bSource_Control;
        }


        private void TrademarkFeeSearch_FormClosed(object sender, FormClosedEventArgs e)
        {
            Public.PublicForm Forms = new LawtechPTSystemByFirm.Public.PublicForm();
            Forms.TrademarkFeeSearch = null;
        }
        #endregion

        private void but_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region but_Excel_Click
        private void but_Excel_Click(object sender, EventArgs e)
        {
            try
            {
                Public.DLL dll = new LawtechPTSystemByFirm.Public.DLL();
                Task task = dll.WriteToCSV(dgViewMF);
            }
            catch
            {
                MessageBox.Show("匯出Excel失敗:匯出過程發生異常被終止");
            }
        }
        #endregion

        #region maskedTextBox_S_DoubleClick
        private void maskedTextBox_S_DoubleClick(object sender, EventArgs e)
        {

        }
        #endregion

        #region but_Search_Click
        private void but_Search_Click(object sender, EventArgs e)
        {
            string times = "";
            string sfilter = "";
            string sfilter1 = "";
            if (comboBox_SelectValue.Text == "" && comboBox_SelectValue1.Text == "" && maskedTextBox_S.Text == "    /  /" && maskedTextBox_D.Text == "    /  /")
            {
                sfilter = " 1=1 ";
            }
            else
            {
                DateTime dtS = new DateTime(), dtE = new DateTime();

                if (maskedTextBox_S.Text != "    /  /")
                {
                    bool IsS = DateTime.TryParse(maskedTextBox_S.Text, out dtS);
                    if (!IsS)
                    {
                        MessageBox.Show("日期格式錯誤 <<" + maskedTextBox_S.Text + ">>");
                        return;
                    }
                }

                if (maskedTextBox_D.Text != "    /  /")
                {
                    bool IsE = DateTime.TryParse(maskedTextBox_D.Text, out dtE);
                    if (!IsE)
                    {
                        MessageBox.Show("日期格式錯誤 <<" + maskedTextBox_D.Text + ">>");
                        return;
                    }
                }

                if (maskedTextBox_S.Text != "    /  /" && maskedTextBox_D.Text != "    /  /")
                {

                    if (dtS > dtE)
                    {
                        maskedTextBox_S.Text = dtE.ToString("yyyy/MM/dd");
                        maskedTextBox_D.Text = dtS.ToString("yyyy/MM/dd");
                    }
                }


                string strDateMode = comboBox_DateMode.SelectedValue.ToString();

                if (maskedTextBox_S.Text != "    /  /" && maskedTextBox_D.Text == "    /  /")
                {
                    times += " " + strDateMode + ">='" + maskedTextBox_S.Text + "'";
                }
                else if (maskedTextBox_S.Text == "    /  /" && maskedTextBox_D.Text != "    /  /")
                {
                    times += " " + strDateMode + "<='" + maskedTextBox_D.Text + "'";
                }
                else if (maskedTextBox_S.Text != "    /  /" && maskedTextBox_D.Text != "    /  /")
                {
                    times += " (" + strDateMode + " >= '" + maskedTextBox_S.Text + "' and " + strDateMode + "<= '" + maskedTextBox_D.Text + "')";
                }


                if (comboBox_SelectValue.Text.Trim() != "" || comboBox_SelectValue.SelectedValue != null)
                {
                    switch (comboBox_Select.SelectedValue.ToString())
                    {
                        case "PPP":
                        case "EventNo":
                        case "MainCustomerRefNo":
                        case "ApplicationNo":
                            sfilter = comboBox_Select.SelectedValue.ToString() + " like '%" + comboBox_SelectValue.Text + "%' ";
                            break;
                        case "CustomerName":
                            if (comboBox_SelectValue.SelectedValue != null)
                            {
                                sfilter = "(CASE PatentManagementT.DelegateType WHEN 1 THEN ApplicantT.ApplicantKey WHEN 2 THEN AttorneyT.AttorneyKey END) =" + comboBox_SelectValue.SelectedValue.ToString();
                            }
                            else
                            {
                                comboBox_SelectValue.Text = "";
                            }

                            break;
                        case "CountryT.CountrySymbol":
                            if (comboBox_Select.SelectedValue != null)
                            {
                                sfilter = comboBox_Select.SelectedValue.ToString() + " ='" + comboBox_SelectValue.SelectedValue.ToString() + "'";
                            }
                            else
                            {
                                comboBox_SelectValue.Text = "";
                            }
                            break;
                    }
                }

                //---------------------------------------------------------------------------------------------
                if (comboBox_SelectValue1.Text.Trim() != "" || comboBox_SelectValue1.SelectedValue != null)
                {
                    switch (comboBox_Select1.SelectedValue.ToString())
                    {
                        case "PPP":
                        case "EventNo":
                        case "MainCustomerRefNo":
                        case "ApplicationNo":
                            sfilter1 = comboBox_Select1.SelectedValue.ToString() + " like '%" + comboBox_SelectValue1.Text + "%' ";
                            break;
                        case "CustomerName":
                            if (comboBox_SelectValue1.SelectedValue != null)
                            {
                                sfilter1 = "(CASE PatentManagementT.DelegateType WHEN 1 THEN ApplicantT.ApplicantKey WHEN 2 THEN AttorneyT.AttorneyKey END) =" + comboBox_SelectValue1.SelectedValue.ToString();
                            }
                            else
                            {
                                comboBox_SelectValue1.Text = "";
                            }

                            break;
                        case "CountryT.CountrySymbol":
                            if (comboBox_Select1.SelectedValue != null)
                            {
                                sfilter1 = comboBox_Select1.SelectedValue.ToString() + " ='" + comboBox_SelectValue1.SelectedValue.ToString() + "'";
                            }
                            else
                            {
                                comboBox_SelectValue1.Text = "";
                            }
                            break;
                    }
                }


            }


            string FullFilter = "";
            if (sfilter1 != "" && sfilter != "")
            {
                if (rb_and.Checked)
                {
                    FullFilter = sfilter + " and " + sfilter1;
                }
                else
                {
                    FullFilter = "(" + sfilter + " or " + sfilter1 + ")";
                }
            }
            else
            {
                if (sfilter != "")
                {
                    FullFilter = sfilter;
                }
                else
                {
                    FullFilter = sfilter1;
                }
            }

            string[] sWhere = { times, FullFilter };

            StringBuilder FullWhere = new StringBuilder();
            for (int iArray = 0; iArray < sWhere.Length; iArray++)
            {
                if (sWhere[iArray] != "")
                {
                    if (FullWhere.Length > 0)
                    {
                        FullWhere.Append(" and ");
                    }
                    FullWhere.Append(sWhere[iArray]);
                }
            }

            DataBind_Fee(FullWhere.ToString());

        }
        #endregion

        #region DataBind_Fee
        public void DataBind_Fee(string strWhere)
        {
            System.Data.DataSet dt_PatentFee = GetFeeEvent(strWhere);
            bSource_Control.DataSource = dt_PatentFee.Tables[0];


            decimal Totall = dt_PatentFee.Tables[1].Rows[0]["Totall"] != DBNull.Value ? (decimal)dt_PatentFee.Tables[1].Rows[0]["Totall"] : 0;
            decimal Totall_CO = dt_PatentFee.Tables[2].Rows[0]["Totall"] != DBNull.Value ? (decimal)dt_PatentFee.Tables[1].Rows[0]["Totall"] : 0;
            toolStripLabel_Totall.Text =( Totall + Totall_CO).ToString("#,##0.##");

            decimal OAttorneyGovFee = dt_PatentFee.Tables[1].Rows[0]["OAttorneyGovFee"] != DBNull.Value ? (decimal)dt_PatentFee.Tables[1].Rows[0]["OAttorneyGovFee"] : 0;
            decimal OAttorneyGovFee_CO = dt_PatentFee.Tables[2].Rows[0]["OAttorneyGovFee"] != DBNull.Value ? (decimal)dt_PatentFee.Tables[1].Rows[0]["OAttorneyGovFee"] : 0;
            toolStripLabel_OAttorneyGovFee.Text =( OAttorneyGovFee + OAttorneyGovFee_CO).ToString("#,##0.##");

            decimal OtherTotalFee = dt_PatentFee.Tables[1].Rows[0]["OtherTotalFee"] != DBNull.Value ? (decimal)dt_PatentFee.Tables[1].Rows[0]["OtherTotalFee"] : 0;
            decimal OtherTotalFee_CO = dt_PatentFee.Tables[2].Rows[0]["OtherTotalFee"] != DBNull.Value ? (decimal)dt_PatentFee.Tables[1].Rows[0]["OtherTotalFee"] : 0;
            toolStripLabel_OtherTotalFee.Text =( OtherTotalFee + OtherTotalFee_CO).ToString("#,##0.##");
        }
        #endregion

        #region GetFeeEvent 取得商標請款的資料
        /// <summary>
        /// 取得請款的資料
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public System.Data.DataSet GetFeeEvent(string strWhere)
        {

            strWhere = strWhere.Replace("EventNo", "TrademarkManagementT.TrademarkNo");

            string strWhere1 = strWhere.Replace("EventNo", "TrademarkControversyManagementT.TrademarkNo").Replace("TrademarkManagementT.", "TrademarkControversyManagementT.");


            string strPatentFeeSQL = string.Format(
                                    @"SELECT  '1' as TrademarkType ,  TrademarkManagementT.TrademarkID AS MainKey, TrademarkFeeT.FeeKEY, TrademarkManagementT.TrademarkNo, TrademarkManagementT.DelegateType, 
                                                  TrademarkManagementT.MainCustomerRefNo, CountryT.Country, TrademarkManagementT.ApplicationDate, TrademarkManagementT.ApplicationNo, 
                                                  TrademarkFeeT.FeeSubject, TrademarkFeeT.Totall, AttorneyT_1.AttorneyFirm, TrademarkFeeT.SingCode, TrademarkFeeT.ReceiptDate, TrademarkFeeT.PayDate, 
                                                  WorkerT.EmployeeName AS WorkerName, TrademarkFeeT.OtherTotalFee, TrademarkFeeT.OAttorneyGovFee, TrademarkFeeT.PPP, TrademarkFeeT.PracticalityPay, 
                                                  CASE TrademarkManagementT.DelegateType WHEN 1 THEN TrademarkManagementT.ApplicantNames WHEN 2 THEN
                                                      (SELECT     AttorneyT.AttorneyFirm
                                                        FROM          AttorneyT
                                                        WHERE      TrademarkManagementT.MainCustomer = AttorneyKey) END AS CustomerName, TrademarkFeeT.RDate, AttorneyT.AttorneyFirm AS AttorneyFirmFee, 
                                                  TrademarkFeeT.OMoney, TrademarkFeeT.GovFee, TrademarkFeeT.OAttorneyFee, TrademarkFeeT.OthFee, AttorneyT.AttorneyKey, TrademarkFeeT.GMoney, 
                                                  TrademarkManagementT.ApplicantNames, TrademarkFeeT.TMoney, TrademarkFeeT.TotalNT, TrademarkFeeT.SingCodeStatus, TrademarkFeeT.Remark, 
                                                  TrademarkFeeT.PayMemo, TrademarkManagementT.StyleName, TrademarkManagementT.TMTypeName,TrademarkManagementT.TrademarkName
                                        FROM         TrademarkManagementT LEFT OUTER JOIN
                                                  AttorneyT AS AttorneyT_1 ON TrademarkManagementT.OutsourcingAttorney = AttorneyT_1.AttorneyKey LEFT OUTER JOIN
                                                  CountryT ON TrademarkManagementT.CountrySymbol = CountryT.CountrySymbol RIGHT OUTER JOIN
                                                  TrademarkNotifyEventToFeeT LEFT OUTER JOIN
                                                  TrademarkNotifyEventT ON TrademarkNotifyEventToFeeT.TMNotifyEventID = TrademarkNotifyEventT.TMNotifyEventID RIGHT OUTER JOIN
                                                  TrademarkFeeT ON TrademarkNotifyEventToFeeT.FeeKEY = TrademarkFeeT.FeeKEY LEFT OUTER JOIN
                                                  AttorneyT ON TrademarkFeeT.Attorney = AttorneyT.AttorneyKey LEFT OUTER JOIN
                                                  WorkerT ON TrademarkFeeT.FClientTransactor = WorkerT.WorkerKey ON TrademarkManagementT.TrademarkID = TrademarkFeeT.TrademarkID  where {0}
                                        UNION
                                            SELECT   '2' as TrademarkType ,   TrademarkControversyManagementT.TrademarkControversyID AS MainKey, TrademarkControversyFeeT.ControversyFeeKEY, 
                                                              TrademarkControversyManagementT.TrademarkNo, TrademarkControversyManagementT.DelegateType, TrademarkControversyManagementT.MainCustomerRefNo, 
                                                              CountryT.Country, TrademarkControversyManagementT.ApplicationDate, TrademarkControversyManagementT.ApplicationNo, TrademarkControversyFeeT.FeeSubject, 
                                                              TrademarkControversyFeeT.Totall, AttorneyT_1.AttorneyFirm, TrademarkControversyFeeT.SingCode, TrademarkControversyFeeT.ReceiptDate, 
                                                              TrademarkControversyFeeT.PayDate, WorkerT.EmployeeName AS WorkerName, TrademarkControversyFeeT.OtherTotalFee, TrademarkControversyFeeT.OAttorneyGovFee, 
                                                              TrademarkControversyFeeT.PPP, TrademarkControversyFeeT.PracticalityPay, 
                                                              CASE TrademarkControversyManagementT.DelegateType WHEN 1 THEN TrademarkControversyManagementT.ApplicantNames WHEN 2 THEN
                                                                  (SELECT     AttorneyT.AttorneyFirm
                                                                    FROM          AttorneyT
                                                                    WHERE      TrademarkControversyManagementT.MainCustomer = AttorneyKey) END AS CustomerName, TrademarkControversyFeeT.RDate, 
                                                              AttorneyT.AttorneyFirm AS AttorneyFirmFee, TrademarkControversyFeeT.OMoney, TrademarkControversyFeeT.GovFee, TrademarkControversyFeeT.OAttorneyFee, 
                                                              TrademarkControversyFeeT.OthFee, AttorneyT.AttorneyKey, TrademarkControversyFeeT.GMoney, TrademarkControversyManagementT.ApplicantNames, 
                                                              TrademarkControversyFeeT.TMoney, TrademarkControversyFeeT.TotalNT, TrademarkControversyFeeT.SingCodeStatus, TrademarkControversyFeeT.Remark, 
                                                              TrademarkControversyFeeT.PayMemo, TrademarkControversyManagementT.StyleName, TrademarkControversyManagementT.TMTypeName, 
                                                              TrademarkControversyManagementT.TrademarkName
                                        FROM         TrademarkControversyManagementT LEFT OUTER JOIN
                                                              AttorneyT AS AttorneyT_1 ON TrademarkControversyManagementT.OutsourcingAttorney = AttorneyT_1.AttorneyKey LEFT OUTER JOIN
                                                              CountryT ON TrademarkControversyManagementT.CountrySymbol = CountryT.CountrySymbol RIGHT OUTER JOIN
                                                              TrademarkControversyNotifyEventToFeeT LEFT OUTER JOIN
                                                              TrademarkControversyNotifyEventT ON 
                                                              TrademarkControversyNotifyEventToFeeT.TMNotifyControversyEventID = TrademarkControversyNotifyEventT.TMNotifyControversyEventID RIGHT OUTER JOIN
                                                              TrademarkControversyFeeT ON TrademarkControversyNotifyEventToFeeT.ControversyFeeKEY = TrademarkControversyFeeT.ControversyFeeKEY LEFT OUTER JOIN
                                                              AttorneyT ON TrademarkControversyFeeT.Attorney = AttorneyT.AttorneyKey LEFT OUTER JOIN
                                                              WorkerT ON TrademarkControversyFeeT.FClientTransactor = WorkerT.WorkerKey ON 
                                                              TrademarkControversyManagementT.TrademarkControversyID = TrademarkControversyFeeT.TrademarkControversyID where {1};

                                          SELECT   Sum( TrademarkFeeT.TotalNT) as Totall, SUM(TrademarkFeeT.OAttorneyGovFee) as OAttorneyGovFee,SUM(TrademarkFeeT.OtherTotalFee) as OtherTotalFee
                                           FROM    TrademarkManagementT LEFT OUTER JOIN
                                                  AttorneyT AS AttorneyT_1 ON TrademarkManagementT.OutsourcingAttorney = AttorneyT_1.AttorneyKey LEFT OUTER JOIN
                                                  CountryT ON TrademarkManagementT.CountrySymbol = CountryT.CountrySymbol RIGHT OUTER JOIN
                                                  TrademarkNotifyEventToFeeT LEFT OUTER JOIN
                                                  TrademarkNotifyEventT ON TrademarkNotifyEventToFeeT.TMNotifyEventID = TrademarkNotifyEventT.TMNotifyEventID RIGHT OUTER JOIN
                                                  TrademarkFeeT ON TrademarkNotifyEventToFeeT.FeeKEY = TrademarkFeeT.FeeKEY LEFT OUTER JOIN
                                                  AttorneyT ON TrademarkFeeT.Attorney = AttorneyT.AttorneyKey LEFT OUTER JOIN
                                                  WorkerT ON TrademarkFeeT.FClientTransactor = WorkerT.WorkerKey ON TrademarkManagementT.TrademarkID = TrademarkFeeT.TrademarkID  where {0}

                                      

                                         SELECT   Sum( TrademarkControversyFeeT.TotalNT) as Totall, SUM(TrademarkControversyFeeT.OAttorneyGovFee) as OAttorneyGovFee,SUM(TrademarkControversyFeeT.OtherTotalFee) as OtherTotalFee
                                        FROM         TrademarkControversyManagementT LEFT OUTER JOIN
                                                              AttorneyT AS AttorneyT_1 ON TrademarkControversyManagementT.OutsourcingAttorney = AttorneyT_1.AttorneyKey LEFT OUTER JOIN
                                                              CountryT ON TrademarkControversyManagementT.CountrySymbol = CountryT.CountrySymbol RIGHT OUTER JOIN
                                                              TrademarkControversyNotifyEventToFeeT LEFT OUTER JOIN
                                                              TrademarkControversyNotifyEventT ON 
                                                              TrademarkControversyNotifyEventToFeeT.TMNotifyControversyEventID = TrademarkControversyNotifyEventT.TMNotifyControversyEventID RIGHT OUTER JOIN
                                                              TrademarkControversyFeeT ON TrademarkControversyNotifyEventToFeeT.ControversyFeeKEY = TrademarkControversyFeeT.ControversyFeeKEY LEFT OUTER JOIN
                                                              AttorneyT ON TrademarkControversyFeeT.Attorney = AttorneyT.AttorneyKey LEFT OUTER JOIN
                                                              WorkerT ON TrademarkControversyFeeT.FClientTransactor = WorkerT.WorkerKey ON 
                                                              TrademarkControversyManagementT.TrademarkControversyID = TrademarkControversyFeeT.TrademarkControversyID where {1};

                                            ", strWhere, strWhere1);

            Public.DLL dll = new LawtechPTSystemByFirm.Public.DLL();
            System.Data.DataSet dtFeeEvent = new System.Data.DataSet();
            dtFeeEvent = dll.SqlDataAdapterDataSet(strPatentFeeSQL);
            return dtFeeEvent;
        }
        #endregion

        #region comboBox_Select_SelectedIndexChanged
        private void comboBox_Select_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox combo = (ComboBox)sender;
            DataTable dt = new DataTable();
            Public.DLL dll = new LawtechPTSystemByFirm.Public.DLL();
            string strSQL = "";

            if (combo.SelectedValue != null)
            {
                switch (combo.SelectedValue.ToString())
                {
                    case "CustomerName"://主委託人

                        strSQL = "select ApplicantKey,ApplicantName from ApplicantT order by ApplicantName";
                        dt = dll.SqlDataAdapterDataTable(strSQL);
                        comboBox_SelectValue.DropDownStyle = ComboBoxStyle.DropDown;
                        comboBox_SelectValue.AutoCompleteSource = AutoCompleteSource.ListItems;
                        comboBox_SelectValue.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                        comboBox_SelectValue.DataSource = dt;
                        comboBox_SelectValue.DisplayMember = "ApplicantName";
                        comboBox_SelectValue.ValueMember = "ApplicantKey";
                        comboBox_SelectValue.Text = "";
                        break;
                    case "CountryT.CountrySymbol"://國別
                        strSQL = "select CountrySymbol+'-'+Country as Country,CountrySymbol from CountryT order by SN";
                        dt = dll.SqlDataAdapterDataTable(strSQL);
                        comboBox_SelectValue.DropDownStyle = ComboBoxStyle.DropDown;
                        comboBox_SelectValue.AutoCompleteSource = AutoCompleteSource.ListItems;
                        comboBox_SelectValue.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                        comboBox_SelectValue.DataSource = dt;
                        comboBox_SelectValue.DisplayMember = "Country";
                        comboBox_SelectValue.ValueMember = "CountrySymbol";
                        comboBox_SelectValue.Text = "";
                        break;
                    default:
                        comboBox_SelectValue.AutoCompleteSource = AutoCompleteSource.None;
                        comboBox_SelectValue.AutoCompleteMode = AutoCompleteMode.None;
                        comboBox_SelectValue.DropDownStyle = ComboBoxStyle.Simple;
                        comboBox_SelectValue.Text = "";
                        break;
                }
            }
        }


        private void comboBox_Select1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox combo = (ComboBox)sender;
            DataTable dt = new DataTable();
            Public.DLL dll = new LawtechPTSystemByFirm.Public.DLL();
            string strSQL = "";

            if (combo.SelectedValue != null)
            {
                switch (combo.SelectedValue.ToString())
                {
                    case "CustomerName"://主委託人

                        strSQL = "select ApplicantKey,ApplicantName from ApplicantT order by ApplicantName";
                        dt = dll.SqlDataAdapterDataTable(strSQL);
                        comboBox_SelectValue1.DropDownStyle = ComboBoxStyle.DropDown;
                        comboBox_SelectValue1.AutoCompleteSource = AutoCompleteSource.ListItems;
                        comboBox_SelectValue1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                        comboBox_SelectValue1.DataSource = dt;
                        comboBox_SelectValue1.DisplayMember = "ApplicantName";
                        comboBox_SelectValue1.ValueMember = "ApplicantKey";
                        comboBox_SelectValue1.Text = "";
                        break;
                    case "CountryT.CountrySymbol"://國別
                        strSQL = "select CountrySymbol+'-'+Country as Country,CountrySymbol from CountryT order by SN";
                        dt = dll.SqlDataAdapterDataTable(strSQL);
                        comboBox_SelectValue1.DropDownStyle = ComboBoxStyle.DropDown;
                        comboBox_SelectValue1.AutoCompleteSource = AutoCompleteSource.ListItems;
                        comboBox_SelectValue1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                        comboBox_SelectValue1.DataSource = dt;
                        comboBox_SelectValue1.DisplayMember = "Country";
                        comboBox_SelectValue1.ValueMember = "CountrySymbol";
                        comboBox_SelectValue1.Text = "";
                        break;
                    default:
                        comboBox_SelectValue1.AutoCompleteSource = AutoCompleteSource.None;
                        comboBox_SelectValue1.AutoCompleteMode = AutoCompleteMode.None;
                        comboBox_SelectValue1.DropDownStyle = ComboBoxStyle.Simple;
                        comboBox_SelectValue1.Text = "";
                        break;
                }
            }
        }
        #endregion

        #region button1_Click
        private void button1_Click(object sender, EventArgs e)
        {
            if (dgViewMF.CurrentRow != null)
            {
                string TrademarkType = dgViewMF.CurrentRow.Cells["TrademarkType"].Value.ToString();

                if (TrademarkType == "1")
                {
                    TrademarkHistoryRecord HistoryRecord = new TrademarkHistoryRecord();
                    HistoryRecord.TrademarkID = (int)dgViewMF.CurrentRow.Cells["MainKey"].Value;
                    HistoryRecord.TabSelectedIndex = 3;
                    HistoryRecord.Show();
                }
                else
                {
                    TrademarkControversyHistoryRecord HistoryRecord = new TrademarkControversyHistoryRecord();
                    HistoryRecord.TrademarkControversyID = (int)dgViewMF.CurrentRow.Cells["MainKey"].Value;
                    HistoryRecord.TabSelectedIndex = 3;
                    HistoryRecord.Show();
                }
            }
        }
        #endregion

        #region dgViewMF_CellDoubleClick
        private void dgViewMF_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != -1 && e.RowIndex != -1)
            {
                button1_Click(null, null);
            }
        }
        #endregion

        private void dgViewMF_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox_DateMode_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}
