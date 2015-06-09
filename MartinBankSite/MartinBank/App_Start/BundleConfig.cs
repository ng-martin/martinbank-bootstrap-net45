using System.Web.Optimization;

namespace MartinBank.Web
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

            bundles.Add(new ScriptBundle("~/bundles/js-martinbank").Include(
                        "~/Scripts/MartinBank/martinbank.namespaces.js",
                        "~/Scripts/MartinBank/martinbank.payment.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/js-thirdparty").Include(
                        "~/Scripts/jquery.mask.js",
                        "~/Scripts/toastr.js"
                        ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new StyleBundle("~/Content/css")
                .Include(
                    "~/Content/toastr.css",
                    "~/Content/site.css"
                ));

            bundles.Add(new StyleBundle("~/Content/bootstrap")
                .Include(
                    "~/Content/bootstrap.css",
                    "~/Content/bootstrap-theme.css"
                ));

            bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
                        "~/Content/themes/base/jquery.ui.core.css",
                        "~/Content/themes/base/jquery.ui.datepicker.css",
                        "~/Content/themes/base/jquery.ui.theme.css"));

            BundleTable.EnableOptimizations = true;
        }
    }
}