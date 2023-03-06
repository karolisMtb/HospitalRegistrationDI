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

        [BindProperty(Name = "doctorsName", SupportsGet = true)]
        public string doctorsName { get; set; }

        [BindProperty(Name = "doctorsLastName", SupportsGet = true)]
        public string doctorsLastName { get; set; }

        [BindProperty(Name = "specialtyName", SupportsGet = true)]
        public string specialtyName { get; set; }
        public IEnumerable<Doctor> doctorList { get; set; }
        public Department department { get; set; }

        public async void OnGetDoctor()
        {
            doctorList = await _hospitalService.FindDoctorsByNameAsync(doctorsName);

        }



    }
}
