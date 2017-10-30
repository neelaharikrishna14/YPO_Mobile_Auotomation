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
    [Script("Iteration_2", "US5446-Terms Of Use- Link for unauthenticated users", "", "Mobile", "iOS_Terms of Use link displayed on Login screen for unauthenticated users")]
    class TC14345_VerifydisplayofTermsofUselink_unauthenticatedusers : BaseTest
    {
        
        protected override void ExecuteTestCase()
        {
            Reporter.Add(new Chapter("To verify the display of Terms of Use link on the login screen for unauthenticated users"));
            var pg_LoginPage = Page<HomeSiteLogin>(Driver,TestDataNode, Reporter);
            Step = "Launch the YPO application";
            Thread.Sleep(1000);
            Step = "Verify the Display Of -Terms Of Use- Link";
            pg_LoginPage.VerifyTermsofUseLink();


        }



    }
}
