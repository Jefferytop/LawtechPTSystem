using System;
using System.Collections.Generic;
using H3Operator.DBHelper;
using H3Operator.DBModels;

namespace LawtechPTSystem.Public
{
    #region CPatentFee=================
    /// <summary>
    /// 專利--請款記錄
    /// </summary>
    [TableMapping("PatentFeeT")]
    public class CPatentFee : SysBaseModel
    {
        #region Public property

        private int m_FeeKey;
        /// <summary>
        /// 專利費用請款記錄表 PK
        /// </summary>
        [TableColumnSetting("FeeKey", DbType = SqlDataType.Int, IsPrimary = true, IsCumulative = true, IsCanNull = false, DataLength = 4)]
        public int FeeKey
        {
            get
            {
                return m_FeeKey;
            }
            set
            {
                m_FeeKey = value;
            }
        }

        private int m_PatentID;
        /// <summary>
        /// 專利 PK
        /// </summary>
        [TableColumnSetting("PatentID", DbType = SqlDataType.Int, IsCanNull = false, DataLength = 4)]
        public int PatentID
        {
            get
            {
                return m_PatentID;
            }
            set
            {
                m_PatentID = value;
            }
        }

        private DateTime? m_RDate;
        /// <summary>
        /// 請款日期
        /// </summary>
        [TableColumnSetting("RDate", DbType = SqlDataType.DateTime, DataLength = 8)]
        public DateTime? RDate
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

        private DateTime? m_CollectionPeriod;
        /// <summary>
        /// 收款期限(預設 請款日期+14天)
        /// </summary>
        [TableColumnSetting("CollectionPeriod", DbType = SqlDataType.DateTime, DataLength = 8)]
        public DateTime? CollectionPeriod
        {
            get
            {
                return m_CollectionPeriod;
            }
            set
            {
                m_CollectionPeriod = value;
            }
        }

        private string m_FeeSubject;
        /// <summary>
        /// 費用內容
        /// </summary>
        [TableColumnSetting("FeeSubject", DataLength = 200)]
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

        private int? m_FeePhase;
        /// <summary>
        /// 費用種類
        /// </summary>
        [TableColumnSetting("FeePhase", DbType = SqlDataType.Int, DataLength = 4)]
        public int? FeePhase
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

        private int? m_Attorney;
        /// <summary>
        /// 受款人
        /// </summary>
        [TableColumnSetting("Attorney", DbType = SqlDataType.Int, DataLength = 4)]
        public int? Attorney
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

        private int? m_FClientTransactor;
        /// <summary>
        /// 請款人
        /// </summary>
        [TableColumnSetting("FClientTransactor", DbType = SqlDataType.Int, DataLength = 4)]
        public int? FClientTransactor
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

        private DateTime? m_IReceiptDate;
        /// <summary>
        /// 本事務所費用-收據日期
        /// </summary>
        [TableColumnSetting("IReceiptDate", DbType = SqlDataType.DateTime, DataLength = 8)]
        public DateTime? IReceiptDate
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
        /// <summary>
        /// 本事務所費用-收據編號
        /// </summary>
        [TableColumnSetting("IReceiptNo", DataLength = 100)]
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

        private DateTime? m_aBillDate;
        /// <summary>
        /// 本事務所費用-發票日期
        /// </summary>
        [TableColumnSetting("aBillDate", DbType = SqlDataType.DateTime, DataLength = 8)]
        public DateTime? aBillDate
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
        /// <summary>
        /// 本事務所費用-發票編號
        /// </summary>
        [TableColumnSetting("aBill", DataLength = 100)]
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

        private decimal? m_IAttorneyFee;
        /// <summary>
        /// 本事務所費用
        /// </summary>
        [TableColumnSetting("IAttorneyFee", DbType = SqlDataType.Decimal, DataLength = 9)]
        public decimal? IAttorneyFee
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
        /// <summary>
        /// 本事務所費用-幣別
        /// </summary>
        [TableColumnSetting("IMoney", DataLength = 100)]
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

        private decimal? m_ItoNT;
        /// <summary>
        /// 本事務所費用-兑NT
        /// </summary>
        [TableColumnSetting("ItoNT", DbType = SqlDataType.Decimal, DataLength = 9)]
        public decimal? ItoNT
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

        private decimal? m_ITotall;
        /// <summary>
        /// 本事務所費用-合計NT
        /// </summary>
        [TableColumnSetting("ITotall", DbType = SqlDataType.Decimal, DataLength = 9)]
        public decimal? ITotall
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

        private DateTime? m_OReceiptDate;
        /// <summary>
        /// 國外事務所費用-收據日期
        /// </summary>
        [TableColumnSetting("OReceiptDate", DbType = SqlDataType.DateTime, DataLength = 8)]
        public DateTime? OReceiptDate
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
        /// <summary>
        /// 國外事務所費用-收據編號
        /// </summary>
        [TableColumnSetting("OReceiptNo", DataLength = 100)]
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

        private decimal? m_OAttorneyFee;
        /// <summary>
        /// 國外事務所費用
        /// </summary>
        [TableColumnSetting("OAttorneyFee", DbType = SqlDataType.Decimal, DataLength = 9)]
        public decimal? OAttorneyFee
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
        /// <summary>
        /// 國外事務所費用-幣別
        /// </summary>
        [TableColumnSetting("OMoney", DataLength = 40)]
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

        private decimal? m_OtoNT;
        /// <summary>
        /// 國外事務所費用-兑NT
        /// </summary>
        [TableColumnSetting("OtoNT", DbType = SqlDataType.Decimal, DataLength = 9)]
        public decimal? OtoNT
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

        private decimal? m_OTotall;
        /// <summary>
        /// 國外事務所費用-合計NT
        /// </summary>
        [TableColumnSetting("OTotall", DbType = SqlDataType.Decimal, DataLength = 9)]
        public decimal? OTotall
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

        private DateTime? m_GReceiptDate;
        /// <summary>
        /// 官方規費-收據日期
        /// </summary>
        [TableColumnSetting("GReceiptDate", DbType = SqlDataType.DateTime, DataLength = 8)]
        public DateTime? GReceiptDate
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
        /// <summary>
        /// 官方規費-收據號碼
        /// </summary>
        [TableColumnSetting("GReceiptNo", DataLength = 100)]
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

        private decimal? m_GovFee;
        /// <summary>
        /// 官方規費
        /// </summary>
        [TableColumnSetting("GovFee", DbType = SqlDataType.Decimal, DataLength = 9)]
        public decimal? GovFee
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
        /// <summary>
        /// 官方規費-幣別
        /// </summary>
        [TableColumnSetting("GMoney", DataLength = 100)]
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

        private decimal? m_GtoNT;
        /// <summary>
        /// 官方規費-兌NT
        /// </summary>
        [TableColumnSetting("GtoNT", DbType = SqlDataType.Decimal, DataLength = 9)]
        public decimal? GtoNT
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

        private decimal? m_GTotall;
        /// <summary>
        /// 官方規費-合計NT
        /// </summary>
        [TableColumnSetting("GTotall", DbType = SqlDataType.Decimal, DataLength = 9)]
        public decimal? GTotall
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

        private decimal? m_OAttorneyGovFee;
        /// <summary>
        /// 代收代付合計NT
        /// </summary>
        [TableColumnSetting("OAttorneyGovFee", DbType = SqlDataType.Decimal, DataLength = 9)]
        public decimal? OAttorneyGovFee
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

        private decimal? m_Totall;
        /// <summary>
        /// 全部總計NT
        /// </summary>
        [TableColumnSetting("Totall", DbType = SqlDataType.Decimal, DataLength = 9)]
        public decimal? Totall
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
        /// <summary>
        /// 請款合計 幣別
        /// </summary>
        [TableColumnSetting("TMoney", DataLength = 100)]
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

        private decimal? m_TtoNT;
        /// <summary>
        /// 請款合計-兌NT(當時匯率)
        /// </summary>
        [TableColumnSetting("TtoNT", DbType = SqlDataType.Decimal, DataLength = 9)]
        public decimal? TtoNT
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

        private decimal? m_TotalNT;
        /// <summary>
        /// 請款合計
        /// </summary>
        [TableColumnSetting("TotalNT", DbType = SqlDataType.Decimal, DataLength = 9)]
        public decimal? TotalNT
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

        private string m_OthFeeName;
        /// <summary>
        /// 複代雜費-名稱
        /// </summary>
        [TableColumnSetting("OthFeeName", DataLength = 400)]
        public string OthFeeName
        {
            get
            {
                return m_OthFeeName;
            }
            set
            {
                m_OthFeeName = value;
            }
        }

        private decimal? m_OthFee;
        /// <summary>
        /// 複代雜費
        /// </summary>
        [TableColumnSetting("OthFee", DbType = SqlDataType.Decimal, DataLength = 9)]
        public decimal? OthFee
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

        private string m_OthMoney;
        /// <summary>
        /// 複代雜費-幣別
        /// </summary>
        [TableColumnSetting("OthMoney", DataLength = 100)]
        public string OthMoney
        {
            get
            {
                return m_OthMoney;
            }
            set
            {
                m_OthMoney = value;
            }
        }

        private decimal? m_OthtoNT;
        /// <summary>
        /// 複代雜費-匯率兌NT
        /// </summary>
        [TableColumnSetting("OthtoNT", DbType = SqlDataType.Decimal, DataLength = 9)]
        public decimal? OthtoNT
        {
            get
            {
                return m_OthtoNT;
            }
            set
            {
                m_OthtoNT = value;
            }
        }

        private decimal? m_OthTotal;
        /// <summary>
        /// 複代雜費合計NT
        /// </summary>
        [TableColumnSetting("OthTotal", DbType = SqlDataType.Decimal, DataLength = 9)]
        public decimal? OthTotal
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

        private string m_CustomizeName;
        /// <summary>
        /// 自定義費用名稱
        /// </summary>
        [TableColumnSetting("CustomizeName", DataLength = 100)]
        public string CustomizeName
        {
            get
            {
                return m_CustomizeName;
            }
            set
            {
                m_CustomizeName = value;
            }
        }

        private decimal? m_CustomizeOthFee;
        /// <summary>
        /// 自定義費用
        /// </summary>
        [TableColumnSetting("CustomizeOthFee", DbType = SqlDataType.Decimal, DataLength = 9)]
        public decimal? CustomizeOthFee
        {
            get
            {
                return m_CustomizeOthFee;
            }
            set
            {
                m_CustomizeOthFee = value;
            }
        }

        private string m_CustomizeMoney;
        /// <summary>
        /// 自定義費用-幣別
        /// </summary>
        [TableColumnSetting("CustomizeMoney", DataLength = 100)]
        public string CustomizeMoney
        {
            get
            {
                return m_CustomizeMoney;
            }
            set
            {
                m_CustomizeMoney = value;
            }
        }

        private decimal? m_CustomizeNT;
        /// <summary>
        /// 自定義費用-匯率
        /// </summary>
        [TableColumnSetting("CustomizeNT", DbType = SqlDataType.Decimal, DataLength = 9)]
        public decimal? CustomizeNT
        {
            get
            {
                return m_CustomizeNT;
            }
            set
            {
                m_CustomizeNT = value;
            }
        }

        private decimal? m_CustomizeTotal;
        /// <summary>
        /// 自定義費用-合計NT
        /// </summary>
        [TableColumnSetting("CustomizeTotal", DbType = SqlDataType.Decimal, DataLength = 9)]
        public decimal? CustomizeTotal
        {
            get
            {
                return m_CustomizeTotal;
            }
            set
            {
                m_CustomizeTotal = value;
            }
        }

        private decimal? m_OtherTotalFee;
        /// <summary>
        /// 本事務所費用-本所服務費
        /// </summary>
        [TableColumnSetting("OtherTotalFee", DbType = SqlDataType.Decimal, DataLength = 9)]
        public decimal? OtherTotalFee
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

        private string m_OtherTotalFeeCustomize1Name;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("OtherTotalFeeCustomize1Name", DataLength = 400)]
        public string OtherTotalFeeCustomize1Name
        {
            get
            {
                return m_OtherTotalFeeCustomize1Name;
            }
            set
            {
                m_OtherTotalFeeCustomize1Name = value;
            }
        }

        private decimal? m_OtherTotalFeeCustomize1;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("OtherTotalFeeCustomize1", DbType = SqlDataType.Decimal, DataLength = 9)]
        public decimal? OtherTotalFeeCustomize1
        {
            get
            {
                return m_OtherTotalFeeCustomize1;
            }
            set
            {
                m_OtherTotalFeeCustomize1 = value;
            }
        }

        private string m_OtherTotalFeeCustomize2Name;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("OtherTotalFeeCustomize2Name", DataLength = 400)]
        public string OtherTotalFeeCustomize2Name
        {
            get
            {
                return m_OtherTotalFeeCustomize2Name;
            }
            set
            {
                m_OtherTotalFeeCustomize2Name = value;
            }
        }

        private decimal? m_OtherTotalFeeCustomize2;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("OtherTotalFeeCustomize2", DbType = SqlDataType.Decimal, DataLength = 9)]
        public decimal? OtherTotalFeeCustomize2
        {
            get
            {
                return m_OtherTotalFeeCustomize2;
            }
            set
            {
                m_OtherTotalFeeCustomize2 = value;
            }
        }

        private string m_OtherTotalFeeCustomize3Name;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("OtherTotalFeeCustomize3Name", DataLength = 400)]
        public string OtherTotalFeeCustomize3Name
        {
            get
            {
                return m_OtherTotalFeeCustomize3Name;
            }
            set
            {
                m_OtherTotalFeeCustomize3Name = value;
            }
        }

        private decimal? m_OtherTotalFeeCustomize3;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("OtherTotalFeeCustomize3", DbType = SqlDataType.Decimal, DataLength = 9)]
        public decimal? OtherTotalFeeCustomize3
        {
            get
            {
                return m_OtherTotalFeeCustomize3;
            }
            set
            {
                m_OtherTotalFeeCustomize3 = value;
            }
        }

        private decimal? m_OtherTotalFeeInSide;
        /// <summary>
        /// 所內收費合計
        /// </summary>
        [TableColumnSetting("OtherTotalFeeInSide", DbType = SqlDataType.Decimal, DataLength = 9)]
        public decimal? OtherTotalFeeInSide
        {
            get
            {
                return m_OtherTotalFeeInSide;
            }
            set
            {
                m_OtherTotalFeeInSide = value;
            }
        }

        private decimal? m_OtherTotalFeeInSideTax;
        /// <summary>
        /// 未稅額合計(收費合計-預扣稅額)
        /// </summary>
        [TableColumnSetting("OtherTotalFeeInSideTax", DbType = SqlDataType.Decimal, DataLength = 9)]
        public decimal? OtherTotalFeeInSideTax
        {
            get
            {
                return m_OtherTotalFeeInSideTax;
            }
            set
            {
                m_OtherTotalFeeInSideTax = value;
            }
        }

        private DateTime? m_ReceiptDate;
        /// <summary>
        /// 收據日期
        /// </summary>
        [TableColumnSetting("ReceiptDate", DbType = SqlDataType.DateTime, DataLength = 8)]
        public DateTime? ReceiptDate
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

        private bool? m_Pay;
        /// <summary>
        /// 已請款
        /// </summary>
        [TableColumnSetting("Pay", DbType = SqlDataType.Bit, DataLength = 1)]
        public bool? Pay
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

        private DateTime? m_PayDate;
        /// <summary>
        /// 收款日期
        /// </summary>
        [TableColumnSetting("PayDate", DbType = SqlDataType.DateTime, DataLength = 8)]
        public DateTime? PayDate
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
        /// <summary>
        /// 請款單號
        /// </summary>
        [TableColumnSetting("PPP", DataLength = 100)]
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

        private bool? m_Withholding;
        /// <summary>
        /// 已預扣
        /// </summary>
        [TableColumnSetting("Withholding", DbType = SqlDataType.Bit, DataLength = 1)]
        public bool? Withholding
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

        private decimal? m_TaxPercent;
        /// <summary>
        /// 稅額%
        /// </summary>
        [TableColumnSetting("TaxPercent", DbType = SqlDataType.Decimal, DataLength = 5)]
        public decimal? TaxPercent
        {
            get
            {
                return m_TaxPercent;
            }
            set
            {
                m_TaxPercent = value;
            }
        }

        private decimal? m_Tax;
        /// <summary>
        /// 預扣稅額
        /// </summary>
        [TableColumnSetting("Tax", DbType = SqlDataType.Decimal, DataLength = 9)]
        public decimal? Tax
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

        private decimal? m_PracticalityPay;
        /// <summary>
        /// 實際收款
        /// </summary>
        [TableColumnSetting("PracticalityPay", DbType = SqlDataType.Decimal, DataLength = 9)]
        public decimal? PracticalityPay
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

        private bool? m_NT;
        /// <summary>
        /// 外幣支付
        /// </summary>
        [TableColumnSetting("NT", DbType = SqlDataType.Bit, DataLength = 1)]
        public bool? NT
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
        /// <summary>
        /// 付款方式
        /// </summary>
        [TableColumnSetting("PayKind", DataLength = 1000)]
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
        /// <summary>
        /// 備註
        /// </summary>
        [TableColumnSetting("Remark")]
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

        private int? m_PayType;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("PayType", DbType = SqlDataType.Int, DataLength = 4)]
        public int? PayType
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
        /// <summary>
        /// 請款處理說明
        /// </summary>
        [TableColumnSetting("PayMemo", DataLength = 1000)]
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
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("SingCode", DataLength = 200)]
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
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("SingCodeStatus", DataLength = 1000)]
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

        private int? m_Days;
        /// <summary>
        /// 付款方式--天
        /// </summary>
        [TableColumnSetting("Days", DbType = SqlDataType.Int, DataLength = 4)]
        public int? Days
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

        private bool? m_IsClosing;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("IsClosing", DbType = SqlDataType.Bit, DataLength = 1)]
        public bool? IsClosing
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

        private DateTime? m_CloseDate;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("CloseDate", DbType = SqlDataType.DateTime, DataLength = 8)]
        public DateTime? CloseDate
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
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("Creator", DataLength = 100)]
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

        private string m_LastModifyWorker;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("LastModifyWorker", DataLength = 100)]
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

        private int? m_LockedWorker;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("LockedWorker", DbType = SqlDataType.Int, DataLength = 4)]
        public int? LockedWorker
        {
            get
            {
                return m_LockedWorker;
            }
            set
            {
                m_LockedWorker = value;
            }
        }

    

        #endregion

        #region Method

        #region 確認指定欄位的值是否存在 CheckValueExist(string ColumnName, object Value ,ref bool IsExist, bool IsCreateMode = true)
        /// <summary>
        /// 確認指定欄位的值是否存在，true:已存在相同的值 ; false : 未存在 (有新增和編輯模式)
        /// </summary>
        /// <param name="ColumnName">欄位名稱</param>
        /// <param name="Value">要確認指定欄位是否有此值(只提供字串[string] 或數字[int])</param>
        /// <param name="IsExist">ture:已存在該值的資料 ; false:不存在該值的資料</param>
        /// <param name="IsCreateMode">模式 true:新增模式(預設值) ; false:編輯模式(排除本身的)</param>
        /// <returns>0:成功 ; string:失敗</returns>
        public object CheckValueExist(string ColumnName, object Value, ref bool IsExist, bool IsCreateMode = true)
        {
            ORMFactory orm = new ORMFactory();
            List<CPatentFee> list = new List<CPatentFee>();
            System.Data.SqlClient.SqlParameter para;

            if (Value.GetType() == string.Empty.GetType())
            {
                para = DBAccess.MakeInParam(ColumnName, SqlDataType.NVarChar, Value.ToString());
            }
            else
            {
                para = DBAccess.MakeInParam(ColumnName, SqlDataType.Int, (int)Value);
            }

            System.Data.SqlClient.SqlParameter[] ParList = { para };
            object retObj;
            if (IsCreateMode)
            {
                retObj = orm.ReadListToObjs<CPatentFee>(ColumnName + "=@" + ColumnName, ref list, ParList);
            }
            else
            {
                retObj = orm.ReadListToObjs<CPatentFee>(ColumnName + "=@" + ColumnName + " and FeeKey<>" + this.FeeKey.ToString(), ref list, ParList);
            }

            if (retObj.ToString() == "0")
            {
                if (list.Count > 0)
                {
                    IsExist = true;
                }
                else
                {
                    IsExist = false;
                }
            }
            return retObj;
        }
        #endregion

        #region 取得一筆資料  ReadOne(ref CPatentFee Item, string strCusTableName = ")
        /// <summary>
        /// 取得一筆PatentFeeT資料
        /// </summary>          
        /// <param name="item"></param>   
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>
        /// <returns>0:成功 ; string:失敗</returns>       
        public static object ReadOne(ref CPatentFee Item, string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.ReadOneToObj(ref Item, CusTableName: strCusTableName);
            return retObj;
        }
        #endregion

        #region 取得一筆資料 ReadOne(int iPKey, ref DB_MenuRoleTModel item, string strCusTableName = "")
        /// <summary>
        /// 取得一筆PatentFeeT資料
        /// </summary>
        /// <param name="iPKey">指定某筆資料的Key值(不適合複合key)</param>     
        /// <param name="item"></param>   
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>
        /// <returns>0:成功 ; string:失敗</returns>       
        public static object ReadOne(int iPKey, ref CPatentFee item, string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.ReadOneToObj(iPKey, ref item, CusTableName: strCusTableName);
            return retObj;
        }
        #endregion

        #region 取得一筆PatentFeeT資料 ReadOne(string strSqlWhere, System.Data.SqlClient.SqlParameter[] MySqlParameterList=null, string strCusTableName = "")
        /// <summary>
        /// 取得一筆PatentFeeT資料;如果有多筆符合條件，則只回傳null
        /// </summary>
        /// <param name="strSqlWhere">查詢條件(不用加「where」關鍵字, 可加Sql參數,例如: account=@account)</param>
        /// <param name="MySqlParameterList">Sql參數</param>
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>
        /// <returns>0:成功 ; string:失敗</returns>
        public static object ReadOne(string strSqlWhere, ref CPatentFee item, System.Data.SqlClient.SqlParameter[] MySqlParameterList = null, string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            List<CPatentFee> itemlist = new List<CPatentFee>();
            object retObj = orm.ReadListToObjs(strSqlWhere, ref itemlist, sqlParameterList: MySqlParameterList, CusTableName: strCusTableName);
            if (retObj.ToString() == "0" && itemlist.Count > 0)
            {
                if (itemlist.Count == 1)
                {
                    item = itemlist[0];
                }
                else
                {
                    retObj = "Error：有一筆以上的資料";
                }
            }
            return retObj;
        }
        #endregion

        #region 取得多筆CPatentFee資料 ReadList
        /// <summary>
        /// 取得多筆 PatentFeeT資料 
        /// </summary>
        /// <param name="Items"></param>
        /// <param name="strSqlWhere">SQL條件式 (不用加「where」關鑵字,可加Sql參數,例如: account=@account)</param>
        /// <param name="MySqlParameterList">Sql參數</param>
        /// <param name="strOrderBy">SQL排序式 , 當空值時，預設帶[ CreateDateTime Desc] (不用加「Order by 」關鑵字, 例 "uid desc,createDateTime asc ")</param>
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>      
        /// <returns></returns>
        public static object ReadList(ref List<CPatentFee> Items, string strSqlWhere = "", System.Data.SqlClient.SqlParameter[] MySqlParameterList = null, string strOrderBy = "", string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();

            object retObj = orm.ReadListToObjs<CPatentFee>(strSqlWhere, ref Items, sqlParameterList: MySqlParameterList, OrderBy: strOrderBy, CusTableName: strCusTableName);

            return retObj;
        }

        #endregion

        #region 取得多筆 PatentFeeT資料 , 指定頁數和頁碼 ReadList
        /// <summary>
        /// 取得多筆 PatentFeeT資料 , 指定頁數和頁碼
        /// </summary>
        /// <param name="PageSize">一頁的筆數</param>
        /// <param name="PageIndex">第 n 頁</param>
        /// <param name="Items"></param>
        /// <param name="strSqlWhere">SQL條件式 (不用加「where」關鑵字,可加Sql參數,例如: account=@account)</param>
        /// <param name="MySqlParameterList">Sql參數</param>
        /// <param name="strOrderBy">SQL排序式 , 當空值時，預設帶[ CreateDateTime Desc] (不用加「Order by 」關鑵字, 例 "uid desc,createDateTime asc ")</param>
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>       
        /// <returns></returns>
        public static object ReadList(int PageSize, int PageIndex, ref List<CPatentFee> Items, string strSqlWhere = "", System.Data.SqlClient.SqlParameter[] MySqlParameterList = null, string strOrderBy = "", string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();

            object retObj = orm.ReadListToObjs<CPatentFee>(PageSize, PageIndex, strSqlWhere, ref Items, sqlParameterList: MySqlParameterList, OrderBy: strOrderBy, CusTableName: strCusTableName);

            return retObj;
        }
        #endregion

        #region Create
        /// <summary>
        /// 新增PatentFeeT 項目
        /// </summary> 
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>      
        /// <returns>0:成功 ; string:失敗</returns>
        public object Create(string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.InsertByObj<CPatentFee>(this, strCusTableName);
            return retObj;
        }
        #endregion

        #region Update
        /// <summary>
        /// 更新 PatentFeeT 項目
        /// </summary>       
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param> 
        /// <returns>0:成功 ; string:失敗</returns>
        public object Update(string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.UpdateObj<CPatentFee>(this, strCusTableName);
            return retObj;
        }
        #endregion

        #region Delete

        #region 刪除項目PatentFeeT Delete()
        /// <summary>
        /// 刪除項目PatentFeeT
        /// </summary>  
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>
        /// <returns></returns>   
        public object Delete(string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.DeleteObj<CPatentFee>(this, strCusTableName);
            return retObj;
        }
        #endregion

        #region 刪除項目PatentFeeT Delete(int iPKey)
        /// <summary>
        /// 刪除項目PatentFeeT , 指定某一筆主鍵刪除(單筆)
        /// </summary>
        /// <param name="iPKey">指定刪除某筆資料的Key值</param> 
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>      
        /// <returns></returns>
        public object Delete(int iPKey, string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.DeleteObj<CPatentFee>(iPKey, strCusTableName);
            return retObj;
        }
        #endregion

        #region 刪除項目PatentFeeT Delete(string strSqlWhere)
        /// <summary>
        /// 刪除項目PatentFeeT ,符合條件刪除(多筆)
        /// </summary>
        /// <param name="strSqlWhere">查詢條件(不用加「where」關鍵字)</param>   
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>    
        /// <returns></returns>
        public object Delete(string strSqlWhere, string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.DeleteObj<CPatentFee>(strSqlWhere, strCusTableName);
            return retObj;
        }
        #endregion

        #endregion

        #endregion
    }
    #endregion =================
}
