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
    [Script("Iteration_2", "US5419-Privacy Policy- Link", "", "Mobile", "iOS_Verify the Display Of -Privacy Policy- Link in Lgoin Screen")]
    class TC14245_VerifyDisplayOfPrivacyPolicylink : BaseTest
    {
        
        protected override void ExecuteTestCase()
        {
            Reporter.Add(new Chapter("To verify the display of Privacy Policy link on the login screen."));
            var pg_LoginPage = Page<HomeSiteLogin>(Driver,TestDataNode, Reporter);
            Step = "Launch the YPO application";
            Thread.Sleep(1000);
            Step = "Verify the Display Of -Privacy Policy- Link";
            pg_LoginPage.VerifyPrivacyPolicy();


        }



    }
}
