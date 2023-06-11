using HrManagement.Domain.Entities.Company;
using HrManagement.Domain.Entities.ThirdPartyServices.Medical;

namespace HrManagement.Domain.Entities
{
    public class ContactEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CorporateEmail { get; set; }
        public string PersonalEmail { get; set; }
        public string Phone { get; set; }

        public int? MedicalClinicId { get; set; }
        public MedicalClinicEntity? MedicalClinic { get; set; }

        public int? EmployeeId { get; set; }
        public EmployeeEntity? Employee { get; set; }
    }
}
