using HospitalRegistration.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalRegistration.DataAccess.Repositories
{
    public class Repository<T> : IRepository<T>, IDisposable where T : class
    {
        protected readonly DbContext dbContext;
        public Repository(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Add(T entity)
        {
            //TODO
            //naudoti cia db context
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
