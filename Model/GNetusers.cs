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
    
    public partial class GNetusers
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public Nullable<int> CustomerID { get; set; }
        public Nullable<int> Role { get; set; }
        public Nullable<int> SiteId { get; set; }
        public string Language { get; set; }
        public string Country { get; set; }
        public Nullable<bool> UserLocked { get; set; }
        public Nullable<System.DateTime> LastLogin { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<bool> Active { get; set; }
        public string ProfileName { get; set; }
    }
}
