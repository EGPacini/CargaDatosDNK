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
    
    public partial class accounts
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public accounts()
        {
            this.AccountLeakOptions = new HashSet<AccountLeakOptions>();
            this.AccountLeakOptions1 = new HashSet<AccountLeakOptions>();
            this.ShapeFileIconConfiguration = new HashSet<ShapeFileIconConfiguration>();
            this.alarmforwarding = new HashSet<alarmforwarding>();
            this.correlationAccountMeta = new HashSet<correlationAccountMeta>();
            this.correlationPath = new HashSet<correlationPath>();
            this.fleetreportoptions = new HashSet<fleetreportoptions>();
            this.ShapeFiles = new HashSet<ShapeFiles>();
            this.SiteLoggerUserActions = new HashSet<SiteLoggerUserActions>();
            this.SiteLoggerUserActions1 = new HashSet<SiteLoggerUserActions>();
        }
    
        public int ID { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
        public Nullable<int> DatagateID { get; set; }
        public Nullable<int> Parent { get; set; }
        public Nullable<int> AccountType { get; set; }
        public string AccountName { get; set; }
        public string AccountUserName { get; set; }
        public string AccountPassword { get; set; }
        public Nullable<int> Language { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        public Nullable<System.DateTime> DateOfLastLogin { get; set; }
        public Nullable<int> TimeOffset { get; set; }
        public string Logo { get; set; }
        public string Notes { get; set; }
        public Nullable<int> quietdays { get; set; }
        public Nullable<bool> DSTEnabled { get; set; }
        public Nullable<int> LeakDetectionMode { get; set; }
        public Nullable<double> CentreLongitude { get; set; }
        public Nullable<double> CentreLatitude { get; set; }
        public Nullable<int> QuietMins { get; set; }
        public Nullable<bool> EnableCustomerSideLeak { get; set; }
        public Nullable<bool> EnableStitching { get; set; }
        public Nullable<int> MinimumPhotoNumber { get; set; }
        public Nullable<bool> UseInternalSiteID { get; set; }
        public Nullable<int> AccountTypeID { get; set; }
        public Nullable<int> DisplayAccountTypes { get; set; }
        public Nullable<bool> ShowQuietLogger { get; set; }
        public Nullable<bool> EnableCNS { get; set; }
        public bool EnableLoggerModePRV { get; set; }
        public Nullable<int> AverageNoiseChangeThreshold { get; set; }
        public Nullable<bool> DaylightSavings { get; set; }
        public Nullable<double> MinLongitude { get; set; }
        public Nullable<double> MaxLongitude { get; set; }
        public Nullable<double> MinLatitude { get; set; }
        public Nullable<double> MaxLatitude { get; set; }
        public Nullable<bool> Enable2FA { get; set; }
        public Nullable<int> Mode2FA { get; set; }
        public Nullable<int> ModeWarningDays { get; set; }
        public bool Archived { get; set; }
        public Nullable<int> LevelAndSpreadUnchangedWarningDays { get; set; }
        public Nullable<int> Mode2FAIntervalDays { get; set; }
        public Nullable<bool> EnableStatusDurationAlarm { get; set; }
        public Nullable<int> StatusDurationAlarmThreshold { get; set; }
        public Nullable<bool> EnableSSO { get; set; }
        public string SSOTenantId { get; set; }
        public string SSODomainHint { get; set; }
        public string SSOClientId { get; set; }
        public bool ExtendedRecordingDaysEnabled { get; set; }
        public string DefaultAccountListSort { get; set; }
        public Nullable<System.TimeSpan> start_mnf { get; set; }
        public Nullable<System.TimeSpan> end_MNF { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AccountLeakOptions> AccountLeakOptions { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AccountLeakOptions> AccountLeakOptions1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ShapeFileIconConfiguration> ShapeFileIconConfiguration { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<alarmforwarding> alarmforwarding { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<correlationAccountMeta> correlationAccountMeta { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<correlationPath> correlationPath { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<fleetreportoptions> fleetreportoptions { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ShapeFiles> ShapeFiles { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SiteLoggerUserActions> SiteLoggerUserActions { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SiteLoggerUserActions> SiteLoggerUserActions1 { get; set; }
    }
}
