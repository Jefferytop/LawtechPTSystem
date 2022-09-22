using System;
using System.Windows.Forms;

namespace LawtechPTSystemByFirm.SubFrom
{
    public partial class TrademarkAnalysis : Form
    {
        public TrademarkAnalysis()
        {
            InitializeComponent();
        }

        string _searchTrademarkID = "";
        public string SearchTrademarkID
        {
            get { return _searchTrademarkID; }
            set { _searchTrademarkID = value; }
        }

        string _patentCountSearch = "";
        /// <summary>
        /// 案件量統計查詢
        /// </summary>
        public string PatentCountSearch
        {
            get
            {
                _patentCountSearch = string.Format(@"select PatentYear,PatentMonth,
                                        (select count(TrademarkID) from TrademarkManagementT where year(ApplicationDate)=PatentYear and  month(ApplicationDate)=PatentMonth and TrademarkID in({0}) ) as ApplicationCount,
                                        (select count(TrademarkID) from TrademarkManagementT where year(NoticeDate)=PatentYear and  month(NoticeDate)=PatentMonth  and TrademarkID in({0}) ) as APubdateCount,
                                        (select count(TrademarkID) from TrademarkManagementT where year(RegistrationDate)=PatentYear and  month(RegistrationDate)=PatentMonth and TrademarkID in({0}) ) as AllowDateCount,
                                        (select count(TrademarkID) from TrademarkManagementT where year(CloseDate)=PatentYear and  month(CloseDate)=PatentMonth and TrademarkID in({0}) ) as CloseDateCount
                                        from(
                                        select year(ApplicationDate) as PatentYear,month(ApplicationDate) as PatentMonth   
                                        from TrademarkManagementT  with(nolock)
                                        where ApplicationDate is not null and TrademarkID in({0})
                                        group by  year(ApplicationDate),month(ApplicationDate)
                                        union 
                                        select year(NoticeDate) as PatentYear,month(NoticeDate) as PatentMonth   
                                        from TrademarkManagementT  with(nolock)
                                        where NoticeDate is not null and TrademarkID in({0})
                                        group by  year(NoticeDate),month(NoticeDate)
                                        union 
                                        select year(RegistrationDate) as PatentYear,month(RegistrationDate) as PatentMonth   
                                        from TrademarkManagementT  with(nolock) 
                                        where RegistrationDate is not null and TrademarkID in({0})
                                        group by  year(RegistrationDate),month(RegistrationDate)
                                        union 
                                        select year(CloseDate) as PatentYear,month(CloseDate) as PatentMonth   
                                        from TrademarkManagementT  with(nolock)
                                        where CloseDate is not null and TrademarkID in({0})
                                        group by  year(CloseDate),month(CloseDate)

                                        ) as PatentCount
                                        ", SearchTrademarkID);
                return _patentCountSearch;
            }
            set { _patentCountSearch = value; }
        }


        string _patentMainCustomerSearch = "";
        /// <summary>
        /// 主委託人案件統計
        /// </summary>
        public string PatentMainCustomerSearch
        {
            get
            {
                _patentMainCustomerSearch = string.Format(@"select DelegateType,ApplicantNames as CustomerName,
                                                             ISNULL(year(ApplicationDate),0 )as PatenYear,ISNULL(month(ApplicationDate),0)as PatenMonth ,count(TrademarkID) as PatentCount
                                                            from V_TrademarkList 
                                                            where DelegateType=1 and TrademarkID in( {0} ) 
                                                            group by DelegateType,ApplicantNames, ISNULL(year(ApplicationDate),0 ),ISNULL(month(ApplicationDate),0)
                                                            union
                                                            select DelegateType,MainCustomerName as CustomerName,
                                                            ISNULL( year(ApplicationDate),0) as PatenYear,ISNULL(month(ApplicationDate),0)as PatenMonth ,count(TrademarkID) as PatentCount
                                                            from V_TrademarkList 
                                                            where DelegateType=2  and TrademarkID in( {0} )
                                                            group by DelegateType,MainCustomerName, ISNULL( year(ApplicationDate),0) ,ISNULL(month(ApplicationDate),0)", SearchTrademarkID);
                return _patentMainCustomerSearch;
            }
            set { _patentMainCustomerSearch = value; }
        }

        string _patentCountrySearch = "";
        /// <summary>
        /// 國別案件統計
        /// </summary>
        public string PatentCountrySearch
        {
            get
            {
                _patentCountrySearch = string.Format(@"SELECT     CountryT.Country, CountryT.SN ,ISNULL(Year(TrademarkManagementT.ApplicationDate),0 ) as PatenYear,ISNULL(Month(TrademarkManagementT.ApplicationDate),0)as PatentMonth, COUNT(TrademarkManagementT.CountrySymbol) AS CountryCount
                                                            FROM         TrademarkManagementT LEFT OUTER JOIN
                                                                         CountryT ON TrademarkManagementT.CountrySymbol = CountryT.CountrySymbol
                                                            WHERE     (TrademarkManagementT.CountrySymbol IS NOT NULL) and TrademarkID in({0})
                                                            GROUP BY TrademarkManagementT.CountrySymbol, CountryT.Country, CountryT.SN,ISNULL(Year(TrademarkManagementT.ApplicationDate),0 ),ISNULL(Month(TrademarkManagementT.ApplicationDate),0)
                                                            ORDER BY CountryT.SN,PatenYear,PatentMonth
                                                        ", SearchTrademarkID);
                return _patentCountrySearch;
            }
            set { _patentCountrySearch = value; }
        }

        string _patentKindSearch = "";
        /// <summary>
        /// 種類案件統計
        /// </summary>
        public string PatentKindSearch
        {
            get
            {
                _patentKindSearch = string.Format(@"SELECT     TrademarkManagementT.TMTypeName as kind,ISNULL( Year(TrademarkManagementT.ApplicationDate),0) as PatenYear,ISNULL(Month(TrademarkManagementT.ApplicationDate) ,0)as PatentMonth, COUNT(TrademarkManagementT.TMTypeName) AS KindCount
                                                            FROM         TrademarkManagementT 
                                                            WHERE     (TrademarkManagementT.TMTypeName IS NOT NULL)  and TrademarkID in({0})
                                                            GROUP BY TrademarkManagementT.TMTypeName, Year(TrademarkManagementT.ApplicationDate),Month(TrademarkManagementT.ApplicationDate)
                                                            ORDER BY TrademarkManagementT.TMTypeName,PatenYear,PatentMonth
                                                    ", SearchTrademarkID);
                return _patentKindSearch;
            }
            set { _patentKindSearch = value; }
        }

        string _patentAttorneySearch = "";
        /// <summary>
        /// 承辦事務所統計
        /// </summary>
        public string PatentAttorneySearch
        {
            get
            {
                _patentAttorneySearch = string.Format(@"select 
                                                            ISNULL(year(TrademarkManagementT.ApplicationDate) ,0)as PatenYear,ISNULL(month(TrademarkManagementT.ApplicationDate),0)as PatenMonth,
                                                            '本所' as AttorneyName,count(TrademarkID)as PatentCount
                                                            from TrademarkManagementT
                                                            where ( (DelegateType=1 and IsBySelf=1 ) or DelegateType=2) and TrademarkID in({0})
                                                            group by  year(TrademarkManagementT.ApplicationDate) ,month(TrademarkManagementT.ApplicationDate)
                                                            union
                                                            select 
                                                            ISNULL(year(TrademarkManagementT.ApplicationDate),0) as PatenYear,ISNULL(month(TrademarkManagementT.ApplicationDate),0)as PatenMonth,
                                                            AttorneyT.AttorneyFirm as AttorneyName,count(TrademarkID)as PatentCount
                                                            from TrademarkManagementT LEFT OUTER JOIN
                                                                                  AttorneyT ON TrademarkManagementT.OutsourcingAttorney = AttorneyT.AttorneyKey
                                                            where DelegateType=1 and IsBySelf=0 and TrademarkID in({0})
                                                            group by  year(TrademarkManagementT.ApplicationDate) ,month(TrademarkManagementT.ApplicationDate),AttorneyT.AttorneyFirm", SearchTrademarkID);
                return _patentAttorneySearch;
            }
            set { _patentAttorneySearch = value; }
        }




        private void but_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void but_OK_Click(object sender, EventArgs e)
        {
            ReportView.TrademarkAnalysis analysis = new LawtechPTSystemByFirm.ReportView.TrademarkAnalysis();

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
                analysis.SearchType = 5;
                analysis.SQLSearch = PatentAttorneySearch;
            }
            else
            {
                analysis.SearchType = 1;
            }

            analysis.Show();
        }
    }
}
