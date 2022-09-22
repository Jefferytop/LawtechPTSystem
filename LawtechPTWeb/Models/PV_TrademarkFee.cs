using H3Operator.DBHelper;
using H3Operator.DBModels;
using System;
using System.Collections.Generic;

namespace LawtechPTWeb.Models
{

    #region View PV_TrademarkFee Script
    [ViewTableMapping(@"select * from V_TrademarkFeeSearch")]
    public class PV_TrademarkFee
    {
        #region Public Property

        private int m_FeeKEY;
        [TableColumnSetting("FeeKEY", DbType = SqlDataType.Int)]
        public int FeeKEY
        {
            get
            {
                return m_FeeKEY;
            }
            set
            {
                m_FeeKEY = value;
            }
        }

        private DateTime m_RDate;
        [TableColumnSetting("RDate", DbType = SqlDataType.DateTime)]
        public DateTime RDate
        {
            get
            {
                return m_RDate;
            }
            set
            {
                m_RDate = value;
            }
        }

        private string m_FeeSubject;
        [TableColumnSetting("FeeSubject", DbType = SqlDataType.NVarChar)]
        public string FeeSubject
        {
            get
            {
                return m_FeeSubject;
            }
            set
            {
                m_FeeSubject = value;
            }
        }

        private int m_Attorney;
        [TableColumnSetting("Attorney", DbType = SqlDataType.Int)]
        public int Attorney
        {
            get
            {
                return m_Attorney;
            }
            set
            {
                m_Attorney = value;
            }
        }

        private int m_FClientTransactor;
        [TableColumnSetting("FClientTransactor", DbType = SqlDataType.Int)]
        public int FClientTransactor
        {
            get
            {
                return m_FClientTransactor;
            }
            set
            {
                m_FClientTransactor = value;
            }
        }

        private DateTime m_IReceiptDate;
        [TableColumnSetting("IReceiptDate", DbType = SqlDataType.DateTime)]
        public DateTime IReceiptDate
        {
            get
            {
                return m_IReceiptDate;
            }
            set
            {
                m_IReceiptDate = value;
            }
        }

        private string m_IReceiptNo;
        [TableColumnSetting("IReceiptNo", DbType = SqlDataType.NVarChar)]
        public string IReceiptNo
        {
            get
            {
                return m_IReceiptNo;
            }
            set
            {
                m_IReceiptNo = value;
            }
        }

        private DateTime m_aBillDate;
        [TableColumnSetting("aBillDate", DbType = SqlDataType.DateTime)]
        public DateTime aBillDate
        {
            get
            {
                return m_aBillDate;
            }
            set
            {
                m_aBillDate = value;
            }
        }

        private string m_aBill;
        [TableColumnSetting("aBill", DbType = SqlDataType.NVarChar)]
        public string aBill
        {
            get
            {
                return m_aBill;
            }
            set
            {
                m_aBill = value;
            }
        }

        private decimal m_IAttorneyFee;
        [TableColumnSetting("IAttorneyFee", DbType = SqlDataType.Decimal)]
        public decimal IAttorneyFee
        {
            get
            {
                return m_IAttorneyFee;
            }
            set
            {
                m_IAttorneyFee = value;
            }
        }

        private string m_IMoney;
        [TableColumnSetting("IMoney", DbType = SqlDataType.NVarChar)]
        public string IMoney
        {
            get
            {
                return m_IMoney;
            }
            set
            {
                m_IMoney = value;
            }
        }

        private decimal m_ItoNT;
        [TableColumnSetting("ItoNT", DbType = SqlDataType.Decimal)]
        public decimal ItoNT
        {
            get
            {
                return m_ItoNT;
            }
            set
            {
                m_ItoNT = value;
            }
        }

        private decimal m_ITotall;
        [TableColumnSetting("ITotall", DbType = SqlDataType.Decimal)]
        public decimal ITotall
        {
            get
            {
                return m_ITotall;
            }
            set
            {
                m_ITotall = value;
            }
        }

        private DateTime m_ReceiptDate;
        [TableColumnSetting("ReceiptDate", DbType = SqlDataType.DateTime)]
        public DateTime ReceiptDate
        {
            get
            {
                return m_ReceiptDate;
            }
            set
            {
                m_ReceiptDate = value;
            }
        }

        private DateTime m_OReceiptDate;
        [TableColumnSetting("OReceiptDate", DbType = SqlDataType.DateTime)]
        public DateTime OReceiptDate
        {
            get
            {
                return m_OReceiptDate;
            }
            set
            {
                m_OReceiptDate = value;
            }
        }

        private string m_OReceiptNo;
        [TableColumnSetting("OReceiptNo", DbType = SqlDataType.NVarChar)]
        public string OReceiptNo
        {
            get
            {
                return m_OReceiptNo;
            }
            set
            {
                m_OReceiptNo = value;
            }
        }

        private decimal m_OAttorneyFee;
        [TableColumnSetting("OAttorneyFee", DbType = SqlDataType.Decimal)]
        public decimal OAttorneyFee
        {
            get
            {
                return m_OAttorneyFee;
            }
            set
            {
                m_OAttorneyFee = value;
            }
        }

        private string m_OMoney;
        [TableColumnSetting("OMoney", DbType = SqlDataType.NVarChar)]
        public string OMoney
        {
            get
            {
                return m_OMoney;
            }
            set
            {
                m_OMoney = value;
            }
        }

        private decimal m_OtoNT;
        [TableColumnSetting("OtoNT", DbType = SqlDataType.Decimal)]
        public decimal OtoNT
        {
            get
            {
                return m_OtoNT;
            }
            set
            {
                m_OtoNT = value;
            }
        }

        private decimal m_OthFee;
        [TableColumnSetting("OthFee", DbType = SqlDataType.Decimal)]
        public decimal OthFee
        {
            get
            {
                return m_OthFee;
            }
            set
            {
                m_OthFee = value;
            }
        }

        private decimal m_OTotall;
        [TableColumnSetting("OTotall", DbType = SqlDataType.Decimal)]
        public decimal OTotall
        {
            get
            {
                return m_OTotall;
            }
            set
            {
                m_OTotall = value;
            }
        }

        private DateTime m_GReceiptDate;
        [TableColumnSetting("GReceiptDate", DbType = SqlDataType.DateTime)]
        public DateTime GReceiptDate
        {
            get
            {
                return m_GReceiptDate;
            }
            set
            {
                m_GReceiptDate = value;
            }
        }

        private string m_GReceiptNo;
        [TableColumnSetting("GReceiptNo", DbType = SqlDataType.NVarChar)]
        public string GReceiptNo
        {
            get
            {
                return m_GReceiptNo;
            }
            set
            {
                m_GReceiptNo = value;
            }
        }

        private decimal m_GovFee;
        [TableColumnSetting("GovFee", DbType = SqlDataType.Decimal)]
        public decimal GovFee
        {
            get
            {
                return m_GovFee;
            }
            set
            {
                m_GovFee = value;
            }
        }

        private string m_GMoney;
        [TableColumnSetting("GMoney", DbType = SqlDataType.NVarChar)]
        public string GMoney
        {
            get
            {
                return m_GMoney;
            }
            set
            {
                m_GMoney = value;
            }
        }

        private decimal m_GtoNT;
        [TableColumnSetting("GtoNT", DbType = SqlDataType.Decimal)]
        public decimal GtoNT
        {
            get
            {
                return m_GtoNT;
            }
            set
            {
                m_GtoNT = value;
            }
        }

        private decimal m_GTotall;
        [TableColumnSetting("GTotall", DbType = SqlDataType.Decimal)]
        public decimal GTotall
        {
            get
            {
                return m_GTotall;
            }
            set
            {
                m_GTotall = value;
            }
        }

        private decimal m_OAttorneyGovFee;
        [TableColumnSetting("OAttorneyGovFee", DbType = SqlDataType.Decimal)]
        public decimal OAttorneyGovFee
        {
            get
            {
                return m_OAttorneyGovFee;
            }
            set
            {
                m_OAttorneyGovFee = value;
            }
        }

        private decimal m_OtherTotalFee;
        [TableColumnSetting("OtherTotalFee", DbType = SqlDataType.Decimal)]
        public decimal OtherTotalFee
        {
            get
            {
                return m_OtherTotalFee;
            }
            set
            {
                m_OtherTotalFee = value;
            }
        }

        private decimal m_OthTotal;
        [TableColumnSetting("OthTotal", DbType = SqlDataType.Decimal)]
        public decimal OthTotal
        {
            get
            {
                return m_OthTotal;
            }
            set
            {
                m_OthTotal = value;
            }
        }

        private decimal m_Totall;
        [TableColumnSetting("Totall", DbType = SqlDataType.Decimal)]
        public decimal Totall
        {
            get
            {
                return m_Totall;
            }
            set
            {
                m_Totall = value;
            }
        }

        private string m_TMoney;
        [TableColumnSetting("TMoney", DbType = SqlDataType.NVarChar)]
        public string TMoney
        {
            get
            {
                return m_TMoney;
            }
            set
            {
                m_TMoney = value;
            }
        }

        private decimal m_TtoNT;
        [TableColumnSetting("TtoNT", DbType = SqlDataType.Decimal)]
        public decimal TtoNT
        {
            get
            {
                return m_TtoNT;
            }
            set
            {
                m_TtoNT = value;
            }
        }

        private decimal m_TotalNT;
        [TableColumnSetting("TotalNT", DbType = SqlDataType.Decimal)]
        public decimal TotalNT
        {
            get
            {
                return m_TotalNT;
            }
            set
            {
                m_TotalNT = value;
            }
        }

        private bool m_Pay;
        [TableColumnSetting("Pay", DbType = SqlDataType.Bit)]
        public bool Pay
        {
            get
            {
                return m_Pay;
            }
            set
            {
                m_Pay = value;
            }
        }

        private DateTime m_PayDate;
        [TableColumnSetting("PayDate", DbType = SqlDataType.DateTime)]
        public DateTime PayDate
        {
            get
            {
                return m_PayDate;
            }
            set
            {
                m_PayDate = value;
            }
        }

        private string m_PPP;
        [TableColumnSetting("PPP", DbType = SqlDataType.NVarChar)]
        public string PPP
        {
            get
            {
                return m_PPP;
            }
            set
            {
                m_PPP = value;
            }
        }

        private bool m_Withholding;
        [TableColumnSetting("Withholding", DbType = SqlDataType.Bit)]
        public bool Withholding
        {
            get
            {
                return m_Withholding;
            }
            set
            {
                m_Withholding = value;
            }
        }

        private decimal m_Tax;
        [TableColumnSetting("Tax", DbType = SqlDataType.Decimal)]
        public decimal Tax
        {
            get
            {
                return m_Tax;
            }
            set
            {
                m_Tax = value;
            }
        }

        private decimal m_PracticalityPay;
        [TableColumnSetting("PracticalityPay", DbType = SqlDataType.Decimal)]
        public decimal PracticalityPay
        {
            get
            {
                return m_PracticalityPay;
            }
            set
            {
                m_PracticalityPay = value;
            }
        }

        private bool m_NT;
        [TableColumnSetting("NT", DbType = SqlDataType.Bit)]
        public bool NT
        {
            get
            {
                return m_NT;
            }
            set
            {
                m_NT = value;
            }
        }

        private string m_PayKind;
        [TableColumnSetting("PayKind", DbType = SqlDataType.NVarChar)]
        public string PayKind
        {
            get
            {
                return m_PayKind;
            }
            set
            {
                m_PayKind = value;
            }
        }

        private string m_Remark;
        [TableColumnSetting("Remark", DbType = SqlDataType.NVarChar)]
        public string Remark
        {
            get
            {
                return m_Remark;
            }
            set
            {
                m_Remark = value;
            }
        }

        private int m_PayType;
        [TableColumnSetting("PayType", DbType = SqlDataType.Int)]
        public int PayType
        {
            get
            {
                return m_PayType;
            }
            set
            {
                m_PayType = value;
            }
        }

        private string m_PayMemo;
        [TableColumnSetting("PayMemo", DbType = SqlDataType.NVarChar)]
        public string PayMemo
        {
            get
            {
                return m_PayMemo;
            }
            set
            {
                m_PayMemo = value;
            }
        }

        private string m_SingCode;
        [TableColumnSetting("SingCode", DbType = SqlDataType.NVarChar)]
        public string SingCode
        {
            get
            {
                return m_SingCode;
            }
            set
            {
                m_SingCode = value;
            }
        }

        private string m_SingCodeStatus;
        [TableColumnSetting("SingCodeStatus", DbType = SqlDataType.NVarChar)]
        public string SingCodeStatus
        {
            get
            {
                return m_SingCodeStatus;
            }
            set
            {
                m_SingCodeStatus = value;
            }
        }

        private int m_Days;
        [TableColumnSetting("Days", DbType = SqlDataType.Int)]
        public int Days
        {
            get
            {
                return m_Days;
            }
            set
            {
                m_Days = value;
            }
        }

        private bool m_IsClosing;
        [TableColumnSetting("IsClosing", DbType = SqlDataType.Bit)]
        public bool IsClosing
        {
            get
            {
                return m_IsClosing;
            }
            set
            {
                m_IsClosing = value;
            }
        }

        private DateTime m_CloseDate;
        [TableColumnSetting("CloseDate", DbType = SqlDataType.DateTime)]
        public DateTime CloseDate
        {
            get
            {
                return m_CloseDate;
            }
            set
            {
                m_CloseDate = value;
            }
        }

        private string m_Creator;
        [TableColumnSetting("Creator", DbType = SqlDataType.NVarChar)]
        public string Creator
        {
            get
            {
                return m_Creator;
            }
            set
            {
                m_Creator = value;
            }
        }

        private DateTime m_CreateDateTime;
        [TableColumnSetting("CreateDateTime", DbType = SqlDataType.DateTime)]
        public DateTime CreateDateTime
        {
            get
            {
                return m_CreateDateTime;
            }
            set
            {
                m_CreateDateTime = value;
            }
        }

        private DateTime m_LastModifyDateTime;
        [TableColumnSetting("LastModifyDateTime", DbType = SqlDataType.DateTime)]
        public DateTime LastModifyDateTime
        {
            get
            {
                return m_LastModifyDateTime;
            }
            set
            {
                m_LastModifyDateTime = value;
            }
        }

        private string m_LastModifyWorker;
        [TableColumnSetting("LastModifyWorker", DbType = SqlDataType.NVarChar)]
        public string LastModifyWorker
        {
            get
            {
                return m_LastModifyWorker;
            }
            set
            {
                m_LastModifyWorker = value;
            }
        }

        private string m_AttorneyFirm;
        [TableColumnSetting("AttorneyFirm", DbType = SqlDataType.NVarChar)]
        public string AttorneyFirm
        {
            get
            {
                return m_AttorneyFirm;
            }
            set
            {
                m_AttorneyFirm = value;
            }
        }

        private string m_EmployeeName;
        [TableColumnSetting("EmployeeName", DbType = SqlDataType.NVarChar)]
        public string EmployeeName
        {
            get
            {
                return m_EmployeeName;
            }
            set
            {
                m_EmployeeName = value;
            }
        }

        private string m_FeePhase;
        [TableColumnSetting("FeePhase", DbType = SqlDataType.NVarChar)]
        public string FeePhase
        {
            get
            {
                return m_FeePhase;
            }
            set
            {
                m_FeePhase = value;
            }
        }

        private int m_FeePhaseID;
        [TableColumnSetting("FeePhaseID", DbType = SqlDataType.Int)]
        public int FeePhaseID
        {
            get
            {
                return m_FeePhaseID;
            }
            set
            {
                m_FeePhaseID = value;
            }
        }

        private int m_TMNotifyEventID;
        [TableColumnSetting("TMNotifyEventID", DbType = SqlDataType.Int)]
        public int TMNotifyEventID
        {
            get
            {
                return m_TMNotifyEventID;
            }
            set
            {
                m_TMNotifyEventID = value;
            }
        }

        private int m_TrademarkID;
        [TableColumnSetting("TrademarkID", DbType = SqlDataType.Int)]
        public int TrademarkID
        {
            get
            {
                return m_TrademarkID;
            }
            set
            {
                m_TrademarkID = value;
            }
        }

        private string m_TrademarkNo;
        [TableColumnSetting("TrademarkNo", DbType = SqlDataType.NVarChar)]
        public string TrademarkNo
        {
            get
            {
                return m_TrademarkNo;
            }
            set
            {
                m_TrademarkNo = value;
            }
        }

        private string m_TrademarkName;
        [TableColumnSetting("TrademarkName", DbType = SqlDataType.NVarChar)]
        public string TrademarkName
        {
            get
            {
                return m_TrademarkName;
            }
            set
            {
                m_TrademarkName = value;
            }
        }

        private string m_ApplicantNames;
        [TableColumnSetting("ApplicantNames", DbType = SqlDataType.NVarChar)]
        public string ApplicantNames
        {
            get
            {
                return m_ApplicantNames;
            }
            set
            {
                m_ApplicantNames = value;
            }
        }

        private string m_Country;
        [TableColumnSetting("Country", DbType = SqlDataType.NVarChar)]
        public string Country
        {
            get
            {
                return m_Country;
            }
            set
            {
                m_Country = value;
            }
        }

        private string m_CountrySymbol;
        [TableColumnSetting("CountrySymbol", DbType = SqlDataType.NVarChar)]
        public string CountrySymbol
        {
            get
            {
                return m_CountrySymbol;
            }
            set
            {
                m_CountrySymbol = value;
            }
        }

        private string m_StyleName;
        [TableColumnSetting("StyleName", DbType = SqlDataType.NVarChar)]
        public string StyleName
        {
            get
            {
                return m_StyleName;
            }
            set
            {
                m_StyleName = value;
            }
        }

        private string m_TMTypeName;
        [TableColumnSetting("TMTypeName", DbType = SqlDataType.NVarChar)]
        public string TMTypeName
        {
            get
            {
                return m_TMTypeName;
            }
            set
            {
                m_TMTypeName = value;
            }
        }

        private bool m_TMNature;
        [TableColumnSetting("TMNature", DbType = SqlDataType.Bit)]
        public bool TMNature
        {
            get
            {
                return m_TMNature;
            }
            set
            {
                m_TMNature = value;
            }
        }

        private int m_Status;
        [TableColumnSetting("Status", DbType = SqlDataType.Int)]
        public int Status
        {
            get
            {
                return m_Status;
            }
            set
            {
                m_Status = value;
            }
        }

        private string m_StatusName;
        [TableColumnSetting("StatusName", DbType = SqlDataType.NVarChar)]
        public string StatusName
        {
            get
            {
                return m_StatusName;
            }
            set
            {
                m_StatusName = value;
            }
        }

        private DateTime m_EntrustDate;
        [TableColumnSetting("EntrustDate", DbType = SqlDataType.DateTime)]
        public DateTime EntrustDate
        {
            get
            {
                return m_EntrustDate;
            }
            set
            {
                m_EntrustDate = value;
            }
        }

        private int m_OutsourcingAttorney;
        [TableColumnSetting("OutsourcingAttorney", DbType = SqlDataType.Int)]
        public int OutsourcingAttorney
        {
            get
            {
                return m_OutsourcingAttorney;
            }
            set
            {
                m_OutsourcingAttorney = value;
            }
        }

        private int m_OutsourcingAttorneyWorker;
        [TableColumnSetting("OutsourcingAttorneyWorker", DbType = SqlDataType.Int)]
        public int OutsourcingAttorneyWorker
        {
            get
            {
                return m_OutsourcingAttorneyWorker;
            }
            set
            {
                m_OutsourcingAttorneyWorker = value;
            }
        }

        private string m_OutsourcingTrademarkNo;
        [TableColumnSetting("OutsourcingTrademarkNo", DbType = SqlDataType.NVarChar)]
        public string OutsourcingTrademarkNo
        {
            get
            {
                return m_OutsourcingTrademarkNo;
            }
            set
            {
                m_OutsourcingTrademarkNo = value;
            }
        }

        private DateTime m_OutsourcingDate;
        [TableColumnSetting("OutsourcingDate", DbType = SqlDataType.DateTime)]
        public DateTime OutsourcingDate
        {
            get
            {
                return m_OutsourcingDate;
            }
            set
            {
                m_OutsourcingDate = value;
            }
        }

        private DateTime m_ApplicationDate;
        [TableColumnSetting("ApplicationDate", DbType = SqlDataType.DateTime)]
        public DateTime ApplicationDate
        {
            get
            {
                return m_ApplicationDate;
            }
            set
            {
                m_ApplicationDate = value;
            }
        }

        private string m_ApplicationNo;
        [TableColumnSetting("ApplicationNo", DbType = SqlDataType.NVarChar)]
        public string ApplicationNo
        {
            get
            {
                return m_ApplicationNo;
            }
            set
            {
                m_ApplicationNo = value;
            }
        }

        private DateTime m_NoticeDate1;
        [TableColumnSetting("NoticeDate1", DbType = SqlDataType.DateTime)]
        public DateTime NoticeDate1
        {
            get
            {
                return m_NoticeDate1;
            }
            set
            {
                m_NoticeDate1 = value;
            }
        }

        private string m_NoticeNo1;
        [TableColumnSetting("NoticeNo1", DbType = SqlDataType.NVarChar)]
        public string NoticeNo1
        {
            get
            {
                return m_NoticeNo1;
            }
            set
            {
                m_NoticeNo1 = value;
            }
        }

        private DateTime m_NoticeDate;
        [TableColumnSetting("NoticeDate", DbType = SqlDataType.DateTime)]
        public DateTime NoticeDate
        {
            get
            {
                return m_NoticeDate;
            }
            set
            {
                m_NoticeDate = value;
            }
        }

        private string m_NoticeNo;
        [TableColumnSetting("NoticeNo", DbType = SqlDataType.NVarChar)]
        public string NoticeNo
        {
            get
            {
                return m_NoticeNo;
            }
            set
            {
                m_NoticeNo = value;
            }
        }

        private DateTime m_RegistrationDate;
        [TableColumnSetting("RegistrationDate", DbType = SqlDataType.DateTime)]
        public DateTime RegistrationDate
        {
            get
            {
                return m_RegistrationDate;
            }
            set
            {
                m_RegistrationDate = value;
            }
        }

        private string m_RegistrationNo;
        [TableColumnSetting("RegistrationNo", DbType = SqlDataType.NVarChar)]
        public string RegistrationNo
        {
            get
            {
                return m_RegistrationNo;
            }
            set
            {
                m_RegistrationNo = value;
            }
        }

        #endregion

        #region [GetTotalCountRows]多資料表join時使用，回傳查詢後的總筆數 public static object GetTotalCountRows(ref int iCountRows, string strSqlWhere = ", System.Data.SqlClient.SqlParameter[] sqlParameterList = null, string strCusTableName = "")
        /// <summary>
        /// [GetTotalCountRows]多資料表join時使用，回傳查詢後的總筆數
        /// </summary>
        /// <param name="iCountRows">回傳此次查詢的總筆數</param>
        /// <param name="strSqlWhere">SQL條件式 (不用加「where」關鑵字)</param>
        /// <param name="sqlParameterList">Sql參數</param>
        /// <param name="IsStoredProcedure">是否為預存程序, 預設為False</param>
        /// <returns></returns>
        public static object GetTotalCountRows(ref int iCountRows, string strSqlWhere = "", System.Data.SqlClient.SqlParameter[] sqlParameterList = null, bool IsStoredProcedure = false)
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.ReadViewCountRows<PV_TrademarkFee>(ref iCountRows, strSqlWhere, sqlParameterList: sqlParameterList, isStoredProcedure: IsStoredProcedure);
            return retObj;
        }

        /// <summary>
        /// [GetTotalCountRows]多資料表join時使用，回傳查詢後的總筆數
        /// </summary>
        /// <param name="strSqlScript">提供完整的Sql Script 語法</param>
        /// <param name="iCountRows">回傳此次查詢的總筆數</param>
        /// <param name="sqlParameterList">Sql參數</param>       
        /// <param name="IsStoredProcedure">是否為預存程序, 預設為False</param>
        /// <param name="ConnectString">預設為空字串，不為空字串時，以帶的連線字串為主; 若為空字串則以類別指定的連線字串(當類別連線名稱為空則帶DBSetConnection.ConnectionListDefaultConnectionString); </param>
        /// <returns></returns>
        public static object GetTotalCountRows(string strSqlScript, ref int iCountRows, System.Data.SqlClient.SqlParameter[] sqlParameterList = null, bool IsStoredProcedure = false, string ConnectString = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.ReadViewCountRows<PV_TrademarkFee>(strSqlScript, ref iCountRows, sqlParameterList: sqlParameterList, strConnectionString: ConnectString, isStoredProcedure: IsStoredProcedure);
            return retObj;
        }
        #endregion

        #region 取得多筆PV_TrademarkFee資料 ReadList

        #region  public static object ReadList(ref List<PV_TrademarkFee> Items, string strSqlScript = "", System.Data.SqlClient.SqlParameter[] MySqlParameterList = null, bool IsStoredProcedure = false)
        /// <summary>
        /// 取得多筆PV_TrademarkFee資料 ReadList
        /// 只要指定的Sql欄位有對應至類別屬性，則自動繫結       
        /// </summary>
        /// <param name="Items"></param>
        /// <param name="strSqlScript">完整的Sql Script語法</param>
        /// <param name="MySqlParameterList"></param>
        /// <param name="IsStoredProcedure">是否為StoredProcedure ,true:是 ; false:否(預設值) </param>
        /// <returns></returns>
        public static object ReadList(ref List<PV_TrademarkFee> Items, string strSqlScript = "", System.Data.SqlClient.SqlParameter[] MySqlParameterList = null, bool IsStoredProcedure = false)
        {
            ORMFactory orm = new ORMFactory();

            object retObj = orm.ReadViewDBListToObjs<PV_TrademarkFee>(strSqlScript, ref Items, sqlParameterList: MySqlParameterList, isStoredProcedure: IsStoredProcedure);

            return retObj;
        }
        #endregion

        #region public static object ReadList( string strSqlWhere  ,ref List<PV_TrademarkFee> Items, System.Data.SqlClient.SqlParameter[] MySqlParameterList = null, bool IsStoredProcedure = false)
        /// <summary>
        /// 取得多筆PV_TrademarkFee資料 ReadList
        /// 只要指定的Sql欄位有對應至類別屬性，則自動繫結       
        /// </summary>
        /// <param name="strSqlWhere">SQL條件式 (不用加「where」關鑵字)</param>  
        /// <param name="Items"></param>       
        /// <param name="MySqlParameterList"></param>
        /// <param name="IsStoredProcedure">是否為StoredProcedure ,true:是 ; false:否(預設值)</param>
        /// <returns></returns>
        public static object ReadList(string strSqlWhere, ref List<PV_TrademarkFee> Items, System.Data.SqlClient.SqlParameter[] MySqlParameterList = null, bool IsStoredProcedure = false)
        {
            ORMFactory orm = new ORMFactory();

            object retObj = orm.ReadViewDBListToObjs<PV_TrademarkFee>(ref Items, strSqlWhere, sqlParameterList: MySqlParameterList, isStoredProcedure: IsStoredProcedure);

            return retObj;
        }
        #endregion

        #region public static object ReadList(string strSqlWhere, string strOrderBy, ref List<PV_TrademarkFee> Items, int myPageSize = 10, int myPageIndex = 1, System.Data.SqlClient.SqlParameter[] MySqlParameterList = null, bool IsStoredProcedure = false)
        /// <summary>
        /// [ReadViewDBListToObjsByFetch](使用MSSQL 2014的分頁做法OFFSET FETCH ，效能佳, §注意 MSSQL2008 無法使用)
        /// 取得多筆PV_TrademarkFee資料 ReadList
        /// 只要指定的Sql欄位有對應至類別屬性，則自動繫結       
        /// </summary>
        /// <param name="strSqlWhere">SQL條件式 (不用加「where」關鑵字)</param>  
        /// <param name="strOrderBy">排序的欄位; 例: CreateDateTime desc </param> 
        /// <param name="Items"></param>     
        /// <param name="myPageSize">一頁的筆數,預設一頁 10 筆</param>  
        /// <param name="myPageIndex">從 0 起算，0即表示第1頁</param>  
        /// <param name="MySqlParameterList">Sql參數</param>
        /// <param name="IsStoredProcedure">是否為StoredProcedure ,true:是 ; false:否(預設值)</param>
        /// <returns></returns>
        public static object ReadList(string strSqlWhere, string strOrderBy, ref List<PV_TrademarkFee> Items, int myPageSize = 10, int myPageIndex = 1, System.Data.SqlClient.SqlParameter[] MySqlParameterList = null, bool IsStoredProcedure = false)
        {
            ORMFactory orm = new ORMFactory();
            int iTotalCountRows = 0;
            myPageIndex--;
            object retObj = null;
            try
            {
                retObj = orm.ReadViewDBListToObjsByFetch<PV_TrademarkFee>(myPageSize, myPageIndex, strOrderBy, ref Items, strSqlWhere, ref iTotalCountRows, sqlParameterList: MySqlParameterList, isStoredProcedure: IsStoredProcedure);
            }
            catch (InvalidCastException ex)
            {
                retObj = ex.Message;
            }

            return retObj;
        }
        #endregion

        #region #region public static object ReadList(string strSqlWhere, string strOrderBy, ref List<V_ProductTtest> Items, ref int iTotalCountRows, int myPageSize = 10, int myPageIndex = 0, System.Data.SqlClient.SqlParameter[] MySqlParameterList = null, bool IsStoredProcedure = false)
        /// <summary>
        /// [ReadViewDBListToObjsByFetch](使用MSSQL 2014的分頁做法OFFSET FETCH ，效能佳, §注意 MSSQL2008 無法使用)
        /// 取得多筆PV_TrademarkFee資料 ReadList
        /// 只要指定的Sql欄位有對應至類別屬性，則自動繫結       
        /// </summary>
        /// <param name="strSqlWhere">SQL條件式 (不用加「where」關鑵字)</param>  
        /// <param name="strOrderBy">排序的欄位; 例: CreateDateTime desc </param> 
        /// <param name="Items"></param>     
        /// <param name="iTotalCountRows">回傳此次查詢的總筆數</param>
        /// <param name="myPageSize">一頁的筆數,預設一頁 10 筆</param>  
        /// <param name="myPageIndex">當值為小於 0 時，預設帶 0 (從 0 起算，0即表示第1頁)</param>  
        /// <param name="MySqlParameterList">Sql參數</param>
        /// <param name="IsStoredProcedure">是否為StoredProcedure ,true:是 ; false:否(預設值)</param>
        /// <returns></returns>
        public static object ReadList(string strSqlWhere, string strOrderBy, ref List<PV_TrademarkFee> Items, ref int iTotalCountRows, int myPageSize = 10, int myPageIndex = 0, System.Data.SqlClient.SqlParameter[] MySqlParameterList = null, bool IsStoredProcedure = false)
        {
            ORMFactory orm = new ORMFactory();

            object retObj = null;
            try
            {
                retObj = orm.ReadViewDBListToObjsByFetch<PV_TrademarkFee>(myPageSize, myPageIndex, strOrderBy, ref Items, strSqlWhere, ref iTotalCountRows, sqlParameterList: MySqlParameterList, isStoredProcedure: IsStoredProcedure);
            }
            catch (InvalidCastException ex)
            {
                retObj = ex.Message;
            }

            return retObj;
        }
        #endregion

        #region [ReadViewDBListToObjsByFetch]多資料表join時使用 public static object ReadList(int myPageSize, int myPageIndex, string strOrderBy, string strSqlScript, ref List<PV_TrademarkFee> Items, ref int iTotalCountRows, System.Data.SqlClient.SqlParameter[] MySqlParameterList = null, bool IsStoredProcedure = false,string MyConnectionString="")
        /// <summary>
        /// [ReadViewDBListToObjsByFetch]多資料表join時使用，將結果繫結至Models (使用MSSQL 2014的分頁做法OFFSET FETCH ，效能佳, §注意 MSSQL2008 無法使用)
        /// </summary>
        /// <param name="myPageSize">一頁的筆數</param>
        /// <param name="myPageIndex">當值為小於 0 時，預設帶 0 (從 0 起算，0即表示第1頁)</param>
        /// <param name="strOrderBy">必要值(不得為空)，排序時需有指定排序的欄位, 例:「SiteKey desc , Account asc」</param>
        /// <param name="strSqlScript">提供完整的Sql Script 語法(注意select出來的資料需和物件的屬性對應)</param>
        /// <param name="Items"></param>
        /// <param name="iTotalCountRows">回傳此次查詢的總筆數</param>
        /// <param name="MySqlParameterList">Sql參數</param>
        /// <param name="IsStoredProcedure">是否為預存程序, 預設為False</param>
        /// <param name="MyConnectionString">預設為空字串，不為空字串時，以帶的連線字串為主; 若為空字串則以類別指定的連線字串( 當類別連線名稱為空則帶DBSetConnection.ConnectionListDefaultConnectionString )</param>
        /// <returns></returns>
        public static object ReadList(int myPageSize, int myPageIndex, string strOrderBy, string strSqlScript, ref List<PV_TrademarkFee> Items, ref int iTotalCountRows, System.Data.SqlClient.SqlParameter[] MySqlParameterList = null, bool IsStoredProcedure = false, string MyConnectionString = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = null;
            try
            {
                retObj = orm.ReadViewDBListToObjsByFetch<PV_TrademarkFee>(myPageSize, myPageIndex, strOrderBy, strSqlScript, ref Items, ref iTotalCountRows, sqlParameterList: MySqlParameterList, strConnectionString: MyConnectionString, isStoredProcedure: IsStoredProcedure);
            }
            catch (InvalidCastException ex)
            {
                retObj = ex.Message;
            }

            return retObj;
        }
        #endregion
        #endregion

    }
    #endregion  
}