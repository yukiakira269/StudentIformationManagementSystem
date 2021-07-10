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
    public class ClassController : ControllerBase
    {
        [HttpGet("GetClasses")]
        public IEnumerable<Class> GetClasses()
        {
            Console.WriteLine("Called");
            using SIMSContext ctx = new SIMSContext();
            return ctx.Classes.ToList();
        }
    }
}
