using TestQuest.DataAccess;
namespace TestQuest.BusinessLogic;

public static class UserAuthorizeExtension
{
    public static UserAuthorizeDto DbUserAuthorizeToDto(this DbUserAuthorize dbUserAuthorize)
        => new()
        {
            Id = dbUserAuthorize.Id,
            Email = dbUserAuthorize.Email,
            Password = dbUserAuthorize.Password
        };

    public static DbUserAuthorize DtoToDbUserAuthorize(this UserAuthorizeDto userAuthorizeDto)
        => new()
        {
            Id = userAuthorizeDto.Id,
            Email = userAuthorizeDto.Email,
            Password = userAuthorizeDto.Password
        };
}