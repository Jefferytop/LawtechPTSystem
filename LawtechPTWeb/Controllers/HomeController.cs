using LawtechPTWeb.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace LawtechPTWeb.Controllers
{
    public class HomeController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            DB_ApplicantTModel manger = (DB_ApplicantTModel)Session[PublicFunction.GetEnumString(SessionCodeName.UserInfo)];

           
            int PatCounts = 0;
            object obj = PV_PatentList.GetTotalCountRows(ref PatCounts, "ApplicantNames like N'%" + manger.ApplicantName + "%' ");
            Session["PatentCount"] = PatCounts;
           
            int tmCounts = 0;
            obj = PV_TrademarkList.GetTotalCountRows(ref tmCounts, "ApplicantNames like N'%" + manger.ApplicantName + "%' ");
            Session["TrademarkCount"] = tmCounts;

            List<PV_PatentKind> kinds = new List<PV_PatentKind>();
            PV_PatentKind.ReadList(manger.ApplicantKey.ToString(), ref kinds);
            Session["PatentKindList"] = kinds;

            List<PV_TopPatentTrademark> top = new List<PV_TopPatentTrademark>();
            PV_TopPatentTrademark.ReadList(manger.ApplicantKey.ToString(), ref top);
            Session["TopPatTm"] = top;

            List<PV_FeePracticalityPay> feeTotal = new List<PV_FeePracticalityPay>();
            PV_FeePracticalityPay.ReadList(manger.ApplicantName.ToString(), ref feeTotal);
            Session["feeTotal"] = feeTotal;
            

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
