using H3Operator.DBHelper;
using System.Data;

namespace LawtechPTSystem.Public
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
            dbhelper.QueryToDataTableByDataAdapter(strSQL, ref dtTrademarkWorkReport, isFillSchema: false);
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

        #region 取得入款公司 V_AcountingFirm 的資料  public static DataRow GetAcountingFirmTDataRow(string strAcountingFirmKey)
        /// <summary>
        /// 取得入款公司 V_AcountingFirm 的資料
        /// </summary>
        /// <param name="strAcountingFirmKey"></param>
        /// <returns></returns>
        public static DataRow GetAcountingFirmTDataRow(string strAcountingFirmKey)
        {
            string strSQL = string.Format(@"SELECT     *   FROM    V_AcountingFirm  where AcountingFirmKey={0}", strAcountingFirmKey);

            DBAccess dbhelper = new DBAccess();
            System.Data.DataTable dtAcountingFirm = new System.Data.DataTable();
            dbhelper.QueryToDataTableByDataAdapter(strSQL, ref dtAcountingFirm, isFillSchema: false);
            if (dtAcountingFirm.Rows.Count == 1)
            {
                return dtAcountingFirm.Rows[0];
            }
            else
            {
                return null;
            }
        }
        #endregion

        #region 取得公司帳戶 V_AcountingFirmDetailT 的資料  public static DataRow GetAcountingFirmDetailTDataRow(string strAcountingBankKey)
        /// <summary>
        /// 取得公司帳戶 V_AcountingFirmDetailT 的資料
        /// </summary>
        /// <param name="strAcountingBankKey"></param>
        /// <returns></returns>
        public static DataRow GetAcountingFirmDetailTDataRow(string strAcountingBankKey)
        {
            string strSQL = string.Format(@"SELECT     *   FROM    V_AcountingFirmDetailT  where AcountingBankKey={0}", strAcountingBankKey);

            DBAccess dbhelper = new DBAccess();
            System.Data.DataTable dtAcountingFirm = new System.Data.DataTable();
            dbhelper.QueryToDataTableByDataAdapter(strSQL, ref dtAcountingFirm, isFillSchema: false);
            if (dtAcountingFirm.Rows.Count == 1)
            {
                return dtAcountingFirm.Rows[0];
            }
            else
            {
                return null;
            }
        }
        #endregion


        #region 取得入帳公司的資料  public static void GetAcountingFirmTList(string strWhere, ref DataTable dtSource)
        /// <summary>
        /// 取得入帳公司的資料
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static void GetAcountingFirmTList(string strWhere, ref DataTable dtSource)
        {

            string strSQL = string.Format(@"SELECT *  from  V_AcountingFirm with(nolock)  {0} order by Sort", !string.IsNullOrEmpty(strWhere.Trim()) ? " where " + strWhere : "");

            DBAccess dbhelper = new DBAccess();
            dtSource.Rows.Clear();
            dbhelper.QueryToDataTableByDataAdapter(strSQL, ref dtSource, isFillSchema: false);

            if (dtSource.PrimaryKey.Length == 0)
            {
                DataColumn[] pk = { dtSource.Columns["AcountingFirmKey"] };
                dtSource.PrimaryKey = pk;
            }
        }
        #endregion

        #region 取得入帳公司的資料  public static void GetAcountingFirmTDropDownList( ref DataTable dtSource)
        /// <summary>
        /// 取得入帳公司的資料 DropDown 下拉選單
        /// </summary>
        /// <param name="dtSource"></param>
        /// <returns></returns>
        public static void GetAcountingFirmTDropDownList( ref DataTable dtSource)
        {
            string strSQL = string.Format(@"SELECT AcountingFirmKey,AcountingFirmName  from  V_AcountingFirm with(nolock)  where IsEnable='True' order by Sort");

            DBAccess dbhelper = new DBAccess();
            dtSource.Rows.Clear();
            dbhelper.QueryToDataTableByDataAdapter(strSQL, ref dtSource, isFillSchema: false);

            if (dtSource.PrimaryKey.Length == 0)
            {
                DataColumn[] pk = { dtSource.Columns["AcountingFirmKey"] };
                dtSource.PrimaryKey = pk;
            }
        }
        #endregion


        #region 取得公司帳戶的資料   public static void GetAcountingFirmDetailTList(string strAcountingFirmKey, ref DataTable dtSource)
        /// <summary>
        /// 取得公司帳戶的資料
        /// </summary>
        /// <param name="strAcountingFirmKey"></param>
        /// <param name="dtSource"></param>
        /// <returns></returns>
        public static void GetAcountingFirmDetailTList(string strAcountingFirmKey, ref DataTable dtSource)
        {

            string strSQL = string.Format(@"SELECT *  from  V_AcountingFirmDetailT with(nolock)  where AcountingFirmKey={0} order by Sort", strAcountingFirmKey);

            DBAccess dbhelper = new DBAccess();
            dtSource.Rows.Clear();
            dbhelper.QueryToDataTableByDataAdapter(strSQL, ref dtSource, isFillSchema: false);

            if (dtSource.PrimaryKey.Length == 0)
            {
                DataColumn[] pk = { dtSource.Columns["AcountingBankKey"] };
                dtSource.PrimaryKey = pk;
            }
        }
        #endregion

        #region 取得公司帳戶的資料   public static void GetAcountingFirmDetailTList(string strAcountingFirmKey, ref DataTable dtSource)
        /// <summary>
        /// 取得公司帳戶的資料
        /// </summary>
        /// <param name="strAcountingFirmKey"></param>
        /// <param name="dtSource"></param>
        /// <returns></returns>
        public static void GetAcountingFirmDetailDropDownTList(string strAcountingFirmKey, ref DataTable dtSource)
        {

            string strSQL = string.Format(@"SELECT AcountingBankKey, BankName+'-'+BankAccount as BankInfo  from  V_AcountingFirmDetailT with(nolock)  where IsEnable='True' and  AcountingFirmKey={0} order by Sort", strAcountingFirmKey);

            DBAccess dbhelper = new DBAccess();
            dtSource.Rows.Clear();
            dbhelper.QueryToDataTableByDataAdapter(strSQL, ref dtSource, isFillSchema: false);

            if (dtSource.PrimaryKey.Length == 0)
            {
                DataColumn[] pk = { dtSource.Columns["AcountingBankKey"] };
                dtSource.PrimaryKey = pk;
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
group by IMoney;

SELECT  SUM(ActuallyPay) as ActuallyPay
                                      FROM       V_PATControlPayment where   {0};

", strWhere);

            Public.DLL dll = new LawtechPTSystem.Public.DLL();
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
group by  IMoney;

SELECT  SUM(ActuallyPay) as ActuallyPay
                                      FROM       V_TrademarkControlPaymentList  where   {0};
", strWhere);

            Public.DLL dll = new LawtechPTSystem.Public.DLL();
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
        /// <param name="dtSource"></param>
        /// <returns></returns>
        public static void GetAccountingCombinListPatent(string strWhere, ref DataTable dtSource)
        {

            string strSQL = string.Format(@"SELECT *  from  V_AccountingCombinList_Patent with(nolock)  {0}", !string.IsNullOrEmpty(strWhere.Trim()) ? " where " + strWhere : "");

            DBAccess dbhelper = new DBAccess();
            dtSource.Rows.Clear();
            dbhelper.QueryToDataTableByDataAdapter(strSQL, ref dtSource, isFillSchema: false);

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
            dbhelper.QueryToDataTableByDataAdapter(strSQL, ref dtSource, isFillSchema: false);

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
