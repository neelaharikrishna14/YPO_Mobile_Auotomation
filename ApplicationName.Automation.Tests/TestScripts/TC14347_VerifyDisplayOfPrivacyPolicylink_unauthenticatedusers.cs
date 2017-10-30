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
    [Script("Iteration_2", "US5446-Privacy Policy- Link for unauthenticated users", "", "Mobile", "iOS_Verify the Display Of -Privacy Policy- Link in Lgoin Screen for unauthenticated users")]
    class TC14347_VerifyDisplayOfPrivacyPolicylink_unauthenticatedusers : BaseTest
    {
        
        protected override void ExecuteTestCase()
        {
            Reporter.Add(new Chapter("To verify the display of Privacy Policy link on the login screen."));
            var pg_LoginPage = Page<HomeSiteLogin>(Driver,TestDataNode, Reporter);
            Step = "Launch the YPO application";
            Thread.Sleep(1000);
            Step = "Verify the Display Of -Privacy Policy- Link for unauthenticated users";
            pg_LoginPage.VerifyPrivacyPolicy();


        }



    }
}
