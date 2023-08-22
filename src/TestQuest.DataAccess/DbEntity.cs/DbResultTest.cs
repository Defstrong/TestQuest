namespace TestQuest.DataAccess;

public record DbResultTest : BaseDbEntity
{
    private readonly string? _userId;
    private readonly byte? _correctAnswers;
    private readonly uint? _resultPoints;

    public string UserId
    {
        get => _userId ?? string.Empty;
        init => _userId = value is { Length: > 0 }
            ? value : throw new ArgumentOutOfRangeException(nameof(value));
    }
    public byte CorrectAnswers
    {
        get => _correctAnswers ?? 0;
        init => _correctAnswers = value >= 0
            ? value : throw new ArgumentOutOfRangeException(nameof(value));
    }

    public uint ResultPoints
    {
        get => _resultPoints ?? 0;
        init => _resultPoints = value >= 0
            ? value : throw new ArgumentOutOfRangeException(nameof(value));
    }

    public DateTime CompletedAt { get; init; }

    public virtual List<DbQuestionAnswer> QuestionAnswers { get; init; } = new();
}