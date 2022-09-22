using System.Collections.Generic;
using H3Operator.DBHelper;
using H3Operator.DBModels;


namespace LawtechPTSystem.Public
{
    #region CLinks=================
    /// <summary>
    /// 
    /// </summary>
    [TableMapping("LinksT")]
    public class CLinks : SysBaseModel
    {
        #region Public property

        private int m_LinksKey;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("LinksKey", DbType = SqlDataType.Int, IsPrimary = true, IsCumulative = true, IsCanNull = false, DataLength = 4)]
        public int LinksKey
        {
            get
            {
                return m_LinksKey;
            }
            set
            {
                m_LinksKey = value;
            }
        }

        private int? m_NewsTypeKey;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("NewsTypeKey", DbType = SqlDataType.Int, DataLength = 4)]
        public int? NewsTypeKey
        {
            get
            {
                return m_NewsTypeKey;
            }
            set
            {
                m_NewsTypeKey = value;
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

        private string m_WebSiteName;
        /// <summary>
        /// 網站名稱
        /// </summary>
        [TableColumnSetting("WebSiteName", DataLength = 1000)]
        public string WebSiteName
        {
            get
            {
                return m_WebSiteName;
            }
            set
            {
                m_WebSiteName = value;
            }
        }

        private string m_WebAddress;
        /// <summary>
        /// 網址
        /// </summary>
        [TableColumnSetting("WebAddress", DataLength = 1000)]
        public string WebAddress
        {
            get
            {
                return m_WebAddress;
            }
            set
            {
                m_WebAddress = value;
            }
        }

        private string m_Description;
        /// <summary>
        /// 說明
        /// </summary>
        [TableColumnSetting("Description", DataLength = 6000)]
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

        private int? m_Creator;
        /// <summary>
        /// 建立者
        /// </summary>
        [TableColumnSetting("Creator", DbType = SqlDataType.Int, DataLength = 4)]
        public int? Creator
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
            List<CLinks> list = new List<CLinks>();
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
                retObj = orm.ReadListToObjs<CLinks>(ColumnName + "=@" + ColumnName, ref list, ParList);
            }
            else
            {
                retObj = orm.ReadListToObjs<CLinks>(ColumnName + "=@" + ColumnName + " and LinksKey<>" + this.LinksKey.ToString(), ref list, ParList);
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

        #region 取得一筆資料  ReadOne(ref CLinks Item, string strCusTableName = ")
        /// <summary>
        /// 取得一筆LinksT資料
        /// </summary>          
        /// <param name="item"></param>   
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>
        /// <returns>0:成功 ; string:失敗</returns>       
        public static object ReadOne(ref CLinks Item, string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.ReadOneToObj(ref Item, CusTableName: strCusTableName);
            return retObj;
        }
        #endregion

        #region 取得一筆資料 ReadOne(int iPKey, ref DB_MenuRoleTModel item, string strCusTableName = "")
        /// <summary>
        /// 取得一筆LinksT資料
        /// </summary>
        /// <param name="iPKey">指定某筆資料的Key值(不適合複合key)</param>     
        /// <param name="item"></param>   
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>
        /// <returns>0:成功 ; string:失敗</returns>       
        public static object ReadOne(int iPKey, ref CLinks item, string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.ReadOneToObj(iPKey, ref item, CusTableName: strCusTableName);
            return retObj;
        }
        #endregion

        #region 取得一筆LinksT資料 ReadOne(string strSqlWhere, System.Data.SqlClient.SqlParameter[] MySqlParameterList=null, string strCusTableName = "")
        /// <summary>
        /// 取得一筆LinksT資料;如果有多筆符合條件，則只回傳null
        /// </summary>
        /// <param name="strSqlWhere">查詢條件(不用加「where」關鍵字, 可加Sql參數,例如: account=@account)</param>
        /// <param name="MySqlParameterList">Sql參數</param>
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>
        /// <returns>0:成功 ; string:失敗</returns>
        public static object ReadOne(string strSqlWhere, ref CLinks item, System.Data.SqlClient.SqlParameter[] MySqlParameterList = null, string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            List<CLinks> itemlist = new List<CLinks>();
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

        #region 取得多筆CLinks資料 ReadList
        /// <summary>
        /// 取得多筆 LinksT資料 
        /// </summary>
        /// <param name="Items"></param>
        /// <param name="strSqlWhere">SQL條件式 (不用加「where」關鑵字,可加Sql參數,例如: account=@account)</param>
        /// <param name="MySqlParameterList">Sql參數</param>
        /// <param name="strOrderBy">SQL排序式 , 當空值時，預設帶[ CreateDateTime Desc] (不用加「Order by 」關鑵字, 例 "uid desc,createDateTime asc ")</param>
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>      
        /// <returns></returns>
        public static object ReadList(ref List<CLinks> Items, string strSqlWhere = "", System.Data.SqlClient.SqlParameter[] MySqlParameterList = null, string strOrderBy = "", string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();

            object retObj = orm.ReadListToObjs<CLinks>(strSqlWhere, ref Items, sqlParameterList: MySqlParameterList, OrderBy: strOrderBy, CusTableName: strCusTableName);

            return retObj;
        }

        #endregion

        #region 取得多筆 LinksT資料 , 指定頁數和頁碼 ReadList
        /// <summary>
        /// 取得多筆 LinksT資料 , 指定頁數和頁碼
        /// </summary>
        /// <param name="PageSize">一頁的筆數</param>
        /// <param name="PageIndex">第 n 頁</param>
        /// <param name="Items"></param>
        /// <param name="strSqlWhere">SQL條件式 (不用加「where」關鑵字,可加Sql參數,例如: account=@account)</param>
        /// <param name="MySqlParameterList">Sql參數</param>
        /// <param name="strOrderBy">SQL排序式 , 當空值時，預設帶[ CreateDateTime Desc] (不用加「Order by 」關鑵字, 例 "uid desc,createDateTime asc ")</param>
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>       
        /// <returns></returns>
        public static object ReadList(int PageSize, int PageIndex, ref List<CLinks> Items, string strSqlWhere = "", System.Data.SqlClient.SqlParameter[] MySqlParameterList = null, string strOrderBy = "", string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();

            object retObj = orm.ReadListToObjs<CLinks>(PageSize, PageIndex, strSqlWhere, ref Items, sqlParameterList: MySqlParameterList, OrderBy: strOrderBy, CusTableName: strCusTableName);

            return retObj;
        }
        #endregion

        #region Create
        /// <summary>
        /// 新增LinksT 項目
        /// </summary> 
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>      
        /// <returns>0:成功 ; string:失敗</returns>
        public object Create(string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.InsertByObj<CLinks>(this, strCusTableName);
            return retObj;
        }
        #endregion

        #region Update
        /// <summary>
        /// 更新 LinksT 項目
        /// </summary>       
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param> 
        /// <returns>0:成功 ; string:失敗</returns>
        public object Update(string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.UpdateObj<CLinks>(this, strCusTableName);
            return retObj;
        }
        #endregion

        #region Delete

        #region 刪除項目LinksT Delete()
        /// <summary>
        /// 刪除項目LinksT
        /// </summary>  
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>
        /// <returns></returns>   
        public object Delete(string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.DeleteObj<CLinks>(this, strCusTableName);
            return retObj;
        }
        #endregion

        #region 刪除項目LinksT Delete(int iPKey)
        /// <summary>
        /// 刪除項目LinksT , 指定某一筆主鍵刪除(單筆)
        /// </summary>
        /// <param name="iPKey">指定刪除某筆資料的Key值</param> 
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>      
        /// <returns></returns>
        public object Delete(int iPKey, string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.DeleteObj<CLinks>(iPKey, strCusTableName);
            return retObj;
        }
        #endregion

        #region 刪除項目LinksT Delete(string strSqlWhere)
        /// <summary>
        /// 刪除項目LinksT ,符合條件刪除(多筆)
        /// </summary>
        /// <param name="strSqlWhere">查詢條件(不用加「where」關鍵字)</param>   
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>    
        /// <returns></returns>
        public object Delete(string strSqlWhere, string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.DeleteObj<CLinks>(strSqlWhere, strCusTableName);
            return retObj;
        }
        #endregion

        #endregion

        #endregion
    }
    #endregion =================
    #region ======CLinks======
//    public class CLinks
//    {
//        SqlConnection conn = new SqlConnection(DBAccess.ConnectionListDefaultConnectionString);
//        SqlDataAdapter sAdapter;
//        SqlCommandBuilder CBuilder;

//        DataTable dt;
//        /// <summary>
//        /// 預設帶出所有的資料
//        /// </summary>
//        public CLinks()
//        {
//            sAdapter = new SqlDataAdapter("select * from LinksT", conn);
//            dt = new DataTable();
//            //DataSet ds = new DataSet();
//            //ds.Tables.Add(dt);
//            sAdapter.FillSchema(dt, SchemaType.Source);
//            sAdapter.Fill(dt);
//            CBuilder = new SqlCommandBuilder(sAdapter);
//            sAdapter.InsertCommand = CBuilder.GetInsertCommand(true);
//            sAdapter.InsertCommand.UpdatedRowSource = UpdateRowSource.Both;
//            sAdapter.InsertCommand.CommandText += " Select @@IDENTITY AS 'IDENTITY'";
//            sAdapter.UpdateCommand = new SqlCommand(@"UPDATE LinksT  SET 
//                                                       NewsTypeID=@NewsTypeID,
//                                                       Sort=@Sort,
//                                                       WebSiteName=@WebSiteName,
//                                                       WebAddress=@WebAddress,
//                                                       Description=@Description,
//                                                       Creator=@Creator,
//                                                       CreateDate=@CreateDate,
//                                                       LastEditDate=@LastEditDate
//                                                   where 
//                                                       LINKEy=@LINKEy", conn);
//        }
//        /// <summary>
//        /// 有條件的過濾資料
//        /// </summary>
//        /// <param name="sWhere">SQL的條件式</param>
//        public CLinks(string sWhere)
//        {
//            sAdapter = new SqlDataAdapter("select * from LinksT where " + sWhere, conn);
//            dt = new DataTable();
//            //DataSet ds = new DataSet();
//            //ds.Tables.Add(dt);
//            sAdapter.FillSchema(dt, SchemaType.Source);
//            sAdapter.Fill(dt);
//            CBuilder = new SqlCommandBuilder(sAdapter);
//            sAdapter.InsertCommand = CBuilder.GetInsertCommand(true);
//            sAdapter.InsertCommand.UpdatedRowSource = UpdateRowSource.Both;
//            sAdapter.InsertCommand.CommandText += " Select @@IDENTITY AS 'IDENTITY'";
//            sAdapter.UpdateCommand = new SqlCommand(@"UPDATE LinksT  SET 
//                                                       NewsTypeID=@NewsTypeID,
//                                                       Sort=@Sort,
//                                                       WebSiteName=@WebSiteName,
//                                                       WebAddress=@WebAddress,
//                                                       Description=@Description,
//                                                       Creator=@Creator,
//                                                       CreateDate=@CreateDate,
//                                                       LastEditDate=@LastEditDate
//                                                   where 
//                                                       LINKEy=@LINKEy", conn);
//        }


//        private int _LINKEy = -1;
//        /// <summary>  
//        /// 
//        /// </summary>  
//        public int LINKEy
//        {
//            get
//            {
//                return _LINKEy;
//            }
//            set
//            {
//                _LINKEy = value;
//            }
//        }
//        private int _NewsTypeID = -1;
//        /// <summary>  
//        /// 
//        /// </summary>  
//        public int NewsTypeID
//        {
//            get
//            {
//                return _NewsTypeID;
//            }
//            set
//            {
//                _NewsTypeID = value;
//            }
//        }
//        private int _Sort = -1;
//        /// <summary>  
//        /// 
//        /// </summary>  
//        public int Sort
//        {
//            get
//            {
//                return _Sort;
//            }
//            set
//            {
//                _Sort = value;
//            }
//        }
//        private string _WebSiteName = "";
//        /// <summary>  
//        /// 網站名稱
//        /// </summary>  
//        public String WebSiteName
//        {
//            get
//            {
//                return _WebSiteName;
//            }
//            set
//            {
//                _WebSiteName = value;
//            }
//        }
//        private string _WebAddress = "";
//        /// <summary>  
//        /// 網址
//        /// </summary>  
//        public String WebAddress
//        {
//            get
//            {
//                return _WebAddress;
//            }
//            set
//            {
//                _WebAddress = value;
//            }
//        }
//        private string _Description = "";
//        /// <summary>  
//        /// 說明
//        /// </summary>  
//        public String Description
//        {
//            get
//            {
//                return _Description;
//            }
//            set
//            {
//                _Description = value;
//            }
//        }
//        private int _Creator = -1;
//        /// <summary>  
//        /// 建立者
//        /// </summary>  
//        public int Creator
//        {
//            get
//            {
//                return _Creator;
//            }
//            set
//            {
//                _Creator = value;
//            }
//        }
//        private DateTime _CreateDate = DateTime.Parse("1900/1/1");
//        /// <summary>  
//        /// 建立時間
//        /// </summary>  
//        public DateTime CreateDate
//        {
//            get
//            {
//                return _CreateDate;
//            }
//            set
//            {
//                _CreateDate = value;
//            }
//        }
//        private DateTime _LastEditDate = DateTime.Parse("1900/1/1");
//        /// <summary>  
//        /// 最後修改時間
//        /// </summary>  
//        public DateTime LastEditDate
//        {
//            get
//            {
//                return _LastEditDate;
//            }
//            set
//            {
//                _LastEditDate = value;
//            }
//        }

//        /// <summary>
//        /// 取得LinksT資料集
//        /// </summary>
//        public DataTable GetDataTable()
//        {
//            return dt;
//        }

//        /// <summary>
//        /// 設定LinksT資料集
//        /// </summary>
//        /// <param name="ReTable"></param>
//        public void SetDataTable(DataTable ReTable)
//        {
//            dt = ReTable;
//        }

//        /// <summary> 
//        /// 確認該欄位的值是否重複   true:表示沒有這個值  false:表示資料庫已有這個值
//        /// </summary> 
//        /// <param name="ColumnName">資料庫欄位名稱</param> 
//        /// <param name="Value">欄位的值</param> 
//        /// <returns>true:表示沒有這個值  false:表示資料庫已有這個值</returns> 
//        public bool CheckValue(string ColumnName, string Value)
//        {
//            bool bValue = true;
//            Value.Replace("'", "").Replace("--", "").Replace("@", "");
//            string strSQL = "select count(" + ColumnName + ") as CountValue from LinksT where " + ColumnName + "='" + Value + "'";
//            SqlCommand comm = new SqlCommand(strSQL, conn);
//            conn.Open();
//            object obj = comm.ExecuteScalar();
//            conn.Close();
//            if (obj != null && (int)obj > 0)
//            {
//                bValue = false;
//            }
//            else
//            {
//                bValue = true;
//            }
//            return bValue;
//        }
//        /// <summary> 
//        /// 確認該欄位的值是否重複 
//        /// </summary> 
//        /// <param name="ColumnName">資料庫欄位名稱</param> 
//        /// <param name="Value">欄位的值</param> 
//        /// <returns>true:表示沒有這個值  false:表示資料庫已有這個值</returns> 
//        public bool CheckValue(string ColumnName, int Value)
//        {
//            bool bValue = true;
//            string strSQL = "select count(" + ColumnName + ") as CountValue from LinksT where " + ColumnName + "=" + Value;
//            SqlCommand comm = new SqlCommand(strSQL, conn);
//            conn.Open();
//            object obj = comm.ExecuteScalar();
//            conn.Close();
//            if (obj != null && (int)obj > 0)
//            {
//                bValue = false;
//            }
//            else
//            {
//                bValue = true;
//            }
//            return bValue;
//        }

//        public DataRow GetRow(string ColumnName, string Value)
//        {
//            dt.Rows.Clear();
//            sAdapter.Fill(dt);
//            DataRow dr = dt.NewRow();
//            for (int i = 0; i < dt.Rows.Count; i++)
//            {
//                if (dt.Rows[i][ColumnName].ToString() == Value)
//                {
//                    dr = dt.Rows[i];

//                    break;
//                }
//            }
//            return dr;
//        }
//        public void SetCurrent(int NO)
//        {
//            try
//            {
//                DataRow dr = dt.Rows.Find(NO);
//                this.LINKEy = dr["LINKEy"].ToString() == "" ? -1 : (int)dr["LINKEy"];
//                this.NewsTypeID = dr["NewsTypeID"].ToString() == "" ? -1 : (int)dr["NewsTypeID"];
//                this.Sort = dr["Sort"].ToString() == "" ? -1 : (int)dr["Sort"];
//                this.WebSiteName = dr["WebSiteName"].ToString();
//                this.WebAddress = dr["WebAddress"].ToString();
//                this.Description = dr["Description"].ToString();
//                this.Creator = dr["Creator"].ToString() == "" ? -1 : (int)dr["Creator"];
//                this.CreateDate = dr["CreateDate"].ToString() == "" ? DateTime.Parse("1900/1/1") : (DateTime)dr["CreateDate"];
//                this.LastEditDate = dr["LastEditDate"].ToString() == "" ? DateTime.Parse("1900/1/1") : (DateTime)dr["LastEditDate"];
//            }
//            catch
//            {
//                throw (new System.Exception("LinksT該筆資料有誤：" + NO.ToString()));
//            }
//        }
//        public void Insert()
//        {
//            try
//            {
//                Object Rownull = System.DBNull.Value;
//                DataRow dr = dt.NewRow();
//                dr["NewsTypeID"] = this.NewsTypeID == -1 ? Rownull : this.NewsTypeID;
//                dr["Sort"] = this.Sort == -1 ? Rownull : this.Sort;
//                dr["WebSiteName"] = this.WebSiteName == "" ? Rownull : this.WebSiteName;
//                dr["WebAddress"] = this.WebAddress == "" ? Rownull : this.WebAddress;
//                dr["Description"] = this.Description == "" ? Rownull : this.Description;
//                dr["Creator"] = this.Creator == -1 ? Rownull : this.Creator;
//                dr["CreateDate"] = this.CreateDate.ToShortDateString() == "1900/1/1" ? Rownull : this.CreateDate;
//                dr["LastEditDate"] = this.LastEditDate.ToShortDateString() == "1900/1/1" ? Rownull : this.LastEditDate;
//                sAdapter.InsertCommand.Parameters["@NewsTypeID"].Value = dr["NewsTypeID"];
//                sAdapter.InsertCommand.Parameters["@Sort"].Value = dr["Sort"];
//                sAdapter.InsertCommand.Parameters["@WebSiteName"].Value = dr["WebSiteName"];
//                sAdapter.InsertCommand.Parameters["@WebAddress"].Value = dr["WebAddress"];
//                sAdapter.InsertCommand.Parameters["@Description"].Value = dr["Description"];
//                sAdapter.InsertCommand.Parameters["@Creator"].Value = dr["Creator"];
//                sAdapter.InsertCommand.Parameters["@CreateDate"].Value = dr["CreateDate"];
//                sAdapter.InsertCommand.Parameters["@LastEditDate"].Value = dr["LastEditDate"];
//                conn.Open();
//                string KEY = sAdapter.InsertCommand.ExecuteScalar().ToString();
//                conn.Close();
//                if (KEY != "")
//                {
//                    this.LINKEy = int.Parse(KEY);
//                    dr["LINKEy"] = this.LINKEy;
//                }
//                dt.Rows.Add(dr);
//                dt.AcceptChanges();
//            }
//            catch (System.Exception EX)
//            {
//                System.Windows.Forms.MessageBox.Show(EX.Message.Replace("'", ""));
//            }
//        }
//        public void Updata(int No)
//        {
//            try
//            {
//                Object Rownull = System.DBNull.Value;
//                DataRow dr = dt.Rows.Find(No);
//                dr["NewsTypeID"] = this.NewsTypeID == -1 ? Rownull : this.NewsTypeID;
//                dr["Sort"] = this.Sort == -1 ? Rownull : this.Sort;
//                dr["WebSiteName"] = this.WebSiteName == "" ? Rownull : this.WebSiteName;
//                dr["WebAddress"] = this.WebAddress == "" ? Rownull : this.WebAddress;
//                dr["Description"] = this.Description == "" ? Rownull : this.Description;
//                dr["Creator"] = this.Creator == -1 ? Rownull : this.Creator;
//                dr["CreateDate"] = this.CreateDate.ToShortDateString() == "1900/1/1" ? Rownull : this.CreateDate;
//                dr["LastEditDate"] = this.LastEditDate.ToShortDateString() == "1900/1/1" ? Rownull : this.LastEditDate;
//                sAdapter.UpdateCommand.Parameters.Clear();
//                sAdapter.UpdateCommand.Parameters.Add("LINKEy", SqlDbType.Int);
//                sAdapter.UpdateCommand.Parameters["LINKEy"].Value = dr["LINKEy"];
//                sAdapter.UpdateCommand.Parameters.Add("NewsTypeID", SqlDbType.Int);
//                sAdapter.UpdateCommand.Parameters["NewsTypeID"].Value = dr["NewsTypeID"];
//                sAdapter.UpdateCommand.Parameters.Add("Sort", SqlDbType.Int);
//                sAdapter.UpdateCommand.Parameters["Sort"].Value = dr["Sort"];
//                sAdapter.UpdateCommand.Parameters.Add("WebSiteName", SqlDbType.NVarChar);
//                sAdapter.UpdateCommand.Parameters["WebSiteName"].Value = dr["WebSiteName"];
//                sAdapter.UpdateCommand.Parameters.Add("WebAddress", SqlDbType.NVarChar);
//                sAdapter.UpdateCommand.Parameters["WebAddress"].Value = dr["WebAddress"];
//                sAdapter.UpdateCommand.Parameters.Add("Description", SqlDbType.NVarChar);
//                sAdapter.UpdateCommand.Parameters["Description"].Value = dr["Description"];
//                sAdapter.UpdateCommand.Parameters.Add("Creator", SqlDbType.Int);
//                sAdapter.UpdateCommand.Parameters["Creator"].Value = dr["Creator"];
//                sAdapter.UpdateCommand.Parameters.Add("CreateDate", SqlDbType.DateTime);
//                sAdapter.UpdateCommand.Parameters["CreateDate"].Value = dr["CreateDate"];
//                sAdapter.UpdateCommand.Parameters.Add("LastEditDate", SqlDbType.DateTime);
//                sAdapter.UpdateCommand.Parameters["LastEditDate"].Value = dr["LastEditDate"];

//                sAdapter.UpdateCommand.Connection.Open();
//                sAdapter.UpdateCommand.ExecuteNonQuery();
//                sAdapter.UpdateCommand.Connection.Close();
//                dt.AcceptChanges();
//            }
//            catch (System.Exception EX)
//            {
//                System.Windows.Forms.MessageBox.Show(EX.Message.Replace("'", ""));
//            }
//        }
//        /// <summary>
//        /// 刪除--依條件式刪除資料
//        /// </summary>
//        /// <param name="strSQLWhere"></param>
//        public void Delete(string strSQLWhere)
//        {
//            try
//            {
//                StringBuilder delString = new StringBuilder("DELETE FROM LinksT where " + strSQLWhere);
//                sAdapter.DeleteCommand = new SqlCommand(delString.ToString(), conn);

//                conn.Open();
//                sAdapter.DeleteCommand.ExecuteNonQuery();
//                conn.Close();

//            }
//            catch (System.Exception EX)
//            {
//                System.Windows.Forms.MessageBox.Show(EX.Message.Replace("'", ""));
//            }
//            finally
//            {
//                if (conn.State == ConnectionState.Open)
//                {
//                    conn.Close();
//                }
//            }
//        }


//        /// <summary>
//        ///  刪除--依PrimaryKey刪除資料
//        /// </summary>
//        /// <param name="PrimaryKey"></param>
//        public void Delete(int PrimaryKey)
//        {
//            try
//            {
//                StringBuilder delString = new StringBuilder("DELETE FROM LinksT where LINKEy=@LINKEy ");
//                sAdapter.DeleteCommand = new SqlCommand(delString.ToString(), conn);
//                for (int i = 0; i < dt.PrimaryKey.Length; i++)
//                {
//                    switch (dt.PrimaryKey[i].DataType.Name)
//                    {
//                        case "Int32":
//                            sAdapter.DeleteCommand.Parameters.Add(dt.PrimaryKey[i].ToString(), SqlDbType.Int);
//                            sAdapter.DeleteCommand.Parameters[dt.PrimaryKey[i].ToString()].Value = PrimaryKey;
//                            break;
//                        case "Int64":
//                            sAdapter.DeleteCommand.Parameters.Add(dt.PrimaryKey[i].ToString(), SqlDbType.BigInt);
//                            sAdapter.DeleteCommand.Parameters[dt.PrimaryKey[i].ToString()].Value = PrimaryKey;
//                            break;
//                    }
//                }
//                conn.Open();
//                sAdapter.DeleteCommand.ExecuteNonQuery();
//                conn.Close();

//            }
//            catch (System.Exception EX)
//            {
//                System.Windows.Forms.MessageBox.Show(EX.Message.Replace("'", ""));
//            }
//            finally
//            {
//                if (conn.State == ConnectionState.Open)
//                {
//                    conn.Close();
//                }
//            }
//        }



//        /// <summary>
//        /// 將刪除資料回溯用的Insert 語法
//        /// </summary>
//        /// <param name='iNo'>Key值</param>
//        /// <returns>[0]Columns , [1]Parameters , [2]TableName</returns>
//        public string[] GetInsertString(int iNo)
//        {
//            DataRow dr = dt.Rows.Find(iNo);
//            StringBuilder sbInsert = new StringBuilder();
//            StringBuilder sbInsertColumns = new StringBuilder();

//            for (int iCol = 0; iCol < dt.Columns.Count; iCol++)
//            {
//                string Column = dt.Columns[iCol].ColumnName;
//                string PKColumn = dt.PrimaryKey[0].ColumnName;

//                if (dr[Column] != DBNull.Value && Column != PKColumn)
//                {
//                    if (sbInsert.ToString().Length > 0)
//                    {
//                        sbInsert.Append(",");
//                        sbInsertColumns.Append(",");
//                    }


//                    if (dt.Columns[iCol].DataType.Name == "Int32" || dt.Columns[iCol].DataType.Name == "Int64" || dt.Columns[iCol].DataType.Name == "Decimal")
//                    {
//                        sbInsert.Append(string.Format("{0}", dr[Column].ToString()));
//                    }
//                    else if (dt.Columns[iCol].DataType.Name == "DateTime")
//                    {
//                        sbInsert.Append(string.Format("'{0}'", ((DateTime)dr[Column]).ToString("yyyy/MM/dd HH:mm")));
//                    }
//                    else if (dt.Columns[iCol].DataType.Name == "Boolean")
//                    {
//                        sbInsert.Append(string.Format("{0}", ((bool)dr[Column]) == true ? 1 : 0));
//                    }
//                    else
//                    {
//                        sbInsert.Append(string.Format("N'{0}'", dr[Column].ToString().Replace("'", "''")));
//                    }

//                    sbInsertColumns.Append(Column);
//                }
//            }

//            string[] Result = { sbInsertColumns.ToString(), sbInsert.ToString(), dt.TableName };
//            return Result;
//        }


//    }
    #endregion
}
