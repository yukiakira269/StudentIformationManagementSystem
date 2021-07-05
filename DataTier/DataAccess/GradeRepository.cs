using Microsoft.EntityFrameworkCore;
using SIMS.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIMS.DataTier.Infrastructure
{
    public class GradeRepository : IRepository<Grade>
    {
        public bool Delete(Grade entity, bool saveChanges = true)
        {
            throw new NotImplementedException();
        }

        public Grade Find(params object[] values)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Grade> FindAll()
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
    }
}
