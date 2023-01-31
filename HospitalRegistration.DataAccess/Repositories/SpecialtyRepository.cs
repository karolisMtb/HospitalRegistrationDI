using HospitalRegistration.DataAccess.DataContext;
using HospitalRegistration.DataAccess.Entities;
using HospitalRegistration.DataAccess.Interfaces;

namespace HospitalRegistration.DataAccess.Repositories
{
    public class SpecialtyRepository : Repository<Specialty>, ISpecialtyRepository
    {
        IEnumerable<Specialty> Specialties { get; set; }
        public SpecialtyRepository(DatabaseContext databaseContext) : base(databaseContext)
        {

        }

        public DatabaseContext DatabaseContext => dbContext as DatabaseContext;
    }
}
