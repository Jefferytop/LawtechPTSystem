using System;
using System.Data;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LawtechPTSystem.SubFrom
{
    /// <summary>
    /// 商標案件查詢統計
    /// </summary>
    public partial class TrademarkStatistics : Form
    {

        string strSearhSQL = " select TrademarkID from TrademarkManagementT ";
        public string SeachSQL
        {
            get
            {
                return strSearhSQL;
            }
            set { strSearhSQL = value; }
        }

        public TrademarkStatistics()
        {
            InitializeComponent();
            trademarkManagementTDataGridView.AutoGenerateColumns = false;
            Public.DynamicGridViewColumn.GetGridColum(ref trademarkManagementTDataGridView);
        }

        private void but_Close_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        #region TrademarkStatistics_Load  TrademarkStatistics_FormClosed
        private void TrademarkStatistics_Load(object sender, EventArgs e)
        {              
            Public.PublicForm Forms = new Public.PublicForm();
            Forms.TrademarkStatistics = this;

            this.trademarkStyleTTableAdapter.Fill(this.dataSet_Drop.TrademarkStyleT);
            DataRow drStyle = this.dataSet_Drop.TrademarkStyleT.NewRow();
            drStyle["StyleName"] = " ";
            drStyle["TMStyleID"] = -1;
            this.dataSet_Drop.TrademarkStyleT.Rows.InsertAt(drStyle,0);
            comboBox_Style.SelectedIndex = 0;

            this.tMStatusTTableAdapter.Fill(this.dataSet_Drop.TMStatusT);
            DataRow drStatus = this.dataSet_Drop.TMStatusT.NewRow();
            drStatus["Status"] = " ";
            drStatus["TMStatusID"] = -1;
            this.dataSet_Drop.TMStatusT.Rows.InsertAt(drStatus, 0);
            comboBox_Status.SelectedIndex = 0;


            this.trademarkTypeTTableAdapter.Fill(this.dataSet_Drop.TrademarkTypeT);
            DataRow drType = this.dataSet_Drop.TrademarkTypeT.NewRow();
            drType["TMTypeName"] = "";
            drType["TMTypeID"] = -1;
            this.dataSet_Drop.TrademarkTypeT.Rows.InsertAt(drType, 0);
            comboBox_Type.SelectedIndex = 0;

            this.countryT_DropTableAdapter.Fill(this.qS_DataSet.CountryT_Drop);
            DataRow drCountry = this.qS_DataSet.CountryT_Drop.NewRow();
            drCountry["Country"] = " ";
            drCountry["CountrySymbol"] = "All";
            this.qS_DataSet.CountryT_Drop.Rows.InsertAt(drCountry, 0);

            comboBox_Country.SelectedIndex = 0;
                   

            
        }

        private void TrademarkStatistics_FormClosed(object sender, FormClosedEventArgs e)
        {
            Public.PublicForm Forms = new Public.PublicForm();
            Forms.TrademarkStatistics = null;
        }
        #endregion

        private void but_FileDetail_Click(object sender, EventArgs e)
        {
            if (trademarkManagementTDataGridView.CurrentRow!=null)
            {
                TrademarkHistoryRecord history = new TrademarkHistoryRecord();
                history.TrademarkID = (int)trademarkManagementTDataGridView.CurrentRow.Cells["TrademarkID"].Value;
                history.Show();
            }
        }

        private void but_ClearSearch_Click(object sender, EventArgs e)
        {
           
            comboBox_Country.SelectedIndex = 0;
            comboBox_Style.SelectedIndex = 0;
            comboBox_Type.SelectedIndex = 0;
            comboBox_Status.SelectedIndex = 0;
            QueryFilter1.ComboBoxSearchColumn.SelectedIndex = 0;
            QueryFilter2.ComboBoxSearchColumn.SelectedIndex = 0;
            userControlFilterDate1.MaskedStartDate.Text = "";
            userControlFilterDate1.MaskedEndDate.Text = "";
        } 

        private void but_Excel_Click(object sender, EventArgs e)
        {
            try
            {
                Public.DLL dll = new Public.DLL();
                Task t = dll.WriteToCSV(trademarkManagementTDataGridView);
            }
            catch
            {
                MessageBox.Show("匯出CSV失敗");
            }
        }

        private void but_Search_Click(object sender, EventArgs e)
        {
            but_Search.Enabled = false;
            string strSQL = Public.CommonFunctions.GetSQLScript(QueryFilter1, QueryFilter2, rb_and.Checked ? " and " : " or ", userControlFilterDate1);

            Public.DLL dll = new Public.DLL();

            string strFilter = "";

            string strCountry = "";
            //國別
            if (comboBox_Country.Text.Trim() != "" && comboBox_Country.SelectedValue != null)
            {
                strCountry = " CountrySymbol='" + comboBox_Country.SelectedValue.ToString() + "'";
            }

            string strStatus = "";
            //案件狀態
            if (comboBox_Status.Text.Trim() != "")
            {
                strStatus = "TMStatusID=" + comboBox_Status.SelectedValue.ToString();
            }

            string strStyle = "";
            //商標樣式
            if (comboBox_Style.Text.Trim() != "")
            {
                strStyle = "StyleName='" + comboBox_Style.Text.ToString() + "' ";
            }

            string strTMTypeName = "";
            //案件類別
            if (comboBox_Type.Text.Trim() != "")
            {
                strTMTypeName = "TMTypeName='" + comboBox_Type.Text.ToString() + "' ";
            }


            string[] sWhere = { strSQL, strFilter, strCountry, strStyle, strTMTypeName, strStatus };

            StringBuilder FullWhere = new StringBuilder();
            for (int iArray = 0; iArray < sWhere.Length; iArray++)
            {
                if (sWhere[iArray].Trim() != "")
                {
                    if (FullWhere.Length > 0)
                    {
                        FullWhere.Append(" and ");
                    }
                    FullWhere.Append(sWhere[iArray]);
                }
            }
           
            string strSQLFullWhere = "";
            strSQLFullWhere = FullWhere.ToString() == "" ? "SELECT *  from V_TrademarkList with(nolock)" : " SELECT *  from V_TrademarkList with(nolock) where " + FullWhere.ToString();
            DataTable dt = dll.SqlDataAdapterDataTable(strSQLFullWhere);

            trademarkManagementTBindingSource.DataSource = dt;

            but_Search.Enabled = true;
        }

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

        private void but_All_Click(object sender, EventArgs e)
        {
            but_ClearSearch_Click(null, null);
            //this.trademarkManagementTTableAdapter.Fill(this.dataSet_TM.TrademarkManagementT);
            but_Search_Click(null,null);
        }

        private void trademarkManagementTDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != -1 && e.RowIndex != -1)
            {
                but_FileDetail_Click(null, null);
            }
        }

        private void but_Statistic_Click(object sender, EventArgs e)
        {
            if (trademarkManagementTDataGridView.Rows.Count > 0)
            {
                TrademarkAnalysis Analysis = new LawtechPTSystem.SubFrom.TrademarkAnalysis();
                Analysis.SearchTrademarkID = strSearhSQL;
                Analysis.ShowDialog();
            }
            else
            {
                MessageBox.Show("目前符合條件筆數為0\r\n請重新查詢", "提示訊息");
            }
        }

        private void but_FeeStatistics_Click(object sender, EventArgs e)
        {
            if (trademarkManagementTDataGridView.Rows.Count > 0)
            {
                TrademarkFeeStatistics FeeAnalysis = new LawtechPTSystem.SubFrom.TrademarkFeeStatistics();
                FeeAnalysis.SearchTrademarkID = strSearhSQL;
                FeeAnalysis.ShowDialog();
            }
            else
            {
                MessageBox.Show("目前符合條件筆數為0\r\n請重新查詢", "提示訊息");
            }
        }

        private void but_CompleteHistory_Click(object sender, EventArgs e)
        {
            if (trademarkManagementTDataGridView.CurrentRow!=null)
            {
                ViewFrom.TrademarkCompleteHistory history = new LawtechPTSystem.ViewFrom.TrademarkCompleteHistory();
                history.Gv = trademarkManagementTDataGridView;
                history.Show();
            }
        }

        #region private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            contextMenuStrip1.Visible = false;
            switch (e.ClickedItem.Name)
            {
                case "ToolStripMenuItem_PatentView"://申請案詳細資料
                    but_FileDetail_Click(null, null);
                    break;
                case "toolStripButton_Export":
                case "ToolStripMenuItem_ExportCSV":
                    try
                    {
                        Public.DLL dll = new Public.DLL();
                        Task task = dll.WriteToCSV(trademarkManagementTDataGridView);
                    }
                    catch
                    {
                        MessageBox.Show("匯出CSV失敗");
                    }
                    break;
                case "toolStripButton_OpenFile":
                case "toolStripLabel_UpdateFileList":
                    if (trademarkManagementTDataGridView.CurrentRow != null)
                    {
                        ViewUpdateFileList subForm = new ViewUpdateFileList();
                        subForm.Text = trademarkManagementTDataGridView.CurrentRow.Cells["TrademarkNo"].Value.ToString() + "的相關文件";
                        subForm.FileKind =4;
                        subForm.FileType = 0;
                        subForm.MainParentID = (int)trademarkManagementTDataGridView.CurrentRow.Cells["TrademarkID"].Value;
                        subForm.radoC.Checked = true;
                        subForm.ShowDialog();
                    }
                    break;
                case "toolStripButton_CompleteHistory":                    
                case "ToolStripMenuItem_CompleteHistory":
                    but_CompleteHistory_Click(null,null);
                    break;
                case "toolStripMenuItem_SetGridColumn":
                    SetGridColumnT gc = new SetGridColumnT();
                    gc.CurrentGridSymboID = trademarkManagementTDataGridView.Tag.ToString();
                    gc.TitleName = "商標案件查詢統計";
                    gc.Show();
                    break;
                case "ToolStripMenuItem_OpenFile":
                    if (trademarkManagementTDataGridView.CurrentRow != null)
                    {
                        ViewUpdateFileList subForm = new ViewUpdateFileList();
                        subForm.Text = trademarkManagementTDataGridView.CurrentRow.Cells["TrademarkNo"].Value.ToString() + "的相關文件";
                        subForm.FileKind = 4;
                        subForm.FileType = 6;
                        subForm.MainParentID = (int)trademarkManagementTDataGridView.CurrentRow.Cells["TrademarkID"].Value;
                        subForm.vb_TM.Checked = true;
                        subForm.ShowDialog();
                    }
                    break;
              
            }
        }
        #endregion

     
    }
}
