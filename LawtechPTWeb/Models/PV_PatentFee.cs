using H3Operator.DBHelper;
using H3Operator.DBModels;
using System;
using System.Collections.Generic;

namespace LawtechPTWeb.Models
{
    
    #region View PV_PatentFee Script
    [ViewTableMapping(@"select * from V_PatentFeeSearch")]
    public class PV_PatentFee
    {
        #region Public Property

        private int m_PatentID;
        [TableColumnSetting("PatentID", DbType = SqlDataType.Int)]
        public int PatentID
        {
            get
            {
                return m_PatentID;
            }
            set
            {
                m_PatentID = value;
            }
        }

        private int m_FeeKey;
        [TableColumnSetting("FeeKey", DbType = SqlDataType.Int)]
        public int FeeKey
        {
            get
            {
                return m_FeeKey;
            }
            set
            {
                m_FeeKey = value;
            }
        }

        private string m_PatentNo;
        [TableColumnSetting("PatentNo", DbType = SqlDataType.NVarChar)]
        public string PatentNo
        {
            get
            {
                return m_PatentNo;
            }
            set
            {
                m_PatentNo = value;
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

        private string m_Country;
        [TableColumnSetting("Country", DbType = SqlDataType.NVarChar)]
        public string Country
        {
            get
            {
                return m_Country;
            }
            set
            {
                m_Country = value;
            }
        }

        private string m_Kind;
        [TableColumnSetting("Kind", DbType = SqlDataType.NVarChar)]
        public string Kind
        {
            get
            {
                return m_Kind;
            }
            set
            {
                m_Kind = value;
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

        private string m_FeeSubject;
        [TableColumnSetting("FeeSubject", DbType = SqlDataType.NVarChar)]
        public string FeeSubject
        {
            get
            {
                return m_FeeSubject;
            }
            set
            {
                m_FeeSubject = value;
            }
        }

        private decimal m_Totall;
        [TableColumnSetting("Totall", DbType = SqlDataType.Decimal)]
        public decimal Totall
        {
            get
            {
                return m_Totall;
            }
            set
            {
                m_Totall = value;
            }
        }

        private string m_Title;
        [TableColumnSetting("Title", DbType = SqlDataType.NVarChar)]
        public string Title
        {
            get
            {
                return m_Title;
            }
            set
            {
                m_Title = value;
            }
        }

        private string m_SingCode;
        [TableColumnSetting("SingCode", DbType = SqlDataType.NVarChar)]
        public string SingCode
        {
            get
            {
                return m_SingCode;
            }
            set
            {
                m_SingCode = value;
            }
        }

        private DateTime m_ReceiptDate;
        [TableColumnSetting("ReceiptDate", DbType = SqlDataType.DateTime)]
        public DateTime ReceiptDate
        {
            get
            {
                return m_ReceiptDate;
            }
            set
            {
                m_ReceiptDate = value;
            }
        }

        private DateTime m_PayDate;
        [TableColumnSetting("PayDate", DbType = SqlDataType.DateTime)]
        public DateTime PayDate
        {
            get
            {
                return m_PayDate;
            }
            set
            {
                m_PayDate = value;
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

        private decimal m_OtherTotalFee;
        [TableColumnSetting("OtherTotalFee", DbType = SqlDataType.Decimal)]
        public decimal OtherTotalFee
        {
            get
            {
                return m_OtherTotalFee;
            }
            set
            {
                m_OtherTotalFee = value;
            }
        }

        private decimal m_OAttorneyGovFee;
        [TableColumnSetting("OAttorneyGovFee", DbType = SqlDataType.Decimal)]
        public decimal OAttorneyGovFee
        {
            get
            {
                return m_OAttorneyGovFee;
            }
            set
            {
                m_OAttorneyGovFee = value;
            }
        }

        private string m_PPP;
        [TableColumnSetting("PPP", DbType = SqlDataType.NVarChar)]
        public string PPP
        {
            get
            {
                return m_PPP;
            }
            set
            {
                m_PPP = value;
            }
        }

        private decimal m_PracticalityPay;
        [TableColumnSetting("PracticalityPay", DbType = SqlDataType.Decimal)]
        public decimal PracticalityPay
        {
            get
            {
                return m_PracticalityPay;
            }
            set
            {
                m_PracticalityPay = value;
            }
        }

        private string m_CustomerName;
        [TableColumnSetting("CustomerName", DbType = SqlDataType.NVarChar)]
        public string CustomerName
        {
            get
            {
                return m_CustomerName;
            }
            set
            {
                m_CustomerName = value;
            }
        }

        private DateTime m_RDate;
        [TableColumnSetting("RDate", DbType = SqlDataType.DateTime)]
        public DateTime RDate
        {
            get
            {
                return m_RDate;
            }
            set
            {
                m_RDate = value;
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

        private string m_OMoney;
        [TableColumnSetting("OMoney", DbType = SqlDataType.NVarChar)]
        public string OMoney
        {
            get
            {
                return m_OMoney;
            }
            set
            {
                m_OMoney = value;
            }
        }

        private decimal m_GovFee;
        [TableColumnSetting("GovFee", DbType = SqlDataType.Decimal)]
        public decimal GovFee
        {
            get
            {
                return m_GovFee;
            }
            set
            {
                m_GovFee = value;
            }
        }

        private decimal m_OAttorneyFee;
        [TableColumnSetting("OAttorneyFee", DbType = SqlDataType.Decimal)]
        public decimal OAttorneyFee
        {
            get
            {
                return m_OAttorneyFee;
            }
            set
            {
                m_OAttorneyFee = value;
            }
        }

        private decimal m_OthFee;
        [TableColumnSetting("OthFee", DbType = SqlDataType.Decimal)]
        public decimal OthFee
        {
            get
            {
                return m_OthFee;
            }
            set
            {
                m_OthFee = value;
            }
        }

        private int m_Applicant;
        [TableColumnSetting("Applicant", DbType = SqlDataType.Int)]
        public int Applicant
        {
            get
            {
                return m_Applicant;
            }
            set
            {
                m_Applicant = value;
            }
        }

        private int m_AttorneyKey;
        [TableColumnSetting("AttorneyKey", DbType = SqlDataType.Int)]
        public int AttorneyKey
        {
            get
            {
                return m_AttorneyKey;
            }
            set
            {
                m_AttorneyKey = value;
            }
        }

        private string m_GMoney;
        [TableColumnSetting("GMoney", DbType = SqlDataType.NVarChar)]
        public string GMoney
        {
            get
            {
                return m_GMoney;
            }
            set
            {
                m_GMoney = value;
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

        private string m_TMoney;
        [TableColumnSetting("TMoney", DbType = SqlDataType.NVarChar)]
        public string TMoney
        {
            get
            {
                return m_TMoney;
            }
            set
            {
                m_TMoney = value;
            }
        }

        private decimal m_TotalNT;
        [TableColumnSetting("TotalNT", DbType = SqlDataType.Decimal)]
        public decimal TotalNT
        {
            get
            {
                return m_TotalNT;
            }
            set
            {
                m_TotalNT = value;
            }
        }

        private string m_SingCodeStatus;
        [TableColumnSetting("SingCodeStatus", DbType = SqlDataType.NVarChar)]
        public string SingCodeStatus
        {
            get
            {
                return m_SingCodeStatus;
            }
            set
            {
                m_SingCodeStatus = value;
            }
        }

        private string m_FeeEventID;
        [TableColumnSetting("FeeEventID", DbType = SqlDataType.NVarChar)]
        public string FeeEventID
        {
            get
            {
                return m_FeeEventID;
            }
            set
            {
                m_FeeEventID = value;
            }
        }

        private int m_PatComitEventID;
        [TableColumnSetting("PatComitEventID", DbType = SqlDataType.Int)]
        public int PatComitEventID
        {
            get
            {
                return m_PatComitEventID;
            }
            set
            {
                m_PatComitEventID = value;
            }
        }

        private bool m_IsClosing;
        [TableColumnSetting("IsClosing", DbType = SqlDataType.Bit)]
        public bool IsClosing
        {
            get
            {
                return m_IsClosing;
            }
            set
            {
                m_IsClosing = value;
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

        private string m_FeePhase;
        [TableColumnSetting("FeePhase", DbType = SqlDataType.NVarChar)]
        public string FeePhase
        {
            get
            {
                return m_FeePhase;
            }
            set
            {
                m_FeePhase = value;
            }
        }

        private int m_FeePhaseID;
        [TableColumnSetting("FeePhaseID", DbType = SqlDataType.Int)]
        public int FeePhaseID
        {
            get
            {
                return m_FeePhaseID;
            }
            set
            {
                m_FeePhaseID = value;
            }
        }

        private int m_FClientTransactor;
        [TableColumnSetting("FClientTransactor", DbType = SqlDataType.Int)]
        public int FClientTransactor
        {
            get
            {
                return m_FClientTransactor;
            }
            set
            {
                m_FClientTransactor = value;
            }
        }

        #endregion

        #region [GetTotalCountRows]多資料表join時使用，回傳查詢後的總筆數 public static object GetTotalCountRows(ref int iCountRows, string strSqlWhere = ", System.Data.SqlClient.SqlParameter[] sqlParameterList = null, string strCusTableName = "")
        /// <summary>
        /// [GetTotalCountRows]多資料表join時使用，回傳查詢後的總筆數
        /// </summary>
        /// <param name="iCountRows">回傳此次查詢的總筆數</param>
        /// <param name="strSqlWhere">SQL條件式 (不用加「where」關鑵字)</param>
        /// <param name="sqlParameterList">Sql參數</param>
        /// <param name="IsStoredProcedure">是否為預存程序, 預設為False</param>
        /// <returns></returns>
        public static object GetTotalCountRows(ref int iCountRows, string strSqlWhere = "", System.Data.SqlClient.SqlParameter[] sqlParameterList = null, bool IsStoredProcedure = false)
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.ReadViewCountRows<PV_PatentFee>(ref iCountRows, strSqlWhere, sqlParameterList: sqlParameterList, isStoredProcedure: IsStoredProcedure);
            return retObj;
        }

        /// <summary>
        /// [GetTotalCountRows]多資料表join時使用，回傳查詢後的總筆數
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
            object retObj = orm.ReadViewCountRows<PV_PatentFee>(strSqlScript, ref iCountRows, sqlParameterList: sqlParameterList, strConnectionString: ConnectString, isStoredProcedure: IsStoredProcedure);
            return retObj;
        }
        #endregion

        #region 取得多筆PV_PatentFee資料 ReadList

        #region  public static object ReadList(ref List<PV_PatentFee> Items, string strSqlScript = "", System.Data.SqlClient.SqlParameter[] MySqlParameterList = null, bool IsStoredProcedure = false)
        /// <summary>
        /// 取得多筆PV_PatentFee資料 ReadList
        /// 只要指定的Sql欄位有對應至類別屬性，則自動繫結       
        /// </summary>
        /// <param name="Items"></param>
        /// <param name="strSqlScript">完整的Sql Script語法</param>
        /// <param name="MySqlParameterList"></param>
        /// <param name="IsStoredProcedure">是否為StoredProcedure ,true:是 ; false:否(預設值) </param>
        /// <returns></returns>
        public static object ReadList(ref List<PV_PatentFee> Items, string strSqlScript = "", System.Data.SqlClient.SqlParameter[] MySqlParameterList = null, bool IsStoredProcedure = false)
        {
            ORMFactory orm = new ORMFactory();

            object retObj = orm.ReadViewDBListToObjs<PV_PatentFee>(strSqlScript, ref Items, sqlParameterList: MySqlParameterList, isStoredProcedure: IsStoredProcedure);

            return retObj;
        }
        #endregion

        #region public static object ReadList( string strSqlWhere  ,ref List<PV_PatentFee> Items, System.Data.SqlClient.SqlParameter[] MySqlParameterList = null, bool IsStoredProcedure = false)
        /// <summary>
        /// 取得多筆PV_PatentFee資料 ReadList
        /// 只要指定的Sql欄位有對應至類別屬性，則自動繫結       
        /// </summary>
        /// <param name="strSqlWhere">SQL條件式 (不用加「where」關鑵字)</param>  
        /// <param name="Items"></param>       
        /// <param name="MySqlParameterList"></param>
        /// <param name="IsStoredProcedure">是否為StoredProcedure ,true:是 ; false:否(預設值)</param>
        /// <returns></returns>
        public static object ReadList(string strSqlWhere, ref List<PV_PatentFee> Items, System.Data.SqlClient.SqlParameter[] MySqlParameterList = null, bool IsStoredProcedure = false)
        {
            ORMFactory orm = new ORMFactory();

            object retObj = orm.ReadViewDBListToObjs<PV_PatentFee>(ref Items, strSqlWhere, sqlParameterList: MySqlParameterList, isStoredProcedure: IsStoredProcedure);

            return retObj;
        }
        #endregion

        #region public static object ReadList(string strSqlWhere, string strOrderBy, ref List<PV_PatentFee> Items, int myPageSize = 10, int myPageIndex = 1, System.Data.SqlClient.SqlParameter[] MySqlParameterList = null, bool IsStoredProcedure = false)
        /// <summary>
        /// [ReadViewDBListToObjsByFetch](使用MSSQL 2014的分頁做法OFFSET FETCH ，效能佳, §注意 MSSQL2008 無法使用)
        /// 取得多筆PV_PatentFee資料 ReadList
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
        public static object ReadList(string strSqlWhere, string strOrderBy, ref List<PV_PatentFee> Items, int myPageSize = 10, int myPageIndex = 1, System.Data.SqlClient.SqlParameter[] MySqlParameterList = null, bool IsStoredProcedure = false)
        {
            ORMFactory orm = new ORMFactory();
            int iTotalCountRows = 0;
            myPageIndex--;
            object retObj = null;
            try
            {
                retObj = orm.ReadViewDBListToObjsByFetch<PV_PatentFee>(myPageSize, myPageIndex, strOrderBy, ref Items, strSqlWhere, ref iTotalCountRows, sqlParameterList: MySqlParameterList, isStoredProcedure: IsStoredProcedure);
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
        /// 取得多筆PV_PatentFee資料 ReadList
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
        public static object ReadList(string strSqlWhere, string strOrderBy, ref List<PV_PatentFee> Items, ref int iTotalCountRows, int myPageSize = 10, int myPageIndex = 0, System.Data.SqlClient.SqlParameter[] MySqlParameterList = null, bool IsStoredProcedure = false)
        {
            ORMFactory orm = new ORMFactory();

            object retObj = null;
            try
            {
                retObj = orm.ReadViewDBListToObjsByFetch<PV_PatentFee>(myPageSize, myPageIndex, strOrderBy, ref Items, strSqlWhere, ref iTotalCountRows, sqlParameterList: MySqlParameterList, isStoredProcedure: IsStoredProcedure);
            }
            catch (InvalidCastException ex)
            {
                retObj = ex.Message;
            }

            return retObj;
        }
        #endregion

        #region [ReadViewDBListToObjsByFetch]多資料表join時使用 public static object ReadList(int myPageSize, int myPageIndex, string strOrderBy, string strSqlScript, ref List<PV_PatentFee> Items, ref int iTotalCountRows, System.Data.SqlClient.SqlParameter[] MySqlParameterList = null, bool IsStoredProcedure = false,string MyConnectionString="")
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
        public static object ReadList(int myPageSize, int myPageIndex, string strOrderBy, string strSqlScript, ref List<PV_PatentFee> Items, ref int iTotalCountRows, System.Data.SqlClient.SqlParameter[] MySqlParameterList = null, bool IsStoredProcedure = false, string MyConnectionString = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = null;
            try
            {
                retObj = orm.ReadViewDBListToObjsByFetch<PV_PatentFee>(myPageSize, myPageIndex, strOrderBy, strSqlScript, ref Items, ref iTotalCountRows, sqlParameterList: MySqlParameterList, strConnectionString: MyConnectionString, isStoredProcedure: IsStoredProcedure);
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