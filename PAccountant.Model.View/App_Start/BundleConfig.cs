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
                      //"~/Scripts/Bootstrap/ui-bootstrap-2.1.3.min.js",
                      "~/Scripts/Bootstrap/ui-bootstrap-tpls.min.js",
                      "~/Scripts/Others/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                        "~/Scripts/Angular/angular.min.js",
                        "~/Scripts/Angular/angular-route.min.js",
                        "~/Scripts/angular-ui/angular-animate.min.js",
                        //"~/Scripts/angular-ui/ui-bootstrap-custom-2.1.3.min.js",
                        //"~/Scripts/angular-ui/ui-bootstrap-2.1.3.min.js",
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
                        "~/Scripts/Angular/Custom/Service/converter-service.js",
                        "~/Scripts/Angular/Custom/Controller/accountant-main-controller.js",
                        "~/Scripts/Angular/Custom/Controller/popup_controllers.js",
                        "~/Scripts/Angular/Custom/Controller/statistic-personal-controller.js",
                        "~/Scripts/Angular/Custom/Controller/operations-table-controller.js",
                        "~/Scripts/Angular/Custom/Controller/extremums-controller.js",
                        "~/Scripts/Angular/Custom/Controller/notifications-controller.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/ui-bootstrap-csp.css",
                      "~/Content/site.css",
                      "~/Content/CustomCss.css"));

            bundles.Add(new ScriptBundle("~/bundles/jsgrid").
                IncludeDirectory("~/Scripts/Others/JSGrid", "*.js", true).
                IncludeDirectory("~/Scripts/Others/JSGrid/fields", "*.js", true).
                IncludeDirectory("~/Scripts/Others/JSGrid/i18n", "*.js", true));


            bundles.Add(new StyleBundle("~/Content/jsgridCss")
                .IncludeDirectory("~/Content/JSGrid", "*.css", true));

            bundles.Add(new ScriptBundle("~/bundles/googleCharts").Include(
                "~/Scripts/Angular/Custom/Controller/chart-controller.js",
                "~/Scripts/Angular/Custom/Factory/line-chart-factory.js",
                "~/Scripts/Angular/Custom/Factory/bar-chart-factory.js",
                "~/Scripts/Angular/Custom/Factory/pie-chart-factory.js"));

            bundles.Add(new ScriptBundle("~/bundles/personalJS").Include(
                    "~/Scripts/Angular/PersonalAccountant/Factory/add-personal-operation-factory.js"));
            bundles.Add(new ScriptBundle("~/bundles/debtJS").Include(
                    "~/Scripts/Angular/Debts/Factory/add-debt-operation-factory.js",
                    "~/Scripts/Angular/Debts/Controller/add-debt-transaction-controller.js",
                    "~/Scripts/Angular/Debts/Controller/debt-transaction-controller.js",
                    "~/Scripts/Angular/Debts/Controller/statistic-debt-controller.js",
                    "~/Scripts/Angular/Debts/Controller/debt-operations-table.js"));

            bundles.Add(new ScriptBundle("~/bundles/otherJS").Include(
                    "~/Scripts/Angular/Other/Controller/planed-buy-controller.js",
                    "~/Scripts/Angular/Other/Controller/freelance-popup-controllers.js",
                    "~/Scripts/Angular/Other/Controller/freelance-controller.js"));
        }
    }
}
