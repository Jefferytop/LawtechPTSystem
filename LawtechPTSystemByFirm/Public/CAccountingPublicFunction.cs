using H3Operator.DBHelper;
using System.Data;

namespace LawtechPTSystemByFirm.Public
{
    /// <summary>
    /// 帳務管理公用方法
    /// </summary>
    public class CAccountingPublicFunction
    {
        #region 取得專利V_PATControlPayment的資料  public static DataRow GetPATControlPaymentDataRow(string strPaymentID)
        /// <summary>
        /// 取得專利V_PATControlPayment的資料
        /// </summary>
        /// <param name="strPaymentID"></param>
        /// <returns></returns>
        public static DataRow GetPATControlPaymentDataRow(string strPaymentID)
        {
            string strSQL = string.Format(@"SELECT     'Pat' AS CaseType, '專利' AS CaseTypeName,PatentID as MainKey, *
                                        FROM        V_PATControlPayment  where PaymentID={0}", strPaymentID);

            DBAccess dbhelper = new DBAccess();
            System.Data.DataTable dtTrademarkWorkReport = new System.Data.DataTable();
            dbhelper.QueryToDataTableByDataAdapter(strSQL, ref dtTrademarkWorkReport);
            if (dtTrademarkWorkReport.Rows.Count == 1)
            {
                return dtTrademarkWorkReport.Rows[0];
            }
            else
            {
                return null;
            }
        }
        #endregion


        #region GetPATControlPayment 取得專利付款的資料  public System.Data.DataSet GetPATControlPayment(string strWhere)
        /// <summary>
        /// 取得付款的資料
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static System.Data.DataSet GetPATControlPayment(string strWhere)
        {

            strWhere = strWhere.Replace("EventNo", "PatentNo");

            string strPatentFeeSQL = string.Format(
                                    @"SELECT     'Pat' AS CaseType, '專利' AS CaseTypeName,PatentID as MainKey, *
                                        FROM        V_PATControlPayment  where {0};

select sum(Totall) as Total ,IMoney,'專利' AS CaseTypeName
FROM        V_PATControlPayment
where {0}
group by IMoney

", strWhere);

            Public.DLL dll = new LawtechPTSystemByFirm.Public.DLL();
            System.Data.DataSet dsFeeEvent = new System.Data.DataSet();
            dsFeeEvent = dll.SqlDataAdapterDataSet(strPatentFeeSQL);
            return dsFeeEvent;
        }
        #endregion

        #region  取得商標付款的資料  public System.Data.DataSet GetTrademarkControlPaymentList(string strWhere)
        /// <summary>
        /// 取得商標付款的資料
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static System.Data.DataSet GetTrademarkControlPaymentList(string strWhere)
        {

            strWhere = strWhere.Replace("EventNo", "TrademarkNo");

            string strPatentFeeSQL = string.Format(
                                    @"SELECT     'Tm' AS CaseType, '商標' AS CaseTypeName, TrademarkID as MainKey,*
                                    FROM       V_TrademarkControlPaymentList  
                                                        where {0};

select sum(Totall) as Total ,IMoney,'商標' AS CaseTypeName
FROM        V_TrademarkControlPaymentList
where {0}
group by  IMoney
", strWhere);

            Public.DLL dll = new LawtechPTSystemByFirm.Public.DLL();
            System.Data.DataSet dtFeeEvent = new System.Data.DataSet();
            dtFeeEvent = dll.SqlDataAdapterDataSet(strPatentFeeSQL);
            return dtFeeEvent;
        }
        #endregion

        #region  取得專利應收應付總表的資料 public static void GetAccountingCombinListPatent(string strWhere, ref DataTable dtSource)
        /// <summary>
        /// 取得專利應收應付總表的資料 V_AccountingCombinList_Patent
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static void GetAccountingCombinListPatent(string strWhere, ref DataTable dtSource)
        {

            string strSQL = string.Format(@"SELECT *  from  V_AccountingCombinList_Patent with(nolock)  {0}", !string.IsNullOrEmpty(strWhere.Trim()) ? " where " + strWhere : "");

            DBAccess dbhelper = new DBAccess();
            dtSource.Rows.Clear();
            dbhelper.QueryToDataTableByDataAdapter(strSQL, ref dtSource);

            if (dtSource.PrimaryKey.Length == 0)
            {
                DataColumn[] pk = { dtSource.Columns["PatentID"] };
                dtSource.PrimaryKey = pk;
            }
        }
        #endregion

        #region  取得專利應收應付總表的資料 public static void GetAccountingCombinListPatentSUM(string strWhere, ref DataTable dtSource)
        /// <summary>
        /// 取得專利應收應付總表的資料 V_AccountingCombinList_Patent
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static void GetAccountingCombinListPatentSUM(string strWhere, ref DataTable dtSource)
        {

            string strSQL = string.Format(@"SELECT SUM(SUM_PracticalityFee) as TotalPracticalityFee,SUM(SUM_PracticalityPayment) as TotalPracticalityPayment,SUM(Profit) as TotalProfit from  V_AccountingCombinList_Patent with(nolock)  {0}", !string.IsNullOrEmpty(strWhere.Trim()) ? " where " + strWhere : "");

            DBAccess dbhelper = new DBAccess();
            dtSource.Rows.Clear();
            dbhelper.QueryToDataTableByDataAdapter(strSQL, ref dtSource);
           
        }
        #endregion

        #region  取得商標應收應付總表的資料 public static void GetAccountingCombinListPatent(string strWhere, ref DataTable dtSource)
        /// <summary>
        /// 取得商標應收應付總表的資料 V_AccountingCombinList_Trademark
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static void GetAccountingCombinListTrademark(string strWhere, ref DataTable dtSource)
        {

            string strSQL = string.Format(@"SELECT *  from  V_AccountingCombinList_Trademark with(nolock)  {0}", !string.IsNullOrEmpty(strWhere.Trim()) ? " where " + strWhere : "");

            DBAccess dbhelper = new DBAccess();
            dtSource.Rows.Clear();
            dbhelper.QueryToDataTableByDataAdapter(strSQL, ref dtSource);

            if (dtSource.PrimaryKey.Length == 0)
            {
                DataColumn[] pk = { dtSource.Columns["TrademarkID"] };
                dtSource.PrimaryKey = pk;
            }
        }
        #endregion


        #region  取得商標應收應付總表的資料 public static void GetAccountingCombinListTrademarkSUM(string strWhere, ref DataTable dtSource)
        /// <summary>
        /// 取得專利應收應付總表的資料 V_AccountingCombinList_Patent
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static void GetAccountingCombinListTrademarkSUM(string strWhere, ref DataTable dtSource)
        {

            string strSQL = string.Format(@"SELECT SUM(SUM_PracticalityFee) as TotalPracticalityFee,SUM(SUM_PracticalityPayment) as TotalPracticalityPayment,SUM(Profit) as TotalProfit from  V_AccountingCombinList_Trademark with(nolock)  {0}", !string.IsNullOrEmpty(strWhere.Trim()) ? " where " + strWhere : "");

            DBAccess dbhelper = new DBAccess();
            dtSource.Rows.Clear();
            dbhelper.QueryToDataTableByDataAdapter(strSQL, ref dtSource);

        }
        #endregion


    }
}
