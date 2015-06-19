using System.Web;
using System.Web.Optimization;

namespace _9th.Sacred.WebApp
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/headerscripts").Include("~/Scripts/angular.js"));

            bundles.Add(new ScriptBundle("~/bundles/scripts").Include(
                        "~/Scripts/jquery*",
                        "~/Scripts/bootstrap.js",
                        "~/Scripts/angular-*",
                        "~/Scripts/sacred.core.js",
                        "~/Scripts/Factories/*.js",
                        "~/Scripts/Controllers/*.js",
                        "~/Scripts/Sacred/*.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap-theme.css",
                      "~/Content/bootstrap.css", 
                      "~/Content/9th.Sacred.css",
                      "~/Content/Site.css"));
        }
    }
}
