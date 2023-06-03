﻿using HrManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HrManagement.Data.EntityConfig.Domain
{
    public class AddressEntityConfig : IEntityTypeConfiguration<AddressEntity>
    {
        public void Configure(EntityTypeBuilder<AddressEntity> builder)
        {
            builder.ToTable("addresses");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.Street)
                .HasColumnName("street")
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(e => e.Neighborhood)
                .HasColumnName("neighborhood")
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.City)
                .HasColumnName("city")
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.State)
                .HasColumnName("state")
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.ZipCode)
                .HasColumnName("zip_code")
                .IsRequired()
                .HasMaxLength(9);

            builder.HasOne(e => e.MedicalClinic)
                .WithOne(e => e.Address)
                .HasForeignKey<AddressEntity>(e => e.MedicalClinicId)
                .IsRequired();

            builder.HasOne(e => e.Employee)
                .WithOne(e => e.Address)
                .HasForeignKey<AddressEntity>(e => e.EmployeeId)
                .IsRequired();
        }
    }
}
