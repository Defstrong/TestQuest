using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace TestQuest.DataAccess;

public sealed class QuestionAnswerConfiguration : IEntityTypeConfiguration<DbQuestionAnswer>
{
    public void Configure(EntityTypeBuilder<DbQuestionAnswer> builder)
    {
        builder
            .ToTable("question_answer")
            .HasKey(qa => qa.Id);
        
        builder
            .Property(qa => qa.Id)
            .HasColumnName("id")
            .HasColumnType("VARCHAR")
            .IsRequired();
        
        builder
            .Property(qa => qa.QuestionText)
            .HasColumnName("question_text")
            .HasColumnType("VARCHAR")
            .HasMaxLength(500);
        
        builder
            .Property(qa => qa.Answer)
            .HasColumnName("answer")
            .HasColumnType("VARCHAR")
            .IsRequired();
        
        builder
            .Property(qa => qa.Status)
            .HasColumnName("status")
            .HasColumnType("VARCHAR")
            .IsRequired();
    }
}