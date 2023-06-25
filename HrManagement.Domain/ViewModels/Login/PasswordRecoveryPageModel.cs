using System.ComponentModel.DataAnnotations;

namespace HrManagement.Domain.ViewModels.Login
{
    public class PasswordRecoveryPageModel
    {
        [Required(ErrorMessage = "E-mail -e um campo obrigatório.")]
        [EmailAddress(ErrorMessage = "Insira um endereço de e-mail válido.")]
        public string Email { get; set; }
    }
}
