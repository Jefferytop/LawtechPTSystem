using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace LawtechPTSystemByFirm
{
    static class Program
    {
        
        /// <summary>
        /// 應用程式的主要進入點。
        /// </summary>
        [STAThread]
        static void Main()
        {
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
                    //USkin.USkinSDK.USkinInit("", "", SPath);
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