using HospitalRegistration.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
