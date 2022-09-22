using H3Operator.DBHelper;
using H3Operator.DBModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace LawtechPTWeb.Models
{

    #region View PV_TopPatentTrademark Script
    [ViewTableMapping(@"SELECT          TOP (5) PatentID as ID, PatentNo as Symbol, Title, LastModifyDateTime,'Pat' as TypeName
FROM              PatentManagementT
where ApplicantKeys=@ApplicantKeys
union all
SELECT          TOP (5) TrademarkID as ID , TrademarkNo as Symbol, TrademarkName as Title, LastModifyDateTime,'TM' as TypeName
FROM              TrademarkManagementT
where ApplicantKeys=@ApplicantKeys
ORDER BY   LastModifyDateTime DESC")]
    public class PV_TopPatentTrademark
    {
        #region Public Property

        private int m_ID;
        [TableColumnSetting("ID", DbType = SqlDataType.Int)]
        public int ID
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

        private string m_Symbol;
        [TableColumnSetting("Symbol", DbType = SqlDataType.NVarChar)]
        public string Symbol
        {
            get
            {
                return m_Symbol;
            }
            set
            {
                m_Symbol = value;
            }
        }

        private string m_Title;
        [TableColumnSetting("Title", DbType = SqlDataType.NVarChar)]
        public string Title
        {
            get
            {
                return m_Title;
            }
            set
            {
                m_Title = value;
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

        private string m_TypeName;
        [TableColumnSetting("TypeName", DbType = SqlDataType.NVarChar)]
        public string TypeName
        {
            get
            {
                return m_TypeName;
            }
            set
            {
                m_TypeName = value;
            }
        }

        #endregion

        #region [GetTotalCountRows]多資料表join時使用，回傳查詢後的總筆數 public static object GetTotalCountRows(ref int iCountRows, string strSqlWhere = ", System.Data.SqlClient.SqlParameter[] sqlParameterList = null, string strCusTableName = "")
        /// <summary>
        /// [GetTotalCountRows]多資料表join時使用，回傳查詢後的總筆數
        /// </summary>
        /// <param name="iCountRows">回傳此次查詢的總筆數</param>
        /// <param name="strSqlWhere">SQL條件式 (不用加「where」關鑵字)</param>
        /// <param name="sqlParameterList">Sql參數</param>
        /// <param name="IsStoredProcedure">是否為預存程序, 預設為False</param>
        /// <returns></returns>
        public static object GetTotalCountRows(ref int iCountRows, string strSqlWhere = "", System.Data.SqlClient.SqlParameter[] sqlParameterList = null, bool IsStoredProcedure = false)
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.ReadViewCountRows<PV_TopPatentTrademark>(ref iCountRows, strSqlWhere, sqlParameterList: sqlParameterList, isStoredProcedure: IsStoredProcedure);
            return retObj;
        }

        /// <summary>
        /// [GetTotalCountRows]多資料表join時使用，回傳查詢後的總筆數
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
            object retObj = orm.ReadViewCountRows<PV_TopPatentTrademark>(strSqlScript, ref iCountRows, sqlParameterList: sqlParameterList, strConnectionString: ConnectString, isStoredProcedure: IsStoredProcedure);
            return retObj;
        }
        #endregion

        #region 取得多筆PV_TopPatentTrademark資料 ReadList

     
        #region public static object ReadList( string strSqlWhere  ,ref List<PV_TopPatentTrademark> Items, System.Data.SqlClient.SqlParameter[] MySqlParameterList = null, bool IsStoredProcedure = false)
        /// <summary>
        /// 取得多筆PV_TopPatentTrademark資料 ReadList
        /// 只要指定的Sql欄位有對應至類別屬性，則自動繫結       
        /// </summary>
        /// <param name="strApplicantKeys"></param>  
        /// <param name="Items"></param>       
        /// <param name="MySqlParameterList"></param>
        /// <param name="IsStoredProcedure">是否為StoredProcedure ,true:是 ; false:否(預設值)</param>
        /// <returns></returns>
        public static object ReadList(string strApplicantKeys, ref List<PV_TopPatentTrademark> Items)
        {
            SqlParameter[] MySqlParameterList = { DBAccess.MakeInParam("ApplicantKeys", SqlDataType.VarChar, strApplicantKeys) };

            ORMFactory orm = new ORMFactory();

            object retObj = orm.ReadViewDBListToObjs<PV_TopPatentTrademark>(ref Items, sqlParameterList: MySqlParameterList);

            return retObj;
        }
        #endregion

      
       
        #endregion

    }
    #endregion  
}