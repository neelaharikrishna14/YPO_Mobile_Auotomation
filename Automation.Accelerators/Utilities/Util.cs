using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Reflection;
using System.Xml;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;

using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.iOS;


using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium;

using NUnit;
using NUnit.Framework;
using OpenQA.Selenium.Appium.Enums;
using OpenQA.Selenium.Support.UI;
using Selenium.Automation.Accelerators;
using System.Threading;


namespace Selenium.Automation.Accelerators
{
	/// <summary>
	/// Description of Util.
	/// </summary>
	public class Util
	{
        private string reportDirectory = "reports";
        private string reportFormat = "xml";
        private string testName = "Util";


        private static Dictionary<string, string> environmentSettings = new Dictionary<string, string>();
        
		/// <summary>
		/// Gets settings for current environment
		/// </summary>
		public static Dictionary<string, string> EnvironmentSettings
		{
			get
			{
				string environment = ConfigurationManager.AppSettings.Get("Environment");
				if (environmentSettings.Count > 0) return environmentSettings;
				String[] KeyValue = null;

				lock (environmentSettings)
				{
					foreach (String setting in ConfigurationManager.AppSettings.Get(environment).Split(new Char[] { ';' }))
					{
						KeyValue = setting.Split(new Char[] { '=' }, 2);
						if (KeyValue.Length > 1)
						{
							environmentSettings.Add(KeyValue[0].Trim(), KeyValue[1].Trim());
						}
					}
				}
				return environmentSettings;
			}
		}
		
		/// <summary>
		/// Prepares RemoteWebDriver basing on configuration supplied
		/// </summary>
		/// <param name="browserConfig"></param>
		/// <returns></returns>
		
		/// <summary>
		/// Prepares RemoteWebDriver basing on configuration supplied
		/// </summary>
		/// <param name="browserConfig"></param>
		/// <returns></returns>
        public static RemoteWebDriver GetDriver(Dictionary<String, String> browserConfig)
        {
            RemoteWebDriver driver = null;           
            try
            {
                if (browserConfig["target"] == "local")
                {
                    if (browserConfig["browser"] == "Firefox")
                    {
                        // C# selenium grid Test
                        
                        FirefoxProfile fprofile = new FirefoxProfile();
                        //fprofile.SetPreference("browser.download.dir", "C:");
                        // 2 tells it to use a custom download path whereas a 1 is the browser's default path and a 0 is the Desktop
                        fprofile.SetPreference("browser.download.folderList", 2);
                        //Set Preference to not show file download confirmation dialogue using MIME types Of different file extension types.
                        //Full lsit of MIME types "http://www.webmaster-toolkit.com/mime-types.shtml"
                        fprofile.SetPreference("browser.helperApps.neverAsk.saveToDisk", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet,application/pdf,application/vnd.openxmlformats-officedocument.wordprocessingml.document,image/jpeg");
                        //fprofile.setPreference( "browser.download.manager.showWhenStarting", false );
                        //if usign PDFs then use it
                        //fprofile.setPreference( "pdfjs.disabled", true );
                        //Pass firefox profile parameter In webdriver to use preferences to download file.
                        driver = new FirefoxDriver(fprofile);
                         
                        // C# selenium grid Test
                    }
                    else if (browserConfig["browser"] == "IE")
                    {
                        DesiredCapabilities capabilities = DesiredCapabilities.InternetExplorer();
                        InternetExplorerOptions intOpts=new InternetExplorerOptions();
                        //intOpts.EnableNativeEvents = false;                      
                        //TODO: Get rid of Framework Path
                        driver = new InternetExplorerDriver(Directory.GetParent(Assembly.GetEntryAssembly().Location).ToString(), intOpts);
                    }
                    else if (browserConfig["browser"] == "Chrome")
                    {
                        DesiredCapabilities capabilities = DesiredCapabilities.Chrome();
                        ChromeOptions chrOpts = new ChromeOptions();
                        chrOpts.AddArguments("test-type");
                        chrOpts.AddArguments("--disable-extensions");
                        //chrOpts.AddUserProfilePreference("download.prompt_for_download", ConfigurationManager.AppSettings["ShowBrowserDownloadPrompt"]);
                        driver = new ChromeDriver(Directory.GetParent(Assembly.GetEntryAssembly().Location).ToString(), chrOpts);
                    }
                    driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(Convert.ToInt32(ConfigurationManager.AppSettings.Get("ElementPageLoad"))));
                    driver.Manage().Window.Maximize();
                    driver.Manage().Cookies.DeleteAllCookies();
                    return driver;
                }
                else if (browserConfig["target"] == "browserstack")
                {
                    DesiredCapabilities desiredCapabilities = new DesiredCapabilities();

                    String[] bsCredentials = ConfigurationManager.AppSettings.Get("BrowserStackCredentials").Split(new Char[] { ':' });
                    desiredCapabilities.SetCapability("browserstack.user", bsCredentials[0].Trim());
                    desiredCapabilities.SetCapability("browserstack.key", bsCredentials[1].Trim());

                    foreach (KeyValuePair<String, String> capability in browserConfig)
                    {
                        if (capability.Key != "target")
                            desiredCapabilities.SetCapability(capability.Key, capability.Value);
                    }

                    driver = new RemoteWebDriver(new Uri("http://hub.browserstack.com/wd/hub/"), desiredCapabilities);
                    driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
                    driver.Manage().Cookies.DeleteAllCookies();
                    return driver;
                }
                else if (browserConfig["target"] == "Androidchrome")
                {
                    string[] arguments = ConfigurationManager.AppSettings["AndroidChrome"].Split(';');
                    StartAppiumServer(arguments[0].Split(':')[1], arguments[1].Split(':')[1], arguments[6].Split(':')[1], arguments[4].Split(':')[1], arguments[5].Split(':')[1], "Appium");
                    System.Threading.Thread.Sleep(5000);
                    DesiredCapabilities desiredCapabilities = new DesiredCapabilities();
                    System.Threading.Thread.Sleep(2000);
                    foreach (KeyValuePair<String, String> capability in browserConfig)
                    {
                        if (capability.Key != "target")
                            desiredCapabilities.SetCapability(capability.Key, capability.Value);
                    }                
                    string ip1 = "127.0.0.1";
                    string port1 = "4723";
                    Uri uri = new Uri("http://" + ip1 + ":" + port1 + "/wd/hub");
                    System.Threading.Thread.Sleep(35000);
                   // driver = new RemoteWebDriver(uri, desiredCapabilities);
                   // driver = new IOSDriver<IOSElement>(new Uri("http://localhost:4723/wd/hub"), dc);
                    //driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(Convert.ToInt32(ConfigurationManager.AppSettings.Get("ElementPageLoad"))));
                    //driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(120));
                    driver.Manage().Cookies.DeleteAllCookies();
                    return driver;
                    //return new RemoteWebDriver(uri, desiredCapabilities);
                }
                else if (browserConfig["target"] == "SafariIOSDevice")
                {

                }
                else if (browserConfig["target"] == "iPhone7Plus")
                {
                    DesiredCapabilities capabilities = new DesiredCapabilities();
                    capabilities.SetCapability("device", "iOS");
                    // capabilities.SetCapability("browserName", "Safari");
                    // capabilities.SetCapability(MobileCapabilityType.App, "C:\\Users\\E000332\\AppData\\Roaming\\appiumstudioenterprise\\original-apks\\YPO Connect QA.ipa");
                    capabilities.SetCapability(IOSMobileCapabilityType.BundleId, "com.ypo.connect.qa");
                    capabilities.SetCapability("deviceName", "617eaeffd39b3869bdcdadbd15908c4f68b7dd1d");
                    capabilities.SetCapability("platformName", "iOS");
                    capabilities.SetCapability("platformVersion", "10.3.2");
                    capabilities.SetCapability("instrumentApp", true);
                    driver = new IOSDriver<IOSElement>(new Uri("http://localhost:4723/wd/hub"), capabilities);
                    return driver; 
                    
                   }
            
                else if (browserConfig["target"] == "iPhone6")
                {
                    DesiredCapabilities capabilities = new DesiredCapabilities();
                    capabilities.SetCapability("device", "iOS");
                    // capabilities.SetCapability("browserName", "Safari");
                    // capabilities.SetCapability(MobileCapabilityType.App, "C:\\Users\\E000332\\AppData\\Roaming\\appiumstudioenterprise\\original-apks\\YPO Connect QA.ipa");
                    capabilities.SetCapability(IOSMobileCapabilityType.BundleId, "com.ypo.connect.qa");
                    capabilities.SetCapability("deviceName", "acdea7640f5b9ba47fda582225c7b596ae6819f1");
                    capabilities.SetCapability("platformName", "iOS");
                    capabilities.SetCapability("platformVersion", "10.2");
                    capabilities.SetCapability("instrumentApp", true);
                    driver = new IOSDriver<IOSElement>(new Uri("http://localhost:4723/wd/hub"), capabilities);
                    return driver; 
                    
                   }
               
           
                return null;
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        /// <summary>
        /// Start Appium Server
        /// </summary>
        private static void StartAppiumServer(string address, string port, string browserName, string platformName, string platformVersion, string automationName)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.FileName = System.IO.Directory.GetCurrentDirectory() + "\\AppiumServer\\StartAppium.bat";           
            string arguments = string.Format("\"{0}\" \"--address {1} --port {2} --browser-name {3} --full-reset --session-override --platform-name {4} --platform-version {5} --automation-name {6} --log-no-color\"",
                @"C:\Program Files (x86)\Appium\node_modules\appium\lib\server\main.js", address, port, browserName, platformName, platformVersion, automationName);
            process.StartInfo.Arguments = arguments;
            process.StartInfo.EnvironmentVariables["ANDROID_HOME"] = ConfigurationManager.AppSettings["ANDROID_HOME"];
            process.Start();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="browserConfig"></param>
        /// <returns></returns>
        public static string getBrowser(Dictionary<String, String> browserConfig)
        {
            string browser_new = string.Empty;
            try
            {
                browser_new = browserConfig["browser"];
            }
            catch
            {

            }
            return browser_new;
        }

		/// <summary>
		/// Gets Browser related configuration data from App.Config
		/// </summary>
		/// <param name="browserId">Identity of Browser</param>
		/// <returns><see cref="Dictionary<String, String>"/></returns>
		public static Dictionary<String, String> GetBrowserConfig(String browserId)
		{
			browserId=ConfigurationManager.AppSettings.Get(browserId).ToString();
			Dictionary<String, String> config = new Dictionary<string, string>();
			String[] KeyValue = null;

			foreach (String attribute in browserId.Split(new Char[] { ';' }))
			{
				if (attribute != "")
				{
					KeyValue = attribute.Split(new Char[] { ':' });
					config.Add(KeyValue[0].Trim(), KeyValue[1].Trim());
				}
			}
			return config;
		}
        public static XmlDocument ReadXmlDocData(string documentName)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(documentName);
            return xmlDoc;
        }             
	}
}
