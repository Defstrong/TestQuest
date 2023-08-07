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
            .Property(t => t.Id)
            .HasColumnName("id")
            .HasColumnType("VARCHAR")
            .IsRequired();

        builder
            .Property(t => t.AuthorId)
            .HasColumnName("author_id")
            .HasColumnType("VARCHAR")
            .IsRequired();

        builder
            .Property(t => t.Name)
            .HasColumnName("name")
            .HasColumnType("VARCHAR")
            .HasMaxLength(50)
            .IsRequired();

        builder
            .Property(t => t.Difficulty)
            .HasColumnName("difficulty")
            .HasColumnType("VARCHAR")
            .HasMaxLength(30)
            .IsRequired();

        builder
            .Property(t => t.TimeLimit)
            .HasColumnName("time_limit")
            .HasColumnType("INT")
            .IsRequired();

        builder
            .Property(t => t.TotalQuestions)
            .HasColumnName("total_questions")
            .HasColumnType("INT")
            .IsRequired();

        builder
            .Property(t => t.TotalQuestions)
            .HasColumnName("total_questions")
            .HasColumnType("INT")
            .IsRequired();

        builder
            .Property(t => t.CreatedAt)
            .HasColumnName("created_at")
            .HasColumnType("DATE")
            .IsRequired();

        builder
            .Property(t => t.Status)
            .HasColumnName("status")
            .HasColumnType("VARCHAR")
            .HasMaxLength(20)
            .IsRequired();
        
        builder
            .HasMany(t => t.Category)
            .WithOne(t => t.Test)
            .HasConstraintName("category")
            .HasForeignKey(t => t.Id)
            .IsRequired();
    }
}