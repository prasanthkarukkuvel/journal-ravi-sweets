using System.Web;
using System.Web.Optimization;

namespace Journal7
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
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/angular.js",
                      "~/Scripts/angular-ui-router.js",
                      "~/Scripts/angular-material-icons.min.js",
                      "~/Scripts/svg-morpheus.js",
                      "~/Scripts/materialize.min.js",
                      "~/Scripts/respond.js",
                      "~/Scripts/app.js"));
          
            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/materialize.min.css",
                      "~/Content/layout.css"));
        }
    }
}
