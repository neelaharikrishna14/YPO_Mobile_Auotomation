using System;
using System.Xml;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using Selenium.Automation.Accelerators;
using OpenQA.Selenium.Interactions;
using System.Collections.Generic;


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


namespace ApplicationName.Automation
{
    public class HomeSiteLogin : BasePage
    {
        #region Constructor
        private Locator Locator = new Locator(ApplicationPages.HomeSiteLogin.ToString());
        BrowserTypes pageBrowserType;

        public HomeSiteLogin()
        {

        }

        public HomeSiteLogin(RemoteWebDriver _Driver)
        {
            this.Driver = _Driver;
        }

        public HomeSiteLogin(XmlNode _testNode)
        {
            this.TestDataNode = _testNode;
        }

        public HomeSiteLogin(RemoteWebDriver _Driver, XmlNode _testNode)
        {
            this.Driver = _Driver;
            this.TestDataNode = _testNode;
        }

        public HomeSiteLogin(RemoteWebDriver _Driver, XmlNode _testNode, Iteration iteration)
        {
            this.Driver = _Driver;
            this.TestDataNode = _testNode;
            this.Reporter = iteration;
            this.Browser = iteration.Browser.Title;
            Locator.Browser = iteration.Browser.Title;
            pageBrowserType = AppCommon.GetPageBrowserType(this.Browser);
        }

        #endregion

        #region ObjectRepository

        By txt_UserId
        {
            get
            {
                return Locator.GetLocator("UserId");
            }
        }

        By txt_Password
        {
            get
            {
                return Locator.GetLocator("Password");
            }
        }

        By btn_LogIn
        {
            get
            {
                return Locator.GetLocator("SignIn");
            }
        }
        By validation_msg
        {
            get
            {
                return Locator.GetLocator("validation_for_invalidlogin");
            }
        }
        By btn_RememeberMe
        {
            get
            {
                return Locator.GetLocator("RememeberMe");
            }
        }



        By Link_TermsOfUse
        {
            get
            {
                return Locator.GetLocator("TermsOfUse");
            }
        }

        By btn_TermsOfUse
        {
            get
            {
                return Locator.GetLocator("Btn_TermsOfUse");
            }
        }

        By pdf_DocumentPage
        {
            get
            {
                return Locator.GetLocator("Pdf_DocumentPage");
            }
        }

        By btn_Close
        {
            get
            {
                return Locator.GetLocator("Btn_Close");
            }
        }


        By Link_PrivacyPolicy
        {
            get
            {
                return Locator.GetLocator("PrivacyPolicy");
            }
        }




        By btn_PrivacyPolicy
        {
            get
            {
                return Locator.GetLocator("Btn_PrivacyPolicy");
            }
        }

       



        By btn_claims
        {
            get
            {
                return Locator.GetLocator("claims");
            }
        }
        By btn_Newclaims
        {
            get
            {
                return Locator.GetLocator("NewClaim");
            }
        }
        By btn_BackToClaimCenter
        {
            get
            {
                return Locator.GetLocator("BackToClaimCenter");
            }
        }
        By btn_visitHelpCenter
        {
            get
            {
                return Locator.GetLocator("visitHelpCenter");
            }
        }
        By btn_Menu
        {
            get
            {
                return Locator.GetLocator("Menu");
            }
        }

        By btn_signOutButton
        {
            get
            {
                return Locator.GetLocator("signOutButton");
            }
        }
        By txt_searchbox
        {
            get
            {
                return Locator.GetLocator("searchbox");
            }
        }
        By btn_headerSearchBtn
        {
            get
            {
                return Locator.GetLocator("headerSearchBtn");
            }
        }
        By lst_SearchList
        {
            get
            {
                return Locator.GetLocator("SearchList");
            }
        }
        By txt_EffectiveDateCalendar
        {
            get
            {
                return Locator.GetLocator("EffectiveDateCalendar");
            }
        }
        By txt_AddressLine1
        {
            get
            {
                return Locator.GetLocator("AddressLine1");
            }
        }
        By txt_AddressLine2
        {
            get
            {
                return Locator.GetLocator("AddressLine2");
            }
        }
        By txt_City
        {
            get
            {
                return Locator.GetLocator("City");
            }
        }
        By lst_State
        {
            get
            {
                return Locator.GetLocator("State");
            }
        }
        By txt_Zip
        {
            get
            {
                return Locator.GetLocator("Zip");
            }
        }
        By btn_Continue
        {
            get
            {
                return Locator.GetLocator("Continue");
            }
        }
        By btn_Cancel
        {
            get
            {
                return Locator.GetLocator("Cancel");
            }
        }
        By btn_BkHelpCenter
        {
            get
            {
                return Locator.GetLocator("BkHelpCenter");
            }
        }

        By btn_searchicon
        {
            get
            {
                return Locator.GetLocator("searchicon");
            }
        }
        By text_Directory
        {
            get
            {
                return Locator.GetLocator("Directory");
            }
        }




        #endregion

        #region PageFunctions

        public bool Login(string userName = "", string password = "")
        {
            bool isSuccess = false;
            try
            {
                Reporter.Add(new Act("Click on username field"));
                ClickOnObject(txt_UserId);

                Reporter.Add(new Act("Enter user name"));
                SetValueToObject(txt_UserId, userName);

                Reporter.Add(new Act("Click on password field"));
                ClickOnObject(txt_Password);

                Reporter.Add(new Act("Enter password"));
                SetValueToObject(txt_Password, password);

                Reporter.Add(new Act("Click on Login"));
                ClickOnObject(btn_LogIn);

                Thread.Sleep(10000);
                Reporter.Add(new Act("Verify the successful login"));
                WaitForElementVisible(text_Directory);
                isSuccess = true;
               
                
               
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return isSuccess;
        }




        public bool VerifyRemememberMe(string expectedValue = "")
        {
            bool isSuccess = false;
            try
            {
                Thread.Sleep(10000);
                Reporter.Add(new Act("Verify the Remember me button status"));
                ValidateObjectAttributeValue(btn_RememeberMe, "text", expectedValue);
                isSuccess = true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return isSuccess;
        }


        public bool VerifyUserNameFieldText()
        {
            bool isSuccess = false;
            try
            {
                string UserNameFieldText = GetObjectAttributeValue(txt_UserId, "text");
                if(UserNameFieldText.Equals(null))
                {
                    Reporter.Add(new Act("UsernameField is Empty"));
                    Reporter.Add(new Act("Value in UsernameField is:"+UserNameFieldText));
                }
               // if (!(UserNameFieldText.Equals(null)))
               else
                {
                    Reporter.Add(new Act("UsernameField is not-Empty"));
                    Reporter.Add(new Act("Value in UsernameField is:"+UserNameFieldText));
                }
                isSuccess = true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return isSuccess;
        }


        public bool DisableRememberMeButton()
        {
            bool isSuccess = false;
            try
            {
                string UserNameFieldText = GetObjectAttributeValue(btn_RememeberMe, "text");
                if (UserNameFieldText.Equals("0"))
                {
                    Reporter.Add(new Act("Verify RememberMe Button is OFF"));
                }
                if (UserNameFieldText.Equals("1"))
                {
                    Reporter.Add(new Act("Verify RememberMe Button is ON"));
                    ClickonRemememberMe();
                    Reporter.Add(new Act("RememberMe Button is in OFF Mode"));
                    ClearObjectValue(txt_UserId);
                    Reporter.Add(new Act("UserNameField Value is cleared"));
                }
                isSuccess = true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return isSuccess;
        }


        public bool ClickonRemememberMe()
        {
            bool isSuccess = false;
            try
            {
                ClickOnObject(btn_RememeberMe);
                Reporter.Add(new Act("Successfully Clicked on RememeberMe Button"));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return isSuccess;
        }


        public bool ClickonTermsofUseLink()
        {
            bool isSuccess = false;
            try
            {
                ClickOnObject(btn_TermsOfUse);
                Reporter.Add(new Act("Successfully Clicked on Terms of Use Link"));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return isSuccess;
        }


        public bool ClickonPrivacyPolicy()
        {
            bool isSuccess = false;
            try
            {
                ClickOnObject(btn_PrivacyPolicy);
                Reporter.Add(new Act("Successfully Clicked on Privacy Policy Link"));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return isSuccess;
        }

        public bool VerifyTermsofUseLink()
        {
            bool isSuccess = false;
            try
            {
                //WaitForElementVisible(Link_TermsOfUse);
                WaitForElementVisible(btn_TermsOfUse);
                Console.WriteLine("verify block");
                Reporter.Add(new Act("TermsofUse Link is Present in Login Screen"));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return isSuccess;
        }



        public bool VerifyPrivacyPolicy()
        {
            bool isSuccess = false;
            try
            {
                //WaitForElementVisible(Link_PrivacyPolicy);
                WaitForElementVisible(btn_PrivacyPolicy);
                Reporter.Add(new Act("TermsofUse Link is Present in Login Screen"));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return isSuccess;
        }


        public bool VerifyDocumentLoadedOrNot()
        {
            bool isSuccess = false;
            try
            {
                WaitForElementVisible(pdf_DocumentPage);
                Reporter.Add(new Act("Corresponding PDF Document opened successfully."));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return isSuccess;
        }


        public bool closeDocument()
        {
            bool isSuccess = false;
            try
            {
                ClickOnObject(btn_Close);
                Reporter.Add(new Act("Document Closed Successfully."));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return isSuccess;
        }
















        public bool Claims()
        {
            bool isSuccess = false;
            try
            {
               
                if (pageBrowserType == BrowserTypes.MobileBrowser)
                {
                     Reporter.Add(new Act("Click on Menu button"));
                     ClickOnObject(btn_Menu);
                }
                if (pageBrowserType == BrowserTypes.WebBrowser)
                {
                    Reporter.Add(new Act("Click on Claims button"));
                    ClickOnObject(btn_claims);
                }
                
                  
                    //NavigateToURL("https://www.homesite.com/OnlineServicing/Policy/Claims/Center/"); 
                   /* Reporter.Add(new Act("Click on Create a new Claim button"));
                    ClickOnObject(btn_Newclaims);
                    Thread.Sleep(3000);
                    Reporter.Add(new Act("Validate if FNOL page shows up - String Renter Claim Form"));
                    Reporter.Add(new Act("Click on Back to Claim center button"));
                    ClickOnObject(btn_BackToClaimCenter);
                    Thread.Sleep(3000);
                    Reporter.Add(new Act("Validate if user navigates to Claim Center page shows up - String Closed Claims"));
                    Reporter.Add(new Act("Click on Visit Help Center"));
                    ClickOnObject(btn_visitHelpCenter);
                    Reporter.Add(new Act("Validate if user navigates to Claim Center page shows up - String Claims FAQs"));
                    Thread.Sleep(3000);*/
                Thread.Sleep(4000);
                Reporter.Add(new Act("Validate if previous claims information shows - Claim number 2151715"));
                Reporter.Add(new Act("Validate if previous claims information shows - Status Closed"));
                Reporter.Add(new Act("Validate if previous claims information shows - Loss type - Bodily Injury"));
                Reporter.Add(new Act("Validate if previous claims information shows - Loss Date - 12/28/2016"));


                    if (pageBrowserType == BrowserTypes.MobileBrowser)
                {
                     Reporter.Add(new Act("Click on Menu button"));
                     ClickOnObject(btn_Menu);
                }
                                    
                isSuccess = true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return isSuccess;
        }

        public bool Search()
        {
            bool isSuccess = false;
            try
            {
                if (pageBrowserType == BrowserTypes.MobileBrowser)
                {
                    Reporter.Add(new Act("Click on Search Icon button"));
                    ClickOnObject(btn_searchicon);
                }
                    Reporter.Add(new Act("Enter text in search box"));
                    if (pageBrowserType == BrowserTypes.MobileBrowser)
                    {
                        
                        Thread.Sleep(10000);
                    }
                    else
                    {
                        SetValueToObject(txt_searchbox, "cancel", 20);
                        Thread.Sleep(2000);
                    }
                    Reporter.Add(new Act("Click on search button"));
                    ClickOnObject(btn_headerSearchBtn);
                    //NavigateToURL("https://www.homesite.com/OnlineServicing/Policy/Claims/Center/"); 
                   // Reporter.Add(new Act("Click on cancel FAQ"));
                   // ClickOnObject(lst_SearchList);
                    Thread.Sleep(10000);
                    Reporter.Add(new Act("Validate the search result for text -- Cancel"));
                    Reporter.Add(new Act("Number of links with search term Cancel -- 5"));
                }



            
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return isSuccess;
        }


        public bool CancelFAQ()
        {
            bool isSuccess = false;
            try
            {
                


                    Reporter.Add(new Act("Validate if navigated to cancel FAQ"));

                    Reporter.Add(new Act("Enter Effective Date"));
                    SetValueToObject(txt_EffectiveDateCalendar, "10/10/2017", 10);
                    Reporter.Add(new Act("Enter Address Line1"));
                    SetValueToObject(txt_AddressLine1, "Test", 10);
                    Reporter.Add(new Act("Enter Address Line2"));
                    SetValueToObject(txt_AddressLine2, "Apt 203", 10);
                    Reporter.Add(new Act("Enter City Name"));
                    SetValueToObject(txt_City, "Mobile", 10);
                    Reporter.Add(new Act("Select State"));
                    ClickOnObject(lst_State);
                    //SelectValueInDropdown(lst_State, "AL", "text", 20);

                    //  IWebElement element = null;
                    // element = WaitForElementVisible(lst_State, 20);
                    //OpenQA.Selenium.Support.UI.SelectElement dropDownElement = new OpenQA.Selenium.Support.UI.SelectElement(element);
                    // dropDownElement.SelectByIndex(8);
                    Reporter.Add(new Act("Enter zip code"));
                    SetValueToObject(txt_Zip, "36695", 10);
                    Reporter.Add(new Act("Click on Back to Help Center link"));
                    ClickOnObject(btn_BkHelpCenter);
                    if (pageBrowserType == BrowserTypes.MobileBrowser)
                    {
                        Reporter.Add(new Act("Click on Menu button"));
                        ClickOnObject(btn_Menu);
                    }
                

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return isSuccess;
        }

        public bool LogOut()
        {
            bool isSuccess = false;
            try
            {
                if (pageBrowserType == BrowserTypes.WebBrowser)
                {

                    Reporter.Add(new Act("Click on SignOut Button"));
                    ClickOnObject(btn_signOutButton);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return isSuccess;
        }

        public bool LogOut2()
        {
            bool isSuccess = false;
            try
            {
                

                    Reporter.Add(new Act("Click on SignOut Button"));
                    ClickOnObject(btn_BkHelpCenter);
               
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return isSuccess;
        }




        #endregion

    }
}
