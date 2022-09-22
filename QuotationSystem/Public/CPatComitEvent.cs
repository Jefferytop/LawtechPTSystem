using H3Operator.DBHelper;
using H3Operator.DBModels;
using System;
using System.Collections.Generic;

namespace LawtechPTSystem.Public
{
    #region CPatComitEvent=================
    /// <summary>
    /// 
    /// </summary>
    [TableMapping("PatComitEventT")]
    public class CPatComitEvent : SysBaseModel
    {
        #region Public property

        private int m_PatComitEventID;
        /// <summary>
        /// 專利委辦記錄表
        /// </summary>
        [TableColumnSetting("PatComitEventID", DbType = SqlDataType.Int, IsPrimary = true, IsCumulative = true, IsCanNull = false, DataLength = 4)]
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

        private int m_PatentID;
        /// <summary>
        /// 專利資料表 PK
        /// </summary>
        [TableColumnSetting("PatentID", DbType = SqlDataType.Int, IsCanNull = false, DataLength = 4)]
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

        private DateTime? m_CreateDate;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("CreateDate", DbType = SqlDataType.DateTime, DataLength = 8)]
        public DateTime? CreateDate
        {
            get
            {
                return m_CreateDate;
            }
            set
            {
                m_CreateDate = value;
            }
        }

        private DateTime? m_OccurDate;
        /// <summary>
        /// 委辦日期
        /// </summary>
        [TableColumnSetting("OccurDate", DbType = SqlDataType.DateTime, DataLength = 8)]
        public DateTime? OccurDate
        {
            get
            {
                return m_OccurDate;
            }
            set
            {
                m_OccurDate = value;
            }
        }

        private string m_EventContent;
        /// <summary>
        /// 事件內容
        /// </summary>
        [TableColumnSetting("EventContent", DataLength = 1000)]
        public string EventContent
        {
            get
            {
                return m_EventContent;
            }
            set
            {
                m_EventContent = value;
            }
        }

        private string m_SingCode;
        /// <summary>
        /// 主管簽核碼
        /// </summary>
        [TableColumnSetting("SingCode", DataLength = 200)]
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

       
        private string m_SingCodeStatus;
        /// <summary>
        /// 主管簽核狀態
        /// </summary>
        [TableColumnSetting("SingCodeStatus", DataLength = 1000)]
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

        private string m_Result;
        /// <summary>
        /// 處理結果
        /// </summary>
        [TableColumnSetting("Result", DataLength = 6000)]
        public string Result
        {
            get
            {
                return m_Result;
            }
            set
            {
                m_Result = value;
            }
        }

        private int? m_WorkerKey;
        /// <summary>
        /// 申請案承辦人
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

        private int? m_AttorneyKey;
        /// <summary>
        /// 承辦事務所
        /// </summary>
        [TableColumnSetting("AttorneyKey", DbType = SqlDataType.Int, DataLength = 4)]
        public int? AttorneyKey
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

        private int? m_ALiaisonerKey;
        /// <summary>
        /// 事務所承辦人
        /// </summary>
        [TableColumnSetting("ALiaisonerKey", DbType = SqlDataType.Int, DataLength = 4)]
        public int? ALiaisonerKey
        {
            get
            {
                return m_ALiaisonerKey;
            }
            set
            {
                m_ALiaisonerKey = value;
            }
        }

        private DateTime? m_OfficerDate;
        /// <summary>
        /// 官方發文日
        /// </summary>
        [TableColumnSetting("OfficerDate", DbType = SqlDataType.DateTime, DataLength = 8)]
        public DateTime? OfficerDate
        {
            get
            {
                return m_OfficerDate;
            }
            set
            {
                m_OfficerDate = value;
            }
        }

        private DateTime? m_DueDate;
        /// <summary>
        /// 官方送件期限
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

        private DateTime? m_OfficeDueDate;
        /// <summary>
        /// 所內管制期限
        /// </summary>
        [TableColumnSetting("OfficeDueDate", DbType = SqlDataType.DateTime, DataLength = 8)]
        public DateTime? OfficeDueDate
        {
            get
            {
                return m_OfficeDueDate;
            }
            set
            {
                m_OfficeDueDate = value;
            }
        }

        private DateTime? m_StartDate;
        /// <summary>
        /// 開工日期
        /// </summary>
        [TableColumnSetting("StartDate", DbType = SqlDataType.DateTime, DataLength = 8)]
        public DateTime? StartDate
        {
            get
            {
                return m_StartDate;
            }
            set
            {
                m_StartDate = value;
            }
        }

        private DateTime? m_ComitDate;
        /// <summary>
        /// 送件日期
        /// </summary>
        [TableColumnSetting("ComitDate", DbType = SqlDataType.DateTime, DataLength = 8)]
        public DateTime? ComitDate
        {
            get
            {
                return m_ComitDate;
            }
            set
            {
                m_ComitDate = value;
            }
        }

        private DateTime? m_FinishDate;
        /// <summary>
        /// 完成日期
        /// </summary>
        [TableColumnSetting("FinishDate", DbType = SqlDataType.DateTime, DataLength = 8)]
        public DateTime? FinishDate
        {
            get
            {
                return m_FinishDate;
            }
            set
            {
                m_FinishDate = value;
            }
        }

        private string m_Remark;
        /// <summary>
        /// 備註
        /// </summary>
        [TableColumnSetting("Remark", DataLength = 6000)]
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
            List<CPatComitEvent> list = new List<CPatComitEvent>();
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
                retObj = orm.ReadListToObjs<CPatComitEvent>(ColumnName + "=@" + ColumnName, ref list, ParList);
            }
            else
            {
                retObj = orm.ReadListToObjs<CPatComitEvent>(ColumnName + "=@" + ColumnName + " and PatComitEventID<>" + this.PatComitEventID.ToString(), ref list, ParList);
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

        #region 取得一筆資料  ReadOne(ref CPatComitEvent Item, string strCusTableName = ")
        /// <summary>
        /// 取得一筆PatComitEventT資料
        /// </summary>          
        /// <param name="item"></param>   
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>
        /// <returns>0:成功 ; string:失敗</returns>       
        public static object ReadOne(ref CPatComitEvent Item, string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.ReadOneToObj(ref Item, CusTableName: strCusTableName);
            return retObj;
        }
        #endregion

        #region 取得一筆資料 ReadOne(int iPKey, ref DB_MenuRoleTModel item, string strCusTableName = "")
        /// <summary>
        /// 取得一筆PatComitEventT資料
        /// </summary>
        /// <param name="iPKey">指定某筆資料的Key值(不適合複合key)</param>     
        /// <param name="item"></param>   
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>
        /// <returns>0:成功 ; string:失敗</returns>       
        public static object ReadOne(int iPKey, ref CPatComitEvent item, string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.ReadOneToObj(iPKey, ref item, CusTableName: strCusTableName);
            return retObj;
        }
        #endregion

        #region 取得一筆PatComitEventT資料 ReadOne(string strSqlWhere, System.Data.SqlClient.SqlParameter[] MySqlParameterList=null, string strCusTableName = "")
        /// <summary>
        /// 取得一筆PatComitEventT資料;如果有多筆符合條件，則只回傳null
        /// </summary>
        /// <param name="strSqlWhere">查詢條件(不用加「where」關鍵字, 可加Sql參數,例如: account=@account)</param>
        /// <param name="MySqlParameterList">Sql參數</param>
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>
        /// <returns>0:成功 ; string:失敗</returns>
        public static object ReadOne(string strSqlWhere, ref CPatComitEvent item, System.Data.SqlClient.SqlParameter[] MySqlParameterList = null, string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            List<CPatComitEvent> itemlist = new List<CPatComitEvent>();
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

        #region 取得多筆CPatComitEvent資料 ReadList
        /// <summary>
        /// 取得多筆 PatComitEventT資料 
        /// </summary>
        /// <param name="Items"></param>
        /// <param name="strSqlWhere">SQL條件式 (不用加「where」關鑵字,可加Sql參數,例如: account=@account)</param>
        /// <param name="MySqlParameterList">Sql參數</param>
        /// <param name="strOrderBy">SQL排序式 , 當空值時，預設帶[ CreateDateTime Desc] (不用加「Order by 」關鑵字, 例 "uid desc,createDateTime asc ")</param>
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>      
        /// <returns></returns>
        public static object ReadList(ref List<CPatComitEvent> Items, string strSqlWhere = "", System.Data.SqlClient.SqlParameter[] MySqlParameterList = null, string strOrderBy = "", string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();

            object retObj = orm.ReadListToObjs<CPatComitEvent>(strSqlWhere, ref Items, sqlParameterList: MySqlParameterList, OrderBy: strOrderBy, CusTableName: strCusTableName);

            return retObj;
        }

        #endregion

        #region 取得多筆 PatComitEventT資料 , 指定頁數和頁碼 ReadList
        /// <summary>
        /// 取得多筆 PatComitEventT資料 , 指定頁數和頁碼
        /// </summary>
        /// <param name="PageSize">一頁的筆數</param>
        /// <param name="PageIndex">第 n 頁</param>
        /// <param name="Items"></param>
        /// <param name="strSqlWhere">SQL條件式 (不用加「where」關鑵字,可加Sql參數,例如: account=@account)</param>
        /// <param name="MySqlParameterList">Sql參數</param>
        /// <param name="strOrderBy">SQL排序式 , 當空值時，預設帶[ CreateDateTime Desc] (不用加「Order by 」關鑵字, 例 "uid desc,createDateTime asc ")</param>
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>       
        /// <returns></returns>
        public static object ReadList(int PageSize, int PageIndex, ref List<CPatComitEvent> Items, string strSqlWhere = "", System.Data.SqlClient.SqlParameter[] MySqlParameterList = null, string strOrderBy = "", string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();

            object retObj = orm.ReadListToObjs<CPatComitEvent>(PageSize, PageIndex, strSqlWhere, ref Items, sqlParameterList: MySqlParameterList, OrderBy: strOrderBy, CusTableName: strCusTableName);

            return retObj;
        }
        #endregion

        #region Create
        /// <summary>
        /// 新增PatComitEventT 項目
        /// </summary> 
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>      
        /// <returns>0:成功 ; string:失敗</returns>
        public object Create(string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.InsertByObj<CPatComitEvent>(this, strCusTableName);
            return retObj;
        }
        #endregion

        #region Update
        /// <summary>
        /// 更新 PatComitEventT 項目
        /// </summary>       
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param> 
        /// <returns>0:成功 ; string:失敗</returns>
        public object Update(string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.UpdateObj<CPatComitEvent>(this, strCusTableName);
            return retObj;
        }
        #endregion

        #region Delete

        #region 刪除項目PatComitEventT Delete()
        /// <summary>
        /// 刪除項目PatComitEventT
        /// </summary>  
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>
        /// <returns></returns>   
        public object Delete(string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.DeleteObj<CPatComitEvent>(this, strCusTableName);
            return retObj;
        }
        #endregion

        #region 刪除項目PatComitEventT Delete(int iPKey)
        /// <summary>
        /// 刪除項目PatComitEventT , 指定某一筆主鍵刪除(單筆)
        /// </summary>
        /// <param name="iPKey">指定刪除某筆資料的Key值</param> 
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>      
        /// <returns></returns>
        public object Delete(int iPKey, string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.DeleteObj<CPatComitEvent>(iPKey, strCusTableName);
            return retObj;
        }
        #endregion

        #region 刪除項目PatComitEventT Delete(string strSqlWhere)
        /// <summary>
        /// 刪除項目PatComitEventT ,符合條件刪除(多筆)
        /// </summary>
        /// <param name="strSqlWhere">查詢條件(不用加「where」關鍵字)</param>   
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>    
        /// <returns></returns>
        public object Delete(string strSqlWhere, string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.DeleteObj<CPatComitEvent>(strSqlWhere, strCusTableName);
            return retObj;
        }
        #endregion

        #endregion

        #endregion
    }
    #endregion =================
}
