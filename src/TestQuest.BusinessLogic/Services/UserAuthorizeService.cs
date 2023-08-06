using TestQuest.DataAccess;

namespace TestQuest.BusinessLogic;

public sealed class UserAuthorizeService : IUserAuthorizeService
{
    private readonly IUserAuthorizeRepository _userAuthorizeRepository;

    public UserAuthorizeService(IUserAuthorizeRepository userAuthorizeRepository) 
        => _userAuthorizeRepository = userAuthorizeRepository;

    public async Task<bool> CreateAsync(UserAuthorizeDto model, CancellationToken token = default)
    {
        DbUserAuthorize dbUserAuthorize = model.DtoToDbUserAuthorize();
        bool createResult = await _userAuthorizeRepository.CreateAsync(dbUserAuthorize, token);
        return createResult;
    }

    public async Task<bool> DeleteAsync(string id, CancellationToken token = default)
    {
        bool deleteResult = await _userAuthorizeRepository.DeleteAsync(id, token);
        return deleteResult;
    }

    public async Task<UserAuthorizeDto> GetAsync(string id, CancellationToken token = default)
    {
        DbUserAuthorize dbUserAuthorize = await _userAuthorizeRepository.GetAsync(id, token);
        UserAuthorizeDto userAuthorizeDto = dbUserAuthorize.DbUserAuthorizeToDto();
        return userAuthorizeDto;
    }

    public async Task<IEnumerable<UserAuthorizeDto>> GetAsync(CancellationToken token = default)
    {
        IEnumerable<DbUserAuthorize> dbUserAuthorizes = await _userAuthorizeRepository.GetAsync(token);
        IEnumerable<UserAuthorizeDto> userAuthorizeDtos = dbUserAuthorizes.Select(ua => ua.DbUserAuthorizeToDto());
        return userAuthorizeDtos;
    }

    public async Task<bool> UpdateAsync(UserAuthorizeDto model, CancellationToken token = default)
    {
        DbUserAuthorize dbUserAuthorize = model.DtoToDbUserAuthorize();
        bool updateResult = await _userAuthorizeRepository.UpdateAsync(dbUserAuthorize, token);
        return updateResult;
    }
}