using System;
using System.Windows.Forms;

namespace LawtechPTSystem.SubFrom
{
    public partial class TrademarkFeeStatistics : Form
    {
        public TrademarkFeeStatistics()
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
        /// 案件量費用統計查詢
        /// </summary>
        public string PatentFeeCountSearch
        {
            get
            {
                _patentCountSearch = string.Format(@"SELECT      1 AS 'FeeType',ISNULL(YEAR(TrademarkFeeT.PayDate),0) AS PatentYear,ISNULL( MONTH(TrademarkFeeT.PayDate),0) AS PatentMonth, SUM(TrademarkFeeT.OAttorneyGovFee) 
                                                                              AS GovFeeTotal, ISNULL((SUM(TrademarkFeeT.PracticalityPay),0) AS total
                                                        FROM         TrademarkManagementT INNER JOIN
                                                                     TrademarkFeeT ON TrademarkManagementT.TrademarkID = TrademarkFeeT.TrademarkID
                                                        WHERE     (TrademarkFeeT.Pay = 1)and TrademarkManagementT.TrademarkID in( {0} )
                                                        GROUP BY ISNULL(YEAR(TrademarkFeeT.PayDate),0),ISNULL( MONTH(TrademarkFeeT.PayDate),0)
                                                        union
                                                        SELECT     2 AS 'FeeType', ISNULL(YEAR(TrademarkPaymentT.IReceiptDate),0) AS PatentYear, ISNULL(MONTH(TrademarkPaymentT.IReceiptDate),0) AS PatentMonth, 
                                                                     SUM( (TrademarkPaymentT.GovFee + TrademarkPaymentT.OtherFee)*ISnull(ExchangeRate,1)) AS GovFeetotal, ISNULL(SUM(TrademarkPaymentT.ActuallyPay),0) *-1  AS Total
                                                        FROM  TrademarkManagementT INNER JOIN
                                                             TrademarkPaymentT ON TrademarkManagementT.TrademarkID = TrademarkPaymentT.TrademarkID
                                                        where TrademarkPaymentT.IReceiptDate is not null and TrademarkManagementT.TrademarkID in( {0} )
                                                        GROUP BY ISNULL(YEAR(TrademarkPaymentT.IReceiptDate),0),ISNULL(MONTH(TrademarkPaymentT.IReceiptDate),0) ", SearchTrademarkID);
                return _patentCountSearch;
            }
            set { _patentCountSearch = value; }
        }


        string _patentMainCustomerSearch = "";
        /// <summary>
        /// 主委託人案件費用統計
        /// </summary>
        public string PatentMainCustomerSearch
        {
            get
            {
                _patentMainCustomerSearch = string.Format(@"SELECT     TrademarkManagementT.DelegateType, 1 AS FeeType, ApplicantT.ApplicantName AS CustomerName, ISNULL(YEAR(TrademarkFeeT.PayDate), 0) AS PatenYear,
                                                                               ISNULL(MONTH(TrademarkFeeT.PayDate), 0) AS PatenMonth, SUM(TrademarkFeeT.OAttorneyGovFee) AS OAttorneyGovFee, SUM(TrademarkFeeT.Totall) AS Totall
                                                                    FROM         TrademarkManagementT LEFT OUTER JOIN
                                                                                  ApplicantT ON TrademarkManagementT.ApplicantKey = ApplicantT.ApplicantKey RIGHT OUTER JOIN
                                                                                  TrademarkFeeT ON TrademarkManagementT.TrademarkID = TrademarkFeeT.TrademarkID
                                                                    WHERE     (TrademarkManagementT.DelegateType = 1) AND (TrademarkManagementT.ApplicantKey IS NOT NULL) AND (TrademarkFeeT.Pay = 1)and TrademarkManagementT.TrademarkID in( {0} )
                                                                    GROUP BY TrademarkManagementT.DelegateType, ApplicantT.ApplicantName, YEAR(TrademarkFeeT.PayDate), MONTH(TrademarkFeeT.PayDate)

                                                                    union

                                                                    SELECT     TrademarkManagementT.DelegateType, 1 as FeeType,AttorneyT.AttorneyFirm AS CustomerName, ISNULL(YEAR(TrademarkFeeT.PayDate), 0) AS PatenYear, 
                                                                                          ISNULL(MONTH(TrademarkFeeT.PayDate), 0) AS PatenMonth, SUM(TrademarkFeeT.OAttorneyGovFee) as OAttorneyGovFee, SUM(TrademarkFeeT.Totall) as Totall
                                                                    FROM         TrademarkManagementT LEFT OUTER JOIN
                                                                                          AttorneyT ON AttorneyT.AttorneyKey = TrademarkManagementT.OutsourcingAttorney RIGHT OUTER JOIN
                                                                                          TrademarkFeeT ON TrademarkManagementT.TrademarkID = TrademarkFeeT.TrademarkID
                                                                    WHERE     (TrademarkManagementT.DelegateType = 2) AND (TrademarkManagementT.ApplicantKey IS NOT NULL) AND (TrademarkFeeT.Pay = 1) and TrademarkManagementT.TrademarkID in( {0} )
                                                                    GROUP BY TrademarkManagementT.DelegateType, AttorneyT.AttorneyFirm, YEAR(TrademarkFeeT.PayDate), MONTH(TrademarkFeeT.PayDate)
                                                                    union

                                                                    --Payment
                                                                    SELECT     TrademarkManagementT.DelegateType, 2 AS FeeType, ApplicantT.ApplicantName AS CustomerName, ISNULL(YEAR(TrademarkPaymentT.IReceiptDate), 0) AS PatenYear,
                                                                               ISNULL(MONTH(TrademarkPaymentT.IReceiptDate), 0) AS PatenMonth, 
                                                                               sum((TrademarkPaymentT.GovFee + TrademarkPaymentT.OtherFee)* ISNULL(TrademarkPaymentT.ExchangeRate, 1)) * - 1 AS OAttorneyGovFee,
                                                                               sum(TrademarkPaymentT.Totall * ISNULL(TrademarkPaymentT.ExchangeRate, 1) ) * - 1 AS Totall
                                                                    FROM         TrademarkManagementT RIGHT OUTER JOIN
                                                                                  TrademarkPaymentT ON TrademarkManagementT.TrademarkID = TrademarkPaymentT.TrademarkID LEFT OUTER JOIN
                                                                                  ApplicantT ON TrademarkManagementT.ApplicantKey = ApplicantT.ApplicantKey
                                                                    WHERE     (TrademarkManagementT.DelegateType = 1) AND (TrademarkManagementT.ApplicantKey IS NOT NULL) AND (TrademarkPaymentT.IReceiptDate is not null) and TrademarkManagementT.TrademarkID in( {0} )
                                                                    GROUP BY TrademarkManagementT.DelegateType, ApplicantT.ApplicantName, YEAR(TrademarkPaymentT.IReceiptDate),MONTH(TrademarkPaymentT.IReceiptDate)
                                                                    union
                                                                    --Payment
                                                                    SELECT     TrademarkManagementT.DelegateType, 1 AS FeeType, AttorneyT.AttorneyFirm AS CustomerName, 
                                                                               ISNULL(YEAR(TrademarkPaymentT.IReceiptDate), 0) AS PatenYear,
                                                                               ISNULL(MONTH(TrademarkPaymentT.IReceiptDate), 0) AS PatenMonth, 
                                                                               SUM((TrademarkPaymentT.GovFee + TrademarkPaymentT.OtherFee)* ISNULL(TrademarkPaymentT.ExchangeRate, 1))*-1 AS OAttorneyGovFee,
                                                                               SUM(TrademarkPaymentT.Totall * ISNULL(TrademarkPaymentT.ExchangeRate, 1))*-1 AS Totall
                                                                    FROM         TrademarkManagementT RIGHT OUTER JOIN
                                                                                          TrademarkPaymentT ON TrademarkManagementT.TrademarkID = TrademarkPaymentT.TrademarkID LEFT OUTER JOIN
                                                                                          AttorneyT ON AttorneyT.AttorneyKey = TrademarkManagementT.OutsourcingAttorney
                                                                    WHERE     (TrademarkManagementT.DelegateType = 2) AND (TrademarkManagementT.ApplicantKey IS NOT NULL) AND (TrademarkPaymentT.IReceiptDate is not null) and TrademarkManagementT.TrademarkID in( {0} )
                                                                    GROUP BY TrademarkManagementT.DelegateType, AttorneyT.AttorneyFirm, YEAR(TrademarkPaymentT.IReceiptDate), MONTH(TrademarkPaymentT.IReceiptDate)", SearchTrademarkID);
                return _patentMainCustomerSearch;
            }
            set { _patentMainCustomerSearch = value; }
        }

        string _patentCountrySearch = "";
        /// <summary>
        /// 國別案件費用統計
        /// </summary>
        public string PatentCountrySearch
        {
            get
            {
                _patentCountrySearch = string.Format(@"SELECT      1 AS 'FeeType',CountryT.Country,ISNULL(YEAR(TrademarkFeeT.PayDate),0) AS PatentYear,
                                                                ISNULL( MONTH(TrademarkFeeT.PayDate),0) AS PatentMonth, 
                                                                SUM(TrademarkFeeT.OAttorneyGovFee) AS GovFeeTotal, 
                                                                SUM(TrademarkFeeT.PracticalityPay) AS total
                                                        FROM         TrademarkManagementT RIGHT OUTER JOIN
                                                                          TrademarkFeeT ON TrademarkManagementT.TrademarkID = TrademarkFeeT.TrademarkID LEFT OUTER JOIN
                                                                          CountryT ON TrademarkManagementT.Country = CountryT.CountrySymbol
                                                        WHERE     (TrademarkFeeT.Pay = 1) and TrademarkManagementT.TrademarkID in({0})
                                                        GROUP BY CountryT.Country,ISNULL(YEAR(TrademarkFeeT.PayDate),0),ISNULL( MONTH(TrademarkFeeT.PayDate),0)
                                                        union
                                                        SELECT     2 AS 'FeeType', CountryT.Country, ISNULL(YEAR(TrademarkPaymentT.IReceiptDate), 0) AS PatentYear,
                                                                   ISNULL(MONTH(TrademarkPaymentT.IReceiptDate), 0) AS PatentMonth,
                                                                   SUM( (TrademarkPaymentT.GovFee + TrademarkPaymentT.OtherFee) * ISNULL(TrademarkPaymentT.ExchangeRate, 1)) * - 1 AS GovFeetotal, 
				                                                    SUM(TrademarkPaymentT.Totall * ISNULL(TrademarkPaymentT.ExchangeRate, 1)) * - 1 AS Total
				                                                    FROM  TrademarkManagementT LEFT OUTER JOIN
			                                                          CountryT ON TrademarkManagementT.Country = CountryT.CountrySymbol RIGHT OUTER JOIN
				                                                      TrademarkPaymentT ON TrademarkManagementT.TrademarkID = TrademarkPaymentT.TrademarkID
				                                                    WHERE     (TrademarkPaymentT.IReceiptDate IS NOT NULL) and TrademarkManagementT.TrademarkID in({0})
				                                                    GROUP BY  CountryT.Country, ISNULL(YEAR(TrademarkPaymentT.IReceiptDate),0),ISNULL(MONTH(TrademarkPaymentT.IReceiptDate),0)
                                                        ", SearchTrademarkID);
                return _patentCountrySearch;
            }
            set { _patentCountrySearch = value; }
        }

        string _patentKindSearch = "";
        /// <summary>
        /// 種類案件費用統計
        /// </summary>
        public string PatentKindSearch
        {
            get
            {
                _patentKindSearch = string.Format(@"SELECT     1 AS 'FeeType', TrademarkManagementT.TMTypeName as Kind,
                                                           ISNULL(YEAR(TrademarkFeeT.PayDate), 0) AS PatentYear, 
                                                           ISNULL(MONTH(TrademarkFeeT.PayDate), 0) AS PatentMonth, 
                                                           SUM(TrademarkFeeT.OAttorneyGovFee) AS GovFeeTotal, 
                                                           SUM(TrademarkFeeT.PracticalityPay) AS total
                                                    FROM         TrademarkManagementT  RIGHT OUTER JOIN
                                                                  TrademarkFeeT ON TrademarkManagementT.TrademarkID = TrademarkFeeT.TrademarkID
                                                    WHERE     (TrademarkFeeT.Pay = 1) and TrademarkManagementT.TrademarkID in({0})
                                                    GROUP BY  TrademarkManagementT.TMTypeName, ISNULL(YEAR(TrademarkFeeT.PayDate),0),ISNULL( MONTH(TrademarkFeeT.PayDate),0)
                                                    UNION
                                                    SELECT     2 AS 'FeeType', TrademarkManagementT.TMTypeName as Kind, 
                                                               ISNULL(YEAR(TrademarkPaymentT.IReceiptDate), 0) AS PatentYear,
                                                               ISNULL(MONTH(TrademarkPaymentT.IReceiptDate), 0) AS PatentMonth,
                                                               SUM((TrademarkPaymentT.GovFee + TrademarkPaymentT.OtherFee) * ISNULL(TrademarkPaymentT.ExchangeRate, 1)) * - 1 AS GovFeetotal, 
                                                               SUM(TrademarkPaymentT.Totall * ISNULL(TrademarkPaymentT.ExchangeRate, 1)) * - 1 AS Total
                                                                FROM         TrademarkManagementT  RIGHT OUTER JOIN
                                                                  TrademarkPaymentT ON TrademarkManagementT.TrademarkID = TrademarkPaymentT.TrademarkID
                                                                WHERE     (TrademarkPaymentT.IReceiptDate IS NOT NULL) and TrademarkManagementT.TrademarkID in({0})
                                                                GROUP BY TrademarkManagementT.TMTypeName, ISNULL(YEAR(TrademarkPaymentT.IReceiptDate),0),ISNULL(MONTH(TrademarkPaymentT.IReceiptDate),0)
                                                                                                        ", SearchTrademarkID);
                return _patentKindSearch;
            }
            set { _patentKindSearch = value; }
        }

        string _patentAttorneySearch = "";
        /// <summary>
        /// 承辦事務所費用統計
        /// </summary>
        public string PatentAttorneySearch
        {
            get
            {
                _patentAttorneySearch = string.Format(@"select 
	                                                        1 AS 'FeeType',ISNULL(year(TrademarkFeeT.PayDate) ,0)as PatenYear,ISNULL(month(TrademarkFeeT.PayDate),0)as PatenMonth,
	                                                        '本所' as AttorneyName,
                                                            SUM(TrademarkFeeT.OAttorneyGovFee) AS GovFeeTotal, SUM(TrademarkFeeT.PracticalityPay) AS total
	                                                        from TrademarkManagementT RIGHT OUTER JOIN
                                                             TrademarkFeeT ON TrademarkManagementT.TrademarkID = TrademarkFeeT.TrademarkID
	                                                        where ( (DelegateType=1 and IsBySelf=1 ) or DelegateType=2) and (TrademarkFeeT.Pay = 1) and TrademarkManagementT.TrademarkID in({0})
	                                                        group by ISNULL(YEAR(TrademarkFeeT.PayDate),0),ISNULL( MONTH(TrademarkFeeT.PayDate),0)
	                                                        UNION
	                                                        select 
	                                                        2 AS 'FeeType',ISNULL(year(TrademarkPaymentT.IReceiptDate),0) as PatenYear,ISNULL(month(TrademarkPaymentT.IReceiptDate),0)as PatenMonth,
	                                                        AttorneyT.AttorneyFirm as AttorneyName,
                                                            SUM((TrademarkPaymentT.GovFee + TrademarkPaymentT.OtherFee) * ISNULL(TrademarkPaymentT.ExchangeRate, 1)) * - 1 AS GovFeetotal, 
                                                            SUM(TrademarkPaymentT.Totall * ISNULL(TrademarkPaymentT.ExchangeRate, 1)) * - 1 AS Total
	                                                        from TrademarkManagementT LEFT OUTER JOIN
	                                                        AttorneyT ON TrademarkManagementT.OutsourcingAttorney = AttorneyT.AttorneyKey RIGHT OUTER JOIN
                                                              TrademarkPaymentT ON TrademarkManagementT.TrademarkID = TrademarkPaymentT.TrademarkID
	                                                        where DelegateType=1 and IsBySelf=0 and (TrademarkPaymentT.IReceiptDate IS NOT NULL) and TrademarkManagementT.TrademarkID in({0})
	                                                        group by  AttorneyT.AttorneyFirm,ISNULL(YEAR(TrademarkPaymentT.IReceiptDate),0),ISNULL(MONTH(TrademarkPaymentT.IReceiptDate),0)", SearchTrademarkID);
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
            ReportView.TrademarkFeeAnalysis analysis = new LawtechPTSystem.ReportView.TrademarkFeeAnalysis();

            if (rb_PatentCount.Checked)
            {
                analysis.SearchType = 1;
                analysis.SQLSearch = PatentFeeCountSearch;
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
