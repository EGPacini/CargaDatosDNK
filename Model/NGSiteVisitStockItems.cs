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
    
    public partial class NGSiteVisitStockItems
    {
        public int ID { get; set; }
        public string NGMReference { get; set; }
        public string StockCode { get; set; }
        public System.DateTime CreatedDate { get; set; }
    
        public virtual NGSiteVisit NGSiteVisit { get; set; }
        public virtual NGStockItems NGStockItems { get; set; }
    }
}
