﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Selenium.Automation.Accelerators
{
    public class Step
    {
        private List<Act> actions = new List<Act>();
       
        public Step()
        {

        }

        /// <summary>
        /// Creates a new Chapter
        /// </summary>
        /// <param name="title">Title</param>
        public Step(String title)
        {
            this.Title = title;
        }

        /// <summary>
        /// Gets or sets Title
        /// </summary>
        public String Title { get; set; }

        /// <summary>
        /// Gets Actions
        /// </summary>
        public List<Act> Actions
        {
            get
            {
                return actions;
            }
        }

        /// <summary>
        /// Gets current Action
        /// </summary>
        public Act Action
        {
            get
            {
                return Actions.Last();
            }
        }

        /// <summary>
        /// Gets or sets IsSuccess
        /// </summary>
        public Boolean IsSuccess
        {
            get
            {
                //if (Actions.Count() > 0)
                //{
                //    return Action.IsSuccess;
                //}
                if (Actions != null && Actions.Count>0)
                {
                    if (Actions.Where<Act>(a => a.IsSuccess == false).Count() > 0)
                        return false;
                }                
                return true;
            }
            set { }
        }
    }
}
