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
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHospitalService _hospitalService;
        public IEnumerable<Patient> patients { get; set; }
        public IndexModel(IUnitOfWork unitOfWork, IHospitalService hospitalService)
        {
            _unitOfWork = unitOfWork;
            _hospitalService = hospitalService;
        }        
        

        public void OnGet()
        {
            patients = _unitOfWork.PatientRepository.GetAll();
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
