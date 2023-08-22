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
            .Property(rt => rt.Id)
            .HasColumnName("id")
            .HasColumnType("VARCHAR")
            .IsRequired();

        builder
            .Property(rt => rt.CompletedAt)
            .HasColumnName("completed_at")
            .HasColumnType("DATE")
            .IsRequired();

        builder
            .Property(rt => rt.CorrectAnswers)
            .HasColumnName("correct_answers")
            .HasColumnType("INT");

        builder
            .Property(rt => rt.ResultPoints)
            .HasColumnName("result")
            .HasColumnType("VARCHAR")
            .HasMaxLength(500)
            .IsRequired();

        builder
            .Property(rt => rt.UserId)
            .HasColumnName("user_id")
            .HasColumnType("VARCHAR")
            .IsRequired();

        builder
            .Property(rt => rt.TestId)
            .HasColumnName("test_id")
            .HasColumnType("VARCHAR")
            .IsRequired();
        
        builder
            .HasMany(rt => rt.QuestionAnswers)
            .WithOne(rt => rt.ResultTest)
            .HasConstraintName("result_test_id")
            .HasForeignKey(rt => rt.ResultTestId)
            .IsRequired();
    }
}