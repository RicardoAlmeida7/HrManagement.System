using HrManagement.Security;
using HrManagement.Security.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HrManagement.WebApplication.Pages.Login
{
    public class LoginModel : PageModel
    {
        private readonly ILoginService _loginService;

        public LoginModel(ILoginService loginService)
        {
            _loginService = loginService;
        }
        
        [BindProperty]
        public new ApplicationUser User { get; set; }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            var result = await _loginService.SignIn(User.UserName, User.PasswordHash);
            if (result.Succeeded)
            {
                return LocalRedirect("/privacy");
            }
            else
            {
                int attempt = await _loginService.GetAttemptAsync(User.UserName);
                ModelState.AddModelError("", ValidationLogin.Validation(result, attempt));
            }
            return Page();
        }
    }
}
