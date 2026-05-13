using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ZooApp.Services;

namespace ZooApp.Web.Pages.User
{
    public class StaffLoginModel : PageModel
    {
        private readonly UserService _userService;

        public StaffLoginModel(UserService userService)
        {
            _userService = userService;
        }

        [BindProperty]
        public string Username { get; set; } = "";

        [BindProperty]
        public string Password { get; set; } = "";

        public string ErrorMessage { get; set; } = "";

        public void OnGet() { }

        public IActionResult OnPost()
        {
            ZooApp.Domain.Models.User? user = _userService.ValidateLogin(Username, Password);

            if (user == null)
            {
                ErrorMessage = "Forkerte loginoplysninger";
                return Page();
            }

            HttpContext.Session.SetString("IsStaff", "true");
            HttpContext.Session.SetString("Name", user.Name);
           

            return RedirectToPage("/Index");
        }
    }
}

