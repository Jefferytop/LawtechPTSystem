using H3Operator.DBHelper;
using H3Operator.DBModels;
using System.Collections.Generic;

namespace LawtechPTSystemByFirm.Public
{
    #region CWorkerProgram=================
    /// <summary>
    /// 
    /// </summary>
    [TableMapping("WorkerProgramT")]
    public class CWorkerProgram : SysBaseModel
    {
        #region Public property

        private int m_PWID;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("PWID", DbType = SqlDataType.Int, IsPrimary = true, IsCumulative = true, IsCanNull = false, DataLength = 4)]
        public int PWID
        {
            get
            {
                return m_PWID;
            }
            set
            {
                m_PWID = value;
            }
        }

        private int? m_ProgramKEY;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("ProgramKEY", DbType = SqlDataType.Int, DataLength = 4)]
        public int? ProgramKEY
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

        private int? m_WorkerKEY;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("WorkerKEY", DbType = SqlDataType.Int, DataLength = 4)]
        public int? WorkerKEY
        {
            get
            {
                return m_WorkerKEY;
            }
            set
            {
                m_WorkerKEY = value;
            }
        }

        private bool? m_AuthorizeCreate;
        /// <summary>
        /// 新增權限
        /// </summary>
        [TableColumnSetting("AuthorizeCreate", DbType = SqlDataType.Bit, DataLength = 1)]
        public bool? AuthorizeCreate
        {
            get
            {
                return m_AuthorizeCreate;
            }
            set
            {
                m_AuthorizeCreate = value;
            }
        }

        private bool? m_AuthorizeModify;
        /// <summary>
        /// 修改權限
        /// </summary>
        [TableColumnSetting("AuthorizeModify", DbType = SqlDataType.Bit, DataLength = 1)]
        public bool? AuthorizeModify
        {
            get
            {
                return m_AuthorizeModify;
            }
            set
            {
                m_AuthorizeModify = value;
            }
        }

        private bool? m_SearchAuthority;
        /// <summary>
        /// 檢視權限
        /// </summary>
        [TableColumnSetting("SearchAuthority", DbType = SqlDataType.Bit, DataLength = 1)]
        public bool? SearchAuthority
        {
            get
            {
                return m_SearchAuthority;
            }
            set
            {
                m_SearchAuthority = value;
            }
        }

        private bool? m_AuthorizeDelete;
        /// <summary>
        /// 刪除權限
        /// </summary>
        [TableColumnSetting("AuthorizeDelete", DbType = SqlDataType.Bit, DataLength = 1)]
        public bool? AuthorizeDelete
        {
            get
            {
                return m_AuthorizeDelete;
            }
            set
            {
                m_AuthorizeDelete = value;
            }
        }

        private bool? m_AuthorizeDownload;
        /// <summary>
        /// 下載權限
        /// </summary>
        [TableColumnSetting("AuthorizeDownload", DbType = SqlDataType.Bit, DataLength = 1)]
        public bool? AuthorizeDownload
        {
            get
            {
                return m_AuthorizeDownload;
            }
            set
            {
                m_AuthorizeDownload = value;
            }
        }

        private bool? m_AuthorizeExport;
        /// <summary>
        /// 匯出權限
        /// </summary>
        [TableColumnSetting("AuthorizeExport", DbType = SqlDataType.Bit, DataLength = 1)]
        public bool? AuthorizeExport
        {
            get
            {
                return m_AuthorizeExport;
            }
            set
            {
                m_AuthorizeExport = value;
            }
        }

        private bool? m_AuthorizeUpload;
        /// <summary>
        /// 上傳權限
        /// </summary>
        [TableColumnSetting("AuthorizeUpload", DbType = SqlDataType.Bit, DataLength = 1)]
        public bool? AuthorizeUpload
        {
            get
            {
                return m_AuthorizeUpload;
            }
            set
            {
                m_AuthorizeUpload = value;
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
            List<CWorkerProgram> list = new List<CWorkerProgram>();
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
                retObj = orm.ReadListToObjs<CWorkerProgram>(ColumnName + "=@" + ColumnName, ref list, ParList);
            }
            else
            {
                retObj = orm.ReadListToObjs<CWorkerProgram>(ColumnName + "=@" + ColumnName + " and PWID<>" + this.PWID.ToString(), ref list, ParList);
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

        #region 取得一筆資料  ReadOne(ref CWorkerProgram Item, string strCusTableName = ")
        /// <summary>
        /// 取得一筆WorkerProgramT資料
        /// </summary>          
        /// <param name="item"></param>   
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>
        /// <returns>0:成功 ; string:失敗</returns>       
        public static object ReadOne(ref CWorkerProgram Item, string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.ReadOneToObj(ref Item, CusTableName: strCusTableName);
            return retObj;
        }
        #endregion

        #region 取得一筆資料 ReadOne(int iPKey, ref DB_MenuRoleTModel item, string strCusTableName = "")
        /// <summary>
        /// 取得一筆WorkerProgramT資料
        /// </summary>
        /// <param name="iPKey">指定某筆資料的Key值(不適合複合key)</param>     
        /// <param name="item"></param>   
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>
        /// <returns>0:成功 ; string:失敗</returns>       
        public static object ReadOne(int iPKey, ref CWorkerProgram item, string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.ReadOneToObj(iPKey, ref item, CusTableName: strCusTableName);
            return retObj;
        }
        #endregion

        #region 取得一筆WorkerProgramT資料 ReadOne(string strSqlWhere, System.Data.SqlClient.SqlParameter[] MySqlParameterList=null, string strCusTableName = "")
        /// <summary>
        /// 取得一筆WorkerProgramT資料;如果有多筆符合條件，則只回傳null
        /// </summary>
        /// <param name="strSqlWhere">查詢條件(不用加「where」關鍵字, 可加Sql參數,例如: account=@account)</param>
        /// <param name="MySqlParameterList">Sql參數</param>
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>
        /// <returns>0:成功 ; string:失敗</returns>
        public static object ReadOne(string strSqlWhere, ref CWorkerProgram item, System.Data.SqlClient.SqlParameter[] MySqlParameterList = null, string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            List<CWorkerProgram> itemlist = new List<CWorkerProgram>();
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

        #region 取得多筆CWorkerProgram資料 ReadList
        /// <summary>
        /// 取得多筆 WorkerProgramT資料 
        /// </summary>
        /// <param name="Items"></param>
        /// <param name="strSqlWhere">SQL條件式 (不用加「where」關鑵字,可加Sql參數,例如: account=@account)</param>
        /// <param name="MySqlParameterList">Sql參數</param>
        /// <param name="strOrderBy">SQL排序式 , 當空值時，預設帶[ CreateDateTime Desc] (不用加「Order by 」關鑵字, 例 "uid desc,createDateTime asc ")</param>
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>      
        /// <returns></returns>
        public static object ReadList(ref List<CWorkerProgram> Items, string strSqlWhere = "", System.Data.SqlClient.SqlParameter[] MySqlParameterList = null, string strOrderBy = "", string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();

            object retObj = orm.ReadListToObjs<CWorkerProgram>(strSqlWhere, ref Items, sqlParameterList: MySqlParameterList, OrderBy: strOrderBy, CusTableName: strCusTableName);

            return retObj;
        }

        #endregion

        #region 取得多筆 WorkerProgramT資料 , 指定頁數和頁碼 ReadList
        /// <summary>
        /// 取得多筆 WorkerProgramT資料 , 指定頁數和頁碼
        /// </summary>
        /// <param name="PageSize">一頁的筆數</param>
        /// <param name="PageIndex">第 n 頁</param>
        /// <param name="Items"></param>
        /// <param name="strSqlWhere">SQL條件式 (不用加「where」關鑵字,可加Sql參數,例如: account=@account)</param>
        /// <param name="MySqlParameterList">Sql參數</param>
        /// <param name="strOrderBy">SQL排序式 , 當空值時，預設帶[ CreateDateTime Desc] (不用加「Order by 」關鑵字, 例 "uid desc,createDateTime asc ")</param>
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>       
        /// <returns></returns>
        public static object ReadList(int PageSize, int PageIndex, ref List<CWorkerProgram> Items, string strSqlWhere = "", System.Data.SqlClient.SqlParameter[] MySqlParameterList = null, string strOrderBy = "", string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();

            object retObj = orm.ReadListToObjs<CWorkerProgram>(PageSize, PageIndex, strSqlWhere, ref Items, sqlParameterList: MySqlParameterList, OrderBy: strOrderBy, CusTableName: strCusTableName);

            return retObj;
        }
        #endregion

        #region Create
        /// <summary>
        /// 新增WorkerProgramT 項目
        /// </summary> 
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>      
        /// <returns>0:成功 ; string:失敗</returns>
        public object Create(string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.InsertByObj<CWorkerProgram>(this, strCusTableName);
            return retObj;
        }
        #endregion

        #region Update
        /// <summary>
        /// 更新 WorkerProgramT 項目
        /// </summary>       
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param> 
        /// <returns>0:成功 ; string:失敗</returns>
        public object Update(string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.UpdateObj<CWorkerProgram>(this, strCusTableName);
            return retObj;
        }
        #endregion

        #region Delete

        #region 刪除項目WorkerProgramT Delete()
        /// <summary>
        /// 刪除項目WorkerProgramT
        /// </summary>  
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>
        /// <returns></returns>   
        public object Delete(string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.DeleteObj<CWorkerProgram>(this, strCusTableName);
            return retObj;
        }
        #endregion

        #region 刪除項目WorkerProgramT Delete(int iPKey)
        /// <summary>
        /// 刪除項目WorkerProgramT , 指定某一筆主鍵刪除(單筆)
        /// </summary>
        /// <param name="iPKey">指定刪除某筆資料的Key值</param> 
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>      
        /// <returns></returns>
        public object Delete(int iPKey, string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.DeleteObj<CWorkerProgram>(iPKey, strCusTableName);
            return retObj;
        }
        #endregion

        #region 刪除項目WorkerProgramT Delete(string strSqlWhere)
        /// <summary>
        /// 刪除項目WorkerProgramT ,符合條件刪除(多筆)
        /// </summary>
        /// <param name="strSqlWhere">查詢條件(不用加「where」關鍵字)</param>   
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>    
        /// <returns></returns>
        public object Delete(string strSqlWhere, string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.DeleteObj<CWorkerProgram>(strSqlWhere, strCusTableName);
            return retObj;
        }
        #endregion

        #endregion

        #endregion
    }
    #endregion =================
}
