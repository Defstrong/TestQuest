namespace TestQuest.DataAccess;

public interface IBaseRepository<T>
    where T : BaseDbEntity
{
    Task<bool> CreateAsync(T model, CancellationToken token = default);
    Task<T> GetAsync(string id, CancellationToken token = default);
    Task<IEnumerable<T>> GetAsync(CancellationToken token = default);
    Task<bool> DeleteAsync(string id, CancellationToken token = default);
    Task<bool> UpdateAsync(T model, CancellationToken token = default);
}