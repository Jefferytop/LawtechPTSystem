using H3Operator.DBHelper;
using System.Data;

namespace LawtechPTSystem.Public
{

    public class CMacSettingPublicFunction
    {
        #region 取得MAC的資料 public static DataRow GetMacSettingListDataRow(string strApplicantKey)
        /// <summary>
        /// 取得MAC的資料
        /// </summary>
        /// <param name="strMACkey"></param>
        /// <returns></returns>
        public static DataRow GetMacSettingListDataRow(string strMACkey)
        {

            string strSQL = string.Format(@"SELECT *  from  MACsettingT where MACkey= {0}", strMACkey);

            DBAccess dbhelper = new DBAccess();
            System.Data.DataTable dtMAC = new System.Data.DataTable();
            dbhelper.QueryToDataTableByDataAdapter(strSQL, ref dtMAC, isFillSchema: false);

            if (dtMAC.Rows.Count == 1)
            {
                return dtMAC.Rows[0];
            }
            else
            {
                return null;
            }

        }
        #endregion

        #region 取得MAC的資料  public static void GetApplicantTList(string strWhere, ref DataTable dtSource)
        /// <summary>
        /// 取得MAC的資料
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        public static void GetMACSettingTList(string strWhere, ref DataTable dtSource)
        {

            string strSQL = string.Format(@"SELECT *  from  MACsettingT with(nolock)  {0}", !string.IsNullOrEmpty(strWhere.Trim()) ? " where " + strWhere : "");

            DBAccess dbhelper = new DBAccess();
            dtSource.Rows.Clear();
            dbhelper.QueryToDataTableByDataAdapter(strSQL, ref dtSource, isFillSchema: false);

            if (dtSource.PrimaryKey.Length == 0)
            {
                DataColumn[] pk = { dtSource.Columns["MACkey"] };
                dtSource.PrimaryKey = pk;
            }
        }
        #endregion

        #region 中安全性機制 檢查登入的MAC是否存在  public static void CheckMACSettingTPass(string strWhere, ref  bool isPass)
        /// <summary>
        /// 中安全性機制 檢查登入的MAC是否存在
        /// </summary>
        /// <param name="strMAC"></param>
        /// <param name="isPass"></param>
        /// <returns></returns>
        public static void CheckMACSettingTPass(string strMAC, ref bool isPass)
        {

            string strSQL = string.Format(@"SELECT Count(*)    from  MACsettingT with(nolock) where IsEnable='True' and MAC='{0}' ", strMAC);

            DBAccess dbhelper = new DBAccess();
            object obj = new object();
            dbhelper.ExecuteScaler(strSQL, ref obj, null);

            int i = 0;
            bool isInt = int.TryParse(obj.ToString(), out i);
            if (i > 0)
            {
                isPass = true;
            }
            else
            {
                isPass = false;
            }
           
        }

        public static void CheckMACSettingTPass(string[] strMAC, ref bool isPass)
        {            
            foreach(string str in strMAC)
            {
                CheckMACSettingTPass(str.Trim(), ref isPass);
                if (isPass)
                {
                    break;
                }
            }
             
        }

        #endregion

        #region 高安全性機制  public static void CheckMACSettingTPass(string strMAC, string Account, ref bool isPass)
        /// <summary>
        /// 高安全性機制 檢查登入的MAC是否存在
        /// </summary>
        /// <param name="strMAC"></param>
        /// <param name="Account"></param>
        /// <param name="isPass"></param>
        /// <returns></returns>
        public static void CheckMACSettingTPass(string strMAC, string Account, ref bool isPass)
        {
            string strSQL = string.Format(@"SELECT Count(*)    from  MACsettingT with(nolock) where IsEnable='True' and MAC='{0}' and  Account='{1}' ", strMAC, Account);

            DBAccess dbhelper = new DBAccess();
            object obj = new object();
            dbhelper.ExecuteScaler(strSQL, ref obj, null);

            int i = 0;
            bool isInt = int.TryParse(obj.ToString(), out i);
            if (i > 0)
            {
                isPass = true;
            }
            else
            {
                isPass = false;
            }
        }

        /// <summary>
        /// 高安全性機制 檢查登入的MAC和登入的帳號是否符合
        /// </summary>
        /// <param name="strMAC"></param>
        /// <param name="Account"></param>
        /// <param name="isPass"></param>
        public static void CheckMACSettingTPass(string[] strMAC, string Account, ref bool isPass)
        {
            foreach (string str in strMAC)
            {
                CheckMACSettingTPass(str.Trim(), Account, ref isPass);
                if (isPass)
                {
                    break;
                }
            }
        }
        #endregion


    }
}
