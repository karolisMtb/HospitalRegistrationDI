using HospitalRegistration.DataAccess.DataContext;
using HospitalRegistration.DataAccess.Entities;
using HospitalRegistration.DataAccess.Interfaces;
using HospitalRegistration.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalRegistration.DataAccess.Repositories
{
    public class DoctorRepository : Repository<Doctor>, IDoctorRepository
    {
        public IEnumerable<Doctor> DoctorsOfPatient { get; set; }
        public DoctorRepository(DatabaseContext databaseContext) : base(databaseContext)
        {

        }

        public DatabaseContext DatabaseContext
        {
            get
            {
                return dbContext as DatabaseContext;
            }
        }
        public Doctor GetDoctor(Doctor doctor)
        {
            return DatabaseContext.Doctors.FirstOrDefault(doctor);
        }

        public IEnumerable<Doctor> GetAllDoctorsOfPatient(Patient patient)
        {
            DoctorsOfPatient = new List<Doctor>();
            DoctorsOfPatient = (IEnumerable<Doctor>)DatabaseContext.DoctorPatients.Include(x => x.Doctor).Where(x => x.PatientId == patient.Id).Select(x => x.Patient);
            return DoctorsOfPatient;
        }
            
    }
}

