using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Selenium.Automation.Accelerators
{
    public class Act
    {
        private Boolean isSuccess = true;

        public Act()
        {

        }

        /// <summary>
        /// Creates Action instance
        /// </summary>
        /// <param name="title"></param>
        public Act(String title)
        {
            this.Title = title;
            this.TimeStamp = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.Local, TimeZoneInfo.Local);
            //this.TimeStamp = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.Local, TimeZoneInfo.FindSystemTimeZoneById("India Standard Time"));
        }

        /// <summary>
        /// Create Action instance
        /// </summary>
        /// <param name="title"></param>
        /// <param name="isPassed"></param>
        /// <param name="Driver"></param>
        public Act(string title, bool isPassed, RemoteWebDriver Driver)
        {
            this.Title = title;
            this.TimeStamp = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.Local, TimeZoneInfo.Local);

            if(isPassed==false)
            {
                IsSuccess = false;
                string randomName = String.Format("{0}_Error.png", DateTime.Now.ToString("ddMMyyyyhhmmss"));
                Engine repEngine = (Engine)Utilities.AppStore.Instance.Store["ReportEngine"];
                string screenshotPath = Path.Combine(repEngine.ReportPath, "Screenshots", randomName);
                ITakesScreenshot iTakeScreenshot = Driver;
                string Screenshot = iTakeScreenshot.GetScreenshot().AsBase64EncodedString;
                File.WriteAllBytes(screenshotPath, Convert.FromBase64String(Screenshot));
                ImagePath = ".\\Screenshots\\" + randomName;
            }                            
        }

        /// <summary>
        /// Gets or sets error screenshot path
        /// </summary>
        public string ImagePath { get; set; }

        /// <summary>
        /// Gets or sets Title
        /// </summary>
        public String Title { get; set; }

        /// <summary>
        /// Gets or sets TimeStamp
        /// </summary>
        public DateTime TimeStamp { get; set; }

        /// <summary>
        /// Gets or sets Extra
        /// </summary>
        public String Extra { get; set; }

        /// <summary>
        /// Gets or sets isSuccess
        /// </summary>
        public Boolean IsSuccess
        {
            get
            {
                return isSuccess;
            }
            set
            {
                isSuccess = value;
            }
        }
    }
}