using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalRegistration.DataAccess.Interfaces
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        void AddRange(List<T> entities);
        void Remove(T entity);
        void RemoveRange(List<T> entities);
        // TODO
        // Add Move() moves object to another department/ doctor
    }
}
