using Microsoft.EntityFrameworkCore;

namespace TestQuest.DataAccess;

public sealed class TestRepository : ITestRepository
{
    private readonly TestQuestDbContext _db;

    public TestRepository(TestQuestDbContext db) => _db = db;

    public async Task<bool> CreateAsync(DbTest model, CancellationToken token = default)
    {
        await _db.Tests.AddAsync(model, token);
        int createResult = await _db.SaveChangesAsync(token);
        return createResult > 0;
    }

    public async Task<bool> DeleteAsync(string id, CancellationToken token = default)
    {
        DbTest test = await _db.Tests.SingleAsync(q => q.Id == id, token);
        _db.Remove(test);
        int deleteResult= await _db.SaveChangesAsync(token);
        return deleteResult > 0;
    }

    public async Task<DbTest> GetAsync(string id, CancellationToken token = default)
    {
        DbTest test = await _db.Tests.SingleAsync(q => q.Id == id, token);
        return test;
    }

    public async Task<IEnumerable<DbTest>> GetAsync(CancellationToken token = default)
    {
        IEnumerable<DbTest> tests = await _db.Tests.ToListAsync(token);
        return tests;
    }

    public async Task<bool> UpdateAsync(DbTest model, CancellationToken token = default)
    {
        _db.Entry(model).State = EntityState.Modified;
        int updateResult = await _db.SaveChangesAsync(token);
        return updateResult > 0;
    }
}