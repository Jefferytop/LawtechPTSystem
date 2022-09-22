using System;
using System.Windows.Forms;

namespace LawtechPTSystemByFirm.SubFrom
{
    /// <summary>
    ///  事務所查詢(複代)
    /// </summary>
    public partial class AttorneySearchMF : Form
    {
        /// <summary>
        /// 事務所查詢(複代)
        /// </summary>
        public AttorneySearchMF()
        {
            InitializeComponent();
            GridView_Attorney.AutoGenerateColumns = false;
            GridView_AttLiaisoner.AutoGenerateColumns = false;

            Public.DynamicGridViewColumn.GetGridColum(ref GridView_Attorney);

            Public.DynamicGridViewColumn.GetGridColum(ref GridView_AttLiaisoner);
        }
        
        private void AttorneySearchMF_Load(object sender, EventArgs e)
        {           
            
            Public.PublicForm Forms = new LawtechPTSystemByFirm.Public.PublicForm();
            Forms.AttorneySearchMF = this;
            
            this.attorneySearchTTableAdapter.Fill(this.dataSet_Attorney.AttorneySearchT);
            attorneySearchTBindingSource.Filter = "1=0";

            Init();           

            but_MoneyList_Click(null, null);

            if (Properties.Settings.Default.IsLoadData)
            {
                but_Search_Click(null, null);
            }
        }

        #region ===========Init============
        public void Init()
        {
            txt_AttorneySymbol.DataBindings.Clear();
            txt_AttorneySymbol.DataBindings.Add("Text", attorneySearchTBindingSource, "AttorneySymbol", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_AttorneyFirm.DataBindings.Clear();
            txt_AttorneyFirm.DataBindings.Add("Text", attorneySearchTBindingSource, "AttorneyFirm", true, DataSourceUpdateMode.OnValidation, "", "");


            txt_Addr.DataBindings.Clear();
            txt_Addr.DataBindings.Add("Text", attorneySearchTBindingSource, "Addr", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_ID.DataBindings.Clear();
            txt_ID.DataBindings.Add("Text", attorneySearchTBindingSource, "ID", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_Principal.DataBindings.Clear();
            txt_Principal.DataBindings.Add("Text", attorneySearchTBindingSource, "Principal", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_TEL.DataBindings.Clear();
            txt_TEL.DataBindings.Add("Text", attorneySearchTBindingSource, "TEL", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_FAX.DataBindings.Clear();
            txt_FAX.DataBindings.Add("Text", attorneySearchTBindingSource, "FAX", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_email.DataBindings.Clear();
            txt_email.DataBindings.Add("Text", attorneySearchTBindingSource, "Email", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_Website.DataBindings.Clear();
            txt_Website.DataBindings.Add("Text", attorneySearchTBindingSource, "WebSite", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_BankAccount.DataBindings.Clear();
            txt_BankAccount.DataBindings.Add("Text", attorneySearchTBindingSource, "BankAccount", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_BankAccountNo.DataBindings.Clear();
            txt_BankAccountNo.DataBindings.Add("Text", attorneySearchTBindingSource, "BankAccountNo", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_Bank.DataBindings.Clear();
            txt_Bank.DataBindings.Add("Text", attorneySearchTBindingSource, "Bank", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_Remark.DataBindings.Clear();
            txt_Remark.DataBindings.Add("Text", attorneySearchTBindingSource, "Remark", true, DataSourceUpdateMode.OnValidation, "", "");

            txt_payment.DataBindings.Clear();
            txt_payment.DataBindings.Add("Text", attorneySearchTBindingSource, "payment", true, DataSourceUpdateMode.OnValidation, "", "");

        }
        #endregion

        private void GridView_Attorney_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = false;
        }

        private void GridView_Attorney_SelectionChanged(object sender, EventArgs e)
        {
            if (GridView_Attorney.CurrentRow != null)
            {
                attorneyLiaisonerSearchTTableAdapter.Fill(dataSet_Attorney.AttorneyLiaisonerSearchT, (int)GridView_Attorney.CurrentRow.Cells["AttorneyKey"].Value);                
            }
            else
            {
                dataSet_Attorney.AttorneyLiaisonerSearchT.Rows.Clear(); 
            }
        }

        
        private void AttorneySearchMF_FormClosed(object sender, FormClosedEventArgs e)
        {
            Public.PublicForm Forms = new LawtechPTSystemByFirm.Public.PublicForm();
            Forms.AttorneySearchMF = null;
        }

        private void but_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 刷新按鈕
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void but_All_Click(object sender, EventArgs e)
        {
            this.dataSet_Attorney.AttorneyT.Rows.Clear();
            this.attorneySearchTTableAdapter.Fill(this.dataSet_Attorney.AttorneySearchT);
            attorneySearchTBindingSource.Filter = "1=1";
        }

        /// <summary>
        /// 查詢按鈕
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void but_Search_Click(object sender, EventArgs e)
        {
             string strSQLWhere = Public.CommonFunctions.GetSQLScript(QueryFilter1, QueryFilter2, Radio_and.Checked ? " and " : " or ");
             attorneySearchTBindingSource.Filter = strSQLWhere;          
        }


        private void GridView_AttLiaisoner_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                if (GridView_AttLiaisoner.Columns[e.ColumnIndex].Name == "email")
                {
                    if (GridView_AttLiaisoner.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Trim() != "")
                    {
                        Public.Utility.ProcessMailTo(GridView_AttLiaisoner.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                    }
                }
            }
        }

        private void GridView_Attorney_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                if (GridView_Attorney.Columns[e.ColumnIndex].Name == "AEmail")
                {
                    if (GridView_Attorney.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Trim() != "")
                    {
                        Public.Utility.ProcessMailTo(GridView_Attorney.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                    }
                }
                else if (GridView_Attorney.Columns[e.ColumnIndex].Name == "WebSite")
                {
                    if (GridView_Attorney.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Replace("http://", "").Trim() != "")
                    {
                        Public.Utility.ProcessStart("http://" + GridView_Attorney.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Replace("http://", ""));
                    }
                }
            }
        }

        private void but_MoneyList_Click(object sender, EventArgs e)
        {
            if (!splitContainer1.Panel2Collapsed)
            {
                but_MoneyList.Text = "開啟明細";

                splitContainer1.Panel2Collapsed = true;
            }
            else
            {
                but_MoneyList.Text = "關閉明細";
                splitContainer1.Panel2Collapsed = false;
            }
        }

        private void AttorneyMF_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt)
            {
                if (e.KeyCode == Keys.E)
                {
                    but_MoneyList_Click(null, null);
                }
            }
        }       

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// 水平 / 垂直
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Public.Utility.SsplitContainerHorizontal(ref splitContainer1);
        }
    }
}
