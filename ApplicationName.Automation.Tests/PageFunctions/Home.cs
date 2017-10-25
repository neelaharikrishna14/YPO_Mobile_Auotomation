using System;
using System.Xml;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using Selenium.Automation.Accelerators;
using OpenQA.Selenium.Interactions;
using System.Collections.Generic;

namespace ApplicationName.Automation
{
    public class Home : BasePage
    {
        #region Constructor
        private Locator Locator = new Locator(ApplicationPages.Home.ToString());
        BrowserTypes pageBrowserType;

        public Home()
        {

        }

        public Home(RemoteWebDriver _Driver)
        {
            this.Driver = _Driver;
        }

        public Home(XmlNode _testNode)
        {
            this.TestDataNode = _testNode;
        }

        public Home(RemoteWebDriver _Driver, XmlNode _testNode)
        {
            this.Driver = _Driver;
            this.TestDataNode = _testNode;
        }

        public Home(RemoteWebDriver _Driver, XmlNode _testNode, Iteration iteration)
        {
            this.Driver = _Driver;
            this.TestDataNode = _testNode;
            this.Reporter = iteration;
            this.Browser = iteration.Browser.Title;
            Locator.Browser = iteration.Browser.Title;
            pageBrowserType = AppCommon.GetPageBrowserType(this.Browser);
        }

        #endregion

        #region ObjectRepository

        By txt_Searchbox
        {
            get
            {
                return Locator.GetLocator("Search");
            }
        }

        By btn_Submit
        {
            get
            {
                return Locator.GetLocator("SubmitSearch");
            }
        }

        private By lnk_SearchResults(string searchValue)
        {
            return Locator.GetLocator("SearchResults", searchValue);
        }

        By btn_BuyNow
        {
            get
            {
                return Locator.GetLocator("BuyNow");
            }
        }

        #endregion

        #region PageFunctions

        public bool SearchProduct()
        {
            bool isSuccess = false;
            try
            {
                Reporter.Add(new Act(String.Format("Input search value as : '{0}' ", TestDataNode.SelectSingleNode("SearchValue").InnerText)));
                SetValueToObject(txt_Searchbox, TestDataNode.SelectSingleNode("SearchValue").InnerText);
                Reporter.Add(new Act(String.Format("Click on Search")));
                ClickOnObject(btn_Submit);
                isSuccess = true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return isSuccess;
        }

        public bool CheckResultsAndSelectOne()
        {
            bool isSuccess = false;
            try
            {
                Reporter.Add(new Act(String.Format("Select top one match from the search results")));
                ClickOnObject(lnk_SearchResults(TestDataNode.SelectSingleNode("SearchValue").InnerText));
                isSuccess = true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return isSuccess;
        }

        public bool BuyProduct()
        {
            bool isSuccess = false;
            try
            {
                Reporter.Add(new Act(String.Format("Click on Buy Now")));
                ClickOnObject(btn_BuyNow);
                isSuccess = true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return isSuccess;
        }

        #endregion

    }
}