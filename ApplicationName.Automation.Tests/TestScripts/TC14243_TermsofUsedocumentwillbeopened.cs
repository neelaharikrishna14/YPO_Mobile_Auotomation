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
    [Script("Iteration_2", "US5416-Terms Of Use- Link", "", "Mobile", "iOs_Terms of Use link_Opens in PDF viewer")]
    class TC14243_TermsofUsedocumentwillbeopened: BaseTest
    {
        
        protected override void ExecuteTestCase()
        {
            Reporter.Add(new Chapter("Verify that Terms of Use document will be opened in the device's default PDF viewer application"));
            var pg_LoginPage = Page<HomeSiteLogin>(Driver,TestDataNode, Reporter);
            Step = "Launch the YPO application";
            Thread.Sleep(1000);
            Step = "Verify the Display Of -Terms Of Use- Link";
            pg_LoginPage.VerifyTermsofUseLink();
            Step = "Click on -Terms Of Use- Link";
            pg_LoginPage.ClickonTermsofUseLink();
            Thread.Sleep(1000);
            Step = "Verify the -Terms Of Use- Link pdf is Opened";
            pg_LoginPage.VerifyDocumentLoadedOrNot();
        }



    }
}
