using HospitalRegistration.DataAccess.Entities;

namespace HospitalRegistration.DataAccess.Interfaces
{
    public interface IIlnessRepository : IRepository<Illness>
    {
        Task AsignIllnessToPatientAsync(Guid patientId, string illnessName);
    }
}
