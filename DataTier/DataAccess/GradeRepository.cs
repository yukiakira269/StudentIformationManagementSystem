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
            throw new NotImplementedException();
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
