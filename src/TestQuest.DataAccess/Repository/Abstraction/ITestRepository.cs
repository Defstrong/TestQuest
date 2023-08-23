namespace TestQuest.DataAccess;

public interface ITestRepository : IBaseRepository<DbTest> 
{ 
    Task<bool> SaveResultAsync(DbResultTest dbResultTest, CancellationToken token = default);
    Task<IEnumerable<DbTest>> GetWithoutUserTestAsync(string userId, CancellationToken token = default);
    Task<IEnumerable<DbTest>> GetAllUserTestAsync(string userId, CancellationToken token = default);
    Task<List<DbTest>> SearchTestAsync(string str, string userId, CancellationToken token = default);
}