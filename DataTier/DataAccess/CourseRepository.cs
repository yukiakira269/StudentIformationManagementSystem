using Microsoft.EntityFrameworkCore;
using SIMS.DataTier.BusinessObject;
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
            using var ctx = new SIMSContext();
            ctx.Courses.Remove(entity);
            ctx.SaveChanges();
            return saveChanges;
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
            using var ctx = new SIMSContext();

            return saveChanges;
        }

        public bool UpdateList(IEnumerable<Course> Entities, bool saveChanges = true)
        {
            using var ctx = new SIMSContext();
            foreach (Course course in Entities)
            {
                //Load to memory for performance improvement
                var courseList = ctx.Courses.ToList();
                var toBeAdded = courseList.SingleOrDefault(c => c.CourseId.Equals(course.CourseId));
                //The course is not on the list
                if (toBeAdded == null)
                {
                    ctx.Courses.Add(course);
                }
                //The course is on the list
                else if (toBeAdded != null)
                {
                    var toBeUpdated = toBeAdded;
                    ctx.Update(toBeUpdated);
                }
            }
            ctx.SaveChanges();
            return saveChanges;
        }
    }
}
