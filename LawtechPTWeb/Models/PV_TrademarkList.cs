using H3Operator.DBHelper;
using H3Operator.DBModels;
using System;
using System.Collections.Generic;

namespace LawtechPTWeb.Models
{
    #region View PV_TrademarkList Script
    [ViewTableMapping(@"select * from V_TrademarkList")]
    public class PV_TrademarkList
    {
        #region Public Property

        private int m_TrademarkID;
        [TableColumnSetting("TrademarkID", DbType = SqlDataType.Int)]
        public int TrademarkID
        {
            get
            {
                return m_TrademarkID;
            }
            set
            {
                m_TrademarkID = value;
            }
        }

        private string m_TrademarkNo;
        [TableColumnSetting("TrademarkNo", DbType = SqlDataType.NVarChar)]
        public string TrademarkNo
        {
            get
            {
                return m_TrademarkNo;
            }
            set
            {
                m_TrademarkNo = value;
            }
        }

        private string m_TrademarkName;
        [TableColumnSetting("TrademarkName", DbType = SqlDataType.NVarChar)]
        public string TrademarkName
        {
            get
            {
                return m_TrademarkName;
            }
            set
            {
                m_TrademarkName = value;
            }
        }

        private int m_ApplicantKey;
        [TableColumnSetting("ApplicantKey", DbType = SqlDataType.Int)]
        public int ApplicantKey
        {
            get
            {
                return m_ApplicantKey;
            }
            set
            {
                m_ApplicantKey = value;
            }
        }

        private string m_CountrySymbol;
        [TableColumnSetting("CountrySymbol", DbType = SqlDataType.NVarChar)]
        public string CountrySymbol
        {
            get
            {
                return m_CountrySymbol;
            }
            set
            {
                m_CountrySymbol = value;
            }
        }

        private string m_StyleName;
        [TableColumnSetting("StyleName", DbType = SqlDataType.NVarChar)]
        public string StyleName
        {
            get
            {
                return m_StyleName;
            }
            set
            {
                m_StyleName = value;
            }
        }

        private string m_TMTypeName;
        [TableColumnSetting("TMTypeName", DbType = SqlDataType.NVarChar)]
        public string TMTypeName
        {
            get
            {
                return m_TMTypeName;
            }
            set
            {
                m_TMTypeName = value;
            }
        }

        private string m_StatusExplain;
        [TableColumnSetting("StatusExplain", DbType = SqlDataType.NVarChar)]
        public string StatusExplain
        {
            get
            {
                return m_StatusExplain;
            }
            set
            {
                m_StatusExplain = value;
            }
        }

        private string m_CloseCaus;
        [TableColumnSetting("CloseCaus", DbType = SqlDataType.NVarChar,DataLength =1000)]
        public string CloseCaus
        {
            get
            {
                return m_CloseCaus;
            }
            set
            {
                m_CloseCaus = value;
            }
        }

        private int m_WorkerKey;
        [TableColumnSetting("WorkerKey", DbType = SqlDataType.Int)]
        public int WorkerKey
        {
            get
            {
                return m_WorkerKey;
            }
            set
            {
                m_WorkerKey = value;
            }
        }

        private DateTime m_EntrustDate;
        [TableColumnSetting("EntrustDate", DbType = SqlDataType.DateTime)]
        public DateTime EntrustDate
        {
            get
            {
                return m_EntrustDate;
            }
            set
            {
                m_EntrustDate = value;
            }
        }

        private int m_OutsourcingAttorney;
        [TableColumnSetting("OutsourcingAttorney", DbType = SqlDataType.Int)]
        public int OutsourcingAttorney
        {
            get
            {
                return m_OutsourcingAttorney;
            }
            set
            {
                m_OutsourcingAttorney = value;
            }
        }

        private int m_OutsourcingAttorneyWorker;
        [TableColumnSetting("OutsourcingAttorneyWorker", DbType = SqlDataType.Int)]
        public int OutsourcingAttorneyWorker
        {
            get
            {
                return m_OutsourcingAttorneyWorker;
            }
            set
            {
                m_OutsourcingAttorneyWorker = value;
            }
        }

        private string m_OutsourcingTrademarkNo;
        [TableColumnSetting("OutsourcingTrademarkNo", DbType = SqlDataType.NVarChar)]
        public string OutsourcingTrademarkNo
        {
            get
            {
                return m_OutsourcingTrademarkNo;
            }
            set
            {
                m_OutsourcingTrademarkNo = value;
            }
        }

        private DateTime m_OutsourcingDate;
        [TableColumnSetting("OutsourcingDate", DbType = SqlDataType.DateTime)]
        public DateTime OutsourcingDate
        {
            get
            {
                return m_OutsourcingDate;
            }
            set
            {
                m_OutsourcingDate = value;
            }
        }

        private DateTime m_ApplicationDate;
        [TableColumnSetting("ApplicationDate", DbType = SqlDataType.DateTime)]
        public DateTime ApplicationDate
        {
            get
            {
                return m_ApplicationDate;
            }
            set
            {
                m_ApplicationDate = value;
            }
        }

        private string m_ApplicationNo;
        [TableColumnSetting("ApplicationNo", DbType = SqlDataType.NVarChar)]
        public string ApplicationNo
        {
            get
            {
                return m_ApplicationNo;
            }
            set
            {
                m_ApplicationNo = value;
            }
        }

        private DateTime m_NoticeDate;
        [TableColumnSetting("NoticeDate", DbType = SqlDataType.DateTime)]
        public DateTime NoticeDate
        {
            get
            {
                return m_NoticeDate;
            }
            set
            {
                m_NoticeDate = value;
            }
        }

        private string m_NoticeNo;
        [TableColumnSetting("NoticeNo", DbType = SqlDataType.NVarChar)]
        public string NoticeNo
        {
            get
            {
                return m_NoticeNo;
            }
            set
            {
                m_NoticeNo = value;
            }
        }

        private DateTime m_RegistrationDate;
        [TableColumnSetting("RegistrationDate", DbType = SqlDataType.DateTime)]
        public DateTime RegistrationDate
        {
            get
            {
                return m_RegistrationDate;
            }
            set
            {
                m_RegistrationDate = value;
            }
        }

        private string m_RegistrationNo;
        [TableColumnSetting("RegistrationNo", DbType = SqlDataType.NVarChar)]
        public string RegistrationNo
        {
            get
            {
                return m_RegistrationNo;
            }
            set
            {
                m_RegistrationNo = value;
            }
        }

        private DateTime m_LawDate;
        [TableColumnSetting("LawDate", DbType = SqlDataType.DateTime)]
        public DateTime LawDate
        {
            get
            {
                return m_LawDate;
            }
            set
            {
                m_LawDate = value;
            }
        }

        private string m_RegisterProduct;
        [TableColumnSetting("RegisterProduct", DbType = SqlDataType.NVarChar)]
        public string RegisterProduct
        {
            get
            {
                return m_RegisterProduct;
            }
            set
            {
                m_RegisterProduct = value;
            }
        }

        private string m_RegisterProductName;
        [TableColumnSetting("RegisterProductName", DbType = SqlDataType.NVarChar)]
        public string RegisterProductName
        {
            get
            {
                return m_RegisterProductName;
            }
            set
            {
                m_RegisterProductName = value;
            }
        }

        private DateTime m_ExtendedDate;
        [TableColumnSetting("ExtendedDate", DbType = SqlDataType.DateTime)]
        public DateTime ExtendedDate
        {
            get
            {
                return m_ExtendedDate;
            }
            set
            {
                m_ExtendedDate = value;
            }
        }

        private DateTime m_CloseDate;
        [TableColumnSetting("CloseDate", DbType = SqlDataType.DateTime)]
        public DateTime CloseDate
        {
            get
            {
                return m_CloseDate;
            }
            set
            {
                m_CloseDate = value;
            }
        }

        private string m_Remarks;
        [TableColumnSetting("Remarks", DbType = SqlDataType.NVarChar)]
        public string Remarks
        {
            get
            {
                return m_Remarks;
            }
            set
            {
                m_Remarks = value;
            }
        }

        private string m_PicPath;
        [TableColumnSetting("PicPath", DbType = SqlDataType.NVarChar)]
        public string PicPath
        {
            get
            {
                return m_PicPath;
            }
            set
            {
                m_PicPath = value;
            }
        }

        private string m_StatusName;
        [TableColumnSetting("StatusName", DbType = SqlDataType.NVarChar)]
        public string StatusName
        {
            get
            {
                return m_StatusName;
            }
            set
            {
                m_StatusName = value;
            }
        }

        private string m_EmployeeName;
        [TableColumnSetting("EmployeeName", DbType = SqlDataType.NVarChar)]
        public string EmployeeName
        {
            get
            {
                return m_EmployeeName;
            }
            set
            {
                m_EmployeeName = value;
            }
        }

        private string m_AttorneyFirm;
        [TableColumnSetting("AttorneyFirm", DbType = SqlDataType.NVarChar)]
        public string AttorneyFirm
        {
            get
            {
                return m_AttorneyFirm;
            }
            set
            {
                m_AttorneyFirm = value;
            }
        }

        private string m_AttLiaisoner;
        [TableColumnSetting("AttLiaisoner", DbType = SqlDataType.NVarChar)]
        public string AttLiaisoner
        {
            get
            {
                return m_AttLiaisoner;
            }
            set
            {
                m_AttLiaisoner = value;
            }
        }

        private string m_CountryName;
        [TableColumnSetting("CountryName", DbType = SqlDataType.NVarChar)]
        public string CountryName
        {
            get
            {
                return m_CountryName;
            }
            set
            {
                m_CountryName = value;
            }
        }

        private bool m_TMNature;
        [TableColumnSetting("TMNature", DbType = SqlDataType.Bit)]
        public bool TMNature
        {
            get
            {
                return m_TMNature;
            }
            set
            {
                m_TMNature = value;
            }
        }

        private int m_DelegateType;
        [TableColumnSetting("DelegateType", DbType = SqlDataType.Int)]
        public int DelegateType
        {
            get
            {
                return m_DelegateType;
            }
            set
            {
                m_DelegateType = value;
            }
        }

        private int m_MainCustomer;
        [TableColumnSetting("MainCustomer", DbType = SqlDataType.Int)]
        public int MainCustomer
        {
            get
            {
                return m_MainCustomer;
            }
            set
            {
                m_MainCustomer = value;
            }
        }

        private string m_MainCustomerRefNo;
        [TableColumnSetting("MainCustomerRefNo", DbType = SqlDataType.NVarChar)]
        public string MainCustomerRefNo
        {
            get
            {
                return m_MainCustomerRefNo;
            }
            set
            {
                m_MainCustomerRefNo = value;
            }
        }

        private int m_MainCustomerTransactor;
        [TableColumnSetting("MainCustomerTransactor", DbType = SqlDataType.Int)]
        public int MainCustomerTransactor
        {
            get
            {
                return m_MainCustomerTransactor;
            }
            set
            {
                m_MainCustomerTransactor = value;
            }
        }

        private bool m_IsBySelf;
        [TableColumnSetting("IsBySelf", DbType = SqlDataType.Bit)]
        public bool IsBySelf
        {
            get
            {
                return m_IsBySelf;
            }
            set
            {
                m_IsBySelf = value;
            }
        }

        private string m_TrademarkOvertureName;
        [TableColumnSetting("TrademarkOvertureName", DbType = SqlDataType.NVarChar)]
        public string TrademarkOvertureName
        {
            get
            {
                return m_TrademarkOvertureName;
            }
            set
            {
                m_TrademarkOvertureName = value;
            }
        }

        private DateTime m_NoticeDate1;
        [TableColumnSetting("NoticeDate1", DbType = SqlDataType.DateTime)]
        public DateTime NoticeDate1
        {
            get
            {
                return m_NoticeDate1;
            }
            set
            {
                m_NoticeDate1 = value;
            }
        }

        private string m_NoticeNo1;
        [TableColumnSetting("NoticeNo1", DbType = SqlDataType.NVarChar)]
        public string NoticeNo1
        {
            get
            {
                return m_NoticeNo1;
            }
            set
            {
                m_NoticeNo1 = value;
            }
        }

        private string m_ApplicantNames;
        [TableColumnSetting("ApplicantNames", DbType = SqlDataType.NVarChar)]
        public string ApplicantNames
        {
            get
            {
                return m_ApplicantNames;
            }
            set
            {
                m_ApplicantNames = value;
            }
        }

        private string m_ApplicantKeys;
        [TableColumnSetting("ApplicantKeys", DbType = SqlDataType.NVarChar)]
        public string ApplicantKeys
        {
            get
            {
                return m_ApplicantKeys;
            }
            set
            {
                m_ApplicantKeys = value;
            }
        }

        private string m_Introducer;
        [TableColumnSetting("Introducer", DbType = SqlDataType.NVarChar)]
        public string Introducer
        {
            get
            {
                return m_Introducer;
            }
            set
            {
                m_Introducer = value;
            }
        }

        private DateTime m_IntroductionDate;
        [TableColumnSetting("IntroductionDate", DbType = SqlDataType.DateTime)]
        public DateTime IntroductionDate
        {
            get
            {
                return m_IntroductionDate;
            }
            set
            {
                m_IntroductionDate = value;
            }
        }

        private DateTime m_LastModifyDateTime;
        [TableColumnSetting("LastModifyDateTime", DbType = SqlDataType.DateTime)]
        public DateTime LastModifyDateTime
        {
            get
            {
                return m_LastModifyDateTime;
            }
            set
            {
                m_LastModifyDateTime = value;
            }
        }

        private string m_LastModifyWorker;
        [TableColumnSetting("LastModifyWorker", DbType = SqlDataType.NVarChar)]
        public string LastModifyWorker
        {
            get
            {
                return m_LastModifyWorker;
            }
            set
            {
                m_LastModifyWorker = value;
            }
        }

        private string m_Creator;
        [TableColumnSetting("Creator", DbType = SqlDataType.NVarChar)]
        public string Creator
        {
            get
            {
                return m_Creator;
            }
            set
            {
                m_Creator = value;
            }
        }

        private DateTime m_CreateDateTime;
        [TableColumnSetting("CreateDateTime", DbType = SqlDataType.DateTime)]
        public DateTime CreateDateTime
        {
            get
            {
                return m_CreateDateTime;
            }
            set
            {
                m_CreateDateTime = value;
            }
        }

        private int m_TMStatusID;
        [TableColumnSetting("TMStatusID", DbType = SqlDataType.Int)]
        public int TMStatusID
        {
            get
            {
                return m_TMStatusID;
            }
            set
            {
                m_TMStatusID = value;
            }
        }

        private string m_DelegateTypeName;
        [TableColumnSetting("DelegateTypeName", DbType = SqlDataType.NVarChar)]
        public string DelegateTypeName
        {
            get
            {
                return m_DelegateTypeName;
            }
            set
            {
                m_DelegateTypeName = value;
            }
        }

        private string m_MainCustomerTransactorName;
        [TableColumnSetting("MainCustomerTransactorName", DbType = SqlDataType.NVarChar)]
        public string MainCustomerTransactorName
        {
            get
            {
                return m_MainCustomerTransactorName;
            }
            set
            {
                m_MainCustomerTransactorName = value;
            }
        }

        private string m_MainCustomerName;
        [TableColumnSetting("MainCustomerName", DbType = SqlDataType.NVarChar)]
        public string MainCustomerName
        {
            get
            {
                return m_MainCustomerName;
            }
            set
            {
                m_MainCustomerName = value;
            }
        }

        private int m_DelegateFeatureKey;
        [TableColumnSetting("DelegateFeatureKey", DbType = SqlDataType.Int)]
        public int DelegateFeatureKey
        {
            get
            {
                return m_DelegateFeatureKey;
            }
            set
            {
                m_DelegateFeatureKey = value;
            }
        }

        private string m_DelegateFeatureName;
        [TableColumnSetting("DelegateFeatureName", DbType = SqlDataType.NVarChar)]
        public string DelegateFeatureName
        {
            get
            {
                return m_DelegateFeatureName;
            }
            set
            {
                m_DelegateFeatureName = value;
            }
        }

        #endregion

        #region [GetTotalCountRows]多資料表join時使用，回傳查詢後的總筆數 public static object GetTotalCountRows(ref int iCountRows, string strSqlWhere = ", System.Data.SqlClient.SqlParameter[] sqlParameterList = null, string strCusTableName = "")
        /// <summary>
        /// [ViewDBMapping]多資料表join時使用，回傳查詢後的總筆數
        /// </summary>
        /// <param name="iCountRows">回傳此次查詢的總筆數</param>
        /// <param name="strSqlWhere">SQL條件式 (不用加「where」關鑵字)</param>
        /// <param name="sqlParameterList">Sql參數</param>
        /// <param name="IsStoredProcedure">是否為預存程序, 預設為False</param>
        /// <returns></returns>
        public static object GetTotalCountRows(ref int iCountRows, string strSqlWhere = "", System.Data.SqlClient.SqlParameter[] sqlParameterList = null, bool IsStoredProcedure = false)
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.ReadViewCountRows<PV_TrademarkList>(ref iCountRows, strSqlWhere, sqlParameterList: sqlParameterList, isStoredProcedure: IsStoredProcedure);
            return retObj;
        }

        /// <summary>
        /// [ViewDBMapping]多資料表join時使用，回傳查詢後的總筆數
        /// </summary>
        /// <param name="strSqlScript">提供完整的Sql Script 語法</param>
        /// <param name="iCountRows">回傳此次查詢的總筆數</param>
        /// <param name="sqlParameterList">Sql參數</param>       
        /// <param name="IsStoredProcedure">是否為預存程序, 預設為False</param>
        /// <param name="ConnectString">預設為空字串，不為空字串時，以帶的連線字串為主; 若為空字串則以類別指定的連線字串(當類別連線名稱為空則帶DBSetConnection.ConnectionListDefaultConnectionString); </param>
        /// <returns></returns>
        public static object GetTotalCountRows(string strSqlScript, ref int iCountRows, System.Data.SqlClient.SqlParameter[] sqlParameterList = null, bool IsStoredProcedure = false, string ConnectString = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.ReadViewCountRows<PV_TrademarkList>(strSqlScript, ref iCountRows, sqlParameterList: sqlParameterList, strConnectionString: ConnectString, isStoredProcedure: IsStoredProcedure);
            return retObj;
        }
        #endregion

        #region 取得多筆PV_TrademarkList資料 ReadList

        #region  public static object ReadList(ref List<PV_TrademarkList> Items, string strSqlScript = "", System.Data.SqlClient.SqlParameter[] MySqlParameterList = null, bool IsStoredProcedure = false)
        /// <summary>
        /// 取得多筆PV_TrademarkList資料 ReadList
        /// 只要指定的Sql欄位有對應至類別屬性，則自動繫結       
        /// </summary>
        /// <param name="Items"></param>
        /// <param name="strSqlScript">完整的Sql Script語法</param>
        /// <param name="MySqlParameterList"></param>
        /// <param name="IsStoredProcedure">是否為StoredProcedure ,true:是 ; false:否(預設值) </param>
        /// <returns></returns>
        public static object ReadList(ref List<PV_TrademarkList> Items, string strSqlScript = "", System.Data.SqlClient.SqlParameter[] MySqlParameterList = null, bool IsStoredProcedure = false)
        {
            ORMFactory orm = new ORMFactory();

            object retObj = orm.ReadViewDBListToObjs<PV_TrademarkList>(strSqlScript, ref Items, sqlParameterList: MySqlParameterList, isStoredProcedure: IsStoredProcedure);

            return retObj;
        }
        #endregion

        #region public static object ReadList( string strSqlWhere  ,ref List<PV_TrademarkList> Items, System.Data.SqlClient.SqlParameter[] MySqlParameterList = null, bool IsStoredProcedure = false)
        /// <summary>
        /// 取得多筆PV_TrademarkList資料 ReadList
        /// 只要指定的Sql欄位有對應至類別屬性，則自動繫結       
        /// </summary>
        /// <param name="strSqlWhere">SQL條件式 (不用加「where」關鑵字)</param>  
        /// <param name="Items"></param>       
        /// <param name="MySqlParameterList"></param>
        /// <param name="IsStoredProcedure">是否為StoredProcedure ,true:是 ; false:否(預設值)</param>
        /// <returns></returns>
        public static object ReadList(string strSqlWhere, ref List<PV_TrademarkList> Items, System.Data.SqlClient.SqlParameter[] MySqlParameterList = null, bool IsStoredProcedure = false)
        {
            ORMFactory orm = new ORMFactory();

            object retObj = orm.ReadViewDBListToObjs<PV_TrademarkList>(ref Items, strSqlWhere, sqlParameterList: MySqlParameterList, isStoredProcedure: IsStoredProcedure);

            return retObj;
        }
        #endregion

        #region public static object ReadList(string strSqlWhere, string strOrderBy, ref List<PV_TrademarkList> Items, int myPageSize = 10, int myPageIndex = 1, System.Data.SqlClient.SqlParameter[] MySqlParameterList = null, bool IsStoredProcedure = false)
        /// <summary>
        /// [ReadViewDBListToObjsByFetch](使用MSSQL 2014的分頁做法OFFSET FETCH ，效能佳, §注意 MSSQL2008 無法使用)
        /// 取得多筆PV_TrademarkList資料 ReadList
        /// 只要指定的Sql欄位有對應至類別屬性，則自動繫結       
        /// </summary>
        /// <param name="strSqlWhere">SQL條件式 (不用加「where」關鑵字)</param>  
        /// <param name="strOrderBy">排序的欄位; 例: CreateDateTime desc </param> 
        /// <param name="Items"></param>     
        /// <param name="myPageSize">一頁的筆數,預設一頁 10 筆</param>  
        /// <param name="myPageIndex">從 0 起算，0即表示第1頁</param>  
        /// <param name="MySqlParameterList">Sql參數</param>
        /// <param name="IsStoredProcedure">是否為StoredProcedure ,true:是 ; false:否(預設值)</param>
        /// <returns></returns>
        public static object ReadList(string strSqlWhere, string strOrderBy, ref List<PV_TrademarkList> Items, int myPageSize = 10, int myPageIndex = 1, System.Data.SqlClient.SqlParameter[] MySqlParameterList = null, bool IsStoredProcedure = false)
        {
            ORMFactory orm = new ORMFactory();
            int iTotalCountRows = 0;
            myPageIndex--;
            object retObj = null;
            try
            {
                retObj = orm.ReadViewDBListToObjsByFetch<PV_TrademarkList>(myPageSize, myPageIndex, strOrderBy, ref Items, strSqlWhere, ref iTotalCountRows, sqlParameterList: MySqlParameterList, isStoredProcedure: IsStoredProcedure);
            }
            catch (InvalidCastException ex)
            {
                retObj = ex.Message;
            }

            return retObj;
        }
        #endregion

        #region #region public static object ReadList(string strSqlWhere, string strOrderBy, ref List<V_ProductTtest> Items, ref int iTotalCountRows, int myPageSize = 10, int myPageIndex = 0, System.Data.SqlClient.SqlParameter[] MySqlParameterList = null, bool IsStoredProcedure = false)
        /// <summary>
        /// [ReadViewDBListToObjsByFetch](使用MSSQL 2014的分頁做法OFFSET FETCH ，效能佳, §注意 MSSQL2008 無法使用)
        /// 取得多筆PV_TrademarkList資料 ReadList
        /// 只要指定的Sql欄位有對應至類別屬性，則自動繫結       
        /// </summary>
        /// <param name="strSqlWhere">SQL條件式 (不用加「where」關鑵字)</param>  
        /// <param name="strOrderBy">排序的欄位; 例: CreateDateTime desc </param> 
        /// <param name="Items"></param>     
        /// <param name="iTotalCountRows">回傳此次查詢的總筆數</param>
        /// <param name="myPageSize">一頁的筆數,預設一頁 10 筆</param>  
        /// <param name="myPageIndex">當值為小於 0 時，預設帶 0 (從 0 起算，0即表示第1頁)</param>  
        /// <param name="MySqlParameterList">Sql參數</param>
        /// <param name="IsStoredProcedure">是否為StoredProcedure ,true:是 ; false:否(預設值)</param>
        /// <returns></returns>
        public static object ReadList(string strSqlWhere, string strOrderBy, ref List<PV_TrademarkList> Items, ref int iTotalCountRows, int myPageSize = 10, int myPageIndex = 0, System.Data.SqlClient.SqlParameter[] MySqlParameterList = null, bool IsStoredProcedure = false)
        {
            ORMFactory orm = new ORMFactory();

            object retObj = null;
            try
            {
                retObj = orm.ReadViewDBListToObjsByFetch<PV_TrademarkList>(myPageSize, myPageIndex, strOrderBy, ref Items, strSqlWhere, ref iTotalCountRows, sqlParameterList: MySqlParameterList, isStoredProcedure: IsStoredProcedure);
            }
            catch (InvalidCastException ex)
            {
                retObj = ex.Message;
            }

            return retObj;
        }
        #endregion

        #region [ReadViewDBListToObjsByFetch]多資料表join時使用 public static object ReadList(int myPageSize, int myPageIndex, string strOrderBy, string strSqlScript, ref List<PV_TrademarkList> Items, ref int iTotalCountRows, System.Data.SqlClient.SqlParameter[] MySqlParameterList = null, bool IsStoredProcedure = false,string MyConnectionString="")
        /// <summary>
        /// [ReadViewDBListToObjsByFetch]多資料表join時使用，將結果繫結至Models (使用MSSQL 2014的分頁做法OFFSET FETCH ，效能佳, §注意 MSSQL2008 無法使用)
        /// </summary>
        /// <param name="myPageSize">一頁的筆數</param>
        /// <param name="myPageIndex">當值為小於 0 時，預設帶 0 (從 0 起算，0即表示第1頁)</param>
        /// <param name="strOrderBy">必要值(不得為空)，排序時需有指定排序的欄位, 例:「SiteKey desc , Account asc」</param>
        /// <param name="strSqlScript">提供完整的Sql Script 語法(注意select出來的資料需和物件的屬性對應)</param>
        /// <param name="Items"></param>
        /// <param name="iTotalCountRows">回傳此次查詢的總筆數</param>
        /// <param name="MySqlParameterList">Sql參數</param>
        /// <param name="IsStoredProcedure">是否為預存程序, 預設為False</param>
        /// <param name="MyConnectionString">預設為空字串，不為空字串時，以帶的連線字串為主; 若為空字串則以類別指定的連線字串( 當類別連線名稱為空則帶DBSetConnection.ConnectionListDefaultConnectionString )</param>
        /// <returns></returns>
        public static object ReadList(int myPageSize, int myPageIndex, string strOrderBy, string strSqlScript, ref List<PV_TrademarkList> Items, ref int iTotalCountRows, System.Data.SqlClient.SqlParameter[] MySqlParameterList = null, bool IsStoredProcedure = false, string MyConnectionString = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = null;
            try
            {
                retObj = orm.ReadViewDBListToObjsByFetch<PV_TrademarkList>(myPageSize, myPageIndex, strOrderBy, strSqlScript, ref Items, ref iTotalCountRows, sqlParameterList: MySqlParameterList, strConnectionString: MyConnectionString, isStoredProcedure: IsStoredProcedure);
            }
            catch (InvalidCastException ex)
            {
                retObj = ex.Message;
            }

            return retObj;
        }
        #endregion
        #endregion

    }
    #endregion  
}