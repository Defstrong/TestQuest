using TestQuest.DataAccess;
namespace TestQuest.BusinessLogic;

public interface IUserService : IBaseService<UserDto>
{
    Task<UserDto?> UserDefinition(SingInData singInData, CancellationToken token = default);
}