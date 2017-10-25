using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Selenium.Automation.Accelerators;


namespace ApplicationName.Automation.Tests.TestScripts
{
    [Script("Login", "Cancel FAQ", "", "Mobile", "Validate Header Search and Cancel FAQ")]
    class TC001_CancelFAQ : BaseTest
    {
        protected override void ExecuteTestCase()
        {
            Reporter.Add(new Chapter("Validate Header Search and Cancel FAQ"));
            var pg_CommonPage = Page<Common>(Driver, TestDataNode, Reporter);
            var pg_LoginPage = Page<HomeSiteLogin>(Driver, TestDataNode, Reporter);
            pg_LoginPage.Login(TestDataNode.SelectSingleNode("UserName").InnerText, TestDataNode.SelectSingleNode("Password").InnerText);
            // var pg_claims = Page<Claims>(Driver, TestDataNode, Reporter);
            /*    Step = "Launch the application";
          pg_CommonPage.LaunchApplication();
    Step = "Login to OLS";
          pg_LoginPage.Login(TestDataNode.SelectSingleNode("UserName").InnerText, TestDataNode.SelectSingleNode("Password").InnerText);
         //  Step = "Navigate to Claims Center and validate if user can create a new claim";
         //  pg_LoginPage.Claims();
          Step = "Validate Search functionality";
          pg_LoginPage.Search();
          //Step = "Validate Cancel FAQ, if user is able to submit ticket";
         // pg_LoginPage.CancelFAQ();
          Step = "Logout of OLS";
          pg_LoginPage.LogOut();*/

        }

    }
}
