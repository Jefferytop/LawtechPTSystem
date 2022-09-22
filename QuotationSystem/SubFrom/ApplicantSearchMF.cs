using System;
using System.Data;
using System.Windows.Forms;

namespace LawtechPTSystem.SubFrom
{
    public partial class ApplicantSearchMF : Form
    {
        public ApplicantSearchMF()
        {
            InitializeComponent();
            GridView_Applicant.AutoGenerateColumns = false;
            GridView_AttLiaisoner.AutoGenerateColumns = false;
            Public.DynamicGridViewColumn.GetGridColum(ref GridView_Applicant);
            Public.DynamicGridViewColumn.GetGridColum(ref GridView_AttLiaisoner);
        }

        #region Public Property
        private DataTable dt_ApplicantSearchT = new DataTable();
        /// <summary>
        /// 申請人資料集
        /// </summary>
        public DataTable DT_ApplicantSearchT
        {
            get { return dt_ApplicantSearchT; }

        }

        private DataTable dt_LiaisonerSreachT = new DataTable();
        /// <summary>
        /// 聯絡人資料集
        /// </summary>
        public DataTable DT_LiaisonerSreachT
        {
            get { return dt_LiaisonerSreachT; }

        }

        /// <summary>
        /// 取得目前該申請人的Key值
        /// </summary>
        public int ProApplicantKey
        {
            get
            {
                if (GridView_Applicant.CurrentRow != null)
                {
                    return (int)GridView_Applicant.CurrentRow.Cells["ApplicantKey"].Value;
                }
                else
                {
                    return -1;
                }
            }
        } 
       
        #endregion

        private void but_Close_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        #region  private void ApplicantSearchMF_Load(object sender, EventArgs e)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ApplicantSearchMF_Load(object sender, EventArgs e)
        {
            Public.PublicForm Forms = new Public.PublicForm();
            Forms.ApplicantSearchMF = this;
           
            SetBindingSource();
            Init();

            but_MoneyList_Click(null, null);
        } 
        #endregion

        #region 設定BindingSource的來源 private void SetBindingSource()
        /// <summary>
        /// 設定BindingSource的來源
        /// </summary>
        private void SetBindingSource()
        {
            if (dt_ApplicantSearchT.Columns.Count == 0)
            {
                Public.CApplicantPublicFunction.GetApplicantTList("1=0", ref dt_ApplicantSearchT);
            }
            applicantTBindingSource.DataSource = dt_ApplicantSearchT;

            if (dt_LiaisonerSreachT.Columns.Count == 0)
            {
                Public.CApplicantPublicFunction.GetLiaisoner("0", ref dt_LiaisonerSreachT);
            }
            liaisonerTBindingSource.DataSource = dt_LiaisonerSreachT;           

        }
        #endregion
      
        #region ===========Init============
        public void Init()
        {
            txt_ApplicantName.DataBindings.Clear();
            txt_ApplicantName.DataBindings.Add("Text", applicantTBindingSource, "ApplicantName", true, DataSourceUpdateMode.OnPropertyChanged, "", "");

            txt_ApplicantNameEn.DataBindings.Clear();
            txt_ApplicantNameEn.DataBindings.Add("Text", applicantTBindingSource, "ApplicantNameEn", true, DataSourceUpdateMode.OnPropertyChanged, "", "");

            txt_PrincipalName.DataBindings.Clear();
            txt_PrincipalName.DataBindings.Add("Text", applicantTBindingSource, "PrincipalName", true, DataSourceUpdateMode.OnPropertyChanged, "", "");

            txt_PrincipalNameEn.DataBindings.Clear();
            txt_PrincipalNameEn.DataBindings.Add("Text", applicantTBindingSource, "PrincipalNameEn", true, DataSourceUpdateMode.OnPropertyChanged, "", "");

            txt_Addr.DataBindings.Clear();
            txt_Addr.DataBindings.Add("Text", applicantTBindingSource, "Address", true, DataSourceUpdateMode.OnPropertyChanged, "", "");

            txt_AddrEn.DataBindings.Clear();
            txt_AddrEn.DataBindings.Add("Text", applicantTBindingSource, "AddressEn", true, DataSourceUpdateMode.OnPropertyChanged, "", "");

            txt_LiaisonAddr.DataBindings.Clear();
            txt_LiaisonAddr.DataBindings.Add("Text", applicantTBindingSource, "ContactAddr", true, DataSourceUpdateMode.OnPropertyChanged, "", "");

            //客戶代碼
            txt_ApplicantSymbol.DataBindings.Clear();
            txt_ApplicantSymbol.DataBindings.Add("Text", applicantTBindingSource, "ApplicantSymbol", true, DataSourceUpdateMode.OnPropertyChanged, "", "");

            //資本額
            txt_Capital.DataBindings.Clear();
            txt_Capital.DataBindings.Add("Text", applicantTBindingSource, "Capital", true, DataSourceUpdateMode.OnPropertyChanged, "", "");

            //收款記錄
            txt_CollectionRecord.DataBindings.Clear();
            txt_CollectionRecord.DataBindings.Add("Text", applicantTBindingSource, "CollectionRecord", true, DataSourceUpdateMode.OnPropertyChanged, "", "");

            //客戶評價
            txt_Evaluation.DataBindings.Clear();
            txt_Evaluation.DataBindings.Add("Text", applicantTBindingSource, "Evaluation", true, DataSourceUpdateMode.OnPropertyChanged, "", "");

            //開始來往時間
            maskedTextBox_StartedDate.DataBindings.Clear();
            maskedTextBox_StartedDate.DataBindings.Add("Text", applicantTBindingSource, "StartedDate", true, DataSourceUpdateMode.OnPropertyChanged, "    /  /", "yyyy/MM/dd");

            txt_ID.DataBindings.Clear();
            txt_ID.DataBindings.Add("Text", applicantTBindingSource, "ID", true, DataSourceUpdateMode.OnPropertyChanged, "", "");

            //所屬母公司
            txt_MainCorp.DataBindings.Clear();
            txt_MainCorp.DataBindings.Add("Text", applicantTBindingSource, "MainCorpName", true, DataSourceUpdateMode.OnPropertyChanged, "", "");

            //客戶種類
            txt_ClientKind.DataBindings.Clear();
            txt_ClientKind.DataBindings.Add("Text", applicantTBindingSource, "ClientKindString", true, DataSourceUpdateMode.OnPropertyChanged, "", "");

            //本所承辦人
            txt_Worker.DataBindings.Clear();
            txt_Worker.DataBindings.Add("Text", applicantTBindingSource, "EmployeeName", true, DataSourceUpdateMode.OnPropertyChanged, "", "");

            //請款方式
            txt_RecWay.DataBindings.Clear();
            txt_RecWay.DataBindings.Add("Text", applicantTBindingSource, "RecWayName", true, DataSourceUpdateMode.OnPropertyChanged, "", "");

            //電子信箱
            //txt_email.DataBindings.Clear();
            //txt_email.DataBindings.Add("Text", applicantTBindingSource, "Email", true, DataSourceUpdateMode.OnPropertyChanged, "", "");

            //網址
            txt_WebSite.DataBindings.Clear();
            txt_WebSite.DataBindings.Add("Text", applicantTBindingSource, "WebSite", true, DataSourceUpdateMode.OnPropertyChanged, "", "");

            //客戶來源
            txt_Source.DataBindings.Clear();
            txt_Source.DataBindings.Add("Text", applicantTBindingSource, "ApplicantSourceName", true, DataSourceUpdateMode.OnPropertyChanged, "", "");

            //產業別
            //txt_businessKind.DataBindings.Clear();
            //txt_businessKind.DataBindings.Add("Text", applicantTBindingSource, "BusinessKind", true, DataSourceUpdateMode.OnPropertyChanged, "", "");


            txt_Chage.DataBindings.Clear();
            txt_Chage.DataBindings.Add("Text", applicantTBindingSource, "Chage", true, DataSourceUpdateMode.OnPropertyChanged, "", "");

            txt_Business.DataBindings.Clear();
            txt_Business.DataBindings.Add("Text", applicantTBindingSource, "Business", true, DataSourceUpdateMode.OnPropertyChanged, "", "");

            txt_SendTitle.DataBindings.Clear();
            txt_SendTitle.DataBindings.Add("Text", applicantTBindingSource, "SendTitle", true, DataSourceUpdateMode.OnPropertyChanged, "", "");

            txt_Account.DataBindings.Clear();
            txt_Account.DataBindings.Add("Text", applicantTBindingSource, "Account", true, DataSourceUpdateMode.OnPropertyChanged, "", "");

            txt_Password.DataBindings.Clear();
            txt_Password.DataBindings.Add("Text", applicantTBindingSource, "Password", true, DataSourceUpdateMode.OnPropertyChanged, "", "");

            txt_TEL.DataBindings.Clear();
            txt_TEL.DataBindings.Add("Text", applicantTBindingSource, "TEL", true, DataSourceUpdateMode.OnPropertyChanged, "", "");

            txt_FAX.DataBindings.Clear();
            txt_FAX.DataBindings.Add("Text", applicantTBindingSource, "FAX", true, DataSourceUpdateMode.OnPropertyChanged, "", "");

            txt_Remark.DataBindings.Clear();
            txt_Remark.DataBindings.Add("Text", applicantTBindingSource, "Remart", true, DataSourceUpdateMode.OnPropertyChanged, "", "");

            txt_SourceDescription.DataBindings.Clear();
            txt_SourceDescription.DataBindings.Add("Text", applicantTBindingSource, "SourceDescription", true, DataSourceUpdateMode.OnPropertyChanged, "", "");

            txt_Receiptor.DataBindings.Clear();
            txt_Receiptor.DataBindings.Add("Text", applicantTBindingSource, "Receiptor", true, DataSourceUpdateMode.OnPropertyChanged, "", "");

            txt_Remark.DataBindings.Clear();
            txt_Remark.DataBindings.Add("Text", applicantTBindingSource, "Remart", true, DataSourceUpdateMode.OnPropertyChanged, "", "");

            Check_P.DataBindings.Clear();
            Check_P.DataBindings.Add("Checked", applicantTBindingSource, "P", true, DataSourceUpdateMode.OnPropertyChanged, false);

            Check_T.DataBindings.Clear();
            Check_T.DataBindings.Add("Checked", applicantTBindingSource, "T", true, DataSourceUpdateMode.OnPropertyChanged, false);

            Check_C.DataBindings.Clear();
            Check_C.DataBindings.Add("Checked", applicantTBindingSource, "C", true, DataSourceUpdateMode.OnPropertyChanged, false);

            Check_L.DataBindings.Clear();
            Check_L.DataBindings.Add("Checked", applicantTBindingSource, "L", true, DataSourceUpdateMode.OnPropertyChanged, false);

            Check_E.DataBindings.Clear();
            Check_E.DataBindings.Add("Checked", applicantTBindingSource, "E", true, DataSourceUpdateMode.OnPropertyChanged, false);

            checkBox_LawVIP.DataBindings.Clear();
            checkBox_LawVIP.DataBindings.Add("Checked", applicantTBindingSource, "LawVIP", true, DataSourceUpdateMode.OnPropertyChanged, false);

            txt_LargeEnty.DataBindings.Clear();
            txt_LargeEnty.DataBindings.Add("Text", applicantTBindingSource, "LargeEntyName", true, DataSourceUpdateMode.OnPropertyChanged, "", "");

        }
        #endregion

        #region private void ApplicantSearchMF_FormClosed(object sender, FormClosedEventArgs e)
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ApplicantSearchMF_FormClosed(object sender, FormClosedEventArgs e)
        {
            Public.PublicForm Forms = new Public.PublicForm();
            Forms.ApplicantSearchMF = null;
        } 
        #endregion

        private void GridView_Applicant_SelectionChanged(object sender, EventArgs e)
        {
            if (GridView_Applicant.CurrentRow != null)
            {
                Public.CApplicantPublicFunction.GetLiaisoner(ProApplicantKey.ToString(), ref dt_LiaisonerSreachT);
            }
            else {
                dt_LiaisonerSreachT.Rows.Clear();
            }
           
        }

       
        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Name)
            {
                case "toolStripButton_Add":
                case "AddApplicantMenuItem":
                    AddFrom.AddApplicant add = new LawtechPTSystem.AddFrom.AddApplicant();
                    add.ShowDialog();
                    break;             
            }
        }

      

        private void button1_Click(object sender, EventArgs e)
        {
            string strSQL = Public.CommonFunctions.GetSQLScript(QueryFilter1, QueryFilter2, Radio_and.Checked ? " and " : " or ");
            Public.CApplicantPublicFunction.GetApplicantTList(strSQL, ref dt_ApplicantSearchT);
                     
        }
  

        private void contextMenuStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Name)
            {
                case "toolStripButton_AddAttLiaisoner":
                case "AddLiaisonerMenuItem":
                    contextMenuStrip2.Visible = false;
                    if (GridView_Applicant.CurrentRow != null)
                    {
                        AddFrom.AddLiaisoner add = new LawtechPTSystem.AddFrom.AddLiaisoner();
                        add.ApplicantKey = (int)GridView_Applicant.CurrentRow.Cells["ApplicantKey"].Value;
                        add.ShowDialog();
                    }
                    break;
               
            }
        }

        private void GridView_AttLiaisoner_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = false;
        }

        private void GridView_Applicant_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = false;
        }

        private void GridView_AttLiaisoner_CellClick(object sender, DataGridViewCellEventArgs e)
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

        private void GridView_Applicant_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                if (GridView_Applicant.Columns[e.ColumnIndex].Name == "AEmail")
                {
                    if (GridView_Applicant.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Trim() != "")
                    {
                        Public.Utility.ProcessMailTo(GridView_Applicant.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
                    }
                }
                else if (GridView_Applicant.Columns[e.ColumnIndex].Name == "WebSite")
                {
                    if (GridView_Applicant.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Replace("http://", "").Trim() != "")
                    {
                        Public.Utility.ProcessStart("http://" + GridView_Applicant.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Replace("http://", ""));
                    }
                }
            }
        }

        private void but_MoneyList_Click(object sender, EventArgs e)
        {
            if (!splitContainer1.Panel2Collapsed)
            {
                but_MoneyList.Text = "開啟客戶明細(Alt+E)";

                splitContainer1.Panel2Collapsed = true;
            }
            else
            {
                but_MoneyList.Text = "關閉客戶明細(Alt+E)";
                splitContainer1.Panel2Collapsed = false;
            }
        }

        private void ApplicantSearchMF_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Alt)
            {
                if (e.KeyCode == Keys.E)
                {
                    but_MoneyList_Click(null, null);
                }
            }
        }

        #region 刷新按鈕 private void btnRefresh_Click(object sender, EventArgs e)
        /// <summary>
        /// 刷新按鈕
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            dt_ApplicantSearchT.Rows.Clear();
            Public.CApplicantPublicFunction.GetApplicantTList("", ref dt_ApplicantSearchT);
        } 
        #endregion

     
    }
}