using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using H3Operator.DBHelper;

namespace LawtechPTSystem.Public
{
    #region ======CTrademarkControversyNotifyEvent======
    public class CTrademarkControversyNotifyEvent
    {
        SqlConnection conn = new SqlConnection(DBAccess.ConnectionListDefaultConnectionString);
        SqlDataAdapter sAdapter;
        SqlCommandBuilder CBuilder;

        DataTable dt;
        /// <summary>
        /// 預設帶出所有的資料
        /// </summary>
        public CTrademarkControversyNotifyEvent()
        {
            sAdapter = new SqlDataAdapter("select * from TrademarkControversyNotifyEventT", conn);
            dt = new DataTable();
            //DataSet ds = new DataSet();
            //ds.Tables.Add(dt);
            sAdapter.FillSchema(dt, SchemaType.Source);
            sAdapter.Fill(dt);
            CBuilder = new SqlCommandBuilder(sAdapter);
            sAdapter.InsertCommand = CBuilder.GetInsertCommand(true);
            sAdapter.InsertCommand.UpdatedRowSource = UpdateRowSource.Both;
            sAdapter.InsertCommand.CommandText += " Select @@IDENTITY AS 'IDENTITY'";
            sAdapter.UpdateCommand = new SqlCommand(@"UPDATE TrademarkControversyNotifyEventT  SET 
                                                       TrademarkControversyID=@TrademarkControversyID,
                                                       NotifyEventContent=@NotifyEventContent,
                                                       EventType=@EventType,
                                                       TMStatusID=@TMStatusID,
                                                       NotifyComitDate=@NotifyComitDate,
                                                       WorkerKey=@WorkerKey,
                                                       OccurDate=@OccurDate,
                                                       NotifyOfficerDate=@NotifyOfficerDate,
                                                       DueDate=@DueDate,
                                                       NoticeDate=@NoticeDate,
                                                       AttorneyDueDate=@AttorneyDueDate,
                                                       CustomerAuthorizationDate=@CustomerAuthorizationDate,
                                                       OutsourcingDate=@OutsourcingDate,
                                                       FinishDate=@FinishDate,
                                                       Result=@Result,
                                                       Remark=@Remark,
                                                       LastModifyDate=@LastModifyDate,
                                                       UpbuildDay=@UpbuildDay,
                                                       LastModifyWorker=@LastModifyWorker,
                                                       Locker=@Locker
                                                   where 
                                                       TMNotifyControversyEventID=@TMNotifyControversyEventID", conn);
        }
        /// <summary>
        /// 有條件的過濾資料
        /// </summary>
        /// <param name="sWhere">SQL的條件式</param>
        public CTrademarkControversyNotifyEvent(string sWhere)
        {
            sAdapter = new SqlDataAdapter("select * from TrademarkControversyNotifyEventT where " + sWhere, conn);
            dt = new DataTable();
            //DataSet ds = new DataSet();
            //ds.Tables.Add(dt);
            sAdapter.FillSchema(dt, SchemaType.Source);
            sAdapter.Fill(dt);
            CBuilder = new SqlCommandBuilder(sAdapter);
            sAdapter.InsertCommand = CBuilder.GetInsertCommand(true);
            sAdapter.InsertCommand.UpdatedRowSource = UpdateRowSource.Both;
            sAdapter.InsertCommand.CommandText += " Select @@IDENTITY AS 'IDENTITY'";
            sAdapter.UpdateCommand = new SqlCommand(@"UPDATE TrademarkControversyNotifyEventT  SET 
                                                       TrademarkControversyID=@TrademarkControversyID,
                                                       NotifyEventContent=@NotifyEventContent,
                                                       EventType=@EventType,
                                                       TMStatusID=@TMStatusID,
                                                       NotifyComitDate=@NotifyComitDate,
                                                       WorkerKey=@WorkerKey,
                                                       OccurDate=@OccurDate,
                                                       NotifyOfficerDate=@NotifyOfficerDate,
                                                       DueDate=@DueDate,
                                                       NoticeDate=@NoticeDate,
                                                       AttorneyDueDate=@AttorneyDueDate,
                                                       CustomerAuthorizationDate=@CustomerAuthorizationDate,
                                                       OutsourcingDate=@OutsourcingDate,
                                                       FinishDate=@FinishDate,
                                                       Result=@Result,
                                                       Remark=@Remark,
                                                       LastModifyDate=@LastModifyDate,
                                                       UpbuildDay=@UpbuildDay,
                                                       LastModifyWorker=@LastModifyWorker,
                                                       Locker=@Locker
                                                   where 
                                                       TMNotifyControversyEventID=@TMNotifyControversyEventID", conn);
        }


        private int _TMNotifyControversyEventID = -1;
        /// <summary>  
        /// 
        /// </summary>  
        public int TMNotifyControversyEventID
        {
            get
            {
                return _TMNotifyControversyEventID;
            }
            set
            {
                _TMNotifyControversyEventID = value;
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
        private string _NotifyEventContent = "";
        /// <summary>  
        /// 來函內容
        /// </summary>  
        public String NotifyEventContent
        {
            get
            {
                return _NotifyEventContent;
            }
            set
            {
                _NotifyEventContent = value;
            }
        }
        private string _EventType = "";
        /// <summary>  
        /// 事件種類
        /// </summary>  
        public String EventType
        {
            get
            {
                return _EventType;
            }
            set
            {
                _EventType = value;
            }
        }
        private int _TMStatusID = -1;
        /// <summary>  
        /// 案件階段
        /// </summary>  
        public int TMStatusID
        {
            get
            {
                return _TMStatusID;
            }
            set
            {
                _TMStatusID = value;
            }
        }
        private DateTime _NotifyComitDate = DateTime.Parse("1900/1/1");
        /// <summary>  
        /// 本所來函日
        /// </summary>  
        public DateTime NotifyComitDate
        {
            get
            {
                return _NotifyComitDate;
            }
            set
            {
                _NotifyComitDate = value;
            }
        }
        private int _WorkerKey = -1;
        /// <summary>  
        /// 本所承辦人
        /// </summary>  
        public int WorkerKey
        {
            get
            {
                return _WorkerKey;
            }
            set
            {
                _WorkerKey = value;
            }
        }
        private DateTime _OccurDate = DateTime.Parse("1900/1/1");
        /// <summary>  
        /// 官方送達日
        /// </summary>  
        public DateTime OccurDate
        {
            get
            {
                return _OccurDate;
            }
            set
            {
                _OccurDate = value;
            }
        }
        private DateTime _NotifyOfficerDate = DateTime.Parse("1900/1/1");
        /// <summary>  
        /// 官方發文日
        /// </summary>  
        public DateTime NotifyOfficerDate
        {
            get
            {
                return _NotifyOfficerDate;
            }
            set
            {
                _NotifyOfficerDate = value;
            }
        }
        private DateTime _DueDate = DateTime.Parse("1900/1/1");
        /// <summary>  
        /// 官方期限
        /// </summary>  
        public DateTime DueDate
        {
            get
            {
                return _DueDate;
            }
            set
            {
                _DueDate = value;
            }
        }
        private DateTime _NoticeDate = DateTime.Parse("1900/1/1");
        /// <summary>  
        /// 本所通知日
        /// </summary>  
        public DateTime NoticeDate
        {
            get
            {
                return _NoticeDate;
            }
            set
            {
                _NoticeDate = value;
            }
        }
        private DateTime _AttorneyDueDate = DateTime.Parse("1900/1/1");
        /// <summary>  
        /// 本所期限
        /// </summary>  
        public DateTime AttorneyDueDate
        {
            get
            {
                return _AttorneyDueDate;
            }
            set
            {
                _AttorneyDueDate = value;
            }
        }
        private DateTime _CustomerAuthorizationDate = DateTime.Parse("1900/1/1");
        /// <summary>  
        /// 客戶委託日
        /// </summary>  
        public DateTime CustomerAuthorizationDate
        {
            get
            {
                return _CustomerAuthorizationDate;
            }
            set
            {
                _CustomerAuthorizationDate = value;
            }
        }
        private DateTime _OutsourcingDate = DateTime.Parse("1900/1/1");
        /// <summary>  
        /// 所外委辦日
        /// </summary>  
        public DateTime OutsourcingDate
        {
            get
            {
                return _OutsourcingDate;
            }
            set
            {
                _OutsourcingDate = value;
            }
        }
        private DateTime _FinishDate = DateTime.Parse("1900/1/1");
        /// <summary>  
        /// 完成日期
        /// </summary>  
        public DateTime FinishDate
        {
            get
            {
                return _FinishDate;
            }
            set
            {
                _FinishDate = value;
            }
        }
        private string _Result = "";
        /// <summary>  
        /// 處理結果
        /// </summary>  
        public String Result
        {
            get
            {
                return _Result;
            }
            set
            {
                _Result = value;
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
        /// 取得TrademarkControversyNotifyEventT資料集
        /// </summary>
        public DataTable GetDataTable()
        {
            return dt;
        }

        /// <summary>
        /// 設定TrademarkControversyNotifyEventT資料集
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
            string strSQL = "select count(" + ColumnName + ") as CountValue from TrademarkControversyNotifyEventT where " + ColumnName + "='" + Value + "'";
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
            string strSQL = "select count(" + ColumnName + ") as CountValue from TrademarkControversyNotifyEventT where " + ColumnName + "=" + Value;
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
                this.TMNotifyControversyEventID = dr["TMNotifyControversyEventID"].ToString() == "" ? -1 : (int)dr["TMNotifyControversyEventID"];
                this.TrademarkControversyID = dr["TrademarkControversyID"].ToString() == "" ? -1 : (int)dr["TrademarkControversyID"];
                this.NotifyEventContent = dr["NotifyEventContent"].ToString();
                this.EventType = dr["EventType"].ToString();
                this.TMStatusID = dr["TMStatusID"].ToString() == "" ? -1 : (int)dr["TMStatusID"];
                this.NotifyComitDate = dr["NotifyComitDate"].ToString() == "" ? DateTime.Parse("1900/1/1") : (DateTime)dr["NotifyComitDate"];
                this.WorkerKey = dr["WorkerKey"].ToString() == "" ? -1 : (int)dr["WorkerKey"];
                this.OccurDate = dr["OccurDate"].ToString() == "" ? DateTime.Parse("1900/1/1") : (DateTime)dr["OccurDate"];
                this.NotifyOfficerDate = dr["NotifyOfficerDate"].ToString() == "" ? DateTime.Parse("1900/1/1") : (DateTime)dr["NotifyOfficerDate"];
                this.DueDate = dr["DueDate"].ToString() == "" ? DateTime.Parse("1900/1/1") : (DateTime)dr["DueDate"];
                this.NoticeDate = dr["NoticeDate"].ToString() == "" ? DateTime.Parse("1900/1/1") : (DateTime)dr["NoticeDate"];
                this.AttorneyDueDate = dr["AttorneyDueDate"].ToString() == "" ? DateTime.Parse("1900/1/1") : (DateTime)dr["AttorneyDueDate"];
                this.CustomerAuthorizationDate = dr["CustomerAuthorizationDate"].ToString() == "" ? DateTime.Parse("1900/1/1") : (DateTime)dr["CustomerAuthorizationDate"];
                this.OutsourcingDate = dr["OutsourcingDate"].ToString() == "" ? DateTime.Parse("1900/1/1") : (DateTime)dr["OutsourcingDate"];
                this.FinishDate = dr["FinishDate"].ToString() == "" ? DateTime.Parse("1900/1/1") : (DateTime)dr["FinishDate"];
                this.Result = dr["Result"].ToString();
                this.Remark = dr["Remark"].ToString();
                this.LastModifyDate = dr["LastModifyDate"].ToString() == "" ? DateTime.Parse("1900/1/1") : (DateTime)dr["LastModifyDate"];
                this.UpbuildDay = dr["UpbuildDay"].ToString() == "" ? DateTime.Parse("1900/1/1") : (DateTime)dr["UpbuildDay"];
                this.LastModifyWorker = dr["LastModifyWorker"].ToString() == "" ? -1 : (int)dr["LastModifyWorker"];
                this.Locker = dr["Locker"].ToString() == "" ? -1 : (int)dr["Locker"];
            }
            catch
            {
                throw (new System.Exception("TrademarkControversyNotifyEventT該筆資料有誤：" + NO.ToString()));
            }
        }
        public void Insert()
        {
            try
            {
                Object Rownull = System.DBNull.Value;
                DataRow dr = dt.NewRow();
                dr["TrademarkControversyID"] = this.TrademarkControversyID == -1 ? Rownull : this.TrademarkControversyID;
                dr["NotifyEventContent"] = this.NotifyEventContent == "" ? Rownull : this.NotifyEventContent;
                dr["EventType"] = this.EventType == "" ? Rownull : this.EventType;
                dr["TMStatusID"] = this.TMStatusID == -1 ? Rownull : this.TMStatusID;
                dr["NotifyComitDate"] = this.NotifyComitDate.ToShortDateString() == "1900/1/1" ? Rownull : this.NotifyComitDate;
                dr["WorkerKey"] = this.WorkerKey == -1 ? Rownull : this.WorkerKey;
                dr["OccurDate"] = this.OccurDate.ToShortDateString() == "1900/1/1" ? Rownull : this.OccurDate;
                dr["NotifyOfficerDate"] = this.NotifyOfficerDate.ToShortDateString() == "1900/1/1" ? Rownull : this.NotifyOfficerDate;
                dr["DueDate"] = this.DueDate.ToShortDateString() == "1900/1/1" ? Rownull : this.DueDate;
                dr["NoticeDate"] = this.NoticeDate.ToShortDateString() == "1900/1/1" ? Rownull : this.NoticeDate;
                dr["AttorneyDueDate"] = this.AttorneyDueDate.ToShortDateString() == "1900/1/1" ? Rownull : this.AttorneyDueDate;
                dr["CustomerAuthorizationDate"] = this.CustomerAuthorizationDate.ToShortDateString() == "1900/1/1" ? Rownull : this.CustomerAuthorizationDate;
                dr["OutsourcingDate"] = this.OutsourcingDate.ToShortDateString() == "1900/1/1" ? Rownull : this.OutsourcingDate;
                dr["FinishDate"] = this.FinishDate.ToShortDateString() == "1900/1/1" ? Rownull : this.FinishDate;
                dr["Result"] = this.Result == "" ? Rownull : this.Result;
                dr["Remark"] = this.Remark == "" ? Rownull : this.Remark;
                dr["LastModifyDate"] = this.LastModifyDate.ToShortDateString() == "1900/1/1" ? Rownull : this.LastModifyDate;
                dr["UpbuildDay"] = this.UpbuildDay.ToShortDateString() == "1900/1/1" ? Rownull : this.UpbuildDay;
                dr["LastModifyWorker"] = this.LastModifyWorker == -1 ? Rownull : this.LastModifyWorker;
                dr["Locker"] = this.Locker == -1 ? Rownull : this.Locker;
                sAdapter.InsertCommand.Parameters["@TrademarkControversyID"].Value = dr["TrademarkControversyID"];
                sAdapter.InsertCommand.Parameters["@NotifyEventContent"].Value = dr["NotifyEventContent"];
                sAdapter.InsertCommand.Parameters["@EventType"].Value = dr["EventType"];
                sAdapter.InsertCommand.Parameters["@TMStatusID"].Value = dr["TMStatusID"];
                sAdapter.InsertCommand.Parameters["@NotifyComitDate"].Value = dr["NotifyComitDate"];
                sAdapter.InsertCommand.Parameters["@WorkerKey"].Value = dr["WorkerKey"];
                sAdapter.InsertCommand.Parameters["@OccurDate"].Value = dr["OccurDate"];
                sAdapter.InsertCommand.Parameters["@NotifyOfficerDate"].Value = dr["NotifyOfficerDate"];
                sAdapter.InsertCommand.Parameters["@DueDate"].Value = dr["DueDate"];
                sAdapter.InsertCommand.Parameters["@NoticeDate"].Value = dr["NoticeDate"];
                sAdapter.InsertCommand.Parameters["@AttorneyDueDate"].Value = dr["AttorneyDueDate"];
                sAdapter.InsertCommand.Parameters["@CustomerAuthorizationDate"].Value = dr["CustomerAuthorizationDate"];
                sAdapter.InsertCommand.Parameters["@OutsourcingDate"].Value = dr["OutsourcingDate"];
                sAdapter.InsertCommand.Parameters["@FinishDate"].Value = dr["FinishDate"];
                sAdapter.InsertCommand.Parameters["@Result"].Value = dr["Result"];
                sAdapter.InsertCommand.Parameters["@Remark"].Value = dr["Remark"];
                sAdapter.InsertCommand.Parameters["@LastModifyDate"].Value = dr["LastModifyDate"];
                sAdapter.InsertCommand.Parameters["@UpbuildDay"].Value = dr["UpbuildDay"];
                sAdapter.InsertCommand.Parameters["@LastModifyWorker"].Value = dr["LastModifyWorker"];
                sAdapter.InsertCommand.Parameters["@Locker"].Value = dr["Locker"];
                conn.Open();
                string KEY = sAdapter.InsertCommand.ExecuteScalar().ToString();
                conn.Close();
                if (KEY != "")
                {
                    this.TMNotifyControversyEventID = int.Parse(KEY);
                    dr["TMNotifyControversyEventID"] = this.TMNotifyControversyEventID;
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
                dr["NotifyEventContent"] = this.NotifyEventContent == "" ? Rownull : this.NotifyEventContent;
                dr["EventType"] = this.EventType == "" ? Rownull : this.EventType;
                dr["TMStatusID"] = this.TMStatusID == -1 ? Rownull : this.TMStatusID;
                dr["NotifyComitDate"] = this.NotifyComitDate.ToShortDateString() == "1900/1/1" ? Rownull : this.NotifyComitDate;
                dr["WorkerKey"] = this.WorkerKey == -1 ? Rownull : this.WorkerKey;
                dr["OccurDate"] = this.OccurDate.ToShortDateString() == "1900/1/1" ? Rownull : this.OccurDate;
                dr["NotifyOfficerDate"] = this.NotifyOfficerDate.ToShortDateString() == "1900/1/1" ? Rownull : this.NotifyOfficerDate;
                dr["DueDate"] = this.DueDate.ToShortDateString() == "1900/1/1" ? Rownull : this.DueDate;
                dr["NoticeDate"] = this.NoticeDate.ToShortDateString() == "1900/1/1" ? Rownull : this.NoticeDate;
                dr["AttorneyDueDate"] = this.AttorneyDueDate.ToShortDateString() == "1900/1/1" ? Rownull : this.AttorneyDueDate;
                dr["CustomerAuthorizationDate"] = this.CustomerAuthorizationDate.ToShortDateString() == "1900/1/1" ? Rownull : this.CustomerAuthorizationDate;
                dr["OutsourcingDate"] = this.OutsourcingDate.ToShortDateString() == "1900/1/1" ? Rownull : this.OutsourcingDate;
                dr["FinishDate"] = this.FinishDate.ToShortDateString() == "1900/1/1" ? Rownull : this.FinishDate;
                dr["Result"] = this.Result == "" ? Rownull : this.Result;
                dr["Remark"] = this.Remark == "" ? Rownull : this.Remark;
                dr["LastModifyDate"] = this.LastModifyDate.ToShortDateString() == "1900/1/1" ? Rownull : this.LastModifyDate;
                dr["UpbuildDay"] = this.UpbuildDay.ToShortDateString() == "1900/1/1" ? Rownull : this.UpbuildDay;
                dr["LastModifyWorker"] = this.LastModifyWorker == -1 ? Rownull : this.LastModifyWorker;
                dr["Locker"] = this.Locker == -1 ? Rownull : this.Locker;
                sAdapter.UpdateCommand.Parameters.Clear();
                sAdapter.UpdateCommand.Parameters.Add("TMNotifyControversyEventID", SqlDbType.Int);
                sAdapter.UpdateCommand.Parameters["TMNotifyControversyEventID"].Value = dr["TMNotifyControversyEventID"];
                sAdapter.UpdateCommand.Parameters.Add("TrademarkControversyID", SqlDbType.Int);
                sAdapter.UpdateCommand.Parameters["TrademarkControversyID"].Value = dr["TrademarkControversyID"];
                sAdapter.UpdateCommand.Parameters.Add("NotifyEventContent", SqlDbType.NVarChar);
                sAdapter.UpdateCommand.Parameters["NotifyEventContent"].Value = dr["NotifyEventContent"];
                sAdapter.UpdateCommand.Parameters.Add("EventType", SqlDbType.NVarChar);
                sAdapter.UpdateCommand.Parameters["EventType"].Value = dr["EventType"];
                sAdapter.UpdateCommand.Parameters.Add("TMStatusID", SqlDbType.Int);
                sAdapter.UpdateCommand.Parameters["TMStatusID"].Value = dr["TMStatusID"];
                sAdapter.UpdateCommand.Parameters.Add("NotifyComitDate", SqlDbType.DateTime);
                sAdapter.UpdateCommand.Parameters["NotifyComitDate"].Value = dr["NotifyComitDate"];
                sAdapter.UpdateCommand.Parameters.Add("WorkerKey", SqlDbType.Int);
                sAdapter.UpdateCommand.Parameters["WorkerKey"].Value = dr["WorkerKey"];
                sAdapter.UpdateCommand.Parameters.Add("OccurDate", SqlDbType.DateTime);
                sAdapter.UpdateCommand.Parameters["OccurDate"].Value = dr["OccurDate"];
                sAdapter.UpdateCommand.Parameters.Add("NotifyOfficerDate", SqlDbType.DateTime);
                sAdapter.UpdateCommand.Parameters["NotifyOfficerDate"].Value = dr["NotifyOfficerDate"];
                sAdapter.UpdateCommand.Parameters.Add("DueDate", SqlDbType.DateTime);
                sAdapter.UpdateCommand.Parameters["DueDate"].Value = dr["DueDate"];
                sAdapter.UpdateCommand.Parameters.Add("NoticeDate", SqlDbType.DateTime);
                sAdapter.UpdateCommand.Parameters["NoticeDate"].Value = dr["NoticeDate"];
                sAdapter.UpdateCommand.Parameters.Add("AttorneyDueDate", SqlDbType.DateTime);
                sAdapter.UpdateCommand.Parameters["AttorneyDueDate"].Value = dr["AttorneyDueDate"];
                sAdapter.UpdateCommand.Parameters.Add("CustomerAuthorizationDate", SqlDbType.DateTime);
                sAdapter.UpdateCommand.Parameters["CustomerAuthorizationDate"].Value = dr["CustomerAuthorizationDate"];
                sAdapter.UpdateCommand.Parameters.Add("OutsourcingDate", SqlDbType.DateTime);
                sAdapter.UpdateCommand.Parameters["OutsourcingDate"].Value = dr["OutsourcingDate"];
                sAdapter.UpdateCommand.Parameters.Add("FinishDate", SqlDbType.DateTime);
                sAdapter.UpdateCommand.Parameters["FinishDate"].Value = dr["FinishDate"];
                sAdapter.UpdateCommand.Parameters.Add("Result", SqlDbType.NVarChar);
                sAdapter.UpdateCommand.Parameters["Result"].Value = dr["Result"];
                sAdapter.UpdateCommand.Parameters.Add("Remark", SqlDbType.NVarChar);
                sAdapter.UpdateCommand.Parameters["Remark"].Value = dr["Remark"];
                sAdapter.UpdateCommand.Parameters.Add("LastModifyDate", SqlDbType.DateTime);
                sAdapter.UpdateCommand.Parameters["LastModifyDate"].Value = dr["LastModifyDate"];
                sAdapter.UpdateCommand.Parameters.Add("UpbuildDay", SqlDbType.DateTime);
                sAdapter.UpdateCommand.Parameters["UpbuildDay"].Value = dr["UpbuildDay"];
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
                StringBuilder delString = new StringBuilder("DELETE FROM TrademarkControversyNotifyEventT where " + strSQLWhere);
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
                StringBuilder delString = new StringBuilder("DELETE FROM TrademarkControversyNotifyEventT where TMNotifyControversyEventID=@TMNotifyControversyEventID ");
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
