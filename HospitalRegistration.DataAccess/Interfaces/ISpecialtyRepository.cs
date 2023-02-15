using HospitalRegistration.DataAccess.Entities;

namespace HospitalRegistration.DataAccess.Interfaces
{
    public interface ISpecialtyRepository : IRepository<Specialty>
    {
        Task<Specialty> GetSpecialtyAsync(Guid specialtyId);
        Task AsignSpecialtyToDocAsync(Guid doctorId, Guid specialtyId);
    }
}
