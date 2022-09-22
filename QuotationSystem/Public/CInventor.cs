using H3Operator.DBModels;
using H3Operator.DBHelper;
using System.Collections.Generic;


namespace LawtechPTSystem.Public
{
    #region CInventor=================
    /// <summary>
    /// 
    /// </summary>
    [TableMapping("InventorT")]
    public class CInventor : SysBaseModel
    {
        #region Public property

        private int m_InventorKey;
        /// <summary>
        /// 發明人資料表
        /// </summary>
        [TableColumnSetting("InventorKey", DbType = SqlDataType.Int, IsPrimary = true, IsCumulative = true, IsCanNull = false, DataLength = 4)]
        public int InventorKey
        {
            get
            {
                return m_InventorKey;
            }
            set
            {
                m_InventorKey = value;
            }
        }

        private int? m_ApplicantKey;
        /// <summary>
        /// ApplicantT key值
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

        private string m_InventorName;
        /// <summary>
        /// 發明人姓名
        /// </summary>
        [TableColumnSetting("InventorName", DataLength = 100)]
        public string InventorName
        {
            get
            {
                return m_InventorName;
            }
            set
            {
                m_InventorName = value;
            }
        }

        private string m_FamilyName;
        /// <summary>
        /// 姓
        /// </summary>
        [TableColumnSetting("FamilyName", DataLength = 200)]
        public string FamilyName
        {
            get
            {
                return m_FamilyName;
            }
            set
            {
                m_FamilyName = value;
            }
        }

        private string m_GivenName;
        /// <summary>
        /// 名
        /// </summary>
        [TableColumnSetting("GivenName", DataLength = 400)]
        public string GivenName
        {
            get
            {
                return m_GivenName;
            }
            set
            {
                m_GivenName = value;
            }
        }

        private string m_FullEnName;
        /// <summary>
        /// 英文全名
        /// </summary>
        [TableColumnSetting("FullEnName", DataLength = 600)]
        public string FullEnName
        {
            get
            {
                return m_FullEnName;
            }
            set
            {
                m_FullEnName = value;
            }
        }

        private string m_InventorID;
        /// <summary>
        /// 身份証字號
        /// </summary>
        [TableColumnSetting("InventorID", DataLength = 300)]
        public string InventorID
        {
            get
            {
                return m_InventorID;
            }
            set
            {
                m_InventorID = value;
            }
        }

        private string m_Address;
        /// <summary>
        /// 地址
        /// </summary>
        [TableColumnSetting("Address", DataLength = 1000)]
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

        private string m_Remark;
        /// <summary>
        /// 備註
        /// </summary>
        [TableColumnSetting("Remark", DataLength = 1000)]
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

        private string m_InventorCountryCitizenship;
        /// <summary>
        /// 發明人國籍
        /// </summary>
        [TableColumnSetting("InventorCountryCitizenship", DataLength = 1000)]
        public string InventorCountryCitizenship
        {
            get
            {
                return m_InventorCountryCitizenship;
            }
            set
            {
                m_InventorCountryCitizenship = value;
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
            List<CInventor> list = new List<CInventor>();
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
                retObj = orm.ReadListToObjs<CInventor>(ColumnName + "=@" + ColumnName, ref list, ParList);
            }
            else
            {
                retObj = orm.ReadListToObjs<CInventor>(ColumnName + "=@" + ColumnName + " and InventorKey<>" + this.InventorKey.ToString(), ref list, ParList);
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

        #region 取得一筆資料  ReadOne(ref CInventor Item, string strCusTableName = ")
        /// <summary>
        /// 取得一筆InventorT資料
        /// </summary>          
        /// <param name="item"></param>   
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>
        /// <returns>0:成功 ; string:失敗</returns>       
        public static object ReadOne(ref CInventor Item, string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.ReadOneToObj(ref Item, CusTableName: strCusTableName);
            return retObj;
        }
        #endregion

        #region 取得一筆資料 ReadOne(int iPKey, ref DB_MenuRoleTModel item, string strCusTableName = "")
        /// <summary>
        /// 取得一筆InventorT資料
        /// </summary>
        /// <param name="iPKey">指定某筆資料的Key值(不適合複合key)</param>     
        /// <param name="item"></param>   
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>
        /// <returns>0:成功 ; string:失敗</returns>       
        public static object ReadOne(int iPKey, ref CInventor item, string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.ReadOneToObj(iPKey, ref item, CusTableName: strCusTableName);
            return retObj;
        }
        #endregion

        #region 取得一筆InventorT資料 ReadOne(string strSqlWhere, System.Data.SqlClient.SqlParameter[] MySqlParameterList=null, string strCusTableName = "")
        /// <summary>
        /// 取得一筆InventorT資料;如果有多筆符合條件，則只回傳null
        /// </summary>
        /// <param name="strSqlWhere">查詢條件(不用加「where」關鍵字, 可加Sql參數,例如: account=@account)</param>
        /// <param name="MySqlParameterList">Sql參數</param>
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>
        /// <returns>0:成功 ; string:失敗</returns>
        public static object ReadOne(string strSqlWhere, ref CInventor item, System.Data.SqlClient.SqlParameter[] MySqlParameterList = null, string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            List<CInventor> itemlist = new List<CInventor>();
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

        #region 取得多筆CInventor資料 ReadList
        /// <summary>
        /// 取得多筆 InventorT資料 
        /// </summary>
        /// <param name="Items"></param>
        /// <param name="strSqlWhere">SQL條件式 (不用加「where」關鑵字,可加Sql參數,例如: account=@account)</param>
        /// <param name="MySqlParameterList">Sql參數</param>
        /// <param name="strOrderBy">SQL排序式 , 當空值時，預設帶[ CreateDateTime Desc] (不用加「Order by 」關鑵字, 例 "uid desc,createDateTime asc ")</param>
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>      
        /// <returns></returns>
        public static object ReadList(ref List<CInventor> Items, string strSqlWhere = "", System.Data.SqlClient.SqlParameter[] MySqlParameterList = null, string strOrderBy = "", string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();

            object retObj = orm.ReadListToObjs<CInventor>(strSqlWhere, ref Items, sqlParameterList: MySqlParameterList, OrderBy: strOrderBy, CusTableName: strCusTableName);

            return retObj;
        }

        #endregion

        #region 取得多筆 InventorT資料 , 指定頁數和頁碼 ReadList
        /// <summary>
        /// 取得多筆 InventorT資料 , 指定頁數和頁碼
        /// </summary>
        /// <param name="PageSize">一頁的筆數</param>
        /// <param name="PageIndex">第 n 頁</param>
        /// <param name="Items"></param>
        /// <param name="strSqlWhere">SQL條件式 (不用加「where」關鑵字,可加Sql參數,例如: account=@account)</param>
        /// <param name="MySqlParameterList">Sql參數</param>
        /// <param name="strOrderBy">SQL排序式 , 當空值時，預設帶[ CreateDateTime Desc] (不用加「Order by 」關鑵字, 例 "uid desc,createDateTime asc ")</param>
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>       
        /// <returns></returns>
        public static object ReadList(int PageSize, int PageIndex, ref List<CInventor> Items, string strSqlWhere = "", System.Data.SqlClient.SqlParameter[] MySqlParameterList = null, string strOrderBy = "", string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();

            object retObj = orm.ReadListToObjs<CInventor>(PageSize, PageIndex, strSqlWhere, ref Items, sqlParameterList: MySqlParameterList, OrderBy: strOrderBy, CusTableName: strCusTableName);

            return retObj;
        }
        #endregion

        #region Create
        /// <summary>
        /// 新增InventorT 項目
        /// </summary> 
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>      
        /// <returns>0:成功 ; string:失敗</returns>
        public object Create(string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.InsertByObj<CInventor>(this, strCusTableName);
            return retObj;
        }
        #endregion

        #region Update
        /// <summary>
        /// 更新 InventorT 項目
        /// </summary>       
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param> 
        /// <returns>0:成功 ; string:失敗</returns>
        public object Update(string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.UpdateObj<CInventor>(this, strCusTableName);
            return retObj;
        }
        #endregion

        #region Delete

        #region 刪除項目InventorT Delete()
        /// <summary>
        /// 刪除項目InventorT
        /// </summary>  
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>
        /// <returns></returns>   
        public object Delete(string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.DeleteObj<CInventor>(this, strCusTableName);
            return retObj;
        }
        #endregion

        #region 刪除項目InventorT Delete(int iPKey)
        /// <summary>
        /// 刪除項目InventorT , 指定某一筆主鍵刪除(單筆)
        /// </summary>
        /// <param name="iPKey">指定刪除某筆資料的Key值</param> 
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>      
        /// <returns></returns>
        public object Delete(int iPKey, string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.DeleteObj<CInventor>(iPKey, strCusTableName);
            return retObj;
        }
        #endregion

        #region 刪除項目InventorT Delete(string strSqlWhere)
        /// <summary>
        /// 刪除項目InventorT ,符合條件刪除(多筆)
        /// </summary>
        /// <param name="strSqlWhere">查詢條件(不用加「where」關鍵字)</param>   
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>    
        /// <returns></returns>
        public object Delete(string strSqlWhere, string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.DeleteObj<CInventor>(strSqlWhere, strCusTableName);
            return retObj;
        }
        #endregion

        #endregion

        #endregion
    }
    #endregion =================

}
