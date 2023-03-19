using HospitalRegistration.DataAccess.DataContext;
using HospitalRegistration.DataAccess.Entities;
using HospitalRegistration.DataAccess.Exceptions;
using HospitalRegistration.DataAccess.Interfaces;
using HospitalRegistration.DataAccess.Repositories;

namespace HospitalRegistration.BusinessLogic.Services
{
    public class HospitalService : IHospitalService
    {
        private IDepartmentRepository _departmentRepository;
        private IUnitOfWork _unitOfWork;
        protected string Message;
        protected IDoctorRepository _doctorRepository;
        protected ISpecialtyRepository _specialtyRepository;
        protected IPatientRepository _patientRepository;
        protected IDoctorPatientRepository _doctorPatientRepository;

        public HospitalService(
            IDepartmentRepository departmentRepository, 
            IUnitOfWork unitOfWork, 
            IDoctorRepository doctorRepository, 
            IPatientRepository petientRepository, 
            ISpecialtyRepository specialtyRepository,
            IDoctorPatientRepository doctorPatientRepository)
        {
            _departmentRepository = departmentRepository;
            _unitOfWork = unitOfWork;
            _doctorRepository = doctorRepository;
            _patientRepository = petientRepository;
            _specialtyRepository = specialtyRepository;
            _doctorPatientRepository = doctorPatientRepository;
        }

        public HospitalService()
        {

        }

        public async Task DeleteDepartmentsAsync()
        {
            await _departmentRepository.RemoveAllDepartmentsAsync();
            _unitOfWork.SaveChanges();
        }

        public async Task<IEnumerable<Department>> GetAllDepartmentsAsync()
        {
            var departmentList = await _departmentRepository.GetAllAsync();
            return departmentList;
        }

        public async Task<IEnumerable<Doctor>> GetAllDoctorsAsync()
        {
            IEnumerable<Doctor> doctorsList = await _doctorRepository.GetAllAsync();
            return doctorsList;
        }

        public async Task AsignDoctorToDepartmentAsync(Guid doctorId, Guid departmentId) //tested
        {
            Department departmentToBeAsignedTo = await _departmentRepository.GetDepartmentAsync(departmentId);
            var doctorToBeAsigned = await _doctorRepository.GetDoctorAsync(doctorId);
            departmentToBeAsignedTo.Doctors.Add(doctorToBeAsigned);
            await _unitOfWork.SaveChanges();
        }

        public async Task AsignSpecialtyToDoctorAsync(Guid doctorId, Guid specialtyId) //tested
        {
            await _specialtyRepository.AsignSpecialtyToDocAsync(doctorId, specialtyId);
            await _unitOfWork.SaveChanges();
        }

        public async Task AsignPatientToDoctorAsync(Guid doctorId, Guid patientId)
        {
            var patientToBeAsigned = await _patientRepository.GetPatientAsync(patientId);
            var doctorToBeAsignedTo = await _doctorRepository.GetDoctorAsync(doctorId);
            DoctorPatient doctorPatient = new();


            if (doctorToBeAsignedTo.DoctorPatients.Any(x => x.PatientId == patientToBeAsigned.Id))
            {
                throw new Exception("Patient already asignd to doctor");
            }
            else
            {
                doctorPatient.Patient = patientToBeAsigned;
                doctorPatient.Doctor = doctorToBeAsignedTo;

                await _patientRepository.AddDoctorPatientAsync(doctorPatient);
                await _unitOfWork.SaveChanges();
            }

        }

        public async Task RegisterNewPatientAsync(string name, string lastName, DateTime dateOfBirth, string? illnessName)
        {
            Patient existingPatientInDB = await _patientRepository.CheckIfPatientExistsAsync(name, lastName, dateOfBirth);

            if (existingPatientInDB != null)
            {
                await _patientRepository.SignInExistingPatientAsync(existingPatientInDB.Id, illnessName);
            }
            else
            {
                Patient newPatient = new Patient(name, lastName, dateOfBirth);
                await _patientRepository.AddAsync(newPatient);
                
                if(illnessName != null)
                {
                    PatientIllness newPatientIllness = new PatientIllness();
                    Illness newIllness = new Illness(illnessName);

                    newPatient.SignedIn = DateTime.UtcNow;
                    newPatientIllness.Patient = newPatient;
                    newPatientIllness.Illness = newIllness;

                    await _patientRepository.AddPatientIllnessAsync(newPatientIllness);
                }
            }

            await _unitOfWork.SaveChanges();
        }

        public async Task RegisterNewDoctorAsync(string name, string lastName)
        {
            await _doctorRepository.AddAsync(new Doctor(name, lastName));
            await _unitOfWork.SaveChanges();
        }


        public async Task DischargePatientAsync(Guid patientId)
        {
            Patient patientToBeDischarged = await _patientRepository.GetPatientAsync(patientId);
            if (patientToBeDischarged.SignedOut == null)
            {
                await _patientRepository.DischargeAsync(patientToBeDischarged.Id);
                await _unitOfWork.SaveChanges();
            }
        }

        public async Task AsignPatientToNewDoctorAsync(Guid patientId, Guid newDoctorId) // not tested
        {
            DoctorPatient doctorPatient = await _doctorPatientRepository.GetDoctorPatient(patientId);
            doctorPatient.DoctorId = newDoctorId;
            await _doctorPatientRepository.AddDoctorPatientAsync(doctorPatient);
            await _unitOfWork.SaveChanges();
        }

        public async Task<IEnumerable<Doctor>> FindDoctorsByNameAsync(string name)
        {
            List<Doctor> doctors = new();
            doctors =  await _doctorRepository.GetDoctorsByNameAsync(name);
            return doctors;
        }

        public Task<Department> GetDepartmentByIdAsync(Guid departmentId)
        {
            return _departmentRepository.GetDepartmentAsync(departmentId);
        }

        public Task<Doctor> GetDoctorById(Guid doctorId)
        {
            return _doctorRepository.GetDoctorAsync(doctorId);
        }
    }
}
