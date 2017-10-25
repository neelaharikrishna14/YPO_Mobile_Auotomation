using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using OpenQA.Selenium;


namespace Selenium.Automation.Accelerators
{    
    public class Locator
    {
        private XmlDocument ObjectsLocators;
        private XmlNode pageObjectsLocators;
        private string pageName,browser;
        public Locator(string pageName)
        {
            this.pageName = pageName;
        }

        public string Browser
        {
            set
            {
                browser = value;
            }
            get
            {
                return browser;
            }
        }
        public By GetLocator(string ObjectName,string objectIncrementalId="")
        {
            By locator=null;
            XmlNode objectLocatorNode = null;
            string locatorValue = "";
            if(ObjectsLocators==null)
            {
                ObjectsLocators = Util.ReadXmlDocData("PageObjects.xml");
            }
            if(pageObjectsLocators==null)
            {
                pageObjectsLocators = ObjectsLocators.SelectSingleNode(".//Page[@name='"+pageName+"']");
            }

            //objectLocatorNode = pageObjectsLocators.SelectSingleNode("//Object[@name='" + ObjectName + "' and contains(@browsers,'" + browser + "')]");
            objectLocatorNode = pageObjectsLocators.SelectSingleNode(".//Object[@name='" + ObjectName + "']/Browser[contains(@value,'" + browser + "')]");
            if (objectLocatorNode != null)
            {
                locatorValue = objectLocatorNode.SelectSingleNode("Value").InnerText.Replace("&lt;", "<");
                if(objectIncrementalId!="")
                {
                    locatorValue = locatorValue.Replace("$", objectIncrementalId);
                }
                switch (objectLocatorNode.SelectSingleNode("Findby").InnerText.Trim())
                {
                    case "Id":
                            locator = By.Id(locatorValue);
                        break;
                    case "XPath":
                        locator = By.XPath(locatorValue);
                        break;
                    case "Name":
                        locator = By.Name(locatorValue);
                        break;
                }
            }
            return locator;
        }
    }
}
