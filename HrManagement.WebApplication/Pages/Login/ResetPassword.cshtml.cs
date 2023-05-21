using HrManagement.AppService.ViewModels.Login;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HrManagement.WebApplication.Pages.Login
{
    public class ResetPasswordModel : PageModel
    {
        [BindProperty]
        public new PasswordResetPageModel Model { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost() 
        {
            if (ModelState.IsValid)
            {
                return LocalRedirect("/login");
            }
            return Page();
        }
    }
}
