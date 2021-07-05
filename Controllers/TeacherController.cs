using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SIMS.DataTier.Infrastructure;
using SIMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SIMS.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        ClassRepository classRepo = new ClassRepository();
        StudentRepository stuRepo = new StudentRepository();

        [HttpGet("GetClassList")]
        public IEnumerable<Class> GetClassList([FromQuery] string email)
        {
            return classRepo.FindAll(email).ToList();
        }


        [HttpGet("GetStudentList")]
        public IEnumerable<Student> GetStudentList([FromQuery] string classId)
        {
            return classRepo.GetStudentList(classId).ToList();
        }

        [HttpPost("GradeStudent")]
        public void GradeStudent([FromBody] Object obj)
        {
            var data = JsonConvert.DeserializeObject<grade>(obj.ToString());
            Console.WriteLine(data.Gpa);
        }
        class grade
        {
            public string Id { get; set; }
            public string Gpa { get; set; }
        }

    }
}
