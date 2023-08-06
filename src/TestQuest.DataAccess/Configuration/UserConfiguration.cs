using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace TestQuest.DataAccess;

public sealed class UserConfiguration : IEntityTypeConfiguration<DbUser>
{
    public void Configure(EntityTypeBuilder<DbUser> builder)
    {
        builder
            .ToTable("users")
            .HasKey(u => u.Id);

        builder
            .Property(u => u.Id)
            .HasColumnName("id")
            .HasColumnType("VARCHAR")
            .IsRequired();

        builder
            .Property(u => u.Name)
            .HasColumnName("name")
            .HasColumnType("VARCHAR")
            .HasMaxLength(20)
            .IsRequired();

        builder
            .Property(u => u.Gender)
            .HasColumnName("gender")
            .HasColumnType("VARCHAR")
            .HasMaxLength(10)
            .IsRequired();

        builder
            .Property(u => u.Age)
            .HasColumnName("age")
            .HasColumnType("INT")
            .HasMaxLength(150)
            .IsRequired();

        builder
            .Property(u => u.RatingPoints)
            .HasColumnName("rating_points")
            .HasColumnType("INT");

        builder
            .Property(u => u.Achievements)
            .HasColumnName("achievements")
            .HasColumnType("VARCHAR[]");
    }
}