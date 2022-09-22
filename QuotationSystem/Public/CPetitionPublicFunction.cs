using H3Operator.DBHelper;
using System.Data;

namespace LawtechPTSystem.Public
{
    public class CPetitionPublicFunction
    {
        #region 取得申請需知的資料 public static DataRow GetPetitionDataRow(string strPatentID)
        /// <summary>
        /// 取得申請需知的資料 PetitionT
        /// </summary>
        /// <param name="strPID"></param>
        /// <returns></returns>
        public static DataRow GetPetitionDataRow(string strPID)
        {

            string strSQL = string.Format(@"SELECT *  from  PetitionT where PID= {0}", strPID);

            DBAccess dbhelper = new DBAccess();
            System.Data.DataTable dtPetition = new System.Data.DataTable();
            dbhelper.QueryToDataTableByDataAdapter(strSQL, ref dtPetition, isFillSchema: false);

            if (dtPetition.Rows.Count == 1)
            {
                return dtPetition.Rows[0];
            }
            else
            {
                return null;
            }

        }
        #endregion 


        #region  取得申請需知的資料 PetitionT public static void GetPetition(string strWhere, ref DataTable dtSource)
        /// <summary>
        /// 取得申請需知的資料 PetitionT
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static void GetPetition(string strWhere, ref DataTable dtSource)
        {

            string strSQL = string.Format(@"SELECT *  from  PetitionT with(nolock)  {0}", !string.IsNullOrEmpty(strWhere.Trim()) ? " where " + strWhere : "");

            DBAccess dbhelper = new DBAccess();
            dtSource.Rows.Clear();
            dbhelper.QueryToDataTableByDataAdapter(strSQL, ref dtSource, isFillSchema: false);

            if (dtSource.PrimaryKey.Length == 0)
            {
                DataColumn[] pk = { dtSource.Columns["PID"] };
                dtSource.PrimaryKey = pk;
            }
        }
        #endregion
    }

}
