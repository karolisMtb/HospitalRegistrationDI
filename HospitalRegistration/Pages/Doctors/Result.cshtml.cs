using HospitalRegistration.DataAccess.DataContext;
using HospitalRegistration.DataAccess.Entities;
using HospitalRegistration.DataAccess.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Cryptography.X509Certificates;

namespace HospitalRegistration.Pages.Doctors
{
    public class ResultModel : PageModel
    {
        private readonly IHospitalService _hospitalService;

        public ResultModel(IHospitalService hospitalService)
        {
            _hospitalService = hospitalService;
        }

        //[BindProperty(SupportsGet = true)]
        //public Doctor Doctor { get; set; } 


        //[BindProperty(SupportsGet = true)]
        //public IEnumerable<Doctor> Doctors { get; set; }

        protected internal Doctor Doctor { get; set; }

        [BindProperty]
        public Guid Id { get; set; }

        public void OnPost()
        {

        }

        public async void OnGet(Guid id)
        {
            Doctor = await _hospitalService.GetDoctorById(id);
        }




    }
}
