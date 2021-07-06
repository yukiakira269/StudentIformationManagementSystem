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
        public bool Delete(Teacher entity, bool saveChanges = true)
        {
            throw new NotImplementedException();
        }

        public Teacher Find(params object[] values)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Teacher> FindAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Teacher> getAll()
        {
            throw new NotImplementedException();
        }

        public bool Insert(Teacher entity, bool saveChanges = true)
        {
            throw new NotImplementedException();
        }

        public bool Update(Teacher Entity, bool saveChanges = true)
        {
            throw new NotImplementedException();
        }
    }
}
