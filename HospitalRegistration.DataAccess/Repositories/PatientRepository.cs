using HospitalRegistration.DataAccess.DataContext;
using HospitalRegistration.DataAccess.Entities;
using HospitalRegistration.DataAccess.Interfaces;

namespace HospitalRegistration.DataAccess.Repositories
{
    public class PatientRepository : Repository<Patient>, IPatientRepository
    {
        public IGeneratorService<Patient> PatientGeneratorService { get; set; }
        public PatientRepository(IGeneratorService<Patient> PatientGeneratorService, DatabaseContext databaseContext) : base(databaseContext)
        {
            this.PatientGeneratorService = PatientGeneratorService;
        }

        public DatabaseContext DatabaseContext => dbContext as DatabaseContext;

        public IEnumerable<Doctor> GetAllDoctorsOfPatient(Patient patient)
        {
            //TODO
            return null;
        }

        public void GeneratePatients()
        {
            DatabaseContext.Patients.AddRange(PatientGeneratorService.Generate());
            // sita turi daryti UnitOfWork
            //DatabaseContext.SaveChanges();
        }
    }
}
