using HospitalRegistration.DataAccess.DataContext;
using HospitalRegistration.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalRegistration.DataAccess.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DatabaseContext _databaseContext;
        public IPatientRepository Patients { get; private set; }
        public IDepartmentRepository Departments { get; private set; }
        public IDoctorRepository Doctors { get; private set; }
        public UnitOfWork(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
            Patient = // new PatientRepository(_databaseContext);
        }
    }
}
