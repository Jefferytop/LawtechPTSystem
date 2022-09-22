using H3Operator.DBHelper;
using System.Data;

namespace LawtechPTSystem.Public
{
    public class COfficialDocumentPublicFunction
    {

        #region GetOfficialDocumentT 取得公文的資料
        /// <summary>
        /// 取得公文的資料
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static DataRow GetOfficialDocumentTDataRow(string strOfficialDocumentKey)
        {
            string strSQL = string.Format(@"SELECT *  from  V_OfficialDocumentT with(nolock)  where OfficialDocumentKey={0}", strOfficialDocumentKey);

            DBAccess dbhelper = new DBAccess();
            System.Data.DataTable dtTrademarkWorkReport = new System.Data.DataTable();
            dbhelper.QueryToDataTableByDataAdapter(strSQL, ref dtTrademarkWorkReport, isFillSchema: false);
            if (dtTrademarkWorkReport.Rows.Count == 1)
            {
                return dtTrademarkWorkReport.Rows[0];
            }
            else
            {
                return null;
            }
        }
        #endregion


        #region GetOfficialDocumentT 取得公文的資料
        /// <summary>
        /// 取得公文的資料
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static DataTable GetOfficialDocumentT(string strWhere)
        {

            string strEventSQL = string.Format(@"SELECT *  from  V_OfficialDocumentT with(nolock)  {0}", !string.IsNullOrEmpty(strWhere) ? " where " + strWhere : "");

            Public.DLL dll = new Public.DLL();
            System.Data.DataTable dtComitEvent = new System.Data.DataTable();
            dll.FetchDataTable(strEventSQL, dtComitEvent);
            if (dtComitEvent.PrimaryKey.Length == 0)
            {
                DataColumn[] pk = { dtComitEvent.Columns["OfficialDocumentKey"] };
                dtComitEvent.PrimaryKey = pk;
            }
            return dtComitEvent;
        }
        #endregion


    }
}
