using H3Operator.DBHelper;
using H3Operator.DBModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace LawtechPTSystemByFirm.Public
{
    #region View V_OfficeRoleT Script
    [ViewTableMapping(@"SELECT    OfficeRole, OfficeRoleName, Sort FROM   OfficeRoleT ")]
    public class V_OfficeRoleT
    {
        #region Public Property

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

        private string m_OfficeRoleName;
        [TableColumnSetting("OfficeRoleName", DbType = SqlDataType.NVarChar)]
        public string OfficeRoleName
        {
            get
            {
                return m_OfficeRoleName;
            }
            set
            {
                m_OfficeRoleName = value;
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

        #endregion

        #region 取得多筆V_OfficeRoleT資料 ReadList
        /// <summary>
        /// 取得多筆V_OfficeRoleT資料 ReadList
        /// 只要指定的Sql欄位有對應至類別屬性，則自動繫結       
        /// </summary>
        /// <param name="Items"></param>
        /// <param name="strSqlScript">完整的Sql Script語法</param>
        /// <param name="MySqlParameterList"></param>
        /// <param name="IsStoredProcedure">是否為StoredProcedure ,true:是 ; false:否(預設值) </param>
        /// <returns></returns>
        public static object ReadViewTableList(ref List<V_OfficeRoleT> Items, string strSqlScript = "", System.Data.SqlClient.SqlParameter[] MySqlParameterList = null, bool IsStoredProcedure = false)
        {
            ORMFactory orm = new ORMFactory();

            object retObj = orm.ReadViewDBListToObjs<V_OfficeRoleT>(strSqlScript, ref Items, sqlParameterList: MySqlParameterList, isStoredProcedure: IsStoredProcedure);

            return retObj;
        }

        /// <summary>
        /// 取得多筆V_OfficeRoleT資料 ReadList
        /// 只要指定的Sql欄位有對應至類別屬性，則自動繫結        
        /// </summary>
        /// <param name="strSqlWhere">SQL條件式 (不用加「where」關鑵字)</param>  
        /// <param name="Items"></param>       
        /// <param name="MySqlParameterList"></param>
        /// <param name="IsStoredProcedure">是否為StoredProcedure ,true:是 ; false:否(預設值)</param>
        /// <returns></returns>
        public static object ReadViewTableList(string strSqlWhere, ref List<V_OfficeRoleT> Items, System.Data.SqlClient.SqlParameter[] MySqlParameterList = null, bool IsStoredProcedure = false)
        {
            ORMFactory orm = new ORMFactory();

            object retObj = orm.ReadViewDBListToObjs<V_OfficeRoleT>(ref Items, strSqlWhere, sqlParameterList: MySqlParameterList, isStoredProcedure: IsStoredProcedure);

            return retObj;
        }

        /// <summary>
        /// 取得多筆V_OfficeRoleT資料 ReadList
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
        public static object ReadViewTableList(string strSqlWhere, string strOrderBy, ref List<V_OfficeRoleT> Items, int myPageSize = 10, int myPageIndex = 1, System.Data.SqlClient.SqlParameter[] MySqlParameterList = null, bool IsStoredProcedure = false, bool WithDelete = false)
        {
            ORMFactory orm = new ORMFactory();

            StringBuilder sb = new StringBuilder();

            string strSqlQuerySchema = ((ViewTableMappingAttribute)Attribute.GetCustomAttribute(typeof(V_OfficeRoleT), typeof(ViewTableMappingAttribute))).SqlQuerySchema.Replace("#Top", "Top(V_OfficeRoleT*{1})").Replace("#RankNumber", " ROW_Number() OVER (order by {2} ) AS RankNumber, ");

            strSqlQuerySchema = string.Format(strSqlQuerySchema.Replace("SELECT", "select ROW_Number() OVER (order by V_OfficeRoleT ) AS RankNumber, "), strOrderBy);

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
                retObj = orm.ReadViewDBListToObjs<V_OfficeRoleT>(strSQL, ref Items, sqlParameterList: MySqlParameterList, isStoredProcedure: IsStoredProcedure);
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
