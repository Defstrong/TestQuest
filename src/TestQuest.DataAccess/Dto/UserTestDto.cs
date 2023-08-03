namespace TestQuest.DataAccess;

public record UserTestDto : BaseDbEntity
{
    private readonly string? _name;
    private readonly Difficulty _difficulty;
    private readonly byte? _timeLimit;
    private readonly byte? _totalQuestions;
    private readonly byte? _correctAnswers;
    private readonly string? _result;
    private readonly string? _authorId;
    private readonly DateTime? _creationDate;
    // private readonly List<string>? _category;
    private readonly TestStatus _status;

    public string Name
    {
        get => _name ?? string.Empty;
        init => _name = value is { Length: > 0 }
            ? value : throw new ArgumentOutOfRangeException(nameof(value));
    }
    
    public Difficulty Difficulty 
    {
        get => _difficulty;
        init => _difficulty = value;
    }

    public byte TimeLimit 
    {
        get => _timeLimit ?? 0;
        init => _timeLimit = value > 0
            ? value : throw new ArgumentOutOfRangeException(nameof(value));
    }

    public byte TotalQuestions
    {
        get => _totalQuestions ?? 0;
        init => _totalQuestions = value > 0
            ? value : throw new ArgumentOutOfRangeException(nameof(value));
    }

    public byte CorrectAnswers
    {
        get => _correctAnswers ?? 0;
        init => _correctAnswers = value > 0
            ? value : throw new ArgumentOutOfRangeException(nameof(value));
    }

    public string Result
    {
        get => _result ?? string.Empty;
        init => _result = value is { Length: > 0 }
            ? value : throw new ArgumentOutOfRangeException(nameof(value));
    }

    public string AuthorId
    {
        get => _authorId ?? string.Empty;
        init => _authorId = value is { Length: > 0 }
            ? value : throw new ArgumentOutOfRangeException(nameof(value));
    }

    public DateTime CreationDate
    {
        get => _creationDate ?? new DateTime();
        init => _creationDate = value >= DateTime.Now
            ? value : throw new ArgumentOutOfRangeException(nameof(value));
    }

    public List<string> Category { get; init; } = new();

    public TestStatus Status    
    {
        get => _status;
        init => _status = value;
    }
}