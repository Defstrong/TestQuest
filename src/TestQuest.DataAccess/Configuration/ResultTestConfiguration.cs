using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace TestQuest.DataAccess;

public sealed class ResultTestConfiguration : IEntityTypeConfiguration<DbResultTest>
{
    public void Configure(EntityTypeBuilder<DbResultTest> builder)
    {
        builder
            .ToTable("result_test")
            .HasKey(rt => rt.Id);

        builder
            .Property(rt => rt.CompletedAt)
            .HasColumnName("completed_at")
            .HasColumnType("DATETIME")
            .IsRequired();

        builder
            .Property(rt => rt.CorrectAnswers)
            .HasColumnName("correct_answers")
            .HasColumnType("TINYINT")
            .HasMaxLength(255);
        
        builder
            .Property(rt => rt.Result)
            .HasColumnName("result")
            .HasColumnType("VARCHAR")
            .HasMaxLength(500)
            .IsRequired();
        
        builder
            .Property(rt => rt.UserId)
            .HasColumnName("id_user")
            .IsRequired();
    }
}