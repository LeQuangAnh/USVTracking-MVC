using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Web;

namespace USVTracking_MVC.Models
{
    public class SingleTaskModel
    {
        public string Description { get; set; }

        /// <summary>
        /// Get or set WBS name
        /// </summary>
        public decimal? WBSNo { get; set; }

        /// <summary>
        /// Get or set WBS name
        /// </summary>
        public string WBSName { get; set; }

        /// <summary>
        /// Get or set date
        /// </summary>
        [Required(ErrorMessage = "Date is not in correct format")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        /// <summary>
        /// Get or set working type
        /// </summary>
        public Dictionary<string, string> WorkingTypeList { get; set; }

        /// <summary>
        /// Get or set working type name
        /// </summary>
        [Required(ErrorMessage = "Working type is required")]
        public string WorkingTypeName { get; set; }

        /// <summary>
        /// Get or set working phase
        /// </summary>
        [Required]
        public string Phase { get; set; }

        /// <summary>
        /// Get or set working process
        /// </summary>
        public Dictionary<string, string> ProcessList { get; set; }

        /// <summary>
        /// Get or set process name
        /// </summary>
        [Required]
        public string ProcessName { get; set; }

        /// <summary>
        /// Get or set duration
        /// </summary>
        [Required(ErrorMessage = "Duration must be greater than 0 and lesser than 8 and is multiple of 0.5")]
        [Range(0, 8)]
        public double? Duration { get; set; }

        /// <summary>
        /// Get or set progress
        /// </summary>
        [Required(ErrorMessage = "Progress must be greater than 0 and lesser than 100")]
        [Range(0, 100)]
        public decimal? Progress { get; set; }

        /// <summary>
        /// Get or set function name
        /// </summary>
        public string FunctionCode { get; set; }

        /// <summary>
        /// Get or set function name
        /// </summary>
        public string FunctionName { get; set; }

        /// <summary>
        /// Get or set function include function code and function name
        /// </summary>
        public string Function { get; set; }

        /// <summary>
        /// Get or set time record project name
        /// </summary>
        public string ProjectName { get; set; }

        /// <summary>
        /// List of TrackingInfo
        /// </summary>
        public List<TrackingInfoEx> ListTrackingInfo { get; set; }
    }

    public class TrackingInfoEx : TrackingInfo
    {
        public String FullName { set; get; }
        public TrackingInfo TrackInfoBase
        {
            set
            {
                PropertyInfo[] propertInf = value.GetType().GetProperties();
                foreach (PropertyInfo prop in propertInf)
                {
                    try
                    {
                        object val = prop.GetValue(value, null);
                        prop.SetValue(this, val, null);
                    }
                    catch (Exception e)
                    {
                        Console.Out.Write(e.StackTrace);
                    }
                }

            }
        }
        public TrackingInfoEx()
            : base()
        {
        }
    }
}