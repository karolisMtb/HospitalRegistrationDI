using HospitalRegistration.DataAccess.DataContext;
using HospitalRegistration.DataAccess.Entities;
using HospitalRegistration.DataAccess.Interfaces;
using HospitalRegistration.DataAccess.Exceptions;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace HospitalRegistration.DataAccess.Repositories
{
    public class DepartmentRepository : Repository<Department>, IDepartmentRepository
    {
        public DepartmentRepository( DatabaseContext databaseContext) : base(databaseContext)
        {

        }

        private DatabaseContext DatabaseContext => dbContext as DatabaseContext;

        public async Task RemoveAllDepartmentsAsync()
        {
            foreach (var department in DatabaseContext.Departments)
            {
                DatabaseContext.Departments.Remove(department);
            }
        }

        public async Task<Department> GetDepartmentAsync(Guid departmentId)
        {
            var matchingDepartment = DatabaseContext.Departments.Where(x=> x.Id == departmentId).FirstOrDefault();

            if (matchingDepartment == null)
            {
                throw new FailedDbActionException("Department was not found");
            }
            else
            {
                return matchingDepartment;
            }
        }

        public async Task<IEnumerable<Department>> GetAllDepartmentsAsync()
        {
            return DatabaseContext.Departments.ToList();
        }
        public async Task<IEnumerable<Doctor>> GetAllDoctorsOfDepartmentAsync(Guid departmentId)
        {
            return DatabaseContext.Departments.Where(department => department.Id == department.Id).SelectMany(department => department.Doctors).ToList();
        }

        public async Task<IEnumerable<Patient>> GetAllPatientsOfDepartmentAsync(Guid departmentId)
        {

            return DatabaseContext.Departments.Where(department => department.Id == departmentId)
                .SelectMany(x => x.Doctors.Where(doctor => doctor.DepartmentId == departmentId)
                .SelectMany(x => x.DoctorPatients).Select(x => x.Patient).ToList());
        }
        
        public async Task RemoveDoctorFromDepartmentAsync(Guid doctorId, Guid departmentId)
        {
            // drop down list ismeta tik tuos gydytojus is departamento kurie ten egzistuoja
            try
            {
                var doctorsInDepartment = DatabaseContext.Departments.Where(department => department.Id == departmentId)
                    .SelectMany(x => x.Doctors.Where(doctor => doctor.Id == doctorId))
                    .ToList();

                foreach(var doctor in doctorsInDepartment)
                {
                    doctorsInDepartment.Remove(doctor);
                }
            }
            catch
            {
                throw new UnsuccessfullOperationException("Failed to delete doctor from department");
            }
        }
       
    }
}
