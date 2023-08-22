using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TestQuest.DataAccess;

public sealed class CategoryConfiguration : IEntityTypeConfiguration<DbCategory>
{
    public void Configure(EntityTypeBuilder<DbCategory> builder)
    {
        builder
            .ToTable("category")
            .HasKey(q => q.Id);

        builder
            .Property(q => q.Id)
            .HasColumnName("id")
            .HasColumnType("VARCHAR")
            .IsRequired();

        builder
            .Property(q => q.TestId)
            .HasColumnName("test_id")
            .HasColumnType("VARCHAR")
            .IsRequired();

        builder
            .Property(q => q.Category)
            .HasColumnName("category")
            .HasColumnType("VARCHAR")
            .IsRequired();
    }
}