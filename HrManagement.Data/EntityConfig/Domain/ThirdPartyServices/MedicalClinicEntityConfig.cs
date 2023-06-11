using HrManagement.Domain.Entities;
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

            builder.HasOne(e => e.Contact)
               .WithOne(e => e.MedicalClinic)
               .HasForeignKey<ContactEntity>(e => e.MedicalClinicId)
               .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.Address)
                .WithOne(e => e.MedicalClinic)
                .HasForeignKey<AddressEntity>(e => e.MedicalClinicId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Navigation(x => x.Address)
              .UsePropertyAccessMode(PropertyAccessMode.Field)
              .AutoInclude();

            builder.Navigation(x => x.Contact)
              .UsePropertyAccessMode(PropertyAccessMode.Field)
              .AutoInclude();
        }
    }
}
