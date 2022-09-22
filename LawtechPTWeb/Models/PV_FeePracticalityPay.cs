using H3Operator.DBHelper;
using H3Operator.DBModels;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace LawtechPTWeb.Models
{

    #region View PV_FeePracticalityPay Script
    [ViewTableMapping(@"select 'Pat' as TypeName,Sum(PracticalityPay) as TotalPracticalityPay
from V_PatentFeeSearch
where   PracticalityPay>0
and ApplicantNames like '%'+@ApplicantNames+'%' 
union ALL
select 'TM' as TypeName,Sum(PracticalityPay) as TotalPracticalityPay
from V_TrademarkFeeSearch
where  PracticalityPay>0
    and ApplicantNames like '%'+@ApplicantNames+'%' ")]
    public class PV_FeePracticalityPay
    {
        #region Public Property

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

        private decimal m_TotalPracticalityPay;
        [TableColumnSetting("TotalPracticalityPay", DbType = SqlDataType.Decimal)]
        public decimal TotalPracticalityPay
        {
            get
            {
                return m_TotalPracticalityPay;
            }
            set
            {
                m_TotalPracticalityPay = value;
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
            object retObj = orm.ReadViewCountRows<PV_FeePracticalityPay>(ref iCountRows, strSqlWhere, sqlParameterList: sqlParameterList, isStoredProcedure: IsStoredProcedure);
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
            object retObj = orm.ReadViewCountRows<PV_FeePracticalityPay>(strSqlScript, ref iCountRows, sqlParameterList: sqlParameterList, strConnectionString: ConnectString, isStoredProcedure: IsStoredProcedure);
            return retObj;
        }
        #endregion

        #region 取得多筆PV_FeePracticalityPay資料 ReadList

        #region  public static object ReadList(ref List<PV_FeePracticalityPay> Items, string strSqlScript = "", System.Data.SqlClient.SqlParameter[] MySqlParameterList = null, bool IsStoredProcedure = false)
        /// <summary>
        /// 取得多筆PV_FeePracticalityPay資料 ReadList
        /// 只要指定的Sql欄位有對應至類別屬性，則自動繫結       
        /// </summary>
        /// <param name="Items"></param>
        /// <param name="strSqlScript">完整的Sql Script語法</param>
        /// <param name="MySqlParameterList"></param>
        /// <param name="IsStoredProcedure">是否為StoredProcedure ,true:是 ; false:否(預設值) </param>
        /// <returns></returns>
        public static object ReadList(ref List<PV_FeePracticalityPay> Items, string strSqlScript = "", System.Data.SqlClient.SqlParameter[] MySqlParameterList = null, bool IsStoredProcedure = false)
        {
            ORMFactory orm = new ORMFactory();

            object retObj = orm.ReadViewDBListToObjs<PV_FeePracticalityPay>(strSqlScript, ref Items, sqlParameterList: MySqlParameterList, isStoredProcedure: IsStoredProcedure);

            return retObj;
        }
        #endregion

        #region public static object ReadList( string strSqlWhere  ,ref List<PV_FeePracticalityPay> Items, System.Data.SqlClient.SqlParameter[] MySqlParameterList = null, bool IsStoredProcedure = false)
        /// <summary>
        /// 取得多筆PV_FeePracticalityPay資料 ReadList
        /// 只要指定的Sql欄位有對應至類別屬性，則自動繫結       
        /// </summary>
        /// <param name="strApplicantKeys"></param>  
        /// <param name="Items"></param>       
        /// <param name="MySqlParameterList"></param>
        /// <param name="IsStoredProcedure">是否為StoredProcedure ,true:是 ; false:否(預設值)</param>
        /// <returns></returns>
        public static object ReadList(string strApplicantKeys, ref List<PV_FeePracticalityPay> Items)
        {
            SqlParameter[] MySqlParameterList = { DBAccess.MakeInParam("ApplicantNames", SqlDataType.VarChar, strApplicantKeys) };

            ORMFactory orm = new ORMFactory();

            object retObj = orm.ReadViewDBListToObjs<PV_FeePracticalityPay>(ref Items, sqlParameterList: MySqlParameterList);

            return retObj;
        }
        #endregion

      

              
        #endregion

    }
    #endregion  
}