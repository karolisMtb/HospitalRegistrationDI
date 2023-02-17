using HospitalRegistration.DataAccess.DataContext;
using HospitalRegistration.DataAccess.Entities;
using HospitalRegistration.DataAccess.Interfaces;
using System.Runtime.CompilerServices;

namespace HospitalRegistration.DataAccess.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext _databaseContext;
        //public IPatientRepository PatientRepository { get;  set; }
        //public IDepartmentRepository DepartmentRepository { get;  set; }
        //public IDoctorRepository DoctorRepository { get;  set; }
        //public IIlnessRepository IllnessRepository { get;  set; }
        //public ISpecialtyRepository SpecialtyRepository { get;  set; }
        //public UnitOfWork(
        //    DatabaseContext databaseContext,
        //    IPatientRepository patientRepository,
        //    IDepartmentRepository departmentRepository,
        //    IDoctorRepository doctorRepository,
        //    IIlnessRepository ilnessRepository,
        //    ISpecialtyRepository specialtyRepository)
        //{
        //    _databaseContext = databaseContext;
        //    PatientRepository = patientRepository;
        //    DepartmentRepository = departmentRepository;
        //    DoctorRepository = doctorRepository;
        //    IllnessRepository = ilnessRepository;
        //    SpecialtyRepository = specialtyRepository;
        //}

        public UnitOfWork()
        {

        }

        public async Task AddToDoctorRepository(Doctor doctor)
        {
            //await DoctorRepository.AddAsync(doctor);
        }

        public async Task SaveChanges()
        {
            await _databaseContext.SaveChangesAsync();
        }
    }
}
