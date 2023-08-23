namespace TestQuest.DataAccess;

public record UserDto : BaseDto
{
    private readonly string? _name;
    private readonly byte? _age;
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

    public string Name
    {
        get => _name ?? string.Empty;
        init => _name = value is { Length: > 0 }
            ? value : throw new ArgumentOutOfRangeException(nameof(value));
    }

    public Gender Gender { get; init; }
    public AccessLevel AccessLevel { get; set; } = AccessLevel.Full;

    public byte Age
    {
        get => _age ?? 0;
        init => _age = value > 0
            ? value : throw new ArgumentOutOfRangeException(nameof(value));
    }

    public int RatingPoints { get; set; }

    public List<Achievement> Achievements { get; set; } = new();

    public Role Role { get; init; } = Role.User;
}