using HospitalRegistration.DataAccess.Entities;

namespace HospitalRegistration.DataAccess.Interfaces
{
    public interface IUnitOfWork
    {
        Task SaveChanges();
        Task AddToDoctorRepository(Doctor doctor);
    }
}
