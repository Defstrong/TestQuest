namespace TestQuest.DataAccess;

public sealed record CategoryDto : BaseDto
{
    private readonly string? _category;
    public string Category 
    {
        get => _category ?? string.Empty;
        init => _category = value is { Length: > 0 }
            ? value : throw new ArgumentOutOfRangeException(nameof(value));
    }
}