using Microsoft.EntityFrameworkCore;
using SIMS.DataTier.BusinessObject;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIMS.DataTier.Infrastructure
{
    public class TeacherRepository : IRepository<Teacher>
    {

        public string GenerateId()
        {
            using var ctx = new SIMSContext();
            var lastId = ctx.Teachers.OrderByDescending(t => t.TeacherId).First().TeacherId;
            var lastDigits = Int32.Parse(lastId.Substring(2, lastId.Length - 2)) + 1;
            return "TE" + lastDigits.ToString();
        }

        public void Promote(Student student)
        {
            //Remove the Student from the student list
            StudentRepository stuRepo = new StudentRepository();
            stuRepo.Delete(student);
            //Generate a new Teacher ID
            string id = GenerateId();
            //Add a new teacher with relevant information
            Teacher teacher = new Teacher
            {
                TeacherId = id,
                Name = student.Name,
                Email = student.Email,
            };
            this.Insert(teacher);
        }

        public bool Delete(Teacher entity, bool saveChanges = true)
        {
            using var ctx = new SIMSContext();
            var teachingClass = ctx.Classes.AsNoTracking<Class>().Where(c => c.TeacherId.Equals(entity.TeacherId)).ToList();
            foreach(var cl in teachingClass)
            {
                Class c = new Class
                {
                    ClassId = cl.ClassId,
                    CourseId = cl.CourseId,
                    NumOfStudent = cl.NumOfStudent,
                    TeacherId = null
                };
                ctx.Classes.Update(c);
            }
            var feedbacks = ctx.Feedbacks.AsNoTracking<Feedback>().Where(f => f.TeacherId.Equals(entity.TeacherId)).ToList();
            foreach(var f in feedbacks)
            {
                ctx.Feedbacks.Remove(f);
            }
            ctx.Teachers.Remove(entity);
            ctx.SaveChanges();
            return saveChanges;
        }

        public Teacher Find(params object[] values)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Teacher> FindAll()
        {
            using var ctx = new SIMSContext();
            return ctx.Teachers.ToList();
        }

        public IEnumerable<Teacher> getAll()
        {
            throw new NotImplementedException();
        }

        public bool Insert(Teacher entity, bool saveChanges = true)
        {
            using var ctx = new SIMSContext();
            ctx.Teachers.Add(entity);
            ctx.SaveChanges();
            return saveChanges;
        }

        public bool Update(Teacher Entity, bool saveChanges = true)
        {
            try
            {
                using var ctx = new SIMSContext();
                ctx.Teachers.Update(Entity);
                ctx.SaveChanges();
                Console.WriteLine("Updated!!");
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return saveChanges;
        }
    }
}
