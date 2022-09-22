using H3Operator.DBHelper;
using H3Operator.DBModels;
using System;
using System.Collections.Generic;

namespace LawtechPTWeb.Models
{
    #region View PV_PatentList Script
    [ViewTableMapping(@"SELECT *  from  V_PatentList")]
    public class PV_PatentList
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

        private string m_PatentNo_Old;
        [TableColumnSetting("PatentNo_Old", DbType = SqlDataType.NVarChar)]
        public string PatentNo_Old
        {
            get
            {
                return m_PatentNo_Old;
            }
            set
            {
                m_PatentNo_Old = value;
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

        private string m_TitleEn;
        [TableColumnSetting("TitleEn", DbType = SqlDataType.NVarChar)]
        public string TitleEn
        {
            get
            {
                return m_TitleEn;
            }
            set
            {
                m_TitleEn = value;
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

        private int m_Nature;
        [TableColumnSetting("Nature", DbType = SqlDataType.Int)]
        public int Nature
        {
            get
            {
                return m_Nature;
            }
            set
            {
                m_Nature = value;
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

        private int m_ClientWorker;
        [TableColumnSetting("ClientWorker", DbType = SqlDataType.Int)]
        public int ClientWorker
        {
            get
            {
                return m_ClientWorker;
            }
            set
            {
                m_ClientWorker = value;
            }
        }

        private int m_Status;
        [TableColumnSetting("Status", DbType = SqlDataType.Int)]
        public int Status
        {
            get
            {
                return m_Status;
            }
            set
            {
                m_Status = value;
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

        private int m_ISexam;
        [TableColumnSetting("ISexam", DbType = SqlDataType.Int)]
        public int ISexam
        {
            get
            {
                return m_ISexam;
            }
            set
            {
                m_ISexam = value;
            }
        }

        private int m_Priority;
        [TableColumnSetting("Priority", DbType = SqlDataType.Int)]
        public int Priority
        {
            get
            {
                return m_Priority;
            }
            set
            {
                m_Priority = value;
            }
        }

        private DateTime m_EarlyPriorityDate;
        [TableColumnSetting("EarlyPriorityDate", DbType = SqlDataType.DateTime)]
        public DateTime EarlyPriorityDate
        {
            get
            {
                return m_EarlyPriorityDate;
            }
            set
            {
                m_EarlyPriorityDate = value;
            }
        }

        private DateTime m_EarlyMotherDate;
        [TableColumnSetting("EarlyMotherDate", DbType = SqlDataType.DateTime)]
        public DateTime EarlyMotherDate
        {
            get
            {
                return m_EarlyMotherDate;
            }
            set
            {
                m_EarlyMotherDate = value;
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

        private DateTime m_Pubdate;
        [TableColumnSetting("Pubdate", DbType = SqlDataType.DateTime)]
        public DateTime Pubdate
        {
            get
            {
                return m_Pubdate;
            }
            set
            {
                m_Pubdate = value;
            }
        }

        private string m_PubNo;
        [TableColumnSetting("PubNo", DbType = SqlDataType.NVarChar)]
        public string PubNo
        {
            get
            {
                return m_PubNo;
            }
            set
            {
                m_PubNo = value;
            }
        }

        private DateTime m_AllowDate;
        [TableColumnSetting("AllowDate", DbType = SqlDataType.DateTime)]
        public DateTime AllowDate
        {
            get
            {
                return m_AllowDate;
            }
            set
            {
                m_AllowDate = value;
            }
        }

        private DateTime m_AllowPubDate;
        [TableColumnSetting("AllowPubDate", DbType = SqlDataType.DateTime)]
        public DateTime AllowPubDate
        {
            get
            {
                return m_AllowPubDate;
            }
            set
            {
                m_AllowPubDate = value;
            }
        }

        private string m_AllowPubNo;
        [TableColumnSetting("AllowPubNo", DbType = SqlDataType.NVarChar)]
        public string AllowPubNo
        {
            get
            {
                return m_AllowPubNo;
            }
            set
            {
                m_AllowPubNo = value;
            }
        }

        private DateTime m_GetDate;
        [TableColumnSetting("GetDate", DbType = SqlDataType.DateTime)]
        public DateTime GetDate
        {
            get
            {
                return m_GetDate;
            }
            set
            {
                m_GetDate = value;
            }
        }

        private string m_CertifyNo;
        [TableColumnSetting("CertifyNo", DbType = SqlDataType.NVarChar)]
        public string CertifyNo
        {
            get
            {
                return m_CertifyNo;
            }
            set
            {
                m_CertifyNo = value;
            }
        }

        private DateTime m_RegisterDate;
        [TableColumnSetting("RegisterDate", DbType = SqlDataType.DateTime)]
        public DateTime RegisterDate
        {
            get
            {
                return m_RegisterDate;
            }
            set
            {
                m_RegisterDate = value;
            }
        }

        private DateTime m_DueDate;
        [TableColumnSetting("DueDate", DbType = SqlDataType.DateTime)]
        public DateTime DueDate
        {
            get
            {
                return m_DueDate;
            }
            set
            {
                m_DueDate = value;
            }
        }

        private decimal m_PayYear;
        [TableColumnSetting("PayYear", DbType = SqlDataType.Decimal)]
        public decimal PayYear
        {
            get
            {
                return m_PayYear;
            }
            set
            {
                m_PayYear = value;
            }
        }

        private DateTime m_RenewTo;
        [TableColumnSetting("RenewTo", DbType = SqlDataType.DateTime)]
        public DateTime RenewTo
        {
            get
            {
                return m_RenewTo;
            }
            set
            {
                m_RenewTo = value;
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

        private string m_CloseCaus;
        [TableColumnSetting("CloseCaus", DbType = SqlDataType.NVarChar)]
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

        private string m_Remark;
        [TableColumnSetting("Remark", DbType = SqlDataType.NVarChar)]
        public string Remark
        {
            get
            {
                return m_Remark;
            }
            set
            {
                m_Remark = value;
            }
        }

        private int m_FileSource;
        [TableColumnSetting("FileSource", DbType = SqlDataType.Int)]
        public int FileSource
        {
            get
            {
                return m_FileSource;
            }
            set
            {
                m_FileSource = value;
            }
        }

        private string m_NextYear;
        [TableColumnSetting("NextYear", DbType = SqlDataType.NVarChar)]
        public string NextYear
        {
            get
            {
                return m_NextYear;
            }
            set
            {
                m_NextYear = value;
            }
        }

        private decimal m_YearFee;
        [TableColumnSetting("YearFee", DbType = SqlDataType.Decimal)]
        public decimal YearFee
        {
            get
            {
                return m_YearFee;
            }
            set
            {
                m_YearFee = value;
            }
        }

        private int m_IneventerMan;
        [TableColumnSetting("IneventerMan", DbType = SqlDataType.Int)]
        public int IneventerMan
        {
            get
            {
                return m_IneventerMan;
            }
            set
            {
                m_IneventerMan = value;
            }
        }

        private int m_AddDay;
        [TableColumnSetting("AddDay", DbType = SqlDataType.Int)]
        public int AddDay
        {
            get
            {
                return m_AddDay;
            }
            set
            {
                m_AddDay = value;
            }
        }

        private string m_Inventor;
        [TableColumnSetting("Inventor", DbType = SqlDataType.NVarChar)]
        public string Inventor
        {
            get
            {
                return m_Inventor;
            }
            set
            {
                m_Inventor = value;
            }
        }

        private string m_ClientWorkerName;
        [TableColumnSetting("ClientWorkerName", DbType = SqlDataType.NVarChar)]
        public string ClientWorkerName
        {
            get
            {
                return m_ClientWorkerName;
            }
            set
            {
                m_ClientWorkerName = value;
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

        private string m_KindName;
        [TableColumnSetting("KindName", DbType = SqlDataType.NVarChar)]
        public string KindName
        {
            get
            {
                return m_KindName;
            }
            set
            {
                m_KindName = value;
            }
        }

        private string m_FeatureName;
        [TableColumnSetting("FeatureName", DbType = SqlDataType.NVarChar)]
        public string FeatureName
        {
            get
            {
                return m_FeatureName;
            }
            set
            {
                m_FeatureName = value;
            }
        }

        private string m_PriorityBaseName;
        [TableColumnSetting("PriorityBaseName", DbType = SqlDataType.NVarChar)]
        public string PriorityBaseName
        {
            get
            {
                return m_PriorityBaseName;
            }
            set
            {
                m_PriorityBaseName = value;
            }
        }

        private string m_ISExamName;
        [TableColumnSetting("ISExamName", DbType = SqlDataType.NVarChar)]
        public string ISExamName
        {
            get
            {
                return m_ISExamName;
            }
            set
            {
                m_ISExamName = value;
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

        private int m_Attorney;
        [TableColumnSetting("Attorney", DbType = SqlDataType.Int)]
        public int Attorney
        {
            get
            {
                return m_Attorney;
            }
            set
            {
                m_Attorney = value;
            }
        }

        private string m_AttorneyRefNo;
        [TableColumnSetting("AttorneyRefNo", DbType = SqlDataType.NVarChar)]
        public string AttorneyRefNo
        {
            get
            {
                return m_AttorneyRefNo;
            }
            set
            {
                m_AttorneyRefNo = value;
            }
        }

        private int m_AttorneyTransactor;
        [TableColumnSetting("AttorneyTransactor", DbType = SqlDataType.Int)]
        public int AttorneyTransactor
        {
            get
            {
                return m_AttorneyTransactor;
            }
            set
            {
                m_AttorneyTransactor = value;
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

        private string m_EarlyPriorityNo;
        [TableColumnSetting("EarlyPriorityNo", DbType = SqlDataType.NVarChar)]
        public string EarlyPriorityNo
        {
            get
            {
                return m_EarlyPriorityNo;
            }
            set
            {
                m_EarlyPriorityNo = value;
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

        private DateTime m_GracePeriod;
        [TableColumnSetting("GracePeriod", DbType = SqlDataType.DateTime)]
        public DateTime GracePeriod
        {
            get
            {
                return m_GracePeriod;
            }
            set
            {
                m_GracePeriod = value;
            }
        }

        private string m_GraceRemark;
        [TableColumnSetting("GraceRemark", DbType = SqlDataType.NVarChar)]
        public string GraceRemark
        {
            get
            {
                return m_GraceRemark;
            }
            set
            {
                m_GraceRemark = value;
            }
        }

        private string m_ECode;
        [TableColumnSetting("ECode", DbType = SqlDataType.NVarChar)]
        public string ECode
        {
            get
            {
                return m_ECode;
            }
            set
            {
                m_ECode = value;
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
            object retObj = orm.ReadViewCountRows<PV_PatentList>(ref iCountRows, strSqlWhere, sqlParameterList: sqlParameterList, isStoredProcedure: IsStoredProcedure);
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
            object retObj = orm.ReadViewCountRows<PV_PatentList>(strSqlScript, ref iCountRows, sqlParameterList: sqlParameterList, strConnectionString: ConnectString, isStoredProcedure: IsStoredProcedure);
            return retObj;
        }
        #endregion

        #region 取得多筆PV_PatentList資料 ReadList

        #region  public static object ReadList(ref List<PV_PatentList> Items, string strSqlScript = "", System.Data.SqlClient.SqlParameter[] MySqlParameterList = null, bool IsStoredProcedure = false)
        /// <summary>
        /// 取得多筆PV_PatentList資料 ReadList
        /// 只要指定的Sql欄位有對應至類別屬性，則自動繫結       
        /// </summary>
        /// <param name="Items"></param>
        /// <param name="strSqlScript">完整的Sql Script語法</param>
        /// <param name="MySqlParameterList"></param>
        /// <param name="IsStoredProcedure">是否為StoredProcedure ,true:是 ; false:否(預設值) </param>
        /// <returns></returns>
        public static object ReadList(ref List<PV_PatentList> Items, string strSqlScript = "", System.Data.SqlClient.SqlParameter[] MySqlParameterList = null, bool IsStoredProcedure = false)
        {
            ORMFactory orm = new ORMFactory();

            object retObj = orm.ReadViewDBListToObjs<PV_PatentList>(strSqlScript, ref Items, sqlParameterList: MySqlParameterList, isStoredProcedure: IsStoredProcedure);

            return retObj;
        }
        #endregion

        #region public static object ReadList( string strSqlWhere  ,ref List<PV_PatentList> Items, System.Data.SqlClient.SqlParameter[] MySqlParameterList = null, bool IsStoredProcedure = false)
        /// <summary>
        /// 取得多筆PV_PatentList資料 ReadList
        /// 只要指定的Sql欄位有對應至類別屬性，則自動繫結       
        /// </summary>
        /// <param name="strSqlWhere">SQL條件式 (不用加「where」關鑵字)</param>  
        /// <param name="Items"></param>       
        /// <param name="MySqlParameterList"></param>
        /// <param name="IsStoredProcedure">是否為StoredProcedure ,true:是 ; false:否(預設值)</param>
        /// <returns></returns>
        public static object ReadList(string strSqlWhere, ref List<PV_PatentList> Items, System.Data.SqlClient.SqlParameter[] MySqlParameterList = null, bool IsStoredProcedure = false)
        {
            ORMFactory orm = new ORMFactory();

            object retObj = orm.ReadViewDBListToObjs<PV_PatentList>(ref Items, strSqlWhere, sqlParameterList: MySqlParameterList, isStoredProcedure: IsStoredProcedure);

            return retObj;
        }
        #endregion

        #region public static object ReadList(string strSqlWhere, string strOrderBy, ref List<PV_PatentList> Items, int myPageSize = 10, int myPageIndex = 1, System.Data.SqlClient.SqlParameter[] MySqlParameterList = null, bool IsStoredProcedure = false)
        /// <summary>
        /// [ReadViewDBListToObjsByFetch](使用MSSQL 2014的分頁做法OFFSET FETCH ，效能佳, §注意 MSSQL2008 無法使用)
        /// 取得多筆PV_PatentList資料 ReadList
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
        public static object ReadList(string strSqlWhere, string strOrderBy, ref List<PV_PatentList> Items, int myPageSize = 10, int myPageIndex = 1, System.Data.SqlClient.SqlParameter[] MySqlParameterList = null, bool IsStoredProcedure = false)
        {
            ORMFactory orm = new ORMFactory();
            int iTotalCountRows = 0;
            myPageIndex--;
            object retObj = null;
            try
            {
                retObj = orm.ReadViewDBListToObjsByFetch<PV_PatentList>(myPageSize, myPageIndex, strOrderBy, ref Items, strSqlWhere, ref iTotalCountRows, sqlParameterList: MySqlParameterList, isStoredProcedure: IsStoredProcedure);
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
        /// 取得多筆PV_PatentList資料 ReadList
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
        public static object ReadList(string strSqlWhere, string strOrderBy, ref List<PV_PatentList> Items, ref int iTotalCountRows, int myPageSize = 10, int myPageIndex = 0, System.Data.SqlClient.SqlParameter[] MySqlParameterList = null, bool IsStoredProcedure = false)
        {
            ORMFactory orm = new ORMFactory();

            object retObj = null;
            try
            {
                retObj = orm.ReadViewDBListToObjsByFetch<PV_PatentList>(myPageSize, myPageIndex, strOrderBy, ref Items, strSqlWhere, ref iTotalCountRows, sqlParameterList: MySqlParameterList, isStoredProcedure: IsStoredProcedure);
            }
            catch (InvalidCastException ex)
            {
                retObj = ex.Message;
            }

            return retObj;
        }
        #endregion

        #region [ReadViewDBListToObjsByFetch]多資料表join時使用 public static object ReadList(int myPageSize, int myPageIndex, string strOrderBy, string strSqlScript, ref List<PV_PatentList> Items, ref int iTotalCountRows, System.Data.SqlClient.SqlParameter[] MySqlParameterList = null, bool IsStoredProcedure = false,string MyConnectionString="")
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
        public static object ReadList(int myPageSize, int myPageIndex, string strOrderBy, string strSqlScript, ref List<PV_PatentList> Items, ref int iTotalCountRows, System.Data.SqlClient.SqlParameter[] MySqlParameterList = null, bool IsStoredProcedure = false, string MyConnectionString = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = null;
            try
            {
                retObj = orm.ReadViewDBListToObjsByFetch<PV_PatentList>(myPageSize, myPageIndex, strOrderBy, strSqlScript, ref Items, ref iTotalCountRows, sqlParameterList: MySqlParameterList, strConnectionString: MyConnectionString, isStoredProcedure: IsStoredProcedure);
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