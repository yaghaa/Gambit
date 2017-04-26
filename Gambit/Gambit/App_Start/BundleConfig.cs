using System.Web;
using System.Web.Optimization;

namespace Gambit
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr.js"));

            bundles.Add(new ScriptBundle("~/bundles/allscripts").Include(
                         "~/Scripts/sb-admin-2",
                         "~/Scripts/locale-all",
                         "~/Scripts/gulpfile",
                         "~/Scripts/gcal",
                         "~/Scripts/fullcalendar",
                         "~/Scripts/calendar",
                         "~/Scripts/main"
                         ));


            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/css/bootstrap.css",
                      "~/Content/css/fullcalendar.css",
                      "~/Content/css/sb-admin-2.css",
                      "~/Content/css/timeline.css"));
        }
    }
}
