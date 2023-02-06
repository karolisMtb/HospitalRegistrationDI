using HospitalRegistration.BusinessLogic.Services;
using HospitalRegistration.DataAccess.DataContext;
using HospitalRegistration.DataAccess.Entities;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalRegistration.BusinessLogic
{
    public class DbInitializerService
    {
        public static void Initialize(DatabaseContext dbContext)
        {
            DbMockDataGeneratorService dbMockDataGeneratorService = new DbMockDataGeneratorService();

            ArgumentNullException.ThrowIfNull(dbContext, nameof(dbContext));
            dbContext.Database.EnsureCreated();
            if (dbContext.Illnesses.Any() &&
                dbContext.DoctorSpecialties.Any() &&
                dbContext.Doctors.Any() &&
                dbContext.Patients.Any() &&
                dbContext.Departments.Any()) return;

            var illnesses = dbMockDataGeneratorService.GenerateIllnesses();
            var specialties = dbMockDataGeneratorService.GenerateSpecialties();
            var doctors = dbMockDataGeneratorService.GenerateDoctors();
            var patients = dbMockDataGeneratorService.GeneratePatients();
            var departments = dbMockDataGeneratorService.GenerateDepartments();


            dbContext.Illnesses.AddRange(illnesses);
            dbContext.DoctorSpecialties.AddRange(specialties);
            dbContext.Doctors.AddRange(doctors);
            dbContext.Patients.AddRange(patients);
            dbContext.Departments.AddRange(departments);

            dbContext.SaveChanges();
        }
    }
}
