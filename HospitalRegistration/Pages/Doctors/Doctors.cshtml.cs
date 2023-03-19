using HospitalRegistration.DataAccess.DataContext;
using HospitalRegistration.DataAccess.Entities;
using HospitalRegistration.DataAccess.Exceptions;
using HospitalRegistration.DataAccess.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace HospitalRegistration.Pages.Doctors
{
    public class DoctorsModel : PageModel
    {

        private readonly IHospitalService _hospitalService;

        public DoctorsModel(IHospitalService hospitalService)
        {
            _hospitalService = hospitalService;
        }
        
        [BindProperty]
        public IEnumerable<Doctor> DoctorsList { get; set; }

        //[BindProperty]
        protected internal IEnumerable<Department> _departmentList { get; set; }
        [BindProperty]
        public string docName { get; set; }
        [BindProperty]
        public string docsLastName { get; set; }
        [BindProperty]
        public string specialtyName { get; set; }
        public async void OnGetAsync()
        {
            DoctorsList = await _hospitalService.GetAllDoctorsAsync(); // ganu doctorslist uzkrovus puslapi. Filtruoti su JS kol typini
        }

        public async Task<IActionResult> OnPostAsync() // gaunu data submittines forma
        {
            docName = Request.Form["_name"];
            docsLastName = Request.Form["_lastName"];
            specialtyName = Request.Form["_specialtyName"];



            return RedirectToPage("Result","Doctors",
            new
            {
                //here come just list of doctor id's
            });

        }

        public async Task<IActionResult> OnResultAsync()
        {
            return RedirectToPage("Result");
        }
    }
}
