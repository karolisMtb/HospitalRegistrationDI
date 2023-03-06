using HospitalRegistration.DataAccess.Entities;

namespace HospitalRegistration.DataAccess.Interfaces
{
    public interface IDoctorRepository : IRepository<Doctor>
    {
        Task<IEnumerable<Doctor>> GetAllDoctorsOfPatientAsync(Guid doctorId);
        Task<Doctor> GetDoctorAsync(Guid doctorId);
        Task<List<Doctor>> GetDoctorsByNameAsync(string name);
    }
}
