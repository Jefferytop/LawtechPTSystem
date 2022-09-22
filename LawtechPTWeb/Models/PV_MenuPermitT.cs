using H3Operator.DBHelper;
using H3Operator.DBModels;
using System;
using System.Collections.Generic;
using System.Text;


namespace LawtechPTWeb.Models
{
    #region View PV_MenuPermitT Script
    [ViewTableMapping(@"SELECT   ModuleKey, ParentModuleKey, Sort, ModuleName, ModuleIcon, ControllerName, ActionName, Target, 
                            IsView, IsAdd, IsUpdate, IsDelete, IsOther, IsEnable, Remark, CreateDateTime, LastModifyDateTime
                        FROM  ApplicantModuleT ")]
    public class PV_MenuPermitT
    {
        #region Public Property

        private int m_ModuleKey;
        [TableColumnSetting("ModuleKey", DbType = SqlDataType.Int)]
        public int ModuleKey
        {
            get
            {
                return m_ModuleKey;
            }
            set
            {
                m_ModuleKey = value;
            }
        }

        private int m_ParentModuleKey;
        [TableColumnSetting("ParentModuleKey", DbType = SqlDataType.Int)]
        public int ParentModuleKey
        {
            get
            {
                return m_ParentModuleKey;
            }
            set
            {
                m_ParentModuleKey = value;
            }
        }

        private int m_Sort;
        [TableColumnSetting("Sort", DbType = SqlDataType.Int)]
        public int Sort
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

        private string m_ModuleName;
        [TableColumnSetting("ModuleName", DbType = SqlDataType.NVarChar)]
        public string ModuleName
        {
            get
            {
                return m_ModuleName;
            }
            set
            {
                m_ModuleName = value;
            }
        }

        private string m_ModuleIcon;
        [TableColumnSetting("ModuleIcon", DbType = SqlDataType.NVarChar)]
        public string ModuleIcon
        {
            get
            {
                return m_ModuleIcon;
            }
            set
            {
                m_ModuleIcon = value;
            }
        }

        private string m_ControllerName;
        [TableColumnSetting("ControllerName", DbType = SqlDataType.NVarChar)]
        public string ControllerName
        {
            get
            {
                return m_ControllerName;
            }
            set
            {
                m_ControllerName = value;
            }
        }

        private string m_ActionName;
        [TableColumnSetting("ActionName", DbType = SqlDataType.NVarChar)]
        public string ActionName
        {
            get
            {
                return m_ActionName;
            }
            set
            {
                m_ActionName = value;
            }
        }

        private string m_Target;
        [TableColumnSetting("Target", DbType = SqlDataType.NVarChar)]
        public string Target
        {
            get
            {
                return m_Target;
            }
            set
            {
                m_Target = value;
            }
        }

        private bool m_IsView;
        [TableColumnSetting("IsView", DbType = SqlDataType.Bit)]
        public bool IsView
        {
            get
            {
                return m_IsView;
            }
            set
            {
                m_IsView = value;
            }
        }

        private bool m_IsAdd;
        [TableColumnSetting("IsAdd", DbType = SqlDataType.Bit)]
        public bool IsAdd
        {
            get
            {
                return m_IsAdd;
            }
            set
            {
                m_IsAdd = value;
            }
        }

        private bool m_IsUpdate;
        [TableColumnSetting("IsUpdate", DbType = SqlDataType.Bit)]
        public bool IsUpdate
        {
            get
            {
                return m_IsUpdate;
            }
            set
            {
                m_IsUpdate = value;
            }
        }

        private bool m_IsDelete;
        [TableColumnSetting("IsDelete", DbType = SqlDataType.Bit)]
        public bool IsDelete
        {
            get
            {
                return m_IsDelete;
            }
            set
            {
                m_IsDelete = value;
            }
        }

        private bool m_IsOther;
        [TableColumnSetting("IsOther", DbType = SqlDataType.Bit)]
        public bool IsOther
        {
            get
            {
                return m_IsOther;
            }
            set
            {
                m_IsOther = value;
            }
        }

        private bool m_IsEnable;
        [TableColumnSetting("IsEnable", DbType = SqlDataType.Bit)]
        public bool IsEnable
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

        #endregion

        #region [GetTotalCountRows]多資料表join時使用，回傳查詢後的總筆數 public static object GetTotalCountRows(ref int iCountRows, string strSqlWhere = ", System.Data.SqlClient.SqlParameter[] sqlParameterList = null, string strCusTableName = "")
        /// <summary>
        /// [ViewDBMapping]多資料表join時使用，回傳查詢後的總筆數
        /// </summary>
        /// <param name="iCountRows">回傳此次查詢的總筆數</param>
        /// <param name="strSqlWhere">SQL條件式 (不用加「where」關鑵字)</param>
        /// <param name="sqlParameterList">Sql參數</param>
        /// <param name="IsStoredProcedure">是否為預存程序, 預設為False</param>
        /// <returns></returns>
        public static object GetTotalCountRows(ref int iCountRows, string strSqlWhere = "", System.Data.SqlClient.SqlParameter[] sqlParameterList = null, bool IsStoredProcedure = false)
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.ReadViewCountRows<PV_MenuPermitT>(ref iCountRows, strSqlWhere, sqlParameterList: sqlParameterList, isStoredProcedure: IsStoredProcedure);
            return retObj;
        }

        /// <summary>
        /// [ViewDBMapping]多資料表join時使用，回傳查詢後的總筆數
        /// </summary>
        /// <param name="strSqlScript">提供完整的Sql Script 語法</param>
        /// <param name="iCountRows">回傳此次查詢的總筆數</param>
        /// <param name="sqlParameterList">Sql參數</param>       
        /// <param name="IsStoredProcedure">是否為預存程序, 預設為False</param>
        /// <param name="ConnectString">預設為空字串，不為空字串時，以帶的連線字串為主; 若為空字串則以類別指定的連線字串(當類別連線名稱為空則帶DBSetConnection.ConnectionListDefaultConnectionString); </param>
        /// <returns></returns>
        public static object GetTotalCountRows(string strSqlScript, ref int iCountRows, System.Data.SqlClient.SqlParameter[] sqlParameterList = null, bool IsStoredProcedure = false, string ConnectString = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.ReadViewCountRows<PV_MenuPermitT>(strSqlScript, ref iCountRows, sqlParameterList: sqlParameterList, strConnectionString: ConnectString, isStoredProcedure: IsStoredProcedure);
            return retObj;
        }
        #endregion

        #region 取得多筆PV_MenuPermitT資料 ReadList

        #region  public static object ReadList(ref List<PV_MenuPermitT> Items, string strSqlScript = "", System.Data.SqlClient.SqlParameter[] MySqlParameterList = null, bool IsStoredProcedure = false)
        /// <summary>
        /// 取得多筆PV_MenuPermitT資料 ReadList
        /// 只要指定的Sql欄位有對應至類別屬性，則自動繫結       
        /// </summary>
        /// <param name="Items"></param>
        /// <param name="strSqlScript">完整的Sql Script語法</param>
        /// <param name="MySqlParameterList"></param>
        /// <param name="IsStoredProcedure">是否為StoredProcedure ,true:是 ; false:否(預設值) </param>
        /// <returns></returns>
        public static object ReadList(ref List<PV_MenuPermitT> Items, string strSqlScript = "", System.Data.SqlClient.SqlParameter[] MySqlParameterList = null, bool IsStoredProcedure = false)
        {
            ORMFactory orm = new ORMFactory();

            object retObj = orm.ReadViewDBListToObjs<PV_MenuPermitT>(strSqlScript, ref Items, sqlParameterList: MySqlParameterList, isStoredProcedure: IsStoredProcedure);

            return retObj;
        }
        #endregion

        #region public static object ReadList( string strSqlWhere  ,ref List<PV_MenuPermitT> Items, System.Data.SqlClient.SqlParameter[] MySqlParameterList = null, bool IsStoredProcedure = false)
        /// <summary>
        /// 取得多筆PV_MenuPermitT資料 ReadList
        /// 只要指定的Sql欄位有對應至類別屬性，則自動繫結       
        /// </summary>
        /// <param name="strSqlWhere">SQL條件式 (不用加「where」關鑵字)</param>  
        /// <param name="Items"></param>       
        /// <param name="MySqlParameterList"></param>
        /// <param name="IsStoredProcedure">是否為StoredProcedure ,true:是 ; false:否(預設值)</param>
        /// <returns></returns>
        public static object ReadList(string strSqlWhere, ref List<PV_MenuPermitT> Items, System.Data.SqlClient.SqlParameter[] MySqlParameterList = null, bool IsStoredProcedure = false)
        {
            ORMFactory orm = new ORMFactory();

            object retObj = orm.ReadViewDBListToObjs<PV_MenuPermitT>(ref Items, strSqlWhere, sqlParameterList: MySqlParameterList, isStoredProcedure: IsStoredProcedure);

            return retObj;
        }
        #endregion

        #region public static object ReadList(string strSqlWhere, string strOrderBy, ref List<PV_MenuPermitT> Items, int myPageSize = 10, int myPageIndex = 1, System.Data.SqlClient.SqlParameter[] MySqlParameterList = null, bool IsStoredProcedure = false)
        /// <summary>
        /// [ReadViewDBListToObjsByFetch](使用MSSQL 2014的分頁做法OFFSET FETCH ，效能佳, §注意 MSSQL2008 無法使用)
        /// 取得多筆PV_MenuPermitT資料 ReadList
        /// 只要指定的Sql欄位有對應至類別屬性，則自動繫結       
        /// </summary>
        /// <param name="strSqlWhere">SQL條件式 (不用加「where」關鑵字)</param>  
        /// <param name="strOrderBy">排序的欄位; 例: CreateDateTime desc </param> 
        /// <param name="Items"></param>     
        /// <param name="myPageSize">一頁的筆數,預設一頁 10 筆</param>  
        /// <param name="myPageIndex">從 0 起算，0即表示第1頁</param>  
        /// <param name="MySqlParameterList">Sql參數</param>
        /// <param name="IsStoredProcedure">是否為StoredProcedure ,true:是 ; false:否(預設值)</param>
        /// <returns></returns>
        public static object ReadList(string strSqlWhere, string strOrderBy, ref List<PV_MenuPermitT> Items, int myPageSize = 10, int myPageIndex = 1, System.Data.SqlClient.SqlParameter[] MySqlParameterList = null, bool IsStoredProcedure = false)
        {
            ORMFactory orm = new ORMFactory();
            int iTotalCountRows = 0;
            myPageIndex--;
            object retObj = null;
            try
            {
                retObj = orm.ReadViewDBListToObjsByFetch<PV_MenuPermitT>(myPageSize, myPageIndex, strOrderBy, ref Items, strSqlWhere, ref iTotalCountRows, sqlParameterList: MySqlParameterList, isStoredProcedure: IsStoredProcedure);
            }
            catch (InvalidCastException ex)
            {
                retObj = ex.Message;
            }

            return retObj;
        }
        #endregion

        #region #region public static object ReadList(string strSqlWhere, string strOrderBy, ref List<V_ProductTtest> Items, ref int iTotalCountRows, int myPageSize = 10, int myPageIndex = 0, System.Data.SqlClient.SqlParameter[] MySqlParameterList = null, bool IsStoredProcedure = false)
        /// <summary>
        /// [ReadViewDBListToObjsByFetch](使用MSSQL 2014的分頁做法OFFSET FETCH ，效能佳, §注意 MSSQL2008 無法使用)
        /// 取得多筆PV_MenuPermitT資料 ReadList
        /// 只要指定的Sql欄位有對應至類別屬性，則自動繫結       
        /// </summary>
        /// <param name="strSqlWhere">SQL條件式 (不用加「where」關鑵字)</param>  
        /// <param name="strOrderBy">排序的欄位; 例: CreateDateTime desc </param> 
        /// <param name="Items"></param>     
        /// <param name="iTotalCountRows">回傳此次查詢的總筆數</param>
        /// <param name="myPageSize">一頁的筆數,預設一頁 10 筆</param>  
        /// <param name="myPageIndex">當值為小於 0 時，預設帶 0 (從 0 起算，0即表示第1頁)</param>  
        /// <param name="MySqlParameterList">Sql參數</param>
        /// <param name="IsStoredProcedure">是否為StoredProcedure ,true:是 ; false:否(預設值)</param>
        /// <returns></returns>
        public static object ReadList(string strSqlWhere, string strOrderBy, ref List<PV_MenuPermitT> Items, ref int iTotalCountRows, int myPageSize = 10, int myPageIndex = 0, System.Data.SqlClient.SqlParameter[] MySqlParameterList = null, bool IsStoredProcedure = false)
        {
            ORMFactory orm = new ORMFactory();

            object retObj = null;
            try
            {
                retObj = orm.ReadViewDBListToObjsByFetch<PV_MenuPermitT>(myPageSize, myPageIndex, strOrderBy, ref Items, strSqlWhere, ref iTotalCountRows, sqlParameterList: MySqlParameterList, isStoredProcedure: IsStoredProcedure);
            }
            catch (InvalidCastException ex)
            {
                retObj = ex.Message;
            }

            return retObj;
        }
        #endregion

        #region [ReadViewDBListToObjsByFetch]多資料表join時使用 public static object ReadList(int myPageSize, int myPageIndex, string strOrderBy, string strSqlScript, ref List<PV_MenuPermitT> Items, ref int iTotalCountRows, System.Data.SqlClient.SqlParameter[] MySqlParameterList = null, bool IsStoredProcedure = false,string MyConnectionString="")
        /// <summary>
        /// [ReadViewDBListToObjsByFetch]多資料表join時使用，將結果繫結至Models (使用MSSQL 2014的分頁做法OFFSET FETCH ，效能佳, §注意 MSSQL2008 無法使用)
        /// </summary>
        /// <param name="myPageSize">一頁的筆數</param>
        /// <param name="myPageIndex">當值為小於 0 時，預設帶 0 (從 0 起算，0即表示第1頁)</param>
        /// <param name="strOrderBy">必要值(不得為空)，排序時需有指定排序的欄位, 例:「SiteKey desc , Account asc」</param>
        /// <param name="strSqlScript">提供完整的Sql Script 語法(注意select出來的資料需和物件的屬性對應)</param>
        /// <param name="Items"></param>
        /// <param name="iTotalCountRows">回傳此次查詢的總筆數</param>
        /// <param name="MySqlParameterList">Sql參數</param>
        /// <param name="IsStoredProcedure">是否為預存程序, 預設為False</param>
        /// <param name="MyConnectionString">預設為空字串，不為空字串時，以帶的連線字串為主; 若為空字串則以類別指定的連線字串( 當類別連線名稱為空則帶DBSetConnection.ConnectionListDefaultConnectionString )</param>
        /// <returns></returns>
        public static object ReadList(int myPageSize, int myPageIndex, string strOrderBy, string strSqlScript, ref List<PV_MenuPermitT> Items, ref int iTotalCountRows, System.Data.SqlClient.SqlParameter[] MySqlParameterList = null, bool IsStoredProcedure = false, string MyConnectionString = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = null;
            try
            {
                retObj = orm.ReadViewDBListToObjsByFetch<PV_MenuPermitT>(myPageSize, myPageIndex, strOrderBy, strSqlScript, ref Items, ref iTotalCountRows, sqlParameterList: MySqlParameterList, strConnectionString: MyConnectionString, isStoredProcedure: IsStoredProcedure);
            }
            catch (InvalidCastException ex)
            {
                retObj = ex.Message;
            }

            return retObj;
        }
        #endregion

        #endregion

    }
    #endregion  
}