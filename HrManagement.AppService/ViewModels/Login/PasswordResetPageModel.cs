using System.ComponentModel.DataAnnotations;

namespace HrManagement.AppService.ViewModels.Login
{
    public class PasswordResetPageModel
    {
        [Required(ErrorMessage ="Campo senha é obrigatório.")]
        public string NewPassword { get; set; }

        [Required(ErrorMessage ="É necessário confirmar a senha.")]
        [Compare("NewPassword", ErrorMessage ="Senhas não conferem.")]
        public string ConfirmPassword { get; set; }
    }
}
