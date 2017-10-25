﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
//using System.Runtime.Serialization;

namespace Selenium.Automation.Accelerators
{
    [Serializable]
    //[DataContract(IsReference = true)]
    public class Browser
    {
        private List<Iteration> iterations = new List<Iteration>();

        public Browser()
        {
           
        }

        /// <summary>
        /// Creates a new Browser
        /// </summary>
        /// <param name="title">Title</param>
        public Browser(String title)
        {
            this.Title = title;
        }

        //[DataMember]
        /// <summary>
        /// Gets or sets Title
        /// </summary>
        public String Title { get; set; }

        //[DataMember]
        /// <summary>
        /// Gets or sets Browser Name
        /// </summary>
        public String BrowserName { get; set; }

        //[DataMember]
        /// <summary>
        /// Gets or sets Browser Version
        /// </summary>
        public String BrowserVersion { get; set; }

        //[DataMember]
        /// <summary>
        /// Gets or sets Platform Name
        /// </summary>
        public String PlatformName { get; set; }

        //[DataMember]
        /// <summary>
        /// Gets or sets Platform Version
        /// </summary>
        public String PlatformVersion { get; set; }

        //[DataMember]
        /// <summary>
        /// Gets Iterations
        /// </summary>
        public List<Iteration> Iterations
        {
            get
            {
                return iterations;
            }
        }

        //[DataMember]
        /// <summary>
        /// Gets current Iteration
        /// </summary>
        public Iteration Iteration
        {
            get
            {
                return Iterations.Last();
            }            
        }

        /// <summary>
        /// Gets Passed Count
        /// </summary>
        public int PassedCount
        {
            get
            {
                return Iterations.FindAll(i => i.IsSuccess == true && i.IsCompleted == true).Count;
            }
        }

        /// <summary>
        /// Gets Failed Count
        /// </summary>
        public int FailedCount
        {
            get
            {
                return Iterations.FindAll(i => i.IsSuccess == false && i.IsCompleted == true).Count;
            }
        }

        //[DataMember]
        /// <summary>
        /// Gets IsSuccess
        /// </summary>
        public bool IsSuccess
        {
            get
            {
                return Iterations.FindAll(i => i.IsSuccess == false && i.IsCompleted == true).Count == 0;
            }
            set { }
        }

        [XmlIgnore]
        public TestCase TestCase { get; set; }
    }
}
