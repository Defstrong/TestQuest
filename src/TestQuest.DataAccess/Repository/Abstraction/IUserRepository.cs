namespace TestQuest.DataAccess;

public interface IUserRepository : IBaseRepository<DbUser>
{
    Task<DbUser?> UserDefinition(string email, string password, CancellationToken token = default);
}