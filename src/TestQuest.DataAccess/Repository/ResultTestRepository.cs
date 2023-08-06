using Microsoft.EntityFrameworkCore;

namespace TestQuest.DataAccess;

public sealed class ResultTestRepository : IResultTestRepository
{
    private readonly TestQuestDbContext _db;

    public ResultTestRepository(TestQuestDbContext db) => _db = db;

    public async Task<bool> CreateAsync(DbResultTest model, CancellationToken token = default)
    {
        await _db.ResultTests.AddAsync(model, token);
        int createResult = await _db.SaveChangesAsync(token);
        return createResult > 0;
    }

    public async Task<bool> DeleteAsync(string id, CancellationToken token = default)
    {
        DbQuestion resultTest = await _db.Questions.SingleAsync(q => q.Id == id, token);
        _db.Remove(resultTest);
        int deleteResult = await _db.SaveChangesAsync(token);
        return deleteResult > 0;
    }

    public async Task<DbResultTest> GetAsync(string id, CancellationToken token = default)
    {
        DbResultTest resultTest = await _db.ResultTests.SingleAsync(q => q.Id == id, token);
        return resultTest;
    }

    public async Task<IEnumerable<DbResultTest>> GetAsync(CancellationToken token = default)
    {
        IEnumerable<DbResultTest> resultTests = await _db.ResultTests.ToListAsync(token);
        return resultTests;
    }

    public async Task<bool> UpdateAsync(DbResultTest model, CancellationToken token = default)
    {
        _db.Entry(model).State = EntityState.Modified;
        int updateResult = await _db.SaveChangesAsync(token);
        return updateResult > 0;
    }
}