using H3Operator.DBHelper;
using H3Operator.DBModels;
using System.Collections.Generic;

namespace LawtechPTSystem.Public
{
    #region CAttorney=================
    /// <summary>
    /// 
    /// </summary>
    [TableMapping("AttorneyT")]
    public class CAttorney : SysBaseModel
    {
        #region Public property

        private int m_AttorneyKey;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("AttorneyKey", DbType = SqlDataType.Int, IsPrimary = true, IsCumulative = true, IsCanNull = false, DataLength = 4)]
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

        private string m_AttorneySymbol;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("AttorneySymbol", DataLength = 40)]
        public string AttorneySymbol
        {
            get
            {
                return m_AttorneySymbol;
            }
            set
            {
                m_AttorneySymbol = value;
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

        private string m_AttorneyFirm;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("AttorneyFirm", DataLength = 600)]
        public string AttorneyFirm
        {
            get
            {
                return m_AttorneyFirm;
            }
            set
            {
                m_AttorneyFirm = value;
            }
        }

        private string m_ID;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("ID", DataLength = 40)]
        public string ID
        {
            get
            {
                return m_ID;
            }
            set
            {
                m_ID = value;
            }
        }

        private string m_Principal;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("Principal", DataLength = 100)]
        public string Principal
        {
            get
            {
                return m_Principal;
            }
            set
            {
                m_Principal = value;
            }
        }

        private string m_CountrySymbol;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("CountrySymbol", DataLength = 100)]
        public string CountrySymbol
        {
            get
            {
                return m_CountrySymbol;
            }
            set
            {
                m_CountrySymbol = value;
            }
        }

        private string m_Addr;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("Addr", DataLength = 300)]
        public string Addr
        {
            get
            {
                return m_Addr;
            }
            set
            {
                m_Addr = value;
            }
        }

        private string m_TEL;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("TEL", DataLength = 100)]
        public string TEL
        {
            get
            {
                return m_TEL;
            }
            set
            {
                m_TEL = value;
            }
        }

        private string m_FAX;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("FAX", DataLength = 100)]
        public string FAX
        {
            get
            {
                return m_FAX;
            }
            set
            {
                m_FAX = value;
            }
        }

        private string m_Email;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("Email", DataLength = 1000)]
        public string Email
        {
            get
            {
                return m_Email;
            }
            set
            {
                m_Email = value;
            }
        }

        private string m_WebSite;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("WebSite", DataLength = 1000)]
        public string WebSite
        {
            get
            {
                return m_WebSite;
            }
            set
            {
                m_WebSite = value;
            }
        }

        private string m_BankAccount;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("BankAccount", DataLength = 200)]
        public string BankAccount
        {
            get
            {
                return m_BankAccount;
            }
            set
            {
                m_BankAccount = value;
            }
        }

        private string m_BankAccountNo;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("BankAccountNo", DataLength = 100)]
        public string BankAccountNo
        {
            get
            {
                return m_BankAccountNo;
            }
            set
            {
                m_BankAccountNo = value;
            }
        }

        private string m_Bank;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("Bank", DataLength = 200)]
        public string Bank
        {
            get
            {
                return m_Bank;
            }
            set
            {
                m_Bank = value;
            }
        }

        private string m_Remark;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("Remark", DataLength = 3000)]
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

        private int? m_MotherAttorney;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("MotherAttorney", DbType = SqlDataType.Int, DataLength = 4)]
        public int? MotherAttorney
        {
            get
            {
                return m_MotherAttorney;
            }
            set
            {
                m_MotherAttorney = value;
            }
        }

        private string m_Payment;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("Payment", DataLength = 200)]
        public string Payment
        {
            get
            {
                return m_Payment;
            }
            set
            {
                m_Payment = value;
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
            List<CAttorney> list = new List<CAttorney>();
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
                retObj = orm.ReadListToObjs<CAttorney>(ColumnName + "=@" + ColumnName, ref list, ParList);
            }
            else
            {
                retObj = orm.ReadListToObjs<CAttorney>(ColumnName + "=@" + ColumnName + " and AttorneyKey<>" + this.AttorneyKey.ToString(), ref list, ParList);
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

        #region 取得一筆資料  ReadOne(ref CAttorney Item, string strCusTableName = ")
        /// <summary>
        /// 取得一筆AttorneyT資料
        /// </summary>          
        /// <param name="item"></param>   
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>
        /// <returns>0:成功 ; string:失敗</returns>       
        public static object ReadOne(ref CAttorney Item, string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.ReadOneToObj(ref Item, CusTableName: strCusTableName);
            return retObj;
        }
        #endregion

        #region 取得一筆資料 ReadOne(int iPKey, ref DB_MenuRoleTModel item, string strCusTableName = "")
        /// <summary>
        /// 取得一筆AttorneyT資料
        /// </summary>
        /// <param name="iPKey">指定某筆資料的Key值(不適合複合key)</param>     
        /// <param name="item"></param>   
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>
        /// <returns>0:成功 ; string:失敗</returns>       
        public static object ReadOne(int iPKey, ref CAttorney item, string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.ReadOneToObj(iPKey, ref item, CusTableName: strCusTableName);
            return retObj;
        }
        #endregion

        #region 取得一筆AttorneyT資料 ReadOne(string strSqlWhere, System.Data.SqlClient.SqlParameter[] MySqlParameterList=null, string strCusTableName = "")
        /// <summary>
        /// 取得一筆AttorneyT資料;如果有多筆符合條件，則只回傳null
        /// </summary>
        /// <param name="strSqlWhere">查詢條件(不用加「where」關鍵字, 可加Sql參數,例如: account=@account)</param>
        /// <param name="MySqlParameterList">Sql參數</param>
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>
        /// <returns>0:成功 ; string:失敗</returns>
        public static object ReadOne(string strSqlWhere, ref CAttorney item, System.Data.SqlClient.SqlParameter[] MySqlParameterList = null, string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            List<CAttorney> itemlist = new List<CAttorney>();
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

        #region 取得多筆CAttorney資料 ReadList
        /// <summary>
        /// 取得多筆 AttorneyT資料 
        /// </summary>
        /// <param name="Items"></param>
        /// <param name="strSqlWhere">SQL條件式 (不用加「where」關鑵字,可加Sql參數,例如: account=@account)</param>
        /// <param name="MySqlParameterList">Sql參數</param>
        /// <param name="strOrderBy">SQL排序式 , 當空值時，預設帶[ CreateDateTime Desc] (不用加「Order by 」關鑵字, 例 "uid desc,createDateTime asc ")</param>
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>      
        /// <returns></returns>
        public static object ReadList(ref List<CAttorney> Items, string strSqlWhere = "", System.Data.SqlClient.SqlParameter[] MySqlParameterList = null, string strOrderBy = "", string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();

            object retObj = orm.ReadListToObjs<CAttorney>(strSqlWhere, ref Items, sqlParameterList: MySqlParameterList, OrderBy: strOrderBy, CusTableName: strCusTableName);

            return retObj;
        }

        #endregion

        #region 取得多筆 AttorneyT資料 , 指定頁數和頁碼 ReadList
        /// <summary>
        /// 取得多筆 AttorneyT資料 , 指定頁數和頁碼
        /// </summary>
        /// <param name="PageSize">一頁的筆數</param>
        /// <param name="PageIndex">第 n 頁</param>
        /// <param name="Items"></param>
        /// <param name="strSqlWhere">SQL條件式 (不用加「where」關鑵字,可加Sql參數,例如: account=@account)</param>
        /// <param name="MySqlParameterList">Sql參數</param>
        /// <param name="strOrderBy">SQL排序式 , 當空值時，預設帶[ CreateDateTime Desc] (不用加「Order by 」關鑵字, 例 "uid desc,createDateTime asc ")</param>
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>       
        /// <returns></returns>
        public static object ReadList(int PageSize, int PageIndex, ref List<CAttorney> Items, string strSqlWhere = "", System.Data.SqlClient.SqlParameter[] MySqlParameterList = null, string strOrderBy = "", string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();

            object retObj = orm.ReadListToObjs<CAttorney>(PageSize, PageIndex, strSqlWhere, ref Items, sqlParameterList: MySqlParameterList, OrderBy: strOrderBy, CusTableName: strCusTableName);

            return retObj;
        }
        #endregion

        #region Create
        /// <summary>
        /// 新增AttorneyT 項目
        /// </summary> 
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>      
        /// <returns>0:成功 ; string:失敗</returns>
        public object Create(string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.InsertByObj<CAttorney>(this, strCusTableName);
            return retObj;
        }
        #endregion

        #region Update
        /// <summary>
        /// 更新 AttorneyT 項目
        /// </summary>       
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param> 
        /// <returns>0:成功 ; string:失敗</returns>
        public object Update(string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.UpdateObj<CAttorney>(this, strCusTableName);
            return retObj;
        }
        #endregion

        #region Delete

        #region 刪除項目AttorneyT Delete()
        /// <summary>
        /// 刪除項目AttorneyT
        /// </summary>  
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>
        /// <returns></returns>   
        public object Delete(string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.DeleteObj<CAttorney>(this, strCusTableName);
            return retObj;
        }
        #endregion

        #region 刪除項目AttorneyT Delete(int iPKey)
        /// <summary>
        /// 刪除項目AttorneyT , 指定某一筆主鍵刪除(單筆)
        /// </summary>
        /// <param name="iPKey">指定刪除某筆資料的Key值</param> 
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>      
        /// <returns></returns>
        public object Delete(int iPKey, string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.DeleteObj<CAttorney>(iPKey, strCusTableName);
            return retObj;
        }
        #endregion

        #region 刪除項目AttorneyT Delete(string strSqlWhere)
        /// <summary>
        /// 刪除項目AttorneyT ,符合條件刪除(多筆)
        /// </summary>
        /// <param name="strSqlWhere">查詢條件(不用加「where」關鍵字)</param>   
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>    
        /// <returns></returns>
        public object Delete(string strSqlWhere, string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.DeleteObj<CAttorney>(strSqlWhere, strCusTableName);
            return retObj;
        }
        #endregion

        #endregion

        #endregion
    }
    #endregion =================
}
