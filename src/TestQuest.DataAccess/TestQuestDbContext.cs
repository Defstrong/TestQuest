using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace TestQuest.DataAccess;

public sealed class TestQuestDbContext : DbContext
{
    public DbSet<DbCloseQuestion> CloseQuestion => Set<DbCloseQuestion>();
    public DbSet<DbOpenQuestion> OpenQuestions => Set<DbOpenQuestion>();
    public DbSet<DbResultTest> ResultTests => Set<DbResultTest>();
    public DbSet<DbTest> Tests => Set<DbTest>();
    public DbSet<DbUser> Users => Set<DbUser>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}