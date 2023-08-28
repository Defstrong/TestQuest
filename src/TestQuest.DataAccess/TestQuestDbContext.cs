using System.Reflection;
using Microsoft.EntityFrameworkCore;
namespace TestQuest.DataAccess;

public sealed class TestQuestDbContext : DbContext
{
    public DbSet<DbQuestion> Questions => Set<DbQuestion>();
    public DbSet<DbResultTest> ResultTests => Set<DbResultTest>();
    public DbSet<DbTest> Tests => Set<DbTest>();
    public DbSet<DbUser> Users => Set<DbUser>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string connectionStirng = "Server=localhost;Port=5432;User Id=postgres;Password=1111;Database=postgres";
        optionsBuilder.EnableSensitiveDataLogging().UseLazyLoadingProxies().UseNpgsql(connectionStirng);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}