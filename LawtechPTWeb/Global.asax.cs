using H3Operator.DBHelper;
using System;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace LawtechPTWeb
{
    // 注意: 如需啟用 IIS6 或 IIS7 傳統模式的說明，
    // 請造訪 http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();

            //設定資料庫連線字串
            DBSetConnection.AddConnectionListByConfigALL(true);
            DBSetConnection.SetDefaultConnection("DefaultConnection");
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            // 發生未處理錯誤時執行的程式碼          
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("------Application_Error------\r\n");

            var error = Server.GetLastError();
            HttpException httpException = new HttpException();
            int httpCode = 0;
            try
            {
                httpException = (HttpException)error;
                httpCode = httpException.GetHttpCode();
            }
            catch
            {
            }

            sb.Append("ExceptionType:" + error.GetType().ToString() + "\r\n");
            sb.Append("ExceptionTime:" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "\r\n");
            sb.Append("Message: " + error.Message + "\r\n");
            //CommonFunction.ThreadWriteLog(sb.ToString());
            Response.Redirect("~/");
        }
    }
}