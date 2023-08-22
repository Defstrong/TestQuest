namespace TestQuest.DataAccess;

public record DbQuestionAnswer : BaseDbEntity
{
    private readonly string? _questionText;
    private readonly string? _answer;
    private readonly string? _correctAnswer;

    public string QuestionText
    {
        get => _questionText ?? string.Empty;
        init => _questionText = value is { Length: > 0 }
            ? value : throw new ArgumentOutOfRangeException(nameof(value));
    }

    public string Answer 
    {
        get => _answer ?? string.Empty;
        init => _answer = value is { Length: > 0 }
            ? value : throw new ArgumentOutOfRangeException(nameof(value));
    }

    public string CorrectAnswer
    {
        get => _correctAnswer ?? string.Empty;
        init => _correctAnswer = value is { Length: > 0 }
            ? value : throw new ArgumentOutOfRangeException(nameof(value));
    }

    public QuestionStatus Status { get; set; }
    public string? ResultTestId { get; init; }
    public virtual DbResultTest ResultTest { get; set;} = new();
}