using TestQuest.DataAccess;
using AutoMapper;

namespace TestQuest.BusinessLogic;

public sealed class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UserService(IUserRepository userRepository, IMapper mapper)
    {
        _mapper = mapper;
        _userRepository = userRepository;
    }

    public async Task<bool> CreateAsync(UserDto entity, CancellationToken token = default)
    {
        DbUser dbUser = _mapper.Map<DbUser>(entity);
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
        DbUser? dbUser = await _userRepository.GetAsync(id, token);
        UserDto userAuthorizeDto = _mapper.Map<UserDto>(dbUser);
        return userAuthorizeDto;
    }

    public async Task<IEnumerable<UserDto>> GetAsync(CancellationToken token = default)
    {
        IEnumerable<DbUser> dbUsers = await _userRepository.GetAsync(token);
        IEnumerable<UserDto> userDtos = _mapper.Map<IEnumerable<UserDto>>(dbUsers);
        return userDtos;
    }

    public async Task<UserDto?> UserDefinition(SingInData singInData, CancellationToken token = default)
    {
        DbUser? getResult = await _userRepository.UserDefinition(singInData.Email, singInData.Password);
        UserDto userDto = _mapper.Map<UserDto>(getResult);
        return userDto;
    }

    public async Task<bool> UpdateAsync(UserDto entity, CancellationToken token = default)
    {
        DbUser dbUser = _mapper.Map<DbUser>(entity);
        bool updateResult = await _userRepository.UpdateAsync(dbUser, token);
        return updateResult;
    }
}