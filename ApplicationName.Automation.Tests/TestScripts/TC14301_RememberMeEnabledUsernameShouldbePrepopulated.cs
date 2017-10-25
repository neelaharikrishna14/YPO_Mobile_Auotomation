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
    [Script("Iteration_2", "US5403 -  Remember Me", "", "Mobile", "iOS_Login Screen_Remember Me option ON_Username should be prepopulated")]
    class TC14301_RememberMeEnabledUsernameShouldbePrepopulated : BaseTest
    {
        
        protected override void ExecuteTestCase()
        {
            Reporter.Add(new Chapter("Verify that whether the application save the username used in the last successful login,when the Remember Me setting is ON"));
            var pg_LoginPage = Page<HomeSiteLogin>(Driver,TestDataNode, Reporter);
            Step = "Launch the YPO application";
            Step = "Click on Remember Me buuton";
            pg_LoginPage.ClickonRemememberMe();
            Step = "Verify the Remember me option is ON";
            pg_LoginPage.VerifyRemememberMe(TestDataNode.SelectSingleNode("ExpectedStatus").InnerText);
            Step = "Login to YPO";
            pg_LoginPage.Login(TestDataNode.SelectSingleNode("UserName").InnerText, TestDataNode.SelectSingleNode("Password").InnerText);
            Step = "wait for Logged out the YPO Application";
            Thread.Sleep(65000);
            Step = "Logged out";
            Driver.Quit();
            Thread.Sleep(1000);
            Step = "Re-Launch the YPO application";
            DesiredCapabilities dc = new DesiredCapabilities();
            dc.SetCapability(IOSMobileCapabilityType.BundleId, "com.ypo.connect.qa");
            Driver = new IOSDriver<IOSElement>(new Uri("http://localhost:4723/wd/hub"), dc);
            Step = "Re-Launched sussessfully";
            Step = "Username should be prepopulated";
           //string s= pg_LoginPage.GetObjectAttributeValue(HomeSiteLogin.txt_UserId, "text");

        }



    }
}
