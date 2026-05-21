using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZooApp.Services;
using ZooApp.Services.Interfaces;

namespace ZooApp.Web.Pages.User
{
    public class StaffLoginModel : PageModel
    {
        private readonly IStaffService _staffService;

        public StaffLoginModel(IStaffService staffService)
        {
            _staffService = staffService;
        }

        [BindProperty]
        public string Email { get; set; } = "";

        [BindProperty]
        public string Password { get; set; } = "";

        public string ErrorMessage { get; set; } = "";

        public void OnGet() { }

        public IActionResult OnPost()
        {
            ZooApp.Domain.Models.UserModel? User = _staffService.ValidateLogin(Email, Password);

            if (User == null)
            {
                ErrorMessage = "Forkerte loginoplysninger";
                return Page();
            }

            HttpContext.Session.SetString("IsStaff", "true");
            HttpContext.Session.SetString("Name", User.Name);
           

            return RedirectToPage("/Index");
        }
    }
}

