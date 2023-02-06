using HospitalRegistration.DataAccess.Entities;

namespace HospitalRegistration.DataAccess.Interfaces
{
    public interface IDoctorRepository : IRepository<Doctor>
    {
        IEnumerable<Doctor> GetAllDoctorsOfPatient(Patient patient);
       Doctor GetDoctor(Doctor doctor);
    }
}
