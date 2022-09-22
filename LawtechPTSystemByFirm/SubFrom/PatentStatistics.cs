using System;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LawtechPTSystemByFirm.SubFrom
{
    /// <summary>
    /// 案件查詢統計
    /// </summary>
    public partial class PatentStatistics : Form
    {
        public PatentStatistics()
        {
            InitializeComponent();

            dataGridView1.AutoGenerateColumns = false;
            Public.DynamicGridViewColumn.GetGridColum(ref dataGridView1);
        }

        string strSearhSQL = " select PatentID from PatentManagementT ";
        /// <summary>
        /// 記錄查詢的條件
        /// </summary>
        public string SeachSQL
        {
            get {
                return strSearhSQL;
            }
            set { strSearhSQL = value; }
        }



        private void PatentStatistics_Load(object sender, EventArgs e)
        {
            
           
            Public.PublicForm Forms = new LawtechPTSystemByFirm.Public.PublicForm();
            Forms.PatentStatistics = this;
            this.patSelectDateModeAnalysis_DropTableAdapter.Fill(this.qS_DataSet.PatSelectDateModeAnalysis_Drop);
            
            //this.patentManagementTTableAdapter.Fill(this.qS_DataSet.PatentManagementT);

            this.patStatusT_DropTableAdapter.Fill(this.qS_DataSet._PatStatusT_Drop);

            this.pATFeatureT_DropTableAdapter.Fill(this.qS_DataSet.PATFeatureT_Drop);
            QS_DataSet.PATFeatureT_DropRow drFeatureT = this.qS_DataSet.PATFeatureT_Drop.NewPATFeatureT_DropRow();
            drFeatureT["FeatureName"] = " ";
            drFeatureT["FeatureID"] = -1;
            this.qS_DataSet.PATFeatureT_Drop.Rows.InsertAt(drFeatureT, 0);
            comboBox_Nature.SelectedIndex = 0;

            this.kindforPatTableAdapter.FillbyPatKind(this.qS_DataSet.KindforPat);
            QS_DataSet.KindforPatRow drKind = this.qS_DataSet.KindforPat.NewKindforPatRow();
            drKind["KindSN"] = "All";
            drKind["Kind"] = " ";
            this.qS_DataSet.KindforPat.Rows.InsertAt(drKind, 0);
            comboBox_Kind.SelectedIndex = 0;

            this.countryT_DropTableAdapter.Fill(this.qS_DataSet.CountryT_Drop);
            QS_DataSet.CountryT_DropRow drCountry = this.qS_DataSet.CountryT_Drop.NewCountryT_DropRow();
            drCountry["Country"] = " ";
            drCountry["CountrySymbol"] = "All";
            this.qS_DataSet.CountryT_Drop.Rows.InsertAt(drCountry, 0);
            comboBox_Country.SelectedIndex = 0;


            //bSource_Patent.DataSource = this.dataSet_Pat;
            //bSource_Patent.DataMember = "V_PatentList";

            this.v_PatentListTableAdapter.Fill(this.dataSet_Pat.V_PatentList);
            //but_Search_Click(null,null);

        }

        private void but_Search_Click(object sender, EventArgs e)        
        {
            //if (searchMain1.comboBox2.Text == "" && maskedTextBox_S.Text == "    /  /" && maskedTextBox_D.Text == "    /  /" && comboBox_Nature.SelectedIndex == 0 && comboBox_Kind.SelectedIndex == 0 && comboBox_Status.SelectedIndex == 0 && comboBox_Country.SelectedIndex == 0)
            //{
            //    MessageBox.Show("請輸入查詢條件", "提示訊息");
            //}
            //else
            //{
            but_Search.Enabled = false;

            string strSQL = Public.CommonFunctions.GetSQLScript(QueryFilter1, QueryFilter2, rb_and.Checked ? " and " : " or ", userControlFilterDate1);
               
                Public.DLL dll = new LawtechPTSystemByFirm.Public.DLL();

                string strFilter = "";              

                string strCountry = "";
                //國別
                if (comboBox_Country.Text.Trim() != "" && comboBox_Country.SelectedValue!=null)
                {                    
                    strCountry = " CountrySymbol='" + comboBox_Country.SelectedValue.ToString() + "'";
                }

                string strKind = "";
                //種類
                if (comboBox_Kind.Text.Trim() != "" && comboBox_Kind.SelectedValue!=null)
                {                   
                    strKind = " Kind='" + comboBox_Kind.SelectedValue.ToString() + "'";
                }

                string strNature = "";
                //性質
                if (comboBox_Nature.Text.Trim() != "" && comboBox_Nature.SelectedValue != null)
                {                  
                    strNature = "PatentManagementT.Nature=" + comboBox_Nature.SelectedValue.ToString();
                }

                string strStatus = "";
                //案件狀態
                if (comboBox_Status.Text.Trim() != "" && comboBox_Status.SelectedValue != null)
                {                   
                    strStatus = "PatentManagementT.Status=" + comboBox_Status.SelectedValue.ToString();
                }


                string[] sWhere = { strSQL, strFilter, strCountry, strKind, strNature, strStatus };

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

               
                #region 
                //string strSQL = @"SELECT         row_number() OVER (ORDER BY PatentID) AS SerialNumber, 
                          //  PatentManagementT.PatentID, PatentManagementT.PatentNo, 
                          //  PatentManagementT.PatentNo_Old, PatentManagementT.UpbuildDate, 
                          //  PatentManagementT.Applicant, PatentManagementT.Title, PatentManagementT.TitleEn, 
                          //  PatentManagementT.Kind, PatentManagementT.Nature, PatentManagementT.Country, 
                          //  PatentManagementT.ClientWorker, PatentManagementT.Status, 
                          //  PatentManagementT.StatusExplain, PatentManagementT.ISexam, 
                          //  PatentManagementT.Priority, PatentManagementT.EarlyPriorityDate, 
                          //  PatentManagementT.EarlyMotherDate, PatentManagementT.ApplicationDate, 
                          //  PatentManagementT.ApplicationNo, PatentManagementT.Pubdate, 
                          //  PatentManagementT.PubNo, PatentManagementT.AllowDate, 
                          //  PatentManagementT.AllowPubDate, PatentManagementT.AllowPubNo, 
                          //  PatentManagementT.GetDate, PatentManagementT.CertifyNo, 
                          //  PatentManagementT.RegisterDate, PatentManagementT.DueDate, 
                          //  PatentManagementT.PayYear, PatentManagementT.RenewTo, 
                          //  PatentManagementT.CloseDate, PatentManagementT.CloseCaus, 
                          //  PatentManagementT.Remark, PatentManagementT.FileSource, 
                          //  PatentManagementT.NextYear, PatentManagementT.YearFee, 
                          //  PatentManagementT.IneventerMan, PatentManagementT.AddDay, 
                          //  PatentManagementT.Inventor, WorkerT.Name AS WorkerName, 
                          //  PatStatusT.Status AS StatusName, CountryT.Country AS CountryName, 
                          //  KindT.Kind AS KindName, PATFeatureT.FeatureName, PattPriorityBaseT.PriorityBaseName, 
                          //  PatISexamT.ISExam AS ISExamName, 
                          //  CASE WHEN PatentManagementT.DelegateType = 1 THEN '申請人直接委託' WHEN PatentManagementT.DelegateType
                          //   = 2 THEN '複代委託' END AS DelegateTypeName, 
                          //  CASE WHEN PatentManagementT.DelegateType = 1 THEN PatentManagementT.ApplicantNames
                          //   WHEN PatentManagementT.DelegateType = 2 THEN
                          //      (SELECT         AttorneyT.AttorneyFirm
                          //        FROM              AttorneyT
                          //        WHERE          AttorneyT.AttorneyKey = PatentManagementT.MainCustomer) 
                          //  END AS MainCustomerName, PatentManagementT.MainCustomerRefNo, 
                          //  CASE WHEN PatentManagementT.DelegateType = 1 THEN
                          //      (SELECT         LiaisonerT.Liaisoner
                          //        FROM              LiaisonerT
                          //        WHERE          LiaisonerKey = PatentManagementT.MainCustomerTransactor) 
                          //  WHEN PatentManagementT.DelegateType = 2 THEN
                          //      (SELECT         AttLiaisonerT.Liaisoner
                          //        FROM              AttLiaisonerT
                          //        WHERE          ALiaisonerKey = PatentManagementT.MainCustomerTransactor) 
                          //  END AS MainCustomerTransactorName, PatentManagementT.Attorney, 
                          //  PatentManagementT.AttorneyRefNo, PatentManagementT.AttorneyTransactor, 
                          //  PatentManagementT.IsBySelf, PatentManagementT.Introducer, 
                          //  PatentManagementT.IntroductionDate, AttorneyT.AttorneyFirm, 
                          //  AttLiaisonerT.Liaisoner AS AttLiaisoner, PatentManagementT.DelegateType, 
                          //  PatentManagementT.MainCustomer, PatentManagementT.MainCustomerTransactor, 
                          //  PatentManagementT.ApplicantNames, PatentManagementT.EarlyPriorityNo, 
                          //  PatentManagementT.ApplicantKeys
                          //  FROM             KindT RIGHT OUTER JOIN
                          //AttorneyT RIGHT OUTER JOIN
                          //PatentManagementT LEFT OUTER JOIN
                          //AttLiaisonerT ON 
                          //PatentManagementT.AttorneyTransactor = AttLiaisonerT.ALiaisonerKey ON 
                          //AttorneyT.AttorneyKey = PatentManagementT.Attorney LEFT OUTER JOIN
                          //PatISexamT ON 
                          //PatentManagementT.ISexam = PatISexamT.ISExamID LEFT OUTER JOIN
                          //PattPriorityBaseT ON 
                          //PatentManagementT.Priority = PattPriorityBaseT.PriorityBaseID LEFT OUTER JOIN
                          //PATFeatureT ON 
                          //PatentManagementT.Nature = PATFeatureT.FeatureID LEFT OUTER JOIN
                          //CountryT ON 
                          //PatentManagementT.Country = CountryT.CountrySymbol LEFT OUTER JOIN
                          //PatStatusT ON 
                          //PatentManagementT.Status = PatStatusT.StatusID LEFT OUTER JOIN
                          //WorkerT ON PatentManagementT.ClientWorker = WorkerT.WorkerKey ON 
                          //KindT.KindSN = PatentManagementT.Kind";
                #endregion

                #region NULL使用N/A替代
                string strSQLFull = @"SELECT   row_number() OVER(ORDER BY PatentID ) as SerialNumber, PatentManagementT.PatentID, PatentManagementT.PatentNo, 
                         ISNULL( PatentManagementT.PatentNo_Old,'N/A')as PatentNo_Old, PatentManagementT.CreateDateTime, 
                          PatentManagementT.Applicant, PatentManagementT.Title, 
                          ISNULL(PatentManagementT.TitleEn,'N/A') as TitleEn, PatentManagementT.Kind, 
                          PatentManagementT.Nature, PatentManagementT.CountrySymbol, 
                          PatentManagementT.ClientWorker, PatentManagementT.Status, 
                          ISNULL(PatentManagementT.StatusExplain,'N/A') as StatusExplain, PatentManagementT.ISexam, 
                          PatentManagementT.Priority,ISNULL(convert(nvarchar(30),  PatentManagementT.EarlyPriorityDate,111),'N/A') as EarlyPriorityDate, 
                        ISNULL( convert(nvarchar(30), PatentManagementT.EarlyMotherDate,111) ,'N/A')as EarlyMotherDate,
ISNULL( convert( nvarchar(30),PatentManagementT.ApplicationDate,111),'N/A') as ApplicationDate, 
                         ISNULL( PatentManagementT.ApplicationNo,'N/A') as ApplicationNo, 
ISNULL(convert( nvarchar(30),PatentManagementT.Pubdate,111),'N/A') as Pubdate, 
                         ISNULL( PatentManagementT.PubNo,'N/A') as PubNo, 
ISNULL(convert( nvarchar(30),PatentManagementT.AllowDate,111) ,'N/A') as AllowDate, 
                         ISNULL( convert( nvarchar(30),PatentManagementT.AllowPubDate,111),'N/A') as AllowPubDate , ISNULL(PatentManagementT.AllowPubNo,'N/A') as AllowPubNo, 
                         ISNULL(convert( nvarchar(30), PatentManagementT.[GetDate],111) ,'N/A') as GetDate,ISNULL( PatentManagementT.CertifyNo,'N/A')as CertifyNo, 
                         ISNULL( convert( nvarchar(30),PatentManagementT.RegisterDate,111),'N/A')as RegisterDate, 
ISNULL( convert( nvarchar(30),PatentManagementT.DueDate,111),'N/A')as DueDate, 
                         isnULL( convert( nvarchar(30),PatentManagementT.PayYear,111),'N/A') as PayYear,isnULL( convert( nvarchar(30), PatentManagementT.RenewTo,111),'N/A') as RenewTo, 
                         ISNULL( convert( nvarchar(30), PatentManagementT.CloseDate,111),'N/A') as CloseDate, ISNULL(PatentManagementT.CloseCaus,'N/A')as CloseCaus, 
                          PatentManagementT.Remark, PatentManagementT.FileSource, 
                          PatentManagementT.NextYear, ISNULL(  convert( nvarchar(30),PatentManagementT.YearFee),'N/A')as YearFee, 
                          PatentManagementT.IneventerMan, PatentManagementT.AddDay, 
                          ISNULL(PatentManagementT.Inventor,'N/A')as Inventor,ISNULL( WorkerT.EmployeeName,'N/A' )AS WorkerName, 
                          PatStatusT.Status AS StatusName, CountryT.Country AS CountryName, 
                         ISNULL( KindT.Kind,'N/A') AS KindName, PATFeatureT.FeatureName, 
                         isNULL( PattPriorityBaseT.PriorityBaseName,'N/A') as PriorityBaseName, ISNULL(PatISexamT.ISExam,'N/A') AS ISExamName, 
                          CASE WHEN PatentManagementT.DelegateType = 1 THEN '申請人直接委託' WHEN
                           PatentManagementT.DelegateType = 2 THEN '複代委託' END AS DelegateTypeName,
                           CASE WHEN PatentManagementT.DelegateType = 1 THEN PatentManagementT.ApplicantNames
                           WHEN PatentManagementT.DelegateType = 2 THEN
                              (SELECT         AttorneyT.AttorneyFirm
                                FROM              AttorneyT
                                WHERE          AttorneyT.AttorneyKey = PatentManagementT.MainCustomer) 
                          END AS MainCustomerName, ISNULL(PatentManagementT.MainCustomerRefNo,'N/A') as MainCustomerRefNo, 
                          CASE WHEN PatentManagementT.DelegateType = 1 THEN
                              (SELECT         LiaisonerT.LiaisonerName
                                FROM              LiaisonerT
                                WHERE          LiaisonerKey = PatentManagementT.MainCustomerTransactor) 
                          WHEN PatentManagementT.DelegateType = 2 THEN
                              (SELECT         AttLiaisonerT.Liaisoner
                                FROM              AttLiaisonerT
                                WHERE          ALiaisonerKey = PatentManagementT.MainCustomerTransactor) 
                          END AS MainCustomerTransactorName, PatentManagementT.Attorney, 
                          ISNULL(PatentManagementT.AttorneyRefNo,'N/A') as AttorneyRefNo, PatentManagementT.AttorneyTransactor, 
                          PatentManagementT.IsBySelf, PatentManagementT.Introducer, 
                         ISNULL( convert( nvarchar(30), PatentManagementT.IntroductionDate,111),'N/A')as IntroductionDate,ISNULL( AttorneyT.AttorneyFirm,'N/A') as AttorneyFirm, 
                          ISnULL(AttLiaisonerT.Liaisoner,'N/A' )AS AttLiaisoner, PatentManagementT.DelegateType, 
                          PatentManagementT.MainCustomer, 
                          PatentManagementT.MainCustomerTransactor, 
                         ISNULL( PatentManagementT.ApplicantNames,'N/A') as ApplicantNames,
						 ISNULL( PatentManagementT.EarlyPriorityNo,'N/A')as EarlyPriorityNo, 
                          PatentManagementT.ApplicantKeys
                        FROM             KindT RIGHT OUTER JOIN
                          AttorneyT RIGHT OUTER JOIN
                          PatentManagementT LEFT OUTER JOIN
                          AttLiaisonerT ON 
                          PatentManagementT.AttorneyTransactor = AttLiaisonerT.ALiaisonerKey ON 
                          AttorneyT.AttorneyKey = PatentManagementT.Attorney LEFT OUTER JOIN
                          PatISexamT ON 
                          PatentManagementT.ISexam = PatISexamT.ISExamID LEFT OUTER JOIN
                          PattPriorityBaseT ON 
                          PatentManagementT.Priority = PattPriorityBaseT.PriorityBaseID LEFT OUTER JOIN
                          PATFeatureT ON 
                          PatentManagementT.Nature = PATFeatureT.FeatureID LEFT OUTER JOIN
                          CountryT ON 
                          PatentManagementT.CountrySymbol = CountryT.CountrySymbol LEFT OUTER JOIN
                          PatStatusT ON 
                          PatentManagementT.Status = PatStatusT.StatusID LEFT OUTER JOIN
                          WorkerT ON PatentManagementT.ClientWorker = WorkerT.WorkerKey ON 
                          KindT.KindSN = PatentManagementT.Kind  ";
                #endregion

                vPatentListBindingSource.Filter = FullWhere.ToString();

                strSearhSQL = FullWhere.ToString().Trim() == "" ? "SELECT  PatentManagementT.PatentID from PatentManagementT" : " SELECT  PatentManagementT.PatentID from PatentManagementT where " + FullWhere.ToString();
               
                //string sWhereAll = FullWhere.ToString().Length > 0 ? strSQLFull + " where " + FullWhere.ToString() : strSQL;
                //vPatentListBindingSource.Filter = sWhereAll;
                //dll.FetchDataTable(sWhereAll, this.qS_DataSet.PatentManagementT);
                
                //dll.SQLBeginExecuteReader("select * from PatentManagementT where " + strFilter, this.toolStripProgressBar1, (int)iCount, this.qS_DataSet.PatentManagementT, GridView_File);
                //bSource_Patent.Filter = strFilter;

               //NULL使用N/A替代
               //DataTable dt= dll.SqlDataAdapterDataTable(sWhereAll);
               //bSource_Patent.DataSource = dt;
            
            //NULL使用N/A替代

            //}

               but_Search.Enabled = true; ;
        }

        private void but_ClearSearch_Click(object sender, EventArgs e)
        {
            comboBox_Nature.SelectedIndex = 0;
            comboBox_Kind.SelectedIndex = 0;
            comboBox_Status.SelectedIndex = 0;
            comboBox_Country.SelectedIndex = 0;
            QueryFilter1.ComboBoxSearchColumn.SelectedIndex = 0;
            QueryFilter2.ComboBoxSearchColumn.SelectedIndex = 0;
            userControlFilterDate1.MaskedStartDate.Text = "";
            userControlFilterDate1.MaskedEndDate.Text = "";
        }

        private void but_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void but_Excel_Click(object sender, EventArgs e)
        {
            try
            {
                Public.DLL dll = new LawtechPTSystemByFirm.Public.DLL();
                Task t=dll.WriteToCSV(dataGridView1);
            }
            catch
            {
                MessageBox.Show("匯出CSV失敗");
            }
        }

        private void but_All_Click(object sender, EventArgs e)
        {
            but_ClearSearch_Click(null,null);
            but_Search_Click(null, null);
            //this.patentManagementTTableAdapter.Fill(this.qS_DataSet.PatentManagementT);
        }

        private void but_FileDetail_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                PatentHistoryRecord1 patent = new LawtechPTSystemByFirm.SubFrom.PatentHistoryRecord1();
                patent.property_PatentID = (int)dataGridView1.CurrentRow.Cells["PatentID"].Value;
                patent.ShowDialog();
            }
        }

        private void but_Statistic_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                PatentAnalysis patentAnalysis = new LawtechPTSystemByFirm.SubFrom.PatentAnalysis();
                patentAnalysis.SearchPatentID = strSearhSQL;
                patentAnalysis.Show();
            }
            else
            {
                MessageBox.Show("目前符合條件筆數為0\r\n請重新查詢","提示訊息");
            }
        }

        private void but_FeeStatistics_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                PatentFeeStatistics patentFeeAnalysis = new LawtechPTSystemByFirm.SubFrom.PatentFeeStatistics();
                patentFeeAnalysis.SearchPatentID = strSearhSQL;
                patentFeeAnalysis.Show();
            }
            else
            {
                MessageBox.Show("目前符合條件筆數為0\r\n請重新查詢", "提示訊息");
            }
        }

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

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 1 && e.RowIndex != -1)
            {
                but_FileDetail_Click(null, null);
            }
        }

        private void PatentStatistics_FormClosed(object sender, FormClosedEventArgs e)
        {
            Public.PublicForm Forms = new LawtechPTSystemByFirm.Public.PublicForm();
            Forms.PatentStatistics = null;
        }

        private void but_CompleteHistory_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow!=null)
            {
                ViewFrom.PatentCompleteHistory history = new LawtechPTSystemByFirm.ViewFrom.PatentCompleteHistory();
                history.Gv = dataGridView1;
                history.Show();
            }
          
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }     
     
    }
}
