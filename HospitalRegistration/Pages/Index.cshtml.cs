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
        

        public async Task OnGet()
        {
            //patients = await _unitOfWork.PatientRepository.GetAllAsync();
        }
    }
}
