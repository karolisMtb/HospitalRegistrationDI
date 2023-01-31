using HospitalRegistration.BusinessLogic.Services;
using HospitalRegistration.DataAccess.DataContext;
using HospitalRegistration.DataAccess.Entities;
using HospitalRegistration.DataAccess.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace HospitalRegistration.Pages
{
    public class IndexModel : PageModel
    {
        public IDbService _dbService;

        public IGeneratorService DbMockDataGeneratorService;
        public IUnitOfWork unitOfWork;

        public IndexModel(IDbService dbService, IGeneratorService dbMockDataGeneratorService, IUnitOfWork unitOfWork)
        {
            _dbService = dbService;
            DbMockDataGeneratorService = dbMockDataGeneratorService;
            this.unitOfWork = unitOfWork;           
        }

        public void OnGetTest()
        {
            var patients = DbMockDataGeneratorService.GeneratePatients();
            var docs = DbMockDataGeneratorService.GenerateDoctors();
            var departments = DbMockDataGeneratorService.GenerateDepartments();
            var illnesses = DbMockDataGeneratorService.GenerateIllnesses();
            var specialties = DbMockDataGeneratorService.GenerateSpecialties();

            if(
                patients.Count != 0 &&
                docs.Count != 0 &&
                departments.Count != 0)
            {
                
                unitOfWork.PatientRepository.AddRange(patients);
                unitOfWork.DoctorRepository.AddRange(docs);
                unitOfWork.DepartmentRepository.AddRange(departments);
                unitOfWork.SaveChanges();
            }
        }
        

        public void OnGet()
        {
            var departments = _dbService.GetAll().ToList();
        }
    }
}


//Studentų informacinė sistema:

//Entities:
//1.Departamentas.Turi: Daug studentų, daug paskaitų.
//2. Paskaita. Turi: Daug departamentų.
//3. Studentas.Turi: Daug paskaitų, vieną departamentą.

//Funkcionalumai:
//1. Sukurti departamentą ir į jį pridėti studentus, paskaitas(papildomi points jei pridedamos paskaitos jau egzistuojančios duomenų bazėje).
//2.Pridėti studentus / paskaitas į jau egzistuojantį departamentą.
//3. Sukurti paskaitą ir ją priskirti prie departamento.
//4. Sukurti studentą, jį pridėti prie egzistuojančio departamento ir priskirti jam egzistuojančias paskaitas.
//5. Perkelti studentą į kitą departamentą(bonus points jei pakeičiamos ir jo paskaitos).
//6.Atvaizduoti visus departamento studentus.
//7. Atvaizduoti visas departamento paskaitas.
//8. Atvaizduoti visas paskaitas pagal studentą.
