using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HrManagement.Domain.ViewModels.Generics
{
    public class AddressModel
    {
        public int? Id { get; set; }

        [DisplayName("Rua e número")]
        [Required(ErrorMessage = "Nome da rua é obrigatório.")]
        [MaxLength(100)]
        public string Street { get; set; }

        [DisplayName("Bairro")]
        [Required(ErrorMessage = "Bairro é obrigatório.")]
        [MaxLength(50)]
        public string Neighborhood { get; set; }

        [DisplayName("Cidade")]
        [Required(ErrorMessage = "Cidade é obrigatório.")]
        [MaxLength(50)]
        public string City { get; set; }

        [DisplayName("Estado")]
        [Required(ErrorMessage = "Estado é obrigatório.")]
        [MaxLength(50)]
        public string State { get; set; }

        [DisplayName("CEP")]
        [Required(ErrorMessage = "CEP é obrigatório.")]
        [MaxLength(9)]
        public string ZipCode { get; set; }
    }
}
