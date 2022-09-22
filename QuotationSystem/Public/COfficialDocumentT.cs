using H3Operator.DBHelper;
using H3Operator.DBModels;
using System;
using System.Collections.Generic;
using System.Data;

namespace LawtechPTSystem.Public
{
    #region COfficialDocumentT=================
    /// <summary>
    /// 官方公文管理資料表
    /// </summary>
    [TableMapping("OfficialDocumentT")]
    public class COfficialDocumentT : SysBaseModel
    {
        #region Public property

        private int m_OfficialDocumentKey;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("OfficialDocumentKey", DbType = SqlDataType.Int, IsPrimary = true, IsCumulative = true, IsCanNull = false, DataLength = 4)]
        public int OfficialDocumentKey
        {
            get
            {
                return m_OfficialDocumentKey;
            }
            set
            {
                m_OfficialDocumentKey = value;
            }
        }

        private string m_DocumentNumber;
        /// <summary>
        /// 發文文號
        /// </summary>
        [TableColumnSetting("DocumentNumber", DataLength = 100)]
        public string DocumentNumber
        {
            get
            {
                return m_DocumentNumber;
            }
            set
            {
                m_DocumentNumber = value;
            }
        }

        private string m_TextNumber;
        /// <summary>
        /// 發文字號
        /// </summary>
        [TableColumnSetting("TextNumber", DataLength = 200)]
        public string TextNumber
        {
            get
            {
                return m_TextNumber;
            }
            set
            {
                m_TextNumber = value;
            }
        }

        private string m_NumberType;
        /// <summary>
        /// 案號類別
        /// </summary>
        [TableColumnSetting("NumberType", DataLength = 100)]
        public string NumberType
        {
            get
            {
                return m_NumberType;
            }
            set
            {
                m_NumberType = value;
            }
        }

        private string m_NumberID;
        /// <summary>
        /// 案號
        /// </summary>
        [TableColumnSetting("NumberID", DataLength = 100)]
        public string NumberID
        {
            get
            {
                return m_NumberID;
            }
            set
            {
                m_NumberID = value;
            }
        }

        private string m_ApplicationNo;
        /// <summary>
        /// 申請案號
        /// </summary>
        [TableColumnSetting("ApplicationNo", DataLength = 100)]
        public string ApplicationNo
        {
            get
            {
                return m_ApplicationNo;
            }
            set
            {
                m_ApplicationNo = value;
            }
        }

        private DateTime? m_DeliveryTime;
        /// <summary>
        /// 送達時間
        /// </summary>
        [TableColumnSetting("DeliveryTime", DbType = SqlDataType.DateTime, DataLength = 8)]
        public DateTime? DeliveryTime
        {
            get
            {
                return m_DeliveryTime;
            }
            set
            {
                m_DeliveryTime = value;
            }
        }

        private string m_Summary;
        /// <summary>
        /// 案由
        /// </summary>
        [TableColumnSetting("Summary", DataLength = 300)]
        public string Summary
        {
            get
            {
                return m_Summary;
            }
            set
            {
                m_Summary = value;
            }
        }

        private string m_ProcessingPeriod;
        /// <summary>
        /// 處理期限
        /// </summary>
        [TableColumnSetting("ProcessingPeriod", DataLength = 100)]
        public string ProcessingPeriod
        {
            get
            {
                return m_ProcessingPeriod;
            }
            set
            {
                m_ProcessingPeriod = value;
            }
        }

        private string m_DuringProcessing;
        /// <summary>
        /// 處理期間
        /// </summary>
        [TableColumnSetting("DuringProcessing", DataLength = 100)]
        public string DuringProcessing
        {
            get
            {
                return m_DuringProcessing;
            }
            set
            {
                m_DuringProcessing = value;
            }
        }

        private DateTime? m_SubmissionTime;
        /// <summary>
        /// 簽收時間
        /// </summary>
        [TableColumnSetting("SubmissionTime", DbType = SqlDataType.DateTime, DataLength = 8)]
        public DateTime? SubmissionTime
        {
            get
            {
                return m_SubmissionTime;
            }
            set
            {
                m_SubmissionTime = value;
            }
        }

        private string m_Signer;
        /// <summary>
        /// 簽收人
        /// </summary>
        [TableColumnSetting("Signer", DataLength = 100)]
        public string Signer
        {
            get
            {
                return m_Signer;
            }
            set
            {
                m_Signer = value;
            }
        }

        private string m_Recipient;
        /// <summary>
        /// 受送達人
        /// </summary>
        [TableColumnSetting("Recipient", DataLength = 100)]
        public string Recipient
        {
            get
            {
                return m_Recipient;
            }
            set
            {
                m_Recipient = value;
            }
        }

        private DateTime? m_IssueDate;
        /// <summary>
        /// 發文日期
        /// </summary>
        [TableColumnSetting("IssueDate", DbType = SqlDataType.Date, DataLength = 3)]
        public DateTime? IssueDate
        {
            get
            {
                return m_IssueDate;
            }
            set
            {
                m_IssueDate = value;
            }
        }

        private string m_FileName;
        /// <summary>
        /// 檔案
        /// </summary>
        [TableColumnSetting("FileName", DataLength = 2000)]
        public string FileName
        {
            get
            {
                return m_FileName;
            }
            set
            {
                m_FileName = value;
            }
        }

        private string m_CaseType;
        /// <summary>
        /// 案件種類
        /// </summary>
        [TableColumnSetting("CaseType", DataLength = 100)]
        public string CaseType
        {
            get
            {
                return m_CaseType;
            }
            set
            {
                m_CaseType = value;
            }
        }

        private string m_RecipientNumber;
        /// <summary>
        /// 受文者序號
        /// </summary>
        [TableColumnSetting("RecipientNumber", DataLength = 100)]
        public string RecipientNumber
        {
            get
            {
                return m_RecipientNumber;
            }
            set
            {
                m_RecipientNumber = value;
            }
        }

        private string m_RelatedCaseNumber;
        /// <summary>
        /// 相關案號
        /// </summary>
        [TableColumnSetting("RelatedCaseNumber", DataLength = 200)]
        public string RelatedCaseNumber
        {
            get
            {
                return m_RelatedCaseNumber;
            }
            set
            {
                m_RelatedCaseNumber = value;
            }
        }

        private string m_Reviewer;
        /// <summary>
        /// 承審委員
        /// </summary>
        [TableColumnSetting("Reviewer", DataLength = 100)]
        public string Reviewer
        {
            get
            {
                return m_Reviewer;
            }
            set
            {
                m_Reviewer = value;
            }
        }

        private string m_IPCclassification;
        /// <summary>
        /// IPC分類
        /// </summary>
        [TableColumnSetting("IPCclassification", DataLength = 200)]
        public string IPCclassification
        {
            get
            {
                return m_IPCclassification;
            }
            set
            {
                m_IPCclassification = value;
            }
        }

        private string m_FirmNumberID;
        /// <summary>
        /// 事務所案號
        /// </summary>
        [TableColumnSetting("FirmNumberID", DataLength = 100)]
        public string FirmNumberID
        {
            get
            {
                return m_FirmNumberID;
            }
            set
            {
                m_FirmNumberID = value;
            }
        }

        private string m_OriginalCopy;
        /// <summary>
        /// 正副本
        /// </summary>
        [TableColumnSetting("OriginalCopy", DataLength = 100)]
        public string OriginalCopy
        {
            get
            {
                return m_OriginalCopy;
            }
            set
            {
                m_OriginalCopy = value;
            }
        }

        private string m_CasePerson;
        /// <summary>
        /// 受文者
        /// </summary>
        [TableColumnSetting("CasePerson", DataLength = 200)]
        public string CasePerson
        {
            get
            {
                return m_CasePerson;
            }
            set
            {
                m_CasePerson = value;
            }
        }

        private string m_FilePath;
        /// <summary>
        /// 檔案路徑
        /// </summary>
        [TableColumnSetting("FilePath", DataLength = 1000)]
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
            List<COfficialDocumentT> list = new List<COfficialDocumentT>();
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
                retObj = orm.ReadListToObjs<COfficialDocumentT>(ColumnName + "=@" + ColumnName, ref list, ParList);
            }
            else
            {
                retObj = orm.ReadListToObjs<COfficialDocumentT>(ColumnName + "=@" + ColumnName + " and OfficialDocumentKey<>" + this.OfficialDocumentKey.ToString(), ref list, ParList);
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
            object retObj = orm.ReadCountRows<COfficialDocumentT>(ref iCountRows, strSqlWhere, sqlParameterList: sqlParameterList, CusTableName: strCusTableName);
            return retObj;
        }
        #endregion

        #region 取得一筆資料  ReadOne(ref COfficialDocumentT Item, string strCusTableName = ")
        /// <summary>
        /// 取得一筆OfficialDocumentT資料
        /// </summary>          
        /// <param name="Item"></param>   
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>
        /// <returns>0:成功 ; string:失敗</returns>       
        public static object ReadOne(ref COfficialDocumentT Item, string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.ReadOneToObj(ref Item, CusTableName: strCusTableName);
            return retObj;
        }
        #endregion

        #region 取得一筆資料 ReadOne(int iPKey, ref COfficialDocumentT item, string strCusTableName = "")
        /// <summary>
        /// 取得一筆OfficialDocumentT資料
        /// </summary>
        /// <param name="iPKey">指定某筆資料的Key值(不適合複合key)</param>     
        /// <param name="item"></param>   
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>
        /// <returns>0:成功 ; string:失敗</returns>       
        public static object ReadOne(int iPKey, ref COfficialDocumentT item, string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.ReadOneToObj(iPKey, ref item, CusTableName: strCusTableName);
            return retObj;
        }
        #endregion

        #region 取得一筆OfficialDocumentT資料 ReadOne(string strSqlWhere, System.Data.SqlClient.SqlParameter[] MySqlParameterList=null, string strCusTableName = "")
        /// <summary>
        /// 取得一筆OfficialDocumentT資料;如果有多筆符合條件，則只回傳null
        /// </summary>
        /// <param name="strSqlWhere">查詢條件(不用加「where」關鍵字, 可加Sql參數,例如: account=@account)</param>
        /// <param name="item"></param>
        /// <param name="MySqlParameterList">Sql參數</param>
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>
        /// <returns>0:成功 ; string:失敗</returns>
        public static object ReadOne(string strSqlWhere, ref COfficialDocumentT item, System.Data.SqlClient.SqlParameter[] MySqlParameterList = null, string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            List<COfficialDocumentT> itemlist = new List<COfficialDocumentT>();
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

        #region 取得多筆COfficialDocumentT資料 ReadList 
        /// <summary>
        /// 取得多筆 OfficialDocumentT資料，符合的全部撈出並轉成物件
        /// </summary>
        /// <param name="Items"></param>
        /// <param name="strSqlWhere">SQL條件式 (不用加「where」關鑵字,可加Sql參數,例如: account=@account)</param>
        /// <param name="MySqlParameterList">Sql參數</param>
        /// <param name="strOrderBy">SQL排序式 , 當空值時，預設帶[ CreateDateTime Desc] (不用加「Order by 」關鑵字, 例 "uid desc,createDateTime asc ")</param>
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>      
        /// <returns></returns>
        public static object ReadList(ref List<COfficialDocumentT> Items, string strSqlWhere = "", System.Data.SqlClient.SqlParameter[] MySqlParameterList = null, string strOrderBy = "", string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();

            object retObj = orm.ReadListToObjs<COfficialDocumentT>(strSqlWhere, ref Items, sqlParameterList: MySqlParameterList, OrderBy: strOrderBy, CusTableName: strCusTableName);

            return retObj;
        }

        #endregion

        #region 取得多筆COfficialDocumentT資料 ReadList DataTable
        /// <summary>
        /// 取得多筆 OfficialDocumentT DataTable資料
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

            object retObj = orm.ReadListToObjs<COfficialDocumentT>(strSqlWhere, ref Items, sqlParameterList: MySqlParameterList, OrderBy: strOrderBy, CusTableName: strCusTableName);

            return retObj;
        }

        #endregion

        #region 取得多筆 OfficialDocumentT資料 , 指定頁數和頁碼 ReadList
        /// <summary>
        /// 取得多筆 OfficialDocumentT資料 , 指定頁數和頁碼
        /// </summary>
        /// <param name="PageSize">一頁的筆數</param>
        /// <param name="PageIndex">第 n 頁;從 0 起算，當值小於0時，預設帶0 (0即表示第一頁)</param>
        /// <param name="Items"></param>
        /// <param name="strSqlWhere">SQL條件式 (不用加「where」關鑵字,可加Sql參數,例如: account=@account)</param>
        /// <param name="MySqlParameterList">Sql參數</param>
        /// <param name="strOrderBy">SQL排序式 , 當空值時，預設帶[ CreateDateTime Desc] (不用加「Order by 」關鑵字, 例 "uid desc,createDateTime asc ")</param>
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>       
        /// <returns></returns>
        public static object ReadList(int PageSize, int PageIndex, ref List<COfficialDocumentT> Items, string strSqlWhere = "", System.Data.SqlClient.SqlParameter[] MySqlParameterList = null, string strOrderBy = "", string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            int iTotalCountRows = 0;
            object retObj = orm.ReadListToObjsByFetch<COfficialDocumentT>(PageSize, PageIndex, strSqlWhere, ref Items, ref iTotalCountRows, sqlParameterList: MySqlParameterList, OrderBy: strOrderBy, CusTableName: strCusTableName);

            return retObj;
        }
        #endregion

        #region 取得多筆 OfficialDocumentT資料 , 指定頁數和頁碼 ReadList,回傳查詢的總筆數
        /// <summary>
        /// 取得多筆 OfficialDocumentT資料 , 指定頁數和頁碼,回傳查詢的總筆數
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
        public static object ReadList(int PageSize, int PageIndex, ref List<COfficialDocumentT> Items, ref int iTotalRowCount, string strSqlWhere = "", System.Data.SqlClient.SqlParameter[] MySqlParameterList = null, string strOrderBy = "", string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();

            object retObj = orm.ReadListToObjsByFetch<COfficialDocumentT>(PageSize, PageIndex, strSqlWhere, ref Items, ref iTotalRowCount, sqlParameterList: MySqlParameterList, OrderBy: strOrderBy, CusTableName: strCusTableName);

            return retObj;
        }
        #endregion

        #region 取得多筆 OfficialDocumentT DataTable資料 , 指定頁數和頁碼 ReadList,回傳查詢的總筆數
        /// <summary>
        /// 取得多筆 OfficialDocumentT DataTable 資料 , 指定頁數和頁碼,回傳查詢的總筆數
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

            object retObj = orm.ReadListToObjsByFetch<COfficialDocumentT>(PageSize, PageIndex, strSqlWhere, ref Items, ref iTotalRowCount, sqlParameterList: MySqlParameterList, OrderBy: strOrderBy, CusTableName: strCusTableName);

            return retObj;
        }
        #endregion

        #region Create
        /// <summary>
        /// 新增OfficialDocumentT 項目
        /// </summary> 
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>      
        /// <returns>0:成功 ; string:失敗</returns>
        public object Create(string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.InsertByObj<COfficialDocumentT>(this, strCusTableName);
            return retObj;
        }
        #endregion

        #region Update
        /// <summary>
        /// 更新 OfficialDocumentT 項目
        /// </summary>       
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param> 
        /// <returns>0:成功 ; string:失敗</returns>
        public object Update(string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.UpdateObj<COfficialDocumentT>(this, strCusTableName);
            return retObj;
        }
        #endregion

        #region Delete

        #region 刪除項目OfficialDocumentT Delete()
        /// <summary>
        /// 刪除項目OfficialDocumentT
        /// </summary>  
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>
        /// <returns></returns>   
        public object Delete(string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.DeleteObj<COfficialDocumentT>(this, strCusTableName);
            return retObj;
        }
        #endregion

        #region 刪除項目OfficialDocumentT Delete(int iPKey)
        /// <summary>
        /// 刪除項目OfficialDocumentT , 指定某一筆主鍵刪除(單筆)
        /// </summary>
        /// <param name="iPKey">指定刪除某筆資料的Key值</param> 
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>      
        /// <returns></returns>
        public object Delete(int iPKey, string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.DeleteObj<COfficialDocumentT>(iPKey, strCusTableName);
            return retObj;
        }
        #endregion      

        #region 刪除項目OfficialDocumentT Delete(string strSqlWhere)
        /// <summary>
        /// 刪除項目OfficialDocumentT ,符合條件刪除(多筆)
        /// </summary>
        /// <param name="strSqlWhere">查詢條件(不用加「where」關鍵字)</param>   
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>    
        /// <returns></returns>
        public object Delete(string strSqlWhere, string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.DeleteObj<COfficialDocumentT>(strSqlWhere, strCusTableName);
            return retObj;
        }
        #endregion

        #endregion

        #endregion
    }
    #endregion =================
}
