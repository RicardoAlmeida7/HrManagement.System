using HrManagement.AppService.ViewModels.Generics;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HrManagement.AppService.ViewModels.Company
{
    public class EmployeeModel
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = "Nome do funcionário é obrigatório.")]
        [MaxLength(100)]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Cargo (função) é obrigatório.")]
        [MaxLength(100)]
        public string PositionInTheCompany { get; set; }

        [DisplayName("Comentários")]
        [MaxLength(500, ErrorMessage ="Tamanho máximo de {0}.")]
        public string? Comments { get; set; }

        [Display(Name = "Data de contratação")]
        [Required(ErrorMessage = "Data de contratação é obrigatório.")]
        public DateTime HiringDate { get; set; }

        [Display(Name = "Data de nascimento")]
        [Required(ErrorMessage = "Data de nascimento é obrigatório.")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Dados de contato são obrigatórios.")]
        public ContactModel? Contact { get; set; }

        [Required(ErrorMessage = "Endereço é obrigatório.")]
        public AddressModel? Address { get; set; }

        [Required(ErrorMessage = "Departamento é obrigatório.")]
        public int DepartmentId { get; set; }

        public DepartmentModel? Department { get; set; }
    }
}
