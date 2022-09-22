using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using H3Operator.DBHelper;

namespace LawtechPTSystemByFirm.Public
{
    #region =====公用資料庫建表=====
    class DataClass
    {
        /// <summary>
        /// /// 建立所屬階段列表，回傳欄位:PhaseName,PhaseValue。
        /// </summary>
        /// <returns></returns>
        internal DataTable CreatePhase()
        {
            DataTable dtPhase = new DataTable();
            dtPhase.Columns.Add("PhaseName");
            dtPhase.Columns.Add("PhaseValue");
            dtPhase.Rows.Add("申請", "1");
            dtPhase.Rows.Add("領證及年費", "2");
            dtPhase.Rows.Add("行政救濟", "3");
            dtPhase.Rows.Add("撤銷", "4");
            dtPhase.Rows.Add("其它", "5");
            return dtPhase;
        }
    }
    #endregion    

      
    #region ======CSubject======
    public class CSubject
    {
        SqlConnection conn = new SqlConnection(DBAccess.ConnectionListDefaultConnectionString);
        SqlDataAdapter sAdapter;
        SqlCommandBuilder CBuilder;

        DataTable dt;
        /// <summary>
        /// 預設帶出所有的資料
        /// </summary>
        public CSubject()
        {
            sAdapter = new SqlDataAdapter("select * from SubjectT", conn);
            dt = new DataTable();
            //DataSet ds = new DataSet();
            //ds.Tables.Add(dt);
            sAdapter.FillSchema(dt, SchemaType.Source);
            sAdapter.Fill(dt);
            CBuilder = new SqlCommandBuilder(sAdapter);
            sAdapter.InsertCommand = CBuilder.GetInsertCommand(true);
            sAdapter.InsertCommand.UpdatedRowSource = UpdateRowSource.Both;
            sAdapter.InsertCommand.CommandText += " Select @@IDENTITY AS 'IDENTITY'";
            sAdapter.UpdateCommand = new SqlCommand(@"UPDATE SubjectT  SET 
                                                       SubjectName=@SubjectName,
                                                       SubjectNameEN=@SubjectNameEN,
                                                       SubjectNameCHS=@SubjectNameCHS,
                                                       sort=@sort
                                                   where 
                                                       SID=@SID", conn);
        }
        /// <summary>
        /// 有條件的過濾資料
        /// </summary>
        /// <param name="sWhere">SQL的條件式</param>
        public CSubject(string sWhere)
        {
            sAdapter = new SqlDataAdapter("select * from SubjectT where " + sWhere, conn);
            dt = new DataTable();
            //DataSet ds = new DataSet();
            //ds.Tables.Add(dt);
            sAdapter.FillSchema(dt, SchemaType.Source);
            sAdapter.Fill(dt);
            CBuilder = new SqlCommandBuilder(sAdapter);
            sAdapter.InsertCommand = CBuilder.GetInsertCommand(true);
            sAdapter.InsertCommand.UpdatedRowSource = UpdateRowSource.Both;
            sAdapter.InsertCommand.CommandText += " Select @@IDENTITY AS 'IDENTITY'";
            sAdapter.UpdateCommand = new SqlCommand(@"UPDATE SubjectT  SET 
                                                       SubjectName=@SubjectName,
                                                       SubjectNameEN=@SubjectNameEN,
                                                       SubjectNameCHS=@SubjectNameCHS,
                                                       sort=@sort
                                                   where 
                                                       SID=@SID", conn);
        }


        private int _SID = -1;
        /// <summary>  
        /// 
        /// </summary>  
        public int SID
        {
            get
            {
                return _SID;
            }
            set
            {
                _SID = value;
            }
        }
        private string _SubjectName = "";
        /// <summary>  
        /// 
        /// </summary>  
        public String SubjectName
        {
            get
            {
                return _SubjectName;
            }
            set
            {
                _SubjectName = value;
            }
        }
        private string _SubjectNameEN = "";
        /// <summary>  
        /// 
        /// </summary>  
        public String SubjectNameEN
        {
            get
            {
                return _SubjectNameEN;
            }
            set
            {
                _SubjectNameEN = value;
            }
        }
        private string _SubjectNameCHS = "";
        /// <summary>  
        /// 
        /// </summary>  
        public String SubjectNameCHS
        {
            get
            {
                return _SubjectNameCHS;
            }
            set
            {
                _SubjectNameCHS = value;
            }
        }
        private int _sort = -1;
        /// <summary>  
        /// 
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

        /// <summary>
        /// 取得SubjectT資料集
        /// </summary>
        public DataTable GetDataTable()
        {
            return dt;
        }

        /// <summary>
        /// 設定SubjectT資料集
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
            string strSQL = "select distinct " + ColumnName + " from SubjectT where " + ColumnName + "='" + Value + "'";
            SqlCommand comm = new SqlCommand(strSQL, conn);
            conn.Open();
            object obj = comm.ExecuteScalar();
            conn.Close();
            if (obj != null)
            {
                bValue = true;
            }
            else
            {
                bValue = false;
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
            string strSQL = "select distinct " + ColumnName + " from SubjectT where " + ColumnName + "=" + Value;
            SqlCommand comm = new SqlCommand(strSQL, conn);
            conn.Open();
            object obj = comm.ExecuteScalar();
            conn.Close();
            if (obj != null)
            {
                bValue = true;
            }
            else
            {
                bValue = false;
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
                this.SID = dr["SID"].ToString() == "" ? -1 : (int)dr["SID"];
                this.SubjectName = dr["SubjectName"].ToString();
                this.SubjectNameEN = dr["SubjectNameEN"].ToString();
                this.SubjectNameCHS = dr["SubjectNameCHS"].ToString();
                this.sort = dr["sort"].ToString() == "" ? -1 : (int)dr["sort"];
            }
            catch
            {
                throw (new System.Exception("SubjectT該筆資料有誤：" + NO.ToString()));
            }
        }
        public void Insert()
        {
            try
            {
                Object Rownull = System.DBNull.Value;
                DataRow dr = dt.NewRow();
                dr["SubjectName"] = this.SubjectName == "" ? Rownull : this.SubjectName;
                dr["SubjectNameEN"] = this.SubjectNameEN == "" ? Rownull : this.SubjectNameEN;
                dr["SubjectNameCHS"] = this.SubjectNameCHS == "" ? Rownull : this.SubjectNameCHS;
                dr["sort"] = this.sort == -1 ? Rownull : this.sort;
                sAdapter.InsertCommand.Parameters["@SubjectName"].Value = dr["SubjectName"];
                sAdapter.InsertCommand.Parameters["@SubjectNameEN"].Value = dr["SubjectNameEN"];
                sAdapter.InsertCommand.Parameters["@SubjectNameCHS"].Value = dr["SubjectNameCHS"];
                sAdapter.InsertCommand.Parameters["@sort"].Value = dr["sort"];
                conn.Open();
                string KEY = sAdapter.InsertCommand.ExecuteScalar().ToString();
                conn.Close();
                if (KEY != "")
                {
                    this.SID = int.Parse(KEY);
                    dr["SID"] = this.SID;
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
                dr["SubjectName"] = this.SubjectName == "" ? Rownull : this.SubjectName;
                dr["SubjectNameEN"] = this.SubjectNameEN == "" ? Rownull : this.SubjectNameEN;
                dr["SubjectNameCHS"] = this.SubjectNameCHS == "" ? Rownull : this.SubjectNameCHS;
                dr["sort"] = this.sort == -1 ? Rownull : this.sort;
                sAdapter.UpdateCommand.Parameters.Clear();
                sAdapter.UpdateCommand.Parameters.Add("SID", SqlDbType.Int);
                sAdapter.UpdateCommand.Parameters["SID"].Value = dr["SID"];
                sAdapter.UpdateCommand.Parameters.Add("SubjectName", SqlDbType.NVarChar);
                sAdapter.UpdateCommand.Parameters["SubjectName"].Value = dr["SubjectName"];
                sAdapter.UpdateCommand.Parameters.Add("SubjectNameEN", SqlDbType.NVarChar);
                sAdapter.UpdateCommand.Parameters["SubjectNameEN"].Value = dr["SubjectNameEN"];
                sAdapter.UpdateCommand.Parameters.Add("SubjectNameCHS", SqlDbType.NVarChar);
                sAdapter.UpdateCommand.Parameters["SubjectNameCHS"].Value = dr["SubjectNameCHS"];
                sAdapter.UpdateCommand.Parameters.Add("sort", SqlDbType.Int);
                sAdapter.UpdateCommand.Parameters["sort"].Value = dr["sort"];

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
                StringBuilder delString = new StringBuilder("DELETE FROM SubjectT where " + strSQLWhere);
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
                StringBuilder delString = new StringBuilder("DELETE FROM SubjectT where SID=@SID ");
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

    #region ======CPetitionSubject======
    public class CPetitionSubject
    {
        SqlConnection conn = new SqlConnection(DBAccess.ConnectionListDefaultConnectionString);
        SqlDataAdapter sAdapter;
        SqlCommandBuilder CBuilder;
        DataTable dt;
        /// <summary>
        /// 預設帶出所有的值
        /// </summary>
        public CPetitionSubject()
        {
            sAdapter = new SqlDataAdapter("select * from PetitionSubjectT", conn);
            dt = new DataTable();
            //DataSet ds = new DataSet();
            //ds.Tables.Add(dt);
            sAdapter.FillSchema(dt, SchemaType.Source);
            sAdapter.Fill(dt);
            CBuilder = new SqlCommandBuilder(sAdapter);
            sAdapter.InsertCommand = CBuilder.GetInsertCommand(true);
            sAdapter.InsertCommand.UpdatedRowSource = UpdateRowSource.Both;
            sAdapter.InsertCommand.CommandText += " Select @@IDENTITY AS 'IDENTITY'";
        }
        /// <summary>
        /// 有條件的過濾條件
        /// </summary>
        /// <param name="sWhere">SQL的條件式</param>
        public CPetitionSubject(string sWhere)
        {
            sAdapter = new SqlDataAdapter("select * from PetitionSubjectT where " + sWhere, conn);
            dt = new DataTable();
            //DataSet ds = new DataSet();
            //ds.Tables.Add(dt);
            sAdapter.FillSchema(dt, SchemaType.Source);
            sAdapter.Fill(dt);
            CBuilder = new SqlCommandBuilder(sAdapter);
            sAdapter.InsertCommand = CBuilder.GetInsertCommand(true);
            sAdapter.InsertCommand.UpdatedRowSource = UpdateRowSource.Both;
            sAdapter.InsertCommand.CommandText += " Select @@IDENTITY AS 'IDENTITY'";
        }

        private int _PID = -1;
        public int PID
        {
            get
            {
                return _PID;
            }
            set
            {
                _PID = value;
            }
        }
        private int _SID = -1;
        public int SID
        {
            get
            {
                return _SID;
            }
            set
            {
                _SID = value;
            }
        }
        private int _PSID = -1;
        public int PSID
        {
            get
            {
                return _PSID;
            }
            set
            {
                _PSID = value;
            }
        }
        private int _sort = -1;
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

        /// <summary>
        /// 取得PetitionSubjectT資料集
        /// </summary>
        public DataTable GetDataTable()
        {
            return dt;
        }

        /// <summary>
        /// 設定PetitionSubjectT資料集
        /// </summary>
        /// <param name="ReTable"></param>
        public void SetDataTable(DataTable ReTable)
        {
            dt = ReTable;
        }

        /// <summary> 
        /// 確認該欄位的值是否重複 
        /// </summary> 
        /// <param name="ColumnName">資料庫欄位名稱</param> 
        /// <param name="Value">欄位的值</param> 
        /// <returns>true:表示沒有這個值  false:表示資料庫已有這個值</returns> 
        public bool CheckValue(string ColumnName, string Value)
        {
            bool bValue = true;
            Value.Replace("'", "").Replace("--", "").Replace("@", "");
            string strSQL = "select count(*) from PetitionSubjectT where " + ColumnName + "='" + Value + "'";
            SqlCommand comm = new SqlCommand(strSQL, conn);
            conn.Open();
            object obj = comm.ExecuteScalar();
            conn.Close();
            if (obj != null && (int)obj == 0)
            {
                bValue = true;
            }
            else
            {
                bValue = false;
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
            string strSQL = "select count(*) from PetitionSubjectT where " + ColumnName + "=" + Value;
            SqlCommand comm = new SqlCommand(strSQL, conn);
            conn.Open();
            object obj = comm.ExecuteScalar();
            conn.Close();
            if (obj != null && (int)obj == 0)
            {
                bValue = true;
            }
            else
            {
                bValue = false;
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
            DataRow dr = dt.Rows.Find(NO);
            this.PID = dr["PID"].ToString() == "" ? -1 : (int)dr["PID"];
            this.SID = dr["SID"].ToString() == "" ? -1 : (int)dr["SID"];
            this.PSID = dr["PSID"].ToString() == "" ? -1 : (int)dr["PSID"];
            this.sort = dr["sort"].ToString() == "" ? -1 : (int)dr["sort"];
        }
        public void Insert()
        {
            try
            {
                Object Rownull = System.DBNull.Value;
                DataRow dr = dt.NewRow();
                dr["PID"] = this.PID == -1 ? Rownull : this.PID;
                dr["SID"] = this.SID == -1 ? Rownull : this.SID;
                dr["PSID"] = 0;
                dr["sort"] = this.sort == -1 ? Rownull : this.sort;
                sAdapter.InsertCommand.Parameters["@PID"].Value = dr["PID"];
                sAdapter.InsertCommand.Parameters["@SID"].Value = dr["SID"];
                sAdapter.InsertCommand.Parameters["@sort"].Value = dr["sort"];
                conn.Open();
                string KEY = sAdapter.InsertCommand.ExecuteScalar().ToString();
                conn.Close();
                if (KEY != "")
                {
                    this.PSID = int.Parse(KEY);
                    dr["PSID"] = this.PSID;
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
                dr["PID"] = this.PID == -1 ? Rownull : this.PID;
                dr["SID"] = this.SID == -1 ? Rownull : this.SID;
                dr["sort"] = this.sort == -1 ? Rownull : this.sort;
                sAdapter.Update(dt);
                dt.AcceptChanges();
            }
            catch (System.Exception EX)
            {
                System.Windows.Forms.MessageBox.Show(EX.Message.Replace("'", ""));
            }
        }
        public void Delete(string No)
        {
            try
            {
                StringBuilder delString = new StringBuilder("DELETE FROM PetitionSubjectT where PSID=");
                for (int i = 0; i < dt.PrimaryKey.Length; i++)
                {
                    switch (dt.PrimaryKey[i].DataType.Name)
                    {
                        case "Int32":
                            delString.Append(No);
                            break;
                        case "String":
                            delString.Append("'" + No + "'");
                            break;
                        case "Int64":
                            delString.Append(No);
                            break;
                    }
                }
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
    }
    #endregion

    #region ======CParagraph======
    public class CParagraph
    {
        SqlConnection conn = new SqlConnection(DBAccess.ConnectionListDefaultConnectionString);
        SqlDataAdapter sAdapter;
        SqlCommandBuilder CBuilder;

        DataTable dt;
        /// <summary>
        /// 預設帶出所有的資料
        /// </summary>
        public CParagraph()
        {
            sAdapter = new SqlDataAdapter("select * from ParagraphT", conn);
            dt = new DataTable();
            //DataSet ds = new DataSet();
            //ds.Tables.Add(dt);
            sAdapter.FillSchema(dt, SchemaType.Source);
            sAdapter.Fill(dt);
            CBuilder = new SqlCommandBuilder(sAdapter);
            sAdapter.InsertCommand = CBuilder.GetInsertCommand(true);
            sAdapter.InsertCommand.UpdatedRowSource = UpdateRowSource.Both;
            sAdapter.InsertCommand.CommandText += " Select @@IDENTITY AS 'IDENTITY'";
            sAdapter.UpdateCommand = new SqlCommand(@"UPDATE ParagraphT  SET 
                                                       PSID=@PSID,
                                                       sort=@sort,
                                                       Paragraph=@Paragraph,
                                                       EditDate=@EditDate,
                                                       ParagraphEN=@ParagraphEN,
                                                       ParagraphCHS=@ParagraphCHS,
                                                       IsOpen=@IsOpen
                                                   where 
                                                       ParaID=@ParaID", conn);
        }
        /// <summary>
        /// 有條件的過濾資料
        /// </summary>
        /// <param name="sWhere">SQL的條件式</param>
        public CParagraph(string sWhere)
        {
            sAdapter = new SqlDataAdapter("select * from ParagraphT where " + sWhere, conn);
            dt = new DataTable();
            //DataSet ds = new DataSet();
            //ds.Tables.Add(dt);
            sAdapter.FillSchema(dt, SchemaType.Source);
            sAdapter.Fill(dt);
            CBuilder = new SqlCommandBuilder(sAdapter);
            sAdapter.InsertCommand = CBuilder.GetInsertCommand(true);
            sAdapter.InsertCommand.UpdatedRowSource = UpdateRowSource.Both;
            sAdapter.InsertCommand.CommandText += " Select @@IDENTITY AS 'IDENTITY'";
            sAdapter.UpdateCommand = new SqlCommand(@"UPDATE ParagraphT  SET 
                                                       PSID=@PSID,
                                                       sort=@sort,
                                                       Paragraph=@Paragraph,
                                                       EditDate=@EditDate,
                                                       ParagraphEN=@ParagraphEN,
                                                       ParagraphCHS=@ParagraphCHS,
                                                       IsOpen=@IsOpen
                                                   where 
                                                       ParaID=@ParaID", conn);
        }


        private int _ParaID = -1;
        /// <summary>  
        /// 
        /// </summary>  
        public int ParaID
        {
            get
            {
                return _ParaID;
            }
            set
            {
                _ParaID = value;
            }
        }
        private int _PSID = -1;
        /// <summary>  
        /// 
        /// </summary>  
        public int PSID
        {
            get
            {
                return _PSID;
            }
            set
            {
                _PSID = value;
            }
        }
        private int _sort = -1;
        /// <summary>  
        /// 
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
        private string _Paragraph = "";
        /// <summary>  
        /// 
        /// </summary>  
        public String Paragraph
        {
            get
            {
                return _Paragraph;
            }
            set
            {
                _Paragraph = value;
            }
        }
        private DateTime _EditDate = DateTime.Parse("1900/1/1");
        /// <summary>  
        /// 
        /// </summary>  
        public DateTime EditDate
        {
            get
            {
                return _EditDate;
            }
            set
            {
                _EditDate = value;
            }
        }
        private string _ParagraphEN = "";
        /// <summary>  
        /// 
        /// </summary>  
        public String ParagraphEN
        {
            get
            {
                return _ParagraphEN;
            }
            set
            {
                _ParagraphEN = value;
            }
        }
        private string _ParagraphCHS = "";
        /// <summary>  
        /// 
        /// </summary>  
        public String ParagraphCHS
        {
            get
            {
                return _ParagraphCHS;
            }
            set
            {
                _ParagraphCHS = value;
            }
        }
        private bool _IsOpen = false;
        /// <summary>  
        /// 
        /// </summary>  
        public bool IsOpen
        {
            get
            {
                return _IsOpen;
            }
            set
            {
                _IsOpen = value;
            }
        }

        /// <summary>
        /// 取得ParagraphT資料集
        /// </summary>
        public DataTable GetDataTable()
        {
            return dt;
        }

        /// <summary>
        /// 設定ParagraphT資料集
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
            string strSQL = "select distinct " + ColumnName + " from ParagraphT where " + ColumnName + "='" + Value + "'";
            SqlCommand comm = new SqlCommand(strSQL, conn);
            conn.Open();
            object obj = comm.ExecuteScalar();
            conn.Close();
            if (obj != null)
            {
                bValue = true;
            }
            else
            {
                bValue = false;
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
            string strSQL = "select distinct " + ColumnName + " from ParagraphT where " + ColumnName + "=" + Value;
            SqlCommand comm = new SqlCommand(strSQL, conn);
            conn.Open();
            object obj = comm.ExecuteScalar();
            conn.Close();
            if (obj != null)
            {
                bValue = true;
            }
            else
            {
                bValue = false;
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
                this.ParaID = dr["ParaID"].ToString() == "" ? -1 : (int)dr["ParaID"];
                this.PSID = dr["PSID"].ToString() == "" ? -1 : (int)dr["PSID"];
                this.sort = dr["sort"].ToString() == "" ? -1 : (int)dr["sort"];
                this.Paragraph = dr["Paragraph"].ToString();
                this.EditDate = dr["EditDate"].ToString() == "" ? DateTime.Parse("1900/1/1") : (DateTime)dr["EditDate"];
                this.ParagraphEN = dr["ParagraphEN"].ToString();
                this.ParagraphCHS = dr["ParagraphCHS"].ToString();
                this.IsOpen = dr["IsOpen"].ToString() == "" ? false : (bool)dr["IsOpen"];
            }
            catch
            {
                throw (new System.Exception("ParagraphT該筆資料有誤：" + NO.ToString()));
            }
        }
        public void Insert()
        {
            try
            {
                Object Rownull = System.DBNull.Value;
                DataRow dr = dt.NewRow();
                dr["PSID"] = this.PSID == -1 ? Rownull : this.PSID;
                dr["sort"] = this.sort == -1 ? Rownull : this.sort;
                dr["Paragraph"] = this.Paragraph == "" ? Rownull : this.Paragraph;
                dr["EditDate"] = this.EditDate.ToShortDateString() == "1900/1/1" ? Rownull : this.EditDate;
                dr["ParagraphEN"] = this.ParagraphEN == "" ? Rownull : this.ParagraphEN;
                dr["ParagraphCHS"] = this.ParagraphCHS == "" ? Rownull : this.ParagraphCHS;
                dr["IsOpen"] = this.IsOpen;
                sAdapter.InsertCommand.Parameters["@PSID"].Value = dr["PSID"];
                sAdapter.InsertCommand.Parameters["@sort"].Value = dr["sort"];
                sAdapter.InsertCommand.Parameters["@Paragraph"].Value = dr["Paragraph"];
                sAdapter.InsertCommand.Parameters["@EditDate"].Value = dr["EditDate"];
                sAdapter.InsertCommand.Parameters["@ParagraphEN"].Value = dr["ParagraphEN"];
                sAdapter.InsertCommand.Parameters["@ParagraphCHS"].Value = dr["ParagraphCHS"];
                sAdapter.InsertCommand.Parameters["@IsOpen"].Value = dr["IsOpen"];
                conn.Open();
                string KEY = sAdapter.InsertCommand.ExecuteScalar().ToString();
                conn.Close();
                if (KEY != "")
                {
                    this.ParaID = int.Parse(KEY);
                    dr["ParaID"] = this.ParaID;
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
                dr["PSID"] = this.PSID == -1 ? Rownull : this.PSID;
                dr["sort"] = this.sort == -1 ? Rownull : this.sort;
                dr["Paragraph"] = this.Paragraph == "" ? Rownull : this.Paragraph;
                dr["EditDate"] = this.EditDate.ToShortDateString() == "1900/1/1" ? Rownull : this.EditDate;
                dr["ParagraphEN"] = this.ParagraphEN == "" ? Rownull : this.ParagraphEN;
                dr["ParagraphCHS"] = this.ParagraphCHS == "" ? Rownull : this.ParagraphCHS;
                dr["IsOpen"] = this.IsOpen;
                sAdapter.UpdateCommand.Parameters.Clear();
                sAdapter.UpdateCommand.Parameters.Add("ParaID", SqlDbType.Int);
                sAdapter.UpdateCommand.Parameters["ParaID"].Value = dr["ParaID"];
                sAdapter.UpdateCommand.Parameters.Add("PSID", SqlDbType.Int);
                sAdapter.UpdateCommand.Parameters["PSID"].Value = dr["PSID"];
                sAdapter.UpdateCommand.Parameters.Add("sort", SqlDbType.Int);
                sAdapter.UpdateCommand.Parameters["sort"].Value = dr["sort"];
                sAdapter.UpdateCommand.Parameters.Add("Paragraph", SqlDbType.NVarChar);
                sAdapter.UpdateCommand.Parameters["Paragraph"].Value = dr["Paragraph"];
                sAdapter.UpdateCommand.Parameters.Add("EditDate", SqlDbType.DateTime);
                sAdapter.UpdateCommand.Parameters["EditDate"].Value = dr["EditDate"];
                sAdapter.UpdateCommand.Parameters.Add("ParagraphEN", SqlDbType.NVarChar);
                sAdapter.UpdateCommand.Parameters["ParagraphEN"].Value = dr["ParagraphEN"];
                sAdapter.UpdateCommand.Parameters.Add("ParagraphCHS", SqlDbType.NVarChar);
                sAdapter.UpdateCommand.Parameters["ParagraphCHS"].Value = dr["ParagraphCHS"];
                sAdapter.UpdateCommand.Parameters.Add("IsOpen", SqlDbType.Bit);
                sAdapter.UpdateCommand.Parameters["IsOpen"].Value = dr["IsOpen"];

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
                StringBuilder delString = new StringBuilder("DELETE FROM ParagraphT where " + strSQLWhere);
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
                StringBuilder delString = new StringBuilder("DELETE FROM ParagraphT where ParaID=@ParaID ");
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

    #region ======CParagraphDetail======
    public class CParagraphDetail
    {
        SqlConnection conn = new SqlConnection(DBAccess.ConnectionListDefaultConnectionString);
        SqlDataAdapter sAdapter;
        SqlCommandBuilder CBuilder;
        static int IndexRow;
        DataTable dt;
        /// <summary>
        /// 預設帶出所有的值
        /// </summary>
        public CParagraphDetail()
        {
            sAdapter = new SqlDataAdapter("select * from ParagraphDetailT", conn);
            dt = new DataTable();
            //DataSet ds = new DataSet();
            //ds.Tables.Add(dt);
            sAdapter.FillSchema(dt, SchemaType.Source);
            sAdapter.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                IndexRow = 0;
            }
            else
            {
                IndexRow = -1;
            }
            CBuilder = new SqlCommandBuilder(sAdapter);
            sAdapter.InsertCommand = CBuilder.GetInsertCommand(true);
            sAdapter.InsertCommand.UpdatedRowSource = UpdateRowSource.Both;
            sAdapter.InsertCommand.CommandText += " Select @@IDENTITY AS 'IDENTITY'";
        }
        /// <summary>
        /// 有條件的過濾條件
        /// </summary>
        /// <param name="sWhere">SQL的條件式</param>
        public CParagraphDetail(string sWhere)
        {
            sAdapter = new SqlDataAdapter("select * from ParagraphDetailT where " + sWhere, conn);
            dt = new DataTable();
            //DataSet ds = new DataSet();
            //ds.Tables.Add(dt);
            sAdapter.FillSchema(dt, SchemaType.Source);
            sAdapter.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                IndexRow = 0;
            }
            else
            {
                IndexRow = -1;
            }
            CBuilder = new SqlCommandBuilder(sAdapter);
            sAdapter.InsertCommand = CBuilder.GetInsertCommand(true);
            sAdapter.InsertCommand.UpdatedRowSource = UpdateRowSource.Both;
            sAdapter.InsertCommand.CommandText += " Select @@IDENTITY AS 'IDENTITY'";
        }

        private int _ParaDetailKEY = -1;
        public int ParaDetailKEY
        {
            get
            {
                return _ParaDetailKEY;
            }
            set
            {
                _ParaDetailKEY = value;
            }
        }
        private int _ParaID = -1;
        public int ParaID
        {
            get
            {
                return _ParaID;
            }
            set
            {
                _ParaID = value;
            }
        }
        private string _detail = "";
        public String detail
        {
            get
            {
                return _detail;
            }
            set
            {
                _detail = value;
            }
        }
        private DateTime _EditDate = DateTime.Parse("1900/1/1");
        public DateTime EditDate
        {
            get
            {
                return _EditDate;
            }
            set
            {
                _EditDate = value;
            }
        }
        private int _EditWorker = -1;
        public int EditWorker
        {
            get
            {
                return _EditWorker;
            }
            set
            {
                _EditWorker = value;
            }
        }
        private int _sort = -1;
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
        private string _UpFilePath = "";
        public String UpFilePath
        {
            get
            {
                return _UpFilePath;
            }
            set
            {
                _UpFilePath = value;
            }
        }

        /// <summary>
        /// 取得ParagraphDetailT資料集
        /// </summary>
        public DataTable GetDataTable()
        {
            return dt;
        }

        /// <summary>
        /// 設定ParagraphDetailT資料集
        /// </summary>
        /// <param name="ReTable"></param>
        public void SetDataTable(DataTable ReTable)
        {
            dt = ReTable;
        }

        /// <summary> 
        /// 確認該欄位的值是否重複 
        /// </summary> 
        /// <param name="ColumnName">資料庫欄位名稱</param> 
        /// <param name="Value">欄位的值</param> 
        /// <returns>true:表示沒有這個值  false:表示資料庫已有這個值</returns> 
        public bool CheckValue(string ColumnName, string Value)
        {
            bool bValue = true;
            Value.Replace("'", "").Replace("--", "").Replace("@", "");
            string strSQL = "select count(*) from ParagraphDetailT where " + ColumnName + "='" + Value + "'";
            SqlCommand comm = new SqlCommand(strSQL, conn);
            conn.Open();
            object obj = comm.ExecuteScalar();
            conn.Close();
            if (obj != null && (int)obj == 0)
            {
                bValue = true;
            }
            else
            {
                bValue = false;
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
            string strSQL = "select count(*) from ParagraphDetailT where " + ColumnName + "=" + Value;
            SqlCommand comm = new SqlCommand(strSQL, conn);
            conn.Open();
            object obj = comm.ExecuteScalar();
            conn.Close();
            if (obj != null && (int)obj == 0)
            {
                bValue = true;
            }
            else
            {
                bValue = false;
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
                this.ParaDetailKEY = dr["ParaDetailKEY"].ToString() == "" ? -1 : (int)dr["ParaDetailKEY"];
                this.ParaID = dr["ParaID"].ToString() == "" ? -1 : (int)dr["ParaID"];
                this.detail = dr["detail"].ToString();
                this.EditDate = dr["EditDate"].ToString() == "" ? DateTime.Parse("1900/1/1") : (DateTime)dr["EditDate"];
                this.EditWorker = dr["EditWorker"].ToString() == "" ? -1 : (int)dr["EditWorker"];
                this.sort = dr["sort"].ToString() == "" ? -1 : (int)dr["sort"];
                this.UpFilePath = dr["UpFilePath"].ToString();
            }
            catch
            {
                throw (new System.Exception("ParagraphDetailT該筆資料有誤：" + NO.ToString()));
            }
        }
        /// <summary>
        /// 第一筆
        /// </summary>
        public void Frist()
        {
            if (dt.Rows.Count > 0)
            {
                SetCurrent((int)dt.Rows[0]["ParaDetailKEY"]);
            }
            else
            {
                IndexRow = -1;
            }
        }
        /// <summary>
        /// 上一筆
        /// </summary>
        public void Previous()
        {
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows.Count - 1 <= IndexRow)
                {
                    IndexRow = dt.Rows.Count - 1;
                }
                else if (IndexRow > 0 && dt.Rows.Count - 1 > IndexRow)
                {
                    IndexRow--;
                }
                SetCurrent((int)dt.Rows[IndexRow]["ParaDetailKEY"]);
            }
            else
            {
                IndexRow = -1;
            }
        }
        /// <summary>
        /// 下一筆
        /// </summary>
        public void next()
        {
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows.Count - 1 <= IndexRow)
                {
                    IndexRow = dt.Rows.Count - 1;
                }
                else if (dt.Rows.Count - 1 > IndexRow)
                {
                    IndexRow++;
                }
                SetCurrent((int)dt.Rows[IndexRow]["ParaDetailKEY"]);
            }
            else
            {
                IndexRow = -1;
            }
        }
        /// <summary>
        /// 最後筆
        /// </summary>
        public void Last()
        {
            if (dt.Rows.Count > 0)
            {
                SetCurrent((int)dt.Rows[dt.Rows.Count - 1]["ParaDetailKEY"]);
            }
            else
            {
                IndexRow = -1;
            }
        }
        public void Insert()
        {
            try
            {
                Object Rownull = System.DBNull.Value;
                DataRow dr = dt.NewRow();
                dr["ParaDetailKEY"] = 0;
                dr["ParaID"] = this.ParaID == -1 ? Rownull : this.ParaID;
                dr["detail"] = this.detail == "" ? Rownull : this.detail;
                dr["EditDate"] = this.EditDate.ToShortDateString() == "1900/1/1" ? Rownull : this.EditDate;
                dr["EditWorker"] = this.EditWorker == -1 ? Rownull : this.EditWorker;
                dr["sort"] = this.sort == -1 ? Rownull : this.sort;
                dr["UpFilePath"] = this.UpFilePath == "" ? Rownull : this.UpFilePath;
                sAdapter.InsertCommand.Parameters["@ParaID"].Value = dr["ParaID"];
                sAdapter.InsertCommand.Parameters["@detail"].Value = dr["detail"];
                sAdapter.InsertCommand.Parameters["@EditDate"].Value = dr["EditDate"];
                sAdapter.InsertCommand.Parameters["@EditWorker"].Value = dr["EditWorker"];
                sAdapter.InsertCommand.Parameters["@sort"].Value = dr["sort"];
                sAdapter.InsertCommand.Parameters["@UpFilePath"].Value = dr["UpFilePath"];
                conn.Open();
                string KEY = sAdapter.InsertCommand.ExecuteScalar().ToString();
                conn.Close();
                if (KEY != "")
                {
                    this.ParaDetailKEY = int.Parse(KEY);
                    dr["ParaDetailKEY"] = this.ParaDetailKEY;
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
                dr["ParaID"] = this.ParaID == -1 ? Rownull : this.ParaID;
                dr["detail"] = this.detail == "" ? Rownull : this.detail;
                dr["EditDate"] = this.EditDate.ToShortDateString() == "1900/1/1" ? Rownull : this.EditDate;
                dr["EditWorker"] = this.EditWorker == -1 ? Rownull : this.EditWorker;
                dr["sort"] = this.sort == -1 ? Rownull : this.sort;
                dr["UpFilePath"] = this.UpFilePath == "" ? Rownull : this.UpFilePath;
                sAdapter.Update(dt);
                dt.AcceptChanges();
            }
            catch (System.Exception EX)
            {
                System.Windows.Forms.MessageBox.Show(EX.Message.Replace("'", ""));
            }
        }
        public void Delete(string No)
        {
            try
            {
                StringBuilder delString = new StringBuilder("DELETE FROM ParagraphDetailT where ParaDetailKEY=");
                for (int i = 0; i < dt.PrimaryKey.Length; i++)
                {
                    switch (dt.PrimaryKey[i].DataType.Name)
                    {
                        case "Int32":
                            delString.Append(No);
                            break;
                        case "String":
                            delString.Append("'" + No + "'");
                            break;
                        case "Int64":
                            delString.Append(No);
                            break;
                    }
                }
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
    }
    #endregion

    #region ======CUpload======
    public class CUpload
    {
        SqlConnection conn = new SqlConnection(DBAccess.ConnectionListDefaultConnectionString);
        SqlDataAdapter sAdapter;
        SqlCommandBuilder CBuilder;

        DataTable dt;
        /// <summary>
        /// 預設帶出所有的資料
        /// </summary>
        public CUpload()
        {
            sAdapter = new SqlDataAdapter("select * from UploadT", conn);
            dt = new DataTable();
            //DataSet ds = new DataSet();
            //ds.Tables.Add(dt);
            sAdapter.FillSchema(dt, SchemaType.Source);
            sAdapter.Fill(dt);
            CBuilder = new SqlCommandBuilder(sAdapter);
            sAdapter.InsertCommand = CBuilder.GetInsertCommand(true);
            sAdapter.InsertCommand.UpdatedRowSource = UpdateRowSource.Both;
            sAdapter.InsertCommand.CommandText += " Select @@IDENTITY AS 'IDENTITY'";
            sAdapter.UpdateCommand = new SqlCommand(@"UPDATE UploadT  SET 
                                                       ArticleTitle=@ArticleTitle,
                                                       Description=@Description,
                                                       Author=@Author,
                                                       KindSN=@KindSN,
                                                       CountrySymbol=@CountrySymbol,
                                                       KeyWods=@KeyWods,
                                                       FilePath=@FilePath,
                                                       BuildDate=@BuildDate,
                                                       BuildWorker=@BuildWorker,
                                                       EditedDate=@EditedDate,
                                                       EditedWorker=@EditedWorker,
                                                       Reference=@Reference,
                                                       RefURL=@RefURL,
                                                       FKEY=@FKEY,
                                                       SubTable=@SubTable
                                                   where 
                                                       UploadKey=@UploadKey", conn);
        }
        /// <summary>
        /// 有條件的過濾資料
        /// </summary>
        /// <param name="sWhere">SQL的條件式</param>
        public CUpload(string sWhere)
        {
            sAdapter = new SqlDataAdapter("select * from UploadT where " + sWhere, conn);
            dt = new DataTable();
            //DataSet ds = new DataSet();
            //ds.Tables.Add(dt);
            sAdapter.FillSchema(dt, SchemaType.Source);
            sAdapter.Fill(dt);
            CBuilder = new SqlCommandBuilder(sAdapter);
            sAdapter.InsertCommand = CBuilder.GetInsertCommand(true);
            sAdapter.InsertCommand.UpdatedRowSource = UpdateRowSource.Both;
            sAdapter.InsertCommand.CommandText += " Select @@IDENTITY AS 'IDENTITY'";
            sAdapter.UpdateCommand = new SqlCommand(@"UPDATE UploadT  SET 
                                                       ArticleTitle=@ArticleTitle,
                                                       Description=@Description,
                                                       Author=@Author,
                                                       KindSN=@KindSN,
                                                       CountrySymbol=@CountrySymbol,
                                                       KeyWods=@KeyWods,
                                                       FilePath=@FilePath,
                                                       BuildDate=@BuildDate,
                                                       BuildWorker=@BuildWorker,
                                                       EditedDate=@EditedDate,
                                                       EditedWorker=@EditedWorker,
                                                       Reference=@Reference,
                                                       RefURL=@RefURL,
                                                       FKEY=@FKEY,
                                                       SubTable=@SubTable
                                                   where 
                                                       UploadKey=@UploadKey", conn);
        }


        private int _UploadKey = -1;
        /// <summary>  
        /// 相關文章檔案
        /// </summary>  
        public int UploadKey
        {
            get
            {
                return _UploadKey;
            }
            set
            {
                _UploadKey = value;
            }
        }
        private string _ArticleTitle = "";
        /// <summary>  
        /// 篇名
        /// </summary>  
        public String ArticleTitle
        {
            get
            {
                return _ArticleTitle;
            }
            set
            {
                _ArticleTitle = value;
            }
        }
        private string _Description = "";
        /// <summary>  
        /// 簡述
        /// </summary>  
        public String Description
        {
            get
            {
                return _Description;
            }
            set
            {
                _Description = value;
            }
        }
        private string _Author = "";
        /// <summary>  
        /// 
        /// </summary>  
        public String Author
        {
            get
            {
                return _Author;
            }
            set
            {
                _Author = value;
            }
        }
        private string _KindSN = "";
        /// <summary>  
        /// 
        /// </summary>  
        public String KindSN
        {
            get
            {
                return _KindSN;
            }
            set
            {
                _KindSN = value;
            }
        }
        private string _CountrySymbol = "";
        /// <summary>  
        /// 國別
        /// </summary>  
        public String CountrySymbol
        {
            get
            {
                return _CountrySymbol;
            }
            set
            {
                _CountrySymbol = value;
            }
        }
        private string _KeyWods = "";
        /// <summary>  
        /// 關鍵字
        /// </summary>  
        public String KeyWods
        {
            get
            {
                return _KeyWods;
            }
            set
            {
                _KeyWods = value;
            }
        }
        private string _FilePath = "";
        /// <summary>  
        /// 檔案路徑
        /// </summary>  
        public String FilePath
        {
            get
            {
                return _FilePath;
            }
            set
            {
                _FilePath = value;
            }
        }
        private DateTime _BuildDate = DateTime.Parse("1900/1/1");
        /// <summary>  
        /// 建立時間
        /// </summary>  
        public DateTime BuildDate
        {
            get
            {
                return _BuildDate;
            }
            set
            {
                _BuildDate = value;
            }
        }
        private int _BuildWorker = -1;
        /// <summary>  
        /// 建立人員
        /// </summary>  
        public int BuildWorker
        {
            get
            {
                return _BuildWorker;
            }
            set
            {
                _BuildWorker = value;
            }
        }
        private DateTime _EditedDate = DateTime.Parse("1900/1/1");
        /// <summary>  
        /// 修改時間
        /// </summary>  
        public DateTime EditedDate
        {
            get
            {
                return _EditedDate;
            }
            set
            {
                _EditedDate = value;
            }
        }
        private int _EditedWorker = -1;
        /// <summary>  
        /// 修改人員
        /// </summary>  
        public int EditedWorker
        {
            get
            {
                return _EditedWorker;
            }
            set
            {
                _EditedWorker = value;
            }
        }
        private string _Reference = "";
        /// <summary>  
        /// 
        /// </summary>  
        public String Reference
        {
            get
            {
                return _Reference;
            }
            set
            {
                _Reference = value;
            }
        }
        private string _RefURL = "";
        /// <summary>  
        /// 網路位置
        /// </summary>  
        public String RefURL
        {
            get
            {
                return _RefURL;
            }
            set
            {
                _RefURL = value;
            }
        }
        private int _FKEY = -1;
        /// <summary>  
        /// 
        /// </summary>  
        public int FKEY
        {
            get
            {
                return _FKEY;
            }
            set
            {
                _FKEY = value;
            }
        }
        private int _SubTable = -1;
        /// <summary>  
        /// 
        /// </summary>  
        public int SubTable
        {
            get
            {
                return _SubTable;
            }
            set
            {
                _SubTable = value;
            }
        }

        /// <summary>
        /// 取得UploadT資料集
        /// </summary>
        public DataTable GetDataTable()
        {
            return dt;
        }

        /// <summary>
        /// 設定UploadT資料集
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
            string strSQL = "select count(" + ColumnName + ") as CountValue from UploadT where " + ColumnName + "='" + Value + "'";
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
            string strSQL = "select count(" + ColumnName + ") as CountValue from UploadT where " + ColumnName + "=" + Value;
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
                this.UploadKey = dr["UploadKey"].ToString() == "" ? -1 : (int)dr["UploadKey"];
                this.ArticleTitle = dr["ArticleTitle"].ToString();
                this.Description = dr["Description"].ToString();
                this.Author = dr["Author"].ToString();
                this.KindSN = dr["KindSN"].ToString();
                this.CountrySymbol = dr["CountrySymbol"].ToString();
                this.KeyWods = dr["KeyWods"].ToString();
                this.FilePath = dr["FilePath"].ToString();
                this.BuildDate = dr["BuildDate"].ToString() == "" ? DateTime.Parse("1900/1/1") : (DateTime)dr["BuildDate"];
                this.BuildWorker = dr["BuildWorker"].ToString() == "" ? -1 : (int)dr["BuildWorker"];
                this.EditedDate = dr["EditedDate"].ToString() == "" ? DateTime.Parse("1900/1/1") : (DateTime)dr["EditedDate"];
                this.EditedWorker = dr["EditedWorker"].ToString() == "" ? -1 : (int)dr["EditedWorker"];
                this.Reference = dr["Reference"].ToString();
                this.RefURL = dr["RefURL"].ToString();
                this.FKEY = dr["FKEY"].ToString() == "" ? -1 : (int)dr["FKEY"];
                this.SubTable = dr["SubTable"].ToString() == "" ? -1 : (int)dr["SubTable"];
            }
            catch
            {
                throw (new System.Exception("UploadT該筆資料有誤：" + NO.ToString()));
            }
        }
        public void Insert()
        {
            try
            {
                Object Rownull = System.DBNull.Value;
                DataRow dr = dt.NewRow();
                dr["ArticleTitle"] = this.ArticleTitle == "" ? Rownull : this.ArticleTitle;
                dr["Description"] = this.Description == "" ? Rownull : this.Description;
                dr["Author"] = this.Author == "" ? Rownull : this.Author;
                dr["KindSN"] = this.KindSN == "" ? Rownull : this.KindSN;
                dr["CountrySymbol"] = this.CountrySymbol == "" ? Rownull : this.CountrySymbol;
                dr["KeyWods"] = this.KeyWods == "" ? Rownull : this.KeyWods;
                dr["FilePath"] = this.FilePath == "" ? Rownull : this.FilePath;
                dr["BuildDate"] = this.BuildDate.ToShortDateString() == "1900/1/1" ? Rownull : this.BuildDate;
                dr["BuildWorker"] = this.BuildWorker == -1 ? Rownull : this.BuildWorker;
                dr["EditedDate"] = this.EditedDate.ToShortDateString() == "1900/1/1" ? Rownull : this.EditedDate;
                dr["EditedWorker"] = this.EditedWorker == -1 ? Rownull : this.EditedWorker;
                dr["Reference"] = this.Reference == "" ? Rownull : this.Reference;
                dr["RefURL"] = this.RefURL == "" ? Rownull : this.RefURL;
                dr["FKEY"] = this.FKEY == -1 ? Rownull : this.FKEY;
                dr["SubTable"] = this.SubTable == -1 ? Rownull : this.SubTable;
                sAdapter.InsertCommand.Parameters["@ArticleTitle"].Value = dr["ArticleTitle"];
                sAdapter.InsertCommand.Parameters["@Description"].Value = dr["Description"];
                sAdapter.InsertCommand.Parameters["@Author"].Value = dr["Author"];
                sAdapter.InsertCommand.Parameters["@KindSN"].Value = dr["KindSN"];
                sAdapter.InsertCommand.Parameters["@CountrySymbol"].Value = dr["CountrySymbol"];
                sAdapter.InsertCommand.Parameters["@KeyWods"].Value = dr["KeyWods"];
                sAdapter.InsertCommand.Parameters["@FilePath"].Value = dr["FilePath"];
                sAdapter.InsertCommand.Parameters["@BuildDate"].Value = dr["BuildDate"];
                sAdapter.InsertCommand.Parameters["@BuildWorker"].Value = dr["BuildWorker"];
                sAdapter.InsertCommand.Parameters["@EditedDate"].Value = dr["EditedDate"];
                sAdapter.InsertCommand.Parameters["@EditedWorker"].Value = dr["EditedWorker"];
                sAdapter.InsertCommand.Parameters["@Reference"].Value = dr["Reference"];
                sAdapter.InsertCommand.Parameters["@RefURL"].Value = dr["RefURL"];
                sAdapter.InsertCommand.Parameters["@FKEY"].Value = dr["FKEY"];
                sAdapter.InsertCommand.Parameters["@SubTable"].Value = dr["SubTable"];
                conn.Open();
                string KEY = sAdapter.InsertCommand.ExecuteScalar().ToString();
                conn.Close();
                if (KEY != "")
                {
                    this.UploadKey = int.Parse(KEY);
                    dr["UploadKey"] = this.UploadKey;
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
                dr["ArticleTitle"] = this.ArticleTitle == "" ? Rownull : this.ArticleTitle;
                dr["Description"] = this.Description == "" ? Rownull : this.Description;
                dr["Author"] = this.Author == "" ? Rownull : this.Author;
                dr["KindSN"] = this.KindSN == "" ? Rownull : this.KindSN;
                dr["CountrySymbol"] = this.CountrySymbol == "" ? Rownull : this.CountrySymbol;
                dr["KeyWods"] = this.KeyWods == "" ? Rownull : this.KeyWods;
                dr["FilePath"] = this.FilePath == "" ? Rownull : this.FilePath;
                dr["BuildDate"] = this.BuildDate.ToShortDateString() == "1900/1/1" ? Rownull : this.BuildDate;
                dr["BuildWorker"] = this.BuildWorker == -1 ? Rownull : this.BuildWorker;
                dr["EditedDate"] = this.EditedDate.ToShortDateString() == "1900/1/1" ? Rownull : this.EditedDate;
                dr["EditedWorker"] = this.EditedWorker == -1 ? Rownull : this.EditedWorker;
                dr["Reference"] = this.Reference == "" ? Rownull : this.Reference;
                dr["RefURL"] = this.RefURL == "" ? Rownull : this.RefURL;
                dr["FKEY"] = this.FKEY == -1 ? Rownull : this.FKEY;
                dr["SubTable"] = this.SubTable == -1 ? Rownull : this.SubTable;
                sAdapter.UpdateCommand.Parameters.Clear();
                sAdapter.UpdateCommand.Parameters.Add("UploadKey", SqlDbType.Int);
                sAdapter.UpdateCommand.Parameters["UploadKey"].Value = dr["UploadKey"];
                sAdapter.UpdateCommand.Parameters.Add("ArticleTitle", SqlDbType.NVarChar);
                sAdapter.UpdateCommand.Parameters["ArticleTitle"].Value = dr["ArticleTitle"];
                sAdapter.UpdateCommand.Parameters.Add("Description", SqlDbType.NVarChar);
                sAdapter.UpdateCommand.Parameters["Description"].Value = dr["Description"];
                sAdapter.UpdateCommand.Parameters.Add("Author", SqlDbType.NVarChar);
                sAdapter.UpdateCommand.Parameters["Author"].Value = dr["Author"];
                sAdapter.UpdateCommand.Parameters.Add("KindSN", SqlDbType.NVarChar);
                sAdapter.UpdateCommand.Parameters["KindSN"].Value = dr["KindSN"];
                sAdapter.UpdateCommand.Parameters.Add("CountrySymbol", SqlDbType.NVarChar);
                sAdapter.UpdateCommand.Parameters["CountrySymbol"].Value = dr["CountrySymbol"];
                sAdapter.UpdateCommand.Parameters.Add("KeyWods", SqlDbType.NVarChar);
                sAdapter.UpdateCommand.Parameters["KeyWods"].Value = dr["KeyWods"];
                sAdapter.UpdateCommand.Parameters.Add("FilePath", SqlDbType.NVarChar);
                sAdapter.UpdateCommand.Parameters["FilePath"].Value = dr["FilePath"];
                sAdapter.UpdateCommand.Parameters.Add("BuildDate", SqlDbType.SmallDateTime);
                sAdapter.UpdateCommand.Parameters["BuildDate"].Value = dr["BuildDate"];
                sAdapter.UpdateCommand.Parameters.Add("BuildWorker", SqlDbType.Int);
                sAdapter.UpdateCommand.Parameters["BuildWorker"].Value = dr["BuildWorker"];
                sAdapter.UpdateCommand.Parameters.Add("EditedDate", SqlDbType.SmallDateTime);
                sAdapter.UpdateCommand.Parameters["EditedDate"].Value = dr["EditedDate"];
                sAdapter.UpdateCommand.Parameters.Add("EditedWorker", SqlDbType.Int);
                sAdapter.UpdateCommand.Parameters["EditedWorker"].Value = dr["EditedWorker"];
                sAdapter.UpdateCommand.Parameters.Add("Reference", SqlDbType.NVarChar);
                sAdapter.UpdateCommand.Parameters["Reference"].Value = dr["Reference"];
                sAdapter.UpdateCommand.Parameters.Add("RefURL", SqlDbType.NVarChar);
                sAdapter.UpdateCommand.Parameters["RefURL"].Value = dr["RefURL"];
                sAdapter.UpdateCommand.Parameters.Add("FKEY", SqlDbType.Int);
                sAdapter.UpdateCommand.Parameters["FKEY"].Value = dr["FKEY"];
                sAdapter.UpdateCommand.Parameters.Add("SubTable", SqlDbType.Int);
                sAdapter.UpdateCommand.Parameters["SubTable"].Value = dr["SubTable"];

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
                StringBuilder delString = new StringBuilder("DELETE FROM UploadT where " + strSQLWhere);
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
                StringBuilder delString = new StringBuilder("DELETE FROM UploadT where UploadKey=@UploadKey ");
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

    #region ======CKeyWords======
    public class CKeyWords
    {
        SqlConnection conn = new SqlConnection(DBAccess.ConnectionListDefaultConnectionString);
        SqlDataAdapter sAdapter;
        SqlCommandBuilder CBuilder;
        DataTable dt;
        /// <summary>
        /// 預設帶出所有的值
        /// </summary>
        public CKeyWords()
        {
            sAdapter = new SqlDataAdapter("select * from KeyWordsT", conn);
            dt = new DataTable();
            //DataSet ds = new DataSet();
            //ds.Tables.Add(dt);
            sAdapter.FillSchema(dt, SchemaType.Source);
            sAdapter.Fill(dt);
            CBuilder = new SqlCommandBuilder(sAdapter);
            sAdapter.InsertCommand = CBuilder.GetInsertCommand(true);
            sAdapter.InsertCommand.UpdatedRowSource = UpdateRowSource.Both;
            sAdapter.InsertCommand.CommandText += " Select @@IDENTITY AS 'IDENTITY'";
        }
        /// <summary>
        /// 有條件的過濾條件
        /// </summary>
        /// <param name="sWhere">SQL的條件式</param>
        public CKeyWords(string sWhere)
        {
            sAdapter = new SqlDataAdapter("select * from KeyWordsT where " + sWhere, conn);
            dt = new DataTable();
            //DataSet ds = new DataSet();
            //ds.Tables.Add(dt);
            sAdapter.FillSchema(dt, SchemaType.Source);
            sAdapter.Fill(dt);
            CBuilder = new SqlCommandBuilder(sAdapter);
            sAdapter.InsertCommand = CBuilder.GetInsertCommand(true);
            sAdapter.InsertCommand.UpdatedRowSource = UpdateRowSource.Both;
            sAdapter.InsertCommand.CommandText += " Select @@IDENTITY AS 'IDENTITY'";
        }

        private int _SN = -1;
        public int SN
        {
            get
            {
                return _SN;
            }
            set
            {
                _SN = value;
            }
        }
        private string _KeyWord = "";
        public String KeyWord
        {
            get
            {
                return _KeyWord;
            }
            set
            {
                _KeyWord = value;
            }
        }
        private int _pkey = -1;
        public int pkey
        {
            get
            {
                return _pkey;
            }
            set
            {
                _pkey = value;
            }
        }

        /// <summary>
        /// 取得KeyWordsT資料集
        /// </summary>
        public DataTable GetDataTable()
        {
            return dt;
        }

        /// <summary>
        /// 設定KeyWordsT資料集
        /// </summary>
        /// <param name="ReTable"></param>
        public void SetDataTable(DataTable ReTable)
        {
            dt = ReTable;
        }

        /// <summary> 
        /// 確認該欄位的值是否重複 
        /// </summary> 
        /// <param name="ColumnName">資料庫欄位名稱</param> 
        /// <param name="Value">欄位的值</param> 
        /// <returns>true:表示沒有這個值  false:表示資料庫已有這個值</returns> 
        public bool CheckValue(string ColumnName, string Value)
        {
            bool bValue = true;
            Value.Replace("'", "").Replace("--", "").Replace("@", "");
            string strSQL = "select count(*) from KeyWordsT where " + ColumnName + "='" + Value + "'";
            SqlCommand comm = new SqlCommand(strSQL, conn);
            conn.Open();
            object obj = comm.ExecuteScalar();
            conn.Close();
            if (obj != null && (int)obj == 0)
            {
                bValue = true;
            }
            else
            {
                bValue = false;
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
            string strSQL = "select count(*) from KeyWordsT where " + ColumnName + "=" + Value;
            SqlCommand comm = new SqlCommand(strSQL, conn);
            conn.Open();
            object obj = comm.ExecuteScalar();
            conn.Close();
            if (obj != null && (int)obj == 0)
            {
                bValue = true;
            }
            else
            {
                bValue = false;
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
            DataRow dr = dt.Rows.Find(NO);
            this.SN = dr["SN"].ToString() == "" ? -1 : (int)dr["SN"];
            this.KeyWord = dr["KeyWord"].ToString();
            this.pkey = dr["pkey"].ToString() == "" ? -1 : (int)dr["pkey"];
        }
        public void Insert()
        {
            try
            {
                Object Rownull = System.DBNull.Value;
                DataRow dr = dt.NewRow();
                dr["SN"] = this.SN == -1 ? Rownull : this.SN;
                dr["KeyWord"] = this.KeyWord == "" ? Rownull : this.KeyWord;
                dr["pkey"] = 0;
                sAdapter.InsertCommand.Parameters["@SN"].Value = dr["SN"];
                sAdapter.InsertCommand.Parameters["@KeyWord"].Value = dr["KeyWord"];
                conn.Open();
                string KEY = sAdapter.InsertCommand.ExecuteScalar().ToString();
                conn.Close();
                if (KEY != "")
                {
                    this.pkey = int.Parse(KEY);
                    dr["pkey"] = this.pkey;
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
                dr["SN"] = this.SN == -1 ? Rownull : this.SN;
                dr["KeyWord"] = this.KeyWord == "" ? Rownull : this.KeyWord;
                sAdapter.Update(dt);
                dt.AcceptChanges();
            }
            catch (System.Exception EX)
            {
                System.Windows.Forms.MessageBox.Show(EX.Message.Replace("'", ""));
            }
        }
        public void Delete(string No)
        {
            try
            {
                StringBuilder delString = new StringBuilder("DELETE FROM KeyWordsT where pkey=");
                for (int i = 0; i < dt.PrimaryKey.Length; i++)
                {
                    switch (dt.PrimaryKey[i].DataType.Name)
                    {
                        case "Int32":
                            delString.Append(No);
                            break;
                        case "String":
                            delString.Append("'" + No + "'");
                            break;
                        case "Int64":
                            delString.Append(No);
                            break;
                    }
                }
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
    }
    #endregion 
        
    #region ======CPatNotifyContent======
    public class CPatNotifyContent
    {
        SqlConnection conn = new SqlConnection(DBAccess.ConnectionListDefaultConnectionString);
        SqlDataAdapter sAdapter;
        SqlCommandBuilder CBuilder;

        DataTable dt;
        /// <summary>
        /// 預設帶出所有的資料
        /// </summary>
        public CPatNotifyContent()
        {
            sAdapter = new SqlDataAdapter("select * from PatNotifyContentT", conn);
            dt = new DataTable();
            //DataSet ds = new DataSet();
            //ds.Tables.Add(dt);
            sAdapter.FillSchema(dt, SchemaType.Source);
            sAdapter.Fill(dt);
            CBuilder = new SqlCommandBuilder(sAdapter);
            sAdapter.InsertCommand = CBuilder.GetInsertCommand(true);
            sAdapter.InsertCommand.UpdatedRowSource = UpdateRowSource.Both;
            sAdapter.InsertCommand.CommandText += " Select @@IDENTITY AS 'IDENTITY'";
            sAdapter.UpdateCommand = new SqlCommand(@"UPDATE PatNotifyContentT  SET 
                                                       Country=@Country,
                                                       Sort=@Sort,
                                                       NotifyContent=@NotifyContent,
                                                       Status=@Status,
                                                       Note=@Note,
                                                       NotifyPhase=@NotifyPhase
                                                   where 
                                                       NotifyContentID=@NotifyContentID", conn);
        }
        /// <summary>
        /// 有條件的過濾資料
        /// </summary>
        /// <param name="sWhere">SQL的條件式</param>
        public CPatNotifyContent(string sWhere)
        {
            sAdapter = new SqlDataAdapter("select * from PatNotifyContentT where " + sWhere, conn);
            dt = new DataTable();
            //DataSet ds = new DataSet();
            //ds.Tables.Add(dt);
            sAdapter.FillSchema(dt, SchemaType.Source);
            sAdapter.Fill(dt);
            CBuilder = new SqlCommandBuilder(sAdapter);
            sAdapter.InsertCommand = CBuilder.GetInsertCommand(true);
            sAdapter.InsertCommand.UpdatedRowSource = UpdateRowSource.Both;
            sAdapter.InsertCommand.CommandText += " Select @@IDENTITY AS 'IDENTITY'";
            sAdapter.UpdateCommand = new SqlCommand(@"UPDATE PatNotifyContentT  SET 
                                                       Country=@Country,
                                                       Sort=@Sort,
                                                       NotifyContent=@NotifyContent,
                                                       Status=@Status,
                                                       Note=@Note,
                                                       NotifyPhase=@NotifyPhase
                                                   where 
                                                       NotifyContentID=@NotifyContentID", conn);
        }


        private int _NotifyContentID = -1;
        /// <summary>  
        /// 
        /// </summary>  
        public int NotifyContentID
        {
            get
            {
                return _NotifyContentID;
            }
            set
            {
                _NotifyContentID = value;
            }
        }
        private string _Country = "";
        /// <summary>  
        /// 
        /// </summary>  
        public String Country
        {
            get
            {
                return _Country;
            }
            set
            {
                _Country = value;
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
        private string _NotifyContent = "";
        /// <summary>  
        /// 
        /// </summary>  
        public String NotifyContent
        {
            get
            {
                return _NotifyContent;
            }
            set
            {
                _NotifyContent = value;
            }
        }
        private int _Status = -1;
        /// <summary>  
        /// 
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
        private string _Note = "";
        /// <summary>  
        /// 
        /// </summary>  
        public String Note
        {
            get
            {
                return _Note;
            }
            set
            {
                _Note = value;
            }
        }
        private int _NotifyPhase = -1;
        /// <summary>  
        /// 
        /// </summary>  
        public int NotifyPhase
        {
            get
            {
                return _NotifyPhase;
            }
            set
            {
                _NotifyPhase = value;
            }
        }

        /// <summary>
        /// 取得PatNotifyContentT資料集
        /// </summary>
        public DataTable GetDataTable()
        {
            return dt;
        }

        /// <summary>
        /// 設定PatNotifyContentT資料集
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
            string strSQL = "select count(*) from PatNotifyContentT where " + ColumnName + "='" + Value + "'";
            SqlCommand comm = new SqlCommand(strSQL, conn);
            conn.Open();
            object obj = comm.ExecuteScalar();
            conn.Close();
            if (obj != null && (int)obj == 0)
            {
                bValue = true;
            }
            else
            {
                bValue = false;
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
            string strSQL = "select count(*) from PatNotifyContentT where " + ColumnName + "=" + Value;
            SqlCommand comm = new SqlCommand(strSQL, conn);
            conn.Open();
            object obj = comm.ExecuteScalar();
            conn.Close();
            if (obj != null && (int)obj == 0)
            {
                bValue = true;
            }
            else
            {
                bValue = false;
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
                this.NotifyContentID = dr["NotifyContentID"].ToString() == "" ? -1 : (int)dr["NotifyContentID"];
                this.Country = dr["Country"].ToString();
                this.Sort = dr["Sort"].ToString() == "" ? -1 : (int)dr["Sort"];
                this.NotifyContent = dr["NotifyContent"].ToString();
                this.Status = dr["Status"].ToString() == "" ? -1 : (int)dr["Status"];
                this.Note = dr["Note"].ToString();
                this.NotifyPhase = dr["NotifyPhase"].ToString() == "" ? -1 : (int)dr["NotifyPhase"];
            }
            catch
            {
                throw (new System.Exception("PatNotifyContentT該筆資料有誤：" + NO.ToString()));
            }
        }
        public void Insert()
        {
            try
            {
                Object Rownull = System.DBNull.Value;
                DataRow dr = dt.NewRow();
                dr["Country"] = this.Country == "" ? Rownull : this.Country;
                dr["Sort"] = this.Sort == -1 ? Rownull : this.Sort;
                dr["NotifyContent"] = this.NotifyContent == "" ? Rownull : this.NotifyContent;
                dr["Status"] = this.Status == -1 ? Rownull : this.Status;
                dr["Note"] = this.Note == "" ? Rownull : this.Note;
                dr["NotifyPhase"] = this.NotifyPhase == -1 ? Rownull : this.NotifyPhase;
                sAdapter.InsertCommand.Parameters["@Country"].Value = dr["Country"];
                sAdapter.InsertCommand.Parameters["@Sort"].Value = dr["Sort"];
                sAdapter.InsertCommand.Parameters["@NotifyContent"].Value = dr["NotifyContent"];
                sAdapter.InsertCommand.Parameters["@Status"].Value = dr["Status"];
                sAdapter.InsertCommand.Parameters["@Note"].Value = dr["Note"];
                sAdapter.InsertCommand.Parameters["@NotifyPhase"].Value = dr["NotifyPhase"];
                conn.Open();
                string KEY = sAdapter.InsertCommand.ExecuteScalar().ToString();
                conn.Close();
                if (KEY != "")
                {
                    this.NotifyContentID = int.Parse(KEY);
                    dr["NotifyContentID"] = this.NotifyContentID;
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
                dr["Country"] = this.Country == "" ? Rownull : this.Country;
                dr["Sort"] = this.Sort == -1 ? Rownull : this.Sort;
                dr["NotifyContent"] = this.NotifyContent == "" ? Rownull : this.NotifyContent;
                dr["Status"] = this.Status == -1 ? Rownull : this.Status;
                dr["Note"] = this.Note == "" ? Rownull : this.Note;
                dr["NotifyPhase"] = this.NotifyPhase == -1 ? Rownull : this.NotifyPhase;
                sAdapter.UpdateCommand.Parameters.Clear();
                sAdapter.UpdateCommand.Parameters.Add("NotifyContentID", SqlDbType.Int);
                sAdapter.UpdateCommand.Parameters["NotifyContentID"].Value = dr["NotifyContentID"];
                sAdapter.UpdateCommand.Parameters.Add("Country", SqlDbType.NVarChar);
                sAdapter.UpdateCommand.Parameters["Country"].Value = dr["Country"];
                sAdapter.UpdateCommand.Parameters.Add("Sort", SqlDbType.Int);
                sAdapter.UpdateCommand.Parameters["Sort"].Value = dr["Sort"];
                sAdapter.UpdateCommand.Parameters.Add("NotifyContent", SqlDbType.NVarChar);
                sAdapter.UpdateCommand.Parameters["NotifyContent"].Value = dr["NotifyContent"];
                sAdapter.UpdateCommand.Parameters.Add("Status", SqlDbType.Int);
                sAdapter.UpdateCommand.Parameters["Status"].Value = dr["Status"];
                sAdapter.UpdateCommand.Parameters.Add("Note", SqlDbType.NVarChar);
                sAdapter.UpdateCommand.Parameters["Note"].Value = dr["Note"];
                sAdapter.UpdateCommand.Parameters.Add("NotifyPhase", SqlDbType.Int);
                sAdapter.UpdateCommand.Parameters["NotifyPhase"].Value = dr["NotifyPhase"];

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
                StringBuilder delString = new StringBuilder("DELETE FROM PatNotifyContentT where " + strSQLWhere);
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
                StringBuilder delString = new StringBuilder("DELETE FROM PatNotifyContentT where NotifyContentID=@NotifyContentID ");
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

    #region ======CPatNotifyDue======
    public class CPatNotifyDue
    {
        SqlConnection conn = new SqlConnection(DBAccess.ConnectionListDefaultConnectionString);
        SqlDataAdapter sAdapter;
        SqlCommandBuilder CBuilder;

        DataTable dt;
        /// <summary>
        /// 預設帶出所有的資料
        /// </summary>
        public CPatNotifyDue()
        {
            sAdapter = new SqlDataAdapter("select * from PatNotifyDueT", conn);
            dt = new DataTable();
            //DataSet ds = new DataSet();
            //ds.Tables.Add(dt);
            sAdapter.FillSchema(dt, SchemaType.Source);
            sAdapter.Fill(dt);
            CBuilder = new SqlCommandBuilder(sAdapter);
            sAdapter.InsertCommand = CBuilder.GetInsertCommand(true);
            sAdapter.InsertCommand.UpdatedRowSource = UpdateRowSource.Both;
            sAdapter.InsertCommand.CommandText += " Select @@IDENTITY AS 'IDENTITY'";
            sAdapter.UpdateCommand = new SqlCommand(@"UPDATE PatNotifyDueT  SET 
                                                       Sort=@Sort,
                                                       NotifyContent=@NotifyContent,
                                                       Status=@Status,
                                                       Country=@Country,
                                                       Note=@Note,
                                                       Answer=@Answer,
                                                       AnswerTime=@AnswerTime,
                                                       TimeUnit=@TimeUnit,
                                                       StartDate=@StartDate,
                                                       ASday=@ASday,
                                                       FeePhase=@FeePhase,
                                                       ProcessKEY=@ProcessKEY
                                                   where 
                                                       PatNotifyDueID=@PatNotifyDueID", conn);
        }
        /// <summary>
        /// 有條件的過濾資料
        /// </summary>
        /// <param name="sWhere">SQL的條件式</param>
        public CPatNotifyDue(string sWhere)
        {
            sAdapter = new SqlDataAdapter("select * from PatNotifyDueT where " + sWhere, conn);
            dt = new DataTable();
            //DataSet ds = new DataSet();
            //ds.Tables.Add(dt);
            sAdapter.FillSchema(dt, SchemaType.Source);
            sAdapter.Fill(dt);
            CBuilder = new SqlCommandBuilder(sAdapter);
            sAdapter.InsertCommand = CBuilder.GetInsertCommand(true);
            sAdapter.InsertCommand.UpdatedRowSource = UpdateRowSource.Both;
            sAdapter.InsertCommand.CommandText += " Select @@IDENTITY AS 'IDENTITY'";
            sAdapter.UpdateCommand = new SqlCommand(@"UPDATE PatNotifyDueT  SET 
                                                       Sort=@Sort,
                                                       NotifyContent=@NotifyContent,
                                                       Status=@Status,
                                                       Country=@Country,
                                                       Note=@Note,
                                                       Answer=@Answer,
                                                       AnswerTime=@AnswerTime,
                                                       TimeUnit=@TimeUnit,
                                                       StartDate=@StartDate,
                                                       ASday=@ASday,
                                                       FeePhase=@FeePhase,
                                                       ProcessKEY=@ProcessKEY
                                                   where 
                                                       PatNotifyDueID=@PatNotifyDueID", conn);
        }


        private int _PatNotifyDueID = -1;
        /// <summary>  
        /// PK(專利期限來函表)
        /// </summary>  
        public int PatNotifyDueID
        {
            get
            {
                return _PatNotifyDueID;
            }
            set
            {
                _PatNotifyDueID = value;
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
        private string _NotifyContent = "";
        /// <summary>  
        /// 
        /// </summary>  
        public String NotifyContent
        {
            get
            {
                return _NotifyContent;
            }
            set
            {
                _NotifyContent = value;
            }
        }
        private int _Status = -1;
        /// <summary>  
        /// 對應的專利案件狀態
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
        private string _Country = "";
        /// <summary>  
        /// 國別
        /// </summary>  
        public String Country
        {
            get
            {
                return _Country;
            }
            set
            {
                _Country = value;
            }
        }
        private string _Note = "";
        /// <summary>  
        /// 提醒訊息
        /// </summary>  
        public String Note
        {
            get
            {
                return _Note;
            }
            set
            {
                _Note = value;
            }
        }
        private string _Answer = "";
        /// <summary>  
        /// 應答覆之程序
        /// </summary>  
        public String Answer
        {
            get
            {
                return _Answer;
            }
            set
            {
                _Answer = value;
            }
        }
        private int _AnswerTime = -1;
        /// <summary>  
        /// 答覆時間
        /// </summary>  
        public int AnswerTime
        {
            get
            {
                return _AnswerTime;
            }
            set
            {
                _AnswerTime = value;
            }
        }
        private int _TimeUnit = -1;
        /// <summary>  
        /// 時間單位
        /// </summary>  
        public int TimeUnit
        {
            get
            {
                return _TimeUnit;
            }
            set
            {
                _TimeUnit = value;
            }
        }
        private int _StartDate = -1;
        /// <summary>  
        /// (官方發文日,官方送達日)
        /// </summary>  
        public int StartDate
        {
            get
            {
                return _StartDate;
            }
            set
            {
                _StartDate = value;
            }
        }
        private int _ASday = -1;
        /// <summary>  
        /// 加減天數
        /// </summary>  
        public int ASday
        {
            get
            {
                return _ASday;
            }
            set
            {
                _ASday = value;
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
        private int _ProcessKEY = -1;
        /// <summary>  
        /// 觸發的專利事件
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
        /// 取得PatNotifyDueT資料集
        /// </summary>
        public DataTable GetDataTable()
        {
            return dt;
        }

        /// <summary>
        /// 設定PatNotifyDueT資料集
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
            string strSQL = "select count(*) from PatNotifyDueT where " + ColumnName + "='" + Value + "'";
            SqlCommand comm = new SqlCommand(strSQL, conn);
            conn.Open();
            object obj = comm.ExecuteScalar();
            conn.Close();
            if (obj != null && (int)obj == 0)
            {
                bValue = true;
            }
            else
            {
                bValue = false;
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
            string strSQL = "select count(*) from PatNotifyDueT where " + ColumnName + "=" + Value;
            SqlCommand comm = new SqlCommand(strSQL, conn);
            conn.Open();
            object obj = comm.ExecuteScalar();
            conn.Close();
            if (obj != null && (int)obj == 0)
            {
                bValue = true;
            }
            else
            {
                bValue = false;
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
                this.PatNotifyDueID = dr["PatNotifyDueID"].ToString() == "" ? -1 : (int)dr["PatNotifyDueID"];
                this.Sort = dr["Sort"].ToString() == "" ? -1 : (int)dr["Sort"];
                this.NotifyContent = dr["NotifyContent"].ToString();
                this.Status = dr["Status"].ToString() == "" ? -1 : (int)dr["Status"];
                this.Country = dr["Country"].ToString();
                this.Note = dr["Note"].ToString();
                this.Answer = dr["Answer"].ToString();
                this.AnswerTime = dr["AnswerTime"].ToString() == "" ? -1 : (int)dr["AnswerTime"];
                this.TimeUnit = dr["TimeUnit"].ToString() == "" ? -1 : (int)dr["TimeUnit"];
                this.StartDate = dr["StartDate"].ToString() == "" ? -1 : (int)dr["StartDate"];
                this.ASday = dr["ASday"].ToString() == "" ? -1 : (int)dr["ASday"];
                this.FeePhase = dr["FeePhase"].ToString() == "" ? -1 : (int)dr["FeePhase"];
                this.ProcessKEY = dr["ProcessKEY"].ToString() == "" ? -1 : (int)dr["ProcessKEY"];
            }
            catch
            {
                throw (new System.Exception("PatNotifyDueT該筆資料有誤：" + NO.ToString()));
            }
        }
        public void Insert()
        {
            try
            {
                Object Rownull = System.DBNull.Value;
                DataRow dr = dt.NewRow();
                dr["Sort"] = this.Sort == -1 ? Rownull : this.Sort;
                dr["NotifyContent"] = this.NotifyContent == "" ? Rownull : this.NotifyContent;
                dr["Status"] = this.Status == -1 ? Rownull : this.Status;
                dr["Country"] = this.Country == "" ? Rownull : this.Country;
                dr["Note"] = this.Note == "" ? Rownull : this.Note;
                dr["Answer"] = this.Answer == "" ? Rownull : this.Answer;
                dr["AnswerTime"] = this.AnswerTime == -1 ? Rownull : this.AnswerTime;
                dr["TimeUnit"] = this.TimeUnit == -1 ? Rownull : this.TimeUnit;
                dr["StartDate"] = this.StartDate == -1 ? Rownull : this.StartDate;
                dr["ASday"] = this.ASday == -1 ? Rownull : this.ASday;
                dr["FeePhase"] = this.FeePhase == -1 ? Rownull : this.FeePhase;
                dr["ProcessKEY"] = this.ProcessKEY == -1 ? Rownull : this.ProcessKEY;
                sAdapter.InsertCommand.Parameters["@Sort"].Value = dr["Sort"];
                sAdapter.InsertCommand.Parameters["@NotifyContent"].Value = dr["NotifyContent"];
                sAdapter.InsertCommand.Parameters["@Status"].Value = dr["Status"];
                sAdapter.InsertCommand.Parameters["@Country"].Value = dr["Country"];
                sAdapter.InsertCommand.Parameters["@Note"].Value = dr["Note"];
                sAdapter.InsertCommand.Parameters["@Answer"].Value = dr["Answer"];
                sAdapter.InsertCommand.Parameters["@AnswerTime"].Value = dr["AnswerTime"];
                sAdapter.InsertCommand.Parameters["@TimeUnit"].Value = dr["TimeUnit"];
                sAdapter.InsertCommand.Parameters["@StartDate"].Value = dr["StartDate"];
                sAdapter.InsertCommand.Parameters["@ASday"].Value = dr["ASday"];
                sAdapter.InsertCommand.Parameters["@FeePhase"].Value = dr["FeePhase"];
                sAdapter.InsertCommand.Parameters["@ProcessKEY"].Value = dr["ProcessKEY"];
                conn.Open();
                string KEY = sAdapter.InsertCommand.ExecuteScalar().ToString();
                conn.Close();
                if (KEY != "")
                {
                    this.PatNotifyDueID = int.Parse(KEY);
                    dr["PatNotifyDueID"] = this.PatNotifyDueID;
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
                dr["Sort"] = this.Sort == -1 ? Rownull : this.Sort;
                dr["NotifyContent"] = this.NotifyContent == "" ? Rownull : this.NotifyContent;
                dr["Status"] = this.Status == -1 ? Rownull : this.Status;
                dr["Country"] = this.Country == "" ? Rownull : this.Country;
                dr["Note"] = this.Note == "" ? Rownull : this.Note;
                dr["Answer"] = this.Answer == "" ? Rownull : this.Answer;
                dr["AnswerTime"] = this.AnswerTime == -1 ? Rownull : this.AnswerTime;
                dr["TimeUnit"] = this.TimeUnit == -1 ? Rownull : this.TimeUnit;
                dr["StartDate"] = this.StartDate == -1 ? Rownull : this.StartDate;
                dr["ASday"] = this.ASday == -1 ? Rownull : this.ASday;
                dr["FeePhase"] = this.FeePhase == -1 ? Rownull : this.FeePhase;
                dr["ProcessKEY"] = this.ProcessKEY == -1 ? Rownull : this.ProcessKEY;
                sAdapter.UpdateCommand.Parameters.Clear();
                sAdapter.UpdateCommand.Parameters.Add("PatNotifyDueID", SqlDbType.Int);
                sAdapter.UpdateCommand.Parameters["PatNotifyDueID"].Value = dr["PatNotifyDueID"];
                sAdapter.UpdateCommand.Parameters.Add("Sort", SqlDbType.Int);
                sAdapter.UpdateCommand.Parameters["Sort"].Value = dr["Sort"];
                sAdapter.UpdateCommand.Parameters.Add("NotifyContent", SqlDbType.NVarChar);
                sAdapter.UpdateCommand.Parameters["NotifyContent"].Value = dr["NotifyContent"];
                sAdapter.UpdateCommand.Parameters.Add("Status", SqlDbType.Int);
                sAdapter.UpdateCommand.Parameters["Status"].Value = dr["Status"];
                sAdapter.UpdateCommand.Parameters.Add("Country", SqlDbType.NVarChar);
                sAdapter.UpdateCommand.Parameters["Country"].Value = dr["Country"];
                sAdapter.UpdateCommand.Parameters.Add("Note", SqlDbType.NVarChar);
                sAdapter.UpdateCommand.Parameters["Note"].Value = dr["Note"];
                sAdapter.UpdateCommand.Parameters.Add("Answer", SqlDbType.NVarChar);
                sAdapter.UpdateCommand.Parameters["Answer"].Value = dr["Answer"];
                sAdapter.UpdateCommand.Parameters.Add("AnswerTime", SqlDbType.Int);
                sAdapter.UpdateCommand.Parameters["AnswerTime"].Value = dr["AnswerTime"];
                sAdapter.UpdateCommand.Parameters.Add("TimeUnit", SqlDbType.Int);
                sAdapter.UpdateCommand.Parameters["TimeUnit"].Value = dr["TimeUnit"];
                sAdapter.UpdateCommand.Parameters.Add("StartDate", SqlDbType.Int);
                sAdapter.UpdateCommand.Parameters["StartDate"].Value = dr["StartDate"];
                sAdapter.UpdateCommand.Parameters.Add("ASday", SqlDbType.Int);
                sAdapter.UpdateCommand.Parameters["ASday"].Value = dr["ASday"];
                sAdapter.UpdateCommand.Parameters.Add("FeePhase", SqlDbType.Int);
                sAdapter.UpdateCommand.Parameters["FeePhase"].Value = dr["FeePhase"];
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
                StringBuilder delString = new StringBuilder("DELETE FROM PatNotifyDueT where " + strSQLWhere);
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
                StringBuilder delString = new StringBuilder("DELETE FROM PatNotifyDueT where PatNotifyDueID=@PatNotifyDueID ");
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
   
    #region ======CPatNotifyEvent======
    public class CPatNotifyEvent
    {
        SqlConnection conn = new SqlConnection(DBAccess.ConnectionListDefaultConnectionString);
        SqlDataAdapter sAdapter;
        SqlCommandBuilder CBuilder;

        DataTable dt;
        /// <summary>
        /// 預設帶出所有的資料
        /// </summary>
        public CPatNotifyEvent()
        {
            sAdapter = new SqlDataAdapter("select * from PatNotifyEventT", conn);
            dt = new DataTable();
            //DataSet ds = new DataSet();
            //ds.Tables.Add(dt);
            sAdapter.FillSchema(dt, SchemaType.Source);
            sAdapter.Fill(dt);
            CBuilder = new SqlCommandBuilder(sAdapter);
            sAdapter.InsertCommand = CBuilder.GetInsertCommand(true);
            sAdapter.InsertCommand.UpdatedRowSource = UpdateRowSource.Both;
            sAdapter.InsertCommand.CommandText += " Select @@IDENTITY AS 'IDENTITY'";
            sAdapter.UpdateCommand = new SqlCommand(@"UPDATE PatNotifyEventT  SET 
                                                       PatentID=@PatentID,
                                                       OccurDate=@OccurDate,
                                                       NotifyEventContent=@NotifyEventContent,
                                                       NotifyResult=@NotifyResult,
                                                       NotifyComitDate=@NotifyComitDate,
                                                       NotifyOfficerDate=@NotifyOfficerDate,
                                                       DueDate=@DueDate,
                                                       NotifyAttorneyDueDate=@NotifyAttorneyDueDate,
                                                       NotifyStartDate=@NotifyStartDate,
                                                       FinishDate=@FinishDate,
                                                       WorkerKey=@WorkerKey,
                                                       AttorneyKey=@AttorneyKey,
                                                       ALiaisonerKey=@ALiaisonerKey,
                                                       NotifyRespond=@NotifyRespond,
                                                       NotifyRemark=@NotifyRemark,
                                                       UpbuildDate=@UpbuildDate,
                                                       LastModifyDate=@LastModifyDate,
                                                       LastModifyWorker=@LastModifyWorker
                                                   where 
                                                       PatNotifyEventID=@PatNotifyEventID", conn);
        }
        /// <summary>
        /// 有條件的過濾資料
        /// </summary>
        /// <param name="sWhere">SQL的條件式</param>
        public CPatNotifyEvent(string sWhere)
        {
            sAdapter = new SqlDataAdapter("select * from PatNotifyEventT where " + sWhere, conn);
            dt = new DataTable();
            //DataSet ds = new DataSet();
            //ds.Tables.Add(dt);
            sAdapter.FillSchema(dt, SchemaType.Source);
            sAdapter.Fill(dt);
            CBuilder = new SqlCommandBuilder(sAdapter);
            sAdapter.InsertCommand = CBuilder.GetInsertCommand(true);
            sAdapter.InsertCommand.UpdatedRowSource = UpdateRowSource.Both;
            sAdapter.InsertCommand.CommandText += " Select @@IDENTITY AS 'IDENTITY'";
            sAdapter.UpdateCommand = new SqlCommand(@"UPDATE PatNotifyEventT  SET 
                                                       PatentID=@PatentID,
                                                       OccurDate=@OccurDate,
                                                       NotifyEventContent=@NotifyEventContent,
                                                       NotifyResult=@NotifyResult,
                                                       NotifyComitDate=@NotifyComitDate,
                                                       NotifyOfficerDate=@NotifyOfficerDate,
                                                       DueDate=@DueDate,
                                                       NotifyAttorneyDueDate=@NotifyAttorneyDueDate,
                                                       NotifyStartDate=@NotifyStartDate,
                                                       FinishDate=@FinishDate,
                                                       WorkerKey=@WorkerKey,
                                                       AttorneyKey=@AttorneyKey,
                                                       ALiaisonerKey=@ALiaisonerKey,
                                                       NotifyRespond=@NotifyRespond,
                                                       NotifyRemark=@NotifyRemark,
                                                       UpbuildDate=@UpbuildDate,
                                                       LastModifyDate=@LastModifyDate,
                                                       LastModifyWorker=@LastModifyWorker
                                                   where 
                                                       PatNotifyEventID=@PatNotifyEventID", conn);
        }


        private int _PatNotifyEventID = -1;
        /// <summary>  
        /// 申請案來函記錄 PK
        /// </summary>  
        public int PatNotifyEventID
        {
            get
            {
                return _PatNotifyEventID;
            }
            set
            {
                _PatNotifyEventID = value;
            }
        }
        private int _PatentID = -1;
        /// <summary>  
        /// 專利資料表 PK
        /// </summary>  
        public int PatentID
        {
            get
            {
                return _PatentID;
            }
            set
            {
                _PatentID = value;
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
        private string _NotifyResult = "";
        /// <summary>  
        /// 處理結果
        /// </summary>  
        public String NotifyResult
        {
            get
            {
                return _NotifyResult;
            }
            set
            {
                _NotifyResult = value;
            }
        }
        private DateTime _NotifyComitDate = DateTime.Parse("1900/1/1");
        /// <summary>  
        /// 來函收文日
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
        /// 法定答覆期限
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
        private DateTime _NotifyAttorneyDueDate = DateTime.Parse("1900/1/1");
        /// <summary>  
        /// 事務所答覆期限
        /// </summary>  
        public DateTime NotifyAttorneyDueDate
        {
            get
            {
                return _NotifyAttorneyDueDate;
            }
            set
            {
                _NotifyAttorneyDueDate = value;
            }
        }
        private DateTime _NotifyStartDate = DateTime.Parse("1900/1/1");
        /// <summary>  
        /// 送件日期
        /// </summary>  
        public DateTime NotifyStartDate
        {
            get
            {
                return _NotifyStartDate;
            }
            set
            {
                _NotifyStartDate = value;
            }
        }
        private DateTime _FinishDate = DateTime.Parse("1900/1/1");
        /// <summary>  
        /// 完成時間
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
        private int _WorkerKey = -1;
        /// <summary>  
        /// 申請案承辦人
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
        private int _AttorneyKey = -1;
        /// <summary>  
        /// 承辦事務所
        /// </summary>  
        public int AttorneyKey
        {
            get
            {
                return _AttorneyKey;
            }
            set
            {
                _AttorneyKey = value;
            }
        }
        private int _ALiaisonerKey = -1;
        /// <summary>  
        /// 事務所承辦人
        /// </summary>  
        public int ALiaisonerKey
        {
            get
            {
                return _ALiaisonerKey;
            }
            set
            {
                _ALiaisonerKey = value;
            }
        }
        private string _NotifyRespond = "";
        /// <summary>  
        /// 應答覆程序
        /// </summary>  
        public String NotifyRespond
        {
            get
            {
                return _NotifyRespond;
            }
            set
            {
                _NotifyRespond = value;
            }
        }
        private string _NotifyRemark = "";
        /// <summary>  
        /// 
        /// </summary>  
        public String NotifyRemark
        {
            get
            {
                return _NotifyRemark;
            }
            set
            {
                _NotifyRemark = value;
            }
        }
        private DateTime _UpbuildDate = DateTime.Parse("1900/1/1");
        /// <summary>  
        /// 建立日期
        /// </summary>  
        public DateTime UpbuildDate
        {
            get
            {
                return _UpbuildDate;
            }
            set
            {
                _UpbuildDate = value;
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

        /// <summary>
        /// 取得PatNotifyEventT資料集
        /// </summary>
        public DataTable GetDataTable()
        {
            return dt;
        }

        /// <summary>
        /// 設定PatNotifyEventT資料集
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
            string strSQL = "select distinct " + ColumnName + " from PatNotifyEventT where " + ColumnName + "='" + Value + "'";
            SqlCommand comm = new SqlCommand(strSQL, conn);
            conn.Open();
            object obj = comm.ExecuteScalar();
            conn.Close();
            if (obj != null)
            {
                bValue = true;
            }
            else
            {
                bValue = false;
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
            string strSQL = "select distinct " + ColumnName + " from PatNotifyEventT where " + ColumnName + "=" + Value;
            SqlCommand comm = new SqlCommand(strSQL, conn);
            conn.Open();
            object obj = comm.ExecuteScalar();
            conn.Close();
            if (obj != null)
            {
                bValue = true;
            }
            else
            {
                bValue = false;
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
                this.PatNotifyEventID = dr["PatNotifyEventID"].ToString() == "" ? -1 : (int)dr["PatNotifyEventID"];
                this.PatentID = dr["PatentID"].ToString() == "" ? -1 : (int)dr["PatentID"];
                this.OccurDate = dr["OccurDate"].ToString() == "" ? DateTime.Parse("1900/1/1") : (DateTime)dr["OccurDate"];
                this.NotifyEventContent = dr["NotifyEventContent"].ToString();
                this.NotifyResult = dr["NotifyResult"].ToString();
                this.NotifyComitDate = dr["NotifyComitDate"].ToString() == "" ? DateTime.Parse("1900/1/1") : (DateTime)dr["NotifyComitDate"];
                this.NotifyOfficerDate = dr["NotifyOfficerDate"].ToString() == "" ? DateTime.Parse("1900/1/1") : (DateTime)dr["NotifyOfficerDate"];
                this.DueDate = dr["DueDate"].ToString() == "" ? DateTime.Parse("1900/1/1") : (DateTime)dr["DueDate"];
                this.NotifyAttorneyDueDate = dr["NotifyAttorneyDueDate"].ToString() == "" ? DateTime.Parse("1900/1/1") : (DateTime)dr["NotifyAttorneyDueDate"];
                this.NotifyStartDate = dr["NotifyStartDate"].ToString() == "" ? DateTime.Parse("1900/1/1") : (DateTime)dr["NotifyStartDate"];
                this.FinishDate = dr["FinishDate"].ToString() == "" ? DateTime.Parse("1900/1/1") : (DateTime)dr["FinishDate"];
                this.WorkerKey = dr["WorkerKey"].ToString() == "" ? -1 : (int)dr["WorkerKey"];
                this.AttorneyKey = dr["AttorneyKey"].ToString() == "" ? -1 : (int)dr["AttorneyKey"];
                this.ALiaisonerKey = dr["ALiaisonerKey"].ToString() == "" ? -1 : (int)dr["ALiaisonerKey"];
                this.NotifyRespond = dr["NotifyRespond"].ToString();
                this.NotifyRemark = dr["NotifyRemark"].ToString();
                this.UpbuildDate = dr["UpbuildDate"].ToString() == "" ? DateTime.Parse("1900/1/1") : (DateTime)dr["UpbuildDate"];
                this.LastModifyDate = dr["LastModifyDate"].ToString() == "" ? DateTime.Parse("1900/1/1") : (DateTime)dr["LastModifyDate"];
                this.LastModifyWorker = dr["LastModifyWorker"].ToString() == "" ? -1 : (int)dr["LastModifyWorker"];
            }
            catch
            {
                throw (new System.Exception("PatNotifyEventT該筆資料有誤：" + NO.ToString()));
            }
        }
        public void Insert()
        {
            try
            {
                Object Rownull = System.DBNull.Value;
                DataRow dr = dt.NewRow();
                dr["PatentID"] = this.PatentID == -1 ? Rownull : this.PatentID;
                dr["OccurDate"] = this.OccurDate.ToShortDateString() == "1900/1/1" ? Rownull : this.OccurDate;
                dr["NotifyEventContent"] = this.NotifyEventContent == "" ? Rownull : this.NotifyEventContent;
                dr["NotifyResult"] = this.NotifyResult == "" ? Rownull : this.NotifyResult;
                dr["NotifyComitDate"] = this.NotifyComitDate.ToShortDateString() == "1900/1/1" ? Rownull : this.NotifyComitDate;
                dr["NotifyOfficerDate"] = this.NotifyOfficerDate.ToShortDateString() == "1900/1/1" ? Rownull : this.NotifyOfficerDate;
                dr["DueDate"] = this.DueDate.ToShortDateString() == "1900/1/1" ? Rownull : this.DueDate;
                dr["NotifyAttorneyDueDate"] = this.NotifyAttorneyDueDate.ToShortDateString() == "1900/1/1" ? Rownull : this.NotifyAttorneyDueDate;
                dr["NotifyStartDate"] = this.NotifyStartDate.ToShortDateString() == "1900/1/1" ? Rownull : this.NotifyStartDate;
                dr["FinishDate"] = this.FinishDate.ToShortDateString() == "1900/1/1" ? Rownull : this.FinishDate;
                dr["WorkerKey"] = this.WorkerKey == -1 ? Rownull : this.WorkerKey;
                dr["AttorneyKey"] = this.AttorneyKey == -1 ? Rownull : this.AttorneyKey;
                dr["ALiaisonerKey"] = this.ALiaisonerKey == -1 ? Rownull : this.ALiaisonerKey;
                dr["NotifyRespond"] = this.NotifyRespond == "" ? Rownull : this.NotifyRespond;
                dr["NotifyRemark"] = this.NotifyRemark == "" ? Rownull : this.NotifyRemark;
                dr["UpbuildDate"] = this.UpbuildDate.ToShortDateString() == "1900/1/1" ? Rownull : this.UpbuildDate;
                dr["LastModifyDate"] = this.LastModifyDate.ToShortDateString() == "1900/1/1" ? Rownull : this.LastModifyDate;
                dr["LastModifyWorker"] = this.LastModifyWorker == -1 ? Rownull : this.LastModifyWorker;
                sAdapter.InsertCommand.Parameters["@PatentID"].Value = dr["PatentID"];
                sAdapter.InsertCommand.Parameters["@OccurDate"].Value = dr["OccurDate"];
                sAdapter.InsertCommand.Parameters["@NotifyEventContent"].Value = dr["NotifyEventContent"];
                sAdapter.InsertCommand.Parameters["@NotifyResult"].Value = dr["NotifyResult"];
                sAdapter.InsertCommand.Parameters["@NotifyComitDate"].Value = dr["NotifyComitDate"];
                sAdapter.InsertCommand.Parameters["@NotifyOfficerDate"].Value = dr["NotifyOfficerDate"];
                sAdapter.InsertCommand.Parameters["@DueDate"].Value = dr["DueDate"];
                sAdapter.InsertCommand.Parameters["@NotifyAttorneyDueDate"].Value = dr["NotifyAttorneyDueDate"];
                sAdapter.InsertCommand.Parameters["@NotifyStartDate"].Value = dr["NotifyStartDate"];
                sAdapter.InsertCommand.Parameters["@FinishDate"].Value = dr["FinishDate"];
                sAdapter.InsertCommand.Parameters["@WorkerKey"].Value = dr["WorkerKey"];
                sAdapter.InsertCommand.Parameters["@AttorneyKey"].Value = dr["AttorneyKey"];
                sAdapter.InsertCommand.Parameters["@ALiaisonerKey"].Value = dr["ALiaisonerKey"];
                sAdapter.InsertCommand.Parameters["@NotifyRespond"].Value = dr["NotifyRespond"];
                sAdapter.InsertCommand.Parameters["@NotifyRemark"].Value = dr["NotifyRemark"];
                sAdapter.InsertCommand.Parameters["@UpbuildDate"].Value = dr["UpbuildDate"];
                sAdapter.InsertCommand.Parameters["@LastModifyDate"].Value = dr["LastModifyDate"];
                sAdapter.InsertCommand.Parameters["@LastModifyWorker"].Value = dr["LastModifyWorker"];
                conn.Open();
                string KEY = sAdapter.InsertCommand.ExecuteScalar().ToString();
                conn.Close();
                if (KEY != "")
                {
                    this.PatNotifyEventID = int.Parse(KEY);
                    dr["PatNotifyEventID"] = this.PatNotifyEventID;
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
                dr["PatentID"] = this.PatentID == -1 ? Rownull : this.PatentID;
                dr["OccurDate"] = this.OccurDate.ToShortDateString() == "1900/1/1" ? Rownull : this.OccurDate;
                dr["NotifyEventContent"] = this.NotifyEventContent == "" ? Rownull : this.NotifyEventContent;
                dr["NotifyResult"] = this.NotifyResult == "" ? Rownull : this.NotifyResult;
                dr["NotifyComitDate"] = this.NotifyComitDate.ToShortDateString() == "1900/1/1" ? Rownull : this.NotifyComitDate;
                dr["NotifyOfficerDate"] = this.NotifyOfficerDate.ToShortDateString() == "1900/1/1" ? Rownull : this.NotifyOfficerDate;
                dr["DueDate"] = this.DueDate.ToShortDateString() == "1900/1/1" ? Rownull : this.DueDate;
                dr["NotifyAttorneyDueDate"] = this.NotifyAttorneyDueDate.ToShortDateString() == "1900/1/1" ? Rownull : this.NotifyAttorneyDueDate;
                dr["NotifyStartDate"] = this.NotifyStartDate.ToShortDateString() == "1900/1/1" ? Rownull : this.NotifyStartDate;
                dr["FinishDate"] = this.FinishDate.ToShortDateString() == "1900/1/1" ? Rownull : this.FinishDate;
                dr["WorkerKey"] = this.WorkerKey == -1 ? Rownull : this.WorkerKey;
                dr["AttorneyKey"] = this.AttorneyKey == -1 ? Rownull : this.AttorneyKey;
                dr["ALiaisonerKey"] = this.ALiaisonerKey == -1 ? Rownull : this.ALiaisonerKey;
                dr["NotifyRespond"] = this.NotifyRespond == "" ? Rownull : this.NotifyRespond;
                dr["NotifyRemark"] = this.NotifyRemark == "" ? Rownull : this.NotifyRemark;
                dr["UpbuildDate"] = this.UpbuildDate.ToShortDateString() == "1900/1/1" ? Rownull : this.UpbuildDate;
                dr["LastModifyDate"] = this.LastModifyDate.ToShortDateString() == "1900/1/1" ? Rownull : this.LastModifyDate;
                dr["LastModifyWorker"] = this.LastModifyWorker == -1 ? Rownull : this.LastModifyWorker;
                sAdapter.UpdateCommand.Parameters.Clear();
                sAdapter.UpdateCommand.Parameters.Add("PatNotifyEventID", SqlDbType.Int);
                sAdapter.UpdateCommand.Parameters["PatNotifyEventID"].Value = dr["PatNotifyEventID"];
                sAdapter.UpdateCommand.Parameters.Add("PatentID", SqlDbType.Int);
                sAdapter.UpdateCommand.Parameters["PatentID"].Value = dr["PatentID"];
                sAdapter.UpdateCommand.Parameters.Add("OccurDate", SqlDbType.DateTime);
                sAdapter.UpdateCommand.Parameters["OccurDate"].Value = dr["OccurDate"];
                sAdapter.UpdateCommand.Parameters.Add("NotifyEventContent", SqlDbType.NVarChar);
                sAdapter.UpdateCommand.Parameters["NotifyEventContent"].Value = dr["NotifyEventContent"];
                sAdapter.UpdateCommand.Parameters.Add("NotifyResult", SqlDbType.NVarChar);
                sAdapter.UpdateCommand.Parameters["NotifyResult"].Value = dr["NotifyResult"];
                sAdapter.UpdateCommand.Parameters.Add("NotifyComitDate", SqlDbType.DateTime);
                sAdapter.UpdateCommand.Parameters["NotifyComitDate"].Value = dr["NotifyComitDate"];
                sAdapter.UpdateCommand.Parameters.Add("NotifyOfficerDate", SqlDbType.DateTime);
                sAdapter.UpdateCommand.Parameters["NotifyOfficerDate"].Value = dr["NotifyOfficerDate"];
                sAdapter.UpdateCommand.Parameters.Add("DueDate", SqlDbType.DateTime);
                sAdapter.UpdateCommand.Parameters["DueDate"].Value = dr["DueDate"];
                sAdapter.UpdateCommand.Parameters.Add("NotifyAttorneyDueDate", SqlDbType.DateTime);
                sAdapter.UpdateCommand.Parameters["NotifyAttorneyDueDate"].Value = dr["NotifyAttorneyDueDate"];
                sAdapter.UpdateCommand.Parameters.Add("NotifyStartDate", SqlDbType.DateTime);
                sAdapter.UpdateCommand.Parameters["NotifyStartDate"].Value = dr["NotifyStartDate"];
                sAdapter.UpdateCommand.Parameters.Add("FinishDate", SqlDbType.DateTime);
                sAdapter.UpdateCommand.Parameters["FinishDate"].Value = dr["FinishDate"];
                sAdapter.UpdateCommand.Parameters.Add("WorkerKey", SqlDbType.Int);
                sAdapter.UpdateCommand.Parameters["WorkerKey"].Value = dr["WorkerKey"];
                sAdapter.UpdateCommand.Parameters.Add("AttorneyKey", SqlDbType.Int);
                sAdapter.UpdateCommand.Parameters["AttorneyKey"].Value = dr["AttorneyKey"];
                sAdapter.UpdateCommand.Parameters.Add("ALiaisonerKey", SqlDbType.Int);
                sAdapter.UpdateCommand.Parameters["ALiaisonerKey"].Value = dr["ALiaisonerKey"];
                sAdapter.UpdateCommand.Parameters.Add("NotifyRespond", SqlDbType.NVarChar);
                sAdapter.UpdateCommand.Parameters["NotifyRespond"].Value = dr["NotifyRespond"];
                sAdapter.UpdateCommand.Parameters.Add("NotifyRemark", SqlDbType.NVarChar);
                sAdapter.UpdateCommand.Parameters["NotifyRemark"].Value = dr["NotifyRemark"];
                sAdapter.UpdateCommand.Parameters.Add("UpbuildDate", SqlDbType.DateTime);
                sAdapter.UpdateCommand.Parameters["UpbuildDate"].Value = dr["UpbuildDate"];
                sAdapter.UpdateCommand.Parameters.Add("LastModifyDate", SqlDbType.DateTime);
                sAdapter.UpdateCommand.Parameters["LastModifyDate"].Value = dr["LastModifyDate"];
                sAdapter.UpdateCommand.Parameters.Add("LastModifyWorker", SqlDbType.Int);
                sAdapter.UpdateCommand.Parameters["LastModifyWorker"].Value = dr["LastModifyWorker"];

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
                StringBuilder delString = new StringBuilder("DELETE FROM PatNotifyEventT where " + strSQLWhere);
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
                StringBuilder delString = new StringBuilder("DELETE FROM PatNotifyEventT where PatNotifyEventID=@PatNotifyEventID ");
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

    #region ======CPatNotifyEventToFee======
    public class CPatNotifyEventToFee
    {
        SqlConnection conn = new SqlConnection(DBAccess.ConnectionListDefaultConnectionString);
        SqlDataAdapter sAdapter;
        SqlCommandBuilder CBuilder;

        DataTable dt;
        /// <summary>
        /// 預設帶出所有的資料
        /// </summary>
        public CPatNotifyEventToFee()
        {
            sAdapter = new SqlDataAdapter("select * from PatNotifyEventToFeeT", conn);
            dt = new DataTable();
            //DataSet ds = new DataSet();
            //ds.Tables.Add(dt);
            sAdapter.FillSchema(dt, SchemaType.Source);
            sAdapter.Fill(dt);
            CBuilder = new SqlCommandBuilder(sAdapter);
            sAdapter.InsertCommand = CBuilder.GetInsertCommand(true);
            sAdapter.InsertCommand.UpdatedRowSource = UpdateRowSource.Both;
            sAdapter.InsertCommand.CommandText += " Select @@IDENTITY AS 'IDENTITY'";
            sAdapter.UpdateCommand = new SqlCommand(@"UPDATE PatNotifyEventToFeeT  SET 
                                                       PatNotifyEventID=@PatNotifyEventID,
                                                       FeeKEY=@FeeKEY
                                                   where 
                                                       NFID=@NFID", conn);
        }
        /// <summary>
        /// 有條件的過濾資料
        /// </summary>
        /// <param name="sWhere">SQL的條件式</param>
        public CPatNotifyEventToFee(string sWhere)
        {
            sAdapter = new SqlDataAdapter("select * from PatNotifyEventToFeeT where " + sWhere, conn);
            dt = new DataTable();
            //DataSet ds = new DataSet();
            //ds.Tables.Add(dt);
            sAdapter.FillSchema(dt, SchemaType.Source);
            sAdapter.Fill(dt);
            CBuilder = new SqlCommandBuilder(sAdapter);
            sAdapter.InsertCommand = CBuilder.GetInsertCommand(true);
            sAdapter.InsertCommand.UpdatedRowSource = UpdateRowSource.Both;
            sAdapter.InsertCommand.CommandText += " Select @@IDENTITY AS 'IDENTITY'";
            sAdapter.UpdateCommand = new SqlCommand(@"UPDATE PatNotifyEventToFeeT  SET 
                                                       PatNotifyEventID=@PatNotifyEventID,
                                                       FeeKEY=@FeeKEY
                                                   where 
                                                       NFID=@NFID", conn);
        }


        private int _NFID = -1;
        /// <summary>  
        /// 來函轉請款表
        /// </summary>  
        public int NFID
        {
            get
            {
                return _NFID;
            }
            set
            {
                _NFID = value;
            }
        }
        private int _PatNotifyEventID = -1;
        /// <summary>  
        /// 
        /// </summary>  
        public int PatNotifyEventID
        {
            get
            {
                return _PatNotifyEventID;
            }
            set
            {
                _PatNotifyEventID = value;
            }
        }
        private int _FeeKEY = -1;
        /// <summary>  
        /// 
        /// </summary>  
        public int FeeKEY
        {
            get
            {
                return _FeeKEY;
            }
            set
            {
                _FeeKEY = value;
            }
        }

        /// <summary>
        /// 取得PatNotifyEventToFeeT資料集
        /// </summary>
        public DataTable GetDataTable()
        {
            return dt;
        }

        /// <summary>
        /// 設定PatNotifyEventToFeeT資料集
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
            string strSQL = "select distinct " + ColumnName + " from PatNotifyEventToFeeT where " + ColumnName + "='" + Value + "'";
            SqlCommand comm = new SqlCommand(strSQL, conn);
            conn.Open();
            object obj = comm.ExecuteScalar();
            conn.Close();
            if (obj != null)
            {
                bValue = true;
            }
            else
            {
                bValue = false;
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
            string strSQL = "select distinct " + ColumnName + " from PatNotifyEventToFeeT where " + ColumnName + "=" + Value;
            SqlCommand comm = new SqlCommand(strSQL, conn);
            conn.Open();
            object obj = comm.ExecuteScalar();
            conn.Close();
            if (obj != null)
            {
                bValue = true;
            }
            else
            {
                bValue = false;
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
                this.NFID = dr["NFID"].ToString() == "" ? -1 : (int)dr["NFID"];
                this.PatNotifyEventID = dr["PatNotifyEventID"].ToString() == "" ? -1 : (int)dr["PatNotifyEventID"];
                this.FeeKEY = dr["FeeKEY"].ToString() == "" ? -1 : (int)dr["FeeKEY"];
            }
            catch
            {
                throw (new System.Exception("PatNotifyEventToFeeT該筆資料有誤：" + NO.ToString()));
            }
        }
        public void Insert()
        {
            try
            {
                Object Rownull = System.DBNull.Value;
                DataRow dr = dt.NewRow();
                dr["PatNotifyEventID"] = this.PatNotifyEventID == -1 ? Rownull : this.PatNotifyEventID;
                dr["FeeKEY"] = this.FeeKEY == -1 ? Rownull : this.FeeKEY;
                sAdapter.InsertCommand.Parameters["@PatNotifyEventID"].Value = dr["PatNotifyEventID"];
                sAdapter.InsertCommand.Parameters["@FeeKEY"].Value = dr["FeeKEY"];
                conn.Open();
                string KEY = sAdapter.InsertCommand.ExecuteScalar().ToString();
                conn.Close();
                if (KEY != "")
                {
                    this.NFID = int.Parse(KEY);
                    dr["NFID"] = this.NFID;
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
                dr["PatNotifyEventID"] = this.PatNotifyEventID == -1 ? Rownull : this.PatNotifyEventID;
                dr["FeeKEY"] = this.FeeKEY == -1 ? Rownull : this.FeeKEY;
                sAdapter.UpdateCommand.Parameters.Clear();
                sAdapter.UpdateCommand.Parameters.Add("NFID", SqlDbType.Int);
                sAdapter.UpdateCommand.Parameters["NFID"].Value = dr["NFID"];
                sAdapter.UpdateCommand.Parameters.Add("PatNotifyEventID", SqlDbType.Int);
                sAdapter.UpdateCommand.Parameters["PatNotifyEventID"].Value = dr["PatNotifyEventID"];
                sAdapter.UpdateCommand.Parameters.Add("FeeKEY", SqlDbType.Int);
                sAdapter.UpdateCommand.Parameters["FeeKEY"].Value = dr["FeeKEY"];

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
                StringBuilder delString = new StringBuilder("DELETE FROM PatNotifyEventToFeeT where " + strSQLWhere);
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
                StringBuilder delString = new StringBuilder("DELETE FROM PatNotifyEventToFeeT where NFID=@NFID ");
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

    #region ======CPatNotifyEventToPayment======
    public class CPatNotifyEventToPayment
    {
        SqlConnection conn = new SqlConnection(DBAccess.ConnectionListDefaultConnectionString);
        SqlDataAdapter sAdapter;
        SqlCommandBuilder CBuilder;

        DataTable dt;
        /// <summary>
        /// 預設帶出所有的資料
        /// </summary>
        public CPatNotifyEventToPayment()
        {
            sAdapter = new SqlDataAdapter("select * from PatNotifyEventToPaymentT", conn);
            dt = new DataTable();
            //DataSet ds = new DataSet();
            //ds.Tables.Add(dt);
            sAdapter.FillSchema(dt, SchemaType.Source);
            sAdapter.Fill(dt);
            CBuilder = new SqlCommandBuilder(sAdapter);
            sAdapter.InsertCommand = CBuilder.GetInsertCommand(true);
            sAdapter.InsertCommand.UpdatedRowSource = UpdateRowSource.Both;
            sAdapter.InsertCommand.CommandText += " Select @@IDENTITY AS 'IDENTITY'";
            sAdapter.UpdateCommand = new SqlCommand(@"UPDATE PatNotifyEventToPaymentT  SET 
                                                       PatNotifyEventID=@PatNotifyEventID,
                                                       PaymentID=@PaymentID
                                                   where 
                                                       NPID=@NPID", conn);
        }
        /// <summary>
        /// 有條件的過濾資料
        /// </summary>
        /// <param name="sWhere">SQL的條件式</param>
        public CPatNotifyEventToPayment(string sWhere)
        {
            sAdapter = new SqlDataAdapter("select * from PatNotifyEventToPaymentT where " + sWhere, conn);
            dt = new DataTable();
            //DataSet ds = new DataSet();
            //ds.Tables.Add(dt);
            sAdapter.FillSchema(dt, SchemaType.Source);
            sAdapter.Fill(dt);
            CBuilder = new SqlCommandBuilder(sAdapter);
            sAdapter.InsertCommand = CBuilder.GetInsertCommand(true);
            sAdapter.InsertCommand.UpdatedRowSource = UpdateRowSource.Both;
            sAdapter.InsertCommand.CommandText += " Select @@IDENTITY AS 'IDENTITY'";
            sAdapter.UpdateCommand = new SqlCommand(@"UPDATE PatNotifyEventToPaymentT  SET 
                                                       PatNotifyEventID=@PatNotifyEventID,
                                                       PaymentID=@PaymentID
                                                   where 
                                                       NPID=@NPID", conn);
        }


        private int _NPID = -1;
        /// <summary>  
        /// 來函轉付款表
        /// </summary>  
        public int NPID
        {
            get
            {
                return _NPID;
            }
            set
            {
                _NPID = value;
            }
        }
        private int _PatNotifyEventID = -1;
        /// <summary>  
        /// 
        /// </summary>  
        public int PatNotifyEventID
        {
            get
            {
                return _PatNotifyEventID;
            }
            set
            {
                _PatNotifyEventID = value;
            }
        }
        private int _PaymentID = -1;
        /// <summary>  
        /// 
        /// </summary>  
        public int PaymentID
        {
            get
            {
                return _PaymentID;
            }
            set
            {
                _PaymentID = value;
            }
        }

        /// <summary>
        /// 取得PatNotifyEventToPaymentT資料集
        /// </summary>
        public DataTable GetDataTable()
        {
            return dt;
        }

        /// <summary>
        /// 設定PatNotifyEventToPaymentT資料集
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
            string strSQL = "select distinct " + ColumnName + " from PatNotifyEventToPaymentT where " + ColumnName + "='" + Value + "'";
            SqlCommand comm = new SqlCommand(strSQL, conn);
            conn.Open();
            object obj = comm.ExecuteScalar();
            conn.Close();
            if (obj != null)
            {
                bValue = true;
            }
            else
            {
                bValue = false;
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
            string strSQL = "select distinct " + ColumnName + " from PatNotifyEventToPaymentT where " + ColumnName + "=" + Value;
            SqlCommand comm = new SqlCommand(strSQL, conn);
            conn.Open();
            object obj = comm.ExecuteScalar();
            conn.Close();
            if (obj != null)
            {
                bValue = true;
            }
            else
            {
                bValue = false;
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
                this.NPID = dr["NPID"].ToString() == "" ? -1 : (int)dr["NPID"];
                this.PatNotifyEventID = dr["PatNotifyEventID"].ToString() == "" ? -1 : (int)dr["PatNotifyEventID"];
                this.PaymentID = dr["PaymentID"].ToString() == "" ? -1 : (int)dr["PaymentID"];
            }
            catch
            {
                throw (new System.Exception("PatNotifyEventToPaymentT該筆資料有誤：" + NO.ToString()));
            }
        }
        public void Insert()
        {
            try
            {
                Object Rownull = System.DBNull.Value;
                DataRow dr = dt.NewRow();
                dr["PatNotifyEventID"] = this.PatNotifyEventID == -1 ? Rownull : this.PatNotifyEventID;
                dr["PaymentID"] = this.PaymentID == -1 ? Rownull : this.PaymentID;
                sAdapter.InsertCommand.Parameters["@PatNotifyEventID"].Value = dr["PatNotifyEventID"];
                sAdapter.InsertCommand.Parameters["@PaymentID"].Value = dr["PaymentID"];
                conn.Open();
                string KEY = sAdapter.InsertCommand.ExecuteScalar().ToString();
                conn.Close();
                if (KEY != "")
                {
                    this.NPID = int.Parse(KEY);
                    dr["NPID"] = this.NPID;
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
                dr["PatNotifyEventID"] = this.PatNotifyEventID == -1 ? Rownull : this.PatNotifyEventID;
                dr["PaymentID"] = this.PaymentID == -1 ? Rownull : this.PaymentID;
                sAdapter.UpdateCommand.Parameters.Clear();
                sAdapter.UpdateCommand.Parameters.Add("NPID", SqlDbType.Int);
                sAdapter.UpdateCommand.Parameters["NPID"].Value = dr["NPID"];
                sAdapter.UpdateCommand.Parameters.Add("PatNotifyEventID", SqlDbType.Int);
                sAdapter.UpdateCommand.Parameters["PatNotifyEventID"].Value = dr["PatNotifyEventID"];
                sAdapter.UpdateCommand.Parameters.Add("PaymentID", SqlDbType.Int);
                sAdapter.UpdateCommand.Parameters["PaymentID"].Value = dr["PaymentID"];

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
                StringBuilder delString = new StringBuilder("DELETE FROM PatNotifyEventToPaymentT where " + strSQLWhere);
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
                StringBuilder delString = new StringBuilder("DELETE FROM PatNotifyEventToPaymentT where NPID=@NPID ");
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
         
    #region ======CTMComitContent======
    public class CTMComitContent
    {
        SqlConnection conn = new SqlConnection(DBAccess.ConnectionListDefaultConnectionString);
        SqlDataAdapter sAdapter;
        SqlCommandBuilder CBuilder;

        DataTable dt;
        /// <summary>
        /// 預設帶出所有的資料
        /// </summary>
        public CTMComitContent()
        {
            sAdapter = new SqlDataAdapter("select * from TMComitContentT", conn);
            dt = new DataTable();
            //DataSet ds = new DataSet();
            //ds.Tables.Add(dt);
            sAdapter.FillSchema(dt, SchemaType.Source);
            sAdapter.Fill(dt);
            CBuilder = new SqlCommandBuilder(sAdapter);
            sAdapter.InsertCommand = CBuilder.GetInsertCommand(true);
            sAdapter.InsertCommand.UpdatedRowSource = UpdateRowSource.Both;
            sAdapter.InsertCommand.CommandText += " Select @@IDENTITY AS 'IDENTITY'";
            sAdapter.UpdateCommand = new SqlCommand(@"UPDATE TMComitContentT  SET 
                                                       CountrySymbol=@CountrySymbol,
                                                       Sort=@Sort,
                                                       ComitContent=@ComitContent,
                                                       ProcessKEY=@ProcessKEY,
                                                       Status=@Status
                                                   where 
                                                       TMComitContentID=@TMComitContentID", conn);
        }
        /// <summary>
        /// 有條件的過濾資料
        /// </summary>
        /// <param name="sWhere">SQL的條件式</param>
        public CTMComitContent(string sWhere)
        {
            sAdapter = new SqlDataAdapter("select * from TMComitContentT where " + sWhere, conn);
            dt = new DataTable();
            //DataSet ds = new DataSet();
            //ds.Tables.Add(dt);
            sAdapter.FillSchema(dt, SchemaType.Source);
            sAdapter.Fill(dt);
            CBuilder = new SqlCommandBuilder(sAdapter);
            sAdapter.InsertCommand = CBuilder.GetInsertCommand(true);
            sAdapter.InsertCommand.UpdatedRowSource = UpdateRowSource.Both;
            sAdapter.InsertCommand.CommandText += " Select @@IDENTITY AS 'IDENTITY'";
            sAdapter.UpdateCommand = new SqlCommand(@"UPDATE TMComitContentT  SET 
                                                       CountrySymbol=@CountrySymbol,
                                                       Sort=@Sort,
                                                       ComitContent=@ComitContent,
                                                       ProcessKEY=@ProcessKEY,
                                                       Status=@Status
                                                   where 
                                                       TMComitContentID=@TMComitContentID", conn);
        }


        private int _TMComitContentID = -1;
        /// <summary>  
        /// 商標委辦內容設定表 PK
        /// </summary>  
        public int TMComitContentID
        {
            get
            {
                return _TMComitContentID;
            }
            set
            {
                _TMComitContentID = value;
            }
        }
        private string _CountrySymbol = "";
        /// <summary>  
        /// 國別
        /// </summary>  
        public String CountrySymbol
        {
            get
            {
                return _CountrySymbol;
            }
            set
            {
                _CountrySymbol = value;
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
        private string _ComitContent = "";
        /// <summary>  
        /// 委辦內容
        /// </summary>  
        public String ComitContent
        {
            get
            {
                return _ComitContent;
            }
            set
            {
                _ComitContent = value;
            }
        }
        private int _ProcessKEY = -1;
        /// <summary>  
        /// 適用的程序
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
        private int _Status = -1;
        /// <summary>  
        /// 對應的商標狀態
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

        /// <summary>
        /// 取得TMComitContentT資料集
        /// </summary>
        public DataTable GetDataTable()
        {
            return dt;
        }

        /// <summary>
        /// 設定TMComitContentT資料集
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
            string strSQL = "select count(*) from TMComitContentT where " + ColumnName + "='" + Value + "'";
            SqlCommand comm = new SqlCommand(strSQL, conn);
            conn.Open();
            object obj = comm.ExecuteScalar();
            conn.Close();
            if (obj != null && (int)obj == 0)
            {
                bValue = true;
            }
            else
            {
                bValue = false;
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
            string strSQL = "select count(*) from TMComitContentT where " + ColumnName + "=" + Value;
            SqlCommand comm = new SqlCommand(strSQL, conn);
            conn.Open();
            object obj = comm.ExecuteScalar();
            conn.Close();
            if (obj != null && (int)obj == 0)
            {
                bValue = true;
            }
            else
            {
                bValue = false;
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
                this.TMComitContentID = dr["TMComitContentID"].ToString() == "" ? -1 : (int)dr["TMComitContentID"];
                this.CountrySymbol = dr["CountrySymbol"].ToString();
                this.Sort = dr["Sort"].ToString() == "" ? -1 : (int)dr["Sort"];
                this.ComitContent = dr["ComitContent"].ToString();
                this.ProcessKEY = dr["ProcessKEY"].ToString() == "" ? -1 : (int)dr["ProcessKEY"];
                this.Status = dr["Status"].ToString() == "" ? -1 : (int)dr["Status"];
            }
            catch
            {
                throw (new System.Exception("TMComitContentT該筆資料有誤：" + NO.ToString()));
            }
        }
        public void Insert()
        {
            try
            {
                Object Rownull = System.DBNull.Value;
                DataRow dr = dt.NewRow();
                dr["CountrySymbol"] = this.CountrySymbol == "" ? Rownull : this.CountrySymbol;
                dr["Sort"] = this.Sort == -1 ? Rownull : this.Sort;
                dr["ComitContent"] = this.ComitContent == "" ? Rownull : this.ComitContent;
                dr["ProcessKEY"] = this.ProcessKEY == -1 ? Rownull : this.ProcessKEY;
                dr["Status"] = this.Status == -1 ? Rownull : this.Status;
                sAdapter.InsertCommand.Parameters["@CountrySymbol"].Value = dr["CountrySymbol"];
                sAdapter.InsertCommand.Parameters["@Sort"].Value = dr["Sort"];
                sAdapter.InsertCommand.Parameters["@ComitContent"].Value = dr["ComitContent"];
                sAdapter.InsertCommand.Parameters["@ProcessKEY"].Value = dr["ProcessKEY"];
                sAdapter.InsertCommand.Parameters["@Status"].Value = dr["Status"];
                conn.Open();
                string KEY = sAdapter.InsertCommand.ExecuteScalar().ToString();
                conn.Close();
                if (KEY != "")
                {
                    this.TMComitContentID = int.Parse(KEY);
                    dr["TMComitContentID"] = this.TMComitContentID;
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
                dr["CountrySymbol"] = this.CountrySymbol == "" ? Rownull : this.CountrySymbol;
                dr["Sort"] = this.Sort == -1 ? Rownull : this.Sort;
                dr["ComitContent"] = this.ComitContent == "" ? Rownull : this.ComitContent;
                dr["ProcessKEY"] = this.ProcessKEY == -1 ? Rownull : this.ProcessKEY;
                dr["Status"] = this.Status == -1 ? Rownull : this.Status;
                sAdapter.UpdateCommand.Parameters.Clear();
                sAdapter.UpdateCommand.Parameters.Add("TMComitContentID", SqlDbType.Int);
                sAdapter.UpdateCommand.Parameters["TMComitContentID"].Value = dr["TMComitContentID"];
                sAdapter.UpdateCommand.Parameters.Add("CountrySymbol", SqlDbType.NVarChar);
                sAdapter.UpdateCommand.Parameters["CountrySymbol"].Value = dr["CountrySymbol"];
                sAdapter.UpdateCommand.Parameters.Add("Sort", SqlDbType.Int);
                sAdapter.UpdateCommand.Parameters["Sort"].Value = dr["Sort"];
                sAdapter.UpdateCommand.Parameters.Add("ComitContent", SqlDbType.NVarChar);
                sAdapter.UpdateCommand.Parameters["ComitContent"].Value = dr["ComitContent"];
                sAdapter.UpdateCommand.Parameters.Add("ProcessKEY", SqlDbType.Int);
                sAdapter.UpdateCommand.Parameters["ProcessKEY"].Value = dr["ProcessKEY"];
                sAdapter.UpdateCommand.Parameters.Add("Status", SqlDbType.Int);
                sAdapter.UpdateCommand.Parameters["Status"].Value = dr["Status"];

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
                StringBuilder delString = new StringBuilder("DELETE FROM TMComitContentT where " + strSQLWhere);
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
                StringBuilder delString = new StringBuilder("DELETE FROM TMComitContentT where TMComitContentID=@TMComitContentID ");
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
        

    #region ======CProgram======
    public class CProgram
    {
        SqlConnection conn = new SqlConnection(DBAccess.ConnectionListDefaultConnectionString);
        SqlDataAdapter sAdapter;
        SqlCommandBuilder CBuilder;

        DataTable dt;
        /// <summary>
        /// 預設帶出所有的資料
        /// </summary>
        public CProgram()
        {
            sAdapter = new SqlDataAdapter("select * from ProgramT", conn);
            dt = new DataTable();
            //DataSet ds = new DataSet();
            //ds.Tables.Add(dt);
            sAdapter.FillSchema(dt, SchemaType.Source);
            sAdapter.Fill(dt);
            CBuilder = new SqlCommandBuilder(sAdapter);
            sAdapter.InsertCommand = CBuilder.GetInsertCommand(true);
            sAdapter.InsertCommand.UpdatedRowSource = UpdateRowSource.Both;
            sAdapter.InsertCommand.CommandText += " Select @@IDENTITY AS 'IDENTITY'";
            sAdapter.UpdateCommand = new SqlCommand(@"UPDATE ProgramT  SET 
                                                       ProgramName=@ProgramName,
                                                       ProgramKind=@ProgramKind,
                                                       ProgramSymbol=@ProgramSymbol,
                                                       Description=@Description,
                                                       IsOpen=@IsOpen
                                                   where 
                                                       ProgramKEY=@ProgramKEY", conn);
        }
        /// <summary>
        /// 有條件的過濾資料
        /// </summary>
        /// <param name="sWhere">SQL的條件式</param>
        public CProgram(string sWhere)
        {
            sAdapter = new SqlDataAdapter("select * from ProgramT where " + sWhere, conn);
            dt = new DataTable();
            //DataSet ds = new DataSet();
            //ds.Tables.Add(dt);
            sAdapter.FillSchema(dt, SchemaType.Source);
            sAdapter.Fill(dt);
            CBuilder = new SqlCommandBuilder(sAdapter);
            sAdapter.InsertCommand = CBuilder.GetInsertCommand(true);
            sAdapter.InsertCommand.UpdatedRowSource = UpdateRowSource.Both;
            sAdapter.InsertCommand.CommandText += " Select @@IDENTITY AS 'IDENTITY'";
            sAdapter.UpdateCommand = new SqlCommand(@"UPDATE ProgramT  SET 
                                                       ProgramName=@ProgramName,
                                                       ProgramKind=@ProgramKind,
                                                       ProgramSymbol=@ProgramSymbol,
                                                       Description=@Description,
                                                       IsOpen=@IsOpen
                                                   where 
                                                       ProgramKEY=@ProgramKEY", conn);
        }


        private int _ProgramKEY = -1;
        /// <summary>  
        /// 
        /// </summary>  
        public int ProgramKEY
        {
            get
            {
                return _ProgramKEY;
            }
            set
            {
                _ProgramKEY = value;
            }
        }
        private string _ProgramName = "";
        /// <summary>  
        /// 
        /// </summary>  
        public String ProgramName
        {
            get
            {
                return _ProgramName;
            }
            set
            {
                _ProgramName = value;
            }
        }
        private int _ProgramKind = -1;
        /// <summary>  
        /// 1.事務所管理系統  2.專利管理系統 3.商標管理系統 4.契約管理系統 5.法務
        /// </summary>  
        public int ProgramKind
        {
            get
            {
                return _ProgramKind;
            }
            set
            {
                _ProgramKind = value;
            }
        }
        private string _ProgramSymbol = "";
        /// <summary>  
        /// 
        /// </summary>  
        public String ProgramSymbol
        {
            get
            {
                return _ProgramSymbol;
            }
            set
            {
                _ProgramSymbol = value;
            }
        }
        private string _Description = "";
        /// <summary>  
        /// 描述
        /// </summary>  
        public String Description
        {
            get
            {
                return _Description;
            }
            set
            {
                _Description = value;
            }
        }
        private bool _IsOpen = false;
        /// <summary>  
        /// 是否公開
        /// </summary>  
        public bool IsOpen
        {
            get
            {
                return _IsOpen;
            }
            set
            {
                _IsOpen = value;
            }
        }

        /// <summary>
        /// 取得ProgramT資料集
        /// </summary>
        public DataTable GetDataTable()
        {
            return dt;
        }

        /// <summary>
        /// 設定ProgramT資料集
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
            string strSQL = "select count(" + ColumnName + ") as CountValue from ProgramT where " + ColumnName + "='" + Value + "'";
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
            string strSQL = "select count(" + ColumnName + ") as CountValue from ProgramT where " + ColumnName + "=" + Value;
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
                this.ProgramKEY = dr["ProgramKEY"].ToString() == "" ? -1 : (int)dr["ProgramKEY"];
                this.ProgramName = dr["ProgramName"].ToString();
                this.ProgramKind = dr["ProgramKind"].ToString() == "" ? -1 : (int)dr["ProgramKind"];
                this.ProgramSymbol = dr["ProgramSymbol"].ToString();
                this.Description = dr["Description"].ToString();
                this.IsOpen = dr["IsOpen"].ToString() == "" ? false : (bool)dr["IsOpen"];
            }
            catch
            {
                throw (new System.Exception("ProgramT該筆資料有誤：" + NO.ToString()));
            }
        }
        public void Insert()
        {
            try
            {
                Object Rownull = System.DBNull.Value;
                DataRow dr = dt.NewRow();
                dr["ProgramName"] = this.ProgramName == "" ? Rownull : this.ProgramName;
                dr["ProgramKind"] = this.ProgramKind == -1 ? Rownull : this.ProgramKind;
                dr["ProgramSymbol"] = this.ProgramSymbol == "" ? Rownull : this.ProgramSymbol;
                dr["Description"] = this.Description == "" ? Rownull : this.Description;
                dr["IsOpen"] = this.IsOpen;
                sAdapter.InsertCommand.Parameters["@ProgramName"].Value = dr["ProgramName"];
                sAdapter.InsertCommand.Parameters["@ProgramKind"].Value = dr["ProgramKind"];
                sAdapter.InsertCommand.Parameters["@ProgramSymbol"].Value = dr["ProgramSymbol"];
                sAdapter.InsertCommand.Parameters["@Description"].Value = dr["Description"];
                sAdapter.InsertCommand.Parameters["@IsOpen"].Value = dr["IsOpen"];
                conn.Open();
                string KEY = sAdapter.InsertCommand.ExecuteScalar().ToString();
                conn.Close();
                if (KEY != "")
                {
                    this.ProgramKEY = int.Parse(KEY);
                    dr["ProgramKEY"] = this.ProgramKEY;
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
                dr["ProgramName"] = this.ProgramName == "" ? Rownull : this.ProgramName;
                dr["ProgramKind"] = this.ProgramKind == -1 ? Rownull : this.ProgramKind;
                dr["ProgramSymbol"] = this.ProgramSymbol == "" ? Rownull : this.ProgramSymbol;
                dr["Description"] = this.Description == "" ? Rownull : this.Description;
                dr["IsOpen"] = this.IsOpen;
                sAdapter.UpdateCommand.Parameters.Clear();
                sAdapter.UpdateCommand.Parameters.Add("ProgramKEY", SqlDbType.Int);
                sAdapter.UpdateCommand.Parameters["ProgramKEY"].Value = dr["ProgramKEY"];
                sAdapter.UpdateCommand.Parameters.Add("ProgramName", SqlDbType.NVarChar);
                sAdapter.UpdateCommand.Parameters["ProgramName"].Value = dr["ProgramName"];
                sAdapter.UpdateCommand.Parameters.Add("ProgramKind", SqlDbType.Int);
                sAdapter.UpdateCommand.Parameters["ProgramKind"].Value = dr["ProgramKind"];
                sAdapter.UpdateCommand.Parameters.Add("ProgramSymbol", SqlDbType.NVarChar);
                sAdapter.UpdateCommand.Parameters["ProgramSymbol"].Value = dr["ProgramSymbol"];
                sAdapter.UpdateCommand.Parameters.Add("Description", SqlDbType.NVarChar);
                sAdapter.UpdateCommand.Parameters["Description"].Value = dr["Description"];
                sAdapter.UpdateCommand.Parameters.Add("IsOpen", SqlDbType.Bit);
                sAdapter.UpdateCommand.Parameters["IsOpen"].Value = dr["IsOpen"];

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
                StringBuilder delString = new StringBuilder("DELETE FROM ProgramT where " + strSQLWhere);
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
                StringBuilder delString = new StringBuilder("DELETE FROM ProgramT where ProgramKEY=@ProgramKEY ");
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
