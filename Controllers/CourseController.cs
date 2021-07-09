using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SIMS.DataTier.BusinessObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIMS.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CourseController : Controller
    {
        [HttpGet("GetCourses")]
        public IEnumerable<Course> GetCourses()
        {
            Console.WriteLine("Called");
            using SIMSContext ctx = new SIMSContext();
            return ctx.Courses.ToList();
        }

        [HttpPost("Register")]
        public void RegisterCourse([FromBody] object obj)
        {

        }
    }
}
