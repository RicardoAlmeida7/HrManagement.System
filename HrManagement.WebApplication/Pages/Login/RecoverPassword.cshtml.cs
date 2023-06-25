using HrManagement.Domain.Services.Email;
using HrManagement.Domain.ViewModels.Login;
using HrManagement.EmailService.Templates;
using HrManagement.Security;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HrManagement.WebApplication.Pages.Login
{
    public class RecoverPasswordModel : PageModel
    {
        private readonly IEmailService _emailService;
        private readonly UserManager<ApplicationUser> _userManager;

        public RecoverPasswordModel(IEmailService emailService, UserManager<ApplicationUser> userManager)
        {
            _emailService = emailService;
            _userManager = userManager;
        }

        [BindProperty]
        public new PasswordRecoveryPageModel Model { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var user = await _userManager.FindByEmailAsync(Model.Email);
                    if (user is not null)
                    {
                        var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                        var url = Url.Page("/login/resetpassword", null, new { userId = user.Id, token }, protocol: Request.Scheme);
                        _emailService.SendEmail(Model.Email, Subject.PASSWORD_RECOVERY, RecoverPasswordTemplate.Build(url));
                    }
                    TempData["Message"] = "E-mail de redefinição de senha enviado com sucesso. Verifique sua caixa de entrada ou spam.";
                    return LocalRedirect("/login");
                }
                catch (Exception)
                {
                    ModelState.AddModelError("", "Falha ao enviar e-mail de recuperação de senha. Entre em contato com o suporte.");
                }
            }
            return Page();
        }
    }
}
