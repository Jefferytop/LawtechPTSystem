﻿using System;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LawtechPTSystemByFirm.SubFrom
{
    /// <summary>
    /// 商標 付款查詢
    /// </summary>
    public partial class TrademarkPaymentSearchList : Form
    {

        BindingSource bSource_Control;

        public TrademarkPaymentSearchList()
        {
            InitializeComponent();
            dgViewMF.AutoGenerateColumns = false;
            Public.DynamicGridViewColumn.GetGridColum(ref dgViewMF);
        }

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
        /// 權限 0.最高權限 1.指定權限 2.專利  3.商標
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

        private void but_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void but_Excel_Click(object sender, EventArgs e)
        {
            try
            {
                Public.DLL dll = new LawtechPTSystemByFirm.Public.DLL();
                Task task = dll.WriteToCSV(dgViewMF);
            }
            catch
            {
                MessageBox.Show("匯出CSV失敗:匯出過程發生異常被終止");
            }
        }

        private void but_Search_Click(object sender, EventArgs e)
        {
            but_Search.Enabled = false;

            string FullWhere = Public.CommonFunctions.GetSQLScript(QueryFilter1, QueryFilter2, rb_and.Checked ? " and " : " or ", userControlFilterDate1);
            if (string.IsNullOrEmpty(FullWhere.Trim()))
            {
                DataBind_Payment("");
            }
            else {
                DataBind_Payment(FullWhere.ToString());
            }

            but_Search.Enabled = true;
        }

        #region DataBind_Fee
        public void DataBind_Payment(string strWhere)
        {
            System.Data.DataSet dt_PatentPayment = GetPatentPaymentT(strWhere);
            bSource_Control.DataSource = dt_PatentPayment.Tables[0];

            decimal Totall = dt_PatentPayment.Tables[1].Rows[0]["Totall"] != DBNull.Value ? (decimal)dt_PatentPayment.Tables[1].Rows[0]["Totall"] : 0;
            toolStripLabel_Totall.Text = Totall.ToString("#,##0.##");

            decimal ActuallyPay = dt_PatentPayment.Tables[1].Rows[0]["ActuallyPay"] != DBNull.Value ? (decimal)dt_PatentPayment.Tables[1].Rows[0]["ActuallyPay"] : 0;
            toolStripLabel_ActuallyPay.Text = ActuallyPay.ToString("#,##0.##");
        }
        #endregion

        #region =============maskedTextBox_S_DoubleClick===========
        private void maskedTextBox_S_DoubleClick(object sender, EventArgs e)
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

        #region contextMenuStrip_ForDate_ItemClicked
        private void contextMenuStrip_ForDate_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            ContextMenuStrip content = (ContextMenuStrip)sender;
            MaskedTextBox mtb = content.SourceControl as MaskedTextBox;

            contextMenuStrip_ForDate.Visible = false;

            switch (e.ClickedItem.Name)
            {
                case "ToolStripMenuItem_Calculation":

                    US.CalculationDate Calculation = new LawtechPTSystemByFirm.US.CalculationDate();
                    DateTime dt = new DateTime(1900, 1, 1);
                    bool IsSuccess = DateTime.TryParse(mtb.Text, out dt);
                    if (IsSuccess)
                    {
                        Calculation.CurrentDate = dt;
                    }
                    else
                    {
                        Calculation.CurrentDate =null;
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
       
        #region GetFeeEvent 取得專利付款的資料
        /// <summary>
        /// 取得付款的資料
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public System.Data.DataSet GetPatentPaymentT(string strWhere)
        {
            string strPatentFeeSQL = string.Format(
                                    @"SELECT  *   FROM   V_TrademarkControlPaymentList {0};

                                      SELECT    SUM(Totall) as Totall ,SUM(ActuallyPay) as ActuallyPay
                                      FROM       V_TrademarkControlPaymentList   {0};
                ", string.IsNullOrEmpty(strWhere) ? "" : " where " + strWhere);

            Public.DLL dll = new LawtechPTSystemByFirm.Public.DLL();
            System.Data.DataSet dtFeeEvent = new System.Data.DataSet();
            dtFeeEvent = dll.SqlDataAdapterDataSet(strPatentFeeSQL);
            return dtFeeEvent;
        }
        #endregion

        private void PatentPaymentSearch_Load(object sender, EventArgs e)
        {
            Public.PublicForm Forms = new LawtechPTSystemByFirm.Public.PublicForm();
            Forms.TrademarkPaymentSearchList = this;
            
            //登入者
            iWorkerID = Properties.Settings.Default.WorkerKEY;
            Worker_Model worker = new Worker_Model();
            Worker_Model.ReadOne(iWorkerID, ref  worker);
            iOfficeRole = worker.OfficeRole.Value;//角色的權限
           
            bSource_Control = new BindingSource();
            dgViewMF.DataSource = bSource_Control;
            bindingNavigator1.BindingSource = bSource_Control;

            //but_Search_Click(null, null);
        }

        #region private void PatentPaymentSearch_FormClosed(object sender, FormClosedEventArgs e)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PatentPaymentSearch_FormClosed(object sender, FormClosedEventArgs e)
        {
            Public.PublicForm Forms = new LawtechPTSystemByFirm.Public.PublicForm();
            Forms.TrademarkPaymentSearchList = null;
        } 
        #endregion

        private void dgViewMF_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgViewMF.CurrentRow != null)
            {
                PatentHistoryRecord1 patent = new LawtechPTSystemByFirm.SubFrom.PatentHistoryRecord1();
                patent.property_PatentID = (int)dgViewMF.CurrentRow.Cells["TrademarkID"].Value;
                patent.TabSelectedIndex =3;
                patent.Show();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dgViewMF_CellDoubleClick(null,null);
        }

        private void dgViewMF_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = false;
        }

       

      

    }
}
