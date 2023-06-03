using HrManagement.Domain.Entities.ThirdPartyServices.Medical;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HrManagement.Data.EntityConfig.Domain.ThirdPartyServices
{
    public class MedicalExamEntityConfig : IEntityTypeConfiguration<MedicalExamEntity>
    {
        public void Configure(EntityTypeBuilder<MedicalExamEntity> builder)
        {
            builder.ToTable("medical_exams");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("id")
                .ValueGeneratedOnAdd();

            builder.Property(e => e.Type)
                .HasColumnName("type")
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.ExamDate)
                .HasColumnName("exam_date")
                .IsRequired();

            builder.Property(e => e.ExamStatus)
               .HasColumnName("status")
               .IsRequired();

            builder.Property(e => e.NextExamDate)
                .HasColumnName("next_exam_date");

            builder.Property(e => e.RequiresNextExam)
                .HasColumnName("requires_next_exam")
                .IsRequired();

            builder.Property(e => e.Description)
               .HasColumnName("descripton")
               .HasMaxLength(100);

            builder.HasOne(e => e.Employee)
                .WithOne(e => e.MedicalExam)
                .HasForeignKey<MedicalExamEntity>(e => e.EmployeeId)
                .IsRequired();
        }
    }
}
