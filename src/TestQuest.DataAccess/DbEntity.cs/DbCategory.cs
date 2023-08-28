namespace TestQuest.DataAccess;

public record DbCategory : BaseDbEntity
{
    private readonly string? _categories;

    public string Category
    {
        get => _categories ?? string.Empty;
        init => _categories = value is { Length: > 0 }
            ? value : throw new ArgumentOutOfRangeException(nameof(value));
    }

    public string TestId { get; set; }
    public virtual DbTest Test { get; init; } = new();
}