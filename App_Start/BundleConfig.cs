using System.Web;
using System.Web.Optimization;

namespace WebVentaVehiculos
{
    public class BundleConfig
    {
        // Para obtener más información sobre las uniones, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/chosen").Include(
            "~/Scripts/chosen.jquery.min.js",
            "~/Scripts/chosen.jquery.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                             "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                         "~/Scripts/jquery-{version}.js",
                        "~/Scripts/bootstrap.js",
                        "~/Scripts/bootbox.js",
                        "~/Scripts/respond.js",
                        "~/Scripts/datatables/jquery.datatables.js",
                        "~/Scripts/datatables/datatables.bootstrap.js",
                        "~/Scripts/typeahead.bundle.js",
                        "~/ Scripts/MenuHamburguesa.js",
                        "~/Scripts/toastr.js"
                      ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Utilice la versión de desarrollo de Modernizr para desarrollar y obtener información. De este modo, estará
            // para la producción, use la herramienta de compilación disponible en https://modernizr.com para seleccionar solo las pruebas que necesite.


            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/c3").Include(
            "~/Scripts/c3.min.js",
            "~/Scripts/c3.js",
            "~/Scripts/d3.min.js",
            "~/Scripts/d3.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/bootbox.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/chosen.css",
                       "~/Content/c3.css",
                      "~/Content/datatables/css/datatables.bootstrap.css",
                      "~/Content/themes/base/jquery-ui.css",
                      "~/Content/site.css",
                      "~/Content/bootstrap-select.css",
                      "~/Content/bootstrap-select.min.css",
                      "~/Content/MenuHamburguesa.css")) ;

            bundles.Add(new ScriptBundle("~/bundles/bootstrapSelect").Include(
                "~/Scripts/bootstrap-select.js",
                "~/Scripts/bootstrap-select.min.js",
                "~/Scripts/jquerysession.js"
                ));
        }
    }
}
