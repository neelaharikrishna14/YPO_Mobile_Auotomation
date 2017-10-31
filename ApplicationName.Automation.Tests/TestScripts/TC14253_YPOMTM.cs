using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Selenium.Automation.Accelerators;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.iOS;
using NUnit;
using NUnit.Framework;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Support.UI;
using System.Threading;




namespace ApplicationName.Automation.Tests.TestScripts
{
    [Script("Iteration_2", "US5344 - SignIn with user credentials", "", "Mobile", "Different types of YPO members are able to log in to YPO app")]
    class TC14253_YPOMTM : BaseTest
    {
        //public IOSDriver<IOSElement> driver;
        protected override void ExecuteTestCase()
        {

            Reporter.Add(new Chapter("Validating Sign In"));
            var pg_CommonPage = Page<Common>(Driver, TestDataNode, Reporter);
            var pg_LoginPage = Page<HomeSiteLogin>(Driver, TestDataNode, Reporter);

         Step = "Login with YPO_member";
         pg_LoginPage.Login(TestDataNode.SelectSingleNode("YPOMTM").InnerText, TestDataNode.SelectSingleNode("Password").InnerText);
         Step = "Wait for Directory Page";
        pg_LoginPage.WaitforDirectorypage();


        }



    }
}
