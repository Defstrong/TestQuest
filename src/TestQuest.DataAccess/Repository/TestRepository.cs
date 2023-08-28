using Microsoft.EntityFrameworkCore;

namespace TestQuest.DataAccess;

public sealed class TestRepository : BaseRepository<DbTest>, ITestRepository
{
    private readonly TestQuestDbContext _db;
    public TestRepository(TestQuestDbContext db) : base(db)
        => _db = db;

    public async Task<bool> SaveResultAsync(DbResultTest dbResultTest, CancellationToken token = default)
    {
        await _db.ResultTests.AddAsync(dbResultTest, token);
        int saveResult = await _db.SaveChangesAsync(token);
        return saveResult > 0;
    }
    public async Task<IEnumerable<DbTest>> GetWithoutUserTestAsync(string userId, CancellationToken token = default)
    {
        var testsWithoutUserTest = await _db.Tests.Where(t => t.AuthorId != userId).ToListAsync(token);

        return testsWithoutUserTest;
    }

    public async Task<IEnumerable<DbTest>> GetAllUserTestAsync(string userId, CancellationToken token = default)
    {
        var allUserTests = await _db.Tests.Where(ut => ut.AuthorId == userId).ToListAsync();

        return allUserTests; 
    }

    public async Task<List<DbTest>> SearchTestAsync(string str, string userId, CancellationToken token = default)
    {
        
        var tests = await _db.Tests.Where(t => EF.Functions.Like(t.Name, "%"+str+"%") && t.AuthorId != userId).ToListAsync();
        return tests ?? new();
    }
}