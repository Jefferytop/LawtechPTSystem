using H3Operator.DBHelper;
using System.Data;

namespace LawtechPTSystemByFirm.Public
{
    /// <summary>
    /// 商標 的共用方法
    /// </summary>
    public class CTrademarkPublicFunction
    {
        #region GetTrademarkList 取得商標的資料 public static DataRow GetTrademarkList(string strTrademarkID)
        /// <summary>
        /// 取得商標的資料
        /// </summary>
        /// <param name="strTrademarkID"></param>
        /// <returns></returns>
        public static DataRow GetTrademarkList(string strTrademarkID)
        {

            string strSQL = string.Format(@"SELECT *  from  V_TrademarkList where TrademarkID= {0}", strTrademarkID);

            DBAccess dbhelper = new DBAccess();
            System.Data.DataTable dtTrademark = new System.Data.DataTable();
            dbhelper.QueryToDataTableByDataAdapter(strSQL, ref dtTrademark);

            if (dtTrademark.Rows.Count == 1)
            {
                return dtTrademark.Rows[0];
            }
            else
            {
                return null;
            }

        }
        #endregion 

        #region GetComitEvent 取得事件的資料 public static DataRow GetTrademarkEvent(string strTMNotifyEventID)
        /// <summary>
        /// 取得商標事件的資料
        /// </summary>
        /// <param name="strTMNotifyEventID"></param>
        /// <returns></returns>
        public static DataRow GetTrademarkEvent(string strTMNotifyEventID)
        {
            string strSQL = string.Format(@"SELECT * from  V_TrademarkNotifyEventT where TMNotifyEventID={0}", strTMNotifyEventID);

            DBAccess dbhelper = new DBAccess();
            System.Data.DataTable dtTrademarkEvent = new System.Data.DataTable();
            dbhelper.QueryToDataTableByDataAdapter(strSQL, ref dtTrademarkEvent);
            if (dtTrademarkEvent.Rows.Count == 1)
            {
                return dtTrademarkEvent.Rows[0];
            }
            else
            {
                return null;
            }
        }
        #endregion

        #region GetTrademarkEstimateCost 取得預估成本的資料 public static DataRow GetTrademarkEstimateCost(string strEstimateCostID)
        /// <summary>
        /// 取得預估成本的資料
        /// </summary>
        /// <param name="strEstimateCostID"></param>
        /// <returns></returns>
        public static DataRow GetTrademarkEstimateCost(string strEstimateCostID)
        {
            string strSQL = string.Format(@"SELECT * from  TrademarkEstimateCostT where TMEstimateCostID={0}", strEstimateCostID);

            DBAccess dbhelper = new DBAccess();
            System.Data.DataTable dtTrademarkEstimateCost = new System.Data.DataTable();
            dbhelper.QueryToDataTableByDataAdapter(strSQL, ref dtTrademarkEstimateCost);
            if (dtTrademarkEstimateCost.Rows.Count == 1)
            {
                return dtTrademarkEstimateCost.Rows[0];
            }
            else
            {
                return null;
            }
        }
        #endregion

        #region GetTrademarkFee 取得商標請款的資料  public static DataRow GetTrademarkFee(string strFeeKEY)
        /// <summary>
        /// 取得商標請款的資料
        /// </summary>
        /// <param name="FeeKEY"></param>
        /// <returns></returns>
        public static DataRow GetTrademarkFee(string strFeeKEY)
        {
            string strSQL = string.Format(@"SELECT * from  V_TrademarkFeeT where FeeKEY={0}", strFeeKEY);

            DBAccess dbhelper = new DBAccess();
            System.Data.DataTable dtTrademarkEstimateCost = new System.Data.DataTable();
            dbhelper.QueryToDataTableByDataAdapter(strSQL, ref dtTrademarkEstimateCost);
            if (dtTrademarkEstimateCost.Rows.Count == 1)
            {
                return dtTrademarkEstimateCost.Rows[0];
            }
            else
            {
                return null;
            }
        }
        #endregion

        #region GetTrademarkPayment 取得商標付款的資料  public static DataRow GetTrademarkPayment(string strPaymentID)
        /// <summary>
        /// 取得商標付款的資料
        /// </summary>
        /// <param name="strPaymentID"></param>
        /// <returns></returns>
        public static DataRow GetTrademarkPayment(string strPaymentID)
        {
            string strSQL = string.Format(@"SELECT * from  V_TrademarkPaymentT with(nolock) where PaymentID={0}", strPaymentID);

            DBAccess dbhelper = new DBAccess();
            System.Data.DataTable dtTrademarkEstimateCost = new System.Data.DataTable();
            dbhelper.QueryToDataTableByDataAdapter(strSQL, ref dtTrademarkEstimateCost);
            if (dtTrademarkEstimateCost.Rows.Count == 1)
            {
                return dtTrademarkEstimateCost.Rows[0];
            }
            else
            {
                return null;
            }
        }
        #endregion

        #region GetTrademarkWorkReport 取得商標作業確認項目的資料  public static DataRow GetTrademarkWorkReport(string strWorkReportID)
        /// <summary>
        /// 取得商標作業確認項目的資料
        /// </summary>
        /// <param name="WorkReportID"></param>
        /// <returns></returns>
        public static DataRow GetTrademarkWorkReport(string strWorkReportID)
        {
            string strSQL = string.Format(@"SELECT * from  V_TrademarkWorkReportT where WorkReportID={0}", strWorkReportID);

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

        #region GetTrademarkEventList 取得事件的資料
        /// <summary>
        /// 取得V_TrademarkEventList事件的資料
        /// </summary>
        /// <param name="strTMNotifyEventID"></param>
        /// <returns></returns>
        public static DataRow GetTrademarkEventList(string strTMNotifyEventID)
        {

            string strNotifyEventSQL = string.Format(@"SELECT *  from  V_TrademarkEventList  where TMNotifyEventID={0}", strTMNotifyEventID);

            Public.DLL dll = new LawtechPTSystemByFirm.Public.DLL();
            System.Data.DataTable dtComitEvent = new System.Data.DataTable();
            dll.FetchDataTable(strNotifyEventSQL, dtComitEvent);
            if (dtComitEvent.Rows.Count == 1)
            {
                return dtComitEvent.Rows[0];
            }
            else
            {
                return null;
            }
           
        }
        #endregion 


        #region GetTrademarkList 取得商標的資料 public static void GetTrademarkList(string strWhere, ref DataTable dtSource)
        /// <summary>
        /// 取得商標的資料
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static void GetTrademarkList(string strWhere, ref DataTable dtSource)
        {

            string strSQL = string.Format(@"SELECT *  from  V_TrademarkList with(nolock) {0}", !string.IsNullOrEmpty(strWhere) ? " where " + strWhere : "");

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

        #region GetComitEvent 取得事件的資料 public static void GetTrademarkEvent(string strTrademarkID, ref DataTable dtSource)
        /// <summary>
        /// 取得商標事件的資料
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static void GetTrademarkEvent(string strTrademarkID, ref DataTable dtSource)
        {
            string strSQL = string.Format(@"SELECT * from  V_TrademarkNotifyEventT with(nolock) where TrademarkID={0}", strTrademarkID);

            DBAccess dbhelper = new DBAccess();
            dtSource.Rows.Clear();
            dbhelper.QueryToDataTableByDataAdapter(strSQL, ref dtSource);

            if (dtSource.PrimaryKey.Length == 0)
            {
                DataColumn[] pk = { dtSource.Columns["TMNotifyEventID"] };
                dtSource.PrimaryKey = pk;
            }
        }
        #endregion

        #region GetTrademarkFee 取得商標請款的資料  public static void GetTrademarkFee(string strTrademarkID, ref DataTable dtSource)
        /// <summary>
        /// 取得商標請款的資料
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static void GetTrademarkFee(string strTrademarkID, ref DataTable dtSource)
        {

            string strSQL = string.Format(@"SELECT * from  V_TrademarkFeeT with(nolock) where TrademarkID={0}", strTrademarkID);

            DBAccess dbhelper = new DBAccess();
            dtSource.Rows.Clear();
            dbhelper.QueryToDataTableByDataAdapter(strSQL, ref dtSource);
            if (dtSource.PrimaryKey.Length == 0)
            {
                DataColumn[] pk = { dtSource.Columns["FeeKEY"] };
                dtSource.PrimaryKey = pk;
            }
        }
        #endregion

        #region GetTrademarkPayment 取得商標付款的資料 public static void GetTrademarkPayment(string strTrademarkID, ref DataTable dtSource)
        /// <summary>
        /// 取得商標付款的資料
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static void GetTrademarkPayment(string strTrademarkID, ref DataTable dtSource)
        {

            string strSQL = string.Format(@"SELECT * from  V_TrademarkPaymentT with(nolock) where TrademarkID={0}", strTrademarkID);

            DBAccess dbhelper = new DBAccess();
            dtSource.Rows.Clear();
            dbhelper.QueryToDataTableByDataAdapter(strSQL, ref dtSource);

            if (dtSource.PrimaryKey.Length == 0)
            {
                DataColumn[] pk = { dtSource.Columns["PaymentID"] };
                dtSource.PrimaryKey = pk;
            }
        }
        #endregion

        #region GetTrademarkEstimateCost 取得商標預估費用的資料  public static void GetTrademarkEstimateCost(string strTrademarkID, ref DataTable dtSource)
        /// <summary>
        /// 取得商標預估費用的資料
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static void GetTrademarkEstimateCost(string strTrademarkID, ref DataTable dtSource)
        {

            string strSQL = string.Format(@"SELECT * from  TrademarkEstimateCostT with(nolock) where TrademarkID={0}", strTrademarkID);

            DBAccess dbhelper = new DBAccess();
            dtSource.Rows.Clear();
            dbhelper.QueryToDataTableByDataAdapter(strSQL, ref dtSource);
            if (dtSource.PrimaryKey.Length == 0)
            {
                DataColumn[] pk = { dtSource.Columns["TMEstimateCostID"] };
                dtSource.PrimaryKey = pk;
            }
        }
        #endregion 

        #region GetTrademarkWorkReportT 取得商標作業確認項目的資料  public static void GetTrademarkEstimateCost(string strTrademarkID, ref DataTable dtSource)
        /// <summary>
        /// 取得商標作業確認項目的資料
        /// </summary>
        /// <param name="strEventType"></param>
        /// <param name="strEventID"></param>
        /// <returns></returns>
        public static void GetTrademarkWorkReportT(string strEventType, string strEventID, ref DataTable dtSource)
        {

            string strSQL = string.Format(@"SELECT * from  V_TrademarkWorkReportT with(nolock) where EventType={0} and EventID={1}", strEventType, strEventID);

            DBAccess dbhelper = new DBAccess();
            dtSource.Rows.Clear();
            dbhelper.QueryToDataTableByDataAdapter(strSQL, ref dtSource);
            if (dtSource.PrimaryKey.Length == 0)
            {
                DataColumn[] pk = { dtSource.Columns["WorkReportID"] };
                dtSource.PrimaryKey = pk;
            }
        }
        #endregion 

        #region 取得商標案件績效表的資料 public static void GetTrademarkPerformanceBonus(string strWhere, ref DataTable dtSource)
        /// <summary>
        /// 取得商標案件績效表的資料 V_PatentPerformanceBonus
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static void GetTrademarkPerformanceBonus(string strWhere, ref DataTable dtSource)
        {

            string strSQL = string.Format(@"SELECT *  from  V_TrademarkPerformanceBonus with(nolock)  {0}", !string.IsNullOrEmpty(strWhere.Trim()) ? " where " + strWhere : "");

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

        #region 取得事件By User的資料  public static void GetPatentEventByUser(string strPatentID,int Userkey, ref DataTable dtSource)
        /// <summary>
        /// 取得商標事件的資料 By User( V_PatComitEventT )
        /// </summary>
        /// <param name="strTrademarkID"></param>
        /// <returns></returns>
        public static void GetTrademarkEventByUser(string strTrademarkID, int Userkey, ref DataTable dtSource)
        {
            string strSQL = string.Format(@"SELECT * from  V_TrademarkNotifyEventT with(nolock) where TrademarkID={0} and WorkerKey={1}", strTrademarkID, Userkey.ToString());

            DBAccess dbhelper = new DBAccess();
            dtSource.Rows.Clear();
            dbhelper.QueryToDataTableByDataAdapter(strSQL, ref dtSource);

            if (dtSource.PrimaryKey.Length == 0)
            {
                DataColumn[] pk = { dtSource.Columns["TMNotifyEventID"] };
                dtSource.PrimaryKey = pk;
            }
        }
        #endregion

        #region 取得商標請款By User的資料 public static void GetTrademarkFeeByUser(string strTrademarkID,int Userkey, ref DataTable dtSource)
        /// <summary>
        /// 取得商標請款的資料 By User (V_TrademarkFeeT)
        /// </summary>
        /// <param name="strTrademarkID"></param>
        /// <param name="Userkey"></param>
        /// <returns></returns>
        public static void GetTrademarkFeeByUser(string strTrademarkID, int Userkey, ref DataTable dtSource)
        {

            string strSQL = string.Format(@"SELECT * from  V_TrademarkFeeT with(nolock) where TrademarkID={0} and FClientTransactor={1}", strTrademarkID, Userkey.ToString());

            DBAccess dbhelper = new DBAccess();
            dtSource.Rows.Clear();
            dbhelper.QueryToDataTableByDataAdapter(strSQL, ref dtSource);

            if (dtSource.PrimaryKey.Length == 0)
            {
                DataColumn[] pk = { dtSource.Columns["FeeKEY"] };
                dtSource.PrimaryKey = pk;
            }
        }
        #endregion

        #region 取得商標付款的資料 public static void GetTrademarkPaymentByUser(string strTrademarkID, int Userkey, ref DataTable dtSource)
        /// <summary>
        /// 取得商標付款的資料 By User (V_TrademarkPaymentT)
        /// </summary>
        /// <param name="strTrademarkID"></param>
        /// <param name="Userkey"></param>
        /// <returns></returns>
        public static void GetTrademarkPaymentByUser(string strTrademarkID, int Userkey, ref DataTable dtSource)
        {

            string strSQL = string.Format(@"SELECT * from  V_TrademarkPaymentT with(nolock) where TrademarkID={0} and FClientTransactor={1}", strTrademarkID, Userkey.ToString());

            DBAccess dbhelper = new DBAccess();
            dtSource.Rows.Clear();
            dbhelper.QueryToDataTableByDataAdapter(strSQL, ref dtSource);

            if (dtSource.PrimaryKey.Length == 0)
            {
                DataColumn[] pk = { dtSource.Columns["PaymentID"] };
                dtSource.PrimaryKey = pk;
            }
        }
        #endregion


    }

}
