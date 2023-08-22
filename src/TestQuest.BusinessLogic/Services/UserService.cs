using TestQuest.DataAccess;
using AutoMapper;

namespace TestQuest.BusinessLogic;

public sealed class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UserService(IUserRepository userRepository, IMapper mapper)
    {
        ArgumentNullException.ThrowIfNull(userRepository);
        ArgumentNullException.ThrowIfNull(mapper);

        _mapper = mapper;
        _userRepository = userRepository;
    }

    public async Task<bool> CreateAsync(UserDto entity, CancellationToken token = default)
    {
        ArgumentNullException.ThrowIfNull(entity);

        DbUser dbUser = _mapper.Map<DbUser>(entity);
        bool createResult = await _userRepository.CreateAsync(dbUser, token);

        return createResult;
    }

    public async Task<bool> DeleteAsync(string id, CancellationToken token = default)
    {
        ArgumentException.ThrowIfNullOrEmpty(id);

        bool deleteResult = await _userRepository.DeleteAsync(id, token);

        return deleteResult;
    }

    public async Task<UserDto> GetAsync(string id, CancellationToken token = default)
    {
        ArgumentException.ThrowIfNullOrEmpty(id);

        DbUser? dbUser = await _userRepository.GetAsync(id, token);
        UserDto userAuthorizeDto = _mapper.Map<UserDto>(dbUser);

        return userAuthorizeDto;
    }

    public async Task<IEnumerable<UserDto>> GetAsync(CancellationToken token = default)
    {
        IEnumerable<DbUser> dbUsers = await _userRepository.GetAsync(token);
        IEnumerable<UserDto> usersDtos = _mapper.Map<IEnumerable<UserDto>>(dbUsers);

        return usersDtos;
    }

    public async Task<UserDto?> GetAsync(SingInData singInData, CancellationToken token = default)
    {
        ArgumentNullException.ThrowIfNull(singInData);

        DbUser? getResult = await _userRepository.GetAsync(singInData.Email, singInData.Password, token);
        UserDto userDto = _mapper.Map<UserDto>(getResult);

        return userDto;
    }

    public async Task<bool> UpdateAsync(UserDto entity, CancellationToken token = default)
    {
        ArgumentNullException.ThrowIfNull(entity);

        DbUser dbUser = _mapper.Map<DbUser>(entity);
        bool updateResult = await _userRepository.UpdateAsync(dbUser, token);

        return updateResult;
    }
}