using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace HrManagement.AppService.ViewModels.UsersViewModel
{
    public class UserPageModel
    {
        public string? Id { get; set; }

        [Required(ErrorMessage = "Nome de acesso é obrigatório.")]
        [Display(Name = "Login")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Nome completo é obrigatório.")]
        [Display(Name = "Nome")]
        [MaxLength(45, ErrorMessage = "O nome completo deve conter no máximo 45 caracteres.")]
        public string FullName { get; set; }

        public string? Password { get; set; }

        public IList<string>? Access { get; set; }

        [Display(Name = "E-mail")]
        [EmailAddress(ErrorMessage = "Informe um e-mail válido.")]
        [Required(ErrorMessage = "E-mail é campo necessário.")]
        public string Email { get; set; }

        public UserPageModel() { }
        
        public UserPageModel(RoleManager<IdentityRole> rolesManager)
        {
            Access = rolesManager.Roles.Select(n => n.Name).ToList();
        }
    }
}
