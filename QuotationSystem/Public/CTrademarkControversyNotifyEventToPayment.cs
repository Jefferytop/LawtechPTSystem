using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using H3Operator.DBHelper;
namespace LawtechPTSystem.Public
{
    #region ======CTrademarkControversyNotifyEventToPayment======
    public class CTrademarkControversyNotifyEventToPayment
    {
        SqlConnection conn = new SqlConnection(DBAccess.ConnectionListDefaultConnectionString);
        SqlDataAdapter sAdapter;
        SqlCommandBuilder CBuilder;

        DataTable dt;
        /// <summary>
        /// 預設帶出所有的資料
        /// </summary>
        public CTrademarkControversyNotifyEventToPayment()
        {
            sAdapter = new SqlDataAdapter("select * from TrademarkControversyNotifyEventToPaymentT", conn);
            dt = new DataTable();
            //DataSet ds = new DataSet();
            //ds.Tables.Add(dt);
            sAdapter.FillSchema(dt, SchemaType.Source);
            sAdapter.Fill(dt);
            CBuilder = new SqlCommandBuilder(sAdapter);
            sAdapter.InsertCommand = CBuilder.GetInsertCommand(true);
            sAdapter.InsertCommand.UpdatedRowSource = UpdateRowSource.Both;
            sAdapter.InsertCommand.CommandText += " Select @@IDENTITY AS 'IDENTITY'";
            sAdapter.UpdateCommand = new SqlCommand(@"UPDATE TrademarkControversyNotifyEventToPaymentT  SET 
                                                       TMNotifyControversyEventID=@TMNotifyControversyEventID,
                                                       ControversyPaymentID=@ControversyPaymentID
                                                   where 
                                                       TNPID=@TNPID", conn);
        }
        /// <summary>
        /// 有條件的過濾資料
        /// </summary>
        /// <param name="sWhere">SQL的條件式</param>
        public CTrademarkControversyNotifyEventToPayment(string sWhere)
        {
            sAdapter = new SqlDataAdapter("select * from TrademarkControversyNotifyEventToPaymentT where " + sWhere, conn);
            dt = new DataTable();
            //DataSet ds = new DataSet();
            //ds.Tables.Add(dt);
            sAdapter.FillSchema(dt, SchemaType.Source);
            sAdapter.Fill(dt);
            CBuilder = new SqlCommandBuilder(sAdapter);
            sAdapter.InsertCommand = CBuilder.GetInsertCommand(true);
            sAdapter.InsertCommand.UpdatedRowSource = UpdateRowSource.Both;
            sAdapter.InsertCommand.CommandText += " Select @@IDENTITY AS 'IDENTITY'";
            sAdapter.UpdateCommand = new SqlCommand(@"UPDATE TrademarkControversyNotifyEventToPaymentT  SET 
                                                       TMNotifyControversyEventID=@TMNotifyControversyEventID,
                                                       ControversyPaymentID=@ControversyPaymentID
                                                   where 
                                                       TNPID=@TNPID", conn);
        }


        private int _TNPID = -1;
        /// <summary>  
        /// 來函轉付款表
        /// </summary>  
        public int TNPID
        {
            get
            {
                return _TNPID;
            }
            set
            {
                _TNPID = value;
            }
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

        /// <summary>
        /// 取得TrademarkControversyNotifyEventToPaymentT資料集
        /// </summary>
        public DataTable GetDataTable()
        {
            return dt;
        }

        /// <summary>
        /// 設定TrademarkControversyNotifyEventToPaymentT資料集
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
            string strSQL = "select count(" + ColumnName + ") as CountValue from TrademarkControversyNotifyEventToPaymentT where " + ColumnName + "='" + Value + "'";
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
            string strSQL = "select count(" + ColumnName + ") as CountValue from TrademarkControversyNotifyEventToPaymentT where " + ColumnName + "=" + Value;
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
                this.TNPID = dr["TNPID"].ToString() == "" ? -1 : (int)dr["TNPID"];
                this.TMNotifyControversyEventID = dr["TMNotifyControversyEventID"].ToString() == "" ? -1 : (int)dr["TMNotifyControversyEventID"];
                this.ControversyPaymentID = dr["ControversyPaymentID"].ToString() == "" ? -1 : (int)dr["ControversyPaymentID"];
            }
            catch
            {
                throw (new System.Exception("TrademarkControversyNotifyEventToPaymentT該筆資料有誤：" + NO.ToString()));
            }
        }
        public void Insert()
        {
            try
            {
                Object Rownull = System.DBNull.Value;
                DataRow dr = dt.NewRow();
                dr["TMNotifyControversyEventID"] = this.TMNotifyControversyEventID == -1 ? Rownull : this.TMNotifyControversyEventID;
                dr["ControversyPaymentID"] = this.ControversyPaymentID == -1 ? Rownull : this.ControversyPaymentID;
                sAdapter.InsertCommand.Parameters["@TMNotifyControversyEventID"].Value = dr["TMNotifyControversyEventID"];
                sAdapter.InsertCommand.Parameters["@ControversyPaymentID"].Value = dr["ControversyPaymentID"];
                conn.Open();
                string KEY = sAdapter.InsertCommand.ExecuteScalar().ToString();
                conn.Close();
                if (KEY != "")
                {
                    this.TNPID = int.Parse(KEY);
                    dr["TNPID"] = this.TNPID;
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
                dr["TMNotifyControversyEventID"] = this.TMNotifyControversyEventID == -1 ? Rownull : this.TMNotifyControversyEventID;
                dr["ControversyPaymentID"] = this.ControversyPaymentID == -1 ? Rownull : this.ControversyPaymentID;
                sAdapter.UpdateCommand.Parameters.Clear();
                sAdapter.UpdateCommand.Parameters.Add("TNPID", SqlDbType.Int);
                sAdapter.UpdateCommand.Parameters["TNPID"].Value = dr["TNPID"];
                sAdapter.UpdateCommand.Parameters.Add("TMNotifyControversyEventID", SqlDbType.Int);
                sAdapter.UpdateCommand.Parameters["TMNotifyControversyEventID"].Value = dr["TMNotifyControversyEventID"];
                sAdapter.UpdateCommand.Parameters.Add("ControversyPaymentID", SqlDbType.Int);
                sAdapter.UpdateCommand.Parameters["ControversyPaymentID"].Value = dr["ControversyPaymentID"];

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
                StringBuilder delString = new StringBuilder("DELETE FROM TrademarkControversyNotifyEventToPaymentT where " + strSQLWhere);
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
                StringBuilder delString = new StringBuilder("DELETE FROM TrademarkControversyNotifyEventToPaymentT where TNPID=@TNPID ");
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
