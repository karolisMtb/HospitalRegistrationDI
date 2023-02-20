using HospitalRegistration.DataAccess.Entities;
using HospitalRegistration.DataAccess.Interfaces;
using HospitalRegistration.DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HospitalRegistration.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IHospitalService _hospitalService;
        private readonly IPatientRepository _patientRepository;
        public IEnumerable<Patient> patients;
        public IndexModel(IHospitalService hospitalService, IPatientRepository patientRepository)
        {
            _hospitalService = hospitalService;
            _patientRepository = patientRepository;

        }        
        

        public async Task OnGet()
        {
            patients = await _patientRepository.GetAllAsync();
        }
    }
}
