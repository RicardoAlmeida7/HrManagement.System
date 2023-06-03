using HrManagement.Domain.Entities;
using HrManagement.Domain.Entities.Company;
using HrManagement.Domain.Entities.ThirdPartyServices.Medical;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HrManagement.Data.EntityConfig.Domain.Company
{
    public class EmployeeEntityConfig : IEntityTypeConfiguration<EmployeeEntity>
    {
        public void Configure(EntityTypeBuilder<EmployeeEntity> builder)
        {
            builder.ToTable("employees");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.Name)
                .HasColumnName("name")
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.PositionInTheCompany)
                .HasColumnName("position_in_the_company")
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.Comments)
                .HasColumnName("comments")
                .HasMaxLength(500);

            builder.Property(e => e.HiringDate)
                .HasColumnName("hiring_date")
                .IsRequired();

            builder.Property(e => e.DateOfBirth)
                .HasColumnName("date_of_birth")
                .IsRequired();

            builder.HasOne(e => e.MedicalExam)
                .WithOne()
                .HasForeignKey<MedicalExamEntity>(me => me.EmployeeId)
                .IsRequired();

            builder.HasOne(e => e.Contact)
                .WithOne()
                .HasForeignKey<ContactEntity>(c => c.EmployeeId)
                .IsRequired();

            builder.HasOne(e => e.Address)
                .WithOne()
                .HasForeignKey<AddressEntity>(a => a.EmployeeId)
                .IsRequired();

            builder.HasOne(e => e.Department)
                .WithMany()
                .HasForeignKey(e => e.DepartmentId)
                .IsRequired();
        }
    }
}
