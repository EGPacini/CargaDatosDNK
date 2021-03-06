//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WindowsFormsApp1.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class AccountLeakOptions
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public Nullable<double> Radius { get; set; }
        public Nullable<int> RadiusUnits { get; set; }
        public Nullable<System.DateTime> TimeToRunAutoCorrelation { get; set; }
        public Nullable<int> LastRecordingID { get; set; }
        public Nullable<int> UseDefaultOptionIfNoPipe { get; set; }
        public Nullable<bool> IsEnabled { get; set; }
        public string ServerAddress { get; set; }
        public Nullable<int> RadiusUnitsRec { get; set; }
        public Nullable<double> RadiusRec { get; set; }
        public Nullable<bool> AutoRequestRecording { get; set; }
        public Nullable<int> RepeatRecording { get; set; }
        public Nullable<int> ContinuousDaysInLeak { get; set; }
        public Nullable<int> LeakCategoryHigh { get; set; }
        public Nullable<int> LeakCategoryMedium { get; set; }
        public Nullable<int> LeakCategoryLow { get; set; }
        public Nullable<int> CorrelationThreshold { get; set; }
        public Nullable<bool> EnableLeakCategorisation { get; set; }
        public Nullable<int> AutoCorrelationOption { get; set; }
        public Nullable<bool> CachePipesInProgress { get; set; }
        public Nullable<System.DateTime> CachePipesStartRunTime { get; set; }
        public Nullable<bool> AutoCorrelationInProgress { get; set; }
        public Nullable<bool> LoggerRecordSetInProgress { get; set; }
        public Nullable<bool> SetLoggerRecordings { get; set; }
        public Nullable<System.DateTime> TimetoSetLoggersToRecord { get; set; }
        public Nullable<bool> RevertToLinearCorrelation { get; set; }
        public string CostPer1000 { get; set; }
    
        public virtual accounts accounts { get; set; }
        public virtual unitslookup unitslookup { get; set; }
        public virtual accounts accounts1 { get; set; }
    }
}
