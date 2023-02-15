using HospitalRegistration.DataAccess.DataContext;
using HospitalRegistration.DataAccess.Interfaces;

namespace HospitalRegistration.DataAccess.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext _databaseContext;
        public virtual IPatientRepository PatientRepository { get;  set; }
        public virtual IDepartmentRepository DepartmentRepository { get;  set; }
        public virtual IDoctorRepository DoctorRepository { get;  set; }
        public virtual IIlnessRepository IllnessRepository { get;  set; }
        public virtual ISpecialtyRepository SpecialtyRepository { get;  set; }
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
            IllnessRepository = ilnessRepository;
            SpecialtyRepository = specialtyRepository;
        }

        public UnitOfWork()
        {

        }
        public void SaveChanges()
        {
            _databaseContext.SaveChanges();
        }
        // prideti write line query string i metoda kuris turi du add metodus i db ir tikrinti ar mes klaida po SaveChanges(); Rokui

    }
}
