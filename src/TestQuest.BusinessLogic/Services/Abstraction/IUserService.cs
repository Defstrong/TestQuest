using TestQuest.DataAccess;
namespace TestQuest.BusinessLogic;

public interface IUserService : IBaseService<UserDto>
{
    Task<UserDto?> GetAsync(SingInData singInData, CancellationToken token = default);
}