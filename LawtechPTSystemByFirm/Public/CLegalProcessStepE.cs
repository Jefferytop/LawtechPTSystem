using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using H3Operator.DBHelper;

namespace LawtechPTSystemByFirm.Public
{
    #region ======CLegalProcessStepE======
    public class CLegalProcessStepE
    {
        SqlConnection conn = new SqlConnection(DBAccess.ConnectionListDefaultConnectionString);
        SqlDataAdapter sAdapter;
        SqlCommandBuilder CBuilder;

        DataTable dt;
        /// <summary>
        /// 預設帶出所有的資料
        /// </summary>
        public CLegalProcessStepE()
        {
            sAdapter = new SqlDataAdapter("select * from LegalProcessStepET", conn);
            dt = new DataTable();
            //DataSet ds = new DataSet();
            //ds.Tables.Add(dt);
            sAdapter.FillSchema(dt, SchemaType.Source);
            sAdapter.Fill(dt);
            CBuilder = new SqlCommandBuilder(sAdapter);
            sAdapter.InsertCommand = CBuilder.GetInsertCommand(true);
            sAdapter.InsertCommand.UpdatedRowSource = UpdateRowSource.Both;
            sAdapter.InsertCommand.CommandText += " Select @@IDENTITY AS 'IDENTITY'";
            sAdapter.UpdateCommand = new SqlCommand(@"UPDATE LegalProcessStepET  SET 
                                                       sort=@sort,
                                                       Handle=@Handle,
                                                       Status=@Status,
                                                       DefualtWorker=@DefualtWorker,
                                                       Days=@Days,
                                                       Hours=@Hours,
                                                       Minutes=@Minutes,
                                                       IsUsing=@IsUsing,
                                                       ProcessKEY=@ProcessKEY
                                                   where 
                                                       ProcessHandleKEY=@ProcessHandleKEY", conn);
        }
        /// <summary>
        /// 有條件的過濾資料
        /// </summary>
        /// <param name="sWhere">SQL的條件式</param>
        public CLegalProcessStepE(string sWhere)
        {
            sAdapter = new SqlDataAdapter("select * from LegalProcessStepET where " + sWhere, conn);
            dt = new DataTable();
            //DataSet ds = new DataSet();
            //ds.Tables.Add(dt);
            sAdapter.FillSchema(dt, SchemaType.Source);
            sAdapter.Fill(dt);
            CBuilder = new SqlCommandBuilder(sAdapter);
            sAdapter.InsertCommand = CBuilder.GetInsertCommand(true);
            sAdapter.InsertCommand.UpdatedRowSource = UpdateRowSource.Both;
            sAdapter.InsertCommand.CommandText += " Select @@IDENTITY AS 'IDENTITY'";
            sAdapter.UpdateCommand = new SqlCommand(@"UPDATE LegalProcessStepET  SET 
                                                       sort=@sort,
                                                       Handle=@Handle,
                                                       Status=@Status,
                                                       DefualtWorker=@DefualtWorker,
                                                       Days=@Days,
                                                       Hours=@Hours,
                                                       Minutes=@Minutes,
                                                       IsUsing=@IsUsing,
                                                       ProcessKEY=@ProcessKEY
                                                   where 
                                                       ProcessHandleKEY=@ProcessHandleKEY", conn);
        }


        private int _ProcessHandleKEY = -1;
        /// <summary>  
        /// 法務程序清單表 PK
        /// </summary>  
        public int ProcessHandleKEY
        {
            get
            {
                return _ProcessHandleKEY;
            }
            set
            {
                _ProcessHandleKEY = value;
            }
        }
        private int _sort = -1;
        /// <summary>  
        /// 排序
        /// </summary>  
        public int sort
        {
            get
            {
                return _sort;
            }
            set
            {
                _sort = value;
            }
        }
        private string _Handle = "";
        /// <summary>  
        /// 處理階段
        /// </summary>  
        public String Handle
        {
            get
            {
                return _Handle;
            }
            set
            {
                _Handle = value;
            }
        }
        private int _Status = -1;
        /// <summary>  
        /// 對應的法務階段
        /// </summary>  
        public int Status
        {
            get
            {
                return _Status;
            }
            set
            {
                _Status = value;
            }
        }
        private int _DefualtWorker = -1;
        /// <summary>  
        /// 
        /// </summary>  
        public int DefualtWorker
        {
            get
            {
                return _DefualtWorker;
            }
            set
            {
                _DefualtWorker = value;
            }
        }
        private int _Days = -1;
        /// <summary>  
        /// 預計的工作天數
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
        private int _Hours = -1;
        /// <summary>  
        /// 預計的工作時數
        /// </summary>  
        public int Hours
        {
            get
            {
                return _Hours;
            }
            set
            {
                _Hours = value;
            }
        }
        private int _Minutes = -1;
        /// <summary>  
        /// 預計的工作時間--分鐘
        /// </summary>  
        public int Minutes
        {
            get
            {
                return _Minutes;
            }
            set
            {
                _Minutes = value;
            }
        }
        private bool _IsUsing = false;
        /// <summary>  
        /// 1.使用  0.不使用
        /// </summary>  
        public bool IsUsing
        {
            get
            {
                return _IsUsing;
            }
            set
            {
                _IsUsing = value;
            }
        }
        private int _ProcessKEY = -1;
        /// <summary>  
        /// ProcessKindT PK
        /// </summary>  
        public int ProcessKEY
        {
            get
            {
                return _ProcessKEY;
            }
            set
            {
                _ProcessKEY = value;
            }
        }

        /// <summary>
        /// 取得LegalProcessStepET資料集
        /// </summary>
        public DataTable GetDataTable()
        {
            return dt;
        }

        /// <summary>
        /// 設定LegalProcessStepET資料集
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
            string strSQL = "select count(" + ColumnName + ") as CountValue from LegalProcessStepET where " + ColumnName + "='" + Value + "'";
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
            string strSQL = "select count(" + ColumnName + ") as CountValue from LegalProcessStepET where " + ColumnName + "=" + Value;
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
                this.ProcessHandleKEY = dr["ProcessHandleKEY"].ToString() == "" ? -1 : (int)dr["ProcessHandleKEY"];
                this.sort = dr["sort"].ToString() == "" ? -1 : (int)dr["sort"];
                this.Handle = dr["Handle"].ToString();
                this.Status = dr["Status"].ToString() == "" ? -1 : (int)dr["Status"];
                this.DefualtWorker = dr["DefualtWorker"].ToString() == "" ? -1 : (int)dr["DefualtWorker"];
                this.Days = dr["Days"].ToString() == "" ? -1 : (int)dr["Days"];
                this.Hours = dr["Hours"].ToString() == "" ? -1 : (int)dr["Hours"];
                this.Minutes = dr["Minutes"].ToString() == "" ? -1 : (int)dr["Minutes"];
                this.IsUsing = dr["IsUsing"].ToString() == "" ? false : (bool)dr["IsUsing"];
                this.ProcessKEY = dr["ProcessKEY"].ToString() == "" ? -1 : (int)dr["ProcessKEY"];
            }
            catch
            {
                throw (new System.Exception("LegalProcessStepET該筆資料有誤：" + NO.ToString()));
            }
        }
        public void Insert()
        {
            try
            {
                Object Rownull = System.DBNull.Value;
                DataRow dr = dt.NewRow();
                dr["sort"] = this.sort == -1 ? Rownull : this.sort;
                dr["Handle"] = this.Handle == "" ? Rownull : this.Handle;
                dr["Status"] = this.Status == -1 ? Rownull : this.Status;
                dr["DefualtWorker"] = this.DefualtWorker == -1 ? Rownull : this.DefualtWorker;
                dr["Days"] = this.Days == -1 ? Rownull : this.Days;
                dr["Hours"] = this.Hours == -1 ? Rownull : this.Hours;
                dr["Minutes"] = this.Minutes == -1 ? Rownull : this.Minutes;
                dr["IsUsing"] = this.IsUsing;
                dr["ProcessKEY"] = this.ProcessKEY == -1 ? Rownull : this.ProcessKEY;
                sAdapter.InsertCommand.Parameters["@sort"].Value = dr["sort"];
                sAdapter.InsertCommand.Parameters["@Handle"].Value = dr["Handle"];
                sAdapter.InsertCommand.Parameters["@Status"].Value = dr["Status"];
                sAdapter.InsertCommand.Parameters["@DefualtWorker"].Value = dr["DefualtWorker"];
                sAdapter.InsertCommand.Parameters["@Days"].Value = dr["Days"];
                sAdapter.InsertCommand.Parameters["@Hours"].Value = dr["Hours"];
                sAdapter.InsertCommand.Parameters["@Minutes"].Value = dr["Minutes"];
                sAdapter.InsertCommand.Parameters["@IsUsing"].Value = dr["IsUsing"];
                sAdapter.InsertCommand.Parameters["@ProcessKEY"].Value = dr["ProcessKEY"];
                conn.Open();
                string KEY = sAdapter.InsertCommand.ExecuteScalar().ToString();
                conn.Close();
                if (KEY != "")
                {
                    this.ProcessHandleKEY = int.Parse(KEY);
                    dr["ProcessHandleKEY"] = this.ProcessHandleKEY;
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
                dr["sort"] = this.sort == -1 ? Rownull : this.sort;
                dr["Handle"] = this.Handle == "" ? Rownull : this.Handle;
                dr["Status"] = this.Status == -1 ? Rownull : this.Status;
                dr["DefualtWorker"] = this.DefualtWorker == -1 ? Rownull : this.DefualtWorker;
                dr["Days"] = this.Days == -1 ? Rownull : this.Days;
                dr["Hours"] = this.Hours == -1 ? Rownull : this.Hours;
                dr["Minutes"] = this.Minutes == -1 ? Rownull : this.Minutes;
                dr["IsUsing"] = this.IsUsing;
                dr["ProcessKEY"] = this.ProcessKEY == -1 ? Rownull : this.ProcessKEY;
                sAdapter.UpdateCommand.Parameters.Clear();
                sAdapter.UpdateCommand.Parameters.Add("ProcessHandleKEY", SqlDbType.Int);
                sAdapter.UpdateCommand.Parameters["ProcessHandleKEY"].Value = dr["ProcessHandleKEY"];
                sAdapter.UpdateCommand.Parameters.Add("sort", SqlDbType.Int);
                sAdapter.UpdateCommand.Parameters["sort"].Value = dr["sort"];
                sAdapter.UpdateCommand.Parameters.Add("Handle", SqlDbType.NVarChar);
                sAdapter.UpdateCommand.Parameters["Handle"].Value = dr["Handle"];
                sAdapter.UpdateCommand.Parameters.Add("Status", SqlDbType.Int);
                sAdapter.UpdateCommand.Parameters["Status"].Value = dr["Status"];
                sAdapter.UpdateCommand.Parameters.Add("DefualtWorker", SqlDbType.Int);
                sAdapter.UpdateCommand.Parameters["DefualtWorker"].Value = dr["DefualtWorker"];
                sAdapter.UpdateCommand.Parameters.Add("Days", SqlDbType.Int);
                sAdapter.UpdateCommand.Parameters["Days"].Value = dr["Days"];
                sAdapter.UpdateCommand.Parameters.Add("Hours", SqlDbType.Int);
                sAdapter.UpdateCommand.Parameters["Hours"].Value = dr["Hours"];
                sAdapter.UpdateCommand.Parameters.Add("Minutes", SqlDbType.Int);
                sAdapter.UpdateCommand.Parameters["Minutes"].Value = dr["Minutes"];
                sAdapter.UpdateCommand.Parameters.Add("IsUsing", SqlDbType.Bit);
                sAdapter.UpdateCommand.Parameters["IsUsing"].Value = dr["IsUsing"];
                sAdapter.UpdateCommand.Parameters.Add("ProcessKEY", SqlDbType.Int);
                sAdapter.UpdateCommand.Parameters["ProcessKEY"].Value = dr["ProcessKEY"];

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
                StringBuilder delString = new StringBuilder("DELETE FROM LegalProcessStepET where " + strSQLWhere);
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
                StringBuilder delString = new StringBuilder("DELETE FROM LegalProcessStepET where ProcessHandleKEY=@ProcessHandleKEY ");
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
    }
    #endregion
}
