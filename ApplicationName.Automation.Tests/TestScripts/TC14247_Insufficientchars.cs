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
    [Script("Iteration_2", "US5344 - SignIn with user credentials", "", "Mobile", "Sign-in button should be disabled until 3 characters for username and 10 characters for password are provided")]
    class TC14247_Insufficientchars : BaseTest
    {


        //public IOSDriver<IOSElement> driver;
       
        protected override void ExecuteTestCase()
        {

            Reporter.Add(new Chapter("Validating Sign In"));
            var pg_LoginPage = Page<HomeSiteLogin>(Driver, TestDataNode, Reporter);

            Step = "Enter 2 characters in username field and 7 characters in password field";
            pg_LoginPage.Insufficientchars27(TestDataNode.SelectSingleNode("UserName").InnerText, TestDataNode.SelectSingleNode("Password").InnerText);
            Step = "Enter 3 characters in username field and 6 characters in password field";
            pg_LoginPage.Insufficientchars36(TestDataNode.SelectSingleNode("UserName1").InnerText, TestDataNode.SelectSingleNode("Password1").InnerText);
            Step = "Enter 3 characters in username field and 7 characters in password field";
            pg_LoginPage.Insufficientchars37(TestDataNode.SelectSingleNode("UserName2").InnerText, TestDataNode.SelectSingleNode("Password2").InnerText);

        }
        
    }
}
