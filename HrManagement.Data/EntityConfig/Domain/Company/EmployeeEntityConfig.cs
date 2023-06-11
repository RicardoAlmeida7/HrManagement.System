using HrManagement.Domain.Entities;
using HrManagement.Domain.Entities.Company;
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

            builder.Property(e => e.DepartmentId)
             .HasColumnName("department_id");

            builder.HasOne(e => e.Department)
                .WithMany(e => e.Employees)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(e => e.DepartmentId);

            builder.HasOne(e => e.Contact)
                .WithOne(e => e.Employee)
                .HasForeignKey<ContactEntity>(e => e.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(e => e.Address)
                .WithOne(e => e.Employee)
                .HasForeignKey<AddressEntity>(e => e.EmployeeId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Navigation(x => x.Address)
              .UsePropertyAccessMode(PropertyAccessMode.Field)
              .AutoInclude();

            builder.Navigation(x => x.Contact)
              .UsePropertyAccessMode(PropertyAccessMode.Field)
              .AutoInclude();

            builder.Navigation(x => x.Department)
              .UsePropertyAccessMode(PropertyAccessMode.Field)
              .AutoInclude();
        }
    }
}
