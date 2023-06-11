using HrManagement.Domain.Entities;
using HrManagement.Domain.Entities.ThirdPartyServices.Medical;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HrManagement.Data.EntityConfig.Domain
{
    public class ContactEntityConfig : IEntityTypeConfiguration<ContactEntity>
    {
        public void Configure(EntityTypeBuilder<ContactEntity> builder)
        {
            builder.ToTable("contacts");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.Name)
                .HasColumnName("name")
                .IsRequired(false)
                .HasMaxLength(60);

            builder.Property(e => e.CorporateEmail)
                .HasColumnName("corporate_email")
                .IsRequired()
                .HasMaxLength(60);

            builder.Property(e => e.Phone)
               .HasColumnName("phone")
               .IsRequired(false)
               .HasMaxLength(20);

            builder.Property(e => e.PersonalEmail)
                .HasColumnName("personal_email")
                .IsRequired(false)
                .HasMaxLength(60);

            builder.Property(e => e.MedicalClinicId)
                .HasColumnName("medical_clinic_id");

            builder.HasOne(e => e.MedicalClinic)
               .WithOne(e => e.Contact)
               .HasForeignKey<MedicalClinicEntity>(e => e.Id)
               .HasPrincipalKey<ContactEntity>(e => e.Id);
        }
    }
}
