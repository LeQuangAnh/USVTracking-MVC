﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class DBTrackingEntities : DbContext
    {
        public DBTrackingEntities()
            : base("name=UVTrackingInfoEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<BaselineManagement> BaselineManagement { get; set; }
        public virtual DbSet<FunctionMaster> FunctionMaster { get; set; }
        public virtual DbSet<FunctionSizeInfo> FunctionSizeInfo { get; set; }
        public virtual DbSet<HolidayMaster> HolidayMaster { get; set; }
        public virtual DbSet<MappingProductivityProcess> MappingProductivityProcess { get; set; }
        public virtual DbSet<MappingTrackingAndTimeRecord> MappingTrackingAndTimeRecord { get; set; }
        public virtual DbSet<ProductivityPhaseMaster> ProductivityPhaseMaster { get; set; }
        public virtual DbSet<ProjectMaster> ProjectMaster { get; set; }
        public virtual DbSet<RequestSchedule> RequestSchedule { get; set; }
        public virtual DbSet<Schedule> Schedule { get; set; }
        public virtual DbSet<ScheduleDev> ScheduleDev { get; set; }
        public virtual DbSet<TimeRecordPhase> TimeRecordPhase { get; set; }
        public virtual DbSet<TimeRecordPhaseProcess> TimeRecordPhaseProcess { get; set; }
        public virtual DbSet<TimeRecordProcess> TimeRecordProcess { get; set; }
        public virtual DbSet<TimeRecordProject> TimeRecordProject { get; set; }
        public virtual DbSet<TimeRecordProjectUser> TimeRecordProjectUser { get; set; }
        public virtual DbSet<TimeRecordWorkingType> TimeRecordWorkingType { get; set; }
        public virtual DbSet<TrackingInfo> TrackingInfo { get; set; }
        public virtual DbSet<TrackingPhase> TrackingPhase { get; set; }
        public virtual DbSet<TrackingProcess> TrackingProcess { get; set; }
        public virtual DbSet<TrackingWBSPhaseProcess> TrackingWBSPhaseProcess { get; set; }
        public virtual DbSet<UserMaster> UserMaster { get; set; }
        public virtual DbSet<WBSMaster> WBSMaster { get; set; }
        public virtual DbSet<ProductivityView> ProductivityView { get; set; }
        public virtual DbSet<ProgressTrackingView> ProgressTrackingView { get; set; }
        public virtual DbSet<ScheduleView> ScheduleView { get; set; }
    
        public virtual ObjectResult<GetScheduleInfo_Result> GetScheduleInfo(Nullable<System.DateTime> reportDate)
        {
            var reportDateParameter = reportDate.HasValue ?
                new ObjectParameter("ReportDate", reportDate) :
                new ObjectParameter("ReportDate", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetScheduleInfo_Result>("GetScheduleInfo", reportDateParameter);
        }
    }
}
