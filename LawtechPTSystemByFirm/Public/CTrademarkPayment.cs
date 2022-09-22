using System;
using System.Collections.Generic;
using H3Operator.DBHelper;
using H3Operator.DBModels;

namespace LawtechPTSystemByFirm.Public
{
    #region CTrademarkPayment=================
    /// <summary>
    /// 
    /// </summary>
    [TableMapping("TrademarkPaymentT")]
    public class CTrademarkPayment : SysBaseModel
    {
        #region Public property

        private int m_PaymentID;
        /// <summary>
        /// 商標付款資料表 PK
        /// </summary>
        [TableColumnSetting("PaymentID", DbType = SqlDataType.Int, IsPrimary = true, IsCumulative = true, IsCanNull = false, DataLength = 4)]
        public int PaymentID
        {
            get
            {
                return m_PaymentID;
            }
            set
            {
                m_PaymentID = value;
            }
        }

        private int m_TrademarkID;
        /// <summary>
        /// 商標基本資料表 PK
        /// </summary>
        [TableColumnSetting("TrademarkID", DbType = SqlDataType.Int, IsCanNull = false, DataLength = 4)]
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

        private string m_FeeSubject;
        /// <summary>
        /// 費用內容
        /// </summary>
        [TableColumnSetting("FeeSubject", DataLength = 1000)]
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

        private int? m_Attorney;
        /// <summary>
        /// 受款人(預設帶國外事務所)
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

        private string m_PayKind;
        /// <summary>
        /// 付款方式
        /// </summary>
        [TableColumnSetting("PayKind", DataLength = 100)]
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

        private DateTime? m_IReceiptDate;
        /// <summary>
        /// 收據日期
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
        /// 收據號碼
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

        private string m_IMoney;
        /// <summary>
        /// 幣別
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

        private decimal? m_IServiceFee;
        /// <summary>
        /// 服務費
        /// </summary>
        [TableColumnSetting("IServiceFee", DbType = SqlDataType.Decimal, DataLength = 9)]
        public decimal? IServiceFee
        {
            get
            {
                return m_IServiceFee;
            }
            set
            {
                m_IServiceFee = value;
            }
        }

        private decimal? m_GovFee;
        /// <summary>
        /// 官費
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

        private decimal? m_OtherFee;
        /// <summary>
        /// 雜支
        /// </summary>
        [TableColumnSetting("OtherFee", DbType = SqlDataType.Decimal, DataLength = 9)]
        public decimal? OtherFee
        {
            get
            {
                return m_OtherFee;
            }
            set
            {
                m_OtherFee = value;
            }
        }

        private decimal? m_ExchangeRate;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("ExchangeRate", DbType = SqlDataType.Decimal, DataLength = 9)]
        public decimal? ExchangeRate
        {
            get
            {
                return m_ExchangeRate;
            }
            set
            {
                m_ExchangeRate = value;
            }
        }

        private decimal? m_Totall;
        /// <summary>
        /// 金額合計NT
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

        private decimal? m_ActuallyPay;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("ActuallyPay", DbType = SqlDataType.Decimal, DataLength = 9)]
        public decimal? ActuallyPay
        {
            get
            {
                return m_ActuallyPay;
            }
            set
            {
                m_ActuallyPay = value;
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

        private string m_Memo;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("Memo")]
        public string Memo
        {
            get
            {
                return m_Memo;
            }
            set
            {
                m_Memo = value;
            }
        }

        private string m_BillCheck;
        /// <summary>
        /// 帳單確認
        /// </summary>
        [TableColumnSetting("BillCheck", DataLength = 100)]
        public string BillCheck
        {
            get
            {
                return m_BillCheck;
            }
            set
            {
                m_BillCheck = value;
            }
        }

        private DateTime? m_ReciveDate;
        /// <summary>
        /// 收件日期
        /// </summary>
        [TableColumnSetting("ReciveDate", DbType = SqlDataType.DateTime, DataLength = 8)]
        public DateTime? ReciveDate
        {
            get
            {
                return m_ReciveDate;
            }
            set
            {
                m_ReciveDate = value;
            }
        }

        private DateTime? m_PayDueDate;
        /// <summary>
        /// 付款期限
        /// </summary>
        [TableColumnSetting("PayDueDate", DbType = SqlDataType.DateTime, DataLength = 8)]
        public DateTime? PayDueDate
        {
            get
            {
                return m_PayDueDate;
            }
            set
            {
                m_PayDueDate = value;
            }
        }

        private DateTime? m_PaymentDate;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("PaymentDate", DbType = SqlDataType.DateTime, DataLength = 8)]
        public DateTime? PaymentDate
        {
            get
            {
                return m_PaymentDate;
            }
            set
            {
                m_PaymentDate = value;
            }
        }

        private DateTime? m_EstimatedPaymentDate;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("EstimatedPaymentDate", DbType = SqlDataType.DateTime, DataLength = 8)]
        public DateTime? EstimatedPaymentDate
        {
            get
            {
                return m_EstimatedPaymentDate;
            }
            set
            {
                m_EstimatedPaymentDate = value;
            }
        }

        private bool? m_IsBilling;
        /// <summary>
        /// 是否請款
        /// </summary>
        [TableColumnSetting("IsBilling", DbType = SqlDataType.Bit, DataLength = 1)]
        public bool? IsBilling
        {
            get
            {
                return m_IsBilling;
            }
            set
            {
                m_IsBilling = value;
            }
        }

        private string m_BillingNo;
        /// <summary>
        /// 請款單編號
        /// </summary>
        [TableColumnSetting("BillingNo", DataLength = 100)]
        public string BillingNo
        {
            get
            {
                return m_BillingNo;
            }
            set
            {
                m_BillingNo = value;
            }
        }

        private bool? m_IsCopyFile;
        /// <summary>
        /// 是否有影本
        /// </summary>
        [TableColumnSetting("IsCopyFile", DbType = SqlDataType.Bit, DataLength = 1)]
        public bool? IsCopyFile
        {
            get
            {
                return m_IsCopyFile;
            }
            set
            {
                m_IsCopyFile = value;
            }
        }

        private bool? m_IsScan;
        /// <summary>
        /// 是否有掃瞄
        /// </summary>
        [TableColumnSetting("IsScan", DbType = SqlDataType.Bit, DataLength = 1)]
        public bool? IsScan
        {
            get
            {
                return m_IsScan;
            }
            set
            {
                m_IsScan = value;
            }
        }

        private string m_SingCode;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("SingCode", DataLength = 1000)]
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

        private int? m_AcountingFirmKey;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("AcountingFirmKey", DbType = SqlDataType.Int, DataLength = 4)]
        public int? AcountingFirmKey
        {
            get
            {
                return m_AcountingFirmKey;
            }
            set
            {
                m_AcountingFirmKey = value;
            }
        }

        private string m_Creator;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("Creator", DataLength = 200)]
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
        [TableColumnSetting("LastModifyWorker", DataLength = 200)]
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

        private int? m_Locker;
        /// <summary>
        /// 
        /// </summary>
        [TableColumnSetting("Locker", DbType = SqlDataType.Int, DataLength = 4)]
        public int? Locker
        {
            get
            {
                return m_Locker;
            }
            set
            {
                m_Locker = value;
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
            List<CTrademarkPayment> list = new List<CTrademarkPayment>();
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
                retObj = orm.ReadListToObjs<CTrademarkPayment>(ColumnName + "=@" + ColumnName, ref list, ParList);
            }
            else
            {
                retObj = orm.ReadListToObjs<CTrademarkPayment>(ColumnName + "=@" + ColumnName + " and PaymentID<>" + this.PaymentID.ToString(), ref list, ParList);
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

        #region 取得一筆資料  ReadOne(ref CTrademarkPayment Item, string strCusTableName = ")
        /// <summary>
        /// 取得一筆TrademarkPaymentT資料
        /// </summary>          
        /// <param name="item"></param>   
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>
        /// <returns>0:成功 ; string:失敗</returns>       
        public static object ReadOne(ref CTrademarkPayment Item, string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.ReadOneToObj(ref Item, CusTableName: strCusTableName);
            return retObj;
        }
        #endregion

        #region 取得一筆資料 ReadOne(int iPKey, ref CTrademarkPayment item, string strCusTableName = "")
        /// <summary>
        /// 取得一筆TrademarkPaymentT資料
        /// </summary>
        /// <param name="iPKey">指定某筆資料的Key值(不適合複合key)</param>     
        /// <param name="item"></param>   
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>
        /// <returns>0:成功 ; string:失敗</returns>       
        public static object ReadOne(int iPKey, ref CTrademarkPayment item, string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.ReadOneToObj(iPKey, ref item, CusTableName: strCusTableName);
            return retObj;
        }
        #endregion

        #region 取得一筆TrademarkPaymentT資料 ReadOne(string strSqlWhere, System.Data.SqlClient.SqlParameter[] MySqlParameterList=null, string strCusTableName = "")
        /// <summary>
        /// 取得一筆TrademarkPaymentT資料;如果有多筆符合條件，則只回傳null
        /// </summary>
        /// <param name="strSqlWhere">查詢條件(不用加「where」關鍵字, 可加Sql參數,例如: account=@account)</param>
        /// <param name="MySqlParameterList">Sql參數</param>
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>
        /// <returns>0:成功 ; string:失敗</returns>
        public static object ReadOne(string strSqlWhere, ref CTrademarkPayment item, System.Data.SqlClient.SqlParameter[] MySqlParameterList = null, string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            List<CTrademarkPayment> itemlist = new List<CTrademarkPayment>();
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

        #region 取得多筆CTrademarkPayment資料 ReadList
        /// <summary>
        /// 取得多筆 TrademarkPaymentT資料 
        /// </summary>
        /// <param name="Items"></param>
        /// <param name="strSqlWhere">SQL條件式 (不用加「where」關鑵字,可加Sql參數,例如: account=@account)</param>
        /// <param name="MySqlParameterList">Sql參數</param>
        /// <param name="strOrderBy">SQL排序式 , 當空值時，預設帶[ CreateDateTime Desc] (不用加「Order by 」關鑵字, 例 "uid desc,createDateTime asc ")</param>
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>      
        /// <returns></returns>
        public static object ReadList(ref List<CTrademarkPayment> Items, string strSqlWhere = "", System.Data.SqlClient.SqlParameter[] MySqlParameterList = null, string strOrderBy = "", string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();

            object retObj = orm.ReadListToObjs<CTrademarkPayment>(strSqlWhere, ref Items, sqlParameterList: MySqlParameterList, OrderBy: strOrderBy, CusTableName: strCusTableName);

            return retObj;
        }

        #endregion

        #region 取得多筆 TrademarkPaymentT資料 , 指定頁數和頁碼 ReadList
        /// <summary>
        /// 取得多筆 TrademarkPaymentT資料 , 指定頁數和頁碼
        /// </summary>
        /// <param name="PageSize">一頁的筆數</param>
        /// <param name="PageIndex">第 n 頁</param>
        /// <param name="Items"></param>
        /// <param name="strSqlWhere">SQL條件式 (不用加「where」關鑵字,可加Sql參數,例如: account=@account)</param>
        /// <param name="MySqlParameterList">Sql參數</param>
        /// <param name="strOrderBy">SQL排序式 , 當空值時，預設帶[ CreateDateTime Desc] (不用加「Order by 」關鑵字, 例 "uid desc,createDateTime asc ")</param>
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>       
        /// <returns></returns>
        public static object ReadList(int PageSize, int PageIndex, ref List<CTrademarkPayment> Items, string strSqlWhere = "", System.Data.SqlClient.SqlParameter[] MySqlParameterList = null, string strOrderBy = "", string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();

            object retObj = orm.ReadListToObjs<CTrademarkPayment>(PageSize, PageIndex, strSqlWhere, ref Items, sqlParameterList: MySqlParameterList, OrderBy: strOrderBy, CusTableName: strCusTableName);

            return retObj;
        }
        #endregion

        #region Create
        /// <summary>
        /// 新增TrademarkPaymentT 項目
        /// </summary> 
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>      
        /// <returns>0:成功 ; string:失敗</returns>
        public object Create(string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.InsertByObj<CTrademarkPayment>(this, strCusTableName);
            return retObj;
        }
        #endregion

        #region Update
        /// <summary>
        /// 更新 TrademarkPaymentT 項目
        /// </summary>       
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param> 
        /// <returns>0:成功 ; string:失敗</returns>
        public object Update(string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.UpdateObj<CTrademarkPayment>(this, strCusTableName);
            return retObj;
        }
        #endregion

        #region Delete

        #region 刪除項目TrademarkPaymentT Delete()
        /// <summary>
        /// 刪除項目TrademarkPaymentT
        /// </summary>  
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>
        /// <returns></returns>   
        public object Delete(string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.DeleteObj<CTrademarkPayment>(this, strCusTableName);
            return retObj;
        }
        #endregion

        #region 刪除項目TrademarkPaymentT Delete(int iPKey)
        /// <summary>
        /// 刪除項目TrademarkPaymentT , 指定某一筆主鍵刪除(單筆)
        /// </summary>
        /// <param name="iPKey">指定刪除某筆資料的Key值</param> 
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>      
        /// <returns></returns>
        public object Delete(int iPKey, string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.DeleteObj<CTrademarkPayment>(iPKey, strCusTableName);
            return retObj;
        }
        #endregion

        #region 刪除項目TrademarkPaymentT Delete(string strSqlWhere)
        /// <summary>
        /// 刪除項目TrademarkPaymentT ,符合條件刪除(多筆)
        /// </summary>
        /// <param name="strSqlWhere">查詢條件(不用加「where」關鍵字)</param>   
        /// <param name="strCusTableName">指定的資料表; 若為空則採預設的Model所綁定的資料表</param>    
        /// <returns></returns>
        public object Delete(string strSqlWhere, string strCusTableName = "")
        {
            ORMFactory orm = new ORMFactory();
            object retObj = orm.DeleteObj<CTrademarkPayment>(strSqlWhere, strCusTableName);
            return retObj;
        }
        #endregion

        #endregion

        #endregion
    }
    #endregion =================
}
