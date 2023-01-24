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
    public class DepartmentRepository : Repository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(DatabaseContext databaseContext) : base(databaseContext)
        {

        }

        public DatabaseContext DatabaseContext
        {
            get
            {
                return dbContext as DatabaseContext;
            }
        }
        public IEnumerable<Doctor> GetAllDoctorsOfDepartment(Department department)
        {
            //TODO
            return null;
        }

        public IEnumerable<Patient> GetAllPatientsOfDepartment(Department department)
        {
            //TODO
            // is databasecontext traukti pacientus
            return null;
        }
       
    }
}
