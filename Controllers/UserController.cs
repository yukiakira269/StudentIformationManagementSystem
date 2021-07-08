using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SIMS.DataTier.BusinessObject;
using SIMS.DataTier.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIMS.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        [HttpPost]
        public string SetRole([FromBody] object obj)
        {
            using SIMSContext ctx = new SIMSContext();
            string mail = obj.ToString();
            string id = UserRepository.GetIdFromMail(mail.ToString());
            //No ID found
            if (id == null)
            {
                var stu = ctx.Students.SingleOrDefault(s => s.Email.Equals(mail));
                //Add a new student acc by default
                if (stu == null)
                {
                    try
                    {
                        ctx.Parents.Add(new Parent
                        {
                            StudentId = mail,
                            Balance = null,
                            Email = "",
                            Phone = null,
                        });
                        ctx.Students.Add(new Student
                        {
                            StudentId = mail,
                            Name = "",
                            Email = mail,
                            Address = "",
                            Avatar = "",
                            Dob = null,
                            Gpa = null,
                            ParentsPhone = null,
                        });
                        
                        ctx.SaveChanges();
                        return JsonConvert.SerializeObject("N");
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
                //Awaiting authorisation
                else if (stu != null && stu.Email.Contains("@"))
                {
                    return JsonConvert.SerializeObject("N");
                }
                else
                {
                    return JsonConvert.SerializeObject(stu.StudentId.Substring(0, 2));
                }
            }
            else
            {
                return JsonConvert.SerializeObject(id.Substring(0, 2));
             
            }


        }
    }
}

