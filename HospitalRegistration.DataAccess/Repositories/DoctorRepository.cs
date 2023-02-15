using HospitalRegistration.DataAccess.DataContext;
using HospitalRegistration.DataAccess.Entities;
using HospitalRegistration.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HospitalRegistration.DataAccess.Repositories
{
    public class DoctorRepository : Repository<Doctor>, IDoctorRepository
    {
        public DoctorRepository(DatabaseContext databaseContext) : base(databaseContext)
        {

        }

        public DatabaseContext DatabaseContext => dbContext as DatabaseContext;
        
        public async Task<Doctor> GetDoctorAsync(Guid doctorId)
        {
            return DatabaseContext.Doctors.FirstOrDefault(x => x.Id == doctorId);
        }

        public async Task<IEnumerable<Doctor>> GetAllDoctorsOfPatientAsync(Guid patientId)
        {
           return DatabaseContext.DoctorPatients.Include(x => x.Doctor).Where(x => x.PatientId == patientId).Select(x => x.Doctor).ToList();
        }
            
    }
}

