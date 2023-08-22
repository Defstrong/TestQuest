namespace TestQuest.DataAccess;

public record QuestionAnswerDto : BaseDto
{
    private readonly string? _questionText;
    private readonly string? _answer;
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
    public QuestionStatus Status { get; set; }
    public virtual DbResultTest ResultTest { get; set;} = new();
}