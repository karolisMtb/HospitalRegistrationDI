using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalRegistration.DataAccess.Interfaces
{
    public interface IUnitOfWork
    {
        IPatientRepository Patients { get;}
        IDepartmentRepository Departments { get; }
        IDoctorRepository Doctors { get; }
        void SaveChanges();
    }
}
