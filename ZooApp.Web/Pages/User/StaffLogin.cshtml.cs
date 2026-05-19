using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZooApp.Services;
using ZooApp.Services.Interfaces;

namespace ZooApp.Web.Pages.User
{
    public class StaffLoginModel : PageModel
    {
        private readonly IUserService _userService;

        public StaffLoginModel(IUserService userService)
        {
            _userService = userService;
        }

        [BindProperty]
        public string Email { get; set; } = "";

        [BindProperty]
        public string Password { get; set; } = "";

        public string ErrorMessage { get; set; } = "";

        public void OnGet() { }

        public IActionResult OnPost()
        {
            ZooApp.Domain.Models.User? User = _userService.ValidateLogin(Email, Password);

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

