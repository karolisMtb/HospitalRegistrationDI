using HospitalRegistration.DataAccess.DataContext;
using HospitalRegistration.DataAccess.Interfaces;

namespace HospitalRegistration.DataAccess.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext _databaseContext;
        public IPatientRepository PatientRepository { get; private set; }
        public IDepartmentRepository DepartmentRepository { get; private set; }
        public IDoctorRepository DoctorRepository { get; private set; }
        public IIlnessRepository ilnessRepository { get; private set; }
        public ISpecialtyRepository specialtyRepository { get; private set; }
        public UnitOfWork(DatabaseContext databaseContext,
            IPatientRepository patientRepository,
            IDepartmentRepository departmentRepository,
            IDoctorRepository doctorRepository,
            IIlnessRepository ilnessRepository,
            ISpecialtyRepository specialtyRepository)
        {
            _databaseContext = databaseContext;
            PatientRepository = patientRepository;
            DepartmentRepository = departmentRepository;
            DoctorRepository = doctorRepository;
            this.ilnessRepository = ilnessRepository;
            this.specialtyRepository = specialtyRepository;
        }
        public void SaveChanges()
        {
            _databaseContext.SaveChanges();
        }
    }
}
