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
       
        private string docName { get; set; }
        public string docsLastName { get; set; }
        public string specialtyName { get; set; }
        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPostAsync()
        {
            docName = Request.Form["_name"];
            docsLastName = Request.Form["_lastName"];
            specialtyName = Request.Form["_specialtyName"];

            return RedirectToPage("Result", "Doctor", 
            new { 
            doctorsName = docName,
            doctorsLastName = docsLastName,
            specialtyName = specialtyName
            });
        }
    }
}
