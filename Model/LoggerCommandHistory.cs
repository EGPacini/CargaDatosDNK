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
    
    public partial class LoggerCommandHistory
    {
        public int ID { get; set; }
        public int LoggerID { get; set; }
        public int CommandType { get; set; }
        public bool CommandFileCreated { get; set; }
        public System.DateTime CommandStartDate { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string Error { get; set; }
    
        public virtual loggers loggers { get; set; }
    }
}
