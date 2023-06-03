using HrManagement.Domain.Entities.Company;
using HrManagement.Domain.Entities.ThirdPartyServices.Medical;

namespace HrManagement.Domain.Entities
{
    public class AddressEntity
    {
        public int Id { get; set; } 
        public string Street { get; set; }
        public string Neighborhood { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }

        public int MedicalClinicId { get; set; }
        public MedicalClinicEntity MedicalClinic { get; set; }

        public int EmployeeId { get; set; }
        public EmployeeEntity Employee { get; set; }
    }
}
