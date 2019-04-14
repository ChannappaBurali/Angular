using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoginAPI.Models
{
    public class Login
    {
        public string EMail { set; get; }
        public string Password { set; get; }
    }
    public class Registration : EmpployeeMaster { }

    public class EmpployeeMaster
    {
        public string Password { set; get; }
        public string EMail { get; set; }
        public int UserPersonalId { get; set; }
        public int UserId { get; set; }
        public string FName { get; set; }
        public string LName { get; set; }
        public string Phone { get; set; }
        public bool Gender { get; set; }
        public bool IsActive { get; set; }
        public System.DateTime DOB { get; set; }
        public string Address { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public Nullable<int> ModifiedBy { get; set; }
        public Nullable<System.DateTime> LastUpdatedDate { get; set; }
    }
}