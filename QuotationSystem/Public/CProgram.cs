using H3Operator.DBHelper;
using H3Operator.DBModels;
using System;
using System.Collections.Generic;
using System.Data;

namespace LawtechPTSystem.Public
{
    #region CProgram=================
    /// <summary>
    /// 
    /// </summary>
    [TableMapping("ProgramT")]
    public class CProgram : SysBaseModel
    {
        #region Public property

        private int m_ProgramKEY;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("ProgramKEY", DbType = SqlDataType.Int, IsPrimary = true, IsCumulative = true, IsCanNull = false, DataLength = 4)]
        public int ProgramKEY
        {
            get
            {
                return m_ProgramKEY;
            }
            set
            {
                m_ProgramKEY = value;
            }
        }

        private string m_ProgramName;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("ProgramName", DataLength = 100)]
        public string ProgramName
        {
            get
            {
                return m_ProgramName;
            }
            set
            {
                m_ProgramName = value;
            }
        }

        private int? m_ProgramKind;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("ProgramKind", DbType = SqlDataType.Int, DataLength = 4)]
        public int? ProgramKind
        {
            get
            {
                return m_ProgramKind;
            }
            set
            {
                m_ProgramKind = value;
            }
        }

        private int? m_Sort;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("Sort", DbType = SqlDataType.Int, DataLength = 4)]
        public int? Sort
        {
            get
            {
                return m_Sort;
            }
            set
            {
                m_Sort = value;
            }
        }

        private string m_ProgramSymbol;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("ProgramSymbol", DataLength = 100)]
        public string ProgramSymbol
        {
            get
            {
                return m_ProgramSymbol;
            }
            set
            {
                m_ProgramSymbol = value;
            }
        }

        private string m_Description;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("Description", DataLength = 4000)]
        public string Description
        {
            get
            {
                return m_Description;
            }
            set
            {
                m_Description = value;
            }
        }

        private bool? m_IsOpen;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("IsOpen", DbType = SqlDataType.Bit, DataLength = 1)]
        public bool? IsOpen
        {
            get
            {
                return m_IsOpen;
            }
            set
            {
                m_IsOpen = value;
            }
        }

        private int? m_LastModifyWorker;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("LastModifyWorker", DbType = SqlDataType.Int, DataLength = 4)]
        public int? LastModifyWorker
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

        private DateTime? m_LogicDeleteDateTime;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("LogicDeleteDateTime", DbType = SqlDataType.DateTime, DataLength = 8)]
        public DateTime? LogicDeleteDateTime
        {
            get
            {
                return m_LogicDeleteDateTime;
            }
            set
            {
                m_LogicDeleteDateTime = value;
            }
        }

        private DateTime? m_IsLogicDelete;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("IsLogicDelete", DbType = SqlDataType.DateTime, DataLength = 8)]
        public DateTime? IsLogicDelete
        {
            get
            {
                return m_IsLogicDelete;
            }
            set
            {
                m_IsLogicDelete = value;
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
            List<CProgram> list = new List<CProgram>();
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
                retObj = orm.ReadListToObjs<CProgram>(ColumnName + "=@" + ColumnName, ref list, ParList);
            }
            else
            {
                retObj = orm.ReadListToObjs<CProgram>(ColumnName + "=@" + ColumnName + " and ProgramKEY<>" + this.ProgramKEY.ToString(), ref list, ParList);
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
            object retObj = orm.ReadCountRows<CProgram>(ref iCountRows, strSqlWhere, sqlParameterList: sqlParameterList, CusTableName: strCusTableName);
            return retObj;
        }
        #endregion

        #region 取得一筆資料  ReadOne(ref CProgram Item, string strCusTableName = ")
        /// <summary>
        /// 取得一筆ProgramT資料
        /// </summary>          
        /// <param name="item"></param>   
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>
        /// <returns>0:成功 ; string:失敗</returns>       
        public static object ReadOne(ref CProgram Item, string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.ReadOneToObj(ref Item, CusTableName: strCusTableName);
            return retObj;
        }
        #endregion

        #region 取得一筆資料 ReadOne(int iPKey, ref CProgram item, string strCusTableName = "")
        /// <summary>
        /// 取得一筆ProgramT資料
        /// </summary>
        /// <param name="iPKey">指定某筆資料的Key值(不適合複合key)</param>     
        /// <param name="item"></param>   
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>
        /// <returns>0:成功 ; string:失敗</returns>       
        public static object ReadOne(int iPKey, ref CProgram item, string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.ReadOneToObj(iPKey, ref item, CusTableName: strCusTableName);
            return retObj;
        }
        #endregion

        #region 取得一筆ProgramT資料 ReadOne(string strSqlWhere, System.Data.SqlClient.SqlParameter[] MySqlParameterList=null, string strCusTableName = "")
        /// <summary>
        /// 取得一筆ProgramT資料;如果有多筆符合條件，則只回傳null
        /// </summary>
        /// <param name="strSqlWhere">查詢條件(不用加「where」關鍵字, 可加Sql參數,例如: account=@account)</param>
        /// <param name="MySqlParameterList">Sql參數</param>
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>
        /// <returns>0:成功 ; string:失敗</returns>
        public static object ReadOne(string strSqlWhere, ref CProgram item, System.Data.SqlClient.SqlParameter[] MySqlParameterList = null, string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            List<CProgram> itemlist = new List<CProgram>();
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

        #region 取得多筆CProgram資料 ReadList 
        /// <summary>
        /// 取得多筆 ProgramT資料，符合的全部撈出並轉成物件
        /// </summary>
        /// <param name="Items"></param>
        /// <param name="strSqlWhere">SQL條件式 (不用加「where」關鑵字,可加Sql參數,例如: account=@account)</param>
        /// <param name="MySqlParameterList">Sql參數</param>
        /// <param name="strOrderBy">SQL排序式 , 當空值時，預設帶[ CreateDateTime Desc] (不用加「Order by 」關鑵字, 例 "uid desc,createDateTime asc ")</param>
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>      
        /// <returns></returns>
        public static object ReadList(ref List<CProgram> Items, string strSqlWhere = "", System.Data.SqlClient.SqlParameter[] MySqlParameterList = null, string strOrderBy = "", string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();

            object retObj = orm.ReadListToObjs<CProgram>(strSqlWhere, ref Items, sqlParameterList: MySqlParameterList, OrderBy: strOrderBy, CusTableName: strCusTableName);

            return retObj;
        }

        #endregion

        #region 取得多筆CProgram資料 ReadList DataTable
        /// <summary>
        /// 取得多筆 ProgramT DataTable資料
        /// </summary>
        /// <param name="Items"></param>
        /// <param name="strSqlWhere">SQL條件式 (不用加「where」關鑵字,可加Sql參數,例如: account=@account)</param>
        /// <param name="MySqlParameterList">Sql參數</param>
        /// <param name="strOrderBy">SQL排序式 , 當空值時，預設帶[ CreateDateTime Desc] (不用加「Order by 」關鑵字, 例 "uid desc,createDateTime asc ")</param>
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>      
        /// <returns></returns>
        public static object ReadList(ref DataTable Items, string strSqlWhere = "", System.Data.SqlClient.SqlParameter[] MySqlParameterList = null, string strOrderBy = "", string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();

            object retObj = orm.ReadListToObjs<CProgram>(strSqlWhere, ref Items, sqlParameterList: MySqlParameterList, OrderBy: strOrderBy, CusTableName: strCusTableName);

            return retObj;
        }

        #endregion

        #region 取得多筆 ProgramT資料 , 指定頁數和頁碼 ReadList
        /// <summary>
        /// 取得多筆 ProgramT資料 , 指定頁數和頁碼
        /// </summary>
        /// <param name="PageSize">一頁的筆數</param>
        /// <param name="PageIndex">第 n 頁;從 0 起算，當值小於0時，預設帶0 (0即表示第一頁)</param>
        /// <param name="Items"></param>
        /// <param name="strSqlWhere">SQL條件式 (不用加「where」關鑵字,可加Sql參數,例如: account=@account)</param>
        /// <param name="MySqlParameterList">Sql參數</param>
        /// <param name="strOrderBy">SQL排序式 , 當空值時，預設帶[ CreateDateTime Desc] (不用加「Order by 」關鑵字, 例 "uid desc,createDateTime asc ")</param>
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>       
        /// <returns></returns>
        public static object ReadList(int PageSize, int PageIndex, ref List<CProgram> Items, string strSqlWhere = "", System.Data.SqlClient.SqlParameter[] MySqlParameterList = null, string strOrderBy = "", string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            int iTotalCountRows = 0;
            object retObj = orm.ReadListToObjsByFetch<CProgram>(PageSize, PageIndex, strSqlWhere, ref Items, ref iTotalCountRows, sqlParameterList: MySqlParameterList, OrderBy: strOrderBy, CusTableName: strCusTableName);

            return retObj;
        }
        #endregion

        #region 取得多筆 ProgramT資料 , 指定頁數和頁碼 ReadList,回傳查詢的總筆數
        /// <summary>
        /// 取得多筆 ProgramT資料 , 指定頁數和頁碼,回傳查詢的總筆數
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
        public static object ReadList(int PageSize, int PageIndex, ref List<CProgram> Items, ref int iTotalRowCount, string strSqlWhere = "", System.Data.SqlClient.SqlParameter[] MySqlParameterList = null, string strOrderBy = "", string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();

            object retObj = orm.ReadListToObjsByFetch<CProgram>(PageSize, PageIndex, strSqlWhere, ref Items, ref iTotalRowCount, sqlParameterList: MySqlParameterList, OrderBy: strOrderBy, CusTableName: strCusTableName);

            return retObj;
        }
        #endregion

        #region 取得多筆 ProgramT DataTable資料 , 指定頁數和頁碼 ReadList,回傳查詢的總筆數
        /// <summary>
        /// 取得多筆 ProgramT DataTable 資料 , 指定頁數和頁碼,回傳查詢的總筆數
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
        public static object ReadList(int PageSize, int PageIndex, ref DataTable Items, ref int iTotalRowCount, string strSqlWhere = "", System.Data.SqlClient.SqlParameter[] MySqlParameterList = null, string strOrderBy = "", string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();

            object retObj = orm.ReadListToObjsByFetch<CProgram>(PageSize, PageIndex, strSqlWhere, ref Items, ref iTotalRowCount, sqlParameterList: MySqlParameterList, OrderBy: strOrderBy, CusTableName: strCusTableName);

            return retObj;
        }
        #endregion

        #region Create
        /// <summary>
        /// 新增ProgramT 項目
        /// </summary> 
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>      
        /// <returns>0:成功 ; string:失敗</returns>
        public object Create(string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.InsertByObj<CProgram>(this, strCusTableName);
            return retObj;
        }
        #endregion

        #region Update
        /// <summary>
        /// 更新 ProgramT 項目
        /// </summary>       
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param> 
        /// <returns>0:成功 ; string:失敗</returns>
        public object Update(string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.UpdateObj<CProgram>(this, strCusTableName);
            return retObj;
        }
        #endregion

        #region Delete

        #region 刪除項目ProgramT Delete()
        /// <summary>
        /// 刪除項目ProgramT
        /// </summary>  
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>
        /// <returns></returns>   
        public object Delete(string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.DeleteObj<CProgram>(this, strCusTableName);
            return retObj;
        }
        #endregion

        #region 刪除項目ProgramT Delete(int iPKey)
        /// <summary>
        /// 刪除項目ProgramT , 指定某一筆主鍵刪除(單筆)
        /// </summary>
        /// <param name="iPKey">指定刪除某筆資料的Key值</param> 
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>      
        /// <returns></returns>
        public object Delete(int iPKey, string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.DeleteObj<CProgram>(iPKey, strCusTableName);
            return retObj;
        }
        #endregion      

        #region 刪除項目ProgramT Delete(string strSqlWhere)
        /// <summary>
        /// 刪除項目ProgramT ,符合條件刪除(多筆)
        /// </summary>
        /// <param name="strSqlWhere">查詢條件(不用加「where」關鍵字)</param>   
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>    
        /// <returns></returns>
        public object Delete(string strSqlWhere, string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.DeleteObj<CProgram>(strSqlWhere, strCusTableName);
            return retObj;
        }
        #endregion

        #endregion

        #endregion
    }
    #endregion =================
}
