using TestQuest.DataAccess;

namespace TestQuest.BusinessLogic;

public sealed class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
        => _userRepository = userRepository;

    public async Task<bool> CreateAsync(UserDto model, CancellationToken token = default)
    {
        DbUser dbUser = model.DtoToDbUser();
        bool createResult = await _userRepository.CreateAsync(dbUser, token);
        return createResult;
    }

    public async Task<bool> DeleteAsync(string id, CancellationToken token = default)
    {
        bool deleteResult = await _userRepository.DeleteAsync(id, token);
        return deleteResult;
    }

    public async Task<UserDto> GetAsync(string id, CancellationToken token = default)
    {
        DbUser dbUser = await _userRepository.GetAsync(id, token);
        UserDto userAuthorizeDto = dbUser.DbUserToDto();
        return userAuthorizeDto;
    }

    public async Task<IEnumerable<UserDto>> GetAsync(CancellationToken token = default)
    {
        IEnumerable<DbUser> dbUser = await _userRepository.GetAsync(token);
        IEnumerable<UserDto> userDtos = dbUser.Select(u => u.DbUserToDto());
        return userDtos;
    }

    public async Task<bool> UpdateAsync(UserDto model, CancellationToken token = default)
    {
        DbUser dbUser = model.DtoToDbUser();
        bool updateResult = await _userRepository.UpdateAsync(dbUser, token);
        return updateResult;
    }
}