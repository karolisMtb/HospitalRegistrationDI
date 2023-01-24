using HospitalRegistration.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalRegistration.DataAccess.Repositories
{
    public class Repository<T> : IRepository<T>, IDisposable where T : class
    {
        public void Add(T entity)
        {
            //TODO
        }

        public void AddRange(List<T> entities)
        {
            //TODO
        }

        public void Remove(T entity)
        {
            //TODO
        }

        public void RemoveRange(List<T> entities)
        {
            //TODO
        }
        public void Dispose()
        {
            // TODO
        }
    }
}
