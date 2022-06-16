using System;
using System.Web.Mvc;

namespace FAQ.Interview
{
    public abstract class BaseWebViewPage : WebViewPage
    {
        public DateTime UserTimezoneNow { get; set; }
        public override void InitHelpers()
        {
            base.InitHelpers();
        }
    }

    public abstract class BaseWebViewPage<TModel> : WebViewPage<TModel>
    {
        public DateTime UserTimezoneNow { get; set; }

        public override void InitHelpers()
        {
            base.InitHelpers();
        
        }
    }
}


