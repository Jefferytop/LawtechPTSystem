using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using H3Operator.DBHelper;

namespace LawtechPTSystemByFirm.Public
{
    #region ======CTrademarkControversyFee======
    public class CTrademarkControversyFee
    {
        SqlConnection conn = new SqlConnection(DBAccess.ConnectionListDefaultConnectionString);
        SqlDataAdapter sAdapter;
        SqlCommandBuilder CBuilder;

        DataTable dt;
        /// <summary>
        /// 預設帶出所有的資料
        /// </summary>
        public CTrademarkControversyFee()
        {
            sAdapter = new SqlDataAdapter("select * from TrademarkControversyFeeT", conn);
            dt = new DataTable();
            //DataSet ds = new DataSet();
            //ds.Tables.Add(dt);
            sAdapter.FillSchema(dt, SchemaType.Source);
            sAdapter.Fill(dt);
            CBuilder = new SqlCommandBuilder(sAdapter);
            sAdapter.InsertCommand = CBuilder.GetInsertCommand(true);
            sAdapter.InsertCommand.UpdatedRowSource = UpdateRowSource.Both;
            sAdapter.InsertCommand.CommandText += " Select @@IDENTITY AS 'IDENTITY'";
            sAdapter.UpdateCommand = new SqlCommand(@"UPDATE TrademarkControversyFeeT  SET 
                                                       TrademarkControversyID=@TrademarkControversyID,
                                                       RDate=@RDate,
                                                       FeeSubject=@FeeSubject,
                                                       FeePhase=@FeePhase,
                                                       Attorney=@Attorney,
                                                       FClientTransactor=@FClientTransactor,
                                                       IReceiptDate=@IReceiptDate,
                                                       IReceiptNo=@IReceiptNo,
                                                       aBillDate=@aBillDate,
                                                       aBill=@aBill,
                                                       IAttorneyFee=@IAttorneyFee,
                                                       IMoney=@IMoney,
                                                       ItoNT=@ItoNT,
                                                       ITotall=@ITotall,
                                                       ReceiptDate=@ReceiptDate,
                                                       OReceiptDate=@OReceiptDate,
                                                       OReceiptNo=@OReceiptNo,
                                                       OAttorneyFee=@OAttorneyFee,
                                                       OMoney=@OMoney,
                                                       OtoNT=@OtoNT,
                                                       OTotall=@OTotall,
                                                       OthFee=@OthFee,
                                                       OthTotal=@OthTotal,
                                                       GReceiptDate=@GReceiptDate,
                                                       GReceiptNo=@GReceiptNo,
                                                       GovFee=@GovFee,
                                                       GMoney=@GMoney,
                                                       GtoNT=@GtoNT,
                                                       GTotall=@GTotall,
                                                       OAttorneyGovFee=@OAttorneyGovFee,
                                                       Totall=@Totall,
                                                       TMoney=@TMoney,
                                                       TtoNT=@TtoNT,
                                                       TotalNT=@TotalNT,
                                                       OtherTotalFee=@OtherTotalFee,
                                                       Pay=@Pay,
                                                       PayDate=@PayDate,
                                                       PPP=@PPP,
                                                       Withholding=@Withholding,
                                                       Tax=@Tax,
                                                       PracticalityPay=@PracticalityPay,
                                                       NT=@NT,
                                                       PayKind=@PayKind,
                                                       Remark=@Remark,
                                                       PayType=@PayType,
                                                       PayMemo=@PayMemo,
                                                       SingCode=@SingCode,
                                                       Days=@Days,
                                                       IsClosing=@IsClosing,
                                                       CloseDate=@CloseDate,
                                                       UpbuildDay=@UpbuildDay,
                                                       LastModifyDate=@LastModifyDate,
                                                       LastModifyWorker=@LastModifyWorker,
                                                       Locker=@Locker
                                                   where 
                                                       ControversyFeeKEY=@ControversyFeeKEY", conn);
        }
        /// <summary>
        /// 有條件的過濾資料
        /// </summary>
        /// <param name="sWhere">SQL的條件式</param>
        public CTrademarkControversyFee(string sWhere)
        {
            sAdapter = new SqlDataAdapter("select * from TrademarkControversyFeeT where " + sWhere, conn);
            dt = new DataTable();
            //DataSet ds = new DataSet();
            //ds.Tables.Add(dt);
            sAdapter.FillSchema(dt, SchemaType.Source);
            sAdapter.Fill(dt);
            CBuilder = new SqlCommandBuilder(sAdapter);
            sAdapter.InsertCommand = CBuilder.GetInsertCommand(true);
            sAdapter.InsertCommand.UpdatedRowSource = UpdateRowSource.Both;
            sAdapter.InsertCommand.CommandText += " Select @@IDENTITY AS 'IDENTITY'";
            sAdapter.UpdateCommand = new SqlCommand(@"UPDATE TrademarkControversyFeeT  SET 
                                                       TrademarkControversyID=@TrademarkControversyID,
                                                       RDate=@RDate,
                                                       FeeSubject=@FeeSubject,
                                                       FeePhase=@FeePhase,
                                                       Attorney=@Attorney,
                                                       FClientTransactor=@FClientTransactor,
                                                       IReceiptDate=@IReceiptDate,
                                                       IReceiptNo=@IReceiptNo,
                                                       aBillDate=@aBillDate,
                                                       aBill=@aBill,
                                                       IAttorneyFee=@IAttorneyFee,
                                                       IMoney=@IMoney,
                                                       ItoNT=@ItoNT,
                                                       ITotall=@ITotall,
                                                       ReceiptDate=@ReceiptDate,
                                                       OReceiptDate=@OReceiptDate,
                                                       OReceiptNo=@OReceiptNo,
                                                       OAttorneyFee=@OAttorneyFee,
                                                       OMoney=@OMoney,
                                                       OtoNT=@OtoNT,
                                                       OTotall=@OTotall,
                                                       OthFee=@OthFee,
                                                       OthTotal=@OthTotal,
                                                       GReceiptDate=@GReceiptDate,
                                                       GReceiptNo=@GReceiptNo,
                                                       GovFee=@GovFee,
                                                       GMoney=@GMoney,
                                                       GtoNT=@GtoNT,
                                                       GTotall=@GTotall,
                                                       OAttorneyGovFee=@OAttorneyGovFee,
                                                       Totall=@Totall,
                                                       TMoney=@TMoney,
                                                       TtoNT=@TtoNT,
                                                       TotalNT=@TotalNT,
                                                       OtherTotalFee=@OtherTotalFee,
                                                       Pay=@Pay,
                                                       PayDate=@PayDate,
                                                       PPP=@PPP,
                                                       Withholding=@Withholding,
                                                       Tax=@Tax,
                                                       PracticalityPay=@PracticalityPay,
                                                       NT=@NT,
                                                       PayKind=@PayKind,
                                                       Remark=@Remark,
                                                       PayType=@PayType,
                                                       PayMemo=@PayMemo,
                                                       SingCode=@SingCode,
                                                       Days=@Days,
                                                       IsClosing=@IsClosing,
                                                       CloseDate=@CloseDate,
                                                       UpbuildDay=@UpbuildDay,
                                                       LastModifyDate=@LastModifyDate,
                                                       LastModifyWorker=@LastModifyWorker,
                                                       Locker=@Locker
                                                   where 
                                                       ControversyFeeKEY=@ControversyFeeKEY", conn);
        }


        private int _ControversyFeeKEY = -1;
        /// <summary>  
        /// 
        /// </summary>  
        public int ControversyFeeKEY
        {
            get
            {
                return _ControversyFeeKEY;
            }
            set
            {
                _ControversyFeeKEY = value;
            }
        }
        private int _TrademarkControversyID = -1;
        /// <summary>  
        /// 
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
        private int _Attorney = -1;
        /// <summary>  
        /// 受款人
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
        private DateTime _IReceiptDate = DateTime.Parse("1900/1/1");
        /// <summary>  
        /// 本事務所費用-收據日期
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
        /// 本事務所費用-收據編號
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
        private DateTime _aBillDate = DateTime.Parse("1900/1/1");
        /// <summary>  
        /// 本事務所費用-發票日期
        /// </summary>  
        public DateTime aBillDate
        {
            get
            {
                return _aBillDate;
            }
            set
            {
                _aBillDate = value;
            }
        }
        private string _aBill = "";
        /// <summary>  
        /// 本事務所費用-發票編號
        /// </summary>  
        public String aBill
        {
            get
            {
                return _aBill;
            }
            set
            {
                _aBill = value;
            }
        }
        private decimal _IAttorneyFee = 0;
        /// <summary>  
        /// 本事務所費用
        /// </summary>  
        public decimal IAttorneyFee
        {
            get
            {
                return _IAttorneyFee;
            }
            set
            {
                _IAttorneyFee = value;
            }
        }
        private string _IMoney = "";
        /// <summary>  
        /// 本事務所費用-幣別
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
        private decimal _ItoNT = 0;
        /// <summary>  
        /// 本事務所費用-?NT
        /// </summary>  
        public decimal ItoNT
        {
            get
            {
                return _ItoNT;
            }
            set
            {
                _ItoNT = value;
            }
        }
        private decimal _ITotall = 0;
        /// <summary>  
        /// 本事務所費用-合計NT
        /// </summary>  
        public decimal ITotall
        {
            get
            {
                return _ITotall;
            }
            set
            {
                _ITotall = value;
            }
        }
        private DateTime _ReceiptDate = DateTime.Parse("1900/1/1");
        /// <summary>  
        /// 收據日期
        /// </summary>  
        public DateTime ReceiptDate
        {
            get
            {
                return _ReceiptDate;
            }
            set
            {
                _ReceiptDate = value;
            }
        }
        private DateTime _OReceiptDate = DateTime.Parse("1900/1/1");
        /// <summary>  
        /// 國外事務所費用-收據日期
        /// </summary>  
        public DateTime OReceiptDate
        {
            get
            {
                return _OReceiptDate;
            }
            set
            {
                _OReceiptDate = value;
            }
        }
        private string _OReceiptNo = "";
        /// <summary>  
        /// 國外事務所費用-收據編號
        /// </summary>  
        public String OReceiptNo
        {
            get
            {
                return _OReceiptNo;
            }
            set
            {
                _OReceiptNo = value;
            }
        }
        private decimal _OAttorneyFee = 0;
        /// <summary>  
        /// 國外事務所費用
        /// </summary>  
        public decimal OAttorneyFee
        {
            get
            {
                return _OAttorneyFee;
            }
            set
            {
                _OAttorneyFee = value;
            }
        }
        private string _OMoney = "";
        /// <summary>  
        /// 國外事務所費用-幣別
        /// </summary>  
        public String OMoney
        {
            get
            {
                return _OMoney;
            }
            set
            {
                _OMoney = value;
            }
        }
        private decimal _OtoNT = 0;
        /// <summary>  
        /// 國外事務所費用-?NT
        /// </summary>  
        public decimal OtoNT
        {
            get
            {
                return _OtoNT;
            }
            set
            {
                _OtoNT = value;
            }
        }
        private decimal _OTotall = 0;
        /// <summary>  
        /// 國外事務所費用-合計NT
        /// </summary>  
        public decimal OTotall
        {
            get
            {
                return _OTotall;
            }
            set
            {
                _OTotall = value;
            }
        }
        private decimal _OthFee = 0;
        /// <summary>  
        /// 
        /// </summary>  
        public decimal OthFee
        {
            get
            {
                return _OthFee;
            }
            set
            {
                _OthFee = value;
            }
        }
        private decimal _OthTotal = 0;
        /// <summary>  
        /// 
        /// </summary>  
        public decimal OthTotal
        {
            get
            {
                return _OthTotal;
            }
            set
            {
                _OthTotal = value;
            }
        }
        private DateTime _GReceiptDate = DateTime.Parse("1900/1/1");
        /// <summary>  
        /// 官方規費-收據日期
        /// </summary>  
        public DateTime GReceiptDate
        {
            get
            {
                return _GReceiptDate;
            }
            set
            {
                _GReceiptDate = value;
            }
        }
        private string _GReceiptNo = "";
        /// <summary>  
        /// 官方規費-收據號碼
        /// </summary>  
        public String GReceiptNo
        {
            get
            {
                return _GReceiptNo;
            }
            set
            {
                _GReceiptNo = value;
            }
        }
        private decimal _GovFee = 0;
        /// <summary>  
        /// 官方規費
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
        private string _GMoney = "";
        /// <summary>  
        /// 官方規費-幣別
        /// </summary>  
        public String GMoney
        {
            get
            {
                return _GMoney;
            }
            set
            {
                _GMoney = value;
            }
        }
        private decimal _GtoNT = 0;
        /// <summary>  
        /// 官方規費-兌NT
        /// </summary>  
        public decimal GtoNT
        {
            get
            {
                return _GtoNT;
            }
            set
            {
                _GtoNT = value;
            }
        }
        private decimal _GTotall = 0;
        /// <summary>  
        /// 官方規費-合計NT
        /// </summary>  
        public decimal GTotall
        {
            get
            {
                return _GTotall;
            }
            set
            {
                _GTotall = value;
            }
        }
        private decimal _OAttorneyGovFee = 0;
        /// <summary>  
        /// 代收代付合計NT
        /// </summary>  
        public decimal OAttorneyGovFee
        {
            get
            {
                return _OAttorneyGovFee;
            }
            set
            {
                _OAttorneyGovFee = value;
            }
        }
        private decimal _Totall = 0;
        /// <summary>  
        /// 請款合計
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
        private string _TMoney = "";
        /// <summary>  
        /// 請款合計 幣別
        /// </summary>  
        public String TMoney
        {
            get
            {
                return _TMoney;
            }
            set
            {
                _TMoney = value;
            }
        }
        private decimal _TtoNT = 0;
        /// <summary>  
        /// 請款合計-匯率
        /// </summary>  
        public decimal TtoNT
        {
            get
            {
                return _TtoNT;
            }
            set
            {
                _TtoNT = value;
            }
        }
        private decimal _TotalNT = 0;
        /// <summary>  
        /// 請款合計 兌換成NT
        /// </summary>  
        public decimal TotalNT
        {
            get
            {
                return _TotalNT;
            }
            set
            {
                _TotalNT = value;
            }
        }
        private decimal _OtherTotalFee = 0;
        /// <summary>  
        /// 
        /// </summary>  
        public decimal OtherTotalFee
        {
            get
            {
                return _OtherTotalFee;
            }
            set
            {
                _OtherTotalFee = value;
            }
        }
        private bool _Pay = false;
        /// <summary>  
        /// 已請款
        /// </summary>  
        public bool Pay
        {
            get
            {
                return _Pay;
            }
            set
            {
                _Pay = value;
            }
        }
        private DateTime _PayDate = DateTime.Parse("1900/1/1");
        /// <summary>  
        /// 收款日期
        /// </summary>  
        public DateTime PayDate
        {
            get
            {
                return _PayDate;
            }
            set
            {
                _PayDate = value;
            }
        }
        private string _PPP = "";
        /// <summary>  
        /// 請款單號
        /// </summary>  
        public String PPP
        {
            get
            {
                return _PPP;
            }
            set
            {
                _PPP = value;
            }
        }
        private bool _Withholding = false;
        /// <summary>  
        /// 已預扣
        /// </summary>  
        public bool Withholding
        {
            get
            {
                return _Withholding;
            }
            set
            {
                _Withholding = value;
            }
        }
        private decimal _Tax = 0;
        /// <summary>  
        /// 預扣稅額
        /// </summary>  
        public decimal Tax
        {
            get
            {
                return _Tax;
            }
            set
            {
                _Tax = value;
            }
        }
        private decimal _PracticalityPay = 0;
        /// <summary>  
        /// 實際請款
        /// </summary>  
        public decimal PracticalityPay
        {
            get
            {
                return _PracticalityPay;
            }
            set
            {
                _PracticalityPay = value;
            }
        }
        private bool _NT = false;
        /// <summary>  
        /// 外幣支付
        /// </summary>  
        public bool NT
        {
            get
            {
                return _NT;
            }
            set
            {
                _NT = value;
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
        private int _PayType = -1;
        /// <summary>  
        /// 
        /// </summary>  
        public int PayType
        {
            get
            {
                return _PayType;
            }
            set
            {
                _PayType = value;
            }
        }
        private string _PayMemo = "";
        /// <summary>  
        /// 請款處理說明
        /// </summary>  
        public String PayMemo
        {
            get
            {
                return _PayMemo;
            }
            set
            {
                _PayMemo = value;
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
        private int _Days = -1;
        /// <summary>  
        /// 付款方式--天
        /// </summary>  
        public int Days
        {
            get
            {
                return _Days;
            }
            set
            {
                _Days = value;
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
        private DateTime _UpbuildDay = DateTime.Parse("1900/1/1");
        /// <summary>  
        /// 建立時間
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
        /// 最後一次修改日期
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
        /// 最後修改者
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
        /// 取得TrademarkControversyFeeT資料集
        /// </summary>
        public DataTable GetDataTable()
        {
            return dt;
        }

        /// <summary>
        /// 設定TrademarkControversyFeeT資料集
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
            string strSQL = "select count(" + ColumnName + ") as CountValue from TrademarkControversyFeeT where " + ColumnName + "='" + Value + "'";
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
            string strSQL = "select count(" + ColumnName + ") as CountValue from TrademarkControversyFeeT where " + ColumnName + "=" + Value;
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
                this.ControversyFeeKEY = dr["ControversyFeeKEY"].ToString() == "" ? -1 : (int)dr["ControversyFeeKEY"];
                this.TrademarkControversyID = dr["TrademarkControversyID"].ToString() == "" ? -1 : (int)dr["TrademarkControversyID"];
                this.RDate = dr["RDate"].ToString() == "" ? DateTime.Parse("1900/1/1") : (DateTime)dr["RDate"];
                this.FeeSubject = dr["FeeSubject"].ToString();
                this.FeePhase = dr["FeePhase"].ToString() == "" ? -1 : (int)dr["FeePhase"];
                this.Attorney = dr["Attorney"].ToString() == "" ? -1 : (int)dr["Attorney"];
                this.FClientTransactor = dr["FClientTransactor"].ToString() == "" ? -1 : (int)dr["FClientTransactor"];
                this.IReceiptDate = dr["IReceiptDate"].ToString() == "" ? DateTime.Parse("1900/1/1") : (DateTime)dr["IReceiptDate"];
                this.IReceiptNo = dr["IReceiptNo"].ToString();
                this.aBillDate = dr["aBillDate"].ToString() == "" ? DateTime.Parse("1900/1/1") : (DateTime)dr["aBillDate"];
                this.aBill = dr["aBill"].ToString();
                this.IAttorneyFee = dr["IAttorneyFee"].ToString() != "" ? (decimal)dr["IAttorneyFee"] : 0;
                this.IMoney = dr["IMoney"].ToString();
                this.ItoNT = dr["ItoNT"].ToString() != "" ? (decimal)dr["ItoNT"] : 0;
                this.ITotall = dr["ITotall"].ToString() != "" ? (decimal)dr["ITotall"] : 0;
                this.ReceiptDate = dr["ReceiptDate"].ToString() == "" ? DateTime.Parse("1900/1/1") : (DateTime)dr["ReceiptDate"];
                this.OReceiptDate = dr["OReceiptDate"].ToString() == "" ? DateTime.Parse("1900/1/1") : (DateTime)dr["OReceiptDate"];
                this.OReceiptNo = dr["OReceiptNo"].ToString();
                this.OAttorneyFee = dr["OAttorneyFee"].ToString() != "" ? (decimal)dr["OAttorneyFee"] : 0;
                this.OMoney = dr["OMoney"].ToString();
                this.OtoNT = dr["OtoNT"].ToString() != "" ? (decimal)dr["OtoNT"] : 0;
                this.OTotall = dr["OTotall"].ToString() != "" ? (decimal)dr["OTotall"] : 0;
                this.OthFee = dr["OthFee"].ToString() != "" ? (decimal)dr["OthFee"] : 0;
                this.OthTotal = dr["OthTotal"].ToString() != "" ? (decimal)dr["OthTotal"] : 0;
                this.GReceiptDate = dr["GReceiptDate"].ToString() == "" ? DateTime.Parse("1900/1/1") : (DateTime)dr["GReceiptDate"];
                this.GReceiptNo = dr["GReceiptNo"].ToString();
                this.GovFee = dr["GovFee"].ToString() != "" ? (decimal)dr["GovFee"] : 0;
                this.GMoney = dr["GMoney"].ToString();
                this.GtoNT = dr["GtoNT"].ToString() != "" ? (decimal)dr["GtoNT"] : 0;
                this.GTotall = dr["GTotall"].ToString() != "" ? (decimal)dr["GTotall"] : 0;
                this.OAttorneyGovFee = dr["OAttorneyGovFee"].ToString() != "" ? (decimal)dr["OAttorneyGovFee"] : 0;
                this.Totall = dr["Totall"].ToString() != "" ? (decimal)dr["Totall"] : 0;
                this.TMoney = dr["TMoney"].ToString();
                this.TtoNT = dr["TtoNT"].ToString() != "" ? (decimal)dr["TtoNT"] : 0;
                this.TotalNT = dr["TotalNT"].ToString() != "" ? (decimal)dr["TotalNT"] : 0;
                this.OtherTotalFee = dr["OtherTotalFee"].ToString() != "" ? (decimal)dr["OtherTotalFee"] : 0;
                this.Pay = dr["Pay"].ToString() == "" ? false : (bool)dr["Pay"];
                this.PayDate = dr["PayDate"].ToString() == "" ? DateTime.Parse("1900/1/1") : (DateTime)dr["PayDate"];
                this.PPP = dr["PPP"].ToString();
                this.Withholding = dr["Withholding"].ToString() == "" ? false : (bool)dr["Withholding"];
                this.Tax = dr["Tax"].ToString() != "" ? (decimal)dr["Tax"] : 0;
                this.PracticalityPay = dr["PracticalityPay"].ToString() != "" ? (decimal)dr["PracticalityPay"] : 0;
                this.NT = dr["NT"].ToString() == "" ? false : (bool)dr["NT"];
                this.PayKind = dr["PayKind"].ToString();
                this.Remark = dr["Remark"].ToString();
                this.PayType = dr["PayType"].ToString() == "" ? -1 : (int)dr["PayType"];
                this.PayMemo = dr["PayMemo"].ToString();
                this.SingCode = dr["SingCode"].ToString();
                this.Days = dr["Days"].ToString() == "" ? -1 : (int)dr["Days"];
                this.IsClosing = dr["IsClosing"].ToString() == "" ? false : (bool)dr["IsClosing"];
                this.CloseDate = dr["CloseDate"].ToString() == "" ? DateTime.Parse("1900/1/1") : (DateTime)dr["CloseDate"];
                this.UpbuildDay = dr["UpbuildDay"].ToString() == "" ? DateTime.Parse("1900/1/1") : (DateTime)dr["UpbuildDay"];
                this.LastModifyDate = dr["LastModifyDate"].ToString() == "" ? DateTime.Parse("1900/1/1") : (DateTime)dr["LastModifyDate"];
                this.LastModifyWorker = dr["LastModifyWorker"].ToString() == "" ? -1 : (int)dr["LastModifyWorker"];
                this.Locker = dr["Locker"].ToString() == "" ? -1 : (int)dr["Locker"];
            }
            catch
            {
                throw (new System.Exception("TrademarkControversyFeeT該筆資料有誤：" + NO.ToString()));
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
                dr["Attorney"] = this.Attorney == -1 ? Rownull : this.Attorney;
                dr["FClientTransactor"] = this.FClientTransactor == -1 ? Rownull : this.FClientTransactor;
                dr["IReceiptDate"] = this.IReceiptDate.ToShortDateString() == "1900/1/1" ? Rownull : this.IReceiptDate;
                dr["IReceiptNo"] = this.IReceiptNo == "" ? Rownull : this.IReceiptNo;
                dr["aBillDate"] = this.aBillDate.ToShortDateString() == "1900/1/1" ? Rownull : this.aBillDate;
                dr["aBill"] = this.aBill == "" ? Rownull : this.aBill;
                dr["IAttorneyFee"] = this.IAttorneyFee.ToString() != "" ? this.IAttorneyFee : 0;
                dr["IMoney"] = this.IMoney == "" ? Rownull : this.IMoney;
                dr["ItoNT"] = this.ItoNT.ToString() != "" ? this.ItoNT : 0;
                dr["ITotall"] = this.ITotall.ToString() != "" ? this.ITotall : 0;
                dr["ReceiptDate"] = this.ReceiptDate.ToShortDateString() == "1900/1/1" ? Rownull : this.ReceiptDate;
                dr["OReceiptDate"] = this.OReceiptDate.ToShortDateString() == "1900/1/1" ? Rownull : this.OReceiptDate;
                dr["OReceiptNo"] = this.OReceiptNo == "" ? Rownull : this.OReceiptNo;
                dr["OAttorneyFee"] = this.OAttorneyFee.ToString() != "" ? this.OAttorneyFee : 0;
                dr["OMoney"] = this.OMoney == "" ? Rownull : this.OMoney;
                dr["OtoNT"] = this.OtoNT.ToString() != "" ? this.OtoNT : 0;
                dr["OTotall"] = this.OTotall.ToString() != "" ? this.OTotall : 0;
                dr["OthFee"] = this.OthFee.ToString() != "" ? this.OthFee : 0;
                dr["OthTotal"] = this.OthTotal.ToString() != "" ? this.OthTotal : 0;
                dr["GReceiptDate"] = this.GReceiptDate.ToShortDateString() == "1900/1/1" ? Rownull : this.GReceiptDate;
                dr["GReceiptNo"] = this.GReceiptNo == "" ? Rownull : this.GReceiptNo;
                dr["GovFee"] = this.GovFee.ToString() != "" ? this.GovFee : 0;
                dr["GMoney"] = this.GMoney == "" ? Rownull : this.GMoney;
                dr["GtoNT"] = this.GtoNT.ToString() != "" ? this.GtoNT : 0;
                dr["GTotall"] = this.GTotall.ToString() != "" ? this.GTotall : 0;
                dr["OAttorneyGovFee"] = this.OAttorneyGovFee.ToString() != "" ? this.OAttorneyGovFee : 0;
                dr["Totall"] = this.Totall.ToString() != "" ? this.Totall : 0;
                dr["TMoney"] = this.TMoney == "" ? Rownull : this.TMoney;
                dr["TtoNT"] = this.TtoNT.ToString() != "" ? this.TtoNT : 0;
                dr["TotalNT"] = this.TotalNT.ToString() != "" ? this.TotalNT : 0;
                dr["OtherTotalFee"] = this.OtherTotalFee.ToString() != "" ? this.OtherTotalFee : 0;
                dr["Pay"] = this.Pay;
                dr["PayDate"] = this.PayDate.ToShortDateString() == "1900/1/1" ? Rownull : this.PayDate;
                dr["PPP"] = this.PPP == "" ? Rownull : this.PPP;
                dr["Withholding"] = this.Withholding;
                dr["Tax"] = this.Tax.ToString() != "" ? this.Tax : 0;
                dr["PracticalityPay"] = this.PracticalityPay.ToString() != "" ? this.PracticalityPay : 0;
                dr["NT"] = this.NT;
                dr["PayKind"] = this.PayKind == "" ? Rownull : this.PayKind;
                dr["Remark"] = this.Remark == "" ? Rownull : this.Remark;
                dr["PayType"] = this.PayType == -1 ? Rownull : this.PayType;
                dr["PayMemo"] = this.PayMemo == "" ? Rownull : this.PayMemo;
                dr["SingCode"] = this.SingCode == "" ? Rownull : this.SingCode;
                dr["Days"] = this.Days == -1 ? Rownull : this.Days;
                dr["IsClosing"] = this.IsClosing;
                dr["CloseDate"] = this.CloseDate.ToShortDateString() == "1900/1/1" ? Rownull : this.CloseDate;
                dr["UpbuildDay"] = this.UpbuildDay.ToShortDateString() == "1900/1/1" ? Rownull : this.UpbuildDay;
                dr["LastModifyDate"] = this.LastModifyDate.ToShortDateString() == "1900/1/1" ? Rownull : this.LastModifyDate;
                dr["LastModifyWorker"] = this.LastModifyWorker == -1 ? Rownull : this.LastModifyWorker;
                dr["Locker"] = this.Locker == -1 ? Rownull : this.Locker;
                sAdapter.InsertCommand.Parameters["@TrademarkControversyID"].Value = dr["TrademarkControversyID"];
                sAdapter.InsertCommand.Parameters["@RDate"].Value = dr["RDate"];
                sAdapter.InsertCommand.Parameters["@FeeSubject"].Value = dr["FeeSubject"];
                sAdapter.InsertCommand.Parameters["@FeePhase"].Value = dr["FeePhase"];
                sAdapter.InsertCommand.Parameters["@Attorney"].Value = dr["Attorney"];
                sAdapter.InsertCommand.Parameters["@FClientTransactor"].Value = dr["FClientTransactor"];
                sAdapter.InsertCommand.Parameters["@IReceiptDate"].Value = dr["IReceiptDate"];
                sAdapter.InsertCommand.Parameters["@IReceiptNo"].Value = dr["IReceiptNo"];
                sAdapter.InsertCommand.Parameters["@aBillDate"].Value = dr["aBillDate"];
                sAdapter.InsertCommand.Parameters["@aBill"].Value = dr["aBill"];
                sAdapter.InsertCommand.Parameters["@IAttorneyFee"].Value = dr["IAttorneyFee"];
                sAdapter.InsertCommand.Parameters["@IMoney"].Value = dr["IMoney"];
                sAdapter.InsertCommand.Parameters["@ItoNT"].Value = dr["ItoNT"];
                sAdapter.InsertCommand.Parameters["@ITotall"].Value = dr["ITotall"];
                sAdapter.InsertCommand.Parameters["@ReceiptDate"].Value = dr["ReceiptDate"];
                sAdapter.InsertCommand.Parameters["@OReceiptDate"].Value = dr["OReceiptDate"];
                sAdapter.InsertCommand.Parameters["@OReceiptNo"].Value = dr["OReceiptNo"];
                sAdapter.InsertCommand.Parameters["@OAttorneyFee"].Value = dr["OAttorneyFee"];
                sAdapter.InsertCommand.Parameters["@OMoney"].Value = dr["OMoney"];
                sAdapter.InsertCommand.Parameters["@OtoNT"].Value = dr["OtoNT"];
                sAdapter.InsertCommand.Parameters["@OTotall"].Value = dr["OTotall"];
                sAdapter.InsertCommand.Parameters["@OthFee"].Value = dr["OthFee"];
                sAdapter.InsertCommand.Parameters["@OthTotal"].Value = dr["OthTotal"];
                sAdapter.InsertCommand.Parameters["@GReceiptDate"].Value = dr["GReceiptDate"];
                sAdapter.InsertCommand.Parameters["@GReceiptNo"].Value = dr["GReceiptNo"];
                sAdapter.InsertCommand.Parameters["@GovFee"].Value = dr["GovFee"];
                sAdapter.InsertCommand.Parameters["@GMoney"].Value = dr["GMoney"];
                sAdapter.InsertCommand.Parameters["@GtoNT"].Value = dr["GtoNT"];
                sAdapter.InsertCommand.Parameters["@GTotall"].Value = dr["GTotall"];
                sAdapter.InsertCommand.Parameters["@OAttorneyGovFee"].Value = dr["OAttorneyGovFee"];
                sAdapter.InsertCommand.Parameters["@Totall"].Value = dr["Totall"];
                sAdapter.InsertCommand.Parameters["@TMoney"].Value = dr["TMoney"];
                sAdapter.InsertCommand.Parameters["@TtoNT"].Value = dr["TtoNT"];
                sAdapter.InsertCommand.Parameters["@TotalNT"].Value = dr["TotalNT"];
                sAdapter.InsertCommand.Parameters["@OtherTotalFee"].Value = dr["OtherTotalFee"];
                sAdapter.InsertCommand.Parameters["@Pay"].Value = dr["Pay"];
                sAdapter.InsertCommand.Parameters["@PayDate"].Value = dr["PayDate"];
                sAdapter.InsertCommand.Parameters["@PPP"].Value = dr["PPP"];
                sAdapter.InsertCommand.Parameters["@Withholding"].Value = dr["Withholding"];
                sAdapter.InsertCommand.Parameters["@Tax"].Value = dr["Tax"];
                sAdapter.InsertCommand.Parameters["@PracticalityPay"].Value = dr["PracticalityPay"];
                sAdapter.InsertCommand.Parameters["@NT"].Value = dr["NT"];
                sAdapter.InsertCommand.Parameters["@PayKind"].Value = dr["PayKind"];
                sAdapter.InsertCommand.Parameters["@Remark"].Value = dr["Remark"];
                sAdapter.InsertCommand.Parameters["@PayType"].Value = dr["PayType"];
                sAdapter.InsertCommand.Parameters["@PayMemo"].Value = dr["PayMemo"];
                sAdapter.InsertCommand.Parameters["@SingCode"].Value = dr["SingCode"];
                sAdapter.InsertCommand.Parameters["@Days"].Value = dr["Days"];
                sAdapter.InsertCommand.Parameters["@IsClosing"].Value = dr["IsClosing"];
                sAdapter.InsertCommand.Parameters["@CloseDate"].Value = dr["CloseDate"];
                sAdapter.InsertCommand.Parameters["@UpbuildDay"].Value = dr["UpbuildDay"];
                sAdapter.InsertCommand.Parameters["@LastModifyDate"].Value = dr["LastModifyDate"];
                sAdapter.InsertCommand.Parameters["@LastModifyWorker"].Value = dr["LastModifyWorker"];
                sAdapter.InsertCommand.Parameters["@Locker"].Value = dr["Locker"];
                conn.Open();
                string KEY = sAdapter.InsertCommand.ExecuteScalar().ToString();
                conn.Close();
                if (KEY != "")
                {
                    this.ControversyFeeKEY = int.Parse(KEY);
                    dr["ControversyFeeKEY"] = this.ControversyFeeKEY;
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
                dr["Attorney"] = this.Attorney == -1 ? Rownull : this.Attorney;
                dr["FClientTransactor"] = this.FClientTransactor == -1 ? Rownull : this.FClientTransactor;
                dr["IReceiptDate"] = this.IReceiptDate.ToShortDateString() == "1900/1/1" ? Rownull : this.IReceiptDate;
                dr["IReceiptNo"] = this.IReceiptNo == "" ? Rownull : this.IReceiptNo;
                dr["aBillDate"] = this.aBillDate.ToShortDateString() == "1900/1/1" ? Rownull : this.aBillDate;
                dr["aBill"] = this.aBill == "" ? Rownull : this.aBill;
                dr["IAttorneyFee"] = this.IAttorneyFee.ToString() != "" ? this.IAttorneyFee : 0;
                dr["IMoney"] = this.IMoney == "" ? Rownull : this.IMoney;
                dr["ItoNT"] = this.ItoNT.ToString() != "" ? this.ItoNT : 0;
                dr["ITotall"] = this.ITotall.ToString() != "" ? this.ITotall : 0;
                dr["ReceiptDate"] = this.ReceiptDate.ToShortDateString() == "1900/1/1" ? Rownull : this.ReceiptDate;
                dr["OReceiptDate"] = this.OReceiptDate.ToShortDateString() == "1900/1/1" ? Rownull : this.OReceiptDate;
                dr["OReceiptNo"] = this.OReceiptNo == "" ? Rownull : this.OReceiptNo;
                dr["OAttorneyFee"] = this.OAttorneyFee.ToString() != "" ? this.OAttorneyFee : 0;
                dr["OMoney"] = this.OMoney == "" ? Rownull : this.OMoney;
                dr["OtoNT"] = this.OtoNT.ToString() != "" ? this.OtoNT : 0;
                dr["OTotall"] = this.OTotall.ToString() != "" ? this.OTotall : 0;
                dr["OthFee"] = this.OthFee.ToString() != "" ? this.OthFee : 0;
                dr["OthTotal"] = this.OthTotal.ToString() != "" ? this.OthTotal : 0;
                dr["GReceiptDate"] = this.GReceiptDate.ToShortDateString() == "1900/1/1" ? Rownull : this.GReceiptDate;
                dr["GReceiptNo"] = this.GReceiptNo == "" ? Rownull : this.GReceiptNo;
                dr["GovFee"] = this.GovFee.ToString() != "" ? this.GovFee : 0;
                dr["GMoney"] = this.GMoney == "" ? Rownull : this.GMoney;
                dr["GtoNT"] = this.GtoNT.ToString() != "" ? this.GtoNT : 0;
                dr["GTotall"] = this.GTotall.ToString() != "" ? this.GTotall : 0;
                dr["OAttorneyGovFee"] = this.OAttorneyGovFee.ToString() != "" ? this.OAttorneyGovFee : 0;
                dr["Totall"] = this.Totall.ToString() != "" ? this.Totall : 0;
                dr["TMoney"] = this.TMoney == "" ? Rownull : this.TMoney;
                dr["TtoNT"] = this.TtoNT.ToString() != "" ? this.TtoNT : 0;
                dr["TotalNT"] = this.TotalNT.ToString() != "" ? this.TotalNT : 0;
                dr["OtherTotalFee"] = this.OtherTotalFee.ToString() != "" ? this.OtherTotalFee : 0;
                dr["Pay"] = this.Pay;
                dr["PayDate"] = this.PayDate.ToShortDateString() == "1900/1/1" ? Rownull : this.PayDate;
                dr["PPP"] = this.PPP == "" ? Rownull : this.PPP;
                dr["Withholding"] = this.Withholding;
                dr["Tax"] = this.Tax.ToString() != "" ? this.Tax : 0;
                dr["PracticalityPay"] = this.PracticalityPay.ToString() != "" ? this.PracticalityPay : 0;
                dr["NT"] = this.NT;
                dr["PayKind"] = this.PayKind == "" ? Rownull : this.PayKind;
                dr["Remark"] = this.Remark == "" ? Rownull : this.Remark;
                dr["PayType"] = this.PayType == -1 ? Rownull : this.PayType;
                dr["PayMemo"] = this.PayMemo == "" ? Rownull : this.PayMemo;
                dr["SingCode"] = this.SingCode == "" ? Rownull : this.SingCode;
                dr["Days"] = this.Days == -1 ? Rownull : this.Days;
                dr["IsClosing"] = this.IsClosing;
                dr["CloseDate"] = this.CloseDate.ToShortDateString() == "1900/1/1" ? Rownull : this.CloseDate;
                dr["UpbuildDay"] = this.UpbuildDay.ToShortDateString() == "1900/1/1" ? Rownull : this.UpbuildDay;
                dr["LastModifyDate"] = this.LastModifyDate.ToShortDateString() == "1900/1/1" ? Rownull : this.LastModifyDate;
                dr["LastModifyWorker"] = this.LastModifyWorker == -1 ? Rownull : this.LastModifyWorker;
                dr["Locker"] = this.Locker == -1 ? Rownull : this.Locker;
                sAdapter.UpdateCommand.Parameters.Clear();
                sAdapter.UpdateCommand.Parameters.Add("ControversyFeeKEY", SqlDbType.Int);
                sAdapter.UpdateCommand.Parameters["ControversyFeeKEY"].Value = dr["ControversyFeeKEY"];
                sAdapter.UpdateCommand.Parameters.Add("TrademarkControversyID", SqlDbType.Int);
                sAdapter.UpdateCommand.Parameters["TrademarkControversyID"].Value = dr["TrademarkControversyID"];
                sAdapter.UpdateCommand.Parameters.Add("RDate", SqlDbType.DateTime);
                sAdapter.UpdateCommand.Parameters["RDate"].Value = dr["RDate"];
                sAdapter.UpdateCommand.Parameters.Add("FeeSubject", SqlDbType.NVarChar);
                sAdapter.UpdateCommand.Parameters["FeeSubject"].Value = dr["FeeSubject"];
                sAdapter.UpdateCommand.Parameters.Add("FeePhase", SqlDbType.Int);
                sAdapter.UpdateCommand.Parameters["FeePhase"].Value = dr["FeePhase"];
                sAdapter.UpdateCommand.Parameters.Add("Attorney", SqlDbType.Int);
                sAdapter.UpdateCommand.Parameters["Attorney"].Value = dr["Attorney"];
                sAdapter.UpdateCommand.Parameters.Add("FClientTransactor", SqlDbType.Int);
                sAdapter.UpdateCommand.Parameters["FClientTransactor"].Value = dr["FClientTransactor"];
                sAdapter.UpdateCommand.Parameters.Add("IReceiptDate", SqlDbType.DateTime);
                sAdapter.UpdateCommand.Parameters["IReceiptDate"].Value = dr["IReceiptDate"];
                sAdapter.UpdateCommand.Parameters.Add("IReceiptNo", SqlDbType.NVarChar);
                sAdapter.UpdateCommand.Parameters["IReceiptNo"].Value = dr["IReceiptNo"];
                sAdapter.UpdateCommand.Parameters.Add("aBillDate", SqlDbType.DateTime);
                sAdapter.UpdateCommand.Parameters["aBillDate"].Value = dr["aBillDate"];
                sAdapter.UpdateCommand.Parameters.Add("aBill", SqlDbType.NVarChar);
                sAdapter.UpdateCommand.Parameters["aBill"].Value = dr["aBill"];
                sAdapter.UpdateCommand.Parameters.Add("IAttorneyFee", SqlDbType.Decimal);
                sAdapter.UpdateCommand.Parameters["IAttorneyFee"].Value = dr["IAttorneyFee"];
                sAdapter.UpdateCommand.Parameters.Add("IMoney", SqlDbType.NVarChar);
                sAdapter.UpdateCommand.Parameters["IMoney"].Value = dr["IMoney"];
                sAdapter.UpdateCommand.Parameters.Add("ItoNT", SqlDbType.Decimal);
                sAdapter.UpdateCommand.Parameters["ItoNT"].Value = dr["ItoNT"];
                sAdapter.UpdateCommand.Parameters.Add("ITotall", SqlDbType.Decimal);
                sAdapter.UpdateCommand.Parameters["ITotall"].Value = dr["ITotall"];
                sAdapter.UpdateCommand.Parameters.Add("ReceiptDate", SqlDbType.DateTime);
                sAdapter.UpdateCommand.Parameters["ReceiptDate"].Value = dr["ReceiptDate"];
                sAdapter.UpdateCommand.Parameters.Add("OReceiptDate", SqlDbType.DateTime);
                sAdapter.UpdateCommand.Parameters["OReceiptDate"].Value = dr["OReceiptDate"];
                sAdapter.UpdateCommand.Parameters.Add("OReceiptNo", SqlDbType.NVarChar);
                sAdapter.UpdateCommand.Parameters["OReceiptNo"].Value = dr["OReceiptNo"];
                sAdapter.UpdateCommand.Parameters.Add("OAttorneyFee", SqlDbType.Decimal);
                sAdapter.UpdateCommand.Parameters["OAttorneyFee"].Value = dr["OAttorneyFee"];
                sAdapter.UpdateCommand.Parameters.Add("OMoney", SqlDbType.NVarChar);
                sAdapter.UpdateCommand.Parameters["OMoney"].Value = dr["OMoney"];
                sAdapter.UpdateCommand.Parameters.Add("OtoNT", SqlDbType.Decimal);
                sAdapter.UpdateCommand.Parameters["OtoNT"].Value = dr["OtoNT"];
                sAdapter.UpdateCommand.Parameters.Add("OTotall", SqlDbType.Decimal);
                sAdapter.UpdateCommand.Parameters["OTotall"].Value = dr["OTotall"];
                sAdapter.UpdateCommand.Parameters.Add("OthFee", SqlDbType.Decimal);
                sAdapter.UpdateCommand.Parameters["OthFee"].Value = dr["OthFee"];
                sAdapter.UpdateCommand.Parameters.Add("OthTotal", SqlDbType.Decimal);
                sAdapter.UpdateCommand.Parameters["OthTotal"].Value = dr["OthTotal"];
                sAdapter.UpdateCommand.Parameters.Add("GReceiptDate", SqlDbType.DateTime);
                sAdapter.UpdateCommand.Parameters["GReceiptDate"].Value = dr["GReceiptDate"];
                sAdapter.UpdateCommand.Parameters.Add("GReceiptNo", SqlDbType.NVarChar);
                sAdapter.UpdateCommand.Parameters["GReceiptNo"].Value = dr["GReceiptNo"];
                sAdapter.UpdateCommand.Parameters.Add("GovFee", SqlDbType.Decimal);
                sAdapter.UpdateCommand.Parameters["GovFee"].Value = dr["GovFee"];
                sAdapter.UpdateCommand.Parameters.Add("GMoney", SqlDbType.NVarChar);
                sAdapter.UpdateCommand.Parameters["GMoney"].Value = dr["GMoney"];
                sAdapter.UpdateCommand.Parameters.Add("GtoNT", SqlDbType.Decimal);
                sAdapter.UpdateCommand.Parameters["GtoNT"].Value = dr["GtoNT"];
                sAdapter.UpdateCommand.Parameters.Add("GTotall", SqlDbType.Decimal);
                sAdapter.UpdateCommand.Parameters["GTotall"].Value = dr["GTotall"];
                sAdapter.UpdateCommand.Parameters.Add("OAttorneyGovFee", SqlDbType.Decimal);
                sAdapter.UpdateCommand.Parameters["OAttorneyGovFee"].Value = dr["OAttorneyGovFee"];
                sAdapter.UpdateCommand.Parameters.Add("Totall", SqlDbType.Decimal);
                sAdapter.UpdateCommand.Parameters["Totall"].Value = dr["Totall"];
                sAdapter.UpdateCommand.Parameters.Add("TMoney", SqlDbType.NVarChar);
                sAdapter.UpdateCommand.Parameters["TMoney"].Value = dr["TMoney"];
                sAdapter.UpdateCommand.Parameters.Add("TtoNT", SqlDbType.Decimal);
                sAdapter.UpdateCommand.Parameters["TtoNT"].Value = dr["TtoNT"];
                sAdapter.UpdateCommand.Parameters.Add("TotalNT", SqlDbType.Decimal);
                sAdapter.UpdateCommand.Parameters["TotalNT"].Value = dr["TotalNT"];
                sAdapter.UpdateCommand.Parameters.Add("OtherTotalFee", SqlDbType.Decimal);
                sAdapter.UpdateCommand.Parameters["OtherTotalFee"].Value = dr["OtherTotalFee"];
                sAdapter.UpdateCommand.Parameters.Add("Pay", SqlDbType.Bit);
                sAdapter.UpdateCommand.Parameters["Pay"].Value = dr["Pay"];
                sAdapter.UpdateCommand.Parameters.Add("PayDate", SqlDbType.DateTime);
                sAdapter.UpdateCommand.Parameters["PayDate"].Value = dr["PayDate"];
                sAdapter.UpdateCommand.Parameters.Add("PPP", SqlDbType.NVarChar);
                sAdapter.UpdateCommand.Parameters["PPP"].Value = dr["PPP"];
                sAdapter.UpdateCommand.Parameters.Add("Withholding", SqlDbType.Bit);
                sAdapter.UpdateCommand.Parameters["Withholding"].Value = dr["Withholding"];
                sAdapter.UpdateCommand.Parameters.Add("Tax", SqlDbType.Decimal);
                sAdapter.UpdateCommand.Parameters["Tax"].Value = dr["Tax"];
                sAdapter.UpdateCommand.Parameters.Add("PracticalityPay", SqlDbType.Decimal);
                sAdapter.UpdateCommand.Parameters["PracticalityPay"].Value = dr["PracticalityPay"];
                sAdapter.UpdateCommand.Parameters.Add("NT", SqlDbType.Bit);
                sAdapter.UpdateCommand.Parameters["NT"].Value = dr["NT"];
                sAdapter.UpdateCommand.Parameters.Add("PayKind", SqlDbType.NVarChar);
                sAdapter.UpdateCommand.Parameters["PayKind"].Value = dr["PayKind"];
                sAdapter.UpdateCommand.Parameters.Add("Remark", SqlDbType.NVarChar);
                sAdapter.UpdateCommand.Parameters["Remark"].Value = dr["Remark"];
                sAdapter.UpdateCommand.Parameters.Add("PayType", SqlDbType.Int);
                sAdapter.UpdateCommand.Parameters["PayType"].Value = dr["PayType"];
                sAdapter.UpdateCommand.Parameters.Add("PayMemo", SqlDbType.NVarChar);
                sAdapter.UpdateCommand.Parameters["PayMemo"].Value = dr["PayMemo"];
                sAdapter.UpdateCommand.Parameters.Add("SingCode", SqlDbType.NVarChar);
                sAdapter.UpdateCommand.Parameters["SingCode"].Value = dr["SingCode"];
                sAdapter.UpdateCommand.Parameters.Add("Days", SqlDbType.Int);
                sAdapter.UpdateCommand.Parameters["Days"].Value = dr["Days"];
                sAdapter.UpdateCommand.Parameters.Add("IsClosing", SqlDbType.Bit);
                sAdapter.UpdateCommand.Parameters["IsClosing"].Value = dr["IsClosing"];
                sAdapter.UpdateCommand.Parameters.Add("CloseDate", SqlDbType.DateTime);
                sAdapter.UpdateCommand.Parameters["CloseDate"].Value = dr["CloseDate"];
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
                StringBuilder delString = new StringBuilder("DELETE FROM TrademarkControversyFeeT where " + strSQLWhere);
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
                StringBuilder delString = new StringBuilder("DELETE FROM TrademarkControversyFeeT where ControversyFeeKEY=@ControversyFeeKEY ");
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
