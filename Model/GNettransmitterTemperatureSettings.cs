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
    
    public partial class GNettransmitterTemperatureSettings
    {
        public int Id { get; set; }
        public Nullable<int> TransmitterChannelId { get; set; }
        public Nullable<System.DateTime> UpdateTime { get; set; }
        public string ChannelType { get; set; }
        public Nullable<double> TargetTemperature { get; set; }
        public Nullable<int> DurationMins { get; set; }
        public Nullable<System.DateTime> LastOkTime { get; set; }
    }
}
