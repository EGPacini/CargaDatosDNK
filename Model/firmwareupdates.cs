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
    
    public partial class firmwareupdates
    {
        public int ID { get; set; }
        public Nullable<int> LoggerID { get; set; }
        public string RequiredVersion { get; set; }
        public Nullable<System.DateTime> DateUpdateStarted { get; set; }
        public Nullable<System.DateTime> DateOfLastCommand { get; set; }
        public Nullable<int> NumTries { get; set; }
        public Nullable<int> status { get; set; }
    
        public virtual loggers loggers { get; set; }
    }
}
