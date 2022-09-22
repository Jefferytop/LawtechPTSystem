using H3Operator.DBHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawtechPTSystemByFirm.Public
{
    /// <summary>
    /// 標準報價 公用取資料的類別
    /// </summary>
    public class CnTriffPublicFunction
    {

        #region 取得客戶報價的資料 public static DataRow GetClientFeeDataRow(string strClientFeeSN)
        /// <summary>
        /// 取得客戶報價的資料 V_ClientFeeDetail
        /// </summary>
        /// <param name="strClientFeeSN"></param>
        /// <returns></returns>
        public static DataRow GetClientFeeDataRow(string strClientFeeSN)
        {

            string strSQL = string.Format(@"SELECT *  from  V_ClientFeeDetail where ClientFeeSN= {0}", strClientFeeSN);

            DBAccess dbhelper = new DBAccess();
            System.Data.DataTable dtPatent = new System.Data.DataTable();
            dbhelper.QueryToDataTableByDataAdapter(strSQL, ref dtPatent);

            if (dtPatent.Rows.Count == 1)
            {
                return dtPatent.Rows[0];
            }
            else
            {
                return null;
            }

        }
        #endregion 


        // DataRow
        // *********************************
        // DataTable

        #region  取得客戶報價的資料 ClientFeeMF public static void GetPatentList(string strWhere, ref DataTable dtSource)
        /// <summary>
        /// 取得客戶報價的資料 ClientFeeMF
        /// </summary>
        /// <param name="strApplicantKey">報價對象 ApplicantMode=0 帶ApplicantKey ;ApplicantMode=1 帶AttorneyKey</param>
        /// <param name="strApplicantMode">報價模式 0.對客戶報價 1.對複代報價</param>
        /// <returns></returns>
        public static void GetClientFeeList(string strApplicantKey, string strApplicantMode, ref DataTable dtSource)
        {

            string strSQL = string.Format(@"SELECT *
                            FROM  V_ClientFee with(nolock)
                            where  ApplicantKey = {0} and ApplicantMode={1} ", strApplicantKey, strApplicantMode);

            DBAccess dbhelper = new DBAccess();
            dtSource.Rows.Clear();
            dbhelper.QueryToDataTableByDataAdapter(strSQL, ref dtSource);

            if (dtSource.PrimaryKey.Length == 0)
            {
                DataColumn[] pk = { dtSource.Columns["ClientFeeSN"] };
                dtSource.PrimaryKey = pk;
            }
        }
        #endregion


        #region  取得客戶報價明細的資料 ClientFeeMF public static void GetPatentList(string strWhere, ref DataTable dtSource)
        /// <summary>
        /// 取得客戶報價明細的資料 ClientFeeMF
        /// </summary>
        /// <param name="strApplicantKey">報價對象 ApplicantMode=0 帶ApplicantKey ;ApplicantMode=1 帶AttorneyKey</param>
        /// <param name="strCountrySymbol">國別代碼</param>
        /// <param name="strKindSN">種類</param>
        /// <param name="bLargeEntity">種類</param>
        /// <param name="strApplicantMode">報價模式 0.對客戶報價 1.對複代報價</param>
        /// <returns></returns>
        public static void GetClientFeeDetailList(string strApplicantKey, string strCountrySymbol, string strKindSN,string bLargeEntity, string strApplicantMode,ref DataTable dtSource)
        {

            string strSQL = string.Format(@"Select *
                                                From  V_ClientFeeDetail with(nolock)
                                                Where   ApplicantKey = {0} and Country = '{1}' and 
                                                        Kind = '{2}' and LargeEntity = {3} and ApplicantMode={4}  Order by Sort ", strApplicantKey, strCountrySymbol, strKindSN, bLargeEntity, strApplicantMode);

            DBAccess dbhelper = new DBAccess();
            dtSource.Rows.Clear();
            dbhelper.QueryToDataTableByDataAdapter(strSQL, ref dtSource);

            if (dtSource.PrimaryKey.Length == 0)
            {
                DataColumn[] pk = { dtSource.Columns["ClientFeeSN"] };
                dtSource.PrimaryKey = pk;
            }
        }
        #endregion

    }
}
