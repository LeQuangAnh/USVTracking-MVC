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
    
    public partial class TimeRecordProcess
    {
        public string TimeRecordProcessID { get; set; }
        public string TimeRecordProcessName { get; set; }
        public Nullable<byte> GM { get; set; }
        public Nullable<byte> PL { get; set; }
        public Nullable<byte> DEV { get; set; }
        public Nullable<byte> QA { get; set; }
        public Nullable<byte> OTHERS { get; set; }
    }
}