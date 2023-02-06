using HospitalRegistration.DataAccess.DataContext;
using HospitalRegistration.DataAccess.Entities;
using HospitalRegistration.DataAccess.Interfaces;

namespace HospitalRegistration.DataAccess.Repositories
{
    public class SpecialtyRepository : Repository<Specialty>, ISpecialtyRepository
    {
        public SpecialtyRepository(DatabaseContext databaseContext) : base(databaseContext)
        {

        }

        public DatabaseContext DatabaseContext => dbContext as DatabaseContext;

        public Specialty GetSpecialty(Specialty specialty)
        {
            return DatabaseContext.DoctorSpecialties.FirstOrDefault(specialty);
        }

        public void AsignSpecialtyToDoctor(Doctor doctor, Specialty specialty)
        {
            bool doctorHasThisSpecialty = doctor.Specialties.Where(x=>x.Name == specialty.Name).Any();
            if(doctor != null && specialty != null && !doctorHasThisSpecialty)
            {
                doctor.Specialties.Add(specialty);
            }
        }
    }
}
