namespace TestQuest.DataAccess;

public sealed record DbOption : BaseDbEntity
{
    private readonly string? _option;
    // private readonly string? _idQuestion;

    // public string IdQuestion
    // {
    //     get => _idQuestion ?? string.Empty;
    //     init => _idQuestion = value is { Length: > 0 }
    //         ? value : throw new ArgumentOutOfRangeException(nameof(value));
    // }

    public string Option
    {
        get => _option ?? string.Empty;
        init => _option = value is { Length: > 0 }
            ? value : throw new ArgumentOutOfRangeException(nameof(value));
    }
    public DbQuestion Question { get; init; } = new();
}