using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZooApp.Services;
using ZooApp.Services.Interfaces;

namespace ZooApp.Web.Pages.Admin
{
    public class AdminLoginModel : PageModel
    {
        private readonly IAdminService _adminService;

        public AdminLoginModel(IAdminService adminService)
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
            return RedirectToPage("/Admin/AdminDashboard");
        }
    }
}
