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
    
    public partial class DeviceSummary
    {
        public int ID { get; set; }
        public string Smsnumber { get; set; }
        public Nullable<int> LoggerID { get; set; }
        public System.DateTime DateTime { get; set; }
        public Nullable<System.DateTime> LastCallIn { get; set; }
        public int CallIns { get; set; }
        public Nullable<int> BatteryAverage { get; set; }
        public Nullable<byte> BatteryMin { get; set; }
        public Nullable<byte> BatteryMax { get; set; }
        public Nullable<int> CsqAverage { get; set; }
        public Nullable<byte> CsqMin { get; set; }
        public Nullable<byte> CsqMax { get; set; }
        public int NumMessages { get; set; }
    }
}