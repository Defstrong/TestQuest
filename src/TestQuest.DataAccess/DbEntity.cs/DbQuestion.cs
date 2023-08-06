namespace TestQuest.DataAccess;

public sealed record DbQuestion : BaseDbEntity
{
    private readonly string? _question;
    private readonly string? _answer;

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

    public List<string> Options { get; init; } = new();
}