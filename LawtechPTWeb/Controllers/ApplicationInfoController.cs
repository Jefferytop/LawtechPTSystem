using LawtechPTWeb.Models;
using System.Web.Mvc;

namespace LawtechPTWeb.Controllers
{
    public class ApplicationInfoController : Controller
    {

        [Authorize]
        public ActionResult Index()
        {
            return View();
        }


        [Authorize]
        public ActionResult ReSetPassword()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult ChangePassword(Models.LocalPasswordModel model)
        {
            if (model.OldPassword == null || model.NewPassword == null)
            {
                return Content("密碼不得為空，請重新確認!!");
            }
            object objRet = new object();
          
                DB_ApplicantTModel manger = (DB_ApplicantTModel)Session[PublicFunction.GetEnumString(SessionCodeName.UserInfo)];

                if (manger.Password == model.OldPassword.Trim())
                {
                    if (model.NewPassword.Trim() == model.ConfirmPassword.Trim())
                    {
                        manger.Password = model.NewPassword;
                        manger.LastModifyWorker = "申請人:"+manger.Account;

                        objRet = manger.Update();

                        Session[PublicFunction.GetEnumString(SessionCodeName.UserInfo)] = manger;
                        return Content(objRet.ToString());
                    }
                    else
                    {
                        
                        TempData["ErrorMsg"] = "新密碼、確認密碼輸入有誤，請重新確認";
                        return Content(TempData["ErrorMsg"].ToString());
                    }
                }
                else
                {
                    
                    TempData["ErrorMsg"] = "舊密碼有誤，請重新確認";
                    return Content(TempData["ErrorMsg"].ToString());
                }
            //}
            //else
            //{
                
            //    TempData["ErrorMsg"] = "Error";
            //    return Content(TempData["ErrorMsg"].ToString());
            //}
        }
    }
}
