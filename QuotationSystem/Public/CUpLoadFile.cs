using H3Operator.DBHelper;
using H3Operator.DBModels;
using System.Collections.Generic;

namespace LawtechPTSystem.Public
{
    #region CUpLoadFile=================
    /// <summary>
    /// 
    /// </summary>
    [TableMapping("UpLoadFileT")]
    public class CUpLoadFile : SysBaseModel
    {
        #region Public property

        private int m_UpLoadID;
        /// <summary>
        /// 專利、商標上傳相關檔案表 PK
        /// </summary>
        [TableColumnSetting("UpLoadID", DbType = SqlDataType.Int, IsPrimary = true, IsCumulative = true, IsCanNull = false, DataLength = 4)]
        public int UpLoadID
        {
            get
            {
                return m_UpLoadID;
            }
            set
            {
                m_UpLoadID = value;
            }
        }

        private int m_MainParentID;
        /// <summary>
        /// 主要ID(專利、商標案的ID)
        /// </summary>
        [TableColumnSetting("MainParentID", DbType = SqlDataType.Int, IsCanNull = false, DataLength = 4)]
        public int MainParentID
        {
            get
            {
                return m_MainParentID;
            }
            set
            {
                m_MainParentID = value;
            }
        }

        private int? m_ChildID;
        /// <summary>
        /// 副ID(專利-如事件記錄、來函....)
        /// </summary>
        [TableColumnSetting("ChildID", DbType = SqlDataType.Int, DataLength = 4)]
        public int? ChildID
        {
            get
            {
                return m_ChildID;
            }
            set
            {
                m_ChildID = value;
            }
        }

        private int? m_FileKind;
        /// <summary>
        ///  (主)檔案上傳模式: 1.段落依據 2.相關檔案管理 3.專利案件相關檔案管理 4.商標案件相關檔案管理 5.商標異議案 6.單位財產 10.知識管理  20.EmailLog的附件  30.已刪除的附件   40.客戶附加檔案 50.事務所附加檔案  
        /// </summary>
        [TableColumnSetting("FileKind", DbType = SqlDataType.Int, DataLength = 4)]
        public int? FileKind
        {
            get
            {
                return m_FileKind;
            }
            set
            {
                m_FileKind = value;
            }
        }

        private int? m_FileType;
        /// <summary>
        /// (副)類型(例:專利 0.申請案 1.委辦  2.來函  3.請款費用 4.付款費用    商標5. 代表圖 6.商標案件 7.來函  8.請款費用 9.付款費用)
        /// </summary>
        [TableColumnSetting("FileType", DbType = SqlDataType.Int, DataLength = 4)]
        public int? FileType
        {
            get
            {
                return m_FileType;
            }
            set
            {
                m_FileType = value;
            }
        }

        private string m_Uploader;
        /// <summary>
        /// 上傳者
        /// </summary>
        [TableColumnSetting("Uploader", DataLength = 100)]
        public string Uploader
        {
            get
            {
                return m_Uploader;
            }
            set
            {
                m_Uploader = value;
            }
        }

        private string m_FileDoc;
        /// <summary>
        /// 檔案說明
        /// </summary>
        [TableColumnSetting("FileDoc", DataLength = 1000)]
        public string FileDoc
        {
            get
            {
                return m_FileDoc;
            }
            set
            {
                m_FileDoc = value;
            }
        }

        private string m_FilePath;
        /// <summary>
        /// 檔案路徑
        /// </summary>
        [TableColumnSetting("FilePath", DataLength = 2000)]
        public string FilePath
        {
            get
            {
                return m_FilePath;
            }
            set
            {
                m_FilePath = value;
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
            List<CUpLoadFile> list = new List<CUpLoadFile>();
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
                retObj = orm.ReadListToObjs<CUpLoadFile>(ColumnName + "=@" + ColumnName, ref list, ParList);
            }
            else
            {
                retObj = orm.ReadListToObjs<CUpLoadFile>(ColumnName + "=@" + ColumnName + " and UpLoadID<>" + this.UpLoadID.ToString(), ref list, ParList);
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

        #region 取得一筆資料  ReadOne(ref CUpLoadFile Item, string strCusTableName = ")
        /// <summary>
        /// 取得一筆UpLoadFileT資料
        /// </summary>          
        /// <param name="item"></param>   
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>
        /// <returns>0:成功 ; string:失敗</returns>       
        public static object ReadOne(ref CUpLoadFile Item, string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.ReadOneToObj(ref Item, CusTableName: strCusTableName);
            return retObj;
        }
        #endregion

        #region 取得一筆資料 ReadOne(int iPKey, ref DB_MenuRoleTModel item, string strCusTableName = "")
        /// <summary>
        /// 取得一筆UpLoadFileT資料
        /// </summary>
        /// <param name="iPKey">指定某筆資料的Key值(不適合複合key)</param>     
        /// <param name="item"></param>   
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>
        /// <returns>0:成功 ; string:失敗</returns>       
        public static object ReadOne(int iPKey, ref CUpLoadFile item, string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.ReadOneToObj(iPKey, ref item, CusTableName: strCusTableName);
            return retObj;
        }
        #endregion

        #region 取得一筆UpLoadFileT資料 ReadOne(string strSqlWhere, System.Data.SqlClient.SqlParameter[] MySqlParameterList=null, string strCusTableName = "")
        /// <summary>
        /// 取得一筆UpLoadFileT資料;如果有多筆符合條件，則只回傳null
        /// </summary>
        /// <param name="strSqlWhere">查詢條件(不用加「where」關鍵字, 可加Sql參數,例如: account=@account)</param>
        /// <param name="MySqlParameterList">Sql參數</param>
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>
        /// <returns>0:成功 ; string:失敗</returns>
        public static object ReadOne(string strSqlWhere, ref CUpLoadFile item, System.Data.SqlClient.SqlParameter[] MySqlParameterList = null, string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            List<CUpLoadFile> itemlist = new List<CUpLoadFile>();
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

        #region 取得多筆CUpLoadFile資料 ReadList
        /// <summary>
        /// 取得多筆 UpLoadFileT資料 
        /// </summary>
        /// <param name="Items"></param>
        /// <param name="strSqlWhere">SQL條件式 (不用加「where」關鑵字,可加Sql參數,例如: account=@account)</param>
        /// <param name="MySqlParameterList">Sql參數</param>
        /// <param name="strOrderBy">SQL排序式 , 當空值時，預設帶[ CreateDateTime Desc] (不用加「Order by 」關鑵字, 例 "uid desc,createDateTime asc ")</param>
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>      
        /// <returns></returns>
        public static object ReadList(ref List<CUpLoadFile> Items, string strSqlWhere = "", System.Data.SqlClient.SqlParameter[] MySqlParameterList = null, string strOrderBy = "", string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();

            object retObj = orm.ReadListToObjs<CUpLoadFile>(strSqlWhere, ref Items, sqlParameterList: MySqlParameterList, OrderBy: strOrderBy, CusTableName: strCusTableName);

            return retObj;
        }

        #endregion

        #region 取得多筆 UpLoadFileT資料 , 指定頁數和頁碼 ReadList
        /// <summary>
        /// 取得多筆 UpLoadFileT資料 , 指定頁數和頁碼
        /// </summary>
        /// <param name="PageSize">一頁的筆數</param>
        /// <param name="PageIndex">第 n 頁</param>
        /// <param name="Items"></param>
        /// <param name="strSqlWhere">SQL條件式 (不用加「where」關鑵字,可加Sql參數,例如: account=@account)</param>
        /// <param name="MySqlParameterList">Sql參數</param>
        /// <param name="strOrderBy">SQL排序式 , 當空值時，預設帶[ CreateDateTime Desc] (不用加「Order by 」關鑵字, 例 "uid desc,createDateTime asc ")</param>
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>       
        /// <returns></returns>
        public static object ReadList(int PageSize, int PageIndex, ref List<CUpLoadFile> Items, string strSqlWhere = "", System.Data.SqlClient.SqlParameter[] MySqlParameterList = null, string strOrderBy = "", string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();

            object retObj = orm.ReadListToObjs<CUpLoadFile>(PageSize, PageIndex, strSqlWhere, ref Items, sqlParameterList: MySqlParameterList, OrderBy: strOrderBy, CusTableName: strCusTableName);

            return retObj;
        }
        #endregion

        #region Create
        /// <summary>
        /// 新增UpLoadFileT 項目
        /// </summary> 
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>      
        /// <returns>0:成功 ; string:失敗</returns>
        public object Create(string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.InsertByObj<CUpLoadFile>(this, strCusTableName);
            return retObj;
        }
        #endregion

        #region Update
        /// <summary>
        /// 更新 UpLoadFileT 項目
        /// </summary>       
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param> 
        /// <returns>0:成功 ; string:失敗</returns>
        public object Update(string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.UpdateObj<CUpLoadFile>(this, strCusTableName);
            return retObj;
        }
        #endregion

        #region Delete

        #region 刪除項目UpLoadFileT Delete()
        /// <summary>
        /// 刪除項目UpLoadFileT
        /// </summary>  
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>
        /// <returns></returns>   
        public object Delete(string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.DeleteObj<CUpLoadFile>(this, strCusTableName);
            return retObj;
        }
        #endregion

        #region 刪除項目UpLoadFileT Delete(int iPKey)
        /// <summary>
        /// 刪除項目UpLoadFileT , 指定某一筆主鍵刪除(單筆)
        /// </summary>
        /// <param name="iPKey">指定刪除某筆資料的Key值</param> 
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>      
        /// <returns></returns>
        public object Delete(int iPKey, string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.DeleteObj<CUpLoadFile>(iPKey, strCusTableName);
            return retObj;
        }
        #endregion

        #region 刪除項目UpLoadFileT Delete(string strSqlWhere)
        /// <summary>
        /// 刪除項目UpLoadFileT ,符合條件刪除(多筆)
        /// </summary>
        /// <param name="strSqlWhere">查詢條件(不用加「where」關鍵字)</param>   
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>    
        /// <returns></returns>
        public object Delete(string strSqlWhere, string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.DeleteObj<CUpLoadFile>(strSqlWhere, strCusTableName);
            return retObj;
        }
        #endregion

        #endregion

        #endregion
    }
    #endregion =================
}
