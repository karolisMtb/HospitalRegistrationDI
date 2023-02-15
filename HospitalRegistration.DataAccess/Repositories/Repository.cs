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
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return dbContext.Set<T>().ToList();
        }

        public async Task AddAsync(T entity)
        {
            dbContext.Set<T>().Add(entity);
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            dbContext.Set<T>().AddRange(entities);
        }

        public async Task RemoveAsync(T entity)
        {
            dbContext.Set<T>().Remove(entity);
        }

        public async Task RemoveRangeAsync(IEnumerable<T> entities)
        {
            dbContext.Set<T>().RemoveRange(entities);
        }
        public void Dispose()
        {
            dbContext.Dispose();
        }
    }
}
