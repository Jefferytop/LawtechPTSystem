using H3Operator.DBHelper;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace LawtechPTSystemByFirm.SubFrom
{
    /// <summary>
    ///  設定GridColumn
    /// </summary>
    public partial class SetGridColumnT : Form
    {
        UserPermissionForm myPermission;
        private const string strProgramSymbol = "SetGridColumnT";
        private const string SourceTableName = "GridColumnT";

        public SetGridColumnT()
        {
            InitializeComponent();
            //Public.DynamicGridViewColumn.GetGridColum(ref DataGridView_GridColumn);
        }

        private DataTable dt_GridSymboID = new DataTable();
        /// <summary>
        /// PatentManagement 資料集
        /// </summary>
        public DataTable DT_GridSymboID
        {
            get
            {
                return dt_GridSymboID;
            }

        }

        private DataTable dt_GridColumnT = new DataTable();
        /// <summary>
        /// 
        /// </summary>
        public DataTable DT_GridColumnT
        {
            get { return dt_GridColumnT; }
        }

        /// <summary>
        /// 目前所指定的GridSymboID
        /// </summary>
        public string CurrentGridSymboID
        {
            get;
            set;
        }

        #region private void PATFeatureMF_Load(object sender, EventArgs e)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PATFeatureMF_Load(object sender, EventArgs e)
        {
           
            //取得權限
            //myPermission = new UserPermissionForm(Properties.Settings.Default.WorkerKEY, strProgramSymbol);

            //System.Windows.Forms.BindingNavigator[] listbinding = { bindingNavigator1 };
            //System.Windows.Forms.ContextMenuStrip[] listtMenu = { contextMenuStrip1 };

            //確認可使用的功能選單
            //Public.CommonFunctions.CheckMeunItemVisible(listbinding, myPermission.UserPermission);
            //Public.CommonFunctions.CheckMeunItemVisible(listtMenu, myPermission.UserPermission);

            GetGridSymboID();
            comboBox_GridColumn.DisplayMember = "GridSymboID";
            comboBox_GridColumn.ValueMember = "GridSymboID";
            comboBox_GridColumn.DataSource = dt_GridSymboID;

            if (comboBox_GridColumn.SelectedValue.ToString() != CurrentGridSymboID)
            {
                comboBox_GridColumn.SelectedValue = CurrentGridSymboID;
            }

            SetDataGridView_GridColumn();
            if (!string.IsNullOrEmpty(CurrentGridSymboID))
            {
                comboBox_GridColumn.Visible = false;
                toolStripButton_Delete.Visible = false;
                DelToolStripMenuItem.Visible = false;
            }

            
            GridColumnTBindingSource.DataSource = dt_GridColumnT;

            dt_GridColumnT.ColumnChanged += new DataColumnChangeEventHandler(DT_GridColumnT_ColumnChanged);
        } 
        #endregion

        #region GetGridColumnT()
        /// <summary>
        /// 
        /// </summary>
        public void GetGridColumnT()
        {
            dt_GridColumnT.Rows.Clear();
            string strSQL = string.Format(@"SELECT *  from  GridColumnT where GridSymboID='{0}' and IsPublic<>'False'  order by Sort", comboBox_GridColumn.SelectedValue.ToString());

            DBAccess dbhelper = new DBAccess();
            dt_GridColumnT.Rows.Clear();
            dbhelper.QueryToDataTableByDataAdapter(strSQL, ref dt_GridColumnT);

            if (dt_GridColumnT.PrimaryKey.Length == 0)
            {
                DataColumn[] pk = { dt_GridColumnT.Columns["GridColumnKey"] };
                dt_GridColumnT.PrimaryKey = pk;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void GetGridSymboID()
        {
            string strSQL = string.Format(@"SELECT Distinct GridSymboID from  GridColumnT ");

            DBAccess dbhelper = new DBAccess();
            DT_GridSymboID.Rows.Clear();
            dbhelper.QueryToDataTableByDataAdapter(strSQL, ref dt_GridSymboID);

            if (DT_GridSymboID.PrimaryKey.Length == 0)
            {
                DataColumn[] pk = { DT_GridSymboID.Columns["GridSymboID"] };
                DT_GridSymboID.PrimaryKey = pk;
            }
        } 
        #endregion

        public void SetDataGridView_GridColumn()
        {
            if (!string.IsNullOrEmpty(CurrentGridSymboID))
            {
                foreach (DataGridViewColumn item in DataGridView_GridColumn.Columns)
                {
                    if (item.ToolTipText == "")
                    {
                        item.Visible = false;
                    }
                }
            }

          
        }

        #region 關閉按鈕 private void button2_Click(object sender, EventArgs e)
        /// <summary>
        /// 關閉按鈕
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        } 
        #endregion

        #region 表單關閉事件 private void PATFeatureMF_FormClosed(object sender, FormClosedEventArgs e)
        /// <summary>
        /// 表單關閉事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PATFeatureMF_FormClosed(object sender, FormClosedEventArgs e)
        {
            Public.PublicForm Forms = new LawtechPTSystemByFirm.Public.PublicForm();
            Forms.PATFeatureMF = null;
        } 
        #endregion

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
              
                case "toolStripButton_Delete":
                case "DelToolStripMenuItem":
                    if (DataGridView_GridColumn.CurrentRow != null)
                    {
                        string sName = DataGridView_GridColumn.CurrentRow.Cells["GridColumnName"].Value.ToString();
                        if (MessageBox.Show("是否確定刪除--" + sName, "確認視窗", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                        {
                            int iKey = (int)DataGridView_GridColumn.CurrentRow.Cells["GridColumnKey"].Value;
                            Public.CGridColumn gc = new Public.CGridColumn();
                            gc.Delete(iKey);
                           
                            DataGridView_GridColumn.Rows.Remove(DataGridView_GridColumn.CurrentRow);
                            MessageBox.Show("刪除成功");
                        }
                    }
                    break;               
            }
        } 
        #endregion

        #region  =============DT_GridColumnT_ColumnChanged事件===============
        private void DT_GridColumnT_ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            if (e.Row.RowState == DataRowState.Unchanged)
            {

                Public.CGridColumn GC = new Public.CGridColumn();
                Public.CGridColumn.ReadOne(int.Parse(e.Row["GridColumnKey"].ToString()), ref GC);

                switch (e.Column.ColumnName)
                {
                    case "GridSymboID":
                        GC.GridSymboID = e.ProposedValue != null ? e.ProposedValue.ToString() : "";
                        break;
                    case "GridColumnType":
                        short iGridColumnType = 1;
                        bool isGridColumnType = short.TryParse(e.ProposedValue.ToString(), out  iGridColumnType);                       
                            GC.GridColumnType = iGridColumnType;                       
                        break;
                    case "GridColumnName":
                        GC.GridColumnName = e.ProposedValue != null ? e.ProposedValue.ToString() : "";
                        break;
                    case "DataPropertyName":
                        GC.DataPropertyName = e.ProposedValue != null ? e.ProposedValue.ToString() : "";
                        break;
                    case "HeaderText":
                        GC.HeaderText = e.ProposedValue != null ? e.ProposedValue.ToString() : "";
                        break;
                    case "ToolTipText":
                        GC.ToolTipText = e.ProposedValue != null ? e.ProposedValue.ToString() : "";
                        break;
                    case "Sort":
                        int iSort = 0;
                        bool isOkSort = int.TryParse(e.ProposedValue.ToString(), out  iSort);
                        if (isOkSort)
                        {
                            GC.Sort = e.ProposedValue != DBNull.Value ? (int)e.ProposedValue : (int)80;
                        }
                        else
                        {
                            GC.Sort = null;
                        }

                        break;
                    case "Visible":
                        GC.Visible = e.ProposedValue != DBNull.Value ? (bool)e.ProposedValue : false;
                        break;
                    case "Alignment":
                        if (e.ProposedValue.ToString() == "MiddleCenter" || e.ProposedValue.ToString() == "MiddleRight" || e.ProposedValue.ToString() == "MiddleLeft")
                        {
                            GC.Alignment = e.ProposedValue != null ? e.ProposedValue.ToString() : null;
                        }
                        else
                        {
                            GC.Alignment = null;
                        }
                        break;
                    case "Width":
                        short width = 60;
                        bool isOk = short.TryParse(e.ProposedValue.ToString(), out  width);
                        if (isOk)
                        {
                            GC.Width = e.ProposedValue != DBNull.Value ? (short)e.ProposedValue : (short)60;
                        }
                        else
                        {
                            GC.Width = null;
                        }
                        break;
                    case "ForeColor":
                        try
                        {
                            Color test = ColorTranslator.FromHtml(e.ProposedValue.ToString());
                            GC.ForeColor = e.ProposedValue != null ? e.ProposedValue.ToString() : "";
                        }
                        catch
                        {
                            GC.ForeColor = null;
                        }
                        break;
                    case "BackColor":
                        try
                        {
                            Color test = ColorTranslator.FromHtml(e.ProposedValue.ToString());
                            GC.BackColor = e.ProposedValue != null ? e.ProposedValue.ToString() : "";
                        }
                        catch
                        {
                            GC.BackColor = null;
                        }
                        break;
                }
                GC.Update();
                e.Row.AcceptChanges();
            }
        }
        #endregion

        private void comboBox_GridColumn_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_GridColumn.SelectedValue.ToString()!="")
            {
                GetGridColumnT();               
            }
        }

        private void DataGridView_GridColumn_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            int i = e.ColumnIndex;
            int r = e.RowIndex;
            e.Cancel = false;
        }

        #region 刷新按鈕  private void btn_Refresh_Click(object sender, EventArgs e)
        /// <summary>
        /// 刷新按鈕
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            comboBox_GridColumn_SelectedIndexChanged(null, null);
        } 
        #endregion
    }
}