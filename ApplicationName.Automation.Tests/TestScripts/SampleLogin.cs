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
    [Script("Iteration_2", "", "", "Mobile", "Validating Sign In")]
    class SampleLogin : BaseTest
    {
        //public IOSDriver<IOSElement> driver;
        protected override void ExecuteTestCase()
        {
           
            Reporter.Add(new Chapter("Validating Sign In"));
            var pg_CommonPage = Page<Common>(Driver, TestDataNode, Reporter);
            var pg_LoginPage = Page<HomeSiteLogin>(Driver, TestDataNode, Reporter);
            // var pg_claims = Page<Claims>(Driver, TestDataNode, Reporter);

            Step = "Enter username";
            Reporter.Add(new Act("Validate user name"));
            Driver.FindElement(By.XPath("xpath=//*[@class='UIATextField']")).Click();
            Reporter.Add(new Act("Enter user name"));
            Driver.FindElement(By.XPath("xpath=//*[@class='UIATextField']")).SendKeys("Umanath_bhat");
            Driver.FindElement(By.XPath("xpath=(//*[@class='UIAView' and ./parent::*[@class='UIAScrollView']]/*[@class='UIAView'])[2]")).SendKeys("ypot3st");
            Driver.FindElement(By.XPath("xpath=//*[@text='Sign In']")).Click();
            Thread.Sleep(5000);
            string text1 = Driver.FindElement(By.XPath("//*[@text='Directory']']")).GetAttribute("value");
            Console.WriteLine(text1);

        }



    }
}
