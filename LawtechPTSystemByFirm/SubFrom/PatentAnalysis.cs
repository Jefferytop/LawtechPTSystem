using System;
using System.Windows.Forms;

namespace LawtechPTSystemByFirm.SubFrom
{
    /// <summary>
    /// 專利統計圖
    /// </summary>
    public partial class PatentAnalysis : Form
    {
        public PatentAnalysis()
        {
            InitializeComponent();
        }

        string _searchPatentID = "";
        public string SearchPatentID
        {
            get { return _searchPatentID; }
            set { _searchPatentID = value; }
        }

        string _patentCountSearch = "";
        /// <summary>
        /// 案件量統計查詢
        /// </summary>
        public string PatentCountSearch
        {
            get {
                _patentCountSearch = string .Format(@"select PatentYear,PatentMonth,
                                        (select count(PatentNo) from PatentManagementT where year(ApplicationDate)=PatentYear and  month(ApplicationDate)=PatentMonth and PatentID in({0}) ) as ApplicationCount,
                                        (select count(PatentNo) from PatentManagementT where year(Pubdate)=PatentYear and  month(Pubdate)=PatentMonth  and PatentID in({0}) ) as APubdateCount,
                                        (select count(PatentNo) from PatentManagementT where year(AllowDate)=PatentYear and  month(AllowDate)=PatentMonth and PatentID in({0}) ) as AllowDateCount,
                                        (select count(PatentNo) from PatentManagementT where year(CloseDate)=PatentYear and  month(CloseDate)=PatentMonth and PatentID in({0}) ) as CloseDateCount
                                        from(
                                        select year(ApplicationDate) as PatentYear,month(ApplicationDate) as PatentMonth   
                                                                                from PatentManagementT  
                                                                                where ApplicationDate is not null and PatentID in({0})
                                                                                group by  year(ApplicationDate),month(ApplicationDate)
                                                                                union 
                                                                                select year(Pubdate) as PatentYear,month(Pubdate) as PatentMonth   
                                                                                from PatentManagementT  
                                                                                where Pubdate is not null and PatentID in({0})
                                                                                group by  year(Pubdate),month(Pubdate)
                                                                                union 
                                                                                select year(AllowDate) as PatentYear,month(AllowDate) as PatentMonth   
                                                                                from PatentManagementT  
                                                                                where AllowDate is not null and PatentID in({0})
                                                                                group by  year(AllowDate),month(AllowDate)
                                                                                union 
                                                                                select year(CloseDate) as PatentYear,month(CloseDate) as PatentMonth   
                                                                                from PatentManagementT  
                                                                                where CloseDate is not null and PatentID in({0})
                                                                                group by  year(CloseDate),month(CloseDate)

                                        ) as PatentCount
                                        ", SearchPatentID);
                return _patentCountSearch; }
            set { _patentCountSearch = value; }
        }


        string _patentMainCustomerSearch = "";
        /// <summary>
        /// 主委託人案件統計
        /// </summary>
        public string PatentMainCustomerSearch
        {
            get {
//                _patentMainCustomerSearch = string.Format(@"select DelegateType,ApplicantName as CustomerName,
//                                                             ISNULL(year(PatentManagementT.ApplicationDate),0 )as PatenYear,ISNULL(month(PatentManagementT.ApplicationDate),0)as PatenMonth ,count(PatentNo) as PatentCount
//                                                            from PatentManagementT LEFT OUTER JOIN ApplicantT on PatentManagementT.Applicant = ApplicantT.ApplicantKey
//                                                            where DelegateType=1 and Applicant is not null and PatentID in( {0} )
//                                                            group by DelegateType,ApplicantName, year(PatentManagementT.ApplicationDate) ,month(PatentManagementT.ApplicationDate)
//                                                            union
//                                                            select DelegateType,AttorneyT.AttorneyFirm as CustomerName,
//                                                            ISNULL( year(PatentManagementT.ApplicationDate),0) as PatenYear,ISNULL(month(PatentManagementT.ApplicationDate),0)as PatenMonth ,count(PatentNo) as PatentCount
//                                                            from PatentManagementT LEFT OUTER JOIN AttorneyT on AttorneyT.AttorneyKey = PatentManagementT.Attorney
//                                                            where DelegateType=2 and Applicant is not null and PatentID in( {0} )
//                                                            group by DelegateType,AttorneyT.AttorneyFirm, year(PatentManagementT.ApplicationDate) ,month(PatentManagementT.ApplicationDate)", SearchPatentID);

                _patentMainCustomerSearch = string.Format(@"SELECT     PatentManagementT.DelegateType,ApplicantT.ApplicantName as CustomerName, ISNULL(YEAR(PatentManagementT.ApplicationDate), 0) AS PatenYear, ISNULL(MONTH(PatentManagementT.ApplicationDate), 0) 
                                                            AS PatenMonth, COUNT(PatentManagementT.PatentNo) AS PatentCount
                                                            FROM         ApplicantT RIGHT OUTER JOIN
                                                                                  PatentApplicantT ON ApplicantT.ApplicantKey = PatentApplicantT.ApplicantKey LEFT OUTER JOIN
                                                                                  PatentManagementT ON PatentApplicantT.PatentID = PatentManagementT.PatentID
                                                            WHERE     (PatentManagementT.DelegateType = 1) and PatentManagementT.PatentID in( {0} )
                                                            GROUP BY PatentManagementT.DelegateType, YEAR(PatentManagementT.ApplicationDate), MONTH(PatentManagementT.ApplicationDate),ApplicantT.ApplicantName 
                                                           union
                                                            select DelegateType,AttorneyT.AttorneyFirm as CustomerName,
                                                            ISNULL( year(PatentManagementT.ApplicationDate),0) as PatenYear,ISNULL(month(PatentManagementT.ApplicationDate),0)as PatenMonth ,count(PatentNo) as PatentCount
                                                            from PatentManagementT LEFT OUTER JOIN AttorneyT on AttorneyT.AttorneyKey = PatentManagementT.Attorney
                                                            where DelegateType=2 and PatentManagementT.PatentID in( {0} )
                                                            group by DelegateType,AttorneyT.AttorneyFirm, year(PatentManagementT.ApplicationDate) ,month(PatentManagementT.ApplicationDate) ", SearchPatentID);
                return _patentMainCustomerSearch; }
            set { _patentMainCustomerSearch = value; }
        }

        string _patentCountrySearch = "";
        /// <summary>
        /// 國別案件統計
        /// </summary>
        public string PatentCountrySearch
        {
            get {
                _patentCountrySearch = string.Format(@"SELECT     CountryT.Country, CountryT.SN ,ISNULL(Year(PatentManagementT.ApplicationDate),0 ) as PatenYear,ISNULL(Month(PatentManagementT.ApplicationDate),0)as PatentMonth, COUNT(PatentManagementT.CountrySymbol) AS CountryCount
                                                            FROM         PatentManagementT LEFT OUTER JOIN
                                                                                  CountryT ON PatentManagementT.CountrySymbol = CountryT.CountrySymbol
                                                            WHERE     (PatentManagementT.CountrySymbol IS NOT NULL) and PatentID in({0})
                                                            GROUP BY PatentManagementT.CountrySymbol, CountryT.Country, CountryT.SN,Year(PatentManagementT.ApplicationDate),Month(PatentManagementT.ApplicationDate)
                                                            ORDER BY CountryT.SN,PatenYear,PatentMonth
                                                        ", SearchPatentID);
                return _patentCountrySearch; }
            set { _patentCountrySearch = value; }
        }

        string _patentKindSearch = "";
        /// <summary>
        /// 種類案件統計
        /// </summary>
        public string PatentKindSearch
        {
            get {
                _patentKindSearch = string.Format(@"SELECT     KindT.Kind,ISNULL( Year(PatentManagementT.ApplicationDate),0) as PatenYear,ISNULL(Month(PatentManagementT.ApplicationDate) ,0)as PatentMonth, COUNT(PatentManagementT.Kind) AS KindCount
                                                            FROM         PatentManagementT LEFT OUTER JOIN
                                                                                  Kindt ON PatentManagementT.Kind = KindT.KindSN
                                                            WHERE     (PatentManagementT.Kind IS NOT NULL)  and PatentID in({0})
                                                            GROUP BY KindT.Kind, Year(PatentManagementT.ApplicationDate),Month(PatentManagementT.ApplicationDate)
                                                            ORDER BY KindT.Kind,PatenYear,PatentMonth
                                                    ", SearchPatentID);
                return _patentKindSearch; }
            set { _patentKindSearch = value; }
        }

        string _patentAttorneySearch = "";
        /// <summary>
        /// 承辦事務所統計
        /// </summary>
        public string PatentAttorneySearch
        {
            get {
                _patentAttorneySearch = string.Format(@"select 
                                                            ISNULL(year(PatentManagementT.ApplicationDate) ,0)as PatenYear,ISNULL(month(PatentManagementT.ApplicationDate),0)as PatenMonth,
                                                            '本所' as AttorneyName,count(PatentID)as PatentCount
                                                            from PatentManagementT
                                                            where ( (DelegateType=1 and IsBySelf=1 ) or DelegateType=2) and PatentID in({0})
                                                            group by  year(PatentManagementT.ApplicationDate) ,month(PatentManagementT.ApplicationDate)
                                                            union
                                                            select 
                                                            ISNULL(year(PatentManagementT.ApplicationDate),0) as PatenYear,ISNULL(month(PatentManagementT.ApplicationDate),0)as PatenMonth,
                                                            AttorneyT.AttorneyFirm as AttorneyName,count(PatentID)as PatentCount
                                                            from PatentManagementT LEFT OUTER JOIN
                                                                                  AttorneyT ON PatentManagementT.Attorney = AttorneyT.AttorneyKey
                                                            where DelegateType=1 and IsBySelf=0 and PatentID in({0})
                                                            group by  year(PatentManagementT.ApplicationDate) ,month(PatentManagementT.ApplicationDate),AttorneyT.AttorneyFirm", SearchPatentID);
                return _patentAttorneySearch; }
            set { _patentAttorneySearch = value; }
        }



        string _patentStatusSearch = "";
        /// <summary>
        /// 各案件階段統計
        /// </summary>
        public string PatentStatusSearch
        {
            get
            {
                _patentStatusSearch = string.Format(@"SELECT     PatStatusT.sort, PatStatusT.Status,Count(PatentManagementT.PatentNo)as CountStatus
                                                            FROM         PatentManagementT LEFT OUTER JOIN
                                                                                  PatStatusT ON PatentManagementT.Status = PatStatusT.StatusID
                                                            WHERE     (PatentManagementT.Status IS NOT NULL)  and PatentID in (  {0}  )
                                                            GROUP BY  PatStatusT.sort,PatStatusT.Status
                                                            ORDER BY PatStatusT.sort", SearchPatentID);
                                                                        return _patentStatusSearch;
            }
            set { _patentStatusSearch = value; }
        }


        private void PatentAnalysis_Load(object sender, EventArgs e)
        {

        }

        private void but_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rb_PatentCount_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void but_OK_Click(object sender, EventArgs e)
        {
           
                ReportView.PatentAnalysis analysis = new LawtechPTSystemByFirm.ReportView.PatentAnalysis();
                
                if (rb_PatentCount.Checked)
                {
                    analysis.SearchType = 1;
                    analysis.SQLSearch = PatentCountSearch;
                }
                else if (rb_MainCustomer.Checked)
                {
                    analysis.SearchType = 2;
                    analysis.SQLSearch = PatentMainCustomerSearch;
                }
                else if (rb_Country.Checked)
                {
                    analysis.SearchType = 3;
                    analysis.SQLSearch = PatentCountrySearch;
                }
                else if (rb_Kind.Checked)
                {
                    analysis.SearchType = 4;
                    analysis.SQLSearch = PatentKindSearch;
                }
                else if (rb_Attorney.Checked)
                {
                    analysis.SearchType =5;
                    analysis.SQLSearch = PatentAttorneySearch;
                }
                else if (rb_Status.Checked)
                {
                    analysis.SearchType = 6;
                    analysis.SQLSearch = PatentStatusSearch;
                }
                else
                {
                    analysis.SearchType = 1;
                }

                analysis.Show();
            
        }

     

    }
}
