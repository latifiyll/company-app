using System.Web;
using System.Web.Optimization;

namespace CompanyMVC
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new Bundle("~/bundles/lib").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/assets/js/plugins.js",
                        "~/Scripts/assets/js/main.js",
                        "~/Scripts/assets/js/popper.min.js",
                        "~/Scripts/assets/js/widgets.js",
                        "~/Scripts/assets/js/dashboard.js",
                        //"~/Scripts/bootstrap.js",
                      "~/Scripts/bootbox.js",
                      "~/Scripts/assets/js/lib/data-table/datatables.min.js",
                      "~/Scripts/assets/js/lib/data-table/dataTables.bootstrap.min.js",
                      "~/Scripts/assets/js/lib/data-table/dataTables.buttons.min.js",
                      "~/Scripts/assets/js/lib/data-table/buttons.bootstrap.min.js",
                      "~/Scripts/assets/js/lib/data-table/jszip.min.js",
                      "~/Scripts/assets/js/lib/data-table/pdfmake.min.js",
                      "~/Scripts/assets/js/lib/data-table/vfs_fonts.js",
                      "~/Scripts/assets/js/lib/data-table/buttons.html5.min.js",
                      "~/Scripts/assets/js/lib/data-table/buttons.print.min.js",
                      "~/Scripts/assets/js/lib/data-table/buttons.colVis.min.js",
                      "~/Scripts/assets/js/lib/data-table/datatables-init.js"

                      //"~/Scripts/datatables/jquery.datatables.js",
                      /*"~/Scripts/datatables/datatables.bootstrap.js"*/));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"
                        ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/assets/css/normalize.css",
                      "~/Content/assets/css/bootstrap.min.css",
                      "~/Content/assets/css/font-awesome.min.css",
                      "~/Content/assets/css/themify-icons.css",
                      "~/Content/assets/css/flag-icon.min.css",
                      "~/Content/assets/css/cs-skin-elastic.css",
                      "~/Content/assets/scss/style.css",
                      "~/Content/assets/css/lib/vector-map/jqvmap.min.css",

                      "~/Content/assets/css/lib/datatable/dataTables.bootstrap.min.css"));
        }
    }
}
