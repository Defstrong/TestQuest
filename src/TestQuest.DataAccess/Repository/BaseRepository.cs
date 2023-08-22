using Microsoft.EntityFrameworkCore;

namespace TestQuest.DataAccess;

public class BaseRepository<T> : IBaseRepository<T>
    where T : BaseDbEntity
{
    private readonly TestQuestDbContext _db;

    public BaseRepository(TestQuestDbContext db) => _db = db;

    public async Task<bool> CreateAsync(T entity, CancellationToken token = default)
    {
        await _db.Set<T>().AddAsync(entity, token);
        int createResult = await _db.SaveChangesAsync(token);
        return createResult > 0;
    }

    public async Task<bool> DeleteAsync(string id, CancellationToken token = default)
    {
        var entity = await _db.Set<T>().FindAsync(id);

        if(entity is null)
            return false;

        _db.Set<T>().Remove(entity);
        int deleteResult = await _db.SaveChangesAsync(token);
        return deleteResult > 0;
    }

    public ValueTask<T?> GetAsync(string id, CancellationToken token = default)
    {
        var entity = _db.Set<T>().FindAsync(id);
        return entity;
    }

    public Task<List<T>> GetAsync(CancellationToken token = default)
    {
        var entities = _db.Set<T>().ToListAsync(token);
        return entities;
    }

    public async Task<bool> UpdateAsync(T entity, CancellationToken token = default)
    {
        await DeleteAsync(entity.Id, token);
        await CreateAsync(entity, token);
        int updateResult = await _db.SaveChangesAsync(token);
        return updateResult > 0;
    }
}