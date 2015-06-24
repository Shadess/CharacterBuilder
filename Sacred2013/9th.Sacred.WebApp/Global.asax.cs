using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace _9th.Sacred.WebApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            ViewEngines.Engines.Add(new RazorViewEngine
            {
                PartialViewLocationFormats = new string[]
                {
                    "~/Views/Shared/Character/{0}.cshtml",
                    "~/Views/Admin/Partials/{0}.cshtml"
                }
            });
        }

        protected void Session_Start(Object sender, EventArgs e)
        {

        }

        protected void Session_End(Object sender, EventArgs e)
        {

        }
    }
}
