using H3Operator.DBHelper;
using H3Operator.DBModels;
using System.Collections.Generic;

namespace LawtechPTSystemByFirm.Public
{
    #region CTrademarkClassSelect=================
    /// <summary>
    /// 
    /// </summary>
    [TableMapping("TrademarkClassSelectT")]
    public class CTrademarkClassSelect : SysBaseModel
    {
        #region Public property

        private int m_TMClassSelectID;
        /// <summary>
        /// 商標所選分類表 PK
        /// </summary>
        [TableColumnSetting("TMClassSelectID", DbType = SqlDataType.Int, IsPrimary = true, IsCumulative = true, IsCanNull = false, DataLength = 4)]
        public int TMClassSelectID
        {
            get
            {
                return m_TMClassSelectID;
            }
            set
            {
                m_TMClassSelectID = value;
            }
        }

        private int? m_TMClassID;
        /// <summary>
        /// 商標分類 ID
        /// </summary>
        [TableColumnSetting("TMClassID", DbType = SqlDataType.Int, DataLength = 4)]
        public int? TMClassID
        {
            get
            {
                return m_TMClassID;
            }
            set
            {
                m_TMClassID = value;
            }
        }

        private int? m_TrademarkID;
        /// <summary>
        /// 商標案 ID
        /// </summary>
        [TableColumnSetting("TrademarkID", DbType = SqlDataType.Int, DataLength = 4)]
        public int? TrademarkID
        {
            get
            {
                return m_TrademarkID;
            }
            set
            {
                m_TrademarkID = value;
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
            List<CTrademarkClassSelect> list = new List<CTrademarkClassSelect>();
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
                retObj = orm.ReadListToObjs<CTrademarkClassSelect>(ColumnName + "=@" + ColumnName, ref list, ParList);
            }
            else
            {
                retObj = orm.ReadListToObjs<CTrademarkClassSelect>(ColumnName + "=@" + ColumnName + " and TMClassSelectID<>" + this.TMClassSelectID.ToString(), ref list, ParList);
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

        #region 取得一筆資料  ReadOne(ref CTrademarkClassSelect Item, string strCusTableName = ")
        /// <summary>
        /// 取得一筆TrademarkClassSelectT資料
        /// </summary>          
        /// <param name="item"></param>   
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>
        /// <returns>0:成功 ; string:失敗</returns>       
        public static object ReadOne(ref CTrademarkClassSelect Item, string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.ReadOneToObj(ref Item, CusTableName: strCusTableName);
            return retObj;
        }
        #endregion

        #region 取得一筆資料 ReadOne(int iPKey, ref CTrademarkClassSelect item, string strCusTableName = "")
        /// <summary>
        /// 取得一筆TrademarkClassSelectT資料
        /// </summary>
        /// <param name="iPKey">指定某筆資料的Key值(不適合複合key)</param>     
        /// <param name="item"></param>   
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>
        /// <returns>0:成功 ; string:失敗</returns>       
        public static object ReadOne(int iPKey, ref CTrademarkClassSelect item, string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.ReadOneToObj(iPKey, ref item, CusTableName: strCusTableName);
            return retObj;
        }
        #endregion

        #region 取得一筆TrademarkClassSelectT資料 ReadOne(string strSqlWhere, System.Data.SqlClient.SqlParameter[] MySqlParameterList=null, string strCusTableName = "")
        /// <summary>
        /// 取得一筆TrademarkClassSelectT資料;如果有多筆符合條件，則只回傳null
        /// </summary>
        /// <param name="strSqlWhere">查詢條件(不用加「where」關鍵字, 可加Sql參數,例如: account=@account)</param>
        /// <param name="MySqlParameterList">Sql參數</param>
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>
        /// <returns>0:成功 ; string:失敗</returns>
        public static object ReadOne(string strSqlWhere, ref CTrademarkClassSelect item, System.Data.SqlClient.SqlParameter[] MySqlParameterList = null, string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            List<CTrademarkClassSelect> itemlist = new List<CTrademarkClassSelect>();
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

        #region 取得多筆CTrademarkClassSelect資料 ReadList
        /// <summary>
        /// 取得多筆 TrademarkClassSelectT資料 
        /// </summary>
        /// <param name="Items"></param>
        /// <param name="strSqlWhere">SQL條件式 (不用加「where」關鑵字,可加Sql參數,例如: account=@account)</param>
        /// <param name="MySqlParameterList">Sql參數</param>
        /// <param name="strOrderBy">SQL排序式 , 當空值時，預設帶[ CreateDateTime Desc] (不用加「Order by 」關鑵字, 例 "uid desc,createDateTime asc ")</param>
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>      
        /// <returns></returns>
        public static object ReadList(ref List<CTrademarkClassSelect> Items, string strSqlWhere = "", System.Data.SqlClient.SqlParameter[] MySqlParameterList = null, string strOrderBy = "", string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();

            object retObj = orm.ReadListToObjs<CTrademarkClassSelect>(strSqlWhere, ref Items, sqlParameterList: MySqlParameterList, OrderBy: strOrderBy, CusTableName: strCusTableName);

            return retObj;
        }

        #endregion

        #region 取得多筆 TrademarkClassSelectT資料 , 指定頁數和頁碼 ReadList
        /// <summary>
        /// 取得多筆 TrademarkClassSelectT資料 , 指定頁數和頁碼
        /// </summary>
        /// <param name="PageSize">一頁的筆數</param>
        /// <param name="PageIndex">第 n 頁</param>
        /// <param name="Items"></param>
        /// <param name="strSqlWhere">SQL條件式 (不用加「where」關鑵字,可加Sql參數,例如: account=@account)</param>
        /// <param name="MySqlParameterList">Sql參數</param>
        /// <param name="strOrderBy">SQL排序式 , 當空值時，預設帶[ CreateDateTime Desc] (不用加「Order by 」關鑵字, 例 "uid desc,createDateTime asc ")</param>
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>       
        /// <returns></returns>
        public static object ReadList(int PageSize, int PageIndex, ref List<CTrademarkClassSelect> Items, string strSqlWhere = "", System.Data.SqlClient.SqlParameter[] MySqlParameterList = null, string strOrderBy = "", string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();

            object retObj = orm.ReadListToObjs<CTrademarkClassSelect>(PageSize, PageIndex, strSqlWhere, ref Items, sqlParameterList: MySqlParameterList, OrderBy: strOrderBy, CusTableName: strCusTableName);

            return retObj;
        }
        #endregion

        #region Create
        /// <summary>
        /// 新增TrademarkClassSelectT 項目
        /// </summary> 
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>      
        /// <returns>0:成功 ; string:失敗</returns>
        public object Create(string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.InsertByObj<CTrademarkClassSelect>(this, strCusTableName);
            return retObj;
        }
        #endregion

        #region Update
        /// <summary>
        /// 更新 TrademarkClassSelectT 項目
        /// </summary>       
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param> 
        /// <returns>0:成功 ; string:失敗</returns>
        public object Update(string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.UpdateObj<CTrademarkClassSelect>(this, strCusTableName);
            return retObj;
        }
        #endregion

        #region Delete

        #region 刪除項目TrademarkClassSelectT Delete()
        /// <summary>
        /// 刪除項目TrademarkClassSelectT
        /// </summary>  
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>
        /// <returns></returns>   
        public object Delete(string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.DeleteObj<CTrademarkClassSelect>(this, strCusTableName);
            return retObj;
        }
        #endregion

        #region 刪除項目TrademarkClassSelectT Delete(int iPKey)
        /// <summary>
        /// 刪除項目TrademarkClassSelectT , 指定某一筆主鍵刪除(單筆)
        /// </summary>
        /// <param name="iPKey">指定刪除某筆資料的Key值</param> 
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>      
        /// <returns></returns>
        public object Delete(int iPKey, string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.DeleteObj<CTrademarkClassSelect>(iPKey, strCusTableName);
            return retObj;
        }
        #endregion

        #region 刪除項目TrademarkClassSelectT Delete(string strSqlWhere)
        /// <summary>
        /// 刪除項目TrademarkClassSelectT ,符合條件刪除(多筆)
        /// </summary>
        /// <param name="strSqlWhere">查詢條件(不用加「where」關鍵字)</param>   
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>    
        /// <returns></returns>
        public object Delete(string strSqlWhere, string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.DeleteObj<CTrademarkClassSelect>(strSqlWhere, strCusTableName);
            return retObj;
        }
        #endregion

        #endregion

        #endregion
    }
    #endregion =================
}
