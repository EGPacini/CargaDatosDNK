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
    
    public partial class GNettransmitters
    {
        public int Id { get; set; }
        public Nullable<int> TransmitterId { get; set; }
        public string TxType { get; set; }
        public string TransmitterName { get; set; }
        public Nullable<System.DateTime> LastCallIn { get; set; }
        public Nullable<int> SignalLevel { get; set; }
        public Nullable<int> CustomerID { get; set; }
        public Nullable<int> LocationID { get; set; }
        public string Notes { get; set; }
        public string Channels { get; set; }
        public string HubId { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
    }
}
