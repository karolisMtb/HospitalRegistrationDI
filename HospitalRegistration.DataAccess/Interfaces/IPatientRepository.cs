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
        Task<Patient> CheckIfPatientExistsAsync(string name, string lastName, DateTime dateOfBirth);
        Task AsignPatientToNewDoctorAsync(Guid doctorId);
        Task SignInExistingPatientAsync(Guid patientId, string? illnessName);
        //TODO delegate, because param can either be patientId or illnessId
        Task<PatientIllness> GetPatientIllnessAsync(); 

    }
}
