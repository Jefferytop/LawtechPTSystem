using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace LawtechPTSystem
{
    static class Program
    {
        
        /// <summary>
        /// 應用程式的主要進入點。
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Microsoft.Win32.RegistryKey key;
            try
            {
                //key =   Microsoft.Win32.Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\.NETFramework\\Security\\TrustManager\\PromptingLevel");
                //object obj = key.GetValue("MyComputer");
                //if (obj == null|| obj.ToString() == "" || obj.ToString() == "Enabled") {
                //    key.SetValue("MyComputer", "Disabled");
                //}
                //key = Microsoft.Win32.Registry.LocalMachine.GetSubKeyNames("SOFTWARE\\Microsoft\\.NETFramework\\Security\\TrustManager\\PromptingLevel");
                //object obj = key.GetValue("MyComputer");
                //if (obj == null || obj.ToString() == "Enabled")
                //{
                //    key.SetValue("MyComputer", "Disabled");
                //    key.SetValue("LocalIntranet", "Disabled");
                //    key.SetValue("Internet", "Disabled");
                //    key.SetValue("TrustedSites", "Disabled");
                //    key.SetValue("UntrustedSites", "Disabled");
                //    key.Close();
                //}
            }
            catch (System.Security.SecurityException sex)
            {
                string ss = sex.Message;
                MessageBox.Show(ss);
            }
            catch (System.UnauthorizedAccessException ex)
            {
                //TODO: 讀取機碼被拒
                string ss = ex.Message;
                MessageBox.Show(ss);
            }



            string MName = Process.GetCurrentProcess().MainModule.ModuleName;
            string PName = Path.GetFileNameWithoutExtension(MName);
            Process[] myProcess = Process.GetProcessesByName(PName);

            if (myProcess.Length > 1)//本程序一次只能執行一個實例
            {
                myProcess[0].Start();

            }
            else
            {
                try
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    //string SPath = Path.Combine(Environment.CurrentDirectory, @"Flow.msstyles");                    
                    Application.Run(new Login());
                }
                catch (System.Exception EX)
                {
                   // MessageBox.Show(EX.Message);
                    H3Operator.DBHelper.CommonFunction.ThreadWriteLog(EX.Message);
                }
            }

        }
    }
}