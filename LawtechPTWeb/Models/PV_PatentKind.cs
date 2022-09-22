using H3Operator.DBHelper;
using H3Operator.DBModels;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace LawtechPTWeb.Models
{


    #region View PV_PatentKind Script
    [ViewTableMapping(@"SELECT          KindSN, Kind, SN,
                                (SELECT          COUNT(*) AS Expr1
                                  FROM               PatentManagementT
                                  WHERE           (ApplicantKeys = @ApplicantKeys) AND (Kind = KindT.KindSN)) AS COUNTs
FROM              KindT
WHERE          (OvertureKind = 'P')
GROUP BY   KindSN, Kind, SN
ORDER BY   SN")]
    public class PV_PatentKind
    {
        #region Public Property

        private string m_KindSN;
        [TableColumnSetting("KindSN", DbType = SqlDataType.NVarChar)]
        public string KindSN
        {
            get
            {
                return m_KindSN;
            }
            set
            {
                m_KindSN = value;
            }
        }

        private string m_Kind;
        [TableColumnSetting("Kind", DbType = SqlDataType.NVarChar)]
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

        private int m_SN;
        [TableColumnSetting("SN", DbType = SqlDataType.Int)]
        public int SN
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

        private int m_COUNTs;
        [TableColumnSetting("COUNTs", DbType = SqlDataType.Int)]
        public int COUNTs
        {
            get
            {
                return m_COUNTs;
            }
            set
            {
                m_COUNTs = value;
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
            object retObj = orm.ReadViewCountRows<PV_PatentKind>(ref iCountRows, strSqlWhere, sqlParameterList: sqlParameterList, isStoredProcedure: IsStoredProcedure);
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
            object retObj = orm.ReadViewCountRows<PV_PatentKind>(strSqlScript, ref iCountRows, sqlParameterList: sqlParameterList, strConnectionString: ConnectString, isStoredProcedure: IsStoredProcedure);
            return retObj;
        }
        #endregion

        #region 取得多筆PV_PatentKind資料 ReadList

       
        #region public static object ReadList( string strSqlWhere  ,ref List<PV_PatentKind> Items, System.Data.SqlClient.SqlParameter[] MySqlParameterList = null, bool IsStoredProcedure = false)
        /// <summary>
        /// 取得多筆PV_PatentKind資料 ReadList
        /// 只要指定的Sql欄位有對應至類別屬性，則自動繫結       
        /// </summary>
        /// <param name="strApplicantKeys"></param>  
        /// <param name="Items"></param>       
        /// <param name="MySqlParameterList"></param>
        /// <param name="IsStoredProcedure">是否為StoredProcedure ,true:是 ; false:否(預設值)</param>
        /// <returns></returns>
        public static object ReadList(string strApplicantKeys, ref List<PV_PatentKind> Items)
        {
            SqlParameter[] MySqlParameterList = { DBAccess.MakeInParam("ApplicantKeys", SqlDataType.VarChar, strApplicantKeys) };

            ORMFactory orm = new ORMFactory();

            object retObj = orm.ReadViewDBListToObjs<PV_PatentKind>(ref Items, sqlParameterList: MySqlParameterList);

            return retObj;
        }
        #endregion
                
        #endregion

    }
    #endregion  
}