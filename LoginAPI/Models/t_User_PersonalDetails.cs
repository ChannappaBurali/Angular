//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LoginAPI.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class t_User_PersonalDetails
    {
        public int UserPersonalId { get; set; }
        public int UserId { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string Phone { get; set; }
        public bool Gender { get; set; }
        public System.DateTime DOB { get; set; }
        public string Address { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> LastUpdatedDate { get; set; }
    
        public virtual t_Users t_Users { get; set; }
    }
}
