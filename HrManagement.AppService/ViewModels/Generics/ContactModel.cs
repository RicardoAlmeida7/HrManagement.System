using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HrManagement.AppService.ViewModels.Generics
{
    public class ContactModel
    {
        public int? Id { get; set; }

        [DisplayName("Nome")]
        [MaxLength(60)]
        public string? Name { get; set; }

        [DisplayName("Telefone")]
        [MaxLength(60)]
        public string? Phone { get; set; }

        [DisplayName("E-mail")]
        [Required(ErrorMessage = "E-mail corporativo um campo obrigatório.")]
        [EmailAddress(ErrorMessage = "Insira um endereço de e-mail válido.")]
        [MaxLength(60)]
        public string CorporateEmail { get; set; }

        [DisplayName("E-mail pessoal")]
        [EmailAddress(ErrorMessage = "Insira um endereço de e-mail válido.")]
        [MaxLength(60)]
        public string? PersonalEmail { get; set; }
    }
}
