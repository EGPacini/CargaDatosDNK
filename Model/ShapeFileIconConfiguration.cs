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
    
    public partial class ShapeFileIconConfiguration
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ShapeFileIconConfiguration()
        {
            this.ShapeFiles = new HashSet<ShapeFiles>();
        }
    
        public int Id { get; set; }
        public int AccountID { get; set; }
        public string Description { get; set; }
        public string IconUrl { get; set; }
        public bool Deleted { get; set; }
    
        public virtual accounts accounts { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ShapeFiles> ShapeFiles { get; set; }
    }
}
