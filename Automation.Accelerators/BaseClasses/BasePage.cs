#region namespaces
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Xml;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System.Data;
using System.Runtime.InteropServices;
using System.Configuration;


#endregion

namespace Selenium.Automation.Accelerators
{
    /// <summary>
    /// This is the Super class for all pages
    /// </summary>
    /// 
    public class BasePage
    {        
        /// <summary>
        /// Gets or Sets Driver
        /// </summary>
        protected RemoteWebDriver Driver { get; set; }



        protected String Browser { get; set; }        

        /// <summary>
        /// Gets or Sets Test Data as XMLNode
        /// </summary>
        protected XmlNode TestDataNode { get; set; }

        /// <summary>
        /// Gets or Sets Reporter
        /// </summary>
        protected Iteration Reporter { get; set; }

        private int _ElementSyncTimeOut;

        public int ElementSyncTimeOut
        {
            get
            {
                if(_ElementSyncTimeOut == 0)
                {
                    if (ConfigurationManager.AppSettings["ElementSyncTimeOut"] != null)
                        _ElementSyncTimeOut = Convert.ToInt32(ConfigurationManager.AppSettings.Get("ElementSyncTimeOut"));
                    else
                        _ElementSyncTimeOut = 0;
                }
                return _ElementSyncTimeOut;
            }

        }
               

        #region Constructor

        public BasePage()
        {

        }

        public BasePage(RemoteWebDriver driver)
        {
            this.Driver = driver;
        }

        public BasePage(String browser)
        {
            this.Browser = browser;
        }

        public BasePage(XmlNode testNode)
        {
            this.TestDataNode = testNode;
        }

        public BasePage(RemoteWebDriver driver, XmlNode testNode)
        {
            this.Driver = driver;
            this.TestDataNode = testNode;
        }

        #endregion

        #region ObjectRetrievalFunctions

        protected IWebElement GetNativeElement(By lookupBy, int maxWaitTime = 0)
        {
            IWebElement element = null;
            maxWaitTime = maxWaitTime > 0 ? maxWaitTime : ElementSyncTimeOut;
            try
            {
                for (int i = 0; i < maxWaitTime; i++)
                {
                    try
                    {
                        element = Driver.FindElement(lookupBy);
                        break;
                    }
                    catch
                    {
                        Thread.Sleep(1000);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            //if (element != null)
            //{
            //    try
            //    {
            //        string script = String.Format(@"arguments[0].style.cssText = ""border-width: 4px; border-style: solid; border-color: {0}"";", "orange");
            //        IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)Driver;
            //        jsExecutor.ExecuteScript(script, new object[] { element });
            //        //jsExecutor.ExecuteScript(String.Format(@"$(arguments[0].scrollIntoView(true));"), new object[] { element });
            //    }
            //    catch { }
            //}
            return element;
        }
        protected IList<IWebElement> GetNativeElements(By lookupBy, int maxWaitTime = 0)
        {
            IList<IWebElement> elements = null;
            maxWaitTime = maxWaitTime > 0 ? maxWaitTime : ElementSyncTimeOut;
            try
            {
                for (int i = 0; i < maxWaitTime; i++)
                {
                    try
                    {
                        elements = Driver.FindElements(lookupBy);
                        break;
                    }
                    catch
                    {
                        Thread.Sleep(1000);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return elements;
        }
        protected Boolean GetElementState(By lookupBy)
        {
            Boolean flag = false;
            try
            {
                flag = Driver.FindElement(lookupBy).Selected;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return flag;
        }



        protected Boolean GetElementStateclick(By lookupBy)
        {
            Boolean flag = false;
            try
            {
                flag = Driver.FindElement(lookupBy).Enabled;
                Boolean falg1 = Driver.FindElement(lookupBy).Enabled;
                if (flag == falg1)
                {
                    Console.WriteLine("SignIn disabled");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return flag;
        }





        protected IWebElement GetNativeElementInAElement(IWebElement parentElement, By lookupBy, int maxWaitTime = 0)
        {
            IWebElement element = null;
            maxWaitTime = maxWaitTime > 0 ? maxWaitTime : ElementSyncTimeOut;
            try
            {
                for (int i = 0; i < maxWaitTime; i++)
                {
                    try
                    {
                        element = parentElement.FindElement(lookupBy);
                    }
                    catch
                    {
                        Thread.Sleep(1000);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            //if (element != null)
            //{
            //    try
            //    {
            //        string script = String.Format(@"arguments[0].style.cssText = ""border-width: 2px; border-style: solid; border-color: {0}"";", "orange");
            //        IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)Driver;
            //        jsExecutor.ExecuteScript(script, new object[] { element });
            //        //jsExecutor.ExecuteScript(String.Format(@"$(arguments[0].scrollIntoView(true));"), new object[] { element });
            //    }
            //    catch { }
            //}
            return element;
        }
        protected IWebElement WaitForElementVisible(By lookupBy, int maxWaitTime = 0)
        {
            IWebElement element = null;
            maxWaitTime = maxWaitTime > 0 ? maxWaitTime : ElementSyncTimeOut;
            try
            {               
                element = new WebDriverWait(Driver, TimeSpan.FromSeconds(maxWaitTime)).Until(ExpectedConditions.ElementIsVisible(lookupBy));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException.Message);
            }
            //if (element != null)
            //{
            //    try
            //    {
            //        //string script = String.Format(@"arguments[0].style.cssText = ""border-width: 4px; border-style: solid; border-color: {0}"";", "orange");
            //        //IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)Driver;
            //        //jsExecutor.ExecuteScript(script, new object[] { element });
            //        //jsExecutor.ExecuteScript(String.Format(@"$(arguments[0].scrollIntoView(true));"), new object[] { element });
            //    }
            //    catch { }
            //}
            return element;
        }       
        protected bool WaitForElementInVisibleByText(By lookupBy,string textValue, int maxWaitTime = 0)
        {          
            maxWaitTime = maxWaitTime > 0 ? maxWaitTime : ElementSyncTimeOut;
            try
            {
                return new WebDriverWait(Driver, TimeSpan.FromSeconds(maxWaitTime)).Until(ExpectedConditions.InvisibilityOfElementWithText(lookupBy, textValue));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException.Message);
            }    
        }
        protected IWebElement WaitForElementClickable(By lookupBy, int maxWaitTime = 0)
        {
            IWebElement element = null;
            maxWaitTime = maxWaitTime > 0 ? maxWaitTime : ElementSyncTimeOut;
            try
            {               
                element = new WebDriverWait(Driver, TimeSpan.FromSeconds(maxWaitTime)).Until(ExpectedConditions.ElementToBeClickable(lookupBy));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException.Message);
            }           
            return element;
        }
        internal IList<IWebElement> GetNativeElementsInAElement(IWebElement parentElement, By lookupBy, int maxWaitTime = 0)
        {
            IList<IWebElement> element = null;
            maxWaitTime = maxWaitTime > 0 ? maxWaitTime : ElementSyncTimeOut;
            try
            {
                for (int i = 0; i < maxWaitTime; i++)
                {
                    try
                    {
                        element = parentElement.FindElements(lookupBy);
                    }
                    catch
                    {
                        Thread.Sleep(1000);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return element;
        }
        protected IWebElement gfn_GetSpecifiedWebElement(By locateBy, string expValue, int maxWaitTime = 0)
        {
            ICollection<IWebElement> rows = null;
            ICollection<IWebElement> cells = null;
            IWebElement table = null;
            IWebElement specifiedRow = null;
            maxWaitTime = maxWaitTime > 0 ? maxWaitTime : ElementSyncTimeOut;
            try
            {
                table = GetNativeElement(locateBy);
                rows = GetNativeElementsInAElement(table, By.TagName("tr"));
                IWebElement currentRow = gfn_GetFirstElementFromTable(rows);
                int columnCount = gfn_GetFirstElementFromTable(rows).FindElements(By.TagName("th")).Count;
                int columns = 0;

                foreach (var row in rows)
                {
                    cells = row.FindElements(By.TagName("td"));
                    IEnumerator<IWebElement> tableCells = cells.GetEnumerator();
                    while (tableCells.MoveNext())
                    {
                        if (expValue.Equals(tableCells.Current.Text.ToString()))
                        {
                            specifiedRow = row;
                            return specifiedRow;
                        }
                        columns++;
                    }

                    columns = 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return specifiedRow;
        }
        #endregion

        #region ObjectOperationFunctions

        protected void ClickOnObject(IWebElement element)
        { 
            try
            {              
                if (element != null)
                {
                    ScrollElementToView(element);                    
                    //element.Click();
                    ClickUsingJavascript(element);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        protected void ClickOnObject(By lookupBy, int maxWaitTime = 0)
        {
            IWebElement element = null;
            maxWaitTime = maxWaitTime > 0 ? maxWaitTime : ElementSyncTimeOut;
            try
            {
                //element = WaitForElementVisible(lookupBy, maxWaitTime);
                element = WaitForElementClickable(lookupBy, maxWaitTime);
                if (element != null)
                {
                    if (Browser == "IE" || Browser == "Internet Explorer")
                    {
                        ClickUsingJavascript(element);
                    }
                    else
                    {
                        element.Click();      
                    }                                  
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        protected void DoubleClickOnObject(By lookupBy, int maxWaitTime = 0)
        {
            IWebElement element = null;
            maxWaitTime = maxWaitTime > 0 ? maxWaitTime : ElementSyncTimeOut;
            try
            {
                element = WaitForElementVisible(lookupBy, maxWaitTime);
                if (element != null)
                {
                    Actions action = new Actions(Driver);
                    action.DoubleClick(element).Build().Perform();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        protected void ClickOnHiddenObject(By lookupBy, int maxWaitTime = 0)
        {
            IWebElement element = null;
            maxWaitTime = maxWaitTime > 0 ? maxWaitTime : ElementSyncTimeOut;
            try
            {
                element = GetNativeElement(lookupBy, maxWaitTime);
                if (element != null)
                {
                    element.Click();
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        protected void ClickUsingJavascript(IWebElement element)
        {
            try
            {
                IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)Driver;
                jsExecutor.ExecuteScript("arguments[0].click();", element);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        protected void SetValueToObject(By lookupBy, string strInputValue, int maxWaitTime = 0)
        {
            IWebElement element = null;
            
            maxWaitTime = maxWaitTime > 0 ? maxWaitTime : ElementSyncTimeOut;
            try
            {
                element = WaitForElementVisible(lookupBy, maxWaitTime);
                if (element != null)
                {
                    //element.SendKeys(Keys.Control + "a");
                   // element.SendKeys(Keys.Delete);
                    element.SendKeys(strInputValue);   
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        protected void PressEnter(By lookupBy, int maxWaitTime = 0)
        {
            IWebElement element = null;
            maxWaitTime = maxWaitTime > 0 ? maxWaitTime : ElementSyncTimeOut;
            try
            {
                element = WaitForElementVisible(lookupBy, maxWaitTime);
                if (element != null)
                {
                    element.SendKeys(Keys.Enter);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        protected void SelectValueInDropdown(By lookupBy, string strInputValue, string selectBy = "text", int maxWaitTime = 60)
        {
            IWebElement element = null;
            try
            {
                element = WaitForElementVisible(lookupBy, maxWaitTime);
                if (element != null)
                {
                    SelectElement dropDownElement = new SelectElement(element);
                    //int count = 1;
                    ////Raghu: Try for three times to make sure we have selected 'strInputValue' value.
                    //while (dropDownElement.SelectedOption.Text != strInputValue)
                    //{
                        switch (selectBy.ToLower())
                        {
                            case "text": dropDownElement.SelectByText(strInputValue); break;
                            case "index": dropDownElement.SelectByIndex(Int32.Parse(strInputValue)); break;
                            case "value": dropDownElement.SelectByValue(strInputValue); break;
                            default: dropDownElement.SelectByText(strInputValue); break;
                        }
                        //if (count++ == 3)
                        //{
                        //    throw new Exception(string.Format("Could not select {0}. No.of tries {1}", strInputValue, count));
                        //}
                        //Thread.Sleep(1500);
                    }
                }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        protected IList<IWebElement> GetDropdownValues(By lookupBy, int maxWaitTime = 0)
        {
            IWebElement element = null;
            IList<IWebElement> strValues = new List<IWebElement>();
            maxWaitTime = maxWaitTime > 0 ? maxWaitTime : ElementSyncTimeOut;
            try
            {
                element = WaitForElementVisible(lookupBy, maxWaitTime);
                if (element != null)
                {
                    SelectElement dropDownElement = new SelectElement(element);
                    strValues = dropDownElement.Options;
                }
                return strValues;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        protected string GetDropdownSelectedValue(By lookupBy, int maxWaitTime = 0)
        {
            IWebElement element = null;
            string strValue = "";
            maxWaitTime = maxWaitTime > 0 ? maxWaitTime : ElementSyncTimeOut;
            try
            {
                element = WaitForElementVisible(lookupBy, maxWaitTime);
                if (element != null)
                {
                    SelectElement dropDownElement = new SelectElement(element);
                    strValue = dropDownElement.SelectedOption.Text;
                }
                return strValue;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        protected void ClearObjectValue(By lookupBy, int maxWaitTime = 0)
        {
            IWebElement element = null;
            maxWaitTime = maxWaitTime > 0 ? maxWaitTime : ElementSyncTimeOut;
            try
            {
                element = WaitForElementVisible(lookupBy, maxWaitTime);
                if (element != null)
                {
                    element.Clear();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        protected bool ValidateObjectAttributeValue(By lookupBy, string strAttributeName, string strExpectedValue, int maxWaitTime = 0)
        {
            bool valueEquals = false;
            IWebElement element = null;
            maxWaitTime = maxWaitTime > 0 ? maxWaitTime : ElementSyncTimeOut;
            try
            {
                element = WaitForElementVisible(lookupBy, maxWaitTime);
                if (element != null)
                {
                    valueEquals = string.Equals(element.GetAttribute(strAttributeName).Trim().ToLower(), strExpectedValue.ToLower());
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return valueEquals;
        }
        protected string GetObjectAttributeValue(By lookupBy, string strAttributeName, int maxWaitTime = 0)
        {
            string returnValue = string.Empty;
            IWebElement element = null;
            maxWaitTime = maxWaitTime > 0 ? maxWaitTime : ElementSyncTimeOut;
            try
            {
                element = WaitForElementVisible(lookupBy, maxWaitTime);
                if (element != null)
                {
                    if (strAttributeName.ToLower().Equals("text"))
                    {
                        return element.Text;
                    }
                    else
                    {
                        returnValue = element.GetAttribute(strAttributeName);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return returnValue;
        }
        protected bool IsObjectSelected(By lookupBy, int maxWaitTime = 0)
        {
            bool valueEquals = false;
            IWebElement element = null;
            maxWaitTime = maxWaitTime > 0 ? maxWaitTime : ElementSyncTimeOut;
            try
            {
                element = WaitForElementVisible(lookupBy, maxWaitTime);
                if (element != null)
                {
                    valueEquals = element.Selected;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return valueEquals;
        }
        protected void MouseOverOnObject(By lookupBy, int maxWaitTime = 0)
        {
            IWebElement element = null;
            maxWaitTime = maxWaitTime > 0 ? maxWaitTime : ElementSyncTimeOut;
            try
            {
                element = WaitForElementVisible(lookupBy, maxWaitTime);
                if (element != null)
                {
                    new Actions(Driver).MoveToElement(element).Perform();
                    Thread.Sleep(1000);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        protected void MoveToObject(By lookupBy, int int_offSetX, int int_offSetY, int maxWaitTime = 0)
        {
            IWebElement element = null;
            maxWaitTime = maxWaitTime > 0 ? maxWaitTime : ElementSyncTimeOut;
            try
            {
                element = WaitForElementVisible(lookupBy, maxWaitTime);
                if (element != null)
                {
                    new Actions(Driver).MoveToElement(element, int_offSetX, int_offSetY).Perform();
                    Thread.Sleep(500);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        protected void MoveObjectInSlider(By lookupBy, int minValue, int maxValue, int setValue, string replaceValue="", int maxWaitTime = 0)
        {
            IWebElement element = null;
            maxWaitTime = maxWaitTime > 0 ? maxWaitTime : ElementSyncTimeOut;
            try
            {
                element = WaitForElementVisible(lookupBy, maxWaitTime);
                if (element != null)
                {
                    int startPointY = element.Location.Y;
                    string displayedValue = element.GetAttribute("text").Trim().Replace(replaceValue, "");
                    Actions ac = new Actions(Driver);
                    ac.ClickAndHold(element);
                    while (Convert.ToInt16(displayedValue) < Convert.ToInt16(setValue) && Convert.ToInt16(displayedValue) < Convert.ToInt16(maxValue))
                    {
                        ac.MoveByOffset(1, startPointY);
                        ac.Perform();
                        Thread.Sleep(100);
                        displayedValue = element.GetAttribute("text").Trim().Replace(replaceValue, "");
                    }
                    ac.Release();
                    ac.Perform();                   
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        protected void MoveToObjectAndClick(By lookupBy, int int_offSetX, int int_offSetY, int maxWaitTime = 0)
        {
            IWebElement element = null;
            maxWaitTime = maxWaitTime > 0 ? maxWaitTime : ElementSyncTimeOut;
            try
            {
                element = WaitForElementVisible(lookupBy, maxWaitTime);
                if (element != null)
                {
                    MoveToObject(lookupBy, int_offSetX, int_offSetY);
                    new Actions(Driver).Click().Perform();
                    Thread.Sleep(500);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        protected bool CheckIfObjectExists(By lookupBy, int maxWaitTime = 0)
        {
            IWebElement element = null;
            maxWaitTime = maxWaitTime > 0 ? maxWaitTime : ElementSyncTimeOut;
            try
            {
                element = WaitForElementVisible(lookupBy, maxWaitTime);
                if (element != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        protected Size GetObjectSize(By lookupBy, int maxWaitTime = 0)
        {
            Size elementSize = new Size();
            IWebElement element = null;
            maxWaitTime = maxWaitTime > 0 ? maxWaitTime : ElementSyncTimeOut;
            try
            {
                element = WaitForElementVisible(lookupBy, maxWaitTime);
                if (element != null)
                {
                    elementSize = element.Size;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return elementSize;
        }
        protected void ValidateLink(By lookup, string pageName, bool switchWindow)
        {
            bool flag = true;
           // ClickOnObject(lookup);
           // WaitForPageLoad();

            string getWindow = Driver.CurrentWindowHandle;
            IList<String> tab = new List<String>(Driver.WindowHandles);
            foreach (String tab_new in tab)
            {
                Driver.SwitchTo().Window(tab_new);
                if (GetBrowserCurrentURL(5).Contains(pageName))
                {
                    if (flag)
                    {
                        CheckStringContains(Reporter, GetBrowserCurrentURL(5), pageName);
                        Driver.Close();
                        flag = false;
                    }
                    else
                        Driver.Close();
                }
                else
                    continue;
            }
            Driver.SwitchTo().Window(getWindow);
            //if (swithWindow)
            //{
            //    string getWindow = Driver.CurrentWindowHandle;
            //    IList<String> windows = new List<String>(Driver.WindowHandles);
            //    foreach (var window in windows)
            //    {
            //        Driver.SwitchTo().Window(window);
            //    }
            //    checkStringContains(Reporter, retrieveCurrentBrowserURL().ToLower(), pageName.ToLower());
            //    Reporter.Add(new Act(pageName + " page is displayed"));
            //    Driver.Close();
            //    Driver.SwitchTo().Window(getWindow);
            //}
            //else
            //{
            //    checkStringContains(Reporter, retrieveCurrentBrowserURL(), pageName);
            //    Reporter.Add(new Act(pageName + " page is displayed"));
            //}
        }

        #endregion

        #region GenericFunctions

        protected void NavigateToURL(string url)
        {
            try
            {
                Driver.Navigate().GoToUrl(url);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        protected string GetBrowserCurrentURL(int maxWaitTime = 0)
        {
            maxWaitTime = maxWaitTime > 0 ? maxWaitTime : ElementSyncTimeOut;
            try
            {
                Thread.Sleep(maxWaitTime * 1000);
                return Driver.Url;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        protected void SwitchToObject(By lookupBy, int maxWaitTime)
        {
            IWebElement element = null;
            try
            {
                element = WaitForElementVisible(lookupBy, maxWaitTime);
                if (element != null)
                {
                    Driver.SwitchTo().Frame(element);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        protected void SwitchToIFrame(By lookupBy, int maxWaitTime = 0)
        {
            IWebElement element = null;
            maxWaitTime = maxWaitTime > 0 ? maxWaitTime : ElementSyncTimeOut;
            try
            {

                element = GetNativeElement(lookupBy, maxWaitTime);
                if (element != null)
                {
                    IWebElement webElement = GetNativeElementInAElement(element, By.TagName("iframe"));

                    Driver.SwitchTo().Frame(webElement);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        protected void SwitchToWindow(String windowTitle)
        {
            try
            {
                IList<String> tab = new List<String>(Driver.WindowHandles);
                foreach (String window in tab)
                {
                    //Driver.SwitchTo().Window(window);
                    if (Driver.Title.Contains(windowTitle))
                    {
                        Driver.SwitchTo().Window(window);
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        protected void SwitchToDefaultContent()
        {
            try
            {
                Driver.SwitchTo().DefaultContent();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        protected string GetCurrentWindowTitle()
        {     
            try
            {
                return Driver.Title;               
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        protected void WaitForPageLoad(int maxWaitTime = 0)
        {
            maxWaitTime = maxWaitTime > 0 ? maxWaitTime : ElementSyncTimeOut;
            try
            {
                bool objAvailable = false;
                bool visible = true;
                WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(maxWaitTime));
                IJavaScriptExecutor javascript = Driver as IJavaScriptExecutor;
                if (javascript == null)
                    throw new ArgumentException("Driver", "Driver not supports javascript execution");
                objAvailable = wait.Until((d) =>
                {
                    try
                    {
                        string readyState = javascript.ExecuteScript(
                            "if (document.readyState) return document.readyState;").ToString();
                        return readyState.ToLower() == "complete";
                    }

                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                });
                if (Driver.FindElement(By.Id("ajaxBusyMenu")).Displayed)
                {
                    visible = wait.Until((d) =>
                    {
                        return Driver.FindElement(By.Id("ajaxBusyMenu")).Displayed == false;
                    });
                }
            }
            catch (Exception ex)
            {
                string str = ex.Message;
            }
        }

        protected void ScrollElementToView(IWebElement element)
        {
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)Driver;           
            //jsExecutor.ExecuteScript(String.Format(@"$(arguments[0].scrollIntoView(true));"), new object[] { element });
            jsExecutor.ExecuteScript("window.scrollTo(" + (element.Location.X - 20) + ","+(element.Location.Y - 100) + ");");
        }

        #endregion

        #region AlertPopUpFunctions

        internal IAlert GetAlertHandle(int maxWaitTime = 0)
        {
            IAlert alertHandle = null;
            maxWaitTime = maxWaitTime > 0 ? maxWaitTime : ElementSyncTimeOut;
            try
            {
                for (int i = 0; i < maxWaitTime; i++)
                {
                    try
                    {
                        alertHandle = Driver.SwitchTo().Alert();
                        break;
                    }
                    catch
                    {
                        Thread.Sleep(1000);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return alertHandle;
        }

        protected void AcceptAlert(int maxWaitTime = 0)
        {
            IAlert alertHandle = null;
            maxWaitTime = maxWaitTime > 0 ? maxWaitTime : ElementSyncTimeOut;
            try
            {
                alertHandle = GetAlertHandle(maxWaitTime);
                if (alertHandle != null)
                {
                    alertHandle.Accept();
                }
                else
                {
                    throw new Exception("Alert handle not available");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        protected void DismissAlert(int maxWaitTime = 0)
        {
            IAlert alertHandle = null;
            maxWaitTime = maxWaitTime > 0 ? maxWaitTime : ElementSyncTimeOut;
            try
            {
                alertHandle = GetAlertHandle(maxWaitTime);
                if (alertHandle != null)
                {
                    alertHandle.Dismiss();
                }
                else
                {
                    throw new Exception("Alert handle not available");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        protected string GetAlertText(int maxWaitTime = 0)
        {
            IAlert alertHandle = null;
            string strAlertText = string.Empty;
            maxWaitTime = maxWaitTime > 0 ? maxWaitTime : ElementSyncTimeOut;
            try
            {
                alertHandle = GetAlertHandle(maxWaitTime);
                if (alertHandle != null)
                {
                    strAlertText = alertHandle.Text;
                }
                else
                {
                    throw new Exception("Alert handle not available");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return strAlertText;
        }

        #endregion
                
        #region AssertionFunctions

        protected void Equal(Iteration reporter, String actual, String expected)
        {
            reporter.Chapter.Step.Actions.Add(new Act(String.Format("Verify '{0}' Equals '{1}'", expected, actual)));

            if (!String.Equals(actual, expected))
            {
                throw new Exception(String.Format("Not Equal {0} : {1}", actual, expected));
            }
        }

        protected void CheckStringContains(Iteration reporter, String StrText, String Token)
        {
            try
            {
                reporter.Chapter.Step.Actions.Add(new Act(String.Format("Verify '{0}' contains '{1}'", StrText, Token)));
                if (!StrText.ToLower().Contains(Token.ToLower()))
                {
                    throw new Exception(String.Format("Does not Contain {0} : {1}", StrText, Token));
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        protected void Equal(Iteration reporter, DateTime actual, DateTime expected, String name = "")
        {
            reporter.Chapter.Step.Actions.Add(new Act(String.Format("Verify '{0}' Equals '{1}'", expected, actual)));

            if (!String.Equals(actual, expected))
            {
                throw new Exception(String.Format("Not Equal {0} : {1}", actual, expected));
            }
        }

        protected void NullOrEmpty(Iteration reporter, String data)
        {
            reporter.Chapter.Step.Actions.Add(new Act(String.Format("Verify Null or Empty '{0}'", data)));

            if (!String.IsNullOrEmpty(data) || !String.IsNullOrWhiteSpace(data))
            {
                throw new Exception(String.Format("Data is not Null or Empty"));
            }
        }

        protected void NotNullOrEmpty(Iteration reporter, String data)
        {
            reporter.Chapter.Step.Actions.Add(new Act(String.Format("Verify Null or Empty '{0}'", data)));

            if (String.IsNullOrEmpty(data) || String.IsNullOrWhiteSpace(data))
            {
                throw new Exception(String.Format("Data is Null or Empty"));
            }
        }

        protected void Equal(Iteration reporter, Int64 first, Int64 second)
        {
            if (!(first == second))
            {
                throw new Exception(String.Format("Not Equal {0} : {1}", first, second));
            }
        }

        protected void checkEqualityOfObjects(Iteration reporter, bool first, bool second, string strStepDesc = "")
        {
            if (string.IsNullOrEmpty(strStepDesc))
            {
                reporter.Chapter.Step.Actions.Add(new Act(String.Format("Verify '{0}' Equals '{1}'", first, second)));
            }
            else
            {
                reporter.Chapter.Step.Actions.Add(new Act(strStepDesc));
            }

            if (!(first == second))
            {
                throw new Exception(String.Format("Not Equal {0} : {1}", first, second));
            }
        }

        protected void Equal(Iteration reporter, Decimal first, Decimal second)
        {
            if (!first.Equals(second))
            {
                throw new Exception(String.Format("Not Equal {0} : {1}", first, second));
            }
        }

        protected void AlphabeticalOrder(IList<String> items)
        {
            String lastItem = String.Empty;
            foreach (String item in items)
            {
                if (lastItem == String.Empty)
                {
                    lastItem = item;
                }

                if (lastItem.CompareTo(item) > 0)
                {
                    throw new Exception(String.Format("Item {0} not in alphabetical order", item));
                }
            }
        }

        protected void NullOrEmpty(String data)
        {
            if (String.IsNullOrEmpty(data) || String.IsNullOrWhiteSpace(data))
            {
                throw new Exception(String.Format("Data is Null or Empty"));
            }
        }

        protected void NotEqual(Iteration reporter, String first, String second)
        {
            reporter.Chapter.Step.Actions.Add(new Act(String.Format("Verify '{0}' Not Equals '{1}'", first, second)));

            if (String.Equals(first, second))
            {
                throw new Exception(String.Format("Equal {0} : {1}", first, second));
            }
        }

        protected void NotEqual(Iteration reporter, Int64 first, Int64 second)
        {
            reporter.Chapter.Step.Actions.Add(new Act(String.Format("Verify '{0}' Not Equals '{1}'", first, second)));

            if (first == second)
            {
                throw new Exception(String.Format("Not Equal {0} : {1}", first, second));
            }
        }

        #endregion

        #region TableFunctions

        protected DataTable gfn_GetDataTable(int columnCount)
        {
            DataTable dt = new DataTable();
            if (columnCount > 0)
            {
                for (int i = 0; i < columnCount; i++)
                {
                    dt.Columns.Add(i.ToString(), typeof(object));
                }
            }
            return dt;
        }

        protected DataTable gfn_GetDataTable(int columnCount, List<string> colNames)
        {
            DataTable dt = new DataTable();
            if (columnCount > 0)
            {
                for (int i = 0; i < columnCount; i++)
                {
                    dt.Columns.Add(colNames[i], typeof(object));
                }
            }
            return dt;
        }

        protected IWebElement gfn_GetFirstElementFromTable(ICollection<IWebElement> cells)
        {
            IWebElement currentData = null;
            IEnumerator<IWebElement> tableCells = cells.GetEnumerator();
            while (tableCells.MoveNext())
            {
                currentData = tableCells.Current;
                break;
            }
            return currentData;
        }

        protected List<string> gfn_GetTableColumnNames(ICollection<IWebElement> cells)
        {
            List<string> colNames= new List<string>();
            IWebElement currentData = null;
            IEnumerator<IWebElement> tableCells = cells.GetEnumerator();
            while (tableCells.MoveNext())
            {
                currentData = tableCells.Current;
                colNames.Add(currentData.Text);               
            }
            return colNames;
        }

        protected DataRow gfn_GetSpecifiedRow(DataTable table, string columnValue)
        {
            DataRow dRow = null;
            object[] rowData;
            foreach (DataRow row in table.Rows)
            {
                int length = row.ItemArray.Length;
                rowData = row.ItemArray;
                for (int count = 0; count < length; count++)
                {
                    if (rowData[count].Equals(columnValue))
                    {
                        dRow = row;
                        break;
                    }
                }
            }
            return dRow;
        }

        protected DataTable gfn_GetCompleteTableDetails(By locateBy, int maxWaitTime = 0)
        {
            ICollection<IWebElement> rows = null;
            ICollection<IWebElement> cells = null;
            DataTable dtTableDetails = null;
            IWebElement table = null;
            List<string> colNames;
            maxWaitTime = maxWaitTime > 0 ? maxWaitTime : ElementSyncTimeOut;
            try
            {
                table = GetNativeElement(locateBy);
                rows = GetNativeElementsInAElement(table, By.TagName("tr"));
                int columnCount = gfn_GetFirstElementFromTable(rows).FindElements(By.TagName("th")).Count;
                colNames = gfn_GetTableColumnNames(rows.ToList()[0].FindElements(By.TagName("th")));
                dtTableDetails = gfn_GetDataTable(columnCount,colNames);
                DataRow dRow;
                int columns = 0;

                foreach (var row in rows)
                {
                    cells = row.FindElements(By.TagName("td"));
                    dRow = dtTableDetails.NewRow();
                    IEnumerator<IWebElement> tableCells = cells.GetEnumerator();
                    while (tableCells.MoveNext())
                    {

                        dRow[columns] = tableCells.Current.Text.ToString();
                        columns++;
                    }
                    dtTableDetails.Rows.Add(dRow);
                    columns = 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return dtTableDetails;
        }

        protected bool VerifyElementExistsUnderRow(string expRowName, string expValue, By locator, int maxWaitTime = 0)
        {
            bool objFound = false;
            maxWaitTime = maxWaitTime > 0 ? maxWaitTime : ElementSyncTimeOut;
            try
            {
                IWebElement table = GetNativeElement(locator);
                ICollection<IWebElement> rows = GetNativeElementsInAElement(table, By.TagName("tr"));
                foreach (var row in rows)
                {
                    string name = row.Text;
                    if (name.Contains(expRowName))
                    {

                        if (name.Contains(expValue))
                        {
                            objFound = true;
                            Reporter.Add(new Act(expRowName + " contains " + expValue));
                            break;
                        }
                        else
                        {
                            Reporter.Add(new Act(expRowName + " does not contains " + expValue));
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return objFound;
        }

        protected void VerifyResultSortedByColumnName(string expcolumnName, By locator)
        {

            try
            {
                int i = 1;
                string val = string.Empty;
                IList<string> DisplayNames = new List<string>();

                IWebElement table = GetNativeElement(locator);
                ICollection<IWebElement> rows = GetNativeElementsInAElement(table, By.TagName("tr"));
                ICollection<IWebElement> columns = GetNativeElementsInAElement(table, By.TagName("td"));
                string[] words = locator.ToString().Split(':');
                string path = words[1].Trim();
                foreach (var row in rows)
                {

                    IWebElement displayName = row.FindElement(By.XPath(path + "/tbody/" + "tr[" + i + "]" + "/td[5]/a"));
                    string value = displayName.Text.ToString();
                    DisplayNames.Add(value);
                    i++;
                    if (i == rows.Count)
                    {
                        //Sort elements by Alphabets
                        List<string> list = DisplayNames.ToList<string>();
                        list.Sort();

                        for (int k = 0; k <= DisplayNames.Count - 1; k++)
                        {
                            if (list.Count == DisplayNames.Count)
                            {
                                if (list[k] == DisplayNames[k])
                                {
                                    if (k == DisplayNames.Count - 1)
                                    {
                                        Reporter.Add(new Act("Elements are displayed in the alphabetical order"));
                                        return;
                                    }

                                }

                            }

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Reporter.Add(new Act(ex.Message));
            }

        }

        #endregion

    }
}
