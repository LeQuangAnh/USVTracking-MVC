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
    using System.Collections.Generic;
    
    public partial class Schedule
    {
        public string ProjectName { get; set; }
        public string FunctionCode { get; set; }
        public decimal WBSNo { get; set; }
        public Nullable<System.DateTime> PlanStart { get; set; }
        public Nullable<System.DateTime> PlanFinish { get; set; }
        public Nullable<double> PlanEffort { get; set; }
        public Nullable<byte> CancelledFlag { get; set; }
        public byte DelFlag { get; set; }
    }
}