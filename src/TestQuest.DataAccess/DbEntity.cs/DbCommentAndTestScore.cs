namespace TestQuest.DataAccess;

public record DbCommentAndTestScore: BaseDto
{
    private readonly string? _commentText;
    private readonly string? _testId;
    private readonly byte? _score;
    private readonly string? _userId;

    public string CommentText
    {
        get => _commentText ?? string.Empty;
        init => _commentText = value is { Length: > 0 }
            ? value : throw new ArgumentOutOfRangeException(nameof(value));
    }

    public byte Score
    {
        get => _score ?? 0;
        init => _score = value > 0
            ? value : throw new ArgumentOutOfRangeException(nameof(value));
    }

    public string TestId 
    {
        get => _testId ?? string.Empty;
        init => _testId = value is { Length: > 0 }
            ? value : throw new ArgumentOutOfRangeException(nameof(value));
    }

    public string UserId
    {
        get => _userId ?? string.Empty;
        init => _userId = value is { Length: > 0 }
            ? value : throw new ArgumentOutOfRangeException(nameof(value));
    }

    public virtual DbTest Test { get; init; } = new();
}