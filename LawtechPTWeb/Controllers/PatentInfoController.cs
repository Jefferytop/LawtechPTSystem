using CsvHelper;
using LawtechPTWeb.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Web.Mvc;

namespace LawtechPTWeb.Controllers
{
    public class PatentInfoController : Controller
    {
        //
        // GET: /PatentInfo/
        [Authorize]
        public ActionResult Index()
        { 
            return View();
        }

        /// <summary>
        /// 取得專利列表
        /// </summary>
        /// <returns></returns>        
        [HttpPost]
        [Authorize]
        public ActionResult GetPatentList()
        {
            DB_ApplicantTModel manger = (DB_ApplicantTModel)Session[PublicFunction.GetEnumString(SessionCodeName.UserInfo)];

            List<PV_PatentList> Patentlist = new List<PV_PatentList>();

            object obj = PV_PatentList.ReadList("ApplicantNames like N'%" + manger.ApplicantName + "%' ", ref Patentlist);
            

            return new JsonResult() { 
            Data= Patentlist,
            MaxJsonLength=Int32.MaxValue
            };
        }

        [HttpPost]
        [Authorize]
        public ActionResult GetPatentListByPage(string PatentNo, string ApplicationNo, int limit, string PageNumber, string sort, string order,string search)
        {
            DB_ApplicantTModel manger = (DB_ApplicantTModel)Session[PublicFunction.GetEnumString(SessionCodeName.UserInfo)];

            List<PV_PatentList> Patentlist = new List<PV_PatentList>();

            StringBuilder sb = new StringBuilder("ApplicantNames like N'%" + manger.ApplicantName + "%' " );

            if (!string.IsNullOrEmpty(PatentNo)) {
                sb.Append(" and PatentNo like N'%" + PatentNo + "%' ");
            }

            if (!string.IsNullOrEmpty(ApplicationNo))
            {
                sb.Append(" and ApplicationNo like N'%" + ApplicationNo + "%' ");
            }

           
            int itotal = 0;
            object obj = PV_PatentList.ReadList(sb.ToString(), sort+" "+ order, ref Patentlist,ref itotal, myPageSize: limit, myPageIndex: PageNumber==null?0: int.Parse(PageNumber));

            OP_PatentList op = new OP_PatentList();
            op.rows = Patentlist;
            op.total = itotal;
            return new JsonResult()
            {               
                Data = op,
                MaxJsonLength = Int32.MaxValue
            };

        }
                
      
        [Authorize]
        public ActionResult ExportCSV(string PatentNo,string ApplicationNo)
        {
            DB_ApplicantTModel manger = (DB_ApplicantTModel)Session[PublicFunction.GetEnumString(SessionCodeName.UserInfo)];

            List<PV_PatentList> Patentlist = new List<PV_PatentList>();

            StringBuilder sb = new StringBuilder("ApplicantNames like N'%" + manger.ApplicantName + "%' ");

            if (!string.IsNullOrEmpty(PatentNo))
            {
                sb.Append(" and PatentNo like N'%" + PatentNo + "%' ");
            }

            if (!string.IsNullOrEmpty(ApplicationNo))
            {
                sb.Append(" and ApplicationNo like N'%" + ApplicationNo + "%' ");
            }

            object obj = PV_PatentList.ReadList(sb.ToString(), ref Patentlist);

            byte[] result;
            using (var memoryStream = new MemoryStream())
            {
                using (var streamWriter = new StreamWriter(memoryStream,Encoding.Unicode))
                {
                    using (var csvWriter = new CsvWriter(streamWriter, System.Globalization.CultureInfo.CurrentCulture))
                    {
                        csvWriter.WriteRecords(Patentlist);
                        streamWriter.Flush();
                        result = memoryStream.ToArray();
                    }
                }
            }


            return new FileStreamResult(new MemoryStream(result), "text/csv") { FileDownloadName = "filename.csv" };

        }

     

        /// <summary>
        /// 取得專利案件階段列表
        /// </summary>
        /// <returns></returns>        
        [HttpGet]
        [Authorize]
        public ActionResult GetPatentStatusStatistics()
        {
            DB_ApplicantTModel manger = (DB_ApplicantTModel)Session[PublicFunction.GetEnumString(SessionCodeName.UserInfo)];

            List<PV_PatentStatusStatistics> Patentlist = new List<PV_PatentStatusStatistics>();

            object obj = PV_PatentStatusStatistics.ReadList(manger.ApplicantName, ref Patentlist);

            return Json(Patentlist, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 取得專利案件種類列表
        /// </summary>
        /// <returns></returns>        
        [HttpGet]
        [Authorize]
        public ActionResult GetPatentKindList()
        {
            DB_ApplicantTModel manger = (DB_ApplicantTModel)Session[PublicFunction.GetEnumString(SessionCodeName.UserInfo)];

            List<PV_PatentStatusStatistics> Patentlist = new List<PV_PatentStatusStatistics>();

            object obj = PV_PatentStatusStatistics.ReadList(manger.ApplicantName, ref Patentlist);

            return Json(Patentlist, JsonRequestBehavior.AllowGet);
        }

        [Authorize]
        public ActionResult PatentFee()
        {
            ViewBag.Message = "P.T.S-Admin|付款查詢";
            return View();
        }

        /// <summary>
        /// 取得專利請款列表
        /// </summary>]
        /// <returns></returns>     
        [HttpPost]
        [Authorize]
        public ActionResult GetPatentFeeListByPage(string PatentNo, int pageSize, string PageNumber, string sort, string order, string search)
        {
            DB_ApplicantTModel manger = (DB_ApplicantTModel)Session[PublicFunction.GetEnumString(SessionCodeName.UserInfo)];

            List<PV_PatentFee> Feelist = new List<PV_PatentFee>();

            StringBuilder sb = new StringBuilder("PracticalityPay>0 and ApplicantNames like N'%" + manger.ApplicantName + "%' ");

            if (!string.IsNullOrEmpty(PatentNo))
            {
                sb.Append(" and PatentNo like N'%" + PatentNo + "%' ");
            }

            int itotal = 0;
            object obj = PV_PatentFee.ReadList(sb.ToString(), sort + " " + order, ref Feelist, ref itotal, myPageSize: pageSize, myPageIndex: PageNumber == null ? 0 : int.Parse(PageNumber));

            OP_PatentFee op = new OP_PatentFee();
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
