using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZooApp.Services.Services;

namespace ZealandZoo.Pages
{
    public class AdminLoginModel : PageModel
    {
        private readonly AdminService _adminService;

        public AdminLoginModel(AdminService adminService)
        {
            _adminService = adminService;
        }

        [BindProperty]
        public string Username { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public string ErrorMessage { get; set; }

        public void OnGet() { }

        public IActionResult OnPost()
        {
            bool isValid = _adminService.ValidateLogin(Username, Password);

            if (!isValid)
            {
                ErrorMessage = "Forkerte loginoplysninger";
                return Page();
            }

            HttpContext.Session.SetString("IsAdmin", "true");
            return RedirectToPage("/AdminDashboard");
        }
    }
}
