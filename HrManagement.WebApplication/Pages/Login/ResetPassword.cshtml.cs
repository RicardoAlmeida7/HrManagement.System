using HrManagement.Domain.ViewModels.Login;
using HrManagement.Security;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HrManagement.WebApplication.Pages.Login
{
    public class ResetPasswordModel : PageModel
    {
        [BindProperty]
        public PasswordResetPageModel Model { get; set; }

        private readonly UserManager<ApplicationUser> _userManager;

        public ResetPasswordModel(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public void OnGet(string userId, string token)
        {
            Model = new PasswordResetPageModel()
            {
                UserId = userId,
                Token = token
            };
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(Model.UserId);
                if (user is not null)
                {
                    var result = await _userManager.ResetPasswordAsync(user, Model.Token, Model.NewPassword);
                    if (result.Succeeded)
                    {
                        user.FirstAccess = false;
                        await _userManager.UpdateAsync(user);
                        TempData["Message"] = "Senha redefinida com sucesso.";
                    }
                }
                return LocalRedirect("/login");
            }
            return Page();
        }
    }
}
