using HospitalRegistration.DataAccess.DataContext;
using HospitalRegistration.DataAccess.Entities;
using HospitalRegistration.DataAccess.Interfaces;

namespace HospitalRegistration.DataAccess.Repositories
{
    public class IllnessRepository : Repository<Illness>, IIlnessRepository
    {
        public IllnessRepository(DatabaseContext databaseContext) : base(databaseContext)
        {

        }

        public DatabaseContext DatabaseContext => dbContext as DatabaseContext;

        public async Task AsignIllnessToPatientAsync(Guid patientId, string illnessName)
        {
            Patient patientToAsignTo = DatabaseContext.Patients.Where(patient => patient.Id == patientId).First();
            PatientIllness patientIllness = new();
            Illness illness = new Illness(illnessName);
            patientIllness.Patient = patientToAsignTo;
            patientIllness.Illness = illness;
            DatabaseContext.PatientIllnesses.Add(patientIllness);
        }
    }
}
