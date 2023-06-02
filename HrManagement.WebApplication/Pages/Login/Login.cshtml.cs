using HrManagement.AppService.ViewModels.Login;
using HrManagement.Security;
using HrManagement.Security.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HrManagement.WebApplication.Pages.Login
{
    public class LoginModel : PageModel
    {
        private readonly ILoginService _loginService;
        private readonly UserManager<ApplicationUser> _userManager;

        public void OnPageHandlerExecuted()
        {
            Response.Headers.Add("Access-Control-Allow-Origin", "*");
        }

        public LoginModel(ILoginService loginService, UserManager<ApplicationUser> userManager)
        {
            _loginService = loginService;
            _userManager = userManager;
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
                var user = await _loginService.GetUserAsync(Model.UserName);
                if (user != null && user.FirstAccess)
                {
                    if (!_loginService.IsValidTemporaryCredentials(Model.Password, user.TempPasswordHash))
                    {
                        ModelState.AddModelError(string.Empty, "Credenciais inválida.");
                    }
                    else
                    {
                        var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                        return RedirectToPage("/login/resetpassword", new { userId = user.Id, token });

                    }
                }
                else
                {
                    var result = await _loginService.SignIn(Model.UserName, Model.Password);
                    if (result.Succeeded)
                        return LocalRedirect("/privacy");

                    int attempt = await _loginService.GetAttemptAsync(Model.UserName);
                    ModelState.AddModelError(string.Empty, ValidationLogin.Validation(result, attempt));

                }

            }
            return Page();
        }

        public async Task<IActionResult> OnPostLogout()
        {
            await _loginService.SignOutAsync();
            return RedirectToPage("/login/login");
        }
    }
}
