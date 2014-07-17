using System.Web;
using System.Web.Optimization;

namespace LineFocus.Nikcron
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/page").Include("~/Scripts/pagevalidator.js"));
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                        "~/Scripts/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));
            bundles.Add(new ScriptBundle("~/bundles/jgWidget").Include("~/Scripts/jqwidgets/jqx-all.js"));

            bundles.Add(new ScriptBundle("~/bundles/AdminLTEApp").Include(
                        "~/Scripts/AdminLTE/app.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/footable")
                                        .Include
                                        (
                                            "~/Scripts/footable.js",
                                            "~/Scripts/footable.bookmarkable.js",
                                            "~/Scripts/footable.filter.js",
                                            "~/Scripts/footable.paginate.js",
                                            "~/Scripts/footable.plugin.template.js",
                                            "~/Scripts/footable.sort.js",
                                            "~/Scripts/footable.striping.js"
                                        ));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/bootstrap.css", "~/Content/sticky-footer-navbar.css"));

            bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
                        "~/Content/themes/base/jquery.ui.core.css",
                        "~/Content/themes/base/jquery.ui.resizable.css",
                        "~/Content/themes/base/jquery.ui.selectable.css",
                        "~/Content/themes/base/jquery.ui.accordion.css",
                        "~/Content/themes/base/jquery.ui.autocomplete.css",
                        "~/Content/themes/base/jquery.ui.button.css",
                        "~/Content/themes/base/jquery.ui.dialog.css",
                        "~/Content/themes/base/jquery.ui.slider.css",
                        "~/Content/themes/base/jquery.ui.tabs.css",
                        "~/Content/themes/base/jquery.ui.datepicker.css",
                        "~/Content/themes/base/jquery.ui.progressbar.css",
                        "~/Content/themes/base/jquery.ui.theme.css"));

            bundles.Add(new StyleBundle("~/Content/footable/css").Include("~/Content/footable*"));

            bundles.Add(new StyleBundle("~/Content/jqWidget").Include("~/Scripts/jqwidgets/styles/jqx.base.css", "~/Scripts/jqwidgets/styles/jqx.metro.css"));

            bundles.Add(new StyleBundle("~/Content/AdminLTE").Include(
                        "~/Content/font-awesome.css",
                        "~/Content/ionicons.css",
                        "~/Content/ionslider/ion.rangeSlider.css",
                        "~/Content/ionslider/ion.rangeSlider.skinFlat.css",
                        "~/Content/ionslider/ion.rangeSlider.skinNice.css",
                        "~/Content/slider.css",
                        "~/Content/bootstrap3-wysihtml5.css",
                        "~/Content/AdminLTE.css"
                ));

        }
    }
}