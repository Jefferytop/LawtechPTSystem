using H3Operator.DBHelper;
using System.Data;
using System.Data.SqlClient;

namespace LawtechPTSystemByFirm.Public
{
    /// <summary>
    /// 提供下拉選單資料的類別
    /// </summary>
    public class CQueryDropT
    {
        #region GetAttorneyDrop 取得事務所的資料
        /// <summary>
        /// 取得AttorneyT的資料
        /// </summary>
        /// <param name="dtAttorney"></param>
        /// <returns></returns>
        public static object GetAttorneyDrop(ref DataTable dtAttorney)
        {

            string strSQL = string.Format(@"SELECT   AttorneyKey,AttorneyFirm , CountrySymbol FROM  AttorneyT with(nolock) order by AttorneyFirm");

            DBAccess dbhelper = new DBAccess();           
            object obj=dbhelper.QueryToDataTableByDataAdapter(strSQL, ref dtAttorney);
            return obj;
        }
        #endregion 

        #region GetAttorneyByCountrySymbolDrop 取得事務所的資料 by CountrySymbol
        /// <summary>
        /// 取得AttorneyT的資料(by CountrySymbol)
        /// </summary>
        /// <param name="strCountrySymbol"></param>
        /// <param name="dtAttorney"></param>
        /// <returns></returns>
        public static object GetAttorneyByCountrySymbolDrop(string strCountrySymbol, ref DataTable dtAttorney)
        {

            string strSQL = string.Format(@"SELECT   AttorneyKey, AttorneyFirm, CountrySymbol FROM    AttorneyT with(nolock) where CountrySymbol=@CountrySymbol order by AttorneyFirm");

            DBAccess dbhelper = new DBAccess();          
            SqlParameter[] myParameter = { DBAccess.MakeInParam("CountrySymbol", H3Operator.DBModels.SqlDataType.VarChar, strCountrySymbol) };
            object obj = dbhelper.QueryToDataTableByDataAdapter(strSQL, ref dtAttorney, myParameter);
            return obj;
        }
        #endregion 

        #region GetAttLiaisonerDrop 取得事務所連聯人的資料 by AttorneyKey
        /// <summary>
        /// 取得AttLiaisonerT的資料(by AttorneyKey)
        /// </summary>
        /// <param name="iAttorneyKey"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static object GetAttLiaisonerDrop(int iAttorneyKey, ref DataTable dt)
        {

            string strSQL = string.Format(@"SELECT   ALiaisonerKey, Liaisoner FROM    AttLiaisonerT with(nolock)
WHERE          (AttorneyKey = @AttorneyKey)
ORDER BY   Sort");

            DBAccess dbhelper = new DBAccess();           
            SqlParameter[] myParameter = { DBAccess.MakeInParam("AttorneyKey", H3Operator.DBModels.SqlDataType.Int, iAttorneyKey) };
            object obj = dbhelper.QueryToDataTableByDataAdapter(strSQL, ref dt, myParameter);
            return obj;
        }
        #endregion 

        #region GetAttLiaisonerDrop 取得事務所連聯人的資料 by AttorneyKey ,IsWindows
        /// <summary>
        /// 取得AttLiaisonerT的資料(by AttorneyKey,IsWindows )
        /// </summary>
        /// <param name="iAttorneyKey"></param>
        /// <param name="iIsWindows">聯絡人窗口</param>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static object GetAttLiaisonerDrop(int iAttorneyKey, int iIsWindows, ref DataTable dt)
        {

            string strSQL = string.Format(@"SELECT  ALiaisonerKey, Liaisoner
FROM      AttLiaisonerT with(nolock)
WHERE          (AttorneyKey = @AttorneyKey) AND (IsWindows = @IsWindows OR IsWindows IS NULL)
ORDER BY   Sort");

            DBAccess dbhelper = new DBAccess();            
            SqlParameter[] myParameter = { DBAccess.MakeInParam("AttorneyKey", H3Operator.DBModels.SqlDataType.Int, iAttorneyKey),
                                             DBAccess.MakeInParam("IsWindows", H3Operator.DBModels.SqlDataType.Int, iIsWindows) };
            object obj = dbhelper.QueryToDataTableByDataAdapter(strSQL, ref dt, myParameter);
            return obj;
        }
        #endregion 


        #region GetApplicantDrop 取得申請人/客戶的資料ApplicantT
        /// <summary>
        /// 取得申請人/客戶的資料ApplicantT
        /// </summary>
        /// <param name="dtApplicant"></param>
        /// <returns></returns>
        public static object GetApplicantDrop(ref DataTable dtApplicant)
        {

            string strSQL = string.Format(@"SELECT   '' AS ApplicantSymbolName, - 1 AS ApplicantKey
UNION ALL
SELECT DISTINCT ApplicantSymbol + '-' + ApplicantName AS ApplicantSymbolName, ApplicantKey
FROM              ApplicantT with(nolock)
ORDER BY   ApplicantSymbolName");

            DBAccess dbhelper = new DBAccess();
            System.Data.DataTable dtPatent = new System.Data.DataTable();
            object obj = dbhelper.QueryToDataTableByDataAdapter(strSQL, ref dtApplicant);
            return obj;
        }
        #endregion 

        #region GetCountryDrop 取得國別的資料CountryT
        /// <summary>
        /// 取得國別的資料CountryT
        /// </summary>
        /// <param name="dtCountry"></param>
        /// <returns></returns>
        public static object GetCountryDrop(ref DataTable dtCountry)
        {

            string strSQL = string.Format(@"SELECT  CountrySymbol, CountrySymbol + '-' + Country AS CountryName
FROM     CountryT with(nolock)
ORDER BY   SN");

            DBAccess dbhelper = new DBAccess();         
            object obj = dbhelper.QueryToDataTableByDataAdapter(strSQL, ref dtCountry);
            return obj;
        }
        #endregion 

        #region GetMoneyDrop 取得幣別的資料MoneyT
        /// <summary>
        /// 取得幣別的資料MoneyT
        /// </summary>
        /// <param name="dtCountry"></param>
        /// <returns></returns>
        public static object GetMoneyDrop(ref DataTable dtMoney)
        {

            string strSQL = string.Format(@"SELECT  MoneyName, MoneyKey, ToNT, Money + MoneyName AS Money, Money AS MoneyCode
FROM              MoneyT with(nolock)
ORDER BY   SN");

            DBAccess dbhelper = new DBAccess();
            object obj = dbhelper.QueryToDataTableByDataAdapter(strSQL, ref dtMoney);
            return obj;
        }
        #endregion 

        #region GetWorkerDrop 取得登入者的資料WorkerT
        /// <summary>
        /// 取得管理員的資料WorkerT
        /// </summary>
        /// <param name="dtCountry"></param>
        /// <param name="bIsQuit">false:在職 ; true:已離職</param>
        /// <returns></returns>
        public static object GetWorkerDrop(ref DataTable dtWorker, bool bIsQuit=false)
        {

            string strSQL = string.Format(@"SELECT   - 1 AS WorkerKey, '' AS FullEmployeeName
UNION ALL
SELECT          WorkerKey, EmployeeNameEn + '-' + EmployeeName AS FullEmployeeName
FROM              WorkerT  with(nolock)
WHERE          (IsQuit = @IsQuit)
ORDER BY   FullEmployeeName");

            DBAccess dbhelper = new DBAccess();
            SqlParameter[] myParameter = { DBAccess.MakeInParam("IsQuit", H3Operator.DBModels.SqlDataType.Bit, bIsQuit) };
            object obj = dbhelper.QueryToDataTableByDataAdapter(strSQL, ref dtWorker, myParameter);
            return obj;
        }
        #endregion

        #region GetWorkerALLDrop 取得所有管理員的資料WorkerT
        /// <summary>
        /// 取得所有管理員的資料WorkerT
        /// </summary>
        /// <param name="dtWorker"></param>
        /// <returns></returns>
        public static object GetWorkerALLDrop(ref DataTable dtWorker)
        {

            string strSQL = string.Format(@"SELECT   - 1 AS WorkerKey, '' AS FullEmployeeName
UNION ALL
SELECT          WorkerKey, EmployeeNameEn + '-' + EmployeeName AS FullEmployeeName
FROM              WorkerT  with(nolock)
ORDER BY   FullEmployeeName");

            DBAccess dbhelper = new DBAccess();
            object obj = dbhelper.QueryToDataTableByDataAdapter(strSQL, ref dtWorker);
            return obj;
        } 
        #endregion        

        #region GetContractTypeDrop 取得所有聯絡窗口的資料 ContractTypeT
        /// <summary>
        /// 取得所有聯絡窗口的資料 ContractTypeT
        /// </summary>
        /// <param name="dtWorker"></param>
        /// <returns></returns>
        public static object GetContractTypeDrop(ref DataTable dtWorker)
        {

            string strSQL = string.Format(@"SELECT   ContractID, ContractNo, ContractType, Sort
FROM   ContractTypeT  with(nolock) ORDER BY   Sort");

            DBAccess dbhelper = new DBAccess();
            object obj = dbhelper.QueryToDataTableByDataAdapter(strSQL, ref dtWorker);
            return obj;
        }
        #endregion        


        #region GetTrademarkProcessKindDrop 取得商標標準作業流程的資料TrademarkProcessKindT
        /// <summary>
        /// 取得商標標準作業流程的資料TrademarkProcessKindT
        /// </summary>
        /// <param name="dtProcess"></param>
        /// <returns></returns>
        public static object GetTrademarkProcessKindDrop(ref DataTable dtProcess)
        {

            string strSQL = string.Format(@"SELECT  '' AS ProcessKind, - 1 AS ProcessKEY, - 1 AS sort
UNION
SELECT          ProcessKind, ProcessKEY, Sort
FROM              TrademarkProcessKindT
WHERE          (bStop = 1)
ORDER BY   sort");

            DBAccess dbhelper = new DBAccess();
            SqlParameter[] myParameter = { DBAccess.MakeInParam("IsQuit", H3Operator.DBModels.SqlDataType.Bit, false) };
            object obj = dbhelper.QueryToDataTableByDataAdapter(strSQL, ref dtProcess);
            return obj;
        }
        #endregion 

        #region GetTrademarkNotifyEventTypeDrop 取得商標事件種類的資料 TrademarkNotifyEventTypeT
        /// <summary>
        /// 取得商標事件種類的資料 TrademarkNotifyEventTypeT
        /// </summary>
        /// <param name="dtProcess"></param>
        /// <returns></returns>
        public static object GetTrademarkNotifyEventTypeDrop(ref DataTable dtProcess)
        {

            string strSQL = string.Format(@"SELECT  NotifyEventTypeName, TMNotifyEventTypeID
FROM              TrademarkNotifyEventTypeT
ORDER BY   Sort");

            DBAccess dbhelper = new DBAccess();           
            object obj = dbhelper.QueryToDataTableByDataAdapter(strSQL, ref dtProcess);
            return obj;
        }
        #endregion 

        #region GetTrademarkStatusDrop 取得商標案件階段的資料 TMStatusT
        /// <summary>
        /// 取得商標案件階段的資料 TMStatusT
        /// </summary>
        /// <param name="dtProcess"></param>
        /// <returns></returns>
        public static object GetTrademarkStatusDrop(ref DataTable dtProcess)
        {

            string strSQL = string.Format(@"SELECT  - 1 AS TMStatusID, '' AS Status, - 1 AS Sort
UNION
SELECT          TMStatusID, Status, Sort
FROM              TMStatusT with(nolock)
WHERE          (bStop = 1)
ORDER BY   Sort");

            DBAccess dbhelper = new DBAccess();
            object obj = dbhelper.QueryToDataTableByDataAdapter(strSQL, ref dtProcess);
            return obj;
        }
        #endregion 

        #region GetTrademarkNotifyDueDrop 取得商標事件內容的資料 by CountrySymbol  TMNotifyDueT
        /// <summary>
        /// 取得商標事件內容的資料(by CountrySymbol)
        /// </summary>
        /// <param name="strCountrySymbol"></param>
        /// <param name="iStatus"></param>
        /// <param name="dtProcess"></param>
        /// <returns></returns>
        public static object GetTrademarkNotifyDueDrop(string strCountrySymbol,int iStatus, ref DataTable dtProcess)
        {

            string strSQL = string.Format(@"SELECT  TMNotifyDueID, NotifyContent
FROM              TMNotifyDueT with(nolock)
WHERE          (CountrySymbol = @CountrySymbol) and (Status=@Status)
ORDER BY   Sort");

            DBAccess dbhelper = new DBAccess();
            SqlParameter[] myParameter = { DBAccess.MakeInParam("CountrySymbol", H3Operator.DBModels.SqlDataType.VarChar, strCountrySymbol),
                                         DBAccess.MakeInParam("Status", H3Operator.DBModels.SqlDataType.Int, iStatus)};
            object obj = dbhelper.QueryToDataTableByDataAdapter(strSQL, ref dtProcess, myParameter);
            return obj;
        }
        #endregion 


        #region GetFeePhaseTByPatDrop 取得專利費用種類的資料 FeePhaseT
        /// <summary>
        /// 取得專利費用種類的資料 FeePhaseT
        /// </summary>
        /// <param name="dtProcess"></param>
        /// <returns></returns>
        public static object GetFeePhaseTByPatDrop(ref DataTable dtProcess)
        {

            string strSQL = string.Format(@"SELECT  FeePhaseID, FeePhase
FROM              FeePhaseT with(nolock)
WHERE          (Type = 1)
ORDER BY   Sort");

            DBAccess dbhelper = new DBAccess();
           
            object obj = dbhelper.QueryToDataTableByDataAdapter(strSQL, ref dtProcess);
            return obj;
        }
        #endregion 

        #region GetFeePhaseTByTMDrop 取得商標費用種類的資料 FeePhaseT
        /// <summary>
        /// 取得商標費用種類的資料 FeePhaseT
        /// </summary>
        /// <param name="dtProcess"></param>
        /// <returns></returns>
        public static object GetFeePhaseTByTMDrop(ref DataTable dtProcess)
        {

            string strSQL = string.Format(@"SELECT  FeePhaseID, FeePhase
FROM  FeePhaseT with(nolock)
WHERE (Type = 2)
ORDER BY   Sort");

            DBAccess dbhelper = new DBAccess();
            object obj = dbhelper.QueryToDataTableByDataAdapter(strSQL, ref dtProcess);
            return obj;
        }
        #endregion 
    }
}
