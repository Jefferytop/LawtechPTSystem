
using System;
using System.Collections.Generic;

namespace LawtechPTSystem.Public
{
    /// <summary>
    /// 公用方法 
    /// </summary>
    public static class PublicCommonFunction
    {
        /// <summary>
        /// 取得連線字串 Properties.Settings.Default.DataBaseConnectionString
        /// <para>判斷字串內含有「Data Source=」則不解密; 反之則用H3Operator進行解密</para>
        /// </summary>
        public static string GetConnectionString()
        {
            if (Properties.Settings.Default.DataBaseConnectionString != "" && Properties.Settings.Default.DataBaseConnectionString.Contains("Data Source="))
            {
                if (Properties.Settings.Default.DataBaseConnectionString.Contains("=LawtechPTSystem"))
                {
                    return Properties.Settings.Default.DataBaseConnectionString;
                }
                else
                {
                    return "";
                }

            }
            else
            {
                return H3Operator.DBHelper.EncryptorClass.Decrypt(Properties.Settings.Default.DataBaseConnectionString, "@wsx8UHB");
            }
        }

        #region 跳過引號中的逗號,進行逗號分隔(欄位內容中的逗號不參與分隔) public static string[] CSVstrToArry(string splitStr)
        /// <summary>
        /// 跳過引號中的逗號,進行逗號分隔(欄位內容中的逗號不參與分隔)
        /// </summary>
        /// <param name="strLine"></param>
        /// <returns></returns>
        public static string[] CSVstrToArry(string splitStr)
        {
            var newstr = string.Empty;
            List<string> sList = new List<string>();

            bool isSplice = false;
            string[] array = splitStr.Split(new char[] { ',' });
            foreach (var str in array)
            {
                if (!string.IsNullOrEmpty(str) && str.IndexOf('"') > -1)
                {
                    var firstchar = str.Substring(0, 1);
                    var lastchar = string.Empty;
                    if (str.Length > 0)
                    {
                        lastchar = str.Substring(str.Length - 1, 1);
                    }
                    if (firstchar.Equals("\"") && !lastchar.Equals("\""))
                    {
                        isSplice = true;
                    }
                    if (lastchar.Equals("\""))
                    {
                        if (!isSplice)
                            newstr += str;
                        else
                            newstr = newstr + "," + str;

                        isSplice = false;
                    }
                }
                else
                {
                    if (string.IsNullOrEmpty(newstr))
                        newstr += str;
                }

                if (isSplice)
                {
                    //新增因拆分時丟失的逗號
                    if (string.IsNullOrEmpty(newstr))
                        newstr += str;
                    else
                        newstr = newstr + "," + str;
                }
                else
                {
                    sList.Add(newstr.Replace("\"", "").Trim());//去除字元中的雙引號和首尾空格
                    newstr = string.Empty;
                }
            }
            return sList.ToArray();
        }
        #endregion

        public static void CheckTrueFileName(string FilePath)
        {
            string path = @"D:\Sheet1.doc";
            System.IO.FileStream fs = new System.IO.FileStream(path, System.IO.FileMode.Open, System.IO.FileAccess.Read);
            System.IO.BinaryReader r = new System.IO.BinaryReader(fs);
            string bx = " "; byte buffer;
            try
            {
                buffer = r.ReadByte();
                bx = buffer.ToString();
                buffer = r.ReadByte();
                bx += buffer.ToString();
            }
            catch (Exception ex)
            {
             
            }
            r.Close();
            fs.Close();
            //真實的檔案型別
            //Console.WriteLine(bx);
            //檔名，包括格式Console.WriteLine(System.IO.Path.GetFileName(path));//檔名， 不包括格式Console.WriteLine(System.IO.Path.GetFileNameWithoutExtension(path));//檔案格式Console.WriteLine(System.IO.Path.GetExtension(path));Console.ReadLine();}
        }

    }
}
