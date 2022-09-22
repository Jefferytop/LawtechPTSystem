using System;
using System.Collections.Generic;
using H3Operator.DBModels;
using H3Operator.DBHelper;

namespace LawtechPTSystemByFirm
{
    #region Worker_Model=================
    /// <summary>
    /// 
    /// </summary>
    [TableMapping("WorkerT")]
    public class Worker_Model : SysBaseModel
    {

        #region Public property

        private int m_WorkerKey;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("WorkerKey", DbType = SqlDataType.Int, IsPrimary = true, IsCumulative = true, IsCanNull = false, DataLength = 4)]
        public int WorkerKey
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

        private string m_EmployeeName;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("EmployeeName", DataLength = 40)]
        public string EmployeeName
        {
            get
            {
                return m_EmployeeName;
            }
            set
            {
                m_EmployeeName = value;
            }
        }

        private string m_EmployeeNameEn;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("EmployeeNameEn", DataLength = 40)]
        public string EmployeeNameEn
        {
            get
            {
                return m_EmployeeNameEn;
            }
            set
            {
                m_EmployeeNameEn = value;
            }
        }

        private string m_WorkerSymbol;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("WorkerSymbol", DataLength = 100)]
        public string WorkerSymbol
        {
            get
            {
                return m_WorkerSymbol;
            }
            set
            {
                m_WorkerSymbol = value;
            }
        }

        private string m_ext;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("ext", DataLength = 20)]
        public string ext
        {
            get
            {
                return m_ext;
            }
            set
            {
                m_ext = value;
            }
        }

        private string m_Account;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("Account", DataLength = 100)]
        public string Account
        {
            get
            {
                return m_Account;
            }
            set
            {
                m_Account = value;
            }
        }

        private string m_Email;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("Email", DataLength = 100)]
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

        private string m_EmployeeID;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("EmployeeID", DataLength = 40)]
        public string EmployeeID
        {
            get
            {
                return m_EmployeeID;
            }
            set
            {
                m_EmployeeID = value;
            }
        }

        private DateTime? m_Birthday;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("Birthday", DbType = SqlDataType.SmallDateTime, DataLength = 4)]
        public DateTime? Birthday
        {
            get
            {
                return m_Birthday;
            }
            set
            {
                m_Birthday = value;
            }
        }

        private DateTime? m_ReachDay;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("ReachDay", DbType = SqlDataType.SmallDateTime, DataLength = 4)]
        public DateTime? ReachDay
        {
            get
            {
                return m_ReachDay;
            }
            set
            {
                m_ReachDay = value;
            }
        }

        private DateTime? m_DepartDay;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("DepartDay", DbType = SqlDataType.SmallDateTime, DataLength = 4)]
        public DateTime? DepartDay
        {
            get
            {
                return m_DepartDay;
            }
            set
            {
                m_DepartDay = value;
            }
        }

        private string m_Urgent;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("Urgent", DataLength = 40)]
        public string Urgent
        {
            get
            {
                return m_Urgent;
            }
            set
            {
                m_Urgent = value;
            }
        }

        private string m_EverAddr;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("EverAddr", DataLength = 100)]
        public string EverAddr
        {
            get
            {
                return m_EverAddr;
            }
            set
            {
                m_EverAddr = value;
            }
        }

        private string m_Addr;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("Addr", DataLength = 100)]
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

        private string m_Mobilephone;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("Mobilephone", DataLength = 40)]
        public string Mobilephone
        {
            get
            {
                return m_Mobilephone;
            }
            set
            {
                m_Mobilephone = value;
            }
        }

        private string m_Remark;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("Remark")]
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

        private string m_WorkerId;
        /// <summary>
        /// 員工編號
        /// </summary>
        [TableColumnSetting("WorkerId", DataLength = 100)]
        public string WorkerId
        {
            get
            {
                return m_WorkerId;
            }
            set
            {
                m_WorkerId = value;
            }
        }

        private bool? m_IsQuit;
        /// <summary>
        /// 是否離職 true-離職  false-在職
        /// </summary>
        [TableColumnSetting("IsQuit", DbType = SqlDataType.Bit, DataLength = 1)]
        public bool? IsQuit
        {
            get
            {
                return m_IsQuit;
            }
            set
            {
                m_IsQuit = value;
            }
        }

        private string m_FullDeptName;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("FullDeptName", DataLength = 200)]
        public string FullDeptName
        {
            get
            {
                return m_FullDeptName;
            }
            set
            {
                m_FullDeptName = value;
            }
        }

        private string m_FullDeptKEY;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("FullDeptKEY", DataLength = 200)]
        public string FullDeptKEY
        {
            get
            {
                return m_FullDeptKEY;
            }
            set
            {
                m_FullDeptKEY = value;
            }
        }

        private string m_Password;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("Password", DataLength = 100)]
        public string Password
        {
            get
            {
                return m_Password;
            }
            set
            {
                m_Password = value;
            }
        }

        private string m_Position;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("Position", DataLength = 100)]
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

        private string m_Background;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("Background", DataLength = 400)]
        public string Background
        {
            get
            {
                return m_Background;
            }
            set
            {
                m_Background = value;
            }
        }

        private string m_Experience;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("Experience", DataLength = 1000)]
        public string Experience
        {
            get
            {
                return m_Experience;
            }
            set
            {
                m_Experience = value;
            }
        }

        private int? m_OfficeRole;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("OfficeRole", DbType = SqlDataType.Int, DataLength = 4)]
        public int? OfficeRole
        {
            get
            {
                return m_OfficeRole;
            }
            set
            {
                m_OfficeRole = value;
            }
        }

        private string m_SingCode;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("SingCode", DataLength = 600)]
        public string SingCode
        {
            get
            {
                return m_SingCode;
            }
            set
            {
                m_SingCode = value;
            }
        }

        private string m_WorkScope;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("WorkScope", DataLength = 6000)]
        public string WorkScope
        {
            get
            {
                return m_WorkScope;
            }
            set
            {
                m_WorkScope = value;
            }
        }

        private string m_Specialty;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("Specialty", DataLength = 1000)]
        public string Specialty
        {
            get
            {
                return m_Specialty;
            }
            set
            {
                m_Specialty = value;
            }
        }

        private string m_FileServer_LocalhostPath;
        /// <summary>
        /// 本機路徑
        /// </summary>
        [TableColumnSetting("FileServer_LocalhostPath", DataLength = 1000)]
        public string FileServer_LocalhostPath
        {
            get
            {
                return m_FileServer_LocalhostPath;
            }
            set
            {
                m_FileServer_LocalhostPath = value;
            }
        }

        private bool? m_IsLoadData;
        /// <summary>
        /// 是否載入資料; true:載入 ; false: 不載入
        /// </summary>
        [TableColumnSetting("IsLoadData", DbType = SqlDataType.Bit, DataLength = 1)]
        public bool? IsLoadData
        {
            get
            {
                return m_IsLoadData;
            }
            set
            {
                m_IsLoadData = value;
            }
        }

        private short? m_LoadDataRange;
        /// <summary>
        /// 載入資料的時間範圍
        /// </summary>
        [TableColumnSetting("LoadDataRange", DbType = SqlDataType.SmallInt, DataLength = 2)]
        public short? LoadDataRange
        {
            get
            {
                return m_LoadDataRange;
            }
            set
            {
                m_LoadDataRange = value;
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
            List<Worker_Model> list = new List<Worker_Model>();
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
                retObj = orm.ReadListToObjs<Worker_Model>(ColumnName + "=@" + ColumnName, ref list, ParList);
            }
            else
            {
                retObj = orm.ReadListToObjs<Worker_Model>(ColumnName + "=@" + ColumnName + " and WorkerKey<>" + this.WorkerKey.ToString(), ref list, ParList);
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

        #region 取得一筆資料  ReadOne(ref Worker_Model Item, string strCusTableName = ")
        /// <summary>
        /// 取得一筆WorkerT資料
        /// </summary>          
        /// <param name="item"></param>   
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>
        /// <returns>0:成功 ; string:失敗</returns>       
        public static object ReadOne(ref Worker_Model Item, string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.ReadOneToObj(ref Item, CusTableName: strCusTableName);
            return retObj;
        }
        #endregion

        #region 取得一筆資料 ReadOne(int iPKey, ref DB_MenuRoleTModel item, string strCusTableName = "")
        /// <summary>
        /// 取得一筆WorkerT資料
        /// </summary>
        /// <param name="iPKey">指定某筆資料的Key值(不適合複合key)</param>     
        /// <param name="item"></param>   
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>
        /// <returns>0:成功 ; string:失敗</returns>       
        public static object ReadOne(int iPKey, ref Worker_Model item, string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.ReadOneToObj(iPKey, ref item, CusTableName: strCusTableName);
            return retObj;
        }
        #endregion

        #region 取得一筆WorkerT資料 ReadOne(string strSqlWhere, System.Data.SqlClient.SqlParameter[] MySqlParameterList=null, string strCusTableName = "")
        /// <summary>
        /// 取得一筆WorkerT資料;如果有多筆符合條件，則只回傳null
        /// </summary>
        /// <param name="strSqlWhere">查詢條件(不用加「where」關鍵字, 可加Sql參數,例如: account=@account)</param>
        /// <param name="MySqlParameterList">Sql參數</param>
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>
        /// <returns>0:成功 ; string:失敗</returns>
        public static object ReadOne(string strSqlWhere, ref Worker_Model item, System.Data.SqlClient.SqlParameter[] MySqlParameterList = null, string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            List<Worker_Model> itemlist = new List<Worker_Model>();
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

        #region 取得多筆Worker_Model資料 ReadList
        /// <summary>
        /// 取得多筆 WorkerT資料 
        /// </summary>
        /// <param name="Items"></param>
        /// <param name="strSqlWhere">SQL條件式 (不用加「where」關鑵字,可加Sql參數,例如: account=@account)</param>
        /// <param name="MySqlParameterList">Sql參數</param>
        /// <param name="strOrderBy">SQL排序式 , 當空值時，預設帶[ CreateDateTime Desc] (不用加「Order by 」關鑵字, 例 "uid desc,createDateTime asc ")</param>
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>      
        /// <returns></returns>
        public static object ReadList(ref List<Worker_Model> Items, string strSqlWhere = "", System.Data.SqlClient.SqlParameter[] MySqlParameterList = null, string strOrderBy = "", string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();

            object retObj = orm.ReadListToObjs<Worker_Model>(strSqlWhere, ref Items, sqlParameterList: MySqlParameterList, OrderBy: strOrderBy, CusTableName: strCusTableName);

            return retObj;
        }

        #endregion

        #region 取得多筆 WorkerT資料 , 指定頁數和頁碼 ReadList
        /// <summary>
        /// 取得多筆 WorkerT資料 , 指定頁數和頁碼
        /// </summary>
        /// <param name="PageSize">一頁的筆數</param>
        /// <param name="PageIndex">第 n 頁</param>
        /// <param name="Items"></param>
        /// <param name="strSqlWhere">SQL條件式 (不用加「where」關鑵字,可加Sql參數,例如: account=@account)</param>
        /// <param name="MySqlParameterList">Sql參數</param>
        /// <param name="strOrderBy">SQL排序式 , 當空值時，預設帶[ CreateDateTime Desc] (不用加「Order by 」關鑵字, 例 "uid desc,createDateTime asc ")</param>
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>       
        /// <returns></returns>
        public static object ReadList(int PageSize, int PageIndex, ref List<Worker_Model> Items, string strSqlWhere = "", System.Data.SqlClient.SqlParameter[] MySqlParameterList = null, string strOrderBy = "", string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();

            object retObj = orm.ReadListToObjs<Worker_Model>(PageSize, PageIndex, strSqlWhere, ref Items, sqlParameterList: MySqlParameterList, OrderBy: strOrderBy, CusTableName: strCusTableName);

            return retObj;
        }
        #endregion

        #region Create
        /// <summary>
        /// 新增WorkerT 項目
        /// </summary> 
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>      
        /// <returns>0:成功 ; string:失敗</returns>
        public object Create(string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.InsertByObj<Worker_Model>(this, strCusTableName);
            return retObj;
        }
        #endregion

        #region Update
        /// <summary>
        /// 更新 WorkerT 項目
        /// </summary>       
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param> 
        /// <returns>0:成功 ; string:失敗</returns>
        public object Update(string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.UpdateObj<Worker_Model>(this, strCusTableName);
            return retObj;
        }
        #endregion

        #region Delete

        #region 刪除項目WorkerT Delete()
        /// <summary>
        /// 刪除項目WorkerT
        /// </summary>  
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>
        /// <returns></returns>   
        public object Delete(string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.DeleteObj<Worker_Model>(this, strCusTableName);
            return retObj;
        }
        #endregion

        #region 刪除項目WorkerT Delete(int iPKey)
        /// <summary>
        /// 刪除項目WorkerT , 指定某一筆主鍵刪除(單筆)
        /// </summary>
        /// <param name="iPKey">指定刪除某筆資料的Key值</param> 
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>      
        /// <returns></returns>
        public object Delete(int iPKey, string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.DeleteObj<Worker_Model>(iPKey, strCusTableName);
            return retObj;
        }
        #endregion

        #region 刪除項目WorkerT Delete(string strSqlWhere)
        /// <summary>
        /// 刪除項目WorkerT ,符合條件刪除(多筆)
        /// </summary>
        /// <param name="strSqlWhere">查詢條件(不用加「where」關鍵字)</param>   
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>    
        /// <returns></returns>
        public object Delete(string strSqlWhere, string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.DeleteObj<Worker_Model>(strSqlWhere, strCusTableName);
            return retObj;
        }
        #endregion

        #endregion

        #endregion
    }
    #endregion =================
}
