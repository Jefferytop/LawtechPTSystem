using H3Operator.DBHelper;
using System.Data;

namespace LawtechPTSystem.Public
{
    /// <summary>
    /// 國別公用類別
    /// </summary>
    public class CCountryPublicFunction
    {
        #region 取得國別的資料  public static void GetApplicantTList(string strWhere, ref DataTable dtSource)
       /// <summary>
        /// 取得國別的資料 CountrySymbol, CountrySymbol+Country as CountryName
       /// </summary>
       /// <param name="dtSource"></param>
       /// <param name="iEnable">1:啟用 ; 0:不啟用 ; -1:All</param>
        /// <param name="language">Country:繁 ; CountryEn:英 ; CountrySimp:簡</param>
        public static void GetCountryList(ref DataTable dtSource, int iEnable = 1, string language = "")
        {
            string striEnable = "";
            if (iEnable == 1)
            {
                striEnable = "where IsEnable=1";
            }
            else if (iEnable == 0)
            {
                striEnable = "where IsEnable=0";
            }

            string strLang = "";
            if (language == "")
            {
                strLang = "Country";
            }
            else 
            {
                strLang = language;
            }

            string strSQL = string.Format(@"SELECT CountrySymbol,CountrySymbol+{1} as CountryName from  CountryT  with(nolock) {0} order by sn ", striEnable, strLang);

            DBAccess dbhelper = new DBAccess();
            dtSource.Rows.Clear();
            dbhelper.QueryToDataTableByDataAdapter(strSQL, ref dtSource, isFillSchema: false);

            if (dtSource.PrimaryKey.Length == 0)
            {
                DataColumn[] pk = { dtSource.Columns["CountrySymbol"] };
                dtSource.PrimaryKey = pk;
            }
        }
        #endregion

        #region 取得國別的資料  public static void GetApplicantTList(string strWhere, ref DataTable dtSource)
        /// <summary>
        /// 取得國別的資料 CountrySymbol, CountrySymbol+Country as CountryName
        /// </summary>
        /// <param name="dtSource"></param>
        /// <param name="iEnable">1:啟用 ; 0:不啟用 ; -1:All</param>        
        public static void GetCountryAllList(ref DataTable dtSource, int iEnable = -1)
        {
            string striEnable = "";
            if (iEnable == 1)
            {
                striEnable = "where IsEnable=1";
            }
            else if (iEnable == 0)
            {
                striEnable = "where IsEnable=0";
            }
            
            string strSQL = string.Format(@"SELECT CountrySymbol, Country, SN, CountryEn, CountrySimp, IsEnable, CreateDateTime, LastModifyDateTime
 from  CountryT  with(nolock) {0} order by sn ", striEnable);

            DBAccess dbhelper = new DBAccess();
            dtSource.Rows.Clear();
            dbhelper.QueryToDataTableByDataAdapter(strSQL, ref dtSource, isFillSchema: false);

            if (dtSource.PrimaryKey.Length == 0)
            {
                DataColumn[] pk = { dtSource.Columns["CountrySymbol"] };
                dtSource.PrimaryKey = pk;
            }
        }
        #endregion

        #region 取得國籍的資料  public static void GetApplicantTList(string strWhere, ref DataTable dtSource)
        /// <summary>
        /// 取得國別的資料 CountrySymbol, CountrySymbol+Country as CountryName
        /// </summary>
        /// <param name="dtSource"></param>             
        public static void GetCountryCitizenshipAllList(ref DataTable dtSource)
        {    
            string strSQL = string.Format(@"SELECT CountrySymbol+'  '+Country as CountrySymbol
 from  CountryT  with(nolock) order by sn ");

            DBAccess dbhelper = new DBAccess();
            dtSource.Rows.Clear();
            dbhelper.QueryToDataTableByDataAdapter(strSQL, ref dtSource, isFillSchema: false);

            if (dtSource.PrimaryKey.Length == 0)
            {
                DataColumn[] pk = { dtSource.Columns["CountrySymbol"] };
                dtSource.PrimaryKey = pk;
            }
        }
        #endregion
    }
}
