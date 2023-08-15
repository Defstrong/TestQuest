using Microsoft.EntityFrameworkCore;

namespace TestQuest.DataAccess;

public sealed class TestRepository : BaseRepository<DbTest>, ITestRepository
{
    public TestRepository(TestQuestDbContext db) : base(db) { }
}