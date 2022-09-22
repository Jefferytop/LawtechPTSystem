using LawtechPTWeb.Models;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace LawtechPTWeb.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/
        [AllowAnonymous]
        public ActionResult Index(string returnUrl)
        {
            List<Models.CStatueRecordT> sr = new List<Models.CStatueRecordT>();
            Models.CStatueRecordT.ReadList(ref sr, "StatusName='WebSystemName' or StatusName='GoogleAnalytics'");
            foreach(var item in sr)
            {
                if (item.StatusName == "WebSystemName")
                {
                    Session["WebSystemName"] = item.Value;
                }
                else if (item.StatusName == "GoogleAnalytics")
                {
                    Session["GoogleAnalytics"] = item.Value;
                }
            }
            
            ViewBag.ReturnUrl = returnUrl==null?"": returnUrl;
            return View();
        }

        // GET: /Login/
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Index(LoginModel model, string returnUrl)
        {
            ViewData["ErrorString"] = "";
            if (ModelState.IsValid)
            {
                if (Membership.ValidateUser(model.Account, model.Password))
                {
                    Models.DB_ApplicantTModel manager = (Models.DB_ApplicantTModel)Session[PublicFunction.GetEnumString(SessionCodeName.UserInfo)];
                    if ( manager.ApplicantKey > 0 )
                    {
                        FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1,
                         model.Account,//你想要存放在 User.Identy.Name 的值，通常是使用者帳號
                         DateTime.Now,
                         DateTime.Now.AddMinutes(30), //票證到期時間
                         model.RememberMe, //將管理者登入的 Cookie 設定成 Session Cookie
                         Guid.NewGuid().ToString(),
                         FormsAuthentication.FormsCookiePath);

                        string encTicket = FormsAuthentication.Encrypt(ticket);
                        var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);

                        cookie.HttpOnly = true; // cookie not available in javascript.
                        Response.Cookies.Add(cookie);

                        return RedirectToAction("Index", "Home");
                        //return RedirectToLocal(returnUrl);
                    }
                    else if (manager.ApplicantKey > 0 &&( manager.Account =="" || manager.Password =="") )
                    {
                        TempData["ErrorString"] = "此登入Email已被停用";
                        return View(model);
                    }                    
                    else
                    {
                        TempData["ErrorString"] = "登入的資訊不正確，請重新確認!!";
                        return View(model);
                    }
                }
                else
                {
                    // 如果執行到這裡，發生某項失敗，則重新顯示表單                 
                    TempData["ErrorString"] = "所提供的Email或密碼不正確。";
                    return View(model);
                }
            }
            else
            {
                foreach (ModelState error in ModelState.Values)
                {
                    if (error.Errors.Count > 0)
                    {
                        TempData["ErrorString"] = error.Errors[0].ErrorMessage;
                        break;
                    }
                }

                return View(model);
            }
        }

        [AllowAnonymous]
        public ActionResult LogOff()
        {
            //將在綫狀態變成0
            //Models.DB_ApplicantTModel manager = (Models.DB_ApplicantTModel)Session[PublicFunction.GetEnumString(SessionCodeName.UserInfo)];
            //if (manager != null)
            //{
                //manager.Online = false;
                //manager.LastActive = DateTime.Now;
                //manager.Update();
            //}
            Session.RemoveAll();

            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Login");
        }

       
    }
}
