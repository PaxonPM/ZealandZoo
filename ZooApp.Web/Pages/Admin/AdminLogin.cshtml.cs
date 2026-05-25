using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
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
        [Required(ErrorMessage = "Brugernavn er påkrævet")]
        public string Username { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Kodeord er påkrævet")]
        public string Password { get; set; }

        public string ErrorMessage { get; set; }

        public void OnGet()
        {
            if (TempData["ErrorMessage"] is string message)
            {
                ErrorMessage = message;
            }
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            ZooApp.Domain.Models.UserModel? admin = _adminService.ValidateLogin(Username, Password);

            if (admin == null)
            {
                ErrorMessage = "Forkerte loginoplysninger";
                return Page();
            }

            HttpContext.Session.SetString("IsAdmin", "true");
            HttpContext.Session.SetString("AdminUsername", admin.Name);

            return RedirectToPage("/index");
        }
    }
}
