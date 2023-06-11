using HrManagement.AppService.ViewModels.Generics;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace HrManagement.AppService.ViewModels.ThirdPartyServices.Medical
{
    public class MedicalClinicModel
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = "Nome da cliníca é obrigatório.")]
        [DisplayName("Clínica")]
        [MaxLength(50)]
        public string? Name { get; set; }

        public AddressModel Address { get; set; }

        public ContactModel Contact { get; set; }
    }
}
