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
    
    public partial class correlationAccountMeta
    {
        public int Id { get; set; }
        public Nullable<int> accountId { get; set; }
        public Nullable<int> lastrecordingID { get; set; }
        public string loggerHash { get; set; }
        public string shapeFileHash { get; set; }
        public Nullable<System.DateTime> created { get; set; }
    
        public virtual accounts accounts { get; set; }
        public virtual loggerrecordings loggerrecordings { get; set; }
    }
}
