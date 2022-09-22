using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using H3Operator.DBHelper;

namespace LawtechPTSystem.Public
{
    #region ======CTrademarkControversyPayment======
    public class CTrademarkControversyPayment
    {
        SqlConnection conn = new SqlConnection(DBAccess.ConnectionListDefaultConnectionString);
        SqlDataAdapter sAdapter;
        SqlCommandBuilder CBuilder;

        DataTable dt;
        /// <summary>
        /// 預設帶出所有的資料
        /// </summary>
        public CTrademarkControversyPayment()
        {
            sAdapter = new SqlDataAdapter("select * from TrademarkControversyPaymentT", conn);
            dt = new DataTable();
            //DataSet ds = new DataSet();
            //ds.Tables.Add(dt);
            sAdapter.FillSchema(dt, SchemaType.Source);
            sAdapter.Fill(dt);
            CBuilder = new SqlCommandBuilder(sAdapter);
            sAdapter.InsertCommand = CBuilder.GetInsertCommand(true);
            sAdapter.InsertCommand.UpdatedRowSource = UpdateRowSource.Both;
            sAdapter.InsertCommand.CommandText += " Select @@IDENTITY AS 'IDENTITY'";
            sAdapter.UpdateCommand = new SqlCommand(@"UPDATE TrademarkControversyPaymentT  SET 
                                                       TrademarkControversyID=@TrademarkControversyID,
                                                       RDate=@RDate,
                                                       FeeSubject=@FeeSubject,
                                                       FeePhase=@FeePhase,
                                                       FClientTransactor=@FClientTransactor,
                                                       Attorney=@Attorney,
                                                       PayKind=@PayKind,
                                                       IReceiptDate=@IReceiptDate,
                                                       IReceiptNo=@IReceiptNo,
                                                       IMoney=@IMoney,
                                                       IServiceFee=@IServiceFee,
                                                       GovFee=@GovFee,
                                                       OtherFee=@OtherFee,
                                                       ExchangeRate=@ExchangeRate,
                                                       Totall=@Totall,
                                                       ActuallyPay=@ActuallyPay,
                                                       Remark=@Remark,
                                                       Memo=@Memo,
                                                       BillCheck=@BillCheck,
                                                       ReciveDate=@ReciveDate,
                                                       PayDueDate=@PayDueDate,
                                                       PaymentDate=@PaymentDate,
                                                       EstimatedPaymentDate=@EstimatedPaymentDate,
                                                       SingCode=@SingCode,
                                                       IsBilling=@IsBilling,
                                                       BillingNo=@BillingNo,
                                                       IsCopyFile=@IsCopyFile,
                                                       IsScan=@IsScan,
                                                       IsClosing=@IsClosing,
                                                       CloseDate=@CloseDate,
                                                       AcountingFirmKey=@AcountingFirmKey,
                                                       UpbuildDay=@UpbuildDay,
                                                       LastModifyDate=@LastModifyDate,
                                                       LastModifyWorker=@LastModifyWorker,
                                                       Locker=@Locker
                                                   where 
                                                       ControversyPaymentID=@ControversyPaymentID", conn);
        }
        /// <summary>
        /// 有條件的過濾資料
        /// </summary>
        /// <param name="sWhere">SQL的條件式</param>
        public CTrademarkControversyPayment(string sWhere)
        {
            sAdapter = new SqlDataAdapter("select * from TrademarkControversyPaymentT where " + sWhere, conn);
            dt = new DataTable();
            //DataSet ds = new DataSet();
            //ds.Tables.Add(dt);
            sAdapter.FillSchema(dt, SchemaType.Source);
            sAdapter.Fill(dt);
            CBuilder = new SqlCommandBuilder(sAdapter);
            sAdapter.InsertCommand = CBuilder.GetInsertCommand(true);
            sAdapter.InsertCommand.UpdatedRowSource = UpdateRowSource.Both;
            sAdapter.InsertCommand.CommandText += " Select @@IDENTITY AS 'IDENTITY'";
            sAdapter.UpdateCommand = new SqlCommand(@"UPDATE TrademarkControversyPaymentT  SET 
                                                       TrademarkControversyID=@TrademarkControversyID,
                                                       RDate=@RDate,
                                                       FeeSubject=@FeeSubject,
                                                       FeePhase=@FeePhase,
                                                       FClientTransactor=@FClientTransactor,
                                                       Attorney=@Attorney,
                                                       PayKind=@PayKind,
                                                       IReceiptDate=@IReceiptDate,
                                                       IReceiptNo=@IReceiptNo,
                                                       IMoney=@IMoney,
                                                       IServiceFee=@IServiceFee,
                                                       GovFee=@GovFee,
                                                       OtherFee=@OtherFee,
                                                       ExchangeRate=@ExchangeRate,
                                                       Totall=@Totall,
                                                       ActuallyPay=@ActuallyPay,
                                                       Remark=@Remark,
                                                       Memo=@Memo,
                                                       BillCheck=@BillCheck,
                                                       ReciveDate=@ReciveDate,
                                                       PayDueDate=@PayDueDate,
                                                       PaymentDate=@PaymentDate,
                                                       EstimatedPaymentDate=@EstimatedPaymentDate,
                                                       SingCode=@SingCode,
                                                       IsBilling=@IsBilling,
                                                       BillingNo=@BillingNo,
                                                       IsCopyFile=@IsCopyFile,
                                                       IsScan=@IsScan,
                                                       IsClosing=@IsClosing,
                                                       CloseDate=@CloseDate,
                                                       AcountingFirmKey=@AcountingFirmKey,
                                                       UpbuildDay=@UpbuildDay,
                                                       LastModifyDate=@LastModifyDate,
                                                       LastModifyWorker=@LastModifyWorker,
                                                       Locker=@Locker
                                                   where 
                                                       ControversyPaymentID=@ControversyPaymentID", conn);
        }


        private int _ControversyPaymentID = -1;
        /// <summary>  
        /// 
        /// </summary>  
        public int ControversyPaymentID
        {
            get
            {
                return _ControversyPaymentID;
            }
            set
            {
                _ControversyPaymentID = value;
            }
        }
        private int _TrademarkControversyID = -1;
        /// <summary>  
        /// 商標基本資料表 PK
        /// </summary>  
        public int TrademarkControversyID
        {
            get
            {
                return _TrademarkControversyID;
            }
            set
            {
                _TrademarkControversyID = value;
            }
        }
        private DateTime _RDate = DateTime.Parse("1900/1/1");
        /// <summary>  
        /// 請款日期
        /// </summary>  
        public DateTime RDate
        {
            get
            {
                return _RDate;
            }
            set
            {
                _RDate = value;
            }
        }
        private string _FeeSubject = "";
        /// <summary>  
        /// 費用內容
        /// </summary>  
        public String FeeSubject
        {
            get
            {
                return _FeeSubject;
            }
            set
            {
                _FeeSubject = value;
            }
        }
        private int _FeePhase = -1;
        /// <summary>  
        /// 費用種類
        /// </summary>  
        public int FeePhase
        {
            get
            {
                return _FeePhase;
            }
            set
            {
                _FeePhase = value;
            }
        }
        private int _FClientTransactor = -1;
        /// <summary>  
        /// 請款人
        /// </summary>  
        public int FClientTransactor
        {
            get
            {
                return _FClientTransactor;
            }
            set
            {
                _FClientTransactor = value;
            }
        }
        private int _Attorney = -1;
        /// <summary>  
        /// 
        /// </summary>  
        public int Attorney
        {
            get
            {
                return _Attorney;
            }
            set
            {
                _Attorney = value;
            }
        }
        private string _PayKind = "";
        /// <summary>  
        /// 付款方式
        /// </summary>  
        public String PayKind
        {
            get
            {
                return _PayKind;
            }
            set
            {
                _PayKind = value;
            }
        }
        private DateTime _IReceiptDate = DateTime.Parse("1900/1/1");
        /// <summary>  
        /// 收據日期
        /// </summary>  
        public DateTime IReceiptDate
        {
            get
            {
                return _IReceiptDate;
            }
            set
            {
                _IReceiptDate = value;
            }
        }
        private string _IReceiptNo = "";
        /// <summary>  
        /// 收據號碼
        /// </summary>  
        public String IReceiptNo
        {
            get
            {
                return _IReceiptNo;
            }
            set
            {
                _IReceiptNo = value;
            }
        }
        private string _IMoney = "";
        /// <summary>  
        /// 幣別
        /// </summary>  
        public String IMoney
        {
            get
            {
                return _IMoney;
            }
            set
            {
                _IMoney = value;
            }
        }
        private decimal _IServiceFee = 0;
        /// <summary>  
        /// 服務費
        /// </summary>  
        public decimal IServiceFee
        {
            get
            {
                return _IServiceFee;
            }
            set
            {
                _IServiceFee = value;
            }
        }
        private decimal _GovFee = 0;
        /// <summary>  
        /// 官費
        /// </summary>  
        public decimal GovFee
        {
            get
            {
                return _GovFee;
            }
            set
            {
                _GovFee = value;
            }
        }
        private decimal _OtherFee = 0;
        /// <summary>  
        /// 雜支
        /// </summary>  
        public decimal OtherFee
        {
            get
            {
                return _OtherFee;
            }
            set
            {
                _OtherFee = value;
            }
        }
        private decimal _ExchangeRate = 0;
        /// <summary>  
        /// 當時匯率
        /// </summary>  
        public decimal ExchangeRate
        {
            get
            {
                return _ExchangeRate;
            }
            set
            {
                _ExchangeRate = value;
            }
        }
        private decimal _Totall = 0;
        /// <summary>  
        /// 金額合計NT
        /// </summary>  
        public decimal Totall
        {
            get
            {
                return _Totall;
            }
            set
            {
                _Totall = value;
            }
        }
        private decimal _ActuallyPay = 0;
        /// <summary>  
        /// 實付金額NT
        /// </summary>  
        public decimal ActuallyPay
        {
            get
            {
                return _ActuallyPay;
            }
            set
            {
                _ActuallyPay = value;
            }
        }
        private string _Remark = "";
        /// <summary>  
        /// 備註
        /// </summary>  
        public String Remark
        {
            get
            {
                return _Remark;
            }
            set
            {
                _Remark = value;
            }
        }
        private string _Memo = "";
        /// <summary>  
        /// 付款說明
        /// </summary>  
        public String Memo
        {
            get
            {
                return _Memo;
            }
            set
            {
                _Memo = value;
            }
        }
        private string _BillCheck = "";
        /// <summary>  
        /// 帳單確認
        /// </summary>  
        public String BillCheck
        {
            get
            {
                return _BillCheck;
            }
            set
            {
                _BillCheck = value;
            }
        }
        private DateTime _ReciveDate = DateTime.Parse("1900/1/1");
        /// <summary>  
        /// 收件日期
        /// </summary>  
        public DateTime ReciveDate
        {
            get
            {
                return _ReciveDate;
            }
            set
            {
                _ReciveDate = value;
            }
        }
        private DateTime _PayDueDate = DateTime.Parse("1900/1/1");
        /// <summary>  
        /// 付款期限
        /// </summary>  
        public DateTime PayDueDate
        {
            get
            {
                return _PayDueDate;
            }
            set
            {
                _PayDueDate = value;
            }
        }
        private DateTime _PaymentDate = DateTime.Parse("1900/1/1");
        /// <summary>  
        /// 付款日期
        /// </summary>  
        public DateTime PaymentDate
        {
            get
            {
                return _PaymentDate;
            }
            set
            {
                _PaymentDate = value;
            }
        }
        private DateTime _EstimatedPaymentDate = DateTime.Parse("1900/1/1");
        /// <summary>  
        /// 
        /// </summary>  
        public DateTime EstimatedPaymentDate
        {
            get
            {
                return _EstimatedPaymentDate;
            }
            set
            {
                _EstimatedPaymentDate = value;
            }
        }
        private string _SingCode = "";
        /// <summary>  
        /// 
        /// </summary>  
        public String SingCode
        {
            get
            {
                return _SingCode;
            }
            set
            {
                _SingCode = value;
            }
        }
        private bool _IsBilling = false;
        /// <summary>  
        /// 是否請款
        /// </summary>  
        public bool IsBilling
        {
            get
            {
                return _IsBilling;
            }
            set
            {
                _IsBilling = value;
            }
        }
        private string _BillingNo = "";
        /// <summary>  
        /// 請款單編號
        /// </summary>  
        public String BillingNo
        {
            get
            {
                return _BillingNo;
            }
            set
            {
                _BillingNo = value;
            }
        }
        private bool _IsCopyFile = false;
        /// <summary>  
        /// 是否有影本
        /// </summary>  
        public bool IsCopyFile
        {
            get
            {
                return _IsCopyFile;
            }
            set
            {
                _IsCopyFile = value;
            }
        }
        private bool _IsScan = false;
        /// <summary>  
        /// 是否有掃瞄
        /// </summary>  
        public bool IsScan
        {
            get
            {
                return _IsScan;
            }
            set
            {
                _IsScan = value;
            }
        }
        private bool _IsClosing = false;
        /// <summary>  
        /// 是否關帳(True 關    False 開放中)
        /// </summary>  
        public bool IsClosing
        {
            get
            {
                return _IsClosing;
            }
            set
            {
                _IsClosing = value;
            }
        }
        private DateTime _CloseDate = DateTime.Parse("1900/1/1");
        /// <summary>  
        /// 關帳日期
        /// </summary>  
        public DateTime CloseDate
        {
            get
            {
                return _CloseDate;
            }
            set
            {
                _CloseDate = value;
            }
        }
        private int _AcountingFirmKey = -1;
        /// <summary>  
        /// 付款事務所
        /// </summary>  
        public int AcountingFirmKey
        {
            get
            {
                return _AcountingFirmKey;
            }
            set
            {
                _AcountingFirmKey = value;
            }
        }
        private DateTime _UpbuildDay = DateTime.Parse("1900/1/1");
        /// <summary>  
        /// 
        /// </summary>  
        public DateTime UpbuildDay
        {
            get
            {
                return _UpbuildDay;
            }
            set
            {
                _UpbuildDay = value;
            }
        }
        private DateTime _LastModifyDate = DateTime.Parse("1900/1/1");
        /// <summary>  
        /// 
        /// </summary>  
        public DateTime LastModifyDate
        {
            get
            {
                return _LastModifyDate;
            }
            set
            {
                _LastModifyDate = value;
            }
        }
        private int _LastModifyWorker = -1;
        /// <summary>  
        /// 
        /// </summary>  
        public int LastModifyWorker
        {
            get
            {
                return _LastModifyWorker;
            }
            set
            {
                _LastModifyWorker = value;
            }
        }
        private int _Locker = -1;
        /// <summary>  
        /// 正在編輯者 進行資料鎖定, Null表示無人編輯中
        /// </summary>  
        public int Locker
        {
            get
            {
                return _Locker;
            }
            set
            {
                _Locker = value;
            }
        }

        /// <summary>
        /// 取得TrademarkControversyPaymentT資料集
        /// </summary>
        public DataTable GetDataTable()
        {
            return dt;
        }

        /// <summary>
        /// 設定TrademarkControversyPaymentT資料集
        /// </summary>
        /// <param name="ReTable"></param>
        public void SetDataTable(DataTable ReTable)
        {
            dt = ReTable;
        }

        /// <summary> 
        /// 確認該欄位的值是否重複   true:表示沒有這個值  false:表示資料庫已有這個值
        /// </summary> 
        /// <param name="ColumnName">資料庫欄位名稱</param> 
        /// <param name="Value">欄位的值</param> 
        /// <returns>true:表示沒有這個值  false:表示資料庫已有這個值</returns> 
        public bool CheckValue(string ColumnName, string Value)
        {
            bool bValue = true;
            Value.Replace("'", "").Replace("--", "").Replace("@", "");
            string strSQL = "select count(" + ColumnName + ") as CountValue from TrademarkControversyPaymentT where " + ColumnName + "='" + Value + "'";
            SqlCommand comm = new SqlCommand(strSQL, conn);
            conn.Open();
            object obj = comm.ExecuteScalar();
            conn.Close();
            if (obj != null && (int)obj > 0)
            {
                bValue = false;
            }
            else
            {
                bValue = true;
            }
            return bValue;
        }
        /// <summary> 
        /// 確認該欄位的值是否重複 
        /// </summary> 
        /// <param name="ColumnName">資料庫欄位名稱</param> 
        /// <param name="Value">欄位的值</param> 
        /// <returns>true:表示沒有這個值  false:表示資料庫已有這個值</returns> 
        public bool CheckValue(string ColumnName, int Value)
        {
            bool bValue = true;
            string strSQL = "select count(" + ColumnName + ") as CountValue from TrademarkControversyPaymentT where " + ColumnName + "=" + Value;
            SqlCommand comm = new SqlCommand(strSQL, conn);
            conn.Open();
            object obj = comm.ExecuteScalar();
            conn.Close();
            if (obj != null && (int)obj > 0)
            {
                bValue = false;
            }
            else
            {
                bValue = true;
            }
            return bValue;
        }

        public DataRow GetRow(string ColumnName, string Value)
        {
            dt.Rows.Clear();
            sAdapter.Fill(dt);
            DataRow dr = dt.NewRow();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i][ColumnName].ToString() == Value)
                {
                    dr = dt.Rows[i];

                    break;
                }
            }
            return dr;
        }
        public void SetCurrent(int NO)
        {
            try
            {
                DataRow dr = dt.Rows.Find(NO);
                this.ControversyPaymentID = dr["ControversyPaymentID"].ToString() == "" ? -1 : (int)dr["ControversyPaymentID"];
                this.TrademarkControversyID = dr["TrademarkControversyID"].ToString() == "" ? -1 : (int)dr["TrademarkControversyID"];
                this.RDate = dr["RDate"].ToString() == "" ? DateTime.Parse("1900/1/1") : (DateTime)dr["RDate"];
                this.FeeSubject = dr["FeeSubject"].ToString();
                this.FeePhase = dr["FeePhase"].ToString() == "" ? -1 : (int)dr["FeePhase"];
                this.FClientTransactor = dr["FClientTransactor"].ToString() == "" ? -1 : (int)dr["FClientTransactor"];
                this.Attorney = dr["Attorney"].ToString() == "" ? -1 : (int)dr["Attorney"];
                this.PayKind = dr["PayKind"].ToString();
                this.IReceiptDate = dr["IReceiptDate"].ToString() == "" ? DateTime.Parse("1900/1/1") : (DateTime)dr["IReceiptDate"];
                this.IReceiptNo = dr["IReceiptNo"].ToString();
                this.IMoney = dr["IMoney"].ToString();
                this.IServiceFee = dr["IServiceFee"].ToString() != "" ? (decimal)dr["IServiceFee"] : 0;
                this.GovFee = dr["GovFee"].ToString() != "" ? (decimal)dr["GovFee"] : 0;
                this.OtherFee = dr["OtherFee"].ToString() != "" ? (decimal)dr["OtherFee"] : 0;
                this.ExchangeRate = dr["ExchangeRate"].ToString() != "" ? (decimal)dr["ExchangeRate"] : 0;
                this.Totall = dr["Totall"].ToString() != "" ? (decimal)dr["Totall"] : 0;
                this.ActuallyPay = dr["ActuallyPay"].ToString() != "" ? (decimal)dr["ActuallyPay"] : 0;
                this.Remark = dr["Remark"].ToString();
                this.Memo = dr["Memo"].ToString();
                this.BillCheck = dr["BillCheck"].ToString();
                this.ReciveDate = dr["ReciveDate"].ToString() == "" ? DateTime.Parse("1900/1/1") : (DateTime)dr["ReciveDate"];
                this.PayDueDate = dr["PayDueDate"].ToString() == "" ? DateTime.Parse("1900/1/1") : (DateTime)dr["PayDueDate"];
                this.PaymentDate = dr["PaymentDate"].ToString() == "" ? DateTime.Parse("1900/1/1") : (DateTime)dr["PaymentDate"];
                this.EstimatedPaymentDate = dr["EstimatedPaymentDate"].ToString() == "" ? DateTime.Parse("1900/1/1") : (DateTime)dr["EstimatedPaymentDate"];
                this.SingCode = dr["SingCode"].ToString();
                this.IsBilling = dr["IsBilling"].ToString() == "" ? false : (bool)dr["IsBilling"];
                this.BillingNo = dr["BillingNo"].ToString();
                this.IsCopyFile = dr["IsCopyFile"].ToString() == "" ? false : (bool)dr["IsCopyFile"];
                this.IsScan = dr["IsScan"].ToString() == "" ? false : (bool)dr["IsScan"];
                this.IsClosing = dr["IsClosing"].ToString() == "" ? false : (bool)dr["IsClosing"];
                this.CloseDate = dr["CloseDate"].ToString() == "" ? DateTime.Parse("1900/1/1") : (DateTime)dr["CloseDate"];
                this.AcountingFirmKey = dr["AcountingFirmKey"].ToString() == "" ? -1 : (int)dr["AcountingFirmKey"];
                this.UpbuildDay = dr["UpbuildDay"].ToString() == "" ? DateTime.Parse("1900/1/1") : (DateTime)dr["UpbuildDay"];
                this.LastModifyDate = dr["LastModifyDate"].ToString() == "" ? DateTime.Parse("1900/1/1") : (DateTime)dr["LastModifyDate"];
                this.LastModifyWorker = dr["LastModifyWorker"].ToString() == "" ? -1 : (int)dr["LastModifyWorker"];
                this.Locker = dr["Locker"].ToString() == "" ? -1 : (int)dr["Locker"];
            }
            catch
            {
                throw (new System.Exception("TrademarkControversyPaymentT該筆資料有誤：" + NO.ToString()));
            }
        }
        public void Insert()
        {
            try
            {
                Object Rownull = System.DBNull.Value;
                DataRow dr = dt.NewRow();
                dr["TrademarkControversyID"] = this.TrademarkControversyID == -1 ? Rownull : this.TrademarkControversyID;
                dr["RDate"] = this.RDate.ToShortDateString() == "1900/1/1" ? Rownull : this.RDate;
                dr["FeeSubject"] = this.FeeSubject == "" ? Rownull : this.FeeSubject;
                dr["FeePhase"] = this.FeePhase == -1 ? Rownull : this.FeePhase;
                dr["FClientTransactor"] = this.FClientTransactor == -1 ? Rownull : this.FClientTransactor;
                dr["Attorney"] = this.Attorney == -1 ? Rownull : this.Attorney;
                dr["PayKind"] = this.PayKind == "" ? Rownull : this.PayKind;
                dr["IReceiptDate"] = this.IReceiptDate.ToShortDateString() == "1900/1/1" ? Rownull : this.IReceiptDate;
                dr["IReceiptNo"] = this.IReceiptNo == "" ? Rownull : this.IReceiptNo;
                dr["IMoney"] = this.IMoney == "" ? Rownull : this.IMoney;
                dr["IServiceFee"] = this.IServiceFee.ToString() != "" ? this.IServiceFee : 0;
                dr["GovFee"] = this.GovFee.ToString() != "" ? this.GovFee : 0;
                dr["OtherFee"] = this.OtherFee.ToString() != "" ? this.OtherFee : 0;
                dr["ExchangeRate"] = this.ExchangeRate.ToString() != "" ? this.ExchangeRate : 0;
                dr["Totall"] = this.Totall.ToString() != "" ? this.Totall : 0;
                dr["ActuallyPay"] = this.ActuallyPay.ToString() != "" ? this.ActuallyPay : 0;
                dr["Remark"] = this.Remark == "" ? Rownull : this.Remark;
                dr["Memo"] = this.Memo == "" ? Rownull : this.Memo;
                dr["BillCheck"] = this.BillCheck == "" ? Rownull : this.BillCheck;
                dr["ReciveDate"] = this.ReciveDate.ToShortDateString() == "1900/1/1" ? Rownull : this.ReciveDate;
                dr["PayDueDate"] = this.PayDueDate.ToShortDateString() == "1900/1/1" ? Rownull : this.PayDueDate;
                dr["PaymentDate"] = this.PaymentDate.ToShortDateString() == "1900/1/1" ? Rownull : this.PaymentDate;
                dr["EstimatedPaymentDate"] = this.EstimatedPaymentDate.ToShortDateString() == "1900/1/1" ? Rownull : this.EstimatedPaymentDate;
                dr["SingCode"] = this.SingCode == "" ? Rownull : this.SingCode;
                dr["IsBilling"] = this.IsBilling;
                dr["BillingNo"] = this.BillingNo == "" ? Rownull : this.BillingNo;
                dr["IsCopyFile"] = this.IsCopyFile;
                dr["IsScan"] = this.IsScan;
                dr["IsClosing"] = this.IsClosing;
                dr["CloseDate"] = this.CloseDate.ToShortDateString() == "1900/1/1" ? Rownull : this.CloseDate;
                dr["AcountingFirmKey"] = this.AcountingFirmKey == -1 ? Rownull : this.AcountingFirmKey;
                dr["UpbuildDay"] = this.UpbuildDay.ToShortDateString() == "1900/1/1" ? Rownull : this.UpbuildDay;
                dr["LastModifyDate"] = this.LastModifyDate.ToShortDateString() == "1900/1/1" ? Rownull : this.LastModifyDate;
                dr["LastModifyWorker"] = this.LastModifyWorker == -1 ? Rownull : this.LastModifyWorker;
                dr["Locker"] = this.Locker == -1 ? Rownull : this.Locker;
                sAdapter.InsertCommand.Parameters["@TrademarkControversyID"].Value = dr["TrademarkControversyID"];
                sAdapter.InsertCommand.Parameters["@RDate"].Value = dr["RDate"];
                sAdapter.InsertCommand.Parameters["@FeeSubject"].Value = dr["FeeSubject"];
                sAdapter.InsertCommand.Parameters["@FeePhase"].Value = dr["FeePhase"];
                sAdapter.InsertCommand.Parameters["@FClientTransactor"].Value = dr["FClientTransactor"];
                sAdapter.InsertCommand.Parameters["@Attorney"].Value = dr["Attorney"];
                sAdapter.InsertCommand.Parameters["@PayKind"].Value = dr["PayKind"];
                sAdapter.InsertCommand.Parameters["@IReceiptDate"].Value = dr["IReceiptDate"];
                sAdapter.InsertCommand.Parameters["@IReceiptNo"].Value = dr["IReceiptNo"];
                sAdapter.InsertCommand.Parameters["@IMoney"].Value = dr["IMoney"];
                sAdapter.InsertCommand.Parameters["@IServiceFee"].Value = dr["IServiceFee"];
                sAdapter.InsertCommand.Parameters["@GovFee"].Value = dr["GovFee"];
                sAdapter.InsertCommand.Parameters["@OtherFee"].Value = dr["OtherFee"];
                sAdapter.InsertCommand.Parameters["@ExchangeRate"].Value = dr["ExchangeRate"];
                sAdapter.InsertCommand.Parameters["@Totall"].Value = dr["Totall"];
                sAdapter.InsertCommand.Parameters["@ActuallyPay"].Value = dr["ActuallyPay"];
                sAdapter.InsertCommand.Parameters["@Remark"].Value = dr["Remark"];
                sAdapter.InsertCommand.Parameters["@Memo"].Value = dr["Memo"];
                sAdapter.InsertCommand.Parameters["@BillCheck"].Value = dr["BillCheck"];
                sAdapter.InsertCommand.Parameters["@ReciveDate"].Value = dr["ReciveDate"];
                sAdapter.InsertCommand.Parameters["@PayDueDate"].Value = dr["PayDueDate"];
                sAdapter.InsertCommand.Parameters["@PaymentDate"].Value = dr["PaymentDate"];
                sAdapter.InsertCommand.Parameters["@EstimatedPaymentDate"].Value = dr["EstimatedPaymentDate"];
                sAdapter.InsertCommand.Parameters["@SingCode"].Value = dr["SingCode"];
                sAdapter.InsertCommand.Parameters["@IsBilling"].Value = dr["IsBilling"];
                sAdapter.InsertCommand.Parameters["@BillingNo"].Value = dr["BillingNo"];
                sAdapter.InsertCommand.Parameters["@IsCopyFile"].Value = dr["IsCopyFile"];
                sAdapter.InsertCommand.Parameters["@IsScan"].Value = dr["IsScan"];
                sAdapter.InsertCommand.Parameters["@IsClosing"].Value = dr["IsClosing"];
                sAdapter.InsertCommand.Parameters["@CloseDate"].Value = dr["CloseDate"];
                sAdapter.InsertCommand.Parameters["@AcountingFirmKey"].Value = dr["AcountingFirmKey"];
                sAdapter.InsertCommand.Parameters["@UpbuildDay"].Value = dr["UpbuildDay"];
                sAdapter.InsertCommand.Parameters["@LastModifyDate"].Value = dr["LastModifyDate"];
                sAdapter.InsertCommand.Parameters["@LastModifyWorker"].Value = dr["LastModifyWorker"];
                sAdapter.InsertCommand.Parameters["@Locker"].Value = dr["Locker"];
                conn.Open();
                string KEY = sAdapter.InsertCommand.ExecuteScalar().ToString();
                conn.Close();
                if (KEY != "")
                {
                    this.ControversyPaymentID = int.Parse(KEY);
                    dr["ControversyPaymentID"] = this.ControversyPaymentID;
                }
                dt.Rows.Add(dr);
                dt.AcceptChanges();
            }
            catch (System.Exception EX)
            {
                System.Windows.Forms.MessageBox.Show(EX.Message.Replace("'", ""));
            }
        }
        public void Updata(int No)
        {
            try
            {
                Object Rownull = System.DBNull.Value;
                DataRow dr = dt.Rows.Find(No);
                dr["TrademarkControversyID"] = this.TrademarkControversyID == -1 ? Rownull : this.TrademarkControversyID;
                dr["RDate"] = this.RDate.ToShortDateString() == "1900/1/1" ? Rownull : this.RDate;
                dr["FeeSubject"] = this.FeeSubject == "" ? Rownull : this.FeeSubject;
                dr["FeePhase"] = this.FeePhase == -1 ? Rownull : this.FeePhase;
                dr["FClientTransactor"] = this.FClientTransactor == -1 ? Rownull : this.FClientTransactor;
                dr["Attorney"] = this.Attorney == -1 ? Rownull : this.Attorney;
                dr["PayKind"] = this.PayKind == "" ? Rownull : this.PayKind;
                dr["IReceiptDate"] = this.IReceiptDate.ToShortDateString() == "1900/1/1" ? Rownull : this.IReceiptDate;
                dr["IReceiptNo"] = this.IReceiptNo == "" ? Rownull : this.IReceiptNo;
                dr["IMoney"] = this.IMoney == "" ? Rownull : this.IMoney;
                dr["IServiceFee"] = this.IServiceFee.ToString() != "" ? this.IServiceFee : 0;
                dr["GovFee"] = this.GovFee.ToString() != "" ? this.GovFee : 0;
                dr["OtherFee"] = this.OtherFee.ToString() != "" ? this.OtherFee : 0;
                dr["ExchangeRate"] = this.ExchangeRate.ToString() != "" ? this.ExchangeRate : 0;
                dr["Totall"] = this.Totall.ToString() != "" ? this.Totall : 0;
                dr["ActuallyPay"] = this.ActuallyPay.ToString() != "" ? this.ActuallyPay : 0;
                dr["Remark"] = this.Remark == "" ? Rownull : this.Remark;
                dr["Memo"] = this.Memo == "" ? Rownull : this.Memo;
                dr["BillCheck"] = this.BillCheck == "" ? Rownull : this.BillCheck;
                dr["ReciveDate"] = this.ReciveDate.ToShortDateString() == "1900/1/1" ? Rownull : this.ReciveDate;
                dr["PayDueDate"] = this.PayDueDate.ToShortDateString() == "1900/1/1" ? Rownull : this.PayDueDate;
                dr["PaymentDate"] = this.PaymentDate.ToShortDateString() == "1900/1/1" ? Rownull : this.PaymentDate;
                dr["EstimatedPaymentDate"] = this.EstimatedPaymentDate.ToShortDateString() == "1900/1/1" ? Rownull : this.EstimatedPaymentDate;
                dr["SingCode"] = this.SingCode == "" ? Rownull : this.SingCode;
                dr["IsBilling"] = this.IsBilling;
                dr["BillingNo"] = this.BillingNo == "" ? Rownull : this.BillingNo;
                dr["IsCopyFile"] = this.IsCopyFile;
                dr["IsScan"] = this.IsScan;
                dr["IsClosing"] = this.IsClosing;
                dr["CloseDate"] = this.CloseDate.ToShortDateString() == "1900/1/1" ? Rownull : this.CloseDate;
                dr["AcountingFirmKey"] = this.AcountingFirmKey == -1 ? Rownull : this.AcountingFirmKey;
                dr["UpbuildDay"] = this.UpbuildDay.ToShortDateString() == "1900/1/1" ? Rownull : this.UpbuildDay;
                dr["LastModifyDate"] = this.LastModifyDate.ToShortDateString() == "1900/1/1" ? Rownull : this.LastModifyDate;
                dr["LastModifyWorker"] = this.LastModifyWorker == -1 ? Rownull : this.LastModifyWorker;
                dr["Locker"] = this.Locker == -1 ? Rownull : this.Locker;
                sAdapter.UpdateCommand.Parameters.Clear();
                sAdapter.UpdateCommand.Parameters.Add("ControversyPaymentID", SqlDbType.Int);
                sAdapter.UpdateCommand.Parameters["ControversyPaymentID"].Value = dr["ControversyPaymentID"];
                sAdapter.UpdateCommand.Parameters.Add("TrademarkControversyID", SqlDbType.Int);
                sAdapter.UpdateCommand.Parameters["TrademarkControversyID"].Value = dr["TrademarkControversyID"];
                sAdapter.UpdateCommand.Parameters.Add("RDate", SqlDbType.DateTime);
                sAdapter.UpdateCommand.Parameters["RDate"].Value = dr["RDate"];
                sAdapter.UpdateCommand.Parameters.Add("FeeSubject", SqlDbType.NVarChar);
                sAdapter.UpdateCommand.Parameters["FeeSubject"].Value = dr["FeeSubject"];
                sAdapter.UpdateCommand.Parameters.Add("FeePhase", SqlDbType.Int);
                sAdapter.UpdateCommand.Parameters["FeePhase"].Value = dr["FeePhase"];
                sAdapter.UpdateCommand.Parameters.Add("FClientTransactor", SqlDbType.Int);
                sAdapter.UpdateCommand.Parameters["FClientTransactor"].Value = dr["FClientTransactor"];
                sAdapter.UpdateCommand.Parameters.Add("Attorney", SqlDbType.Int);
                sAdapter.UpdateCommand.Parameters["Attorney"].Value = dr["Attorney"];
                sAdapter.UpdateCommand.Parameters.Add("PayKind", SqlDbType.NVarChar);
                sAdapter.UpdateCommand.Parameters["PayKind"].Value = dr["PayKind"];
                sAdapter.UpdateCommand.Parameters.Add("IReceiptDate", SqlDbType.DateTime);
                sAdapter.UpdateCommand.Parameters["IReceiptDate"].Value = dr["IReceiptDate"];
                sAdapter.UpdateCommand.Parameters.Add("IReceiptNo", SqlDbType.NVarChar);
                sAdapter.UpdateCommand.Parameters["IReceiptNo"].Value = dr["IReceiptNo"];
                sAdapter.UpdateCommand.Parameters.Add("IMoney", SqlDbType.NVarChar);
                sAdapter.UpdateCommand.Parameters["IMoney"].Value = dr["IMoney"];
                sAdapter.UpdateCommand.Parameters.Add("IServiceFee", SqlDbType.Decimal);
                sAdapter.UpdateCommand.Parameters["IServiceFee"].Value = dr["IServiceFee"];
                sAdapter.UpdateCommand.Parameters.Add("GovFee", SqlDbType.Decimal);
                sAdapter.UpdateCommand.Parameters["GovFee"].Value = dr["GovFee"];
                sAdapter.UpdateCommand.Parameters.Add("OtherFee", SqlDbType.Decimal);
                sAdapter.UpdateCommand.Parameters["OtherFee"].Value = dr["OtherFee"];
                sAdapter.UpdateCommand.Parameters.Add("ExchangeRate", SqlDbType.Decimal);
                sAdapter.UpdateCommand.Parameters["ExchangeRate"].Value = dr["ExchangeRate"];
                sAdapter.UpdateCommand.Parameters.Add("Totall", SqlDbType.Decimal);
                sAdapter.UpdateCommand.Parameters["Totall"].Value = dr["Totall"];
                sAdapter.UpdateCommand.Parameters.Add("ActuallyPay", SqlDbType.Decimal);
                sAdapter.UpdateCommand.Parameters["ActuallyPay"].Value = dr["ActuallyPay"];
                sAdapter.UpdateCommand.Parameters.Add("Remark", SqlDbType.NVarChar);
                sAdapter.UpdateCommand.Parameters["Remark"].Value = dr["Remark"];
                sAdapter.UpdateCommand.Parameters.Add("Memo", SqlDbType.NVarChar);
                sAdapter.UpdateCommand.Parameters["Memo"].Value = dr["Memo"];
                sAdapter.UpdateCommand.Parameters.Add("BillCheck", SqlDbType.NVarChar);
                sAdapter.UpdateCommand.Parameters["BillCheck"].Value = dr["BillCheck"];
                sAdapter.UpdateCommand.Parameters.Add("ReciveDate", SqlDbType.DateTime);
                sAdapter.UpdateCommand.Parameters["ReciveDate"].Value = dr["ReciveDate"];
                sAdapter.UpdateCommand.Parameters.Add("PayDueDate", SqlDbType.DateTime);
                sAdapter.UpdateCommand.Parameters["PayDueDate"].Value = dr["PayDueDate"];
                sAdapter.UpdateCommand.Parameters.Add("PaymentDate", SqlDbType.DateTime);
                sAdapter.UpdateCommand.Parameters["PaymentDate"].Value = dr["PaymentDate"];
                sAdapter.UpdateCommand.Parameters.Add("EstimatedPaymentDate", SqlDbType.DateTime);
                sAdapter.UpdateCommand.Parameters["EstimatedPaymentDate"].Value = dr["EstimatedPaymentDate"];
                sAdapter.UpdateCommand.Parameters.Add("SingCode", SqlDbType.NVarChar);
                sAdapter.UpdateCommand.Parameters["SingCode"].Value = dr["SingCode"];
                sAdapter.UpdateCommand.Parameters.Add("IsBilling", SqlDbType.Bit);
                sAdapter.UpdateCommand.Parameters["IsBilling"].Value = dr["IsBilling"];
                sAdapter.UpdateCommand.Parameters.Add("BillingNo", SqlDbType.NVarChar);
                sAdapter.UpdateCommand.Parameters["BillingNo"].Value = dr["BillingNo"];
                sAdapter.UpdateCommand.Parameters.Add("IsCopyFile", SqlDbType.Bit);
                sAdapter.UpdateCommand.Parameters["IsCopyFile"].Value = dr["IsCopyFile"];
                sAdapter.UpdateCommand.Parameters.Add("IsScan", SqlDbType.Bit);
                sAdapter.UpdateCommand.Parameters["IsScan"].Value = dr["IsScan"];
                sAdapter.UpdateCommand.Parameters.Add("IsClosing", SqlDbType.Bit);
                sAdapter.UpdateCommand.Parameters["IsClosing"].Value = dr["IsClosing"];
                sAdapter.UpdateCommand.Parameters.Add("CloseDate", SqlDbType.DateTime);
                sAdapter.UpdateCommand.Parameters["CloseDate"].Value = dr["CloseDate"];
                sAdapter.UpdateCommand.Parameters.Add("AcountingFirmKey", SqlDbType.Int);
                sAdapter.UpdateCommand.Parameters["AcountingFirmKey"].Value = dr["AcountingFirmKey"];
                sAdapter.UpdateCommand.Parameters.Add("UpbuildDay", SqlDbType.DateTime);
                sAdapter.UpdateCommand.Parameters["UpbuildDay"].Value = dr["UpbuildDay"];
                sAdapter.UpdateCommand.Parameters.Add("LastModifyDate", SqlDbType.DateTime);
                sAdapter.UpdateCommand.Parameters["LastModifyDate"].Value = dr["LastModifyDate"];
                sAdapter.UpdateCommand.Parameters.Add("LastModifyWorker", SqlDbType.Int);
                sAdapter.UpdateCommand.Parameters["LastModifyWorker"].Value = dr["LastModifyWorker"];
                sAdapter.UpdateCommand.Parameters.Add("Locker", SqlDbType.Int);
                sAdapter.UpdateCommand.Parameters["Locker"].Value = dr["Locker"];

                sAdapter.UpdateCommand.Connection.Open();
                sAdapter.UpdateCommand.ExecuteNonQuery();
                sAdapter.UpdateCommand.Connection.Close();
                dt.AcceptChanges();
            }
            catch (System.Exception EX)
            {
                System.Windows.Forms.MessageBox.Show(EX.Message.Replace("'", ""));
            }
        }
        /// <summary>
        /// 刪除--依條件式刪除資料
        /// </summary>
        /// <param name="strSQLWhere"></param>
        public void Delete(string strSQLWhere)
        {
            try
            {
                StringBuilder delString = new StringBuilder("DELETE FROM TrademarkControversyPaymentT where " + strSQLWhere);
                sAdapter.DeleteCommand = new SqlCommand(delString.ToString(), conn);

                conn.Open();
                sAdapter.DeleteCommand.ExecuteNonQuery();
                conn.Close();

            }
            catch (System.Exception EX)
            {
                System.Windows.Forms.MessageBox.Show(EX.Message.Replace("'", ""));
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }


        /// <summary>
        ///  刪除--依PrimaryKey刪除資料
        /// </summary>
        /// <param name="PrimaryKey"></param>
        public void Delete(int PrimaryKey)
        {
            try
            {
                StringBuilder delString = new StringBuilder("DELETE FROM TrademarkControversyPaymentT where ControversyPaymentID=@ControversyPaymentID ");
                sAdapter.DeleteCommand = new SqlCommand(delString.ToString(), conn);
                for (int i = 0; i < dt.PrimaryKey.Length; i++)
                {
                    switch (dt.PrimaryKey[i].DataType.Name)
                    {
                        case "Int32":
                            sAdapter.DeleteCommand.Parameters.Add(dt.PrimaryKey[i].ToString(), SqlDbType.Int);
                            sAdapter.DeleteCommand.Parameters[dt.PrimaryKey[i].ToString()].Value = PrimaryKey;
                            break;
                        case "Int64":
                            sAdapter.DeleteCommand.Parameters.Add(dt.PrimaryKey[i].ToString(), SqlDbType.BigInt);
                            sAdapter.DeleteCommand.Parameters[dt.PrimaryKey[i].ToString()].Value = PrimaryKey;
                            break;
                    }
                }
                conn.Open();
                sAdapter.DeleteCommand.ExecuteNonQuery();
                conn.Close();

            }
            catch (System.Exception EX)
            {
                System.Windows.Forms.MessageBox.Show(EX.Message.Replace("'", ""));
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
        }


        /// <summary>
        /// 將刪除資料回溯用的Insert 語法
        /// </summary>
        /// <param name='iNo'>Key值</param>
        /// <returns>[0]Columns , [1]Parameters , [2]TableName</returns>
        public string[] GetInsertString(int iNo)
        {
            DataRow dr = dt.Rows.Find(iNo);
            StringBuilder sbInsert = new StringBuilder();
            StringBuilder sbInsertColumns = new StringBuilder();

            for (int iCol = 0; iCol < dt.Columns.Count; iCol++)
            {
                string Column = dt.Columns[iCol].ColumnName;
                string PKColumn = dt.PrimaryKey[0].ColumnName;

                if (dr[Column] != DBNull.Value && Column != PKColumn)
                {
                    if (sbInsert.ToString().Length > 0)
                    {
                        sbInsert.Append(",");
                        sbInsertColumns.Append(",");
                    }


                    if (dt.Columns[iCol].DataType.Name == "Int32" || dt.Columns[iCol].DataType.Name == "Int64" || dt.Columns[iCol].DataType.Name == "Decimal")
                    {
                        sbInsert.Append(string.Format("{0}", dr[Column].ToString()));
                    }
                    else if (dt.Columns[iCol].DataType.Name == "DateTime")
                    {
                        sbInsert.Append(string.Format("'{0}'", ((DateTime)dr[Column]).ToString("yyyy/MM/dd HH:mm")));
                    }
                    else if (dt.Columns[iCol].DataType.Name == "Boolean")
                    {
                        sbInsert.Append(string.Format("{0}", ((bool)dr[Column]) == true ? 1 : 0));
                    }
                    else
                    {
                        sbInsert.Append(string.Format("N'{0}'", dr[Column].ToString().Replace("'", "''")));
                    }

                    sbInsertColumns.Append(Column);
                }
            }

            string[] Result = { sbInsertColumns.ToString(), sbInsert.ToString(), dt.TableName };
            return Result;
        }


    }
    #endregion
}
