using System;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LawtechPTSystem.SubFrom
{
    /// <summary>
    /// 申請案事件查詢統計
    /// </summary>
    public partial class PatentEventList : Form
    {
        UserPermissionForm myPermission;
        private const string ProgramSymbol = "PatentEventList";
        private const string SourceTableName = "V_PatentEventList";

        private DataTable dt_PatentEventList;
        /// <summary>
        /// 專利事件列表
        /// </summary>
        public DataTable DT_PatentEventList
        {
            get { return dt_PatentEventList; }
            set { dt_PatentEventList = value; }
        }

        /// <summary>
        /// 權限 0.最高權限 1.指定權限 2.專利  3.商標 4.會計經理
        /// </summary>
        public int OfficeRole
        {
            get { return Properties.Settings.Default.OfficeRole; }
        }
        public PatentEventList()
        {
            InitializeComponent();
            GridView_PatentEventList.AutoGenerateColumns = false;

            Public.DynamicGridViewColumn.GetGridColum(ref GridView_PatentEventList);
        }

        #region private void PatentEventList_Load(object sender, EventArgs e)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PatentEventList_Load(object sender, EventArgs e)
        {
            Public.PublicForm Forms = new Public.PublicForm();
            Forms.PatentEventList = this;


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
        #endregion

        #region =========取得專利事件資料==========
        /// <summary>
        /// 取得專利事件資料
        /// </summary>
        /// <returns></returns>
        public DataSet GetPatentEventList()
        {
            string strSQLWhere = Public.CommonFunctions.GetSQLScript(QueryFilter1, QueryFilter2, Radio_and.Checked ? " and " : " or ", userControlFilterDate1);
            Public.DLL dll = new Public.DLL();
            string sql = string.Format(@"SELECT   * from  V_PatentEventList with(nolock) {0} ;
           SELECT   sum(FeeOtherTotalFee) as FeeOtherTotalFee,sum(OAttorneyGovFee) as FeeSUM_OAttorneyGovFee, sum(FeeSUM_TotalNT) as FeeSUM_TotalNT,sum(FeeSUM_PracticalityPay) as FeeSUM_PracticalityPay,sum(PaymentSUM_Totall) as  PaymentSUM_Totall,sum(PaymentSUM_ActuallyPay) as  PaymentSUM_ActuallyPay,sum(EventProfit) as EventProfitTotalFee from  V_PatentEventList with(nolock) {0} ", strSQLWhere.Trim() != "" ? " where " + strSQLWhere : "");
            DataSet dt = dll.SqlDataAdapterDataSet(sql);
            //if (dt.Tables[0].PrimaryKey.Length == 0)
            //{
            //    dt.Tables[0].PrimaryKey = new DataColumn[2] { dt.Tables[0].Columns["PatComitEventID"], dt.Tables[0].Columns["FeeKey"] };
            //}
            return dt;
        }
        #endregion

        #region 查詢按鈕 private void button_Search_Click(object sender, EventArgs e)
        /// <summary>
        /// 查詢按鈕
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Search_Click(object sender, EventArgs e)
        {
            button_Search.Enabled = false;
            if (dt_PatentEventList != null && dt_PatentEventList.Rows.Count > 0)
            {
                dt_PatentEventList.Rows.Clear();
            }
            DataSet ds = GetPatentEventList();
            if (ds.Tables.Count == 2 && ds.Tables[1].Rows.Count == 1)
            {
                dt_PatentEventList = ds.Tables[0];
                bs_PatentEventList.DataSource = dt_PatentEventList;
                             

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

                //事件利潤合計
                decimal deOtherTotalFeeT;
                bool isOtherTotalFeeT = decimal.TryParse(ds.Tables[1].Rows[0]["EventProfitTotalFee"].ToString(), out deOtherTotalFeeT);
                toolStripLabel_EventProfitTotal.Text = deOtherTotalFeeT.ToString("#,##0.##");
            }

            button_Search.Enabled = true;
        } 
        #endregion       

        private void but_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PatentEventList_FormClosed(object sender, FormClosedEventArgs e)
        {
            Public.PublicForm Forms = new Public.PublicForm();
            Forms.PatentEventList = null;
        }

        private void btnOpenDetail_Click(object sender, EventArgs e)
        {
            if (!splitContainer1.Panel2Collapsed)
            {
                btnOpenDetail.Text = "開啟明細";

                splitContainer1.Panel2Collapsed = true;
            }
            else
            {
                btnOpenDetail.Text = "關閉明細";
                splitContainer1.Panel2Collapsed = false;
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
                        if (OfficeRole != 1)//最高權限、主管權限
                        {
                            PatentHistoryRecord1 patent = new SubFrom.PatentHistoryRecord1();
                            patent.property_PatentID = (int)GridView_PatentEventList.CurrentRow.Cells["PatentID"].Value;
                            patent.TabSelectedIndex = 1;
                            patent.Show();
                        }
                        else {
                            //一般權限
                            PatentHistoryRecord_Event patent = new PatentHistoryRecord_Event();
                            patent.property_PatentID = (int)GridView_PatentEventList.CurrentRow.Cells["PatentID"].Value;

                            patent.TabSelectedIndex = 1;
                            patent.Show();
                        }
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
                        subForm.Text = GridView_PatentEventList.CurrentRow.Cells["PatentNo"].Value.ToString() + "的相關文件";
                        subForm.FileKind = 3;
                        subForm.FileType = 0;
                        subForm.MainParentID = (int)GridView_PatentEventList.CurrentRow.Cells["PatentID"].Value;
                        subForm.radoC.Checked = true;
                        subForm.ShowDialog();
                    }
                    break;
                case "toolStripButton_CompleteHistory":
                case "toolStripMenuItem_CompleteHistory":
                    if (GridView_PatentEventList.SelectedRows.Count > 0)
                    {
                        ViewFrom.PatentCompleteHistory history = new ViewFrom.PatentCompleteHistory();
                        history.Gv = GridView_PatentEventList;
                        history.Show();
                    }
                    break;
                case "toolStripMenuItem_SetGridColumn":
                    SetGridColumnT gc = new SetGridColumnT();
                    gc.CurrentGridSymboID = GridView_PatentEventList.Tag.ToString();
                    gc.TitleName = "專利申請案事件列表";
                    gc.Show();
                    break;
                case "ToolStripMenuItem_OpenFile":
                    if (GridView_PatentEventList.CurrentRow != null)
                    {
                        ViewUpdateFileList subForm = new ViewUpdateFileList();
                        subForm.Text = GridView_PatentEventList.CurrentRow.Cells["PatentNo"].Value.ToString() + "的申請案相關文件";
                        subForm.FileKind = 3;
                        subForm.FileType = 1;
                        subForm.MainParentID = (int)GridView_PatentEventList.CurrentRow.Cells["PatentID"].Value;
                        subForm.ShowDialog();
                    }
                    break;
            }
        }

        private void GridView_PatentEventList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != -1 && e.RowIndex != -1)
            {
                contextMenuStrip1_ItemClicked(contextMenuStrip1, new ToolStripItemClickedEventArgs(contextMenuStrip1.Items["ToolStripMenuItem_PatentView"]));
            }
        }
    }
}
