using H3Operator.DBHelper;
using System.Data;

namespace LawtechPTSystem.Public
{
    /// <summary>
    /// 申請人(客戶)公用類別
    /// </summary>
    public class CApplicantPublicFunction
    {
        #region 取得申請人的資料 public static DataRow GetApplicantListDataRow(string strApplicantKey)
        /// <summary>
        /// 取得申請人的資料
        /// </summary>
        /// <param name="strApplicantKey"></param>
        /// <returns></returns>
        public static DataRow GetApplicantListDataRow(string strApplicantKey)
        {

            string strSQL = string.Format(@"SELECT *  from  V_ApplicantT with(nolock) where ApplicantKey= {0}", strApplicantKey);

            DBAccess dbhelper = new DBAccess();
            System.Data.DataTable dtApplicant = new System.Data.DataTable();
            dbhelper.QueryToDataTableByDataAdapter(strSQL, ref dtApplicant, isFillSchema: false);

            if (dtApplicant.Rows.Count == 1)
            {
                return dtApplicant.Rows[0];
            }
            else
            {
                return null;
            }

        }
        #endregion 

        #region 取得客戶聯絡人的資料 public static DataRow GetLiaisonerDataRow(string strLiaisonerKey)
        /// <summary>
        /// 取得客戶聯絡人的資料
        /// </summary>
        /// <param name="strLiaisonerKey"></param>
        /// <returns></returns>
        public static DataRow GetLiaisonerDataRow(string strLiaisonerKey)
        {

            string strSQL = string.Format(@"SELECT *  from  V_LiaisonerSreachT with(nolock)  where LiaisonerKey= {0}", strLiaisonerKey);

            DBAccess dbhelper = new DBAccess();
            System.Data.DataTable dtApplicant = new System.Data.DataTable();
            dbhelper.QueryToDataTableByDataAdapter(strSQL, ref dtApplicant, isFillSchema: false);

            if (dtApplicant.Rows.Count == 1)
            {
                return dtApplicant.Rows[0];
            }
            else
            {
                return null;
            }

        }
        #endregion 

        #region 取得客戶發明人的資料 public static DataRow GetLiaisonerDataRow(string strLiaisonerKey)
        /// <summary>
        /// 取得客戶發明人的資料
        /// </summary>
        /// <param name="strInventorKey"></param>
        /// <returns></returns>
        public static DataRow GetInventorDataRow(string strInventorKey)
        {

            string strSQL = string.Format(@"SELECT *  from  InventorT with(nolock)  where InventorKey= {0}", strInventorKey);

            DBAccess dbhelper = new DBAccess();
            System.Data.DataTable dtApplicant = new System.Data.DataTable();
            dbhelper.QueryToDataTableByDataAdapter(strSQL, ref dtApplicant, isFillSchema: false);

            if (dtApplicant.Rows.Count == 1)
            {
                return dtApplicant.Rows[0];
            }
            else
            {
                return null;
            }

        }
        #endregion 

        #region 取得客戶來往記錄的資料 public static DataRow GetCustomerTrackingRecordDataRow(string strTrackingRecordKey)
        /// <summary>
        /// 取得客戶來往記錄的資料
        /// </summary>
        /// <param name="strTrackingRecordKey"></param>
        /// <returns></returns>
        public static DataRow GetCustomerTrackingRecordDataRow(string strTrackingRecordKey)
        {
            string strSQL = string.Format(@"SELECT *  from  CustomerTrackingRecordT with(nolock) where TrackingRecordKey= {0}", strTrackingRecordKey);

            DBAccess dbhelper = new DBAccess();
            System.Data.DataTable dtApplicant = new System.Data.DataTable();
            dbhelper.QueryToDataTableByDataAdapter(strSQL, ref dtApplicant, isFillSchema: false);

            if (dtApplicant.Rows.Count == 1)
            {
                return dtApplicant.Rows[0];
            }
            else
            {
                return null;
            }

        }
        #endregion 



        #region 取得申請人的資料  public static void GetApplicantTList(string strWhere, ref DataTable dtSource)
        /// <summary>
        /// 取得申請人的資料
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static void GetApplicantTList(string strWhere, ref DataTable dtSource)
        {

            string strSQL = string.Format(@"SELECT *  from  V_ApplicantT with(nolock)  {0}", !string.IsNullOrEmpty(strWhere.Trim()) ? " where " + strWhere : "");

            DBAccess dbhelper = new DBAccess();
            dtSource.Rows.Clear();
            dbhelper.QueryToDataTableByDataAdapter(strSQL, ref dtSource,isFillSchema:false);

            if (dtSource.PrimaryKey.Length == 0)
            {
                DataColumn[] pk = { dtSource.Columns["ApplicantKey"] };
                dtSource.PrimaryKey = pk;
            }
        }
        #endregion

        #region  取得客戶聯絡人的資料  public static void GetLiaisoner(string strApplicantKey, ref DataTable dtSource)
        /// <summary>
        /// 取得客戶聯絡人的資料
        /// </summary>
        /// <param name="strApplicantKey"></param>
        /// <returns></returns>
        public static void GetLiaisoner(string strApplicantKey, ref DataTable dtSource)
        {
            string strSQL = string.Format(@"SELECT * from  V_LiaisonerSreachT where ApplicantKey={0}", strApplicantKey);

            DBAccess dbhelper = new DBAccess();
            dtSource.Rows.Clear();
            dbhelper.QueryToDataTableByDataAdapter(strSQL, ref dtSource, isFillSchema: false);

            if (dtSource.PrimaryKey.Length == 0)
            {
                DataColumn[] pk = { dtSource.Columns["LiaisonerKey"] };
                dtSource.PrimaryKey = pk;
            }
        }
        #endregion

        #region  取得客戶聯絡人-請款窗口的資料  public static void GetLiaisonerContractTypeT(string strApplicantKey, ref DataTable dtSource)
        /// <summary>
        /// 取得客戶聯絡人-請款窗口的資料
        /// </summary>
        /// <param name="strApplicantKey"></param>
        /// <returns></returns>
        public static void GetLiaisonerContractTypeT(string strApplicantKey, ref DataTable dtSource)
        {
            string strSQL = string.Format(@"SELECT * from  V_LiaisonerSreachT where  ApplicantKey={0} and Quit='False' and isWindows=4 ", strApplicantKey);

            DBAccess dbhelper = new DBAccess();
            dtSource.Rows.Clear();
            dbhelper.QueryToDataTableByDataAdapter(strSQL, ref dtSource, isFillSchema: false);

            if (dtSource.PrimaryKey.Length == 0)
            {
                DataColumn[] pk = { dtSource.Columns["LiaisonerKey"] };
                dtSource.PrimaryKey = pk;
            }
        }
        #endregion

        #region  取得客戶發明人的資料 public static void GetInventorT(string strApplicantKey, ref DataTable dtSource)
        /// <summary>
        /// 取得客戶發明人的資料
        /// </summary>
        /// <param name="strApplicantKey"></param>
        /// <returns></returns>
        public static void GetInventorT(string strApplicantKey, ref DataTable dtSource)
        {
            string strSQL = string.Format(@"SELECT * from  InventorT where ApplicantKey={0}", strApplicantKey);

            DBAccess dbhelper = new DBAccess();
            dtSource.Rows.Clear();
            dbhelper.QueryToDataTableByDataAdapter(strSQL, ref dtSource, isFillSchema: false);

            if (dtSource.PrimaryKey.Length == 0)
            {
                DataColumn[] pk = { dtSource.Columns["InventorKey"] };
                dtSource.PrimaryKey = pk;
            }
        }
        #endregion

        #region  取得客戶來往記錄的資料 public static void GetCustomerTrackingRecordT(string strApplicantKey, ref DataTable dtSource)
        /// <summary>
        /// 取得客戶來往記錄的資料
        /// </summary>
        /// <param name="strApplicantKey"></param>
        /// <returns></returns>
        public static void GetCustomerTrackingRecordT(string strApplicantKey, ref DataTable dtSource)
        {
            string strSQL = string.Format(@"SELECT * from  CustomerTrackingRecordT where ApplicantKey={0}", strApplicantKey);

            DBAccess dbhelper = new DBAccess();
            dtSource.Rows.Clear();
            dbhelper.QueryToDataTableByDataAdapter(strSQL, ref dtSource, isFillSchema: false);

            if (dtSource.PrimaryKey.Length == 0)
            {
                DataColumn[] pk = { dtSource.Columns["TrackingRecordKey"] };
                dtSource.PrimaryKey = pk;
            }
        }
        #endregion

        #region 取得申請人未完成請款的資料  public static void GetApplicantTList(string strWhere, ref DataTable dtSource)
        /// <summary>
        /// 取得申請人未完成請款的資料
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static void GetNoFinishFeeApplicationList(string strWhere, ref DataSet dtSource)
        {

            string strSQL = string.Format(@"SELECT *  from  V_NoFinishFeeApplication  with(nolock)  {0} ;
                                                                          select SUM(TotalNT)as SumTotalNT from V_NoFinishFeeApplication with(nolock)  {0}", !string.IsNullOrEmpty(strWhere.Trim()) ? " where " + strWhere : "");

            DBAccess dbhelper = new DBAccess();
            dtSource.Tables.Clear();
            dbhelper.QueryToDataSetByDataAdapter(strSQL, ref dtSource,"");

            if (dtSource.Tables[0].PrimaryKey.Length == 0)
            {
                DataColumn[] pk = { dtSource.Tables[0].Columns["CaseType"], dtSource.Tables[0].Columns["CaseKey"], dtSource.Tables[0].Columns["FeeKey"] };
                dtSource.Tables[0].PrimaryKey = pk;
            }
        }
        #endregion

    }
}
