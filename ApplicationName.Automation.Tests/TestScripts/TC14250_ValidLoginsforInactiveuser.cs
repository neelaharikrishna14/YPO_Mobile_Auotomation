﻿using System;
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
    [Script("Iteration_2", "US5344 - SignIn with user credentials", "", "Mobile", "Error message displayed when valid credentials of inactive user are provided")]
    class TC14250_ValidLoginsforInactiveuser : BaseTest
    {
        //public IOSDriver<IOSElement> driver;
        protected override void ExecuteTestCase()
        {


            Reporter.Add(new Chapter("Validating Sign In"));
            var pg_LoginPage = Page<HomeSiteLogin>(Driver, TestDataNode, Reporter);

            Step = "Usernamefield_pre_populatedifRemembermeisturnedON";
            pg_LoginPage.InactiveUser(TestDataNode.SelectSingleNode("UserName").InnerText, TestDataNode.SelectSingleNode("Password").InnerText);

        }



    }
}
