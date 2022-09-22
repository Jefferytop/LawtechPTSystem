using System;
using System.Collections.Generic;
using System.Text;
using H3Operator.DBHelper;
using H3Operator.DBModels;


namespace LawtechPTSystemByFirm
{


    #region View ViewModel_WorkerProgram Script
    [ViewTableMapping(@"SELECT     WorkerProgramT.PWID, WorkerProgramT.ProgramKEY, WorkerProgramT.WorkerKEY, WorkerProgramT.SearchAuthority, ProgramT.ProgramName, 
                      ProgramT.ProgramSymbol, ProgramT.ProgramKind, WorkerProgramT.AuthorizeCreate, WorkerProgramT.AuthorizeModify, WorkerProgramT.AuthorizeDelete, 
                      WorkerProgramT.AuthorizeExport, WorkerProgramT.AuthorizeUpload, WorkerProgramT.AuthorizeDownload
                        FROM   WorkerProgramT with(nolock) LEFT OUTER JOIN
                      ProgramT ON WorkerProgramT.ProgramKEY = ProgramT.ProgramKEY")]
    public class ViewModel_WorkerProgram
    {
        #region Public Property

        private int m_PWID;
        [TableColumnSetting("PWID", DbType = SqlDataType.Int)]
        public int PWID
        {
            get
            {
                return m_PWID;
            }
            set
            {
                m_PWID = value;
            }
        }

        private int m_ProgramKEY;
        [TableColumnSetting("ProgramKEY", DbType = SqlDataType.Int)]
        public int ProgramKEY
        {
            get
            {
                return m_ProgramKEY;
            }
            set
            {
                m_ProgramKEY = value;
            }
        }

        private int m_WorkerKEY;
        [TableColumnSetting("WorkerKEY", DbType = SqlDataType.Int)]
        public int WorkerKEY
        {
            get
            {
                return m_WorkerKEY;
            }
            set
            {
                m_WorkerKEY = value;
            }
        }

        private bool m_SearchAuthority;
        [TableColumnSetting("SearchAuthority", DbType = SqlDataType.Bit)]
        public bool SearchAuthority
        {
            get
            {
                return m_SearchAuthority;
            }
            set
            {
                m_SearchAuthority = value;
            }
        }

        private string m_ProgramName;
        [TableColumnSetting("ProgramName", DbType = SqlDataType.NVarChar)]
        public string ProgramName
        {
            get
            {
                return m_ProgramName;
            }
            set
            {
                m_ProgramName = value;
            }
        }

        private string m_ProgramSymbol;
        [TableColumnSetting("ProgramSymbol", DbType = SqlDataType.NVarChar)]
        public string ProgramSymbol
        {
            get
            {
                return m_ProgramSymbol;
            }
            set
            {
                m_ProgramSymbol = value;
            }
        }

        private int m_ProgramKind;
        [TableColumnSetting("ProgramKind", DbType = SqlDataType.Int)]
        public int ProgramKind
        {
            get
            {
                return m_ProgramKind;
            }
            set
            {
                m_ProgramKind = value;
            }
        }

        private bool m_AuthorizeCreate;
        [TableColumnSetting("AuthorizeCreate", DbType = SqlDataType.Bit)]
        public bool AuthorizeCreate
        {
            get
            {
                return m_AuthorizeCreate;
            }
            set
            {
                m_AuthorizeCreate = value;
            }
        }

        private bool m_AuthorizeModify;
        [TableColumnSetting("AuthorizeModify", DbType = SqlDataType.Bit)]
        public bool AuthorizeModify
        {
            get
            {
                return m_AuthorizeModify;
            }
            set
            {
                m_AuthorizeModify = value;
            }
        }

        private bool m_AuthorizeDelete;
        [TableColumnSetting("AuthorizeDelete", DbType = SqlDataType.Bit)]
        public bool AuthorizeDelete
        {
            get
            {
                return m_AuthorizeDelete;
            }
            set
            {
                m_AuthorizeDelete = value;
            }
        }

        private bool m_AuthorizeExport;
        [TableColumnSetting("AuthorizeExport", DbType = SqlDataType.Bit)]
        public bool AuthorizeExport
        {
            get
            {
                return m_AuthorizeExport;
            }
            set
            {
                m_AuthorizeExport = value;
            }
        }

        private bool m_AuthorizeUpload;
        [TableColumnSetting("AuthorizeUpload", DbType = SqlDataType.Bit)]
        public bool AuthorizeUpload
        {
            get
            {
                return m_AuthorizeUpload;
            }
            set
            {
                m_AuthorizeUpload = value;
            }
        }

        private bool m_AuthorizeDownload;
        [TableColumnSetting("AuthorizeDownload", DbType = SqlDataType.Bit)]
        public bool AuthorizeDownload
        {
            get
            {
                return m_AuthorizeDownload;
            }
            set
            {
                m_AuthorizeDownload = value;
            }
        }

        #endregion

        #region 取得多筆ViewModel_WorkerProgram資料 ReadList
        /// <summary>
        /// 取得多筆ViewModel_WorkerProgram資料 ReadList
        /// 只要指定的Sql欄位有對應至類別屬性，則自動繫結       
        /// </summary>
        /// <param name="Items"></param>
        /// <param name="strSqlScript">完整的Sql Script語法</param>
        /// <param name="MySqlParameterList"></param>
        /// <param name="IsStoredProcedure">是否為StoredProcedure ,true:是 ; false:否(預設值) </param>
        /// <returns></returns>
        public static object ReadViewTableList(ref List<ViewModel_WorkerProgram> Items, string strSqlScript = "", System.Data.SqlClient.SqlParameter[] MySqlParameterList = null, bool IsStoredProcedure = false)
        {
            ORMFactory orm = new ORMFactory();

            object retObj = orm.ReadViewDBListToObjs<ViewModel_WorkerProgram>(strSqlScript, ref Items, sqlParameterList: MySqlParameterList, isStoredProcedure: IsStoredProcedure);

            return retObj;
        }

        /// <summary>
        /// 取得多筆ViewModel_WorkerProgram資料 ReadList
        /// 只要指定的Sql欄位有對應至類別屬性，則自動繫結        
        /// </summary>
        /// <param name="strSqlWhere">SQL條件式 (不用加「where」關鑵字)</param>  
        /// <param name="Items"></param>       
        /// <param name="MySqlParameterList"></param>
        /// <param name="IsStoredProcedure">是否為StoredProcedure ,true:是 ; false:否(預設值)</param>
        /// <returns></returns>
        public static object ReadViewTableList(string strSqlWhere, ref List<ViewModel_WorkerProgram> Items, System.Data.SqlClient.SqlParameter[] MySqlParameterList = null, bool IsStoredProcedure = false)
        {
            ORMFactory orm = new ORMFactory();

            object retObj = orm.ReadViewDBListToObjs<ViewModel_WorkerProgram>(ref Items, strSqlWhere, sqlParameterList: MySqlParameterList, isStoredProcedure: IsStoredProcedure);

            return retObj;
        }

        /// <summary>
        /// 取得多筆ViewModel_WorkerProgram資料 ReadList
        /// 只要指定的Sql欄位有對應至類別屬性，則自動繫結        
        /// </summary>
        /// <param name="strSqlWhere">SQL條件式 (不用加「where」關鑵字)</param>  
        /// <param name="strOrderBy">排序的欄位</param> 
        /// <param name="Items"></param>     
        /// <param name="myPageSize">一頁的筆數,預設一頁 10 筆</param>  
        /// <param name="myPageIndex">第 n 頁,預設第一頁</param>  
        /// <param name="MySqlParameterList"></param>
        /// <param name="IsStoredProcedure">是否為StoredProcedure ,true:是 ; false:否(預設值)</param>
        /// <returns></returns>
        public static object ReadViewTableList(string strSqlWhere, string strOrderBy, ref List<ViewModel_WorkerProgram> Items, int myPageSize = 10, int myPageIndex = 1, System.Data.SqlClient.SqlParameter[] MySqlParameterList = null, bool IsStoredProcedure = false, bool WithDelete = false)
        {
            ORMFactory orm = new ORMFactory();

            StringBuilder sb = new StringBuilder();

            string strSqlQuerySchema = ((ViewTableMappingAttribute)Attribute.GetCustomAttribute(typeof(ViewModel_WorkerProgram), typeof(ViewTableMappingAttribute))).SqlQuerySchema.Replace("#Top", "Top(ViewModel_WorkerProgram*{1})").Replace("#RankNumber", " ROW_Number() OVER (order by {2} ) AS RankNumber, ");

            strSqlQuerySchema = string.Format(strSqlQuerySchema.Replace("SELECT", "select ROW_Number() OVER (order by ViewModel_WorkerProgram ) AS RankNumber, "), strOrderBy);

            sb.Append(string.Format(strSqlQuerySchema, myPageSize, myPageIndex, strOrderBy));

            if (strSqlWhere != null && strSqlWhere != "")
            {
                sb.Append(" Where " + strSqlWhere);
            }

            string myRange = "";
            //搜尋範圍(預設為第1頁)            
            if (myPageIndex == 1 || myPageIndex <= 0)
            {
                myRange = string.Format("{0}*({1}-1) and {0}*{1}", myPageSize, myPageIndex);
            }
            else
            {

                myRange = string.Format("{0}*({1}-1)+1 and {0}*{1}", myPageSize, myPageIndex);
            }

            string strSQL = string.Format("Select Top {2} * from({0} ) as QueryT where RankNumber between {1}", sb.ToString(), myRange, myPageSize);

            object retObj = null;
            try
            {
                retObj = orm.ReadViewDBListToObjs<ViewModel_WorkerProgram>(strSQL, ref Items, sqlParameterList: MySqlParameterList, isStoredProcedure: IsStoredProcedure);
            }
            catch (InvalidCastException ex)
            {
                retObj = ex.Message;
            }

            return retObj;
        }

        #endregion

    }
    #endregion  
}
