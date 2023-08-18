namespace TestQuest.DataAccess;

public sealed record CategoryDto : BaseDto
{
    private readonly string? _categories;

    public string Category 
    {
        get => _categories ?? string.Empty;
        init => _categories = value is { Length: > 0 }
            ? value : throw new ArgumentOutOfRangeException(nameof(value));
    }
    public string TestId { get; set; }

    public DbTest Test { get; set; } = new();
}