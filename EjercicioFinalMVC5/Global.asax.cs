using EjercicioFinalMVC5.Services.ID;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace EjercicioFinalMVC5
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AutofacConfig.ConfigureContainer();
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            GlobalConfiguration.Configuration.Formatters.Remove(GlobalConfiguration.Configuration.Formatters.XmlFormatter);
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            HttpContext ctx = HttpContext.Current;

            StringBuilder sb = new StringBuilder();
            sb.Append(ctx.Request.Url.ToString() + System.Environment.NewLine);
            sb.Append("Source:" + System.Environment.NewLine + ctx.Server.GetLastError().Source.ToString());
            sb.Append("Message:" + System.Environment.NewLine + ctx.Server.GetLastError().Message.ToString());
            sb.Append("Stack Trace:" + System.Environment.NewLine + ctx.Server.GetLastError().StackTrace.ToString());
            var error = sb.ToString();

            string logPath =  AppDomain.CurrentDomain.BaseDirectory + @"\Transversal\Log\log.txt";
            using (StreamWriter writer = new StreamWriter(logPath, true))
            {
                writer.WriteLine(DateTime.Now + " : " + error);
            }
        }
    }
}
