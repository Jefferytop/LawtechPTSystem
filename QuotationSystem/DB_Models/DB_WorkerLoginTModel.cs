using H3Operator.DBHelper;
using H3Operator.DBModels;
using System;
using System.Collections.Generic;

namespace LawtechPTSystem.DB_Models
{
    #region DB_WorkerLoginTModel=================
    /// <summary>
    /// 
    /// </summary>
    [TableMapping("WorkerLoginT")]
    public class DB_WorkerLoginTModel : SysBaseModel
    {
        #region Public property

        private int m_WorkerLoginKey;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("WorkerLoginKey", DbType = SqlDataType.Int, IsPrimary = true, IsCumulative = true, IsCanNull = false, DataLength = 4)]
        public int WorkerLoginKey
        {
            get
            {
                return m_WorkerLoginKey;
            }
            set
            {
                m_WorkerLoginKey = value;
            }
        }

        private int m_WorkerKey;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("WorkerKey", DbType = SqlDataType.Int, IsCanNull = false, DataLength = 4)]
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

        private bool? m_Online;
        /// <summary>
        /// 是否在線
        /// </summary>
        [TableColumnSetting("Online", DbType = SqlDataType.Bit, DataLength = 1)]
        public bool? Online
        {
            get
            {
                return m_Online;
            }
            set
            {
                m_Online = value;
            }
        }

        private DateTime? m_OnlineTime;
        /// <summary>
        /// 上線時間
        /// </summary>
        [TableColumnSetting("OnlineTime", DbType = SqlDataType.DateTime, DataLength = 8)]
        public DateTime? OnlineTime
        {
            get
            {
                return m_OnlineTime;
            }
            set
            {
                m_OnlineTime = value;
            }
        }

        private DateTime? m_OutTime;
        /// <summary>
        /// 離線時間
        /// </summary>
        [TableColumnSetting("OutTime", DbType = SqlDataType.DateTime, DataLength = 8)]
        public DateTime? OutTime
        {
            get
            {
                return m_OutTime;
            }
            set
            {
                m_OutTime = value;
            }
        }

        private string m_LoginIP;
        /// <summary>
        /// 登入ip
        /// </summary>
        [TableColumnSetting("LoginIP", IsCanNull = false, DataLength = 200)]
        public string LoginIP
        {
            get
            {
                return m_LoginIP;
            }
            set
            {
                m_LoginIP = value;
            }
        }

        private string m_LoginRemark;
        /// <summary>
        /// 登入備註
        /// </summary>
        [TableColumnSetting("LoginRemark", IsCanNull = false, DataLength = 200)]
        public string LoginRemark
        {
            get
            {
                return m_LoginRemark;
            }
            set
            {
                m_LoginRemark = value;
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
            List<DB_WorkerLoginTModel> list = new List<DB_WorkerLoginTModel>();
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
                retObj = orm.ReadListToObjs<DB_WorkerLoginTModel>(ColumnName + "=@" + ColumnName, ref list, ParList);
            }
            else
            {
                retObj = orm.ReadListToObjs<DB_WorkerLoginTModel>(ColumnName + "=@" + ColumnName + " and WorkerLoginKey<>" + this.WorkerLoginKey.ToString(), ref list, ParList);
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

        #region 取得一筆資料  ReadOne(ref DB_WorkerLoginTModel Item, string strCusTableName = ")
        /// <summary>
        /// 取得一筆WorkerLoginT資料
        /// </summary>          
        /// <param name="item"></param>   
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>
        /// <returns>0:成功 ; string:失敗</returns>       
        public static object ReadOne(ref DB_WorkerLoginTModel Item, string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.ReadOneToObj(ref Item, CusTableName: strCusTableName);
            return retObj;
        }
        #endregion

        #region 取得一筆資料 ReadOne(int iPKey, ref DB_MenuRoleTModel item, string strCusTableName = "")
        /// <summary>
        /// 取得一筆WorkerLoginT資料
        /// </summary>
        /// <param name="iPKey">指定某筆資料的Key值(不適合複合key)</param>     
        /// <param name="item"></param>   
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>
        /// <returns>0:成功 ; string:失敗</returns>       
        public static object ReadOne(int iPKey, ref DB_WorkerLoginTModel item, string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.ReadOneToObj(iPKey, ref item, CusTableName: strCusTableName);
            return retObj;
        }
        #endregion

        #region 取得一筆WorkerLoginT資料 ReadOne(string strSqlWhere, System.Data.SqlClient.SqlParameter[] MySqlParameterList=null, string strCusTableName = "")
        /// <summary>
        /// 取得一筆WorkerLoginT資料;如果有多筆符合條件，則只回傳null
        /// </summary>
        /// <param name="strSqlWhere">查詢條件(不用加「where」關鍵字, 可加Sql參數,例如: account=@account)</param>
        /// <param name="MySqlParameterList">Sql參數</param>
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>
        /// <returns>0:成功 ; string:失敗</returns>
        public static object ReadOne(string strSqlWhere, ref DB_WorkerLoginTModel item, System.Data.SqlClient.SqlParameter[] MySqlParameterList = null, string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            List<DB_WorkerLoginTModel> itemlist = new List<DB_WorkerLoginTModel>();
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

        #region 取得多筆DB_WorkerLoginTModel資料 ReadList
        /// <summary>
        /// 取得多筆 WorkerLoginT資料 
        /// </summary>
        /// <param name="Items"></param>
        /// <param name="strSqlWhere">SQL條件式 (不用加「where」關鑵字,可加Sql參數,例如: account=@account)</param>
        /// <param name="MySqlParameterList">Sql參數</param>
        /// <param name="strOrderBy">SQL排序式 , 當空值時，預設帶[ CreateDateTime Desc] (不用加「Order by 」關鑵字, 例 "uid desc,createDateTime asc ")</param>
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>      
        /// <returns></returns>
        public static object ReadList(ref List<DB_WorkerLoginTModel> Items, string strSqlWhere = "", System.Data.SqlClient.SqlParameter[] MySqlParameterList = null, string strOrderBy = "", string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();

            object retObj = orm.ReadListToObjs<DB_WorkerLoginTModel>(strSqlWhere, ref Items, sqlParameterList: MySqlParameterList, OrderBy: strOrderBy, CusTableName: strCusTableName);

            return retObj;
        }

        #endregion

        #region 取得多筆 WorkerLoginT資料 , 指定頁數和頁碼 ReadList
        /// <summary>
        /// 取得多筆 WorkerLoginT資料 , 指定頁數和頁碼
        /// </summary>
        /// <param name="PageSize">一頁的筆數</param>
        /// <param name="PageIndex">第 n 頁</param>
        /// <param name="Items"></param>
        /// <param name="strSqlWhere">SQL條件式 (不用加「where」關鑵字,可加Sql參數,例如: account=@account)</param>
        /// <param name="MySqlParameterList">Sql參數</param>
        /// <param name="strOrderBy">SQL排序式 , 當空值時，預設帶[ CreateDateTime Desc] (不用加「Order by 」關鑵字, 例 "uid desc,createDateTime asc ")</param>
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>       
        /// <returns></returns>
        public static object ReadList(int PageSize, int PageIndex, ref List<DB_WorkerLoginTModel> Items, string strSqlWhere = "", System.Data.SqlClient.SqlParameter[] MySqlParameterList = null, string strOrderBy = "", string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();

            object retObj = orm.ReadListToObjs<DB_WorkerLoginTModel>(PageSize, PageIndex, strSqlWhere, ref Items, sqlParameterList: MySqlParameterList, OrderBy: strOrderBy, CusTableName: strCusTableName);

            return retObj;
        }
        #endregion

        #region Create
        /// <summary>
        /// 新增WorkerLoginT 項目
        /// </summary> 
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>      
        /// <returns>0:成功 ; string:失敗</returns>
        public object Create(string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.InsertByObj<DB_WorkerLoginTModel>(this, strCusTableName);
            return retObj;
        }
        #endregion

        #region Update
        /// <summary>
        /// 更新 WorkerLoginT 項目
        /// </summary>       
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param> 
        /// <returns>0:成功 ; string:失敗</returns>
        public object Update(string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.UpdateObj<DB_WorkerLoginTModel>(this, strCusTableName);
            return retObj;
        }
        #endregion

        #region Delete

        #region 刪除項目WorkerLoginT Delete()
        /// <summary>
        /// 刪除項目WorkerLoginT
        /// </summary>  
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>
        /// <returns></returns>   
        public object Delete(string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.DeleteObj<DB_WorkerLoginTModel>(this, strCusTableName);
            return retObj;
        }
        #endregion

        #region 刪除項目WorkerLoginT Delete(int iPKey)
        /// <summary>
        /// 刪除項目WorkerLoginT , 指定某一筆主鍵刪除(單筆)
        /// </summary>
        /// <param name="iPKey">指定刪除某筆資料的Key值</param> 
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>      
        /// <returns></returns>
        public object Delete(int iPKey, string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.DeleteObj<DB_WorkerLoginTModel>(iPKey, strCusTableName);
            return retObj;
        }
        #endregion

        #region 刪除項目WorkerLoginT Delete(string strSqlWhere)
        /// <summary>
        /// 刪除項目WorkerLoginT ,符合條件刪除(多筆)
        /// </summary>
        /// <param name="strSqlWhere">查詢條件(不用加「where」關鍵字)</param>   
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>    
        /// <returns></returns>
        public object Delete(string strSqlWhere, string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.DeleteObj<DB_WorkerLoginTModel>(strSqlWhere, strCusTableName);
            return retObj;
        }
        #endregion

        #endregion

        #endregion
    }
    #endregion =================
}
