using HospitalRegistration.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalRegistration.DataAccess.Interfaces
{
    public interface IDepartmentRepository : IRepository<Department>
    {
        IEnumerable<Doctor> GetAllDoctorsOfDepartment(Department department);
        IEnumerable<Patient> GetAllPatientsOfDepartment(Department department);
        Department GetDepartment(Department department);
        void RemoveDoctorFromDepartment(Doctor doctor, Department department);
        void RemoveAllDepartments();
    }
}
