using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Selenium.Automation.Accelerators;

namespace ApplicationName.Automation.Tests
{
    [Script("Login", "Search","", "Smoke", "Validate Search")]
    class TC001_SearchForProduct : BaseTest
    {
        /// <summary>
        /// 
        /// </summary>
        protected override void ExecuteTestCase()
        {
            Reporter.Add(new Chapter("The test case checks if an user can login to Homesite"));
            var pg_CommonPage = Page<Common>(Driver, TestDataNode, Reporter);
            var pg_LoginPage = Page<HomeSiteLogin>(Driver, TestDataNode, Reporter);
            Step = "Launch the application";
            pg_CommonPage.LaunchApplication();
            Step = "Login to OLS";
            pg_LoginPage.Login(TestDataNode.SelectSingleNode("UserName").InnerText, TestDataNode.SelectSingleNode("Password").InnerText);
            Step = "Validate Search functionality";
            pg_LoginPage.Search();
            Step = "Logout of OLS";
        }
    }
}