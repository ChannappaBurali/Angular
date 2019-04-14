using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LoginAPI.Models;

namespace LoginAPI.Controllers
{
    public class LoginController : ApiController
    {

        //For user login   
        [Route("Api/Login/UserLogin")]
        [HttpPost]
        public Response Login(Login Lg)
        {
            EmployeeEntities DB = new EmployeeEntities();
            //var Obj = DB.Usp_Login(Lg.UserName, Lg.Password).ToList<Usp_Login_Result>().FirstOrDefault();
            //  var Obj = DB.t_Users(Lg.UserName, Lg.Password).ToList<Usp_Login_Result>().FirstOrDefault();
            if (Lg != null) { 
            var Obj = DB.t_Users.Where(a => a.EMail.Equals(Lg.EMail) && a.Password.Equals(Lg.Password)).FirstOrDefault();
            if (Obj==null)
                return new Response { Status = "Invalid", Message = "Invalid User." };            
            else
                return new Response { Status = "Success", Message = Lg.EMail };
            }
            return new Response { Status = "Invalid", Message = "Invalid User." };
        }

        //For new user Registration  
        [Route("Api/Login/createcontact")]
        [HttpPost]
        public object createcontact(Registration Lvm)
        {
            if (Lvm != null) { 
            try
            {
                EmployeeEntities db = new EmployeeEntities();
                t_Users tm = new t_Users();
                
                    tm.EMail = Lvm.EMail;
                    tm.Password = Lvm.Password;
                   tm.IsActive = true;
                tm.CreatedDate = DateTime.Now;                    
                    db.t_Users.Add(tm);
                    db.SaveChanges();
                int? id = (
        from p in db.t_Users
        orderby p.UserId descending
        select p.UserId
         ).Take(1).SingleOrDefault();

                t_User_PersonalDetails tps = new t_User_PersonalDetails();
                tps.UserId = (int)id;
                tps.FName = Lvm.FName;
                tps.LName = Lvm.LName;
                tps.Gender = Lvm.Gender;
                tps.Phone = Lvm.Phone;
                tps.DOB = Lvm.DOB;
                tps.Address = Lvm.Address;
                tps.CreatedDate = DateTime.Now;

                db.t_User_PersonalDetails.Add(tps);
                db.SaveChanges();

                return new Response
                    { Status = "Success", Message = "SuccessFully Saved." };
               
            }
            catch (Exception)
            {
                throw;
                
            }
            }
            else {
                return new Response
                { Status = "Error", Message = "Invalid Data." };
            }
        }

        [Route("Api/Login/GetPersonalDt")]
        [HttpGet]
        public IEnumerable<EmpployeeMaster> GetPersonalDt()
        {
            EmployeeEntities db = new EmployeeEntities();
            List<EmpployeeMaster> Listr = new List<EmpployeeMaster>();
            var JoinResult = (from p in db.t_Users
                              join t in db.t_User_PersonalDetails
                              on p.UserId equals t.UserId
                              select new
                              {
                                  UserPersonalId = t.UserPersonalId,
                                  FName = t.FName,
                                  LName = t.LName,
                                  Gender = t.Gender,
                                  Phone = t.Phone,
                                  DOB = t.DOB,
                                  EMail = p.EMail,
                              }
                             ).ToList();
            foreach (var item in JoinResult)
            {
                EmpployeeMaster cu = new EmpployeeMaster();
                cu.UserPersonalId = item.UserPersonalId;
                cu.EMail = item.EMail;
                cu.Gender = item.Gender;
                cu.FName = item.FName;
                cu.LName = item.LName;
                cu.Phone = item.Phone;
                cu.DOB = item.DOB;
                Listr.Add(cu);
            }
            return Listr;
        }

        public IEnumerable<EmpployeeMaster> Edit(string id)
        {
            int pid = Convert.ToInt32(id);
            EmployeeEntities db = new EmployeeEntities();
            t_User_PersonalDetails rg = db.t_User_PersonalDetails.Find(pid);
            List<EmpployeeMaster> Listr = new List<EmpployeeMaster>();
            int uid = rg.UserId;
            t_Users rgt = db.t_Users.Find(uid);
            int uid1 = rgt.UserId;

            var JoinResult = (from p in db.t_Users
                              join t in db.t_User_PersonalDetails
                              on p.UserId equals t.UserId
                              where p.UserId == uid1
                              select new
                              {
                                  UserPersonalId = t.UserPersonalId,
                                  FName = t.FName,
                                  LName = t.LName,
                                  Gender = t.Gender,
                                  Phone = t.Phone,
                                  DOB = t.DOB,
                                  EMail = p.EMail,
                              }
                              ).ToList();

            foreach (var item in JoinResult)
            {
                EmpployeeMaster cu = new EmpployeeMaster();
                cu.UserPersonalId = item.UserPersonalId;
                cu.EMail = item.EMail;
                cu.Gender = item.Gender;
                cu.FName = item.FName;
                cu.LName = item.LName;
                cu.Phone = item.Phone;
                cu.DOB = item.DOB;
                Listr.Add(cu);
            }
            return Listr;
            //db.t_User_PersonalDetails.ToList();
        }



    }

}