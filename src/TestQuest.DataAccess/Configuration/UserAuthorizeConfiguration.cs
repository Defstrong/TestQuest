using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace TestQuest.DataAccess;

public sealed class UserAuthorizeConfiguration : IEntityTypeConfiguration<DbUserAuthorize>
{
    public void Configure(EntityTypeBuilder<DbUserAuthorize> builder)
    {
        builder
            .ToTable("users_authorize")
            .HasKey(u => u.Id);

        builder
            .Property(u => u.Id)
            .HasColumnName("id")
            .HasColumnType("VARCHAR")
            .IsRequired();

        builder
            .Property(u => u.Email)
            .HasColumnName("email")
            .HasColumnType("VARCHAR")
            .HasMaxLength(75)
            .IsRequired();

        builder
            .Property(u => u.Password)
            .HasColumnName("password")
            .HasColumnType("VARCHAR")
            .HasMaxLength(200)
            .IsRequired();
    }
}