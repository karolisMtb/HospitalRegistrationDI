using HospitalRegistration.DataAccess.DataContext;
using HospitalRegistration.DataAccess.Entities;
using HospitalRegistration.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HospitalRegistration.DataAccess.Repositories
{
    public class DoctorRepository : Repository<Doctor>, IDoctorRepository
    {
        public IEnumerable<Doctor> DoctorsOfPatient { get; set; }
        public DoctorRepository(DatabaseContext databaseContext) : base(databaseContext)
        {

        }

        public DatabaseContext DatabaseContext => dbContext as DatabaseContext;
        
        public Doctor GetDoctor(Doctor doctor)
        {
            return DatabaseContext.Doctors.FirstOrDefault(doctor);
        }

        public IEnumerable<Doctor> GetAllDoctorsOfPatient(Patient patient)
        {
            DoctorsOfPatient = new List<Doctor>();
            DoctorsOfPatient = (IEnumerable<Doctor>)DatabaseContext.DoctorPatients.Include(x => x.Doctor).Where(x => x.PatientId == patient.Id).Select(x => x.Patient);
            return DoctorsOfPatient;
        }
            
    }
}

