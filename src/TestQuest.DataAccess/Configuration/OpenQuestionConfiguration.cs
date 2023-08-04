using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TestQuest.DataAccess;

public sealed class OpenQuestionConfiguration : IEntityTypeConfiguration<DbOpenQuestion>
{
    public void Configure(EntityTypeBuilder<DbOpenQuestion> builder)
    {
        builder
            .ToTable("open_question")
            .HasKey(k => k.Id);

        builder
            .Property(q => q.Answer)
            .HasColumnName("answer")
            .HasColumnType("VARCHAR")
            .HasMaxLength(100)
            .IsRequired();

        builder
            .Property(q => q.Question)
            .HasColumnName("question")
            .HasColumnType("VARCHAR")
            .HasMaxLength(500)
            .IsRequired();
    }
}