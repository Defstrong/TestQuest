using Microsoft.EntityFrameworkCore;

namespace TestQuest.DataAccess;

public sealed class UserAuthorizeRepository : IUserAuthorizeRepository
{
    private readonly TestQuestDbContext _db;

    public UserAuthorizeRepository(TestQuestDbContext db) => _db = db;

    public async Task<bool> CreateAsync(DbUserAuthorize model, CancellationToken token = default)
    {
        await _db.UsersAuthorizes.AddAsync(model, token);
        int createResult = await _db.SaveChangesAsync(token);
        return createResult > 0;
    }

    public async Task<bool> DeleteAsync(string id, CancellationToken token = default)
    {
        DbUserAuthorize userAuthorize = await _db.UsersAuthorizes.SingleAsync(q => q.Id == id, token);
        _db.Remove(userAuthorize);
        int deleteResult = await _db.SaveChangesAsync(token);
        return deleteResult > 0;
    }

    public async Task<DbUserAuthorize> GetAsync(string id, CancellationToken token = default)
    {
        DbUserAuthorize userAuthorize = await _db.UsersAuthorizes.SingleAsync(q => q.Id == id, token);
        return userAuthorize;
    }

    public async Task<IEnumerable<DbUserAuthorize>> GetAsync(CancellationToken token = default)
    {
        IEnumerable<DbUserAuthorize> users = await _db.UsersAuthorizes.ToListAsync(token);
        return users;
    }

    public async Task<bool> UpdateAsync(DbUserAuthorize model, CancellationToken token = default)
    {
        _db.Entry(model).State = EntityState.Modified;
        int updateResult = await _db.SaveChangesAsync(token);
        return updateResult > 0;
    }
}