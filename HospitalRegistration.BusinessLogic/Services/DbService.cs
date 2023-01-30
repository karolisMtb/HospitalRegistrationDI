using HospitalRegistration.DataAccess.Entities;
using HospitalRegistration.DataAccess.Interfaces;

namespace HospitalRegistration.BusinessLogic.Services
{
    public class DbService : IDbService
    {
        private readonly IDepartmentRepository _departmentRepository;

        public DbService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }

        public void DeleteDepartments()
        {
            if(GetAll().ToList().Count != 0)
            {
                _departmentRepository.RemoveAllDepartments();
            }
        }

        public IEnumerable<Department> GetAll()
        {
            return _departmentRepository.GetAll();
        }
        

    }


}
