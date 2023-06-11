using HrManagement.Domain.Entities.ThirdPartyServices.Medical;

namespace HrManagement.Domain.Entities.Company
{
    public class EmployeeEntity
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? PositionInTheCompany { get; set; }
        public string? Comments { get; set; }
        public DateTime HiringDate { get; set; }
        public DateTime DateOfBirth { get; set; }

        public virtual ContactEntity Contact { get; set; }

        public virtual AddressEntity Address { get; set; }

        public int DepartmentId { get; set; }
        public virtual DepartmentEntity Department { get; set; }
    }
}
