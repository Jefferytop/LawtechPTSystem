using H3Operator.DBHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawtechPTSystem.Public
{
    /// <summary>
    /// 事務所公用類別
    /// </summary>
    public class CAttorneyPublicFunction
    {

        #region 取得事務所的資料 public static DataRow GetAttorneyTListDataRow(string strApplicantKey)
        /// <summary>
        /// 取得申請人的資料
        /// </summary>
        /// <param name="strAttorneyKey"></param>
        /// <returns></returns>
        public static DataRow GetAttorneyTListDataRow(string strAttorneyKey)
        {

            string strSQL = string.Format(@"SELECT *  from  AttorneyT with(nolock) where AttorneyKey= {0}", strAttorneyKey);

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

    }
}
