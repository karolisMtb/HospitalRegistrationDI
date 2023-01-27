using HospitalRegistration.DataAccess.Entities;
using HospitalRegistration.DataAccess.Interfaces;

namespace HospitalRegistration.BusinessLogic.Services
{
    public class DbService : IDbService
    {
        public IDepartmentRepository _departmentRepository;
        public IEnumerable<Department> Departments = new List<Department>();

        public DbService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
        public IEnumerable<Department> GetAllDepartments()
        {
            Departments = _departmentRepository.GetAll();
            return Departments;
        }

    }


}
