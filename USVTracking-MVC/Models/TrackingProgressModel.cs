using System;
using System.Collections.Generic;

namespace USVTracking_MVC.Models
{
    public class TrackingProgressModel
    {
        public String ProjectName { get; set; }
        public String Status { get; set; }
        public string FromDate { get; set; }
        public string EndDate { get; set; }

        /// <summary>
        /// List of TrackingInfo
        /// </summary>
        public IEnumerable<TrackingInfo> ListTrackingInfo { get; set; }

        public IEnumerable<TaskInfo> ListTaskInfo { get; set; }

        public IEnumerable<ProjectMaster> ListProject { get; set; }

        public String[] TaskStatus { get; set; }
    }
}