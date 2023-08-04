namespace TestQuest.DataAccess;

public record DbTest : BaseDbEntity
{
    private readonly string? _name;
    private readonly Difficulty _difficulty;
    private readonly byte? _timeLimit;
    private readonly byte? _totalQuestions;
    private readonly string? _authorId;
    private readonly DateTime? _createdAt;
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


    public string AuthorId
    {
        get => _authorId ?? string.Empty;
        init => _authorId = value is { Length: > 0 }
            ? value : throw new ArgumentOutOfRangeException(nameof(value));
    }

    public DateTime CreatedAt
    {
        get => _createdAt ?? new DateTime();
        init => _createdAt = value >= DateTime.Now
            ? value : throw new ArgumentOutOfRangeException(nameof(value));
    }

    public List<string> Category { get; init; } = new();
    public List<IQuestion> Questions { get; init; } = new();

    public TestStatus Status    
    {
        get => _status;
        init => _status = value;
    }
}