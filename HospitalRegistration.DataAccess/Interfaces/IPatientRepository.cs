using HospitalRegistration.DataAccess.Entities;
using System.Xml.Linq;

namespace HospitalRegistration.DataAccess.Interfaces
{
    public interface IPatientRepository : IRepository<Patient>
    {
        Task<IEnumerable<Patient>> GetAllPatientsOfDoctorAsync(Guid doctorId);
        Task AddDoctorPatientAsync(DoctorPatient doctorPatient);
        Task AddPatientIllnessAsync(PatientIllness patientIllness);
        Task<Patient> GetPatientAsync(Guid patientId);
        Task DischargeAsync(Guid patientId);
        Task SignInExistingPatientAsync(Guid patientId);
        Task<Patient> CheckIfPatientExistsAsync(string name, string lastName, DateTime dateOfBirth);
    }
}
