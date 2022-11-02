using H3Operator.DBHelper;
using System.Data;
using System.Data.SqlClient;
using System;

namespace LawtechPTSystem.Public
{
    /// <summary>
    ///  
    ///  檢查更新的來源 DemoLawOfficeDB_Trial   ptsupdate 
    ///
    /// </summary>
    class CStructure
    {
        public CStructure()
        {            
            
            strOriConnectionString= H3Operator.DBHelper.EncryptorClass.Decrypt(OriConnectionStringMd5, "@wsx8UHB");

            //來源資料表
            string strTables = "select TABLE_NAME, CreateScript,IsData  from PTS_TablesT with(nolock)";
         
            object obj = DB.QueryToDataTableByDataAdapter(strTables, ref _Tables_Source, strConnectionString: strOriConnectionString);
            if (dt_Tables_Source.PrimaryKey.Length == 0)
            {
                DataColumn[] pk = { dt_Tables_Source.Columns["TABLE_NAME"] };
                dt_Tables_Source.PrimaryKey = pk;
            }

            //來源檢視表
            string strViews = "SELECT *,[definition]=(SELECT definition FROM sysobjects a,sys.all_sql_modules b WHERE a.id = b.object_id and name =TABLE_NAME) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE='VIEW' order by TABLE_NAME ";
           
             obj = DB.QueryToDataTableByDataAdapter(strViews, ref _Views_Source, strConnectionString: strOriConnectionString);
            if (dt_Views_Source.PrimaryKey.Length == 0)
            {
                DataColumn[] pk = { dt_Views_Source.Columns["TABLE_NAME"] };
                dt_Views_Source.PrimaryKey = pk;
            }

            string strVersion = "select  Value  from StatueRecordT where StatusName='DataBaseVersion' ";
            object objResult = new object();
            DB.ExecuteScaler(strVersion,ref objResult,strConnectionString: strOriConnectionString);
            DataBaseVersion = objResult.ToString();
        }

        string strOriConnectionString = "";
        /// <summary>
        /// 來源資料庫路徑
        /// </summary>
        public string OriConnectionString
        {
            get { return strOriConnectionString; }
            set { strOriConnectionString = value; }
        }

        private string _DataBaseVersion = "";
        /// <summary>
        /// 資料庫目前的版本
        /// </summary>
        public string DataBaseVersion
        {
            get { return _DataBaseVersion; }
            set { _DataBaseVersion = value; }
        }
               

        DataTable _Tables_Source = new DataTable();
        /// <summary>
        /// 來源資料表
        /// </summary>
        public DataTable dt_Tables_Source
        {
            get { return _Tables_Source; }
            set { _Tables_Source = value; }
        }

        DataTable _Views_Source = new DataTable();
        /// <summary>
        /// 來源檢視表
        /// </summary>
        public DataTable dt_Views_Source
        {
            get { return _Views_Source; }
            set { _Views_Source = value; }
        }


        const string OriConnectionStringMd5 = "hH2gFIQbMmwvKqMDXx1OUZlfmAHoKyr1AyrNcvI9LsMXNRhdIfVqfZmQQOiPdwmXqBg/nxP5a/f73H5S/e00OEHX8eLfhwgJaewNoNr6DWc+oLAHr8HgAkokNxv8Ftu2bXji6xT1FyCvxNohRpFuee1zqS9BwKUWzCFbNR6zteC+E4YaUwRNnrohlmffVvyp+GqvpsJkCj3XkbJ0rMSzTyskwRc2GH+L";
        DBAccess DB = new DBAccess();

        /// <summary>
        /// 檢查db 的資料表
        /// </summary>
        /// <returns></returns>
        //public async Task CheckDBAll()
        //{
        //    await Task.Run(() =>
        //    {
        //        //1.檢查資料表
        //        TablesCheck();

        //        //2.檢查資料表裏的欄位
        //        foreach (DataRow dr in dt_Tables_Source.Rows)
        //        {
        //            CheckTableColumns(dr["TABLE_NAME"].ToString());
        //        }

        //        //3.檢查檢視表
        //        ViewsCheck();

        //    });

        //}

        #region 判斷連線是否正常
        /// <summary>
        /// 判斷連線是否正常
        /// </summary>
        /// <returns></returns>
        public bool checkConnection()
        {
            //string connectionString = "Data Source=" + txt_dataBase.Text + ";Initial Catalog=" + txt_databaseName.Text + ";Persist Security Info=True;User ID=" + txt_account.Text + ";Password=" + txt_password.Text;

            SqlConnection con = new SqlConnection(OriConnectionString);

            try
            {
                con.Open();

                con.Close();

                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }
        #endregion

        #region 檢查資料表 public object TablesCheck()
        /// <summary>
        /// 檢查資料表
        /// </summary>
        /// <returns></returns>
        public bool TablesCheck()
        {
            bool isTableSuccess = false;
            try
            {               
                //目的地資料表
                DataTable dt_Tables_Destination = new DataTable();
                string strTABLEs = "SELECT * FROM INFORMATION_SCHEMA.Tables where TABLE_TYPE='BASE TABLE' order by TABLE_NAME";
                object obj = DB.QueryToDataTableByDataAdapter(strTABLEs, ref dt_Tables_Destination);
                if (dt_Tables_Destination.PrimaryKey.Length == 0)
                {
                    DataColumn[] pk = { dt_Tables_Destination.Columns["TABLE_NAME"] };
                    dt_Tables_Destination.PrimaryKey = pk;
                }
              
                //檢查資料表
                foreach (DataRow dr in dt_Tables_Source.Rows)
                {
                    string cluName = dr["TABLE_NAME"].ToString();
                    DataRow drDes = dt_Tables_Destination.Rows.Find(cluName);
                    if (drDes == null) //當查無此Table時，建立資料表
                    {
                        bool isCreate = CreateDataTable(dr["CreateScript"].ToString());
                    }
                }
                return isTableSuccess = true;
            }
            catch
            {
                return isTableSuccess;
            }

        }
        #endregion

        #region 建立資料表 public bool CreateDataTable(string strScript)
        /// <summary>
        /// 建立資料表
        /// </summary>
        /// <param name="strScript">建立資料表語法</param>
        /// <returns></returns>
        public bool CreateDataTable(string strScript)        {
            
            object obj = DB.ExecuteNonQuery(strScript);
            if (obj.ToString() == "0")
            {
                return true;
            }
            else
            {
                return false;
            }
        } 
        #endregion

        #region 檢查資料表欄位 public bool CheckTableColumns(string TableName)
        /// <summary>
        /// 檢查資料表欄位
        /// </summary>
        /// <param name="TableName"></param>
        /// <returns></returns>
        public bool CheckTableColumns(string TableName)
        {
            string strOriConnectionString = "";
            strOriConnectionString = H3Operator.DBHelper.EncryptorClass.Decrypt(OriConnectionStringMd5, "@wsx8UHB");

            string strTables = string.Format("SELECT COLUMN_Name ,DATA_TYPE,CHARACTER_MAXIMUM_LENGTH ,IS_NULLABLE , NUMERIC_PRECISION,NUMERIC_SCALE FROM INFORMATION_SCHEMA.Columns Where Table_Name = '{0}' ", TableName);
            
            //來源資料表
            DataTable dt_Tables_Source = new DataTable();
            object obj = DB.QueryToDataTableByDataAdapter(strTables, ref dt_Tables_Source, strConnectionString: strOriConnectionString);
            if (dt_Tables_Source.PrimaryKey.Length == 0)
            {
                DataColumn[] pk = { dt_Tables_Source.Columns["COLUMN_Name"] };
                dt_Tables_Source.PrimaryKey = pk;
            }

            //取得來源資料表的pk欄位
            string sPK = "SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE WHERE TABLE_NAME = 'ApplicantT' ";
            DataTable dt_Tables_Source_PK = new DataTable();
            obj = DB.QueryToDataTableByDataAdapter(sPK, ref dt_Tables_Source_PK, strConnectionString: strOriConnectionString);

            //目的地資料
            DataTable dt_Tables_Destination = new DataTable();
            obj = DB.QueryToDataTableByDataAdapter(strTables, ref dt_Tables_Destination);
            if (dt_Tables_Destination.PrimaryKey.Length == 0)
            {
                DataColumn[] pk = { dt_Tables_Destination.Columns["COLUMN_Name"] };
                dt_Tables_Destination.PrimaryKey = pk;
            }

            try
            {
                #region 移除不必要的欄位
                if (dt_Tables_Source.Rows.Count != dt_Tables_Destination.Rows.Count)
                {
                    //移除不必要的欄位
                    foreach (DataRow drDes in dt_Tables_Destination.Rows)
                    {
                        string ColunmName = drDes["COLUMN_Name"].ToString();
                        DataRow drSource = dt_Tables_Source.Rows.Find(ColunmName);
                        if (drSource == null)
                        {
                            bool isCheck = false;
                            #region 檢查這欄位是不是PK
                            if (dt_Tables_Source_PK.Rows.Count > 0)
                            {
                                foreach (DataRow drP in dt_Tables_Source_PK.Rows)
                                {
                                    if (drP["COLUMN_NAME"].ToString() == drDes["COLUMN_Name"].ToString())
                                    {
                                        isCheck = true;
                                        break;
                                    }
                                }
                            }
                            #endregion

                            if (!isCheck)
                            {
                                DropColunm(TableName, ColunmName);
                            }
                        }
                    }
                } 
                #endregion

                //比對欄位
                foreach (DataRow dr in dt_Tables_Source.Rows)
                    {
                        string ColunmName = dr["COLUMN_Name"].ToString();
                        DataRow drDes = dt_Tables_Destination.Rows.Find(ColunmName);
                        if (drDes == null)
                        {
                            CreateColunm(TableName, ColunmName, dr["CHARACTER_MAXIMUM_LENGTH"].ToString(), dr["DATA_TYPE"].ToString(), dr["IS_NULLABLE"].ToString(), dr["NUMERIC_PRECISION"].ToString(), dr["NUMERIC_SCALE"].ToString());
                        }
                        else
                        {
                            if (dr["DATA_TYPE"].ToString() != drDes["DATA_TYPE"].ToString() || dr["CHARACTER_MAXIMUM_LENGTH"].ToString() != drDes["CHARACTER_MAXIMUM_LENGTH"].ToString())
                            {
                                AlterColunm(TableName, ColunmName, dr["CHARACTER_MAXIMUM_LENGTH"].ToString(), dr["DATA_TYPE"].ToString(), dr["IS_NULLABLE"].ToString(), dr["NUMERIC_PRECISION"].ToString(), dr["NUMERIC_SCALE"].ToString());
                            }

                        }
                    }
               
                return true;
            }
            catch
            {
                return false;
            }

        } 
        #endregion

        #region 建立資料表欄位 public bool CreateColunm(string TableName, string ColunmName, string col_Length, string data_Type, string IS_NULLABLE = "YES", string NUMERIC_PRECISION = "0", string NUMERIC_SCALE = "0")
        /// <summary>
        /// 建立資料表欄位
        /// </summary>
        /// <param name="TableName"></param>
        /// <param name="ColunmName"></param>
        /// <param name="col_Length"></param>
        /// <param name="data_Type"></param>
        /// <param name="IS_NULLABLE"></param>
        /// <param name="NUMERIC_PRECISION"></param>
        /// <param name="NUMERIC_SCALE"></param>
        /// <returns></returns>
        public bool CreateColunm(string TableName, string ColunmName, string col_Length, string data_Type, string IS_NULLABLE = "YES", string NUMERIC_PRECISION = "0", string NUMERIC_SCALE = "0")
        {
            string strCreatecolunm = "";
            switch (data_Type.ToLower())
            {
                case "nvarchar":
                case "varchar":
                case "nchar":
                    strCreatecolunm = string.Format("ALTER TABLE {0} add [{1}] {2}({3} ) {4} ", TableName, ColunmName, data_Type, col_Length.Replace("-1", "max"), IS_NULLABLE.ToLower() == "no" ? " not null " : "null");
                    break;
                case "smallint":
                case "bigint":
                case "int":
                case "bit":
                case "date":
                case "datetime":
                    strCreatecolunm = string.Format("ALTER TABLE {0} add [{1}] {2} {3} ", TableName, ColunmName, data_Type, IS_NULLABLE.ToLower() == "no" ? " not null " : "null");
                    break;
                case "decimal":
                    strCreatecolunm = string.Format("ALTER TABLE {0} add [{1}] {2} ({3},{4}) {5} ", TableName, ColunmName, data_Type, NUMERIC_PRECISION, NUMERIC_SCALE, IS_NULLABLE.ToLower() == "no" ? " not null " : "null");
                    break;
            }

            object obj = DB.ExecuteNonQuery(strCreatecolunm);
            if (obj.ToString() == "0")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region 修改資料表欄位  public bool AlterColunm(string TableName, string ColunmName, string col_Length, string data_Type, string IS_NULLABLE = "YES", string NUMERIC_PRECISION = "0", string NUMERIC_SCALE = "0")
        /// <summary>
        /// 修改資料表欄位
        /// </summary>
        /// <param name="TableName"></param>
        /// <param name="ColunmName"></param>
        /// <param name="col_Length"></param>
        /// <param name="data_Type"></param>
        /// <param name="IS_NULLABLE"></param>
        /// <param name="NUMERIC_PRECISION"></param>
        /// <param name="NUMERIC_SCALE"></param>
        /// <returns></returns>
        public bool AlterColunm(string TableName, string ColunmName, string col_Length, string data_Type, string IS_NULLABLE = "YES", string NUMERIC_PRECISION = "0", string NUMERIC_SCALE = "0")
        {
            string strCreatecolunm = "";
            switch (data_Type.ToLower())
            {
                case "nvarchar":
                case "varchar":
                case "nchar":
                    strCreatecolunm = string.Format("ALTER TABLE {0} ALTER COLUMN [{1}] {2}({3} ) {4} ", TableName, ColunmName, data_Type, col_Length.Replace("-1", "max"), IS_NULLABLE.ToLower() == "no" ? " not null " : "null");
                    break;
                case "bigint":
                case "int":
                case "smallint":
                case "bit":
                case "date":
                case "datetime":
                    strCreatecolunm = string.Format("ALTER TABLE {0} ALTER COLUMN [{1}] {2} {3} ", TableName, ColunmName, data_Type, IS_NULLABLE.ToLower() == "no" ? " not null " : "null");
                    break;
                case "decimal":
                    strCreatecolunm = string.Format("ALTER TABLE {0} ALTER COLUMN [{1}] {2} ({3},{4}) {5} ", TableName, ColunmName, data_Type, NUMERIC_PRECISION, NUMERIC_SCALE, IS_NULLABLE.ToLower() == "no" ? " not null " : "null");
                    break;
            }

            object obj = DB.ExecuteNonQuery(strCreatecolunm);
            if (obj.ToString() == "0")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region 刪除資料表欄位 public bool DropColunm(string TableName, string ColunmName)
        /// <summary> 
        /// 刪除資料表欄位
        /// </summary>
        /// <param name="TableName"></param>
        /// <param name="ColunmName"></param>
        /// <returns></returns>
        public bool DropColunm(string TableName, string ColunmName)
        {
            string strSQL = string.Format("ALTER TABLE {0} DROP COLUMN {1} ", TableName, ColunmName);
            object obj = DB.ExecuteNonQuery(strSQL);
            if (obj.ToString() == "0")
            {
                return true;
            }
            else
            {
                return false;
            }
        } 
        #endregion

        #region 檢查檢視表 public object ViewsCheck()
        /// <summary>
        /// 檢查資料表
        /// </summary>
        /// <returns></returns>
        public void ViewsCheck()
        {
            try
            {
                //目的地檢視表
                DataTable dt_Tables_Destination = new DataTable();
                string strTABLEs = "SELECT *,[definition]=(SELECT definition FROM sysobjects a,sys.all_sql_modules b WHERE a.id = b.object_id and name =TABLE_NAME) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE='VIEW'  order by TABLE_NAME";
                object obj = DB.QueryToDataTableByDataAdapter(strTABLEs, ref dt_Tables_Destination);
                if (dt_Tables_Destination.PrimaryKey.Length == 0)
                {
                    DataColumn[] pk = { dt_Tables_Destination.Columns["TABLE_NAME"] };
                    dt_Tables_Destination.PrimaryKey = pk;
                }

                int itables = 1;
                //檢查資料表
                foreach (DataRow dr in dt_Views_Source.Rows)
                {
                    string cluName = dr["TABLE_NAME"].ToString();
                    DataRow drDes = dt_Tables_Destination.Rows.Find(cluName);
                    if (drDes == null) //當查無此View時，建立資料表
                    {
                         CreateView(dr["definition"].ToString());
                    }
                    else {
                        if (dr["definition"].ToString() != drDes["definition"].ToString())
                        {
                            AlterView(dr["definition"].ToString());
                        }
                    }
                  
                    itables++;
                }

            }
            catch
            { }

        }
        #endregion

       

        #region 建立檢視表 public void CreateView(string strViewScript)
        /// <summary>
        /// 建立檢視表
        /// </summary>
        /// <param name="strViewScript"></param>
        public void CreateView(string strViewScript)
        {
            object obj = DB.ExecuteNonQuery(strViewScript.ToString());
            if (obj.ToString() != "0")
            {
                H3Operator.DBHelper.CommonFunction.ThreadWriteLog("CStructure 建立檢視表 public void CreateView(string strViewScript)\r\n" + obj.ToString());
            }
        }
        #endregion

        #region 修改檢視表 public void AlterView(string strViewScript)
        /// <summary>
        /// 修改檢視表
        /// </summary>
        /// <param name="ViewName"></param>
        public void AlterView(string strViewScript)
        {
            string sqlScript = strViewScript.ToString().Replace("CREATE VIEW ", "ALTER VIEW ").Replace("[dbo].", "").Replace("dbo.", "");
            object objScript = DB.ExecuteNonQuery(sqlScript);

            if (objScript.ToString() != "0")
            {
                H3Operator.DBHelper.CommonFunction.ThreadWriteLog("CStructure 修改檢視表 public void AlterView(string strViewScript)\r\n" + objScript.ToString());
            }

        }
        #endregion

        #region 取得來源資料庫的資料 public object GetSourceDataTable(string tableName)
        /// <summary>
        /// 取得來源資料庫的資料
        /// </summary>
        /// <param name="tableName">資料表名稱</param>
        /// <param name="dtSource"></param>
        /// <returns></returns>
        public object GetSourceDataTable(string tableName)
        {
            string strOriConnectionString = "";
            strOriConnectionString = H3Operator.DBHelper.EncryptorClass.Decrypt(OriConnectionStringMd5, "@wsx8UHB");

            string strSQL = string.Format("select * from {0}   ", tableName);
            DataTable dtSource = new DataTable();
            object obj = DB.QueryToDataTableByDataAdapter(strSQL, ref dtSource, strConnectionString: strOriConnectionString);
            if (obj.ToString() == "0")
            {
                if (dtSource.Rows.Count > 0)
                {
                    //1.先刪除原本的資料
                    DB.ExecuteNonQuery(string.Format("truncate table {0}", tableName));

                    //2.新增資料
                    obj = DB.SqlBulkCopyWriteToServer(dtSource, DBAccess.ConnectionListDefaultConnectionString, tableName);
                }
            }
            return obj;
        }
        #endregion

        #region 取得來源資料庫的GridColumnT資料表 public object GetSourceDataTableGridColumnT()
        /// <summary>
        /// 取得來源資料庫的GridColumnT資料表
        /// </summary>      
        /// <returns></returns>
        public object GetSourceDataTableGridColumnT()
        {
            string strOriConnectionString = "";
            strOriConnectionString = H3Operator.DBHelper.EncryptorClass.Decrypt(OriConnectionStringMd5, "@wsx8UHB");

            //來源資料表
            string strSQL = "select *  from GridColumnT  with(nolock) ";
            DataTable dtSource = new DataTable();
            object obj = DB.QueryToDataTableByDataAdapter(strSQL, ref dtSource, strConnectionString: strOriConnectionString);
            if (obj.ToString() == "0")
            {
                //設定資料表的PK 欄位
                if (dtSource.PrimaryKey.Length == 0)
                {
                    DataColumn[] pk = { dtSource.Columns["GridColumnKey"] };
                    dtSource.PrimaryKey = pk;
                }
            }

            if (obj.ToString() == "0")
            {
                if (dtSource.Rows.Count > 0)
                {
                    //1.先刪除GridColumnT_Temp的資料
                    obj = DB.ExecuteNonQuery(string.Format("truncate table {0} ; truncate table {1}", "GridColumnT_Temp", "GridColumnT_PreviousVersion"));

                    //2.新增至GridColumnT_Temp資料
                    obj = DB.SqlBulkCopyWriteToServer(dtSource, DBAccess.ConnectionListDefaultConnectionString, "GridColumnT_Temp");

                    //2-1.新增至GridColumnT_PreviousVersion資料, 本次的備份資料
                    obj = DB.ExecuteNonQuery(string.Format(@"insert GridColumnT_PreviousVersion (GridSymboID, GridColumnType, Sort, GridColumnName, DataPropertyName, HeaderText, 
                            ToolTipText, LinkText, DataSource, DisplayMember, ValueMember, [ReadOnly], Width, Visible, IsPublic, Alignment, 
                            [Format], ForeColor, BackColor, Font, FontSize, CreateDateTime, LastModifyDateTime)
select GridSymboID, GridColumnType, Sort, GridColumnName, DataPropertyName, HeaderText, 
                            ToolTipText, LinkText, DataSource, DisplayMember, ValueMember, [ReadOnly], Width, Visible, IsPublic, Alignment, 
                            [Format], ForeColor, BackColor, Font, FontSize, getdate(), LastModifyDateTime
							from GridColumnT order by GridSymboID,Sort"));

                    //3. 更新GridColumnT_Temp
                    string strTemp = @"update GridColumnT_Temp set 
GridColumnT_Temp.HeaderText=ISNULL((Select  top 1  GridColumnT.HeaderText from GridColumnT where GridColumnT_Temp.GridSymboID =GridColumnT.GridSymboID and GridColumnT_Temp.GridColumnName=GridColumnT.GridColumnName and GridColumnT_Temp.DataPropertyName=GridColumnT.DataPropertyName),GridColumnT_Temp.HeaderText), 
GridColumnT_Temp.ToolTipText=ISNULL((Select top 1 GridColumnT.ToolTipText from GridColumnT where GridColumnT_Temp.GridSymboID =GridColumnT.GridSymboID and GridColumnT_Temp.GridColumnName=GridColumnT.GridColumnName and GridColumnT_Temp.DataPropertyName=GridColumnT.DataPropertyName), GridColumnT_Temp.ToolTipText), 
GridColumnT_Temp.Width=ISNULL((Select top 1  GridColumnT.Width from GridColumnT where GridColumnT_Temp.GridSymboID =GridColumnT.GridSymboID and GridColumnT_Temp.GridColumnName=GridColumnT.GridColumnName and GridColumnT_Temp.DataPropertyName=GridColumnT.DataPropertyName),GridColumnT_Temp.Width),
GridColumnT_Temp.Alignment=ISNULL((Select top 1  GridColumnT.Alignment from GridColumnT where GridColumnT_Temp.GridSymboID =GridColumnT.GridSymboID and GridColumnT_Temp.GridColumnName=GridColumnT.GridColumnName and GridColumnT_Temp.DataPropertyName=GridColumnT.DataPropertyName),GridColumnT_Temp.Alignment), 
GridColumnT_Temp.ForeColor=ISNULL((Select  top 1 GridColumnT.ForeColor from GridColumnT where GridColumnT_Temp.GridSymboID =GridColumnT.GridSymboID and GridColumnT_Temp.GridColumnName=GridColumnT.GridColumnName and GridColumnT_Temp.DataPropertyName=GridColumnT.DataPropertyName),GridColumnT_Temp.ForeColor),
GridColumnT_Temp.Sort=ISNULL((Select  top 1 GridColumnT.Sort from GridColumnT where GridColumnT_Temp.GridSymboID =GridColumnT.GridSymboID and GridColumnT_Temp.GridColumnName=GridColumnT.GridColumnName and GridColumnT_Temp.DataPropertyName=GridColumnT.DataPropertyName),GridColumnT_Temp.Sort),
GridColumnT_Temp.Visible=ISNULL((Select  top 1 GridColumnT.Visible from GridColumnT where GridColumnT_Temp.GridSymboID =GridColumnT.GridSymboID and GridColumnT_Temp.GridColumnName=GridColumnT.GridColumnName and GridColumnT_Temp.DataPropertyName=GridColumnT.DataPropertyName),GridColumnT_Temp.Visible),
GridColumnT_Temp.FontSize=ISNULL((Select  top 1 GridColumnT.FontSize from GridColumnT where GridColumnT_Temp.GridSymboID =GridColumnT.GridSymboID and GridColumnT_Temp.GridColumnName=GridColumnT.GridColumnName and GridColumnT_Temp.DataPropertyName=GridColumnT.DataPropertyName),GridColumnT_Temp.FontSize)

";
                    obj = DB.ExecuteNonQuery(strTemp);

                    //4.刪除GridColumnT的資料
                    obj = DB.ExecuteNonQuery(string.Format("truncate table {0}", "GridColumnT"));

                    //5.將GridColumnT_Temp 存回GridColumnT，並清空將 GridColumnT_Temp
                    string strGridColumnT = @"insert GridColumnT (GridSymboID, GridColumnType, Sort, GridColumnName, DataPropertyName, HeaderText, 
                            ToolTipText, LinkText, DataSource, DisplayMember, ValueMember, ReadOnly, Width, Visible, IsPublic, Alignment, 
                            [Format], ForeColor, BackColor, Font, FontSize)
							select GridSymboID, GridColumnType, Sort, GridColumnName, DataPropertyName, HeaderText, 
                            ToolTipText, LinkText, DataSource, DisplayMember, ValueMember, [ReadOnly], Width, Visible, IsPublic, Alignment, 
                            [Format], ForeColor, BackColor, Font, FontSize from GridColumnT_Temp; 
                            truncate table GridColumnT_Temp ";
                    obj = DB.ExecuteNonQuery(strGridColumnT);

                }
            }
            return obj;
        } 
        #endregion

        #region 取得來源資料庫的StatueRecordT資料表  public object GetSourceDataTableStatueRecordT()
        /// <summary>
        /// 取得來源資料庫的StatueRecordT資料表
        /// </summary>      
        /// <returns></returns>
        public object GetSourceDataTableStatueRecordT()
        {
        
            string strSQL = "Select *  FROM  StatueRecordT  with(nolock)  ";
            DataTable dtSource = new DataTable();
            object obj = DB.QueryToDataTableByDataAdapter(strSQL, ref dtSource, strConnectionString: strOriConnectionString);
            if (obj.ToString() == "0")
            {
                if (dtSource.Rows.Count > 0)
                {
                    //1.先刪除StatueRecordT_Temp的資料
                    obj = DB.ExecuteNonQuery(string.Format("truncate table {0}", "StatueRecordT_Temp"));

                    //2.新增至StatueRecordT_Temp資料
                    obj = DB.SqlBulkCopyWriteToServer(dtSource, DBAccess.ConnectionListDefaultConnectionString, "StatueRecordT_Temp");

                    //3. 更新StatueRecordT_Temp
                    string strTemp = @"update StatueRecordT_Temp set StatueRecordT_Temp.Value=(select Value From StatueRecordT  where StatueRecordT.StatusName=StatueRecordT_Temp.StatusName  ) 
                                                        where StatueRecordT_Temp.StatusName in (select StatusName from StatueRecordT)";
                    obj = DB.ExecuteNonQuery(strTemp);

                    //4.刪除StatueRecordT的資料
                    obj = DB.ExecuteNonQuery(string.Format("truncate table {0}", "StatueRecordT"));

                    //5.將StatueRecordT_Temp 存回StatueRecordT，並清空將 StatueRecordT_Temp
                    string strGridColumnT = @"insert StatueRecordT (StatusName, [Value], Remark,CreateDateTime, LastModifyDateTime)
							select  StatusName, [Value], Remark, CreateDateTime, LastModifyDateTime  from StatueRecordT_Temp; 
                    truncate table StatueRecordT_Temp ";
                    obj = DB.ExecuteNonQuery(strGridColumnT);
                }
            }
            return obj;
        }

        #endregion

        #region 取得來源資料庫的 ProgramT 資料表  public object GetSourceDataTableProgramT()
        /// <summary>
        /// 取得來源資料庫的 ProgramT 資料表
        /// </summary>      
        /// <returns></returns>
        public object GetSourceDataTableProgramT()
        {

            string strSQL = "delete ProgramT where isOpen='False'  ; Select *  FROM  ProgramT  with(nolock) where isOpen='True' order by ProgramSymbol";
            DataTable dtSource = new DataTable();
            object obj = DB.QueryToDataTableByDataAdapter(strSQL, ref dtSource, strConnectionString: strOriConnectionString);
            if (obj.ToString() == "0")
            {
                //設定PK 欄位
                if (dtSource.PrimaryKey.Length == 0)
                {
                    DataColumn[] pk = { dtSource.Columns["ProgramSymbol"] };
                    dtSource.PrimaryKey = pk;
                }

               foreach (DataRow dr in dtSource.Rows)
                {
                    string strOri = string.Format("select * from ProgramT where  isOpen='True'  and ProgramSymbol='{0}' ", dr["ProgramSymbol"].ToString());
                    DataTable dtDestination = new DataTable();
                     obj = DB.QueryToDataTableByDataAdapter(strOri, ref dtDestination);
                    if (dtDestination.Rows.Count == 1)
                    {
                        string strOriUpdate = string.Format("update ProgramT set ProgramName=N'{0}' ,ProgramKind={1}, sort={2},Description=N'{3}' ,IsOpen='{4}' where  ProgramSymbol='{4}' ", dr["ProgramName"].ToString(), dr["ProgramKind"].ToString(), dr["sort"].ToString(),dr["Description"].ToString(),dr["ProgramSymbol"].ToString(), dr["IsOpen"].ToString());
                        obj = DB.ExecuteNonQuery(strOriUpdate);
                    }
                    else if (dtDestination.Rows.Count == 0)
                    {
                        string strOriInsert = string.Format("insert ProgramT (ProgramName, ProgramKind, Sort,  Description ,ProgramSymbol,IsOpen) values (N'{0}',{1},{2},N'{3}' ,'{4}' ,'True') ", dr["ProgramName"].ToString(), dr["ProgramKind"].ToString(), dr["sort"].ToString(), dr["Description"].ToString(), dr["ProgramSymbol"].ToString());
                        obj = DB.ExecuteNonQuery(strOriInsert);
                    }

                }

            }
            return obj;
        }

        #endregion

        #region 寫入一筆更新記錄 public void UpdateLog()
        /// <summary>
        /// 寫入一筆更新記錄
        /// </summary>
        public void UpdateLog()
        {
           
            //來源資料表
            string strSQL = string.Format("Insert  PTS_UpdateLogT (ConnectionString,CreateDateTime) values(N'{0}',getdate())", DBAccess.ConnectionListDefaultConnectionString);
            DataTable dtSource = new DataTable();
            object obj = DB.ExecuteNonQuery(strSQL, strConnectionString: strOriConnectionString);
        }
        #endregion

        #region 取得是否有授權 public bool GetAuthorize(string InitialCatalog)
        /// <summary>
        /// 取得是否有授權
        /// </summary>
        /// <param name="InitialCatalog"></param>
        /// <returns></returns>
        public bool GetAuthorize(string InitialCatalog)
        {          
            //來源資料表
            string strSQL = string.Format("select  AuthorizeDate, AuthorizeMonth from PTS_AuthorizeT with(nolock) where AuthorizeType=0 and InitialCatalog='{0}' ", InitialCatalog);
            DataTable dtSource = new DataTable();
            object obj = DB.QueryToDataTableByDataAdapter(strSQL, ref dtSource, strConnectionString: strOriConnectionString);

            bool isAuthorize = true;//預設為同意授權
            if (obj.ToString() == "0")
            {
                if (dtSource.Rows.Count == 1)
                {
                    DateTime dtAuthorizeDate;
                    bool isAuthorizeDate = DateTime.TryParse(dtSource.Rows[0]["AuthorizeDate"].ToString(), out dtAuthorizeDate);

                    int iAuthorizeMonth = (int)dtSource.Rows[0]["AuthorizeMonth"];

                    DateTime dt_EndAuthorizeDate = dtAuthorizeDate.AddMonths(iAuthorizeMonth);

                    if (dt_EndAuthorizeDate < DateTime.Now)
                    {
                        isAuthorize = false;
                    }

                }
            }

            return isAuthorize;
        } 
        #endregion


    }
}
