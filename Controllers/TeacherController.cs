using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SIMS.DataTier.BusinessObject;
using SIMS.DataTier.Infrastructure;
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
        GradeRepository gradeRepo = new GradeRepository();

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


        [HttpGet("GetGrade")]
        public IEnumerable<Grade> GetGrade([FromQuery] string id)
        {
            Console.WriteLine(id);
            return gradeRepo.Find(id);
        }

        [HttpPost("GradeStudent")]
        public void GradeStudent([FromBody] Object obj)
        {
            Console.WriteLine(obj.ToString());
            var data = JsonConvert.DeserializeObject<Grade>(obj.ToString());
            Console.WriteLine(data.ToString());
            gradeRepo.Update(data);
        }
        

    }
}
