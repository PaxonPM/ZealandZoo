using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZealandZoo.Repositories;

namespace ZealandZoo.Pages
{
    public class AdminLoginModel : PageModel
    {
        private readonly AdminRepository _adminRepo;

        public AdminLoginModel(AdminRepository adminRepo)
        {
            _adminRepo = adminRepo;
        }

        [BindProperty]
        public string Username { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public string ErrorMessage { get; set; }

        public void OnGet() { }

        public IActionResult OnPost()
        {
            var admin = _adminRepo.GetByCredentials(Username, Password);

            if (admin == null)
            {
                ErrorMessage = "Forkerte loginoplysninger";
                return Page();
            }

            HttpContext.Session.SetString("IsAdmin", "true");
            return RedirectToPage("/AdminDashboard");
        }
    }
}