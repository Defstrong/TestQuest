namespace TestQuest.DataAccess;

public record CommentAndTestScoreDto : BaseDto
{
    private readonly string? _commentText;
    private readonly byte? _score;

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

    public string UserName { get; set; }

    public string? TestId { get; set; }

    public string? UserId { get; set; }

    public DbTest Test { get; init; } = new();
}