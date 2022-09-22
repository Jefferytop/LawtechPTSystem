using System;
using System.Windows.Forms;

namespace LawtechPTSystem.SubFrom
{
    /// <summary>
    /// 專利案件量費用統計
    /// </summary>
    public partial class PatentFeeStatistics : Form
    {

        string _searchPatentID = "";
        public string SearchPatentID
        {
            get { return _searchPatentID; }
            set { _searchPatentID = value; }
        }

        string _patentCountSearch = "";
        /// <summary>
        /// 案件量費用統計查詢
        /// </summary>
        public string PatentFeeCountSearch
        {
            get
            {
                _patentCountSearch = string.Format(@"SELECT      1 AS 'FeeType',ISNULL(YEAR(PatentFeeT.PayDate),0) AS PatentYear,ISNULL( MONTH(PatentFeeT.PayDate),0) AS PatentMonth, SUM(PatentFeeT.OAttorneyGovFee) 
                                                                              AS GovFeeTotal, ISNULL(SUM(PatentFeeT.PracticalityPay),0) AS total
                                                        FROM         PatentManagementT INNER JOIN
                                                                              PatentFeeT ON PatentManagementT.PatentID = PatentFeeT.PatentID
                                                        WHERE     (PatentFeeT.Pay = 1)and PatentManagementT.PatentID in( {0} )
                                                        GROUP BY ISNULL(YEAR(PatentFeeT.PayDate),0),ISNULL( MONTH(PatentFeeT.PayDate),0)
                                                        union
                                                        SELECT     2 AS 'FeeType', ISNULL(YEAR(PatentPaymentT.IReceiptDate),0) AS PatentYear, ISNULL(MONTH(PatentPaymentT.IReceiptDate),0) AS PatentMonth, 
                                                                     ISnull(SUM( (PatentPaymentT.GovFee + PatentPaymentT.OtherFee)*ISnull(ExchangeRate,1)),0) AS GovFeetotal,  ISNULL(SUM(PatentPaymentT.ActuallyPay),0)*-1  AS Total
                                                        FROM  PatentManagementT INNER JOIN
                                                             PatentPaymentT ON PatentManagementT.PatentID = PatentPaymentT.PatentID
                                                        where PatentPaymentT.IReceiptDate is not null and PatentManagementT.PatentID in( {0} )
                                                        GROUP BY ISNULL(YEAR(PatentPaymentT.IReceiptDate),0),ISNULL(MONTH(PatentPaymentT.IReceiptDate),0) ", SearchPatentID);
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
                _patentMainCustomerSearch = string.Format(@"SELECT     PatentManagementT.DelegateType, 1 AS FeeType, ApplicantT.ApplicantName AS CustomerName, ISNULL(YEAR(PatentFeeT.PayDate), 0) AS PatenYear,
                                                                               ISNULL(MONTH(PatentFeeT.PayDate), 0) AS PatenMonth, SUM(PatentFeeT.OAttorneyGovFee) AS OAttorneyGovFee,ISNULL( SUM(PatentFeeT.Totall),0) AS Totall
                                                                    FROM         PatentManagementT LEFT OUTER JOIN
                                                                                  ApplicantT ON PatentManagementT.Applicant = ApplicantT.ApplicantKey RIGHT OUTER JOIN
                                                                                  PatentFeeT ON PatentManagementT.PatentID = PatentFeeT.PatentID
                                                                    WHERE     (PatentManagementT.DelegateType = 1) AND (PatentManagementT.Applicant IS NOT NULL) AND (PatentFeeT.Pay = 1)and PatentManagementT.PatentID in( {0} )
                                                                    GROUP BY PatentManagementT.DelegateType, ApplicantT.ApplicantName, YEAR(PatentFeeT.PayDate), MONTH(PatentFeeT.PayDate)

                                                                    union

                                                                    SELECT     PatentManagementT.DelegateType, 1 as FeeType,AttorneyT.AttorneyFirm AS CustomerName, ISNULL(YEAR(PatentFeeT.PayDate), 0) AS PatenYear, 
                                                                                          ISNULL(MONTH(PatentFeeT.PayDate), 0) AS PatenMonth, SUM(PatentFeeT.OAttorneyGovFee) as OAttorneyGovFee, ISNULL(SUM(PatentFeeT.Totall),0) as Totall
                                                                    FROM         PatentManagementT LEFT OUTER JOIN
                                                                                          AttorneyT ON AttorneyT.AttorneyKey = PatentManagementT.Attorney RIGHT OUTER JOIN
                                                                                          PatentFeeT ON PatentManagementT.PatentID = PatentFeeT.PatentID
                                                                    WHERE     (PatentManagementT.DelegateType = 2) AND (PatentManagementT.Applicant IS NOT NULL) AND (PatentFeeT.Pay = 1) and PatentManagementT.PatentID in( {0} )
                                                                    GROUP BY PatentManagementT.DelegateType, AttorneyT.AttorneyFirm, YEAR(PatentFeeT.PayDate), MONTH(PatentFeeT.PayDate)
                                                                    union

                                                                    --Payment
                                                                    SELECT     PatentManagementT.DelegateType, 2 AS FeeType, ApplicantT.ApplicantName AS CustomerName, ISNULL(YEAR(PatentPaymentT.IReceiptDate), 0) AS PatenYear,
                                                                               ISNULL(MONTH(PatentPaymentT.IReceiptDate), 0) AS PatenMonth, 
                                                                               sum((PatentPaymentT.GovFee + PatentPaymentT.OtherFee)* ISNULL(PatentPaymentT.ExchangeRate, 1))  AS OAttorneyGovFee,
                                                                               sum(PatentPaymentT.Totall * ISNULL(PatentPaymentT.ExchangeRate, 1) ) * - 1 AS Totall
                                                                    FROM         PatentManagementT RIGHT OUTER JOIN
                                                                                  PatentPaymentT ON PatentManagementT.PatentID = PatentPaymentT.PatentID LEFT OUTER JOIN
                                                                                  ApplicantT ON PatentManagementT.Applicant = ApplicantT.ApplicantKey
                                                                    WHERE     (PatentManagementT.DelegateType = 1) AND (PatentManagementT.Applicant IS NOT NULL) AND (PatentPaymentT.IReceiptDate is not null) and PatentManagementT.PatentID in( {0} )
                                                                    GROUP BY PatentManagementT.DelegateType, ApplicantT.ApplicantName, YEAR(PatentPaymentT.IReceiptDate),MONTH(PatentPaymentT.IReceiptDate)
                                                                    union
                                                                    --Payment
                                                                    SELECT     PatentManagementT.DelegateType, 1 AS FeeType, AttorneyT.AttorneyFirm AS CustomerName, 
                                                                               ISNULL(YEAR(PatentPaymentT.IReceiptDate), 0) AS PatenYear,
                                                                               ISNULL(MONTH(PatentPaymentT.IReceiptDate), 0) AS PatenMonth, 
                                                                               SUM((PatentPaymentT.GovFee + PatentPaymentT.OtherFee)* ISNULL(PatentPaymentT.ExchangeRate, 1)) AS OAttorneyGovFee,
                                                                               SUM(PatentPaymentT.Totall * ISNULL(PatentPaymentT.ExchangeRate, 1))*-1 AS Totall
                                                                    FROM         PatentManagementT RIGHT OUTER JOIN
                                                                                          PatentPaymentT ON PatentManagementT.PatentID = PatentPaymentT.PatentID LEFT OUTER JOIN
                                                                                          AttorneyT ON AttorneyT.AttorneyKey = PatentManagementT.Attorney
                                                                    WHERE     (PatentManagementT.DelegateType = 2) AND (PatentManagementT.Applicant IS NOT NULL) AND (PatentPaymentT.IReceiptDate is not null) and PatentManagementT.PatentID in( {0} )
                                                                    GROUP BY PatentManagementT.DelegateType, AttorneyT.AttorneyFirm, YEAR(PatentPaymentT.IReceiptDate), MONTH(PatentPaymentT.IReceiptDate)", SearchPatentID);
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
                _patentCountrySearch = string.Format(@"SELECT      1 AS 'FeeType',CountryT.Country,ISNULL(YEAR(PatentFeeT.PayDate),0) AS PatentYear,
                                                                ISNULL( MONTH(PatentFeeT.PayDate),0) AS PatentMonth, 
                                                                SUM(PatentFeeT.OAttorneyGovFee) AS GovFeeTotal, 
                                                                  ISNULL(SUM(PatentFeeT.PracticalityPay),0) AS total
                                                        FROM         PatentManagementT RIGHT OUTER JOIN
                                                                          PatentFeeT ON PatentManagementT.PatentID = PatentFeeT.PatentID LEFT OUTER JOIN
                                                                          CountryT ON PatentManagementT.CountrySymbol = CountryT.CountrySymbol
                                                        WHERE     (PatentFeeT.Pay = 1) and PatentManagementT.PatentID in({0})
                                                        GROUP BY CountryT.Country,ISNULL(YEAR(PatentFeeT.PayDate),0),ISNULL( MONTH(PatentFeeT.PayDate),0)
                                                        union
                                                        SELECT     2 AS 'FeeType', CountryT.Country, ISNULL(YEAR(PatentPaymentT.IReceiptDate), 0) AS PatentYear,
                                                                   ISNULL(MONTH(PatentPaymentT.IReceiptDate), 0) AS PatentMonth,
                                                                  ISNULL( SUM( (PatentPaymentT.GovFee + PatentPaymentT.OtherFee) * ISNULL(PatentPaymentT.ExchangeRate, 1)),0)  AS GovFeetotal, 
				                                                    ISNULL(SUM(PatentPaymentT.ActuallyPay),0) * - 1 AS Total
				                                                    FROM  PatentManagementT LEFT OUTER JOIN
				                                                          CountryT ON PatentManagementT.CountrySymbol = CountryT.CountrySymbol RIGHT OUTER JOIN
					                                                      PatentPaymentT ON PatentManagementT.PatentID = PatentPaymentT.PatentID
				                                                    WHERE     (PatentPaymentT.IReceiptDate IS NOT NULL) and PatentManagementT.PatentID in({0})
				                                                    GROUP BY  CountryT.Country, YEAR(PatentPaymentT.IReceiptDate), MONTH(PatentPaymentT.IReceiptDate)
                                                        ", SearchPatentID);
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
                _patentKindSearch = string.Format(@"SELECT     1 AS 'FeeType', KindT.Kind, ISNULL(YEAR(PatentFeeT.PayDate), 0) AS PatentYear, ISNULL(MONTH(PatentFeeT.PayDate), 0) AS PatentMonth, 
                                                                 ISNULL(SUM(PatentFeeT.OAttorneyGovFee),0) AS GovFeeTotal,
                                                                 ISNULL(SUM(PatentFeeT.PracticalityPay),0) AS total
                                                    FROM         PatentManagementT RIGHT OUTER JOIN
                                                                          KindT ON PatentManagementT.Kind = KindT.KindSN RIGHT OUTER JOIN
                                                                          PatentFeeT ON PatentManagementT.PatentID = PatentFeeT.PatentID
                                                    WHERE     (PatentFeeT.Pay = 1) and PatentManagementT.PatentID in({0})
                                                    GROUP BY  KindT.Kind , YEAR(PatentFeeT.PayDate), MONTH(PatentFeeT.PayDate)
                                                    UNION
                                                    SELECT     2 AS 'FeeType', KindT.Kind, ISNULL(YEAR(PatentPaymentT.IReceiptDate), 0) AS PatentYear,
                                                               ISNULL(MONTH(PatentPaymentT.IReceiptDate), 0) AS PatentMonth,
                                                                ISNULL( SUM( (PatentPaymentT.GovFee + PatentPaymentT.OtherFee) * ISNULL(PatentPaymentT.ExchangeRate, 1)),0)  AS GovFeetotal, 
                                                                 ISNULL(SUM(PatentPaymentT.ActuallyPay),0) * - 1 AS Total
                                                                FROM         PatentManagementT RIGHT OUTER JOIN
                                                                  KindT ON PatentManagementT.Kind = KindT.KindSN RIGHT OUTER JOIN
                                                                  PatentPaymentT ON PatentManagementT.PatentID = PatentPaymentT.PatentID
                                                                WHERE     (PatentPaymentT.IReceiptDate IS NOT NULL) and PatentManagementT.PatentID in({0})
                                                                GROUP BY KindT.Kind, YEAR(PatentPaymentT.IReceiptDate), MONTH(PatentPaymentT.IReceiptDate)
                                                    ", SearchPatentID);
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
	                                                        1 AS 'FeeType',ISNULL(year(PatentFeeT.PayDate) ,0)as PatenYear,ISNULL(month(PatentFeeT.PayDate),0)as PatenMonth,
	                                                        '本所' as AttorneyName,
                                                            SUM(PatentFeeT.OAttorneyGovFee) AS GovFeeTotal, SUM(PatentFeeT.PracticalityPay) AS total
	                                                        from PatentManagementT RIGHT OUTER JOIN
                                                             PatentFeeT ON PatentManagementT.PatentID = PatentFeeT.PatentID
	                                                        where ( (DelegateType=1 and IsBySelf=1 ) or DelegateType=2) and (PatentFeeT.Pay = 1) and PatentManagementT.PatentID in({0})
	                                                        group by  year(PatentFeeT.PayDate) ,month(PatentFeeT.PayDate)
	                                                        UNION
	                                                        select 
	                                                        2 AS 'FeeType',ISNULL(year(PatentPaymentT.IReceiptDate),0) as PatenYear,ISNULL(month(PatentPaymentT.IReceiptDate),0)as PatenMonth,
	                                                        AttorneyT.AttorneyFirm as AttorneyName,
                                                            SUM((PatentPaymentT.GovFee + PatentPaymentT.OtherFee) * ISNULL(PatentPaymentT.ExchangeRate, 1))  AS GovFeetotal, 
                                                            SUM(PatentPaymentT.Totall * ISNULL(PatentPaymentT.ExchangeRate, 1)) * - 1 AS Total
	                                                        from PatentManagementT LEFT OUTER JOIN
	                                                        AttorneyT ON PatentManagementT.Attorney = AttorneyT.AttorneyKey RIGHT OUTER JOIN
                                                              PatentPaymentT ON PatentManagementT.PatentID = PatentPaymentT.PatentID
	                                                        where DelegateType=1 and IsBySelf=0 and (PatentPaymentT.IReceiptDate IS NOT NULL) and PatentManagementT.PatentID in({0})
	                                                        group by  year(PatentPaymentT.IReceiptDate) ,month(PatentPaymentT.IReceiptDate),AttorneyT.AttorneyFirm", SearchPatentID);
                return _patentAttorneySearch;
            }
            set { _patentAttorneySearch = value; }
        }



        public PatentFeeStatistics()
        {
            InitializeComponent();
        }

        private void but_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void but_OK_Click(object sender, EventArgs e)
        {
            ReportView.PatentFeeAnalysis analysis = new LawtechPTSystem.ReportView.PatentFeeAnalysis();

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
