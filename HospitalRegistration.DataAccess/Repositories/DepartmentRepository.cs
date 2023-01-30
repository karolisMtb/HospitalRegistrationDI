using HospitalRegistration.DataAccess.DataContext;
using HospitalRegistration.DataAccess.Entities;
using HospitalRegistration.DataAccess.Interfaces;
using HospitalRegistration.DataAccess.Exceptions;


namespace HospitalRegistration.DataAccess.Repositories
{
    public class DepartmentRepository : Repository<Department>, IDepartmentRepository
    {
        public IGeneratorService<Department> DepartmentGeneratorService;
        public IEnumerable<Department> departmentList { get; set; }
        public DepartmentRepository(IGeneratorService<Department> generatorService, DatabaseContext databaseContext) : base(databaseContext)
        {
            DepartmentGeneratorService = generatorService;
        }

        public DatabaseContext DatabaseContext
        {
            get
            {
                return dbContext as DatabaseContext;
            }
        }

        public void GenerateAllDepartments()
        {
            if(GetAll().Count() == 0)
            {
                DatabaseContext.Departments.AddRange(DepartmentGeneratorService.Generate());
                // sita turi daryti UnitOfWork
                //DatabaseContext.SaveChanges();
            }
            else
            {
                throw new FailedDbActionException("Failed to populate database");
            }
        }

        public void RemoveAllDepartments()
        {
            foreach (var department in DatabaseContext.Departments)
            {
                DatabaseContext.Departments.Remove(department);
            }
            // sita turi daryti UnitOfWork
            //DatabaseContext.SaveChanges();
        }

        public IEnumerable<Department> GetAll()
        {
            departmentList = new List<Department>();
            if(dbContext != null && DatabaseContext.Departments.ToList().Count != 0)
            {
                departmentList = DatabaseContext.Departments.ToList();
            }

            return departmentList;
        }
        public IEnumerable<Doctor> GetAllDoctorsOfDepartment(Department department)
        {
            departmentList = GetAll();

            return departmentList.Where(x =>x.Id == department.Id).SelectMany(x => x.Doctors).ToList();
        }

        public IEnumerable<Patient> GetAllPatientsOfDepartment(Department department)
        {
            var doctorsListOfDepartment = GetAllDoctorsOfDepartment(department);
            List<Patient> patientsOfDepartment = new List<Patient>();
            return null;
        }       
       
    }
}
