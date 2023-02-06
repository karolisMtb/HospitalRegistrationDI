using HospitalRegistration.DataAccess.Entities;

namespace HospitalRegistration.DataAccess.Interfaces
{
    public interface IGeneratorService
    {
        List<Patient> GeneratePatients();
        List<Doctor> GenerateDoctors();
        List<Department> GenerateDepartments();
        List<Illness> GenerateIllnesses();
        List<Specialty> GenerateSpecialties();
    }
}
