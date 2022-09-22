using System;
using System.Web;
using System.Web.Security;

namespace LawtechPTWeb.Models
{
    public class ValidateBaseProvider : MembershipProvider
    {
        #region Property
        /// <summary>
        /// 應用程式名稱設定
        /// </summary>
        public override string ApplicationName
        {
            get
            {
                return "PatentTrademarSystem v1.0";
            }
            set
            {
            }
        }
        #endregion

        #region Static Method
        /// <summary>
        /// 取得登入者IP
        /// </summary>
        /// <returns></returns>
        public static string GetLoginUserIP()
        {
            try
            {
                string ViaProxy = HttpContext.Current.Request.ServerVariables["HTTP_VIA"];
                //沒有經過proxy : 直接取登入者IP
                if (ViaProxy == null)
                {
                    return HttpContext.Current.Request.UserHostAddress;
                }
                //有經過proxy : 取真實IP
                else
                {
                    return HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"].ToString();
                }
            }
            catch (System.Exception EX)
            {
                return EX.Message;
            }
        }

        /// <summary>
        /// 取得登入者的語系
        /// </summary>
        /// <returns></returns>
        public static string GetLanguage()
        {
            HttpCookie cLang = HttpContext.Current.Request.Cookies["Lang"];

            if (cLang != null)
            {
                //Culture 屬性: 負責判定與文化特性相關功能的結果 (例如: 日期、數字和貨幣格式等)。
                System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(cLang.Value);

                //UICulture 屬性: 負責覺得要為網頁載入哪一國的資源檔
                System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(cLang.Value);
            }


            return cLang.ToString();
        }
        #endregion

        #region method

        #region public override bool ValidateUser(string username, string password)
        /// <summary>
        /// 驗証帳密是否正確
        /// </summary>
        /// <param name="username">帳號</param>
        /// <param name="password">密碼</param>
        /// <returns>true 驗証成功; false 驗証失敗</returns>
        public override bool ValidateUser(string username, string password)
        {
            return true;
        }
        #endregion


        #endregion

        #region Unuse property
        public override bool EnablePasswordReset
        {
            get { throw new NotImplementedException(); }
        }

        public override bool EnablePasswordRetrieval
        {
            get { throw new NotImplementedException(); }
        }

        public override int MaxInvalidPasswordAttempts
        {
            get { throw new NotImplementedException(); }
        }

        public override int MinRequiredNonAlphanumericCharacters
        {
            get { throw new NotImplementedException(); }
        }

        public override int MinRequiredPasswordLength
        {
            get { throw new NotImplementedException(); }
        }

        public override int PasswordAttemptWindow
        {
            get { throw new NotImplementedException(); }
        }

        public override MembershipPasswordFormat PasswordFormat
        {
            get { throw new NotImplementedException(); }
        }

        public override string PasswordStrengthRegularExpression
        {
            get { throw new NotImplementedException(); }
        }

        public override bool RequiresQuestionAndAnswer
        {
            get { throw new NotImplementedException(); }
        }

        public override bool RequiresUniqueEmail
        {
            get { throw new NotImplementedException(); }
        }
        #endregion

        #region Unuse Methods
        public override bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            throw new NotImplementedException();
        }

        public override bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion, string newPasswordAnswer)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey, out MembershipCreateStatus status)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteUser(string username, bool deleteAllRelatedData)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
        {
            throw new NotImplementedException();
        }

        public override int GetNumberOfUsersOnline()
        {
            throw new NotImplementedException();
        }

        public override string GetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser GetUser(string username, bool userIsOnline)
        {
            throw new NotImplementedException();
        }

        public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
        {
            throw new NotImplementedException();
        }

        public override string GetUserNameByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public override string ResetPassword(string username, string answer)
        {
            throw new NotImplementedException();
        }

        public override bool UnlockUser(string userName)
        {
            throw new NotImplementedException();
        }

        public override void UpdateUser(MembershipUser user)
        {
            throw new NotImplementedException();
        }

        #endregion


    }
}