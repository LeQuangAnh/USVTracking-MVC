//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace USVTracking_MVC.Models
{
    using System;
    
    public partial class GetScheduleInfo_Result
    {
        public string UserID { get; set; }
        public string InitialName { get; set; }
        public decimal WBSNo { get; set; }
        public string WBSName { get; set; }
        public string FunctionCode { get; set; }
        public string ProjectName { get; set; }
        public Nullable<System.DateTime> PlanStart { get; set; }
        public Nullable<System.DateTime> ActualStart { get; set; }
        public Nullable<System.DateTime> PlanFinish { get; set; }
        public Nullable<System.DateTime> ActualFinish { get; set; }
        public Nullable<double> PlanEffort { get; set; }
        public double ActualEffort { get; set; }
        public decimal Complete { get; set; }
        public Nullable<byte> CancelledFlag { get; set; }
    }
}
