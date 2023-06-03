using HrManagement.Domain.Entities.Company;
using HrManagement.Domain.Enums.ThirdPartyServices;

namespace HrManagement.Domain.Entities.ThirdPartyServices.Medical
{
    public class MedicalExamEntity
    {
        public int Id { get; set; } 

        public string Type { get; set; }

        public string Description { get; set; }

        public DateTime ExamDate { get; set; }

        public DateTime NextExamDate { get; set;}

        public bool RequiresNextExam { get; set;}

        public ExamStaus ExamStatus { get; set; }

        public MedicalClinicEntity Clinic { get; set; }

        public int EmployeeId { get; set; }
        public EmployeeEntity Employee { get; set; }
    }
}
