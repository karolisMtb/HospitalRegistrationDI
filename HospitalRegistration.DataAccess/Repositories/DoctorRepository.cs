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
        public IGeneratorService<Doctor> DoctorGeneratorService { get; set; }
        public DoctorRepository(IGeneratorService<Doctor> DoctorGeneratorService, DatabaseContext databaseContext) : base(databaseContext)
        {
            this.DoctorGeneratorService = DoctorGeneratorService;
        }

        public DatabaseContext DatabaseContext
        {
            get
            {
                return dbContext as DatabaseContext;
            }
        }
        public IEnumerable<Patient> GetAllPatientsOfDoctor(Doctor doctor)
        {
            //TODO
            // galima naudoti databaseContext
            return null;
        }

        public void GenerateDoctors()
        {
            DatabaseContext.Doctors.AddRange(DoctorGeneratorService.Generate());
            // sita turi daryti UnitOfWork
            //DatabaseContext.SaveChanges();
        }
       
    }
}

