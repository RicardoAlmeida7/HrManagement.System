namespace HrManagement.Domain.Entities.ThirdPartyServices.Medical
{
    public class MedicalClinicEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int AddressId { get; set; }
        public AddressEntity Address { get; set; }

        public int ContactId { get; set; }
        public ContactEntity Contact { get; set; }
    }
}
