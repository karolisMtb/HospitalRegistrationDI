using HospitalRegistration.DataAccess.DataContext;
using HospitalRegistration.DataAccess.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HospitalRegistration.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public static AppConfiguration settings { get; set; }
        public IEnumerable<Department> Departments = new List<Department>();
        public DatabaseContext DatabaseContext = new DatabaseContext(settings);
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            var departments = DatabaseContext.Departments.ToList();
        }
    }
}