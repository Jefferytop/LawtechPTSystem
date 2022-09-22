using LawtechPTWeb.Models;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Text;
using System;

namespace LawtechPTWeb.Controllers
{
    public class TrademarkInfoController : Controller
    {
        //
        // GET: /TrademarkInfo/
        [Authorize]
        public ActionResult Index()
        {
            ViewBag.Message = "P.T.S-Admin|商標基本資料管理";
            return View();
        }

        /// <summary>
        /// 取得商標列表
        /// </summary>
        /// <returns></returns>        
        [HttpPost]
        [Authorize]
        public ActionResult GetTrademarkListByPage(string TrademarkNo,string TrademarkName , int pageSize, string PageNumber, string sort, string order, string search)
        {
            DB_ApplicantTModel manger = (DB_ApplicantTModel)Session[PublicFunction.GetEnumString(SessionCodeName.UserInfo)];

            List<PV_TrademarkList> tmlist = new List<PV_TrademarkList>();

            StringBuilder sb = new StringBuilder("ApplicantNames like N'%" + manger.ApplicantName + "%' ");

            if (!string.IsNullOrEmpty(TrademarkNo))
            {
                sb.Append(" and TrademarkNo like N'%" + TrademarkNo + "%' ");
            }

            if (!string.IsNullOrEmpty(TrademarkName))
            {
                sb.Append(" and TrademarkName like N'%" + TrademarkName + "%' ");
            }

            int itotal = 0;
            object obj = PV_TrademarkList.ReadList(sb.ToString(), sort + " " + order, ref tmlist, ref itotal, myPageSize: pageSize, myPageIndex: PageNumber == null ? 0 : int.Parse(PageNumber));

            OP_TrademarkList op = new OP_TrademarkList();
            op.rows = tmlist;
            op.total = itotal;
            return new JsonResult()
            {
                Data = op,
                MaxJsonLength = Int32.MaxValue
            };
        }

        [Authorize]
        public ActionResult TrademarkFee()
        {
            ViewBag.Message = "P.T.S-Admin|付款查詢";
            return View();
        }

        /// <summary>
        /// 取得商標請款列表
        /// </summary>
        /// <returns></returns>        
        [HttpPost]
        [Authorize]
        public ActionResult GetTrademarkFeeListByPage(string TrademarkNo, string TrademarkName, int pageSize, string PageNumber, string sort, string order, string search)
        {
            DB_ApplicantTModel manger = (DB_ApplicantTModel)Session[PublicFunction.GetEnumString(SessionCodeName.UserInfo)];

            List<PV_TrademarkFee> Feelist = new List<PV_TrademarkFee>();

            StringBuilder sb = new StringBuilder("ApplicantNames like N'%" + manger.ApplicantName + "%' ");

            if (!string.IsNullOrEmpty(TrademarkNo))
            {
                sb.Append(" and TrademarkNo like N'%" + TrademarkNo + "%' ");
            }

            if (!string.IsNullOrEmpty(TrademarkName))
            {
                sb.Append(" and TrademarkName like N'%" + TrademarkName + "%' ");
            }

            int itotal = 0;

            object obj = PV_TrademarkFee.ReadList(sb.ToString(), sort + " " + order, ref Feelist, ref itotal, myPageSize: pageSize, myPageIndex: PageNumber == null ? 0 : int.Parse(PageNumber));

            OP_TrademarkFee op = new OP_TrademarkFee();
            op.rows = Feelist;
            op.total = itotal;
            return new JsonResult()
            {
                Data = op,
                MaxJsonLength = Int32.MaxValue
            };
        }



    }
}
