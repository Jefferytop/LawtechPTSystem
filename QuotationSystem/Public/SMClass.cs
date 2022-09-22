using LawtechPTSystem.ServiceReference1;
using System;
using Newtonsoft.Json;

namespace LawtechPTSystem.Public
{
    /// <summary>
    /// 簡訊類別
    /// </summary>
    class SMClass
    {
        public SMClass()
        {


        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dtnow"></param>
        /// <returns></returns>
        public string GetVerificationCode(DateTime dtnow)
        {
            string account = Properties.Settings.Default.DatabaseName;

            string password = Properties.Settings.Default.DataSource;

            string CustomerCode = account;

            string MD5Code = "3edc$RFV";

            string authcode = string.Format("{0}{1}-{3}/{2}", account, password, CustomerCode, dtnow.ToString("yyyyMMddHHmmssfff"));

            string sCode = EncryptionMD5.Encryption(authcode, MD5Code);

            return sCode;
        }

        /// <summary>
        /// 發送簡訊
        /// </summary>
        /// <param name="ReceivePhone"></param>
        /// <param name="SmContent"></param>
        /// <returns></returns>
        public DB_Models.SMSRootobject SMSend(string ReceivePhone, string SmContent)
        {
            try
            {
                string account = Properties.Settings.Default.DatabaseName;
                ServiceReference1.Service1Client wcf = new Service1Client();
                DateTime dtNow = DateTime.Now;
                string vcode = GetVerificationCode(dtNow);

                wcf.Open();
                string jsonStr = wcf.SendSMS(account, account, dtNow, "Mitake", vcode, ReceivePhone, SmContent);
                wcf.Close();

                DB_Models.SMSRootobject jos = JsonConvert.DeserializeObject<DB_Models.SMSRootobject>(jsonStr);

                if (jos.Code == 200)
                {
                    CSMLog log = new CSMLog();
                    log.ReceivePhone = ReceivePhone;
                    log.SmClientTime = dtNow;
                    log.SmContent = SmContent;
                    log.SMCreator = Properties.Settings.Default.WorkerName;
                    log.SmResult = jsonStr;
                    log.FeePoint = jos.FeePoint;
                    log.Create();
                }

                return jos;
            }
            catch (SystemException EX)
            {
                DB_Models.SMSRootobject josError = new DB_Models.SMSRootobject();
                josError.Code = 500;
                josError.ErrMsg = EX.Message;
                josError.RetObj = "0";
                return josError;
            }
        }

        /// <summary>
        /// 檢查簡訊餘額數量
        /// </summary>
        /// <returns></returns>
        public DB_Models.SMSRootobject CheckSMSAmount()
        {
            string account = Properties.Settings.Default.DatabaseName;
            
            string vcode = "";
            try
            {

                DateTime dtNow = DateTime.Now;
                vcode = GetVerificationCode(dtNow);
                Service1Client wcf = new Service1Client();
                wcf.Open();
                string jsonStr = wcf.CheckSMSAmount(account, account, dtNow, vcode, "Mitake");
                wcf.Close();
                
                DB_Models.SMSRootobject jos = JsonConvert.DeserializeObject<DB_Models.SMSRootobject>(jsonStr);

                return jos;
            }
            catch (SystemException EX)
            {               
                DB_Models.SMSRootobject josError = new DB_Models.SMSRootobject();
                josError.Code = 500;
                josError.ErrMsg = EX.Message;
                josError.RetObj = "0";
                return josError;
            }
          
           
        }


    }
}
