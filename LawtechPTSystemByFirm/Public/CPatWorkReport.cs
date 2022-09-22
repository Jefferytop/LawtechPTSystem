using H3Operator.DBHelper;
using H3Operator.DBModels;
using System;
using System.Collections.Generic;

namespace LawtechPTSystemByFirm.Public
{
    #region CPatWorkReport=================
    /// <summary>
    /// 
    /// </summary>
    [TableMapping("PatWorkReportT")]
    public class CPatWorkReport : SysBaseModel
    {
        #region Public property

        private int m_WorkReportID;
        /// <summary>
        /// 專利事件工作報告表 PK
        /// </summary>
        [TableColumnSetting("WorkReportID", DbType = SqlDataType.Int, IsPrimary = true, IsCumulative = true, IsCanNull = false, DataLength = 4)]
        public int WorkReportID
        {
            get
            {
                return m_WorkReportID;
            }
            set
            {
                m_WorkReportID = value;
            }
        }

        private int? m_EventType;
        /// <summary>
        /// 專利事件類型  1.事件記錄
        /// </summary>
        [TableColumnSetting("EventType", DbType = SqlDataType.Int, DataLength = 4)]
        public int? EventType
        {
            get
            {
                return m_EventType;
            }
            set
            {
                m_EventType = value;
            }
        }

        private int? m_EventID;
        /// <summary>
        /// 事件(1.事件記錄)的 ID
        /// </summary>
        [TableColumnSetting("EventID", DbType = SqlDataType.Int, DataLength = 4)]
        public int? EventID
        {
            get
            {
                return m_EventID;
            }
            set
            {
                m_EventID = value;
            }
        }

        private int? m_Worker;
        /// <summary>
        /// 承辦人
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

        private string m_WorkContent;
        /// <summary>
        /// 事件工作內容
        /// </summary>
        [TableColumnSetting("WorkContent", DataLength = 3000)]
        public string WorkContent
        {
            get
            {
                return m_WorkContent;
            }
            set
            {
                m_WorkContent = value;
            }
        }

        private DateTime? m_WorkDate;
        /// <summary>
        /// 事件發生時間
        /// </summary>
        [TableColumnSetting("WorkDate", DbType = SqlDataType.DateTime, DataLength = 8)]
        public DateTime? WorkDate
        {
            get
            {
                return m_WorkDate;
            }
            set
            {
                m_WorkDate = value;
            }
        }

        private DateTime? m_StartTime;
        /// <summary>
        /// 開工時間
        /// </summary>
        [TableColumnSetting("StartTime", DbType = SqlDataType.DateTime, DataLength = 8)]
        public DateTime? StartTime
        {
            get
            {
                return m_StartTime;
            }
            set
            {
                m_StartTime = value;
            }
        }

        private DateTime? m_EndTime;
        /// <summary>
        /// 結束時間
        /// </summary>
        [TableColumnSetting("EndTime", DbType = SqlDataType.DateTime, DataLength = 8)]
        public DateTime? EndTime
        {
            get
            {
                return m_EndTime;
            }
            set
            {
                m_EndTime = value;
            }
        }

        private string m_AllTime;
        /// <summary>
        /// 花費的時間
        /// </summary>
        [TableColumnSetting("AllTime", DataLength = 100)]
        public string AllTime
        {
            get
            {
                return m_AllTime;
            }
            set
            {
                m_AllTime = value;
            }
        }

        private int? m_Progress;
        /// <summary>
        /// 觸發事件ID(ProcessStepET PK)
        /// </summary>
        [TableColumnSetting("Progress", DbType = SqlDataType.Int, DataLength = 4)]
        public int? Progress
        {
            get
            {
                return m_Progress;
            }
            set
            {
                m_Progress = value;
            }
        }

        private bool? m_IsStart;
        /// <summary>
        /// 是否開始
        /// </summary>
        [TableColumnSetting("IsStart", DbType = SqlDataType.Bit, DataLength = 1)]
        public bool? IsStart
        {
            get
            {
                return m_IsStart;
            }
            set
            {
                m_IsStart = value;
            }
        }

        private int? m_iTime;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("iTime", DbType = SqlDataType.Int, DataLength = 4)]
        public int? iTime
        {
            get
            {
                return m_iTime;
            }
            set
            {
                m_iTime = value;
            }
        }

        private int? m_OstatusSN;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("OstatusSN", DbType = SqlDataType.Int, DataLength = 4)]
        public int? OstatusSN
        {
            get
            {
                return m_OstatusSN;
            }
            set
            {
                m_OstatusSN = value;
            }
        }

        private DateTime? m_EstimateDateTime;
        /// <summary>
        /// 預計完成時間
        /// </summary>
        [TableColumnSetting("EstimateDateTime", DbType = SqlDataType.DateTime, DataLength = 8)]
        public DateTime? EstimateDateTime
        {
            get
            {
                return m_EstimateDateTime;
            }
            set
            {
                m_EstimateDateTime = value;
            }
        }

        private string m_Memo;
        /// <summary>
        /// 備註
        /// </summary>
        [TableColumnSetting("Memo", DataLength = 4000)]
        public string Memo
        {
            get
            {
                return m_Memo;
            }
            set
            {
                m_Memo = value;
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
            List<CPatWorkReport> list = new List<CPatWorkReport>();
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
                retObj = orm.ReadListToObjs<CPatWorkReport>(ColumnName + "=@" + ColumnName, ref list, ParList);
            }
            else
            {
                retObj = orm.ReadListToObjs<CPatWorkReport>(ColumnName + "=@" + ColumnName + " and WorkReportID<>" + this.WorkReportID.ToString(), ref list, ParList);
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

        #region 取得一筆資料  ReadOne(ref CPatWorkReport Item, string strCusTableName = ")
        /// <summary>
        /// 取得一筆PatWorkReportT資料
        /// </summary>          
        /// <param name="item"></param>   
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>
        /// <returns>0:成功 ; string:失敗</returns>       
        public static object ReadOne(ref CPatWorkReport Item, string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.ReadOneToObj(ref Item, CusTableName: strCusTableName);
            return retObj;
        }
        #endregion

        #region 取得一筆資料 ReadOne(int iPKey, ref DB_MenuRoleTModel item, string strCusTableName = "")
        /// <summary>
        /// 取得一筆PatWorkReportT資料
        /// </summary>
        /// <param name="iPKey">指定某筆資料的Key值(不適合複合key)</param>     
        /// <param name="item"></param>   
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>
        /// <returns>0:成功 ; string:失敗</returns>       
        public static object ReadOne(int iPKey, ref CPatWorkReport item, string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.ReadOneToObj(iPKey, ref item, CusTableName: strCusTableName);
            return retObj;
        }
        #endregion

        #region 取得一筆PatWorkReportT資料 ReadOne(string strSqlWhere, System.Data.SqlClient.SqlParameter[] MySqlParameterList=null, string strCusTableName = "")
        /// <summary>
        /// 取得一筆PatWorkReportT資料;如果有多筆符合條件，則只回傳null
        /// </summary>
        /// <param name="strSqlWhere">查詢條件(不用加「where」關鍵字, 可加Sql參數,例如: account=@account)</param>
        /// <param name="MySqlParameterList">Sql參數</param>
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>
        /// <returns>0:成功 ; string:失敗</returns>
        public static object ReadOne(string strSqlWhere, ref CPatWorkReport item, System.Data.SqlClient.SqlParameter[] MySqlParameterList = null, string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            List<CPatWorkReport> itemlist = new List<CPatWorkReport>();
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

        #region 取得多筆CPatWorkReport資料 ReadList
        /// <summary>
        /// 取得多筆 PatWorkReportT資料 
        /// </summary>
        /// <param name="Items"></param>
        /// <param name="strSqlWhere">SQL條件式 (不用加「where」關鑵字,可加Sql參數,例如: account=@account)</param>
        /// <param name="MySqlParameterList">Sql參數</param>
        /// <param name="strOrderBy">SQL排序式 , 當空值時，預設帶[ CreateDateTime Desc] (不用加「Order by 」關鑵字, 例 "uid desc,createDateTime asc ")</param>
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>      
        /// <returns></returns>
        public static object ReadList(ref List<CPatWorkReport> Items, string strSqlWhere = "", System.Data.SqlClient.SqlParameter[] MySqlParameterList = null, string strOrderBy = "", string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();

            object retObj = orm.ReadListToObjs<CPatWorkReport>(strSqlWhere, ref Items, sqlParameterList: MySqlParameterList, OrderBy: strOrderBy, CusTableName: strCusTableName);

            return retObj;
        }

        #endregion

        #region 取得多筆 PatWorkReportT資料 , 指定頁數和頁碼 ReadList
        /// <summary>
        /// 取得多筆 PatWorkReportT資料 , 指定頁數和頁碼
        /// </summary>
        /// <param name="PageSize">一頁的筆數</param>
        /// <param name="PageIndex">第 n 頁</param>
        /// <param name="Items"></param>
        /// <param name="strSqlWhere">SQL條件式 (不用加「where」關鑵字,可加Sql參數,例如: account=@account)</param>
        /// <param name="MySqlParameterList">Sql參數</param>
        /// <param name="strOrderBy">SQL排序式 , 當空值時，預設帶[ CreateDateTime Desc] (不用加「Order by 」關鑵字, 例 "uid desc,createDateTime asc ")</param>
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>       
        /// <returns></returns>
        public static object ReadList(int PageSize, int PageIndex, ref List<CPatWorkReport> Items, string strSqlWhere = "", System.Data.SqlClient.SqlParameter[] MySqlParameterList = null, string strOrderBy = "", string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();

            object retObj = orm.ReadListToObjs<CPatWorkReport>(PageSize, PageIndex, strSqlWhere, ref Items, sqlParameterList: MySqlParameterList, OrderBy: strOrderBy, CusTableName: strCusTableName);

            return retObj;
        }
        #endregion

        #region Create
        /// <summary>
        /// 新增PatWorkReportT 項目
        /// </summary> 
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>      
        /// <returns>0:成功 ; string:失敗</returns>
        public object Create(string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.InsertByObj<CPatWorkReport>(this, strCusTableName);
            return retObj;
        }
        #endregion

        #region Update
        /// <summary>
        /// 更新 PatWorkReportT 項目
        /// </summary>       
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param> 
        /// <returns>0:成功 ; string:失敗</returns>
        public object Update(string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.UpdateObj<CPatWorkReport>(this, strCusTableName);
            return retObj;
        }
        #endregion

        #region Delete

        #region 刪除項目PatWorkReportT Delete()
        /// <summary>
        /// 刪除項目PatWorkReportT
        /// </summary>  
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>
        /// <returns></returns>   
        public object Delete(string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.DeleteObj<CPatWorkReport>(this, strCusTableName);
            return retObj;
        }
        #endregion

        #region 刪除項目PatWorkReportT Delete(int iPKey)
        /// <summary>
        /// 刪除項目PatWorkReportT , 指定某一筆主鍵刪除(單筆)
        /// </summary>
        /// <param name="iPKey">指定刪除某筆資料的Key值</param> 
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>      
        /// <returns></returns>
        public object Delete(int iPKey, string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.DeleteObj<CPatWorkReport>(iPKey, strCusTableName);
            return retObj;
        }
        #endregion

        #region 刪除項目PatWorkReportT Delete(string strSqlWhere)
        /// <summary>
        /// 刪除項目PatWorkReportT ,符合條件刪除(多筆)
        /// </summary>
        /// <param name="strSqlWhere">查詢條件(不用加「where」關鍵字)</param>   
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>    
        /// <returns></returns>
        public object Delete(string strSqlWhere, string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.DeleteObj<CPatWorkReport>(strSqlWhere, strCusTableName);
            return retObj;
        }
        #endregion

        #endregion

        #endregion
    }
    #endregion =================
}
