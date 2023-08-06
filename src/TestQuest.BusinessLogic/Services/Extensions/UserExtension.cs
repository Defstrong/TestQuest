using TestQuest.DataAccess;
namespace TestQuest.BusinessLogic;

public static class UserExtension
{
    public static UserDto DbUserToDto(this DbUser dbUser)
        => new()
        {
            Id = dbUser.Id,
            Name = dbUser.Name,
            Gender = dbUser.Gender,
            Age = dbUser.Age
        };

    public static DbUser DtoToDbUser(this UserDto userDto)
        => new()
        {
            Id = userDto.Id,
            Name = userDto.Name,
            Gender = userDto.Gender,
            Age = userDto.Age
        };
}