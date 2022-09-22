using H3Operator.DBHelper;
using H3Operator.DBModels;
using System.Collections.Generic;

namespace LawtechPTSystem.Public
{
    #region CTrademarkProcessStepE=================
    /// <summary>
    /// 
    /// </summary>
    [TableMapping("TrademarkProcessStepET")]
    public class CTrademarkProcessStepE : SysBaseModel
    {
        #region Public property

        private int m_ProcessHandleKEY;
        /// <summary>
        /// 專利程序清單表 PK
        /// </summary>
        [TableColumnSetting("ProcessHandleKEY", DbType = SqlDataType.Int, IsPrimary = true, IsCumulative = true, IsCanNull = false, DataLength = 4)]
        public int ProcessHandleKEY
        {
            get
            {
                return m_ProcessHandleKEY;
            }
            set
            {
                m_ProcessHandleKEY = value;
            }
        }

        private int? m_sort;
        /// <summary>
        /// 排序
        /// </summary>
        [TableColumnSetting("sort", DbType = SqlDataType.Int, DataLength = 4)]
        public int? sort
        {
            get
            {
                return m_sort;
            }
            set
            {
                m_sort = value;
            }
        }

        private string m_Handle;
        /// <summary>
        /// 處理階段
        /// </summary>
        [TableColumnSetting("Handle", DataLength = 2000)]
        public string Handle
        {
            get
            {
                return m_Handle;
            }
            set
            {
                m_Handle = value;
            }
        }

        private int? m_Status;
        /// <summary>
        /// 對應的專利狀態
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

        private int? m_DefualtWorker;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("DefualtWorker", DbType = SqlDataType.Int, DataLength = 4)]
        public int? DefualtWorker
        {
            get
            {
                return m_DefualtWorker;
            }
            set
            {
                m_DefualtWorker = value;
            }
        }

        private int? m_Days;
        /// <summary>
        /// 預計的工作天數
        /// </summary>
        [TableColumnSetting("Days", DbType = SqlDataType.Int, DataLength = 4)]
        public int? Days
        {
            get
            {
                return m_Days;
            }
            set
            {
                m_Days = value;
            }
        }

        private int? m_Hours;
        /// <summary>
        /// 預計的工作時數
        /// </summary>
        [TableColumnSetting("Hours", DbType = SqlDataType.Int, DataLength = 4)]
        public int? Hours
        {
            get
            {
                return m_Hours;
            }
            set
            {
                m_Hours = value;
            }
        }

        private int? m_Minutes;
        /// <summary>
        /// 預計的工作時間--分鐘
        /// </summary>
        [TableColumnSetting("Minutes", DbType = SqlDataType.Int, DataLength = 4)]
        public int? Minutes
        {
            get
            {
                return m_Minutes;
            }
            set
            {
                m_Minutes = value;
            }
        }

        private bool? m_IsUsing;
        /// <summary>
        /// 1.使用  0.不使用
        /// </summary>
        [TableColumnSetting("IsUsing", DbType = SqlDataType.Bit, DataLength = 1)]
        public bool? IsUsing
        {
            get
            {
                return m_IsUsing;
            }
            set
            {
                m_IsUsing = value;
            }
        }

        private int? m_ProcessKEY;
        /// <summary>
        /// ProcessKindT PK
        /// </summary>
        [TableColumnSetting("ProcessKEY", DbType = SqlDataType.Int, DataLength = 4)]
        public int? ProcessKEY
        {
            get
            {
                return m_ProcessKEY;
            }
            set
            {
                m_ProcessKEY = value;
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
            List<CTrademarkProcessStepE> list = new List<CTrademarkProcessStepE>();
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
                retObj = orm.ReadListToObjs<CTrademarkProcessStepE>(ColumnName + "=@" + ColumnName, ref list, ParList);
            }
            else
            {
                retObj = orm.ReadListToObjs<CTrademarkProcessStepE>(ColumnName + "=@" + ColumnName + " and ProcessHandleKEY<>" + this.ProcessHandleKEY.ToString(), ref list, ParList);
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

        #region 取得一筆資料  ReadOne(ref CTrademarkProcessStepE Item, string strCusTableName = ")
        /// <summary>
        /// 取得一筆TrademarkProcessStepET資料
        /// </summary>          
        /// <param name="item"></param>   
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>
        /// <returns>0:成功 ; string:失敗</returns>       
        public static object ReadOne(ref CTrademarkProcessStepE Item, string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.ReadOneToObj(ref Item, CusTableName: strCusTableName);
            return retObj;
        }
        #endregion

        #region 取得一筆資料 ReadOne(int iPKey, ref DB_MenuRoleTModel item, string strCusTableName = "")
        /// <summary>
        /// 取得一筆TrademarkProcessStepET資料
        /// </summary>
        /// <param name="iPKey">指定某筆資料的Key值(不適合複合key)</param>     
        /// <param name="item"></param>   
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>
        /// <returns>0:成功 ; string:失敗</returns>       
        public static object ReadOne(int iPKey, ref CTrademarkProcessStepE item, string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.ReadOneToObj(iPKey, ref item, CusTableName: strCusTableName);
            return retObj;
        }
        #endregion

        #region 取得一筆TrademarkProcessStepET資料 ReadOne(string strSqlWhere, System.Data.SqlClient.SqlParameter[] MySqlParameterList=null, string strCusTableName = "")
        /// <summary>
        /// 取得一筆TrademarkProcessStepET資料;如果有多筆符合條件，則只回傳null
        /// </summary>
        /// <param name="strSqlWhere">查詢條件(不用加「where」關鍵字, 可加Sql參數,例如: account=@account)</param>
        /// <param name="MySqlParameterList">Sql參數</param>
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>
        /// <returns>0:成功 ; string:失敗</returns>
        public static object ReadOne(string strSqlWhere, ref CTrademarkProcessStepE item, System.Data.SqlClient.SqlParameter[] MySqlParameterList = null, string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            List<CTrademarkProcessStepE> itemlist = new List<CTrademarkProcessStepE>();
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

        #region 取得多筆CTrademarkProcessStepE資料 ReadList
        /// <summary>
        /// 取得多筆 TrademarkProcessStepET資料 
        /// </summary>
        /// <param name="Items"></param>
        /// <param name="strSqlWhere">SQL條件式 (不用加「where」關鑵字,可加Sql參數,例如: account=@account)</param>
        /// <param name="MySqlParameterList">Sql參數</param>
        /// <param name="strOrderBy">SQL排序式 , 當空值時，預設帶[ CreateDateTime Desc] (不用加「Order by 」關鑵字, 例 "uid desc,createDateTime asc ")</param>
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>      
        /// <returns></returns>
        public static object ReadList(ref List<CTrademarkProcessStepE> Items, string strSqlWhere = "", System.Data.SqlClient.SqlParameter[] MySqlParameterList = null, string strOrderBy = "", string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();

            object retObj = orm.ReadListToObjs<CTrademarkProcessStepE>(strSqlWhere, ref Items, sqlParameterList: MySqlParameterList, OrderBy: strOrderBy, CusTableName: strCusTableName);

            return retObj;
        }

        #endregion

        #region 取得多筆 TrademarkProcessStepET資料 , 指定頁數和頁碼 ReadList
        /// <summary>
        /// 取得多筆 TrademarkProcessStepET資料 , 指定頁數和頁碼
        /// </summary>
        /// <param name="PageSize">一頁的筆數</param>
        /// <param name="PageIndex">第 n 頁</param>
        /// <param name="Items"></param>
        /// <param name="strSqlWhere">SQL條件式 (不用加「where」關鑵字,可加Sql參數,例如: account=@account)</param>
        /// <param name="MySqlParameterList">Sql參數</param>
        /// <param name="strOrderBy">SQL排序式 , 當空值時，預設帶[ CreateDateTime Desc] (不用加「Order by 」關鑵字, 例 "uid desc,createDateTime asc ")</param>
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>       
        /// <returns></returns>
        public static object ReadList(int PageSize, int PageIndex, ref List<CTrademarkProcessStepE> Items, string strSqlWhere = "", System.Data.SqlClient.SqlParameter[] MySqlParameterList = null, string strOrderBy = "", string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();

            object retObj = orm.ReadListToObjs<CTrademarkProcessStepE>(PageSize, PageIndex, strSqlWhere, ref Items, sqlParameterList: MySqlParameterList, OrderBy: strOrderBy, CusTableName: strCusTableName);

            return retObj;
        }
        #endregion

        #region Create
        /// <summary>
        /// 新增TrademarkProcessStepET 項目
        /// </summary> 
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>      
        /// <returns>0:成功 ; string:失敗</returns>
        public object Create(string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.InsertByObj<CTrademarkProcessStepE>(this, strCusTableName);
            return retObj;
        }
        #endregion

        #region Update
        /// <summary>
        /// 更新 TrademarkProcessStepET 項目
        /// </summary>       
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param> 
        /// <returns>0:成功 ; string:失敗</returns>
        public object Update(string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.UpdateObj<CTrademarkProcessStepE>(this, strCusTableName);
            return retObj;
        }
        #endregion

        #region Delete

        #region 刪除項目TrademarkProcessStepET Delete()
        /// <summary>
        /// 刪除項目TrademarkProcessStepET
        /// </summary>  
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>
        /// <returns></returns>   
        public object Delete(string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.DeleteObj<CTrademarkProcessStepE>(this, strCusTableName);
            return retObj;
        }
        #endregion

        #region 刪除項目TrademarkProcessStepET Delete(int iPKey)
        /// <summary>
        /// 刪除項目TrademarkProcessStepET , 指定某一筆主鍵刪除(單筆)
        /// </summary>
        /// <param name="iPKey">指定刪除某筆資料的Key值</param> 
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>      
        /// <returns></returns>
        public object Delete(int iPKey, string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.DeleteObj<CTrademarkProcessStepE>(iPKey, strCusTableName);
            return retObj;
        }
        #endregion

        #region 刪除項目TrademarkProcessStepET Delete(string strSqlWhere)
        /// <summary>
        /// 刪除項目TrademarkProcessStepET ,符合條件刪除(多筆)
        /// </summary>
        /// <param name="strSqlWhere">查詢條件(不用加「where」關鍵字)</param>   
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>    
        /// <returns></returns>
        public object Delete(string strSqlWhere, string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.DeleteObj<CTrademarkProcessStepE>(strSqlWhere, strCusTableName);
            return retObj;
        }
        #endregion

        #endregion

        #endregion
    }
    #endregion =================
}
