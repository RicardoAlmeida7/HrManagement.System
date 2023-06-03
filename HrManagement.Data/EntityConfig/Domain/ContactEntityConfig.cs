using HrManagement.Domain.Entities;
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
                .HasMaxLength(100);

            builder.Property(e => e.CorporateEmail)
                .HasColumnName("corporate_email")
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.PersonalEmail)
                .HasColumnName("personal_email")
                .HasMaxLength(100);

            builder.HasOne(e => e.Employee)
                .WithOne(e => e.Contact)
                .HasForeignKey<ContactEntity>(e => e.EmployeeId)
                .IsRequired();

            builder.HasOne(e => e.MedicalClinic)
                .WithOne(e => e.Contact)
                .HasForeignKey<ContactEntity>(e => e.MedicalClinicId)
                .IsRequired();
        }
    }
}
