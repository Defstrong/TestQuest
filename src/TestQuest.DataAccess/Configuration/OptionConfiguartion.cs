using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TestQuest.DataAccess;

public sealed class OptionConfiguration : IEntityTypeConfiguration<DbOption>
{
    public void Configure(EntityTypeBuilder<DbOption> builder)
    {
        builder
            .ToTable("options")
            .HasKey(q => q.Id);

        builder
            .Property(q => q.Id)
            .HasColumnName("id")
            .HasColumnType("VARCHAR")
            .IsRequired();

        builder
            .Property(q => q.Option)
            .HasColumnName("option")
            .HasColumnType("VARCHAR")
            .IsRequired();

    }
}