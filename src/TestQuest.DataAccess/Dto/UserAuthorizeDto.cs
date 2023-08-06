namespace TestQuest.DataAccess;

public sealed record UserAuthorizeDto : BaseDto
{
    private readonly string? _email;
    private readonly string? _password;

    public string Email
    {
        get => _email ?? string.Empty;
        init => _email = value is { Length: > 0 }
            ? value : throw new ArgumentOutOfRangeException(nameof(value));
    }

    public string Password
    {
        get => _password ?? string.Empty;
        init => _password = value is { Length: > 0 }
            ? value : throw new ArgumentOutOfRangeException(nameof(value));
    }
}