using System.Web;
using System.Web.Optimization;

namespace AngularWebApplication
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
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"
                      //, "~/Content/ag-*"
                      //, "~/Content/theme-fresh.css"
                      ));

            bundles.Add(new ScriptBundle("~/bundles/Angular").Include(
                        "~/Scripts/AngularJs/angular.js"
                        , "~/Scripts/AngularJs/ag-*"
                        //, "~/Scripts/Paging.js"
                        ));
            bundles.Add(new StyleBundle("~/Content/cssAngular").Include(
                      "~/Content/Angular/ag-grid.css"
                      , "~/Content/theme-fresh.css"));
            //bundles.UseCdn = true;
            //var cdnPath = "https://cdnjs.cloudflare.com/ajax/libs/angular.js/1.5.0-beta.1/angular.min.js";
            //bundles.Add(new ScriptBundle("~/bundles/AngularLib", cdnPath).Include("angular.min.js"));
           
        }
    }
}
