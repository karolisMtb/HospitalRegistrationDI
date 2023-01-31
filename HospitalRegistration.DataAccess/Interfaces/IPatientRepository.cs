using HospitalRegistration.DataAccess.Entities;

namespace HospitalRegistration.DataAccess.Interfaces
{
    public interface IPatientRepository : IRepository<Patient>
    {
        IEnumerable<Doctor> GetAllDoctorsOfPatient(Patient patient);
    }
}
