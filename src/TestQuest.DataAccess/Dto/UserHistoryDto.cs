namespace TestQuest.DataAccess;

public sealed record UserHistoryDto : BaseDto
{
    private readonly string? _userId;
    private readonly byte? _correctAnswers;
    private readonly int? _result;
    
    public string UserId
    {
        get => _userId ?? string.Empty;
        init => _userId = value is { Length: > 0 }
            ? value : throw new ArgumentOutOfRangeException(nameof(value));
    }

    public byte CorrectAnswers
    {
        get => _correctAnswers ?? 0;
        init => _correctAnswers = value > 0
            ? value : throw new ArgumentOutOfRangeException(nameof(value));
    }

    public int Result
    {
        get => _result ?? 0;
        init => _result = value > 0
            ? value : throw new ArgumentOutOfRangeException(nameof(value));
    }

    public List<QuestionDto> _completedQuestion { get; init; } = new();
}