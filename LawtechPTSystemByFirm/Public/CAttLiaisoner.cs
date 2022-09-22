using H3Operator.DBHelper;
using H3Operator.DBModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawtechPTSystemByFirm.Public
{
    #region CAttLiaisoner=================
    /// <summary>
    /// 事務所連絡人資料表
    /// </summary>
    [TableMapping("AttLiaisonerT")]
    public class CAttLiaisoner : SysBaseModel
    {
        #region Public property

        private int m_ALiaisonerKey;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("ALiaisonerKey", DbType = SqlDataType.Int, IsPrimary = true, IsCumulative = true, IsCanNull = false, DataLength = 4)]
        public int ALiaisonerKey
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

        private int m_AttorneyKey;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("AttorneyKey", DbType = SqlDataType.Int, IsCanNull = false, DataLength = 4)]
        public int AttorneyKey
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

        private string m_Liaisoner;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("Liaisoner", DataLength = 1000)]
        public string Liaisoner
        {
            get
            {
                return m_Liaisoner;
            }
            set
            {
                m_Liaisoner = value;
            }
        }

        private string m_Ext;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("Ext", DataLength = 100)]
        public string Ext
        {
            get
            {
                return m_Ext;
            }
            set
            {
                m_Ext = value;
            }
        }

        private string m_Moblephone;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("Moblephone", DataLength = 300)]
        public string Moblephone
        {
            get
            {
                return m_Moblephone;
            }
            set
            {
                m_Moblephone = value;
            }
        }

        private string m_email;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("email", DataLength = 1000)]
        public string email
        {
            get
            {
                return m_email;
            }
            set
            {
                m_email = value;
            }
        }

        private string m_Position;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("Position", DataLength = 1000)]
        public string Position
        {
            get
            {
                return m_Position;
            }
            set
            {
                m_Position = value;
            }
        }

        private string m_Gender;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("Gender", DataLength = 20)]
        public string Gender
        {
            get
            {
                return m_Gender;
            }
            set
            {
                m_Gender = value;
            }
        }

        private int? m_IsWindows;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("IsWindows", DbType = SqlDataType.Int, DataLength = 4)]
        public int? IsWindows
        {
            get
            {
                return m_IsWindows;
            }
            set
            {
                m_IsWindows = value;
            }
        }

        private bool? m_Quit;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("Quit", DbType = SqlDataType.Bit, DataLength = 1)]
        public bool? Quit
        {
            get
            {
                return m_Quit;
            }
            set
            {
                m_Quit = value;
            }
        }

        private string m_Creator;
        /// <summary>
        /// 建立者
        /// </summary>
        [TableColumnSetting("Creator", DataLength = 300)]
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

        private string m_ModifyWorker;
        /// <summary>
        /// 修改者
        /// </summary>
        [TableColumnSetting("ModifyWorker", DataLength = 300)]
        public string ModifyWorker
        {
            get
            {
                return m_ModifyWorker;
            }
            set
            {
                m_ModifyWorker = value;
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
            List<CAttLiaisoner> list = new List<CAttLiaisoner>();
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
                retObj = orm.ReadListToObjs<CAttLiaisoner>(ColumnName + "=@" + ColumnName, ref list, ParList);
            }
            else
            {
                retObj = orm.ReadListToObjs<CAttLiaisoner>(ColumnName + "=@" + ColumnName + " and ALiaisonerKey<>" + this.ALiaisonerKey.ToString(), ref list, ParList);
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

        #region 取得一筆資料  ReadOne(ref CAttLiaisoner Item, string strCusTableName = ")
        /// <summary>
        /// 取得一筆AttLiaisonerT資料
        /// </summary>          
        /// <param name="item"></param>   
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>
        /// <returns>0:成功 ; string:失敗</returns>       
        public static object ReadOne(ref CAttLiaisoner Item, string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.ReadOneToObj(ref Item, CusTableName: strCusTableName);
            return retObj;
        }
        #endregion

        #region 取得一筆資料 ReadOne(int iPKey, ref DB_MenuRoleTModel item, string strCusTableName = "")
        /// <summary>
        /// 取得一筆AttLiaisonerT資料
        /// </summary>
        /// <param name="iPKey">指定某筆資料的Key值(不適合複合key)</param>     
        /// <param name="item"></param>   
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>
        /// <returns>0:成功 ; string:失敗</returns>       
        public static object ReadOne(int iPKey, ref CAttLiaisoner item, string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.ReadOneToObj(iPKey, ref item, CusTableName: strCusTableName);
            return retObj;
        }
        #endregion

        #region 取得一筆AttLiaisonerT資料 ReadOne(string strSqlWhere, System.Data.SqlClient.SqlParameter[] MySqlParameterList=null, string strCusTableName = "")
        /// <summary>
        /// 取得一筆AttLiaisonerT資料;如果有多筆符合條件，則只回傳null
        /// </summary>
        /// <param name="strSqlWhere">查詢條件(不用加「where」關鍵字, 可加Sql參數,例如: account=@account)</param>
        /// <param name="MySqlParameterList">Sql參數</param>
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>
        /// <returns>0:成功 ; string:失敗</returns>
        public static object ReadOne(string strSqlWhere, ref CAttLiaisoner item, System.Data.SqlClient.SqlParameter[] MySqlParameterList = null, string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            List<CAttLiaisoner> itemlist = new List<CAttLiaisoner>();
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

        #region 取得多筆CAttLiaisoner資料 ReadList
        /// <summary>
        /// 取得多筆 AttLiaisonerT資料 
        /// </summary>
        /// <param name="Items"></param>
        /// <param name="strSqlWhere">SQL條件式 (不用加「where」關鑵字,可加Sql參數,例如: account=@account)</param>
        /// <param name="MySqlParameterList">Sql參數</param>
        /// <param name="strOrderBy">SQL排序式 , 當空值時，預設帶[ CreateDateTime Desc] (不用加「Order by 」關鑵字, 例 "uid desc,createDateTime asc ")</param>
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>      
        /// <returns></returns>
        public static object ReadList(ref List<CAttLiaisoner> Items, string strSqlWhere = "", System.Data.SqlClient.SqlParameter[] MySqlParameterList = null, string strOrderBy = "", string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();

            object retObj = orm.ReadListToObjs<CAttLiaisoner>(strSqlWhere, ref Items, sqlParameterList: MySqlParameterList, OrderBy: strOrderBy, CusTableName: strCusTableName);

            return retObj;
        }

        #endregion

        #region 取得多筆 AttLiaisonerT資料 , 指定頁數和頁碼 ReadList
        /// <summary>
        /// 取得多筆 AttLiaisonerT資料 , 指定頁數和頁碼
        /// </summary>
        /// <param name="PageSize">一頁的筆數</param>
        /// <param name="PageIndex">第 n 頁</param>
        /// <param name="Items"></param>
        /// <param name="strSqlWhere">SQL條件式 (不用加「where」關鑵字,可加Sql參數,例如: account=@account)</param>
        /// <param name="MySqlParameterList">Sql參數</param>
        /// <param name="strOrderBy">SQL排序式 , 當空值時，預設帶[ CreateDateTime Desc] (不用加「Order by 」關鑵字, 例 "uid desc,createDateTime asc ")</param>
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>       
        /// <returns></returns>
        public static object ReadList(int PageSize, int PageIndex, ref List<CAttLiaisoner> Items, string strSqlWhere = "", System.Data.SqlClient.SqlParameter[] MySqlParameterList = null, string strOrderBy = "", string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();

            object retObj = orm.ReadListToObjs<CAttLiaisoner>(PageSize, PageIndex, strSqlWhere, ref Items, sqlParameterList: MySqlParameterList, OrderBy: strOrderBy, CusTableName: strCusTableName);

            return retObj;
        }
        #endregion

        #region Create
        /// <summary>
        /// 新增AttLiaisonerT 項目
        /// </summary> 
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>      
        /// <returns>0:成功 ; string:失敗</returns>
        public object Create(string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.InsertByObj<CAttLiaisoner>(this, strCusTableName);
            return retObj;
        }
        #endregion

        #region Update
        /// <summary>
        /// 更新 AttLiaisonerT 項目
        /// </summary>       
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param> 
        /// <returns>0:成功 ; string:失敗</returns>
        public object Update(string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.UpdateObj<CAttLiaisoner>(this, strCusTableName);
            return retObj;
        }
        #endregion

        #region Delete

        #region 刪除項目AttLiaisonerT Delete()
        /// <summary>
        /// 刪除項目AttLiaisonerT
        /// </summary>  
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>
        /// <returns></returns>   
        public object Delete(string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.DeleteObj<CAttLiaisoner>(this, strCusTableName);
            return retObj;
        }
        #endregion

        #region 刪除項目AttLiaisonerT Delete(int iPKey)
        /// <summary>
        /// 刪除項目AttLiaisonerT , 指定某一筆主鍵刪除(單筆)
        /// </summary>
        /// <param name="iPKey">指定刪除某筆資料的Key值</param> 
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>      
        /// <returns></returns>
        public object Delete(int iPKey, string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.DeleteObj<CAttLiaisoner>(iPKey, strCusTableName);
            return retObj;
        }
        #endregion

        #region 刪除項目AttLiaisonerT Delete(string strSqlWhere)
        /// <summary>
        /// 刪除項目AttLiaisonerT ,符合條件刪除(多筆)
        /// </summary>
        /// <param name="strSqlWhere">查詢條件(不用加「where」關鍵字)</param>   
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>    
        /// <returns></returns>
        public object Delete(string strSqlWhere, string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.DeleteObj<CAttLiaisoner>(strSqlWhere, strCusTableName);
            return retObj;
        }
        #endregion

        #endregion

        #endregion
    }
    #endregion =================
}
