using System;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Security.Permissions;


/*
 * 參考位址 http://yilinliu.blogspot.tw/2006/08/cwindows.html 
 * 在程式中模擬特定的windows帳號存取網路芳鄰 
 */


[assembly: SecurityPermissionAttribute(SecurityAction.RequestMinimum, UnmanagedCode = true)]
[assembly: PermissionSetAttribute(SecurityAction.RequestMinimum, Name = "FullTrust")] 
namespace LawtechPTSystem.Public
{
    class SecurityPermissions
    {
        //登入         
        [DllImport("advapi32.dll", SetLastError = true)]
        public static extern bool LogonUser(
            string lpszUsername,
            string lpszDomain,
            string lpszPassword,
            int dwLogonType,
            int dwLogonProvider,
            ref IntPtr phToken);

        //登出
        [DllImport("kernel32.dll")]
        public extern static bool CloseHandle(IntPtr hToken);

       
        public SecurityPermissions(string IP,string Account,string Password,string PathFolder)
        {
            string UserName = Account;
            string MachineName = IP;
            string Pw = Password;
            string IPath = @"\\" + IP + @"\" + PathFolder;
            const int LOGON32_PROVIDER_DEFAULT = 0;
            const int LOGON32_LOGON_NEW_CREDENTIALS = 9;
            IntPtr tokenHandle = new IntPtr(0);
            tokenHandle = IntPtr.Zero;
            //將登入的Token放在tokenHandle
            bool returnValue = LogonUser(UserName, MachineName, Pw,
                LOGON32_LOGON_NEW_CREDENTIALS,
                LOGON32_PROVIDER_DEFAULT,
                ref tokenHandle);
            //讓程式模擬登入的使用者
            WindowsIdentity w = new WindowsIdentity(tokenHandle);
            w.Impersonate();
            
            if (false == returnValue)
            {
                //登入失敗的處理
                bLogin = false; ;
            }
            else
            {
                //登入成功
                bLogin = true;
            }

            //取得該目錄下的所有檔案名稱
            //DirectoryInfo dir = new DirectoryInfo(IPath);
            //FileInfo[] inf = dir.GetFiles();
            //for (int i = 0; i < inf.Length; i++)
            //{
            //    Console.WriteLine(inf[i].Name); 
            //} 
        }

        private bool bLogin = false;
        /// <summary>
        /// 是否登入成功
        /// </summary>
        public bool IsLoginSuccess
        {
            get { return bLogin; }
            set { bLogin = value; }
        }
    }
}
