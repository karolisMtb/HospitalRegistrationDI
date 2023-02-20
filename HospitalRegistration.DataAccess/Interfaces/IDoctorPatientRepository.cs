using HospitalRegistration.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalRegistration.DataAccess.Interfaces
{
    public interface IDoctorPatientRepository
    {
        Task<DoctorPatient> GetDoctorPatient(Guid patientId);
        Task AddDoctorPatientAsync(DoctorPatient doctorPatient);
    }
}
