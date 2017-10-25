using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
//using System.Runtime.Serialization;

namespace Selenium.Automation.Accelerators
{
    [Serializable]
    //[DataContract(IsReference = true)]
    public class Iteration
    {
        private List<Chapter> chapters = new List<Chapter>();

        public Iteration()
        {
        }
        /// <summary>
        /// Creates a new Iteration
        /// </summary>
        /// <param name="title">Title</param>
        public Iteration(String title, String defectID)
        {
            this.Title = title;
            this.BugInfo = defectID;
            //this.StartTime = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.Local, TimeZoneInfo.FindSystemTimeZoneById("India Standard Time"));
            this.StartTime = TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.Local, TimeZoneInfo.Local);

        }

        //[DataMember]
        /// <summary>
        /// Gets or sets Title
        /// </summary>
        public String Title { get; set; }

        /// <summary>
        /// Gets or sets BugInfo
        /// </summary>
        public String BugInfo { get; set; }

        //[DataMember]
        /// <summary>
        /// Gets or sets Start Time
        /// </summary>
        public DateTime StartTime { get; set; }

        //[DataMember]
        /// <summary>
        /// Gets or sets End Time
        /// </summary>
        public DateTime EndTime { get; set; }

        //[DataMember]
        /// <summary>
        /// Gets Chapters
        /// </summary>
        public List<Chapter> Chapters
        {
            get
            {
                return chapters;
            }
        }

        //[DataMember]
        /// <summary>
        /// Gets Current Chapter
        /// </summary>
        public Chapter Chapter
        {
            get
            {
                if (Chapters.Count() == 0)
                    Chapters.Add(new Chapter("UNKNOWN CHAPTER"));
                return Chapters.Last();
            }           
        }

        /// <summary>
        /// Adds new Chapter
        /// </summary>
        /// <param name="chapter">Chapter to add</param>
        public void Add(Chapter chapter)
        {
            Chapters.Add(chapter);
        }

        /// <summary>
        /// Adds new Step to current Chapter
        /// </summary>
        /// <param name="step"></param>
        public void Add(Step step)
        {
            this.Chapter.Steps.Add(step);
        }

        /// <summary>
        /// Adds new action to current Step
        /// </summary>
        /// <param name="action"></param>
        public void Add(Act action)
        {
            this.Chapter.Step.Actions.Add(action);
        }

        //[DataMember]
        /// <summary>
        /// Gets or sets IsSuccess
        /// </summary>
        public Boolean IsSuccess
        {
            get
            {
                //if (Chapters.Count() > 0)
                //{
                //	return Chapter.IsSuccess;
                //}
                if (Chapters != null && Chapters.Count > 0)
                {
                    if ((Chapters.Where<Chapter>(a => a.IsSuccess == false).Count() > 0) || (Chapters.Where<Chapter>(a => a.Title == "UNKNOWN CHAPTER").Count() > 0))
                        return false;
                }
                return true;
            }
            set { }
        }

        [XmlIgnore]
        /// <summary>
        /// Gets or sets Screenshot
        /// </summary>
        /// 
        public String Screenshot { get; set; }

        [XmlIgnore]
        public Browser Browser { get; set; }

        //[DataMember]
        public Boolean IsCompleted { get; set; }
    }
}