using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace TestQuest.DataAccess;

public sealed class TestConfiguration : IEntityTypeConfiguration<DbTest>
{
    public void Configure(EntityTypeBuilder<DbTest> builder)
    {
        builder
            .ToTable("test")
            .HasKey(t => t.Id);
        
        builder
            .Property(t => t.Difficulty)
            .HasColumnName("difficulty")
            .HasColumnType("VARCHAR")
            .HasMaxLength(30)
            .IsRequired();

        builder
            .Property(t => t.TimeLimit)
            .HasColumnName("time_limit")
            .HasColumnType("TINYINT")
            .HasMaxLength(255)
            .IsRequired();

        builder
            .Property(t => t.TotalQuestions)
            .HasColumnName("total_questions")
            .HasColumnType("TINYINT")
            .HasMaxLength(255)
            .IsRequired();

        builder
            .Property(t => t.TotalQuestions)
            .HasColumnName("total_questions")
            .HasColumnType("TINYINT")
            .HasMaxLength(255)
            .IsRequired();

        builder
            .Property(t => t.CreatedAt)
            .HasColumnName("created_at")
            .HasColumnType("DATETIME")
            .IsRequired();
    }
}