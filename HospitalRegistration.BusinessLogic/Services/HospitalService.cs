using HospitalRegistration.DataAccess.DataContext;
using HospitalRegistration.DataAccess.Entities;
using HospitalRegistration.DataAccess.Exceptions;
using HospitalRegistration.DataAccess.Interfaces;
using HospitalRegistration.DataAccess.Repositories;

namespace HospitalRegistration.BusinessLogic.Services
{
    public class HospitalService : IHospitalService
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IUnitOfWork _unitOfWork;
        protected string Message;
        protected IDoctorRepository _doctorRepository;

        public HospitalService(IDepartmentRepository departmentRepository, IUnitOfWork unitOfWork, IDoctorRepository doctorRepository)
        {
            _departmentRepository = departmentRepository;
            _unitOfWork = unitOfWork;
            _doctorRepository = doctorRepository;
        }

        public HospitalService()
        {

        }

        public async Task DeleteDepartmentsAsync()
        {
            await _departmentRepository.RemoveAllDepartmentsAsync();
            _unitOfWork.SaveChanges();
        }

        public async Task<IEnumerable<Department>> GetAllAsync()
        {
            var departmentList = await _departmentRepository.GetAllAsync();
            return departmentList;
        }

        public async Task AsignDoctorToDepartmentAsync(Guid doctorId, Guid departmentId)
        {
            var departmentToBeAsignedTo = await _unitOfWork.DepartmentRepository.GetDepartmentAsync(departmentId);
            var doctorToBeAsigned = await _unitOfWork.DoctorRepository.GetDoctorAsync(doctorId);

            departmentToBeAsignedTo.Doctors.Add(doctorToBeAsigned);
            _unitOfWork.SaveChanges();
        }

        public async Task AsignSpecialtyToDoctorAsync(Guid doctorId, Guid specialtyId)
        {
            if(doctorId != null && specialtyId != null) { // might remove (if) if it is not relevant in this case

                await _unitOfWork.SpecialtyRepository.AsignSpecialtyToDocAsync(doctorId, specialtyId);
                _unitOfWork.SaveChanges();
            }
            else
            {
                throw new ObjectNotFoundException("Doctor or specialty was not found");
            }
        }

        public async Task AsignPatientToDoctorAsync(Guid doctorId, Guid patientId)
        {
            var patientToBeAsigned = await _unitOfWork.PatientRepository.GetPatientAsync(patientId);
            var doctorToBeAsignedTo = await _unitOfWork.DoctorRepository.GetDoctorAsync(doctorId);
            DoctorPatient doctorPatient = new();


            if(doctorToBeAsignedTo.DoctorPatients.Any(x => x.PatientId == patientToBeAsigned.Id))
            {
                throw new Exception("Patient already asignd to doctor");
            }
            else
            {
                doctorPatient.Patient = patientToBeAsigned;
                doctorPatient.Doctor = doctorToBeAsignedTo;

                await _unitOfWork.PatientRepository.AddDoctorPatientAsync(doctorPatient);
                _unitOfWork.SaveChanges();
            }
                
        }

        public async Task RegisterNewPatientAsync(string name, string lastName, DateTime dateOfBirth, string? illnessName)
        {
            Patient existingPatientInDB = await _unitOfWork.PatientRepository.CheckIfPatientExistsAsync(name, lastName, dateOfBirth);

            if(existingPatientInDB != null)
            {
               await _unitOfWork.PatientRepository.SignInExistingPatientAsync(existingPatientInDB.Id);
            }
            else
            {
                Patient newPatient = new Patient(name, lastName, dateOfBirth);
                PatientIllness newPatientIllness = new PatientIllness();
                Illness newIllness = new Illness(illnessName);

                newPatient.SignedIn = DateTime.UtcNow;
                newPatientIllness.Patient = newPatient;
                newPatientIllness.Illness = newIllness;

                await _unitOfWork.PatientRepository.AddPatientIllnessAsync(newPatientIllness);
                
            }

            _unitOfWork.SaveChanges();
        }

        public async Task RegisterNewDoctorAsync(string name, string lastName)
        {
            Doctor newDoctor = new Doctor(name, lastName);
            await _unitOfWork.DoctorRepository.AddAsync(newDoctor); // testuojant DoctorRepository nesukurtas instance
            _unitOfWork.SaveChanges();
        }


        public async Task DischargePatientAsync(Guid patientId)
        {
            var patientToBeDischarged = await _unitOfWork.PatientRepository.GetPatientAsync(patientId);
            if(patientToBeDischarged.SignedOut == null)
            {
                // pasalinti ligas is paciento. Pasalinti pacienta is DoctorPatient
                await _unitOfWork.PatientRepository.DischargeAsync(patientToBeDischarged.Id);
                _unitOfWork.SaveChanges();
            }
        }

        //TODO
        public async Task AsignPatientToNewDoctorAsync()
        {

        }
    }
}
