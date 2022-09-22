using System;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;


namespace LawtechPTSystemByFirm.Public
{
    public class Utility
    {
       
        #region 檢查是否為數值
        /// <summary>
        /// 檢查是否為數值
        /// </summary>
        /// <param name="Value">指定檢查的字串</param>
        /// <param name="type">型態為int 或 decimal</param>
        /// <returns></returns>
        static public bool isNumeric(string Value, string type)
        {
            bool IsSuccess = false;
            switch (type)
            {
                case "int":
                    try
                    {
                        int iN = 0;
                        IsSuccess = int.TryParse(Value,out iN);
                    }
                    catch 
                    {
                        return false;
                    }
                    return true;
                case "decimal":
                    try
                    {
                        decimal dd = 0;
                      IsSuccess=  decimal.TryParse(Value, out dd);
                    }
                    catch
                    {
                        return false;
                    }
                    break;
            }
            return IsSuccess;
        }
        #endregion       

        static StreamWriter sw;

        #region 建立Log訊息 public static int WriteLog(string ExceptionMessage)
        /// <summary>
        /// 建立Log訊息
        /// </summary>
        /// <param name="AppPath">應用程式路徑。</param>
        /// <param name="ExceptionMessage">將要記錄错誤訊息文字。</param>
        /// <param name="Mode">記錄訊息的模式</param>
        /// <returns></returns>
        public static int WriteLog(string ExceptionMessage)
        {
            int result = -1;
            string logFolderPath = System.Windows.Forms.Application.StartupPath;

            logFolderPath += @"\Log\";
            if (!Directory.Exists(logFolderPath))
                Directory.CreateDirectory(logFolderPath);

            try
            {
                sw = new StreamWriter(logFolderPath + DateTime.Now.ToString(@"yyyyMMdd") + ".txt", true);
                sw.WriteLine(string.Format("在 {0} 發生錯誤. 訊息為:{1}", DateTime.Now.ToString("HH:mm:ss"), ExceptionMessage));
            }
            finally
            {
                result = 1;
                if (sw != null)
                    sw.Close();
            }
            return result;
        } 
        #endregion

        #region 取得排序最大值
        /// <summary>
        /// 取得排序最大值
        /// </summary>
        /// <param name="TableName">資料表名稱</param>
        /// <param name="ColumnName">欄位名稱，預設為Sort</param>
        /// <returns></returns>
        public static int GetMaxSort(string TableName, string ColumnName)
        {
            Public.DLL dll = new DLL();

            string strSQL = string.Format("Select max({0})+1 from {1}", ColumnName, TableName);
            object obj = dll.SQLexecuteScalar(strSQL);
            if (obj != null && obj.ToString() != "")
            {
                return (int)obj;
            }
            else
            {
                return 1;
            }
        }
        

        public static int GetMaxSort(string TableName)
        {
          int ReVale= GetMaxSort(TableName,"Sort");
            return ReVale;
        }
        #endregion

        #region 數字轉換成國字
        /// <summary>
        /// 數字轉換成國字
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        static public String NumberToString(String input)
        {
            String[] arr1 = new String[10] { "", "一", "二", "三", "四", "五", "六", "七", "八", "九" };
            String[] arr2 = new String[8] { "", "十", "百", "千", "萬", "十萬", "百萬", "千萬" };
            String result = null;
            if (input.Length > 3)
            {
                return "輸入錯誤";
            }
            for (Int32 i = 0; i < input.Length; i++)
            {
                if (input.Substring(i, 1) != "0")
                {
                    if (i > 1)
                    {
                        if (input.Substring(i - 1, 1) == "0")
                        {
                            result = result + "零";
                        }
                    }
                    result = result + arr1[Convert.ToInt32(input.Substring(i, 1))];
                    result = result + arr2[(input.Length - (i + 1)) % 3];//取餘數
                }
                else if (input.Length == 1 && input.Substring(i, 1) == "0")
                {
                    result = "零";
                }
            }
            if (result.Length > 1 && result.Substring(0, 1) == "零")
            {
                result = result.Replace("零", null);
            }
            return result;
        }

        /// <summary>
        /// 數字轉換成國字
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        static string GetChineseNumber(int number)
        {
            string[] chineseNumber = { "零", "一", "二", "三", "四", "五", "六", "七", "八", "九" };
            string[] unit = { "", "十", "百", "千", "萬", "十萬", "百萬", "千萬", "億" };
            StringBuilder ret = new StringBuilder();
            string inputNumber = number.ToString();
            int idx = inputNumber.Length;
            bool needAppendZero = false;
            foreach (char c in inputNumber)
            {
                idx--;
                if (c > '0')
                {
                    if (needAppendZero)
                    {
                        ret.Append(chineseNumber[0]);
                        needAppendZero = false;
                    }
                    ret.Append(chineseNumber[(int)(c - '0')] + unit[idx]);
                }
                else
                    needAppendZero = true;
            }
            return ret.Length == 0 ? chineseNumber[0] : ret.ToString();
        }

        #endregion

        #region 使用預設的電子信箱啟動
        /// <summary>
        /// 使用預設的電子信箱啟動
        /// </summary>
        /// <param name="MailTo"></param>
        /// <param name="subject"></param>
        /// <param name="body"></param>
        public static void ProcessMailTo(string MailTo,string subject,string body)
        {
            Process.Start(new ProcessStartInfo(string.Format("mailto:{0}?subject={1}&body={2}", MailTo, subject, body)));
        }
        public static void ProcessMailTo(string MailTo)
        {
            Process.Start(new ProcessStartInfo(string.Format("mailto:{0}", MailTo)));
        }
        #endregion

        public static void ProcessStart(string objectString)
        {
            try
            {
                Process.Start(new ProcessStartInfo(objectString));
            }
            catch (SystemException EX)
            {
                MessageBox.Show(EX.Message+"/r/n 或格式不正確");
            }
        }

       

        #region GetRecordAuth
        /// <summary>
        /// 查詢該資料是否有人使用
        /// </summary>
        /// <param name="TableName">資料表名稱</param>
        /// <param name="sWhere">查詢條件</param>
        /// <returns>-1:無人使用 </returns>
        public static int GetRecordAuth(string TableName,string sWhere)
        {
            string strSQL = string.Format("select LockedWorker from {0} where {1}", TableName, sWhere);

            DLL dll = new DLL();
            object obj=dll.SQLexecuteScalar(strSQL);
            if (obj!=null && obj != DBNull.Value)
            {
                return (int)obj;
            }
            else
            {
                return -1;
            }
        }

        /// <summary>
        /// 鎖定該筆資料
        /// </summary>
        /// <param name="TableName">資料表名稱</param>
        /// <param name="worker"></param>
        /// <param name="sWhere">查詢條件</param>
        /// <returns></returns>
        public static void LockRecordAuth(string TableName,int worker, string sWhere)
        {
            string strSQL = string.Format("update {0} set LockedWorker=null  where LockedWorker={1} ; update {0} set LockedWorker={1}  where {2}", TableName, worker, sWhere);

            DLL dll = new DLL();
            dll.SQLexecuteNonQuery(strSQL);
        }

        /// <summary>
        /// 解除鎖定資料
        /// </summary>
        /// <param name="TableName">資料表名稱</param>       
        /// <param name="sWhere">查詢條件</param>
        /// <returns></returns>
        public static void NuLockRecordAuth(string TableName,  string sWhere)
        {
            string strSQL = string.Format("update {0} set LockedWorker=null  where {1}", TableName, sWhere);

            DLL dll = new DLL();
            dll.SQLexecuteNonQuery(strSQL);
        }
        #endregion

        #region ControlTab Enter移到下一個控制項
        /// <summary>
        /// ControlTab Enter移到下一個控制項
        /// </summary>
        /// <param name="e"></param>
        public static void ControlTab(KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    if (e.Shift == false)
                    {
                        SendKeys.Send("{TAB}");
                    }                   
                    break;
                case Keys.PageDown:
                    SendKeys.Send("{TAB}");
                    break;
                case Keys.PageUp:
                    SendKeys.Send("+{TAB}");
                    break;
            }

        }
        #endregion

        #region 將SplitContainer做水平/垂直 的切換動作 public void SsplitContainerHorizontal(ref SplitContainer sp)
        /// <summary>
        /// 將SplitContainer做水平/垂直 的切換動作
        /// </summary>
        /// <param name="sp"></param>
        public static void SsplitContainerHorizontal(ref SplitContainer sp)
        {
            if (sp.Orientation == Orientation.Horizontal)
            {
                sp.Orientation = Orientation.Vertical;
            }
            else
            {
                sp.Orientation = Orientation.Horizontal;
            }
        } 
        #endregion

        #region 依據設定值，帶入載入資料的時間範圍
        /// <summary>
        /// 依據設定值，帶入載入資料的時間範圍
        /// </summary>
        /// <param name="userControlFilterDate1"></param>
        public static void SetLoadDataRange(US.UserControlFilterDate userControlFilterDate1)
        {
            switch (Properties.Settings.Default.LoadDataRange)
            {
                case 3:
                    userControlFilterDate1.MaskedStartDate.Text = DateTime.Now.AddMonths(-3).ToString("yyyy/MM/dd");
                    break;
                case 6:
                    userControlFilterDate1.MaskedStartDate.Text = DateTime.Now.AddMonths(-6).ToString("yyyy/MM/dd");
                    break;
                case 12:
                    userControlFilterDate1.MaskedStartDate.Text = DateTime.Now.AddMonths(-12).ToString("yyyy/MM/dd");
                    break;
                default:

                    break;

            }
        } 
        #endregion
    }
}
