using System;
using System.Collections.Generic;
using System.Configuration;
using System.Xml;
using OpenQA.Selenium.Remote;
using Selenium.Automation.Accelerators;
using System.Collections.ObjectModel;
using OpenQA.Selenium;

namespace ApplicationName.Automation
{
    /// <summary>
    /// Description of MyClass.
    /// </summary>
    public class Common : BasePage    {

        #region Constructor
        public Common()
        {

        }

        public Common(RemoteWebDriver _Driver)
        {
            this.Driver = _Driver;
        }

        public Common(XmlNode _testNode)
        {
            this.TestDataNode = _testNode;
        }

        public Common(RemoteWebDriver _Driver, XmlNode _testNode)
        {
            this.Driver = _Driver;
            this.TestDataNode = _testNode;
        }

        public Common(RemoteWebDriver _Driver, XmlNode _testNode, Iteration iteration)
        {
            this.Driver = _Driver;
            this.TestDataNode = _testNode;
            this.Reporter = iteration;
        }
        #endregion
                
        /// <summary>
        /// Navigates page to specific location
        /// </summary>
        /// <param name="Driver">Initialized RemoteWebDriver instance</param>
        /// <param name="location">Location to navigate</param>
        public bool LaunchApplication()
        {
            bool isSuccess = false;
            try
            {
                string strURLValue = Util.EnvironmentSettings["Server"];
                Reporter.Add(new Act("Navigate to the URL '" + strURLValue + "'"));
                NavigateToURL(strURLValue);
                CheckStringContains(Reporter, GetBrowserCurrentURL(3), strURLValue);
                isSuccess = true;
            }
            catch (Exception ex)
            {
               
                throw new Exception(ex.Message);
            }
            return isSuccess;
        }

        public void CloseApplication()
        {
            try
            {
                if (Driver != null)
                {
                    Driver.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }        
        
    }
}