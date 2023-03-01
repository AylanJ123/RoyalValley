using System.Web;
using System.Web.Optimization;

namespace RoyaltyValley
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new Bundle("~/bundles/jquery").Include(
                "~/Scripts/jquery-3.6.3.js"
            ));
            bundles.Add(new Bundle("~/bundles/jqueryval").Include(
                "~/Scripts/jquery.validate"
            ));
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                "~/Scripts/modernizr-2.8.3"
            ));
            bundles.Add(new Bundle("~/bundles/bootstrap").IncludeDirectory("~/Scripts", "bootstrap*"));
            bundles.Add(new Bundle("~/bundles/css").IncludeDirectory("~/Content", "*.css"));
        }
    }
}
