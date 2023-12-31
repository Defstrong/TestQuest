namespace TestQuest.DataAccess;

public sealed record CategoryDto : BaseDto
{
    private readonly string? _categories;
    private readonly string? _testId;

    public string Category 
    {
        get => _categories ?? string.Empty;
        init => _categories = value is { Length: > 0 }
            ? value : throw new ArgumentOutOfRangeException(nameof(value));
    }
    public string TestId 
    {
        get => _testId ?? string.Empty;
        init => _testId = value is { Length: > 0 }
            ? value : throw new ArgumentOutOfRangeException(nameof(value));
    }

    public DbTest Test { get; init; } = new();
}