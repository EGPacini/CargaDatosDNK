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
    
    public partial class GDImportDataFileLog
    {
        public int ID { get; set; }
        public int ImportFileID { get; set; }
        public System.DateTime CreationDate { get; set; }
        public short Status { get; set; }
        public string Error { get; set; }
        public string Description { get; set; }
    
        public virtual GDImportDataFiles GDImportDataFiles { get; set; }
    }
}
