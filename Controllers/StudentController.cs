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
    public class StudentController : Controller
    {
        CourseRepository courseRepo = new CourseRepository();
        ClassRepository classRepo = new ClassRepository();
        GradeRepository gradeRepo = new GradeRepository();

        [HttpGet("GetCourseList")]
        public IEnumerable<Course> GetCourseList()
        {
            return courseRepo.FindAll().OrderBy(c => c.CourseId).ToList();
        }

        [HttpGet("GetRegisteredCourses")]
        public IEnumerable<Course> GetRegisteredCourses([FromQuery] string email)
        {
            Student std = (Student)UserRepository.GetUserFromMail(email);
            var registeredClasses = classRepo.GetClassesByStudentId(std.StudentId).ToList();

            var registeredCourses = new List<Course>();
            foreach (Class cls in registeredClasses)
            {
                registeredCourses.Add(courseRepo.GetCourse(cls.CourseId));
            }

            return registeredCourses;
        }

        [HttpGet("GetRegisteredClasses")]
        public IEnumerable<Class> GetRegisteredClasses([FromQuery] string email)
        {
            Student std = (Student)UserRepository.GetUserFromMail(email);
            var registeredClasses = classRepo.GetClassesByStudentId(std.StudentId).ToList();

            var classes = new List<Class>();
            foreach (Class cls in registeredClasses)
            {
                classes.Add(cls);
            }
            return classes;
        }

        [HttpGet("GetGradeList")]
        public IEnumerable<Grade> GetGradeList([FromQuery] string email)
        {
            return gradeRepo.FindAll().ToList();
        }

        [HttpGet("GetStudentInfo")]
        public Student GetStudentInfo([FromQuery] string email)
        {
            return (Student)UserRepository.GetUserFromMail(email);
        }

        [HttpPost("CancelCourse")]
        public Class CancelCourse([FromQuery] string classId, [FromQuery] string email)
        {
            Console.WriteLine(email + ", " + classId);
            Student currentStudent = (Student)UserRepository.GetUserFromMail(email);
            if (currentStudent != null)
            {
                ClassDetail cld = classRepo.CancelCourseForStudent(classId, currentStudent.StudentId);
                if (cld != null)
                    return classRepo.GetClass(classId);
            }
            return new Class() { ClassId="failed cmnr" };
        }
    }
}
