using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace USVTracking_MVC.Models
{
    public class TaskInfo
    {
        /// <summary>
        /// TrackingNo
        /// </summary>
        public string TrackingNo { get; set; }

        /// <summary>
        /// UserID
        /// </summary>
        public string UserID { get; set; }

        /// <summary>
        /// Date
        /// </summary>
        public string Date { get; set; }

        /// <summary>
        /// WorkingTypeName
        /// </summary>
        public string WorkingTypeName { get; set; }

        /// <summary>
        /// ProjectName
        /// </summary>
        public string ProjectName { get; set; }

        /// <summary>
        /// PhaseName
        /// </summary>
        public string TrackingPhaseID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string TrackingPhaseName { get; set; }

        /// <summary>
        /// ProcessName
        /// </summary>
        public string TrackingProcessID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string TrackingProcessName { get; set; }

        /// <summary>
        /// FunctionCode
        /// </summary>
        public string FunctionCode { get; set; }

        /// <summary>
        /// FunctionName
        /// </summary>
        public string FunctionName { get; set; }

        /// <summary>
        /// RequestID
        /// </summary>
        public decimal? RequestID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal WBSNo { get; set; }

        /// <summary>
        /// WBSName
        /// </summary>
        public string WBSName { get; set; }

        /// <summary>
        /// Duration
        /// </summary>
        public double? Duration { get; set; }

        /// <summary>
        /// Progress
        /// </summary>
        public decimal? Progress { get; set; }

        /// <summary>
        /// Description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// ApprovedFlag
        /// </summary>
        public byte ApprovedFlag { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ApproveComment { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ApproverID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string FlagErr { get; set; }

        /// <summary>
        /// TimeRecordInsertedFlag
        /// </summary>
        public byte TimeRecordInsertedFlag { get; set; }

        /// <summary>
        /// ListPhaseName
        /// </summary>
        public List<KeyValuePair<string, string>> ListPhaseName
        {
            get;
            set;
        }

        /// <summary>
        /// ListProcessName
        /// </summary>
        public List<ProcessInformation> ListProcessInfo
        {
            get;
            set;
        }

        public List<decimal> ListRequestID
        {
            get;
            set;
        }

        /// <summary>
        /// WorkingTypeList
        /// </summary>
        public List<string> WorkingTypeList { get; set; }

        public List<TrackingInfoEx> ListTrackingInfo { get; set; }
    }
}