using System;
using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.IO;

namespace LawtechPTSystem.Public
{
    /// <summary>
    /// 檢查Email格式、 Send Mail
    /// </summary>
    class EmailClass
    {

        public struct RegularExp
        {
            public const string Email = @"^[\w-]+(\.[\w-]+)*@[\w-]+(\.[\w-]+)+$";
        }

        #region 檢查Email格式
        /// <summary>
        /// 檢查Email格式
        /// </summary>
        /// <param name="input"></param>
        /// <returns>true:符合  false:不符合</returns>
        public static bool IsEmail(string input)
        {
            return Regex.IsMatch(input, RegularExp.Email);
        }
        #endregion

        #region Send Mail
        /// <summary>
        /// Send Mail
        /// </summary>
        /// <param name="strFrom">Sender</param>
        /// <param name="strTo">Reciver (;)</param>
        /// <param name="strSubject">Subject</param>
        /// <param name="strBody">Body</param>
        /// <param name="bIsBodyHtml">IsBodyHtml</param>
        /// <param name="strAttachments">Attachments (;)</param>
        /// <returns></returns>
        public static bool SendEmail(string strFrom, string strTo, string strSubject, string strBody,bool bIsBodyHtml, string strAttachments)
        {
            try
            {
                // 開始寄信
                // 建立 MailMessage 實體
                MailMessage mms = new MailMessage();

                // 指定寄信人 
                mms.From = new MailAddress(strFrom, Properties.Settings.Default.EmailNickname);
               

                string[] mailTo = strTo.Split(';');
                // 新增收件人
                foreach (string ss in mailTo)
                {
                    mms.To.Add(ss);
                }
               
                // 設定郵件屬性，在此設定為「高」
                mms.Priority = MailPriority.Normal;

                // 設定主旨
                mms.Subject = strSubject;

                // 設定信件內容
                mms.Body = strBody;
                // 設定信件內容是否為 Html 格式
                mms.IsBodyHtml = bIsBodyHtml;

                // 設定是否有附加檔案，有則新增
                string[] Attachments = strAttachments.Split(';');

                foreach (string strAtt in Attachments)
                {
                    if (strAtt != string.Empty)
                    {
                        if (Directory.Exists(strAtt))
                        {
                            mms.Attachments.Add(new Attachment(strAtt));
                        }
                    }
                }

                // 建立 SmtpClient 實體
                SmtpClient smtp_Client = new SmtpClient();
                
                int iTime = Properties.Settings.Default.EmailTimeOut;
                smtp_Client.Timeout = iTime;
                // 建立 Host, Port, SSL, Credentials...等
                smtp_Client.Host = Properties.Settings.Default.SMTPServer;
                smtp_Client.Port = Properties.Settings.Default.EmailPort;
                smtp_Client.EnableSsl = Properties.Settings.Default.EmailSSL;
               
                smtp_Client.UseDefaultCredentials = false;
                smtp_Client.Credentials = new NetworkCredential(Properties.Settings.Default.EmailAddress, Properties.Settings.Default.EmailPassword);

                // 設定 DeliveryMethod 的傳送信件方法 (共有3種)
                smtp_Client.DeliveryMethod = SmtpDeliveryMethod.Network;
                //smtp_Client.DeliveryMethod = SmtpDeliveryMethod.PickupDirectoryFromIis;  
                //smtp_Client.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;

                //TransportStrategy transportStrategy = TransportStrategy.SMTP_SSL;
                //Mailer mailer = new Mailer(serverConfig, transportStrategy);
              
                // 送出郵件 
                smtp_Client.Send(mms);

                return true;

            }
            
            catch (Exception ex)
            {
                string errorstr = ex.Message;
               throw ;
             
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="strFrom">Sender</param>
        /// <param name="strTo">Reciver (;)</param>
        /// <param name="strSubject">Subject</param>
        /// <param name="strBody">Body</param>
        /// <param name="bIsBodyHtml"></param>
        /// <param name="iMailPriority">設定郵件屬性 1.高 2.低 3.一般</param>
        /// <param name="strAttachments">Attachments (;)</param>
        /// <returns></returns>
        public static bool SendEmail(string strFrom, string strTo, string strSubject, string strBody, bool bIsBodyHtml, int iMailPriority, string strAttachments)
        {
            try
            {
                // 開始寄信
                // 建立 MailMessage 實體
                MailMessage mms = new MailMessage();

                // 指定寄信人 
                mms.From = new MailAddress(strFrom, Properties.Settings.Default.EmailNickname);

                string[] mailTo = strTo.Split(';');
                // 新增收件人
                foreach (string ss in mailTo)
                {
                    if (IsEmail(ss))
                    {
                        mms.To.Add(ss);
                    }
                }              

                // 設定郵件屬性，在此設定為「高」
                if (iMailPriority == 1)
                {
                    mms.Priority = MailPriority.High;
                }
                else if (iMailPriority == 2)
                {
                    mms.Priority = MailPriority.Low;
                }
                else{
                    mms.Priority = MailPriority.Normal;
                }

                // 設定主旨
                mms.Subject = strSubject;

                // 設定信件內容
                mms.Body = strBody;
                // 設定信件內容是否為 Html 格式
                mms.IsBodyHtml = bIsBodyHtml;

                // 設定是否有附加檔案，有則新增
                string[] Attachments = strAttachments.Split(';');

                foreach (string strAtt in Attachments)
                {
                    if (strAtt != string.Empty)
                    {
                        mms.Attachments.Add(new Attachment(strAtt));
                    }
                }

                // 建立 SmtpClient 實體
                SmtpClient smtp_Client = new SmtpClient();
                int iTime = Properties.Settings.Default.EmailTimeOut;
                smtp_Client.Timeout = iTime;
                // 建立 Host, Port, SSL, Credentials...等
                smtp_Client.Host = Properties.Settings.Default.SMTPServer;
                smtp_Client.Port = Properties.Settings.Default.EmailPort;
                smtp_Client.EnableSsl = Properties.Settings.Default.EmailSSL;
                smtp_Client.UseDefaultCredentials = false;
                smtp_Client.Credentials = new NetworkCredential(Properties.Settings.Default.EmailAddress, Properties.Settings.Default.EmailPassword);
               
                // 設定 DeliveryMethod 的傳送信件方法 (共有3種)
                smtp_Client.DeliveryMethod = SmtpDeliveryMethod.Network;
                //smtp_Client.DeliveryMethod = SmtpDeliveryMethod.PickupDirectoryFromIis;  
                //smtp_Client.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;

                // 送出郵件 
                smtp_Client.Send(mms);

                return true;

            }
            catch //(Exception ex)
            {
                throw ;
              
            }
        }

       /// <summary>
       /// 
       /// </summary>
        /// <param name="strFrom">Sender</param>
        /// <param name="strTo">Reciver (;)</param>
       /// <param name="cc">副本</param>
        /// <param name="strSubject">Subject</param>
        /// <param name="strBody">Body</param>
       /// <param name="bIsBodyHtml"></param>
        /// <param name="iMailPriority">設定郵件屬性 1.高 2.低 3.一般</param>
        /// <param name="strAttachments">Attachments (;)</param>
       /// <returns></returns>
        public static bool SendEmail(string strFrom, string strTo,string cc, string strSubject, string strBody, bool bIsBodyHtml, int iMailPriority, string strAttachments)
        {
            try
            {
                // 開始寄信
                // 建立 MailMessage 實體
                MailMessage mms = new MailMessage();

                // 指定寄信人 
                mms.From = new MailAddress(strFrom, Properties.Settings.Default.EmailNickname);

                string[] mailTo = strTo.Split(';');
                // 新增收件人
                foreach (string ss in mailTo)
                {
                    if (IsEmail(ss))
                    {
                        mms.To.Add(ss);
                    }
                }

                string[] mailCC = cc.Split(';');
                // 新增副本
                foreach (string Mailcc in mailCC)
                {
                    if (IsEmail(Mailcc))
                        mms.CC.Add(Mailcc);
                }


                // 設定郵件屬性，在此設定為「高」
                if (iMailPriority == 1)
                {
                    mms.Priority = MailPriority.High;
                }
                else if (iMailPriority == 2)
                {
                    mms.Priority = MailPriority.Low;
                }
                else
                {
                    mms.Priority = MailPriority.Normal;
                }

                // 設定主旨
                mms.Subject = strSubject;

                // 設定信件內容
                mms.Body = strBody;
                // 設定信件內容是否為 Html 格式
                mms.IsBodyHtml = bIsBodyHtml;

                // 設定是否有附加檔案，有則新增
                string[] Attachments = strAttachments.Split(';');

                foreach (string strAtt in Attachments)
                {

                    if (strAtt != string.Empty)
                    {
                        mms.Attachments.Add(new Attachment(strAtt));
                    }

                }

                // 建立 SmtpClient 實體
                SmtpClient smtp_Client = new SmtpClient();
                int iTime = Properties.Settings.Default.EmailTimeOut;
                smtp_Client.Timeout = iTime;

                // 建立 Host, Port, SSL, Credentials...等
                smtp_Client.Host = Properties.Settings.Default.SMTPServer;
                smtp_Client.Port = Properties.Settings.Default.EmailPort;
                smtp_Client.EnableSsl = Properties.Settings.Default.EmailSSL;
                smtp_Client.UseDefaultCredentials = false;
                smtp_Client.Credentials = new NetworkCredential(Properties.Settings.Default.EmailAddress, Properties.Settings.Default.EmailPassword);

               
                // 設定 DeliveryMethod 的傳送信件方法 (共有3種)
                smtp_Client.DeliveryMethod = SmtpDeliveryMethod.Network;
                //smtp_Client.DeliveryMethod = SmtpDeliveryMethod.PickupDirectoryFromIis;  
                //smtp_Client.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;

                // 送出郵件 
                smtp_Client.Send(mms);

                return true;

            }
            catch //(Exception ex)
            {
                throw ;                
            }
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="strFrom">Sender</param>
        /// <param name="strTo">Reciver (;)</param>
        /// <param name="cc">副本</param>
        /// <param name="Bcc">密件副本</param>
        /// <param name="strSubject">Subject</param>
        /// <param name="strBody">Body</param>
        /// <param name="bIsBodyHtml"></param>
        /// <param name="iMailPriority">設定郵件屬性 1.高 2.低 3.一般</param>
        /// <param name="strAttachments">Attachments (;)</param>
        /// <returns></returns>
        public static bool SendEmail(string strFrom, string strTo, string cc, string Bcc,string strSubject, string strBody, bool bIsBodyHtml, int iMailPriority, string strAttachments)
        {
            try
            {
                // 開始寄信
                // 建立 MailMessage 實體
                MailMessage mms = new MailMessage();

                // 指定寄信人 
                mms.From = new MailAddress(strFrom, Properties.Settings.Default.EmailNickname);

                string[] mailTo = strTo.Split(';');
                // 新增收件人
                foreach (string ss in mailTo)
                {
                    if (IsEmail(ss))
                    {
                        mms.To.Add(ss);
                    }
                }

                string[] mailCC = cc.Split(';');
                // 新增副本
                foreach (string Mailcc in mailCC)
                {
                    if (IsEmail(Mailcc))
                        mms.CC.Add(Mailcc);
                }


                string[] mailBCC = Bcc.Split(';');
                // 新增副本
                foreach (string Mailbcc in mailBCC)
                {
                    if (IsEmail(Mailbcc))
                        mms.Bcc.Add(Mailbcc);
                }


                // 設定郵件屬性，在此設定為「高」
                if (iMailPriority == 1)
                {
                    mms.Priority = MailPriority.High;
                }
                else if (iMailPriority == 2)
                {
                    mms.Priority = MailPriority.Low;
                }
                else
                {
                    mms.Priority = MailPriority.Normal;
                }

                // 設定主旨
                mms.Subject = strSubject;

                // 設定信件內容
                mms.Body = strBody;
                // 設定信件內容是否為 Html 格式
                mms.IsBodyHtml = bIsBodyHtml;

                // 設定是否有附加檔案，有則新增
                string[] Attachments = strAttachments.Split(';');

                foreach (string strAtt in Attachments)
                {

                    if (strAtt != string.Empty)
                    {
                        mms.Attachments.Add(new Attachment(strAtt));
                    }

                }

                // 建立 SmtpClient 實體
                SmtpClient smtp_Client = new SmtpClient();
                int iTime = Properties.Settings.Default.EmailTimeOut;
                smtp_Client.Timeout = iTime;

                // 建立 Host, Port, SSL, Credentials...等
                smtp_Client.Host = Properties.Settings.Default.SMTPServer;
                smtp_Client.Port = Properties.Settings.Default.EmailPort;
                smtp_Client.EnableSsl = Properties.Settings.Default.EmailSSL;
                smtp_Client.UseDefaultCredentials = false;
                smtp_Client.Credentials = new NetworkCredential(Properties.Settings.Default.EmailAddress, Properties.Settings.Default.EmailPassword);
                
                // 設定 DeliveryMethod 的傳送信件方法 (共有3種)
                smtp_Client.DeliveryMethod = SmtpDeliveryMethod.Network;
                //smtp_Client.DeliveryMethod = SmtpDeliveryMethod.PickupDirectoryFromIis;  
                //smtp_Client.DeliveryMethod = SmtpDeliveryMethod.SpecifiedPickupDirectory;

                // 送出郵件 
                smtp_Client.Send(mms);

                return true;

            }
            catch //(Exception ex)
            {
                throw ;
            }
        }



        #endregion

    }
}
