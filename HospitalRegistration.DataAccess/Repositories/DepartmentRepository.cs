using HospitalRegistration.DataAccess.DataContext;
using HospitalRegistration.DataAccess.Entities;
using HospitalRegistration.DataAccess.Interfaces;
using HospitalRegistration.DataAccess.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace HospitalRegistration.DataAccess.Repositories
{
    public class DepartmentRepository : Repository<Department>, IDepartmentRepository
    {
        public IEnumerable<Department> departmentList { get; set; }
        public DepartmentRepository( DatabaseContext databaseContext) : base(databaseContext)
        {

        }

        public DatabaseContext DatabaseContext => dbContext as DatabaseContext;

        public void RemoveAllDepartments()
        {
            foreach (var department in DatabaseContext.Departments)
            {
                DatabaseContext.Departments.Remove(department);
            }
        }

        public Department GetDepartment(Department department)
        {
            var matchingDepartment = DatabaseContext.Departments.Where(x=> x.Id== department.Id).FirstOrDefault();
            if (matchingDepartment == null)
            {
                throw new FailedDbActionException("Department was not found");
            }
            else
            {
                return matchingDepartment;
            }
        }

        public IEnumerable<Department> GetAllDepartments()
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
            departmentList = GetAllDepartments();

            return departmentList.Where(department => department.Id == department.Id).SelectMany(department => department.Doctors).ToList();
        }

        public IEnumerable<Patient> GetAllPatientsOfDepartment(Department department)
        {
            IEnumerable<Doctor> doctorsOfDepartment = GetAllDoctorsOfDepartment(department);
            IEnumerable<Patient> patientsOfDepartment = new List<Patient>();
            foreach (var doctor in doctorsOfDepartment)
            {
               patientsOfDepartment = DatabaseContext.DoctorPatients.Include(doctorPatient => doctorPatient.Patient).Where(doctorPatient => doctorPatient.DoctorId == doctor.Id).Select(x => x.Patient);
            }
            return patientsOfDepartment;
        }
        
        public void RemoveDoctorFromDepartment(Doctor doctor, Department department)
        {
            bool doctorExistsInDepartment = department.Doctors.Any(x => x.Id == doctor.Id);
            if(doctor != null && department != null && doctorExistsInDepartment)
            {
                var doctorToRemove = DatabaseContext.Departments.Find(department).Doctors.Where(x => x.Id == doctor.Id);
                DatabaseContext.Remove(doctorToRemove);
            }
        }
       
    }
}
