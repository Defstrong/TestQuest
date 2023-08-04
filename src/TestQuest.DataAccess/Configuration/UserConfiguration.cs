using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace TestQuest.DataAccess;

public sealed class UserConfiguration : IEntityTypeConfiguration<DbUser>
{
    public void Configure(EntityTypeBuilder<DbUser> builder)
    {
        builder
            .ToTable("user")
            .HasKey(u => u.Id);

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
            .HasColumnType("TINYINT")
            .HasMaxLength(150)
            .IsRequired();
    }
}