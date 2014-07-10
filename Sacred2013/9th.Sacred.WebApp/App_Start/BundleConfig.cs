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
            bundles.Add(new ScriptBundle("~/bundles/scripts").Include(
                        "~/Scripts/*.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/9th.Sacred.css",
                      "~/Content/Site.css"));
        }
    }
}
