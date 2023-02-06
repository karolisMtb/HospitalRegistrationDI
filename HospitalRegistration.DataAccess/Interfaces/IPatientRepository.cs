using HospitalRegistration.DataAccess.Entities;

namespace HospitalRegistration.DataAccess.Interfaces
{
    public interface IPatientRepository : IRepository<Patient>
    {
        IEnumerable<Patient> GetAllPatientsOfDoctor(Doctor doctor);
        void AddDoctorPatient(DoctorPatient doctorPatient);
        void AddPatientIllness(PatientIllness patientIllness);
        Patient GetPatient(Patient patient);
    }
}
