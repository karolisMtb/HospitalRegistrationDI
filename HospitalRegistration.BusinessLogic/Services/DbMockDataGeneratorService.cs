using HospitalRegistration.DataAccess.DataContext;
using HospitalRegistration.DataAccess.Entities;
using HospitalRegistration.DataAccess.Interfaces;
using Newtonsoft.Json;

namespace HospitalRegistration.BusinessLogic.Services
{
    public class DbMockDataGeneratorService : IGeneratorService
    {
        public List<Patient> PatientList { get; private set; }
        public List<Department> DepartmentList { get; set; }
        public List<Doctor> DoctorList { get; set; }
        public List<Illness> IllnessList { get; set; }
        public List<Specialty> SpecialtiesList { get; set; }

        public List<Patient> GeneratePatients()
        {
            PatientList = new List<Patient>();

            string path = @"C:\Users\Karolis\source\repos\HospitalRegistrationApp\HospitalRegistration.DataAccess\Files\Patients.json";

            if (File.Exists(path))
            {
                PatientList = JsonConvert.DeserializeObject<List<Patient>>(File.ReadAllText(path));
            }
            else
            {
                throw new FileNotFoundException();
            }
            //TODO perkelti path i appsettings.json
            return PatientList;
        }

        public List<Doctor> GenerateDoctors()
        {
            DoctorList = new List<Doctor>();

            //TODO perkelti path i appsettings.json
            string path = @"C:\Users\Karolis\source\repos\HospitalRegistrationApp\HospitalRegistration.DataAccess\Files\Doctors.json";

            if (File.Exists(path))
            {
                DoctorList = JsonConvert.DeserializeObject<List<Doctor>>(File.ReadAllText(path));
            }
            else
            {
                throw new FileNotFoundException();
            }

            return DoctorList;
        }

        public List<Department> GenerateDepartments()
        {
            DepartmentList = new List<Department>();
            DepartmentList.Add(new Department("ER"));
            DepartmentList.Add(new Department("Psychiatry"));
            DepartmentList.Add(new Department("Dental"));
            DepartmentList.Add(new Department("Neurology"));
            DepartmentList.Add(new Department("Paediatric"));
            DepartmentList.Add(new Department("Surgery"));
            DepartmentList.Add(new Department("Cardiology"));
            DepartmentList.Add(new Department("Orthopaedics"));

            return DepartmentList;
        }

        public List<Illness> GenerateIllnesses()
        {
            IllnessList = new List<Illness>();
            string path = @"C:\Users\Karolis\source\repos\HospitalRegistrationApp\HospitalRegistration.DataAccess\Files\Illnesses.json";
            if (File.Exists(path))
            {
                IllnessList = JsonConvert.DeserializeObject<List<Illness>>(File.ReadAllText(path));
            }
            else
            {
                throw new FileNotFoundException();
            }

            return IllnessList;
        }

        public List<Specialty> GenerateSpecialties()
        {
            SpecialtiesList = new();
            string path = @"C:\Users\Karolis\source\repos\HospitalRegistrationApp\HospitalRegistration.DataAccess\Files\Specialties.json";
            if (File.Exists(path))
            {
                SpecialtiesList = JsonConvert.DeserializeObject<List<Specialty>>(File.ReadAllText(path));
            }
            else
            {
                throw new FileNotFoundException();
            }

            return SpecialtiesList;
        }

    }
}
