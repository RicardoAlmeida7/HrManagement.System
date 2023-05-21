using HrManagement.AppService.ViewModels.Login;
using HrManagement.EmailService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HrManagement.WebApplication.Pages.Login
{
    public class RecoverPasswordModel : PageModel
    {
        private readonly IEmailService _emailService;

        public RecoverPasswordModel(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [BindProperty]
        public new PasswordRecoveryPageModel Model { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _emailService.SendEmail(Model.Email, "Teste", "<h1>Teste</h1>");
                    TempData["Message"] = "E-mail de redefini��o de senha enviado com sucesso. Verifique sua caixa de entrada ou spam.";
                    return LocalRedirect("/login");
                }
                catch (Exception)
                {
                    ModelState.AddModelError("", "Falha ao enviar e-mail de recupera��o de senha. Entre em contato com o suporte.");
                }
            }
            return Page();
        }
    }
}
