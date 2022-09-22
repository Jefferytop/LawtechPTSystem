using System;
using System.Collections.Generic;
using H3Operator.DBHelper;
using H3Operator.DBModels;


namespace LawtechPTSystem.Public
{
    #region CEmailLog=================
    /// <summary>
    /// 
    /// </summary>
    [TableMapping("EmailLogT")]
    public class CEmailLog : SysBaseModel
    {
        #region Public property

        private int m_EmailLogID;
        /// <summary>
        /// Email記錄表
        /// </summary>
        [TableColumnSetting("EmailLogID", DbType = SqlDataType.Int, IsPrimary = true, IsCumulative = true, IsCanNull = false, DataLength = 4)]
        public int EmailLogID
        {
            get
            {
                return m_EmailLogID;
            }
            set
            {
                m_EmailLogID = value;
            }
        }

        private string m_EmailSampleType;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("EmailSampleType", DataLength = 300)]
        public string EmailSampleType
        {
            get
            {
                return m_EmailSampleType;
            }
            set
            {
                m_EmailSampleType = value;
            }
        }

        private string m_EmailSender;
        /// <summary>
        /// 寄件者mail
        /// </summary>
        [TableColumnSetting("EmailSender", DataLength = 300)]
        public string EmailSender
        {
            get
            {
                return m_EmailSender;
            }
            set
            {
                m_EmailSender = value;
            }
        }

        private string m_EmailReciver;
        /// <summary>
        /// 收件者
        /// </summary>
        [TableColumnSetting("EmailReciver", DataLength = 6000)]
        public string EmailReciver
        {
            get
            {
                return m_EmailReciver;
            }
            set
            {
                m_EmailReciver = value;
            }
        }

        private string m_EmailCC;
        /// <summary>
        /// 副本
        /// </summary>
        [TableColumnSetting("EmailCC", DataLength = 4000)]
        public string EmailCC
        {
            get
            {
                return m_EmailCC;
            }
            set
            {
                m_EmailCC = value;
            }
        }

        private string m_EmailBCC;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("EmailBCC", DataLength = 2000)]
        public string EmailBCC
        {
            get
            {
                return m_EmailBCC;
            }
            set
            {
                m_EmailBCC = value;
            }
        }

        private string m_EmailSubject;
        /// <summary>
        /// Mail主旨
        /// </summary>
        [TableColumnSetting("EmailSubject", DataLength = 4000)]
        public string EmailSubject
        {
            get
            {
                return m_EmailSubject;
            }
            set
            {
                m_EmailSubject = value;
            }
        }

        private string m_EmailFormat;
        /// <summary>
        /// Mail格式
        /// </summary>
        [TableColumnSetting("EmailFormat", DataLength = 100)]
        public string EmailFormat
        {
            get
            {
                return m_EmailFormat;
            }
            set
            {
                m_EmailFormat = value;
            }
        }

        private int? m_MailPriority;
        /// <summary>
        /// mail重要性
        /// </summary>
        [TableColumnSetting("MailPriority", DbType = SqlDataType.Int, DataLength = 4)]
        public int? MailPriority
        {
            get
            {
                return m_MailPriority;
            }
            set
            {
                m_MailPriority = value;
            }
        }

        private string m_EmailBody;
        /// <summary>
        /// 內文
        /// </summary>
        [TableColumnSetting("EmailBody")]
        public string EmailBody
        {
            get
            {
                return m_EmailBody;
            }
            set
            {
                m_EmailBody = value;
            }
        }

        private string m_AttachFile;
        /// <summary>
        /// 附件
        /// </summary>
        [TableColumnSetting("AttachFile", DataLength = 8000)]
        public string AttachFile
        {
            get
            {
                return m_AttachFile;
            }
            set
            {
                m_AttachFile = value;
            }
        }

        private int? m_WorkerKey;
        /// <summary>
        /// 本所人員
        /// </summary>
        [TableColumnSetting("WorkerKey", DbType = SqlDataType.Int, DataLength = 4)]
        public int? WorkerKey
        {
            get
            {
                return m_WorkerKey;
            }
            set
            {
                m_WorkerKey = value;
            }
        }

        private DateTime? m_SendDateTime;
        /// <summary>
        /// 寄送時間
        /// </summary>
        [TableColumnSetting("SendDateTime", DbType = SqlDataType.DateTime, DataLength = 8)]
        public DateTime? SendDateTime
        {
            get
            {
                return m_SendDateTime;
            }
            set
            {
                m_SendDateTime = value;
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
            List<CEmailLog> list = new List<CEmailLog>();
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
                retObj = orm.ReadListToObjs<CEmailLog>(ColumnName + "=@" + ColumnName, ref list, ParList);
            }
            else
            {
                retObj = orm.ReadListToObjs<CEmailLog>(ColumnName + "=@" + ColumnName + " and EmailLogID<>" + this.EmailLogID.ToString(), ref list, ParList);
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

        #region 取得一筆資料  ReadOne(ref CEmailLog Item, string strCusTableName = ")
        /// <summary>
        /// 取得一筆EmailLogT資料
        /// </summary>          
        /// <param name="item"></param>   
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>
        /// <returns>0:成功 ; string:失敗</returns>       
        public static object ReadOne(ref CEmailLog Item, string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.ReadOneToObj(ref Item, CusTableName: strCusTableName);
            return retObj;
        }
        #endregion

        #region 取得一筆資料 ReadOne(int iPKey, ref DB_MenuRoleTModel item, string strCusTableName = "")
        /// <summary>
        /// 取得一筆EmailLogT資料
        /// </summary>
        /// <param name="iPKey">指定某筆資料的Key值(不適合複合key)</param>     
        /// <param name="item"></param>   
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>
        /// <returns>0:成功 ; string:失敗</returns>       
        public static object ReadOne(int iPKey, ref CEmailLog item, string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.ReadOneToObj(iPKey, ref item, CusTableName: strCusTableName);
            return retObj;
        }
        #endregion

        #region 取得一筆EmailLogT資料 ReadOne(string strSqlWhere, System.Data.SqlClient.SqlParameter[] MySqlParameterList=null, string strCusTableName = "")
        /// <summary>
        /// 取得一筆EmailLogT資料;如果有多筆符合條件，則只回傳null
        /// </summary>
        /// <param name="strSqlWhere">查詢條件(不用加「where」關鍵字, 可加Sql參數,例如: account=@account)</param>
        /// <param name="MySqlParameterList">Sql參數</param>
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>
        /// <returns>0:成功 ; string:失敗</returns>
        public static object ReadOne(string strSqlWhere, ref CEmailLog item, System.Data.SqlClient.SqlParameter[] MySqlParameterList = null, string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            List<CEmailLog> itemlist = new List<CEmailLog>();
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

        #region 取得多筆CEmailLog資料 ReadList
        /// <summary>
        /// 取得多筆 EmailLogT資料 
        /// </summary>
        /// <param name="Items"></param>
        /// <param name="strSqlWhere">SQL條件式 (不用加「where」關鑵字,可加Sql參數,例如: account=@account)</param>
        /// <param name="MySqlParameterList">Sql參數</param>
        /// <param name="strOrderBy">SQL排序式 , 當空值時，預設帶[ CreateDateTime Desc] (不用加「Order by 」關鑵字, 例 "uid desc,createDateTime asc ")</param>
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>      
        /// <returns></returns>
        public static object ReadList(ref List<CEmailLog> Items, string strSqlWhere = "", System.Data.SqlClient.SqlParameter[] MySqlParameterList = null, string strOrderBy = "", string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();

            object retObj = orm.ReadListToObjs<CEmailLog>(strSqlWhere, ref Items, sqlParameterList: MySqlParameterList, OrderBy: strOrderBy, CusTableName: strCusTableName);

            return retObj;
        }

        #endregion

        #region 取得多筆 EmailLogT資料 , 指定頁數和頁碼 ReadList
        /// <summary>
        /// 取得多筆 EmailLogT資料 , 指定頁數和頁碼
        /// </summary>
        /// <param name="PageSize">一頁的筆數</param>
        /// <param name="PageIndex">第 n 頁</param>
        /// <param name="Items"></param>
        /// <param name="strSqlWhere">SQL條件式 (不用加「where」關鑵字,可加Sql參數,例如: account=@account)</param>
        /// <param name="MySqlParameterList">Sql參數</param>
        /// <param name="strOrderBy">SQL排序式 , 當空值時，預設帶[ CreateDateTime Desc] (不用加「Order by 」關鑵字, 例 "uid desc,createDateTime asc ")</param>
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>       
        /// <returns></returns>
        public static object ReadList(int PageSize, int PageIndex, ref List<CEmailLog> Items, string strSqlWhere = "", System.Data.SqlClient.SqlParameter[] MySqlParameterList = null, string strOrderBy = "", string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();

            object retObj = orm.ReadListToObjs<CEmailLog>(PageSize, PageIndex, strSqlWhere, ref Items, sqlParameterList: MySqlParameterList, OrderBy: strOrderBy, CusTableName: strCusTableName);

            return retObj;
        }
        #endregion

        #region Create
        /// <summary>
        /// 新增EmailLogT 項目
        /// </summary> 
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>      
        /// <returns>0:成功 ; string:失敗</returns>
        public object Create(string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.InsertByObj<CEmailLog>(this, strCusTableName);
            return retObj;
        }
        #endregion

        #region Update
        /// <summary>
        /// 更新 EmailLogT 項目
        /// </summary>       
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param> 
        /// <returns>0:成功 ; string:失敗</returns>
        public object Update(string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.UpdateObj<CEmailLog>(this, strCusTableName);
            return retObj;
        }
        #endregion

        #region Delete

        #region 刪除項目EmailLogT Delete()
        /// <summary>
        /// 刪除項目EmailLogT
        /// </summary>  
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>
        /// <returns></returns>   
        public object Delete(string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.DeleteObj<CEmailLog>(this, strCusTableName);
            return retObj;
        }
        #endregion

        #region 刪除項目EmailLogT Delete(int iPKey)
        /// <summary>
        /// 刪除項目EmailLogT , 指定某一筆主鍵刪除(單筆)
        /// </summary>
        /// <param name="iPKey">指定刪除某筆資料的Key值</param> 
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>      
        /// <returns></returns>
        public object Delete(int iPKey, string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.DeleteObj<CEmailLog>(iPKey, strCusTableName);
            return retObj;
        }
        #endregion

        #region 刪除項目EmailLogT Delete(string strSqlWhere)
        /// <summary>
        /// 刪除項目EmailLogT ,符合條件刪除(多筆)
        /// </summary>
        /// <param name="strSqlWhere">查詢條件(不用加「where」關鍵字)</param>   
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>    
        /// <returns></returns>
        public object Delete(string strSqlWhere, string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.DeleteObj<CEmailLog>(strSqlWhere, strCusTableName);
            return retObj;
        }
        #endregion

        #endregion

        #endregion
    }
    #endregion =================
   
}
