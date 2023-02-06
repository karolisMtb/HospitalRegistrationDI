using HospitalRegistration.DataAccess.DataContext;
using HospitalRegistration.DataAccess.Entities;
using HospitalRegistration.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HospitalRegistration.DataAccess.Repositories
{
    public class PatientRepository : Repository<Patient>, IPatientRepository
    {
        public IEnumerable<Patient> PatientsOfDoctor { get; set; }
        public PatientRepository(DatabaseContext databaseContext) : base(databaseContext)
        {

        }

        public DatabaseContext DatabaseContext => dbContext as DatabaseContext;

        public Patient GetPatient(Patient patient)
        {
            return DatabaseContext.Patients.FirstOrDefault(patient);
        }

        public void AddDoctorPatient(DoctorPatient doctorPatient)
        {
            DatabaseContext.DoctorPatients.Add(doctorPatient);
        }

        public void AddPatientIllness(PatientIllness patientIllness)
        {
            DatabaseContext.PatientIllnesses.Add(patientIllness);
        }

        public IEnumerable<Patient> GetAllPatientsOfDoctor(Doctor doctor)
        {
            PatientsOfDoctor = new List<Patient>();
            PatientsOfDoctor = DatabaseContext.DoctorPatients.Include(x => x.Patient).Where(x => x.DoctorId == doctor.Id).Select(x => x.Patient);
            return PatientsOfDoctor;
        }
    }
}
