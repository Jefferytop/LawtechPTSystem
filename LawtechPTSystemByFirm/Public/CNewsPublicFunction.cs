using H3Operator.DBHelper;
using System.Data;

namespace LawtechPTSystemByFirm.Public
{
    class CNewsPublicFunction
    {
        #region 取得公怖欄的資料 public static DataRow GetNewsDataRow(string strNewsKey)
        /// <summary>
        /// 取得公怖欄的資料 V_NewsList
        /// </summary>
        /// <param name="strNewsKey"></param>
        /// <returns></returns>
        public static DataRow GetNewsDataRow(string strNewsKey)
        {

            string strSQL = string.Format(@"SELECT *  from  V_NewsList where NewsKey= {0}", strNewsKey);

            DBAccess dbhelper = new DBAccess();
            System.Data.DataTable dtNews = new System.Data.DataTable();
            dbhelper.QueryToDataTableByDataAdapter(strSQL, ref dtNews);

            if (dtNews.Rows.Count == 1)
            {
                return dtNews.Rows[0];
            }
            else
            {
                return null;
            }

        }
        #endregion


        #region  取得公怖欄的資料 V_NewsList public static void GetNewsList(string strWhere, ref DataTable dtSource)
        /// <summary>
        /// 取得公怖欄的資料 V_NewsList
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static void GetNewsList(string strWhere, ref DataTable dtSource)
        {

            string strSQL = string.Format(@"SELECT *  from  V_NewsList with(nolock)  {0}", !string.IsNullOrEmpty(strWhere.Trim()) ? " where " + strWhere : "");

            DBAccess dbhelper = new DBAccess();
            dtSource.Rows.Clear();
            dbhelper.QueryToDataTableByDataAdapter(strSQL, ref dtSource);

            if (dtSource.PrimaryKey.Length == 0)
            {
                DataColumn[] pk = { dtSource.Columns["NewsKey"] };
                dtSource.PrimaryKey = pk;
            }
        }
        #endregion
    }
}
