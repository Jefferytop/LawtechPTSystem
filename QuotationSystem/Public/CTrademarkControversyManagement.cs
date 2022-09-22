using System;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using H3Operator.DBModels;
using H3Operator.DBHelper;
using System.Collections.Generic;

namespace LawtechPTSystem.Public
{
    #region CTrademarkControversyManagement=================
    /// <summary>
    /// 
    /// </summary>
    [TableMapping("TrademarkControversyManagementT")]
    public class CTrademarkControversyManagement : SysBaseModel
    {
        #region Public property

        private int m_TrademarkControversyID;
        /// <summary>
        /// 商標案件管理表 PK
        /// </summary>
        [TableColumnSetting("TrademarkControversyID", DbType = SqlDataType.Int, IsPrimary = true, IsCumulative = true, IsCanNull = false, DataLength = 4)]
        public int TrademarkControversyID
        {
            get
            {
                return m_TrademarkControversyID;
            }
            set
            {
                m_TrademarkControversyID = value;
            }
        }

        private string m_TrademarkNo;
        /// <summary>
        /// 本所案號
        /// </summary>
        [TableColumnSetting("TrademarkNo", DataLength = 100)]
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

        private string m_TrademarOriginalNo;
        /// <summary>
        /// 原始案號
        /// </summary>
        [TableColumnSetting("TrademarOriginalNo", DataLength = 300)]
        public string TrademarOriginalNo
        {
            get
            {
                return m_TrademarOriginalNo;
            }
            set
            {
                m_TrademarOriginalNo = value;
            }
        }

        private string m_TrademarkName;
        /// <summary>
        /// 商標名稱
        /// </summary>
        [TableColumnSetting("TrademarkName", DataLength = 1000)]
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

        private string m_TrademarkOvertureName;
        /// <summary>
        /// 提案家族
        /// </summary>
        [TableColumnSetting("TrademarkOvertureName", DataLength = 1000)]
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
        [TableColumnSetting("ApplicantKeys", DataLength = 300)]
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

        private int? m_ApplicantKey;
        /// <summary>
        /// 申請人
        /// </summary>
        [TableColumnSetting("ApplicantKey", DbType = SqlDataType.Int, DataLength = 4)]
        public int? ApplicantKey
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

        private string m_StyleName;
        /// <summary>
        /// 商標樣式
        /// </summary>
        [TableColumnSetting("StyleName", DataLength = 100)]
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
        /// <summary>
        /// 案件類別
        /// </summary>
        [TableColumnSetting("TMTypeName", DataLength = 100)]
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

        private int? m_Status;
        /// <summary>
        /// 案件階段
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
        /// 案件階段描述
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

        private int? m_WorkerKey;
        /// <summary>
        /// 本所承辦人
        /// </summary>
        [TableColumnSetting("WorkerKey", DbType = SqlDataType.Int, DataLength = 4)]
        public int? WorkerKey
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

        private DateTime? m_EntrustDate;
        /// <summary>
        /// 本所委辦日期
        /// </summary>
        [TableColumnSetting("EntrustDate", DbType = SqlDataType.DateTime, DataLength = 8)]
        public DateTime? EntrustDate
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

        private int? m_OutsourcingAttorney;
        /// <summary>
        /// 所外承辦事務所
        /// </summary>
        [TableColumnSetting("OutsourcingAttorney", DbType = SqlDataType.Int, DataLength = 4)]
        public int? OutsourcingAttorney
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

        private int? m_OutsourcingAttorneyWorker;
        /// <summary>
        /// 所外事務所承辦人
        /// </summary>
        [TableColumnSetting("OutsourcingAttorneyWorker", DbType = SqlDataType.Int, DataLength = 4)]
        public int? OutsourcingAttorneyWorker
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
        /// <summary>
        /// 對方案號
        /// </summary>
        [TableColumnSetting("OutsourcingTrademarkNo", DataLength = 100)]
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

        private DateTime? m_OutsourcingDate;
        /// <summary>
        /// 所外委辦日期
        /// </summary>
        [TableColumnSetting("OutsourcingDate", DbType = SqlDataType.DateTime, DataLength = 8)]
        public DateTime? OutsourcingDate
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

        private DateTime? m_ApplicationDate;
        /// <summary>
        /// 申請日期
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

        private string m_DisagreementNo;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("DisagreementNo", DataLength = 200)]
        public string DisagreementNo
        {
            get
            {
                return m_DisagreementNo;
            }
            set
            {
                m_DisagreementNo = value;
            }
        }

        private string m_ApplicationNo;
        /// <summary>
        /// 申請案號
        /// </summary>
        [TableColumnSetting("ApplicationNo", DataLength = 1000)]
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

        private DateTime? m_RegistrationDate;
        /// <summary>
        /// 註冊日期
        /// </summary>
        [TableColumnSetting("RegistrationDate", DbType = SqlDataType.DateTime, DataLength = 8)]
        public DateTime? RegistrationDate
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
        /// <summary>
        /// 註冊證號
        /// </summary>
        [TableColumnSetting("RegistrationNo", DataLength = 100)]
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

        private DateTime? m_LawDate;
        /// <summary>
        /// 專用期限
        /// </summary>
        [TableColumnSetting("LawDate", DbType = SqlDataType.DateTime, DataLength = 8)]
        public DateTime? LawDate
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
        /// <summary>
        /// 註冊類別
        /// </summary>
        [TableColumnSetting("RegisterProduct", DataLength = 6000)]
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
        /// <summary>
        /// 商品名稱
        /// </summary>
        [TableColumnSetting("RegisterProductName")]
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

        private DateTime? m_ExtendedDate;
        /// <summary>
        /// 可辦延展日期
        /// </summary>
        [TableColumnSetting("ExtendedDate", DbType = SqlDataType.DateTime, DataLength = 8)]
        public DateTime? ExtendedDate
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

        private string m_Remarks;
        /// <summary>
        /// 備註
        /// </summary>
        [TableColumnSetting("Remarks")]
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
        /// <summary>
        /// 代表圖路徑
        /// </summary>
        [TableColumnSetting("PicPath", DataLength = 1000)]
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
        /// 主要委託人--貴方案號
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

        private string m_Introducer;
        /// <summary>
        /// 引案人
        /// </summary>
        [TableColumnSetting("Introducer", DataLength = 1000)]
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

        private DateTime? m_ObjectionDate;
        /// <summary>
        /// 異議日期
        /// </summary>
        [TableColumnSetting("ObjectionDate", DbType = SqlDataType.DateTime, DataLength = 8)]
        public DateTime? ObjectionDate
        {
            get
            {
                return m_ObjectionDate;
            }
            set
            {
                m_ObjectionDate = value;
            }
        }

        private string m_ObjectionPeople;
        /// <summary>
        /// 被異議人
        /// </summary>
        [TableColumnSetting("ObjectionPeople", DataLength = 1000)]
        public string ObjectionPeople
        {
            get
            {
                return m_ObjectionPeople;
            }
            set
            {
                m_ObjectionPeople = value;
            }
        }

        private string m_ObjectionNo;
        /// <summary>
        /// 異議案號
        /// </summary>
        [TableColumnSetting("ObjectionNo", DataLength = 1000)]
        public string ObjectionNo
        {
            get
            {
                return m_ObjectionNo;
            }
            set
            {
                m_ObjectionNo = value;
            }
        }

        private string m_ObjectionTrademarkName;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("ObjectionTrademarkName", DataLength = 1000)]
        public string ObjectionTrademarkName
        {
            get
            {
                return m_ObjectionTrademarkName;
            }
            set
            {
                m_ObjectionTrademarkName = value;
            }
        }

        private string m_ObjectionApplicationNo;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("ObjectionApplicationNo", DataLength = 1000)]
        public string ObjectionApplicationNo
        {
            get
            {
                return m_ObjectionApplicationNo;
            }
            set
            {
                m_ObjectionApplicationNo = value;
            }
        }

        private DateTime? m_ObjectionApplicationDate;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("ObjectionApplicationDate", DbType = SqlDataType.DateTime, DataLength = 8)]
        public DateTime? ObjectionApplicationDate
        {
            get
            {
                return m_ObjectionApplicationDate;
            }
            set
            {
                m_ObjectionApplicationDate = value;
            }
        }

        private DateTime? m_ObjectionNoticeDate;
        /// <summary>
        /// 被異議商標公告日
        /// </summary>
        [TableColumnSetting("ObjectionNoticeDate", DbType = SqlDataType.DateTime, DataLength = 8)]
        public DateTime? ObjectionNoticeDate
        {
            get
            {
                return m_ObjectionNoticeDate;
            }
            set
            {
                m_ObjectionNoticeDate = value;
            }
        }

        private string m_ObjectionNoticeNo;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("ObjectionNoticeNo", DataLength = 1000)]
        public string ObjectionNoticeNo
        {
            get
            {
                return m_ObjectionNoticeNo;
            }
            set
            {
                m_ObjectionNoticeNo = value;
            }
        }

        private string m_ObjectionClass;
        /// <summary>
        /// 異議類別
        /// </summary>
        [TableColumnSetting("ObjectionClass", DataLength = 1000)]
        public string ObjectionClass
        {
            get
            {
                return m_ObjectionClass;
            }
            set
            {
                m_ObjectionClass = value;
            }
        }

        private string m_ObjectionContent;
        /// <summary>
        /// 議異內容
        /// </summary>
        [TableColumnSetting("ObjectionContent")]
        public string ObjectionContent
        {
            get
            {
                return m_ObjectionContent;
            }
            set
            {
                m_ObjectionContent = value;
            }
        }

        private DateTime? m_ObjectionRegistrationDate;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("ObjectionRegistrationDate", DbType = SqlDataType.DateTime, DataLength = 8)]
        public DateTime? ObjectionRegistrationDate
        {
            get
            {
                return m_ObjectionRegistrationDate;
            }
            set
            {
                m_ObjectionRegistrationDate = value;
            }
        }

        private string m_ObjectionRegistrationNo;
        /// <summary>
        /// 被異議商標証號
        /// </summary>
        [TableColumnSetting("ObjectionRegistrationNo", DataLength = 1000)]
        public string ObjectionRegistrationNo
        {
            get
            {
                return m_ObjectionRegistrationNo;
            }
            set
            {
                m_ObjectionRegistrationNo = value;
            }
        }

        private DateTime? m_ObjectionDueDate;
        /// <summary>
        /// 官方期限
        /// </summary>
        [TableColumnSetting("ObjectionDueDate", DbType = SqlDataType.DateTime, DataLength = 8)]
        public DateTime? ObjectionDueDate
        {
            get
            {
                return m_ObjectionDueDate;
            }
            set
            {
                m_ObjectionDueDate = value;
            }
        }

        private string m_ObjectionPicPath;
        /// <summary>
        /// 被異議人的商標圖
        /// </summary>
        [TableColumnSetting("ObjectionPicPath", DataLength = 1000)]
        public string ObjectionPicPath
        {
            get
            {
                return m_ObjectionPicPath;
            }
            set
            {
                m_ObjectionPicPath = value;
            }
        }

        private string m_Creator;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("Creator", DataLength = 200)]
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
        [TableColumnSetting("LastModifyWorker", DataLength = 200)]
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

        private int? m_Locker;
        /// <summary>
        /// 正在編輯者 進行資料鎖定, Null表示無人編輯中
        /// </summary>
        [TableColumnSetting("Locker", DbType = SqlDataType.Int, DataLength = 4)]
        public int? Locker
        {
            get
            {
                return m_Locker;
            }
            set
            {
                m_Locker = value;
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
            List<CTrademarkControversyManagement> list = new List<CTrademarkControversyManagement>();
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
                retObj = orm.ReadListToObjs<CTrademarkControversyManagement>(ColumnName + "=@" + ColumnName, ref list, ParList);
            }
            else
            {
                retObj = orm.ReadListToObjs<CTrademarkControversyManagement>(ColumnName + "=@" + ColumnName + " and TrademarkControversyID<>" + this.TrademarkControversyID.ToString(), ref list, ParList);
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

        #region 取得一筆資料  ReadOne(ref CTrademarkControversyManagement Item, string strCusTableName = ")
        /// <summary>
        /// 取得一筆TrademarkControversyManagementT資料
        /// </summary>          
        /// <param name="item"></param>   
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>
        /// <returns>0:成功 ; string:失敗</returns>       
        public static object ReadOne(ref CTrademarkControversyManagement Item, string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.ReadOneToObj(ref Item, CusTableName: strCusTableName);
            return retObj;
        }
        #endregion

        #region 取得一筆資料 ReadOne(int iPKey, ref DB_MenuRoleTModel item, string strCusTableName = "")
        /// <summary>
        /// 取得一筆TrademarkControversyManagementT資料
        /// </summary>
        /// <param name="iPKey">指定某筆資料的Key值(不適合複合key)</param>     
        /// <param name="item"></param>   
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>
        /// <returns>0:成功 ; string:失敗</returns>       
        public static object ReadOne(int iPKey, ref CTrademarkControversyManagement item, string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.ReadOneToObj(iPKey, ref item, CusTableName: strCusTableName);
            return retObj;
        }
        #endregion

        #region 取得一筆TrademarkControversyManagementT資料 ReadOne(string strSqlWhere, System.Data.SqlClient.SqlParameter[] MySqlParameterList=null, string strCusTableName = "")
        /// <summary>
        /// 取得一筆TrademarkControversyManagementT資料;如果有多筆符合條件，則只回傳null
        /// </summary>
        /// <param name="strSqlWhere">查詢條件(不用加「where」關鍵字, 可加Sql參數,例如: account=@account)</param>
        /// <param name="MySqlParameterList">Sql參數</param>
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>
        /// <returns>0:成功 ; string:失敗</returns>
        public static object ReadOne(string strSqlWhere, ref CTrademarkControversyManagement item, System.Data.SqlClient.SqlParameter[] MySqlParameterList = null, string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            List<CTrademarkControversyManagement> itemlist = new List<CTrademarkControversyManagement>();
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

        #region 取得多筆CTrademarkControversyManagement資料 ReadList
        /// <summary>
        /// 取得多筆 TrademarkControversyManagementT資料 
        /// </summary>
        /// <param name="Items"></param>
        /// <param name="strSqlWhere">SQL條件式 (不用加「where」關鑵字,可加Sql參數,例如: account=@account)</param>
        /// <param name="MySqlParameterList">Sql參數</param>
        /// <param name="strOrderBy">SQL排序式 , 當空值時，預設帶[ CreateDateTime Desc] (不用加「Order by 」關鑵字, 例 "uid desc,createDateTime asc ")</param>
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>      
        /// <returns></returns>
        public static object ReadList(ref List<CTrademarkControversyManagement> Items, string strSqlWhere = "", System.Data.SqlClient.SqlParameter[] MySqlParameterList = null, string strOrderBy = "", string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();

            object retObj = orm.ReadListToObjs<CTrademarkControversyManagement>(strSqlWhere, ref Items, sqlParameterList: MySqlParameterList, OrderBy: strOrderBy, CusTableName: strCusTableName);

            return retObj;
        }

        #endregion

        #region 取得多筆 TrademarkControversyManagementT資料 , 指定頁數和頁碼 ReadList
        /// <summary>
        /// 取得多筆 TrademarkControversyManagementT資料 , 指定頁數和頁碼
        /// </summary>
        /// <param name="PageSize">一頁的筆數</param>
        /// <param name="PageIndex">第 n 頁</param>
        /// <param name="Items"></param>
        /// <param name="strSqlWhere">SQL條件式 (不用加「where」關鑵字,可加Sql參數,例如: account=@account)</param>
        /// <param name="MySqlParameterList">Sql參數</param>
        /// <param name="strOrderBy">SQL排序式 , 當空值時，預設帶[ CreateDateTime Desc] (不用加「Order by 」關鑵字, 例 "uid desc,createDateTime asc ")</param>
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>       
        /// <returns></returns>
        public static object ReadList(int PageSize, int PageIndex, ref List<CTrademarkControversyManagement> Items, string strSqlWhere = "", System.Data.SqlClient.SqlParameter[] MySqlParameterList = null, string strOrderBy = "", string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();

            object retObj = orm.ReadListToObjs<CTrademarkControversyManagement>(PageSize, PageIndex, strSqlWhere, ref Items, sqlParameterList: MySqlParameterList, OrderBy: strOrderBy, CusTableName: strCusTableName);

            return retObj;
        }
        #endregion

        #region Create
        /// <summary>
        /// 新增TrademarkControversyManagementT 項目
        /// </summary> 
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>      
        /// <returns>0:成功 ; string:失敗</returns>
        public object Create(string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.InsertByObj<CTrademarkControversyManagement>(this, strCusTableName);
            return retObj;
        }
        #endregion

        #region Update
        /// <summary>
        /// 更新 TrademarkControversyManagementT 項目
        /// </summary>       
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param> 
        /// <returns>0:成功 ; string:失敗</returns>
        public object Update(string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.UpdateObj<CTrademarkControversyManagement>(this, strCusTableName);
            return retObj;
        }
        #endregion

        #region Delete

        #region 刪除項目TrademarkControversyManagementT Delete()
        /// <summary>
        /// 刪除項目TrademarkControversyManagementT
        /// </summary>  
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>
        /// <returns></returns>   
        public object Delete(string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.DeleteObj<CTrademarkControversyManagement>(this, strCusTableName);
            return retObj;
        }
        #endregion

        #region 刪除項目TrademarkControversyManagementT Delete(int iPKey)
        /// <summary>
        /// 刪除項目TrademarkControversyManagementT , 指定某一筆主鍵刪除(單筆)
        /// </summary>
        /// <param name="iPKey">指定刪除某筆資料的Key值</param> 
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>      
        /// <returns></returns>
        public object Delete(int iPKey, string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.DeleteObj<CTrademarkControversyManagement>(iPKey, strCusTableName);
            return retObj;
        }
        #endregion

        #region 刪除項目TrademarkControversyManagementT Delete(string strSqlWhere)
        /// <summary>
        /// 刪除項目TrademarkControversyManagementT ,符合條件刪除(多筆)
        /// </summary>
        /// <param name="strSqlWhere">查詢條件(不用加「where」關鍵字)</param>   
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>    
        /// <returns></returns>
        public object Delete(string strSqlWhere, string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.DeleteObj<CTrademarkControversyManagement>(strSqlWhere, strCusTableName);
            return retObj;
        }
        #endregion

        #endregion

        #endregion
    }
    #endregion =================
}
