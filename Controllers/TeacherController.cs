using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SIMS.DataTier.BusinessObject;
using SIMS.DataTier.DataAccess;
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
    public class TeacherController : Controller
    {
        ClassRepository classRepo = new ClassRepository();
        GradeRepository gradeRepo = new GradeRepository();
        FeedbackRepository feedbackRepo = new FeedbackRepository();


        [HttpPost("Feedback")]
        public IActionResult FeedbackStudent([FromBody] object obj)
        {
            Console.WriteLine(obj.ToString());
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var data = JsonConvert.DeserializeObject<Feedback>(obj.ToString());
            feedbackRepo.Update(data);
            return Json(data);
        }

        [HttpGet("GetFeedbacks")]
        public IEnumerable<Feedback> GetFeedbacks([FromQuery] string email)
        {
            var id = UserRepository.GetIdFromMail(email);
            return feedbackRepo.FindAll(id);
        }


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
        public IEnumerable<Grade> GetGrade([FromQuery] string id, string classId, string email)
        {
            Console.WriteLine(id);
            var teacherId = UserRepository.GetIdFromMail(email);
            return gradeRepo.FindGrade(id,classId,teacherId);
        }

        [HttpPost("GradeStudent")]
        public IActionResult GradeStudent([FromBody] Object obj)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var data = JsonConvert.DeserializeObject<Grade>(obj.ToString());
            if (data.Grade1 == null)
            {
                ModelState.AddModelError("grade", "Grades cannot be empty!");
                return BadRequest(ModelState);
            }
            if(data.Grade1 < 0 || data.Grade1 > 10)
            {
                ModelState.AddModelError("grade", "Grades must be between 0 and 10!");
                return BadRequest(ModelState);
            }
            gradeRepo.Update(data);
            return Json(data);
        }

        [HttpGet("GetTeacherInfo")]
        public Teacher GetStudentInfo([FromQuery] string email)
        {
            return UserRepository.GetTeacherFromMail(email);
        }
    }
}
