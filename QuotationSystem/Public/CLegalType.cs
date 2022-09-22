using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using H3Operator.DBHelper;

namespace LawtechPTSystem.Public
{
    #region ======CLegalType======
    public class CLegalType
    {
        SqlConnection conn = new SqlConnection(DBAccess.ConnectionListDefaultConnectionString);
        SqlDataAdapter sAdapter;
        SqlCommandBuilder CBuilder;

        DataTable dt;
        /// <summary>
        /// 預設帶出所有的資料
        /// </summary>
        public CLegalType()
        {
            sAdapter = new SqlDataAdapter("select * from LegalTypeT", conn);
            dt = new DataTable();
            //DataSet ds = new DataSet();
            //ds.Tables.Add(dt);
            sAdapter.FillSchema(dt, SchemaType.Source);
            sAdapter.Fill(dt);
            CBuilder = new SqlCommandBuilder(sAdapter);
            sAdapter.InsertCommand = CBuilder.GetInsertCommand(true);
            sAdapter.InsertCommand.UpdatedRowSource = UpdateRowSource.Both;
            sAdapter.InsertCommand.CommandText += " Select @@IDENTITY AS 'IDENTITY'";
            sAdapter.UpdateCommand = new SqlCommand(@"UPDATE LegalTypeT  SET 
                                                       LegalTypeName=@LegalTypeName,
                                                       Sort=@Sort
                                                   where 
                                                       LegalTypeKey=@LegalTypeKey", conn);
        }
        /// <summary>
        /// 有條件的過濾資料
        /// </summary>
        /// <param name="sWhere">SQL的條件式</param>
        public CLegalType(string sWhere)
        {
            sAdapter = new SqlDataAdapter("select * from LegalTypeT where " + sWhere, conn);
            dt = new DataTable();
            //DataSet ds = new DataSet();
            //ds.Tables.Add(dt);
            sAdapter.FillSchema(dt, SchemaType.Source);
            sAdapter.Fill(dt);
            CBuilder = new SqlCommandBuilder(sAdapter);
            sAdapter.InsertCommand = CBuilder.GetInsertCommand(true);
            sAdapter.InsertCommand.UpdatedRowSource = UpdateRowSource.Both;
            sAdapter.InsertCommand.CommandText += " Select @@IDENTITY AS 'IDENTITY'";
            sAdapter.UpdateCommand = new SqlCommand(@"UPDATE LegalTypeT  SET 
                                                       LegalTypeName=@LegalTypeName,
                                                       Sort=@Sort
                                                   where 
                                                       LegalTypeKey=@LegalTypeKey", conn);
        }


        private int _LegalTypeKey = -1;
        /// <summary>  
        /// 法務案件類別表
        /// </summary>  
        public int LegalTypeKey
        {
            get
            {
                return _LegalTypeKey;
            }
            set
            {
                _LegalTypeKey = value;
            }
        }
        private string _LegalTypeName = "";
        /// <summary>  
        /// 案件類別名稱
        /// </summary>  
        public String LegalTypeName
        {
            get
            {
                return _LegalTypeName;
            }
            set
            {
                _LegalTypeName = value;
            }
        }
        private int _Sort = -1;
        /// <summary>  
        /// 排序
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

        /// <summary>
        /// 取得LegalTypeT資料集
        /// </summary>
        public DataTable GetDataTable()
        {
            return dt;
        }

        /// <summary>
        /// 設定LegalTypeT資料集
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
            string strSQL = "select count(" + ColumnName + ") as CountValue from LegalTypeT where " + ColumnName + "='" + Value + "'";
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
            string strSQL = "select count(" + ColumnName + ") as CountValue from LegalTypeT where " + ColumnName + "=" + Value;
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
                this.LegalTypeKey = dr["LegalTypeKey"].ToString() == "" ? -1 : (int)dr["LegalTypeKey"];
                this.LegalTypeName = dr["LegalTypeName"].ToString();
                this.Sort = dr["Sort"].ToString() == "" ? -1 : (int)dr["Sort"];
            }
            catch
            {
                throw (new System.Exception("LegalTypeT該筆資料有誤：" + NO.ToString()));
            }
        }
        public void Insert()
        {
            try
            {
                Object Rownull = System.DBNull.Value;
                DataRow dr = dt.NewRow();
                dr["LegalTypeName"] = this.LegalTypeName == "" ? Rownull : this.LegalTypeName;
                dr["Sort"] = this.Sort == -1 ? Rownull : this.Sort;
                sAdapter.InsertCommand.Parameters["@LegalTypeName"].Value = dr["LegalTypeName"];
                sAdapter.InsertCommand.Parameters["@Sort"].Value = dr["Sort"];
                conn.Open();
                string KEY = sAdapter.InsertCommand.ExecuteScalar().ToString();
                conn.Close();
                if (KEY != "")
                {
                    this.LegalTypeKey = int.Parse(KEY);
                    dr["LegalTypeKey"] = this.LegalTypeKey;
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
                dr["LegalTypeName"] = this.LegalTypeName == "" ? Rownull : this.LegalTypeName;
                dr["Sort"] = this.Sort == -1 ? Rownull : this.Sort;
                sAdapter.UpdateCommand.Parameters.Clear();
                sAdapter.UpdateCommand.Parameters.Add("LegalTypeKey", SqlDbType.Int);
                sAdapter.UpdateCommand.Parameters["LegalTypeKey"].Value = dr["LegalTypeKey"];
                sAdapter.UpdateCommand.Parameters.Add("LegalTypeName", SqlDbType.NVarChar);
                sAdapter.UpdateCommand.Parameters["LegalTypeName"].Value = dr["LegalTypeName"];
                sAdapter.UpdateCommand.Parameters.Add("Sort", SqlDbType.Int);
                sAdapter.UpdateCommand.Parameters["Sort"].Value = dr["Sort"];

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
                StringBuilder delString = new StringBuilder("DELETE FROM LegalTypeT where " + strSQLWhere);
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
                StringBuilder delString = new StringBuilder("DELETE FROM LegalTypeT where LegalTypeKey=@LegalTypeKey ");
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
