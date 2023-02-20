using HospitalRegistration.DataAccess.DataContext;
using HospitalRegistration.DataAccess.Entities;
using HospitalRegistration.DataAccess.Exceptions;
using HospitalRegistration.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace HospitalRegistration.DataAccess.Repositories
{
    public class PatientRepository : Repository<Patient>, IPatientRepository
    {
        public PatientRepository(DatabaseContext databaseContext) : base(databaseContext)
        {

        }

        private DatabaseContext DatabaseContext => dbContext as DatabaseContext;

        public async Task<Patient> GetPatientAsync(Guid patientId)
        {
            return DatabaseContext.Patients.Where(x => x.Id == patientId).First();
        }

        public async Task AddDoctorPatientAsync(DoctorPatient doctorPatient)
        {
            DatabaseContext.DoctorPatients.Add(doctorPatient);
        }

        public async Task AddPatientIllnessAsync(PatientIllness patientIllness)
        {
            DatabaseContext.PatientIllnesses.Add(patientIllness);
        }

        public async Task<IEnumerable<Patient>> GetAllPatientsOfDoctorAsync(Guid doctorId)
        {
            return DatabaseContext.DoctorPatients.Include(x => x.Patient).Where(x => x.DoctorId == doctorId).Select(x => x.Patient).ToList();
        }

        public async Task DischargeAsync(Guid patientId)
        {
            List<Patient> patientIllness = DatabaseContext.PatientIllnesses.Include(x => x.Patient).Where(x => x.PatientId == patientId).Select(x => x.Patient).ToList();
            List<Patient> doctorPatients = DatabaseContext.DoctorPatients.Include(x => x.Patient).Where(x => x.Patient.Id == patientId).Select(x => x.Patient).ToList();

            foreach(Patient patient in patientIllness)
            {
                patientIllness.Remove(patient);
            }

            foreach(Patient patient in doctorPatients)
            {
                doctorPatients.Remove(patient);
            }
        }

        //TODO
        public async Task SignInExistingPatientAsync(Guid patientId, string? illnessName)
        {
            //save previous data to new db table "HospitalRecords"
            try
            {
                Patient existingPatient = await GetPatientAsync(patientId);
                PatientIllness newPatientIllness = new();
                newPatientIllness.Patient = existingPatient;
                newPatientIllness.Illness = new Illness(illnessName);
                DatabaseContext.PatientIllnesses.Add(newPatientIllness);
            }
            catch
            {
                throw new FailedDbActionException("Failed to sign in existing patient");
            }

            // sita turi padaryti service klase.
            //find patient
            //linq => select(new{patient})
            //add illness
            //asign to doctor
            // if signed out == dateTime => dateTime = null;
        }

        public async Task<Patient> CheckIfPatientExistsAsync(string name, string lastName, DateTime dateOfBirth)
        {
            return DatabaseContext.Patients.Where(patient => patient.Name == name && patient.LastName == lastName && patient.DateOfBirth == dateOfBirth).First();
        }

        //TODO
        public async Task AsignPatientToNewDoctorAsync(Guid doctorId)
        {

        }

        //TODO
        public Task<PatientIllness> GetPatientIllnessAsync()
        {
            return null;
        }
    }
}
