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
    
    public partial class GNettransmitterFlushEvents
    {
        public int Id { get; set; }
        public Nullable<int> TransmitterId { get; set; }
        public string FlushType { get; set; }
        public Nullable<System.DateTime> FlushStartDate { get; set; }
        public Nullable<System.DateTime> FlushEndDate { get; set; }
        public Nullable<double> FlushStartTemp { get; set; }
        public Nullable<double> FlushEndTemp { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
    }
}
