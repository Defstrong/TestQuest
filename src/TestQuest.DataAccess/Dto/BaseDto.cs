namespace TestQuest.DataAccess;

public abstract record BaseDto
{
    private readonly string? _id;
    public BaseDto()
        => Id = Guid.NewGuid().ToString();

    public string Id
    {
        get => _id ?? string.Empty;
        init => _id = value is { Length: > 0 }
            ? value : throw new ArgumentOutOfRangeException(nameof(value));
    }
}