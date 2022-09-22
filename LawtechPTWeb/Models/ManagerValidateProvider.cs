using System;
using System.Collections.Generic;
using System.Web;
using H3Operator.DBHelper;
using H3Operator.DBModels;
using System.Data.SqlClient;
using System.Web.Mvc;

namespace LawtechPTWeb.Models
{
    public class ManagerValidateProvider : ValidateBaseProvider
    {

        /// <summary>
        /// 驗證登入都的帳號、密碼
        /// </summary>
        /// <param name="userAccount">帳號</param>
        /// <param name="password">密碼</param>
        /// <returns>return true or false</returns>
        public override bool ValidateUser(string userAccount, string password)
        {
            //預設為驗証失敗
            object retobj = "1";

            //加密字串
            //string encodepwd = PTSBaseEncrypt.EncryptDES(password);

            //驗証使用者
            DB_ApplicantTModel manager = new DB_ApplicantTModel();

            SqlParameter[] SqlParameterList ={DBAccess.MakeInParam("Account",SqlDataType.VarChar,userAccount),
                                             DBAccess.MakeInParam("Password", SqlDataType.VarChar, password) };
            retobj = DB_ApplicantTModel.ReadOne("Account=@Account and Password=@Password ", ref manager, SqlParameterList);

            //string strMenuRoleName = "";

            if (retobj.ToString() == "0")
            {
                HttpContext.Current.Session[PublicFunction.GetEnumString(SessionCodeName.UserInfo)] = manager;

                List<PV_UserMenuTree> MenuTree = PublicFunction.GetUserMenuTreeMethod();
                HttpContext.Current.Session["MenuTree"] = MenuTree;
                return true;
            }
            else
            {
                HttpContext.Current.Session[PublicFunction.GetEnumString(SessionCodeName.UserInfo)] = null;
                HttpContext.Current.Session.Clear();
                return false;
            }

        }

       


    }
}