using HrManagement.AppService.ViewModels.Login;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HrManagement.WebApplication.Pages.Login
{
    public class RecoverPasswordModel : PageModel
    {
        [BindProperty]
        public new PasswordRecoveryPageModel Model { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                //email sending service logic
                TempData["Message"] = "E-mail de redefinição de senha enviado com sucesso. Verifique sua caixa de entrada ou spam.";
                return LocalRedirect("/login");
            }
            return Page();
        }
    }
}
