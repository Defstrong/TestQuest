using Microsoft.EntityFrameworkCore;

namespace TestQuest.DataAccess;

public sealed class UserRepository : IUserRepository
{
    private readonly TestQuestDbContext _db;

    public UserRepository(TestQuestDbContext db) => _db = db;

    public async Task<bool> CreateAsync(DbUser model, CancellationToken token = default)
    {
        await _db.Users.AddAsync(model, token);
        int createResult = await _db.SaveChangesAsync(token);
        return createResult > 0;
    }

    public async Task<bool> DeleteAsync(string id, CancellationToken token = default)
    {
        DbUser user = await _db.Users.SingleAsync(q => q.Id == id, token);
        _db.Remove(user);
        int deleteResult= await _db.SaveChangesAsync(token);
        return deleteResult > 0;
    }

    public async Task<DbUser> GetAsync(string id, CancellationToken token = default)
    {
        DbUser user = await _db.Users.SingleAsync(q => q.Id == id, token);
        return user;
    }

    public async Task<IEnumerable<DbUser>> GetAsync(CancellationToken token = default)
    {
        IEnumerable<DbUser> users = await _db.Users.ToListAsync(token);
        return users;
    }

    public async Task<bool> UpdateAsync(DbUser model, CancellationToken token = default)
    {
        _db.Entry(model).State = EntityState.Modified;
        int updateResult = await _db.SaveChangesAsync(token);
        return updateResult > 0;
    }
}