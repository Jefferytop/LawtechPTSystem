using H3Operator.DBHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LawtechPTSystem.Public
{
    public  class  DLL
    {
                    
        #region Property

        #region 上傳資料夾名稱
        /// <summary>
        /// 專利上傳的資料夾名稱
        /// </summary>
        private const string constPatFolder = "PatentFolder";

        /// <summary>
        /// 商標上傳的資料夾名稱
        /// </summary>
        private const string constTmFolder = "TrademarkFolder";

        /// <summary>
        /// 商標異議案上傳的資料夾名稱
        /// </summary>
        private const string constTmControversyFolder = "TrademarkControversyFolder";

        /// <summary>
        /// 客戶上傳的資料夾名稱
        /// </summary>
        private const string constCustomerFolder = "CustomerFolder";

        /// <summary>
        /// 複代/事務所上傳的資料夾名稱
        /// </summary>
        private const string constFirmFolder = "FirmFolder";

        /// <summary>
        /// 公用的上傳的資料夾名稱
        /// </summary>
        private const string constPublicFolder = "PublicFolder";

        /// <summary>
        /// EMail Log上傳的資料夾名稱
        /// </summary>
        private const string constEmailLog = "EmailLog";

        /// <summary>
        ///知識管理上傳的資料夾名稱
        /// </summary>
        private const string constKM = "KMFolder";

        /// <summary>
        ///刪除log上傳的資料夾名稱
        /// </summary>
        private const string constDelFileLog = "DelFileLog"; 
       

        /// <summary>
        /// 資產管理上傳的資料夾名稱
        /// </summary>
        private const string constOfficeProperty = "OfficeProperty";

        #endregion

        private string _ConnString = Public.PublicCommonFunction.GetConnectionString();

        private  string _SqlCommand = string.Empty;
        /// <summary>
        /// 對SQL Server下達SQL指令行。
        /// </summary>
        public string SqlCommand
        {
            get { return _SqlCommand; }
            set { _SqlCommand = value; }
        }

        private SqlConnection _Connection = null;
        /// <summary>
        /// SQL Connection
        /// </summary>
        public SqlConnection Connection
        {
            get { return _Connection; }
            set { _Connection = value; }
        }

        private SqlCommand _Command = null;
        /// <summary>
        /// SQL Command
        /// </summary>
        public SqlCommand Command
        {
            get { return _Command; }
            set { _Command = value; }
        }

        #region 最上層資料夾名稱
        private string strRootFolder="";
        /// <summary>
        /// 最上層的資料夾 
        /// </summary>
        public string RootFolder
        {
            get { return FileRootFolder(); }
            set { strRootFolder = value; }
        }
        #endregion 

        private bool bIsFileServer = false;
        /// <summary>
        ///是否啟用檔案上傳功能(0:否 ; 1:是)
        /// </summary>
        public bool IsFileServer
        {
            get { return GetIsFileServer(); }
            set { bIsFileServer = value; }
        }

        private string strFileServerType = "";
        /// <summary>
        /// 0:本機路徑 ; 1:區域網路
        /// </summary>
        public string FileServerType
        {
            get { return GetFileServerType(); }
            set { strFileServerType = value; }
        }

        private string strFileServerLocalhostPath = "";
        /// <summary>
        /// 預設本機路徑
        /// </summary>
        public string FileServerLocalhostPath
        {
            get { return GetFileServerLocalhostPath(); }
            set { strFileServerLocalhostPath = value; }
        }

        
        /// <summary>
        /// 區域網路路徑
        /// </summary>
        public string FileServerIntranetPath
        {
            get { return GetIntranetPath(); }
           
        }

      
        private string strFileServer_IP="";
        /// <summary>
        /// 檔案伺服器的IP 位址 /{ip}/{FileServerFolder}/{RootFolder}
        /// </summary>
        public string FileServer_IP
        {
            get { return GetFileServerIP(); }
            set { strFileServer_IP = value; }
        }


        private string strFileServerFolder="";
        /// <summary>
        /// 檔案伺服器上的資料夾 /{ip}/{FileServerFolder}/{RootFolder}
        /// </summary>
        public string FileServerFolder
        {
            get { return FileServerPath(); }
            set { strFileServerFolder = value; }
        }

        /// <summary>
        /// 檔案伺服器的完整路徑 
        /// 1.)判斷是否有啟用檔案上傳功能
        /// 2.)判斷檔案上傳類型
        /// </summary>
        public string FileServerFullPath
        {
            get {
                bIsFileServer = GetIsFileServer();
                //啟用檔案上傳功能
                if (bIsFileServer)
                {
                    if ( FileServerType == "0") // 0:本機路徑; 1:區域網路
                    {
                        //系統預設本機徑
                        string strServerLocalhostPath = FileServerLocalhostPath;

                        //使用者自行設定的本機路徑
                        string strUserLocalPath = Properties.Settings.Default.FileServerLocalhostPath_WorkerT == null ? "" : Properties.Settings.Default.FileServerLocalhostPath_WorkerT;

                        if (strUserLocalPath.Trim() != "" )
                        {
                            return Path.Combine(strUserLocalPath , RootFolder);
                        }
                        else if (strUserLocalPath.Trim() == "" && strServerLocalhostPath.Trim() != "")
                        {
                            return Path.Combine(FileServerLocalhostPath , RootFolder);
                        }
                        else {
                            return "";
                        }
                    }
                    else
                    {
                        return Path.Combine(FileServerIntranetPath, RootFolder);
                    }
                }
                else
                {
                    return "";
                }
            }
        }

        /// <summary>
        /// 刪除附件(Del File Log)的上層資料夾路徑 root\OfficeData\UpFileLog
        /// </summary>
        public string DelFileFolderRoot
        {
            get
            {              
                string pathDir = this.FileServerFullPath;//檔案伺服器的路徑
                string PatentFolder = string.Format(@"{0}\{1}", pathDir, constDelFileLog);
                return PatentFolder;
            }
        }

        /// <summary>
        /// 所內財產的上層資料夾路徑 root\OfficeData\OfficeProperty
        /// </summary>
        public string OfficePropertyFolderRoot
        {
            get
            {               
                string pathDir = this.FileServerFullPath;//檔案伺服器的路徑
                string PatentFolder = string.Format(@"{0}\{1}", pathDir, constOfficeProperty);
                return PatentFolder;
            }
        }

        /// <summary>
        /// 知識管理的上層資料夾路徑 root\OfficeData\KM
        /// </summary>
        public string KMFolderRoot
        {
            get
            {               
                string pathDir =  this.FileServerFullPath;//檔案伺服器的路徑
                string PatentFolder = string.Format(@"{0}\{1}", pathDir, constKM);
                return PatentFolder;
            }
        }

        /// <summary>
        /// 客戶(申請人)檔案的上層資料夾路徑 root\OfficeData\Customer
        /// </summary>
        public string CustomerFolderRoot
        {
            get
            {                
                string pathDir = this.FileServerFullPath;//檔案伺服器的路徑
                string PatentFolder = string.Format(@"{0}\{1}", pathDir, constCustomerFolder);
                return PatentFolder;
            }
        }

        /// <summary>
        /// 事務所檔案的上層資料夾路徑 root\OfficeData\Firm
        /// </summary>
        public string FirmFolderRoot
        {
            get
            {               
                string pathDir = this.FileServerFullPath;//檔案伺服器的路徑
                string PatentFolder = string.Format(@"{0}\{1}", pathDir, constFirmFolder);
                return PatentFolder;
            }
        }

        /// <summary>
        /// 專利的上層資料夾路徑 root\OfficeData\Patent
        /// </summary>
        public string PatentFolderRoot
        {
            get
            {
                string pathDir = this.FileServerFullPath;
                string PatentFolder = string.Format(@"{0}\{1}", pathDir, constPatFolder);
                return PatentFolder;
            }
        }

        /// <summary>
        /// 商標的上層資料夾路徑 Trademark
        /// </summary>
        public string TrademarkFolderRoot
        {
            get
            {               
                string pathDir =this.FileServerFullPath;//檔案伺服器的路徑
                string PatentFolder = string.Format(@"{0}\{1}", pathDir,constTmFolder);
                return PatentFolder;
            }
        }

        /// <summary>
        /// 商標異議案的上層資料夾路徑 TrademarkControversy
        /// </summary>
        public string TrademarkControversyFolderRoot
        {
            get
            {
                
                string pathDir = this.FileServerFullPath;//檔案伺服器的路徑
                string PatentFolder = string.Format(@"{0}\{1}", pathDir, constTmControversyFolder);
                CreatFolder(PatentFolder);
                return PatentFolder;
            }
        }

        /// <summary>
        ///  公用資料夾 PublicFolder 
        /// </summary>
        public string GeneralFolderRoot
        {
            get
            {             
                string pathDir = this.FileServerFullPath;//檔案伺服器的路徑
                string PatentFolder = string.Format(@"{0}\{1}", pathDir, constPublicFolder);
                return PatentFolder;
            }
        }


        /// <summary>
        ///  上傳文章所使用的資料夾 {PublicFolder}\Upload
        /// </summary>
        public string GeneralFolderRootUpload
        {
            get
            {             
                string pathDir = this.FileServerFullPath;//檔案伺服器的路徑
                string PatentFolder = string.Format(@"{0}\{1}\{2}", pathDir, constPublicFolder,"Upload");
                return PatentFolder;
            }
        }

        /// <summary>
        /// 專門放法條依據的上傳檔案 {PublicFolder}\BasedOn
        /// </summary>
        public string GeneralBasedOnFolderRoot
        {
            get
            {              
                string pathDir = this.FileServerFullPath;//檔案伺服器的路徑
                string PatentFolder = string.Format(@"{0}\{1}\{2}", pathDir, constPublicFolder, "BasedOn");
                return PatentFolder;
            }
        }

        /// <summary>
        /// Email Log的上層資料夾路徑 EmailLog
        /// </summary>
        public string EmailLogFolderRoot
        {
            get
            {              
                string pathDir = this.FileServerFullPath;//檔案伺服器的路徑
                string PatentFolder = string.Format(@"{0}\{1}", pathDir, constEmailLog);
                return PatentFolder;
            }
        }

        #endregion

        #region 專利管制年費的期限 設定幾個月
        /// <summary>
        /// 專利管制年費的期限
        /// </summary>
        public decimal GetPatentControlPeriodTime
        {
            get {
                return PatentControlPeriodTime();
            }
        }

        public decimal PatentControlPeriodTime()
        {
         Public.DLL dll = new Public.DLL();
            string strSQL = "select Value from StatueRecordT with(nolock) where StatusName='PatentControlFee'";
           object obj= dll.SQLexecuteScalar(strSQL);

           if (obj == null)
           {
               return 0;
              
           }
           else
           {
               return decimal.Parse(obj.ToString());
           }
        }
        #endregion

        #region 商標延展的期限 設定幾個月
        /// <summary>
        /// 商標延展的期限
        /// </summary>
        public decimal GetTrademarkControlPeriodTime
        {
            get
            {
                return TrademarkControlPeriodTime();
            }
        }

        /// <summary>
        /// 商標延展的期限 設定幾個月
        /// </summary>
        /// <returns></returns>
        public decimal TrademarkControlPeriodTime()
        {
            Public.DLL dll = new Public.DLL();
            string strSQL = "select Value from StatueRecordT with(nolock) where StatusName='TrademarkControlFee'";
            object obj = dll.SQLexecuteScalar(strSQL);

            if (obj == null)
            {
                return 0;

            }
            else
            {
                return decimal.Parse(obj.ToString());
            }
        }
        #endregion

        #region  ==============GetPatentNO================
        /// <summary>
        /// 申請案編號,例:97038 ([西元年-1911 固定2碼]+[每年從0起跳 3碼])
        /// </summary>
        /// <param name="parYear">年份 例:2008年-->2008</param>
        /// <returns></returns>
        public string GetPatentNO(int parYear)
        {
            int iYear = parYear - 1911;
            string Restr = "";
            string code = "";
            if (parYear < 2271)//
            {
                if (iYear.ToString().Length > 2)
                {
                    switch (iYear.ToString().Substring(0, 2))
                    {
                        case "10":
                            code = "A";
                            break;
                        case "11":
                            code = "B";
                            break;
                        case "12":
                            code = "C";
                            break;
                        case "13":
                            code = "D";
                            break;
                        case "14":
                            code = "E";
                            break;
                        case "15":
                            code = "F";
                            break;
                        case "16":
                            code = "G";
                            break;
                        case "17":
                            code = "H";
                            break;
                        case "18":
                            code = "I";
                            break;
                        case "19":
                            code = "J";
                            break;
                        case "20":
                            code = "K";
                            break;
                        case "21":
                            code = "L";
                            break;
                        case "22":
                            code = "M";
                            break;
                        case "23":
                            code = "N";
                            break;
                        case "24":
                            code = "O";
                            break;
                        case "25":
                            code = "P";
                            break;
                        case "26":
                            code = "Q";
                            break;
                        case "27":
                            code = "R";
                            break;
                        case "28":
                            code = "S";
                            break;
                        case "29":
                            code = "T";
                            break;
                        case "30":
                            code = "U";
                            break;
                        case "31":
                            code = "V";
                            break;
                        case "32":
                            code = "W";
                            break;
                        case "33":
                            code = "X";
                            break;
                        case "34":
                            code = "Y";
                            break;
                        case "35":
                            code = "Z";
                            break;
                    }
                    Restr = code + iYear.ToString().Substring(iYear.ToString().Length - 1);
                }
                else
                {
                    Restr = iYear.ToString();
                }

                SqlConnection conn = new SqlConnection(DBAccess.ConnectionListDefaultConnectionString);

                string str = "SELECT TOP 1 CONVERT(int, REPLACE(PatentNo, '" + Restr + "', 0)) AS Number FROM PatentManagementT WHERE  (PatentNo LIKE '" + Restr + "%') ORDER BY Number DESC";

                SqlCommand comm = new SqlCommand(str, conn);

                conn.Open();
                object obj = comm.ExecuteScalar();
                conn.Close();

                if (obj != null && obj.ToString() != "")
                {

                    int i = int.Parse(obj.ToString());

                    if (i < 9999)//流水號差過999之後重新計算
                    {
                        i++;
                        Restr += i.ToString("D4");
                    }
                    else
                    {
                        Restr = "0001";
                    }
                }
                else
                {
                    Restr += "0001";
                }
            }


            return Restr;

        }
        #endregion

        #region 使用SQL指令並回傳影響筆數
        /// <summary>
        /// 使用SQL指令並回傳影響筆數。
        /// </summary>
        /// <param name="SqlCommand">SQL指令字串</param>
        /// <returns>回傳筆數，如為-1則失敗。</returns>
        public int Update(string SqlCommand)
        {
            int ResultCount = -1;
            if (_Connection == null) _Connection = new SqlConnection(DBAccess.ConnectionListDefaultConnectionString);
            if (_Command == null) _Command = new SqlCommand(SqlCommand, _Connection);

            try
            {
                _Command.Connection.Open();
                ResultCount = _Command.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                Utility.WriteLog("Error on SqlException:" + ex.Message);
            }
            catch (Exception ex)
            {
                Utility.WriteLog("Error on Exception:" + ex.Message);
            }
            finally
            {
                if (_Connection.State == ConnectionState.Open)
                    _Connection.Close();
            }
            return ResultCount;
        }
        #endregion 

        #region 指定資料表回傳資料
        /// <summary>
        /// 指定資料表回傳資料
        /// </summary>
        /// <param name="SqlCommand">SQL指令</param>
        /// <returns></returns>
        public System.Data.DataTable FetchDataTable(string SqlCommand)
        {
            
            if (_Connection == null) _Connection = new SqlConnection(DBAccess.ConnectionListDefaultConnectionString);
            if (_Command == null) _Command = new SqlCommand(SqlCommand, _Connection);
            SqlDataAdapter _DataAdapter;
            DataSet ds = new DataSet();

            try
            {
                _DataAdapter = new SqlDataAdapter(_Command);
                _DataAdapter.Fill(ds);
            }
            catch (SqlException ex)
            {
                Utility.WriteLog("Error on SqlException:" + ex.Message);
            }
            catch (Exception ex)
            {
                Utility.WriteLog("Error on Exception:" + ex.Message);
            }
            finally
            {
                if (_Connection.State == ConnectionState.Open)
                    _Connection.Close();
            }
            return ds.Tables[0];
        }

        
        /// <summary>
        /// 指定資料表回傳資料
        /// </summary>
        /// <param name="SqlCommand">SQL指令</param>
        /// <param name="DT">指定DataTable</param>
        /// <returns></returns>
        public void FetchDataTable(string SqlCommand, DataTable DT)
        {
            
            if (_Connection == null) _Connection = new SqlConnection(DBAccess.ConnectionListDefaultConnectionString);
            if (_Command == null) _Command = new SqlCommand(SqlCommand, _Connection);
            SqlDataAdapter _DataAdapter;
            if (DT == null) DT = new DataTable();
            if (DT.Rows.Count > 0) DT.Clear();

            try
            {
                _DataAdapter = new SqlDataAdapter(_Command);
                _DataAdapter.Fill(DT);
            }
            catch (SqlException ex)
            {
                Utility.WriteLog("Error on SqlException:" + ex.Message);
            }
            catch (Exception ex)
            {
                Utility.WriteLog("Error on Exception:" + ex.Message);
            }
            finally
            {
                if (_Connection.State == ConnectionState.Open)
                    _Connection.Close();
            }
        }
        #endregion

        #region ============SqlDataAdapterDataTable===============
        /// <summary>
        /// SqlDataAdapter.Fill()
        /// </summary>
        /// <param name="SqlCommand">SQL語法</param>
        /// <returns></returns>
        public DataTable  SqlDataAdapterDataTable(string SqlCommand)
        {

            if (_Connection == null) _Connection = new SqlConnection(DBAccess.ConnectionListDefaultConnectionString); //Properties.Settings.Default.DataBaseConnectionString

            SqlDataAdapter _DataAdapter = new SqlDataAdapter(SqlCommand, _Connection);

            DataTable DT = new DataTable();
            try
            {
               
                _DataAdapter.Fill(DT);
            }
            catch (SqlException ex)
            {
                Utility.WriteLog("Error on SqlException:" + ex.Message);
            }
            catch (Exception ex)
            {
                Utility.WriteLog("Error on Exception:" + ex.Message);
            }
            finally
            {
                if (_Connection.State == ConnectionState.Open)
                    _Connection.Close();
            }

            return DT;
        }      

        /// <summary>
        /// SqlDataAdapter
        /// </summary>
        /// <param name="SqlCommand">sql查詢字串</param>
        /// <param name="CombineTable">匯入指定的資料表</param>
        /// <param name="IsClear">是否清空原本的資料</param>
        public void SqlDataAdapterDataTable(string SqlCommand, ref DataTable CombineTable,bool IsClear=true)
        {

            if (_Connection == null) _Connection = new SqlConnection(DBAccess.ConnectionListDefaultConnectionString);

            SqlDataAdapter _DataAdapter = new SqlDataAdapter(SqlCommand, _Connection);


            if (CombineTable != null && CombineTable.Rows.Count > 0 && IsClear)
            {
                CombineTable.Rows.Clear();
            }
           
            try
            {
                _DataAdapter.Fill(CombineTable);
            }
            catch (SqlException ex)
            {
                Utility.WriteLog("Error on SqlException:" + ex.Message);
            }
            catch (Exception ex)
            {
                Utility.WriteLog("Error on Exception:" + ex.Message);
            }
            finally
            {
                if (_Connection.State == ConnectionState.Open)
                    _Connection.Close();
            }
                       
        }

        /// <summary>
        /// SqlDataAdapter.Fill()
        /// </summary>
        /// <param name="SqlCommand">SQL語法</param>
        /// <returns></returns>
        public DataSet SqlDataAdapterDataSet(string SqlCommand)
        {

            if (_Connection == null) _Connection = new SqlConnection(DBAccess.ConnectionListDefaultConnectionString);

            SqlDataAdapter _DataAdapter = new SqlDataAdapter(SqlCommand, _Connection);

            DataSet DT = new DataSet();
            try
            {
              
                _DataAdapter.Fill(DT);
            }
            catch (SqlException ex)
            {
                Utility.WriteLog("Error on SqlException:" + ex.Message);
            }
            catch (Exception ex)
            {
                Utility.WriteLog("Error on Exception:" + ex.Message);
            }
            finally
            {
                if (_Connection.State == ConnectionState.Open)
                    _Connection.Close();
            }

            return DT;
        }
        #endregion

        #region 大量儲存資料到資料表
        /// <summary>
        /// 大量儲存資料到資料表
        /// </summary>
        /// <param name="DataSourceDT">來源資料表</param>
        /// <param name="DestTableName">目地資料表名稱</param>
        public void DataBulkCopy(DataTable DataSourceDT, string DestTableName)
        {

            _Connection = new SqlConnection(DBAccess.ConnectionListDefaultConnectionString);
            _Command = new SqlCommand(SqlCommand, _Connection);

            try
            {
                _Connection.Open();
                using (SqlBulkCopy sbc = new SqlBulkCopy(_Connection))
                {
                    sbc.DestinationTableName = DestTableName;
                    sbc.WriteToServer(DataSourceDT);
                }
            }
            catch (SqlException ex)
            {
                Utility.WriteLog("Error on SqlException:" + ex.Message);
            }
            catch (Exception ex)
            {
                Utility.WriteLog("Error on Exception:" + ex.Message);
            }
            finally
            {
                if (_Connection.State == ConnectionState.Open)
                    _Connection.Close();
            }
        }
        #endregion

        #region ================SQLexecuteScalar===================
        /// <summary>
        /// 執行sql語法，回傳結果的第一行第一列的資料，同Command.ExecuteScalar()
        /// </summary>
        /// <param name="strSQL">SQL語法</param>
        /// <returns></returns>
        public object SQLexecuteScalar(string strSQL)
        {
            _Connection = new SqlConnection(DBAccess.ConnectionListDefaultConnectionString);
            _Command = new SqlCommand(strSQL, _Connection);
            object obj = null;
            try
            {
                _Connection.Open();
                obj = _Command.ExecuteScalar();
                _Connection.Close();
                return obj;
            }
            catch (SqlException ex)
            {
                Utility.WriteLog("Error on SqlException:" + ex.Message);
                return obj;
            }
            catch (Exception ex)
            {
                Utility.WriteLog("Error on Exception:" + ex.Message);
                return obj;
            }
            finally
            {
                if (_Connection.State == ConnectionState.Open)
                { _Connection.Close(); }
            }
        }
        #endregion

        #region ==============SQLexecuteNonQuery==================
        /// <summary>
        /// 執行SQL陳述式，同Command.ExecuteNonQuery()
        /// </summary>
        /// <param name="strSQL">SQL語法</param>
        public void SQLexecuteNonQuery(string strSQL)
        {
            _Connection = new SqlConnection(DBAccess.ConnectionListDefaultConnectionString);
            _Command = new SqlCommand(strSQL, _Connection);
            try
            {
                _Connection.Open();
                int iRe = _Command.ExecuteNonQuery();
                _Connection.Close();

            }
            catch (SqlException ex)
            {
                Utility.WriteLog("Error on SqlException:" + ex.Message);
            }
            catch (Exception ex)
            {
                Utility.WriteLog("Error on Exception:" + ex.Message);
            }
            finally
            {
                if (_Connection.State == ConnectionState.Open)
                    _Connection.Close();

            }
        }
        #endregion

      

        #region  ==============GetRandom================
        /// <summary>
        /// 回傳一組亂數，預設六碼亂數
        /// </summary>
        /// <returns></returns>
        public  string GetRandom()
        {
            string[] ss = new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "W", "X", "Y", "Z" };
            string Restr = "";
            Random k = new Random();
            for (int i = 0; i < 6; i++)
            {

                Restr += ss[k.Next(0, 34)];
            }

            return Restr;
        }

        /// <summary>
        ///  回傳一組亂數
        /// </summary>
        /// <param name="iNum">定義要回傳幾碼的亂數</param>
        /// <returns></returns>
        public  string GetRandom(int iNum)
        {
            string[] ss = new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "W", "X", "Y", "Z" };
            string Restr = "";
            Random k = new Random();
            for (int i = 0; i < iNum; i++)
            {

                Restr += ss[k.Next(0, 34)];
            }

            return Restr;
        }
        #endregion

        #region ===========FTPServerEnable=============
        /// <summary>
        /// 是否啟用FTP
        /// </summary>
        /// <returns></returns>
        public bool FTPServerEnable()
        {
            string Value = SQLexecuteScalar("select value from StatueRecordT where StatusName='FTPServerEnable'").ToString();
            bool ReValue = Value == "0" ? false : true;

            return ReValue;

        }
        #endregion

        #region ===========IsFileServer=============
        /// <summary>
        /// 是否啟用檔案上傳功能
        /// </summary>
        /// <returns></returns>
        public bool GetIsFileServer()
        {
            //if(Properties.Settings.Default.IsFileServer)
            //string Value = SQLexecuteScalar("select value from StatueRecordT where StatusName='IsFileServer'").ToString();
            //bool ReValue = Value == "0" ? false : true;

            return Properties.Settings.Default.IsFileServer;

        }
        #endregion

        #region ===========FileServerPath=============
        /// <summary>
        /// 回傳檔案伺服器上的資料夾名稱 /{ip}/{FileServerFolder}/{RootFolder}
        /// </summary>
        /// <returns></returns>
        public string FileServerPath()
        {
            if (strFileServerFolder.Trim() == "")
            {
                strFileServerFolder = SQLexecuteScalar("select value from StatueRecordT where StatusName='FileServerFolder'").ToString();
               
            }

            return strFileServerFolder;
           
        }
        #endregion

        #region ===========FileRootFolder=============
        /// <summary>
        /// 最上層的資料夾名稱 
        /// </summary>
        /// <returns></returns>
        public string FileRootFolder()
        {
             return Properties.Settings.Default.RootFolder   ;
        }
        #endregion

        #region ===========GetFileServerType=============
        /// <summary>
        /// 檔案伺服器的類型  0:本機路徑 ; 1:區域網路
        /// </summary>
        /// <returns></returns>
        public string GetFileServerType()
        {
            if (strFileServerType.Trim() == "")
            {
                strFileServerType = SQLexecuteScalar("select value from StatueRecordT where StatusName='FileServerType'").ToString();
            }

            return strFileServerType;
        }
        #endregion

        #region ===========GetFileServerLocalhostPath=============
        /// <summary>
        /// 預設本機路徑  
        /// </summary>
        /// <returns></returns>
        public string GetFileServerLocalhostPath()
        {           
            return Properties.Settings.Default.FileServerLocalhostPath;
        }
        #endregion

        #region ===========GetFileServerLocalhostPath=============
        /// <summary>
        /// 區域網路路徑  
        /// </summary>
        /// <returns></returns>
        public string GetIntranetPath()
        { 
            return Properties.Settings.Default.IntranetPath;
        }
        #endregion


        #region ===========GetFileServerIP=============
        /// <summary>
        /// 取得檔案伺服務器的IP位址 /{ip}/{FileServerFolder}/{RootFolder}
        /// </summary>
        /// <returns></returns>
        public string GetFileServerIP()
        {
            if (strFileServer_IP.Trim() == "")
            {
                strFileServer_IP = SQLexecuteScalar("select value from StatueRecordT where StatusName='FileServer_IP'").ToString();
            }

            return strFileServer_IP;
        }
        #endregion

        #region 取得最大的排序編號
        /// <summary>
        /// 取得最大的排序編號
        /// </summary>
        /// <param name="TableName">資料表名稱</param>
        /// <param name="ColunmName">欄位名稱，一般預設是Sort</param>
        /// <returns></returns>
        private static int getMaxSn(string TableName, string ColunmName)
        {

            DBAccess helper = new DBAccess();
            string sqlStr = string.Format(@"SELECT     MAX({0}) + 1 AS maxNo
                                    FROM         {1} ", ColunmName, TableName);


            object maxSn=new object();
            object obj = helper.ExecuteScaler(sqlStr, ref maxSn, null);


            if (maxSn == null)
            {
                return 0;
            }
            else
            {
                return int.Parse(maxSn.ToString());
            }
        }
        #endregion

        #region ==========建立資料夾===========
        
        /// <summary>
        /// 建立基本的上傳資料夾OfficeData、general、BasedOn 、Patent、Trademark、TrademarkControversy、KM、EmailLog、DelFileLog(UpFileLog)、Firm、Customer
        /// </summary>        
        /// <param name="iFullPath"></param>
        public void CreatFolder( bool iFullPath)
        {
            string pathDir="";
            bool isCheckPathDir = true;
            try
            {
                pathDir = this.FileServerFullPath;

                if (!Directory.Exists(pathDir))
                {
                    Directory.CreateDirectory(pathDir); //建立資料夾 \\ServerPath\OfficeSystemData\                                           
                }

                if (!Directory.Exists(string.Format(@"{0}\{1}", pathDir, "PublicFolder"))) //公用資料夾 general
                {
                    Directory.CreateDirectory(string.Format(@"{0}\{1}", pathDir, "PublicFolder"));
                }

                if (!Directory.Exists(string.Format(@"{0}\{1}\{2}", pathDir, "General", "BasedOn"))) //公用資料夾 general\BasedOn專門放法條依據的上傳檔案
                {
                    Directory.CreateDirectory(string.Format(@"{0}\{1}\{2}", pathDir, "General", "BasedOn"));
                }

                if (!Directory.Exists(string.Format(@"{0}\{1}", pathDir, "PatentFolder"))) //專利資料夾 Patent
                {
                    Directory.CreateDirectory(string.Format(@"{0}\{1}", pathDir, "PatentFolder"));
                }

                if (!Directory.Exists(string.Format(@"{0}\{1}", pathDir, "TrademarkFolder"))) //商標資料夾 Trademark
                {
                    Directory.CreateDirectory(string.Format(@"{0}\{1}", pathDir, "TrademarkFolder"));
                }

                //if (!Directory.Exists(string.Format(@"{0}\{1}", pathDir, "TrademarkControversy"))) //商標異議案資料夾 TrademarkControversy
                //{
                //    Directory.CreateDirectory(string.Format(@"{0}\{1}", pathDir, "TrademarkControversy"));
                //}


                if (!Directory.Exists(string.Format(@"{0}\{1}", pathDir, "OfficeProperty"))) //所內財產資料夾 OfficeProperty
                {
                    Directory.CreateDirectory(string.Format(@"{0}\{1}", pathDir, "OfficeProperty"));
                }

                if (!Directory.Exists(string.Format(@"{0}\{1}", pathDir, "KM"))) //知識管理資料夾 KM
                {
                    Directory.CreateDirectory(string.Format(@"{0}\{1}", pathDir, "KM"));
                }

                if (!Directory.Exists(string.Format(@"{0}\{1}", pathDir, "EmailLog"))) //Email Log的附加檔案 EmailLog
                {
                    Directory.CreateDirectory(string.Format(@"{0}\{1}", pathDir, "EmailLog"));
                }

                //if (!Directory.Exists(string.Format(@"{0}\{1}", pathDir, "DelFileLog"))) //Del File Log的附加檔案 UpFileLog
                //{
                //    Directory.CreateDirectory(string.Format(@"{0}\{1}", pathDir, "DelFileLog"));
                //}

                if (!Directory.Exists(string.Format(@"{0}\{1}", pathDir, "CustomerFolder"))) //客戶(申請人)的附加檔案 Customer
                {
                    Directory.CreateDirectory(string.Format(@"{0}\{1}", pathDir, "CustomerFolder"));
                }

                if (!Directory.Exists(string.Format(@"{0}\{1}", pathDir, "FirmFolder"))) //事務所的附加檔案 Firm
                {
                    Directory.CreateDirectory(string.Format(@"{0}\{1}", pathDir, "FirmFolder"));
                }

            }
            catch
            {
                isCheckPathDir = false;
                //MessageBox.Show(string.Format("找不到網路路徑:{0}\r\n您目前不是在指定的網路內，上傳檔案將會失敗\r\n但不影響其它的操作\r\n{1}", pathDir, EX.Message));
            }
            finally {
                Properties.Settings.Default.IsFileServerConnection = isCheckPathDir;
                Properties.Settings.Default.Save();
            }

        }

      

        /// <summary>
        /// 建立基本的上傳資料夾OfficeData、general、BasedOn 並回傳目的檔路路徑
        /// </summary>
        /// <param name="iMode">1.段落依據 2.相關檔案管理 3.專利案件相關檔案管理 4.商標案件相關檔案管理 5.商標異議案件相關檔案管理 6.所內財產資料夾 10.知識管理 20.EmailLog的附件 30.DelFileLog 40.客戶(申請人)的附件  50.事務所的附件</param>
        /// <param name="sDoc">建立的資料夾名稱[當iMode=2時, sDoc參數必為空值],sDoc該key值</param>
        public string CreatFolder(int iMode ,string sDoc)
        {
            //當不啟用FTP時直接返回空字串
            if (!Properties.Settings.Default.IsFileServer)
            {
                return "";
            }
            string result = string.Empty;
            //this.CreatFolder();//建立本本資料夾         

            string pathDir = FileServerFullPath;//檔案伺服器的路徑

            try
            {
                switch (iMode)
                {
                    case 1://段落依據
                        if (!Directory.Exists(string.Format(@"{0}\{1}\{2}\{3}", pathDir, constPublicFolder, "BasedOn", sDoc))) //sDoc該申請需知的key值
                        {
                            Directory.CreateDirectory(string.Format(@"{0}\{1}\{2}\{3}", pathDir, constPublicFolder, "BasedOn", sDoc));
                        }
                        result = string.Format(@"{0}\{1}\{2}\{3}", pathDir, constPublicFolder, "BasedOn", sDoc);
                        break;

                    case 2://相關檔案管理
                        if (!Directory.Exists(string.Format(@"{0}\{1}\{2}", pathDir, constPublicFolder, "Upload"))) //sDoc該檔案上傳的key值-UploadT.UploadKey
                        {
                            Directory.CreateDirectory(string.Format(@"{0}\{1}\{2}", pathDir, constPublicFolder, "Upload"));
                        }
                        result = string.Format(@"{0}\{1}\{2}", pathDir, constPublicFolder, "Upload");
                        break;

                    case 3://專利案件相關檔案管理
                        if (!Directory.Exists(string.Format(@"{0}\{1}", pathDir, constPatFolder))) //建立專利的主目錄
                        {
                            Directory.CreateDirectory(string.Format(@"{0}\{1}", pathDir, constPatFolder));
                        }

                        if (!Directory.Exists(string.Format(@"{0}\{1}\{2}", pathDir, constPatFolder, sDoc))) //建立專利的案件目錄，sDoc為資料夾名稱
                        {
                            Directory.CreateDirectory(string.Format(@"{0}\{1}\{2}", pathDir, constPatFolder, sDoc));
                        }
                        result = string.Format(@"{0}\{1}\{2}", pathDir, constPatFolder, sDoc);
                        break;

                    case 4://商標案件相關檔案管理
                        if (!Directory.Exists(string.Format(@"{0}\{1}", pathDir, constTmFolder)))//建立商標的主目錄
                        {
                            Directory.CreateDirectory(string.Format(@"{0}\{1}", pathDir, constTmFolder));
                        }

                        if (!Directory.Exists(string.Format(@"{0}\{1}\{2}", pathDir, constTmFolder, sDoc)))//建立商標的專案目錄，sDoc為資料夾名稱
                        {
                            Directory.CreateDirectory(string.Format(@"{0}\{1}\{2}", pathDir, constTmFolder, sDoc));
                        }
                        result = string.Format(@"{0}\{1}\{2}", pathDir, constTmFolder, sDoc);
                        break;

                    case 5://商標異議案件相關檔案管理
                        if (!Directory.Exists(string.Format(@"{0}\{1}", pathDir, constTmControversyFolder)))//建立商標的主目錄
                        {
                            Directory.CreateDirectory(string.Format(@"{0}\{1}", pathDir, constTmControversyFolder));
                        }

                        if (!Directory.Exists(string.Format(@"{0}\{1}\{2}", pathDir, constTmControversyFolder, sDoc)))//建立商標的專案目錄，sDoc為資料夾名稱
                        {
                            Directory.CreateDirectory(string.Format(@"{0}\{1}\{2}", pathDir, constTmControversyFolder, sDoc));
                        }
                        result = string.Format(@"{0}\{1}\{2}", pathDir, constTmControversyFolder, sDoc);
                        break;
                    case 6://所內財產資料夾
                        if (!Directory.Exists(string.Format(@"{0}\{1}", pathDir, constOfficeProperty)))//建立所內財產的主目錄
                        {
                            Directory.CreateDirectory(string.Format(@"{0}\{1}", pathDir, constOfficeProperty));
                        }

                        if (!Directory.Exists(string.Format(@"{0}\{1}\{2}", pathDir, constOfficeProperty, sDoc)))//建立所內財產目錄，sDoc為資料夾名稱
                        {
                            Directory.CreateDirectory(string.Format(@"{0}\{1}\{2}", pathDir, constOfficeProperty, sDoc));
                        }
                        result = string.Format(@"{0}\{1}\{2}", pathDir, constOfficeProperty, sDoc);
                        break;
                    case 10://知識管理資料夾
                        if (!Directory.Exists(string.Format(@"{0}\{1}", pathDir, constKM)))//建立知識管理的主目錄
                        {
                            Directory.CreateDirectory(string.Format(@"{0}\{1}", pathDir, constKM));
                        }

                        if (!Directory.Exists(string.Format(@"{0}\{1}\{2}", pathDir, constKM, sDoc)))//建立知識管理目錄，sDoc為資料夾名稱
                        {
                            Directory.CreateDirectory(string.Format(@"{0}\{1}\{2}", pathDir, constKM, sDoc));
                        }
                        result = string.Format(@"{0}\{1}\{2}", pathDir, constKM, sDoc);
                        break;

                    case 20://EmailLog的附件
                        if (!Directory.Exists(string.Format(@"{0}\{1}", pathDir, constEmailLog)))//建立EmailLog附件的主目錄
                        {
                            Directory.CreateDirectory(string.Format(@"{0}\{1}", pathDir, constEmailLog));
                        }

                        if (!Directory.Exists(string.Format(@"{0}\{1}\{2}", pathDir, constEmailLog, sDoc)))//建立EmailLog附件目錄，sDoc為資料夾名稱
                        {
                            Directory.CreateDirectory(string.Format(@"{0}\{1}\{2}", pathDir, constEmailLog, sDoc));
                        }
                        result = string.Format(@"{0}\{1}\{2}", pathDir, constEmailLog, sDoc);
                        break;
                    case 30://Del File Log的附件
                        if (!Directory.Exists(string.Format(@"{0}\{1}", pathDir, constDelFileLog)))//建立Del File Log附件的主目錄
                        {
                            Directory.CreateDirectory(string.Format(@"{0}\{1}", pathDir, constDelFileLog));
                        }

                        if (!Directory.Exists(string.Format(@"{0}\{1}\{2}", pathDir, constDelFileLog, sDoc)))//建立Del File Log附件目錄，sDoc為資料夾名稱
                        {
                            Directory.CreateDirectory(string.Format(@"{0}\{1}\{2}", pathDir, constDelFileLog, sDoc));
                        }
                        result = string.Format(@"{0}\{1}\{2}", pathDir, constDelFileLog, sDoc);
                        break;
                    case 40://客戶(申請人)的附件
                        if (!Directory.Exists(string.Format(@"{0}\{1}", pathDir, constCustomerFolder)))//建立Customer附件的主目錄
                        {
                            Directory.CreateDirectory(string.Format(@"{0}\{1}", pathDir, constCustomerFolder));
                        }

                        if (!Directory.Exists(string.Format(@"{0}\{1}\{2}", pathDir, constCustomerFolder, sDoc)))//建立Customer附件目錄，sDoc為資料夾名稱
                        {
                            Directory.CreateDirectory(string.Format(@"{0}\{1}\{2}", pathDir, constCustomerFolder, sDoc));
                        }
                        result = string.Format(@"{0}\{1}\{2}", pathDir, constCustomerFolder, sDoc);
                        break;
                    case 50://事務所的附件
                        if (!Directory.Exists(string.Format(@"{0}\{1}", pathDir, constFirmFolder)))//建立Firm附件的主目錄
                        {
                            Directory.CreateDirectory(string.Format(@"{0}\{1}", pathDir, constFirmFolder));
                        }

                        if (!Directory.Exists(string.Format(@"{0}\{1}\{2}", pathDir, constFirmFolder, sDoc)))//建立Firm附件目錄，sDoc為資料夾名稱
                        {
                            Directory.CreateDirectory(string.Format(@"{0}\{1}\{2}", pathDir, constFirmFolder, sDoc));
                        }
                        result = string.Format(@"{0}\{1}\{2}", pathDir, constFirmFolder, sDoc);
                        break;
                    default:
                        break;
                }
            }
            catch (System.Exception EX)
            {
                //MessageBox.Show("您目前不是在指定的路徑，上傳檔案將會失敗\r\n 但不影響其它的操作 \r\n" + EX.Message);
            }

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="FolerdMode">1.段落依據 2.相關檔案管理 3.專利案件相關檔案管理 4.商標案件相關檔案管理 5.商標異議案件相關檔案管理 6.所內財產資料夾 10.知識管理 20.EmailLog的附件 30.UpFileLog(刪除附件的log)  40.客戶(申請人)附件    50.事務所附件</param>
        /// <param name="sDoc">sDoc該key值</param>
        /// <returns>回傳完整路徑</returns>
        public string CreatFolder(Public.CreateFolerdMode FolerdMode, string sDoc)
        {
           string ReValue= CreatFolder((int)FolerdMode, sDoc);
           return ReValue;
        }

        /// <summary>
        /// 指定路徑
        /// </summary>
        /// <param name="FullPath">完整路徑</param>
        /// <returns>true:資料夾已建立  false:建立資料夾發生異常</returns>
        public bool CreatFolder( string FullPath)
        {
            
            bool ReValue = false;
            try
            {
                if (!Directory.Exists(FullPath)) //完整路徑
                {
                    Directory.CreateDirectory(FullPath);
                    ReValue = true;
                }
                else
                {
                    ReValue = true;
                }

                return ReValue;
            }
            catch
            {
                return ReValue;
            }
        }
        #endregion

        #region 刪除資料夾
        /// <summary>
        /// 刪除資料夾
        /// </summary>
        /// <param name="FullPath">完整路徑</param>
        /// <param name="Recursive">True:刪除子目錄，False:不刪除子目錄</param>
        /// <returns></returns>
        public bool DeleteFolder(string FullPath,bool Recursive)
        {

            bool ReValue = false;
            try
            {
                if (Directory.Exists(FullPath)) //完整路徑
                {
                    Directory.Delete(FullPath, Recursive);
                    ReValue = true;
                }
                else
                {
                    ReValue = true;
                }
                return ReValue;
            }
            catch
            {
                return ReValue;
            }
        }
        #endregion

        #region convertMoneyString
        /// <summary>
        /// 取得國字數字
        /// </summary>
        /// <param name="sMon">字串的數字</param>
        /// <returns></returns>
        public string convertMoneyString(string sMon)
        {
            string[] ar = sMon.Split('.');
            sMon = ar[0];
            string[][] m = new string[][] { new string[] { "0", "零" }, new string[] { "1", "壹" }, new string[] { "2", "貳" }, new string[] { "3", "參" }, new string[] { "4", "肆" }, new string[] { "5", "伍" }, new string[] { "6", "陸" }, new string[] { "7", "柒" }, new string[] { "8", "捌" }, new string[] { "9", "玖" } };
            string[] unit = { "拾", "佰", "仟", "萬", "拾", "佰" };
            string Restr = "";

            for (int i = 0; i < sMon.Length; i++)
            {
                for (int n = 0; n < m.Length; n++)
                {
                    if (sMon.Substring(sMon.Length - 1 - i, 1) == m[n][0])
                    {
                        if (i < sMon.Length - 1)
                        {
                            Restr = unit[i] + " " + m[n][1] + " " + Restr;
                            break;
                        }
                        else
                        {
                            Restr = m[n][1] + " " + Restr;
                            break;
                        }
                    }

                }
            }

            return Restr + "元整";
        }
        #endregion

        #region =============上傳檔案(如有相同檔名將會覆寫)=============
        /// <summary>
        /// 上傳檔案(如有相同檔名將會覆寫)
        /// </summary>
        /// <param name="iType">判斷是專利或商標</param>
        /// <param name="UpdateFileSourcePath">檔案來源路徑</param>
        /// <param name="UpdateFileSavePath">檔案儲存路徑</param>
        /// <returns></returns>
        public bool UpdateFile(SystemType iType, string UpdateFileSourcePath, string UpdateFileSavePath)
        {
            try
            {
                FileInfo Upfile = new FileInfo(UpdateFileSourcePath);
                string sFileSavePath = "";
                switch (iType.ToString())
                {
                    case "Patent":
                        sFileSavePath = PatentFolderRoot;
                        break;
                    case "Trademark":
                        sFileSavePath = TrademarkFolderRoot;
                        break;
                }
                string FilePath = string.Format(@"{0}\{1}", sFileSavePath, UpdateFileSavePath);

                File.Copy(UpdateFileSourcePath, FilePath, true);
                return true;
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region 匯出DataGridView 的資料到Excel
        /// <summary>
        /// 匯出DataGridView 的資料到Excel
        /// </summary>
        /// <param name="gv"></param>
        //public void TrasferExcel(DataGridView gv)
        //{
            
        //        Microsoft.Office.Interop.Excel.Application Appexcel = new Microsoft.Office.Interop.Excel.Application();//引用Excel
        //    try
        //    {
        //        Appexcel.Application.Workbooks.Add(true);
        //        Appexcel.Visible = true;
        //        int Column = 1;
        //        for (int i = 0; i < gv.ColumnCount; i++) //匯出欄位名稱
        //        {
        //            if (gv.Columns[i].Visible != false)
        //            {
        //                Appexcel.Cells[1, Column] = gv.Columns[i].HeaderText;
        //                Column++;
        //            }
        //        }


        //        //Appexcel.Cells[1, Column] = "提案部門";

        //        for (int rowC = 0; rowC < gv.Rows.Count; rowC++)  //匯出值
        //        {
        //            int n = 1;
        //            for (int columnR = 0; columnR < gv.ColumnCount; columnR++)
        //            {
        //                if (gv.Columns[columnR].Visible != false)
        //                {
        //                    switch (gv.Columns[columnR].CellType.ToString())
        //                    {
        //                        case "System.Windows.Forms.DataGridViewComboBoxCell":
        //                            Appexcel.Cells[rowC + 2, n] = gv.Rows[rowC].Cells[columnR].FormattedValue.ToString();
        //                            break;

        //                        case "System.Windows.Forms.DataGridViewTextBoxCell":
        //                            if (gv.Rows[rowC].Cells[columnR].Value != null && gv.Rows[rowC].Cells[columnR].Value.GetType().ToString() == "System.DateTime")
        //                            {
        //                                Appexcel.Cells[rowC + 2, n] = gv.Rows[rowC].Cells[columnR].Value.ToString() != "" ? ((DateTime)gv.Rows[rowC].Cells[columnR].Value).ToShortDateString() : "";
        //                            }
        //                            else if (gv.Rows[rowC].Cells[columnR].Value != null && gv.Rows[rowC].Cells[columnR].Value.GetType().ToString() == "System.String")
        //                            {
        //                                Appexcel.Cells[rowC + 2, n] = gv.Rows[rowC].Cells[columnR].Value != null ? "'" + gv.Rows[rowC].Cells[columnR].Value.ToString() : "";
        //                            }
        //                            else if (gv.Rows[rowC].Cells[columnR].Value != null && gv.Rows[rowC].Cells[columnR].Value.GetType().ToString() == "System.Decimal")
        //                            {
        //                                Appexcel.Cells[rowC + 2, n] = gv.Rows[rowC].Cells[columnR].Value != null ? gv.Rows[rowC].Cells[columnR].FormattedValue.ToString() : "";
        //                            }
        //                            else
        //                            {
        //                                Appexcel.Cells[rowC + 2, n] = gv.Rows[rowC].Cells[columnR].Value != null ? gv.Rows[rowC].Cells[columnR].Value.ToString() : "";
        //                            }
        //                            break;
        //                        default:
        //                            Appexcel.Cells[rowC + 2, n] = gv.Rows[rowC].Cells[columnR].Value!=null?gv.Rows[rowC].Cells[columnR].Value.ToString():"";
        //                            break;
        //                    }


        //                    n++;
        //                }
        //            }
        //        }
        //    }
        //    catch
        //    {
        //        Appexcel.Quit();
        //        MessageBox.Show("匯出Excel失敗");
        //    }
        //}
        #endregion 

        #region 匯出DataGridView 的資料到CSV
        /// <summary>
        /// 匯出DataGridView 的資料到CSV
        /// </summary>
        /// <param name="gv"></param>
        public async Task WriteToCSV(DataGridView gv)
        {
            try
            {
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Filter = "CSV File|*.csv";
                saveFileDialog1.Title = "Save an File";
                saveFileDialog1.FileName = DateTime.Today.ToString("yyyyMMdd");

                if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK && saveFileDialog1.FileName != "")
                {
                    string strContent = TrasferExportCSV(gv);
                    System.IO.FileStream fs = (System.IO.FileStream)saveFileDialog1.OpenFile();
                    StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.UTF8);
                    await sw.WriteAsync(strContent);
                    
                    sw.Close();
                    fs.Close();
                }
            }
            catch (System.Exception EX)
            {
                string ss = EX.Message;
            }
        }
        #endregion 

        #region 匯出DataGridView 的資料到CVS
      /// <summary>
      /// 匯出DataGridView 的資料為文字格式
      /// </summary>
      /// <param name="gv"></param>
      /// <returns></returns>
        public string TrasferExportCSV(DataGridView gv)
        {

            StringBuilder sbHeader = new StringBuilder();

            List<string> bColumnName = new List<string>();
            // 寫出表頭
            int iColumnIndex = 0;
            foreach (DataGridViewColumn ColumnHead in gv.Columns)
            {
                if (ColumnHead.Visible)
                {
                    bColumnName.Add(ColumnHead.Name);

                    if (sbHeader.Length > 0)
                    {
                        sbHeader.Append(",");
                    }
                    sbHeader.Append(ColumnHead.HeaderText);
                }
                iColumnIndex++;
            }
            sbHeader.Append("\r\n");

            StringBuilder sbContent = new StringBuilder();
            StringBuilder sbRows = new StringBuilder();
            // 寫出資料                
            for (int iRow = 0; iRow < gv.Rows.Count; iRow++)
            {
                sbRows.Clear();
                foreach (var sName in bColumnName)
                {
                    if (sbRows.Length > 0)
                    {
                        sbRows.Append(",");
                    }

                    if (gv.Rows[iRow].Cells[sName].Value == null  || string.IsNullOrEmpty(gv.Rows[iRow].Cells[sName].Value.ToString().Trim())  )
                    {
                        sbRows.Append("\"\"");
                    }
                    else
                    {
                        sbRows.Append("\"" + gv.Rows[iRow].Cells[sName].FormattedValue.ToString().Replace("\n"," ").Replace("\r","")+ "\"");
                    }
                }
                sbContent.Append(sbRows.ToString() + "\r\n");

            }
            return sbHeader.ToString() +  sbContent.ToString();
        }
        #endregion 
    }
}
