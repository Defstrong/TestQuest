namespace TestQuest.DataAccess;

public record CloseQuestionDto : BaseDto
{
    private readonly string? _question;
    // private readonly List<string> _options;
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