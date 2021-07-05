using Microsoft.EntityFrameworkCore;
using SIMS.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIMS.DataTier.Infrastructure
{
    public class CourseRepository : IRepository<Course>
    {
        public bool Delete(Course entity, bool saveChanges = true)
        {
            throw new NotImplementedException();
        }

        public Course Find(params object[] values)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Course> FindAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Course> getAll()
        {
            throw new NotImplementedException();
        }

        public bool Insert(Course entity, bool saveChanges = true)
        {
            throw new NotImplementedException();
        }

        public bool Update(Course Entity, bool saveChanges = true)
        {
            throw new NotImplementedException();
        }
    }
}
