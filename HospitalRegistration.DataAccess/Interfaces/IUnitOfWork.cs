namespace HospitalRegistration.DataAccess.Interfaces
{
    public interface IUnitOfWork
    {
        IPatientRepository PatientRepository { get; }
        IDepartmentRepository DepartmentRepository { get; }
        IDoctorRepository DoctorRepository { get; }
        ISpecialtyRepository SpecialtyRepository { get; }
        IIlnessRepository IllnessRepository { get; }
        void SaveChanges();
    }
}
