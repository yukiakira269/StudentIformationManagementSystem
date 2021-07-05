using Microsoft.EntityFrameworkCore;
using SIMS.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIMS.DataTier.Infrastructure
{
    public class StudentRepository : IRepository<Student>
    {
        private static SIMSContext ctx = new SIMSContext();

        public bool Delete(Student entity, bool saveChanges = true)
        {
            throw new NotImplementedException();
        }

        public Student Find(params object[] values)
        {
            return ctx.Students.Find(values[0].ToString());
        }

        public IEnumerable<Student> FindAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Student> getAll()
        {
            throw new NotImplementedException();
        }

        public bool Insert(Student entity, bool saveChanges = true)
        {
            throw new NotImplementedException();
        }

        public bool Update(Student Entity, bool saveChanges = true)
        {
            throw new NotImplementedException();
        }
    }
}
