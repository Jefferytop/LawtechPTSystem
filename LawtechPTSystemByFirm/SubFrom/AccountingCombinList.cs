using System;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LawtechPTSystemByFirm.SubFrom
{
    /// <summary>
    /// 應收應付總表
    /// </summary>
    public partial class AccountingCombinList : Form
    {
        public AccountingCombinList()
        {
            InitializeComponent();

            dgViewMF.AutoGenerateColumns = false;
            GridView_Fee.AutoGenerateColumns = false;
            GridView_Payment.AutoGenerateColumns = false;

            Public.DynamicGridViewColumn.GetGridColum(ref dgViewMF);
            Public.DynamicGridViewColumn.GetGridColum(ref GridView_Fee);
            Public.DynamicGridViewColumn.GetGridColum(ref GridView_Payment);
        }

        #region  ============property============
        /// <summary>
        /// 類型 PAT or TM
        /// </summary>
        public string PropertyType
        {
            get {
                if (radioButton_Patent.Checked)
                {
                    return "PAT";
                }
                else
                {
                    return "TM";
                }
            }
        }

        /// <summary>
        /// PatentID
        /// </summary>
        public int property_PatentID
        {
            get
            {
                if (PropertyType == "PAT")
                {
                    if (dgViewMF.CurrentRow != null)
                    {
                        return (int)dgViewMF.CurrentRow.Cells["PatentID"].Value;
                    }
                    else
                    {
                        return -1;
                    }
                }
                else
                {
                    if (dgViewMF.CurrentRow != null)
                    {
                        return (int)dgViewMF.CurrentRow.Cells["TrademarkID"].Value;
                    }
                    else
                    {
                        return -1;
                    }
                }
            }
        }

        /// <summary>
        /// 案件編號
        /// </summary>
        public string property_PatentNo
        {
            get
            {
                if (PropertyType == "PAT")
                {
                    if (dgViewMF.CurrentRow != null)
                    {
                        return dgViewMF.CurrentRow.Cells["PatentNo"].Value.ToString();
                    }
                    else
                    {
                        return "";
                    }
                }
                else
                {
                    if (dgViewMF.CurrentRow != null)
                    {
                        return dgViewMF.CurrentRow.Cells["TrademarkNo"].Value.ToString();
                    }
                    else
                    {
                        return "";
                    }
                }
            }
        }
        #endregion

        #region 資料表

        private DataTable dt_AccountingCombinList = new DataTable();
        /// <summary>
        /// V_AccountingCombinList_Patent 資料集
        /// </summary>
        public DataTable DT_AccountingCombinList
        {
            get
            {
                return dt_AccountingCombinList;
            }
        }

        private DataTable dt_PatentFeeT = new DataTable();
        /// <summary>
        /// PatentFeeT 請款費用
        /// </summary>
        public DataTable DT_PatentFeeT
        {
            get
            {
                return dt_PatentFeeT;
            }

        }

        private DataTable dt_PatentPaymentT = new DataTable();
        /// <summary>
        /// PatentFeeT 付款費用
        /// </summary>
        public DataTable DT_PatentPaymentT
        {
            get
            {
                return dt_PatentPaymentT;
            }

        } 
        #endregion

        #region  private void radioButton_Patent_CheckedChanged(object sender, EventArgs e)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButton_Patent_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rb = (RadioButton)sender;

            if (rb.Checked)
            {
                this.dgViewMF.SelectionChanged -= new System.EventHandler(this.GridView_File_SelectionChanged);
                if (rb.Tag != null)
                {
                    dt_AccountingCombinList.PrimaryKey = null;
                    dt_PatentFeeT.PrimaryKey = null;
                    dt_PatentPaymentT.PrimaryKey = null;
                    

                    if (rb.Tag.ToString() == "TM")
                    { 
                        dgViewMF.Tag = "AccountingCombinList_Trademark";
                        GridView_Fee.Tag = "TrademarkMF_Fee";
                        GridView_Payment.Tag = "TrademarkMF_Payment";

                        userControlFilterDate1.SearchType = "TrademarkMF";
                        QueryFilter1.SearchType = "TrademarkMF";
                        QueryFilter2.SearchType = "TrademarkMF";
                    }
                    else
                    {
                       
                        dgViewMF.Tag = "AccountingCombinList_Patent";
                        GridView_Fee.Tag = "PatListMF_Fee";
                        GridView_Payment.Tag = "PatListMF_Payment";

                        userControlFilterDate1.SearchType = "PatListMF";
                        QueryFilter1.SearchType = "PatentList";
                        QueryFilter2.SearchType = "PatentList";
                    }

                    Public.DynamicGridViewColumn.GetGridColum(ref dgViewMF);
                    Public.DynamicGridViewColumn.GetGridColum(ref GridView_Fee);
                    Public.DynamicGridViewColumn.GetGridColum(ref GridView_Payment);
                }

                but_Search_Click(null, null);
                this.dgViewMF.SelectionChanged += new System.EventHandler(this.GridView_File_SelectionChanged);
            }
        } 
        #endregion
         
        #region 匯出按鈕 private void but_Excel_Click(object sender, EventArgs e)
        /// <summary>
        /// 匯出按鈕
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        #region 查詢按鈕 private void but_Search_Click(object sender, EventArgs e)
        /// <summary>
        /// 查詢按鈕
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void but_Search_Click(object sender, EventArgs e)
        {
            but_Search.Enabled = false;

            string strSQL = Public.CommonFunctions.GetSQLScript(QueryFilter1, QueryFilter2, rb_and.Checked ? " and " : " or ", userControlFilterDate1);
            DataTable total = new DataTable();
            if (PropertyType == "PAT")
            {
                Public.CAccountingPublicFunction.GetAccountingCombinListPatent(strSQL, ref dt_AccountingCombinList);
                
                Public.CAccountingPublicFunction.GetAccountingCombinListPatentSUM(strSQL, ref total);
             
            }
            else
            {
                Public.CAccountingPublicFunction.GetAccountingCombinListTrademark(strSQL, ref dt_AccountingCombinList);

                Public.CAccountingPublicFunction.GetAccountingCombinListTrademarkSUM(strSQL, ref total);
            }

            if (total.Rows.Count == 1)
            {
                decimal fee = 0;
                bool isFee = decimal.TryParse(total.Rows[0]["TotalPracticalityFee"].ToString(), out fee);
                toolStripLabel_FeeTotal.Text = fee.ToString("#,##0.##");

                decimal Payment = 0;
                bool isPayment = decimal.TryParse(total.Rows[0]["TotalPracticalityPayment"].ToString(), out Payment);
                toolStripLabel_PaymentTotal.Text = Payment.ToString("#,##0.##");

                decimal Profit = 0;
                bool isProfit = decimal.TryParse(total.Rows[0]["TotalProfit"].ToString(), out Profit);
                toolStripLabel_ProfitTotal.Text = Profit.ToString("#,##0.##");
            }

            but_Search.Enabled = true;
        } 
        #endregion

        #region private void dgViewMF_DataError(object sender, DataGridViewDataErrorEventArgs e)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgViewMF_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = false;
        } 
        #endregion

        #region private void GridView_File_SelectionChanged(object sender, EventArgs e)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GridView_File_SelectionChanged(object sender, EventArgs e)
        {
            if (dgViewMF.CurrentRow != null)
            {
                if (PropertyType == "PAT")
                {
                    Public.CPatentPublicFunction.GetPatentkFee(property_PatentID.ToString(), ref dt_PatentFeeT);
                    Public.CPatentPublicFunction.GetPatentPayment(property_PatentID.ToString(), ref dt_PatentPaymentT);
                }
                else
                {
                    Public.CTrademarkPublicFunction.GetTrademarkFee(property_PatentID.ToString(), ref dt_PatentFeeT);
                    Public.CTrademarkPublicFunction.GetTrademarkPayment(property_PatentID.ToString(), ref dt_PatentPaymentT);
                }
            }
            else
            {
                dt_PatentFeeT.Rows.Clear();
                dt_PatentPaymentT.Rows.Clear();
            }
        } 
        #endregion

        #region ==============AccountingCombinList_Load 、 AccountingCombinList_FormClosed==============
        private void AccountingCombinList_Load(object sender, EventArgs e)
        {
            Public.PublicForm Forms = new LawtechPTSystemByFirm.Public.PublicForm();
            Forms.AccountingCombinList = this;

            Public.Utility.SetLoadDataRange(userControlFilterDate1);

            SetBindingSource();
            if (Properties.Settings.Default.IsLoadData)
            {
                but_Search_Click(null, null);
            }

            this.dgViewMF.SelectionChanged += new System.EventHandler(this.GridView_File_SelectionChanged);

            GridView_File_SelectionChanged(null, null);       

        }

        private void AccountingCombinList_FormClosed(object sender, FormClosedEventArgs e)
        {
            Public.PublicForm Forms = new LawtechPTSystemByFirm.Public.PublicForm();
            Forms.AccountingCombinList = null;
        }
        #endregion

        #region 設定BindingSource的來源 private void SetBindingSource()
        /// <summary>
        /// 設定BindingSource的來源
        /// </summary>
        private void SetBindingSource()
        {
            if (dt_AccountingCombinList.Columns.Count == 0)
            {
                Public.CAccountingPublicFunction.GetAccountingCombinListPatent("1=0", ref dt_AccountingCombinList);
            }
            vAccountingCombinListBindingSource.DataSource = dt_AccountingCombinList;           

            if (dt_PatentFeeT.Columns.Count == 0)
            {
                Public.CPatentPublicFunction.GetPatentkFee("0", ref dt_PatentFeeT);
            }
            patentFeeTBindingSource.DataSource = dt_PatentFeeT;

            if (dt_PatentPaymentT.Columns.Count == 0)
            {
                Public.CPatentPublicFunction.GetPatentPayment("0", ref dt_PatentPaymentT);
            }
            patentPaymentTBindingSource.DataSource = dt_PatentPaymentT;
        }
        #endregion

        #region  private void but_ShowDetail_Click(object sender, EventArgs e)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void but_ShowDetail_Click(object sender, EventArgs e)
        {
            if (!splitContainer1.Panel2Collapsed)
            {
                but_ShowDetail.Text = "開啟應收應付明細(Alt+E)";

                splitContainer1.Panel2Collapsed = true;
            }
            else
            {
                but_ShowDetail.Text = "關閉應收應付明細(Alt+E)";

                splitContainer1.Panel2Collapsed = false;
            }
        } 
        #endregion

        #region 關閉按鈕 private void but_Close_Click(object sender, EventArgs e)
        /// <summary>
        /// 關閉按鈕
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void but_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        } 
        #endregion

        #region 快顯功能表 private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        /// <summary>
        /// 快顯功能表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            contextMenuStrip1.Visible = false;
            switch (e.ClickedItem.Name)
            {
                case "toolStripMenuItem_SetGridColumn":
                    SetGridColumnT gc = new SetGridColumnT();
                    gc.CurrentGridSymboID = dgViewMF.Tag.ToString();
                    gc.Show();
                    break;
                case "toolStripButton_CaseDetail":
                case "toolStripMenuItem_CaseDetail": //案件詳細資料
                    if (dgViewMF.CurrentRow != null)
                    {
                        if (PropertyType == "PAT")
                        {
                            PatentHistoryRecord1 patent = new LawtechPTSystemByFirm.SubFrom.PatentHistoryRecord1();
                            patent.property_PatentID = (int)dgViewMF.CurrentRow.Cells["PatentID"].Value;
                            patent.TabSelectedIndex = 0;
                            patent.Show();
                        }
                        else
                        {
                            TrademarkHistoryRecord HistoryRecord = new TrademarkHistoryRecord();
                            HistoryRecord.TrademarkID = (int)dgViewMF.CurrentRow.Cells["TrademarkID"].Value;
                            HistoryRecord.TabSelectedIndex = 0;
                            HistoryRecord.Show();
                        }
                    }
                    break;
                case "toolStripMenuItem_CompleteHistory"://案件完整歷程
                    if (dgViewMF.CurrentRow != null)
                    {
                        if (PropertyType == "PAT")
                        {
                            ViewFrom.PatentCompleteHistory history = new LawtechPTSystemByFirm.ViewFrom.PatentCompleteHistory();
                            history.Gv = dgViewMF;
                            history.Show();
                        }
                        else
                        {
                            ViewFrom.TrademarkCompleteHistory history = new LawtechPTSystemByFirm.ViewFrom.TrademarkCompleteHistory();
                            history.Gv = dgViewMF;
                            history.Show();
                        }
                    }
                    break;
            }
        }
        
        #endregion

        #region toolStripButton1_Click
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            //ToolStripButton toolbut = (ToolStripButton)sender;

            if (splitContainer2.Orientation == Orientation.Horizontal)
            {
                splitContainer2.Orientation = Orientation.Vertical;

                if (splitContainer2.Size.Width > 50)
                {
                    int iWidth = splitContainer2.Size.Width / 2;
                    splitContainer2.SplitterDistance = iWidth;
                }

                toolStripButton1.Text = "水平畫面";
                toolStripButton1.Image = global::LawtechPTSystemByFirm.Properties.Resources.horizontal;

                toolStripButton2.Text = "水平畫面";
                toolStripButton2.Image = global::LawtechPTSystemByFirm.Properties.Resources.horizontal;
            }
            else
            {
                if (splitContainer2.Size.Height > 50)
                {
                    int iHeight = splitContainer2.Size.Height / 2;
                    splitContainer2.SplitterDistance = iHeight;
                }

                splitContainer2.Orientation = Orientation.Horizontal;
                toolStripButton1.Text = "垂直畫面";
                toolStripButton1.Image = global::LawtechPTSystemByFirm.Properties.Resources.Vertical;

                toolStripButton2.Text = "垂直畫面";
                toolStripButton2.Image = global::LawtechPTSystemByFirm.Properties.Resources.Vertical;
            }
        }
        #endregion


    }
}
