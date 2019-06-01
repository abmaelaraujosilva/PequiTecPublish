using System.Web.Optimization;
using WebHelpers.Mvc5;

namespace PequiTec.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Bundles/css")
                .Include("~/Content/css/bootstrap.min.css", new CssRewriteUrlTransformAbsolute())
                .Include("~/Content/css/bootstrap-select.css")
                .Include("~/Content/css/bootstrap-datepicker3.min.css")
                .Include("~/Content/css/font-awesome.min.css", new CssRewriteUrlTransformAbsolute())
                .Include("~/Content/css/icheck/blue.min.css", new CssRewriteUrlTransformAbsolute())
                .Include("~/Content/css/AdminLTE.css", new CssRewriteUrlTransformAbsolute())
                .Include("~/Content/stylish-portfolio.min.css")
                .Include("~/DataTable/css/dataTables.bootstrap.min.css")
                .Include("~/Content/Pequitec.css")
                .Include("~/Content/UploadImg.css")
                .Include("~/Content/css/skins/skin-blue.css"));

            bundles.Add(new StyleBundle("~/Bundles2/css")
                .Include("~/Content/bootstrap.min.css", new CssRewriteUrlTransformAbsolute())
                .Include("~/Content/css/font-awesome.min.css", new CssRewriteUrlTransformAbsolute())
                .Include("~/Content/simple-line-icons.css")
                .Include("~/Content/stylish-portfolio.min.css")
                .Include("~/Content/Organograma.css")
                .Include("~/Content/Pequitec.css")
                .Include("~/Content/carosel.css")
                .Include("~/Content/css/AdminLTE.min.css", new CssRewriteUrlTransformAbsolute())
                .Include("~/Content/agency.min.css"));

            bundles.Add(new ScriptBundle("~/Bundles/js")
                .Include("~/Content/js/plugins/jquery/jquery-3.3.1.js")
                .Include("~/Content/js/plugins/bootstrap/bootstrap.js")
                .Include("~/Content/js/plugins/fastclick/fastclick.js")
                .Include("~/Content/js/plugins/slimscroll/jquery.slimscroll.js")
                .Include("~/Content/js/plugins/bootstrap-select/bootstrap-select.js")
                .Include("~/Content/js/plugins/moment/moment.js")
                .Include("~/Content/js/plugins/datepicker/bootstrap-datepicker.js")
                .Include("~/Content/js/plugins/icheck/icheck.js")
                .Include("~/Content/js/plugins/validator.js")
                .Include("~/Content/js/plugins/inputmask/jquery.inputmask.bundle.js")
                .Include("~/Scripts/stylish-portfolio.min.js")
                .Include("~/DataTable/js/jquery.js")
                .Include("~/DataTable/js/jquery.dataTables.min.js")
                .Include("~/DataTable/js/dataTables.bootstrap.min.js")
                .Include("~/DataTable/js/DataTableID.js")
                .Include("~/Content/js/adminlte.js")
                .Include("~/Scripts/PequiTec.js")
                .Include("~/Scripts/UploadImg.js")
                .Include("~/Scripts/jquery.unobtrusive-ajax.min.js")
                .Include("~/Content/js/init.js"));

            bundles.Add(new ScriptBundle("~/Bundles2/js")
                .Include("~/Content/js/plugins/bootstrap/bootstrap.min.js")
                .Include("~/Scripts/jquery.unobtrusive-ajax.min.js")
                .Include("~/Scripts/bootstrap.min.js")
                .Include("~/Scripts/bootstrap.bundle.min.js")
                .Include("~/Scripts/jquery.easing.min.js")
                .Include("~/Scripts/stylish-portfolio.min.js")
                .Include("~/Content/js/adminlte.js"));

#if DEBUG
            BundleTable.EnableOptimizations = false;
#else
            BundleTable.EnableOptimizations = true;
#endif
        }
    }
}
