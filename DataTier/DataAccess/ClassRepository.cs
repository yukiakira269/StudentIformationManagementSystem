using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SIMS.DataTier.BusinessObject;
using SIMS.DataTier.DataAccess;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIMS.DataTier.Infrastructure
{
    public class ClassRepository : IRepository<Class>
    {
        private static SIMSContext ctx = new SIMSContext();

        public IEnumerable<ClassDetail> GetClassDetails(string classId)
        {
            return ctx.ClassDetails.ToList().Where(clD => clD.ClassId == (classId));

        }

        public IEnumerable<Student> GetStudentList(string classId)
        {
            var classDetails = GetClassDetails(classId);
            var students = new List<Student>();
            foreach (ClassDetail cld in classDetails)
            {
                var tempStu = ctx.Students.SingleOrDefault(s => s.StudentId == cld.StudentId);
                if (tempStu != null)
                {
                    students.Add(tempStu);
                }
            }
            foreach (Student s in students)
            {
                Console.WriteLine(students.Count);
            }

            return students;

        }


        public bool Delete(Class entity, bool saveChanges = true)
        {
            using var ctx = new SIMSContext();
            ctx.Classes.Remove(entity);
            ctx.SaveChanges();
            return saveChanges;
        }

        public Class Find(params object[] values)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Class> FindAll()
        {
            return ctx.Classes;
        }

        public IEnumerable<Class> FindAll(string email)
        {
            var id = UserRepository.GetIdFromMail(email);
            return ctx.Classes.ToList().Where(c =>
            {
                return c.TeacherId.Equals(id);
            });
        }



        public IEnumerable<Class> getAll()
        {
            throw new NotImplementedException();
        }

        public bool Insert(Class entity, bool saveChanges = true)
        {
            throw new NotImplementedException();
        }

        public bool Update(Class Entity, bool saveChanges = true)
        {
            throw new NotImplementedException();
        }

        public bool UpdateList(IEnumerable<Class> Entities, bool saveChanges = true)
        {
            using var ctx = new SIMSContext();
            foreach (Class cl in Entities)
            {
                //Load to memory for performance improvement
                var classList = ctx.Classes.ToList();
                var toBeAdded = classList.SingleOrDefault(c => c.CourseId.Equals(cl.CourseId));
                //The course is not on the list
                if (toBeAdded == null)
                {
                    ctx.Classes.Add(cl);
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
