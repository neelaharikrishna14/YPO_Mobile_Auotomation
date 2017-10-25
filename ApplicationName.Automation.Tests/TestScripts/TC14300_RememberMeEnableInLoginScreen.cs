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
    [Script("Iteration_2", "US5403 -  Remember Me", "", "Mobile", "Verify that the member is able to enable Remember Me option")]
    class TC14300_RememberMeEnableInLoginScreen : BaseTest
    {
        
             protected override void ExecuteTestCase()
        {

            Reporter.Add(new Chapter("Verify that the member is able to enable Remember Me option on the login screen"));
            var pg_LoginPage = Page<HomeSiteLogin>(Driver, TestDataNode, Reporter);
            Step = "Launch the YPO application";
            Step = "Click on Remember Me buuton";
            pg_LoginPage.ClickonRemememberMe();
            Step = "Verify the Remember me option is ON";
            pg_LoginPage.VerifyRemememberMe(TestDataNode.SelectSingleNode("ExpectedStatus").InnerText);

        }

}
}
