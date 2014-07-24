using System.Web;
using System.Web.Optimization;

namespace E_banking
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));


            bundles.Add(new ScriptBundle("~/bundles/Scripts").Include(
                     "~/Scripts/bootstrap.min.js",
                     "~/Scripts/jquery-1.11.0.min.js",
                     "~/Scripts/custom.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                       "~/Content/css/bootstrap.min.css",
                       "~/Content/css/font-awesome.css",
                       "~/Content/css/font-awesome.min.css",
                       "~/Content/css/main.css",
                       "~/Content/css/normalize.css",
                       "~/Content/css/responsive.css"));

            
        }
    }
}