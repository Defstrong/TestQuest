namespace TestQuest.DataAccess;

public record UserDto : BaseDto
{
    private readonly string? _name;
    private readonly Gender _gender;
    private readonly byte? _age;

    public string Name
    {
        get => _name ?? string.Empty;
        init => _name = value is { Length: > 0 }
            ? value : throw new ArgumentOutOfRangeException(nameof(value));
    }

    public Gender Gender
    {
        get => _gender;
        init => _gender = value;
    }

    public byte Age
    {
        get => _age ?? 0;
        init => _age = value > 0
            ? value : throw new ArgumentOutOfRangeException(nameof(value));
    }
}