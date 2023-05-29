using HrManagement.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HrManagement.Data.EntityConfig.Security
{
    internal class ApplicationUserEntityConfig : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.Property(x => x.FullName)
                .HasColumnName("FullName")
                .HasColumnType("varchar(45)");

            builder.Property(x => x.TempPasswordHash)
                .HasColumnName("TempPasswordHash")
                .HasColumnType("varchar(45)");
        }
    }
}
