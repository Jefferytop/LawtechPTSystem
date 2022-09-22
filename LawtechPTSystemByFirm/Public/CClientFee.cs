using H3Operator.DBHelper;
using H3Operator.DBModels;
using System;
using System.Collections.Generic;

namespace LawtechPTSystemByFirm.Public
{
    #region CClientFee=================
    /// <summary>
    /// 
    /// </summary>
    [TableMapping("ClientFeeT")]
    public class CClientFee : SysBaseModel
    {
        #region Public property

        private int m_ClientFeeSN;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("ClientFeeSN", DbType = SqlDataType.Int, IsPrimary = true, IsCumulative = true, IsCanNull = false, DataLength = 4)]
        public int ClientFeeSN
        {
            get
            {
                return m_ClientFeeSN;
            }
            set
            {
                m_ClientFeeSN = value;
            }
        }

        private int? m_ApplicantMode;
        /// <summary>
        /// 申請模式 0.對客戶報價  1.對複代報價
        /// </summary>
        [TableColumnSetting("ApplicantMode", DbType = SqlDataType.Int, DataLength = 4)]
        public int? ApplicantMode
        {
            get
            {
                return m_ApplicantMode;
            }
            set
            {
                m_ApplicantMode = value;
            }
        }

        private int? m_ApplicantKey;
        /// <summary>
        /// 
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

        private int? m_SN;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("SN", DbType = SqlDataType.Int, DataLength = 4)]
        public int? SN
        {
            get
            {
                return m_SN;
            }
            set
            {
                m_SN = value;
            }
        }

        private string m_Country;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("Country", DataLength = 100)]
        public string Country
        {
            get
            {
                return m_Country;
            }
            set
            {
                m_Country = value;
            }
        }

        private string m_Kind;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("Kind", DataLength = 20)]
        public string Kind
        {
            get
            {
                return m_Kind;
            }
            set
            {
                m_Kind = value;
            }
        }

        private string m_ProcedureName;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("ProcedureName", DataLength = 1000)]
        public string ProcedureName
        {
            get
            {
                return m_ProcedureName;
            }
            set
            {
                m_ProcedureName = value;
            }
        }

        private string m_ProcedureName_CHS;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("ProcedureName_CHS", DataLength = 4000)]
        public string ProcedureName_CHS
        {
            get
            {
                return m_ProcedureName_CHS;
            }
            set
            {
                m_ProcedureName_CHS = value;
            }
        }

        private string m_ProcedureName_EN;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("ProcedureName_EN", DataLength = 6000)]
        public string ProcedureName_EN
        {
            get
            {
                return m_ProcedureName_EN;
            }
            set
            {
                m_ProcedureName_EN = value;
            }
        }

        private string m_Phase;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("Phase", DataLength = 20)]
        public string Phase
        {
            get
            {
                return m_Phase;
            }
            set
            {
                m_Phase = value;
            }
        }

        private string m_Examtime;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("Examtime", DataLength = 20)]
        public string Examtime
        {
            get
            {
                return m_Examtime;
            }
            set
            {
                m_Examtime = value;
            }
        }

        private decimal? m_GovFeeNT;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("GovFeeNT", DbType = SqlDataType.Decimal, DataLength = 9)]
        public decimal? GovFeeNT
        {
            get
            {
                return m_GovFeeNT;
            }
            set
            {
                m_GovFeeNT = value;
            }
        }

        private string m_Attorney;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("Attorney", DataLength = 40)]
        public string Attorney
        {
            get
            {
                return m_Attorney;
            }
            set
            {
                m_Attorney = value;
            }
        }

        private decimal? m_AttorneyFeeNT;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("AttorneyFeeNT", DbType = SqlDataType.Decimal, DataLength = 9)]
        public decimal? AttorneyFeeNT
        {
            get
            {
                return m_AttorneyFeeNT;
            }
            set
            {
                m_AttorneyFeeNT = value;
            }
        }

        private decimal? m_AttorneyGovFee;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("AttorneyGovFee", DbType = SqlDataType.Decimal, DataLength = 9)]
        public decimal? AttorneyGovFee
        {
            get
            {
                return m_AttorneyGovFee;
            }
            set
            {
                m_AttorneyGovFee = value;
            }
        }

        private decimal? m_MeFee;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("MeFee", DbType = SqlDataType.Decimal, DataLength = 9)]
        public decimal? MeFee
        {
            get
            {
                return m_MeFee;
            }
            set
            {
                m_MeFee = value;
            }
        }

        private decimal? m_QuotaTotal;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("QuotaTotal", DbType = SqlDataType.Decimal, DataLength = 9)]
        public decimal? QuotaTotal
        {
            get
            {
                return m_QuotaTotal;
            }
            set
            {
                m_QuotaTotal = value;
            }
        }

        private string m_SignDocument;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("SignDocument", DataLength = 2400)]
        public string SignDocument
        {
            get
            {
                return m_SignDocument;
            }
            set
            {
                m_SignDocument = value;
            }
        }

        private string m_Remark;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("Remark", DataLength = 8000)]
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

        private string m_Remark_CHS;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("Remark_CHS", DataLength = 8000)]
        public string Remark_CHS
        {
            get
            {
                return m_Remark_CHS;
            }
            set
            {
                m_Remark_CHS = value;
            }
        }

        private string m_Remark_EN;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("Remark_EN", DataLength = 8000)]
        public string Remark_EN
        {
            get
            {
                return m_Remark_EN;
            }
            set
            {
                m_Remark_EN = value;
            }
        }

        private bool? m_LargeEntity;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("LargeEntity", DbType = SqlDataType.Bit, DataLength = 1)]
        public bool? LargeEntity
        {
            get
            {
                return m_LargeEntity;
            }
            set
            {
                m_LargeEntity = value;
            }
        }

        private string m_Creator;
        /// <summary>
        /// 建立者
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
        /// 最後修改者
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
            List<CClientFee> list = new List<CClientFee>();
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
                retObj = orm.ReadListToObjs<CClientFee>(ColumnName + "=@" + ColumnName, ref list, ParList);
            }
            else
            {
                retObj = orm.ReadListToObjs<CClientFee>(ColumnName + "=@" + ColumnName + " and ClientFeeSN<>" + this.ClientFeeSN.ToString(), ref list, ParList);
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
            object retObj = orm.ReadCountRows<CClientFee>(ref iCountRows, strSqlWhere, sqlParameterList: sqlParameterList, CusTableName: strCusTableName);
            return retObj;
        }
        #endregion

        #region 取得一筆資料  ReadOne(ref CClientFee Item, string strCusTableName = ")
        /// <summary>
        /// 取得一筆ClientFeeT資料
        /// </summary>          
        /// <param name="item"></param>   
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>
        /// <returns>0:成功 ; string:失敗</returns>       
        public static object ReadOne(ref CClientFee Item, string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.ReadOneToObj(ref Item, CusTableName: strCusTableName);
            return retObj;
        }
        #endregion

        #region 取得一筆資料 ReadOne(int iPKey, ref CClientFee item, string strCusTableName = "")
        /// <summary>
        /// 取得一筆ClientFeeT資料
        /// </summary>
        /// <param name="iPKey">指定某筆資料的Key值(不適合複合key)</param>     
        /// <param name="item"></param>   
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>
        /// <returns>0:成功 ; string:失敗</returns>       
        public static object ReadOne(int iPKey, ref CClientFee item, string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.ReadOneToObj(iPKey, ref item, CusTableName: strCusTableName);
            return retObj;
        }
        #endregion

        #region 取得一筆ClientFeeT資料 ReadOne(string strSqlWhere, System.Data.SqlClient.SqlParameter[] MySqlParameterList=null, string strCusTableName = "")
        /// <summary>
        /// 取得一筆ClientFeeT資料;如果有多筆符合條件，則只回傳null
        /// </summary>
        /// <param name="strSqlWhere">查詢條件(不用加「where」關鍵字, 可加Sql參數,例如: account=@account)</param>
        /// <param name="MySqlParameterList">Sql參數</param>
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>
        /// <returns>0:成功 ; string:失敗</returns>
        public static object ReadOne(string strSqlWhere, ref CClientFee item, System.Data.SqlClient.SqlParameter[] MySqlParameterList = null, string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            List<CClientFee> itemlist = new List<CClientFee>();
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

        #region 取得多筆CClientFee資料 ReadList
        /// <summary>
        /// 取得多筆 ClientFeeT資料，符合的全部撈出並轉成物件
        /// </summary>
        /// <param name="Items"></param>
        /// <param name="strSqlWhere">SQL條件式 (不用加「where」關鑵字,可加Sql參數,例如: account=@account)</param>
        /// <param name="MySqlParameterList">Sql參數</param>
        /// <param name="strOrderBy">SQL排序式 , 當空值時，預設帶[ CreateDateTime Desc] (不用加「Order by 」關鑵字, 例 "uid desc,createDateTime asc ")</param>
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>      
        /// <returns></returns>
        public static object ReadList(ref List<CClientFee> Items, string strSqlWhere = "", System.Data.SqlClient.SqlParameter[] MySqlParameterList = null, string strOrderBy = "", string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();

            object retObj = orm.ReadListToObjs<CClientFee>(strSqlWhere, ref Items, sqlParameterList: MySqlParameterList, OrderBy: strOrderBy, CusTableName: strCusTableName);

            return retObj;
        }

        #endregion

        #region 取得多筆 ClientFeeT資料 , 指定頁數和頁碼 ReadList
        /// <summary>
        /// 取得多筆 ClientFeeT資料 , 指定頁數和頁碼
        /// </summary>
        /// <param name="PageSize">一頁的筆數</param>
        /// <param name="PageIndex">第 n 頁;從 0 起算，當值小於0時，預設帶0 (0即表示第一頁)</param>
        /// <param name="Items"></param>
        /// <param name="strSqlWhere">SQL條件式 (不用加「where」關鑵字,可加Sql參數,例如: account=@account)</param>
        /// <param name="MySqlParameterList">Sql參數</param>
        /// <param name="strOrderBy">SQL排序式 , 當空值時，預設帶[ CreateDateTime Desc] (不用加「Order by 」關鑵字, 例 "uid desc,createDateTime asc ")</param>
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>       
        /// <returns></returns>
        public static object ReadList(int PageSize, int PageIndex, ref List<CClientFee> Items, string strSqlWhere = "", System.Data.SqlClient.SqlParameter[] MySqlParameterList = null, string strOrderBy = "", string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            int iTotalCountRows = 0;
            object retObj = orm.ReadListToObjsByFetch<CClientFee>(PageSize, PageIndex, strSqlWhere, ref Items, ref iTotalCountRows, sqlParameterList: MySqlParameterList, OrderBy: strOrderBy, CusTableName: strCusTableName);

            return retObj;
        }
        #endregion

        #region 取得多筆 ClientFeeT資料 , 指定頁數和頁碼 ReadList,回傳查詢的總筆數
        /// <summary>
        /// 取得多筆 ClientFeeT資料 , 指定頁數和頁碼,回傳查詢的總筆數
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
        public static object ReadList(int PageSize, int PageIndex, ref List<CClientFee> Items, ref int iTotalRowCount, string strSqlWhere = "", System.Data.SqlClient.SqlParameter[] MySqlParameterList = null, string strOrderBy = "", string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();

            object retObj = orm.ReadListToObjsByFetch<CClientFee>(PageSize, PageIndex, strSqlWhere, ref Items, ref iTotalRowCount, sqlParameterList: MySqlParameterList, OrderBy: strOrderBy, CusTableName: strCusTableName);

            return retObj;
        }
        #endregion

        #region Create
        /// <summary>
        /// 新增ClientFeeT 項目
        /// </summary> 
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>      
        /// <returns>0:成功 ; string:失敗</returns>
        public object Create(string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.InsertByObj<CClientFee>(this, strCusTableName);
            return retObj;
        }
        #endregion

        #region Update
        /// <summary>
        /// 更新 ClientFeeT 項目
        /// </summary>       
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param> 
        /// <returns>0:成功 ; string:失敗</returns>
        public object Update(string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.UpdateObj<CClientFee>(this, strCusTableName);
            return retObj;
        }
        #endregion

        #region Delete

        #region 刪除項目ClientFeeT Delete()
        /// <summary>
        /// 刪除項目ClientFeeT
        /// </summary>  
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>
        /// <returns></returns>   
        public object Delete(string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.DeleteObj<CClientFee>(this, strCusTableName);
            return retObj;
        }
        #endregion

        #region 刪除項目ClientFeeT Delete(int iPKey)
        /// <summary>
        /// 刪除項目ClientFeeT , 指定某一筆主鍵刪除(單筆)
        /// </summary>
        /// <param name="iPKey">指定刪除某筆資料的Key值</param> 
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>      
        /// <returns></returns>
        public object Delete(int iPKey, string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.DeleteObj<CClientFee>(iPKey, strCusTableName);
            return retObj;
        }
        #endregion

        #region 刪除項目ClientFeeT Delete(string strSqlWhere)
        /// <summary>
        /// 刪除項目ClientFeeT ,符合條件刪除(多筆)
        /// </summary>
        /// <param name="strSqlWhere">查詢條件(不用加「where」關鍵字)</param>   
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>    
        /// <returns></returns>
        public object Delete(string strSqlWhere, string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.DeleteObj<CClientFee>(strSqlWhere, strCusTableName);
            return retObj;
        }
        #endregion

        #endregion

        #endregion
    }
    #endregion =================
}
