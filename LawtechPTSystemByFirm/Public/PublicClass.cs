using System;
using System.Text;
using System.Management;
using System.Windows.Forms;
using System.Diagnostics;
using Microsoft.Win32;

namespace LawtechPTSystemByFirm.Public
{   
    /// <summary>
    /// 公用的 (取得OS 的版本、目前的OS的語系、取得OS 是32bit或64bit、取得CPU ID、取得網卡序號)
    /// </summary>
    class PublicClass
    {
        //TODO 公用但頻率不常使用的Function

        #region 取得OS 的版本
        /// <summary>
        /// 取得OS 的版本
        /// </summary>
        /// <returns></returns>
        public string GetOSVersion()
        {
            string strValue = "";

            OperatingSystem myOS = Environment.OSVersion;

            if (myOS.Version.Major == 5)
            {
                switch (myOS.Version.Minor)
                {
                    case 0:
                        strValue = "Windows 2000 " + myOS.ServicePack;
                        break;
                    case 1:
                        strValue = "Windows XP " + myOS.ServicePack;
                        break;
                    case 2:
                        strValue = "Windows Server 2003 " + " " + myOS.ServicePack;
                        break;
                    default:
                        strValue = myOS.ToString() + " " + myOS.ServicePack;
                        break;
                }
            }
            else if (myOS.Version.Major == 6)
            {
                switch (myOS.Version.Minor)
                {
                    case 0:
                        strValue = "WindowsVista " + myOS.ServicePack;
                        break;
                    case 1:
                        strValue = "Windows7 " + myOS.ServicePack;
                        break;
                    default:
                        strValue = myOS.ToString() + " " + myOS.ServicePack;
                        break;
                }
            }
            else
            {
                strValue = myOS.VersionString + " " + myOS.ServicePack;
            }

            return strValue;
        }
        #endregion       

        #region 目前的OS的語系
        /// <summary>
        /// 目前的OS的語系
        /// </summary>
        /// <returns></returns>
        public string GetOSVersionCurrentCulture()
        {
            string strValue = "";
           string LanguageType= System.Threading.Thread.CurrentThread.CurrentCulture.Name;
           switch (LanguageType)
            {
                case "zh-CN":
                    strValue = "中文（中国）";
                    break;
                case "zh-Hans":
                    strValue = "中文（简体）";
                    break;
                case "zh-SG":
                    strValue = "中文（新加坡）";
                    break;
                case "zh-Hant":
                    strValue = "中文（中国）";
                    break;
                case "Zh-TW":
                    strValue = "中文（台灣）";
                    break;
                case "en-US":
                    strValue = "America";
                    break;
               case  "en-GB" :
                    strValue = "United Kingdom";
                    break;
                case "ja-JP":
                    strValue = "日本";
                    break;
              default:
                    strValue = LanguageType;
                    break;
            }

           return strValue;

        }
        #endregion

        #region 取得OS 是32bit或64bit
        /// <summary>
        /// 取得OS 是32bit或64bit
        /// </summary>
        /// <returns></returns>
        public string GetAddressWidth()
        {
            ConnectionOptions oConn = new ConnectionOptions();
            System.Management.ManagementScope oMs = new System.Management.ManagementScope("\\\\localhost", oConn);
            System.Management.ObjectQuery oQuery = new System.Management.ObjectQuery("select AddressWidth from Win32_Processor");
            ManagementObjectSearcher oSearcher = new ManagementObjectSearcher(oMs, oQuery);
            ManagementObjectCollection oReturnCollection = oSearcher.Get();
            string addressWidth = null;
            foreach (ManagementObject oReturn in oReturnCollection)
            {
                addressWidth = oReturn["AddressWidth"].ToString();
            }
            return addressWidth;
        }
        #endregion

        #region 取得應用程式的完整路徑
        /// <summary>
        /// 取得應用程式的完整路徑
        /// </summary>
        /// <returns></returns>
        public string GetApplicationExecutablePath()
        {
            return Application.ExecutablePath;
        }
        #endregion

        #region 開機後自動執行
        /// <summary>
        /// 開機後自動執行
        /// </summary>
        /// <param name="agreen">true:同意開機後執行，false:反之</param>
        /// <returns></returns>
        public bool AutoRun(bool agreen)
        {
            try
            {
                string strName = GetApplicationExecutablePath().Trim();
                if (!System.IO.File.Exists(strName))
                    return false;
                string strnewName = strName.Substring(strName.LastIndexOf("\\") + 1);
                RegistryKey RKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
                if (RKey == null)
                {
                    RKey = Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run");
                    if (agreen)
                    {
                        RKey.SetValue(strnewName, strName);
                    }
                    else
                    {
                        RKey.DeleteValue(strnewName, false);
                    }
                }
               
                if (MessageBox.Show("設定完畢") == DialogResult.OK)
                {
                    RefreshSystem();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void RefreshSystem()
        {
            Process[] mprocess;
            mprocess = Process.GetProcessesByName("explorer");
            foreach (Process mp in mprocess)
            {
                mp.Kill();
            }
        }
        #endregion

        #region 取得CPU ID
        /// <summary>
        /// 取得CPU ID
        /// </summary>
        /// <returns></returns>
        public string GetCPU()
        {
            // 透過 ManagementObjectSearcher 類別用類似 SQL 的語法查詢 

            ManagementObjectSearcher wmiSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_Processor");

            

            StringBuilder sb = new StringBuilder();

            // 使用 ManagementObjectSearcher 的 Get 方法取得所有集合 
            foreach (ManagementObject obj in wmiSearcher.Get())
            {

                // 取得CPU 序號
                sb.Append( obj["ProcessorId"].ToString()+",");
                obj.Dispose();
            }
            string strCPU = "";
            if (sb.ToString().Substring(sb.ToString().Length - 1) == ",")
            {
                strCPU = sb.ToString().Remove(sb.ToString().Length - 1);
            }
            else
            {
                strCPU = sb.ToString();
            }

            return strCPU;
        }

        #endregion

        #region 取得網卡序號
        /// <summary>
        /// 取得網卡序號
        /// </summary>
        /// <returns></returns>
        public string GetMACaddress()
        {
            ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection moc2 = mc.GetInstances();
            StringBuilder sb = new StringBuilder();
            foreach (ManagementObject mo in moc2)
            {
                if ((bool)mo["IPEnabled"] == true)
                {                    
                    sb.Append(mo["MacAddress"].ToString()+",");
                    mo.Dispose();
                }
            }
            string strMacAddress = "";
            if (sb.ToString().Substring(sb.ToString().Length - 1) == ",")
            {
                strMacAddress = sb.ToString().Remove(sb.ToString().Length - 1);
            }
            else
            {
                strMacAddress = sb.ToString();
            }

            return strMacAddress;
        }
        #endregion
    }

  
}
