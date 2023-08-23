namespace TestQuest.DataAccess;

public record DbQuestion : BaseDbEntity
{
    private readonly string? _question;
    private readonly string? _answer;

    public DbQuestion()
    {
        Id = Guid.NewGuid().ToString();
    }

    public string Question
    {
        get => _question ?? string.Empty;
        init => _question = value is { Length: > 0 }
            ? value : throw new ArgumentOutOfRangeException(nameof(value));
    }

    public string Answer
    {
        get => _answer ?? string.Empty;
        init => _answer = value is { Length: > 0 }
            ? value : throw new ArgumentOutOfRangeException(nameof(value));
    }
    public string TestId { get; set; }

    public virtual DbTest Test { get; init; } = new();
    public virtual List<DbOption> Options { get; init; } = new();
}