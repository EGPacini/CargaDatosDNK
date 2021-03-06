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
    
    public partial class loggers
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public loggers()
        {
            this.DatFiles = new HashSet<DatFiles>();
            this.firmwareupdates = new HashSet<firmwareupdates>();
            this.leakconfirmationassociation = new HashSet<leakconfirmationassociation>();
            this.LoggerAccessTechnology = new HashSet<LoggerAccessTechnology>();
            this.LoggerCommandHistory = new HashSet<LoggerCommandHistory>();
            this.LoggerFilterConfiguration = new HashSet<LoggerFilterConfiguration>();
            this.LoggerLevelAndSpread = new HashSet<LoggerLevelAndSpread>();
            this.SiteLoggerUserActions = new HashSet<SiteLoggerUserActions>();
            this.sites = new HashSet<sites>();
        }
    
        public int ID { get; set; }
        public string LoggerType { get; set; }
        public string LoggerSoftware { get; set; }
        public string LoggerSerialNumber { get; set; }
        public string LoggerSMSNumber { get; set; }
        public string LoggerGSMNumber { get; set; }
        public Nullable<int> OwnerAccount { get; set; }
        public Nullable<System.DateTime> LastCallIn { get; set; }
        public Nullable<System.DateTime> RST { get; set; }
        public Nullable<int> SignalLevel { get; set; }
        public Nullable<double> BatteryLevel { get; set; }
        public Nullable<int> LogRateMs { get; set; }
        public Nullable<int> NetID { get; set; }
        public Nullable<int> LAC { get; set; }
        public Nullable<int> CellID { get; set; }
        public Nullable<double> MastLongitude { get; set; }
        public Nullable<double> MastLatitude { get; set; }
        public Nullable<long> DataCount { get; set; }
        public string Notes { get; set; }
        public string LastMessageType { get; set; }
        public Nullable<int> CallFrequency { get; set; }
        public Nullable<bool> IsRoaming { get; set; }
        public Nullable<int> MonthlyDownloadLimit { get; set; }
        public Nullable<int> SMSCredits { get; set; }
        public string LoggerNetwork { get; set; }
        public Nullable<System.DateTime> RTC { get; set; }
        public Nullable<int> TA { get; set; }
        public Nullable<int> LastCallStatus { get; set; }
        public Nullable<int> Watchdogs { get; set; }
        public Nullable<System.DateTime> ServiceDate { get; set; }
        public Nullable<System.DateTime> WarrantyExpiry { get; set; }
        public string ServiceDescription { get; set; }
        public Nullable<decimal> EquipmentServiceCost { get; set; }
        public Nullable<System.DateTime> BatteryReplacement { get; set; }
        public Nullable<System.DateTime> BatteryReplacementNext { get; set; }
        public Nullable<byte> UTCOffset { get; set; }
        public Nullable<bool> ExternalBattery { get; set; }
        public Nullable<double> FlightTimeSecs { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<int> NetRegistrationTime { get; set; }
        public string Imei { get; set; }
        public string Imsi { get; set; }
        public Nullable<System.DateTime> LoggerRET { get; set; }
        public Nullable<bool> ManualRecordings { get; set; }
        public Nullable<bool> SecureModeActive { get; set; }
        public string CustomerLoggerSerial { get; set; }
        public string MacAddress { get; set; }
        public string MasterPassword { get; set; }
        public string SecurityTimestamp { get; set; }
        public Nullable<int> LoggerTypeId { get; set; }
        public Nullable<System.DateTime> SimExpiry { get; set; }
        public Nullable<System.DateTime> CellLookupTime { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DatFiles> DatFiles { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<firmwareupdates> firmwareupdates { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<leakconfirmationassociation> leakconfirmationassociation { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LoggerAccessTechnology> LoggerAccessTechnology { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LoggerCommandHistory> LoggerCommandHistory { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LoggerFilterConfiguration> LoggerFilterConfiguration { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LoggerLevelAndSpread> LoggerLevelAndSpread { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SiteLoggerUserActions> SiteLoggerUserActions { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<sites> sites { get; set; }
    }
}
