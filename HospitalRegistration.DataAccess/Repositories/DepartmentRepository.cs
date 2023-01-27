using HospitalRegistration.DataAccess.DataContext;
using HospitalRegistration.DataAccess.Entities;
using HospitalRegistration.DataAccess.Interfaces;


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

        public IEnumerable<Department> GetAll()
        {
            IEnumerable<Department> departmentList = new List<Department>();
            if(dbContext != null && DatabaseContext.Departments.ToList().Count != 0)
            {
                departmentList = DatabaseContext.Departments.ToList();
            } else
            {
                throw new NotImplementedException();
            }
            return departmentList;
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
