using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Threading.Tasks;
using System.Data;


namespace ApplicationName.Automation
{   
    public enum BrowserTypes
    {
        MobileBrowser,
        WebBrowser
    }

    public enum ApplicationPages
    {
        Home,
        SignIn,
        HomeSiteLogin
    }

    public static class AppCommon
    {
        public static BrowserTypes GetPageBrowserType(string executingBrowser)
        {

            if (executingBrowser == "Androidchrome")
            {
                return BrowserTypes.MobileBrowser;
            }
            else
            {
                return BrowserTypes.WebBrowser;
            }
        }
    }
}
