using HospitalRegistration.DataAccess.DataContext;
using HospitalRegistration.DataAccess.Entities;
using HospitalRegistration.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalRegistration.DataAccess.Repositories
{
    public class IllnessRepository : Repository<Illness>, IIlnessRepository
    {
        IEnumerable<Illness> IllnessList { get; set; }
        public IllnessRepository(DatabaseContext databaseContext) : base(databaseContext)
        {

        }

        public DatabaseContext DatabaseContext => dbContext as DatabaseContext;



    }
}
