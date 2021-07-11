using Microsoft.EntityFrameworkCore;
using SIMS.DataTier.BusinessObject;
using SIMS.DataTier.DataAccess;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIMS.DataTier.Infrastructure
{
    public class GradeRepository : IRepository<Grade>
    {
        private static SIMSContext ctx = new SIMSContext();

        public bool Delete(Grade entity, bool saveChanges = true)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Grade> Find(string studentId, string classId)
        {
            using var ctx = new SIMSContext();

            return ctx.Grades.Where(g => g.StudentId.Equals(studentId) && g.CourseId.Equals(classId)).ToList();
        }

        public IEnumerable<Grade> Find(string id)
        {
            using var ctx = new SIMSContext();

            return ctx.Grades.Where(g => g.StudentId.Equals(id)).ToList();
        }

        public IEnumerable<Grade> FindGrade(string studentId, string classId, string teacherId)
        {
            var teachingClass = ctx.Classes.SingleOrDefault(c => c.ClassId.Equals(classId) && c.TeacherId.Equals(teacherId));
            return ctx.Grades.Where(g =>
            g.CourseId.Equals(teachingClass.CourseId)
            && g.StudentId.Equals(studentId)
            );
        }

        public Grade Find(params object[] values)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Grade> FindAll()
        {
            return ctx.Grades.ToList();
        }

        public IEnumerable<Grade> FindAll(string email)
        {
            var id = UserRepository.GetIdFromMail(email);
            return ctx.Grades.ToList().Where(c =>
            {
                return c.StudentId.Equals(id);
            });
        }

        public IEnumerable<Grade> getAll()
        {
            throw new NotImplementedException();
        }

        public bool Insert(Grade entity, bool saveChanges = true)
        {
            using var ctx = new SIMSContext();
            //The Student has not been graded
            var grade = ctx.Grades.SingleOrDefault
                (g => g.CourseId.Equals(entity.CourseId) &&
                g.StudentId.Equals(entity.StudentId));
            if (grade == null)
            {
                ctx.Grades.Add(entity);
            }
            //The Student has been graded but re-register
            else
            {
                Update(entity);
            }
            ctx.SaveChanges();
            return saveChanges;
        }

        public bool Update(Grade Entity, bool saveChanges = true)
        {
            try
            {
                using var ctx = new SIMSContext();
                ctx.Grades.Update(Entity);
                ctx.SaveChanges();
                Console.WriteLine("Updated!!");
            }
            catch (Exception ex)
            {
                saveChanges = false;
                throw new Exception(ex.Message);
            }
            return saveChanges;

        }
    }
}
