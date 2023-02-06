using HospitalRegistration.DataAccess.Entities;

namespace HospitalRegistration.DataAccess.Interfaces
{
    public interface ISpecialtyRepository : IRepository<Specialty>
    {
        Specialty GetSpecialty(Specialty specialty);
        void AsignSpecialtyToDoctor(Doctor doctor, Specialty specialty);
    }
}
