﻿using H3Operator.DBHelper;
using H3Operator.DBModels;
using System;
using System.Collections.Generic;

namespace LawtechPTWeb.Models
{
    #region DB_ApplicantTModel=================
    /// <summary>
    /// 客戶資料表
    /// </summary>
    [TableMapping("ApplicantT")]
    public class DB_ApplicantTModel : SysBaseModel
    {
        #region Public property

        private int m_ApplicantKey;
        /// <summary>
        /// 客戶資料表 PK
        /// </summary>
        [TableColumnSetting("ApplicantKey", DbType = SqlDataType.Int, IsPrimary = true, IsCumulative = true, IsCanNull = false, DataLength = 4)]
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

        private string m_ApplicantName;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("ApplicantName", IsCanNull = false, DataLength = 1000)]
        public string ApplicantName
        {
            get
            {
                return m_ApplicantName;
            }
            set
            {
                m_ApplicantName = value;
            }
        }

        private string m_ApplicantNameEn;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("ApplicantNameEn", DataLength = 4000)]
        public string ApplicantNameEn
        {
            get
            {
                return m_ApplicantNameEn;
            }
            set
            {
                m_ApplicantNameEn = value;
            }
        }

        private string m_ApplicantSymbol;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("ApplicantSymbol", DataLength = 200)]
        public string ApplicantSymbol
        {
            get
            {
                return m_ApplicantSymbol;
            }
            set
            {
                m_ApplicantSymbol = value;
            }
        }

        private string m_ID;
        /// <summary>
        /// 統編/身份証號
        /// </summary>
        [TableColumnSetting("ID", DataLength = 400)]
        public string ID
        {
            get
            {
                return m_ID;
            }
            set
            {
                m_ID = value;
            }
        }

        private string m_Address;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("Address", DataLength = 4000)]
        public string Address
        {
            get
            {
                return m_Address;
            }
            set
            {
                m_Address = value;
            }
        }

        private string m_AddressEn;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("AddressEn", DataLength = 4000)]
        public string AddressEn
        {
            get
            {
                return m_AddressEn;
            }
            set
            {
                m_AddressEn = value;
            }
        }

        private string m_ContactAddr;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("ContactAddr", DataLength = 1000)]
        public string ContactAddr
        {
            get
            {
                return m_ContactAddr;
            }
            set
            {
                m_ContactAddr = value;
            }
        }

        private string m_Email;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("Email", DataLength = 1000)]
        public string Email
        {
            get
            {
                return m_Email;
            }
            set
            {
                m_Email = value;
            }
        }

        private string m_WebSite;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("WebSite", DataLength = 4000)]
        public string WebSite
        {
            get
            {
                return m_WebSite;
            }
            set
            {
                m_WebSite = value;
            }
        }

        private string m_PrincipalName;
        /// <summary>
        /// 代表人
        /// </summary>
        [TableColumnSetting("PrincipalName", DataLength = 2000)]
        public string PrincipalName
        {
            get
            {
                return m_PrincipalName;
            }
            set
            {
                m_PrincipalName = value;
            }
        }

        private string m_PrincipalNameEn;
        /// <summary>
        /// 代表人(英)
        /// </summary>
        [TableColumnSetting("PrincipalNameEn", DataLength = 2000)]
        public string PrincipalNameEn
        {
            get
            {
                return m_PrincipalNameEn;
            }
            set
            {
                m_PrincipalNameEn = value;
            }
        }

        private string m_Chage;
        /// <summary>
        /// 異動註記
        /// </summary>
        [TableColumnSetting("Chage", DataLength = 2000)]
        public string Chage
        {
            get
            {
                return m_Chage;
            }
            set
            {
                m_Chage = value;
            }
        }

        private string m_TEL;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("TEL", DataLength = 200)]
        public string TEL
        {
            get
            {
                return m_TEL;
            }
            set
            {
                m_TEL = value;
            }
        }

        private string m_FAX;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("FAX", DataLength = 200)]
        public string FAX
        {
            get
            {
                return m_FAX;
            }
            set
            {
                m_FAX = value;
            }
        }

        private string m_Remart;
        /// <summary>
        /// 備    註
        /// </summary>
        [TableColumnSetting("Remart", DataLength = 8000)]
        public string Remart
        {
            get
            {
                return m_Remart;
            }
            set
            {
                m_Remart = value;
            }
        }

        private bool? m_P;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("P", DbType = SqlDataType.Bit, DataLength = 1)]
        public bool? P
        {
            get
            {
                return m_P;
            }
            set
            {
                m_P = value;
            }
        }

        private bool? m_T;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("T", DbType = SqlDataType.Bit, DataLength = 1)]
        public bool? T
        {
            get
            {
                return m_T;
            }
            set
            {
                m_T = value;
            }
        }

        private bool? m_C;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("C", DbType = SqlDataType.Bit, DataLength = 1)]
        public bool? C
        {
            get
            {
                return m_C;
            }
            set
            {
                m_C = value;
            }
        }

        private bool? m_L;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("L", DbType = SqlDataType.Bit, DataLength = 1)]
        public bool? L
        {
            get
            {
                return m_L;
            }
            set
            {
                m_L = value;
            }
        }

        private bool? m_E;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("E", DbType = SqlDataType.Bit, DataLength = 1)]
        public bool? E
        {
            get
            {
                return m_E;
            }
            set
            {
                m_E = value;
            }
        }

        private string m_SendTitle;
        /// <summary>
        /// 信件抬頭
        /// </summary>
        [TableColumnSetting("SendTitle", DataLength = 400)]
        public string SendTitle
        {
            get
            {
                return m_SendTitle;
            }
            set
            {
                m_SendTitle = value;
            }
        }

        private string m_Account;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("Account", DataLength = 100)]
        public string Account
        {
            get
            {
                return m_Account;
            }
            set
            {
                m_Account = value;
            }
        }

        private string m_Password;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("Password", DataLength = 100)]
        public string Password
        {
            get
            {
                return m_Password;
            }
            set
            {
                m_Password = value;
            }
        }

        private int? m_MainCorp;
        /// <summary>
        /// 所屬母公司
        /// </summary>
        [TableColumnSetting("MainCorp", DbType = SqlDataType.Int, DataLength = 4)]
        public int? MainCorp
        {
            get
            {
                return m_MainCorp;
            }
            set
            {
                m_MainCorp = value;
            }
        }

        private int? m_Worker;
        /// <summary>
        /// 本所服務人員
        /// </summary>
        [TableColumnSetting("Worker", DbType = SqlDataType.Int, DataLength = 4)]
        public int? Worker
        {
            get
            {
                return m_Worker;
            }
            set
            {
                m_Worker = value;
            }
        }

        private bool? m_LawVIP;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("LawVIP", DbType = SqlDataType.Bit, DataLength = 1)]
        public bool? LawVIP
        {
            get
            {
                return m_LawVIP;
            }
            set
            {
                m_LawVIP = value;
            }
        }

        private int? m_Source;
        /// <summary>
        /// 客戶來源
        /// </summary>
        [TableColumnSetting("Source", DbType = SqlDataType.Int, DataLength = 4)]
        public int? Source
        {
            get
            {
                return m_Source;
            }
            set
            {
                m_Source = value;
            }
        }

        private int? m_RecWay;
        /// <summary>
        /// 請款方式
        /// </summary>
        [TableColumnSetting("RecWay", DbType = SqlDataType.Int, DataLength = 4)]
        public int? RecWay
        {
            get
            {
                return m_RecWay;
            }
            set
            {
                m_RecWay = value;
            }
        }

        private int? m_LargeEnty;
        /// <summary>
        /// 企業實體
        /// </summary>
        [TableColumnSetting("LargeEnty", DbType = SqlDataType.Int, DataLength = 4)]
        public int? LargeEnty
        {
            get
            {
                return m_LargeEnty;
            }
            set
            {
                m_LargeEnty = value;
            }
        }

        private string m_Receiptor;
        /// <summary>
        /// 收據抬頭
        /// </summary>
        [TableColumnSetting("Receiptor", DataLength = 400)]
        public string Receiptor
        {
            get
            {
                return m_Receiptor;
            }
            set
            {
                m_Receiptor = value;
            }
        }

        private string m_SourceDescription;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("SourceDescription", DataLength = 400)]
        public string SourceDescription
        {
            get
            {
                return m_SourceDescription;
            }
            set
            {
                m_SourceDescription = value;
            }
        }

        private int? m_ClientKind;
        /// <summary>
        /// 客戶種類
        /// </summary>
        [TableColumnSetting("ClientKind", DbType = SqlDataType.Int, DataLength = 4)]
        public int? ClientKind
        {
            get
            {
                return m_ClientKind;
            }
            set
            {
                m_ClientKind = value;
            }
        }

        private int? m_BusinessKind;
        /// <summary>
        /// 產業別
        /// </summary>
        [TableColumnSetting("BusinessKind", DbType = SqlDataType.Int, DataLength = 4)]
        public int? BusinessKind
        {
            get
            {
                return m_BusinessKind;
            }
            set
            {
                m_BusinessKind = value;
            }
        }

        private string m_Business;
        /// <summary>
        /// 主要營業項目
        /// </summary>
        [TableColumnSetting("Business", DataLength = 2000)]
        public string Business
        {
            get
            {
                return m_Business;
            }
            set
            {
                m_Business = value;
            }
        }

        private string m_Capital;
        /// <summary>
        /// 資本額
        /// </summary>
        [TableColumnSetting("Capital", DataLength = 2000)]
        public string Capital
        {
            get
            {
                return m_Capital;
            }
            set
            {
                m_Capital = value;
            }
        }

        private string m_CollectionRecord;
        /// <summary>
        /// 收款記錄
        /// </summary>
        [TableColumnSetting("CollectionRecord", DataLength = 400)]
        public string CollectionRecord
        {
            get
            {
                return m_CollectionRecord;
            }
            set
            {
                m_CollectionRecord = value;
            }
        }

        private DateTime? m_StartedDate;
        /// <summary>
        /// 開始來往時間
        /// </summary>
        [TableColumnSetting("StartedDate", DbType = SqlDataType.DateTime, DataLength = 8)]
        public DateTime? StartedDate
        {
            get
            {
                return m_StartedDate;
            }
            set
            {
                m_StartedDate = value;
            }
        }

        private string m_Evaluation;
        /// <summary>
        /// 客戶評定
        /// </summary>
        [TableColumnSetting("Evaluation", DataLength = 400)]
        public string Evaluation
        {
            get
            {
                return m_Evaluation;
            }
            set
            {
                m_Evaluation = value;
            }
        }

        private int? m_LockedWorker;
        /// <summary>
        /// 當前鎖定者
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
            List<DB_ApplicantTModel> list = new List<DB_ApplicantTModel>();
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
                retObj = orm.ReadListToObjs<DB_ApplicantTModel>(ColumnName + "=@" + ColumnName, ref list, ParList);
            }
            else
            {
                retObj = orm.ReadListToObjs<DB_ApplicantTModel>(ColumnName + "=@" + ColumnName + " and ApplicantKey<>" + this.ApplicantKey.ToString(), ref list, ParList);
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

        #region 取得查詢後的總筆數 public static object GetTotalCountRows(ref int iCountRows, string strSqlWhere = ", System.Data.SqlClient.SqlParameter[] sqlParameterList = null,  string strCusTableName = ")
        /// <summary>
        /// [DBMapping] 取得查詢後的總筆數
        /// </summary>
        /// <param name="iCountRows">回傳此次查詢的總筆數</param>
        /// <param name="strSqlWhere">SQL條件式，可帶空字串，即表示取該資料表所有的筆數 (不用加「where」關鑵字)</param>
        /// <param name="sqlParameterList">Sql 參數</param>
        /// <param name="strCusTableName">指定的資料表名稱(預設為類別所綁定的資料表，當不為空字串時，則以指定的資料表名稱)</param>
        /// <returns></returns>   
        public static object GetTotalCountRows(ref int iCountRows, string strSqlWhere = "", System.Data.SqlClient.SqlParameter[] sqlParameterList = null, string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.ReadCountRows<DB_ApplicantTModel>(ref iCountRows, strSqlWhere, sqlParameterList: sqlParameterList, CusTableName: strCusTableName);
            return retObj;
        }
        #endregion

        #region 取得一筆資料  ReadOne(ref DB_ApplicantTModel Item, string strCusTableName = ")
        /// <summary>
        /// 取得一筆ApplicantT資料
        /// </summary>          
        /// <param name="item"></param>   
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>
        /// <returns>0:成功 ; string:失敗</returns>       
        public static object ReadOne(ref DB_ApplicantTModel Item, string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.ReadOneToObj(ref Item, CusTableName: strCusTableName);
            return retObj;
        }
        #endregion

        #region 取得一筆資料 ReadOne(int iPKey, ref DB_ApplicantTModel item, string strCusTableName = "")
        /// <summary>
        /// 取得一筆ApplicantT資料
        /// </summary>
        /// <param name="iPKey">指定某筆資料的Key值(不適合複合key)</param>     
        /// <param name="item"></param>   
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>
        /// <returns>0:成功 ; string:失敗</returns>       
        public static object ReadOne(int iPKey, ref DB_ApplicantTModel item, string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.ReadOneToObj(iPKey, ref item, CusTableName: strCusTableName);
            return retObj;
        }
        #endregion

        #region 取得一筆ApplicantT資料 ReadOne(string strSqlWhere, System.Data.SqlClient.SqlParameter[] MySqlParameterList=null, string strCusTableName = "")
        /// <summary>
        /// 取得一筆ApplicantT資料;如果有多筆符合條件，則只回傳null
        /// </summary>
        /// <param name="strSqlWhere">查詢條件(不用加「where」關鍵字, 可加Sql參數,例如: account=@account)</param>
        /// <param name="MySqlParameterList">Sql參數</param>
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>
        /// <returns>0:成功 ; string:失敗</returns>
        public static object ReadOne(string strSqlWhere, ref DB_ApplicantTModel item, System.Data.SqlClient.SqlParameter[] MySqlParameterList = null, string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            List<DB_ApplicantTModel> itemlist = new List<DB_ApplicantTModel>();
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

        #region 取得多筆DB_ApplicantTModel資料 ReadList
        /// <summary>
        /// 取得多筆 ApplicantT資料，符合的全部撈出並轉成物件
        /// </summary>
        /// <param name="Items"></param>
        /// <param name="strSqlWhere">SQL條件式 (不用加「where」關鑵字,可加Sql參數,例如: account=@account)</param>
        /// <param name="MySqlParameterList">Sql參數</param>
        /// <param name="strOrderBy">SQL排序式 , 當空值時，預設帶[ CreateDateTime Desc] (不用加「Order by 」關鑵字, 例 "uid desc,createDateTime asc ")</param>
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>      
        /// <returns></returns>
        public static object ReadList(ref List<DB_ApplicantTModel> Items, string strSqlWhere = "", System.Data.SqlClient.SqlParameter[] MySqlParameterList = null, string strOrderBy = "", string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();

            object retObj = orm.ReadListToObjs<DB_ApplicantTModel>(strSqlWhere, ref Items, sqlParameterList: MySqlParameterList, OrderBy: strOrderBy, CusTableName: strCusTableName);

            return retObj;
        }

        #endregion

        #region 取得多筆 ApplicantT資料 , 指定頁數和頁碼 ReadList
        /// <summary>
        /// 取得多筆 ApplicantT資料 , 指定頁數和頁碼
        /// </summary>
        /// <param name="PageSize">一頁的筆數</param>
        /// <param name="PageIndex">第 n 頁;從 0 起算，當值小於0時，預設帶0 (0即表示第一頁)</param>
        /// <param name="Items"></param>
        /// <param name="strSqlWhere">SQL條件式 (不用加「where」關鑵字,可加Sql參數,例如: account=@account)</param>
        /// <param name="MySqlParameterList">Sql參數</param>
        /// <param name="strOrderBy">SQL排序式 , 當空值時，預設帶[ CreateDateTime Desc] (不用加「Order by 」關鑵字, 例 "uid desc,createDateTime asc ")</param>
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>       
        /// <returns></returns>
        public static object ReadList(int PageSize, int PageIndex, ref List<DB_ApplicantTModel> Items, string strSqlWhere = "", System.Data.SqlClient.SqlParameter[] MySqlParameterList = null, string strOrderBy = "", string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            int iTotalCountRows = 0;
            object retObj = orm.ReadListToObjsByFetch<DB_ApplicantTModel>(PageSize, PageIndex, strSqlWhere, ref Items, ref iTotalCountRows, sqlParameterList: MySqlParameterList, OrderBy: strOrderBy, CusTableName: strCusTableName);

            return retObj;
        }
        #endregion

        #region 取得多筆 ApplicantT資料 , 指定頁數和頁碼 ReadList,回傳查詢的總筆數
        /// <summary>
        /// 取得多筆 ApplicantT資料 , 指定頁數和頁碼,回傳查詢的總筆數
        /// </summary>
        /// <param name="PageSize">一頁的筆數</param>
        /// <param name="PageIndex">第 n 頁;從 0 起算，當值小於0時，預設帶0 (0即表示第一頁)</param>
        /// <param name="Items"></param>
        /// <param name="iTotalRowCount">回傳此次查詢的總筆數</param>
        /// <param name="strSqlWhere">SQL條件式 (不用加「where」關鑵字,可加Sql參數,例如: account=@account)</param>
        /// <param name="MySqlParameterList">Sql參數</param>
        /// <param name="strOrderBy">SQL排序式 , 當空值時，預設帶[ CreateDateTime Desc] (不用加「Order by 」關鑵字, 例 "uid desc,createDateTime asc ")</param>
        /// <param name="strCusTableName">指定的TableName(需跟原本的table有相同的table欄位和型態)</param>
        /// <returns></returns>
        public static object ReadList(int PageSize, int PageIndex, ref List<DB_ApplicantTModel> Items, ref int iTotalRowCount, string strSqlWhere = "", System.Data.SqlClient.SqlParameter[] MySqlParameterList = null, string strOrderBy = "", string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();

            object retObj = orm.ReadListToObjsByFetch<DB_ApplicantTModel>(PageSize, PageIndex, strSqlWhere, ref Items, ref iTotalRowCount, sqlParameterList: MySqlParameterList, OrderBy: strOrderBy, CusTableName: strCusTableName);

            return retObj;
        }
        #endregion

        #region Create
        /// <summary>
        /// 新增ApplicantT 項目
        /// </summary> 
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>      
        /// <returns>0:成功 ; string:失敗</returns>
        public object Create(string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.InsertByObj<DB_ApplicantTModel>(this, strCusTableName);
            return retObj;
        }
        #endregion

        #region Update
        /// <summary>
        /// 更新 ApplicantT 項目
        /// </summary>       
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param> 
        /// <returns>0:成功 ; string:失敗</returns>
        public object Update(string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.UpdateObj<DB_ApplicantTModel>(this, strCusTableName);
            return retObj;
        }
        #endregion

        #region Delete

        #region 刪除項目ApplicantT Delete()
        /// <summary>
        /// 刪除項目ApplicantT
        /// </summary>  
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>
        /// <returns></returns>   
        public object Delete(string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.DeleteObj<DB_ApplicantTModel>(this, strCusTableName);
            return retObj;
        }
        #endregion

        #region 刪除項目ApplicantT Delete(int iPKey)
        /// <summary>
        /// 刪除項目ApplicantT , 指定某一筆主鍵刪除(單筆)
        /// </summary>
        /// <param name="iPKey">指定刪除某筆資料的Key值</param> 
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>      
        /// <returns></returns>
        public object Delete(int iPKey, string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.DeleteObj<DB_ApplicantTModel>(iPKey, strCusTableName);
            return retObj;
        }
        #endregion

        #region 刪除項目ApplicantT Delete(string strSqlWhere)
        /// <summary>
        /// 刪除項目ApplicantT ,符合條件刪除(多筆)
        /// </summary>
        /// <param name="strSqlWhere">查詢條件(不用加「where」關鍵字)</param>   
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>    
        /// <returns></returns>
        public object Delete(string strSqlWhere, string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.DeleteObj<DB_ApplicantTModel>(strSqlWhere, strCusTableName);
            return retObj;
        }
        #endregion

        #endregion

        #endregion
    }
    #endregion =================
}