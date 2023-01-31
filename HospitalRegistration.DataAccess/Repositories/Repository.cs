using HospitalRegistration.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HospitalRegistration.DataAccess.Repositories
{
    public class Repository<T> : IRepository<T>, IDisposable where T : class
    {
        protected readonly DbContext dbContext;

        public Repository(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public IEnumerable<T> GetAll()
        {
            return dbContext.Set<T>().ToList();
        }

        public void Add(T entity)
        {
            dbContext.Set<T>().Add(entity);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            dbContext.Set<T>().AddRange(entities);
        }

        public void Remove(T entity)
        {
            //TODO
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            dbContext.Set<T>().RemoveRange(entities);
        }
        public void Dispose()
        {
            // TODO
        }
    }
}
