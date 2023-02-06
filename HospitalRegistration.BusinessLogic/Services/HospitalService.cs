using HospitalRegistration.DataAccess.DataContext;
using HospitalRegistration.DataAccess.Entities;
using HospitalRegistration.DataAccess.Interfaces;

namespace HospitalRegistration.BusinessLogic.Services
{
    public class HospitalService : IHospitalService
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly DatabaseContext _databaseContext;
        public string Message;

        public HospitalService(IDepartmentRepository departmentRepository, IUnitOfWork unitOfWork, DatabaseContext databaseContext)
        {
            _departmentRepository = departmentRepository;
            _unitOfWork = unitOfWork;
            _databaseContext = databaseContext;
        }

        public void DeleteDepartments()
        {
            if(GetAll().ToList().Count != 0)
            {
                _departmentRepository.RemoveAllDepartments();
            }
            _unitOfWork.SaveChanges();
        }

        public IEnumerable<Department> GetAll()
        {
            return _departmentRepository.GetAll();
        }

        public void AsignDoctorToDepartment(Doctor doctor, Department department)
        {
            var doctorToBeAsigned = _unitOfWork.DoctorRepository.GetDoctor(doctor);
            var departmentToBeAsignedTo = _unitOfWork.DepartmentRepository.GetDepartment(department);
            bool doctorAlreadyExistsInDepartment = departmentToBeAsignedTo.Doctors.Any(x => x.DepartmentId == doctor.Id);

            if (doctor != null && department != null && !doctorAlreadyExistsInDepartment)
            {
                departmentToBeAsignedTo.Doctors.Add(doctorToBeAsigned);
                _unitOfWork.SaveChanges();
            }
        }

        public void AsignSpecialtyToDoctor(Doctor doctor, Specialty specialty)
        {
            var doctorToBeAsignedTo = _unitOfWork.DoctorRepository.GetDoctor(doctor);
            var specialtyToBeAsigned = _unitOfWork.SpecialtyRepository.GetSpecialty(specialty);
            bool doctorHasSpecialty = doctorToBeAsignedTo.Specialties.Contains(specialty);
            if(doctor != null && specialty != null && !doctorHasSpecialty)
            {
                doctorToBeAsignedTo.Specialties.Add(specialtyToBeAsigned);
                _unitOfWork.SaveChanges();
            }
            else
            {
                Message = "Doctor already has this specialty";
            }
        }

        public void AsignPatientToDoctor(Doctor doctor, Patient patient)
        {
            var patientToBeAsigned = _unitOfWork.PatientRepository.GetPatient(patient);
            var doctorToBeAsignedTo = _unitOfWork.DoctorRepository.GetDoctor(doctor);
            DoctorPatient doctorPatient = new();


            if(doctorToBeAsignedTo.DoctorPatients.Any(x => x.PatientId == patientToBeAsigned.Id))
            {
                Message = "This patient is already asigned to doctor";
                return;
            }
            else
            {
                doctorPatient.Patient = patientToBeAsigned;
                doctorPatient.Doctor = doctorToBeAsignedTo;
                doctorPatient.Count = 1;

                _unitOfWork.PatientRepository.AddDoctorPatient(doctorPatient);
                _unitOfWork.SaveChanges();
            }
                
        }

        public void RegisterNewPatient(string Name, string LastName, DateTime DateOfBirth, DateTime SignedIn, string IllnessName)
        {
            Patient newPatient = new Patient(Name, LastName, DateOfBirth);
            Illness newIllness = new Illness(IllnessName);
            newPatient.SignedIn = SignedIn;


            PatientIllness patientIllness = new PatientIllness();
            patientIllness.Illness = newIllness;
            patientIllness.Patient = newPatient;

            _unitOfWork.PatientRepository.AddPatientIllness(patientIllness);
            _unitOfWork.SaveChanges();
        }

        public void RegisterNewDoctor(string Name, string LastName, Specialty specialty)
        {
            Doctor newDoctor = new Doctor(Name, LastName);
            newDoctor.Specialties.Add(specialty);
            _unitOfWork.DoctorRepository.Add(newDoctor);
            _unitOfWork.SaveChanges();
        }

        public void DischargePatient(Patient patient)
        {
            var patientToBeDischarged = _unitOfWork.PatientRepository.GetPatient(patient);
            if(patientToBeDischarged.SignedIn != null)
            {
                patientToBeDischarged.SignedOut = DateTime.Now;
                _unitOfWork.PatientRepository.Remove(patientToBeDischarged);
                _unitOfWork.SaveChanges();
            }
        }

        //TODO
        public void AsignPatientToNewDoctor()
        {

        }
    }
}
