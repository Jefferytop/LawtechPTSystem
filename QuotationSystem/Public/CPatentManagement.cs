using H3Operator.DBHelper;
using H3Operator.DBModels;
using System;
using System.Collections.Generic;

namespace LawtechPTSystem.Public
{
    #region CPatentManagement=================
    /// <summary>
    /// 
    /// </summary>
    [TableMapping("PatentManagementT")]
    public class CPatentManagement : SysBaseModel
    {
        #region Public property

        private int m_PatentID;
        /// <summary>
        /// 專利申請案資料表
        /// </summary>
        [TableColumnSetting("PatentID", DbType = SqlDataType.Int, IsPrimary = true, IsCumulative = true, IsCanNull = false, DataLength = 4)]
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
        /// <summary>
        /// 申請案編號
        /// </summary>
        [TableColumnSetting("PatentNo", IsCanNull = false, DataLength = 60)]
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
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("PatentNo_Old", DataLength = 1000)]
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

        private string m_Creator;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("Creator", DataLength = 100)]
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

        private string m_LastModifyWorker;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("LastModifyWorker", DataLength = 100)]
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
        
        private string m_ApplicantNames;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("ApplicantNames", DataLength = 1000)]
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
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("ApplicantKeys", DataLength = 1000)]
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

        private int? m_Applicant;
        /// <summary>
        /// 所屬客戶編號
        /// </summary>
        [TableColumnSetting("Applicant", DbType = SqlDataType.Int, DataLength = 4)]
        public int? Applicant
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
        /// <summary>
        /// 申請案名稱
        /// </summary>
        [TableColumnSetting("Title", DataLength = 1000)]
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
        /// <summary>
        /// 申請案名稱(英)
        /// </summary>
        [TableColumnSetting("TitleEn", DataLength = 4000)]
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
        /// <summary>
        /// 種類
        /// </summary>
        [TableColumnSetting("Kind", DataLength = 20)]
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

        private int? m_Nature;
        /// <summary>
        /// 性質
        /// </summary>
        [TableColumnSetting("Nature", DbType = SqlDataType.Int, DataLength = 4)]
        public int? Nature
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
        /// <summary>
        /// 國別
        /// </summary>
        [TableColumnSetting("CountrySymbol", DataLength = 100)]
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

        private int? m_ClientWorker;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("ClientWorker", DbType = SqlDataType.Int, DataLength = 4)]
        public int? ClientWorker
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

        private int? m_Status;
        /// <summary>
        /// 申請案狀態
        /// </summary>
        [TableColumnSetting("Status", DbType = SqlDataType.Int, DataLength = 4)]
        public int? Status
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
        /// <summary>
        /// 申請案狀態描述
        /// </summary>
        [TableColumnSetting("StatusExplain", DataLength = 1000)]
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

        private int? m_ISexam;
        /// <summary>
        /// 審查請求
        /// </summary>
        [TableColumnSetting("ISexam", DbType = SqlDataType.Int, DataLength = 4)]
        public int? ISexam
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

        private int? m_Priority;
        /// <summary>
        /// 優先權主張
        /// </summary>
        [TableColumnSetting("Priority", DbType = SqlDataType.Int, DataLength = 4)]
        public int? Priority
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

        private string m_EarlyPriorityNo;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("EarlyPriorityNo", DataLength = 400)]
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

        private DateTime? m_EarlyPriorityDate;
        /// <summary>
        /// 最早優先申請日
        /// </summary>
        [TableColumnSetting("EarlyPriorityDate", DbType = SqlDataType.DateTime, DataLength = 8)]
        public DateTime? EarlyPriorityDate
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

        private DateTime? m_EarlyMotherDate;
        /// <summary>
        /// 最早母案申請日
        /// </summary>
        [TableColumnSetting("EarlyMotherDate", DbType = SqlDataType.DateTime, DataLength = 8)]
        public DateTime? EarlyMotherDate
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

        private DateTime? m_ApplicationDate;
        /// <summary>
        /// 實際申請日
        /// </summary>
        [TableColumnSetting("ApplicationDate", DbType = SqlDataType.DateTime, DataLength = 8)]
        public DateTime? ApplicationDate
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
        /// <summary>
        /// 申請案號
        /// </summary>
        [TableColumnSetting("ApplicationNo", DataLength = 100)]
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

        private DateTime? m_Pubdate;
        /// <summary>
        /// 公開日期
        /// </summary>
        [TableColumnSetting("Pubdate", DbType = SqlDataType.DateTime, DataLength = 8)]
        public DateTime? Pubdate
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
        /// <summary>
        /// 公開號數
        /// </summary>
        [TableColumnSetting("PubNo", DataLength = 100)]
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

        private DateTime? m_AllowDate;
        /// <summary>
        /// 核准日期
        /// </summary>
        [TableColumnSetting("AllowDate", DbType = SqlDataType.DateTime, DataLength = 8)]
        public DateTime? AllowDate
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

        private DateTime? m_AllowPubDate;
        /// <summary>
        /// 公告日期
        /// </summary>
        [TableColumnSetting("AllowPubDate", DbType = SqlDataType.DateTime, DataLength = 8)]
        public DateTime? AllowPubDate
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
        /// <summary>
        /// 公告號數
        /// </summary>
        [TableColumnSetting("AllowPubNo", DataLength = 100)]
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

        private DateTime? m_GetDate;
        /// <summary>
        /// 收到證書日
        /// </summary>
        [TableColumnSetting("GetDate", DbType = SqlDataType.DateTime, DataLength = 8)]
        public DateTime? GetDate
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
        /// <summary>
        /// 專利號數
        /// </summary>
        [TableColumnSetting("CertifyNo", DataLength = 100)]
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

        private DateTime? m_RegisterDate;
        /// <summary>
        /// 授予專利權日
        /// </summary>
        [TableColumnSetting("RegisterDate", DbType = SqlDataType.DateTime, DataLength = 8)]
        public DateTime? RegisterDate
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

        private DateTime? m_DueDate;
        /// <summary>
        /// 專利權終止日
        /// </summary>
        [TableColumnSetting("DueDate", DbType = SqlDataType.DateTime, DataLength = 8)]
        public DateTime? DueDate
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

        private decimal? m_PayYear;
        /// <summary>
        /// 年費繳至第幾年
        /// </summary>
        [TableColumnSetting("PayYear", DbType = SqlDataType.Decimal, DataLength = 5)]
        public decimal? PayYear
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

        private DateTime? m_RenewTo;
        /// <summary>
        /// 年費有效期限
        /// </summary>
        [TableColumnSetting("RenewTo", DbType = SqlDataType.DateTime, DataLength = 8)]
        public DateTime? RenewTo
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

        private DateTime? m_CloseDate;
        /// <summary>
        /// 結案日期
        /// </summary>
        [TableColumnSetting("CloseDate", DbType = SqlDataType.DateTime, DataLength = 8)]
        public DateTime? CloseDate
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
        /// <summary>
        /// 結案原因
        /// </summary>
        [TableColumnSetting("CloseCaus", DataLength = 8000)]
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
        /// <summary>
        /// 備註
        /// </summary>
        [TableColumnSetting("Remark", DataLength = 8000)]
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

        private int? m_FileSource;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("FileSource", DbType = SqlDataType.Int, DataLength = 4)]
        public int? FileSource
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
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("NextYear", DataLength = 100)]
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

        private decimal? m_YearFee;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("YearFee", DbType = SqlDataType.Decimal, DataLength = 5)]
        public decimal? YearFee
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

        private int? m_IneventerMan;
        /// <summary>
        /// 申請案聯絡人
        /// </summary>
        [TableColumnSetting("IneventerMan", DbType = SqlDataType.Int, DataLength = 4)]
        public int? IneventerMan
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

        private int? m_AddDay;
        /// <summary>
        /// 延長日數
        /// </summary>
        [TableColumnSetting("AddDay", DbType = SqlDataType.Int, DataLength = 4)]
        public int? AddDay
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
        /// <summary>
        /// 發明人
        /// </summary>
        [TableColumnSetting("Inventor", DataLength = 1000)]
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

        private int? m_DelegateFeatureKey;
        /// <summary>
        /// 委託性質
        /// </summary>
        [TableColumnSetting("DelegateFeatureKey", DbType = SqlDataType.Int, DataLength = 4)]
        public int? DelegateFeatureKey
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

        private int? m_DelegateType;
        /// <summary>
        /// 委託類型(1.申請人直接委託 2.複代委託)
        /// </summary>
        [TableColumnSetting("DelegateType", DbType = SqlDataType.Int, DataLength = 4)]
        public int? DelegateType
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

        private int? m_MainCustomer;
        /// <summary>
        /// 依委託類型改變(申請人或複代)
        /// </summary>
        [TableColumnSetting("MainCustomer", DbType = SqlDataType.Int, DataLength = 4)]
        public int? MainCustomer
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
        /// <summary>
        /// 主要委託人--對方案號
        /// </summary>
        [TableColumnSetting("MainCustomerRefNo", DataLength = 100)]
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

        private int? m_MainCustomerTransactor;
        /// <summary>
        /// 主要委託人--聯絡窗口
        /// </summary>
        [TableColumnSetting("MainCustomerTransactor", DbType = SqlDataType.Int, DataLength = 4)]
        public int? MainCustomerTransactor
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

        private bool? m_IsBySelf;
        /// <summary>
        /// 是否本所承辦案件
        /// </summary>
        [TableColumnSetting("IsBySelf", DbType = SqlDataType.Bit, DataLength = 1)]
        public bool? IsBySelf
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

        private int? m_Attorney;
        /// <summary>
        /// 承辦事務所
        /// </summary>
        [TableColumnSetting("Attorney", DbType = SqlDataType.Int, DataLength = 4)]
        public int? Attorney
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
        /// <summary>
        /// 貴方案號
        /// </summary>
        [TableColumnSetting("AttorneyRefNo", DataLength = 120)]
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

        private int? m_AttorneyTransactor;
        /// <summary>
        /// 事務所承辦人
        /// </summary>
        [TableColumnSetting("AttorneyTransactor", DbType = SqlDataType.Int, DataLength = 4)]
        public int? AttorneyTransactor
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

        private string m_Introducer;
        /// <summary>
        /// 引案人
        /// </summary>
        [TableColumnSetting("Introducer", DataLength = 2000)]
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

        private DateTime? m_IntroductionDate;
        /// <summary>
        /// 引案日期
        /// </summary>
        [TableColumnSetting("IntroductionDate", DbType = SqlDataType.DateTime, DataLength = 8)]
        public DateTime? IntroductionDate
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

        private DateTime? m_GracePeriod;
        /// <summary>
        /// 優惠期日期
        /// </summary>
        [TableColumnSetting("GracePeriod", DbType = SqlDataType.DateTime, DataLength = 8)]
        public DateTime? GracePeriod
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
        /// <summary>
        /// 優惠期公開事由
        /// </summary>
        [TableColumnSetting("GraceRemark", DataLength = 4000)]
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
        /// <summary>
        /// 電子交互碼
        /// </summary>
        [TableColumnSetting("ECode", DataLength = 200)]
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

        private int? m_LockedWorker;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("LockedWorker", DbType = SqlDataType.Int, DataLength = 4)]
        public int? LockedWorker
        {
            get
            {
                return m_LockedWorker;
            }
            set
            {
                m_LockedWorker = value;
            }
        }

        #endregion

        #region Method

        #region 確認指定欄位的值是否存在 CheckValueExist(string ColumnName, object Value ,ref bool IsExist, bool IsCreateMode = true)
        /// <summary>
        /// 確認指定欄位的值是否存在，true:已存在相同的值 ; false : 未存在 (有新增和編輯模式)
        /// </summary>
        /// <param name="ColumnName">欄位名稱</param>
        /// <param name="Value">要確認指定欄位是否有此值(只提供字串[string] 或數字[int])</param>
        /// <param name="IsExist">ture:已存在該值的資料 ; false:不存在該值的資料</param>
        /// <param name="IsCreateMode">模式 true:新增模式(預設值) ; false:編輯模式(排除本身的)</param>
        /// <returns>0:成功 ; string:失敗</returns>
        public object CheckValueExist(string ColumnName, object Value, ref bool IsExist, bool IsCreateMode = true)
        {
            ORMFactory orm = new ORMFactory();
            List<CPatentManagement> list = new List<CPatentManagement>();
            System.Data.SqlClient.SqlParameter para;

            if (Value.GetType() == string.Empty.GetType())
            {
                para = DBAccess.MakeInParam(ColumnName, SqlDataType.NVarChar, Value.ToString());
            }
            else
            {
                para = DBAccess.MakeInParam(ColumnName, SqlDataType.Int, (int)Value);
            }

            System.Data.SqlClient.SqlParameter[] ParList = { para };
            object retObj;
            if (IsCreateMode)
            {
                retObj = orm.ReadListToObjs<CPatentManagement>(ColumnName + "=@" + ColumnName, ref list, ParList);
            }
            else
            {
                retObj = orm.ReadListToObjs<CPatentManagement>(ColumnName + "=@" + ColumnName + " and PatentID<>" + this.PatentID.ToString(), ref list, ParList);
            }

            if (retObj.ToString() == "0")
            {
                if (list.Count > 0)
                {
                    IsExist = true;
                }
                else
                {
                    IsExist = false;
                }
            }
            return retObj;
        }
        #endregion

        #region 取得一筆資料  ReadOne(ref CPatentManagement Item, string strCusTableName = ")
        /// <summary>
        /// 取得一筆PatentManagementT資料
        /// </summary>          
        /// <param name="item"></param>   
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>
        /// <returns>0:成功 ; string:失敗</returns>       
        public static object ReadOne(ref CPatentManagement Item, string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.ReadOneToObj(ref Item, CusTableName: strCusTableName);
            return retObj;
        }
        #endregion

        #region 取得一筆資料 ReadOne(int iPKey, ref DB_MenuRoleTModel item, string strCusTableName = "")
        /// <summary>
        /// 取得一筆PatentManagementT資料
        /// </summary>
        /// <param name="iPKey">指定某筆資料的Key值(不適合複合key)</param>     
        /// <param name="item"></param>   
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>
        /// <returns>0:成功 ; string:失敗</returns>       
        public static object ReadOne(int iPKey, ref CPatentManagement item, string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.ReadOneToObj(iPKey, ref item, CusTableName: strCusTableName);
            return retObj;
        }
        #endregion

        #region 取得一筆PatentManagementT資料 ReadOne(string strSqlWhere, System.Data.SqlClient.SqlParameter[] MySqlParameterList=null, string strCusTableName = "")
        /// <summary>
        /// 取得一筆PatentManagementT資料;如果有多筆符合條件，則只回傳null
        /// </summary>
        /// <param name="strSqlWhere">查詢條件(不用加「where」關鍵字, 可加Sql參數,例如: account=@account)</param>
        /// <param name="MySqlParameterList">Sql參數</param>
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>
        /// <returns>0:成功 ; string:失敗</returns>
        public static object ReadOne(string strSqlWhere, ref CPatentManagement item, System.Data.SqlClient.SqlParameter[] MySqlParameterList = null, string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            List<CPatentManagement> itemlist = new List<CPatentManagement>();
            object retObj = orm.ReadListToObjs(strSqlWhere, ref itemlist, sqlParameterList: MySqlParameterList, CusTableName: strCusTableName);
            if (retObj.ToString() == "0" && itemlist.Count > 0)
            {
                if (itemlist.Count == 1)
                {
                    item = itemlist[0];
                }
                else
                {
                    retObj = "Error：有一筆以上的資料";
                }
            }
            return retObj;
        }
        #endregion

        #region 取得多筆CPatentManagement資料 ReadList
        /// <summary>
        /// 取得多筆 PatentManagementT資料 
        /// </summary>
        /// <param name="Items"></param>
        /// <param name="strSqlWhere">SQL條件式 (不用加「where」關鑵字,可加Sql參數,例如: account=@account)</param>
        /// <param name="MySqlParameterList">Sql參數</param>
        /// <param name="strOrderBy">SQL排序式 , 當空值時，預設帶[ CreateDateTime Desc] (不用加「Order by 」關鑵字, 例 "uid desc,createDateTime asc ")</param>
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>      
        /// <returns></returns>
        public static object ReadList(ref List<CPatentManagement> Items, string strSqlWhere = "", System.Data.SqlClient.SqlParameter[] MySqlParameterList = null, string strOrderBy = "", string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();

            object retObj = orm.ReadListToObjs<CPatentManagement>(strSqlWhere, ref Items, sqlParameterList: MySqlParameterList, OrderBy: strOrderBy, CusTableName: strCusTableName);

            return retObj;
        }

        #endregion

        #region 取得多筆 PatentManagementT資料 , 指定頁數和頁碼 ReadList
        /// <summary>
        /// 取得多筆 PatentManagementT資料 , 指定頁數和頁碼
        /// </summary>
        /// <param name="PageSize">一頁的筆數</param>
        /// <param name="PageIndex">第 n 頁</param>
        /// <param name="Items"></param>
        /// <param name="strSqlWhere">SQL條件式 (不用加「where」關鑵字,可加Sql參數,例如: account=@account)</param>
        /// <param name="MySqlParameterList">Sql參數</param>
        /// <param name="strOrderBy">SQL排序式 , 當空值時，預設帶[ CreateDateTime Desc] (不用加「Order by 」關鑵字, 例 "uid desc,createDateTime asc ")</param>
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>       
        /// <returns></returns>
        public static object ReadList(int PageSize, int PageIndex, ref List<CPatentManagement> Items, string strSqlWhere = "", System.Data.SqlClient.SqlParameter[] MySqlParameterList = null, string strOrderBy = "", string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();

            object retObj = orm.ReadListToObjs<CPatentManagement>(PageSize, PageIndex, strSqlWhere, ref Items, sqlParameterList: MySqlParameterList, OrderBy: strOrderBy, CusTableName: strCusTableName);

            return retObj;
        }
        #endregion

        #region Create
        /// <summary>
        /// 新增PatentManagementT 項目
        /// </summary> 
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>      
        /// <returns>0:成功 ; string:失敗</returns>
        public object Create(string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.InsertByObj<CPatentManagement>(this, strCusTableName);
            return retObj;
        }
        #endregion

        #region Update
        /// <summary>
        /// 更新 PatentManagementT 項目
        /// </summary>       
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param> 
        /// <returns>0:成功 ; string:失敗</returns>
        public object Update(string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.UpdateObj<CPatentManagement>(this, strCusTableName);
            return retObj;
        }
        #endregion

        #region Delete

        #region 刪除項目PatentManagementT Delete()
        /// <summary>
        /// 刪除項目PatentManagementT
        /// </summary>  
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>
        /// <returns></returns>   
        public object Delete(string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.DeleteObj<CPatentManagement>(this, strCusTableName);
            return retObj;
        }
        #endregion

        #region 刪除項目PatentManagementT Delete(int iPKey)
        /// <summary>
        /// 刪除項目PatentManagementT , 指定某一筆主鍵刪除(單筆)
        /// </summary>
        /// <param name="iPKey">指定刪除某筆資料的Key值</param> 
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>      
        /// <returns></returns>
        public object Delete(int iPKey, string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.DeleteObj<CPatentManagement>(iPKey, strCusTableName);
            return retObj;
        }
        #endregion

        #region 刪除項目PatentManagementT Delete(string strSqlWhere)
        /// <summary>
        /// 刪除項目PatentManagementT ,符合條件刪除(多筆)
        /// </summary>
        /// <param name="strSqlWhere">查詢條件(不用加「where」關鍵字)</param>   
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>    
        /// <returns></returns>
        public object Delete(string strSqlWhere, string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.DeleteObj<CPatentManagement>(strSqlWhere, strCusTableName);
            return retObj;
        }
        #endregion

        #endregion

        #endregion
    }
    #endregion =================
}
