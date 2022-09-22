using System;
using System.Collections.Generic;
using H3Operator.DBHelper;
using H3Operator.DBModels;
using System.Data;

namespace LawtechPTSystem
{
    #region View ViewModel_Worker Script
    [ViewTableMapping(@"SELECT          WorkerKey, EmployeeName, EmployeeNameEn, ext, Account, Password, Email, TEL, EmployeeID, Birthday, 
                            ReachDay, DepartDay, Urgent, EverAddr, Addr, Mobilephone, Remark, WorkerSymbol, IsQuit, FullDeptName, 
                            FullDeptKEY, Position, Background, Experience, OfficeRole, SingCode, WorkScope, Specialty, CreateDateTime, 
                            LastModifyDateTime, Creator, LastModifyWorker, WorkerId
FROM              WorkerT ")]
    public class ViewModel_Worker
    {
        #region Public Property

        private int m_WorkerKey;
        [TableColumnSetting("WorkerKey", DbType = SqlDataType.Int)]
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
        [TableColumnSetting("EmployeeName", DbType = SqlDataType.NVarChar)]
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
        [TableColumnSetting("EmployeeNameEn", DbType = SqlDataType.NVarChar)]
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

        private string m_ext;
        [TableColumnSetting("ext", DbType = SqlDataType.NVarChar)]
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
        [TableColumnSetting("Account", DbType = SqlDataType.NVarChar)]
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

        private string m_Password;
        [TableColumnSetting("Password", DbType = SqlDataType.NVarChar)]
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

        private string m_Email;
        [TableColumnSetting("Email", DbType = SqlDataType.NVarChar)]
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
        [TableColumnSetting("TEL", DbType = SqlDataType.NVarChar)]
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
        [TableColumnSetting("EmployeeID", DbType = SqlDataType.NVarChar)]
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

        private DateTime m_Birthday;
        [TableColumnSetting("Birthday", DbType = SqlDataType.DateTime)]
        public DateTime Birthday
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

        private DateTime m_ReachDay;
        [TableColumnSetting("ReachDay", DbType = SqlDataType.DateTime)]
        public DateTime ReachDay
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

        private DateTime m_DepartDay;
        [TableColumnSetting("DepartDay", DbType = SqlDataType.DateTime)]
        public DateTime DepartDay
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
        [TableColumnSetting("Urgent", DbType = SqlDataType.NVarChar)]
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
        [TableColumnSetting("EverAddr", DbType = SqlDataType.NVarChar)]
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
        [TableColumnSetting("Addr", DbType = SqlDataType.NVarChar)]
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
        [TableColumnSetting("Mobilephone", DbType = SqlDataType.NVarChar)]
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
        [TableColumnSetting("Remark", DbType = SqlDataType.NVarChar)]
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

        private string m_WorkerSymbol;
        [TableColumnSetting("WorkerSymbol", DbType = SqlDataType.NVarChar)]
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

        private bool m_IsQuit;
        [TableColumnSetting("IsQuit", DbType = SqlDataType.Bit)]
        public bool IsQuit
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
        [TableColumnSetting("FullDeptName", DbType = SqlDataType.NVarChar)]
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
        [TableColumnSetting("FullDeptKEY", DbType = SqlDataType.NVarChar)]
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

        private string m_Position;
        [TableColumnSetting("Position", DbType = SqlDataType.NVarChar)]
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
        [TableColumnSetting("Background", DbType = SqlDataType.NVarChar)]
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
        [TableColumnSetting("Experience", DbType = SqlDataType.NVarChar)]
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

        private int m_OfficeRole;
        [TableColumnSetting("OfficeRole", DbType = SqlDataType.Int)]
        public int OfficeRole
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
        [TableColumnSetting("SingCode", DbType = SqlDataType.NVarChar)]
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
        [TableColumnSetting("WorkScope", DbType = SqlDataType.NVarChar)]
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
        [TableColumnSetting("Specialty", DbType = SqlDataType.NVarChar)]
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

        private DateTime m_CreateDateTime;
        [TableColumnSetting("CreateDateTime", DbType = SqlDataType.DateTime)]
        public DateTime CreateDateTime
        {
            get
            {
                return m_CreateDateTime;
            }
            set
            {
                m_CreateDateTime = value;
            }
        }

        private DateTime m_LastModifyDateTime;
        [TableColumnSetting("LastModifyDateTime", DbType = SqlDataType.DateTime)]
        public DateTime LastModifyDateTime
        {
            get
            {
                return m_LastModifyDateTime;
            }
            set
            {
                m_LastModifyDateTime = value;
            }
        }

        private string m_Creator;
        [TableColumnSetting("Creator", DbType = SqlDataType.NVarChar)]
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
        [TableColumnSetting("LastModifyWorker", DbType = SqlDataType.NVarChar)]
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

        private string m_WorkerId;
        [TableColumnSetting("WorkerId", DbType = SqlDataType.NVarChar)]
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

        #endregion

        #region 取得多筆ViewModel_Worker資料 ReadList
        /// <summary>
        /// 取得多筆ViewModel_Worker資料 ReadList
        /// 只要指定的Sql欄位有對應至類別屬性，則自動繫結       
        /// </summary>
        /// <param name="Items"></param>
        /// <param name="strSqlScript">完整的Sql Script語法</param>
        /// <param name="MySqlParameterList"></param>
        /// <param name="IsStoredProcedure">是否為StoredProcedure ,true:是 ; false:否(預設值) </param>
        /// <returns></returns>
        public static object ReadViewTableList(ref List<ViewModel_Worker> Items, string strSqlScript = "", System.Data.SqlClient.SqlParameter[] MySqlParameterList = null, bool IsStoredProcedure = false)
        {
            ORMFactory orm = new ORMFactory();

            object retObj = orm.ReadViewDBListToObjs<ViewModel_Worker>(strSqlScript, ref Items, sqlParameterList: MySqlParameterList, isStoredProcedure: IsStoredProcedure);

            return retObj;
        }

        /// <summary>
        /// 取得多筆ViewModel_Worker資料 ReadList
        /// 只要指定的Sql欄位有對應至類別屬性，則自動繫結        
        /// </summary>
        /// <param name="strSqlWhere">SQL條件式 (不用加「where」關鑵字)</param>  
        /// <param name="Items"></param>       
        /// <param name="MySqlParameterList"></param>
        /// <param name="IsStoredProcedure">是否為StoredProcedure ,true:是 ; false:否(預設值)</param>
        /// <returns></returns>
        public static object ReadViewTableList(string strSqlWhere, ref List<ViewModel_Worker> Items, System.Data.SqlClient.SqlParameter[] MySqlParameterList = null, bool IsStoredProcedure = false)
        {
            ORMFactory orm = new ORMFactory();

            object retObj = orm.ReadViewDBListToObjs<ViewModel_Worker>(ref Items, strSqlWhere, sqlParameterList: MySqlParameterList, isStoredProcedure: IsStoredProcedure);

            return retObj;
        }

        public static void GetDataTable(ref DataTable dt)
        {
            DBAccess dbhelper = new DBAccess();
            string strSqlQuerySchema = ((ViewTableMappingAttribute)Attribute.GetCustomAttribute(typeof(ViewModel_Worker), typeof(ViewTableMappingAttribute))).SqlQuerySchema;
            dbhelper.QueryToDataTableByDataAdapter(strSqlQuerySchema, ref dt, isFillSchema: false);


        }

        #endregion

    }
    #endregion  
}
