using H3Operator.DBHelper;
using H3Operator.DBModels;
using System.Collections.Generic;
using System.Data;

namespace LawtechPTSystem.Public
{
    #region CAcountingFirmT=================
    /// <summary>
    /// 入帳
    /// </summary>
    [TableMapping("AcountingFirmT")]
    public class CAcountingFirmT : SysBaseModel
    {
        #region Public property

        private int m_AcountingFirmKey;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("AcountingFirmKey", DbType = SqlDataType.Int, IsPrimary = true, IsCumulative = true, IsCanNull = false, DataLength = 4)]
        public int AcountingFirmKey
        {
            get
            {
                return m_AcountingFirmKey;
            }
            set
            {
                m_AcountingFirmKey = value;
            }
        }

        private string m_AcountingFirm;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("AcountingFirm", DataLength = 100)]
        public string AcountingFirm
        {
            get
            {
                return m_AcountingFirm;
            }
            set
            {
                m_AcountingFirm = value;
            }
        }

        private string m_AcountingFirmName;
        /// <summary>
        /// 入帳公司名稱
        /// </summary>
        [TableColumnSetting("AcountingFirmName", DataLength = 1000)]
        public string AcountingFirmName
        {
            get
            {
                return m_AcountingFirmName;
            }
            set
            {
                m_AcountingFirmName = value;
            }
        }

        private string m_LogoUrl;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("LogoUrl", DataLength = 1000)]
        public string LogoUrl
        {
            get
            {
                return m_LogoUrl;
            }
            set
            {
                m_LogoUrl = value;
            }
        }

        private int? m_Sort;
        /// <summary>
        /// 排序
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

        private bool? m_IsEnable;
        /// <summary>
        /// 是否啟用
        /// </summary>
        [TableColumnSetting("IsEnable", DbType = SqlDataType.Bit, DataLength = 1)]
        public bool? IsEnable
        {
            get
            {
                return m_IsEnable;
            }
            set
            {
                m_IsEnable = value;
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

        private string m_Quotation_Subject;
        /// <summary>
        /// 報價單-主旨
        /// </summary>
        [TableColumnSetting("Quotation_Subject", DataLength = 1000)]
        public string Quotation_Subject
        {
            get
            {
                return m_Quotation_Subject;
            }
            set
            {
                m_Quotation_Subject = value;
            }
        }

        private string m_Quotation_Content;
        /// <summary>
        /// 報價單-內文
        /// </summary>
        [TableColumnSetting("Quotation_Content", DataLength = 6000)]
        public string Quotation_Content
        {
            get
            {
                return m_Quotation_Content;
            }
            set
            {
                m_Quotation_Content = value;
            }
        }

        private string m_Quotation_Explain;
        /// <summary>
        /// 報價單-說明
        /// </summary>
        [TableColumnSetting("Quotation_Explain")]
        public string Quotation_Explain
        {
            get
            {
                return m_Quotation_Explain;
            }
            set
            {
                m_Quotation_Explain = value;
            }
        }

        private string m_Fee_PaymentInstructions;
        /// <summary>
        /// 請款單-付款說明
        /// </summary>
        [TableColumnSetting("Fee_PaymentInstructions")]
        public string Fee_PaymentInstructions
        {
            get
            {
                return m_Fee_PaymentInstructions;
            }
            set
            {
                m_Fee_PaymentInstructions = value;
            }
        }

        private string m_Fee_Footer;
        /// <summary>
        /// 請款單-頁尾
        /// </summary>
        [TableColumnSetting("Fee_Footer", DataLength = 1000)]
        public string Fee_Footer
        {
            get
            {
                return m_Fee_Footer;
            }
            set
            {
                m_Fee_Footer = value;
            }
        }

        private string m_Fee_Footer1;
        /// <summary>
        /// 請款單-頁尾1
        /// </summary>
        [TableColumnSetting("Fee_Footer1", DataLength = 1000)]
        public string Fee_Footer1
        {
            get
            {
                return m_Fee_Footer1;
            }
            set
            {
                m_Fee_Footer1 = value;
            }
        }

        private string m_Receipt_PaymentInstructions;
        /// <summary>
        /// 收據-備住
        /// </summary>
        [TableColumnSetting("Receipt_PaymentInstructions")]
        public string Receipt_PaymentInstructions
        {
            get
            {
                return m_Receipt_PaymentInstructions;
            }
            set
            {
                m_Receipt_PaymentInstructions = value;
            }
        }

        private string m_Receipt_Footer;
        /// <summary>
        /// 收據-頁尾
        /// </summary>
        [TableColumnSetting("Receipt_Footer", DataLength = 1000)]
        public string Receipt_Footer
        {
            get
            {
                return m_Receipt_Footer;
            }
            set
            {
                m_Receipt_Footer = value;
            }
        }

        private string m_Receipt_Footer1;
        /// <summary>
        /// 收據-頁尾1
        /// </summary>
        [TableColumnSetting("Receipt_Footer1", DataLength = 1000)]
        public string Receipt_Footer1
        {
            get
            {
                return m_Receipt_Footer1;
            }
            set
            {
                m_Receipt_Footer1 = value;
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
            List<CAcountingFirmT> list = new List<CAcountingFirmT>();
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
                retObj = orm.ReadListToObjs<CAcountingFirmT>(ColumnName + "=@" + ColumnName, ref list, ParList);
            }
            else
            {
                retObj = orm.ReadListToObjs<CAcountingFirmT>(ColumnName + "=@" + ColumnName + " and AcountingFirmKey<>" + this.AcountingFirmKey.ToString(), ref list, ParList);
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
            object retObj = orm.ReadCountRows<CAcountingFirmT>(ref iCountRows, strSqlWhere, sqlParameterList: sqlParameterList, CusTableName: strCusTableName);
            return retObj;
        }
        #endregion

        #region 取得一筆資料  ReadOne(ref CAcountingFirmT Item, string strCusTableName = ")
        /// <summary>
        /// 取得一筆AcountingFirmT資料
        /// </summary>          
        /// <param name="Item"></param>   
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>
        /// <returns>0:成功 ; string:失敗</returns>       
        public static object ReadOne(ref CAcountingFirmT Item, string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.ReadOneToObj(ref Item, CusTableName: strCusTableName);
            return retObj;
        }
        #endregion

        #region 取得一筆資料 ReadOne(int iPKey, ref CAcountingFirmT item, string strCusTableName = "")
        /// <summary>
        /// 取得一筆AcountingFirmT資料
        /// </summary>
        /// <param name="iPKey">指定某筆資料的Key值(不適合複合key)</param>     
        /// <param name="item"></param>   
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>
        /// <returns>0:成功 ; string:失敗</returns>       
        public static object ReadOne(int iPKey, ref CAcountingFirmT item, string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.ReadOneToObj(iPKey, ref item, CusTableName: strCusTableName);
            return retObj;
        }
        #endregion

        #region 取得一筆AcountingFirmT資料 ReadOne(string strSqlWhere, System.Data.SqlClient.SqlParameter[] MySqlParameterList=null, string strCusTableName = "")
        /// <summary>
        /// 取得一筆AcountingFirmT資料;如果有多筆符合條件，則只回傳null
        /// </summary>
        /// <param name="strSqlWhere">查詢條件(不用加「where」關鍵字, 可加Sql參數,例如: account=@account)</param>
        /// <param name="item"></param>
        /// <param name="MySqlParameterList">Sql參數</param>
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>
        /// <returns>0:成功 ; string:失敗</returns>
        public static object ReadOne(string strSqlWhere, ref CAcountingFirmT item, System.Data.SqlClient.SqlParameter[] MySqlParameterList = null, string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            List<CAcountingFirmT> itemlist = new List<CAcountingFirmT>();
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

        #region 取得多筆CAcountingFirmT資料 ReadList 
        /// <summary>
        /// 取得多筆 AcountingFirmT資料，符合的全部撈出並轉成物件
        /// </summary>
        /// <param name="Items"></param>
        /// <param name="strSqlWhere">SQL條件式 (不用加「where」關鑵字,可加Sql參數,例如: account=@account)</param>
        /// <param name="MySqlParameterList">Sql參數</param>
        /// <param name="strOrderBy">SQL排序式 , 當空值時，預設帶[ CreateDateTime Desc] (不用加「Order by 」關鑵字, 例 "uid desc,createDateTime asc ")</param>
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>      
        /// <returns></returns>
        public static object ReadList(ref List<CAcountingFirmT> Items, string strSqlWhere = "", System.Data.SqlClient.SqlParameter[] MySqlParameterList = null, string strOrderBy = "", string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();

            object retObj = orm.ReadListToObjs<CAcountingFirmT>(strSqlWhere, ref Items, sqlParameterList: MySqlParameterList, OrderBy: strOrderBy, CusTableName: strCusTableName);

            return retObj;
        }

        #endregion

        #region 取得多筆CAcountingFirmT資料 ReadList DataTable
        /// <summary>
        /// 取得多筆 AcountingFirmT DataTable資料
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

            object retObj = orm.ReadListToObjs<CAcountingFirmT>(strSqlWhere, ref Items, sqlParameterList: MySqlParameterList, OrderBy: strOrderBy, CusTableName: strCusTableName);

            return retObj;
        }

        #endregion

        #region 取得多筆 AcountingFirmT資料 , 指定頁數和頁碼 ReadList
        /// <summary>
        /// 取得多筆 AcountingFirmT資料 , 指定頁數和頁碼
        /// </summary>
        /// <param name="PageSize">一頁的筆數</param>
        /// <param name="PageIndex">第 n 頁;從 0 起算，當值小於0時，預設帶0 (0即表示第一頁)</param>
        /// <param name="Items"></param>
        /// <param name="strSqlWhere">SQL條件式 (不用加「where」關鑵字,可加Sql參數,例如: account=@account)</param>
        /// <param name="MySqlParameterList">Sql參數</param>
        /// <param name="strOrderBy">SQL排序式 , 當空值時，預設帶[ CreateDateTime Desc] (不用加「Order by 」關鑵字, 例 "uid desc,createDateTime asc ")</param>
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>       
        /// <returns></returns>
        public static object ReadList(int PageSize, int PageIndex, ref List<CAcountingFirmT> Items, string strSqlWhere = "", System.Data.SqlClient.SqlParameter[] MySqlParameterList = null, string strOrderBy = "", string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            int iTotalCountRows = 0;
            object retObj = orm.ReadListToObjsByFetch<CAcountingFirmT>(PageSize, PageIndex, strSqlWhere, ref Items, ref iTotalCountRows, sqlParameterList: MySqlParameterList, OrderBy: strOrderBy, CusTableName: strCusTableName);

            return retObj;
        }
        #endregion

        #region 取得多筆 AcountingFirmT資料 , 指定頁數和頁碼 ReadList,回傳查詢的總筆數
        /// <summary>
        /// 取得多筆 AcountingFirmT資料 , 指定頁數和頁碼,回傳查詢的總筆數
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
        public static object ReadList(int PageSize, int PageIndex, ref List<CAcountingFirmT> Items, ref int iTotalRowCount, string strSqlWhere = "", System.Data.SqlClient.SqlParameter[] MySqlParameterList = null, string strOrderBy = "", string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();

            object retObj = orm.ReadListToObjsByFetch<CAcountingFirmT>(PageSize, PageIndex, strSqlWhere, ref Items, ref iTotalRowCount, sqlParameterList: MySqlParameterList, OrderBy: strOrderBy, CusTableName: strCusTableName);

            return retObj;
        }
        #endregion

        #region 取得多筆 AcountingFirmT DataTable資料 , 指定頁數和頁碼 ReadList,回傳查詢的總筆數
        /// <summary>
        /// 取得多筆 AcountingFirmT DataTable 資料 , 指定頁數和頁碼,回傳查詢的總筆數
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

            object retObj = orm.ReadListToObjsByFetch<CAcountingFirmT>(PageSize, PageIndex, strSqlWhere, ref Items, ref iTotalRowCount, sqlParameterList: MySqlParameterList, OrderBy: strOrderBy, CusTableName: strCusTableName);

            return retObj;
        }
        #endregion

        #region Create
        /// <summary>
        /// 新增AcountingFirmT 項目
        /// </summary> 
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>      
        /// <returns>0:成功 ; string:失敗</returns>
        public object Create(string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.InsertByObj<CAcountingFirmT>(this, strCusTableName);
            return retObj;
        }
        #endregion

        #region Update
        /// <summary>
        /// 更新 AcountingFirmT 項目
        /// </summary>       
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param> 
        /// <returns>0:成功 ; string:失敗</returns>
        public object Update(string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.UpdateObj<CAcountingFirmT>(this, strCusTableName);
            return retObj;
        }
        #endregion

        #region Delete

        #region 刪除項目AcountingFirmT Delete()
        /// <summary>
        /// 刪除項目AcountingFirmT
        /// </summary>  
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>
        /// <returns></returns>   
        public object Delete(string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.DeleteObj<CAcountingFirmT>(this, strCusTableName);
            return retObj;
        }
        #endregion

        #region 刪除項目AcountingFirmT Delete(int iPKey)
        /// <summary>
        /// 刪除項目AcountingFirmT , 指定某一筆主鍵刪除(單筆)
        /// </summary>
        /// <param name="iPKey">指定刪除某筆資料的Key值</param> 
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>      
        /// <returns></returns>
        public object Delete(int iPKey, string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.DeleteObj<CAcountingFirmT>(iPKey, strCusTableName);
            return retObj;
        }
        #endregion      

        #region 刪除項目AcountingFirmT Delete(string strSqlWhere)
        /// <summary>
        /// 刪除項目AcountingFirmT ,符合條件刪除(多筆)
        /// </summary>
        /// <param name="strSqlWhere">查詢條件(不用加「where」關鍵字)</param>   
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>    
        /// <returns></returns>
        public object Delete(string strSqlWhere, string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.DeleteObj<CAcountingFirmT>(strSqlWhere, strCusTableName);
            return retObj;
        }
        #endregion

        #endregion

        #endregion
    }
    #endregion =================
}
