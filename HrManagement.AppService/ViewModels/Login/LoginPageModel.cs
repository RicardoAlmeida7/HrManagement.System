using System.ComponentModel.DataAnnotations;

namespace HrManagement.AppService.ViewModels.Login
{
    public class LoginPageModel
    {
        [Required(ErrorMessage = "Nome do usuário é obrigatório.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória.")]
        public string Password { get; set; }
    }
}
