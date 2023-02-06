using HospitalRegistration.DataAccess.Entities;

namespace HospitalRegistration.DataAccess.Interfaces
{
    public interface IHospitalService
    {
        void DeleteDepartments();
        IEnumerable<Department> GetAll();
        void AsignDoctorToDepartment(Doctor doctor, Department department);
        void AsignSpecialtyToDoctor(Doctor doctor, Specialty specialty);
        void AsignPatientToDoctor(Doctor doctor, Patient patient);
        void RegisterNewPatient(string Name, string LastName, DateTime DateOfBirth, DateTime SignedIn, string IllnessName);
        void RegisterNewDoctor(string Name, string LastName, Specialty specialty);
        void AsignPatientToNewDoctor();
    }
}
