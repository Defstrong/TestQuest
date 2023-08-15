using TestQuest.DataAccess;
namespace TestQuest.BusinessLogic;

public interface IBaseService<T>
    where T : BaseDto
{
    Task<bool> CreateAsync(T entity, CancellationToken token = default);
    Task<T> GetAsync(string id, CancellationToken token = default);
    Task<IEnumerable<T>> GetAsync(CancellationToken token = default);
    Task<bool> DeleteAsync(string id, CancellationToken token = default);
    Task<bool> UpdateAsync(T entity, CancellationToken token = default);
}