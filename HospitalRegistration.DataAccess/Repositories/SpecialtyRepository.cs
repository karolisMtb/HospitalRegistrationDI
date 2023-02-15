using HospitalRegistration.DataAccess.DataContext;
using HospitalRegistration.DataAccess.Entities;
using HospitalRegistration.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace HospitalRegistration.DataAccess.Repositories
{
    public class SpecialtyRepository : Repository<Specialty>, ISpecialtyRepository
    {
        public SpecialtyRepository(DatabaseContext databaseContext) : base(databaseContext)
        {

        }

        private DatabaseContext DatabaseContext => dbContext as DatabaseContext;

        public async Task<Specialty> GetSpecialtyAsync(Guid specialtyId)
        {
            return DatabaseContext.DoctorSpecialties.Where(specialty => specialty.Id == specialtyId).First();
        }

        public async Task AsignSpecialtyToDocAsync(Guid doctorId, Guid specialtyId)
        {
            bool doctorHasThisSpecialty = DatabaseContext.DoctorSpecialties.Include(x => x.Doctors.Where(doctor => doctor.Id == doctorId)).Where(specialty => specialty.Id == specialtyId).Any();
            
            if(!doctorHasThisSpecialty)
            {
                DatabaseContext.Doctors.Where(doctor => doctor.Id == doctorId).First().Specialties.Add(await GetSpecialtyAsync(specialtyId));
            }
        }
    }
}
