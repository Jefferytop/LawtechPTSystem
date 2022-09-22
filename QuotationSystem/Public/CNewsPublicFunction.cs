using H3Operator.DBHelper;
using System.Data;

namespace LawtechPTSystem.Public
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
            dbhelper.QueryToDataTableByDataAdapter(strSQL, ref dtNews, isFillSchema: false);

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
            dbhelper.QueryToDataTableByDataAdapter(strSQL, ref dtSource, isFillSchema: false);

            if (dtSource.PrimaryKey.Length == 0)
            {
                DataColumn[] pk = { dtSource.Columns["NewsKey"] };
                dtSource.PrimaryKey = pk;
            }
        }
        #endregion

        #region  取得公怖欄已閱讀者的資料  public static void GetNewsWorkerNameList(string strWhere, ref DataTable dtSource)
        /// <summary>
        /// 取得公怖欄已閱讀者的資料 
        /// </summary>
        /// <param name="strNewsKey"></param>
        /// <param name="workerKey"></param>
        /// <returns></returns>
        public static void GetNewsWorkerNameList(string strNewsKey, string workerKey,ref DataTable dtSource)
        {

            string strSQL = string.Format(@"SELECT    NewsWorkerT.NewsWorkerKey, WorkerT.EmployeeName, WorkerT.WorkerSymbol, 
                            WorkerT.WorkerKey
                            FROM    NewsWorkerT with(nolock)  INNER JOIN
                            WorkerT ON NewsWorkerT.WorkerKey = WorkerT.WorkerKey where   WorkerT.WorkerKey={0} and NewsWorkerT.NewsKey={1}", workerKey ,strNewsKey);

            DBAccess dbhelper = new DBAccess();
            dtSource.Rows.Clear();
            dbhelper.QueryToDataTableByDataAdapter(strSQL, ref dtSource, isFillSchema: false);

            if (dtSource.PrimaryKey.Length == 0)
            {
                DataColumn[] pk = { dtSource.Columns["WorkerKey"] };
                dtSource.PrimaryKey = pk;
            }
        }
        #endregion


    }
}
