namespace TestQuest.DataAccess;

public record DbUser : BaseDbEntity
{
    private readonly string? _name;
    private readonly Gender _gender;
    private readonly byte? _age;
    private readonly int? _ratingPoints;

    public string Name
    {
        get => _name ?? string.Empty;
        init => _name = value is { Length: > 0 }
            ? value : throw new ArgumentOutOfRangeException(nameof(value));
    }

    public Gender Gender
    {
        get => _gender;
        init => _gender = value;
    }

    public byte Age
    {
        get => _age ?? 0;
        init => _age = value > 0
            ? value : throw new ArgumentOutOfRangeException(nameof(value));
    }

    public int RatingPoints
    {
        get => _ratingPoints ?? 0;
        init => _ratingPoints = value > 0
            ? value : throw new ArgumentOutOfRangeException(nameof(value));
    }

    public List<Achievement> Achievements { get; init; } = new();
}