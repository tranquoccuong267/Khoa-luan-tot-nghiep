using System.Web;
using System.Web.Optimization;

namespace BeautyCosmetic.Web
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/js/jquery").Include("~/Assets/client/js/jquery-2.2.3.min.js"));

            bundles.Add(new ScriptBundle("~/js/plugins").Include(
                 "~/Assets/admin/libs/jqueri-ui/jquery-ui.min.js",
                 "~/Assets/admin/libs/mustache/mustache.js",
                 "~/Assets/admin/libs/numeral/numeral.js",
                 "~/Assets/admin/libs/jquery-validation/dist/jquery.validate.js",
                 "~/Assets/client/js/common.js",
                 "~/ Assets/client/js/ responsiveslides.min.js",
                 "~/ Assets/client/js/owl.carousel.js",
                 "~/Assets/client/js/minicart.js",
                 "~/Assets/client/js/jquery.flexslider.js",
                 "~/Assets/client/js/move-top.js",
                 "~/Assets/client/js/common.js",
                 "~/Assets/signup/js/index.js",
                 "~/Assets/client/js/SmoothScroll.min.js"
                ));

            bundles.Add(new StyleBundle("~/css/base")
                .Include("~/Assets/client/css/bootstrap.css", new CssRewriteUrlTransform())
                .Include("~/Assets/client/font-awesome-4.6.3/css/font-awesome.css", new CssRewriteUrlTransform())
                .Include("~/Assets/admin/libs/jquery-ui/themes/smoothness/jquery-ui.min.css", new CssRewriteUrlTransform())
                .Include("~/Assets/client/css/style.css", new CssRewriteUrlTransform())
                .Include("~/Assets/client/css/custom.css", new CssRewriteUrlTransform())
                );
          //  BundleTable.EnableOptimizations = true;
        }
    }
}
