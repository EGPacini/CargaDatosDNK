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
    
    public partial class messages
    {
        public long ID { get; set; }
        public Nullable<byte> flags { get; set; }
        public string siteid { get; set; }
        public string smsnumber { get; set; }
        public Nullable<byte> battery { get; set; }
        public Nullable<byte> csq { get; set; }
        public byte[] data { get; set; }
        public Nullable<System.DateTime> rxtime { get; set; }
    }
}
