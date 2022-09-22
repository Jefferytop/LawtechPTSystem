using System;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LawtechPTSystem.SubFrom
{
    /// <summary>
    /// 商標事件績效表
    /// </summary>
    public partial class TrademarkEventList : Form
    {
        UserPermissionForm myPermission;
        private const string ProgramSymbol = "TrademarkEventList";
        private const string SourceTableName = "V_TrademarkEventList";

        private DataTable dt_TrademarkEventList;
        /// <summary>
        /// 商標事件列表
        /// </summary>
        public DataTable DT_TrademarkEventList
        {
            get { return dt_TrademarkEventList; }
            set { dt_TrademarkEventList = value; }
        }

        public TrademarkEventList()
        {
            InitializeComponent();

            GridView_PatentEventList.AutoGenerateColumns = false;
            Public.DynamicGridViewColumn.GetGridColum(ref GridView_PatentEventList);
        }

        private void TrademarkEventList_Load(object sender, EventArgs e)
        {
            Public.PublicForm Forms = new Public.PublicForm();
            Forms.TrademarkEventList = this;


            //取得權限
            myPermission = new UserPermissionForm(Properties.Settings.Default.WorkerKEY, ProgramSymbol);

            System.Windows.Forms.BindingNavigator[] listbinding = { bindingNavigator_App };
            System.Windows.Forms.ContextMenuStrip[] listtMenu = { contextMenuStrip1 };

            //確認可使用的功能選單
            Public.CommonFunctions.CheckMeunItemVisible(listbinding, myPermission.UserPermission);
            Public.CommonFunctions.CheckMeunItemVisible(listtMenu, myPermission.UserPermission);

            Public.Utility.SetLoadDataRange(userControlFilterDate1);

            if (Properties.Settings.Default.IsLoadData)
            {
                button_Search_Click(null, null);
            }
        }

        private void TrademarkEventList_FormClosed(object sender, FormClosedEventArgs e)
        {
            Public.PublicForm Forms = new Public.PublicForm();
            Forms.TrademarkEventList = null;
        }

        private void button_Search_Click(object sender, EventArgs e)
        {
            button_Search.Enabled = false;
            if (dt_TrademarkEventList != null && dt_TrademarkEventList.Rows.Count > 0)
            {
                dt_TrademarkEventList.Rows.Clear();
            }
            DataSet ds = GetTrademarkEventList();
            if (ds.Tables.Count == 2 && ds.Tables[1].Rows.Count == 1)
            {
                dt_TrademarkEventList = ds.Tables[0];
                bs_TrademarkEventList.DataSource = dt_TrademarkEventList;              

                decimal deOAttorneyGovFee;
                bool isOAttorneyGovFee = decimal.TryParse(ds.Tables[1].Rows[0]["FeeSUM_OAttorneyGovFee"].ToString(), out deOAttorneyGovFee);
                toolStripLabel_FeeSUM_OAttorneyGovFee.Text = deOAttorneyGovFee.ToString("#,##0.##");

                decimal deAllTotalNT;
                bool isTotalNT = decimal.TryParse(ds.Tables[1].Rows[0]["FeeSUM_TotalNT"].ToString(), out deAllTotalNT);
                toolStripLabel_FeeSUM_TotalNT.Text = deAllTotalNT.ToString("#,##0.##");

                decimal deOtherTotalFee;
                bool IsOtherTotalFee = decimal.TryParse(ds.Tables[1].Rows[0]["FeeSUM_PracticalityPay"].ToString(), out deOtherTotalFee);
                toolStripLabel_FeeSUM_PracticalityPay.Text = deOtherTotalFee.ToString("#,##0.##");

                decimal dePaymentSUM_Totall;
                bool isPaymentSUM_Totall = decimal.TryParse(ds.Tables[1].Rows[0]["PaymentSUM_Totall"].ToString(), out dePaymentSUM_Totall);
                toolStripLabel_PaymentSUM_Totall.Text = dePaymentSUM_Totall.ToString("#,##0.##");

                decimal dePaymentSUM_ActuallyPay;
                bool isPaymentSUM_ActuallyPay = decimal.TryParse(ds.Tables[1].Rows[0]["PaymentSUM_ActuallyPay"].ToString(), out dePaymentSUM_ActuallyPay);
                toolStripLabel_PaymentSUM_ActuallyPay.Text = dePaymentSUM_ActuallyPay.ToString("#,##0.##");

                //事件利潤
                decimal deOtherTotalFeeT;
                bool isOtherTotalFeeT = decimal.TryParse(ds.Tables[1].Rows[0]["EventProfitTotal"].ToString(), out deOtherTotalFeeT);
                toolStripLabel_EventProfitTotal.Text = deOtherTotalFeeT.ToString("#,##0.##");
            }

            button_Search.Enabled = true;
        }

        #region =========取得商標事件資料==========
        /// <summary>
        /// 取得商標事件資料
        /// </summary>
        /// <returns></returns>
        public DataSet GetTrademarkEventList()
        {
            string strSQLWhere = Public.CommonFunctions.GetSQLScript(QueryFilter1, QueryFilter2, Radio_and.Checked ? " and " : " or ", userControlFilterDate1);
            Public.DLL dll = new Public.DLL();
            string sql = string.Format(@"SELECT   * from  V_TrademarkEventList with(nolock) {0} ;
           SELECT   sum(FeeOtherTotalFee) as FeeOtherTotalFee,sum(OAttorneyGovFee) as FeeSUM_OAttorneyGovFee,sum(FeeSUM_TotalNT) as FeeSUM_TotalNT,sum(FeeSUM_PracticalityPay) as FeeSUM_PracticalityPay,sum(PaymentSUM_Totall) as  PaymentSUM_Totall,sum(PaymentSUM_ActuallyPay) as  PaymentSUM_ActuallyPay, sum(EventProfit) as EventProfitTotal from  V_TrademarkEventList with(nolock) {0} ", strSQLWhere.Trim() != "" ? " where " + strSQLWhere : "");
            DataSet dt = dll.SqlDataAdapterDataSet(sql);
            //if (dt.Tables[0].PrimaryKey.Length == 0)
            //{
            //    dt.Tables[0].PrimaryKey = new DataColumn[2] { dt.Tables[0].Columns["PatComitEventID"], dt.Tables[0].Columns["FeeKey"] };
            //}
            return dt;
        }
        #endregion

        private void but_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void GridView_PatentEventList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != -1 && e.RowIndex != -1)
            {
                contextMenuStrip1_ItemClicked(contextMenuStrip1, new ToolStripItemClickedEventArgs(contextMenuStrip1.Items["ToolStripMenuItem_PatentView"]));
            }
        }

        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            contextMenuStrip1.Visible = false;
            switch (e.ClickedItem.Name)
            {
                case "ToolStripMenuItem_PatentView":
                    if (GridView_PatentEventList.CurrentRow != null)
                    {
                        TrademarkHistoryRecord patent = new SubFrom.TrademarkHistoryRecord();
                        patent.TrademarkID = (int)GridView_PatentEventList.CurrentRow.Cells["TrademarkID"].Value;
                        patent.TabSelectedIndex = 1;
                        patent.Show();
                    }
                    break;
                case "toolStripButton_Export":
                case "ToolStripMenuItem_ExportCSV":
                    try
                    {
                        Public.DLL dll = new Public.DLL();
                        Task task = dll.WriteToCSV(GridView_PatentEventList);
                    }
                    catch
                    {
                        MessageBox.Show("匯出CSV失敗");
                    }
                    break;
                case "toolStripLabel_UpdateFileList":
                    if (GridView_PatentEventList.CurrentRow != null)
                    {
                        ViewUpdateFileList subForm = new ViewUpdateFileList();
                        subForm.Text = GridView_PatentEventList.CurrentRow.Cells["TrademarkNo"].Value.ToString() + "的相關文件";
                        subForm.FileKind = 3;
                        subForm.FileType = 0;
                        subForm.MainParentID = (int)GridView_PatentEventList.CurrentRow.Cells["TrademarkID"].Value;
                        subForm.radoC.Checked = true;
                        subForm.ShowDialog();
                    }
                    break;
                case "toolStripButton_CompleteHistory":
                case "ToolStripMenuItem_CompleteHistory":
                    if (GridView_PatentEventList.CurrentRow!=null)
                    {
                        ViewFrom.TrademarkCompleteHistory history = new ViewFrom.TrademarkCompleteHistory();
                        history.Gv = GridView_PatentEventList;
                        history.Show();
                    }
                    break;
                case "toolStripMenuItem_SetGridColumn":
                    SetGridColumnT gc = new SetGridColumnT();
                    gc.CurrentGridSymboID = GridView_PatentEventList.Tag.ToString();
                    gc.TitleName = "商標事件列表";
                    gc.Show();
                    break;
                case "ToolStripMenuItem_OpenFile":
                    if (GridView_PatentEventList.CurrentRow != null)
                    {
                        ViewUpdateFileList FileList = new ViewUpdateFileList();
                        FileList.Text = GridView_PatentEventList.CurrentRow.Cells["TrademarkNo"].Value.ToString() + "的相關文件";
                        FileList.FileKind = 4;
                        FileList.FileType = 6;
                        FileList.MainParentID = (int)GridView_PatentEventList.CurrentRow.Cells["TrademarkID"].Value;
                        FileList.vb_TM.Checked = true;
                        FileList.ShowDialog();
                    }
                    break;
            }
        }


    }
}
