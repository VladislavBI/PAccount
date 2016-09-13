using System.Web;
using System.Web.Optimization;

namespace PAccountant.Model.View
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/Jquery/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/Jquery/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/Others/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/Bootstrap/bootstrap.js",
                      "~/Scripts/Others/respond.js",
                      "~/Scripts/Bootstrap/ui-bootstrap-2.1.3.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                        "~/Scripts/Angular/angular.min.js",
                        "~/Scripts/Angular/app.js"));

            bundles.Add(new ScriptBundle("~/bundles/authorization").Include(
                        "~/Scripts/Angular/Custom/Service/validator-service.js",
                        "~/Scripts/Angular/Custom/Controller/authorization-controller.js"));

            bundles.Add(new ScriptBundle("~/bundles/accountant").Include(
                        "~/Scripts/Angular/Custom/Factory/api-url-factory.js",
                        "~/Scripts/Angular/Custom/Service/chain-of-responsibility-service.js",
                        "~/Scripts/Angular/Custom/Service/http-service.js",
                        "~/Scripts/Angular/Custom/Service/modal_service.js",
                        "~/Scripts/Angular/Custom/Service/validator-service.js",
                        "~/Scripts/Angular/Custom/Service/add-operation-popUp-service.js",
                        "~/Scripts/Angular/Custom/Controller/accountant-main-controller.js",
                        "~/Scripts/Angular/Custom/Controller/operation_popup_controller.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/CustomCss.css"));
        }
    }
}
