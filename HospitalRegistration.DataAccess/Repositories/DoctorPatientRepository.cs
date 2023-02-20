using HospitalRegistration.DataAccess.DataContext;
using HospitalRegistration.DataAccess.Entities;
using HospitalRegistration.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalRegistration.DataAccess.Repositories
{
    public class DoctorPatientRepository : Repository<DoctorPatient>, IDoctorPatientRepository
    {
        public DoctorPatientRepository(DatabaseContext databaseContext) : base(databaseContext)
        {

        }

        private DatabaseContext DatabaseContext => dbContext as DatabaseContext;

        public async Task<DoctorPatient> GetDoctorPatient(Guid patientId)
        {
            return DatabaseContext.DoctorPatients.Include(doctor => doctor.Doctor).Where(patient => patient.PatientId == patientId).First();
        }

        public async Task AddDoctorPatientAsync(DoctorPatient doctorPatient)
        {
            DatabaseContext.DoctorPatients.Add(doctorPatient);
        }

    }
}
