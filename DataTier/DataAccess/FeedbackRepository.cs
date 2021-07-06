using Microsoft.EntityFrameworkCore;
using SIMS.DataTier.BusinessObject;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIMS.DataTier.Infrastructure
{
    public class FeedbackRepository : IRepository<Feedback>
    {
        public bool Delete(Feedback entity, bool saveChanges = true)
        {
            throw new NotImplementedException();
        }

        public Feedback Find(params object[] values)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Feedback> FindAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Feedback> getAll()
        {
            throw new NotImplementedException();
        }

        public bool Insert(Feedback entity, bool saveChanges = true)
        {
            throw new NotImplementedException();
        }

        public bool Update(Feedback Entity, bool saveChanges = true)
        {
            throw new NotImplementedException();
        }
    }
}
