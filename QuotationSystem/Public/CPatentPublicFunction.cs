using H3Operator.DBHelper;
using System;
using System.Data;

namespace LawtechPTSystem.Public
{
    /// <summary>
    /// 專利公用取資料的類別
    /// </summary>
    public class CPatentPublicFunction
    {
        #region 取得專利的資料 public static DataRow GetPatentListDataRow(string strPatentID)
        /// <summary>
        /// 取得專利的資料 V_PatentList
        /// </summary>
        /// <param name="strPatentID"></param>
        /// <returns></returns>
        public static DataRow GetPatentListDataRow(string strPatentID)
        {

            string strSQL = string.Format(@"SELECT *  from  V_PatentList where PatentID= {0}", strPatentID);

            DBAccess dbhelper = new DBAccess();
            System.Data.DataTable dtPatent = new System.Data.DataTable();
            dbhelper.QueryToDataTableByDataAdapter(strSQL, ref dtPatent, isFillSchema: false);

            if (dtPatent.Rows.Count == 1)
            {
                return dtPatent.Rows[0];
            }
            else
            {
                return null;
            }

        }
        #endregion 

        #region 取得專利事件記錄的資料 public static DataRow GetPatentComitEventDataRow(string strPatComitEventID)
        /// <summary>
        /// 取得專利事件記錄的資料 V_PatComitEventT
        /// </summary>
        /// <param name="strPatComitEventID"></param>
        /// <returns></returns>
        public static DataRow GetPatentComitEventDataRow(string strPatComitEventID)
        {

            string strSQL = string.Format(@"SELECT * from V_PatComitEventT where PatComitEventID= {0}", strPatComitEventID);

            DBAccess dbhelper = new DBAccess();
            System.Data.DataTable dtPatent = new System.Data.DataTable();
            dbhelper.QueryToDataTableByDataAdapter(strSQL, ref dtPatent, isFillSchema: false);

            if (dtPatent.Rows.Count == 1)
            {
                return dtPatent.Rows[0];
            }
            else
            {
                return null;
            }

        }
        #endregion 

        #region 取得專利請款的資料 public static DataRow GetPatentFeeTDataRow(string strFeeKey)
        /// <summary>
        /// 取得專利請款的資料 V_PatentFeeT
        /// </summary>
        /// <param name="strFeeKey"></param>
        /// <returns></returns>
        public static DataRow GetPatentFeeTDataRow(string strFeeKey)
        {

            string strSQL = string.Format(@"SELECT *  from  V_PatentFeeT where FeeKey= {0}", strFeeKey);

            DBAccess dbhelper = new DBAccess();
            System.Data.DataTable dtPatent = new System.Data.DataTable();
            dbhelper.QueryToDataTableByDataAdapter(strSQL, ref dtPatent, isFillSchema: false);

            if (dtPatent.Rows.Count == 1)
            {
                return dtPatent.Rows[0];
            }
            else
            {
                return null;
            }

        }
        #endregion 

        #region 取得專利付款的資料  public static DataRow GetPatentPaymentTDataRow(string strPaymentID)
        /// <summary>
        /// 取得專利付款的資料 V_PatentPaymentT
        /// </summary>
        /// <param name="strPaymentID"></param>
        /// <returns></returns>
        public static DataRow GetPatentPaymentTDataRow(string strPaymentID)
        {

            string strSQL = string.Format(@"SELECT *  from  V_PatentPaymentT where PaymentID= {0}", strPaymentID);

            DBAccess dbhelper = new DBAccess();
            System.Data.DataTable dtPatent = new System.Data.DataTable();
            dbhelper.QueryToDataTableByDataAdapter(strSQL, ref dtPatent, isFillSchema: false);

            if (dtPatent.Rows.Count == 1)
            {
                return dtPatent.Rows[0];
            }
            else
            {
                return null;
            }

        }
        #endregion 

        #region 取得預估成本的資料 public static DataRow GetPatentEstimateCost(string strPTEstimateCostID)
        /// <summary>
        /// 取得預估成本的資料 PatentEstimateCostT
        /// </summary>
        /// <param name="strPTEstimateCostID"></param>
        /// <returns></returns>
        public static DataRow GetPatentEstimateCost(string strPTEstimateCostID)
        {
            string strSQL = string.Format(@"SELECT * from  PatentEstimateCostT where PTEstimateCostID={0}", strPTEstimateCostID);

            DBAccess dbhelper = new DBAccess();
            System.Data.DataTable dtTrademarkEstimateCost = new System.Data.DataTable();
            dbhelper.QueryToDataTableByDataAdapter(strSQL, ref dtTrademarkEstimateCost, isFillSchema: false);
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

        #region 取得專利作業確認項目的資料  public static DataRow GetPatWorkReport(string strWorkReportID)
        /// <summary>
        /// 取得專利作業確認項目的資料 V_PatWorkReportT
        /// </summary>
        /// <param name="WorkReportID"></param>
        /// <returns></returns>
        public static DataRow GetPatWorkReport(string strWorkReportID)
        {
            string strSQL = string.Format(@"SELECT * from  V_PatWorkReportT where WorkReportID={0}", strWorkReportID);

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

        #region 取得專利V_PATControlEventList的資料 public static DataRow GetV_PATControlEventList(string strPatentID, string strPatComitEventID)
        /// <summary>
        /// 取得專利V_PATControlEventList的資料
        /// </summary>
        /// <param name="strPatentID"></param>
        /// <param name="strPatComitEventID"></param>
        /// <returns></returns>
        public static DataRow GetV_PATControlEventList(string strPatentID, string strPatComitEventID)
        {
            string strSQL = string.Format(@"SELECT * from  V_PATControlEventList with(nolock) where PatentID={0} and PatComitEventID={1}", strPatentID, strPatComitEventID);

            DBAccess dbhelper = new DBAccess();
            System.Data.DataTable dtPATControlEventList = new System.Data.DataTable();
            dbhelper.QueryToDataTableByDataAdapter(strSQL, ref dtPATControlEventList);
            if (dtPATControlEventList.Rows.Count == 1)
            {
                return dtPATControlEventList.Rows[0];
            }
            else
            {
                return null;
            }
        }
        #endregion

        #region  取得專利V_PATControlPayment的資料  public static DataRow GetPATControlPayment(string strPaymentID)
        /// <summary>
        /// 取得專利V_PATControlPayment的資料
        /// </summary>
        /// <param name="WorkReportID"></param>
        /// <returns></returns>
        public static DataRow GetPATControlPayment(string strPaymentID)
        {
            string strSQL = string.Format(@"SELECT * from  V_PATControlPayment with(nolock) where PaymentID={0}", strPaymentID);

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

        #region  取得專利V_PATControlFeeList的資料  public static DataRow GetPATControlFee(string strPaymentID)
        /// <summary>
        /// 取得專利V_PATControlFeeList的資料
        /// </summary>
        /// <param name="strFeeKey"></param>
        /// <returns></returns>
        public static DataRow GetPATControlFee(string strFeeKey)
        {
            string strSQL = string.Format(@"SELECT * from  V_PATControlFeeList with(nolock) where FeeKey={0}", strFeeKey);

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


        // DataRow
        // *********************************
        // DataTable

        #region  取得專利的資料 public static void GetPatentList(string strWhere, ref DataTable dtSource)
        /// <summary>
        /// 取得專利的資料 V_PatentList
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static void GetPatentList(string strWhere, ref DataTable dtSource)
        {

            string strSQL = string.Format(@"SELECT *  from  V_PatentList with(nolock)  {0}  order by PatentNo ", !string.IsNullOrEmpty(strWhere.Trim()) ? " where " + strWhere : "");

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

        #region 取得事件的資料 public static void GetPatentEvent(string strPatentID, ref DataTable dtSource)
        /// <summary>
        /// 取得專利事件的資料 V_PatComitEventT
        /// </summary>
        /// <param name="strPatentID"></param>
        /// <returns></returns>
        public static void GetPatentEvent(string strPatentID, ref DataTable dtSource)
        {
            string strSQL = string.Format(@"SELECT * from  V_PatComitEventT with(nolock) where PatentID={0} order by CreateDate ", strPatentID);

            DBAccess dbhelper = new DBAccess();
            dtSource.Rows.Clear();
            dbhelper.QueryToDataTableByDataAdapter(strSQL, ref dtSource, isFillSchema: false);

            if (dtSource.PrimaryKey.Length == 0)
            {
                DataColumn[] pk = { dtSource.Columns["PatComitEventID"] };
                dtSource.PrimaryKey = pk;
            }
        }
        #endregion

        #region 取得事件的資料 public static void GetOfficialDocumentPatentEvent(string strOfficialDocumentKey, ref DataTable dtSource)
        /// <summary>
        /// 取得專利事件的資料
        /// </summary>
        /// <param name="strOfficialDocumentKey"></param>
        /// <returns></returns>
        public static void GetOfficialDocumentPatentEvent(string strOfficialDocumentKey, ref DataTable dtSource)
        {
            string strSQL = string.Format(@"SELECT * from  V_PatComitEventT with(nolock) where PatComitEventID in(select  CaseEventKey  from OfficialDocumentEventT with(nolock) where OfficialDocumentKey={0} ) order by CreateDate ", strOfficialDocumentKey);

            DBAccess dbhelper = new DBAccess();
            dtSource.Rows.Clear();
            dbhelper.QueryToDataTableByDataAdapter(strSQL, ref dtSource, isFillSchema: false);

           

            if (dtSource.PrimaryKey.Length == 0)
            {
                DataColumn[] pk = { dtSource.Columns["PatComitEventID"] };
                dtSource.PrimaryKey = pk;
            }
        }
        #endregion

        #region 取得事件By User的資料  public static void GetPatentEventByUser(string strPatentID,int Userkey, ref DataTable dtSource)
        /// <summary>
        /// 取得專利事件的資料 By User( V_PatComitEventT )
        /// </summary>
        /// <param name="strPatentID"></param>
        /// <returns></returns>
        public static void GetPatentEventByUser(string strPatentID,int Userkey, ref DataTable dtSource)
        {
            string strSQL = string.Format(@"SELECT * from  V_PatComitEventT with(nolock) where PatentID={0} and WorkerKey={1}", strPatentID,Userkey.ToString());

            DBAccess dbhelper = new DBAccess();
            dtSource.Rows.Clear();
            dbhelper.QueryToDataTableByDataAdapter(strSQL, ref dtSource, isFillSchema: false);

            if (dtSource.PrimaryKey.Length == 0)
            {
                DataColumn[] pk = { dtSource.Columns["PatComitEventID"] };
                dtSource.PrimaryKey = pk;
            }
        }
        #endregion

        #region 取得專利請款的資料  public static void GetPatentkFee(string strPatentID, ref DataTable dtSource)
        /// <summary>
        /// 取得專利請款的資料 V_PatentFeeT
        /// </summary>
        /// <param name="strPatentID"></param>
        /// <returns></returns>
        public static void GetPatentkFee(string strPatentID, ref DataTable dtSource)
        {
            string strSQL = string.Format(@"SELECT * from  V_PatentFeeT with(nolock) where PatentID={0} ", strPatentID);

            DBAccess dbhelper = new DBAccess();
            dtSource.Rows.Clear();
            dbhelper.QueryToDataTableByDataAdapter(strSQL, ref dtSource, isFillSchema: false);

            if (dtSource.PrimaryKey.Length == 0)
            {
                DataColumn[] pk = { dtSource.Columns["FeeKey"] };
                dtSource.PrimaryKey = pk;
            }
        }

        /// <summary>
        /// 取得專利請款的資料 V_PATControlFeeList
        /// </summary>
        /// <param name="FeeKey"></param>
        /// <param name="dtSource"></param>
        public static void GetPatentkControlFeeList(int FeeKey, ref DataTable dtSource)
        {
            string strSQL = string.Format(@"SELECT * from  V_PATControlFeeList with(nolock) where FeeKey={0} ", FeeKey);

            DBAccess dbhelper = new DBAccess();
            dtSource.Rows.Clear();
            dbhelper.QueryToDataTableByDataAdapter(strSQL, ref dtSource, isFillSchema: false);

            if (dtSource.PrimaryKey.Length == 0)
            {
                DataColumn[] pk = { dtSource.Columns["FeeKey"] };
                dtSource.PrimaryKey = pk;
            }
        }
        #endregion

        #region 取得專利請款By User的資料 public static void GetPatentkFeeByUser(string strPatentID,int Userkey, ref DataTable dtSource)
        /// <summary>
        /// 取得專利請款的資料 By User (V_PatentFeeT)
        /// </summary>
        /// <param name="strPatentID"></param>
        /// <param name="Userkey"></param>
        /// <returns></returns>
        public static void GetPatentkFeeByUser(string strPatentID,int Userkey, ref DataTable dtSource)
        {

            string strSQL = string.Format(@"SELECT * from  V_PatentFeeT with(nolock) where PatentID={0} and FClientTransactor={1}", strPatentID, Userkey.ToString());

            DBAccess dbhelper = new DBAccess();
            dtSource.Rows.Clear();
            dbhelper.QueryToDataTableByDataAdapter(strSQL, ref dtSource, isFillSchema: false);

            if (dtSource.PrimaryKey.Length == 0)
            {
                DataColumn[] pk = { dtSource.Columns["FeeKey"] };
                dtSource.PrimaryKey = pk;
            }
        }
        #endregion

        #region 取得專利付款的資料 public static void GetPatentPayment(string strPatentID, ref DataTable dtSource)
        /// <summary>
        /// 取得專利付款的資料 V_PatentPaymentT
        /// </summary>
        /// <param name="strPatentID"></param>
        /// <returns></returns>
        public static void GetPatentPayment(string strPatentID, ref DataTable dtSource)
        {

            string strSQL = string.Format(@"SELECT * from  V_PatentPaymentT with(nolock) where PatentID={0}", strPatentID);

            DBAccess dbhelper = new DBAccess();
            dtSource.Rows.Clear();
            dbhelper.QueryToDataTableByDataAdapter(strSQL, ref dtSource, isFillSchema: false);

            if (dtSource.PrimaryKey.Length == 0)
            {
                DataColumn[] pk = { dtSource.Columns["PaymentID"] };
                dtSource.PrimaryKey = pk;
            }
        }
        #endregion

        #region 取得專利付款的資料 public static void GetPatentPaymentByUser(string strPatentID, int Userkey, ref DataTable dtSource)
        /// <summary>
        /// 取得專利付款的資料 By User (V_PatentPaymentT)
        /// </summary>
        /// <param name="strPatentID"></param>
        /// <param name="Userkey"></param>
        /// <returns></returns>
        public static void GetPatentPaymentByUser(string strPatentID, int Userkey, ref DataTable dtSource)
        {

            string strSQL = string.Format(@"SELECT * from  V_PatentPaymentT with(nolock) where PatentID={0} and FClientTransactor={1}", strPatentID,Userkey.ToString());

            DBAccess dbhelper = new DBAccess();
            dtSource.Rows.Clear();
            dbhelper.QueryToDataTableByDataAdapter(strSQL, ref dtSource, isFillSchema: false);

            if (dtSource.PrimaryKey.Length == 0)
            {
                DataColumn[] pk = { dtSource.Columns["PaymentID"] };
                dtSource.PrimaryKey = pk;
            }
        }
        #endregion

        #region 取得商標預估費用的資料 public static void GetPatentEstimateCost(string strPatentID, ref DataTable dtSource)
        /// <summary>
        /// 取得專利預估費用的資料 PatentEstimateCostT
        /// </summary>
        /// <param name="strPatentID"></param>
        /// <returns></returns>
        public static void GetPatentEstimateCost(string strPatentID, ref DataTable dtSource)
        {

            string strSQL = string.Format(@"SELECT * from  PatentEstimateCostT with(nolock) where PatentID={0}", strPatentID);

            DBAccess dbhelper = new DBAccess();
            dtSource.Rows.Clear();
            dbhelper.QueryToDataTableByDataAdapter(strSQL, ref dtSource, isFillSchema: false);
            if (dtSource.PrimaryKey.Length == 0)
            {
                DataColumn[] pk = { dtSource.Columns["PTEstimateCostID"] };
                dtSource.PrimaryKey = pk;
            }
        }
        #endregion 

        #region 取得專利作業確認項目的資料  public static void GetPatWorkReportT(string strEventType, string strEventID, ref DataTable dtSource)
        /// <summary>
        /// 取得專利作業確認項目的資料 V_PatWorkReportT
        /// </summary>
        /// <param name="strEventType"></param>
        /// <param name="strEventID"></param>
        /// <returns></returns>
        public static void GetPatWorkReportT(string strEventType, string strEventID, ref DataTable dtSource)
        {

            string strSQL = string.Format(@"SELECT * from  V_PatWorkReportT with(nolock) where EventType={0} and EventID={1}", strEventType, strEventID);

            DBAccess dbhelper = new DBAccess();
            dtSource.Rows.Clear();
            dbhelper.QueryToDataTableByDataAdapter(strSQL, ref dtSource, isFillSchema: false);
            if (dtSource.PrimaryKey.Length == 0)
            {
                DataColumn[] pk = { dtSource.Columns["WorkReportID"] };
                dtSource.PrimaryKey = pk;
            }
        }
        #endregion 

        #region 取得專利案件績效表的資料 public static void GetPatentPerformanceBonus(string strWhere, ref DataTable dtSource)
        /// <summary>
        /// 取得專利案件績效表的資料 V_PatentPerformanceBonus
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static void GetPatentPerformanceBonus(string strWhere, ref DataTable dtSource)
        {

            string strSQL = string.Format(@"SELECT *  from  V_PatentPerformanceBonus with(nolock)  {0}", !string.IsNullOrEmpty(strWhere.Trim()) ? " where " + strWhere : "");

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

        #region 取得專利請款管控表  public static void GetPATControlFeeList(string strWhere, ref DataTable dtSource)
        /// <summary>
        /// 取得專利請款管控表 V_PATControlFeeList
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static void GetPATControlFeeList(string strWhere, ref DataTable dtSource)
        {

            string strSQL = string.Format(@"SELECT *  from  V_PATControlFeeList with(nolock)  {0}", !string.IsNullOrEmpty(strWhere.Trim()) ? " where " + strWhere : "");

            DBAccess dbhelper = new DBAccess();
            dtSource.Rows.Clear();
            dbhelper.QueryToDataTableByDataAdapter(strSQL, ref dtSource, isFillSchema: false);

            if (dtSource.PrimaryKey.Length == 0)
            {
                DataColumn[] pk = { dtSource.Columns["Feekey"] };
                dtSource.PrimaryKey = pk;
            }
        }
        #endregion

        #region 取得專利付款管控表  public static void GetPATControlPaymentList(string strWhere, ref DataTable dtSource)
        /// <summary>
        /// 取得專利付款管控表 PATControlPayment
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static void GetPATControlPaymentList(string strWhere, ref DataTable dtSource)
        {

            string strSQL = string.Format(@"SELECT *  from  V_PATControlPayment with(nolock)  {0}", !string.IsNullOrEmpty(strWhere.Trim()) ? " where " + strWhere : "");

            DBAccess dbhelper = new DBAccess();
            dtSource.Rows.Clear();
            dbhelper.QueryToDataTableByDataAdapter(strSQL, ref dtSource, isFillSchema: false);

            if (dtSource.PrimaryKey.Length == 0)
            {
                DataColumn[] pk = { dtSource.Columns["Feekey"] };
                dtSource.PrimaryKey = pk;
            }
        }
        #endregion


        #region GetPatTriffList 取得專利年費的資料
        /// <summary>
        /// 取得專利年費的資料
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static void GetPatTriffList(string strWhere, ref DataTable dtSource)
        {

            string strSQL = string.Format(@"select * from PatTriffT with(nolock) {0} order by StaYear", !string.IsNullOrEmpty(strWhere.Trim()) ? " where " + strWhere : "");

            DBAccess dbhelper = new DBAccess();
            dtSource.Rows.Clear();
            dbhelper.QueryToDataTableByDataAdapter(strSQL, ref dtSource, isFillSchema: false);

            if (dtSource.PrimaryKey.Length == 0)
            {
                DataColumn[] pk = { dtSource.Columns["TriffTkEY"] };
                dtSource.PrimaryKey = pk;
            }
        }
        #endregion

        #region GetComitEvent 取得待處理事件的資料
        /// <summary>
        /// 取得事件的資料 V_PATControlEventList
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static System.Data.DataTable GetComitEvent(string strWhere)
        {

            string strNotifyEventSQL = string.Format(@"SELECT *  from  V_PATControlEventList with(nolock)  {0}", !string.IsNullOrEmpty(strWhere) ? " where " + strWhere : "");

            Public.DLL dll = new Public.DLL();
            System.Data.DataTable dtComitEvent = new System.Data.DataTable();
            dll.FetchDataTable(strNotifyEventSQL, dtComitEvent);
            if (dtComitEvent.PrimaryKey.Length == 0)
            {
                DataColumn[] pk = { dtComitEvent.Columns["PatComitEventID"] };
                dtComitEvent.PrimaryKey = pk;
            }
            return dtComitEvent;
        }
        #endregion

        #region GetPatentEventPracticalityPayList 取得個人專利/商標績效點數的資料
        /// <summary>
        /// 取得個人專利/商標績效點數的資料 V_PatentEventList V_TrademarkEventList
        /// </summary>
        /// <param name="WorkerKey"></param>
        /// <param name="dtNow">月份</param>
        /// <returns></returns>
        public static System.Data.DataTable GetPatentEventPracticalityPayList(int WorkerKey ,DateTime dtNow)
        {
            string strthisMonth = dtNow.ToString("yyyy-MM-01");
            string strlastMonth = dtNow.AddMonths(-1).ToString("yyyy-MM-01");
            string strnextMonth = dtNow.AddMonths(1).ToString("yyyy-MM-01");
           
            string strNotifyEventSQL = string.Format(
                @"select  'PatMon' as lab,Sum(FeeSUM_PracticalityPay) as MonthFee from V_PatentEventList with(nolock)
where FinishDate >='{1}' and FinishDate <'{2}' and WorkerKey={3}
union 
select 'PatMon2' as lab,Sum(FeeSUM_PracticalityPay) as MonthFee from V_PatentEventList with(nolock)
where FinishDate >='{0}' and FinishDate <'{1}' and WorkerKey={3}
union 
select 'TmMoth' as lab,Sum(FeeSUM_PracticalityPay) as MonthFee from V_TrademarkEventList with(nolock)
where FinishDate >='{1}' and FinishDate <'{2}' and WorkerKey={3}
union 
select 'TmMonth2' as lab,Sum(FeeSUM_PracticalityPay) as MonthFee from V_TrademarkEventList with(nolock)
where FinishDate >='{0}' and FinishDate <'{1}' and WorkerKey={3}", strlastMonth,strthisMonth, strnextMonth, WorkerKey.ToString());

            DBAccess dll = new DBAccess();
            System.Data.DataTable dtEvent = new System.Data.DataTable();
            dll.QueryToDataTableByDataAdapter(strNotifyEventSQL,ref  dtEvent);
            
            return dtEvent;
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strPatentID"></param>
        /// <param name="dtSource"></param>
        public static void GetPatentRightInfoT(string strPatentID, ref DataSet dtSource)
        {
            string strSQL = string.Format(@"declare @patentid int 
set @patentid={0}

select PatentRightKey, PatentID, notice_no, notice_volno, notice_isuno, notice_date, publish_no, publish_volno, 
                            publish_isuno, publish_date, appl_no, appl_date, first_date, foreign_language, foreign_language_desc, design_type, 
                            design_type_desc, appl_class, material_appl_date, material_flag, faplexm_date, reappl_date, raplexam_date, 
                            agree_flag, twins_flag, patent_name_chinese, patent_name_english, licence_date, relicence_date, patent_no, 
                            patent_bdate, patent_edate, charge_expir_date, charge_expir_year, rent_status, cancel_date, cancel_result, 
                            revoke_date, revoke_code, dep_patent_class, dep_appl_no, patentisuregspecxmla_url, patentpubmtiff_url, 
                            patentpubxml_url, patentisuregspecmtiff_url, CreateDateTime, LastModifyDateTime 
							from PatentRightT with(nolock) where PatentID=@patentid;

select PatentRightApplicantsKey, PatentID, Sort, chinese_name, english_name, [address], english_country, 
                            chinese_country, english_address, CreateDateTime, LastModifyDateTime
 from PatentRightApplicantsT with(nolock) where  PatentID=@patentid;

 select PatentRightInventorsKey, PatentID, Sort, chinese_name, english_name, english_country, chinese_country, 
                            CreateDateTime, LastModifyDateTime
 from PatentRightInventorsT with(nolock) where  PatentID=@patentid;

select PatentAnnuityDetailKey, PatentAnnuityKey, Sort, annuity_date, annuity_beg, annuity_end, CreateDateTime, 
       LastModifyDateTime
FROM  PatentAnnuityInfoT with(nolock) where PatentAnnuityKey=(select PatentAnnuityKey from  PatentAnnuityT with(nolock) where PatentAnnuityT.PatentID=@patentid  );

 SELECT  PatentRightIPCKey, PatentID, Sort, ipc_full, ipc_section, ipc_class, ipc_subclass, ipc_main_group, 
                            ipc_group, ipc_version, CreateDateTime, LastModifyDateTime
FROM  PatentRightIpcT with(nolock) where  PatentID=@patentid;

SELECT  PatentRightLocKey, PatentID, Sort, loc_full, loc_level1, loc_level2, loc_version, CreateDateTime, 
                            LastModifyDateTime
FROM  PatentRightLocT with(nolock) where  PatentID=@patentid;
", strPatentID);

            DBAccess dbhelper = new DBAccess();
            dtSource.Tables.Clear();
            dbhelper.QueryToDataSetByDataAdapter(strSQL, ref dtSource,"");
           
        }


    }
}
