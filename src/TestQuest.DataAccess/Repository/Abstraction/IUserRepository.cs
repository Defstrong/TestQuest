namespace TestQuest.DataAccess;

public interface IUserRepository : IBaseRepository<DbUser>
{
    Task<DbUser?> GetAsync(string email, string password, CancellationToken token = default);
}