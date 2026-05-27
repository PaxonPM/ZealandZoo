using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
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
        [Required(ErrorMessage = "Email er påkrævet")]
        public string Email { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "Kodeord er påkrævet")]
        public string Password { get; set; }

        public string ErrorMessage { get; set; } = "";

        public void OnGet() { }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
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

