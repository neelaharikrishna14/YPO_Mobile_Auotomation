﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Selenium.Automation.Accelerators;

namespace ApplicationName.Automation.Tests.TestScripts
{
    [Script("Claims", "Claim Center", "", "Mobile", "Validate Claim Center")]
    public class TC004_ClaimCenter : BaseTest
    {
        protected override void ExecuteTestCase()
        {
            Reporter.Add(new Chapter("The test case checks if an user can login to Homesite"));
            var pg_CommonPage = Page<Common>(Driver, TestDataNode, Reporter);
            var pg_LoginPage = Page<HomeSiteLogin>(Driver, TestDataNode, Reporter);
           // var pg_claims = Page<Claims>(Driver, TestDataNode, Reporter);
            Step = "Launch the application";
            pg_CommonPage.LaunchApplication();
            Step = "Login to OLS";
            pg_LoginPage.Login(TestDataNode.SelectSingleNode("UserName").InnerText, TestDataNode.SelectSingleNode("Password").InnerText);
            Step = "Navigate to Claims Center and validate if user can create a new claim";
            pg_LoginPage.Claims();
            //Step = "Validate Search functionality";
            //pg_LoginPage.Search();
            //Step = "Validate Cancel FAQ, if user is able to submit ticket";
            //pg_LoginPage.CancelFAQ();
            Step = "Logout of OLS";
            pg_LoginPage.LogOut(); 

         }
    }
}
