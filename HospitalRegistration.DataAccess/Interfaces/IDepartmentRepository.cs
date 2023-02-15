using HospitalRegistration.DataAccess.Entities;

namespace HospitalRegistration.DataAccess.Interfaces
{
    public interface IDepartmentRepository : IRepository<Department>
    {
        Task<IEnumerable<Doctor>> GetAllDoctorsOfDepartmentAsync(Guid departmentId);
        Task<IEnumerable<Patient>> GetAllPatientsOfDepartmentAsync(Guid departmentId);
        Task<Department> GetDepartmentAsync(Guid departmentId);
        Task RemoveDoctorFromDepartmentAsync(Guid doctorId, Guid departmentId);
        Task RemoveAllDepartmentsAsync();
    }
}
