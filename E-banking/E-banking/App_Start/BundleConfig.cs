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

            bundles.Add(new ScriptBundle("~/bundles/JS").Include(
                       "~/Scripts/JS/jquery-1.9.1.js*",
                       "~/Scripts/JS/jquery-1.9.1.min.js*",
                        "~/Scripts/JS/custom*",
                        "~/Scripts/JS/jquery.reveal*",
                        "~/Scripts/JS/jquery.flexslider*",
                        "~/Scripts/JS/jquery.checkbox*",
                        "~/Scripts/JS/jquery.elastislide*",
                        "~/Scripts/JS/jquery.twitter*",
                        "~/Scripts/JS/jquery.mobilemenu*",
                        "~/Scripts/JS/jquery.prettyPhoto*",
                        "~/Scripts/JS/jquery.easing.min*",
                        "~/Scripts/JS/superfish*",
                        "~/Scripts/JS/modernizr.custom.14583*"));

            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/custom.css"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                       "~/Content/Style/base.css",
                       "~/Content/Style/coming-soon-page.css",
                       "~/Content/Style/flexslider.css",
                       "~/Content/Style/fonts.css",
                       "~/Content/Style/layout.css",
                       "~/Content/Style/normalize.css",
                       "~/Content/Style/prettyPhoto.css",
                       "~/Content/Style/skeleton.css",
                       "~/Content/Style/style.css",
                       "~/Content/Style/login.css",
                       "~/Content/Style/superfish.css",
                       "~/Content/custom.css"));

            
        }
    }
}