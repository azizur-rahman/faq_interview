using System.Web.Optimization;

namespace FAQ.Interview
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            //bundles.Add(new ScriptBundle("~/scripts/bundles").Include(
            //          "~/Scripts/common.js"));

            bundles.Add(new StyleBundle("~/Styles/Site").Include(
                      "~/Styles/layout.css"));
        }
    }
}
