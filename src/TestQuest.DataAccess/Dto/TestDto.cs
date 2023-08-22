namespace TestQuest.DataAccess;

public sealed record TestDto : BaseDto
{
    private readonly string? _name;
    private readonly byte? _timeLimit;
    private readonly byte? _ageLimit;
    private readonly DateTime? _createdAt;
    private readonly string? _description;

    public string Name
    {
        get => _name ?? string.Empty;
        init => _name = value is { Length: > 0 }
            ? value : throw new ArgumentOutOfRangeException(nameof(value));
    }

    public Difficulty Difficulty { get; init; }

    public byte TimeLimit
    {
        get => _timeLimit ?? 0;
        init => _timeLimit = value > 0
            ? value : throw new ArgumentOutOfRangeException(nameof(value));
    }

    public byte TotalQuestions { get; set; }
    public string? AuthorId { get; set; }

    public byte AgeLimit 
    {
        get => _ageLimit ?? 16;
        init => _ageLimit = value > 0
            ? value : throw new ArgumentOutOfRangeException(nameof(value));
    }

    public DateTime CreatedAt
    {
        get => _createdAt ?? new DateTime();
        init => _createdAt = DateTime.Now;
    }

    public TestStatus Status { get; init; }
    public List<CategoryDto> Category { get; init; } = new();
    public List<CommentAndTestScoreDto> CommentAndTestScores{ get; init; } = new();
    public List<DbQuestion> Questions { get; init; } = new();

    public string Description
    {
        get => _description ?? string.Empty;
        init => _description = value is { Length: > 0 }
            ? value : throw new ArgumentOutOfRangeException(nameof(value));
    }
}