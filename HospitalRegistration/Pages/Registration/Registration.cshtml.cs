using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HospitalRegistration.Pages.Registration
{
    public class RegistrationModel : PageModel
    {
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync() // submit forma method="post"
        {
            return RedirectToPage("/Doctors/Doctors");
        }
    }
}

// is registration, reikia eiti atgal i kita folderi "/Doctors" ir pasiekti kita faila "/Doctors"
// return RedirectToPage("/Doctors/Doctors"); jei noriu is sito puslapio nueiti i Doctors puslapi
