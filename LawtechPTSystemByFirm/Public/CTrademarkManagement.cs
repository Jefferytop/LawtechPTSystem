using System;
using System.Collections.Generic;
using H3Operator.DBHelper;
using H3Operator.DBModels;

namespace LawtechPTSystemByFirm.Public
{
    #region CTrademarkManagement=================
    /// <summary>
    /// 
    /// </summary>
    [TableMapping("TrademarkManagementT")]
    public class CTrademarkManagement : SysBaseModel
    {
        #region Public property

        private int m_TrademarkID;
        /// <summary>
        /// 商標案件管理表 PK
        /// </summary>
        [TableColumnSetting("TrademarkID", DbType = SqlDataType.Int, IsPrimary = true, IsCumulative = true, IsCanNull = false, DataLength = 4)]
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
        /// <summary>
        /// 本所案號
        /// </summary>
        [TableColumnSetting("TrademarkNo", DataLength = 1000)]
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
        /// 
        /// </summary>
        [TableColumnSetting("TrademarkOvertureName", DataLength = 200)]
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
        [TableColumnSetting("ApplicantKeys", DataLength = 600)]
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
        [TableColumnSetting("CountrySymbol", DataLength = 300)]
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

        private bool? m_TMNature;
        /// <summary>
        /// 案件性質0.委任 1.被委任
        /// </summary>
        [TableColumnSetting("TMNature", DbType = SqlDataType.Bit, DataLength = 1)]
        public bool? TMNature
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

        private int? m_Status;
        /// <summary>
        /// 狀態
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
        /// 狀態描述
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
        /// 本所承辦日期
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
        [TableColumnSetting("OutsourcingTrademarkNo", DataLength = 1000)]
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

        private DateTime? m_NoticeDate1;
        /// <summary>
        /// 第一次公告日期
        /// </summary>
        [TableColumnSetting("NoticeDate1", DbType = SqlDataType.DateTime, DataLength = 8)]
        public DateTime? NoticeDate1
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
        /// <summary>
        /// 第一次公告號數
        /// </summary>
        [TableColumnSetting("NoticeNo1", DataLength = 1000)]
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

        private DateTime? m_NoticeDate;
        /// <summary>
        /// 第二次公告日
        /// </summary>
        [TableColumnSetting("NoticeDate", DbType = SqlDataType.DateTime, DataLength = 8)]
        public DateTime? NoticeDate
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
        /// <summary>
        /// 第二次公告日
        /// </summary>
        [TableColumnSetting("NoticeNo", DataLength = 1000)]
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
        [TableColumnSetting("RegistrationNo", DataLength = 1000)]
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
        /// 註冊產品
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
        /// 
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
        /// 委託類型
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
        /// 
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
        /// 
        /// </summary>
        [TableColumnSetting("MainCustomerRefNo", DataLength = 1000)]
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
        /// 
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
        /// 
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
        /// 
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
        /// 
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

        private int? m_Locker;
        /// <summary>
        /// 
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
            List<CTrademarkManagement> list = new List<CTrademarkManagement>();
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
                retObj = orm.ReadListToObjs<CTrademarkManagement>(ColumnName + "=@" + ColumnName, ref list, ParList);
            }
            else
            {
                retObj = orm.ReadListToObjs<CTrademarkManagement>(ColumnName + "=@" + ColumnName + " and TrademarkID<>" + this.TrademarkID.ToString(), ref list, ParList);
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

        #region 取得一筆資料  ReadOne(ref CTrademarkManagement Item, string strCusTableName = ")
        /// <summary>
        /// 取得一筆TrademarkManagementT資料
        /// </summary>          
        /// <param name="item"></param>   
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>
        /// <returns>0:成功 ; string:失敗</returns>       
        public static object ReadOne(ref CTrademarkManagement Item, string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.ReadOneToObj(ref Item, CusTableName: strCusTableName);
            return retObj;
        }
        #endregion

        #region 取得一筆資料 ReadOne(int iPKey, ref CTrademarkManagement item, string strCusTableName = "")
        /// <summary>
        /// 取得一筆TrademarkManagementT資料
        /// </summary>
        /// <param name="iPKey">指定某筆資料的Key值(不適合複合key)</param>     
        /// <param name="item"></param>   
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>
        /// <returns>0:成功 ; string:失敗</returns>       
        public static object ReadOne(int iPKey, ref CTrademarkManagement item, string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.ReadOneToObj(iPKey, ref item, CusTableName: strCusTableName);
            return retObj;
        }
        #endregion

        #region 取得一筆TrademarkManagementT資料 ReadOne(string strSqlWhere, System.Data.SqlClient.SqlParameter[] MySqlParameterList=null, string strCusTableName = "")
        /// <summary>
        /// 取得一筆TrademarkManagementT資料;如果有多筆符合條件，則只回傳null
        /// </summary>
        /// <param name="strSqlWhere">查詢條件(不用加「where」關鍵字, 可加Sql參數,例如: account=@account)</param>
        /// <param name="MySqlParameterList">Sql參數</param>
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>
        /// <returns>0:成功 ; string:失敗</returns>
        public static object ReadOne(string strSqlWhere, ref CTrademarkManagement item, System.Data.SqlClient.SqlParameter[] MySqlParameterList = null, string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            List<CTrademarkManagement> itemlist = new List<CTrademarkManagement>();
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

        #region 取得多筆CTrademarkManagement資料 ReadList
        /// <summary>
        /// 取得多筆 TrademarkManagementT資料 
        /// </summary>
        /// <param name="Items"></param>
        /// <param name="strSqlWhere">SQL條件式 (不用加「where」關鑵字,可加Sql參數,例如: account=@account)</param>
        /// <param name="MySqlParameterList">Sql參數</param>
        /// <param name="strOrderBy">SQL排序式 , 當空值時，預設帶[ CreateDateTime Desc] (不用加「Order by 」關鑵字, 例 "uid desc,createDateTime asc ")</param>
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>      
        /// <returns></returns>
        public static object ReadList(ref List<CTrademarkManagement> Items, string strSqlWhere = "", System.Data.SqlClient.SqlParameter[] MySqlParameterList = null, string strOrderBy = "", string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();

            object retObj = orm.ReadListToObjs<CTrademarkManagement>(strSqlWhere, ref Items, sqlParameterList: MySqlParameterList, OrderBy: strOrderBy, CusTableName: strCusTableName);

            return retObj;
        }

        #endregion

        #region 取得多筆 TrademarkManagementT資料 , 指定頁數和頁碼 ReadList
        /// <summary>
        /// 取得多筆 TrademarkManagementT資料 , 指定頁數和頁碼
        /// </summary>
        /// <param name="PageSize">一頁的筆數</param>
        /// <param name="PageIndex">第 n 頁</param>
        /// <param name="Items"></param>
        /// <param name="strSqlWhere">SQL條件式 (不用加「where」關鑵字,可加Sql參數,例如: account=@account)</param>
        /// <param name="MySqlParameterList">Sql參數</param>
        /// <param name="strOrderBy">SQL排序式 , 當空值時，預設帶[ CreateDateTime Desc] (不用加「Order by 」關鑵字, 例 "uid desc,createDateTime asc ")</param>
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>       
        /// <returns></returns>
        public static object ReadList(int PageSize, int PageIndex, ref List<CTrademarkManagement> Items, string strSqlWhere = "", System.Data.SqlClient.SqlParameter[] MySqlParameterList = null, string strOrderBy = "", string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();

            object retObj = orm.ReadListToObjs<CTrademarkManagement>(PageSize, PageIndex, strSqlWhere, ref Items, sqlParameterList: MySqlParameterList, OrderBy: strOrderBy, CusTableName: strCusTableName);

            return retObj;
        }
        #endregion

        #region Create
        /// <summary>
        /// 新增TrademarkManagementT 項目
        /// </summary> 
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>      
        /// <returns>0:成功 ; string:失敗</returns>
        public object Create(string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.InsertByObj<CTrademarkManagement>(this, strCusTableName);
            return retObj;
        }
        #endregion

        #region Update
        /// <summary>
        /// 更新 TrademarkManagementT 項目
        /// </summary>       
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param> 
        /// <returns>0:成功 ; string:失敗</returns>
        public object Update(string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.UpdateObj<CTrademarkManagement>(this, strCusTableName);
            return retObj;
        }
        #endregion

        #region Delete

        #region 刪除項目TrademarkManagementT Delete()
        /// <summary>
        /// 刪除項目TrademarkManagementT
        /// </summary>  
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>
        /// <returns></returns>   
        public object Delete(string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.DeleteObj<CTrademarkManagement>(this, strCusTableName);
            return retObj;
        }
        #endregion

        #region 刪除項目TrademarkManagementT Delete(int iPKey)
        /// <summary>
        /// 刪除項目TrademarkManagementT , 指定某一筆主鍵刪除(單筆)
        /// </summary>
        /// <param name="iPKey">指定刪除某筆資料的Key值</param> 
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>      
        /// <returns></returns>
        public object Delete(int iPKey, string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.DeleteObj<CTrademarkManagement>(iPKey, strCusTableName);
            return retObj;
        }
        #endregion

        #region 刪除項目TrademarkManagementT Delete(string strSqlWhere)
        /// <summary>
        /// 刪除項目TrademarkManagementT ,符合條件刪除(多筆)
        /// </summary>
        /// <param name="strSqlWhere">查詢條件(不用加「where」關鍵字)</param>   
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>    
        /// <returns></returns>
        public object Delete(string strSqlWhere, string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.DeleteObj<CTrademarkManagement>(strSqlWhere, strCusTableName);
            return retObj;
        }
        #endregion

        #endregion

        #endregion
    }
    #endregion =================
}
