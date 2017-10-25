using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Xml;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace Selenium.Automation.Accelerators
{
    /// <summary>
    /// Description of BaseTest.
    /// </summary>
    public abstract class BaseTest
    {
        //public static Dictionary<String, String> browserConfig;
                
        /// <summary>
        /// Gets or Sets Driver
        /// </summary>
        public RemoteWebDriver Driver { get; set; }

        /// <summary>
        /// Gets or Sets Browser
        /// </summary>
        public String browser{ get; set; }

        /// <summary>
        /// Gets or Sets Reporter
        /// </summary>
        public Iteration Reporter { get; set; }

        /// <summary>
        /// Gets or Sets Step
        /// </summary>
        protected string Step
        {
            get
            {
                //TODO: Get should go away
                return Reporter.Chapter.Step.Title;
            }
            set
            {
                Reporter.Add(new Step(value));
            }
        }

        /// <summary>
        /// Gets or Sets Identity of Test Case
        /// </summary>
        public string TestCaseId { get; set; }

        /// <summary>
        /// Gets or Sets Identity of Test Data
        /// </summary>
        public string TestDataId { get; set; }

        /// <summary>
        /// Gets or Sets Test Data as XMLNode
        /// </summary>
        public XmlNode TestDataNode { get; set; }

        /// <summary>
        /// Gets or Sets Test Case as XMLNode
        /// </summary>
        public XmlNode TestCaseNode { get; set; }        

        private string browserTarget = "";

        #region Instance

        private static BaseTest instance;
        public static BaseTest Instance
        {
            get
            {
                if (instance == null)
                {
                    if (instance == null)
                    {
                        instance = Activator.CreateInstance<BaseTest>();
                    }
                }
                return instance;
            }
        }

        #endregion

        #region Constructor

        public BaseTest()
        {
        }

        public BaseTest(RemoteWebDriver _Driver)
        {
            this.Driver = _Driver;
        }

        public BaseTest(String _browser)
        {
            this.browser= _browser;
        }

        public BaseTest(XmlNode _testNode)
        {
            this.TestCaseNode = _testNode;
        }

        #endregion              

        public void Execute(TestCase testCaseObject, Dictionary<String, String> browserConfig, XmlNode testDataNode, Iteration iteration, Engine reportEngine)
        {
            try
            {
                this.Driver = Util.GetDriver(browserConfig);
                this.browser= Util.getBrowser(browserConfig);
                this.browserTarget = browserConfig["target"];
                iteration.StartTime = DateTime.Now;
                this.Reporter = iteration;
                this.TestCaseId = testCaseObject.Title;
                this.TestDataId = testDataNode.SelectSingleNode("TDID").InnerText;
                this.TestDataNode = testDataNode;

                if (browserConfig["target"] == "local")
                {
                    var wmi = new ManagementObjectSearcher("select * from Win32_OperatingSystem").Get().Cast<ManagementObject>().First();

                    this.Reporter.Browser.PlatformName = String.Format("{0} {1}", ((string)wmi["Caption"]).Trim(), (string)wmi["OSArchitecture"]);
                    this.Reporter.Browser.PlatformVersion = ((string)wmi["Version"]);
                    this.Reporter.Browser.BrowserName = Driver.Capabilities.BrowserName;
                    this.Reporter.Browser.BrowserVersion = Driver.Capabilities.Version;
                }
                //else //added by srikanth on 17-aug for mobile devices..need to be tested
                //{
                //    this.Reporter.Browser.BrowserName = Driver.Capabilities.BrowserName;
                //    this.Reporter.Browser.BrowserVersion = Driver.Capabilities.Version;
                //}
                // Does Seed having anything?
                if (this.Reporter.Chapter.Steps.Count == 0)
                    this.Reporter.Chapters.RemoveAt(0);              

                ExecuteTestCase();               
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                try
                {
                    this.Reporter.Chapter.Step.Action.Extra = ex.Message + "<br/>" + ex.StackTrace;
                    this.Reporter.Chapter.Step.Action.IsSuccess = false;
                }
                catch (Exception ex1)
                {
                    Console.WriteLine(ex1.Message);
                    this.Reporter.Chapter.Step.Action.Extra = ex1.Message + "<br/>" + ex1.StackTrace;
                    this.Reporter.Chapter.Step.Action.IsSuccess = false;
                }

            }
            finally
            {
                try
                {
                    this.Reporter.IsCompleted = true;
                    ITakesScreenshot iTakeScreenshot = Driver;
                    this.Reporter.Screenshot = iTakeScreenshot.GetScreenshot().AsBase64EncodedString;
                    //this.Reporter.EndTime = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.Local, TimeZoneInfo.FindSystemTimeZoneById("India Standard Time"));
                    this.Reporter.EndTime = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.Local, TimeZoneInfo.Local);

                    lock (reportEngine)
                    {
                        reportEngine.PublishIteration(this.Reporter);
                        reportEngine.Summarize(false);
                    }
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
                finally
                {
                    if(Driver !=null)
                    Driver.Quit();

                    if (browserTarget == "Androidchrome")
                    KillAppium();
                }
            }
        }
        
        /// <summary>	
        /// Executes Test Case, should be overriden by derived
        /// </summary>
        protected virtual void ExecuteTestCase()
        {
            Reporter.Add(new Chapter("Execute Test Case"));
        }

        /// <summary>
        /// Prepares Seed Data, should be overriden by derived
        /// </summary>
        protected virtual void PrepareSeed()
        {
            Reporter.Add(new Chapter("Prepare Seed Data"));
        }

        #region PageInstance

        protected T Page<T>() where T : BasePage
        {
            Type pageType = typeof(T);
            if (pageType != null)
            {
                T ob = Activator.CreateInstance<T>();
                return ob;
            }
            else
            {
                return null;
            }
        }

        protected T Page<T>(RemoteWebDriver driver) where T : BasePage, new()
        {
            Type pageType = typeof(T);
            if (pageType != null)
            {
                T ob = (T)Activator.CreateInstance(pageType, new object[] { driver });
                return ob;
            }
            else
            {
                return null;
            }
        }

        protected T Page<T>(XmlNode _testNode) where T : BasePage, new()
        {
            Type pageType = typeof(T);
            if (pageType != null)
            {
                T ob = (T)Activator.CreateInstance(pageType, new object[] { _testNode });
                return ob;
            }
            else
            {
                return null;
            }
        }

        protected T Page<T>(RemoteWebDriver driver, XmlNode _testNode) where T : BasePage, new()
        {
            Type pageType = typeof(T);
            if (pageType != null)
            {
                T ob = (T)Activator.CreateInstance(pageType, new object[] { driver, _testNode });
                return ob;
            }
            else
            {
                return null;
            }
        }

        protected T Page<T>(RemoteWebDriver driver, XmlNode _testNode, Iteration iteration) where T : BasePage, new()
        {
            Type pageType = typeof(T);
            if (pageType != null)
            {
                T ob = (T)Activator.CreateInstance(pageType, new object[] { driver, _testNode, iteration });               
                return ob;
            }
            else
            {
                return null;
            }
        }

        #endregion

        /// <summary>
        /// KillAppium
        /// </summary>
        private static void KillAppium()
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.FileName = System.IO.Directory.GetCurrentDirectory() + "\\AppiumServer\\EndAppium.bat";
            process.Start();
        }

    }
}
