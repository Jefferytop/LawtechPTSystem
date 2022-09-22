using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using H3Operator.DBHelper;

namespace LawtechPTSystem.Public
{
    #region ======CLegalProcessKind======
    public class CLegalProcessKind
    {
        SqlConnection conn = new SqlConnection(DBAccess.ConnectionListDefaultConnectionString);
        SqlDataAdapter sAdapter;
        SqlCommandBuilder CBuilder;

        DataTable dt;
        /// <summary>
        /// 預設帶出所有的資料
        /// </summary>
        public CLegalProcessKind()
        {
            sAdapter = new SqlDataAdapter("select * from LegalProcessKindT", conn);
            dt = new DataTable();
            //DataSet ds = new DataSet();
            //ds.Tables.Add(dt);
            sAdapter.FillSchema(dt, SchemaType.Source);
            sAdapter.Fill(dt);
            CBuilder = new SqlCommandBuilder(sAdapter);
            sAdapter.InsertCommand = CBuilder.GetInsertCommand(true);
            sAdapter.InsertCommand.UpdatedRowSource = UpdateRowSource.Both;
            sAdapter.InsertCommand.CommandText += " Select @@IDENTITY AS 'IDENTITY'";
            sAdapter.UpdateCommand = new SqlCommand(@"UPDATE LegalProcessKindT  SET 
                                                       sort=@sort,
                                                       ProcessKind=@ProcessKind,
                                                       bStop=@bStop
                                                   where 
                                                       ProcessKEY=@ProcessKEY", conn);
        }
        /// <summary>
        /// 有條件的過濾資料
        /// </summary>
        /// <param name="sWhere">SQL的條件式</param>
        public CLegalProcessKind(string sWhere)
        {
            sAdapter = new SqlDataAdapter("select * from LegalProcessKindT where " + sWhere, conn);
            dt = new DataTable();
            //DataSet ds = new DataSet();
            //ds.Tables.Add(dt);
            sAdapter.FillSchema(dt, SchemaType.Source);
            sAdapter.Fill(dt);
            CBuilder = new SqlCommandBuilder(sAdapter);
            sAdapter.InsertCommand = CBuilder.GetInsertCommand(true);
            sAdapter.InsertCommand.UpdatedRowSource = UpdateRowSource.Both;
            sAdapter.InsertCommand.CommandText += " Select @@IDENTITY AS 'IDENTITY'";
            sAdapter.UpdateCommand = new SqlCommand(@"UPDATE LegalProcessKindT  SET 
                                                       sort=@sort,
                                                       ProcessKind=@ProcessKind,
                                                       bStop=@bStop
                                                   where 
                                                       ProcessKEY=@ProcessKEY", conn);
        }


        private int _ProcessKEY = -1;
        /// <summary>  
        /// 法務事件表 PK
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
        private string _ProcessKind = "";
        /// <summary>  
        /// 法務事件程序
        /// </summary>  
        public String ProcessKind
        {
            get
            {
                return _ProcessKind;
            }
            set
            {
                _ProcessKind = value;
            }
        }
        private int _bStop = -1;
        /// <summary>  
        /// 1.啟動 0.停用
        /// </summary>  
        public int bStop
        {
            get
            {
                return _bStop;
            }
            set
            {
                _bStop = value;
            }
        }

        /// <summary>
        /// 取得LegalProcessKindT資料集
        /// </summary>
        public DataTable GetDataTable()
        {
            return dt;
        }

        /// <summary>
        /// 設定LegalProcessKindT資料集
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
            string strSQL = "select count(" + ColumnName + ") as CountValue from LegalProcessKindT where " + ColumnName + "='" + Value + "'";
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
            string strSQL = "select count(" + ColumnName + ") as CountValue from LegalProcessKindT where " + ColumnName + "=" + Value;
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
                this.ProcessKEY = dr["ProcessKEY"].ToString() == "" ? -1 : (int)dr["ProcessKEY"];
                this.sort = dr["sort"].ToString() == "" ? -1 : (int)dr["sort"];
                this.ProcessKind = dr["ProcessKind"].ToString();
                this.bStop = dr["bStop"].ToString() == "" ? -1 : (int)dr["bStop"];
            }
            catch
            {
                throw (new System.Exception("LegalProcessKindT該筆資料有誤：" + NO.ToString()));
            }
        }
        public void Insert()
        {
            try
            {
                Object Rownull = System.DBNull.Value;
                DataRow dr = dt.NewRow();
                dr["sort"] = this.sort == -1 ? Rownull : this.sort;
                dr["ProcessKind"] = this.ProcessKind == "" ? Rownull : this.ProcessKind;
                dr["bStop"] = this.bStop == -1 ? Rownull : this.bStop;
                sAdapter.InsertCommand.Parameters["@sort"].Value = dr["sort"];
                sAdapter.InsertCommand.Parameters["@ProcessKind"].Value = dr["ProcessKind"];
                sAdapter.InsertCommand.Parameters["@bStop"].Value = dr["bStop"];
                conn.Open();
                string KEY = sAdapter.InsertCommand.ExecuteScalar().ToString();
                conn.Close();
                if (KEY != "")
                {
                    this.ProcessKEY = int.Parse(KEY);
                    dr["ProcessKEY"] = this.ProcessKEY;
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
                dr["ProcessKind"] = this.ProcessKind == "" ? Rownull : this.ProcessKind;
                dr["bStop"] = this.bStop == -1 ? Rownull : this.bStop;
                sAdapter.UpdateCommand.Parameters.Clear();
                sAdapter.UpdateCommand.Parameters.Add("ProcessKEY", SqlDbType.Int);
                sAdapter.UpdateCommand.Parameters["ProcessKEY"].Value = dr["ProcessKEY"];
                sAdapter.UpdateCommand.Parameters.Add("sort", SqlDbType.Int);
                sAdapter.UpdateCommand.Parameters["sort"].Value = dr["sort"];
                sAdapter.UpdateCommand.Parameters.Add("ProcessKind", SqlDbType.NVarChar);
                sAdapter.UpdateCommand.Parameters["ProcessKind"].Value = dr["ProcessKind"];
                sAdapter.UpdateCommand.Parameters.Add("bStop", SqlDbType.Int);
                sAdapter.UpdateCommand.Parameters["bStop"].Value = dr["bStop"];

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
                StringBuilder delString = new StringBuilder("DELETE FROM LegalProcessKindT where " + strSQLWhere);
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
                StringBuilder delString = new StringBuilder("DELETE FROM LegalProcessKindT where ProcessKEY=@ProcessKEY ");
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
