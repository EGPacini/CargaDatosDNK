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
    
    public partial class ShapeFiles
    {
        public int Id { get; set; }
        public int AccountID { get; set; }
        public string FileName { get; set; }
        public string Description { get; set; }
        public Nullable<System.DateTime> UploadDate { get; set; }
        public bool Enabled { get; set; }
        public bool Deleted { get; set; }
        public string SiteIdMetaName { get; set; }
        public string Validated { get; set; }
        public string ValidatedAssets { get; set; }
        public Nullable<int> ShapeFileIconConfigurationId { get; set; }
        public string PipeMaterialMetaName { get; set; }
        public string PipeDiameterMetaName { get; set; }
        public string PipeLengthMetaName { get; set; }
        public Nullable<int> MeasurementUnits { get; set; }
    
        public virtual accounts accounts { get; set; }
        public virtual ShapeFileIconConfiguration ShapeFileIconConfiguration { get; set; }
    }
}
