using HospitalRegistration.DataAccess.Entities;

namespace HospitalRegistration.DataAccess.Interfaces
{
    public interface IHospitalService
    {
        Task DeleteDepartmentsAsync();
        Task<IEnumerable<Department>> GetAllAsync();
        Task AsignDoctorToDepartmentAsync(Guid doctorId, Guid departmentId);
        Task AsignSpecialtyToDoctorAsync(Guid doctorId, Guid specialtyId);
        Task AsignPatientToDoctorAsync(Guid doctorId, Guid patientId);
        Task RegisterNewPatientAsync(string name, string lastName, DateTime dateOfBirth, string? illnessName);
        Task RegisterNewDoctorAsync(string name, string lastName);
        Task AsignPatientToNewDoctorAsync(Guid patientId, Guid doctorId);
    }
}
