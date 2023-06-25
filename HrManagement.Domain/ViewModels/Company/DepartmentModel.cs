using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HrManagement.Domain.ViewModels.Company
{
    public class DepartmentModel
    {
        public int? Id { get; set; }

        [DisplayName("Nome do departamento")]
        [Required(ErrorMessage = "Nome do departamento é obrigatório.")]
        [MaxLength(50)]
        public string? Name { get; set; }
    }
}
