using System;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LawtechPTSystem.SubFrom
{
    /// <summary>
    /// 商標請款查詢
    /// </summary>
    public partial class TrademarkFeeSearchList : Form
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

        public TrademarkFeeSearchList()
        {
            InitializeComponent();
            dgViewMF.AutoGenerateColumns = false;
            Public.DynamicGridViewColumn.GetGridColum(ref dgViewMF);
        }

        private void PatentFeeSearch_Load(object sender, EventArgs e)
        {
            Public.PublicForm Forms = new Public.PublicForm();
            Forms.TrademarkFeeSearchList = this;

            //登入者
            iWorkerID = Properties.Settings.Default.WorkerKEY;
            Worker_Model worker = new Worker_Model();
            Worker_Model.ReadOne(iWorkerID, ref  worker);     
           
            //角色的權限
            OfficeRole = worker.OfficeRole.Value;

          
            bSource_Control = new BindingSource();
            dgViewMF.DataSource = bSource_Control;
            bindingNavigator1.BindingSource = bSource_Control;

            Public.Utility.SetLoadDataRange(userControlFilterDate1);

            if (Properties.Settings.Default.IsLoadData)
            {
                but_Search_Click(null, null);
            }
        }

        private void PatentFeeSearch_FormClosed(object sender, FormClosedEventArgs e)
        {
            Public.PublicForm Forms = new Public.PublicForm();
            Forms.TrademarkFeeSearchList = null;
        }

        private void but_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void but_Excel_Click(object sender, EventArgs e)
        {
            try
            {
                Public.DLL dll = new Public.DLL();
                Task t = dll.WriteToCSV(dgViewMF);
            }
            catch
            {
                MessageBox.Show("匯出CSV失敗:匯出過程發生異常被終止");
            }
        }

        #region but_Search_Click
        private void but_Search_Click(object sender, EventArgs e)
        {
            but_Search.Enabled = false;

            string strSQLWhere = Public.CommonFunctions.GetSQLScript(QueryFilter1, QueryFilter2, Radio_and.Checked ? " and " : " or ", userControlFilterDate1);           

            DataBind_Fee(strSQLWhere.ToString());

            but_Search.Enabled = true;
        }
        #endregion


        #region contextMenuStrip_ForDate_ItemClicked
        private void contextMenuStrip_ForDate_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ContextMenuStrip content = (ContextMenuStrip)sender;
            MaskedTextBox mtb = content.SourceControl as MaskedTextBox;

            contextMenuStrip_ForDate.Visible = false;

            switch (e.ClickedItem.Name)
            {
                case "ToolStripMenuItem_Calculation":

                    US.CalculationDate Calculation = new LawtechPTSystem.US.CalculationDate();
                    DateTime dt = new DateTime(1900, 1, 1);
                    bool IsSuccess = DateTime.TryParse(mtb.Text, out dt);
                    if (IsSuccess)
                    {
                        Calculation.CurrentDate = dt;
                    }
                    else
                    {
                        Calculation.CurrentDate = new DateTime(1900, 1, 1);
                    }

                    //取得結果
                    if (Calculation.ShowDialog() == DialogResult.OK)
                    {
                        mtb.Text = Calculation.GetResult;
                    }
                    break;
            }
        }
        #endregion

        #region maskedTextBox_S_DoubleClick
        private void maskedTextBox_S_DoubleClick(object sender, EventArgs e)
        {
            MaskedTextBox mtb = (MaskedTextBox)sender;
            DateTime dt;
            bool IsSuccess = DateTime.TryParse(mtb.Text, out dt);
            if (!IsSuccess)
            {
                mtb.Text = DateTime.Now.ToString("yyyy-MM-dd");
            }
        }
        #endregion      
        
        #region DataBind_Fee
        public void DataBind_Fee(string strWhere)
        {
            System.Data.DataSet dt_PatentFee = GetFeeEvent(strWhere);

            if (dt_PatentFee.Tables.Count == 2)
            {
                bSource_Control.DataSource = dt_PatentFee.Tables[0];


                decimal Totall = dt_PatentFee.Tables[1].Rows[0]["TotalNT"] != DBNull.Value ? (decimal)dt_PatentFee.Tables[1].Rows[0]["TotalNT"] : 0;
                toolStripLabel_Totall.Text = Totall.ToString("#,##0.##");

                decimal OAttorneyGovFee = dt_PatentFee.Tables[1].Rows[0]["OAttorneyGovFee"] != DBNull.Value ? (decimal)dt_PatentFee.Tables[1].Rows[0]["OAttorneyGovFee"] : 0;
                toolStripLabel_OAttorneyGovFee.Text = OAttorneyGovFee.ToString("#,##0.##");

                decimal OtherTotalFee = dt_PatentFee.Tables[1].Rows[0]["OtherTotalFee"] != DBNull.Value ? (decimal)dt_PatentFee.Tables[1].Rows[0]["OtherTotalFee"] : 0;
                toolStripLabel_OtherTotalFee.Text = OtherTotalFee.ToString("#,##0.##");

                decimal PracticalityPay = dt_PatentFee.Tables[1].Rows[0]["PracticalityPay"] != DBNull.Value ? (decimal)dt_PatentFee.Tables[1].Rows[0]["PracticalityPay"] : 0;
                toolStripLabel_PracticalityPay.Text = PracticalityPay.ToString("#,##0.##");
            }
        }
        #endregion

        #region GetFeeEvent 取得專利請款的資料
        /// <summary>
        /// 取得請款的資料
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public System.Data.DataSet GetFeeEvent(string strWhere)
        {           
            string strPatentFeeSQL = string.Format(
                                    @"SELECT  * from V_TrademarkFeeSearch  {0};
 SELECT   Sum( TotalNT) as TotalNT, SUM(OAttorneyGovFee)as OAttorneyGovFee ,SUM(OtherTotalFee) as OtherTotalFee ,SUM(PracticalityPay) as PracticalityPay
    FROM         V_TrademarkFeeSearch  {0} ", strWhere);

            Public.DLL dll = new Public.DLL();
            System.Data.DataSet dtFeeEvent = new System.Data.DataSet();
            dtFeeEvent = dll.SqlDataAdapterDataSet(strPatentFeeSQL);
            return dtFeeEvent;
        }
        #endregion

        private void dgViewMF_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e!=null && e.RowIndex !=-1 && dgViewMF.CurrentRow != null)
            {
                TrademarkHistoryRecord patent = new LawtechPTSystem.SubFrom.TrademarkHistoryRecord();
                patent.TrademarkID = (int)dgViewMF.CurrentRow.Cells["TrademarkID"].Value;
                patent.TabSelectedIndex = 2;
                patent.Show();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dgViewMF.CurrentRow != null)
            {
                dgViewMF_CellDoubleClick(dgViewMF, new DataGridViewCellEventArgs(dgViewMF.CurrentCell.ColumnIndex, dgViewMF.CurrentCell.RowIndex));
            }
        }

        private void contextMenuStrip_Accounting_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Name)
            {
                case "ToolStripMenuItem_CaseDetail":
                    if (dgViewMF.CurrentRow != null)
                    {
                        TrademarkHistoryRecord HistoryRecord = new TrademarkHistoryRecord();
                        HistoryRecord.TrademarkID = (int)dgViewMF.CurrentRow.Cells["TrademarkID"].Value;
                        HistoryRecord.TabSelectedIndex = 2;
                        HistoryRecord.Show();
                    }
                    break;

                case "ToolStripMenuItem_PatentCompleteHistory":
                    if (dgViewMF.CurrentRow != null)
                    {
                        ViewFrom.TrademarkCompleteHistory history = new ViewFrom.TrademarkCompleteHistory();
                        history.Gv = dgViewMF;
                        history.Show();
                    }
                    break;
                case "toolStripMenuItem_SetGridColumn":
                    SetGridColumnT gc = new SetGridColumnT();
                    gc.CurrentGridSymboID = dgViewMF.Tag.ToString();
                    gc.TitleName = "應收款項清單表";
                    gc.Show();
                    break;
            }
        }

        private void dgViewMF_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = false;
        }
    }
}
