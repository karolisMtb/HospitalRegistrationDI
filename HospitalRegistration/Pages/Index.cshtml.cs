using HospitalRegistration.DataAccess.Entities;
using HospitalRegistration.DataAccess.Interfaces;
using HospitalRegistration.DataAccess.Repositories;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HospitalRegistration.Pages
{
    public class IndexModel : PageModel
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly IHospitalService _hospitalService;
        public IEnumerable<Patient> patients;
        public IndexModel(UnitOfWork unitOfWork, IHospitalService hospitalService)
        {
            _unitOfWork = unitOfWork;
            _hospitalService = hospitalService;
        }        
        

        public async Task OnGet()
        {
            //patients = await _unitOfWork.PatientRepository.GetAllAsync();
        }
    }
}
