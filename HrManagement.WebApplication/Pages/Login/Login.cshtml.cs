using HrManagement.AppService.ViewModels.Login;
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
        public new LoginPageModel Model { get; set; }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var result = await _loginService.SignIn(Model.UserName, Model.Password);
                if (result.Succeeded)
                    return LocalRedirect("/privacy");

                int attempt = await _loginService.GetAttemptAsync(Model.UserName);
                ModelState.AddModelError("", ValidationLogin.Validation(result, attempt));
            }
            return Page();
        }
    }
}
