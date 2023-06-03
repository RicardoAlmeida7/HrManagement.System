using HrManagement.Domain.Entities.ThirdPartyServices.Medical;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HrManagement.Data.EntityConfig.Domain.ThirdPartyServices
{
    public class MedicalClinicEntityConfig : IEntityTypeConfiguration<MedicalClinicEntity>
    {
        public void Configure(EntityTypeBuilder<MedicalClinicEntity> builder)
        {
            builder.ToTable("medical_clinics");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.Name)
                .HasColumnName("name")
                .IsRequired()
                .HasMaxLength(50);

            builder.HasOne(e => e.Address)
                .WithOne()
                .HasForeignKey<MedicalClinicEntity>(e => e.AddressId)
                .IsRequired();

            builder.HasOne(e => e.Contact)
                .WithOne()
                .HasForeignKey<MedicalClinicEntity>(e => e.ContactId)
                .IsRequired();
        }
    }
}
