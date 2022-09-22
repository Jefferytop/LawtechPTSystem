using System;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using H3Operator.DBHelper;

namespace LawtechPTSystem.Public
{
    
    #region ======CEmailSample======
    public class CEmailSample
    {
        SqlConnection conn = new SqlConnection(DBAccess.ConnectionListDefaultConnectionString);
        SqlDataAdapter sAdapter;
        SqlCommandBuilder CBuilder;

        DataTable dt;
        /// <summary>
        /// 預設帶出所有的資料
        /// </summary>
        public CEmailSample()
        {
            sAdapter = new SqlDataAdapter("select * from EmailSampleT", conn);
            dt = new DataTable();
            //DataSet ds = new DataSet();
            //ds.Tables.Add(dt);
            sAdapter.FillSchema(dt, SchemaType.Source);
            sAdapter.Fill(dt);
            CBuilder = new SqlCommandBuilder(sAdapter);
            sAdapter.InsertCommand = CBuilder.GetInsertCommand(true);
            sAdapter.InsertCommand.UpdatedRowSource = UpdateRowSource.Both;
            sAdapter.InsertCommand.CommandText += " Select @@IDENTITY AS 'IDENTITY'";
            sAdapter.UpdateCommand = new SqlCommand(@"UPDATE EmailSampleT  SET 
                                                       EmailSampleType=@EmailSampleType,
                                                       Sort=@Sort,
                                                       SampleName=@SampleName,
                                                       EmailSampleDescription=@EmailSampleDescription,
                                                       MailSubject=@MailSubject,
                                                       MailPriority=@MailPriority,
                                                       MailBody=@MailBody,
                                                       MailFormat=@MailFormat,
                                                       CreateDate=@CreateDate,
                                                       CreateWorkerKey=@CreateWorkerKey,
                                                       Locker=@Locker
                                                   where 
                                                       ESID=@ESID", conn);
        }
        /// <summary>
        /// 有條件的過濾資料
        /// </summary>
        /// <param name="sWhere">SQL的條件式</param>
        public CEmailSample(string sWhere)
        {
            sAdapter = new SqlDataAdapter("select * from EmailSampleT where " + sWhere, conn);
            dt = new DataTable();
            //DataSet ds = new DataSet();
            //ds.Tables.Add(dt);
            sAdapter.FillSchema(dt, SchemaType.Source);
            sAdapter.Fill(dt);
            CBuilder = new SqlCommandBuilder(sAdapter);
            sAdapter.InsertCommand = CBuilder.GetInsertCommand(true);
            sAdapter.InsertCommand.UpdatedRowSource = UpdateRowSource.Both;
            sAdapter.InsertCommand.CommandText += " Select @@IDENTITY AS 'IDENTITY'";
            sAdapter.UpdateCommand = new SqlCommand(@"UPDATE EmailSampleT  SET 
                                                       EmailSampleType=@EmailSampleType,
                                                       Sort=@Sort,
                                                       SampleName=@SampleName,
                                                       EmailSampleDescription=@EmailSampleDescription,
                                                       MailSubject=@MailSubject,
                                                       MailPriority=@MailPriority,
                                                       MailBody=@MailBody,
                                                       MailFormat=@MailFormat,
                                                       CreateDate=@CreateDate,
                                                       CreateWorkerKey=@CreateWorkerKey,
                                                       Locker=@Locker
                                                   where 
                                                       ESID=@ESID", conn);
        }


        private int _ESID = -1;
        /// <summary>  
        /// Email範本資料表
        /// </summary>  
        public int ESID
        {
            get
            {
                return _ESID;
            }
            set
            {
                _ESID = value;
            }
        }
        private string _EmailSampleType = "";
        /// <summary>  
        /// 範本類型
        /// </summary>  
        public String EmailSampleType
        {
            get
            {
                return _EmailSampleType;
            }
            set
            {
                _EmailSampleType = value;
            }
        }
        private int _Sort = -1;
        /// <summary>  
        /// 
        /// </summary>  
        public int Sort
        {
            get
            {
                return _Sort;
            }
            set
            {
                _Sort = value;
            }
        }
        private string _SampleName = "";
        /// <summary>  
        /// 範本名稱
        /// </summary>  
        public String SampleName
        {
            get
            {
                return _SampleName;
            }
            set
            {
                _SampleName = value;
            }
        }
        private string _EmailSampleDescription = "";
        /// <summary>  
        /// 範本使用說明
        /// </summary>  
        public String EmailSampleDescription
        {
            get
            {
                return _EmailSampleDescription;
            }
            set
            {
                _EmailSampleDescription = value;
            }
        }
        private string _MailSubject = "";
        /// <summary>  
        /// mail主旨
        /// </summary>  
        public String MailSubject
        {
            get
            {
                return _MailSubject;
            }
            set
            {
                _MailSubject = value;
            }
        }
        private int _MailPriority = -1;
        /// <summary>  
        /// mail重要性
        /// </summary>  
        public int MailPriority
        {
            get
            {
                return _MailPriority;
            }
            set
            {
                _MailPriority = value;
            }
        }
        private string _MailBody = "";
        /// <summary>  
        /// mail內文
        /// </summary>  
        public String MailBody
        {
            get
            {
                return _MailBody;
            }
            set
            {
                _MailBody = value;
            }
        }
        private string _MailFormat = "";
        /// <summary>  
        /// email 格式  文字格式(txt) HTML格式(html)
        /// </summary>  
        public String MailFormat
        {
            get
            {
                return _MailFormat;
            }
            set
            {
                _MailFormat = value;
            }
        }
        private DateTime _CreateDate = DateTime.Parse("1900/1/1");
        /// <summary>  
        /// 建立時間
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
        private int _CreateWorkerKey = -1;
        /// <summary>  
        /// 建立者
        /// </summary>  
        public int CreateWorkerKey
        {
            get
            {
                return _CreateWorkerKey;
            }
            set
            {
                _CreateWorkerKey = value;
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
        /// 取得EmailSampleT資料集
        /// </summary>
        public DataTable GetDataTable()
        {
            return dt;
        }

        /// <summary>
        /// 設定EmailSampleT資料集
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
            string strSQL = "select count(" + ColumnName + ") as CountValue from EmailSampleT where " + ColumnName + "='" + Value + "'";
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
            string strSQL = "select count(" + ColumnName + ") as CountValue from EmailSampleT where " + ColumnName + "=" + Value;
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
                this.ESID = dr["ESID"].ToString() == "" ? -1 : (int)dr["ESID"];
                this.EmailSampleType = dr["EmailSampleType"].ToString();
                this.Sort = dr["Sort"].ToString() == "" ? -1 : (int)dr["Sort"];
                this.SampleName = dr["SampleName"].ToString();
                this.EmailSampleDescription = dr["EmailSampleDescription"].ToString();
                this.MailSubject = dr["MailSubject"].ToString();
                this.MailPriority = dr["MailPriority"].ToString() == "" ? -1 : (int)dr["MailPriority"];
                this.MailBody = dr["MailBody"].ToString();
                this.MailFormat = dr["MailFormat"].ToString();
                this.CreateDate = dr["CreateDate"].ToString() == "" ? DateTime.Parse("1900/1/1") : (DateTime)dr["CreateDate"];
                this.CreateWorkerKey = dr["CreateWorkerKey"].ToString() == "" ? -1 : (int)dr["CreateWorkerKey"];
                this.Locker = dr["Locker"].ToString() == "" ? -1 : (int)dr["Locker"];
            }
            catch
            {
                throw (new System.Exception("EmailSampleT該筆資料有誤：" + NO.ToString()));
            }
        }
        public void Insert()
        {
            try
            {
                Object Rownull = System.DBNull.Value;
                DataRow dr = dt.NewRow();
                dr["EmailSampleType"] = this.EmailSampleType == "" ? Rownull : this.EmailSampleType;
                dr["Sort"] = this.Sort == -1 ? Rownull : this.Sort;
                dr["SampleName"] = this.SampleName == "" ? Rownull : this.SampleName;
                dr["EmailSampleDescription"] = this.EmailSampleDescription == "" ? Rownull : this.EmailSampleDescription;
                dr["MailSubject"] = this.MailSubject == "" ? Rownull : this.MailSubject;
                dr["MailPriority"] = this.MailPriority == -1 ? Rownull : this.MailPriority;
                dr["MailBody"] = this.MailBody == "" ? Rownull : this.MailBody;
                dr["MailFormat"] = this.MailFormat == "" ? Rownull : this.MailFormat;
                dr["CreateDate"] = this.CreateDate.ToShortDateString() == "1900/1/1" ? Rownull : this.CreateDate;
                dr["CreateWorkerKey"] = this.CreateWorkerKey == -1 ? Rownull : this.CreateWorkerKey;
                dr["Locker"] = this.Locker == -1 ? Rownull : this.Locker;
                sAdapter.InsertCommand.Parameters["@EmailSampleType"].Value = dr["EmailSampleType"];
                sAdapter.InsertCommand.Parameters["@Sort"].Value = dr["Sort"];
                sAdapter.InsertCommand.Parameters["@SampleName"].Value = dr["SampleName"];
                sAdapter.InsertCommand.Parameters["@EmailSampleDescription"].Value = dr["EmailSampleDescription"];
                sAdapter.InsertCommand.Parameters["@MailSubject"].Value = dr["MailSubject"];
                sAdapter.InsertCommand.Parameters["@MailPriority"].Value = dr["MailPriority"];
                sAdapter.InsertCommand.Parameters["@MailBody"].Value = dr["MailBody"];
                sAdapter.InsertCommand.Parameters["@MailFormat"].Value = dr["MailFormat"];
                sAdapter.InsertCommand.Parameters["@CreateDate"].Value = dr["CreateDate"];
                sAdapter.InsertCommand.Parameters["@CreateWorkerKey"].Value = dr["CreateWorkerKey"];
                sAdapter.InsertCommand.Parameters["@Locker"].Value = dr["Locker"];
                conn.Open();
                string KEY = sAdapter.InsertCommand.ExecuteScalar().ToString();
                conn.Close();
                if (KEY != "")
                {
                    this.ESID = int.Parse(KEY);
                    dr["ESID"] = this.ESID;
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
                dr["EmailSampleType"] = this.EmailSampleType == "" ? Rownull : this.EmailSampleType;
                dr["Sort"] = this.Sort == -1 ? Rownull : this.Sort;
                dr["SampleName"] = this.SampleName == "" ? Rownull : this.SampleName;
                dr["EmailSampleDescription"] = this.EmailSampleDescription == "" ? Rownull : this.EmailSampleDescription;
                dr["MailSubject"] = this.MailSubject == "" ? Rownull : this.MailSubject;
                dr["MailPriority"] = this.MailPriority == -1 ? Rownull : this.MailPriority;
                dr["MailBody"] = this.MailBody == "" ? Rownull : this.MailBody;
                dr["MailFormat"] = this.MailFormat == "" ? Rownull : this.MailFormat;
                dr["CreateDate"] = this.CreateDate.ToShortDateString() == "1900/1/1" ? Rownull : this.CreateDate;
                dr["CreateWorkerKey"] = this.CreateWorkerKey == -1 ? Rownull : this.CreateWorkerKey;
                dr["Locker"] = this.Locker == -1 ? Rownull : this.Locker;
                sAdapter.UpdateCommand.Parameters.Clear();
                sAdapter.UpdateCommand.Parameters.Add("ESID", SqlDbType.Int);
                sAdapter.UpdateCommand.Parameters["ESID"].Value = dr["ESID"];
                sAdapter.UpdateCommand.Parameters.Add("EmailSampleType", SqlDbType.NVarChar);
                sAdapter.UpdateCommand.Parameters["EmailSampleType"].Value = dr["EmailSampleType"];
                sAdapter.UpdateCommand.Parameters.Add("Sort", SqlDbType.Int);
                sAdapter.UpdateCommand.Parameters["Sort"].Value = dr["Sort"];
                sAdapter.UpdateCommand.Parameters.Add("SampleName", SqlDbType.NVarChar);
                sAdapter.UpdateCommand.Parameters["SampleName"].Value = dr["SampleName"];
                sAdapter.UpdateCommand.Parameters.Add("EmailSampleDescription", SqlDbType.NVarChar);
                sAdapter.UpdateCommand.Parameters["EmailSampleDescription"].Value = dr["EmailSampleDescription"];
                sAdapter.UpdateCommand.Parameters.Add("MailSubject", SqlDbType.NVarChar);
                sAdapter.UpdateCommand.Parameters["MailSubject"].Value = dr["MailSubject"];
                sAdapter.UpdateCommand.Parameters.Add("MailPriority", SqlDbType.Int);
                sAdapter.UpdateCommand.Parameters["MailPriority"].Value = dr["MailPriority"];
                sAdapter.UpdateCommand.Parameters.Add("MailBody", SqlDbType.NVarChar);
                sAdapter.UpdateCommand.Parameters["MailBody"].Value = dr["MailBody"];
                sAdapter.UpdateCommand.Parameters.Add("MailFormat", SqlDbType.NVarChar);
                sAdapter.UpdateCommand.Parameters["MailFormat"].Value = dr["MailFormat"];
                sAdapter.UpdateCommand.Parameters.Add("CreateDate", SqlDbType.DateTime);
                sAdapter.UpdateCommand.Parameters["CreateDate"].Value = dr["CreateDate"];
                sAdapter.UpdateCommand.Parameters.Add("CreateWorkerKey", SqlDbType.Int);
                sAdapter.UpdateCommand.Parameters["CreateWorkerKey"].Value = dr["CreateWorkerKey"];
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
                StringBuilder delString = new StringBuilder("DELETE FROM EmailSampleT where " + strSQLWhere);
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
                StringBuilder delString = new StringBuilder("DELETE FROM EmailSampleT where ESID=@ESID ");
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
