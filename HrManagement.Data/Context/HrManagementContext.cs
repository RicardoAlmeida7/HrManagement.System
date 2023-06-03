using HrManagement.Data.EntityConfig.Domain;
using HrManagement.Data.EntityConfig.Domain.Company;
using HrManagement.Data.EntityConfig.Domain.ThirdPartyServices;
using HrManagement.Security;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HrManagement.Data.Context
{
    public class HrManagementContext : IdentityDbContext<ApplicationUser>
    {
        public HrManagementContext(DbContextOptions<HrManagementContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new DepartmentEntityConfig());
            builder.ApplyConfiguration(new EmployeeEntityConfig());
            builder.ApplyConfiguration(new AddressEntityConfig());
            builder.ApplyConfiguration(new ContactEntityConfig());
            builder.ApplyConfiguration(new MedicalClinicEntityConfig());
            builder.ApplyConfiguration(new MedicalExamEntityConfig());

            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                base.OnConfiguring(optionsBuilder);
            }
        }
    }
}
