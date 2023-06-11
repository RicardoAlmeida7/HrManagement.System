using HrManagement.Domain.Enums.ThirdPartyServices;
using System.ComponentModel.DataAnnotations;

namespace HrManagement.AppService.ViewModels.ThirdPartyServices.Medical
{
    public class MedicaExamModel
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = "Tipo do exame é obrigatório.")]
        [MaxLength(50)]
        public string Type { get; set; }

        public string Description { get; set; }

        [Required(ErrorMessage = "Data do exame é obrigatório.")]
        public DateTime ExamDate { get; set; }

        public DateTime NextExamDate { get; set; }

        public bool RequiresNextExam { get; set; }

        [Required(ErrorMessage = "Status do exame é obrigatório.")]
        public ExamStatus ExamStatus { get; set; }

        public MedicalClinicModel Clinic { get; set; }
    }
}
