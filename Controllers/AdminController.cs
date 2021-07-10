using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SIMS.DataTier.BusinessObject;
using SIMS.DataTier.Infrastructure;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SIMS.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AdminController : Controller
    {
        StudentRepository stuRepo = new StudentRepository();
        TeacherRepository teacherRepo = new TeacherRepository();
        CourseRepository courseRepo = new CourseRepository();
        ClassRepository classRepo = new ClassRepository();

        [HttpPost("RemoveClass")]
        public IActionResult RemoveClass([FromBody] object obj)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var data = JsonConvert.DeserializeObject<Class>(obj.ToString());
            Debug.WriteLine(data);
            classRepo.Delete(data);
            return Json(data);
        }


        [HttpPost("UpdateClass")]
        public IActionResult UpdateClass([FromBody] object obj)
        {
            Console.WriteLine(obj.ToString());
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var data = JsonConvert.DeserializeObject<List<Class>>(obj.ToString());
            data.ForEach(c => Console.WriteLine(c.CourseId));
            classRepo.UpdateList(data);
            return Json(data);
        }


        [HttpPost("RemoveCourse")]
        public IActionResult RemoveCourse([FromBody] object obj)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var data = JsonConvert.DeserializeObject<Course>(obj.ToString());
            Debug.WriteLine(data);
            courseRepo.Delete(data);
            return Json(data);
        }


        [HttpPost("UpdateCourse")]
        public IActionResult UpdateCourse([FromBody] object obj)
        {
            Console.WriteLine(obj.ToString());
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var data = JsonConvert.DeserializeObject<List<Course>>(obj.ToString());
            data.ForEach(c => Console.WriteLine(c.CourseId));
            courseRepo.UpdateList(data);
            return Json(data);
        }


        [HttpPost("RemoveTeacher")]
        public IActionResult RemoveTeacher([FromBody] object obj)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var data = JsonConvert.DeserializeObject<Teacher>(obj.ToString());
            teacherRepo.Delete(data);
            return Json(data);
        }


        [HttpPost("UpdateTeacher")]
        public IActionResult UpdateTeacher([FromBody] object obj)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var data = JsonConvert.DeserializeObject<Teacher>(obj.ToString());
            teacherRepo.Update(data);
            return Json(data);
        }


        [HttpPost("RemoveStudent")]
        public IActionResult RemoveStudent([FromBody] object obj)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var data = JsonConvert.DeserializeObject<Student>(obj.ToString());
            stuRepo.Delete(data);
            return Json(data);
        }

        [HttpPost("PromoteStudent")]
        public IActionResult PromoteStudent([FromBody] object obj)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var data = JsonConvert.DeserializeObject<Student>(obj.ToString());
            teacherRepo.Promote(data);
            return Json(data);
        }


        [HttpPost("AuthoriseStudent")]
        public IActionResult AuthoriseStudent([FromBody] object obj)
        {
            Console.WriteLine(obj.ToString());
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var data = JsonConvert.DeserializeObject<Student>(obj.ToString());
            stuRepo.Authorise(data);
            return Json(data);
        }

        [HttpPost("UpdateStudent")]
        public IActionResult UpdateStudent([FromBody] object obj)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var data = JsonConvert.DeserializeObject<Student>(obj.ToString());
            stuRepo.Update(data);
            return Json(data);
        }

        [HttpGet("GetStudents")]
        public IEnumerable<Student> GetStudents()
        {
            return stuRepo.FindAll();
        }

        [HttpGet("GetTeachers")]
        public IEnumerable<Teacher> GetTeachers()
        {
            return teacherRepo.FindAll();
        }
    }
}
