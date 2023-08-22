using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace TestQuest.DataAccess;

public sealed class CommentAndTestScoreConfiguration : IEntityTypeConfiguration<DbCommentAndTestScore>
{
    public void Configure(EntityTypeBuilder<DbCommentAndTestScore> builder)
    {
        builder
            .ToTable("comment_and_test_score")
            .HasKey(cts => cts.Id);
        
        builder
            .Property(cts => cts.Id)
            .HasColumnName("id")
            .HasColumnType("VARCHAR")
            .IsRequired();

        builder
            .Property(cts => cts.UserId)
            .HasColumnName("user_id")
            .HasColumnType("VARCHAR")
            .IsRequired();

        builder
            .Property(cts => cts.CommentText)
            .HasColumnName("comment_text")
            .HasColumnType("VARCHAR")
            .HasMaxLength(5000);

        builder
            .Property(cts => cts.Score)
            .HasColumnName("score")
            .HasColumnType("SMALLINT");

        builder
            .Property(cts => cts.TestId)
            .HasColumnName("test_id")
            .HasColumnType("VARCHAR");
    }
}