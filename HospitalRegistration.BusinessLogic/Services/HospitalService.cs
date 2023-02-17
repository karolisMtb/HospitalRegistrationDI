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

        public HospitalService(
            IDepartmentRepository departmentRepository, 
            IUnitOfWork unitOfWork, 
            IDoctorRepository doctorRepository, 
            IPatientRepository petientRepository, 
            ISpecialtyRepository specialtyRepository)
        {
            _departmentRepository = departmentRepository;
            _unitOfWork = unitOfWork;
            _doctorRepository = doctorRepository;
            _patientRepository = petientRepository;
            _specialtyRepository = specialtyRepository;
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
            var departmentToBeAsignedTo = await _departmentRepository.GetDepartmentAsync(departmentId);
            var doctorToBeAsigned = await _doctorRepository.GetDoctorAsync(doctorId);
            departmentToBeAsignedTo.Doctors.Add(doctorToBeAsigned);
            await _unitOfWork.SaveChanges();
        }

        public async Task AsignSpecialtyToDoctorAsync(Guid doctorId, Guid specialtyId)
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
                await _patientRepository.SignInExistingPatientAsync(existingPatientInDB.Id);
            }
            else
            {
                Patient newPatient = new Patient(name, lastName, dateOfBirth);
                PatientIllness newPatientIllness = new PatientIllness();
                Illness newIllness = new Illness(illnessName);

                newPatient.SignedIn = DateTime.UtcNow;
                newPatientIllness.Patient = newPatient;
                newPatientIllness.Illness = newIllness;

                await _patientRepository.AddPatientIllnessAsync(newPatientIllness);
            }

            await _unitOfWork.SaveChanges();
        }

        public async Task RegisterNewDoctorAsync(string name, string lastName)
        {
            await _unitOfWork.AddToDoctorRepository(new Doctor(name, lastName));
            await _unitOfWork.SaveChanges();
        }


        public async Task DischargePatientAsync(Guid patientId)
        {
            var patientToBeDischarged = await _patientRepository.GetPatientAsync(patientId);
            if (patientToBeDischarged.SignedOut == null)
            {
                // pasalinti ligas is paciento. Pasalinti pacienta is DoctorPatient
                await _patientRepository.DischargeAsync(patientToBeDischarged.Id);
                _unitOfWork.SaveChanges();
            }
        }

        //TODO
        public async Task AsignPatientToNewDoctorAsync()
        {

        }
    }
}
