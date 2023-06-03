using HrManagement.Domain.Entities.ThirdPartyServices.Medical;

namespace HrManagement.Domain.Entities.Company
{
    public class EmployeeEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PositionInTheCompany { get; set; }
        public string Comments { get; set; }
        public DateTime HiringDate { get; set; }
        public DateTime DateOfBirth { get; set; }

        public int MedicalExamId { get; set; }
        public MedicalExamEntity MedicalExam { get; set; }

        public int ContactId { get; set; }
        public ContactEntity Contact { get; set; }

        public int AddressId { get; set; }
        public AddressEntity Address { get; set; }

        public int DepartmentId { get; set; }
        public DepartmentEntity Department { get; set; }
    }
}
