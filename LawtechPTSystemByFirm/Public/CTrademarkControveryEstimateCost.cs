using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using H3Operator.DBHelper;

namespace LawtechPTSystemByFirm.Public
{
    #region ======CTrademarkControveryEstimateCost======
    public class CTrademarkControveryEstimateCost
    {
        SqlConnection conn = new SqlConnection(DBAccess.ConnectionListDefaultConnectionString);
        SqlDataAdapter sAdapter;
        SqlCommandBuilder CBuilder;

        DataTable dt;
        /// <summary>
        /// 預設帶出所有的資料
        /// </summary>
        public CTrademarkControveryEstimateCost()
        {
            sAdapter = new SqlDataAdapter("select * from TrademarkControveryEstimateCostT", conn);
            dt = new DataTable();
            //DataSet ds = new DataSet();
            //ds.Tables.Add(dt);
            sAdapter.FillSchema(dt, SchemaType.Source);
            sAdapter.Fill(dt);
            CBuilder = new SqlCommandBuilder(sAdapter);
            sAdapter.InsertCommand = CBuilder.GetInsertCommand(true);
            sAdapter.InsertCommand.UpdatedRowSource = UpdateRowSource.Both;
            sAdapter.InsertCommand.CommandText += " Select @@IDENTITY AS 'IDENTITY'";
            sAdapter.UpdateCommand = new SqlCommand(@"UPDATE TrademarkControveryEstimateCostT  SET 
                                                       TrademarkControversyID=@TrademarkControversyID,
                                                       FeeSubject=@FeeSubject,
                                                       IAttorneyFee=@IAttorneyFee,
                                                       IMoney=@IMoney,
                                                       ItoNT=@ItoNT,
                                                       ITotall=@ITotall,
                                                       OAttorneyFee=@OAttorneyFee,
                                                       OMoney=@OMoney,
                                                       OtoNT=@OtoNT,
                                                       OTotall=@OTotall,
                                                       GovFee=@GovFee,
                                                       GMoney=@GMoney,
                                                       GtoNT=@GtoNT,
                                                       GTotall=@GTotall,
                                                       OtherFee=@OtherFee,
                                                       OtherMoney=@OtherMoney,
                                                       OtherNT=@OtherNT,
                                                       OtherTotal=@OtherTotal,
                                                       EstimateCost=@EstimateCost,
                                                       EstimateProfit=@EstimateProfit,
                                                       RealPrice=@RealPrice,
                                                       PayMemo=@PayMemo,
                                                       Remark=@Remark,
                                                       CreateDate=@CreateDate,
                                                       Locker=@Locker,
                                                       LastModifyWorker=@LastModifyWorker,
                                                       LastModifyDate=@LastModifyDate
                                                   where 
                                                       TMControveryEstimateCostID=@TMControveryEstimateCostID", conn);
        }
        /// <summary>
        /// 有條件的過濾資料
        /// </summary>
        /// <param name="sWhere">SQL的條件式</param>
        public CTrademarkControveryEstimateCost(string sWhere)
        {
            sAdapter = new SqlDataAdapter("select * from TrademarkControveryEstimateCostT where " + sWhere, conn);
            dt = new DataTable();
            //DataSet ds = new DataSet();
            //ds.Tables.Add(dt);
            sAdapter.FillSchema(dt, SchemaType.Source);
            sAdapter.Fill(dt);
            CBuilder = new SqlCommandBuilder(sAdapter);
            sAdapter.InsertCommand = CBuilder.GetInsertCommand(true);
            sAdapter.InsertCommand.UpdatedRowSource = UpdateRowSource.Both;
            sAdapter.InsertCommand.CommandText += " Select @@IDENTITY AS 'IDENTITY'";
            sAdapter.UpdateCommand = new SqlCommand(@"UPDATE TrademarkControveryEstimateCostT  SET 
                                                       TrademarkControversyID=@TrademarkControversyID,
                                                       FeeSubject=@FeeSubject,
                                                       IAttorneyFee=@IAttorneyFee,
                                                       IMoney=@IMoney,
                                                       ItoNT=@ItoNT,
                                                       ITotall=@ITotall,
                                                       OAttorneyFee=@OAttorneyFee,
                                                       OMoney=@OMoney,
                                                       OtoNT=@OtoNT,
                                                       OTotall=@OTotall,
                                                       GovFee=@GovFee,
                                                       GMoney=@GMoney,
                                                       GtoNT=@GtoNT,
                                                       GTotall=@GTotall,
                                                       OtherFee=@OtherFee,
                                                       OtherMoney=@OtherMoney,
                                                       OtherNT=@OtherNT,
                                                       OtherTotal=@OtherTotal,
                                                       EstimateCost=@EstimateCost,
                                                       EstimateProfit=@EstimateProfit,
                                                       RealPrice=@RealPrice,
                                                       PayMemo=@PayMemo,
                                                       Remark=@Remark,
                                                       CreateDate=@CreateDate,
                                                       Locker=@Locker,
                                                       LastModifyWorker=@LastModifyWorker,
                                                       LastModifyDate=@LastModifyDate
                                                   where 
                                                       TMControveryEstimateCostID=@TMControveryEstimateCostID", conn);
        }


        private int _TMControveryEstimateCostID = -1;
        /// <summary>  
        /// 
        /// </summary>  
        public int TMControveryEstimateCostID
        {
            get
            {
                return _TMControveryEstimateCostID;
            }
            set
            {
                _TMControveryEstimateCostID = value;
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
        private decimal _IAttorneyFee = 0;
        /// <summary>  
        /// 服務費
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
        /// 服務費-幣別
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
        /// 服務費-兌換
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
        /// 服務費-合計NT
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
        /// 國外事務所費用-匯率
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
        private decimal _GovFee = 0;
        /// <summary>  
        /// 官方費用
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
        /// 官方費用-幣別
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
        /// 官方費用-兌NT
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
        /// 官方費用-合計NT
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
        private string _OtherMoney = "";
        /// <summary>  
        /// 雜支-幣別
        /// </summary>  
        public String OtherMoney
        {
            get
            {
                return _OtherMoney;
            }
            set
            {
                _OtherMoney = value;
            }
        }
        private decimal _OtherNT = 0;
        /// <summary>  
        /// 雜支-兌NT
        /// </summary>  
        public decimal OtherNT
        {
            get
            {
                return _OtherNT;
            }
            set
            {
                _OtherNT = value;
            }
        }
        private decimal _OtherTotal = 0;
        /// <summary>  
        /// 雜支-合計NT
        /// </summary>  
        public decimal OtherTotal
        {
            get
            {
                return _OtherTotal;
            }
            set
            {
                _OtherTotal = value;
            }
        }
        private decimal _EstimateCost = 0;
        /// <summary>  
        /// 預估成本
        /// </summary>  
        public decimal EstimateCost
        {
            get
            {
                return _EstimateCost;
            }
            set
            {
                _EstimateCost = value;
            }
        }
        private decimal _EstimateProfit = 0;
        /// <summary>  
        /// 預估利潤
        /// </summary>  
        public decimal EstimateProfit
        {
            get
            {
                return _EstimateProfit;
            }
            set
            {
                _EstimateProfit = value;
            }
        }
        private decimal _RealPrice = 0;
        /// <summary>  
        /// 實際報價
        /// </summary>  
        public decimal RealPrice
        {
            get
            {
                return _RealPrice;
            }
            set
            {
                _RealPrice = value;
            }
        }
        private string _PayMemo = "";
        /// <summary>  
        /// 付款條件
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
        private DateTime _CreateDate = DateTime.Parse("1900/1/1");
        /// <summary>  
        /// 預估時間
        /// </summary>  
        public DateTime CreateDate
        {
            get
            {
                return _CreateDate;
            }
            set
            {
                _CreateDate = value;
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

        /// <summary>
        /// 取得TrademarkControveryEstimateCostT資料集
        /// </summary>
        public DataTable GetDataTable()
        {
            return dt;
        }

        /// <summary>
        /// 設定TrademarkControveryEstimateCostT資料集
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
            string strSQL = "select count(" + ColumnName + ") as CountValue from TrademarkControveryEstimateCostT where " + ColumnName + "='" + Value + "'";
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
            string strSQL = "select count(" + ColumnName + ") as CountValue from TrademarkControveryEstimateCostT where " + ColumnName + "=" + Value;
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
                this.TMControveryEstimateCostID = dr["TMControveryEstimateCostID"].ToString() == "" ? -1 : (int)dr["TMControveryEstimateCostID"];
                this.TrademarkControversyID = dr["TrademarkControversyID"].ToString() == "" ? -1 : (int)dr["TrademarkControversyID"];
                this.FeeSubject = dr["FeeSubject"].ToString();
                this.IAttorneyFee = dr["IAttorneyFee"].ToString() != "" ? (decimal)dr["IAttorneyFee"] : 0;
                this.IMoney = dr["IMoney"].ToString();
                this.ItoNT = dr["ItoNT"].ToString() != "" ? (decimal)dr["ItoNT"] : 0;
                this.ITotall = dr["ITotall"].ToString() != "" ? (decimal)dr["ITotall"] : 0;
                this.OAttorneyFee = dr["OAttorneyFee"].ToString() != "" ? (decimal)dr["OAttorneyFee"] : 0;
                this.OMoney = dr["OMoney"].ToString();
                this.OtoNT = dr["OtoNT"].ToString() != "" ? (decimal)dr["OtoNT"] : 0;
                this.OTotall = dr["OTotall"].ToString() != "" ? (decimal)dr["OTotall"] : 0;
                this.GovFee = dr["GovFee"].ToString() != "" ? (decimal)dr["GovFee"] : 0;
                this.GMoney = dr["GMoney"].ToString();
                this.GtoNT = dr["GtoNT"].ToString() != "" ? (decimal)dr["GtoNT"] : 0;
                this.GTotall = dr["GTotall"].ToString() != "" ? (decimal)dr["GTotall"] : 0;
                this.OtherFee = dr["OtherFee"].ToString() != "" ? (decimal)dr["OtherFee"] : 0;
                this.OtherMoney = dr["OtherMoney"].ToString();
                this.OtherNT = dr["OtherNT"].ToString() != "" ? (decimal)dr["OtherNT"] : 0;
                this.OtherTotal = dr["OtherTotal"].ToString() != "" ? (decimal)dr["OtherTotal"] : 0;
                this.EstimateCost = dr["EstimateCost"].ToString() != "" ? (decimal)dr["EstimateCost"] : 0;
                this.EstimateProfit = dr["EstimateProfit"].ToString() != "" ? (decimal)dr["EstimateProfit"] : 0;
                this.RealPrice = dr["RealPrice"].ToString() != "" ? (decimal)dr["RealPrice"] : 0;
                this.PayMemo = dr["PayMemo"].ToString();
                this.Remark = dr["Remark"].ToString();
                this.CreateDate = dr["CreateDate"].ToString() == "" ? DateTime.Parse("1900/1/1") : (DateTime)dr["CreateDate"];
                this.Locker = dr["Locker"].ToString() == "" ? -1 : (int)dr["Locker"];
                this.LastModifyWorker = dr["LastModifyWorker"].ToString() == "" ? -1 : (int)dr["LastModifyWorker"];
                this.LastModifyDate = dr["LastModifyDate"].ToString() == "" ? DateTime.Parse("1900/1/1") : (DateTime)dr["LastModifyDate"];
            }
            catch
            {
                throw (new System.Exception("TrademarkControveryEstimateCostT該筆資料有誤：" + NO.ToString()));
            }
        }
        public void Insert()
        {
            try
            {
                Object Rownull = System.DBNull.Value;
                DataRow dr = dt.NewRow();
                dr["TrademarkControversyID"] = this.TrademarkControversyID == -1 ? Rownull : this.TrademarkControversyID;
                dr["FeeSubject"] = this.FeeSubject == "" ? Rownull : this.FeeSubject;
                dr["IAttorneyFee"] = this.IAttorneyFee.ToString() != "" ? this.IAttorneyFee : 0;
                dr["IMoney"] = this.IMoney == "" ? Rownull : this.IMoney;
                dr["ItoNT"] = this.ItoNT.ToString() != "" ? this.ItoNT : 0;
                dr["ITotall"] = this.ITotall.ToString() != "" ? this.ITotall : 0;
                dr["OAttorneyFee"] = this.OAttorneyFee.ToString() != "" ? this.OAttorneyFee : 0;
                dr["OMoney"] = this.OMoney == "" ? Rownull : this.OMoney;
                dr["OtoNT"] = this.OtoNT.ToString() != "" ? this.OtoNT : 0;
                dr["OTotall"] = this.OTotall.ToString() != "" ? this.OTotall : 0;
                dr["GovFee"] = this.GovFee.ToString() != "" ? this.GovFee : 0;
                dr["GMoney"] = this.GMoney == "" ? Rownull : this.GMoney;
                dr["GtoNT"] = this.GtoNT.ToString() != "" ? this.GtoNT : 0;
                dr["GTotall"] = this.GTotall.ToString() != "" ? this.GTotall : 0;
                dr["OtherFee"] = this.OtherFee.ToString() != "" ? this.OtherFee : 0;
                dr["OtherMoney"] = this.OtherMoney == "" ? Rownull : this.OtherMoney;
                dr["OtherNT"] = this.OtherNT.ToString() != "" ? this.OtherNT : 0;
                dr["OtherTotal"] = this.OtherTotal.ToString() != "" ? this.OtherTotal : 0;
                dr["EstimateCost"] = this.EstimateCost.ToString() != "" ? this.EstimateCost : 0;
                dr["EstimateProfit"] = this.EstimateProfit.ToString() != "" ? this.EstimateProfit : 0;
                dr["RealPrice"] = this.RealPrice.ToString() != "" ? this.RealPrice : 0;
                dr["PayMemo"] = this.PayMemo == "" ? Rownull : this.PayMemo;
                dr["Remark"] = this.Remark == "" ? Rownull : this.Remark;
                dr["CreateDate"] = this.CreateDate.ToShortDateString() == "1900/1/1" ? Rownull : this.CreateDate;
                dr["Locker"] = this.Locker == -1 ? Rownull : this.Locker;
                dr["LastModifyWorker"] = this.LastModifyWorker == -1 ? Rownull : this.LastModifyWorker;
                dr["LastModifyDate"] = this.LastModifyDate.ToShortDateString() == "1900/1/1" ? Rownull : this.LastModifyDate;
                sAdapter.InsertCommand.Parameters["@TrademarkControversyID"].Value = dr["TrademarkControversyID"];
                sAdapter.InsertCommand.Parameters["@FeeSubject"].Value = dr["FeeSubject"];
                sAdapter.InsertCommand.Parameters["@IAttorneyFee"].Value = dr["IAttorneyFee"];
                sAdapter.InsertCommand.Parameters["@IMoney"].Value = dr["IMoney"];
                sAdapter.InsertCommand.Parameters["@ItoNT"].Value = dr["ItoNT"];
                sAdapter.InsertCommand.Parameters["@ITotall"].Value = dr["ITotall"];
                sAdapter.InsertCommand.Parameters["@OAttorneyFee"].Value = dr["OAttorneyFee"];
                sAdapter.InsertCommand.Parameters["@OMoney"].Value = dr["OMoney"];
                sAdapter.InsertCommand.Parameters["@OtoNT"].Value = dr["OtoNT"];
                sAdapter.InsertCommand.Parameters["@OTotall"].Value = dr["OTotall"];
                sAdapter.InsertCommand.Parameters["@GovFee"].Value = dr["GovFee"];
                sAdapter.InsertCommand.Parameters["@GMoney"].Value = dr["GMoney"];
                sAdapter.InsertCommand.Parameters["@GtoNT"].Value = dr["GtoNT"];
                sAdapter.InsertCommand.Parameters["@GTotall"].Value = dr["GTotall"];
                sAdapter.InsertCommand.Parameters["@OtherFee"].Value = dr["OtherFee"];
                sAdapter.InsertCommand.Parameters["@OtherMoney"].Value = dr["OtherMoney"];
                sAdapter.InsertCommand.Parameters["@OtherNT"].Value = dr["OtherNT"];
                sAdapter.InsertCommand.Parameters["@OtherTotal"].Value = dr["OtherTotal"];
                sAdapter.InsertCommand.Parameters["@EstimateCost"].Value = dr["EstimateCost"];
                sAdapter.InsertCommand.Parameters["@EstimateProfit"].Value = dr["EstimateProfit"];
                sAdapter.InsertCommand.Parameters["@RealPrice"].Value = dr["RealPrice"];
                sAdapter.InsertCommand.Parameters["@PayMemo"].Value = dr["PayMemo"];
                sAdapter.InsertCommand.Parameters["@Remark"].Value = dr["Remark"];
                sAdapter.InsertCommand.Parameters["@CreateDate"].Value = dr["CreateDate"];
                sAdapter.InsertCommand.Parameters["@Locker"].Value = dr["Locker"];
                sAdapter.InsertCommand.Parameters["@LastModifyWorker"].Value = dr["LastModifyWorker"];
                sAdapter.InsertCommand.Parameters["@LastModifyDate"].Value = dr["LastModifyDate"];
                conn.Open();
                string KEY = sAdapter.InsertCommand.ExecuteScalar().ToString();
                conn.Close();
                if (KEY != "")
                {
                    this.TMControveryEstimateCostID = int.Parse(KEY);
                    dr["TMControveryEstimateCostID"] = this.TMControveryEstimateCostID;
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
                dr["FeeSubject"] = this.FeeSubject == "" ? Rownull : this.FeeSubject;
                dr["IAttorneyFee"] = this.IAttorneyFee.ToString() != "" ? this.IAttorneyFee : 0;
                dr["IMoney"] = this.IMoney == "" ? Rownull : this.IMoney;
                dr["ItoNT"] = this.ItoNT.ToString() != "" ? this.ItoNT : 0;
                dr["ITotall"] = this.ITotall.ToString() != "" ? this.ITotall : 0;
                dr["OAttorneyFee"] = this.OAttorneyFee.ToString() != "" ? this.OAttorneyFee : 0;
                dr["OMoney"] = this.OMoney == "" ? Rownull : this.OMoney;
                dr["OtoNT"] = this.OtoNT.ToString() != "" ? this.OtoNT : 0;
                dr["OTotall"] = this.OTotall.ToString() != "" ? this.OTotall : 0;
                dr["GovFee"] = this.GovFee.ToString() != "" ? this.GovFee : 0;
                dr["GMoney"] = this.GMoney == "" ? Rownull : this.GMoney;
                dr["GtoNT"] = this.GtoNT.ToString() != "" ? this.GtoNT : 0;
                dr["GTotall"] = this.GTotall.ToString() != "" ? this.GTotall : 0;
                dr["OtherFee"] = this.OtherFee.ToString() != "" ? this.OtherFee : 0;
                dr["OtherMoney"] = this.OtherMoney == "" ? Rownull : this.OtherMoney;
                dr["OtherNT"] = this.OtherNT.ToString() != "" ? this.OtherNT : 0;
                dr["OtherTotal"] = this.OtherTotal.ToString() != "" ? this.OtherTotal : 0;
                dr["EstimateCost"] = this.EstimateCost.ToString() != "" ? this.EstimateCost : 0;
                dr["EstimateProfit"] = this.EstimateProfit.ToString() != "" ? this.EstimateProfit : 0;
                dr["RealPrice"] = this.RealPrice.ToString() != "" ? this.RealPrice : 0;
                dr["PayMemo"] = this.PayMemo == "" ? Rownull : this.PayMemo;
                dr["Remark"] = this.Remark == "" ? Rownull : this.Remark;
                dr["CreateDate"] = this.CreateDate.ToShortDateString() == "1900/1/1" ? Rownull : this.CreateDate;
                dr["Locker"] = this.Locker == -1 ? Rownull : this.Locker;
                dr["LastModifyWorker"] = this.LastModifyWorker == -1 ? Rownull : this.LastModifyWorker;
                dr["LastModifyDate"] = this.LastModifyDate.ToShortDateString() == "1900/1/1" ? Rownull : this.LastModifyDate;
                sAdapter.UpdateCommand.Parameters.Clear();
                sAdapter.UpdateCommand.Parameters.Add("TMControveryEstimateCostID", SqlDbType.Int);
                sAdapter.UpdateCommand.Parameters["TMControveryEstimateCostID"].Value = dr["TMControveryEstimateCostID"];
                sAdapter.UpdateCommand.Parameters.Add("TrademarkControversyID", SqlDbType.Int);
                sAdapter.UpdateCommand.Parameters["TrademarkControversyID"].Value = dr["TrademarkControversyID"];
                sAdapter.UpdateCommand.Parameters.Add("FeeSubject", SqlDbType.NVarChar);
                sAdapter.UpdateCommand.Parameters["FeeSubject"].Value = dr["FeeSubject"];
                sAdapter.UpdateCommand.Parameters.Add("IAttorneyFee", SqlDbType.Decimal);
                sAdapter.UpdateCommand.Parameters["IAttorneyFee"].Value = dr["IAttorneyFee"];
                sAdapter.UpdateCommand.Parameters.Add("IMoney", SqlDbType.NVarChar);
                sAdapter.UpdateCommand.Parameters["IMoney"].Value = dr["IMoney"];
                sAdapter.UpdateCommand.Parameters.Add("ItoNT", SqlDbType.Decimal);
                sAdapter.UpdateCommand.Parameters["ItoNT"].Value = dr["ItoNT"];
                sAdapter.UpdateCommand.Parameters.Add("ITotall", SqlDbType.Decimal);
                sAdapter.UpdateCommand.Parameters["ITotall"].Value = dr["ITotall"];
                sAdapter.UpdateCommand.Parameters.Add("OAttorneyFee", SqlDbType.Decimal);
                sAdapter.UpdateCommand.Parameters["OAttorneyFee"].Value = dr["OAttorneyFee"];
                sAdapter.UpdateCommand.Parameters.Add("OMoney", SqlDbType.NVarChar);
                sAdapter.UpdateCommand.Parameters["OMoney"].Value = dr["OMoney"];
                sAdapter.UpdateCommand.Parameters.Add("OtoNT", SqlDbType.Decimal);
                sAdapter.UpdateCommand.Parameters["OtoNT"].Value = dr["OtoNT"];
                sAdapter.UpdateCommand.Parameters.Add("OTotall", SqlDbType.Decimal);
                sAdapter.UpdateCommand.Parameters["OTotall"].Value = dr["OTotall"];
                sAdapter.UpdateCommand.Parameters.Add("GovFee", SqlDbType.Decimal);
                sAdapter.UpdateCommand.Parameters["GovFee"].Value = dr["GovFee"];
                sAdapter.UpdateCommand.Parameters.Add("GMoney", SqlDbType.NVarChar);
                sAdapter.UpdateCommand.Parameters["GMoney"].Value = dr["GMoney"];
                sAdapter.UpdateCommand.Parameters.Add("GtoNT", SqlDbType.Decimal);
                sAdapter.UpdateCommand.Parameters["GtoNT"].Value = dr["GtoNT"];
                sAdapter.UpdateCommand.Parameters.Add("GTotall", SqlDbType.Decimal);
                sAdapter.UpdateCommand.Parameters["GTotall"].Value = dr["GTotall"];
                sAdapter.UpdateCommand.Parameters.Add("OtherFee", SqlDbType.Decimal);
                sAdapter.UpdateCommand.Parameters["OtherFee"].Value = dr["OtherFee"];
                sAdapter.UpdateCommand.Parameters.Add("OtherMoney", SqlDbType.NVarChar);
                sAdapter.UpdateCommand.Parameters["OtherMoney"].Value = dr["OtherMoney"];
                sAdapter.UpdateCommand.Parameters.Add("OtherNT", SqlDbType.Decimal);
                sAdapter.UpdateCommand.Parameters["OtherNT"].Value = dr["OtherNT"];
                sAdapter.UpdateCommand.Parameters.Add("OtherTotal", SqlDbType.Decimal);
                sAdapter.UpdateCommand.Parameters["OtherTotal"].Value = dr["OtherTotal"];
                sAdapter.UpdateCommand.Parameters.Add("EstimateCost", SqlDbType.Decimal);
                sAdapter.UpdateCommand.Parameters["EstimateCost"].Value = dr["EstimateCost"];
                sAdapter.UpdateCommand.Parameters.Add("EstimateProfit", SqlDbType.Decimal);
                sAdapter.UpdateCommand.Parameters["EstimateProfit"].Value = dr["EstimateProfit"];
                sAdapter.UpdateCommand.Parameters.Add("RealPrice", SqlDbType.Decimal);
                sAdapter.UpdateCommand.Parameters["RealPrice"].Value = dr["RealPrice"];
                sAdapter.UpdateCommand.Parameters.Add("PayMemo", SqlDbType.NVarChar);
                sAdapter.UpdateCommand.Parameters["PayMemo"].Value = dr["PayMemo"];
                sAdapter.UpdateCommand.Parameters.Add("Remark", SqlDbType.NVarChar);
                sAdapter.UpdateCommand.Parameters["Remark"].Value = dr["Remark"];
                sAdapter.UpdateCommand.Parameters.Add("CreateDate", SqlDbType.DateTime);
                sAdapter.UpdateCommand.Parameters["CreateDate"].Value = dr["CreateDate"];
                sAdapter.UpdateCommand.Parameters.Add("Locker", SqlDbType.Int);
                sAdapter.UpdateCommand.Parameters["Locker"].Value = dr["Locker"];
                sAdapter.UpdateCommand.Parameters.Add("LastModifyWorker", SqlDbType.Int);
                sAdapter.UpdateCommand.Parameters["LastModifyWorker"].Value = dr["LastModifyWorker"];
                sAdapter.UpdateCommand.Parameters.Add("LastModifyDate", SqlDbType.DateTime);
                sAdapter.UpdateCommand.Parameters["LastModifyDate"].Value = dr["LastModifyDate"];

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
                StringBuilder delString = new StringBuilder("DELETE FROM TrademarkControveryEstimateCostT where " + strSQLWhere);
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
                StringBuilder delString = new StringBuilder("DELETE FROM TrademarkControveryEstimateCostT where TMControveryEstimateCostID=@TMControveryEstimateCostID ");
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
