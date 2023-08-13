using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TestQuest.DataAccess;

public sealed class QuestionConfiguration : IEntityTypeConfiguration<DbQuestion>
{
    public void Configure(EntityTypeBuilder<DbQuestion> builder)
    {
        builder
            .ToTable("question")
            .HasKey(q => q.Id);

        builder
            .Property(q => q.Id)
            .HasColumnName("id")
            .HasColumnType("VARCHAR")
            .IsRequired();

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

        builder
            .Property(q => q.Options)
            .HasColumnName("options")
            .HasColumnType("VARCHAR[]");
        
    }
}