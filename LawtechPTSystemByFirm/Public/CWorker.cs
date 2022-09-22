using System;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using H3Operator.DBHelper;

namespace LawtechPTSystemByFirm.Public
{
    #region ======CWorker======
    public class CWorker1
    {
        SqlConnection conn = new SqlConnection(DBAccess.ConnectionListDefaultConnectionString);
        SqlDataAdapter sAdapter;
        SqlCommandBuilder CBuilder;

        DataTable dt;
        /// <summary>
        /// 預設帶出所有的資料
        /// </summary>
        public CWorker1()
        {
            sAdapter = new SqlDataAdapter("select * from WorkerT", conn);
            dt = new DataTable();
            //DataSet ds = new DataSet();
            //ds.Tables.Add(dt);
            sAdapter.FillSchema(dt, SchemaType.Source);
            sAdapter.Fill(dt);
            CBuilder = new SqlCommandBuilder(sAdapter);
            sAdapter.InsertCommand = CBuilder.GetInsertCommand(true);
            sAdapter.InsertCommand.UpdatedRowSource = UpdateRowSource.Both;
            sAdapter.InsertCommand.CommandText += " Select @@IDENTITY AS 'IDENTITY'";
            sAdapter.UpdateCommand = new SqlCommand(@"UPDATE WorkerT  SET 
                                                       WorkerSymbol=@WorkerSymbol,
                                                       EmployeeName=@EmployeeName,
                                                       EmployeeNameEn=@EmployeeNameEn,
                                                       Ext=@Ext,
                                                       Account=@Account,
                                                       Password=@Password,
                                                       Email=@Email,
                                                       TEL=@TEL,
                                                       EmployeeID=@EmployeeID,
                                                       Birthday=@Birthday,
                                                       ReachDay=@ReachDay,
                                                       DepartDay=@DepartDay,
                                                       Urgent=@Urgent,
                                                       EverAddr=@EverAddr,
                                                       Addr=@Addr,
                                                       Mobilephone=@Mobilephone,
                                                       Remark=@Remark,
                                                       IsQuit=@IsQuit,
                                                       FullDeptName=@FullDeptName,
                                                       FullDeptKEY=@FullDeptKEY,
                                                       Position=@Position,
                                                       Background=@Background,
                                                       Experience=@Experience,
                                                       OfficeRole=@OfficeRole,
                                                       SingCode=@SingCode,
                                                       WorkScope=@WorkScope,
                                                       Specialty=@Specialty,
                                                       Creator=@Creator,
                                                       CreateDateTime=@CreateDateTime,
                                                       LastModifyWorker=@LastModifyWorker,
                                                       LastModifyDateTime=@LastModifyDateTime,
                                                       LogicDeleteDateTime=@LogicDeleteDateTime,
                                                       IsLogicDelete=@IsLogicDelete,
                                                       LockedWorker=@LockedWorker
                                                   where 
                                                       WorkerKey=@WorkerKey", conn);
        }
        /// <summary>
        /// 有條件的過濾資料
        /// </summary>
        /// <param name="sWhere">SQL的條件式</param>
        public CWorker1(string sWhere)
        {
            sAdapter = new SqlDataAdapter("select * from WorkerT where " + sWhere, conn);
            dt = new DataTable();
            //DataSet ds = new DataSet();
            //ds.Tables.Add(dt);
            sAdapter.FillSchema(dt, SchemaType.Source);
            sAdapter.Fill(dt);
            CBuilder = new SqlCommandBuilder(sAdapter);
            sAdapter.InsertCommand = CBuilder.GetInsertCommand(true);
            sAdapter.InsertCommand.UpdatedRowSource = UpdateRowSource.Both;
            sAdapter.InsertCommand.CommandText += " Select @@IDENTITY AS 'IDENTITY'";
            sAdapter.UpdateCommand = new SqlCommand(@"UPDATE WorkerT  SET 
                                                       WorkerSymbol=@WorkerSymbol,
                                                       EmployeeName=@EmployeeName,
                                                       EmployeeNameEn=@EmployeeNameEn,
                                                       Ext=@Ext,
                                                       Account=@Account,
                                                       Password=@Password,
                                                       Email=@Email,
                                                       TEL=@TEL,
                                                       EmployeeID=@EmployeeID,
                                                       Birthday=@Birthday,
                                                       ReachDay=@ReachDay,
                                                       DepartDay=@DepartDay,
                                                       Urgent=@Urgent,
                                                       EverAddr=@EverAddr,
                                                       Addr=@Addr,
                                                       Mobilephone=@Mobilephone,
                                                       Remark=@Remark,
                                                       IsQuit=@IsQuit,
                                                       FullDeptName=@FullDeptName,
                                                       FullDeptKEY=@FullDeptKEY,
                                                       Position=@Position,
                                                       Background=@Background,
                                                       Experience=@Experience,
                                                       OfficeRole=@OfficeRole,
                                                       SingCode=@SingCode,
                                                       WorkScope=@WorkScope,
                                                       Specialty=@Specialty,
                                                       Creator=@Creator,
                                                       CreateDateTime=@CreateDateTime,
                                                       LastModifyWorker=@LastModifyWorker,
                                                       LastModifyDateTime=@LastModifyDateTime,
                                                       LogicDeleteDateTime=@LogicDeleteDateTime,
                                                       IsLogicDelete=@IsLogicDelete,
                                                       LockedWorker=@LockedWorker
                                                   where 
                                                       WorkerKey=@WorkerKey", conn);
        }


        private int _WorkerKey = -1;
        /// <summary>  
        /// 
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
        private string _WorkerSymbol = "";
        /// <summary>  
        /// 員工編號
        /// </summary>  
        public String WorkerSymbol
        {
            get
            {
                return _WorkerSymbol;
            }
            set
            {
                _WorkerSymbol = value;
            }
        }
        private string _EmployeeName = "";
        /// <summary>  
        /// 姓名
        /// </summary>  
        public String EmployeeName
        {
            get
            {
                return _EmployeeName;
            }
            set
            {
                _EmployeeName = value;
            }
        }
        private string _EmployeeNameEn = "";
        /// <summary>  
        /// 英文名
        /// </summary>  
        public String EmployeeNameEn
        {
            get
            {
                return _EmployeeNameEn;
            }
            set
            {
                _EmployeeNameEn = value;
            }
        }
        private string _Ext = "";
        /// <summary>  
        /// 分機
        /// </summary>  
        public String Ext
        {
            get
            {
                return _Ext;
            }
            set
            {
                _Ext = value;
            }
        }
        private string _Account = "";
        /// <summary>  
        /// 登入帳號
        /// </summary>  
        public String Account
        {
            get
            {
                return _Account;
            }
            set
            {
                _Account = value;
            }
        }
        private string _Password = "";
        /// <summary>  
        /// 
        /// </summary>  
        public String Password
        {
            get
            {
                return _Password;
            }
            set
            {
                _Password = value;
            }
        }
        private string _Email = "";
        /// <summary>  
        /// 電子信箱
        /// </summary>  
        public String Email
        {
            get
            {
                return _Email;
            }
            set
            {
                _Email = value;
            }
        }
        private string _TEL = "";
        /// <summary>  
        /// 電話
        /// </summary>  
        public String TEL
        {
            get
            {
                return _TEL;
            }
            set
            {
                _TEL = value;
            }
        }
        private string _EmployeeID = "";
        /// <summary>  
        /// 身份證字號
        /// </summary>  
        public String EmployeeID
        {
            get
            {
                return _EmployeeID;
            }
            set
            {
                _EmployeeID = value;
            }
        }
        private DateTime _Birthday = DateTime.Parse("1900/1/1");
        /// <summary>  
        /// 生日
        /// </summary>  
        public DateTime Birthday
        {
            get
            {
                return _Birthday;
            }
            set
            {
                _Birthday = value;
            }
        }
        private DateTime _ReachDay = DateTime.Parse("1900/1/1");
        /// <summary>  
        /// 到職日
        /// </summary>  
        public DateTime ReachDay
        {
            get
            {
                return _ReachDay;
            }
            set
            {
                _ReachDay = value;
            }
        }
        private DateTime _DepartDay = DateTime.Parse("1900/1/1");
        /// <summary>  
        /// 離職日
        /// </summary>  
        public DateTime DepartDay
        {
            get
            {
                return _DepartDay;
            }
            set
            {
                _DepartDay = value;
            }
        }
        private string _Urgent = "";
        /// <summary>  
        /// 緊急聯絡人
        /// </summary>  
        public String Urgent
        {
            get
            {
                return _Urgent;
            }
            set
            {
                _Urgent = value;
            }
        }
        private string _EverAddr = "";
        /// <summary>  
        /// 
        /// </summary>  
        public String EverAddr
        {
            get
            {
                return _EverAddr;
            }
            set
            {
                _EverAddr = value;
            }
        }
        private string _Addr = "";
        /// <summary>  
        /// 地址
        /// </summary>  
        public String Addr
        {
            get
            {
                return _Addr;
            }
            set
            {
                _Addr = value;
            }
        }
        private string _Mobilephone = "";
        /// <summary>  
        /// 行動電話
        /// </summary>  
        public String Mobilephone
        {
            get
            {
                return _Mobilephone;
            }
            set
            {
                _Mobilephone = value;
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
        private bool _IsQuit = false;
        /// <summary>  
        /// 是否離職 true-離職  false-在職
        /// </summary>  
        public bool IsQuit
        {
            get
            {
                return _IsQuit;
            }
            set
            {
                _IsQuit = value;
            }
        }
        private string _FullDeptName = "";
        /// <summary>  
        /// 
        /// </summary>  
        public String FullDeptName
        {
            get
            {
                return _FullDeptName;
            }
            set
            {
                _FullDeptName = value;
            }
        }
        private string _FullDeptKEY = "";
        /// <summary>  
        /// 
        /// </summary>  
        public String FullDeptKEY
        {
            get
            {
                return _FullDeptKEY;
            }
            set
            {
                _FullDeptKEY = value;
            }
        }
        private string _Position = "";
        /// <summary>  
        /// 
        /// </summary>  
        public String Position
        {
            get
            {
                return _Position;
            }
            set
            {
                _Position = value;
            }
        }
        private string _Background = "";
        /// <summary>  
        /// 
        /// </summary>  
        public String Background
        {
            get
            {
                return _Background;
            }
            set
            {
                _Background = value;
            }
        }
        private string _Experience = "";
        /// <summary>  
        /// 
        /// </summary>  
        public String Experience
        {
            get
            {
                return _Experience;
            }
            set
            {
                _Experience = value;
            }
        }
        private int _OfficeRole = -1;
        /// <summary>  
        /// 
        /// </summary>  
        public int OfficeRole
        {
            get
            {
                return _OfficeRole;
            }
            set
            {
                _OfficeRole = value;
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
        private string _WorkScope = "";
        /// <summary>  
        /// 
        /// </summary>  
        public String WorkScope
        {
            get
            {
                return _WorkScope;
            }
            set
            {
                _WorkScope = value;
            }
        }
        private string _Specialty = "";
        /// <summary>  
        /// 
        /// </summary>  
        public String Specialty
        {
            get
            {
                return _Specialty;
            }
            set
            {
                _Specialty = value;
            }
        }
        private int _Creator = -1;
        /// <summary>  
        /// 
        /// </summary>  
        public int Creator
        {
            get
            {
                return _Creator;
            }
            set
            {
                _Creator = value;
            }
        }
        private DateTime _CreateDateTime = DateTime.Parse("1900/1/1");
        /// <summary>  
        /// 
        /// </summary>  
        public DateTime CreateDateTime
        {
            get
            {
                return _CreateDateTime;
            }
            set
            {
                _CreateDateTime = value;
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
        private DateTime _LastModifyDateTime = DateTime.Parse("1900/1/1");
        /// <summary>  
        /// 
        /// </summary>  
        public DateTime LastModifyDateTime
        {
            get
            {
                return _LastModifyDateTime;
            }
            set
            {
                _LastModifyDateTime = value;
            }
        }
        private DateTime _LogicDeleteDateTime = DateTime.Parse("1900/1/1");
        /// <summary>  
        /// 
        /// </summary>  
        public DateTime LogicDeleteDateTime
        {
            get
            {
                return _LogicDeleteDateTime;
            }
            set
            {
                _LogicDeleteDateTime = value;
            }
        }
        private bool _IsLogicDelete = false;
        /// <summary>  
        /// 
        /// </summary>  
        public bool IsLogicDelete
        {
            get
            {
                return _IsLogicDelete;
            }
            set
            {
                _IsLogicDelete = value;
            }
        }
        private int _LockedWorker = -1;
        /// <summary>  
        /// 
        /// </summary>  
        public int LockedWorker
        {
            get
            {
                return _LockedWorker;
            }
            set
            {
                _LockedWorker = value;
            }
        }

        /// <summary>
        /// 取得WorkerT資料集
        /// </summary>
        public DataTable GetDataTable()
        {
            return dt;
        }

        /// <summary>
        /// 設定WorkerT資料集
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
            string strSQL = "select count(" + ColumnName + ") as CountValue from WorkerT where " + ColumnName + "='" + Value + "'";
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
            string strSQL = "select count(" + ColumnName + ") as CountValue from WorkerT where " + ColumnName + "=" + Value;
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
                this.WorkerKey = dr["WorkerKey"].ToString() == "" ? -1 : (int)dr["WorkerKey"];
                this.WorkerSymbol = dr["WorkerSymbol"].ToString();
                this.EmployeeName = dr["EmployeeName"].ToString();
                this.EmployeeNameEn = dr["EmployeeNameEn"].ToString();
                this.Ext = dr["Ext"].ToString();
                this.Account = dr["Account"].ToString();
                this.Password = dr["Password"].ToString();
                this.Email = dr["Email"].ToString();
                this.TEL = dr["TEL"].ToString();
                this.EmployeeID = dr["EmployeeID"].ToString();
                this.Birthday = dr["Birthday"].ToString() == "" ? DateTime.Parse("1900/1/1") : (DateTime)dr["Birthday"];
                this.ReachDay = dr["ReachDay"].ToString() == "" ? DateTime.Parse("1900/1/1") : (DateTime)dr["ReachDay"];
                this.DepartDay = dr["DepartDay"].ToString() == "" ? DateTime.Parse("1900/1/1") : (DateTime)dr["DepartDay"];
                this.Urgent = dr["Urgent"].ToString();
                this.EverAddr = dr["EverAddr"].ToString();
                this.Addr = dr["Addr"].ToString();
                this.Mobilephone = dr["Mobilephone"].ToString();
                this.Remark = dr["Remark"].ToString();
                this.IsQuit = dr["IsQuit"].ToString() == "" ? false : (bool)dr["IsQuit"];
                this.FullDeptName = dr["FullDeptName"].ToString();
                this.FullDeptKEY = dr["FullDeptKEY"].ToString();
                this.Position = dr["Position"].ToString();
                this.Background = dr["Background"].ToString();
                this.Experience = dr["Experience"].ToString();
                this.OfficeRole = dr["OfficeRole"].ToString() == "" ? -1 : (int)dr["OfficeRole"];
                this.SingCode = dr["SingCode"].ToString();
                this.WorkScope = dr["WorkScope"].ToString();
                this.Specialty = dr["Specialty"].ToString();
                this.Creator = dr["Creator"].ToString() == "" ? -1 : (int)dr["Creator"];
                this.CreateDateTime = dr["CreateDateTime"].ToString() == "" ? DateTime.Parse("1900/1/1") : (DateTime)dr["CreateDateTime"];
                this.LastModifyWorker = dr["LastModifyWorker"].ToString() == "" ? -1 : (int)dr["LastModifyWorker"];
                this.LastModifyDateTime = dr["LastModifyDateTime"].ToString() == "" ? DateTime.Parse("1900/1/1") : (DateTime)dr["LastModifyDateTime"];
                this.LogicDeleteDateTime = dr["LogicDeleteDateTime"].ToString() == "" ? DateTime.Parse("1900/1/1") : (DateTime)dr["LogicDeleteDateTime"];
                this.IsLogicDelete = dr["IsLogicDelete"].ToString() == "" ? false : (bool)dr["IsLogicDelete"];
                this.LockedWorker = dr["LockedWorker"].ToString() == "" ? -1 : (int)dr["LockedWorker"];
            }
            catch
            {
                throw (new System.Exception("WorkerT該筆資料有誤：" + NO.ToString()));
            }
        }
        public void Insert()
        {
            try
            {
                Object Rownull = System.DBNull.Value;
                DataRow dr = dt.NewRow();
                dr["WorkerSymbol"] = this.WorkerSymbol == "" ? Rownull : this.WorkerSymbol;
                dr["EmployeeName"] = this.EmployeeName == "" ? Rownull : this.EmployeeName;
                dr["EmployeeNameEn"] = this.EmployeeNameEn == "" ? Rownull : this.EmployeeNameEn;
                dr["Ext"] = this.Ext == "" ? Rownull : this.Ext;
                dr["Account"] = this.Account == "" ? Rownull : this.Account;
                dr["Password"] = this.Password == "" ? Rownull : this.Password;
                dr["Email"] = this.Email == "" ? Rownull : this.Email;
                dr["TEL"] = this.TEL == "" ? Rownull : this.TEL;
                dr["EmployeeID"] = this.EmployeeID == "" ? Rownull : this.EmployeeID;
                dr["Birthday"] = this.Birthday.ToShortDateString() == "1900/1/1" ? Rownull : this.Birthday;
                dr["ReachDay"] = this.ReachDay.ToShortDateString() == "1900/1/1" ? Rownull : this.ReachDay;
                dr["DepartDay"] = this.DepartDay.ToShortDateString() == "1900/1/1" ? Rownull : this.DepartDay;
                dr["Urgent"] = this.Urgent == "" ? Rownull : this.Urgent;
                dr["EverAddr"] = this.EverAddr == "" ? Rownull : this.EverAddr;
                dr["Addr"] = this.Addr == "" ? Rownull : this.Addr;
                dr["Mobilephone"] = this.Mobilephone == "" ? Rownull : this.Mobilephone;
                dr["Remark"] = this.Remark == "" ? Rownull : this.Remark;
                dr["IsQuit"] = this.IsQuit;
                dr["FullDeptName"] = this.FullDeptName == "" ? Rownull : this.FullDeptName;
                dr["FullDeptKEY"] = this.FullDeptKEY == "" ? Rownull : this.FullDeptKEY;
                dr["Position"] = this.Position == "" ? Rownull : this.Position;
                dr["Background"] = this.Background == "" ? Rownull : this.Background;
                dr["Experience"] = this.Experience == "" ? Rownull : this.Experience;
                dr["OfficeRole"] = this.OfficeRole == -1 ? Rownull : this.OfficeRole;
                dr["SingCode"] = this.SingCode == "" ? Rownull : this.SingCode;
                dr["WorkScope"] = this.WorkScope == "" ? Rownull : this.WorkScope;
                dr["Specialty"] = this.Specialty == "" ? Rownull : this.Specialty;
                dr["Creator"] = this.Creator == -1 ? Rownull : this.Creator;
                dr["CreateDateTime"] = this.CreateDateTime.ToShortDateString() == "1900/1/1" ? Rownull : this.CreateDateTime;
                dr["LastModifyWorker"] = this.LastModifyWorker == -1 ? Rownull : this.LastModifyWorker;
                dr["LastModifyDateTime"] = this.LastModifyDateTime.ToShortDateString() == "1900/1/1" ? Rownull : this.LastModifyDateTime;
                dr["LogicDeleteDateTime"] = this.LogicDeleteDateTime.ToShortDateString() == "1900/1/1" ? Rownull : this.LogicDeleteDateTime;
                dr["IsLogicDelete"] = this.IsLogicDelete;
                dr["LockedWorker"] = this.LockedWorker == -1 ? Rownull : this.LockedWorker;
                sAdapter.InsertCommand.Parameters["@WorkerSymbol"].Value = dr["WorkerSymbol"];
                sAdapter.InsertCommand.Parameters["@EmployeeName"].Value = dr["EmployeeName"];
                sAdapter.InsertCommand.Parameters["@EmployeeNameEn"].Value = dr["EmployeeNameEn"];
                sAdapter.InsertCommand.Parameters["@Ext"].Value = dr["Ext"];
                sAdapter.InsertCommand.Parameters["@Account"].Value = dr["Account"];
                sAdapter.InsertCommand.Parameters["@Password"].Value = dr["Password"];
                sAdapter.InsertCommand.Parameters["@Email"].Value = dr["Email"];
                sAdapter.InsertCommand.Parameters["@TEL"].Value = dr["TEL"];
                sAdapter.InsertCommand.Parameters["@EmployeeID"].Value = dr["EmployeeID"];
                sAdapter.InsertCommand.Parameters["@Birthday"].Value = dr["Birthday"];
                sAdapter.InsertCommand.Parameters["@ReachDay"].Value = dr["ReachDay"];
                sAdapter.InsertCommand.Parameters["@DepartDay"].Value = dr["DepartDay"];
                sAdapter.InsertCommand.Parameters["@Urgent"].Value = dr["Urgent"];
                sAdapter.InsertCommand.Parameters["@EverAddr"].Value = dr["EverAddr"];
                sAdapter.InsertCommand.Parameters["@Addr"].Value = dr["Addr"];
                sAdapter.InsertCommand.Parameters["@Mobilephone"].Value = dr["Mobilephone"];
                sAdapter.InsertCommand.Parameters["@Remark"].Value = dr["Remark"];
                sAdapter.InsertCommand.Parameters["@IsQuit"].Value = dr["IsQuit"];
                sAdapter.InsertCommand.Parameters["@FullDeptName"].Value = dr["FullDeptName"];
                sAdapter.InsertCommand.Parameters["@FullDeptKEY"].Value = dr["FullDeptKEY"];
                sAdapter.InsertCommand.Parameters["@Position"].Value = dr["Position"];
                sAdapter.InsertCommand.Parameters["@Background"].Value = dr["Background"];
                sAdapter.InsertCommand.Parameters["@Experience"].Value = dr["Experience"];
                sAdapter.InsertCommand.Parameters["@OfficeRole"].Value = dr["OfficeRole"];
                sAdapter.InsertCommand.Parameters["@SingCode"].Value = dr["SingCode"];
                sAdapter.InsertCommand.Parameters["@WorkScope"].Value = dr["WorkScope"];
                sAdapter.InsertCommand.Parameters["@Specialty"].Value = dr["Specialty"];
                sAdapter.InsertCommand.Parameters["@Creator"].Value = dr["Creator"];
                sAdapter.InsertCommand.Parameters["@CreateDateTime"].Value = dr["CreateDateTime"];
                sAdapter.InsertCommand.Parameters["@LastModifyWorker"].Value = dr["LastModifyWorker"];
                sAdapter.InsertCommand.Parameters["@LastModifyDateTime"].Value = dr["LastModifyDateTime"];
                sAdapter.InsertCommand.Parameters["@LogicDeleteDateTime"].Value = dr["LogicDeleteDateTime"];
                sAdapter.InsertCommand.Parameters["@IsLogicDelete"].Value = dr["IsLogicDelete"];
                sAdapter.InsertCommand.Parameters["@LockedWorker"].Value = dr["LockedWorker"];
                conn.Open();
                string KEY = sAdapter.InsertCommand.ExecuteScalar().ToString();
                conn.Close();
                if (KEY != "")
                {
                    this.WorkerKey = int.Parse(KEY);
                    dr["WorkerKey"] = this.WorkerKey;
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
                dr["WorkerSymbol"] = this.WorkerSymbol == "" ? Rownull : this.WorkerSymbol;
                dr["EmployeeName"] = this.EmployeeName == "" ? Rownull : this.EmployeeName;
                dr["EmployeeNameEn"] = this.EmployeeNameEn == "" ? Rownull : this.EmployeeNameEn;
                dr["Ext"] = this.Ext == "" ? Rownull : this.Ext;
                dr["Account"] = this.Account == "" ? Rownull : this.Account;
                dr["Password"] = this.Password == "" ? Rownull : this.Password;
                dr["Email"] = this.Email == "" ? Rownull : this.Email;
                dr["TEL"] = this.TEL == "" ? Rownull : this.TEL;
                dr["EmployeeID"] = this.EmployeeID == "" ? Rownull : this.EmployeeID;
                dr["Birthday"] = this.Birthday.ToShortDateString() == "1900/1/1" ? Rownull : this.Birthday;
                dr["ReachDay"] = this.ReachDay.ToShortDateString() == "1900/1/1" ? Rownull : this.ReachDay;
                dr["DepartDay"] = this.DepartDay.ToShortDateString() == "1900/1/1" ? Rownull : this.DepartDay;
                dr["Urgent"] = this.Urgent == "" ? Rownull : this.Urgent;
                dr["EverAddr"] = this.EverAddr == "" ? Rownull : this.EverAddr;
                dr["Addr"] = this.Addr == "" ? Rownull : this.Addr;
                dr["Mobilephone"] = this.Mobilephone == "" ? Rownull : this.Mobilephone;
                dr["Remark"] = this.Remark == "" ? Rownull : this.Remark;
                dr["IsQuit"] = this.IsQuit;
                dr["FullDeptName"] = this.FullDeptName == "" ? Rownull : this.FullDeptName;
                dr["FullDeptKEY"] = this.FullDeptKEY == "" ? Rownull : this.FullDeptKEY;
                dr["Position"] = this.Position == "" ? Rownull : this.Position;
                dr["Background"] = this.Background == "" ? Rownull : this.Background;
                dr["Experience"] = this.Experience == "" ? Rownull : this.Experience;
                dr["OfficeRole"] = this.OfficeRole == -1 ? Rownull : this.OfficeRole;
                dr["SingCode"] = this.SingCode == "" ? Rownull : this.SingCode;
                dr["WorkScope"] = this.WorkScope == "" ? Rownull : this.WorkScope;
                dr["Specialty"] = this.Specialty == "" ? Rownull : this.Specialty;
                dr["Creator"] = this.Creator == -1 ? Rownull : this.Creator;
                dr["CreateDateTime"] = this.CreateDateTime.ToShortDateString() == "1900/1/1" ? Rownull : this.CreateDateTime;
                dr["LastModifyWorker"] = this.LastModifyWorker == -1 ? Rownull : this.LastModifyWorker;
                dr["LastModifyDateTime"] = this.LastModifyDateTime.ToShortDateString() == "1900/1/1" ? Rownull : this.LastModifyDateTime;
                dr["LogicDeleteDateTime"] = this.LogicDeleteDateTime.ToShortDateString() == "1900/1/1" ? Rownull : this.LogicDeleteDateTime;
                dr["IsLogicDelete"] = this.IsLogicDelete;
                dr["LockedWorker"] = this.LockedWorker == -1 ? Rownull : this.LockedWorker;
                sAdapter.UpdateCommand.Parameters.Clear();
                sAdapter.UpdateCommand.Parameters.Add("WorkerKey", SqlDbType.Int);
                sAdapter.UpdateCommand.Parameters["WorkerKey"].Value = dr["WorkerKey"];
                sAdapter.UpdateCommand.Parameters.Add("WorkerSymbol", SqlDbType.NVarChar);
                sAdapter.UpdateCommand.Parameters["WorkerSymbol"].Value = dr["WorkerSymbol"];
                sAdapter.UpdateCommand.Parameters.Add("EmployeeName", SqlDbType.NVarChar);
                sAdapter.UpdateCommand.Parameters["EmployeeName"].Value = dr["EmployeeName"];
                sAdapter.UpdateCommand.Parameters.Add("EmployeeNameEn", SqlDbType.NVarChar);
                sAdapter.UpdateCommand.Parameters["EmployeeNameEn"].Value = dr["EmployeeNameEn"];
                sAdapter.UpdateCommand.Parameters.Add("Ext", SqlDbType.NVarChar);
                sAdapter.UpdateCommand.Parameters["Ext"].Value = dr["Ext"];
                sAdapter.UpdateCommand.Parameters.Add("Account", SqlDbType.NVarChar);
                sAdapter.UpdateCommand.Parameters["Account"].Value = dr["Account"];
                sAdapter.UpdateCommand.Parameters.Add("Password", SqlDbType.NVarChar);
                sAdapter.UpdateCommand.Parameters["Password"].Value = dr["Password"];
                sAdapter.UpdateCommand.Parameters.Add("Email", SqlDbType.NVarChar);
                sAdapter.UpdateCommand.Parameters["Email"].Value = dr["Email"];
                sAdapter.UpdateCommand.Parameters.Add("TEL", SqlDbType.NVarChar);
                sAdapter.UpdateCommand.Parameters["TEL"].Value = dr["TEL"];
                sAdapter.UpdateCommand.Parameters.Add("EmployeeID", SqlDbType.NVarChar);
                sAdapter.UpdateCommand.Parameters["EmployeeID"].Value = dr["EmployeeID"];
                sAdapter.UpdateCommand.Parameters.Add("Birthday", SqlDbType.SmallDateTime);
                sAdapter.UpdateCommand.Parameters["Birthday"].Value = dr["Birthday"];
                sAdapter.UpdateCommand.Parameters.Add("ReachDay", SqlDbType.SmallDateTime);
                sAdapter.UpdateCommand.Parameters["ReachDay"].Value = dr["ReachDay"];
                sAdapter.UpdateCommand.Parameters.Add("DepartDay", SqlDbType.SmallDateTime);
                sAdapter.UpdateCommand.Parameters["DepartDay"].Value = dr["DepartDay"];
                sAdapter.UpdateCommand.Parameters.Add("Urgent", SqlDbType.NVarChar);
                sAdapter.UpdateCommand.Parameters["Urgent"].Value = dr["Urgent"];
                sAdapter.UpdateCommand.Parameters.Add("EverAddr", SqlDbType.NVarChar);
                sAdapter.UpdateCommand.Parameters["EverAddr"].Value = dr["EverAddr"];
                sAdapter.UpdateCommand.Parameters.Add("Addr", SqlDbType.NVarChar);
                sAdapter.UpdateCommand.Parameters["Addr"].Value = dr["Addr"];
                sAdapter.UpdateCommand.Parameters.Add("Mobilephone", SqlDbType.NVarChar);
                sAdapter.UpdateCommand.Parameters["Mobilephone"].Value = dr["Mobilephone"];
                sAdapter.UpdateCommand.Parameters.Add("Remark", SqlDbType.NVarChar);
                sAdapter.UpdateCommand.Parameters["Remark"].Value = dr["Remark"];
                sAdapter.UpdateCommand.Parameters.Add("IsQuit", SqlDbType.Bit);
                sAdapter.UpdateCommand.Parameters["IsQuit"].Value = dr["IsQuit"];
                sAdapter.UpdateCommand.Parameters.Add("FullDeptName", SqlDbType.NVarChar);
                sAdapter.UpdateCommand.Parameters["FullDeptName"].Value = dr["FullDeptName"];
                sAdapter.UpdateCommand.Parameters.Add("FullDeptKEY", SqlDbType.NVarChar);
                sAdapter.UpdateCommand.Parameters["FullDeptKEY"].Value = dr["FullDeptKEY"];
                sAdapter.UpdateCommand.Parameters.Add("Position", SqlDbType.NVarChar);
                sAdapter.UpdateCommand.Parameters["Position"].Value = dr["Position"];
                sAdapter.UpdateCommand.Parameters.Add("Background", SqlDbType.NVarChar);
                sAdapter.UpdateCommand.Parameters["Background"].Value = dr["Background"];
                sAdapter.UpdateCommand.Parameters.Add("Experience", SqlDbType.NVarChar);
                sAdapter.UpdateCommand.Parameters["Experience"].Value = dr["Experience"];
                sAdapter.UpdateCommand.Parameters.Add("OfficeRole", SqlDbType.Int);
                sAdapter.UpdateCommand.Parameters["OfficeRole"].Value = dr["OfficeRole"];
                sAdapter.UpdateCommand.Parameters.Add("SingCode", SqlDbType.NVarChar);
                sAdapter.UpdateCommand.Parameters["SingCode"].Value = dr["SingCode"];
                sAdapter.UpdateCommand.Parameters.Add("WorkScope", SqlDbType.NVarChar);
                sAdapter.UpdateCommand.Parameters["WorkScope"].Value = dr["WorkScope"];
                sAdapter.UpdateCommand.Parameters.Add("Specialty", SqlDbType.NVarChar);
                sAdapter.UpdateCommand.Parameters["Specialty"].Value = dr["Specialty"];
                sAdapter.UpdateCommand.Parameters.Add("Creator", SqlDbType.Int);
                sAdapter.UpdateCommand.Parameters["Creator"].Value = dr["Creator"];
                sAdapter.UpdateCommand.Parameters.Add("CreateDateTime", SqlDbType.DateTime);
                sAdapter.UpdateCommand.Parameters["CreateDateTime"].Value = dr["CreateDateTime"];
                sAdapter.UpdateCommand.Parameters.Add("LastModifyWorker", SqlDbType.Int);
                sAdapter.UpdateCommand.Parameters["LastModifyWorker"].Value = dr["LastModifyWorker"];
                sAdapter.UpdateCommand.Parameters.Add("LastModifyDateTime", SqlDbType.DateTime);
                sAdapter.UpdateCommand.Parameters["LastModifyDateTime"].Value = dr["LastModifyDateTime"];
                sAdapter.UpdateCommand.Parameters.Add("LogicDeleteDateTime", SqlDbType.DateTime);
                sAdapter.UpdateCommand.Parameters["LogicDeleteDateTime"].Value = dr["LogicDeleteDateTime"];
                sAdapter.UpdateCommand.Parameters.Add("IsLogicDelete", SqlDbType.Bit);
                sAdapter.UpdateCommand.Parameters["IsLogicDelete"].Value = dr["IsLogicDelete"];
                sAdapter.UpdateCommand.Parameters.Add("LockedWorker", SqlDbType.Int);
                sAdapter.UpdateCommand.Parameters["LockedWorker"].Value = dr["LockedWorker"];

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
                StringBuilder delString = new StringBuilder("DELETE FROM WorkerT where " + strSQLWhere);
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
                StringBuilder delString = new StringBuilder("DELETE FROM WorkerT where WorkerKey=@WorkerKey ");
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
