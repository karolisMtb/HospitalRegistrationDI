﻿using HospitalRegistration.DataAccess.DataContext;
using HospitalRegistration.DataAccess.Entities;
using HospitalRegistration.DataAccess.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalRegistration.DataAccess.Repositories
{
    public class DoctorRepository : Repository<Doctor>, IDoctorRepository
    {
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
        public IEnumerable<Patient> GetAllPatientsOfDoctor(Doctor doctor)
        {
            //TODO
            // galima naudoti databaseContext
            return null;
        }
       
    }
}
