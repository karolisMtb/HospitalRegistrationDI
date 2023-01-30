using HospitalRegistration.DataAccess.DataContext;
using HospitalRegistration.DataAccess.Entities;
using HospitalRegistration.DataAccess.Interfaces;
using HospitalRegistration.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalRegistration.BusinessLogic.Services
{
    public class DepartmentGeneratorService : IGeneratorService<Department>//, IDepartmentGeneratorService
    {
        List<Department> departments;
       
        public List<Department> Generate()
        {
            departments = new List<Department>();
            departments.Add(new Department("ER"));
            departments.Add(new Department("Psychiatry"));
            departments.Add(new Department("Dental"));
            departments.Add(new Department("Neurology"));
            departments.Add(new Department("Paediatric"));
            departments.Add(new Department("Surgery"));
            departments.Add(new Department("Cardiology"));
            departments.Add(new Department("Orthopaedics"));

            return departments;
        }
    }
}

