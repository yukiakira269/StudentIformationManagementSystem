using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIMS.DataTier.Infrastructure
{
    //Using async because an API can be accessed by multiple applications at the same time
    //T must be a ref value
    public interface IRepository<T> where T : class
    {
        T Find(params object[] values);
        IEnumerable<T> FindAll();
        bool Insert(T entity, bool saveChanges = true);
        bool Delete(T entity, bool saveChanges = true);
        bool Update(T Entity, bool saveChanges = true);
    }
}
