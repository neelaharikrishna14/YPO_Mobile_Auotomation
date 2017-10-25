using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Selenium.Automation.Accelerators
{
    public class Chapter
    {
        private List<Step> steps = new List<Step>();

        public Chapter()
        {

        }
        /// <summary>
        /// Creates a new Chapter
        /// </summary>
        /// <param name="title">Title</param>
        public Chapter(String title)
        {
            this.Title = title;
        }

        /// <summary>
        /// Gets or sets Title
        /// </summary>
        public String Title { get; set; }

        /// <summary>
        /// Gets Steps
        /// </summary>
        public List<Step> Steps
        {
            get
            {
                return steps;
            }
        }

        /// <summary>
        /// Get current Step
        /// </summary>
        public Step Step
        {
            get
            {
                if (Steps.Count() == 0)
                    Steps.Add(new Step("UNKNOWN STEP"));
                return Steps.Last();
            }
        }

        /// <summary>
        /// Gets or sets IsSuccess
        /// </summary>
        public Boolean IsSuccess
        {
            get
            {
                //if (Steps.Count() > 0)
                //{
                //    return Step.IsSuccess;
                //}
                if (Steps != null && Steps.Count > 0)
                {
                    if (Steps.Where<Step>(a => a.IsSuccess == false).Count() > 0 || (Steps.Where<Step>(a => a.Title == "UNKNOWN STEP").Count() > 0))
                        return false;
                }
                return true;
            }

        }

    }
}
